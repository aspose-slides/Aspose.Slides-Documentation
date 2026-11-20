---
title: 在 Java 中格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/java/text-formatting/
keywords:
- 对齐段落
- 文本样式
- 文本背景
- 文本透明度
- 字符间距
- 字体属性
- 字体族
- 文本旋转
- 旋转角度
- 文本框
- 行间距
- 自动适应属性
- 文本框锚点
- 文本制表
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化和样式设置。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。内容涵盖背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位和语言设置。

除非另有说明，示例使用 [sample.pptx](sample.pptx)。第一张幻灯片的第一个形状是一个文本框，第一段包含如下文本。幻灯片和形状的索引均为从零开始。选择粗体部分的示例使用有效格式，包括继承的粗体格式：

![示例文本](sample_text.png)

要查找并突出显示文字字面量或正则表达式匹配，请参阅 [搜索和替换文本](/slides/zh/java/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 为段落设置默认的高亮颜色，或使用 [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) 为单独的文本部分设置高亮颜色。

以下示例为第一段设置浅灰色高亮作为默认。对单独部分的显式高亮颜色优先于此默认值：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 为整个段落设置高亮颜色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **粗体字体的文本部分** 设置背景颜色：

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 为文本部分设置高亮颜色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![灰色文本部分](gray_text_portions.png)

## **对齐文本段落**

使用 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 在文本框内设置段落对齐方式。可以是居中、左对齐、右对齐、两端对齐等。

以下代码示例展示如何将段落对齐到 **居中**：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 将段落的对齐方式设置为居中。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![对齐的段落](aligned_paragraph.png)

## **对齐行内字体**

使用 [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) 垂直对齐同一行中不同字号的文本部分。该设置适用于整个段落，并控制每行内部的对齐方式。

以下独立示例在同一张幻灯片上创建四个带标签的文本框。每个段落分别使用 18、36、54 点的相同文本，且字体对齐方式不同。示例使用 Arial，禁用自动适应和换行，并保持文本框足够宽以容纳单行。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![基线、顶部、居中和底部字体对齐的比较（混合字体大小）](font_alignment.png)

字体对齐使用字体度量，因此各字母的可见边缘不一定完全对齐。示例同时包含大写字母和下划线字符，以帮助展示基线与底部对齐的差异。字体可用性、字符选择以及字号差异都会影响结果。框架尺寸、边距、行距、换行和自动适应也会影响布局；比较模式时请使用相同的字体和布局设置。

此设置不同于 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-)，后者控制水平段落对齐；也不同于 [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-)，后者在形状内部垂直定位文本块。通过 [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) 实现的上标和下标格式会相对于基线移动单个部分，而不是为段落行设置字体对齐。

## **设置文本透明度**

文本透明度通过分配给 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) 的颜色的 alpha 分量来控制。下面示例中，`alpha = 50` 是 0–255 范围的 ARGB alpha 通道值，而非透明度百分比。

下面的代码示例展示如何对 **整个段落** 应用透明度：

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 将文本的填充颜色设置为透明颜色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![透明段落](transparent_paragraph.png)

以下代码示例展示如何对 **粗体字体的文本部分** 应用透明度：

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 为文本部分设置透明度。
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![透明文本部分](transparent_text_portions.png)

## **设置字符间距**

使用 [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) 可以在文本框中扩大或压缩字符间距。示例在字符之间添加 3 点间距；负值会压缩文本。

以下 Java 代码展示如何在 **整个段落** 中扩展字符间距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意: 使用负值来压缩字符间距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 扩展字符间距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示如何在 **粗体字体的文本部分** 中扩展字符间距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注意: 使用负值来压缩字符间距。
            portion.getPortionFormat().setSpacing(3); // 扩展字符间距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![文本部分的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中显示的略紧。这可能是因为 PowerPoint 对某些字体会忽略字距信息，即使字体本身包含有效的字距数据且 PowerPoint 设置中已启用字距。

若要使渲染结果更接近 PowerPoint，可为使用受影响字体的文本部分禁用字距。将 [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) 设置为大于实际字号的值。本示例需要 “presentation.pptx”，其第一张幻灯片的第一个形状是文本框。示例检查有效字体名称（包括继承的字体），并对使用 Roboto 且字号低于 100 点的部分设置阈值，从而禁用这些部分的字距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

对于低于阈值的匹配文本，此设置会阻止字距调整，从而帮助 Aspose.Slides 的渲染效果与 PowerPoint 在受此行为影响的字体上的视觉输出保持一致。

## **管理文本字体属性**

可以通过 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 在段落层面设置字体属性，也可以通过 [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) 对单独的文本部分设置。

