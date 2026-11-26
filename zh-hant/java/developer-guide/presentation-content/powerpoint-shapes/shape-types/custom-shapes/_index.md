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
description: "使用 Aspose.Slides for Java 在 PowerPoint 簡報中建立與自訂形狀：幾何路徑、曲線角、複合形狀。"
---
## **概述**

此文章說明如何透過編輯點與幾何路徑來編輯形狀幾何，以自訂 Aspose.Slides 中的簡報形狀。它示範如何使用 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 與 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 來修改現有形狀、執行基本路徑編輯操作、增加或移除點，並將更新後的幾何套用回形狀。

它同時展示如何建立自訂與複合形狀、建構具有曲線角的形狀、判斷形狀幾何是否為閉合、檢查形狀元素，並將 Java AWT 文字輪廓轉換為幾何路徑。

## **透過編輯點變更形狀**

在 PowerPoint 中，您可以使用 **Edit Points** 來修改正方形：

* 將角落向內或向外移動。
* 調整該點的曲率。
* 新增點。

編輯點讓您可以修改形狀的輪廓，或以現有形狀作為新形狀的基礎。

## **形狀編輯技巧**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 形狀時，請記住以下概念：

* 形狀（或其路徑）可以是閉合或開放的。
* 形狀的路徑由錨點透過線段連接組成。
* 線段可以是直線或曲線。錨點與控制桿決定其形狀。
* 錨點可分為角點、直點或平滑點：
  * 在角點，鄰接的線段可在角度處相交。
  * 在平滑點，兩個控制桿對齊且與錨點的距離相等。
  * 在直點，兩個控制桿雖然對齊，但與錨點的距離可以不同。
* 移動錨點或調整其桿會改變形狀的輪廓。

若要透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 類別與 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 介面。

* 一個 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 實例代表 [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 物件的幾何路徑。
* 若要從 [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 實例取得 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)，可使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) 方法。
* 若要為形狀設定 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)，可使用以下方法：對於單一路徑的形狀使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)，對於多路徑的形狀使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)。
* 若要新增線段，可使用 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 下的方法。
* 使用 [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) 與 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 方法，可設定幾何路徑的外觀。
* 使用 [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) 方法，可將 [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) 的幾何路徑以路徑線段陣列取得。
* 若要存取其他形狀幾何自訂選項，可透過其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 讀取 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)，並在 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 上重播線段。

## **簡單編輯操作**

| 操作 | 方法 |
| --- | --- |
| 新增或插入直線。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 新增或插入具有兩個控制點及終點的三次貝茲曲線。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 新增或插入具有一個控制點及終點的二次貝茲曲線。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 新增具有指定尺寸與角度（以度為單位）的橢圓弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 透過將端點連回起點來關閉目前的圖形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| 設定圖形的起始點。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| 移除位於零基索引的線段。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **向形狀新增自訂點**

此範例使用 [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) 在矩形形狀中插入兩個點，並以 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用編輯後的路徑。座標以形狀為基準：兩個新點皆位於中心，距左側 100 點、距上側 50 點。線段索引 1 與 4 分別將它們放在上、下邊緣，將這些邊緣向內拉。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **從形狀移除點**

此範例透過 [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) 移除零基索引為 2 的線段，以變更心形輪廓。以 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用修改後的路徑，即可更新形狀的輪廓。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **建立自訂形狀**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 建立一個五角星。交替的外半徑與內半徑分別為 100 點與 50 點，定義星角與凹陷；每 72 度一步均勻分布五個星角。路徑以 [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) 關閉，並以 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用至矩形形狀，取代其輪廓。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **建立複合自訂形狀**

此範例為形狀的上、下三分之一各定義一個閉合的 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 物件。以 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 套用兩條路徑，會產生一個在中間三分之一處留有間隙的單一複合形狀。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **建立具有曲線角的自訂形狀**

此範例將直線段與 [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) 結合，建立具有向內彎曲角的形狀。每個角的大小決定弧形的寬度與高度（以點為單位），-90 度的掃描角繪製逆時針四分之一橢圓。完成的路徑以 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用，並將簡報儲存為 PPTX 格式。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **判斷形狀幾何是否為閉合**

以下輔助程式會檢查每個非空的幾何路徑是否以閉合線段結束。它讀取 [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) 並將最後線段的 [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) 與 [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) 做比較。若沒有非空路徑則回傳 false。此檢查每條路徑的最後指令，並不會檢查路徑內的每個子圖形。範例會對矩形輸出 `true`。

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **檢查幾何路徑指令**

