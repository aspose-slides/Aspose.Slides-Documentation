---
title: PresentationLockingBehavior Enumeration
type: docs
weight: 9740
url: /slides/python-net/api-reference/aspose.slides/presentationlockingbehavior/
---

Represents the behavior regarding treating the [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/) source (file or <br/>            stream) while loading and working with an instance of [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Name:** aspose.slides.PresentationLockingBehavior

**Assembly:**  Aspose.Slides Version: 21.12.0.0

## **Members**
|**Member name**|**Value**|**Description**|
| :- | :- | :- |
|LOAD_AND_RELEASE|0|The source will be locked only for a time of [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/) constructor execution.|
|KEEP_LOCKED|1|The source will be locked for a whole lifetime of [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/) instance, until it will <br/>            be disposed.|
|LOAD_AND_RELEASE_LEGACY_TEMPORARY_DEFAULT|2|The source will be locked only for a time of [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/) constructor execution, all BLOBs <br/>            will be loaded into memory.<br/>            This behavior is the legacy behavior to provide backward compatibility. The same behavior can be achieved <br/>            by using [LOAD_AND_RELEASE](/python-net/api-reference/aspose.slides/presentationlockingbehavior/) and set [is_temporary_files_allowed](/python-net/api-reference/aspose.slides/iblobmanagementoptions/) <br/>            to false. <br/>            Please consider choosing the [LOAD_AND_RELEASE](/python-net/api-reference/aspose.slides/presentationlockingbehavior/) or [KEEP_LOCKED](/python-net/api-reference/aspose.slides/presentationlockingbehavior/) behavior, what is <br/>            the most suitable for you. <br/>            After|
