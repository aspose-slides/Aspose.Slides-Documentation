---
title: Форматирование текста PowerPoint в Python
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/python-net/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- межбуквенный интервал
- свойства шрифта
- семейство шрифтов
- поворот текста
- угол поворота
- текстовый фрейм
- межстрочный интервал
- свойство автоподгонки
- якорь текстового фрейма
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как форматировать и оформлять текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Настраивайте шрифты, цвета, выравнивание и многое другое с помощью мощных примеров кода на Python."
---

## **Подсветка текста**

Метод `highlight_text` в классе [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) позволяет подсвечивать часть текста фоновым цветом, используя образец текста, аналогично инструменту Text Highlight Color в PowerPoint 2019.

В следующем фрагменте кода показано, как использовать эту возможность:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```


## **Подсветка текста с помощью регулярных выражений**

Метод `highlight_regex` класса [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) позволяет подсвечивать часть текста фоновым цветом с помощью регулярного выражения, аналогично инструменту Text Highlight Color в PowerPoint 2019.

В следующем фрагменте кода показано, как использовать эту возможность:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка фонового цвета текста**

Aspose.Slides позволяет задать предпочитаемый фоновый цвет для текста. Приведённый ниже код на Python показывает, как установить фоновый цвет для всего текста:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        portion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


Этот код на Python показывает, как установить фоновый цвет только для части текста:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Black")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Red ")
    
    portion3 = slides.Portion("Black")
    portion3.portion_format.font_bold = 1
    
    para.portions.add(portion1)
    para.portions.add(portion2)
    para.portions.add(portion3)
    autoShape.text_frame.paragraphs.add(para)
    
    pres.save("text.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("text.pptx") as pres:
    autoShape = pres.slides[0].shapes[0]

    for portion in autoShape.text_frame.paragraphs[0].portions:
        print (portion.text)

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Red' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **Выравнивание абзацев текста**

Форматирование текста является ключевым элементом при создании документов или презентаций. Aspose.Slides for Python via .NET поддерживает добавление текста на слайды; в этом разделе мы посмотрим, как управлять выравниванием абзацев на слайде. Выполните следующие шаги для выравнивания абзацев текста с помощью Aspose.Slides for Python via .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к заполняющим формам на слайде и приведите их к типу [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Из [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), предоставляемого [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/), получите абзац, который необходимо выровнять.
1. Выровняйте абзац. Абзац может быть выровнен `LEFT`, `RIGHT`, `CENTER`, `JUSTIFY`, `JUSTIFY_LOW` или `DISTRIBUTED`.
1. Сохраните изменённую презентацию в файл PPTX.

Реализация этих шагов показана ниже.
```py
import aspose.slides as slides

# Создайте объект Presentation, представляющий файл PPTX
with slides.Presentation("ParagraphsAlignment.pptx") as presentation:
    # Получаем первый слайд
    slide = presentation.slides[0]

    # Получаем первый и второй заполнители на слайде и приводим их к типу AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Изменяем текст в обоих заполнителях
    tf1.text = "Center Align by Aspose"
    tf2.text = "Center Align by Aspose"

    # Получаем первый абзац из заполнителей
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Выравниваем абзац текста по центру
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # Сохраняем презентацию в файл PPTX
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка прозрачности текста**

В этом разделе демонстрируется, как задать свойство прозрачности для любой текстовой формы с помощью Aspose.Slides for Python via .NET. Чтобы установить прозрачность текста, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд.
1. Задайте цвет тени.
1. Сохраните презентацию в файл PPTX.

Реализация этих шагов приведена ниже.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - transparency is: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # установить прозрачность в ноль процентов
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка межбуквенного интервала текста**

Aspose.Slides позволяет регулировать интервал между символами в текстовом поле. Это даёт возможность контролировать визуальную плотность строки или блока текста, расширяя или сужая расстояние между символами.

