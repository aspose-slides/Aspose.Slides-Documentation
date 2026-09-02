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
- текстовый кадр
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Поиск, выделение и замена текста в презентациях PowerPoint с помощью Aspose.Slides for Python via .NET."
---
## **Обзор**

Aspose.Slides for Python via .NET может искать, выделять и заменять текст в отдельном текстовом фрейме или в презентации целиком. Эти возможности полезны для проверки, редактирования, проверки терминологии, очистки шаблонов и других автоматизированных процессов обработки документов.

В первых примерах ниже используется файл с именем "sample.pptx", который содержит один текстовый блок на первом слайде со следующим текстом:

![Пример текста](sample_text.png)

## **Выберите область поиска**

Используйте методы класса [TextFrame](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/) чтобы ограничить операцию одним текстовым фреймом. Используйте методы класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/) чтобы обработать весь применимый текст в презентации.

| Операция | Один текстовый фрейм | Вся презентация |
|---|---|---|
| Выделить буквальный текст | [TextFrame.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/highlight_text/) |
| Выделить совпадения регулярных выражений | [TextFrame.highlight_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/highlight_regex/) |
| Заменить буквальный текст | [TextFrame.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/replace_text/) |
| Заменить совпадения регулярных выражений | [TextFrame.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/replace_regex/) |

## **Настройка сопоставления текста**

Для операций с буквальным текстом используйте [TextSearchOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/) для управления сопоставлением:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/whole_words_only/) ограничивает совпадения полными словами.  
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/case_sensitive/) управляет требованием совпадения регистра символов.  
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/include_notes/) включает заметки слайдов в поиск, замену и выделение на уровне презентации.

Операции с регулярными выражениями используют строку шаблона, поэтому такие правила, как чувствительность к регистру и границы слов, задаются самим выражением.

## **Выделение текста**

Используйте метод [TextFrame.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_text/) для выделения буквальных совпадений текста в текстовом фрейме. Передайте [TextSearchOptions](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/) для управления поиском.

Пример кода ниже выделяет все вхождения символов **"try"** и затем выделяет только полное слово **"to"**.

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

## **Выделение текста с использованием регулярных выражений**

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

## **Выделение текста во всей презентации**

Используйте [Presentation.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/highlight_text/) и [Presentation.highlight_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/highlight_regex/) для поиска во всех применимых текстовых фреймах презентации. В следующем примере выделяется буквальный термин и все адреса электронной почты:

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

Используйте [TextFrame.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_text/) для буквального текста и [TextFrame.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_regex/) для замены на основе шаблона. Эти методы обновляют найденный текст внутри существующего текстового фрейма, сохраняя форматирование окружающих частей вместо полного пересоздания фрейма из строки.

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

Если одно совпадение охватывает части с разным форматированием, проверьте результат, чтобы убедиться, какое форматирование должно применяться к заменяемому тексту.

## **Замена текста во всей презентации**

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

## **Часто задаваемые вопросы**

**Как я могу искать только один текстовый блок вместо всей презентации?**

Получите текстовый фрейм формы и вызовите [TextFrame.highlight_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_text/) или [TextFrame.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_regex/) для этого фрейма. Методы уровня презентации обрабатывают все применимые текстовые фреймы.

**Как я могу сопоставлять полные слова с правильным регистром?**

Установите [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/whole_words_only/) и [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/case_sensitive/) в `True` и передайте параметры в метод выделения или замены буквального текста. Для регулярных выражений определите границы слов и чувствительность к регистру непосредственно в шаблоне.

**Может ли поиск и замена включать текст в заметках слайдов?**

Да. Установите [TextSearchOptions.include_notes](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textsearchoptions/include_notes/) в `True`, когда используете операцию буквального текста на уровне презентации.

**Сохраняет ли замена текста его форматирование?**

[TextFrame.replace_text](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_text/) и [TextFrame.replace_regex](https://reference.aspose.com/slides/ru/python-net/aspose.slides/textframe/replace_regex/) изменяют найденный текст внутри существующего текстового фрейма и сохраняют форматирование окружающих частей. Если совпадение охватывает участки с разным форматированием, проверьте результат, чтобы убедиться, что замена использует желаемый стиль.