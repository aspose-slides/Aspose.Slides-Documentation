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
- якорь текстового кадра
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Форматируйте и задавайте стиль тексту в презентациях PowerPoint и OpenDocument, используя Aspose.Slides для Python через .NET. Настраивайте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

Эта статья показывает, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Рассматриваются цвета фона, прозрачность, интервал между символами, свойства шрифта, вращение, отступы абзацев, поведение автоподгонки, привязка текста, табуляция и языковые настройки.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде — это текстовое поле, а его первый абзац содержит показанный ниже текст. Индексы слайдов и фигур начинаются с нуля. Примеры, выбирающие жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и выделить буквальный текст или совпадения регулярных выражений, смотрите [Поиск и замена текста](/slides/ru/python-net/search-and-replace-text/).

## **Установить цвет фона текста**

Используйте [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) для установки цвета выделения по умолчанию для абзаца, либо используйте [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) для отдельных частей текста.

Следующий пример устанавливает светло-серое выделение как значение по умолчанию для первого абзаца. Явные цвета выделения для отдельных частей имеют приоритет над этим значением по умолчанию:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установите цвет выделения для всего абзаца.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже представленный пример кода демонстрирует, как установить цвет фона для **частей текста с жирным шрифтом**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установите цвет выделения для части текста.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Серые части текста](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) для установки выравнивания абзаца внутри текстового кадра. Значение может быть по центру, по левому краю, по правому краю, по ширине и т.д.

Следующий пример кода показывает, как выровнять абзац по **центру**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установите выравнивание абзаца по центру.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Выровненный абзац](aligned_paragraph.png)

## **Выравнивание шрифтов в строке**

Используйте [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) для вертикального выравнивания частей текста разного размера шрифта в пределах строки. Этот параметр применяется ко всему абзацу и управляет выравниванием в каждой его строке.

Следующий автономный пример создает четыре маркированных текстовых поля на одном слайде. Каждый абзац содержит одинаковый текст размером 18, 36 и 54 пункта с разным выравниванием шрифта. Он использует Arial, отключает автоподгонку и перенос, и сохраняет текстовые кадры достаточно большими для одной строки.

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

Результат:

![Сравнение выравнивания по базовой линии, вверху, по центру и внизу при смешанных размерах шрифта](font_alignment.png)

Выравнивание шрифтов использует метрики шрифта, поэтому видимые края отдельных букв не всегда выравниваются точно. В примере присутствует как прописная буква, так и нижний вынос, чтобы продемонстрировать разницу между выравниванием по базовой линии и по нижнему краю. Доступность шрифтов и их подстановка, используемые символы и различие в размерах шрифтов влияют на результат. Размеры кадров, отступы и отступы абзаца идентичны, перенос и автоподгонка отключены, чтобы сравнение было последовательным. Пример выводит `FALSE: False` и `NOT_DEFINED: True`, затем сохраняет "text_height_normalization.pptx".

Этот параметр отличается от [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), который управляет горизонтальным выравниванием абзаца, и от [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), который позиционирует блок текста вертикально внутри фигуры. Форматирование надстрочных и подстрочных знаков через [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) смещает отдельные части относительно базовой линии вместо установки выравнивания шрифтов для строк абзаца.

## **Установить прозрачность текста**

Прозрачность текста управляется через альфа‑компонент цвета, назначенного [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). В приведенных ниже примерах `alpha = 50` — это значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже пример кода, показывающий, как применить прозрачность к **всему абзацу**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установите полупрозрачную чёрную заливку для текста.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прозрачный абзац](transparent_paragraph.png)

Следующий пример кода показывает, как применить прозрачность к **частям текста с жирным шрифтом**:

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
            # Установите прозрачность части текста.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Прозрачные части текста](transparent_text_portions.png)

## **Установить интервал между символами текста**

Используйте [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) для увеличения или сжатия интервала между символами в текстовом поле. В примерах добавляется 3 пункта интервала; отрицательные значения сжимают текст.

