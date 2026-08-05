---
title: 在 PHP 中向演示文稿添加线形状
linktitle: 线条
type: docs
weight: 50
url: /zh/php-java/line/
keywords:
- 线条
- 创建线条
- 添加线条
- 普通线
- 配置线条
- 自定义线条
- 虚线样式
- 箭头
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "学习使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中操作线条格式。了解属性、方法和示例。"
---
## **概述**

Aspose.Slides 允许您以编程方式向 PowerPoint 幻灯片添加线形状。本文展示了如何创建一条简单的线以及如何自定义线使其显示为箭头。

您将学习如何向幻灯片添加线形状、调整其外观并保存更新后的演示文稿。示例侧重于实用的线条格式设置，如样式、宽度、虚线模式、箭头选项和填充颜色。

## **创建普通直线**

要在演示文稿的选定幻灯片上添加一条简单的普通直线，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/#addAutoShape) 方法添加线类型的 AutoShape。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们已向演示文稿的第一张幻灯片添加了一条线。

```php
  # 实例化表示 PPTX 文件的 PresentationEx 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加类型为线的 AutoShape
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 将 PPTX 写入磁盘
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **创建箭头形状的线**

Aspose.Slides for PHP via Java 还允许开发人员配置线的某些属性，使其外观更具吸引力。让我们尝试配置线的几个属性，使其看起来像箭头。请按照以下步骤进行操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapecollection/#addAutoShape) 方法添加线类型的 AutoShape。
- 将 [Line Style](https://reference.aspose.com/slides/zh/php-java/aspose.slides/LineStyle) 设置为 Aspose.Slides for PHP via Java 提供的样式之一。
- 设置线的宽度。
- 将线的 [Dash Style](https://reference.aspose.com/slides/zh/php-java/aspose.slides/LineDashStyle) 设置为 Aspose.Slides for PHP via Java 提供的样式之一。
- 设置线起点的 [Arrow Head Style](https://reference.aspose.com/slides/zh/php-java/aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/zh/php-java/aspose.slides/LineArrowheadLength)。
- 设置线终点的 [Arrow Head Style](https://reference.aspose.com/slides/zh/php-java/aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/zh/php-java/aspose.slides/LineArrowheadLength)。
- 将修改后的演示文稿写入为 PPTX 文件。

```php
  # 实例化表示 PPTX 文件的 PresentationEx 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加类型为线的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 对线进行一些格式设置
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # 将 PPTX 写入磁盘
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常见问题**

**我可以将普通线转换为连接器，使其“捕捉”到形状吗？**

不可以。普通线（类型为 [Line](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/)）不会自动变为连接器。若要使其捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/zh/php-java/aspose.slides/connector/) 类型以及用于连接的 [corresponding APIs](/slides/zh/php-java/connector/)。

**如果线的属性是从主题继承的，且难以确定最终值，我该怎么办？**

通过 `LineFormatEffectiveData`/`LineFillFormatEffectiveData` [Read the effective properties](/slides/zh/php-java/shape-effective-properties/)——这些已经考虑了继承和主题样式。

**我可以锁定线以防止编辑（移动、调整大小）吗？**

可以。形状提供了 [lock objects](https://reference.aspose.com/slides/zh/php-java/aspose.slides/autoshape/getautoshapelock/)，可让您禁止编辑操作。