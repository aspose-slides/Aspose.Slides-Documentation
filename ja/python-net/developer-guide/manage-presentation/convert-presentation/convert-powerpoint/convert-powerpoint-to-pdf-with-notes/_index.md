---
title: Python でノート付きプレゼンテーションを PDF に変換
linktitle: ノート付きプレゼンテーションを PDF に変換
type: docs
weight: 50
url: /ja/python-net/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- ODP を変換
- PowerPoint を PDF に
- OpenDocument を PDF に
- プレゼンテーションを PDF に
- PPT を PDF に
- PPTX を PDF に
- ODP を PDF に
- スピーカーノート
- ノート付き PDF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PPT、PPTX、ODP 形式をノート付きの PDF に変換します。プロフェッショナルなプレゼンテーションのレイアウトとスピーカーノートを保持します。"
---
## **概要**

この講座では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。このガイドでは必要な手順を説明し、コード例を提供して効率的にこのタスクを完了できるようにします。この記事の最後までに、次のことができるようになります：

- スピーカーノートを保持しながら、PowerPoint スライドを PDF ドキュメントに変換するプロセスを実装する。
- 出力 PDF をカスタマイズして、スピーカーノートが含まれ、要件に合わせて書式設定されていることを確認する。

エクスポート前にノートページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/python-net/notes-size/) を参照してください。

## **スピーカーノート付きで PowerPoint を PDF に変換**

`save` メソッドは、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスで、PPT または PPTX プレゼンテーションをスピーカーノート付きの PDF に変換するために使用できます。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/notescommentslayoutingoptions/) クラスを使用してレイアウトオプションを構成してスピーカーノートを含め、そしてファイルを PDF として保存します。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューの PDF に変換する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    # スピーカーノートをレンダリングするための PDF オプションを構成します。
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = notes_options

    # スピーカーノート付きでプレゼンテーションを PDF に保存します。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="info" title="Note" %}}
Aspose の [オンライン PowerPoint から PDF へのコンバータ](https://products.aspose.app/slides/ja/conversion) をご覧ください。
{{% /alert %}}