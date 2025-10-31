---
title: Создание линейных фигур в презентациях с помощью Python
linktitle: Линия
type: docs
weight: 50
url: /ru/python-net/line/
keywords:
- линия
- создать линию
- добавить линию
- простая линия
- настроить линию
- кастомизировать линию
- стиль пунктирной линии
- стрелка
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как управлять форматированием линий в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Откройте свойства, методы и примеры."
---

## **Обзор**

Aspose.Slides for Python via .NET поддерживает добавление различных типов фигур на слайды. В этой теме мы начнём работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides разработчики могут создавать не только простые линии, но и более сложные линии на слайдах.

## **Создание простых линий**

Используйте Aspose.Slides для добавления простой линии на слайд в качестве разделителя или соединителя. Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `LINE`, используя метод `add_auto_shape` объекта [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Сохраните презентацию в файл PPTX.

В примере ниже линия добавляется на первый слайд презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation.
with slides.Presentation() as presentation:

    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить автофигуру типа LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Сохранить презентацию в файл PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Создание линий со стрелкой**

Aspose.Slides позволяет настраивать свойства линии, делая её более визуально привлекательной. Ниже мы настраиваем несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `LINE`, используя метод `add_auto_shape` объекта [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Установите [стиль линии](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
5. Установите толщину линии.
6. Установите [стиль пунктирной линии](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).
7. Установите стиль и длину наконечника стрелки для начальной точки линии.
8. Установите стиль и длину наконечника стрелки для конечной точки линии.
9. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation() as presentation:
    # Получить первый слайд.
    slide = presentation.slides[0]

    # Добавить автофигуру типа LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Применить форматирование к линии.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Сохранить презентацию в файл PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **Часто задаваемые вопросы**

**Можно ли преобразовать обычную линию в соединитель, чтобы она «привязывалась» к фигурам?**

Нет. Обычная линия ([AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) автоматически не становится соединителем. Чтобы она привязывалась к фигурам, используйте специально предназначенный тип [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) и соответствующие API(/slides/ru/python-net/connector/) для соединений.

**Что делать, если свойства линии наследуются из темы и сложно определить окончательные значения?**

[прочитать эффективные свойства](/slides/ru/python-net/shape-effective-properties/) через классы [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Можно ли заблокировать линию от редактирования (перемещения, изменения размеров)?**

Да. Фигуры предоставляют [объекты блокировки](/slides/ru/python-net/applying-protection-to-presentation/), которые позволяют [запретить операции редактирования](/slides/ru/python-net/applying-protection-to-presentation/).