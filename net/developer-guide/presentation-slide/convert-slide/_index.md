---
title: Convert Slide
type: docs
weight: 41
url: /net/convert-slide/
---

Aspose.Slides for .NET allows you to convert slides (in presentations) to images. These are the supported image formats: BMP, PNG, JPG (JPEG), GIF, and others. 

To convert a slide to an image, do this: 

1. First,
   * convert the slide to a Bitmap first by using the [GetThumbnail](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) method or
   * render the slide to a Graphics object by using the [RenderToGraphics](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index) method from the [ISlide](https://apireference.aspose.com/slides/net/aspose.slides/islide) interface.

2. Second, set additional options for conversion and convertible slide objects through
   * the [ITiffOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/itiffoptions) interface or
   * the [IRenderingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/irenderingoptions) interface. 

## **About Bitmap and Other Image Formats**

In .NET, a [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (BMP, JPG, PNG, etc.).

## **Converting Slides to Bitmap and Saving the Images in PNG**

This C# code shows you how to convert the first slide of a presentation to a bitmap object and then how to then save the image in the PNG format:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Converts the first slide in the presentation to a Bitmap object
    using (Bitmap bmp = pres.Slides[0].GetThumbnail())
    {
        // Saves the image in the PNG format
        bmp.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

This sample code shows you how to convert the first slide of a presentation to a bitmap object using the [RenderToGraphics](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index) method:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Gets the presentation slide size
    Size slideSize = pres.SlideSize.Size.ToSize();

    // Creates a Bitmap with the slide size
    using (Bitmap slideImage = new Bitmap(slideSize.Width, slideSize.Height))
    {
        // Renders the first slide to the Graphics object
        using (Graphics graphics = Graphics.FromImage(slideImage))
        {
            pres.Slides[0].RenderToGraphics(new RenderingOptions(), graphics);
        }

        slideImage.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="Tip" color="primary" %}} 

You can convert a slide to a bitmap object and then use the object directly somewhere. Or you can convert a slide to a bitmap and then save the image in JPEG or any other format you prefer. 

{{% /alert %}}  

## **Converting Slides to Images with Custom Sizes**

You may need to get an image of a certain size. Using an overload from the [GetThumbnail](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) or [RenderToGraphics](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index) method, you can convert a slide to an image with specific dimensions (length and width). 

This sample code demonstrates the proposed conversion using the [GetThumbnail](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) method in C#:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Converts the first slide in the presentation to a Bitmap with the specified size
    using (Bitmap bmp = pres.Slides[0].GetThumbnail(new Size(1820, 1040)))
    {
        // Saves the image in the JPEG format
        bmp.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

This C# code demonstrates how to convert the first slide to the framed image with the [RenderToGraphics](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index) method:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    Size slideSize = new Size(1820, 1040);

    // Creates a Bitmap with the specified size (slide size + fields)
    using (Bitmap slideImage = new Bitmap(slideSize.Width + 50, slideSize.Height + 50))
    {
        using (Graphics graphics = Graphics.FromImage(slideImage))
        {
            // Fills and translates Graphics to create a frame around the slide
            graphics.Clear(Color.Red);
            graphics.TranslateTransform(25f, 25f);

            // Renders the first slide to Graphics
            pres.Slides[0].RenderToGraphics(new RenderingOptions(), graphics, slideSize);
        }

        // Saves the image in the JPEG format
        slideImage.Save("FramedSlide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Converting Slides With Notes and Comments to Images**

Some slides contain notes and comments. 

Aspose.Slides provides two interfaces—[ITiffOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/itiffoptions) and [IRenderingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)—that allow you to control the rendering of presentation slides to images. Both interfaces house the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) interface that allows you to add notes and comments on a slide when you are converting that slide to an image.

{{% alert title="Info" color="info" %}} 

With the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) interface, you get to specify your preferred position for notes and comments in the resulting image. 

{{% /alert %}} 

This C# code demonstrates the conversion process for a slide with notes and comments:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Creates the rendering options
    IRenderingOptions options = new RenderingOptions();
                
    // Sets the position of the notes on the page
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;
                
    // Sets the position of the comments on the page 
    options.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

    // Sets the width of the comment output area
    options.NotesCommentsLayouting.CommentsAreaWidth = 500;
                
    // Sets the color for the comments area
    options.NotesCommentsLayouting.CommentsAreaColor = Color.AntiqueWhite;
                
    // Converts the first slide of the presentation to a Bitmap object
    Bitmap bmp = pres.Slides[0].GetThumbnail(options, 2f, 2f);

    // Saves the image in the GIF format
    bmp.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
}
```

This C# code demonstrates the conversion process for a slide with notes using the [RenderToGraphics](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index) method:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotes.pptx"))
{
    // Gets the presentation notes size
    Size notesSize = pres.NotesSize.Size.ToSize();

    // Creates the rendering options
    IRenderingOptions options = new RenderingOptions();

    // Sets the position of the notes
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Creates a Bitmap with the notes' size
    using (Bitmap slideImage = new Bitmap(notesSize.Width, notesSize.Height))
    {
        // Renders the first slide to Graphics
        using (Graphics graphics = Graphics.FromImage(slideImage))
        {
            pres.Slides[0].RenderToGraphics(options, graphics, notesSize);
        }

        // Saves the image in PNG format
        slideImage.Save("Slide_Notes_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="Note" color="warning" %}} 

In any slide to image conversion process, the [NotesPositions](https://apireference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) property cannot be set to BottomFull (to specify the position for notes) because a note's text may be large, which means it might not fit into the specified image size. 

{{% /alert %}} 

## **Converting Slides to Images Using ITiffOptions**

The [ITiffOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/itiffoptions) interface gives you more control (in terms of parameters) over the resulting image. Using this interface, you get to specify the size, resolution, color palette, and other parameters for the resulting image. 

This C# code demonstrates a conversion process where ITiffOptions is used to output a black and white image with a 300dpi resolution and 2160 × 2800 size:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Gets a slide by its index
    ISlide slide = pres.Slides[0];

    // Creates a TiffOptions object
    TiffOptions options = new TiffOptions() {ImageSize = new Size(2160, 2880)};

    // Set the font used in case source font is not found
    options.DefaultRegularFont = "Arial Black";

    // Set the position of the notes on the page 
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Sets the pixel format (black and white)
    options.PixelFormat = ImagePixelFormat.Format1bppIndexed;

    // Sets the resolution
    options.DpiX = 300;
    options.DpiY = 300;

    // Converts the slide to a Bitmap object
    using (Bitmap bmp = slide.GetThumbnail(options))
    {
        // Saves the image in BMP format
        bmp.Save("PresentationNotesComments.tiff", ImageFormat.Tiff);
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
    for (int i = 0 ; i < pres.Slides.Count ; i++)
    {
        // Specifies the setting for hidden slides (do not render hidden slides)
        if (pres.Slides[i].Hidden)
            continue;

        // Converts the slide to a Bitmap object
        using (Bitmap bmp = pres.Slides[i].GetThumbnail(2f, 2f))
        {
            // Creates a file name for an image
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // Saves the image in the JPEG format
            bmp.Save(outputFilePath, ImageFormat.Jpeg);
        }
    }
} 
```

