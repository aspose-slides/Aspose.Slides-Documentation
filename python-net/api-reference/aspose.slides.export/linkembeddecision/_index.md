---
title: LinkEmbedDecision Enumeration
type: docs
weight: 720
url: /python-net/api-reference/aspose.slides.export/linkembeddecision/
---

Determines how object will be processed during saving.

**Namespace:** [aspose.slides.export](/slides/python-net/api-reference/aspose.slides.export/)

**Full Name:** aspose.slides.export.LinkEmbedDecision



## **Members**
|**Member name**|**Description**|
| :- | :- |
|LINK|Object will be stored externally, referrenced by URL|
|EMBED|Object should be embedded to a generated file if possible. If embedding is imposible, GetUrl will be called and, depending on result, object will be referrenced by URL or ignored.|
|IGNORE|Object will be ignored.|
