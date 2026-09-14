---
title: Beheer lettertypen in presentaties met Python via Java
linktitle: Beheer lettertypen
type: docs
weight: 10
url: /nl/python-java/manage-fonts/
keywords:
- lettertypen beheren
- lettertype-eigenschappen
- alinea
- tekstopmaak
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheer lettertypen in Python via Java met Aspose.Slides: embed, vervang en laad aangepaste lettertypen om PPT-, PPTX- en ODP‑presentaties duidelijk, merkrecht en consistent te houden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lettertype‑eigenschappen in presentatietekst rechtstreeks vanuit uw code te beheren. U kunt toegang krijgen tot tekst in dia’s via vormen, tekstframes, alinea’s en delen, en vervolgens de opmaak op de geselecteerde tekst toepassen.

Dit artikel legt uit hoe u lettertype‑gerelateerde eigenschappen voor bestaande tekst in een presentatie kunt configureren, inclusief lettertypefamilie, vet en cursief, alinea‑uitlijning en letterkleur. Het laat ook zien hoe u een tekstvak maakt, er tekst aan toevoegt en lettertype‑eigenschappen zoals lettertypefamilie, vet, cursief, onderstrepen, lettergrootte en kleur instelt voordat u het resultaat opslaat als een PPTX‑bestand.

## **Lettertype‑gerelateerde eigenschappen beheren**
{{% alert color="info" title="Note" %}} 

Presentaties bevatten doorgaans zowel tekst als afbeeldingen. De tekst kan op verschillende manieren worden opgemaakt, bijvoorbeeld om specifieke secties en woorden te accentueren of om te voldoen aan de huisstijl. Tekstopmaak helpt gebruikers het uiterlijk van de presentatiewaarde te variëren. Dit artikel toont hoe u Aspose.Slides for Python via Java kunt gebruiken om de lettertype‑eigenschappen van alinea‑tekst op dia’s te configureren.

{{% /alert %}} 

Om de lettertype‑eigenschappen van een alinea te beheren met Aspose.Slides for Python via Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg een referentie naar een dia door de index te gebruiken.
1. Toegang tot de [Placeholder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/placeholder/)‑vormen in de dia als [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/).
1. Haal de [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) op uit het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) dat wordt blootgesteld door de [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/).
1. Stel de alinea uit.
1. Toegang tot de tekst‑[Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) van een [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/).
1. Definieer het lettertype met [FontData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fontdata/) en stel de **Font** van de tekst‑[Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) dienovereenkomstig in.
   1. Maak het lettertype vet.
   1. Maak het lettertype cursief.
1. Stel de letterkleur in met de [FillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/fillformat/) die wordt blootgesteld door het [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/)-object.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder. Het neemt een onbewerkte presentatie en past de lettertypen op een van de dia’s aan. De schermafbeeldingen hieronder tonen het invoerbestand en hoe de codefragmenten dit wijzigen. De code verandert het lettertype, de kleur en de lettertype‑stijl.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figuur: De tekst in het invoerbestand**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figuur: Dezelfde tekst met bijgewerkte opmaak**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Laad de presentatie.
presentation = Presentation("FontProperties.pptx")
try:
    # Toegang tot de eerste dia en de tekstframes van de eerste twee placeholder‑objecten.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Toegang tot de eerste alinea in elk tekstframe.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Toegang tot het eerste gedeelte in elke alinea.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Definieer en wijs nieuwe lettertypen toe.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Stel de lettertypen in op vet en cursief.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Stel de lettertypekleuren in.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Sla de presentatie op.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tekst‑lettertype‑eigenschappen instellen**
{{% alert color="info" title="Note" %}} 

Zoals vermeld in **Lettertype‑gerelateerde eigenschappen beheren**, wordt een [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) gebruikt om tekst met een gelijkaardige opmaakstijl in een alinea vast te houden. Dit artikel laat zien hoe u Aspose.Slides for Python via Java kunt gebruiken om een tekstvak met wat tekst te maken en vervolgens een specifiek lettertype en verschillende andere lettertype‑eigenschappen te definiëren.

{{% /alert %}} 

Om een tekstvak te maken en de lettertype‑eigenschappen van de tekst daarin in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
1. Verkrijg de referentie van een dia door de index te gebruiken.
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) van het type **Rectangle** toe aan de dia.
1. Verwijder de opvulstijl die is gekoppeld aan de [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/).
1. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) van de [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/).
1. Voeg wat tekst toe aan het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/).
1. Toegang tot het [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/)‑object dat is gekoppeld aan het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/).
1. Definieer het lettertype dat moet worden gebruikt voor de [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/).
1. Stel andere lettertype‑eigenschappen in, zoals vet, cursief, onderstrepen, kleur en hoogte, met behulp van de relevante eigenschappen die worden blootgesteld door het [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/)-object.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

De implementatie van de bovenstaande stappen staat hieronder.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figuur: Tekst met sommige lettertype‑eigenschappen ingesteld door Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Haal de eerste dia op en voeg een rechthoek toe.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Verwijder de opvulling van de vorm.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Voeg tekst toe aan het tekstframe van de vorm.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Stel de lettertypefamilie in.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Stel vet, cursief, onderstrepen en lettergrootte in.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Stel de letterkleur in.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Sla de presentatie op.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```