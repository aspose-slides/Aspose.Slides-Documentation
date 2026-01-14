---
title: Add Math Equations to PowerPoint Presentations in Python
linktitle: Math Equations
type: docs
weight: 80
url: /python-net/powerpoint-math-equations/
keywords:
- math equation
- PowerPoint math equation
- math symbol
- PowerPoint math symbol
- math formula
- PowerPoint math formula
- math text
- PowerPoint math text
- add math equation to PowerPoint
- add math symbol to PowerPoint
- add math formula to PowerPoint
- add math text to PowerPoint
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn how to work with mathematical equations in PowerPoint using Aspose.Slides for Python via .NET. Get detailed instructions, code examples, and tips to automate the creation and editing of presentations."
---

## **Overview**

In PowerPoint, you can write a math equation or formula and display it in your presentation. Various mathematical symbols are available and can be added to text or equations. The math equations constructor is used to create complex formulas like:

- Math fraction
- Math radical
- Math function
- Limits and log functions
- N-ary operations
- Matrix
- Large operators
- Sin, cos functions

To add a mathematical equation in PowerPoint, the *Insert -> Equation* menu is used:

![todo:image_alt_text](powerpoint-math-equations_1.png)

This will create a mathematical text in XML that can be displayed in PowerPoint as following:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint supports a wide range of mathematical symbols for creating equations. However, generating complex math equations in PowerPoint often doesn't yield a polished, professional result. As a result, users who frequently create mathematical presentations often turn to third-party solutions for better-looking math formulas.

Using the [**Aspose.Slides API**](https://products.aspose.com/slides/python-net/), you can work with math equations in PowerPoint presentations programmatically in Python. Create new math expressions or edit previously created ones. Partial support is available for exporting mathematical structures as images.

## **How to Create a Mathematical Equation**

Mathematical elements are used to build any mathematical construction, regardless of nesting level. A linear collection of these elements forms a mathematical block, represented by the [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) class. The [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) class represents a standalone mathematical expression, formula, or equation. [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) is used to hold mathematical text (distinct from the regular [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) class), while [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) allows you to manipulate a set of [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objects. These classes are essential for working with PowerPoint math equations via the Aspose.Slides API.

Let's see how we can create the following mathematical equation using the Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

To add a mathematical expression to the slide, first add a shape that will contain the mathematical text:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```

After creating the shape, it already contains one paragraph with a mathematical portion by default. The [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) class represents a portion that contains mathematical text. To access the mathematical content inside a [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/), refer to the [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) variable:

```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```

The [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) class lets you read, add, edit, and delete math blocks ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)), which consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
``` 

Each mathematical element is represented by a class that implements the [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) class. This class provides numerous methods to easily create mathematical expressions, enabling you to construct fairly complex equations with just a single line of code. For example, the Pythagorean theorem would look like this:

```py
math_block = (
    math.MathematicalText("c").set_superscript("2").
        join("=").
        join(math.MathematicalText("a").set_superscript("2")).
        join("+").
        join(math.MathematicalText("b").set_superscript("2")))
```

Operations of the [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) class are implemented in every type of element, including the [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) class.

Below is the full source code sample:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    math_paragraph.add(math.MathBlock(fraction))

    math_block = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    math_paragraph.add(math_block)

    presentation.save("math.pptx", slides.export.SaveFormat.PPTX)
```

## **Mathematical Element Types**

Mathematical expressions are composed of sequences of mathematical elements. A mathematical block represents such a sequence, and the arguments of these elements form a nested, tree-like structure.

There are many types of mathematical elements that can be used to construct a mathematical block. Each of these elements can be aggregated within another, forming a tree-like structure. The simplest type of element is one that does not contain any other mathematical text elements.

Each type of math element implements the [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) class, allowing you to use a common set of math operations on different types of math elements.

### **MathematicalText class**

The [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) class represents a mathematical text—the underlying element of all mathematical constructions. Mathematical text may represent operands and operators, variables, or any other linear text.

Example: 𝑎=𝑏+𝑐

### **MathFraction class**

The [MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) class specifies a fraction object consisting of a numerator and denominator separated by a fraction bar. The fraction bar can be horizontal or diagonal, depending on the fraction properties. The fraction object is also used to represent the stack function, which places one element above another without a fraction bar.

Example:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical class**

The [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) class specifies the radical function (mathematical root), consisting of a base and an optional degree.

Example:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction class**

The [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) class specifies a function of an argument. It contains properties such as [name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/name/), which represents the function name, and [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/base/), which represents the function argument.

Example:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator class**

The [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) class specifies an N-ary mathematical object, such as a Summation or Integral. It consists of an operator, a base (or operand), and optional upper and lower limits. Examples of N-ary operators are Summation, Union, Intersection, and Integral. for a couple of seconds
The MathNaryOperator class specifies an N-ary mathematical object, such as Summation and Integral. It consists of an operator, a base (or operand), and optional upper and lower limits. Examples of N-ary operators include Summation, Union, Intersection, and Integral.

This class does not include simple operators such as addition, subtraction, and so on. They are represented by a single text [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/).

Example:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit class**

The [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) class creates the upper or lower limit. It specifies the limit object, consisting of text on the baseline and reduced-size text immediately above or below it. This element does not include the word "lim", but allows you to place text at the top or bottom of the expression. So, the expression 

![todo:image_alt_text](powerpoint-math-equations_8.png)

is created using a combination of [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) and [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) elements this way:

```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement classes**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

These classes specify a lower index or an upper index. You can set both subscript and superscript simultaneously on the left or right side of an argument, but a single subscript or superscript is supported only on the right side. The [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) can also be used to set the mathematical degree of a number.

Example: 

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix class**

The [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) class specifies the Matrix object, which consists of child elements arranged in one or more rows and columns. It is important to note that matrices do not have built-in delimiters. To enclose the matrix in brackets, use the delimiter object [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/). Null arguments can be used to create gaps in matrices.

Example: 

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray class**

The [MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) class specifies a vertical array of equations or any mathematical objects.

Example: 

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatting Mathematical Elements**

- [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) class: Draws a rectangular or alternative border around the [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

Example:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) class: Specifies the logical boxing (packaging) of a mathematical element. A boxed object can serve as an operator emulator—with or without an alignment point—function as a line breakpoint, or be grouped to prevent line breaks within. For example, the "==" operator should be boxed to prevent line breaks.

- [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) class: Specifies the delimiter object, which consists of opening and closing characters (such as parentheses, braces, brackets, or vertical bars) and one or more mathematical elements inside, separated by a specified character. Examples include: (𝑥2); [𝑥2|𝑦2].

Example:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) class: Specifies the accent function, which consists of a base and a combining diacritical mark.

Example: 𝑎́.

- [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) class: Specifies the bar function, which consists of a base argument and an overbar or underbar.

Example:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) class: Specifies a grouping symbol placed above or below an expression, typically to highlight the relationships between elements.

