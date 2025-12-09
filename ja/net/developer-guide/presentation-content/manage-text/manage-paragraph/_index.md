---
title: PowerPoint テキスト段落を .NET で管理
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/net/manage-paragraph/
keywords:
- テキストを追加
- 段落を追加
- テキストを管理
- 段落を管理
- 箇条書きを管理
- 段落インデント
- ハンギングインデント
- 段落の箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTMLのインポート
- テキストをHTMLへ
- 段落をHTMLへ
- 段落を画像へ
- テキストを画像へ
- 段落のエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使って段落書式をマスターし、C# で PPT、PPTX、ODP プレゼンテーションの配置、間隔、スタイルを最適化します。"
---

Aspose.Slides は、C# で PowerPoint のテキスト、段落、ポーションを操作するために必要なすべてのインターフェイスとクラスを提供します。

* Aspose.Slides は、段落を表すオブジェクトを追加できるようにする [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) インターフェイスを提供します。`ITextFame` オブジェクトは 1 つまたは複数の段落を持つことができます（各段落は改行で作成されます）。
* Aspose.Slides は、ポーションを表すオブジェクトを追加できるようにする [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) インターフェイスを提供します。`IParagraph` オブジェクトは 1 つまたは複数のポーション（iPortion オブジェクトのコレクション）を持つことができます。
* Aspose.Slides は、テキストとその書式設定プロパティを表すオブジェクトを追加できるようにする [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) インターフェイスを提供します。

`IParagraph` オブジェクトは、基になる `IPortion` オブジェクトを介して異なる書式設定プロパティを持つテキストを処理できます。

## **Add Multiple Paragraph Containing Multiple Portions**

この手順では、3 つの段落を持ち、各段落に 3 つのポーションを含むテキストフレームを追加する方法を示します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) に関連付けられた ITextFrame を取得します。
5. 2 つの [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) オブジェクトを作成し、[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) の `IParagraphs` コレクションに追加します。
6. 各新しい `IParagraph` に対して 3 つの [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) オブジェクトを作成（デフォルトの段落には 2 つの Portion）し、各 `IParagraph` の IPortion コレクションに追加します。
7. 各ポーションにテキストを設定します。
8. `IPortion` オブジェクトが公開する書式設定プロパティを使用して、各ポーションに好みの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この C# コードは、ポーションを含む段落を追加する手順の実装例です:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{
    // 最初のスライドにアクセス
    ISlide slide = pres.Slides[0];

    // 四角形の IAutoShape を追加
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShape の TextFrame にアクセス
    ITextFrame tf = ashp.TextFrame;

    // 異なるテキスト書式の Paragraph と Portion を作成
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
    // 変更されたプレゼンテーションを保存
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```


## **Manage Paragraph Bullets**

箇条書きは情報をすばやく効率的に整理・提示するのに役立ちます。箇条書きの段落は常に読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 選択したスライドに [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) にアクセスします。 
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 段落の bullet `Type` を `Symbol` に設定し、バレット文字を指定します。
9. 段落の `Text` を設定します。
10. バレット用に段落の `Indent` を設定します。
11. バレットの色を設定します。
12. バレットの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、手順 7〜13 を繰り返します。
15. プレゼンテーションを保存します。

この C# コードは、段落バレットを追加する方法を示しています:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセス
    ISlide slide = pres.Slides[0];


    // Autoshape を追加してアクセス
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // autoshape のテキスト フレームにアクセス
    ITextFrame txtFrm = aShp.TextFrame;

    // デフォルトの段落を削除
    txtFrm.Paragraphs.RemoveAt(0);

    // 段落を作成
    Paragraph para = new Paragraph();

    // 段落の箇条書きスタイルとシンボルを設定
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // 段落のテキストを設定
    para.Text = "Welcome to Aspose.Slides";

    // 箇条書きインデントを設定
    para.ParagraphFormat.Indent = 25;

    // 箇条書きの色を設定
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor を true に設定すると独自の箇条書き色を使用

    // 箇条書きの高さを設定
    para.ParagraphFormat.Bullet.Height = 100;

    // 段落をテキストフレームに追加
    txtFrm.Paragraphs.Add(para);

    // 2 番目の段落を作成
    Paragraph para2 = new Paragraph();

    // 段落の箇条書きタイプとスタイルを設定
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // 段落のテキストを追加
    para2.Text = "This is numbered bullet";

    // 箇条書きインデントを設定
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // IsBulletHardColor を true に設定すると独自の箇条書き色を使用

    // 箇条書きの高さを設定
    para2.ParagraphFormat.Bullet.Height = 100;

    // 段落をテキストフレームに追加
    txtFrm.Paragraphs.Add(para2);


    // 変更されたプレゼンテーションを保存
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Manage Picture Bullets**

箇条書きは情報をすばやく効率的に整理・提示するのに役立ちます。画像段落は読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) で画像をロードします。
8. バレットのタイプを [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) に設定し、画像を指定します。
9. 段落の `Text` を設定します。
10. バレット用に段落の `Indent` を設定します。
11. バレットの色を設定します。
12. バレットの高さを設定します。
13. 新しい段落を `TextFrame` の段落コレクションに追加します。
14. 2 番目の段落を追加し、前の手順に従って繰り返します。
15. 変更したプレゼンテーションを保存します。

この C# コードは、画像バレットの追加と管理方法を示しています:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation presentation = new Presentation();

// 最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// 箇条書き用画像をインスタンス化
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Autoshape を追加してアクセス
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// autoshape のテキストフレームにアクセス
ITextFrame textFrame = autoShape.TextFrame;

// デフォルトの段落を削除
textFrame.Paragraphs.RemoveAt(0);

// 新しい段落を作成
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// 段落の箇条書きスタイルと画像を設定
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// 箇条書きの高さを設定
paragraph.ParagraphFormat.Bullet.Height = 100;

// 段落をテキストフレームに追加
textFrame.Paragraphs.Add(paragraph);

// プレゼンテーションを PPTX ファイルとして保存
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// プレゼンテーションを PPT ファイルとして保存
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Manage Multilevel Bullets**

箇条書きは情報をすばやく効率的に整理・提示するのに役立ちます。多層バレットは読みやすく理解しやすいです。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class のインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. 新しいスライドに [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、深さを 0 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、深さを 1 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、深さを 2 に設定します。
9. `Paragraph` クラスを使用して 4 番目の段落インスタンスを作成し、深さを 3 に設定します。
10. 新しい段落を `TextFrame` の段落コレクションに追加します。
11. 変更したプレゼンテーションを保存します。

この C# コードは、多層バレットの追加と管理方法を示しています:
```c#
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセス
    ISlide slide = pres.Slides[0];
    
    // Autoshape を追加してアクセス
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成した Autoshape のテキストフレームにアクセス
    ITextFrame text = aShp.AddTextFrame("");
    
    // デフォルトの段落をクリア
    text.Paragraphs.Clear();

    // 最初の段落を追加
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きレベルを設定
    para1.ParagraphFormat.Depth = 0;

    // 2 番目の段落を追加
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きレベルを設定
    para2.ParagraphFormat.Depth = 1;

    // 3 番目の段落を追加
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きレベルを設定
    para3.ParagraphFormat.Depth = 2;

    // 4 番目の段落を追加
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 箇条書きレベルを設定
    para4.ParagraphFormat.Depth = 3;

    // 段落をコレクションに追加
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // プレゼンテーションを PPTX ファイルとして保存
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Manage Paragraph with Custom Numbered List**

[IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) インターフェイスは、[NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) プロパティなどを提供し、カスタム番号付けや書式設定を持つ段落を管理できます。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class のインスタンスを作成します。
2. 対象段落が含まれるスライドにアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
4. autoshape の [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) にアクセスします。
5. `TextFrame` のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) を 2 に設定します。
7. `Paragraph` クラスを使用して 2 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 3 に設定します。
8. `Paragraph` クラスを使用して 3 番目の段落インスタンスを作成し、`NumberedBulletStartWith` を 7 に設定します。
9. 新しい段落を `TextFrame` の段落コレクションに追加します。
10. 変更したプレゼンテーションを保存します。

この C# コードは、カスタム番号付けや書式設定を持つ段落の追加と管理方法を示しています:
```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// 作成したオートシェイプのテキストフレームにアクセス
	ITextFrame textFrame = shape.TextFrame;

	// デフォルトで既存の段落を削除
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


## **Set Paragraph Indent**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. インデックスを使用して対象スライドの参照にアクセスします。
1. スライドに矩形の [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) を追加します。
1. 矩形 autoshape に 3 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) を追加します。
1. 矩形の枠線を非表示にします。
1. 各 [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) の `BulletOffset` プロパティを使用してインデントを設定します。
1. 変更したプレゼンテーションを PPT ファイルとして書き出します。

この C# コードは、段落インデントを設定する方法を示しています:
```c#
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

// 矩形シェイプを追加
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// 矩形に TextFrame を追加
ITextFrame tf = rect.AddTextFrame("This is first line \rThis is second line \rThis is third line");

// テキストがシェイプに合わせるように設定
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// 矩形の線を非表示にする
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// TextFrame の最初の段落を取得しインデントを設定
IParagraph para1 = tf.Paragraphs[0];

// 段落の箇条書きスタイルとシンボルを設定
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// TextFrame の2番目の段落を取得しインデントを設定
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// TextFrame の3番目の段落を取得しインデントを設定
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// プレゼンテーションをディスクに保存
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```


## **Set Hanging Indent for Paragraph**

この C# コードは、段落のハンギングインデントを設定する方法を示しています:  
```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Example"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Set Hanging Indent for Paragraph"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "This C# code shows you how to set the hanging indent for a paragraph: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Manage End Paragraph Run Properties for Paragraph**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
1. 位置を指定して段落が含まれるスライドの参照を取得します。
1. スライドに矩形の [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) を追加します。
1. 矩形に 2 つの段落を持つ [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) を追加します。
1. 段落の `FontHeight` とフォント種別を設定します。
1. 段落の End プロパティを設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして書き出します。

