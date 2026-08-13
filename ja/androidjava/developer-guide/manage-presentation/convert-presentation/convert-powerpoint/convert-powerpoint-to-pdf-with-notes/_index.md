---
title: Androidでノート付きPowerPointプレゼンテーションをPDFに変換
linktitle: ノート付きPowerPointからPDFへ
type: docs
weight: 50
url: /ja/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android（Java）を使用して、PPT および PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---
## **概要**

本記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。このガイドでは必要な手順を解説し、タスクを効率的に実行できるコード例を提供します。記事の最後まで読むと、以下ができるようになります。

- PowerPoint スライドをスピーカーノートを保持したまま PDF ドキュメントに変換するプロセスを実装できるようになります。
- 出力 PDF をカスタマイズし、スピーカーノートが要求どおりに含まれ、書式設定されるようにできるようになります。

## **PowerPoint をノート付き PDF に変換**

`save` メソッドは、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスで使用でき、PPT または PPTX プレゼンテーションをスピーカーノート付き PDF に変換します。Aspose.Slides を使用すると、プレゼンテーションを読み込み、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notescommentslayoutingoptions/) クラスでレイアウトオプションを設定してスピーカーノートを含め、ファイルを PDF として保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューの PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// スピーカーノートのレンダリング用にPDFオプションを設定します。
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // スライドの下にスピーカーノートを表示します。

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// スピーカーノート付きでプレゼンテーションをPDFに保存します。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" %}}Aspose のオンライン PowerPoint から PDF への変換ツールをご確認ください。{{% /alert %}}