---
title: Verbinder in Präsentationen mit Python verwalten
linktitle: Verbinder
type: docs
weight: 10
url: /de/python-net/connector/
keywords:
- Verbinder
- Verbinder-Typ
- Verbinderpunkt
- Verbinderlinie
- Verbinderwinkel
- Formen verbinden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Ermöglichen Sie Python-Anwendungen, Linien in PowerPoint- und OpenDocument-Folien zu zeichnen, zu verbinden und automatisch zu routen – erhalten Sie vollständige Kontrolle über gerade, Ellenbogen- und gekrümmte Verbinder."
---

## **Einleitung**

Ein PowerPoint‑Verbinder ist eine spezialisierte Linie, die zwei Formen verbindet und angeheftet bleibt, wenn die Formen auf einer Folie verschoben oder neu positioniert werden. Verbinder werden an **Verbindungspunkten** (grüne Punkte) an Formen befestigt. Verbindungspunkte erscheinen, wenn der Zeiger sich ihnen nähert. **Anpassungspunkte** (gelbe Punkte), die bei bestimmten Verbindern verfügbar sind, ermöglichen das Ändern von Position und Form eines Verbinders.

## **Verbindertypen**

In PowerPoint können Sie drei Arten von Verbindern verwenden: gerade, Ellenbogen (gekrümmt) und Kurven.

Aspose.Slides unterstützt die folgenden Verbindertypen:

