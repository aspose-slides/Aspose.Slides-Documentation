---
title: Aangepaste presentatievormen in Python via Java
linktitle: Aangepaste Vorm
type: docs
weight: 20
url: /nl/python-java/custom-shape/
keywords:
- aangepaste vorm
- vorm toevoegen
- vorm maken
- vorm wijzigen
- vorm geometrie
- geometriepad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- gebogen hoek
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak en pas vormen aan in PowerPoint-presentaties met Aspose.Slides voor Python via Java: geometrie-paden, gebogen hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe u presentatievormen in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometrische paden. Het laat zien hoe u met [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/) kunt werken om bestaande vormen te wijzigen, basisbewerkingsbewerkingen uit te voeren, punten toe te voegen of te verwijderen, en de bijgewerkte geometrie weer op een vorm toe te passen.

Het toont ook hoe u aangepaste en samengestelde vormen kunt maken, vormen met gebogen hoeken kunt bouwen, kunt bepalen of een vormgeometrie gesloten is, en hoe u tussen [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/) en [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) kunt converteren voor extra geometrie‑aanpassingsscenario's.

## **Vorm Wijzigen met Bewerkingspunten**

Beschouw een vierkant. In PowerPoint kunt u met **bewerkingspunten** 

* de hoek van het vierkant naar binnen of buiten verplaatsen
* de kromming van een hoek of punt specificeren
* nieuwe punten aan het vierkant toevoegen
* punten op het vierkant manipuleren, enz. 

In wezen kunt u de beschreven handelingen op elke vorm uitvoeren. Met bewerkingspunten kunt u een vorm wijzigen of een nieuwe vorm maken op basis van een bestaande vorm. 

## **Tips voor Vormbewerking**

![overview_image](custom_shape_0.png)

Voordat u begint met het bewerken van PowerPoint‑vormen via bewerkingspunten, wilt u wellicht de volgende punten over vormen overwegen:

* Een vorm (of het pad ervan) kan zowel gesloten als open zijn.
* Wanneer een vorm gesloten is, heeft ze geen begin‑ of eindpunt. Wanneer een vorm open is, heeft ze een begin en een einde. 
* Alle vormen bestaan uit minstens 2 ankerpunten die met elkaar verbonden zijn door lijnen.
* Een lijn is recht of gebogen. Ankerpunten bepalen de aard van de lijn. 
* Ankerpunten bestaan uit hoekpunten, rechte punten of vloeiende punten:
  * Een hoekpunt is een punt waar twee rechte lijnen samenkomen onder een hoek. 
  * Een vloeiend punt is een punt waar twee handvatten zich langs een rechte lijn bevinden en de segmenten van de lijn samenkomen in een vloeiende boog. In dit geval staan alle handvatten op gelijke afstand van het ankerpunt. 
  * Een recht punt is een punt waar twee handvatten zich langs een rechte lijn bevinden en de segmenten van die lijn samenkomen in een vloeiende boog. In dit geval hoeven de handvatten niet op gelijke afstand van het ankerpunt te staan. 
* Door ankerpunten te verplaatsen of te bewerken (wat de hoek van de lijnen verandert), kunt u de vorm van een vorm aanpassen. 

Om PowerPoint‑vormen via bewerkingspunten te bewerken, biedt **Aspose.Slides** de [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/)‑klasse. 

* Een [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometriepaden van het [GeometryShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/)‑object. 
* Om de [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/) van de [GeometryShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/)‑instantie op te halen, kunt u de methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/#getGeometryPaths) gebruiken. 
* Om de [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/) voor een vorm in te stellen, kunt u deze methoden gebruiken: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/#setGeometryPath) voor *solid shapes* en [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/#setGeometryPaths) voor *composite shapes*.
* Om segmenten toe te voegen, kunt u de methoden onder [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/) gebruiken. 
* Met behulp van de methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/#setStroke) en [GeometryPath.setFillMode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/#setFillMode) kunt u het uiterlijk van een geometriepaden instellen.
* Met de methode [GeometryPath.getPathData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/#getPathData) kunt u de geometriepaden van een [GeometryShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/) ophalen als een array van padsegmenten. 
* Om toegang te krijgen tot extra aanpassingsopties voor vormgeometrie, kunt u [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/) naar [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) converteren
* Gebruik [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeutil/) en [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeutil/) methoden (van de [ShapeUtil](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapeutil/)‑klasse) om [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/) naar [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) en terug te converteren. 

## **Eenvoudige Bewerkingstaken**

De volgende handtekeningen tonen de basisbewerkingen:

**Een lijn toevoegen aan het einde van een pad:**

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Een lijn toevoegen op een opgegeven positie op een pad:**

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Een kubieke Bézier‑curve toevoegen aan het einde van een pad:**

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Een kubieke Bézier‑curve toevoegen op de opgegeven positie op een pad:**

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Een kwadratische Bézier‑curve toevoegen aan het einde van een pad:**

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Een kwadratische Bézier‑curve toevoegen op de opgegeven positie op een pad:**

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Een opgegeven boog aan een pad toevoegen:**

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**De huidige figuur van een pad afsluiten:**

- `geometry_path.closeFigure()`

**De positie voor het volgende punt instellen:**

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Het padsegment op een gegeven index verwijderen:**

- `geometry_path.removeAt(index)`


## **Aangepaste Punten Aan een Vorm Toevoegen**
1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/)‑klasse en stel het type [ShapeType.Rectangle](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#Rectangle) in.
2. Haal een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/)‑klasse op van de vorm.
3. Voeg een nieuw punt toe tussen de twee bovenste punten van het pad.
4. Voeg een nieuw punt toe tussen de twee onderste punten van het pad.
5. Pas het pad toe op de vorm.

Deze Python‑code laat zien hoe u aangepaste punten aan een vorm toevoegt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example1_image](custom_shape_1.png)

