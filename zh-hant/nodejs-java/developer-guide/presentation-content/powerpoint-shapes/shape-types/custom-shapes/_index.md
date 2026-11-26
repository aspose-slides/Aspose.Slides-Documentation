---
title: 在 JavaScript 中自訂簡報形狀
linktitle: 自訂形狀
type: docs
weight: 20
url: /zh-hant/nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 以及 Aspose.Slides for Node.js 在 PowerPoint 簡報中建立與自訂形狀：幾何路徑、圓角、合成形狀。"
---
## **概觀**

本文說明如何透過編輯點與幾何路徑編輯形狀幾何，來自訂 Aspose.Slides 簡報中的形狀。它展示如何使用 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 來修改現有形狀、執行基本路徑編輯操作、加入或移除點，並將更新後的幾何套用回形狀。  
它亦示範如何建立自訂與合成形狀、建構帶有圓角的形狀、判斷形狀幾何是否為閉合、檢查形狀元素，以及將 Java AWT 文字輪廓轉換為幾何路徑。

## **使用編輯點變更形狀**

在 PowerPoint 中，您可以使用 **Edit Points** 來修改正方形：

* 將角向內或向外移動。
* 調整點的曲率。
* 新增點。

編輯點可讓您修改形狀的輪廓，或以現有形狀作為新形狀的基礎。

## **形狀編輯技巧**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 形狀時，請留意以下概念：

* 形狀（或其路徑）可以是閉合或開放的。
* 形狀的路徑由錨點透過線段相連組成。
* 線段可以是直線或曲線。錨點與控制手柄決定其形狀。
* 錨點可作為角點、直點或平滑點：
  * 在角點，相鄰的線段可在角度處相交。
  * 在平滑點，兩個控制手柄保持對齊且與錨點等距。
  * 在直點，兩個控制手柄保持對齊，但距離錨點的長度可不同。
* 移動錨點或調整其手柄會改變形狀的輪廓。

若要透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 類別。

* 一個 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 實例表示 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) 物件的幾何路徑。
* 若要從 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) 實例取得 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)，可使用 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) 方法。
* 若要為形狀設定 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)，可使用以下方法：單一路徑形狀使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)，多路徑形狀使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)。
* 若要加入線段，可使用屬於 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 的方法。
* 使用 [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) 和 [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) 方法，可設定幾何路徑的外觀。
* 使用 [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) 方法，可將 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) 的幾何路徑以路徑線段陣列形式取得。
* 若要存取其他形狀幾何的自訂選項，可透過 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 讀取 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)，並在 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 上重播這些線段。

## **簡易編輯操作**

使用以下方法編輯幾何路徑。接受索引的多載會在路徑的線段陣列中，以零為起點的指定位置插入線段。

| 操作 | 方法 |
| --- | --- |
| 附加或插入直線。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| 附加或插入具有兩個控制點與端點的三次貝茲曲線。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 附加或插入具有一個控制點與端點的二次貝茲曲線。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 附加具有指定尺寸與角度（以度為單位）的橢圓弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| 透過將終點連回起始點來關閉目前圖形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| 設定圖形的起始點。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| 移除位於零基索引的線段。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **將自訂點新增至形狀**

此範例使用 [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) 在矩形形狀中插入兩個點，並使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 套用編輯後的路徑。座標是相對於形狀的本地座標：兩個新點位於形狀中心，距左側 100 點、距頂部 50 點。線段索引 1 與 4 分別將它們放置於上、下邊緣，將這些邊緣向內拉。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **從形狀移除點**

此範例使用 [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) 移除零基索引為 2 的線段，以變更心形輪廓。使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 套用修改後的路徑，即可更新形狀的輪廓。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```

![example2_image](custom_shape_2.png)

## **建立自訂形狀**

此範例使用 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 建立五角星。交替的外半徑 100 點與內半徑 50 點定義星尖與凹陷；以 72 度的步幅均勻分布五個星尖。路徑透過 [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) 閉合，並使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 套用至矩形形狀，以取代其輪廓。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```

![example3_image](custom_shape_3.png)

## **建立合成自訂形狀**

