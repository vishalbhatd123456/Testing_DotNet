using System;
using System.Collections.Generic;   
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculateLibraryMain;
using Xunit.Abstractions;
using FluentAssertions;


namespace CalcTestProject
{
    public class CalculatorTests : IDisposable
    {
	//arrange
	private readonly Calculator _sut = new();
	private readonly Guid _guid = Guid.NewGuid();

	private readonly ITestOutputHelper _outputHelper;

	public Calculator calc = new (){
		fullName = "Visal"
	}

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
	    //Assert.Equal(expected, res); //assert versus the actual versus the 
		res.Should().Be(expected);
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

	[Fact]
	public void StringAssertion()
	{
		var fullName = _sut.fullName;

		fullName.Should().Be("Vishal");
	}
	[Fact]	
	public void TestAgeBeingANumber()
	{

    var age = _sut.Age;

    age.Should().BePositive();
    age.Should().Be(21);
    age.Should().BeGreaterThanOrEqualTo(18);
	}	
	 
	public void Dispose()
	{
	    //throw new NotImplementedException();
	    _outputHelper.WriteLine("Hello from clean up:");
	}

	[Fact]
	public void TestObjectExample()
	{
		var _testObj = new Calculator()
		{
			fullName = "Vishal"
		};

		var user = _sut.calc;

		Assert.Equal(user, _testObj); //the test fails here due to reference comparisons

		user.Should().BeEquivalentTo(_testObj
	}

	[Fact]
	public void TestDivideByZeroException(){
		var _test = _sut.Divide(1,0);

		Action result = () => Calculator.Divide(1,0);

		_test.Should().Throw<DivideByZeroException>().WithMessage("attempt to divide with zero.")
	}
    }
}
