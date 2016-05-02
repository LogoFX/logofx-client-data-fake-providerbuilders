using System;
using Attest.Fake.Setup;
using Attest.Fake.Setup.Contracts;

namespace LogoFX.Client.Data.Fake.ProviderBuilders
{
    /// <summary>
    /// Base provider builder with basic setup functionality.
    /// </summary>
    /// <typeparam name="TProvider">The type of the provider.</typeparam>
    [Serializable]
    public abstract class FakeBuilderBase<TProvider> : Attest.Fake.Builders.FakeBuilderBase<TProvider> where TProvider : class
    {
        /// <summary>
        /// Creates initial template for the fake setup.
        /// </summary>
        /// <returns></returns>
        private IHaveNoMethods<TProvider> CreateInitialSetup()
        {
            return ServiceCallFactory.CreateServiceCall(FakeService);
        }

        /// <summary>
        /// Override this method to substitute method calls in the faked service.
        /// </summary>
        protected override void SetupFake()
        {
            var initialSetup = CreateInitialSetup();
            var setup = CreateServiceCall(initialSetup);
            setup.Build();
        }

        /// <summary>
        /// Override this method to create service call from the provided template.
        /// </summary>
        /// <param name="serviceCallTemplate">The service call template.</param>
        /// <returns></returns>
        protected abstract IServiceCall<TProvider> CreateServiceCall(IHaveNoMethods<TProvider> serviceCallTemplate);
    }
}
