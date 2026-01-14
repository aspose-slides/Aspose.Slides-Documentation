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
- 形状备用文本
- 形状布局格式
- 形状为 SVG
- 形状转 SVG
- 对齐形状
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "学习在 Aspose.Slides for PHP via Java 中创建、编辑和优化形状，并交付高性能的 PowerPoint 演示文稿。"
---

## **在幻灯片上查找形状**
本主题将介绍一种简便技术，帮助开发者在不使用内部 Id 的情况下更容易在幻灯片上找到特定形状。需要了解的是，PowerPoint 演示文稿文件除内部唯一 Id 外，无法以其他方式标识幻灯片上的形状。开发者仅凭内部唯一 Id 查找形状往往比较困难。所有添加到幻灯片的形状都有 Alt Text（备用文本）。我们建议开发者使用备用文本来查找特定形状。您可以使用 MS PowerPoint 为计划以后更改的对象定义备用文本。

在为任意所需形状设置了备用文本后，您可以使用 Aspose.Slides for PHP via Java 打开该演示文稿，并遍历幻灯片中添加的所有形状。每次遍历时，都可以检查形状的备用文本，匹配的备用文本即为您需要的形状。为了更直观地展示此技术，我们创建了一个方法 [findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) 来实现查找幻灯片中特定形状的功能，并直接返回该形状。
```php
  # 实例化一个表示演示文稿文件的 Presentation 类
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 要查找的形状的备用文本
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
使用 Aspose.Slides for PHP via Java 将形状克隆到幻灯片的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问源幻灯片的形状集合。
1. 向演示文稿中添加新幻灯片。
1. 将源幻灯片形状集合中的形状克隆到新幻灯片。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片中添加了一个组合形状。
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
Aspose.Slides for PHP via Java 允许开发者删除任意形状。要从任意幻灯片中删除形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
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
Aspose.Slides for PHP via Java 允许开发者隐藏任意形状。要隐藏幻灯片中的形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
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
Aspose.Slides for PHP via Java 允许开发者重新排列形状的顺序。重新排列形状可决定哪个形状在前、哪个形状在后。要在任意幻灯片上重新排序形状，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文字。
1. 再添加一个具有相同坐标的形状。
1. 重新排列这些形状。
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
Aspose.Slides for PHP via Java 允许开发者获取幻灯片范围内的唯一形状标识符，这与 [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/) 方法（获取演示文稿范围内的唯一标识符）不同。已在 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类中添加了方法 [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/)。[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) 方法返回的值对应 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id。下面给出了示例代码。
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # 获取幻灯片范围内唯一的形状标识符
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **为形状设置备用文本**
Aspose.Slides for PHP via Java 允许开发者为任意形状设置 AlternateText（备用文本）。演示文稿中的形状可以通过 `Alternative Text` 或 [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) 方法进行区分。可以使用 Aspose.Slides 以及 Microsoft PowerPoint 读取或设置 [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) 和 [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) 方法。通过此方法，您可以为形状标记，并执行删除形状、隐藏形状或在幻灯片上重新排序形状等不同操作。

设置形状的 AlternateText，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
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
Aspose.Slides for PHP via Java 提供了简洁的 API 来访问形状的布局格式。本文展示了如何访问布局格式。

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
现在 Aspose.Slides for PHP via Java 支持将形状渲染为 SVG。已在 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类中添加了方法 [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/)（及其重载），该方法可以将形状内容保存为 SVG 文件。下面的代码片段展示了如何将幻灯片的形状导出为 SVG 文件。
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
Aspose.Slides 允许将形状相对于幻灯片边距或相互之间对齐。为此，已添加了重载方法 [SlidesUtil::alignShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/alignshapes/)。[ShapesAlignmentType](https://reference.aspose.com/slides/php-java/aspose.slides/shapesalignmenttype/) 枚举定义了可能的对齐选项。

**示例 1**

下面的源代码将索引为 1、2 和 4 的形状对齐到幻灯片的顶部边框。
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

下面的示例展示了如何将整个形状集合相对于集合中最底部的形状进行对齐。
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

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) 类通过其 `flipH` 和 `flipV` 属性提供对形状水平和垂直镜像的控制。这两个属性的类型为 [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/)，可取值 `True` 表示翻转，`False` 表示不翻转，`NotDefined` 表示使用默认行为。可以通过形状的 [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) 访问这些值。

要修改翻转设置，需使用形状当前的位置和尺寸、期望的 `flipH`、`flipV` 值以及旋转角度构造一个新的 [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) 实例。将该实例赋给形状的 [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) 并保存演示文稿，即可应用镜像变换并写入输出文件。

假设我们有一个 sample.pptx 文件，其中第一张幻灯片包含一个默认翻转设置的单个形状，如下所示。

![要翻转的形状](shape_to_be_flipped.png)

下面的代码示例获取形状当前的翻转属性，并同时在水平和垂直方向翻转它。
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

## **常见问答**

**我能像桌面编辑器一样在幻灯片上对形状进行合并（联合/交集/相减）吗？**

目前没有内置的布尔运算 API。您可以通过自行构造所需轮廓来近似实现，例如使用 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) 计算结果几何体，并创建具有该轮廓的新形状，必要时删除原始形状。

**如何控制堆叠顺序（z 顺序），使形状始终置于“顶部”？**

在幻灯片的 [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 集合中更改插入/移动顺序。为了得到可预测的结果，请在完成所有其他幻灯片修改后最终确定 z 顺序。

**我能“锁定”形状，以防止用户在 PowerPoint 中编辑它吗？**

可以。设置 [shape-level protection flags](/slides/zh/php-java/applying-protection-to-presentation/)（例如锁定选择、移动、大小调整、文本编辑）。如有需要，也可在母版或版式上镜像这些限制。请注意，这属于 UI 级别的保护，而非安全特性；如需更强的保护，可结合文件级限制，如 [只读推荐或密码](/slides/zh/php-java/password-protected-presentation/)。