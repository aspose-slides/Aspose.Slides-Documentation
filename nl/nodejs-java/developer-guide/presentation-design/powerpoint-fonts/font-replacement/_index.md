---
title: Stroomlijn lettertypevervanging in presentaties met JavaScript
linktitle: Lettertypevervanging
type: docs
weight: 60
url: /nl/nodejs-java/font-replacement/
keywords:
- lettertype
- lettertype vervangen
- lettertypevervanging
- lettertype wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Vervang moeiteloos lettertypen in JavaScript met Aspose.Slides voor Node.js via Java om consistente typografie te garanderen in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een lettertype door een ander te vervangen in de hele presentatie. Wanneer een lettertype wordt vervangen, worden alle exemplaren van het oorspronkelijke lettertype gewijzigd in het nieuwe lettertype.

Om lettertypevervanging uit te voeren, laadt u de presentatie, definieert u het bronlettertype en het vervangende lettertype, roept u de vervangingsmethode aan en slaat u de gewijzigde presentatie op als een PPTX‑bestand. Deze aanpak is handig wanneer u opzettelijk van het ene lettertypefamilie naar een andere wilt overschakelen in de hele presentatie.

## **Lettertypen vervangen**

Als u van gedachten verandert over het gebruik van een lettertype, kunt u dat lettertype door een ander vervangen. Alle exemplaren van het oude lettertype worden vervangen door het nieuwe lettertype.

Aspose.Slides stelt u in staat om een lettertype op deze manier te vervangen:

1. Laad de relevante presentatie. 
2. Laad het lettertype dat vervangen moet worden. 
3. Laad het nieuwe lettertype. 
4. Vervang het lettertype. 
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze JavaScript‑code toont lettertypevervanging:

```javascript
// Laadt een presentatie
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Laadt het bronlettertype dat vervangen zal worden
    var sourceFont = new aspose.slides.FontData("Arial");
    // Laadt het nieuwe lettertype
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Vervangt de lettertypen
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Slaat de presentatie op
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Opmerking" color="warning" %}} 
Om regels in te stellen die bepalen wat er gebeurt onder bepaalde omstandigheden (bijvoorbeeld wanneer een lettertype niet toegankelijk is), zie [**Lettertype‑substitutie**](/slides/nl/nodejs-java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen “lettertype‑vervanging”, “lettertype‑substitutie” en “fallback‑lettertypen”?**

Vervanging is een bewuste omschakeling van de ene familie naar de andere in het hele document. [Substitutie](/slides/nl/nodejs-java/font-substitution/) is een regel als “als het lettertype niet beschikbaar is, gebruik X.” [Fallback](/slides/nl/nodejs-java/fallback-font/) wordt chirurgisch toegepast op individuele ontbrekende tekens wanneer het basislettertype geïnstalleerd is maar de vereiste karakters niet bevat.

**Wordt vervanging toegepast op master‑slides, lay-outs, notities en opmerkingen?**

Ja. Vervanging beïnvloedt alle presentatie‑objecten die het oorspronkelijke lettertype gebruiken, inclusief master‑slides en notities; opmerkingen maken ook deel uit van het document en worden meegenomen door de lettertype‑engine.

**Wordt het lettertype aangepast in ingebedde OLE‑objecten (bijvoorbeeld Excel)?**

Nee. [OLE‑inhoud](/slides/nl/nodejs-java/manage-ole/) wordt beheerd door de eigen toepassing. Vervanging in de presentatie herschikt de interne OLE‑gegevens niet; deze worden mogelijk weergegeven als afbeelding of als extern bewerkbare inhoud.

**Kan ik een lettertype alleen in een deel van de presentatie (per dia of regio) vervangen?**

Gerichte vervanging is mogelijk wanneer u het lettertype wijzigt op het niveau van de vereiste objecten/bereiken in plaats van een globale vervanging op het gehele document toe te passen. De algemene logica voor lettertype‑selectie tijdens het renderen blijft ongewijzigd.

**Hoe kan ik vooraf bepalen welke lettertypen de presentatie allemaal gebruikt?**

Gebruik de [lettertype‑manager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/) van de presentatie: deze geeft een lijst van de [gebruikte families](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getfonts/) en informatie over [substituties/“onbekende” lettertypen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/), wat helpt bij het plannen van de vervanging.

**Werkt lettertype‑vervanging bij het converteren naar PDF/afbeeldingen?**

Ja. Tijdens export past Aspose.Slides dezelfde [lettertype‑selectie‑/substitutiereeks](/slides/nl/nodejs-java/font-selection-sequence/) toe, zodat een vooraf uitgevoerde vervanging gerespecteerd wordt bij de conversie.

**Moet ik het doel‑lettertype installeren op het systeem, of kan ik een lettertype‑map bijvoegen?**

Installatie is niet vereist: de bibliotheek staat toe om [externe lettertypen](/slides/nl/nodejs-java/custom-font/) uit gebruikersmappen te laden voor gebruik tijdens [renderen en exporteren](/slides/nl/nodejs-java/convert-powerpoint/).

**Zal vervanging “tofu” (vierkanten) in plaats van tekens oplossen?**

Alleen als het doel‑lettertype daadwerkelijk de vereiste glieven bevat. Zo niet, [configureer fallback](/slides/nl/nodejs-java/fallback-font/) om de ontbrekende tekens te dekken.