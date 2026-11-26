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
- abgerundete Ecke
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und anpassen von Formen in PowerPoint‑Präsentationen mit Aspose.Slides für Python über Java: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsformen in Aspose.Slides anpassen, indem Sie die Geometrie von Formen über Bearbeitungspunkte und Geometriepfade bearbeiten. Er zeigt, wie Sie mit [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) vorhandene Formen ändern, grundlegende Pfad‑Bearbeitungsoperationen durchführen, Punkte hinzufügen oder entfernen und die aktualisierte Geometrie wieder einer Form zuweisen.

Er demonstriert außerdem, wie benutzerdefinierte und zusammengesetzte Formen erstellt, Formen mit abgerundeten Ecken gebaut, festgestellt wird, ob eine Formgeometrie geschlossen ist, Formelemente inspiziert und Java‑AWT‑Texte zu Geometriepfaden konvertiert werden.

## **Form mit Bearbeitungspunkten ändern**

In PowerPoint können Sie **Bearbeitungspunkte** verwenden, um ein Quadrat zu modifizieren:

* Einen Eckpunkt nach innen oder außen verschieben.
* Die Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Durch das Bearbeiten von Punkten können Sie die Kontur einer Form ändern oder eine bestehende Form als Basis für eine neue verwenden.

## **Tipps zum Bearbeiten von Formen**

![overview_image](custom_shape_0.png)

Beim Bearbeiten von PowerPoint‑Formen sollten Sie folgende Konzepte berücksichtigen:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder gekrümmt sein. Ankerpunkte und Steuergriffe bestimmen seine Form.
* Ankerpunkte gibt es als Eckpunkte, gerade Punkte oder glatte Punkte:
  * An einem Eckpunkt können angrenzende Segmente in einem Winkel zusammentreffen.
  * An einem glatten Punkt sind die beiden Steuergriffe ausgerichtet und gleich weit vom Ankerpunkt entfernt.
  * An einem geraden Punkt sind die beiden Steuergriffe ausgerichtet, können jedoch unterschiedliche Abstände zum Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Griffe ändert die Kontur der Form.

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) bereit.

* Ein [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑Instanz stellt einen Geometriepfad des [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)‑Objekts dar.
* Um den [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) aus der [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/)‑Instanz abzurufen, können Sie die Methode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) verwenden.
* Um den [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) für eine Form festzulegen, können Sie diese Methoden verwenden: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) für Formen mit einem einzelnen Pfad und [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) für Formen mit mehreren Pfaden.
* Zum Hinzufügen von Segmenten können Sie die Methoden unter [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) nutzen.
* Mit den Methoden [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) und [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) können Sie das Aussehen eines Geometriepfads festlegen.
* Mit der Methode [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) können Sie den Geometriepfad einer [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.
* Um zusätzliche Optionen zur Anpassung der Formgeometrie zu nutzen, können Sie ein [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) über seinen [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) lesen und die Segmente auf einem [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) wiedergeben.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfads ein.

| Operation | Methode |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| Eine kubische Bézier‑Kurve mit zwei Steuerpunkten und Endpunkt anhängen oder einfügen. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Eine quadratische Bézier‑Kurve mit einem Steuerpunkt und Endpunkt anhängen oder einfügen. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Einen elliptischen Bogen mit den angegebenen Abmessungen und Winkeln in Grad anhängen. | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| Die aktuelle Figur schließen, indem ihr Endpunkt mit dem Startpunkt verbunden wird. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form zwei Punkte mit [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) ein und wendet den bearbeiteten Pfad mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) an. Die Koordinaten sind relativ zur Form: beide neuen Punkte liegen in ihrer Mitte, 100 Punkte vom linken Rand und 50 Punkte vom oberen Rand entfernt. Die Segment‑Indizes 1 und 4 platzieren sie an den oberen bzw. unteren Kanten und ziehen diese Kanten nach innen.

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