以下示例将第一段的默认字体设置为 12 点 Times New Roman，且加粗、斜体、点划下划线。对单独部分的显式格式优先于这些默认值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 设置段落的字体属性。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![段落的字体属性](font_properties_for_paragraph.png)

以下示例对有效格式为粗体的文本部分应用 13 点 Times New Roman、斜体以及点划下划线：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 为文本部分设置字体属性。
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![文本部分的字体属性](font_properties_for_text_portions.png)

## **控制文本高度标准化**

在复现模板排版或研究字符高度差异时，可使用 [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-)。在 PowerPoint 中，启用标准化会在垂直方向拉伸或压缩单个字符，使其在文本部分内具有统一的可见高度。它并不能保证不同字体之间的文本高度相等。

将属性设置为 [NullableBool.True 或 False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) 可显式开启或关闭标准化。`NullableBool.NotDefined` 表示本地设置未定义，部分将从段落的 [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 等继承，而不是等同于 `False`。使用 [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) 并读取 [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) 可获得解析后的布尔值。

以下独立示例需要安装 **Arial**。它创建两个包含相同大写字母、小写字母、下划线以及重音字符的文本块，字号为 54 点。两个段落默认启用标准化。上部文本显式关闭；下部文本继承段落设置。框架尺寸、边距和段落间距相同，且禁用换行和自动适应，以保持比较一致。示例输出 `False: false` 和 `NotDefined: true`，并保存为 “text_height_normalization.pptx”。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

下面的比较图源自已保存的演示文稿。上排禁用标准化 (`False`)；下排继承已启用的设置 (`NotDefined` → `True`)。请保持安装 Arial 以复现此外观。

![Arial 54 点文本（上方禁用标准化，下方继承并启用标准化）](text_height_normalization.png)

标准化会在不改变分配给 [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) 值的情况下改变字符高度——该值指定字体的点数大小。段落 [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) 控制行距，而文本框 [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 控制文本或其容器如何自动适应。这些设置各自承担不同职责，可独立影响整体布局。更多段落格式和继承信息，请参见 [管理段落](/slides/zh/java/manage-paragraph/)。

## **应用和移除删除线**

对文本部分使用 [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) 可显示更正、取消的词语或先前的价格，而无需删除原始文本。可将其设置为 [TextStrikethroughType.Single 或 Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) 以呈现单线或双线删除线。

要移除删除线，请传入 [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None)。这会显式禁用该效果，即使周围的格式指定了删除线。相比之下，[TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) 保持本地设置未定义，允许部分从段落等继承格式，但不保证删除线被移除。使用 [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) 可读取最终的格式，包括继承值。

以下独立示例创建三个价格对比。每个段落分别包含标签、原价和现价的文本部分，仅原价受删除线影响。第一行先应用后移除删除线；其余行保留单线和双线删除线。修改此设置可保留文本及其其他格式，包括加粗的原价。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // 应用删除线，然后显式移除第一个原价的删除线。
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果（从上到下）：无删除线、单删除线、双删除线。

![无删除线、单删除线和双删除线的前价对比](strikethrough.png)

## **设置文本旋转**

使用 [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) 可在形状内部设置预定义的文本方向。

以下代码示例将形状内的文本方向设置为 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/)，这会使文本 **逆时针旋转 90 度**：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

使用 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 可为 [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) 设置自定义旋转角度。

下面的代码示例在形状内部将文本框顺时针旋转 3 度：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行距**

Aspose.Slides 提供 [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) 和 [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) 来控制段落间距。使用方式如下：

* 使用正值可将行距指定为行高的百分比。
* 使用负值可将行距指定为点数。

以下示例将第一段内部的行距设置为行高的 200%（双倍行距）：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![段落内部的行距](line_spacing.png)

## **控制换行**

段落换行规则在窄文本块以及混合拉丁文和东亚文字的演示文稿中非常有用。以下方法属于 [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/)，因此适用于整个段落：

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) 控制拉丁文换行规则。在混合文本中，修改它也可能影响相邻东亚文字和标点的换行位置。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) 控制东亚换行规则，包括对行首和行尾字符的限制。

这些规则不替代 [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-)，后者启用文本框内的自动换行。换行规则在换行发生时影响布局，但不会插入换行字符。显式换行会强制在段落内部另起一行，独立于可用宽度。

