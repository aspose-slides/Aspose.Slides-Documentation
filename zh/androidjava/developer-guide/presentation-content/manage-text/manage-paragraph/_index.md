---
title: 在 Android 上管理 PowerPoint 文本段落
linktitle: 管理段落
type: docs
weight: 40
url: /zh/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 创建和格式化段落、部分、项目符号、编号列表、缩进、HTML 内容以及段落图像。"
---
## **概述**

Aspose.Slides for Android via Java 将文本表示为文本框、段落和部分的层次结构：

* [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/) 表示形状中的文本容器，并提供对其段落集合的访问。
* [IParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/) 表示文本框中的一个段落，并提供对其部分和段落级格式的访问。
* [IPortion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/) 表示段落中的一段文字。每个部分可以拥有自己的文本和字符级格式。

因此，一个段落可以通过使用多个部分来包含不同字体、颜色、大小和其他格式的文本。

## **创建和格式化段落**

### **使用多个部分创建段落**

以下步骤创建一个包含三个段落、每个段落包含三个部分的文本框：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向幻灯片添加一个矩形的 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)。
5. 使用默认段落并向文本框再添加两个 [IParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/) 对象。
6. 为每个段落添加足够的 [IPortion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/) 对象，使其包含三个部分。默认段落已经包含一个空的部分。
7. 设置每个部分的文本。
8. 通过 [IPortion.getPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#getPortionFormat--) 应用字符级格式。
9. 保存修改后的演示文稿。

此 Android via Java 示例实现了上述步骤：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

项目符号和编号可以让相关项目更易于浏览。在 Aspose.Slides 中，列表设置通过 [IBulletFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/) 定义。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 向选定的幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)。
5. 从文本框中移除默认段落。
6. 为符号项目符号创建一个 [Paragraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/paragraph/)。
7. 将 [IBulletFormat.setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setType-int-) 设置为 [BulletType.Symbol](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/bullettype/) 并指定项目符号字符。
8. 设置段落文本、缩进、项目符号颜色和项目符号高度。
9. 将段落添加到文本框。
10. 创建第二个段落并将 [IBulletFormat.setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setType-int-) 设置为 [BulletType.Numbered](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/bullettype/)。
11. 配置编号项目符号样式并将段落添加到文本框。
12. 保存演示文稿。

此 Android via Java 示例创建了一个符号项目符号和一个编号项目符号：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 通过索引访问相应的幻灯片。
3. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/) 并访问其 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)。
4. 从文本框中移除默认段落。
5. 加载项目符号图像并将其作为 [IPPImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ippimage/) 添加到演示文稿的图像集合中。
6. 创建一个 [Paragraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/paragraph/) 并设置其文本。
7. 将 [IBulletFormat.setType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setType-int-) 设置为 [BulletType.Picture](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/bullettype/)。
8. 通过 [IBulletFormat.getPicture](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#getPicture--) 赋予图像并设置项目符号高度。
9. 将段落添加到文本框。
10. 保存修改后的演示文稿。

此 Android via Java 示例创建了一个图片项目符号：

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

将 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) 设置为不同的值，以将段落放在列表的不同层级。顶层的深度为 `0`。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 并访问一个幻灯片。
2. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/) 并清除其文本框中的默认段落。
3. 创建四个段落并配置它们的项目符号符号。
4. 将它们的 [IParagraphFormat.setDepth](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) 值分别设为 `0`、`1`、`2`、`3`。
5. 将段落添加到文本框并保存演示文稿。

此 Android via Java 示例创建了一个四级项目符号列表：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

使用 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 为编号段落设置初始显示的数字。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 并向幻灯片添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
2. 清除形状文本框中的默认段落。
3. 创建三个编号段落。
4. 对相应的段落将 [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) 设置为 `2`、`3` 和 `7`。
5. 将段落添加到文本框并保存演示文稿。

此 Android via Java 示例为每个段落分配了自定义起始编号：

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

## **控制段落布局和结束属性**

### **设置首行缩进**

使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 控制段落的首行缩进。此方法仅移动相对于段落左侧边距的首行。正值将首行向右移动，而其余行保持与段落正文对齐。

需要整体移动段落时请使用 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)。仅需移动首行时使用 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-)。

下面的示例创建了多个段落，并对它们应用不同的 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 值，以演示首行缩进对段落布局的影响。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/) 并移除默认段落。
5. 创建若干段落，并为它们设置不同的 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 值。
6. 将段落添加到文本框。
7. 保存修改后的演示文稿。

以下代码演示了如何设置段落缩进：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

效果如下：

![段落的首行缩进](first_line_indent.png)

### **设置悬挂缩进**

