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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中格式化和样式化文本。自定义字体、颜色、对齐方式等。"
---
## **概述**

本文展示了如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 和 OpenDocument 演示文稿中格式化文本。内容涵盖背景颜色、透明度、字符间距、字体属性、旋转、段落间距、自动适应行为、文本锚定、制表位和语言设置。

除非另行说明，示例均使用 [sample.pptx](sample.pptx)。其第一张幻灯片的第一个形状是文本框，首个段落包含以下文本。幻灯片和形状索引均从零开始。选择粗体部分的示例使用有效格式（包括继承的粗体格式）：

![示例文本](sample_text.png)

要查找并高亮显示文字或正则表达式匹配，请参阅 [Search and Replace Text](/slides/zh/php-java/search-and-replace-text/)。

## **设置文本背景颜色**

使用 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 为段落设置默认突出显示颜色，或使用 [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#getHighlightColor) 为单独的文本片段设置。

下面的示例将浅灰色突出显示设为第一段的默认颜色。对单独片段的显式突出显示颜色将优先于此默认值：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

使用 [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setAlignment) 设置文本框内段落的对齐方式。可选值包括居中、左对齐、右对齐、两端对齐等。

下面的代码示例展示如何将段落对齐到 **居中**：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

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

文本透明度通过分配给 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#getFillFormat) 的颜色的 Alpha 分量控制。下面示例中，`alpha = 50` 是 0–255 范围的 ARGB 透明通道值，而非百分比。

下面的代码示例展示如何对 **整个段落** 应用透明度：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

下面的代码示例展示如何对 **加粗字体的文本片段** 应用透明度：

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

使用 [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setSpacing) 可以在文本框中扩大或压缩字符之间的间距。示例中增加了 3 磅的间距；负值会压缩文本。

下面的 PHP 代码展示如何在 **整个段落** 中扩大字符间距：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // 注意：使用负值来压缩字符间距。
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // 展开字符间距。

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![段落中的字符间距](character_spacing_in_paragraph.png)

下面的代码示例展示如何在 **加粗字体的文本片段** 中扩大字符间距：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // 注意：使用负值来压缩字符间距。
            $portion->getPortionFormat()->setSpacing(3); // 展开字符间距。
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

结果：

![文本片段中的字符间距](character_spacing_in_text_portions.png)

### **为特定字体禁用连字**

在某些情况下，Aspose.Slides 渲染的文本看起来比 PowerPoint 中的同一文本略紧。这可能是因为 PowerPoint 会忽略某些字体的连字数据，即使该字体包含有效的连字信息且在 PowerPoint 设置中已启用连字。

为使渲染输出更接近 PowerPoint，您可以为使用受影响字体的文本片段禁用连字。将 [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) 设置为大于实际字体大小的值。本示例需要 “presentation.pptx”，其中第一张幻灯片的第一形状是文本框。它检查有效字体名称（包括继承的字体），并为使用 Roboto 且字体大小低于 100 点的片段设置阈值，从而禁用这些片段的连字：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

对于低于阈值的匹配文本，此设置会阻止连字，帮助使 Aspose.Slides 的渲染与 PowerPoint 在受此 PowerPoint 特定行为影响的字体的视觉输出更为一致。

## **管理文本字体属性**

可以通过 [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) 在段落级别设置字体属性，也可以通过 [PortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/) 在单个片段上设置。

下面的示例将第一段的默认字体设为 12 磅 Times New Roman，并使用粗体、斜体和点状下划线。对单个片段的显式格式将优先于这些默认设置：

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // 为段落设置字体属性。
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

下面的示例为有效格式为粗体的片段应用 13 磅 Times New Roman、斜体以及点状下划线：

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

使用 [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setTextVerticalType) 在形状内部设置预定义的文本方向。

下面的代码示例将形状中的文本方向设置为 [TextVerticalType::Vertical270](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textverticaltype/)，这会使文本 **逆时针旋转 90 度**：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

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

下面的代码示例将在形状内将文本框顺时针旋转 3 度：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **设置段落的行间距**

Aspose.Slides 提供 [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setSpaceAfter)、[ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setSpaceBefore) 和 [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setSpaceWithin) 来控制段落间距。这些属性的使用方式如下：

* 使用正值将行间距指定为行高的百分比。
* 使用负值将行间距指定为磅值。

下面的示例将第一段内部的间距设为行高的 200%（双倍行距）：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **控制换行行为**

段落换行规则在窄文本块以及混合拉丁文和东亚文字的演示文稿中非常有用。以下方法属于 [ParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/)，因此适用于整个段落：

- [setLatinLineBreak](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) 控制拉丁文换行规则。在混合文本中，修改它也可能影响相邻东亚文字和标点的换行位置。
- [setEastAsianLineBreak](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) 控制东亚换行规则，包括行首和行末字符的限制。

这些规则不会取代 [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setWrapText)，后者启用文本框内的自动换行。它们仅在换行发生时影响布局，不会插入换行符。显式换行会强制在段落内部另起一行，独立于可用宽度。

下面的完整示例创建一个包含中文和拉丁文的窄文本块，显式设置两种换行选项并保存为 “line_breaking.pptx”。如需实验任一规则，只需更改对应的值，同时保持另一设置不变。示例使用 24 磅 Arial 和 SimSun，框宽 160 磅，水平文本框边距为零。调用 [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setAutofitType) 并使用 [TextAutofitType::None](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textautofittype/) 以保持文字尺寸和框尺寸固定：

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **控制悬挂标点**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) 允许符合条件的标点超出文本行右边缘，而不是占据下一行。它作用于整个段落，且不同于悬挂缩进。

