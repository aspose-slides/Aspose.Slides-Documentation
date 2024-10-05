---
title: テキストフォーマット
linktitle: テキストフォーマット
type: docs
weight: 50
url: /net/text-formatting/
keywords:
- テキスト強調
- 正規表現
- テキスト段落の整列
- テキストの透明度
- 段落フォントプロパティ
- フォントファミリ
- テキストの回転
- カスタム角度回転
- テキストフレーム
- 行間
- オートフィットプロパティ
- テキストフレームアンカー
- テキストタブ
- デフォルトのテキストスタイル
- C#
- Aspose.Slides for .NET
description: "C#でテキストとテキストフレームプロパティを管理および操作します"
---

## 概要

この記事では、**C#を使ったPowerPointプレゼンテーションのテキストフォーマットの操作方法**について説明します。例えば、テキストの強調表示、正規表現の適用、テキスト段落の整列、テキストの透明度の設定、段落フォントプロパティの変更、フォントファミリの使用、テキストの回転の設定、角度回転のカスタマイズ、テキストフレームの管理、行間の設定、オートフィットプロパティの使用、テキストフレームアンカーの設定、テキストタブの変更などのトピックを扱います。

## **テキストを強調表示する**

新しいHighlightTextメソッドがITextFrameインターフェイスとTextFrameクラスに追加されました。

これにより、PowerPoint 2019のテキストハイライトカラーツールに似た、テキストサンプルを使用して背景色でテキストの一部を強調表示できます。

