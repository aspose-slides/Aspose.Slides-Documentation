---
title: PowerPoint Math Equations
type: docs
weight: 60
url: /net/powerpoint-math-equations/
keywords: " PowerPoint Math Equations, PowerPoint Math Symbols, PowerPoint Formula, PowerPoint Math Text"
description: "PowerPoint Math Equations, PowerPoint Math Symbols, PowerPoint Formula, PowerPoint Math Text"
---

## **Overview**
In PowerPoint, it is possible to write a math equation or formula and display it in the presentation. To do that, various mathematical symbols are represented in PowerPoint and can be added to the text or equation. For that, the math equations constructor is used in PowerPoint, which helps to create complex formulas like:

- Math Fraction
- Math Radical
- Math Function
- Limits and log functions
- N-ary operations
- Matrix
- Large operators
- Sin, cos functions

To add a mathematical equation in PowerPoint, the *Insert -> Equation* menu is used:

![todo:image_alt_text](powerpoint-math-equations_1.png)

This will create a mathematical text in XML that can be displayed in PowerPoint as following: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint supports plenty of mathematical symbols to create math equations. However, creating complicated math equations in PowerPoint often does not bring a good and professional-looking result. Users, who need to create mathematical presentations frequently, resort to the use of third-party solutions to create good-looking math formulas.

