---
title: Watermerken toevoegen aan presentaties in Python
linktitle: Watermerk
type: docs
weight: 40
url: /nl/python-java/watermark/
keywords:
- watermerk
- tekstwatermerk
- afbeeldingswatermerk
- watermerk toevoegen
- watermerk wijzigen
- watermerk verwijderen
- watermerk wissen
- watermerk toevoegen aan PPT
- watermerk toevoegen aan PPTX
- watermerk toevoegen aan ODP
- watermerk verwijderen uit PPT
- watermerk verwijderen uit PPTX
- watermerk verwijderen uit ODP
- watermerk wissen uit PPT
- watermerk wissen uit PPTX
- watermerk wissen uit ODP
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Beheer tekst- en afbeeldingswatermerken in PowerPoint- en OpenDocument-presentaties in Python om een concept, vertrouwelijke informatie, auteursrechten en meer aan te geven."
---
## **Inleiding**

**Een watermerk** in een presentatie is een tekst‑ of afbeeldingstempel die op een dia of op alle dia’s van de presentatie wordt gebruikt. Gewoonlijk wordt een watermerk gebruikt om aan te geven dat de presentatie een concept is (bijv. een “Draft” watermerk), dat deze vertrouwelijke informatie bevat (bijv. een “Confidential” watermerk), om te specificeren bij welk bedrijf deze hoort (bijv. een “Company Name” watermerk), om de auteur van de presentatie te identificeren, enz. Een watermerk helpt auteursrechtelijke overtredingen te voorkomen door aan te geven dat de presentatie niet gekopieerd mag worden. Watermerken worden gebruikt in zowel PowerPoint‑ als OpenOffice‑presentatieformaten. In Aspose.Slides kun je een watermerk toevoegen aan PowerPoint‑PPT, PPTX en OpenOffice‑ODP‑bestandsformaten.

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/python-java/), zijn er verschillende manieren om watermerken te maken in PowerPoint‑ of OpenOffice‑documenten en hun ontwerp en gedrag aan te passen. Het gemeenschappelijke punt is dat je voor tekstwatermerken de class [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) moet gebruiken, en voor afbeeldingwatermerken de class [PictureFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pictureframe/) of een watermerkvorm met een afbeelding vullen. [PictureFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pictureframe/) erft van de class [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/), waardoor je alle flexibele instellingen van het vormobject kunt gebruiken. Aangezien [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/) geen vorm is en zijn instellingen beperkt zijn, wordt het verpakt in een [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/)‑object.

Er zijn twee manieren om een watermerk toe te passen: op één enkele dia of op alle dia’s van de presentatie. De Slide Master wordt gebruikt om een watermerk op alle dia’s toe te passen — het watermerk wordt aan de Slide Master toegevoegd, daar volledig ontworpen, en op alle dia’s toegepast zonder de mogelijkheid om het watermerk op individuele dia’s te wijzigen.

Een watermerk wordt meestal beschouwd als niet‐bewerkbaar voor andere gebruikers. Om te voorkomen dat het watermerk (of beter gezegd de bovenliggende vorm van het watermerk) bewerkt wordt, biedt Aspose.Slides functie voor vergrendeling van vormen. Een specifieke vorm kan worden vergrendeld op een gewone dia of op een Slide Master. Wanneer de watermerkvorm op de Slide Master wordt vergrendeld, is deze vergrendeld op alle dia’s van de presentatie.

Je kunt een naam aan het watermerk geven zodat je het later, wanneer je het wilt verwijderen, kunt vinden in de vormen van de dia op basis van die naam.

Je kunt het watermerk op elke gewenste manier ontwerpen; er zijn echter doorgaans gemeenschappelijke kenmerken van watermerken, zoals centreren, roteren, voorgrondpositie, enz. We zullen in de onderstaande voorbeelden laten zien hoe je deze kunt gebruiken.

## **Tekstwatermerk**

### **Een tekstwatermerk aan een dia toevoegen**

