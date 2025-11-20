---
title: C# で PowerPoint テキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/net/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- 自動調整プロパティ
- テキストフレームアンカー
- テキストタブ設定
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションでテキストをフォーマットおよびスタイル設定する方法を学びます。フォント、色、配置などを強力な C# コード例でカスタマイズできます。"
---

## **概要**

この記事では、Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーション内のテキストの管理と書式設定方法を紹介します。フォントの選択、サイズ、色、ハイライト、背景色、間隔、配置などのテキスト書式設定機能の適用方法を学びます。さらに、テキストフレーム、段落、書式設定、およびカスタム回転や自動調整動作などの高度なレイアウトオプションの操作方法もカバーします。

プログラムでプレゼンテーションを生成する場合でも、既存のコンテンツをカスタマイズする場合でも、これらの例はスライドの可読性を向上させ、プロフェッショナルな外観のテキストレイアウトを作成するのに役立ちます。

以下の例では、最初のスライドに単一のテキストボックスが含まれる「sample.pptx」ファイルを使用し、テキストは次のとおりです。

![サンプルテキスト](sample_text.png)

## **テキストのハイライト**

[ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) メソッドを使用すると、マッチするテキストサンプルに基づいてテキストの一部を背景色でハイライトできます。

このメソッドを使用する手順は次のとおりです。

1. 入力ファイル (PPT、PPTX、ODP など) を指定して [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) コレクションから目的のスライドにアクセスします。
1. [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) コレクションから対象のシェイプにアクセスし、[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) にキャストします。
1. サンプルテキストとカラーを指定して [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) メソッドで目的のテキストをハイライトします。
1. 任意の出力形式 (PPT、PPTX、ODP など) でプレゼンテーションを保存します。

以下のコード例は文字列 **"try"** と単語 **"to"** のすべての出現箇所をハイライトします。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // 最初のスライドから最初のシェイプを取得します。
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // シェイプ内の単語 "try" をハイライトします。
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // シェイプ内の単語 "to" をハイライトします。
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```


結果:

![ハイライトされたテキスト](highlighted_text.png)

{{% alert color="primary" %}} 

Aspose はシンプルな、[FREE Online PowerPoint Editor](https://products.aspose.app/slides/editor) を提供しています。

{{% /alert %}} 

## **正規表現を使用したテキストのハイライト**

Aspose.Slides for .NET では、正規表現を使用して PowerPoint スライド内の特定のテキスト部分を検索およびハイライトできます。この機能は、キーワード、パターン、データ駆動型コンテンツを動的に強調表示したい場合に特に便利です。[ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) メソッドを使用すると、正規表現で一致したテキスト部分を背景色でハイライトできます。

以下のコード例は **7 文字以上** の単語すべてをハイライトします。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // 7文字以上の単語すべてをハイライトします。
    shape.TextFrame.HighlightRegex(@"\b[^\s]{7,}\b", Color.Yellow, null);

    presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```


結果:

![正規表現でハイライトされたテキスト](highlighted_text_using_regex.png)

## **テキストの背景色の設定**

Aspose.Slides for .NET では、PowerPoint スライド内の段落全体または個々のテキスト部分に背景色を適用できます。この機能は、特定の単語やフレーズを強調したり、重要なメッセージに注意を引いたり、プレゼンテーションの視覚的魅力を高めたい場合に便利です。

以下のコード例は **段落全体** の背景色を設定する方法を示しています。 
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 段落全体のハイライト色を設定します。
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```


結果:

![グレーの段落](gray_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の背景色を設定する方法を示しています。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // テキスト部分のハイライト色を設定します。
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```


結果:

![グレーのテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキストの配置は、可読性と視覚的魅力の両方に影響するスライド書式設定の重要な要素です。Aspose.Slides for .NET では、テキストフレーム内の段落配置を正確に制御でき、センタリング、左揃え、右揃え、両端揃えなど、一貫した表示を実現できます。このセクションでは、PowerPoint プレゼンテーションでテキスト配置を適用およびカスタマイズする方法を説明します。

以下のコード例は段落を **中央** に揃える方法を示しています。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 段落の配置を中央に設定します。
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```


結果:

![揃えられた段落](aligned_paragraph.png)

## **テキストの透明度の設定**

テキストの透明度を調整すると、微妙な視覚効果を作成し、スライドの美観を向上させることができます。Aspose.Slides for .NET は、段落やテキスト部分の透明度レベルを設定する機能を提供し、テキストを背景とブレンドしたり、特定の要素を強調したりするのが簡単になります。このセクションでは、プレゼンテーションのテキストに透明度設定を適用する方法を示します。

以下のコード例は **段落全体** に透明度を適用する方法を示しています。
```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // テキストの塗りつぶし色を透過色に設定します。
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```


結果:

![透明な段落](transparent_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** に透明度を適用する方法を示しています。
```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // テキスト部分の透明度を設定します。
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```


結果:

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔の設定**

Aspose.Slides では、テキストボックス内の文字間隔を設定できます。これにより、文字間のスペースを拡大または縮小して、行やブロックの視覚的密度を調整できます。

以下の C# コードは **段落全体** の文字間隔を拡大する方法を示しています。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 注：文字間隔を縮めるには負の値を使用します。
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 文字間隔を拡大します。

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の文字間隔を拡大する方法を示しています。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 注: 文字間隔を縮めるには負の値を使用します。
            portion.PortionFormat.Spacing = 3;  // 文字間隔を拡大します。
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```


結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

## **テキストのフォントプロパティの管理**

Aspose.Slides for .NET では、段落レベルと個々のテキスト部分の両方でフォント設定を細かく調整でき、視覚的な一貫性を保ち、プレゼンテーションのデザイン要件を満たすことができます。フォントスタイル、サイズ、その他の書式オプションを段落全体に定義でき、テキストの外観をより細かく制御できます。このセクションでは、スライド内のテキスト段落のフォントプロパティを管理する方法を示します。

以下のコードは段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、イタリック、点線下線、Times New Roman フォントを段落内のすべての部分に適用します。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 段落のフォントプロパティを設定します。
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```


結果:

![段落のフォントプロパティ](font_properties_for_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** に同様のプロパティを適用します。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // テキスト部分のフォントプロパティを設定します。
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```


結果:

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキストの回転の設定**

テキストを回転させることで、スライドのレイアウトを強化し、特定のコンテンツを強調できます。Aspose.Slides for .NET を使用すると、シェイプ内のテキストに簡単に回転を適用でき、デザインに合わせて角度を調整できます。このセクションでは、目的の視覚効果を得るためのテキスト回転の設定と制御方法を示します。

以下のコード例はシェイプ内のテキスト方向を `Vertical270` に設定し、テキストを **90 度反時計回り** に回転させます。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```


結果:

![テキストの回転](text_rotation.png)

## **テキストフレームのカスタム回転の設定**

`TextFrame` にカスタム回転角度を設定すると、正確な角度でテキストを配置でき、より創造的で柔軟なスライドデザインが可能になります。Aspose.Slides for .NET はテキストフレームの回転をフルコントロールでき、他のスライド要素とテキストを整列させやすくします。このセクションでは、`TextFrame` に特定の回転角度を適用する手順を説明します。

以下のコード例はシェイプ内でテキストフレームを **時計回りに 3 度** 回転させます。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```


結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間の設定**

Aspose.Slides は [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) クラスの `SpaceAfter`、`SpaceBefore`、`SpaceWithin` プロパティを提供し、段落の行間を管理できます。これらのプロパティは次のように使用します。

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間をポイント単位で指定します。

以下のコード例は段落内の行間を指定する方法を示しています。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```


結果:

![段落内の行間](line_spacing.png)

## **テキストフレームの Autofit タイプの設定**

AutofitType プロパティは、テキストがコンテナの境界を超えたときの動作を決定します。Aspose.Slides for .NET では、テキストを縮小して合わせるか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。このセクションでは、`TextFrame` の `AutofitType` を設定してシェイプ内のテキストレイアウトを効果的に管理する方法を示します。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **テキストフレームのアンカーの設定**

アンカーはテキストをシェイプ内で垂直方向に配置する方法を定義します。Aspose.Slides for .NET を使用すると、`TextFrame` のアンカータイプを設定してテキストをシェイプの上部、中央、下部に配置できます。このセクションでは、テキストの垂直配置を調整するアンカー設定の方法を示します。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **テキストのタブ設定**

タブ設定は、コンテンツ要素間に一貫したスペースを追加して、テキストを整理されたレイアウトにするのに役立ちます。Aspose.Slides for .NET は、テキスト段落内にカスタムタブストップを設定する機能をサポートし、テキスト位置の正確な制御が可能です。このセクションでは、整列と書式設定を向上させるためのテキストタブ設定方法を示します。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```


結果:

![段落タブ](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) クラスの `LanguageId` プロパティを提供し、PowerPoint ドキュメントの校正言語を設定できます。校正言語は PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

以下のコード例はテキスト部分の校正言語を設定する方法を示しています。
```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // 校正言語の ID を設定します。
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```


## **既定言語の設定**

テキストの既定言語を指定すると、PowerPoint で正しいスペルチェック、ハイフネーション、音声読み上げが行われます。Aspose.Slides for .NET は、テキスト部分または段落レベルで言語を設定できます。このセクションでは、プレゼンテーションテキストの既定言語を定義する方法を示します。
```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // テキスト付きの新しい矩形シェイプを追加します。
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // 最初の部分の言語を確認します。
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```


## **既定テキストスタイルの設定**

プレゼンテーション内のすべてのテキスト要素に同一の既定テキスト書式を一括で適用したい場合は、[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) インターフェイスの `DefaultTextStyle` プロパティを使用して、好みの書式を定義できます。

以下のコード例は新規プレゼンテーションのすべてのスライドのテキストに、サイズ 14 ポイントの太字フォントを既定として設定する方法を示しています。
```cs
using (var presentation = new Presentation())
{
    // 最上位レベルの段落フォーマットを取得します。
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```


## **すべて大文字効果でテキストを抽出する**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上でテキストが大文字で表示されますが、実際のテキストは元の小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。対処方法として、[TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) が `All` を示す場合は、取得した文字列を大文字に変換して、スライド上に表示されている内容と一致させます。

以下の図は sample2.pptx ファイルの最初のスライドにあるテキストボックスを示しています。

![すべて大文字効果](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示しています。
```cs
using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```


出力:
```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```


## **FAQ**

**スライド上のテーブルのテキストを変更するには？**

テーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを使用します。テーブル内のすべてのセルを反復処理し、各セルの `TextFrame` と `ParagraphFormat` プロパティにアクセスしてテキストを変更できます。

**PowerPoint スライドのテキストにグラデーションカラーを適用するには？**

テキストにグラデーションカラーを適用するには、[PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) の `FillFormat` プロパティを使用します。`FillFormat` を `Gradient` に設定し、開始色と終了色、方向、透明度などのプロパティを定義してテキストにグラデーション効果を作成します。