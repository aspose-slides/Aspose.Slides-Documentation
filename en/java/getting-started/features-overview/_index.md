---
title: Features Overview
type: docs
weight: 104
url: /java/features-overview/
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
- Java
- Aspose.Slides
description: "Review what Aspose.Slides for Java covers before you evaluate it: supported platforms, file formats, slide rendering, and the content you can create and edit."
---

## **Overview**

Aspose.Slides for Java is a class library for creating, reading, editing, converting, and rendering PowerPoint and OpenDocument presentations. It has no user interface of its own and does not require Microsoft PowerPoint or Microsoft Office. This article summarizes what the library covers and links to the articles that describe each area.

## **Supported Platforms**

Aspose.Slides for Java is a single JAR file, published in Aspose's Maven repository with the `jdk16` classifier. It is written in pure Java: the JAR contains no native libraries, and it does not depend on other packages.

- **Java:** Java 8 or later. Aspose.Slides for Java 26.9 and earlier versions also run on Java 6 and 7, which version 26.10 no longer supports; see the [26.9 release notes](https://releases.aspose.com/slides/java/release-notes/2026/aspose-slides-for-java-26-9-release-notes/).
- **Operating systems:** any operating system with a Java runtime, such as Windows, Linux, and macOS. On Linux, the fontconfig library and at least one font must be installed.

[Installation](/slides/java/installation/) shows how to add the library to a project and lists the Linux prerequisites. [System Requirements](/slides/java/system-requirements/) lists the supported platforms in detail.

## **File Formats and Conversions**

Aspose.Slides opens and saves PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP, and PowerPoint XML presentations. It imports PDF and HTML content into slides, and it saves presentations as PDF, XPS, HTML, HTML5, TIFF, animated GIF, SWF, Markdown, and XAML. [Supported File Formats](/slides/java/supported-file-formats/) lists every format with the API that reads or writes it.

|**Feature**|**Description**|
| :- | :- |
|[PPT and PPTX](/slides/java/ppt-vs-pptx/)|Read and write both the binary PowerPoint 97-2003 format and the Office Open XML format.|
|[PPT to PPTX conversion](/slides/java/convert-ppt-to-pptx/)|Convert legacy PPT presentations to PPTX.|
|[ODP to PPTX conversion](/slides/java/convert-odp-to-pptx/)|Open and save ODP, OTP, and FODP presentations, and convert ODP presentations to PPTX.|
|[Portable Document Format (PDF)](/slides/java/convert-powerpoint-to-pdf/)|Export presentations to PDF, including PDF/A and PDF/UA documents.|
|[XML Paper Specification (XPS)](/slides/java/convert-powerpoint-to-xps/)|Export presentations to XPS documents.|
|[Tagged Image File Format (TIFF)](/slides/java/convert-powerpoint-to-tiff/)|Export presentations to multi-page TIFF images, one page per slide.|
|[HTML](/slides/java/convert-powerpoint-to-html/)|Export presentations to HTML and HTML5.|
|[PDF and HTML import](/slides/java/import-presentation/)|Create slides from PDF pages and HTML content.|

## **Presentation Rendering**

Aspose.Slides renders slides and individual shapes as PNG, JPEG, BMP, GIF, TIFF, and SVG images, and slides as EMF metafiles. See [Convert Presentation Slides to Images](/slides/java/convert-slide/), [Render Presentation Slides as SVG Images](/slides/java/render-a-slide-as-an-svg-image/), and [Create Thumbnails of Presentation Shapes](/slides/java/create-shape-thumbnails/).

## **Content Features**

Aspose.Slides lets you create, read, and modify almost all the content of a presentation:

|**Area**|**What you can do**|
| :- | :- |
|[Slides](/slides/java/presentation-slide/)|Add, clone, reorder, and remove slides; apply layouts and masters; organize slides into sections; change the slide size.|
|[Design](/slides/java/presentation-design/)|Set backgrounds, theme colors, headers and footers, and fonts.|
|[Text](/slides/java/manage-text/)|Create and edit text frames, paragraphs, and portions; set fonts, colors, bullets, and alignment; find and replace text.|
|[Shapes](/slides/java/powerpoint-shapes/)|Create AutoShapes, lines, connectors, group shapes, and picture frames; set position, size, line, and solid, gradient, or pattern fill; find a shape by its alternative text.|
|[Tables](/slides/java/powerpoint-table/), [charts](/slides/java/powerpoint-charts/), and [SmartArt](/slides/java/powerpoint-smartart/)|Create and edit tables, Microsoft Office charts, and SmartArt diagrams.|
|[Media](/slides/java/manage-media-files/), [OLE objects](/slides/java/manage-ole/), and [ActiveX controls](/slides/java/activex/)|Add embedded or linked audio and video frames, embed OLE objects, and add, modify, or remove ActiveX controls.|
|[Notes](/slides/java/presentation-notes/) and [comments](/slides/java/presentation-comments/)|Add, read, and edit speaker notes and review comments.|
|[Animation](/slides/java/powerpoint-animation/) and [transitions](/slides/java/slide-transition/)|Apply animation effects to shapes, set slide transitions, and configure slide show settings.|
|[Security](/slides/java/presentation-security/)|Encrypt presentations with a password, set write protection, and work with [digital signatures](/slides/java/digital-signature-in-powerpoint/).|
|[VBA macros](/slides/java/presentation-via-vba/)|Add, extract, and remove VBA modules in macro-enabled presentations.|
|[Properties](/slides/java/presentation-properties/)|Read and edit document properties.|

## **FAQ**

**Do I need to install Microsoft PowerPoint on the server or PC for the library to work?**

No. PowerPoint is not required; Aspose.Slides is a standalone engine for creating, editing, converting, and rendering presentations.

**How does multithreading work? Can processing be parallelized?**

It is safe to process different documents in different threads; the same [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) object must not be used by [multiple threads](/slides/java/multithreading/) at the same time.

**Are file passwords and encryption supported?**

Yes. [You can](/slides/java/password-protected-presentation/) open encrypted presentations, set or remove an open and write password, and check the protection status.

**Do I need to care about fonts in Linux containers?**

Yes. On Linux, the fontconfig library and at least one font must be installed, and the fonts used in your presentations, or suitable substitutes, must be installed for text to render correctly. You can also [specify font directories](/slides/java/custom-font/) in your application. See [Installation](/slides/java/installation/#linux).

**Are there limitations in the evaluation version?**

Yes. Without a [license](/slides/java/licensing/), Aspose.Slides adds an evaluation watermark to every slide it saves and truncates text that your code reads through the API. A [30-day temporary license](https://purchase.aspose.com/temporary-license/) is available for full-feature testing.

**Is importing external formats into a presentation (PDF or HTML to PPTX) supported?**

Yes. You can add [PDF pages and HTML content](/slides/java/import-presentation/) to a presentation, turning them into slides.
