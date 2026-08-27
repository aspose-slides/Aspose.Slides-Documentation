---
title: Hantera kopplingar i presentationer med PHP
linktitle: Koppling
type: docs
weight: 10
url: /sv/php-java/connector/
keywords:
- koppling
- kopplingstyp
- kopplingspunkt
- kopplingslinje
- kopplingsvinkel
- anslutningsställe
- justeringspunkt
- koppla former
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du lägger till, fäster, omdirigerar, justerar och granskar raka, böjda och kurvade PowerPoint-kopplingar med Aspose.Slides för PHP via Java."
---
## **Översikt**

En koppling är en linje som kan förbli fäst vid två former när någon av formerna flyttas. Dess ändar fästs vid anslutningsställen, som visas som gröna prickar i PowerPoint. Vissa böjda och kurvade kopplingar visar även justeringspunkter, representerade av orange prickar, som styr positionen för enskilda segment av kopplingen.

Aspose.Slides representerar kopplingar genom klassen [Connector](https://reference.aspose.com/slides/sv/php-java/aspose.slides/connector/). Du kan skapa dem, fästa deras ändar på former, välja anslutningsställen, omdirigera dem och ändra geometrin för kopplingar som har justeringspunkter.

## **Kopplingstyper**

Klassen [ShapeType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapetype/) innehåller förinställningar för raka, böjda och kurvade kopplingar. Tabellen nedan visar tillgängliga kopplingsgeometrier och antalet justeringspunkter som definieras av varje förinställning.

| Koppling | Bild | Antal justeringspunkter |
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

Antalet och innebörden av justeringspunkterna är en del av den valda kopplingsförinställningen. Anta inte att två olika kopplingstyper exponerar samma samlingslayout.

## **Koppla två former**

Använd [ShapeCollection::addConnector](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/addconnector/) för att lägga till en koppling, och använd [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/connector/setstartshapeconnectedto/) samt [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/sv/php-java/aspose.slides/connector/setendshapeconnectedto/) för att fästa dess ändar. När båda ändarna är fästa väljer [Connector::reroute](https://reference.aspose.com/slides/sv/php-java/aspose.slides/connector/reroute/) en kort ruta mellan formerna.

Följande exempel kopplar en ellips och en rektangel med en böjd koppling:

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

{{% alert color="warning" title="Varning" %}}

Att anropa `reroute` kan ändra värdena för [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) och [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Tilldela specifika anslutningsställen efter omdirigering om dessa ställen måste förbli fasta.

{{% /alert %}}

## **Välj ett anslutningsställe**

Varje form som kan anslutas rapporterar sitt antal ställen via [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getconnectionsitecount/). Validera ett föredraget nollbaserat ställeindex innan du tilldelar det till en kopplingsände; antalet ställen varierar beroende på formens geometri.

Detta exempel fäster kopplingen på ett specifikt ställe på ellipsen när det stället finns:

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

## **Justera en kopplingspunkt**

Kopplingar med justeringspunkter exponerar dem via [GeometryShape::getAdjustments](https://reference.aspose.com/slides/sv/php-java/aspose.slides/geometryshape/#getadjustments). Inspektera varje [AdjustValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/) och kontrollera dess [AdjustValue::getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/#gettype)-värde innan du ändrar det med [AdjustValue::setRawValue](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/setrawvalue/). De allmänna reglerna för att identifiera förinställda formjusteringar beskrivs i [Shape Manipulation](/slides/sv/php-java/shape-manipulations/).

Antalet, ordningen, innebörden och det giltiga värdeintervallet för kopplingsjusteringar beror på kopplingsförinställningen. Justeringstypen är skrivskyddad, medan justeringsvärdet är skrivbart. Den skrivskyddade metoden [AdjustValue::getName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/getname/) ger ytterligare identifiering när en koppling innehåller mer än en justering av samma semantiska typ.

### **Rutt runt ett hinder**

I layouten nedan passerar en `BentConnector5` mellan två former genom en tredje form:

![connector-obstruction](connector-obstruction.png)

Denna kod skapar den hindrade kopplingen:

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

Att flytta den vertikala böjen ändrar rutten så att kopplingen går förbi hindret:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Istället för att anta att samlingsindex `1` alltid representerar den vertikala böjen, söker detta exempel efter `ConnectorBendPositionY` och ändrar den endast när den förväntade semantiska typen finns:

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

En `BentConnector5` har två `ConnectorBendPositionX`-justeringar och en `ConnectorBendPositionY`-justering. Om den typ du behöver förekommer flera gånger, inspektera `getName` och den kända geometrin för den förinställningen innan du väljer en. Om en justering rapporterar `ShapeAdjustmentType::Custom`, behandla dess innebörd och intervall som förinställningsspecifika och ändra den inte förrän kontraktet är känt.

## **Koppla justeringsvärden till kopplingsgeometri**

För böjda kopplingar kan justeringsvärden användas för att uppskatta positionerna för individuella segment. Dessa beräkningar är specifika för kopplingsförinställningen:

- `BentConnector4` exponerar normalt en `ConnectorBendPositionX` och en `ConnectorBendPositionY`-justering.
- För dessa böjpositioner ger division av värdet som returneras av `getRawValue` med `100000` bråkdelen av kopplingsramens bredd eller höjd som används i exemplen nedan.
- En kopplingsram kan roteras eller vändas, så ramkoordinater måste transformeras innan de jämförs med bildens koordinater.

Följande exempel använder `getType` för att först identifiera justeringarna. De behandlar inte samlingsindex som portabla identifierare.

### **Icke roterad koppling**

Den ursprungliga layouten innehåller två textformer som är förenade med en `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Detta exempel inspekterar kopplingen och hämtar dess horisontella och vertikala böjningsjusteringar:

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

För att ändra båda böjarna, lokalisera varje förväntad typ och modifiera värdena först när båda har hittats:

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

Resultatet blir en koppling vars horisontella och vertikala segment har flyttats:

![connector-adjusted-1](connector-adjusted-1.png)

När de semantiska typerna är kända kan deras värden konverteras till kopplingsramens koordinater. Detta exempel ritar en tunn rektangel över det vertikala segmentet som styrs av de två böjningsjusteringarna:

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

Guideformen markerar det beräknade segmentet:

![connector-adjusted-2](connector-adjusted-2.png)

### **Roterad eller vänd koppling**

När samma kopplingsgeometri är orienterad vertikalt påverkar värdena från [Shape::getFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapeframe/getfliph/) och [ShapeFrame::getFlipV](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapeframe/getflipv/) konverteringen från kopplingsramens koordinater till bildkoordinater.

Detta exempel skapar och justerar den vertikalt orienterade kopplingen:

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

Den justerade kopplingen visas vertikalt mellan formerna:

![connector-adjusted-3](connector-adjusted-3.png)

För en godtycklig rotationsvinkel `alpha` roteras en punkt i kopplingsramen `(x, y)` kring ramens centrum `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Följande kod hanterar den 90‑graders orientering som används i detta exempel och ritar en röd guide över motsvarande kopplingssegment:

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

Den röda guiden markerar det beräknade segmentet efter koordinattransformationen:

![connector-adjusted-4](connector-adjusted-4.png)

Dessa formler beskriver förinställningarna som används i exemplen, inte en universell kopplingsmodell. Validera justeringstyper, ramorientering och värdeintervall innan du tillämpar samma beräkning på en annan förinställning.

## **Hitta en kopplingsriktningens vinkel**

Riktningen för en rak koppling kan beräknas från dess bredd och höjd, med horisontella och vertikala vändningar tillämpade. Följande exempel rapporterar den medurs vinkel från den positiva horisontella axeln i bildkoordinater:

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

**Hur kan jag avgöra om en koppling kan fästas vid en form?**

Kontrollera formens [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getconnectionsitecount/)-värde. Ett positivt antal innebär att formen exponerar anslutningsställen. Validera det valda ställeindexet innan du tilldelar det till någon av kopplingsändarna.

**Kan jag identifiera en kopplingsjustering via dess samlingsindex?**

Ett index är meningsfullt bara för en känd kopplingsförinställning och samlingslayout. Kontrollera [AdjustValue::getType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/#gettype) innan du modifierar ett värde, och använd [AdjustValue::getName](https://reference.aspose.com/slides/sv/php-java/aspose.slides/adjustvalue/getname/) som ytterligare information när samma semantiska typ förekommer mer än en gång.

**Vad händer när en ansluten form tas bort?**

Den motsvarande kopplingsänden blir frånkopplad. Kopplingen har kvar på bilden och kan tas bort, placeras som en fri linje eller fästas på en annan form.

**Bevaras kopplingsbindningar när en bild kopieras?**

Bindningar bevaras i allmänhet när de anslutna formerna kopieras med bilden. Om en koppling kopieras utan någon av sina målformer måste den drabbade änden fästas igen.