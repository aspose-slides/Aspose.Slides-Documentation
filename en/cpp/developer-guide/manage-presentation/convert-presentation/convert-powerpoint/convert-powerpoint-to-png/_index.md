---
title: Convert PowerPoint Slides to PNG in C++
linktitle: PowerPoint to PNG
type: docs
weight: 30
url: /cpp/convert-powerpoint-to-png/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to PNG
- presentation to PNG
- slide to PNG
- PPT to PNG
- PPTX to PNG
- save PPT as PNG
- save PPTX as PNG
- export PPT to PNG
- export PPTX to PNG
- C++
- Aspose.Slides
description: "Convert PowerPoint presentations to high-quality PNG images quickly with Aspose.Slides for C++, ensuring precise, automated results."
---

## **About PowerPoint to PNG Conversion**

The PNG (Portable Network Graphics) format is not as popular as JPEG (Joint Photographic Experts Group), but it still very popular. 

**Use case:** When you have a complex image and size is not an issue, PNG is a better image format than JPEG. 

{{% alert title="Tip" color="primary" %}} You may want to check out Aspose free **PowerPoint to PNG Converters**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) and [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). They are a live implementation of the process described on this page. {{% /alert %}}

## **Convert PowerPoint to PNG**

Go through these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class.
2. Get the slide object from the [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) collection under the [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide) interface. 
3. Use a [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) method to get the thumbnail for each slide. 
4. Use the [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) method to save the slide thumbnail to the PNG format. 

This C++ code shows you how to convert a PowerPoint presentation to PNG:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **Convert PowerPoint to PNG With Custom Dimensions**

If you want to obtain PNG files around a certain scale, you can set the values for `desiredX` and `desiredY`, which determine the dimensions of the resulting thumbnail. 

This code in C++ demonstrates the described operation:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```

## **Convert PowerPoint to PNG With Custom Size**

If you want to obtain PNG files around a certain size, you can pass your preferred `width` and `height` arguments for `ImageSize`. 

This code shows you how to convert a PowerPoint to PNG while specifying the size for the images: 

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```

