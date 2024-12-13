---
title: Getting Warning Callbacks for Fonts Substitution in Aspose.Slides
type: docs
weight: 120
url: /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for .NET makes it possible to get warning callbacks for fonts substitution in case the used font is not available on machine during rendering process. The warning callbacks are helpful in debugging the issues of missing or inaccessible fonts during rendering process.

{{% /alert %}} 
## **Getting Warning Callbacks for Fonts substitution**
Aspose.Slides for .NET provides simple API methods to get warning callbacks during the rendering process. Follow the steps below to configure warning callbacks on your end:

1. Create a custom callback class to receive the warnings.
1. Set the warning callback using classes such as [**RenderingOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions), [**PdfOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions), [**HtmlOptions**](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions), and others.
1. Load a presentation file that uses a font unavailable on your target machine.
1. Generate a slide thumbnail or export the presentation to see the effect.

`Generate a Slide Thumbnail:`
```c#
// Set up warning callbacks to handle font-related warnings during image generation.
RenderingOptions options = new RenderingOptions();
options.WarningCallback = new HandleFontsWarnings();

// Load the presentation from the specified file path.
Presentation presentation = new Presentation("sample.pptx");

// Generate thumbnail images for each slide in the presentation.
foreach (ISlide slide in presentation.Slides)
{
    // Get the slide thumbnail as an image using the specified rendering options.
    IImage image = slide.GetImage(options);
}
```

`Export to PDF Format:`
```c#
// Set up warning callbacks to handle font-related warnings during PDF export.
SaveOptions options = new PdfOptions();
options.WarningCallback = new HandleFontsWarnings();

// Load the presentation from the specified file path.
Presentation presentation = new Presentation("sample.pptx");

// Export the presentation to a PDF format.
using (MemoryStream stream = new MemoryStream())
	presentation.Save(stream, SaveFormat.Pdf, options);
```

`Export to HTML Format:`
```c#
// Set up warning callbacks to handle font-related warnings during HTML export.
SaveOptions options = new HtmlOptions();
options.WarningCallback = new HandleFontsWarnings();

// Load the presentation from the specified file path.
Presentation presentation = new Presentation("sample.pptx");

// Export the presentation to an HTML format.
using (MemoryStream stream = new MemoryStream())
    presentation.Save(stream, SaveFormat.Html, options);
```

`Custom Warning Callback Class:`
```c#
class HandleFontsWarnings : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        Console.WriteLine(warning.WarningType); // 1 - WarningType.DataLoss
        Console.WriteLine(warning.Description); // "Font will be substituted from X to Y"
        return ReturnAction.Continue;
    }
}
```



