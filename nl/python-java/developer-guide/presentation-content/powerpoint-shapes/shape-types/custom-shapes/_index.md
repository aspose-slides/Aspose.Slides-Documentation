---
title: Aangepaste presentatievormen in Python via Java
linktitle: Aangepaste vorm
type: docs
weight: 20
url: /nl/python-java/custom-shape/
keywords:
- aangepaste vorm
- vorm toevoegen
- vorm maken
- vorm wijzigen
- vormgeometrie
- geometrisch pad
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
description: "Maak en pas vormen aan in PowerPoint-presentaties met Aspose.Slides voor Python via Java: geometrische paden, gebogen hoeken, samengestelde vormen."
---
## **Overzicht**

Dit artikel legt uit hoe je presentatiesvormen in Aspose.Slides kunt aanpassen door de vormgeometrie te bewerken via bewerkingspunten en geometrische paden. Het laat zien hoe je met [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) bestaande vormen kunt wijzigen, basisbewerkingsbewerkingen kunt uitvoeren, punten kunt toevoegen of verwijderen, en de bijgewerkte geometrie op een vorm kunt toepassen.

Het toont ook hoe je aangepaste en samengestelde vormen kunt maken, vormen met afgeronde hoeken kunt bouwen, kunt bepalen of een vormgeometrie gesloten is, vormelementen kunt inspecteren en Java AWT‑tekstcontouren in geometrische paden kunt omzetten.

## **Een Vorm Wijzigen met Bewerkingpunten**

In PowerPoint kun je **Bewerkingpunten** gebruiken om een vierkant te wijzigen:

* Een hoek naar binnen of naar buiten verplaatsen.
* De kromming op een punt aanpassen.
* Nieuwe punten toevoegen.

Bewerkingpunten laten je de omtrek van een vorm aanpassen of een bestaande vorm als basis voor een nieuwe gebruiken.

## **Tips voor Vormbewerking**

![overview_image](custom_shape_0.png)

Houd bij het bewerken van PowerPoint‑vormen de volgende concepten in gedachten:

* Een vorm (of het pad ervan) kan gesloten of open zijn.
* Het pad van een vorm bestaat uit ankerpunten die met segmenten zijn verbonden.
* Een segment kan recht of gebogen zijn. Ankerpunten en bediening handvatten bepalen de vorm.
* Ankerpunten bestaan als hoekpunten, rechte punten of soepele punten:
  * Bij een hoekpunt kunnen aangrenzende segmenten onder een hoek samenkomen.
  * Bij een soepel punt zijn de twee bediening handvatten uitgelijnd en op gelijke afstand van het ankerpunt.
  * Bij een recht punt zijn de twee bediening handvatten uitgelijnd maar kunnen ze verschillende afstanden tot het ankerpunt hebben.
* Het verplaatsen van ankerpunten of het aanpassen van hun handvatten wijzigt de omtrek van de vorm.

Om PowerPoint‑vormen via bewerkingspunten te bewerken, biedt **Aspose.Slides** de klasse [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* Een [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑instantie vertegenwoordigt een geometrisch pad van het object [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* Om het [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) op te halen van de [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)-instantie, kun je de methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) gebruiken.
* Om het [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) voor een vorm in te stellen, kun je deze methoden gebruiken: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) voor vormen met één enkel pad en [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) voor vormen met meerdere paden.
* Om segmenten toe te voegen, kun je de methoden onder [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) gebruiken.
* Met de methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) en [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) kun je het uiterlijk van een geometrisch pad instellen.
* Met de methode [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) kun je het geometrische pad van een [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) ophalen als een array van padsegmenten.
* Voor extra opties voor het aanpassen van vormgeometrie kun je een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) lezen via zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) en de segmenten afspelen op een [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Eenvoudige Bewerkingstaken**

Gebruik de volgende methoden om een geometrisch pad te bewerken. Overloads die een index accepteren, voegen een segment in op die nul‑gebaseerde positie in de segmentarray van het pad.

| Operatie | Methode |
| --- | --- |
| Een rechte lijn toevoegen of invoegen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Een kubieke Bézier‑curve met twee controlepunten en een eindpunt toevoegen of invoegen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Een kwadratische Bézier‑curve met één controlepunt en een eindpunt toevoegen of invoegen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Een elliptische boog met de opgegeven afmetingen en hoeken in graden toevoegen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| De huidige figuur sluiten door het eindpunt met het startpunt te verbinden. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Het startpunt van een figuur instellen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Een segment op een nul‑gebaseerde index verwijderen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Aangepaste Punten Toevoegen aan een Vorm**

Dit voorbeeld voegt twee punten in een rechthoekige vorm in met [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) en past het bewerkte pad toe met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). De coördinaten zijn lokaal ten opzichte van de vorm: beide nieuwe punten staan in het midden, 100 punten van de linkerkant en 50 punten van de bovenkant. Segmentindices 1 en 4 plaatsen ze op de boven‑ en onderranden, waardoor die randen naar binnen worden getrokken.

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

