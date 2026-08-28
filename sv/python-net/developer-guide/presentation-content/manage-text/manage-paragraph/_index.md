---
title: Hantera PowerPoint-textstycken i Python
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- lägga till text
- lägga till stycke
- hantera text
- hantera stycke
- hantera punkt
- styckeindrag
- hängande indrag
- styckepunkt
- numrerad lista
- punktlista
- styckeegenskaper
- importera HTML
- text till HTML
- stycke till HTML
- stycke till bild
- text till bild
- exportera stycke
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, delar, punkter, numrerade listor, indrag, HTML-innehåll och stycke-bilder med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides för Python via .NET representerar text som en hierarki av textramar, stycken och delar:

* [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) representerar textbehållaren i en form och ger åtkomst till dess styckesamling.
* [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) representerar ett stycke i en textram och ger åtkomst till dess delar och formatering på styckesnivå.
* [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/) representerar ett textstycke inom ett stycke. Varje del kan ha sin egen text och teckenformatering.

Ett stycke kan därför innehålla text med olika teckensnitt, färger, storlekar och annan formatering genom att använda flera delar.

## **Skapa och formatera stycken**

### **Skapa stycken med flera delar**

Följande steg skapar en textram med tre stycken, var och en innehållande tre delar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Åtkomst till den relevanta bilden via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
4. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
5. Använd standardstycket och lägg till två ytterligare [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/)‑objekt i textramen.
6. Lägg till tillräckligt många [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/)‑objekt så att varje stycke innehåller tre delar. Standardstycket innehåller redan en tom del.
7. Ställ in texten för varje del.
8. Tillämpa teckenformatering via [Portion.portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/portion_format/).
9. Spara den ändrade presentationen.

Detta Python‑exempel implementerar stegen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Skapa punkt- och numrerade listor**

### **Skapa en punkt- eller numrerad lista**

Punkter och numrering gör relaterade objekt enklare att skanna. I Aspose.Slides definieras listinställningar via [BulletFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/).

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Åtkomst till den relevanta bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på den valda bilden.
4. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
5. Ta bort standardstycket från textramen.
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) för en symbolpunkt.
7. Ställ in [BulletFormat.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/type/) till [BulletType.SYMBOL](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bullettype/) och ange punkttecknet.
8. Ställ in styckets text, indrag, punktfärg och punktens höjd.
9. Lägg till stycket i textramen.
10. Skapa ett andra stycke och ställ in [BulletFormat.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/type/) till [BulletType.NUMBERED](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bullettype/).
11. Konfigurera den numrerade punktstilen och lägg till stycket i textramen.
12. Spara presentationen.

Detta Python‑exempel skapar en symbolpunkt och en numrerad punkt:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Använd bildpunkter**

Bildpunkter låter dig använda en anpassad bild i stället för en symbol eller siffra.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Åtkomst till den relevanta bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) och åtkomst till dess [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
4. Ta bort standardstycket från textramen.
5. Läs in punktbilden och lägg till den i presentationens bildsamling som en [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/).
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) och ange dess text.
7. Ställ in [BulletFormat.type](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/type/) till [BulletType.PICTURE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bullettype/).
8. Tilldela bilden via [BulletFormat.picture](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/picture/) och ställ in punktens höjd.
9. Lägg till stycket i textramen.
10. Spara den ändrade presentationen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Skapa en flernivålista**

Ställ in [ParagraphFormat.depth](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/depth/) för att placera stycken på olika nivåer i en lista. Översta nivån har djup `0`.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och åtkomst till en bild.
2. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) och rensa standardstycket från dess textram.
3. Skapa fyra stycken och konfigurera deras punkttecken.
4. Ställ in deras [ParagraphFormat.depth](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/depth/)‑värden till `0`, `1`, `2` och `3`.
5. Lägg till stycken i textramen och spara presentationen.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Starta numrerade listobjekt med egna värden**

Använd [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) för att ange det initiala talet som visas för ett numrerat stycke.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på en bild.
2. Rensa standardstycket från formens textram.
3. Skapa tre numrerade stycken.
4. Ställ in [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) till `2`, `3` och `7` för respektive stycke.
5. Lägg till stycken i textramen och spara presentationen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrollera styckeslayout och slutegenskaper**

### **Ställ in indrag för första raden**

Använd egenskapen [ParagraphFormat.indent](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/indent/) för att styra indraget för första raden i ett stycke. Denna egenskap flyttar endast den första raden i förhållande till styckets vänstermarginal. Ett positivt värde förskjuter den första raden åt höger, medan de resterande raderna förblir justerade med styckeskroppen.

Använd [ParagraphFormat.margin_left](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/margin_left/) när du behöver flytta hela stycket. Använd [ParagraphFormat.indent](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/indent/) när du bara vill flytta den första raden.

Exemplet nedan skapar flera stycken och tillämpar olika [ParagraphFormat.indent]-värden för att demonstrera hur indraget för första raden påverkar styckeslayouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Åtkomst till målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
4. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) och ta bort standardstycket.
5. Skapa flera stycken och sätt olika [ParagraphFormat.indent]-värden för dem.
6. Lägg till stycken i textramen.
7. Spara den ändrade presentationen.

