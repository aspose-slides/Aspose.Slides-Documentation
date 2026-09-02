---
title: Connectoren in Präsentationen mit JavaScript verwalten
linktitle: Verbinder
type: docs
weight: 10
url: /de/nodejs-java/connector/
keywords:
- Connector
- Connector-Typ
- Connector-Punkt
- Connector-Linie
- Connector-Winkel
- Verbindungsstelle
- Anpassungspunkt
- Formen verbinden
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie gerade, gebogene und gekrümmte PowerPoint‑Connectoren mit Aspose.Slides für Node.js über Java hinzufügen, anfügen, neu routen, anpassen und untersuchen können."
---
## **Übersicht**

Ein Connector ist eine Linie, die an zwei Formen befestigt bleiben kann, wenn eine der Formen bewegt wird. Seine Enden werden an Verbindungsstellen angebracht, die in PowerPoint durch grüne Punkte dargestellt werden. Einige gebogene und gekrümmte Connectoren besitzen außerdem Anpassungspunkte, die durch orange Punkte dargestellt werden und die Position einzelner Connector‑Segmente steuern.

Aspose.Slides stellt Connectoren über die Klasse [Connector](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/connector/) dar. Sie können Connectoren erstellen, deren Enden an Formen anbinden, Verbindungsstellen auswählen, sie neu routen und die Geometrie von Connectoren mit Anpassungspunkten ändern.

## **Connector‑Typen**

Die Klasse [ShapeType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapetype/) umfasst Vorgaben für gerade, gebogene und gekrümmte Connectoren. Die folgende Tabelle zeigt die verfügbaren Connector‑Geometrien und die Anzahl der für jede Vorgabe definierten Anpassungspunkte.

| Connector | Bild | Anzahl der Anpassungspunkte |
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

Die Anzahl und Bedeutung der Anpassungspunkte gehören zur jeweiligen Connector‑Vorgabe. Gehen Sie nicht davon aus, dass zwei unterschiedliche Connector‑Typen dieselbe Sammlungsstruktur besitzen.

## **Zwei Formen verbinden**

Verwenden Sie [ShapeCollection.addConnector](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/addconnector/), um einen Connector hinzuzufügen, und nutzen Sie [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) sowie [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/connector/setendshapeconnectedto/), um dessen Enden zu befestigen. Nachdem beide Enden angebunden sind, wählt [Connector.reroute](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/connector/reroute/) eine kurze Route zwischen den Formen.

Das folgende Beispiel verbindet eine Ellipse und ein Rechteck mit einem gebogenen Connector:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}

Der Aufruf von `reroute` kann die Werte von [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) und [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/) ändern. Weisen Sie nach dem Rerouten konkrete Verbindungsstellen zu, wenn diese fest bleiben sollen.

{{% /alert %}}

## **Eine Verbindungsstelle auswählen**

Jede verbindbare Form gibt ihre Anzahl an Verbindungsstellen über [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/getconnectionsitecount/) zurück. Validieren Sie einen bevorzugten nullbasierten Stellenindex, bevor Sie ihn einem Connector‑Ende zuweisen; die Anzahl variiert je nach Formgeometrie.

Dieses Beispiel bindet den Connector an eine bestimmte Stelle der Ellipse, sofern diese existiert:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Einen Connector‑Punkt anpassen**

Connectoren mit Anpassungspunkten stellen diese über [GeometryShape.getAdjustments](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/geometryshape/) bereit. Prüfen Sie jeden [AdjustValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/) und dessen [getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/)-Wert, bevor Sie ihn mit [setRawValue](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) ändern. Die allgemeinen Regeln zur Identifizierung von Vorgaben‑Anpassungen werden in [Shape Manipulation](/slides/de/nodejs-java/shape-manipulations/) beschrieben.

Die Anzahl, Reihenfolge, Bedeutung und der zulässige Wertebereich von Connector‑Anpassungen hängen von der jeweiligen Vorgabe ab. Der Anpassungstyp ist schreibgeschützt, der Anpassungswert hingegen beschreibbar. Die schreibgeschützte Methode [getName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/getname/) liefert zusätzliche Identifikation, wenn ein Connector mehrere Anpassungen desselben semantischen Typs enthält.

### **Um ein Hindernis herumführen**

In der folgenden Anordnung verläuft ein `BentConnector5` zwischen zwei Formen durch eine dritte Form:

![connector-obstruction](connector-obstruction.png)

Dieser Code erzeugt den blockierten Connector:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Durch Verschieben des vertikalen Bends ändert sich die Route, sodass der Connector das Hindernis umgeht:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Anstatt anzunehmen, dass Index `1` immer den vertikalen Bend darstellt, sucht dieses Beispiel nach `ConnectorBendPositionY` und ändert ihn nur, wenn der erwartete semantische Typ vorhanden ist:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ein `BentConnector5` besitzt zwei `ConnectorBendPositionX`‑Anpassungen und eine `ConnectorBendPositionY`‑Anpassung. Wenn der benötigte Typ mehr als einmal vorkommt, prüfen Sie `getName` und die bekannte Geometrie dieser Vorgabe, bevor Sie eine Auswahl treffen. Gibt eine Anpassung `ShapeAdjustmentType.Custom` zurück, behandeln Sie Bedeutung und Wertebereich als vorsppezifisch und ändern Sie sie nicht, solange die Vertragsbedingungen unbekannt sind.

