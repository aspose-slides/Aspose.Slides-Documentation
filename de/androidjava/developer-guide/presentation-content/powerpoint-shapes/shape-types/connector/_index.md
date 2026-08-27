---
title: Manage Connectors in Presentations on Android
linktitle: Verbinder
type: docs
weight: 10
url: /de/androidjava/connector/
keywords:
- Verbinder
- Verbindertyp
- Verbindungspunkt
- Verbindungslinie
- Verbindungswinkel
- Anschlusspunkt
- Anpassungspunkt
- Formen verbinden
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie gerade, gebogene und gekrümmte PowerPoint‑Verbinder mit Aspose.Slides für Android über Java hinzufügen, anheften, neu routen, anpassen und untersuchen."
---
## **Übersicht**

Ein Verbinder ist eine Linie, die an zwei Formen angeheftet bleiben kann, wenn sich eine der Formen bewegt. Seine Enden werden an Verbindungspunkten befestigt, die in PowerPoint durch grüne Punkte dargestellt werden. Einige gebogene und gekrümmte Verbinder zeigen außerdem Anpassungspunkte, die durch orange Punkte dargestellt werden und die Position einzelner Verbindungselemente steuern.

Aspose.Slides stellt Verbinder über das Interface [IConnector](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iconnector/) dar. Sie können Verbinder erstellen, deren Enden an Formen anheften, Verbindungspunkte auswählen, sie neu routen und die Geometrie von Verbindern mit Anpassungspunkten ändern.

## **Verbinder‑Typen**

Die Klasse [ShapeType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapetype/) enthält voreingestellte gerade, gebogene und gekrümmte Verbinder. Die folgende Tabelle zeigt die verfügbaren Verbindergeometrien und die Anzahl der für jedes Preset definierten Anpassungspunkte.

| Verbinder | Bild | Anzahl der Anpassungspunkte |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Die Anzahl und Bedeutung der Anpassungspunkte sind Teil des gewählten Verbinder‑Presets. Sie dürfen nicht davon ausgehen, dass zwei verschiedene Verbinder‑Typen dieselbe Sammlungsstruktur aufweisen.

## **Zwei Formen verbinden**

Verwenden Sie [IShapeCollection.addConnector](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-), um einen Verbinder hinzuzufügen, und [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) sowie [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-), um seine Enden anzuhängen. Nachdem beide Enden angeheftet wurden, wählt [IConnector.reroute](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iconnector/#reroute--) eine kurze Route zwischen den Formen aus.

Das folgende Beispiel verbindet eine Ellipse und ein Rechteck mit einem gebogenen Verbinder:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}

Ein Aufruf von `reroute` kann die Werte von [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) und [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) ändern. Weisen Sie nach dem Rerouten bestimmte Verbindungspunkte zu, wenn diese fest bleiben sollen.

{{% /alert %}}

## **Einen Verbindungspunkt auswählen**

Jede verbindbare Form meldet die Anzahl ihrer Punkte über [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--). Prüfen Sie vor der Zuweisung zu einem Verbinderende, ob ein bevorzugter nullbasierter Index gültig ist; die Punktzahlen variieren je nach Formgeometrie.

Dieses Beispiel hängt den Verbinder an einen bestimmten Punkt der Ellipse, sofern dieser existiert:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Einen Verbinder‑Punkt anpassen**

