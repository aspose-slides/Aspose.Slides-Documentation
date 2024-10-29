---
title: 在 Java 中管理 PowerPoint 段落
type: docs
weight: 40
url: /zh/androidjava/manage-paragraph/
keywords: "添加 PowerPoint 段落, 管理段落, 段落缩进, 段落属性, HTML 文本, 导出段落文本, PowerPoint 演示文稿, Java, Aspose.Slides for Android via Java"
description: "在 Java 中创建和管理 PowerPoint 演示文稿中的段落、文本、缩进和属性"
---

Aspose.Slides 提供了在 Java 中处理 PowerPoint 文本、段落和部分所需的所有接口和类。

* Aspose.Slides 提供 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 接口，允许您添加表示段落的对象。一个 `ITextFrame` 对象可以具有一个或多个段落（每个段落通过换行符创建）。
* Aspose.Slides 提供 [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) 接口，允许您添加表示部分的对象。一个 `IParagraph` 对象可以具有一个或多个部分（iPortions 对象的集合）。
* Aspose.Slides 提供 [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) 接口，允许您添加表示文本及其格式属性的对象。

一个 `IParagraph` 对象能够通过其底层的 `IPortion` 对象处理具有不同格式属性的文本。

## **添加包含多个部分的多个段落**

以下步骤展示如何添加一个包含 3 个段落的文本框，每个段落包含 3 个部分：

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 向幻灯片添加一个矩形 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。
4. 获取与 [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) 关联的 ITextFrame。
5. 创建两个 [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) 对象并将它们添加到 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) 的 `IParagraphs` 集合中。
6. 为每个新的 `IParagraph` 创建三个 [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) 对象（默认段落需要两个部分对象），并将每个 `IPortion` 对象添加到每个 `IParagraph` 的 IPortion 集合中。
7. 为每个部分设置一些文本。
8. 利用 `IPortion` 对象暴露的格式属性，对每个部分应用您偏好的格式特性。
9. 保存修改后的演示文稿。

以下是添加段落的 Java 代码示例：

```java
// 实例化代表 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 添加一个矩形类型的 AutoShape
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // 访问 AutoShape 的 TextFrame
    ITextFrame tf = ashp.getTextFrame();

    // 创建具有不同文本格式的段落和部分
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

    //将 PPTX 写入磁盘
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **管理段落项目符号**

项目符号列表帮助您快速有效地组织和呈现信息。带项目符号的段落通常更易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 向选定的幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) 类创建第一个段落实例。
7. 为段落设置项目符号 `Type` 为 `Symbol` 并设置项目符号字符。
8. 设置段落 `Text`。
9. 为项目符号设置段落 `Indent`。
10. 为项目符号设置颜色。
11. 为项目符号设置高度。
12. 将新段落添加到 `TextFrame` 段落集合中。
13. 添加第二个段落并重复步骤 7 到 13 中的过程。
14. 保存演示文稿。

以下 Java 代码演示如何添加段落项目符号：

```java
// 实例化代表 PPTX 文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 添加并访问 Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问 Autoshape 文本框
    ITextFrame txtFrm = aShp.getTextFrame();

    // 移除默认段落
    txtFrm.getParagraphs().removeAt(0);

    // 创建段落
    Paragraph para = new Paragraph();

    // 设置段落项目符号样式和符号
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // 设置段落文本
    para.setText("欢迎使用 Aspose.Slides");

    // 设置项目符号缩进
    para.getParagraphFormat().setIndent(25);

    // 设置项目符号颜色
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 将 IsBulletHardColor 设置为 true 以使用自己的项目符号颜色

    // 设置项目符号高度
    para.getParagraphFormat().getBullet().setHeight(100);

    // 将段落添加到文本框
    txtFrm.getParagraphs().add(para);

    // 创建第二个段落
    Paragraph para2 = new Paragraph();

    // 设置段落项目符号类型和样式
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // 添加段落文本
    para2.setText("这是编号项目符号");

    // 设置项目符号缩进
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // 将 IsBulletHardColor 设置为 true 以使用自己的项目符号颜色

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

