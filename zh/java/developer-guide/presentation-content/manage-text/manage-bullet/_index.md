---
title: 使用 Java 管理演示文稿中的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 60
url: /zh/java/manage-bullet/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 演示文稿中管理项目符号和编号列表。一步一步的指南。"
---

在 **Microsoft PowerPoint** 中，您可以像在 Word 和其他文本编辑器中一样创建项目符号和编号列表。**Aspose.Slides for Java** 也允许您在演示文稿的幻灯片中使用项目符号和编号。

## **为什么使用项目符号列表？**

项目符号列表帮助您快速高效地组织和呈现信息。

**项目符号列表示例**

在大多数情况下，项目符号列表具有以下三项主要功能：

- 吸引读者或观众的注意力到重要信息
- 让读者或观众能够轻松浏览关键点
- 高效地传达和交付重要细节。

## **为什么使用编号列表？**

编号列表同样有助于组织和呈现信息。当条目的顺序（例如 *步骤 1，步骤 2* 等）重要或需要引用条目（例如 *参见步骤 3*）时，最好使用编号（而非项目符号）。

**编号列表示例**

以下是 **创建项目符号** 过程中的步骤（步骤 1 到步骤 15）摘要：

1. 创建演示文稿类的实例。 
2. 执行多个任务（步骤 3 到步骤 14）。 
3. 保存演示文稿。 

## **创建项目符号**

本主题也是管理文本段落系列主题的一部分。本页将演示如何管理段落项目符号。项目符号在需要分步骤描述时更有用。此外，使用项目符号可以使文本看起来更有条理。带项目符号的段落更易于阅读和理解。我们将看到开发者如何使用 Aspose.Slides for Java 的这一小而强大的功能。请按照以下步骤使用 Aspose.Slides for Java 管理段落项目符号：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。 
1. 使用 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。 
1. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText)。 
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame)。 
1. 删除 TextFrame 中的默认段落。 
1. 使用 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph) 类创建第一个段落实例。 
1. 设置段落的项目符号类型。 
1. 将项目符号类型设为 [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) 并设置项目符号字符。 
1. 设置段落文本。 
1. 设置段落缩进以设置项目符号。 
1. 设置项目符号的颜色。 
1. 设置项目符号的高度。 
1. 将创建的段落添加到 TextFrame 的段落集合中。 
1. 添加第二个段落并重复 **7 到 13** 步骤。 
1. 保存演示文稿。

