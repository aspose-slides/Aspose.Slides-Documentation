---
title: 形状格式化
type: docs
weight: 20
url: /zh/php-java/shape-formatting/
keywords: "格式化形状, 格式化线条, 格式化连接样式, 渐变填充, 图案填充, 图片填充, 实心颜色填充, 旋转形状, 3d 倾斜效果, 3d 旋转效果, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "在 PowerPoint 演示文稿中格式化形状"
---

在 PowerPoint 中，您可以向幻灯片添加形状。由于形状是由线条组成的，因此您可以通过修改或应用某些效果来格式化形状。此外，您还可以通过指定设置来格式化形状，从而确定它们（它们内部的区域）是如何填充的。

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides for PHP via Java** 提供了允许您根据 PowerPoint 中已知选项格式化形状的接口和属性。

## **格式化线条**

使用 Aspose.Slides，您可以为形状指定首选的线条样式。以下步骤概述了此过程：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)。
4. 为形状线条设置颜色。
5. 为形状线条设置宽度。
6. 为形状线条设置 [线条样式](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle)。
7. 为形状线条设置 [虚线样式](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle)。
8. 将修改后的演示文稿写入一个 PPTX 文件。

以下 PHP 代码演示了格式化矩形 `AutoShape` 的操作：

```php
  # 实例化表示演示文稿文件的演示文稿类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的自动形状
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
    # 为矩形形状设置填充颜色
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # 对矩形的线条应用一些格式
    $shp->getLineFormat()->setStyle(LineStyle->ThickThin);
    $shp->getLineFormat()->setWidth(7);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->Dash);
    # 设置矩形线条的颜色
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # 将 PPTX 文件写入磁盘
    $pres->save("RectShpLn_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **格式化连接样式**

这些是 3 种连接类型选项：

* 圆形
* 斜接
* 斜面

默认情况下，当 PowerPoint 以角度连接两条线（或形状的角）时，使用**圆形**设置。然而，如果您希望绘制一个非常锋利角度的形状，您可能希望选择**斜接**。

![join-style-powerpoint](join-style-powerpoint.png)

此 Java 代码演示了使用斜接、斜面和圆形连接类型设置创建 3 个矩形的操作（上图）：

```php
  # 实例化表示演示文稿文件的演示文稿类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加 3 个矩形自动形状
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 150, 75);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
    $shp3 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);
    # 为矩形形状设置填充颜色
    $shp1->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp3->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # 设置线条的宽度
    $shp1->getLineFormat()->setWidth(15);
    $shp2->getLineFormat()->setWidth(15);
    $shp3->getLineFormat()->setWidth(15);
    # 设置矩形线条的颜色
    $shp1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # 设置连接样式
    $shp1->getLineFormat()->setJoinStyle(LineJoinStyle->Miter);
    $shp2->getLineFormat()->setJoinStyle(LineJoinStyle->Bevel);
    $shp3->getLineFormat()->setJoinStyle(LineJoinStyle->Round);
    # 向每个矩形添加文本
    $shp1->getTextFrame()->setText("斜接连接样式");
    $shp2->getTextFrame()->setText("斜面连接样式");
    $shp3->getTextFrame()->setText("圆形连接样式");
    # 将 PPTX 文件写入磁盘
    $pres->save("RectShpLnJoin_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **渐变填充**

在 PowerPoint 中，渐变填充是一种格式化选项，允许您对形状应用连续的颜色混合。例如，您可以在一种颜色逐渐消退并改变为另一种颜色的设置中应用两种或更多颜色。

以下是如何使用 Aspose.Slides 将渐变填充应用于形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) 设置为 `渐变`。
5. 使用 `GradientFormat` 类中与 `GradientStops` 集合关联的 `Add` 方法添加您首选的 2 种颜色及其定义的位置。
6. 将修改后的演示文稿写入一个 PPTX 文件。

以下 PHP 代码演示了对椭圆使用渐变填充效果的操作：

```php
  # 实例化表示演示文稿文件的演示文稿类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加椭圆自动形状
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);
    # 对椭圆应用渐变格式
    $shp->getFillFormat()->setFillType(FillType::Gradient);
    $shp->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape->Linear);
    # 设置渐变的方向
    $shp->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);
    # 添加 2 个渐变停止
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor->Purple);
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor->Red);
    # 将 PPTX 文件写入磁盘
    $pres->save("EllipseShpGrad_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **图案填充**

在 PowerPoint 中，图案填充是一种格式化选项，允许您将包含点、条纹、交叉阴影或棋盘格的两种颜色设计应用于形状。此外，您还可以选择您首选的颜色作为图案的前景色和背景色。

Aspose.Slides 提供了 45 种以上的预定义样式，可用于格式化形状并丰富演示文稿。即使在选择了预定义图案之后，您依然可以指定图案必须包含的颜色。

以下是如何使用 Aspose.Slides 将图案填充应用于形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) 设置为 `图案`。
5. 为形状设置您首选的图案样式。
6. 设置 [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat) 的 [背景颜色](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getBackColor--)。
7. 设置 [前景颜色](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getForeColor--) 的 [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat)。
8. 将修改后的演示文稿写入一个 PPTX 文件。

以下 PHP 代码演示了对矩形使用图案填充以美化的操作：

```php
  # 实例化表示演示文稿文件的演示文稿类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形自动形状
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # 设置填充类型为图案
    $shp->getFillFormat()->setFillType(FillType::Pattern);
    # 设置图案样式
    $shp->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->Trellis);
    # 设置图案的背景和前景颜色
    $shp->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shp->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);
    # 将 PPTX 文件写入磁盘
    $pres->save("RectShpPatt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **图片填充**

在 PowerPoint 中，图片填充是一种格式化选项，允许您在形状内放置图片。基本上，您可以将图片用作形状的背景。

以下是如何使用 Aspose.Slides 用图片填充形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) 设置为 `图片`。
5. 将图片填充模式设置为平铺。
6. 创建一个 `IPPImage` 对象，使用将用于填充形状的图片。
7. 将`Picture.Image`属性的 `PictureFillFormat` 对象设置为最近创建的 `IPPImage`。
8. 将修改后的演示文稿写入一个 PPTX 文件。

