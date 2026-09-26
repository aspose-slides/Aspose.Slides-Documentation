---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /net/
keywords:
- documentation
- presentation processing
- presentation conversion
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Start here: install Aspose.Slides for .NET, create a first presentation, and find the guides for common tasks, the API reference and support."
is_root: true
---

<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET is a class library for creating, reading, editing and converting PowerPoint and OpenDocument presentations in .NET applications, without Microsoft PowerPoint or Office Automation.

It loads and saves PPT, PPTX, PPS, POT and ODP, including macro-enabled and template variants, and exports to PDF, XPS, HTML, SVG, TIFF, Markdown and images.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Get Started</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/net/installation/">Installation</a></li>
<li><a href="/slides/net/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/net/getting-started/">Getting started guide</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/net/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/net/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/net/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Build with Slides</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/net/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/net/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/net/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/net/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/net/manage-text/">Edit text and shapes</a></li>
</ul>
<p>SLIDES WORKFLOWS</p>
<ul>
<li><a href="/slides/net/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/net/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/net/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/net/presentation-design/">Slide design</a></li>
<li><a href="/slides/net/merge-presentation/">Merge presentations</a></li>
</ul>
<p>EXAMPLES</p>
<ul>
<li><a href="/slides/net/examples/">Examples by slide element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">Examples on GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Reference &amp; Support</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Release notes</a></li>
<li><a href="/slides/net/known-issues/">Known issues</a></li>
<li><a href="https://releases.aspose.com/slides/net/">Download</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

## **Your first presentation**

Create a console application with the .NET SDK 6 or later:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Then add one package for your platform:

- On Windows: `dotnet add package Aspose.Slides.NET`
- On Linux and macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — see [Installation](/slides/net/installation/) for the Linux prerequisite and for the systems that need Aspose.Slides.NET instead.

Replace the contents of *Program.cs* with this code and run `dotnet run`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

The program saves *hello.pptx* with one slide holding a text box. Without a license, the saved file carries an evaluation watermark — see [Licensing](/slides/net/licensing/). For more ways to create and fill a presentation, see [Create Presentations](/slides/net/create-presentation/).