项目符号列表帮助您快速有效地组织和呈现信息。图片段落易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 使用 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) 类创建第一个段落实例。
7. 在 [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 中加载图像。
8. 将项目符号类型设置为 [Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 并设置图像。
9. 设置段落 `Text`。
10. 为项目符号设置段落 `Indent`。
11. 为项目符号设置颜色。
12. 为项目符号设置高度。
13. 将新段落添加到 `TextFrame` 段落集合中。
14. 添加第二个段落并根据之前的步骤重复过程。
15. 保存修改后的演示文稿。

以下 Java 代码演示如何添加和管理图片项目符号：

```java
// 实例化代表 PPTX 文件的 Presentation 类
Presentation presentation = new Presentation();
try {
    // 访问第一张幻灯片
    ISlide slide = presentation.getSlides().get_Item(0);

    // 实例化用于项目符号的图像
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

    // 移除默认段落
    textFrame.getParagraphs().removeAt(0);

    // 创建一个新段落
    Paragraph paragraph = new Paragraph();
    paragraph.setText("欢迎使用 Aspose.Slides");

    // 设置段落的项目符号样式和图像
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

项目符号列表帮助您快速有效地组织和呈现信息。多级项目符号易于阅读和理解。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 在新幻灯片中添加一个 [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) 类创建第一个段落实例，并将深度设置为 0。
7. 通过 `Paragraph` 类创建第二个段落实例，并将深度设置为 1。
8. 通过 `Paragraph` 类创建第三个段落实例，并将深度设置为 2。
9. 通过 `Paragraph` 类创建第四个段落实例，并将深度设置为 3。
10. 将新段落添加到 `TextFrame` 段落集合中。
11. 保存修改后的演示文稿。

以下 Java 代码演示如何添加和管理多级项目符号：

```java
// 实例化代表 PPTX 文件的 Presentation 类
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

    // 添加第一个段落
    IParagraph para1 = new Paragraph();
    para1.setText("内容");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para1.getParagraphFormat().setDepth((short)0);

    // 添加第二个段落
    IParagraph para2 = new Paragraph();
    para2.setText("第二级");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para2.getParagraphFormat().setDepth((short)1);

    // 添加第三个段落
    IParagraph para3 = new Paragraph();
    para3.setText("第三级");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para3.getParagraphFormat().setDepth((short)2);

    // 添加第四个段落
    IParagraph para4 = new Paragraph();
    para4.setText("第四级");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // 设置项目符号级别
    para4.getParagraphFormat().setDepth((short)3);

    // 将段落添加到集合
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


## **管理带有自定义编号列表的段落**

[IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) 接口提供 [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 属性及其他操作，允许您管理具有自定义编号或格式的段落。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 访问包含段落的幻灯片。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。
4. 访问 autoshape 的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `TextFrame` 中的默认段落。
6. 通过 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) 类创建第一个段落实例，并将 [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 设置为 2。
7. 通过 `Paragraph` 类创建第二个段落实例，并将 `NumberedBulletStartWith` 设置为 3。
8. 通过 `Paragraph` 类创建第三个段落实例，并将 `NumberedBulletStartWith` 设置为 7。
9. 将新段落添加到 `TextFrame` 段落集合中。
10. 保存修改后的演示文稿。

以下 Java 代码演示如何添加和管理具有自定义编号或格式的段落：

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 访问已创建的 autoshape 的文本框
    ITextFrame textFrame = shape.getTextFrame();

    // 移除默认的现有段落
    textFrame.getParagraphs().removeAt(0);

    // 第一个列表
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("项目符号 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("项目符号 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("项目符号 7");
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

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过索引访问相关幻灯片的引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。
1. 向矩形 autoshape 添加一个具有三个段落的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)。
1. 隐藏矩形线条。
1. 通过其 BulletOffset 属性为每个 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) 设置缩进。
1. 将修改后的演示文稿写入 PPT 文件。

以下 Java 代码演示如何设置段落缩进：

```java
// 实例化 Presentation 类
Presentation pres = new Presentation();
try {
    // 获取第一张幻灯片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 添加一个矩形形状
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // 向矩形添加 TextFrame
    ITextFrame tf = rect.addTextFrame("这是第一行 \r这是第二行 \r这是第三行");
    
    // 设置文本以适应形状
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // 隐藏矩形的线条
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // 获取 TextFrame 中的第一个段落并设置其缩进
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // 设置段落项目符号样式和符号
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // 获取 TextFrame 中的第二个段落并设置其缩进
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // 获取 TextFrame 中的第三个段落并设置其缩进
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // 将演示文稿写入磁盘
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **设置段落的悬挂缩进**

以下 Java 代码演示如何为段落设置悬挂缩进：

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("示例");

    Paragraph para2 = new Paragraph();
    para2.setText("为段落设置悬挂缩进");

    Paragraph para3 = new Paragraph();
    para3.setText("此 C# 代码演示如何为段落设置悬挂缩进：");

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

## **管理段落的结束段落运行属性**

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
1. 通过位置获取包含段落的幻灯片的引用。
1. 向幻灯片添加一个矩形 [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。
1. 向矩形添加一个带有两个段落的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)。
1. 设置段落的 `FontHeight` 和字体类型。
1. 设置段落的结束属性。
1. 将修改后的演示文稿写入 PPTX 文件。

以下 Java 代码演示如何在 PowerPoint 中设置段落的结束属性：

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("示例文本"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("示例文本 2"));

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

Aspose.Slides 提供了增强的支持，将 HTML 文本导入段落。

1. 创建 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相关幻灯片的引用。
3. 向幻灯片添加一个 [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)。
4. 添加并访问 `autoshape` 的 [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/)。
5. 移除 `ITextFrame` 中的默认段落。
6. 使用 TextReader 读取源 HTML 文件。
7. 通过 [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) 类创建第一个段落实例。
8. 将读取的 TextReader 中的 HTML 文件内容添加到 TextFrame 的 [ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/) 中。
9. 保存修改后的演示文稿。

以下 Java 代码实现了将 HTML 文本导入段落的步骤：

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

    // 清除添加的文本框中的所有段落
    ashape.getTextFrame().getParagraphs().clear();

    // 使用流读取器加载 HTML 文件
    TextReader tr = new StreamReader("file.html");

    // 将 HTML 流读取器中的文本添加到文本框中
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // 保存演示文稿
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **导出段落文本到 HTML**

Aspose.Slides 提供了增强的支持，将文本（包含在段落中）导出到 HTML。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 通过索引访问相关幻灯片的引用。
3. 访问包含要导出到 HTML 的文本的形状。
4. 访问形状的 [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/)。
5. 创建 `StreamWriter` 实例并添加新的 HTML 文件。
6. 提供起始索引给 StreamWriter 并导出您需要的段落。

以下 Java 代码演示如何将 PowerPoint 段落文本导出到 HTML：

```java
// 加载演示文稿文件
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // 访问演示文稿的默认第一张幻灯片
    ISlide slide = pres.getSlides().get_Item(0);

    // 所需的索引
    int index = 0;

    // 访问添加的形状
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // 创建输出 HTML 文件
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // 提取第一个段落作为 HTML
    // 通过提供段落起始索引和要复制的总段落数，将段落数据写入 HTML
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```