В приведённом ниже примере Python показано, как расширить интервал для одной строки текста и сжать его для другой:
```python
import aspose.slides as slides

with slides.Presentation("in.pptx") as pres:

    textBox1 = pres.slides[0].shapes[0]
    textBox2 = pres.slides[0].shapes[1]

    textBox1.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = 20 # расширить
    textBox2.text_frame.paragraphs[0].paragraph_format.default_portion_format.spacing = -2 # сжать

    pres.save("out.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление свойствами шрифта абзаца**

Презентации обычно содержат как текст, так и изображения. Текст можно форматировать различными способами — либо для подсветки отдельных разделов и слов, либо в соответствии с корпоративными стилями. Форматирование текста помогает пользователям изменить внешний вид содержимого презентации.

В этом разделе демонстрируется, как с помощью Aspose.Slides for Python via .NET настроить свойства шрифта абзацев в тексте слайдов. Чтобы управлять свойствами шрифта абзаца с помощью Aspose.Slides for Python via .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к заполняющим формам на слайде и приведите их к типу [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Получите абзац из [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), предоставляемого [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Выровняйте абзац по ширине.
1. Получите доступ к текстовой части абзаца.
1. Определите шрифт, используя [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), и задайте шрифт текстовой части соответственно.
   1. Установите шрифт полужирным.
   1. Установите шрифт курсивом.
1. Установите цвет шрифта, используя [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/), предоставляемый объектом [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов показана ниже. Он берёт обычную презентацию и применяет форматирование шрифтов к одному из слайдов.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте объект Presentation, представляющий файл PPTX
with slides.Presentation("FontProperties.pptx") as pres:
    # Доступ к слайду по его позиции
    slide = pres.slides[0]

    # Получаем первый и второй заполнители на слайде и приводим их к типу AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Получаем первый абзац
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Получаем первую часть
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # Определяем новые шрифты
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # Применяем новые шрифты к части
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # Устанавливаем шрифт полужирным
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # Устанавливаем шрифт курсивом
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # Устанавливаем цвет шрифта
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    #Записать PPTX на диск
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление семейством шрифтов текста**

Объекты [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) используются для хранения текста с одинаковым стилем внутри абзаца. В этом разделе показано, как с помощью Aspose.Slides for Python создать текстовое поле, добавить в него текст и задать конкретный шрифт вместе с различными другими свойствами семейства шрифтов.

Чтобы создать текстовое поле и задать свойства шрифта текста внутри него:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его индексу.
1. Добавьте к слайду [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) типа `RECTANGLE`.
1. Удалите стиль заливки, связанный с [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) AutoShape.
1. Добавьте текст в [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Получите объект [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/), связанный с [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Определите шрифт, который будет использоваться для [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Задайте дополнительные свойства шрифта, такие как полужирный, курсив, подчёркивание, цвет и высота, используя соответствующие свойства объекта [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/).
1. Сохраните изменённую презентацию в файл PPTX.

Реализация вышеуказанных шагов показана ниже.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать объект Presentation
with slides.Presentation() as presentation:
    # Получить первый слайд
    sld = presentation.slides[0]

    # Добавить AutoShape типа Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Удалить любой стиль заливки, связанный с AutoShape
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Получить TextFrame, связанный с AutoShape
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # Получить Portion, связанный с TextFrame
    port = tf.paragraphs[0].portions[0]

    # Установить шрифт для Portion
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Установить свойство Bold у шрифта
    port.portion_format.font_bold = 1

    # Установить свойство Italic у шрифта
    port.portion_format.font_italic = 1

    # Установить свойство Underline у шрифта
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Установить высоту шрифта
    port.portion_format.font_height = 25

    # Установить цвет шрифта
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Сохранить PPTX на диск 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка размера шрифта текста**

Aspose.Slides позволяет задать предпочитаемый размер шрифта для существующего текста в абзаце, а также для любого текста, который может быть добавлен в абзац позже.

В следующем примере на Python показано, как установить размер шрифта для текста, содержащегося в абзаце:
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Получает первую форму, например.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Получает первый абзац, например.
        paragraph = shape.text_frame.paragraphs[0]

        # Устанавливает размер шрифта по умолчанию 20 пунктов для всех частей текста в абзаце.
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Устанавливает размер шрифта 20 пунктов для текущих частей текста в абзаце.
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Поворот текста**

Aspose.Slides for Python via .NET позволяет разработчикам вращать текст. Текст можно задать как `HORIZONTAL`, `VERTICAL`, `VERTICAL270`, `WORD_ART_VERTICAL`, `EAST_ASIAN_VERTICAL`, `MONGOLIAN_VERTICAL` или `WORD_ART_VERTICAL_RIGHT_TO_LEFT`.

Чтобы повернуть текст в любом [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите доступ к первому слайду.
1. Добавьте форму к слайду.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Примените нужный поворот текста.
1. Сохраните файл на диск.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Получить первый слайд 
    slide = presentation.slides[0]

    # Добавить AutoShape типа Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Добавить TextFrame к прямоугольнику
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Доступ к текстовому фрейму
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Создать объект Paragraph для текстового фрейма
    para = txtFrame.paragraphs[0]

    # Создать объект Portion для абзаца
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Сохранить презентацию
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка пользовательского угла поворота для TextFrame**

Aspose.Slides for Python via .NET поддерживает установку пользовательского угла поворота для [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). В этом разделе мы покажем, как использовать свойство `rotation_angle` в Aspose.Slides.

Чтобы задать свойство `rotation_angle`, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Добавьте к слайду диаграмму.
1. Задайте свойство `rotation_angle`.
1. Сохраните презентацию в файл PPTX.

В примере ниже мы задаём свойство `rotation_angle`.
```py
import aspose.slides as slides

