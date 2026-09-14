---
title: Lägg till vattenmärken i presentationer i Python
linktitle: Vattenmärke
type: docs
weight: 40
url: /sv/python-java/watermark/
keywords:
- vattenmärke
- textvattenmärke
- bildvattenmärke
- lägga till vattenmärke
- ändra vattenmärke
- ta bort vattenmärke
- radera vattenmärke
- lägga till vattenmärke i PPT
- lägga till vattenmärke i PPTX
- lägga till vattenmärke i ODP
- ta bort vattenmärke från PPT
- ta bort vattenmärke från PPTX
- ta bort vattenmärke från ODP
- radera vattenmärke från PPT
- radera vattenmärke från PPTX
- radera vattenmärke från ODP
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Hantera text- och bildvattenmärken i PowerPoint- och OpenDocument-presentationer i Python för att ange ett utkast, konfidentiell information, upphovsrätt och mer."
---
## **Introduktion**

**Ett vattenmärke** i en presentation är en text- eller bildstämpel som används på en bild eller genom alla presentationsbilder. Vanligtvis används ett vattenmärke för att ange att presentationen är ett utkast (t.ex. ett "Utkast"-vattenmärke), att den innehåller konfidentiell information (t.ex. ett "Konfidentiellt"-vattenmärke), för att specificera vilket företag den tillhör (t.ex. ett "Företagsnamn"-vattenmärke), för att identifiera presentationsförfattaren osv. Ett vattenmärke hjälper till att förhindra upphovsrättsintrång genom att ange att presentationen inte får kopieras. Vattenmärken används i både PowerPoint- och OpenOffice-presentationsformat. I Aspose.Slides kan du lägga till ett vattenmärke i PowerPoint PPT, PPTX och OpenOffice ODP filformat.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/python-java/) finns det olika sätt att skapa vattenmärken i PowerPoint- eller OpenOffice-dokument och ändra deras design och beteende. Det gemensamma är att för att lägga till textvattenmärken bör du använda klassen [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/), och för att lägga till bildvattenmärken, använd klassen [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) eller fyll en vattenmärkesform med en bild. [PictureFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframe/) ärver från klassen [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/), vilket gör att du kan använda alla flexibla inställningar för shape‑objektet. Eftersom [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/) inte är en shape och dess inställningar är begränsade, är den inbäddad i ett [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/)‑objekt.

Det finns två sätt att tillämpa ett vattenmärke på: på en enskild bild eller på alla presentationsbilder. Slide Master används för att applicera ett vattenmärke på alla presentationsbilder — vattenmärket läggs till i Slide Master, designas helt där och tillämpas på alla bilder utan att påverka möjligheten att redigera vattenmärket på enskilda bilder.

Ett vattenmärke anses normalt vara otillgängligt för redigering av andra användare. För att förhindra att vattenmärket (eller snarare dess överordnade shape) redigeras, erbjuder Aspose.Slides funktionalitet för låsning av shapes. En specifik shape kan låsas på en vanlig bild eller på en Slide Master. När vattenmärkes‑shape:n är låst på Slide Master, blir den låst på alla presentationsbilder.

Du kan ange ett namn för vattenmärket så att du i framtiden, om du vill ta bort det, kan hitta det bland bildens shapes efter namn.

Du kan designa vattenmärket på vilket sätt som helst; men det finns vanligtvis gemensamma egenskaper i vattenmärken, såsom centrerad justering, rotation, frontposition osv. Vi kommer att titta på hur man använder dessa i exemplen nedan.

## **Textvattenmärke**

### **Lägg till ett textvattenmärke på en bild**

