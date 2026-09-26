---
title: Javaでスピーカーノート付きPowerPointプレゼンテーションをPDFに変換する
linktitle: スピーカーノート付きPowerPointからPDFへ
type: docs
weight: 50
url: /ja/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PPT と PPTX の形式をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---
## **概要**

本稿では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。このガイドでは、必要な手順を解説し、タスクを効率的に実行できるようコード例を提供します。記事の最後までに、以下ができるようになります：

- スピーカーノートを保持したまま、PowerPoint スライドを PDF ドキュメントに変換するプロセスを実装する。
- 出力 PDF をカスタマイズし、スピーカーノートが含まれ、要件に合わせて書式設定されていることを確認する。

エクスポート前にノートページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/java/notes-size/) を参照してください。

## **スピーカーノート付きで PowerPoint を PDF に変換する**

`save` メソッドは、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスで、PPT または PPTX プレゼンテーションをスピーカーノート付きの PDF に変換するために使用できます。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notescommentslayoutingoptions/) クラスを使用してスピーカーノートを含めるレイアウトオプションを設定し、ファイルを PDF として保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライド表示の PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// スピーカーノートのレンダリング用に PDF オプションを設定します。
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // スライドの下にスピーカーノートをレンダリングします。

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// プレゼンテーションをスピーカーノート付き PDF として保存します。
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" title="Note" %}}
Aspose の [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ja/conversion) を確認したいかもしれません。
{{% /alert %}}