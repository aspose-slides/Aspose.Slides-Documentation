---
title: Java でノート付き PowerPoint プレゼンテーションを PDF に変換
linktitle: PowerPoint をノート付き PDF に変換
type: docs
weight: 50
url: /ja/java/convert-powerpoint-to-pdf-with-notes/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PPT および PPTX 形式をノート付き PDF に変換します。レイアウトとスピーカーノートを保持し、プロフェッショナルなプレゼンテーションを実現します。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションをスピーカーノート付きの PDF 形式に変換する方法を学びます。このガイドでは、必要な手順を説明し、タスクを効率的に実行できるようにコード例を提供します。記事の最後まで読むと、以下ができるようになります。

- PowerPoint スライドを PDF ドキュメントに変換し、スピーカーノートを保持するプロセスを実装する。
- 出力 PDF をカスタマイズし、スピーカーノートが要件に合わせて含まれ、フォーマットされるようにする。

## **PowerPoint をノート付き PDF に変換する**

`save` メソッドは [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスで、PPT または PPTX プレゼンテーションをスピーカーノート付きの PDF に変換するために使用できます。Aspose.Slides を使用すると、プレゼンテーションをロードし、[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/notescommentslayoutingoptions/) クラスでレイアウトオプションを構成してスピーカーノートを含め、最後にファイルを PDF として保存するだけです。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューの PDF に変換する方法を示しています。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

// スピーカーノートをレンダリングするための PDF オプションを設定します。
NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(NotesPositions.BottomFull); // スライドの下にスピーカーノートをレンダリングします。

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

// スピーカーノート付きでプレゼンテーションを PDF に保存します。
presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

{{% alert color="info" %}} 

Aspose の [オンライン PowerPoint から PDF へのコンバータ](https://products.aspose.app/slides/ja/conversion) をご確認ください。 

{{% /alert %}}