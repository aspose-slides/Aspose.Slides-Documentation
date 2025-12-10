---
title: .NET でプレゼンテーションの箇条書きと番号付きリストを管理する
linktitle: リストの管理
type: docs
weight: 70
url: /ja/net/manage-bullet-and-numbered-lists
keywords:
- 箇条書き
- 箇条書きリスト
- 番号付きリスト
- 記号箇条書き
- 画像箇条書き
- カスタム箇条書き
- 階層リスト
- 箇条書き作成
- 箇条書き追加
- リスト追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションで箇条書きと番号付きリストを管理する方法を学びます。ステップバイステップのガイド。"
---

**Microsoft PowerPoint** では、Word やその他のテキストエディタと同様に箇条書きや番号付きリストを作成できます。**Aspose.Slides for .NET** でもスライド内で箇条書きや番号を使用できます。 

## **箇条書きを使用する理由**

箇条書きは情報を迅速かつ効率的に整理・提示するのに役立ちます。 

**箇条書きの例**

ほとんどの場合、箇条書きは次の 3 つの主な機能を果たします：

- 読者や視聴者の注意を重要な情報へ引きつける
- 読者や視聴者が重要なポイントを簡単にスキャンできるようにする
- 重要な詳細を効率的に伝達する。

## **番号付きリストを使用する理由**

番号付きリストも情報の整理・提示に役立ちます。エントリの順序（例: *step 1、step 2* など）が重要な場合や、エントリを参照する必要がある場合（例: *see step 3*）は、箇条書きの代わりに番号を使用すべきです。

**番号付きリストの例**

以下の **Creating Bullets** 手順におけるステップ（step 1 から step 15） の概要です：

1. プレゼンテーション クラスのインスタンスを作成します。 
2. 複数のタスクを実行します（step 3 から step 14）。 
3. プレゼンテーションを保存します。 

## **箇条書きの作成**

箇条書きリストを作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. スライド コレクション内で、箇条書きを追加したいスライドに [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) オブジェクトでアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) を追加します。
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) にアクセスします。
5. [TextFrame](). のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) クラスを使用して最初の段落インスタンスを作成します。
8. 箇条書きのタイプを Symbol に設定し、次に箇条書き文字を設定します。
9. 段落テキストを設定します。
10. 段落インデントを設定して箇条書きを設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 作成した段落を [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) の段落コレクションに追加します。
14. 2 番目の段落を追加し、手順 7〜12 を繰り返します。
15. プレゼンテーションを保存します。

以下の C# サンプルコードは、上記手順の実装例として、スライドに箇条書きリストを作成する方法を示します：
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


## **画像箇条書きの作成**

Aspose.Slides for .NET は箇条書きリストの箇条書きを変更できます。箇条書きをカスタムシンボルや画像に置き換えることができます。リストに視覚的なアクセントを加えたり、エントリへの注意をさらに引きつけたい場合は、独自の画像を箇条書きとして使用できます。 

{{% alert color="primary" %}} 
通常の箇条書きシンボルを画像に置き換える場合は、透明な背景を持つシンプルなグラフィック画像を選択することをお勧めします。そのような画像はカスタム箇条書きシンボルとして最適です。 
いずれにせよ、選択した画像は非常に小さなサイズに縮小されるため、リスト内で箇条書きシンボルの代替として見栄えの良い画像を選択することを強く推奨します。 
{{% /alert %}} 

画像箇条書きを作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. スライド コレクション内で、目的のスライドに [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) オブジェクトでアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) を追加します。
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) にアクセスします。
5. [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) クラスを使用して最初の段落インスタンスを作成します。
7. ディスクから画像をロードし、[Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) に追加し、次に [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index) メソッドから返された [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) インスタンスを使用します。
8. 箇条書きのタイプを Picture に設定し、画像を設定します。
9. 段落テキストを設定します。
10. 段落インデントを設定して箇条書きを設定します。
11. 箇条書きの色を設定します。
12. 箇条書きの高さを設定します。
13. 作成した段落を [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) の段落コレクションに追加します。
14. 2 番目の段落を追加し、手順 7〜13 を繰り返します。
15. プレゼンテーションを保存します。

この C# コードは、スライドに画像箇条書きを作成する方法を示します：
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


## **階層化箇条書きの作成**

異なるレベルの項目（メインの箇条書きリストの下に追加のリスト）を含む箇条書きリストを作成するには、次の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
2. スライド コレクション内で、目的のスライドに [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index) オブジェクトでアクセスします。
3. 選択したスライドに [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) を追加します。
4. 追加したシェイプの [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) にアクセスします。
5. [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) のデフォルト段落を削除します。
6. [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) クラスを使用し、深さを 0 に設定して最初の段落インスタンスを作成します。
7. [Paragraph] クラスを使用し、深さを 1 に設定して2番目の段落インスタンスを作成します。
8. [Paragraph] クラスを使用し、深さを 2 に設定して3番目の段落インスタンスを作成します。
9. [Paragraph] クラスを使用し、深さを 3 に設定して4番目の段落インスタンスを作成します。
10. 作成した段落を [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) の段落コレクションに追加します。
11. プレゼンテーションを保存します。

上記手順の実装例であるこのコードは、C# で階層化箇条書きリストを作成する方法を示します：
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


## **番号リストの作成**

この C# コードは、スライドに番号付きリストを作成する方法を示します：
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


## **FAQ**

**Aspose.Slides で作成した箇条書きおよび番号付きリストは、PDF や画像などの他の形式にエクスポートできますか？**

はい、Aspose.Slides はプレゼンテーションを PDF や画像などの形式にエクスポートする際、箇条書きおよび番号付きリストの書式と構造を完全に保持し、一貫した結果を保証します。

**既存のプレゼンテーションから箇条書きや番号付きリストをインポートできますか？**

はい、Aspose.Slides は既存のプレゼンテーションから箇条書きや番号付きリストをインポートして編集でき、元の書式や外観を保持します。

**Aspose.Slides は複数言語で作成されたプレゼンテーションの箇条書きや番号付きリストをサポートしていますか？**

はい、Aspose.Slides は多言語プレゼンテーションを完全にサポートし、任意の言語で箇条書きや番号付きリストを作成でき、特殊文字や非ラテン文字の使用も可能です。