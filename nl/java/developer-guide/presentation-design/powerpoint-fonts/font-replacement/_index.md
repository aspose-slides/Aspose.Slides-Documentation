---
title: Stroomlijn Lettertypevervanging in Presentaties met Java
linktitle: Lettertypevervanging
type: docs
weight: 60
url: /nl/java/font-replacement/
keywords:
- lettertype
- lettertype vervangen
- lettertypevervanging
- lettertype wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Vervang moeiteloos lettertypen in Aspose.Slides voor Java om consistente typografie in PowerPoint- en OpenDocument-presentaties te waarborgen."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een lettertype te vervangen door een ander lettertype in de hele presentatie. Wanneer een lettertype wordt vervangen, worden alle exemplaren van het oorspronkelijke lettertype gewijzigd naar het nieuwe lettertype.

Om een lettertypevervanging uit te voeren, laadt u de presentatie, definieert u het bronlettertype en het vervangende lettertype, roept u de lettertypevervangingsmethode aan en slaat u de gewijzigde presentatie op als een PPTX-bestand. Deze aanpak is handig wanneer u opzettelijk wilt overschakelen van de ene lettertypefamilie naar de andere in de hele presentatie.

## **Lettertypen vervangen**

Als u van gedachten verandert over het gebruik van een lettertype, kunt u dat lettertype vervangen door een ander lettertype. Alle exemplaren van het oude lettertype worden vervangen door het nieuwe lettertype.

Aspose.Slides stelt u in staat om een lettertype op deze manier te vervangen:

1. Laad de betreffende presentatie. 
2. Laad het lettertype dat vervangen moet worden. 
3. Laad het nieuwe lettertype. 
4. Vervang het lettertype. 
5. Schrijf de gewijzigde presentatie weg als een PPTX-bestand.

Deze Java-code demonstreert lettertypevervanging:

```java
// Laadt een presentatie
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Laadt het bronlettertype dat vervangen zal worden
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
Om regels in te stellen die bepalen wat er gebeurt onder bepaalde omstandigheden (bijvoorbeeld als een lettertype niet toegankelijk is), zie [**Lettertype-substitutie**](/slides/nl/java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen "lettertype-vervanging", "lettertype-substitutie" en "fallback-lettertypen"?**

Vervanging is een bewuste omschakeling van de ene familie naar de andere in het volledige document. [Substitutie](/slides/nl/java/font-substitution/) is een regel zoals "als het lettertype niet beschikbaar is, gebruik X." [Fallback](/slides/nl/java/fallback-font/) wordt chirurgisch toegepast voor individuele ontbrekende glyphs wanneer het baslettertype geïnstalleerd is maar de vereiste tekens niet bevat.

**Is vervanging van toepassing op master-dia's, lay-outs, aantekeningen en opmerkingen?**

Ja. Vervanging heeft invloed op alle presentatie-objecten die het oorspronkelijke lettertype gebruiken, inclusief master-dia's en aantekeningen; opmerkingen maken ook deel uit van het document en worden door de lettertype-engine meegenomen.

**Zal het lettertype wijzigen binnen ingesloten OLE-objecten (bijvoorbeeld Excel)?**

Nee. [OLE-inhoud](/slides/nl/java/manage-ole/) wordt beheerd door de eigen toepassing. Vervanging in de presentatie herformatteert de interne OLE-gegevens niet; ze kunnen worden weergegeven als een afbeelding of als extern bewerkbare inhoud.

**Kan ik een lettertype alleen in een deel van de presentatie (per dia of regio) vervangen?**

Gerichte vervanging is mogelijk als u het lettertype wijzigt op het niveau van de benodigde objecten/bereiken in plaats van een globale vervanging toe te passen op het gehele document. De algehele logica voor lettertype-selectie tijdens het renderen blijft ongewijzigd.

**Hoe kan ik van tevoren bepalen welke lettertypen de presentatie gebruikt?**

Gebruik de [lettertype-beheerder](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/): deze geeft een lijst van de [gebruikte families](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#getFonts--) en informatie over [substituties/"onbekende" lettertypen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#getSubstitutions--), wat helpt bij het plannen van de vervanging.

**Werkt lettertypevervanging bij het converteren naar PDF/afbeeldingen?**

Ja. Tijdens export past Aspose.Slides dezelfde [lettertype-selectie/-substitutievolgorde](/slides/nl/java/font-selection-sequence/) toe, zodat een vooraf uitgevoerde vervanging wordt gerespecteerd tijdens de conversie.

**Moet ik het doellettertype installeren op het systeem, of kan ik een lettertype-map bijvoegen?**

Installatie is niet nodig: de bibliotheek staat het [laden van externe lettertypen](/slides/nl/java/custom-font/) vanuit gebruikersmappen toe voor gebruik tijdens het [renderen en exporteren](/slides/nl/java/convert-powerpoint/).

**Zal vervanging de "tofu" (vierkanten) in plaats van tekens oplossen?**

Alleen als het doellettertype de vereiste glyphs daadwerkelijk bevat. Zo niet, [fallback configureren](/slides/nl/java/fallback-font/) om de ontbrekende tekens te dekken.