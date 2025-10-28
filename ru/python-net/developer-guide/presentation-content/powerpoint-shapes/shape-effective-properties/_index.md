---
title: Получение эффективных свойств фигур из презентаций с помощью Python
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/python-net/shape-effective-properties/
keywords:
- свойства формы
- свойства камеры
- световая установка
- форма фаски
- текстовый кадр
- стиль текста
- высота шрифта
- формат заполнения
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Python via .NET вычисляет и применяет эффективные свойства фигур для точного отображения PowerPoint и OpenDocument."
---

## **Обзор**

В этой статье вы узнаете о понятиях **эффективных** и **локальных** свойств. Когда значения задаются непосредственно на следующих уровнях:

1. В свойствах текста в части текста на слайде.  
2. В стиле текста прототипной фигуры на макете или мастере слайда (если у текстового кадра есть стиль).  
3. В глобальных параметрах текста презентации.  

эти значения называют **локальными**. На любом уровне **локальные** значения могут быть определены или опущены. Когда приложению необходимо определить, как должна выглядеть часть текста, оно использует **эффективные** значения. Получить эффективные значения можно, вызвав метод `get_effective` у локального формата.

Следующий пример демонстрирует, как получить эффективные значения для формата текстового кадра и формата части текста.

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    local_portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    effective_portion_format = local_portion_format.get_effective()
```

## **Получение эффективных свойств камеры**

Aspose.Slides for Python via .NET позволяет извлекать эффективные свойства камеры. Класс [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) представляет неизменяемый объект, содержащий эти свойства. Экземпляр [ICameraEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icameraeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для класса [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Следующий пример показывает, как получить эффективные свойства камеры:

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

## **Получение эффективных свойств световой установки**

Aspose.Slides for Python via .NET позволяет извлекать эффективные свойства световой установки. Класс [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) представляет неизменяемый объект, содержащий эти свойства. Экземпляр [ILightRigEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ilightrigeffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для класса [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Следующий пример показывает, как получить эффективные свойства световой установки:

```py
import aspose.slides as slides

with slides.Presentation("Presentation1.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

	three_d_effective_data = shape.three_d_format.get_effective()

	print("= Effective light rig properties =")
	print("Type:", str(three_d_effective_data.light_rig.light_type))
	print("Direction:", str(three_d_effective_data.light_rig.direction))
```

## **Получение эффективных свойств фаски фигуры**

Aspose.Slides for Python via .NET позволяет извлекать эффективные свойства фаски фигуры. Класс [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) представляет неизменяемый объект, содержащий свойства рельефа (фаски) фигуры. Экземпляр [IShapeBevelEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ishapebeveleffectivedata/) доступен через [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ithreedformateffectivedata/), который предоставляет эффективные значения для класса [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/).

Следующий пример показывает, как получить эффективные свойства фаски фигуры:

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

## **Получение эффективных свойств текстового кадра**

С помощью Aspose.Slides for Python via .NET можно получить эффективные свойства текстового кадра. Класс [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformateffectivedata/) содержит эффективные свойства форматирования текстового кадра.

Следующий пример демонстрирует, как получить эффективные свойства форматирования текстового кадра:

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

## **Получение эффективных свойств стиля текста**

С помощью Aspose.Slides for Python via .NET можно получить эффективные свойства стиля текста. Класс [ITextStyleEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/itextstyleeffectivedata/) содержит эффективные свойства стиля текста.

Следующий пример демонстрирует, как получить эффективные свойства стиля текста:

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

## **Получение эффективной высоты шрифта**

С помощью Aspose.Slides for Python via .NET можно получить эффективную высоту шрифта. Пример ниже показывает, как меняется эффективная высота шрифта у части текста при задавании локальных значений высоты шрифта на разных уровнях структуры презентации.

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

## **Получение эффективного формата заполнения таблицы**

С помощью Aspose.Slides for Python via .NET можно получить эффективное форматирование заполнения для различных логических частей таблицы. Класс [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) содержит эффективные свойства форматирования заполнения. Обратите внимание, что форматирование ячейки всегда имеет более высокий приоритет, чем форматирование строки, строка — более высокий, чем столбец, а столбец — более высокий, чем вся таблица.

Поэтому свойства [ICellFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/icellformateffectivedata/) в конечном итоге используются для отрисовки таблицы. Ниже показан пример получения эффективного форматирования заполнения для разных уровней таблицы:

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

**Как понять, что я получил «снимок», а не «живой объект», и когда следует снова считывать эффективные свойства?**

Объекты EffectiveData являются неизменяемыми снимками вычисленных значений на момент вызова. Если вы меняете локальные или унаследованные настройки фигуры, получайте эффективные данные снова, чтобы увидеть обновлённые значения.

**Влияет ли изменение макета/мастер‑слайда на уже полученные эффективные свойства?**

Да, но только после повторного чтения. Уже полученный объект EffectiveData сам не обновляется — запросите его снова после изменения макета или мастера.

**Можно ли изменять значения через EffectiveData?**

Нет. EffectiveData доступен только для чтения. Вносите изменения в локальные объекты форматирования (фигура/текст/3D и т.д.), а затем снова получайте эффективные значения.

**Что происходит, если свойство не задано на уровне фигуры, макета/мастера и глобальных настроек?**

Эффективное значение определяется механизмом по умолчанию (стандартные параметры PowerPoint/Aspose.Slides). Это разрешённое значение становится частью снимка EffectiveData.

**Можно ли по эффективному значению шрифта определить, на каком уровне была задана высота или гарнитура?**

Не напрямую. EffectiveData возвращает окончательное значение. Чтобы найти источник, проверьте локальные значения в части/абзаце/текстовом кадре и стили текста на макете/мастере/презентации, чтобы увидеть, где впервые определено явное значение.

**Почему значения EffectiveData иногда совпадают с локальными?**

Потому что локальное значение оказалось окончательным (не потребовалось наследование с более высокого уровня). В таких случаях эффективное значение совпадает с локальным.

**Когда следует использовать эффективные свойства, а когда работать только с локальными?**

Используйте EffectiveData, когда нужен результат «как он будет отрисован» после применения всех уровней наследования (например, для согласования цветов, отступов или размеров). Если необходимо изменить форматирование на конкретном уровне, изменяйте локальные свойства и, при необходимости, повторно считывайте EffectiveData для проверки результата.