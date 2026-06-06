---
title: 在 Android 上管理演示文稿中的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 60
url: /zh/androidjava/manage-lists/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号、图片、多级和编号列表。"
---
## **概述**

Aspose.Slides for Android via Java 可让您在 PowerPoint 和 OpenDocument 演示文稿中创建和格式化项目符号列表和编号列表。列表项是段落，其项目符号设置通过段落格式进行控制。

使用 [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) 方法访问段落级别的列表设置。主要入口是 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)，它返回一个 [IBulletFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/) 对象。通过该对象，您可以设置项目符号类型、符号、图片、颜色、大小、编号样式以及起始编号。

本文展示了如何：

- 使用自定义符号创建项目符号列表
- 创建图片项目符号
- 通过设置段落深度创建多级列表
- 创建编号列表
- 检查并更改现有演示文稿中的列表格式

## **创建项目符号列表**

要创建项目符号列表，向 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/) 添加段落，并将 [IBulletFormat.setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/bullettype/)。随后可以使用 [IBulletFormat.setChar](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setChar-char-)、[IBulletFormat.getColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#getColor--) 和 [IBulletFormat.setHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) 来控制项目符号的外观。

以下 Java 代码演示了如何在幻灯片中创建项目符号列表：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

效果：

![The symbol bullets](symbol_bullets.png)

## **创建编号列表**

当项目顺序重要时使用编号列表。将 [IBulletFormat.setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/bullettype/)。您还可以使用 [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) 选择编号格式，或使用 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 在列表需要从除 1 之外的其他值开始时进行设置。

以下 Java 代码展示了如何在幻灯片中创建编号列表：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

效果：

![The numbered bullets](numbered_bullets.png)

## **创建图片项目符号**

Aspose.Slides 允许您用图像替换常规的项目符号符号。图片项目符号最适合使用在小尺寸下仍能保持可读性的简洁图像，例如图标或小型透明 PNG 文件。

{{% alert color="primary" %}}
理想情况下，如果您计划用图像替换常规项目符号，最好选择具有透明背景的简洁图形。这类图像可作为自定义项目符号使用效果很好。
请记住，图像会被缩小到非常小的尺寸。因此，我们强烈建议您选择在列表中作为项目符号使用时仍保持清晰且视觉有效的图像。
{{% /alert %}}

要创建图片项目符号，向 [Presentation.getImages](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#getImages--) 添加图像，并将返回的 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 对象赋给 [IBulletFormat.getPicture](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#getPicture--)。在分配图像之前，将 [IBulletFormat.setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) 设置为 [BulletType.Picture](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/bullettype/)。

假设我们有一张 “image.png”：

![A picture for the bullets](picture_for_bullets.png)

以下 Java 代码展示了如何在幻灯片中创建图片项目符号：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

效果：

![The picture bullets](picture_bullets.png)

## **创建多级列表**

使用 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) 将列表项放置在不同层级。层级 0 为顶层，层级 1 为其下的嵌套层，以此类推。

以下 Java 代码展示了如何创建多级项目符号列表：

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

效果：

![The multilevel list](multilevel_list.png)

## **更改已有列表**

要更改现有演示文稿中的列表格式，访问目标段落并更新其 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 设置。创建列表时使用的相同方法可用于检查或修改从 PPT、PPTX 或 ODP 文件加载的列表。

以下 Java 代码将文本框中的第一段落改为使用编号列表样式：

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常见问题解答**

**项目符号和编号列表可以导出为 PDF 或图像吗？**

可以。Aspose.Slides 在目标格式支持相应的文本布局和项目符号特性时，会保留列表格式。

**我可以编辑已有演示文稿中的列表吗？**

可以。加载演示文稿，访问目标段落，检查或更新其 [IParagraphFormat.getBullet](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) 设置，然后保存演示文稿。

**列表可以包含非拉丁文字吗？**

可以。列表项文本支持 Unicode 字符，您可以在多语言演示文稿中创建列表。请确保演示文稿使用的字体支持所需字符。