---
title: API Limitations
type: docs
weight: 320
url: /cpp/api-limitations/
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
- C++
- Aspose.Slides
description: "Know Aspose.Slides for C++ limits: exports set fixed Application/Producer metadata in PPT, PPTX, ODP, and PDF—helping you plan integrations without surprises."
---

## **Application and Producer**

When you create or export presentations with Aspose.Slides for C++, some technical metadata is written into the file. Two fields often raise questions:

**Application** identifies the program that created or last saved a **PPTX** presentation. In Aspose.Slides for C++, this value is fixed and shows the library vendor rather than your app name, even if you use [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/).

**Producer** identifies the rendering engine that generated the final file during export. In **PDF** exports, metadata uses **Creator** and **Producer** fields. With Aspose.Slides for C++, both of these are fixed and reflect the library and its version.

**What’s restricted**

You cannot override these fields through the API for the formats above. For **PPTX**, the Application property is written as "Aspose.Slides for C++". For **PDF**, the Creator and Producer properties are written as "Aspose.Slides for C++ x.x.x". This behavior is by design and applies regardless of how you load or save the file, and regardless of values assigned using [DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/).
