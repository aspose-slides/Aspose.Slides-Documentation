---
title: BlobManagementOptions
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 160
url: /python-net/api-reference/aspose.slides/blobmanagementoptions/
---

## BlobManagementOptions class

Represents options which can be used to manage BLOB handling rules and other BLOB settings.

The BlobManagementOptions type exposes the following members:
## Constructors
| Name | Description |
| :- | :- |
|BlobManagementOptions()|Creates new default blob management options.|
## Properties
| Name | Description |
| :- | :- |
|presentation_locking_behavior|Represents the locking behavior for the presentation's source (stream or file).|
|is_temporary_files_allowed|Set that using of temporary files is not allowed to optimize memory consumption while working with<br/>            large amounts of data during presentation's lifetime. If false, OutOfMemoryException can be thrown.|
|temp_files_root_path|Represents the root path on the filesystem, where the temporary files will be stored. System<br/>            temorary directory will be used by default.|
|max_blobs_bytes_in_memory|A threshold that indicates the maximum amount of bytes which BLOBs can occupied in memory. After <br/>            this threshold was reached, all new BLOBs will be placed in temporary files and will not affect the <br/>            total memory consumption of the process. <br/>            [is_temporary_files_allowed](/slides/python-net/api-reference/aspose.slides/blobmanagementoptions/) should be set to true to use this property.|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

