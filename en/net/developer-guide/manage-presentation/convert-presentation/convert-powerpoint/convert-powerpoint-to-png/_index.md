---
title: Convert PowerPoint Slides to PNG in .NET
linktitle: PowerPoint to PNG
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
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
- .NET
- C#
- Aspose.Slides
description: "Convert PowerPoint presentations to high-quality PNG images quickly with Aspose.Slides for .NET, ensuring precise, automated results."
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

## **FAQ**

**How can I export only a specific shape (e.g., chart or picture) rather than the whole slide?**

Aspose.Slides supports [generating thumbnails for individual shapes](/slides/net/create-shape-thumbnails/); you can render a shape to a PNG image.

**Is parallel conversion supported on a server?**

Yes, but [don’t share](/slides/net/multithreading/) a single presentation instance across threads. Use a separate instance per thread or process.

**What are the trial-version limitations when exporting to PNG?**

The evaluation mode adds a watermark to output images and enforces [other restrictions](/slides/net/licensing/) until a license is applied.
