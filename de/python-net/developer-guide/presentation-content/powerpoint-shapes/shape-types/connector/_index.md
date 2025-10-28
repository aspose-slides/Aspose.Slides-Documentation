---
title: Verwalten von Verbindern in Präsentationen mit Python
linktitle: Verbinder
type: docs
weight: 10
url: /de/python-net/connector/
keywords:
- Verbinder
- Verbindertyp
- Verbindungspunkt
- Verbindungslinie
- Verbindungswinkel
- Formen verbinden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Ermöglichen Sie Python‑Anwendungen, Linien in PowerPoint‑ und OpenDocument‑Folien zu zeichnen, zu verbinden und automatisch zu routen – erhalten Sie die vollständige Kontrolle über gerade, abgewinkelte und gekrümmte Verbinder."
---

## **Einleitung**

Ein PowerPoint‑Verbinder ist eine spezialisierte Linie, die zwei Formen verbindet und an diesen befestigt bleibt, wenn die Formen auf einer Folie verschoben oder neu positioniert werden. Verbinder werden an **Verbindungspunkten** (grüne Punkte) von Formen angebracht. Verbindungspunkte erscheinen, wenn der Zeiger ihnen nahekommt. **Anpassungsgriffe** (gelbe Punkte), die bei bestimmten Verbindern verfügbar sind, ermöglichen das Ändern von Position und Form eines Verbinders.

## **Verbindertypen**

In PowerPoint können Sie drei Arten von Verbindern verwenden: gerade, abgewinkelt (Ellenbogen) und gekrümmt.

Aspose.Slides unterstützt die folgenden Verbindertypen:

| Verbindertyp                     | Bild                                                       | Anzahl der Anpassungspunkte |
| -------------------------------- | ---------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`                 | ![Linienverbinder](shapetype-lineconnector.png)           | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1`  | ![Gerader Verbinder 1](shapetype-straightconnector1.png)   | 0                           |
| `ShapeType.BENT_CONNECTOR2`      | ![Gebogener Verbinder 2](shapetype-bent-connector2.png)   | 0                           |
| `ShapeType.BENT_CONNECTOR3`      | ![Gebogener Verbinder 3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BENT_CONNECTOR4`      | ![Gebogener Verbinder 4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BENT_CONNECTOR5`      | ![Gebogener Verbinder 5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CURVED_CONNECTOR2`    | ![Gekrümmter Verbinder 2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CURVED_CONNECTOR3`    | ![Gekrümmter Verbinder 3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CURVED_CONNECTOR4`    | ![Gekrümmter Verbinder 4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CURVED_CONNECTOR5`    | ![Gekrümmter Verbinder 5](shapetype.curvedconnector5.png) | 3                           |

## **Formen mit Verbindern verbinden**

Dieser Abschnitt demonstriert, wie Sie Formen mit Verbindern in Aspose.Slides verknüpfen. Sie fügen einer Folie einen Verbinder hinzu und befestigen dessen Anfang und Ende an Ziel­formen. Durch die Verwendung von Verbindungspunkten bleibt der Verbinder „geklebt“ an den Formen, selbst wenn diese verschoben oder skaliert werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.  
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekte mittels der `add_auto_shape`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Instanz hinzu.  
4. Fügen Sie einen Verbinder mittels der `add_connector`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Instanz hinzu und geben Sie den Verbindertyp an.  
5. Verbinden Sie die Formen mit dem Verbinder.  
6. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungsweg anzuwenden.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie zwischen zwei Formen (einer Ellipse und einem Rechteck) einen gebogenen Verbinder hinzufügen:

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Call reroute to set the shortest path.
    connector.reroute()

    # Save the presentation.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="HINWEIS" color="warning" %}}
Die Methode `connector.reroute` routet einen Verbinder neu und zwingt ihn, den kürzesten möglichen Pfad zwischen den Formen zu nehmen. Dabei kann die Methode die Werte von `start_shape_connection_site_index` und `end_shape_connection_site_index` ändern.
{{% /alert %}}

## **Verbindungspunkte angeben**

Dieser Abschnitt erklärt, wie Sie einen Verbinder an einem bestimmten Verbindungspunkt einer Form in Aspose.Slides anbringen. Durch das gezielte Ansteuern genauer Verbindungspunkte können Sie das Routing und Layout von Verbindern steuern und saubere, vorhersehbare Diagramme in Ihren Präsentationen erzeugen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich die Referenz zur Folie über ihren Index.  
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekte mittels `add_auto_shape` der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Instanz hinzu.  
4. Fügen Sie einen Verbinder mithilfe der `add_connector`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Instanz hinzu und geben Sie den Verbindertyp an.  
5. Verbinden Sie die Formen mit dem Verbinder.  
6. Legen Sie Ihre bevorzugten Verbindungspunkte an den Formen fest.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie Sie einen bevorzugten Verbindungspunkt festlegen:

```python
import aspose.slides as slides

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Access the shapes collection for the first slide.
    shapes = presentation.slides[0].shapes

    # Add an ellipse AutoShape.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Add a rectangle AutoShape.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Add a connector to the slide's shape collection.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Connect the shapes with the connector.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Set the preferred connection site index on the ellipse.
    site_index = 6

    # Check that the preferred index is within the available site count.
    if  ellipse.connection_site_count > site_index:
        # Assign the preferred connection site on the ellipse AutoShape.
        connector.start_shape_connection_site_index = site_index

    # Save the presentation.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Verbinderpunkte anpassen**

Sie können Verbinder über deren Anpassungspunkte modifizieren. Nur Verbinder, die Anpassungspunkte bereitstellen, können auf diese Weise bearbeitet werden. Welche Verbinder Anpassungen unterstützen, sehen Sie in der Tabelle unter [Verbindertypen](/slides/de/python-net/connector/#connector-types).

### **Einfacher Fall**

Betrachten Sie den Fall, dass ein Verbinder zwischen zwei Formen (A und B) ein drittes Objekt (C) schneidet:

![Verbindungsbehinderung](connector-obstruction.png)

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

Um das dritte Objekt zu umgehen, verschieben Sie den vertikalen Segment des Verbinders nach links:

![Behobene Verbindungsbehinderung](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Komplexe Fälle** 

Für weiterführende Anpassungen beachten Sie Folgendes:

- Der anpassbare Punkt eines Verbinders wird durch eine Formel bestimmt, die seine Position festlegt. Eine Änderung dieses Punktes kann die Gesamtform des Verbinders verändern.  
- Die Anpassungspunkte eines Verbinders werden in einem streng geordneten Array gespeichert, das von Anfang zu Ende des Verbinders nummeriert ist.  
- Werte der Anpassungspunkte stellen Prozentsätze der Breite/Höhe der Verbinderform dar.  
  - Die Form wird durch die Start‑ und Endpunkte des Verbinders begrenzt und um den Faktor 1000 skaliert.  
  - Der erste, zweite und dritte Anpassungspunkt stehen für: Prozent der Breite, Prozent der Höhe und erneut Prozent der Breite.  
- Beim Berechnen der Koordinaten der Anpassungspunkte muss die Drehung und Spiegelung des Verbinders berücksichtigt werden. **Hinweis:** Für alle unter [Verbindertypen](/slides/de/python-net/connector/#connector-types) aufgeführten Verbinder beträgt der Rotationswinkel 0.

#### **Fall 1**

Betrachten Sie den Fall, dass zwei Textfeld‑Objekte mit einem Verbinder verknüpft sind:

![Verknüpfte Formen](connector-shape-complex.png)

Code‑Beispiel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instantiate the Presentation class to create a PPTX file.
with slides.Presentation() as presentation:

    # Get the first slide.
    slide = presentation.slides[0]

    # Get the first slide.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Add a connector.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Set the connector's direction.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Set the connector's color.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Set the connector's line thickness.
    connector.line_format.width = 3

    # Link the shapes with the connector.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Get the connector's adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Anpassung**

Ändern Sie die Werte der Anpassungspunkte, indem Sie den Breiten‑Prozentsatz um 20 % und den Höhen‑Prozentsatz um 200 % erhöhen:

```python
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Das Ergebnis:

![Verbindungsanpassung 1](connector-adjusted-1.png)

Um ein Modell zu definieren, das die Koordinaten und Form der Verbinder‑Segmente bestimmt, erstellen Sie eine Form, die dem vertikalen Anteil des Verbinders bei `connector.adjustments[0]` entspricht:

```python
    # Draw the vertical component of the connector.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Das Ergebnis:

![Verbindungsanpassung 2](connector-adjusted-2.png)

#### **Fall 2**

Im **Fall 1** haben wir eine einfache Verbinder‑Anpassung anhand grundlegender Prinzipien demonstriert. In typischen Szenarien muss die Drehung des Verbinders sowie dessen Anzeigeeinstellungen (gesteuert durch `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v`) berücksichtigt werden. So funktioniert der Prozess.

Zuerst fügen Sie der Folie ein neues Textfeld‑Objekt (**To 1**) zur Verbindung hinzu und erstellen einen neuen grünen Verbinder, der es mit den vorhandenen Objekten verknüpft.

```python
    # Create a new target object.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Create a new connector.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Connect the objects using the newly created connector.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Get the connector adjustment points.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Change the values of the adjustment points.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Das Ergebnis:

![Verbindungsanpassung 3](connector-adjusted-3.png)

Zweitens erstellen Sie eine Form, die dem **horizontalen** Segment des Verbinders entspricht, das durch den neuen Anpassungspunkt `connector.adjustments[0]` verläuft. Nutzen Sie dabei die Werte von `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v` und wenden Sie die Standard‑Formel zur Koordinatenumwandlung bei Drehung um einen Punkt `x0` an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel 90° und der Verbinder wird vertikal angezeigt, sodass der entsprechende Code lautet:

```python
    # Save the connector coordinates.
    x = connector.x
    y = connector.y
    
    # Correct the connector coordinates if it is flipped.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Use the adjustment point value as the coordinate.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Convert the coordinates because sin(90°) = 1 and cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Determine the width of the horizontal segment using the second adjustment point value.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Das Ergebnis:

![Verbindungsanpassung 4](connector-adjusted-4.png)

Wir haben Berechnungen für einfache Anpassungen sowie komplexere Anpassungspunkte (unter Berücksichtigung von Drehungen) demonstriert. Mit diesem Wissen können Sie ein eigenes Modell entwickeln – oder Code schreiben – um ein `GraphicsPath`‑Objekt zu erhalten oder die Anpassungspunkte eines Verbinders basierend auf konkreten Folienkoordinaten zu setzen.

## **Winkel von Verbindungslinien finden**

Verwenden Sie das folgende Beispiel, um den Winkel von Verbindungslinien auf einer Folie mit Aspose.Slides zu bestimmen. Sie lernen, wie Sie die Endpunkte eines Verbinders auslesen und seine Orientierung berechnen, sodass Sie Pfeile, Beschriftungen und andere Formen exakt ausrichten können.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich die Referenz zur Folie über ihren Index.  
3. Greifen Sie auf die Form des Verbindungslinien‑Verbinders zu.  
4. Verwenden Sie die Breite und Höhe der Linie sowie die Breite und Höhe des Formrahmens, um den Winkel zu berechnen.

Der folgende Python‑Code demonstriert, wie Sie den Winkel für ein Verbindungslinien‑Shape berechnen:

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

**Wie kann ich erkennen, ob ein Verbinder an einer bestimmten Form „geklebt“ werden kann?**  
Prüfen Sie, ob die Form [Verbindungspunkte](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/) bereitstellt. Gibt es keine oder ist die Anzahl 0, ist das Einkleben nicht möglich; verwenden Sie dann freie Endpunkte und positionieren Sie sie manuell. Es ist sinnvoll, die Punktzahl vor dem Anbinden zu prüfen.

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**  
Seine Enden werden gelöst; der Verbinder bleibt als gewöhnliche Linie mit freien Start‑/Endpunkten auf der Folie. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und bei Bedarf [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/) ausführen.

**Werden Verbinder‑Verknüpfungen beibehalten, wenn eine Folie in eine andere Präsentation kopiert wird?**  
In der Regel ja, vorausgesetzt, die Ziel‑Formen werden ebenfalls kopiert. Wird die Folie in eine andere Datei eingefügt, ohne die verbundenen Formen, werden die Enden frei und Sie müssen sie erneut anbringen.