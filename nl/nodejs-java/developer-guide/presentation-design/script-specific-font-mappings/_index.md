---
title: Beheer script-specifieke themale lettertypen in JavaScript
linktitle: Script-specifieke themale lettertypen
type: docs
weight: 15
url: /nl/nodejs-java/script-specific-font-mappings/
keywords:
- script-specifiek lettertype
- themale lettertype-mapping
- meertalige presentatie
- schrijfsysteem
- cyrillisch lettertype
- arabisch lettertype
- Japans lettertype
- Georgisch lettertype
- Thaana lettertype
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Inspecteer, voeg toe, vervang en verwijder script-specifieke lettertype-mappings in PowerPoint-thema's met Aspose.Slides voor Node.js."
---
## **Overzicht**

Een presentatiethema kan verschillende lettertypefamilies kiezen voor verschillende schrijfsystemen. Hierdoor kan meertalige tekst die nog steeds de thema‑lettertypen gebruikt, één gecoördineerd lettertype‑schema volgen, terwijl geschikte lettertypen voor Cyrillisch, Arabisch, Japans, Georgisch, Thaana en andere schriften worden gebruikt.

Het [FontScheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontscheme/) van het thema bevat een hoofdlettertypecollectie, meestal gebruikt voor koppen, en een sublettertypecollectie, meestal gebruikt voor de hoofdtekst. Naast hun Latijnse en Oost‑Aziatische lettertype‑instellingen, bieden beide collecties mappings van schrijfsysteem‑tags naar lettertype‑familienamen via de [Fonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fonts/)‑klasse.

Dit artikel laat zien hoe u die mappings kunt inspecteren en aanpassen in het master‑thema van de presentatie en hoe u kunt verifiëren dat de wijzigingen een opslaan‑en‑herladen‑cyclus overleven.

## **Begrijp script‑tags**

De script‑lettertype‑methoden gebruiken vierletterige BCP 47 script‑subtags om schrijfsystemen te identificeren. Veelvoorkomende waarden zijn:

| Script‑tag | Schrijfsysteem |
|---|---|
| `Cyrl` | Cyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereenvoudigd Chinees |
| `Jpan` | Japans |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Deze mappings behoren tot het thema‑lettertype‑schema, niet tot individuele tekstgedeelten. Een presentatie kan verschillende mappings definiëren voor de hoofd‑ en subcollecties, en kan mappings voor sommige scripts weglaten.

## **Toegang krijgen tot en inspecteren van script‑lettertype‑toewijzingen**

Gebruik [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getmastertheme/) om het thema op presentatieniveau te benaderen. De methoden [FontScheme.getMajor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontscheme/) en [FontScheme.getMinor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontscheme/) geven de twee [Fonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fonts/)‑collecties terug.

Roep [Fonts.getScriptFontMap](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fonts/) aan om alle mappings uit een collectie op te halen. Om één schrijfsysteem op te zoeken, roep je [Fonts.getScriptFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fonts/) aan met de bijbehorende script‑tag. `getScriptFont` geeft `null` terug wanneer die collectie de gevraagde mapping niet heeft gedefinieerd.

## **Wijzig toewijzingen en verifieer persistentie**

Gebruik [Fonts.setScriptFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fonts/) om een mapping te maken of de huidige lettertypefamilie te vervangen. Gebruik [Fonts.removeScriptFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fonts/) om een mapping te verwijderen.

Het onderstaande end‑to‑end‑voorbeeld leest alle bestaande hoofd‑ en sub‑mappings, zoekt het Japanse hoofd‑lettertype op, wijzigt het Cyrillische hoofd‑lettertype, verwijdert de Thaana‑sub‑mapping, slaat de presentatie op en opent deze opnieuw om beide wijzigingen te verifiëren. Om de verwijderingsstap onafhankelijk te maken van het oorspronkelijke thema, maakt het voorbeeld eerst een Thaana‑mapping aan alleen wanneer er nog geen bestaat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

De verificatie gebruikt hetzelfde `null`‑gedrag als een gewone lookup: na het opslaan van de verwijdering geeft `getScriptFont("Thaa")` `null` terug voor de sub‑collectie.

## **Maak onderscheid tussen thematoewijzingen en andere lettertype‑instellingen**

Script‑specifieke themamappings nemen deel aan de lettertype‑selectie, maar lossen een ander probleem op dan directe tekstopmaak, substitutie en fallback:

