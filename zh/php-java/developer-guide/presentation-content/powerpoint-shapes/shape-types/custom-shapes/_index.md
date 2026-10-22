---
title: 在 PHP 中自定义演示文稿形状
linktitle: 自定义形状
type: docs
weight: 20
url: /zh/php-java/custom-shape/
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
- 删除点
- 编辑操作
- 圆角
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中创建和自定义形状：几何路径、圆角、复合形状。"
---
## **概述**

本文介绍了如何通过编辑点和几何路径来自定义 Aspose.Slides 中的演示文稿形状几何。它展示了如何使用 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 修改现有形状、执行基本的路径编辑操作、添加或删除点，并将更新后的几何应用回形状。

本文还演示了如何创建自定义和复合形状、构建带圆角的形状、判断形状几何是否闭合、检查形状元素，以及将 Java AWT 文本轮廓转换为几何路径。

## **使用编辑点更改形状**

在 PowerPoint 中，您可以使用 **编辑点** 来修改正方形：

* 将角向内或向外移动。
* 调整点处的曲率。
* 添加新点。

编辑点可让您修改形状的轮廓，或以现有形状为基础创建新形状。

## **形状编辑技巧**

![概览图](custom_shape_0.png)

编辑 PowerPoint 形状时，请记住以下概念：

* 形状（或其路径）可以是闭合的，也可以是开放的。
* 形状的路径由锚点和连接它们的段组成。
* 段可以是直线或曲线。锚点和控制手柄决定其形状。
* 锚点有三种形式：拐角点、直线点或平滑点：
  * 在拐角点，相邻段可以形成角度。
  * 在平滑点，两个控制手柄共线且与锚点的距离相等。
  * 在直线点，两个控制手柄共线，但与锚点的距离可以不同。
* 移动锚点或调整其手柄会改变形状的轮廓。

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 类。

* 一个 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 实例表示 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 对象的几何路径。
* 要从 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 实例获取 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)，可以使用 [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) 方法。
* 要为形状设置 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)，可以使用以下方法：单路径形状使用 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath)；多路径形状使用 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths)。
* 要添加段，可使用 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 下的相应方法。
* 使用 [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) 和 [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) 方法，可设置几何路径的外观。
* 使用 [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) 方法，可将 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) 的几何路径检索为路径段数组。
* 若要访问其他形状几何自定义选项，可通过读取 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 的 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 并在 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 上重放段来实现。

## **简单编辑操作**

使用以下方法编辑几何路径。接受索引的重载将在路径段数组的零基位置插入段。

| 操作 | 方法 |
| --- | --- |
| 追加或插入直线段。 | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| 追加或插入带两个控制点和终点的三次贝塞尔曲线。 | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| 追加或插入带一个控制点和终点的二次贝塞尔曲线。 | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| 追加具有指定尺寸和角度（以度为单位）的椭圆弧。 | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| 通过将端点连接到起点来关闭当前图形。 | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| 设置图形的起始点。 | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| 删除零基索引处的段。 | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **向形状添加自定义点**

此示例使用 [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) 向矩形形状插入两个点，并使用 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 应用编辑后的路径。坐标相对于形状本身：两个新点位于形状中心，左侧 100 点、顶部 50 点。段索引 1 和 4 将它们放在顶部和底部边缘，向内拉动这些边缘。

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![示例1图](custom_shape_1.png)

## **从形状中移除点**

此示例通过使用 [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) 删除零基索引 2 处的段来更改心形轮廓。使用 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 应用修改后的路径后，形状轮廓将被更新。

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![示例2图](custom_shape_2.png)

## **创建自定义形状**

此示例使用 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 构建一个五角星。外半径 100 点、内半径 50 点交替定义尖端和凹陷；每隔 72 度放置一个尖端，使五个尖端均匀分布。路径通过 [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) 闭合，并使用 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 应用于矩形形状，替换其轮廓。

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![示例3图](custom_shape_3.png)

## **创建复合自定义形状**

此示例为形状的上三分之一和下三分之一定义了两个闭合的 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 对象。使用 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 同时应用两个路径，可创建一个在中间三分之一处有间隙的单一复合形状。

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![示例4图](custom_shape_4.png)

## **创建带圆角的自定义形状**

