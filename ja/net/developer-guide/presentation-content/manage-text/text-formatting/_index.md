---
title: .NET でプレゼンテーションのテキストをフォーマットする
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/net/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキスト背景
- テキストの透明性
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキスト回転
- 回転角度
- テキストフレーム
- 行間隔
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーションのテキスト書式設定方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブ位置、言語設定について説明します。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初の図形はテキスト ボックスで、最初の段落には以下に示すテキストが含まれています。スライドおよび図形のインデックスは 0 から始まります。太字部分を選択する例では、継承された太字書式を含む有効な書式設定を使用します。

![サンプルテキスト](sample_text.png)

リテラルテキストや正規表現の一致箇所を検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/net/search-and-replace-text/) を参照してください。

## **テキストの背景色の設定**

[IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) を使用して段落のデフォルトハイライト色を設定し、個々のテキスト部分には [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) を使用します。

次の例は、最初の段落のデフォルトとしてライトグレーのハイライトを設定します。個別の部分に対して明示的に設定されたハイライト色はこのデフォルトよりも優先されます。

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

以下のコード例は、**太字フォントのテキスト部分**の背景色を設定する方法を示します。

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

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) を使用してテキスト フレーム内の段落配置を設定します。値は中央、左揃え、右揃え、両端揃えなどがあります。

以下のコード例は、段落を **中央** に配置する方法を示します。

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

## **行内のフォントの配置**

[IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) を使用して、行内の異なるフォントサイズのテキスト部分を垂直方向に揃えます。この設定は段落全体に適用され、各行内の配置を制御します。

以下の自己完結型サンプルは、1 枚のスライドに 4 つのラベル付きテキスト ボックスを作成します。各段落は 18、36、54 ポイントの同じテキストを含み、フォント配置が異なります。Arial を使用し、オートフィットと折り返しを無効にして、テキスト フレームが 1 行分の幅を確保するようにします。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

結果:

![ベースライン、トップ、センター、ボトムのフォント配置（混在フォントサイズ）の比較](font_alignment.png)

フォント配置はフォントメトリクスに基づくため、個々の文字の見た目の端が必ずしも正確に揃うわけではありません。例では大文字とディセンダーの両方を含め、ベースラインとボトム配置の違いを示しています。フォントの利用可否や代替、使用文字、フォントサイズの差が結果に影響します。フレームサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モードを比較する際は同じフォントとレイアウト設定を使用してください。

この設定は、水平段落配置を制御する [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) および図形内でテキスト ブロックを垂直方向に配置する [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) とは異なります。[IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) による上付き・下付き書式は、ベースラインに対して個々の部分を移動させ、段落行のフォント配置を設定するものではありません。

## **テキストの透明度の設定**

テキストの透明度は、[IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) に割り当てられた色のアルファ成分で制御します。下記の例では `alpha = 50` は 0〜255 のスケールの ARGB アルファチャンネル値であり、透明度のパーセンテージではありません。

以下のコード例は、**段落全体** に透明度を適用する方法を示します。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// テキストの半透明の黒塗りつぶしを設定します。
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

結果:

