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
- 段落バレット
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTML をインポート
- テキストを HTML に変換
- 段落を HTML に変換
- 段落を画像に変換
- テキストを画像に変換
- 段落をエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で段落の書式設定をマスターし、C# の PPT、PPTX、ODP プレゼンテーションの配置、間隔、スタイルを最適化します。"
---
## **はじめに**

Aspose.Slides は、C# で PowerPoint のテキスト、段落、そしてポーションを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは、1 つまたは複数の段落を持つことができます（各段落は改行で作成されます）。
* Aspose.Slides は、ポーションを表すオブジェクトを追加できるようにする [IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは、1 つまたは複数のポーション（iPortions オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [IPortion](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基になる `IPortion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数のポーションを含む複数の段落を追加する**

以下の手順では、3 つの段落を含み、各段落が 3 つのポーションを持つテキストフレームの追加方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使って対象スライドの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) の `IParagraphs` コレクションに追加します。
6. 各新しい `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/) オブジェクトを作成（デフォルトの段落には 2 つの Portion オブジェクト）し、各 `IPortion` オブジェクトをそれぞれの `IParagraph` の IPortion コレクションに追加します。
7. 各ポーションにテキストを設定します。
8. `IPortion` オブジェクトが提供する書式プロパティを使用して、各ポーションに好みの書式設定を適用します。
9. 変更されたプレゼンテーションを保存します。

```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{
    // 最初のスライドにアクセスします
    ISlide slide = pres.Slides[0];

    // 矩形の IAutoShape を追加します
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape の TextFrame にアクセスします
    ITextFrame tf = ashp.TextFrame;

    // 異なるテキスト書式を持つ Paragraph と Portion を作成します
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // 変更されたプレゼンテーションを保存します
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **段落の箇条書きの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書きされた段落は常に読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使って対象スライドの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) にアクセスします。 
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 段落のバレット `Type` を `Symbol` に設定し、バレット文字を設定します。
9. 段落の `Text` を設定します。
10. バレット用に段落の `Indent` を設定します。
11. バレットの色を設定します。
12. バレットの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、手順 7 から 13 のプロセスを繰り返します。
15. プレゼンテーションを保存します。

```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセスします
    ISlide slide = pres.Slides[0];


    // Autoshape を追加してアクセスします
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Autoshape のテキストフレームにアクセスします
    ITextFrame txtFrm = aShp.TextFrame;

    // デフォルトの段落を削除します
    txtFrm.Paragraphs.RemoveAt(0);

    // 段落を作成します
    Paragraph para = new Paragraph();

    // 段落の箇条書きスタイルとシンボルを設定します
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // 段落のテキストを設定します
    para.Text = "Welcome to Aspose.Slides";

    // 箇条書きのインデントを設定します
    para.ParagraphFormat.Indent = 25;

    // 箇条書きの色を設定します
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor を true に設定して独自の箇条書き色を使用します

    // 箇条書きの高さを設定します
    para.ParagraphFormat.Bullet.Height = 100;

    // 段落をテキストフレームに追加します
    txtFrm.Paragraphs.Add(para);

    // 2 番目の段落を作成します
    Paragraph para2 = new Paragraph();

    // 段落の箇条書きタイプとスタイルを設定します
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // 段落のテキストを追加します
    para2.Text = "This is numbered bullet";

    // 箇条書きのインデントを設定します
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor を true に設定して独自の箇条書き色を使用します

    // 箇条書きの高さを設定します
    para2.ParagraphFormat.Bullet.Height = 100;

    // 段落をテキストフレームに追加します
    txtFrm.Paragraphs.Add(para2);


    // 変更されたプレゼンテーションを保存します
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **画像バレットの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像段落は読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使って対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) で画像をロードします。
8. バレットのタイプを [Picture](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) に設定し、画像を設定します。
9. 段落の `Text` を設定します。
10. バレット用に段落の `Indent` を設定します。
11. バレットの色を設定します。
12. バレットの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前の手順に基づいてプロセスを繰り返します。
15. 変更されたプレゼンテーションを保存します。

