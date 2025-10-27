---
title: Formen in Präsentationen mit Python anpassen
linktitle: Benutzerdefinierte Form
type: docs
weight: 20
url: /de/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/custom-shapes/
keywords:
- benutzerdefinierte Form
- Form hinzufügen
- Form erstellen
- Form ändern
- Formgeometrie
- Geometriepfad
- Pfadpunkte
- Punkte bearbeiten
- Punkt hinzufügen
- Punkt entfernen
- Bearbeitungsvorgang
- abgerundete Ecke
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und Anpassen von Formen in PowerPoint- und OpenDocument‑Präsentationen mit Aspose.Slides für Python via .NET: Geometriepfade, abgerundete Ecken, zusammengesetzte Formen."
---

## **Übersicht**

Betrachten Sie ein Quadrat. In PowerPoint können Sie mit **Edit Points**:

* die Ecke eines Quadrats nach innen oder außen verschieben,
* die Krümmung einer Ecke oder eines Punktes anpassen,
* neue Punkte zum Quadrat hinzufügen,
* seine Punkte manipulieren.

Sie können diese Vorgänge auf jede Form anwenden. Mit **Edit Points** können Sie eine Form ändern oder aus einer vorhandenen Form eine neue erstellen.

## **Tipps zur Formbearbeitung**

!["Edit Points"-Befehl](custom_shape_0.png)

Bevor Sie mit **Edit Points** Formen in PowerPoint bearbeiten, beachten Sie diese Hinweise zu Formen:

* Eine Form (oder ihr Pfad) kann **geschlossen** oder **offen** sein.
* Eine geschlossene Form hat keinen Anfangs‑ oder Endpunkt; eine offene Form hat einen Anfang und ein Ende.
* Jede Form hat mindestens zwei Ankerpunkte, die durch Liniensegmente verbunden sind.
* Ein Segment ist entweder gerade oder gekrümmt; Ankerpunkte bestimmen die Art des Segments.
* Ankerpunkte können **Ecke**, **glatt** oder **gerade** sein:
  * Ein **Eck**‑Punkt ist dort, wo zwei gerade Segmente in einem Winkel aufeinandertreffen.
  * Ein **glatter** Punkt hat zwei Griffe, die kollinear sind, und die angrenzenden Segmente bilden eine glatte Kurve. In diesem Fall haben beide Griffe den gleichen Abstand vom Ankerpunkt.
  * Ein **gerader** Punkt hat ebenfalls zwei kollineare Griffe, und die angrenzenden Segmente bilden eine glatte Kurve. Hier müssen die Griffe nicht den gleichen Abstand vom Ankerpunkt haben.
* Durch Verschieben oder Bearbeiten von Ankerpunkten (und damit Ändern der Segmentwinkel) können Sie das Aussehen der Form ändern.

Um PowerPoint‑Formen zu bearbeiten, stellt Aspose.Slides die Klasse [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) bereit.

