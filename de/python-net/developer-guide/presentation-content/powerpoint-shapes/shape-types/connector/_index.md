---
title: "Verwalten von Verbindern in Präsentationen mit Python"
linktitle: "Verbinder"
type: docs
weight: 10
url: /de/python-net/connector/
keywords:
- Verbinder
- Verbinder-Typ
- Verbindungs‑punkt
- Verbindungs‑linie
- Verbindungs‑winkel
- Formen verbinden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Ermöglichen Sie Python‑Anwendungen das Zeichnen, Verbinden und automatisierte Routen von Linien in PowerPoint‑ und OpenDocument‑Folien – erhalten Sie die volle Kontrolle über gerade, Ellenbogen‑ und gekrümmte Verbinder."
---

## **Einführung**

Ein PowerPoint‑Verbinder ist eine spezialisierte Linie, die zwei Formen verbindet und an diesen befestigt bleibt, wenn die Formen auf einer Folie verschoben oder neu positioniert werden. Verbinder schließen sich an **Verbindungspunkte** (grüne Punkte) an Formen an. Verbindungspunkte werden sichtbar, wenn der Zeiger ihnen nähert. **Anpassungspunkte** (gelbe Punkte), die bei bestimmten Verbindern verfügbar sind, ermöglichen das Ändern von Position und Form des Verbinders.

## **Verbinder‑Typen**

In PowerPoint können Sie drei Arten von Verbindern verwenden: gerade, Ellenbogen (gekrümmt) und gebogen.

Aspose.Slides unterstützt die folgenden Verbinder‑Typen:

