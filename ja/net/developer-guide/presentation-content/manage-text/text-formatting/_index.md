---
title: .NET でプレゼンテーションテキストをフォーマット
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/net/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリ
- テキスト回転
- 回転角度
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、カラー、配置などをカスタマイズできます。
---
## **概要**

この記事では、Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーション内のテキストの書式設定方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィットの動作、テキストのアンカリング、タブストップ、言語設定について解説します。

特に指定がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキスト ボックスで、最初の段落に以下のテキストが含まれています。スライドおよびシェイプのインデックスは 0 ベースです。太字部分を選択する例は、継承された太字書式設定を含む有効な書式設定を使用します。

![サンプルテキスト](sample_text.png)

リテラルテキストや正規表現の一致箇所を検索・ハイライトする方法については、[テキストの検索と置換](/slides/ja/net/search-and-replace-text/) を参照してください。

## **テキストの背景色の設定**

段落の既定のハイライト色を設定するには [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/defaultportionformat/) を使用し、個々のテキスト部分のハイライト色を設定するには [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/highlightcolor/) を使用します。

以下の例は、最初の段落の既定ハイライトとして薄い灰色を設定します。個々の部分で明示的に指定したハイライト色は、この既定より優先されます。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 段落全体のハイライト色を設定します。
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

結果:

![灰色の段落](gray_paragraph.png)

次のコード例は **太字フォントのテキスト部分** の背景色を設定する方法を示します。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
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
```

結果:

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキスト フレーム内の段落配置を設定するには [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/alignment/) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどが指定できます。

以下のコード例は段落を **中央** に配置する方法を示します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 段落の配置を中央に設定します。
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

結果:

![配置された段落](aligned_paragraph.png)

## **テキストの透明度の設定**

テキストの透明度は [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/fillformat/) に割り当てた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 のスケールでの ARGB アルファ値であり、透明度のパーセンテージではありません。

次のコード例は **段落全体** に透明度を適用する方法を示します。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// テキストに半透明の黒塗りつぶしを設定します。
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

結果:

![透明な段落](transparent_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** に透明度を適用する方法を示します。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
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
```

結果:

![透明なテキスト部分](transparent_text_portions.png)

## **テキストの文字間隔の設定**

テキスト ボックス内の文字間隔を拡大または縮小するには [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/spacing/) を使用します。以下の例は 3 ポイントの間隔を追加します。負の値を指定すると文字が縮まります。

次の C# コードは **段落全体** の文字間隔を拡大する方法を示します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 注: 文字間隔を縮めるには負の値を使用します。
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 文字間隔を拡張します。

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の文字間隔を拡大する方法を示します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // 注: 文字間隔を縮めるには負の値を使用します。
        portion.PortionFormat.Spacing = 3;  // 文字間隔を拡張します。
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニング無効化**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の表示と比べてやや詰まって見えることがあります。これは PowerPoint が特定フォントのカーニング情報を無視するためです（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても）。

このようなケースでは、影響を受けるフォントを使用するテキスト部分のカーニングを無効化できます。`[IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/kerningminimalsize/)` に実際のフォントサイズより大きい値を設定します。この例は、最初のスライドの最初のシェイプがテキスト ボックスである「presentation.pptx」を使用します。効果的なフォント名（継承フォントを含む）をチェックし、Roboto を使用する部分に対して 100 ポイントを閾値として設定します。これにより、100 ポイント未満のフォントサイズの該当部分のカーニングが無効化されます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

閾値以下の該当テキストに対して、この設定はカーニングを防止し、PowerPoint 固有の動作の影響を受けるフォントの表示結果を Aspose.Slides のレンダリングとより一致させるのに役立ちます。

## **テキスト フォント プロパティの管理**

フォント プロパティは、段落レベルでは [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/defaultportionformat/) を介して、個々の部分では [IPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/) を介して設定できます。

次の例は、最初の段落の既定フォントを 12 ポイントの Times New Roman に設定し、太字、斜体、点線下線を適用します。個々の部分での明示的な書式設定は、これらの既定よりも優先されます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 段落のフォントプロパティを設定します。
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

結果:

![段落のフォント プロパティ](font_properties_for_paragraph.png)

