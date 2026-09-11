---
title: Hantera SmartArt-formnoder i presentationer med Python
linktitle: SmartArt-formnod
type: docs
weight: 30
url: /sv/python-java/manage-smartart-shape-node/
keywords:
- SmartArt-nod
- barnnod
- lägg till nod
- nodposition
- åtkomstnod
- ta bort nod
- anpassad position
- assistentnod
- fyllningsformat
- rendera nod
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera SmartArt-formnoder i PPT och PPTX med Aspose.Slides för Python via Java. Få tydliga kodexempel och tips för att effektivisera dina presentationer."
---
## **Översikt**

SmartArt-grafik i PowerPoint-presentationer organiseras via noder som innehåller text och definierar diagrammets struktur. Aspose.Slides låter dig arbeta med dessa SmartArt‑noder programatiskt: lägga till nya noder och barnnoder, infoga barnnoder på en specifik position, komma åt befintliga noder och läsa deras text, nivå och position.

Denna artikel förklarar hur du hanterar SmartArt‑formnoder. Den visar hur du tar bort noder, arbetar med barnnoder efter index eller position, ändrar en assistentnod till en normal nod, justerar position, storlek och rotation för SmartArt‑nodformer, sätter fyllningsformat för noder och genererar en miniatyrbild för en SmartArt‑barnnod.

