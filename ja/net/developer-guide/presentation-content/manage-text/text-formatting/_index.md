---
title: .NET でプレゼンテーションのテキストをフォーマット
linktitle: テキストのフォーマット
type: docs
weight: 50
url: /ja/net/text-formatting/
keywords:
- 段落の配置
- テキストスタイル
- テキストの背景
- テキストの透明度
- 文字間隔
- フォントプロパティ
- フォントファミリー
- テキストの回転
- 回転角度
- テキストフレーム
- 行間
- オートフィット プロパティ
- テキストフレームのアンカー
- テキストのタブ設定
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーション内のテキストをフォーマットおよびスタイル設定します。フォント、色、配置などをカスタマイズできます。"
---
## **概要**

この記事では、Aspose.Slides for .NET を使用して PowerPoint および OpenDocument プレゼンテーションのテキストをフォーマットする方法を示します。背景色、透明度、文字間隔、フォントプロパティ、回転、段落間隔、オートフィット動作、テキストのアンカリング、タブストップ、言語設定について解説します。

以下の例では、1 つのテキスト ボックスが最初のスライドに配置された「sample.pptx」というファイルを使用します。

![サンプルテキスト](sample_text.png)

リテラルテキストや正規表現の一致箇所を検索してハイライトする方法については、[テキストの検索と置換](/slides/ja/net/search-and-replace-text/)をご覧ください。

## **テキストの背景色の設定**

段落全体の既定ハイライト色を設定するには [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/defaultportionformat/) を使用し、個々のテキスト部分のハイライト色を設定するには [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/highlightcolor/) を使用します。

以下のコード例は **段落全体** の背景色を設定する方法を示しています。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 段落全体のハイライトカラーを設定します。
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

結果:

![灰色の段落](gray_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の背景色を設定する方法を示しています。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // テキスト部分のハイライトカラーを設定します。
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

結果:

![灰色のテキスト部分](gray_text_portions.png)

## **テキスト段落の配置**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/alignment/) を使用して、テキスト フレーム内の段落配置を設定します。値は中央揃え、左揃え、右揃え、均等割り付けなどがあります。

以下のコード例は段落を **中央** に揃える方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

テキストの透明度は [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/fillformat/) に割り当てられた色のアルファ成分で制御します。以下の例で使用されている `alpha = 50` は 0〜255 のスケールの ARGB アルファ チャネル値であり、透明度のパーセンテージではありません。

以下のコード例は **段落全体** に透明度を適用する方法を示しています。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // テキストの塗りつぶし色を透明色に設定します。
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

結果:

![透明な段落](transparent_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** に透明度を適用する方法を示しています。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

[IBasePortionFormat.Spacing](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/spacing/) を使用して、テキスト ボックス内の文字間隔を拡大または縮小します。

以下の C# コードは **段落全体** の文字間隔を拡大する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 注: 文字間隔を縮めるには負の値を使用します。
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // 文字間隔を拡大します。

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

結果:

![段落内の文字間隔](character_spacing_in_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** の文字間隔を拡大する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

### **特定フォントのカーニングを無効にする**

場合によっては、Aspose.Slides が描画するテキストが PowerPoint で表示される同じテキストよりもやや詰まって見えることがあります。これは、PowerPoint が特定フォントのカーニング データを無視するためです（フォントに有効なカーニング情報が含まれていても、PowerPoint の設定でカーニングが有効になっていても）。

このようなケースで PowerPoint に近い描画結果を得るには、対象フォントを使用するテキスト部分のカーニングを無効にします。実際のフォントサイズよりはるかに大きい値を [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/kerningminimalsize/) に設定してください。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

この設定により、一致するテキスト部分にカーニングが適用されなくなり、PowerPoint 固有の挙動の影響を受けるフォントの表示を Aspose.Slides と合わせることができます。

## **テキスト フォント プロパティの管理**

フォント プロパティは、[IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/defaultportionformat/) を介して段落レベルで、または個々の部分に対しては [IPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportionformat/) を介して設定できます。

以下のコードは段落全体のフォントとテキスト スタイルを設定します。フォントサイズ、太字、斜体、点線下線、そして Times New Roman フォントが段落内のすべての部分に適用されます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

![段落のフォント プロパティ](font_properties_for_paragraph.png)

以下のコード例は **太字フォントのテキスト部分** に同様のプロパティを適用します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

![テキスト部分のフォント プロパティ](font_properties_for_text_portions.png)

## **テキストの回転の設定**

[ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/textverticaltype/) を使用して、シェイプ内のテキストの事前定義された向きを設定します。

以下のコード例はシェイプ内のテキスト向きを `Vertical270` に設定し、テキストを **時計回りに 90 度** 回転させます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

結果:

![テキストの回転](text_rotation.png)

## **テキスト フレームのカスタム回転の設定**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/rotationangle/) を使用して、[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) のカスタム回転角度を設定します。

以下のコード例はシェイプ内のテキスト フレームを時計回りに 3 度回転させます。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

結果:

![カスタム テキスト回転](custom_text_rotation.png)

## **段落の行間の設定**

Aspose.Slides は [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/spaceafter/)、[IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/spacebefore/)、および [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/spacewithin/) を提供し、段落間隔を制御します。これらのプロパティは次のように使用します。

* 正の値は行高さのパーセンテージとして行間を指定します。
* 負の値はポイント単位で行間を指定します。

以下のコード例は段落内の行間を指定する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **テキスト フレームのオートフィット タイプの設定**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/autofittype/) は、テキストがコンテナの境界を超えたときの動作を決定します。テキストを縮小するか、はみ出すか、またはシェイプを自動的にリサイズするかを制御します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **テキスト フレームのアンカー設定**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/anchoringtype/) は、シェイプ内でテキストが垂直方向に配置される位置（上部、中央、下部など）を定義します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **テキストのタブ設定**

[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/defaulttabsize/) と [IParagraphFormat.Tabs](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/tabs/) を使用して、段落内のタブストップを構成します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides は [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/languageid/) を提供し、テキスト部分の校正言語を設定できます。校正言語は PowerPoint のスペルチェックおよび文法チェックに使用される言語を決定します。

以下のコード例はテキスト部分の校正言語を設定する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **既定言語の設定**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/defaulttextlanguage/) を使用して、プレゼンテーションの読み込みまたは作成時に生成されるテキストの既定言語を定義します。

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // テキスト付きの新しい長方形シェイプを追加します。
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // 最初の部分の言語を確認します。
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **既定テキスト スタイルの設定**

