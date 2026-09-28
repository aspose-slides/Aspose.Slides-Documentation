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
- межсимвольный интервал
- свойства шрифта
- семейство шрифтов
- вращение текста
- угол вращения
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- якорь текстовой рамки
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Форматировать и стилизовать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Описываются цвета фона, прозрачность, межсимвольный интервал, свойства шрифта, вращение, межабзацный интервал, поведение автоподгонки, привязка текста, табуляция и настройки языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, а его первый абзац содержит приведённый ниже текст. Индексы слайдов и фигур начинаются с нуля. Примеры, в которых выделяются жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы искать и выделять буквальный текст или совпадения регулярных выражений, см. [Поиск и замена текста](/slides/ru/python-net/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/default_portion_format/) для задания цвета подсветки по умолчанию для абзаца или [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/highlight_color/) для отдельных текстовых частей.

Следующий пример задаёт светло-серую подсветку как значение по умолчанию для первого абзаца. Явные цвета подсветки у отдельных частей имеют приоритет над этим значением по умолчанию:

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

Ниже показан пример, как установить цвет фона для **текстовых частей с жирным шрифтом**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установить цвет подсветки для текстовой части.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Серые текстовые части](gray_text_portions.png)

## **Выровнять абзацы текста**

Используйте [ParagraphFormat.alignment](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/alignment/) для установки выравнивания абзаца внутри текстовой рамки. Значение может быть центрировано, выровнено по левому, правому краю, по ширине и т.д.

Следующий пример кода демонстрирует выравнивание абзаца **по центру**:

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

## **Установить прозрачность текста**

Прозрачность текста управляется через альфа‑компонент цвета, задаваемого в [BasePortionFormat.fill_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/fill_format/). В приведённых ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже показан пример кода, который применяет прозрачность к **всему абзацу**:

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

Следующий пример кода показывает, как применить прозрачность к **текстовым частям с жирным шрифтом**:

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
            # Установить прозрачность текстовой части.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прозрачные текстовые части](transparent_text_portions.png)

## **Установить межсимвольный интервал текста**

Используйте [BasePortionFormat.spacing](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/spacing/) для увеличения или уменьшения интервала между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сжимают текст.

Следующий код на Python показывает, как увеличить межсимвольный интервал в **всём абзаце**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Увеличить межсимвольный интервал.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Межсимвольный интервал в абзаце](character_spacing_in_paragraph.png)

Ниже пример кода, который увеличивает межсимвольный интервал в **текстовых частях с жирным шрифтом**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Примечание: используйте отрицательные значения для сжатия межсимвольного интервала.
            portion.portion_format.spacing = 3  # Увеличить межсимвольный интервал.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Межсимвольный интервал в текстовых частях](character_spacing_in_text_portions.png)

### **Отключить кёрнинг для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, выглядит немного плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint игнорирует данные кёрнинга для некоторых шрифтов, даже если шрифт содержит валидную информацию о кёрнинге и кёрнинг включён в настройках PowerPoint.

Чтобы сделать вывод более похожим на PowerPoint, можно отключить кёрнинг для текстовых частей, использующих проблемный шрифт. Установите [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) в значение, превышающее фактический размер шрифта. Этот пример требует файл "presentation.pptx" с текстовым полем в первой фигуре первого слайда. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог 100 пунктов для частей, использующих Roboto. Это отключает кёрнинг для совпадающих частей, чей размер шрифта ниже 100 пунктов:

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

Для текста, соответствующего порогу, эта настройка предотвращает кёрнинг и помогает согласовать визуальный вывод Aspose.Slides с PowerPoint для шрифтов, на которые влияет данное специфическое поведение PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задавать на уровне абзаца через [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/default_portion_format/) или на отдельных частях через [PortionFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/).

Следующий пример задаёт для первого абзаца шрифт Times New Roman 12 пунктов с жирным, курсивом и пунктирным подчёркиванием. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

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

![Свойства шрифта абзаца](font_properties_for_paragraph.png)

Следующий пример применяет Times New Roman 13 пунктов, курсив и пунктирное подчёркивание к частям, у которых эффективно применено жирное форматирование:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установить свойства шрифта для текстовой части.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Свойства шрифта текстовых частей](font_properties_for_text_portions.png)

## **Установить вращение текста**

Используйте [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/text_vertical_type/) для задания предопределённой ориентации текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре как [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

## **Установить пользовательский угол вращения для текстовых рамок**

Используйте [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/rotation_angle/) для задания произвольного угла вращения [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/).

Приведённый ниже пример кода вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

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

Aspose.Slides предоставляет [ParagraphFormat.space_after](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/space_before/) и [ParagraphFormat.space_within](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/space_within/) для управления интервалом абзацев. Эти свойства применяются следующим образом:

* Положительное значение задаёт межстрочный интервал в процентах от высоты строки.
* Отрицательное значение задаёт межстрочный интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца равным 200 % от высоты строки (двойной интервал):

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

![Межстрочный интервал в абзаце](line_spacing.png)

## **Управление разрыва­ми строк**

Правила разрыва строк абзаца полезны в узких блоках текста и презентациях, где смешивается латинский и восточно‑азиатский текст. Следующие свойства принадлежат [ParagraphFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/), поэтому они применяются ко всему абзацу:

- [latin_line_break](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/latin_line_break/) управляет правилами разрыва строк для латинского текста. При смешанном тексте изменение этого свойства может также изменить место переноса ближайшего восточно‑азиатского текста и пунктуации.
- [east_asian_line_break](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/east_asian_line_break/) управляет правилами разрыва строк для восточно‑азиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/wrap_text/), который включает автоматический перенос внутри текстовой рамки. Они влияют на разметку при переносе, но не вставляют символы разрыва строки. Явный разрыв строки принудительно создаёт новую строку в абзаце независимо от доступной ширины.

