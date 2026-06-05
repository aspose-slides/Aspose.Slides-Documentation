---
title: ".NET でプレゼンテーションテキストをフォーマットする"
linktitle: "テキスト書式設定"
type: docs
weight: 50
url: /ja/net/text-formatting/
keywords:
- "テキストのハイライト"
- "正規表現"
- "段落の配置"
- "テキストスタイル"
- "テキストの背景"
- "テキストの透明度"
- "文字間隔"
- "フォントプロパティ"
- "フォントファミリー"
- "テキスト回転"
- "回転角度"
- "テキストフレーム"
- "行間"
- "オートフィットプロパティ"
- "テキストフレームアンカー"
- "テキストタブ設定"
- "デフォルト言語"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

このドキュメントでは、Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。ハイライト、背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定について説明します。

以下の例では、最初のスライドに単一のテキストボックスがあり、次のテキストが含まれる "sample.pptx" というファイルを使用します。

![サンプルテキスト](sample_text.png)

## **テキストのハイライト**

テキストフレーム内で特定のサンプルに一致するテキストをハイライトする必要がある場合は、[ITextFrame.HighlightText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlighttext/) メソッドを使用します。このメソッドは一致したテキスト片にハイライト色を適用し、[TextSearchOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/textsearchoptions/) と組み合わせて検索方法を制御できます。例えば、完全一致単語のみを対象にするなどです。

以下のコード例は、文字列 **"try"** のすべての出現箇所をハイライトし、続いて単語全体 **"to"** のみをハイライトします。

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

## **正規表現を使用したテキストのハイライト**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/highlightregex/) メソッドは、正規表現で見つかったテキストの一致部分をハイライトします。.NET では、この API は [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) で提供されています。

以下のコード例は、**7 文字以上** を含むすべての単語をハイライトします。

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // 7 文字以上の単語すべてをハイライトします。
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

結果:

![正規表現を使用したハイライトテキスト](highlighted_text_using_regex.png)

## **テキストの背景色の設定**

段落のデフォルトハイライト色を設定するには [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/defaultportionformat/) を使用し、個々のテキスト部分には [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/highlightcolor/) を使用します。

以下のコード例は、**段落全体** の背景色を設定する方法を示します。

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

