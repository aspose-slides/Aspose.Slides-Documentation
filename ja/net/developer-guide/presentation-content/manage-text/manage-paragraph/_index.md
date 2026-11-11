---
title: .NET で PowerPoint のテキスト段落を管理する
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- テキストの追加
- 段落の追加
- テキストの管理
- 段落の管理
- 箇条書きの管理
- 段落インデント
- ハンギングインデント
- 段落箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTML のインポート
- テキストから HTML へ
- 段落から HTML へ
- 段落から画像へ
- テキストから画像へ
- 段落のエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for .NET はテキストをテキストフレーム、段落、ポーションの階層として表します:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) はシェイプ内のテキスト コンテナを表し、段落コレクションへのアクセスを提供します。
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) はテキストフレーム内の段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) は段落内のテキスト ランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

このため、段落は複数のポーションを使用して、フォント、色、サイズ、その他の書式設定が異なるテキストを含めることができます。

## **段落の作成と書式設定**

シェイプのテキストフレーム内に段落を作成し、ポーションを使用して個々のテキスト ランの書式設定を行います。このセクションでは、各段落内で複数のポーションを組み合わせ、異なる色、フォント サイズ、スタイルを適用する方法を示します。

### **複数のポーションを使用した段落の作成**

次の C# の例は、3 つの段落を作成し、各段落の [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/) コレクションに 3 つのテキスト ランを含めます。既定の段落と空のポーションを再利用し、残りの段落とポーションを追加します。書式設定は [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/) を通じて適用されます。各段落の最初のポーションは赤、太字、15 ポイント、2 番目は青、斜体、18 ポイントです。3 番目のポーションは既定の書式設定を保持します:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **箇条書きと番号付きリストの作成**

シンボル、番号、またはカスタム画像を使用して段落テキストをリストに整理します。このセクションの例では、箇条書きの書式設定、階層リスト、およびカスタム開始番号をカバーします。

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けにより、関連項目をスキャンしやすくなります。Aspose.Slides では、リスト設定は [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) を通じて定義されます。

この C# の例は、同じテキストフレームにシンボル箇条書きと番号付き項目を追加します。[IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) で箇条書きの種類を選択し、[IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) でシンボルを指定し、[IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) で番号付けスタイルを選択します。両方の項目は黒い箇条書きを使用し、高さは 100 パーセント、段落インデントは 25 ポイントです:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **画像箇条書きの使用**

画像箇条書きを使用すると、シンボルや番号の代わりにカスタム画像を使用できます。

この C# の例は、プレゼンテーションの画像コレクションに [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) として画像を追加し、段落箇条書きとして使用します。[IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) を画像箇条書きに設定し、画像は [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/) で割り当てます。[IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) は 100 パーセントに設定され、段落テキストに対する箇条書きのサイズが決まります:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **階層リストの作成**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) を設定して、リストの異なるレベルに段落を配置します。最上位レベルの深さは `0` です。

この C# の例は、4 つの段落に対して `0` から `3` までの [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) 値を割り当て、1 つのテキストフレーム内に階層を作成します。各段落はシンボル箇条書きを使用し、[IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) は丸い箇条書きとハイフンを交互に使用して隣接レベルを区別します:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **番号付きリスト項目をカスタム値から開始**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) を使用して、番号付き段落の最初に表示される番号を設定します。

この C# の例は、3 つの段落に対して番号付けを使用するように [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) を設定し、[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) の値をそれぞれ 2、3、7 に割り当てます。開始値は段落ごとに個別に構成され、表示される番号がスキップされます:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **段落のレイアウトと終了プロパティの制御**

段落の余白とインデントを調整して、最初の行と折り返し行の位置を制御します。また、表示テキストのポーションとは別に段落の終了マークを書式設定できます。

### **最初の行のインデントを設定**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) プロパティを使用して、段落の最初の行のインデントを制御します。このプロパティは段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右にシフトし、残りの行は段落本文に揃ったままです。

全体の段落を移動したい場合は [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) を使用します。最初の行だけを移動したい場合は [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) を使用します。

次の例は、3 つの段落に同じ [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) 20 ポイントと、[IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) をそれぞれ 0、20、40 ポイント設定します。最初の行は徐々に大きなオフセットで開始し、折り返し行は同じ左余白を保持します:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

結果:

![段落の最初の行インデント](first_line_indent.png)

### **ハンギングインデントを設定**

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) プロパティでこの効果を作成します。`Indent` に負の値を設定すると、段落本文に対して最初の行を左へ移動させます。

