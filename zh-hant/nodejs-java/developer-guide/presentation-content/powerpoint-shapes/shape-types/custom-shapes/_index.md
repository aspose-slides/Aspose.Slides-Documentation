---
title: 使用 JavaScript 自訂簡報形狀
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
- 曲線角
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 與 Aspose.Slides for Node.js 在 PowerPoint 簡報中建立與自訂形狀：幾何路徑、曲線角、複合形狀。"
---
## **概述**

本文說明如何透過編輯點與幾何路徑來編輯形狀幾何，從而自訂 Aspose.Slides 中的簡報形狀。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 來修改現有形狀、執行基本路徑編輯操作、加入或移除點，並將更新後的幾何套用回形狀。

它也示範了如何建立自訂與複合形狀、建構具有曲線角的形狀、判斷形狀幾何是否閉合、檢查形狀元素，以及將 Java AWT 文字輪廓轉換為幾何路徑。

## **使用編輯點變更形狀**

在 PowerPoint 中，您可以使用 **編輯點** 來修改方形：

* 向內或向外移動角落。
* 調整某一點的曲率。
* 新增點。

編輯點讓您能修改形狀的輪廓，或以現有形狀作為新形狀的基礎。

## **形狀編輯技巧**

![overview_image](custom_shape_0.png)

編輯 PowerPoint 形狀時，請記住以下概念：

* 形狀（或其路徑）可以是閉合或開放。
* 形狀的路徑由錨點與段落相連組成。
* 段落可以是直線或曲線。錨點與控制手柄決定其形狀。
* 錨點可分為角點、直點或平滑點：
  * 角點的相鄰段落可在角度處相交。
  * 平滑點的兩個控制手柄對齊且與錨點的距離相等。
  * 直點的兩個控制手柄對齊，但與錨點的距離可不同。
* 移動錨點或調整其手柄會改變形狀的輪廓。

要透過編輯點編輯 PowerPoint 形狀，**Aspose.Slides** 提供 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 類別。

* 一個 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 實例代表 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) 物件的幾何路徑。
* 若要從 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) 例項取得 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)，可使用 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) 方法。
* 若要為形狀設定 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)，可使用以下方法：單一路徑形狀使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)，多路徑形狀使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)。
* 若要加入段落，可使用 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 下的各種方法。
* 使用 [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) 與 [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) 方法，可設定幾何路徑的外觀。
* 使用 [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) 方法，可將 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) 的幾何路徑取回為段落陣列。
* 若要存取其他形狀幾何的自訂化選項，可透過 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 的 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 讀取，並將段落重播至 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)。

## **簡易編輯操作**

使用下列方法編輯幾何路徑。接受索引的重載會在路徑段落陣列的零基位置插入段落。

| 操作 | 方法 |
| --- | --- |
| 新增或插入直線。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| 新增或插入具有兩個控制點與端點的三次貝茲曲線。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 新增或插入具有一個控制點與端點的二次貝茲曲線。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 依指定尺寸與以度為單位的角度新增橢圓弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| 透過將端點連回起始點來關閉目前圖形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| 設定圖形的起始點。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| 移除零基索引處的段落。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **向形狀新增自訂點**

此範例使用 [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) 在矩形形狀中插入兩個點，並使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 套用編輯後的路徑。座標以形狀為本地座標：兩個新點位於中心，距左側 100 點、距上方 50 點。段落索引 1 與 4 分別將它們放在上邊與下邊，使這兩條邊向內收縮。

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

此範例透過 [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) 移除零基索引 2 處的段落，變更心形輪廓。使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 套用修改後的路徑，即可更新形狀的輪廓。

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

此範例使用 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 建立五角星。交錯的外半徑 100 點與內半徑 50 點決定星尖與凹陷；72 度的步長讓五個星尖均勻分布。路徑最後以 [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) 關閉，並使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 套用至矩形形狀，取代其輪廓。

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

## **建立複合自訂形狀**

此範例為形狀的上、下三分之一各定義一個閉合的 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) 物件。使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) 同時套用兩條路徑，即可產生一個在中部三分之一有空隙的單一複合形狀。

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

## **建立具有曲線角的自訂形狀**

此範例將直線段與 [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) 結合，產生內彎曲角的形狀。每個角的尺寸以點為單位設定弧形的寬高，-90 度的掃描角繪製逆時針四分之一橢圓。完成的路徑以 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 套用，最後將簡報儲存為 PPTX 格式。

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

## **判斷形狀幾何是否閉合**

