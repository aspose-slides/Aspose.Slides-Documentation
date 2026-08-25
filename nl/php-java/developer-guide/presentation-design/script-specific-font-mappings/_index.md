---
title: Beheer script‑specifieke themalettertypen in PHP
linktitle: Script‑specifieke themalettertypen
type: docs
weight: 15
url: /nl/php-java/script-specific-font-mappings/
keywords:
- script‑specifiek lettertype
- themalettertype‑mapping
- meertalige presentatie
- schrijftaal
- Cyrillisch lettertype
- Arabisch lettertype
- Japans lettertype
- Georgisch lettertype
- Thaana lettertype
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Inspecteer, voeg toe, vervang en verwijder script‑specifieke lettertype‑mappings in PowerPoint‑thema's met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Een presentatiethema kan verschillende lettertypefamilies selecteren voor verschillende schrijftalen. Hierdoor kan meertalige tekst die nog steeds thema‑lettertypen gebruikt één gecoördineerd lettertype‑schema volgen, terwijl geschikte lettertypen voor Cyrillisch, Arabisch, Japans, Georgisch, Thaana en andere scripts worden gebruikt.

Het thema’s [FontScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontscheme/) bevat een hoofd‑lettertypecollectie, meestal gebruikt voor kopteksten, en een secundaire lettertypecollectie, meestal gebruikt voor de hoofdtekst. Naast hun Latijnse en Oost‑Aziatische lettertype‑instellingen tonen beide [Fonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fonts/)‑collecties mappings van schrijftags naar lettertypefamilienamen.

Dit artikel laat zien hoe u die mappings inspecteert en wijzigt in het master‑thema van de presentatie en verifieert dat de wijzigingen een opslaan‑en‑herladen‑cyclus overleven.

## **Script‑tags begrijpen**

De script‑lettertype‑methoden gebruiken vierletterige BCP‑47 script‑subtags om schrijftalen te identificeren. Veelvoorkomende waarden zijn:

| Script‑tag | Schrijfsysteem |
|---|---|
| `Cyrl` | Cyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereenvoudigd Chinees |
| `Jpan` | Japans |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

## **Toegang tot en inspectie van script‑lettertype‑mappings**

