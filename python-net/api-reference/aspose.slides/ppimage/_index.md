---
title: PPImage Class
type: docs
weight: 3230
url: /python-net/api-reference/aspose.slides/ppimage/
---

Represents an image in a presentation.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.PPImage



The PPImage type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|binary_data|Returns the copy of an image's data.<br/>            Read-only int[].|
|system_image|Returns the copy of an image.<br/>            Read-only aspose.pydrawing.Image.|
|svg_image|Returns or sets ISvgImage object [ISvgImage](/slides/python-net/api-reference/aspose.slides/isvgimage/)|
|content_type|Returns a MIME type of an image, encoded in [binary_data](/slides/python-net/api-reference/aspose.slides/ppimage/).<br/>            Read-only string.|
|width|Returns a width of an image.<br/>            Read-only|
|height|Returns a height of an image.<br/>            Read-only|
|x|Returns a X-offset of an image.<br/>            Read-only|
|y|Returns a Y-offset of an image.<br/>            Read-only|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|replace_image(new_image_data)|Replaces image data.|
|replace_image(new_image)|Replaces image data. Attention: when Image is metafile - it will be rasterized due to restrictions of GDI+. Use ReplaceImage(byte[]) instead|
|replace_image(new_image)|Replaces image data.|
