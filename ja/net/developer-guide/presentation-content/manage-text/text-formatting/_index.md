---
title: ".NET でプレゼンテーションテキストをフォーマット"
linktitle: "テキスト書式設定"
type: docs
weight: 50
url: /ja/net/text-formatting/
keywords:
- テキストのハイライト
- 正規表現
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキストの回転
- 回転角度
- テキストフレーム
- 行間隔
- AutoFit プロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint および OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---

## **概要**

この記事では、Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを管理および書式設定する方法を紹介します。フォントの選択、サイズ、色、ハイライト、背景色、間隔、配置などのテキスト書式設定機能の適用方法を学びます。また、テキストフレーム、段落、書式設定、カスタム回転や自動調整動作などの高度なレイアウトオプションの使用方法も取り上げます。

プログラムからプレゼンテーションを生成する場合でも、既存のコンテンツをカスタマイズする場合でも、これらのサンプルはスライドを明確でプロフェッショナルに見せ、可読性を向上させるテキストレイアウトの作成に役立ちます。

以下の例では、最初のスライドに単一のテキストボックスが含まれる「sample.pptx」ファイルを使用します。

![サンプルテキスト](sample_text.png)

## **テキストのハイライト**

[ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) メソッドを使用すると、マッチするテキストサンプルに基づいてテキストの一部分を背景色でハイライトできます。

このメソッドを使用する手順は次のとおりです。

