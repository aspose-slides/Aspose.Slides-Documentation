---
title: Connector
type: docs
weight: 10
url: /de/python-net/connector/
keywords: "Verbinde Formen, Verbinder, PowerPoint Formen, PowerPoint Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Verbinde PowerPoint Formen in Python"
---

Ein PowerPoint-Verbinder ist eine spezielle Linie, die zwei Formen miteinander verbindet oder verknüpft und an den Formen haftet, selbst wenn sie auf einer bestimmten Folie bewegt oder neu positioniert werden.

Verbinder sind typischerweise mit *Verbindungspunkten* (grüne Punkte) verbunden, die standardmäßig auf allen Formen vorhanden sind. Verbindungspunkte erscheinen, wenn ein Cursor sich ihnen nähert.

*Anpassungspunkte* (orange Punkte), die nur bei bestimmten Verbindern vorhanden sind, dienen dazu, die Positionen und Formen der Verbinder zu ändern.

## **Arten von Verbindern**

In PowerPoint können Sie gerade, angewinkelte (Ellbogen) und gebogene Verbinder verwenden.

Aspose.Slides bietet diese Verbinder an:

| Verbinder                      | Bild                                                        | Anzahl der Anpassungspunkte |
| ------------------------------ | ----------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **Formen mit Verbindern verbinden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) zur Folie hinzu, indem Sie die `add_auto_shape` Methode verwenden, die vom `Shapes` Objekt bereitgestellt wird.
1. Fügen Sie einen Verbinder hinzu, indem Sie die `add_auto_shape` Methode verwenden, indem Sie den Verbindungstyp definieren.
1. Verbinden Sie die Formen mithilfe des Verbinders.
1. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungsweg anzuwenden.
1. Speichern Sie die Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie einen Verbinder (einen gebogenen Verbinder) zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzufügen:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation() as input:
    # Greift auf die Formensammlung einer bestimmten Folie zu
    shapes = input.slides[0].shapes

    # Fügt eine Ellipsen-Autoshape hinzu
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Fügt eine Rechteck-Autoshape hinzu
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 300, 100, 100)

    # Fügt eine Verbinderform zur Formensammlung der Folie hinzu
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Verbindet die Formen mithilfe des Verbinders
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Ruft reroute auf, das den automatischen kürzesten Weg zwischen den Formen festlegt
    connector.reroute()

    # Speichert die Präsentation
    input.save("Connecting shapes using connectors_out.pptx", slides.export.SaveFormat.PPTX)

```

{{%  alert title="HINWEIS"  color="warning"   %}} 

Die Methode `connector.reroute` leitet einen Verbinder um und zwingt ihn, den kürzesten möglichen Weg zwischen den Formen zu nehmen. Um ihr Ziel zu erreichen, kann die Methode die Punkte `start_shape_connection_site_index` und `end_shape_connection_site_index` ändern. 

{{% /alert %}} 

## **Verbindungspunkt festlegen**

Wenn Sie möchten, dass ein Verbinder zwei Formen unter Verwendung spezifischer Punkte an den Formen verknüpft, müssen Sie Ihre bevorzugten Verbindungspunkte auf folgende Weise angeben:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) zur Folie hinzu, indem Sie die `add_auto_shape` Methode verwenden, die vom `Shapes` Objekt bereitgestellt wird.
1. Fügen Sie einen Verbinder hinzu, indem Sie die `add_connector` Methode verwenden, die vom `Shapes` Objekt bereitgestellt wird, indem Sie den Verbindungstyp definieren.
1. Verbinden Sie die Formen mithilfe des Verbinders.
1. Setzen Sie Ihre bevorzugten Verbindungspunkte an den Formen.
1. Speichern Sie die Präsentation.

Dieser Python-Code demonstriert einen Vorgang, bei dem ein bevorzugter Verbindungspunkt festgelegt wird:

```python
import aspose.slides as slides

# Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation() as presentation:
    # Greift auf die Formensammlung einer bestimmten Folie zu
    shapes = presentation.slides[0].shapes

    # Fügt eine Verbinderform zur Formensammlung der Folie hinzu
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Fügt eine Ellipsen-Autoshape hinzu
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 0, 100, 100, 100)

    # Fügt eine Rechteck-Autoshape hinzu
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 100, 100)

    # Verbindet die Formen mithilfe des Verbinders
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Setzt den bevorzugten Verbindungspunktindex an der Ellipsenform
    wantedIndex = 6

    # Überprüft, ob der bevorzugte Index kleiner als die maximale Anzahl der Standortindex ist
    if ellipse.connection_site_count > wantedIndex:
        # Setzt den bevorzugten Verbindungspunkt an der Ellipsen-Autoshape
        connector.start_shape_connection_site_index = wantedIndex

    # Speichert die Präsentation
    presentation.save("Connecting_Shape_on_desired_connection_site_out.pptx", slides.export.SaveFormat.PPTX)

```

## **Anpassung des Verbindungspunktes**

Sie können einen bestehenden Verbinder über seine Anpassungspunkte anpassen. Nur Verbinder mit Anpassungspunkten können auf diese Weise geändert werden. Siehe die Tabelle unter **[Arten von Verbindern](/slides/de/python-net/connector/#types-of-connectors)** 

#### **Einfacher Fall**

Betrachten Sie einen Fall, bei dem ein Verbinder zwischen zwei Formen (A und B) durch eine dritte Form (C) verläuft:

![connector-obstruction](connector-obstruction.png)

Code:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    sld = pres.slides[0]
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shapeFrom
    connector.end_shape_connected_to = shapeTo
    connector.start_shape_connection_site_index = 2
```

Um die dritte Form zu vermeiden oder zu umgehen, können wir den Verbinder anpassen, indem wir seine senkrechte Linie nach links verschieben:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```python
    adj2 = connector.adjustments[1]
    adj2.raw_value += 10000
```

### **Komplexe Fälle** 

Um kompliziertere Anpassungen vorzunehmen, müssen Sie diese Dinge berücksichtigen:

* Ein anpassbarer Punkt eines Verbinders ist stark mit einer Formel verknüpft, die seine Position berechnet und bestimmt. Eine Änderung des Standorts des Punktes kann die Form des Verbinders verändern.
* Die Anpassungspunkte eines Verbinders sind in einer strengen Reihenfolge in einem Array definiert. Die Anpassungspunkte sind von einem Startpunkt des Verbinders zu seinem Endpunkt nummeriert.
* Werte der Anpassungspunkte spiegeln den Prozentsatz der Breite/Höhe der Form des Verbinders wider. 
  * Die Form wird durch die Start- und Endpunkte des Verbinders multipliziert mit 1000 begrenzt. 
  * Der erste Punkt, der zweite Punkt und der dritte Punkt definieren den Prozentsatz von der Breite, den Prozentsatz von der Höhe und den Prozentsatz von der Breite (wieder) jeweils.
