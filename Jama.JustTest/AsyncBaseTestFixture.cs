//using System;
//using System.Threading.Tasks;
//using StructureMap.AutoMocking.Moq;

//namespace Jama.JustTest
//{
//    public abstract class AsyncBaseTestFixture<TSubjectUnderTest> where TSubjectUnderTest : class
//    {
//        protected MoqAutoMocker<TSubjectUnderTest> AutoMocker;

//        protected TSubjectUnderTest SubjectUnderTest;
//        protected Exception CaughtException;
//        protected virtual void SetupDependencies() { }
//        protected virtual async Task GivenAsync() {  }
//        protected virtual async Task WhenAsync() { }
//        protected virtual void Finally() { }

//        [Given]
//        public async Task Setup()
//        {
//            BuildMocks();
//            SetupDependencies();
//            SubjectUnderTest = BuildSubjectUnderTest();

//            await GivenAsync();

//            try
//            {
//                await WhenAsync();
//            }
//            catch (Exception exception)
//            {
//                CaughtException = exception;
//            }
//            finally
//            {
//                Finally();
//            }
//        }

//        private void BuildMocks()
//        {
//            AutoMocker = new MoqAutoMocker<TSubjectUnderTest>();
//        }

//        private TSubjectUnderTest BuildSubjectUnderTest()
//        {
//            return AutoMocker.ClassUnderTest;
//        }
//    }
//}