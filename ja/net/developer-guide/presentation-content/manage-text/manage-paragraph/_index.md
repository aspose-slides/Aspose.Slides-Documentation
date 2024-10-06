---
title: C#でPowerPointの段落を管理する
type: docs
weight: 40
url: /ja/net/manage-paragraph/
keywords: 
- 段落の追加
- 段落の管理
- 段落のインデント
- 段落のプロパティ
- HTMLテキスト
- 段落テキストのエクスポート
- PowerPointプレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#または.NETでPowerPointプレゼンテーションの段落、テキスト、インデント、およびプロパティを作成および管理します"
---

Aspose.Slidesは、C#でPowerPointのテキスト、段落、およびポーションを操作するために必要なすべてのインターフェースとクラスを提供します。

* Aspose.Slidesは、段落を表すオブジェクトを追加するための[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)インターフェースを提供します。`ITextFrame`オブジェクトは、1つまたは複数の段落を持つことができます（各段落はキャリッジリターンによって作成されます）。
* Aspose.Slidesは、ポーションを表すオブジェクトを追加するための[IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)インターフェースを提供します。`IParagraph`オブジェクトは、1つまたは複数のポーション（iPortionsオブジェクトのコレクション）を持つことができます。
* Aspose.Slidesは、テキストとそのフォーマットプロパティを表すオブジェクトを追加するための[IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/)インターフェースを提供します。

`IParagraph`オブジェクトは、基になる`IPortion`オブジェクトを介して異なるフォーマットプロパティを持つテキストを処理することができます。

## **複数のポーションを含む複数の段落を追加**

これらの手順は、3つの段落を含むテキストフレームを追加し、各段落に3つのポーションを含める方法を示します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを介して関連スライドの参照にアクセスします。
3. スライドに矩形[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)を追加します。
4. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)に関連するITextFrameを取得します。
5. 2つの[IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/)オブジェクトを作成し、それを[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)の`IParagraphs`コレクションに追加します。
6. 各新しい`IParagraph`に対して3つの[IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/)オブジェクトを作成し、各`IParagraph`のIPortionコレクションに各`IPortion`オブジェクトを追加します。
7. 各ポーションにテキストを設定します。
8. `IPortion`オブジェクトによって公開されているフォーマットプロパティを使用して、各ポーションにお好みのフォーマット機能を適用します。
9. 修正されたプレゼンテーションを保存します。

このC#コードは、ポーションを含む段落を追加する手順の実装です：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation pres = new Presentation())
{
    // 最初のスライドにアクセス
    ISlide slide = pres.Slides[0];

    // 矩形IAutoShapeを追加
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // AutoShapeのTextFrameにアクセス
    ITextFrame tf = ashp.TextFrame;

    // 異なるテキストフォーマットを持つ段落とポーションを作成
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
    // 修正されたプレゼンテーションを保存
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **段落の箇条書きを管理する**
箇条書きのリストは、情報を迅速かつ効率的に整理および提示するのに役立ちます。箇条書きの段落は、常に読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを介して関連スライドの参照にアクセスします。
3. 選択したスライドに[autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)にアクセスします。 
5. `TextFrame`のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
8. 段落の弾丸`Type`を`Symbol`に設定し、弾丸の文字を設定します。
9. 段落`Text`を設定します。
10. 弾丸のために段落`Indent`を設定します。
11. 弾丸の色を設定します。
12. 弾丸の高さを設定します。
13. 新しい段落を`TextFrame`段落コレクションに追加します。
14. 2番目の段落を追加し、ステップ7から13で与えられたプロセスを繰り返します。
15. プレゼンテーションを保存します。

このC#コードは、段落の弾丸を追加する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセス
    ISlide slide = pres.Slides[0];


    // Autoshapeを追加してアクセス
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // autoshapeのテキストフレームにアクセス
    ITextFrame txtFrm = aShp.TextFrame;

    // デフォルトの段落を削除
    txtFrm.Paragraphs.RemoveAt(0);

    // 段落を作成
    Paragraph para = new Paragraph();

    // 段落の弾丸スタイルと記号を設定
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // 段落テキストを設定
    para.Text = "Aspose.Slidesへようこそ";

    // 弾丸のインデントを設定
    para.ParagraphFormat.Indent = 25;

    // 弾丸の色を設定
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 自分の弾丸色を使用するためにIsBulletHardColorをtrueに設定

    // 弾丸の高さを設定
    para.ParagraphFormat.Bullet.Height = 100;

    // テキストフレームに段落を追加
    txtFrm.Paragraphs.Add(para);

    // 2番目の段落を作成
    Paragraph para2 = new Paragraph();

    // 段落の弾丸タイプとスタイルを設定
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // 段落テキストを追加
    para2.Text = "これは番号付き弾丸です";

    // 弾丸のインデントを設定
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // 自分の弾丸色を使用するためにIsBulletHardColorをtrueに設定

    // 弾丸の高さを設定
    para2.ParagraphFormat.Bullet.Height = 100;

    // テキストフレームに段落を追加
    txtFrm.Paragraphs.Add(para2);


    // 修正されたプレゼンテーションを保存
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **画像の弾丸を管理する**
箇条書きのリストは、情報を迅速かつ効率的に整理および提示するのに役立ちます。画像の段落は、読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを介して関連スライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)にアクセスします。
5. `TextFrame`のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)クラスを使用して最初の段落インスタンスを作成します。
7. [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)に画像を読み込みます。
8. 弾丸タイプを[Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/)に設定し、画像を設定します。
9. 段落`Text`を設定します。
10. 弾丸のために段落`Indent`を設定します。
11. 弾丸の色を設定します。
12. 弾丸の高さを設定します。
13. 新しい段落を`TextFrame`段落コレクションに追加します。
14. 2番目の段落を追加し、前のステップに基づいてプロセスを繰り返します。
15. 修正されたプレゼンテーションを保存します。

