---
title: Lettertypen insluiten in presentaties met PHP
linktitle: Ingesloten lettertypen
type: docs
weight: 40
url: /nl/php-java/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- lettertype insluiten
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Beheer ingesloten lettertypen in PowerPoint met Aspose.Slides voor PHP via Java. Voeg lettertypen toe, haal ze op, verwijder ze en comprimeer ze om de weergave van tekst te behouden en de bestandsgrootte te verkleinen."
---
## **Inleiding**

Lettertypen insluiten slaat lettertypegegevens op binnen een PowerPoint‑presentatie. Wanneer een viewer ingebedde lettertypen ondersteunt, kan hij de tekst weergeven met die lettertypen, zelfs als ze niet geïnstalleerd zijn op het doelsysteem. Dit helpt om regeleinden, tekstruimte en de lay‑out van de dia te behouden.

Aspose.Slides voor PHP via Java stelt u in staat om ingebedde lettertypen op te halen, toe te voegen en te verwijderen via de [FontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/) klasse die wordt geretourneerd door [Presentation::getFontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getFontsManager). U kunt ook de grootte van de ingebedde lettertypegegevens verkleinen door tekens te verwijderen die de presentatie niet gebruikt.

De voorbeelden hieronder werken met PPTX‑bestanden. Voordat u een lettertype insluit, moet u ervoor zorgen dat de lettertypegegevens beschikbaar zijn voor Aspose.Slides en dat de licentie insluiten toestaat.

## **Opvragen en verwijderen van ingebedde lettertypen**

Gebruik [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) om de lettertypen die in een presentatie zijn opgeslagen op te sommen. Om er één te verwijderen, geeft u een lettertype uit die lijst door aan [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) en slaat vervolgens de presentatie op.

Het volgende voorbeeld somt de ingebedde lettertypen in `EmbeddedFonts.pptx` op en verwijdert Calibri als het aanwezig is:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Het verwijderen van een ingebed lettertype verwijdert de opgeslagen lettertypegegevens; het verandert het toegewezen lettertype van de tekst niet. Als het lettertype geïnstalleerd is op het doelsysteem, kan de tekst het nog steeds gebruiken. Anders kan het renderen een [font substitution](/slides/nl/php-java/font-substitution/) vereisen, wat de lay‑out kan beïnvloeden.

## **Inspectie van lettertypegegevens en insluitrechten**

