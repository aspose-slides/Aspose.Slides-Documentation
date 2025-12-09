---
title: .NETでノート付きPowerPointプレゼンテーションをPDFに変換
linktitle: ノート付きPowerPointをPDFに変換
type: docs
weight: 50
url: /ja/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをPDFに変換
- プレゼンテーションをPDFに変換
- スライドをPDFに変換
- PPTをPDFに変換
- PPTXをPDFに変換
- プレゼンテーションをPDFとして保存
- PPTをPDFとして保存
- PPTXをPDFとして保存
- PPTをPDFにエクスポート
- PPTXをPDFにエクスポート
- スピーカーノート
- ノート付きPDF
- .NET
- C#
- Aspose.Slides
description: ".NET用 Aspose.Slides を使用して、PPT と PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---

## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。このガイドでは、必要な手順を説明し、タスクを効率的に実行できるようコード例を提供します。この記事の最後までに、以下ができるようになります：

- スピーカーノートを維持しながら、PowerPoint スライドを PDF ドキュメントに変換するプロセスを実装します。
- 出力 PDF をカスタマイズし、スピーカーノートが含まれ、要件に合わせてフォーマットされていることを保証します。

## **スピーカーノート付きで PowerPoint を PDF に変換**

`Save` メソッドは [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスで PPT または PPTX プレゼンテーションをスピーカーノート付き PDF に変換するために使用できます。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使ってスピーカーノートを含めるレイアウトオプションを設定し、PDF として保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューの PDF に変換する方法を示しています。
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // スピーカーノートをレンダリングするための PDF オプションを設定します。
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // スライドの下にスピーカーノートをレンダリングします。
        }
    };

    // スピーカーノート付きでプレゼンテーションを PDF に保存します。
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 
Aspose の [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/conversion) をぜひご利用ください。 
{{% /alert %}}