---
title: Aangepaste presentatieshapes in Python via Java
linktitle: Aangepaste shape
type: docs
weight: 20
url: /nl/python-java/custom-shape/
keywords:
- aangepaste shape
- shape toevoegen
- shape maken
- shape wijzigen
- shape geometrie
- geometriepad
- padpunten
- bewerkingspunten
- punt toevoegen
- punt verwijderen
- bewerkingsoperatie
- afgeronde hoek
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Maak en pas shapes aan in PowerPoint-presentaties met Aspose.Slides voor Python via Java: geometrie-paden, afgeronde hoeken, samengestelde shapes."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatieshape‑geometrieën in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometriepaden. Het laat zien hoe je met [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) bestaande shapes kunt wijzigen, basisbewerkingsbewerkingen kunt uitvoeren, punten kunt toevoegen of verwijderen, en de bijgewerkte geometrie terug op een shape kunt toepassen.

Het laat ook zien hoe je aangepaste en samengestelde shapes maakt, shapes bouwt met afgeronde hoeken, bepaalt of een shape‑geometrie gesloten is, shape‑elementen inspecteert, en Java AWT‑tekstcontouren converteert naar geometriepaden.

## **Een vorm wijzigen met bewerkingspunten**

* Een hoek naar binnen of naar buiten verplaatsen.
* De kromming op een punt aanpassen.
* Nieuwe punten toevoegen.

Bewerkingspunten laten je de omtrek van een shape wijzigen of een bestaande shape gebruiken als basis voor een nieuwe.

## **Tips voor shape‑bewerking**

![overview_image](custom_shape_0.png)

Wanneer je PowerPoint‑shapes bewerkt, houd dan rekening met de volgende concepten:

* Een shape (of het pad) kan zowel gesloten als geopend zijn.
* Het pad van een shape bestaat uit ankerpunten die met segmenten verbonden zijn.
* Een segment kan recht of gekromd zijn. Ankerpunten en controlehandvatten bepalen de vorm.
* Ankerpunten komen voor als hoekpunten, rechte punten of vloeiende punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een vloeiend punt zijn de twee controlehandvatten uitgelijnd en even ver van het ankerpunt verwijderd.
  * Bij een recht punt zijn de twee controlehandvatten uitgelijnd maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten verandert de omtrek van de shape.

Om PowerPoint‑shapes via bewerkingspunten te bewerken, biedt **Aspose.Slides** de [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑klasse.

* Een [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometrie‑pad van het [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)‑object.
* Om het [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) van een [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)‑instantie op te halen, kun je de methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) gebruiken.
* Om het [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) voor een shape in te stellen, kun je de methoden [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) voor shapes met één pad en [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) voor shapes met meerdere paden gebruiken.
* Om segmenten toe te voegen, kun je de methoden onder [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) gebruiken.
* Met de methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) en [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) kun je het uiterlijk van een geometrie‑pad instellen.
* Met de methode [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) kun je het geometrie‑pad van een [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) als een array van padsegmenten ophalen.
* Om meer opties voor shape‑geometrie‑aanpassing te benaderen, kun je een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) lezen via zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) en de segmenten opnieuw afspelen op een [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Eenvoudige bewerkingsbewerkingen**

Gebruik de volgende methoden om een geometrie‑pad te bewerken. Overloads die een index accepteren, voegen een segment in op die nulgebaseerde positie in de segmentarray van het pad.

| Operatie | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Een kubieke Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Een elliptische boog toevoegen met de opgegeven afmetingen en hoeken in graden. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| De huidige figuur afsluiten door het eindpunt met het startpunt te verbinden. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Het startpunt van een figuur instellen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Een segment op een nulgebaseerde index verwijderen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Aangepaste punten toevoegen aan een shape**

Dit voorbeeld voegt twee punten in een rechthoekige shape in met [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) en past het bewerkte pad toe met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). De coördinaten zijn lokaal ten opzichte van de shape: beide nieuwe punten liggen in het midden, 100 punten van links en 50 punten van boven. Segmentindices 1 en 4 plaatsen ze respectievelijk op de boven‑ en onderkant, waardoor die randen naar binnen worden getrokken.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **Punten verwijderen uit een shape**

Dit voorbeeld wijzigt een hartvormige omtrek door het segment op nulgebaseerde index 2 te verwijderen met [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Het toepassen van het gewijzigde pad met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) werkt de contour van de shape bij.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **Een aangepaste shape maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Afwisselend buiten- en binnentradius van respectievelijk 100 en 50 punten definiëren de topjes en inkepingen; een stap van 72 graden verdeelt de vijf topjes gelijkmatig. Het pad wordt gesloten met [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) en toegepast op een rechthoekige shape met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), waardoor de oorspronkelijke omtrek wordt vervangen.

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
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **Een samengestelde aangepaste shape maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en onderste derde deel van een shape. Het toepassen van beide paden met [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) creëert één samengestelde shape met een opening door het middelste derde deel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

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

## **Een aangepaste shape met afgeronde hoeken maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) om een shape met naar binnen afgeronde hoeken te maken. Elke hoekgrootte bepaalt de breedte en hoogte van de boog in punten, en de sweep van –90 graden tekent een tegen‑klokke vierkwadrant‑ellipse. Het voltooide pad wordt toegepast met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), en de presentatie wordt opgeslagen in PPTX‑formaat.

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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

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