Gebruik [Presentation::getMasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getMasterTheme) om toegang te krijgen tot het thema op presentatieniveau. De methoden [MasterTheme::getFontScheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontscheme/#getMajor) en [FontScheme::getMinor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontscheme/#getMinor) bieden toegang tot de twee [Fonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fonts/)‑collecties.

Roep [Fonts::getScriptFontMap](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fonts/#getScriptFontMap) aan om alle mappings uit een collectie op te halen. Om één schrijftaal op te zoeken, roep je [Fonts::getScriptFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fonts/#getScriptFont) aan met de betreffende script‑tag. `Fonts::getScriptFont` retourneert `null` wanneer die collectie de gevraagde mapping niet definieert.

## **Mappings wijzigen en persistentie verifiëren**

Gebruik [Fonts::setScriptFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fonts/#setScriptFont) om een mapping te creëren of de huidige lettertypefamilie te vervangen. Gebruik [Fonts::removeScriptFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fonts/#removeScriptFont) om een mapping te verwijderen.

Het onderstaande end‑to‑end‑voorbeeld leest alle bestaande hoofd‑ en secundaire mappings, zoekt het Japanse hoofdlettertype op, wijzigt het Cyrillische hoofdlettertype, verwijdert de Thaana‑secundaire mapping, slaat de presentatie op en opent deze opnieuw om beide wijzigingen te verifiëren. Om de verwijderingsstap onafhankelijk van het oorspronkelijke thema te maken, creëert het voorbeeld eerst een Thaana‑mapping alleen wanneer er nog geen bestaat.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

De verificatie gebruikt hetzelfde `null`‑gedrag als een gewone lookup: na het opslaan van de verwijdering retourneert `Fonts::getScriptFont("Thaa")` `null` voor de secundaire collectie.

## **Theme‑mappings onderscheiden van andere lettertype‑instellingen**

Script‑specifieke themamappings nemen deel aan de lettertype‑selectie, maar lossen een ander probleem op dan directe Tekst‑opmaak, substitutie en fallback:

| Mechanisme | Doel | Effect van het wijzigen van een themamapping |
|---|---|---|
| Script‑specifieke themalettertype‑mapping | Selecteert een hoofd‑ of secundair themalettertype voor een schrijftaal. | Tekst die nog steeds het corresponderende themalettertype gebruikt, kan naar de nieuw gemapte familie verwijzen. |
| Lettertype expliciet toegewezen aan een tekstgedeelte | Stelt de gevraagde lettertypefamilie vast voor dat gedeelte in plaats van te vertrouwen op het thema. | Het gedeelte kan ongewijzigd blijven omdat directe opmaak de themakeuze overschrijft. |
| Lettertype‑substitutie | Vervangt een aangevraagd lettertype wanneer dat lettertype niet beschikbaar is of wanneer een substitutieregel van toepassing is. | Het treedt in werking nadat een lettertype is aangevraagd; het herschrijft de script‑mapping van het thema niet. |
| Lettertype‑fallback | Levert tekensets die het geselecteerde lettertype niet bevat, vaak voor specifieke Unicode‑bereiken. | Het vult ontbrekende tekensets aan; het verandert de opgeslagen themamapping niet. |

Voor meer informatie over de laatste twee mechanismen, zie [Font Substitution](/slides/nl/php-java/font-substitution/) en [Fallback Fonts](/slides/nl/php-java/fallback-font/).

Het wijzigen van een mapping in [Presentation::getMasterTheme](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getMasterTheme) beïnvloedt alleen inhoud waarvan de effectieve opmaak nog steeds afhankelijk is van dat thema. Tekst kan in plaats daarvan een themaversie erven van een master, lay‑out of dia, of een expliciet toegewezen lettertype gebruiken. Inspecteer die niveaus wanneer het zichtbare resultaat niet overeenkomt met de mapping op presentatieniveau.

## **Gemapte lettertypen beschikbaar maken en het resultaat valideren**

Een script‑mapping slaat een lettertypefamilienaam op; het installeert of laadt het bijbehorende lettertype‑bestand niet. Voor consistente weergave en export moet elk gemapt lettertype geïnstalleerd zijn in de omgeving of beschikbaar worden gesteld aan Aspose.Slides via een aangepaste bron, bijvoorbeeld [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsloader/#loadExternalFonts) of [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Zie [Custom Fonts](/slides/nl/php-java/custom-font/) voor de beschikbare laadopties.

Het verifiëren van de opgeslagen mapping bevestigt alleen dat de themadefinitie behouden is gebleven. Het bewijst niet dat het lettertype beschikbaar is, alle vereiste glyphs bevat, of de beoogde lay‑out oplevert. Render representatieve tekst voor elk vereist schrijftaal naar een afbeelding of PDF en inspecteer de output. Zo worden ontbrekende lettertypen, onvolledige glyph‑dekking, fallback‑gedrag en lay‑outwijzigingen opgemerkt voordat de presentatie wordt verspreid. Zie [Convert PowerPoint Presentations](/slides/nl/php-java/convert-powerpoint/) voor voorbeelden van weergave en export.

## **FAQ**

**Wat retourneert `Fonts::getScriptFont` wanneer een script niet gemapt is?**

`[Fonts::getScriptFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fonts/#getScriptFont)` retourneert `null` wanneer de gevraagde script‑mapping niet is gedefinieerd in die hoofd‑ of secundaire lettertypecollectie.

**Voegt `Fonts::setScriptFont` een tweede mapping toe wanneer het script al bestaat?**

Nee. `[Fonts::setScriptFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fonts/#setScriptFont)` creëert de mapping wanneer deze ontbreekt en vervangt de gemapte lettertypefamilie wanneer dezelfde script‑tag al aanwezig is.

**Waarom heeft het wijzigen van een themamapping sommige tekst niet beïnvloed?**

De tekst kan een expliciet toegewezen lettertype hebben, een ander thema erven via een overschrijving, of beïnvloed worden door substitutie of fallback tijdens het renderen. Een script‑mapping op presentatieniveau regelt alleen tekst waarvan de effectieve opmaak nog steeds verwijst naar die themalettertype‑collectie.

**Is opslaan en opnieuw openen voldoende om meertalige output te valideren?**

Nee. Het opnieuw openen verifieert alleen de persistentie van de themagegevens. Render daarnaast representatieve tekst uit elk vereist schrijftaal om te bevestigen dat de gemapte lettertypen beschikbaar zijn en de nodige glyphs bevatten.