| Verbinder‑typ                 | Bild                                                       | Anzahl der Anpassungspunkte |
| ----------------------------- | ---------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`              | ![Linien‑Verbinder](shapetype-lineconnector.png)          | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Gerader Verbinder 1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`   | ![Gebogener Verbinder 2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BENT_CONNECTOR3`   | ![Gebogener Verbinder 3](shapetype-bentconnector3.png)   | 1                           |
| `ShapeType.BENT_CONNECTOR4`   | ![Gebogener Verbinder 4](shapetype-bentconnector4.png)   | 2                           |
| `ShapeType.BENT_CONNECTOR5`   | ![Gebogener Verbinder 5](shapetype-bentconnector5.png)   | 3                           |
| `ShapeType.CURVED_CONNECTOR2` | ![Gekrümmter Verbinder 2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CURVED_CONNECTOR3` | ![Gekrümmter Verbinder 3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CURVED_CONNECTOR4` | ![Gekrümmter Verbinder 4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CURVED_CONNECTOR5` | ![Gekrümmter Verbinder 5](shapetype.curvedconnector5.png) | 3                           |

## **Formen mit Verbindern verbinden**

Dieser Abschnitt demonstriert, wie Sie Formen mit Verbindern in Aspose.Slides verbinden. Sie fügen einer Folie einen Verbinder hinzu und verbinden dessen Anfang und Ende mit Ziel­formen. Durch die Verwendung von Verbindungspunkten bleibt der Verbinder „geklebt“ an den Formen, selbst wenn diese verschoben oder skaliert werden.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.  
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekte mittels der `add_auto_shape`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Klasse hinzu.  
4. Fügen Sie einen Verbinder mit der `add_connector`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Klasse hinzu und geben Sie den Verbinder‑Typ an.  
5. Verbinden Sie die Formen mit dem Verbinder.  
6. Rufen Sie die `reroute`‑Methode auf, um den kürzesten Verbindungsweg anzuwenden.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie Sie zwischen zwei Formen (einer Ellipse und einem Rechteck) einen gebogenen Verbinder hinzufügen:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei zu erstellen.
with slides.Presentation() as presentation:

    # Greifen Sie auf die Formen‑Sammlung der ersten Folie zu.
    shapes = presentation.slides[0].shapes

    # Fügen Sie eine Ellipse‑AutoShape hinzu.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Fügen Sie eine Rechteck‑AutoShape hinzu.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Fügen Sie der Folie einen Verbinder hinzu.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Verbinden Sie die Formen mit dem Verbinder.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Rufen Sie reroute auf, um den kürzesten Pfad festzulegen.
    connector.reroute()

    # Speichern Sie die Präsentation.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="HINWEIS" color="warning" %}}
Die Methode `connector.reroute` routet einen Verbinder neu und zwingt ihn, den kürzesten möglichen Pfad zwischen den Formen zu nehmen. Dabei kann die Methode die Werte `start_shape_connection_site_index` und `end_shape_connection_site_index` ändern.
{{% /alert %}}

## **Verbindungspunkte festlegen**

Dieser Abschnitt erklärt, wie Sie einen Verbinder an einem bestimmten Verbindungspunkt einer Form in Aspose.Slides anbringen. Durch das Anvisieren genauer Verbindungspunkte können Sie das Routing und Layout des Verbinders steuern und saubere, vorhersehbare Diagramme in Ihren Präsentationen erzeugen.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf die Folie über ihren Index.  
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekte mittels der `add_auto_shape`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Klasse hinzu.  
4. Fügen Sie einen Verbinder mit der `add_connector`‑Methode der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Klasse hinzu und geben Sie den Verbinder‑Typ an.  
5. Verbinden Sie die Formen mit dem Verbinder.  
6. Legen Sie Ihre bevorzugten Verbindungspunkte an den Formen fest.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie Sie einen bevorzugten Verbindungspunkt festlegen:

```python
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei zu erstellen.
with slides.Presentation() as presentation:

    # Greifen Sie auf die Formen‑Sammlung der ersten Folie zu.
    shapes = presentation.slides[0].shapes

    # Fügen Sie eine Ellipse‑AutoShape hinzu.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Fügen Sie eine Rechteck‑AutoShape hinzu.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Fügen Sie der Formsammlung der Folie einen Verbinder hinzu.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Verbinden Sie die Formen mit dem Verbinder.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Legen Sie den bevorzugten Verbindungs‑site‑Index für die Ellipse fest.
    site_index = 6

    # Überprüfen Sie, ob der bevorzugte Index innerhalb der verfügbaren Site‑Anzahl liegt.
    if  ellipse.connection_site_count > site_index:
        # Weisen Sie der Ellipse‑AutoShape den bevorzugten Verbindungs‑Site zu.
        connector.start_shape_connection_site_index = site_index

    # Speichern Sie die Präsentation.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Verbinder‑Punkte anpassen**

Sie können Verbinder über deren Anpassungspunkte modifizieren. Nur Verbinder, die Anpassungspunkte besitzen, können auf diese Weise bearbeitet werden. Welche Verbinder Anpassungen unterstützen, entnehmen Sie der Tabelle unter [Verbinder‑Typen](/slides/de/python-net/connector/#verbinder-typen).

### **Einfacher Fall**

Betrachten Sie einen Fall, in dem ein Verbinder zwischen zwei Formen (A und B) ein drittes Objekt (C) durchschneidet:

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

Um das dritte Objekt zu umgehen, passen Sie den Verbinder an, indem Sie dessen vertikalen Abschnitt nach links verschieben:

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Komplexe Fälle**

Für anspruchsvollere Anpassungen betrachten Sie Folgendes:

- Der anpassbare Punkt eines Verbinders wird durch eine Formel bestimmt, die seine Position festlegt. Änderungen dieses Punktes können die gesamte Form des Verbinders beeinflussen.  
- Die Anpassungspunkte eines Verbinders werden in einem streng geordneten Array gespeichert, das vom Anfang bis zum Ende des Verbinders nummeriert ist.  
- Anpassungs‑Werte stellen Prozentsätze der Breite/Höhe der Verbinder‑Form dar.  
  - Die Form ist durch die Start‑ und Endpunkte des Verbinders begrenzt und wird mit 1000 skaliert.  
  - Der erste, zweite und dritte Anpassungspunkt stehen für: Prozentsatz der Breite, Prozentsatz der Höhe und erneut Prozentsatz der Breite.  
- Beim Berechnen der Koordinaten der Anpassungspunkte muss die Rotation und Spiegelung des Verbinders berücksichtigt werden. **Hinweis:** Für alle im Abschnitt [Verbinder‑Typen](/slides/de/python-net/connector/#verbinder-typen) aufgeführten Verbinder beträgt der Rotationswinkel 0.

#### **Fall 1**

Betrachten Sie einen Fall, in dem zwei Text‑Frame‑Objekte mit einem Verbinder verknüpft sind:

![Linked shapes](connector-shape-complex.png)

Code‑Beispiel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei zu erstellen.
with slides.Presentation() as presentation:

    # Holen Sie die erste Folie.
    slide = presentation.slides[0]

    # Holen Sie die erste Folie.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Fügen Sie einen Verbinder hinzu.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Legen Sie die Richtung des Verbinders fest.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Legen Sie die Farbe des Verbinders fest.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Legen Sie die Linien­stärke des Verbinders fest.
    connector.line_format.width = 3

    # Verbinden Sie die Formen mit dem Verbinder.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Holen Sie die Anpassungspunkte des Verbinders.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Anpassung**

Ändern Sie die Werte der Anpassungspunkte, indem Sie den Breiten‑Prozentsatz um 20 % und den Höhen‑Prozentsatz um 200 % erhöhen:

```python
    # Ändern Sie die Werte der Anpassungspunkte.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Das Ergebnis:

![Connector adjustment 1](connector-adjusted-1.png)

Um ein Modell zu definieren, das die Koordinaten und Form der Verbinder‑Segmente bestimmt, erstellen Sie eine Form, die dem vertikalen Teil des Verbinders bei `connector.adjustments[0]` entspricht:

```python
    # Zeichnen Sie die vertikale Komponente des Verbinders.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Das Ergebnis:

![Connector adjustment 2](connector-adjusted-2.png)

#### **Fall 2**

In **Fall 1** haben wir eine einfache Verbinder‑Anpassung anhand grundlegender Prinzipien gezeigt. In typischen Szenarien müssen Sie die Rotation des Verbinders und seine Anzeigeeinstellungen (gesteuert durch `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v`) berücksichtigen. So funktioniert der Prozess.

Zuerst fügen Sie ein neues Text‑Frame‑Objekt (**To 1**) zur Folie hinzu (zur Verbindung) und erstellen einen neuen grünen Verbinder, der es mit den vorhandenen Objekten verbindet.

```python
    # Erstellen Sie ein neues Zielobjekt.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Erstellen Sie einen neuen Verbinder.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Verbinden Sie die Objekte mit dem neu erstellten Verbinder.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Holen Sie die Anpassungspunkte des Verbinders.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Ändern Sie die Werte der Anpassungspunkte.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Das Ergebnis:

![Connector adjustment 3](connector-adjusted-3.png)

Zweitens erstellen Sie eine Form, die dem **horizontalen** Segment des Verbinders entspricht, das durch den neuen Anpassungspunkt `connector.adjustments[0]` verläuft. Verwenden Sie die Werte aus `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v` und wenden Sie die Standard‑Koordinaten‑Umrechnungsformel für die Rotation um einen Punkt `x0` an:

X = (x — x0) * cos(α) — (y — y0) * sin(α) + x0;  
Y = (x — x0) * sin(α) + (y — y0) * cos(α) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90° und der Verbinder wird vertikal angezeigt, sodass der entsprechende Code lautet:

```python
    # Speichern Sie die Koordinaten des Verbinders.
    x = connector.x
    y = connector.y
    
    # Korrigieren Sie die Koordinaten des Verbinders, falls er gespiegelt ist.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Verwenden Sie den Wert des Anpassungspunkts als Koordinate.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Konvertieren Sie die Koordinaten, weil sin(90°) = 1 und cos(90°) = 0.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Bestimmen Sie die Breite des horizontalen Segments mithilfe des Wertes des zweiten Anpassungspunkts.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

Das Ergebnis:

![Connector adjustment 4](connector-adjusted-4.png)

Wir haben Berechnungen für einfache Anpassungen und komplexere Anpassungspunkte (unter Berücksichtigung der Rotation) demonstriert. Mit diesem Wissen können Sie Ihr eigenes Modell entwickeln – oder Code schreiben –, um ein `GraphicsPath`‑Objekt zu erhalten oder sogar die Anpassungspunkte eines Verbinders anhand konkreter Folienkoordinaten zu setzen.

## **Connector‑Linien‑Winkel bestimmen**

Verwenden Sie das nachfolgende Beispiel, um den Winkel von Connector‑Linien in einer Folie mit Aspose.Slides zu ermitteln. Sie lernen, wie Sie die Endpunkte eines Verbinders auslesen und seine Orientierung berechnen, sodass Sie Pfeile, Beschriftungen und andere Formen exakt ausrichten können.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf die Folie über deren Index.  
3. Greifen Sie auf die Form des Connector‑Linie zu.  
4. Verwenden Sie die Breite und Höhe der Linie sowie die Breite und Höhe des Form‑Frames, um den Winkel zu berechnen.

Der folgende Python‑Code demonstriert, wie Sie den Winkel einer Connector‑Linie berechnen:

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

**Wie kann ich feststellen, ob ein Verbinder an einer bestimmten Form „geklebt“ werden kann?**

Prüfen Sie, ob die Form [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/) bereitstellt. Wenn keine vorhanden sind oder die Anzahl 0 beträgt, ist das Kleben nicht möglich; in diesem Fall verwenden Sie freie Endpunkte und positionieren diese manuell. Es ist sinnvoll, die Site‑Anzahl vor dem Anbringen zu prüfen.

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**

Seine Enden werden getrennt; der Verbinder bleibt als normale Linie mit freien Start‑/Endpunkten auf der Folie. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und, falls nötig, [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/) ausführen.

**Werden Verbinder‑Verknüpfungen beim Kopieren einer Folie in eine andere Präsentation erhalten?**

Im Allgemeinen ja, sofern die Ziel‑Formen ebenfalls kopiert werden. Wird die Folie in eine Datei eingefügt, die die verbundenen Formen nicht enthält, werden die Enden frei und Sie müssen sie erneut anbringen.