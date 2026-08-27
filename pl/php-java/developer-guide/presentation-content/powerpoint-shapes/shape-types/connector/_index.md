---
title: Zarządzanie łącznikami w prezentacjach przy użyciu PHP
linktitle: Łącznik
type: docs
weight: 10
url: /pl/php-java/connector/
keywords:
- łącznik
- typ łącznika
- punkt łącznika
- linia łącznika
- kąt łącznika
- miejsce połączenia
- punkt regulacji
- łączenie kształtów
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak dodawać, przyłączać, zmieniać trasę, regulować i analizować proste, zgięte oraz zakrzywione łączniki PowerPoint przy użyciu Aspose.Slides dla PHP poprzez Java."
---
## **Przegląd**

Łącznik jest linią, która może pozostać przyłączona do dwóch kształtów, gdy którykolwiek z nich zostanie przesunięty. Jego końce przyłączają się do miejsc połączeń, przedstawionych jako zielone kropki w PowerPoint. Niektóre zgięte i zakrzywione łączniki udostępniają również punkty regulacji, oznaczone pomarańczowymi kropkami, które kontrolują pozycję poszczególnych segmentów łącznika.

Aspose.Slides reprezentuje łączniki za pomocą klasy [Connector](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/). Można je tworzyć, przyłączać ich końce do kształtów, wybierać miejsca połączeń, zmieniać trasę oraz modyfikować geometrię łączników posiadających punkty regulacji.

## **Typy łączników**

Klasa [ShapeType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapetype/) zawiera gotowe typy prostych, zgiętych i zakrzywionych łączników. Poniższa tabela prezentuje dostępne geometrie łączników oraz liczbę punktów regulacji zdefiniowaną dla każdego typu.

| Łącznik | Obraz | Liczba punktów regulacji |
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

Liczba i znaczenie punktów regulacji są częścią wybranego typu łącznika. Nie zakładaj, że dwa różne typy łączników udostępniają tę samą kolejność elementów w kolekcji.

## **Połączenie dwóch kształtów**

Użyj [ShapeCollection::addConnector](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addconnector/), aby dodać łącznik, a następnie [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/setstartshapeconnectedto/) oraz [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/setendshapeconnectedto/), aby przyłączyć jego końce. Po przyłączeniu obu końcówek, [Connector::reroute](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/reroute/) wybiera najkrótszą trasę między kształtami.

Poniższy przykład łączy elipsę i prostokąt za pomocą zgiętego łącznika:

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

{{% alert color="warning" title="Ostrzeżenie" %}}

