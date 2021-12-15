---
title: IWarningInfo Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 60
url: /python-net/api-reference/aspose.slides.warnings/iwarninginfo/
---

Represents a base interface for all warnings.

**Namespace:** [aspose.slides.warnings](/python-net/api-reference/aspose.slides.warnings/)

**Full Class Name:** aspose.slides.warnings.IWarningInfo

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IWarningInfo type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|warning_type|Returns a type of warning.<br/>            Read-only [warning_type](/python-net/api-reference/aspose.slides.warnings/iwarninginfo/).|
|description|Returns a human readable description of this warning.<br/>            Read-only string.|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|send_warning(receiver)|If receiver is not null ends warning to a specified receiver and throws the <br/>            AbortRequestedException if receiver decided to abort a operation.|
