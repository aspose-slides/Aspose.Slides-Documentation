---
title: Features Overview
type: docs
weight: 94
url: /net/features-overview/
keywords:
- features
- supported platforms
- file formats
- conversion
- rendering
- presentation content
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Review what Aspose.Slides for .NET covers before you evaluate it: supported platforms, file formats, slide rendering, and the content you can create and edit."
---

## **Overview**

Aspose.Slides for .NET is a class library for creating, reading, editing, converting, and rendering PowerPoint and OpenDocument presentations. It has no user interface of its own and does not require Microsoft PowerPoint or Office, so you can use it in console applications, desktop applications such as Windows Forms, web applications, and web services. This article summarizes what the library covers and links to the articles that describe each area.

## **Supported Platforms**

Aspose.Slides for .NET is distributed as two NuGet packages with the same API:

|**Package**|**Builds in the package**|**Operating systems**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0, and .NET 6. Use it with .NET Framework 4.6.2 or later, or with .NET 6 or later.|Windows. Linux and macOS with the `libgdiplus` library and the `System.Drawing.EnableUnixSupport` switch.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Use it with .NET 6 or later.|Windows (x86, x64), Linux (x64 with glibc 2.23 or later, ARM64 with glibc 2.39 or later), and macOS (x64, ARM64).|

[Installation](/slides/net/installation/) explains which package to choose and what each one needs on Linux. [System Requirements](/slides/net/system-requirements/) lists the supported platforms in detail.

## **File Formats and Conversions**

Aspose.Slides opens and saves PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP, and PowerPoint XML presentations. It imports PDF and HTML content into slides, and it saves presentations as PDF, XPS, HTML, HTML5, TIFF, animated GIF, SWF, Markdown, and XAML. [Supported File Formats](/slides/net/supported-file-formats/) lists every format with the API that reads or writes it.

|**Feature**|**Description**|
| :- | :- |
|[PPT and PPTX](/slides/net/ppt-vs-pptx/)|Read and write both the binary PowerPoint 97-2003 format and the Office Open XML format.|
|[PPT to PPTX conversion](/slides/net/convert-ppt-to-pptx/)|Convert legacy PPT presentations to PPTX.|
|[Portable Document Format (PDF)](/slides/net/convert-powerpoint-to-pdf/)|Export presentations to PDF, including PDF/A and PDF/UA documents.|
|[XML Paper Specification (XPS)](/slides/net/convert-powerpoint-to-xps/)|Export presentations to XPS documents.|
|[Tagged Image File Format (TIFF)](/slides/net/convert-powerpoint-to-tiff/)|Export presentations to TIFF images.|
|[HTML](/slides/net/convert-powerpoint-to-html/)|Export presentations to HTML and HTML5.|
|[PDF and HTML import](/slides/net/import-presentation/)|Create slides from PDF pages and HTML content.|

## **Presentation Rendering**

Aspose.Slides renders slides and individual shapes as PNG, JPEG, BMP, GIF, TIFF, and SVG images, and slides as EMF metafiles. See [Convert Presentation Slides to Images](/slides/net/convert-slide/), [Render a Slide as an SVG Image](/slides/net/render-a-slide-as-an-svg-image/), and [Create Shape Thumbnails](/slides/net/create-shape-thumbnails/).

## **Content Features**

Aspose.Slides lets you create, read, and modify almost all the content of a presentation:

|**Area**|**What you can do**|
| :- | :- |
|[Slides](/slides/net/presentation-slide/)|Add, clone, reorder, and remove slides; apply layouts and masters; organize slides into sections; change the slide size.|
|[Design](/slides/net/presentation-design/)|Set backgrounds, theme colors, headers and footers, and fonts.|
|[Text](/slides/net/manage-text/)|Create and edit text frames, paragraphs, and portions; set fonts, colors, bullets, and alignment; find and replace text.|
|[Shapes](/slides/net/powerpoint-shapes/)|Create AutoShapes, lines, connectors, group shapes, and picture frames; set position, size, line, and solid, gradient, or pattern fill; find a shape by its alternative text.|
|[Tables](/slides/net/powerpoint-table/), [charts](/slides/net/powerpoint-charts/), and [SmartArt](/slides/net/powerpoint-smartart/)|Create and edit tables, Microsoft Office charts, and SmartArt diagrams.|
|[Media](/slides/net/manage-media-files/), [OLE objects](/slides/net/manage-ole/), and [ActiveX controls](/slides/net/activex/)|Add embedded or linked audio and video frames, embed OLE objects, and add, modify, or remove ActiveX controls.|
|[Notes](/slides/net/presentation-notes/) and [comments](/slides/net/presentation-comments/)|Add, read, and edit speaker notes and review comments.|
|[Animation](/slides/net/powerpoint-animation/) and [transitions](/slides/net/slide-transition/)|Apply animation effects to shapes, set slide transitions, and configure slide show settings.|
|[Security](/slides/net/presentation-security/)|Encrypt presentations with a password, set write protection, and work with digital signatures.|
|[VBA macros](/slides/net/presentation-via-vba/)|Add, extract, and remove VBA modules in macro-enabled presentations.|
|[Properties](/slides/net/presentation-properties/)|Read and edit document properties.|

## **FAQ**

**Do I need to install Microsoft PowerPoint on the server or PC for the library to work?**

No. PowerPoint is not required; Aspose.Slides is a standalone engine for creating, editing, converting, and rendering presentations.

**How does multithreading work? Can processing be parallelized?**

It is safe to process different documents in different threads; the same [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) object must not be used by [multiple threads](/slides/net/multithreading/) at the same time.

**Are file passwords and encryption supported?**

Yes. [You can](/slides/net/password-protected-presentation/) open encrypted presentations, set or remove an open and write password, and check the protection status.

**Do I need to care about fonts in Linux containers?**

Yes. The fonts used in your presentations, or suitable substitutes, must be installed on the system for text to render correctly. You can also [specify font directories](/slides/net/custom-font/) in your application. [Installation](/slides/net/installation/) lists the Linux prerequisites of each package.

**Are there limitations in the evaluation version?**

Yes. Without a [license](/slides/net/licensing/), Aspose.Slides adds an evaluation watermark to every slide it saves and truncates text read from presentations. A [30-day temporary license](https://purchase.aspose.com/temporary-license/) is available for full-feature testing.

**Is importing external formats into a presentation (PDF or HTML to PPTX) supported?**

Yes. You can add [PDF pages and HTML content](/slides/net/import-presentation/) to a presentation, turning them into slides.
