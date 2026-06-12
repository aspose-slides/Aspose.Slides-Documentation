---  
title: Optimaliseer lettertypevervanging in presentaties in .NET  
linktitle: Lettertypevervanging  
type: docs  
weight: 60  
url: /nl/net/font-replacement/  
keywords:  
- lettertype  
- lettertype vervangen  
- lettertypevervanging  
- lettertype wijzigen  
- PowerPoint  
- OpenDocument  
- presentatie  
- .NET  
- C#  
- Aspose.Slides  
description: "Vervang moeiteloos lettertypen in Aspose.Slides voor .NET om consistente typografie te garanderen in PowerPoint- en OpenDocument-presentaties."  
---
## **Overzicht**

Aspose.Slides stelt u in staat om een lettertype in een hele presentatie te vervangen door een ander lettertype. Wanneer een lettertype wordt vervangen, worden alle exemplaren van het oorspronkelijke lettertype gewijzigd in het nieuwe lettertype.

Om een lettertypevervanging uit te voeren, laadt u de presentatie, definieert u het bronlettertype en het vervangende lettertype, roept u de methode voor lettertypevervanging aan en slaat u de aangepaste presentatie op als een PPTX‑bestand. Deze aanpak is handig wanneer u opzettelijk van de ene lettertypefamilie naar de andere wilt overschakelen in de hele presentatie.

## **Lettertypen vervangen**

Als u van gedachten verandert over het gebruik van een lettertype, kunt u dat lettertype vervangen door een ander lettertype. Alle exemplaren van het oude lettertype worden vervangen door het nieuwe lettertype.

Aspose.Slides stelt u in staat een lettertype op deze manier te vervangen:

1. Laad de betreffende presentatie. 
2. Laad het lettertype dat vervangen zal worden.
3. Laad het nieuwe lettertype. 
4. Vervang het lettertype. 
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze C#‑code demonstreert een lettertypevervanging:

```c#
// Laadt een presentatie
Presentation presentation = new Presentation("Fonts.pptx");

// Laadt het bronlettertype dat vervangen zal worden
IFontData sourceFont = new FontData("Arial");

// Laadt het nieuwe lettertype
IFontData destFont = new FontData("Times New Roman");

// Vervangt de lettertypen
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Slaat de presentatie op
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 

Om regels in te stellen die bepalen wat er gebeurt onder bepaalde omstandigheden (bijvoorbeeld als een lettertype niet toegankelijk is), zie [**Lettertypevervanging**](/slides/nl/net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen “lettertypevervanging”, “lettertype‑substitutie” en “fallback‑lettertypen”?**

Vervanging is een bewuste overstap van de ene familie naar de andere in het hele document. [Substitutie](/slides/nl/net/font-substitution/) is een regel als “als het lettertype niet beschikbaar is, gebruik X.” [Fallback](/slides/nl/net/fallback-font/) wordt chirurgisch toegepast op afzonderlijke ontbrekende glyphs wanneer het basis‑lettertype geïnstalleerd is maar niet over de vereiste tekens beschikt.

**Is vervanging van toepassing op masterslides, lay‑outs, notities en opmerkingen?**

Ja. Vervanging heeft invloed op alle presentatie‑objecten die het oorspronkelijke lettertype gebruiken, inclusief masterslides en notities; opmerkingen maken ook deel uit van het document en worden door de lettertype‑engine in overweging genomen.

**Zal het lettertype veranderen binnen ingebedde OLE‑objecten (bijvoorbeeld Excel)?**

Nee. [OLE‑inhoud](/slides/nl/net/manage-ole/) wordt beheerd door de eigen applicatie. Vervanging in de presentatie formatteert de interne OLE‑gegevens niet opnieuw; deze kunnen worden weergegeven als een afbeelding of als extern bewerkbare inhoud.

**Kan ik een lettertype alleen in een deel van de presentatie vervangen (per slide of regio)?**

Gerichte vervanging is mogelijk als u het lettertype wijzigt op het niveau van de benodigde objecten/bereiken in plaats van een globale vervanging toe te passen op het volledige document. De algemene logica voor lettertype‑selectie tijdens het renderen blijft ongewijzigd.

**Hoe kan ik van tevoren bepalen welke lettertypen de presentatie gebruikt?**

Gebruik de presentatie‑[lettertype‑manager](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/): deze biedt een lijst van de [gebruikte families](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getfonts/) en informatie over [substituties/"onbekende" lettertypen](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/getsubstitutions/), wat helpt bij het plannen van de vervanging.

**Werkt lettertypevervanging bij het converteren naar PDF/afbeeldingen?**

Ja. Tijdens het exporteren past Aspose.Slides dezelfde [lettertype‑selectie/substitutie‑reeks](/slides/nl/net/font-selection-sequence/) toe, zodat een vooraf uitgevoerde vervanging wordt gerespecteerd tijdens de conversie.

**Moet ik het doel‑lettertype op het systeem installeren, of kan ik een lettertype‑map bijvoegen?**

Installatie is niet vereist: de bibliotheek staat het [laden van externe lettertypen](/slides/nl/net/custom-font/) vanuit gebruikersmappen toe voor gebruik tijdens het [renderen en exporteren](/slides/nl/net/convert-powerpoint/).

**Zal vervanging "tofu" (vierkanten) in plaats van tekens verhelpen?**

Alleen als het doel‑lettertype daadwerkelijk de benodigde glyphs bevat. Zo niet, [configureer fallback](/slides/nl/net/fallback-font/) om de ontbrekende tekens te dekken.