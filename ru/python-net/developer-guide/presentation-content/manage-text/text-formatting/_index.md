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
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Охвачены фоновые цвета, прозрачность, интервал между символами, свойства шрифтов, вращение, отступы абзацев, поведение автоматической подгонки, привязка текста, табуляция и настройки языка.

В примерах ниже мы будем использовать файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/python-net/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/default_portion_format/) чтобы задать цвет выделения по умолчанию для абзаца, либо используйте [PortionFormat.highlight_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/highlight_color/) для отдельных частей текста.

Следующий пример кода показывает, как задать цвет фона для **всего абзаца**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установить цвет выделения для всего абзаца.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Серый абзац](gray_paragraph.png)

Следующий пример кода демонстрирует, как задать цвет фона для **частей текста с полужирным шрифтом**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установить цвет выделения для части текста.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Серые части текста](gray_text_portions.png)

## **Выровнять абзацы текста**

Используйте [ParagraphFormat.alignment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/alignment/) чтобы задать выравнивание абзаца внутри текстового кадра. Значение может быть центрированным, выравненным по левому краю, по правому, выровненным по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац **по центру**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установить выравнивание абзаца по центру.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Установить прозрачность текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [PortionFormat.fill_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/fill_format/). В примерах ниже `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0‑255, а не процент прозрачности.

Следующий пример кода показывает, как применить прозрачность к **всему абзацу**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установить цвет заливки текста в прозрачный цвет.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **частям текста с полужирным шрифтом**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установить прозрачность части текста.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прозрачные части текста](transparent_text_portions.png)

## **Установить интервал между символами текста**

Используйте [BasePortionFormat.spacing](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/spacing/) чтобы увеличить или уменьшить интервал между символами в текстовом блоке.

Следующий Python‑код показывает, как увеличить интервал между символами в **всём абзаце**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Примечание: используйте отрицательные значения для сжатия интервала между символами.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Увеличить интервал между символами.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Следующий пример кода показывает, как увеличить интервал между символами в **частях текста с полужирным шрифтом**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Примечание: используйте отрицательные значения для сжатия интервала между символами.
            portion.portion_format.spacing = 3  # Увеличить интервал между символами.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Интервал между символами в частях текста](character_spacing_in_text_portions.png)

### **Отключить кернинг для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть немного более плотным, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint может игнорировать данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint в подобных случаях, можно отключить кернинг для частей текста, использующих затронутый шрифт. Установите [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) в значение, значительно превышающее фактический размер шрифта:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Эта настройка предотвращает применение кернинга к соответствующим частям текста и может помочь согласовать рендеринг Aspose.Slides с визуальным выводом PowerPoint для шрифтов, на которые влияет данное специфическое поведение PowerPoint.

## **Управление свойствами шрифтов текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/default_portion_format/) либо для отдельных частей через [PortionFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/).

Следующий код задаёт шрифт и стиль текста для всего абзаца: он применяет размер шрифта, полужирное начертание, курсив, пунктирное подчёркивание и шрифт Times New Roman ко всем частям абзаца.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установить свойства шрифта для абзаца.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Свойства шрифта для абзаца](font_properties_for_paragraph.png)

Следующий пример кода применяет аналогичные свойства к **частям текста с полужирным шрифтом**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установить свойства шрифта для части текста.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Свойства шрифта для частей текста](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/text_vertical_type/) чтобы задать предопределённую ориентацию текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре `VERTICAL270`, что вращает текст **на 90 градусов против часовой стрелки**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Вращение текста](text_rotation.png)

## **Установить пользовательское вращение для текстовых рамок**

Используйте [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/rotation_angle/) чтобы задать пользовательский угол вращения для [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).

Следующий пример кода вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Пользовательское вращение текста](custom_text_rotation.png)

## **Установить межстрочный интервал абзацев**

Aspose.Slides предоставляет [ParagraphFormat.space_after](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/space_before/), и [ParagraphFormat.space_within](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/space_within/) чтобы управлять интервалами абзацев. Эти свойства используются следующим образом:

* Укажите положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Укажите отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример кода показывает, как указать межстрочный интервал внутри абзаца:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Межстрочный интервал внутри абзаца](line_spacing.png)

## **Установить тип автоподгонки для текстовых рамок**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/autofit_type/) определяет, как текст ведёт себя, когда выходит за границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, вытекать за пределы или автоматически изменять размер фигуры.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить привязку текстовых рамок**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/anchoring_type/) определяет, как текст позиционируется вертикально внутри фигуры, например вверху, посередине или внизу.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить табуляцию текста**

Используйте [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/default_tab_size/) и [ParagraphFormat.tabs](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/tabs/) чтобы настроить позиции табуляции в абзаце.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Табуляции абзаца](paragraph_tabs.png)

## **Установить язык проверки правописания**

Aspose.Slides предоставляет [PortionFormat.language_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/language_id/), который позволяет задать язык проверки правописания для части текста. Язык проверки определяет, какой язык используется для проверки орфографии и грамматики в PowerPoint.

Следующий пример кода показывает, как задать язык проверки правописания для части текста:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Установить идентификатор языка проверки правописания.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.default_text_language](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/default_text_language/) чтобы определить язык по умолчанию для текста, создаваемого при загрузке или создании презентации.

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

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation.default_text_style](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/default_text_style/).

Следующий пример кода показывает, как задать шрифт по умолчанию полужирный размером 14 pt для всего текста на всех слайдах в новой презентации.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Получить формат абзаца верхнего уровня.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Извлечь текст с эффектом All-Caps**

В PowerPoint применение эффекта **All Caps** заставляет текст отображаться заглавными буквами на слайде, даже если он был введён строчными. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы соответствовать отображаемому тексту, проверьте [TextCapType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, если значение равно `ALL`.

Предположим, у нас есть следующий текстовый блок на первом слайде файла sample2.pptx.

![Эффект All Caps](all_caps_effect.png)

Следующий пример кода показывает, как извлечь текст с применённым эффектом **All Caps**:

```python
import aspose.slides as slides

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

## **FAQ**

**Как изменить текст в таблице на слайде?**

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/ru/python-net/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую ячейку через [Cell.text_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/cell/text_frame/) и форматирование абзаца — через [Paragraph.paragraph_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/paragraph_format/).

**Как применить градиентный цвет к тексту в слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [PortionFormat.fill_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/fill_format/). Установите [FillFormat.fill_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fillformat/fill_type/) в значение [FillType.GRADIENT](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) и затем настройте остановки градиента, направление и прозрачность.