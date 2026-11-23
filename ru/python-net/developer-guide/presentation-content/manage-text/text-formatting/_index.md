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
- текстовая рамка
- межстрочный интервал
- свойство автоподгонки
- привязка текстовой рамки
- табуляция текста
- язык по умолчанию
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Форматирование и стилизация текста в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Настройте шрифты, цвета, выравнивание и многое другое."
---
## **Обзор**

В этой статье показано, как форматировать текст в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET. Рассматриваются фоновые цвета, прозрачность, интервал между символами, свойства шрифтов, вращение, интервалы абзацев, поведение автоподгонки, привязка текста, табуляция и настройки языка.

Если не указано иное, примеры используют [sample.pptx](sample.pptx). Первая фигура на первом слайде – текстовое поле, и его первый абзац содержит показанный ниже текст. Индексы слайдов и фигур начинаются с нуля. Примеры, в которых выделяются жирные части, используют эффективное форматирование, включая унаследованное жирное форматирование:

![Пример текста](sample_text.png)

Чтобы найти и подсветить буквальный текст или совпадения с регулярным выражением, см. [Поиск и замена текста](/slides/ru/python-net/search-and-replace-text/).

## **Установка фонового цвета текста**

Используйте [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) для установки цвета выделения по умолчанию для абзаца, либо используйте [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) для отдельных текстовых частей.

Следующий пример задает светло‑серый цвет выделения по умолчанию для первого абзаца. Явные цвета выделения у отдельных частей имеют приоритет над этим значением по умолчанию:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Установить цвет выделения для всего абзаца.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Серый абзац](gray_paragraph.png)

Ниже приведён пример кода, демонстрирующий, как установить фоновый цвет для **текстовых частей с полужирным шрифтом**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Установить цвет выделения для текстовой части.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Серые текстовые части](gray_text_portions.png)

## **Выравнивание абзацев текста**

Используйте [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) для установки выравнивания абзаца внутри текстовой рамки. Значение может быть: по центру, по левому краю, по правому краю, выровнено по ширине и т.д.

Следующий пример кода демонстрирует, как выровнять абзац **по центру**:

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

Используйте [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) для вертикального выравнивания текстовых частей разного размера шрифта в строке. Эта настройка применяется к целому абзацу и управляет выравниванием в каждой его строке.

Следующий автономный пример создаёт четыре подписи в текстовых полях на одном слайде. Каждый абзац содержит одинаковый текст размером 18, 36 и 54 пункта, с разным выравниванием шрифта. Он использует Arial, отключает автоподгонку и перенос, и делает текстовые рамки достаточно большими для одной строки.

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

![Сравнение выравнивания шрифтов по базовой линии, вверху, по центру и внизу с разными размерами шрифтов](font_alignment.png)

Выравнивание шрифтов использует метрики шрифта, поэтому визуальные края отдельных букв не обязательно совпадают точно. В примере присутствует как заглавная буква, так и нижний вынос, чтобы продемонстрировать разницу между выравниванием по базовой линии и нижнему выравниванию. Доступность шрифта и его замена, используемые символы и различие в размерах шрифтов влияют на результат. Размеры рамки, отступы, межстрочный интервал, перенос и автоподгонка также влияют на макет; при сравнении режимов используйте одинаковые шрифты и настройки макета.

Эта настройка отличается от [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), который управляет горизонтальным выравниванием абзаца, и от [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), который позиционирует текстовый блок вертикально внутри своей фигуры. Форматирование надстрочного и подстрочного индексов через [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) смещает отдельные части относительно базовой линии вместо установки выравнивания шрифта для строк абзаца.

## **Установка прозрачности текста**

Прозрачность текста управляется альфа‑компонентой цвета, назначенного [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). В приведённых ниже примерах `alpha = 50` — значение альфа‑канала ARGB в диапазоне 0–255, а не процент прозрачности.

Ниже приведён пример кода, показывающий, как применить прозрачность к **целому абзацу**:

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

Следующий пример кода показывает, как применить прозрачность к **текстовым частям с полужирным шрифтом**:

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

## **Установка интервала между символами текста**

Используйте [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) для расширения или сжатия интервала между символами в текстовом поле. Примеры добавляют 3 пункта интервала; отрицательные значения сжимают текст.

Следующий пример кода показывает, как расширить интервал между символами в **целом абзаце**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Примечание: используйте отрицательные значения для сжатия интервала между символами.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Расширить интервал между символами.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Интервал между символами в абзаце](character_spacing_in_paragraph.png)

