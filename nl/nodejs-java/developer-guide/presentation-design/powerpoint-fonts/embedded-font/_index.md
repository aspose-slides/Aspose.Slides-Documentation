---
title: Lettertypen insluiten in presentaties in JavaScript
linktitle: Ingesloten lettertypen
type: docs
weight: 40
url: /nl/nodejs-java/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- insluiting van lettertype
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer ingesloten lettertypen in PowerPoint met Aspose.Slides voor Node.js via Java. Voeg lettertypen toe, haal ze op, verwijder ze en comprimeer ze om de weergave van tekst te behouden en de bestandsgrootte te verkleinen."
---
## **Inleiding**

Het insluiten van lettertypen slaat lettertypegegevens op in een PowerPoint‑presentatie. Wanneer een viewer ingesloten lettertypen ondersteunt, kan hij tekst weergeven met die lettertypen, zelfs als ze niet op het doelsysteem geïnstalleerd zijn. Dit helpt om regeleinden, tekstopmaak en de lay‑out van dia’s te behouden.

Aspose.Slides for Node.js via Java stelt je in staat om ingesloten lettertypen op te halen, toe te voegen en te verwijderen via de [FontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/)‑klasse die wordt geretourneerd door [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getfontsmanager/). Je kunt ook de omvang van ingesloten lettertypegegevens verkleinen door tekens te verwijderen die de presentatie niet gebruikt.

De voorbeelden hieronder werken met PPTX‑bestanden. Zorg er voor je een lettertype insluit ervoor dat de lettertypegegevens beschikbaar zijn voor Aspose.Slides en dat de licentie het insluiten toestaat.

## **Ophalen en Verwijderen van Ingesloten Lettertypen**

Gebruik [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) om de lettertypen die in een presentatie zijn opgeslagen te tonen. Om er één te verwijderen, geef een lettertype uit die lijst door aan [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), sla vervolgens de presentatie op.

Het volgende voorbeeld toont de ingesloten lettertypen in `EmbeddedFonts.pptx` en verwijdert Calibri als dat aanwezig is:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Het verwijderen van een ingesloten lettertype verwijdert de opgeslagen lettertypegegevens; het wijzigt niet het aan de tekst toegewezen lettertype. Als het lettertype op het doelsysteem geïnstalleerd is, kan de tekst het nog steeds gebruiken. Anders vereist de weergave mogelijk [font substitution](/slides/nl/nodejs-java/font-substitution/), wat de lay‑out kan beïnvloeden.

## **Inspectie van Lettertypegegevens en Insluitrechten**

