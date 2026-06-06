---
title: .NET でプレゼンテーションの箇条書きと番号付きリストを管理
linktitle: リストの管理
type: docs
weight: 70
url: /ja/net/manage-lists/
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- 記号箇条書き
- 画像箇条書き
- カスタム箇条書き
- 階層リスト
- バレット作成
- バレット追加
- リスト追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションで、箇条書き、画像、階層、および番号付きリストを作成および書式設定する方法を学びます。"
---
## **概要**

Aspose.Slides for .NET を使用すると、PowerPoint および OpenDocument プレゼンテーションで箇条書きリストと番号付きリストを作成および書式設定できます。リスト項目は、段落の書式設定によって箇条書き設定が制御される段落です。

[IParagraph.ParagraphFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/paragraphformat/) プロパティを使用して段落レベルのリスト設定にアクセスします。主なエントリーポイントは[IParagraphFormat.Bullet](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/bullet/)で、[IBulletFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/) オブジェクトを返します。このオブジェクトを使用して、箇条書きの種類、記号、画像、色、サイズ、番号付スタイル、開始番号を設定できます。

この記事では、以下を示します：

- カスタム記号を使用した箇条書きリストを作成する
- 画像箇条書きを作成する
- 段落の深さを設定して階層付きリストを作成する
- 番号付きリストを作成する
- 既存のプレゼンテーションでリストの書式を検査および変更する

## **箇条書きリストの作成**

箇条書きリストを作成するには、[IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) オブジェクトを [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) に追加し、[IBulletFormat.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/type/) を[BulletType.Symbol](https://reference.aspose.com/slides/ja/net/aspose.slides/bullettype/) に設定します。その後、[IBulletFormat.Char](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/char/)、[IBulletFormat.Color](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/color/)、[IBulletFormat.Height](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/height/) を設定して箇条書きの外観を制御できます。

次の C# コードは、スライドで箇条書きリストを作成する方法を示しています。

```csharp
static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

結果：

![記号の箇条書き](symbol_bullets.png)

## **番号付きリストの作成**

項目の順序が重要な場合は、番号付きリストを使用します。[IBulletFormat.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/type/) を[BulletType.Numbered](https://reference.aspose.com/slides/ja/net/aspose.slides/bullettype/) に設定します。また、[IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/numberedbulletstyle/) で番号付けの書式を選択したり、リストを 1 以外の値から開始したい場合は[IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/numberedbulletstartwith/) を設定できます。

次の C# コードは、スライドで番号付きリストを作成する方法を示しています。

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

結果：

![番号付き箇条書き](numbered_bullets.png)

## **画像箇条書きの作成**

Aspose.Slides では、通常の箇条書き記号を画像に置き換えることができます。画像箇条書きは、小さいサイズでも読みやすいシンプルな画像（アイコンや小さな透過 PNG ファイルなど）で最適に機能します。

 {{% alert color="primary" %}}
理想的には、通常の箇条書き記号を画像に置き換える場合、透過背景のシンプルなグラフィックを選択するのが最適です。そのような画像はカスタム箇条書き記号としてうまく機能します。
{{% /alert %}}

画像は非常に小さなサイズに縮小されることに留意してください。そのため、リストの箇条書きとして使用したときに鮮明で視覚的に効果的な画像を選択することを強く推奨します。

画像箇条書きを作成するには、[Presentation.Images](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/images/) に画像を追加し、返された画像オブジェクトを[IBulletFormat.Picture](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/picture/) に割り当てます。画像を割り当てる前に、[IBulletFormat.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/type/) を[BulletType.Picture](https://reference.aspose.com/slides/ja/net/aspose.slides/bullettype/) に設定します。

例えば、"image.png" があるとします:

![箇条書き用の画像](picture_for_bullets.png)

次の C# コードは、スライドで画像箇条書きを作成する方法を示しています。

```csharp
static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

結果：

![画像箇条書き](picture_bullets.png)

## **階層付きリストの作成**

[IParagraphFormat.Depth](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/depth/) を使用して、リスト項目を異なるレベルに配置します。レベル0が最上位レベル、レベル1がその下にネストされる、といった具合です。

次の C# コードは、階層付き箇条書きリストを作成する方法を示しています。

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

結果：

![階層付きリスト](multilevel_list.png)

## **既存リストの変更**

既存のプレゼンテーションでリストの書式を変更するには、対象の段落にアクセスし、その[IParagraphFormat.Bullet](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/bullet/) 設定を更新します。リスト作成時に使用したプロパティは、PPT、PPTX、または ODP ファイルから読み込んだリストを検査または変更する際にも使用できます。

次の C# コードは、テキストフレーム内の最初の段落を番号付きリストスタイルに変更します。

```csharp
using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **FAQ**

**箇条書きと番号付きリストは PDF や画像にエクスポートできますか？**

はい。対象の形式が対応するテキストレイアウトと箇条書き機能をサポートしている場合、Aspose.Slides はリストの書式を保持します。

**既存のプレゼンテーションでリストを編集できますか？**

はい。プレゼンテーションをロードし、対象の段落にアクセスして、その[IParagraphFormat.Bullet](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/bullet/) 設定を検査または更新し、プレゼンテーションを保存します。

**リストに非ラテン文字を含めることはできますか？**

はい。リスト項目のテキストは Unicode 文字を含めることができるため、多言語プレゼンテーションでリストを作成できます。プレゼンテーションで使用するフォントが必要な文字をサポートしていることを確認してください。