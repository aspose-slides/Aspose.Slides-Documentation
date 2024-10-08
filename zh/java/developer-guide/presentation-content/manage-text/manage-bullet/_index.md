---
title: 管理项目符号
type: docs
weight: 60
url: /zh/java/manage-bullet/
keywords: "项目符号, 项目符号列表, 数字, 编号列表, 图片项目符号, 多级项目符号, PowerPoint 演示文稿, Java, Aspose.Slides for Java"
description: "在 Java 中创建 PowerPoint 演示文稿中的项目符号和编号列表"
---

在 **Microsoft PowerPoint** 中，您可以像在 Word 和其他文本编辑器中一样创建项目符号和编号列表。 **Aspose.Slides for Java** 还允许您在演示文稿中的幻灯片上使用项目符号和数字。

## 为什么使用项目符号列表？

项目符号列表可以帮助您快速有效地组织和呈现信息。

**项目符号列表示例**

在大多数情况下，项目符号列表有以下三个主要功能：

- 吸引读者或观众的注意力到重要信息
- 使读者或观众能够轻松扫描关键点
- 有效地传达和传递重要细节。

## 为什么使用编号列表？

编号列表也有助于组织和呈现信息。 理想情况下，当条目的顺序（例如，*步骤 1，步骤 2* 等）很重要或当需要引用某个条目（例如，*见步骤 3*）时，您应该使用数字（代替项目符号）。

**编号列表示例**

以下是 **创建项目符号** 过程中的步骤摘要（步骤 1 到步骤 15）：

1. 创建演示文稿类的实例。
2. 执行几个任务（步骤 3 到步骤 14）。
3. 保存演示文稿。

## 创建项目符号
本主题也是管理文本段落主题系列的一部分。 本页将说明如何管理段落项目符号。 在需要分步骤描述某些内容的地方，项目符号更为有用。 此外，使用项目符号的文本看起来更有条理。 项目符号段落始终更容易阅读和理解。 我们将看到开发人员如何使用 Aspose.Slides for Java 这个小而强大的功能。 请按照以下步骤使用 Aspose.Slides for Java 管理段落项目符号：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 使用 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) 对象访问幻灯片集合中的所需幻灯片。
1. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText)。
1. 访问添加的形状的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)。
1. 删除 TextFrame 中的默认段落。
1. 使用 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) 类创建第一个段落实例。
1. 设置段落的项目符号类型。
1. 将项目符号类型设置为 [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) 并设置项目符号字符。
1. 设置段落文本。
1. 设置段落缩进以设置项目符号。
1. 设置项目符号的颜色。
1. 设置项目符号的高度。
1. 将创建的段落添加到 TextFrame 段落集合中。
1. 添加第二个段落并重复步骤 **7 到 13** 中给出的过程。
1. 保存演示文稿。

以下是 Java 中的示例代码--上述步骤的实现--展示了如何在幻灯片中创建项目符号列表：

```java
// 创建表示 PPTX 文件的 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 访问创建的 autoshape 的文本框
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // 移除默认的现有段落
    txtFrm.getParagraphs().removeAt(0);
    
    // 创建段落
    Paragraph para = new Paragraph();
    
    // 设置段落的项目符号样式和符号
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // 设置段落文本
    para.setText("欢迎使用 Aspose.Slides");
    
    // 设置项目符号缩进
    para.getParagraphFormat().setIndent(25);
    
    // 设置项目符号颜色
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // 设置项目符号高度
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para);
    
    // 将演示文稿保存为 PPTX 文件
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## 创建图片项目符号

Aspose.Slides for Java 允许您更改项目符号列表上的项目符号。 您可以用自定义符号或图像替换项目符号。 如果您想为列表增加视觉趣味或进一步吸引对列表上条目的关注，可以使用您自己的图像作为项目符号。

{{% alert color="primary" %}} 

理想情况下，如果您打算用图片替换常规项目符号，您可能希望选择一张具有透明背景的简单图形图像。 这样的图像作为自定义项目符号效果最佳。 

无论如何，您选择的图像将缩小到非常小的尺寸，因此我们强烈建议您选择在列表中看起来不错（作为项目符号的替代品）的图像。

{{% /alert %}} 

要创建图片项目符号，请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例
1. 使用 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) 对象访问幻灯片集合中的所需幻灯片
1. 在选定的幻灯片中添加一个 autoshape
1. 访问添加的形状的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)
1. 删除 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 中的默认段落
1. 使用 Paragraph 类创建第一个段落实例
1. 从磁盘加载图像到 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage)
1. 将项目符号类型设置为 Picture 并设置图像
1. 设置段落文本
1. 设置段落缩进以设置项目符号
1. 设置项目符号的颜色
1. 设置项目符号的高度
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 段落集合中
1. 添加第二个段落并重复之前步骤中的过程
1. 保存演示文稿

以下 Java 代码展示了如何在幻灯片中创建图片项目符号：

```java
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 为项目符号实例化图像
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问创建的 autoshape 的文本框
    ITextFrame txtFrm = aShp.getTextFrame();
    // 移除默认的现有段落
    txtFrm.getParagraphs().removeAt(0);

    // 创建新段落
    Paragraph para = new Paragraph();
    para.setText("欢迎使用 Aspose.Slides");

    // 设置段落的项目符号样式和图像
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 设置项目符号高度
    para.getParagraphFormat().getBullet().setHeight(100);

    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para);

    // 将演示文稿写入 PPTX 文件
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## 创建多级项目符号

