---
title: PowerPoint Math Equations
type: docs
weight: 80
url: /cpp/powerpoint-math-equations/
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

Using [**Aspose.Slide API**](https://products.aspose.com/slides/cpp), you can work with math equations in the PowerPoint presentations programmatically in C++. Create new math expressions or edit previously created ones. The export of mathematical structures into images is also partially supported.


## **How to Create a Mathematical Equation**
Mathematical elements are used for building any mathematical constructions with any level of nesting. A linear collection of mathematical elements forms a mathematical block represented by the [**MathBlock** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)class. [**MathBlock** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)class essentially is a separated mathematical expression, formula, or equation. [**MathPortion**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion) is a mathematical portion, used to hold mathematical text (do not mix with [**Portion**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.portion)). [**MathParagraph** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)allows manipulating a set of math blocks. The abovementioned classes are the key to work with PowerPoint math equations via Aspose.Slides API.



Let's see how we can create the following mathematical equation via Aspose.Slides API:

![todo:image_alt_text](powerpoint-math-equations_3.png)

To add a mathematical expression on the slide, first, add a shape that will contain the mathematical text:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
``` 


After creating, the shape will already contain one paragraph with a mathematical portion by default. The [**MathPortion** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion)class is a portion that contains a mathematical text inside. To access mathematical content inside [**MathPortion**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_portion), refer to the [**MathParagraph** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)variable:

``` cpp
 auto mathParagraph = (System::DynamicCast_noexcept<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();
``` 


The [**MathParagraph** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_paragraph)class allows to read, add, edit and delete math blocks ([**MathBlock**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

``` cpp
auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));
``` 


Each mathematical element is represented by some class that implements the [**IMathElement** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)interface. This interface provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

``` cpp
auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")
  ->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
``` 



Operations of the interface [**IMathElement** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)are implemented in any type of element, including the [**MathBlock**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block).

The full source code sample:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto mathShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 720.0f, 150.0f);
auto mathParagraph = (System::DynamicCast_noexcept<MathPortion>(mathShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)))->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"x")->Divide(u"y");
mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

auto mathBlock = System::MakeObject<MathematicalText>(u"c")
  ->SetSuperscript(u"2")
  ->Join(u"=")
  ->Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
  ->Join(u"+")->Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
mathParagraph->Add(mathBlock);

pres->Save(u"math.pptx", SaveFormat::Pptx);
``` 


## **Mathematical Element Types**
Mathematical expressions are formed from sequences of mathematical elements. The sequence of mathematical elements is represented by a mathematical block, and arguments of mathematical elements form a tree-like nesting.

There are a lot of mathematical element types that can be used to construct a mathematical block. Each of these elements can be included (aggregated) in another element. That is, elements are actually containers for others, forming a tree-like structure. The simplest type of element that does not contain other elements of the mathematical text.

Each type of math element implements the [**IMathElement** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)interface, allowing the use of the common set of math operations on different types of math elements.
### **MathematicalText class**
The [**MathematicalText** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)class represents a mathematical text - the underlying element of all mathematical constructions. Mathematical text may represent operands and operators, variables, and any other linear text.

Example: 𝑎=𝑏+𝑐
### **MathFraction class**
[**MathFraction** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_fraction)class specifies the fraction object, consisting of a numerator and denominator separated by a fraction bar. The fraction bar can be horizontal or diagonal, depending on the fraction properties. The fraction object is also used to represent the stack function, which places one element above another, with no fraction bar.

Example:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical class**
[**MathRadical** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_radical)class specifies the radical function (mathematical root), consisting of a base, and an optional degree.