次の例は、効果的な書式が太字である部分に対して 13 ポイントの Times New Roman、斜体、点線下線を適用します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
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
```

結果:

![テキスト部分のフォント プロパティ](font_properties_for_text_portions.png)

## **テキストの回転設定**

シェイプ内のテキストの向きを事前定義されたものに設定するには [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/textverticaltype/) を使用します。

次のコード例は、シェイプ内のテキスト向きを [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ja/net/aspose.slides/textverticaltype/) に設定し、テキストを **反時計回りに 90 度** 回転させます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

結果:

![テキストの回転](text_rotation.png)

## **テキスト フレームのカスタム回転設定**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/rotationangle/) を使用して、[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) のカスタム回転角度を設定できます。

次のコード例は、シェイプ内のテキスト フレームを時計回りに 3 度回転させます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

結果:

![カスタムテキスト回転](custom_text_rotation.png)

## **段落の行間設定**

Aspose.Slides は [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/spacebefore/)、[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/spacewithin/) を提供し、段落の行間を制御します。使用例は次のとおりです。

* 正の値は行の高さのパーセンテージとして行間を指定します。
* 負の値はポイント単位で行間を指定します。

次の例は、最初の段落の行間を行高さの 200%（二倍）に設定します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

結果:

![段落内の行間](line_spacing.png)

## **改行の制御**

段落の改行規則は、狭いテキスト領域やラテン文字と東アジア文字が混在するプレゼンテーションで便利です。これらのプロパティは [IParagraphFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/) に属し、段落全体に適用されます。

- [LatinLineBreak](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/latinlinebreak/) はラテン文字の改行規則を制御します。混在テキストでは、隣接する東アジア文字や句読点の折り返し位置にも影響します。
- [EastAsianLineBreak](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/eastasianlinebreak/) は東アジア文字の改行規則を制御し、行頭・行末の文字制限などを含みます。

これらの規則は [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/wraptext/) の代替ではなく、テキスト フレーム内で自動折り返しが有効になる際のレイアウトに影響します。行ブレーク文字を挿入するわけではありません。明示的な改行は、利用可能な幅に関係なく段落内に新しい行を強制します。

次のセルフコンテインド例は、中国語とラテン文字を含む狭いテキスト ブロックを作成し、両方の改行プロパティを明示的に設定して「line_breaking.pptx」として保存します。どちらか一方の規則を試すには、もう一方を固定したままそのプロパティの値を変更してください。例では 24 ポイントの Arial と SimSun、フレーム幅 160 ポイント、水平余白 0 を使用します。[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/autofittype/) は [TextAutofitType.None](https://reference.aspose.com/slides/ja/net/aspose.slides/textautofittype/) に設定し、テキスト サイズとフレーム寸法を固定しています。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **行末句読点の制御**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/hangingpunctuation/) を使用すると、対象となる句読点がテキスト行の右端をはみ出して表示され、次の行を占有しません。段落全体に適用され、ハンギング インデントとは別の機能です。

次のセルフコンテインド例は、幅 100 ポイントのテキスト フレームでハンギング句読点を有効にし、「hanging_punctuation.pptx」として保存します。24 ポイントの Arial と水平余白 0 の設定で、最後の句点は「sentence」の後に残り、右端をはみ出します。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/ja/net/aspose.slides/nullablebool/) に設定すると、句点が別行に表示されます。折り返しは有効、オートフィットは無効にして幅を固定しています。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

すべての句読点がハンギングできるわけではありません。上記の [フォントとレイアウトの条件](#conditions-and-limitations) も同様に適用されます。フォント、利用可能幅、余白、オートフィット設定を変更すると、視覚的な違いがなくなることがあります。

## **テキスト フレームのオートフィット タイプの設定**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/autofittype/) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小、オーバーフロー、またはシェイプを自動的にリサイズするかを制御できます。次の例はシェイプをテキストに合わせてリサイズし、結果を「autofit_type.pptx」として保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

自動折り返し後の行数やテキスト／シェイプ幅の変化を確認したい場合は、[レンダリングされた行数のカウント](/slides/ja/net/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかどうかは判断できません。

## **テキスト フレームのアンカー設定**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/anchoringtype/) は、シェイプ内でテキストを縦方向に配置する方法（上部、中央、下部など）を定義します。次の例は最初のシェイプのテキストを下部に固定し、結果を「text_anchor.pptx」として保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **テキストのタブ設定**

段落内のタブストップは、[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/defaulttabsize/) と [IParagraphFormat.Tabs](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/tabs/) で構成できます。次の例はデフォルトタブ幅を 100 ポイントに設定し、30 ポイント位置に左揃えタブストップを追加します。これらの設定はタブ文字を含むテキストに影響します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

結果:

![段落のタブ](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/languageid/) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint でのスペルチェックおよび文法チェックに使用される言語です。

次の例は「presentation.pptx」（最初のスライドの最初のシェイプがテキスト ボックスで、少なくとも1つの段落がある）を使用します。最初の段落の内容を「1。」に置き換え、フォントを SimSun に設定し、校正言語を簡体字中国語 (`zh-CN`) に割り当てます。結果は「proofing_language.pptx」として保存されます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// 校正言語を簡体字中国語に設定します。
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **既定言語の設定**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/defaulttextlanguage/) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストの既定言語を定義できます。次の例は既定テキスト言語を米国英語に設定したプレゼンテーションを作成し、テキスト ボックスを追加して最初のテキスト部分の言語コード `en-US` を出力します。

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// 新しい矩形シェイプをテキスト付きで追加します。
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 最初の部分の言語を確認します。
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **既定テキスト スタイルの設定**

プレゼンテーション全体の既定テキスト書式を適用するには [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/defaulttextstyle/) を使用します。

次の例は新しいプレゼンテーションのトップレベル段落の既定フォントを 14 ポイントの太字に設定し、結果を「default_text_style.pptx」として保存します。テキストは、より具体的な書式設定が上書きしない限り、これらの既定を継承できます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// トップレベルの段落書式を取得します。
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **全角文字効果（All Caps）でテキストを抽出**

PowerPoint では、**All Caps** フォント効果を適用すると、スライド上では大文字で表示されますが、実際の文字列は元の小文字のままです。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/net/aspose.slides/textcaptype/) を確認し、値が `All` の場合は取得文字列を大文字に変換します。

この例は「sample2.pptx」（最初のスライドの最初のシェイプがテキスト ボックス）を使用します。最初の段落の最初の部分に **All Caps** 効果が適用された「Hello, Aspose!」が含まれています（下図参照）。

![All Caps 効果](all_caps_effect.png)

次のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示します。

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

出力:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブルのテキストを変更するにはどうすればよいですか？**

テーブルのテキストを変更するには [ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) を使用します。セルを走査し、各セルを [ICell.TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/textframe/) で更新し、段落書式は [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/paragraphformat/) を通じて設定します。

**PowerPoint スライド上のテキストにグラデーションカラーを適用するにはどうすればよいですか？**

グラデーションカラーを適用するには [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/fillformat/) を使用します。[IFillFormat.FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformat/filltype/) を [FillType.Gradient](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。