Using [**Aspose.Slide API**](https://products.aspose.com/slides/net), you can work with math equations in the PowerPoint presentations programmatically in C#. Create new math expressions or edit previously created ones. The export of mathematical structures into images is also partially supported.


## **How to Create a Mathematical Equation**
Mathematical elements are used for building any mathematical constructions with any level of nesting. A linear collection of mathematical elements forms a mathematical block represented by the [**MathBlock** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)class. [**MathBlock** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)class essentially is a separated mathematical expression, formula, or equation. [**MathPortion**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) is a mathematical portion, used to hold mathematical text (do not mix with [**Portion**](https://apireference.aspose.com/slides/net/aspose.slides/portion)). [**MathParagraph** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)allows manipulating a set of math blocks. The abovementioned classes are the key to work with PowerPoint math equations via Aspose.Slides API.



Let's see how we can create the following mathematical equation via Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

To add a mathematical expression on the slide, first, add a shape that will contain the mathematical text:

``` csharp

 using (Presentation pres = new Presentation())

{

    var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

}

``` 


After creating, the shape will already contain one paragraph with a mathematical portion by default. The [**MathPortion** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathportion)class is a portion that contains a mathematical text inside. To access mathematical content inside [**MathPortion**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathportion), refer to the [**MathParagraph** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)variable:

``` csharp

 var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

``` 


The [**MathParagraph** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)class allows to read, add, edit and delete math blocks ([**MathBlock**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

``` csharp

 var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));

``` 


Each mathematical element is represented by some class that implements the [**IMathElement** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)interface. This interface provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

``` csharp

 var mathBlock = new MathematicalText("c")

    .SetSuperscript("2")

    .Join("=")

    .Join(new MathematicalText("a").SetSuperscript("2"))

    .Join("+")

    .Join(new MathematicalText("b").SetSuperscript("2"));

``` 



Operations of the interface [**IMathElement** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)are implemented in any type of element, including the [**MathBlock**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

The full source code sample:

``` csharp

 using (Presentation pres = new Presentation())

{

    IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

   var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;



   var fraction = new MathematicalText("x").Divide("y");

    mathParagraph.Add(new MathBlock(fraction));



   var mathBlock = new MathematicalText("c")

        .SetSuperscript("2")

        .Join("=")

        .Join(new MathematicalText("a").SetSuperscript("2"))

        .Join("+")

        .Join(new MathematicalText("b").SetSuperscript("2"));

    mathParagraph.Add(mathBlock);

    pres.Save("math.pptx", SaveFormat.Pptx);

}

``` 


## **Mathematical Element Types**
Mathematical expressions are formed from sequences of mathematical elements. The sequence of mathematical elements is represented by a mathematical block, and arguments of mathematical elements form a tree-like nesting.

There are a lot of mathematical element types that can be used to construct a mathematical block. Each of these elements can be included (aggregated) in another element. That is, elements are actually containers for others, forming a tree-like structure. The simplest type of element that does not contain other elements of the mathematical text.

Each type of math element implements the [**IMathElement** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)interface, allowing the use of the common set of math operations on different types of math elements.
### **MathematicalText class**
The [**MathematicalText** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext)class represents a mathematical text - the underlying element of all mathematical constructions. Mathematical text may represent operands and operators, variables, and any other linear text.

Example: 𝑎=𝑏+𝑐
### **MathFraction class**
[**MathFraction** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction)class specifies the fraction object, consisting of a numerator and denominator separated by a fraction bar. The fraction bar can be horizontal or diagonal, depending on the fraction properties. The fraction object is also used to represent the stack function, which places one element above another, with no fraction bar.

Example:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical class**
[**MathRadical** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathradical)class specifies the radical function (mathematical root), consisting of a base, and an optional degree.

Example:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction class**
[**MathFunction** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction)class specifies a function of an argument. Contains properties: [Name ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name)- function name and [Base](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) - function argument.

Example:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator class**
[**MathNaryOperator** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator)class specifies an N-ary mathematical object, such as Summation and Integral. It consists of an operator, a base (or operand), and optional upper and lower limits. Examples of N-ary operators are Summation, Union, Intersection, Integral.

This class does not include simple operators such as addition, subtraction, and so on. They are represented by a single text element - [MathematicalText](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

Example:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit class**
[**MathLimit** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit)class creates the upper or lower limit. It specifies the limit object, consisting of text on the baseline and reduced-size text immediately above or below it. This element does not include the word “lim", but allows you to place text at the top or at the bottom of the expression. So, the expression 

![todo:image_alt_text](powerpoint-math-equations_8.png)

is created using a combination of [**MathFunction** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction)and [**MathLimit** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit)elements this way:

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));

``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement classes**
- [MathSubscriptElement](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

The following classes specify a lower index or an upper index. You can set subscript and superscript at the same time on the left or on the right side of an argument, but single subscript or superscript is supported on the right side only. The [MathSubscriptElement ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)can also be used to set the mathematical degree of a number.

Example: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix class**
[**MathMatrix** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix)class specifies the Matrix object, consisting of child elements laid out in one or more rows and columns. It is important to note that matrixes do not have built-in delimiters. To place the matrix in the brackets you should use the delimiter object - [**IMathDelimiter**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). Null arguments can be used to create gaps in matrices.

Example: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray class**
[**MathArray** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/matharray)class specifies a vertical array of equations or any mathematical objects.

Example: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatting Mathematical Elements**
- [**MathBorderBox** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox)class: draws a rectangular or some other border around the [**IMathElement**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathbox)class: specifies the logical boxing (packaging) of the mathematical element. For example, a boxed object can serve as an operator emulator with or without an alignment point, serve as a line breakpoint, or be grouped such as not to allow line breaks within. For example, the "==" operator should be boxed to prevent line breaks.
- [**MathDelimiter** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter)class: specifies the delimiter object, consisting of opening and closing characters (such as parentheses, braces, brackets, and vertical bars), and one or more mathematical elements inside, separated by a specified character. Examples: (𝑥2); [𝑥2|𝑦2].
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent)class: specifies the accent function, consisting of a base and a combining diacritical mark. 

  Example: 𝑎́.

- [**MathBar** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/MathBar)class: specifies the bar function, consisting of a base argument and an overbar or underbar.
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter)class: specifies a grouping symbol above or below an expression, usually to highlight the relationships between elements.
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematical Operations**
Each mathematical element and mathematical expression (via [**MathBlock**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) implements the [**IMathElement** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)interface. It allows you to use operations on the existing structure and form more complex mathematical expressions. All operations have two parameter sets: either [**IMathElement** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)or string as arguments. Instances of the [**MathematicalText** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText)class are implicitly created from specified strings when string arguments are used. Math operations available in Aspose.Slides are listed below.
### **Join method**
- [Join(String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Joins a mathematical element and forms a mathematical block. For example:

``` csharp

 IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);

``` 
### **Divide method**
- [Divide(String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Creates a fraction of the specified type with this numerator and specified denominator. For example:

``` csharp

 IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);

``` 
### **Enclose method**
- [Enclose()](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

Encloses the element in specified characters such as parenthesis or another character as framing.

``` csharp

 /// <summary>

/// Encloses a math element in parenthesis

/// </summary>

IMathDelimiter Enclose();

/// <summary>

/// Encloses this element in specified characters such as parenthesis or another characters as framing

/// </summary>

IMathDelimiter Enclose(char beginningCharacter, char endingCharacter);

``` 


For example:

``` csharp

 IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();

``` 
### **Function method**
- [Function(String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Takes a function of an argument using the current object as the function name.

``` csharp

 /// <summary>

/// Takes a function of an argument using this instance as the function name

/// </summary>

/// <param name="functionArgument">An argument of the function</param>

IMathFunction Function(IMathElement functionArgument);

IMathFunction Function(string functionArgument);

``` 


For example:

``` csharp

 IMathFunction func = new MathematicalText("sin").Function("x");

``` 
### **AsArgumentOfFunction method**
- [AsArgumentOfFunction(String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

Takes the specified function using the current instance as the argument. You can:

- specify a string as the function name, for example “cos”.
- select one of the predefined values of the enumerations [**MathFunctionsOfOneArgument** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument)or [**MathFunctionsOfTwoArguments**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments), for example **MathFunctionsOfOneArgument.ArcSin.**
- select the instance of the [**IMathElement**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement).

For example:

``` csharp

 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);

var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");

var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")

``` 
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft methods**
- [SetSubscript(String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

Sets subscript and superscript. You can set subscript and superscript at the same time on the left or on the right side of the argument, but single subscript or superscript is supported only on the right side. The **Superscript** can also be used to set the mathematical degree of a number.

Example:

``` csharp

 var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");

``` 
### **Radical method**
- [Radical(String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Specifies the mathematical root of the given degree from the specified argument.

Example:

``` csharp

 var radical = new MathematicalText("x").Radical("3");

``` 
### **SetUpperLimit and SetLowerLimit methods**
- [SetUpperLimit(String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Takes the upper or lower limit. Here, the upper and bottom simply indicate the location of the argument relative to the base.

Let's consider an expression: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Such expressions can be created through a combination of classes [MathFunction ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction)and [MathLimit](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit), and operations of the [IMathElement ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)as follows:

``` csharp

 var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");

``` 
### **Nary and Integral methods**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://apireference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

Both **Nary** and **Integral** methods create and return the N-ary operator represented by the [**INaryOperator** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator)type. In Nary method, the [**MathNaryOperatorTypes** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes)enumeration specifies the type of operator: summation, union, etc., not including integrals. In Integral method, there is the specialized operation Integral with the enumeration of integral types [**MathIntegralTypes**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes). 

Example:

``` csharp

 IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());

IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");

``` 
### **ToMathArray method**
[**ToMathArray**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) puts elements in a vertical array. If this operation is called for a **MathBlock** instance, all child elements will be placed in the returned array.

Example:

``` csharp

 var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();

``` 
### **Formatting operations: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**Accent**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) method sets an accent mark (a character on the top of the element).
- [**Overbar**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) and [**Underbar**](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) methods set a bar on the top or bottom.
- [**Group** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group)method places in a group using a grouping character such as a bottom curly bracket or another.
- [**ToBorderBox** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox)method places in a border-box.
- [**ToBox** ](https://apireference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox)method places in a non-visual box (logical grouping).

Examples:

``` csharp

 var accent = new MathematicalText("x").Accent('\u0303');

var bar = new MathematicalText("x").Overbar();

var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

var borderBox = new MathematicalText("x+y+z").ToBorderBox();

var boxedOperator = new MathematicalText(":=").ToBox();

``` 
