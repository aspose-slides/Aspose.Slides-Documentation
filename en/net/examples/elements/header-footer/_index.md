---
title: Header Footer
type: docs
weight: 220
url: /net/examples/elements/elements/headerfooter/
keywords:
- code example
- header
- footer
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Control slide headers and footers with Aspose.Slides for .NET: add dates, slide numbers, and custom text in PPT, PPTX, and ODP with C# examples."
---

This article demonstrates how to add footers and update date and time placeholders using **Aspose.Slides for .NET**.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Update Date and Time**

Modify the date and time placeholder on a slide.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