# Создать экземпляр класса Presentation
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Custom title").text_frame_format.rotation_angle = -30

    # Сохранить презентацию
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет свойства `space_after`, `space_before` и `space_within` в классе [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) для управления межстрочным интервалом абзаца. Эти свойства работают следующим образом:

* Чтобы задать межстрочный интервал в процентах, используйте положительное значение.
* Чтобы задать интервал в пунктах, используйте отрицательное значение.

Например, чтобы применить интервал 16 pt перед абзацем, задайте свойство `space_before` со значением `-16`.

Как задать межстрочный интервал для конкретного абзаца:

1. Загрузите презентацию, содержащую [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) с текстом.
1. Получите ссылку на слайд по его индексу.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Получите доступ к [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/).
1. Задайте нужные свойства абзаца.
1. Сохраните презентацию.

В следующем примере на Python показано, как задать межстрочный интервал для абзаца:
```py
import aspose.slides as slides

# Создать объект класса Presentation
with slides.Presentation("Fonts.pptx") as presentation:

    # Получить ссылку на слайд по его индексу
    sld = presentation.slides[0]

    # Получить доступ к TextFrame
    tf1 = sld.shapes[0].text_frame

    # Получить доступ к Paragraph
    para1 = tf1.paragraphs[0]

    # Установить свойства Paragraph
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Сохранить презентацию
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка свойства AutofitType для TextFrame**

В этом разделе мы рассмотрим различные свойства форматирования [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), включая установку `autofit_type`, настройку привязки текста и поворот текста в презентации.

Aspose.Slides for Python via .NET позволяет задать свойство `autofit_type` любого [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Значение `autofit_type` может быть `NORMAL` или `SHAPE`:

* При значении `NORMAL` форма остаётся неизменной, а текст автоматически подгоняется под её размеры.
* При значении `SHAPE` форма изменяется так, чтобы вместить только необходимый текст.

Чтобы задать свойство `autofit_type` для [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите доступ к первому слайду.
1. Добавьте к слайду форму.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Задайте `autofit_type` для [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Сохраните файл на диск.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation
with slides.Presentation() as presentation:

    # Обратиться к первому слайду 
    slide = presentation.slides[0]

    # Добавить AutoShape типа Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Добавить TextFrame к прямоугольнику
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Доступ к текстовому фрейму
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Создать объект Paragraph для текстового фрейма
    para = txtFrame.paragraphs[0]

    # Создать объект Portion для абзаца
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Сохранить презентацию
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **Установка привязки TextFrame**

Aspose.Slides for Python via .NET позволяет задавать позицию привязки любого [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Свойство [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) указывает, где будет размещён текст внутри формы. Оно может быть `TOP`, `CENTER`, `BOTTOM`, `JUSTIFIED` или `DISTRIBUTED`.

Чтобы задать привязку [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите доступ к первому слайду.
1. Добавьте к слайду форму.
1. Получите доступ к [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Задайте [TextAnchorType](https://reference.aspose.com/slides/python-net/aspose.slides/textanchortype/) для [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).
1. Сохраните файл на диск.
```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создать экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Получить первый слайд 
    slide = presentation.slides[0]

    # Добавить AutoShape типа Rectangle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Добавить TextFrame к прямоугольнику
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Доступ к текстовому фрейму
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Создать объект Paragraph для текстового фрейма
    para = txtFrame.paragraphs[0]

    # Создать объект Portion для абзаца
    portion = para.portions[0]
    portion.text = "A quick brown fox jumps over the lazy dog. A quick brown fox jumps over the lazy dog."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Сохранить презентацию
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка стиля текста по умолчанию**