此範例為形狀的上、下三分之一各定義兩個閉合的 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 物件。使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) 套用兩條路徑，會建立一個在中間三分之一有間隙的單一合成形狀。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```

![example4_image](custom_shape_4.png)

## **建立帶圓角的自訂形狀**

此範例結合直線段與 [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) 以建立帶有向內彎曲角落的形狀。每個角落尺寸以點為單位設定弧的寬度與高度，-90 度的掃描角繪製逆時針四分之一橢圓。完成的路徑使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 套用，並將簡報儲存為 PPTX 格式。

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **判斷形狀幾何是否為閉合**

以下輔助程式檢查每個非空的幾何路徑是否以閉合線段結束。它會讀取 [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) 並將最後線段的 [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) 與 [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) 進行比較。若沒有非空路徑則回傳 false。此檢查每條路徑的最後指令，並不會檢查路徑內的每個子圖形。範例對矩形輸出 `true`。

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **檢查幾何路徑指令**

下載 [contour.pptx](contour.pptx) 並將其放置於應用程式的工作目錄中。第一張投影片的第一個形狀具有直線上緣、三次貝茲曲線以及直線閉合邊緣。使用 [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) 讀取形狀的路徑，並使用 [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) 依繪製順序讀取每條路徑的線段。對於每個線段，[getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) 會識別指令，並決定如何解讀 [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData) 所回傳的值。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

該形狀位於投影片的 (200, 100) 點。回報的座標為相對於形狀的本地座標，原點 (0, 0) 位於左上角，x 向右遞增，y 向下遞增。閉合線段會返回起始點，且不含其他座標。

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint 形狀，具有直線上緣、從右上至左下的曲線邊緣以及直線左側邊緣](contour.png)

## **擷取與檢查形狀元素**

使用 [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) 可將現有形狀視為包含路徑點與點類型的元素進行檢查。對每個回傳的 [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) 使用 [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) 與 [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) 方法取得點與類型陣列。此表示法對輪廓分析或將幾何傳遞給自訂繪圖工具很有用。

此範例開啟 input.pptx，直接在第一張投影片上找到第一個幾何形狀，並印出其路徑線段。請使用包含直線與曲線線段的形狀之簡報，以觀察兩種輸出。此程式不會在群組內搜尋。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // 保留線段類型，排除旗標。
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // 消耗兩個控制點與終點。
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

陣列以索引對應：`points[i]` 為一個點，`types[i]` 描述其角色。類型 `0` 開始一個圖形，類型 `1` 從前一點畫線至目前點。三次貝茲線段從前一端點開始，使用連續三個 type-`3` 條目：兩個控制點接著新的端點。迴圈會一起消耗這三個條目，並檢查端點是否閉合。

點類型亦包含旗標。使用 `0x07` 掩碼可辨識線段類型，並另行測試 `0x80` 以偵測閉合子路徑。例如，`129`（`0x81`）表示閉合子路徑的直線端點，`131`（`0x83`）表示閉合的貝茲端點。Java 以有號位元組儲存這些旗標；使用掩碼可保留預期的位元值。僅以 `1` 或 `3` 比較原始值會遺漏這些情況。其他旗標，如虛線 (`0x10`) 與標記 (`0x20`)，不會改變基礎線段類型。

**座標與變換。** 點以點為單位（1/72 吋）測量，X 向右遞增，Y 向下遞增。對於未分組的形狀，擷取的座標已包含由 [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) 與 [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) 回傳的位置，並反映其目前的寬度與高度。例如，位於 `(100, 200)`、尺寸為 `120 × 80` 的未旋轉矩形，其輪廓範圍為 `(100, 200)`–`(220, 280)`。請勿再次加入形狀的位置。將其 X 與 Y 相減即可取得相對於未旋轉框架的座標。

擷取的點不會套用形狀的旋轉（由 [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) 回傳）或水平、垂直翻轉。若要還原顯示的輪廓，需在形狀中心周圍套用這些變換。對於群組形狀，亦需考慮群組座標映射與變換；請不要假設擷取的點即為最終呈現在投影片上的座標，或在已在子形狀框架中反映的情況下再次套用平移或縮放。

**檢查與編輯的差異。** 擷取的陣列描述輪廓；變更它們不會更新原始形狀。當分析或繪圖程式需要點 / 類型陣列時，可採用此方式。若需要在形狀本地座標系統中的幾何指令或欲編輯其幾何，請使用 [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths)。透過 [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 或 [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) 套用編輯後的路徑。

## **將 Java AWT Shape 轉換為 GeometryPath**

此範例將矩形輪廓與轉換為幾何的文字結合。輪廓的 [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) 方法會關閉填滿。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 於 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 中建立文字輪廓。其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 提供移動、線條、二次、三次與閉合線段，範例將這些線段重新播放於 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 上。

Java 橋接使用明確的 float 與 byte 值作為對應的 Java 參數。迭代器將座標寫入 Java float 陣列；反射則將其更新的值讀回 JavaScript。文字使用 40 點的 Arial 字型。輪廓水平偏移 20 點，且其視覺上方位於形狀上緣下方 10 點。文字路徑為填滿狀態，而原始矩形則保留為輪廓。使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) 套用兩條路徑，可產生包含矩形與文字的單一形狀。

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // 移動到。
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // 畫線至。
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // 二次貝茲曲線。
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // 三次貝茲曲線。
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // 關閉圖形。
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**取代幾何後，填色與輪廓會如何？**

樣式仍保留於形狀上；僅輪廓會變更。填色與輪廓會自動套用到新的幾何。

**如何正確地連同幾何一起旋轉自訂形狀？**

使用形狀的 [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) 方法；幾何會隨形狀一起旋轉，因為它綁定於形狀自身的座標系統。

**我可以將自訂形狀轉換為影像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/nodejs-java/create-shape-thumbnails/) 本身匯出為點陣格式；這可簡化後續對複雜幾何的處理。