Example:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction class**
[**MathFunction** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)class specifies a function of an argument. Contains methods: [get_Name() ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a88b5a46342839d7ef1a8d273694bf0b3)- function name and [get_Base()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function#a765fa6bcbeb9b48730dbcb6504d9b543) - function argument.

Example:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator class**
[**MathNaryOperator** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_nary_operator)class specifies an N-ary mathematical object, such as Summation and Integral. It consists of an operator, a base (or operand), and optional upper and lower limits. Examples of N-ary operators are Summation, Union, Intersection, Integral.

This class does not include simple operators such as addition, subtraction, and so on. They are represented by a single text element - [MathematicalText](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text).

Example:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit class**
[**MathLimit** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit)class creates the upper or lower limit. It specifies the limit object, consisting of text on the baseline and reduced-size text immediately above or below it. This element does not include the word “lim", but allows you to place text at the top or at the bottom of the expression. So, the expression 

![todo:image_alt_text](powerpoint-math-equations_8.png)

is created using a combination of [**MathFunction** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)and [**MathLimit** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit)elements this way:

``` cpp
auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑥→∞"));
auto mathFunc = System::MakeObject<MathFunction>(funcName, System::MakeObject<MathematicalText>(u"𝑥"));
``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement classes**
- [MathSubscriptElement](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)
- [MathSuperscriptElement](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_superscript_element)
- [MathRightSubSuperscriptElement](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_right_sub_superscript_element)
- [MathLeftSubSuperscriptElement](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_left_sub_superscript_element)

The following classes specify a lower index or an upper index. You can set subscript and superscript at the same time on the left or on the right side of an argument, but single subscript or superscript is supported on the right side only. The [MathSubscriptElement ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_subscript_element)can also be used to set the mathematical degree of a number.

Example: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix class**
[**MathMatrix** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_matrix)class specifies the Matrix object, consisting of child elements laid out in one or more rows and columns. It is important to note that matrixes do not have built-in delimiters. To place the matrix in the brackets you should use the delimiter object - [**IMathDelimiter**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_delimiter). Null arguments can be used to create gaps in matrices.

Example: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray class**
[**MathArray** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_array)class specifies a vertical array of equations or any mathematical objects.

Example: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatting Mathematical Elements**
- [**MathBorderBox** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_border_box)class: draws a rectangular or some other border around the [**IMathElement**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_box)class: specifies the logical boxing (packaging) of the mathematical element. For example, a boxed object can serve as an operator emulator with or without an alignment point, serve as a line breakpoint, or be grouped such as not to allow line breaks within. For example, the "==" operator should be boxed to prevent line breaks.
- [**MathDelimiter** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_delimiter)class: specifies the delimiter object, consisting of opening and closing characters (such as parentheses, braces, brackets, and vertical bars), and one or more mathematical elements inside, separated by a specified character. Examples: (𝑥2); [𝑥2|𝑦2].
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_accent)class: specifies the accent function, consisting of a base and a combining diacritical mark. 

  Example: 𝑎́.

- [**MathBar** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_bar)class: specifies the bar function, consisting of a base argument and an overbar or underbar.
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_grouping_character)class: specifies a grouping symbol above or below an expression, usually to highlight the relationships between elements.
  
  Example: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematical Operations**
Each mathematical element and mathematical expression (via [**MathBlock**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_block)) implements the [**IMathElement** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)interface. It allows you to use operations on the existing structure and form more complex mathematical expressions. All operations have two parameter sets: either [**IMathElement** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)or string as arguments. Instances of the [**MathematicalText** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.mathematical_text)class are implicitly created from specified strings when string arguments are used. Math operations available in Aspose.Slides are listed below.
### **Join method**
- [Join(String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a40d44a0f16d2832ab67decf5e4698b49)
- [Join(IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a372375a4f990a157018466622d5d52d9)

Joins a mathematical element and forms a mathematical block. For example:

``` cpp
auto element1 = System::MakeObject<MathematicalText>(u"x");
    
auto element2 = System::MakeObject<MathematicalText>(u"y");

auto block = element1->Join(element2);
``` 


### **Divide method**
- [Divide(String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae3175481538f5a0a2d6bd3606e7ecfb6)
- [Divide(IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ae1b231db04fff125e5e8c96fd18e608a)
- [Divide(String, MathFractionTypes)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2a1029bda3a198390da3f1b6cb0f677d)
- [Divide(IMathElement, MathFractionTypes)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4a19fcb4fcc3a09327793f0ac823e19a)

Creates a fraction of the specified type with this numerator and specified denominator. For example:

``` cpp
auto numerator = System::MakeObject<MathematicalText>(u"x");
auto fraction = numerator->Divide(u"y", MathFractionTypes::Linear);
``` 
### **Enclose method**
- [Enclose()](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab0aa4399c0d506050a7aac9dc7f78804)
- [Enclose(Char, Char)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a36d623c14594a0926fc8121c42b87bf5)

Encloses the element in specified characters such as parenthesis or another character as framing.

``` cpp
/// <summary>
/// Encloses a math element in parenthesis
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose() = 0;

/// <summary>
/// Encloses this element in specified characters such as parenthesis or another characters as framing
/// </summary>
virtual System::SharedPtr<IMathDelimiter> Enclose(char16_t beginningCharacter, char16_t endingCharacter) = 0;
``` 


For example:

``` cpp
auto delimiter = System::MakeObject<MathematicalText>(u"x")->Enclose(u'[', u']');
auto delimiter2 = System::StaticCast<IMathElement>(System::MakeObject<MathematicalText>(u"elem1")->Join(u"elem2"))->Enclose();
``` 

### **Function method**
- [Function(String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afef234e875543a6437a9e2546174ae04)
- [Function(IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a320fcf20f060c1a378164558bfa670d4)

Takes a function of an argument using the current object as the function name.

``` cpp
/// <summary>
/// Takes a function of an argument using this instance as the function name
/// </summary>
/// <param name="functionArgument">An argument of the function</param>

virtual System::SharedPtr<IMathFunction> Function(System::SharedPtr<IMathElement> functionArgument) = 0;

virtual System::SharedPtr<IMathFunction> Function(System::String functionArgument) = 0;
``` 


For example:

``` cpp
auto func = System::MakeObject<MathematicalText>(u"sin")->Function(u"x");
``` 
### **AsArgumentOfFunction method**
- [AsArgumentOfFunction(String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2f9d0d8b693637f52f8aa9243fd5988e)
- [AsArgumentOfFunction(IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac1c703c0ed93628b61e20f622e3d91e9)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac540ffa6839db0e17b1096bc57803b3e)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a93dbde6d11b23e577c427a7d02cf13aa)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a304ca31f530ac1cf6c55dc59995a)

Takes the specified function using the current instance as the argument. You can:

- specify a string as the function name, for example “cos”.
- select one of the predefined values of the enumerations [**MathFunctionsOfOneArgument** ](https://apireference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#adc9da096602adece523e68cb7f302415)or [**MathFunctionsOfTwoArguments**](https://apireference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#a161816c6905df993b6c0aae0d98d597b), for example **MathFunctionsOfOneArgument.ArcSin.**
- select the instance of the [**IMathElement**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element).

For example:

``` cpp

auto funcName = System::MakeObject<MathLimit>(System::MakeObject<MathematicalText>(u"lim"), System::MakeObject<MathematicalText>(u"𝑛→∞"));
    
auto func1 = System::MakeObject<MathematicalText>(u"2x")->AsArgumentOfFunction(funcName);

auto func2 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(u"sin");

auto func3 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfOneArgument::Sin);

