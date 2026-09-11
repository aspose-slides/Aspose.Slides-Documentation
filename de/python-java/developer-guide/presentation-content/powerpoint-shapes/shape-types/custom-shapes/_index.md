---
title: Präsentationsformen in Python über Java anpassen
linktitle: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/python-java/custom-shape/
keywords:
- benutzerdefinierte Form
- Form hinzufügen
- Form erstellen
- Form ändern
- Formgeometrie
- Geometriepfad
- Pfadpunkte
- Bearbeitungspunkte
- Punkt hinzufügen
- Punkt entfernen
- Bearbeitungsoperation
- gekrümmte Ecke
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für Python über Java: Geometriepfade, gekrümmte Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsformen in Aspose.Slides anpassen können, indem Sie die Formgeometrie über Bearbeitungspunkte und Geometriepfade bearbeiten. Er zeigt, wie man mit [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) arbeitet, um vorhandene Formen zu ändern, grundlegende Pfadbearbeitungsoperationen durchzuführen, Punkte hinzuzufügen oder zu entfernen und die aktualisierte Geometrie wieder auf eine Form anzuwenden.

Er demonstriert zudem, wie benutzerdefinierte und zusammengesetzte Formen erstellt werden, Formen mit gekrümmten Ecken aufgebaut werden, ermittelt wird, ob eine Formgeometrie geschlossen ist, und wie zwischen [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) und [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) konvertiert wird, um weitere Geometrie‑Anpassungsszenarien zu ermöglichen.

## **Form mit Bearbeitungspunkten ändern**

Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **edit points** 

* die Ecke des Quadrats nach innen oder außen verschieben
* die Krümmung einer Ecke oder eines Punktes festlegen
* neue Punkte zum Quadrat hinzufügen
* Punkte auf dem Quadrat manipulieren usw. 

Im Wesentlichen können Sie die beschriebenen Aufgaben an jeder Form ausführen. Mit Bearbeitungspunkten können Sie eine Form ändern oder aus einer bestehenden Form eine neue Form erstellen.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Bevor Sie beginnen, PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, sollten Sie diese Punkte zu Formen beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Wenn eine Form geschlossen ist, hat sie keinen Start‑ oder Endpunkt. Wenn eine Form offen ist, hat sie einen Anfang und ein Ende. 
* Alle Formen bestehen aus mindestens 2 Ankerpunkten, die durch Linien miteinander verbunden sind.
* Eine Linie ist entweder gerade oder gekrümmt. Ankerpunkte bestimmen die Art der Linie. 
* Ankerpunkte existieren als Eckpunkte, Geradepunkte oder Glättungspunkte:
  * Ein Eckpunkt ist ein Punkt, an dem sich zwei gerade Linien in einem Winkel treffen. 
  * Ein Glättungspunkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie liegen und die Segmente der Linie zu einer sanften Kurve verbinden. In diesem Fall sind alle Griffe vom Ankerpunkt um die gleiche Distanz getrennt. 
  * Ein Geradepunkt ist ein Punkt, an dem 2 Griffe in einer geraden Linie liegen und die Segmente dieser Linie zu einer glatten Kurve verbinden. In diesem Fall müssen die Griffe nicht in gleichem Abstand vom Ankerpunkt getrennt sein. 
* Durch Verschieben oder Bearbeiten von Ankerpunkten (die den Winkel der Linien ändern) können Sie das Aussehen einer Form verändern. 

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) bereit. 

* Eine [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) Instanz stellt einen Geometriepfad des [GeometryShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/) Objekts dar. 
* Um die [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) aus der [GeometryShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/) Instanz abzurufen, können Sie die Methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/#getGeometryPaths) verwenden. 
* Um die [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) für eine Form zu setzen, können Sie diese Methoden verwenden: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/#setGeometryPath) für *solide Formen* und [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/#setGeometryPaths) für *zusammengesetzte Formen*.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) verwenden. 
* Mit den Methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/#setStroke) und [GeometryPath.setFillMode](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/#setFillMode) können Sie das Aussehen eines Geometriepfads festlegen.
* Mit der Methode [GeometryPath.getPathData](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/#getPathData) können Sie den Geometriepfad eines [GeometryShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen. 
* Um zusätzliche Optionen zur Formgeometrie‑Anpassung zu nutzen, können Sie [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) konvertieren.
* Verwenden Sie die Methoden [geometryPathToGraphicsPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeutil/) und [graphicsPathToGeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeutil/) (aus der Klasse [ShapeUtil](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeutil/)), um [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) in [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) und zurück zu konvertieren. 

## **Einfache Bearbeitungsoperationen**

Die folgenden Signaturen zeigen die grundlegenden Bearbeitungsoperationen:

**Linie hinzufügen** am Ende eines Pfads:

- `geometry_path.lineTo(point)`
- `geometry_path.lineTo(x, y)`

**Linie hinzufügen** an einer angegebenen Position im Pfad:

- `geometry_path.lineTo(point, index)`
- `geometry_path.lineTo(x, y, index)`

**Kubische Bézier‑Kurve hinzufügen** am Ende eines Pfads:

- `geometry_path.cubicBezierTo(point1, point2, point3)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3)`

**Kubische Bézier‑Kurve hinzufügen** an einer angegebenen Position im Pfad:

- `geometry_path.cubicBezierTo(point1, point2, point3, index)`
- `geometry_path.cubicBezierTo(x1, y1, x2, y2, x3, y3, index)`

**Quadratische Bézier‑Kurve hinzufügen** am Ende eines Pfads:

- `geometry_path.quadraticBezierTo(point1, point2)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2)`

**Quadratische Bézier‑Kurve hinzufügen** an einer angegebenen Position im Pfad:

- `geometry_path.quadraticBezierTo(point1, point2, index)`
- `geometry_path.quadraticBezierTo(x1, y1, x2, y2, index)`

**Einen angegebenen Bogen an den Pfad anhängen**:

- `geometry_path.arcTo(width, height, start_angle, sweep_angle)`

**Die aktuelle Figur** des Pfads schließen:

- `geometry_path.closeFigure()`

**Die Position für den nächsten Punkt** setzen:

- `geometry_path.moveTo(point)`
- `geometry_path.moveTo(x, y)`

**Das Pfadsegment** an einem angegebenen Index entfernen:

- `geometry_path.removeAt(index)`


## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/) und setzen Sie den Typ [ShapeType.Rectangle](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#Rectangle).
2. Holen Sie sich eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) aus der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten des Pfads hinzu.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten des Pfads hinzu.
5. Wenden Sie den Pfad auf die Form an.

