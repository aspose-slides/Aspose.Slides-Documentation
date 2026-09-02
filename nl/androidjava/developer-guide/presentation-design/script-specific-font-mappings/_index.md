---
title: Beheer script‑specifieke themalettertypen op Android
linktitle: Script‑specifieke themalettertypen
type: docs
weight: 15
url: /nl/androidjava/script-specific-font-mappings/
keywords:
- script‑specifiek lettertype
- thema‑lettertype‑koppeling
- meertalige presentatie
- schrijfsysteem
- Cyrillisch lettertype
- Arabisch lettertype
- Japans lettertype
- Georgisch lettertype
- Thaana lettertype
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Inspecteer, voeg toe, vervang en verwijder script‑specifieke lettertype‑koppelingen in PowerPoint‑thema's met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Een presentatiethema kan verschillende lettertype‑familieën selecteren voor verschillende schrijfsystemen. Dit maakt meertalige tekst die nog steeds thema‑lettertypen gebruikt mogelijk, waarbij één gecoördineerd lettertype‑schema wordt gevolgd, maar met geschikte lettertypen voor Cyrillisch, Arabisch, Japans, Georgisch, Thaana en andere scripts.

Het thema‑[IFontScheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/) bevat een hoofdlettertype‑collectie, doorgaans gebruikt voor koppen, en een secundaire lettertype‑collectie, doorgaans gebruikt voor de hoofdtekst. Naast hun Latijnse en Oost‑Azia‑lettertype‑instellingen, bieden beide collecties koppelingen van schrijfsysteem‑tags naar lettertype‑families via de [IFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifonts/)‑interface.

Dit artikel laat zien hoe u die koppelingen in het master‑thema van de presentatie kunt inspecteren en wijzigen, en hoe u kunt controleren of de wijzigingen een opslaan‑en‑herladen‑cyclus overleven.

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

Deze koppelingen maken deel uit van het thematische lettertype‑schema, niet van individuele tekstgedeelten. Een presentatie kan verschillende koppelingen definiëren voor de hoofd‑ en secundaire collecties, en kan koppelingen voor sommige scripts weglaten.

## **Toegang tot en inspectie van script‑lettertype‑koppelingen**

