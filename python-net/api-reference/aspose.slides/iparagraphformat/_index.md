---
title: IParagraphFormat Class
type: docs
weight: 2060
url: /python-net/api-reference/aspose.slides/iparagraphformat/
---

This class contains the paragraph formatting properties. Unlike [IParagraphFormatEffectiveData](/slides/python-net/api-reference/aspose.slides/iparagraphformateffectivedata/), all properties of this class are writeable.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IParagraphFormat

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IParagraphFormat type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|bullet|Returns bullet format of the paragraph.<br/>            Read-only [IBulletFormat](/slides/python-net/api-reference/aspose.slides/ibulletformat/).|
|depth|Returns or sets depth of the paragraph.<br/>            Value 0 means undefined value.<br/>            Read/write int.|
|alignment|Returns or sets the text alignment in a paragraph with no inheritance.<br/>            Read/write [TextAlignment](/slides/python-net/api-reference/aspose.slides/textalignment/).|
|space_within|Returns or sets the amount of space between base lines in a paragraph. Positive value means percentage, negative - size in points. No inheritance applied.<br/>            Read/write|
|space_before|Returns or sets the amount of space before the first line in a paragraph with no inheritance.<br/>            A positive value specifies the percentage of the font size that the white space should be.<br/>            A negative value specifies the size of the white space in point size.<br/>            Read/write|
|space_after|Returns or sets the amount of space after the last line in a paragraph with no inheritance.<br/>            A positive value specifies the percentage of the font size that the white space should be.<br/>            A negative value specifies the size of the white space in point size.<br/>            Read/write|
|east_asian_line_break|Determines whether the East Asian line break is used in a paragraph. No inheritance applied.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|right_to_left|Determines whether the Right to Left writing is used in a paragraph. No inheritance applied.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|latin_line_break|Determines whether the Latin line break is used in a paragraph. No inheritance applied.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|hanging_punctuation|Determines whether the hanging punctuation is used in a paragraph. No inheritance applied.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|margin_left|Returns or sets the left margin in a paragraph with no inheritance.<br/>            Read/write|
|margin_right|Returns or sets the right margin in a paragraph with no inheritance.<br/>            Read/write|
|indent|Returns or sets paragraph First Line Indent/Hanging Indent with no inheritance. Hanging Indent can be defined with negative values.<br/>            Read/write|
|default_tab_size|Returns or sets default tabulation size with no inheritance.<br/>            Read/write|
|tabs|Returns tabulations of a paragraph. No inheritance applied.<br/>            Read-only [ITabCollection](/slides/python-net/api-reference/aspose.slides/itabcollection/).|
|font_alignment|Returns or sets a font alignment in a paragraph with no inheritance.<br/>            Read/write [FontAlignment](/slides/python-net/api-reference/aspose.slides/fontalignment/).|
|default_portion_format|Returns default portion format of a paragraph. No inheritance applied.<br/>            Read-only [IPortionFormat](/slides/python-net/api-reference/aspose.slides/iportionformat/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_effective()|Gets effective paragraph formatting data with the inheritance applied.|
