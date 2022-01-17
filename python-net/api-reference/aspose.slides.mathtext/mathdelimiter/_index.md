---
title: MathDelimiter Class
type: docs
weight: 580
url: /python-net/api-reference/aspose.slides.mathtext/mathdelimiter/
---

Specifies the delimiter object, consisting of opening and closing characters (such as parentheses, <br/>            braces, brackets, and vertical bars), and one or more mathematical elements inside, separated by a specified character.<br/>            Examples: (𝑥2); [𝑥2|𝑦2]

**Namespace:** [aspose.slides.mathtext](/slides/python-net/api-reference/aspose.slides.mathtext/)

**Full Class Name:** aspose.slides.mathtext.MathDelimiter

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The MathDelimiter type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|MathDelimiter(element)|Initializes a new instance of the MathDelimiter class|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|arguments|One or more mathematical elements separated by delimiter characters|
|beginning_character|Delimiter Beginning Character specifies the beginning, or opening, delimiter character. <br/>            Mathematical delimiters are enclosing characters such as parentheses, brackets, and braces.<br/>            The default: '('.|
|separator_character|Delimiter Separator Character specifies the character that separates arguments in the delimiter object. <br/>            The default: '|'.|
|ending_character|Delimiter Ending Character specifies the ending, or closing, delimiter character. <br/>            Mathematical delimiters are enclosing characters such as parentheses, brackets, and braces.<br/>            The default: ')'.|
|grow_to_match_operand_height|Specifies the growth of BeginningCharacter, SeparatorCharacter, EndingCharacter<br/>            When true, the delimiters grows vertically to match its operand height.<br/>            The default value is true|
|delimiter_shape|Specifies the shape of delimiters in the delimiter object. <br/>            When is MathDelimiterShape.Centered, delimiters are centered around the math axis of the mathematical text <br/>            and still be made to fit the entire height of their contents.<br/>            When is MathDelimiterShape.Match, their height and shape are altered to exactly match their contents.|
|as_imath_element|Allows to get base IMathElement interface<br/>            [IMathElement](/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|join(math_element)|Joins a mathematical element and forms a mathematical block|
|join(math_text)|Joins a mathematical text and forms a mathematical block|
|divide(denominator)|Creates a fraction with this numerator and specified denominator|
|divide(denominator)|Creates a fraction with this numerator and specified denominator|
|divide(denominator, fraction_type)|Creates a fraction of the specified type with this numerator and specified denominator|
|divide(denominator, fraction_type)|Creates a fraction of the specified type with this numerator and specified denominator|
|enclose(beginning_character, ending_character)|Encloses a math element in specified characters such as parenthesis or another characters as framing|
|enclose()|Encloses a math element in specified characters such as parenthesis or another characters as framing|
|function(function_argument)|Takes a function of an argument using this instance as the function name|
|function(function_argument)|Takes a function of an argument using this instance as the function name|
|as_argument_of_function(function_name)|Takes specified function using this instance as the argument|
|as_argument_of_function(function_name)|Takes specified function using this instance as the argument|
|as_argument_of_function(function_type)|Takes specified function using this instance as the argument|
|as_argument_of_function(function_type, additional_argument)|Takes specified function using this instance as the argument and specified additional argument|
|as_argument_of_function(function_type, additional_argument)|Takes specified function using this instance as the argument and specified additional argument|
|set_subscript(subscript)|Creates subscript|
|set_subscript(subscript)|Creates subscript|
|set_superscript(superscript)|Creates superscript|
|set_superscript(superscript)|Creates superscript|
|set_sub_superscript_on_the_right(subscript, superscript)|Creates subscript and superscript on the right|
|set_sub_superscript_on_the_right(subscript, superscript)|Creates subscript and superscript on the right|
|set_sub_superscript_on_the_left(subscript, superscript)|Creates subscript and superscript on the left|
|set_sub_superscript_on_the_left(subscript, superscript)|Creates subscript and superscript on the left|
|radical(degree)|Specifies the mathematical root of the given degree from the specified argument.|
|radical(degree)|Specifies the mathematical root of the given degree from the specified argument.|
|set_upper_limit(limit)|Takes upper limit|
|set_upper_limit(limit)|Takes upper limit|
|set_lower_limit(limit)|Takes lower limit|
|set_lower_limit(limit)|Takes lower limit|
|nary(type, lower_limit, upper_limit)|Creates a N-ary operator|
|nary(type, lower_limit, upper_limit)|Creates a N-ary operator|
|integral(integral_type, lower_limit, upper_limit, limit_locations)|Takes the integral|
|integral(integral_type, lower_limit, upper_limit)|Takes the integral|
|integral(integral_type)|Takes the integral|
|integral(integral_type, lower_limit, upper_limit, limit_locations)|Takes the integral|
|integral(integral_type, lower_limit, upper_limit)|Takes the integral|
|group()|Places this element in a group using a bottom curly bracket|
|group(character, position, vertical_justification)|Places this element in a group using a grouping character such as bottom curly bracket or another|
|to_border_box()|Places this element in a border-box|
|to_border_box(hide_top, hide_bottom, hide_left, hide_right, strikethrough_horizontal, strikethrough_vertical, strikethrough_bottom_left_to_top_right, strikethrough_top_left_to_bottom_right)|Places this element in a border-box|
|to_math_array()|Puts in a vertical array|
|accent(accent_character)|Sets an accent mark (a character on the top of this element)|
|overbar()|Sets a bar on the top of this element|
|underbar()|Sets a bar on the bottom of this element|
|to_box()|Places this element in a non-visual box (logical grouping) <br/>            which is used to group components of an equation or other instance of mathematical text.<br/>            A boxed object can (for example) serve as an operator emulator with or without an alignment point, <br/>            serve as a line break point, or be grouped such as not to allow line breaks within.|
|delimit(separator_character)|Delimits arguments using the specified delimiter character|
|get_children()|Get children elements|
