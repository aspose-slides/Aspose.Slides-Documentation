---
title: Connectoren in Präsentationen mit PHP verwalten
linktitle: Verbinder
type: docs
weight: 10
url: /de/php-java/connector/
keywords:
- Verbinder
- Verbinder Typ
- Verbinderpunkt
- Verbinderlinie
- Verbinderwinkel
- Verbindungsstelle
- Anpassungspunkt
- Formen verbinden
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für PHP via Java gerade, gebogene und gekrümmte PowerPoint-Connectoren hinzufügen, anhängen, neu routen, anpassen und untersuchen können."
---
## **Übersicht**

Ein Connector ist eine Linie, die an zwei Formen befestigt bleiben kann, wenn sich eine der Formen bewegt. Seine Enden werden an Verbindungsstellen angebracht, die in PowerPoint durch grüne Punkte dargestellt werden. Einige gebogene und gekrümmte Connectoren zeigen zudem Anpassungspunkte (orange Punkte), mit denen die Position einzelner Connector‑Segmente gesteuert wird.

Aspose.Slides stellt Connectoren über die [Connector](https://reference.aspose.com/slides/de/php-java/aspose.slides/connector/)‑Klasse dar. Sie können Connectoren erstellen, deren Enden an Formen anhängen, Verbindungsstellen wählen, sie neu routen und die Geometrie von Connectoren mit Anpassungspunkten ändern.

## **Connector‑Typen**

Die [ShapeType](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapetype/)‑Klasse enthält Vorgaben für gerade, gebogene und gekrümmte Connectoren. Die folgende Tabelle zeigt die verfügbaren Connector‑Geometrien und die Anzahl der für jede Vorgabe definierten Anpassungspunkte.

| Connector | Bild | Anzahl der Anpassungspunkte |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Die Anzahl und Bedeutung der Anpassungspunkte sind Teil der jeweiligen Connector‑Vorgabe. Gehen Sie nicht davon aus, dass zwei verschiedene Connector‑Typen dieselbe Sammlungsstruktur besitzen.

## **Zwei Formen verbinden**

Verwenden Sie [ShapeCollection::addConnector](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapecollection/addconnector/), um einen Connector hinzuzufügen, und benutzen Sie [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/de/php-java/aspose.slides/connector/setstartshapeconnectedto/) sowie [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/de/php-java/aspose.slides/connector/setendshapeconnectedto/), um seine Enden anzuhängen. Sobald beide Enden befestigt sind, wählt [Connector::reroute](https://reference.aspose.com/slides/de/php-java/aspose.slides/connector/reroute/) eine kurze Verbindung zwischen den Formen.

Das folgende Beispiel verbindet eine Ellipse und ein Rechteck mit einem gebogenen Connector:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    $connector->reroute();

    $presentation->save("connected-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warnung" %}}
Das Aufrufen von `reroute` kann die Werte von [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) und [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/de/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/) ändern. Legen Sie nach dem Rerouten konkrete Verbindungsstellen fest, wenn diese fix bleiben sollen.
{{% /alert %}}

## **Verbindungsstelle wählen**

Jede verbindbare Form gibt ihre Anzahl an Stellen über [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getconnectionsitecount/) zurück. Validieren Sie einen gewünschten nullbasierten Stellen‑Index, bevor Sie ihn einem Connector‑Ende zuweisen; die Anzahl variiert je nach Formgeometrie.

Dieses Beispiel hängt den Connector an eine bestimmte Stelle der Ellipse, sofern diese existiert:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);

    $preferredSiteIndex = 2;
    $connectionSiteCount = java_values($ellipse->getConnectionSiteCount());
    if ($preferredSiteIndex < $connectionSiteCount) {
        $connector->setStartShapeConnectionSiteIndex($preferredSiteIndex);
    } else {
        echo "The ellipse has only " . $connectionSiteCount . " connection sites." . PHP_EOL;
    }

    $presentation->save("specific-connection-site.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Connector‑Punkt anpassen**

Connectoren mit Anpassungspunkten stellen diese über [GeometryShape::getAdjustments](https://reference.aspose.com/slides/de/php-java/aspose.slides/geometryshape/#getadjustments) bereit. Prüfen Sie jedes [AdjustValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/adjustvalue/) und dessen [AdjustValue::getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/adjustvalue/#gettype)-Wert, bevor Sie ihn mit [AdjustValue::setRawValue](https://reference.aspose.com/slides/de/php-java/aspose.slides/adjustvalue/setrawvalue/) ändern. Die allgemeinen Regeln zur Identifizierung von Vorgabe‑Form‑Anpassungen finden Sie in [Shape Manipulation](/slides/de/php-java/shape-manipulations/).

Die Anzahl, Reihenfolge, Bedeutung und der zulässige Wertebereich von Connector‑Anpassungen hängen von der jeweiligen Vorgabe ab. Der Anpassungstyp ist schreibgeschützt, der Wert jedoch änderbar. Die schreibgeschützte Methode [AdjustValue::getName](https://reference.aspose.com/slides/de/php-java/aspose.slides/adjustvalue/getname/) liefert zusätzliche Identifikation, wenn ein Connector mehr als eine Anpassung desselben semantischen Typs enthält.

### **Weg um ein Hindernis**

Im nachfolgenden Layout führt ein `BentConnector5` zwischen zwei Formen durch eine dritte Form:

![connector-obstruction](connector-obstruction.png)

Der Code erzeugt den blockierten Connector:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $presentation->save("connector-obstruction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Durch das Verschieben des vertikalen Biegungspunktes ändert sich die Route, sodass der Connector das Hindernis umgeht:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Anstatt anzunehmen, dass Index `1` immer die vertikale Biegung darstellt, sucht dieses Beispiel nach `ConnectorBendPositionY` und ändert ihn nur, wenn der erwartete semantische Typ vorhanden ist:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentName = java_values($adjustment->getName());
        $adjustmentType = java_values($adjustment->getType());
        $rawValue = java_values($adjustment->getRawValue());
        echo $adjustmentName . ": " . $adjustmentType . ", raw value = " . $rawValue . PHP_EOL;
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
            break;
        }
    }

    if ($verticalBend === null) {
        echo "The connector does not expose a vertical bend adjustment." . PHP_EOL;
    } else {
        $verticalBend->setRawValue(60000);
        $presentation->save("connector-obstruction-fixed.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Ein `BentConnector5` verfügt über zwei `ConnectorBendPositionX`‑Anpassungen und eine `ConnectorBendPositionY`‑Anpassung. Wenn der benötigte Typ mehrfach vorkommt, prüfen Sie `getName` und die bekannte Geometrie der Vorgabe, bevor Sie einen auswählen. Gibt eine Anpassung `ShapeAdjustmentType::Custom` zurück, behandeln Sie Bedeutung und Wertebereich als vorgabenspezifisch und ändern Sie sie nicht, solange der Vertrag nicht bekannt ist.

## **Anpassungswerte in Beziehung zur Connector‑Geometrie setzen**

Bei gebogenen Connectoren können Anpassungswerte verwendet werden, um die Positionen einzelner Segmente abzuschätzen. Diese Berechnungen sind spezifisch für die jeweilige Vorgabe:

- `BentConnector4` stellt normalerweise eine `ConnectorBendPositionX`‑ und eine `ConnectorBendPositionY`‑Anpassung bereit.
- Für diese Biegungspositionen ergibt das Teilen des mit `getRawValue` zurückgegebenen Werts durch `100000` den Bruchteil der Connector‑Rahmenbreite bzw. -höhe, wie in den nachfolgenden Beispielen verwendet.
- Ein Connector‑Rahmen kann rotiert oder gespiegelt sein, sodass Rahmenkoordinaten vor dem Vergleich mit Folienkoordinaten transformiert werden müssen.

Die folgenden Beispiele nutzen zuerst `getType`, um die Anpassungen zu identifizieren. Sie behandeln Sammlungsindizes nicht als portable Kennungen.

### **Nicht rotierter Connector**

Das Ausgangs‑Layout enthält zwei Textformen, die durch einen `BentConnector4` verbunden sind:

![connector-shape-complex](connector-shape-complex.png)

Dieses Beispiel untersucht den Connector und ermittelt die horizontalen und vertikalen Biegungs‑Anpassungen:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $targetShape->getTextFrame()->setText("To");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        echo $adjustment->getName() . ": " . $adjustment->getType() . ", raw value = " . $adjustment->getRawValue() . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Um beide Biegungen zu ändern, suchen Sie jeden erwarteten Typ und passen Sie die Werte erst an, nachdem beide gefunden wurden:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);
        $presentation->save("connector-adjusted.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Das Ergebnis ist ein Connector, dessen horizontale und vertikale Segmente verschoben wurden:

![connector-adjusted-1](connector-adjusted-1.png)

Sobald die semantischen Typen bekannt sind, können ihre Werte in Connector‑Rahmekoordinaten umgerechnet werden. Dieses Beispiel zeichnet ein dünnes Rechteck über das vertikale Segment, das von den beiden Biegungs‑Anpassungen gesteuert wird:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $x = $connectorX + $connectorWidth * $horizontalBendValue / 100000;
        $y = $connectorY;
        $height = $connectorHeight * $verticalBendValue / 100000;
        $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 1, $height);
        $presentation->save("connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Die Hilfsform markiert das berechnete Segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Rotierter oder gespiegelter Connector**

Wenn dieselbe Connector‑Geometrie vertikal ausgerichtet ist, beeinflussen die Werte von [Shape::getFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapeframe/getfliph/) und [ShapeFrame::getFlipV](https://reference.aspose.com/slides/de/php-java/aspose.slides/shapeframe/getflipv/) die Umrechnung von Rahmen‑ zu Folienkoordinaten.

Dieses Beispiel erzeugt und passt den vertikal ausgerichteten Connector an:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $targetShape->getTextFrame()->setText("To 1");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(102, 205, 170));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 20000);
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 200000);
        }
    }

    $presentation->save("vertical-connector-adjusted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der angepasste Connector erscheint vertikal zwischen den Formen:

![connector-adjusted-3](connector-adjusted-3.png)

Für einen beliebigen Rotationswinkel `alpha` wird ein Punkt `(x, y)` des Connector‑Rahmens um das Rahmenschwerpunkt `(x0, y0)` rotiert:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Der folgende Code behandelt die in diesem Beispiel genutzte 90‑Grad‑Orientierung und zeichnet eine rote Hilfslinie über das entsprechende Connector‑Segment:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);

        $frame = $connector->getFrame();
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $flipH = java_values($frame->getFlipH()) == NullableBool::True;
        $flipV = java_values($frame->getFlipV()) == NullableBool::True;
        $centerX = java_values($frame->getCenterX());
        $centerY = java_values($frame->getCenterY());

        $x = $connectorX;
        $y = $connectorY;
        if ($flipH) {
            $x += $connectorWidth;
        }
        if ($flipV) {
            $y += $connectorHeight;
        }

        $x += $connectorWidth * $horizontalBendValue / 100000;
        $rotatedX = $centerX - $y + $centerY;
        $rotatedY = $x - $centerX + $centerY;
        $segmentWidth = $connectorHeight * $verticalBendValue / 100000;
        $guide = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $rotatedX, $rotatedY, $segmentWidth, 1);
        $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));

        $presentation->save("rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Die rote Hilfslinie markiert das berechnete Segment nach der Koordinatentransformation:

![connector-adjusted-4](connector-adjusted-4.png)

Diese Formeln beschreiben die in den Beispielen genutzten Vorgaben, nicht ein universelles Connector‑Modell. Validieren Sie die Anpassungstypen, Rahmen‑Orientierung und Wertebereiche, bevor Sie dieselbe Berechnung auf eine andere Vorgabe anwenden.

## **Winkel der Connector‑Richtung ermitteln**

Der Richtungswinkel eines geraden Connectors kann aus seiner Breite und Höhe berechnet werden, wobei horizontale und vertikale Spiegelungen berücksichtigt werden. Das folgende Beispiel gibt den im Uhrzeigersinn gemessenen Winkel relativ zur positiven Horizontalachse in Folienkoordinaten aus:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);

    $frame = $connector->getFrame();
    $flipH = java_values($frame->getFlipH()) == NullableBool::True;
    $flipV = java_values($frame->getFlipV()) == NullableBool::True;
    $width = java_values($connector->getWidth());
    $height = java_values($connector->getHeight());
    $deltaX = $width * ($flipH ? -1 : 1);
    $deltaY = $height * ($flipV ? -1 : 1);
    $angle = atan2($deltaY, $deltaX) * 180.0 / pi();

    if ($angle < 0) {
        $angle += 360;
    }

    printf("Connector direction: %.2f degrees%s", $angle, PHP_EOL);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Wie kann ich feststellen, ob ein Connector an einer Form befestigt werden kann?**

