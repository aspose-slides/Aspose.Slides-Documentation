---
title: IAutoShapeLock Class
type: docs
weight: 820
url: /slides/python-net/api-reference/aspose.slides/iautoshapelock/
---

Determines which operations are disabled on the parent AutoshapeEx.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IAutoShapeLock

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IAutoShapeLock type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|grouping_locked|Determines whether an adding this shape to a group is forbidden.<br/>            Read-write bool.|
|select_locked|Determines whether a selecting this shape is forbidden.<br/>            Read-write bool.|
|rotate_locked|Determines whether a changing rotation angle of this shape is forbidden.<br/>            Read-write bool.|
|aspect_ratio_locked|Determines whether a shape have to preserve aspect ratio on resizing.<br/>            Read-write bool.|
|position_locked|Determines whether a moving this shape is forbidden.<br/>            Read-write bool.|
|size_locked|Determines whether a resizing this shape is forbidden.<br/>            Read-write bool.|
|edit_points_locked|Determines whether a direct changing of contour of this shape is forbidden.<br/>            Read-write bool.|
|adjust_handles_locked|Determines whether a changing adjust values is forbidden.<br/>            Read-write bool.|
|arrowheads_locked|Determines whether a changing arrowheads is forbidden.<br/>            Read-write bool.|
|shape_type_locked|Determines whether a changing of a shape type is forbidden.<br/>            Read-write bool.|
|text_locked|Determines whether an editing of text is forbidden.<br/>            Read-write bool.|
|as_ibase_shape_lock|Allows to get base IBaseShapeLock interface.<br/>            Read-only [IBaseShapeLock](/python-net/api-reference/aspose.slides/ibaseshapelock/).|
|no_locks|Return true if all lock-flags are disabled.<br/>            Read-only bool.|
