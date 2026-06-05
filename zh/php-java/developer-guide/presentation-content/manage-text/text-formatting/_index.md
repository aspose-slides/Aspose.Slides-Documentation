---
title: 在 PHP 中格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/php-java/text-formatting/
keywords:
- 高亮文本
- 正则表达式
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
- 文本制表
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中格式化和设置文本样式。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中格式化文本。它涵盖了高亮、背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位以及语言设置。

在下面的示例中，我们将使用名为“sample.pptx”的文件，该文件在第一张幻灯片上包含一个带有以下文本的单个文本框：

![示例文本](sample_text.png)

## **高亮文本**

当需要高亮文本框中匹配特定样本的文本时，请使用 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)`::highlightText` 方法。该方法为匹配的文本片段应用高亮颜色，并且可以结合 [TextHighlightingOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/texthighlightingoptions/) 来控制搜索方式，例如，仅匹配完整单词。

下面的代码示例先高亮所有字符 **"try"** 的出现，然后仅高亮完整单词 **"to"**。

```php
$presentation = new Presentation("sample.pptx");
try {
    // 获取第一张幻灯片中的第一个形状。
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // 在形状中高亮单词 "try"。
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // 在形状中高亮单词 "to"。
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![高亮文本](highlighted_text.png)

## **使用正则表达式高亮文本**

[TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/)`::highlightRegex` 方法会高亮正则表达式匹配的文本。

下面的代码示例高亮所有包含 **七个或更多字符** 的单词：

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // 高亮所有包含七个或更多字符的单词。
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![使用正则表达式高亮的文本](highlighted_text_using_regex.png)

## **设置文本背景颜色**

使用 [ParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/) 的默认部分格式来设置段落的默认高亮颜色，或使用 [PortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/) 为单个文本部分设置颜色。

下面的代码示例展示如何为 **整个段落** 设置背景颜色：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 为整个段落设置高亮颜色。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **加粗字体的文本部分** 设置背景颜色：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 为文本部分设置高亮颜色。
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![灰色文本部分](gray_text_portions.png)

## **对齐文本段落**

使用 [ParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/)`::setAlignment` 方法在文本框内设置段落对齐方式。该值可以是居中、左对齐、右对齐、两端对齐等。

下面的代码示例展示如何将段落对齐到 **居中**：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 将段落的对齐方式设置为居中。
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![已对齐的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给 [PortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/) 填充格式的颜色的 alpha 分量进行控制。在下面的示例中，`alpha = 50` 是 0-255 规模上的 ARGB alpha 通道值，而不是透明度百分比。

下面的代码示例展示如何对 **整个段落** 应用透明度：

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // 将文本的填充颜色设置为透明颜色。
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![透明段落](transparent_paragraph.png)

下面的代码示例展示如何对 **加粗字体的文本部分** 应用透明度：

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 设置文本部分的透明度。
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![透明文本部分](transparent_text_portions.png)

## **设置文本字符间距**

使用 [BasePortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/)`::setSpacing` 方法来扩展或压缩文本框中字符之间的间距。

下面的 PHP 代码展示如何在 **整个段落** 中扩展字符间距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注意：使用负值来压缩字符间距。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 扩展字符间距。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示如何在 **加粗字体的文本部分** 中扩展字符间距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 注意：使用负值来压缩字符间距。
            $portion->getPortionFormat()->setSpacing(3); // 扩展字符间距。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![文本部分中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字距调整**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中显示的相同文本略显紧凑。这可能是因为 PowerPoint 会忽略某些字体的字距信息，即使该字体包含有效的字距数据且在 PowerPoint 设置中已启用字距调整。

为使渲染输出更接近 PowerPoint，可以为使用受影响字体的文本部分禁用字距调整。将 [BasePortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` 方法设置为远大于实际字体大小的值：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

此设置可防止对匹配的文本部分应用字距调整，并有助于使 Aspose.Slides 的渲染效果与受此 PowerPoint 特定行为影响的字体的 PowerPoint 可视输出保持一致。

## **管理文本字体属性**

字体属性可以通过 [ParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/) 的默认部分格式在段落级别设置，或者通过 [PortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/) 在单个部分上设置。

下面的代码为整个段落设置字体和文本样式：它对段落中的所有部分应用字体大小、粗体、斜体、点状下划线以及 Times New Roman 字体。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // 为段落设置字体属性。
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![段落的字体属性](font_properties_for_paragraph.png)

下面的代码示例对 **加粗字体的文本部分** 应用类似属性：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 为文本部分设置字体属性。
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![文本部分的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用 [TextFrameFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` 方法在形状内设置预定义的文本方向。

下面的代码示例将形状中的文本方向设置为 `Vertical270`，即将文本 **逆时针旋转 90 度**：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

使用 [TextFrameFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/)`::setRotationAngle` 方法为 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 设置自定义旋转角度。

下面的代码示例将在形状内将文本框顺时针旋转 3 度：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行间距**

Aspose.Slides 提供 [ParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`、`ParagraphFormat::setSpaceBefore` 和 `ParagraphFormat::setSpaceWithin` 方法来控制段落间距。这些方法的使用如下：

* 使用正值将行间距指定为行高的百分比。
* 使用负值将行间距指定为磅值。

下面的代码示例展示如何在段落中指定行间距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![段落中的行间距](line_spacing.png)

## **设置文本框的自动适应类型**

[TextFrameFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/)`::setAutofitType` 方法决定文本超出容器边界时的行为。使用它可以控制文本是缩小、溢出还是自动调整形状大小。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置文本框的锚点**

[TextFrameFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/)`::setAnchoringType` 方法定义文本在形状内部的垂直定位方式，例如位于顶部、居中或底部。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置文本制表**

使用 [ParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` 方法及其制表符集合来配置段落中的制表位。

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [BasePortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/)`::setLanguageId` 方法，允许您为文本部分设置校对语言。校对语言决定 PowerPoint 中拼写和语法检查所使用的语言。

下面的代码示例展示如何为文本部分设置校对语言：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // 设置校对语言的 ID。
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置默认语言**

使用 [LoadOptions](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` 方法定义在加载或创建演示文稿时创建的文本的默认语言。

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个带文本的矩形形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 检查第一个文本段的语言。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 的默认文本样式。

下面的代码示例展示如何在新演示文稿中为所有幻灯片的所有文本设置默认的粗体、14 磅大小的字体。

```php
$presentation = new Presentation();
try {
    // 获取顶级段落格式。
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **提取带全大写效果的文本**

在 PowerPoint 中，应用 **All Caps** 字体效果会使文本在幻灯片上显示为大写，即使原始输入为小写。当使用 Aspose.Slides 检索此类文本部分时，库会返回文本的原始输入。为匹配显示的文本，需要检查 [TextCapType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textcaptype/) ，当其值为 `All` 时将返回的字符串转换为大写。

假设在 sample2.pptx 文件的第一页幻灯片上有如下文本框。

![全大写效果](all_caps_effect.png)

下面的代码示例展示如何提取已应用 **All Caps** 效果的文本：

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常见问题**

**如何在幻灯片的表格中修改文本？**

要在幻灯片的表格中修改文本，请使用 [Table](https://reference.aspose.com/slides/zh/php-java/aspose.slides/table/)。遍历单元格，并通过 [Cell](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cell/) 的文本框以及通过 [Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 的段落格式更新每个单元格的文本。

**如何在 PowerPoint 幻灯片的文本上应用渐变颜色？**

要对文本应用渐变颜色，请使用 [PortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/) 的填充格式。将 [FillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/) 的填充类型设置为 [FillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/) `Gradient`，并配置渐变停靠点、方向和透明度。