---
title: 椭圆
type: docs
weight: 30
url: /php-java/ellipse/
---


{{% alert color="primary" %}} 

在本主题中，我们将向开发人员介绍如何使用 Aspose.Slides for PHP via Java 将椭圆形状添加到他们的幻灯片中。Aspose.Slides for PHP via Java 提供了一组更简单的 API，可以仅用几行代码绘制不同类型的形状。

{{% /alert %}} 

## **创建椭圆**
要将一个简单的椭圆添加到演示文稿的选定幻灯片中，请按照以下步骤进行：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 对象暴露的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加一个椭圆类型的自动形状。
- 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们已经在第一张幻灯片上添加了一个椭圆。

```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加椭圆类型的自动形状
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # 将 PPTX 文件写入磁盘
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **创建格式化椭圆**
要将一个更好格式化的椭圆添加到幻灯片中，请按照以下步骤进行：

- 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 类的实例。
- 通过使用其索引获取幻灯片的引用。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection) 对象暴露的 [addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法添加一个椭圆类型的自动形状。
- 将椭圆的填充类型设置为实心。
- 使用 [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/IFillFormat) 对象的 SolidFillColor.Color 属性设置椭圆的颜色，该对象与 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) 对象关联。
- 设置椭圆的线条颜色。
- 设置椭圆的线条宽度。
- 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们已经在演示文稿的第一张幻灯片上添加了一个格式化的椭圆。

```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加椭圆类型的自动形状
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