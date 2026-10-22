---
title: 在 Android 上自訂簡報圖形
linktitle: 自訂圖形
type: docs
weight: 20
url: /zh-hant/androidjava/custom-shape/
keywords:
- 自訂圖形
- 新增圖形
- 建立圖形
- 變更圖形
- 圖形幾何
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
description: "使用 Aspose.Slides for Android 透過 Java 在 PowerPoint 簡報中建立與自訂圖形：幾何路徑、圓角、複合圖形。"
---
## **概述**

本文說明如何透過編輯點與幾何路徑來編輯形狀幾何，以自訂 Aspose.Slides 簡報中的圖形。它示範如何使用 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 和 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 變更既有圖形、執行基本路徑編輯操作、加入或移除點，並將更新後的幾何套用回圖形。

同時也示範如何建立自訂與複合圖形、建構具有圓角的圖形、判斷圖形幾何是否為閉合，以及使用 Android 點陣列檢查圖形元素。

## **使用編輯點變更圖形**

在 PowerPoint 中，您可以使用 **編輯點** 來修改方形：

* 將角落向內或向外移動。
* 調整某點的曲率。
* 新增點。

透過編輯點可以修改圖形的輪廓，或以既有圖形作為新圖形的基礎。

## **圖形編輯要點**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 圖形時，請留意以下概念：

* 圖形（或其路徑）可以是閉合或開放的。
* 圖形的路徑由透過線段相連的錨點組成。
* 線段可以是直線或曲線。錨點與控制手柄決定其形狀。
* 錨點可分為角點、直線點或平滑點：
  * 在角點，相鄰的線段可以形成角度。
  * 在平滑點，兩個控制手柄共線且與錨點的距離相等。
  * 在直線點，兩個控制手柄共線，但與錨點的距離可能不同。
* 移動錨點或調整其手柄會改變圖形的輪廓。

為了透過編輯點編輯 PowerPoint 圖形，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 類別與 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 介面。

* 一個 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 實例代表 [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) 物件的幾何路徑。
* 若要從 [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) 取得 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)，可使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) 方法。
* 若要為圖形設定 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)，可使用以下方法：單一路徑圖形使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-)，多路徑圖形使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)。
* 若要新增線段，可使用屬於 [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) 的方法。
* 透過 [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) 與 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) 方法，可設定幾何路徑的外觀。
* 使用 [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) 方法，可將 [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) 的幾何路徑以路徑段陣列形式取得。

## **簡單編輯操作**

使用下列方法編輯幾何路徑。接受索引的重載會在路徑的線段陣列中於零基索引位置插入線段。

| 操作 | 方法 |
| --- | --- |
| 追加或插入直線。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| 追加或插入具有兩個控制點與終點的三次貝茲曲線。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| 追加或插入具有一個控制點與終點的二次貝茲曲線。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| 追加具有指定尺寸與角度（度）的橢圓弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| 透過將終點連回起點關閉目前圖形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| 設定圖形的起始點。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| 移除指定零基索引處的線段。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **為圖形新增自訂點**

此範例使用 [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) 在矩形圖形中插入兩個點，並使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用編輯後的路徑。座標為相對於圖形的本地座標：兩個新點均位於圖形中心，距左側 100 點、距上方 50 點。線段索引 1 與 4 分別將它們放在上緣與下緣，將這兩條邊向內拉。

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

## **從圖形移除點**

此範例透過 [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) 移除零基索引 2 處的線段，變更心形輪廓。使用 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用修改後的路徑，即可更新圖形的外框。

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

## **建立自訂圖形**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 建立一個五角星。交替的外徑與內徑分別為 100 點與 50 點，形成星尖與凹陷；每 72 度的步進使五個星尖均勻分布。路徑最後以 [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) 閉合，並透過 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用到矩形圖形，取代其原始輪廓。

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
![example3_image](custom_shape_3.png)

## **建立複合自訂圖形**

此範例為圖形的上三分之一與下三分之一分別定義兩個閉合的 [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) 物件。使用 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 同時套用兩條路徑，便可產生一個在中間三分之一留有間隙的單一複合圖形。

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

