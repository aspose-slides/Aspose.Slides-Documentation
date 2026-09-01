---
title: Automatiseer presentatie-lokalisatie in PHP
linktitle: Presentatie-lokalisatie
type: docs
weight: 100
url: /nl/php-java/presentation-localization/
keywords:
- taal wijzigen
- spellingcontrole
- spellingcontrole onderdrukken
- proeftaal
- taal-id
- meertalige tekst
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Stel proeftalen in voor PowerPoint- en OpenDocument-presentatietekst in PHP met Aspose.Slides, inclusief standaardwaarden en meertalige alinea's."
---
## **Overzicht**

Aspose.Slides for PHP via Java stelt u in staat om proefmetadata voor afzonderlijke tekstgedeelten te configureren. Gebruik [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId) om de proeftaal te identificeren, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setSpellCheck) om spellingcontroles toe te staan of te onderdrukken, en [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setProofDisabled) om de bredere “geen proef”-status te beheren. Omdat deze instellingen per gedeelte worden toegepast, kan één alinea meerdere talen en verschillende proefregels bevatten.

Dit artikel legt uit hoe u een taal toewijst aan specifieke tekst, de standaardtaal instelt voor nieuwe tekst met [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), meertalige alinea’s samenstelt, kiest tussen `SpellCheck` en `ProofDisabled`, en de gewenste instellingen behoudt bij gebruik van [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Deze eigenschappen slaan metadata op voor presentatie‑applicaties; ze vertalen de tekst niet, voeren geen woordenboek‑gebaseerde spellingscontrole uit en geven geen foutieve woorden terug.

## **De proeftaal voor tekst instellen**

Maak of laad een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/), krijg toegang tot het gewenste tekstgedeelte via [Portion::getPortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#getPortionFormat), en wijs de taal‑identificator toe. Het volgende voorbeeld maakt een vorm, stelt Brits‑Engels in als proeftaal en slaat het resultaat op met [Presentation::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#save):

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

## **Standaardtaal voor nieuwe tekst instellen**

Gebruik [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) om de proeftaal te specificeren die Aspose.Slides toekent aan nieuw aangemaakte tekst. Deze instelling is nuttig wanneer de meeste of alle nieuwe tekst in een presentatie dezelfde taal gebruikt. Het verandert de taal‑metadata van tekst die al een expliciete taal heeft.

Het volgende voorbeeld maakt een presentatie waarvan nieuwe tekst Duits als proeftaal gebruikt:

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

## **Meerdere talen in één alinea gebruiken**

Een [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) bevat een collectie tekstgedeelten. Maak een afzonderlijk [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/) voor elke taal en stel de `LanguageId` onafhankelijk in.

Dit voorbeeld maakt één alinea met Engelse en Franse gedeelten:

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

## **Spellingcontrole voor individuele gedeelten in- of uitschakelen**

[PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/) erft de gemeenschappelijke tekst‑eigenschappen die gedefinieerd zijn in [BasePortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/). Verkrijg het format van een gedeelte via [Portion::getPortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#getPortionFormat) en gebruik [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setSpellCheck) om te bepalen of een presentatie‑applicatie de spelling van dat gedeelte mag controleren. De standaardwaarde is `false`: `true` staat spellingcontrole toe, terwijl `false` deze onderdrukt.

De instelling geldt voor afzonderlijke tekstgedeelten. Verschillende gedeelten in dezelfde alinea kunnen daardoor verschillende waarden hebben. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId) en `setSpellCheck` hebben complementaire doeleinden: `setLanguageId` identificeert de proeftaal, terwijl `setSpellCheck` bepaalt of spellingcontroles zijn toegestaan voor het gedeelte.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setProofDisabled) regelt ook proefmetadata, maar vertegenwoordigt de bredere “geen proef”-status als een [NullableBool](https://reference.aspose.com/slides/nl/php-java/aspose.slides/nullablebool/). Gebruik `setSpellCheck` wanneer u een directe Booleaanse schakelaar wilt voor spellingcontroles. Gebruik `setProofDisabled` wanneer u de “geen proef”‑metadata wilt behouden of expliciet wilt beheren, inclusief de `NotDefined`‑status. Als u beide eigenschappen instelt, houd hun waarden consistent; combineer `setSpellCheck(true)` niet met `setProofDisabled(NullableBool::True)`.

Deze eigenschappen configureren proefmetadata die door PowerPoint en andere presentatie‑applicaties worden gebruikt. Aspose.Slides maakt er geen gebruik van om woordenboek‑gebaseerde spellingcontroles uit te voeren of een lijst van foutieve woorden te retourneren.

Het volgende volledige voorbeeld maakt een invoer‑presentatie, laadt deze, kent verschillende spelling‑instellingen en proef‑talen toe aan twee gedeelten in dezelfde alinea, slaat het resultaat op, opent het opnieuw, en verifieert de opgeslagen waarden:

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

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combineert aangrenzende gedeelten die dezelfde opmaak hebben. Een verschil in alleen `SpellCheck` houdt dergelijke gedeelten niet gescheiden; na het samenvoegen behoudt het resulterende gedeelte de `SpellCheck`‑waarde van het eerste gedeelte. Als gedeelten verschillende spellinginstellingen nodig hebben, roep `joinPortionsWithSameFormatting` aan vóór het toewijzen van die instellingen, of inspecteer de grenzen van het resulterende gedeelte en pas de instellingen daarna opnieuw toe. Gedeelten met verschillende `LanguageId`‑waarden blijven gescheiden omdat hun proef‑taalopmaak verschilt.

## **FAQ**

**Zorgt een taal‑ID ervoor dat de tekst wordt vertaald?**

Nee. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId) slaat proefmetadata op voor spelling en grammatica; het wijzigt de tekstinhoud niet. Vertaal de tekst apart en stel vervolgens de juiste taal‑identifier in voor elk vertaald gedeelte.

**Beheert de proeftaal lettertypen, afbreking of regelafstand?**

Nee. De taal‑identifier is uitsluitend voor proefdoeleinden. Tekst‑weergave en -layout hangen voornamelijk af van de beschikbare [fonts](/slides/nl/php-java/powerpoint-fonts/), het schrijfsysteem en de tekst‑frame‑instellingen. Zorg voor de benodigde lettertypen, configureer [font substitution](/slides/nl/php-java/font-substitution/), of [embed fonts](/slides/nl/php-java/embedded-font/) in de presentatie voor een betrouwbare weergave.

**Kan één alinea meerdere proef‑talen gebruiken?**

Ja. Wijs elke taal toe aan een afzonderlijk gedeelte, zoals getoond in het voorbeeld met een meertalige alinea.

**Moet ik `setDefaultTextLanguage` of `setLanguageId` gebruiken?**

Gebruik [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) wanneer u een standaard voor nieuw aangemaakte tekst wilt. Gebruik [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId) wanneer een specifiek gedeelte een expliciete proeftaal nodig heeft of wanneer een alinea meerdere talen bevat.