![透明な段落](transparent_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** に透明度を適用する方法を示します。

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

[IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) を使用してテキスト ボックス内の文字間隔を拡大または縮小します。例では 3 ポイントの間隔を追加しています。負の値は文字を縮めます。

以下の C# コードは、**段落全体** の文字間隔を拡大する方法を示します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// Note: Use negative values to compress the character spacing.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 文字間隔を拡大します。

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の文字間隔を拡大する方法を示します。

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
        portion.PortionFormat.Spacing = 3;  // 文字間隔を拡大します。
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効化**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の同じテキストよりも若干詰まって見えることがあります。これは、PowerPoint が特定のフォントに対してカーニング情報を無視するためで、フォントに有効なカーニング情報があり、PowerPoint の設定でカーニングが有効になっていても発生します。

このような場合に PowerPoint に近い表示にするには、対象フォントを使用するテキスト部分のカーニングを無効にできます。[IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) に実際のフォントサイズより大きい値を設定します。この例では、最初のスライドの最初の図形がテキスト ボックスである "presentation.pptx" が必要です。継承されたフォントも含む有効フォント名を確認し、Roboto を使用する部分に 100 ポイントの閾値を設定します。これにより、フォントサイズが 100 ポイント未満の該当部分のカーニングが無効になります。

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

閾値未満の該当テキストに対しては、この設定によりカーニングが無効になり、PowerPoint 固有の動作の影響を受けるフォントで Aspose.Slides の描画を PowerPoint の視覚出力に近づけるのに役立ちます。

## **テキストフォントプロパティの管理**

フォントプロパティは、段落レベルでは [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) を、個々の部分では [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) を使用して設定できます。

次の例は、最初の段落のデフォルトフォントを 12 ポイントの Times New Roman に設定し、太字、イタリック、点線下線を書式設定します。個々の部分の明示的な書式設定はこれらのデフォルトより優先されます。

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

![段落のフォントプロパティ](font_properties_for_paragraph.png)

次の例は、実効書式が太字である部分に対して、13 ポイントの Times New Roman、イタリック書式、点線下線を適用します。

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

![テキスト部分のフォントプロパティ](font_properties_for_text_portions.png)

## **テキスト高さの正規化の制御**

テンプレートのタイポグラフィを再現したり文字高さの差異を調査したりする際は、[IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) を使用します。PowerPoint では、正規化を有効にすると、テキスト部分内で文字の可視高さを均一にするために、個々の文字が垂直方向に伸縮されます。異なるフォント間でテキスト高さが同じになることは保証されません。

プロパティを [NullableBool.True または False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) に設定すると、正規化を明示的に有効または無効にできます。`NullableBool.NotDefined` はローカル設定を未設定のままにし、例えば段落の [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) から値を継承させます。これは `False` を意味しません。解決された Boolean 値を取得するには、[IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) を使用し、[IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) を参照します。

以下の自己完結型例は **Arial** のインストールが必要です。54 ポイントで同じ大文字・小文字・ディセンダー・アクセント文字を含む 2 つのテキスト ブロックを作成します。両方の段落はデフォルトで正規化を有効にしています。上部の部分は明示的に無効化し、下部の部分は継承します。フレームサイズ、余白、段落間隔は同一で、比較が一貫するように折り返しとオートフィットを無効にしています。例では `False: False` と `NotDefined: True` を出力し、"text_height_normalization.pptx" として保存します。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

以下の比較は保存されたプレゼンテーションからエクスポートしたものです。上段は正規化が無効 (`False`) で、下段は有効設定を継承 (`NotDefined` → `True`) しています。この外観を再現するには Arial をインストールしたままにしてください。

![Arial 54ポイントテキスト（上部は正規化無効、下部は正規化有効を継承）](text_height_normalization.png)

正規化は、ポイント単位のフォントサイズを指定する [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) の値を変更せずに文字の高さを変えます。段落の [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) は行間を制御し、テキスト フレームの [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) はテキストやそのコンテナがフィットする方法を制御します。これらの設定は目的が異なり、全体レイアウトに独立して影響します。段落書式設定と継承の詳細については、[段落の管理](/slides/ja/net/manage-paragraph/) を参照してください。

## **取り消し線の適用と除去**

テキスト部分に対して [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) を使用すると、元のテキストを削除せずに修正や取り消し、以前の価格などを表示できます。テキストに1本または2本の線を引く場合は、[TextStrikethroughType.Single または Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) に設定します。

取り消し線を除去するには `TextStrikethroughType.None` を割り当てます。これにより、周囲の書式で取り消し線が指定されていても効果が明示的に無効になります。これに対し、`TextStrikethroughType.NotDefined` はローカル設定を未定義のままにし、例えば段落から継承させます。取り消し線が必ず除去されるわけではありません。結果の書式（継承された値も含む）を取得するには [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) を使用します。

以下の自己完結型例は、3 つの価格比較を作成します。各段落はラベル、旧価格、現在価格の部分に分かれているため、影響を受けるのは旧価格のみです。最初の行では取り消し線を適用してから除去し、他の行は単一および二重取り消し線を保持します。このプロパティを変更しても、テキストやその他の書式（太字の旧価格を含む）は保持されます。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// Apply strikethrough, then explicitly remove it from the first previous price.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

結果（上から順に）：取り消し線なし、単一取り消し線、二重取り消し線。

![取り消し線なし、単一取り消し線、二重取り消し線の過去価格](strikethrough.png)

## **テキスト回転の設定**

[ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) を使用して、シェイプ内のテキスト方向を事前定義されたものに設定します。

以下のコード例は、シェイプ内のテキスト方向を [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) に設定し、テキストを **反時計回りに 90 度** 回転させます。

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

## **縦書きテキストで数字を横並びで表示**

縦書きの日本語ラベルで 2 桁の数字をまとめて表示するには、両方の数字を 1 つのテキスト部分に入れ、その部分に [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) を設定します。例では [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) と 40 ポイントの MS Gothic を両ラベルに使用しています。数値部分に割り当てられる [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) の値だけが異なります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

PowerPoint では、左側のラベル (`True`) は数字が縦向きのまま和 と 年 の間に横並びで表示されます。右側のラベル (`False`) では、数字のペアが時計回りに 90 度回転します。両ラベルの周囲の日本語文字は縦向きのままです。

![左側が縦向き数字、右側が回転した数字の縦書き日付ラベルの PowerPoint 比較](vertical_date.png)

## **テキストフレームのカスタム回転設定**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) を使用して、[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内でテキスト フレームを時計回りに 3 度回転させます。

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

Aspose.Slides は、段落間隔を制御するために [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/)、[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) を提供します。これらのプロパティは次のように使用します：

* 正の値を使用すると、行間を行の高さのパーセンテージで指定します。
* 負の値を使用すると、行間をポイントで指定します。

以下の例は、最初の段落の内部間隔を行の高さの 200%（二倍の行間）に設定します。

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

## **改行制御**

段落の改行ルールは、狭いテキストブロックやラテン文字と東アジア文字が混在するプレゼンテーションで役立ちます。以下のプロパティは [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) に属し、段落全体に適用されます：

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) はラテン文字の改行規則を制御します。混在テキストでは、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) は東アジア文字の改行規則を制御し、行頭・行末の文字に対する制限を含みます。

