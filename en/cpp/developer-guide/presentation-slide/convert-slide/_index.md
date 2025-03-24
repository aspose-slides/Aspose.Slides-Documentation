---
title: Convert PowerPoint Slides to Images in C++
linktitle: Slide to Image
type: docs
weight: 41
url: /cpp/convert-slide/
keywords: 
- convert slide
- convert slide to image
- export slide as image
- save slide as image
- slide to image
- slide to PNG
- slide to JPEG
- slide to bitmap
- C++
- Aspose.Slides
description: "Learn how to convert PowerPoint and OpenDocument slides into various formats using Aspose.Slides for C++. Easily export PPTX and ODP slides to BMP, PNG, JPEG, TIFF, and more with high-quality results."
---

Aspose.Slides for C++ enables you to easily convert PowerPoint and OpenDocument presentation slides into various image formats, including BMP, PNG, JPG (JPEG), GIF, and others.

To convert a slide into an image, follow these steps:

1. Define the desired conversion settings and select the slides you want to export by using:
    - The [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) interface, or
    - The [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/) interface.
2. Generate the slide image by calling the [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) method.

A [Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/) is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (BMP, JPG, PNG, etc.).

## **Convert Slides to Bitmap and Save the Images in PNG**

You can convert a slide to a bitmap object and use it directly in your application. Alternatively, you can convert a slide to a bitmap and then save the image in JPEG or any other preferred format.

This C++ code demonstrates how to convert the first slide of a presentation to a bitmap object and then save the image in PNG format:

```cpp 
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap.
auto image = presentation->get_Slide(0)->GetImage();

// Save the image in the PNG format.
image->Save(u"Slide_0.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

## **Convert Slides to Images with Custom Sizes**

You may need to get an image of a certain size. Using an overload from the [GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/), you can convert a slide to an image with specific dimensions (width and height). 

This sample code demonstrates how to do this:

```cpp 
Size imageSize(1820, 1040);

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Convert the first slide in the presentation to a bitmap with the specified size.
auto image = presentation->get_Slide(0)->GetImage(imageSize);

// Save the image in the JPEG format.
image->Save(u"Slide_0.jpg", ImageFormat::Jpeg);

image->Dispose();
presentation->Dispose();
```

## **Convert Slides with Notes and Comments to Images**

Some slides may contain notes and comments.

Aspose.Slides provides two interfaces—[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) and [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)—that allow you to control the rendering of presentation slides to images. Both interfaces include the `set_SlidesLayoutOptions` method, which enables you to configure the rendering of notes and comments on a slide when converting it to an image.

With the [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) class, you can specify your preferred position for notes and comments in the resulting image.

This C++ code demonstrates how to convert a slide with notes and comments:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"Presentation_with_notes_and_comments.pptx");

auto notesCommentsOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesCommentsOptions->set_NotesPosition(NotesPositions::BottomTruncated);  // Set the position of the notes.
notesCommentsOptions->set_CommentsPosition(CommentsPositions::Right);      // Set the position of the comments.
notesCommentsOptions->set_CommentsAreaWidth(500);                          // Set the width of the comments area.
notesCommentsOptions->set_CommentsAreaColor(Color::get_AntiqueWhite());    // Set the color for the comments area.

// Create the rendering options.
auto options = MakeObject<RenderingOptions>();
options->set_SlidesLayoutOptions(notesCommentsOptions);

// Convert the first slide of the presentation to an image.
auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

// Save the image in the GIF format.
image->Save(u"Image_with_notes_and_comments_0.gif", ImageFormat::Gif);

image->Dispose();
presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 

In any slide-to-image conversion process, the [set_NotesPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_notesposition/) method cannot apply `BottomFull` (to specify the position for notes) because a note's text may be too large, making it unable to fit within the specified image size.

{{% /alert %}} 

## **Convert Slides to Images Using TIFF Options**

The [ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) interface provides greater control over the resulting TIFF image by allowing you to specify parameters such as size, resolution, color palette, and more.

This C++ code demonstrates a conversion process where TIFF options are used to output a black-and-white image with a 300 DPI resolution and a size of 2160 × 2800:

```cpp 
// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Get the first slide from the presentation.
auto slide = presentation->get_Slide(0);

// Configure the settings of the output TIFF image.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_ImageSize(Size(2160, 2880));                       // Set the image size.
tiffOptions->set_PixelFormat(ImagePixelFormat::Format1bppIndexed);  // Set the pixel format (black and white).
tiffOptions->set_DpiX(300);                                         // Set the horizontal resolution.
tiffOptions->set_DpiY(300);                                         // Set the vertical resolution.

// Convert the slide to an image with the specified options.
auto image = slide->GetImage(tiffOptions);

// Save the image in TIFF format.
image->Save(u"output.bmp", ImageFormat::Tiff);

image->Dispose();
presentation->Dispose();
```

## **Convert All Slides to Images**

Aspose.Slides allows you to convert all slides in a presentation to images, effectively converting the entire presentation into a series of images.

This sample code demonstrates how to convert all slides in a presentation to images in C++:

```cpp 
float scaleX = 2;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

// Render the presentation to images slide by slide.
for (int i = 0; i < presentation->get_Slides()->get_Count(); i++)
{
    // Control hidden slides (do not render hidden slides).
    if (presentation->get_Slide(i)->get_Hidden())
    {
        continue;
    }

    // Convert the slide to an image.
    auto image = presentation->get_Slide(i)->GetImage(scaleX, scaleY);

    // Save the image in the JPEG format.
    image->Save(u"Slide_" + String(i) + u".jpg", ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **FAQs**

**1. Does Aspose.Slides support rendering slides with animations?**

No, the `GetImage` method saves only a static image of the slide, without animations.

**2. Can hidden slides be exported as images?**

Yes, hidden slides can be processed just like regular ones. Just make sure they are included in the processing loop.

**3. Can images be saved with shadows and effects?**

Yes, Aspose.Slides supports rendering shadows, transparency, and other graphic effects when saving slides as images.
