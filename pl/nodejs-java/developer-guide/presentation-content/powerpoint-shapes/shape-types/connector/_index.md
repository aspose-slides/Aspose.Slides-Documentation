---
title: Zarządzanie łącznikami w prezentacjach przy użyciu JavaScript
linktitle: Łącznik
type: docs
weight: 10
url: /pl/nodejs-java/connector/
keywords:
- łącznik
- typ łącznika
- punkt łącznika
- linia łącznika
- kąt łącznika
- punkt połączenia
- punkt regulacji
- łączenie kształtów
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak dodawać, podłączać, zmieniać trasę, regulować i przeglądać proste, zgięte i zakrzywione łączniki PowerPoint przy użyciu Aspose.Slides dla Node.js w Javie."
---
## **Przegląd**

Łącznik jest linią, która może pozostać podłączona do dwóch kształtów, gdy którykolwiek z nich się przemieszcza. Jego końce przyczepiają się do punktów połączeń, reprezentowanych przez zielone kropki w programie PowerPoint. Niektóre zgięte i krzywe łączniki udostępniają także punkty regulacji, reprezentowane przez pomarańczowe kropki, które sterują położeniem poszczególnych segmentów łącznika.

Aspose.Slides reprezentuje łączniki za pomocą klasy [Connector](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/connector/). Można je tworzyć, podłączać ich końce do kształtów, wybierać punkty połączeń, zmieniać trasę oraz modyfikować geometrię łączników, które mają punkty regulacji.

## **Typy łączników**

Klasa [ShapeType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapetype/) zawiera predefiniowane łączniki prosty, zgięty i zakrzywiony. Poniższa tabela przedstawia dostępne geometrie łączników oraz liczbę punktów regulacji zdefiniowaną w każdym presecie.

| Łącznik | Image | Liczba punktów regulacji |
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

Liczba i znaczenie punktów regulacji są częścią wybranego predefiniowanego łącznika. Nie zakładaj, że dwa różne typy łączników udostępniają ten sam układ kolekcji.

## **Połącz dwa kształty**

Użyj [ShapeCollection.addConnector](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/addconnector/), aby dodać łącznik, oraz metod [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) i [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/connector/setendshapeconnectedto/), aby podłączyć jego końce. Po podłączeniu obu końcówek, metoda [Connector.reroute](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/connector/reroute/) wybiera krótką trasę między kształtami.

Poniższy przykład łączy elipsę i prostokąt przy użyciu zgiętego łącznika:

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

{{% alert color="warning" title="Ostrzeżenie" %}}
Wywołanie `reroute` może zmienić wartości [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) i [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/). Po zmianie trasy przydziel konkretne punkty połączeń, jeśli muszą pozostać stałe.
{{% /alert %}}

## **Wybierz punkt połączenia**

Każdy kształt, do którego można podłączyć łącznik, zgłasza liczbę dostępnych punktów połączeń za pomocą [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getconnectionsitecount/). Przed przypisaniem końcowi łącznika sprawdź wybrany indeks punktu (indeks zerowy). Liczba punktów zależy od geometrii kształtu.

Ten przykład podłącza łącznik do określonego punktu na elipsie, jeśli taki punkt istnieje:

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

## **Regulacja punktu łącznika**

Łączniki z punktami regulacji udostępniają je przez [GeometryShape.getAdjustments](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/geometryshape/). Przejrzyj każdy [AdjustValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/) i sprawdź jego wartość [getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/) przed zmianą przy użyciu [setRawValue](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/setrawvalue/). Ogólne zasady identyfikacji predefiniowanych regulacji kształtu opisano w [Manipulacja kształtem](/slides/pl/nodejs-java/shape-manipulations/).

Liczba, kolejność, znaczenie i dopuszczalny zakres wartości regulacji łącznika zależą od wybranego predefiniowanego łącznika. Typ regulacji jest tylko do odczytu, natomiast wartość można modyfikować. Metoda tylko do odczytu [getName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/getname/) zapewnia dodatkową identyfikację, gdy łącznik zawiera więcej niż jedną regulację tego samego typu semantycznego.

### **Omijanie przeszkody**

W poniższym układzie łącznik `BentConnector5` pomiędzy dwoma kształtami przechodzi przez trzeci kształt:

![connector-obstruction](connector-obstruction.png)

Ten kod tworzy łącznik z przeszkodą:

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

Przesunięcie pionowego zgięcia zmienia trasę tak, aby łącznik omijał przeszkodę:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Zamiast zakładać, że indeks kolekcji `1` zawsze oznacza pionowe zgięcie, ten przykład wyszukuje `ConnectorBendPositionY` i zmienia je tylko wtedy, gdy oczekiwany typ semantyczny jest obecny:

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

`BentConnector5` posiada dwa regulacje `ConnectorBendPositionX` i jedną `ConnectorBendPositionY`. Jeśli wymagany typ występuje wielokrotnie, sprawdź `getName` oraz znaną geometrię predefiniowanego łącznika przed wybraniem jednej z nich. Jeśli regulacja zwraca `ShapeAdjustmentType.Custom`, traktuj jej znaczenie i zakres jako specyficzne dla predefiniowanego łącznika i nie zmieniaj jej, dopóki nie będziesz znał odpowiedniej umowy.