Om een tekstwatermerk toe te voegen in PPT, PPTX of ODP, kun je eerst een vorm aan de dia toevoegen en vervolgens een tekstframe aan die vorm. Het tekstframe wordt vertegenwoordigd door de class [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/). Dit type erft niet van [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/), die een breed scala aan eigenschappen biedt voor het flexibel positioneren van het watermerk. Daarom wordt het [TextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/)‑object verpakt in een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/)‑object. Om tekst aan de vorm toe te voegen, gebruik je de [addTextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/#addTextFrame)‑methode zoals hieronder getoond.

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

{{% alert color="info" title="Opmerking" %}} 
- [How to Use the TextFrame Class](/slides/nl/python-java/text-formatting/)
{{% /alert %}}

### **Een tekstwatermerk aan een presentatie toevoegen**

Als je een tekstwatermerk aan de gehele presentatie wilt toevoegen (dus aan alle dia’s tegelijk), voeg je het toe aan de [MasterSlide](https://reference.aspose.com/slides/nl/python-java/aspose.slides/masterslide/). De rest van de logica is hetzelfde als bij het toevoegen van een watermerk aan één dia — maak een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/)‑object aan en voeg vervolgens het watermerk toe met de [addTextFrame](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/#addTextFrame)‑methode.

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

{{% alert color="info" title="Opmerking" %}} 
- [Hoe de Slide Master te gebruiken](/slides/nl/python-java/slide-master/)
{{% /alert %}}

### **Transparantie van watermerkvorm instellen**

Standaard is de rechthoekvorm opgemaakt met vul- en lijnkleuren. De volgende code maakt de vorm transparant.

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

### **Lettertype voor een tekstwatermerk instellen**

Je kunt het lettertype van het tekstwatermerk wijzigen zoals hieronder weergegeven.

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

### **Kleur van watermerktekst instellen**

Om de kleur van de watermerktekst in te stellen, gebruik je deze code:

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

### **Een tekstwatermerk centreren**

Het is mogelijk om het watermerk op een dia te centreren; daarvoor kun je het volgende doen:

```python
import jpade
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

De afbeelding hieronder toont het eindresultaat.

![Het tekstwatermerk](text_watermark.png)

## **Afbeeldingswatermerk**

### **Een afbeeldingswatermerk aan een presentatie toevoegen**

Om een afbeeldingswatermerk aan een presentatiedia toe te voegen, kun je het volgende doen:

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

### **Een watermerk tegen bewerken vergrendelen**

Indien het nodig is om te voorkomen dat een watermerk bewerkt wordt, gebruik je de [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/#getAutoShapeLock)‑methode op de vorm. Met deze eigenschap kun je de vorm beschermen tegen selectie, grootte‑aanpassing, verplaatsing, groeperen met andere elementen, vergrendeling van de tekst tegen bewerking, en meer:

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
    # Vergrendel de watermerkvorm tegen wijziging.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Een watermerk naar voren brengen**

In Aspose.Slides kan de Z‑volgorde van vormen worden ingesteld via de [ShapeCollection.reorder](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#reorder)‑methode. Hiervoor roep je deze methode aan vanuit de vormcollectie van de dia en geef je de vormreferentie en het ordernummer door. Op deze manier kun je een vorm naar voren brengen of naar de achtergrond verplaatsen. Deze functionaliteit is vooral nuttig als je een watermerk vooraan de presentatie wilt plaatsen:

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

### **Rotatie van watermerk instellen**

Hier is een codevoorbeeld om de rotatie van het watermerk zó aan te passen dat het diagonaal over de dia wordt geplaatst:

```python
import jpype
import asposeslides
import math

if not jpade.isJVMStarted():
    jpade.startJVM()

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

### **Een naam aan een watermerk geven**

Aspose.Slides maakt het mogelijk om de naam van een vorm in te stellen. Door de vormnaam te gebruiken kun je later de vorm benaderen om deze te wijzigen of te verwijderen. Om de naam van de watermerkvorm in te stellen, geef je deze door aan de [Shape.setName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#setName)‑methode:

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

### **Een watermerk verwijderen**

Om de watermerkvorm te verwijderen, gebruik je de [Shape.getName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getName)‑methode om deze in de vormen van de dia te vinden. Vervolgens geef je de watermerkvorm door aan de [ShapeCollection.remove](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#remove)‑methode:

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

## **Veelgestelde vragen**

**Wat is een watermerk en waarom zou ik het gebruiken?**

Een watermerk is een tekst‑ of afbeeldingsoverlay die op dia’s wordt toegepast om intellectueel eigendom te beschermen, merkherkenning te versterken of ongeoorloofd gebruik van presentaties te voorkomen.

**Kan ik een watermerk aan alle dia’s van een presentatie toevoegen?**

Ja, Aspose.Slides maakt het mogelijk om programmatically een watermerk aan elke dia van een presentatie toe te voegen. Je kunt door alle dia’s itereren en de watermerkinstellingen individueel toepassen.

**Hoe kan ik de transparantie van het watermerk aanpassen?**

Je kunt de transparantie van het watermerk aanpassen door de vulinstellingen ([getFillFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/#getFillFormat)) van de vorm te wijzigen. Hierdoor blijft het watermerk subtiel en storend minder.

**Welke beeldformaten worden ondersteund voor watermerken?**

Aspose.Slides ondersteunt diverse beeldformaten zoals PNG, JPEG, GIF, BMP, SVG en meer.

**Kan ik het lettertype en de stijl van een tekstwatermerk aanpassen?**

Ja, je kunt elk lettertype, grootte en stijl kiezen om aan het ontwerp van je presentatie te voldoen en de merkconsistentie te behouden.

**Hoe wijzig ik de positie of oriëntatie van een watermerk?**

Je kunt de positie en oriëntatie van het watermerk programmatically aanpassen door de coördinaten, grootte en rotatie‑eigenschappen van de vorm te wijzigen.