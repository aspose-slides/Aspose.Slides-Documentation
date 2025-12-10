---
title: 在 Java 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/java/manage-paragraph/
keywords:
- 添加文本
- 添加段落
- 管理文本
- 管理段落
- 管理项目符号
- 段落缩进
- 悬挂缩进
- 段落项目符号
- 编号列表
- 项目符号列表
- 段落属性
- 导入 HTML
- 文本转 HTML
- 段落转 HTML
- 段落转图像
- 文本转图像
- 导出段落
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 完成段落格式的高级控制——在 PPT、PPTX 和 ODP 演示文稿中优化对齐、间距和样式。"
---

Aspose.Slides 提供了在 Java 中处理 PowerPoint 文本、段落和文本块所需的所有接口和类。

* Aspose.Slides 提供了 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) 接口，允许您添加表示段落的对象。`ITextFame` 对象可以包含一个或多个段落（每个段落通过回车创建）。
* Aspose.Slides 提供了 [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) 接口，允许您添加表示文本块的对象。`IParagraph` 对象可以包含一个或多个文本块（iPortions 对象的集合）。
* Aspose.Slides 提供了 [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) 接口，允许您添加表示文本及其格式属性的对象。

`IParagraph` 对象能够通过其底层的 `IPortion` 对象处理具有不同格式属性的文本。

## **添加包含多个文本块的多个段落**

以下步骤演示如何添加一个包含 3 个段落且每个段落包含 3 个文本块的文本框：

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。
4. 获取与 [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) 关联的 ITextFrame。
5. 创建两个 [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) 对象，并将它们添加到 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) 的 `IParagraphs` 集合中。
6. 为每个新 `IParagraph` 创建三个 [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) 对象（默认段落创建两个 Portion 对象），并将每个 `IPortion` 对象添加到相应 `IParagraph` 的 IPortion 集合中。
7. 为每个文本块设置一些文本。
8. 使用 `IPortion` 对象提供的格式属性，为每个文本块应用您喜欢的格式设置。
9. 保存修改后的演示文稿。

此 Java 代码实现了添加包含文本块的段落的步骤：
```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // 访问 AutoShape 的 TextFrame
    ITextFrame tf = ashp.getTextFrame();

    // 创建具有不同文本格式的段落和文本块
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // 将 PPTX 写入磁盘
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **管理段落项目符号**

项目符号列表帮助您快速高效地组织和呈现信息。使用项目符号的段落更易阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向选定的幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) 类创建第一个段落实例。
7. 将段落的项目符号 `Type` 设置为 `Symbol`，并设置项目符号字符。
8. 设置段落的 `Text`。
9. 为项目符号设置段落的 `Indent`。
10. 为项目符号设置颜色。
11. 设置项目符号的高度。
12. 将新段落添加到 `TextFrame` 的段落集合中。
13. 添加第二个段落，并重复步骤 7 至 13 中的操作。
14. 保存演示文稿。

此 Java 代码演示如何添加段落项目符号：
```java
// 实例化表示 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问 Autoshape 的文本框
    ITextFrame txtFrm = aShp.getTextFrame();

    // 删除默认段落
    txtFrm.getParagraphs().removeAt(0);

    // 创建段落
    Paragraph para = new Paragraph();

    // 设置段落项目符号样式和符号
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // 设置段落文本
    para.setText("Welcome to Aspose.Slides");

    // 设置项目符号缩进
    para.getParagraphFormat().setIndent(25);

    // 设置项目符号颜色
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色

    // 设置项目符号高度
    para.getParagraphFormat().getBullet().setHeight(100);

    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para);

    // 创建第二段落
    Paragraph para2 = new Paragraph();

    // 设置段落项目符号类型和样式
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // 添加段落文本
    para2.setText("This is numbered bullet");

    // 设置项目符号缩进
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 将 IsBulletHardColor 设置为 true 以使用自定义项目符号颜色

    // 设置项目符号高度
    para2.getParagraphFormat().getBullet().setHeight(100);

    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para2);
    
    // 保存修改后的演示文稿
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **管理图片项目符号**

图片列表帮助您快速高效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) 中加载图像。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)，并设置图像。
9. 设置段落的 `Text`。
10. 为项目符号设置段落的 `Indent`。
11. 为项目符号设置颜色。
12. 设置项目符号的高度。
13. 将新段落添加到 `TextFrame` 的段落集合中。
14. 添加第二个段落，并根据前面的步骤重复操作。
15. 保存修改后的演示文稿。

