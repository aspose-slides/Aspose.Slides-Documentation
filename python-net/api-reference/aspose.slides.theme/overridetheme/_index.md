---
title: OverrideTheme
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 430
url: /python-net/api-reference/aspose.slides.theme/overridetheme/
---

## OverrideTheme class

Represents a overriding theme.

The OverrideTheme type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|color_scheme|Returns the color scheme.<br/>            Read-only [IColorScheme](/slides/python-net/api-reference/aspose.slides.theme/icolorscheme/).|
|font_scheme|Returns the font scheme.<br/>            Read-only [IFontScheme](/slides/python-net/api-reference/aspose.slides.theme/ifontscheme/).|
|format_scheme|Returns the shape format scheme.<br/>            Read-only [IFormatScheme](/slides/python-net/api-reference/aspose.slides.theme/iformatscheme/).|
|presentation|Returns the parent presentation.<br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
|is_empty|True value means that ColorScheme, FontScheme, FormatScheme is null and any overriding with this theme object are disabled.<br/>            Read-only bool.|
|as_i_presentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|as_i_theme|Allows to get base ITheme interface.<br/>            Read-only [ITheme](/slides/python-net/api-reference/aspose.slides.theme/itheme/).|
## Methods
| Name | Description |
| :- | :- |
|get_effective()|Gets effective theme data with the inheritance applied.|
|init_color_scheme()|Init ColorScheme with new object for overriding ColorScheme of InheritedTheme.|
|init_color_scheme_from(color_scheme)|Init ColorScheme with new object for overriding ColorScheme of InheritedTheme.|
|init_color_scheme_from_inherited()|Init ColorScheme with new object for overriding ColorScheme of InheritedTheme. And initialize data of this new object with data of the ColorScheme of InheritedTheme.|
|init_font_scheme()|Init FontScheme with new object for overriding FontScheme of InheritedTheme.|
|init_font_scheme_from(font_scheme)|Init FontScheme with new object for overriding FontScheme of InheritedTheme.|
|init_font_scheme_from_inherited()|Init FontScheme with new object for overriding FontScheme of InheritedTheme. And initialize data of this new object with data of the FontScheme of InheritedTheme.|
|init_format_scheme()|Init FormatScheme with new object for overriding FormatScheme of InheritedTheme.|
|init_format_scheme_from(format_scheme)|Init FormatScheme with new object for overriding FormatScheme of InheritedTheme.|
|init_format_scheme_from_inherited()|Init FormatScheme with new object for overriding FormatScheme of InheritedTheme. And initialize data of this new object with data of the FormatScheme of InheritedTheme.|
|clear()|Set ColorScheme, FontScheme, FormatScheme to null to disable any overriding with this theme object.|

### See Also

* namespace [aspose.slides.theme](/slides/python-net/api-reference/aspose.slides.theme/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

