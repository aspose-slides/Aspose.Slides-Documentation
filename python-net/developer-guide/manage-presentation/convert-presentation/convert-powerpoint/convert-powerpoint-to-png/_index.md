---
title: Convert PowerPoint to PNG
type: docs
weight: 30
url: /python-net/convert-powerpoint-to-png/
keywords: PowerPoint to PNG, PPT to PNG, PPTX to PNG, Python, Aspose.Slides for Python via .NET
description: Convert PowerPoint presentation to PNG
---

## **About PowerPoint to PNG Conversion**

The PNG (Portable Network Graphics) format is not as popular as JPEG (Joint Photographic Experts Group), but it still very popular. 

**Use case:** When you have a complex image and size is not an issue, PNG is a better image format than JPEG. 

{{% alert title="Tip" color="primary" %}} You may want to check out Aspose free **PowerPoint to PNG Converters**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) and [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). They are a live implementation of the process described on this page. {{% /alert %}}

## **Convert PowerPoint to PNG**

Go through these steps:

1. Instantiate the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Get the slide object from the [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) collection under the [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) interface. 
3. Use a [ISlideGetThumbnail](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) method to get the thumbnail for each slide. 
4. Use the [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) method to save the slide thumbnail to the PNG format. 

This Python code shows you how to convert a PowerPoint presentation to PNG:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]
    slide.get_thumbnail().save("slide_{i}.png".format(i = index), drawing.imaging.ImageFormat.png)
```

## **Convert PowerPoint to PNG With Custom Dimensions**

If you want to obtain PNG files around a certain scale, you can set the values for `desiredX` and `desiredY`, which determine the dimensions of the resulting thumbnail. 

This code in Python demonstrates the described operation:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation("pres.pptx")

scaleX = 2
scaleY = 2
for index in range(pres.slides.length):
    slide = pres.slides[index]
    slide.get_thumbnail(scaleX, scaleY).save("slide_{index}.png".format(index=index), drawing.imaging.ImageFormat.png)
```

## **Convert PowerPoint to PNG With Custom Size**

If you want to obtain PNG files around a certain size, you can pass your preferred `width` and `height` arguments for `ImageSize`. 

This code shows you how to convert a PowerPoint to PNG while specifying the size for the images: 

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

size = drawing.Size(960, 720)

for index in range(pres.slides.length):
    slide = pres.slides[index]
    slide.get_thumbnail(size).save("slide_{index}.png".format(index=index), drawing.imaging.ImageFormat.png)
```

