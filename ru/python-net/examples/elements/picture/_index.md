---
title: Изображение
type: docs
weight: 50
url: /ru/python-net/examples/elements/picture/
keywords:
- изображение
- рамка изображения
- добавить изображение
- доступ к изображению
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Работа с изображениями в Python с использованием Aspose.Slides: вставка, замена, обрезка, сжатие, настройка прозрачности и эффектов, заполнение фигур и экспорт в PPT, PPTX и ODP."
---
Показывает, как вставлять и получать доступ к изображениям из памяти, используя **Aspose.Slides for Python via .NET**. Приведённые ниже примеры создают изображение в памяти, размещают его на слайде и затем извлекают его.

## **Add a Picture**
Этот код загружает изображение из файла и вставляет его в виде рамки изображения на первом слайде.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Загрузить изображение из файла.
        with open("image.png", "rb") as image_stream:
            # Добавить изображение в ресурсы презентации.
            image = presentation.images.add_image(image_stream)

        # Вставить рамку изображения, отображающую картинку, на первый слайд.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Access a Picture**
Этот пример проверяет, что на слайде есть рамка изображения, и затем получает доступ к первой найденной.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Получить первую рамку изображения на слайде.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```