---
title: XpsOptions Class
type: docs
weight: 550
url: /slides/python-net/api-reference/aspose.slides.export/xpsoptions/
---

Provides options that control how a presentation is saved in XPS format.

**Namespace:** [aspose.slides.export](/slides/python-net/api-reference/aspose.slides.export/)

**Full Class Name:** aspose.slides.export.XpsOptions

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The XpsOptions type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|XpsOptions()|Default constructor.|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|warning_callback|Returns of sets an object which receives warnings and decides whether loading process will continue or will be aborted.<br/>            Read/write [IWarningCallback](/python-net/api-reference/aspose.slides.warnings/iwarningcallback/).|
|progress_callback|Represents a callback object for saving progress updates in percentage.<br/>            See [IProgressCallback](/python-net/api-reference/aspose.slides/iprogresscallback/).|
|default_regular_font|Returns or sets font used in case source font is not found.<br/>            Read-write string.|
|show_hidden_slides|Specifies whether the generated document should include hidden slides or not.<br/>            Default is|
|save_metafiles_as_png|True to convert all metafiles used in a presentation to the PNG images.<br/>            Read/write bool.|
|draw_slides_frame|True to draw black frame around each slide.<br/>             Read/write bool.|
|as_isave_options|Returns ISaveOptions interface.<br/>            Read-only [ISaveOptions](/python-net/api-reference/aspose.slides.export/isaveoptions/).|
