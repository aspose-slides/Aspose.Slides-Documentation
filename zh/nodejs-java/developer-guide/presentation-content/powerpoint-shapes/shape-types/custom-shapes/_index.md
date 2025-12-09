---
title: 自定义形状
type: docs
weight: 20
url: /zh/nodejs-java/custom-shape/
keywords:
- 形状
- 自定义形状
- 创建形状
- 几何
- 形状几何
- 几何路径
- 路径点
- 编辑点
- PowerPoint
- 演示文稿
- JavaScript
- Aspose.Slides for Node.js via Java
description: "在 JavaScript 中向 PowerPoint 演示文稿添加自定义形状"
---

## **使用编辑点更改形状**

以正方形为例。在 PowerPoint 中，使用 **编辑点**，您可以

* 将正方形的角向内或向外移动
* 指定角或点的曲率
* 向正方形添加新点
* 操作正方形上的点等

本质上，您可以在任何形状上执行上述任务。使用编辑点，您可以更改一个形状或从现有形状创建新形状。

## **形状编辑技巧**

![overview_image](custom_shape_0.png)

在通过编辑点编辑 PowerPoint 形状之前，您可能需要考虑以下有关形状的要点：

* 形状（或其路径）可以是闭合的，也可以是开放的。
* 闭合形状没有起始或结束点。开放形状有起点和终点。 
* 所有形状至少由 2 个锚点组成，锚点之间通过线段相连
* 线段可以是直线或曲线。锚点决定线段的性质。 
* 锚点可以是拐角点、直线点或平滑点：
  * 拐角点是两条直线在某个角度相交的点。 
  * 平滑点是两条控制柄位于同一直线上，且线段以平滑曲线相连的点。此时所有控制柄与锚点的距离相等。 
  * 直线点是两条控制柄位于同一直线上，且线段以平滑曲线相连的点。但在此情况下，控制柄与锚点的距离不必相等。 
* 通过移动或编辑锚点（从而改变线段的角度），可以改变形状的外观。 

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 类和 [**GeometryPath**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 类。

* 一个 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 实例表示 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) 对象的几何路径。
* 要从 `GeometryShape` 实例检索 `GeometryPath`，可以使用 [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) 方法。
* 要为形状设置 `GeometryPath`，可以使用以下方法：针对 *实心形状* 使用 [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) ，针对 *复合形状* 使用 [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-)。
* 要添加段落，可以使用 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 下的方法。
* 使用 [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) 和 [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) 方法，可设置几何路径的外观。
* 使用 [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath#getPathData--) 方法，可将 `GeometryShape` 的几何路径作为路径段数组检索。
* 若要访问其他形状几何自定义选项，可将 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 转换为 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)。
* 使用来自 [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil) 类的 [geometryPathToGraphicsPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) 和 [graphicsPathToGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) 方法，可在 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 与 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 之间相互转换。

## **简单编辑操作**

此 JavaScript 代码演示如何

**添加线段** 到路径的末尾
```javascript
lineTo(point);
lineTo(x, y);
```

**在指定位置添加线段**：
```javascript
lineTo(point, index);
lineTo(x, y, index);
```

**在路径末尾添加三次贝塞尔曲线**：
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**在指定位置添加三次贝塞尔曲线**：
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```

**在路径末尾添加二次贝塞尔曲线**：
```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```

**在指定位置添加二次贝塞尔曲线**：
```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```

**将给定弧线追加到路径**：
```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```

**关闭路径的当前图形**：
```javascript
closeFigure();
```

**设置下一个点的位置**：
```javascript
moveTo(point);
moveTo(x, y);
```

**移除指定索引处的路径段**：
```javascript
removeAt(index);
```


## **向形状添加自定义点**
1. 创建 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) 类的实例，并将其类型设置为 [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType)。
2. 从形状获取 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 类的实例。
3. 在路径的两个顶部点之间添加一个新点。
4. 在路径的两个底部点之间添加一个新点。
5. 将路径应用于形状。

此 JavaScript 代码演示如何向形状添加自定义点：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example1_image](custom_shape_1.png)

## **从形状中移除点**
1. 创建 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) 类的实例，并将其类型设置为 [ShapeType.Heart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeType)。
2. 从形状获取 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 类的实例。
3. 移除路径的段落。
4. 将路径应用于形状。

此 JavaScript 代码演示如何从形状中移除点：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example2_image](custom_shape_2.png)

## **创建自定义形状**
1. 计算形状的各个点。
2. 创建 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 类的实例。
3. 使用这些点填充路径。
4. 创建 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) 类的实例。
5. 将路径应用于形状。

此 JavaScript 代码演示如何创建自定义形状：
```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example3_image](custom_shape_3.png)


## **创建复合自定义形状**
  1. 创建 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) 类的实例。
  2. 创建第一个 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 类的实例。
  3. 创建第二个 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 类的实例。
  4. 将这些路径应用于形状。

此 JavaScript 代码演示如何创建复合自定义形状：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example4_image](custom_shape_4.png)

## **创建带有圆角的自定义形状**
此 JavaScript 代码演示如何创建带有圆角（向内）的自定义形状；
```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
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
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **确定形状几何是否闭合**
闭合形状是指其所有边都相连，形成单一的、没有间隙的边界。该形状可以是简单的几何图形，也可以是复杂的自定义轮廓。下面的代码示例展示了如何检查形状几何是否闭合：
```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```


## **将 GeometryPath 转换为 java.awt.Shape** 

1. 创建 [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryShape) 类的实例。
2. 创建 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 类的实例。
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeUtil) 将 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) 实例转换为 [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/GeometryPath) 实例。
4. 将路径应用于形状。

此 JavaScript 代码——实现上述步骤——演示了 **GeometryPath** 到 **GraphicsPath** 的转换过程：
```javascript
var pres = new aspose.slides.Presentation();
try {
    // 创建新形状
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // 获取形状的几何路径
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // 使用文本创建新的图形路径
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // 将图形路径转换为几何路径
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // 将新几何路径与原始几何路径的组合设置到形状
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![example5_image](custom_shape_5.png)

## **FAQ**

**替换几何后填充和轮廓会怎样？**

样式仍然保留在形状上；仅轮廓会改变。填充和轮廓会自动应用到新的几何上。

**如何在旋转自定义形状时一起旋转其几何？**

使用形状的 [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setrotation/) 方法；几何会随形状一起旋转，因为它绑定在形状自身的坐标系上。

**我可以将自定义形状转换为图像以“锁定”结果吗？**

可以。将所需的 [slide](/slides/zh/nodejs-java/convert-powerpoint-to-png/) 区域或 [shape](/slides/zh/nodejs-java/create-shape-thumbnails/) 本身导出为栅格格式，这样可以简化对复杂几何的后续处理。