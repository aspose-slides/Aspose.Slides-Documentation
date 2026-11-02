---
title: Hantera punkt- och numrerade listor i presentationer med Python via Java
linktitle: Hantera listor
type: docs
weight: 60
url: /sv/python-java/manage-lists/
keywords:
- punkt
- punktlista
- numrerad lista
- symbolpunkt
- bildpunkt
- anpassad punkt
- flernivålista
- skapa punkt
- lägga till punkt
- lägga till lista
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar punktlistor, bildpunkter, flernivålistor och numrerade listor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via Java."
---
## **Översikt**

Aspose.Slides för Python via Java låter dig skapa och formatera punktlistor och numrerade listor i PowerPoint- och OpenDocument-presentationer. Ett listobjekt är ett stycke vars bulletinställningar styrs via dess styckeformat.

Använd metoden [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) för att komma åt listinställningar på stycketnivå. Huvudentrén är [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet), som returnerar ett [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/)‑objekt. Med detta objekt kan du ange bullet‑typen, symbolen, bilden, färgen, storleken, numreringsstilen och startnumret.

Denna artikel visar hur man:

- skapa en punktlista med en anpassad symbol
- skapa en bildbullet
- skapa en flernivålista genom att ange styckets djup
- skapa en numrerad lista
- granska och ändra listformatering i en befintlig presentation
- läsa faktiska listmarkörer och siffror tillsammans med stycketexten

## **Skapa en punktlista**

För att skapa en punktlista, lägg till [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/)‑objekt i en [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) och sätt [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol). Du kan sedan använda [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor), och [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight) för att styra bulletens utseende.

Följande Python‑kod demonstrerar hur man skapar en punktlista på en bild:

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

Resultatet:

![Symbol‑punkter](symbol_bullets.png)

## **Skapa en numrerad lista**

Använd numrerade listor när ordningen på objekten är viktig. Sätt [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered). Du kan också välja ett numreringsformat med [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) eller använda [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) när listan ska börja på ett annat värde än 1.

Följande Python‑kod visar hur man skapar en numrerad lista på en bild:

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

Resultatet:

![Numrerade punkter](numbered_bullets.png)

## **Skapa en bildbullet**

Aspose.Slides låter dig ersätta en vanlig bulletsymbol med en bild. Bildbullets fungerar bäst med enkla bilder som förblir läsbara i liten storlek, såsom ikoner eller små transparenta PNG‑filer.

{{% alert color="info" title="Note" %}}
Om du planerar att ersätta en vanlig bulletsymbol med en bild, välj en enkel grafik med transparent bakgrund. Sådana bilder fungerar bra som anpassade bulletsymboler.

Tänk på att bilden kommer att skalas ner till en mycket liten storlek. Av den anledningen rekommenderar vi starkt att välja en bild som förblir tydlig och visuellt effektiv när den används som bullet i en lista.
{{% /alert %}}

För att skapa en bildbullet, lägg till en bild i [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages) och tilldela det returnerade bildobjektet till [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture). Sätt [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) innan du tilldelar bilden.

Anta att vi har en bild med namn "image.png":

![En bild för bullets](picture_for_bullets.png)

Följande Python‑kod visar hur man skapar bildbullets på en bild:

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

Resultatet:

![Bildbullets](picture_bullets.png)

## **Skapa en flernivålista**

Använd [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) för att placera listobjekt på olika nivåer. Nivå 0 är toppraden, nivå 1 är inbäddad under den, och så vidare.

Följande Python‑kod visar hur man skapar en flernivåpunktlista:

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

Resultatet:

![Flernivålista](multilevel_list.png)

## **Ändra en befintlig lista**

För att ändra listformatering i en befintlig presentation, få åtkomst till målstycket och uppdatera dess [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet)‑inställningar. Samma egenskaper som används för att skapa listor kan användas för att granska eller ändra listor som laddats från en PPT‑, PPTX‑ eller ODP‑fil.

Följande Python‑kod ändrar det första stycket i en textram för att använda en numrerad liststil:

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

## **Läs faktiska bullet‑värden**

När du extraherar presentationsinnehåll, behåll listmarkörer tillsammans med stycketexten. Anropa [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective) och få åtkomst till `getBullet` för att erhålla det effektiva bullet‑formatet. Kontrollera dess `getType` innan du läser `getActualBulletValue`.

För numrerade listor, skilj på dessa tre värden:

- `getNumberedBulletStyle` bestämmer formatet, till exempel arabiska siffror följda av en punkt eller gemena bokstäver följda av en punkt.
- `getNumberedBulletStartWith` anger startnumret för en grupp numrerade stycken.
- `getActualBulletValue` returnerar den formaterade markören för ett specifikt stycke. Till exempel returnerar det andra objektet i en lista som startar vid 5 `6.`.

Bevara [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth) för varje stycke för att behålla dess nästlingsnivå. Den faktiska markören kodar inte hela hierarkin: ett nästlat objekt kan returnera `c.` istället för en kombinerad etikett som `6.c.`.

Följande självständiga exempel skapar listor, sparar dem till en presentation och laddar om presentationen för att rapportera varje styckes text, djup, bullet‑typ och faktiska värde. Den lilla blå bildmarkören skapas från inbäddad SVG.

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

    # Skapa en bildmarkör utan en extern bildfil.
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

Källistorna visas nedan.

![Listor som startar vid 5, nästlade bokstavs- och romartalsobjekt, en symbolmarkör, ett stycke utan bullet och en blå bildmarkör](actual_bullet_values.png)

Rapporten matchar de markörer som visas i PowerPoint:

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

För [BulletType.None_ and BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/) returnerar `getActualBulletValue` `None` (Java `null`), inte en tom sträng. Hantera dessa typer separat: den förra har ingen markör, medan den senare kräver att bullet‑bilden extraheras separat. En bildbullet kan inte reproduceras enbart genom att extrahera en textmarkör.

## **FAQ**

**Kan punktlistor och numrerade listor exporteras till PDF eller bilder?**

Ja. Aspose.Slides bevarar listformatering när målformatet stöder motsvarande textlayout och bullet‑funktioner.

**Kan jag redigera listor i befintliga presentationer?**

Ja. Ladda presentationen, få åtkomst till målstycket, granska eller uppdatera dess [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet)‑inställningar och spara presentationen.

**Kan listor innehålla icke‑latinsk text?**

Ja. Listobjekt kan innehålla Unicode‑tecken, så du kan skapa listor i flerspråkiga presentationer. Se till att de teckensnitt som används i presentationen stödjer de tecken du behöver.