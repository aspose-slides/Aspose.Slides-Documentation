---
title: IBasePortionFormat Class
type: docs
weight: 880
url: /python-net/api-reference/aspose.slides/ibaseportionformat/
---

This class contains the text portion formatting properties. Unlike [IPortionFormatEffectiveData](/slides/python-net/api-reference/aspose.slides/iportionformateffectivedata/), all properties of this class are writeable.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IBasePortionFormat



The IBasePortionFormat type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|line_format|Returns the LineFormat properties for text outlining. No inheritance applied.<br/>            Read-only [ILineFormat](/slides/python-net/api-reference/aspose.slides/ilineformat/).|
|fill_format|Returns the text FillFormat properties. No inheritance applied.<br/>            Read-only [IFillFormat](/slides/python-net/api-reference/aspose.slides/ifillformat/).|
|effect_format|Returns the text EffectFormat properties. No inheritance applied.<br/>            Read-only [IEffectFormat](/slides/python-net/api-reference/aspose.slides/ieffectformat/).|
|highlight_color|Returns the color used to highlight a text. No inheritance applied.<br/>            Read-only [IColorFormat](/slides/python-net/api-reference/aspose.slides/icolorformat/).|
|underline_line_format|Returns the LineFormat properties used to outline underline line. No inheritance applied.<br/>            Read-only [ILineFormat](/slides/python-net/api-reference/aspose.slides/ilineformat/).|
|underline_fill_format|Returns the underline line FillFormat properties. No inheritance applied.<br/>            Read-only [IFillFormat](/slides/python-net/api-reference/aspose.slides/ifillformat/).|
|font_bold|Determines whether the font is bold. No inheritance applied.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|font_italic|Determines whether the font is itallic. No inheritance applied.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|kumimoji|Determines whether the numbers should ignore text eastern language-specific vertical text layout. No inheritance applied.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|normalise_height|Determines whether the height of a text should be normalized. No inheritance applied.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|proof_disabled|Determines whether the text shouldn't be proofed. No inheritance applied.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|font_underline|Returns or sets the text underline type. No inheritance applied.<br/>            Read/write [TextUnderlineType](/slides/python-net/api-reference/aspose.slides/textunderlinetype/).|
|text_cap_type|Returns or sets the type of text capitalization. No inheritance applied.<br/>            Read/write [TextCapType](/slides/python-net/api-reference/aspose.slides/textcaptype/).|
|strikethrough_type|Returns or sets the strikethrough type of a text. No inheritance applied.<br/>            Read/write [TextStrikethroughType](/slides/python-net/api-reference/aspose.slides/textstrikethroughtype/).|
|is_hard_underline_line|Determines whether the underline style has own LineFormat properties or inherits it<br/>            from the LineFormat properties of the text.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|is_hard_underline_fill|Determines whether the underline style has own FillFormat properties or inherits it<br/>            from the FillFormat properties of the text.<br/>            Read/write [NullableBool](/slides/python-net/api-reference/aspose.slides/nullablebool/).|
|font_height|Returns or sets the font height of a portion.<br/>            float.NaN means height is undefined and should be inherited from the Master.<br/>            Read/write|
|latin_font|Returns or sets the Latin font info.<br/>            Null means font is undefined and should be inherited from the Master.<br/>            Read/write [IFontData](/slides/python-net/api-reference/aspose.slides/ifontdata/).|
|east_asian_font|Returns or sets the East Asian font info.<br/>            Null means font is undefined and should be inherited from the Master.<br/>            Read/write [IFontData](/slides/python-net/api-reference/aspose.slides/ifontdata/).|
|complex_script_font|Returns or sets the complex script font info.<br/>            Null means font is undefined and should be inherited from the Master.<br/>            Read/write [IFontData](/slides/python-net/api-reference/aspose.slides/ifontdata/).|
|symbol_font|Returns or sets the symbolic font info.<br/>            Null means font is undefined and should be inherited from the Master.<br/>            Read/write [IFontData](/slides/python-net/api-reference/aspose.slides/ifontdata/).|
|escapement|Returns or sets the superscript or subscript text.<br/>            Value from -100% (subscript) to 100% (superscript).<br/>            float.NaN means value is undefined and should be inherited from the Master.<br/>            Read/write|
|kerning_minimal_size|Returns or sets the minimal font size, for which kerning should be switched on.<br/>            float.NaN means value is undefined and should be inherited from the Master.<br/>            Read/write|
|language_id|Returns or sets the Id of a proofing language. Used for checking spelling and grammar.<br/>            Read/write string.|
|alternative_language_id|Returns or sets the Id of an alternative language.<br/>            Read/write string.|
|spacing|Returns or sets the intercharacter spacing increment.<br/>            float.NaN means value is undefined and should be inherited from the Master.<br/>            Read/write|
