---
title: HeaderFooter
type: docs
weight: 220
url: /net/examples/elements/elements/header-footer/
keywords:
- header footer example
- add header footer
- update header footer
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Control headers and footers in C# with Aspose.Slides: add or edit date/time, slide numbers, and footer text, show or hide placeholders across PPT, PPTX and ODP."
---

Shows how to add footers and update date and time placeholders using **Aspose.Slides for .NET**.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

```csharp
static void Add_Header_Footer()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Update Date and Time**

Modify the date and time placeholder on a slide.

```csharp
static void Update_Date_Time()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
