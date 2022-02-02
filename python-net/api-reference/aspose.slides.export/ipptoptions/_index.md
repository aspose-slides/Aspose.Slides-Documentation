---
title: IPptOptions Class
type: docs
weight: 200
url: /python-net/api-reference/aspose.slides.export/ipptoptions/
---

Provides options that control how a presentation is saved in PPT format.

**Namespace:** [aspose.slides.export](/slides/python-net/api-reference/aspose.slides.export/)

**Full Class Name:** aspose.slides.export.IPptOptions



The IPptOptions type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|root_directory_clsid|Represents the object class GUID (CLSID) that is stored in the root directory entry. Can be used for COM<br/>            activation of the document's application.<br/>            The default value is '64818D11-4F9B-11CF-86EA-00AA00B929E8' that corresponds to 'Microsoft Powerpoint.Slide.8'.|
|as_isave_options|Returns ISaveOptions interface.<br/>            Read-only [ISaveOptions](/slides/python-net/api-reference/aspose.slides.export/isaveoptions/).|
|warning_callback|Returns or sets an object which receives warnings and decides whether loading process will continue or will be aborted.<br/>            Read/write [IWarningCallback](/slides/python-net/api-reference/aspose.slides.warnings/iwarningcallback/).|
|progress_callback|Represents a callback object for saving progress updates in percentage. <br/>            See [IProgressCallback](/slides/python-net/api-reference/aspose.slides/iprogresscallback/).|
|default_regular_font|Returns or sets font used in case source font is not found.<br/>            Read-write string.|
