---
title: 在 Android 上管理簡報中的連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/androidjava/connector/
keywords:
- 連接線
- 連接線類型
- 連接點
- 連接線
- 連接線角度
- 連接圖形
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "讓 Java 應用程式在 Android 上的 PowerPoint 投影片中繪製、連接並自動路由線條——全面掌控直線、彎角和曲線連接線。"
---
## **簡介**

PowerPoint 連接線是一種特殊的線條，用於將兩個圖形連接或鏈接在一起，即使在幻燈片上移動或重新定位圖形時，也會保持附著於圖形上。  

連接線通常會連接到 *連接點*（綠點），這些點預設存在於所有圖形上。當游標接近時，連接點會顯示出來。  

*調整點*（橙點），僅在某些連接線上存在，用於修改連接線的位置和形狀。  

## **連接線類型**

在 PowerPoint 中，您可以使用直線、彎角（有角度）和曲線連接線。  

Aspose.Slides 提供以下這些連接線：

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

## **使用連接線連接圖形**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 使用 `Shapes` 物件提供的 `addAutoShape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AutoShape) 新增至投影片。  
1. 使用 `Shapes` 物件提供的 `addConnector` 方法，並指定連接線類型，新增連接線。  
1. 使用該連接線將圖形連接起來。  
1. 呼叫 `reroute` 方法，以套用最短的連接路徑。  
1. 儲存簡報。  

以下 Java 程式碼示範如何在兩個圖形（橢圓形和矩形）之間新增一條連接線（彎曲連接線）：

```Java
// 實例化代表 PPTX 檔案的簡報類別
Presentation pres = new Presentation();
try {
    // 取得特定投影片的圖形集合
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // 新增橢圓形自動圖形
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // 新增矩形自動圖形
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // 新增連接線圖形至投影片的圖形集合
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // 使用連接線連接圖形
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // 呼叫 reroute 以設定圖形之間的自動最短路徑
    connector.reroute();
    
    // 儲存簡報
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` 方法會重新路由連接線，強制其在圖形之間採取最短路徑。為了達成此目的，該方法可能會變更 `setStartShapeConnectionSiteIndex` 與 `setEndShapeConnectionSiteIndex` 點。 
{{% /alert %}} 

## **指定連接點**

