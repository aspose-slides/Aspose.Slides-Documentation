---
title: PresentationLockingBehavior
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 9650
url: /python-net/api-reference/aspose.slides/presentationlockingbehavior/
---

## PresentationLockingBehavior enumeration

Represents the behavior regarding treating the [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/) source (file or <br/>            stream) while loading and working with an instance of [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).

## Members
| Member name | Description |
| :- | :- |
|LOAD_AND_RELEASE|The source will be locked only for a time of [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/) constructor execution.|
|KEEP_LOCKED|The source will be locked for a whole lifetime of [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/) instance, until it will <br/>            be disposed.|
|LOAD_AND_RELEASE_LEGACY_TEMPORARY_DEFAULT|The source will be locked only for a time of [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/) constructor execution, all BLOBs <br/>            will be loaded into memory.<br/>            This behavior is the legacy behavior to provide backward compatibility. The same behavior can be achieved <br/>            by using [LOAD_AND_RELEASE](/slides/python-net/api-reference/aspose.slides/presentationlockingbehavior/) and set [is_temporary_files_allowed](/slides/python-net/api-reference/aspose.slides/iblobmanagementoptions/) <br/>            to false. <br/>            Please consider choosing the [LOAD_AND_RELEASE](/slides/python-net/api-reference/aspose.slides/presentationlockingbehavior/) or [KEEP_LOCKED](/slides/python-net/api-reference/aspose.slides/presentationlockingbehavior/) behavior, what is <br/>            the most suitable for you. <br/>            After|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