1. 入力ファイル（PPT、PPTX、ODP など）で [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスをインスタンス化します。
1. [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) コレクションから目的のスライドにアクセスします。
1. [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) コレクションから対象のシェイプを取得し、[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) にキャストします。
1. サンプルテキストとカラーを指定して [ITextFrame.HighlightText](https://reference.aspose.com/slides/net/aspose.slides/itextframe/highlighttext/) メソッドで目的のテキストをハイライトします。
1. 任意の出力形式（例: PPT、PPTX、ODP）でプレゼンテーションを保存します。

以下のコード例は、文字列 **"try"** のすべての出現と完全単語 **"to"** をハイライトします。
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

{{% alert color="primary"%}} 
Aspose はシンプルな[無料オンライン PowerPoint エディター](https://products.aspose.app/slides/editor) を提供しています。
{{% /alert %}} 

## **正規表現を使用したテキストのハイライト**

Aspose.Slides for .NET では、正規表現を使用して PowerPoint スライド内の特定のテキスト部分を検索およびハイライトできます。この機能は、キーワード、パターン、またはデータ駆動型コンテンツを動的に強調表示したい場合に特に便利です。[ITextFrame.HighlightRegex](https://docs.aspose.com/slides/net/text-formatting/) メソッドを使用すると、正規表現で一致したテキスト部分を背景色でハイライトできます。

以下のコード例は、**7 文字以上** の単語すべてをハイライトします。
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

## **テキストの背景色を設定する**

Aspose.Slides for .NET は、PowerPoint スライド内の段落全体または個々のテキスト部分に背景色を適用できます。この機能は、特定の単語やフレーズを強調したり、重要メッセージに注意を引いたり、プレゼンテーションの視覚的魅力を高めたりする際に便利です。

以下のコード例は、**段落全体** の背景色を設定する方法を示しています。 
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

以下のコード例は、**太字フォントのテキスト部分** の背景色を設定する方法を示しています。
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

テキストの配置は、スライドの可読性と視覚的魅力に影響する重要な要素です。Aspose.Slides for .NET では、テキストフレーム内の段落配置を正確に制御でき、中央、左揃え、右揃え、両端揃えのいずれでも一貫した表示が可能です。このセクションでは、PowerPoint プレゼンテーションでのテキスト配置の適用とカスタマイズ方法を説明します。

以下のコード例は、段落を **中央揃え** にする方法を示しています。
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

![配置された段落](aligned_paragraph.png)

## **テキストの透明度を設定する**

テキストの透明度を調整すると、微妙な視覚効果を作り出し、スライドの美観を向上させることができます。Aspose.Slides for .NET は、段落やテキスト部分の透明度レベルを設定でき、背景とテキストを自然にブレンドしたり、特定の要素を目立たせたりするのが簡単です。このセクションでは、プレゼンテーションのテキストに透明度設定を適用する方法を示します。

以下のコード例は、**段落全体** に透明度を適用する方法を示しています。
```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // テキストの塗りつぶし色を透明に設定します。
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```


結果:

![透明な段落](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** に透明度を適用する方法を示しています。
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

## **テキストの文字間隔を設定する**

Aspose.Slides は、テキストボックス内の文字間隔を設定できます。これにより、文字間のスペースを拡大または縮小して、行またはブロック全体の視覚的密度を調整できます。

以下の C# コードは、**段落全体** の文字間隔を拡大する方法を示しています。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 注: 文字間隔を圧縮するには負の値を使用します。
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 文字間隔を拡張します。

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```


結果:

![段落の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の文字間隔を拡大する方法を示しています。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // 注: 文字間隔を圧縮するには負の値を使用します。
            portion.PortionFormat.Spacing = 3;  // 文字間隔を拡張します。
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```


結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

## **テキストフォントプロパティの管理**

Aspose.Slides for .NET は、段落レベルと個々のテキスト部分の両方でフォント設定を細かく調整でき、視覚的一貫性とプレゼンテーションデザイン要件を満たすことができます。フォントスタイル、サイズ、その他の書式オプションを段落全体に適用でき、テキストの外観をより自由にコントロールできます。このセクションでは、スライド内のテキスト段落のフォントプロパティを管理する方法を示します。

以下のコードは、段落全体にフォントサイズ、太字、斜体、点線下線、Times New Roman フォントを適用する例です。
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

以下のコード例は、**太字フォントのテキスト部分** に同様のプロパティを適用する方法を示しています。
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

## **テキストの回転を設定する**

テキストを回転させることでスライドのレイアウトを強化し、特定のコンテンツを強調できます。Aspose.Slides for .NET を使用すれば、シェイプ内のテキストに回転を簡単に適用でき、デザインに合わせて角度を調整できます。このセクションでは、目的の視覚効果を得るためのテキスト回転の設定と制御方法を示します。

以下のコード例は、シェイプ内のテキスト方向を `Vertical270` に設定し、**90 度反時計回り** に回転させます。
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

## **テキストフレームのカスタム回転を設定する**

`TextFrame` にカスタム回転角度を設定すると、テキストを正確な角度で配置でき、より創造的で柔軟なスライドデザインが可能になります。Aspose.Slides for .NET はテキストフレームの回転を完全に制御でき、他のスライド要素とテキストを整列させやすくします。このセクションでは、`TextFrame` に特定の回転角度を適用する手順を案内します。

以下のコード例は、シェイプ内のテキストフレームを時計回りに 3 度回転させます。
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

## **段落の行間隔を設定する**

Aspose.Slides は、[ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) クラスの `SpaceAfter`、`SpaceBefore`、`SpaceWithin` プロパティを提供し、段落の行間隔を管理できます。これらのプロパティの使用方法は次のとおりです。

* 正の値を使用すると、行高さのパーセンテージとして行間隔を指定します。
* 負の値を使用すると、ポイント単位で行間隔を指定します。

以下のコード例は、段落内の行間隔を指定する方法を示しています。
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

![段落内の行間隔](line_spacing.png)

## **テキストフレームの AutoFit タイプを設定する**

`AutofitType` プロパティは、テキストがコンテナの境界を超えたときの動作を決定します。Aspose.Slides for .NET では、テキストを縮小してフィットさせるか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。このセクションでは、シェイプ内のテキストレイアウトを効果的に管理するために `TextFrame` の `AutofitType` を設定する方法を示します。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```


## **テキストフレームのアンカーを設定する**

アンカーは、シェイプ内でテキストが垂直方向に配置される方法を定義します。Aspose.Slides for .NET を使用すると、`TextFrame` のアンカータイプを設定して、テキストをシェイプの上部、中央、下部に揃えることができます。このセクションでは、テキストコンテンツの垂直配置を調整するアンカー設定の方法を示します。
```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```


## **テキストのタブ設定を行う**

タブは、コンテンツ要素間に一貫した間隔を追加して、テキストを整然としたレイアウトに整理するのに役立ちます。Aspose.Slides for .NET は、テキスト段落内にカスタムタブストップを設定でき、テキストの位置を正確に制御できます。このセクションでは、整列と書式設定を改善するためのテキストタブ設定方法を示します。
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

## **校正言語を設定する**

Aspose.Slides は、[PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) クラスの `LanguageId` プロパティを提供し、PowerPoint 文書の校正言語を設定できます。校正言語は、PowerPoint のスペルチェックや文法チェックに使用される言語を決定します。

以下のコード例は、テキスト部分の校正言語を設定する方法を示しています。
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


## **デフォルト言語を設定する**

テキストのデフォルト言語を指定すると、PowerPoint での正しいスペルチェック、ハイフン分割、音声読み上げが保証されます。Aspose.Slides for .NET では、テキスト部分または段落レベルで言語を設定できます。このセクションでは、プレゼンテーションテキストのデフォルト言語を定義する方法を示します。
```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // テキスト付きの新しい矩形シェイプを追加します。
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // 最初のテキスト部分の言語を確認します。
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```


## **デフォルトテキストスタイルを設定する**

プレゼンテーション全体のすべてのテキスト要素に同じデフォルト書式を一括で適用したい場合は、[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/) インターフェイスの `DefaultTextStyle` プロパティを使用して、好みの書式を定義できます。

以下のコード例は、新しいプレゼンテーションのすべてのスライドに対して、サイズ 14pt の太字フォントをデフォルトとして設定する方法を示しています。
```cs
using (var presentation = new Presentation())
{
    // トップレベルの段落書式を取得します。
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```


## **全角効果付きテキストの抽出**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、元のテキストは小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。これを処理するには、[TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) を確認し、`All` が返された場合は文字列を大文字に変換して、出力がスライド上の表示と一致するようにします。

サンプル2.pptx の最初のスライドに次のテキストボックスがあるとします。

![All Caps 効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示しています。
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

**スライド上のテーブルのテキストを変更する方法は？**

テーブル上のテキストを変更するには、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) オブジェクトを使用します。テーブル内のすべてのセルを反復処理し、各セルの `TextFrame` と `ParagraphFormat` プロパティにアクセスしてテキストを変更できます。

**PowerPoint スライドのテキストにグラデーション色を適用する方法は？**

テキストにグラデーション色を適用するには、[PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) の `FillFormat` プロパティを使用します。`FillFormat` を `Gradient` に設定し、開始色と終了色、方向、透明度などのプロパティを定義してテキストにグラデーション効果を作成します。