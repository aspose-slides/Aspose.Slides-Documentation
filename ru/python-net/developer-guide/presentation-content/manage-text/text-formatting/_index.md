---
title: Форматирование текста презентации в Python
linktitle: Форматирование текста
type: docs
weight: 50
url: /ru/python-net/text-formatting/
keywords:
- выравнивание абзаца
- стиль текста
- фон текста
- прозрачность текста
- интервал между символами
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
- текстовый кадр
- межстрочный интервал
- свойство автоподгонки
- привязка текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с использованием Aspose.Slides для Python через .NET. Настройка шрифтов, цветов, выравнивания и прочего."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Она охватывает фоновые цвета, прозрачность, интервал между символами, свойства шрифтов, вращение, межабзацный интервал, поведение автоподгонки, привязку текста, табуляцию и параметры языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде представляет собой текстовое поле, и его первый абзац содержит показанный ниже текст. Индексы слайдов и фигур нумеруются с нуля. Примеры, выбирающие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/python-net/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) чтобы установить цвет подсветки по умолчанию для абзаца, или используйте [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) для отдельных текстовых фрагментов.

Следующий пример устанавливает светло‑серую подсветку по умолчанию для первого абзаца. Явные цвета подсветки в отдельных фрагментах имеют приоритет над этим значением по умолчанию:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установить цвет подсветки для всего абзаца.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Серый абзац](gray_paragraph.png)

Пример кода ниже демонстрирует, как установить цвет фона для **текстовых фрагментов с жирным шрифтом**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установить цвет подсветки для текстового фрагмента.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Серые текстовые фрагменты](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) чтобы задать выравнивание абзаца внутри текстового кадра. Значение может быть по центру, выравнено по левому краю, по правому, по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац по **центру**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установить выравнивание абзаца по центру.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Выравнивание шрифтов в строке**

Используйте [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) чтобы вертикально выровнять текстовые фрагменты разного размера шрифта внутри строки. Эта настройка применяется к всему абзацу и контролирует выравнивание в каждой его строке.

Следующий автономный пример создаёт четыре помеченных текстовых блока на одном слайде. Каждый абзац содержит один и тот же текст размером 18, 36 и 54 пункта, с различным выравниванием шрифта. Он использует Arial, отключает автоподгонку и перенос, и оставляет текстовые кадры достаточно большими для одной строки.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Сравнение выравнивания шрифтов по базовой линии, верхнему, центру и нижнему при разных размерах шрифтов:

![Сравнение выравнивания шрифтов по базовой линии, верхнему, центру и нижнему при разных размерах шрифтов](font_alignment.png)

Выравнивание шрифтов использует метрики шрифта, поэтому видимые края отдельных букв не всегда точно совпадают. Пример включает как заглавную букву, так и нижний выносной элемент, чтобы показать разницу между базовой линией и нижним выравниванием. Доступность шрифтов и их подстановка, используемые символы и различие в размерах шрифтов влияют на результат. Размеры кадра, отступы, межстрочный интервал, перенос и автоподгонка также влияют на разметку; при сравнении режимов используйте одинаковые шрифты и настройки разметки.

Эта настройка отличается от [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), который контролирует горизонтальное выравнивание абзаца, и [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), который позиционирует текстовый блок вертикально внутри фигуры. Форматирование надстрочного и нижстрочного текста через [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) сдвигает отдельные фрагменты относительно базовой линии вместо установки выравнивания шрифтов для строк абзаца.

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Пример кода ниже показывает, как применить прозрачность к **целому абзацу**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установить полупрозрачную черную заливку для текста.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **текстовым фрагментам с жирным шрифтом**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установить прозрачность текстового фрагмента.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прозрачные текстовые фрагменты](transparent_text_portions.png)

## **Установить интервал между символами текста**

Используйте [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) чтобы расширить или сузить интервал между символами в текстовом поле. В примерах добавляется интервал в 3 пункта; отрицательные значения сжимают текст.

Следующий код Python показывает, как увеличить интервал между символами в **полном абзаце**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Примечание: используйте отрицательные значения, чтобы сжать интервал между символами.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Расширить интервал между символами.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Пример кода ниже показывает, как увеличить интервал между символами в **текстовых фрагментах с жирным шрифтом**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Примечание: используйте отрицательные значения, чтобы сжать интервал между символами.
            portion.portion_format.spacing = 3  # Расширить интервал между символами.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Интервал между символами в текстовых фрагментах](character_spacing_in_text_portions.png)

### **Отключить кернинг для конкретных шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть немного более плотно, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint может игнорировать данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы вывод был ближе к PowerPoint в таких случаях, можно отключить кернинг для текстовых фрагментов, использующих затронутый шрифт. Установите [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) в значение, превышающее фактический размер шрифта. Этот пример требует файл "presentation.pptx" с текстовым полем в качестве первой фигуры на первом слайде. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для фрагментов, использующих Roboto. Это отключает кернинг для соответствующих фрагментов размером шрифта ниже 100 пунктов:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Для соответствующего текста, размер которого ниже порога, эта настройка отключает кернинг и может помочь согласовать визуальный вывод Aspose.Slides с выводом PowerPoint для шрифтов, затронутых этим специфическим поведением PowerPoint.

## **Управление свойствами шрифтов текста**