Verbinder mit Anpassungspunkten stellen diese über [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/igeometryshape/#getAdjustments--) bereit. Untersuchen Sie jedes [IAdjustValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/) und prüfen Sie dessen [getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/#getType--)‑Wert, bevor Sie ihn mit [setRawValue](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/#setRawValue-long-) ändern. Die allgemeinen Regeln zur Identifizierung von Preset‑Formanpassungen sind in [Shape Manipulation](/slides/de/androidjava/shape-manipulations/) beschrieben.

Die Anzahl, Reihenfolge, Bedeutung und der gültige Wertebereich von Verbinder‑Anpassungen hängen vom Verbinder‑Preset ab. Der Anpassungstyp ist schreibgeschützt, während der Anpassungswert beschreibbar ist. Die schreibgeschützte Methode [getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/#getName--) liefert zusätzliche Identifikation, wenn ein Verbinder mehr als eine Anpassung desselben semantischen Typs enthält.

### **Um ein Hindernis herumführen**

Im folgenden Layout verläuft ein `BentConnector5` zwischen zwei Formen durch eine dritte Form:

![connector-obstruction](connector-obstruction.png)

Dieser Code erstellt den blockierten Verbinder:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Das Verschieben des vertikalen Biegungspunkts ändert die Route, sodass der Verbinder das Hindernis umgeht:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Anstatt anzunehmen, dass der Sammlungs‑Index `1` immer die vertikale Biegung darstellt, sucht dieses Beispiel nach `ConnectorBendPositionY` und ändert ihn nur, wenn der erwartete semantische Typ vorhanden ist:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ein `BentConnector5` besitzt zwei `ConnectorBendPositionX`‑Anpassungen und eine `ConnectorBendPositionY`‑Anpassung. Wenn der benötigte Typ mehrfach vorkommt, prüfen Sie `getName` und die bekannte Geometrie dieses Presets, bevor Sie einen auswählen. Gibt eine Anpassung `ShapeAdjustmentType.Custom` zurück, behandeln Sie deren Bedeutung und Wertebereich als preset‑spezifisch und ändern Sie sie nicht, bis der Vertrag bekannt ist.

## **Anpassungswerte in Relation zur Verbindergeometrie setzen**

Bei gebogenen Verbindern können Anpassungswerte verwendet werden, um die Positionen einzelner Segmente zu schätzen. Diese Berechnungen sind spezifisch für das Verbinder‑Preset:

- `BentConnector4` stellt normalerweise eine `ConnectorBendPositionX`‑ und eine `ConnectorBendPositionY`‑Anpassung bereit.
- Für diese Biegungspositionen ergibt die Division des von `getRawValue` zurückgegebenen Wertes durch `100000f` den Bruchteil der Verbinder‑Rahmenbreite bzw. -höhe, der in den nachfolgenden Beispielen verwendet wird.
- Ein Verbinderrahmen kann gedreht oder gespiegelt sein, sodass Rahmenkoordinaten vor dem Vergleich mit Folienkoordinaten transformiert werden müssen.

Die folgenden Beispiele verwenden zunächst `getType`, um die Anpassungen zu identifizieren. Sie behandeln Sammlungsindizes nicht als portable Kennungen.

### **Nicht gedrehter Verbinder**

Das Ausgangslayout enthält zwei Textformen, die durch einen `BentConnector4` verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Dieses Beispiel untersucht den Verbinder und ermittelt dessen horizontale und vertikale Biegungsanpassungen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

Um beide Biegungen zu ändern, finden Sie zunächst jeden erwarteten Typ und modifizieren Sie die Werte erst, nachdem beide gefunden wurden:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Das Ergebnis ist ein Verbinder, dessen horizontale und vertikale Segmente verschoben wurden:

![connector-adjusted-1](connector-adjusted-1.png)

Sobald die semantischen Typen bekannt sind, können ihre Werte in Verbinder‑Rahmenkoordinaten umgerechnet werden. Dieses Beispiel zeichnet ein dünnes Rechteck über das vertikale Segment, das von den beiden Biegungsanpassungen gesteuert wird:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Die Hilfsform markiert das berechnete Segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Gedrehter oder gespiegelter Verbinder**

Wenn dieselbe Verbindergeometrie vertikal ausgerichtet ist, beeinflussen die Werte von [IShape.getFrame](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapeframe/#getFlipH--) und [ShapeFrame.getFlipV](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/shapeframe/#getFlipV--) die Umrechnung von Verbinder‑Rahmenkoordinaten zu Folienkoordinaten.

Dieses Beispiel erstellt und passt den vertikal ausgerichteten Verbinder an:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    int connectorColor = Color.rgb(102, 205, 170);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der angepasste Verbinder erscheint vertikal zwischen den Formen:

![connector-adjusted-3](connector-adjusted-3.png)

Für einen beliebigen Rotationswinkel `alpha` rotiert man einen Verbinder‑Rahmenpunkt `(x, y)` um das Rahmencentrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Der folgende Code behandelt die 90‑Grad‑Orientierung, die in diesem Beispiel verwendet wird, und zeichnet einen roten Leitfaden über das entsprechende Verbindersegment:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Der rote Leitfaden markiert das nach der Koordinatentransformation berechnete Segment:

![connector-adjusted-4](connector-adjusted-4.png)

Diese Formeln beschreiben die in den Beispielen verwendeten Presets, nicht ein universelles Verbinder‑Modell. Validieren Sie die Anpassungstypen, Rahmenorientierung und Wertebereiche, bevor Sie dieselbe Berechnung auf ein anderes Preset anwenden.

## **Den Winkel einer Verbinder‑Richtung finden**

Der Richtungswinkel eines geraden Verbinders kann aus Breite und Höhe berechnet werden, wobei horizontale und vertikale Spiegelungen berücksichtigt werden. Das folgende Beispiel gibt den im Uhrzeigersinn gemessenen Winkel relativ zur positiven Horizontalachse in Folienkoordinaten aus:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wie kann ich feststellen, ob ein Verbinder an einer Form befestigt werden kann?**

Überprüfen Sie den Wert von [getConnectionSiteCount](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getConnectionSiteCount--). Ein positiver Wert bedeutet, dass die Form Verbindungspunkte bereitstellt. Validieren Sie den ausgewählten Punkt‑Index, bevor Sie ihn einem Verbinderende zuweisen.

**Kann ich eine Verbinder‑Anpassung anhand ihres Sammlungs‑Indexes identifizieren?**

Ein Index ist nur für ein bekanntes Verbinder‑Preset und dessen Sammlungsstruktur sinnvoll. Prüfen Sie [IAdjustValue.getType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/#getType--) bevor Sie einen Wert ändern, und verwenden Sie [IAdjustValue.getName](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iadjustvalue/#getName--) als zusätzliche Information, wenn derselbe semantische Typ mehrfach vorkommt.

**Was passiert, wenn eine verbundene Form gelöscht wird?**

Das entsprechende Verbinderende wird lose. Der Verbinder bleibt auf der Folie und kann gelöscht, als freie Linie positioniert oder an einer anderen Form befestigt werden.

**Werden Verbinder‑Verknüpfungen beibehalten, wenn eine Folie kopiert wird?**

Verknüpfungen bleiben in der Regel erhalten, wenn die verbundenen Formen mit der Folie kopiert werden. Wird ein Verbinder ohne eine seiner Ziel­formen kopiert, muss das betroffene Ende erneut angeheftet werden.