---
title: ModernComment Class
type: docs
weight: 3060
url: /python-net/api-reference/aspose.slides/moderncomment/
---

Represents a comment on a slide.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.ModernComment

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ModernComment type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|text|Returns or sets the plain text of a slide comment.<br/>            Read/write string.|
|created_time|Returns or sets the time of a comment creation.<br/>            Setting this property to min date value means no comment time is set.<br/>            Read/write datetime.|
|slide|Returns or sets the parent slide of a comment.<br/>            Read-only [ISlide](/python-net/api-reference/aspose.slides/islide/).|
|author|Returns the author of a comment.<br/>            Read-only [ICommentAuthor](/python-net/api-reference/aspose.slides/icommentauthor/).|
|position|Returns or sets the position of a comment on a slide.<br/>            Read/write aspose.pydrawing.PointF.|
|parent_comment|Gets or sets parent comment.<br/>            Read/write [IComment](/python-net/api-reference/aspose.slides/icomment/).|
|shape|Returns a shape associated with the comment.<br/>            Read-only [IShape](/python-net/api-reference/aspose.slides/ishape/).|
|text_selection_start|Gets or sets starting position of text selection in text frame if the comment associated with AutoShape.<br/>            Read/write|
|text_selection_length|Gets or sets text selection length in text frame if the comment associated with AutoShape.<br/>            Read/write|
|status|Gets or sets the status of the comment.<br/>            Read/write [ModernCommentStatus](/python-net/api-reference/aspose.slides/moderncommentstatus/).|
|as_icomment|Allows to get base IComment interface.<br/>            Read-only [IComment](/python-net/api-reference/aspose.slides/icomment/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|remove()|Removes comment and all its replies from the parent collection.|