Dieses Beispiel ändert die Kontur einer herzförmigen Form, indem das Segment am nullbasierten Index 2 mit [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) entfernt wird. Das Anwenden des modifizierten Pfads mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) aktualisiert die Kontur der Form.

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

## **Benutzerdefinierte Form erstellen**

Dieses Beispiel erstellt einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/). Wechselnde äußere und innere Radien von 100 bzw. 50 Punkten definieren die Spitzen und Einziehungen; ein Schritt von 72 Grad verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) geschlossen und mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) einer rechteckigen Form zugewiesen, wodurch deren Kontur ersetzt wird.

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

## **Zusammengesetzte benutzerdefinierte Form erstellen**

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/)‑Objekte für das obere und untere Drittel einer Form. Das Anwenden beider Pfade mit [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) erzeugt eine einzelne zusammengesetzte Form mit einer Lücke im mittleren Drittel.

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

## **Benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo), um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jede Eckgröße legt die Breite und Höhe des Bogens in Punkten fest, und der –90‑Grad‑Bogen zeichnet ein gegen den Uhrzeigersinn gedrehtes Viertel‑Ellipse. Der fertige Pfad wird mit [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) angewendet, und die Präsentation wird im PPTX‑Format gespeichert.

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

Der folgende Helfer prüft, ob jeder nicht leere Geometriepfad mit einem Schließsegment endet. Er liest [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) und vergleicht den letzten Segment‑Befehl [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) mit [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/). Er gibt `False` zurück, wenn keine nicht leeren Pfade vorhanden sind. Diese Prüfung betrachtet nur den letzten Befehl jedes Pfads; sie untersucht nicht jede Unterfigur innerhalb eines Pfads. Das Beispiel gibt `True` für ein Rechteck aus.

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

## **Geometriepfadbefehle untersuchen**

Laden Sie [contour.pptx](contour.pptx) herunter und legen Sie die Datei im Arbeitsverzeichnis der Anwendung ab. Die erste Form auf der ersten Folie hat eine gerade obere Kante, eine kubische Bézier‑Kurve und eine gerade Schließkante. Verwenden Sie [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths), um die Pfade der Form zu lesen, und [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData), um die Segmente jedes Pfads in Zeichenreihenfolge zu erhalten. Für jedes Segment identifiziert [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) den Befehl und bestimmt, wie die Werte von [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData) zu interpretieren sind.

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

Die Form befindet sich bei (200, 100) Punkten auf der Folie. Die gemeldeten Koordinaten sind relativ zur Form, wobei (0, 0) deren obere linke Ecke ist, x nach rechts und y nach unten wächst. Das Schließsegment führt zum Startpunkt zurück, ohne zusätzliche Koordinaten.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Formelemente extrahieren und untersuchen**

Verwenden Sie [GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements), um eine vorhandene Form als Elemente zu inspizieren, die Pfadpunkte und Punkt‑Typen enthalten. Casten Sie jedes zurückgegebene Element zu [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) mit `jpype.JObject`, um die Punkte‑ und Typ‑Arrays über die Methoden [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) und [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) abzurufen. Diese Darstellung ist nützlich für Konturanalysen oder zum Weitergeben der Geometrie an benutzerdefinierte Zeichenwerkzeuge.

Das Beispiel öffnet `input.pptx`, findet die erste GeometryShape direkt auf der ersten Folie und gibt deren Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgaben zu sehen. Es werden keine Gruppen durchsucht.

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
                    i += 2  # Verwende beide Steuerpunkte und den Endpunkt.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Die Arrays entsprechen einander nach Index: `points[i]` ist ein Punkt und `types[i]` beschreibt dessen Rolle. Typ `0` startet eine Figur, Typ `1` zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment beginnt beim vorherigen Endpunkt und nutzt drei aufeinanderfolgende Typ‑`3`‑Einträge: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge zusammen und prüft den Endpunkt auf Schließung.

