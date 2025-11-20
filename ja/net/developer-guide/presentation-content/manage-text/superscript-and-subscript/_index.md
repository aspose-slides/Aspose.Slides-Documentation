---
title: C#で上付き文字と下付き文字を管理する
linktitle: 上付き文字と下付き文字
type: docs
weight: 80
url: /ja/net/superscript-and-subscript/
keywords:
- 上付き文字
- 下付き文字
- 上付き文字の追加
- 下付き文字の追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides
description: "Aspose.Slides for .NET で上付き文字と下付き文字をマスターし、プレゼンテーションをプロフェッショナルなテキスト書式で強化して最大のインパクトを実現します。"
---

## **概要**

Aspose.Slides for .NET は、PowerPoint（PPT、PPTX）および OpenDocument（ODP）プレゼンテーションに上付き文字と下付き文字のテキストを統合する機能を提供します。化学式、数式、または脚注でコンテンツに注釈を付ける必要がある場合でも、これらの特殊な書式設定オプションは明瞭さと正確さを保つのに役立ちます。本稿では、上付き文字と下付き文字のスタイルをシームレスに適用し、すべてのスライドでプロフェッショナルな結果を得る方法を学びます。

## **上付き文字および下付き文字のテキストを追加**

任意の段落内に上付き文字や下付き文字のテキストを追加できます。Aspose.Slides でこれを実現するには、[PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) クラスの `Escapement` プロパティを使用する必要があります。

このプロパティを使用すると、上付き文字または下付き文字のテキストを設定でき、値は -100%（下付き）から 100%（上付き）までです。

実装手順:

1. Presentation クラスのインスタンスを作成します。
1. インデックスを使用してスライドへの参照を取得します。
1. `Rectangle` タイプの [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) をスライドに追加します。
1. [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) に関連付けられた [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) にアクセスします。
1. 既存の段落をクリアします。
1. 上付き文字テキスト用に新しい [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) を作成し、[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) の段落コレクションに追加します。
1. 新しいテキスト部分オブジェクトを作成します。
1. `Escapement` プロパティを 0 から 100 の範囲で設定し、上付き文字を適用します（0 は上付きなし）。
1. [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) にテキストを設定し、段落の部分コレクションに追加します。
1. 下付き文字テキスト用に別の [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) を作成し、段落コレクションに追加します。
1. 新しいテキスト部分オブジェクトを作成します。
1. `Escapement` プロパティを 0 から -100 の範囲で設定し、下付き文字を適用します（0 は下付きなし）。
1. [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) にテキストを設定し、段落の部分コレクションに追加します。
1. プレゼンテーションを PPTX ファイルとして保存します。

以下の C# コードはこれらの手順を実装しています:
```c#
using (Presentation presentation = new Presentation())
{
    // 最初のスライドを取得します。
    ISlide slide = presentation.Slides[0];

    // テキストボックスを作成します。
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // 上付き文字用の段落を作成します。
    IParagraph superPar = new Paragraph();

    // 通常テキストのテキスト部分を作成します。
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // 上付き文字のテキスト部分を作成します。
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // 下付き文字用の段落を作成します。
    IParagraph paragraph2 = new Paragraph();

    // 通常テキストのテキスト部分を作成します。
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // 下付き文字のテキスト部分を作成します。
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // 段落をテキストボックスに追加します。
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


結果:

![上付き文字と下付き文字](superscript_and_subscript.png)

## **よくある質問**

**上付き文字と下付き文字は PDF や他の形式にエクスポートする際に保持されますか？**

はい、Aspose.Slides for .NET は、PDF、PPT/PPTX、画像、その他のサポートされている形式へプレゼンテーションをエクスポートする際に、上付き文字と下付き文字の書式設定を適切に保持します。特殊な書式はすべての出力ファイルでそのまま残ります。

**上付き文字と下付き文字は、太字や斜体などの他の書式スタイルと組み合わせることができますか？**

はい、Aspose.Slides では、単一のテキスト部分内でさまざまなテキストスタイルを組み合わせることができます。太字、斜体、下線を有効にし、同時に上付き文字や下付き文字を適用するには、[PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) の対応するプロパティを設定します。

**上付き文字と下付き文字の書式設定は、表、チャート、または SmartArt 内のテキストでも機能しますか？**

はい、Aspose.Slides for .NET は、表やチャート要素を含むほとんどのオブジェクト内での書式設定をサポートしています。SmartArt を使用する場合は、適切な要素（たとえば [SmartArtNode](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartnode/)）とそのテキストコンテナにアクセスし、同様の方法で [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) プロパティを設定する必要があります。