---
title: Header Footer
type: docs
weight: 220
url: /net/examples/elements/header-footer/
aliases:
  - /net/examples/elements/elements/header-footer/
keywords:
- header footer
- add header footer
- update header footer
- code example
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Control slide headers and footers with Aspose.Slides for .NET: add dates, slide numbers, and custom text in PPT, PPTX, and ODP with C# examples."
---

This article demonstrates how to add footers and update date and time placeholders using **Aspose.Slides for .NET**.

Copy a C# block into `Program.cs` in a .NET project with `Aspose.Slides.NET6.CrossPlatform` installed. Each block is a complete program. Run one block at a time. The ZIP contains the IDE-ready project and its verification checks.

## Download and run

[Download the complete project](example.zip), extract it, and open `Example.sln` or run:

```console
dotnet restore Example.sln
dotnet run --project Example.csproj -- --mode evaluation
```

The download includes every case below, its fixture helpers and inputs. `Program.cs` runs all cases; use `--action block-001` to run one independently. Outputs and an action report are written to the printed output directory. No previous example or working-directory setup is required. Evaluation adds a watermark and can truncate read-back text; the short fixtures still have explicit structural checks. For full text and no watermark, use `--mode licensed --license PATH` with your own valid license. See the [setup guide](/slides/net/examples/getting-started/) for supported SDKs and native prerequisites.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
slide.HeaderFooterManager.SetFooterText("Foot");

presentation.Save("header-footer-01.pptx", SaveFormat.Pptx);
```

## **Update Date and Time**

Modify the date and time placeholder on a slide.

```csharp
using Aspose.Slides.Export;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
slide.HeaderFooterManager.SetDateTimeText("Today");

presentation.Save("header-footer-02.pptx", SaveFormat.Pptx);
```
