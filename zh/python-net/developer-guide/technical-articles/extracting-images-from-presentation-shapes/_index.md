---
title: 从演示文稿形状中提取图像
type: docs
weight: 90
url: /zh/python-net/extracting-images-from-presentation-shapes/
keywords: "提取图像, PowerPoint, PPT, PPTX, PowerPoint 演示文稿, Python, Aspose.Slides for Python"
description: "在 Python 中从 PowerPoint 演示文稿中提取图像"
---

{{% alert color="primary" %}} 

图像通常添加到形状中，并且经常用作幻灯片的背景。图像对象是通过 [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) 添加的，它是 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 对象的集合。 

本文解释了如何提取添加到演示文稿中的图像。 

{{% /alert %}} 

要从演示文稿中提取图像，您必须首先通过浏览每个幻灯片并然后浏览每个形状来定位图像。一旦找到或识别图像，您就可以提取它并将其保存为新文件。 XXX 

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
    #访问演示文稿
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #访问第一张幻灯片
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #获取背景图片  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #获取背景图片  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #设置所需的图片格式 
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