悬挂缩进是一种段落布局，其中首行位于其余行的左侧。在 Aspose.Slides 中，可通过 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 实现此效果。传入负值即可使首行相对于段落正文向左移动。

实际上，[IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 定义段落正文的左侧位置，而 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 定义首行相对于该左边距的位置。要实现悬挂缩进，可对 `setMarginLeft` 传入正值，对 `setIndent` 传入负值。

此格式常用于参考文献、书目、词汇表等需要使换行文本对齐到段落正文而非首字符的场景。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 访问目标幻灯片。
3. 向幻灯片添加一个矩形的 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
4. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/) 并移除默认段落。
5. 为每个段落调用 [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 并传入正值。
6. 对 [IParagraphFormat.setIndent](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) 传入负值，以实现悬挂缩进效果。
7. 将段落添加到文本框。
8. 保存修改后的演示文稿。

以下代码演示了如何为段落设置悬挂缩进：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

效果如下：

![段落的悬挂缩进](hanging_indent.png)

### **设置段落结束运行属性**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 控制段落结束标记的格式。下面的示例为第二段落的结束标记分配了字体大小和拉丁字体：

1. 加载一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 并访问一个幻灯片。
2. 添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/) 并清除其默认段落。
3. 创建两个段落并向其中添加文本部分。
4. 为第二段落的结束标记创建一个 [PortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/portionformat/)。
5. 设置 [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) 和 [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-)。
6. 使用 [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) 将格式应用到段落，并保存演示文稿。

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

## **导入和导出段落内容**

### **将 HTML 文本导入段落**

使用 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) 将 HTML 标记转换为文本框中的段落和部分。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 访问一个幻灯片并添加一个 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
3. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/) 并清除默认段落。
4. 读取源 HTML 文件。
5. 将 HTML 字符串传递给 [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)。
6. 保存修改后的演示文稿。

此 Android via Java 示例将 HTML 导入到文本框中：

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

使用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) 将选定范围的段落导出为 HTML。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例并加载所需的演示文稿。
2. 访问幻灯片并找到包含文本的 [IAutoShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iautoshape/)。
3. 访问形状的 [ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)。
4. 调用 [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)，传入起始段落索引和要导出的段落数。
5. 将返回的 HTML 字符串写入文件。

此 Android via Java 示例导出第一个文本形状的所有段落：

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

[IParagraph.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/#getImage--) 直接渲染单个段落并返回一个 [IImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/)。使用 [IImage.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 将结果保存到文件或流。无需渲染包含的形状或手动裁剪位图。

如果段落在其父集合中未找到、没有有效的渲染边界或无法渲染，[IParagraph.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/#getImage--) 可能返回 `null`。在保存之前检查返回结果，并在使用后释放图像。

#### **以默认比例渲染段落**

假设我们有一个名为 sample.pptx 的演示文稿，包含一张幻灯片，其中第一个形状是包含三个段落的文本框。

![包含三个段落的文本框](paragraph_to_image_input.png)

以下示例在默认比例下渲染第二个段落，并以 PNG 格式保存返回的图像。`finally` 块确保正确释放图像。

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

结果如下：

![段落图像](paragraph_to_image_output.png)

#### **在表格单元格中渲染段落并进行缩放**

使用接受 `float scaleX` 和 `float scaleY` 参数的 [IParagraph.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) 重载来设置水平和垂直缩放比例。下面的示例创建一个表格，在其第一个单元格中以两倍默认宽高渲染段落，并将结果保存为 PNG 图像。

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

缩放因子为 `1` 时保持该轴的默认像素尺寸。例如，两个因子均为 `2` 时，生成的图像宽高约为默认尺寸的两倍，像素数约为原来的四倍。更大的因子通常能在放大或高分辨率输出时获得更清晰的文本，但也会增加内存使用和文件大小。因子小于 `1` 会产生更小、细节更少的图像。使用相等的因子可保持段落的宽高比；不同的水平和垂直因子会独立拉伸输出。

在需要包含形状填充、边框或其他视觉上下文时，仍然可以使用 [IShape.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/#getImage--) 渲染整个形状。若仅需段落图像，请使用 [IParagraph.getImage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/#getImage--)。

## **常见问题**

**可以完全禁用文本框内的自动换行吗？**

可以。将 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) 设置为关闭换行，使行在文本框边缘处不换行。

**如何获取特定段落在幻灯片上的精确边界？**

使用 [IParagraph.getRect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/#getRect--) 获取段落的包围矩形。 [IPortion.getRect](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#getRect--) 提供单个部分的边界。

**段落对齐（左、右、居中或两端对齐）在哪里控制？**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) 是段落级设置，适用于整个段落，而不受各部分格式的影响。

**可以为段落的部分设置校对语言吗？**

可以。对各部分使用 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，这样同一段落中可以包含多种语言的文本。