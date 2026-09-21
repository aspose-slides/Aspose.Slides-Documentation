---
title: JavaScript で PDF ドキュメントを編集
linktitle: PDF を編集
type: docs
weight: 65
url: /ja/nodejs-java/edit-pdf/
keywords:
- PDF を編集
- PDF テキストの置換
- PDF から PPTX へ
- PPTX から PDF へ
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript で PDF ドキュメントを Aspose.Slides にインポートし、テキストを置換して、変更されたプレゼンテーションを PDF として保存します。"
---
## **概要**

Aspose.Slides for Node.js via Java は、PDF のページをスライドとしてインポートし、プレゼンテーションを編集して再び PDF にエクスポートすることで、PDF コンテンツを編集できます。本記事では、簡単なテキスト置換の方法を示します。プレゼンテーションはメモリ上に保持されるため、途中で PPTX ファイルを保存する必要は任意です。

## **PDF内のテキスト置換**

[addFromPdf](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/slidecollection/#addFromPdf) を使用してページをインポートし、[replaceText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#replaceText) でテキストを更新し、[save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) で結果をエクスポートします。

次の例では、`input.pdf` にインポート後に編集可能なテキストとして「Draft」という単語が含まれていることを前提としています。この単語を「Final」に置換し、`edited.pdf` として書き出します。インポート前に最初のスライドをクリアすることで、出力に余分な空白ページが入るのを防ぎます。検索は大文字小文字を区別した完全一致（単語単位）です。`null` は結果コールバックが不要であることを意味します。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

さらに詳しいオプションについては、[Search and Replace Text](/slides/ja/nodejs-java/search-and-replace-text/) と [Convert PowerPoint to PDF](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/) を参照してください。

{{% alert color="info" title="Note" %}}
テキスト置換はインポートされたテキストに対してのみ機能し、スキャン画像内のテキストには適用されません。変換によりレイアウトや書式が変わる可能性があるため、特に置換後のテキストが元のテキストより長い場合は、出力結果を必ず確認してください。
{{% /alert %}}

## **よくある質問**

**PDFにエクスポートする前にPPTXファイルを保存する必要がありますか？**

いいえ。メモリ上の同じプレゼンテーションを編集してエクスポートできます。PowerPoint で引き続き編集したい場合のみ、PPTX のコピーを保存してください。詳しくは [Save Presentations](/slides/ja/nodejs-java/save-presentation/) を参照してください。

**なぜ一部のテキストが変更されないままになることがありますか？**

この例では、完全一致かつ大文字小文字が同一の単語「Draft」のみを対象としています。画像としてインポートされたテキストや、別々のテキストフレームに分割されたテキストは検索に一致しない可能性があります。インポートされたコンテンツを確認し、ドキュメントに合わせて検索条件を調整してください。