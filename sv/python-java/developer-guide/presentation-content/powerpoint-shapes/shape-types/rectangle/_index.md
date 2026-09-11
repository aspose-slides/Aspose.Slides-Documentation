---
title: Lägg till rektanglar i presentationer i Python via Java
linktitle: Rektangel
type: docs
weight: 80
url: /sv/python-java/rectangle/
keywords:
- lägga till rektangel
- skapa rektangel
- rektangelform
- enkel rektangel
- formaterad rektangel
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Förbättra dina PowerPoint-presentationer genom att lägga till rektanglar med Aspose.Slides för Python via Java – designa och ändra former programvarumässigt enkelt."
---
## **Översikt**

Den här artikeln visar hur du lägger till rektangelformer i PowerPoint‑bilder med hjälp av Aspose.Slides. Den behandlar att skapa en enkel rektangel, skapa en formaterad rektangel och spara den uppdaterade presentationen som en PPTX‑fil.

Du får också se hur man använder grundläggande formatering för rektanglar, såsom en solid fyllningsfärg, linjefärg och linjebredd. Dessutom pekar artikelnens FAQ på relaterade rektangeluppgifter, inklusive rundade hörn, bildfyllningar, visuella effekter, hyperlänkar, lås för former, exportalternativ och effektiva egenskaper.

## **Lägg till en rektangel på en bild**

För att lägga till en enkel rektangel på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
- Hämta en referens till en bild med dess index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) av rektangeltyp med metoden [addAutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAutoShape) som finns i objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).
- Skriv den ändrade presentationen som en PPTX‑fil.

I exempel nedan har vi lagt till en enkel rektangel på den första bilden i presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Skapa en instans av Presentation-klassen som representerar PPTX-filen.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en rektangel.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Skriv PPTX-filen till disk.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lägg till en formaterad rektangel på en bild**

För att lägga till en formaterad rektangel på en bild, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
- Hämta en referens till en bild med dess index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshape/) av rektangeltyp med metoden [addAutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAutoShape) som finns i objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).
- Ställ in [fill type](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/) för rektangeln till solid.
- Ange rektangelns färg med metoden [setColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/colorformat/#setColor) på den solida fyllningsfärgen i objektet [FillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/) som är kopplat till objektet [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/).
- Ställ in färgen på rektangelns kontur.
- Ställ in bredden på rektangelns kontur.
- Skriv den ändrade presentationen som en PPTX‑fil.

Stegen ovan är implementerade i exempel nedan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation-klassen som representerar PPTX-filen.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en rektangel.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Formatera rektangelns fyllning.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Formatera rektangelns kontur.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Skriv PPTX-filen till disk.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Hur lägger jag till en rektangel med rundade hörn?**

Använd den rundade hörn‑[shape type](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/) och justera hörnradien i formens egenskaper; avrundning kan också tillämpas per hörn via geometrijusteringar.

**Hur fyller jag en rektangel med en bild (textur)?**

Välj bild‑[fill type](https://reference.aspose.com/slides/sv/python-java/aspose.slides/filltype/), ange bildkällan och konfigurera [stretching/tiling modes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/picturefillmode/).

**Kan en rektangel ha skugga och glöd?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/sv/python-java/shape-effect/) är tillgängliga med justerbara parametrar.

**Kan jag göra en rektangel till en knapp med en hyperlänk?**

Ja. [Assign a hyperlink](/slides/sv/python-java/manage-hyperlinks/) till formens klick (hoppa till en bild, fil, webbadress eller e‑post).

**Hur kan jag skydda en rektangel mot att flyttas och ändras?**

[Use shape locks](/slides/sv/python-java/applying-protection-to-presentation/): du kan förbjuda flyttning, storleksändring, markering eller textredigering för att bevara layouten.

**Kan jag konvertera en rektangel till en rasterbild eller SVG?**

Ja. Du kan [render the shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) till en bild med en angiven storlek/skala eller [export it as SVG](/slides/sv/python-java/create-shape-thumbnails/) för vektoranvändning.

**Hur får jag snabbt de faktiska (effektiva) egenskaperna för en rektangel med hänsyn till tema och arv?**

[Use the shape’s effective properties](/slides/sv/python-java/shape-effective-properties/): API‑t returnerar beräknade värden som tar hänsyn till temastilar, layout och lokala inställningar, vilket förenklar formateringsanalys.