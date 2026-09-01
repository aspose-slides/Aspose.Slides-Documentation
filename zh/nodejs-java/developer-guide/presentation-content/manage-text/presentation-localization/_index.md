---
title: 在 JavaScript 中自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/nodejs-java/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 抑制拼写检查
- 校对语言
- 语言标识符
- 多语言文本
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中为 PowerPoint 和 OpenDocument 演示文稿文本设置校对语言，包括默认语言和多语言段落。"
---
## **概述**

Aspose.Slides for Node.js via Java 允许您为单独的文本段落配置校对元数据。使用[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)来标识校对语言，使用[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-)来允许或抑制拼写检查，使用[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-)来控制更广泛的“不校对”状态。由于这些设置在段落级别应用，一个段落可以包含多种语言和不同的校对规则。

本文说明了如何为特定文本分配语言，使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)为新文本设置默认语言，构建多语言段落，在`SpellCheck`和`ProofDisabled`之间进行选择，以及在使用[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--)时保留预期设置。这些属性存储演示文稿应用程序的元数据；它们不翻译文本、不执行基于词典的拼写检查，也不返回拼写错误的单词。

## **为文本设置校对语言**

创建或加载一个[Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/)，通过[Portion.getPortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#getPortionFormat--)获取所需的文本段落，并分配其语言标识符。以下示例创建一个形状，将校对语言设置为英式英语，并使用[Presentation.save](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-)保存结果：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **为新文本设置默认语言**

使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)指定 Aspose.Slides 分配给新创建文本的校对语言。当演示文稿中大多数或全部新文本使用相同语言时，此设置很有用。它不会更改已经具有显式语言的文本的语言元数据。

下面的示例创建一个演示文稿，其新文本使用德语校对规则：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在同一段落中使用多种语言**

[Paragraph](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/paragraph/) 包含一组文本段落。为每种语言创建单独的[Portion](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/)，并独立设置其 `LanguageId`。

此示例创建一个包含英文和法文段落的段落：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **为单独段落启用或抑制拼写检查**

[PortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portionformat/) 继承了由[BasePortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/)定义的通用文本属性。通过[Portion.getPortionFormat](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/portion/#getPortionFormat--)访问段落的格式，并使用[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-)来控制演示文稿应用程序是否检查该段落的拼写。默认值为 `false`：`true` 允许拼写检查，`false` 则抑制。

该设置适用于单个文本段落。因此，同一段落中的不同段落可以使用不同的值。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 和 `setSpellCheck` 具有互补作用：`setLanguageId` 标识校对语言，而 `setSpellCheck` 决定是否允许对该段落进行拼写检查。

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) 也控制校对，但它以[NullableBool](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/nullablebool/)的形式表示更广泛的“不要校对”状态。当您仅需要针对拼写检查的布尔开关时，使用 `setSpellCheck`。当您需要保留或显式控制演示文稿的“无校对”元数据（包括其 `NotDefined` 状态）时，使用 `setProofDisabled`。如果同时设置两个属性，请保持它们的值一致；不要将 `setSpellCheck(true)` 与 `setProofDisabled(NullableBool.True)` 组合使用。

这些属性配置 PowerPoint 和其他演示文稿应用程序使用的校对元数据。Aspose.Slides 不会使用它们进行基于词典的拼写检查，也不会返回拼写错误单词的列表。

以下完整示例创建一个输入演示文稿，加载它，为同一段落中的两个段落分配不同的拼写检查设置和校对语言，保存结果，重新打开并验证存储的值：

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) 将具有相同格式的相邻段落合并。仅 `SpellCheck` 的差异不足以保持这些段落分离；合并后，生成的段落保留首个段落的 `SpellCheck` 值。如果段落需要不同的拼写检查设置，请在分配这些设置之前调用 `joinPortionsWithSameFormatting`，或检查生成的段落边界并在之后重新应用设置。具有不同 `LanguageId` 值的段落会保持分离，因为它们的校对语言格式不同。

## **常见问题**

**语言 ID 会翻译文本吗？**

不会。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 仅存储用于拼写和语法校对的元数据；它不更改文本内容。请单独翻译文本，然后为每个已翻译的段落设置相应的语言标识符。

**校对语言会控制字体、连字或换行吗？**

不会。语言标识符仅用于校对。文本渲染和布局主要取决于可用的[字体](/slides/zh/nodejs-java/powerpoint-fonts/)、书写系统和文本框设置。为获得可靠的渲染，请提供所需字体，配置[字体替换](/slides/zh/nodejs-java/font-substitution/)，或在演示文稿中[嵌入字体](/slides/zh/nodejs-java/embedded-font/)。

**一个段落可以使用多种校对语言吗？**

可以。按照多语言段落示例，将每种语言分配给单独的段落。

**应该使用 `setDefaultTextLanguage` 还是 `setLanguageId`？**

当您希望为新创建的文本设置默认语言时，请使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)。当特定段落需要显式的校对语言，或段落包含多种语言时，请使用[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)。