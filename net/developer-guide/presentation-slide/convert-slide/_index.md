---
title: Convert Slide
type: docs
weight: 41
url: /net/convert-slide/
---

Aspose.Slides for .NET allows you to convert slides (in presentations) to images. These are the supported image formats: BMP, PNG, JPG (JPEG), GIF, and others. 

To convert a slide to an image, convert the slide to a Bitmap first—use the [GetThumbnail](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) method from the [ISlide](https://apireference.aspose.com/slides/net/aspose.slides/islide) interface. Then you can use [ITiffOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/itiffoptions) or [IRenderingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/irenderingoptions) interfaces to set additional options for conversion and convertible slide objects.

## About Bitmap and Other Image Formats

In general, a bitmap is a memory organization or image file format for storing digital images (rasters mostly). Bitmap is one of the oldest and purest formats for digital images. Bitmap is the base platform for many other file types or formats used to store digital images.  

In .NET, a [bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) is an object that allows you to work with images defined by pixel data. BMP is Microsoft's preferred format for bitmap images in Windows. However, you may have to work with other image formats.

- A **bitmap** is a true image since it renders every pixel individually. It takes up a lot of space, so it is rarely used directly in applications or on the web.
- **PNG** (Portable Network Graphics) is a raster graphics file format based on a bitmap image. PNG is widely accepted. It is often used in different applications and on the web. 

## **Converting Slides to Bitmap and Saving the Images in PNG**

This C# code shows you how to convert the first slide of a presentation to a bitmap object and then how to then save the image in the PNG format:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Convert the first slide of the presentation to a Bitmap object
    using (Bitmap bmp = pres.Slides[0].GetThumbnail())
    {

        // Save the image in PNG format
        bmp.Save("Slide_0.png", ImageFormat.Png);
    }
}
```
{{% alert title="TIP" color="green" %}} 

You can convert a slide to a bitmap object and then use the object directly somewhere. Or you can convert a slide to a bitmap and then save the image in JPEG or any other format you prefer. 

{{% /alert %}}  

## **Converting Slides to Images with Custom Sizes**

You may need to get an image with a certain size. Through one of the [GetThumbnail](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) method overloads, you can convert a slide to an image with specific dimensions (length and width). 

This sample code demonstrates the proposed conversion in C#:

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Convert the first slide of the presentation to a Bitmap with the specified size
    using (Bitmap bmp = pres.Slides[0].GetThumbnail(new Size(1820, 1040)))
    {
        // Save the image in JPEG format
        bmp.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Converting Slides With Notes and Comments to Images**

Some slides contain notes and comments. 

Aspose.Slides provides two interfaces— [ITiffOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/itiffoptions) and [IRenderingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)—that allow you to control the rendering of presentation slides to images. Both interfaces house the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) interface that allows you to add notes and comments on a slide when you are converting that slide to an image.

{{% alert title="TIP" color="green" %}} 

With the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) interface, you get to specify your preferred position for notes and comments in the resulting image. 

{{% /alert %}} 

This C# code demonstrates the conversion process for a slide with notes and comments:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Create rendering options
    IRenderingOptions options = new RenderingOptions();
                
    // Set the position of the notes on the page
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;
                
    // Set the position of the comments on the page 
    options.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

    // Set the width of the comment output area
    options.NotesCommentsLayouting.CommentsAreaWidth = 500;
                
    // Set the color of comments area
    options.NotesCommentsLayouting.CommentsAreaColor = Color.AntiqueWhite;
                
    // Convert the first slide of the presentation to a Bitmap object
    Bitmap bmp = pres.Slides[0].GetThumbnail(options, 2f, 2f);

    // Save the image in GIF format
    bmp.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
}
```

{{% alert title="NOTE" color="green" %}} 

In any slide to image conversion process, the [NotesPositions](https://apireference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) property cannot be set to BottomFull (to specify the position for notes) because a note's text may be large, which means it might not fit into the specified image size. 

{{% /alert %}} 

## **Converting Slides to Images Using ITiffOptions **

The [ITiffOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/itiffoptions) interface gives you more control (in terms of parameters) over the resulting image. Using this interface, you get to specify the size, resolution, color palette, and other parameters for the resulting image. 

This C# code demonstrates a conversion process where ITiffOptions is used to output a black and white image with a 300dpi resolution and 2160 × 2800 size:

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Get a slide by its index
    ISlide slide = pres.Slides[0];

    // Create TiffOptions object
    TiffOptions options = new TiffOptions() {ImageSize = new Size(2160, 2880)};

    // Set font used in case source font is not found
    options.DefaultRegularFont = "Arial Black";

    // Set the position of the notes on the page 
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Set pixel format (black and white)
    options.PixelFormat = ImagePixelFormat.Format1bppIndexed;

    // Set resolution
    options.DpiX = 300;
    options.DpiY = 300;

    // Convert slide to a Bitmap object
    using (Bitmap bmp = slide.GetThumbnail(options))
    {
        // Save the image in BMP format
        bmp.Save("PresentationNotesComments.bmp", ImageFormat.Tiff);
    }
}  
```

## **Converting All Slides to Images**

Aspose.Slides allows you to convert all slides in a single presentation to images. Essentially, you get to convert the presentation (in its entirety) to images. 

This sample code shows you how to convert all slides in a presentation to images in C#:

``` csharp 
// Path to output directory
string outputDir = @"D:\PresentationImages";

using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Render presentation to images array slide by slide
    for (int i = 0 ; i < pres.Slides.Count ; i++)
    {
        // Control hidden slides (do not render hidden slides)
        if (pres.Slides[i].Hidden)
            continue;

        // Convert slide to a Bitmap object
        using (Bitmap bmp = pres.Slides[i].GetThumbnail(2f, 2f))
        {
            // Create file name for an image
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // Save the image in PNG format
            bmp.Save(outputFilePath, ImageFormat.Png);
        }
    }
} 
```
