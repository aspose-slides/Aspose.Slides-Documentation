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
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
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
description: "Aspose.Slides for .NET を使用して、段落、パーツ、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for .NET はテキストをテキストフレーム、段落、パーツの階層として表現します。

* [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) はシェイプ内のテキスト コンテナを表し、段落コレクションへのアクセスを提供します。
* [IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) はテキストフレーム内の 1 つの段落を表し、パーツおよび段落レベルの書式設定へのアクセスを提供します。
* [IPortion](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/) は段落内のテキスト ランを表します。各パーツは独自のテキストと文字レベルの書式設定を持つことができます。

このように、段落は複数のパーツを使用することで、フォント、色、サイズ、その他の書式が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数パーツを持つ段落の作成**

以下の手順で、3 つの段落それぞれに 3 つのパーツを持つテキスト フレームを作成します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使って対象スライドへの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) にアクセスします。
5. デフォルトの段落を使用し、テキスト フレームにさらに 2 つの [IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) オブジェクトを追加します。
6. 各段落が 3 つのパーツを含むように、十分な数の [IPortion](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/) オブジェクトを追加します。デフォルトの段落にはすでに空のパーツが 1 つ含まれています。
7. 各パーツのテキストを設定します。
8. [IPortion.PortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/portionformat/) を介して文字レベルの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この C# の例が手順を実装しています：

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