| Verbindertyp | Bild | Anzahl der Anpassungspunkte |
| ------------ | ---- | --------------------------- |
| `ShapeType.LINE` | ![Linienverbinder](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![Gerader Verbinder 1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![Gebogener Verbinder 2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![Gebogener Verbinder 3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![Gebogener Verbinder 4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![Gebogener Verbinder 5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![Kurvenverbinder 2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![Kurvenverbinder 3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![Kurvenverbinder 4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![Kurvenverbinder 5](shapetype.curvedconnector5.png) | 3 |

## **Formen mit Verbindern verbinden**

Dieser Abschnitt zeigt, wie man Formen mit Verbindern in Aspose.Slides verknüpft. Sie fügen einer Folie einen Verbinder hinzu und befestigen dessen Anfang und Ende an Ziel­formen. Die Verwendung von Verbindungspunkten stellt sicher, dass der Verbinder an den Formen „geklebt“ bleibt, selbst wenn diese verschoben oder in ihrer Größe verändert werden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz auf die Folie anhand ihres Index.  
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekte mithilfe der vom [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Objekt bereitgestellten Methode `add_auto_shape` hinzu.  
4. Fügen Sie einen Verbinder mit der Methode `add_connector` des [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Objekts hinzu und geben Sie den Verbindertyp an.  
5. Verbinden Sie die Formen mit dem Verbinder.  
6. Rufen Sie die Methode `reroute` auf, um den kürzesten Verbindungsweg anzuwenden.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code zeigt, wie ein gebogener Verbinder zwischen zwei Formen (einer Ellipse und einem Rechteck) hinzugefügt wird:
```python
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um eine PPTX-Datei zu erstellen.
with slides.Presentation() as presentation:

    # Zugriff auf die Shapes-Sammlung der ersten Folie.
    shapes = presentation.slides[0].shapes

    # Eine Ellipse-AutoShape hinzufügen.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Ein Rechteck-AutoShape hinzufügen.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Einen Verbinder zur Folie hinzufügen.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # Die Formen mit dem Verbinder verbinden.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # reroute aufrufen, um den kürzesten Pfad zu setzen.
    connector.reroute()

    # Die Präsentation speichern.
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert title="NOTE" color="warning" %}}
Die Methode `connector.reroute` leitet einen Verbinder neu, sodass er den kürzest möglichen Pfad zwischen den Formen nimmt. Dabei kann die Methode die Werte `start_shape_connection_site_index` und `end_shape_connection_site_index` ändern.
{{% /alert %}}

## **Verbindungspunkte angeben**

Dieser Abschnitt erklärt, wie man einen Verbinder an einem bestimmten Verbindungspunkt einer Form in Aspose.Slides befestigt. Durch das gezielte Ansteuern von Verbindungspunkten können Sie die Leitung und Anordnung des Verbinders steuern und saubere, vorhersehbare Diagramme in Ihren Präsentationen erzeugen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz auf die Folie anhand ihres Index.  
3. Fügen Sie der Folie zwei [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)‑Objekte mithilfe der vom [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Objekt bereitgestellten Methode `add_auto_shape` hinzu.  
4. Fügen Sie einen Verbinder mit der Methode `add_connector` des [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/)‑Objekts hinzu und geben Sie den Verbindertyp an.  
5. Verbinden Sie die Formen mit dem Verbinder.  
6. Setzen Sie Ihre bevorzugten Verbindungspunkte an den Formen.  
7. Speichern Sie die Präsentation.

Der folgende Python‑Code demonstriert, wie ein bevorzugter Verbindungspunkt festgelegt wird:
```python
import aspose.slides as slides

# Instanziieren der Presentation-Klasse, um eine PPTX-Datei zu erstellen.
with slides.Presentation() as presentation:

    # Zugriff auf die Shapes-Sammlung der ersten Folie.
    shapes = presentation.slides[0].shapes

    # Eine Ellipse-AutoShape hinzufügen.
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # Eine Rechteck-AutoShape hinzufügen.
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # Einen Verbinder zur Shape-Sammlung der Folie hinzufügen.
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # Die Formen mit dem Verbinder verbinden.
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # Den bevorzugten Verbindungsseitenindex auf der Ellipse festlegen.
    site_index = 6

    # Prüfen, ob der bevorzugte Index innerhalb der verfügbaren Seitenanzahl liegt.
    if  ellipse.connection_site_count > site_index:
        # Den bevorzugten Verbindungsseitenindex auf der Ellipse-AutoShape zuweisen.
        connector.start_shape_connection_site_index = site_index

    # Die Präsentation speichern.
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```


## **Verbindungspunkte anpassen**

Sie können Verbinder über deren Anpassungspunkte modifizieren. Nur Verbinder, die Anpassungspunkte bereitstellen, können auf diese Weise bearbeitet werden. Einzelheiten dazu, welche Verbinder Anpassungen unterstützen, finden Sie in der Tabelle unter [Verbindertypen](/slides/de/python-net/connector/#connector-types).

### **Einfacher Fall**

Betrachten Sie den Fall, dass ein Verbinder zwischen zwei Formen (A und B) eine dritte Form (C) schneidet:

![Verbinderbehinderung](connector-obstruction.png)

Codebeispiel:
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


Um die dritte Form zu umgehen, passen Sie den Verbinder an, indem Sie dessen vertikalen Abschnitt nach links verschieben:

![Behobene Verbinderbehinderung](connector-obstruction-fixed.png)
```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```


### **Komplexe Fälle**

Für fortgeschrittene Anpassungen betrachten Sie Folgendes:

- Der anpassbare Punkt eines Verbinders wird durch eine Formel bestimmt, die seine Position festlegt. Das Ändern dieses Punktes kann die Gesamtform des Verbinders verändern.  
- Die Anpassungspunkte eines Verbinders werden in einem streng geordneten Array gespeichert, das von Anfang bis Ende des Verbinders nummeriert ist.  
- Die Werte der Anpassungspunkte stellen Prozentsätze der Breite/Höhe der Verbinder­form dar.  
  - Die Form ist durch die Anfangs‑ und Endpunkte des Verbinders begrenzt und wird mit 1000 skaliert.  
  - Der erste, zweite und dritte Anpassungspunkt stehen für: Prozentsatz der Breite, Prozentsatz der Höhe und erneut Prozentsatz der Breite.  
- Beim Berechnen der Koordinaten der Anpassungspunkte sind die Rotation und Spiegelung des Verbinders zu berücksichtigen. **Hinweis:** Für alle unter [Connector Types](/slides/de/python-net/connector/#connector-types) aufgeführten Verbinder beträgt der Rotationswinkel 0.

#### **Case 1**

Betrachten Sie den Fall, dass zwei Textfeld‑Objekte mit einem Verbinder verknüpft sind:

![Verknüpfte Formen](connector-shape-complex.png)

Codebeispiel:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanziieren der Presentation-Klasse, um eine PPTX-Datei zu erstellen.
with slides.Presentation() as presentation:

    # Erste Folie abrufen.
    slide = presentation.slides[0]

    # Erste Folie abrufen.
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # Einen Verbinder hinzufügen.
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # Richtung des Verbinders festlegen.
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # Farbe des Verbinders festlegen.
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # Linienstärke des Verbinders festlegen.
    connector.line_format.width = 3

    # Formen mit dem Verbinder verknüpfen.
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # Anpassungspunkte des Verbinders abrufen.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```


**Anpassung**

Ändern Sie die Werte der Anpassungspunkte des Verbinders, indem Sie den Prozentwert der Breite um 20 % und den Prozentwert der Höhe um 200 % erhöhen:

```python
    # Werte der Anpassungspunkte ändern.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```


Das Ergebnis:

![Verbinderanpassung 1](connector-adjusted-1.png)

Um ein Modell zu definieren, das uns ermöglicht, die Koordinaten und die Form der Verbindersegmente zu bestimmen, erstellen Sie eine Form, die dem vertikalen Bauteil des Verbinders bei `connector.adjustments[0]` entspricht:

```python
    # Zeichnen des vertikalen Bestandteils des Verbinders.
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```


Das Ergebnis:

![Verbinderanpassung 2](connector-adjusted-2.png)

#### **Case 2**

In **Case 1** haben wir eine einfache Verbinderanpassung anhand grundlegender Prinzipien demonstriert. In typischen Szenarien müssen Sie die Rotation des Verbinders und seine Anzeigeeinstellungen (gesteuert durch `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v`) berücksichtigen. So funktioniert der Prozess.

Zuerst fügen Sie der Folie ein neues Textfeld‑Objekt (**To 1**) für die Verbindung hinzu und erstellen einen neuen grünen Verbinder, der es mit den bestehenden Objekten verbindet.
```python
    # Erstelle ein neues Zielobjekt.
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # Erstelle einen neuen Verbinder.
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # Verbinde die Objekte mit dem neu erstellten Verbinder.
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # Abrufen der Anpassungspunkte des Verbinders.
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # Werte der Anpassungspunkte ändern.
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```


Das Ergebnis:

![Verbinderanpassung 3](connector-adjusted-3.png)

Als Nächstes erstellen Sie eine Form, die dem **horizontalen** Abschnitt des Verbinders entspricht, der durch den neuen Anpassungspunkt `connector.adjustments[0]` verläuft. Verwenden Sie die Werte aus `connector.rotation`, `connector.frame.flip_h` und `connector.frame.flip_v` und wenden Sie die Standard‑Formel zur Koordinatentransformation bei Rotation um einen gegebenen Punkt `x0` an:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

In unserem Fall beträgt der Rotationswinkel des Objekts 90 Grad und der Verbinder wird vertikal dargestellt, sodass der entsprechende Code lautet:
```python
    # Speichere die Koordinaten des Verbinders.
    x = connector.x
    y = connector.y
    
    # Korrigiere die Koordinaten des Verbinders, falls er gespiegelt ist.
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # Verwende den Wert des Anpassungspunkts als Koordinate.
    x += connector.width * adjValue_0.raw_value / 100000
    
    # Konvertiere die Koordinaten, weil sin(90°) = 1 und cos(90°) = 0 ist.
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # Bestimme die Breite des horizontalen Segments mithilfe des Wertes des zweiten Anpassungspunkts.
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```


Das Ergebnis:

![Verbinderanpassung 4](connector-adjusted-4.png)

Wir haben Berechnungen sowohl für einfache als auch für komplexere Anpassungspunkte (bei denen Rotation berücksichtigt wird) demonstriert. Mit diesem Wissen können Sie Ihr eigenes Modell entwickeln – oder Code schreiben – um ein `GraphicsPath`‑Objekt zu erhalten oder sogar die Werte der Anpassungspunkte eines Verbinders basierend auf konkreten Folienkoordinaten zu setzen.

## **Verbindungs­liniewinkel ermitteln**

Verwenden Sie das untenstehende Beispiel, um den Winkel von Verbindungs­linien auf einer Folie mit Aspose.Slides zu bestimmen. Sie lernen, wie Sie die Endpunkte eines Verbinders auslesen und seine Ausrichtung berechnen, um Pfeile, Beschriftungen und andere Formen exakt auszurichten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz auf die Folie anhand des Index.  
3. Greifen Sie auf die Form des Verbindungs­linien‑Objekts zu.  
4. Verwenden Sie die Breite und Höhe der Linie sowie die Breite und Höhe des Formrahmens, um den Winkel zu berechnen.

Der folgende Python‑Code demonstriert, wie der Winkel für ein Verbinder‑Linien‑Objekt berechnet wird:
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

**Wie erkenne ich, ob ein Verbinder an einer bestimmten Form "geklebt" werden kann?**

Prüfen Sie, ob die Form [connection sites](https://reference.aspose.com/slides/python-net/aspose.slides/shape/connection_site_count/) bereitstellt. Gibt es keine oder ist die Anzahl 0, ist ein Kleben nicht möglich; in diesem Fall verwenden Sie freie Endpunkte und positionieren sie manuell. Es ist ratsam, die Anzahl der Sites vor dem Anfügen zu prüfen.

**Was passiert mit einem Verbinder, wenn ich eine der verbundenen Formen lösche?**

Die Enden werden gelöst; der Verbinder bleibt als gewöhnliche Linie mit freien Anfangs‑/Endpunkten auf der Folie erhalten. Sie können ihn entweder löschen oder die Verbindungen neu zuweisen und, falls nötig, [reroute](https://reference.aspose.com/slides/python-net/aspose.slides/connector/reroute/) verwenden.

**Werden Verbinder‑Beziehungen beim Kopieren einer Folie in eine andere Präsentation erhalten?**

Im Allgemeinen ja, vorausgesetzt, die Ziel­formen werden ebenfalls kopiert. Wird die Folie in eine andere Datei eingefügt, ohne die verbundenen Formen, werden die Enden frei und Sie müssen sie erneut anfügen.