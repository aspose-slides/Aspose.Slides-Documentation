---
title: Beheer opsommingen en genummerde lijsten in presentaties met Python via Java
linktitle: Lijsten beheren
type: docs
weight: 60
url: /nl/python-java/manage-lists/
keywords:
- opsommingsteken
- opsomming
- genummerde lijst
- symbool-opsommingsteken
- afbeelding-opsommingsteken
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
description: "Leer hoe u opsommingen, afbeelding-opsommingstekens, meerlagige lijsten en genummerde lijsten kunt maken en opmaken in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Aspose.Slides for Python via Java stelt u in staat om opsomming‑ en genummerde lijsten te maken en op te maken in PowerPoint‑ en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de bullet‑instellingen worden beheerd via het alinea‑formaat.

Gebruik de methode [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) om de lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet), dat een [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/) object retourneert. Met dit object kunt u het type bullet, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming maken met een aangepast symbool
- een afbeelding‑opsommingsteken maken
- een meerlagige lijst maken door de alinearijpte in te stellen
- een genummerde lijst maken
- de lijstopmaak in een bestaande presentatie inspecteren en wijzigen
- de werkelijke lijstmarkeringen en nummers samen met de alinea‑tekst lezen

## **Maak een opsomming**

Om een opsomming te maken, voegt u [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) objecten toe aan een [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) en stelt u [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol). Vervolgens kunt u [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor) en [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) gebruiken om het uiterlijk van het opsommingsteken te regelen.

De volgende Python‑code toont hoe u een opsomming maakt op een dia:

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

![De symbool‑opsomming](symbol_bullets.png)

## **Maak een genummerde lijst**

Gebruik genummerde lijsten wanneer de volgorde van items van belang is. Stel [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered). U kunt ook een nummeringsformaat kiezen met [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) of [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) gebruiken wanneer de lijst moet beginnen bij een andere waarde dan 1.

De volgende Python‑code toont hoe u een genummerde lijst maakt op een dia:

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

## **Maak een afbeelding‑opsommingsteken**

Aspose.Slides maakt het mogelijk om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het beste met eenvoudige afbeeldingen die ook op een kleine grootte leesbaar blijven, zoals iconen of kleine transparante PNG‑bestanden.

{{% alert color="info" title="Note" %}}
Als u van plan bent een regulier opsommingsteken te vervangen door een afbeelding, kies dan een eenvoudige afbeelding met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Om een afbeelding‑opsommingsteken te maken, voegt u een afbeelding toe via [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) en kent u het geretourneerde afbeelding‑object toe aan [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture). Stel [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) in op [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) voordat u de afbeelding toewijst.

Stel dat we een afbeelding hebben met de naam "image.png":

![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende Python‑code toont hoe u afbeelding‑opsommingstekens maakt op een dia:

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

![De afbeelding‑opsommingstekens](picture_bullets.png)

## **Maak een meerlagige lijst**

Gebruik [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het hoogste niveau, niveau 1 staat eronder genest, enzovoort.

De volgende Python‑code toont hoe u een meerlagige opsomming maakt:

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

## **Wijzig een bestaande lijst**

Om de lijstopmaak in een bestaande presentatie te wijzigen, benadert u de doel‑alinea en werkt u de instellingen van [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen worden gebruikt om lijsten die zijn geladen uit een PPT, PPTX of ODP‑bestand te inspecteren of te wijzigen.

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

## **Lees de werkelijke opsommingsteken‑waarden**

Bij het extraheren van presentatietekst houdt u lijstmarkeringen naast de alinea‑tekst. Roep [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) aan en krijg `getBullet` om het effectieve opsommingsteken‑formaat te verkrijgen. Controleer `getType` voordat u `getActualBulletValue` leest.

Voor genummerde lijsten onderscheiden deze drie waarden:

- `getNumberedBulletStyle` bepaalt het formaat, bijvoorbeeld Arabische cijfers gevolgd door een punt of kleine letters gevolgd door een punt.
- `getNumberedBulletStartWith` geeft het startnummer op voor een groep genummerde alinea’s.
- `getActualBulletValue` retourneert de opgemaakte markering voor een specifieke alinea. Bijvoorbeeld, het tweede item in een lijst die begint bij 5 geeft `6.` terug.

Behoud [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) bij elke alinea om het nestingsniveau te behouden. De werkelijke markering codeert niet de volledige hiërarchie: een genest item kan `c.` teruggeven in plaats van een gecombineerd label zoals `6.c.`.

Het volgende zelfstandige voorbeeld maakt lijsten, slaat ze op in een presentatie en laadt de presentatie opnieuw om voor elke alinea de tekst, diepte, type opsommingsteken en werkelijke waarde te rapporteren. De kleine blauwe afbeelding‑markering wordt gemaakt uit inline SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Maak een afbeelding‑markering zonder een extern afbeeldingsbestand.
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

De bron‑lijsten worden hieronder weergegeven.

![Lijsten die beginnen bij 5, geneste letter‑ en Romeins‑nummer items, een symbool‑markering, een alinea zonder opsommingsteken, en een blauwe afbeelding‑markering](actual_bullet_values.png)

Het rapport komt overeen met de markeringen die in PowerPoint worden weergegeven:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

Voor [BulletType.None_ en BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/), `getActualBulletValue` retourneert `None` (Java `null`), niet een lege tekenreeks. Verwerk deze types afzonderlijk: de eerste heeft geen markering, terwijl de tweede vereist dat de bullet‑afbeelding apart wordt geëxtraheerd. Een afbeelding‑opsommingsteken kan niet uitsluitend worden gereproduceerd door een tekst‑markering te extraheren.

## **Veelgestelde vragen**

**Kunnen opsomming‑ en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de overeenkomstige tekstlay‑out en bullet‑functies ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, benader de doel‑alinea, inspecteer of werk de instellingen van [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet) bij en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de gebruikte lettertypen de benodigde tekens ondersteunen.