---
title: Anpassa presentationsformer i Python via Java
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/python-java/custom-shape/
keywords:
- anpassad form
- lägg till form
- skapa form
- ändra form
- formgeometri
- geometrisk bana
- banpunkter
- redigera punkter
- lägg till punkt
- ta bort punkt
- redigeringsoperation
- böjt hörn
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint-presentationer med Aspose.Slides för Python via Java: geometriska banor, böjda hörn, sammansatta former."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formgeometri via redigeringspunkter och geometriska banor. Den visar hur du arbetar med [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) för att ändra befintliga former, utföra grundläggande banredigeringsoperationer, lägga till eller ta bort punkter och tillämpa uppdaterad geometri på en form.

Den visar också hur du skapar anpassade och sammansatta former, bygger former med böjda hörn, avgör om en formgeometri är sluten, granskar formelement och konverterar Java AWT-textkonturer till geometriska banor.

## **Ändra en form med redigeringspunkter**

* Flytta ett hörn inåt eller utåt.
* Justera krökningen på en punkt.
* Lägg till nya punkter.

Att redigera punkter låter dig ändra en forms kontur eller använda en befintlig form som grund för en ny.

## **Tips för formredigering**

![overview_image](custom_shape_0.png)

När du redigerar PowerPoint‑former, håll dessa begrepp i åtanke:

* En form (eller dess bana) kan antingen vara sluten eller öppen.
* En formes bana består av ankarnpunkter som är sammanlänkade med segment.
* Ett segment kan vara rakt eller krökt. Ankarnpunkter och kontrollhandtag bestämmer dess form.
* Ankarnpunkter finns som hörnpunkter, raka punkter eller släta punkter:
  * På en hörnpunkt kan intilliggande segment mötas i en vinkel.
  * På en slät punkt är de två kontrollhandtagen i linje och lika avlägsna från ankarnpunkten.
  * På en rak punkt är de två kontrollhandtagen i linje men kan ha olika avstånd från ankarnpunkten.
* Att flytta ankarnpunkter eller justera deras handtag ändrar formens kontur.

