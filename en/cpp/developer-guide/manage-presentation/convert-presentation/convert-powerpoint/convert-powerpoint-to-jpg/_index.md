---
title: Convert PPT, PPTX, and ODP to JPG in C++
linktitle: Convert Slides to JPG Images
type: docs
weight: 60
url: /cpp/convert-powerpoint-to-jpg/
keywords:
- convert PowerPoint to JPG
- convert presentation to JPG
- convert slide to JPG
- convert PPT to JPG
- convert PPTX to JPG
- convert ODP to JPG
- PowerPoint to JPG
- presentation to JPG
- slide to JPG
- PPT to JPG
- PPTX to JPG
- ODP to JPG
- convert PowerPoint to JPEG
- convert presentation to JPEG
- convert slide to JPEG
- convert PPT to JPEG
- convert PPTX to JPEG
- convert ODP to JPEG
- PowerPoint to JPEG
- presentation to JPEG
- slide to JPEG
- PPT to JPEG
- PPTX to JPEG
- ODP to JPEG
- C++
- Aspose.Slides
description: "Learn how to transform your slides from PowerPoint and OpenDocument presentations into high-quality JPEG images with just a few lines of code in C++. Optimize presentations for web use, sharing, and archiving. Read the full guide now!"
---

## **Overview**

Converting PowerPoint and OpenDocument presentations to JPG images helps with sharing slides, optimizing performance, and embedding content into websites or applications. Aspose.Slides for C++ allows you to transform PPTX, PPT, and ODP files into high-quality JPEG images. This guide explains different methods for conversion.

With these features, it's easy to implement your own presentation viewer and create a thumbnail for every slide. This may be useful if you want to protect presentation slides from copying or demonstrate the presentation in read-only mode. Aspose.Slides allows you to convert the whole presentation or a specific slide into image formats.

## **Convert Presentation Slides to JPG Images**

Here are the steps to convert a PPT, PPTX, or ODP file to JPG:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. Get the slide object of the [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) type from the presentation's slide collection.
1. Create an image of the slide using the [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/) method.
1. Call the [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) method on the image object. Pass the output file name and image format as arguments.

{{% alert color="primary" %}} 

**Note:** PPT, PPTX, or ODP to JPG conversion differs from conversion to other formats in the Aspose.Slides for C++ API. For other formats, you typically use the [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/) method. However, for JPG conversion, you need to use the [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) method.

{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Create a slide image of the specified scale.
    auto image = slide->GetImage(scaleX, scaleY);

    // Save the image to disk in JPEG format.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Convert Slides to JPG with Customized Dimensions**

To change the dimensions of the resulting JPG images, you can set the image size by passing it into the [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) method. This allows you to generate images with specific width and height values, ensuring that the output meets your requirements for resolution and aspect ratio. This flexibility is particularly useful when generating images for web applications, reports, or documentation, where precise image dimensions are required.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Create a slide image of the specified size.
    auto image = slide->GetImage(imageSize);

    // Save the image to disk in JPEG format.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Render Comments when Saving Slides as Images**

Aspose.Slides for C++ provides a feature that allows you to render comments on a presentation's slides when converting them into JPG images. This functionality is particularly useful for preserving annotations, feedback, or discussions added by collaborators in PowerPoint presentations. By enabling this option, you ensure that comments are visible in the generated images, making it easier to review and share feedback without needing to open the original presentation file.

Let's say we have a presentation file, "sample.pptx," with a slide that contains comments:

![The slide with comments](slide_with_comments.png)

The following C++ code converts the slide to a JPG image while preserving the comments:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Set options for the slide comments.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Convert the first slide to an image.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

The result:

![The JPG image with comments](image_with_comments.png)

## **See also**

See other options for converting PPT, PPTX, or ODP to images, such as:

- [Convert PowerPoint to GIF](/slides/cpp/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/cpp/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/cpp/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

To see how Aspose.Slides converts PowerPoint to JPG images, try these free online converters: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) and [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}}

![Free Online PPTX to JPG Converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

Using the same principles described in this article, you can convert images from one format to another. For more information, see these pages: convert [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **FAQs**

**Does this method support batch conversion?**

Yes, Aspose.Slides allows batch conversion of multiple slides to JPG in a single operation.

**Does the conversion support SmartArt, charts, and other complex objects?**

Yes, Aspose.Slides renders all content, including SmartArt, charts, tables, shapes, and more. However, the rendering accuracy may vary slightly compared to PowerPoint, especially when using custom or missing fonts.

**Are there any limitations on the number of slides that can be processed?**

Aspose.Slides itself does not impose any strict limits on the number of slides you can process. However, you may encounter out-of-memory error when working with large presentations or high-resolution images.
