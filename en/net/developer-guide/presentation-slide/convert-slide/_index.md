---
title: Convert Slide
type: docs
weight: 41
url: /net/convert-slide/
keywords: 
- convert slide to image
- export slide as image
- save slide as image
- slide to image
- slide to PNG
- slide to JPEG
- slide to bitmap
- C#
- Csharp
- .NET
- Aspose.Slides for .NET
description: "Convert PowerPoint slides to images (bitmap, PNG, or JPG) in C# or .NET"
---

Aspose.Slides for .NET allows you to convert slides (in presentations) to images. These are the supported image formats: BMP, PNG, JPG (JPEG), GIF, and others. 

To convert a slide to an image, do this: 

1. First, set the conversion parameters and the slide objects to convert using:
   * the [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) interface or
   * the [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions) interface. 

2. Second, convert the slide to an image by using the [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) method.

## **About Bitmap and Other Image Formats**

In .NET, a [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (BMP, JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose recently developed an online [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter. 

{{% /alert %}}

## **Converting Slides to Bitmap and Saving the Images in PNG**

This C# code shows you how to convert the first slide of a presentation to a bitmap object and then how to then save the image in the PNG format:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Converts the first slide in the presentation to a Bitmap object
    using (IImage image = pres.Slides[0].GetImage())
    {
        // Saves the image in the PNG format
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="Tip" color="primary" %}} 

You can convert a slide to a bitmap object and then use the object directly somewhere. Or you can convert a slide to a bitmap and then save the image in JPEG or any other format you prefer. 

{{% /alert %}}  

## **Converting Slides to Images with Custom Sizes**

You may need to get an image of a certain size. Using an overload from the [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/), you can convert a slide to an image with specific dimensions (length and width). 

This sample code demonstrates the proposed conversion using the [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) method in C#:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Converts the first slide in the presentation to a Bitmap with the specified size
    using (IImage image = pres.Slides[0].GetImage(new Size(1820, 1040)))
    {
        // Saves the image in the JPEG format
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Converting Slides With Notes and Comments to Images**

Some slides contain notes and comments. 

Aspose.Slides provides two interfaces—[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) and [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)—that allow you to control the rendering of presentation slides to images. Both interfaces include the [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) property, which allows you to configure the rendering of notes and comments on a slide when converting it to an image.

{{% alert title="Info" color="info" %}} 

With the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/#notescommentslayoutingoptions-class) class, you get to specify your preferred position for notes and comments in the resulting image. 

{{% /alert %}} 

This C# code demonstrates the conversion process for a slide with notes and comments:

``` csharp 
// Load the presentation
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Creates the rendering options
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,      // Sets the position of the notes
            CommentsPosition = CommentsPositions.Right,          // Sets the position of the comments
            CommentsAreaWidth = 500,                             // Sets the width of the comments area
            CommentsAreaColor = Color.AntiqueWhite               // Sets the color for the comments area
        }
    };

    // Converts the first slide of the presentation to an image
    using (IImage image = pres.Slides[0].GetImage(options, 2f, 2f))
    {
        // Saves the image in the GIF format
        image.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 

In any slide to image conversion process, the [NotesPositions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) property cannot be set to BottomFull (to specify the position for notes) because a note's text may be large, which means it might not fit into the specified image size. 

{{% /alert %}} 

## **Converting Slides to Images Using ITiffOptions**

The [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) interface gives you more control (in terms of parameters) over the resulting image. Using this interface, you get to specify the size, resolution, color palette, and other parameters for the resulting image. 

This C# code demonstrates a conversion process where ITiffOptions is used to output a black and white image with a 300dpi resolution and 2160 × 2800 size:

``` csharp 
// Load the presentation
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Gets the first slide from the presentation
    ISlide slide = pres.Slides[0];

    // Creates rendering options with layout settings
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated // Sets the position of the notes
        },
        DefaultRegularFont = "Arial Black" // Sets the default font if source font is not found
    };

    // Configures the output image settings
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                 // Sets the image size
        PixelFormat = ImagePixelFormat.Format1bppIndexed, // Sets the pixel format (black and white)
        DpiX = 300,                                       // Sets the horizontal resolution
        DpiY = 300                                        // Sets the vertical resolution
    };

    // Converts the slide to an image
    using (IImage image = slide.GetImage(options))
    {
        // Saves the image in TIFF format with the specified options
        image.Save("PresentationNotesComments.tiff", tiffOptions);
    }
}
```

## **Converting All Slides to Images**

Aspose.Slides allows you to convert all slides in a single presentation to images. Essentially, you get to convert the presentation (in its entirety) to images. 

This sample code shows you how to convert all slides in a presentation to images in C#:

```csharp
// Specifies the path to the output directory
string outputDir = @"D:\PresentationImages";

using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Renders presentation to images array slide by slide
    for (int i = 0; i < pres.Slides.Count; i++)
    {
        // Specifies the setting for hidden slides (do not render hidden slides)
        if (pres.Slides[i].Hidden)
            continue;

        // Converts the slide to a Bitmap object
        using (IImage image = pres.Slides[i].GetImage(2f, 2f))
        {
            // Creates a file name for an image
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // Saves the image in the JPEG format
            image.Save(outputFilePath, ImageFormat.Jpeg);
        }
    }
}
```

