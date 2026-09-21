---
title: Android で PDF 文書を編集
linktitle: PDF を編集
type: docs
weight: 65
url: /ja/androidjava/edit-pdf/
keywords:
- PDF を編集
- PDF テキストの置換
- PDF から PPTX へ
- PPTX から PDF へ
- Android
- Java
- Aspose.Slides
description: "Java を使用して Android で PDF 文書を編集し、Aspose.Slides にインポートしてテキストを置換し、変更されたプレゼンテーションを PDF として保存します。"
---
## **概要**

Aspose.Slides for Android via Java を使用すると、PDF のページをスライドとしてインポートし、プレゼンテーションを変更してから PDF にエクスポートすることで、PDF のコンテンツを編集できます。この記事では、シンプルなテキスト置換の方法を示します。プレゼンテーションはメモリ上に保持されるため、途中の PPTX ファイルを保存する必要はありません。

## **PDF のテキスト置換**

[addFromPdf](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) を使用してページをインポートし、[replaceText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) でテキストを更新し、[save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) で結果をエクスポートします。

以下の例は、`input.pdf` にインポート後に編集可能なテキストとして「Draft」という単語が含まれていることを前提としています。この単語を「Final」に置換し、`edited.pdf` として保存します。インポート前に最初のスライドをクリアすることで、出力に余分な空白ページが入らないようにします。検索は同一ケースの完全一致単語にマッチします。`null` は結果コールバックが不要であることを示します。

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

詳細なオプションについては、[Search and Replace Text](/slides/ja/androidjava/search-and-replace-text/) と [Convert PowerPoint to PDF](/slides/ja/androidjava/convert-powerpoint-to-pdf/) を参照してください。

{{% alert color="info" title="Note" %}}
テキスト置換はインポートされたテキストに対してのみ機能し、スキャンされた画像内のテキストには適用されません。変換によりレイアウトや書式が変わる可能性があるため、特に置換後のテキストが元のテキストより長い場合は出力結果を必ず確認してください。
{{% /alert %}}

## **FAQ**

**PDF をエクスポートする前に PPTX ファイルを保存する必要がありますか？**

いいえ。メモリ上の同じプレゼンテーションを編集してそのままエクスポートできます。PowerPoint で引き続き編集したい場合のみ、PPTX のコピーを保存してください。詳細は [Save Presentations](/slides/ja/androidjava/save-presentation/) を参照してください。

**一部のテキストが変更されないのはなぜですか？**

この例では、完全一致かつケースが一致する単語「Draft」のみを検索対象としています。画像としてインポートされたテキストや、別々のテキストフレームに分割されたテキストは検索にヒットしないことがあります。インポートされたコンテンツを確認し、ドキュメントに合わせて検索条件を調整してください。