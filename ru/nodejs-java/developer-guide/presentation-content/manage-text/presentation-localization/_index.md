---
title: Автоматизировать локализацию презентаций в JavaScript
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/nodejs-java/presentation-localization/
keywords:
- смена языка
- проверка орфографии
- подавление проверки орфографии
- язык проверки
- идентификатор языка
- многоязычный текст
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Установите языки проверки для текста презентаций PowerPoint и OpenDocument в JavaScript с помощью Aspose.Slides, включая значения по умолчанию и многоязычные абзацы."
---
## **Обзор**

Aspose.Slides for Node.js via Java позволяет настраивать метаданные проверки орфографии для отдельных фрагментов текста. Используйте [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) для указания языка проверки, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) — для разрешения или подавления проверки орфографии, и [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) — для управления более широким состоянием «без проверки». Поскольку эти параметры применяются на уровне фрагмента, один абзац может содержать несколько языков и разных правил проверки.

Эта статья объясняет, как назначить язык конкретному тексту, установить язык по умолчанию для нового текста с помощью [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), создавать многоязычные абзацы, выбирать между `SpellCheck` и `ProofDisabled`, а также сохранять заданные параметры при использовании [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Эти свойства хранят метаданные для приложений презентаций; они не переводят текст, не выполняют проверку орфографии на основе словарей и не возвращают ошибочно написанные слова.

## **Установить язык проверки для текста**

Создайте или загрузите [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), получите требуемый фрагмент текста через [Portion.getPortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#getPortionFormat--), и назначьте его идентификатор языка. В следующем примере создаётся фигура, устанавливается британский английский как язык проверки и результат сохраняется с помощью [Presentation.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить язык по умолчанию для нового текста**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) для указания языка проверки, который Aspose.Slides назначит вновь создаваемому тексту. Этот параметр полезен, когда большинство или весь новый текст в презентации использует один и тот же язык. Он не изменяет языковые метаданные текста, у которого уже задан явный язык.

В следующем примере создаётся презентация, в которой новый текст использует правила проверки орфографии немецкого языка:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Использовать несколько языков в одном абзаце**

[Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/) содержит коллекцию фрагментов текста. Создайте отдельный [Portion](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/) для каждого языка и задайте его `LanguageId` независимо.

В этом примере создаётся один абзац с фрагментами на английском и французском языках:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Включить или подавлять проверку орфографии для отдельных фрагментов**

[PortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portionformat/) наследует общие текстовые свойства, определённые в [BasePortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/). Получите формат фрагмента через [Portion.getPortionFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/portion/#getPortionFormat--) и используйте [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) для управления тем, может ли приложение презентаций проверять орфографию этого фрагмента. Значение по умолчанию — `false`: `true` разрешает проверку, а `false` её подавляет.

Параметр применяется к отдельным фрагментам текста. Разные фрагменты в одном абзаце могут использовать разные значения. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) и `setSpellCheck` выполняют взаимодополняющие функции: `setLanguageId` указывает язык проверки, а `setSpellCheck` определяет, разрешена ли проверка орфографии для фрагмента.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) также управляет проверкой, но представляет более широкое состояние «не проверять» как [NullableBool](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/nullablebool/). Используйте `setSpellCheck`, когда нужен простой логический переключатель именно для проверки орфографии. Используйте `setProofDisabled`, когда нужно сохранить или явно контролировать метаданные «без проверки» презентации, включая состояние `NotDefined`. Если вы задаёте оба свойства, сохраняйте их согласованность; не комбинируйте `setSpellCheck(true)` с `setProofDisabled(NullableBool.True)`.

Эти свойства настраивают метаданные проверки, используемые PowerPoint и другими приложениями презентаций. Aspose.Slides не использует их для выполнения словарной проверки орфографии и не возвращает список ошибочно написанных слов.

В следующем полном примере создаётся входная презентация, загружается, различным фрагментам в одном абзаце назначаются разные параметры проверки орфографии и языки, результат сохраняется, открывается повторно и проверяются сохранённые значения:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) объединяет соседние фрагменты с одинаковым форматированием. Различие только в `SpellCheck` не удерживает такие фрагменты раздельно; после объединения полученный фрагмент сохраняет значение `SpellCheck` первого фрагмента. Если фрагменты требуют разных настроек проверки орфографии, вызовите `joinPortionsWithSameFormatting` до назначения этих настроек или проанализируйте границы получившегося фрагмента и повторно примените настройки. Фрагменты с разными значениями `LanguageId` остаются отдельными, поскольку их форматирование языка проверки отличается.

## **FAQ**

**Переводит ли идентификатор языка текст?**

Нет. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) сохраняет метаданные проверки орфографии и грамматики; он не меняет содержимое текста. Переведите текст отдельно, а затем задайте соответствующий идентификатор языка для каждого переведённого фрагмента.

**Контролирует ли язык проверки шрифты, переносы или перенос строк?**

Нет. Идентификатор языка предназначен только для проверки. Отображение текста и разметка в основном зависят от доступных [fonts](/slides/ru/nodejs-java/powerpoint-fonts/), системы письма и настроек текстового фрейма. Для надёжного отображения предоставьте необходимые шрифты, настройте [font substitution](/slides/ru/nodejs-java/font-substitution/) или [embed fonts](/slides/ru/nodejs-java/embedded-font/) в презентации.

**Можно ли в одном абзаце использовать несколько языков проверки?**

Да. Назначьте каждый язык отдельному фрагменту, как показано в примере многоязычного абзаца.

**Стоит ли использовать `setDefaultTextLanguage` или `setLanguageId`?**

Используйте [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), когда нужен язык по умолчанию для вновь создаваемого текста. Используйте [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), когда конкретному фрагменту требуется явно указанный язык проверки или когда абзац содержит несколько языков.