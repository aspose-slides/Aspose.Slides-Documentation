---
title: Anpassa presentationsformer i Python via Java
linktitle: Anpassad form
type: docs
weight: 20
url: /sv/python-java/custom-shape/
keywords: 
- anpassad form
- lägga till form
- skapa form
- ändra form
- formgeometri
- geometribana
- banpunkter
- redigeringspunkter
- lägga till punkt
- ta bort punkt
- redigeringsoperation
- rundat hörn
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Skapa och anpassa former i PowerPoint‑presentationer med Aspose.Slides för Python via Java: geometribanor, rundade hörn, sammansatta former."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar presentationsformer i Aspose.Slides genom att redigera formens geometri med hjälp av redigeringspunkter och geometriska banor. Den visar hur du arbetar med [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) för att modifiera befintliga former, utföra grundläggande redigeringsoperationer för banor, lägga till eller ta bort punkter och tillämpa uppdaterad geometri på en form.

Den visar också hur du skapar anpassade och sammansatta former, bygger former med rundade hörn, avgör om en forms geometri är sluten och konverterar mellan [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) och [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) för ytterligare scenarier för geometrianpassning.

## **Ändra en form med redigeringspunkter**

Tänk dig en fyrkant. I PowerPoint, med **redigeringspunkter**, kan du

* flytta fyrkantens hörn inåt eller utåt
* ange krökningsgraden för ett hörn eller en punkt
* lägga till nya punkter i fyrkanten
* manipulera punkter på fyrkanten osv.

I grund och botten kan du utföra de beskrivna uppgifterna på vilken form som helst. Med redigeringspunkter kan du ändra en form eller skapa en ny form från en befintlig form.

## **Tips för formredigering**

![overview_image](custom_shape_0.png)

Innan du börjar redigera PowerPoint‑former med redigeringspunkter kan du vilja ta hänsyn till följande aspekter om former:

* En form (eller dess bana) kan antingen vara sluten eller öppen.
* När en form är sluten saknar den en start‑ eller slutpunkt. När en form är öppen har den en början och ett slut.
* Alla former består av minst 2 ankarpunkter som är kopplade till varandra med linjer.
* En linje är antingen rak eller kurvad. Ankorpunkter bestämmer linjens natur.
* Ankorpunkter finns som hörnpunkter, raka punkter eller mjuka punkter:
  * En hörnpunkt är en punkt där två raka linjer möts i en vinkel.
  * En mjuk punkt är en punkt där två handtag ligger i en rak linje och linjens segment förenas i en mjuk kurva. I detta fall är alla handtag separerade från ankropunkten med lika avstånd.
  * En rak punkt är en punkt där två handtag ligger i en rak linje och linjens segment förenas i en mjuk kurva. I detta fall behöver handtagen inte vara separerade från ankropunkten med lika avstånd.
* Genom att flytta eller redigera ankorpunkter (vilket ändrar linjernas vinklar) kan du förändra hur en form ser ut.

För att redigera PowerPoint‑former med redigeringspunkter tillhandahåller **Aspose.Slides** klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/).

