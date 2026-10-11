---
title: PHPでノート付きPowerPointプレゼンテーションをPDFに変換
linktitle: ノート付きPowerPointからPDFへ
type: docs
weight: 50
url: /ja/php-java/convert-powerpoint-to-pdf-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- スライド を変換
- PPT を変換
- PPTX を変換
- PowerPoint から PDF へ
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PPT および PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---
## **概要**

このガイドでは、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。必要な手順を解説し、効率的にタスクを実行できるようコード例を提供します。この記事の最後までに、以下ができるようになります：

- スピーカーノートを保持しながら、PowerPoint スライドを PDF ドキュメントに変換するプロセスを実装する。
- 出力 PDF をカスタマイズし、スピーカーノートが要件どおりに含まれ、フォーマットされていることを保証する。

エクスポート前にノートページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/php-java/notes-size/) を参照してください。

## **スピーカーノート付きで PowerPoint を PDF に変換**

`save` メソッドは、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスで、PPT または PPTX プレゼンテーションをスピーカーノート付きの PDF に変換するために使用できます。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/notescommentslayoutingoptions/) クラスを使用してスピーカーノートを含めるようにレイアウトオプションを構成し、そしてファイルを PDF として保存します。以下のコードスニペットは、サンプルプレゼンテーションをノートスライド表示の PDF に変換する方法を示しています。

```php
$presentation = new Presentation("sample.pptx");

// スピーカーノートをレンダリングするための PDF オプションを設定.
$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull); // スライドの下部にスピーカーノートをレンダリング.

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

// スピーカーノート付きでプレゼンテーションを PDF に保存.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="info" title="Note" %}}
Aspose の [オンライン PowerPoint to PDF コンバータ](https://products.aspose.app/slides/ja/conversion) をご確認いただくと良いでしょう。
{{% /alert %}}