此示例将直线段与 [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) 结合，创建一个内凹圆角的形状。每个角的大小决定了弧的宽度和高度（单位为点），-90 度的扫掠角绘制逆时针四分之一椭圆。完成的路径通过 [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 应用，演示文稿以 PPTX 格式保存。

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **判断形状几何是否闭合**

以下帮助程序检查每个非空几何路径是否以闭合段结束。它读取 [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData)，并将最终段的 [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) 与 [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) 进行比较。当不存在非空路径时返回 false。该检查仅针对每条路径的最后指令，不会检查路径内部的每个子图形。示例对矩形输出 `true`。

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **提取并检查形状元素**

使用 [GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) 可将现有形状检查为包含路径点和点类型的元素。对每个返回的 [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) 使用 [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) 与 [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) 方法检索点数组和类型数组。此表示形式对轮廓分析或将几何传递给自定义绘图工具非常有用。

示例打开 `input.pptx`，在第一张幻灯片上直接查找第一个几何形状，并打印其路径段。使用包含直线段和曲线段的形状进行演示，以观察两种输出。该示例不在组内部搜索。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // 保留段类型，排除标志。
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // 消耗两个控制点和终点。
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

数组通过索引对应：`$points[$i]` 为点，`$types[$i]` 描述其角色。类型 `0` 表示开始一个图形，类型 `1` 表示从前一点到当前点绘制直线。三次贝塞尔段从前一个端点开始，使用连续的三个类型 `3` 条目：两个控制点随后是新的端点。循环一次性消费这三个条目并检查端点是否闭合。

点类型还包含标志。使用 `0x07` 掩码可识别段类型，单独检测 `0x80` 可判断是否闭合子路径。例如，`129`（`0x81`）表示闭合的直线端点，`131`（`0x83`）表示闭合的贝塞尔端点。PHP/Java Bridge 将字节数组返回为二进制字符串；使用 `"C*"` 解包可得到无符号字节值。掩码保留了预期的位值，仅比较原始值为 `1` 或 `3` 会遗漏这些情况。其他标志，如虚线 (`0x10`) 和标记 (`0x20`)，不会改变基础段类型。

**坐标与变换。** 点的单位为点（1/72 英寸），X 向右递增，Y 向下递增。对于未分组的形状，提取的坐标已包含由 [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) 和 [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) 返回的位置，并反映当前宽高。例如，未旋转的矩形位于 `(100, 200)`，大小为 `120 × 80`，其轮廓边界为 `(100, 200)`–`(220, 280)`。请勿再次加上形状的位置。应减去其 X 与 Y，以获得相对于未旋转框架的坐标。

提取的点不考虑由 [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) 返回的形状旋转，或水平、垂直翻转。若要恢复显示的轮廓，需要围绕形状中心应用这些变换。对于分组形状，还需考虑组坐标映射和变换；不要假设提取的点已经是最终渲染的幻灯片坐标，亦不要在已经在子框架中体现的情况下再次平移或缩放。

**检查与编辑的区别。** 提取的数组仅描述轮廓，修改它们不会更新原始形状。当您的分析或绘图代码需要点/类型数组时使用此方法。若需要在形状本地坐标系中获取几何指令或编辑几何，请使用 [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths)。编辑后通过 [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) 或 [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 应用。

## **将 Java AWT Shape 转换为 GeometryPath**

此示例将矩形轮廓与转换后的文本结合。轮廓的 [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) 方法关闭填充。[GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) 在 [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) 中创建文本轮廓。其 [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) 提供移动、直线、二次、三次和闭合段，示例将这些段重新播放到 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 上。

示例使用 Java 浮点数组，以便 PHP/Java Bridge 保留迭代器写入的坐标。文本使用 40 点 Arial 字体。轮廓水平偏移 20 点，视觉顶部位于形状顶部以下 10 点。文本路径填充，而原始矩形保持轮廓。通过 [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) 同时应用两条路径，生成包含矩形和文本的单一形状。

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![示例5图](custom_shape_5.png)

## **常见问题**

**替换几何后，填充和轮廓会怎样？**

样式仍然保留在形状上，只是轮廓发生了改变。填充和轮廓会自动应用到新几何上。

**如何在旋转自定义形状时同时旋转其几何？**

使用形状的 [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) 方法；几何会随形状一起旋转，因为它绑定到形状自身的坐标系。

**能否将自定义形状转换为图像以“锁定”结果？**

可以。将所需的 [slide](/slides/zh/php-java/convert-powerpoint-to-png/) 区域或 [shape](/slides/zh/php-java/create-shape-thumbnails/) 本身导出为栅格格式，这样可简化后续对复杂几何的处理。