Gebruik [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getMasterTheme--) om toegang te krijgen tot het thema op presentatieniveau. De methoden [IFontScheme.getMajor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/#getMajor--) en [IFontScheme.getMinor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontscheme/#getMinor--) retourneren respectievelijk de twee [IFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifonts/)‑collecties.

Roep [IFonts.getScriptFontMap](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) aan om alle koppelingen van een collectie op te halen. Om één schrijfsysteem op te zoeken, roep je [IFonts.getScriptFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) aan met de bijbehorende script‑tag. `getScriptFont` retourneert `null` wanneer die collectie de gevraagde koppeling niet definieert.

## **Wijzigen van koppelingen en controle van blijvendheid**

Gebruik [IFonts.setScriptFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) om een koppeling te maken of de huidige lettertype‑familie te vervangen. Gebruik [IFonts.removeScriptFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) om een koppeling te verwijderen.

Het volgende end‑to‑end‑voorbeeld leest alle bestaande hoofd‑ en secundaire koppelingen, zoekt het Japanse hoofdlettertype op, wijzigt het Cyrillische hoofdlettertype, verwijdert de Thaana‑secundaire koppeling, slaat de presentatie op en opent deze opnieuw om beide wijzigingen te verifiëren. Om de verwijderingsstap onafhankelijk te maken van het initiële thema, creëert het voorbeeld eerst een Thaana‑koppeling alleen wanneer er nog geen bestaat.

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

De verificatie maakt gebruik van hetzelfde `null`‑gedrag als een gewone opzoeking: nadat de verwijdering is opgeslagen, retourneert `getScriptFont("Thaa")` `null` voor de secundaire collectie.

## **Onderscheid thema‑koppelingen van andere lettertype‑instellingen**

Script‑specifieke themakoppelingen nemen deel aan de lettertype‑selectie, maar lossen een ander probleem op dan directe tekstopmaak, substitutie en fallback:

| Mechanisme | Doel | Effect van het wijzigen van een themakoppeling |
|---|---|---|
| Script‑specifieke themakoppeling | Selecteert een hoofd‑ of secundair themalettertype voor een schrijfsysteem. | Tekst die nog steeds het bijbehorende themalettertype gebruikt, kan overgaan op de nieuw gekoppelde familie. |
| Lettertype expliciet toegewezen aan een tekstgedeelte | Fixeert de gevraagde lettertype‑familie op dat gedeelte in plaats van te vertrouwen op het thema. | Het gedeelte blijft mogelijk onveranderd omdat de directe opmaak de themakeuze overschrijft. |
| Lettertype‑substitutie | Vervangt een gevraagd lettertype wanneer dat lettertype niet beschikbaar is of wanneer een substitutieregel van toepassing is. | Het treedt op nadat een lettertype is aangevraagd; het herschrijft de script‑koppeling van het thema niet. |
| Lettertype‑fallback | Levert glyphs die het geselecteerde lettertype niet bevat, vaak voor specifieke Unicode‑bereiken. | Het vult ontbrekende glyph‑dekking; het verandert de opgeslagen themakoppeling niet. |

Voor meer informatie over de laatste twee mechanismen, zie [Font Substitution](/slides/nl/androidjava/font-substitution/) en [Fallback Fonts](/slides/nl/androidjava/fallback-font/).

Het wijzigen van een koppeling via [Presentation.getMasterTheme](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getMasterTheme--) beïnvloedt alleen inhoud waarvan de effectieve opmaak nog steeds afhankelijk is van dat thema. Tekst kan in plaats daarvan een thematisch override erven van een master, lay‑out of dia, of een expliciet toegewezen lettertype gebruiken. Inspecteer die niveaus wanneer het zichtbare resultaat niet overeenkomt met de koppeling op presentatieniveau.

## **Zorg dat gekoppelde lettertypen beschikbaar zijn en valideer het resultaat**

Een script‑koppeling slaat een lettertype‑familienaam op; het installeert of laadt het bijbehorende lettertype‑bestand niet. Voor consistente weergave en export moet elk gekoppeld lettertype geïnstalleerd zijn in de omgeving of beschikbaar worden gesteld aan Aspose.Slides via een aangepaste bron, zoals [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) of [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Zie [Custom Fonts](/slides/nl/androidjava/custom-font/) voor de beschikbare laadopties.

Het verifiëren van de opgeslagen koppeling bevestigt alleen dat de themadefinities behouden zijn gebleven. Het bewijst niet dat het lettertype beschikbaar is, alle vereiste glyphs bevat, of de beoogde lay‑out oplevert. Render representatieve tekst voor elk vereist schrijfsysteem naar een afbeelding of PDF en inspecteer de output. Zo ontdek je ontbrekende lettertypen, onvolledige glyph‑dekking, fallback‑gedrag en lay‑out‑wijzigingen voordat de presentatie wordt verspreid. Zie [Convert PowerPoint Presentations](/slides/nl/androidjava/convert-powerpoint/) voor render‑ en exportvoorbeelden.

## **Veelgestelde vragen**

**Wat retourneert `getScriptFont` wanneer een script niet is gekoppeld?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) retourneert `null` wanneer de gevraagde script‑koppeling niet is gedefinieerd in die hoofd‑ of secundaire lettertype‑collectie.

**Voegt `setScriptFont` een tweede koppeling toe wanneer het script al bestaat?**

Nee. [IFonts.setScriptFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) maakt de koppeling aan wanneer deze ontbreekt en vervangt de gekoppelde lettertype‑familie wanneer dezelfde script‑tag al aanwezig is.

**Waarom wijzigde het wijzigen van een themakoppeling sommige tekst niet?**

De tekst kan een expliciet toegewezen lettertype hebben, een ander thema erven via een override, of worden beïnvloed door substitutie of fallback tijdens het renderen. Een script‑koppeling op presentatieniveau beïnvloedt alleen tekst waarvan de effectieve opmaak nog steeds verwijst naar die themalettertype‑collectie.

**Is opslaan en opnieuw openen voldoende om meertalige output te valideren?**

Nee. Opnieuw openen verifieert alleen de persistentie van de themagegevens. Daarnaast moet representatieve tekst van elk vereist schrijfsysteem worden gerenderd om te bevestigen dat de gekoppelde lettertypen beschikbaar zijn en de benodigde glyphs bevatten.