Следующий код на Python показывает, как расширить интервал между символами в **всём абзаце**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Примечание: используйте отрицательные значения для сжатия интервала между символами.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Увеличить интервал между символами.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Ниже пример кода, показывающий, как расширить интервал между символами в **частях текста с жирным шрифтом**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть немного плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint может игнорировать данные кернинга для некоторых шрифтов, даже если шрифт содержит корректную информацию о кернинге и кернинг включён в настройках PowerPoint.

Чтобы вывести отрисованный результат ближе к PowerPoint в таких случаях, можно отключить кернинг для частей текста, использующих затронутый шрифт. Установите [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) в значение, превышающее фактический размер шрифта. Этот пример требует файл "presentation.pptx" с текстовым полем в качестве первой фигуры на первом слайде. Он проверяет эффективные имена шрифтов, включая унаследованные, и задаёт порог в 100 пунктов для частей, использующих Roboto. Это отключает кернинг для совпадающих частей с размером шрифта меньше 100 пунктов:

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

Для текста, соответствующего условию и находящегося ниже порога, этот параметр предотвращает кернинг и может помочь согласовать отрисовку Aspose.Slides с визуальным выводом PowerPoint для шрифтов, подверженных этому специфическому поведению PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задавать на уровне абзаца через [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) или для отдельных частей через [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Следующий пример устанавливает шрифт по умолчанию первого абзаца в 12 пунктов Times New Roman с жирным, курсивом и пунктирным подчёркиванием. Явное форматирование отдельных частей имеет приоритет над этими значениями по умолчанию:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установите свойства шрифта для абзаца.
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

Следующий пример применяет к частям, у которых эффективное форматирование — жирное, шрифт Times New Roman размером 13 пунктов, курсив и пунктирное подчёркивание:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установите свойства шрифта для части текста.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Свойства шрифта для частей текста](font_properties_for_text_portions.png)

## **Управление нормализацией высоты текста**

Используйте [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) при воспроизведении типографии шаблона или исследовании различий в высоте символов. В PowerPoint включение нормализации растягивает или сжимает отдельные символы по вертикали, чтобы придать им одинаковую видимую высоту внутри части текста. Это не гарантирует одинаковую высоту текста для разных шрифтов.

Установите свойство в [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), чтобы явно включить или отключить нормализацию. `NullableBool.NOT_DEFINED` оставляет локальную настройку неустановленной, поэтому часть наследует значение, например, из [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) абзаца. Это не означает `False`. Используйте [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) и прочитайте [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) для получения полученного логического значения.

Следующий автономный пример требует установленный шрифт **Arial**. Он создает два текстовых блока, содержащих одинаковые прописные буквы, строчные буквы, нижние выносы и символы с диакритическими знаками размером 54 пункта. Оба абзаца включают нормализацию по умолчанию. Верхняя часть явно отключает её; нижняя часть наследует. Размеры кадров, отступы и отступы абзаца идентичны, перенос и автоподгонка отключены, чтобы сравнение было последовательным. Пример выводит `FALSE: False` и `NOT_DEFINED: True`, затем сохраняет "text_height_normalization.pptx".

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

Сравнение ниже было экспортировано из сохранённой презентации. В верхней строке нормализация отключена (`FALSE`); в нижней строке наследуется включённый параметр (`NOT_DEFINED` → `True`). Оставьте установленным шрифт Arial, чтобы воспроизвести этот вид.

![Текст Arial 54 пункта с отключённой нормализацией сверху и унаследованной нормализацией снизу](text_height_normalization.png)

Нормализация изменяет высоту символов без изменения назначенного значения [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/), которое задаёт размер шрифта в пунктах. Абзацный параметр [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) управляет межстрочным интервалом, тогда как параметр [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) текстового кадра определяет, как текст или его контейнер подстраивается под размер. Эти настройки служат разным целям и могут независимо влиять на общую разметку. Для получения дополнительной информации о форматировании абзацев и наследовании см. [Управление абзацем](/slides/ru/python-net/manage-paragraph/).

