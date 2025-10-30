---
title: API Limitations
type: docs
weight: 320
url: /net/api-limitations/
keywords:
- API limitations
- document properties
- metadata
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Know Aspose.Slides for .NET limits: exports set fixed Application/Producer metadata in PPT, PPTX, ODP, and PDF—helping you plan integrations without surprises."
---

## **Application and Producer**

When you create or export presentations with Aspose.Slides for .NET, some technical metadata is written into the file. Two fields often raise questions:

**Application** identifies the program that created or last saved a **PPTX** presentation. In Aspose.Slides for .NET, this value is fixed and shows the library vendor rather than your app name, even if you set [Presentation.DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).

**Producer** identifies the rendering engine that generated the final file during export. In **PDF** exports, metadata uses **Creator** and **Producer** fields. With Aspose.Slides for .NET, both of these are fixed and reflect the library and its version.

**What’s restricted**

You cannot override these fields through the API for the formats above. For **PPTX**, the Application property is written as “Aspose.Slides for .NET.” For **PDF**, the Creator and Producer properties are written as “Aspose.Slides for .NET x.x.x.” This behavior is by design and applies regardless of how you load or save the file, and regardless of values assigned to [Presentation.DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/).
