---
title: .NET でノート付き PowerPoint プレゼンテーションを PDF に変換する
linktitle: ノート付き PowerPoint を PDF に変換
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
description: ".NET 用 Aspose.Slides を使用して PPT と PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---

## **概要**

この記事では、Aspose.Slides を使用してスライドノートを含む PowerPoint プレゼンテーションを PDF 形式に変換する方法を学びます。このガイドでは、必要な手順を説明し、効率的にタスクを実行できるようコード例を提供します。記事の最後まで読むと、以下ができるようになります。

- スライドノートを保持しながら、PowerPoint スライドを PDF 文書に変換するプロセスを実装すること。
- 出力 PDF をカスタマイズし、スライドノートが要件どおりに含まれ、フォーマットされていることを確認すること。

## **スライドノート付きで PowerPoint を PDF に変換する**

`Save` メソッドは、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスで PPT または PPTX プレゼンテーションをスライドノート付きの PDF に変換できます。Aspose.Slides を使用すると、プレゼンテーションを読み込み、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) クラスでレイアウトオプションを設定してスライドノートを含め、ファイルを PDF として保存するだけです。次のコードスニペットは、サンプルプレゼンテーションをノートスライドビューの PDF に変換する方法を示しています。
```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // スピーカーノートをレンダリングするためのPDFオプションを設定します。
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // スライドの下にスピーカーノートを描画します。
        }
    };

    // スピーカーノート付きでプレゼンテーションをPDFに保存します。
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```


{{% alert color="primary" %}} 
Aspose の[オンライン PowerPoint から PDF へのコンバータ](https://products.aspose.app/slides/conversion)をご確認ください。 
{{% /alert %}}