## **Anpassungswerte in Beziehung zur Connector‑Geometrie setzen**

Bei gebogenen Connectoren können Anpassungswerte verwendet werden, um die Position einzelner Segmente abzuschätzen. Diese Berechnungen sind spezifisch für die jeweilige Connector‑Vorgabe:

- `BentConnector4` stellt normalerweise eine `ConnectorBendPositionX`‑ und eine `ConnectorBendPositionY`‑Anpassung bereit.
- Für diese Bends ergibt die Division des von `getRawValue` zurückgegebenen Werts durch `100000` den Bruchteil der Connector‑Rahmenbreite bzw. -höhe, wie in den nachfolgenden Beispielen verwendet.
- Ein Connector‑Rahmen kann rotiert oder gespiegelt sein; daher müssen Rahmenkoordinaten vor dem Vergleich mit Folienkoordinaten transformiert werden.

Die folgenden Beispiele nutzen `getType`, um zunächst die Anpassungen zu identifizieren. Sie behandeln Sammlungsindizes nicht als portable Kennungen.

### **Nicht‑roter Connector**

Die Ausgangsanordnung enthält zwei Textformen, die durch einen `BentConnector4` verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Dieses Beispiel prüft den Connector und ermittelt seine horizontalen und vertikalen Bend‑Anpassungen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

Um beide Bends zu ändern, lokalisieren Sie jeden erwarteten Typ und modifizieren Sie die Werte erst, nachdem beide gefunden wurden:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Das Ergebnis ist ein Connector, dessen horizontale und vertikale Segmente verschoben wurden:

![connector-adjusted-1](connector-adjusted-1.png)

Sind die semantischen Typen bekannt, können deren Werte in Connector‑Rahmenkoordinaten umgerechnet werden. Dieses Beispiel zeichnet ein dünnes Rechteck über das vertikale Segment, das von den beiden Bend‑Anpassungen gesteuert wird:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Die Hilfsform markiert das berechnete Segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Rotierter oder gespiegelter Connector**

Wenn dieselbe Connector‑Geometrie vertikal ausgerichtet ist, beeinflussen die Werte von [Shape.getFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapeframe/getfliph/) und [ShapeFrame.getFlipV](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapeframe/getflipv/) die Umrechnung von Connector‑Rahmen‑ zu Folienkoordinaten.

Dieses Beispiel erzeugt und passt den vertikal ausgerichteten Connector an:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Der angepasste Connector erscheint vertikal zwischen den Formen:

![connector-adjusted-3](connector-adjusted-3.png)

Für einen beliebigen Rotationswinkel `alpha` wird ein Punkt `(x, y)` des Connector‑Rahmens um das Rahmenzentrum `(x0, y0)` rotiert:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Der nachfolgende Code behandelt die in diesem Beispiel genutzte 90‑Grad‑Ausrichtung und zeichnet eine rote Hilfslinie über das entsprechende Connector‑Segment:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Die rote Hilfslinie markiert das nach der Koordinatentransformation berechnete Segment:

![connector-adjusted-4](connector-adjusted-4.png)

Diese Formeln beschreiben die in den Beispielen verwendeten Vorgaben, nicht ein universelles Connector‑Modell. Validieren Sie vor der Anwendung derselben Berechnung auf eine andere Vorgabe die Anpassungstypen, Rahmenorientierung und Wertebereiche.

## **Den Winkel der Connector‑Richtung ermitteln**

Der Winkel eines geraden Connectors kann aus seiner Breite und Höhe berechnet werden, wobei horizontale und vertikale Spiegelungen berücksichtigt werden. Das folgende Beispiel gibt den im Uhrzeigersinn gemessenen Winkel zur positiven Horizontalachse in Folienkoordinaten aus:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wie kann ich feststellen, ob ein Connector an einer Form befestigt werden kann?**

Prüfen Sie den Wert von [getConnectionSiteCount](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/getconnectionsitecount/) der Form. Ein positiver Wert bedeutet, dass die Form Verbindungsstellen bereitstellt. Validieren Sie den gewählten Stellenindex, bevor Sie ihn einem Connector‑Ende zuweisen.

**Kann ich eine Connector‑Anpassung anhand ihres Sammlungsindexes identifizieren?**

Ein Index ist nur für eine bekannte Connector‑Vorgabe und deren Sammlungsstruktur sinnvoll. Prüfen Sie [AdjustValue.getType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/), bevor Sie einen Wert ändern, und verwenden Sie [AdjustValue.getName](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/adjustvalue/getname/) als zusätzliche Information, wenn derselbe semantische Typ mehrfach vorkommt.

**Was passiert, wenn eine verbundene Form gelöscht wird?**

Das zugehörige Connector‑Ende wird losgelöst. Der Connector bleibt auf der Folie erhalten und kann gelöscht, als freie Linie positioniert oder an eine andere Form angebunden werden.

**Werden Connector‑Bindungen beim Kopieren einer Folie erhalten?**

Bindungen bleiben in der Regel erhalten, wenn die verbundenen Formen zusammen mit der Folie kopiert werden. Wird ein Connector ohne eine seiner Ziel‑Formen kopiert, muss das betroffene Ende erneut angebunden werden.