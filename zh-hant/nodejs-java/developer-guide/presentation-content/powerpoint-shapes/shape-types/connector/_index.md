---
title: 使用 JavaScript 在簡報中管理連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/nodejs-java/connector/
keywords:
- 連接線
- 連接線類型
- 連接點
- 連接線條
- 連接角度
- 連接圖形
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "賦能 JavaScript 應用程式在 PowerPoint 投影片中繪製、連接並自動路由線條——完全掌控直線、彎角與曲線連接線。"
---
## **簡介**

PowerPoint 連接線是一種特殊的線條，可連接或連結兩個圖形，且即使在投影片上移動或重新定位圖形時仍會保持附著。

連接線通常連接到 *連接點*（綠點），這些點預設存在於所有圖形上。當游標靠近時，連接點會顯示。

*調整點*（橙點）僅存在於某些連接線上，用於調整連接線的位置和形狀。

## **連接線類型**

在 PowerPoint 中，您可以使用直線、彎角（斜角）和曲線連接線。

Aspose.Slides 提供以下連接線：

| 連接線 | 圖片 | 調整點數量 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **使用連接線連結圖形**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 使用 `Shapes` 物件提供的 `addAutoShape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 新增至投影片。  
1. 使用 `Shapes` 物件提供的 `addConnector` 方法，依據連接線類型新增連接線。  
1. 使用該連接線將圖形連結起來。  
1. 呼叫 `reroute` 方法以套用最短的連接路徑。  
1. 儲存投影片。  

以下 JavaScript 程式碼示範如何在兩個圖形（橢圓與矩形）之間加入一條連接線（折彎連接線）：

```javascript
// 建立表示 PPTX 檔案的簡報類別實例
var pres = new aspose.slides.Presentation();
try {
    // 取得特定投影片的圖形集合
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // 新增橢圓自動圖形
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // 新增矩形自動圖形
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // 為投影片的圖形集合新增連接線圖形
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // 使用連接線連接圖形
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // 呼叫 reroute 以設定圖形之間的自動最短路徑
    connector.reroute();
    // 儲存簡報
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` 方法會重新導向連接線，強制其在圖形之間採取最短路徑。為了達成此目的，該方法可能會變更 `setStartShapeConnectionSiteIndex` 與 `setEndShapeConnectionSiteIndex` 點。 
{{% /alert %}} 

## **指定連接點**

如果您希望連接線使用圖形上的特定點來連結兩個圖形，必須以以下方式指定首選的連接點：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 使用 `Shapes` 物件提供的 `addAutoShape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 新增至投影片。  
1. 使用 `Shapes` 物件提供的 `addConnector` 方法，依據連接線類型新增連接線。  
1. 使用該連接線將圖形連結起來。  
1. 在圖形上設定您首選的連接點。  
1. 儲存投影片。  

以下 JavaScript 程式碼示範指定首選連接點的操作：

```javascript
// 建立表示 PPTX 檔案的簡報類別實例
var pres = new aspose.slides.Presentation();
try {
    // 取得特定投影片的圖形集合
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // 新增橢圓自動圖形
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // 新增矩形自動圖形
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // 為投影片的圖形集合新增連接線圖形
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // 使用連接線連接圖形
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // 設定橢圓圖形上首選的連接點索引
    var wantedIndex = 6;
    // 檢查首選索引是否小於最大連接點索引數量
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // 為橢圓自動圖形設定首選的連接點
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // 儲存簡報
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **調整連接線點**

您可以通過調整點調整現有的連接線。僅有具備調整點的連接線才能以此方式變更。請參閱 **[連接線類型](/slides/zh-hant/nodejs-java/connector/#types-of-connectors)** 中的表格。

### **簡單案例**

考慮一種情況：連接兩個圖形 (A 與 B) 的連接線穿過第三個圖形 (C)：

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

為避免或繞過第三個圖形，我們可以透過將其垂直線向左移動來調整連接線：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **複雜案例** 

若要執行更複雜的調整，必須考慮以下事項：

* 連接線的可調整點與計算其位置的公式緊密相連。因此，改變點的位置可能會影響連接線的形狀。  
* 連接線的調整點在陣列中以嚴格順序定義，且由連接線的起點依序編號至終點。  
* 調整點的數值代表連接線形狀寬度/高度的百分比。  
  * 形狀以連接線的起點與終點乘以 1000 作為界限。  
  * 第一點、第二點與第三點分別定義寬度的百分比、高度的百分比以及再次的寬度百分比。  
* 在計算連接線調整點座標時，必須考慮連接線的旋轉與翻轉。**注意**，在 **[連接線類型](/slides/zh-hant/nodejs-java/connector/#types-of-connectors)** 中顯示的所有連接線的旋轉角度皆為 0。

#### **案例 1**

考慮兩個文字框物件透過連接線相互連結的情況：

![connector-shape-complex](connector-shape-complex.png)

```javascript
// 建立表示 PPTX 檔案的簡報類別實例
var pres = new aspose.slides.Presentation();
try {
    // 取得簡報中的第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增將透過連接線連結的圖形
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // 新增連接線
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // 指定連接線的方向
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // 指定連接線的顏色
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // 指定連接線的線條粗細
    connector.getLineFormat().setWidth(3);
    // 使用連接線將圖形連結起來
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // 取得連接線的調整點
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Adjustment**

我們可以將對應的寬度與高度百分比分別增加 20% 與 200%，以變更連接線的調整點數值：

```javascript
// 變更調整點的值
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

為了定義一個模型，以便我們判斷連接線各部分的座標與形狀，讓我們在 `connector.getAdjustments().get_Item(0)` 點處建立一個對應水平分量的形狀：

```javascript
// 畫出連接線的垂直組件
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我們示範了使用基本原理的簡單調整操作。於一般情況下，必須考慮連接線的旋轉與顯示（由 `connector.getRotation()`、`connector.getFrame().getFlipH()` 與 `connector.getFrame().getFlipV()` 設定）。以下示範此過程。

首先，將一個新的文字框物件（**To 1**）加入投影片（作為連接用途），並建立一條新的（綠色）連接線，將其連接至先前建立的物件。

```javascript
// 建立新綁定物件
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 建立新連接線
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// 使用新建立的連接線連結物件
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// 取得連接線的調整點
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// 變更調整點的值
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

結果：

![connector-adjusted-3](connector-adjusted-3.png)

其次，建立一個形狀，以對應穿過新連接線調整點 `connector.getAdjustments().get_Item(0)` 的水平分量。我們將使用 `connector.getRotation()`、`connector.getFrame().getFlipH()` 與 `connector.getFrame().getFlipV()` 的數值，並套用以下常用的繞點 x0 旋轉座標轉換公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，物件的旋轉角度為 90 度且連接線以垂直方式顯示，對應程式碼如下：

```javascript
// 儲存連接線座標
x = connector.getX();
y = connector.getY();
// 在需要時校正連接線座標
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// 將調整點的值作為座標
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// 轉換座標，因為 Sin(90) = 1 且 Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// 使用第二個調整點的值決定水平組件的寬度
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

我們示範了包含簡單調整與帶旋轉角度的複雜調整點的計算。運用所學，您可以開發自己的模型（或撰寫程式碼）以取得 `GraphicsPath` 物件，甚至根據特定投影片座標設定連接線的調整點數值。

## **取得連接線角度**

1. 建立該類別的實例。  
1. 透過索引取得投影片的參考。  
1. 存取連接線形狀。  
1. 使用線條寬度、高度、圖形框的高度與寬度來計算角度。  

以下 JavaScript 程式碼示範計算連接線形狀角度的操作：

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **常見問題**

**如何判斷連接線是否能「黏貼」到特定圖形？**  

確認該圖形是否提供 [connection sites](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getconnectionsitecount/)。若無或計數為零，則無法黏貼；此時請使用自由端點並手動定位。建議在附加前先檢查 site 數量。

**如果我刪除其中一個已連接的圖形，連接線會發生什麼情況？**  

其兩端會被分離；連接線會保留在投影片上，成為具有自由起點/終點的普通線條。您可以刪除它，或重新指派連接，必要時再 [reroute](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/connector/reroute/)。

**在將投影片複製到另一個簡報時，連接線的綁定會保留嗎？**  

一般而言會保留，前提是目標圖形也一併被複製。若將投影片插入另一個檔案卻缺少已連接的圖形，則兩端會變成自由端點，需要重新附加。