## **建立具有圓角的自訂圖形**

此範例將直線段與 [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) 結合，打造具有內彎圓角的圖形。每個角的大小設定弧的寬度與高度（以點為單位），且 -90 度的掃描角度繪製逆時針四分之一橢圓。完成的路徑以 [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 套用，最後將簡報存為 PPTX 格式。

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

## **判斷圖形幾何是否為閉合**

以下輔助程式會檢查每個非空幾何路徑是否以閉合線段結尾。它會讀取 [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--)，並將最終線段的 [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) 與 [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) 進行比較。若無非空路徑，則回傳 false。此檢查僅比對每條路徑的最後指令，不會檢查路徑內的每個子圖形。範例會對矩形輸出 `true`。

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

## **擷取與檢查圖形元素**

使用 [IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) 可將現有圖形檢視為包含路徑點與點類型的元素。將每個回傳的 [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) 轉型為 [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/)，即可透過 [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) 與 [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) 方法取得點陣列與類型陣列。此表示方式適合輪廓分析或將幾何傳遞給自訂繪圖工具。

範例會開啟 `input.pptx`，在第一張投影片上直接尋找第一個幾何圖形，並列印其路徑線段。請使用包含直線與曲線線段的圖形測試，以觀察兩種輸出。此程式不會搜尋群組內部。

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
                        i += 2; // Consume both control points and the endpoint.
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

陣列依索引對應：`points[i]` 為座標點，`types[i]` 描述其角色。類型 `0` 代表開始圖形，類型 `1` 表示從前一點畫直線至當前點。三次貝茲線段以先前的終點為起點，接著使用三個連續的類型 `3` 條目：兩個控制點與新的終點。迴圈會一起處理這三條目，並檢查終點是否形成閉合。

點類型亦包含旗標。使用 `0x07` 掩碼可辨識線段類型，另以 `0x80` 判斷是否為閉合子路徑。例如 `129` (`0x81`) 代表閉合的直線終點，`131` (`0x83`) 代表閉合的貝茲終點。Java 以有號位元組儲存這些旗標；透過掩碼可保留正確的位元值。僅以 `1` 或 `3` 直接比較原始值會遺漏這些情況。其他旗標如虛線 (`0x10`) 與標記 (`0x20`) 不會改變基礎線段類型。

**座標與變換。** 點的單位為點 (1/72 吋)，X 向右增加，Y 向下增加。對於未群組的圖形，擷取的座標已包含由 [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) 與 [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) 回傳的位置，且反映當前寬度與高度。例如，位於 `(100, 200)`、尺寸為 `120 × 80` 的未旋轉矩形，其輪廓界限為 `(100, 200)`–`(220, 280)`。請勿再次加上圖形的位置。將其 X、Y 扣除即可取得相對於未旋轉框架的座標。

擷取的點不會套用圖形的旋轉（由 [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) 回傳）或水平、垂直翻轉。若要還原顯示出的輪廓，需在圖形中心周圍套用這些變換。對於群組圖形，還需考慮群組座標映射與變換；切勿假設擷取的點已是最終投影片座標，亦不要在已反映於子圖形框架的情況下再次平移或縮放。

**檢查 vs. 編輯。** 擷取的陣列僅描述輪廓，變更它們不會更新原始圖形。當您僅需點/類型陣列以進行分析或繪圖時，請使用此方式。若需在圖形本地座標系統中取得幾何指令或編輯幾何，請使用 [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--)。編輯後的路徑可透過 [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) 或 [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) 套用。

## **常見問題**

**取代幾何後，填色與輪廓會發生什麼變化？**

樣式仍屬於圖形本身，只有輪廓會改變。填色與輪廓會自動套用到新的幾何上。

**如何正確地旋轉自訂圖形以及其幾何？**

使用圖形的 [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) 方法；幾何會隨圖形一起旋轉，因為它繫結於圖形的座標系統。

**我可以把自訂圖形轉換成圖像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/androidjava/create-shape-thumbnails/) 本身匯出為點陣圖格式；這樣可簡化後續對複雜幾何的處理。