これらの規則は、テキスト フレーム内で自動折り返しを有効にする [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) の代わりになるものではありません。折り返しが発生したときのレイアウトに影響しますが、改行文字を挿入するわけではありません。明示的な改行は、使用可能幅に関係なく段落内で新しい行を強制します。

以下の自己完結型例は、中国語とラテン文字を含む狭いテキストブロックを作成します。両方の改行プロパティを明示的に設定し、"line_breaking.pptx" として保存します。どちらかの規則を試すには、もう一方の設定はそのままでプロパティ値を変更します。例では 24 ポイントの Arial と SimSun を使用し、フレーム幅 160 ポイント、水平テキストフレーム余白 0 としています。[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) は [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) に設定し、テキストサイズとフレーム寸法が固定されるようにしています。

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) は、対象となる句読点がテキスト行の右端を超えて伸びることを可能にし、次の行に入らせません。段落全体に適用され、ハンギングインデントとは異なります。

以下の自己完結型例は、幅 100 ポイントのテキストフレームで行末句読点を有効にし、"hanging_punctuation.pptx" として保存します。24 ポイントの Arial と水平テキストフレーム余白 0 の状態で、最後の句点は "sentence" の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) に設定すると、句点が別行に配置されます。折り返しを有効にし、オートフィットを無効にして利用可能幅を固定しています。

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