1. 入力ファイルを持つ[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
   - 入力ファイルはPPT、PPTX、ODPなどが可能です。
2. [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)コレクションを使って、そのスライドにアクセスします。
3. [Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/)コレクションを使用して、形状に[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)としてアクセスします。
4. [TextFrame.Highlight()](https://reference.aspose.com/slides/net/aspose.slides/textframe/highlighttext/#highlighttext)メソッドを使用してテキストを強調表示します。
5. 希望の出力形式（PPT、PPTXまたはODPなど）でプレゼンテーションを保存します。

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("title", Color.LightBlue); // 'important'のすべての単語を強調表示します
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightText("to", Color.Violet, new TextHighlightingOptions()
{
    WholeWordsOnly = true
}); // 'the'のすべての別々の出現を強調表示します
presentation.Save("SomePresentation-out2.pptx", SaveFormat.Pptx);
```

{{% alert color="primary" %}} 

Asposeは、シンプルな[無料オンラインPowerPoint編集サービス](https://products.aspose.app/slides/editor)を提供します。

{{% /alert %}} 

## **正規表現を使用してテキストを強調表示する**

新しいHighlightRegexメソッドがITextFrameインターフェイスとTextFrameクラスに追加されました。

これにより、正規表現を使用して背景色でテキストの一部を強調表示できます。これは、PowerPoint 2019のテキストハイライトカラーツールに似ています。

以下のコードスニペットは、この機能を使用する方法を示しています：

```c#
Presentation presentation = new Presentation("SomePresentation.pptx");
TextHighlightingOptions options = new TextHighlightingOptions();
((AutoShape)presentation.Slides[0].Shapes[0]).TextFrame.HighlightRegex(@"\b[^\s]{5,}\b", Color.Blue, options); // 10文字以上のすべての単語を強調表示します
presentation.Save("SomePresentation-out.pptx", SaveFormat.Pptx);
```

## **テキストの背景色を設定する**

Aspose.Slidesを使用すると、テキストの背景に好みの色を指定できます。

以下のC#コードは、全体のテキストの背景色を設定する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Black");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Red ");
    
    var portion3 = new Portion("Black");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    foreach (IPortion portion in autoShape.TextFrame.Paragraphs[0].Portions)
    {
        portion.PortionFormat.HighlightColor.Color = Color.Blue;
    }

    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

このC#コードは、テキストの一部の背景色を設定する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    IAutoShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    autoShape.TextFrame.Paragraphs.Clear();

    Paragraph para = new Paragraph();

    var portion1 = new Portion("Black");
    portion1.PortionFormat.FontBold = NullableBool.True;
    
    var portion2 = new Portion(" Red ");
    
    var portion3 = new Portion("Black");
    portion3.PortionFormat.FontBold = NullableBool.True;
    
    para.Portions.Add(portion1);
    para.Portions.Add(portion2);
    para.Portions.Add(portion3);
    autoShape.TextFrame.Paragraphs.Add(para);
    
    pres.Save("text.pptx", SaveFormat.Pptx);
}

using (Presentation pres = new Presentation("text.pptx"))
{
    var autoShape = (IAutoShape)pres.Slides[0].Shapes[0];

    IPortion redPortion = autoShape.TextFrame.Paragraphs[0].Portions
        .First(p => p.Text.Contains("Red"));

    redPortion.PortionFormat.HighlightColor.Color = Color.Red;
    
    pres.Save("text-red.pptx", SaveFormat.Pptx);
}
```

## **テキスト段落を整列する**

テキストフォーマットは、さまざまな文書やプレゼンテーションを作成する際の重要な要素の一つです。Aspose.Slides for .NETはスライドにテキストを追加することをサポートしていますが、このトピックでは、スライド内のテキスト段落の整列をどのように制御するかを見ていきます。以下の手順に従って、Aspose.Slides for .NETを使用してテキスト段落を整列してください：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダー形状にアクセスし、それらをAutoShapeにキャストします。
4. AutoShapeによって公開されたTextFrameから（整列が必要な）段落を取得します。
5. 段落を整列します。段落は右、左、中央、均等に整列できます。
6. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記のステップの実装は以下に示されています。

```c#
// PPTXファイルを表すPresentationオブジェクトを作成する
using (Presentation pres = new Presentation("ParagraphsAlignment.pptx"))
{

    // 最初のスライドにアクセスする
    ISlide slide = pres.Slides[0];

    // スライド内の最初と2番目のプレースホルダーにアクセスし、AutoShapeとしてキャストする
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // 両方のプレースホルダーのテキストを変更する
    tf1.Text = "Asposeによるセンターアライン";
    tf2.Text = "Asposeによるセンターアライン";

    // プレースホルダーの最初の段落を取得する
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // テキスト段落を中央に整列させる
    para1.ParagraphFormat.Alignment = TextAlignment.Center;
    para2.ParagraphFormat.Alignment = TextAlignment.Center;

    // PPTXファイルとしてプレゼンテーションを書き込む
    pres.Save("Centeralign_out.pptx", SaveFormat.Pptx);
}
```

## **テキストの透明度を設定する**

この記事では、Aspose.Slides for .NETを使用してテキスト形状に透明度プロパティを設定する方法を示します。テキストに透明度を設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドの参照を取得します。
3. 影の色を設定します。
4. プレゼンテーションをPPTXファイルとして書き込みます。

上記のステップの実装は以下に示されています。

```c#
using (Presentation pres = new Presentation("transparency.pptx"))
{
    IAutoShape shape = (IAutoShape)pres.Slides[0].Shapes[0];
    IEffectFormat effects = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.EffectFormat;

    IOuterShadow outerShadowEffect = effects.OuterShadowEffect;

    Color shadowColor = outerShadowEffect.ShadowColor.Color;
    Console.WriteLine($"{shadowColor} - 透明度は：{((float)shadowColor.A / byte.MaxValue) * 100}");

    // 透明度をゼロパーセントに設定する
    outerShadowEffect.ShadowColor.Color = Color.FromArgb(255, shadowColor);

    pres.Save("transparency-2.pptx", SaveFormat.Pptx);
}
```

## **テキストの文字間隔を設定する**

Aspose.Slidesを使用すると、テキストボックス内の文字間のスペースを設定できます。これにより、文字の間隔を広げたり縮めたりすることで、行やブロックの視覚的な密度を調整できます。

以下のC#コードは、1行のテキストの間隔を広げ、別の行の間隔を縮める方法を示しています：

```c#
var presentation = new Presentation("in.pptx");

var textBox1 = (IAutoShape)presentation.Slides[0].Shapes[0];
var textBox2 = (IAutoShape)presentation.Slides[0].Shapes[1];

textBox1.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = 20; // 拡張
textBox2.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.Spacing = -2; // 縮小

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **段落のフォントプロパティを管理する**

プレゼンテーションには通常、テキストと画像の両方が含まれています。テキストは、特定のセクションや単語を強調表示するためにさまざまにフォーマットできます。また、企業スタイルに適合させることも可能です。テキストフォーマットは、プレゼンテーションコンテンツの外観と感触を変えるのに役立ちます。この記事では、Aspose.Slides for .NETを使用してスライドのテキスト段落のフォントプロパティを構成する方法を示します。Aspose.Slides for .NETを使用して段落のフォントプロパティを管理するには：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライド内のプレースホルダー形状にアクセスし、それらをAutoShapeにキャストします。
4. AutoShapeによって公開されたTextFrameから段落を取得します。
5. 段落を均等に整列させます。
6. 段落のテキストポーションにアクセスします。
7. FontDataを使ってフォントを定義し、テキストポーションのフォントを設定します。
   1. フォントを太字に設定します。
   1. フォントを斜体に設定します。
8. ポーションオブジェクトによって公開されたFillFormatを使用してフォントの色を設定します。
9. 修正されたプレゼンテーションを[PPTX](https://docs.fileformat.com/presentation/pptx/)ファイルとして書き込みます。

以下に、上記のステップの実装を示します。これは、装飾のないプレゼンテーションを取り、スライドの1つでフォントをフォーマットします。

```c#
// PPTXファイルを表すPresentationオブジェクトを作成する
using (Presentation pres = new Presentation("FontProperties.pptx"))
{

    // スライドの位置を使用してアクセスする
    ISlide slide = pres.Slides[0];

    // スライドの最初と2番目のプレースホルダーにアクセスし、AutoShapeとしてキャストする
    ITextFrame tf1 = ((IAutoShape)slide.Shapes[0]).TextFrame;
    ITextFrame tf2 = ((IAutoShape)slide.Shapes[1]).TextFrame;

    // 最初の段落にアクセスする
    IParagraph para1 = tf1.Paragraphs[0];
    IParagraph para2 = tf2.Paragraphs[0];

    // 最初のポーションにアクセスする
    IPortion port1 = para1.Portions[0];
    IPortion port2 = para2.Portions[0];

    // 新しいフォントを定義する
    FontData fd1 = new FontData("Elephant");
    FontData fd2 = new FontData("Castellar");

    // ポーションに新しいフォントを割り当てる
    port1.PortionFormat.LatinFont = fd1;
    port2.PortionFormat.LatinFont = fd2;

    // フォントを太字に設定する
    port1.PortionFormat.FontBold = NullableBool.True;
    port2.PortionFormat.FontBold = NullableBool.True;

    // フォントを斜体に設定する
    port1.PortionFormat.FontItalic = NullableBool.True;
    port2.PortionFormat.FontItalic = NullableBool.True;

    // フォント色を設定する
    port1.PortionFormat.FillFormat.FillType = FillType.Solid;
    port1.PortionFormat.FillFormat.SolidFillColor.Color = Color.Purple;
    port2.PortionFormat.FillFormat.FillType = FillType.Solid;
    port2.PortionFormat.FillFormat.SolidFillColor.Color = Color.Peru;

    // PPTXをディスクに書き込む
    pres.Save("WelcomeFont_out.pptx", SaveFormat.Pptx);
}
```

## **テキストのフォントファミリを管理する**

ポーションは、段落内の同様の書式スタイルを持つテキストを保持するために使用されます。この記事では、Aspose.Slides for .NETを使用してテキストボックスを作成し、特定のフォント、さまざまなフォントファミリのプロパティを定義する方法を示します。テキストボックスを作成し、テキストのフォントプロパティを設定するには：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを使用してスライドの参照を取得します。
3. スライドに長方形のAutoShapeを追加します。
4. AutoShapeに関連付けられた塗りつぶしスタイルを削除します。
5. AutoShapeのTextFrameにアクセスします。
6. TextFrameにテキストを追加します。
7. TextFrameに関連付けられたPortionオブジェクトにアクセスします。
8. Portionのために使用するフォントを定義します。
9. 太字、斜体、下線、色、高さなどの他のフォントプロパティを設定します。
10. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

上記のステップの実装は以下に示されています。

```c#
// プレゼンテーションをインスタンス化する
using (Presentation presentation = new Presentation())
{
   
    // 最初のスライドを取得する
    ISlide sld = presentation.Slides[0];

    // 長方形のタイプのAutoShapeを追加する
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);

    // AutoShapeに関連付けられた塗りつぶしスタイルを削除する
    ashp.FillFormat.FillType = FillType.NoFill;

    // AutoShapeに関連付けられたTextFrameにアクセスする
    ITextFrame tf = ashp.TextFrame;
    tf.Text = "Aspose TextBox";

    // TextFrameに関連付けられたポーションにアクセスする
    IPortion port = tf.Paragraphs[0].Portions[0];

    // ポーションのフォントを設定する
    port.PortionFormat.LatinFont = new FontData("Times New Roman");

    // フォントの太字プロパティを設定する
    port.PortionFormat.FontBold = NullableBool.True;

    // フォントの斜体プロパティを設定する
    port.PortionFormat.FontItalic = NullableBool.True;

    // フォントの下線プロパティを設定する
    port.PortionFormat.FontUnderline = TextUnderlineType.Single;

    // フォントの高さを設定する
    port.PortionFormat.FontHeight = 25;

    // フォントの色を設定する
    port.PortionFormat.FillFormat.FillType = FillType.Solid;
    port.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // PPTXをディスクに書き込む 
    presentation.Save("SetTextFontProperties_out.pptx", SaveFormat.Pptx);
}
```

## **フォントサイズを設定する**

Aspose.Slidesを使用すると、段落内の既存のテキストや後で追加されるテキストに好みのフォントサイズを選択できます。

以下のC#コードは、段落に含まれるテキストのフォントサイズを設定する方法を示しています。

```c#
var presentation = new Presentation("example.pptx");

// 最初の形状を取得する
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape autoShape)
{
    // 最初の段落を取得する
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // 段落内のすべてのテキストポーションに対してデフォルトのフォントサイズを20ptに設定する。 
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;

    // 段落内の現在のテキストポーションに対してフォントサイズを20ptに設定する。 
    foreach (var portion in paragraph.Portions)
    {
        portion.PortionFormat.FontHeight = 20;
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **テキストを回転させる**

Aspose.Slides for .NETでは、開発者がテキストを回転させることができます。テキストは、水平、垂直、270度垂直、WordArt垂直、東アジア垂直、モンゴル垂直、または右から左へのWordArt垂直として表示できます。テキストフレームのテキストを回転させるには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意の形状を追加します。
4. TextFrameにアクセスします。
5. テキストを回転させます。
6. ファイルをディスクに保存します。

```c#
// Presentationクラスのインスタンスを作成する
Presentation presentation = new Presentation();

// 最初のスライドを取得する 
ISlide slide = presentation.Slides[0];

// 長方形のタイプのAutoShapeを追加する
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// 長方形にTextFrameを追加する
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// テキストフレームにアクセスする
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

// テキストフレームの段落オブジェクトを作成する
IParagraph para = txtFrame.Paragraphs[0];

// 段落のポーションオブジェクトを作成する
IPortion portion = para.Portions[0];
portion.Text = "速い茶色の狐が怠け者の犬を飛び越える。速い茶色の狐が怠け者の犬を飛び越える。";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// プレゼンテーションを保存する
presentation.Save("RotateText_out.pptx", SaveFormat.Pptx);
```

## **テキストフレームのカスタム回転角度を設定する**

Aspose.Slides for .NETでは、テキストフレームのカスタム回転角度を設定することがサポートされました。このトピックでは、Aspose.SlidesのRotationAngleプロパティを設定する方法を例を用いて見ていきます。新しいプロパティRotationAngleがIChartTextBlockFormatおよびITextFrameFormatインターフェイスに追加され、テキストフレームのカスタム回転角度を設定できるようになりました。RotationAngleプロパティを設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. スライドにチャートを追加します。
3. RotationAngleプロパティを設定します。
4. プレゼンテーションをPPTXファイルとして書き込みます。

以下の例では、RotationAngleプロパティを設定しています。

```c#
// Presentationクラスのインスタンスを作成する
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("カスタムタイトル").TextFrameFormat.RotationAngle = -30;

// プレゼンテーションを保存する
presentation.Save("textframe-rotation_out.pptx", SaveFormat.Pptx);
```

## **段落の行間を設定する**

Aspose.Slidesは、段落の行間を管理するためのプロパティ（[SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spaceafter)、[SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacebefore)、および[SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/spacewithin)）を提供します。これらのプロパティは以下のように使用されます：

* 段落の行間をパーセントで指定するには、正の値を使用します。 
* 段落の行間をポイントで指定するには、負の値を使用します。

例えば、段落に16ptの行間を適用するには、`SpaceBefore`プロパティを-16に設定します。

特定の段落の行間を指定するには、以下の手順を実行します：

1. テキストが含まれるAutoShapeを持つプレゼンテーションを読み込みます。
2. インデックスを通じてスライドの参照を取得します。
3. TextFrameにアクセスします。
4. 段落にアクセスします。
5. 段落のプロパティを設定します。
6. プレゼンテーションを保存します。

以下のC#コードは、段落の行間を指定する方法を示しています：

```c#
// Presentationクラスのインスタンスを作成する
Presentation presentation = new Presentation("Fonts.pptx");

// インデックスを使用してスライドの参照を取得します
ISlide sld = presentation.Slides[0];

// TextFrameにアクセスします
ITextFrame tf1 = ((IAutoShape)sld.Shapes[0]).TextFrame;

// 段落にアクセスします
IParagraph para1 = tf1.Paragraphs[0];

// 段落のプロパティを設定します
para1.ParagraphFormat.SpaceWithin = 80;
para1.ParagraphFormat.SpaceBefore = 40;
para1.ParagraphFormat.SpaceAfter = 40;
// プレゼンテーションを保存します
presentation.Save("LineSpacing_out.pptx", SaveFormat.Pptx);
```

## **テキストフレームのAutofitTypeプロパティを設定する**

このトピックでは、テキストフレームのさまざまなフォーマットプロパティを探ります。この記事では、テキストフレームのAutofitTypeプロパティの設定、テキストのアンカー、プレゼンテーション内のテキストの回転について説明します。Aspose.Slides for .NETは、任意のテキストフレームのAutofitTypeプロパティを設定できるようにします。AutofitTypeはNormalまたはShapeに設定できます。Normalに設定すると、形状はそのままで、テキストが調整され形状を変更しません。一方、AutofitTypeがShapeに設定されている場合、形状は変更され、必要なテキストのみが収まります。テキストフレームのAutofitTypeプロパティを設定するには、以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意の形状を追加します。
4. TextFrameにアクセスします。
5. TextFrameのAutofitTypeを設定します。
6. ファイルをディスクに保存します。

```c#
// Presentationクラスのインスタンスを作成する
Presentation presentation = new Presentation();

// 最初のスライドにアクセスする 
ISlide slide = presentation.Slides[0];

// 長方形のタイプのAutoShapeを追加する
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// 長方形にTextFrameを追加する
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// テキストフレームにアクセスする
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// テキストフレームの段落オブジェクトを作成する
IParagraph para = txtFrame.Paragraphs[0];

// 段落のポーションオブジェクトを作成する
IPortion portion = para.Portions[0];
portion.Text = "速い茶色の狐が怠け者の犬を飛び越える。速い茶色の狐が怠け者の犬を飛び越える。";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// プレゼンテーションを保存する
presentation.Save("formatText_out.pptx", SaveFormat.Pptx); 
```

## **テキストフレームのアンカーを設定する**

Aspose.Slides for .NETは、任意のTextFrameのアンカーを設定できます。TextAnchorTypeは、テキストが形状内のどこに配置されるかを指定します。TextAnchorTypeはTop、Center、Bottom、Justified、またはDistributedに設定できます。任意のTextFrameのアンカーを設定するには、以下の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. 最初のスライドにアクセスします。
3. スライドに任意の形状を追加します。
4. TextFrameにアクセスします。
5. TextAnchorTypeをTextFrameに設定します。
6. ファイルをディスクに保存します。

```c#
// Presentationクラスのインスタンスを作成する
Presentation presentation = new Presentation();

// 最初のスライドを取得する 
ISlide slide = presentation.Slides[0];

// 長方形のタイプのAutoShapeを追加する
IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 350, 350);

// 長方形にTextFrameを追加する
ashp.AddTextFrame(" ");
ashp.FillFormat.FillType = FillType.NoFill;

// テキストフレームにアクセスする
ITextFrame txtFrame = ashp.TextFrame;
txtFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

// テキストフレームの段落オブジェクトを作成する
IParagraph para = txtFrame.Paragraphs[0];

// 段落のポーションオブジェクトを作成する
IPortion portion = para.Portions[0];
portion.Text = "速い茶色の狐が怠け者の犬を飛び越える。速い茶色の狐が怠け者の犬を飛び越える。";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// プレゼンテーションを保存する
presentation.Save("AnchorText_out.pptx", SaveFormat.Pptx);
```

## **テキストタブを設定する**
- EffectiveTabs.ExplicitTabCount（ここでは2）は、Tabs.Countに等しいプロパティです。
- EffectiveTabsコレクションには、すべてのタブ（Tabsコレクションからとデフォルトタブ）が含まれます。
- EffectiveTabs.DefaultTabSize（294）は、デフォルトタブ間の距離を示します（この例では3と4）。
- EffectiveTabs.GetTabByIndex(index)でindex=0は最初の明示的タブ（位置=731）を返し、index=1は2番目のタブ（位置=1241）を返します。index=2で次のタブを取得しようとすると最初のデフォルトタブ（位置=1470）が返されます。
- EffectiveTabs.GetTabAfterPosition(pos)は、テキストの後の次のタブを取得するために使用されます。例えば、テキストが「Helloworld!」とあるとき、「world!」を描画する開始位置を知る必要があります。最初に、「Hello」の長さをピクセル単位で計算し、その値でGetTabAfterPositionを呼び出します。そうすると、「world!」を描画するための次のタブ位置が得られます。

## **校正言語を設定する**

Aspose.Slidesは、PowerPointドキュメントの校正言語を設定できるように、[PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)クラスが提供する[LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/)プロパティを提供します。校正言語は、PowerPointのスペルや文法がチェックされる言語です。

以下のC#コードは、PowerPointの校正言語を設定する方法を示しています：

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // 校正言語のIDを設定します
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **デフォルトの言語を設定する**

以下のC#コードは、PowerPointプレゼンテーション全体のデフォルト言語を設定する方法を示しています：

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // テキスト付きの新しい長方形の形状を追加します
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "新しいテキスト";
    
    // 最初のポーションの言語を確認します
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```

## **デフォルトのテキストスタイルを設定する**

プレゼンテーション内のすべてのテキスト要素に同じデフォルトのテキストフォーマットを一度に適用する必要がある場合、[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/)インターフェイスからの`DefaultTextStyle`プロパティを使用して、好みのフォーマッティングを設定できます。以下のコード例は、新しいプレゼンテーション内のすべてのスライドのテキストにデフォルトの太字フォント（14pt）を設定する方法を示しています。

```c#
using (Presentation presentation = new Presentation())
{
    // トップレベルの段落フォーマットを取得します。
    IParagraphFormat paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("DefaultTextStyle.pptx", SaveFormat.Pptx);
}
```