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
- 字体系列
- 文本旋转
- 旋转角度
- 文本框
- 行距
- 自动适应属性
- 文本框锚点
- 文本制表
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 演示文稿中格式化和设置文本样式。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 演示文稿中格式化文本。它涵盖了背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位和语言设置。

在下面的示例中，我们将使用名为 “sample.pptx” 的文件，该文件在第一页包含一个包含以下文本的单个文本框：

![示例文本](sample_text.png)

要查找并突出显示文字字面量或正则表达式匹配，请参阅[搜索和替换文本](/slides/zh/java/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 为段落设置默认高亮颜色，或使用 [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) 为单独的文本片段设置。

以下代码示例展示了如何为 **整个段落** 设置背景颜色：

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

下面的代码示例演示了如何为 **加粗字体的文本片段** 设置背景颜色：

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
            // 为文本片段设置高亮颜色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用 [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) 在文本框内设置段落对齐方式。该值可以是居中、左对齐、右对齐、两端对齐等。

以下代码示例展示了如何将段落对齐到 **居中**：

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

![已对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) 的颜色的 alpha 分量来控制。在下面的示例中，`alpha = 50` 是 0–255 规模上的 ARGB alpha 通道值，而不是透明度百分比。

以下代码示例展示了如何对 **整个段落** 应用透明度：

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

以下代码示例展示了如何对 **加粗字体的文本片段** 应用透明度：

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
            // 设置文本片段的透明度。
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

![透明文本片段](transparent_text_portions.png)

## **设置文本字符间距**

使用 [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) 可扩大或压缩文本框中字符之间的间距。

以下 Java 代码展示了如何在 **整个段落** 中扩大字符间距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意：使用负值来压缩字符间距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 展开字符间距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示了如何在 **加粗字体的文本片段** 中扩大字符间距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 注意：使用负值来压缩字符间距。
            portion.getPortionFormat().setSpacing(3); // 展开字符间距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **禁用特定字体的字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中显示的相同文本略显紧凑。这可能是因为 PowerPoint 在某些字体上会忽略字距调整数据，即使该字体包含有效的字距信息且在 PowerPoint 设置中已启用字距调整。

在此类情况下，为了使渲染输出更接近 PowerPoint，您可以禁用使用受影响字体的文本片段的字距调整。将 [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) 设置为明显大于实际字体大小的值：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

此设置可防止对匹配的文本片段应用字距调整，并有助于使 Aspose.Slides 的渲染在受此 PowerPoint 特定行为影响的字体上与 PowerPoint 的视觉输出保持一致。

## **管理文本字体属性**

可以通过 [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) 在段落级别设置字体属性，或通过 [IPortionFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iportionformat/) 在单个片段上设置。

以下代码为整个段落设置字体和文本样式：它对段落中的所有片段应用字号、粗体、斜体、点线下划线以及 Times New Roman 字体。

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

下面的代码示例对 **加粗字体的文本片段** 应用类似的属性：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 设置文本片段的字体属性。
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

![文本片段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用 [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) 在形状内设置预定义的文本方向。

以下代码示例将形状中的文本方向设置为 `Vertical270`，这会将文本 **逆时针旋转 90 度**：

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

使用 [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 为 [ITextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframe/) 设置自定义旋转角度。

下面的代码示例在形状内将文本框顺时针旋转 3 度：

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

Aspose.Slides 提供了 [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) 和 [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) 来控制段落间距。这些属性的使用方式如下：

* 使用正值将行距指定为行高的百分比。
* 使用负值将行距指定为点数。

以下代码示例展示了如何在段落内指定行距：

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

![段落内的行距](line_spacing.png)

## **设置文本框的自动适应类型**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) 确定文本在超出容器边界时的行为。使用它可以控制文本是缩小、溢出还是自动调整形状大小。

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

要统计自动换行后的行数并查看文本或形状宽度变化对结果的影响，请参阅[统计渲染的行数](/slides/zh/java/manage-paragraph/)。仅凭行数并不能判断文本是否溢出其容器。

## **设置文本框的锚点**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) 定义文本在形状内部的垂直定位方式，例如顶部、居中或底部。

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

## **设置文本制表**

使用 [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) 和 [IParagraphFormat.getTabs](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraphformat/#getTabs--) 配置段落中的制表位。

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

Aspose.Slides 提供了 [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，允许您为文本片段设置校对语言。校对语言决定在 PowerPoint 中进行拼写和语法检查时使用的语言。

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

## **设置默认语言**

使用 [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) 定义在加载或创建演示文稿时创建的文本的默认语言。

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // 添加一个带有文本的新矩形形状。
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // 检查第一个片段的语言。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--)。

以下代码示例展示了如何为新演示文稿中所有幻灯片的所有文本设置 14 磅、粗体的默认字体：

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

## **提取全部大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使幻灯片上的文本显示为大写，即使原始输入为小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。为匹配显示的文本，请检查 [TextCapType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/textcaptype/) 并在其值为 `All` 时将返回的字符串转换为大写。

假设我们在 sample2.pptx 文件的第一页有如下文本框。

以下代码示例展示了如何提取带有 **All Caps** 效果的文本：

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

## **FAQ**

**如何在幻灯片的表格中修改文本？**

要在幻灯片的表格中修改文本，使用 [ITable](https://reference.aspose.com/slides/zh/java/com.aspose.slides/itable/)。遍历单元格，并通过 [ICell.getTextFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icell/#getTextFrame--) 更新每个单元格，通过 [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/iparagraph/#getParagraphFormat--) 更新段落格式。

**如何在 PowerPoint 幻灯片中的文本上应用渐变颜色？**

要对文本应用渐变颜色，使用 [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)。将 [IFillFormat.setFillType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ifillformat/#setFillType-byte-) 设置为 [FillType.Gradient](https://reference.aspose.com/slides/zh/java/com.aspose.slides/filltype/)，并配置渐变止点、方向和透明度。