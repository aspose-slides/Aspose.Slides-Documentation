---
title: 在 Android 上自动化演示文稿本地化
linktitle: 演示文稿本地化
type: docs
weight: 100
url: /zh/androidjava/presentation-localization/
keywords:
- 更改语言
- 拼写检查
- 抑制拼写检查
- 校对语言
- 语言标识符
- 多语言文本
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides for Android via Java 为 PowerPoint 和 OpenDocument 演示文稿文本设置校对语言，包括默认语言和多语言段落。"
---
## **概述**

Aspose.Slides for Android via Java 允许您为各个文本段落配置校对元数据。使用[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)来标识校对语言，使用[IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-)来允许或抑制拼写检查，并使用[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-)来控制更广泛的“禁止校对”状态。由于这些设置在段落级别应用，一个段落可以包含多种语言和不同的校对规则。

本文档说明了如何为特定文本分配语言，如何使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)为新文本设置默认语言，如何构建多语言段落，如何在 `SpellCheck` 与 `ProofDisabled` 之间进行选择，以及在使用[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--)时如何保留预期的设置。这些属性仅存储演示文稿应用程序使用的元数据；它们不会翻译文本、执行基于词典的拼写检查或返回拼写错误的单词。

## **为文本设置校对语言**

创建或加载一个[Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/)，通过[IPortion.getPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#getPortionFormat--)获取所需的文本段落，并为其分配语言标识符。以下示例创建一个形状，将校对语言设置为英式英语，并使用[Presentation.save](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)保存结果：

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **为新文本设置默认语言**

使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)指定 Aspose.Slides 为新创建的文本分配的校对语言。当演示文稿中的大部分或全部新文本使用相同语言时，此设置非常有用。它不会更改已经显式设置语言的文本的语言元数据。

以下示例创建一个演示文稿，其新文本使用德语校对规则：

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **在单段落中使用多种语言**

[IParagraph](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iparagraph/) 包含一个文本段落集合。为每种语言创建单独的[Portion](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/portion/)，并独立设置其 `LanguageId`。

此示例创建一个包含英文和法文段落的段落：

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **为单个部分启用或抑制拼写检查**

[IPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportionformat/) 继承了由[IBasePortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/) 定义的通用文本属性。通过[IPortion.getPortionFormat](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/iportion/#getPortionFormat--)获取段落的格式，并使用[IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-)来控制演示文稿应用程序是否检查该段落的拼写。默认值为 `false`：`true` 允许拼写检查，`false` 则抑制检查。

该设置适用于各个文本段落。同一段落中的不同段落因此可以使用不同的值。[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 与 `setSpellCheck` 具有互补作用：`setLanguageId` 标识校对语言，而 `setSpellCheck` 决定是否允许对该段落进行拼写检查。

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) 亦可控制校对，但它以 [NullableBool](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/nullablebool/) 表示更广泛的“禁止校对”状态。当您仅需要针对拼写检查的布尔开关时，请使用 `setSpellCheck`。当您需要保留或显式控制演示文稿的“无校对”元数据（包括其 `NotDefined` 状态）时，请使用 `setProofDisabled`。如果同时设置这两个属性，请保持它们的值一致；不要将 `setSpellCheck(true)` 与 `setProofDisabled(NullableBool.True)` 组合使用。

这些属性配置 PowerPoint 等演示文稿应用程序使用的校对元数据。Aspose.Slides 不会利用它们执行基于词典的拼写检查或返回拼写错误单词的列表。

以下完整示例创建一个输入演示文稿，加载它，为同一段落中的两个段落分配不同的拼写检查设置和校对语言，保存结果后重新打开，并验证已存储的值：

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) 会合并具有相同格式的相邻段落。仅 `SpellCheck` 差异并不能保持这些段落分离；合并后，产生的段落保留首个段落的 `SpellCheck` 值。如果段落需要不同的拼写检查设置，请在分配这些设置之前调用 `joinPortionsWithSameFormatting`，或者在合并后检查产生的段落边界并重新应用设置。具有不同 `LanguageId` 值的段落会保持分离，因为它们的校对语言格式不同。

## **常见问题**

**语言 ID 会翻译文本吗？**

不会。[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) 仅存储用于拼写和语法校对的元数据；它不会改变文本内容。请单独翻译文本，然后为每个已翻译的段落设置相应的语言标识符。

**校对语言会控制字体、断字或换行吗？**

不会。语言标识符仅用于校对。文本的渲染和布局主要取决于可用的[fonts](/slides/zh/androidjava/powerpoint-fonts/)、书写系统以及文本框设置。为确保可靠渲染，请提供所需字体，配置[font substitution](/slides/zh/androidjava/font-substitution/)，或在演示文稿中[embed fonts](/slides/zh/androidjava/embedded-font/)。

**一个段落可以使用多种校对语言吗？**

可以。如多语言段落示例所示，为每种语言创建单独的段落即可。

**我应该使用 `setDefaultTextLanguage` 还是 `setLanguageId`？**

当您希望为新创建的文本提供默认语言时，请使用[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)。当特定段落需要显式的校对语言，或段落中包含多种语言时，请使用[IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-)。