## **Punten Verwijderen uit een Vorm**

Dit voorbeeld wijzigt de omtrek van een hartvorm door het segment op nul‑gebaseerde index 2 te verwijderen met [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Het toepassen van het aangepaste pad met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) werkt de contour van de vorm bij.

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

## **Een Aangepaste Vorm Maken**

Dit voorbeeld bouwt een vijfpuntige ster met [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Afwisselend buiten- en binnentradii van respectievelijk 100 en 50 punten bepalen de topjes en inkepingen; een stap van 72 graden verdeelt de vijf topjes gelijkmatig. Het pad wordt gesloten met [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) en toegepast op een rechthoekige vorm met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), waardoor de bestaande omtrek wordt vervangen.

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

## **Een Samengestelde Aangepaste Vorm Maken**

Dit voorbeeld definieert twee gesloten [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑objecten voor respectievelijk het boven‑ en onderste derde deel van een vorm. Het toepassen van beide paden met [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) creëert één samengestelde vorm met een opening in het middelste derde deel.

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

## **Een Aangepaste Vorm met Gebogen Hoeken Maken**

Dit voorbeeld combineert rechte segmenten met [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) om een vorm met naar binnen gebogen hoeken te maken. Elke hoekgrootte stelt de breedte en hoogte van de boog in punten in, en de boog van –90 graden tekent een kwart‑ellips tegen de klok in. Het afgeronde pad wordt toegepast met [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), en de presentatie wordt opgeslagen in PPTX‑formaat.

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

## **Controleren Of een Vormgeometrie Gesloten Is**

De volgende helper controleert of elke niet‑lege geometrische pad eindigt met een sluitingssegment. Het leest [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) en vergelijkt het laatste segment‑[PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) met [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Het retourneert `False` wanneer er geen niet‑lege paden zijn. Deze controle kijkt naar het laatste commando van elk pad; hij inspecteert niet elke subfiguur binnen een pad. Het voorbeeld geeft `True` voor een rechthoek.

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

## **Inspectie van GeometryPath‑commando’s**

Download [contour.pptx](contour.pptx) en plaats het in de werkmap van de applicatie. De eerste vorm op de eerste dia heeft een rechte bovenrand, een kubieke Bézier‑curve en een rechte sluitingsrand. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) om de paden van de vorm te lezen en [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) om de segmenten van elk pad in tekenvolgorde te lezen. Voor elk segment identificeert [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) het commando en bepaalt hoe de waarden die door [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData) worden geretourneerd, geïnterpreteerd moeten worden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

De vorm staat op (200, 100) punten op de dia. De gerapporteerde coördinaten zijn lokaal ten opzichte van de vorm, met (0, 0) in de linkerbovenhoek, x stijgt naar rechts en y naar beneden. Het sluitingssegment keert terug naar het startpunt zonder extra coördinaten.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Geometrische Vormelementen Uithalen en Inspecteren**

Gebruik [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) om een bestaande vorm te inspecteren als elementen die padpunten en punt‑types bevatten. Cast elk teruggegeven element naar [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) met `jpype.JObject` om de punt‑ en type‑arrays op te halen via de methoden [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) en [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes). Deze weergave is nuttig voor contouranalyse of om geometrie door te geven aan aangepaste tekengereedschappen.

Het voorbeeld opent input.pptx, vindt de eerste geometry‑vorm rechtstreeks op de eerste dia, en drukt de padsegmenten af. Gebruik een presentatie met een vorm die zowel rechte als gebogen segmenten bevat om beide soorten output te zien. Het zoekt niet binnen groepen.

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
                    i += 2  # Verbruik beide controlepunten en het eindpunt.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

De arrays corresponderen per index: `points[i]` is een punt en `types[i]` beschrijft de rol. Type `0` start een figuur, en type `1` trekt een lijn van het vorige punt naar het huidige punt. Een kubiek Bézier‑segment start bij het vorige eindpunt en gebruikt drie opeenvolgende type‑`3`‑items: twee controlepunten gevolgd door het nieuwe eindpunt. De lus verwerkt deze drie items samen en controleert het eindpunt op sluiting.

Punt‑types bevatten ook vlaggen. Maskeer met `0x07` om het segmenttype te identificeren, en test `0x80` apart om een gesloten subpad te detecteren. Bijvoorbeeld, `129` (`0x81`) betekent een lijn‑eindpunt dat een subpad sluit, en `131` (`0x83`) betekent een Bézier‑eindpunt dat een subpad sluit. Java slaat deze vlaggen op in signed bytes; maskeren behoudt de bedoelde bitwaarden. Alleen de ruwe waarde vergelijken met `1` of `3` zou deze gevallen missen. Andere vlaggen, zoals dash (`0x10`) en marker (`0x20`), veranderen het basistype van het segment niet.

**Coördinaten en transformaties.** Punten worden gemeten in points (1/72 inch), met X die naar rechts toe groeit en Y die naar beneden toe groeit. Voor een niet‑gegroepeerde vorm omvatten de geëxtraheerde coördinaten al de positie die wordt geretourneerd door [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) en [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) en weerspiegelen ze de huidige breedte en hoogte. Bijvoorbeeld, een niet‑geroteerde rechthoek op `(100, 200)` met grootte `120 × 80` heeft contourgrenzen `(100, 200)`–`(220, 280)`. Voeg de positie van de vorm niet opnieuw toe. Trek X en Y af om coördinaten te verkrijgen relatief ten opzichte van het ongeroteerde frame.

De geëxtraheerde punten houden geen rekening met de rotatie van de vorm, geretourneerd door [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), of horizontale en verticale spiegels. Om de weergegeven contour te reproduceren, moet je die transformaties toepassen rond het midden van de vorm. Voor gegroepeerde vormen moet je ook rekening houden met de coördinatenmapping en transformaties van de groep; ga er niet van uit dat de geëxtraheerde punten de definitieve gerenderde dia‑coördinaten zijn of dat je een translatie of schaal twee keer moet toepassen als dit al in het kind‑frame is verwerkt.

**Inspectie versus bewerking.** Geëxtraheerde arrays beschrijven de contour; wijzigen ervan werkt de oorspronkelijke vorm niet bij. Kies deze aanpak wanneer je analyse‑ of tekencode punt‑/type‑arrays nodig heeft. Gebruik [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) wanneer je geometrie‑commando’s in het lokale coördinatensysteem van de vorm nodig hebt of wanneer je de geometrie wilt bewerken. Pas bewerkte paden toe via [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) of [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Een Java AWT‑Vorm Omzetten naar GeometryPath**

Dit voorbeeld combineert een rechthoekige omtrek met tekst die is omgezet naar geometrie. De [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode)‑methode van de omtrek schakelt de vulling uit. Een [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) maakt de tekstopzetting in een [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Zijn [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levert verplaatsings‑, lijn‑, kwadratische, kubieke en sluitingssegmenten, die het voorbeeld afspeelt op een [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

De tekst gebruikt een Arial‑lettertype van 40 points. De omtrek wordt horizontaal 20 points verschoven en met de visuele bovenrand 10 points onder de bovenrand van de vorm gepositioneerd. Het tekstpad wordt gevuld, terwijl de oorspronkelijke rechthoek een omtrek blijft. Het toepassen van beide paden met [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) levert één vorm op die de rechthoek en de tekst bevat.

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

    # Haal het geometrische pad van de vorm op.
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

    # Converteer het grafische pad naar een geometrisch pad.
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

    # Pas het tekstpad samen met het oorspronkelijke geometrische pad toe.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Wat gebeurt er met de vulling en de omtrek na het vervangen van de geometrie?**

De stijl blijft bij de vorm; alleen de contour verandert. De vulling en de omtrek worden automatisch op de nieuwe geometrie toegepast.

**Hoe roteer ik een aangepaste vorm correct samen met zijn geometrie?**

Gebruik de methode [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) van de vorm; de geometrie roteert mee omdat deze gebonden is aan het eigen coördinatensysteem van de vorm.

**Kan ik een aangepaste vorm omzetten naar een afbeelding om het resultaat te “vergrendelen”?**

Ja. Exporteer het benodigde [slide](/slides/nl/python-java/convert-powerpoint-to-png/)‑gebied of de [shape](/slides/nl/python-java/create-shape-thumbnails/) zelf naar een rasterformaat; dit vereenvoudigt verdere bewerking met complexe geometrieën.