Wywołanie `reroute` może zmienić wartości [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) oraz [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/pl/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Przypisz konkretne miejsca połączeń po zmianie trasy, jeśli muszą pozostać stałe.

{{% /alert %}}

## **Wybór miejsca połączenia**

Każdy łączny kształt raportuje liczbę dostępnych miejsc poprzez [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getconnectionsitecount/). Zweryfikuj żądany indeks miejsca (zero‑based) przed przypisaniem go do końca łącznika; liczba miejsc różni się w zależności od geometrii kształtu.

Ten przykład przyłącza łącznik do określonego miejsca na elipsie, jeśli takie miejsce istnieje:

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

## **Regulacja punktu łącznika**

Łączniki posiadające punkty regulacji udostępniają je przez [GeometryShape::getAdjustments](https://reference.aspose.com/slides/pl/php-java/aspose.slides/geometryshape/#getadjustments). Zbadaj każdy [AdjustValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/) i sprawdź jego wartość [AdjustValue::getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/#gettype) przed zmianą przy użyciu [AdjustValue::setRawValue](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/setrawvalue/). Ogólne zasady identyfikacji regulacji predefiniowanych kształtów opisano w [Manipulacji kształtem](/slides/pl/php-java/shape-manipulations/).

Liczba, kolejność, znaczenie oraz dopuszczalny zakres wartości regulacji łącznika zależą od wybranego typu łącznika. Typ regulacji jest tylko do odczytu, natomiast jego wartość można modyfikować. Metoda tylko do odczytu [AdjustValue::getName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/getname/) dostarcza dodatkowej identyfikacji, gdy łącznik zawiera więcej niż jedną regulację tego samego typu semantycznego.

### **Omijanie przeszkody**

W poniższym układzie łącznik `BentConnector5` między dwoma kształtami przechodzi przez trzeci kształt:

![connector-obstruction](connector-obstruction.png)

Ten kod tworzy łącznik z przeszkodą:

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

Przesunięcie pionowego zgięcia zmienia trasę tak, aby łącznik omijał przeszkodę:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Zamiast zakładać, że indeks kolekcji `1` zawsze reprezentuje pionowe zgięcie, ten przykład wyszukuje `ConnectorBendPositionY` i zmienia je tylko wtedy, gdy oczekiwany typ semantyczny jest obecny:

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

`BentConnector5` posiada dwa regulacje `ConnectorBendPositionX` i jedną regulację `ConnectorBendPositionY`. Jeśli potrzebny typ występuje więcej niż raz, zbadaj `getName` oraz znaną geometrię tego typu przed wybraniem konkretnej regulacji. Gdy regulacja zwraca `ShapeAdjustmentType::Custom`, traktuj jej znaczenie i zakres jako specyficzne dla wybranego typu i nie zmieniaj jej, dopóki nie zostanie określona umowa.

## **Powiązanie wartości regulacji z geometrią łącznika**

W przypadku zgiętych łączników wartości regulacji mogą być używane do przybliżonego określenia pozycji poszczególnych segmentów. Obliczenia te są specyficzne dla konkretnego typu łącznika:

- `BentConnector4` zazwyczaj udostępnia po jednej regulacji `ConnectorBendPositionX` i `ConnectorBendPositionY`.
- Dla tych pozycji zgięcia, podzielenie wartości zwróconej przez `getRawValue` przez `100000` daje ułamek szerokości lub wysokości ramki łącznika, używany w poniższych przykładach.
- Ramka łącznika może być obrócona lub odbita, więc współrzędne ramki muszą być przekształcone przed porównaniem z współrzędnymi slajdu.

Poniższe przykłady najpierw używają `getType`, aby zidentyfikować regulacje. Nie traktują indeksów kolekcji jako przenośnych identyfikatorów.

### **Nieobrócony łącznik**

Początkowy układ zawiera dwa kształty tekstowe połączone `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Ten przykład bada łącznik i pobiera jego regulacje poziomego i pionowego zgięcia:

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

Aby zmienić oba zgięcia, znajdź każdy oczekiwany typ i modyfikuj wartości dopiero po odnalezieniu obu:

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

Wynikiem jest łącznik, którego segmenty poziome i pionowe zostały przesunięte:

![connector-adjusted-1](connector-adjusted-1.png)

Gdy typy semantyczne są znane, ich wartości można przeliczyć na współrzędne ramki łącznika. Ten przykład rysuje cienki prostokąt nad pionowym segmentem kontrolowanym przez dwie regulacje zgięcia:

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

Kształt prowadzący oznacza obliczony segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Obrócony lub odbity łącznik**

Gdy ta sama geometria łącznika jest ustawiona pionowo, wartości [Shape::getFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapeframe/getfliph/), oraz [ShapeFrame::getFlipV](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapeframe/getflipv/) wpływają na konwersję współrzędnych ramki łącznika na współrzędne slajdu.

Ten przykład tworzy i reguluje pionowo ustawiony łącznik:

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

Regulowany łącznik pojawia się pionowo między kształtami:

![connector-adjusted-3](connector-adjusted-3.png)

Dla dowolnego kąta obrotu `alpha`, obróć punkt ramki łącznika `(x, y)` wokół środka ramki `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Poniższy kod obsługuje 90‑stopniową orientację używaną w tym przykładzie i rysuje czerwony prowadnik nad odpowiednim segmentem łącznika:

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

Czerwony prowadnik oznacza obliczony segment po przekształceniu współrzędnych:

![connector-adjusted-4](connector-adjusted-4.png)

Te wzory opisują preset używany w przykładach, a nie uniwersalny model łącznika. Zweryfikuj typy regulacji, orientację ramki oraz zakresy wartości przed zastosowaniem tych samych obliczeń do innego typu.

## **Obliczanie kąta kierunku łącznika**

Kierunek prostego łącznika można obliczyć na podstawie jego szerokości i wysokości, uwzględniając poziome i pionowe odbicia. Poniższy przykład podaje kąt w stopniach, liczony zgodnie z ruchem wskazówek zegara od dodatniej osi poziomej w współrzędnych slajdu:

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

**Jak mogę sprawdzić, czy łącznik może być przyłączony do kształtu?**

Sprawdź wartość [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getconnectionsitecount/). Dodatnia liczba oznacza, że kształt udostępnia miejsca połączeń. Zweryfikuj wybrany indeks miejsca przed przypisaniem go do któregoś końca łącznika.

**Czy mogę zidentyfikować regulację łącznika po jej indeksie w kolekcji?**

Indeks ma sens tylko w kontekście znanego typu łącznika i układu kolekcji. Sprawdź [AdjustValue::getType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/#gettype) przed modyfikacją wartości i użyj [AdjustValue::getName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/adjustvalue/getname/) jako dodatkowej informacji, gdy ten sam typ semantyczny występuje wielokrotnie.

**Co się dzieje, gdy połączony kształt zostanie usunięty?**

Odpowiedni koniec łącznika zostaje odłączony. Łącznik pozostaje na slajdzie i może być usunięty, przekształcony w wolną linię lub przyłączony do innego kształtu.

**Czy powiązania łączników są zachowywane przy kopiowaniu slajdu?**

Powiązania są zazwyczaj zachowywane, gdy połączone kształty są kopiowane razem ze slajdem. Jeśli łącznik zostanie skopiowany bez jednego z docelowych kształtów, odpowiedni koniec musi zostać ponownie przyłączony.