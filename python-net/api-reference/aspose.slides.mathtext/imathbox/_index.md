---
title: IMathBox
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 130
url: /python-net/api-reference/aspose.slides.mathtext/imathbox/
---

## IMathBox class

Specifies the logical boxing (packaging) of mathematical element.<br/>            For example, a boxed object can serve as an operator emulator with or without an alignment point, <br/>            serve as a line break point, or be grouped such as not to allow line breaks within.<br/>            For example, the "==" operator should be boxed to prevent line breaks.

The IMathBox type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|base|Base argument|
|operator_emulator|Operator Emulator.<br/>            When true, the box and its contents behave as a single operator and inherit the properties of an operator. <br/>            This means, for example, that the character can serve as a point for a line break and can be aligned to other operators.<br/>            Operator Emulators are often used when one or more glyphs combine to form an operator, such as '=='.<br/>            Default value: false|
|no_break|No break.<br/>            This property specifies the "unbreakable" property on the object box. When true, no line breaks can occur within the box.<br/>            This can be important for operator emulators that consist of more than one binary operator. <br/>            When this element is not specified, breaks can occur inside box.<br/>            Default: true|
|differential|Differential.<br/>            When true, the box acts as a differential (e.g., 𝑑𝑥 in an integrand), and receives the appropriate <br/>            horizontal spacing for the mathematical differential.<br/>            Default: false|
|alignment_point|When true, this operator emulator serves as an alignment point; that is, <br/>            designated alignment points in other equations can be aligned with it.<br/>            Default: false|
|explicit_break|Explicit break specifies whether there is a line break at the start of the Box object, <br/>            such that the line wraps at the start of the box object.<br/>            Specifies the number of the operator on the previous line of mathematical text which shall<br/>            be used as the alignment point for the current line of mathematical text<br/>            possible values: 1..255<br/>            Default: 0 (no explicit break)|
|as_i_math_element|Allows to get base IMathElement interface<br/>            [IMathElement](/slides/python-net/api-reference/aspose.slides.mathtext/imathelement/)|
## Methods
| Name | Description |
| :- | :- |
|join(math_element)|Joins a mathematical element and forms a mathematical block|
|join(math_text)|Joins a mathematical text and forms a mathematical block|
|divide(denominator)|Creates a fraction with this numerator and specified denominator|
|divide(denominator)|Creates a fraction with this numerator and specified denominator|
|divide(denominator, fraction_type)|Creates a fraction of the specified type with this numerator and specified denominator|
|divide(denominator, fraction_type)|Creates a fraction of the specified type with this numerator and specified denominator|
|enclose()|Encloses a math element in parenthesis|
|enclose(beginning_character, ending_character)|Encloses this element in specified characters such as parenthesis or another characters as framing|
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
|get_children()|Get children elements|
|to_math_array()|Puts in a vertical array|
|accent(accent_character)|Sets an accent mark (a character on the top of this element)|
|overbar()|Sets a bar on the top of this element|
|underbar()|Sets a bar on the bottom of this element|
|to_box()|Places this element in a non-visual box (logical grouping) <br/>            which is used to group components of an equation or other instance of mathematical text.<br/>            A boxed object can (for example) serve as an operator emulator with or without an alignment point, <br/>            serve as a line break point, or be grouped such as not to allow line breaks within.|

### See Also

* namespace [aspose.slides.mathtext](/slides/python-net/api-reference/aspose.slides.mathtext/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

