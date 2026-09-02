---
title: Csatlakozók kezelése prezentációkban JavaScript használatával
linktitle: Csatlakozó
type: docs
weight: 10
url: /hu/nodejs-java/connector/
keywords:
- csatlakozó
- csatlakozó típus
- csatlakozó pont
- csatlakozó vonal
- csatlakozó szög
- kapcsolódási hely
- állítási pont
- alakzatok összekapcsolása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá, csatlakoztasson, újrarajzoljon, állítson be és vizsgálja meg a egyenes, hajlított és ívelt PowerPoint csatlakozókat az Aspose.Slides Node.js számára Java segítségével."
---
## **Áttekintés**

A csatlakozó egy vonal, amely két alakzathoz is rögzítve maradhat, ha bármelyik alakzat mozog. Végződései kapcsolódási pontokhoz kapcsolódnak, amelyeket a PowerPoint zöld pontokkal jelöl. Néhány hajlított és ívelt csatlakozó narancssárga pontokkal jelölt szabályozási pontokat is tartalmaz, amelyek az egyes csatlakozó szakaszok pozícióját vezérlik.

Az Aspose.Slides a csatlakozókat a [Connector](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/) osztállyal reprezentálja. Létrehozhatja őket, csatlakoztathatja a végeiket alakzatokhoz, választhat kapcsolódási pontokat, újrarajzolhatja őket, és módosíthatja azok geometriáját, ha beállítási pontokkal rendelkeznek.

## **Csatlakozó Típusok**

A [ShapeType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapetype/) osztály tartalmaz egyenes, hajlított és ívelt csatlakozó előbeállításokat. Az alábbi táblázat mutatja a rendelkezésre álló csatlakozó geometriákat és az egyes előbeállítások által definiált beállítási pontok számát.

| Csatlakozó | Kép | Beállítási pontok száma |
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

A beállítási pontok száma és jelentése az adott csatlakozó előbeállítás része. Ne tételezze, hogy két különböző csatlakozó típus ugyanazt a gyűjteményelrendezést mutatja.

## **Két Alakzat Összekapcsolása**

Használja a [ShapeCollection.addConnector](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/addconnector/) metódust csatlakozó hozzáadásához, és a [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) illetve a [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) metódusokat a végek csatlakoztatásához. Miután mindkét vég csatlakoztatva van, a [Connector.reroute](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/reroute/) rövid útvonalat választ a alakzatok között.

Az alábbi példa egy ellipszist és egy téglalapot köt össze egy hajlított csatlakozóval:

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
A `reroute` meghívása megváltoztathatja a [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) és a [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/) értékeket. A újrarajzolás után rendelje hozzá a konkrét kapcsolódási pontokat, ha azoknak rögzítve kell maradniuk.
{{% /alert %}}

## **Kapcsolódási Pont Kiválasztása**

Minden csatlakoztatható alakzat a [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getconnectionsitecount/) metódussal jelzi a kapcsolódási pontok számát. Érvényesítse a kívánt, nullától számított pont indexet, mielőtt a csatlakozó végéhez rendeli; a pontok száma alakzatonként különbözik.

Ez a példa a csatlakozót egy adott ponthoz csatlakoztatja az ellipszisen, ha az a pont létezik:

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

## **Csatlakozó Pont Módosítása**

A beállítási pontokkal rendelkező csatlakozók ezeket a [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/geometryshape/) metódussal teszik elérhetővé. Vizsgálja meg minden [AdjustValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/) elemet, és ellenőrizze a [getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/) értékét, mielőtt a [setRawValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/setrawvalue/)‑vel módosítaná. Az előbeállított alakzat beállítások azonosításának általános szabályait a [Shape Manipulation](/slides/hu/nodejs-java/shape-manipulations/) részben ismertetik.

A csatlakozó beállítási pontok száma, sorrendje, jelentése és érvényes értéktartománya az adott csatlakozó előbeállítástól függ. A beállítás típusa csak olvasható, míg az értéke írható. A csak olvasható [getName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/getname/) metódus további azonosítást nyújt, ha egy csatlakozó több azonos szemantikai típussal rendelkező beállítást tartalmaz.

### **Útvonal Egy Akadály Között**

Az alábbi elrendezésben egy `BentConnector5` csatlakozó két alakzat között egy harmadik alakzaton át halad:

![connector-obstruction](connector-obstruction.png)

Ez a kód hozza létre az akadályos csatlakozót:

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

A függőleges hajlítás mozgatásával megváltozik az útvonal, így a csatlakozó megkerüli az akadályt:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Ahelyett, hogy feltételezné, hogy az `1` index mindig a függőleges hajlítást jelenti, ez a példa a `ConnectorBendPositionY`‑t keresi, és csak akkor módosítja, ha a várt szemantikai típus jelen van:

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

Egy `BentConnector5` két `ConnectorBendPositionX` és egy `ConnectorBendPositionY` beállítással rendelkezik. Ha a szükséges típus többször is előfordul, vizsgálja meg a `getName`‑et és az adott előbeállítás ismert geometriáját, mielőtt kiválasztana egyet. Ha egy beállítás `ShapeAdjustmentType.Custom`‑ként jelez, tekintse jelentését és tartományát az adott előbeállításra jellemzőnek, és ne módosítsa, amíg a szerződés nincs tisztázva.

