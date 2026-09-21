---
title: JavaでPDFドキュメントを編集
linktitle: PDFを編集
type: docs
weight: 65
url: /ja/java/edit-pdf/
keywords:
- PDFを編集
- PDFテキストを置換
- PDFからPPTXへ
- PPTXからPDFへ
- Java
- Aspose.Slides
description: "Aspose.Slides にインポートし、テキストを置換して、変更されたプレゼンテーションを PDF に再保存することで、Javaで PDF ドキュメントを編集します。"
---
## **概要**

Aspose.Slides for Java は、PDF のページをスライドとしてインポートし、プレゼンテーションを変更してから再び PDF にエクスポートすることで PDF コンテンツを編集できます。この記事ではシンプルなテキスト置換の方法を示します。プレゼンテーションはメモリ内に保持されるため、中間の PPTX ファイルを保存するかどうかは任意です。

## **PDF のテキスト置換**

[addFromPdf](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) を使用してページをインポートし、[replaceText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) でテキストを更新し、[save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) で結果をエクスポートします。

以下の例では、インポート後に `input.pdf` に編集可能なテキストとして「Draft」という単語が含まれていることを前提としています。この単語を「Final」に置換し、`edited.pdf` として書き出します。インポート前に最初のスライドをクリアしておくと、出力に余分な空白ページが追加されるのを防げます。検索は同じ大文字小文字で完全一致する単語にマッチします。`null` は結果コールバックが不要であることを意味します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

他のオプションについては、[テキストの検索と置換](/slides/ja/java/search-and-replace-text/) と [PowerPoint を PDF に変換](/slides/ja/java/convert-powerpoint-to-pdf/) を参照してください。

{{% alert color="info" title="Note" %}}
テキスト置換はインポートされたテキストに対してのみ機能し、スキャンした画像内のテキストには適用されません。変換によりレイアウトや書式が変わる可能性があるため、特に置換後のテキストが元のテキストより長い場合は、出力を必ず確認してください。
{{% /alert %}}

## **FAQ**

**PDF をエクスポートする前に PPTX ファイルを保存する必要がありますか？**

いいえ。メモリ内の同じプレゼンテーションを編集してエクスポートできます。PowerPoint で引き続き編集したい場合のみ、PPTX のコピーを保存してください。詳しくは [プレゼンテーションの保存](/slides/ja/java/save-presentation/) を参照してください。

**なぜ一部のテキストが変更されないままになることがありますか？**

この例では、完全一致かつ同一の大文字小文字で「Draft」という単語を検索しています。画像としてインポートされたテキストや、別々のテキストフレームに分割されているテキストは検索に一致しない可能性があります。インポートされたコンテンツを確認し、ドキュメントに合わせて検索条件を調整してください。