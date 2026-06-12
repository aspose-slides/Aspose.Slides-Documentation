---
title: Beheer opsommingstekens en genummerde lijsten in presentaties in Python
linktitle: Lijsten beheren
type: docs
weight: 70
url: /nl/python-net/manage-lists/
keywords:
- opsommingsteken
- opsomming
- genummerde lijst
- symbool opsommingsteken
- afbeelding opsommingsteken
- aangepast opsommingsteken
- meerlagige lijst
- opsomming maken
- opsomming toevoegen
- lijst toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u opsommingstekens, afbeelding‑opsommingen, meerlagige en genummerde lijsten kunt maken en opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides for Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET stelt u in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint‑ en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingstekeninstellingen worden geregeld via het alinea‑formaat.

Gebruik de eigenschap [Paragraph.paragraph_format](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/paragraph_format/) om lijstinstellingen op alinea‑niveau te benaderen. Het hoofdtoegangspunt is [ParagraphFormat.bullet](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/bullet/), dat een [BulletFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/)‑object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming met een aangepast symbool maakt
- een afbeelding als opsommingsteken maakt
- een meerlagige lijst maakt door de diepte van de alinea in te stellen
- een genummerde lijst maakt
- lijstopmaak in een bestaande presentatie inspecteert en wijzigt

## **Een opsomming maken**

Om een opsomming te maken, voegt u [Paragraph](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraph/)‑objecten toe aan een [TextFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/textframe/) en stelt u [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.SYMBOL](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/). Vervolgens kunt u [BulletFormat.char](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/color/) en [BulletFormat.height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/height/) instellen om het uiterlijk van het opsommingsteken te regelen.

De volgende Python‑code demonstreert hoe u een opsomming maakt in een dia:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De symboolopsommingen](symbol_bullets.png)

## **Een genummerde lijst maken**

Gebruik genummerde lijsten wanneer de volgorde van items van belang is. Stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.NUMBERED](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/). U kunt ook een nummeringsopmaak kiezen met [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/numbered_bullet_style/) of [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) instellen wanneer de lijst moet beginnen met een andere waarde dan 1.

De volgende Python‑code laat zien hoe u een genummerde lijst maakt in een dia:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De genummerde opsommingen](numbered_bullets.png)

## **Een afbeelding‑opsomming maken**

Aspose.Slides stelt u in staat om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingen werken het best met eenvoudige afbeeldingen die ook op een kleine grootte leesbaar blijven, zoals iconen of kleine transparante PNG‑bestanden.

{{% alert color="primary" %}}
Idealiter, als u van plan bent om het gewone opsommingsteken te vervangen door een afbeelding, is het het beste een eenvoudige afbeelding met een transparante achtergrond te kiezen. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.

Houd er rekening mee dat de afbeelding wordt verkleind tot een zeer kleine afmeting. Om die reden raden we sterk aan een afbeelding te kiezen die duidelijk en visueel effectief blijft wanneer deze als opsommingsteken in een lijst wordt gebruikt.
{{% /alert %}}

Om een afbeelding‑opsomming te maken, voegt u een afbeelding toe aan [Presentation.images](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/images/) en kent u het geretourneerde afbeeldingobject toe aan [BulletFormat.picture](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/picture/). Stel [BulletFormat.type](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bulletformat/type/) in op [BulletType.PICTURE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/bullettype/) voordat u de afbeelding toewijst.

Stel dat we een "image.png" hebben:

![Een afbeelding voor de opsommingen](picture_for_bullets.png)

De volgende Python‑code laat zien hoe u afbeelding‑opsommingen maakt in een dia:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De afbeelding‑opsommingen](picture_bullets.png)

## **Een meerlagige lijst maken**

Gebruik [ParagraphFormat.depth](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/depth/) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het hoogste niveau, niveau 1 wordt eronder genest, enzovoort.

De volgende Python‑code laat zien hoe u een meerlagige opsomming maakt:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Het resultaat:

![De meerlagige lijst](multilevel_list.png)

## **Een bestaande lijst wijzigen**

Om de lijstopmaak in een bestaande presentatie te wijzigen, krijgt u toegang tot de doel‑alinea en werkt u de instellingen van [ParagraphFormat.bullet](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/bullet/) bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen worden gebruikt om lijsten die uit een PPT, PPTX of ODP‑bestand zijn geladen, te inspecteren of te wijzigen.

De volgende Python‑code wijzigt de eerste alinea in een tekstframe zodat deze een genummerde lijststijl gebruikt:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kunnen opsommings‑ en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doel‑formaat de overeenkomstige tekstlay-out en opsommingsteken‑functies ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, krijg toegang tot de doel‑alinea, inspecteer of werk de instellingen van [ParagraphFormat.bullet](https://reference.aspose.com/slides/nl/python-net/aspose.slides/paragraphformat/bullet/) bij, en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de gebruikte lettertypen in de presentatie de benodigde tekens ondersteunen.