以下 PHP 代码演示了如何用图片填充形状：

```php
  # 实例化表示演示文稿文件的演示文稿类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形自动形状
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # 设置填充类型为图片
    $shp->getFillFormat()->setFillType(FillType::Picture);
    # 设置图片填充模式
    $shp->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Tile);
    # 设置图片
    $picture;
    $image = Images->fromFile("Tulips.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $shp->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # 将 PPTX 文件写入磁盘
    $pres->save("RectShpPic_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **实心颜色填充**

在 PowerPoint 中，实心颜色填充是一种格式化选项，允许您用单一颜色填充形状。所选颜色通常是一种纯颜色。该颜色被应用于形状的背景，带有任何特殊效果或修改。

以下是如何使用 Aspose.Slides 将实心颜色填充应用于形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)。
4. 将形状的 [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) 设置为 `实心`。
5. 为形状设置您首选的颜色。
6. 将修改后的演示文稿写入一个 PPTX 文件。

以下 PHP 代码演示了如何将实心颜色填充应用于 PowerPoint 中的一个框：

```php
  # 实例化表示演示文稿文件的演示文稿类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加矩形自动形状
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # 设置填充类型为实心
    $shape->getFillFormat()->setFillType(FillType::Solid);
    # 设置矩形的颜色
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # 将 PPTX 文件写入磁盘
    $pres->save("RectShpSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置透明度**

在 PowerPoint 中，当您用实心颜色、渐变、图片或纹理填充形状时，可以指定透明度水平，以确定填充的不透明度。例如，如果您设置较低的透明度级别，则幻灯片对象或背景（形状）将在后面显示。

Aspose.Slides 允许您以这种方式设置形状的透明度级别：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)。
4. 使用带有 alpha 组件设置的新颜色。
5. 将对象保存为 PowerPoint 文件。

以下 PHP 代码演示了该过程：

```php
  # 实例化表示演示文稿文件的演示文稿类
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 添加实心形状
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);
    # 在实心形状上添加透明形状
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 204, 102, 0, 128));
    # 将 PPTX 文件写入磁盘
    $pres->save("ShapeTransparentOverSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **旋转形状**

Aspose.Slides 允许您按以下方式旋转添加到幻灯片的形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)。
4. 将形状旋转所需的角度。
5. 将修改后的演示文稿写入一个 PPTX 文件。

以下 PHP 代码演示了如何将形状旋转 90 度：

```php
  # 实例化表示演示文稿文件的演示文稿类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形自动形状
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # 将形状旋转 90 度
    $shp->setRotation(90);
    # 将 PPTX 文件写入磁盘
    $pres->save("RectShpRot_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **添加 3D 倾斜效果**

Aspose.Slides 允许您通过修改其 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) 属性按以下方式向形状添加 3D 倾斜效果：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)。
4. 为形状的 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) 属性设置首选参数。
5. 将演示文稿写入磁盘。

以下 PHP 代码演示了如何向形状添加 3D 倾斜效果：

```php
  # 创建演示文稿类的实例
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 向幻灯片添加形状
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 30, 30, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $format = $shape->getLineFormat()->getFillFormat();
    $format->setFillType(FillType::Solid);
    $format->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);
    # 设置形状的 ThreeDFormat 属性
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    # 将演示文稿保存为 PPTX 文件
    $pres->save("Bavel_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **添加 3D 旋转效果**

Aspose.Slides 允许您通过修改其 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) 属性以这种方式将 3D 旋转效果应用于形状：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
2. 通过其索引获取幻灯片的引用。
3. 向幻灯片添加一个 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape)。
4. 为 [CameraType](https://reference.aspose.com/slides/php-java/aspose.slides/ICamera#getCameraType--) 和 [LightType](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRig#getLightType--) 指定首选的数值。
5. 将演示文稿写入磁盘。

以下 PHP 代码演示了如何将 3D 旋转效果应用于形状：

```php
  # 创建演示文稿类的实例
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Line, 30, 300, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(0, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    # 将演示文稿保存为 PPTX 文件
    $pres->save("Rotation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **重置格式**

以下 PHP 代码演示了如何重置幻灯片中的格式，并将每个在 [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutSlide) 上具有占位符的形状的位置、大小和格式恢复到默认值：

```php
  $pres = new Presentation();
  try {
    foreach($pres->getSlides() as $slide) {
      # 幻灯片上每个具有布局占位符的形状将被恢复
      $slide->reset();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```