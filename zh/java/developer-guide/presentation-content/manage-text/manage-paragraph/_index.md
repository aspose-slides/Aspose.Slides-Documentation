---
title: 在 Java 中管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
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
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 创建和格式化段落、片段、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for Java 将文本表示为文本框、段落和片段的层次结构：

* [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [IParagraph](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/) 表示文本框中的一个段落，并提供对其片段和段落级格式的访问。
* [IPortion](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportion/) 表示段落内的一个文本运行。每个片段可以拥有独立的文本和字符级格式。

因此，一个段落可以通过使用多个片段来包含不同字体、颜色、大小和其他格式的文本。

## **创建和格式化段落**

### **创建具有多个片段的段落**

以下步骤创建一个包含三个段落、每个段落包含三个片段的文本框：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向幻灯片添加一个矩形的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)。
5. 使用默认段落并向文本框再添加两个 [IParagraph](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/) 对象。
6. 为每个段落添加足够的 [IPortion](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportion/) 对象，以使其包含三个片段。默认段落已经包含一个空片段。
7. 设置每个片段的文本。
8. 通过 [IPortion.getPortionFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportion/#getPortionFormat--) 应用字符级格式。
9. 保存修改后的演示文稿。

下面的 Java 示例实现了这些步骤：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **创建项目符号和编号列表**

### **创建项目符号或编号列表**

项目符号和编号可以让相关项更易于浏览。在 Aspose.Slides 中，列表设置通过 [IBulletFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibulletformat/) 定义。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向选定的幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)。
5. 从文本框中移除默认段落。
6. 为符号项目符号创建一个 [Paragraph](https://reference.aspose.com/slides/zh/java/com.aspose.slides/paragraph/)。
7. 将 [IBulletFormat.setType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibulletformat/#setType-int-) 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/zh/java/com.aspose.slides/bullettype/)，并指定项目符号字符。
8. 设置段落文本、缩进、项目符号颜色和项目符号高度。
9. 将段落添加到文本框。
10. 创建第二个段落并将 [IBulletFormat.setType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibulletformat/#setType-int-) 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/zh/java/com.aspose.slides/bullettype/)。
11. 配置编号项目符号样式并将段落添加到文本框。
12. 保存演示文稿。

下面的 Java 示例创建了符号项目符号和编号项目符号：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **使用图片项目符号**

图片项目符号允许使用自定义图像代替符号或数字。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 并访问其 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)。
4. 从文本框中移除默认段落。
5. 加载项目符号图像并将其作为 [IPPImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ippimage/) 添加到演示文稿的图像集合中。
6. 创建一个 [Paragraph](https://reference.aspose.com/slides/zh/java/com.aspose.slides/paragraph/) 并设置其文本。
7. 将 [IBulletFormat.setType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibulletformat/#setType-int-) 设置为 [BulletType.Picture](https://reference.aspose.com/slides/zh/java/com.aspose.slides/bullettype/)。
8. 通过 [IBulletFormat.getPicture](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibulletformat/#getPicture--) 指定图像并设置项目符号高度。
9. 将段落添加到文本框。
10. 保存修改后的演示文稿。

下面的 Java 示例创建了图片项目符号：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **创建多级列表**

将 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 设置为不同的深度，以将段落放置在列表的不同层级。顶层深度为 `0`。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 并访问幻灯片。
2. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 并清除其文本框中的默认段落。
3. 创建四个段落并配置它们的项目符号符号。
4. 将它们的 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setDepth-short-) 值分别设为 `0`、`1`、`2`、`3`。
5. 将段落添加到文本框并保存演示文稿。

下面的 Java 示例创建了四层项目符号列表：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **为编号列表项设置自定义起始值**

使用 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 为编号段落设置起始数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 并向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
2. 清除形状文本框中的默认段落。
3. 创建三个编号段落。
4. 将 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 分别设置为 `2`、`3`、`7`。
5. 将段落添加到文本框并保存演示文稿。

下面的 Java 示例为每个段落分配了自定义起始编号：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制段落布局和结尾属性**

### **设置首行缩进**

使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 控制段落的首行缩进。该方法仅移动第一行相对于段落左边距的位置。正值将首行向右移动，剩余行保持与段落正文对齐。

当需要移动整个段落时使用 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。仅需移动首行时使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setIndent-float-)。

下面的示例创建了若干段落，并对不同的 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 值进行演示，以展示首行缩进如何影响段落布局。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/) 并移除默认段落。
5. 创建若干段落，并为它们设置不同的 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 值。
6. 将段落添加到文本框。
7. 保存修改后的演示文稿。

下面的代码演示了如何设置段落缩进：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![段落的首行缩进](first_line_indent.png)

### **设置悬挂缩进**

悬挂缩进是一种段落布局，首行位于其余行的左侧。在 Aspose.Slides 中，可通过 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 实现。传入负值即可使首行相对于段落正文向左移动。

实际操作中，[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 定义段落正文的左侧位置，而 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 定义首行相对于该左侧的位置。要创建悬挂缩进，需对 `setMarginLeft` 传入正值，对 `setIndent` 传入负值。

此格式常用于参考文献、书目、词汇表条目等，需要换行内容对齐在段落正文左边而非首行第一个字符下方的情形。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/) 并移除默认段落。
5. 为每个段落创建段落并对 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 传入正值。
6. 对 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setIndent-float-) 传入负值以实现悬挂缩进效果。
7. 将段落添加到文本框。
8. 保存修改后的演示文稿。

下面的代码演示了如何为段落设置悬挂缩进：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![段落的悬挂缩进](hanging_indent.png)

### **设置段落结束运行属性**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 控制段落结束标记的格式。下面的示例为第二段落的结束标记分配了字体大小和拉丁字体：

1. 加载一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 并访问幻灯片。
2. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/) 并清除其默认段落。
3. 创建两个段落并向其中添加文本片段。
4. 为第二段落的结束标记创建一个 [PortionFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/portionformat/)。
5. 设置 [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 和 [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-)。
6. 使用 [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 赋予格式并保存演示文稿。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **统计渲染行数**

使用 [IParagraph.getLinesCount](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/#getLinesCount--) 可统计段落在文本布局后占用的行数（包括自动换行）。这在检查演示模板中的文本长度和布局时非常有用。

段落是 [ITextFrame.getParagraphs](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/#getParagraphs--) 中的一个项目，可能占用多行渲染。段落内部的显式换行会强制产生新行，而不会创建新段落。自动换行根据可用宽度生成行，而不会在文本中插入显式换行符。因此，仅统计段落数量或换行字符并不能得到渲染行数。

下面的示例创建一个文本形状，统计其行数，随后缩窄形状并用更短的字符串替换文本。示例启用了换行并禁用了自动适配，以便形状宽度控制换行，而不会自动缩小文字或调整形状大小。形状尺寸使用点（pt）为单位。最后，示例再添加一个段落并对文本框内的行数求和。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

在此文本和这些尺寸下，缩窄形状会增加行数，而用短字符串替换文本会减少行数。具体计数会随字体可用性、替代、字体大小、边距、缩进、换行和自动适配设置而变化。检查模板时请使用目标环境的字体和布局设置。

仅凭行数并不能判断文本是否溢出容器。可用高度、行高、段落和行间距以及自动适配行为同样重要；即使是一行文本，在关闭换行时也可能超过可用宽度。

## **导入和导出段落内容**

### **将 HTML 文本导入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 将 HTML 标记转换为文本框中的段落和片段。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。
2. 访问幻灯片并添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
3. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/) 并清除默认段落。
4. 读取源 HTML 文件。
5. 将 HTML 字符串传递给 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)。
6. 保存修改后的演示文稿。

下面的 Java 示例将 HTML 导入文本框：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **将段落文本导出为 HTML**

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 将选定范围的段落导出为 HTML。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 访问幻灯片并找到包含文本的 [IAutoShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iautoshape/)。
3. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/)。
4. 调用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) ，传入起始段落索引和要导出的段落数量。
5. 将返回的 HTML 字符串写入文件。

