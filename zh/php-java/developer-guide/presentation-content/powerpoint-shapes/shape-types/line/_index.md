---
title: 直线
type: docs
weight: 50
url: /php-java/Line/
---


{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 支持向幻灯片添加不同类型的形状。在本主题中，我们将通过向幻灯片添加线条来开始处理形状。使用 Aspose.Slides for PHP via Java，开发人员不仅可以创建简单的直线，还可以在幻灯片上绘制一些花哨的线条。

{{% /alert %}} 

## **创建简单直线**

要向演示文稿的选定幻灯片添加一条简单的直线，请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 通过使用其索引获得幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 对象提供的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加类型为线的自动形状。
- 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一条线。

```php
  # 实例化表示 PPTX 文件的 PresentationEx 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加类型为线的自动形状
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 将 PPTX 写入磁盘
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **创建箭头形状的直线**

Aspose.Slides for PHP via Java 还允许开发人员配置线条的一些属性，以使其看起来更具吸引力。让我们尝试配置几条线的属性，使其看起来像箭头。请按照以下步骤操作：

- 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
- 通过使用其索引获得幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 对象提供的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加类型为线的自动形状。
- 将 [线条样式](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) 设置为 Aspose.Slides for PHP via Java 提供的某种样式。
- 设置线条的宽度。
- 将 [虚线样式](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) 设置为 Aspose.Slides for PHP via Java 提供的某种样式。
- 设置线条的起始点的 [箭头头样式](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) 和 [长度](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength)。
- 设置线条的终点的 [箭头头样式](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadStyle) 和 [长度](https://reference.aspose.com/slides/php-java/aspose.slides/LineArrowheadLength)。
- 将修改后的演示文稿写入 PPTX 文件。

```php
  # 实例化表示 PPTX 文件的 PresentationEx 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加类型为线的自动形状
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 在直线上应用一些格式
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