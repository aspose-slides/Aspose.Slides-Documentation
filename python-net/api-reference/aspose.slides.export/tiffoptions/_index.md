---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 520
url: /python-net/api-reference/aspose.slides.export/tiffoptions/
---

Provides options that control how a presentation is saved in TIFF format.

**Namespace:** [aspose.slides.export](/python-net/api-reference/aspose.slides.export/)

**Full Class Name:** aspose.slides.export.TiffOptions

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The TiffOptions type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|TiffOptions()|Default constructor.|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|warning_callback|Returns of sets an object which receives warnings and decides whether loading process will continue or will be aborted.<br/>            Read/write [IWarningCallback](/python-net/api-reference/aspose.slides.warnings/iwarningcallback/).|
|progress_callback|Represents a callback object for saving progress updates in percentage.<br/>            See [IProgressCallback](/python-net/api-reference/aspose.slides/iprogresscallback/).|
|default_regular_font|Returns or sets font used in case source font is not found.<br/>            Read-write string.|
|notes_comments_layouting|Provides options that control how notes and comments is placed in exported document.|
|show_hidden_slides|Specifies whether the generated document should include hidden slides or not.<br/>            Default is|
|image_size|Specifies size of a generated TIFF image.<br/>            Default value is 0x0, what means that generated image sizes will be calculated based on presentation slide size value.<br/>            Read/write aspose.pydrawing.Size.|
|dpi_x|Specifies the horizontal resolution in dots per inch.<br/>            Read/write int.|
|dpi_y|Specifies the vertical resolution in dots per inch.<br/>            Read/write int.|
|compression_type|Specifies the compression type.<br/>            Read/write [TiffCompressionTypes](/python-net/api-reference/aspose.slides.export/tiffcompressiontypes/).|
|pixel_format|Specifies the pixel format for the generated images.<br/>            Read/write [ImagePixelFormat](/python-net/api-reference/aspose.slides.export/imagepixelformat/).|
|as_isave_options|Returns ISaveOptions interface.<br/>            Read-only [ISaveOptions](/python-net/api-reference/aspose.slides.export/isaveoptions/).|
