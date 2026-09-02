---
title: JavaScript を使用したプレゼンテーションのコネクタ管理
linktitle: コネクタ
type: docs
weight: 10
url: /ja/nodejs-java/connector/
keywords:
- コネクタ
- コネクタ タイプ
- コネクタ ポイント
- コネクタ ライン
- コネクタ 角度
- 接続サイト
- 調整ポイント
- シェイプの接続
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、ストレート、ベンド、カーブした PowerPoint コネクタの追加、接続、再ルーティング、調整、検査方法を学びます。"
---
## **概要**

コネクタは、いずれかのシェイプが移動しても 2 つのシェイプに接続されたままにできる線です。その端は、PowerPoint で緑の点で表される接続サイトに接続されます。曲がったりカーブしたりするコネクタの一部は、オレンジの点で表される調整ポイントも公開しており、個々のコネクタ セグメントの位置を制御します。

Aspose.Slides は、[Connector](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/connector/) クラスを使用してコネクタを表します。コネクタを作成し、端をシェイプに接続し、接続サイトを選択し、再ルーティングし、調整ポイントを持つコネクタのジオメトリを変更できます。

## **コネクタの種類**

[ShapeType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapetype/) クラスには、直線、曲がり、曲線コネクタのプリセットが含まれます。以下の表は、利用可能なコネクタジオメトリと各プリセットで定義された調整ポイント数を示しています。

| コネクタ | 画像 | 調整ポイント数 |
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

調整ポイントの数と意味は、選択されたコネクタプリセットの一部です。異なるコネクタタイプが同じコレクションレイアウトを公開すると想定しないでください。

## **2 つのシェイプを接続する**

[ShapeCollection.addConnector](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/addconnector/) を使用してコネクタを追加し、[Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) と [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) を使用して端を接続します。両端が接続された後、[Connector.reroute](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/connector/reroute/) はシェイプ間の最短経路を選択します。

次の例は、楕円と長方形を曲がったコネクタで接続します。

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
`reroute` を呼び出すと、[setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) および [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/) の値が変更される可能性があります。これらのサイトを固定したままにする必要がある場合は、再ルーティング後に特定の接続サイトを割り当ててください。
{{% /alert %}}

## **接続サイトを選択する**

接続可能な各シェイプは、[Shape.getConnectionSiteCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getconnectionsitecount/) を介してサイト数を報告します。コネクタの端に割り当てる前に、希望のゼロベースのサイトインデックスを検証してください。サイト数はシェイプのジオメトリにより異なります。

この例は、該当するサイトが存在する場合に、楕円の特定のサイトにコネクタを接続します。

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

## **コネクタポイントを調整する**

調整ポイントを持つコネクタは、[GeometryShape.getAdjustments](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/geometryshape/) を通じてそれらを公開します。各 [AdjustValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/) を検査し、[setRawValue](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) で変更する前にその [getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/) の値を確認してください。プリセットシェイプの調整を識別する一般的な規則は、[Shape Manipulation](/slides/ja/nodejs-java/shape-manipulations/) に記載されています。

コネクタ調整の数、順序、意味、および有効な値範囲は、コネクタプリセットに依存します。調整タイプは読み取り専用で、調整値は書き込み可能です。読み取り専用の [getName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/getname/) メソッドは、同一の意味タイプが複数ある場合に追加の識別情報を提供します。

### **障害物を回避する**

以下のレイアウトでは、2 つのシェイプ間の `BentConnector5` コネクタが 3 番目のシェイプを通過しています。

![connector-obstruction](connector-obstruction.png)

このコードは障害物があるコネクタを作成します。

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

垂直方向の曲げを移動すると、コネクタが障害物を回避するように経路が変更されます。

![connector-obstruction-fixed](connector-obstruction-fixed.png)

コレクションインデックス `1` が常に垂直方向の曲げを表すと想定する代わりに、この例は `ConnectorBendPositionY` を検索し、期待される意味タイプが存在する場合にのみ変更します。

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

`BentConnector5` には 2 つの `ConnectorBendPositionX` 調整と 1 つの `ConnectorBendPositionY` 調整があります。必要なタイプが複数回出現する場合は、`getName` とそのプリセットの既知のジオメトリを確認してから選択してください。調整が `ShapeAdjustmentType.Custom` を返す場合、その意味と範囲はプリセット固有とみなし、契約が明らかになるまで変更しないでください。

