---
title: IMathMatrix Class
type: docs
weight: 280
url: /slides/python-net/api-reference/aspose.slides.mathtext/imathmatrix/
---

Specifies the Matrix object, consisting of child elements laid out in one or more rows and columns. <br/>            It is important to note that matrices do not have built in delimiters. <br/>            To place the matrix in the brackets you should use the delimiter object (IMathDelimiter).<br/>            Null arguments can be used to create gaps in matrices.

**Namespace:** [aspose.slides.mathtext](/slides/python-net/api-reference/aspose.slides.mathtext/)

**Full Class Name:** aspose.slides.mathtext.IMathMatrix

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IMathMatrix type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|row_count|Number of rows in the matrix|
|column_count|Number of columns in the matrix|
|hide_placeholders|Hide the placeholders for empty matrix elements<br/>            Default: false|
|base_justification|Specifies the vertical justification respect to surrounding text. <br/>            Possible values are top, bottom, and center.<br/>            Default: Center|
|min_column_width|Minimum column width in twips (1/20th of a point)<br/>            The gap spacing (also referred to as “Column Gap” or “Gap Width”) is added to <br/>            the MinColumnWidth to determine the total Matrix Column Spacing<br/>            (distance between the same edges of different columns).<br/>            Default: 0.|
|column_gap_rule|The type of horizontal spacing between columns of a matrix; <br/>            Horizontal spacing units can be ems or points (stored as twips).<br/>            Default: SingleSpacingGap (0)|
|column_gap|The value of horizontal spacing between columns of a matrix;<br/>            If the ColumnGapRule is set to 3 ("Exactly"), then the unit is interpreted as twips (1/20th of a point)<br/>            If the ColumnGapRule is set to 4 ("Multiple"), then the unit is interpreted as number of 0.5 em increments.<br/>            In other cases ignored.<br/>            Default: 0|
|row_gap_rule|The type of vertical spacing between rows of a matrix; <br/>            Vertical spacing units can be lines or points (stored as twips).<br/>            Default: SingleSpacingGap (0)|
|row_gap|The value of vertical spacing between rows of a matrix;<br/>            If the RowGapRule is set to 3 ("Exactly"), then the unit is interpreted as twips (1/20th of a point)<br/>            If the RowGapRule is set to 4 ("Multiple"), then the unit is interpreted as half-lines.<br/>            Default: 0|
|as_imath_element|Allows to get base IMathElement interface<br/>            [IMathElement](/python-net/api-reference/aspose.slides.mathtext/imathelement/)|
## **Methods**
|**Name**|**Description**|
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
|get_column_alignment(column_index)|Get the horizontal alignment of the specified column|
|set_column_alignment(column_index, val)|Set the horizontal alignment of the specified column|
|set_columns_alignment(column_index, columns_count, val)|Set the horizontal alignment of the specified columns|
|insert_row_before(row_index)|Insert a new row before the specified one<br/>            Initially all elements in the new row are null.|
|insert_row_after(row_index)|Insert a new row after the specified one<br/>            Initially all elements in the new row are null.|
|delete_row(row_index)|Deletes the specified row|
|insert_column_before(column_index)|Insert a new column before the specified one<br/>            Initially all elements in the new column are null.|
|insert_column_after(column_index)|Insert a new column after the specified one<br/>            Initially all elements in the new column are null.|
|delete_column(column_index)|Deletes the specified column|
|get_children()|Get children elements|
|to_math_array()|Puts in a vertical array|
|accent(accent_character)|Sets an accent mark (a character on the top of this element)|
|overbar()|Sets a bar on the top of this element|
|underbar()|Sets a bar on the bottom of this element|
|to_box()|Places this element in a non-visual box (logical grouping) <br/>            which is used to group components of an equation or other instance of mathematical text.<br/>            A boxed object can (for example) serve as an operator emulator with or without an alignment point, <br/>            serve as a line break point, or be grouped such as not to allow line breaks within.|
