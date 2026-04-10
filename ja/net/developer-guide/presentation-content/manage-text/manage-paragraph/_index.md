---
title: .NET で PowerPoint テキスト段落を管理
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/net/manage-paragraph/
keywords:
- テキストの追加
- 段落の追加
- テキストの管理
- 段落の管理
- 箇条書きの管理
- 段落インデント
- ぶら下げインデント
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
description: "Aspose.Slides for .NET を使用して段落書式設定をマスターし、C# の PPT、PPTX、ODP プレゼンテーションで配置、間隔、スタイルを最適化します。"
---
Aspose.Slides は、C# で PowerPoint のテキスト、段落、およびパーツを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは、1 つまたは複数の段落を持つことができ（各段落は改行で作成されます）。
* Aspose.Slides は、パーツを表すオブジェクトを追加できるようにする [IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは、1 つまたは複数のパーツ（iPortions オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [IPortion](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基底の `IPortion` オブジェクトを通じて、異なる書式設定プロパティを持つテキストを処理できます。

## **複数のパーツを含む複数の段落を追加する**

以下の手順では、3 つの段落を含むテキストフレームを追加し、各段落に 3 つのパーツを含ませる方法を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 長方形の [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) をスライドに追加します。
4. その [IAutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) の `IParagraphs` コレクションに追加します。
6. 各新規 `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/) オブジェクト（デフォルト段落の場合は 2 つの Portion）を作成し、各 `IParagraph` の IPortion コレクションに追加します。
7. 各パーツにテキストを設定します。
8. `IPortion` オブジェクトが提供する書式設定プロパティを使用して、各パーツに好みの書式を適用します。
9. 変更したプレゼンテーションを保存します。

この C# コードは、パーツを含む段落を追加する手順の実装例です。

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
箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。箇条書き段落は常に読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) にアクセスします。 
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 段落の箇条書き `Type` を `Symbol` に設定し、箇条書き文字を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きのインデントを段落の `Indent` で設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、手順 7〜13 を繰り返します。
15. プレゼンテーションを保存します。

この C# コードは、段落の箇条書きを追加する方法を示しています。

```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセスします
    ISlide slide = pres.Slides[0];


    // AutoShape を追加し、アクセスします
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // AutoShape のテキストフレームにアクセスします
    ITextFrame txtFrm = aShp.TextFrame;

    // デフォルトの段落を削除します
    txtFrm.Paragraphs.RemoveAt(0);

    // 段落を作成します
    Paragraph para = new Paragraph();

    // 段落の箇条書きスタイルと記号を設定します
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // 段落のテキストを設定します
    para.Text = "Welcome to Aspose.Slides";

    // 箇条書きのインデントを設定します
    para.ParagraphFormat.Indent = 25;

    // 箇条書きの色を設定します
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 独自の箇条書き色を使用するために IsBulletHardColor を true に設定します

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
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 独自の箇条書き色を使用するために IsBulletHardColor を true に設定します

    // 箇条書きの高さを設定します
    para2.ParagraphFormat.Bullet.Height = 100;

    // 段落をテキストフレームに追加します
    txtFrm.Paragraphs.Add(para2);


    // 変更されたプレゼンテーションを保存します
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **画像箇条書きの管理**
箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。画像段落は読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) で画像を読み込みます。
8. 箇条書きタイプを [Picture](https://reference.aspose.com/slides/ja/net/aspose.slides/ippimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. 箇条書きのインデントを段落の `Indent` で設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前述の手順を繰り返します。
15. 変更したプレゼンテーションを保存します。

この C# コードは、画像箇条書きを追加・管理する方法を示しています。

```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();

// 最初のスライドにアクセスします
ISlide slide = presentation.Slides[0];

// 箇条書き用の画像をインスタンス化します
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// AutoShape を追加し、アクセスします
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// AutoShape のテキストフレームにアクセスします
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

// プレゼンテーションを PPTX ファイルとして保存します
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// プレゼンテーションを PPT ファイルとして保存します
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **階層付き箇条書きの管理**
箇条書きリストは、情報を迅速かつ効率的に整理・提示するのに役立ちます。階層付き箇条書きは読みやすく、理解しやすくなります。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

この C# コードは、階層付き箇条書きを追加・管理する方法を示しています。

```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセスします
    ISlide slide = pres.Slides[0];
    
    // AutoShape を追加し、アクセスします
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した AutoShape のテキストフレームにアクセスします
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
    // 箇条書きのレベルを設定します
    para1.ParagraphFormat.Depth = 0;

    // 2 番目の段落を追加します
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きのレベルを設定します
    para2.ParagraphFormat.Depth = 1;

    // 3 番目の段落を追加します
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きのレベルを設定します
    para3.ParagraphFormat.Depth = 2;

    // 4 番目の段落を追加します
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きのレベルを設定します
    para4.ParagraphFormat.Depth = 3;

    // 段落をコレクションに追加します
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // プレゼンテーションを PPTX ファイルとして保存します
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **カスタム番号付きリストを持つ段落の管理**
[IBulletFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/numberedbulletstartwith) プロパティなどを提供し、カスタム番号付けや書式設定を行う段落を管理できます。 

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. 対象段落が含まれるスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/ja/net/aspose.slides/ibulletformat/numberedbulletstartwith) を 2 に設定します。
7. `Paragraph` クラスを使用して2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

この C# コードは、カスタム番号付けや書式設定を持つ段落を追加・管理する方法を示しています。

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// 作成した AutoShape のテキストフレームにアクセスします
	ITextFrame textFrame = shape.TextFrame;

	// 既存のデフォルト段落を削除します
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

## **段落の先頭行インデントを設定する**

[IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) プロパティを使用して段落の先頭行インデントを制御します。このプロパティは段落の左余白に対して先頭行のみを移動させます。正の値は先頭行を右にシフトし、残りの行は段落本文に揃ったままです。

段落全体を移動させる場合は [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginleft/) を使用し、先頭行だけを移動させる場合は [IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) を使用します。

以下の例では、複数の段落を作成し、異なる `Indent` 値を適用して先頭行インデントが段落レイアウトに与える影響を示します。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 複数の段落を作成し、各段落に異なる [Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントを設定する方法を示します。

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

結果:

![段落の先頭行インデント](first_line_indent.png)

## **段落のぶら下げインデントを設定する**

ぶら下げインデントは、最初の行が残りの行より左に開始する段落レイアウトです。Aspose.Slides では、[IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) プロパティでこの効果を実現できます。`Indent` に負の値を設定すると、段落本文に対して最初の行が左へ移動します。

実際には、[IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginleft/) が段落本文の左位置を定義し、[IParagraphFormat.Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) がその余白に対する最初の行の位置を定義します。ぶら下げインデントを作成するには、`MarginLeft` に正の値、`Indent` に負の値を設定します。

この書式設定は、参考文献や辞書項目など、折り返し行が段落本文の下に揃う必要がある場合に有用です。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [AutoShape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) を追加します。
4. シェイプに空の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) を追加し、デフォルト段落を削除します。
5. 各段落に対して正の [MarginLeft](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/marginleft/) 値を設定します。
6. ぶら下げインデント効果を作成するために負の [Indent](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraphformat/indent/) 値を設定します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落のぶら下げインデントを設定する方法を示します。

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

結果:

![段落のぶら下げインデント](hanging_indent.png)

## **段落の終了実行プロパティの管理**

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 位置を使って段落を含むスライドの参照を取得します。
1. スライドに矩形の [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) を追加します。
1. 矩形に 2 段落の [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) を追加します。
1. 段落の `FontHeight` とフォント種別を設定します。
1. 段落の End プロパティを設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、PowerPoint の段落に対して End プロパティを設定する方法を示します。

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
Aspose.Slides は、HTML テキストを段落にインポートする機能を強化しています。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/ja/net/aspose.slides/autoshape/) を追加します。
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/itextframe/) を追加・取得します。
5. `ITextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML コンテンツを TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

この C# コードは、HTML テキストを段落にインポートする手順の実装例です。

```c#
// 空のプレゼンテーション インスタンスを作成します
using (Presentation pres = new Presentation())
{
    // プレゼンテーションのデフォルトの最初のスライドにアクセスします
    ISlide slide = pres.Slides[0];

    // HTML コンテンツを格納する AutoShape を追加します
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // シェイプにテキストフレームを追加します
    ashape.AddTextFrame("");

    // 追加されたテキストフレームのすべての段落をクリアします
    ashape.TextFrame.Paragraphs.Clear();

    // ストリームリーダーを使用して HTML ファイルを読み込みます
    TextReader tr = new StreamReader("file.html");

    // HTML ストリームリーダーからのテキストをテキストフレームに追加します
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // プレゼンテーションを保存します
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **段落テキストを HTML にエクスポートする**
Aspose.Slides は、段落内のテキストを HTML にエクスポートする機能を強化しています。

1. [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) クラスのインスタンスを作成し、目的のプレゼンテーションを読み込みます。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/ja/net/aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. 開始インデックスを StreamWriter に指定し、希望する段落をエクスポートします。

この C# コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示します。

```c#
// プレゼンテーション ファイルを読み込みます
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // プレゼンテーションのデフォルトの最初のスライドにアクセスします
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

このセクションでは、[IParagraph](https://reference.aspose.com/slides/ja/net/aspose.slides/iparagraph/) インターフェイスで表現されるテキスト段落を画像として保存する 2 つの例を紹介します。両例とも、段落を含むシェイプの画像を取得し（[IShape](https://reference.aspose.com/slides/ja/net/aspose.slides/ishape/) の `GetImage` メソッド使用）、シェイプ内の段落の境界を計算し、ビットマップ画像としてエクスポートします。これにより、PowerPoint プレゼンテーションからテキストの特定部分を抽出し、別々の画像として保存でき、さまざまなシナリオで活用できます。

サンプルとして、1 スライドだけのプレゼンテーションファイル sample.pptx を想定します。最初のシェイプは 3 段落を含むテキストボックスです。

![3 段落を含むテキストボックス](paragraph_to_image_input.png)

**例 1**

この例では、2 番目の段落を画像として取得します。まずプレゼンテーションの最初のスライドからシェイプの画像を抽出し、次にシェイプのテキストフレーム内の 2 番目の段落の境界を計算します。その段落を新しいビットマップ画像に描画し、PNG 形式で保存します。この手法は、特定の段落を正確なサイズと書式を保ったまま別画像として保存したい場合に便利です。

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

結果:

![段落画像](paragraph_to_image_output.png)

**例 2**

この例では、前例に拡張して段落画像にスケーリング係数を加えます。シェイプを抽出し、スケール係数 `2` で画像として保存します。これにより、段落の高解像度出力が可能になります。段落の境界はスケールを考慮して計算されます。スケーリングは、印刷物など高品質な画像が必要な場合に特に有用です。

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// スケーリング付きでシェイプをメモリ内にビットマップとして保存します。
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

// 出力画像のサイズを計算します（最小サイズ - 1x1 ピクセル）。
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// 段落用のビットマップを準備します。
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// シェイプのビットマップから段落ビットマップへ段落を再描画します。
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**テキストフレーム内で改行を完全に無効にできますか？**

はい。テキストフレームの折り返し設定（[WrapText](https://reference.aspose.com/slides/ja/net/aspose.slides/textframeformat/wraptext/)）をオフにすれば、行はフレームの端で改行しません。

**特定の段落のスライド上での正確な境界を取得する方法は？**

段落（や単一パーツ）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズが分かります。

**段落の配置（左揃え/右揃え/中央揃え/均等割付）はどこで設定しますか？**

[ParagraphFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphformat/) の [Alignment](https://reference.aspose.com/slides/ja/net/aspose.slides/paragraphformat/alignment/) が段落レベルの設定で、個々のパーツの書式に関係なく段落全体に適用されます。

**段落の一部（例：単語）だけにスペルチェック言語を設定できますか？**

はい。言語はパーツレベル（[PortionFormat.LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/baseportionformat/languageid/)）で設定できるため、同一段落内に複数言語を共存させることが可能です。