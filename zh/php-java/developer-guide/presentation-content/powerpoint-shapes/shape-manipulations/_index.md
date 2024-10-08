---
title: 形状操作
type: docs
weight: 40
url: /php-java/shape-manipulations/
---

## **在幻灯片中查找形状**
本主题将描述一种简单的技术，使开发人员能够在幻灯片上更容易找到特定形状，而无需使用其内部 ID。重要的是要知道，PowerPoint 演示文稿文件没有任何方法可以通过内部唯一 ID 识别幻灯片上的形状。对于开发人员而言，使用内部唯一 ID 查找形状似乎很困难。所有添加到幻灯片上的形状都有一些替代文本。我们建议开发人员使用替代文本来查找特定形状。您可以使用 MS PowerPoint 为您计划在未来更改的对象定义替代文本。

在设置任何所需形状的替代文本后，您可以通过 Aspose.Slides for PHP 通过 Java 打开该演示文稿，并遍历添加到幻灯片上的所有形状。在每次迭代中，您可以检查形状的替代文本，具有匹配替代文本的形状将是您所需的形状。为了更好地演示这种技术，我们创建了一个方法，[findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)，可以找到幻灯片中的特定形状，然后简单地返回该形状。

```php
  # 实例化表示演示文稿文件的 Presentation 类
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 要查找的形状的替代文本
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("形状名称: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **克隆形状**
要使用 Aspose.Slides for PHP 通过 Java 将形状克隆到幻灯片中：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过使用其索引获取幻灯片的引用。
1. 访问源幻灯片形状集合。
1. 将新幻灯片添加到演示文稿中。
1. 从源幻灯片形状集合克隆形状到新幻灯片中。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例将组形状添加到幻灯片中。

```php
  # 实例化 Presentation 类
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # 将 PPTX 文件写入磁盘
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **删除形状**
Aspose.Slides for PHP 通过 Java 允许开发人员删除任何形状。要从任何幻灯片中删除形状，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定替代文本的形状。
1. 删除该形状。
1. 将文件保存到磁盘。

```php
  # 创建 Presentation 对象
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的自动形状
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "用户定义";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # 将演示文稿保存到磁盘
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **隐藏形状**
Aspose.Slides for PHP 通过 Java 允许开发人员隐藏任何形状。要从任何幻灯片中隐藏形状，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定替代文本的形状。
1. 隐藏该形状。
1. 将文件保存到磁盘。

```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的自动形状
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "用户定义";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # 将演示文稿保存到磁盘
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **改变形状的顺序**
Aspose.Slides for PHP 通过 Java 允许开发人员重新排序形状。重新排序形状指定哪个形状在前或哪个形状在后。要从任何幻灯片中重新排序形状，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 添加另一个具有相同坐标的形状。
1. 重新排序形状。
1. 将文件保存到磁盘。

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("水印文本 水印文本 水印文本");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取 Interop 形状 ID**
Aspose.Slides for PHP 通过 Java 允许开发人员获取在幻灯片范围内的唯一形状标识符，与 [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--) 方法不同，该方法允许获得在演示文稿范围内的唯一标识符。[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) 方法已添加到 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) 接口和 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) 类中。 [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--) 方法返回的值对应于 Microsoft.Office.Interop.PowerPoint.Shape 对象的 ID 值。下面给出了示例代码。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 在幻灯片范围内获取唯一形状标识符
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置形状的替代文本**
Aspose.Slides for PHP 通过 Java 允许开发人员为任何形状设置替代文本。
演示文稿中的形状可以通过 [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) 或 [形状名称](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-) 方法进行区分。
[setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) 和 [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) 方法可以通过 Aspose.Slides 和 Microsoft PowerPoint 读取或设置。
通过这种方法，您可以标记形状并执行不同的操作，如删除形状、隐藏形状或在幻灯片上重新排序形状。
要设置形状的替代文本，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 向幻灯片添加任意形状。
1. 对新添加的形状进行一些操作。
1. 遍历形状以查找形状。
1. 设置替代文本。
1. 将文件保存到磁盘。

```php
  # 实例化表示 PPTX 的 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形类型的自动形状
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("用户定义");
      }
    }
    # 将演示文稿保存到磁盘
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **访问形状的布局格式**
Aspose.Slides for PHP 通过 Java 提供了一个简单的 API 来访问形状的布局格式。本文演示了如何访问布局格式。

下面给出了示例代码。

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **将形状渲染为 SVG**
现在，Aspose.Slides for PHP 通过 Java 支持将形状渲染为 SVG。方法 [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) （及其重载）已添加到 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) 类和 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) 接口。该方法允许将形状的内容保存为 SVG 文件。下面的代码片段演示如何将幻灯片的形状导出为 SVG 文件。

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **形状对齐**
Aspose.Slides 允许根据幻灯片边距或相互之间对齐形状。为此，已添加重载方法 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)。 [ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) 枚举定义了可能的对齐选项。

**示例 1**

下面的源代码将索引为 1、2 和 4 的形状沿幻灯片的顶部边界对齐。

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**示例 2**

下面的示例展示了如何使整个形状集合相对于集合中的最底部形状对齐。

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```