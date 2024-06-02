using System;
using System.Collections.Generic;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculateLibraryMain;
using Xunit.Abstractions;


namespace CalcTestProject
{
    public class CalculatorTests : IDisposable
    {
	//arrange
	private readonly Calculator _sut = new();
	private readonly Guid _guid = Guid.NewGuid();

	private readonly ITestOutputHelper _outputHelper;

	public CalculatorTests(ITestOutputHelper outputHelper)
	{
	    _outputHelper = outputHelper;
	    _outputHelper.WriteLine("Hello from constructor");
	}

	[Fact]
	public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers()
	{
	    //act
	    var res = _sut.Add(5, 5);

	    //assert
	    Assert.Equal(10, res); //assert versus the actual versus the 
	}


	//parametrized
	[Theory]
	[InlineData(1,2,3)]
	[InlineData(0,1,1)]
	[InlineData(1,1,2)]
	public void Add_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers(int a, int b, int expected)
	{
	    //act
	    var res = _sut.Add(a, b);

	    //assert
	    Assert.Equal(expected, res); //assert versus the actual versus the 
	}

	[Fact]
	public void TestGuid()
	{
	    _outputHelper.WriteLine(_guid.ToString());
	}
	[Fact]
	public void TestGuid2()
	{
	    _outputHelper.WriteLine(_guid.ToString());
	}
	 
	public void Dispose()
	{
	    //throw new NotImplementedException();
	    _outputHelper.WriteLine("Hello from clean up:");
	}
    }
}
