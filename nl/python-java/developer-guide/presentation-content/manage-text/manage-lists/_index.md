---
title: Beheer opsommingstekens en genummerde lijsten in presentaties met Python via Java
linktitle: Lijsten beheren
type: docs
weight: 60
url: /nl/python-java/manage-lists/
keywords:
- opsommingsteken
- opsommingslijst
- genummerde lijst
- symbool opsommingsteken
- afbeeldingsopsommingsteken
- aangepast opsommingsteken
- meerlagige lijst
- opsommingsteken maken
- opsommingsteken toevoegen
- lijst toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u opsommingslijsten, afbeeldingsopsommingstekens, meerlagige lijsten en genummerde lijsten kunt maken en opmaken in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides voor Python via Java stelt u in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint- en OpenDocument-presentaties. Een lijstitem is een alinea waarvan de opsommingstekeninstellingen worden geregeld via het alineaformaat.

Gebruik de [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/#getParagraphFormat) methode om lijstinstellingen op alinea-niveau te benaderen. Het belangrijkste toegangspunt is [ParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#getBullet), dat een [BulletFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/) object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming met een aangepast symbool maken
- een afbeeldingsopsomming maken
- een meerlagige lijst maken door de alinea-diepte in te stellen
- een genummerde lijst maken
- de lijstopmaak in een bestaande presentatie inspecteren en wijzigen

## **Een opsomming maken**

Om een opsomming te maken, voegt u [Paragraph](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraph/) objecten toe aan een [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) en stelt u [BulletFormat.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bullettype/#Symbol). Vervolgens kunt u [BulletFormat.setChar](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#getColor), en [BulletFormat.setHeight](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setHeight) gebruiken om het uiterlijk van het opsommingsteken te regelen.

De volgende Python-code toont hoe u een opsomming op een dia maakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De symbool opsommingstekens](symbol_bullets.png)

## **Een genummerde lijst maken**

Gebruik genummerde lijsten wanneer de volgorde van items belangrijk is. Stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bullettype/#Numbered). U kunt ook een nummeropmaak kiezen met [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) of [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) gebruiken wanneer de lijst op een andere waarde dan 1 moet beginnen.

De volgende Python-code laat zien hoe u een genummerde lijst op een dia maakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De genummerde opsommingstekens](numbered_bullets.png)

## **Een afbeelding-opsomming maken**

Aspose.Slides stelt u in staat om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldingsopsommingen werken het beste met eenvoudige afbeeldingen die ook op een kleine schaal leesbaar blijven, zoals pictogrammen of kleine transparante PNG‑bestanden.

{{% alert color="info" title="Opmerking" %}}
Als u van plan bent een regulier opsommingsteken te vervangen door een afbeelding, kies dan een eenvoudige grafiek met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Om een afbeelding-opsomming te maken, voegt u een afbeelding toe aan [Presentation.getImages](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getImages) en kent u het teruggegeven afbeeldingobject toe aan [BulletFormat.getPicture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#getPicture). Stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/python-java/aspose.slides/bullettype/#Picture) voordat u de afbeelding toewijst.

Stel dat we een afbeelding hebben met de naam "image.png":

![Een afbeelding voor de opsommingen](picture_for_bullets.png)

De volgende Python-code toont hoe u afbeeldingsopsommingen op een dia maakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De afbeeldingsopsommingen](picture_bullets.png)

## **Een meerlagige lijst maken**

Gebruik [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#setDepth) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het hoogste niveau, niveau 1 staat eronder genest, enzovoort.

De volgende Python-code laat zien hoe u een meerlagige opsomming maakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De meerlagige lijst](multilevel_list.png)

## **Een bestaande lijst wijzigen**

Om de lijstopmaak in een bestaande presentatie te wijzigen, krijgt u toegang tot de doelalinea en werkt u de [ParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#getBullet) instellingen bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen ook worden gebruikt om lijsten die uit een PPT‑, PPTX‑ of ODP‑bestand zijn geladen, te inspecteren of te wijzigen.

De volgende Python-code wijzigt de eerste alinea in een tekstvak zodat deze een genummerde lijststijl gebruikt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Kunnen opsomming- en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de overeenkomstige tekstlay-out en opsommingsteken‑functies ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, krijg toegang tot de doelalinea, inspecteer of werk de [ParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/python-java/aspose.slides/paragraphformat/#getBullet) instellingen bij, en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de lettertypen die in de presentatie worden gebruikt, de tekens die u nodig hebt, ondersteunen.