---
title: Verbindungselemente in Präsentationen in Java verwalten
linktitle: Verbindungselement
type: docs
weight: 10
url: /de/java/connector/
keywords:
- Verbindungselement
- Verbindungselementtyp
- Verbindungspunkt
- Verbindungslinie
- Verbindungswinkel
- Verbindungsstelle
- Anpassungspunkt
- Formen verbinden
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie gerade, geknickte und gekrümmte PowerPoint‑Verbindungselemente mit Aspose.Slides für Java hinzufügen, anhängen, umleiten, anpassen und inspizieren können."
---
## **Übersicht**

Ein Verbindungselement ist eine Linie, die an zwei Formen befestigt bleiben kann, wenn sich eine der Formen bewegt. Seine Enden werden an Verbindungsstellen befestigt, die in PowerPoint durch grüne Punkte dargestellt werden. Einige gebogene und gekrümmte Verbindungselemente besitzen außerdem Anpassungspunkte, die durch orange Punkte angezeigt werden und die Position einzelner Segmente des Verbindungselements steuern.

Aspose.Slides repräsentiert Verbindungselemente über das [IConnector](https://reference.aspose.com/slides/de/java/com.aspose.slides/iconnector/)‑Interface. Sie können Verbindungselemente erstellen, deren Enden an Formen anhängen, Verbindungsstellen auswählen, sie umleiten und die Geometrie von Verbindungselementen mit Anpassungspunkten ändern.

## **Verbindungstypen**

Die [ShapeType](https://reference.aspose.com/slides/de/java/com.aspose.slides/shapetype/)‑Klasse enthält Voreinstellungen für gerade, geknickte und gekrümmte Verbindungselemente. Die folgende Tabelle zeigt die verfügbaren Geometrien und die Anzahl der Anpassungspunkte, die jede Voreinstellung definiert.

| Verbindungselement | Bild | Anzahl der Anpassungspunkte |
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

Die Anzahl und Bedeutung der Anpassungspunkte sind Teil der jeweiligen Voreinstellung. Gehen Sie nicht davon aus, dass zwei unterschiedliche Verbindungstypen dieselbe Layout‑Struktur der Sammlung besitzen.

## **Zwei Formen verbinden**

Verwenden Sie [IShapeCollection.addConnector](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-), um ein Verbindungselement hinzuzufügen, und verwenden Sie [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) sowie [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/de/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-), um seine Enden zu verbinden. Nachdem beide Enden befestigt sind, wählt [IConnector.reroute](https://reference.aspose.com/slides/de/java/com.aspose.slides/iconnector/#reroute--) eine kurze Route zwischen den Formen.

Das folgende Beispiel verbindet eine Ellipse und ein Rechteck mit einem geknickten Verbindungselement:

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

Der Aufruf von `reroute` kann die Werte von [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) und [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) ändern. Weisen Sie nach dem Umleiten bestimmte Verbindungsstellen zu, wenn diese fest bleiben müssen.

{{% /alert %}}

## **Verbindungsstelle auswählen**

Jede verbindbare Form gibt ihre Anzahl von Verbindungsstellen über [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getConnectionSiteCount--) zurück. Validieren Sie einen bevorzugten nullbasierten Stellen‑Index, bevor Sie ihn einem Verbindungselement‑Ende zuweisen; die Anzahl variiert je nach Formgeometrie.

Dieses Beispiel befestigt das Verbindungselement an einer bestimmten Stelle der Ellipse, sofern diese existiert:

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

## **Anpassungspunkt eines Verbindungselements anpassen**

Verbindungselemente mit Anpassungspunkten stellen diese über [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/de/java/com.aspose.slides/igeometryshape/#getAdjustments--) bereit. Überprüfen Sie jedes [IAdjustValue](https://reference.aspose.com/slides/de/java/com.aspose.slides/iadjustvalue/) und dessen [getType](https://reference.aspose.com/slides/de/java/com.aspose.slides/iadjustvalue/#getType--)‑Wert, bevor Sie ihn mit [setRawValue](https://reference.aspose.com/slides/de/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) ändern. Die allgemeinen Regeln zur Identifizierung von Voreinstellungs‑Formanpassungen sind in [Shape Manipulation](/slides/de/java/shape-manipulations/) beschrieben.

Die Anzahl, Reihenfolge, Bedeutung und der zulässige Wertebereich von Verbindungselement‑Anpassungen hängen von der jeweiligen Voreinstellung ab. Der Anpassungstyp ist schreibgeschützt, der Anpassungswert jedoch beschreibbar. Die schreibgeschützte Methode [getName](https://reference.aspose.com/slides/de/java/com.aspose.slides/iadjustvalue/#getName--) liefert zusätzliche Identifikation, wenn ein Verbindungselement mehr als eine Anpassung des gleichen semantischen Typs enthält.

### **Um ein Hindernis herumführen**

Im folgenden Layout verläuft ein `BentConnector5` zwischen zwei Formen durch eine dritte Form:

![connector-obstruction](connector-obstruction.png)

Der Code erzeugt das blockierte Verbindungselement:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Das Verschieben der vertikalen Krümmung ändert die Route, sodass das Verbindungselement das Hindernis umgeht:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Anstatt anzunehmen, dass der Sammlungs‑Index `1` immer die vertikale Krümmung darstellt, sucht dieses Beispiel nach `ConnectorBendPositionY` und ändert sie nur, wenn der erwartete semantische Typ vorhanden ist:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Ein `BentConnector5` besitzt zwei `ConnectorBendPositionX`‑Anpassungen und eine `ConnectorBendPositionY`‑Anpassung. Wenn der benötigte Typ mehrmals vorkommt, prüfen Sie `getName` und die bekannte Geometrie dieser Voreinstellung, bevor Sie einen auswählen. Gibt eine Anpassung `ShapeAdjustmentType.Custom` zurück, behandeln Sie ihre Bedeutung und den Wertebereich als presetspezifisch und ändern Sie sie nicht, solange die Vereinbarung nicht bekannt ist.

## **Bezug von Anpassungswerten zur Geometrie des Verbindungselements**

Bei geknickten Verbindungselementen können Anpassungswerte verwendet werden, um die Positionen einzelner Segmente abzuschätzen. Diese Berechnungen sind spezifisch für die jeweilige Voreinstellung:

- `BentConnector4` stellt normalerweise eine `ConnectorBendPositionX`‑ und eine `ConnectorBendPositionY`‑Anpassung bereit.
- Für diese Krümmungspositionen erzeugt das Teilen des von `getRawValue` zurückgegebenen Werts durch `100000f` den Bruchteil der Rahmenbreite bzw. -höhe, der in den folgenden Beispielen verwendet wird.
- Ein Rahmen eines Verbindungselements kann rotiert oder gespiegelt sein, sodass Rahmenkoordinaten vor dem Vergleich mit Folienkoordinaten transformiert werden müssen.

Die folgenden Beispiele verwenden zunächst `getType`, um die Anpassungen zu identifizieren. Sie behandeln Sammlungs‑Indizes nicht als portable Kennungen.

### **Unrotierter Verbindungselement**

Das Ausgangs‑Layout enthält zwei Textformen, die durch ein `BentConnector4` verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Dieses Beispiel untersucht das Verbindungselement und ermittelt seine horizontalen und vertikalen Krümmungs‑Anpassungen:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Um beide Krümmungen zu ändern, finden Sie jeden erwarteten Typ und passen die Werte erst an, nachdem beide gefunden wurden:

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

Das Ergebnis ist ein Verbindungselement, dessen horizontale und vertikale Segmente verschoben wurden:

![connector-adjusted-1](connector-adjusted-1.png)

Sobald die semantischen Typen bekannt sind, können deren Werte in Rahmen‑Koordinaten umgerechnet werden. Dieses Beispiel zeichnet ein dünnes Rechteck über das vertikale Segment, das von den beiden Krümmungs‑Anpassungen gesteuert wird:

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

Das Hilfs‑Formobjekt markiert das berechnete Segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Gedrehter oder gespiegelter Verbindungselement**

Wenn dieselbe Geometrie vertikal ausgerichtet ist, beeinflussen die Werte von [IShape.getFrame](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/de/java/com.aspose.slides/shapeframe/#getFlipH--) und [ShapeFrame.getFlipV](https://reference.aspose.com/slides/de/java/com.aspose.slides/shapeframe/#getFlipV--) die Umrechnung von Rahmen‑ zu Folienkoordinaten.

Dieses Beispiel erzeugt und passt das vertikal ausgerichtete Verbindungselement an:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
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

Das angepasste Verbindungselement erscheint vertikal zwischen den Formen:

![connector-adjusted-3](connector-adjusted-3.png)

Für einen beliebigen Rotationswinkel `alpha` wird ein Rahmen‑Punkt `(x, y)` um das Rahmen‑Mittelpunkt `(x0, y0)` rotiert:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Der nachfolgende Code behandelt die 90‑Grad‑Ausrichtung, die in diesem Beispiel verwendet wird, und zeichnet eine rote Führungslinie über das entsprechende Verbindungselement‑Segment:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Die rote Führungslinie markiert das berechnete Segment nach der Koordinatentransformation:

![connector-adjusted-4](connector-adjusted-4.png)

Diese Formeln beschreiben die in den Beispielen genutzten Voreinstellungen, nicht ein universelles Modell für Verbindungselemente. Validieren Sie die Anpassungstypen, die Rahmen­orientierung und die Wertebereiche, bevor Sie dieselbe Berechnung auf eine andere Voreinstellung anwenden.

## **Winkel der Verbindungselement‑Richtung ermitteln**

Der Richtungswinkel eines geraden Verbindungselements lässt sich aus Breite und Höhe berechnen, wobei horizontale und vertikale Spiegelungen berücksichtigt werden. Das folgende Beispiel gibt den im Uhrzeigersinn gemessenen Winkel zur positiven Horizontalachse in Folienkoordinaten aus:

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

**Wie kann ich feststellen, ob ein Verbindungselement an einer Form befestigt werden kann?**

Prüfen Sie den Wert von [getConnectionSiteCount](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getConnectionSiteCount--). Ein positiver Wert bedeutet, dass die Form Verbindungsstellen bereitstellt. Validieren Sie den ausgewählten Stellen‑Index, bevor Sie ihn einem Verbindungselement‑Ende zuweisen.

**Kann ich eine Verbindungselement‑Anpassung über ihren Sammlungs‑Index identifizieren?**

Ein Index ist nur für eine bekannte Voreinstellung und das zugehörige Layout sinnvoll. Prüfen Sie [IAdjustValue.getType](https://reference.aspose.com/slides/de/java/com.aspose.slides/iadjustvalue/#getType--) bevor Sie einen Wert ändern, und nutzen Sie [IAdjustValue.getName](https://reference.aspose.com/slides/de/java/com.aspose.slides/iadjustvalue/#getName--) als zusätzliche Information, wenn derselbe semantische Typ mehrfach vorkommt.

**Was passiert, wenn eine verbundene Form gelöscht wird?**

Das entsprechende Ende des Verbindungselements wird getrennt. Das Verbindungselement verbleibt auf der Folie und kann gelöscht, als freie Linie positioniert oder an eine andere Form angebunden werden.

**Bleiben die Bindungen von Verbindungselementen erhalten, wenn eine Folie kopiert wird?**

Die Bindungen bleiben in der Regel erhalten, wenn die verbundenen Formen zusammen mit der Folie kopiert werden. Wird ein Verbindungselement ohne eine seiner Ziel‑Formen kopiert, muss das betroffene Ende erneut befestigt werden.