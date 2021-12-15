---
title: LinkEmbedDecision Enumeration - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 720
url: /python-net/api-reference/aspose.slides.export/linkembeddecision/
---

Determines how object will be processed during saving.

**Namespace:** [aspose.slides.export](/python-net/api-reference/aspose.slides.export/)

**Full Name:** aspose.slides.export.LinkEmbedDecision

**Assembly:**  Aspose.Slides Version: 21.12.0.0

## **Members**
|**Member name**|**Value**|**Description**|
| :- | :- | :- |
|LINK|0|Object will be stored externally, referrenced by URL|
|EMBED|1|Object should be embedded to a generated file if possible. If embedding is imposible, GetUrl will be called and, depending on result, object will be referrenced by URL or ignored.|
|IGNORE|2|Object will be ignored.|
