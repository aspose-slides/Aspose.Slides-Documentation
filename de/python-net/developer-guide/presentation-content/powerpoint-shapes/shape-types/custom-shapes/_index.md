---
title: Präsentationsformen in Python anpassen
linktitle: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/python-net/custom-shape/
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
- Bearbeitungsvorgang
- abgerundete Ecke
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und anpassen von Formen in PowerPoint‑Präsentationen mit Aspose.Slides für Python über .NET: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsformen in Aspose.Slides anpassen, indem Sie die Formgeometrie über Bearbeitungspunkte und Geometriepfade bearbeiten. Er zeigt, wie Sie mit [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) bestehende Formen ändern, grundlegende Pfadbearbeitungsoperationen durchführen, Punkte hinzufügen oder entfernen und die aktualisierte Geometrie wieder auf eine Form anwenden.

Es demonstriert außerdem, wie benutzerdefinierte und zusammengesetzte Formen erstellt, Formen mit abgerundeten Ecken gebaut, bestimmt wird, ob eine Formgeometrie geschlossen ist, und Formelemente für Konturanalysen extrahiert werden.

## **Form mit Bearbeitungspunkten ändern**

* Einen Eckpunkt nach innen oder außen verschieben.
* Die Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Durch das Bearbeiten von Punkten können Sie die Kontur einer Form ändern oder eine vorhandene Form als Basis für eine neue verwenden.

## **Tipps zur Formbearbeitung**

![overview_image](custom_shape_0.png)

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder gekrümmt sein. Ankerpunkte und Steuergriffe bestimmen seine Form.
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * An einem Eckpunkt können angrenzende Segmente einen Winkel bilden.
  * An einem glatten Punkt sind die beiden Steuergriffe ausgerichtet und gleich weit vom Ankerpunkt entfernt.
  * An einem geraden Punkt sind die beiden Steuergriffe ausgerichtet, können aber unterschiedliche Abstände zum Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Steuergriffe ändert die Kontur der Form.

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)‑Instanz repräsentiert einen Geometriepfad des Objekts [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
* Um den [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) aus der [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)-Instanz abzurufen, können Sie die Methode [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) verwenden.
* Um den [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) für eine Form festzulegen, können Sie diese Methoden verwenden: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) für Formen mit einem einzelnen Pfad und [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) für Formen mit mehreren Pfaden.
* Um Segmente hinzuzufügen, können Sie die Methoden unter [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) verwenden.
* Mit den Eigenschaften [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) und [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) können Sie das Aussehen eines Geometriepfads festlegen.
* Mit der Eigenschaft [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) können Sie den Geometriepfad einer [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfads ein.

| Operation | Method |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Eine kubische Bézier‑Kurve mit zwei Steuerpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Eine quadratische Bézier‑Kurve mit einem Steuerpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Ein elliptisches Bogensegment mit den angegebenen Abmessungen und Winkeln in Grad anhängen. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Die aktuelle Figur schließen, indem ihr Endpunkt mit dem Startpunkt verbunden wird. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form zwei Punkte mithilfe von [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) hinzu und wendet den bearbeiteten Pfad mit [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) an. Die Koordinaten sind relativ zur Form: beide neuen Punkte befinden sich in ihrer Mitte, 100 Punkte vom linken Rand und 50 Punkte vom oberen Rand entfernt. Segmentindizes 1 und 4 platzieren sie an den oberen bzw. unteren Kanten und ziehen diese Kanten nach innen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **Punkte aus einer Form entfernen**

Dieses Beispiel verändert die Kontur einer herzförmigen Form, indem es das Segment am nullbasierten Index 2 mit [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) entfernt. Das Anwenden des modifizierten Pfads mit [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) aktualisiert die Kontur der Form.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **Eine benutzerdefinierte Form erstellen**

Dieses Beispiel erstellt einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Abwechselnde äußere und innere Radien von 100 bzw. 50 Punkten definieren die Spitzen und Einziehungen; ein Schritt von 72 Grad verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) geschlossen und mittels [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) auf eine rechteckige Form angewendet, wodurch deren Kontur ersetzt wird.

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **Eine zusammengesetzte benutzerdefinierte Form erstellen**

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)‑Objekte für das obere und das untere Drittel einer Form. Das Anwenden beider Pfade mit [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) erzeugt eine einzelne zusammengesetzte Form mit einer Lücke im mittleren Drittel.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **Eine benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/), um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jede Eckgröße legt die Breite und Höhe des Bogens in Punkten fest, und der -90‑Grad‑Bogen zieht ein gegen den Uhrzeigersinn verlaufendes Viertel‑Ellipse. Der fertige Pfad wird mit [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) angewendet und die Präsentation im PPTX‑Format gespeichert.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ermitteln, ob eine Formgeometrie geschlossen ist**