| Mechanisme | Doel | Effect van het wijzigen van een themamapping |
|---|---|---|
| Script‑specifieke themamapping | Selecteert een hoofd‑ of sub‑themale lettertype voor een schrijfsysteem. | Tekst die nog steeds het overeenkomstige themale lettertype gebruikt, kan naar de nieuw toegewezen familie resolven. |
| Lettertype expliciet toegewezen aan een tekstgedeelte | Verankert de gevraagde lettertypefamilie op dat gedeelte in plaats van te vertrouwen op het thema. | Het gedeelte blijft mogelijk onveranderd omdat de directe opmaak de themakeuze overschrijft. |
| Lettertypesubstitutie | Vervangt een gevraagde lettertype wanneer die niet beschikbaar is of wanneer een substitutieregel van toepassing is. | Het treedt op nadat een lettertype is aangevraagd; het redefineert de themamapping niet. |
| Lettertype‑fallback | Levert glyphs die het geselecteerde lettertype niet bevat, vaak voor specifieke Unicode‑bereiken. | Het vult ontbrekende glyph‑dekking aan; het wijzigt de opgeslagen themamapping niet. |

Voor meer informatie over de laatste twee mechanismen, zie [Font Substitution](/slides/nl/nodejs-java/font-substitution/) en [Fallback Fonts](/slides/nl/nodejs-java/fallback-font/).

Het wijzigen van een mapping in [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getmastertheme/) beïnvloedt alleen inhoud waarvan de effectieve opmaak nog steeds afhankelijk is van dat thema. Tekst kan in plaats daarvan een themaversie overerven van een master, lay‑out of dia, of een expliciet toegewezen lettertype gebruiken. Inspecteer die niveaus wanneer het zichtbare resultaat niet overeenkomt met de mapping op presentatieniveau.

## **Zorg dat toegewezen lettertypen beschikbaar zijn en valideer het resultaat**

Een script‑mapping slaat een lettertypefamilienaam op; hij installeert of laadt het bijbehorende lettertype‑bestand niet. Voor consistente weergave en export moet elk toegewezen lettertype in de omgeving geïnstalleerd zijn of aan Aspose.Slides worden geleverd via een aangepaste bron zoals [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) of [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/). Zie [Custom Fonts](/slides/nl/nodejs-java/custom-font/) voor de beschikbare laadopties.

Het verifiëren van de opgeslagen mapping bevestigt alleen dat de themadefinitie is behouden. Het bewijst niet dat het lettertype beschikbaar is, alle benodigde glyphs bevat, of de beoogde lay‑out oplevert. Render representatieve tekst voor elk vereist schrijfsysteem naar een afbeelding of PDF en inspecteer de output. Dit vangt ontbrekende lettertypen, onvolledige glyph‑dekking, fallback‑gedrag en lay‑out‑wijzigingen op vóór distributie van de presentatie. Zie [Convert PowerPoint Presentations](/slides/nl/nodejs-java/convert-powerpoint/) voor voorbeelden van rendering en export.

## **FAQ**

**Wat retourneert `getScriptFont` wanneer een script niet is gemapt?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fonts/) retourneert `null` wanneer de gevraagde script‑mapping niet is gedefinieerd in die hoofd‑ of sub‑lettertypecollectie.

**Voegt `setScriptFont` een tweede mapping toe wanneer het script al bestaat?**

Nee. [Fonts.setScriptFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fonts/) maakt de mapping aan wanneer die ontbreekt en vervangt de toegewezen lettertypefamilie wanneer dezelfde script‑tag al aanwezig is.

**Waarom wijzigde een themamapping niet sommige tekst?**

De tekst kan een expliciet toegewezen lettertype hebben, een ander thema erven via een override, of beïnvloed worden door substitutie of fallback tijdens het renderen. Een script‑mapping op presentatieniveau regelt alleen tekst waarvan de effectieve opmaak nog steeds naar die themale lettertypecollectie verwijst.

**Is opslaan en opnieuw openen voldoende om meertalige output te valideren?**

Nee. Opnieuw openen verifieert alleen de persistentie van de themagegevens. Render tevens representatieve tekst uit elk vereist schrijfsysteem om te bevestigen dat de toegewezen lettertypen beschikbaar zijn en de nodige glyphs bevatten.