Свойства шрифта могут устанавливаться на уровне абзаца через [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) либо для отдельных фрагментов через [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Следующий пример устанавливает шрифт по умолчанию для первого абзаца: Times New Roman 12 пунктов с жирным, курсивом и пунктирным подчёркиванием. Явное форматирование отдельных фрагментов имеет приоритет над этими значениями по умолчанию:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установить свойства шрифта для абзаца.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Следующий пример применяет Times New Roman 13 пунктов, курсив и пунктирное подчёркивание к фрагментам, у которых эффективное форматирование является жирным:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установить свойства шрифта для текстового фрагмента.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Свойства шрифта для текстовых фрагментов](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) чтобы задать предустановленную ориентацию текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Вращение текста](text_rotation.png)

## **Установить пользовательское вращение для текстовых кадров**

Используйте [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) чтобы задать пользовательский угол вращения для [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Пример кода ниже вращает текстовый кадр на 3 градуса по часовой стрелке внутри фигуры:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), и [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) чтобы управлять межабзацным интервалом. Эти свойства используются следующим образом:

* Используйте положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Используйте отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца как 200% от высоты строки (двойной интервал):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Управление разрывом строк**

Правила разрыва строк в абзацах полезны в узких текстовых блоках и презентациях, сочетающих латинский и восточноазиатский текст. Ниже перечисленные свойства относятся к [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), поэтому они применяются к целому абзацу:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) управляет правилами разрыва строк для латинского текста. В смешанном тексте изменение этого параметра может также изменить место переноса соседнего восточноазиатского текста и знаков пунктуации.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) управляет правилами разрыва строк для восточноазиатского текста, включая ограничения на символы в начале и в конце строки.

Эти правила не заменяют [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), который включает автоматический перенос внутри текстового кадра. Они влияют на разметку при переносе; они не вставляют символы разрыва строки. Явный разрыв строки принудительно создаёт новую строку в абзаце независимо от доступной ширины.

Следующий автономный пример создаёт узкий текстовый блок, содержащий китайский и латинский текст. Он явно задаёт оба свойства разрыва строк и сохраняет файл "line_breaking.pptx". Чтобы поэкспериментировать с любым из правил, измените значение соответствующего свойства, оставив остальные параметры неизменными. В примере используется Arial и SimSun 24 пункта, ширина кадра 160 пунктов и нулевые горизонтальные отступы текста. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) установлен в [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) чтобы размер текста и размеры кадра оставались фиксированными.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Управление висячей пунктуацией**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) позволяет допустимой пунктуации выходить за правый край строки текста вместо того, чтобы занимать следующую строку. Применяется к целому абзацу и отличается от висячего отступа.

Следующий автономный пример включает висячую пунктуацию в текстовом кадре шириной 100 пунктов и сохраняет файл "hanging_punctuation.pptx". При Arial 24 пункта и нулевых горизонтальных отступах текстового кадра конечная точка остаётся после "sentence" и выходит за правый край текста. Установите свойство в значение [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) чтобы сравнить: при этих настройках точка занимает отдельную строку. Перенос включён, а автоподгонка отключена, чтобы фиксировать доступную ширину.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Не каждый знак пунктуации может «висеть». Видимый результат зависит от [условий шрифта и разметки](#control-line-breaking): изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать видимую разницу.

## **Установить тип автоподгонки для текстовых кадров**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) определяет, как текст ведёт себя, когда выходит за пределы контейнера. Используйте его, чтобы контролировать, будет ли текст уменьшаться, выходить за границы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру так, чтобы она изменяла размер под текст, и сохраняет результат в файл "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы посчитать строки после автоматического переноса и увидеть, как изменяется результат при изменении ширины текста или фигуры, см. [Count Rendered Lines](/slides/ru/python-net/manage-paragraph/). Одна лишь подсчёт строк не указывает, выходит ли текст за границы контейнера.

## **Установить привязку текстовых кадров**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, по центру или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в файл "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить табуляцию текста**

Используйте [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) и [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) чтобы настроить табуляцию в абзаце. Следующий пример задаёт интервал табуляции по умолчанию 100 пунктов и добавляет табуляцию, выровненную по левому краю, на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Табы абзаца](paragraph_tabs.png)

## **Установить язык проверки**

Aspose.Slides предоставляет [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), позволяющий задать язык проверки для текстового фрагмента. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует файл "presentation.pptx" с текстовым полем в качестве первой фигуры на первом слайде и как минимум одним абзацем. Он заменяет содержимое первого абзаца на "1。", задаёт SimSun в качестве шрифта и устанавливает язык проверки Simplified Chinese (`zh-CN`). Затем сохраняет результат в файл "proofing_language.pptx":

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Установить язык проверки на упрощённый китайский.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) чтобы задать язык по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с американским английским в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для первого текстового фрагмента.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Добавить новую прямоугольную фигуру с текстом.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Проверить язык первой части.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Следующий пример задаёт шрифт 14 пунктов жирный в качестве значения по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в файл "default_text_style.pptx". Текст может наследовать эти значения по умолчанию, если только более конкретное форматирование не переопределит их.

```python
import aspose.slides as slides

with slides.Presentation() as ?{
 
```

## **Извлечь текст с эффектом всех заглавных букв**

В PowerPoint применение эффекта **All Caps** делает текст на слайде отображаемым заглавными буквами, даже если он был введён в нижнем регистре. При получении такого текстового фрагмента с помощью Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы получить отображаемый текст, проверьте [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `ALL`.

Этот пример требует файл "sample2.pptx" с текстовым полем в качестве первой фигуры на первом слайде. Первый фрагмент первого абзаца содержит "Hello, Aspose!" с применённым эффектом All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Пример кода ниже показывает, как извлечь текст с применённым эффектом **All Caps**:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

## **FAQ**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Перебирайте ячейки и обновляйте каждую ячейку через [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) и форматирование абзацев — через [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Установите [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) в [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) и настройте градиентные остановки, направление и прозрачность.