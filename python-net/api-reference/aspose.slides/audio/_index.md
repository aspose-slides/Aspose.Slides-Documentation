---
title: Audio Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 30
url: /python-net/api-reference/aspose.slides/audio/
---

Represents an embedded audio file.

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.Audio

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The Audio type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|content_type|Returns a MIME type of an audio, encoded in [binary_data](/python-net/api-reference/aspose.slides/audio/).<br/>            Read-only string.|
|binary_data|Returns the copy of an audio's data. In case of large amount of data consider <br/>            using of [None](/python-net/api-reference/aspose.slides/audio/) method to prevent unnecessary  loading of audio's<br/>            data into memory or even OutOfMemoryException.<br/>            Read-only int[].|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_stream()|Returns Stream stream for reading.<br/>            Use 'using' or close stream after using.|
