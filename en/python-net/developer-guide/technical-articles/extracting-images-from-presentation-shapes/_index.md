---
title: Extract Images from Presentation Shapes in Python
linktitle: Image from Shape
type: docs
weight: 90
url: /python-net/extracting-images-from-presentation-shapes/
keywords:
- extract image
- retrieve image
- slide background
- shape background
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Extract images from shapes in PowerPoint and OpenDocument presentations with Aspose.Slides for Python via .NET — quick, code-friendly solution."
---

{{% alert color="primary" %}} 

Images are often added to shapes and also frequently used as slides' backgrounds. The image objects are added through [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), which is a collection of [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) objects. 

This article explains how you can extract the images added to presentations. 

{{% /alert %}} 

To extract an image from a presentation, you have to locate the image first by going through every slide and then going through every shape. Once the image is found or identified, you can extract it and save it as a new file. XXX 

```py
import aspose.slides as slides

def get_image_format(image_type):
    return {
        "jpeg": slides.ImageFormat.JPEG,
        "emf": slides.ImageFormat.EMF,
        "bmp": slides.ImageFormat.BMP,
        "png": slides.ImageFormat.PNG,
        "wmf": slides.ImageFormat.WMF,
        "gif": slides.ImageFormat.GIF,
    }.get(image_type, slides.ImageFormat.JPEG)

with slides.Presentation("pres.pptx") as pres:
    #Accessing the presentation
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #Accessing the first slide
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Getting the back picture  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Getting the back picture  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #Setting the desired picture format 
            image_type = back_image.content_type.split("/")[1]
            image_format = get_image_format(image_type)

            back_image.image.save(
                file_name.format("LayoutSlide_" if is_layout else "", slideIndex, image_type), 
                image_format)

        for i in range(len(slide.shapes)):
            shape = slide.shapes[i]
            shape_image = None

            if type(shape) is slides.AutoShape and shape.fill_format.fill_type == slides.FillType.PICTURE:
                shape_image = shape.fill_format.picture_fill_format.picture.image
            elif type(shape) is slides.PictureFrame:
                shape_image = shape.picture_format.picture.image

            if shape_image is not None:
                image_type = shape_image.content_type.split("/")[1]
                image_format = get_image_format(image_type)

                shape_image.image.save(
                                file_name.format("shape_"+str(i)+"_", slideIndex, image_type), 
                                image_format)
```