* En [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) instans representerar en geometrisk bana för objektet [GeometryShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/).
* För att hämta [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) från en [GeometryShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/) instans kan du använda metoden [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/#getGeometryPaths).
* För att ställa in [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) för en form kan du använda dessa metoder: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/#setGeometryPath) för *solida former* och [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/#setGeometryPaths) för *sammansatta former*.
* För att lägga till segment kan du använda metoderna under [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/).
* Genom att använda metoderna [GeometryPath.setStroke](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/#setStroke) och [GeometryPath.setFillMode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/#setFillMode) kan du ange utseendet för en geometrisk bana.
* Med metoden [GeometryPath.getPathData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/#getPathData) kan du hämta geometribanan för en [GeometryShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/) som en array av bansegment.
* För att komma åt ytterligare alternativ för anpassning av formgeometri kan du konvertera [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) till [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
* Använd metoderna [geometryPathToGraphicsPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeutil/) och [graphicsPathToGeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeutil/) (från klassen [ShapeUtil](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapeutil/)) för att konvertera [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) till [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) fram och tillbaka.

## **Enkla redigeringsoperationer**

Följande signaturer visar de grundläggande redigeringsoperationerna:

**Lägg till en linje** i slutet av en bana:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Lägg till en linje** på en specificerad position på en bana:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Lägg till en kubisk Bézier-kurva** i slutet av en bana:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Lägg till en kubisk Bézier-kurva** på den specificerade positionen på en bana:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Lägg till en kvadratisk Bézier-kurva** i slutet av en bana:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Lägg till en kvadratisk Bézier-kurva** på en specificerad position på en bana:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Lägg till en given båge** till en bana:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Stäng den aktuella figuren** för en bana:

- `geometry_path.closeFigure()`

**Ställ in positionen för nästa punkt**:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Ta bort bansegmentet** på ett givet index:

- `geometry_path.removeAt(index)`

## **Lägg till anpassade punkter till en form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/) och ange typen [ShapeType.Rectangle](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#Rectangle).
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) från formen.
3. Lägg till en ny punkt mellan de två övre punkterna på banan.
4. Lägg till en ny punkt mellan de två nedre punkterna på banan.
5. Applicera banan på formen.

Denna Python‑kod visar hur du lägger till anpassade punkter till en form:

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

## **Ta bort punkter från en form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/) och ange typen [ShapeType.Heart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shapetype/#Heart).
2. Hämta en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) från formen.
3. Ta bort segmentet för banan.
4. Applicera banan på formen.

Denna Python‑kod visar hur du tar bort punkter från en form:

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

## **Skapa en anpassad form**

1. Beräkna punkterna för formen.
2. Skapa en instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/).
3. Fyll banan med punkterna.
4. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/).
5. Applicera banan på formen.

Denna Python‑kod visar hur du skapar en anpassad form:

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

## **Skapa en sammansatt anpassad form**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/).
2. Skapa en första instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/).
3. Skapa en andra instans av klassen [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/).
4. Applicera banorna på formen.

Denna Python‑kod visar hur du skapar en sammansatt anpassad form:

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

## **Skapa en anpassad form med rundade hörn**

Denna Python‑kod visar hur du skapar en anpassad form med rundade hörn (inåtriktade):

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

## **Ta reda på om en formgeometri är sluten**

En sluten form definieras som en där alla sidor är sammankopplade och bildar en enda gräns utan hål. En sådan form kan vara en enkel geometrisk figur eller en komplex anpassad kontur. Följande kodexempel visar hur du kontrollerar om en formgeometri är sluten:

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

## **Konvertera GeometryPath till java.awt.Shape**

1. Skapa en instans av klassen [GeometryShape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometryshape/).
2. Skapa en instans av klassen [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Konvertera [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) instansen till [GeometryPath](https://reference.aspose.com/slides/sv/python-java/aspose.slides/geometrypath/) instansen genom att gå igenom dess [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) och återspela varje segment på banan.
4. Applicera banorna på formen.

Denna Python‑kod implementerar stegen ovan för att konvertera en grafikbana till en geometribana:

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
    # Skapa en ny form.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Hämta formens geometribana.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Skapa en ny grafikbana med text.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
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

    # Applicera textbanan tillsammans med den ursprungliga geometribanan.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Vad händer med fyllning och kontur efter att geometrin ersatts?**

Stilen förblir på formen; endast konturen förändras. Fyllning och kontur appliceras automatiskt på den nya geometrin.

**Hur roterar jag korrekt en anpassad form tillsammans med dess geometri?**

Använd formens [setRotation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setRotation) metod; geometrin roteras med formen eftersom den är bunden till formens eget koordinatsystem.

**Kan jag konvertera en anpassad form till en bild för att "låsa" resultatet?**

Ja. Exportera det önskade [slide](/slides/sv/python-java/convert-powerpoint-to-png/) området eller själva [shape](/slides/sv/python-java/create-shape-thumbnails/) till ett rasterformat; detta förenklar vidare arbete med tunga geometrier.