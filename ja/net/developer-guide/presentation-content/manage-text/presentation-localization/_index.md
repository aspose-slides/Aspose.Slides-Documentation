---
title: .NET でプレゼンテーションのローカリゼーションを自動化する
linktitle: プレゼンテーション ローカリゼーション
type: docs
weight: 100
url: /ja/net/presentation-localization/
keywords:
- 言語を変更する
- スペルチェック
- スペルチェックを抑制する
- 校正言語
- 言語 ID
- 多言語テキスト
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET の Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーション テキストの校正言語を設定します。デフォルトや多言語段落も含みます。"
---
## **概要**

Aspose.Slides for .NET は、個々のテキスト部分の校正メタデータを構成できるようにします。[IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/languageid/) を使用して校正言語を識別し、[BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/spellcheck/) でスペルチェックの許可または抑制を行い、[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/proofdisabled/) でより広範な「校正なし」状態を制御します。これらの設定は部分レベルで適用されるため、1つの段落に複数の言語や異なる校正ルールを含めることができます。

この記事では、特定のテキストに言語を割り当てる方法、[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/defaulttextlanguage/) を使用して新規テキストのデフォルト言語を設定する方法、多言語段落の作成、`SpellCheck` と `ProofDisabled` の選択、そして [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/joinportionswithsameformatting/) を使用する際に意図した設定を保持する方法を説明します。これらのプロパティはプレゼンテーション アプリケーション向けのメタデータを格納しますが、テキストの翻訳や辞書ベースのスペルチェック、誤字一覧の取得は行いません。

## **テキストの校正言語を設定する**

[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) を作成または読み込み、[IPortion.PortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/portionformat/) を介して目的のテキスト部分にアクセスし、その言語識別子を割り当てます。以下の例はシェイプを作成し、校正言語として英語（英国）を設定し、[Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) で結果を保存します。

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

## **新規テキストのデフォルト言語を設定する**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/defaulttextlanguage/) を使用して、Aspose.Slides が新規作成テキストに割り当てる校正言語を指定します。この設定は、プレゼンテーション内の新規テキストのほとんどまたはすべてが同じ言語を使用する場合に便利です。既に明示的な言語が設定されているテキストの言語メタデータは変更されません。

以下の例は、新規テキストがドイツ語の校正規則を使用するプレゼンテーションを作成します。

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

## **1つの段落で複数の言語を使用する**

[IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) はテキスト部分のコレクションを保持します。各言語ごとに別々の [Portion](https://reference.aspose.com/slides/ja/net/aspose.slides/portion/) を作成し、`LanguageId` を個別に設定します。

この例は、英語とフランス語の部分を持つ段落を1つ作成します。

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

## **個々の部分に対してスペルチェックを有効化または抑制する**

[IPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/) は [IBasePortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/) によって定義された共通テキストプロパティを継承します。[IPortion.PortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/portionformat/) を通じて部分のフォーマットにアクセスし、[BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/spellcheck/) を設定してプレゼンテーション アプリケーションがその部分のスペルチェックを行うかどうかを制御します。既定値は `false` で、`true` にするとスペルチェックが有効になり、`false` にすると抑制されます。

この設定は個々のテキスト部分に適用されます。同じ段落内の異なる部分は異なる値を使用できます。[BasePortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/languageid/) と `SpellCheck` は補完的な役割を果たします。`LanguageId` は校正言語を識別し、`SpellCheck` はその部分でスペルチェックを許可するかどうかを決定します。

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/proofdisabled/) も校正を制御しますが、[NullableBool](https://reference.aspose.com/slides/ja/net/aspose.slides/nullablebool/) としてより広範な「校正しない」状態を表します。スペルチェック専用の直接的な Boolean スイッチが必要な場合は `SpellCheck` を使用してください。プレゼンテーション の校正なしメタデータ（`NotDefined` 状態を含む）を保持または明示的に制御する必要がある場合は `ProofDisabled` を使用します。両方のプロパティを設定する場合は、値を一貫させてください。`SpellCheck = true` と `ProofDisabled = NullableBool.True` を組み合わせて使用しないでください。

これらのプロパティは、PowerPoint やその他のプレゼンテーション アプリケーションで使用される校正メタデータを構成します。Aspose.Slides はこれらを使用して辞書ベースのスペルチェックを実行したり、誤字リストを返したりしません。

以下の完全な例は、入力プレゼンテーションを作成し、読み込み、同じ段落内の2つの部分に異なるスペルチェック設定と校正言語を割り当て、結果を保存して再度開き、保存された値を検証します。

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

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/joinportionswithsameformatting/) は、同一の書式設定を持つ隣接する部分を結合します。`SpellCheck` のみが異なる場合でも、結合後の部分は最初の部分の `SpellCheck` 値を保持します。部分ごとに異なるスペルチェック設定が必要な場合は、設定を付与する前に `JoinPortionsWithSameFormatting` を呼び出すか、結合後の部分境界を確認して設定を再適用してください。`LanguageId` の値が異なる部分は、校正言語の書式が異なるため、結合されずに別々に残ります。

## **FAQ**

**言語 ID はテキストを翻訳しますか？**

いいえ。[IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/languageid/) はスペルと文法の校正メタデータを保存しますが、テキストの内容は変更しません。テキストは別途翻訳し、翻訳した各部分に適切な言語識別子を設定してください。

**校正言語はフォント、ハイフネーション、改行を制御しますか？**

いいえ。言語識別子は校正用です。テキストの描画とレイアウトは主に利用可能な [fonts](/slides/ja/net/powerpoint-fonts/)、文字体系、テキストフレームの設定に依存します。確実な表示のために、必要なフォントを提供し、[font substitution](/slides/ja/net/font-substitution/) を構成するか、プレゼンテーションに [embed fonts](/slides/ja/net/embedded-font/) を埋め込んでください。

**1つの段落で複数の校正言語を使用できますか？**

はい。各言語を別々の部分に割り当てます。多言語段落の例をご参照ください。

**`DefaultTextLanguage` と `LanguageId` のどちらを使用すべきですか？**

新規作成テキストのデフォルトを設定したい場合は [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/defaulttextlanguage/) を使用します。特定の部分に明示的な校正言語が必要な場合や段落に複数の言語が含まれる場合は [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/languageid/) を使用してください。