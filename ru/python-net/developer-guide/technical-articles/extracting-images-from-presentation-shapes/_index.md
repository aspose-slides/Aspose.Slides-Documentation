---
title: Извлечение изображений из фигур презентации на Python
linktitle: Изображение из фигуры
type: docs
weight: 90
url: /ru/python-net/extracting-images-from-presentation-shapes/
keywords:
- извлечение изображения
- получение изображения
- фон слайда
- фон фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Извлекайте изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET — быстрое, удобное решение."
---

## **Извлечение изображений из фигур**

{{% alert color="primary" %}} 

Изображения часто добавляются в фигуры и также часто используются в качестве фонов слайдов. Объекты изображений добавляются через [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), который является коллекцией объектов [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) . 

Эта статья объясняет, как извлекать изображения, добавленные в презентации. 

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

## **FAQ**

**Могу ли я извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?**

Да. Когда вы получаете изображение фигуры, вы получаете объект изображения из [коллекции изображений](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) презентации, то есть оригинальные пиксели без обрезки или стилистических эффектов. Процесс проходит по коллекции изображений презентации и объектам [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), которые хранят необработанные данные.

**Существует ли риск создания дублирующих идентичных файлов при сохранении большого количества изображений одновременно?**

Да, если сохранять всё без разбора. [Коллекция изображений](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) презентации может содержать одинаковые бинарные данные, на которые ссылаются разные фигуры или слайды. Чтобы избежать дублирования, сравнивайте хеши, размеры или содержимое извлечённых данных перед записью.

**Как определить, какие фигуры связаны с конкретным изображением из коллекции презентации?**

Aspose.Slides не хранит обратные ссылки от [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) к фигурам. Сформируйте отображение вручную во время обхода: каждый раз, когда вы находите ссылку на [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), фиксируйте, какие фигуры её используют.

**Могу ли я извлекать изображения, встроенные в OLE-объекты, например вложенные документы?**

Не напрямую, поскольку OLE-объект является контейнером. Необходимо извлечь сам OLE‑пакет, а затем проанализировать его содержимое с помощью отдельных инструментов. Фигуры‑картинки презентации работают через [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/); OLE — это другой тип объекта.