以下独立示例创建一个包含中文和拉丁文的窄文本块。示例显式设置两项换行选项，并保存为 “line_breaking.pptx”。如需实验任意规则，只需在保持另一设置不变的情况下更改对应的值。示例使用 24 点 Arial 与 SimSun，框宽为 160 点，水平文本框边距为 0。调用 [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 并传入 [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/)，以保持文本大小和框尺寸固定。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **控制悬挂标点**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) 允许符合条件的标点超出文本行的右边缘，而不是占据下一行。它适用于整个段落，并不同于悬挂缩进。

以下独立示例在宽度为 100 点的文本框中启用悬挂标点，并保存为 “hanging_punctuation.pptx”。使用 24 点 Arial 且水平文本框边距为 0，最终的句号会停留在 “sentence” 后面并超出文本右边缘。将属性设置为 [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) 可进行对比：此时句号会占据单独一行。为保持可用宽度固定，示例启用换行并禁用自动适应。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

并非所有标点都能悬挂。上述 [字体和布局条件](#control-line-breaking) 同样适用于此对比：更改字体、可用宽度、边距或自动适应设置都可能消除可见差异。

## **设置文本框的自动适应类型**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 决定文本超出容器边界时的行为。使用它可控制文本是缩小、溢出还是自动调整形状大小。以下示例将形状配置为随文本自动调整大小，并将结果保存为 “autofit_type.pptx”。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

要在自动换行后统计行数并查看文本或形状宽度的变化，请参阅 [统计渲染行数](/slides/zh/java/manage-paragraph/)。仅行数并不能指示文本是否溢出容器。

## **设置文本框锚点**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) 定义文本在形状内部的垂直定位方式，例如顶部、居中或底部。以下示例将文本锚定到第一形状的底部，并将结果保存为 “text_anchor.pptx”。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **设置文本制表位**

使用 [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) 和 [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) 可在段落中配置制表位。以下示例将默认制表间隔设为 100 点，并在 30 点处添加左对齐制表位。这些设置会影响包含制表符的文本。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，可为文本部分设置校对语言。校对语言决定 PowerPoint 中的拼写和语法检查使用的语言。

以下示例需要 “presentation.pptx”，其第一张幻灯片的第一个形状是文本框，并且至少有一个段落。示例将第一段内容替换为 “1。”，将字体设为 SimSun，并将校对语言设为简体中文 (`zh-CN`)。保存结果为 “proofing_language.pptx”：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // 设置校对语言的 Id。
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **复制语言元数据**

在从模板复制多语言文本时，需要同时保留 [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) 和 [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--)。以下独立示例创建一个源文本部分，其语言为美式英语，备选语言为法语，并将文本和标识符复制到新演示文稿中的一个文本部分。

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // 如果源没有备选语言，null 将清除目标值。
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果想尝试没有备选语言的源，只需省略对 `"fr-FR"` 的赋值。此时备选标识符为 `null`，相同的复制语句会保留其缺失，而不会引入默认值，即使目标先前已分配了备选语言。

这些标识符存储语言元数据。保留它们并不决定 PowerPoint 为拼写或语法检查选择哪种字典。

## **设置默认语言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 可定义在加载或创建演示文稿时创建的文本的默认语言。以下示例创建一个默认语言为美式英语的演示文稿，添加一个文本框，并打印其第一文本部分的 `en-US`。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个带文本的矩形形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 检查第一段落的语言。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)。

以下示例将新演示文稿中顶层段落的默认字体设置为 14 点加粗，并将其保存为 “default_text_style.pptx”。文本可以继承这些默认值，除非更具体的格式覆盖它们。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // 获取顶级段落格式。
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **提取全大写效果的文本**

在 PowerPoint 中，应用 **全大写** 字体效果会使文本在幻灯片上显示为大写，即使原始输入为小写。当使用 Aspose.Slides 检索此类文本部分时，库会返回实际输入的文本。若要匹配显示的文本，需要检查 [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) 并在其值为 `All` 时将返回的字符串转换为大写。

本示例需要 “sample2.pptx”，其第一张幻灯片的第一个形状是文本框。其第一段的第一部分包含 “Hello, Aspose!” 并应用了全大写效果，如下所示。

![全大写效果](all_caps_effect.png)

下面的代码示例展示如何提取已应用 **全大写** 效果的文本：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

输出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常见问题**

**如何在幻灯片上的表格中修改文本？**

要在幻灯片上的表格中修改文本，请使用 [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/)。遍历单元格，并通过 [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) 更新每个单元格的文本框，并通过 [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) 更新段落格式。

**如何在 PowerPoint 幻灯片的文本上应用渐变颜色？**

要为文本应用渐变颜色，请使用 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)。将 [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) 设置为 [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)，并配置渐变停止点、方向和透明度。

Related feature: [在幻灯片中格式化文本](/slides/zh/features/text-formatting/).