---
title: API Limitations
type: docs
weight: 210
url: /python-net/api-limitations/
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
- Python
- Aspose.Slides
description: "Know Aspose.Slides for Python limits: exports set fixed Application/Producer metadata in PPT, PPTX, ODP, and PDF—helping you plan integrations without surprises."
---

## **Application and Producer**

When you create or export presentations with Aspose.Slides for Python via .NET, some technical metadata is written into the file. Two fields often raise questions:

**Application** identifies the program that created or last saved a **PPTX** presentation. In Aspose.Slides for Python via .NET, this value is fixed and shows the library vendor rather than your app name, even if you set [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/).

**Producer** identifies the rendering engine that generated the final file during export. In **PDF** exports, metadata uses **Creator** and **Producer** fields. With Aspose.Slides for Python via .NET, both of these are fixed and reflect the library and its version.

**What’s restricted**

You cannot override these fields through the API for the formats above. For **PPTX**, the Application property is written as "Aspose.Slides for Python via .NET". For **PDF**, the Creator and Producer properties are written as "Aspose.Slides for Python via .NET x.x.x". This behavior is by design and applies regardless of how you load or save the file, and regardless of values assigned to [DocumentProperties.name_of_application](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/name_of_application/).