* Eine [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)-Instanz repräsentiert den Geometriepfad eines [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)-Objekts.
* Um den [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) von einer [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/)-Instanz zu erhalten, verwenden Sie die Methode [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/).
* Um den [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) für eine Form zu setzen, verwenden Sie [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) für *solide Formen* und [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) für *zusammengesetzte Formen*.
* Zum Hinzufügen von Segmenten nutzen Sie die Methoden von [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
* Verwenden Sie die Eigenschaften [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) und [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/), um das Erscheinungsbild eines Geometriepfads zu steuern.
* Mit der Eigenschaft [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) können Sie den Geometriepfad einer Form als Array von Pfadsegmenten abrufen.

## **Einfache Bearbeitungsvorgänge**

Die folgenden Methoden werden für einfache Bearbeitungsvorgänge verwendet.

**Eine Linie** am Ende eines Pfads hinzufügen:

```py
line_to(point)
line_to(x, y)
```

**Eine Linie** an einer angegebenen Position in einem Pfad hinzufügen:

```py    
line_to(point, index)
line_to(x, y, index)
```

**Eine kubische Bézier‑Kurve** am Ende eines Pfads hinzufügen:

```py
cubic_bezier_to(point1, point2, point3)
cubic_bezier_to(x1, y1, x2, y2, x3, y3)
```

**Eine kubische Bézier‑Kurve** an einer angegebenen Position in einem Pfad hinzufügen:

```py
cubic_bezier_to(point1, point2, point3, index)
cubic_bezier_to(x1, y1, x2, y2, x3, y3, index)
```

**Eine quadratische Bézier‑Kurve** am Ende eines Pfads hinzufügen:

```py
quadratic_bezier_to(point1, point2)
quadratic_bezier_to(x1, y1, x2, y2)
```

**Eine quadratische Bézier‑Kurve** an einer angegebenen Position in einem Pfad hinzufügen:

```py
quadratic_bezier_to(point1, point2, index)
quadratic_bezier_to(x1, y1, x2, y2, index)
```

**Einen Bogen** an einen Pfad anhängen:

```py
arc_to(width, heigth, startAngle, sweepAngle)
```

**Die aktuelle Figur** in einem Pfad schließen:

```py
close_figure()
```

**Die Position für den nächsten Punkt** festlegen:

```py
move_to(point)
move_to(x, y)
```

**Das Pfadsegment** an einem angegebenen Index entfernen:

```py
remove_at(index)
```

## **Benutzerdefinierte Punkte zu Formen hinzufügen**

Hier lernen Sie, wie Sie eine Freiform‑Form definieren, indem Sie Ihre eigene Punktsequenz hinzufügen. Durch Angabe geordneter Punkte und Segmenttypen (gerade oder gekrümmt) und optionales Schließen des Pfads können Sie präzise Grafiken – Polygon‑, Icon‑, Callout‑ oder Logo‑Formen – direkt auf Ihren Folien zeichnen.

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) und setzen Sie deren [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Holen Sie sich eine [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)-Instanz von der Form.
3. Fügen Sie einen neuen Punkt zwischen den beiden oberen Punkten des Pfads ein.
4. Fügen Sie einen neuen Punkt zwischen den beiden unteren Punkten des Pfads ein.
5. Wenden Sie den aktualisierten Pfad auf die Form an.

Der folgende Python‑Code zeigt, wie Sie benutzerdefinierte Punkte zu einer Form hinzufügen:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)

    presentation.save("custom_points.pptx", slides.export.SaveFormat.PPTX)
```

![Benutzerdefinierte Punkte](custom_shape_1.png)

##  **Punkte aus Formen entfernen**

Manchmal enthält eine benutzerdefinierte Form unnötige Punkte, die ihre Geometrie verkomplizieren oder das Rendering beeinflussen. Dieser Abschnitt zeigt, wie Sie bestimmte Punkte aus dem Pfad einer Form entfernen, um die Kontur zu vereinfachen und sauberere, präzisere Ergebnisse zu erzielen.

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) und setzen Sie den Typ auf [ShapeType.HEART](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/).
2. Holen Sie sich eine [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)-Instanz von der Form.
3. Entfernen Sie ein Segment aus dem Pfad.
- 4. Wenden Sie den aktualisierten Pfad auf die Form an.

Der folgende Python‑Code zeigt, wie Sie Punkte aus einer Form entfernen:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)

    presentation.save("removed_points.pptx", slides.export.SaveFormat.PPTX)
```

![Entfernte Punkte](custom_shape_2.png)

##  **Benutzerdefinierte Formen erstellen**

Erstellen Sie maßgeschneiderte Vektorformen, indem Sie einen [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) definieren und ihn aus Linien, Bögen und Bézier‑Kurven zusammensetzen. Dieser Abschnitt zeigt, wie Sie von Grund auf eine benutzerdefinierte Geometrie bauen und die resultierende Form Ihrer Folie hinzufügen.

1. Berechnen Sie die Punkte für die Form.
2. Erstellen Sie eine Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Befüllen Sie den Pfad mit den Punkten.
4. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
5. Wenden Sie den Pfad auf die Form an.

Der folgende Python‑Code zeigt, wie Sie eine benutzerdefinierte Form erstellen:

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

R = 100
r = 50
step = 72

