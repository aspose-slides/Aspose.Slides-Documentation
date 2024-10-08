---
title: 自定义形状
type: docs
weight: 20
url: /zh/php-java/custom-shape/
keywords: "PowerPoint 形状，自定义形状，PowerPoint 演示文稿，Java，Aspose.Slides for PHP via Java"
description: "在 PowerPoint 演示文稿中添加自定义形状"
---

# 使用编辑点更改形状
考虑一个正方形。在 PowerPoint 中，使用 **编辑点**，您可以

* 将正方形的角向内或向外移动
* 指定角或点的曲率
* 向正方形添加新点
* 操纵正方形上的点等

本质上，您可以在任何形状上执行描述的任务。使用编辑点，您可以更改形状或从现有形状创建新形状。

## **形状编辑技巧**

![overview_image](custom_shape_0.png)

在通过编辑点开始编辑 PowerPoint 形状之前，您可能想考虑以下关于形状的要点：

* 形状（或其路径）可以是封闭的或开放的。
* 当形状是封闭的时，它没有起点或终点。当形状是开放的时，它有开始和结束。
* 所有形状至少由 2 个锚点通过线条连接。
* 线条可以是直线或曲线。锚点决定线的性质。
* 锚点存在为角点、直点或平滑点：
  * 角点是两条直线相交于一个角度的点。
  * 平滑点是两个手柄存在于一条直线上，且线的段在一个平滑的曲线上连接。在这种情况下，所有手柄与锚点的距离相等。
  * 直点是两个手柄存在于一条直线上，并且该线的段以平滑的曲线连接。在这种情况下，手柄与锚点的距离不必相等。
* 通过移动或编辑锚点（这会改变线的角度），您可以改变形状的外观。

要通过编辑点编辑 PowerPoint 形状，**Aspose.Slides** 提供了 [**GeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 类和 [**IGeometryPath**](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath) 接口。

* 一个 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 实例表示一个 [IGeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape) 对象的几何路径。
* 要从 `IGeometryShape` 实例中检索 `GeometryPath`，您可以使用 [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#getGeometryPaths--) 方法。
* 要为形状设置 `GeometryPath`，您可以使用以下方法： [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) 适用于 *实心形状*，而 [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) 适用于 *复合形状*。
* 要添加段，您可以使用 [IGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath) 下的方法。
* 使用 [IGeometryPath.setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setStroke-boolean-) 和 [IGeometryPath.setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#setFillMode-byte-) 方法，您可以设置几何路径的外观。
* 使用 [IGeometryPath.getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/IGeometryPath#getPathData--) 方法，您可以将 `GeometryShape` 的几何路径作为路径段数组检索。
* 要访问其他形状几何自定义选项，您可以将 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 转换为 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html)
* 使用 [geometryPathToGraphicsPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) 和 [graphicsPathToGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) 方法（来自 [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) 类）在 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 和 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) 之间进行转换。

## **简单编辑操作**

以下 PHP 代码显示您如何

**在路径末尾添加一条线**

```php

```
**在路径特定位置添加一条线：**

```php

```
**在路径末尾添加一个三次贝塞尔曲线：**

```php

```
**在路径特定位置添加一个三次贝塞尔曲线：**

```php

```
**在路径末尾添加一个二次贝塞尔曲线：**

```php

```
**在路径特定位置添加一个二次贝塞尔曲线：**

```php

```
**将给定弧附加到路径：**

```php

```
**关闭路径的当前图形：**

```php

```
**设置下一个点的位置：**

```php

```
**移除给定索引处的路径段：**

```php

```

## **向形状添加自定义点**
1. 创建 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) 类的实例并设置 [ShapeType::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) 类型。
2. 从形状中获取 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 类的实例。
3. 在路径的两个顶部点之间添加一个新点。
4. 在路径的两个底部点之间添加一个新点。
5. 将路径应用于形状。

以下 PHP 代码显示您如何向形状添加自定义点：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## 从形状中移除点

1. 创建 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) 类的实例并设置 [ShapeType::Heart](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType) 类型。
2. 从形状中获取 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 类的实例。
3. 移除路径的段。
4. 将路径应用于形状。

以下 PHP 代码显示您如何从形状中移除点：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

## **创建自定义形状**

1. 计算形状的点。
2. 创建 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 类的实例。
3. 用点填充路径。
4. 创建 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) 类的实例。
5. 将路径应用于形状。

以下 Java 显示您如何创建一个自定义形状：

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **创建复合自定义形状**

1. 创建 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) 类的实例。
2. 创建第一实例的 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 类。
3. 创建第二实例的 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 类。
4. 将路径应用于形状。

以下 PHP 代码显示您如何创建一个复合自定义形状：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **创建具有圆角的自定义形状**

以下 PHP 代码显示您如何创建一个具有圆角（向内）的自定义形状；

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将 GeometryPath 转换为 java.awt.Shape** 

1. 创建 [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryShape) 类的实例。
2. 创建 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) 类的实例。
3. 使用 [ShapeUtil](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeUtil) 将 [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) 实例转换为 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/GeometryPath) 实例。
4. 将路径应用于形状。

以下 PHP 代码—上述步骤的实现—演示了 **GeometryPath** 到 **GraphicsPath** 的转换过程：

```php
  $pres = new Presentation();
  try {
    # 创建新形状
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # 获取形状的几何路径
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # 创建带文本的新图形路径
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "形状中的文本";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # 将图形路径转换为几何路径
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # 设置新几何路径和原始几何路径的组合到形状
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)