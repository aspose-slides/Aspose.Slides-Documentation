---
title: 矩形
type: docs
weight: 80
url: /zh/php-java/rectangle/
---

{{% alert color="primary" %}} 

与之前的主题一样，这个主题也是关于添加一种形状，这次我们讨论的形状是 **矩形**。在本主题中，我们描述了开发人员如何使用 Aspose.Slides for PHP 通过 Java 将简单或格式化的矩形添加到他们的幻灯片中。

{{% /alert %}} 

## **将矩形添加到幻灯片**
要将简单的矩形添加到所选的演示文稿幻灯片，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加一个矩形类型的 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)。
- 将修改后的演示文稿写入 PPTX 文件。

在下面的示例中，我们将一个简单的矩形添加到演示文稿的第一张幻灯片。

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

## **将格式化的矩形添加到幻灯片**
要将格式化的矩形添加到幻灯片，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 对象公开的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，添加一个矩形类型的 [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)。
- 将矩形的 [填充类型](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) 设置为实心。
- 使用 [SolidFillColor.setColor](https://reference.aspose.com/slides/php-java/aspose.slides/IColorFormat#setColor-java.awt.Color-) 方法设置矩形的颜色，该方法由与 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) 对象关联的 [IFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) 对象公开。
- 设置矩形线条的颜色。
- 设置矩形线条的宽度。
- 将修改后的演示文稿写入 PPTX 文件。

上述步骤在下面的示例中得到了实现。

```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加椭圆类型的 AutoShape
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # 对椭圆形状应用一些格式
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # 对椭圆的线条应用一些格式
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