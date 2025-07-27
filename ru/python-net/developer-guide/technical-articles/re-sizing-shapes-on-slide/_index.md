---
title: Меняйте размеры фигур в презентациях с помощью Python
linktitle: Изменение размеров фигур
type: docs
weight: 130
url: /ru/python-net/re-sizing-shapes-on-slide/
keywords:
- размер фигуры
- изменение размера фигуры
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко изменяйте размеры фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET — автоматизируйте корректировку макета слайдов и повышайте продуктивность."
---

## **Изменение размеров фигур на слайде**
Одним из самых частых вопросов, задаваемых клиентами Aspose.Slides для Python через .NET, является то, как изменить размеры фигур так, чтобы при изменении размера слайда данные не обрезались. Этот короткий технический совет показывает, как это сделать.

Чтобы избежать дезориентации фигур, каждую фигуру на слайде необходимо обновить в соответствии с новым размером слайда.

```py
import aspose.slides as slides

#Загрузить презентацию
with slides.Presentation("pres.pptx") as presentation:
    #Старый размер слайда
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #Изменение размера слайда
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #Новый размер слайда
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #Изменение позиции
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Изменение размера фигуры, если необходимо 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

    presentation.save("Resize-1.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Если на слайде есть таблица, приведенный выше код не будет работать идеально. В этом случае каждую ячейку таблицы необходимо изменить.

{{% /alert %}} 

Вам нужно использовать следующий код, если вы хотите изменить размеры слайдов с таблицами. Установка ширины или высоты таблицы является особым случаем фигур, когда необходимо изменить высоту отдельных строк и ширину столбцов, чтобы изменить высоту и ширину таблицы.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    #Старый размер слайда
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #Изменение размера слайда
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #Новый размер слайда
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width


    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for master in presentation.masters:
        for shape in master.shapes:
            #Изменение позиции
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Изменение размера фигуры, если необходимо 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

        for layoutslide in master.layout_slides:
            for shape in layoutslide.shapes:
                #Изменение позиции
                shape.height = shape.height * ratioHeight
                shape.width = shape.width * ratioWidth

                #Изменение размера фигуры, если необходимо 
                shape.y = shape.y * ratioHeight
                shape.x = shape.x * ratioWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #Изменение позиции
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Изменение размера фигуры, если необходимо 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth
            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * ratioHeight
                for col in shape.columns:
                    col.width = col.width * ratioWidth

    presentation.save("Resize-2.pptx", slides.export.SaveFormat.PPTX)
```