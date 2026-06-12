---
title: Vereenvoudig lettertypevervanging in presentaties op Android
linktitle: Lettertypevervanging
type: docs
weight: 60
url: /nl/androidjava/font-replacement/
keywords:
- lettertype
- lettertype vervangen
- lettertypevervanging
- lettertype wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Vervang lettertypen naadloos in Aspose.Slides voor Android via Java om consistente typografie te garanderen in PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om één lettertype te vervangen door een ander in de hele presentatie. Wanneer een lettertype wordt vervangen, worden alle exemplaren van het oorspronkelijke lettertype gewijzigd in het nieuwe lettertype.

Om een lettertypevervanging uit te voeren, laadt u de presentatie, definieert u het bronlettertype en het vervangende lettertype, roept u de methode voor lettertypevervanging aan en slaat u de gewijzigde presentatie op als een PPTX‑bestand. Deze aanpak is handig wanneer u opzettelijk van de ene lettertype‑familie naar de andere wilt overschakelen in de gehele presentatie.

## **Lettertypen vervangen**

Als u van gedachten verandert over het gebruik van een lettertype, kunt u dat lettertype door een ander vervangen. Alle exemplaren van het oude lettertype worden vervangen door het nieuwe lettertype.

Aspose.Slides stelt u in staat om een lettertype op deze manier te vervangen:

1. Laad de betreffende presentatie.  
2. Laad het lettertype dat vervangen zal worden.  
3. Laad het nieuwe lettertype.  
4. Vervang het lettertype.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Java‑code demonstreert lettertypevervanging:

```java
// Laadt een presentatie
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Laadt het bronlettertype dat zal worden vervangen
    IFontData sourceFont = new FontData("Arial");
    
    // Laadt het nieuwe lettertype
    IFontData destFont = new FontData("Times New Roman");
    
    // Vervangt de lettertypen
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Slaat de presentatie op
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Om regels in te stellen die bepalen wat er gebeurt onder bepaalde omstandigheden (bijvoorbeeld als een lettertype niet toegankelijk is), zie [**Lettertype‑substitutie**](/slides/nl/androidjava/font-substitution/).
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen “lettertype‑vervanging”, “lettertype‑substitutie” en “fallback‑lettertypen”?**

Vervanging is een opzettelijke omschakeling van de ene familie naar de andere in het gehele document. [Substitutie](/slides/nl/androidjava/font-substitution/) is een regel zoals “als het lettertype niet beschikbaar is, gebruik dan X.” [Fallback](/slides/nl/androidjava/fallback-font/) wordt chirurgisch toegepast voor individuele ontbrekende glyphs wanneer het basislettertype geïnstalleerd is maar niet de benodigde tekens bevat.

**Is vervanging van toepassing op masterslides, lay‑outs, notities en opmerkingen?**

Ja. Vervanging beïnvloedt alle presentatie‑objecten die het oorspronkelijke lettertype gebruiken, inclusief masterslides en notities; opmerkingen maken ook deel uit van het document en worden door de lettertype‑engine in aanmerking genomen.

**Wordt het lettertype ook gewijzigd in ingesloten OLE‑objecten (bijvoorbeeld Excel)?**

Nee. [OLE‑inhoud](/slides/nl/androidjava/manage-ole/) wordt beheerd door de eigen applicatie. Vervanging in de presentatie formatteert de interne OLE‑gegevens niet opnieuw; ze kunnen worden weergegeven als een afbeelding of als extern bewerkbare inhoud.

**Kan ik een lettertype alleen in een deel van de presentatie vervangen (per slide of regio)?**

Gerichte vervanging is mogelijk als u het lettertype wijzigt op het niveau van de benodigde objecten/gebieden in plaats van een globale vervanging toe te passen op het gehele document. De algemene logica voor lettertype‑selectie tijdens het renderen blijft hetzelfde.

**Hoe kan ik vooraf bepalen welke lettertypen de presentatie gebruikt?**

Gebruik de [font manager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/) van de presentatie: deze biedt een lijst van de [families in gebruik](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#getFonts--) en informatie over [substituties/"onbekende" lettertypen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), die helpt bij het plannen van de vervanging.

**Werkt lettertype‑vervanging bij het converteren naar PDF/afbeeldingen?**

Ja. Tijdens export past Aspose.Slides dezelfde [lettertype‑selectie/substitutie‑volgorde](/slides/nl/androidjava/font-selection-sequence/) toe, waardoor een vooraf uitgevoerde vervanging wordt gerespecteerd bij de conversie.

**Moet ik het doel‑lettertype in het systeem installeren, of kan ik een lettertype‑map bijvoegen?**

Installatie is niet vereist: de bibliotheek staat [het laden van externe lettertypen](/slides/nl/androidjava/custom-font/) vanuit gebruikersmappen toe voor gebruik tijdens [renderen en exporteren](/slides/nl/androidjava/convert-powerpoint/).

**Zal vervanging “tofu” (vierkanten) in plaats van tekens verhelpen?**

Alleen als het doel‑lettertype daadwerkelijk de vereiste glyphs bevat. Zo niet, [configureer fallback](/slides/nl/androidjava/fallback-font/) om de ontbrekende tekens te dekken.