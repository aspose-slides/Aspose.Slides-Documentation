---
title: Convert PowerPoint to PNG in C#
linktitle: Convert PowerPoint to PNG
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
keywords:
- PowerPoint to png
- ppt to png
- pptx to png
- odp to png
- PowerPoint to PNG
- PPT to PNG
- PPTX to PNG
- ODP to PNG
- C#
- Csharp
- Aspose.Slides for .NET
description: Convert PowerPoint presentation to PNG in C#. Convert PPT to PNG in C#. Convert PPTX to PNG in C#. Convert ODP to PNG in C#
---

## **Overview**

This article explains how to convert PowerPoint Presentation to PNG format using C#. It covers the following topics.

- [Convert PowerPoint to PNG in C#](#convert-powerpoint-to-png)
- [Convert PPT to PNG in C#](#convert-powerpoint-to-png)
- [Convert PPTX to PNG in C#](#convert-powerpoint-to-png)
- [Convert ODP to PNG in C#](#convert-powerpoint-to-png)
- [Convert PowerPoint Slide to Image in C#](#convert-powerpoint-to-png)

## **C# PowerPoint to PNG**

For C# sample code to convert PowerPoint to PNG, please see the section below i.e. [Convert PowerPoint to PNG](#convert-powerpoint-to-png). The code can load number of formats like PPT, PPTX and ODP in Presentation object and then save its slide thumbnail to PNG format. The other PowerPoint to Image conversions which are sort of similar like JPG, BMP, TIFF and SVG are discussed in these articles.

- [C# PowerPoint to JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint to BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint to TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint to SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **About PowerPoint to PNG Conversion**

The PNG (Portable Network Graphics) format is not as popular as JPEG (Joint Photographic Experts Group), but it still very popular. 

**Use case:** When you have a complex image and size is not an issue, PNG is a better image format than JPEG. 

{{% alert title="Tip" color="primary" %}} You may want to check out Aspose free **PowerPoint to PNG Converters**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) and [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). They are a live implementation of the process described on this page. {{% /alert %}}

## **Convert PowerPoint to PNG**

Go through these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get the slide object from the [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) collection under the [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) interface. 
3. Use a [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) method to get the thumbnail for each slide. 
4. Use the [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) method to save the slide thumbnail to the PNG format. 

This C# code shows you how to convert a PowerPoint presentation to PNG. Presentation object can load PPT, PPTX, ODP etc, then each slide in presentation object is converted to PNG format or other images format.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Convert PowerPoint to PNG With Custom Dimensions**

If you want to obtain PNG files around a certain scale, you can set the values for `desiredX` and `desiredY`, which determine the dimensions of the resulting thumbnail. 

This code in C# demonstrates the described operation:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Convert PowerPoint to PNG With Custom Size**

If you want to obtain PNG files around a certain size, you can pass your preferred `width` and `height` arguments for `imageSize`. 

This code shows you how to convert a PowerPoint to PNG while specifying the size for the images: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