Следующий пример кода показывает, как расширить интервал между символами в **текстовых частях с полужирным шрифтом**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Примечание: используйте отрицательные значения для сжатия интервала между символами.
            portion.portion_format.spacing = 3  # Расширить интервал между символами.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Интервал между символами в текстовых частях](character_spacing_in_text_portions.png)

### **Отключить кернинг для определённых шрифтов**

В некоторых случаях текст, отрисованный Aspose.Slides, может выглядеть чуть плотнее, чем тот же текст в PowerPoint. Это может происходить, потому что PowerPoint может игнорировать данные о кернинге для определённых шрифтов, даже если шрифт содержит корректные данные о кернинге и кернинг включён в настройках PowerPoint.

Чтобы сделать отрисовку ближе к PowerPoint в таких случаях, можно отключить кернинг для текстовых частей, использующих затронутый шрифт. Установите [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) в значение, превышающее фактический размер шрифта. Этот пример требует файл «presentation.pptx» с текстовым полем в первой фигуре первого слайда. Он проверяет эффективные имена шрифтов, включая наследованные, и задаёт порог 100 пунктов для частей, использующих Roboto. Это отключает кернинг для совпадающих частей, размер шрифта которых ниже 100 пунктов:

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

Для совпадающего текста ниже порога данная настройка предотвращает кернинг и может помочь согласовать отрисовку Aspose.Slides с визуальным выводом PowerPoint для шрифтов, подверженных этому специфическому поведению PowerPoint.

## **Управление свойствами шрифта текста**

