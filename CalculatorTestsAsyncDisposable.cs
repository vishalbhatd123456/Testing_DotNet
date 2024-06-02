using System;
using System.Collections.Generic;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculateLibraryMain;
using Xunit.Abstractions;

namespace CalcTestProject
{
    public class CalcTestsAsyncDisposable : IAsyncLifetime
    {
        //arrange
        private readonly Calculator _sut = new();
        private readonly Guid _guid = Guid.NewGuid();
        private readonly ITestOutputHelper _outputHelper;

        public CalcTestsAsyncDisposable(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _outputHelper.WriteLine("Hello from constructor...");
        }

        [Fact]
        public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers()
        {

            //act
            var res = _sut.Add(5,5);

            //assert
            Assert.Equal(10,res);
        }

        public async Task InitializeAsync()
        {
            _outputHelper.WriteLine("FROM INITITALIZE Async");
            await Task.Delay(1);
        }

        public async Task DisposeAsync()
        {
            _outputHelper.WriteLine("Hello frm cleanup...");
            await Task.Delay(5);
        }

        //[TEARDOWN]
        // 1. CONSTRUCTOR -> INITITALIZE -> DISPOSE
    }
}