## **調整値とコネクタジオメトリの関連付け**

曲がったコネクタの場合、調整値は個々のセグメントの位置を推定するために使用できます。これらの計算はコネクタプリセット固有です：

- `BentConnector4` は通常、1 つの `ConnectorBendPositionX` と 1 つの `ConnectorBendPositionY` 調整を公開します。
- これらの曲げ位置については、`getRawValue` が返す値を `100000` で除算すると、以下の例で使用されるコネクタフレームの幅または高さの比率が得られます。
- コネクタフレームは回転または反転できるため、フレーム座標はスライド座標と比較する前に変換する必要があります。

以下の例は最初に `getType` を使用して調整を識別します。コレクションインデックスは搬送可能な識別子として扱いません。

### **回転していないコネクタ**

初期レイアウトには、`BentConnector4` で接続された 2 つのテキストシェイプが含まれています：

![connector-shape-complex](connector-shape-complex.png)

この例はコネクタを検査し、水平および垂直の曲げ調整を取得します。

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

両方の曲げを変更するには、期待されるタイプをそれぞれ見つけ、両方が見つかった後にのみ値を変更します。

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

結果として、水平および垂直セグメントが移動したコネクタが得られます：

![connector-adjusted-1](connector-adjusted-1.png)

意味タイプが判明したら、その値はコネクタフレーム座標に変換できます。この例は、2 つの曲げ調整で制御される垂直セグメント上に細い長方形を描画します。

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

ガイドシェイプは計算されたセグメントを示します：

![connector-adjusted-2](connector-adjusted-2.png)

### **回転または反転されたコネクタ**

同じコネクタジオメトリが垂直に配置される場合、[Shape.getFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getframe/)、[ShapeFrame.getFlipH](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapeframe/getfliph/)、および [ShapeFrame.getFlipV](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapeframe/getflipv/) の値は、コネクタフレーム座標からスライド座標への変換に影響します。

この例は垂直に配置されたコネクタを作成し、調整します。

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

調整されたコネクタはシェイプ間に垂直に表示されます：

![connector-adjusted-3](connector-adjusted-3.png)

任意の回転角 `alpha` に対して、コネクタフレームの点 `(x, y)` をフレーム中心 `(x0, y0)` の周りで回転させます：

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下のコードはこの例で使用される 90 度の向きに対応し、対応するコネクタセグメント上に赤いガイドを描画します。

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

赤いガイドは座標変換後の計算されたセグメントを示します：

![connector-adjusted-4](connector-adjusted-4.png)

これらの式は例で使用されるプリセットを説明したものであり、汎用的なコネクタモデルではありません。別のプリセットに同じ計算を適用する前に、調整タイプ、フレームの向き、値の範囲を検証してください。

## **コネクタの方向角度を求める**

直線コネクタの方向は、幅と高さから、水平・垂直反転を考慮して計算できます。以下の例は、スライド座標系で正の水平軸から時計回りの角度を報告します：

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

**コネクタがシェイプに接続できるかどうかを判別するにはどうすればよいですか？**

シェイプの [getConnectionSiteCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/getconnectionsitecount/) の値を確認してください。正のカウントはシェイプが接続サイトを公開していることを意味します。接続サイトインデックスをコネクタのどちらかの端に割り当てる前に、選択したサイトインデックスを検証してください。

**コレクションインデックスでコネクタの調整を識別できますか？**

インデックスは、既知のコネクタプリセットとコレクションレイアウトに対してのみ意味があります。値を変更する前に [AdjustValue.getType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/) を確認し、同一の意味タイプが複数存在する場合は追加情報として [AdjustValue.getName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/adjustvalue/getname/) を使用してください。

**接続されたシェイプが削除された場合はどうなりますか？**

対応するコネクタの端は切り離されます。コネクタはスライド上に残り、削除したり、自由な線として配置したり、別のシェイプに再接続したりできます。

**スライドをコピーしたとき、コネクタのバインディングは保持されますか？**

接続されたシェイプがスライドとともにコピーされる場合、バインディングは通常保持されます。コネクタが対象シェイプのいずれかなしでコピーされた場合、影響を受けた端を再度接続する必要があります。