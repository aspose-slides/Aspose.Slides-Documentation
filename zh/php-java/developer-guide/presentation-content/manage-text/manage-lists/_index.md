---
title: 使用 PHP 管理演示文稿中的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 60
url: /zh/php-java/manage-lists/
keywords:
- 项目符号
- 项目符号列表
- 编号列表
- 符号项目符号
- 图片项目符号
- 自定义项目符号
- 多级列表
- 创建项目符号
- 添加项目符号
- 添加列表
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号、图片、多级和编号列表。"
---
## **概览**

Aspose.Slides for PHP via Java 允许您在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号列表和编号列表。列表项是一个段落，其项目符号设置由段落格式控制。

使用 [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#getParagraphFormat--) 方法可访问段落级别的列表设置。主要入口是 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#getBullet--)，它返回一个 [BulletFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/) 对象。通过该对象，您可以设置项目符号的类型、符号、图片、颜色、大小、编号样式及起始编号。

本文展示了如何：

- 创建带自定义符号的项目符号列表
- 创建图片项目符号
- 通过设置段落深度创建多级列表
- 创建编号列表
- 检查并更改现有演示文稿中的列表格式

## **创建项目符号列表**

要创建项目符号列表，向 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 中添加 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 对象，并将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setType-int-) 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bullettype/#Symbol)。随后可以设置 [BulletFormat.setChar](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setChar-char-)、[BulletFormat.getColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#getColor--) 和 [BulletFormat.setHeight](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setHeight-float-) 来控制项目符号的外观。

以下 PHP 代码演示如何在幻灯片中创建项目符号列表：

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

结果如下：

![符号项目符号](symbol_bullets.png)

## **创建编号列表**

当项目顺序重要时使用编号列表。将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setType-int-) 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bullettype/#Numbered)。您还可以通过 [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) 选择编号格式，或使用 [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) 设置列表起始值（非 1 时）。

以下 PHP 代码展示如何在幻灯片中创建编号列表：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

结果如下：

![编号项目符号](numbered_bullets.png)

## **创建图片项目符号**

Aspose.Slides 允许您使用图像替换普通的项目符号。图片项目符号最适合在小尺寸下仍保持可读性的简洁图像，例如图标或小型透明 PNG 文件。

{{% alert color="primary" %}}
理想情况下，如果您计划用图像替换普通项目符号，最好选择具有透明背景的简洁图形。这类图像非常适合作为自定义项目符号。

请注意，图像会被缩小到非常小的尺寸。因此，我们强烈建议选择在列表中作为项目符号使用时仍保持清晰且视觉有效的图像。
{{% /alert %}}

要创建图片项目符号，向 [Presentation.getImages](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getImages--) 添加图像，并将返回的 [PPImage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/ppimage/) 对象分配给 [BulletFormat.getPicture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#getPicture--)。在分配图像之前，将 [BulletFormat.setType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bulletformat/#setType-int-) 设置为 [BulletType.Picture](https://reference.aspose.com/slides/zh/php-java/aspose.slides/bullettype/#Picture)。

假设我们有一个 "image.png"：

![用于项目符号的图片](picture_for_bullets.png)

以下 PHP 代码展示如何在幻灯片中创建图片项目符号：

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

结果如下：

![图片项目符号](picture_bullets.png)

## **创建多级列表**

使用 [ParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setDepth-short-) 将列表项放置在不同层级。层级 0 为顶层，层级 1 为其下的嵌套层，以此类推。

以下 PHP 代码展示如何创建多级项目符号列表：

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

结果如下：

![多级列表](multilevel_list.png)

## **更改现有列表**

要更改现有演示文稿中的列表格式，访问目标段落并更新其 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#getBullet--) 设置。创建列表时使用的相同属性也可用于检查或修改从 PPT、PPTX 或 ODP 文件加载的列表。

以下 PHP 代码将文本框中的第一个段落更改为使用编号列表样式：

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **常见问题**

**项目符号和编号列表可以导出为 PDF 或图像吗？**

是的。当目标格式支持相应的文本布局和项目符号特性时，Aspose.Slides 会保留列表格式。

**我可以编辑现有演示文稿中的列表吗？**

是的。加载演示文稿，访问目标段落，检查或更新其 [ParagraphFormat.getBullet](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#getBullet--) 设置，然后保存演示文稿。

**列表可以包含非拉丁文字吗？**

是的。列表项文本可以包含 Unicode 字符，因此您可以在多语言演示文稿中创建列表。请确保演示文稿中使用的字体支持所需的字符。