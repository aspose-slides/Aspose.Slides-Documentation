---
title: Beheer SmartArt-vormknooppunten in presentaties met Python
linktitle: SmartArt-vormknooppunt
type: docs
weight: 30
url: /nl/python-java/manage-smartart-shape-node/
keywords:
- SmartArt-knooppunt
- onderliggend knooppunt
- knooppunt toevoegen
- knooppuntpositie
- knooppunt benaderen
- knooppunt verwijderen
- aangepaste positie
- assistent-knooppunt
- vullingsformaat
- knooppunt renderen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer SmartArt-vormknooppunten in PPT en PPTX met Aspose.Slides for Python via Java. Ontvang duidelijke code-voorbeelden en tips om uw presentaties te optimaliseren."
---
## **Overzicht**

SmartArt‑afbeeldingen in PowerPoint‑presentaties worden georganiseerd via knooppunten die tekst bevatten en de structuur van het diagram bepalen. Aspose.Slides stelt u in staat om programmatically met deze SmartArt‑knooppunten te werken: nieuwe knooppunten en onderliggende knooppunten toevoegen, onderliggende knooppunten op een specifieke positie invoegen, bestaande knooppunten benaderen en hun tekst, niveau en positie uitlezen.

Dit artikel legt uit hoe u SmartArt‑vormknooppunten beheert. Het toont hoe u knooppunten verwijdert, met onderliggende knooppunten werkt op index of positie, een assistent‑knooppunt omvormt tot een normaal knooppunt, de positie, grootte en rotatie van SmartArt‑knooppunt‑vormen aanpast, knooppunt‑vullingsformaten instelt en een miniatuur‑afbeelding genereert voor een SmartArt‑onderliggend knooppunt.

