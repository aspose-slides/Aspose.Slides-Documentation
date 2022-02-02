---
title: PdfAccessPermissions Enumeration
type: docs
weight: 740
url: /python-net/api-reference/aspose.slides.export/pdfaccesspermissions/
---

Contains a set of flags specifying which access permissions should be granted when the document is opened with <br/>            user access.

**Namespace:** [aspose.slides.export](/slides/python-net/api-reference/aspose.slides.export/)

**Full Name:** aspose.slides.export.PdfAccessPermissions



## **Members**
|**Member name**|**Description**|
| :- | :- |
|NONE|Specifies that a user does not have access permissions.|
|PRINT_DOCUMENT|Specifies whether a user may print the document (possibly not at the highest quality level, depending on <br/>            whether bit [HIGH_QUALITY_PRINT](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/) is also set).|
|MODIFY_CONTENT|Specifies whether a user may modify the contents of the document by operations other than those controlled<br/>            by bits [ADD_OR_MODIFY_FIELDS](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/), [FILL_EXISTING_FIELDS](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/), [ASSEMBLE_DOCUMENT](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/).|
|COPY_TEXT_AND_GRAPHICS|Specifies whether a user may copy or otherwise extract text and graphics from the document by operations <br/>            other than that controlled by bit [EXTRACT_TEXT_AND_GRAPHICS](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/).|
|ADD_OR_MODIFY_FIELDS|Specifies whether a user may add or modify text annotations, fill in interactive form fields, and, if bit<br/>            [MODIFY_CONTENT](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/) is also set, create or modify interactive form fields (including signature <br/>            fields).|
|FILL_EXISTING_FIELDS|Specifies whether a user may fill in existing interactive form fields (including signature fields), even if<br/>            bit [ADD_OR_MODIFY_FIELDS](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/) is clear.|
|EXTRACT_TEXT_AND_GRAPHICS|Specifies whether a user may extract text and graphics in support of accessibility to users with disabilities<br/>            or for other purposes.|
|ASSEMBLE_DOCUMENT|Specifies whether a user may assemble the document (insert, rotate, or delete pages and create bookmarks or<br/>            thumbnail images), even if bit [MODIFY_CONTENT](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/) is clear.|
|HIGH_QUALITY_PRINT|Specifies whether a user may print the document to a representation from which a faithful digital copy of<br/>            the PDF content could be generated. When this bit is clear (and bit [PRINT_DOCUMENT](/slides/python-net/api-reference/aspose.slides.export/pdfaccesspermissions/) is set),<br/>            printing is limited to a low-level representation of the appearance, possibly of degraded quality.|