このC#コードは、画像の弾丸を追加および管理する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
Presentation presentation = new Presentation();

// 最初のスライドにアクセス
ISlide slide = presentation.Slides[0];

// 弾丸用の画像をインスタンス化
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Autoshapeを追加してアクセス
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// autoshapeのテキストフレームにアクセス
ITextFrame textFrame = autoShape.TextFrame;

// デフォルトの段落を削除
textFrame.Paragraphs.RemoveAt(0);

// 新しい段落を作成
Paragraph paragraph = new Paragraph();
paragraph.Text = "Aspose.Slidesへようこそ";

// 段落の弾丸スタイルと画像を設定
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// 弾丸の高さを設定
paragraph.ParagraphFormat.Bullet.Height = 100;

// 段落をテキストフレームに追加
textFrame.Paragraphs.Add(paragraph);

// PPTXファイルとしてプレゼンテーションを書き込む
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// PPTファイルとしてプレゼンテーションを書き込む
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **マルチレベルの弾丸を管理する**
箇条書きのリストは、情報を迅速かつ効率的に整理および提示するのに役立ちます。マルチレベルの弾丸は、読みやすく理解しやすいです。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを介して関連スライドの参照にアクセスします。
3. 新しいスライドに[autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)にアクセスします。
5. `TextFrame`のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)クラスを介して最初の段落インスタンスを作成し、深さを0に設定します。
7. `Paragraph`クラスを介して2番目の段落インスタンスを作成し、深さを1に設定します。
8. `Paragraph`クラスを介して3番目の段落インスタンスを作成し、深さを2に設定します。
9. `Paragraph`クラスを介して4番目の段落インスタンスを作成し、深さを3に設定します。
10. 新しい段落を`TextFrame`段落コレクションに追加します。
11. 修正されたプレゼンテーションを保存します。

このC#コードは、マルチレベルの弾丸を追加および管理する方法を示しています：

```c#
// PPTXファイルを表すPresentationクラスをインスタンス化
using (Presentation pres = new Presentation())
{

    // 最初のスライドにアクセス
    ISlide slide = pres.Slides[0];
    
    // Autoshapeを追加してアクセス
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // 作成したautoshapeのテキストフレームにアクセス
    ITextFrame text = aShp.AddTextFrame("");
    
    // デフォルトの段落をクリア
    text.Paragraphs.Clear();

    // 最初の段落を追加
    IParagraph para1 = new Paragraph();
    para1.Text = "内容";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 弾丸レベルを設定
    para1.ParagraphFormat.Depth = 0;

    // 2番目の段落を追加
    IParagraph para2 = new Paragraph();
    para2.Text = "第二レベル";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 弾丸レベルを設定
    para2.ParagraphFormat.Depth = 1;

    // 3番目の段落を追加
    IParagraph para3 = new Paragraph();
    para3.Text = "第三レベル";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 弾丸レベルを設定
    para3.ParagraphFormat.Depth = 2;

    // 4番目の段落を追加
    IParagraph para4 = new Paragraph();
    para4.Text = "第四レベル";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // 弾丸レベルを設定
    para4.ParagraphFormat.Depth = 3;

    // コレクションに段落を追加
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // PPTXファイルとしてプレゼンテーションを書き込む
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **カスタム番号付きリストの段落を管理する**
[IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/)インターフェースは、カスタム番号付けやフォーマットを持つ段落を管理できる[NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith)プロパティなどを提供します。

1. [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. 段落を含むスライドにアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)にアクセスします。
5. `TextFrame`のデフォルトの段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)クラスを介して最初の段落インスタンスを作成し、[NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith)を2に設定します。
7. `Paragraph`クラスを介して2番目の段落インスタンスを作成し、`NumberedBulletStartWith`を3に設定します。
8. `Paragraph`クラスを介して3番目の段落インスタンスを作成し、`NumberedBulletStartWith`を7に設定します。
9. 新しい段落を`TextFrame`段落コレクションに追加します。
10. 修正されたプレゼンテーションを保存します。

このC#コードは、カスタム番号付けまたはフォーマットを持つ段落を追加および管理する方法を示しています：

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// 作成したautoshapeのテキストフレームにアクセス
	ITextFrame textFrame = shape.TextFrame;

	// 既存のデフォルト段落を削除
	textFrame.Paragraphs.RemoveAt(0);

	// 最初のリスト
	var paragraph1 = new Paragraph { Text = "弾丸 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "弾丸 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "弾丸 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```


