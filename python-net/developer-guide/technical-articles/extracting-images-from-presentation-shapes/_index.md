---
title: Extracting Images from Presentation shapes
type: docs
weight: 90
url: /python-net/extracting-images-from-presentation-shapes/
keywords: "Extract image, PowerPoint, PPT, PPTX, PowerPoint presentation, Python, Aspose.Slides for Python"
description: "Extract images from PowerPoint presentation in Python"
---

{{% alert color="primary" %}} 

Images are often added to shapes and also frequently used as slides' backgrounds. The image objects are added through [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), which is a collection of [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) objects. 

This article explains how you can extract the images added to presentations. 

{{% /alert %}} 

To extract an image from a presentation, you have to locate the image first by going through every slide and then going through every shape. Once the image is found or identified, you can extract it and save it as a new file. XXX 

```py
import aspose.pydrawing as draw
import aspose.slides as slides

def get_image_format(image_type):
    return {
        "jpeg": draw.imaging.ImageFormat.jpeg,
        "emf": draw.imaging.ImageFormat.emf,
        "bmp": draw.imaging.ImageFormat.bmp,
        "png": draw.imaging.ImageFormat.png,
        "wmf": draw.imaging.ImageFormat.wmf,
        "gif": draw.imaging.ImageFormat.gif,
    }.get(image_type, draw.imaging.ImageFormat.jpeg)

with slides.Presentation("pres.pptx") as pres:
    #Accessing the presentation
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #Accessing the first slide
        image_format = draw.imaging.ImageFormat.jpeg

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

            back_image.system_image.save(
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

                shape_image.system_image.save(
                                file_name.format("shape_"+str(i)+"_", slideIndex, image_type), 
                                image_format)
```