För att lägga till ett textvattenmärke i PPT, PPTX eller ODP kan du först lägga till en shape på bilden och sedan lägga till en textframe till denna shape. Textframen representeras av klassen [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/). Denna typ ärver inte från [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/), som har ett brett urval av egenskaper för att positionera vattenmärket på ett flexibelt sätt. Därför är [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/)‑objektet inbäddat i ett [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/)‑objekt. För att lägga till vattenmärkestext till shape:n, använd metoden [addTextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#addTextFrame) som visas nedan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Obs" %}} 
- [Hur man använder TextFrame-klassen](/slides/sv/python-java/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenmärke i en presentation**

Om du vill lägga till ett textvattenmärke i hela presentationen (dvs. alla bilder på en gång), lägg till det i [MasterSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till ett vattenmärke på en enskild bild — skapa ett [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/)‑objekt och lägg sedan till vattenmärket i det med hjälp av metoden [addTextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Obs" %}} 
- [Hur man använder Slide Master](/slides/sv/python-java/slide-master/)
{{% /alert %}}

### **Ställ in transparenthet för vattenmärkes‑shape**

Som standard är rektangel‑shape:n stiliserad med fyllnings‑ och linjefärger. Följande kodrader gör shape:n transparent.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Ange teckensnittet för ett textvattenmärke**

Du kan ändra teckensnittet för textvattenmärket enligt nedan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Ange textfärgen för vattenmärket**

För att ange färgen på vattenmärkestexten, använd följande kod:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Centrera ett textvattenmärke**

Det är möjligt att centrera vattenmärket på en bild, och för det kan du göra följande:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

Bilden nedan visar slutresultatet.

![Textvattenmärket](text_watermark.png)

## **Bildvattenmärke**

### **Lägg till ett bildvattenmärke i en presentation**

För att lägga till ett bildvattenmärke på en presentationsbild kan du göra följande:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Lås ett vattenmärke från redigering**

Om det är nödvändigt att förhindra att ett vattenmärke redigeras, använd metoden [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/#getAutoShapeLock) på shape:n. Med denna egenskap kan du skydda shape:n från att väljas, storleksändras, flyttas, grupperas med andra element, låsa dess text från redigering och mycket mer:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Lås vattenmärkesformen mot ändring.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Flytta ett vattenmärke framåt**

I Aspose.Slides kan Z‑ordningen för shapes ställas in via metoden [ShapeCollection.reorder](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#reorder). För att göra detta måste du anropa metoden från bildens shape‑samling och skicka shape‑referensen och dess ordningsnummer till metoden. På så sätt går det att föra en shape framåt eller skicka den bakåt på bilden. Denna funktion är särskilt användbar om du behöver placera ett vattenmärke framför presentationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Ställ in rotation för vattenmärke**

Här är ett kodexempel på hur du justerar rotationen för vattenmärket så att det placeras diagonalt över bilden:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Ange ett namn för ett vattenmärke**

Aspose.Slides låter dig ange namnet på en shape. Genom att använda shape‑namnet kan du i framtiden komma åt den för att ändra eller ta bort den. För att ange namn på vattenmärkes‑shape:n, skicka den till metoden [Shape.setName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Ta bort ett vattenmärke**

För att ta bort vattenmärkeshapen, använd metoden [Shape.getName](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getName) för att hitta den i bildens shapes. Skicka sedan vattenmärkeshapen till metoden [ShapeCollection.remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **FAQ**

**Vad är ett vattenmärke och varför ska jag använda det?**

Ett vattenmärke är en text- eller bildövertäckning som appliceras på bilder och hjälper till att skydda immateriella rättigheter, förbättra varumärkesigenkänning eller förhindra obehörig användning av presentationer.

**Kan jag lägga till ett vattenmärke på alla bilder i en presentation?**

Ja, Aspose.Slides låter dig programatiskt lägga till ett vattenmärke på varje bild i en presentation. Du kan iterera igenom alla bilder och applicera vattenmärkeinställningarna individuellt.

**Hur kan jag justera transparensen för vattenmärket?**

Du kan justera transparensen för vattenmärket genom att ändra fyllningsinställningarna ([getFillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getFillFormat)) för shape:n. Detta säkerställer att vattenmärket är subtilt och inte distraherar från bildens innehåll.

**Vilka bildformat stöds för vattenmärken?**

Aspose.Slides stöder olika bildformat såsom PNG, JPEG, GIF, BMP, SVG och fler.

**Kan jag anpassa teckensnitt och stil för ett textvattenmärke?**

Ja, du kan välja vilket teckensnitt, storlek och stil som helst för att matcha designen i din presentation och upprätthålla varumärkeskonsekvens.

**Hur ändrar jag position eller orientering av ett vattenmärke?**

Du kan programatiskt justera position och orientering av vattenmärket genom att ändra shape‑ns koordinater, storlek och rotationsegenskaper.