Свойства шрифта можно задать на уровне абзаца через [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) или для отдельных частей через [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Следующий пример задаёт для первого абзаца шрифт Times New Roman 12 пунктов с жирным, курсивом и пунктирным подчёркиванием. Явное форматирование отдельных частей имеет приоритет над этими настройками по умолчанию:

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

Следующий пример применяет к частям, у которых эффективное форматирование — жирное, шрифт Times New Roman 13 пунктов, курсив и пунктирное подчёркивание:

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

![Свойства шрифта для текстовых частей](font_properties_for_text_portions.png)

## **Контроль нормализации высоты текста**

Используйте [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) при воспроизведении типографики шаблона или исследовании различий в высоте символов. В PowerPoint включение нормализации растягивает или сжимает отдельные символы по вертикали, чтобы придать им единообразную видимую высоту внутри текстовой части. Это не гарантирует одинаковую высоту текста в разных шрифтах.

Установите свойство в [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), чтобы явно включить или отключить нормализацию. `NullableBool.NOT_DEFINED` оставляет локальную настройку неустановленной, позволяя части унаследовать значение, например, из [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) абзаца. Это не означает `False`. Используйте [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) и прочитайте [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/), чтобы получить разрешённое логическое значение.

Следующий автономный пример требует установленный **Arial**. Он создаёт два текстовых блока, содержащих одинаковые заглавные буквы, прописные буквы, нижние выносы и символы с диакритикой размером 54 пункта. Оба абзаца включают нормализацию по умолчанию. Верхняя часть явно отключает её; нижняя часть наследует её. Размеры рамок, отступы и интервалы абзацев одинаковы, перенос и автоподгонка отключены для согласованного сравнения. Пример печатает `FALSE: False` и `NOT_DEFINED: True`, затем сохраняет «text_height_normalization.pptx»:

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

Сравнение ниже экспортировано из сохранённой презентации. В верхней строке нормализация отключена (`FALSE`); в нижней строке унаследовано включённое значение (`NOT_DEFINED` → `True`). Оставьте установленный Arial, чтобы воспроизвести внешний вид.

![Текст Arial 54 пункта с отключенной нормализацией сверху и унаследованной нормализацией снизу](text_height_normalization.png)

Нормализация меняет высоту символов без изменения назначенного значения [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/), которое задаёт размер шрифта в пунктах. Параметр абзаца [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) регулирует межстрочный интервал, а параметр текстовой рамки [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) контролирует, как текст или его контейнер подстраивается под размер. Эти настройки служат разным целям и могут независимо влиять на общий макет. Подробнее о форматировании абзацев и наследовании см. в статье [Manage Paragraph](/slides/ru/python-net/manage-paragraph/).

## **Применение и удаление зачеркивания**

Используйте [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) для текстовой части, чтобы отобразить исправления, отменённые термины или прежние цены без удаления оригинального текста. Установите его в [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) для одной или двух линий через текст.

Для удаления зачеркивания присвойте `TextStrikethroughType.NONE`. Это явно отключает эффект, даже если окружающее форматирование задаёт зачеркивание. В отличие от этого, `TextStrikethroughType.NOT_DEFINED` оставляет локальную настройку неустановленной, позволяя части унаследовать форматирование, например, из абзаца. Это не гарантирует удаление зачеркивания. Используйте [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), чтобы прочитать полученное форматирование, включая унаследованные значения.

Следующий автономный пример создаёт три сравнения цен. Каждый абзац имеет отдельные части для метки, прежней цены и текущей цены, поэтому зачеркиванию подлежит только прежняя цена. В первой строке зачеркивание применяется, а затем удаляется; остальные строки сохраняют одиночное и двойное зачеркивание. Изменение этого свойства сохраняет текст и его прочие параметры оформления, включая жирную прежнюю цену:

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

    # Применить зачеркивание, затем явно удалить его у первой прежней цены.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Результат, сверху вниз: без зачеркивания, одиночное зачеркивание и двойное зачеркивание.

![Предыдущие цены без зачеркивания, с одиночным зачеркиванием и с двойным зачеркиванием](strikethrough.png)

## **Установка вращения текста**

Используйте [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) для задания предопределённой ориентации текста внутри фигуры.

Следующий пример кода задаёт ориентацию текста в фигуре **[TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/)**, что вращает текст **на 90 градусов против часовой стрелки**:

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

## **Отображение цифр рядом в вертикальном тексте**

Чтобы удержать двухзначное число вместе в вертикальной японской метке, поместите обе цифры в одну текстовую часть и задайте для неё [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/). Пример создаёт две метки в новой презентации, используя [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) и 40‑пунктовый MS Gothic. Единственное различие – значение [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), присвоенное числовой части:

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

В PowerPoint левая метка (`TRUE`) показывает цифры вертикально и рядом между 和 и 年. Правая метка (`FALSE`) поворачивает пару на 90 градусов по часовой стрелке. Окружающие японские символы остаются вертикальными в обеих метках.

![Сравнение в PowerPoint вертикальных меток даты с прямыми цифрами слева и повернутыми цифрами справа.](vertical_date.png)

## **Установка пользовательского вращения для текстовых рамок**

Используйте [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) для задания произвольного угла вращения для [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Следующий пример кода вращает текстовую рамку на 3 градуса по часовой стрелке внутри фигуры:

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

## **Установка межстрочного интервала абзацев**

Aspose.Slides предоставляет [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) и [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) для управления интервалами абзацев. Эти свойства используются так:

* Используйте положительное значение, чтобы задать межстрочный интервал в процентах от высоты строки.
* Используйте отрицательное значение, чтобы задать межстрочный интервал в пунктах.

Следующий пример задаёт интервал внутри первого абзаца в 200 % от высоты строки (двойной интервал):

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

## **Управление разрывами строк**

Правила переноса строк в абзаце полезны в узких текстовых блоках и презентациях, где смешаны латинский и восточно‑азиатский тексты. Следующие свойства принадлежат [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), поэтому они применяются ко всему абзацу:

* [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) контролирует правила переноса строк для латинского текста. В смешанном тексте изменение этого параметра может также изменить места переноса соседнего восточно‑азиатского текста и знаков пунктуации.
* [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) контролирует правила переноса строк для восточно‑азиатского текста, включая ограничения на символы в начале и конце строки.

Эти правила не заменяют [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), который включает автоматический перенос внутри текстовой рамки. Они влияют на макет при переносе; они не вставляют символы разрыва строки. Явный разрыв строки заставляет новую строку в абзаце независимо от доступной ширины.

Следующий автономный пример создаёт узкий текстовый блок с китайским и латинским текстом. Он явно задаёт оба свойства переноса строк и сохраняет «line_breaking.pptx». Чтобы поэкспериментировать с любым правилом, измените значение данного свойства, оставив остальные настройки неизменными. Пример использует 24‑пунктовый Arial и SimSun, ширина рамки 160 пунктов, горизонтальные отступы 0. Параметр [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) установлен в [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/), чтобы размер текста и размеры рамки оставались фиксированными:

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

Следующий автономный пример включает висячую пунктуацию в 100‑пунктовой широкой текстовой рамке и сохраняет «hanging_punctuation.pptx». При 24‑пунктовом Arial и горизонтальных отступах 0 последний символ точки остаётся после слова «sentence» и выступает за правый край текста. Установите свойство в [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), чтобы сравнить: при этих настройках точка занимает отдельную строку. Перенос включён, автоподгонка отключена, чтобы фиксировать доступную ширину.

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

Не каждый знак пунктуации может «висеть». Видимый результат зависит от [условий шрифта и макета](#control-line-breaking): изменение шрифта, доступной ширины, отступов или параметров автоподгонки может убрать визуальную разницу.

## **Установка типа автоподгонки для текстовых рамок**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) определяет, как текст ведёт себя, когда превышает границы своего контейнера. Используйте его, чтобы контролировать, будет ли текст сжиматься, выходить за границы или автоматически изменять размер фигуры. Следующий пример настраивает фигуру так, чтобы она изменяла размер под текст, и сохраняет результат в «autofit_type.pptx»:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы подсчитать строки после автоматического переноса и увидеть, как меняются ширина текста или фигуры, см. [Count Rendered Lines](/slides/ru/python-net/manage-paragraph/). Одно лишь количество строк не указывает, переполняет ли текст контейнер.

## **Установка привязки текста в рамках**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) определяет, как текст позиционируется вертикально внутри фигуры, например, вверху, посередине или внизу. Следующий пример привязывает текст к нижней части первой фигуры и сохраняет результат в «text_anchor.pptx»:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Установка табуляции текста**

Используйте [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) и [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) для настройки табуляций в абзаце. Следующий пример задаёт интервал табуляции по умолчанию в 100 пунктов и добавляет левую табуляцию на 30 пунктов. Эти настройки влияют на текст, содержащий символы табуляции:

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

![Табуляция абзаца](paragraph_tabs.png)

## **Установка языка проверки**

Aspose.Slides предоставляет [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), позволяя задать язык проверки для текстовой части. Язык проверки определяет язык, используемый для проверки орфографии и грамматики в PowerPoint.

Следующий пример требует файл «presentation.pptx» с текстовым полем в первой фигуре первого слайда и хотя бы один абзац. Он заменяет содержимое первого абзаца на «1。», задаёт SimSun как шрифт и назначает упрощённый китайский язык проверки (`zh-CN`). Затем сохраняет результат в «proofing_language.pptx»:

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

### **Копирование метаданных языка**

При копировании многоязычного текста из шаблона сохраняйте как [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), так и [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Следующий автономный пример создаёт исходную часть с языком US English и альтернативным языком French, затем копирует текст и идентификаторы в часть новой презентации:

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
    # Если у источника нет альтернативного языка, None очищает значение получателя.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Чтобы попробовать источник без альтернативного языка, опустите присваивание `"fr-FR"`. В этом случае альтернативный идентификатор будет `None`, и то же выражение копирования сохранит его отсутствие, не вводя значение по умолчанию, даже если получатель ранее имел альтернативный язык.

Эти идентификаторы хранят метаданные языка. Сохранение их не определяет, какой словарь PowerPoint выберет для проверки орфографии или грамматики.

## **Установка языка по умолчанию**

Используйте [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) для определения языка по умолчанию для текста, создаваемого при загрузке или создании презентации. Следующий пример создаёт презентацию с языком US English по умолчанию, добавляет текстовое поле и выводит `en-US` для его первой текстовой части:

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

## **Установка стиля текста по умолчанию**

Чтобы применить форматирование текста по умолчанию на уровне презентации, используйте [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Следующий пример задаёт 14‑пунктовый жирный шрифт как значение по умолчанию для абзацев верхнего уровня в новой презентации и сохраняет её в «default_text_style.pptx». Текст может наследовать эти значения, если более конкретное форматирование их не переопределяет:

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

## **Извлечение текста с эффектом All-Caps**

В PowerPoint применение эффекта **All Caps** к шрифту делает текст заглавным на слайде, даже если он изначально был набран строчными. При получении такой части текста с помощью Aspose.Slides библиотека возвращает текст точно так, как он был введён. Чтобы соответствовать отображаемому тексту, проверьте [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) и при значении `ALL` преобразуйте возвращённую строку в верхний регистр.

Этот пример требует файл «sample2.pptx» с текстовым полем в первой фигуре первого слайда. Первая часть первого абзаца содержит «Hello, Aspose!», к которой применён эффект All Caps, как показано ниже.

![Эффект All Caps](all_caps_effect.png)

Следующий пример кода показывает, как извлечь текст с применённым эффектом **All Caps**:

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

Для изменения текста в таблице на слайде используйте [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Пройдитесь по ячейкам и обновите каждую через [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) и форматирование абзацев через [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Как применить градиентный цвет к тексту на слайде PowerPoint?**

Чтобы применить градиентный цвет к тексту, используйте [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Установите [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) в [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) и настройте остановки градиента, направление и прозрачность.

Связанная функция: [Форматирование текста в слайдах](/slides/ru/features/text-formatting/).