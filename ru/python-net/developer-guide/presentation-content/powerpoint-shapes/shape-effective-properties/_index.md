---
title: Получить эффективные свойства фигур из презентаций с Python
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/python-net/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- освещение
- фаска фигуры
- текстовый кадр
- текстовый стиль
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для Python через .NET вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint."
---
## **Обзор**

Эта статья объясняет различие между **локальными** и **эффективными** свойствами. Локальные значения — это значения, задаваемые непосредственно на определённом уровне форматирования, например:

1. Свойства части на слайде.
1. Стили текста прототипов фигур в макете или главном слайде, когда у формы текстового фрейма части есть такой стиль.
1. Глобальные настройки текста в презентации.

Локальные значения могут быть определены или опущены на любом уровне. Когда Aspose.Slides требуется окончательное «как отрендерено» форматирование, он разрешает цепочку наследования и возвращает **эффективные** значения. Получить их можно, вызвав метод `get_effective` у объекта локального формата.

Следующий пример показывает, как получить эффективные значения. Предполагается, что первая фигура на первом слайде — это [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) с текстовым фреймом и как минимум одной частью.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Эффективные данные форматирования представляют текущие вычисленные параметры после применения наследования. В текущей реализации некоторые объекты эффективных данных, такие как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iportionformateffectivedata/), могут кэшироваться внутри. Повторный вызов `get_effective` после изменения родительского или наследуемого форматирования может обновить кэш, и ранее полученный объект может больше не представлять прежнее состояние. Если необходимо сохранить эффективные значения для последующего использования, скопируйте требуемые свойства (например, высоту шрифта, цвет заливки, стиль шрифта или выравнивание) в свой собственный объект данных.
{{% /alert %}}

## **Получить эффективные свойства камеры**

Aspose.Slides позволяет получить эффективные свойства камеры. Тип [ICameraEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/icameraeffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства камеры. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/icameraeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/).

Следующий пример кода показывает, как получить эффективные свойства камеры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Получить эффективные свойства светового оборудования**

Aspose.Slides позволяет получить эффективные свойства светового оборудования. Тип [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ilightrigeffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства светового оборудования. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ilightrigeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/).

Следующий пример кода показывает, как получить эффективные свойства светового оборудования. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Получить эффективные свойства фаски фигуры**

Aspose.Slides позволяет получить эффективные свойства фаски фигуры. Тип [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ishapebeveleffectivedata/) представляет собой неизменяемый объект, содержащий эффективные свойства рельефа фаски для фигуры. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ishapebeveleffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для [ThreeDFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/threedformat/).

Следующий пример кода показывает, как получить эффективные свойства верхней фаски фигуры. Предполагается, что первая фигура на первом слайде имеет 3D‑форматирование.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Получить эффективные свойства текстового кадра**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового кадра. Тип [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/itextframeformateffectivedata/) содержит эффективные свойства форматирования текстового кадра.

Следующий пример кода показывает, как получить эффективные свойства форматирования текстового кадра. Предполагается, что первая фигура на первом слайде — это [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) с текстовым кадром.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Получить эффективные свойства текстового стиля**

С помощью Aspose.Slides вы можете получить эффективные свойства текстового стиля. Тип [ITextStyleEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/itextstyleeffectivedata/) содержит эффективные свойства текстового стиля.

Следующий пример кода показывает, как получить эффективные свойства текстового стиля. Предполагается, что первая фигура на первом слайде — это [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) с текстовым кадром.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Получить эффективное значение высоты шрифта**

С помощью Aspose.Slides вы можете получить эффективную высоту шрифта. Приведённый ниже код демонстрирует, как эффективная высота шрифта части меняется после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить эффективный формат заливки для таблицы**

С помощью Aspose.Slides можно получить эффективное форматирование заливки для разных частей таблицы. Тип [IFillFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ifillformateffectivedata/) содержит эффективные свойства форматирования заливки. Форматирование ячейки имеет более высокий приоритет, чем форматирование строки; форматирование строки — выше, чем форматирование столбца; форматирование столбца — выше, чем форматирование всей таблицы.

В результате свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/icellformateffectivedata/) используются при отрисовке ячейки таблицы. Следующий пример кода показывает, как получить эффективное форматирование заливки для разных частей таблицы. Предполагается, что первая фигура на первом слайде — это [Table](https://reference.aspose.com/slides/ru/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**Возвращает ли `get_effective` моментальный снимок?**

Не всегда. Эффективные данные представляют рассчитанное форматирование после применения наследования, но некоторые объекты эффективных данных могут кэшироваться внутри. Последующий вызов `get_effective` может пересчитать форматирование и обновить кэш, поэтому ранее полученный объект не следует рассматривать как постоянный снимок.

**Когда следует снова считывать эффективные свойства?**

Вызовите `get_effective` повторно после изменения локального форматирования, стилей‑родителей, форматирования макета, форматирования мастер‑слайда или значений по умолчанию на уровне презентации. При следующем вызове будет переоценена иерархия форматирования, и будут возвращены текущие эффективные результаты.

**Влияет ли изменение или удаление макета/главного слайда на уже полученные эффективные свойства?**

Да, но изменение отражается только при следующем вызове `get_effective`. Если источник форматирования‑родителя изменён или удалён, ранее полученные эффективные данные могут стать устаревшими. После повторного вызова `get_effective` Aspose.Slides переоценивает дерево форматирования, и полученные шрифты, цвета, размеры или другие значения могут измениться.

**Можно ли изменить значения через объекты эффективных данных?**

Нет. Объекты эффективных данных предоставляют только рассчитанные значения. Вносите изменения в локальные объекты форматирования, а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано ни на уровне фигуры, ни в макете/главном слайде, ни в глобальных настройках?**

Эффективное значение определяется механизмом значения по умолчанию, который включает настройки PowerPoint и Aspose.Slides. Это разрешённое значение становится частью текущих эффективных данных.

**Можно ли по эффективному значению шрифта определить, какой уровень предоставил размер или гарнитуру?**

Не напрямую. Эффективные данные возвращают окончательное значение. Чтобы найти источник, проверьте локальные значения в части, абзаце, текстовом кадре и текстовых стилях на уровнях макета, главного слайда и презентации, чтобы увидеть, где впервые было задано явное определение.

**Почему иногда эффективные значения выглядят одинаково с локальными?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте эффективные данные, когда нужен результат «как отрендерено» после применения всего наследования, например, для синхронизации цветов, отступов или размеров. Если необходимо сохранить эти значения независимо от последующих изменений форматирования, скопируйте требуемые свойства в свой собственный объект. Если нужно изменить форматирование на конкретном уровне, измените локальные свойства и, при необходимости, снова прочитайте эффективные данные для проверки результата.