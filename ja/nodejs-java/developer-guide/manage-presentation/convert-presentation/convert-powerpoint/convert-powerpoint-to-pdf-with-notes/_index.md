---
title: JavaScript でスピーカーノート付き PowerPoint プレゼンテーションを PDF に変換
linktitle: スピーカーノート付き PowerPoint の PDF 変換
type: docs
weight: 50
url: /ja/nodejs-java/convert-powerpoint-to-pdf-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、JavaScript で PPT および PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを作成します。"
---
## **概要**

本記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。このガイドでは、必要な手順を解説し、タスクを効率的に実行できるコード例を提供します。この記事の最後までに、以下ができるようになります：

- スライドノートを保持しながら、PowerPoint のスライドを PDF ドキュメントに変換するプロセスを実装する。
- 出力 PDF をカスタマイズし、スピーカーノートが含まれ、要件に合わせて書式設定されていることを確認する。

エクスポート前にノートページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/nodejs-java/notes-size/) を参照してください。

## **ノート付きPowerPointをPDFに変換**

`save` メソッドは、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスで使用でき、PPT または PPTX プレゼンテーションをスピーカーノート付きの PDF に変換します。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/notescommentslayoutingoptions/) クラスでレイアウトオプションを設定してスピーカーノートを含め、その後ファイルを PDF として保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライド表示の PDF に変換する方法を示しています。

```js
const asposeSlides = require("aspose.slides.via.java");

let presentation = new asposeSlides.Presentation("sample.pptx");

// スピーカーノートのレンダリングのために PDF オプションを構成します。
let notesOptions = new asposeSlides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(asposeSlides.NotesPositions.BottomFull); // スライドの下にスピーカーノートを描画します。

let pdfOptions = new asposeSlides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation.save("output.pdf", asposeSlides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Aspose の [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ja/conversion) を確認するとよいでしょう。
{{% /alert %}}