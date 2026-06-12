---
title: Versnel lettertypevervanging in presentaties met Python
linktitle: Lettertypevervanging
type: docs
weight: 60
url: /nl/python-net/font-replacement/
keywords:
- lettertype
- lettertype vervangen
- lettertypevervanging
- lettertype wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Vervang moeiteloos lettertypen in Aspose.Slides Python via .NET om consistente typografie te garanderen in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Met Aspose.Slides kunt u één lettertype door een ander vervangen in een hele presentatie. Wanneer een lettertype wordt vervangen, worden alle exemplaren van het oorspronkelijke lettertype gewijzigd naar het nieuwe lettertype.

Om een lettertypevervanging uit te voeren, laadt u de presentatie, definieert u het bronlettertype en het vervangingslettertype, roept u de vervangingsmethode aan en slaat u de gewijzigde presentatie op als een PPTX‑bestand. Deze aanpak is handig wanneer u bewust van de ene lettertypefamilie naar de andere wilt overschakelen in de hele presentatie.

## **Lettertypen vervangen**

Als u van gedachten verandert over het gebruik van een lettertype, kunt u dat lettertype vervangen door een ander. Alle exemplaren van het oude lettertype worden vervangen door het nieuwe lettertype. 

Aspose.Slides biedt de volgende werkwijze om een lettertype te vervangen:

1. Laad de betreffende presentatie. 
2. Laad het lettertype dat vervangen moet worden.
3. Laad het nieuwe lettertype. 
4. Vervang het lettertype. 
5. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze Python‑code toont hoe u lettertypen vervangt:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Laadt een presentatie
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Laadt het bronlettertype dat vervangen zal worden
    sourceFont = slides.FontData("Arial")

    # Laadt het nieuwe lettertype
    destFont = slides.FontData("Times New Roman")

    # Vervangt de lettertypen
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Slaat de presentatie op
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 
Om regels in te stellen die bepalen wat er gebeurt onder bepaalde omstandigheden (bijvoorbeeld als een lettertype niet toegankelijk is), zie [**Lettertypevervanging**](/slides/nl/python-net/font-substitution/). 
{{% /alert %}}

## **Veelgestelde vragen**

**Wat is het verschil tussen “lettertypevervanging”, “lettertype‑substitutie” en “fallback‑lettertypen”?**

Vervanging is een opzettelijke omschakeling van de ene familie naar de andere in het hele document. [Substitutie](/slides/nl/python-net/font-substitution/) is een regel als “als het lettertype niet beschikbaar is, gebruik X.” [Fallback](/slides/nl/python-net/fallback-font/) wordt chirurgisch toegepast voor individuele ontbrekende glyphs wanneer het basislettertype geïnstalleerd is, maar niet de vereiste tekens bevat.

**Is vervanging van toepassing op masterslides, lay‑outs, notities en opmerkingen?**

Ja. Vervanging beïnvloedt alle presentatie‑objecten die het oorspronkelijke lettertype gebruiken, inclusief masterslides en notities; opmerkingen maken ook deel uit van het document en worden meegenomen door de lettertype‑engine.

**Wordt het lettertype aangepast binnen ingebedde OLE‑objecten (bijvoorbeeld Excel)?**

Nee. [OLE‑inhoud](/slides/nl/python-net/manage-ole/) wordt beheerd door de eigen toepassing. Vervanging in de presentatie herschikt de interne OLE‑gegevens niet; ze kunnen worden weergegeven als afbeelding of als extern bewerkbare inhoud.

**Kan ik een lettertype alleen vervangen in een deel van de presentatie (per dia of regio)?**

Gerichte vervanging is mogelijk als u het lettertype wijzigt op het niveau van de benodigde objecten/bereiken in plaats van een globale vervanging toe te passen op het volledige document. De algehele logica voor lettertypekeuze tijdens renderen blijft ongewijzigd.

**Hoe kan ik van tevoren bepalen welke lettertypen de presentatie gebruikt?**

Gebruik de [font manager] van de presentatie (https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/): deze levert een lijst van de [gebruikte families]https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_fonts/ en informatie over [substitues/“onbekende” lettertypen]https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_substitutions/, wat helpt bij het plannen van de vervanging.

**Werkt lettertypevervanging bij conversie naar PDF/afbeeldingen?**

Ja. Tijdens export past Aspose.Slides dezelfde [lettertype‑selectie/substitutie‑sequentie](/slides/nl/python-net/font-selection-sequence/) toe, zodat een vooraf uitgevoerde vervanging gerespecteerd wordt bij de conversie.

**Moet ik het doellettertype installeren op het systeem, of kan ik een lettertype‑map bijvoegen?**

Installatie is niet nodig: de bibliotheek maakt het mogelijk om [externe lettertypen](/slides/nl/python-net/custom-font/) te laden uit gebruikers‑mappen voor gebruik tijdens [renderen en export](/slides/nl/python-net/convert-powerpoint/).

**Zal vervanging “tofu” (vierkanten) in plaats van tekens oplossen?**

Alleen als het doellettertype daadwerkelijk de vereiste glyphs bevat. Zo niet, configureer dan [fallback](/slides/nl/python-net/fallback-font/) om de ontbrekende tekens te dekken.