---
title: LoadOptions Class
type: docs
weight: 2960
url: /python-net/api-reference/aspose.slides/loadoptions/
---

Allows to specify additional options (such as format or default font) when loading a presentation.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.LoadOptions

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The LoadOptions type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|LoadOptions()|Creates new default load options.|
|LoadOptions(load_format)|Initializes a new instance of the LoadOptions class|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|load_format|Returns or sets format of a presentation to load.<br/>            Read/write [LoadFormat](/python-net/api-reference/aspose.slides/loadformat/).|
|default_regular_font|Returns or sets Regular font used in case source font is not found.<br/>            Read/write string.|
|default_symbol_font|Returns or sets Symbol font used in case source font is not found.<br/>            Read/write string.|
|default_asian_font|Returns or sets Asian font used in case source font is not found.<br/>            Read/write string.|
|password|Gets or sets the password.<br/>            Read/write string.|
|only_load_document_properties|This property makes sense, if presentation file is password protected.<br/>            Value of true means that only document properties must be loaded from an encrypted <br/>            presentation file and password must be ignored.<br/>            Value of false means that entire encrypted presentation must be loaded with use of right <br/>            password.<br/>            If presentation isn't encrypted then property value is always ignored.<br/>            If document properties of an encrypted file aren't public and property value is true then<br/>            document properties cannot be loaded and exception will be thrown.<br/>            Read/write bool.|
|warning_callback|Returns or sets an object which receives warnings and decides whether loading <br/>            process will continue or will be aborted.<br/>            Read/write [IWarningCallback](/python-net/api-reference/aspose.slides.warnings/iwarningcallback/).|
|blob_management_options|Represents the options which can be used to manage Binary Large Objects (BLOBs) handling behavior,<br/>            such as using of temporary files or max BLOBs bytes in memory. These options intended to set up<br/>            the best performance/memory consumption ratio for a perticular environment or requirements.|
|document_level_font_sources|Specifies sources for external fonts to be used by the presentation.<br/>            These fonts are available to the presentation throughout its lifetime and are not shared with other presentations|
|interruption_token|The token to monitor for interruption requests.|
|resource_loading_callback|Returns or sets callback interface which manages external resources loading.<br/>            Read/write [IResourceLoadingCallback](/python-net/api-reference/aspose.slides/iresourceloadingcallback/).|
|spreadsheet_options|Gets options for spreadsheets. For example, these options affect calculating formulas for charts.|