Следующий самостоятельный пример создаёт узкий блок текста, содержащий китайский и латинский текст. Он явно задаёт оба свойства разрыва строк и сохраняет файл "line_breaking.pptx". Чтобы поэкспериментировать с тем или иным правилом, измените значение соответствующего свойства, оставив другое без изменений. Пример использует шрифт Arial 24 пункта и SimSun при ширине рамки 160 пунктов и нулевых горизонтальных отступах рамки. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/autofit_type/) установлен в [TextAutofitType.NONE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textautofittype/), чтобы размер текста и размеры рамки оставались фиксированными.

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/hanging_punctuation/) позволяет допустимой пунктуации выходить за правый край строки вместо того, чтобы занимать следующую строку. Применяется ко всему абзацу и отличается от висячего отступа.

Следующий самостоятельный пример включает висячую пунктуацию в текстовой рамке шириной 100 пунктов и сохраняет файл "hanging_punctuation.pptx". При шрифте Arial 24 пункта и нулевых горизонтальных отступах конечная точка остаётся после слова «sentence» и выходит за правый край текста. Чтобы сравнить, установите свойство в [NullableBool.FALSE](https://reference.aspose.com/slides/ru/python-net/aspose.slides/nullablebool/): в этом случае точка будет занимать отдельную строку. Перенос включён, а автоподгонка отключена, чтобы фиксировать доступную ширину.

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

Не каждый знак пунктуации может «висеть». Видимый результат зависит от шрифта и условий разметки: изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать различия.

## **Установить тип автоподгонки для текстовых рамок**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/autofit_type/) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы задать, будет ли текст уменьшаться, выходить за пределы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру таким образом, чтобы она меняла размер под текст, и сохраняет результат в файл "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как изменяется ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/python-net/manage-paragraph/). Само количество строк не указывает, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых рамок**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframeformat/anchoring_type/) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, по центру или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в файл "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить табуляцию текста**

Используйте [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/default_tab_size/) и [ParagraphFormat.tabs](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraphformat/tabs/) для настройки табуляций в абзаце. Следующий пример задаёт интервал табуляции по умолчанию 100 пунктов и добавляет левостороннюю табуляцию на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

![Табуляции в абзаце](paragraph_tabs.png)

## **Установить язык проверки орфографии**

Aspose.Slides предоставляет [BasePortionFormat.language_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/language_id/), позволяющий задать язык проверки орфографии для текстовой части. Язык проверки определяет язык, используемый для проверок правописания и грамматики в PowerPoint.

Следующий пример требует файл "presentation.pptx" с текстовым полем в первой фигуре первого слайда и хотя бы одним абзацем. Он заменяет содержимое первого абзаца на «1。», задаёт SimSun в качестве шрифта и присваивает упрощённый китайский язык проверки (`zh-CN`). Результат сохраняется в файл "proofing_language.pptx":

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

    # Установить язык проверки орфографии на упрощённый китайский.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить язык по умолчанию**

Используйте [LoadOptions.default_text_language](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/default_text_language/) для определения языка текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с американским английским как языком текста по умолчанию, добавляет текстовое поле и выводит `en-US` для первой текстовой части.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Добавить новую прямоугольную форму с текстом.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Проверить язык первой части.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Установить стиль текста по умолчанию**

Для применения форматирования текста по умолчанию на уровне презентации используйте [Presentation.default_text_style](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/default_text_style/).

Следующий пример задаёт 14‑пунктовый жирный шрифт как стиль по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в файл "default_text_style.pptx". Текст может наследовать эти значения, если более конкретное форматирование их не переопределит.

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

## **Извлечь текст с эффектом «Все заглавные»**

В PowerPoint применение эффекта шрифта **All Caps** делает текст на слайде отображаемым заглавными буквами, даже если он изначально был введён в нижнем регистре. При извлечении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в каком он был введён. Чтобы совпадать с отображаемым текстом, проверьте [TextCapType](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textcaptype/) и при значении `ALL` преобразуйте полученную строку к верхнему регистру.

Этот пример требует файл "sample2.pptx" с текстовым полем в первой фигуре первого слайда. Первый абзац его первой части содержит «Hello, Aspose!», к которому применён эффект All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Ниже пример кода, показывающий, как извлечь текст с применённым эффектом **All Caps**:

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

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/ru/python-net/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую через [Cell.text_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/cell/text_frame/) и форматирование абзаца через [Paragraph.paragraph_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/paragraph_format/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Для применения градиентного цвета к тексту используйте [BasePortionFormat.fill_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/fill_format/). Установите [FillFormat.fill_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/fillformat/fill_type/) в [FillType.GRADIENT](https://reference.aspose.com/slides/ru/python-net/aspose.slides/filltype/) и настройте градиентные стопы, направление и прозрачность.