---
title: Anpassen von Präsentationsformen in Python
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
description: "Erstellen und Anpassen von Formen in PowerPoint-Präsentationen mit Aspose.Slides für Python via .NET: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Sie Präsentationsformen in Aspose.Slides anpassen können, indem Sie die Formgeometrie über Bearbeitungspunkte und Geometriepfade bearbeiten. Er zeigt, wie man mit [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) vorhandene Formen modifiziert, grundlegende Pfad‑Bearbeitungsoperationen durchführt, Punkte hinzufügt oder entfernt und die aktualisierte Geometrie wieder auf eine Form anwendet.

Er demonstriert zudem, wie man benutzerdefinierte und zusammengesetzte Formen erstellt, Formen mit abgerundeten Ecken baut, ermittelt, ob eine Formgeometrie geschlossen ist, und Form‑Elemente für Kontur‑Analysen extrahiert.

## **Form mit Bearbeitungspunkten ändern**

In PowerPoint können Sie **Bearbeitungspunkte** verwenden, um ein Quadrat zu verändern:

* Einen Eckpunkt nach innen oder außen verschieben.
* Die Krümmung an einem Punkt anpassen.
* Neue Punkte hinzufügen.

Das Bearbeiten von Punkten ermöglicht es, die Kontur einer Form zu ändern oder eine vorhandene Form als Grundlage für eine neue zu nutzen.

## **Tipps zur Formbearbeitung**

![Übersicht_Bild](custom_shape_0.png)

Beim Bearbeiten von PowerPoint‑Formen sollten Sie diese Konzepte beachten:

* Eine Form (oder ihr Pfad) kann entweder geschlossen oder offen sein.
* Der Pfad einer Form besteht aus Ankerpunkten, die durch Segmente verbunden sind.
* Ein Segment kann gerade oder gekrümmt sein. Ankerpunkte und Steuergriffe bestimmen seine Form.
* Ankerpunkte existieren als Eckpunkte, gerade Punkte oder glatte Punkte:
  * Bei einem Eckpunkt können angrenzende Segmente unter einem Winkel zusammenlaufen.
  * Bei einem glatten Punkt sind die beiden Steuergriffe ausgerichtet und gleich weit vom Ankerpunkt entfernt.
  * Bei einem geraden Punkt sind die beiden Steuergriffe ausgerichtet, können aber unterschiedliche Abstände zum Ankerpunkt haben.
* Das Verschieben von Ankerpunkten oder das Anpassen ihrer Griffe ändert die Kontur der Form.

Um PowerPoint‑Formen über Bearbeitungspunkte zu bearbeiten, stellt **Aspose.Slides** die Klasse [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)-Instanz repräsentiert den Geometriepfad des [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)-Objekts.
* Um den [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) von einer [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)-Instanz zu erhalten, können Sie die Methode [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) verwenden.
* Um den [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) einer Form zu setzen, können Sie diese Methoden verwenden: [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) für Formen mit einem einzigen Pfad und [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) für Formen mit mehreren Pfaden.
* Zum Hinzufügen von Segmenten können Sie die Methoden unter [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) nutzen.
* Mit den Eigenschaften [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) und [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) können Sie das Erscheinungsbild eines Geometriepfads festlegen.
* Über die Eigenschaft [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) können Sie den Geometriepfad einer [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) als Array von Pfadsegmenten abrufen.

## **Einfache Bearbeitungsoperationen**

Verwenden Sie die folgenden Methoden, um einen Geometriepfad zu bearbeiten. Überladungen, die einen Index akzeptieren, fügen ein Segment an dieser nullbasierten Position im Segment‑Array des Pfads ein.

| Operation | Methode |
| --- | --- |
| Eine gerade Linie anhängen oder einfügen. | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| Eine kubische Bézier‑Kurve mit zwei Steuerpunkten und einem Endpunkt anhängen oder einfügen. | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| Eine quadratische Bézier‑Kurve mit einem Steuerpunkt und einem Endpunkt anhängen oder einfügen. | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| Einen elliptischen Bogen mit den angegebenen Abmessungen und Winkeln in Grad anhängen. | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| Die aktuelle Figur schließen, indem ihr Endpunkt mit dem Startpunkt verbunden wird. | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| Den Startpunkt einer Figur festlegen. | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| Ein Segment an einem nullbasierten Index entfernen. | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **Benutzerdefinierte Punkte zu einer Form hinzufügen**

