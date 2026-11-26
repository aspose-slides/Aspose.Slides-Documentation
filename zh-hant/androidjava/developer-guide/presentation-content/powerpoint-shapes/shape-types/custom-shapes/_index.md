---
title: 在 Android 上自訂簡報形狀
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
- 曲線角落
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 於 Java 環境中，建立與自訂 PowerPoint 簡報的圖形：幾何路徑、曲線角落、複合圖形。"
---
## **概覽**

本文說明如何透過編輯點和幾何路徑來自訂 Aspose.Slides 簡報中的圖形。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 和 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 來修改現有圖形、執行基本的路徑編輯操作、加入或移除點，並將更新的幾何套用回圖形。

它還示範了如何建立自訂和複合圖形、以曲線角落構建圖形、判斷圖形幾何是否封閉，並使用 Android 點陣列檢查圖形元素。

## **使用編輯點變更圖形**

在 PowerPoint 中，您可以使用 **編輯點** 來修改正方形：

* 將角落向內或向外移動。
* 調整點的曲率。
* 新增點。

編輯點可讓您修改圖形的輪廓，或以現有圖形為基礎建立新圖形。

## **圖形編輯提示**

![概覽圖像](custom_shape_0.png)

編輯 PowerPoint 圖形時，請記住以下概念：

* 圖形（或其路徑）可以是封閉的或開放的。
* 圖形的路徑由錨點與段落相連組成。
* 段落可以是直線或曲線。錨點和控制手柄決定其形狀。
* 錨點可作為角點、直線點或平滑點：
  * 在角點，相鄰的段落可以形成角度。
  * 在平滑點，兩個控制手柄對齊且與錨點的距離相等。
  * 在直線點，兩個控制手柄仍對齊，但與錨點的距離可以不同。
* 移動錨點或調整其手柄會改變圖形的輪廓。

為了透過編輯點編輯 PowerPoint 圖形，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 類別和 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 介面。

* 一個 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 實例代表 [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) 物件的幾何路徑。
* 若要從 [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) 取得 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)，可以使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) 方法。
* 若要為圖形設定 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)，可使用以下方法：對於單一路徑的圖形使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)，對於多路徑的圖形使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)。
* 若要新增段落，可使用屬於 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 的方法。
* 使用 [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) 和 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) 方法，可設定幾何路徑的外觀。
* 使用 [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) 方法，可將 [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) 的幾何路徑以路徑段陣列的形式取得。

## **簡易編輯操作**

使用下列方法編輯幾何路徑。接受索引的重載會在路徑的段落陣列中於該零基位置插入段落。

| 操作 | 方法 |
| --- | --- |
| 附加或插入直線。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 附加或插入具有兩個控制點與終點的三次貝茲曲線。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 附加或插入具有一個控制點與終點的二次貝茲曲線。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 附加具有指定尺寸與角度（以度為單位）的橢圓弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 透過將端點連接至起點來關閉目前圖形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| 設定圖形的起始點。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| 移除零基索引處的段落。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **為圖形新增自訂點**

此範例使用 [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) 在矩形圖形中插入兩個點，並使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用編輯後的路徑。座標是相對於圖形的本地座標：兩個新點位於圖形中心，左側距離 100 點，頂部距離 50 點。段落索引 1 與 4 分別將它們放在上、下邊緣，將這些邊緣向內拉。

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

![範例1圖像](custom_shape_1.png)

## **從圖形移除點**

此範例透過使用 [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) 移除零基索引 2 處的段落，來變更心形輪廓。使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用修改後的路徑，即可更新圖形的輪廓。

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
![範例2圖像](custom_shape_2.png)

## **建立自訂圖形**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 建立一個五點星形。交替的外半徑 100 點與內半徑 50 點決定星尖與凹陷；72 度的步幅將五個星尖均勻分布。路徑以 [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) 閉合，並使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用至矩形圖形，取代其輪廓。

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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
![範例3圖像](custom_shape_3.png)

## **建立複合自訂圖形**

此範例為圖形的上、下三分之一各定義一個封閉的 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 物件。使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 同時套用兩條路徑，會在圖形的中間三分之一產生一個間隙，形成單一的複合圖形。

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
![範例4圖像](custom_shape_4.png)

## **建立具有曲線角落的自訂圖形**

此範例將直線段與 [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) 結合，建立具有向內彎曲角落的圖形。每個角落的尺寸以點為單位設定弧的寬度與高度，-90 度的掃掠角會繪製逆時針四分之一橢圓。完成的路徑使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用，並將簡報儲存為 PPTX 格式。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

