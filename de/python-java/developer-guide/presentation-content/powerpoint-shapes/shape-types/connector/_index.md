---
title: Verwalten von Verbindern in Präsentationen in Python über Java
linktitle: Verbinder
type: docs
weight: 10
url: /de/python-java/connector/
keywords:
- Verbinder
- Verbinder-Typ
- Verbinderpunkt
- Verbinderlinie
- Verbinderwinkel
- Verbindungspunkt
- Anpassungspunkt
- Formen verbinden
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie gerade, gebogene und gekrümmte PowerPoint‑Verbinder mit Aspose.Slides für Python über Java hinzufügen, anhängen, neu routen, anpassen und untersuchen."
---
## **Übersicht**

Ein Verbinder ist eine Linie, die an zwei Formen angeschlossen bleiben kann, wenn eine der Formen bewegt wird. Seine Enden werden an Verbindungspunkten befestigt, die in PowerPoint durch grüne Punkte dargestellt werden. Einige gebogene und gekrümmte Verbinder stellen außerdem Anpassungspunkte bereit, die durch orange Punkte dargestellt werden und die Position einzelner Verbindungssegmente steuern.

Aspose.Slides stellt Verbinder über die [Connector](https://reference.aspose.com/slides/de/python-java/aspose.slides/connector/) Klasse dar. Sie können sie erstellen, ihre Enden an Formen anhängen, Verbindungspunkte auswählen, sie neu routen und die Geometrie von Verbindern, die Anpassungspunkte besitzen, ändern.

## **Verbinderarten**

Die [ShapeType](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/) Klasse enthält gerade, gebogene und gekrümmte Verbinder‑Vorlagen. Die nachstehende Tabelle zeigt die verfügbaren Verbindergeometrien und die Anzahl der für jede Vorlage definierten Anpassungspunkte.

| Verbinder | Bild | Anzahl der Anpassungspunkte |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Die Anzahl und Bedeutung der Anpassungspunkte ist Teil der gewählten Verbinder‑Vorlage. Gehen Sie nicht davon aus, dass zwei verschiedene Verbinderarten dieselbe Sammlungsstruktur aufweisen.

## **Zwei Formen verbinden**

Verwenden Sie [ShapeCollection.addConnector](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addConnector), um einen Verbinder hinzuzufügen, und verwenden Sie [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/de/python-java/aspose.slides/connector/#setStartShapeConnectedTo) und [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/de/python-java/aspose.slides/connector/#setEndShapeConnectedTo), um seine Enden zu befestigen. Nachdem beide Enden angeschlossen sind, wählt [Connector.reroute](https://reference.aspose.com/slides/de/python-java/aspose.slides/connector/#reroute) eine kurze Route zwischen den Formen.

Das folgende Beispiel verbindet eine Ellipse und ein Rechteck mit einem gebogenen Verbinder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Der Aufruf von [reroute](https://reference.aspose.com/slides/de/python-java/aspose.slides/connector/#reroute) kann die Werte von [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) und [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex) ändern. Ordnen Sie nach dem erneuten Routen bestimmte Verbindungspunkte zu, wenn diese Punkte fest bleiben müssen.
{{% /alert %}}

## **Verbindungspunkt wählen**

Jede verbindbare Form gibt ihre Anzahl an Punkten über [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getConnectionSiteCount) zurück. Validieren Sie einen bevorzugten nullbasierten Index, bevor Sie ihn einem Verbinderende zuweisen; die Punktanzahl variiert je nach Formgeometrie.

Dieses Beispiel befestigt den Verbinder an einem bestimmten Punkt der Ellipse, sofern dieser Punkt vorhanden ist:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Anpassen eines Verbinderpunkts**

Verbinder mit Anpassungspunkten geben diese über [GeometryShape.getAdjustments](https://reference.aspose.com/slides/de/python-java/aspose.slides/geometryshape/#getAdjustments) frei. Untersuchen Sie jeden [AdjustValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/) und prüfen Sie dessen [getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getType)-Wert, bevor Sie ihn mit [setRawValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#setRawValue) ändern. Die allgemeinen Regeln zur Identifizierung von Vorlagen‑Form‑Anpassungen sind in [Shape Manipulation](/slides/de/python-java/shape-manipulations/) beschrieben.

Die Anzahl, Reihenfolge, Bedeutung und zulässige Wertebereiche von Verbinder‑Anpassungen hängen von der jeweiligen Verbinder‑Vorlage ab. Der Anpassungstyp ist schreibgeschützt, während der Anpassungswert beschreibbar ist. Die schreibgeschützte Methode [getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getName) liefert zusätzliche Identifikation, wenn ein Verbinder mehr als eine Anpassung desselben semantischen Typs enthält.

### **Um ein Hindernis herumführen**

Im folgenden Layout führt ein [BentConnector5](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#BentConnector5) zwischen zwei Formen durch eine dritte Form:

![connector-obstruction](connector-obstruction.png)

Dieser Code erstellt den blockierten Verbinder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Verschieben der vertikalen Biegung ändert die Route, sodass der Verbinder das Hindernis umgeht:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Anstatt anzunehmen, dass der Sammlungs‑Index `1` immer die vertikale Biegung darstellt, sucht dieses Beispiel nach [ConnectorBendPositionY](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) und ändert ihn nur, wenn der erwartete semantische Typ vorhanden ist:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ein [BentConnector5](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#BentConnector5) hat zwei [ConnectorBendPositionX](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX)-Anpassungen und eine [ConnectorBendPositionY](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY)-Anpassung. Wenn der benötigte Typ mehrmals vorkommt, prüfen Sie [getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getName) und die bekannte Geometrie dieser Vorlage, bevor Sie einen auswählen. Gibt eine Anpassung [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#Custom) zurück, behandeln Sie deren Bedeutung und Wertebereich als vorlagenabhängig und ändern Sie sie nicht, solange diese Vereinbarung nicht bekannt ist.

## **Anpassungswerte mit Verbindergeometrie in Beziehung setzen**

Bei gebogenen Verbindern können Anpassungswerte verwendet werden, um die Positionen einzelner Segmente abzuschätzen. Diese Berechnungen sind spezifisch für die jeweilige Verbinder‑Vorlage:

- [BentConnector4](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#BentConnector4) stellt normalerweise eine [ConnectorBendPositionX](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX)- und eine [ConnectorBendPositionY](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY)-Anpassung bereit.
- Für diese Biegungspositionen erzeugt die Division des von [getRawValue](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getRawValue) zurückgegebenen Werts durch `100000.0` den Bruchteil der Verbinder‑Rahmenbreite bzw. -höhe, wie in den nachstehenden Beispielen verwendet.
- Ein Verbinder‑Rahmen kann gedreht oder gespiegelt werden, sodass Rahmenkoordinaten vor dem Vergleich mit Folienkoordinaten umgerechnet werden müssen.

Die folgenden Beispiele verwenden zunächst [getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getType), um die Anpassungen zu identifizieren. Sie behandeln Sammlungs‑Indizes nicht als portable Bezeichner.

### **Nicht gedrehter Verbinder**

Das Ausgangslayout enthält zwei Textformen, die durch einen [BentConnector4](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapetype/#BentConnector4) verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Dieses Beispiel untersucht den Verbinder und ermittelt seine horizontalen und vertikalen Biegungs‑Anpassungen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Um beide Biegungen zu ändern, suchen Sie jeden erwarteten Typ und ändern Sie die Werte erst, wenn beide gefunden wurden:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Das Ergebnis ist ein Verbinder, dessen horizontale und vertikale Segmente verschoben wurden:

![connector-adjusted-1](connector-adjusted-1.png)

Sobald die semantischen Typen bekannt sind, können deren Werte in Verbinder‑Rahmenkoordinaten umgerechnet werden. Dieses Beispiel zeichnet ein dünnes Rechteck über das vertikale Segment, das von den beiden Biegungs‑Anpassungen gesteuert wird:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die Hilfsform markiert das berechnete Segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Gedrehter oder gespiegelter Verbinder**

Wenn dieselbe Verbindergeometrie vertikal ausgerichtet ist, beeinflussen die Werte von [Shape.getFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getFrame), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeframe/#getFlipH) und [ShapeFrame.getFlipV](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapeframe/#getFlipV) die Umrechnung von Verbinder‑Rahmenkoordinaten zu Folienkoordinaten.

Dieses Beispiel erstellt und passt den vertikal ausgerichteten Verbinder an:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der angepasste Verbinder erscheint vertikal zwischen den Formen:

![connector-adjusted-3](connector-adjusted-3.png)

Für einen beliebigen Rotationswinkel `alpha` wird ein Punkt `(x, y)` des Verbinder‑Rahmens um das Rahmen‑Mittelpunkt `(x0, y0)` gedreht:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Der folgende Code behandelt die in diesem Beispiel genutzte 90‑Grad‑Ausrichtung und zeichnet eine rote Hilfslinie über das entsprechende Verbinder‑Segment:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Die rote Hilfslinie markiert das berechnete Segment nach der Koordinatentransformation:

![connector-adjusted-4](connector-adjusted-4.png)

Diese Formeln beschreiben die in den Beispielen verwendeten Vorlagen, nicht ein universelles Verbinder‑Modell. Validieren Sie die Anpassungstypen, Rahmenorientierung und Wertebereiche, bevor Sie dieselbe Berechnung auf eine andere Vorlage anwenden.

## **Winkel der Verbinder‑Richtung finden**

Die Richtung eines geraden Verbinders kann aus seiner Breite und Höhe berechnet werden, wobei horizontale und vertikale Spiegelungen berücksichtigt werden. Das folgende Beispiel gibt den im Uhrzeigersinn gemessenen Winkel zur positiven Horizontalachse in Folienkoordinaten aus:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **FAQ**

**Wie kann ich feststellen, ob ein Verbinder an einer Form befestigt werden kann?**

Überprüfen Sie den Wert von [getConnectionSiteCount](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getConnectionSiteCount) der Form. Ein positiver Wert bedeutet, dass die Form Verbindungspunkte bereitstellt. Validieren Sie den ausgewählten Punkt‑Index, bevor Sie ihn einem Verbinderende zuweisen.

**Kann ich eine Verbinder‑Anpassung über ihren Sammlungs‑Index identifizieren?**

Ein Index ist nur für eine bekannte Verbinder‑Vorlage und deren Sammlungsstruktur sinnvoll. Prüfen Sie [AdjustValue.getType](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getType), bevor Sie einen Wert ändern, und verwenden Sie [AdjustValue.getName](https://reference.aspose.com/slides/de/python-java/aspose.slides/adjustvalue/#getName) als zusätzliche Information, wenn derselbe semantische Typ mehrfach vorkommt.

**Was geschieht, wenn eine verbundene Form gelöscht wird?**

Das zugehörige Verbinderende wird gelöst. Der Verbinder bleibt auf der Folie und kann gelöscht, als freie Linie positioniert oder an einer anderen Form befestigt werden.

**Bleiben Verbinder‑Verknüpfungen erhalten, wenn eine Folie kopiert wird?**

Verknüpfungen werden im Allgemeinen beibehalten, wenn die verbundenen Formen zusammen mit der Folie kopiert werden. Wird ein Verbinder ohne eine seiner Ziel­formen kopiert, muss das betroffene Ende erneut angeheftet werden.