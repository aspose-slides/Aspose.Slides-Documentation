---
title: Создание линейных фигур в презентациях с Python
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
- стиль штриха
- наконечник стрелки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Изучите манипулирование форматированием линий в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Ознакомьтесь со свойствами, методами и примерами."
---

## **Обзор**

Aspose.Slides для Python через .NET поддерживает добавление различных типов фигур на слайды. В этой статье мы начнём работу с фигурами, добавляя линии на слайды. С помощью Aspose.Slides разработчики могут создавать не только простые линии, но и более сложные линии на слайдах.

## **Создание простых линий**

Используйте Aspose.Slides, чтобы добавить простую линию на слайд в качестве разделителя или соединителя. Чтобы добавить простую линию на выбранный слайд в презентации, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `LINE`, вызвав метод `add_auto_shape` у объекта [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Сохраните презентацию в файл PPTX.

В примере ниже линия добавляется на первый слайд презентации.

```py
import aspose.slides as slides

# Создаём экземпляр класса Presentation.
with slides.Presentation() as presentation:

    # Получаем первый слайд.
    slide = presentation.slides[0]

    # Добавляем автофигуру типа LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Сохраняем презентацию в файл PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Создание линий‑стрелок**

Aspose.Slides позволяет настраивать свойства линии, чтобы она выглядела более привлекательно. Ниже мы настроим несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд по индексу.
3. Добавьте [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `LINE`, вызвав метод `add_auto_shape` у объекта [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).
4. Установите [стиль линии](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/).
5. Установите толщину линии.
6. Установите [стиль штриха линии](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/).
7. Установите стиль и длину наконечника стрелки для начала линии.
8. Установите стиль и длину наконечника стрелки для конца линии.
9. Сохраните презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создаём экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation() as presentation:
    # Получаем первый слайд.
    slide = presentation.slides[0]

    # Добавляем автофигуру типа LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Применяем форматирование к линии.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Сохраняем презентацию в файл PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Можно ли преобразовать обычную линию в соединитель, чтобы она «прилипала» к фигурам?**

Нет. Обычная линия (это [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа [LINE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/)) автоматически не становится соединителем. Чтобы она «прилипала» к фигурам, используйте специализированный тип [Connector](https://reference.aspose.com/slides/python-net/aspose.slides/connector/) и соответствующие API [/slides/python-net/connector/].

**Что делать, если свойства линии наследованы из темы и сложно определить их окончательные значения?**

[Изучите эффективные свойства](/slides/ru/python-net/shape-effective-properties/) через классы [ILineFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/) и [ILineFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilinefillformateffectivedata/) — они уже учитывают наследование и стили темы.

**Можно ли заблокировать линию от редактирования (перемещения, изменения размеров)?**

Да. Фигуры предоставляют [объекты блокировки](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/), позволяющие [запретить операции редактирования](/slides/ru/python-net/applying-protection-to-presentation/).