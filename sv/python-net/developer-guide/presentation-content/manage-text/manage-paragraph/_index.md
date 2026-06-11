---
title: Hantera PowerPoint‑textparagrafer i Python
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/python-net/manage-paragraph/
keywords:
- lägga till text
- lägg till stycke
- hantera text
- hantera stycke
- hantera punkt
- styckeindrag
- hängande indrag
- styckepunkt
- numrerad lista
- punktlista
- styckegenskaper
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
description: "Bemästra styckeformatering med Aspose.Slides för Python via .NET — optimera justering, avstånd och stil i PowerPoint- och OpenDocument‑presentationer i Python för att engagera tittarna."
---
## **Introduktion**

Aspose.Slides tillhandahåller de klasser du behöver för att arbeta med PowerPoint‑text i Python.

* Aspose.Slides tillhandahåller klassen [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) för att skapa textram‑objekt. Ett `TextFrame`‑objekt kan innehålla ett eller flera stycken (varje stycke är separerat av ett radbrytningstecken).
* Aspose.Slides tillhandahåller klassen [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) för att skapa stycke‑objekt. Ett `Paragraph`‑objekt kan innehålla ett eller flera textportioner.
* Aspose.Slides tillhandahåller klassen [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/) för att skapa textportion‑objekt och ange deras formaterings‑egenskaper.

Ett `Paragraph`‑objekt kan hantera text med olika formaterings‑egenskaper genom sina underliggande `Portion`‑objekt.

## **Lägg till flera stycken som innehåller flera portioner**

Stegen nedan visar hur du lägger till en textram som innehåller tre stycken, var och en med tre portioner:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Hämta en referens till mål‑bilden genom dess index.
1. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Hämta den [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/).
1. Skapa två [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/)‑objekt och lägg till dem i paragraf‑samlingen för [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) (tillsammans med standard‑stycket ger detta tre stycken).
1. För varje stycke, skapa tre [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/)‑objekt och lägg till dem i styckets portionssamling.
1. Ställ in texten för varje portion.
1. Applicera önskad formatering på varje textportion med hjälp av egenskaperna som exponeras av [Portion](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portion/).
1. Spara den modifierade presentationen.

Följande Python‑kod implementerar dessa steg:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiera Presentation-klassen för att skapa en ny PPTX-fil.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till en rektangulär AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Hämta AutoShape:s TextFrame.
    text_frame = shape.text_frame

    # Skapa stycken och portioner; formatering tillämpas nedan.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Spara PPTX-filen till disk.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hantera styckepunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Stycken med punkter är ofta lättare att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Få åtkomst till mål‑bilden via dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Få åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) för formen.
