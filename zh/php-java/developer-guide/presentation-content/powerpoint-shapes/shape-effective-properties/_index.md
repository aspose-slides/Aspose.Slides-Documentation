---
title: 从 PHP 演示文稿获取形状的实际属性
linktitle: 实际属性
type: docs
weight: 50
url: /zh/php-java/shape-effective-properties/
keywords:
- 形状属性
- 摄像机属性
- 灯光装置
- 斜面形状
- 文本框
- 文本样式
- 字体高度
- 填充格式
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP via Java 如何计算并应用实际形状属性，以实现精确的 PowerPoint 渲染。"
---

在本主题中，我们将讨论 **实际** 和 **本地** 属性。当我们在以下层级直接设置值时

1. 在部分的幻灯片上设置部分属性；
1. 在布局或母版幻灯片上设置原型形状文本样式（如果该部分的文本框形状有的话）；
1. 在演示文稿全局文本设置中；

这些值称为 **本地** 值。 在任何层级，**本地** 值都可以定义或省略。 但当应用程序需要了解该部分应该呈现的外观时，它会使用 **实际** 值。 您可以通过从本地格式调用 **getEffective()** 方法来获取实际值。

以下示例代码演示了如何获取实际值：
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat::getEffective();
    $localPortionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat::getEffective();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取相机的实际属性**
Aspose.Slides for PHP via Java 允许开发者获取相机的实际属性。 为此，向 Aspose.Slides 添加了 [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) 接口。 [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) 接口表示一个不可变对象，包含实际的相机属性。 [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) 接口的实例作为 [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) 接口的一部分使用，该接口是 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码展示了如何获取相机的实际属性：
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective camera properties =");
    echo("Type: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("Field of view: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("Zoom: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取灯光装置的实际属性**
Aspose.Slides for PHP via Java 允许开发者获取灯光装置的实际属性。 为此，向 Aspose.Slides 添加了 [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) 接口。 [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) 接口表示一个不可变对象，包含实际的灯光装置属性。 [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) 接口的实例作为 [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) 接口的一部分使用，该接口是 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码展示了如何获取灯光装置的实际属性：
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective light rig properties =");
    echo("Type: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("Direction: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取斜面形状的实际属性**
Aspose.Slides for PHP via Java 允许开发者获取斜面形状的实际属性。 为此，向 Aspose.Slides 添加了 [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) 接口。 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) 接口表示一个不可变对象，包含实际的形状面部浮雕属性。 [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) 接口的实例作为 [**IThreeDFormatEffectiveData**]([**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData)) 接口的一部分使用，该接口是 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码展示了如何获取斜面形状的实际属性：
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= Effective shape's top face relief properties =");
    echo("Type: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("Width: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("Height: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取文本框的实际属性**
使用 Aspose.Slides for PHP via Java，您可以获取文本框的实际属性。 为此，向 Aspose.Slides 添加了 [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) 接口。它包含实际的文本框格式属性。

以下示例代码展示了如何获取实际的文本框格式属性：
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("Anchoring type: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("Autofit type: " . $effectiveTextFrameFormat::getAutofitType());
    echo("Text vertical type: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("Margins");
    echo("   Left: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   Top: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   Right: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   Bottom: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取文本样式的实际属性**
使用 Aspose.Slides for PHP via Java，您可以获取文本样式的实际属性。 为此，向 Aspose.Slides 添加了 [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) 接口。它包含实际的文本样式属性。

以下示例代码展示了如何获取实际的文本样式属性：
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= Effective paragraph formatting for style level #" . $i . " =");
      echo("Depth: " . $effectiveStyleLevel->getDepth());
      echo("Indent: " . $effectiveStyleLevel->getIndent());
      echo("Alignment: " . $effectiveStyleLevel->getAlignment());
      echo("Font alignment: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取实际的字体高度值**
使用 Aspose.Slides for PHP via Java，您可以获取字体高度的实际属性。 此处提供的代码展示了在不同演示文稿结构层级上设置本地字体高度后，部分的实际字体高度值如何变化：
```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("Sample text with first portion");
    $portion1 = new Portion(" and second portion.");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("Effective font height just after creation:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("Effective font height after setting entire presentation default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("Effective font height after setting paragraph default font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("Effective font height after setting portion #0 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("Effective font height after setting portion #1 font height:");
    echo("Portion #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("Portion #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **获取表格的实际填充格式**
使用 Aspose.Slides for PHP via Java，您可以获取不同表格逻辑部分的实际填充格式。 为此，向 Aspose.Slides 添加了 [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) 接口。它包含实际的填充格式属性。 请注意：单元格格式始终优先于行格式；行格式优先于列格式；列格式优先于整个表格。
```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $tableFormatEffective = $tbl->getTableFormat()->getEffective();
    $rowFormatEffective = $tbl->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnFormatEffective = $tbl->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellFormatEffective = $tbl->get_Item(0, 0)->getCellFormat()->getEffective();
    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我如何判断得到的是 “快照” 而不是 “实时对象”，以及何时需要重新读取实际属性？**

EffectiveData 对象是调用时计算值的不可变快照。 如果您更改了形状的本地或继承设置，请再次检索实际数据以获取更新后的值。

**更改布局/母版幻灯片会影响已检索的实际属性吗？**

会，但只有在您重新读取后才会生效。 已获取的 EffectiveData 对象不会自动更新——在更改布局或母版后请再次请求。

**我可以通过 EffectiveData 修改值吗？**

不能。EffectiveData 为只读。 请在本地格式对象（形状/文本/3D 等）中进行更改，然后再次获取实际值。

**如果属性在形状层级、布局/母版以及全局设置中都未设置，会怎样？**

实际值由默认机制（PowerPoint/Aspose.Slides 默认）确定。 该解析后的值成为 EffectiveData 快照的一部分。

**从实际字体值，我能判断是哪个层级提供的大小或字体吗？**

不能直接判断。EffectiveData 返回最终值。 若要查找来源，请检查部分/段落/文本框的本地值以及布局/母版/演示文稿的文本样式，找出首次出现显式定义的层级。

**为什么 EffectiveData 的值有时看起来和本地值相同？**

因为本地值最终成为了最终值（无需更高层级的继承）。 在这种情况下，实际值与本地值相匹配。

**何时应该使用实际属性，何时只使用本地属性？**

当您需要在所有继承应用后得到“渲染后”的结果（如对齐颜色、缩进或尺寸）时使用 EffectiveData。 如果您只需在特定层级修改格式，请修改本地属性，然后在必要时重新读取 EffectiveData 以验证结果。