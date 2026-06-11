---
title: Hantera punkt- och numrerade listor i presentationer i Python
linktitle: Hantera listor
type: docs
weight: 70
url: /sv/python-net/manage-lists/
keywords:
- punkt
- punklista
- numrerad lista
- symbolpunkt
- bildpunkt
- anpassad punkt
- flernivålista
- skapa punkt
- lägg till punkt
- lägg till lista
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar punkt-, bild-, flernivå- och numrerade listor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides för Python via .NET låter dig skapa och formatera punkt- och numrerade listor i PowerPoint‑ och OpenDocument‑presentationer. Ett listobjekt är ett stycke vars punktinställningar styrs via dess styckeformat.

Använd egenskapen [Paragraph.paragraph_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/paragraph_format/) för att komma åt listinställningar på styckennivå. Huvudinkörningspunkten är [ParagraphFormat.bullet](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/bullet/), som returnerar ett [BulletFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/)‑objekt. Med detta objekt kan du ange punkttyp, symbol, bild, färg, storlek, nummereringsstil och startnummer.

Den här artikeln visar hur man:

- skapa en punktlista med en anpassad symbol
- skapa en bildpunkt
- skapa en flernivålista genom att ange styckedjup
- skapa en numrerad lista
- inspektera och ändra listformat i en befintlig presentation

## **Skapa en punktlista**

För att skapa en punktlista, lägg till [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/)‑objekt i en [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) och ange [BulletFormat.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/type/) till [BulletType.SYMBOL](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bullettype/). Du kan sedan ange [BulletFormat.char](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/color/) och [BulletFormat.height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/height/) för att styra punktens utseende.

Följande Python‑kod demonstrerar hur man skapar en punktlista i en bild:

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

Resultatet:

![Symbolpunkterna](symbol_bullets.png)

## **Skapa en numrerad lista**

Använd numrerade listor när ordningen på objekt är viktig. Ange [BulletFormat.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/type/) till [BulletType.NUMBERED](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bullettype/). Du kan också välja ett nummereringsformat med [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/numbered_bullet_style/) eller ange [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) när listan ska börja med ett annat värde än 1.

Följande Python‑kod visar hur man skapar en numrerad lista i en bild:

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

Resultatet:

![Numrerade punkter](numbered_bullets.png)

## **Skapa en bildpunkt**

Aspose.Slides låter dig ersätta en vanlig punkt‑symbol med en bild. Bildpunkter fungerar bäst med enkla bilder som förblir läsbara i liten storlek, såsom ikoner eller små transparenta PNG‑filer.

{{% alert color="primary" %}}
Idealiskt, om du planerar att ersätta den vanliga punkt‑symbolen med en bild, är det bäst att välja en enkel grafik med transparent bakgrund. Sådana bilder fungerar bra som anpassade puntssymboler.

Tänk på att bilden kommer att skalas ner till en mycket liten storlek. Av den anledningen rekommenderar vi starkt att välja en bild som förblir tydlig och visuellt effektiv när den används som punkt i en lista.
{{% /alert %}}

För att skapa en bildpunkt, lägg till en bild i [Presentation.images](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/images/) och tilldela det returnerade bildobjektet till [BulletFormat.picture](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/picture/). Ange [BulletFormat.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/type/) till [BulletType.PICTURE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bullettype/) innan du tilldelar bilden.

Anta att vi har en "image.png":

![En bild för punkterna](picture_for_bullets.png)

Följande Python‑kod visar hur man skapar bildpunkter i en bild:

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

Resultatet:

![Bildpunkterna](picture_bullets.png)

## **Skapa en flernivålista**

Använd [ParagraphFormat.depth](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/depth/) för att placera listobjekt på olika nivåer. Nivå 0 är den översta nivån, nivå 1 är nästlad under den, och så vidare.

Följande Python‑kod visar hur man skapar en flernivå punktlista:

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

Resultatet:

![Flernivålistan](multilevel_list.png)

## **Ändra en befintlig lista**

För att ändra listformat i en befintlig presentation, hämta mål‑stycket och uppdatera dess [ParagraphFormat.bullet](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/bullet/)‑inställningar. Samma egenskaper som används för att skapa listor kan användas för att inspektera eller modifiera listor som lästs in från en PPT‑, PPTX‑ eller ODP‑fil.

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

**Kan punkt‑ och numrerade listor exporteras till PDF eller bilder?**

Ja. Aspose.Slides bevarar listformat när målformatet stöder motsvarande textlayout och punktfunktioner.

**Kan jag redigera listor i befintliga presentationer?**

Ja. Läs in presentationen, hämta mål‑stycket, inspektera eller uppdatera dess [ParagraphFormat.bullet](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/bullet/)‑inställningar och spara presentationen.

**Kan listor innehålla icke‑latinsk text?**

Ja. Listtext kan innehålla Unicode‑tecken, så du kan skapa listor i flerspråkiga presentationer. Se till att de teckensnitt som används i presentationen stödjer de tecken du behöver.