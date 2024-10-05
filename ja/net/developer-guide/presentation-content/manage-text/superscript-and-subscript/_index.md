---
title: 上付き文字と下付き文字
type: docs
weight: 80
url: /net/superscript-and-subscript/
keywords: "上付き文字, 下付き文字, 上付き文字テキストを追加, 下付き文字テキストを追加, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションに上付き文字と下付き文字テキストを追加する"
---

## **上付き文字と下付き文字テキストの管理**
任意の段落部分内に上付き文字と下付き文字テキストを追加できます。Aspose.Slides テキストフレームに上付き文字または下付き文字テキストを追加するには、**Escapement** プロパティを PortionFormat クラスの使用する必要があります。

このプロパティは、上付き文字または下付き文字のテキストを返すか設定します（値は -100%（下付き文字）から 100%（上付き文字）まで）。例えば：

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- スライドに長方形タイプの IAutoShape を追加します。
- IAutoShape に関連付けられている ITextFrame にアクセスします。
- 既存の段落をクリアします。
- 上付き文字テキストを保持する新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しいポーションオブジェクトを作成します。
- 上付き文字を追加するためにポーションの Escapement プロパティを 0 から 100 の間に設定します。（0 は上付き文字なしを意味します）
- ポーションのテキストを設定し、それを段落のポーションコレクションに追加します。
- 下付き文字テキストを保持する新しい段落オブジェクトを作成し、ITextFrame の IParagraphs コレクションに追加します。
- 新しいポーションオブジェクトを作成します。
- 下付き文字を追加するためにポーションの Escapement プロパティを 0 から -100 の間に設定します。（0 は下付き文字なしを意味します）
- ポーションのテキストを設定し、それを段落のポーションコレクションに追加します。
- プレゼンテーションを PPTX ファイルとして保存します。

上記の手順の実装は以下の通りです。

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    // スライドを取得
    ISlide slide = presentation.Slides[0];

    // テキストボックスを作成
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;
    textFrame.Paragraphs.Clear();

    // 上付き文字テキスト用の段落を作成
    IParagraph superPar = new Paragraph();

    // 通常のテキストを持つポーションを作成
    IPortion portion1 = new Portion();
    portion1.Text = "SlideTitle";
    superPar.Portions.Add(portion1);

    // 上付き文字テキストを持つポーションを作成
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // 下付き文字テキスト用の段落を作成
    IParagraph paragraph2 = new Paragraph();

    // 通常のテキストを持つポーションを作成
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // 下付き文字テキストを持つポーションを作成
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // テキストボックスに段落を追加
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("TestOut.pptx", SaveFormat.Pptx);
    System.Diagnostics.Process.Start("TestOut.pptx");
} 
```