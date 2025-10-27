---
title: Получение эффективных свойств фигур из презентаций с помощью Python
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/python-net/shape-effective-properties/
keywords:
- shape properties
- camera properties
- light rig
- bevel shape
- text frame
- text style
- font height
- fill format
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Узнайте, как Aspose.Slides для Python через .NET вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint и OpenDocument."
---

## **Обзор**

В этой теме вы познакомитесь с понятиями **эффективных** и **локальных** свойств. Когда значения задаются непосредственно на следующих уровнях:

1. В свойствах текстовой части на слайде.  
2. В стиле текста прототипной фигуры на макете или основном слайде (если у текстового фрейма есть стиль).  
3. В глобальных настройках текста презентации.  

эти значения называют **локальными**. На любом уровне **локальные** значения могут быть определены или опущены. Когда приложению нужно определить, как должна выглядеть текстовая часть, оно использует **эффективные** значения. Вы можете получить эффективные значения, вызвав метод `get_effective` у локального формата.

Ниже приведён пример, показывающий, как получить эффективные значения для формата текстового фрейма и формата текстовой части.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **Получить эффективные свойства камеры**

Aspose.Slides for Python via .NET позволяет получить эффективные свойства камеры. Класс [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) представляет неизменяемый объект, содержащий эти свойства. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для класса [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Ниже показан пример получения эффективных свойств камеры:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective camera properties =")
	print("Type:", str(three_d_effective_data.camera.camera_type))
	print("Field of view:", str(three_d_effective_data.camera.field_of_view_angle))
	print("Zoom:", str(three_d_effective_data.camera.zoom))
```

## **Получить эффективные свойства световой установки**

Aspose.Slides for Python via .NET позволяет получить эффективные свойства световой установки. Класс [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) представляет неизменяемый объект, содержащий эти свойства. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для класса [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Ниже показан пример получения эффективных свойств световой установки:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **Получить эффективные свойства фаски фигуры**

Aspose.Slides for Python via .NET позволяет получить эффективные свойства фаски фигуры. Класс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) представляет неизменяемый объект, содержащий свойства фаски (relief) фигуры. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для класса [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Ниже показан пример получения эффективных свойств фаски фигуры:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective shape's top face relief properties =")
	print("Type:", str(three_d_effective_data.bevel_top.bevel_type))
	print("Width:", str(three_d_effective_data.bevel_top.width))
	print("Height:", str(three_d_effective_data.bevel_top.height))
```

## **Получить эффективные свойства текстового фрейма**

С помощью Aspose.Slides for Python via .NET можно получить эффективные свойства текстового фрейма. Класс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) содержит эффективные свойства форматирования текстового фрейма.

Ниже пример получения эффективных свойств форматирования текстового фрейма:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
	shape = presentation.slides[0].shapes[0]

	text_frame_format_effective_data = shape.text_frame.text_frame_format.get_effective()

	print("Anchoring type:", str(text_frame_format_effective_data.anchoring_type))
	print("Autofit type:", str(text_frame_format_effective_data.autofit_type))
	print("Text vertical type:", str(text_frame_format_effective_data.text_vertical_type))
	print("Margins")
	print("   Left:", str(text_frame_format_effective_data.margin_left))
	print("   Top:", str(text_frame_format_effective_data.margin_top))
	print("   Right:", str(text_frame_format_effective_data.margin_right))
	print("   Bottom:", str(text_frame_format_effective_data.margin_bottom))
```

## **Получить эффективные свойства стиля текста**

С помощью Aspose.Slides for Python via .NET можно получить эффективные свойства стиля текста. Класс [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) содержит эффективные свойства стиля текста.

Ниже пример получения эффективных свойств стиля текста:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    effective_text_style = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effective_text_style.get_level(i)
        print(f"= Effective paragraph formatting for style level #{str(i)} =")

        print("Depth:", str(effectiveStyleLevel.depth))
        print("Indent:", str(effectiveStyleLevel.indent))
        print("Alignment:", str(effectiveStyleLevel.alignment))
        print("Font alignment:", str(effectiveStyleLevel.font_alignment))
```

## **Получить эффективную высоту шрифта**

С помощью Aspose.Slides for Python via .NET можно получить эффективную высоту шрифта. Ниже показан пример, демонстрирующий, как меняется эффективная высота шрифта у части текста при установке локальных значений высоты шрифта на разных уровнях структуры презентации.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)

    shape.add_text_frame("")
    paragraph = shape.text_frame.paragraphs[0]

    portion0 = slides.Portion("Sample text with first portion")
    portion1 = slides.Portion(" and second portion.")

    paragraph.portions.add(portion0)
    paragraph.portions.add(portion1)

    print("Effective font height just after creation:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Effective font height after setting entire presentation default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[0].portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    paragraph.portions[1].portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    print("Portion #0:", portion0.portion_format.get_effective().font_height)
    print("Portion #1:", portion1.portion_format.get_effective().font_height)

    presentation.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```

## **Получить эффективный формат заливки таблицы**

С помощью Aspose.Slides for Python via .NET можно получить эффективное форматирование заливки для различных логических частей таблицы. Класс [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) содержит свойства эффективного форматирования заливки. Обратите внимание, что форматирование ячейки всегда имеет более высокий приоритет, чем форматирование строки, строка — выше, чем столбца, а столбец — выше, чем вся таблица.

Следовательно, свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) в конечном итоге используются для отрисовки таблицы. Ниже пример получения эффективного форматирования заливки для разных уровней таблицы:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	table = presentation.slides[0].shapes[0]

	table_format_effective = table.table_format.get_effective()
	row_format_effective = table.rows[0].row_format.get_effective()
	column_format_effective = table.columns[0].column_format.get_effective()
	cell_format_effective = table[0, 0].cell_format.get_effective()

	table_fill_format_effective = table_format_effective.fill_format
	row_fill_format_effective = row_format_effective.fill_format
	column_fill_format_effective = column_format_effective.fill_format
	cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**Как определить, что я получил «снимок», а не «живой объект», и когда следует снова считывать эффективные свойства?**

Объекты EffectiveData — это неизменяемые снимки вычисленных значений на момент вызова. Если вы изменяете локальные или унаследованные настройки фигуры, получите эффективные данные заново, чтобы увидеть обновлённые значения.

**Влияет ли изменение макета/главного слайда на уже полученные эффективные свойства?**

Да, но только после повторного чтения. Уже полученный объект EffectiveData не обновляется автоматически — запросите его снова после изменения макета или главного слайда.

**Можно ли изменять значения через EffectiveData?**

Нет. EffectiveData доступен только для чтения. Вносите изменения в локальные объекты форматирования (фигура/текст/3D и т.д.), а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне фигуры, макета/главного слайда и глобальных настроек?**

Эффективное значение определяется механизмом по умолчанию (стандартные значения PowerPoint/Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**По эффективному значению шрифта можно ли определить, какой уровень предоставил размер или гарнитуру?**

Не напрямую. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения в части/абзаце/текстовом фрейме и стили текста на макете/главном слайде/презентации, чтобы увидеть, где первое явное определение находится.

**Почему значения EffectiveData иногда совпадают с локальными?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте EffectiveData, когда нужен «как отрендерено» результат после применения всего наследования (например, для согласования цветов, отступов или размеров). Если нужно изменить форматирование на конкретном уровне, модифицируйте локальные свойства и, при необходимости, перечитайте EffectiveData для подтверждения результата.