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

Aspose.Slides för Python via Java låter dig skapa och formatera punktlistor och numrerade listor i PowerPoint- och OpenDocument-presentationer. Ett listobjekt är ett stycke vars punkteinställningar styrs via dess styckeformat.

Använd metoden [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/#getParagraphFormat) för att komma åt listinställningar på styckennivå. Huvudinkomstpunkten är [ParagraphFormat.getBullet](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#getBullet), som returnerar ett [BulletFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/)‑objekt. Med detta objekt kan du ange punktens typ, symbol, bild, färg, storlek, numreringsstil och startnummer.

Den här artikeln visar hur du:

- skapar en punktlista med en anpassad symbol
- skapar en bildpunkt
- skapar en flernivålista genom att ange styckedsdjup
- skapar en numrerad lista
- inspekterar och ändrar listformatering i en befintlig presentation

## **Skapa en punktlista**

För att skapa en punktlista, lägg till [Paragraph](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraph/)‑objekt i ett [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) och ange [BulletFormat.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Symbol](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bullettype/#Symbol). Du kan sedan använda [BulletFormat.setChar](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#getColor) och [BulletFormat.setHeight](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setHeight) för att styra punktens utseende.

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

![Symbolpunkter](symbol_bullets.png)

## **Skapa en numrerad lista**

Använd numrerade listor när ordningen på objekten är viktig. Ange [BulletFormat.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Numbered](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bullettype/#Numbered). Du kan också välja ett nummerformat med [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) eller använda [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) när listan ska börja med ett annat värde än 1.

Följande Python‑kod visar hur du skapar en numrerad lista på en bild:

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

## **Skapa en bildpunkt**

Aspose.Slides låter dig ersätta en vanlig punkt‑symbol med en bild. Bildpunkter fungerar bäst med enkla bilder som förblir läsbara i liten storlek, såsom ikoner eller små transparenta PNG‑filer.

{{% alert color="info" title="Note" %}}
Om du planerar att ersätta en vanlig punkt‑symbol med en bild, välj en enkel grafik med transparent bakgrund. Sådana bilder fungerar bra som anpassade punkt‑symboler.

Kom ihåg att bilden kommer att skalas ner till en mycket liten storlek. Av den anledningen rekommenderar vi starkt att du väljer en bild som förblir tydlig och visuellt effektiv när den används som punkt i en lista.
{{% /alert %}}

För att skapa en bildpunkt, lägg till en bild i [Presentation.getImages](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getImages) och tilldela det returnerade bildobjektet till [BulletFormat.getPicture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#getPicture). Ange [BulletFormat.setType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bulletformat/#setType) till [BulletType.Picture](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bullettype/#Picture) innan du tilldelar bilden.

Antag att vi har en bild som heter "image.png":

![En bild för punkterna](picture_for_bullets.png)

Följande Python‑kod visar hur man skapar bildpunkter på en bild:

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

![Bildpunkter](picture_bullets.png)

## **Skapa en flernivålista**

Använd [ParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#setDepth) för att placera listobjekt på olika nivåer. Nivå 0 är den översta nivån, nivå 1 är indenterad under den, och så vidare.

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

![Flernivålistan](multilevel_list.png)

## **Ändra en befintlig lista**

För att ändra listformatering i en befintlig presentation, nå det aktuella stycket och uppdatera dess [ParagraphFormat.getBullet](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#getBullet)‑inställningar. Samma egenskaper som används för att skapa listor kan användas för att inspektera eller modifiera listor som lästs in från en PPT-, PPTX- eller ODP‑fil.

Följande Python‑kod ändrar det första stycket i en textram till att använda en numrerad liststil:

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

## **Vanliga frågor**

**Kan punkt- och numrerade listor exporteras till PDF eller bilder?**

Ja. Aspose.Slides bevarar listformatering när målformatet stöder motsvarande textlayout och punktfunktioner.

**Kan jag redigera listor i befintliga presentationer?**

Ja. Läs in presentationen, nå det aktuella stycket, inspektera eller uppdatera dess [ParagraphFormat.getBullet](https://reference.aspose.com/slides/sv/python-java/aspose.slides/paragraphformat/#getBullet)‑inställningar och spara presentationen.

**Kan listor innehålla icke‑latinsk text?**

Ja. Text i listobjekt kan innehålla Unicode‑tecken, så du kan skapa listor i flerspråkiga presentationer. Se till att de teckensnitt som används i presentationen stöder de tecken du behöver.