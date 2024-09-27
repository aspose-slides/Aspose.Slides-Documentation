---
title: Эффективные свойства формы
type: docs
weight: 50
url: /ru/python-net/shape-effective-properties/
keywords: "Свойства формы, Свойства камеры, световая установка, фаска формы, текстовая рамка, стиль текста, значение высоты шрифта, формат заливки для таблицы, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Получите эффективные свойства форм в презентациях PowerPoint на Python"
---

В этой теме мы обсудим **эффективные** и **локальные** свойства. Когда мы устанавливаем значения непосредственно на этих уровнях

1. В свойствах порции на слайде порции.
1. В прототипе текста свойств формы на макете или мастер-слайде (если форма текстовой рамки порции имеет таковую).
1. В глобальных текстовых настройках презентации.

то эти значения называются **локальными** значениями. На любом уровне **локальные** значения могут быть определены или опущены. Но в конце концов, когда приложению нужно знать, как должна выглядеть порция, оно использует **эффективные** значения. Вы можете получить эффективные значения, используя метод **getEffective()** из локального формата.

Следующий пример показывает, как получить эффективные значения.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    localTextFrameFormat = shape.text_frame.text_frame_format
    effectiveTextFrameFormat = localTextFrameFormat.get_effective()

    localPortionFormat = shape.text_frame.paragraphs[0].portions[0].portion_format
    effectivePortionFormat = localPortionFormat.get_effective()
```



## **Получить эффективные свойства камеры**
Aspose.Slides для Python через .NET позволяет разработчикам получать эффективные свойства камеры. Для этой цели был добавлен класс **CameraEffectiveData** в Aspose.Slides. Класс CameraEffectiveData представляет собой неизменяемый объект, который содержит эффективные свойства камеры. Экземпляр класса **CameraEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий пример кода показывает, как получить эффективные свойства для камеры.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Эффективные свойства камеры =")
	print("Тип: " + str(threeDEffectiveData.camera.camera_type))
	print("Угол обзора: " + str(threeDEffectiveData.camera.field_of_view_angle))
	print("Масштаб: " + str(threeDEffectiveData.camera.zoom))
```


## **Получить эффективные свойства световой установки**
Aspose.Slides для Python через .NET позволяет разработчикам получать эффективные свойства световой установки. Для этой цели был добавлен класс **LightRigEffectiveData** в Aspose.Slides. Класс LightRigEffectiveData представляет собой неизменяемый объект, который содержит эффективные свойства световой установки. Экземпляр класса **LightRigEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий пример кода показывает, как получить эффективные свойства для световой установки.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Эффективные свойства световой установки =")
	print("Тип: " + str(threeDEffectiveData.light_rig.light_type))
	print("Направление: " + str(threeDEffectiveData.light_rig.direction))
```


## **Получить эффективные свойства фаски формы**
Aspose.Slides для Python через .NET позволяет разработчикам получать эффективные свойства фаски формы. Для этой цели был добавлен класс **ShapeBevelEffectiveData** в Aspose.Slides. Класс ShapeBevelEffectiveData представляет собой неизменяемый объект, который содержит эффективные свойства рельефа лицевой стороны формы. Экземпляр класса **ShapeBevelEffectiveData** используется как часть класса **ThreeDFormatEffectiveData**, который является парой эффективных значений для класса ThreeDFormat.

Следующий пример кода показывает, как получить эффективные свойства для фаски формы.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	threeDEffectiveData = pres.slides[0].shapes[0].three_d_format.get_effective()

	print("= Эффективные свойства рельефа верхней стороны формы =")
	print("Тип: " + str(threeDEffectiveData.bevel_top.bevel_type))
	print("Ширина: " + str(threeDEffectiveData.bevel_top.width))
	print("Высота: " + str(threeDEffectiveData.bevel_top.height))
```



## **Получить эффективные свойства текстовой рамки**
Используя Aspose.Slides для Python через .NET, вы можете получить эффективные свойства текстовой рамки. Для этой цели был добавлен класс **TextFrameFormatEffectiveData** в Aspose.Slides, который содержит эффективные свойства форматирования текстовой рамки.

