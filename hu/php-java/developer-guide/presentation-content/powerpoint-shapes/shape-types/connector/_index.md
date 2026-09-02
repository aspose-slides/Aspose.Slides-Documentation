---
title: Csatlakozók kezelése prezentációkban PHP használatával
linktitle: Csatlakozó
type: docs
weight: 10
url: /hu/php-java/connector/
keywords:
- csatlakozó
- csatlakozó típus
- csatlakozó pont
- csatlakozó vonal
- csatlakozó szög
- csatlakozási pont
- állítási pont
- alakzatok összekapcsolása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá, csatlakoztathat, átirányíthat, állíthat és vizsgálhat egyenes, hajlított és görbe PowerPoint csatlakozókat az Aspose.Slides for PHP Java használatával."
---
## **Áttekintés**

Egy csatlakozó egy vonal, amely két alakzathoz is rögzítve maradhat, amikor bármelyik alakzat mozog. Végei kapcsolódnak a csatlakozási pontokhoz, amelyeket a PowerPoint zöld pontokként jelenít meg. Néhány ívelt és hajlított csatlakozó további állítási pontokat (narancssárga pontok) is mutat, amelyek az egyes csatlakozórészletek pozícióját szabályozzák.

Az Aspose.Slides a csatlakozókat a [Connector](https://reference.aspose.com/slides/hu/php-java/aspose.slides/connector/) osztállyal ábrázolja. Létrehozhatja őket, rögzítheti végeiket alakzatokhoz, kiválaszthatja a csatlakozási pontokat, átirányíthatja őket, és módosíthatja a csatlakozók geometriáját, ha azok állítási pontokkal rendelkeznek.

## **Csatlakozó típusok**

A [ShapeType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapetype/) osztály tartalmaz egyenes, hajlított és görbült csatlakozó előbeállításokat. Az alábbi táblázat mutatja a rendelkezésre álló csatlakozó geometriákat és az egyes előbeállításokhoz tartozó állítási pontok számát.

| Csatlakozó | Kép | Állítási pontok száma |
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

Az állítási pontok száma és jelentése a kiválasztott csatlakozó előbeállítás részét képezi. Ne feltételezze, hogy két különböző csatlakozó típus ugyanazt a gyűjteményelrendezést mutatja.

## **Két alakzat összekapcsolása**

Használja a [ShapeCollection::addConnector](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addconnector/) metódust egy csatlakozó hozzáadásához, majd a [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/connector/setstartshapeconnectedto/) és a [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/hu/php-java/aspose.slides/connector/setendshapeconnectedto/) metódusokat a végek rögzítéséhez. Miután mindkét vég csatlakoztatva van, a [Connector::reroute](https://reference.aspose.com/slides/hu/php-java/aspose.slides/connector/reroute/) egy rövid útvonalat választ a két alakzat között.

Az alábbi példa egy ellipszist és egy négyzetet kapcsol össze egy hajlított csatlakozóval:

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

{{% alert color="warning" title="Figyelmeztetés" %}}

A `reroute` meghívása megváltoztathatja a [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) és a [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/) értékeket. Ha a csatlakozási pontoknak rögzítve kell maradniuk, a átirányítás után rendelje hozzá a kívánt csatlakozási pontokat.

{{% /alert %}}

## **Csatlakozási pont kiválasztása**

Minden csatlakoztatható alakzat a [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getconnectionsitecount/) metódussal adja vissza a rendelkezésre álló pontok számát. Érvényesítse a kívánt, nullától indexelt pontot, mielőtt a csatlakozó végéhez rendeli; a pontok száma alakzat-geometriától függően változik.

Ez a példa egy adott ponthoz rögzíti a csatlakozót az ellipszisen, ha az a pont létezik:

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

## **Csatlakozó pont állítása**

Az állítási pontokkal rendelkező csatlakozók ezeket a [GeometryShape::getAdjustments](https://reference.aspose.com/slides/hu/php-java/aspose.slides/geometryshape/#getadjustments) metódussal teszik elérhetővé. Minden [AdjustValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/) esetén ellenőrizze a [AdjustValue::getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/#gettype) értékét, mielőtt a [AdjustValue::setRawValue](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/setrawvalue/) segítségével módosítaná. Az előbeállított alakzat-állítások azonosításának általános szabályait a [Shape Manipulation](/slides/hu/php-java/shape-manipulations/) fejezet tartalmazza.

Az állítások száma, sorrendje, jelentése és a megengedett értéktartomány a csatlakozó előbeállításától függ. Az állítás típusa csak olvasható, az érték írásra jogosult. A csak olvasható [AdjustValue::getName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/getname/) metódus további azonosítást nyújt, ha egy csatlakozó több azonos szemantikus típusú állítással rendelkezik.

### **Útvonal akadály körül**

Az alábbi elrendezésben egy `BentConnector5` csatlakozó két alakzat között egy harmadik alakzaton halad át:

![connector-obstruction](connector-obstruction.png)

Ez a kód létrehozza az akadályos csatlakozót:

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

A függőleges hajlítás mozgatása megváltoztatja az útvonalat, így a csatlakozó kikerüli az akadályt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Ahelyett, hogy azt feltételezné, hogy az `1` indexű elem mindig a függőleges hajlítás, ez a példa a `ConnectorBendPositionY` elemet keresi, és csak akkor módosítja, ha a várt szemantikus típus jelen van:

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

Egy `BentConnector5` két `ConnectorBendPositionX` és egy `ConnectorBendPositionY` állítással rendelkezik. Ha a szükséges típus többször fordul elő, vizsgálja meg a `getName` értéket és az előbeállítás ismert geometriáját, mielőtt kiválasztaná. Ha egy állítás `ShapeAdjustmentType::Custom` értéket ad vissza, tekintse jelentését és tartományát az adott előbeállítás specifikusnak, és ne változtassa meg, amíg a szerződés nem ismert.

## **Az állítási értékek összekapcsolása a csatlakozó geometriával**

Hajlított csatlakozók esetén az állítási értékek felhasználhatók az egyes szegmensek pozíciójának becslésére. Ezek a számítások a csatlakozó előbeállításra jellemzőek:

- `BentConnector4` általában egy `ConnectorBendPositionX` és egy `ConnectorBendPositionY` állítást tesz elérhetővé.
- Ezekhez a hajlítási pozíciókhoz a `getRawValue` által visszaadott értéket `100000`-val osztva kapjuk meg a csatlakozó keret szélességének vagy magasságának megfelelő törtet a lenti példákban.
- A csatlakozó kerete elfordítható vagy tükrözhető, így a keret koordinátáit át kell alakítani, mielőtt a diára vonatkozó koordinátákkal összehasonlítanánk.

Az alábbi példák először a `getType` használatával azonosítják az állításokat; nem tekintik a gyűjtemény indexét hordozható azonosítónak.

### **Nem elforgatott csatlakozó**

A kezdeti elrendezés két szöveges alakzattal tartalmaz egy `BentConnector4`-et:

![connector-shape-complex](connector-shape-complex.png)

Ez a példa megvizsgálja a csatlakozót, és lekéri a vízszintes és függőleges hajlítási állításokat:

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

A két hajlítás módosításához keresse meg a várt típusokat, és csak akkor változtassa meg az értékeket, ha mindkettőt megtalálta:

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

Az eredmény egy olyan csatlakozó, amelynek vízszintes és függőleges szegmensei elmozdultak:

![connector-adjusted-1](connector-adjusted-1.png)

Miután a szemantikus típusok ismertté válnak, értékeik átalakíthatók csatlakozó‑keret koordinátákká. Ez a példa egy vékony téglalapot rajzol a két hajlítás által vezérelt függőleges szegmens fölé:

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

Az útmutató alakzat jelöli a kiszámított szegmenst:

![connector-adjusted-2](connector-adjusted-2.png)

### **Elforgatott vagy tükrözött csatlakozó**

Amikor ugyanaz a csatlakozó geometria függőlegesen van elrendezve, a [Shape::getFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getframe/), a [ShapeFrame::getFlipH](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapeframe/getfliph/) és a [ShapeFrame::getFlipV](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapeframe/getflipv/) értékek befolyásolják a csatlakozó‑keret koordináták diára való átalakítását.

Ez a példa létrehozza és állítja a függőlegesen elrendezett csatlakozót:

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

Az állított csatlakozó függőlegesen jelenik meg az alakzatok között:

![connector-adjusted-3](connector-adjusted-3.png)

Tetszőleges `alpha` forgatási szög esetén a csatlakozó‑keret pont `(x, y)` elforgatható a keret középpontja `(x0, y0)` körül:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Az alábbi kód kezeli a példában használt 90‑fokos orientációt, és piros útmutatót rajzol a megfelelő csatlakozó szegmens fölé:

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

A piros útmutató a koordináta‑átalakítás után kiszámított szegmenst jelöli:

![connector-adjusted-4](connector-adjusted-4.png)

Ezek a képletek a példákban használt előbeállításokat írják le, nem egy univerzális csatlakozó modellt. Ellenőrizze az állítás típusát, a keret orientációját és az értéktartományokat, mielőtt ugyanazt a számítást más előbeállításra alkalmazná.

## **Csalózó csatlakozó irányszög meghatározása**

Egy egyenes csatlakozó irányát a szélesség és a magasság, valamint a vízszintes és függőleges tükrözés figyelembevételével számítható. Az alábbi példa a dián lévő koordinátákban a pozitív vízszintes tengelyhez képest óramutató járásával megegyező szöget adja vissza:

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

## **GYIK**

**Hogyan tudom megállapítani, hogy egy csatlakozó csatlakoztatható-e egy alakzathoz?**

Ellenőrizze a alakzat [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shape/getconnectionsitecount/) értékét. A pozitív szám azt jelenti, hogy az alakzat csatlakozási pontokat kínál. Az érvényesítés után rendelje hozzá a kiválasztott pont indexet a csatlakozó végéhez.

**Azonosíthatom-e a csatlakozó állítását a gyűjtemény indexe alapján?**

Az index csak akkor értelmezhető, ha a csatlakozó előbeállítása és gyűjteményelrendezése ismert. Módosítás előtt ellenőrizze a [AdjustValue::getType](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/#gettype) értékét, és ha ugyanaz a szemantikus típus többször előfordul, használja a [AdjustValue::getName](https://reference.aspose.com/slides/hu/php-java/aspose.slides/adjustvalue/getname/) metódust további információként.

**Mi történik, ha egy csatlakoztatott alakzatot törölnek?**

A megfelelő csatlakozó vége leválik. A csatlakozó a dián marad, és törölhető, szabad vonalként pozicionálható, vagy újra csatlakoztatható egy másik alakzathoz.

**Megmaradnak-e a csatlakozók kötései, ha egy diát másolnak?**

A kötések általában megmaradnak, ha a csatlakoztatott alakzatokkal együtt másolják a diát. Ha egy csatlakozót másolnak anélkül, hogy az egyik célnak megfelelő alakzatot is másolnák, az érintett végét újra kell csatlakoztatni.