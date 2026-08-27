---
title: Správa spojníků v prezentacích pomocí PHP
linktitle: Spojník
type: docs
weight: 10
url: /cs/php-java/connector/
keywords:
- spojník
- typ spojníku
- bod spojníku
- čára spojníku
- úhel spojníku
- připojovací bod
- bod úpravy
- propojit tvary
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak pomocí Aspose.Slides pro PHP (prostřednictvím Javy) přidávat, přichytávat, přepočítávat, upravovat a kontrolovat rovné, ohnuté a zakřivené spojníky PowerPointu."
---
## **Přehled**

Spojník je čára, která může zůstat připojena ke dvěma tvarem, i když se některý z nich pohybuje. Jeho konce se přichytí k připojovacím bodům, které jsou v PowerPointu znázorněny zelenými tečkami. Některé ohnuté a zakřivené spojníky také nabízejí úpravy bodů, znázorněné oranžovými tečkami, které řídí polohu jednotlivých segmentů spojníku.

Aspose.Slides reprezentuje spojníky pomocí třídy [Connector](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/). Můžete je vytvářet, přichytit jejich konce k tvarům, vybrat připojovací body, přepočítat je a upravit geometrii spojníků, které mají úpravy bodů.

## **Typy spojníků**

Třída [ShapeType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapetype/) obsahuje předvolby pro rovné, ohnuté i zakřivené spojníky. Následující tabulka uvádí dostupné geometrie spojníků a počet úpravných bodů definovaných pro každou předvolbu.

| Spojník | Obrázek | Počet úpravných bodů |
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

Počet a význam úpravných bodů jsou součástí vybrané předvolby spojníku. Neočekávejte, že dva různé typy spojníků budou mít stejný uspořádání kolekce.

## **Propojení dvou tvarů**

Použijte [ShapeCollection::addConnector](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addconnector/) pro přidání spojníku a použijte [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/setstartshapeconnectedto/) a [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/setendshapeconnectedto/) k přichytání jeho konců. Po přichytění obou konců [Connector::reroute](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/reroute/) zvolí krátkou cestu mezi tvary.

Následující ukázka propojí elipsu a obdélník pomocí ohnutého spojníku:

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

{{% alert color="warning" title="Warning" %}}

