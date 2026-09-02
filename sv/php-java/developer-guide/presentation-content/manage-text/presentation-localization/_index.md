---
title: Automatisera lokalisering av presentationer i PHP
linktitle: Presentation Lokalisering
type: docs
weight: 100
url: /sv/php-java/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- undertryck stavningskontroll
- korrekturspråk
- språk-id
- flerspråkig text
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Ställ in korrekturspråk för PowerPoint- och OpenDocument-presentationstext i PHP med Aspose.Slides, inklusive standardvärden och flerspråkiga stycken."
---
## **Översikt**

Aspose.Slides för PHP via Java låter dig konfigurera korrekturmetadata för enskilda textdelar. Använd [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId) för att identifiera korrekturspråket, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setSpellCheck) för att tillåta eller undertrycka stavningskontroller, och [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setProofDisabled) för att kontrollera det bredare ”ingen korrektur”-tillståndet. Eftersom dessa inställningar tillämpas på delnivå kan ett stycke innehålla flera språk och olika korrekturregler.

Den här artikeln förklarar hur du tilldelar ett språk till specifik text, anger standardspråk för ny text med [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), bygger flerspråkiga stycken, väljer mellan `SpellCheck` och `ProofDisabled`, samt bevarar de avsedda inställningarna när du använder [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Dessa egenskaper lagrar metadata för presentationsprogram; de översätter inte text, utför inte ordboksbaserad stavningskontroll eller returnerar felstavade ord.

## **Ange korrekturspråk för Text**

Skapa eller läs in en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/), få åtkomst till den önskade textdelen via [Portion::getPortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#getPortionFormat) och tilldela dess språkidentifierare. Följande exempel skapar en form, ställer in brittisk engelska som korrekturspråk och sparar resultatet med [Presentation::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#save):

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

## **Ange Standardspråk för Ny Text**

Använd [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) för att specificera det korrekturspråk som Aspose.Slides tilldelar nygenererad text. Denna inställning är användbar när det mesta eller all ny text i en presentation använder samma språk. Den ändrar inte språkmetadata för text som redan har ett explicit språk.

Följande exempel skapar en presentation där ny text använder tyska korrekturregler:

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

## **Använd Flera Språk i Ett Stycke**

Ett [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) innehåller en samling textdelar. Skapa en separat [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/) för varje språk och ange dess `LanguageId` oberoende.

Detta exempel skapar ett stycke med engelska och franska delar:

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

## **Aktivera eller Undertrycka Stavningskontroll för Enskilda Delar**

[PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/) ärver de gemensamma textegenskaper som definieras av [BasePortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/). Få åtkomst till en​s format via [Portion::getPortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#getPortionFormat) och använd [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setSpellCheck) för att styra om ett presentationsprogram får kontrollera stavning för den delen. Standardvärdet är `false`: `true` tillåter stavningskontroll, medan `false` undertrycker den.

Inställningen gäller enskilda textdelar. Olika delar i samma stycke kan därför ha olika värden. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId) och `setSpellCheck` har kompletterande syften: `setLanguageId` identifierar korrekturspråket, medan `setSpellCheck` bestämmer om stavningskontroller får utföras för delen.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setProofDisabled) styr också korrektur, men representerar det bredare “ingen korrektur”-tillståndet som en [NullableBool](https://reference.aspose.com/slides/sv/php-java/aspose.slides/nullablebool/). Använd `setSpellCheck` när du behöver en direkt boolesk växel specifikt för stavningskontroller. Använd `setProofDisabled` när du vill bevara eller uttryckligen kontrollera presentationens ingen‑korrektur‑metadata, inklusive dess `NotDefined`‑tillstånd. Om du anger båda egenskaperna, håll deras värden konsekventa; kombinera inte `setSpellCheck(true)` med `setProofDisabled(NullableBool::True)`.

Dessa egenskaper konfigurerar korrekturmetadata som används av PowerPoint och andra presentationsprogram. Aspose.Slides använder dem inte för att köra ordboksbaserad stavningskontroll eller returnera en lista över felstavade ord.

Följande kompletta exempel skapar en ingångspresentation, läser in den, tilldelar olika stavningskontrollinställningar och korrekturspråk till två delar i samma stycke, sparar resultatet, öppnar det igen och verifierar de lagrade värdena:

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

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) sammanslår intilliggande delar som har samma formatering. En skillnad i `SpellCheck` räcker inte för att hålla sådana delar separata; efter sammanslagning behåller den resulterande delen `SpellCheck`‑värdet från den första delen. Om delar behöver olika stavningskontrollinställningar, anropa `joinPortionsWithSameFormatting` innan du tilldelar dessa inställningar, eller inspektera de resulterande delgränserna och återapplicera inställningarna efteråt. Delar med olika `LanguageId`‑värden förblir separata eftersom deras korrektur‑språkformatering skiljer sig.

## **FAQ**

**Översätter ett språk‑ID texten?**

Nej. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId) lagrar korrekturmetadata för stavning och grammatik; den ändrar inte textinnehållet. Översätt texten separat och ange sedan rätt språkidentifierare för varje översatt del.

**Styr korrekturspråket teckensnitt, avstavning eller radbrytning?**

Nej. Språkidentifieraren är avsedd för korrektur. Textåtergivning och layout beror främst på de tillgängliga [fonts](/slides/sv/php-java/powerpoint-fonts/), skriftsystemet och inställningarna för textramen. För pålitlig återgivning, tillhandahåll erforderliga teckensnitt, konfigurera [font substitution](/slides/sv/php-java/font-substitution/) eller [embed fonts](/slides/sv/php-java/embedded-font/) i presentationen.

**Kan ett stycke använda flera korrekturspråk?**

Ja. Tilldela varje språk till en separat del, som visas i exemplet med flerspråkigt stycke.

**Ska jag använda `setDefaultTextLanguage` eller `setLanguageId`?**

Använd [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) när du vill ha ett standardvärde för nygenererad text. Använd [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId) när en specifik del behöver ett explicit korrekturspråk eller när ett stycke innehåller flera språk.