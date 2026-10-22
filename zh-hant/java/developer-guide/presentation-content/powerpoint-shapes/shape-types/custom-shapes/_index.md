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
- 彎曲角
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 簡報中建立與自訂形狀：幾何路徑、彎曲角、合成形狀。"
---
## **概觀**

本文說明如何透過編輯點與幾何路徑來修改 Aspose.Slides 中的投影片形狀，並示範如何使用 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 與 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 來變更既有形狀、執行基本路徑編輯操作、加入或移除點，並將更新的幾何套用回形狀。

此外，還示範如何建立自訂與合成形狀、建構具彎曲角的形狀、判斷形狀幾何是否為閉合、檢查形狀元素，以及將 Java AWT 文字輪廓轉換為幾何路徑。

## **使用編輯點變更形狀**

在 PowerPoint 中，您可以使用 **Edit Points** 來修改正方形：

* 將角向內或向外移動。
* 調整某點的曲率。
* 新增點。

編輯點讓您能修改形狀的輪廓，或以既有形狀作為新形狀的基礎。

## **形狀編輯技巧**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 形狀時，請記住以下概念：

* 形狀（或其路徑）可以是閉合或開放的。
* 形狀的路徑由錨點與其間的線段組成。
* 線段可以是直線或曲線。錨點與控制手柄決定其形狀。
* 錨點可為拐角點、直線點或平滑點：
  * 在拐角點，相鄰線段可在角度處相交。
  * 在平滑點，兩條控制手柄對齊且與錨點的距離相等。
  * 在直線點，兩條控制手柄對齊但距離可不同。
* 移動錨點或調整其手柄會改變形狀的輪廓。

要透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 類別與 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 介面。

* 一個 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 實例代表 [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 物件的幾何路徑。
* 若要從 [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) 取得 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)，可使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) 方法。
* 若要設定形狀的 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/)，可使用以下方法：對於單一路徑的形狀使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)，對於多路徑的形狀使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)。
* 若要新增線段，可使用 [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) 下的各種方法。
* 透過 [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) 與 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 方法，您可以設定幾何路徑的外觀。
* 使用 [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) 方法，可將 [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) 的幾何路徑以路徑線段陣列形式取得。
* 若要存取其他形狀幾何的自訂選項，可透過 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 的 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 讀取，並將線段重新播放到 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 上。

## **簡易編輯操作**

使用下列方法編輯幾何路徑。接受索引的重載會在路徑的線段陣列中於該零基位置插入線段。

| 操作 | 方法 |
| --- | --- |
| 附加或插入直線。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 附加或插入具有兩個控制點與終點的三次貝塞爾曲線。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 附加或插入具有一個控制點與終點的二次貝塞爾曲線。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 附加具有指定尺寸與角度（以度為單位）的橢圓弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 透過將端點連回起點關閉目前的圖形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| 設定圖形的起始點。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| 移除零基索引處的線段。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **為形狀新增自訂點**

此範例使用 [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) 在矩形形狀中插入兩個點，並以 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用編輯後的路徑。座標是相對於形狀的本地座標：兩個新點皆位於中心，距左側 100 點、距頂部 50 點。線段索引 1 與 4 分別將它們放在上緣與下緣，將這兩條邊向內收縮。

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

此範例透過 [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) 移除零基索引 2 處的線段，以變更心形輪廓。使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用修改後的路徑，即可更新形狀的輪廓。

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

此範例使用 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 建立五角星。交替的外部與內部半徑分別為 100 與 50 點，定義星尖與凹陷；每 72 度一個步長，使五個星尖均勻分布。路徑最後以 [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) 關閉，並使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用到矩形形狀，取代其原有輪廓。

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

## **建立合成自訂形狀**

此範例為形狀的上三分之一與下三分之一定義兩條閉合的 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 物件。使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 同時套用兩條路徑，即可產生一個單一的合成形狀，其中部三分之一留下空隙。

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

## **建立具彎曲角的自訂形狀**

此範例結合直線段與 [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) 以產生內彎角形狀。每個角的尺寸決定弧的寬度與高度（以點為單位），-90 度的掃描角繪製逆時針四分之一橢圓。完成的路徑以 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用，最後將簡報另存為 PPTX 格式。

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

## **判斷形狀幾何是否閉合**

