---
title: 管理 PHP 中的演示文稿形状
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
- 将形状转换为 SVG
- 对齐形状
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "学习在 Aspose.Slides for PHP via Java 中创建、编辑和优化形状，并交付高性能的 PowerPoint 演示文稿。"
---

## **在幻灯片上查找形状**
本主题将描述一种简单技术，使开发人员能够更轻松地在幻灯片上查找特定形状，而无需使用其内部 Id。重要的是要知道，PowerPoint 演示文稿文件没有除内部唯一 Id 之外的方式来标识幻灯片上的形状。开发人员使用内部唯一 Id 查找形状似乎比较困难。添加到幻灯片的所有形状都有一些替代文本。我们建议开发人员使用替代文本来查找特定形状。您可以使用 MS PowerPoint 为计划将来更改的对象定义替代文本。

在为任意所需形状设置替代文本后，您可以使用 Aspose.Slides for PHP via Java 打开该演示文稿，并遍历幻灯片上添加的所有形状。在每次遍历中，您可以检查形状的替代文本，匹配的替代文本对应的形状即为您需要的形状。为更好地演示此技术，我们创建了一个方法，[findShape](https://reference.aspose.com/slides/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-)，它可以在幻灯片中查找特定形状并直接返回该形状。
```php
  # 实例化一个表示演示文件的 Presentation 类
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
使用 Aspose.Slides for PHP via Java 将形状克隆到幻灯片：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 访问源幻灯片的形状集合。
1. 向演示文稿添加新幻灯片。
1. 将源幻灯片形状集合中的形状克隆到新幻灯片。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加了一个组形状。
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


## **移除形状**
Aspose.Slides for PHP via Java 允许开发人员移除任意形状。要从幻灯片中移除形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText（替代文本）的形状。
1. 移除该形状。
1. 将文件保存到磁盘。
```php
  # 创建 Presentation 对象
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 添加矩形自动形状
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
Aspose.Slides for PHP via Java 允许开发人员隐藏任意形状。要隐藏幻灯片中的形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 查找具有特定 AlternativeText（替代文本）的形状。
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
Aspose.Slides for PHP via Java 允许开发人员重新排序形状。重新排序决定哪个形状在前面，哪个在后面。要重新排序幻灯片中的形状，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 访问第一张幻灯片。
1. 添加一个形状。
1. 在形状的文本框中添加一些文本。
1. 添加另一个具有相同坐标的形状。
1. 重新排序这些形状。
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
Aspose.Slides for PHP via Java 允许开发人员获取幻灯片范围内的唯一形状标识符，这与 [getUniqueId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getuniqueid/) 方法（获取演示文稿范围内的唯一标识符）相区别。已在 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类中添加了方法 [getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/)。[getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getofficeinteropshapeid/) 方法返回的值对应 Microsoft.Office.Interop.PowerPoint.Shape 对象的 Id 值。下面给出示例代码。
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
Aspose.Slides for PHP via Java 允许开发人员设置任意形状的 AlternateText（替代文本）。演示文稿中的形状可以通过 `Alternative Text` 或 [Shape Name](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) 方法来区分。可以使用 Aspose.Slides 读取或设置 [setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) 和 [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) 方法。通过此方法，您可以标记形状并执行不同的操作，如移除形状、隐藏形状或重新排序幻灯片上的形状。

要为形状设置 AlternateText，请按照以下步骤操作：

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
现在 Aspose.Slides for PHP via Java 支持将形状渲染为 SVG。已在 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 类中添加了方法 [writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/)（及其重载）。此方法允许将形状的内容保存为 SVG 文件。下面的代码片段展示了如何将幻灯片的形状导出为 SVG 文件。
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

**Example 1**

下面的源代码将索引为 1、2 和 4 的形状沿幻灯片的顶部边缘对齐。
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

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) 类通过其 `flipH` 和 `flipV` 属性提供对形状水平和垂直镜像的控制。这两个属性的类型为 [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/)，可取 `True` 表示翻转，`False` 表示不翻转，或 `NotDefined` 使用默认行为。这些值可通过形状的 [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) 访问。

要修改翻转设置，可构造一个新的 [ShapeFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapeframe/) 实例，传入形状的当前位置和大小、期望的 `flipH` 和 `flipV` 值以及旋转角度。将该实例分配给形状的 [Frame](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getFrame) 并保存演示文稿，即可应用镜像转换并将其写入输出文件。

假设我们有一个 sample.pptx 文件，其第一张幻灯片包含一个默认翻转设置的单个形状，如下所示。

![The shape to be flipped](shape_to_be_flipped.png)

以下代码示例获取形状当前的翻转属性，并在水平和垂直方向上进行翻转。
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


结果如下：

![The flipped shape](flipped_shape.png)

## **FAQ**

**我可以像桌面编辑器一样在幻灯片上合并形状（联集/相交/相减）吗？**

目前没有内置的布尔运算 API。您可以通过自行构建所需的轮廓来近似实现，例如计算结果几何（通过 [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/)），然后使用该轮廓创建新形状，必要时删除原始形状。

**如何控制堆叠顺序（z 顺序），使形状始终位于“顶部”？**

更改幻灯片的 [shapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) 集合中的插入/移动顺序。为获得可预测的结果，请在完成所有其他幻灯片修改后最终确定 z 顺序。

**我可以“锁定”形状以防止用户在 PowerPoint 中编辑它吗？**

可以。设置形状级别的保护标志（例如，锁定选择、移动、大小调整、文本编辑）。如有需要，可在母版或版式上镜像这些限制。请注意，这仅是 UI 级别的保护，并非安全特性；如果需要更强的保护，可结合文件级别的限制，如 [只读建议或密码](/slides/zh/php-java/password-protected-presentation/)。