* Bei Berechnungen, die die Koordinaten der Anpassungspunkte eines Verbinders bestimmen, müssen Sie die Drehung des Verbinders und seine Spiegelung berücksichtigen. **Beachten Sie**, dass der Drehwinkel für alle Verbinder, die unter **[Arten von Verbindern](/slides/de/python-net/connector/#types-of-connectors)** angezeigt werden, 0 ist.

#### **Fall 1**

Betrachten Sie einen Fall, in dem zwei Textrahmenobjekte durch einen Verbinder miteinander verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Code:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
with slides.Presentation() as pres:
    # Erhält die erste Folie in der Präsentation
    sld = pres.slides[0]
    # Fügt Formen hinzu, die durch einen Verbinder verbunden werden
    shapeFrom = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shapeFrom.text_frame.text = "Von"
    shapeTo = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shapeTo.text_frame.text = "Zu"
    # Fügt einen Verbinder hinzu
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Gibt die Richtung des Verbinders an
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Gibt die Farbe des Verbinders an
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Gibt die Dicke der Linie des Verbinders an
    connector.line_format.width = 3

    # Verbindet die Formen miteinander über den Verbinder
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shapeTo
    connector.end_shape_connection_site_index = 2

    # Erhält die Anpassungspunkte für den Verbinder
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
```

**Anpassung**

Wir können die Werte der Anpassungspunkte des Verbinders ändern, indem wir die entsprechenden Breiten- und Höhenprozentsätze um 20 % bzw. 200 % erhöhen:

```python
    # Ändert die Werte der Anpassungspunkte
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

Das Ergebnis:

![connector-adjusted-1](connector-adjusted-1.png)

Um ein Modell zu definieren, das es uns ermöglicht, die Koordinaten und die Form einzelner Teile des Verbinders zu bestimmen, erstellen wir eine Form, die dem horizontalen Bestandteil des Verbinders an dem Punkt connector.adjustments[0] entspricht:

```python
    # Zeichnet den vertikalen Bestandteil des Verbinders

    x = connector.x + connector.width * adjValue_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjValue_1.raw_value / 100000
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Das Ergebnis:

![connector-adjusted-2](connector-adjusted-2.png)

#### **Fall 2**

Im **Fall 1** haben wir einen einfachen Anpassungsvorgang des Verbinders unter Verwendung grundlegender Prinzipien demonstriert. In normalen Situationen müssen Sie die Drehung des Verbinders und seine Anzeige (die durch `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v` festgelegt werden) berücksichtigen. Wir werden nun den Prozess demonstrieren.

Zuerst fügen wir ein neues Textrahmenobjekt (**Zu 1**) zur Folie hinzu (zu Verbindungszwecken) und erstellen einen neuen (grünen) Verbinder, der es mit den bereits erstellten Objekten verbindet.

```python
    # Erstellt ein neues Bindungsobjekt
    shapeTo_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shapeTo_1.text_frame.text = "Zu 1"
    # Erstellt einen neuen Verbinder
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    # Verbindet die Objekte über den neu erstellten Verbinder
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shapeTo_1
    connector.end_shape_connection_site_index = 3
    # Erhält die Anpassungspunkte des Verbinders
    adjValue_0 = connector.adjustments[0]
    adjValue_1 = connector.adjustments[1]
    # Ändert die Werte der Anpassungspunkte 
    adjValue_0.raw_value += 20000
    adjValue_1.raw_value += 200000
```

Das Ergebnis:

![connector-adjusted-3](connector-adjusted-3.png)

Zweitens erstellen wir eine Form, die dem horizontalen Bestandteil des Verbinders entspricht, der durch den neuen Anpassungspunkt des Verbinders `connector.adjustments[0]` verläuft. Wir verwenden die Werte aus den Verbinderdaten für `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v` und wenden die gängige Koordinatentransformationsformel für die Drehung um einen gegebenen Punkt x0 an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Drehwinkel des Objekts 90 Grad und der Verbinder wird vertikal angezeigt, sodass dies der entsprechende Code ist:

```python
    # Speichert die Koordinaten des Verbinders
    x = connector.x
    y = connector.y
    # Korrigiert die Koordinaten des Verbinders, falls notwendig
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Nimmt den Wert des Anpassungspunktes als Koordinate
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Konvertiert die Koordinaten, da Sin(90) = 1 und Cos(90) = 0
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Bestimmt die Breite des horizontalen Bestandteils mit dem Wert des zweiten Anpassungspunktes
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Das Ergebnis:

![connector-adjusted-4](connector-adjusted-4.png)

Wir haben Berechnungen, die einfache Anpassungen und komplizierte Anpassungspunkte (Anpassungspunkte mit Drehwinkeln) betreffen, demonstriert. Mit dem erlernten Wissen können Sie Ihr eigenes Modell entwickeln (oder einen Code schreiben), um ein `GraphicsPath`-Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Verbinders basierend auf bestimmten Folienkoordinaten festzulegen.

## **Winkel der Verbindungsleitungen finden**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Greifen Sie auf die Form der Verbindungsleitung zu.
1. Verwenden Sie die Linienbreite, Höhe, Höhe des Formrahmens und Breite des Formrahmens, um den Winkel zu berechnen.

Dieser Python-Code demonstriert einen Vorgang, bei dem wir den Winkel für eine Verbindungsleitung berechnet haben:

```python
import aspose.slides as slides
import math

def get_direction(w, h, flipH, flipV):
    endLineX = w * (-1 if flipH else 1)
    endLineY = h * (-1 if flipV else 1)
    endYAxisX = 0
    endYAxisY = h
    angle = math.atan2(endYAxisY, endYAxisX) - math.atan2(endLineY, endLineX)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation(path + "ConnectorLineAngle.pptx") as pres:
    slide = pres.slides[0]
    for i in range(len(slide.shapes)):
        dir = 0.0
        shape = slide.shapes[i]
        if (type(shape) is slides.AutoShape):
            if shape.shape_type == slides.ShapeType.LINE:
                dir = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            dir = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)

        print(dir)

```