以下輔助程式會檢查每個非空的幾何路徑是否以閉合線段結尾。它會讀取 [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--)，並將最終線段的 [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) 與 [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) 進行比較。若沒有非空路徑則回傳 false。此檢查僅比較每條路徑的最終指令，並不會檢查路徑內的每個子圖形。範例會為矩形輸出 `true`。

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

## **擷取與檢查形狀元素**

使用 [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) 可將現有形狀檢查為包含路徑點與點類型的元素。將每個回傳的 [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) 轉型為 [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/)，即可透過 [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) 與 [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) 方法取得點與類型陣列。此表示方式適用於輪廓分析或將幾何傳遞給自訂繪圖工具。

範例會開啟 input.pptx，於第一張投影片直接找出第一個幾何形狀，並印出其路徑線段。請使用包含直線與曲線段的形狀的簡報，以同時看到兩種輸出。此程式不會搜尋群組內的形狀。

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

陣列以索引對應：`points[i]` 為一個點，`types[i]` 描述其角色。類型 `0` 開始一個圖形，類型 `1` 從前一個點繪製到目前點的直線。三次貝塞爾線段從前一個端點開始，使用連續三個類型 `3` 條目：兩個控制點與新的端點。迴圈會同時消耗這三條目，並檢查端點是否閉合。

點類型亦包含旗標。以 `0x07` 進行遮罩可取得線段類型，並以 `0x80` 單獨測試是否為閉合子路徑。例如，`129`（`0x81`）表示關閉子路徑的直線端點，`131`（`0x83`）表示關閉的貝塞爾端點。Java 以有號位元組儲存這些旗標；遮罩後即可保留預期的位元值。僅比較原始值等於 `1` 或 `3` 會遺漏這些情況。其他旗標，如虛線 (`0x10`) 與標記 (`0x20`)，不會改變基礎線段類型。

**座標與變換。** 點的單位為點 (1/72 吋)，X 向右遞增，Y 向下遞增。對於未群組化的形狀，擷取的座標已包含由 [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) 與 [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) 回傳的位置，且反映目前的寬度與高度。例如，未旋轉的矩形位於 `(100, 200)`，大小為 `120 × 80`，其輪廓界限為 `(100, 200)`–`(220, 280)`。請勿再次加上形狀的位置。若要取得相對於未旋轉框架的座標，請減去其 X 與 Y。

擷取的點不會套用由 [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) 回傳的形狀旋轉，亦不會考慮水平與垂直翻轉。若要重現顯示的輪廓，請在形狀中心周圍套用這些變換。對於群組形狀，亦需考慮群組座標映射與變換；請勿假設擷取的點已是最終投影片座標，或在已反映於子框架的情況下再次套用平移或縮放。

**檢查與編輯的差異。** 擷取的陣列僅描述輪廓，變更它們不會更新原始形狀。當您的分析或繪圖程式需要點/類型陣列時，請使用此方式。若需要在形狀本地座標系統中取得幾何指令或欲編輯其幾何，請使用 [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--)。編輯後的路徑請透過 [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 或 [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 套用。

## **將 Java AWT Shape 轉換為 GeometryPath**

此範例將矩形輪廓與文字輪廓結合。矩形的 [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) 方法會停用其填色。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 會在 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 中建立文字輪廓。其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 會提供移動、直線、二次、三次與閉合線段，範例會將這些線段重新播放到 [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) 上。

文字使用 40 點的 Arial 字型。輪廓水平向右偏移 20 點，並以視覺上位於形狀上緣下方 10 點的位置置放。文字路徑會填色，而原始矩形則保留為輪廓。使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 同時套用兩條路徑，即產生包含矩形與文字的單一形狀。

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

    // 建立帶有文字的圖形路徑
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

    // 將新幾何路徑與原始幾何路徑的組合設定給形狀
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **常見問題**

**取代幾何後，填色與輪廓會發生什麼變化？**

樣式會保留在形狀上，只是輪廓變更。填色與輪廓會自動套用到新的幾何。

**如何正確地同時旋轉自訂形狀與其幾何？**

使用形狀的 [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) 方法；幾何會隨形狀一起旋轉，因為它綁定於形狀自己的座標系統。

**我可以將自訂形狀轉換為影像以「鎖定」結果嗎？**

可以。將所需的 [投影片](/slides/zh-hant/java/convert-powerpoint-to-png/) 區域或 [形狀](/slides/zh-hant/java/create-shape-thumbnails/) 本身匯出為點陣圖格式；這可簡化對複雜幾何的後續處理。