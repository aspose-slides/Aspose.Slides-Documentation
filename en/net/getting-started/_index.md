---
title: Getting Started
type: docs
weight: 10
url: /net/getting-started/
keywords:
- getting started
- system requirements
- installation
- first presentation
- NuGet
- PPT processing
- PPTX processing
- ODP processing
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "The path from a new .NET project to a first saved presentation with Aspose.Slides: check the requirements, install the package, run a first program, and continue with common tasks."
---

## **Overview**

Work through the four steps below in order. Each step names what to do and links the article with the details. Evaluation, licensing, and support are covered after the steps.

## **Step 1: Check the System Requirements**

Aspose.Slides for .NET runs on Windows, Linux, and macOS. [System Requirements](/slides/net/system-requirements/) lists the operating systems and .NET versions that each package supports, and the libraries that Linux needs in addition.

## **Step 2: Install the Package**

Aspose.Slides for .NET is distributed through NuGet as two packages that provide the same classes. Add one of them to your project:

- On Windows: `dotnet add package Aspose.Slides.NET`
- On Linux and macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. On Linux, install the `fontconfig` library first.
- On Alpine Linux, and on Linux systems whose glibc is older than 2.23 (x64) or 2.39 (ARM64): Aspose.Slides.NET, with the `libgdiplus` library installed.

[Installation](/slides/net/installation/) gives the Linux commands, the extra startup setting that Aspose.Slides.NET needs on Linux, and the steps for Visual Studio.

## **Step 3: Create Your First Presentation**

The [quick start on the Aspose.Slides for .NET home page](/slides/net/#your-first-presentation) is a complete console program: it adds a text box to a slide and saves the presentation as a PPTX file. [Create Presentations](/slides/net/create-presentation/) explains the same steps in more detail and shows how to open an existing presentation and save it in another format.

## **Step 4: Continue with Common Tasks**

- [Open a presentation](/slides/net/open-presentation/)
- [Save a presentation](/slides/net/save-presentation/)
- [Convert a presentation to PDF](/slides/net/convert-powerpoint-to-pdf/)
- [Render slides as images](/slides/net/convert-slide/)
- [Edit presentation text](/slides/net/manage-text/)
- [Examples by slide element](/slides/net/examples/)

## **Evaluate and License**

Without a license, Aspose.Slides runs in evaluation mode: it adds a watermark to every slide it saves and truncates text read from presentations.

- [Evaluate Aspose.Slides](/slides/net/evaluate-aspose-slides/) describes the evaluation limitations and how to request a temporary license.
- [Licensing](/slides/net/licensing/) shows how to apply a license from a file, a stream, or an embedded resource.
- [Metered Licensing](/slides/net/metered-licensing/) covers licensing that is billed by usage.
- [Supported File Formats](/slides/net/supported-file-formats/) lists the formats that Aspose.Slides can load and save.

## **Get Help**

[Product Support](/slides/net/product-support/) explains how to ask a question on the [free support forum](https://forum.aspose.com/c/slides/11) and what to include when you report a problem.

## **FAQ**

**Do I need Microsoft PowerPoint installed?**

No. Aspose.Slides reads and writes presentation files itself and does not use PowerPoint, so it also runs on servers and on Linux.

**Which package should I use for a .NET Framework application?**

Aspose.Slides.NET. It includes builds for .NET Framework 4.6.2 and later, .NET 6 and later, and .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform requires .NET 6 or later.
