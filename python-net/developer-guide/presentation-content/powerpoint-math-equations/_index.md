---
title: PowerPoint Math Equations
type: docs
weight: 80
url: /python-net/powerpoint-math-equations/
keywords: " PowerPoint Math Equations, PowerPoint Math Symbols, PowerPoint Formula, PowerPoint Math Text, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "PowerPoint Math Equations, Math Symbols, Formula, and Math Text in Python"
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

Using [**Aspose.Slide API**](https://products.aspose.com/slides/python-net/), you can work with math equations in the PowerPoint presentations programmatically in Python. Create new math expressions or edit previously created ones. The export of mathematical structures into images is also partially supported.


## **How to Create a Mathematical Equation**
Mathematical elements are used for building any mathematical constructions with any level of nesting. A linear collection of mathematical elements forms a mathematical block represented by the [**MathBlock** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathblock/)class. [**MathBlock** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathblock/)class essentially is a separated mathematical expression, formula, or equation. [**MathPortion**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathportion/) is a mathematical portion, used to hold mathematical text (do not mix with [**Portion**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/portion/)). [**MathParagraph** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathparagraph/)allows manipulating a set of math blocks. The abovementioned classes are the key to work with PowerPoint math equations via Aspose.Slides API.



Let's see how we can create the following mathematical equation via Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

To add a mathematical expression on the slide, first, add a shape that will contain the mathematical text:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


After creating, the shape will already contain one paragraph with a mathematical portion by default. The [**MathPortion** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathportion/)class is a portion that contains a mathematical text inside. To access mathematical content inside [**MathPortion**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathportion/), refer to the [**MathParagraph** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathparagraph/)variable:

```py
    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph
```


The [**MathParagraph** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathparagraph/)class allows to read, add, edit and delete math blocks ([**MathBlock**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathblock/)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```py
    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))
```


Each mathematical element is represented by some class that implements the [**IMathElement** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)interface. This interface provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

```py
    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))
```



Operations of the interface [**IMathElement** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)are implemented in any type of element, including the [**MathBlock**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathblock/).

The full source code sample:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))

    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    mathParagraph.add(mathBlock)

    pres.save("math.pptx", slides.export.SaveFormat.PPTX)
```


## **Mathematical Element Types**
Mathematical expressions are formed from sequences of mathematical elements. The sequence of mathematical elements is represented by a mathematical block, and arguments of mathematical elements form a tree-like nesting.

There are a lot of mathematical element types that can be used to construct a mathematical block. Each of these elements can be included (aggregated) in another element. That is, elements are actually containers for others, forming a tree-like structure. The simplest type of element that does not contain other elements of the mathematical text.

Each type of math element implements the [**IMathElement** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)interface, allowing the use of the common set of math operations on different types of math elements.
### **MathematicalText class**
The [**MathematicalText** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathematicaltext/)class represents a mathematical text - the underlying element of all mathematical constructions. Mathematical text may represent operands and operators, variables, and any other linear text.

Example: 𝑎=𝑏+𝑐
### **MathFraction class**
[**MathFraction** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathfraction/)class specifies the fraction object, consisting of a numerator and denominator separated by a fraction bar. The fraction bar can be horizontal or diagonal, depending on the fraction properties. The fraction object is also used to represent the stack function, which places one element above another, with no fraction bar.

Example:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical class**
[**MathRadical** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathradical/)class specifies the radical function (mathematical root), consisting of a base, and an optional degree.

Example:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction class**
[**MathFunction** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathfunction/)class specifies a function of an argument. Contains properties: [Name ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathfunction/)- function name and [Base](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathfunction/) - function argument.

Example:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator class**
[**MathNaryOperator** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathnaryoperator/)class specifies an N-ary mathematical object, such as Summation and Integral. It consists of an operator, a base (or operand), and optional upper and lower limits. Examples of N-ary operators are Summation, Union, Intersection, Integral.

This class does not include simple operators such as addition, subtraction, and so on. They are represented by a single text element - [MathematicalText](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathematicaltext/).

Example:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit class**
[**MathLimit** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathlimit/)class creates the upper or lower limit. It specifies the limit object, consisting of text on the baseline and reduced-size text immediately above or below it. This element does not include the word “lim", but allows you to place text at the top or at the bottom of the expression. So, the expression 

![todo:image_alt_text](powerpoint-math-equations_8.png)

is created using a combination of [**MathFunction** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathfunction/)and [**MathLimit** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathlimit/)elements this way:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
    mathFunc = math.MathFunction(funcName, math.MathematicalText("𝑥"))
```


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement classes**
- [MathSubscriptElement](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

The following classes specify a lower index or an upper index. You can set subscript and superscript at the same time on the left or on the right side of an argument, but single subscript or superscript is supported on the right side only. The [MathSubscriptElement ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathsubscriptelement/)can also be used to set the mathematical degree of a number.

Example: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix class**
[**MathMatrix** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathmatrix/)class specifies the Matrix object, consisting of child elements laid out in one or more rows and columns. It is important to note that matrixes do not have built-in delimiters. To place the matrix in the brackets you should use the delimiter object - [**IMathDelimiter**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathdelimiter/). Null arguments can be used to create gaps in matrices.

Example: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray class**
[**MathArray** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/matharray/) class specifies a vertical array of equations or any mathematical objects.

Example: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatting Mathematical Elements**
- [**MathBorderBox**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathborderbox/) class: draws a rectangular or some other border around the [**IMathElement**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/).
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathbox/)class: specifies the logical boxing (packaging) of the mathematical element. For example, a boxed object can serve as an operator emulator with or without an alignment point, serve as a line breakpoint, or be grouped such as not to allow line breaks within. For example, the "==" operator should be boxed to prevent line breaks.
- [**MathDelimiter** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathdelimiter/)class: specifies the delimiter object, consisting of opening and closing characters (such as parentheses, braces, brackets, and vertical bars), and one or more mathematical elements inside, separated by a specified character. Examples: (𝑥2); [𝑥2|𝑦2].
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathaccent/)class: specifies the accent function, consisting of a base and a combining diacritical mark. 

  Example: 𝑎́.

