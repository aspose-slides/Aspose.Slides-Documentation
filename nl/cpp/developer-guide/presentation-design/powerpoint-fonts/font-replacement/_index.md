---
title: Lettertypevervanging in presentaties stroomlijnen met C++
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
description: "Vervang moeiteloos lettertypen in Aspose.Slides voor C++ om consistente typografie te garanderen in PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om één lettertype door een ander te vervangen in de hele presentatie. Wanneer een lettertype wordt vervangen, worden alle exemplaren van het oorspronkelijke lettertype gewijzigd in het nieuwe lettertype.

Om een lettertypevervanging uit te voeren, laadt u de presentatie, definieert u het bronlettertype en het vervangende lettertype, roept u de methode voor lettertypevervanging aan en slaat u de aangepaste presentatie op als een PPTX‑bestand. Deze aanpak is handig wanneer u opzettelijk van de ene lettertype‑familie naar de andere wilt overschakelen in de hele presentatie.

## **Lettertypen vervangen**

Als u van gedachten verandert over het gebruik van een lettertype, kunt u dat lettertype door een ander vervangen. Alle exemplaren van het oude lettertype worden vervangen door het nieuwe.

Aspose.Slides maakt het mogelijk om een lettertype op deze manier te vervangen:

1. Laad de betreffende presentatie.  
2. Laad het lettertype dat vervangen zal worden.  
3. Laad het nieuwe lettertype.  
4. Vervang het lettertype.  
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze C++‑code demonstreert lettertypevervanging:

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

{{% alert title="Opmerking" color="warning" %}} 
Om regels in te stellen die bepalen wat er gebeurt onder bepaalde omstandigheden (bijvoorbeeld als een lettertype niet toegankelijk is), zie [**Lettertypevervanging**](/slides/nl/cpp/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen "font replacement", "font substitution" en "fallback fonts"?**

Vervanging is een bewuste omschakeling van de ene familie naar de andere in het volledige document. [Substitution](/slides/nl/cpp/font-substitution/) is een regel zoals "als het lettertype niet beschikbaar is, gebruik X." [Fallback](/slides/nl/cpp/fallback-font/) wordt chirurgisch toegepast voor individuele ontbrekende glyfen wanneer het basislettertype geïnstalleerd is maar niet de benodigde tekens bevat.

**Is vervanging van toepassing op masterslides, lay‑outs, notities en opmerkingen?**

Ja. Vervanging heeft invloed op alle presentatie‑objecten die het oorspronkelijke lettertype gebruiken, inclusief masterslides en notities; opmerkingen maken ook deel uit van het document en worden door de lettertype‑engine in aanmerking genomen.

**Zal het lettertype veranderen binnen ingesloten OLE‑objecten (bijvoorbeeld Excel)?**

Nee. [OLE content](/slides/nl/cpp/manage-ole/) wordt beheerd door de eigen toepassing. Vervanging in de presentatie formatteert de interne OLE‑gegevens niet opnieuw; ze kunnen worden weergegeven als een afbeelding of als extern bewerkbare inhoud.

**Kan ik een lettertype alleen in een deel van de presentatie vervangen (per slide of regio)?**

Gerichte vervanging is mogelijk als u het lettertype wijzigt op het niveau van de benodigde objecten/bereiken in plaats van een algemene vervanging op het hele document toe te passen. De algehele logica voor lettertype‑selectie tijdens het renderen blijft hetzelfde.

**Hoe kan ik vooraf bepalen welke lettertypen de presentatie gebruikt?**

Gebruik de presentatie‑[lettertypebeheer](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/): het biedt een lijst van de [gebruikte families](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getfonts/) en informatie over [substituties/"onbekende" fonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsmanager/getsubstitutions/), wat helpt bij het plannen van de vervanging.

**Werkt lettertypevervanging bij het converteren naar PDF/afbeeldingen?**

Ja. Tijdens export past Aspose.Slides dezelfde [font selection/substitution sequence](/slides/nl/cpp/font-selection-sequence/) toe, zodat een vooraf uitgevoerde vervanging wordt gerespecteerd tijdens de conversie.

**Moet ik het doellettertype installeren op het systeem, of kan ik een lettertype‑map bijvoegen?**

Installatie is niet vereist: de bibliotheek staat [loading external fonts](/slides/nl/cpp/custom-font/) vanuit gebruikers‑mappen toe voor gebruik tijdens [rendering and export](/slides/nl/cpp/convert-powerpoint/).

**Zal vervanging het "tofu"‑probleem (vierkantjes) in plaats van tekens oplossen?**

Alleen als het doellettertype daadwerkelijk de benodigde glyfen bevat. Zo niet, [configure fallback](/slides/nl/cpp/fallback-font/) om de ontbrekende tekens te dekken.