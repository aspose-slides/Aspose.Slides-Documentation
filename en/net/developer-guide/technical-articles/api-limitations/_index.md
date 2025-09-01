---
title: API Limitations
type: docs
weight: 320
url: /net/api-limitations/
keywords:
- API limitations
- export format
- application
- producer
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

**Application** identifies the program that created or last saved the presentation. You’ll see it in file properties for PowerPoint and OpenDocument formats. With Aspose.Slides for .NET, this value is fixed and shows the library vendor rather than your app name.

**Producer** identifies the rendering engine that generated the final file during export. It is most visible in exported PDFs, and it may appear in other export targets as a generator tag. With Aspose.Slides for .NET, this value is also fixed and reflects the library and its version.

**What’s restricted**

You cannot override these two fields through the API. Aspose.Slides for .NET writes them as vendor defaults—""Aspose.Slides for .NET" for Application and "Aspose.Slides for .NET x.x.x" for Producer—across presentations (PPT, PPTX, ODP) and other export formats. This behavior is by design and applies regardless of how you load or save the file.