## **Związek wartości regulacji z geometrią łącznika**

Dla zgiętych łączników wartości regulacji mogą być użyte do oszacowania położenia poszczególnych segmentów. Obliczenia te są specyficzne dla wybranego predefiniowanego łącznika:

- `BentConnector4` zazwyczaj udostępnia jedną regulację `ConnectorBendPositionX` oraz jedną `ConnectorBendPositionY`.
- Dla tych pozycji zgięcia, podzielenie wartości zwróconej przez `getRawValue` przez `100000` daje ułamek szerokości lub wysokości ramki łącznika używany w poniższych przykładach.
- Ramka łącznika może być obrócona lub odbita, więc współrzędne ramki muszą być przekształcone przed porównaniem z współrzędnymi slajdu.

Poniższe przykłady najpierw używają `getType`, aby zidentyfikować regulacje. Nie traktują indeksów kolekcji jako przenośnych identyfikatorów.

### **Nieobrócony łącznik**

Początkowy układ zawiera dwa kształty tekstowe połączone `BentConnector4`:

![connector-shape-complex](connector-shape-complex.png)

Ten przykład przegląda łącznik i pobiera jego regulacje zgięcia w poziomie i w pionie:

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

Aby zmienić oba zgięcia, znajdź każdy oczekiwany typ i zmodyfikuj wartości dopiero po odnalezieniu obu:

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

Wynikiem jest łącznik, którego segmenty poziomy i pionowy zostały przemieszone:

![connector-adjusted-1](connector-adjusted-1.png)

Gdy typy semantyczne są znane, ich wartości można przeliczyć na współrzędne ramki łącznika. Ten przykład rysuje cienki prostokąt nad pionowym segmentem kontrolowanym przez dwie regulacje zgięcia:

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

Kształt pomocniczy zaznacza obliczony segment:

![connector-adjusted-2](connector-adjusted-2.png)

### **Obrócony lub odbity łącznik**

Gdy ta sama geometria łącznika jest ustawiona pionowo, wartości [Shape.getFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapeframe/getfliph/) i [ShapeFrame.getFlipV](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapeframe/getflipv/) wpływają na konwersję współrzędnych ramki łącznika na współrzędne slajdu.

Ten przykład tworzy i reguluje pionowo ustawiony łącznik:

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

Dostosowany łącznik pojawia się pionowo pomiędzy kształtami:

![connector-adjusted-3](connector-adjusted-3.png)

Dla dowolnego kąta obrotu `alpha` obróć punkt ramki łącznika `(x, y)` wokół środka ramki `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Poniższy kod obsługuje orientację 90 stopni używaną w tym przykładzie i rysuje czerwony przewodnik nad odpowiednim segmentem łącznika:

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

Czerwony przewodnik zaznacza obliczony segment po transformacji współrzędnych:

![connector-adjusted-4](connector-adjusted-4.png)

Te wzory opisują predefiniowane łączniki użyte w przykładach, a nie uniwersalny model łącznika. Zweryfikuj typy regulacji, orientację ramki i zakresy wartości przed zastosowaniem tych samych obliczeń do innego predefiniowanego łącznika.

## **Znajdź kąt kierunkowy łącznika**

Kierunek prostego łącznika można obliczyć z jego szerokości i wysokości, uwzględniając poziome i pionowe odbicia. Poniższy przykład podaje kąt w stopniach (zgodnie z ruchem wskazówek zegara) względem dodatniej osi poziomej w układzie współrzędnych slajdu:

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

**Jak sprawdzić, czy łącznik może zostać podłączony do kształtu?**

Sprawdź wartość [getConnectionSiteCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getconnectionsitecount/) kształtu. Liczba dodatnia oznacza, że kształt udostępnia punkty połączeń. Zweryfikuj wybrany indeks punktu przed przypisaniem go do któregoś końca łącznika.

**Czy mogę identyfikować regulację łącznika po indeksie w kolekcji?**

Indeks ma sens tylko w kontekście znanego predefiniowanego łącznika i układu kolekcji. Przed zmianą wartości sprawdź [AdjustValue.getType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/), a jeśli ten sam typ semantyczny występuje wielokrotnie, użyj [AdjustValue.getName](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/adjustvalue/getname/) jako dodatkowej informacji.

**Co się dzieje, gdy podłączony kształt zostanie usunięty?**

Odpowiedni koniec łącznika zostaje odłączony. Łącznik pozostaje na slajdzie i może być usunięty, pozostawiony jako wolna linia lub podłączony do innego kształtu.

**Czy powiązania łączników są zachowywane przy kopiowaniu slajdu?**

Powiązania są zazwyczaj zachowywane, gdy kopiowane są razem z podłączonymi kształtami. Jeśli łącznik zostanie skopiowany bez jednego z docelowych kształtów, dotknięty koniec musi być ponownie podłączony.