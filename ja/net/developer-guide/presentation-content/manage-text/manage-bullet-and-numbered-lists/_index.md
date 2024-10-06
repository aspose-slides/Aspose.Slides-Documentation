---
title: 箇条書きと番号付きリストの管理
type: docs
weight: 70
url: /ja/net/manage-bullet-and-numbered-lists
keywords: "箇条書き, 箇条書きリスト, 番号, 番号付きリスト, 画像の箇条書き, 階層付き箇条書き, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションに箇条書きと番号付きリストを作成する"
---

**Microsoft PowerPoint**では、Wordや他のテキストエディタと同様に箇条書きや番号付きリストを作成できます。 **Aspose.Slides for .NET**でも、プレゼンテーションのスライドで箇条書きや番号を使用できます。

### 箇条書きを使用する理由

箇条書きは、情報を迅速かつ効率的に整理し、提示するのに役立ちます。

**箇条書きの例**

ほとんどの場合、箇条書きは次の3つの主要な機能を果たします：

- 読者や視聴者の注意を重要な情報に引き付ける
- 読者や視聴者が重要なポイントを簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達する

### 番号付きリストを使用する理由

番号付きリストも情報を整理し提示するのに役立ちます。理想的には、項目の順序（例：*ステップ1、ステップ2*）が重要な場合や、項目に参照を付ける必要がある場合（例：*ステップ3を参照*）、番号（箇条書きの代わりに）を使用すべきです。

**番号付きリストの例**

以下は、**箇条書き作成手順**のステップ（ステップ1からステップ15）の概要です：

1. プレゼンテーションクラスのインスタンスを作成する。
2. いくつかのタスクを実行する（ステップ3からステップ14）。
3. プレゼンテーションを保存する。

## 箇条書きの作成

箇条書きを作成するには、次の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成する。
2. スライドコレクション内の箇条書きリストを追加したいスライドに[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)オブジェクトを介してアクセスする。
3. 選択したスライドに[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)を追加する。
4. 追加した形状の[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)にアクセスする。
5. [TextFrame]()内のデフォルトの段落を削除する。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)クラスを使用して最初の段落インスタンスを作成する。
8. 箇条書きの種類を記号に設定し、箇条書き文字を設定する。
9. 段落のテキストを設定する。
10. 箇条書きを設定するために段落のインデントを設定する。
11. 箇条書きの色を設定する。
12. 箇条書きの高さを設定する。
13. 作成した段落を[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)の段落コレクションに追加する。
14. 2番目の段落を追加し、手順7-12を繰り返す。
15. プレゼンテーションを保存する。

以下のC#のサンプルコードは、上記の手順を実装したもので、スライドに箇条書きを作成する方法を示します：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.Red;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## 画像の箇条書きの作成

Aspose.Slides for .NETでは、箇条書きリストの箇条書きを変更できます。箇条書きをカスタム記号や画像に置き換えることができます。リストに視覚的な興味を追加したり、リスト内の項目にさらに注意を引いたりしたい場合は、自分の画像を箇条書きとして使用できます。

 {{% alert color="primary" %}} 

理想的には、通常の箇条書き記号を画像に置き換える意図がある場合は、透過的な背景を持つシンプルなグラフィック画像を選択した方が良いでしょう。このような画像はカスタム箇条書き記号として最適です。

いずれにせよ、選択した画像は非常に小さなサイズに縮小されるため、箇条書き記号の代わりとしてリストで見栄えの良い画像を選択することを強くお勧めします。

{{% /alert %}} 

画像の箇条書きを作成するには、次の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成する。
2. スライドコレクション内の任意のスライドに[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)オブジェクトを使用してアクセスする。
3. 選択したスライドに[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)を追加する。
4. 追加した形状の[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)にアクセスする。
5. [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)内のデフォルトの段落を削除する。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)クラスを使用して最初の段落インスタンスを作成する。
7. ディスクから画像を読み込み、[Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images)に追加し、[AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index)メソッドから返された[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage)インスタンスを使用する。
8. 箇条書きの種類を画像に設定し、画像を設定する。
9. 段落のテキストを設定する。
10. 箇条書きを設定するために段落のインデントを設定する。
11. 箇条書きの色を設定する。
12. 箇条書きの高さを設定する。
13. 作成した段落を[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)の段落コレクションに追加する。
14. 2番目の段落を追加し、手順7-13を繰り返す。
15. プレゼンテーションを保存する。

このC#コードは、スライドに画像の箇条書きを作成する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## 階層付き箇条書きの作成

異なるレベルの項目を含む箇条書きリスト—メインの箇条書きリストの下にある追加リスト—を作成するには、次の手順に従います：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成する。
2. スライドコレクション内の任意のスライドに[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index)オブジェクトを使用してアクセスする。
3. 選択したスライドに[AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape)を追加する。
4. 追加した形状の[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)にアクセスする。
5. [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)内のデフォルトの段落を削除する。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph)クラスを使用して深さを0に設定した最初の段落インスタンスを作成する。
7. [Paragraph]クラスを使用して深さを1に設定した2番目の段落インスタンスを作成する。
8. [Paragraph]クラスを使用して深さを2に設定した3番目の段落インスタンスを作成する。
9. [Paragraph]クラスを使用して深さを3に設定した4番目の段落インスタンスを作成する。
10. 作成した段落を[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe)の段落コレクションに追加する。
11. プレゼンテーションを保存する。

以下のコードは、上記の手順を実装したもので、C#で階層付き箇条書きリストを作成する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "My text Depth 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "My text Depth 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "My text Depth 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "My text Depth 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## 番号の作成

以下のC#コードは、スライドに番号付きリストを作成する方法を示しています：

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "My text 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "My text 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```