プレゼンテーション レベルで既定のテキスト書式設定を適用するには、[IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/defaulttextstyle/) を使用します。

以下のコード例は新しいプレゼンテーション内のすべてのスライドに対して、サイズ 14 pt の太字フォントを既定テキスト スタイルとして設定する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // トップレベルの段落フォーマットを取得します。
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **全大文字効果でテキストを抽出する**

PowerPoint では **All Caps** フォント効果を適用すると、スライド上のテキストが大文字で表示されますが、元のテキストは小文字で入力されていることがあります。Aspose.Slides でそのテキスト部分を取得すると、入力されたままの文字列が返されます。表示されたテキストと一致させるには、[TextCapType](https://reference.aspose.com/slides/ja/net/aspose.slides/textcaptype/) を確認し、値が `All` の場合は返された文字列を大文字に変換してください。

例として、sample2.pptx の最初のスライドにある次のテキスト ボックスを考えます。

![全大文字効果](all_caps_effect.png)

以下のコード例は **All Caps** 効果が適用されたテキストを抽出する方法を示しています。

```cs
using Aspose.Slides;

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

テーブルのテキストを変更するには、[ITable](https://reference.aspose.com/slides/ja/net/aspose.slides/itable/) を使用します。セルを反復処理し、各セルを [ICell.TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/icell/textframe/) で取得し、段落書式は [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/paragraphformat/) で更新します。

**PowerPoint スライドのテキストにグラデーション 色を適用する方法は？**

テキストにグラデーション 色を適用するには、[IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/fillformat/) を使用します。[IFillFormat.FillType](https://reference.aspose.com/slides/ja/net/aspose.slides/ifillformat/filltype/) を [FillType.Gradient](https://reference.aspose.com/slides/ja/net/aspose.slides/filltype/) に設定し、グラデーション ストップ、方向、透明度を構成してください。