下面的完整示例在宽度为 100 磅的文本框中启用悬挂标点并保存为 “hanging_punctuation.pptx”。使用 24 磅 Arial、水平文本框边距为零，最终的句点会停留在 “sentence” 之后并超出右侧文本边缘。将属性设置为 [NullableBool::False](https://reference.aspose.com/slides/zh/php-java/aspose.slides/nullablebool/) 可作对比：此时句点会占据单独一行。已启用换行并禁用自动适应以保持可用宽度固定。

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

并非所有标点都可以悬挂。可见结果取决于字体可用性和布局：更改字体、可用宽度、边距或自动适应设置都可能消除可见差异。

## **设置文本框的自动适应类型**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setAutofitType) 决定文本超出容器边界时的行为。可用来控制文本是缩小、溢出还是自动调整形状大小。下面的示例将形状设置为随文本大小自动调整，并将结果保存为 “autofit_type.pptx”。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

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

若要在自动换行后统计行数并查看文本或形状宽度变化对结果的影响，请参阅 [Count Rendered Lines](/slides/zh/php-java/manage-paragraph/)。仅行数并不能说明文本是否溢出其容器。

## **设置文本框的锚定方式**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textframeformat/#setAnchoringType) 定义文本在形状内部的垂直定位方式，例如顶部、居中或底部。下面的示例将文本锚定到第一个形状的底部，并将结果保存为 “text_anchor.pptx”。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

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

使用 [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) 和 [ParagraphFormat::getTabs](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraphformat/#getTabs) 配置段落中的制表位。下面的示例将默认制表间距设为 100 磅，并在 30 磅处添加左对齐的制表位。这些设置会影响包含制表符的文本。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

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

Aspose.Slides 提供 [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLanguageId)，用于为文本片段设置校对语言。校对语言决定在 PowerPoint 中进行拼写和语法检查时使用的语言。

下面的示例需要 “presentation.pptx”，其中第一张幻灯片的第一形状为文本框且至少包含一个段落。它将第一段内容替换为 “1。”，将字体设为 SimSun，并将校对语言设为简体中文 (`zh-CN`)。结果保存为 “proofing_language.pptx”：

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

使用 [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 定义在加载或创建演示文稿时创建的文本的默认语言。下面的示例创建一个默认文本语言为美式英语的演示文稿，添加一个文本框，并打印其第一个文本片段的语言代码 `en-US`。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // 添加一个带文本的矩形形状。
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // 检查第一段文字的语言。
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **设置默认文本样式**

要在演示文稿级别应用默认文本格式，请使用 [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#getDefaultTextStyle)。

下面的示例将新演示文稿中顶层段落的默认字体设为 14 磅粗体，并将其保存为 “default_text_style.pptx”。文本可以继承这些默认值，除非更具体的格式覆盖了它们。

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

在 PowerPoint 中，应用 **All Caps** 字体效果会使幻灯片上显示的文本为大写，即使原始输入是小写。当使用 Aspose.Slides 检索此类文本片段时，库会返回原始输入的文本。若要匹配显示的文本，请检查 [TextCapType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/textcaptype/) 并在值为 `All` 时将返回的字符串转换为大写。

此示例需要 “sample2.pptx”，其中第一张幻灯片的第一形状为文本框。其第一段的第一个片段包含 “Hello, Aspose!” 并应用了 All Caps 效果，如下所示。

![全大写效果](all_caps_effect.png)

下面的代码示例展示如何提取带 **All Caps** 效果的文本：

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

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

要修改幻灯片中表格的文本，请使用 [Table](https://reference.aspose.com/slides/zh/php-java/aspose.slides/table/)。遍历单元格并通过 [Cell::getTextFrame](https://reference.aspose.com/slides/zh/php-java/aspose.slides/cell/#getTextFrame) 更新每个单元格，以及通过 [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/#getParagraphFormat) 更新段落格式。

**如何在 PowerPoint 幻灯片上的文本应用渐变颜色？**

要为文本应用渐变颜色，请使用 [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#getFillFormat)。将 [FillFormat::setFillType](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fillformat/#setFillType) 设置为 [FillType::Gradient](https://reference.aspose.com/slides/zh/php-java/aspose.slides/filltype/)，并配置渐变停止点、方向和透明度。