Den här koden visar hur du ställer in ett styckeindrag:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Ställ in hängande indrag**

Ett hängande indrag är en styckeslayout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med egenskapen [ParagraphFormat.indent]. Sätt `indent` till ett negativt värde för att flytta den första raden åt vänster i förhållande till styckets kropp.

I praktiken definierar [ParagraphFormat.margin_left] den vänstra positionen för styckets kropp, och [ParagraphFormat.indent] definierar positionen för den första raden i förhållande till den marginalen. För att skapa ett hängande indrag, sätt ett positivt `margin_left`‑värde och ett negativt `indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, uppslagsverksposter och andra stycken där radbrytningar måste justeras under styckets kropp snarare än under första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Åtkomst till målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
4. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) och ta bort standardstycket.
5. Skapa stycken och sätt ett positivt [ParagraphFormat.margin_left]-värde för varje stycke.
6. Sätt ett negativt [ParagraphFormat.indent]-värde för att skapa hängande indrag.
7. Lägg till stycken i textramen.
8. Spara den ändrade presentationen.

Den här koden visar hur du sätter ett hängande indrag för ett stycke:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Ställ in slutegenskaper för styckekörning**

Egenskapen [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) styr formateringen av styckets slutmarkering. Följande exempel tilldelar en teckenstorlek och ett latinskt teckensnitt till slutmarkeringen för det andra stycket:

1. Läs in en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och åtkomst till en bild.
2. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) och rensa dess standardstycke.
3. Skapa två stycken och lägg till textdelar i dem.
4. Skapa ett [PortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/) för det andra styckets slutmarkering.
5. Ställ in [PortionFormat.font_height](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/font_height/) och [PortionFormat.latin_font](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/latin_font/).
6. Tilldela formatet till [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) och spara presentationen.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Importera och exportera styckeinnehåll**

### **Importera HTML‑text i stycken**

Använd [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphcollection/add_from_html/) för att konvertera HTML‑markup till stycken och delar i en textram.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Åtkomst till en bild och lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/).
3. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) och rensa dess standardstycke.
4. Läs in käll‑HTML‑filen.
5. Skicka HTML‑strängen till [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Spara den ändrade presentationen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Exportera stycketext till HTML**

Använd [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphcollection/export_to_html/) för att exportera ett valt intervall av stycken som HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och läs in önskad presentation.
2. Åtkomst till bilden och hitta den [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) som innehåller texten.
3. Åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
4. Anropa [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphcollection/export_to_html/) med start‑styckeindexet och antalet stycken att exportera.
5. Skriv den returnerade HTML‑strängen till en fil.

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Rendera ett stycke som en bild**

[Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) tillhandahåller metoden `get_image` för att rendera ett enskilt stycke direkt. Metoden returnerar ett [IImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/) som du kan spara till en fil eller ström med [IImage.save](https://reference.aspose.com/slides/sv/python-net/aspose.slides/iimage/save/). Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

`get_image`‑metoden kan returnera `None` om stycket inte kan hittas i sin föräldrakollektion, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan det sparas och använd den returnerade bilden som en context manager för att frigöra dess resurser.

#### **Rendera ett stycke i standardskala**

Anta att vi har en presentationsfil som heter sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![The text box with three paragraphs](paragraph_to_image_input.png)

Följande exempel renderar det andra stycket i en vanlig textruta i standardskala och sparar den returnerade bilden i PNG‑format:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Resultatet:

![The paragraph image](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Skicka horisontella och vertikala skalningsfaktorer till `get_image` för att kontrollera storleken på det renderade stycket. Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbelt så stor bredd och höjd som standard, och sparar resultatet som en PNG‑bild:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

En skalningsfaktor på `1` behåller den axeln på dess standardpixelstorlek. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standardmåtten, vilket resulterar i fyra gånger så många pixlar. Större faktorer ger vanligtvis skarpare text för zoomning eller högupplöst utskrift, men de ökar även minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detaljrikedom. Använd lika faktorer för att bevara styckets bildförhållande; olika horisontella och vertikala faktorer sträcker ut resultatet var för sig.

Att rendera en hel form med [Shape.get_image](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/) är fortsatt användbart när utdata måste inkludera formens fyllning, kant eller annan visuell kontext. För en bild som bara innehåller ett stycke, använd `Paragraph.get_image`.

## **Vanliga frågor**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Ställ in [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/wrap_text/) för att inaktivera radbrytning så att rader inte bryts vid textrammens kanter.

**Hur får jag de exakta gränserna på bilden för ett specifikt stycke?**

Använd [Paragraph.get_rect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/get_rect/) för att hämta styckets omslutande rektangel. [Portion.get_rect](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/get_rect/) ger gränserna för en enskild del.

**Var styrs styckejustering (vänster, höger, centrerad eller marginaljustering)?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/alignment/) är en inställning på styckesnivå och tillämpas på hela stycket oavsett individuell delformatering.

**Kan jag ange korrekturspråk för en del av ett stycke?**

Ja. Ställ in [PortionFormat.language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/language_id/) för enskilda delar, så att ett stycke kan innehålla text på flera språk.