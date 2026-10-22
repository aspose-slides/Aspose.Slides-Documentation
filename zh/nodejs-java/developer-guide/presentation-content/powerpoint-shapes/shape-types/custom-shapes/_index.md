---
title: 在 JavaScript 中自定义演示文稿形状
linktitle: 自定义形状
type: docs
weight: 20
url: /zh/nodejs-java/custom-shape/
keywords:
- 自定义形状
- 添加形状
- 创建形状
- 更改形状
- 形状几何
- 几何路径
- 路径点
- 编辑点
- 添加点
- 移除点
- 编辑操作
- 圆角
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 JavaScript 和 Aspose.Slides for Node.js 在 PowerPoint 演示文稿中创建和自定义形状：几何路径、圆角、复合形状。"
---
## **概述**

本文介绍了如何通过编辑点和几何路径编辑形状几何，从而自定义 Aspose.Slides 中的演示文稿形状。它展示了如何使用[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)修改现有形状、执行基本路径编辑操作、添加或删除点，并将更新后的几何重新应用到形状。

此外，还演示了如何创建自定义和复合形状、构建带圆角的形状、判断形状几何是否闭合、检查形状元素，以及将 Java AWT 文本轮廓转换为几何路径。

## **使用编辑点更改形状**

在 PowerPoint 中，您可以使用**编辑点**来修改正方形：

* 将角向内或向外移动。
* 调整某一点的曲率。
* 添加新点。

编辑点可让您修改形状的轮廓，或以现有形状为基础创建新形状。

## **形状编辑技巧**

![概览图](custom_shape_0.png)

编辑 PowerPoint 形状时，请牢记以下概念：

* 形状（或其路径）可以是闭合的，也可以是开放的。
* 形状的路径由通过线段相连的锚点组成。
* 线段可以是直的或曲的。锚点和控制手柄决定其形状。
* 锚点可分为拐角点、直线点或平滑点：
  * 在拐角点，相邻线段可以形成角度。
  * 在平滑点，两个控制手柄共线且距离锚点相等。
  * 在直线点，两个控制手柄共线但与锚点的距离可不同。
* 移动锚点或调整其手柄会改变形状的轮廓。

为通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)类。

* 一个[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)实例表示[GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)对象的几何路径。
* 要从[GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)实例获取[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)，可使用[GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths)方法。
* 要为形状设置[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)，可使用以下方法：针对单路径形状的[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)以及针对多路径形状的[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)。
* 要添加线段，可使用[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)下的方法。
* 通过[GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke)和[GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode)方法，可设置几何路径的外观。
* 使用[GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData)方法，可将[GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/)的几何路径作为路径段数组检索。
* 若要访问更多形状几何自定义选项，可通过[PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)读取[java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)，并将段重放到[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)上。

## **简单编辑操作**

使用以下方法编辑几何路径。接受索引的重载会在路径的段数组中对应的零基位置插入段。

| 操作 | 方法 |
| --- | --- |
| 附加或插入直线段。 | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| 附加或插入带有两个控制点和终点的三次 Bézier 曲线。 | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 附加或插入带有一个控制点和终点的二次 Bézier 曲线。 | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 附加具有指定尺寸和角度（度）的椭圆弧。 | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| 通过将终点连接到起点来关闭当前图形。 | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| 设置图形的起始点。 | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| 移除指定零基索引处的段。 | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **向形状添加自定义点**

本示例使用[GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo)在矩形形状中插入两个点，并通过[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)应用编辑后的路径。坐标相对于形状本身：两个新点位于中心，距离左侧 100 点、顶部 50 点。段索引 1 和 4 将它们放在上下边缘，向内拉动这些边缘。

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

![示例1图](custom_shape_1.png)

## **从形状中移除点**

本示例通过[GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt)删除零基索引为 2 的段，以改变心形轮廓。使用[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)应用修改后的路径后，形状轮廓得到更新。

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
![示例2图](custom_shape_2.png)

## **创建自定义形状**

本示例使用[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)构建一个五角星。外半径 100 点、内半径 50 点交替定义星尖和凹槽；72 度的步进均匀分布五个星尖。路径通过[GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure)闭合，并使用[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)应用到矩形形状，替换其轮廓。

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
![示例3图](custom_shape_3.png)

## **创建复合自定义形状**

本示例为形状的上三分之一和下三分之一分别定义了两个闭合的[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)对象。通过[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)同时应用这两个路径，可创建一个在中间三分之一处留有空隙的单一复合形状。

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
![示例4图](custom_shape_4.png)

## **创建带圆角的自定义形状**

本示例将直线段与[GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo)结合，创建一个内凹圆角的形状。每个角的尺寸决定弧的宽度和高度（单位为点），-90 度的扫描角绘制逆时针四分之一椭圆。完成的路径通过[GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)应用，并以 PPTX 格式保存演示文稿。

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

