---
title: ICommentCollection
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 1140
url: /python-net/api-reference/aspose.slides/icommentcollection/
---

## ICommentCollection class

Represents a collection of comments of one author.

The ICommentCollection type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|as_icollection|Returns ICollection class.|
|as_ienumerable|Returns IEnumerable class.|
## Indexer
| Name | Description |
| :- | :- |
|[index]|Gets the element at the specified index.<br/>            Read-only [IComment](/slides/python-net/api-reference/aspose.slides/icomment/).|
## Methods
| Name | Description |
| :- | :- |
|to_array()|Creates and returns an array with all comments.|
|to_array(start_index, count)|Creates and returns an array with all comments from the specified range.|
|add_comment(text, slide, position, creation_time)|Add new comment at the end of a collection.|
|add_modern_comment(text, slide, shape, position, creation_time)|Add new modern comment at the end of a collection.|
|insert_comment(index, text, slide, position, creation_time)|Insert new comment to a collection at the specified index.|
|insert_modern_comment(index, text, slide, shape, position, creation_time)|Insert new modern comment to a collection at the specified index.|
|remove_at(index)|Removes the element at the specified index in a collection.|
|remove(comment)|Removes the element at the specified index in a collection.|
|clear()|Removes all comments from a collection.|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

