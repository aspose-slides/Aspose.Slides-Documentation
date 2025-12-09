---
title: Javaでノート付きPowerPointプレゼンテーションをPDFに変換
linktitle: ノート付きPowerPointからPDFへ
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
- プレゼンテーションからPDFへ
- スライドからPDFへ
- PPTからPDFへ
- PPTXからPDFへ
- プレゼンテーションをPDFとして保存
- PPTをPDFとして保存
- PPTXをPDFとして保存
- PPTをPDFにエクスポート
- PPTXをPDFにエクスポート
- スピーカーノート
- ノート付きPDF
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PPT および PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---

## **概要**

本記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。このガイドでは、必要な手順を解説し、効率的にこのタスクを実行できるようコード例を提供します。この記事の最後までに、以下ができるようになります：

- スピーカーノートを保持しながら、PowerPoint スライドを PDF ドキュメントに変換するプロセスを実装する。
- 出力 PDF をカスタマイズし、スピーカーノートが含まれ、要件に合わせて書式設定されていることを確認する。

## **スピーカーノート付きで PowerPoint を PDF に変換する**

`save` メソッドは、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスで PPT または PPTX プレゼンテーションをスピーカーノート付きの PDF に変換するために使用できます。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/notescommentslayoutingoptions/) クラスでレイアウトオプションを設定してスピーカーノートを含め、最後にファイルを PDF として保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューの PDF に変換する方法を示しています。
```java
Presentation presentation = new Presentation("sample.pptx");

// スピーカーノートを描画するための PDF オプションを設定します。
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // スライドの下にスピーカーノートを描画します。

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// スピーカーノート付きでプレゼンテーションを PDF に保存します。
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```


{{% alert color="primary" %}} 
Aspose の[オンライン PowerPoint から PDF へのコンバータ](https://products.aspose.app/slides/conversion)をご確認ください。 
{{% /alert %}}