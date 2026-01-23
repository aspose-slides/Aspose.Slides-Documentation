---
title: 在 PHP 中向演示文稿添加线形状
linktitle: 线条
type: docs
weight: 50
url: /zh/php-java/Line/
keywords:
- 线条
- 创建线条
- 添加线条
- 普通线条
- 配置线条
- 定制线条
- 虚线样式
- 箭头
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "学习使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中操作线条格式。了解属性、方法和示例。"
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 支持向幻灯片添加不同类型的形状。在本主题中，我们将通过向幻灯片添加线条开始使用形状。使用 Aspose.Slides for PHP via Java，开发人员不仅可以创建简单的线条，还可以在幻灯片上绘制一些精美的线条。

{{% /alert %}} 

## **创建普通直线**

要向演示文稿的选定幻灯片添加一条简单的普通直线，请按以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) 方法添加 Line 类型的 AutoShape。
- 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们已向演示文稿的第一张幻灯片添加了一条线。

```php
  # 实例化表示 PPTX 文件的 PresentationEx 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加类型为 line 的 AutoShape
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 将 PPTX 写入磁盘
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **创建箭头形线条**

Aspose.Slides for PHP via Java 还允许开发人员配置线条的某些属性，使其更具吸引力。让我们尝试配置线条的几个属性，使其呈现为箭头。请按以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 通过使用索引获取幻灯片的引用。
- 使用 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) 方法添加 Line 类型的 AutoShape。
- 将 [Line Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) 设置为 Aspose.Slides for PHP via Java 提供的样式之一。
- 设置线条的宽度。
- 将线条的 [Dash Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) 设置为 Aspose.Slides for PHP via Java 提供的样式之一。
- 设置线条起点的 [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength)。
- 设置线条终点的 [Arrow Head Style](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) 和 [Length](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength)。
- 将修改后的演示文稿写入 PPTX 文件。

```php
  # 实例化表示 PPTX 文件的 PresentationEx 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加类型为 line 的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 对线条应用一些格式设置
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

**我可以将普通线转换为连接线使其“捕捉”到形状吗？**

否。普通线（类型为 [Line](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)）不会自动成为连接线。要使其捕捉到形状，请使用专用的 [Connector](https://reference.aspose.com/slides/php-java/aspose.slides/connector/) 类型以及用于连接的 [corresponding APIs](/slides/zh/php-java/connector/)。

**如果线条的属性继承自主题，且很难确定最终值，我该怎么办？**

通过 `LineFormatEffectiveData`/`LineFillFormatEffectiveData` 查看 [Read the effective properties](/slides/zh/php-java/shape-effective-properties/) ——这些已经考虑了继承和主题样式。

**我可以锁定线条以防止编辑（移动、调整大小）吗？**

是的。形状提供了 [lock objects](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/getautoshapelock/)，可以禁止编辑操作。