Dieses Beispiel fügt einer rechteckigen Form zwei Punkte mit [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) ein und wendet den bearbeiteten Pfad mit [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) an. Die Koordinaten sind relativ zur Form: Beide neuen Punkte liegen in ihrem Zentrum, 100 Punkte vom linken Rand und 50 Punkte vom oberen Rand entfernt. Segmentindizes 1 und 4 platzieren sie an den oberen bzw. unteren Kanten und ziehen diese Kanten nach innen.

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

![Beispiel1_Bild](custom_shape_1.png)

## **Punkte aus einer Form entfernen**

Dieses Beispiel ändert die Kontur einer herzförmigen Form, indem es das Segment am nullbasierten Index 2 mit [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) entfernt. Das Anwenden des modifizierten Pfads über [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) aktualisiert die Kontur der Form.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![Beispiel2_Bild](custom_shape_2.png)

## **Eine benutzerdefinierte Form erstellen**

Dieses Beispiel erstellt einen fünfzackigen Stern mit [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/). Wechselnde äußere und innere Radien von 100 bzw. 50 Punkten definieren die Spitzen und Einziehungen; ein Schritt von 72 Grad verteilt die fünf Spitzen gleichmäßig. Der Pfad wird mit [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) geschlossen und über [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) auf ein rechteckiges Grundobjekt angewendet, wodurch dessen Kontur ersetzt wird.

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
![Beispiel3_Bild](custom_shape_3.png)

## **Eine zusammengesetzte benutzerdefinierte Form erstellen**

Dieses Beispiel definiert zwei geschlossene [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)-Objekte für das obere und das untere Drittel einer Form. Das Anwenden beider Pfade mit [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) erzeugt eine einzelne zusammengesetzte Form mit einer Lücke im mittleren Drittel.

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
![Beispiel4_Bild](custom_shape_4.png)

## **Eine benutzerdefinierte Form mit abgerundeten Ecken erstellen**

Dieses Beispiel kombiniert gerade Segmente mit [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/), um eine Form mit nach innen gekrümmten Ecken zu erzeugen. Jeder Eckwert legt die Breite und Höhe des Bogens in Punkten fest, und die -90‑Grad‑Bogenlänge zeichnet ein gegen den Uhrzeigersinn verlaufendes Viertel‑Ellipse. Der fertige Pfad wird über [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) angewendet, und die Präsentation wird im PPTX‑Format gespeichert.

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

Der folgende Helfer prüft, ob jeder nicht leere Geometriepfad mit einem Schließsegment endet. Er liest [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) und vergleicht das letzte Segment‑Kommando [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) mit [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/). Er gibt **false** zurück, wenn keine nicht leeren Pfade existieren. Diese Prüfung betrachtet das Abschluss‑Kommando jedes Pfads; sie inspiziert nicht jede Unterfigur innerhalb eines Pfads. Das Beispiel gibt `True` für ein Rechteck aus.

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

## **Geometrie‑Pfad‑Kommandos untersuchen**

Laden Sie [contour.pptx](contour.pptx) herunter und legen Sie die Datei in Ihrem Arbeitsverzeichnis ab. Die erste Form auf der ersten Folie hat eine gerade obere Kante, eine kubische Bézier‑Kurve und eine gerade abschließende Kante. Verwenden Sie [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/), um deren Pfade zu lesen. Für jeden Pfad listet [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) die Segmente in Zeichenreihenfolge auf. Das [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) jedes Segments bestimmt, wie dessen [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/) zu interpretieren ist.

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

Die Form befindet sich bei (200, 100) Punkten auf der Folie. Die angegebenen Koordinaten sind relativ zur Form. Ihre obere linke Ecke ist (0, 0), x nimmt nach rechts zu, y nach unten. Das Schließsegment kehrt ohne zusätzliche Koordinaten zum Startpunkt zurück.

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint‑Form mit gerader oberer Kante, einer gekrümmten Kante von rechts‑oben nach links‑unten und einer geraden linken Kante](contour.png)

## **Form‑Elemente extrahieren und untersuchen**

Verwenden Sie [GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/), um eine bestehende Form als Elemente zu untersuchen, die Pfad‑Punkte und Punkt‑Typen enthalten. Jeder zurückgegebene [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) stellt seine Arrays [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) und [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) zur Verfügung. Diese Darstellung ist nützlich für Konturanalysen oder zum Weitergeben der Geometrie an benutzerdefinierte Zeichen‑Tools.

