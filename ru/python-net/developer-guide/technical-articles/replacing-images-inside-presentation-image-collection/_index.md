---
title: Замена изображений в коллекции изображений презентации
type: docs
weight: 110
url: /ru/python-net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides для Python через .NET позволяет заменять изображения, добавленные в фигуры слайдов. В этой статье объясняется, как заменить изображение, добавленное в коллекцию изображений презентации, используя различные подходы.

{{% /alert %}} 
## **Замена изображения в коллекции изображений презентации**
Aspose.Slides для Python через .NET предоставляет простые методы API для замены изображений в коллекции изображений презентации. Пожалуйста, выполните следующие шаги:

1. Загрузите файл презентации с изображением, используя класс [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Загрузите изображение из файла в байтовый массив.
1. Замените целевое изображение на новое изображение в байтовом массиве.
1. Во втором подходе загрузите изображение в объект Image и замените целевое изображение загруженным изображением.
1. В третьем подходе замените изображение на уже добавленное изображение в коллекции изображений презентации.
1. Сохраните измененную презентацию в виде файла PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

#Создание презентации
with slides.Presentation("pres.pptx") as presentation:

    #первый способ
    data = read_all_bytes("image_0.jpeg")
    oldImage = presentation.images[0]
    oldImage.replace_image(data)

    #второй способ
    newImage = slides.Images.from_file("image_1.jpeg")
    oldImage = presentation.images[1]
    oldImage.replace_image(newImage)

    #третий способ
    oldImage = presentation.images[2]
    oldImage.replace_image(presentation.images[3])

    #Сохранение презентации
    presentation.save("replace_image-out.pptx", slides.export.SaveFormat.PPTX)
```