## **判断形状几何是否闭合**

以下辅助方法检查每个非空几何路径是否以闭合段结束。它读取[GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData)，并将最后一段的[PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand)与[PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/)比较。若不存在非空路径则返回 false。该检查针对每条路径的最终命令，而不检查路径内部的每个子图形。示例对矩形输出 `true`。

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

## **提取并检查形状元素**

使用[GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements)可将现有形状检查为包含路径点和点类型的元素。对每个返回的[ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/)使用[getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints)和[getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes)方法获取点和类型数组。此表示法适用于轮廓分析或将几何传递给自定义绘图工具。

示例打开 `input.pptx`，在第一张幻灯片上直接查找第一个几何形状，并打印其路径段。请使用包含直线段和曲线段的形状的演示文稿，以观察两种输出。它不会在组内部搜索。

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
                const pointType = types[i] & 0x07; // 保留段类型，排除标志。
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // 消耗两个控制点和终点。
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

数组通过索引对应：`points[i]` 为点，`types[i]` 描述其角色。类型 `0` 开始一个图形，类型 `1` 从前一点绘制到当前点的直线。三次 Bézier 段从前一个终点开始，使用连续的三个类型 `3` 条目：两个控制点后跟新的终点。循环一次性消耗这三个条目，并检查终点是否闭合。

点类型还包含标志。使用 `0x07` 掩码可识别段类型，单独检测 `0x80` 可判断闭合子路径。例如，`129` (`0x81`) 表示闭合子路径的直线终点，`131` (`0x83`) 表示闭合的 Bézier 终点。Java 将这些标志存储在有符号字节中；掩码能够保留预期的位值。仅比较原始值为 `1` 或 `3` 会遗漏这些情况。其他标志如虚线 (`0x10`) 和标记 (`0x20`) 不会改变基本段类型。

**坐标与变换。** 点的单位是 point（1/72 英寸），X 向右增大，Y 向下增大。对于未分组的形状，提取的坐标已经包含了通过[getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX)和[getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY)返回的位置，并反映了当前宽高。例如，位于 `(100, 200)`、尺寸为 `120 × 80` 的未旋转矩形其轮廓边界为 `(100, 200)`–`(220, 280)`。不要再次加上形状的位置。减去其 X 和 Y 可得到相对于未旋转框架的坐标。

提取的点不考虑形状的旋转（由[getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation)返回）以及水平和垂直翻转。若要复现显示的轮廓，需要围绕形状中心应用这些变换。对于分组形状，还需考虑组坐标映射和相应的变换；不要假设提取的点已经是最终渲染的幻灯片坐标，也不要对已在子框架中体现的平移或缩放再次应用。

**检查 vs 编辑。** 提取的数组仅描述轮廓，修改它们不会更新原始形状。若您的分析或绘图代码需要点/类型数组，请使用此方式。若需要在形状本地坐标系中获取几何命令或编辑几何，请使用[getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths)。通过[setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath)或[setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)应用编辑后的路径。

## **将 Java AWT Shape 转换为 GeometryPath**

本示例将矩形轮廓与转换后的文字结合。轮廓的[setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode)方法关闭填充。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html)在[java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)中创建文字轮廓。其[PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html)提供移动、直线、二次、三次和闭合段，示例将其重放到[GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)上。

Java 桥接使用显式的 float 和 byte 值作为对应的 Java 参数。迭代器将坐标写入 Java float 数组；反射将更新后的值读回 JavaScript。文字使用 40 点 Arial 字体。轮廓在水平方向偏移 20 点，且其视觉顶部位于形状顶部下方 10 点。文字路径填充，而原始矩形保持为轮廓。通过[GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)同时应用两条路径，可生成一个包含矩形和文字的单一形状。

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
            case 0: // 移动到。
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // 直线到。
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // 二次贝塞尔曲线。
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // 三次贝塞尔曲线。
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // 闭合图形。
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
![示例5图](custom_shape_5.png)

## **常见问题解答**

**替换几何后，填充和轮廓会怎样？**

样式仍然保留在形状上，仅轮廓发生变化。填充和轮廓会自动应用到新的几何上。

**如何让自定义形状连同其几何一起正确旋转？**

使用形状的[setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation)方法；几何会随形状一起旋转，因为它绑定到形状自己的坐标系。

**能否将自定义形状转换为图像以“锁定”结果？**

可以。将所需的[幻灯片](/slides/zh/nodejs-java/convert-powerpoint-to-png/)区域或[形状](/slides/zh/nodejs-java/create-shape-thumbnails/)本身导出为栅格格式，这会简化对复杂几何的后续处理。