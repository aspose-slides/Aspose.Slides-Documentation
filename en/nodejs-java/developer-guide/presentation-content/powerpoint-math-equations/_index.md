---
title: Add Math Equations to PowerPoint Presentations in JavaScript
linktitle: PowerPoint Math Equations
type: docs
weight: 80
url: /nodejs-java/powerpoint-math-equations/
keywords:
- math equation
- math symbol
- math formula
- math text
- add math equation
- add math symbol
- add math formula
- add math text
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Insert and edit math equations in PowerPoint PPT and PPTX with Aspose.Slides for Node.js, supporting OMML, formatting controls, and clear code samples."
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

Using [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/), you can work with math equations in the PowerPoint presentations programmatically in C#. Create new math expressions or edit previously created ones. The export of mathematical structures into images is also partially supported.


## **How to Create a Mathematical Equation**
Mathematical elements are used for building any mathematical constructions with any level of nesting. A linear collection of mathematical elements forms a mathematical block represented by the [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) class. [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) class essentially is a separated mathematical expression, formula, or equation. [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) is a mathematical portion, used to hold mathematical text (do not mix with [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) allows manipulating a set of math blocks. The abovementioned classes are the key to work with PowerPoint math equations via Aspose.Slides API.

Let's see how we can create the following mathematical equation via Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

To add a mathematical expression on the slide, first, add a shape that will contain the mathematical text:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

After creating, the shape will already contain one paragraph with a mathematical portion by default. The [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) class is a portion that contains a mathematical text inside. To access mathematical content inside [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion), refer to the [**MathParagraph** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph)variable:

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

The [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) class allows to read, add, edit and delete math blocks ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

Each mathematical element is represented by some class that implements the **MathElement** class. This class provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

Operations of the class **MathElement** are implemented in any type of element, including the [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock).

The full source code sample:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
    var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    var fraction = new aspose.slides.MathematicalText("x").divide("y");
    mathParagraph.add(new aspose.slides.MathBlock(fraction));
    var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);
    pres.save("math.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

## **Mathematical Element Types**
Mathematical expressions are formed from sequences of mathematical elements. The sequence of mathematical elements is represented by a mathematical block, and arguments of mathematical elements form a tree-like nesting.

There are a lot of mathematical element types that can be used to construct a mathematical block. Each of these elements can be included (aggregated) in another element. That is, elements are actually containers for others, forming a tree-like structure. The simplest type of element that does not contain other elements of the mathematical text.

Each type of math element implements the **MathElement** class, allowing the use of the common set of math operations on different types of math elements.
### **MathematicalText class**
The [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) class represents a mathematical text - the underlying element of all mathematical constructions. Mathematical text may represent operands and operators, variables, and any other linear text.

Example: 𝑎=𝑏+𝑐
### **MathFraction class**
[**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction) class specifies the fraction object, consisting of a numerator and denominator separated by a fraction bar. The fraction bar can be horizontal or diagonal, depending on the fraction properties. The fraction object is also used to represent the stack function, which places one element above another, with no fraction bar.

Example:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical class**
[**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical) class specifies the radical function (mathematical root), consisting of a base, and an optional degree.

Example:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction class**
[**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) class specifies a function of an argument. Contains properties: [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) - function name and [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) - function argument.

Example:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator class**
[**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) class specifies an N-ary mathematical object, such as Summation and Integral. It consists of an operator, a base (or operand), and optional upper and lower limits. Examples of N-ary operators are Summation, Union, Intersection, Integral.

This class does not include simple operators such as addition, subtraction, and so on. They are represented by a single text element - [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText).

Example:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit class**
[**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) class creates the upper or lower limit. It specifies the limit object, consisting of text on the baseline and reduced-size text immediately above or below it. This element does not include the word “lim", but allows you to place text at the top or at the bottom of the expression. So, the expression 

![todo:image_alt_text](powerpoint-math-equations_8.png)

is created using a combination of [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) and [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) elements this way:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement classes**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

The following classes specify a lower index or an upper index. You can set subscript and superscript at the same time on the left or on the right side of an argument, but single subscript or superscript is supported on the right side only. The [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) can also be used to set the mathematical degree of a number.

Example: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix class**
[**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix) class specifies the Matrix object, consisting of child elements laid out in one or more rows and columns. It is important to note that matrixes do not have built-in delimiters. To place the matrix in the brackets you should use the delimiter object - [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). Null arguments can be used to create gaps in matrices.

Example: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray class**
[**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray) class specifies a vertical array of equations or any mathematical objects.

Example: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatting Mathematical Elements**
- [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox) class: draws a rectangular or some other border around the **MathElement**.
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox) class: specifies the logical boxing (packaging) of the mathematical element. For example, a boxed object can serve as an operator emulator with or without an alignment point, serve as a line breakpoint, or be grouped such as not to allow line breaks within. For example, the "==" operator should be boxed to prevent line breaks.
- [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter) class: specifies the delimiter object, consisting of opening and closing characters (such as parentheses, braces, brackets, and vertical bars), and one or more mathematical elements inside, separated by a specified character. Examples: (𝑥2); [𝑥2|𝑦2].
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent) class: specifies the accent function, consisting of a base and a combining diacritical mark.

  Example: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar) class: specifies the bar function, consisting of a base argument and an overbar or underbar.
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter) class: specifies a grouping symbol above or below an expression, usually to highlight the relationships between elements.
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematical Operations**
Each mathematical element and mathematical expression (via [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) implements the **MathElement** class. It allows you to use operations on the existing structure and form more complex mathematical expressions. All operations have two parameter sets: either **MathElement** or string as arguments. Instances of the [**MathematicalText** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText)class are implicitly created from specified strings when string arguments are used. Math operations available in Aspose.Slides are listed below.
### **Join method**
- `join(String)`
- `join(MathElement)`

Joins a mathematical element and forms a mathematical block. For example:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Divide method**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`
Creates a fraction of the specified type with this numerator and specified denominator. For example:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Enclose method**
- `enclose()`
- `enclose(Char, Char)`

Encloses the element in specified characters such as parenthesis or another character as framing.

```java
/**
 * <p>
 * Enclose a math element in parenthesis
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Encloses this element in specified characters such as parenthesis or another characters as framing
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 


For example:

```javascript
var delimiter = new aspose.slides.MathematicalText("x").enclose('[', ']');
var delimiter2 = new aspose.slides.MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function method**
- `function(String)`
- `function(MathElement)`

Takes a function of an argument using the current object as the function name.

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(MathElement functionArgument);

/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 


For example:

```javascript
var func = new aspose.slides.MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction method**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

Takes the specified function using the current instance as the argument. You can:

- specify a string as the function name, for example “cos”.
- select one of the predefined values of the enumerations [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) or [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments), for example [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- select the instance of the **MathElement**.

For example:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft methods**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

Sets subscript and superscript. You can set subscript and superscript at the same time on the left or on the right side of the argument, but single subscript or superscript is supported only on the right side. The **Superscript** can also be used to set the mathematical degree of a number.

Example:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical method**
- `radical(String)`
- `radical(MathElement)`

Specifies the mathematical root of the given degree from the specified argument.

Example:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **SetUpperLimit and SetLowerLimit methods**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

Takes the upper or lower limit. Here, the upper and bottom simply indicate the location of the argument relative to the base.

Let's consider an expression: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Such expressions can be created through a combination of classes [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) and [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit), and operations of the `MathElement` as follows:

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary and Integral methods**
- `nary(MathNaryOperatorTypes, MathElement, MathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

Both **nary** and **integral** methods create and return the N-ary operator represented by the [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) type. In nary method, the [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperatorTypes) enumeration specifies the type of operator: summation, union, etc., not including integrals. In Integral method, there is the specialized operation Integral with the enumeration of integral types [**MathIntegralTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathIntegralTypes). 

Example:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray method**
**toMathArray** puts elements in a vertical array. If this operation is called for a [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) instance, all child elements will be placed in the returned array.

Example:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **Formatting operations: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **accent** method sets an accent mark (a character on the top of the element).
- **overbar** and **underbar** methods set a bar on the top or bottom.
- **group** method places in a group using a grouping character such as a bottom curly bracket or another.
- **toBorderBox** method places in a border-box.
- **toBox** method places in a non-visual box (logical grouping).

Examples:

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **FAQ**

**How can I add a mathematical equation to a PowerPoint slide?**

To add a mathematical equation, you need to create a `MathShape` object, which automatically contains a mathematical portion. Then, you retrieve the `MathParagraph` from the `MathPortion` and add `MathBlock` objects to it.

**Is it possible to create complex nested mathematical expressions?**

Yes, Aspose.Slides allows you to create complex mathematical expressions by nesting MathBlocks. Each mathematical element inherits the `MathElement` class, which allows you to apply operations (Join, Divide, Enclose, etc.) to combine elements into more complex structures.

**How can I update or modify an existing mathematical equation?**

To update an equation, you need to access the existing MathBlocks through the `MathParagraph`. Then, by using methods such as Join, Divide, Enclose, and others, you can modify individual elements of the equation. After editing, save the presentation to apply the changes.