```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();

// 最初のスライドにアクセスします
ISlide slide = presentation.Slides[0];

// 箇条書き用画像のインスタンスを作成します
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Autoshape を追加してアクセスします
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Autoshape のテキストフレームにアクセスします
ITextFrame textFrame = autoShape.TextFrame;

// デフォルトの段落を削除します
textFrame.Paragraphs.RemoveAt(0);

// 新しい段落を作成します
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// 段落の箇条書きスタイルと画像を設定します
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// 箇条書きの高さを設定します
paragraph.ParagraphFormat.Bullet.Height = 100;

// 段落をテキストフレームに追加します
textFrame.Paragraphs.Add(paragraph);

// プレゼンテーションを PPTX ファイルとして書き込みます
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// プレゼンテーションを PPT ファイルとして書き込みます
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **階層付きバレットの管理**

箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。階層付きバレットは読みやすく、理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使って対象スライドの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスを使って最初の段落インスタンスを作成し、depth を 0 に設定します。
7. `Paragraph` クラスを使って第2の段落インスタンスを作成し、depth を 1 に設定します。
8. `Paragraph` クラスを使って第3の段落インスタンスを作成し、depth を 2 に設定します。
9. `Paragraph` クラスを使って第4の段落インスタンスを作成し、depth を 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更されたプレゼンテーションを保存します。

```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセスします
    ISlide slide = pres.Slides[0];
    
    // Autoshape を追加してアクセスします
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した Autoshape のテキストフレームにアクセスします
    ITextFrame text = aShp.AddTextFrame("");
    
    // デフォルトの段落をクリアします
    text.Paragraphs.Clear();

    // 最初の段落を追加します
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きレベルを設定します
    para1.ParagraphFormat.Depth = 0;

    // 2 番目の段落を追加します
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きレベルを設定します
    para2.ParagraphFormat.Depth = 1;

    // 3 番目の段落を追加します
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きレベルを設定します
    para3.ParagraphFormat.Depth = 2;

    // 4 番目の段落を追加します
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きレベルを設定します
    para4.ParagraphFormat.Depth = 3;

    // 段落をコレクションに追加します
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // プレゼンテーションを PPTX ファイルとして書き込みます
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **カスタム番号付きリストを持つ段落の管理**

[IBulletFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/numberedbulletstartwith) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できるようにします。 

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. 段落が含まれるスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスで最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/numberedbulletstartwith) を 2 に設定します。
7. 第2の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. 第3の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更されたプレゼンテーションを保存します。

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// 作成した Autoshape のテキストフレームにアクセスします
	ITextFrame textFrame = shape.TextFrame;

	// 既定の既存の段落を削除します
	textFrame.Paragraphs.RemoveAt(0);

	// 最初のリスト
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **段落の最初の行インデントを設定する**

段落の最初の行インデントを制御するには、[IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) プロパティを使用します。このプロパティは、段落の左余白に対して最初の行だけを移動させます。正の値は最初の行を右にシフトし、残りの行は段落本文に揃ったままです。

段落全体を移動したい場合は [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginleft/) を使用し、最初の行だけを移動したい場合は [IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) を使用します。

以下の例は、複数の段落を作成し、異なる `Indent` 値を適用して最初の行インデントが段落レイアウトに与える影響を示しています。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. いくつかの段落を作成し、それぞれに異なる [Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更されたプレゼンテーションを保存します。

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

結果：

![段落の最初の行インデント](first_line_indent.png)

## **段落のハンギングインデントを設定する**

ハンギングインデントは、最初の行が残りの行より左側に始まる段落レイアウトです。Aspose.Slides では、[IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) プロパティを使用してこの効果を作ります。`Indent` に負の値を設定すると、段落本文に対して最初の行が左に移動します。

実際には、[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginleft/) が段落本文の左位置を定義し、[IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の `MarginLeft` 値と負の `Indent` 値を設定します。

この書式は、文献リスト、参考文献、用語集エントリ、その他、折り返し行が段落本文の下に揃う必要がある段落で便利です。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) を追加し、デフォルトの段落を削除します。
5. 各段落に対して正の [MarginLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginleft/) 値を設定します。
6. ハンギングインデント効果を作るために負の [Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) 値を設定します。
7. 段落をテキストフレームに追加します。
8. 変更されたプレゼンテーションを保存します。

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

結果：

![段落のハンギングインデント](hanging_indent.png)

## **段落末尾プロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. 段落が含まれるスライドの位置を通じて参照を取得します。  
3. スライドに矩形の [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) を追加します。  
4. 矩形に 2 段落のある [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) を追加します。  
5. 段落の `FontHeight` とフォントタイプを設定します。  
6. 段落の End プロパティを設定します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **HTML テキストを段落にインポートする**

Aspose.Slides は、HTML テキストを段落にインポートするための拡張サポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使って対象スライドの参照にアクセスします。  
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) を追加します。  
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) を追加してアクセスします。  
5. `ITextFrame` のデフォルト段落を削除します。  
6. TextReader でソース HTML ファイルを読み取ります。  
7. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスで最初の段落インスタンスを作成します。  
8. 読み取った TextReader の HTML ファイル内容を TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphcollection/) に追加します。  
9. 変更されたプレゼンテーションを保存します。