すべての句読点がハングできるわけではありません。上記の [フォントとレイアウト条件](#control-line-breaking) もこの比較に適用されます。フォント、利用可能幅、余白、またはオートフィット設定を変更すると、見た目の違いがなくなることがあります。

## **テキストフレームのオートフィットタイプ設定**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にサイズ変更するかを制御します。以下の例は、シェイプがテキストに合わせてサイズ変更するよう設定し、結果を "autofit_type.pptx" として保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

自動折り返し後の行数をカウントし、テキストまたはシェイプ幅の変化が結果にどう影響するか確認するには、[描画行数のカウント](/slides/ja/net/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかは分かりません。

## **テキストフレームのアンカー設定**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) は、テキストがシェイプ内で垂直方向にどこに配置されるか（上部、中央、下部など）を定義します。以下の例は、最初の図形の下部にテキストをアンカーし、結果を "text_anchor.pptx" として保存します。

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

[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) と [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) を使用して、段落のタブ位置を設定します。以下の例では、デフォルトタブ間隔を 100 ポイントに設定し、30 ポイント位置に左揃えのタブ位置を追加します。これらの設定はタブ文字を含むテキストに影響します。

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

Aspose.Slides は [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) を提供し、テキスト部分の校正言語を設定できます。校正言語は、PowerPoint でのスペルチェックや文法チェックに使用される言語を決定します。

以下の例は、最初のスライドの最初の図形がテキスト ボックスである "presentation.pptx" と、少なくとも 1 つの段落が必要です。最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、校正言語を簡体字中国語 (`zh-CN`) に割り当てます。結果は "proofing_language.pptx" として保存されます。

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

### **言語メタデータのコピー**

テンプレートから多言語テキストをコピーする際は、[IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) と [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) の両方を保持してください。以下の自己完結型例は、ソース部分に米国英語を言語、フランス語を代替言語として作成し、テキストと識別子を新しいプレゼンテーションの部分にコピーします。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
    // ソースに代替言語がない場合、null は宛先の値をクリアします。
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

代替言語なしのソースを試すには、"fr-FR" の割り当てを省略してください。その場合、代替識別子は `null` となり、同じコピー文はデフォルト値を導入せずにその欠如を保持します。たとえ宛先に以前代替言語が割り当てられていたとしてもです。

これらの識別子は言語メタデータとして保存されます。保持しても、PowerPoint がスペルチェックや文法チェックに使用する辞書が決まるわけではありません。

## **デフォルト言語の設定**

プレゼンテーションの読み込みまたは作成時に生成されるテキストのデフォルト言語を定義するには、[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) を使用します。以下の例は、デフォルトテキスト言語を米国英語に設定したプレゼンテーションを作成し、テキスト ボックスを追加して、最初のテキスト部分の言語として `en-US` を出力します。

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// テキスト付きの新しい矩形シェイプを追加します。
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 最初の部分の言語を確認します。
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **デフォルトテキストスタイルの設定**

プレゼンテーション レベルでデフォルトのテキスト書式を適用するには、[IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) を使用します。

以下の例は、新しいプレゼンテーションのトップレベル段落のデフォルトとして 14 ポイントの太字フォントを設定し、"default_text_style.pptx" として保存します。テキストは、より具体的な書式が上書きしない限り、これらのデフォルトを継承できます。

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

## **All-Caps 効果でテキストを抽出**

PowerPoint で **All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上で大文字として表示されます。Aspose.Slides でそのようなテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) を確認し、値が `All` の場合に返された文字列を大文字に変換します。

この例は、最初のスライドの最初の図形がテキスト ボックスである "sample2.pptx" が必要です。最初の段落の最初の部分に All Caps 効果が適用された "Hello, Aspose!" が含まれます（下図参照）。

![All Caps 効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

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

スライド上のテーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) を使用します。セルを走査し、各セルを [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) で更新し、段落書式は [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) で設定します。

**PowerPoint スライドのテキストにグラデーションカラーを適用するにはどうすればよいですか？**

テキストにグラデーションカラーを適用するには、[IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) を使用します。[IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) を [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成します。

関連機能: [スライド内テキストの書式設定](/slides/ja/features/text-formatting/).