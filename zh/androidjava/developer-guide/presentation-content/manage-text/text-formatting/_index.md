---
title: 在 Android 上格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/androidjava/text-formatting/
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
- 行间距
- 自动适应属性
- 文本框锚点
- 文本制表位
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化和样式设置。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for Android via Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。内容包括背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位和语言设置。

在下面的示例中，我们使用名为 **sample.pptx** 的文件，该文件的第一页包含一个文本框，文本内容如下：

![Sample text](sample_text.png)

要查找并突出显示文字字面值或正则表达式匹配，请参阅[Search and Replace Text](/slides/zh/androidjava/search-and-replace-text/)。

## **设置文本背景颜色**

使用[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)为段落设置默认高亮颜色，或使用[IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--)为单独的文本片段设置。

下面的代码示例展示了如何为**整段文本**设置背景颜色：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 为整个段落设置高亮颜色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The gray paragraph](gray_paragraph.png)

下面的代码示例演示了如何为**加粗字体的文本片段**设置背景颜色：

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // 为文本片段设置高亮颜色。
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The gray text portions](gray_text_portions.png)

## **对齐文本段落**

使用[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-)设置文本框内段落的对齐方式。可选值包括居中、左对齐、右对齐、两端对齐等。

下面的代码示例展示了如何将段落**居中**对齐：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 将段落的对齐方式设为居中。
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The aligned paragraph](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过为[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--)分配的颜色的 alpha 分量来控制。下例中 `alpha = 50` 是 0–255 规模的 ARGB alpha 通道值，而不是透明度百分比。

下面的代码示例展示了如何为**整段文本**应用透明度：

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 将文本的填充颜色设置为透明颜色。
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The transparent paragraph](transparent_paragraph.png)

下面的代码示例展示了如何为**加粗字体的文本片段**应用透明度：

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The transparent text portions](transparent_text_portions.png)

## **设置文本字符间距**

使用[IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-)可在文本框中扩展或收紧字符之间的间距。

下面的 Java 代码展示了如何在**整段文本**中扩展字符间距：

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // 注意：使用负值来压缩字符间距。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // 扩展字符间距。

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

下面的代码示例展示了如何在**加粗字体的文本片段**中扩展字符间距：

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
            portion.getPortionFormat().setSpacing(3); // 扩展字符间距。
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

结果：

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **禁用特定字体的字距调整**

在某些情况下，Aspose.Slides 渲染的文本看起来比 PowerPoint 中的相同文本稍微紧凑。这可能是因为 PowerPoint 在某些字体上会忽略字距调整数据，即使该字体包含有效的字距信息且在 PowerPoint 设置中已启用字距调整。

为使渲染结果更接近 PowerPoint，您可以对使用受影响字体的文本片段禁用字距调整。将[IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-)设置为明显大于实际字体大小的值：

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

此设置可防止对匹配的文本片段应用字距调整，从而帮助 Aspose.Slides 的渲染效果与 PowerPoint 对受影响字体的视觉输出保持一致。

## **管理文本字体属性**

可以通过[IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)在段落级别设置字体属性，或通过[IPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportionformat/)在单独的片段上设置。

下面的代码为整段文本设置字体和文本样式：它为段落中的所有片段应用字体大小、粗体、斜体、点状下划线以及 Times New Roman 字体。

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

![The font properties for the paragraph](font_properties_for_paragraph.png)

下面的代码示例为**加粗字体的文本片段**应用类似的属性：

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

![The font properties for text portions](font_properties_for_text_portions.png)

## **设置文本旋转**

使用[ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-)可在形状内设置预定义的文本方向。

下面的代码示例将形状中文本的方向设置为[TextVerticalType.Vertical270](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textverticaltype/)，这会使文本**逆时针旋转 90 度**：

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

![The text rotation](text_rotation.png)

## **为文本框设置自定义旋转**

使用[ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-)可为[ITextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframe/)设置自定义旋转角度。

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

![The custom text rotation](custom_text_rotation.png)

## **设置段落行间距**

Aspose.Slides 提供[IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-)、[IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-)和[IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-)来控制段落间距。这些属性的使用规则如下：

* 使用正值可将行间距指定为行高的百分比。
* 使用负值可将行间距指定为磅值。

下面的代码示例展示了如何在段落内部指定行间距：

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

![The line spacing within the paragraph](line_spacing.png)

## **设置文本框的自动适应类型**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-)决定当文本超出容器边界时的行为。可用来控制文本是缩小、溢出还是自动调整形状大小。

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

## **设置文本框的锚点**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-)定义文本在形状内部的垂直定位方式，例如顶部、居中或底部。

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

使用[IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-)和[IParagraphFormat.getTabs](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraphformat/#getTabs--)可在段落中配置制表位。

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

![The paragraph tabs](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)，可为文本片段设置校对语言。校对语言决定 PowerPoint 中拼写和语法检查使用的语言。

下面的代码示例展示了如何为文本片段设置校对语言：

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

使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)可以定义在加载或创建演示文稿时创建的文本的默认语言。

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

    // 检查首个文本片段的语言。
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用[IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--)。

下面的代码示例演示了如何在新演示文稿中为所有幻灯片的文本设置默认的粗体、14 磅大小的字体。

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

## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使幻灯片上的文本显示为大写，即使原始输入是小写。当使用 Aspose.Slides 获取此类文本片段时，库会返回原始输入的文本。要使返回的字符串与显示的文本一致，需要在属性为[TextCapType.All](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/textcaptype/)时将其转换为大写。

假设在 sample2.pptx 的第一页有如下文本框：

![The All Caps effect](all_caps_effect.png)

下面的代码示例展示了如何提取带 **All Caps** 效果的文本：

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

## **常见问题解答**

**如何修改幻灯片中表格的文本？**

要修改幻灯片中表格的文本，使用[ITable](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/itable/)。遍历单元格，通过[ICell.getTextFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icell/#getTextFrame--)获取文本框，并通过[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--)修改段落格式。

**如何在 PowerPoint 幻灯片的文本上应用渐变色？**

要为文本应用渐变色，使用[IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--)。将[IFillFormat.setFillType](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-)设置为[FillType.Gradient](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/filltype/)，并配置渐变停止点、方向和透明度。