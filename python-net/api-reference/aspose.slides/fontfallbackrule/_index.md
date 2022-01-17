---
title: FontFallBackRule Class
type: docs
weight: 510
url: /python-net/api-reference/aspose.slides/fontfallbackrule/
---

Represents font fallback rule

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.FontFallBackRule

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The FontFallBackRule type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|FontFallBackRule(start_index, end_index, font_names)|Initializes a new instance of the FontFallBackRule class|
|FontFallBackRule(start_index, end_index, font_names)|Initializes a new instance of the FontFallBackRule class|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|range_start_index|Get first index of continuous unicode range.|
|range_end_index|Get last index of continuous unicode range.|
|count|Gets the number of fonts actually defined for range.<br/>            Read-only|
## **Indexer**
|**Name**|**Description**|
| :- | :- |
|[index]|Gets the font name at the specified index.<br/>            Read-only [IFontFallBackRule](/slides/python-net/api-reference/aspose.slides/ifontfallbackrule/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|add_fall_back_fonts(font_name)|Adds a new font(s) to the list of FallBack fonts.|
|add_fall_back_fonts(font_names)|Adds a new fonts to the list of FallBack fonts.|
|to_array()|Creates and returns an array with all FallBack fonts for this rule.|
|to_array(start_index, count)|Creates and returns an array with all FallBack fonts from the specified range in list.|
|clear()|Removes all fonts from the list.|
|remove(font_name)|Removes the first occurrence of a specific FallBack font from the list.|
|remove_at(index)|Removes the FallBack font at the specified index of the list.|
|index_of(font_name)|Returns an index of the specified rule in the collection.|
