---
title: "Beheer script-specifieke themalettertypen in Java"
linktitle: "Script-specifieke themalettertypen"
type: docs
weight: 15
url: /nl/java/script-specific-font-mappings/
keywords:
- script-specifiek lettertype
- thema-lettertype-mapping
- meertalige presentatie
- schrift
- Cyrillisch lettertype
- Arabisch lettertype
- Japans lettertype
- Georgisch lettertype
- Thaana lettertype
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Inspecteer, voeg toe, vervang en verwijder script-specifieke lettertype-mappings in PowerPoint-thema's met Aspose.Slides voor Java."
---
## **Overzicht**

Een presentatiethema kan verschillende lettertypefamilies selecteren voor verschillende schriftssystemen. Dit maakt het mogelijk om meertalige tekst die nog steeds thema‑lettertypen gebruikt, één gecoördineerd lettertype‑schema te laten volgen, terwijl geschikte lettertypen voor Cyrillisch, Arabisch, Japans, Georgisch, Thaana en andere schriften worden gebruikt.

Het thema‑[IFontScheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/) bevat een hoofd‑lettertypeverzameling, doorgaans gebruikt voor koppen, en een secundaire lettertypeverzameling, doorgaans gebruikt voor de lopende tekst. Naast hun Latijnse en Oost‑Aziatische lettertype‑instellingen, bieden beide verzamelingen mappings van schrijfsysteem‑tags naar lettertype‑familienamen via de [IFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifonts/) interface.

Dit artikel laat zien hoe u die mappings in het master‑thema van de presentatie kunt inspecteren en aanpassen, en hoe u kunt verifiëren dat de wijzigingen een opslaan‑en‑herladen‑cyclus overleven.

## **Begrijpen van script‑tags**

De script‑lettertype‑methoden gebruiken vierletterige BCP 47 script‑subtags om schriftssystemen te identificeren. Veelvoorkomende waarden zijn:

| Script‑tag | Schriftsysteem |
|---|---|
| `Cyrl` | Cyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereenvoudigd Chinees |
| `Jpan` | Japans |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Deze mappings behoren tot het thematische lettertype‑schema, niet tot individuele tekstgedeelten. Een presentatie kan verschillende mappings definiëren voor de hoofd‑ en secundaire verzamelingen, en kan mappings voor sommige scripts weglaten.

## **Toegang tot en inspectie van script‑lettertype‑mappings**

Gebruik [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getMasterTheme--) om toegang te krijgen tot het thema op presentatieniveau. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/#getMajor--) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontscheme/#getMinor--) geven de twee [IFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifonts/)‑verzamelingen terug.

