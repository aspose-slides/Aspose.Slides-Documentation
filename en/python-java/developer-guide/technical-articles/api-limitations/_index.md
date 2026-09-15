---
title: API Limitations
type: docs
weight: 320
url: /python-java/api-limitations/
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
- Java
- Aspose.Slides
description: "Learn about Aspose.Slides for Python via Java limitations: fixed Application, Creator, and Producer metadata in PPTX and PDF files."
---

## **Overview**

When presentations are created or exported with Aspose.Slides, certain technical metadata is written to the output file. This article explains the limitations related to the `Application`, `Creator`, and `Producer` metadata fields in PPTX and PDF files.

## **Application and Producer**

When you create or export presentations with Aspose.Slides for Python via Java, some technical metadata is written into the file. Two fields often raise questions:

**Application** identifies the program that created or last saved a **PPTX** presentation. In Aspose.Slides for Python via Java, this value is fixed and shows the library vendor rather than your app name, even if you use [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Producer** identifies the rendering engine that generated the final file during export. In **PDF** exports, metadata uses **Creator** and **Producer** fields. With Aspose.Slides for Python via Java, both of these are fixed and reflect the library and its version.

**What's Restricted**

You cannot override these fields through the API for the formats above. For **PPTX**, the Application property is written as "Aspose.Slides for Java". For **PDF**, the Creator and Producer properties are written as "Aspose.Slides for Java x.x.x." This behavior is by design and applies regardless of how you load or save the file, and regardless of values assigned using [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setnameofapplication).

## **FAQ**

**Can I replace the Application value in a PPTX file with my app name?**

No. The value is fixed, even if you use [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setnameofapplication).

**Can I override the Creator and Producer fields in PDF exports?**

No. Both fields are fixed and reflect the library and its version, regardless of how you load or save the presentation.