Gebruik de [FontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/)‑klasse om lettertypen te inspecteren voordat je ze insluit. Roep [FontsManager.getFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getfonts/) aan om de lettertypen op te halen die in de presentatie worden gebruikt. Voor elk lettertype geef je een [FontData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontdata/)‑object en de vereiste [FontStyleType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontstyletype/)‑waarde door aan [FontsManager.getFontBytes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). De methode retourneert de binaire gegevens voor die lettertype‑stijl, of `null` wanneer het gevraagde lettertype of de stijl niet beschikbaar is. Geef geen `null`‑resultaat door aan [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), want die methode vereist een byte‑array. In Node.js converteer je de geretourneerde JavaScript‑array naar een Java‑byte‑array met `java.newArray` voordat je deze doorgeeft aan `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/embeddinglevel/) geeft de insluitbeperkingen weer die in het lettertype zijn opgeslagen als een reeks vlaggen:

- `Installable` staat insluiten en permanente installatie op een ander systeem toe, onder voorbehoud van de licentie van het lettertype.
- `Restricted` verbiedt insluiten tenzij toestemming is verkregen van de juridische eigenaar van het lettertype wanneer dit de enige gebruiks‑toestemmingsvlag is.
- `PreviewPrint` staat tijdelijk gebruik toe voor weergave en afdrukken; een document dat het lettertype bevat moet alleen‑lezen zijn.
- `Editable` staat tijdelijk gebruik toe en maakt het mogelijk het document te bewerken en op te slaan.
- `NoSubsetting` is een extra beperking die verbiedt alleen een subset van de glyphs in te sluiten. Sluit alle tekens in wanneer deze vlag aanwezig is.
- `BitmapOnly` is een extra beperking die alleen bitmap‑strikes toestaat om in te sluiten, niet outline‑data. Als het lettertype geen bitmap‑strikes heeft, kan het niet worden ingesloten.

De eerste vier waarden beschrijven de gebruiks‑toestemming, terwijl `NoSubsetting` en `BitmapOnly` ermee gecombineerd kunnen worden. Controleer de modifiers met bitwise‑operaties. Omdat `Installable` nul is, maskeer je de gebruiks‑toestemmingsbits en vergelijk je het resultaat met `Installable` in plaats van het als een vlag te testen. Huidige lettertypen zouden maximaal één gebruiks‑toestemmingsbit moeten instellen. Voor compatibiliteit met oudere lettertypen die meer dan één instellen, kiest de onderstaande helper de minst beperkende toestemming: `Editable`, daarna `PreviewPrint`, daarna `Restricted`.

Het volgende voorbeeld controleert de reguliere, vet, cursief en vet‑cursief gegevens die beschikbaar zijn voor elk door `getFonts` geretourneerd lettertype. Het slaat niet‑beschikbare stijlen, beperkte lettertypen, uitsluitend‑bitmap‑lettertypen, lettertypen beperkt tot preview en print (omdat de output bewerkbaar blijft) en reeds ingesloten lettertypen over. Als een beschikbare stijl `NoSubsetting` heeft, wordt voor die lettertype‑familie elk teken ingesloten.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze inspectie meldt de beperkingen die in elk lettertype‑bestand zijn gecodeerd. Het verleent geen licentie, bewijst niet dat je het lettertype legaal hebt verkregen, en vervangt niet het controleren van de licentieovereenkomst van het lettertype voordat je een ingesloten kopie distribueert.

## **Ingesloten Lettertypen Toevoegen**

Gebruik [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) om een lettertype in te sluiten. De overloads accepteren ofwel een [FontData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontdata/)‑object of een byte‑array met de lettertype‑data. [EmbedFontCharacters](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/embedfontcharacters/) bepaalt welke tekens worden opgenomen:

- `All` sluit alle tekens in het lettertype in. Gebruik deze optie wanneer ontvangers de presentatie moeten kunnen bewerken en nieuwe tekst moeten invoeren.
- `OnlyUsed` sluit alleen de in de presentatie gebruikte tekens in om de bestandsgrootte te verkleinen. Kies deze optie voor een voltooide presentatie die voornamelijk bedoeld is voor weergave.

Het volgende voorbeeld gebruikt [FontsManager.getFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getfonts/) om de in `Fonts.pptx` gebruikte lettertypen op te halen en sluit die in die nog niet ingesloten zijn. De toe te voegen lettertypen moeten beschikbaar zijn op de machine die de code uitvoert. Bestaande ingesloten lettertypen behouden hun huidige tekensets.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ingesloten Lettertypen Comprimeren**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/compress/compressembeddedfonts/) verkleint ingesloten lettertype‑data door ongebruikte tekens te verwijderen. Het werkt op lettertypen die al ingesloten zijn, dus de grootte‑reductie hangt af van hoeveel ongebruikte lettertype‑data de presentatie bevat.

Het volgende voorbeeld comprimeert de lettertypen in `EmbeddedFonts.pptx` en slaat het resultaat op als een apart bestand:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bewaar het originele bestand als ontvangers later tekst moeten kunnen toevoegen. Tekens die tijdens compressie zijn verwijderd, zijn niet meer beschikbaar vanuit het ingesloten lettertype, zelfs als je oorspronkelijk alle tekens had ingesloten.

## **FAQ**

**Hoe kan ik controleren of een ingesloten lettertype nog steeds zal worden vervangen tijdens het renderen?**

Roep [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) aan in de omgeving waarin je de presentatie rendert om te zien welke lettertypen Aspose.Slides zal vervangen. Controleer ook de instellingen voor [font substitution](/slides/nl/nodejs-java/font-substitution/) en de regels voor [font fallback](/slides/nl/nodejs-java/fallback-font/). Fallback behandelt ontbrekende tekens, dus het insluiten van een lettertype lost geen tekens op die het lettertype zelf niet bevat.

**Moet ik algemene lettertypen zoals Arial en Calibri insluiten?**

Baseer de beslissing op de doelomgeving. Als de benodigde lettertypen op elke machine die de presentatie opent of rendert beschikbaar zijn, kan het insluiten ervan onnodige bestandsgrootte toevoegen. Als ontvangers of servers die lettertypen mogelijk niet hebben, kan insluiten helpen om het beoogde uiterlijk te behouden, mits hun licenties het toestaan.