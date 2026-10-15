---
title: Hantera PowerPoint‑textstycken i Python
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- lägg till text
- lägg till stycke
- hantera text
- hantera stycke
- hantera punkt
- styckeindrag
- hängande indrag
- stycke‑punkt
- numrerad lista
- punktlista
- stycksegenskaper
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
description: "Lär dig hur du skapar och formaterar stycken, portioner, punkter, numrerade listor, indrag, HTML‑innehåll och stycke‑bilder med Aspose.Slides för Python via .NET."
---
## **Översikt**

Aspose.Slides för Python via .NET representerar text som en hierarki av textramar, stycken och portioner:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) representerar textbehållaren i en form och ger åtkomst till dess styckesamling.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) representerar ett stycke i en textram och ger åtkomst till dess portioner och formatering på styckennivå.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) representerar ett textkör i ett stycke. Varje portion kan ha sin egen text och teckenformatering.

Ett stycke kan därför innehålla text med olika typsnitt, färger, storlekar och annan formatering genom att använda flera portioner.

## **Skapa och formatera stycken**

Skapa stycken i en formas textram och använd portioner för att formatera enskilda textkör. Detta avsnitt visar hur du kombinerar flera portioner i varje stycke och tillämpar olika färger, teckenstorlekar och stilar.

### **Skapa stycken med flera portioner**

Följande Python‑exempel skapar tre stycken, var och en innehållande tre textkör i sin [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/)‑samling. Det återanvänder standardstycket och dess tomma portion, och lägger sedan till de återstående styckena och portionerna. Formatering appliceras via [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): den första portionen i varje stycke är röd, fet och 15 punkter; den andra är blå, kursiv och 18 punkter. Den tredje portionen behåller sin standardformatering:

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

Organisera stycketext i listor med symboler, siffror eller anpassade bilder. Exemplen i detta avsnitt täcker punktformatering, flernivållistor och anpassade startnummer.

### **Skapa en punkt- eller numrerad lista**

Punkter och numrering gör relaterade objekt enklare att skanna. I Aspose.Slides definieras listinställningar via [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Detta Python‑exempel lägger till en symbolpunkt och ett numrerat objekt i samma textram. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) väljer punkttypen, medan [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) anger symbolen och [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) väljer numreringsstil. Båda objekten använder svarta punkter med en höjd på 100 procent och ett styckeindrag på 25 punkter:

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

Bildpunkter låter dig använda en anpassad bild istället för en symbol eller siffra.

Exemplet kräver `bullets.png` i arbetskatalogen. Detta Python‑exempel lägger till en bild i presentationens bildsamling som en [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) och använder den som stycke‑punkt. Det sätter [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) till att använda en bildpunkt och tilldelar bilden via [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) sätts till 100 procent för att dimensionera punkten relativt stycketexten:

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

Sätt [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) för att placera stycken på olika nivåer i en lista. Top‑nivån har ett djup på `0`.

Detta Python‑exempel tilldelar [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/)‑värden från 0 till 3 till fyra stycken, vilket skapar en hierarki inom ett textram. Varje stycke använder en symbolpunkt, där [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) växlar mellan en rund punkt och ett bindestreck för att skilja på intilliggande nivåer:

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

### **Starta numrerade listobjekt med anpassade värden**

Använd [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) för att ange det initiala numret som visas för ett numrerat stycke.

Detta Python‑exempel sätter [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) till att använda numrering för tre stycken och tilldelar [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) värdena 2, 3 och 7. Startvärdet konfigureras separat för varje stycke, så att de visade siffrorna kan hoppa över värden:

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

## **Styr stycke‑layout och slut‑egenskaper**

Justera styckemarginaler och indrag för att kontrollera positionen för den första raden och omslagna rader. Du kan också formatera styckets slutmarkering separat från de synliga textportionerna.

### **Ange indrag för första raden**

Använd egenskapen [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) för att styra indraget för den första raden i ett stycke. Denna egenskap flyttar endast den första raden relativt styckets vänstra marginal. Ett positivt värde förskjuter den första raden åt höger, medan de återstående raderna förblir i linje med styckets kropp.

Använd [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) när du vill flytta hela stycket. Använd [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) när du bara vill flytta den första raden.

Följande exempel ger tre stycken samma [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) på 20 punkter och [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)‑värdena 0, 20 och 40 punkter. De första raderna startar vid successivt större avstånd, medan omslagna rader behåller samma vänstra marginal:

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