下面的 Java 示例导出第一个文本形状中的所有段落：

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **将段落渲染为图像**

[IParagraph.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/#getImage--) 可直接渲染单个段落并返回 [IImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/)。使用 [IImage.save](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 将结果保存到文件或流中，无需渲染整个形状或手动裁剪位图。

如果段落在其父集合中未找到、没有有效的渲染边界，或无法渲染， [IParagraph.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/#getImage--) 可能返回 `null`。在保存之前请检查返回值，并在使用后释放图像。

#### **在默认比例下渲染段落**

假设我们有一个名为 sample.pptx 的演示文件，里面只有一张幻灯片，第一形状是一个包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

下面的示例在默认比例下渲染第二段落，并以 PNG 格式保存返回的图像。`finally` 块确保正确释放图像。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

结果：

![段落图像](paragraph_to_image_output.png)

#### **在表格单元格中渲染段落并进行缩放**

使用接受 `float scaleX` 和 `float scaleY` 参数的 [IParagraph.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/#getImage-float-float-) 重载，可设置水平和垂直缩放因子。下面的示例创建一个表格，在其第一个单元格中以两倍默认宽高渲染段落，并将结果保存为 PNG 图像。

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

缩放因子为 `1` 时保持该轴的默认像素大小。例如，两个因子均为 `2` 时，生成的图像宽高约为默认尺寸的两倍，像素数量约为四倍。更大的因子通常可在放大或高分辨率输出时获得更清晰的文字，但也会增加内存使用和文件大小。因子小于 `1` 会生成更小且细节较少的图像。使用相同的因子可保持段落的宽高比例；不同的水平和垂直因子会独立拉伸输出。

在需要包含形状填充、边框或其他视觉上下文时，使用 [IShape.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/#getImage--) 渲染整个形状仍然有用。仅需段落图像时，请使用 [IParagraph.getImage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/#getImage--)。

## **常见问题**

**我可以完全禁用文本框内的换行吗？**

可以。将 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) 设置为禁用换行，行将不会在文本框边缘断开。

**如何获取特定段落在幻灯片上的精确边界？**

使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/#getRect--) 获取段落的边界矩形。 [IPortion.getRect](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportion/#getRect--) 则提供单个片段的边界。

**段落对齐（左、右、居中或两端对齐）在哪里控制？**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 是段落级设置，适用于整个段落，无论各片段的格式如何。

**我可以为段落的部分内容设置校对语言吗？**

可以。对各片段使用 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，这样一个段落可以包含多种语言的文本。