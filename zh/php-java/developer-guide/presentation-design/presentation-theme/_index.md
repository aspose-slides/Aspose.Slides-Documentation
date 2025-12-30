---
title: 在 PHP 中管理演示文稿主题
linktitle: 演示文稿主题
type: docs
weight: 10
url: /zh/php-java/presentation-theme/
keywords:
- PowerPoint 主题
- 演示文稿主题
- 幻灯片主题
- 设置主题
- 更改主题
- 管理主题
- 主题颜色
- 附加调色板
- 主题字体
- 主题样式
- 主题效果
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for PHP 中掌握演示文稿主题，以创建、定制和转换具有一致品牌形象的 PowerPoint 文件。"
---

演示文稿主题定义了设计元素的属性。当您选择演示文稿主题时，实际上是在选择一组特定的视觉元素及其属性。

在 PowerPoint 中，主题包括颜色、[字体](/slides/zh/php-java/powerpoint-fonts/)、[背景样式](/slides/zh/php-java/presentation-background/)和效果。

![主题组成](theme-constituents.png)

## **更改主题颜色**

PowerPoint 主题为幻灯片上的不同元素使用一套特定的颜色。如果您不喜欢这些颜色，可以通过为主题应用新颜色来更改它们。为帮助您选择新的主题颜色，Aspose.Slides 在 [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/SchemeColor) 枚举中提供了相应的值。

此 PHP 代码示例演示如何更改主题的强调色：
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
  echo(sprintf("Color [A=%d, R=%d, G=%d, B=%d]", $effectiveColor->getAlpha(), $effectiveColor->getRed(), $effectiveColor->getGreen(), $effectiveColor->getBlue()));
```


为了进一步演示颜色更改操作，我们创建另一个元素，并将（初始操作得到的）强调色分配给它。然后我们在主题中更改颜色：
```php
  $otherShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 120, 100, 100);
  $otherShape->getFillFormat()->setFillType(FillType::Solid);
  $otherShape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
  $pres->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);
```


新颜色会自动应用到两个元素上。

### **从附加调色板设置主题颜色**

当您对主主题颜色 (1) 应用亮度变换时，会形成来自附加调色板 (2) 的颜色。您随后可以设置和获取这些主题颜色。

![附加调色板颜色](additional-palette-colors.png)

**1** - 主主题颜色  

**2** - 来自附加调色板的颜色。

此 PHP 代码演示了一个操作：从主主题颜色获取附加调色板颜色，然后在形状中使用这些颜色：
```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # 强调色4
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    # 强调色4，亮度提升80%
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.8);
    # 强调色4，亮度提升60%
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.6);
    # 强调色4，亮度提升40%
    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->AddLuminance, 0.4);
    # 强调色4，变暗25%
    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor->Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation->MultiplyLuminance, 0.75);
    # 强调色4，变暗50%
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

为帮助您为主题及其他用途选择字体，Aspose.Slides 使用以下特殊标识符（与 PowerPoint 中使用的标识符类似）：

* **+mn-lt** - 正文字体 拉丁文（Minor Latin Font）
* **+mj-lt** - 标题字体 拉丁文（Major Latin Font）
* **+mn-ea** - 正文字体 东亚（Minor East Asian Font）
* **+mj-ea** - 正文字体 东亚（Major East Asian Font）

此 PHP 代码示例演示如何将拉丁文字体分配给主题元素：
```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
  $paragraph = new Paragraph();
  $portion = new Portion("Theme text format");
  $paragraph->getPortions()->add($portion);
  $shape->getTextFrame()->getParagraphs()->add($paragraph);
  $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));
```


此 PHP 代码示例演示如何更改演示文稿的主题字体：
```php
  $pres->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));
```


所有文本框中的字体都会被更新。

{{% alert color="primary" title="TIP" %}} 
您可能想查看[PowerPoint 字体](/slides/zh/php-java/powerpoint-fonts/)。
{{% /alert %}}

## **更改主题背景样式**

默认情况下，PowerPoint 应用提供 12 种预定义背景，但在一次普通演示文稿中只会保存其中的 3 种。

![演示文稿设计](presentation-design_8.png)

例如，在 PowerPoint 应用中保存演示文稿后，您可以运行以下 PHP 代码来获取演示文稿中预定义背景的数量：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $numberOfBackgroundFills = $pres->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size();
    echo("Number of background fill styles for theme is " . $numberOfBackgroundFills);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="warning" %}} 
使用 [BackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getBackgroundFillStyles--) 属性（来自 [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) 类），您可以在 PowerPoint 主题中添加或访问背景样式。
{{% /alert %}} 

此 PHP 代码示例演示如何为演示文稿设置背景：
```php
  $pres->getMasters()->get_Item(0)->getBackground()->setStyleIndex(2);
```


**索引指南**：0 表示无填充。索引从 1 开始。

{{% alert color="primary" title="TIP" %}} 
您可能想查看[PowerPoint 背景](/slides/zh/php-java/presentation-background/)。
{{% /alert %}}

## **更改主题效果**

PowerPoint 主题通常为每个样式数组包含 3 个值。这些数组组合形成 3 种效果：细微、适中和强烈。例如，以下是在特定形状上应用这些效果后的结果：

![演示文稿设计](presentation-design_10.png)

使用来自 [FormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme) 类的 3 个属性（[FillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getFillStyles--)、[LineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getLineStyles--)、[EffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/FormatScheme#getEffectStyles--)），您可以比 PowerPoint 中的选项更灵活地更改主题中的元素。

此 PHP 代码示例演示如何通过更改元素的部分属性来更改主题效果：
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


结果在填充颜色、填充类型、阴影效果等方面的更改：

![演示文稿设计](presentation-design_11.png)

## **常见问题**

**我可以在不更改母版的情况下仅对单个幻灯片应用主题吗？**

可以。Aspose.Slides 支持幻灯片级别的主题覆盖，您可以仅对该幻灯片应用本地主题，同时保持母版主题不变（通过 [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/)）。

**将主题从一个演示文稿转移到另一个演示文稿的最安全方式是什么？**

将[克隆幻灯片](/slides/zh/php-java/clone-slides/)及其母版一起复制到目标演示文稿。这样可以保留原始母版、布局以及关联的主题，从而保持外观一致。

**如何查看所有继承和覆盖后的“有效”值？**

使用 API 的[“有效”视图](/slides/zh/php-java/shape-effective-properties/)来获取主题/颜色/字体/效果的最终属性。这些视图返回在应用母版和任何本地覆盖后解析得到的最终属性。