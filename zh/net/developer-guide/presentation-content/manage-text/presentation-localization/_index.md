---
title: 在 .NET 中自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/net/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 抑制拼写检查
- 校对语言
- 语言标识符
- 多语言文本
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 为 PowerPoint 和 OpenDocument 演示文稿文本设置校对语言，包括默认设置和多语言段落。"
---
## **概览**

Aspose.Slides for .NET 允许您为单独的文本段落配置校对元数据。使用 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/languageid/) 指定校对语言，使用 [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/zh/net/aspose.slides/baseportionformat/spellcheck/) 来开启或抑制拼写检查，并使用 [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/zh/net/aspose.slides/baseportionformat/proofdisabled/) 控制更广泛的“无校对”状态。由于这些设置在段落级别应用，一个段落可以包含多种语言和不同的校对规则。

本文介绍如何为特定文本分配语言，使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/defaulttextlanguage/) 为新文本设置默认语言，构建多语言段落，在 `SpellCheck` 与 `ProofDisabled` 之间进行选择，以及在使用 [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/joinportionswithsameformatting/) 时保留预期设置。这些属性存储供演示文稿应用程序使用的元数据；它们不对文本进行翻译、执行基于词典的拼写检查，也不返回拼写错误的单词。

## **为文本设置校对语言**

创建或加载一个 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)，通过 [IPortion.PortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/portionformat/) 访问所需的文本段落，并为其分配语言标识符。下面的示例创建一个形状，将校对语言设置为英式英语，并使用 [Presentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/save/) 保存结果：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **为新文本设置默认语言**

使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/defaulttextlanguage/) 指定 Aspose.Slides 为新创建的文本分配的校对语言。当演示文稿中的大多数或全部新文本使用相同语言时，此设置非常有用。它不会更改已显式指定语言的文本的语言元数据。

下面的示例创建一个演示文稿，其新文本使用德语校对规则：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **在同一段落中使用多种语言**

[IParagraph](https://reference.aspose.com/slides/zh/net/aspose.slides/iparagraph/) 包含一组文本段落。为每种语言创建单独的 [Portion](https://reference.aspose.com/slides/zh/net/aspose.slides/portion/)，并独立设置其 `LanguageId`。

此示例创建一个包含英文和法文段落的段落：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **为单独段落启用或抑制拼写检查**

[IPortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportionformat/) 继承自 [IBasePortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/) 定义的通用文本属性。通过 [IPortion.PortionFormat](https://reference.aspose.com/slides/zh/net/aspose.slides/iportion/portionformat/) 访问段落的格式，并设置 [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/zh/net/aspose.slides/baseportionformat/spellcheck/) 来控制演示文稿应用程序是否检查该段落的拼写。默认值为 `false`：`true` 允许拼写检查，`false` 抑制检查。

此设置针对单独的文本段落。同一段落中的不同段落因此可以使用不同的值。[BasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh/net/aspose.slides/baseportionformat/languageid/) 与 `SpellCheck` 互补：`LanguageId` 标识校对语言，而 `SpellCheck` 决定是否允许对该段落进行拼写检查。

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/zh/net/aspose.slides/baseportionformat/proofdisabled/) 也控制校对，但它以 [NullableBool](https://reference.aspose.com/slides/zh/net/aspose.slides/nullablebool/) 表示更广泛的“不要校对”状态。当您仅需针对拼写检查的布尔开关时使用 `SpellCheck`；当需要保留或显式控制演示文稿的无校对元数据（包括其 `NotDefined` 状态）时使用 `ProofDisabled`。如果同时设置两个属性，请保持它们的值一致；不要将 `SpellCheck = true` 与 `ProofDisabled = NullableBool.True` 组合使用。

这些属性配置 PowerPoint 和其他演示文稿应用程序使用的校对元数据。Aspose.Slides 不会使用它们进行基于词典的拼写检查或返回拼写错误单词列表。

下面的完整示例创建一个输入演示文稿，加载它，分别为同一段落中的两个段落分配不同的拼写检查设置和校对语言，保存结果，重新打开并验证存储的值：

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/joinportionswithsameformatting/) 会合并具有相同格式的相邻段落。仅 `SpellCheck` 的差异不足以保持这些段落分离；合并后，生成的段落保留第一个段落的 `SpellCheck` 值。如果段落需要不同的拼写检查设置，请在分配这些设置之前调用 `JoinPortionsWithSameFormatting`，或在合并后检查生成的段落边界并重新应用设置。具有不同 `LanguageId` 值的段落会保持分离，因为它们的校对语言格式不同。

## **常见问题**

**语言 ID 会翻译文本吗？**

不会。[IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/languageid/) 仅存储拼写和语法的校对元数据；它不更改文本内容。请先单独翻译文本，然后为每个已翻译的段落设置相应的语言标识符。

**校对语言会控制字体、连字或换行吗？**

不会。语言标识符仅用于校对。文本渲染和布局主要取决于可用的[字体](/slides/zh/net/powerpoint-fonts/)、书写系统以及文本框设置。为获得可靠的渲染，请提供所需字体，配置[字体替换](/slides/zh/net/font-substitution/)，或在演示文稿中[嵌入字体](/slides/zh/net/embedded-font/)。

**一个段落可以使用多种校对语言吗？**

可以。如多语言段落示例所示，为每种语言创建单独的段落。

**应该使用 `DefaultTextLanguage` 还是 `LanguageId`？**

当您希望为新创建的文本提供默认语言时，请使用 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/defaulttextlanguage/)。当特定段落需要显式的校对语言，或段落包含多种语言时，请使用 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseportionformat/languageid/)。