下載 [contour.pptx](contour.pptx) 並放置於應用程式的工作目錄中。第一張投影片的第一個形狀具有直線上緣、三次貝茲曲線與直線閉合邊。使用 [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) 讀取形狀的路徑，並使用 [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) 依繪製順序讀取每條路徑的線段。對於每個線段，[getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) 會辨識指令，並決定如何詮釋 [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) 所回傳的數值。

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

該形狀位於投影片上的 (200, 100) 點。回報的座標是相對於形狀本身的，本點 (0, 0) 位於左上角，x 向右遞增，y 向下遞增。閉合線段會回到起始點而不需其他座標。

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint 形狀，具有直線上緣、從右上到左下的曲線邊緣，以及直線左側邊緣](contour.png)

## **提取與檢查形狀元素**

使用 [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) 可將現有形狀檢視為包含路徑點與點類型的元素。將每個回傳的 [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) 轉型為 [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) ，以透過 [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) 與 [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) 方法取得點與類型陣列。此表示方式適用於輪廓分析或將幾何傳遞給自訂繪圖工具。

此範例開啟 input.pptx，直接在第一張投影片上找到第一個幾何形狀，並輸出其路徑線段。使用包含具有直線與曲線線段之形狀的簡報，即可看到兩種輸出。它不會在群組內搜尋。

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // 保留線段類型，排除旗標。
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // 消耗兩個控制點與終點。
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

陣列以索引對應：`points[i]` 為一個點，`types[i]` 描述其角色。類型 `0` 表示開始圖形，類型 `1` 從前一點畫線至當前點。三次貝茲線段從前一終點開始，使用連續三個 type-`3` 項目：兩個控制點接著新的終點。迴圈會一起消耗這三個項目，並檢查終點是否閉合。

點類型也包含旗標。以 `0x07` 做遮罩可辨識線段類型，另以 `0x80` 測試可偵測閉合子路徑。例如，`129`（`0x81`）表示閉合子路徑的線段終點，`131`（`0x83`）表示閉合的貝茲終點。Java 將這些旗標存於有號位元組中；使用遮罩可保留預期的位元值。僅以 `1` 或 `3` 比較原始值會遺漏此類情況。其他旗標，如虛線 (`0x10`) 與標記 (`0x20`)，不會改變基本線段類型。

**座標與轉換。** 點以點為單位（1/72 吋），X 向右遞增，Y 向下遞增。對於未群組的形狀，提取的座標已包含 [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) 與 [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) 回傳的位置，並反映其當前寬度與高度。例如，位於 `(100, 200)`、尺寸為 `120 × 80` 的未旋轉矩形，其輪廓界限為 `(100, 200)`–`(220, 280)`。不要再次加上形狀的位置。減去其 X 與 Y 可取得相對於未旋轉框架的座標。

提取的點不會套用形狀的旋轉（由 [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) 回傳）或水平、垂直翻轉。若要重現顯示的輪廓，需以形狀中心為基準套用這些轉換。對於群組形狀，還需考慮群組座標映射與轉換；不要假設提取的點即為最終渲染的投影片座標，或在已於子項框架中反映的情況下再次套用平移或縮放。

**檢查與編輯的差異。** 提取的陣列描述輪廓；更改它們不會更新原始形狀。當您的分析或繪圖程式需要點/類型陣列時，請使用此方式。若需要在形狀本地座標系統的幾何指令或想編輯其幾何，請使用 [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--)。透過 [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 或 [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 套用編輯後的路徑。

## **將 Java AWT Shape 轉換為 GeometryPath**

此範例將矩形輪廓與轉換為幾何形狀的文字結合。輪廓的 [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 方法會停用填滿。一個 [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 在 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 中建立文字輪廓。其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 提供移動、線段、二次、三次與閉合線段，範例將其重播到 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 上。

文字使用 40 點的 Arial 字型。輪廓水平偏移 20 點，且其視覺上緣位於形狀上緣下方 10 點。文字路徑為填滿，而原始矩形則保持輪廓。以 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 套用兩條路徑，會產生包含矩形與文字的單一形狀。

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // 建立新形狀
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // 取得形狀的幾何路徑
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // 建立包含文字的新圖形路徑
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // 將圖形路徑轉換為幾何路徑
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // 設定新幾何路徑與原始幾何路徑的組合到形狀
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **常見問題**

**在取代幾何後，填色與輪廓會怎樣？**

樣式仍保留在形狀上；只有輪廓會改變。填色與輪廓會自動套用到新的幾何上。

**如何正確地連同幾何一起旋轉自訂形狀？**

使用形狀的 [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) 方法；幾何會隨形狀一起旋轉，因為它綁定於形狀自身的座標系統。

**我可以將自訂形狀轉換為圖片以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/java/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/java/create-shape-thumbnails/) 本身匯出為點陣格式；這會讓後續處理複雜幾何變得更簡單。