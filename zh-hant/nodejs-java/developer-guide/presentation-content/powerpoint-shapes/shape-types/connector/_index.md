---
title: 使用 JavaScript 管理簡報中的連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/nodejs-java/connector/
keywords:
- 連接線
- 連接線類型
- 連接點
- 連接線段
- 連接角度
- 連接位置
- 調整點
- 連接圖形
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js 透過 Java 來新增、附加、重新路由、調整以及檢查 PowerPoint 中的直線、彎曲和曲線連接線。"
---
## **概覽**

連接線是一條在任一圖形移動時仍可保持附著於兩個圖形的線。它的兩端會連接到連接點，在 PowerPoint 中以綠點表示。某些彎曲和曲線連接線也會顯示調整點，以橙點表示，用來控制個別連接線段的位置。

Aspose.Slides 透過 [Connector](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/connector/) 類別來表示連接線。您可以建立連接線、將其兩端附加到圖形、選擇連接點、重新路由，並修改具有調整點的連接線的幾何形狀。

## **連接線類型**

[ShapeType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapetype/) 類別包含直線、彎曲和曲線連接線的預設樣式。下表顯示可用的連接線幾何形狀以及每種預設所定義的調整點數量。

| 連接線 | 圖片 | 調整點數量 |
|---|---|---|
| `ShapeType.Line` | ![直線連接線](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![StraightConnector1 直線連接線](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![BentConnector2 彎曲連接線](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![BentConnector3 彎曲連接線](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![BentConnector4 彎曲連接線](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![BentConnector5 彎曲連接線](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![CurvedConnector2 曲線連接線](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![CurvedConnector3 曲線連接線](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![CurvedConnector4 曲線連接線](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![CurvedConnector5 曲線連接線](shapetype.curvedconnector5.png) | 3 |

調整點的數量與意義屬於所選的連接線預設。不要假設兩種不同的連接線類型會公開相同的集合佈局。

## **連接兩個圖形**

使用 [ShapeCollection.addConnector](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/addconnector/) 新增連接線，並使用 [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) 與 [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) 來附加兩端。兩端皆附加完成後，[Connector.reroute](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/connector/reroute/) 會在圖形之間選擇最短路徑。

以下範例使用彎曲連接線將橢圓與矩形連接起來：

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
呼叫 `reroute` 可能會變更 [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) 與 [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/) 的值。若這些連接點必須保持固定，請在重新路由後再指派特定的連接點。
{{% /alert %}}

## **選擇連接點**

每個可連接的圖形會透過 [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getconnectionsitecount/) 回傳其連接點數量。將首選的零基索引指定給連接線端點前，務必先驗證索引是否在範圍內；不同圖形的連接點數量會因幾何形狀而異。

以下範例在橢圓上存在特定連接點時，將連接線附加到該點：

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

## **調整連接線點**

具有調整點的連接線會透過 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/geometryshape/) 暴露這些點。檢查每個 [AdjustValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/) 並於變更前先呼叫 [getType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/) 取得類型，再使用 [setRawValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) 變更值。關於辨識預設圖形調整的通用規則，請參考 [Shape Manipulation](/slides/zh-hant/nodejs-java/shape-manipulations/)。

調整點的數量、順序、意義與有效值範圍皆取決於連接線的預設。調整類型為唯讀，調整值則可寫入。唯讀的 [getName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/getname/) 方法在同一語意類型出現多次時提供額外辨識資訊。

### **繞過障礙物的路徑**

下圖顯示一條 `BentConnector5` 連接線在兩個圖形之間穿過第三個圖形：

![connector-obstruction](connector-obstruction.png)

以下程式碼建立了受阻的連接線：

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

將垂直彎曲點移動後，路徑會改為繞過障礙物：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

此範例不假設集合索引 `1` 必定代表垂直彎曲點，而是搜尋 `ConnectorBendPositionY`，僅在語意類型符合預期時才變更：

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

`BentConnector5` 具有兩個 `ConnectorBendPositionX` 調整與一個 `ConnectorBendPositionY` 調整。若所需的類型出現多次，請先檢查 `getName` 以及該預設的已知幾何形狀後再選取。若調整回傳 `ShapeAdjustmentType.Custom`，則其意義與範圍屬於特定預設，請在瞭解相關合約前勿更改。

## **將調整值與連接線幾何關聯**

對於彎曲連接線，調整值可用來估計各段的座標。以下計算僅適用於特定連接線預設：

- `BentConnector4` 通常會公開一個 `ConnectorBendPositionX` 與一個 `ConnectorBendPositionY` 調整。
- 取 `getRawValue` 後除以 `100000`，即可得到相對於連接線框寬度或高度的比例，以下範例即使用此方式。
- 連接線框可能已旋轉或翻轉，故在比較與投影片座標前必須先轉換框座標。

以下範例先以 `getType` 辨識調整點，絕不以集合索引作為可移植的識別方式。

### **未旋轉的連接線**

初始版面配置包含兩個文字圖形，由一條 `BentConnector4` 連接：

![connector-shape-complex](connector-shape-complex.png)

此範例檢查連接線並取得水平與垂直彎曲的調整值：

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

若要同時變更兩個彎曲點，先找出每個預期的類型，確認兩者皆已找到後再修改值：

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

結果是一條水平與垂直段皆已移動的連接線：

![connector-adjusted-1](connector-adjusted-1.png)

一旦確認語意類型，即可將其值轉換為連接線框座標。以下範例在由兩個彎曲調整所控制的垂直段上繪製一個細長矩形：

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

輔助圖形標示出計算後的段落：

![connector-adjusted-2](connector-adjusted-2.png)

### **旋轉或翻轉的連接線**

當相同的連接線幾何以垂直方向呈現時，其 [Shape.getFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getframe/)、[ShapeFrame.getFlipH](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapeframe/getfliph/)、[ShapeFrame.getFlipV](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapeframe/getflipv/) 會影響從連接線框座標到投影片座標的轉換。

此範例建立並調整垂直方向的連接線：

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

調整後的連接線會垂直位於兩個圖形之間：

![connector-adjusted-3](connector-adjusted-3.png)

對於任意旋轉角度 `alpha`，可將框座標點 `(x, y)` 以框中心 `(x0, y0)` 為中心旋轉：

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

以下程式碼處理本範例使用的 90 度方向，並在相應的連接線段上繪製紅色輔助線：

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

紅色輔助線在座標轉換後標示出計算出的段落：

![connector-adjusted-4](connector-adjusted-4.png)

上述公式說明的是範例中使用的預設，並非通用的連接線模型。請在將相同計算套用至其他預設前，先驗證調整類型、框方向與值範圍。

## **找出連接線方向角度**

可根據直線連接線的寬度與高度（同時考慮水平與垂直翻轉）計算其方向。以下範例回報在投影片座標系統中，以正水平軸為基準的順時針角度：

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

## **常見問題**

**如何判斷連接線是否能附著於圖形？**

檢查圖形的 [getConnectionSiteCount](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getconnectionsitecount/) 值。正值表示圖形提供連接點。指派給任一連接線端點前，務必先驗證所選的點索引。

**我可以透過集合索引辨識連接線調整嗎？**

索引僅在已知的連接線預設與集合佈局下才具意義。變更值前請先檢查 [AdjustValue.getType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/)，若同一語意類型出現多次，請使用 [AdjustValue.getName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/getname/) 取得額外資訊。

**當被連接的圖形被刪除時會發生什麼事？**

相應的連接線端點會變為未附著狀態。連接線仍保留在投影片上，您可以刪除它、將其作為自由線定位，或重新附加到其他圖形。

**複製投影片時會保留連接線的綁定嗎？**

當與投影片一起複製連接的圖形時，綁定通常會被保留。如果僅複製了連接線而未同時複製其目標圖形，則必須重新附加受影響的端點。