---
title: 在 Java 中自訂簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/java/custom-shape/
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
- 曲線角
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 簡報中建立和自訂形狀：幾何路徑、曲線角、複合形狀。"
---
## **概觀**

本文說明如何透過編輯點與幾何路徑編輯形狀幾何，以自訂 Aspose.Slides 中的呈現形狀。它展示了如何使用 `GeometryPath` 和 `IGeometryPath` 修改現有形狀、執行基本路徑編輯操作、加入或移除點，並將更新後的幾何套用回形狀。

同時也示範了如何建立自訂與複合形狀、建構具有曲線角的形狀、判斷形狀幾何是否閉合，以及在 `GeometryPath` 與 `java.awt.Shape` 之間轉換，以因應其他幾何自訂情境。

## **使用編輯點變更形狀**

以正方形為例。在 PowerPoint 中使用 **編輯點**，您可以

* 將正方形的角向內或向外移動  
* 為角或點指定曲率  
* 為正方形新增點  
* 操作正方形上的點，等等  

基本上，您可以對任何形狀執行上述工作。透過編輯點，您可以變更形狀或從現有形狀建立新形狀。

## **形狀編輯提示**

![overview_image](custom_shape_0.png)

在開始使用編輯點編輯 PowerPoint 形狀之前，建議先了解以下相關概念：

* 形狀（或其路徑）可以是閉合的也可以是開放的。  
* 閉合形狀沒有起點或終點；開放形狀則有起點與終點。  
* 所有形狀至少由 2 個錨點組成，這些錨點以線段相連。  
* 線段可以是直線或曲線。錨點決定線段的性質。  
* 錨點有三種類型：角點、直線點與平滑點  
  * 角點：兩條直線在此交會形成角度。  
  * 平滑點：兩個控制柄位於同一直線上，且線段在此形成平滑曲線，兩個控制柄與錨點的距離相等。  
  * 直線點：兩個控制柄位於同一直線上，線段在此形成平滑曲線，但兩個控制柄與錨點的距離不必相等。  
* 透過移動或編輯錨點（即改變線段角度），即可改變形狀的外觀。

為了透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供了[**GeometryPath**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 類別與[**IGeometryPath**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryPath) 介面。

* [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 例項代表 [IGeometryShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryShape) 物件的幾何路徑。  
* 若要從 `IGeometryShape` 例項取得 `GeometryPath`，可使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) 方法。  
* 若要為形狀設定 `GeometryPath`，可使用以下方法：針對*實體形狀*使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-)，針對*複合形狀*使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-)。  
* 若要加入線段，可使用 [IGeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryPath) 下的相關方法。  
* 使用 [IGeometryPath.setStroke](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) 與 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) 方法，可設定幾何路徑的外觀。  
* 透過 [IGeometryPath.getPathData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IGeometryPath#getPathData--) 方法，可將 `GeometryShape` 的幾何路徑以路徑段陣列形式取得。  
* 若需額外的形狀幾何自訂選項，可將 [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 轉換為 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)。  
* 使用 [ShapeUtil](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ShapeUtil) 類別中的 [geometryPathToGraphicsPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) 與 [graphicsPathToGeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) 方法，可在 [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 與 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 之間相互轉換。

## **簡易編輯操作**

以下 Java 程式碼示範如何

**在路徑末端加入直線**

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**在路徑指定位置加入直線：**

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**在路徑末端加入三次貝塞爾曲線：**

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**在路徑指定位置加入三次貝塞爾曲線：**

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**在路徑末端加入二次貝塞爾曲線：**

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**在路徑指定位置加入二次貝塞爾曲線：**

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**將給定弧段附加至路徑：**

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**關閉路徑目前的圖形：**

``` java
public void closeFigure();
```
**設定下一個點的位置：**

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**移除指定索引處的路徑段：**

``` java
public void removeAt(int index);
```

## **為形狀新增自訂點**
1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryShape) 類別的例項，並將類型設為 [ShapeType.Rectangle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ShapeType)。  
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 類別的例項。  
3. 在路徑上兩個上方點之間新增一個點。  
4. 在路徑上兩個下方點之間新增一個點。  
5. 將路徑套用至形狀。

以下 Java 程式碼示範如何為形狀新增自訂點：

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

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryShape) 類別的例項，並將類型設為 [ShapeType.Heart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ShapeType)。  
2. 從形狀取得 [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 類別的例項。  
3. 移除相應的路徑段。  
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

1. 計算形狀的各個點。  
2. 建立 [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 類別的例項。  
3. 使用點填入路徑。  
4. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryShape) 類別的例項。  
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

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryShape) 類別的例項。  
2. 建立第一個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 類別的例項。  
3. 建立第二個 [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 類別的例項。  
4. 將兩條路徑套用至形狀。

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

## **建立具有曲線角的自訂形狀**

以下 Java 程式碼示範如何建立帶有內凹曲線角的自訂形狀：

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

## **判斷形狀幾何是否為閉合**

閉合形狀是指其所有邊緣相連，形成無缺口的單一邊界。此類形狀可以是簡單的幾何圖形，也可以是複雜的自訂輪廓。以下程式碼範例說明如何檢查形狀幾何是否為閉合：

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

1. 建立 [GeometryShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryShape) 類別的例項。  
2. 建立 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 類別的例項。  
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ShapeUtil) 將 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 例項轉換為 [GeometryPath](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/GeometryPath) 例項。  
4. 將路徑套用至形狀。

以下 Java 程式碼—上述步驟的實作—示範了 **GeometryPath** 轉換為 **GraphicsPath** 的過程：

``` java
Presentation pres = new Presentation();
try {
    // 建立新形狀
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 取得形狀的幾何路徑
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // 使用文字建立新的圖形路徑
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

    // 設定新幾何路徑與原始幾何路徑的組合至形狀
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **常見問題**

**取代幾何後，填充與輪廓會發生什麼變化？**

樣式仍屬於該形狀，僅變更外框。填充與輪廓會自動套用至新幾何。

**如何正確地在旋轉自訂形狀時同時旋轉其幾何？**

使用形狀的 [setRotation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#setRotation-float-) 方法；幾何會隨形狀一起旋轉，因為它綁定於形狀自身的座標系統。

**我可以將自訂形狀轉換為影像以「鎖定」結果嗎？**

可以。將所需的[投影片](/slides/zh-hant/java/convert-powerpoint-to-png/)區域或[形狀](/slides/zh-hant/java/create-shape-thumbnails/)本身匯出為點陣圖格式，這樣可簡化對大型幾何的後續處理。