## **Controleren of een shape‑geometrie gesloten is**

De volgende helper controleert of elke niet‑lege geometrie‑pad eindigt met een sluit‑segment. Hij leest [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) en vergelijkt het laatste segment‑[PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) met [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Hij retourneert `False` wanneer er geen niet‑lege paden zijn. Deze controle bekijkt alleen het laatste commando van elk pad; hij inspecteert niet elk subfiguur binnen een pad. Het voorbeeld print `True` voor een rechthoek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **Shape‑elementen extraheren en inspecteren**

Gebruik [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) om een bestaande shape te inspecteren als elementen die padpunten en punt‑types bevatten. Cast elk geretourneerd element naar [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) met `jpype.JObject` om de punt‑ en type‑arrays op te halen via [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) en [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Deze representatie is nuttig voor contouranalyse of om geometrie door te geven aan aangepaste teken‑tools.

Het voorbeeld opent `input.pptx`, zoekt de eerste geometrie‑shape direct op de eerste dia, en print de path‑segmenten. Gebruik een presentatie met een shape die rechte en gekromde segmenten bevat om beide soorten output te zien. Het zoekt niet binnen groepen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # Houd het segmenttype, exclusief vlaggen.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

De arrays corresponderen op index: `points[i]` is een punt en `types[i]` beschrijft de rol. Type `0` start een figuur, en type `1` tekent een lijn van het vorige punt naar het huidige punt. Een kubieke Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert het eindpunt op afsluiting.

Punt‑types bevatten ook vlaggen. Masker met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat er een sluit. Java slaat deze vlaggen op in signed bytes; maskeren behoudt de bedoelde bitwaarden. Alleen vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), wijzigen het basistype niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), met X die naar rechts toeneemt en Y die naar beneden toeneemt. Voor een ongegroepeerde shape bevatten de geëxtraheerde coördinaten al de positie die wordt geretourneerd door [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) en [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) en weerspiegelen ze de huidige breedte en hoogte. Bijvoorbeeld, een niet‑geroteerde rechthoek op `(100, 200)` met grootte `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de shape niet opnieuw toe. Trek X en Y af om coördinaten te verkrijgen relatief ten opzichte van het onge­ro­teerde frame.

De geëxtraheerde punten houden geen rekening met de rotatie van de shape, geretourneerd door [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), of horizontale en verticale spiegels. Om de getoonde contour te reproduceren, pas die transformaties rond het middelpunt van de shape toe. Voor gegroepeerde shapes moet je ook rekening houden met de coördinaten‑mapping en transformaties van de groep; ga er niet van uit dat de geëxtraheerde punten de definitieve gerenderde slide‑coördinaten zijn of pas een translatie of schaal twee keer toe als die al in het kind‑frame zit.

**Inspectie versus bewerking.** Geëxtraheerde arrays beschrijven de contour; wijzigen ervan werkt de originele shape niet bij. Kies deze aanpak wanneer je analyse‑ of teken‑code point/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) wanneer je geometrie‑commando’s in het lokale coördinatensysteem van de shape wilt of wanneer je de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) of [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Een Java AWT‑shape naar GeometryPath converteren**

Dit voorbeeld combineert een rechthoekige omtrek met tekst die naar geometrie wordt geconverteerd. De omtrek‑[setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode)‑methode deactiveert de vulling. Een [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) creëert de tekst‑omtrek in een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Het bijbehorende [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levert verplaatsings‑, lijn‑, kwadratische, kubieke en sluit‑segmenten, die het voorbeeld opnieuw afspeelt op een [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

De tekst gebruikt een Arial‑lettertype van 40 points. De omtrek wordt horizontaal 20 points verschoven en verticaal zo geplaatst dat de visuele bovenkant 10 points onder de bovenrand van de shape ligt. Het tekstpad wordt ingevuld, terwijl de oorspronkelijke rechthoek een omtrek blijft. Het toepassen van beide paden met [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) levert één shape op die zowel de rechthoek als de tekst bevat.

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
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Haal het geometriepad van de shape op.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Maak een nieuw grafisch pad met tekst.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # Converteer het grafische pad naar een geometriepad.
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

    # Pas het tekstpad toe samen met het oorspronkelijke geometriepad.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Wat gebeurt er met de vulling en omtrek nadat de geometrie is vervangen?**

De stijl blijft aan de shape gekoppeld; alleen de contour verandert. Vulling en omtrek worden automatisch toegepast op de nieuwe geometrie.

**Hoe roteer ik een aangepaste shape correct samen met zijn geometrie?**

Gebruik de [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation)‑methode van de shape; de geometrie roteert mee omdat die gebonden is aan het eigen coördinatensysteem van de shape.

**Kan ik een aangepaste shape naar een afbeelding converteren om het resultaat te “vergrendelen”?**

Ja. Exporteer het gewenste [dia](/slides/nl/python-java/convert-powerpoint-to-png/) of de [shape](/slides/nl/python-java/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verdere verwerking van complexe geometrieën.