for angle in range(-90, 270, step):
    radians = angle * (math.pi / 180)
    x = R * math.cos(radians)
    y = R * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

    radians = math.pi * (angle + step / 2) / 180.0
    x = r * math.cos(radians)
    y = r * math.sin(radians)
    points.append(draw.PointF(x + R, y + R))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, R * 2, R * 2)
    shape.set_geometry_path(star_path)

    presentation.save("custom_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Benutzerdefinierte Form](custom_shape_3.png)

## **Zusammengesetzte benutzerdefinierte Formen erstellen**

Das Erstellen einer zusammengesetzten benutzerdefinierten Form ermöglicht es Ihnen, mehrere Geometriepfade zu einer einzigen, wiederverwendbaren Form auf einer Folie zu kombinieren. Definieren und verbinden Sie diese Pfade, um komplexe Visualisierungen zu bauen, die über den Standard‑Formensatz hinausgehen.

1. Erstellen Sie eine Instanz der Klasse [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/).
2. Erstellen Sie die erste Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
3. Erstellen Sie die zweite Instanz der Klasse [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/).
4. Wenden Sie beide Pfade auf die Form an.

Der folgende Python‑Code zeigt, wie Sie eine zusammengesetzte benutzerdefinierte Form erstellen:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path_0 = slides.GeometryPath()
    geometry_path_0.move_to(0, 0)
    geometry_path_0.line_to(shape.width, 0)
    geometry_path_0.line_to(shape.width, shape.height/3)
    geometry_path_0.line_to(0, shape.height / 3)
    geometry_path_0.close_figure()

    geometry_path_1 = slides.GeometryPath()
    geometry_path_1.move_to(0, shape.height/3 * 2)
    geometry_path_1.line_to(shape.width, shape.height / 3 * 2)
    geometry_path_1.line_to(shape.width, shape.height)
    geometry_path_1.line_to(0, shape.height)
    geometry_path_1.close_figure()

    shape.set_geometry_paths([ geometry_path_0, geometry_path_1])

    presentation.save("composite_shape.pptx", slides.export.SaveFormat.PPTX)
```

![Zusammengesetzte Form](custom_shape_4.png)

## **Benutzerdefinierte Formen mit abgerundeten Ecken erstellen**

Dieser Abschnitt zeigt, wie Sie mit einem Geometriepfad eine benutzerdefinierte Form mit sanft abgerundeten Ecken zeichnen. Sie kombinieren gerade Segmente und kreisförmige Bögen, um die Kontur zu bilden, und fügen die fertige Form Ihrer Folie hinzu.

Der folgende Python‑Code zeigt, wie Sie eine benutzerdefinierte Form mit abgerundeten Ecken erstellen:

```py
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

    shape = slide.shapes.add_auto_shape(
        slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    point1 = draw.PointF(left_top_size, 0)
    point2 = draw.PointF(shape_width - right_top_size, 0)
    point3 = draw.PointF(shape_width, shape_height - right_bottom_size)
    point4 = draw.PointF(left_bottom_size, shape_height)
    point5 = draw.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(point1)
    geometry_path.line_to(point2)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(point3)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(point4)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(point5)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("curved_corners.pptx", slides.export.SaveFormat.PPTX)
```

![Abgerundete Ecken](custom_shape_6.png)

## **Ermitteln, ob die Geometrie einer Form geschlossen ist**

Eine geschlossene Form ist definiert als eine Form, bei der alle Seiten miteinander verbunden sind und eine durchgehende Grenze ohne Lücken bilden. Eine solche Form kann eine einfache geometrische Form oder ein komplexer benutzerdefinierter Umriss sein. Der folgende Code zeigt, wie Sie prüfen, ob eine Formgeometrie geschlossen ist:

```py
def is_geometry_closed(geometry_shape):
    is_closed = None

    for geometry_path in geometry_shape.get_geometry_paths():
        data_length = len(geometry_path.path_data)
        if data_length == 0:
            continue

        last_segment = geometry_path.path_data[data_length - 1]
        is_closed = last_segment.path_command == PathCommandType.CLOSE

        if not is_closed:
            return False

    return is_closed
```

## **FAQ**

**Was passiert mit Füllung und Kontur, wenn die Geometrie ersetzt wird?**

Der Stil bleibt bei der Form; nur die Kontur ändert sich. Füllung und Kontur werden automatisch auf die neue Geometrie angewendet.

**Wie drehe ich eine benutzerdefinierte Form korrekt zusammen mit ihrer Geometrie?**

Verwenden Sie die [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/rotation/)-Eigenschaft der Form; die Geometrie rotiert mit der Form, da sie an das eigene Koordinatensystem der Form gebunden ist.

**Kann ich eine benutzerdefinierte Form in ein Bild konvertieren, um das Ergebnis "einzusperren"?**

Ja. Exportieren Sie den gewünschten [Folien](/slides/de/python-net/convert-powerpoint-to-png/)-Bereich oder die [Form](/slides/de/python-net/create-shape-thumbnails/) selbst in ein Rasterformat; das vereinfacht die weitere Arbeit mit komplexen Geometrien.