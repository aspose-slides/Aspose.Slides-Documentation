---
title: Извлечение изображений из фигур презентации
type: docs
weight: 90
url: /ru/python-net/extracting-images-from-presentation-shapes/
keywords: "Извлечение изображения, PowerPoint, PPT, PPTX, Презентация PowerPoint, Python, Aspose.Slides для Python"
description: "Извлечение изображений из презентации PowerPoint на Python"
---

{{% alert color="primary" %}} 

Изображения часто добавляются в фигуры и также часто используются в качестве фона слайдов. Объекты изображений добавляются через [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), которая является коллекцией объектов [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/). 

В этой статье объясняется, как извлечь изображения, добавленные в презентации. 

{{% /alert %}} 

Чтобы извлечь изображение из презентации, сначала нужно найти изображение, пройдя через каждый слайд и затем через каждую фигуру. Как только изображение найдено или идентифицировано, его можно извлечь и сохранить как новый файл. XXX 

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
    # Доступ к презентации
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        # Доступ к первому слайду
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            # Получение фонового изображения  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            # Получение фонового изображения  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            # Установка желаемого формата изображения 
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