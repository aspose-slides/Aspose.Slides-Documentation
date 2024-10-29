---
title: 形状有效属性
type: docs
weight: 50
url: /zh/php-java/shape-effective-properties/
---

在本主题中，我们将讨论 **有效** 和 **局部** 属性。当我们在这些级别直接设置值时：

1. 在部分的幻灯片上的部分属性中；
1. 在布局或母版幻灯片上的原型形状文本样式中（如果部分的文本框形状有一个）；
1. 在演示文稿的全局文本设置中；

这些值被称为 **局部** 值。在任何级别上，**局部** 值可以被定义或省略。但是当应用程序需要知道部分应该是什么样子时，它使用 **有效** 值。您可以通过使用局部格式的 **getEffective()** 方法来获取有效值。

以下示例代码演示了如何获取有效值：

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

## **获取相机的有效属性**
Aspose.Slides for PHP via Java 允许开发人员获取相机的有效属性。为此，[**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) 接口已添加到 Aspose.Slides。 [ICameraEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) 接口代表一个包含有效相机属性的不变对象。 [**ICameraEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICameraEffectiveData) 接口的实例被用作 [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) 接口的一部分，它是 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码展示了如何获取相机的有效属性：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= 有效的相机属性 =");
    echo("类型: " . $threeDEffectiveData->getCamera()->getCameraType());
    echo("视场: " . $threeDEffectiveData->getCamera()->getFieldOfViewAngle());
    echo("缩放: " . $threeDEffectiveData->getCamera()->getZoom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取光线设备的有效属性**
Aspose.Slides for PHP via Java 允许开发人员获取光线设备的有效属性。为此， [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) 接口已添加到 Aspose.Slides。 [ILightRigEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) 接口代表一个包含有效光线设备属性的不变对象。 [**ILightRigEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRigEffectiveData) 接口的实例被用作 [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) 接口的一部分，它是 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码展示了如何获取光线设备的有效属性：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= 有效的光线设备属性 =");
    echo("类型: " . $threeDEffectiveData->getLightRig()->getLightType());
    echo("方向: " . $threeDEffectiveData->getLightRig()->getDirection());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取斜角形状的有效属性**
Aspose.Slides for PHP via Java 允许开发人员获取斜角形状的有效属性。为此， [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) 接口已添加到 Aspose.Slides。 [IShapeBevelEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) 接口代表一个包含有效形状表面浮雕属性的不变对象。 [**IShapeBevelEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeBevelEffectiveData) 接口的实例被用作 [**IThreeDFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/IThreeDFormatEffectiveData) 接口的一部分，它是 [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) 类的 [有效值](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getEffective--) 对。

以下示例代码展示了如何获取斜角形状的有效属性：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $threeDEffectiveData = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThreeDFormat()->getEffective();
    echo("= 有效形状的顶部表面浮雕属性 =");
    echo("类型: " . $threeDEffectiveData->getBevelTop()->getBevelType());
    echo("宽度: " . $threeDEffectiveData->getBevelTop()->getWidth());
    echo("高度: " . $threeDEffectiveData->getBevelTop()->getHeight());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取文本框的有效属性**
使用 Aspose.Slides for PHP via Java，您可以获取文本框的有效属性。为此， [**ITextFrameFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrameFormatEffectiveData) 接口已添加到 Aspose.Slides。它包含有效的文本框格式属性。

以下示例代码展示了如何获取有效的文本框格式属性：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    echo("锚定类型: " . $effectiveTextFrameFormat::getAnchoringType());
    echo("自动适应类型: " . $effectiveTextFrameFormat::getAutofitType());
    echo("文本垂直类型: " . $effectiveTextFrameFormat::getTextVerticalType());
    echo("边距");
    echo("   左: " . $effectiveTextFrameFormat::getMarginLeft());
    echo("   上: " . $effectiveTextFrameFormat::getMarginTop());
    echo("   右: " . $effectiveTextFrameFormat::getMarginRight());
    echo("   下: " . $effectiveTextFrameFormat::getMarginBottom());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取文本样式的有效属性**
使用 Aspose.Slides for PHP via Java，您可以获取文本样式的有效属性。为此， [**ITextStyleEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ITextStyleEffectiveData) 接口已添加到 Aspose.Slides。它包含有效的文本样式属性。

以下示例代码展示了如何获取有效的文本样式属性：

```php
  $pres = new Presentation("Presentation1.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $effectiveTextStyle = $shape->getTextFrame()->getTextFrameFormat()->getTextStyle()->getEffective();
    for($i = 0; $i <= 8; $i++) {
      $effectiveStyleLevel = $effectiveTextStyle->getLevel($i);
      echo("= 样式级别 #" . $i . " 的有效段落格式 =");
      echo("深度: " . $effectiveStyleLevel->getDepth());
      echo("缩进: " . $effectiveStyleLevel->getIndent());
      echo("对齐: " . $effectiveStyleLevel->getAlignment());
      echo("字体对齐: " . $effectiveStyleLevel->getFontAlignment());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取有效字体高度值**
使用 Aspose.Slides for PHP via Java，您可以获取字体高度的有效属性。在这里，我们提供了一段代码，显示在不同的演示文稿结构级别上设置局部字体高度值后，部分的有效字体高度值变化：

```php
  $pres = new Presentation();
  try {
    $newShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $newShape->addTextFrame("");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->clear();
    $portion0 = new Portion("带有第一个部分的示例文本");
    $portion1 = new Portion(" 和第二个部分。");
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion0);
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion1);
    echo("创建后有效的字体高度：");
    echo("部分 #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("部分 #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(24);
    echo("设置整个演示文稿默认字体高度后有效的字体高度：");
    echo("部分 #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("部分 #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(40);
    echo("设置段落默认字体高度后有效的字体高度：");
    echo("部分 #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("部分 #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setFontHeight(55);
    echo("设置部分 #0 字体高度后有效的字体高度：");
    echo("部分 #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("部分 #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $newShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setFontHeight(18);
    echo("设置部分 #1 字体高度后有效的字体高度：");
    echo("部分 #0: " . $portion0->getPortionFormat()->getEffective()->getFontHeight());
    echo("部分 #1: " . $portion1->getPortionFormat()->getEffective()->getFontHeight());
    $pres->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **获取表格的有效填充格式**
使用 Aspose.Slides for PHP via Java，您可以获取不同表格逻辑部分的有效填充格式。为此， [**ICellFormatEffectiveData**](https://reference.aspose.com/slides/php-java/aspose.slides/ICellFormatEffectiveData) 接口已添加到 Aspose.Slides。它包含有效的填充格式属性。请注意：单元格格式始终优先于行格式；行优先于列；列优先于整个表格。

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