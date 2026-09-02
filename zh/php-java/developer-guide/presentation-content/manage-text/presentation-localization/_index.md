---
title: 在 PHP 中自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/php-java/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 抑制拼写检查
- 校对语言
- 语言标识符
- 多语言文本
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "在 PHP 中使用 Aspose.Slides 为 PowerPoint 和 OpenDocument 演示文稿文本设置校对语言，包括默认语言和多语言段落。"
---
## **概述**

Aspose.Slides for PHP via Java 允许您为各个文本片段配置校对元数据。使用[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLanguageId) 来指定校对语言，使用[BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setSpellCheck) 来启用或抑制拼写检查，使用[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setProofDisabled) 来控制更宽泛的“不校对”状态。由于这些设置在片段级别应用，单个段落可以包含多种语言和不同的校对规则。

本文说明了如何为特定文本分配语言，使用[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 为新文本设置默认语言，构建多语言段落，在 `SpellCheck` 与 `ProofDisabled` 之间进行选择，并在使用[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) 时保留预期设置。这些属性存储演示文稿应用程序的元数据；它们不翻译文本、不执行基于字典的拼写检查，也不返回拼写错误的单词。

## **为文本设置校对语言**

创建或加载一个[Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/)，通过[Portion::getPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#getPortionFormat) 访问所需的文本片段，并为其分配语言标识符。下面的示例创建一个形状，将英国英语设为校对语言，并使用[Presentation::save](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#save) 保存结果：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **为新文本设置默认语言**

使用[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) 指定 Aspose.Slides 为新创建的文本分配的校对语言。当演示文稿中大多数或全部新文本使用相同语言时，此设置非常有用。它不会更改已经具有显式语言的文本的语言元数据。

下面的示例创建一个演示文稿，其新文本使用德语校对规则：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **在一个段落中使用多种语言**

[Paragraph](https://reference.aspose.com/slides/zh/php-java/aspose.slides/paragraph/) 包含一组文本片段。为每种语言创建单独的[Portion](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/)，并分别设置其 `LanguageId`。

此示例创建一个段落，其中包含英文和法文片段：

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **为单个片段启用或抑制拼写检查**

[PortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portionformat/) 继承自[BasePortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/) 定义的通用文本属性。通过[Portion::getPortionFormat](https://reference.aspose.com/slides/zh/php-java/aspose.slides/portion/#getPortionFormat) 访问片段的格式，并使用[BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setSpellCheck) 控制演示文稿应用程序是否对该片段进行拼写检查。默认值为 `false`：`true` 允许拼写检查，`false` 抑制拼写检查。

该设置适用于单个文本片段。同一段落中的不同片段因此可以使用不同的值。[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLanguageId) 与 `setSpellCheck` 互为补充：`setLanguageId` 确定校对语言，而 `setSpellCheck` 决定是否允许对该片段进行拼写检查。

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setProofDisabled) 也控制校对，但它表示更广泛的“不要校对”状态，使用[NullableBool](https://reference.aspose.com/slides/zh/php-java/aspose.slides/nullablebool/)。当您需要一个专门针对拼写检查的布尔开关时，请使用 `setSpellCheck`。当您需要保留或显式控制演示文稿的“无校对”元数据（包括其 `NotDefined` 状态）时，请使用 `setProofDisabled`。如果同时设置两个属性，请保持其值一致；不要将 `setSpellCheck(true)` 与 `setProofDisabled(NullableBool::True)` 组合使用。

这些属性配置 PowerPoint 等演示文稿应用程序使用的校对元数据。Aspose.Slides 并不利用它们执行基于字典的拼写检查或返回拼写错误单词列表。

下面的完整示例创建一个输入演示文稿，加载它，为同一段落中的两个片段分配不同的拼写检查设置和校对语言，保存结果，重新打开并验证存储的值：

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) 将具有相同格式的相邻片段合并。仅 `SpellCheck` 的差异并不能保持片段分离；合并后，结果片段保留第一个片段的 `SpellCheck` 值。如果片段需要不同的拼写检查设置，请在分配这些设置之前调用 `joinPortionsWithSameFormatting`，或在合并后检查结果片段的边界并重新应用设置。具有不同 `LanguageId` 值的片段会保持分离，因为其校对语言格式不同。

## **常见问题**

**语言 ID 会翻译文本吗？**

不会。[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLanguageId) 仅存储用于拼写和语法校对的元数据，不会改变文本内容。请先单独翻译文本，然后为每个已翻译的片段设置相应的语言标识符。

**校对语言会控制字体、连字符或换行吗？**

不会。语言标识符仅用于校对。文本渲染和布局主要取决于可用的[字体](/slides/zh/php-java/powerpoint-fonts/)、书写系统以及文本框设置。要确保可靠渲染，请提供所需字体，配置[字体替换](/slides/zh/php-java/font-substitution/)，或在演示文稿中[嵌入字体](/slides/zh/php-java/embedded-font/)。

**一个段落可以使用多种校对语言吗？**

可以。像多语言段落示例中那样，为每种语言创建单独的片段即可。

**应该使用 `setDefaultTextLanguage` 还是 `setLanguageId`？**

当您希望为新创建的文本提供默认语言时，请使用[LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/zh/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage)。当特定片段需要明确的校对语言，或段落包含多种语言时，请使用[BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/zh/php-java/aspose.slides/baseportionformat/#setLanguageId)。