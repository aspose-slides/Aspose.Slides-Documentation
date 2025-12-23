---
title: 使用 PHP 的 AutoFit 提升您的演示文稿
linktitle: AutoFit 设置
type: docs
weight: 30
url: /zh/php-java/manage-autofit-settings/
keywords:
- 文本框
- 自动适应
- 不自动适应
- 适合文本
- 收缩文本
- 换行文本
- 调整形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP 中管理 AutoFit 设置，以优化 PowerPoint 和 OpenDocument 演示文稿中的文本显示并提升内容可读性。"
---

默认情况下，当您添加文本框时，Microsoft PowerPoint 会对该文本框使用 **Resize shape to fix text** 设置——它会自动调整文本框的大小，以确保文本始终适合其中。 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变得更长或更大时，PowerPoint 会自动放大文本框——增加其高度——以容纳更多文本。 
* 当文本框中的文本变得更短或更小的时候，PowerPoint 会自动缩小文本框——降低其高度——以清除多余的空间。 

在 PowerPoint 中，以下是控制文本框自动适应行为的 4 个重要参数或选项：

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java 提供了类似的选项——[TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类中的某些属性——允许您控制演示文稿中文本框的自动适应行为。

## **将形状调整以适应文本**

如果您希望盒子中的文本在更改后始终适合该盒子，则必须使用 **Resize shape to fix text** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类）设置为 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

以下 PHP 代码演示了如何在 PowerPoint 演示文稿中指定文本必须始终适合其盒子：
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


如果文本变得更长或更大，文本框将自动调整大小（高度增加），以确保所有文本都能适合其中。如果文本变得更短，则相反。

## **不自动适应**

如果您希望文本框或形状无论其中的文本如何更改都保持其尺寸，则必须使用 **Do not Autofit** 选项。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类）设置为 `None`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

以下 PHP 代码演示了如何在 PowerPoint 演示文稿中指定文本框必须始终保持其尺寸：
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


当文本对盒子来说过长时，文本会溢出。 

## **溢出时收缩文本**

如果文本对盒子来说过长，可通过 **Shrink text on overflow** 选项指定必须缩小文本的大小和间距以使其适合盒子。要指定此设置，请将 [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类）设置为 `Normal`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

以下 PHP 代码演示了如何在 PowerPoint 演示文稿中指定在溢出时收缩文本：
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Info" color="info" %}}
使用 **Shrink text on overflow** 选项时，仅当文本对盒子过长时才会应用此设置。 
{{% /alert %}}

## **换行文本**

如果您希望文本在超出形状边界（仅宽度）时在形状内部换行，则必须使用 **Wrap text in shape** 参数。要指定此设置，需要将 [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类）设置为 `true`。

以下 PHP 代码演示了如何在 PowerPoint 演示文稿中使用换行文本设置：
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Note" color="warning" %}} 
如果为形状将 `WrapText` 属性设置为 `False`，当形状内的文本长度超过形状宽度时，文本会在单行中超出形状的边界。 
{{% /alert %}}

## **FAQ**

**文本框的内部边距会影响 AutoFit 吗？**

是的。填充（内部边距）会减少可用于文本的区域，因此 AutoFit 会更早触发——更快地缩小字体或调整形状大小。请在调节 AutoFit 之前检查并调整边距。

**AutoFit 如何与手动和软换行交互？**

强制换行保持不变，AutoFit 会在其周围调整字体大小和间距。删除不必要的换行通常会降低 AutoFit 对文本收缩的力度。

**更改主题字体或触发字体替换会影响 AutoFit 结果吗？**

是的。替换为字形度量不同的字体会改变文本的宽度/高度，从而影响最终的字体大小和换行。进行任何字体更改或替换后，请重新检查幻灯片。