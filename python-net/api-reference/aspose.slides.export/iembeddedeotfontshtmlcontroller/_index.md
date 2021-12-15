---
title: IEmbeddedEotFontsHtmlController Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 90
url: /python-net/api-reference/aspose.slides.export/iembeddedeotfontshtmlcontroller/
---

Embedded Eot fonts HTML controller.

**Namespace:** [aspose.slides.export](/python-net/api-reference/aspose.slides.export/)

**Full Class Name:** aspose.slides.export.IEmbeddedEotFontsHtmlController

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IEmbeddedEotFontsHtmlController type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_ihtml_formatting_controller|Returns IHtmlFormattingController interface.|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|write_document_start(generator, presentation)|Called to write html document header. Called once per presentation conversion.|
|write_document_end(generator, presentation)|Called to write html document footer. Called once per presentation conversion.|
|write_slide_start(generator, slide)|Called to write html slide header. Called once per each of slides.|
|write_slide_end(generator, slide)|Called to write html slide footer. Called once per each of slides.|
|write_shape_start(generator, shape)|Called before shape's rendering. Called once per each of shape. If this function writes anything to generator, current slide image generation will be finished, added html fragment inserted and new image will be started atop of the previous.|
|write_shape_end(generator, shape)|Called before shape's rendering. Called once per each of shape. If this function writes anything to generator, current slide image generation will be finished, added html fragment inserted and new image will be started atop of the previous.|
