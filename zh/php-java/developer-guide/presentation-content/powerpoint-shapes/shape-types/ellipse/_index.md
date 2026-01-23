---
title: 在 PHP 中向演示文稿添加椭圆
linktitle: 椭圆
type: docs
weight: 30
url: /zh/php-java/ellipse/
keywords:
- 椭圆
- 形状
- 添加椭圆
- 创建椭圆
- 绘制椭圆
- 格式化椭圆
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中创建、格式化和操作椭圆形状，适用于 PPT 和 PPTX 演示文稿 —— 并附有代码示例。"
---

{{% alert color="primary" %}} 

在本主题中，我们将向开发人员介绍如何使用 Aspose.Slides for PHP via Java 向幻灯片添加椭圆形。Aspose.Slides for PHP via Java 提供了一组更简便的 API，只需几行代码即可绘制各种形状。

{{% /alert %}} 

## **创建椭圆**
要在演示文稿的选定幻灯片中添加一个简单的椭圆，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 使用其索引获取幻灯片的引用。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 对象提供的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，添加一种椭圆类型的 AutoShape。
- 将修改后的演示文稿保存为 PPTX 文件。

在下面的示例中，我们已在第一张幻灯片中添加了一个椭圆
```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加椭圆类型的 AutoShape
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # 将 PPTX 文件写入磁盘
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **创建格式化的椭圆**
要在幻灯片中添加格式更好的椭圆，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 使用其索引获取幻灯片的引用。
- 使用由 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 对象提供的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，添加一种椭圆类型的 AutoShape。
- 将椭圆的填充类型设置为实心。
- 使用 `SolidFillColor::setColor` 方法（由关联的 [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 对象提供）设置椭圆的颜色。
- 设置椭圆线条的颜色。
- 设置椭圆线条的宽度。
- 将修改后的演示文稿保存为 PPTX 文件。

在下面的示例中，我们已在演示文稿的第一张幻灯片中添加了一个格式化的椭圆。
```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加椭圆类型的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # 对椭圆形状应用一些格式设置
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # 对椭圆的线条应用一些格式设置
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # 将 PPTX 文件写入磁盘
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**如何根据幻灯片的单位设置椭圆的精确位置和大小？**

坐标和尺寸通常以 **点** 为单位指定。为了获得可预期的结果，请基于幻灯片尺寸进行计算，并在赋值前将所需的毫米或英寸转换为点。

**如何将椭圆放置在其他对象之上或之下（控制堆叠顺序）？**

通过将对象置于前面或发送到后面来调整其绘制顺序。这可以使椭圆覆盖其他对象或显示其下方的对象。

**如何为椭圆添加出现或强调的动画？**

使用 [应用](/slides/zh/php-java/shape-animation/) 为形状添加进入、强调或退出效果，并配置触发器和时间来安排动画的播放时机和方式。