using System;

namespace Jama.JustTest
{
    public abstract class SimpleTestFixture
    {
        protected Exception CaughtException;
        protected virtual void SetupDependencies() { }
        protected virtual void Given() { }
        protected virtual void When() { }
        protected virtual void Finally() { }

        [Given]
        public void Setup()
        {
            SetupDependencies();

            Given();

            try
            {
                When();
            }
            catch (Exception exception)
            {
                CaughtException = exception;
            }
            finally
            {
                Finally();
            }
        }
    }
}