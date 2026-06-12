---
title: Versimpel het vervangen van lettertypen in presentaties met C++
linktitle: Lettertypevervanging
type: docs
weight: 60
url: /nl/cpp/font-replacement/
keywords:
- lettertype
- lettertype vervangen
- lettertypevervanging
- lettertype wijzigen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Vervang naadloos lettertypen in Aspose.Slides voor C++ om consistente typografie te garanderen in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om één lettertype in een hele presentatie te vervangen door een ander. Wanneer een lettertype wordt vervangen, worden alle exemplaren van het oorspronkelijke lettertype veranderd in het nieuwe lettertype.

Om een lettertypevervanging uit te voeren, laadt u de presentatie, definieert u het bronlettertype en het vervangende lettertype, roept u de lettertypevervangingsmethode aan en slaat u de gewijzigde presentatie op als een PPTX‑bestand. Deze aanpak is handig wanneer u bewust van de ene lettertypefamilie naar de andere wilt schakelen in de hele presentatie.

## **Lettertypen vervangen**

Als u van gedachten verandert over het gebruik van een lettertype, kunt u dat lettertype vervangen door een ander. Alle exemplaren van het oude lettertype worden vervangen door het nieuwe lettertype.

Aspose.Slides stelt u in staat om een lettertype op deze manier te vervangen:

1. Laad de betreffende presentatie.  
2. Laad het lettertype dat vervangen moet worden.  
3. Laad het nieuwe lettertype.  
4. Vervang het lettertype.  
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze C++‑code laat een lettertypevervanging zien:

``` cpp
// Laadt een presentatie
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Laadt het bronlettertype dat vervangen zal worden
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Laadt het nieuwe lettertype
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Vervangt de lettertypen
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Slaat de presentatie op
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Om regels in te stellen die bepalen wat er gebeurt in bepaalde omstandigheden (bijvoorbeeld als een lettertype niet toegankelijk is), zie [**Font Substitution**](/slides/nl/cpp/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen "font replacement", "font substitution" en "fallback fonts"?**

Vervanging is een bewuste overstap van de ene familie naar de andere in het hele document. [Substitution](/slides/nl/cpp/font-substitution/) is een regel als “als het lettertype niet beschikbaar is, gebruik X”. [Fallback](/slides/nl/cpp/fallback-font/) wordt chirurgisch toegepast op individuele ontbrekende glyphs wanneer het basislettertype geïnstalleerd is maar niet de vereiste tekens bevat.

**Is vervanging van toepassing op masterslides, lay-outs, notities en opmerkingen?**

Ja. Vervanging heeft invloed op alle presentatie‑objecten die het oorspronkelijke lettertype gebruiken, inclusief masterslides en notities; opmerkingen maken ook deel uit van het document en worden door de lettertype‑engine in aanmerking genomen.

**Zal het lettertype gewijzigd worden binnen ingesloten OLE‑objecten (bijvoorbeeld Excel)?**

Nee. [OLE content](/slides/nl/cpp/manage-ole/) wordt beheerd door de eigen toepassing. Vervanging in de presentatie formatteert de interne OLE‑gegevens niet opnieuw; deze kunnen weergegeven worden als een afbeelding of als extern bewerkbare inhoud.

**Kan ik een lettertype slechts in een deel van de presentatie vervangen (per dia of regio)?**

Gerichte vervanging is mogelijk als u het lettertype wijzigt op het niveau van de benodigde objecten/bereiken in plaats van een globale vervanging toe te passen op het gehele document. De algemene lettertype‑selectielogica tijdens het renderen blijft ongewijzigd.

**Hoe kan ik van tevoren bepalen welke lettertypen de presentatie overal gebruikt?**

Gebruik de presentatie’s [font manager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/): deze geeft een lijst van de [families in use](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getfonts/) en informatie over [substitutions/"unknown" fonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getsubstitutions/), die helpt bij het plannen van de vervanging.

**Werkt lettertypevervanging bij het converteren naar PDF/afbeeldingen?**

Ja. Tijdens export past Aspose.Slides dezelfde [font selection/substitution sequence](/slides/nl/cpp/font-selection-sequence/) toe, zodat een vooraf uitgevoerde vervanging wordt gerespecteerd tijdens de conversie.

**Moet ik het doelfonttype in het systeem installeren, of kan ik een map met lettertypen bijvoegen?**

Installatie is niet vereist: de bibliotheek staat het [loading external fonts](/slides/nl/cpp/custom-font/) toe vanuit gebruikersmappen voor gebruik tijdens het [rendering and export](/slides/nl/cpp/convert-powerpoint/).

**Zal vervanging “tofu” (vierkanten) in plaats van tekens verhelpen?**

Alleen als het doelfonttype daadwerkelijk de vereiste glyphs bevat. Zo niet, [configure fallback](/slides/nl/cpp/fallback-font/) om de ontbrekende tekens te dekken.