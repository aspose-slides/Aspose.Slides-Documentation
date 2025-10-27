---
title: Connectors in Präsentationen mit Python verwalten
linktitle: Connector
type: docs
weight: 10
url: /de/python-net/developer-guide/presentation-content/powerpoint-shapes/shape-types/connector/
keywords:
- connector
- connector type
- connector point
- connector line
- connector angle
- connect shapes
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Ermöglichen Sie Python‑Apps das Zeichnen, Verbinden und automatisches Routen von Linien in PowerPoint‑ und OpenDocument‑Folien – erhalten Sie volle Kontrolle über gerade, Ellenbogen‑ und Kurven‑Connectoren."
---

## **Einführung**

Ein PowerPoint‑Connector ist eine spezielle Linie, die zwei Formen verbindet und beim Verschieben oder Neu­positionieren der Formen auf einer Folie angeheftet bleibt. Connectoren werden an **Verbindungspunkten** (grüne Punkte) von Formen angebracht. Verbindungspunkte erscheinen, wenn der Zeiger sich ihnen nähert. **Anpassungspunkte** (gelbe Punkte), die bei bestimmten Connectoren verfügbar sind, ermöglichen das Ändern von Position und Form eines Connectors.

## **Connector‑Typen**

In PowerPoint können Sie drei Arten von Connectoren verwenden: gerade, Ellenbogen (gekrümmt) und kurvig.

Aspose.Slides unterstützt die folgenden Connector‑Typen:

| Connector‑Typ                     | Bild                                                       | Anzahl der Anpassungspunkte |
| --------------------------------- | ---------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`                  | ![Line connector](shapetype-lineconnector.png)            | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1`   | ![Straight connector 1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`       | ![Bent connector 2](shapetype-bent-connector2.png)        | 0                           |
| `ShapeType.BENT_CONNECTOR3`       | ![Bent connector 3](shapetype-bentconnector3.png)         | 1                           |
| `ShapeType.BENT_CONNECTOR4`       | ![Bent connector 4](shapetype-bentconnector4.png)         | 2                           |
| `ShapeType.BENT_CONNECTOR5`       | ![Bent connector 5](shapetype-bentconnector5.png)         | 3                           |
| `ShapeType.CURVED_CONNECTOR2`     | ![Curved connector 2](shapetype-curvedconnector2.png)     | 0                           |
| `ShapeType.CURVED_CONNECTOR3`     | ![Curved connector 3](shapetype-curvedconnector3.png)     | 1                           |
| `ShapeType.CURVED_CONNECTOR4`     | ![Curved connector 4](shapetype-curvedconnector4.png)     | 2                           |
| `ShapeType.CURVED_CONNECTOR5`     | ![Curved connector 5](shapetype.curvedconnector5.png)     | 3                           |

## **Formen mit Connectoren verbinden**

Dieser Abschnitt zeigt, wie Formen mit Connectoren in Aspose.Slides verknüpft werden. Sie fügen einer Folie einen Connector hinzu und heften dessen Anfang und Ende an Ziel­formen. Durch die Verwendung von Verbindungspunkten bleibt der Connector „geklebt“, selbst wenn sich die Formen verschieben oder ihre Größe ändern.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.  
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekte mit der Methode `add_auto_shape` der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Klasse hinzu.  
4. Fügen Sie mit der Methode `add_connector` der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Klasse einen Connector hinzu und geben Sie den Connector‑Typ an.  
5. Verbinden Sie die Formen mit dem Connector.  
6. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungsweg anzuwenden.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie ein gebogener Connector zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzugefügt wird:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei zu erstellen.
with slides.Presentation() as presentation:

    # Zugriff auf die Shapes‑Collection der ersten Folie.
    shapes = presentation.slides[0].shapes

    # Eine Ellipse hinzufügen.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Ein Rechteck hinzufügen.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Einen Connector zur Folie hinzufügen.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Formen mit dem Connector verbinden.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Reroute aufrufen, um den kürzesten Pfad zu setzen.
    connector.reroute()

    # Präsentation speichern.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="HINWEIS" color="warning" %}}

Die Methode `connector.reroute` routet einen Connector neu und zwingt ihn, den kürzesten möglichen Pfad zwischen den Formen zu wählen. Dabei können die Werte `start_shape_connection_site_index` und `end_shape_connection_site_index` angepasst werden.

{{% /alert %}}

## **Verbindungspunkte angeben**

In diesem Abschnitt wird erläutert, wie ein Connector an einem bestimmten Verbindungspunkt einer Form in Aspose.Slides befestigt wird. Durch das Anvisieren konkreter Verbindungspunkte können Sie das Routing und Layout des Connectors steuern und saubere, vorhersehbare Diagramme in Ihren Präsentationen erzeugen.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.  
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekte mit `add_auto_shape` der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Klasse hinzu.  
4. Fügen Sie mit `add_connector` der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Klasse einen Connector hinzu und geben Sie den Connector‑Typ an.  
5. Verbinden Sie die Formen mit dem Connector.  
6. Legen Sie Ihre bevorzugten Verbindungspunkte an den Formen fest.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie ein bevorzugter Verbindungspunkt angegeben wird:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei zu erstellen.
with slides.Presentation() as presentation:

    # Zugriff auf die Shapes‑Collection der ersten Folie.
    shapes = presentation.slides[0].shapes

    # Eine Ellipse hinzufügen.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Ein Rechteck hinzufügen.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Einen Connector zur Shapes‑Collection der Folie hinzufügen.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Formen mit dem Connector verbinden.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Den bevorzugten Verbindungspunkt‑Index an der Ellipse festlegen.
    site_index = 6

    # Prüfen, ob der bevorzugte Index innerhalb der verfügbaren Punkte liegt.
    if ellipse.connection_site_count > site_index:
        # Den bevorzugten Verbindungspunkt an der Ellipse‑AutoShape zuweisen.
        connector.start_shape_connection_site_index = site_index

    # Präsentation speichern.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Connector‑Punkte anpassen**

Connectoren können über ihre Anpassungspunkte modifiziert werden. Nur Connectoren, die Anpassungspunkte besitzen, lassen sich auf diese Weise bearbeiten. Welche Connectoren Anpassungen unterstützen, sehen Sie in der Tabelle unter [Connector‑Typen](/slides/de/python-net/connector/#connector-types).

### **Einfacher Fall**

Betrachten Sie den Fall, dass ein Connector zwischen zwei Formen (A und B) eine dritte Form (C) schneidet:

![Connector obstruction](connector-obstruction.png)

Code‑Beispiel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

Um die dritte Form zu umgehen, passen Sie den Connector an, indem Sie den vertikalen Abschnitt nach links verschieben:

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Komplexe Fälle**

Für anspruchsvollere Anpassungen beachten Sie Folgendes:

- Der anpassbare Punkt eines Connectors wird durch eine Formel bestimmt, die seine Position festlegt.Änderungen dieses Punkts können die Gesamtdarstellung des Connectors verändern.  
- Die Anpassungspunkte eines Connectors werden in einem streng geordneten Array gespeichert, beginnend vom Start‑ zum Endpunkt.  
- Die Werte der Anpassungspunkte stellen Prozentsätze der Breite/Höhe der Connector‑Form dar.  
  - Die Form wird durch Start‑ und Endpunkt begrenzt und mit dem Faktor 1000 skaliert.  
  - Der erste, zweite und dritte Anpassungspunkt stehen für: Prozent der Breite, Prozent der Höhe und erneut Prozent der Breite.  
- Beim Berechnen der Koordinaten der Anpassungspunkte muss die Rotation und Spiegelung des Connectors berücksichtigt werden. **Hinweis:** Für alle unter [Connector‑Typen](/slides/de/python-net/connector/#connector-types) aufgeführten Connectoren beträgt der Rotationswinkel 0.

#### **Fall 1**

Zwei Textfeld‑Objekte werden mit einem Connector verbunden:

![Linked shapes](connector-shape-complex.png)

Code‑Beispiel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei zu erstellen.
with slides.Presentation() as presentation:

    # Erste Folie holen.
    slide = presentation.slides[0]

    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Einen Connector hinzufügen.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Richtung des Connectors setzen.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Farbe des Connectors setzen.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Linienstärke setzen.
    connector.line_format.width = 3

    # Formen mit dem Connector verbinden.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Anpassungspunkte des Connectors holen.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Anpassung**

Erhöhen Sie die Werte der Anpassungspunkte: Breiten‑Prozentsatz um 20 % und Höhen‑Prozentsatz um 200 %:

```python
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Ergebnis:

![Connector adjustment 1](connector-adjusted-1.png)

Um ein Modell zu definieren, das die Koordinaten und Formen der Connector‑Segmente berechnet, erzeugen Sie eine Form, die dem vertikalen Bestandteil des Connectors bei `connector.adjustments[0]` entspricht:

```python
    # Vertikalen Teil des Connectors zeichnen.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Ergebnis:

![Connector adjustment 2](connector-adjusted-2.png)

#### **Fall 2**

Im **Fall 1** haben wir eine einfache Anpassung demonstriert. In typischen Szenarien müssen Sie die Rotation des Connectors sowie dessen Anzeigeeinstellungen (`connector.rotation`, `connector.frame.flip_h`, `connector.frame.flip_v`) berücksichtigen. So geht’s:

Zuerst ein neues Textfeld‑Objekt (**To 1**) zur Folie hinzufügen und einen neuen grünen Connector erstellen, der es mit den bestehenden Objekten verbindet.

```python
    # Neuer Ziel‑Objekt erzeugen.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Neuen Connector erzeugen.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Objekte mit dem neuen Connector verbinden.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Anpassungspunkte holen.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Werte der Anpassungspunkte ändern.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Ergebnis:

![Connector adjustment 3](connector-adjusted-3.png)

Als Nächstes eine Form erzeugen, die dem **horizontalen** Segment des Connectors entspricht, das durch das neue Anpassungspunkt `connector.adjustments[0]` verläuft. Verwenden Sie die Werte aus `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v` und die Standard‑Koordinaten‑Umrechnungsformel für die Rotation um den Punkt `x0`:

```
X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;
```

In unserem Fall beträgt der Rotationswinkel 90° und der Connector wird vertikal angezeigt, also:

```python
    # Connector‑Koordinaten sichern.
    x = connector.x
    y = connector.y
    
    # Koordinaten korrigieren, falls gespiegelt.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Anpassungspunkt‑Wert als Koordinate verwenden.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Koordinaten umrechnen, da sin(90°)=1 und cos(90°)=0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Breite des horizontalen Segments mit dem zweiten Anpassungspunkt bestimmen.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Ergebnis:

![Connector adjustment 4](connector-adjusted-4.png)

Wir haben sowohl einfache als auch komplexe Anpassungen (unter Berücksichtigung von Rotation) demonstriert. Mit diesem Wissen können Sie eigene Modelle erstellen – etwa einen `GraphicsPath` generieren oder die Anpassungspunkte eines Connectors basierend auf konkreten Folien‑Koordinaten setzen.

## **Connector‑Linienwinkel ermitteln**

Im folgenden Beispiel wird gezeigt, wie Sie mit Aspose.Slides den Winkel von Connector‑Linien auf einer Folie bestimmen. Sie lernen, wie Sie die Endpunkte eines Connectors auslesen und seine Orientierung berechnen, um Pfeile, Beschriftungen und andere Formen exakt auszurichten.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich die Folie über ihren Index.  
3. Greifen Sie auf die Connector‑Linienform zu.  
4. Verwenden Sie Breite und Höhe der Linie sowie die Breite und Höhe des Formrahmens, um den Winkel zu berechnen.

Der folgende Python‑Code demonstriert die Winkelberechnung für eine Connector‑Linienform:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **FAQ**

**Wie erkenne ich, ob ein Connector an einer bestimmten Form „geklebt“ werden kann?**

Prüfen Sie, ob die Form [Verbindungspunkte](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/) bereitstellt. Gibt es keine oder ist die Anzahl 0, ist ein Kleben nicht möglich; in diesem Fall verwenden Sie freie Endpunkte und positionieren sie manuell. Es empfiehlt sich, die Anzahl vor dem Anheften zu prüfen.

**Was passiert mit einem Connector, wenn ich eine der verbundenen Formen lösche?**

Die Enden werden gelöst; der Connector bleibt als gewöhnliche Linie mit freien Start‑/Endpunkten auf der Folie bestehen. Sie können ihn löschen oder die Verbindungen neu zuweisen und bei Bedarf [rerouten](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/).

**Werden Connector‑Bindungen beim Kopieren einer Folie in eine andere Präsentation erhalten?**

In der Regel ja, vorausgesetzt, die Ziel­formen werden ebenfalls kopiert. Wird die Folie in eine Datei ohne die verbundenen Formen eingefügt, werden die Enden frei und Sie müssen sie erneut anheften.