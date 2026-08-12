---
title: 在 PHP 中格式化演示文稿文本
linktitle: 文本格式化
type: docs
weight: 50
url: /zh/php-java/text-formatting/
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
- 自动适配属性
- 文本框锚点
- 文本制表位
- 默认语言
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中格式化和设置文本样式。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for PHP via Java 对 PowerPoint 和 OpenDocument 演示文稿中的文本进行格式化。内容包括背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适配行为、文本锚点、制表位和语言设置。

在下列示例中，我们使用名为 **“sample.pptx”** 的文件，该文件在首张幻灯片上包含一个带有以下文本的单个文本框：

![示例文本](sample_text.png)

要查找并突出显示文字字面值或正则表达式匹配，请参阅[Search and Replace Text](/slides/zh/php-java/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 为段落设置默认的突出显示颜色，或使用 [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#getHighlightColor) 为单独的文本片段设置颜色。

下面的代码示例演示如何为 **整个段落** 设置背景颜色：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // 为整个段落设置突出显示颜色。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![灰色段落](gray_paragraph.png)

下面的代码示例演示如何为 **加粗字体的文本片段** 设置背景颜色：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 为文本片段设置突出显示颜色。
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![灰色文本片段](gray_text_portions.png)

## **对齐文本段落**

使用 [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setAlignment) 设置文本框内段落的对齐方式。该值可以是居中、左对齐、右对齐、两端对齐等。

下面的代码示例演示如何将段落对齐至 **居中**：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 将段落的对齐方式设置为居中。
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![对齐后的段落](aligned_paragraph.png)

## **设置文本透明度**

文本透明度通过分配给 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#getFillFormat) 的颜色的 Alpha 分量来控制。下面示例中，`alpha = 50` 是 0–255 范围内的 ARGB Alpha 通道值，而非百分比透明度。

下面的代码示例演示如何为 **整个段落** 应用透明度：

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // 将文本的填充颜色设置为透明颜色。
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![透明段落](transparent_paragraph.png)

下面的代码示例演示如何为 **加粗字体的文本片段** 应用透明度：

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 设置文本片段的透明度。
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![透明文本片段](transparent_text_portions.png)

## **设置文本字符间距**

使用 [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setSpacing) 可以在文本框中扩展或收紧字符之间的间距。

下面的 PHP 代码演示如何在 **整个段落** 中扩大字符间距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注意：使用负值来压缩字符间距。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 扩大字符间距。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例演示如何在 **加粗字体的文本片段** 中扩大字符间距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 注意：使用负值来压缩字符间距。
            $portion->getPortionFormat()->setSpacing(3); // 扩大字符间距。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用字偶距**

在某些情况下，Aspose.Slides 渲染的文本可能比 PowerPoint 中显示的略紧。这可能是因为 PowerPoint 对某些字体忽略了字偶距数据，即使该字体包含有效的字偶距信息且在 PowerPoint 设置中已启用字偶距。

为使渲染结果更接近 PowerPoint，您可以为使用受影响字体的文本片段禁用字偶距。将 [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) 设置为明显大于实际字体大小的值：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

此设置可阻止字偶距应用于匹配的文本片段，从而帮助 Aspose.Slides 的渲染效果与 PowerPoint 对此类字体的特定行为保持一致。

## **管理文本字体属性**

可以通过 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落层面设置字体属性，也可以通过 [PortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/) 在单独的片段上设置。

下面的代码为整个段落设置字体和文本样式：包括字体大小、粗体、斜体、点划下划线以及 Times New Roman 字体，适用于段落中的所有片段。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // 设置段落的字体属性。
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![段落的字体属性](font_properties_for_paragraph.png)

下面的代码示例将相同的属性应用于 **加粗字体的文本片段**：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // 为文本片段设置字体属性。
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![文本片段的字体属性](font_properties_for_text_portions.png)

## **设置文本旋转**

使用 [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setTextVerticalType) 可以在形状内设置预定义的文本方向。

下面的代码示例将形状内的文本方向设置为 `Vertical270`，即将文本 **逆时针旋转 90 度**：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![文本旋转](text_rotation.png)

## **为文本框设置自定义旋转**

使用 [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setRotationAngle) 为 [TextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframe/) 设置自定义旋转角度。

下面的代码示例在形状内将文本框顺时针旋转 3 度：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![自定义文本旋转](custom_text_rotation.png)

## **设置段落行间距**

Aspose.Slides 提供 [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setSpaceBefore) 和 [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setSpaceWithin) 用于控制段落间距。这些属性的使用方式如下：

* 使用正值将行间距指定为行高的百分比。
* 使用负值将行间距指定为磅值。

下面的代码示例演示如何在段落内部指定行间距：

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![段落内部的行间距](line_spacing.png)

## **设置文本框的自动适配类型**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setAutofitType) 决定当文本超出容器边界时的行为。使用它可以控制文本是收缩、溢出还是自动调整形状大小。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置文本框的锚点**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setAnchoringType) 定义文本在形状内部的垂直位置，例如顶部、居中或底部。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置文本制表位**

使用 [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) 与 [ParagraphFormat::getTabs](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#getTabs) 可以在段落中配置制表位。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![段落制表位](paragraph_tabs.png)

## **设置校对语言**

Aspose.Slides 提供 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLanguageId)，允许为文本片段设置校对语言。校对语言决定了 PowerPoint 中的拼写和语法检查使用的语言。

下面的代码示例演示如何为文本片段设置校对语言：

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // 设置校对语言的 Id。
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **设置默认语言**

使用 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 可以为在加载或创建演示文稿时生成的文本定义默认语言。

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个带文本的矩形形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 检查第一个文本片段的语言。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getDefaultTextStyle)。

下面的代码示例演示如何在新演示文稿中为所有幻灯片的文本设置默认的 **粗体、14 磅** 字体。

```php
$presentation = new Presentation();
try {
    // 获取顶层段落格式。
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

在 PowerPoint 中，应用 **All Caps** 字体效果会使幻灯片上的文本显示为大写，即使原始输入是小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回其原始输入形式。若要匹配显示的文本，需要检查 [TextCapType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textcaptype/) 并在值为 `All` 时将返回的字符串转换为大写。

假设在 sample2.pptx 文件的第一张幻灯片上有如下文本框：

![全大写效果](all_caps_effect.png)

下面的代码示例演示如何提取带 **All Caps** 效果的文本：

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

输出：

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **常见问题解答**

**如何修改幻灯片中表格的文本？**

要修改幻灯片中表格的文本，请使用 [Table](https://reference.aspose.com/slides/zh/php-java/aspose.slides/table/)。遍历单元格并通过 [Cell::getTextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cell/#getTextFrame) 更新每个单元格的文本框，通过 [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#getParagraphFormat) 更新段落格式。

**如何为 PowerPoint 幻灯片中的文本应用渐变颜色？**

要为文本应用渐变颜色，请使用 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#getFillFormat)。将 [FillFormat::setFillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/#setFillType) 设置为 [FillType::Gradient](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/)，并配置渐变止点、方向以及透明度。