## **Een SmartArt‑knooppunt toevoegen**
Aspose.Slides for Python via Java biedt een API om SmartArt‑vormen te beheren. Het volgende voorbeeld voegt een knooppunt en een onderliggend knooppunt toe aan een SmartArt‑vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die een SmartArt‑vorm bevat.  
1. Haal de eerste dia op basis van de index op.  
1. Doorloop elke vorm op de eerste dia.  
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.  
1. [Voeg een nieuw knooppunt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnodecollection/#addNode) toe aan de [knooppunt‑verzameling](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/#getAllNodes) van de SmartArt‑vorm en stel de tekst in via [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/).  
1. [Voeg](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnodecollection/#addNode) een [onderliggend knooppunt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnode/#getChildNodes) toe aan het nieuwe knooppunt en stel de tekst in via [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/).  
1. Sla de presentatie op.

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

## **Een SmartArt‑knooppunt op een specifieke positie toevoegen**
Het volgende voorbeeld voegt een onderliggend knooppunt toe op een specifieke positie in een SmartArt‑knooppunt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
1. Haal de eerste dia op basis van de index op.  
1. Voeg een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑vorm met de [StackedList](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartlayouttype/#StackedList)‑lay‑out toe aan de dia.  
1. Benader het eerste knooppunt in de toegevoegde SmartArt‑vorm.  
1. Voeg een onderliggend knooppunt toe aan het geselecteerde knooppunt op positie 2 met [addNodeByPosition](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) en stel de tekst in.  
1. Sla de presentatie op.

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

## **Toegang tot een SmartArt‑knooppunt**
Het volgende voorbeeld krijgt toegang tot knooppunten in een SmartArt‑vorm. De lay‑out die wordt geretourneerd door [getLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/#getLayout) is alleen‑lezen en wordt ingesteld wanneer de SmartArt‑vorm wordt toegevoegd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die een SmartArt‑vorm bevat.  
1. Haal de eerste dia op basis van de index op.  
1. Doorloop elke vorm op de eerste dia.  
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.  
1. Doorloop alle [knooppunten](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/#getAllNodes) in de SmartArt‑vorm.  
1. Lees en toon de positie, het niveau en de tekst van elk SmartArt‑knooppunt.

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

## **Toegang tot een onderliggend SmartArt‑knooppunt**
Het volgende voorbeeld krijgt toegang tot de onderliggende knooppunten van elk knooppunt in een SmartArt‑vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die een SmartArt‑vorm bevat.  
1. Haal de eerste dia op basis van de index op.  
1. Doorloop elke vorm op de eerste dia.  
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.  
1. Doorloop alle [knooppunten](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/#getAllNodes) in de SmartArt‑vorm.  
1. Voor elk knooppunt, doorloop de [onderliggende knooppunten](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnode/#getChildNodes).  
1. Lees en toon de positie, het niveau en de tekst van het [onderliggende knooppunt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnode/#getChildNodes).

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

## **Toegang tot een onderliggend SmartArt‑knooppunt op een specifieke positie**
Het volgende voorbeeld krijgt toegang tot een onderliggend knooppunt op een specifieke index in de verzameling van het bovenliggende knooppunt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
1. Haal de eerste dia op basis van de index op.  
1. Voeg een SmartArt‑vorm met de [StackedList](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartlayouttype/#StackedList)‑lay‑out toe.  
1. Benader de toegevoegde SmartArt‑vorm.  
1. Benader het knooppunt met index 0 in de SmartArt‑vorm.  
1. Benader het onderliggende knooppunt met index 1 met [get_Item](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnodecollection/#get_Item).  
1. Lees en toon de positie, het niveau en de tekst van het [onderliggende knooppunt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnode/#getChildNodes).

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

## **Een SmartArt‑knooppunt verwijderen**
Het volgende voorbeeld verwijdert een knooppunt uit een SmartArt‑vorm.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die een SmartArt‑vorm bevat.  
1. Haal de eerste dia op basis van de index op.  
1. Doorloop elke vorm op de eerste dia.  
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.  
1. Controleer dat de [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑vorm ten minste één knooppunt bevat.  
1. Selecteer het SmartArt‑knooppunt dat verwijderd moet worden.  
1. Verwijder het geselecteerde knooppunt met [removeNode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Sla de presentatie op.

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

## **Een SmartArt‑knooppunt verwijderen vanaf een specifieke positie**
Het volgende voorbeeld verwijdert een onderliggend knooppunt op een specifieke index in de verzameling van een SmartArt‑knooppunt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die een SmartArt‑vorm bevat.  
1. Haal de eerste dia op basis van de index op.  
1. Doorloop elke vorm op de eerste dia.  
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.  
1. Benader het SmartArt‑knooppunt met index 0 indien aanwezig.  
1. Controleer dat het geselecteerde SmartArt‑knooppunt ten minste twee onderliggende knooppunten heeft.  
1. Verwijder het onderliggende knooppunt met index 1 met [removeNode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Sla de presentatie op.

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

## **Een aangepaste positie instellen voor een onderliggend knooppunt in een SmartArt‑object**
Aspose.Slides for Python via Java ondersteunt het instellen van de positie van een [SmartArtShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartshape/) met [setX](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setX) en [setY](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setY). Het volgende voorbeeld stelt een aangepaste positie, grootte en rotatie in voor SmartArt‑knooppunt‑vormen. Het toevoegen van nieuwe knooppunten herberekent de posities en groottes van alle knooppunten. Met aangepaste positionering kunt u knooppunten rangschikken zoals vereist.

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

## **Een assistent‑knooppunt controleren**
{{% alert color="info" title="Note" %}} 

Dit gedeelte onderzoekt SmartArt‑vormen die programmatisch aan presentatiedia's worden toegevoegd met Aspose.Slides for Python via Java.

{{% /alert %}} 

De volgende bron‑SmartArt‑vorm wordt in dit voorbeeld gebruikt.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figuur: Bron‑SmartArt‑vorm op een dia**|

Het volgende voorbeeld identificeert assistent‑knooppunten in een SmartArt‑knooppunt‑verzameling en verandert ze in normale knooppunten.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en laad de presentatie die een SmartArt‑vorm bevat.  
1. Haal de eerste dia op basis van de index op.  
1. Doorloop elke vorm op de eerste dia.  
1. Controleer of de vorm een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑instantie is.  
1. Doorloop alle knooppunten in de SmartArt‑vorm en controleer of ze [Assistant Nodes](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartnode/#isAssistant) zijn.  
1. Verander elk assistent‑knooppunt in een normaal knooppunt.  
1. Sla de presentatie op.

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
|**Figuur: Assistent‑knooppunten gewijzigd in een SmartArt‑vorm op een dia**|

## **Het vullingsformaat van een knooppunt instellen**
Aspose.Slides for Python via Java maakt het mogelijk om aangepaste SmartArt‑vormen toe te voegen en hun vullingsformaat in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen maakt, benadert en hun vullingsformaat instelt met Aspose.Slides for Python via Java.

Volg de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
1. Haal een dia op basis van de index op.  
1. Voeg een [SmartArt](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartart/)‑vorm met de [ClosedChevronProcess](https://reference.aspose.com/slides/nl/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess)‑lay‑out toe.  
1. Stel het [FillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getFillFormat) in voor de SmartArt‑vormknooppunten.  
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

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

## **Een miniatuur van een onderliggend SmartArt‑knooppunt genereren**
Volg deze stappen om een miniatuur van een onderliggend SmartArt‑knooppunt te genereren:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
1. [Voeg een SmartArt‑vorm toe](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addSmartArt).  
1. Haal een knooppunt op basis van de index op.  
1. Haal de miniatuur‑afbeelding op.  
1. Sla de miniatuur‑afbeelding op in elk gewenst beeldformaat.

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

**Wordt SmartArt‑animatie ondersteund?**

Ja. SmartArt wordt behandeld als een gewone vorm, zodat u [standaardanimaties](/slides/nl/python-java/shape-animation/) (invoer, uitgang, nadruk, bewegingspaden) kunt toepassen en de timing kunt aanpassen. U kunt desgewenst ook vormen binnen SmartArt‑knooppunten animeren.

**Hoe kan ik een specifiek SmartArt‑object op een dia betrouwbaar vinden als de interne ID onbekend is?**

Ken een [alternatieve tekst](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getAlternativeText) toe en zoek daarop. Het instellen van een kenmerkende alternatieve tekst op de SmartArt maakt het mogelijk deze programmatisch te vinden zonder afhankelijk te zijn van interne identifiers.

**Blijft de weergave van SmartArt behouden bij het converteren van de presentatie naar PDF?**

Ja. Aspose.Slides rendert SmartArt met hoge visuele nauwkeurigheid tijdens [PDF‑export](/slides/nl/python-java/convert-powerpoint-to-pdf/), waardoor lay‑out, kleuren en effecten behouden blijven.

**Kan ik een afbeelding van de volledige SmartArt extraheren (voor voorbeeldweergaven of rapporten)?**

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getImage) of naar [SVG](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#writeAsSvgToBytes) voor schaalbare vectoroutput, wat geschikt is voor miniaturen, rapporten of webgebruik.