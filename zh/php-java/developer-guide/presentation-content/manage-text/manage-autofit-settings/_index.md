---
title: 管理自动调整设置
type: docs
weight: 30
url: /php-java/manage-autofit-settings/
keywords: "文本框, 自动调整, PowerPoint 演示文稿, Java, Aspose.Slides for PHP via Java"
description: "设置 PowerPoint 中文本框的自动调整设置"
---

默认情况下，当您添加文本框时，Microsoft PowerPoint 使用 **调整形状以适应文本** 设置，该设置会自动调整文本框的大小，以确保其文本始终适合其中。

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 当文本框中的文本变得更长或更大时，PowerPoint 会自动放大文本框——增加其高度——以便能够容纳更多文本。
* 当文本框中的文本变得更短或更小时，PowerPoint 会自动缩小文本框——减少其高度——以清除多余的空间。

在 PowerPoint 中，有四个重要参数或选项控制文本框的自动调整行为：

* **不自动调整**
* **溢出时缩小文本**
* **调整形状以适应文本**
* **在形状中换行文本。**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java 提供了类似的选项——在 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类下的一些属性——允许您控制演示文稿中的文本框的自动调整行为。

## **调整形状以适应文本**

如果您希望文本框中的文本在更改后始终适合该文本框，则必须使用 **调整形状以适应文本** 选项。要指定该设置，请将 [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类）设置为 `Shape`。

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

此 PHP 代码显示了如何指定文本在 PowerPoint 演示文稿中必须始终适合其框：

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

如果文本变得更长或更大，文本框将被自动调整大小（增加高度），以确保所有文本都适合其中。如果文本变得更短，则反之亦然。

## **不自动调整**

如果您希望文本框或形状在所包含文本发生更改时保持其尺寸，则必须使用 **不自动调整** 选项。要指定该设置，请将 [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类）设置为 `None`。

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

此 PHP 代码显示了如何指定文本框在 PowerPoint 演示文稿中必须始终保持其尺寸：

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

当文本变得过长以适应其框时，会溢出。

## **溢出时缩小文本**

如果文本对其框过长，通过 **溢出时缩小文本** 选项，您可以指定文本的大小和间距必须减少，以使其适合其框。要指定该设置，请将 [AutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getAutofitType--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类）设置为 `Normal`。

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

此 PHP 代码显示了如何在 PowerPoint 演示文稿中指定文本在溢出时必须缩小：

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

{{% alert title="信息" color="info" %}}

当使用 **溢出时缩小文本** 选项时，仅当文本对其框变得过长时，设置才会应用。

{{% /alert %}}

## **换行文本**

如果您希望形状中的文本在文本超出形状边界（仅宽度）时换行，就必须使用 **在形状中换行文本** 参数。要指定该设置，您必须将 [WrapText](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getWrapText--) 属性（来自 [TextFrameFormat](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat) 类）设置为 `true`。

此 PHP 代码显示了如何在 PowerPoint 演示文稿中使用换行文本设置：

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

{{% alert title="注意" color="warning" %}}

如果您将形状的 `WrapText` 属性设置为 `False`，当形状内的文本长度超过形状的宽度时，文本会在一行中延伸超出形状的边界。

{{% /alert %}}