以下是 Java 示例代码——上述步骤的实现——展示如何在幻灯片中创建项目符号列表：
```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加并访问自动形状
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 访问已创建自动形状的文本框
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // 移除默认的现有段落
    txtFrm.getParagraphs().removeAt(0);
    
    // 创建段落
    Paragraph para = new Paragraph();
    
    // 设置段落项目符号样式和符号
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // 设置段落文本
    para.setText("Welcome to Aspose.Slides");
    
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


## **创建图片项目符号**

Aspose.Slides for Java 允许您更改项目符号列表的项目符号。您可以用自定义符号或图像替换项目符号。如果您想为列表添加视觉趣味或使列表中的条目更突出，可以使用自己的图像作为项目符号。

{{% alert color="primary" %}} 

理想情况下，如果您打算用图片替换常规项目符号，建议选择具有透明背景的简洁图形图像。这类图像最适合作为自定义项目符号。

无论如何，所选图像都会被缩小到非常小的尺寸，因而我们强烈建议您选择在列表中作为项目符号替代时仍能保持良好外观的图像。

{{% /alert %}} 

创建图片项目符号，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例 
1. 使用 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片 
1. 在选定的幻灯片中添加自动形状 
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 
1. 删除 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 中的默认段落 
1. 使用 Paragraph 类创建第一个段落实例 
1. 在 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage) 中从磁盘加载图像 
1. 将项目符号类型设为 Picture 并设置图像 
1. 设置段落文本 
1. 设置段落缩进以设置项目符号 
1. 设置项目符号的颜色 
1. 设置项目符号的高度 
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 的段落集合中 
1. 添加第二个段落并重复前述步骤 
1. 保存演示文稿

以下 Java 代码展示如何在幻灯片中创建图片项目符号：
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

    // 添加并访问自动形状
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问已创建自动形状的文本框
    ITextFrame txtFrm = aShp.getTextFrame();
    // 移除默认的现有段落
    txtFrm.getParagraphs().removeAt(0);

    // 创建新的段落
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // 设置段落项目符号样式和图像
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 设置项目符号高度
    para.getParagraphFormat().getBullet().setHeight(100);

    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para);

    // 将演示文稿写入为 PPTX 文件
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **创建多级项目符号**

要创建包含不同层级项目的列表（主项目符号列表下的子列表），请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。 
1. 使用 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。 
1. 在选定的幻灯片中添加自动形状。 
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)。 
1. 删除 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 中的默认段落。 
1. 使用 Paragraph 类创建第一个段落实例，并将 depth 设置为 0。 
1. 使用 Paragraph 类创建第二个段落实例，并将 depth 设置为 1。 
1. 使用 Paragraph 类创建第三个段落实例，并将 depth 设置为 2。 
1. 使用 Paragraph 类创建第四个段落实例，并将 depth 设置为 3。 
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 的段落集合中。 
1. 保存演示文稿。

以下代码实现上述步骤，展示如何在 Java 中创建多级项目符号列表：
```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加并访问自动形状
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 访问已创建自动形状的文本框
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // 移除默认的现有段落
    txtFrm.getParagraphs().clear();
    
    // 创建第一个段落
    Paragraph para1 = new Paragraph();
    // 设置段落项目符号样式和符号
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //设置项目符号层级
    para1.getParagraphFormat().setDepth ((short)0);
    
    // 创建第二个段落
    Paragraph para2 = new Paragraph();
    // 设置段落项目符号样式和符号
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //设置项目符号层级
    para2.getParagraphFormat().setDepth ((short)1);
    
    // 创建第三个段落
    Paragraph para3 = new Paragraph();
    // 设置段落项目符号样式和符号
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //设置项目符号层级
    para3.getParagraphFormat().setDepth ((short)2);
    
    // 创建第四个段落
    Paragraph para4 = new Paragraph();
    // 设置段落项目符号样式和符号
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //设置项目符号层级
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


## **创建自定义编号列表**

Aspose.Slides for Java 提供了简便的 API 来管理具有自定义数字格式的段落。要在段落中添加自定义编号列表，请按照以下步骤操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。 
1. 使用 [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。 
1. 在选定的幻灯片中添加自动形状。 
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)。 
1. 删除 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 中的默认段落。 
1. 使用 Paragraph 类创建第一个段落实例，并将 **NumberedBulletStartWith** 设置为 2 
1. 使用 Paragraph 类创建第二个段落实例，并将 **NumberedBulletStartWith** 设置为 3 
1. 使用 Paragraph 类创建第三个段落实例，并将 **NumberedBulletStartWith** 设置为 7 
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) 的段落集合中。 
1. 保存演示文稿。

以下 Java 代码展示如何在幻灯片中创建编号列表：
```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加并访问自动形状
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问已创建自动形状的文本框
    ITextFrame txtFrm = aShp.addTextFrame("");

    // 移除默认的现有段落
    txtFrm.getParagraphs().clear();

    // 第一个列表
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // 第二个列表
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **常见问题**

**使用 Aspose.Slides 创建的项目符号和编号列表能导出为 PDF 或图片等其他格式吗？**

是的，Aspose.Slides 在将演示文稿导出为 PDF、图片等格式时，完整保留项目符号和编号列表的格式和结构，确保结果一致。

**是否可以从现有演示文稿中导入项目符号或编号列表？**

是的，Aspose.Slides 允许您导入并编辑现有演示文稿中的项目符号或编号列表，同时保留其原始格式和外观。

**Aspose.Slides 是否支持多语言演示文稿中的项目符号和编号列表？**

是的，Aspose.Slides 完全支持多语言演示文稿，您可以使用任何语言创建项目符号和编号列表，包括特殊字符或非拉丁字符。