Если необходимо применить одинаковое форматирование текста ко всем текстовым элементам презентации, используйте свойство `default_text_style` класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и задайте нужное форматирование.

В примере ниже показано, как установить шрифт по умолчанию полужирным, размером 14 pt, для всего текста на каждом слайде новой презентации.
```py
with slides.Presentation() as presentation:
    # Получить формат абзаца верхнего уровня.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```


## **Извлечение текста с эффектом All-Caps**

В PowerPoint применение эффекта **All Caps** делает текст заглавными буквами на слайде, даже если он был введён строчными. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы обработать это, проверьте [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) — если он указывает `ALL`, просто преобразуйте полученную строку в верхний регистр, чтобы ваш вывод соответствовал тому, что видит пользователь на слайде.

Предположим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект All Caps](all_caps_effect.png)

В примере кода ниже показано, как извлечь текст с применённым эффектом **All Caps**:
```py
with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```


Вывод:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


{{% alert color="primary" %}}
Aspose предоставляет простой, [free online PowerPoint editing service](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Часто задаваемые вопросы**

**Могу ли я применить различное форматирование к отдельным частям текста внутри одного абзаца (например, сделать полужирным лишь несколько слов), и как это взаимодействует со стилями, унаследованными от макетов и тем?**

Да. Форматирование задаётся на уровне «текстовой части» внутри абзаца и переопределяет стиль темы/макета только для выбранных фрагментов. При изменении темы обновятся лишь те регионы, у которых нет явного локального форматирования.

**Как работают шрифты в Linux и в Docker‑контейнерах, где системные шрифты не установлены?**

Библиотека использует поиск и замену шрифтов. На системах без шрифтов следует явно указать [каталоги шрифтов](/slides/ru/python-net/custom-font/) и/или настроить [таблицу замен](/slides/ru/python-net/font-substitution/), чтобы избежать падения к неподходящим типам и смещения разметки.

**Чем отличается форматирование текста в заполнителях от форматирования в обычных автошейпах?**

Заполнители унаследуют стили от слайд‑мастеров и макетов сильнее, чем обычные автошейпы. Локальные изменения в заполнителях возможны, но при смене макета они, как правило, возвращаются к стилям темы, если вы не задали жесткое переопределение на уровне text‑portion.