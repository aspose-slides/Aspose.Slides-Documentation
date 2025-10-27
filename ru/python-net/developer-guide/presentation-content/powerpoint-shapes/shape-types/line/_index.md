---
title: Создание линий в презентациях с помощью Python
linktitle: Линия
type: docs
weight: 50
url: /ru/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/line/
keywords:
- линия
- создать линию
- добавить линию
- прямая линия
- настроить линию
- кастомизировать линию
- стиль штрихов
- конец стрелки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Изучите, как управлять форматированием линий в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Узнайте о свойствах, методах и примерах."
---

## **Обзор**

Aspose.Slides for Python via .NET поддерживает добавление различных типов фигур на слайды. В этой теме мы начнём работать с фигурами, добавляя линии на слайды. С помощью Aspose.Slides разработчики могут не только создавать простые линии, но и рисовать разнообразные стилизованные линии на слайдах.

## **Создание простых линий**

Используйте Aspose.Slides для добавления простой линии на слайд в качестве простого разделителя или соединителя. Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `LINE` с помощью метода `add_auto_shape` объекта [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. Сохраните презентацию в файл PPTX.

В примере ниже линия добавлена на первый слайд презентации.

```py
import aspose.slides as slides

# Instantiate the Presentation class.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Save the presentation as a PPTX file.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Создание линий со стрелкой**

Aspose.Slides позволяет настроить свойства линии, чтобы сделать её более визуально привлекательной. Ниже мы настраиваем несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по индексу.
1. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `LINE` с помощью метода `add_auto_shape` объекта [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
1. Установите [line style](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
1. Установите толщину линии.
1. Установите [dash style](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) линии.
1. Установите стиль и длину наконечника стрелки для начальной точки линии.
1. Установите стиль и длину наконечника стрелки для конечной точки линии.
1. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class that represents the PPTX file.
with slides.Presentation() as presentation:
    # Get the first slide.
    slide = presentation.slides[0]

    # Add an auto shape of type LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Apply formatting to the line.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Save the presentation as a PPTX file.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Могу ли я преобразовать обычную линию в соединитель, чтобы она «привязывалась» к объектам?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) автоматически не становится соединителем. Чтобы она привязывалась к объектам, используйте специализированный тип [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) и [соответствующие API](/slides/ru/python-net/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и трудно определить окончательные значения?**

[Прочитайте эффективные свойства](/slides/ru/python-net/shape-effective-properties/) через классы [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/); они уже учитывают наследование и стили темы.

**Могу ли я заблокировать линию от редактирования (перемещения, изменения размера)?**

Да. Фигуры предоставляют [lock objects](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/), которые позволяют [запретить операции редактирования](/slides/ru/python-net/applying-protection-to-presentation/).