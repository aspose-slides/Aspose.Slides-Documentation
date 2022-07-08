---
title: ILinkEmbedController
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 170
url: /python-net/api-reference/aspose.slides.export/ilinkembedcontroller/
---

## ILinkEmbedController class

Callback interface used to determine how object should be processed during saving.

The ILinkEmbedController type exposes the following members:
## Methods
| Name | Description |
| :- | :- |
|get_object_storing_location(id, entity_data, semantic_name, content_type, recomended_extension)|Determines where object should be stored.<br/>            This method is called once for each object id.<br/>            It is not guaranteed that there won't be two objects with same data, semanticName and contentType but with different id.|
|get_url(id, referrer)|Returns an URL to an external object.<br/>            This method always called if|
|save_external(id, entity_data)|Saves external object.|

### See Also

* namespace [aspose.slides.export](/slides/python-net/api-reference/aspose.slides.export/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

