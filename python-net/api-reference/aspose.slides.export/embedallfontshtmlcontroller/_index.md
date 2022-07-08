---
title: EmbedAllFontsHtmlController
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 10
url: /python-net/api-reference/aspose.slides.export/embedallfontshtmlcontroller/
---

## EmbedAllFontsHtmlController class

The formatting controller class to use for embedding all presentation fonts in WOFF format.

The EmbedAllFontsHtmlController type exposes the following members:
## Constructors
| Name | Description |
| :- | :- |
|EmbedAllFontsHtmlController()|Creates new instance|
|EmbedAllFontsHtmlController(font_name_exclude_list)|Initializes a new instance of the EmbedAllFontsHtmlController class|
## Methods
| Name | Description |
| :- | :- |
|write_document_start(generator, presentation)|Called to write html document header. Called once per presentation conversion.|
|write_document_end(generator, presentation)|Called to write html document footer. Called once per presentation conversion.|
|write_slide_start(generator, slide)|Called to write html slide header. Called once per each of slides.|
|write_slide_end(generator, slide)|Called to write html slide footer. Called once per each of slides.|
|write_shape_start(generator, shape)|Called before shape's rendering. Called once per each of shape. If this function writes anything to generator, current slide image generation will be finished, added html fragment inserted and new image will be started atop of the previous.|
|write_shape_end(generator, shape)|Called before shape's rendering. Called once per each of shape. If this function writes anything to generator, current slide image generation will be finished, added html fragment inserted and new image will be started atop of the previous.|
|write_all_fonts(generator, presentation)|Write all fonts contained in [Presentation](/slides/python-net/api-reference/aspose.slides/presentation/).|
|write_font(generator, original_font, substituted_font, font_style, font_weight, font_data)|Writes data as base64 into HTML document itself|

### See Also

* namespace [aspose.slides.export](/slides/python-net/api-reference/aspose.slides.export/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