以下輔助程式會檢查每個非空的幾何路徑是否以閉合段落結尾。它會讀取 [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) 並將最後段落的 [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) 與 [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) 比較。若沒有非空路徑則回傳 false。此檢查僅檢視每條路徑的最後指令，並不會檢查路徑內的每一個子圖形。範例對矩形會印出 `true`。

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

## **擷取與檢查形狀元素**

使用 [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) 可將現有形狀檢查為包含路徑點與點類型的元素。透過每個回傳的 [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) 可使用 [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) 與 [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) 方法取得點與類型陣列。此表示法對輪廓分析或將幾何傳遞給自訂繪圖工具相當有用。

範例開啟 `input.pptx`，在第一張投影片直接找到第一個幾何形狀，並印出其路徑段落。請使用包含直線與曲線段落的形狀測試，便能同時看到兩種輸出。此程式不會在群組內搜尋。

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
                const pointType = types[i] & 0x07; // 保留段落類型，排除旗標。
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
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

陣列以索引對應：`points[i]` 為一個點，`types[i]` 描述其角色。類型 `0` 表示開始圖形，類型 `1` 表示從前一點畫線至當前點。三次貝茲段落從前一端點開始，使用連續三個類型 `3` 的條目：兩個控制點後接新的端點。迴圈會一次處理這三個條目，並檢查端點是否閉合。

點類型亦包含旗標。使用 `0x07` 遮罩可辨識段落類型，另用 `0x80` 判斷是否為閉合子路徑。例如 `129` (`0x81`) 代表關閉子路徑的線段端點，`131` (`0x83`) 代表關閉的貝茲端點。Java 以有號位元組儲存這些旗標；遮罩可保留正確的位元值。僅以 `1` 或 `3` 比對原始值會遺漏這些情況。其他旗標如虛線 (`0x10`) 與標記 (`0x20`) 不會改變基礎段落類型。

**座標與轉換。** 點的單位為點（1/72 吋），X 向右遞增，Y 向下遞增。對於未群組的形狀，擷取的座標已包含由 [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) 與 [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) 回傳的位置，並反映目前的寬度與高度。例如，未旋轉的矩形位於 `(100, 200)`，尺寸為 `120 × 80`，其輪廓界限為 `(100, 200)`–`(220, 280)`。不要再次加上形狀的位置。將 X 與 Y 減去即可取得相對於未旋轉框架的座標。

擷取的點不會套用由 [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) 回傳的形狀旋轉，亦不會考慮水平或垂直翻轉。若要重現顯示的輪廓，必須在形狀中心周圍套用這些轉換。對於群組形狀，亦需考慮群組座標映射與轉換；不要假設擷取的點已是最終投影片座標，或在已反映於子框架的情況下再次平移或縮放。

**檢查 vs. 編輯。** 擷取的陣列僅描述輪廓；修改它們不會更新原始形狀。當您的分析或繪圖程式需要點/類型陣列時，可使用此方法。若需要以形狀本地座標系統的幾何指令或想編輯其幾何，請使用 [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths)。編輯後的路徑請透過 [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) 或 [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) 套用。

## **將 Java AWT Shape 轉換為 GeometryPath**

此範例將矩形輪廓與轉換後的文字結合。輪廓的 [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) 方法關閉填充。透過 [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 產生文字輪廓，形成一個 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)。其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 會提供移動、直線、二次、三次與閉合段落，範例將這些段落重新播放至 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)。

Java 橋接使用顯式的 float 與 byte 值對應 Java 參數。迭代器將座標寫入 Java float 陣列；反射再將更新後的值讀回 JavaScript。文字使用 40 點的 Arial 字型。輪廓水平向右偏移 20 點，且以其視覺上方位於形狀上緣下方 10 點的位置。文字路徑填色，而原始矩形保持輪廓。最後使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) 套用兩條路徑，產生同時包含矩形與文字的單一形狀。

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
            case 0: // 移動至。
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // 直線至。
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

## **常見問題**

**替換幾何後，填色與輪廓會發生什麼變化？**

樣式仍然屬於形狀，只有輪廓會改變。填色與輪廓會自動套用到新的幾何上。

**如何正確地將自訂形狀與其幾何一起旋轉？**

使用形狀的 [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) 方法；幾何會隨形狀一起旋轉，因為它綁定於形狀自己的座標系統。

**我可以將自訂形狀轉換為影像以「鎖定」結果嗎？**

可以。將所需的 [slide](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 區域或 [shape](/slides/zh-hant/nodejs-java/create-shape-thumbnails/) 本身匯出為點陣圖格式，這樣可簡化後續對複雜幾何的處理。