## **Применить и удалить зачеркивание**

Используйте [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) для части текста, чтобы отображать исправления, отменённые термины или предыдущие цены без удаления исходного текста. Установите его в [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) для одной или двух линий через текст.

Чтобы удалить зачеркивание, назначьте `TextStrikethroughType.NONE`. Это явно отключает эффект, даже если окружающее форматирование указывает зачеркивание. В отличие от этого, `TextStrikethroughType.NOT_DEFINED` оставляет локальную настройку неопределённой, позволяя части наследовать форматирование, например, из абзаца. Это не гарантирует, что зачеркивание будет удалено. Используйте [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) для чтения полученного форматирования, включая унаследованные значения.

Следующий автономный пример создаёт три сравнения цен. Каждый абзац имеет отдельные части для метки, предыдущей цены и текущей цены, поэтому зачеркиванием затрагивается только предыдущая цена. В первой строке зачеркивание применяется, а затем удаляется; в остальных строках сохраняется одинарное и двойное зачеркивание. Изменение этого свойства сохраняет текст и его другое форматирование, включая жирную предыдущую цену.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Применить зачеркивание, затем явно удалить его у первой предыдущей цены.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Результат сверху вниз: без зачеркивания, одинарное зачеркивание и двойное зачеркивание.

![Предыдущие цены без зачеркивания, с одинарным зачеркиванием и с двойным зачеркиванием](strikethrough.png)

## **Установить вращение текста**

Используйте [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) для установки предопределённой ориентации текста внутри фигуры.

Следующий пример кода устанавливает ориентацию текста в фигуре на [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), что вращает текст **на 90 градусов против часовой стрелки**:

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

Используйте [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) для задания пользовательского угла вращения для [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

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

Aspose.Slides предоставляет [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/), и [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) для управления отступами абзаца. Эти свойства используются следующим образом:

* Укажите положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Укажите отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример устанавливает интервал внутри первого абзаца в 200% от высоты строки (двойной интервал):

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

Правила разрыва строк абзаца полезны в узких текстовых блоках и презентациях, где смешивается латинский и восточноазиатский текст. Следующие свойства относятся к [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), поэтому они применяются к целому абзацу:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) управляет правилами разрыва строк для латиницы. При смешанном тексте изменение может также влиять на место переноса соседнего восточноазиатского текста и пунктуации.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) управляет правилами разрыва строк для восточноазиатского текста, включая ограничения на символы в начале и в конце строки.

Эти правила не заменяют [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), который включает автоматический перенос внутри текстового кадра. Они влияют на разметку при переносе, но не вставляют символы разрыва строки. Явный разрыв строки принуждает к новой строке внутри абзаца независимо от доступной ширины.

Следующий автономный пример создает узкий текстовый блок, содержащий китайский и латинский текст. Он явно задаёт оба свойства разрыва строк и сохраняет "line_breaking.pptx". Чтобы поэкспериментировать с каждым правилом, измените значение соответствующего свойства, оставив остальные параметры неизменными. В примере используется 24‑пунктовый Arial и SimSun, ширина кадра 160 пунктов и нулевые горизонтальные отступы текстового кадра. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) установлен в [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/), чтобы размер текста и размеры кадра оставались фиксированными.

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) позволяет подходящей пунктуации выступать за правый край строки текста вместо того, чтобы занимать следующую строку. Применяется к целому абзацу и отличается от висячего отступа.

Следующий автономный пример включает висячую пунктуацию в текстовом кадре шириной 100 пунктов и сохраняет "hanging_punctuation.pptx". При 24‑пунктовом Arial и нулевых горизонтальных отступах текстового кадра конечная точка остаётся после слова "sentence" и выступает за правый край текста. Установите параметр в [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) для сравнения: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы фиксировать доступную ширину.

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

