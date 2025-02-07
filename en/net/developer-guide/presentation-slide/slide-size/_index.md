---
title: Customize Slide Size
linktitle: Slide Size
type: docs
weight: 70
url: /net/slide-size/
keywords: "Set slide size, customize presentation dimensions, PowerPoint aspect ratio, C#, Csharp, .NET, Aspose.Slides"
description: "Learn how to customize and adjust slide sizes or aspect ratios in PowerPoint using C# or .NET with Aspose.Slides."
---

## Customizing Slide Sizes and Aspect Ratios in PowerPoint

Aspose.Slides for .NET provides comprehensive tools to adjust the slide size and aspect ratio in PowerPoint presentations, critical for both printing and on-screen display. 

### Popular Slide Sizes and Ratios:

- **Standard (4:3 Aspect Ratio)**: Ideal for older screens and devices.
  
- **Widescreen (16:9 Aspect Ratio)**: Recommended for modern projectors and displays.

Ensure consistency throughout your presentation as a single slide size and aspect ratio apply to all slides. For optimal results, set your slide dimensions at the beginning of your presentation creation process to avoid complications.

{{% alert color="primary" %}} 
By default, presentations created with Aspose.Slides use the standard 4:3 aspect ratio.
{{% /alert %}}

## How to Change Slide Size in PowerPoint

This example demonstrates changing a presentation's slide size with Aspose.Slides in C#:

```csharp
using (Presentation pres = new Presentation("presentation-4x3.pptx"))
{
    pres.SlideSize.SetSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale);
    pres.Save("presentation-16x9.pptx", SaveFormat.Pptx);
}
```

## Specify Custom Slide Sizes

Tailoring the slide size to your specific needs, such as for unique paper layouts or screen specifications, can be beneficial. Here's how to set a custom slide size with Aspose.Slides for .NET:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
    pres.SlideSize.SetSize(780, 540, SlideSizeScaleType.DoNotScale); // A4 paper size
    pres.Save("presentation-a4.pptx", SaveFormat.Pptx);
}
```

## Handling Slide Content After Resizing

Post-resizing, slide contents may distort. You can control how Aspose.Slides manages this resizing:

- **`DoNotScale`**: Keep objects at original sizes to avoid scaling.
- **`EnsureFit`**: Scale objects to fit smaller slides, preventing content loss.
- **`Maximize`**: Enlarge objects to suit larger slides for aesthetic consistency.

Example of using `Maximize` setting for slide size adjustment:

```csharp
using (Presentation pres = new Presentation("presentation.pptx"))
{
   pres.SlideSize.SetSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize);
}
```