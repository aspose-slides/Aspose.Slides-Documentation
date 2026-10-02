---
title: PowerPoint と OpenDocument プレゼンテーションのテキストを .NET で書式設定
linktitle: テキスト書式設定
type: docs
weight: 50
url: /ja/net/text-formatting/
keywords:
- 段落の配置
- テキスト スタイル
- テキスト 背景
- テキスト 透過性
- 文字間隔
- フォント プロパティ
- フォント ファミリ
- テキスト 回転
- 回転角度
- テキスト フレーム
- 行間隔
- オートフィット プロパティ
- テキスト フレーム アンカー
- テキスト タブ設定
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint と OpenDocument のプレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーションのテキストを書式設定する方法を示します。背景色、透過、文字間隔、フォント プロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブ位置、言語設定について取り上げます。

特に記載がない限り、例では [sample.pptx](sample.pptx) を使用します。最初のスライドの最初のシェイプはテキスト ボックスで、最初の段落には以下に示すテキストが含まれています。スライドおよびシェイプのインデックスは 0 から始まります。太字部分を選択する例は、継承された太字書式を含む実効書式を使用します。

![サンプルテキスト](sample_text.png)

リテラル テキストまたは正規表現マッチを検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/net/search-and-replace-text/) を参照してください。

## **テキストの背景色を設定**

段落のデフォルトハイライト色を設定するには [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) を使用し、個々のテキスト部分のハイライト色を設定するには [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) を使用します。

以下の例は、最初の段落のデフォルトとして薄いグレーのハイライトを設定します。個別部分の明示的なハイライト色はこのデフォルトより優先されます。

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

![グレーの段落](gray_paragraph.png)

次のコード例は、**太字フォント** のテキスト部分の背景色を設定する方法を示します。

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

![グレーのテキスト部分](gray_text_portions.png)

## **段落のテキストを配置**

