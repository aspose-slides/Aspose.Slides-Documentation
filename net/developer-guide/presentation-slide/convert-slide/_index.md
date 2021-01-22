---
title: Convert Slide
type: docs
weight: 41
url: /net/convert-slide/
---

You can convert presentation slides to any graphic image format that .NET supports, such as PNG, BMP, JPEG, GIF, etc., 
by using Aspose.Slides API for .NET.
Use [GetThumbnail](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) method of 
[ISlide](https://apireference.aspose.com/slides/net/aspose.slides/islide) interface to convert slide to a [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=dotnet-plat-ext-5.0) object.
Also, you can use [ITiffOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/itiffoptions) or [IRenderingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/irenderingoptions) interfaces to set additional options for conversion and convertible slide objects.
These interfaces and their properties are described below in the specialized sections of the article.

## **Convert Slide to Bitmap**

The code example below shows how to convert the first slide of presentation to a PNG image.

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Convert the first slide of the presentation to a Bitmap object
    Bitmap bmp = pres.Slides[0].GetThumbnail();

    // Save the image in PNG format
    bmp.Save("Slide_0.png", ImageFormat.Png);
}
```
## **Convert Slide to Image with Custom Size**

Sometimes you need to get an image of a slide of a certain size. 
The following example demonstrates this capability using one of the 
[GetThumbnail](https://apireference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) method overloads:

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

## **Convert Slide with Notes and Comments to Image**

There are two interfaces [ITiffOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/itiffoptions) and [IRenderingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/irenderingoptions), used to control the rendering of presentation slides to images.
Both of these interfaces include the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) interface, which can be used to include notes and comments of a slide in an exporting image.
Using this interface, you can also control the position in which notes and comments will be displayed in the image.
The following example demonstrates the usage of the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) interface using the [IRenderingOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/irenderingoptions) interface.
An example of ITiffOptions interface usage will be provided below. 

{{% alert title="Note" color="dark" %}} 
When converting slide to an image, the 
[NotesPositions](https://apireference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) property cannot be set to [BottomFull](https://apireference.aspose.com/slides/net/aspose.slides.export/notespositions) to indicate the location of the notes.
This is since the text of the note can be quite large and it cannot physically fit into the specified image size.

{{% /alert %}} 

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

## **Convert Slide to Image using ITiffOptions Options**

[ITiffOptions](https://apireference.aspose.com/slides/net/aspose.slides.export/itiffoptions) provides a more complete 
control over the resulting image file.
Using this interface, you can specify the size, resolution, color palette of the resulting image. 
Below is an example of using the ITiffOptions interface to get a black and white image with 300dpi resolution 
and 2160x2880 size:

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

## **Convert Presentation to Image Array**

In some cases, it is necessary to convert the entire presentation into a set of images, 
the same as PowerPoint allows. The following example demonstrates this possibility:

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
  
