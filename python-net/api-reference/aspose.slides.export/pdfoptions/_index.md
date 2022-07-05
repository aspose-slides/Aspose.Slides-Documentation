---
title: PdfOptions
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 390
url: /python-net/api-reference/aspose.slides.export/pdfoptions/
---

## PdfOptions class

Provides options that control how a presentation is saved in Pdf format.

The PdfOptions type exposes the following members:
## Constructors
| Name | Description |
| :- | :- |
|PdfOptions()|Default constructor.|
## Properties
| Name | Description |
| :- | :- |
|warning_callback|Returns of sets an object which receives warnings and decides whether loading process will continue or will be aborted.<br/>            Read/write [IWarningCallback](/slides/python-net/api-reference/aspose.slides.warnings/iwarningcallback/).|
|progress_callback|Represents a callback object for saving progress updates in percentage.<br/>            See [IProgressCallback](/slides/python-net/api-reference/aspose.slides/iprogresscallback/).|
|default_regular_font|Returns or sets font used in case source font is not found.<br/>            Read-write string.|
|notes_comments_layouting|Provides options that control how notes and comments is placed in exported document.|
|show_hidden_slides|Specifies whether the generated document should include hidden slides or not.<br/>            Default is|
|text_compression|Specifies compression type to be used for all textual content in the document.<br/>            Read/write [PdfTextCompression](/slides/python-net/api-reference/aspose.slides.export/pdftextcompression/).|
|best_images_compression_ratio|Indicates if the most effective compression (instead of the default one) for each image must be selected <br/>            automatically. If set to bool.true, for every image in presentation the most appropriate compression <br/>            algorithm will be chosen, what will lead to the smaller size of the resulting PDF document.|
|embed_true_type_fonts_for_ascii|Determines if Aspose.Slides will embed common fonts for ASCII (33..127 code range) text.<br/>            Fonts for character codes greater than 127 are always embedded.<br/>            Common fonts list includes PDF's base 14 fonts and additional user specified fonts.<br/>            Read/write bool.|
|additional_common_font_families|Returns or sets an array of user-defined names of font families which Aspose.Slides should consider common.<br/>            Read/write string[].|
|embed_full_fonts|Determines if all characters of font should be embedded or only used subset.<br/>            Read/write bool.|
|jpeg_quality|Returns or sets a value determining the quality of the JPEG images inside PDF document.<br/>            Read/write int.|
|compliance|Desired conformance level for generated PDF document.<br/>            Read/write [PdfCompliance](/slides/python-net/api-reference/aspose.slides.export/pdfcompliance/).|
|password|Setting user password to protect the PDF document. <br/>            Read/write string.|
|access_permissions|Contains a set of flags specifying which access permissions should be granted when the document is opened<br/>            with user access. See [PdfAccessPermissions](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/).|
|save_metafiles_as_png|True to convert all metafiles used in a presentation to the PNG images.<br/>            Read/write bool.|
|sufficient_resolution|Returns or sets a value determining resolution of images inside PDF document.|
|draw_slides_frame|True to draw black frame around each slide.<br/>             Read/write bool.|
|image_transparent_color|Gets or sets the image transparent color.|
|apply_image_transparent|Applies the specified transparent color to an image if|
|as_isave_options|Returns ISaveOptions interface.<br/>            Read-only [ISaveOptions](/slides/python-net/api-reference/aspose.slides.export/isaveoptions/).|

### See Also

* namespace [aspose.slides.export](/slides/python-net/api-reference/aspose.slides.export/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

