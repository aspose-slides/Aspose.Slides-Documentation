---
title: Автоматизация локализации презентаций в Python через Java
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/python-java/presentation-localization/
keywords:
- изменение языка
- проверка орфографии
- подавление проверки орфографии
- язык проверки
- идентификатор языка
- многоязычный текст
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Установите языки проверки для текста презентаций PowerPoint и OpenDocument в Python через Java с Aspose.Slides, включая значения по умолчанию и многоязычные абзацы."
---
## **Обзор**

Aspose.Slides for Python via Java позволяет настраивать метаданные проверки для отдельных текстовых частей. Используйте [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId), чтобы указать язык проверки, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setSpellCheck), чтобы разрешить или подавлять проверку орфографии, и [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setProofDisabled), чтобы управлять более широким состоянием «не проверять». Поскольку эти настройки применяются на уровне части, один абзац может содержать несколько языков и разных правил проверки.

В этой статье объясняется, как назначить язык конкретному тексту, установить язык по умолчанию для нового текста с помощью [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), создать многоязычные абзацы, выбрать между [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setSpellCheck) и [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setProofDisabled), а также сохранить заданные параметры при использовании [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Эти свойства хранят метаданные для приложений презентаций; они не переводят текст, не выполняют проверку орфографии на основе словаря и не возвращают misspelled words.

## **Установить язык проверки для текста**

Создайте или загрузите [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), получите требуемую текстовую часть через [Portion.getPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getPortionFormat) и задайте её идентификатор языка. Следующий пример создаёт форму, устанавливает британский английский как язык проверки и сохраняет результат с помощью [Presentation.save](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установить язык по умолчанию для нового текста**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), чтобы указать язык проверки, который Aspose.Slides назначает новому создаваемому тексту. Эта настройка полезна, когда большинство или весь новый текст в презентации использует один язык. Она не меняет языковые метаданные текста, у которого уже явно указан язык.

Следующий пример создаёт презентацию, в которой новый текст использует немецкие правила проверки:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Использовать несколько языков в одном абзаце**

[Paragraph](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraph/) содержит коллекцию текстовых частей. Создайте отдельный [Portion](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/) для каждого языка и установите его [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId) независимо.

Этот пример создаёт один абзац с английскими и французскими частями:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Включить или подавить проверку орфографии для отдельных частей**

[PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/) наследует общие свойства текста, определённые в [BasePortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/). Получите формат части через [Portion.getPortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portion/#getPortionFormat) и используйте [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setSpellCheck), чтобы управлять тем, будет ли приложение проверки орфографии проверять орфографию для этой части. Значение по умолчанию — `False`: `True` разрешает проверку орфографии, а `False` подавляет её.

Настройка применяется к отдельным текстовым частям. Разные части в одном абзаце могут therefore использовать разные значения. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId) и [setSpellCheck](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setSpellCheck) служат взаимодополняющим целям: [setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId) указывает язык проверки, тогда как [setSpellCheck](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setSpellCheck) определяет, разрешена ли проверка орфографии для части.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setProofDisabled) также управляет проверкой, но представляет более общее состояние «не проверять» в виде [NullableBool](https://reference.aspose.com/slides/ru/python-java/aspose.slides/nullablebool/). Используйте [setSpellCheck], когда нужен непосредственный переключатель Boolean специально для проверки орфографии. Используйте [setProofDisabled], когда необходимо сохранить или явно контролировать метаданные «не проверять» презентации, включая её состояние [NullableBool.NotDefined](https://reference.aspose.com/slides/ru/python-java/aspose.slides/nullablebool/#NotDefined). Если вы задаёте оба свойства, поддерживайте их значения согласованными; не комбинируйте [setSpellCheck] = `True` с [setProofDisabled] = [NullableBool.True](https://reference.aspose.com/slides/ru/python-java/aspose.slides/nullablebool/#True).

Эти свойства конфигурируют метаданные проверки, используемые PowerPoint и другими приложениями презентаций. Aspose.Slides не использует их для выполнения словарной проверки орфографии или возврата списка misspelled words.

Следующий полный пример создаёт входную презентацию, загружает её, назначает разные настройки проверки орфографии и языки проверки двум частям в одном абзаце, сохраняет результат, открывает его снова и проверяет сохранённые значения:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) объединяет соседние части, имеющие одинаковое форматирование. Различие только в [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setSpellCheck) не удерживает такие части раздельно; после объединения результирующая часть сохраняет значение [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setSpellCheck) первой части. Если части нуждаются в разных настройках проверки орфографии, вызовите [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) до назначения этих настроек, либо проанализируйте границы получившихся частей и повторно примените настройки. Части с разными значениями [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId) остаются отдельными, поскольку их форматирование языка проверки отличается.

## **FAQ**

**Переводит ли идентификатор языка текст?**

Нет. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId) хранит метаданные проверки орфографии и грамматики; он не изменяет содержимое текста. Переведите текст отдельно, а затем задайте соответствующий идентификатор языка для каждой переведённой части.

**Контролирует ли язык проверки шрифты, переносы слов или перенос строк?**

Нет. Идентификатор языка предназначен только для проверки. Отображение текста и макет в основном зависят от доступных [fonts](/slides/ru/python-java/powerpoint-fonts/), системы письма и настроек текстового кадра. Для надёжного отображения предоставьте требуемые шрифты, настройте [font substitution](/slides/ru/python-java/font-substitution/) или [embed fonts](/slides/ru/python-java/embedded-font/) в презентации.

**Можно ли в одном абзаце использовать несколько языков проверки?**

Да. Назначьте каждый язык отдельной части, как показано в примере многоязычного абзаца.

**Стоит ли использовать [setDefaultTextLanguage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) или [setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), когда вам нужен язык по умолчанию для только что создаваемого текста. Используйте [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#setLanguageId), когда конкретной части нужен явно указанный язык проверки или когда абзац содержит несколько языков.