![グレイ段落](gray_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の背景色を設定する方法を示します。

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

![グレイテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

テキストフレーム内の段落配置を設定するには [IParagraphFormat.Alignment](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/alignment/) を使用します。値は中央揃え、左揃え、右揃え、両端揃えなどが可能です。

以下のコード例は、段落を **中央** に揃える方法を示します。

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

テキストの透明度は、[IPortionFormat.FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/fillformat/) に割り当てられた色のアルファ成分で制御します。以下の例では、`alpha = 50` は 0〜255 のスケールの ARGB アルファチャンネル値であり、透明度のパーセンテージではありません。

以下のコード例は、**段落全体** に透明度を適用する方法を示します。

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

以下のコード例は、**太字フォントのテキスト部分** に透明度を適用する方法を示します。

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

テキストボックス内の文字間隔を拡大または縮小するには、[IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/spacing/) を使用します。

以下の C# コードは、**段落全体** の文字間隔を拡大する方法を示します。

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 文字間隔を拡張します。

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

結果:

![段落の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は、**太字フォントのテキスト部分** の文字間隔を拡大する方法を示します。

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
            portion.PortionFormat.Spacing = 3;  // 文字間隔を拡張します。
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

結果:

![テキスト部分の文字間隔](character_spacing_in_text_portions.png)

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides がレンダリングしたテキストが PowerPoint の同じテキストよりもやや狭く見えることがあります。これは、PowerPoint が特定のフォントのカーニングデータを無視するためで、フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっている場合でも起こります。

このようなケースでレンダリング結果を PowerPoint に近づけるには、影響を受けるフォントを使用するテキスト部分のカーニングを無効にできます。[IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/kerningminimalsize/) を実際のフォントサイズよりはるかに大きい値に設定します。

```cs
using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

この設定により、該当するテキスト部分へのカーニング適用が防止され、PowerPoint 固有の動作で影響を受けるフォントの視覚的出力を Aspose.Slides のレンダリングと合わせるのに役立ちます。

## **テキストフォントプロパティの管理**

フォントプロパティは、段落レベルでは [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/defaultportionformat/) を、個々の部分では [IPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/) を通じて設定できます。

以下のコードは、段落全体のフォントとテキストスタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントを段落内のすべての部分に適用します。

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

以下のコード例は、**太字フォントのテキスト部分** に同様のプロパティを適用します。

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

## **テキストの回転設定**

シェイプ内で事前定義されたテキスト方向を設定するには、[ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/textverticaltype/) を使用します。

以下のコード例は、シェイプ内のテキスト方向を `Vertical270` に設定し、テキストを **反時計回りに 90 度** 回転させます。

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

## **テキストフレームのカスタム回転設定**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/rotationangle/) を使用して、[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) のカスタム回転角度を設定します。

以下のコード例は、シェイプ内でテキストフレームを時計回りに 3 度回転させます。

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

## **段落の行間設定**

Aspose.Slides は、段落間隔を制御するために [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/spacebefore/)、[IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/spacewithin/) を提供します。これらのプロパティは次のように使用します。

* 正の値を使用して、行間を行の高さのパーセンテージで指定します。
* 負の値を使用して、行間をポイント単位で指定します。

以下のコード例は、段落内の行間を指定する方法を示します。

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

## **テキストフレームのオートフィットタイプ設定**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/autofittype/) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストが縮小、はみ出し、またはシェイプを自動的にリサイズするかを制御するために使用します。

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **テキストフレームのアンカー設定**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/anchoringtype/) は、シェイプ内でテキストが垂直方向にどの位置に配置されるか（上部、中央、下部など）を定義します。

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **テキストのタブ設定**

段落内のタブストップを設定するには、[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/defaulttabsize/) と [IParagraphFormat.Tabs](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/tabs/) を使用します。

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

![段落のタブ](paragraph_tabs.png)

## **校正言語の設定**

Aspose.Slides は、テキスト部分の校正言語を設定できる [IPortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/languageid/) を提供します。校正言語は、PowerPoint でのスペルチェックと文法チェックに使用される言語を決定します。

以下のコード例は、テキスト部分の校正言語を設定する方法を示します。

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

    // 校正言語の Id を設定します。
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **デフォルト言語の設定**

プレゼンテーションの読み込みまたは作成時に生成されるテキストのデフォルト言語を定義するには、[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/defaulttextlanguage/) を使用します。

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // テキスト付きの新しい長方形シェイプを追加します。
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // 最初のテキスト部分の言語を確認します。
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **デフォルトテキストスタイルの設定**

プレゼンテーションレベルでデフォルトのテキスト書式設定を適用するには、[IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/defaulttextstyle/) を使用します。

以下のコード例は、新しいプレゼンテーションのすべてのスライドのテキストに対して、デフォルトで太字フォント、サイズ 14 pt を設定する方法を示します。

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

## **All-Caps 効果でテキストを抽出する**

PowerPoint では、**All Caps** フォント効果を適用すると、元が小文字で入力されていてもスライド上でテキストが大文字で表示されます。Aspose.Slides でそのテキスト部分を取得すると、ライブラリは入力されたままのテキストを返します。表示されているテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/net/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換します。

例として、sample2.pptx ファイルの最初のスライドに次のテキストボックスがあるとします。

![All Caps 効果](all_caps_effect.png)

以下のコード例は、**All Caps** 効果が適用されたテキストを抽出する方法を示します。

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

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**スライド上のテーブルのテキストを変更する方法は？**

スライド上のテーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) を使用します。セルを反復処理し、各セルを [ICell.TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/textframe/) で更新し、段落書式は [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/paragraphformat/) を通じて設定します。

**PowerPoint スライドのテキストにグラデーションカラーを適用する方法は？**

テキストにグラデーションカラーを適用するには、[IPortionFormat.FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/fillformat/) を使用します。[IFillFormat.FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformat/filltype/) を [FillType.Gradient](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) に設定し、グラデーションストップ、方向、透明度を構成します。