テキスト フレーム内の段落配置を設定するには [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどがあります。

次のコード例は、段落を **中央** に配置する方法を示します。

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

## **行内のフォントを揃える**

行内で異なるフォント サイズのテキスト部分を垂直に揃えるには [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) を使用します。この設定は段落全体に適用され、各行内の揃え方を制御します。

次の自己完結型例は、1 つのスライドに 4 つのラベル付きテキスト ボックスを作成します。各段落は 18、36、54 ポイントの同じテキストを含み、フォント揃えが異なります。Arial を使用し、オートフィットと折り返しを無効にし、テキストフレームを 1 行分だけ大きく保ちます。

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

![ベースライン、上部、中央、下部のフォント揃えの比較 (混在フォントサイズ)](font_alignment.png)

フォント揃えはフォント メトリックに基づくため、個々の文字の可視エッジが正確に一致するとは限りません。例では大文字とディセンダーの両方を含め、ベースラインと下部揃えの違いを示しています。フォントの可用性と置換、使用文字、フォント サイズの違いが結果に影響します。フレームのサイズ、余白、行間、折り返し、オートフィットもレイアウトに影響するため、モードを比較するときは同じフォントとレイアウト設定を使用してください。

この設定は、水平段落揃えを制御する [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) や、シェイプ内でテキスト ブロックを垂直に配置する [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) とは異なります。[IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) による上付き・下付き書式は、段落の行に対してフォント揃えを設定するのではなく、ベースラインに対して個々の部分をシフトさせます。

## **テキストの透過性を設定**

テキストの透過性は [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) に割り当てられた色のアルファ成分で制御します。以下の例では `alpha = 50` は 0〜255 の範囲の ARGB アルファ チャネル値であり、透過率ではありません。

次のコード例は、**段落全体** に透過性を適用する方法を示します。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// テキストに半透明の黒塗りを設定します。
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

結果:

![透過段落](transparent_paragraph.png)

次のコード例は、**太字フォント** のテキスト部分に透過性を適用する方法を示します。

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
        // テキスト部分の透過性を設定します。
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

結果:

![透過テキスト部分](transparent_text_portions.png)

## **テキストの文字間隔を設定**

テキスト ボックス内の文字間隔を拡大または縮小するには [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) を使用します。例では 3 ポイントの間隔を追加しています。負の値は文字間を縮めます。

次の C# コードは、**段落全体** の文字間隔を拡大する方法を示します。

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

次のコード例は、**太字フォント** のテキスト部分の文字間隔を拡大する方法を示します。

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

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides で描画されたテキストが PowerPoint で表示されるテキストよりもわずかに詰まって見えることがあります。これは、PowerPoint が特定フォントのカーニング データを無視するために起こります（フォントに有効なカーニング情報があり、PowerPoint の設定でカーニングが有効になっている場合でも）。

このようなケースで PowerPoint に近い出力にするには、該当フォントを使用するテキスト部分のカーニングを無効にします。実際のフォント サイズより大きい値を [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) に設定します。この例では、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" を前提とし、継承フォントを含む実効フォント名を確認し、Roboto を使用する部分に 100 ポイントの閾値を設定します。これにより、100 ポイント未満のサイズで Robo​to を使用する該当部分のカーニングが無効になります。

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

閾値未満のマッチング テキストに対しては、この設定がカーニングを抑制し、PowerPoint 特有の動作で影響を受けるフォントの視覚的出力を Aspose.Slides と合わせるのに役立ちます。

## **テキスト フォント プロパティを管理**

フォント プロパティは、[IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) を使用して段落レベルで設定するか、[IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) を使用して個々の部分で設定できます。

次の例は、最初の段落のデフォルト フォントを 12 ポイントの Times New Roman に設定し、太字、斜体、点線下線を書式設定します。個々の部分の明示的な書式はこれらのデフォルトより優先されます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// 段落のフォント プロパティを設定します。
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

次の例は、実効書式が太字である部分に対して、13 ポイントの Times New Roman、斜体、点線下線を適用します。

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
        // テキスト部分のフォント プロパティを設定します。
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

## **テキストの回転を設定**

テキストの向きをシェイプ内で事前定義された方式で設定するには [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) を使用します。

次のコード例は、シェイプ内のテキスト向きを [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) に設定し、テキストを **時計回りに 90 度** 回転させます。

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

## **テキスト フレームのカスタム回転を設定**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) を使用して、[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) のカスタム回転角度を設定します。

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

![カスタム テキスト回転](custom_text_rotation.png)

## **段落の行間隔を設定**

Aspose.Slides は [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/)、[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値は行の高さのパーセンテージとして行間隔を指定します。  
* 負の値はポイント単位で行間隔を指定します。

次の例は、最初の段落の行間隔を行の高さの 200%（2 倍行間）に設定します。

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

![段落内の行間隔](line_spacing.png)

## **改行の制御**

段落の改行規則は、狭いテキスト ブロックやラテン文字と東アジア文字が混在するプレゼンテーションで有用です。これらのプロパティは [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) に属し、段落全体に適用されます。

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) はラテン文字の改行規則を制御します。混在テキストの場合、これを変更すると隣接する東アジア文字や句読点の折り返し位置も変わることがあります。  
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) は東アジア文字の改行規則を制御し、行頭・行末の文字に対する制限を含みます。

これらの規則は [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/)（テキスト フレーム内の自動折り返し）を置き換えるものではなく、折り返しが発生したときのレイアウトに影響します。改行文字を挿入するわけではありません。明示的な改行は、利用可能幅に関係なく段落内で新しい行を強制します。

次の自己完結型例は、中文とラテン文字を含む狭いテキスト ブロックを作成し、両方の改行プロパティを明示的に設定して "line_breaking.pptx" として保存します。どちらか一方の規則を試す場合は、もう一方の設定を固定したままプロパティの値を変更してください。例では 24 ポイント Arial と SimSun を使用し、フレーム幅 160 ポイント、水平余白 0 に設定しています。[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) は [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) に設定し、テキストサイズとフレーム寸法を固定しています。

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

## **句読点のぶら下げを制御**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) を使用すると、対象となる句読点がテキスト 行の右端を超えて表示され、次の行に入らないようにできます。段落全体に適用され、ハング インデントとは異なります。

