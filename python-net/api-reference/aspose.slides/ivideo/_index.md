---
title: IVideo Class
type: docs
weight: 2770
url: /python-net/api-reference/aspose.slides/ivideo/
---

Represents a video embedded into a presentation.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IVideo

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IVideo type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|content_type|Returns a MIME type of an video, encoded in [binary_data](/python-net/api-reference/aspose.slides/ivideo/).<br/>            Read-only string.|
|binary_data|Returns the copy of an audio's data. In case of large amount of data consider using of <br/>            [None](/python-net/api-reference/aspose.slides/ivideo/) method to prevent unnecessary loading of video's data into memory <br/>            or even OutOfMemoryException.<br/>            Read-only int[].|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_stream()|Returns Stream stream for reading.<br/>            Use 'using' or close stream after using.|