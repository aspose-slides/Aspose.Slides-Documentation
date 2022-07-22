---
title: Convert PowerPoint to PNG
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
keywords: PowerPoint to PNG, PPT to PNG, PPTX to PNG, C#, Csharp, Aspose.Slides for .NET
description: Convert PowerPoint presentation to PNG
---

## **About PowerPoint to PNG Conversion**

The PNG (Portable Network Graphics) format is not as popular as JPEG (Joint Photographic Experts Group), but it still very popular. 

**Use case:** When you have a complex image and size is not an issue, PNG is a better image format than JPEG. 

{{% alert title="Tip" color="primary" %}} You may want to check out Aspose free **PowerPoint to PNG Converters**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) and [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). They are a live implementation of the process described on this page. {{% /alert %}}

## **Convert PowerPoint to PNG**

Go through these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
2. Get the slide object from the [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) collection under the [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) interface. 
3. Use a [ISlideGetThumbnail](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) method to get the thumbnail for each slide. 
4. Use the [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) method to save the slide thumbnail to the PNG format. 

This C# code shows you how to convert a PowerPoint presentation to PNG:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];
        slide.GetThumbnail().Save($"slide_{index}.png", ImageFormat.Png);
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
        slide.GetThumbnail(scaleX, scaleY).Save($"slide_{index}.png", ImageFormat.Png); 
    }
}
```

## **Convert PowerPoint to PNG With Custom Size**

If you want to obtain PNG files around a certain size, you can pass your preferred `width` and `height` arguments for `ImageSize`. 

This code shows you how to convert a PowerPoint to PNG while specifying the size for the images: 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];
        slide.GetThumbnail(size).Save($"slide_{index}.png", ImageFormat.Png);
    }
}
```