Не каждый пунктуационный знак может висеть. Видимый результат зависит от [условий шрифта и разметки](#control-line-breaking): изменение шрифта, доступной ширины, отступов или настроек автоподгонки может убрать видимую разницу.

## **Установить тип автоподгонки для текстовых кадров**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) определяет, как текст ведёт себя, когда выходит за пределы своего контейнера. Используйте его, чтобы управлять тем, будет ли текст уменьшаться, выходить за пределы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру так, чтобы она изменяла размер под текст, и сохраняет результат в "autofit_type.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняется результат при изменении ширины текста или фигуры, смотрите [Подсчёт отрисованных строк](/slides/ru/python-net/manage-paragraph/). Одного количества строк недостаточно, чтобы определить, выходит ли текст за пределы контейнера.

## **Установить привязку текстовых кадров**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, по центру или внизу. Следующий пример закрепляет текст внизу первой фигуры и сохраняет результат в "text_anchor.pptx".

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить табуляцию текста**

Используйте [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) и [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) для настройки табуляции в абзаце. Следующий пример задаёт интервал табуляции по умолчанию в 100 пунктов и добавляет левый таб‑стоп на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции.

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

## **Установить язык проверки орфографии**

Aspose.Slides предоставляет [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), который позволяет задать язык проверки орфографии для части текста. Язык проверки определяет язык, используемый для проверки правописания и грамматики в PowerPoint.

Следующий пример требует файл "presentation.pptx" с текстовым полем в качестве первой фигуры на первом слайде и как минимум одним абзацем. Он заменяет содержимое первого абзаца на "1。", задаёт SimSun в качестве шрифта и назначает язык проверки Simplified Chinese (`zh-CN`). Сохраняет результат в "proofing_language.pptx":

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

    # Установите язык проверки орфографии на упрощённый китайский.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Копировать метаданные языка**

При копировании многоязычного текста из шаблона сохраняйте как [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), так и [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Следующий автономный пример создаёт исходную часть с американским английским в качестве языка и французским как альтернативным языком, и копирует текст и идентификаторы в часть новой презентации.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Если у источника нет альтернативного языка, None очищает значение назначения.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы попробовать источник без альтернативного языка, опустите присваивание `"fr-FR"`. Тогда альтернативный идентификатор будет `None`, и тот же оператор копирования сохранит его отсутствие без добавления значения по умолчанию, даже если у назначения уже был назначен альтернативный язык.

Эти идентификаторы хранятся как метаданные языка. Сохранение их не определяет, какой словарь PowerPoint выберет для проверки орфографии или грамматики.

## **Установить язык по умолчанию**

Используйте [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с американским английским в качестве языка текста по умолчанию, добавляет текстовое поле и выводит `en-US` для первой части текста.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Добавить новую прямоугольную фигуру с текстом.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Проверить язык первой части текста.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Установить стиль текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Следующий пример задаёт шрифт 14 пунктов жирным в качестве значения по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в "default_text_style.pptx". Текст может наследовать эти значения по умолчанию, если только более конкретное форматирование их не переопределит.

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

## **Извлечь текст с эффектом всех заглавных букв**

В PowerPoint применение эффекта **All Caps** (все заглавные) делает текст заглавным на слайде, даже если он был введён строчными буквами. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно в том виде, в котором он был введён. Чтобы соответствовать отображаемому тексту, проверьте [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) и преобразуйте возвращённую строку в верхний регистр, когда значение равно `ALL`.

Этот пример требует файл "sample2.pptx" с текстовым полем в качестве первой фигуры на первом слайде. Первая часть первого абзаца содержит "Hello, Aspose!" с применённым эффектом All Caps, как показано ниже.

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

Чтобы изменить текст в таблице на слайде, используйте [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую ячейку через [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) и форматирование абзаца через [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Установите [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) в значение [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) и настройте точки градиента, направление и прозрачность.

Связанная возможность: [Форматирование текста в слайдах](/slides/ru/features/text-formatting/).