Dieser Python‑Code zeigt, wie Sie benutzerdefinierte Punkte zu einer Form hinzufügen:

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

## **Punkte aus einer Form entfernen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/) und setzen Sie den Typ [ShapeType.Heart](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#Heart). 
2. Holen Sie sich eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) aus der Form.
3. Entfernen Sie das Segment des Pfads.
4. Wenden Sie den Pfad auf die Form an.

Dieser Python‑Code zeigt, wie Sie Punkte aus einer Form entfernen:

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

## **Eine benutzerdefinierte Form erstellen**

1. Berechnen Sie die Punkte für die Form.
2. Erstellen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/). 
3. Füllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/). 
5. Wenden Sie den Pfad auf die Form an.

Dieser Python‑Code zeigt, wie Sie eine benutzerdefinierte Form erstellen:

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


## **Ein zusammengesetztes benutzerdefiniertes Shape erstellen**

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/).
2. Erstellen Sie eine erste Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/).
3. Erstellen Sie eine zweite Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/).
4. Wenden Sie die Pfade auf die Form an.

Dieser Python‑Code zeigt, wie Sie ein zusammengesetztes benutzerdefiniertes Shape erstellen:

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

## **Eine benutzerdefinierte Form mit gekrümmten Ecken erstellen**

Dieser Python‑Code zeigt, wie Sie eine benutzerdefinierte Form mit gekrümmten Ecken (nach innen) erstellen:

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

## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Eine geschlossene Form ist definiert als eine, bei der alle Seiten miteinander verbunden sind und eine durchgehende Grenze ohne Lücken bilden. Eine solche Form kann eine einfache geometrische Form oder ein komplexes benutzerdefiniertes Kontur sein. Das folgende Codebeispiel zeigt, wie geprüft wird, ob eine Formgeometrie geschlossen ist:

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

## **GeometryPath in java.awt.Shape konvertieren** 

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/).
2. Erstellen Sie eine Instanz der Klasse [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Konvertieren Sie die [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) Instanz in die [GeometryPath](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometrypath/) Instanz, indem Sie deren [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) durchlaufen und jedes Segment auf dem Pfad wiedergeben.
4. Wenden Sie die Pfade auf die Form an.

Dieser Python‑Code implementiert die oben genannten Schritte, um einen Grafiks­pfad in einen Geometrie‑Pfad zu konvertieren:

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
    # Erstelle eine neue Form.
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # Hole den Geometriepfad der Form.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Erstelle einen neuen Grafikpfad mit Text.
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        glyph_vector = font.createGlyphVector(graphics.getFontRenderContext(), text)
        graphics_path = glyph_vector.getOutline(20.0, -glyph_vector.getVisualBounds().getY() + 10)
    finally:
        graphics.dispose()

    # Konvertiere den Grafikpfad in einen Geometriepfad.
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

    # Wende den Textpfad zusammen mit dem ursprünglichen Geometriepfad an.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Was passiert mit Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt an der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie rotiere ich eine benutzerdefinierte Form zusammen mit ihrer Geometrie korrekt?**

Verwenden Sie die Methode [setRotation](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#setRotation) der Form; die Geometrie rotiert mit der Form, weil sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**

Ja. Exportieren Sie den gewünschten [slide](/slides/de/python-java/convert-powerpoint-to-png/)‑Bereich oder die [shape](/slides/de/python-java/create-shape-thumbnails/) selbst in ein Rasterformat; das vereinfacht die weitere Arbeit mit komplexen Geometrien.