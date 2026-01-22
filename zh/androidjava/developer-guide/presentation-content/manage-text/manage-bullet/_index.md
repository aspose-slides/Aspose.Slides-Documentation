---
title: 在 Android 上管理演示文稿中的项目符号和编号列表
linktitle: 管理列表
type: docs
weight: 60
url: /zh/androidjava/manage-bullet/
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
description: "了解如何使用 Aspose.Slides for Android via Java 在 PowerPoint 和 OpenDocument 演示文稿中管理项目符号和编号列表。分步指南。"
---

在 **Microsoft PowerPoint** 中，您可以像在 Word 和其他文字编辑器中一样创建项目符号列表和编号列表。**Aspose.Slides for Android via Java** 也允许您在演示文稿的幻灯片中使用项目符号和编号。

## **为什么使用项目符号列表？**

项目符号列表帮助您快速高效地组织和展示信息。

**项目符号列表示例**

在大多数情况下，项目符号列表承担以下三大功能：

- 吸引读者或观众注意重要信息
- 让读者或观众轻松扫描关键点
- 高效地传达并交付重要细节。

## **为什么使用编号列表？**

编号列表同样有助于组织和展示信息。当条目的顺序（例如 *步骤 1、步骤 2* 等）重要，或需要引用某个条目（例如 *参见步骤 3*）时，最好使用编号代替项目符号。

**编号列表示例**

以下是 **创建项目符号** 过程中的步骤摘要（步骤 1 至步骤 15）：

1. 创建演示文稿类的实例。  
2. 执行多个任务（步骤 3 至步骤 14）。  
3. 保存演示文稿。  

## **创建项目符号**
本章节也是管理文本段落系列主题的一部分。本页将演示如何管理段落项目符号。项目符号在需要按步骤描述内容时尤为有用。此外，使用项目符号可以使文本看起来更有条理。带项目符号的段落始终更易于阅读和理解。下面将展示开发者如何使用 Aspose.Slides for Android via Java 的这一小而强大的功能。请按照以下步骤使用 Aspose.Slides for Android via Java 管理段落项目符号：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。  
1. 使用 [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。  
1. 在选定的幻灯片中添加一个 [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText)。  
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame)。  
1. 删除 TextFrame 中的默认段落。  
1. 使用 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph) 类创建第一段实例。  
1. 设置段落的项目符号类型。  
1. 将项目符号类型设为 [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) 并设置项目符号字符。  
1. 设置段落文本。  
1. 设置段落缩进以放置项目符号。  
1. 设置项目符号的颜色。  
1. 设置项目符号的高度。  
1. 将创建的段落添加到 TextFrame 的段落集合中。  
1. 添加第二段并重复 **7 至 13** 步骤。  
1. 保存演示文稿。

下面的 Java 示例代码实现了上述步骤，展示了如何在幻灯片中创建项目符号列表：
```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 访问已创建的 Autoshape 的文本框
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // 删除默认的现有段落
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

Aspose.Slides for Android via Java 允许您更改项目符号列表中的项目符号。您可以将项目符号替换为自定义符号或图片。如果希望为列表添加视觉兴趣或进一步突出列表项，可使用自己的图片作为项目符号。

{{% alert color="primary" %}}  

理想情况下，如果您打算用图片替换常规项目符号，建议选择背景透明的简洁图形图片。这类图片最适合作为自定义项目符号。  

无论如何，所选图片都会被缩小到极小尺寸，因此强烈建议您选择在列表中作为项目符号替代时仍然清晰可辨的图片。  

{{% /alert %}}  

创建图片项目符号，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例  
1. 使用 [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片  
1. 在选定的幻灯片中添加一个 autoshape  
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)  
1. 删除 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 中的默认段落  
1. 使用 Paragraph 类创建第一段实例  
1. 在 [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 中从磁盘加载图片  
1. 将项目符号类型设为 Picture 并设置图片  
1. 设置段落文本  
1. 设置段落缩进以放置项目符号  
1. 设置项目符号的颜色  
1. 设置项目符号的高度  
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 的段落集合中  
1. 添加第二段并重复前述步骤  
1. 保存演示文稿

下面的 Java 代码展示了如何在幻灯片中创建图片项目符号：
```java
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 实例化用于项目符号的图片
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问已创建的 Autoshape 的文本框
    ITextFrame txtFrm = aShp.getTextFrame();
    // 删除默认的现有段落
    txtFrm.getParagraphs().removeAt(0);

    // 创建新段落
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // 设置段落项目符号样式和图片
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

