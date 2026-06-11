---
title: Hantera zoom i presentationer med Python
linktitle: Zoom
type: docs
weight: 60
url: /sv/python-net/manage-zoom/
keywords:
- zoom
- zoomram
- bildzoom
- sektionzoom
- sammanfattningszoom
- lägga till zoom
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa och anpassa Zoom med Aspose.Slides för Python via .NET — hoppa mellan sektioner, lägg till miniatyrer och övergångar i PPT, PPTX och ODP-presentationer."
---
## **Introduktion**

Zoom-funktioner i PowerPoint låter dig hoppa till och från specifika bilder, sektioner och delar av en presentation. När du presenterar kan förmågan att snabbt navigera över innehållet vara mycket användbar. 

![overview](overview.png)

* För att sammanfatta en hel presentation på en enda bild, använd en [Summary Zoom](#Summary-Zoom).
* För att bara visa utvalda bilder, använd en [Slide Zoom](#Slide-Zoom).
* För att bara visa en enskild sektion, använd en [Section Zoom](#Section-Zoom).

## **Slide Zoom**

En bildzoom kan göra din presentation mer dynamisk, vilket gör att du kan navigera fritt mellan bilder i vilken ordning du vill utan att avbryta presentationens flöde. Bildzoomer är utmärkta för korta presentationer utan många sektioner, men du kan ändå använda dem i olika presentationsscenarier.

Bildzoomer hjälper dig att gräva djupare i flera informationsdelar samtidigt som du känner dig på en enda duk. 

![slidezoomsel](slidezoomsel.png)

För bildzoom‑objekt tillhandahåller Aspose.Slides uppräkningen [ZoomImageType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/zoomimagetype/) , klassen [ZoomFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/zoomframe/) samt några metoder i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/) .

### **Skapa zoomramar**
Du kan lägga till en zoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
2. Skapa nya bilder som du avser att länka till. 
3. Lägg till en identifieringstext och bakgrund på de skapade bilderna.
4. Lägg till zoomramar (som innehåller referenser till de skapade bilderna) i den första bilden.
5. Spara den ändrade presentationen som en PPTX‑fil.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Lägg till nya bilder i presentationen
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #Skapa en bakgrund för den andra bilden
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #Skapa en textruta för den andra bilden
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #Skapa en bakgrund för den tredje bilden
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #Skapa en textruta för den tredje bilden
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Lägg till ZoomFrame-objekt
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Spara presentationen
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Skapa zoomramar med egna bilder**
Med Aspose.Slides för Python via .NET kan du skapa en zoomram med en annan bild än bildförhandsgranskningen på följande sätt: 
1. Skapa en instans av klassen `Presentation` .
2. Skapa en ny bild som du avser att länka till. 
3. Lägg till en identifieringstext och bakgrund på den skapade bilden.
4. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑objekt genom att lägga till en bild i Images‑samlingen som är knuten till Presentation‑objektet och som ska användas för att fylla ramen.
5. Lägg till zoomramar (som innehåller referensen till den skapade bilden) i den första bilden.
6. Spara den ändrade presentationen som en PPTX‑fil.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Lägg till en ny bild i presentationen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Skapa en bakgrund för den andra bilden
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Skapa en textruta för den tredje bilden
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Skapa en ny bild för zoom-objektet
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Lägg till ZoomFrame-objektet
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Spara presentationen
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatera zoomramar**
I föregående avsnitt (ovan) visade vi hur du skapar enkla zoomramar. För att skapa mer komplicerade zoomramar måste du ändra ramens formatering. Det finns flera formateringsinställningar du kan tillämpa på en zoomram. 

Du kan styra formateringen av en zoomram på en bild på följande sätt:

1. Skapa en instans av klassen `Presentation` .
2. Skapa nya bilder att länka till.
3. Lägg till identifieringstext och bakgrund på de skapade bilderna.
4. Lägg till zoomramar (som innehåller referenser till de skapade bilderna) i den första bilden.
5. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑objekt genom att lägga till en bild i Images‑samlingen som är knuten till Presentation‑objektet och som ska användas för att fylla ramen.
6. Ställ in en egen bild för det första zoomramobjektet.
7. Ändra linjeformatet för det andra zoomramobjektet.
8. Ta bort bakgrunden från en bild i det andra zoomramobjektet.
9. Spara den ändrade presentationen som en PPTX‑fil.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Lägg till nya bilder i presentationen
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Skapa en bakgrund för den andra bilden
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Skapa en textruta för den andra bilden
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Skapa en bakgrund för den tredje bilden
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Skapa en textruta för den tredje bilden
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Lägg till ZoomFrame-objekt
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Skapa en ny bild för zoom-objektet
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Ställ in egen bild för zoomFrame1-objektet
    zoomFrame1.image = image

    # Ställ in ett zoomramformat för zoomFrame2-objektet
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Visa inte bakgrund för zoomFrame2-objektet
    zoomFrame2.show_background = False

    # Spara presentationen
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Section Zoom**

En sektionzoom är en länk till en sektion i din presentation. Du kan använda sektionzoomer för att gå tillbaka till sektioner du verkligen vill framhäva. Eller så kan du använda dem för att belysa hur vissa delar av din presentation hänger ihop. 

![seczoomsel](seczoomsel.png)

För sektionzoom‑objekt tillhandahåller Aspose.Slides klassen [SectionZoomFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectionzoomframe/) samt några metoder i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/) .

### **Skapa sektionzoomramar**

Du kan lägga till en sektionzoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
2. Skapa en ny bild. 
3. Lägg till en identifieringsbakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Lägg till en sektionzoomram (som innehåller referenser till den skapade sektionen) i den första bilden.
6. Spara den ändrade presentationen som en PPTX‑fil.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Lägger till en ny bild i presentationen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Lägger till en ny sektion i presentationen
    pres.sections.add_section("Section 1", slide)

    # Lägger till ett SectionZoomFrame-objekt
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Sparar presentationen
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Skapa sektionzoomramar med egna bilder**

Using Aspose.Slides for Python, you can create a section zoom frame with a different slide preview image this way: 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
2. Skapa en ny bild.
3. Lägg till en identifieringsbakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑objekt genom att lägga till en bild i Images‑samlingen som är knuten till [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objektet och som ska användas för att fylla ramen.
6. Lägg till en sektionzoomram (som innehåller en referens till den skapade sektionen) i den första bilden.
7. Spara den ändrade presentationen som en PPTX‑fil.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Lägger till en ny bild i presentationen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Lägger till en ny sektion i presentationen
    pres.sections.add_section("Section 1", slide)

    # Skapar en ny bild för zoom-objektet
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Lägger till ett SectionZoomFrame-objekt
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Sparar presentationen
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatera sektionzoomramar**

Du kan styra formateringen av en sektionzoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
2. Skapa en ny bild.
3. Lägg till en identifieringsbakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoomramen till. 
5. Lägg till en sektionzoomram (som innehåller referenser till den skapade sektionen) i den första bilden.
6. Ändra storlek och position för det skapade sektionzoom‑objektet.
7. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑objekt genom att lägga till en bild i Images‑samlingen som är knuten till [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objektet och som ska användas för att fylla ramen.
8. Ställ in en egen bild för det skapade sektionzoomram‑objektet.
9. Aktivera funktionen *återvänd till ursprungsbilden från den länkade sektionen*.
10. Ta bort bakgrunden från en bild i sektionzoomram‑objektet.
11. Ändra linjeformatet för det andra zoomram‑objektet.
12. Ändra övergångens varaktighet.
13. Spara den ändrade presentationen som en PPTX‑fil.

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Lägger till en ny bild i presentationen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Lägger till en ny sektion i presentationen
    pres.sections.add_section("Section 1", slide)

    # Lägg till SectionZoomFrame-objekt
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formatering för SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Sparar presentationen
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Summary Zoom**

En sammanfattningszoom är som en landningssida där alla delar av din presentation visas på en gång. När du presenterar kan du använda zoomen för att gå från en plats i presentationen till en annan i vilken ordning du vill. Du kan vara kreativ, hoppa fram eller återbesöka delar av din bildspels utan att avbryta presentationens flöde.

![overview_image](summaryzoom.png)

För sammanfattningszoom‑objekt tillhandahåller Aspose.Slides klassen [SummaryZoomFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/summaryzoomsection/), och [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/summaryzoomsectioncollection/) samt några metoder i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shapecollection/) .

### **Skapa sammanfattningszoom**

Du kan lägga till en sammanfattningszoomram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till sammanfattningszoomramen i den första bilden.
4. Spara den ändrade presentationen som en PPTX‑fil.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Skapa bildarray
    for slideNumber in range(5):
        # Lägg till nya bilder i presentationen
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Skapa en bakgrund för bilden
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Skapa en textruta för bilden
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Skapa zoom-objekt för alla bilder i den första bilden
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Ställ in ReturnToParent-egenskapen för att återgå till den första bilden
        zoomFrame.return_to_parent = True

    # Spara presentationen
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Lägga till och ta bort sammanfattningszoomsektion**

Alla sektioner i en sammanfattningszoomram representeras av [SummaryZoomSection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/summaryzoomsection/)‑objekt, som lagras i [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/summaryzoomsectioncollection/)‑objektet. Du kan lägga till eller ta bort ett sammanfattningszoom‑sektionobjekt via klassen [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/summaryzoomsectioncollection/) på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en sammanfattningszoomram i den första bilden.
4. Lägg till en ny bild och sektion i presentationen.
5. Lägg till den skapade sektionen i sammanfattningszoomramen.
6. Ta bort den första sektionen från sammanfattningszoomramen.
7. Spara den ändrade presentationen som en PPTX‑fil.

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Lägger till en ny bild i presentationen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Lägger till en ny sektion i presentationen
    pres.sections.add_section("Section 1", slide)

    #Lägger till en ny bild i presentationen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Lägger till en ny sektion i presentationen
    pres.sections.add_section("Section 2", slide)

    # Lägger till SummaryZoomFrame-objekt
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Lägger till en ny bild i presentationen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Lägger till en ny sektion i presentationen
    section3 = pres.sections.add_section("Section 3", slide)

    # Lägger till en sektion i Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Tar bort sektion från Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Sparar presentationen
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatera sammanfattningszoomsektioner**

För att skapa mer komplicerade sammanfattningszoom‑sektioner måste du ändra en enkel ramens formatering. Det finns flera formateringsalternativ du kan tillämpa på ett sammanfattningszoom‑sektionobjekt. 

Du kan styra formateringen av ett sammanfattningszoom‑sektionobjekt i en sammanfattningszoomram på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) .
2. Skapa nya bilder med identifieringsbakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en sammanfattningszoomram i den första bilden.
4. Hämta ett sammanfattningszoom‑sektionobjekt för det första objektet från `SummaryZoomSectionCollection` .
5. Skapa ett `PPImage`‑objekt genom att lägga till en bild i bildsamlingen som är knuten till [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objektet och som ska användas för att fylla ramen.
6. Ställ in en egen bild för det skapade sektionzoom‑ram‑objektet.
7. Aktivera funktionen *återvänd till ursprungsbilden från den länkade sektionen*.
8. Ändra linjeformatet för det andra zoomram‑objektet.
9. Ändra övergångens varaktighet.
10. Spara den ändrade presentationen som en PPTX‑fil.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Lägger till en ny bild i presentationen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Lägger till en ny sektion i presentationen
    pres.sections.add_section("Section 1", slide)

    #Lägger till en ny bild i presentationen
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Lägger till en ny sektion i presentationen
    pres.sections.add_section("Section 2", slide)

    # Lägger till ett SummaryZoomFrame-objekt
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Hämtar det första SummaryZoomSection-objektet
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formatering för SummaryZoomSection-objektet
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Sparar presentationen
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag styra återgång till 'föräldra'‑bilden efter att målet har visats?**

Ja. [Zoom frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/zoomframe/) eller [section](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectionzoomframe/) har ett `return_to_parent`‑beteende som, när det är aktiverat, skickar tittaren tillbaka till ursprungsbilden efter att de har besökt målinnehållet.

**Kan jag justera 'hastigheten' eller varaktigheten för Zoom‑övergången?**

Ja. Zoom stöder inställning av en `transition_duration` så att du kan kontrollera hur lång tidsanimationen tar.

**Finns det begränsningar för hur många Zoom‑objekt en presentation kan innehålla?**

Det finns ingen hård API‑gräns dokumenterad. Praktiska begränsningar beror på presentationens totala komplexitet och mottagarens prestanda. Du kan lägga till många Zoom‑ramar, men tänk på filstorlek och renderingtid.