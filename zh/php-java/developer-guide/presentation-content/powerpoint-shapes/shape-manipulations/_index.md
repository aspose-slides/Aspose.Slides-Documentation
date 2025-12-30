---
title: 在 PHP 中管理演示文稿形状
linktitle: 形状操作
type: docs
weight: 40
url: /zh/php-java/shape-manipulations/
keywords:
- PowerPoint 形状
- 演示文稿形状
- 幻灯片上的形状
- 查找形状
- 克隆形状
- 删除形状
- 隐藏形状
- 更改形状顺序
- 获取 Interop 形状 ID
- 形状替代文本
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中创建、编辑和优化形状，并实现高性能的 PowerPoint 演示文稿。"
---

## **在幻灯片上查找形状**
本文将介绍一种简便技术，帮助开发人员在不使用内部 Id 的情况下在幻灯片上查找特定形状。需要了解的是，PowerPoint 演示文稿文件只能通过内部唯一 Id 来标识幻灯片上的形状，除此之外没有其他方式。开发人员使用内部唯一 Id 来查找形状往往比较困难。所有添加到幻灯片的形状都可以设置替代文本（Alt Text）。我们建议开发人员使用替代文本来查找特定形状。您可以在 Microsoft PowerPoint 中为以后可能更改的对象定义替代文本。

在为所需形状设置替代文本后，您可以使用 Aspose.Slides for PHP via Java 打开该演示文稿，并遍历幻灯片中所有形状。在每次遍历时检查形状的替代文本，匹配的形状即为您需要的形状。为更好地演示此技术，我们创建了一个方法[findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)，它可以在幻灯片中查找特定形状并返回该形状。
```php
  # 实例化一个表示演示文稿文件的 Presentation 类
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 要查找的形状的替代文本
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
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
要使用 Aspose.Slides for PHP via Java 将形状克隆到幻灯片：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问源幻灯片的形状集合。
1. 向演示文稿添加新幻灯片。
1. 将源幻灯片形状集合中的形状克隆到新幻灯片。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下示例向幻灯片添加了一个组合形状。
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
Aspose.Slides for PHP via Java 允许开发人员删除任意形状。要从幻灯片中删除形状，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText 的形状。
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
    $altText = "User Defined";
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
Aspose.Slides for PHP via Java 允许开发人员隐藏任意形状。要隐藏幻灯片中的形状，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText 的形状。
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
    $alttext = "User Defined";
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


## **更改形状顺序**
Aspose.Slides for PHP via Java 允许开发人员重新排列形状。重新排列决定了形状的前后层级。要在幻灯片中重新排列形状，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 再添加一个坐标相同的形状。
1. 重新排列形状。
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
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取 Interop Shape ID**
Aspose.Slides for PHP via Java 允许开发人员获取幻灯片范围内的唯一形状标识符，这与 [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getUniqueId--) 方法（获取演示文稿范围内的唯一标识符）形成对比。已在 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) 接口和 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) 类中添加了方法 [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getOfficeInteropShapeId--)。该方法返回的值对应 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id。下面给出示例代码。
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 获取幻灯片范围内的唯一形状标识符
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **为形状设置替代文本**
Aspose.Slides for PHP via Java 允许开发人员为任意形状设置 AlternateText。演示文稿中的形状可以通过 [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) 或 [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setName-java.lang.String-) 方法来区分。[setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#setAlternativeText-java.lang.String-) 和 [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) 方法既可以使用 Aspose.Slides 也可以使用 Microsoft PowerPoint 进行读取或设置。使用此方法，您可以为形状打标签，并可执行删除形状、隐藏形状或在幻灯片上重新排序形状等操作。要为形状设置 AlternateText，请按以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 向幻灯片添加任意形状。
1. 对新添加的形状进行一些操作。
1. 遍历形状以查找目标形状。
1. 设置 AlternativeText。
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
        $shape->setAlternativeText("User Defined");
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
Aspose.Slides for PHP via Java 提供了一个简单的 API 来访问形状的布局格式。本文演示如何访问布局格式。

下面给出示例代码。
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
现在 Aspose.Slides for PHP via Java 支持将形状渲染为 SVG。已在 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/Shape) 类和 [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) 接口中添加了方法 [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#writeAsSvg-java.io.OutputStream-)，用于将形状内容保存为 SVG 文件。下面的代码片段展示如何将幻灯片的形状导出为 SVG 文件。
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


## **对齐形状**
Aspose.Slides 允许将形状相对于幻灯片边距或相互之间对齐。为此已添加了重载方法 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)。[ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/ShapesAlignmentType) 枚举定义了可能的对齐选项。

**Example 1**

下面的源代码将索引为 1、2 和 4 的形状对齐到幻灯片的顶部边缘。
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


**Example 2**

下面的示例展示如何将整个形状集合相对于集合中最底部的形状进行对齐。
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


## **翻转属性**
在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) 类通过其 `flipH` 和 `flipV` 属性提供对形状水平和垂直镜像的控制。这两个属性的类型为 [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/)，`True` 表示翻转，`False` 表示不翻转，`NotDefined` 则使用默认行为。这些值可通过形状的 [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) 访问。

要修改翻转设置，可构造一个新的 [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) 实例，传入形状当前的位置、大小、期望的 `flipH`、`flipV` 值以及旋转角度。将该实例赋给形状的 [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) 并保存演示文稿，即可应用镜像变换并写入输出文件。

假设我们有一个 sample.pptx 文件，其中第一页包含一个默认翻转设置的单一形状，如下所示。

![要翻转的形状](shape_to_be_flipped.png)

以下代码示例获取形状当前的翻转属性，并同时对其进行水平和垂直翻转。
```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // 检索形状的水平翻转属性。
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // 检索形状的垂直翻转属性。
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // 水平翻转。
    $flipV = NullableBool::True; // 水平翻转。
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


结果：

![已翻转的形状](flipped_shape.png)

## **常见问题**

**可以像桌面编辑器那样在幻灯片上对形状进行合并（联合/相交/相减）吗？**

目前没有内置的布尔运算 API。您可以通过自行构建所需轮廓来近似实现，例如计算结果几何（通过 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)），然后使用该轮廓创建新形状，并可选择删除原始形状。

**如何控制堆叠顺序（z‑order），使某个形状始终保持在最上层？**

在幻灯片的 [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 集合中更改插入/移动顺序即可。为获得可预测的结果，请在完成所有其他幻灯片修改后再最终确定 z‑order。

**可以“锁定”形状，以防止用户在 PowerPoint 中编辑它吗？**

可以。设置 [形状级别的保护标志](/slides/zh/php-java/applying-protection-to-presentation/)（例如锁定选择、移动、大小调整、文本编辑）。如有需要，可在母版或布局上同步限制。需注意这只是 UI 层面的保护，而非安全特性；若需更强的保护，可结合文件级别的只读建议或密码等措施 [/slides/php-java/password-protected-presentation/]。