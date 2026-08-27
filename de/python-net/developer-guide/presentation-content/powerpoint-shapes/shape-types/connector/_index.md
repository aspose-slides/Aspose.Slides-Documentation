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
- Verbindungsstelle
- Anpassungspunkt
- Formen verbinden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie gerade, gebogene und gekrümmte PowerPoint-Verbinder mit Aspose.Slides für Python über .NET hinzufügen, anfügen, neu routen, anpassen und prüfen."
---
## **Übersicht**

Ein Verbinder ist eine Linie, die an zwei Formen befestigt bleiben kann, wenn eine der Formen bewegt wird. Seine Enden verbinden sich mit Verbindungsstellen, die in PowerPoint durch grüne Punkte dargestellt werden. Einige gebogene und gekrümmte Verbinder besitzen außerdem Anpassungspunkte, die durch orange Punkte angezeigt werden und die Position einzelner Verbindersegmente steuern.

Aspose.Slides repräsentiert Verbinder über das [IConnector](https://reference.aspose.com/slides/de/python-net/aspose.slides/iconnector/)‑Interface. Sie können Verbinder erstellen, deren Enden an Formen anfügen, Verbindungsstellen auswählen, sie neu routen und die Geometrie von Verbindern mit Anpassungspunkten ändern.

## **Verbinder‑Typen**

Die [ShapeType](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapetype/)‑Aufzählung enthält vordefinierte gerade, gebogene und gekrümmte Verbinder. Die folgende Tabelle zeigt die verfügbaren Verbindergeometrien und die Anzahl der für jeden Voreinstellungs‑Typ definierten Anpassungspunkte.

| Verbinder | Bild | Anzahl der Anpassungspunkte |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Die Anzahl und Bedeutung der Anpassungspunkte sind Teil der gewählten Verbinder‑Voreinstellung. Gehen Sie nicht davon aus, dass zwei verschiedene Verbinder‑Typen dieselbe Auflistungsstruktur bereitstellen.

## **Zwei Formen verbinden**

Verwenden Sie [IShapeCollection.add_connector](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishapecollection/add_connector/), um einen Verbinder hinzuzufügen, und setzen Sie die Eigenschaften [start_shape_connected_to](https://reference.aspose.com/slides/de/python-net/aspose.slides/iconnector/start_shape_connected_to/) und [end_shape_connected_to](https://reference.aspose.com/slides/de/python-net/aspose.slides/iconnector/end_shape_connected_to/). Nachdem beide Enden angefügt wurden, wählt [IConnector.reroute](https://reference.aspose.com/slides/de/python-net/aspose.slides/iconnector/reroute/) eine kurze Route zwischen den Formen.

Das folgende Beispiel verbindet eine Ellipse und ein Rechteck mit einem gebogenen Verbinder:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}

Der Aufruf von `reroute` kann die Werte von [start_shape_connection_site_index](https://reference.aspose.com/slides/de/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) und [end_shape_connection_site_index](https://reference.aspose.com/slides/de/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) ändern. Weisen Sie nach dem Rerouten bestimmte Verbindungsstellen zu, wenn diese Stellen fest bleiben sollen.

{{% /alert %}}

## **Verbindungsstelle auswählen**

Jede verbindbare Form gibt über [connection_site_count](https://reference.aspose.com/slides/de/python-net/aspose.slides/igeometryshape/connection_site_count/) die Anzahl ihrer Stellen zurück. Überprüfen Sie einen bevorzugten nullbasierten Stellen‑Index, bevor Sie ihn einem Verbinder‑Ende zuweisen; die Stellenanzahl variiert je nach Formgeometrie.

Dieses Beispiel fügt den Verbinder einer bestimmten Stelle an der Ellipse hinzu, wenn diese Stelle existiert:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **Anpassen eines Verbinderpunktes**

Verbinder mit Anpassungspunkten geben diese über [IGeometryShape.adjustments](https://reference.aspose.com/slides/de/python-net/aspose.slides/igeometryshape/adjustments/) frei. Untersuchen Sie jedes [IAdjustValue](https://reference.aspose.com/slides/de/python-net/aspose.slides/iadjustvalue/) und prüfen Sie dessen [type](https://reference.aspose.com/slides/de/python-net/aspose.slides/iadjustvalue/type/), bevor Sie den [raw_value](https://reference.aspose.com/slides/de/python-net/aspose.slides/iadjustvalue/raw_value/) ändern. Für allgemeine Formmanipulationen siehe [Shape Manipulation](/slides/de/python-net/shape-manipulations/).

Die Anzahl, Reihenfolge, Bedeutung und der zulässige Wertebereich von Verbinder‑Anpassungen hängen von der Verbinder‑Voreinstellung ab. Die Eigenschaft `type` ist schreibgeschützt, während der Anpassungswert beschreibbar ist. Die schreibgeschützte [name](https://reference.aspose.com/slides/de/python-net/aspose.slides/iadjustvalue/name/)‑Eigenschaft liefert zusätzliche Identifikation, wenn ein Verbinder mehr als eine Anpassung desselben semantischen Typs enthält.

### **Umgehen eines Hindernisses**

Im folgenden Layout verläuft ein `ShapeType.BENT_CONNECTOR5`‑Verbinder zwischen zwei Formen durch eine dritte Form:

![connector-obstruction](connector-obstruction.png)

Dieser Code erstellt den blockierten Verbinder:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

Das Verschieben der vertikalen Biegung ändert die Route, sodass der Verbinder das Hindernis umgeht:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Anstatt davon auszugehen, dass Index `1` immer die vertikale Biegung darstellt, sucht dieses Beispiel nach `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` und ändert sie nur, wenn der erwartete semantische Typ vorhanden ist:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

Ein `ShapeType.BENT_CONNECTOR5` besitzt zwei `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X`‑Anpassungen und eine `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`‑Anpassung. Wenn der benötigte Typ mehrmals vorkommt, prüfen Sie `name` und die bekannte Geometrie dieser Voreinstellung, bevor Sie einen auswählen. Gibt eine Anpassung [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/de/python-net/aspose.slides/shapeadjustmenttype/) zurück, behandeln Sie deren Bedeutung und Wertebereich als voreinstellungs‑spezifisch und ändern Sie ihn nicht, solange dieser Vertrag nicht bekannt ist.

## **Bezug von Anpassungswerten zur Verbindergeometrie**

Bei gebogenen Verbindern können Anpassungswerte verwendet werden, um die Positionen einzelner Segmente abzuschätzen. Diese Berechnungen sind spezifisch für die jeweilige Verbinder‑Voreinstellung:

- `ShapeType.BENT_CONNECTOR4` stellt normalerweise eine `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X`‑ und eine `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y`‑Anpassung bereit.
- Für diese Biegungspositionen liefert `raw_value / 100000` den Bruchteil der Verbinder‑Rahmenbreite bzw. -höhe, der in den nachfolgenden Beispielen verwendet wird.
- Ein Verbinder‑Rahmen kann rotiert oder gespiegelt werden, sodass Rahmenkoordinaten vor dem Vergleich mit Folienkoordinaten transformiert werden müssen.

Die folgenden Beispiele erkennen zunächst die Anpassungen über `type`. Sie behandeln Auflistungsindizes nicht als portable Kennungen.

### **Nicht gedrehter Verbinder**

Das Anfangslayout enthält zwei Textformen, die durch einen `ShapeType.BENT_CONNECTOR4` verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Dieses Beispiel untersucht den Verbinder und ermittelt seine horizontalen und vertikalen Biegungs‑Anpassungen:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

Um beide Biegungen zu ändern, suchen Sie jede erwartete Art und passen die Werte erst an, nachdem beide gefunden wurden:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Das Ergebnis ist ein Verbinder, dessen horizontale und vertikale Segmente verschoben wurden:

![connector-adjusted-1](connector-adjusted-1.png)

Sobald die semantischen Typen bekannt sind, können ihre Werte in Verbinder‑Rahmenkoordinaten umgerechnet werden. Dieses Beispiel zeichnet ein dünnes Rechteck über das vertikale Segment, das von den beiden Biegungs‑Anpassungen gesteuert wird:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Die Hilfsform markiert das berechnete Segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Gedrehter oder gespiegelter Verbinder**

Wenn dieselbe Verbindergeometrie vertikal ausgerichtet ist, beeinflussen ihr [frame](https://reference.aspose.com/slides/de/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishapeframe/flip_h/) und [flip_v](https://reference.aspose.com/slides/de/python-net/aspose.slides/ishapeframe/flip_v/) die Umrechnung von Verbinder‑Rahmen‑ zu Folienkoordinaten.

Dieses Beispiel erstellt und passt den vertikal ausgerichteten Verbinder an:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

Der angepasste Verbinder erscheint vertikal zwischen den Formen:

![connector-adjusted-3](connector-adjusted-3.png)

Für einen beliebigen Rotationswinkel `alpha` wird ein Punkt `(x, y)` im Verbinder‑Rahmen um das Rahmencentrum `(x0, y0)` rotiert:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Der folgende Code behandelt die in diesem Beispiel genutzte 90‑Grad‑Ausrichtung und zeichnet einen roten Leitfaden über das entsprechende Verbindersegment:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

Der rote Leitfaden markiert das nach der Koordinatentransformation berechnete Segment:

![connector-adjusted-4](connector-adjusted-4.png)

Diese Formeln beschreiben die in den Beispielen verwendeten Voreinstellungen, nicht ein universelles Verbinder‑Modell. Validieren Sie die Anpassungstypen, Rahmenorientierung und Wertebereiche, bevor Sie dieselbe Berechnung auf eine andere Voreinstellung anwenden.

## **Verbinderrichtungswinkel finden**

Der Richtungswinkel eines geraden Verbinders kann aus seiner Breite und Höhe berechnet werden, wobei horizontale und vertikale Spiegelungen berücksichtigt werden. Das folgende Beispiel gibt den im Uhrzeigersinn gemessenen Winkel zur positiven Horizontalachse in Folienkoordinaten aus:

```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **FAQ**

**Wie kann ich feststellen, ob ein Verbinder an einer Form befestigt werden kann?**

Prüfen Sie die [connection_site_count](https://reference.aspose.com/slides/de/python-net/aspose.slides/igeometryshape/connection_site_count/) der Form. Ein positiver Wert bedeutet, dass die Form Verbindungsstellen bereitstellt. Validieren Sie den gewählten Stellen‑Index, bevor Sie ihn einem Verbinder‑Ende zuweisen.

**Kann ich eine Verbinder‑Anpassung anhand ihres Auflistungsindex identifizieren?**

Ein Index ist nur im Kontext einer bekannten Verbinder‑Voreinstellung und Auflistungsstruktur sinnvoll. Prüfen Sie [IAdjustValue.type](https://reference.aspose.com/slides/de/python-net/aspose.slides/iadjustvalue/type/) bevor Sie einen Wert ändern, und verwenden Sie [IAdjustValue.name](https://reference.aspose.com/slides/de/python-net/aspose.slides/iadjustvalue/name/) als zusätzliche Information, wenn derselbe semantische Typ mehrmals vorkommt.

**Was passiert, wenn eine verbundene Form gelöscht wird?**

Das zugehörige Verbinder‑Ende wird gelöst. Der Verbinder bleibt auf der Folie erhalten und kann gelöscht, als freie Linie positioniert oder an einer anderen Form befestigt werden.

**Werden Verbinderbindungen beim Kopieren einer Folie beibehalten?**

Verbindungen bleiben in der Regel erhalten, wenn die verbundenen Formen zusammen mit der Folie kopiert werden. Wird ein Verbinder ohne eine seiner Ziel‑Formen kopiert, muss das betroffene Ende erneut angefügt werden.