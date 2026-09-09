---
title: "Hantera presentationszoom i Python via Java"
linktitle: "Hantera zoom"
type: docs
weight: 60
url: /sv/python-java/manage-zoom/
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
- Java
- Aspose.Slides
description: "Skapa och anpassa Zoom med Aspose.Slides för Python via Java — hoppa mellan sektioner, lägg till miniatyrbilder och övergångar i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

Zoom-funktioner i PowerPoint låter dig hoppa till och från specifika bilder, sektioner och delar av en presentation. När du presenterar kan denna förmåga att snabbt navigera i innehållet visa sig mycket användbar.

![overview_image](overview.png)

* För att sammanfatta en hel presentation på en enda bild, använd en [Summary Zoom](#summary-zoom).
* För att bara visa utvalda bilder, använd en [Slide Zoom](#slide-zoom).
* För att bara visa en enskild sektion, använd en [Section Zoom](#section-zoom).

## **Slide Zoom**
En slide zoom kan göra din presentation mer dynamisk och låter dig navigera fritt mellan bilder i vilken ordning du önskar utan att avbryta flödet i din presentation. Slide zooms är bra för korta presentationer utan många sektioner, men du kan också använda dem i olika presentationsscenarier.

Slide zooms hjälper dig att gräva ner dig i flera informationsbitar samtidigt som du känner att du befinner dig på en enda canvas.

![overview_image](slidezoomsel.png)

För slide zoom‑objekt tillhandahåller Aspose.Slides enumerationen [ZoomImageType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zoomimagetype/), klassen [ZoomFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zoomframe/) och några metoder i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).

### **Create Zoom Frames**

Du kan lägga till en zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa nya bilder som du avser att länka zoom‑ramarna till.
3. Lägg till identifierande text och bakgrund på de skapade bilderna.
4. Lägg till zoom‑ramar (som innehåller referenserna till de skapade bilderna) på den första bilden.
5. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du skapar en zoom‑ram på en bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Lägger till nya bilder i presentationen
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Skapar en bakgrund för den andra bilden
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Skapar en textruta för den andra bilden
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Skapar en bakgrund för den tredje bilden
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Skapa en textruta för den tredje bilden
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Lägger till ZoomFrame-objekt
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Sparar presentationen
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Create Zoom Frames with Custom Images**
Med Aspose.Slides för Python via Java kan du skapa en zoom‑ram med en annan bild för bildförhandsvisning på följande sätt:
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa en ny bild som du avser att länka zoom‑ramen till.
3. Lägg till identifierande text och bakgrund på bilden.
4. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i bildsamlingen som är knuten till [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-objektet som ska användas för att fylla ramen.
5. Lägg till zoom‑ramar (som innehåller referensen till den skapade bilden) på den första bilden.
6. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du skapar en zoom‑ram med en annan bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Skapar en bakgrund för den andra bilden
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Skapar en textruta för den andra bilden
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Skapar en ny bild för zoom-objektet
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Lägger till ZoomFrame-objektet
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Sparar presentationen
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Format Zoom Frames**
I de föregående avsnitten visade vi hur du skapar enkla zoom‑ramar. För att skapa mer komplicerade zoom‑ramar måste du ändra formateringen på en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en zoom‑ram.

Du kan kontrollera en zoom‑ramens formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa nya bilder som du avser att länka zoom‑ramarna till.
3. Lägg till identifierande text och bakgrund på de skapade bilderna.
4. Lägg till zoom‑ramar (som innehåller referenserna till de skapade bilderna) på den första bilden.
5. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i bildsamlingen som är knuten till [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-objektet som ska användas för att fylla ramen.
6. Ställ in en anpassad bild för det första zoom‑ramobjektet.
7. Ändra linjeformatet för det andra zoom‑ramobjektet.
8. Ta bort bakgrunden från en bild i det andra zoom‑ramobjektet.
9. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du ändrar en zoom‑ramens formatering på en bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Lägger till nya bilder i presentationen
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Skapar en bakgrund för den andra bilden
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Skapar en textruta för den andra bilden
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Skapar en bakgrund för den tredje bilden
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Skapar en textruta för den tredje bilden
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Lägger till ZoomFrame-objekt
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Skapar en ny bild för zoom-objektet
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Ställer in anpassad bild för first_zoom_frame-objektet
    first_zoom_frame.setZoomImage(picture)

    #  Ställer in ett zoomramformat för second_zoom_frame-objektet
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Inställning för att inte visa bakgrund för second_zoom_frame-objektet
    second_zoom_frame.setShowBackground(False)

    #  Sparar presentationen
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Section Zoom**

En section zoom är en länk till en sektion i din presentation. Du kan använda section zooms för att återgå till sektioner du verkligen vill betona. Eller så kan du använda dem för att tydliggöra hur vissa delar av din presentation hänger ihop.

![overview_image](seczoomsel.png)

För section zoom‑objekt tillhandahåller Aspose.Slides klassen [SectionZoomFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectionzoomframe/) och några metoder i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).

### **Create Section Zoom Frames**

Du kan lägga till en section zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa en ny bild.
3. Lägg till en tydlig bakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoom‑ramen till.
5. Lägg till en section zoom‑ram (som innehåller referenser till den skapade sektionen) på den första bilden.
6. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du skapar en zoom‑ram på en bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 1", slide)

    #  Lägger till ett SectionZoomFrame-objekt
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Sparar presentationen
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Create Section Zoom Frames with Custom Images**

Med Aspose.Slides för Python via Java kan du skapa en section zoom‑ram med en annan bild för bildförhandsvisning på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa en ny bild.
3. Lägg till en tydlig bakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoom‑ramen till.
5. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i bildsamlingen som är knuten till [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-objektet som ska användas för att fylla ramen.
6. Lägg till en section zoom‑ram (som innehåller en referens till den skapade sektionen) på den första bilden.
7. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du skapar en zoom‑ram med en annan bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 1", slide)

    #  Skapar en ny bild för zoom-objektet
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Lägger till SectionZoomFrame-objekt
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Sparar presentationen
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Format Section Zoom Frames**

För att skapa mer komplicerade section zoom‑ramar måste du ändra formateringen på en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på en section zoom‑ram.

Du kan kontrollera en section zoom‑ramens formatering på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa en ny bild.
3. Lägg till en tydlig bakgrund på den skapade bilden.
4. Skapa en ny sektion som du avser att länka zoom‑ramen till.
5. Lägg till en section zoom‑ram (som innehåller referenser till den skapade sektionen) på den första bilden.
6. Ändra storlek och position för det skapade section zoom‑objektet.
7. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i bildsamlingen som är knuten till [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-objektet som ska användas för att fylla ramen.
8. Ställ in en anpassad bild för det skapade section zoom‑ramobjektet.
9. Aktivera *återgång till den ursprungliga bilden från den länkade sektionen*.
10. Ta bort bakgrunden från en bild i section zoom‑ramobjektet.
11. Ändra linjeformatet för section zoom‑ramobjektet.
12. Ändra övergångens varaktighet.
13. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du ändrar formateringen för ett section zoom‑objekt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 1", slide)

    #  Lägg till SectionZoomFrame-objekt
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Formatering för SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Sparar presentationen
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Summary Zoom**

En summary zoom fungerar som en landningssida där alla delar av din presentation visas samtidigt. När du presenterar kan du använda zoomen för att gå från en plats i presentationen till en annan i valfri ordning. Du kan vara kreativ, hoppa fram eller återvända till delar av ditt bildspel utan att avbryta flödet i presentationen.

![overview_image](sumzoomsel.png)

För summary zoom‑objekt tillhandahåller Aspose.Slides klasserna [SummaryZoomFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/summaryzoomsection/) och [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/summaryzoomsectioncollection/) samt några metoder i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).

### **Create a Summary Zoom**

Du kan lägga till en summary zoom‑ram på en bild på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa nya bilder med en tydlig bakgrund och nya sektioner för de skapade bilderna.
3. Lägg till summary zoom‑ramen på den första bilden.
4. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du skapar en summary zoom‑ram på en bild:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 1", slide)

    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 2", slide)

    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 3", slide)

    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 4", slide)

    #  Lägger till ett SummaryZoomFrame-objekt
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Sparar presentationen
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Add and Remove a Summary Zoom Section**

Alla sektioner i en summary zoom‑ram representeras av [SummaryZoomSection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/summaryzoomsection/)-objekt, som lagras i [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/summaryzoomsectioncollection/)-objektet. Du kan lägga till eller ta bort ett summary zoom‑sektionobjekt via klassen [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/summaryzoomsectioncollection/) på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa nya bilder med en tydlig bakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en summary zoom‑ram i den första bilden.
4. Lägg till en ny bild och sektion i presentationen.
5. Lägg till den skapade sektionen i summary zoom‑ramen.
6. Ta bort den första sektionen från summary zoom‑ramen.
7. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du lägger till och tar bort sektioner i en summary zoom‑ram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 1", slide)

    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 2", slide)

    #  Lägger till ett SummaryZoomFrame-objekt
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Lägger till en sektion i Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Tar bort sektion från Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Sparar presentationen
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Format Summary Zoom Sections**

För att skapa mer komplicerade summary zoom‑sektioner måste du ändra formateringen på en enkel ram. Det finns flera formateringsalternativ du kan tillämpa på ett summary zoom‑sektionobjekt.

Du kan kontrollera formateringen för ett summary zoom‑sektionobjekt i en summary zoom‑ram på följande sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
2. Skapa nya bilder med en tydlig bakgrund och nya sektioner för de skapade bilderna.
3. Lägg till en summary zoom‑ram på den första bilden.
4. Hämta det första summary zoom‑sektionobjektet från [SummaryZoomSectionCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/summaryzoomsectioncollection/).
5. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/python-java/aspose.slides/ppimage/)-objekt genom att lägga till en bild i bildsamlingen som är knuten till [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-objektet som ska användas för att fylla ramen.
6. Ställ in en anpassad bild för summary zoom‑sektionobjektet.
7. Aktivera *återgång till den ursprungliga bilden från den länkade sektionen*.
8. Ändra linjeformatet för summary zoom‑sektionobjektet.
9. Ändra övergångens varaktighet.
10. Spara den ändrade presentationen som en PPTX‑fil.

Denna Python‑kod visar hur du ändrar formateringen för ett summary zoom‑sektionobjekt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Lägger till en ny bild i presentationen
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 1", slide)

    # Adds a new slide to the presentation
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Lägger till en ny sektion i presentationen
    presentation.getSections().addSection("Section 2", slide)

    #  Lägger till ett SummaryZoomFrame-objekt
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Hämtar det första SummaryZoomSection-objektet
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Formatering för SummaryZoomSection-objekt
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Sparar presentationen
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag kontrollera återgång till den ’föräldra’ bilden efter att målbilden har visats?**

Ja. [ZoomFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zoomframe/) eller [SectionZoomFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sectionzoomframe/) stödjer återgång till ursprungsbilden via [setReturnToParent](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zoomobject/#setReturnToParent), vilket skickar tittarna tillbaka efter att de har besökt mål­innehållet när funktionen är aktiverad.

**Kan jag justera ’hastigheten’ eller varaktigheten för Zoom‑övergången?**

Ja. Zoom stödjer att sätta en övergångsvaraktighet med [setTransitionDuration](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zoomobject/#setTransitionDuration) så att du kan styra hur lång tid hopp‑animationen tar.

**Finns det begränsningar för hur många Zoom‑objekt en presentation kan innehålla?**

Det finns ingen hård API‑gräns dokumenterad. Praktiska begränsningar beror på presentationens totala komplexitet och tittarens prestanda. Du kan lägga till många Zoom‑ramar, men bör tänka på filstorlek och renderingtid.