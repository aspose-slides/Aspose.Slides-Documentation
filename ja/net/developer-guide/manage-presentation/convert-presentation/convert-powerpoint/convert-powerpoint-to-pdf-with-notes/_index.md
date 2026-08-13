---
title: .NETでスピーカーノート付きPowerPointプレゼンテーションをPDFに変換
linktitle: ノート付きPowerPointからPDFへ
type: docs
weight: 50
url: /ja/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointからPDFへ
- プレゼンテーションをPDFへ
- スライドをPDFへ
- PPTをPDFへ
- PPTXをPDFへ
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
description: "Aspose.Slides for .NET を使用して、PPT および PPTX をノート付き PDF に変換します。プロフェッショナルなプレゼンテーションのレイアウトとスピーカーノートを保持します。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。このガイドでは、必要な手順をカバーし、タスクを効率的に実行するためのコード例を提供します。この記事の最後までに、以下ができるようになります：

- スピーカーノートを保持したまま、PowerPoint スライドを PDF ドキュメントに変換するプロセスを実装する。
- 出力 PDF をカスタマイズし、スピーカーノートが含まれ、要求に合わせて書式設定されていることを確認する。

## **ノート付きで PowerPoint を PDF に変換**

`Save` メソッドは [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスで、PPT または PPTX プレゼンテーションをスピーカーノート付きの PDF に変換するために使用できます。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用してスピーカーノートを含めるレイアウトオプションを構成し、最後にファイルを PDF として保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューで PDF に変換する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // スピーカーノートをレンダリングするための PDF オプションを構成します。
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

{{% alert color="info" %}} 
Aspose の [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ja/conversion) をぜひご確認ください。 
{{% /alert %}}