要创建包含不同层级项目的列表（即在主项目符号列表下的子列表），请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。  
1. 使用 [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。  
1. 在选定的幻灯片中添加一个 autoshape。  
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)。  
1. 删除 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 中的默认段落。  
1. 使用 Paragraph 类创建第一段实例，深度设为 0。  
1. 使用 Paragraph 类创建第二段实例，深度设为 1。  
1. 使用 Paragraph 类创建第三段实例，深度设为 2。  
1. 使用 Paragraph 类创建第四段实例，深度设为 3。  
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 的段落集合中。  
1. 保存演示文稿。

以下代码实现了上述步骤，展示了如何在 Java 中创建多级项目符号列表：
```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // 访问已创建的 Autoshape 的文本框
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // 删除默认的现有段落
    txtFrm.getParagraphs().clear();
    
    // 创建第一段
    Paragraph para1 = new Paragraph();
    // 设置段落项目符号样式和符号
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号层级
    para1.getParagraphFormat().setDepth ((short)0);
    
    // 创建第二段
    Paragraph para2 = new Paragraph();
    // 设置段落项目符号样式和符号
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号层级
    para2.getParagraphFormat().setDepth ((short)1);
    
    // 创建第三段
    Paragraph para3 = new Paragraph();
    // 设置段落项目符号样式和符号
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号层级
    para3.getParagraphFormat().setDepth ((short)2);
    
    // 创建第四段
    Paragraph para4 = new Paragraph();
    // 设置段落项目符号样式和符号
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号层级
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
Aspose.Slides for Android via Java 提供了简便的 API 来管理带有自定义编号格式的段落。要在段落中添加自定义编号列表，请按以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。  
1. 使用 [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) 对象访问幻灯片集合中的目标幻灯片。  
1. 在选定的幻灯片中添加一个 autoshape。  
1. 访问所添加形状的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)。  
1. 删除 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 中的默认段落。  
1. 使用 Paragraph 类创建第一段实例，并将 **NumberedBulletStartWith** 设置为 2。  
1. 使用 Paragraph 类创建第二段实例，并将 **NumberedBulletStartWith** 设置为 3。  
1. 使用 Paragraph 类创建第三段实例，并将 **NumberedBulletStartWith** 设置为 7。  
1. 将创建的段落添加到 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) 的段落集合中。  
1. 保存演示文稿。

下面的 Java 代码展示了如何在幻灯片中创建编号列表：
```java
// 实例化一个表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问已创建的 Autoshape 的文本框
    ITextFrame txtFrm = aShp.addTextFrame("");

    // 删除默认的现有段落
    txtFrm.getParagraphs().clear();

    // 第一组列表
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

    // 第二组列表
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


## **FAQ**

**使用 Aspose.Slides 创建的项目符号和编号列表可以导出为 PDF 或图像等其他格式吗？**

可以，Aspose.Slides 在将演示文稿导出为 PDF、图像等格式时，会完整保留项目符号和编号列表的格式和结构，确保结果一致。

**是否可以从现有演示文稿中导入项目符号或编号列表？**

可以，Aspose.Slides 允许您导入并编辑现有演示文稿中的项目符号或编号列表，同时保留其原始格式和外观。

**Aspose.Slides 是否支持在多语言演示文稿中使用项目符号和编号列表？**

可以，Aspose.Slides 完全支持多语言演示文稿，您可以使用任何语言创建项目符号和编号列表，包括使用特殊或非拉丁字符。