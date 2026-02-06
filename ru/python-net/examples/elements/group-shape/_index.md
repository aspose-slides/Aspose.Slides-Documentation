---
title: Групповая фигура
type: docs
weight: 170
url: /ru/python-net/examples/elements/group-shape/
keywords:
- группа
- добавить групповую фигуру
- доступ к групповой фигуре
- удалить групповую фигуру
- разгруппировать фигуры
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Работайте с групповыми фигурами в Python, используя Aspose.Slides: создавайте и разгруппируйте, переупорядочивайте дочерние фигуры, задавайте трансформации и границы в PowerPoint и OpenDocument."
---
Примеры создания групп фигур, доступа к ним, разгруппировки и удаления с использованием **Aspose.Slides for Python via .NET**.

## **Добавить групповую фигуру**

Создайте группу, содержащую две базовые фигуры.

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Добавить групповую фигуру.
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить групповую фигуру**

Получите первую группу фигур со слайда.

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Доступ к первой группе фигур на слайде.
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **Удалить групповую фигуру**

Удалите группу фигур со слайда.

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура является групповой фигурой.
        group = slide.shapes[0]

        # Удалить групповую фигуру.
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Разгруппировать фигуры**

Переместите фигуры из контейнера группы.

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # Предполагая, что первая фигура является групповой фигурой.
        group = slide.shapes[0]

        # Переместить фигуры из группы.
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```