Example:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematical Operations**

Each mathematical element and each mathematical expression (via [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) implements the [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) class. This allows you to perform operations on the existing structure and form more complex mathematical expressions. All operations have two sets of parameters: either [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) or string arguments. Instances of the [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) class are implicitly created from specified strings when string arguments are used. Math operations available in Aspose.Slides are listed below.

### **Join method**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

These methods join a mathematical element and forms a mathematical block. For example:

```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```

### **Divide method**

- [divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str)
- [divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str-mathfractiontypes)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement-mathfractiontypes)

These methods create a fraction of the specified type with a numerator and specified denominator. For example:

```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```

### **Enclose method**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

These methods enclose the element in specified characters, such as parentheses or other framing characters. For example:

```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```

### **Function method**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

These methods take a function of an argument using the current object as the function name. For example:

```py
function = math.MathematicalText("sin").function("x")
```

### **AsArgumentOfFunction method**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

These methods take the specified function using the current instance as the argument. You can:

- specify a string as the function name, for example "cos";
- select one of the predefined values of the enumerations [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) or [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/), for example `MathFunctionsOfOneArgument.ARC_SIN`;
- select the instance of the [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

For example:

```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
func1 = math.MathematicalText("2x").as_argument_of_function(function_name)
func2 = math.MathematicalText("x").as_argument_of_function("sin")
func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft methods**

- [set_subscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#str)
- [set_subscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#imathelement)
- [set_superscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#str)
- [set_superscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#imathelement)
- [set_sub_superscript_on_the_right(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#str-str)
- [set_sub_superscript_on_the_right(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#imathelement-imathelement)
- [set_sub_superscript_on_the_left(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#str-str)
- [set_sub_superscript_on_the_left(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#imathelement-imathelement)

These methods set subscript and superscript. You can set both simultaneously on either the left or right side of the argument; however, a single subscript or superscript is supported only on the right side. The **Superscript** can also be used to set the mathematical degree of a number.

Example:

```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```

### **Radical method**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

These methods specify the mathematical root of the given degree based on the specified argument.

Example:

```py
radical = math.MathematicalText("x").radical("3")
```

### **SetUpperLimit and SetLowerLimit methods**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

These methods take an upper or lower limit, where "upper" and "lower" indicate the position of the argument relative to the base.

Let's consider an expression: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Such expressions can be created through a combination of the [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) and [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/) classes, along with operations of the [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) class, as follows:

```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```

### **Nary and Integral methods**

- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-imathelement-imathelement)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-str-str)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement-mathlimitlocations)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str-mathlimitlocations)

Both `nary` and `integral` methods create and return the N-ary operator represented by the [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) type. In the Nary method, the [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) enumeration specifies the type of operator—such as summation or union—excluding integrals. In the Integral method, a specialized operation for integrals is provided, using the [MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/) enumeration.

Example:

```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```
### **ToMathArray method**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) puts elements into a vertical array. If this operation is called on a [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) instance, all its child elements will be placed in the returned array.

Example:

```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```

### **Formatting operations: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- [accent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/accent/) method sets an accent mark (a character on the top of the element).
- [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/overbar/) and [underbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/underbar/) methods set a bar on the top or bottom.
- [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/group/) method places in a group using a grouping character such as a bottom curly bracket or another.
- [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_border_box/) method places in a border-box.
- [to_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_box/) method places in a non-visual box (logical grouping).

Examples:

```py
accent = math.MathematicalText("x").accent(chr(0x0303))
bar = math.MathematicalText("x").overbar()
group_chr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
        math.MathTopBotPositions.BOTTOM, 
        math.MathTopBotPositions.TOP)
border_box = math.MathematicalText("x+y+z").to_border_box()
boxed_operator = math.MathematicalText(":=").to_box()
```

## **FAQ**

**How can I add a mathematical equation to a PowerPoint slide?**

To add a mathematical equation, you need to [create a math shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) object, which automatically contains a mathematical portion. Then, you retrieve the [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) from the [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) and add [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) objects to it.

**Is it possible to create complex nested mathematical expressions?**

Yes, Aspose.Slides allows you to create complex mathematical expressions by nesting [MathBlocks](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Each mathematical element allows you to apply operations (Join, Divide, Enclose, etc.) to combine elements into more complex structures.

**How can I update or modify an existing mathematical equation?**

To update an equation, you need to access the existing [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) through the [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Then, by using methods such as Join, Divide, Enclose, and others, you can modify individual elements of the equation. After editing, save the presentation to apply the changes.
