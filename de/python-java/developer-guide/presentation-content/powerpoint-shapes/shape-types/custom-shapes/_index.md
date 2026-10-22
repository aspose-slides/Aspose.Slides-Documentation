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
- Gekrümmte Ecke
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und anpassen von Formen in PowerPoint‑Präsentationen mit Aspose.Slides für Python über Java: Geometriepfade, gekrümmte Ecken, zusammengesetzte Formen."
---
## **Überblick**

Dieser Artikel erklärt, wie Sie Präsentationsformen in Aspose.Slides anpassen können, indem Sie die Formgeometrie über Bearbeitungspunkte und Geometriepfade bearbeiten. Er zeigt, wie man mit [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) arbeitet, um vorhandene Formen zu ändern, grundlegende Pfadbearbeitungsoperationen durchzuführen, Punkte hinzuzufügen oder zu entfernen und die aktualisierte Geometrie wieder einer Form anzuwenden.

Er demonstriert außerdem, wie benutzerdefinierte und zusammengesetzte Formen erstellt werden, Formen mit gekrümmten Ecken gebaut werden, festgestellt wird, ob eine Formgeometrie geschlossen ist, Formelemente inspiziert werden und Java‑AWT‑Textumrisse in Geometriepfade konvertiert werden.

## **Ändern einer Form mit Bearbeitungspunkten**

* Ecke nach innen oder außen verschieben.
* Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Das Bearbeiten von Punkten ermöglicht es Ihnen, die Kontur einer Form zu ändern oder eine vorhandene Form als Basis für eine neue zu verwenden.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

Beim Bearbeiten von PowerPoint‑Formen sollten Sie diese Konzepte im Kopf behalten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder kurvig sein. Ankerpunkte und Steuergriffe bestimmen seine Form.
* Ankerpunkte können Eckpunkte, gerade Punkte oder glatte Punkte sein:
  * Bei einem Eckpunkt können angrenzende Segmente in einem Winkel zusammentreffen.
  * Bei einem glatten Punkt sind die beiden Steuergriffe ausgerichtet und gleichweit vom Ankerpunkt entfernt.
  * Bei einem geraden Punkt sind die beiden Steuergriffe ausgerichtet, können aber unterschiedliche Abstände zum Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Griffe ändert die Kontur der Form.

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, bietet **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) an.

* Eine [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) Instanz stellt einen Geometriepfad des [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) Objekts dar.
* Um den [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) aus der [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) Instanz abzurufen, können Sie die Methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) verwenden.
* Um den [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) für eine Form festzulegen, können Sie diese Methoden verwenden: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) für Formen mit einem einzelnen Pfad und [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) für Formen mit mehreren Pfaden.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) verwenden.
* Mit den Methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) und [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) können Sie das Erscheinungsbild eines Geometriepfads festlegen.
* Mit der Methode [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) können Sie den Geometriepfad eines [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.
* Um weitere Optionen zur Anpassung der Formgeometrie zu nutzen, können Sie ein [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) über dessen [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) lesen und die Segmente auf einem [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) wiedergeben.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfads ein.

| Operation | Method |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Eine kubische Bézier‑Kurve mit zwei Steuerpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Eine quadratische Bézier‑Kurve mit einem Steuerpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Ein elliptisches Bogensegment mit den angegebenen Abmessungen und Winkeln in Grad anhängen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Die aktuelle Figur schließen, indem das Endsegment mit dem Startpunkt verbunden wird. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form zwei Punkte mit [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) ein und wendet den bearbeiteten Pfad mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) an. Die Koordinaten sind relativ zur Form: beide neuen Punkte liegen in ihrer Mitte, 100 Punkte von links und 50 Punkte von oben. Die Segmentindizes 1 und 4 platzieren sie an den oberen bzw. unteren Kanten und ziehen diese Kanten nach innen.

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

## **Punkte aus einer Form entfernen**

Dieses Beispiel ändert die Kontur einer herzförmigen Form, indem es das Segment am nullbasierten Index 2 mit [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) entfernt. Das Anwenden des modifizierten Pfads mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) aktualisiert die Kontur der Form.

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

## **Eine benutzerdefinierte Form erstellen**

Dieses Beispiel baut einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) auf. Abwechselnde äußere und innere Radien von 100 und 50 Punkten definieren die Spitzen und Einziehungen; ein 72‑Grad‑Schritt verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) geschlossen und mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) auf eine rechteckige Form angewendet, wodurch deren Kontur ersetzt wird.

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

## **Eine zusammengesetzte benutzerdefinierte Form erstellen**

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑Objekte für das obere und das untere Drittel einer Form. Das Anwenden beider Pfade mit [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) erzeugt eine einzelne zusammengesetzte Form mit einer Lücke über dem mittleren Drittel.

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

## **Eine benutzerdefinierte Form mit gekrümmten Ecken erstellen**

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo), um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jede Eckgröße legt die Breite und Höhe des Bogens in Punkten fest, und die –90‑Grad‑Sweep‑Operation zeichnet ein gegen den Uhrzeigersinn verlaufendes Viertel­ellipse‑Segment. Der fertige Pfad wird mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) angewendet, und die Präsentation wird im PPTX‑Format gespeichert.

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

## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Der folgende Helfer prüft, ob jeder nicht leere Geometriepfad mit einem Schließsegment endet. Er liest [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) und vergleicht den abschließenden Befehl des Segments mittels [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) mit [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Er gibt `False` zurück, wenn keine nicht leeren Pfade vorhanden sind. Diese Prüfung berücksichtigt nur den letzten Befehl jedes Pfads und inspiziert nicht jede Unterfigur innerhalb eines Pfads. Das Beispiel gibt `True` für ein Rechteck aus.

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

## **Formelemente extrahieren und inspizieren**

Verwenden Sie [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements), um eine bestehende Form als Elemente zu inspizieren, die Pfadpunkte und Punktarten enthalten. Casten Sie jedes zurückgegebene Element zu [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) mit `jpype.JObject`, um über die Methoden [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) und [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) auf die Punkt‑ und Typ‑Arrays zuzugreifen. Diese Darstellung ist nützlich für Konturanalysen oder zum Übergeben der Geometrie an benutzerdefinierte Zeichenwerkzeuge.

Das Beispiel öffnet *input.pptx*, findet die erste GeometryShape‑Instanz direkt auf der ersten Folie und gibt deren Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgabetypen zu sehen. Es wird nicht in Gruppen gesucht.

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
                point_type = types[i] & 0x07  # Behalte den Segmenttyp, ohne Flags.
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Verbrauche beide Steuerpunkte und den Endpunkt.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Die Arrays korrespondieren nach Index: `points[i]` ist ein Punkt und `types[i]` beschreibt seine Rolle. Typ `0` startet eine Figur, Typ `1` zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment startet am vorherigen Endpunkt und verwendet drei aufeinanderfolgende Typ‑`3`‑Einträge: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge gemeinsam und prüft das Endsegment auf Abschluss.

Punktarten enthalten zudem Flags. Maskieren Sie mit `0x07`, um den Segmenttyp zu ermitteln, und testen Sie `0x80` getrennt, um einen geschlossenen Unterpfad zu erkennen. Beispiel: `129` (`0x81`) bedeutet ein Linienendpunkt, das einen Unterpfad schließt, und `131` (`0x83`) bedeutet ein Bézier‑Endpunkt, das einen schließt. Java speichert diese Flags in signed Bytes; das Maskieren bewahrt die beabsichtigten Bitwerte. Ein reiner Vergleich des Rohwerts mit `1` oder `3` würde diese Fälle übersehen. Andere Flags, wie Strich (`0x10`) und Marker (`0x20`), ändern den Basissegmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkt (1/72 Zoll) gemessen, wobei X nach rechts und Y nach unten wächst. Für eine nicht gruppierte Form beinhalten die extrahierten Koordinaten bereits die Position, die über [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) und [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) zurückgegeben wird, und spiegeln die aktuelle Breite und Höhe wider. Ein unrotierter Rechteck bei `(100, 200)` mit Größe `120 × 80` hat Kontur‑Grenzen `(100, 200)`–`(220, 280)`. Fügen Sie die Form‑Position nicht erneut hinzu. Subtrahieren Sie X und Y, um Koordinaten relativ zum nicht rotierten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die Rotation der Form, die über [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) zurückgegeben wird, noch nicht horizontale und vertikale Spiegelungen. Um die angezeigte Kontur wiederzugeben, wenden Sie diese Transformationen um den Mittelpunkt der Form an. Für gruppierte Formen berücksichtigen Sie zusätzlich die Koordinatenzuordnung und Transformationen der Gruppe; gehen Sie nicht davon aus, dass die extrahierten Punkte bereits die endgültigen Folienkoordinaten darstellen, und wenden Sie keine Übersetzungen oder Skalierungen doppelt an, wenn sie bereits im Kinderrahmen reflektiert sind.

**Inspektion versus Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; deren Änderung aktualisiert die ursprüngliche Form nicht. Verwenden Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichenlogik Punkt‑/Typ‑Arrays benötigt. Nutzen Sie [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths), wenn Sie Geometrie‑Befehle im lokalen Koordinatensystem der Form benötigen oder die Geometrie bearbeiten möchten. Wenden Sie bearbeitete Pfade über [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) oder [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) an.

## **Java‑AWT‑Shape in GeometryPath konvertieren**

Dieses Beispiel kombiniert eine rechteckige Kontur mit Text, der in Geometrie umgewandelt wird. Die Methode [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) der Kontur deaktiviert deren Füllung. Ein [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) erzeugt den Textumriss in einem [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Sein [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) liefert Move‑, Line‑, Quadratic‑, Cubic‑ und Closing‑Segmente, die das Beispiel auf einem [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) wiederholt.

Der Text verwendet die 40‑Punkt‑Arial‑Schrift. Die Kontur ist horizontal um 20 Punkte verschoben und ihr visueller Oberrand liegt 10 Punkte unterhalb der oberen Kante der Form. Der Textpfad ist gefüllt, während das ursprüngliche Rechteck lediglich als Kontur bleibt. Das Anwenden beider Pfade mit [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) erzeugt eine einzige Form, die das Rechteck und den Text enthält.

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

    # Den Geometriepfad der Form abrufen.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Erstelle einen neuen Grafikpfad mit Text.
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

Der Stil bleibt bei der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie drehe ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie?**

Verwenden Sie die Methode [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) der Form; die Geometrie rotiert mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis zu „sperren“?**

Ja. Exportieren Sie den erforderlichen [Folien](/slides/de/python-java/convert-powerpoint-to-png/)‑Bereich oder die [Form](/slides/de/python-java/create-shape-thumbnails/) selbst in ein Rasterformat; das vereinfacht die weitere Arbeit mit komplexen Geometrien.