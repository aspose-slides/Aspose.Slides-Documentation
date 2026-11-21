---
title: Android でノート付き PowerPoint プレゼンテーションを PDF に変換
linktitle: ノート付き PowerPoint を PDF に変換
type: docs
weight: 50
url: /ja/androidjava/convert-powerpoint-to-pdf-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用して、PPT および PPTX をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを作成できます。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。このガイドでは、必要な手順を説明し、タスクを効率的に実行できるようコード例を提供します。この記事の最後までに、以下ができるようになります：

- スライドの変換プロセスを実装し、スピーカーノートを保持したまま PowerPoint スライドを PDF ドキュメントに変換できるようになります。
- 出力 PDF をカスタマイズして、スピーカーノートが含まれ、要件に合わせてフォーマットされていることを保証できます。

エクスポート前にノートページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/androidjava/notes-size/) を参照してください。

## **ノート付きで PowerPoint を PDF に変換**

`save` メソッドは、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスで、PPT または PPTX プレゼンテーションをスピーカーノート付きの PDF に変換するために使用できます。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/notescommentslayoutingoptions/) クラスを使用してスピーカーノートを含めるレイアウトオプションを設定し、ファイルを PDF として保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライド表示の PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
	// スピーカーノートをレンダリングするための PDF オプションを設定します。
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // スライドの下にスピーカーノートを描画します。

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// スピーカーノート付きでプレゼンテーションを PDF に保存します。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose の [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ja/conversion) をチェックしたいかもしれません。
{{% /alert %}}