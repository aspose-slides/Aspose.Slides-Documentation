---
title: JavaScriptでプレゼンテーションのローカリゼーションを自動化
linktitle: プレゼンテーション ローカリゼーション
type: docs
weight: 100
url: /ja/nodejs-java/presentation-localization/
keywords:
- 言語の変更
- スペルチェック
- スペルチェックの抑制
- 校正言語
- 言語 ID
- 多言語テキスト
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して、JavaScript で PowerPoint および OpenDocument プレゼンテーションテキストの校正言語を設定します。既定設定や多言語段落も含みます。"
---
## **概要**

Aspose.Slides for Node.js via Java を使用すると、個々のテキスト部分に対して校正メタデータを構成できます。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)で校正言語を指定し、[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-)でスペルチェックの有無を制御し、[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-)でより広範な「校正しない」状態を管理します。これらの設定は部分レベルで適用されるため、1 つの段落に複数の言語や異なる校正ルールを含めることができます。

本記事では、特定のテキストに言語を割り当てる方法、[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)で新規テキストの既定言語を設定する方法、多言語段落の作成、`SpellCheck` と `ProofDisabled` の選択、そして [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) を使用した際に意図した設定を保持する方法を説明します。これらのプロパティはプレゼンテーション アプリケーション向けのメタデータを格納しますが、テキストの翻訳や辞書ベースのスペルチェック、誤字の取得は行いません。

## **テキストの校正言語を設定する**

[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) を作成または読み込み、[Portion.getPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#getPortionFormat--) で目的のテキスト部分にアクセスし、言語識別子を割り当てます。以下の例はシェイプを作成し、校正言語として英国英語を設定し、[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) で結果を保存します。

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

## **新規テキストの既定言語を設定する**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用して、Aspose.Slides が新しく作成するテキストに自動的に割り当てる校正言語を指定します。この設定は、プレゼンテーション内のほとんどまたはすべての新規テキストが同じ言語を使用する場合に便利です。既に明示的に言語が設定されているテキストのメタデータは変更されません。

以下の例は、新規テキストがドイツ語の校正ルールを使用するプレゼンテーションを作成します。

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

## **1 段落で複数言語を使用する**

[Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/) はテキスト部分のコレクションを保持します。言語ごとに別々の [Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/) を作成し、各々の `LanguageId` を個別に設定します。

この例は、英語とフランス語の部分を含む 1 つの段落を作成します。

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

## **個々の部分に対してスペルチェックを有効または抑制する**

[PortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/) は、[BasePortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/) で定義された共通テキスト プロパティを継承します。[Portion.getPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#getPortionFormat--) で部分の書式にアクセスし、[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) を使用して、プレゼンテーション アプリケーションがその部分のスペルチェックを行うかどうかを制御します。デフォルト値は `false` で、`true` にするとスペルチェックが許可され、`false` にすると抑制されます。

この設定は個々のテキスト部分に適用されます。同じ段落内の異なる部分はそれぞれ異なる値を持つことができます。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) と `setSpellCheck` は補完的な役割を果たします：`setLanguageId` が校正言語を特定し、`setSpellCheck` がその部分でスペルチェックを許可するかどうかを決定します。

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) も校正を制御しますが、これは [NullableBool](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/nullablebool/) として「校正しない」状態全体を表します。スペルチェック専用のブール スイッチが必要な場合は `setSpellCheck` を使用し、プレゼンテーション の「校正なし」メタデータ（`NotDefined` 状態を含む）を保持または明示的に制御したい場合は `setProofDisabled` を使用します。両方のプロパティを設定する場合は、値を一致させてください。`setSpellCheck(true)` と `setProofDisabled(NullableBool.True)` を組み合わせないでください。

これらのプロパティは PowerPoint などのプレゼンテーション アプリケーションで使用される校正メタデータを構成しますが、Aspose.Slides が辞書ベースのスペルチェックを実行したり、誤字リストを返したりすることはありません。

以下の完全な例は、入力プレゼンテーションを作成し、読み込み、同一段落内の 2 つの部分に対して異なるスペルチェック設定と校正言語を割り当て、結果を保存し、再度開いて格納された値を検証します。

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) は、同じ書式を持つ隣接する部分を結合します。`SpellCheck` のみが異なる場合でも、結合後の部分は最初の部分の `SpellCheck` 値を保持します。異なるスペルチェック設定が必要な部分がある場合は、設定を割り当てる前に `joinPortionsWithSameFormatting` を呼び出すか、結合後の部分境界を確認して再度設定してください。`LanguageId` の値が異なる部分は、校正言語の書式が異なるため、結合されずに残ります。

## **FAQ**

**言語 ID はテキストを翻訳しますか？**

いいえ。[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) はスペルチェックや文法チェック用の校正メタデータを格納するだけで、テキスト内容は変更しません。テキストは別途翻訳し、翻訳後の各部分に適切な言語識別子を設定してください。

**校正言語はフォント、ハイフネーション、行折り返しを制御しますか？**

いいえ。言語識別子は校正用です。テキストの描画やレイアウトは、利用可能な [fonts](/slides/ja/nodejs-java/powerpoint-fonts/)、文字体系、テキストフレームの設定に主に依存します。確実な表示のために必要なフォントを提供し、[font substitution](/slides/ja/nodejs-java/font-substitution/) を設定するか、プレゼンテーションに [embed fonts](/slides/ja/nodejs-java/embedded-font/) を埋め込んでください。

**1 段落で複数の校正言語を使用できますか？**

はい。例に示すように、各言語を別々の部分に割り当てれば、段落内で複数の校正言語を使用できます。

**`setDefaultTextLanguage` と `setLanguageId` のどちらを使うべきですか？**

新規に作成するテキスト全体の既定を設定したい場合は [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) を使用します。特定の部分に明示的な校正言語を設定したい場合、または段落に複数の言語が混在する場合は [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) を使用してください。