1. Ta bort standard‑stycket från [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
1. Skapa det första stycket med klassen [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/).
1. Ställ in styckets punkt‑typ till `SYMBOL` och ange punkttecknet.
1. Ställ in styckets text.
1. Ställ in punkt‑indrag för stycket.
1. Ställ in punktens färg.
1. Ställ in punktens storlek (höjd).
1. Lägg till stycket i [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/)s paragraf‑samling.
1. Lägg till ett andra stycke och upprepa steg 7–12.
1. Spara presentationen.

Denna Python‑kod visar hur man lägger till stycken med punkter:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en presentationinstans.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Lägg till och hämta en AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Hämta textramen för den skapade AutoShape.
    text_frame = shape.text_frame

    # Ta bort standardstycket.
    text_frame.paragraphs.remove_at(0)

    # Skapa ett stycke.
    paragraph = slides.Paragraph()

    # Ställ in styckets punktstil och -symbol.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Ställ in styckets text.
    paragraph.text = "Welcome to Aspose.Slides"

    # Ställ in punktindraget.
    paragraph.paragraph_format.indent = 25

    # Ställ in punktfärgen.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # Ställ in punktens höjd.
    paragraph.paragraph_format.bullet.height = 100

    # Lägg till stycket i textramen.
    text_frame.paragraphs.add(paragraph)

    # Skapa det andra stycket.
    paragraph2 = slides.Paragraph()

    # Ställ in styckets punkt‑typ och stil.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # Ställ in styckets text.
    paragraph2.text = "This is numbered bullet"

    # Ställ in punktindraget.
    paragraph2.paragraph_format.indent = 25

    # Ställ in punktfärgen.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # Ställ in punktens höjd.
    paragraph2.paragraph_format.bullet.height = 100

    # Lägg till stycket i textramen.
    text_frame.paragraphs.add(paragraph2)

    # Spara presentationen som en PPTX‑fil.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hantera bildpunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Bildpunkter är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Få åtkomst till mål‑bilden via dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Få åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) för formen.
1. Ta bort standard‑stycket från [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
1. Skapa det första stycket med klassen [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/).
1. Läs in en bild i en [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/).
1. Ställ in punkt‑typen till [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) och tilldela bilden.
1. Ställ in styckets text.
1. Ställ in styckets indrag för punkten.
1. Ställ in punktens färg.
1. Ställ in punktens höjd.
1. Lägg till det nya stycket i [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/)s paragraf‑samling.
1. Lägg till ett andra stycke och upprepa steg 8–12.
1. Spara presentationen.

Denna Python‑kod visar hur man lägger till och hanterar bildpunkter:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]

    # Läs in punktbilden.
    image = draw.Bitmap("bullets.png")
    pp_image = presentation.images.add_image(image)

    # Lägg till och hämta en AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Hämta TextFrame för den skapade AutoShape.
    text_frame = auto_shape.text_frame

    # Ta bort standardstycket.
    text_frame.paragraphs.remove_at(0)

    # Skapa ett nytt stycke.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Ställ in styckets punkt‑typ till Bild och tilldela bilden.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Ställ in punktens höjd.
    paragraph.paragraph_format.bullet.height = 100

    # Lägg till stycket i textramen.
    text_frame.paragraphs.add(paragraph)

    # Spara presentationen som en PPTX‑fil.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Spara presentationen som en PPT‑fil.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Hantera flernivåpunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Flernivåpunkter är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Få åtkomst till mål‑bilden via dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Få åtkomst till [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/)s [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
1. Ta bort standard‑stycket från [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
1. Skapa det första stycket med klassen [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) och sätt dess djup till 0.
1. Skapa det andra stycket med klassen [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) och sätt dess djup till 1.
1. Skapa det tredje stycket med klassen [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) och sätt dess djup till 2.
1. Skapa det fjärde stycket med klassen [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) och sätt dess djup till 3.
1. Lägg till de nya styckena i [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/)s paragraf‑samling.
1. Spara presentationen.

Följande Python‑kod visar hur man lägger till och hanterar flernivåpunkter:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Skapa en presentationinstans.
with slides.Presentation() as presentation:

    # Hämta den första bilden.
    slide = presentation.slides[0]
    
    # Lägg till en AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Hämta TextFrame för den skapade AutoShape.
    text_frame = auto_shape.text_frame
    
    # Rensa standardstycket.
    text_frame.paragraphs.clear()

    # Lägg till det första stycket.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ställ in punktnivån.
    paragraph1.paragraph_format.depth = 0

    # Lägg till det andra stycket.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ställ in punktnivån.
    paragraph2.paragraph_format.depth = 1

    # Lägg till det tredje stycket.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ställ in punktnivån.
    paragraph3.paragraph_format.depth = 2

    # Lägg till det fjärde stycket.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Ställ in punktnivån.
    paragraph4.paragraph_format.depth = 3

    # Lägg till styckena i samlingen.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Spara presentationen som en PPTX‑fil.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hantera stycken med anpassade numrerade listor**

Klassen [BulletFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/bulletformat/) tillhandahåller egenskapen `numbered_bullet_start_with` (och andra) för att kontrollera anpassad numrering och formatering av stycken.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Få åtkomst till bilden som ska innehålla styckena.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Få åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) för formen.
1. Ta bort standard‑stycket från [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
1. Skapa det första [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) och sätt `numbered_bullet_start_with` till 2.
1. Skapa det andra [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) och sätt `numbered_bullet_start_with` till 3.
1. Skapa det tredje [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/) och sätt `numbered_bullet_start_with` till 7.
1. Lägg till styckena i [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/)s samling.
1. Spara presentationen.

Följande Python‑kod demonstrerar hur man lägger till och hanterar stycken med anpassad numrering och formatering.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Lägg till och hämta en AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Hämta TextFrame för den skapade AutoShape.
    text_frame = shape.text_frame

    # Ta bort det befintliga standardstycket.
    text_frame.paragraphs.remove_at(0)

    # Skapa det första numrerade objektet (starta med 2, djupnivå 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Skapa det andra numrerade objektet (starta med 3, djupnivå 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Skapa det tredje numrerade objektet (starta med 7, djupnivå 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ställ in första‑rad‑indrag för ett stycke**

Använd egenskapen [ParagraphFormat.indent](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/indent/) för att kontrollera första‑rad‑indraget för ett stycke. Denna egenskap flyttar endast den första raden i förhållande till styckets vänstra marginal. Ett positivt värde flyttar den första raden åt höger, medan de återstående raderna förblir justerade till styckeskroppen.

Använd [ParagraphFormat.margin_left](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/margin_left/) när du behöver flytta hela stycket. Använd [ParagraphFormat.indent](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/indent/) när du bara vill flytta den första raden.

Exemplet nedan skapar flera stycken och tillämpar olika `indent`‑värden för att demonstrera hur första‑rad‑indraget påverkar stycke‑layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Få åtkomst till mål‑bilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) till formen och ta bort standard‑stycket.
5. Skapa flera stycken och sätt olika [indent](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/indent/)‑värden för dem.
6. Lägg till styckena i textramen.
7. Spara den modifierade presentationen.

Denna kod visar hur man ställer in ett stycke‑indrag:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Den första radens indrag i styckena](first_line_indent.png)

