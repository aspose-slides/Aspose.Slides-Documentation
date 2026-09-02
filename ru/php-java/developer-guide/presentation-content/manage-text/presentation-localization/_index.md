---
title: Автоматизация локализации презентаций в PHP
linktitle: Локализация презентаций
type: docs
weight: 100
url: /ru/php-java/presentation-localization/
keywords:
- изменение языка
- проверка орфографии
- подавление проверки орфографии
- язык проверки
- идентификатор языка
- многоязычный текст
- PowerPoint
- презентация
- PHP
- Aspose.Slides
description: "Установите языки проверки для текста презентаций PowerPoint и OpenDocument в PHP с помощью Aspose.Slides, включая параметры по умолчанию и многоязычные абзацы."
---
## **Обзор**

Aspose.Slides for PHP via Java позволяет настраивать метаданные проверки правописания для отдельных частей текста. Используйте [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId) для указания языка проверки, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setSpellCheck) для включения или отключения проверки орфографии и [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setProofDisabled) для управления более широким состоянием «без проверки». Поскольку эти параметры применяются на уровне части, один абзац может содержать несколько языков и различных правил проверки.

В этой статье объясняется, как назначить язык определённому фрагменту текста, установить язык по умолчанию для нового текста с помощью [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), создавать многоязычные абзацы, выбирать между `SpellCheck` и `ProofDisabled` и сохранять требуемые настройки при использовании [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Эти свойства хранят метаданные для приложений презентаций; они не переводят текст, не выполняют проверку орфографии на основе словарей и не возвращают ошибочно написанные слова.

## **Установить язык проверки правописания для текста**

Создайте или загрузите [Presentation](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/), получите нужную часть текста через [Portion::getPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#getPortionFormat) и задайте её идентификатор языка. В следующем примере создаётся фигура, устанавливается британский английский как язык проверки и сохраняется результат с помощью [Presentation::save](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Установить язык по умолчанию для нового текста**

Используйте [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) для указания языка проверки, который Aspose.Slides присваивает только что созданному тексту. Эта настройка полезна, когда большинство или весь новый текст в презентации использует один и тот же язык. Она не изменяет метаданные языка у текста, у которого уже явно задан язык.

В следующем примере создаётся презентация, в которой новый текст использует правила немецкой проверки правописания:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Использовать несколько языков в одном абзаце**

[Paragraph](https://reference.aspose.com/slides/ru/php-java/aspose.slides/paragraph/) содержит коллекцию частей текста. Создайте отдельный [Portion](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/) для каждого языка и независимо задайте его `LanguageId`.

В этом примере создаётся один абзац с частями на английском и французском языках:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Включить или подавить проверку орфографии для отдельных частей**

[PortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portionformat/) наследует общие свойства текста, определённые в [BasePortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/). Получите формат части через [Portion::getPortionFormat](https://reference.aspose.com/slides/ru/php-java/aspose.slides/portion/#getPortionFormat) и используйте [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setSpellCheck) для управления тем, будет ли приложение презентации проверять орфографию в этой части. Значение по умолчанию — `false`: `true` включает проверку, `false` её подавляет.

Настройка применяется к отдельным частям текста. Поэтому разные части в одном абзаце могут иметь разные значения. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId) и `setSpellCheck` выполняют взаимодополняющие функции: `setLanguageId` задаёт язык проверки, а `setSpellCheck` определяет, разрешена ли проверка орфографии для части.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setProofDisabled) также управляет проверкой, но представляет более широкое состояние «не проверять» как [NullableBool](https://reference.aspose.com/slides/ru/php-java/aspose.slides/nullablebool/). Используйте `setSpellCheck`, когда нужен простой логический переключатель именно для орфографии. Используйте `setProofDisabled`, когда необходимо сохранять или явно управлять метаданными «без проверки», включая состояние `NotDefined`. Если вы задаёте оба свойства, сохраняйте их согласованность; не комбинируйте `setSpellCheck(true)` с `setProofDisabled(NullableBool::True)`.

Эти свойства настраивают метаданные проверки, используемые PowerPoint и другими приложениями презентаций. Aspose.Slides не использует их для запуска словарной проверки орфографии или возврата списка ошибочных слов.

В следующем полном примере создаётся исходная презентация, загружается, различным частям в одном абзаце назначаются разные настройки проверки и языки, результат сохраняется, открывается снова и проверяется сохранённые значения:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ru/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) объединяет соседние части, имеющие одинаковое форматирование. Различие только в `SpellCheck` не сохраняет части раздельными; после объединения полученная часть сохраняет значение `SpellCheck` первой части. Если части требуют разных настроек проверки, вызывайте `joinPortionsWithSameFormatting` до задания этих настроек или проанализируйте границы получившихся частей и повторно примените настройки. Части с разными значениями `LanguageId` остаются раздельными, поскольку их форматирование языка проверки различается.

## **Часто задаваемые вопросы**

**Переводит ли идентификатор языка текст?**

Нет. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId) сохраняет метаданные проверки орфографии и грамматики; он не меняет содержание текста. Переведите текст отдельно, а затем задайте соответствующий идентификатор языка для каждой переведённой части.

**Контролирует ли язык проверки шрифты, переносы или перенос строк?**

Нет. Идентификатор языка предназначен только для проверки. Отображение текста и его разметка в основном зависят от доступных [fonts](/slides/ru/php-java/powerpoint-fonts/), системы письма и настроек текстового фрейма. Для надёжного отображения предоставьте необходимые шрифты, настройте [font substitution](/slides/ru/php-java/font-substitution/) или [embed fonts](/slides/ru/php-java/embedded-font/) в презентации.

**Можно ли в одном абзаце использовать несколько языков проверки?**

Да. Назначьте каждый язык отдельной части, как показано в примере многоязычного абзаца.

**Следует ли использовать `setDefaultTextLanguage` или `setLanguageId`?**

Используйте [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ru/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), когда нужен язык по умолчанию для только что создаваемого текста. Используйте [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ru/php-java/aspose.slides/baseportionformat/#setLanguageId), когда конкретной части требуется явный язык проверки или когда в абзаце присутствует несколько языков.