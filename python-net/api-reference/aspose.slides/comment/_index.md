---
title: Comment
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 290
url: /python-net/api-reference/aspose.slides/comment/
---

## Comment class

Represents a comment on a slide.

The Comment type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|text|Returns or sets the plain text of a slide comment.<br/>            Read/write string.|
|created_time|Returns or sets the time of a comment creation.<br/>            Setting this property to min date value means no comment time is set.<br/>            Read/write datetime.|
|slide|Returns or sets the parent slide of a comment.<br/>            Read-only [ISlide](/slides/python-net/api-reference/aspose.slides/islide/).|
|author|Returns the author of a comment.<br/>            Read-only [ICommentAuthor](/slides/python-net/api-reference/aspose.slides/icommentauthor/).|
|position|Returns or sets the position of a comment on a slide.<br/>            Read/write aspose.pydrawing.PointF.|
|parent_comment|Gets or sets parent comment.<br/>            Read/write [IComment](/slides/python-net/api-reference/aspose.slides/icomment/).|
## Methods
| Name | Description |
| :- | :- |
|remove()|Removes comment and all its replies from the parent collection.|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

