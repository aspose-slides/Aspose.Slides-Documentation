---
title: Extracción de imágenes de formas de presentación
type: docs
weight: 90
url: /python-net/extracting-images-from-presentation-shapes/
keywords: "Extraer imagen, PowerPoint, PPT, PPTX, presentación de PowerPoint, Python, Aspose.Slides para Python"
description: "Extraer imágenes de presentaciones de PowerPoint en Python"
---

{{% alert color="primary" %}} 

Las imágenes a menudo se agregan a las formas y también se utilizan frecuentemente como fondos de diapositivas. Los objetos de imagen se agregan a través de [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), que es una colección de objetos [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/). 

Este artículo explica cómo puedes extraer las imágenes añadidas a las presentaciones. 

{{% /alert %}} 

Para extraer una imagen de una presentación, primero debes localizar la imagen revisando cada diapositiva y luego revisando cada forma. Una vez que la imagen se encuentre o se identifique, puedes extraerla y guardarla como un nuevo archivo. XXX 

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
    #Accediendo a la presentación
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #Accediendo a la primera diapositiva
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Obteniendo la imagen de fondo  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Obteniendo la imagen de fondo  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #Estableciendo el formato de imagen deseado 
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