此 Java 代码演示如何添加和管理图片项目符号：
```java
// 实例化一个代表 PPTX 文件的 Presentation 类
Presentation presentation = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = presentation.getSlides().get_Item(0);

    // 实例化项目符号的图像
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // 添加并访问 Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问 Autoshape 文本框
    ITextFrame textFrame = autoShape.getTextFrame();

    // 删除默认段落
    textFrame.getParagraphs().removeAt(0);

    // 创建新段落
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // 设置段落项目符号样式和图像
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // 设置项目符号高度
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // 将段落添加到文本框
    textFrame.getParagraphs().add(paragraph);

    // 将演示文稿写入 PPTX 文件
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // 将演示文稿写入 PPT 文件
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **管理多级项目符号**

多级项目符号帮助您快速高效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 在新幻灯片中添加一个 [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) 类创建第一个段落实例，并将深度设为 0。
7. 通过 `Paragraph` 类创建第二个段落实例，并将深度设为 1。
8. 通过 `Paragraph` 类创建第三个段落实例，并将深度设为 2。
9. 通过 `Paragraph` 类创建第四个段落实例，并将深度设为 3。
10. 将新段落添加到 `TextFrame` 的段落集合中。
11. 保存修改后的演示文稿。

此 Java 代码演示如何添加和管理多级项目符号：
```java
// 实例化一个代表 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问已创建的 Autoshape 的文本框
    ITextFrame text = aShp.addTextFrame("");

    // 清除默认段落
    text.getParagraphs().clear();

    // 添加第一段落
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para1.getParagraphFormat().setDepth((short)0);

    // 添加第二段落
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para2.getParagraphFormat().setDepth((short)1);

    // 添加第三段落
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para3.getParagraphFormat().setDepth((short)2);

    // 添加第四段落
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para4.getParagraphFormat().setDepth((short)3);

    // 将段落添加到集合中
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // 将演示文稿写入 PPTX 文件
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **管理带自定义编号的段落**

[IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) 接口提供了 [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 属性等，可让您管理带自定义编号或格式的段落。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。
2. 访问包含段落的幻灯片。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)。
5. 删除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) 类创建第一个段落实例，并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 设置为 2。
7. 通过 `Paragraph` 类创建第二个段落实例，并将 `NumberedBulletStartWith` 设置为 3。
8. 通过 `Paragraph` 类创建第三个段落实例，并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 的段落集合中。
10. 保存修改后的演示文稿。

此 Java 代码演示如何添加和管理带自定义编号的段落：
```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问已创建的自动形状的文本框
    ITextFrame textFrame = shape.getTextFrame();

    // 删除默认的现有段落
    textFrame.getParagraphs().removeAt(0);

    // 第一列表
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **设置段落缩进**

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。
1. 通过索引访问相应幻灯片的引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。
1. 向矩形 autoshape 添加一个包含三个段落的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)。
1. 隐藏矩形线条。
1. 通过它们的 BulletOffset 属性为每个 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) 设置缩进。
1. 将修改后的演示文稿写入 PPT 文件。

此 Java 代码演示如何设置段落缩进：
```java
// 实例化 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 添加一个矩形形状
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // 向矩形添加 TextFrame
    ITextFrame tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
    
    // 设置文本以适应形状
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // 隐藏矩形的线条
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // 获取 TextFrame 中的第一段落并设置其缩进
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // 设置段落项目符号样式和符号
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // 获取 TextFrame 中的第二段落并设置其缩进
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // 获取 TextFrame 中的第三段落并设置其缩进
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    //将演示文稿写入磁盘
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **为段落设置悬挂缩进**

此 Java 代码演示如何为段落设置悬挂缩进：
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Example");

    Paragraph para2 = new Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");

    Paragraph para3 = new Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");

    para2.getParagraphFormat().setMarginLeft(10f);
    para3.getParagraphFormat().setMarginLeft(20f);

    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **管理段落末尾运行属性**

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。
1. 通过位置获取包含该段落的幻灯片引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。
1. 向矩形添加一个包含两个段落的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)。
1. 为段落设置 `FontHeight` 和字体类型。
1. 为段落设置 End 属性。
1. 将修改后的演示文稿写入 PPTX 文件。

