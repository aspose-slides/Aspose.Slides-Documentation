---
title: Get Warning Callbacks for Font Substitution
type: docs
weight: 120
url: /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- warning callback
- font substitution
- rendering process
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Learn to get warning callbacks for font substitution in Aspose.Slides for .NET and display PowerPoint and OpenDocument presentations accurately."
---

## **Overview**

Aspose.Slides for .NET allows you to receive warning callbacks for font substitution when a required font isn’t available on the machine during rendering. These callbacks help diagnose issues with missing or inaccessible fonts.

## **Enable Warning Callbacks**

Aspose.Slides for .NET provides straightforward APIs for receiving warning callbacks when rendering presentation slides. Follow these steps to configure warning callbacks:

1. Create a custom callback class that implements the [IWarningCallback](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarningcallback/) interface to handle warnings.
1. Set the warning callback using option classes such as [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), and others.
1. Load a presentation that uses a font not available on the target machine.
1. Generate a slide thumbnail or export the presentation to observe the effect.

**Custom Warning Callback Class:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Example output:
//
// Font will be substituted from XYZ to {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Generate a Slide Thumbnail:**

```c#
// Set up a warning callback to handle font-related warnings during slide rendering.
RenderingOptions options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Load the presentation from the specified file path.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Generate a thumbnail image for each slide in the presentation.
    foreach (ISlide slide in presentation.Slides)
    {
        // Get the slide thumbnail image using the specified rendering options.
        IImage image = slide.GetImage(options);
        // ...
    }
}
```

**Export to PDF Format:**

```c#
// Set up a warning callback to handle font-related warnings during PDF export.
SaveOptions options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Load the presentation from the specified file path.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Export the presentation as PDF.
    using (MemoryStream stream = new MemoryStream())
    {
        presentation.Save(stream, SaveFormat.Pdf, options);
        // ...
    }
}
```

**Export to HTML Format:**

```c#
// Set up a warning callback to handle font-related warnings during HTML export.
SaveOptions options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Load the presentation from the specified file path.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Export the presentation in HTML format.
    using (MemoryStream stream = new MemoryStream())
    {
        presentation.Save(stream, SaveFormat.Html, options);
        // ...
    }
}
```