## **判斷圖形幾何是否封閉**

以下輔助程式會檢查每個非空幾何路徑是否以關閉段落結束。它會讀取 [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--)，並將最後段落的 [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) 與 [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) 進行比較。若沒有非空路徑則回傳 false。此檢查每條路徑的最後指令；不會檢查路徑內的每個子圖形。範例會對矩形印出 `true`。

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

下載 [contour.pptx](contour.pptx) 並將範例檔名替換為裝置上的實際路徑。第一張投影片的第一個圖形具有直線上緣、三次貝茲曲線以及直線收尾。使用 [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) 讀取圖形的路徑，並使用 [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) 以繪製順序讀取每條路徑的段落。對於每個段落， [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) 會標示指令，並決定如何解讀 [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) 回傳的值。

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

圖形位於投影片上的 (200, 100) 點。報告的座標是相對於圖形本身的本地座標，左上角為 (0, 0)，X 向右遞增，Y 向下遞增。收尾段落會回到起始點，且不會附加其他座標。

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **提取並檢查圖形元素**

使用 [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) 可將現有圖形檢視為包含路徑點與點類型的元素。將每個回傳的 [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) 轉型為 [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) 後，即可透過 [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) 與 [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) 方法取得點與類型陣列。此表示法適合輪廓分析或將幾何傳遞給自訂繪圖工具。

範例會開啟 input.pptx，找到第一張投影片上直接的第一個幾何圖形，並印出其路徑段落。請使用包含直線與曲線段落的圖形來觀察兩種輸出。此程式不會搜尋群組內的圖形。

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // 保留段落類型，排除旗標。
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // 同時消耗兩個控制點與終點。
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

陣列依索引對應：`points[i]` 為一個點，`types[i]` 描述其角色。類型 `0` 表示開始一個圖形，類型 `1` 表示從前一點畫一條直線到當前點。三次貝茲段落從前一端點開始，使用連續三個類型 `3` 的條目：兩個控制點接著新端點。迴圈會一次消耗這三個條目，並檢查端點是否為閉合。

點類型同時也包含旗標。使用 `0x07` 掩碼可辨識段落類型，另用 `0x80` 判斷是否為閉合子路徑。例如，`129` (`0x81`) 代表閉合的直線端點，`131` (`0x83`) 代表閉合的貝茲端點。Java 以有號位元組儲存這些旗標；使用掩碼可保留預期的位元值。僅比對原始值 `1` 或 `3` 會遺漏這些情況。其他旗標如虛線 (`0x10`) 與標記 (`0x20`) 不會改變基礎段落類型。

**座標與變換。** 點的單位為點 (1/72 吋)，X 向右遞增，Y 向下遞增。對於未分組的圖形，提取的座標已包含由 [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) 與 [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) 回傳的位置，且反映當前的寬度與高度。例如，未旋轉的矩形位於 `(100, 200)`，大小為 `120 × 80`，其輪廓界限為 `(100, 200)`–`(220, 280)`。不要再次加入圖形的位置。若要取得相對於未旋轉框架的座標，請減去其 X 與 Y。

提取的點不會套用由 [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) 回傳的旋轉，亦不會套用水平與垂直翻轉。若要重現顯示的輪廓，必須以圖形中心為基點套用這些變換。對於分組圖形，還需考慮群組座標映射與變換；不要假設提取的點已是最終投影片座標，亦不要在已在子圖形框架中反映的情況下再次平移或縮放。

**檢查 vs. 編輯。** 提取的陣列僅描述輪廓，修改它們不會更新原始圖形。當您的分析或繪圖程式需要點/類型陣列時，可選擇此方式。若需在圖形本地座標系統中取得幾何指令或想編輯其幾何，請使用 [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--)。編輯後的路徑可透過 [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 或 [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 套用。

## **常見問題**

**取代幾何後填充與輪廓會怎樣？**

樣式仍附屬於圖形，僅輪廓會變更。填充與輪廓會自動套用至新幾何。

**如何正確旋轉自訂圖形及其幾何？**

使用圖形的 [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) 方法；幾何會隨圖形一起旋轉，因為它綁定在圖形自己的座標系統上。

**我可以將自訂圖形轉換為影像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/androidjava/create-shape-thumbnails/) 本身匯出為點陣圖格式，這能簡化後續對複雜幾何的處理。