## **A Beállítási Értékek Összefüggése a Csatlakozó Geometriával**

Hajlított csatlakozók esetén a beállítási értékek felhasználhatók az egyes szakaszok pozíciójának becslésére. Ezek a számítások a csatlakozó előbeállításhoz kötöttek:

- `BentConnector4` általában egy `ConnectorBendPositionX` és egy `ConnectorBendPositionY` beállítást tesz elérhetővé.
- Ezeknél a hajlítási pozícióknál az `getRawValue` által visszaadott érték `100000`‑al való osztása adja a csatlakozó keret szélességének vagy magasságának hányadát az alábbi példákban.
- A csatlakozó keret elforgatható vagy tükrözhető, ezért a keret koordinátákat át kell alakítani, mielőtt a dián lévő koordinátákkal összehasonlítjuk őket.

Az alábbi példák először a `getType`‑ot használják a beállítások azonosításához, és nem tekintik a gyűjtemény indexeket hordozható azonosítóknak.

### **Forgatás Nélküli Csatlakozó**

A kezdeti elrendezés két szöveges alakzatot kapcsol össze egy `BentConnector4`‑rel:

![connector-shape-complex](connector-shape-complex.png)

Ez a példa megvizsgálja a csatlakozót, és lekéri a vízszintes és függőleges hajlítási beállításokat:

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

A két hajlítás módosításához keresse meg a várt típust, és csak akkor változtassa meg az értékeket, amikor mindkettőt megtalálta:

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

Az eredmény egy olyan csatlakozó, amelynek vízszintes és függőleges szegmensei elmozdultak:

![connector-adjusted-1](connector-adjusted-1.png)

Miután a szemantikai típusok ismertté váltak, azok értékei átalakíthatók a csatlakozó-keret koordinátáivá. Ez a példa egy vékony téglalapot rajzol a két hajlítási beállítás által vezérelt függőleges szegmensre:

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

Az irányító alakzat jelzi a számított szegmenst:

![connector-adjusted-2](connector-adjusted-2.png)

### **Forgatott vagy Tükrözött Csatlakozó**

Amikor ugyanaz a csatlakozó geometria függőlegesen helyezkedik el, a [Shape.getFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getframe/), a [ShapeFrame.getFlipH](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapeframe/getfliph/), valamint a [ShapeFrame.getFlipV](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapeframe/getflipv/) értékek befolyásolják a csatlakozó-keret koordináták diára történő átalakítását.

Ez a példa létrehozza és módosítja a függőlegesen orientált csatlakozót:

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

A módosított csatlakozó függőlegesen jelenik meg az alakzatok között:

![connector-adjusted-3](connector-adjusted-3.png)

Tetszőleges `alpha` forgatási szög esetén a csatlakozó‑keret pont `(x, y)` a keret középpontja `(x0, y0)` körül a következőképpen forgatható:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Az alábbi kód kezeli a példában használt 90°‑os orientációt, és piros irányítót rajzol a megfelelő csatlakozó szegmensre:

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

A piros irányító a koordinátatranszformáció után jelzi a számított szegmenst:

![connector-adjusted-4](connector-adjusted-4.png)

Ezek a képletek a példákban használt előbeállításokat írják le, nem egy általános csatlakozó modellt. Ellenőrizze a beállítási típusokat, a keret orientációját és az értéktartományokat, mielőtt ugyanazt a számítást más előbeállításra alkalmazná.

## **Csatlakozó Irány Szög Megtalálása**

Egy egyenes csatlakozó iránya a szélesség és magasság alapján számítható ki, figyelembe véve a vízszintes és függőleges tükrözéseket. Az alábbi példa a dián lévő koordinátákban az óramutató járásával megegyező szöget adja meg:

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

## **GYIK**

**Hogyan tudom megállapítani, hogy egy csatlakozó csatlakoztatható-e egy alakzathoz?**

Ellenőrizze az alakzat [getConnectionSiteCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/getconnectionsitecount/) értékét. A pozitív szám azt jelzi, hogy az alakzat rendelkezik kapcsolódási pontokkal. Érvényesítse a kiválasztott pont indexet, mielőtt bármelyik csatlakozó végéhez rendeli.

**Azonosíthatom-e egy csatlakozó beállítását a gyűjtemény indexe alapján?**

Az index csak egy ismert csatlakozó előbeállítás és gyűjteményelrendezés esetén értelmezhető. Módosítás előtt ellenőrizze a [AdjustValue.getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/) értékét, és ha ugyanaz a szemantikai típus többször is előfordul, használja a [AdjustValue.getName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/adjustvalue/getname/)‑t további információként.

**Mi történik, ha egy kapcsolt alakzatot törölnek?**

Az érintett csatlakozó vége leválik. A csatlakozó a dián marad, törölhető, szabad vonalként pozicionálható, vagy egy másik alakzathoz csatlakoztatható.

**Megmaradnak-e a csatlakozó kötések, ha egy dia másolódik?**

A kötéseket általában megőrzik, ha a kapcsolt alakzatokkal együtt másolják a diát. Ha egy csatlakozót másolnak anélkül, hogy a célalakzata egyike is másolva lenne, a érintett véget újra csatlakoztatni kell.