Gebruik de [FontsManager](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/) klasse om lettertypen te inspecteren voordat u ze insluit. Roep [FontsManager::getFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#getFonts) aan om de in de presentatie gebruikte lettertypen op te halen. Voor elk lettertype geeft u een [FontData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontdata/)‑object en de vereiste [FontStyleType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontstyletype/)‑waarde door aan [FontsManager::getFontBytes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#getFontBytes). De methode retourneert de binaire gegevens voor die lettertype‑stijl, of `null` wanneer het gevraagde lettertype of de stijl niet beschikbaar is. Geef geen `null`‑resultaat door aan [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), omdat die methode een byte‑array vereist.

[EmbeddingLevel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/embeddinglevel/) is een vlag‑enumeratie die de insluitbeperkingen in het lettertype rapporteert:

- `Installable` staat insluiten en permanente installatie op een ander systeem toe, onder voorbehoud van de licentie van het lettertype.
- `Restricted` verbiedt insluiten tenzij toestemming is verkregen van de wettelijke eigenaar van het lettertype wanneer dit de enige gebruiks‑toestemmingsvlag is.
- `PreviewPrint` staat tijdelijk gebruik toe voor bekijken en afdrukken; een document dat het lettertype bevat moet alleen‑lezen zijn.
- `Editable` staat tijdelijk gebruik toe en maakt het mogelijk het document te bewerken en op te slaan.
- `NoSubsetting` is een extra beperking die verbiedt alleen een subset van de glyphs in te sluiten. Sluit alle tekens in wanneer deze vlag aanwezig is.
- `BitmapOnly` is een extra beperking die alleen bitmap‑strikes toestaat om in te sluiten, niet vector‑data. Als het lettertype geen bitmap‑strikes heeft, kan het niet worden ingesloten.

De eerste vier waarden beschrijven gebruikstoestemming, terwijl `NoSubsetting` en `BitmapOnly` ermee gecombineerd kunnen worden. Controleer de modifiers met bitwise‑operaties. Omdat `Installable` nul is, maskert u de gebruikstoestemmingsbits en vergelijkt u het resultaat met `Installable` in plaats van het als een vlag te controleren. Huidige lettertypen zouden hooguit één gebruikstoestemmingsbit moeten instellen. Voor compatibiliteit met oudere lettertypen die meer dan één bit instellen, selecteert de helper hieronder de minst beperkende toestemming: `Editable`, daarna `PreviewPrint`, daarna `Restricted`.

Het volgende voorbeeld controleert de reguliere, vet, cursief en vet‑cursieve gegevens die beschikbaar zijn voor elk lettertype dat door `FontsManager::getFonts` wordt geretourneerd. Het slaat onbeschikbare stijlen, beperkte lettertypen, alleen‑bitmap‑lettertypen, lettertypen beperkt tot preview en print omdat de output bewerkbaar blijft, en al ingesloten lettertypen over. Als een beschikbare stijl `NoSubsetting` heeft, wordt voor die lettertypefamilie elk teken ingesloten.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Deze inspectie rapporteert de beperkingen die in elk lettertype‑bestand gecodeerd zijn. Het verleent geen licentie, bewijst niet dat u het lettertype legaal hebt verkregen, en vervangt niet de controle van de licentieovereenkomst van het lettertype vóór distributie van een ingesloten kopie.

## **Ingebedde lettertypen toevoegen**

Gebruik [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) om een lettertype in te sluiten. De overloads accepteren ofwel een [FontData](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontdata/)‑object of een byte‑array met de lettertypegegevens. De [EmbedFontCharacters](https://reference.aspose.com/slides/nl/php-java/aspose.slides/embedfontcharacters/)‑enumeratie bepaalt welke tekens worden opgenomen:

- [All](https://reference.aspose.com/slides/nl/php-java/aspose.slides/embedfontcharacters/) sluit alle tekens in het lettertype in. Gebruik deze optie wanneer ontvangers de presentatie moeten bewerken en nieuwe tekst moeten invoeren.
- [OnlyUsed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/embedfontcharacters/) sluit alleen de in de presentatie gebruikte tekens in om de bestandsgrootte te verkleinen. Kies deze optie voor een afgewerkte presentatie die voornamelijk bedoeld is om bekeken te worden.

Het volgende voorbeeld gebruikt [FontsManager::getFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#getFonts) om de in `Fonts.pptx` gebruikte lettertypen op te halen en sluit die in die nog niet zijn ingesloten. De toe te voegen lettertypen moeten beschikbaar zijn op de machine die de code uitvoert. Bestaande ingesloten lettertypen behouden hun huidige tekensets.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ingebedde lettertypen comprimeren**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/nl/php-java/aspose.slides/compress/#compressEmbeddedFonts) verkleint ingesloten lettertypegegevens door ongebruikte tekens te verwijderen. Het werkt op lettertypen die al zijn ingesloten, dus de grootte‑reductie hangt af van hoeveel ongebruikte lettertypegegevens de presentatie bevat.

Het volgende voorbeeld comprimeert de lettertypen in `EmbeddedFonts.pptx` en slaat het resultaat op als een afzonderlijk bestand:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bewaar het originele bestand als ontvangers later tekst moeten toevoegen. Tekens die tijdens compressie worden verwijderd, zijn niet langer beschikbaar vanuit het ingesloten lettertype, zelfs niet als u oorspronkelijk alle tekens had ingesloten.

## **FAQ**

**Hoe kan ik controleren of een ingebed lettertype nog steeds wordt vervangen tijdens het renderen?**

Roep [FontsManager::getSubstitutions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fontsmanager/#getSubstitutions) aan in de omgeving waarin u de presentatie rendert om te zien welke lettertypen Aspose.Slides zal vervangen. Controleer ook de instellingen voor [font substitution](/slides/nl/php-java/font-substitution/) en de regels voor [font fallback](/slides/nl/php-java/fallback-font/). Fallback behandelt ontbrekende tekens, dus het insluiten van een lettertype lost niet de tekens op die het lettertype zelf niet bevat.

**Moet ik algemene lettertypen zoals Arial en Calibri insluiten?**

Baseer de beslissing op de doelomgeving. Als de vereiste lettertypen beschikbaar zijn op elke machine die de presentatie opent of rendert, kan het insluiten onnodig bestandsgrootte toevoegen. Als ontvangers of servers die lettertypen mogelijk missen, kan het insluiten helpen de beoogde weergave te behouden, mits hun licenties het toestaan.