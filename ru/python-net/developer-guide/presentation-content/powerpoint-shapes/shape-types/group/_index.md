---
title: "Группировка фигур презентации с Python"
linktitle: "Группа фигур"
type: docs
weight: 40
url: /ru/python-net/group/
keywords:
- "групповая фигура"
- "группа фигур"
- "добавить группу"
- "альтернативный текст"
- "PowerPoint"
- "презентация"
- "Python"
- "Aspose.Slides"
description: "Узнайте, как группировать и разгруппировать фигуры в PowerPoint и OpenDocument‑документах с помощью Aspose.Slides для Python — быстрый пошаговый гид с бесплатным кодом."
---

## **Обзор**

Grouping shapes allows you to treat multiple drawing objects as a single unit so you can move, resize, format, and transform them together. With Aspose.Slides for Python, you can create a [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), add and arrange child shapes inside it, and persist the result to PPTX. This article demonstrates how to add a group shape on a slide and how to access accessibility metadata such as Alt Text from shapes within the group, enabling cleaner structure and richer, more maintainable presentations.

## **Добавление групповых фигур**

Aspose.Slides supports working with group shapes on a slide. This feature lets you build richer presentations by treating multiple shapes as a single object. You can add new group shapes, access existing ones, populate them with child shapes, and read or modify any of their properties. To add a group shape to a slide:

1. Создайте экземпляр класса [Presentation].
2. Получите ссылку на слайд по индексу.
3. Добавьте [GroupShape] на слайд.
4. Добавьте фигуры в новую групповую форму.
5. Сохраните изменённую презентацию в файл PPTX.

The example below shows how to add a group shape to a slide.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation.
with slides.Presentation() as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Добавьте групповую форму на слайд.
    group_shape = slide.shapes.add_group_shape()

    # Добавьте фигуры внутрь групповой формы.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Запишите файл PPTX на диск.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Доступ к свойству Alt Text**

This section explains how to read the Alt Text of shapes contained within a group shape on a slide using Aspose.Slides. To access the Alt Text of the shapes:

1. Создайте экземпляр класса [Presentation] для представления файла PPTX.
2. Получите ссылку на слайд по его индексу.
3. Получите коллекцию фигур слайда.
4. Получите доступ к [GroupShape].
5. Считайте свойство Alt Text.

The example below retrieves the Alt Text of shapes contained within group shapes.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для открытия файла PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Доступ к групповой форме.
            for child_shape in shape.shapes:
                # Доступ к свойству Alt Text.
                print(child_shape.alternative_text)
```

## **FAQ**

**Поддерживается ли вложенная группировка (группа внутри группы)?**

Да. У [GroupShape] есть свойство [parent_group], которое непосредственно указывает на поддержку иерархии (группа может быть дочерней по отношению к другой группе).

**Как контролировать порядок наложения (z-order) группы относительно других объектов на слайде?**

Используйте свойство [z_order_position] у [GroupShape] для просмотра или изменения её позиции в стеке отображения.

**Можно ли запретить перемещение/редактирование/разгруппировку?**

Да. Раздел блокировки группы доступен через [group_shape_lock], что позволяет ограничить операции над объектом.