Volání `reroute` může změnit hodnoty [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) a [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Po přepočítání přiřaďte konkrétní připojovací body, pokud mají zůstat pevné.

{{% /alert %}}

## **Výběr připojovacího bodu**

Každý připojitelný tvar udává svůj počet bodů pomocí [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getconnectionsitecount/). Před přiřazením ke konecům spojníku ověřte preferovaný nulový index; počet bodů se liší podle geometrie tvaru.

Tento příklad přichytí spojník k určitému bodu na elipse, pokud tento bod existuje:

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

## **Úprava bodu spojníku**

Spojníky s úpravným bodem je lze získat pomocí [GeometryShape::getAdjustments](https://reference.aspose.com/slides/cs/php-java/aspose.slides/geometryshape/#getadjustments). Prohlédněte každý [AdjustValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/) a před změnou zkontrolujte jeho hodnotu [AdjustValue::getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/#gettype/) pomocí [AdjustValue::setRawValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/setrawvalue/). Obecná pravidla pro identifikaci předvoleb úprav tvarů jsou popsána v [Shape Manipulation](/slides/cs/php-java/shape-manipulations/).

Počet, pořadí, význam a platný rozsah úpravy spojníku závisí na předvolbě spojníku. Typ úpravy je jen pro čtení, zatímco hodnota je zapisovatelná. Metoda jen pro čtení [AdjustValue::getName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/getname/) poskytuje další identifikaci, když spojník obsahuje více úprav stejného sémantického typu.

### **Obejití překážky**

V následujícím uspořádání prochází `BentConnector5` mezi dvěma tvary třetím tvarem:

![connector-obstruction](connector-obstruction.png)

Tento kód vytvoří blokovaný spojník:

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

Posunutí vertikálního ohybu změní trasu tak, aby spojník obcházel překážku:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Místo předpokladu, že index kolekce `1` vždy představuje vertikální ohyb, tento příklad hledá `ConnectorBendPositionY` a mění jej jen tehdy, když je přítomen očekávaný sémantický typ:

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

`BentConnector5` má dvě úpravy `ConnectorBendPositionX` a jednu úpravu `ConnectorBendPositionY`. Pokud potřebný typ výskyt vícekrát, prozkoumejte `getName` a známou geometrii předvolby před výběrem. Pokud úprava vrací `ShapeAdjustmentType::Custom`, považujte její význam a rozsah za specifické pro předvolbu a neměňte ji, dokud nebudete mít odpovídající smlouvu.

## **Vztah hodnot úprav ke geometrii spojníku**

U ohnutých spojníků lze hodnoty úprav použít k odhadu polohy jednotlivých segmentů. Výpočty jsou specifické pro předvolbu spojníku:

- `BentConnector4` obvykle poskytuje jednu úpravu `ConnectorBendPositionX` a jednu `ConnectorBendPositionY`.
- Pro tyto ohybové pozice dělením hodnoty vrácené `getRawValue` číslem `100000` získáte zlomek šířky nebo výšky rámce spojníku, jak je použito v níže uvedených příkladech.
- Rámec spojníku může být otočen nebo převrácen, takže souřadnice rámce je třeba transformovat před porovnáním se souřadnicemi snímku.

Následující příklady nejprve pomocí `getType` identifikují úpravy. Nepoužívají indexy kolekce jako přenositelné identifikátory.

### **Neotočený spojník**

Počáteční uspořádání obsahuje dva textové tvary spojené `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Tento příklad prozkoumá spojník a získá jeho vodorovné a svislé ohybové úpravy:

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

Pro změnu obou ohybů najděte každý očekávaný typ a upravte hodnoty až po jejich nalezení:

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

Výsledkem je spojník, jehož vodorovné i svislé segmenty se posunuly:

![connector-adjusted-1](connector-adjusted-1.png)

Jakmile jsou sémantické typy známy, jejich hodnoty lze převést na souřadnice rámce spojníku. Tento příklad nakreslí tenký obdélník přes svislý segment ovládaný dvěma ohybovými úpravami:

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

Pomocný tvar označuje vypočtený segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Otočený nebo převrácený spojník**

Když je stejná geometrii spojníku orientována svisle, hodnoty [Shape::getFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapeframe/getfliph/) a [ShapeFrame::getFlipV](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapeframe/getflipv/) ovlivňují převod ze souřadnic rámce spojníku na souřadnice snímku.

Tento příklad vytvoří a upraví svisle orientovaný spojník:

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

Upravený spojník se objeví svisle mezi tvary:

![connector-adjusted-3](connector-adjusted-3.png)

Pro libovolný úhel rotace `alpha` rotujte bod rámce spojníku `(x, y)` kolem středu rámce `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Následující kód řeší 90‑stupňovou orientaci použitou v tomto příkladu a nakreslí červený vodítko přes odpovídající segment spojníku:

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

Červené vodítko označuje vypočtený segment po transformaci souřadnic:

![connector-adjusted-4](connector-adjusted-4.png)

Tyto vzorce popisují předvolby použité v příkladech, nikoli univerzální model spojníku. Před použitím stejných výpočtů na jiné předvolby ověřte typy úprav, orientaci rámce a rozsahy hodnot.

## **Zjištění úhlu směru spojníku**

Směr rovného spojníku lze spočítat z jeho šířky a výšky, s uplatněním vodorovných a svislých převrácení. Následující příklad vypíše úhel po směru hodinových ručiček od kladné vodorovné osy ve souřadnicích snímku:

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

## **Často kladené otázky**

**Jak zjistím, zda se spojník může připojit k tvaru?**

Zkontrolujte hodnotu [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getconnectionsitecount/). Kladný počet znamená, že tvar poskytuje připojovací body. Před přiřazením ověřte vybraný index bodu.

**Mohu identifikovat úpravu spojníku podle indexu kolekce?**

Index má smysl jen pro známou předvolbu spojníku a rozložení kolekce. Před úpravou hodnoty zkontrolujte [AdjustValue::getType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/#gettype) a použijte [AdjustValue::getName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/adjustvalue/getname/) jako doplňující informaci, když se stejný sémantický typ vyskytuje vícekrát.

**Co se stane, když je připojený tvar smazán?**

Odpovídající konec spojníku se odpojí. Spojník zůstane na snímku a lze jej smazat, umístit jako volnou čáru nebo připojit k jinému tvaru.

**Zůstávají vazby spojníků zachovány při kopírování snímku?**

Vazby jsou obecně zachovány, pokud jsou při kopírování snímku zkopírovány i připojené tvary. Pokud je spojník zkopírován bez jednoho ze svých cílových tvarů, je třeba postižený konec znovu připojit.