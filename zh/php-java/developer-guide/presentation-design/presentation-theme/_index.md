---
title: 演示主题
type: docs
weight: 10
url: /zh/php-java/presentation-theme/
keywords: "主题, PowerPoint 主题, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "PowerPoint 演示文稿主题"
---

演示主题定义了设计元素的属性。当您选择一个演示主题时，您实际上是选择了一组特定的视觉元素及其属性。

在 PowerPoint 中，主题包含颜色、[字体](/slides/zh/php-java/powerpoint-fonts/)、[背景样式](/slides/zh/php-java/presentation-background/)和效果。

![theme-constituents](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用一组特定的颜色。如果您不喜欢这些颜色，可以通过为主题应用新颜色来更改它们。为了让您选择新的主题颜色，Aspose.Slides 提供了 [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor) 枚举下的值。

以下 PHP 代码向您展示了如何更改主题的强调色：

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

您可以通过以下方式确定结果颜色的有效值：

```php
  $fillEffective = $shape->getFillFormat()->getEffective();
  $effectiveColor = $fillEffective->getSolidFillColor();
  echo(sprintf("颜色 [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));

```

为了进一步演示颜色更改操作，我们创建另一个元素并将强调色（来自初始操作）赋值给它。然后，我们在主题中更改颜色：

```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

```

新颜色会自动应用到两个元素上。

### **从附加调色板设置主题颜色**

当您对主要主题颜色(1)应用亮度变换时，将形成附加调色板(2)中的颜色。然后，您可以设置和获取这些主题颜色。

![additional-palette-colors](additional-palette-colors.png)

**1** - 主要主题颜色

**2** - 附加调色板中的颜色。

以下 PHP 代码演示了从主要主题颜色获取附加调色板颜色并在形状中使用的操作：

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 强调 4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # 强调 4, 更亮 80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # 强调 4, 更亮 60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # 强调 4, 更亮 40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # 强调 4, 更暗 25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # 强调 4, 更暗 50%
    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.5);
    $presentation->save($path . "example_accent4.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **更改主题字体**

为了允许您为主题和其他目的选择字体，Aspose.Slides 使用这些特殊标识符（类似于在 PowerPoint 中使用的标识符）：

* **+mn-lt** - 正文字体拉丁文（次要拉丁字体）
* **+mj-lt** - 标题字体拉丁文（主要拉丁字体）
* **+mn-ea** - 正文字体东亚文（次要东亚字体）
* **+mj-ea** - 正文字体东亚文（主要东亚字体）

以下 PHP 代码向您展示了如何将拉丁字体分配给主题元素：

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("主题文本格式");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

```

以下 PHP 代码向您展示了如何更改演示主题字体：

```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

```

所有文本框中的字体将被更新。

{{% alert color="primary" title="提示" %}} 

您可能想查看 [PowerPoint 字体](/slides/zh/php-java/powerpoint-fonts/)。

{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 应用程序提供 12 种预定义背景，但在典型演示文稿中仅保存其中 3 种。

![todo:image_alt_text](presentation-design_8.png)

例如，在您将演示文稿保存在 PowerPoint 应用程序中后，您可以运行以下 PHP 代码以找出演示文稿中的预定义背景数量：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("主题的背景填充样式数量为 " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

使用 [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) 类的 [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) 属性，您可以添加或访问 PowerPoint 主题中的背景样式。

{{% /alert %}} 

以下 PHP 代码向您展示了如何为演示文稿设置背景：

```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);

```

**索引指南**：0 表示无填充。索引从 1 开始。

{{% alert color="primary" title="提示" %}} 

您可能想查看 [PowerPoint 背景](/slides/zh/php-java/presentation-background/)。

{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常为每种样式数组包含 3 个值。这些数组组合成这 3 种效果：细腻、适中和强烈。例如，当这些效果应用于特定形状时，结果如下：

![todo:image_alt_text](presentation-design_10.png)

使用 [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) 类的 3 个属性（[FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)），您可以更灵活地更改主题中的元素（甚至比 PowerPoint 中的选项更灵活）。

以下 PHP 代码向您展示了如何通过修改元素的部分来更改主题效果：

```php
  $pres = new Presentation("Subtle_Moderate_Intense.pptx");
  try {
    $pres->getMasterTheme()->getFormatScheme()->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $pres->getMasterTheme()->getFormatScheme()->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->getMasterTheme()->getFormatScheme()->getEffectStyles()->get_Item(2)->getEffectFormat()->getOuterShadowEffect()->setDistance(10.0);
    $pres->save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

填充颜色、填充类型、阴影效果等的结果变化：

![todo:image_alt_text](presentation-design_11.png)