## **段落のインデントを設定する**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを介して関連スライドの参照にアクセスします。
1. スライドに矩形[autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)を追加します。
1. 矩形autoshapeに3つの段落を持つ[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)を追加します。
1. 矩形の線を非表示にします。
1. 各[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)のBulletOffsetプロパティを介してインデントを設定します。
1. 修正されたプレゼンテーションをPPTファイルとして書き込みます。

このC#コードは、段落のインデントを設定する方法を示しています：

```c#
// Presentationクラスをインスタンス化
Presentation pres = new Presentation();

// 最初のスライドを取得
ISlide sld = pres.Slides[0];

// 矩形形状を追加
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// 矩形にTextFrameを追加
ITextFrame tf = rect.AddTextFrame("これは最初の行です\rこれは2番目の行です\rこれは3番目の行です");

// 形状に合わせてテキストを設定
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// 矩形の線を非表示にする
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// TextFrameの最初の段落を取得し、そのインデントを設定
IParagraph para1 = tf.Paragraphs[0];

// 段落の弾丸スタイルと記号を設定
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// TextFrameの2番目の段落を取得し、そのインデントを設定
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// TextFrameの3番目の段落を取得し、そのインデントを設定
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// プレゼンテーションをディスクに書き込む
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```

## **段落のぶら下げインデントを設定する**

このC#コードは、段落のぶら下げインデントを設定する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "例"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "段落のぶら下げインデントを設定する"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "このC#コードは、段落のぶら下げインデントを設定する方法を示しています："
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **段落の終了段落ランプロパティを管理する**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. スライドの参照を取得し、段落の位置を介してアクセスします。
1. スライドに矩形[autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/)を追加します。
1. 矩形に2つの段落を持つ[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)を追加します。
1. 段落の`FontHeight`およびフォントタイプを設定します。
1. 段落の終了プロパティを設定します。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。

このC#コードは、PowerPointの段落の終了プロパティを設定する方法を示しています：

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("サンプルテキスト"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("サンプルテキスト2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **HTMLテキストを段落にインポートする**
Aspose.Slidesは、段落にHTMLテキストをインポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
2. インデックスを介して関連スライドの参照にアクセスします。
3. スライドに[autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)を追加します。
4. autoshapeの[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)を追加してアクセスします。
5. `ITextFrame`のデフォルトの段落を削除します。
6. ソースHTMLファイルをTextReaderで読み込みます。
7. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)クラスを介して最初の段落インスタンスを作成します。
8. 読み込んだTextReaderのHTMLファイルの内容をTextFrameの[ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/)に追加します。
9. 修正されたプレゼンテーションを保存します。

このC#コードは、段落にHTMLテキストをインポートする手順の実装です：

```c#
// 空のプレゼンテーションインスタンスを作成
using (Presentation pres = new Presentation())
{
    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.Slides[0];

    // HTMLコンテンツを格納するためのAutoShapeを追加
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // 形状にテキストフレームを追加
    ashape.AddTextFrame("");

    // 追加したテキストフレーム内のすべての段落をクリア
    ashape.TextFrame.Paragraphs.Clear();

    // ストリームリーダーを使用してHTMLファイルを読み込みます
    TextReader tr = new StreamReader("file.html");

    // テキストフレームにHTMLストリームリーダーのテキストを追加
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // プレゼンテーションを保存
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **段落のテキストをHTMLにエクスポートする**
Aspose.Slidesは、段落に含まれるテキストをHTMLにエクスポートするための強化されたサポートを提供します。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. インデックスを介して関連スライドの参照にアクセスします。
3. HTMLにエクスポートされるテキストを含む形状にアクセスします。
4. 形状の[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)にアクセスします。
5. `StreamWriter`のインスタンスを作成し、新しいHTMLファイルを追加します。
6. StreamWriterに開始インデックスを設定し、好みの段落をエクスポートします。

このC#コードは、PowerPointの段落テキストをHTMLにエクスポートする方法を示しています：

```c#
// プレゼンテーションファイルをロード
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // プレゼンテーションのデフォルトの最初のスライドにアクセス
    ISlide slide = pres.Slides[0];

    // 必要なインデックスにアクセス
    int index = 0;

    // 追加された形状にアクセス
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // 段落データをHTMLに書き込み、段落の開始インデックスとコピーする段落数を指定
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```