## **Ställ in hängande indrag för ett stycke**

Ett hängande indrag är en stycke‑layout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med egenskapen [ParagraphFormat.indent](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/indent/). Ställ in `indent` till ett negativt värde för att flytta den första raden åt vänster i förhållande till styckeskroppen.

Praktiskt definierar [ParagraphFormat.margin_left](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/margin_left/) den vänstra positionen för stycketskroppen, och [ParagraphFormat.indent](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/indent/) definierar positionen för den första raden i förhållande till den marginalen. För att skapa ett hängande indrag, sätt ett positivt `margin_left`‑värde och ett negativt `indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, förklaringar och andra stycken där radbrytningar ska justeras under stycketskroppen snarare än under den första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
2. Få åtkomst till mål‑bilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) till formen och ta bort standard‑stycket.
5. Skapa stycken och sätt ett positivt [margin_left](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/margin_left/)‑värde för varje stycke.
6. Ställ in ett negativt [indent](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/indent/)‑värde för att skapa hängande indrag.
7. Lägg till styckena i textramen.
8. Spara den modifierade presentationen.

Denna kod visar hur man ställer in ett hängande indrag för ett stycke:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Resultatet:

![Det hängande indraget i styckena](hanging_indent.png)

## **Hantera slutformat för stycke‑portion**

När du behöver kontrollera formateringen av "slutet" på ett stycke (formatet som tillämpas efter den sista textportionen) använder du egenskapen `end_paragraph_portion_format`. Exemplet nedan tillämpar ett större Times New Roman‑teckensnitt på slutet av det andra stycket.

1. Skapa eller öppna en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑fil.
1. Hämta mål‑bilden via index.
1. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Använd formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) och skapa två stycken.
1. Skapa ett [PortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/) satt till 48‑pt Times New Roman och tillämpa det som styckets slut‑av‑stycke‑portion‑format.
1. Tilldela det till styckets `end_paragraph_portion_format` (gäller för det andra styckets avslut).
1. Skriv den modifierade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du ställer in slut‑av‑stycke‑formatet för det andra stycket:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Importera HTML‑text i stycken**

Aspose.Slides erbjuder förbättrat stöd för att importera HTML‑text i stycken.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
1. Få åtkomst till mål‑bilden via dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/) på bilden.
1. Få åtkomst till [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/) för [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/).
1. Ta bort standard‑stycket från [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
1. Läs in käll‑HTML‑filen.
1. Skapa det första stycket med klassen [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/).
1. Lägg till HTML‑innehållet i [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/)s paragraf‑samling.
1. Spara den modifierade presentationen.

Följande Python‑kod implementerar dessa steg för att importera HTML‑text i stycken.

```python
import aspose.slides as slides