- [**MathBar** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/MathBar/)class: specifies the bar function, consisting of a base argument and an overbar or underbar.
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/MathGroupingCharacter/)class: specifies a grouping symbol above or below an expression, usually to highlight the relationships between elements.
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematical Operations**
Each mathematical element and mathematical expression (via [**MathBlock**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathblock/)) implements the [**IMathElement** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)interface. It allows you to use operations on the existing structure and form more complex mathematical expressions. All operations have two parameter sets: either [**IMathElement** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)or string as arguments. Instances of the [**MathematicalText** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathematicaltext/)class are implicitly created from specified strings when string arguments are used. Math operations available in Aspose.Slides are listed below.
### **Join method**
- [Join(String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Join(IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)

Joins a mathematical element and forms a mathematical block. For example:

```py
    element1 = math.MathematicalText("x")
    element2 = math.MathematicalText("y")
    block = element1.join(element2)
```
### **Divide method**
- [Divide(String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Divide(String, MathFractionTypes)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement, MathFractionTypes)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)

Creates a fraction of the specified type with this numerator and specified denominator. For example:

```py
    numerator = math.MathematicalText("x")
    fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```
### **Enclose method**
- [Enclose()](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Enclose(Char, Char)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)

Encloses the element in specified characters such as parenthesis or another character as framing.

```py
# Encloses a math element in parenthesis
MathDelimiter enclose()

# Encloses this element in specified characters such as parenthesis or another characters as framing
MathDelimiter enclose(char beginningCharacter, char endingCharacter)
```


For example:

```py
    delimiter = math.MathematicalText("x").enclose('[', ']')
    delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```
### **Function method**
- [Function(String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Function(IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)

Takes a function of an argument using the current object as the function name.

For example:

```py
func = math.MathematicalText("sin").function("x")
```
### **AsArgumentOfFunction method**
- [AsArgumentOfFunction(String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)

Takes the specified function using the current instance as the argument. You can:

- specify a string as the function name, for example “cos”.
- select one of the predefined values of the enumerations [**MathFunctionsOfOneArgument** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathfunctionsofoneargument/)or [**MathFunctionsOfTwoArguments**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathfunctionsoftwoarguments/), for example **MathFunctionsOfOneArgument.ArcSin.**
- select the instance of the [**IMathElement**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/).

For example:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
    func1 = math.MathematicalText("2x").as_argument_of_function(funcName)
    func2 = math.MathematicalText("x").as_argument_of_function("sin")
    func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
    func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft methods**
- [SetSubscript(String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetSubscript(IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(String, String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(String, String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)

Sets subscript and superscript. You can set subscript and superscript at the same time on the left or on the right side of the argument, but single subscript or superscript is supported only on the right side. The **Superscript** can also be used to set the mathematical degree of a number.

Example:

```py
    script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```
### **Radical method**
- [Radical(String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Radical(IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)

Specifies the mathematical root of the given degree from the specified argument.

Example:

```py
    radical = math.MathematicalText("x").radical("3")
```
### **SetUpperLimit and SetLowerLimit methods**
- [SetUpperLimit(String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetUpperLimit(IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)

Takes the upper or lower limit. Here, the upper and bottom simply indicate the location of the argument relative to the base.

Let's consider an expression: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Such expressions can be created through a combination of classes [MathFunction ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/MathFunction/)and [MathLimit](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/MathLimit/), and operations of the [IMathElement ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)as follows:

```py
mathExpression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```
### **Nary and Integral methods**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Nary(MathNaryOperatorTypes, String, String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)

Both **Nary** and **Integral** methods create and return the N-ary operator represented by the [**INaryOperator** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathnaryoperator/)type. In Nary method, the [**MathNaryOperatorTypes** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathnaryoperatortypes/)enumeration specifies the type of operator: summation, union, etc., not including integrals. In Integral method, there is the specialized operation Integral with the enumeration of integral types [**MathIntegralTypes**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/mathintegraltypes/). 

Example:

```py
    baseArg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
    integral = baseArg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```
### **ToMathArray method**
[**ToMathArray**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/) puts elements in a vertical array. If this operation is called for a **MathBlock** instance, all child elements will be placed in the returned array.

Example:

```py
    arrayFunction = math.MathematicalText("x").join("y").to_math_array()
```
### **Formatting operations: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**Accent**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/) method sets an accent mark (a character on the top of the element).
- [**Overbar**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/) and [**Underbar**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/) methods set a bar on the top or bottom.
- [**Group** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)method places in a group using a grouping character such as a bottom curly bracket or another.
- [**ToBorderBox** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)method places in a border-box.
- [**ToBox** ](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)method places in a non-visual box (logical grouping).

Examples:

```py
    accent = math.MathematicalText("x").accent(chr(0x0303))
    bar = math.MathematicalText("x").overbar()
    groupChr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
            math.MathTopBotPositions.BOTTOM, 
            math.MathTopBotPositions.TOP)
    borderBox = math.MathematicalText("x+y+z").to_border_box()
    boxedOperator = math.MathematicalText(":=").to_box()
```