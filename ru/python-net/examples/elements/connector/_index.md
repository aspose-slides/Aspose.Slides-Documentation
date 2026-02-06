---
title: Соединитель
type: docs
weight: 190
url: /ru/python-net/examples/elements/connector/
keywords:
- соединитель
- добавить соединитель
- получить соединитель
- удалить соединитель
- повторно соединить фигуры
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Создавайте и управляйте соединителями в Python с помощью Aspose.Slides: добавляйте, прокладывайте, перенаправляйте, задавайте точки подключения, стрелки и стили для связывания фигур в PPT, PPTX и ODP."
---
Показывает, как соединять фигуры соединителями и изменять их цели, используя **Aspose.Slides for Python via .NET**.

## **Добавление соединителя**

Вставьте форму‑соединитель между двумя точками на слайде.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Добавить изогнутый соединитель.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Получение соединителя**

Получите первую форму‑соединитель, добавленную на слайд.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Получить первый соединитель на слайде.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Удаление соединителя**

Удалите соединитель со слайда.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура является соединителем.
        connector = slide.shapes[0]

        # Удалить соединитель.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Повторное соединение фигур**

Присоедините соединитель к двум фигурам, задав начальную и конечную цели.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Добавить первую прямоугольную фигуру.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Добавить вторую прямоугольную фигуру.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Добавить изогнутый соединитель.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Присоединить начало соединителя к первой фигуре.
        connector.start_shape_connected_to = shape1
        # Присоединить конец соединителя ко второй фигуре.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```