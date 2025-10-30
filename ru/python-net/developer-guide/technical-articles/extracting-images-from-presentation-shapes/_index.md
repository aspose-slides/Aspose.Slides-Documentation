---
title: Извлечение изображений из фигур презентации в Python
linktitle: Изображение из фигуры
type: docs
weight: 90
url: /ru/python-net/extracting-images-from-presentation-shapes/
keywords:
- извлекать изображение
- получать изображение
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

Изображения часто добавляются в фигуры и также часто используются в качестве фона слайдов. Объекты изображений добавляются через [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/), который является коллекцией объектов [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/). 

В этой статье объясняется, как можно извлечь добавленные в презентацию изображения. 

{{% /alert %}} 

Чтобы извлечь изображение из презентации, необходимо сначала найти его, проходя по каждому слайду и затем по каждой фигуре. Когда изображение найдено или определено, его можно извлечь и сохранить в новый файл. XXX 

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
    # Получение доступа к презентации
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        # Получение доступа к первому слайду
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            # Получение фоновой картинки  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            # Получение фоновой картинки  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            # Установка желаемого формата картинки 
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

## **Часто задаваемые вопросы**

**Могу ли я извлечь оригинальное изображение без обрезки, эффектов или преобразований фигуры?**

Да. При доступе к изображению фигуры вы получаете объект изображения из [image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) презентации, то есть оригинальные пиксели без обрезки или стилистических эффектов. Рабочий процесс проходит через коллекцию изображений презентации и объекты [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), которые хранят необработанные данные.

**Есть ли риск дублирования одинаковых файлов при одновременном сохранении большого количества изображений?**

Да, если сохранять всё без разбора. Коллекция изображений презентации может содержать одинаковые двоичные данные, на которые ссылаются разные фигуры или слайды. Чтобы избежать дубликатов, сравнивайте хеши, размеры или содержимое извлечённых данных перед записью.

**Как определить, какие фигуры связаны с конкретным изображением из коллекции презентации?**

Aspose.Slides не хранит обратные ссылки от [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) к фигурам. Сформируйте сопоставление вручную во время обхода: каждый раз, когда находите ссылку на [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/), фиксируйте, какие фигуры её используют.

**Могу ли я извлечь изображения, встроенные в OLE‑объекты, например, прикреплённые документы?**

Не напрямую, поскольку OLE‑объект является контейнером. Необходимо извлечь сам OLE‑пакет, а затем проанализировать его содержимое с помощью специализированных инструментов. Фигуры‑изображения презентации работают через [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/); OLE – это другой тип объекта.