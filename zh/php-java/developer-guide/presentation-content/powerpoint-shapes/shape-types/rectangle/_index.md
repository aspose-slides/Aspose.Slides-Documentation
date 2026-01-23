---
title: 在 PHP 中向演示文稿添加矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh/php-java/rectangle/
keywords:
- 添加矩形
- 创建矩形
- 矩形形状
- 简单矩形
- 格式化矩形
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Aspose.Slides for PHP via Java 为您的 PowerPoint 演示文稿添加矩形——轻松实现形状的程序化设计和修改。"
---

{{% alert color="primary" %}} 

与之前的主题一样，本主题也关于添加形状，这次我们讨论的形状是 **矩形**。在本主题中，我们描述了开发人员如何使用 Aspose.Slides for PHP via Java 向幻灯片添加简单或格式化的矩形。

{{% /alert %}} 

## **向幻灯片添加矩形**
要在演示文稿的选定幻灯片上添加一个简单矩形，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 通过 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，添加类型为 Rectangle 的 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
- 将修改后的演示文稿写入为 PPTX 文件。

在下面的示例中，我们向演示文稿的第一张幻灯片添加了一个简单矩形。
```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加椭圆类型的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # 将 PPTX 文件写入磁盘
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **向幻灯片添加格式化矩形**
要向幻灯片添加格式化矩形，请按以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 使用索引获取幻灯片的引用。
- 通过 [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addAutoShape) 方法，添加类型为 Rectangle 的 [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)。
- 将矩形的 [Fill Type](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) 设置为 Solid（实心）。
- 使用与 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 对象关联的 [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) 对象公开的 [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) 方法，为矩形设置颜色。
- 设置矩形边框的颜色。
- 设置矩形边框的宽度。
- 将修改后的演示文稿写入为 PPTX 文件。

上述步骤在下面的示例中实现。
```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加椭圆类型的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # 对椭圆形状应用一些格式设置
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # 对椭圆的线条应用一些格式设置
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # 将 PPTX 文件写入磁盘
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**如何添加圆角矩形？**

使用圆角 [shape type](https://reference.aspose.com/slides/php-java/aspose.slides/shapetype/) 并在形状属性中调整角半径；也可以通过几何调整对每个角单独进行圆角处理。

**如何使用图像（纹理）填充矩形？**

选择图片 [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/)，提供图像源，并配置 [stretching/tiling modes](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/)。

**矩形可以使用阴影和光晕吗？**

可以。可通过 [Outer/inner shadow, glow, and soft edges](/slides/zh/php-java/shape-effect/) 添加外阴影、内阴影、光晕和柔边，并可调整参数。

**我可以将矩形转换为带超链接的按钮吗？**

可以。通过 [Assign a hyperlink](/slides/zh/php-java/manage-hyperlinks/) 为形状点击分配超链接（跳转到幻灯片、文件、网页地址或电子邮件）。

**如何保护矩形不被移动或修改？**

使用形状锁定：可以禁止移动、调整大小、选择或文本编辑，以保持布局。

**可以将矩形转换为位图或 SVG 吗？**

可以。您可以将 [shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) 渲染为具有指定尺寸/比例的图像，或将其 [export it as SVG](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) 用于矢量。

**如何快速获取考虑主题和继承的矩形实际（有效）属性？**

使用 [shape’s effective properties](/slides/zh/php-java/shape-effective-properties/)：API 返回已计算的值，考虑了主题样式、布局和本地设置，从而简化格式分析。