Roep [IFonts.getScriptFontMap](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fonts/#getScriptFontMap--) aan om alle mappings uit een verzameling op te halen. Om een specifiek schriftssysteem op te zoeken, roep je [IFonts.getScriptFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) aan met de bijbehorende script‑tag. `getScriptFont` retourneert `null` wanneer die verzameling de gevraagde mapping niet definieert.

## **Mappings wijzigen en persistentie verifiëren**

Gebruik [IFonts.setScriptFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) om een mapping te maken of de huidige lettertype‑familie te vervangen. Gebruik [IFonts.removeScriptFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) om een mapping te verwijderen.

Het volgende end‑to‑end voorbeeld leest alle bestaande hoofd‑ en secundaire mappings, zoekt het Japanse hoofd‑lettertype op, wijzigt het Cyrillische hoofd‑lettertype, verwijdert de Thaana‑secundaire mapping, slaat de presentatie op en opent deze opnieuw om beide wijzigingen te verifiëren. Om de verwijderingsstap onafhankelijk te maken van het oorspronkelijke thema, maakt het voorbeeld eerst een Thaana‑mapping aan alleen als er nog geen bestaat.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

De verificatie gebruikt hetzelfde `null`‑gedrag als een gewone lookup: na het opslaan van de verwijdering retourneert `getScriptFont("Thaa")` `null` voor de secundaire verzameling.

## **Verschil tussen themamappings en andere lettertype‑instellingen**

Script‑specifieke themamappings nemen deel aan de lettertype‑selectie, maar lossen een ander probleem op dan directe tekstopmaak, substitutie en fallback:

| Mechanisme | Doel | Effect van het wijzigen van een themamapping |
|---|---|---|
| Script‑specifieke themalettertype‑mapping | Selecteert een hoofd‑ of secundair themalettertype voor een schriftssysteem. | Tekst die nog steeds het overeenkomstige themalettertype gebruikt, kan zich verplaatsen naar de nieuw gemapte familie. |
| Lettertype expliciet toegewezen aan een tekstgedeelte | Bepaalt de gevraagde lettertype‑familie voor dat gedeelte in plaats van te vertrouwen op het thema. | Het gedeelte kan ongewijzigd blijven omdat de directe opmaak de themakeuze overschrijft. |
| Lettertype‑substitutie | Vervangt een gevraagd lettertype wanneer dat lettertype niet beschikbaar is of wanneer een substitutieregel van toepassing is. | Het treedt op nadat een lettertype is aangevraagd; het herschrijft de script‑mapping van het thema niet. |
| Lettertype‑fallback | Levert tekens die het geselecteerde lettertype niet bevat, vaak voor specifieke Unicode‑bereiken. | Het vult ontbrekende tekens aan; het wijzigt de opgeslagen themamapping niet. |

Voor meer informatie over de laatste twee mechanismen, zie [Lettertype‑substitutie](/slides/nl/java/font-substitution/) en [Fallback‑lettertypen](/slides/nl/java/fallback-font/).

Het wijzigen van een mapping in [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getMasterTheme--) beïnvloedt alleen inhoud waarvan de effectieve opmaak nog steeds afhankelijk is van dat thema. Tekst kan in plaats daarvan een themabijschrijving erven van een master, lay‑out of dia, of een expliciet toegewezen lettertype gebruiken. Inspecteer die niveaus wanneer het zichtbare resultaat niet overeenkomt met de mapping op presentatieniveau.

## **Gemapte lettertypen beschikbaar maken en het resultaat valideren**

Een script‑mapping slaat een lettertype‑familienaam op; hij installeert of laadt het bijbehorende lettertype‑bestand niet. Voor consistente weergave en export moet elk gemapt lettertype geïnstalleerd zijn in de omgeving of beschikbaar worden gesteld aan Aspose.Slides via een aangepaste bron zoals [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) of [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Zie [Aangepaste lettertypen](/slides/nl/java/custom-font/) voor de beschikbare laadopties.

Het verifiëren van de opgeslagen mapping bevestigt alleen dat de themadefinitie behouden bleef. Het bewijst niet dat het lettertype beschikbaar is, alle vereiste tekens bevat, of de beoogde lay‑out oplevert. Render representatieve tekst voor elk vereist schriftssysteem naar een afbeelding of PDF en inspecteer de uitvoer. Hiermee worden ontbrekende lettertypen, onvolledige teken‑dekking, fallback‑gedrag en lay‑outwijzigingen opgespoord voordat de presentatie wordt verspreid. Zie [PowerPoint‑presentaties converteren](/slides/nl/java/convert-powerpoint/) voor voorbeelden van weergave en export.

## **FAQ**

**Wat retourneert `getScriptFont` wanneer een script niet gemapt is?**

`[IFonts.getScriptFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-)` retourneert `null` wanneer de gevraagde script‑mapping niet is gedefinieerd in die hoofd‑ of secundaire lettertype‑verzameling.

**Voegt `setScriptFont` een tweede mapping toe wanneer het script al bestaat?**

Nee. `[IFonts.setScriptFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-)` maakt de mapping aan wanneer deze ontbreekt en vervangt de gemapte lettertype‑familie wanneer dezelfde script‑tag al aanwezig is.

**Waarom wijzigde het aanpassen van een themamapping niet sommige tekst?**

De tekst kan een expliciet toegewezen lettertype hebben, een ander thema erven via een overschrijving, of beïnvloed worden door substitutie of fallback tijdens het renderen. Een script‑mapping op presentatieniveau regelt alleen tekst waarvan de effectieve opmaak nog steeds verwijst naar die themalettertype‑verzameling.

**Is opslaan en opnieuw openen voldoende om meertalige output te valideren?**

Nee. Het opnieuw openen verifieert alleen de persistentie van de themagegevens. Render bovendien representatieve tekst uit elk vereist schriftssysteem om te bevestigen dat de gemapte lettertypen beschikbaar zijn en de benodigde tekens bevatten.