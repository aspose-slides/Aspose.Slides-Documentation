---
title: IPresentationInfo Class
type: docs
weight: 2260
url: /slides/python-net/api-reference/aspose.slides/ipresentationinfo/
---

Information about presentation file

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IPresentationInfo

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IPresentationInfo type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|is_encrypted|Gets True if binded presentation is encrypted, otherwise False.<br/>            Read-only bool.|
|is_password_protected|Gets a value that indicates whether a binded presentation is protected by a password to open.|
|is_write_protected|Gets a value that indicates whether a binded presentation is write protected.|
|load_format|Gets format of the binded presentation.<br/>            Read-only [LoadFormat](/python-net/api-reference/aspose.slides/loadformat/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|write_binded_presentation(stream)|Writes binded presentation to stream.|
|write_binded_presentation(file)|Writes binded presentation to file.|
|check_password(password)|Checks whether a password is correct for a presentation protected with open password.|
|check_write_protection(password)|Checks whether a password to modify is correct for a write protected presentation.|
|read_document_properties()|Gets document properties of binded presentation.|
|update_document_properties(document_properties)|Updates properties of binded presentation.|