Der folgende Helfer prüft, ob jeder nicht‑leere Geometriepfad mit einem Schließsegment endet. Er liest [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) und vergleicht den Befehlswert des letzten Segments [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) mit [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Er gibt **false** zurück, wenn keine nicht‑leeren Pfade vorhanden sind. Dabei wird nur das letzte Kommando jedes Pfads geprüft; nicht jedes Teil‑Figure im Pfad wird untersucht. Das Beispiel gibt `True` für ein Rechteck aus.

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **Formelemente extrahieren und inspizieren**

Verwenden Sie [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/), um eine vorhandene Form als Elemente zu untersuchen, die Pfadpunkte und Punkt‑Typen enthalten. Jeder zurückgegebene [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) stellt seine Arrays [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) und [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) bereit. Diese Darstellung ist nützlich für Konturanalysen oder um Geometrie an benutzerdefinierte Zeichenwerkzeuge zu übergeben.

Das Beispiel öffnet eine Präsentation, findet die erste Geometrieform direkt auf der ersten Folie und gibt ihre Pfadsegmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgabearten zu sehen. Es wird nicht innerhalb von Gruppen gesucht.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
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

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Die Arrays korrespondieren nach Index: `points[i]` ist ein Punkt und `types[i]` beschreibt dessen Rolle. Typ `0` startet eine Figur, und Typ `1` zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment beginnt am vorherigen Endpunkt und verwendet drei aufeinanderfolgende Typ‑`3`‑Einträge: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge zusammen und prüft den Endpunkt auf Schließung.

Punkt‑Typen enthalten zudem Flags. Mit einer Maske von `0x07` lässt sich der Segmenttyp ermitteln, und `0x80` wird separat getestet, um einen geschlossenen Unterpfad zu erkennen. Beispiel: `129` (`0x81`) bedeutet ein Linien‑Endpunkt, der einen Unterpfad schließt, und `131` (`0x83`) bedeutet ein Bézier‑Endpunkt, der einen schließt. Der reine Vergleich des Rohwerts mit `1` oder `3` würde diese Fälle übersehen. Weitere Flags, wie Strich (`0x10`) und Marker (`0x20`), ändern den Grund‑Segmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkt (1/72 Zoll) gemessen, wobei X nach rechts und Y nach unten zunimmt. Bei einer nicht gruppierten Form enthalten die extrahierten Koordinaten bereits ihre [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/)‑ und [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/)‑Position und spiegeln ihre aktuelle Breite und Höhe wider. Beispielsweise hat ein nicht gedrehtes Rechteck bei `(100, 200)` mit der Größe `120 × 80` Konturgrenzen von `(100, 200)`–`(220, 280)`. Addieren Sie die Position der Form nicht erneut. Subtrahieren Sie ihr X und Y, um Koordinaten relativ zu ihrem nicht gedrehten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) der Form oder horizontale und vertikale Spiegelungen. Um die angezeigte Kontur wiederzugeben, wenden Sie diese Transformationen um das Zentrum der Form herum an. Bei gruppierten Formen berücksichtigen Sie zudem die Koordinatenabbildung und Transformationen der Gruppe; gehen Sie nicht davon aus, dass die extrahierten Punkte die endgültigen gerenderten Folienkoordinaten sind, und wenden Sie keine Übersetzung oder Skalierung doppelt an, wenn sie bereits im Rahmen des Kindobjekts enthalten ist.

**Inspektion versus Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; deren Änderung aktualisiert die ursprüngliche Form nicht. Verwenden Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichen‑Logik Punkt‑/Typ‑Arrays benötigt. Nutzen Sie [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/), wenn Sie Geometrie‑Befehle im lokalen Koordinatensystem der Form benötigen oder deren Geometrie bearbeiten möchten. Wenden Sie bearbeitete Pfade über [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) bzw. [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) an.

## **FAQ**

**Was passiert mit Füllung und Kontur, wenn die Geometrie ersetzt wird?**

Der Stil bleibt an der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie drehe ich eine benutzerdefinierte Form zusammen mit ihrer Geometrie korrekt?**

Verwenden Sie die Eigenschaft [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) der Form; die Geometrie rotiert mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis zu „sperren“?**

Ja. Exportieren Sie den benötigten [Folie](/slides/de/python-net/convert-powerpoint-to-png/)‑Bereich oder die [Form](/slides/de/python-net/create-shape-thumbnails/)‑Selbst in ein Rasterformat; dies erleichtert die weitere Arbeit mit komplexen Geometrien.