![Indrag för första raden i styckena](first_line_indent.png)

### **Ange hängande indrag**

Ett hängande indrag är en stycke‑layout där den första raden startar åt vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med egenskapen [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Sätt `indent` till ett negativt värde för att flytta den första raden åt vänster relativt styckets kropp.

I praktiken definierar [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) den vänstra positionen för styckets kropp, och [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, sätt ett positivt `margin_left`‑värde och ett negativt `indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, glossärsposter och andra stycken där omslagna rader måste anpassas under styckets kropp snarare än under den första tecknet i den första raden.

Följande Python‑exempel parar [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/)‑värdena 40 och 60 punkter med [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/)‑värdena ‑20 och ‑30 punkter. I varje stycke startar den första raden åt vänster om de omslagna raderna; det andra stycket har ett djupare hängande indrag:

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

![Det hängande indraget i styckena](hanging_indent.png)

### **Ange egenskaper för styckets slut‑kör**

Egenskapen [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) styr formateringen av styckets slutmarkering. Exemplet laddar `Test.pptx`, som måste innehålla minst en bild, och skapar ett [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) med [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) satt till 48 punkter och [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) satt till Times New Roman. Det tilldelar detta format till den andra styckets slutmarkering, utan att ändra de synliga textportionerna:

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

## **Räkna renderade rader**

För styckeregler som påverkar automatisk radbrytning och interpunktion vid radslut, se [Control Line Breaking](/slides/sv/python-net/text-formatting/#control-line-breaking) och [Control Hanging Punctuation](/slides/sv/python-net/text-formatting/#control-hanging-punctuation).

Använd [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) för att räkna raderna som ett stycke upptar efter textlayout, inklusive automatisk radbrytning. Detta är användbart när du kontrollerar textlängd och layout i presentationsmallar.

Ett stycke är ett objekt i [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), och det kan uppta flera renderade rader. Ett explicit radbrytningstecken inom ett stycke tvingar en ny rad utan att skapa ett nytt stycke. Automatisk radbrytning skapar rader baserat på tillgänglig bredd utan att infoga explicita radbrytningstecken i texten. Därför ger inte räkning av stycken eller radbrytningstecken den renderade radantalet.

Följande exempel skapar en textruta, räknar dess rader, förminskar rutan och ersätter sedan texten med en kortare sträng. Exemplet aktiverar [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) och inaktiverar [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) så att formens bredd styr radbrytning utan att automatiskt krympa texten eller ändra formens storlek. Varje mätning använder [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Formdimensioner anges i punkter. Slutligen lägger exemplet till ett ytterligare stycke och summerar radantalet över hela textramen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Med denna text och dessa dimensioner ökar radantalet när formen blir smalare, medan ersättningen med den korta strängen minskar det. Exakta tal kan variera beroende på typsnittstillgänglighet och substitution, teckenstorlek, marginaler, indrag, radbrytning och autofit‑inställningar. Använd de typsnitt och layoutinställningar som är avsedda för målmiljön när du granskar en mall.

Radantalet ensamt avgör inte om texten överskrider sin behållare. Tillgänglig höjd, radhöjder, stycke‑ och radavstånd samt autofit‑beteende spelar också roll; även en ensam rad kan överskrida den tillgängliga bredden när radbrytning är inaktiverad.

## **Import och export av stycke‑innehåll**

Använd HTML för att föra in text i en presentation eller exportera befintliga stycken för användning utanför den. Detta avsnitt visar också hur du renderar enskilda stycken som bilder, inklusive stycken i tabellceller.

### **Importera HTML‑text i stycken**

Använd [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) för att konvertera HTML‑markup till stycken och portioner i en textram.

Detta Python‑exempel läser HTML från `file.html` i arbetskatalogen och skickar markupen till [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Det rensar textrammens standardstycke så att ramen endast innehåller det importerade innehållet. Den rektangulära formen lämnar en marginal på 10 punkter på varje sida av bilden:

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

Använd [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) för att exportera ett valt intervall av stycken som HTML. När du återanvänder presentations‑text på en webbplats kan du vilja bevara lokal betoning utan att föra med dig presentationens typsnitt, storlek eller textrute‑stilar. Sätt [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) för att styra hur långt exportören följer formaterings‑ärvtagning.

Ladda ner [exempelpresentationen](text-inheritance.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller en textruta med texten "Inherited text; explicit red 18pt". Indatat använder avsiktligt flera formateringsnivåer:

- Presentationens standardtextstil använder Calibri och en storlek på 28 pt.
- Textrammens förstannivå‑textstil använder blå text och kursiv.
- Stycket sätter explicit fet stil.
- Den andra portionen, "explicit red 18pt", sätter explicit röd text och en storlek på 18 pt.

Följande kompletta exempel exporterar samma stycken tre gånger. Det skickar [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) till exportmetoden och skriver varje resultat till en separat UTF‑8‑HTML‑fil:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

Den genererade HTML‑koden innehåller följande CSS för den första portionen, "Inherited text; ". Tabellen listar de relevanta deklarationerna; andra genererade egenskaper har utelämnats för tydlighet.

| Utdata | Relevant CSS för den första delen | Utseende |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blå, fet, kursiv text på 28 pt i Calibri, om det typsnittet finns tillgängligt. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blå, fet, kursiv text; den omgivande sidan eller webbläsaren tillhandahåller typsnittsfamilj och storlek. |
| `ParagraphOnly.html` | `font-weight:bold` | Fet text; den omgivande sidan eller webbläsaren tillhandahåller typsnittsfamilj, storlek, färg och kursiv stil. |

Den andra delen behåller `color:#ff0000`, `font-size:18pt` och `font-weight:bold` i alla tre utdata. Den behåller också kursiv stil med `ALL` och `TEXT_BOX`, men inte med `PARAGRAPH_ONLY`. Att begränsa arv tar därför inte bort formatering som uttryckligen tilldelats ett stycke eller en portion.

Öppna filerna i samma webbläsare för att jämföra dem. I de två begränsade lägena fylls utelämnade CSS‑egenskaper i stilen för destinationssidan eller webbläsarens standarder, så det slutliga utseendet beror på var HTML‑koden används.

### **Rendera ett stycke som en bild**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) renderar ett enskilt stycke direkt och returnerar ett [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Spara resultatet till en fil eller ström med [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) kan returnera `None` om stycket inte kan hittas i sin föräldrasamling, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar och frigör den returnerade bilden efter användning.

#### **Rendera ett stycke i standardskala**

Exemplet använder `sample.pptx`, en presentation med en bild där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

Följande exempel väljer det andra stycket med index 1 och anropar [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) utan skala‑parametrar. Det kontrollerar att formen innehåller det erforderliga stycket och att renderingen returnerar en bild innan [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) anropas för att spara den som PNG. Kontext‑hanteraren frigör bildresurserna efter användning.

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

![Stycke‑bilden](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd överlagringen av [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) som accepterar parametrarna `scale_x` och `scale_y` för att ange horisontella och vertikala skalningsfaktorer. Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbel bredd och höjd, och sparar resultatet som en PNG‑bild.

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

En skalningsfaktor på `1` behåller den axeln i standardpixelstorlek. Till exempel ger `2` för båda faktorer en bild vars bredd och höjd är ungefär dubbelt så stora som standardmåtten, vilket ger fyra gånger så många pixlar. Större faktorer ger generellt skarpare text för zoomning eller högupplöst utskrift, men de ökar också minnes‑ och filstorlek. Faktorer under `1` ger mindre bilder med mindre detalj. Använd lika faktorer för att behålla styckets bildförhållande; olika horisontella och vertikala faktorer sträcker ut resultatet oberoende.

Att rendera en hel form med [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) är fortfarande användbart när outputen måste inkludera formens fyllning, kantlinje eller annan visuell kontext. För enbart en stycke‑bild, använd [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Sätt [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) till att inaktivera radbrytning så att raderna inte bryts vid textrammens kanter.

**Hur kan jag få de exakta på‑bild‑gränserna för ett specifikt stycke?**

Använd [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) för att hämta styckets omgivande rektangel. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) ger gränserna för en enskild portion.

**Var styrs styckejustering (vänster, höger, centrerad eller marginal) ?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) är en inställning på styckennivå och gäller hela stycket oavsett individuell portionsformatering.

För att vertikalt justera portioner med olika teckenstorlekar inom varje rad, se [Align Fonts Within a Line](/slides/sv/python-net/text-formatting/#align-fonts-within-a-line).

**Kan jag ange granskningsspråk för en del av ett stycke?**

Ja. Sätt [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) för enskilda portioner, så att ett stycke kan innehålla text på flera språk.