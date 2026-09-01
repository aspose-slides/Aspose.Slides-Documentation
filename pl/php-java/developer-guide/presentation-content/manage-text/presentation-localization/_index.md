---
title: Automatyzacja lokalizacji prezentacji w PHP
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/php-java/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- wyłączenie sprawdzania pisowni
- język korekty
- identyfikator języka
- tekst wielojęzyczny
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Ustaw języki korekty dla tekstu prezentacji PowerPoint i OpenDocument w PHP przy użyciu Aspose.Slides, w tym wartości domyślne i wielojęzyczne akapity."
---
## **Przegląd**

Aspose.Slides for PHP via Java umożliwia konfigurowanie metadanych korekty dla poszczególnych fragmentów tekstu. Użyj [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId) aby określić język korekty, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setSpellCheck) aby zezwolić lub wyłączyć sprawdzanie pisowni oraz [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setProofDisabled) aby kontrolować szerszy stan wyłączonej korekty. Ponieważ te ustawienia są stosowane na poziomie fragmentu, jeden akapit może zawierać wiele języków i różnych reguł korekty.

Ten artykuł wyjaśnia, jak przypisać język do określonego tekstu, ustawić domyślny język dla nowego tekstu za pomocą [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), zbudować wielojęzyczne akapity, wybrać pomiędzy `SpellCheck` a `ProofDisabled` oraz zachować zamierzone ustawienia podczas użycia [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Właściwości te przechowują metadane dla aplikacji prezentacji; nie tłumaczą tekstu, nie wykonują sprawdzania pisowni opartego na słowniku ani nie zwracają błędnie napisanych słów.

## **Ustaw język korekty dla tekstu**

Utwórz lub wczytaj [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), uzyskaj dostęp do wymaganego fragmentu tekstu poprzez [Portion::getPortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#getPortionFormat) i przypisz jego identyfikator języka. Poniższy przykład tworzy kształt, ustawia brytyjski angielski jako język korekty i zapisuje wynik za pomocą [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#save):

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

## **Ustaw domyślny język dla nowego tekstu**

Użyj [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), aby określić język korekty, który Aspose.Slides przypisuje nowo tworzonemu tekstowi. To ustawienie jest przydatne, gdy większość lub cały nowy tekst w prezentacji używa tego samego języka. Nie zmienia ono metadanych językowych tekstu, który już ma explicite określony język.

Poniższy przykład tworzy prezentację, której nowy tekst używa niemieckich reguł korekty:

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

## **Użyj wielu języków w jednym akapicie**

[Paragraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/paragraph/) zawiera kolekcję fragmentów tekstu. Utwórz oddzielny [Portion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/) dla każdego języka i ustaw jego `LanguageId` niezależnie.

Ten przykład tworzy jeden akapit z fragmentami w języku angielskim i francuskim:

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

## **Włącz lub wyłącz sprawdzanie pisowni dla poszczególnych fragmentów**

[PortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portionformat/) dziedziczy wspólne właściwości tekstu zdefiniowane przez [BasePortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/). Uzyskaj format fragmentu poprzez [Portion::getPortionFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/portion/#getPortionFormat) i użyj [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setSpellCheck), aby kontrolować, czy aplikacja prezentacji może sprawdzać pisownię dla tego fragmentu. Domyślna wartość to `false`: `true` zezwala na sprawdzanie pisowni, natomiast `false` je wyłącza.

Ustawienie dotyczy poszczególnych fragmentów tekstu. Różne fragmenty w tym samym akapicie mogą więc mieć różne wartości. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId) i `setSpellCheck` spełniają uzupełniające się role: `setLanguageId` identyfikuje język korekty, a `setSpellCheck` określa, czy sprawdzanie pisowni jest dozwolone dla fragmentu.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setProofDisabled) również kontroluje korektę, ale reprezentuje szerszy stan „nie korektuj” jako [NullableBool](https://reference.aspose.com/slides/pl/php-java/aspose.slides/nullablebool/). Użyj `setSpellCheck`, gdy potrzebujesz bezpośredniego przełącznika Boolean specyficznego dla sprawdzania pisowni. Użyj `setProofDisabled`, gdy musisz zachować lub wyraźnie kontrolować metadane „brak korekty” prezentacji, włączając jej stan `NotDefined`. Jeśli ustawisz obie właściwości, utrzymuj ich wartości spójne; nie łącz `setSpellCheck(true)` z `setProofDisabled(NullableBool::True)`.

Właściwości te konfigurują metadane korekty używane przez PowerPoint i inne aplikacje prezentacji. Aspose.Slides nie używa ich do wykonywania słownikowego sprawdzania pisowni ani do zwracania listy błędnie napisanych słów.

Poniższy kompletny przykład tworzy prezentację wejściową, wczytuje ją, przypisuje różne ustawienia sprawdzania pisowni i języki korekty dwóm fragmentom w tym samym akapicie, zapisuje wynik, otwiera go ponownie i weryfikuje zapisane wartości:

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

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) łączy sąsiadujące fragmenty, które mają to samo formatowanie. Różnica w samym `SpellCheck` nie wystarczy, aby fragmenty pozostały oddzielne; po połączeniu wynikowy fragment zachowuje wartość `SpellCheck` pierwszego fragmentu. Jeśli fragmenty wymagają różnych ustawień sprawdzania pisowni, wywołaj `joinPortionsWithSameFormatting` przed ich ustawieniem lub sprawdź granice wynikowego fragmentu i ponownie zastosuj ustawienia. Fragmenty z różnymi wartościami `LanguageId` pozostają oddzielne, ponieważ ich formatowanie języka korekty się różni.

## **FAQ**

**Czy identyfikator języka tłumaczy tekst?**

Nie. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId) przechowuje metadane korekty dla pisowni i gramatyki; nie zmienia treści tekstu. Przetłumacz tekst osobno, a następnie ustaw odpowiedni identyfikator języka dla każdego przetłumaczonego fragmentu.

**Czy język korekty kontroluje czcionki, dzielenie wyrazów lub zawijanie linii?**

Nie. Identyfikator języka służy wyłącznie korekcie. Renderowanie i układ tekstu zależą głównie od dostępnych [czcionek](/slides/pl/php-java/powerpoint-fonts/), systemu pisma oraz ustawień ramki tekstowej. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [zastępowanie czcionek](/slides/pl/php-java/font-substitution/) lub [osadź czcionki](/slides/pl/php-java/embedded-font/) w prezentacji.

**Czy jeden akapit może używać kilku języków korekty?**

Tak. Przypisz każdy język do oddzielnego fragmentu, jak pokazano w przykładzie wielojęzycznego akapitu.

**Czy używać `setDefaultTextLanguage` czy `setLanguageId`?**

Użyj [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), gdy potrzebujesz domyślnego języka dla nowo tworzonego tekstu. Użyj [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/baseportionformat/#setLanguageId), gdy konkretny fragment wymaga explicitego języka korekty lub gdy akapit zawiera wiele języków.