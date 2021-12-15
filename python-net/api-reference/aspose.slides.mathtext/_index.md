---
title: aspose.slides.mathtext Namespace - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 120
url: /python-net/api-reference/aspose.slides.mathtext/
---


Contains classes for work with mathematical text in Microsoft PowerPoint presentations.

## **Classes**
|**Class**|**Description**|
| :- | :- |
|[BaseScript](/python-net/api-reference/aspose.slides.mathtext/basescript/)|Math script|
|[IMathAccent](/python-net/api-reference/aspose.slides.mathtext/imathaccent/)|Specifies the accent function, consisting of a base and a combining diacritical mark<br/>            Example: 𝑎́|
|[IMathAccentFactory](/python-net/api-reference/aspose.slides.mathtext/imathaccentfactory/)|Allows to create a math accent|
|[IMathArray](/python-net/api-reference/aspose.slides.mathtext/imatharray/)|Specifies a vertical array of equations or any mathematical objects|
|[IMathArrayFactory](/python-net/api-reference/aspose.slides.mathtext/imatharrayfactory/)|Allows to create a math array|
|[IMathBar](/python-net/api-reference/aspose.slides.mathtext/imathbar/)|Specifies the bar function, consisting of a base argument and an overbar or underbar|
|[IMathBarFactory](/python-net/api-reference/aspose.slides.mathtext/imathbarfactory/)|Allows to create a math bar|
|[IMathBlock](/python-net/api-reference/aspose.slides.mathtext/imathblock/)|Specifies an instance of mathematical text that contained within a MathParagraph and starts on its own line.<br/>            All math zones, including equations, expressions, arrays of equations or expressions, and formulas are represented by math block.|
|[IMathBlockCollection](/python-net/api-reference/aspose.slides.mathtext/imathblockcollection/)|Collection of math blocks (IMathBlock)|
|[IMathBlockFactory](/python-net/api-reference/aspose.slides.mathtext/imathblockfactory/)|Allows to create a math block|
|[IMathBorderBox](/python-net/api-reference/aspose.slides.mathtext/imathborderbox/)|Draws a rectangular or some other border around the IMathElement.|
|[IMathBorderBoxFactory](/python-net/api-reference/aspose.slides.mathtext/imathborderboxfactory/)|Allows to create a math border box|
|[IMathBox](/python-net/api-reference/aspose.slides.mathtext/imathbox/)|Specifies the logical boxing (packaging) of mathematical element.<br/>            For example, a boxed object can serve as an operator emulator with or without an alignment point, <br/>            serve as a line break point, or be grouped such as not to allow line breaks within.<br/>            For example, the "==" operator should be boxed to prevent line breaks.|
|[IMathBoxFactory](/python-net/api-reference/aspose.slides.mathtext/imathboxfactory/)|Allows to create a math box|
|[IMathDelimiter](/python-net/api-reference/aspose.slides.mathtext/imathdelimiter/)|Specifies the delimiter object, consisting of opening and closing characters (such as parentheses, <br/>            braces, brackets, and vertical bars), and one or more mathematical elements inside, separated by a specified character.<br/>            Examples: (𝑥2); [𝑥2|𝑦2]|
|[IMathDelimiterFactory](/python-net/api-reference/aspose.slides.mathtext/imathdelimiterfactory/)|Allows to create a math delimiter|
|[IMathElement](/python-net/api-reference/aspose.slides.mathtext/imathelement/)|Base interface of any mathematical element: <br/>            fraction, mathmatical text, function, expression with multiple elements etc|
|[IMathElementCollection](/python-net/api-reference/aspose.slides.mathtext/imathelementcollection/)|Represents a collection of mathematical elements (MathElement).|
|[IMathFraction](/python-net/api-reference/aspose.slides.mathtext/imathfraction/)|Specifies the fraction object, consisting of a numerator and denominator separated by a fraction bar.<br/>            The fraction bar can be horizontal or diagonal, depending on the fraction properties.<br/>            The fraction object is also used to represent the stack function, which places one element above another, with no fraction bar.|
|[IMathFractionFactory](/python-net/api-reference/aspose.slides.mathtext/imathfractionfactory/)|Allows to create a math fraction|
|[IMathFunction](/python-net/api-reference/aspose.slides.mathtext/imathfunction/)|Specifies a function of an argument.|
|[IMathFunctionFactory](/python-net/api-reference/aspose.slides.mathtext/imathfunctionfactory/)|Allows to create a math function|
|[IMathGroupingCharacter](/python-net/api-reference/aspose.slides.mathtext/imathgroupingcharacter/)|Specifies a grouping symbol above or below an expression, usually to highlight the relationship between elements|
|[IMathGroupingCharacterFactory](/python-net/api-reference/aspose.slides.mathtext/imathgroupingcharacterfactory/)|Allows to create a math grouping character|
|[IMathLeftSubSuperscriptElement](/python-net/api-reference/aspose.slides.mathtext/imathleftsubsuperscriptelement/)|Specifies the Sub-Superscript object, which consists of a base <br/>            and a subscript and superscript placed to the left of the base.|
|[IMathLimit](/python-net/api-reference/aspose.slides.mathtext/imathlimit/)|Specifies the Limit object, consisting of text on the baseline and reduced-size text immediately above or below it.|
|[IMathLimitFactory](/python-net/api-reference/aspose.slides.mathtext/imathlimitfactory/)|Allows to create IMathLimit|
|[IMathMatrix](/python-net/api-reference/aspose.slides.mathtext/imathmatrix/)|Specifies the Matrix object, consisting of child elements laid out in one or more rows and columns. <br/>            It is important to note that matrices do not have built in delimiters. <br/>            To place the matrix in the brackets you should use the delimiter object (IMathDelimiter).<br/>            Null arguments can be used to create gaps in matrices.|
|[IMathMatrixFactory](/python-net/api-reference/aspose.slides.mathtext/imathmatrixfactory/)|Allows to create a math matrix|
|[IMathNaryOperator](/python-net/api-reference/aspose.slides.mathtext/imathnaryoperator/)|Specifies an N-ary mathematical object, such as Summation and Integral.<br/>            It consists of an operator, a base (or operand), and optional upper and lower limits. <br/>            Examples of N-ary operators are: Summation, Union, Intersection, Integral|
|[IMathNaryOperatorFactory](/python-net/api-reference/aspose.slides.mathtext/imathnaryoperatorfactory/)|Allows to create IMathNaryOperator|
|[IMathNaryOperatorProperties](/python-net/api-reference/aspose.slides.mathtext/imathnaryoperatorproperties/)|Specifies properties of IMathNaryOperator|
|[IMathParagraph](/python-net/api-reference/aspose.slides.mathtext/imathparagraph/)|Mathematical paragraph that is a container for mathematical blocks (IMathBlock)|
|[IMathParagraphFactory](/python-net/api-reference/aspose.slides.mathtext/imathparagraphfactory/)|Allows to create a math paragraph|
|[IMathPortion](/python-net/api-reference/aspose.slides.mathtext/imathportion/)|Represents a portion with mathematical context inside.|
|[IMathRadical](/python-net/api-reference/aspose.slides.mathtext/imathradical/)|Specifies the radical function, consisting of a base, and an optional degree.<br/>            Example of radical object is √𝑥.|
|[IMathRadicalFactory](/python-net/api-reference/aspose.slides.mathtext/imathradicalfactory/)|Allows to create math radical|
|[IMathRightSubSuperscriptElement](/python-net/api-reference/aspose.slides.mathtext/imathrightsubsuperscriptelement/)|Specifies the Sub-Superscript object, which consists of a base <br/>            and a subscript and superscript placed to the right of the base.|
|[IMathRightSubSuperscriptElementFactory](/python-net/api-reference/aspose.slides.mathtext/imathrightsubsuperscriptelementfactory/)|Allows to create IMathRightSubSuperscriptElementFactory|
|[IMathSubscriptElement](/python-net/api-reference/aspose.slides.mathtext/imathsubscriptelement/)|Specifies the subscript object, which consists of a base <br/>            and a reduced-size subscript placed below and to the right.|
|[IMathSubscriptElementFactory](/python-net/api-reference/aspose.slides.mathtext/imathsubscriptelementfactory/)|Allows to create IMathSubscriptElement|
|[IMathSuperscriptElement](/python-net/api-reference/aspose.slides.mathtext/imathsuperscriptelement/)|Specifies the superscript object, which consists of a base <br/>            and a reduced-size superscript placed above and to the right|
|[IMathSuperscriptElementFactory](/python-net/api-reference/aspose.slides.mathtext/imathsuperscriptelementfactory/)|Allows to create IMathSuperscriptElement|
|[IMathematicalText](/python-net/api-reference/aspose.slides.mathtext/imathematicaltext/)|Mathematical text|
|[IMathematicalTextFactory](/python-net/api-reference/aspose.slides.mathtext/imathematicaltextfactory/)|Allows to create a MathematicalText element|
|[MathAccent](/python-net/api-reference/aspose.slides.mathtext/mathaccent/)|Specifies the accent function, consisting of a base and a combining diacritical mark<br/>            Example: 𝑎́|
|[MathAccentFactory](/python-net/api-reference/aspose.slides.mathtext/mathaccentfactory/)|Allows to create a math accent|
|[MathArray](/python-net/api-reference/aspose.slides.mathtext/matharray/)|Specifies a vertical array of equations or any mathematical objects|
|[MathArrayFactory](/python-net/api-reference/aspose.slides.mathtext/matharrayfactory/)|Allows to create a math array|
|[MathBar](/python-net/api-reference/aspose.slides.mathtext/mathbar/)|Specifies the bar function, consisting of a base argument and an overbar or underbar|
|[MathBarFactory](/python-net/api-reference/aspose.slides.mathtext/mathbarfactory/)|Allows to create a math bar|
|[MathBlock](/python-net/api-reference/aspose.slides.mathtext/mathblock/)|Specifies an instance of mathematical text that contained within a MathParagraph and starts on its own line.<br/>            All math zones, including equations, expressions, arrays of equations or expressions, and formulas are represented by math block.|
|[MathBlockFactory](/python-net/api-reference/aspose.slides.mathtext/mathblockfactory/)|Allows to create a math block|
|[MathBorderBox](/python-net/api-reference/aspose.slides.mathtext/mathborderbox/)|Draws a rectangular or some other border around the IMathElement.|
|[MathBorderBoxFactory](/python-net/api-reference/aspose.slides.mathtext/mathborderboxfactory/)|Allows to create a math border box|
|[MathBox](/python-net/api-reference/aspose.slides.mathtext/mathbox/)|Specifies the logical boxing (packaging) of mathematical element.<br/>            For example, a boxed object can serve as an operator emulator with or without an alignment point, <br/>            serve as a line break point, or be grouped such as not to allow line breaks within.<br/>            For example, the "==" operator should be boxed to prevent line breaks.|
|[MathBoxFactory](/python-net/api-reference/aspose.slides.mathtext/mathboxfactory/)|Allows to create a math box|
|[MathDelimiter](/python-net/api-reference/aspose.slides.mathtext/mathdelimiter/)|Specifies the delimiter object, consisting of opening and closing characters (such as parentheses, <br/>            braces, brackets, and vertical bars), and one or more mathematical elements inside, separated by a specified character.<br/>            Examples: (𝑥2); [𝑥2|𝑦2]|
|[MathDelimiterFactory](/python-net/api-reference/aspose.slides.mathtext/mathdelimiterfactory/)|Allows to create a math delimiter|
|[MathElementBase](/python-net/api-reference/aspose.slides.mathtext/mathelementbase/)|Base class for IMathElement with the implementation of some methods that are common to all inherited classes<br/>            For internal use only. Inherited class must be IMathElement.|
|[MathFraction](/python-net/api-reference/aspose.slides.mathtext/mathfraction/)|Specifies the fraction object, consisting of a numerator and denominator separated by a fraction bar.<br/>            The fraction bar can be horizontal or diagonal, depending on the fraction properties.<br/>            The fraction object is also used to represent the stack function, which places one element above another, with no fraction bar.|
|[MathFractionFactory](/python-net/api-reference/aspose.slides.mathtext/mathfractionfactory/)|Allows to create a math fraction|
|[MathFunction](/python-net/api-reference/aspose.slides.mathtext/mathfunction/)|Specifies a function of an argument.|
|[MathFunctionFactory](/python-net/api-reference/aspose.slides.mathtext/mathfunctionfactory/)|Allows to create a math function|
|[MathGroupingCharacter](/python-net/api-reference/aspose.slides.mathtext/mathgroupingcharacter/)|Specifies a grouping symbol above or below an expression, usually to highlight the relationship between elements|
|[MathGroupingCharacterFactory](/python-net/api-reference/aspose.slides.mathtext/mathgroupingcharacterfactory/)|Allows to create a math grouping character|
|[MathLeftSubSuperscriptElement](/python-net/api-reference/aspose.slides.mathtext/mathleftsubsuperscriptelement/)|Specifies the Sub-Superscript object, which consists of a base <br/>            and a subscript and superscript placed to the left of the base.|
|[MathLimit](/python-net/api-reference/aspose.slides.mathtext/mathlimit/)|Specifies the Limit object, consisting of text on the baseline and reduced-size text immediately above or below it.|
|[MathLimitFactory](/python-net/api-reference/aspose.slides.mathtext/mathlimitfactory/)|Allows to create IMathLimit|
|[MathMatrix](/python-net/api-reference/aspose.slides.mathtext/mathmatrix/)|Specifies the Matrix object, consisting of child elements laid out in one or more rows and columns. <br/>            It is important to note that matrices do not have built in delimiters. <br/>            To place the matrix in the brackets you should use the delimiter object (IMathDelimiter).<br/>            Null arguments can be used to create gaps in matrices.|
|[MathMatrixFactory](/python-net/api-reference/aspose.slides.mathtext/mathmatrixfactory/)|Allows to create a math matrix|
|[MathNaryOperator](/python-net/api-reference/aspose.slides.mathtext/mathnaryoperator/)|Specifies an N-ary mathematical object, such as Summation and Integral.<br/>            It consists of an operator, a base (or operand), and optional upper and lower limits. <br/>            Examples of N-ary operators are: Summation, Union, Intersection, Integral|
|[MathNaryOperatorFactory](/python-net/api-reference/aspose.slides.mathtext/mathnaryoperatorfactory/)|Allows to create IMathNaryOperator|
|[MathParagraph](/python-net/api-reference/aspose.slides.mathtext/mathparagraph/)|Mathematical paragraph that is a container for mathematical blocks (IMathBlock)|
|[MathParagraphFactory](/python-net/api-reference/aspose.slides.mathtext/mathparagraphfactory/)|Allows to create a math paragraph|
|[MathPortion](/python-net/api-reference/aspose.slides.mathtext/mathportion/)|Represents a portion with mathematical context inside.|
|[MathRadical](/python-net/api-reference/aspose.slides.mathtext/mathradical/)|Specifies the radical function, consisting of a base, and an optional degree.<br/>            Example of radical object is √𝑥.|
|[MathRadicalFactory](/python-net/api-reference/aspose.slides.mathtext/mathradicalfactory/)|Allows to create math radical|
|[MathRightSubSuperscriptElement](/python-net/api-reference/aspose.slides.mathtext/mathrightsubsuperscriptelement/)|Specifies the Sub-Superscript object, which consists of a base <br/>            and a subscript and superscript placed to the right of the base.|
|[MathRightSubSuperscriptElementFactory](/python-net/api-reference/aspose.slides.mathtext/mathrightsubsuperscriptelementfactory/)|Allows to create IMathRightSubSuperscriptElementFactory|
|[MathSubscriptElement](/python-net/api-reference/aspose.slides.mathtext/mathsubscriptelement/)|Specifies the subscript object, which consists of a base <br/>            and a reduced-size subscript placed below and to the right.|
|[MathSubscriptElementFactory](/python-net/api-reference/aspose.slides.mathtext/mathsubscriptelementfactory/)|Allows to create IMathSubscriptElement|
|[MathSuperscriptElement](/python-net/api-reference/aspose.slides.mathtext/mathsuperscriptelement/)|Specifies the superscript object, which consists of a base <br/>            and a reduced-size superscript placed above and to the right|
|[MathSuperscriptElementFactory](/python-net/api-reference/aspose.slides.mathtext/mathsuperscriptelementfactory/)|Allows to create IMathSuperscriptElement|
|[MathematicalText](/python-net/api-reference/aspose.slides.mathtext/mathematicaltext/)|Mathematical text|
|[MathematicalTextFactory](/python-net/api-reference/aspose.slides.mathtext/mathematicaltextfactory/)|Allows to create a MathematicalText element|
## **Enumerations**
|**Enumeration**|**Description**|
| :- | :- |
|[MathDelimiterShape](/python-net/api-reference/aspose.slides.mathtext/mathdelimitershape/)|The location and size of the delimiters relative to the content of the operands|
|[MathFractionTypes](/python-net/api-reference/aspose.slides.mathtext/mathfractiontypes/)|Fraction Types|
|[MathFunctionsOfOneArgument](/python-net/api-reference/aspose.slides.mathtext/mathfunctionsofoneargument/)|Common mathematical functions of one argument|
|[MathFunctionsOfTwoArguments](/python-net/api-reference/aspose.slides.mathtext/mathfunctionsoftwoarguments/)|Common mathematical functions of two arguments|
|[MathHorizontalAlignment](/python-net/api-reference/aspose.slides.mathtext/mathhorizontalalignment/)|Horizontal Alignment|
|[MathIntegralTypes](/python-net/api-reference/aspose.slides.mathtext/mathintegraltypes/)|Mathematical integral types|
|[MathJustification](/python-net/api-reference/aspose.slides.mathtext/mathjustification/)|Specifies justification of the math paragraph (a series of adjacent instances of mathematical text within the same paragraph)|
|[MathLimitLocations](/python-net/api-reference/aspose.slides.mathtext/mathlimitlocations/)|Location of limits (subscript/superscript) in n-ary operators.|
|[MathNaryOperatorTypes](/python-net/api-reference/aspose.slides.mathtext/mathnaryoperatortypes/)|Nary operator IMathNaryOperator types (excluding integrals)<br/>            For integrals [MathIntegralTypes](/python-net/api-reference/aspose.slides.mathtext/mathintegraltypes/)|
|[MathRowSpacingRule](/python-net/api-reference/aspose.slides.mathtext/mathrowspacingrule/)|The type of vertical spacing between columns in a matrix or array|
|[MathSpacingRules](/python-net/api-reference/aspose.slides.mathtext/mathspacingrules/)|Types of gap (horizontal spacing) between columns of a matrix|
|[MathTopBotPositions](/python-net/api-reference/aspose.slides.mathtext/mathtopbotpositions/)|Top/bottom positions enumeration|
|[MathVerticalAlignment](/python-net/api-reference/aspose.slides.mathtext/mathverticalalignment/)|Vertical Alignment|