如果您希望連接線使用圖形上的特定點來連接兩個圖形，必須以以下方式指定您偏好的連接點：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。  
1. 透過索引取得投影片的參考。  
1. 使用 `Shapes` 物件提供的 `addAutoShape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/AutoShape) 新增至投影片。  
1. 使用 `Shapes` 物件提供的 `addConnector` 方法，並指定連接線類型，新增連接線。  
1. 使用該連接線將圖形連接起來。  
1. 在圖形上設定您偏好的連接點。  
1. 儲存簡報。  

以下 Java 程式碼示範如何指定偏好的連接點：

```java
// 實例化代表 PPTX 檔案的簡報類別
Presentation pres = new Presentation();
try {
    // 取得特定投影片的圖形集合
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // 新增橢圓形自動圖形
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // 新增矩形自動圖形
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // 新增連接線圖形至投影片的圖形集合
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // 使用連接線連接圖形
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // 設定橢圓形圖形上的首選連接點索引
    int wantedIndex = 6;

    // 檢查首選索引是否小於最大站點索引計數
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // 設定橢圓形自動圖形的首選連接點
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // 儲存簡報
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **調整連接線點**

您可以透過調整點來調整現有的連接線。只有具備調整點的連接線才能以此方式修改。請參閱 **[連接線類型](/slides/zh-hant/androidjava/connector/#types-of-connectors)** 表格。  

### **簡單案例**

考慮一個情況：連接線在兩個圖形（A 與 B）之間穿過第三個圖形（C）：

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

為避免或繞過第三個圖形，我們可以透過將其垂直線向左移動來調整連接線：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **複雜案例** 

要執行更複雜的調整，必須考慮以下因素：

* 連接線的可調點與計算並決定其位置的公式緊密相關。因此，變更該點的位置可能會改變連接線的形狀。  
* 連接線的調整點在陣列中以嚴格的順序定義。調整點依序從連接線的起始點編號至結束點。  
* 調整點的值反映連接線形狀寬度/高度的百分比。  
  * 形狀的範圍由連接線的起始點與結束點乘以 1000 所限。  
  * 第一個、第二個與第三個點分別定義寬度的百分比、高度的百分比以及再次的寬度百分比。  
* 在計算連接線調整點坐標時，必須考慮連接線的旋轉角度與其鏡像。**注意**，在 **[連接線類型](/slides/zh-hant/androidjava/connector/#types-of-connectors)** 中顯示的所有連接線的旋轉角度皆為 0。  

#### **案例 1**

考慮一個案例：兩個文字框物件透過連接線相互連結：

![connector-shape-complex](connector-shape-complex.png)

```java
// 實例化代表 PPTX 檔案的簡報類別
Presentation pres = new Presentation();
try {
    // 取得簡報的第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    // 新增將透過連接線連結在一起的圖形
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // 新增連接線
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // 指定連接線的方向
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // 指定連接線的顏色
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // 指定連接線線條的粗細
    connector.getLineFormat().setWidth(3);
    
    // 使用連接線將圖形連結在一起
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // 取得連接線的調整點
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**調整**

我們可以透過將相應的寬度與高度百分比分別提高 20% 和 200%，來變更連接線的調整點值：

```java
// 更改調整點的值
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

為了建立一個模型，使我們能夠確定連接線各個部分的座標與形狀，讓我們在 connector.getAdjustments().get_Item(0) 點建立一個對應於連接線水平分量的形狀：

```java
// 繪製連接線的垂直分量
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我們示範了使用基本原理的簡單連接線調整操作。在一般情況下，必須考慮連接線的旋轉與顯示方式（由 connector.getRotation()、connector.getFrame().getFlipH() 與 connector.getFrame().getFlipV() 設定）。接下來我們將示範此流程。

首先，讓我們在投影片上新增一個文字框物件（**To 1**）以供連接，並建立一條新的（綠色）連接線，將其連接至先前建立的物件。

```java
// 建立新的綁定物件
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// 建立新的連接線
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// 使用新建立的連接線連接物件
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// 取得連接線的調整點
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// 更改調整點的值
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

結果：

![connector-adjusted-3](connector-adjusted-3.png)

其次，讓我們建立一個形狀，以對應通過新連接線的調整點 connector.getAdjustments().get_Item(0) 的水平分量。我們將使用 connector.getRotation()、connector.getFrame().getFlipH() 與 connector.getFrame().getFlipV() 的值，套用常用的繞給定點 x0 旋轉的座標轉換公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，物件的旋轉角度為 90 度，且連接線以垂直方式顯示，因此以下為相應的程式碼：

```java
// 儲存連接線座標
x = connector.getX();
y = connector.getY();
// 若出現則校正連接線座標
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// 以調整點的值作為座標
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  轉換座標，因為 Sin(90) = 1 且 Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// 使用第二個調整點的值來決定水平分量的寬度
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

我們示範了涉及簡單調整與具有旋轉角度之複雜調整點的計算。透過所學，您可以開發自己的模型（或撰寫程式碼），取得 `GraphicsPath` 物件，甚至根據特定投影片座標設定連接線的調整點值。  

## **找出連接線的角度**

1. 建立該類別的實例。  
1. 透過索引取得投影片的參考。  
1. 存取連接線形狀。  
1. 使用線寬、線高、形狀框架高度與寬度來計算角度。  

以下 Java 程式碼示範如何計算連接線形狀的角度：

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **常見問題**

**如何判斷連接線是否可以「黏貼」到特定圖形上？**

檢查該圖形是否提供 [連接點](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--)。如果沒有或計數為零，則無法黏貼；此時請使用自由端點並手動定位。在連接前檢查網站計數是明智的做法。  

**如果刪除其中一個已連接的圖形，連接線會發生什麼情況？**

其兩端會被分離；連接線仍保留在投影片上，變成一條普通的自由起止直線。您可以刪除它，或重新指派連接，必要時使用 [reroute](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/connector/#reroute--) 方法。  

**將投影片複製到另一個簡報時，連接線的綁定會被保留嗎？**

大多數情況下會保留，前提是目標圖形也一併被複製。若將投影片插入到未包含連接圖形的檔案中，連接線兩端會變成自由端點，需重新連接。