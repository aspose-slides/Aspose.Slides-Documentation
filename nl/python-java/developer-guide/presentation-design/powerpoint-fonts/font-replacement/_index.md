---
title: Versnel de vervanging van lettertypen in presentaties met Python via Java
linktitle: Lettertypevervanging
type: docs
weight: 60
url: /nl/python-java/font-replacement/
keywords:
- lettertype
- lettertype vervangen
- lettertypevervanging
- lettertype wijzigen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Vervang moeiteloos lettertypen in Aspose.Slides voor Python via Java om consistente typografie te garanderen in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Aspose.Slides stelt u in staat om een lettertype door een ander te vervangen in een hele presentatie. Wanneer een lettertype wordt vervangen, worden alle exemplaren van het oorspronkelijke lettertype gewijzigd in het nieuwe lettertype.

Om een lettertypevervanging uit te voeren, laadt u de presentatie, definieert u het bronlettertype en het vervangende lettertype, roept u de methode voor lettertypevervanging aan en slaat u de aangepaste presentatie op als een PPTX-bestand. Deze aanpak is handig wanneer u opzettelijk van de ene lettertypefamilie naar de andere wilt overschakelen in de hele presentatie.

## **Lettertypen vervangen**

Als u van gedachten verandert over het gebruik van een lettertype, kunt u dat lettertype door een ander vervangen. Alle exemplaren van het oude lettertype worden vervangen door het nieuwe lettertype.

Aspose.Slides stelt u in staat om een lettertype op deze manier te vervangen:

1. Laad de relevante presentatie.
2. Laad het lettertype dat vervangen zal worden.
3. Laad het nieuwe lettertype.
4. Vervang het lettertype.
5. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

Deze Python‑code demonstreert het vervangen van een lettertype:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat

# Laad een presentatie.
presentation = Presentation("Fonts.pptx")
try:
    # Laad het bronlettertype dat vervangen zal worden.
    source_font = FontData("Arial")

    # Laad het nieuwe lettertype.
    destination_font = FontData("Times New Roman")

    # Vervang het lettertype.
    presentation.getFontsManager().replaceFont(source_font, destination_font)

    # Sla de presentatie op.
    presentation.save("UpdatedFont_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Opmerking" color="info" %}} 
Om regels in te stellen die bepalen wat er gebeurt onder bepaalde voorwaarden (bijvoorbeeld als een lettertype niet toegankelijk is), zie [Lettertype‑substitutie](/slides/nl/python-java/font-substitution/). 
{{% /alert %}}

## **FAQ**

**Wat is het verschil tussen “lettertypevervanging”, “lettertype‑substitutie” en “fallback‑lettertypen”?**

Vervanging is een opzettelijke overschakeling van de ene familie naar de andere in het hele document. [Substitutie](/slides/nl/python-java/font-substitution/) is een regel als “als het lettertype niet beschikbaar is, gebruik X.” [Fallback](/slides/nl/python-java/fallback-font/) wordt toegepast op individuele ontbrekende tekens wanneer het baslettertype geïnstalleerd is maar niet de vereiste tekens bevat.

**Is vervanging van toepassing op master‑dia’s, lay‑outs, notities en opmerkingen?**

Ja. Vervanging heeft invloed op alle presentaties‑objecten die het oorspronkelijke lettertype gebruiken, inclusief master‑dia’s en notities; opmerkingen maken ook deel uit van het document en worden door de lettertype‑engine in acht genomen.

**Zal het lettertype binnen ingebedde OLE‑objecten (bijvoorbeeld Excel) veranderen?**

Nee. [OLE‑inhoud](/slides/nl/python-java/manage-ole/) wordt beheerd door de eigen toepassing. Vervanging in de presentatie herformatteert de interne OLE‑gegevens niet; deze kunnen worden weergegeven als een afbeelding of als extern bewerkbare inhoud.

**Kan ik een lettertype alleen in een deel van de presentatie vervangen (per dia of regio)?**

Gerichte vervanging is mogelijk als u het lettertype op het niveau van de benodigde objecten/bereiken wijzigt in plaats van een globale vervanging toe te passen op het gehele document. De algemene logica voor lettertype‑selectie tijdens het renderen blijft ongewijzigd.

**Hoe kan ik vooraf bepalen welke lettertypen de presentatie gebruikt?**

Gebruik de presentatie's [lettertype‑beheerder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/): hij biedt een lijst van de [gebruikte families](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getFonts) en informatie over [substituties/"onbekende" lettertypen](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontsmanager/#getSubstitutions), die helpt bij het plannen van de vervanging.

**Werkt lettertypevervanging bij het converteren naar PDF/afbeeldingen?**

Ja. Tijdens export past Aspose.Slides dezelfde [lettertype‑selectie‑/substitutie‑reeks](/slides/nl/python-java/font-selection-sequence/) toe, zodat een vooraf uitgevoerde vervanging wordt gerespecteerd bij de conversie.

**Moet ik het doellettertype in het systeem installeren, of kan ik een lettertype‑map bijvoegen?**

Installatie is niet vereist: de bibliotheek maakt het mogelijk om [externe lettertypen te laden](/slides/nl/python-java/custom-font/) vanuit gebruikersmappen voor gebruik tijdens [renderen en exporteren](/slides/nl/python-java/convert-powerpoint/).

**Zal vervanging “tofu” (vierkanten) in plaats van tekens verhelpen?**

Alleen als het doellettertype daadwerkelijk de vereiste tekens bevat. Zo niet, [fallback configureren](/slides/nl/python-java/fallback-font/) om de ontbrekende tekens te dekken.