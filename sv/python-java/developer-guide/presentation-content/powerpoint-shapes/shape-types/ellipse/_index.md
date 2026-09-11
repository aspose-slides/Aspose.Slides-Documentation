---
title: Lägg till ellipser i presentationer i Python via Java
linktitle: Ellips
type: docs
weight: 30
url: /sv/python-java/ellipse/
keywords:
- ellips
- form
- lägg till ellips
- skapa ellips
- rita ellips
- formaterad ellips
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du skapar, formaterar och manipulerar ellipsformer i Aspose.Slides för Python via Java i PPT- och PPTX-presentationer—Python‑kodexempel ingår."
---
## **Översikt**

Den här artikeln visar hur du lägger till ellipsformer i PowerPoint‑bilder med Aspose.Slides. Den täcker hur du skapar en enkel ellips, hur du skapar en formaterad ellips och hur du sparar den uppdaterade presentationen som en PPTX‑fil. Den berör också relaterade frågor såsom att arbeta med ellipsens position och storlek, kontroll av staplingsordning och tillämpning av animeringseffekter.

## **Skapa en ellips**

För att lägga till en enkel ellips på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
- Hämta en referens till en bild via dess index.
- Lägg till en ellips med metoden [addAutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAutoShape) på objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).
- Skriv den modifierade presentationen som en PPTX‑fil.

Följande exempel lägger till en ellips på den första bilden:

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

    # Lägg till en ellipsform.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Skriv PPTX-filen till disk.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Skapa en formaterad ellips**

För att lägga till en formaterad ellips på en bild, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
- Hämta en referens till en bild via dess index.
- Lägg till en ellips med metoden [addAutoShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addAutoShape) på objektet [ShapeCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/).
- Ställ in ellipsens fyllningstyp till solid.
- Ställ in ellipsens fyllningsfärg via [getSolidFillColor](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/#getSolidFillColor) på objektet [FillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fillformat/) som är kopplat till objektet [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/).
- Ställ in färgen på ellipsens kontur.
- Ställ in bredden på ellipsens kontur.
- Skriv den modifierade presentationen som en PPTX‑fil.

Följande exempel lägger till en formaterad ellips på den första bilden i presentationen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Skapa en instans av Presentation-klassen som representerar PPTX-filen.
presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en ellipsform.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Formatera ellipsens fyllning.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Formatera ellipsens kontur.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Skriv PPTX-filen till disk.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Hur anger jag exakt position och storlek på en ellips i förhållande till bildens enheter?**

Koordinater och storlekar anges vanligtvis **i punkter**. För förutsägbara resultat, basera dina beräkningar på bildens storlek och konvertera erforderliga millimeter eller tum till punkter innan du tilldelar värden.

**Hur placerar jag en ellips ovanför eller under andra objekt (kontroll av staplingsordning)?**

Justera ritordningen för objektet genom att flytta det framåt eller skicka det bakåt. Detta låter ellipsen överlappa andra objekt eller avslöja de som ligger under den.

**Hur animera jag en ellipss framträdande eller betoning?**

[Apply](/slides/sv/python-java/shape-animation/) ingångs‑, betoning‑ eller utgångseffekter på formen och konfigurera triggers och tidsinställningar för att styra när och hur animationen spelas upp.