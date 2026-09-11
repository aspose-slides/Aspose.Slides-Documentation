---
title: Hantera SmartArt-grafik i presentationer med Python
linktitle: SmartArt-grafik
type: docs
weight: 20
url: /sv/python-java/manage-smartart-shape/
keywords:
- SmartArt-objekt
- SmartArt-grafik
- SmartArt-stil
- SmartArt-färg
- Skapa SmartArt
- Lägg till SmartArt
- Redigera SmartArt
- Ändra SmartArt
- Åtkomst till SmartArt
- SmartArt-layouttyp
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Automatisera skapande, redigering och formgivning av PowerPoint SmartArt i Python med Aspose.Slides, med koncisa kodexempel och prestandafokuserad vägledning."
---
## **Översikt**

Aspose.Slides låter dig skapa och hantera SmartArt‑grafik i PowerPoint‑presentationer programatiskt. Den här artikeln förklarar hur du lägger till en SmartArt‑form på en bild, får åtkomst till befintliga SmartArt‑former, hittar SmartArt efter en specifik layouttyp och uppdaterar dess visuella utseende genom att ändra SmartArt‑stilen eller färgstilen.

Exemplen visar hur du arbetar med SmartArt‑former via presentationens bilds formsamling, kontrollerar om en form är SmartArt och sedan modifierar eller inspekterar dess egenskaper.

## **Skapa en SmartArt‑form**
Aspose.Slides för Python via Java tillhandahåller ett API för att skapa SmartArt‑former. För att skapa en SmartArt‑form i en bild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Hämta en bild efter dess index.
1. [Lägg till en SmartArt‑form](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addSmartArt) genom att ange en [SmartArtLayoutType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartlayouttype/).
1. Spara den modifierade presentationen som en PPTX‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Hämta den första bilden.
    slide = presentation.getSlides().get_Item(0)

    # Lägg till en SmartArt-form.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Spara presentationen.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figur: SmartArt‑form tillagd på bilden**|

## **Åtkomst till en SmartArt‑form på en bild**
Följande exempel får åtkomst till SmartArt‑former på en presentationsbild. Det itererar genom varje form på bilden och kontrollerar om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)-instans.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iterera genom varje form på den första bilden.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Åtkomst till en SmartArt‑form med en viss layouttyp**
Följande exempel får åtkomst till en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)-form med en viss layouttyp, returnerad av [SmartArt.getLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/#getLayout).

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-klassen och läs in presentationen som innehåller en SmartArt‑form.
1. Hämta den första bilden efter dess index.
1. Iterera genom varje form på den första bilden.
1. Kontrollera om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)-instans.
1. Kontrollera om SmartArt‑formen har den angivna layouttypen och utför den nödvändiga operationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iterera genom varje form på den första bilden.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Kontrollera SmartArt-layouten.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Ändra en SmartArt‑forms stil**
Detta exempel visar hur du ändrar snabbstilen för en SmartArt‑form.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-klassen och läs in presentationen som innehåller en SmartArt‑form.
1. Hämta den första bilden efter dess index.
1. Iterera genom varje form på den första bilden.
1. Kontrollera om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)-instans.
1. Hitta SmartArt‑formen med den angivna stilen.
1. Ställ in den nya stilen för SmartArt‑formen.
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iterera genom varje form på den första bilden.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Kontrollera och ändra SmartArt-stilen.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figur: SmartArt‑form med ändrad stil**|

## **Ändra en SmartArt‑forms färgstil**
Detta exempel får åtkomst till en SmartArt‑form med en särskild färgstil och ändrar den stilen.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)-klassen och läs in presentationen som innehåller en SmartArt‑form.
1. Hämta den första bilden efter dess index.
1. Iterera genom varje form på den första bilden.
1. Kontrollera om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)-instans.
1. Hitta SmartArt‑formen med den angivna färgstilen.
1. Ställ in den nya färgstilen för SmartArt‑formen.
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iterera genom varje form på den första bilden.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Kontrollera och ändra SmartArt-stilen.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figur: SmartArt‑form med ändrad färgstil**|

## **FAQ**

**Kan jag animera SmartArt som ett enda objekt?**

Ja. SmartArt är en form, så du kan applicera [standardanimationer](/slides/sv/python-java/powerpoint-animation/) via animations‑API‑et (ingång, utgång, betoning, rörelsebanor) precis som för andra former.

**Hur hittar jag en specifik SmartArt på en bild om jag inte känner till dess interna ID?**

Ange och använd [alternativ text](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setAlternativeText) och sök efter formen efter det värdet – detta är ett rekommenderat sätt att lokalisera målföremålet.

**Kan jag gruppera SmartArt med andra former?**

Ja. Du kan gruppera SmartArt med andra former (bilder, tabeller osv.) och sedan [manipulera gruppen](/slides/sv/python-java/group/).

**Hur får jag en bild av en specifik SmartArt (t.ex. för förhandsgranskning eller rapport)?**

Exportera en miniatyr/bild av formen; biblioteket kan [rendera enskilda former](/slides/sv/python-java/create-shape-thumbnails/) till rasterfiler (PNG/JPG/TIFF).

**Behålls SmartArt‑utseendet när hela presentationen konverteras till PDF?**

Ja. Renderingsmotorn strävar efter hög noggrannhet för [PDF‑export](/slides/sv/python-java/convert-powerpoint-to-pdf/), med ett urval av kvalitets‑ och kompatibilitetsalternativ.