Punkt‑Typen enthalten zudem Flags. Maskieren Sie mit `0x07`, um den Segmenttyp zu ermitteln, und prüfen Sie `0x80` separat, um einen geschlossenen Unterpfad zu erkennen. Beispiel: `129` (`0x81`) bedeutet ein Linienendpunkt, das einen Unterpfad schließt, und `131` (`0x83`) bedeutet ein Bézier‑Endpunkt, das einen schließt. Java speichert diese Flags in vorzeichenbehafteten Bytes; das Maskieren bewahrt die beabsichtigten Bit­werte. Ein Vergleich des Rohwerts nur mit `1` oder `3` würde diese Fälle übersehen. Andere Flags, wie Strich (`0x10`) und Marker (`0x20`), ändern den Basissegmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkten (1/72 Zoll) gemessen, X wächst nach rechts, Y nach unten. Für eine nicht gruppierte Form beinhalten die extrahierten Koordinaten bereits die Position, die durch [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) und [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) zurückgegeben wird, und spiegeln deren aktuelle Breite und Höhe wider. Beispiel: Ein nicht gedrehtes Rechteck bei `(100, 200)` mit Größe `120 × 80` hat Konturgrenzen `(100, 200)`–`(220, 280)`. Addieren Sie die Positionswerte nicht erneut. Subtrahieren Sie X und Y, um Koordinaten relativ zum ungedrehten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die Drehung der Form, die über [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) zurückgegeben wird, noch horizontale oder vertikale Spiegelungen. Um die angezeigte Kontur nachzubilden, wenden Sie diese Transformationen um den Mittelpunkt der Form an. Für gruppierte Formen berücksichtigen Sie zusätzlich die Koordinatenzuordnung und Transformationen der Gruppe; gehen Sie nicht davon aus, dass die extrahierten Punkte bereits die endgültigen Folienkoordinaten sind, und wenden Sie Übersetzungen oder Skalierungen nicht doppelt an.

**Untersuchung vs. Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; deren Änderung aktualisiert die Originalform nicht. Nutzen Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichenlogik Punkt‑/Typ‑Arrays benötigt. Verwenden Sie [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths), wenn Sie Geometrie‑Befehle im lokalen Koordinatensystem der Form benötigen oder die Geometrie bearbeiten möchten. Wenden Sie bearbeitete Pfade über [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) oder [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) an.

## **Java AWT-Shape in GeometryPath konvertieren**

Dieses Beispiel kombiniert eine rechteckige Kontur mit Text, der in Geometrie konvertiert wurde. Die Methode [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) der Kontur deaktiviert deren Füllung. Ein [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) erzeugt die Textkontur in einem [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html). Der zugehörige [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) liefert Move‑, Line‑, Quadratic‑, Cubic‑ und Close‑Segmente, die das Beispiel auf einem [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) wiederholt.

Der Text verwendet die 40‑Punkt‑Arial‑Schrift. Die Kontur ist um 20 Punkte horizontal versetzt und mit ihrer visuellen Oberkante 10 Punkte unterhalb der oberen Kante der Form positioniert. Der Textpfad wird gefüllt, während das ursprüngliche Rechteck nur als Kontur bleibt. Das Anwenden beider Pfade mit [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) erzeugt eine einzelne Form, die sowohl das Rechteck als auch den Text enthält.

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

    # Den Geometriepfad der Form erhalten.
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # Einen neuen Grafikpfad mit Text erstellen.
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

    # Convert the graphics path to a geometry path.
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

    # Apply the text path together with the original geometry path.
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Was passiert mit Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt an der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie drehe ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie?**

Verwenden Sie die Methode [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) der Form; die Geometrie rotiert mit der Form, weil sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**

Ja. Exportieren Sie den gewünschten [slide](/slides/de/python-java/convert-powerpoint-to-png/)-Bereich oder die [shape](/slides/de/python-java/create-shape-thumbnails/)-Selbst in ein Rasterformat; das erleichtert die weitere Arbeit mit komplexen Geometrien.