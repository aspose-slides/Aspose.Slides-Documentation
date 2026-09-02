---
title: Автоматизировать локализацию презентаций с помощью Python
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/python-net/presentation-localization/
keywords:
- смена языка
- проверка орфографии
- подавление проверки орфографии
- язык проверки
- идентификатор языка
- многоязычный текст
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Устанавливайте языки проверки для текста презентаций PowerPoint и OpenDocument в Python с помощью Aspose.Slides, включая параметры по умолчанию и многоязычные абзацы."
---
## **Обзор**

Aspose.Slides for Python via .NET позволяет настраивать метаданные проверки орфографии для отдельных фрагментов текста. Используйте [BasePortionFormat.language_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/language_id/) для указания языка проверки, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/spell_check/) чтобы разрешить или подавить проверку орфографии, и [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/proof_disabled/) для управления более общим состоянием «не проверять». Поскольку эти настройки применяются на уровне фрагмента, один абзац может содержать несколько языков и разных правил проверки.

В этой статье объясняется, как назначить язык конкретному тексту, установить язык по умолчанию для нового текста с помощью [LoadOptions.default_text_language](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/default_text_language/), создавать многоязычные абзацы, выбирать между `spell_check` и `proof_disabled`, и сохранять необходимые настройки при использовании [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Эти свойства хранят метаданные для приложений презентаций; они не переводят текст, не выполняют проверку орфографии на основе словаря и не возвращают ошибочные слова.

## **Установить язык проверки для текста**

Создайте или загрузите [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/), получите нужный фрагмент текста через [Portion.portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/portion_format/), и задайте его идентификатор языка. В следующем примере создаётся фигура, устанавливается британский английский как язык проверки, и сохраняется результат с помощью [Presentation.save](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Установить язык по умолчанию для нового текста**

Используйте [LoadOptions.default_text_language](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/default_text_language/) для указания языка проверки, который Aspose.Slides будет назначать только что созданному тексту. Эта настройка полезна, когда большинство или весь новый текст в презентации использует один и тот же язык. Она не изменяет метаданные языка уже существующего текста с явным указанием языка.

В следующем примере создаётся презентация, в которой новый текст использует правила для немецкого языка:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Использовать несколько языков в одном абзаце**

[Paragraph](https://reference.aspose.com/slides/ru/python-net/aspose.slides/paragraph/) содержит коллекцию фрагментов текста. Создайте отдельный [Portion](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/) для каждого языка и задайте его `language_id` независимо.

Этот пример создаёт один абзац с английскими и французскими фрагментами:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Включить или подавить проверку орфографии для отдельных фрагментов**

[PortionFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portionformat/) наследует общие свойства текста, определённые в [BasePortionFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/). Получите формат фрагмента через [Portion.portion_format](https://reference.aspose.com/slides/ru/python-net/aspose.slides/portion/portion_format/) и задайте [BasePortionFormat.spell_check](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/spell_check/) для управления тем, может ли приложение презентаций проверять орфографию этого фрагмента. Значение по умолчанию — `False`: `True` разрешает проверку, а `False` подавляет её.

Эта настройка применяется к отдельным фрагментам текста. Поэтому разные фрагменты в одном абзаце могут иметь разные значения. [BasePortionFormat.language_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/language_id/) и `spell_check` служат взаимодополняющим целям: `language_id` определяет язык проверки, а `spell_check` указывает, разрешена ли проверка орфографии для фрагмента.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/proof_disabled/) также управляет проверкой, но представляет более общее состояние «не проверять» как [NullableBool](https://reference.aspose.com/slides/ru/python-net/aspose.slides/nullablebool/). Используйте `spell_check`, когда нужен простой логический переключатель именно для проверки орфографии. Используйте `proof_disabled`, когда необходимо сохранять или явно управлять метаданными «не проверять», включая состояние `NOT_DEFINED`. Если задаёте оба свойства, поддерживайте их согласованность; не комбинируйте `spell_check = True` с `proof_disabled = slides.NullableBool.TRUE`.

Эти свойства конфигурируют метаданные проверки, используемые PowerPoint и другими приложениями презентаций. Aspose.Slides не использует их для выполнения словарной проверки орфографии и не возвращает список ошибочных слов.

Следующий полный пример создаёт входную презентацию, загружает её, назначает разные настройки проверки орфографии и языки проверки двум фрагментам в одном абзаце, сохраняет результат, повторно открывает его и проверяет сохранённые значения:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) объединяет соседние фрагменты с одинаковым форматированием. Различие только в `spell_check` не сохраняет их раздельными; после объединения результирующий фрагмент сохраняет значение `spell_check` первого фрагмента. Если фрагменты требуют разных настроек проверки орфографии, вызовите `join_portions_with_same_formatting` до назначения этих настроек или проверьте границы получившегося фрагмента и повторно примените настройки. Фрагменты с разными значениями `language_id` остаются раздельными, потому что их форматирование языка проверки различается.

## **Часто задаваемые вопросы**

**Переводит ли идентификатор языка текст?**

Нет. [BasePortionFormat.language_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/language_id/) хранит метаданные проверки орфографии и грамматики; он не изменяет содержание текста. Переведите текст отдельно, затем задайте соответствующий идентификатор языка для каждого переведённого фрагмента.

**Контролирует ли язык проверки шрифты, переносы или перенос строк?**

Нет. Идентификатор языка предназначен только для проверки. Отображение текста и разметка в основном зависят от доступных [fonts](/slides/ru/python-net/powerpoint-fonts/), системы письма и настроек текстовой рамки. Для надёжного отображения предоставьте требуемые шрифты, настройте [font substitution](/slides/ru/python-net/font-substitution/) или [embed fonts](/slides/ru/python-net/embedded-font/) в презентации.

**Можно ли использовать несколько языков проверки в одном абзаце?**

Да. Назначьте каждый язык отдельному фрагменту, как показано в примере многоязычного абзаца.

**Что использовать: `default_text_language` или `language_id`?**

Используйте [LoadOptions.default_text_language](https://reference.aspose.com/slides/ru/python-net/aspose.slides/loadoptions/default_text_language/), если нужен язык по умолчанию для вновь создаваемого текста. Используйте [BasePortionFormat.language_id](https://reference.aspose.com/slides/ru/python-net/aspose.slides/baseportionformat/language_id/), когда конкретному фрагменту требуется явный язык проверки или когда абзац содержит несколько языков.