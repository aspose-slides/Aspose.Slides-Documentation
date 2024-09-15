---
title: Convert Powerpoint PPT to JPG
type: docs
weight: 60
url: /cpp/convert-powerpoint-to-jpg/
keywords: "Convert PowerPoint to JPG"
description: "Convert PowerPoint to JPG: PPT to JPG, PPTX to JPG in C++"
---

## **Convert Presentation to Set of Images**

In some cases, it is necessary to convert the entire presentation into a set of images, 
the same as PowerPoint allows. The C++ code shows you how to convert a presentation to JPG images:

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& sld : pres->get_Slides())
{
    // Creates a full scale image
    System::SharedPtr<IImage> image = sld->GetImage(1.0f, 1.0f);

    // Saves the image to disk in JPEG format
    image->Save(System::String::Format(u"Slide_{0}.jpg", sld->get_SlideNumber()),
                ImageFormat::Jpeg);
}
```

{{% alert color="primary" %}} 

To see how Aspose.Slides converts PowerPoint to JPG images, you may want to try these free online converters: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) and [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

## Convert PowerPoint PPT/PPTX to JPG with Customized Dimensions**

To change the dimension of the resulting thumbnail and JPG image, you can set the *ScaleX* and *ScaleY* values by passing them into `float scaleX, float Y` of the [**ISlide::GetImage()**](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagefloat-float-method) method:

```c++
auto pres = System::MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

// Defines dimensions
int32_t desiredX = 1200, desiredY = 800;
// Gets scaled values of X and Y
float ScaleX = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Width()) * desiredX;
float ScaleY = (float)(1.0 / pres->get_SlideSize()->get_Size().get_Height()) * desiredY;

for (auto&& sld : pres->get_Slides())
{
    // Creates a full scale image
    System::SharedPtr<IImage> image = sld->GetImage(ScaleX, ScaleY);

    // Saves the image to disk in JPEG format
    image->Save(System::String::Format(u"Slide_{0}.jpg", sld->get_SlideNumber()),
                ImageFormat::Jpeg);
}
```

{{% alert title="Tip" color="primary" %}}

Aspose provides a [FREE Collage web app](https://products.aspose.app/slides/collage). Using this online service, you can merge [JPG to JPG](https://products.aspose.app/slides/collage/jpg) or PNG to PNG images, create [photo grids](https://products.aspose.app/slides/collage/photo-grid), and so on. 

Using the same principles described in this article, you can convert images from one format to another. For more information, see these pages: convert [image to JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **See also**

See other options to convert PPT/PPTX into image like:

- [PPT/PPTX to SVG conversion](/slides/cpp/render-a-slide-as-an-svg-image/)