## **箇条書きおよび番号付きリストの作成**

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けは、関連項目を見やすくします。Aspose.Slides では、リスト設定は [IBulletFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/) を通じて定義します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使って対象スライドへの参照にアクセスします。
3. 選択したスライドに [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) にアクセスします。
5. テキスト フレームからデフォルトの段落を削除します。
6. 記号箇条書き用に [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) を作成します。
7. [IBulletFormat.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/type/) を [BulletType.Symbol](https://reference.aspose.com/slides/ja/net/aspose.slides/bullettype/) に設定し、箇条書き文字を指定します。
8. 段落のテキスト、インデント、箇条書きの色、箇条書きの高さを設定します。
9. 段落をテキスト フレームに追加します。
10. 2 番目の段落を作成し、[IBulletFormat.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/type/) を [BulletType.Numbered](https://reference.aspose.com/slides/ja/net/aspose.slides/bullettype/) に設定します。
11. 番号付き箇条書きスタイルを構成し、段落をテキスト フレームに追加します。
12. プレゼンテーションを保存します。

この C# の例は記号箇条書きと番号付き箇条書きを作成します：

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

画像箇条書きを使用すると、記号や番号の代わりにカスタム画像を使用できます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使って対象スライドへの参照にアクセスします。
3. [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加し、その [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) にアクセスします。
4. テキスト フレームからデフォルトの段落を削除します。
5. 箇条書き画像をロードし、[IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) としてプレゼンテーションの画像コレクションに追加します。
6. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) を作成し、テキストを設定します。
7. [IBulletFormat.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/type/) を [BulletType.Picture](https://reference.aspose.com/slides/ja/net/aspose.slides/bullettype/) に設定します。
8. [IBulletFormat.Picture](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/picture/) で画像を指定し、箇条書きの高さを設定します。
9. 段落をテキスト フレームに追加します。
10. 変更したプレゼンテーションを保存します。

この C# の例は画像箇条書きを作成します：

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

### **多層リストの作成**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/depth/) を設定して、リスト内の段落を異なるレベルに配置します。最上位レベルの深さは `0` です。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) を作成し、スライドにアクセスします。
2. [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加し、テキスト フレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書き記号を設定します。
4. それぞれの [IParagraphFormat.Depth](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/depth/) 値を `0`、`1`、`2`、`3` に設定します。
5. 段落をテキスト フレームに追加し、プレゼンテーションを保存します。

この C# の例は 4 段階の箇条書きリストを作成します：

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

### **番号付きリスト項目の開始番号をカスタム値に設定**

[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/numberedbulletstartwith/) を使用して、番号付き段落の開始番号を設定します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) を作成し、[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) をスライドに追加します。
2. シェイプのテキスト フレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. 各段落に対して [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/numberedbulletstartwith/) をそれぞれ `2`、`3`、`7` に設定します。
5. 段落をテキスト フレームに追加し、プレゼンテーションを保存します。

この C# の例は各段落にカスタム開始番号を割り当てます：

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

## **段落のレイアウトと End プロパティの制御**

### **ファーストラインインデントの設定**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) プロパティを使用して、段落の最初の行のインデントを制御します。このプロパティは段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右にシフトし、残りの行は段落本体に揃ったままです。

全体の段落を移動したい場合は [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginleft/) を使用し、最初の行だけを移動したい場合は [IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) を使用します。

以下の例は複数の段落を作成し、異なる [IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) 値を適用して、ファーストラインインデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、各段落に異なる [Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) 値を設定します。
6. 段落をテキスト フレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示しています：

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

結果：

![The first-line indent of the paragraphs](first_line_indent.png)

### **ハンギングインデントの設定**

ハンギングインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では [IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) プロパティに負の値を設定して実現します。

実際には、[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginleft/) が段落本体の左位置を定義し、[IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を組み合わせます。

この書式は文献目録、参照、用語集エントリなど、折り返し行が段落本体の下に揃う必要がある段落で便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) にアクセスし、デフォルトの段落を削除します。
5. 各段落に対して正の [MarginLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginleft/) 値を設定します。
6. 負の [Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) 値を設定してハンギングインデント効果を作ります。
7. 段落をテキスト フレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落のハンギングインデント設定方法を示しています：

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

結果：

![The hanging indent of the paragraphs](hanging_indent.png)

### **段落の End プロパティの設定**

[IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/endparagraphportionformat/) プロパティは段落末尾記号の書式を制御します。以下の例は第 2 段落の末尾記号にフォントサイズとラテンフォントを割り当てます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) をロードし、スライドにアクセスします。
2. [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキスト パーツを追加します。
4. 第 2 段落の末尾記号用に [PortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/portionformat/) を作成します。
5. [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/fontheight/) と [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/latinfont/) を設定します。
6. その書式を [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/endparagraphportionformat/) に割り当て、プレゼンテーションを保存します。

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

## **描画された行数の取得**

[IParagraph.GetLinesCount](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/getlinescount/) を使用すると、テキスト レイアウト後に段落が占める描画行数（自動折り返しを含む）を取得できます。これはプレゼンテーション テンプレートでテキスト長やレイアウトを確認する際に便利です。

段落は [ITextFrame.Paragraphs](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/paragraphs/) の 1 アイテムであり、複数の描画行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しは利用可能な幅に基づいて行を生成し、テキストに明示的な改行文字を挿入しません。そのため、段落数や改行文字の数を数えても描画行数は得られません。

以下の例はテキスト シェイプを作成し、行数をカウントし、シェイプを狭め、テキストを短い文字列に置き換えます。折り返しは有効にし、オートフィットは無効にして、シェイプ幅が折り返しを制御し、テキストやシェイプの自動縮小は行わないようにしています。シェイプのサイズはポイント単位です。最後に、別の段落を追加し、テキスト フレーム全体の行数を合計します。

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

このテキストと寸法では、シェイプを狭めると行数が増え、短い文字列に置き換えると減ります。正確なカウントはフォントの利用可能性と代替、フォントサイズ、余白、インデント、折り返し、オートフィット設定により変わります。テンプレートを確認する際は、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナを超えているかは判断できません。利用可能な高さ、行の高さ、段落および行間、オートフィットの動作も影響します。折り返しが無効の場合、1 行でも幅を超えることがあります。

## **段落内容のインポートとエクスポート**

### **HTML テキストを段落にインポート**

[ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphcollection/addfromhtml/) を使用して、HTML マークアップをテキスト フレーム内の段落とパーツに変換できます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. スライドにアクセスし、[IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
3. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) にアクセスし、デフォルトの段落をクリアします。
4. ソース HTML ファイルを読み取ります。
5. HTML 文字列を [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphcollection/addfromhtml/) に渡します。
6. 変更したプレゼンテーションを保存します。

この C# の例は HTML をテキスト フレームにインポートします：

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

[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphcollection/exporttohtml/) を使用して、選択した範囲の段落を HTML としてエクスポートできます。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) のインスタンスを作成し、目的のプレゼンテーションをロードします。
2. スライドにアクセスし、テキストを含む [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を見つけます。
3. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して、[ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphcollection/exporttohtml/) を呼び出します。
5. 返された HTML 文字列をファイルに書き込みます。

この C# の例は最初のテキスト シェイプからすべての段落をエクスポートします：

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **段落を画像としてレンダリング**

[IParagraph.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/getimage/) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/) を返します。結果は [IImage.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/iimage/save/) でファイルまたはストリームに保存できます。シェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

[IParagraph.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/getimage/) は、段落が親コレクションに存在しない、レンダリング境界が有効でない、またはレンダリングできない場合に `null` を返すことがあります。保存前に結果を確認し、使用後は返された画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

1 枚のスライドと、最初のシェイプが 3 段落を含むテキスト ボックスである sample.pptx というプレゼンテーション ファイルがあるとします。

![The text box with three paragraphs](paragraph_to_image_input.png)

以下の例は、通常のテキスト シェイプ内の第 2 段落をデフォルト スケールでレンダリングし、PNG 形式で画像を保存します。`using` 宣言により画像は適切に破棄されます。

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

結果：

![The paragraph image](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリング**

`float scaleX` と `float scaleY` パラメータを受け取る [IParagraph.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/getimage/) のオーバーロードを使用して、水平・垂直スケール係数を設定します。以下の例はテーブルを作成し、最初のセル内の段落を幅と高さを 2 倍に拡大してレンダリングし、PNG 画像として保存します。

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

スケール係数 `1` はその軸をデフォルトのピクセルサイズのままにします。たとえば、両方の係数に `2` を指定すると、幅と高さが約 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストを鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が減った小さな画像を生成します。段落のアスペクト比を保つには等しい係数を使用し、水平と垂直で異なる係数を設定すると出力が個別に伸びます。

シェイプ全体を画像化したい場合は、[IShape.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/getimage/) が有用です。段落だけの画像が必要なときは、[IParagraph.GetImage](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/getimage/) を使用してください。

## **FAQ**

**テキスト フレーム内で行折り返しを完全に無効にできますか？**

はい。`[ITextFrameFormat.WrapText](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframeformat/wraptext/)` を設定して折り返しを無効にすると、行はテキスト フレームの端で改行しなくなります。

**特定の段落のスライド上での正確な境界を取得するには？**

`[IParagraph.GetRect](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/getrect/)` を使用して段落のバウンディング矩形を取得できます。`[IPortion.GetRect](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/getrect/)` は個々のパーツの境界を提供します。

**段落の配置（左揃え、右揃え、中央揃え、両端揃え）はどこで制御しますか？**

`[IParagraphFormat.Alignment](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/alignment/)` は段落レベルの設定であり、個々のパーツの書式設定に関係なく段落全体に適用されます。

**段落の一部だけに校正言語を設定できますか？**

はい。個々のパーツに対して `[IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/languageid/)` を設定すれば、1 段落内で複数の言語を使用できます。