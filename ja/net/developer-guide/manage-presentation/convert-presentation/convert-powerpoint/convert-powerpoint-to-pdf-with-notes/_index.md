---
title: ノート付きで PowerPoint プレゼンテーションを PDF に変換 (.NET)
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
- PowerPoint から PDF へ
- プレゼンテーションを PDF に
- スライドを PDF に
- PPT を PDF に
- PPTX を PDF に
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
description: "Aspose.Slides for .NET を使用して PPT と PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---
## **概要**

この記事では、Aspose.Slides を使用してスライドノートを含む PowerPoint プレゼンテーションを PDF 形式に変換する方法を学びます。このガイドでは、必要な手順を解説し、効率的にタスクを実行できるコード例を提供します。この記事を読み終えると、次のことができるようになります。

- スライドノートを保持したまま、PowerPoint のスライドを PDF ドキュメントに変換するプロセスを実装する。
- 出力 PDF をカスタマイズし、スライドノートが要件に合わせて含まれ、書式設定されていることを確認する。

エクスポート前にノートページのサイズと向きを設定するには、[ノートページサイズ](/slides/ja/net/notes-size/) を参照してください。

## **ノート付きで PowerPoint を PDF に変換**

[Presentation クラス](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) の `Save` メソッドを使用すると、PPT または PPTX プレゼンテーションをスライドノート付きの PDF に変換できます。Aspose.Slides では、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions クラス](https://reference.aspose.com/slides/ja/net/aspose.slides.export/notescommentslayoutingoptions/) を使用してレイアウトオプションを構成し、スライドノートを含めて PDF として保存します。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューの PDF に変換する方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // スピーカーノートのレンダリング用に PDF オプションを構成します。
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
Aspose の[オンライン PowerPoint から PDF への変換ツール](https://products.aspose.app/slides/ja/conversion)を確認してみてください。 
{{% /alert %}}