# Skapa en tom Presentation‑instans.
with slides.Presentation() as presentation:

    # Hämta den första bilden i presentationen.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Lägg till en AutoShape för att rymma HTML‑innehållet.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Rensa alla stycken i den tillagda textramen.
    shape.text_frame.paragraphs.clear()

    # Läs in HTML‑filen.
    with open("file.html", "rt") as html_stream:
        # Lägg till text från HTML‑filen i textramen.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Spara presentationen.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Exportera stycketext till HTML**

Aspose.Slides erbjuder förbättrat stöd för att exportera text till HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och ladda mål‑presentationen.
1. Få åtkomst till önskad bild via dess index.
1. Välj formen som innehåller texten som ska exporteras.
1. Få åtkomst till formens [TextFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/).
1. Öppna ett fil‑stream för att skriva HTML‑utdata.
1. Ange start‑index och exportera de required styckena.

Detta Python‑exempel visar hur man exporterar stycketext till HTML.

```python
import aspose.slides as slides

# Ladda in presentationsfilen.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Hämta den första bilden i presentationen.
    slide = presentation.slides[0]

    # Index för målformen.
    index = 0

    # Hämta formen efter index.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Skriv stycke data till HTML genom att ange startindex för stycket och det totala antalet stycken som ska exporteras.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Spara ett stycke som bild**

I detta avsnitt kommer vi att gå igenom två exempel som visar hur man sparar ett textstycke, representerat av klassen [Paragraph](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraph/), som en bild. Båda exemplen inkluderar att hämta bilden av en form som innehåller stycket med `get_image`‑metoderna från klassen [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/), beräkna styckets gränser inom formen och exportera det som en bitmap‑bild. Dessa metoder gör det möjligt att extrahera specifika delar av texten från PowerPoint‑presentationer och spara dem som separata bilder, vilket kan vara användbart i olika scenarier.

Anta att vi har en presentationsfil som heter sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

**Exempel 1**

I detta exempel hämtar vi det andra stycket som en bild. För att göra detta extraherar vi bilden av formen från den första bilden i presentationen och beräknar sedan gränserna för det andra stycket i formens textram. Stycket återges sedan på en ny bitmap‑bild som sparas i PNG‑format. Denna metod är särskilt användbar när du behöver spara ett specifikt stycke som en separat bild samtidigt som du bevarar exakt dimension och formatering.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Spara formen i minnet som en bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Skapa en shape‑bitmap från minnet.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Beräkna gränserna för det andra stycket.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Beräkna koordinaterna och storleken för utdata‑bilden (minimumstorlek - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Beskär shape‑bitmapen för att bara få paragraf‑bitmapen.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Resultatet:

![Stycke‑bilden](paragraph_to_image_output.png)

**Exempel 2**

I detta exempel utökar vi föregående tillvägagångssätt genom att lägga till skalningsfaktorer till stycke‑bilden. Formen extraheras från presentationen och sparas som en bild med en skalningsfaktor på `2`. Detta möjliggör en högre upplösning vid export av stycket. Styckets gränser beräknas sedan med hänsyn till skalan. Skalning kan vara särskilt användbart när en mer detaljerad bild krävs, till exempel för högkvalitativt tryckt material.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Spara formen i minnet som en bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Skapa en shape-bitmap från minnet.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Beräkna gränserna för det andra stycket.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Beräkna koordinaterna och storleken för utdata-bilden (minimumstorlek - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Beskär shape-bitmapen för att bara få paragraf-bitmapen.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **Vanliga frågor**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Använd textrammens omslag‑inställning ([wrap_text](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframeformat/wrap_text/)) för att slå av omslag så att raderna inte bryts vid ramens kanter.

**Hur kan jag få de exakt på‑bild‑gränserna för ett specifikt stycke?**

Du kan hämta styckets (och även en enskild portions) omslutsrektangel för att känna till dess exakta position och storlek på bilden.

**Var styrs styckejusteringen (vänster/höger/centrerat/justerat)?**

[Alignment](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/alignment/) är en inställning på styckennivå i [ParagraphFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/paragraphformat/); den gäller för hela stycket oavsett enskild portions formatering.

**Kan jag ange ett stavningsspråk för bara en del av ett stycke (t.ex. ett ord)?**

Ja. Språket anges på portionsnivå ([PortionFormat.language_id](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/language_id/)), så flera språk kan samexistera i ett och samma stycke.