---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 530
url: /python-net/api-reference/aspose.slides.export/videoplayerhtmlcontroller/
---

This class allows export of video and audio files into a HTML

**Namespace:** [aspose.slides.export](/python-net/api-reference/aspose.slides.export/)

**Full Class Name:** aspose.slides.export.VideoPlayerHtmlController

**Assembly:**  Aspose.Slides Version: 21.11.0.0

The VideoPlayerHtmlController type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|VideoPlayerHtmlController(path, file_name, base_uri)|Initializes a new instance of the VideoPlayerHtmlController class|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_ihtml_formatting_controller|Allows to get base IHtmlFormattingController interface.<br/>            Read-only [IHtmlFormattingController](/python-net/api-reference/aspose.slides.export/ihtmlformattingcontroller/).|
|as_isvg_shape_formatting_controller|Allows to get base ISvgShapeFormattingController interface.<br/>            Read-only [ISvgShapeFormattingController](/python-net/api-reference/aspose.slides.export/isvgshapeformattingcontroller/).|
|as_ilink_embed_controller|Allows to get base ILinkEmbedController interface.<br/>            Read-only [ILinkEmbedController](/python-net/api-reference/aspose.slides.export/ilinkembedcontroller/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|write_document_start(generator, presentation)|Called to write html document header. Called once per presentation conversion.|
|write_document_end(generator, presentation)|Called to write html document footer. Called once per presentation conversion.|
|write_slide_start(generator, slide)|Called to write html slide header. Called once per each of slides.|
|write_slide_end(generator, slide)|Called to write html slide footer. Called once per each of slides.|
|write_shape_start(generator, shape)|Called before shape's rendering. Called once per each of shape. If this function writes anything to generator, current slide image generation will be finished, added html fragment inserted and new image will be started atop of the previous.|
|write_shape_end(generator, shape)|Called before shape's rendering. Called once per each of shape. If this function writes anything to generator, current slide image generation will be finished, added html fragment inserted and new image will be started atop of the previous.|
|format_shape(svg_shape, shape)|This function is called before rendering of shape to SVG to allow user to control resulting SVG.|
|get_object_storing_location(id, entity_data, semantic_name, content_type, recomended_extension)|Determines where object should be stored.<br/>            This method is called once for each object id.<br/>            It is not guaranteed that there won't be two objects with same data, semanticName and contentType but with different id.|
|get_url(id, referrer)|Returns an URL to an external object.<br/>            This method always called if|
|save_external(id, entity_data)|Saves external object.|
