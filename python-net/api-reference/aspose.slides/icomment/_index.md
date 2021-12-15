---
title: IComment Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 1110
url: /python-net/api-reference/aspose.slides/icomment/
---

Represents a comment on a slide.

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IComment

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IComment type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|text|Returns or sets the plain text of a slide comment.<br/>            Read/write string.|
|created_time|Returns or sets the time of a comment creation.<br/>            Setting this property to min date value means no comment time is set.<br/>            Read/write datetime.|
|slide|Returns or sets the parent slide of a comment.<br/>            Read-only [ISlide](/python-net/api-reference/aspose.slides/islide/).|
|author|Returns the author of a comment.<br/>            Read-only [ICommentAuthor](/python-net/api-reference/aspose.slides/icommentauthor/).|
|position|Returns or sets the position of a comment on a slide.<br/>            Read/write aspose.pydrawing.PointF.|
|parent_comment|Gets or sets parent comment.<br/>            Read/write [IComment](/python-net/api-reference/aspose.slides/icomment/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|remove()|Removes comment and all its replies from the parent collection.|