Следующий пример кода показывает, как получить эффективные свойства форматирования текстовой рамки.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
	shape = pres.slides[0].shapes[0]

	textFrameFormat = shape.text_frame.text_frame_format
	effectiveTextFrameFormat = textFrameFormat.get_effective()


	print("Тип анкоринга: " + str(effectiveTextFrameFormat.anchoring_type))
	print("Тип автоформатирования: " + str(effectiveTextFrameFormat.autofit_type))
	print("Вертикальный тип текста: " + str(effectiveTextFrameFormat.text_vertical_type))
	print("Поля")
	print("   Слева: " + str(effectiveTextFrameFormat.margin_left))
	print("   Сверху: " + str(effectiveTextFrameFormat.margin_top))
	print("   Справа: " + str(effectiveTextFrameFormat.margin_right))
	print("   Снизу: " + str(effectiveTextFrameFormat.margin_bottom))
```



## **Получить эффективные свойства стиля текста**
Используя Aspose.Slides для Python через .NET, вы можете получить эффективные свойства стиля текста. Для этой цели был добавлен класс **TextStyleEffectiveData** в Aspose.Slides, который содержит эффективные свойства стиля текста.

Следующий пример кода показывает, как получить эффективные свойства стиля текста.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation1.pptx") as pres:
    shape = pres.slides[0].shapes[0]

    effectiveTextStyle = shape.text_frame.text_frame_format.text_style.get_effective()

    for i in range(8):
        effectiveStyleLevel = effectiveTextStyle.get_level(i)
        print("= Эффективное форматирование абзаца для уровня стиля #" + str(i) + " =")

        print("Глубина: " + str(effectiveStyleLevel.depth))
        print("Отступ: " + str(effectiveStyleLevel.indent))
        print("Выравнивание: " + str(effectiveStyleLevel.alignment))
        print("Выравнивание шрифта: " + str(effectiveStyleLevel.font_alignment))

```


## **Получить эффективное значение высоты шрифта**
Используя Aspose.Slides для Python через .NET, вы можете получить эффективные свойства высоты шрифта. Вот код, демонстрирующий изменение эффективного значения высоты шрифта порции после установки локальных значений высоты шрифта на разных уровнях структуры презентации.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    newShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    newShape.add_text_frame("")
    newShape.text_frame.paragraphs[0].portions.clear()

    portion0 = slides.Portion("Пример текста с первой порцией")
    portion1 = slides.Portion(" и второй порцией.")

    newShape.text_frame.paragraphs[0].portions.add(portion0)
    newShape.text_frame.paragraphs[0].portions.add(portion1)

    print("Эффективная высота шрифта сразу после создания:")
    print("Порция #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Порция #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.default_text_style.get_level(0).default_portion_format.font_height = 24

    print("Эффективная высота шрифта после установки высоты шрифта по умолчанию для всей презентации:")
    print("Порция #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Порция #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 40

    print("Эффективная высота шрифта после установки высоты шрифта по умолчанию для абзаца:")
    print("Порция #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Порция #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 55

    print("Эффективная высота шрифта после установки высоты шрифта порции #0:")
    print("Порция #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Порция #1: " + str(portion1.portion_format.get_effective().font_height))

    newShape.text_frame.paragraphs[0].portions[1].portion_format.font_height = 18

    print("Эффективная высота шрифта после установки высоты шрифта порции #1:")
    print("Порция #0: " + str(portion0.portion_format.get_effective().font_height))
    print("Порция #1: " + str(portion1.portion_format.get_effective().font_height))

    pres.save("SetLocalFontHeightValues.pptx",slides.export.SaveFormat.PPTX)
```


## **Получить эффективный формат заливки для таблицы**
Используя Aspose.Slides для Python через .NET, вы можете получить эффективное форматирование заливки для различных логических частей таблицы. Для этой цели был добавлен интерфейс **IFillFormatEffectiveData** в Aspose.Slides, который содержит эффективные свойства форматирования заливки. Обратите внимание, что форматирование ячеек всегда имеет более высокий приоритет, чем форматирование строки, строка имеет более высокий приоритет, чем столбец, а столбец выше, чем вся таблица.

Таким образом, в конце концов свойства **CellFormatEffectiveData** всегда используются для рендеринга таблицы. Следующий пример кода показывает, как получить эффективное форматирование заливки для различных логических частей таблицы.

```py
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
	tbl = pres.slides[0].shapes[0]
	tableFormatEffective = tbl.table_format.get_effective()
	rowFormatEffective = tbl.rows[0].row_format.get_effective()
	columnFormatEffective = tbl.columns[0].column_format.get_effective()
	cellFormatEffective = tbl[0, 0].cell_format.get_effective()

	tableFillFormatEffective = tableFormatEffective.fill_format
	rowFillFormatEffective = rowFormatEffective.fill_format
	columnFillFormatEffective = columnFormatEffective.fill_format
	cellFillFormatEffective = cellFormatEffective.fill_format
```