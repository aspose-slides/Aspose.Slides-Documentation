---
title: IHtmlOptions Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 160
url: /python-net/api-reference/aspose.slides.export/ihtmloptions/
---

Represents a HTML exporting options.

**Namespace:** [aspose.slides.export](/python-net/api-reference/aspose.slides.export/)

**Full Class Name:** aspose.slides.export.IHtmlOptions

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IHtmlOptions type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|html_formatter|Returns or sets HTML template.<br/>            Read/write [IHtmlFormatter](/python-net/api-reference/aspose.slides.export/ihtmlformatter/).|
|slide_image_format|Returns or sets slide image format options.<br/>            Read/write [ISlideImageFormat](/python-net/api-reference/aspose.slides.export/islideimageformat/).|
|show_hidden_slides|Specifies whether the generated document should include hidden slides or not.<br/>            Default is|
|jpeg_quality|Returns or sets a value determining the quality of the JPEG images inside PDF document.<br/>            Read/write int.|
|pictures_compression|Represents the pictures compression level<br/>            Read/write [pictures_compression](/python-net/api-reference/aspose.slides.export/ihtmloptions/).|
|delete_pictures_cropped_areas|A boolean flag indicates if the cropped parts remain as part of the document. If true the cropped <br/>            parts will removed, if false they will be serialized in the document (which can possible lead to a <br/>            larger file)<br/>            Read/write bool.|
|svg_responsive_layout|True to exclude width and height attributes from SVG container - that will make layout responsive. False - otherwise.<br/>            Read/write bool.|
|notes_comments_layouting|Provides options that control how notes and comments is placed in exported document.|
|as_isave_options|Returns ISaveOptions interface.<br/>            Read-only [ISaveOptions](/python-net/api-reference/aspose.slides.export/isaveoptions/).|
|warning_callback|Returns or sets an object which receives warnings and decides whether loading process will continue or will be aborted.<br/>            Read/write [IWarningCallback](/python-net/api-reference/aspose.slides.warnings/iwarningcallback/).|
|progress_callback|Represents a callback object for saving progress updates in percentage. <br/>            See [IProgressCallback](/python-net/api-reference/aspose.slides/iprogresscallback/).|
|default_regular_font|Returns or sets font used in case source font is not found.<br/>            Read-write string.|