```c#
// 空のプレゼンテーション インスタンスを作成します
using (Presentation pres = new Presentation())
{
    // プレゼンテーションの既定の最初のスライドにアクセスします
    ISlide slide = pres.Slides[0];

    // HTML コンテンツを格納するために AutoShape を追加します
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // シェイプにテキストフレームを追加します
    ashape.AddTextFrame("");

    // 追加されたテキストフレームのすべての段落をクリアします
    ashape.TextFrame.Paragraphs.Clear();

    // ストリームリーダーを使用して HTML ファイルを読み込みます
    TextReader tr = new StreamReader("file.html");

    // HTML ストリームリーダーからテキストをテキストフレームに追加します
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // プレゼンテーションを保存します
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **段落テキストを HTML にエクスポートする**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための拡張サポートを提供します。

1. 目的のプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。  
2. インデックスを使って対象スライドの参照にアクセスします。  
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。  
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にアクセスします。  
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。  
6. StreamWriter に開始インデックスを指定し、希望する段落をエクスポートします。

```c#
// プレゼンテーション ファイルを読み込みます
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // プレゼンテーションの既定の最初のスライドにアクセスします
    ISlide slide = pres.Slides[0];

    // 必要なインデックスにアクセスします
    int index = 0;

    // 追加されたシェイプにアクセスします
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // 段落の開始インデックスとコピーする段落数を指定して、段落データを HTML に書き込みます
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **段落を画像として保存する**

このセクションでは、[IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) インターフェイスで表されるテキスト段落を画像として保存する方法を示す 2 つの例を紹介します。両方の例では、[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) インターフェイスの `GetImage` メソッドを使用して段落を含むシェイプの画像を取得し、シェイプ内の段落の境界を計算してビットマップ画像としてエクスポートします。これらのアプローチにより、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオでの再利用が容易になります。

例として、sample.pptx という名前のプレゼンテーション ファイルに 1 枚のスライドがあり、最初のシェイプは 3 段落を含むテキスト ボックスであると仮定します。

![3 段落を含むテキスト ボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。まず、プレゼンテーションの最初のスライドからシェイプの画像を抽出し、次にシェイプのテキストフレーム内の 2 番目の段落の境界を計算します。その後、段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、テキストの正確なサイズと書式を保持しながら、特定の段落を別画像として保存したい場合に特に有用です。

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

結果：

![段落画像](paragraph_to_image_output.png)

**例 2**

この例では、前のアプローチにスケーリング係数を追加して段落画像を拡大します。シェイプをプレゼンテーションから抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。その後、スケールを考慮して段落の境界を計算します。スケーリングは、印刷物など高品質な画像が必要な場合に特に有用です。

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// スケーリング付きでシェイプをビットマップとしてメモリに保存します。
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// メモリからシェイプのビットマップを作成します。
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// 2 番目の段落の境界を計算します。
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// 出力画像のサイズを計算します（最小サイズ 1x1 ピクセル）。
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// 段落用のビットマップを準備します。
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// シェイプのビットマップから段落用ビットマップへ段落を再描画します。
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**テキストフレーム内の改行を完全に無効にできますか？**

はい。テキストフレームの折り返し設定（[WrapText](https://reference.aspose.com/slides/ja/net/aspose.slides/textframeformat/wraptext/)）を使用して折り返しをオフにすれば、フレームの端で行が分割されません。

**特定の段落のスライド上での正確な境界を取得するには？**

段落（場合によっては単一のポーション）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズが分かります。

**段落の配置（左揃え/右揃え/中央揃え/均等割り付け）はどこで制御されますか？**

[Alignment](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphformat/alignment/) は [ParagraphFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphformat/) の段落レベル設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部（例：単語）だけにスペルチェック言語を設定できますか？**

はい。言語はポーションレベル（[PortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/languageid/)）で設定されるため、同一段落内で複数の言語を併用できます。