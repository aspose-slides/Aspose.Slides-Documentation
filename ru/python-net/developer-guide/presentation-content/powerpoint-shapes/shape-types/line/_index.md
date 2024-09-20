---
title: Линия
type: docs
weight: 50
url: /python-net/line/
keywords: "Линия, форма PowerPoint, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Добавление линии в презентацию PowerPoint на Python"
---

Aspose.Slides для Python через .NET поддерживает добавление различных форм на слайды. В этой теме мы начнем работать с формами, добавляя линии на слайды. С помощью Aspose.Slides для Python через .NET разработчики могут не только создавать простые линии, но и рисовать некоторые декоративные линии на слайдах.
## **Создание простой линии**
Чтобы добавить простую линию на выбранный слайд презентации, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте Автофигуру типа линия, используя метод [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/), предоставленный объектом Shapes.
- Запишите измененную презентацию в файл PPTX.

В приведенном ниже примере мы добавили линию на первый слайд презентации.

```py
import aspose.slides as slides

# Создание экземпляра класса PresentationEx, представляющего файл PPTX
with slides.Presentation() as pres:
    # Получаем первый слайд
    sld = pres.slides[0]

    # Добавляем автофигуру типа линия
    sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Записываем PPTX на диск
    pres.save("LineShape1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Создание линии в форме стрелки**
Aspose.Slides для Python через .NET также позволяет разработчикам настраивать некоторые свойства линии, чтобы она выглядела более привлекательно. Давайте попробуем настроить несколько свойств линии, чтобы она выглядела как стрелка. Выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Получите ссылку на слайд, используя его индекс.
- Добавьте Автофигуру типа линия, используя метод AddAutoShape, предоставленный объектом Shapes.
- Установите стиль линии на один из стилей, предложенных Aspose.Slides для Python через .NET.
- Установите ширину линии.
- Установите [стиль штриха](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) линии на один из стилей, предложенных Aspose.Slides для Python через .NET.
- Установите [стиль наконечника стрелки](https://reference.aspose.com/slides/python-net/aspose.slides/linearrowheadstyle/) и длину начальной точки линии.
- Установите стиль наконечника стрелки и длину конечной точки линии.
- Запишите измененную презентацию в файл PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создание экземпляра класса PresentationEx, представляющего файл PPTX
with slides.Presentation() as pres:
    # Получаем первый слайд
    sld = pres.slides[0]

    # Добавляем автофигуру типа линия
    shp = sld.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Применяем некоторые настройки к линии
    shp.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shp.line_format.width = 10

    shp.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shp.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shp.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shp.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shp.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Записываем PPTX на диск
    pres.save("LineShape2_out.pptx", slides.export.SaveFormat.PPTX)
```