auto func4 = System::MakeObject<MathematicalText>(u"x")->AsArgumentOfFunction(MathFunctionsOfTwoArguments::Log, u"3");

``` 
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft methods**
- [SetSubscript(String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a1610efd629e0fef10f46397c3c671829)
- [SetSubscript(IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a747a756f05c3a5ebaf96ae4b9853d300)
- [SetSuperscript(String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a3e3613e5c07f1b9df5f59c533d5430d0)
- [SetSuperscript(IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aed4ce1bd63e756b9585214ad832d174a)
- [SetSubSuperscriptOnTheRight(String, String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acedc512b9952ca9ae6750ff75fd10b1d)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aba884260e8d8b434cbe666444bcb7cdc)
- [SetSubSuperscriptOnTheLeft(String, String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad3a3850ed28e26b627a46a6e7198228f)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afb8cea063303a9e81b6d7f50d9ce8c7c)

Sets subscript and superscript. You can set subscript and superscript at the same time on the left or on the right side of the argument, but single subscript or superscript is supported only on the right side. The **Superscript** can also be used to set the mathematical degree of a number.

Example:

``` cpp
auto script = System::MakeObject<MathematicalText>(u"y")->SetSubSuperscriptOnTheLeft(u"2x", u"3z");
``` 
### **Radical method**
- [Radical(String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aee6b34eb9da73f4c213b93228bfb2fab)
- [Radical(IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5a144aefdd800d5e564d368e4885ce30)

Specifies the mathematical root of the given degree from the specified argument.

Example:

``` cpp
auto radical = System::MakeObject<MathematicalText>(u"x")->Radical(u"3");
``` 
### **SetUpperLimit and SetLowerLimit methods**
- [SetUpperLimit(String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a8382894852974a63b242a303ad4973d0)
- [SetUpperLimit(IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acbcf1b88a42676de8794c889a4a33354)
- [SetLowerLimit(String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad14a530d7e4e8296ce38fc54b154c059)
- [SetLowerLimit(IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a2b580a403a87e19f64672cc50e7c53dd)

Takes the upper or lower limit. Here, the upper and bottom simply indicate the location of the argument relative to the base.

Let's consider an expression: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Such expressions can be created through a combination of classes [MathFunction ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_function)and [MathLimit](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.math_limit), and operations of the [IMathElement ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element)as follows:

``` cpp
auto mathExpression = System::MakeObject<MathematicalText>(u"lim")->SetLowerLimit(u"x→∞")->Function(u"x");
``` 
### **Nary and Integral methods**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab850b5a7244cf71b89810555e5f55e26)
- [Nary(MathNaryOperatorTypes, String, String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a667e2c89d5d77aacc51599177f543f75)
- [Integral(MathIntegralTypes)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ad2a93a7e43548d38e23552f480c85c01)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#afed3647d15dc6bd636f5bfa111dfd726)
- [Integral(MathIntegralTypes, String, String)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a27d1ee66c5a31ed7ac1b2d9cc1f6af7d)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aef3e63bdeb956c428b7b1ea385bcdad5)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a16a7f1cd3aa5d09543dfbf0b18bb024e)

Both **Nary** and **Integral** methods create and return the N-ary operator represented by the [**IMathNaryOperator** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_nary_operator)type. In Nary method, the [**MathNaryOperatorTypes** ](https://apireference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#abd1cf265844d1b4a2e33970bc64d1167)enumeration specifies the type of operator: summation, union, etc., not including integrals. In Integral method, there is the specialized operation Integral with the enumeration of integral types [**MathIntegralTypes**](https://apireference.aspose.com/slides/cpp/namespace/aspose.slides.math_text#ab12cc959f134cc6693e552d5b7f78607). 

Example:

``` cpp
auto baseArg = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = baseArg->Integral(MathIntegralTypes::Simple, u"0", u"1");
``` 
### **ToMathArray method**
[**ToMathArray**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ab3130531dfa9403d42ae02466100ddc1) puts elements in a vertical array. If this operation is called for a **MathBlock** instance, all child elements will be placed in the returned array.

Example:

``` cpp
auto arrayFunction = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->ToMathArray();
``` 
### **Formatting operations: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**Accent**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#acd0f38691b52fb83294c0da9f3690483) method sets an accent mark (a character on the top of the element).
- [**Overbar**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a5d4780f9be6d0709465f50f5d830d4e3) and [**Underbar**](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a97d93a1fc79a31f4ffd20d233e06c5a5) methods set a bar on the top or bottom.
- [**Group** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#a4662589060e34723455b8164ce556546)method places in a group using a grouping character such as a bottom curly bracket or another.
- [**ToBorderBox** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#aa32771655d8931aa8e0b5d3c1c7e160b)method places in a border-box.
- [**ToBox** ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.math_text.i_math_element#ac18b6b70362303cb307862a9aaa7dce2)method places in a non-visual box (logical grouping).

Examples:

``` cpp
auto accent = System::MakeObject<MathematicalText>(u"x")->Accent(u'\u0303');
    
auto bar = System::MakeObject<MathematicalText>(u"x")->Overbar();

auto groupChr = System::MakeObject<MathematicalText>(u"x")->Join(u"y")->Join(u"z")->Group(u'\u23E1', MathTopBotPositions::Bottom, MathTopBotPositions::Top);

auto borderBox = System::MakeObject<MathematicalText>(u"x+y+z")->ToBorderBox();

auto boxedOperator = System::MakeObject<MathematicalText>(u":=")->ToBox();
``` 
