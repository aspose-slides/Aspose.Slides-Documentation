---
title: Verwalten von Verbindern in Präsentationen mit Python
linktitle: Verbindung
type: docs
weight: 10
url: /de/python-net/connector/
keywords:
- Verbindung
- Verbindungs­typ
- Verbindungs­punkt
- Verbindungs­linie
- Verbindungs­winkel
- Formen verbinden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Ermöglicht Python‑Apps das Zeichnen, Verbinden und automatisierte Routen von Linien in PowerPoint‑ & OpenDocument‑Folien – volle Kontrolle über gerade, Ellenbogen‑ und gekrümmte Verbinder."
---

## **Einleitung**

Ein PowerPoint‑Verbinder ist eine spezialisierte Linie, die zwei Formen verbindet und beim Verschieben oder Neu‑Positionieren der Formen auf einer Folie befestigt bleibt. Verbinder werden an **Verbindungspunkten** (grüne Punkte) an Formen angebracht. Verbindungspunkte erscheinen, wenn der Zeiger sich ihnen nähert. **Anpassungs­griffe** (gelbe Punkte), die bei bestimmten Verbindern verfügbar sind, ermöglichen das Ändern von Position und Form eines Verbinders.

## **Verbindungs­typen**

In PowerPoint können Sie drei Arten von Verbindern verwenden: gerade, Ellenbogen (gekrümmt) und gekrümmt.

Aspose.Slides unterstützt die folgenden Verbindertypen:

| Verbindungs­typ                | Bild                                                       | Anzahl der Anpassungspunkte |
| ------------------------------ | ---------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`               | ![Linienverbinder](shapetype-lineconnector.png)           | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1`| ![Gerader Verbinder 1](shapetype-straightconnector1.png)   | 0                           |
| `ShapeType.BENT_CONNECTOR2`    | ![Gebogener Verbinder 2](shapetype-bent-connector2.png)   | 0                           |
| `ShapeType.BENT_CONNECTOR3`    | ![Gebogener Verbinder 3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BENT_CONNECTOR4`    | ![Gebogener Verbinder 4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BENT_CONNECTOR5`    | ![Gebogener Verbinder 5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CURVED_CONNECTOR2`  | ![Gekrümmter Verbinder 2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CURVED_CONNECTOR3`  | ![Gekrümmter Verbinder 3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CURVED_CONNECTOR4`  | ![Gekrümmter Verbinder 4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CURVED_CONNECTOR5`  | ![Gekrümmter Verbinder 5](shapetype.curvedconnector5.png) | 3                           |

## **Formen mit Verbindern verbinden**

In diesem Abschnitt wird gezeigt, wie Formen mit Verbindern in Aspose.Slides verknüpft werden. Sie fügen einer Folie einen Verbinder hinzu und verbinden dessen Anfang und Ende mit Ziel­formen. Die Nutzung von Verbindungspunkten stellt sicher, dass der Verbinder an den Formen „geklebt“ bleibt, selbst wenn diese verschoben oder skaliert werden.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
3. Fügen Sie mit der Methode `add_auto_shape` der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Objekts zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekte zur Folie hinzu.  
4. Fügen Sie mit der Methode `add_connector` der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Objekts einen Verbinder hinzu und geben Sie den Verbinder­typ an.  
5. Verbinden Sie die Formen mit dem Verbinder.  
6. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungspfad anzuwenden.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie zwischen zwei Formen (einem Ellipsen‑ und einem Rechteck‑AutoShape) ein gebogener Verbinder eingefügt wird:

```python
import aspose.slides as slides

# Instanz der Presentation‑Klasse erstellen, um eine PPTX‑Datei zu erzeugen.
with slides.Presentation() as presentation:

    # Zugriff auf die Shapes‑Collection der ersten Folie.
    shapes = presentation.slides[0].shapes

    # Ellipsen‑AutoShape hinzufügen.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Rechteck‑AutoShape hinzufügen.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Einen Verbinder zur Folie hinzufügen.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Die Formen mit dem Verbinder verbinden.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Reroute aufrufen, um den kürzesten Pfad zu setzen.
    connector.reroute()

    # Präsentation speichern.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="HINWEIS" color="warning" %}}

Die Methode `connector.reroute` ermittelt einen neuen Pfad für einen Verbinder und zwingt ihn, den kürzesten möglichen Weg zwischen den Formen zu nehmen. Dabei können die Werte von `start_shape_connection_site_index` und `end_shape_connection_site_index` geändert werden.

{{% /alert %}}

## **Verbindungspunkte angeben**

Dieser Abschnitt erklärt, wie ein Verbinder an einem bestimmten Verbindungspunkt einer Form in Aspose.Slides angebracht wird. Durch das gezielte Ansteuern von Verbindungspunkten können Sie das Routing und Layout des Verbinders steuern und saubere, vorhersehbare Diagramme in Ihren Präsentationen erzeugen.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
3. Fügen Sie mit der Methode `add_auto_shape` der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Objekts zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-Objekte zur Folie hinzu.  
4. Fügen Sie mit der Methode `add_connector` der [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)-Objekts einen Verbinder hinzu und geben Sie den Verbinder­typ an.  
5. Verbinden Sie die Formen mit dem Verbinder.  
6. Setzen Sie die gewünschten Verbindungspunkte an den Formen.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie ein bevorzugter Verbindungspunkt festgelegt wird:

```python
import aspose.slides as slides

# Instanz der Presentation‑Klasse erstellen, um eine PPTX‑Datei zu erzeugen.
with slides.Presentation() as presentation:

    # Zugriff auf die Shapes‑Collection der ersten Folie.
    shapes = presentation.slides[0].shapes

    # Ellipsen‑AutoShape hinzufügen.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Rechteck‑AutoShape hinzufügen.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Einen Verbinder zur Shape‑Collection der Folie hinzufügen.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Die Formen mit dem Verbinder verbinden.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Den bevorzugten Verbindungspunkt‑Index an der Ellipse festlegen.
    site_index = 6

    # Prüfen, ob der bevorzugte Index innerhalb der verfügbaren Anzahl liegt.
    if ellipse.connection_site_count > site_index:
        # Den bevorzugten Verbindungspunkt an der Ellipse‑AutoShape zuweisen.
        connector.start_shape_connection_site_index = site_index

    # Präsentation speichern.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **Verbindungs­punkte anpassen**

Sie können Verbinder über deren Anpassungspunkte verändern. Nur Verbinder, die Anpassungspunkte bereitstellen, können auf diese Weise bearbeitet werden. Welche Verbinder Anpassungen unterstützen, entnehmen Sie bitte der Tabelle unter [Verbindungs­typen](/slides/de/python-net/connector/#connector-types).

### **Einfacher Fall**

Betrachten Sie einen Fall, bei dem ein Verbinder zwischen zwei Formen (A und B) eine dritte Form (C) schneidet:

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

Um die dritte Form zu umgehen, verschieben Sie das vertikale Segment des Verbinders nach links:

![Fixed connector obstruction](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **Komplexe Fälle**

Für anspruchsvollere Anpassungen beachten Sie Folgendes:

- Der einstellbare Punkt eines Verbinders wird durch eine Formel bestimmt, die dessen Position berechnet. Durch Ändern dieses Punktes verändert sich die gesamte Form des Verbinders.  
- Die Anpassungspunkte eines Verbinders werden in einem streng geordneten Array gespeichert, das von Anfang zu Ende des Verbinders nummeriert ist.  
- Die Werte der Anpassungspunkte stellen Prozentsätze der Breite/Höhe der Verbinderform dar.  
  - Die Form ist durch die Start‑ und Endpunkte des Verbinders begrenzt und wird mit dem Faktor 1000 skaliert.  
  - Der erste, zweite und dritte Anpassungspunkt stehen für: Prozentsatz der Breite, Prozentsatz der Höhe und erneut Prozentsatz der Breite.  
- Bei der Berechnung der Koordinaten der Anpassungspunkte muss die Rotation und Spiegelung des Verbinders berücksichtigt werden. **Hinweis:** Für alle unter [Verbindungs­typen](/slides/de/python-net/connector/#connector-types) aufgeführten Verbinder beträgt der Rotationswinkel 0.

#### **Fall 1**

Zwei Text‑Frame‑Objekte werden mit einem Verbinder verknüpft:

![Linked shapes](connector-shape-complex.png)

Code‑Beispiel:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanz der Presentation‑Klasse erstellen, um eine PPTX‑Datei zu erzeugen.
with slides.Presentation() as presentation:

    # Erste Folie holen.
    slide = presentation.slides[0]

    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Verbinder hinzufügen.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Richtung des Verbinders setzen.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Farbe des Verbinders setzen.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Strichstärke des Verbinders setzen.
    connector.line_format.width = 3

    # Formen mit dem Verbinder verknüpfen.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Anpassungspunkte des Verbinders holen.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**Anpassung**

Erhöhen Sie die Werte der Anpassungspunkte, indem Sie den Breiten‑Prozentsatz um 20 % und den Höhen‑Prozentsatz um 200 % steigern:

```python
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Ergebnis:

![Connector adjustment 1](connector-adjusted-1.png)

Um ein Modell zu definieren, das die Koordinaten und Form der Verbindersegmente liefert, erstellen Sie eine Form, die dem vertikalen Anteil des Verbinders bei `connector.adjustments[0]` entspricht:

```python
    # Vertikalen Anteil des Verbinders zeichnen.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

Ergebnis:

![Connector adjustment 2](connector-adjusted-2.png)

#### **Fall 2**

Im **Fall 1** wurde eine einfache Anpassung anhand grundlegender Prinzipien demonstriert. In typischen Szenarien müssen Sie jedoch die Rotation des Verbinders sowie dessen Anzeigeeinstellungen (`connector.rotation`, `connector.frame.flip_h`, `connector.frame.flip_v`) berücksichtigen. So funktioniert der Vorgang.

Zuerst fügen Sie ein neues Text‑Frame‑Objekt (**To 1**) zur Folie hinzu und erstellen einen neuen grünen Verbinder, der es mit den bestehenden Objekten verbindet.

```python
    # Neues Ziel‑Objekt erstellen.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Neuen Verbinder erstellen.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Objekte mit dem neu erstellten Verbinder verbinden.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Anpassungspunkte des Verbinders holen.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Werte der Anpassungspunkte ändern.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

Ergebnis:

![Connector adjustment 3](connector-adjusted-3.png)

Als nächstes erstellen Sie eine Form, die dem **horizontalen** Segment des Verbinders entspricht, das durch das neue Anpassungspunkt‑Element `connector.adjustments[0]` verläuft. Verwenden Sie die Werte aus `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v` und wenden Sie die übliche Koordinaten‑Umrechnungsformel für die Rotation um einen Punkt `x0` an:

X = (x — x0) * cos(α) — (y — y0) * sin(α) + x0;  
Y = (x — x0) * sin(α) + (y — y0) * cos(α) + y0;

In unserem Beispiel beträgt der Rotationswinkel des Objekts 90° und der Verbinder wird vertikal angezeigt, sodass der entsprechende Code lautet:

```python
    # Verbinder‑Koordinaten speichern.
    x = connector.x
    y = connector.y
    
    # Koordinaten korrigieren, falls gespiegelt.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Anpassungspunkt‑Wert als Koordinate verwenden.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Koordinaten umrechnen, weil sin(90°)=1 und cos(90°)=0.
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

Wir haben sowohl einfache als auch komplexe Anpassungen (unter Berücksichtigung von Rotation) demonstriert. Mit diesem Wissen können Sie ein eigenes Modell entwickeln – oder Code schreiben – um ein `GraphicsPath`‑Objekt zu erhalten oder die Anpassungspunkte eines Verbinders anhand konkreter Folienkoordinaten zu setzen.

## **Winkel von Verbindungs­linien finden**

Verwenden Sie das nachstehende Beispiel, um den Winkel von Verbindungs‑Linien auf einer Folie mit Aspose.Slides zu bestimmen. Sie lernen, wie Sie die Endpunkte eines Verbinders auslesen und dessen Ausrichtung berechnen, um Pfeile, Beschriftungen und weitere Formen exakt auszurichten.

1. Erzeugen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie sich über den Index eine Referenz auf die Folie.  
3. Greifen Sie auf das Verbinder‑Linien‑Shape zu.  
4. Verwenden Sie die Breite und Höhe der Linie sowie die Breite und Höhe des Shape‑Frames, um den Winkel zu berechnen.

Der folgende Python‑Code zeigt, wie der Winkel eines Verbinder‑Linien‑Shapes ermittelt wird:

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

Prüfen Sie, ob die Form **connection sites** bereitstellt. Wenn keine vorhanden sind bzw. die Anzahl 0 beträgt, ist das Kleben nicht verfügbar; in diesem Fall verwenden Sie freie Endpunkte und positionieren sie manuell. Es empfiehlt sich, die Anzahl der Sites vor dem Anhängen zu prüfen.

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**

Die Enden werden getrennt; der Verbinder bleibt als gewöhnliche Linie mit freien Start‑/Endpunkten auf der Folie liegen. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und bei Bedarf **reroute** aufrufen.

**Werden Verbinder‑Bindungen beim Kopieren einer Folie in eine andere Präsentation erhalten?**

In der Regel ja, sofern die Ziel­formen ebenfalls kopiert werden. Wird die Folie in eine andere Datei eingefügt, ohne dass die verbundenen Formen mitkommen, werden die Enden frei und Sie müssen sie erneut anbringen.