## **Punten Verwijderen van een Vorm**

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/)‑klasse en stel het type [ShapeType.Heart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#Heart) in. 
2. Haal een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/)‑klasse op van de vorm.
3. Verwijder het segment van het pad.
4. Pas het pad toe op de vorm.

Deze Python‑code laat zien hoe u punten van een vorm verwijdert:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)
    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)
    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Een Aangepaste Vorm Maken**

1. Bereken de punten voor de vorm.
2. Maak een instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/)‑klasse. 
3. Vul het pad met de punten.
4. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/)‑klasse. 
5. Pas het pad toe op de vorm.

Deze Python‑code laat zien hoe u een aangepaste vorm maakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
step = 72

for angle in range(-90, 270, step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)


## **Een Samengestelde Aangepaste Vorm Maken**

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/)‑klasse.
2. Maak een eerste instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/)‑klasse.
3. Maak een tweede instantie van de [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/)‑klasse.
4. Pas de paden toe op de vorm.

Deze Python‑code laat zien hoe u een samengestelde aangepaste vorm maakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **Een Aangepaste Vorm Met Gebogen Hoeken Maken**

Deze Python‑code laat zien hoe u een aangepaste vorm met gebogen hoeken (naar binnen) maakt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)
    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    shape.setGeometryPath(geometry_path)
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nagaan of een Vormgeometrie Gesloten Is**

Een gesloten vorm wordt gedefinieerd als een vorm waarbij al haar zijden met elkaar verbonden zijn, waardoor één enkele rand zonder gaten ontstaat. Zo’n vorm kan een eenvoudige geometrische vorm zijn of een complex aangepast omrande. Het volgende code‑voorbeeld laat zien hoe u kunt controleren of een vormgeometrie gesloten is:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType

def is_geometry_closed(geometry_shape):
    is_closed = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        is_closed = last_segment.getPathCommand() == PathCommandType.Close
        if not is_closed:
            return False
    return is_closed
```

## **GeometryPath Converteren naar java.awt.Shape** 

1. Maak een instantie van de [GeometryShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometryshape/)‑klasse.
2. Maak een instantie van de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)‑klasse.
3. Converteer de [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)‑instantie naar de [GeometryPath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/geometrypath/)‑instantie door zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) te doorlopen en elk segment op het pad opnieuw af te spelen.
4. Pas de paden toe op de vorm.

Deze Python‑code implementeert de bovenstaande stappen om een grafisch pad naar een geometriepaden te converteren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    # Maak een nieuwe vorm.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Haal het geometriepaden van de vorm op.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Maak een nieuw grafisch pad met tekst.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Converteer het grafisch pad naar een geometriepaden.
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # Pas het tekstpad toe samen met het originele geometriepaden.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Wat gebeurt er met de vulling en omtrek na het vervangen van de geometrie?**

De stijl blijft bij de vorm; alleen de contour verandert. De vulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste vorm correct samen met zijn geometrie?**

Gebruik de setRotation‑methode van de vorm; de geometrie roteert mee met de vorm omdat deze gebonden is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm converteren naar een afbeelding om het resultaat vast te leggen?**

Ja. Exporteer het gewenste [slide](/slides/nl/python-java/convert-powerpoint-to-png/) gebied of de [shape](/slides/nl/python-java/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verder werk met complexe geometrieën.