---
title: Convert Slide
type: docs
weight: 41
url: /cpp/convert-slide/
keywords: 
- convert slide to image
- export slide as image
- save slide as image
- slide to image
- slide to PNG
- slide to JPEG
- slide to bitmap
- C++
- Aspose.Slides for C++
description: "Convert PowerPoint slide to image (Bitmap, PNG, or JPG) in C++"
---

Aspose.Slides for C++ allows you to convert slides (in presentations) to images. These are the supported image formats: BMP, PNG, JPG (JPEG), GIF, and others. 

To convert a slide to an image, do this: 

1. First, set the conversion parameters and the slide objects to convert using:
   * the [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) interface or
   * the [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options) interface. 

2. Second, convert the slide to an image by using the [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) method.

## **About Bitmap and Other Image Formats**

A [Bitmap](https://reference.aspose.com/slides/cpp/class/system.drawing.bitmap) is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (BMP, JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose recently developed an online [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter. 

{{% /alert %}}

## **Converting Slides to Bitmap and Saving the Images in PNG**

This C++ code shows you how to convert the first slide of a presentation to a bitmap object and then how to then save the image in the PNG format:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide of the presentation to a Bitmap object
System::SharedPtr<IImage> image = pres->get_Slide(0)->GetImage();
                 
// Save the image in PNG format
image->Save(u"Slide_0.png", ImageFormat::Png);
```

{{% alert title="Tip" color="primary" %}} 

You can convert a slide to a bitmap object and then use the object directly somewhere. Or you can convert a slide to a bitmap and then save the image in JPEG or any other format you prefer. 

{{% /alert %}}  

## **Converting Slides to Images with Custom Sizes**

You may need to get an image of a certain size. Using an overload from the [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/), you can convert a slide to an image with specific dimensions (length and width). 

This sample code demonstrates the proposed conversion using the [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) method in C++:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");
// Converts the first slide in the presentation to a Bitmap with the specified size
auto image = pres->get_Slide(0)->GetImage(Size(1820, 1040));
// Saves the image in the JPEG format
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);
```

## **Converting Slides With Notes and Comments to Images**

Some slides contain notes and comments. 

Aspose.Slides provides two interfaces—[ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) and [IRenderingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_rendering_options)—that allow you to control the rendering of presentation slides to images. Both interfaces house the [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) interface that allows you to add notes and comments on a slide when you are converting that slide to an image.

{{% alert title="Info" color="info" %}} 

With the [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) interface, you get to specify your preferred position for notes and comments in the resulting image. 

{{% /alert %}} 

This C++ code demonstrates the conversion process for a slide with notes and comments:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");
// Creates the rendering options
auto options = System::MakeObject<RenderingOptions>();
auto notesCommentsLayouting = options->get_NotesCommentsLayouting();
// Sets the position of the notes on the page
notesCommentsLayouting->set_NotesPosition(NotesPositions::BottomTruncated);
// Sets the position of the comments on the page 
notesCommentsLayouting->set_CommentsPosition(CommentsPositions::Right);
// Sets the width of the comment output area
notesCommentsLayouting->set_CommentsAreaWidth(500);
// Sets the color for the comments area
notesCommentsLayouting->set_CommentsAreaColor(Color::get_AntiqueWhite());

// Converts the first slide of the presentation to a Bitmap object
auto image = pres->get_Slide(0)->GetImage(options, 2.f, 2.f);

// Saves the image in the GIF format
image->Save(u"Slide_Notes_Comments_0.gif", ImageFormat::Gif);
```

{{% alert title="Note" color="warning" %}} 

In any slide to image conversion process, you cannot pass the BottomFull value (to specify the position for notes) to the [set_NotesPositions()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) method because a note's text may be large, which means it might not fit into the specified image size. 

{{% /alert %}} 

## **Converting Slides to Images Using ITiffOptions**

The [ITiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_tiff_options) interface gives you more control (in terms of parameters) over the resulting image. Using this interface, you get to specify the size, resolution, color palette, and other parameters for the resulting image. 

This C++ code demonstrates a conversion process where ITiffOptions is used to output a black and white image with a 300dpi resolution and 2160 × 2800 size:

``` cpp 
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"PresentationNotesComments.pptx");

// Get a slide by its index
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Create TiffOptions object
System::SharedPtr<TiffOptions> options = System::MakeObject<TiffOptions>();
options->set_ImageSize(Size(2160, 2880));

// Set font used in case source font is not found
options->set_DefaultRegularFont(u"Arial Black");

// Set the position of the notes on the page 
options->get_NotesCommentsLayouting()->set_NotesPosition(NotesPositions::BottomTruncated);

// Set pixel format (black and white)
options->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);

// Set resolution
options->set_DpiX(300);
options->set_DpiY(300);

// Convert slide to a Bitmap object
System::SharedPtr<Bitmap> image = slide->GetImage(options);

// Save the image in BMP format
image->Save(u"PresentationNotesComments.bmp", ImageFormat::Tiff);
```

## **Converting All Slides to Images**

Aspose.Slides allows you to convert all slides in a single presentation to images. Essentially, you get to convert the presentation (in its entirety) to images. 

This sample code shows you how to convert all slides in a presentation to images in C++:

``` cpp 
// Path to output directory
System::String outputDir = u"D:\\PresentationImages";

auto pres = System::MakeObject<Presentation>(u"Presentation.pptx");

// Render presentation to images array slide by slide
for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
{
    // Control hidden slides (do not render hidden slides)
    if (pres->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Convert slide to a Bitmap object
    auto image = pres->get_Slide(i)->GetImage(2.f, 2.f);

    // Create file name for an image
    auto outputFilePath = Path::Combine(outputDir, String(u"Slide_") + i + u".jpg");

    // Save the image in PNG format
    image->Save(outputFilePath, ImageFormat::Png);
}
```

