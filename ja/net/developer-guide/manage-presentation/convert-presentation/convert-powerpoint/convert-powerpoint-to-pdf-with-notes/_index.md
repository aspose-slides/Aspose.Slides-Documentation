---
title: .NET でノート付き PowerPoint プレゼンテーションを PDF に変換
linktitle: ノート付き PowerPoint to PDF
type: docs
weight: 50
url: /ja/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PDF に変換
- プレゼンテーションを PDF に変換
- スライドを PDF に変換
- PPT を PDF に変換
- PPTX を PDF に変換
- プレゼンテーションを PDF として保存
- PPT を PDF として保存
- PPTX を PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- スピーカーノート
- ノート付き PDF
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides を使用して、PPT と PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---

## **概要**

この記事では、Aspose.Slides を使用してスライドノートを含む PowerPoint プレゼンテーションを PDF 形式に変換する方法を学びます。このガイドでは必要な手順を解説し、効率的に作業を行うためのコード例を提供します。この記事を読み終えると、次のことができるようになります。

- スライドノートを保持したまま PowerPoint スライドを PDF ドキュメントに変換するプロセスを実装する。
- 出力 PDF にスライドノートが含まれ、要件に合わせて書式設定されるようにカスタマイズする。

## **スライドノート付きで PowerPoint を PDF に変換する**

`Save` メソッドは、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスで PPT または PPTX プレゼンテーションをスライドノート付きの PDF に変換するために使用できます。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) クラスでレイアウトオプションを設定してスライドノートを含め、ファイルを PDF として保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューの PDF に変換する方法を示しています。
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // スピーカーノートのレンダリング用に PDF オプションを設定します。
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // スライドの下にスピーカーノートを描画します。
        }
    };

    // スピーカーノート付きでプレゼンテーションを PDF に保存します。
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 

Aspose の [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion) をぜひご利用ください。 

{{% /alert %}}