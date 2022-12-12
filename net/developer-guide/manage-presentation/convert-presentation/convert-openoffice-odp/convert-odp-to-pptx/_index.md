---
title: Convert ODP to PPTX in C#
linktitle: Convert ODP to PPTX
type: docs
weight: 10
url: /net/convert-odp-to-pptx/
keywords: "Convert OpenOffice Presentation, ODP, ODP to PPTX, C#, Csharp, .NET"
description: "Convert OpenOffice ODP to PowerPoint Presentation PPTX  in C# or .NET"
---

## Overview

This article explains the following topics.

- [C# Convert ODP to PPTX](#csharp-odp-to-pptx)
- [C# Convert ODP to PowerPoint](#csharp-odp-to-powerpoint)

## C# ODP to PPTX Conversion

Aspose.Slides for .NET offers Presentation class that represents a presentation file. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) class can now also access ODP through Presentation constructor when the object is instantiated. The following example shows how to convert a ODP Presentation into PPTX Presentation.

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>Steps: Convert ODP to PPTX in C#</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>Steps: Convert ODP to PowerPoint in C#</strong></a>

```c#
// Open the ODP file
Presentation pres = new Presentation("AccessOpenDoc.odp");

// Saving the ODP presentation to PPTX format
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```



## **Live Example**
You can visit [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) web app, which is built with **Aspose.Slides API.** The app demonstrates how ODP to PPTX conversion can be implemented with Aspose.Slides API.