此 Java 代码演示如何为 PowerPoint 中的段落设置 End 属性：
```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将 HTML 文本导入段落**

Aspose.Slides 提供了增强的功能，将 HTML 文本导入段落。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/)。
4. 添加并访问 `autoshape` 的 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/)。
5. 删除 `ITextFrame` 中的默认段落。
6. 在 TextReader 中读取源 HTML 文件。
7. 通过 [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 TextReader 中的 HTML 内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/)。
9. 保存修改后的演示文稿。

此 Java 代码实现了将 HTML 文本导入段落的步骤：
```java
// 创建空的演示文稿实例
Presentation pres = new Presentation();
try {
    // 访问演示文稿的默认第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加 AutoShape 以容纳 HTML 内容
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // 向形状添加文本框
    ashape.addTextFrame("");

    // 清除已添加文本框中的所有段落
    ashape.getTextFrame().getParagraphs().clear();

    // 使用流读取器加载 HTML 文件
    TextReader tr = new StreamReader("file.html");

    // 从 HTML 流读取器将文本添加到文本框
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // 保存演示文稿
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **将段落文本导出为 HTML**

Aspose.Slides 提供了增强的功能，将段落中的文本导出为 HTML。

1. 创建 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 通过索引访问相应幻灯片的引用。
3. 访问包含将导出为 HTML 的文本的形状。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/)。
5. 创建 `StreamWriter` 实例并添加新的 HTML 文件。
6. 为 StreamWriter 提供起始索引并导出您选择的段落。

此 Java 代码演示如何将 PowerPoint 段落文本导出为 HTML：
```java
// 加载演示文稿文件
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // 访问演示文稿的默认第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 目标索引
    int index = 0;

    // 访问已添加的形状
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 创建输出 HTML 文件
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //提取第一个段落为 HTML
    // 将段落数据写入 HTML，提供段落起始索引和要复制的段落总数
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **将段落保存为图像**

在本节中，我们将演示两个示例，展示如何将由 [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) 接口表示的文本段落保存为图像。两个示例都包括使用 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 接口的 `getImage` 方法获取包含段落的形状图像，计算段落在形状中的边界，并将其导出为位图图像。这些方法允许您从 PowerPoint 演示文稿中提取特定文本部分并将其保存为单独的图像，适用于各种场景。

假设我们有一个名为 sample.pptx 的演示文稿，其中只有一张幻灯片，第一形状是包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

**示例 1**

在此示例中，我们获取第二段落的图像。为此，我们从演示文稿的第一张幻灯片中提取形状的图像，然后计算该形状文本框中第二段落的边界。随后将段落重新绘制到新的位图图像并以 PNG 格式保存。此方法在需要将特定段落保存为单独图像且保持文本精确尺寸和格式时特别有用。
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 将形状保存为内存中的位图。
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // 从内存创建形状位图。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 计算第二段落的边界。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // 计算输出图像的坐标和尺寸（最小尺寸为 1x1 像素）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // 裁剪形状位图，仅获取段落位图。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


结果：

![段落图像](paragraph_to_image_output.png)

**示例 2**

在此示例中，我们在前一种方法的基础上为段落图像添加了缩放因子。形状从演示文稿中提取并以缩放因子 `2` 保存为图像，这在导出段落时可获得更高分辨率的输出。随后在考虑缩放的情况下计算段落边界。缩放在需要更细致图像的场景（例如高质量印刷材料）中尤为有用。
```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // 将形状以缩放方式保存为内存中的位图。
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // 从内存创建形状位图。
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // 计算第二段落的边界。
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // 计算输出图像的坐标和尺寸（最小尺寸为 1x1 像素）。
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // 裁剪形状位图，仅获取段落位图。
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **FAQ**

**是否可以完全禁用文本框内的换行？**

可以。使用文本框的换行设置（[setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setWrapText-byte-)）关闭换行，这样行就不会在框边缘断开。

**如何获取特定段落在幻灯片上的精确边界？**

您可以检索段落（甚至单个文本块）的边界矩形，以了解其在幻灯片上的确切位置和大小。

**段落对齐方式（左/右/居中/两端对齐）在哪里控制？**

[Alignment](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setAlignment-int-) 是 [ParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/) 的段落级设置，适用于整个段落，而不受单个文本块格式的影响。

**是否可以仅为段落的一部分（例如一个单词）设置拼写检查语言？**

可以。语言在文本块级别设置（[PortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)），因此同一段落中可以共存多种语言。