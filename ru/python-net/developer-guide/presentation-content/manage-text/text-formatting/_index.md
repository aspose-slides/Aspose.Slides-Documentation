---
title: Форматирование текста
type: docs
weight: 50
url: /ru/python-net/text-formatting/
keywords:
- выделение текста
- регулярное выражение
- выравнивание абзацев текста
- прозрачность текста
- свойства шрифта абзаца
- семейство шрифтов
- поворот текста
- кастомный угол поворота
- текстовый фрейм
- интервал между строками
- свойство авторазмера
- анкор текстового фрейма
- табуляция текста
- стиль текста по умолчанию
- Python
- Aspose.Slides для Python
description: "Управление и манипуляция свойствами текста и текстовых фреймов в Python"
---

## **Выделение текста**
Новый метод HighlightText был добавлен в интерфейс ITextFrame и класс TextFrame.

Он позволяет выделять часть текста с помощью фона, используя текстовый шаблон, аналогично инструменту выделения текста в PowerPoint 2019.

Приведенный ниже фрагмент кода показывает, как использовать эту функцию:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    presentation.slides[0].shapes[0].text_frame.highlight_text("title", draw.Color.light_blue)

    opts = slides.TextHighlightingOptions()
    opts.whole_words_only = True
    presentation.slides[0].shapes[0].text_frame.highlight_text("to", draw.Color.violet, opts)

    presentation.save("SomePresentation-out2.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

Aspose предоставляет простой, [бесплатный онлайн-сервис редактирования PowerPoint](https://products.aspose.app/slides/editor).

{{% /alert %}} 


## **Выделение текста с использованием регулярных выражений**
Новый метод HighlightRegex был добавлен в интерфейс ITextFrame и класс TextFrame.

Он позволяет выделять часть текста с помощью фона, используя регулярные выражения, аналогично инструменту выделения текста в PowerPoint 2019.

Приведенный ниже фрагмент кода показывает, как использовать эту функцию:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "SomePresentation.pptx") as presentation:
    options = slides.TextHighlightingOptions()

    presentation.slides[0].shapes[0].text_frame.highlight_regex("\\b[^\s]{5,}\\b", draw.Color.blue, options) 
    presentation.save("SomePresentation-out3.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка цвета фона текста**

Aspose.Slides позволяет указывать предпочитаемый цвет для фона текста.

Этот код на Python показывает, как установить цвет фона для всего текста: 

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Черный")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Красный ")
    
    portion3 = slides.Portion("Черный")
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

Этот код на Python показывает, как установить цвет фона только для части текста:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    autoShape.text_frame.paragraphs.clear()

    para = slides.Paragraph()

    portion1 = slides.Portion("Черный")
    portion1.portion_format.font_bold = 1
    
    portion2 = slides.Portion(" Красный ")
    
    portion3 = slides.Portion("Черный")
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

    redPortion = list(p for p in autoShape.text_frame.paragraphs[0].portions if 'Красный' in p.text)[0]
    redPortion.portion_format.highlight_color.color = draw.Color.blue

    pres.save("text-red.pptx", slides.export.SaveFormat.PPTX)
```


## **Выравнивание текстовых абзацев**
Форматирование текста является одним из ключевых элементов при создании любых документов или презентаций. Мы знаем, что Aspose.Slides для Python через .NET поддерживает добавление текста на слайды, но в этой теме мы увидим, как можем контролировать выравнивание текстовых абзацев на слайде. Пожалуйста, следуйте приведенным ниже шагам для выравнивания текстовых абзацев с использованием Aspose.Slides для Python через .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Получите доступ к формам-заполнителям, присутствующим на слайде, и приведите их к типу AutoShape.
4. Получите абзац (который нужно выровнять) из TextFrame, предоставленного AutoShape.
5. Выравните абзац. Абзац может быть выровнен по правому, левому, центру и в justified.
6. Запишите измененную презентацию как файл PPTX.

Имплементация приведенных выше шагов представлена ниже.

```py
import aspose.slides as slides

# Создайте объект Presentation, который представляет файл PPTX
with slides.Presentation(path + "ParagraphsAlignment.pptx") as presentation:
    # Получаем первый слайд
    slide = presentation.slides[0]

    # Получаем первый и второй заполнители на слайде и приводим их к типу AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Изменяем текст в обоих заполнителях
    tf1.text = "Центрирование с помощью Aspose"
    tf2.text = "Центрирование с помощью Aspose"

    # Получаем первый абзац заполнителей
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Выравниваем текстовый абзац по центру
    para1.paragraph_format.alignment = slides.TextAlignment.CENTER
    para2.paragraph_format.alignment = slides.TextAlignment.CENTER

    # Записываем презентацию как файл PPTX
    presentation.save("Centeralign_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка прозрачности для текста**
Эта статья демонстрирует, как установить свойство прозрачности для любой текстовой формы с использованием Aspose.Slides для Python через .NET. Чтобы установить прозрачность для текста, пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд.
3. Установите цвет тени.
4. Запишите презентацию как файл PPTX.

Имплементация приведенных выше шагов представлена ниже.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "transparency.pptx") as pres:
    shape = pres.slides[0].shapes[0]
    effects = shape.text_frame.paragraphs[0].portions[0].portion_format.effect_format

    outerShadowEffect = effects.outer_shadow_effect

    shadowColor = outerShadowEffect.shadow_color.color
    print("{color} - прозрачность равна: {value}".format(color = shadowColor, value = (shadowColor.a / 255) * 100))
    # устанавливаем прозрачность на ноль процентов
    outerShadowEffect.shadow_color.color = draw.Color.from_argb(255, shadowColor)

    pres.save("transparency-2.pptx", slides.export.SaveFormat.PPTX)
```


## **Настройка интервала между буквами для текста**

Aspose.Slides позволяет вам устанавливать расстояние между буквами в текстовом поле. Таким образом, вы можете настроить визуальную плотность строки или блока текста, расширяя или сжимая расстояние между символами.

Этот код на Python показывает, как расширить интервал для одной строки текста и сжать интервал для другой строки: 

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
Презентации обычно содержат как текст, так и изображения. Текст можно форматировать различными способами, либо для выделения конкретных разделов и слов, либо для соблюдения корпоративных стилей. Форматирование текста помогает пользователям изменить вид и структуру содержания презентации. Эта статья показывает, как использовать Aspose.Slides для Python через .NET для настройки свойств шрифта абзацев текста на слайдах. Чтобы управлять свойствами шрифта абзаца с использованием Aspose.Slides для Python через .NET :

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Получите доступ к формам-заполнителям на слайде и приведите их к типу AutoShape.
1. Получите абзац из TextFrame, предоставленного AutoShape.
1. Выравните абзац.
1. Получите текстовый элемент абзаца.
1. Определите шрифт с помощью FontData и установите шрифт для текстового элемента соответственно.
   1. Установите шрифт в жирный.
   1. Установите шрифт в курсив.
1. Установите цвет шрифта, используя FillFormat, предоставленный объектом Portion.
1. Запишите измененную презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

Имплементация приведенных выше шагов приведена ниже. Она берет непримечательную презентацию и форматирует шрифты на одном из слайдов.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте объект Presentation, который представляет файл PPTX
with slides.Presentation(path + "FontProperties.pptx") as pres:
    # Получаем слайд по его положению на слайде
    slide = pres.slides[0]

    # Получаем первый и второй заполнители на слайде и приводим их к типу AutoShape
    tf1 = slide.shapes[0].text_frame
    tf2 = slide.shapes[1].text_frame

    # Получаем первый абзац
    para1 = tf1.paragraphs[0]
    para2 = tf2.paragraphs[0]

    # Получаем первый элемент
    port1 = para1.portions[0]
    port2 = para2.portions[0]

    # Определяем новые шрифты
    fd1 = slides.FontData("Elephant")
    fd2 = slides.FontData("Castellar")

    # Присваиваем новые шрифты порциям
    port1.portion_format.latin_font = fd1
    port2.portion_format.latin_font = fd2

    # Устанавливаем шрифт в жирный
    port1.portion_format.font_bold = 1
    port2.portion_format.font_bold = 1

    # Устанавливаем шрифт в курсив
    port1.portion_format.font_italic = 1
    port2.portion_format.font_italic = 1

    # Устанавливаем цвет шрифта
    port1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port1.portion_format.fill_format.solid_fill_color.color = draw.Color.purple
    port2.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port2.portion_format.fill_format.solid_fill_color.color = draw.Color.peru

    # Записываем PPTX на диск
    pres.save("WelcomeFont_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Управление семейством шрифтов текста**
Порция используется для отображения текста с одинаковым стилем форматирования в абзаце. Эта статья показывает, как использовать Aspose.Slides для Python, чтобы создать текстовое поле с некоторым текстом, а затем определить определенный шрифт и различные другие свойства в категории шрифтов. Чтобы создать текстовое поле и установить свойства шрифта текста в нем:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите ссылку на слайд, используя его индекс.
3. Добавьте AutoShape типа Прямоугольник на слайд.
4. Удалите стиль заливки, связанный с AutoShape.
5. Получите доступ к TextFrame AutoShape.
6. Добавьте текст в TextFrame.
7. Получите доступ к объекту Portion, связанному с TextFrame.
8. Определите шрифт, который будет использоваться для Portion.
9. Установите другие свойства шрифта, такие как жирный, курсив, подчеркивание, цвет и высота, используя соответствующие свойства, предоставленные объектом Portion.
10. Запишите измененную презентацию как файл PPTX.

Имплементация приведенных выше шагов представлена ниже.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр Presentation
with slides.Presentation() as presentation:
    # Получите первый слайд
    sld = presentation.slides[0]

    # Добавьте AutoShape типа Прямоугольник
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 50)

    # Удалите любой стиль заливки, связанный с AutoShape
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Получите доступ к TextFrame, связанному с AutoShape
    tf = ashp.text_frame
    tf.text = "Aspose TextBox"

    # Получите доступ к Portion, связанному с TextFrame
    port = tf.paragraphs[0].portions[0]

    # Установите шрифт для Portion
    port.portion_format.latin_font = slides.FontData("Times New Roman")

    # Установите жирный шрифт
    port.portion_format.font_bold = 1

    # Установите курсивный шрифт
    port.portion_format.font_italic = 1

    # Установите подчеркивание шрифта
    port.portion_format.font_underline = slides.TextUnderlineType.SINGLE

    # Установите высоту шрифта
    port.portion_format.font_height = 25

    # Установите цвет шрифта
    port.portion_format.fill_format.fill_type = slides.FillType.SOLID
    port.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Запишите PPTX на диск 
    presentation.save("SetTextFontProperties_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка размера шрифта для текста**

Aspose.Slides позволяет вам выбрать предпочитаемый размер шрифта для существующего текста в абзаце и другого текста, который может быть добавлен в абзац позже.

Этот код на Python показывает, как установить размер шрифта для текстов, содержащихся в абзаце: 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:

    # Получаем первый элемент, например.
    shape = presentation.slides[0].shapes[0]

    if type(shape) is slides.AutoShape:
        # Получаем первый абзац, например.
        paragraph = shape.text_frame.paragraphs[0]

        # Устанавливаем размер шрифта по умолчанию на 20 пунктов для всех текстовых элементов в абзаце. 
        paragraph.paragraph_format.default_portion_format.font_height = 20

        # Устанавливаем размер шрифта на 20 пунктов для текущих текстовых элементов в абзаце. 
        for portion in paragraph.portions:
            portion.portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)

```


## **Установка поворота текста**
Aspose.Slides для Python через .NET позволяет разработчикам поворачивать текст. Текст может быть установлен так, чтобы отображаться как Горизонтально, Вертикально, Вертикально270, WordArtVertical, EastAsianVertical, MongolianVertical или WordArtVerticalRightToLeft. Чтобы повернуть текст в любом TextFrame, пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите доступ к TextFrame.
5. Поверните текст.
6. Сохраните файл на диск.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Получите первый слайд 
    slide = presentation.slides[0]

    # Добавьте AutoShape типа Прямоугольник
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Добавьте TextFrame к прямоугольнику
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Получаем текстовый фрейм
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Создаем объект абзаца для текстового фрейма
    para = txtFrame.paragraphs[0]

    # Создаем объект Portion для абзаца
    portion = para.portions[0]
    portion.text = "Быстрая коричневая лисица перепрыгивает через ленивую собаку. Быстрая коричневая лисица перепрыгивает через ленивую собаку."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Сохраняем презентацию
    presentation.save("RotateText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка пользовательского угла поворота для TextFrame**
Aspose.Slides для Python через .NET теперь поддерживает установку пользовательского угла поворота для текстового фрейма. В этой теме мы увидим с примером, как установить свойство RotationAngle в Aspose.Slides. Новое свойство RotationAngle было добавлено в интерфейсы IChartTextBlockFormat и ITextFrameFormat, что позволяет установить пользовательский угол поворота для текстового фрейма. Для установки свойства RotationAngle, пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Добавьте график на слайд.
3. Установите свойство RotationAngle.
4. Запишите презентацию как файл PPTX.

В приведенном ниже примере мы устанавливаем свойство RotationAngle.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation
with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.text_format.text_block_format.rotation_angle = 65

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Пользовательский заголовок").text_frame_format.rotation_angle = -30

    # Сохраняем презентацию
    presentation.save("textframe-rotation_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Интервал между строками абзаца**
Aspose.Slides предоставляет свойства под `paragraph_format`—`space_after`, `space_before` и `space_within`—которые позволяют управлять интервалом между строками для абзаца. Три свойства используются следующим образом:

* Для указания интервала между строками для абзаца в процентах используйте положительное значение. 
* Для указания интервала между строками для абзаца в пунктах используйте отрицательное значение.

Например, вы можете установить интервал в 16pt для абзаца, установив свойство `space_before` в -16.

Вот как вы можете указать интервал между строками для конкретного абзаца:

1. Загрузите презентацию, содержащую AutoShape с некоторым текстом в ней.
2. Получите ссылку на слайд через его индекс.
3. Получите доступ к TextFrame.
4. Получите доступ к абзацу.
5. Установите свойства абзаца.
6. Сохраните презентацию.

Этот код на Python показывает, как указать интервал между строками для абзаца:

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:

    # Получите ссылку на слайд через его индекс
    sld = presentation.slides[0]

    # Получите доступ к TextFrame
    tf1 = sld.shapes[0].text_frame

    # Получите доступ к абзацу
    para1 = tf1.paragraphs[0]

    # Установите свойства абзаца
    para1.paragraph_format.space_within = 80
    para1.paragraph_format.space_before = 40
    para1.paragraph_format.space_after = 40
    # Сохраняем презентацию
    presentation.save("LineSpacing_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка свойства AutofitType для TextFrame**
В этой теме мы исследуем различные свойства форматирования текстового фрейма. Эта статья охватывает, как установить свойство AutofitType текстового фрейма, анкор текста и поворот текста в презентации. Aspose.Slides для Python через .NET позволяет разработчикам устанавливать свойство AutofitType для любого текстового фрейма. AutofitType может быть установлен на Normal или Shape. Если установлен на Normal, форма останется прежней, тогда как текст будет скорректирован без изменения самой формы, в то время как если AutofitType установлен на Shape, форма будет изменена так, что будет содержать только необходимый текст. Чтобы установить свойство AutofitType для текстового фрейма, пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите доступ к TextFrame.
5. Установите AutofitType для TextFrame.
6. Сохраните файл на диск.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation
with slides.Presentation() as presentation:

    # Получите доступ к первому слайду 
    slide = presentation.slides[0]

    # Добавьте AutoShape типа Прямоугольник
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Добавьте TextFrame к Прямоугольнику
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Получаем текстовый фрейм
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    # Создаем объект абзаца для текстового фрейма
    para = txtFrame.paragraphs[0]

    # Создаем объект Portion для абзаца
    portion = para.portions[0]
    portion.text = "Быстрая коричневая лисица перепрыгивает через ленивую собаку. Быстрая коричневая лисица перепрыгивает через ленивую собаку."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Сохраняем презентацию
    presentation.save("formatText_out.pptx", slides.export.SaveFormat.PPTX) 
```


## **Установка анкора TextFrame**
Aspose.Slides для Python через .NET позволяет разработчикам устанавливать анкор для любого TextFrame. TextAnchorType указывает, где размещен текст в форме. TextAnchorType может быть установлен на Top, Center, Bottom, Justified или Distributed. Чтобы установить анкор для любого TextFrame, пожалуйста, следуйте приведенным ниже шагам:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Получите доступ к первому слайду.
3. Добавьте любую форму на слайд.
4. Получите доступ к TextFrame.
5. Установите TextAnchorType для TextFrame.
6. Сохраните файл на диск.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создайте экземпляр класса Presentation
with slides.Presentation() as presentation:
    # Получите первый слайд 
    slide = presentation.slides[0]

    # Добавьте AutoShape типа Прямоугольник
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 350, 350)

    # Добавьте TextFrame к Прямоугольнику
    ashp.add_text_frame(" ")
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Получаем текстовый фрейм
    txtFrame = ashp.text_frame
    txtFrame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    # Создаем объект абзаца для текстового фрейма
    para = txtFrame.paragraphs[0]

    # Создаем объект Portion для абзаца
    portion = para.portions[0]
    portion.text = "Быстрая коричневая лисица перепрыгивает через ленивую собаку. Быстрая коричневая лисица перепрыгивает через ленивую собаку."
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Сохраняем презентацию
    presentation.save("AnchorText_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Установка табуляции текста**
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно значению Tabs.Count.
- Коллекция EffectiveTabs включает все табуляции (из коллекции Tabs и стандартных табуляторов).
- Свойство EffectiveTabs.ExplicitTabCount (2 в нашем случае) равно значению Tabs.Count.
- Свойство EffectiveTabs.DefaultTabSize (294) показывает расстояние между стандартными табуляторами (3 и 4 в нашем примере).
- Метод EffectiveTabs.GetTabByIndex(index) с индексом = 0 вернёт первую явную табуляцию (Position = 731), индекс = 1 - вторую табуляцию (Position = 1241). Если вы попытаетесь получить следующую табуляцию с индексом = 2, она вернёт первую стандартную табуляцию (Position = 1470) и т. д.
- Метод EffectiveTabs.GetTabAfterPosition(pos) используется для получения следующей табуляции после некоторого текста. Например, у вас есть текст: "Helloworld!". Чтобы отобразить такой текст, вы должны знать, с какого места начинать рисовать "world!". Вначале вы должны рассчитать длину "Hello" в пикселях и вызвать GetTabAfterPosition с этим значением. Вы получите следующую позицию табуляции, чтобы нарисовать "world!".


## **Установка стиля текста по умолчанию**

Если вам нужно применить одинаковое форматирование текста по умолчанию ко всем текстовым элементам презентации сразу, вы можете использовать свойство `default_text_style` из класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и установить желаемое форматирование. Пример кода ниже показывает, как установить жирный шрифт по умолчанию (14 pt) для текста на всех слайдах в новой презентации.

```py
with slides.Presentation() as presentation:
    # Получаем формат абзаца верхнего уровня.
    paragraphFormat = presentation.default_text_style.get_level(0)

    if paragraphFormat is not None:
        paragraphFormat.default_portion_format.font_height = 14
        paragraphFormat.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("DefaultTextStyle.pptx", slides.export.SaveFormat.PPTX)
```