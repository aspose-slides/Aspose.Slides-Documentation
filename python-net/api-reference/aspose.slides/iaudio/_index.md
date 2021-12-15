---
title: IAudio Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 780
url: /python-net/api-reference/aspose.slides/iaudio/
---

Represents an embedded audio file.

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IAudio

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IAudio type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|content_type|Returns a MIME type of an audio, encoded in [binary_data](/python-net/api-reference/aspose.slides/iaudio/).<br/>            Read-only string.|
|binary_data|Returns the copy of an audio's data. In case of large amount of data consider <br/>            using of [None](/python-net/api-reference/aspose.slides/iaudio/) method to prevent unnecessary  loading of audio's<br/>            data into memory or even OutOfMemoryException.<br/>            Read-only int[].|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_stream()|Returns Stream stream for reading.<br/>            Use 'using' or close stream after using.|