要创建一个包含不同级别项目的项目符号列表——主项目符号列表下的附加列表——请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 使用 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) 对象访问幻灯片集合中的所需幻灯片。
1. 在选定的幻灯片中添加一个 autoshape。
1. 访问添加的形状的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)。
1. 删除 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 中的默认段落。
1. 使用段落类创建第一个段落实例，并将深度设置为 0。
1. 使用段落类创建第二个段落实例，并将深度设置为 1。
1. 使用段落类创建第三个段落实例，并将深度设置为 2。
1. 使用段落类创建第四个段落实例，并将深度设置为 3。
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 段落集合中。
1. 保存演示文稿。

以下代码是上述步骤的实现，展示了如何在 Java 中创建多级项目符号列表：

```java
// 创建表示 PPTX 文件的 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 访问创建的 autoshape 的文本框
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // 移除默认的现有段落
    txtFrm.getParagraphs().clear();
    
    // 创建第一个段落
    Paragraph para1 = new Paragraph();
    // 设置段落的项目符号样式和符号
    para1.setText("内容");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para1.getParagraphFormat().setDepth ((short)0);
    
    // 创建第二个段落
    Paragraph para2 = new Paragraph();
    // 设置段落的项目符号样式和符号
    para2.setText("第二级");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para2.getParagraphFormat().setDepth ((short)1);
    
    // 创建第三个段落
    Paragraph para3 = new Paragraph();
    // 设置段落的项目符号样式和符号
    para3.setText("第三级");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para3.getParagraphFormat().setDepth ((short)2);
    
    // 创建第四个段落
    Paragraph para4 = new Paragraph();
    // 设置段落的项目符号样式和符号
    para4.setText("第四级");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para4.getParagraphFormat().setDepth ((short)3);
    
    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // 将演示文稿保存为 PPTX 文件
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## 创建自定义编号列表
Aspose.Slides for Java 提供了一个简单的 API 来管理带有自定义数字格式的段落。 要在段落中添加自定义数字列表，请遵循以下步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
1. 使用 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) 对象访问幻灯片集合中的所需幻灯片。
1. 在选定的幻灯片中添加一个 autoshape。
1. 访问添加的形状的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)。
1. 删除 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 中的默认段落。
1. 使用段落类创建第一个段落实例并将 **NumberedBulletStartWith** 设置为 2。
1. 使用段落类创建第二个段落实例并将 **NumberedBulletStartWith** 设置为 3。
1. 使用段落类创建第三个段落实例并将 **NumberedBulletStartWith** 设置为 7。
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 段落集合中。
1. 保存演示文稿。

以下 Java 代码展示了如何在幻灯片中创建编号列表：

```java
// 创建表示 PPTX 文件的 Presentation 类的实例
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问创建的 autoshape 的文本框
    ITextFrame txtFrm = aShp.addTextFrame("");

    // 移除默认的现有段落
    txtFrm.getParagraphs().clear();

    // 第一个列表
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("项目符号 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("项目符号 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // 第二个列表
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("项目符号 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```