実際には、[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) が段落本文の左位置を定義し、[IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式設定は、文献、参考文献、用語集エントリ、その他折り返し行が段落本文の下に揃う必要がある段落で便利です。

次の C# の例は、[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) を 40 と 60 ポイント、[IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) を -20 と -30 ポイントで組み合わせます。各段落で最初の行は折り返し行の左に開始し、2 番目の段落はより深いハンギングインデントになります:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

結果:

![段落のハンギングインデント](hanging_indent.png)

### **段落末端の実行プロパティを設定**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) プロパティは段落終了マークの書式設定を制御します。次の例は、[IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) を 48 ポイント、[IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) を Times New Roman に設定した [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) を作成します。この書式を 2 番目の段落の終了マークに割り当て、可視テキストのポーションは変更しません:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **レンダリングされた行数のカウント**

行末の自動折り返しや句読点に影響する段落規則については、[行分割の制御](/slides/ja/net/text-formatting/#control-line-breaking) と [ハンギング句読点の制御](/slides/ja/net/text-formatting/#control-hanging-punctuation) を参照してください。

[IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) を使用すると、テキストレイアウト後の段落が占める行数（自動折り返しを含む）をカウントできます。プレゼンテーション テンプレートでテキストの長さとレイアウトを確認する際に便利です。

段落は [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/) の項目の一つで、複数のレンダリング行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しは利用可能な幅に基づいて行を生成し、テキストに明示的な改行文字を挿入しません。そのため、段落数や改行文字の数を数えても実際のレンダリング行数は得られません。

次の例はテキスト シェイプを作成し、行数をカウントした後にシェイプを狭め、さらに短い文字列に置き換えます。例では [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) を有効にし、[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) を無効にして、シェイプの幅で折り返しを制御し、テキストやシェイプの自動縮小を防ぎます。各測定は [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) を使用します。シェイプのサイズはポイント単位です。最後に、別の段落を追加し、テキストフレーム全体の行数を合計します:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

このテキストとこれらのサイズでシェイプを狭めると行数が増加し、短い文字列に置き換えると減少します。正確なカウントはフォントの可用性と置換、フォント サイズ、余白、インデント、折り返し、オートフィット設定により変わります。テンプレートをチェックする際は、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナを超えているかどうかは判断できません。利用可能な高さ、行高さ、段落と行間隔、オートフィットの動作も重要です。折り返しが無効でも、単一行が利用可能な幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

HTML を使用してテキストをプレゼンテーションに取り込んだり、既存の段落を外部で使用できるようにエクスポートしたりできます。このセクションでは、テーブル セル内の段落を含む、個々の段落を画像としてレンダリングする方法も示します。

### **HTML テキストを段落にインポート**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

この C# の例はファイルから HTML を読み取り、マークアップを [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) に渡します。テキストフレームの既定段落をクリアして、フレームにインポートされたコンテンツだけが含まれるようにします。長方形シェイプはスライドの各側に 10 ポイントの余白を残します:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **段落テキストを HTML にエクスポート**

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) を使用して、選択した段落範囲を HTML としてエクスポートします。プレゼンテーションのテキストを Web サイトで再利用する場合、フォント、サイズ、テキスト ボックス スタイルを持ち込まずにローカルの強調表示を保持したいことがあります。その場合は [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) を設定して、エクスポート時の書式継承の深さを制御します。

[サンプル プレゼンテーション](text-inheritance.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置してください。最初のスライドにはテキスト "Inherited text; explicit red 18pt" を含むテキスト シェイプが 1 つあります。入力は意図的に複数の書式レベルを使用しています。

- プレゼンテーションの既定テキスト スタイルは Calibri と 28 pt を提供します。
- テキストフレームの第一レベルテキスト スタイルは青色テキストと斜体を提供します。
- 段落は太字テキストを明示的に設定します。
- 第二ポーション "explicit red 18pt" は赤色テキストと 18 pt のサイズを明示的に設定します。

次の完全な例は同じ段落を 3 回エクスポートします。[TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) をエクスポート メソッドに渡し、各結果を別々の UTF-8 HTML ファイルとして書き込みます:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

生成された HTML には最初のポーション "Inherited text; " に対する次の CSS が含まれます。表は関連する宣言を示し、その他の生成プロパティは簡潔さのために省略しています。

| 出力 | 最初のポーションの関連 CSS | 外観 |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Calibri が利用可能な場合、28 pt で青色、太字、斜体のテキスト |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | 青色、太字、斜体のテキスト；フォントファミリとサイズはページまたはブラウザーが供給 |
| `ParagraphOnly.html` | `font-weight:bold` | 太字のテキスト；フォントファミリ、サイズ、色、斜体はページまたはブラウザーが供給 |

第二ポーションはすべての出力で `color:#ff0000`、`font-size:18pt`、`font-weight:bold` を保持します。`All` と `TextBox` では斜体も保持されますが、`ParagraphOnly` では保持されません。継承制限を使用しても、段落またはポーションに明示的に割り当てられた書式は削除されません。

同じブラウザーでファイルを開いて比較してください。制限モードの 2 つでは、除外された CSS プロパティが宛先ページのスタイルまたはブラウザーのデフォルトで解決されるため、最終的な外観は HTML の使用場所に依存します。

### **HTML クリップボード フラグメントの生成**

[AddClipboardFragmentHeader](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/addclipboardfragmentheader/) を `false` に設定すると通常の HTML、`true` に設定するとクリップボード ヘッダーが含まれます。どちらの呼び出しも文字列を返します。ヘッダーは周囲の HTML の UTF-8 バイトオフセット（`StartHTML` と `EndHTML`）と貼り付けるコンテンツのオフセット（`StartFragment` と `EndFragment`）を提供します。

この例は 2 つの書式設定された段落を通常の HTML (`html`) と HTML クリップボード フラグメント (`clipboardHtml`) としてエクスポートします。フラグメントをシステム クリップボードに書き込むには別途アプリケーション側で処理が必要です。生の HTML クリップボードバイトを受け付けるクリップボード API では、BOM のない UTF-8 が必要です。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
var paragraphs = shape.TextFrame.Paragraphs;
paragraphs.Clear();
paragraphs.AddFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

var options = new TextToHtmlConversionOptions { AddClipboardFragmentHeader = false };
var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);

options.AddClipboardFragmentHeader = true;
var clipboardHtml = paragraphs.ExportToHtml(0, paragraphs.Count, options);
```

### **段落を画像としてレンダリング**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) を返します。結果は [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) でファイルまたはストリームに保存できます。 containing shape をレンダリングしたり、ビットマップを手動で切り取ったりする必要はありません。

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) は、段落が親コレクションに見つからない、レンダリング境界が無効、またはレンダリングできない場合に `null` を返すことがあります。保存前に結果を確認し、使用後は返された画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

この例は、1 つのスライドに 3 つの段落を含むテキスト ボックスがあるプレゼンテーションを使用します。

![3 段落のテキスト ボックス](paragraph_to_image_input.png)

次の例はインデックス 1 の 2 番目の段落を選択し、スケール パラメーターなしで [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) を呼び出します。シェイプが対象の段落を含むことを確認し、レンダリングが画像を返すことをチェックした上で、[IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) を使用して PNG 形式で保存します。`using` 宣言により画像は使用後に破棄されます。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

結果:

![段落画像](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリング**

`float scaleX` と `float scaleY` パラメーターを受け取る [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) のオーバーロードを使用して、水平および垂直のスケール係数を設定します。次の例はテーブルを作成し、最初のセル内の段落をデフォルト幅と高さの 2 倍でレンダリングし、PNG 画像として保存します。

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

スケール係数 `1` はその軸をデフォルトのピクセルサイズに保ちます。たとえば、両方の係数を `2` にすると、幅と高さがほぼ 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストをより鮮明にしますが、メモリ使用量とファイル サイズも増加します。`1` 未満の係数は詳細が少ない小さな画像を生成します。段落のアスペクト比を保持したい場合は同等の係数を使用し、水平と垂直で異なる係数を使用すると出力が個別に伸びます。

形状全体を [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) でレンダリングすることは、シェイプの塗りつぶし、枠線、その他の視覚コンテキストを含める必要がある場合に有用です。段落のみの画像の場合は [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) を使用してください。

## **よくある質問**

**テキストフレーム内の行折り返しを完全に無効にできますか？**

はい。[ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) を設定して折り返しを無効にすると、行はテキストフレームの端で改行しなくなります。

**特定の段落のスライド上の正確な境界を取得するにはどうすればよいですか？**

[IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) を使用して段落の境界矩形を取得します。[IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) は個々のポーションの境界を提供します。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御されますか？**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) は段落レベルの設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

各行内で異なるフォントサイズのポーションを垂直に揃える方法については、[行内フォントの揃え方](/slides/ja/net/text-formatting/#align-fonts-within-a-line) を参照してください。

**段落の一部に校正言語を設定できますか？**

はい。個々のポーションに対して [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) を設定すると、同一段落内で複数の言語のテキストを含めることができます。