Das Beispiel öffnet eine Präsentation, findet die erste GeometryShape direkt auf der ersten Folie und gibt deren Pfad‑Segmente aus. Verwenden Sie eine Präsentation, die eine Form mit geraden und gekrümmten Segmenten enthält, um beide Ausgabearten zu sehen. Es wird nicht in Gruppen gesucht.

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
                    i += 2  # Verbrauche beide Kontrollpunkte und den Endpunkt.

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

Die Arrays korrespondieren nach Index: `points[i]` ist ein Punkt und `types[i]` beschreibt seine Rolle. Typ 0 startet eine Figur, und Typ 1 zeichnet eine Linie vom vorherigen Punkt zum aktuellen Punkt. Ein kubisches Bézier‑Segment startet am vorherigen Endpunkt und verwendet drei aufeinanderfolgende Typ‑`3`‑Einträge: zwei Steuerpunkte gefolgt vom neuen Endpunkt. Die Schleife verarbeitet diese drei Einträge gemeinsam und prüft das Endsegment auf Abschluß.

Punkt‑Typen enthalten zudem Flags. Maskieren Sie mit `0x07`, um den Segmenttyp zu ermitteln, und testen Sie `0x80` separat, um einen geschlossenen Unterpfad zu erkennen. Beispielsweise bedeutet `129` (`0x81`) ein Linien‑Endpunkt, das einen Unterpfad schließt, und `131` (`0x83`) ein Bézier‑Endpunkt, das einen schließt. Ein reiner Vergleich des Rohwerts mit `1` oder `3` würde diese Fälle übersehen. Weitere Flags wie Strich (`0x10`) und Marker (`0x20`) ändern den Grund‑Segmenttyp nicht.

**Koordinaten und Transformationen.** Punkte werden in Punkt (1/72 Zoll) gemessen, wobei X nach rechts und Y nach unten wächst. Bei einer nicht gruppierten Form sind die extrahierten Koordinaten bereits um ihre [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/)‑ und [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/)‑Position ergänzt und spiegeln die aktuelle Breite und Höhe wider. Beispiel: Ein nicht gedrehtes Rechteck bei `(100, 200)` mit Größe `120 × 80` hat Kontur‑Grenzen `(100, 200)`–`(220, 280)`. Fügen Sie die Position der Form nicht erneut hinzu. Subtrahieren Sie X und Y, um Koordinaten relativ zu ihrem nicht gedrehten Rahmen zu erhalten.

Die extrahierten Punkte berücksichtigen nicht die [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) der Form sowie horizontale und vertikale Spiegelungen. Um die dargestellte Kontur zu reproduzieren, wenden Sie diese Transformationen um den Mittelpunkt der Form an. Bei gruppierten Formen berücksichtigen Sie zudem die Gruppen‑Koordinaten‑Abbildung und Transformationen; gehen Sie nicht davon aus, dass die extrahierten Punkte bereits die endgültigen Folien‑Koordinaten sind oder dass Sie eine Translation bzw. Skalierung doppelt anwenden.

**Untersuchung vs. Bearbeitung.** Extrahierte Arrays beschreiben die Kontur; Änderungen an ihnen aktualisieren nicht die ursprüngliche Form. Nutzen Sie diesen Ansatz, wenn Ihre Analyse‑ oder Zeichen‑Logik Punkt‑/Typ‑Arrays benötigt. Verwenden Sie [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/), wenn Sie Geometrie‑Kommandos im lokalen Koordinatensystem der Form benötigen oder die Geometrie bearbeiten möchten. Wenden Sie bearbeitete Pfade über [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) oder [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) an.

## **FAQ**

**Was passiert mit Füllung und Kontur, nachdem die Geometrie ersetzt wurde?**

Der Stil bleibt an der Form erhalten; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie rotiere ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie?**

Verwenden Sie die Eigenschaft [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) der Form; die Geometrie rotiert mit der Form, weil sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis „einzusperren“?**

Ja. Exportieren Sie den gewünschten [Folie](/slides/de/python-net/convert-powerpoint-to-png/)‑Bereich oder die [Form](/slides/de/python-net/create-shape-thumbnails/) selbst in ein Rasterformat; das vereinfacht die weitere Arbeit mit komplexen Geometrien.