Prüfen Sie den Wert von [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/getconnectionsitecount/). Ein positiver Wert bedeutet, dass die Form Verbindungsstellen bereitstellt. Validieren Sie den ausgewählten Stellen‑Index, bevor Sie ihn einem Connector‑Ende zuweisen.

**Kann ich eine Connector‑Anpassung anhand ihres Sammlungs‑Indexes identifizieren?**

Ein Index ist nur für eine bekannte Connector‑Vorgabe und deren Sammlungsstruktur sinnvoll. Prüfen Sie vor einer Änderung [AdjustValue::getType](https://reference.aspose.com/slides/de/php-java/aspose.slides/adjustvalue/#gettype) und verwenden Sie [AdjustValue::getName](https://reference.aspose.com/slides/de/php-java/aspose.slides/adjustvalue/getname/) als zusätzliche Information, wenn derselbe semantische Typ mehrmals vorkommt.

**Was passiert, wenn eine verbundene Form gelöscht wird?**

Das entsprechende Connector‑Ende wird getrennt. Der Connector bleibt auf der Folie und kann gelöscht, als freie Linie positioniert oder an einer anderen Form befestigt werden.

**Werden Connector‑Bindungen beibehalten, wenn eine Folie kopiert wird?**

Bindungen bleiben in der Regel erhalten, wenn die verbundenen Formen zusammen mit der Folie kopiert werden. Wird ein Connector ohne eine seiner Ziel‑Formen kopiert, muss das betroffene Ende erneut befestigt werden.