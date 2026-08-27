---
title: Поиск и замена текста в презентациях PowerPoint на Python
linktitle: Поиск и замена текста
type: docs
weight: 55
url: /ru/python-net/search-and-replace-text/
keywords:
- поиск текста
- выделение текста
- замена текста
- регулярное выражение
- текстовый фрейм
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Поиск, выделение и замена текста в презентациях PowerPoint с помощью Aspose.Slides для Python через .NET."
---
## **Обзор**

Aspose.Slides for Python via .NET может выполнять поиск, выделение и замену текста в отдельном текстовом фрейме или по всей презентации. Эти возможности полезны для проверки, редактирования, проверки терминологии, очистки шаблонов и других автоматизированных рабочих процессов обработки документов.

В первых примерах ниже используется файл «sample.pptx», который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выбор области поиска**

Используйте методы на [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) для ограничения операции одним текстовым фреймом. Используйте методы на [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) для обработки всего применимого текста в презентации.

| Операция | Один текстовый фрейм | Вся презентация |
|---|---|---|
| Выделить буквальный текст | [TextFrame.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/highlight_text/) |
| Выделить совпадения регулярного выражения | [TextFrame.highlight_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/highlight_regex/) |
| Заменить буквальный текст | [TextFrame.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/replace_text/) |
| Заменить совпадения регулярного выражения | [TextFrame.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/replace_regex/) |

## **Настройка сопоставления текста**

Для операций с буквальным текстом используйте [TextSearchOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/) для управления сопоставлением:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/whole_words_only/) ограничивает совпадения полными словами.  
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/case_sensitive/) определяет, должен ли регистр символов совпадать.  
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/include_notes/) включает заметки слайдов в операции поиска, замены и выделения на уровне презентации.  

Операции с регулярными выражениями используют строку‑шаблон, поэтому правила сопоставления, такие как чувствительность к регистру и границы слов, задаются в самом выражении.

## **Определение владельца текстового фрейма**

Общие рабочие процессы обработки текста часто получают [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) во время поиска, замены, проверки или экспорта текста. Используйте [TextFrame.parent_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/parent_shape/) и [TextFrame.parent_cell](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/parent_cell/) для определения, какой объект презентации владеет этим фреймом.

Ожидаемые значения зависят от владельца:

| Владелец текстового фрейма | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape или другая форма, содержащая текст | Владелец [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/) | `None` |
| Ячейка таблицы | `None` | Владелец [Cell](https://reference.aspose.com/slides/ru/python-net/aspose.slides/cell/) |

Обе свойства являются навигационными свойствами только для чтения. Чтение их не перемещает текстовый фрейм и не меняет его владельца. Универсальный код должен проверять оба значения на `None` и учитывать возможность отсутствия любого владельца.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Для содержимого SmartArt перебирайте формы в [SmartArtNode.shapes](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartartnode/shapes/) и получайте каждую [ISmartArtShape.text_frame](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/ismartartshape/text_frame/). Текстовый фрейм можно проследить к связанной форме через [TextFrame.parent_shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/parent_shape/), в то время как [TextFrame.parent_cell](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/parent_cell/) имеет значение `None`. Поэтому ветка формы в примере также обрабатывает текст из узлов SmartArt.

## **Выделение текста**

Используйте метод [TextFrame.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_text/) для выделения совпадений буквального текста в текстовом фрейме. Передайте [TextSearchOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/) для управления поиском.

Пример кода ниже выделяет все вхождения символов **"try"**, а затем выделяет только полное слово **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Выделить каждое вхождение "try" в текстовом фрейме.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Выделить только полное слово "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Результат:

![Выделенный текст](highlighted_text.png)

## **Выделение текста с помощью регулярных выражений**

Метод [TextFrame.highlight_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_regex/) выделяет совпадения текста, найденные регулярным выражением, в текстовом фрейме.

Следующий код выделяет все слова, содержащие семь и более символов:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Результат:

![Выделенный текст с использованием регулярного выражения](highlighted_text_using_regex.png)

## **Выделение текста по всей презентации**

Используйте [Presentation.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/highlight_text/) и [Presentation.highlight_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/highlight_regex/) для поиска по всем применимым текстовым фреймам в презентации. В следующем примере выделяется буквальный термин и все адреса электронной почты:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Замена текста в текстовом фрейме**

Используйте [TextFrame.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_text/) для буквального текста и [TextFrame.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_regex/) для замены по шаблону. Эти методы обновляют найденный текст внутри существующего текстового фрейма, сохраняя форматирование окружающих фрагментов вместо полной перестройки фрейма из обычной строки.

Следующий пример стандартизирует вариант написания и затем заменяет метки версий:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Если одно совпадение охватывает части с различным форматированием, проверьте результат, чтобы убедиться, какое форматирование должно применяться к заменяемому тексту.

## **Замена текста по всей презентации**

Используйте [Presentation.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/replace_text/) и [Presentation.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/replace_regex/) для применения тех же операций ко всей презентации. Это полезно для очистки шаблонов, обновления терминологии и редактирования.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Вопросы и ответы**

**Как выполнить поиск только в одном текстовом блоке, а не во всей презентации?**

Получите текстовый фрейм формы и вызовите [TextFrame.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_text/) или [TextFrame.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_regex/) для этого фрейма. Методы уровня презентации обрабатывают все применимые текстовые фреймы.

**Как сопоставить полные слова с правильным регистром?**

Установите [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/whole_words_only/) и [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/case_sensitive/) в `True` и передайте параметры в метод выделения или замены буквального текста. Для регулярных выражений определите границы слов и чувствительность к регистру непосредственно в шаблоне.

**Можно ли включить поиск и замену текста из заметок слайдов?**

Да. Установите [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/include_notes/) в `True`, когда используете операцию буквального текста на уровне презентации.

**Сохраняет ли замена текста его форматирование?**

[TextFrame.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_text/) и [TextFrame.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_regex/) изменяют найденный текст внутри существующего фрейма и сохраняют форматирование окружающих фрагментов. Если совпадение охватывает части с разным форматированием, проверьте результат, чтобы убедиться, что замена использует требуемый стиль.