## **Lägg till en SmartArt‑nod**
Aspose.Slides for Python via Java tillhandahåller ett API för att hantera SmartArt‑former. Följande exempel lägger till en nod och en barnnod till en SmartArt‑form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och ladda presentationen som innehåller en SmartArt‑form.  
1. Hämta den första bilden efter dess index.  
1. Iterera genom alla former på den första bilden.  
1. Kontrollera om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)‑instans.  
1. [Add a new node](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnodecollection/#addNode) till SmartArt‑formens [node collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/#getAllNodes) och sätt dess text via [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).  
1. [Add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnodecollection/#addNode) en [child node](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnode/#getChildNodes) till den nya noden och sätt dess text via [TextFrame](https://reference.aspose.com/slides/sv/python-java/aspose.slides/textframe/).  
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Lägg till en SmartArt‑nod på en specifik position**
Följande exempel lägger till en barnnod på en specifik position i en SmartArt‑nod.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).  
1. Hämta den första bilden efter dess index.  
1. Lägg till en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)‑form med layouten [StackedList](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartlayouttype/#StackedList) på bilden.  
1. Kom åt den första noden i den tillagda SmartArt‑formen.  
1. Lägg till en barnnod till den valda noden på position 2 med [addNodeByPosition](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) och sätt dess text.  
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kom åt en SmartArt‑nod**
Följande exempel kommer åt noder i en SmartArt‑form. Layouten som returneras av [getLayout](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/#getLayout) är skrivskyddad och sätts när SmartArt‑formen läggs till.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och ladda presentationen som innehåller en SmartArt‑form.  
1. Hämta den första bilden efter dess index.  
1. Iterera genom alla former på den första bilden.  
1. Kontrollera om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)‑instans.  
1. Iterera genom alla [nodes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/#getAllNodes) i SmartArt‑formen.  
1. Läs och visa varje SmartArt‑nods position, nivå och text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Kom åt en SmartArt‑barnnod**
Följande exempel kommer åt barnnoderna för varje nod i en SmartArt‑form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och ladda presentationen som innehåller en SmartArt‑form.  
1. Hämta den första bilden efter dess index.  
1. Iterera genom alla former på den första bilden.  
1. Kontrollera om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)‑instans.  
1. Iterera genom alla [nodes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/#getAllNodes) i SmartArt‑formen.  
1. För varje nod, iterera genom dess [child nodes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnode/#getChildNodes).  
1. Läs och visa [child node](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnode/#getChildNodes)‑position, nivå och text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Kom åt en SmartArt‑barnnod på en specifik position**
Följande exempel kommer åt en barnnod på ett specifikt index i dess föräldranods samling.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).  
1. Hämta den första bilden efter dess index.  
1. Lägg till en SmartArt‑form med layouten [StackedList](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartlayouttype/#StackedList).  
1. Kom åt den tillagda SmartArt‑formen.  
1. Kom åt noden på index 0 i SmartArt‑formen.  
1. Kom åt barnnoden på index 1 med [get_Item](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnodecollection/#get_Item).  
1. Läs och visa [child node](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnode/#getChildNodes)‑position, nivå och text.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Ta bort en SmartArt‑nod**
Följande exempel tar bort en nod från en SmartArt‑form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och ladda presentationen som innehåller en SmartArt‑form.  
1. Hämta den första bilden efter dess index.  
1. Iterera genom alla former på den första bilden.  
1. Kontrollera om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)‑instans.  
1. Kontrollera att SmartArt‑formen innehåller minst en nod.  
1. Välj den SmartArt‑nod som ska tas bort.  
1. Ta bort den valda noden med [removeNode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ta bort en SmartArt‑nod från en specifik position**
Följande exempel tar bort en barnnod på ett specifikt index i en SmartArt‑nods samling.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och ladda presentationen som innehåller en SmartArt‑form.  
1. Hämta den första bilden efter dess index.  
1. Iterera genom alla former på den första bilden.  
1. Kontrollera om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)‑instans.  
1. Kom åt SmartArt‑noden på index 0 om den finns.  
1. Kontrollera att den valda SmartArt‑noden har minst två barnnoder.  
1. Ta bort barnnoden på index 1 med [removeNode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange en anpassad position för en barnnod i ett SmartArt‑objekt**
Aspose.Slides for Python via Java stödjer att sätta positionen för en [SmartArtShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartshape/) med [setX](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setX) och [setY](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setY). Följande exempel anger en anpassad position, storlek och rotation för SmartArt‑nodformer. När nya noder läggs till beräknas positioner och storlekar om för alla noder. Anpassad positionering låter dig ordna noderna som krävs.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontrollera en assistentnod**
{{% alert color="info" title="Note" %}} 

Detta avsnitt utforskar SmartArt‑former som läggs till i presentationsbilder programatiskt med Aspose.Slides for Python via Java.

{{% /alert %}} 

Den följande käll‑SmartArt‑formen används i exemplet.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figur: Käll‑SmartArt‑form på en bild**|

Följande exempel identifierar assistentnoder i en SmartArt‑nodsamling och ändrar dem till normala noder.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) och ladda presentationen som innehåller en SmartArt‑form.  
1. Hämta den första bilden efter dess index.  
1. Iterera genom alla former på den första bilden.  
1. Kontrollera om formen är en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)‑instans.  
1. Iterera genom alla noder i SmartArt‑formen och kontrollera om de är [Assistant Nodes](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartnode/#isAssistant).  
1. Ändra varje assistentnod till en normal nod.  
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figur: Assistentnoder ändrade i en SmartArt‑form på en bild**|

## **Ange en nods fyllningsformat**
Aspose.Slides for Python via Java gör det möjligt att lägga till anpassade SmartArt‑former och sätta deras fyllningsformat. Denna artikel förklarar hur du skapar och kommer åt SmartArt‑former samt sätter deras fyllningsformat med Aspose.Slides for Python via Java.

Följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).  
1. Hämta en bild efter dess index.  
1. Lägg till en [SmartArt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartart/)‑form med layouten [ClosedChevronProcess](https://reference.aspose.com/slides/sv/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).  
1. Sätt [FillFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getFillFormat) för SmartArt‑formens noder.  
1. Skriv den modifierade presentationen som en PPTX‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Generera en miniatyr av en SmartArt‑barnnod**
För att generera en miniatyr av en SmartArt‑barnnod, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).  
1. [Add a SmartArt shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapecollection/#addSmartArt).  
1. Hämta en nod efter dess index.  
1. Hämta miniatyrbilden.  
1. Spara miniatyrbilden i önskat bildformat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Stöds SmartArt‑animation?**

Ja. SmartArt behandlas som en vanlig form, så du kan [apply standard animations](/slides/sv/python-java/shape-animation/) (inkomst, utgång, betoning, rörelsespår) och justera timing. Du kan också animera former inuti SmartArt‑noder vid behov.

**Hur kan jag på ett tillförlitligt sätt lokalisera en specifik SmartArt på en bild om dess interna ID är okänt?**

Tilldela och sök efter [alternative text](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getAlternativeText). Genom att sätta distinkt alternativ text på SmartArt kan du hitta den programatiskt utan att förlita dig på interna identifierare.

**Behåller SmartArt sitt utseende när presentationen konverteras till PDF?**

Ja. Aspose.Slides renderar SmartArt med hög visuell trohet under [PDF export](/slides/sv/python-java/convert-powerpoint-to-pdf/), vilket bevarar layout, färger och effekter.

**Kan jag extrahera en bild av hela SmartArt (för förhandsgranskningar eller rapporter)?**

Ja. Du kan rendera en SmartArt‑form till [raster formats](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) eller till [SVG](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#writeAsSvgToBytes) för skalbar vektoroutput, vilket gör den lämplig för miniatyrer, rapporter eller webbbruk.