---
title: Convert Slide
type: docs
weight: 35
url: /java/convert-slide/
---

{{% alert color="primary" %}} 

Conversion of slides to JPEG, GIF, PNG and TIFF is powered by Aspose.Imaging export module.

{{% /alert %}} 

You can convert presentation slides to any graphic image format that Java supports, such as PNG, BMP, JPEG, GIF, etc., 
by using Aspose.Slides API for Java.
Use [getThumbnail](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#getThumbnail--) method of 
[ISlide](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide) interface to convert slide to a [BufferedImage](https://docs.oracle.com/javase/7/docs/api/java/awt/image/BufferedImage.html) object.
Also, you can use [ITiffOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) or [IRenderingOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions) interfaces to set additional options for conversion and convertible slide objects.
These interfaces and their properties are described below in the specialized sections of the article.

## **Convert Slide to BufferedImage**

The code example below shows how to convert the first slide of presentation to a PNG image.

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Convert the first slide of the presentation to a Bitmap object
    BufferedImage bmp = pres.getSlides().get_Item(0).getThumbnail();
    {
        // Save the image in PNG format
        ImageIO.write(bmp, "PNG", new File("Slide_0.png"));
    }
} catch (Exception e) {  
} finally {
    if (pres != null) pres.dispose();
}
```
## **Convert Slide to Image with Custom Size**

Sometimes you need to get an image of a slide of a certain size. 
The following example demonstrates this capability using one of the 
[getThumbnail](https://apireference.aspose.com/slides/java/com.aspose.slides/ISlide#getThumbnail-java.awt.Dimension-) method overloads:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Convert the first slide of the presentation to a Bitmap with the specified size
    BufferedImage bmp = pres.getSlides().get_Item(0).getThumbnail(new Dimension(1820, 1040));
    {
        // Save the image in JPEG format
        ImageIO.write(bmp, "PNG", new File("Slide_0.jpg"));
    }
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert Slide with Notes and Comments to Image**

There are two interfaces [ITiffOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) and [IRenderingOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions), used to control the rendering of presentation slides to images.
Both of these interfaces include the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) interface, which can be used to include notes and comments of a slide in an exporting image.
Using this interface, you can also control the position in which notes and comments will be displayed in the image.
The following example demonstrates the usage of the [INotesCommentsLayoutingOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/INotesCommentsLayoutingOptions) interface using the [IRenderingOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/IRenderingOptions) interface.
An example of ITiffOptions interface usage will be provided below. 

{{% alert title="Note" color="dark" %}} 
When converting slide to an image, the 
[NotesPositions](https://apireference.aspose.com/slides/java/com.aspose.slides/NotesPositions) property cannot be set to [BottomFull](https://apireference.aspose.com/slides/java/com.aspose.slides/NotesPositions#BottomFull) to indicate the location of the notes.
This is since the text of the note can be quite large and it cannot physically fit into the specified image size.

{{% /alert %}} 

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // Create rendering options
    IRenderingOptions options = new RenderingOptions();

    // Set the position of the notes on the page
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // Set the position of the comments on the page
    options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

    // Set the width of the comment output area
    options.getNotesCommentsLayouting().setCommentsAreaWidth(500);

    // Set the color of comments area
    options.getNotesCommentsLayouting().setCommentsAreaColor(Color.LIGHT_GRAY);

    // Convert the first slide of the presentation to a Bitmap object
    BufferedImage bmp = pres.getSlides().get_Item(0).getThumbnail(options, 2f, 2f);

    // Save the image in GIF format
    ImageIO.write(bmp, "GIF", new File("Slide_Notes_Comments_0.gif"));
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert Slide to Image using ITiffOptions Options**

[ITiffOptions](https://apireference.aspose.com/slides/java/com.aspose.slides/ITiffOptions) provides a more complete 
control over the resulting image file.
Using this interface, you can specify the size, resolution, color palette of the resulting image. 
Below is an example of using the ITiffOptions interface to get an image with 300dpi resolution 
and 2160x2880 size:

``` java 
Presentation pres = new Presentation("PresentationNotesComments.pptx");
try {
    // Get a slide by its index
    ISlide slide = pres.getSlides().get_Item(0);

    // Create TiffOptions object
    TiffOptions options = new TiffOptions();
    options.setImageSize(new Dimension(2160, 2880));

    // Set font used in case source font is not found
    options.setDefaultRegularFont("Arial Black");

    // Set the position of the notes on the page
    options.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomTruncated);

    // Set resolution
    options.setDpiX(300);
    options.setDpiY(300);

    // Convert slide to a Tiff image
    pres.save("Slide_Notes_Comments_0.tiff", SaveFormat.Tiff, options);
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convert Presentation to Set of Images**

In some cases, it is necessary to convert the entire presentation into a set of images, 
the same as PowerPoint allows. The following example demonstrates this possibility:

``` java 
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Render presentation to images array slide by slide
    for (int i = 0 ; i < pres.getSlides().size(); i++)
    {
        // Control hidden slides (do not render hidden slides)
        if (pres.getSlides().get_Item(i).getHidden())
            continue;

        // Convert slide to a Bitmap object
        BufferedImage bmp = pres.getSlides().get_Item(i).getThumbnail(2f, 2f);
		
        // Create file name for an image
        String outputFilePath = outputDir + "Slide_" + i + ".jpg";

        // Save the image in PNG format
        ImageIO.write(bmp, "PNG", new File(outputFilePath));
    }
} catch (Exception e) {
} finally {
    if (pres != null) pres.dispose();
} 
```