För att redigera PowerPoint‑former via redigeringspunkter tillhandahåller **Aspose.Slides** klassen [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

* En [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑instans representerar en geometrisk bana för objektet [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/).
* För att hämta [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) från [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)-instansen kan du använda metoden [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* För att ange [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) för en form kan du använda dessa metoder: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) för former med en enda bana och [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) för former med flera banor.
* För att lägga till segment kan du använda metoderna under [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).
* Med metoderna [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) och [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) kan du ange utseendet för en geometrisk bana.
* Med metoden [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) kan du hämta geometribanan för en [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) som en matris av bansegment.
* För att få tillgång till ytterligare anpassningsalternativ för formgeometri kan du läsa ett [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) via dess [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) och återupprepa segmenten på en [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

## **Enkla redigeringsoperationer**

Använd följande metoder för att redigera en geometrisk bana. Överlagringar som tar emot ett index sätter in ett segment på den nollbaserade positionen i banans segmentmatris.

| Operation | Metod |
| --- | --- |
| Lägg till eller infoga en rak linje. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Lägg till eller infoga en kubisk Bézier‑kurva med två kontrollpunkter och en slutpunkt. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Lägg till eller infoga en kvadratisk Bézier‑kurva med en kontrollpunkt och en slutpunkt. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Lägg till en elliptisk båge med angivna dimensioner och vinklar i grader. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Stäng den aktuella figuren genom att koppla dess slutpunkt till startpunkten. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Ange startpunkten för en figur. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Ta bort ett segment på ett nollbaserat index. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Lägg till anpassade punkter till en form**

Detta exempel infogar två punkter i en rektangulär form med hjälp av [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) och tillämpar den redigerade banan med [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath). Koordinaterna är lokala för formen: båda nya punkterna ligger i dess centrum, 100 punkter från vänster och 50 punkter från toppen. Segmentindex 1 och 4 placerar dem på den övre och nedre kanten och drar dessa kanter inåt.

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

## **Ta bort punkter från en form**

Detta exempel ändrar en hjärtformad kontur genom att ta bort segmentet på nollbaserat index 2 med [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt). Att tillämpa den modifierade banan med [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) uppdaterar formens kontur.

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

## **Skapa en anpassad form**

Detta exempel bygger en femtoppig stjärna med [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Växlande yttre och inre radier på 100 och 50 punkter definierar spetsarna och fördjupningarna; ett steg på 72 grader placerar de fem spetsarna jämnt. Banan stängs med [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) och tillämpas på en rektangulär form med [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), vilket ersätter dess kontur.

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

## **Skapa en sammansatt anpassad form**

Detta exempel definierar två stängda [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑objekt för den övre och nedre tredjedelen av en form. Att tillämpa båda banorna med [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) skapar en enda sammansatt form med ett gap över dess mitttredje.

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

## **Skapa en anpassad form med böjda hörn**

Detta exempel kombinerar raka segment med [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) för att skapa en form med inåtböjda hörn. Varje hörnstorlek anger bågens bredd och höjd i punkter, och -90‑gradssvepet ritar en moturs kvartselips. Den färdiga banan tillämpas med [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath), och presentationen sparas i PPTX‑format.

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

## **Ta reda på om en formgeometri är sluten**

Följande hjälpfunktion kontrollerar om varje icke‑tom geometrisk bana avslutas med ett slutsegment. Den läser [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) och jämför sista segmentets [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) med [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Den returnerar `False` när det inte finns några icke‑tomma banor. Denna kontroll granskar det sista kommandot för varje bana; den inspekterar inte varje underfigur inom en bana. Exemplet skriver ut `True` för en rektangel.

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

## **Inspektera geometribankommando**

Ladda ner [contour.pptx](contour.pptx) och placera den i applikationens arbetskatalog. Den första formen på den första bilden har en rak överkant, en kubisk Bézier‑kurva och en rak slutkant. Använd [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) för att läsa formens banor och [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) för att läsa varje bana's segment i ritningsordning. För varje segment identifierar [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) kommandot och bestämmer hur värdena som returneras av [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData) ska tolkas.

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

Formen sitter på (200, 100) punkter på bilden. De rapporterade koordinaterna är lokala för formen, med (0, 0) i dess övre vänstra hörn, x ökar åt höger och y ökar nedåt. Det avslutande segmentet återgår till startpunkten utan ytterligare koordinater.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint-form med en rak överkant, en böjd kant från övre högra till nedre vänstra, och en rak vänsterkant](contour.png)

## **Extrahera och inspektera formelement**

Använd [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) för att inspektera en befintlig form som element som innehåller banpunkter och punkttyper. Casta varje returnerat element till [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) med `jpype.JObject` för att hämta punkt- och typmatriserna via [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) och [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes)-metoderna. Denna representation är användbar för konturanalys eller för att skicka geometri till anpassade ritverktyg.

Exemplet öppnar input.pptx, hittar den första geometriformen direkt på den första bilden och skriver ut dess bansegment. Använd en presentation som innehåller en form med raka och böjda segment för att se båda typerna av utskrift. Det söker inte i grupper.

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
                point_type = types[i] & 0x07  # Keep the segment type, excluding flags.
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

Arrayerna motsvarar varandra enligt index: `points[i]` är en punkt och `types[i]` beskriver dess roll. Typ `0` startar en figur, och typ `1` ritar en linje från föregående punkt till den aktuella. Ett kubiskt Bézier‑segment startar vid föregående slutpunkt och använder tre på varandra följande typ‑`3`‑poster: två kontrollpunkter följda av den nya slutpunkten. Loopen konsumerar dessa tre poster tillsammans och kontrollerar slutpunkten för slutenhet.

Punkttyperna innehåller också flaggor. Maskera med `0x07` för att identifiera segmenttypen och testa `0x80` separat för att upptäcka ett stängt delspår. Till exempel betyder `129` (`0x81`) en linjeslutpunkt som stänger ett delspår, och `131` (`0x83`) betyder en Bézier‑slutpunkt som stänger ett sådant. Java lagrar dessa flaggor i signerade bytes; maskering bevarar de avsedda bitvärdena. Att jämföra det råa värdet endast med `1` eller `3` skulle missa dessa fall. Andra flaggor, såsom streck (`0x10`) och markör (`0x20`), förändrar inte bassegmenttypen.

**Koordinater och transformationer.** Punkter mäts i punkter (1/72 tum), med X som ökar åt höger och Y som ökar nedåt. För en icke‑grupperad form inkluderar de extraherade koordinaterna redan positionen som returneras av [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) och [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) och återspeglar dess nuvarande bredd och höjd. Till exempel har en oroterad rektangel vid `(100, 200)` med storlek `120 × 80` konturboundar `(100, 200)`–`(220, 280)`. Lägg inte till formens position igen. Subtrahera dess X och Y för att få koordinater relativt till dess oroterade ram.

De extraherade punkterna applicerar inte formens rotation, som returneras av [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation), eller horisontella och vertikala speglingar. För att reproducera den visade konturen, tillämpa dessa transformationer kring formens centrum. För grupperade former, ta även hänsyn till gruppens koordinatmappning och transformationer; anta inte att de extraherade punkterna är de slutgiltiga renderade bildkoordinaterna eller applicera en translation eller skala två gånger om den redan reflekteras i barnets ram.

**Inspektion vs redigering.** Extraherade arrayer beskriver konturen; att ändra dem uppdaterar inte den ursprungliga formen. Välj detta tillvägagångssätt när din analys‑ eller ritkod behöver punkt‑/typ‑arrayer. Använd [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) när du behöver geometrikommando i formens lokala koordinatsystem eller vill redigera dess geometri. Tillämpa redigerade banor via [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) eller [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths).

## **Konvertera en Java AWT-form till GeometryPath**

Detta exempel kombinerar en rektangulär kontur med text som konverterats till geometri. Konturens [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode)-metod inaktiverar dess fyllning. En [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) skapar textkonturen i ett [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Dess [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) levererar flytt-, linje-, kvadratiska-, kubiska- och stängningssegment, vilka exemplet återupprepar på en [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/).

Texten använder ett 40‑punkts Arial‑typsnitt. Konturen är förskjuten 20 punkter horisontellt och placerad så att dess visuella topp är 10 punkter under formens övre kant. Textbanan är fylld, medan den ursprungliga rektangeln förblir en kontur. Att tillämpa båda banorna med [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) skapar en enda form som innehåller rektangeln och texten.

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

    # Hämta geometribanan för formen.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Skapa en ny grafikbana med text.
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

    # Konvertera grafikbanan till en geometribana.
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

    # Tillämpa textbanan tillsammans med den ursprungliga geometribanan.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Vad händer med fyllningen och konturen efter att geometrin har ersatts?**

Stilen förblir på formen; endast konturen ändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag en anpassad form korrekt tillsammans med dess geometri?**

Använd formens [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation)-metod; geometrin roterar med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att "låsa" resultatet?**

Ja. Exportera det önskade [slide](/slides/sv/python-java/convert-powerpoint-to-png/)-området eller själva [shape](/slides/sv/python-java/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med komplexa geometrier.