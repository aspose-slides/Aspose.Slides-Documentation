---
title: Superscript- en subscript beheren in presentaties met Python via Java
linktitle: Superscript en Subscript
type: docs
weight: 80
url: /nl/python-java/superscript-and-subscript/
keywords:
- superscript
- subscript
- superscript toevoegen
- subscript toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Beheers superscript en subscript in Aspose.Slides voor Python via Java en til uw presentaties naar een hoger niveau met professionele tekstopmaak voor maximaal effect."
---
## **Overzicht**

Aspose.Slides biedt mogelijkheden om superscript‑ en subscripttekst op te nemen in uw PowerPoint‑presentaties (PPT, PPTX) en OpenDocument‑presentaties (ODP). Of u nu chemische formules, wiskundige vergelijkingen wilt benadrukken of inhoud wilt voorzien van voetnoten, deze gespecialiseerde opmaakopties helpen duidelijkheid en precisie te behouden. In dit artikel leert u hoe u superscript‑ en subscriptstijlen naadloos toepast en professioneel resultaat behaalt in elke dia.

## **Superscript‑ en subscripttekst beheren**

U kunt superscript‑ en subscripttekst toevoegen aan elk gedeelte van een alinea. Om deze opmaak toe te passen in een Aspose.Slides‑tekstframe, gebruikt u de [setEscapement](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#setEscapement)‑methode van de [PortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/)‑klasse.

De escapement‑waarde varieert van -100 % (subscript) tot 100 % (superscript). Bijvoorbeeld:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.
- Haal een dia op op basis van zijn index.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) van het type [ShapeType.Rectangle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#Rectangle) toe aan de dia.
- Verkrijg het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) dat bij de [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) hoort.
- Wis de bestaande alinea’s.
- Maak een alinea aan om superscripttekst te bevatten en voeg deze toe aan de [paragraph collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getParagraphs) van het tekstframe.
- Maak een portion aan.
- Gebruik [setEscapement](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#setEscapement) om een waarde van 0 tot 100 in te stellen voor superscript (0 betekent geen superscript).
- Stel de tekst van de [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) in en voeg deze toe aan de portion‑collectie van de alinea.
- Maak een alinea aan om subscripttekst te bevatten en voeg deze toe aan de [paragraph collection](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#getParagraphs) van het tekstframe.
- Maak een portion aan.
- Gebruik [setEscapement](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/#setEscapement) om een waarde van -100 tot 0 in te stellen voor subscript (0 betekent geen subscript).
- Stel de tekst van de [Portion](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portion/) in en voeg deze toe aan de portion‑collectie van de alinea.
- Sla de presentatie op als een PPTX‑bestand.

Het volgende voorbeeld implementeert deze stappen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# Maak een presentatie aan.
presentation = Presentation()
try:
    # Haal de dia op.
    slide = presentation.getSlides().get_Item(0)

    # Maak een tekstvak aan.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Maak een alinea voor superscripttekst aan.
    superscript_paragraph = Paragraph()

    # Maak een gedeelte met normale tekst aan.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # Maak een gedeelte met superscripttekst aan.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # Maak een alinea voor subscripttekst aan.
    subscript_paragraph = Paragraph()

    # Maak een gedeelte met normale tekst aan.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # Maak een gedeelte met subscripttekst aan.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # Voeg de alinea's toe aan het tekstvak.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Worden superscript en subscript behouden bij het exporteren naar PDF of andere formaten?**

Ja, Aspose.Slides behoudt superscript‑ en subscriptopmaak correct bij het exporteren van presentaties naar PDF, PPT/PPTX, afbeeldingen en andere ondersteunde formaten. De gespecialiseerde opmaak blijft ongewijzigd in alle uitvoerbestanden.

**Kunnen superscript en subscript worden gecombineerd met andere opmaakstijlen zoals vet of cursief?**

Ja, Aspose.Slides laat u verschillende tekststijlen combineren binnen één portion tekst. U kunt vet, cursief, onderstrepen inschakelen en tegelijkertijd superscript of subscript toepassen door de overeenkomstige eigenschappen in [PortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/) te configureren.

**Werkt superscript en subscript op tekst binnen tabellen, grafieken of SmartArt?**

Ja, Aspose.Slides ondersteunt opmaak binnen de meeste objecten, inclusief tabellen en grafiekelementen. Bij het werken met SmartArt moet u de juiste elementen (zoals [SmartArtNode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnode/)) en hun tekstcontainers benaderen, en vervolgens de [PortionFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/portionformat/)‑eigenschappen op dezelfde manier configureren.