次の自己完結型例は、幅 100 ポイントのテキスト フレームで句読点のぶら下げを有効にし、"hanging_punctuation.pptx" として保存します。24 ポイント Arial と水平余白 0 の条件下で、最後の句点は "sentence" の後に残り、右端を超えて表示されます。比較のためにプロパティを [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) に設定すると、句点が別行に配置されます。折り返しは有効で、オートフィットは無効にして利用可能幅を固定しています。

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

すべての句読点がぶら下げ可能というわけではありません。上記の [フォントとレイアウト条件](#control-line-breaking) も比較に影響します。フォント、利用可能幅、余白、オートフィット設定を変更すると、見た目の違いが消えることがあります。

## **テキスト フレームのオートフィット タイプを設定**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、シェイプを自動的にリサイズするかを制御できます。次の例は、シェイプがテキストに合わせてリサイズするように設定し、結果を "autofit_type.pptx" として保存します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

自動折り返し後の行数を確認したり、テキストやシェイプの幅が結果に与える影響を見るには、[レンダリングされた行のカウント](/slides/ja/net/manage-paragraph/) を参照してください。行数だけではテキストがコンテナをはみ出しているかどうかは判断できません。

## **テキスト フレームのアンカーを設定**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) は、シェイプ内でテキストが垂直方向にどの位置に配置されるか（上部、中央、下部など）を定義します。次の例は、テキストを最初のシェイプの下部に固定し、結果を "text_anchor.pptx" として保存します。

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

段落内のタブ位置を構成するには、[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) と [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) を使用します。次の例は、デフォルトのタブ間隔を 100 ポイントに設定し、30 ポイント位置に左揃えのタブ位置を追加します。これらの設定はタブ文字を含むテキストに影響します。

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

## **校閲言語を設定**

Aspose.Slides は [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) を提供し、テキスト部分の校閲言語を設定できます。校閲言語は PowerPoint のスペルチェックや文法チェックで使用される言語を決定します。

次の例は、最初のスライドの最初のシェイプがテキスト ボックスである "presentation.pptx" を前提とし、最初の段落の内容を "1。" に置き換え、フォントを SimSun に設定し、簡体字中国語 (`zh-CN`) の校閲言語を割り当てます。結果は "proofing_language.pptx" として保存されます。

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

// 校閲言語を簡体字中国語に設定します。
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **デフォルト言語を設定**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) を使用して、プレゼンテーションの読み込みまたは作成時に作成されるテキストのデフォルト言語を定義します。次の例は、デフォルトテキスト言語を米国英語に設定したプレゼンテーションを作成し、テキスト ボックスを追加して最初のテキスト部分の言語コードとして `en-US` を出力します。

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// 新しい矩形シェイプにテキストを追加します。
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// 最初の部分の言語を確認します。
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **デフォルト テキスト スタイルを設定**

プレゼンテーション レベルでデフォルトのテキスト書式設定を適用するには、[IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) を使用します。

次の例は、新規プレゼンテーションの最上位段落のデフォルトとして 14 ポイントの太字フォントを設定し、"default_text_style.pptx" として保存します。テキストはこれらのデフォルトを継承できますが、より具体的な書式設定が上書きします。

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

## **全大文字効果でテキストを抽出**

PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字でもスライド上で大文字で表示されます。Aspose.Slides でそのテキスト部分を取得すると、入力時の文字列がそのまま返されます。表示されたテキストと合わせるには、[TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

この例は、最初のスライドの最初のシェイプがテキスト ボックスである "sample2.pptx" を前提とし、最初の段落の最初の部分に **All Caps** 効果が適用された "Hello, Aspose!" が含まれています。

![全大文字効果](all_caps_effect.png)

次のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

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

テーブルのテキストを変更するには [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) を使用します。セルを列挙し、各セルを [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) で更新し、段落書式は [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) で設定します。

**PowerPoint のスライド上のテキストにグラデーション カラーを適用するには？**

テキストにグラデーション カラーを適用するには [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) を使用します。[IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) を [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透過性を構成します。