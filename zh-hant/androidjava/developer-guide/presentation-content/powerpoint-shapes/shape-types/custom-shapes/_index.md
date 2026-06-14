---
title: 自訂 Android 上的簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/androidjava/custom-shape/
keywords:
- 自訂形狀
- 新增形狀
- 建立形狀
- 變更形狀
- 形狀幾何
- 幾何路徑
- 路徑點
- 編輯點
- 新增點
- 移除點
- 編輯操作
- 圓角
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 於 Java 中建立與自訂 PowerPoint 簡報的形狀：幾何路徑、圓角、複合形狀。"
---
## **概述**

本文說明如何透過編輯點和幾何路徑編輯形狀幾何，來自訂 Aspose.Slides 中的簡報形狀。它示範如何使用 `GeometryPath` 與 `IGeometryPath` 來修改現有形狀、執行基本的路徑編輯操作、加入或移除點，並將更新後的幾何套用回形狀。

它同時展示如何建立自訂與複合形狀、建構具有圓角的形狀、判斷形狀幾何是否為封閉，以及在 `GeometryPath` 與 `java.awt.Shape` 之間轉換，以應對額外的幾何自訂情境。

## **使用編輯點變更形狀**
以正方形為例。在 PowerPoint 中，使用 **編輯點**，您可以

* 將正方形的角向內或向外移動
* 為角或點指定曲率
* 為正方形新增點
* 操作正方形上的點等

基本上，您可以對任何形狀執行上述工作。使用編輯點，您可以變更形狀或從現有形狀建立新形狀。

## **形狀編輯技巧**

![overview_image](custom_shape_0.png)

在開始透過編輯點編輯 PowerPoint 形狀之前，您可能想先了解以下關於形狀的要點：

* 形狀（或其路徑）可以是封閉的或開放的。
* 當形狀為封閉時，沒有起始點或結束點。當形狀為開放時，則具有起始點與結束點。 
* 所有形狀至少由 2 個錨點組成，這些錨點透過線條互相連接。 
* 線條可以是直線或曲線。錨點決定線條的性質。 
* 錨點可分為拐角點、直點或平滑點：
  * 拐角點是兩條直線在某角度相交的點。 
  * 平滑點是兩個控制柄位於同一直線上，並且線段以平滑曲線相連的點。此情況下，所有控制柄與錨點的距離相等。 
  * 直點是兩個控制柄位於同一直線上，且線段以平滑曲線相連的點。此情況下，控制柄與錨點的距離不必相等。 
* 透過移動或編輯錨點（會改變線條角度），即可改變形狀的外觀。 

要透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供了 [**GeometryPath**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 類別以及 [**IGeometryPath**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IGeometryPath) 介面。

* 一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 實例代表 [IGeometryShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IGeometryShape) 物件的幾何路徑。  
* 若要從 `IGeometryShape` 實例取得 `GeometryPath`，可以使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) 方法。  
* 若要為形狀設定 `GeometryPath`，可使用以下方法：針對*實心形狀*使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-)，針對*複合形狀*使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-)。  
* 若要加入線段，可使用 [IGeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IGeometryPath) 下的相關方法。  
* 使用 [IGeometryPath.setStroke](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) 與 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) 方法，即可設定幾何路徑的外觀。  
* 透過 [IGeometryPath.getPathData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IGeometryPath#getPathData--) 方法，可取得 `GeometryShape` 的幾何路徑，回傳為路徑段陣列。  
* 若要存取額外的形狀幾何自訂選項，可將 [GeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 轉換為 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)。  
* 使用 [geometryPathToGraphicsPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) 與 [graphicsPathToGeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) 方法（來自 [ShapeUtil](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ShapeUtil) 類別）可以在 [GeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 與 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 之間互相轉換。

## **簡易編輯操作**

以下 Java 程式碼示範如何

**在路徑末端新增線段**  
``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**在路徑的指定位置新增線段**：  
``` java
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**在路徑末端新增立方貝茲曲線**：  
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**在路徑的指定位置新增立方貝茲曲線**：  
``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**在路徑末端新增二次貝茲曲線**：  
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**在路徑的指定位置新增二次貝茲曲線**：  
``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**將給定的弧段附加至路徑**：  
``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**關閉路徑的目前圖形**：  
``` java
public void closeFigure();
```
**設定下一個點的位置**：  
``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**移除指定索引的路徑段**：  
``` java
public void removeAt(int index);
```

## **向形狀新增自訂點**

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryShape) 類別的實例，並設定其 [ShapeType.Rectangle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ShapeType) 類型。  
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 類別的實例。  
3. 在路徑的兩個上方點之間新增一個點。  
4. 在路徑的兩個下方點之間新增一個點。  
5. 將路徑套用至形狀。  

以下 Java 程式碼示範如何向形狀新增自訂點：  
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

## **從形狀移除點**

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryShape) 類別的實例，並設定其 [ShapeType.Heart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ShapeType) 類型。  
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 類別的實例。  
3. 移除路徑的線段。  
4. 將路徑套用至形狀。  

以下 Java 程式碼示範如何從形狀移除點：  
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

## **建立自訂形狀**

1. 計算形狀的點座標。  
2. 建立 [GeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 類別的實例。  
3. 以點填充路徑。  
4. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryShape) 類別的實例。  
5. 將路徑套用至形狀。  

以下 Java 程式碼示範如何建立自訂形狀：  
``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example3_image](custom_shape_3.png)


## **建立複合自訂形狀**

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryShape) 類別的實例。  
2. 建立第一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 類別的實例。  
3. 建立第二個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 類別的實例。  
4. 將路徑套用至形狀。  

以下 Java 程式碼示範如何建立複合自訂形狀：  
``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **建立具有圓角的自訂形狀**

以下 Java 程式碼示範如何建立具有內凹圓角的自訂形狀；  
```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.closeFigure();

    childShape.setGeometryPath(geometryPath);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **判斷形狀幾何是否為封閉**

封閉形狀的定義是其所有邊皆相連，形成沒有缺口的單一邊界。此類形狀可以是簡單的幾何形狀，也可以是複雜的自訂輪廓。以下程式碼範例示範如何檢查形狀幾何是否為封閉：  
```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **將 GeometryPath 轉換為 java.awt.Shape**

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryShape) 類別的實例。  
2. 建立 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 類別的實例。  
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ShapeUtil) 將 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 實例轉換為 [GeometryPath](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/GeometryPath) 實例。  
4. 將路徑套用至形狀。  

以下 Java 程式碼（上述步驟的實作）示範 **GeometryPath** 轉換至 **GraphicsPath** 的過程：  
``` java
Presentation pres = new Presentation();
try {
    // 建立新形狀
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 取得形狀的幾何路徑
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // 建立包含文字的圖形路徑
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // 將圖形路徑轉換為幾何路徑
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // 將新幾何路徑與原始幾何路徑的組合設定到形狀
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **常見問題**

**替換幾何後填充與輪廓會發生什麼變化？**  
樣式仍保留在形狀上，僅輪廓會變更。填充與輪廓會自動套用到新幾何上。

**如何正確地一起旋轉自訂形狀及其幾何？**  
使用形狀的 [setRotation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#setRotation-float-) 方法；因為幾何綁定於形狀自身的座標系統，旋轉形狀時幾何也會一起旋轉。

**我可以將自訂形狀轉換成影像以「鎖定」結果嗎？**  
可以。將所需的 [投影片](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 區域或 [形狀](/slides/zh-hant/androidjava/create-shape-thumbnails/) 本身匯出為點陣圖格式；這樣可簡化對複雜幾何的後續處理。