この C# コードは、PowerPoint の段落に End プロパティを設定する方法を示しています:
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


## **Import HTML Text into Paragraphs**

Aspose.Slides は、HTML テキストを段落にインポートするための拡張サポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. スライドに [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) を追加します。
4. `autoshape` の [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) を追加および取得します。
5. `ITextFrame` のデフォルト段落を削除します。
6. TextReader でソース HTML ファイルを読み取ります。
7. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) クラスを使用して最初の段落インスタンスを作成します。
8. 読み取った TextReader の HTML コンテンツを TextFrame の [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) に追加します。
9. 変更したプレゼンテーションを保存します。

この C# コードは、段落への HTML テキストインポート手順の実装例です:
```c#
// 空のプレゼンテーション インスタンスを作成
using (Presentation pres = new Presentation())
{
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.Slides[0];

    // HTML コンテンツを格納する AutoShape を追加
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // シェイプにテキストフレームを追加
    ashape.AddTextFrame("");

    // 追加したテキストフレーム内のすべての段落をクリア
    ashape.TextFrame.Paragraphs.Clear();

    // ストリームリーダーを使用して HTML ファイルを読み込む
    TextReader tr = new StreamReader("file.html");

    // HTML ストリームリーダーからのテキストをテキストフレームに追加
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // プレゼンテーションを保存
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Export Paragraphs Text to HTML**

Aspose.Slides は、段落に含まれるテキストを HTML にエクスポートするための拡張サポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、対象のプレゼンテーションをロードします。
2. インデックスを使用して対象スライドの参照にアクセスします。
3. HTML にエクスポートするテキストを含むシェイプにアクセスします。
4. シェイプの [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) にアクセスします。
5. `StreamWriter` のインスタンスを作成し、新しい HTML ファイルを追加します。
6. `StreamWriter` に開始インデックスを指定し、好みの段落をエクスポートします。

この C# コードは、PowerPoint の段落テキストを HTML にエクスポートする方法を示しています:
```c#
// プレゼンテーション ファイルをロード
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.Slides[0];

    // 必要なインデックスにアクセス
    int index = 0;

    // 追加されたシェイプにアクセス
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // コピーする段落の開始インデックスと段落数を指定して段落データを HTML に書き込む
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```


## **Save a Paragraph as an Image**

このセクションでは、[IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) インターフェイスで表されるテキスト段落を画像として保存する 2 つの例を紹介します。両方の例で、[IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) インターフェイスの `GetImage` メソッドを使用して段落を含むシェイプの画像を取得し、シェイプ内での段落の境界を計算してビットマップ画像としてエクスポートします。これにより、PowerPoint プレゼンテーションからテキストの特定部分を抽出して個別の画像として保存でき、さまざまなシナリオでの利用が容易になります。

サンプルとして、`sample.pptx` というプレゼンテーションファイルが 1 スライドだけ持ち、最初のシェイプが 3 段落を含むテキストボックスであると仮定します。

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

この例では、2 番目の段落を画像として取得します。プレゼンテーションの最初のスライドからシェイプの画像を取得し、シェイプのテキストフレーム内で 2 番目の段落の境界を計算します。その後、段落を新しいビットマップ画像に再描画し、PNG 形式で保存します。この方法は、特定の段落を別画像として保存し、テキストの正確なサイズと書式設定を保持したい場合に特に有用です。
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

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

この例では、前のアプローチにスケーリング係数を追加します。シェイプをプレゼンテーションから抽出し、スケーリング係数 `2` で画像として保存します。これにより、段落をエクスポートする際に高解像度の出力が得られます。その後、スケールを考慮して段落の境界を計算します。スケーリングは、印刷物など高品質な画像が必要な場合に特に役立ちます。
```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

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


## **FAQ**

**Can I completely disable line wrapping inside a text frame?**

はい。テキストフレームの折り返し設定（[WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)）をオフにすると、行がフレームの端で改行しなくなります。

**How can I get the exact on-slide bounds of a specific paragraph?**

段落（および単一のポーション）のバウンディング矩形を取得すれば、スライド上での正確な位置とサイズを知ることができます。

**Where is paragraph alignment (left/right/center/justify) controlled?**

[Alignment](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/alignment/) は [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/) の段落レベル設定で、個々のポーションの書式設定に関係なく段落全体に適用されます。

**Can I set a spell-check language for just part of a paragraph (e.g., one word)?**

はい。言語はポーションレベル（[PortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/)）で設定されるため、同一段落内に複数言語を共存させることが可能です。