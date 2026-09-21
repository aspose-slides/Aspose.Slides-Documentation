---
title: PHPでPDF文書を編集
linktitle: PDFを編集
type: docs
weight: 65
url: /ja/php-java/edit-pdf/
keywords:
- PDFを編集
- PDFテキストの置換
- PDFからPPTXへ
- PPTXからPDFへ
- PHP
- Aspose.Slides
description: "PDF文書をPHPでAspose.Slidesにインポートし、テキストを置換して、変更されたプレゼンテーションをPDFとして保存します。"
---
## **概要**

Aspose.Slides for PHP via Java を使用すると、PDF のページをスライドとしてインポートし、プレゼンテーションを変更して、PDF に再エクスポートすることで PDF コンテンツを編集できます。この記事では、簡単なテキスト置換を示します。プレゼンテーションはメモリ上に保持されるため、中間の PPTX ファイルを保存する必要は任意です。

## **PDF のテキスト置換**

ページをインポートするには [SlideCollection::addFromPdf](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slidecollection/#addFromPdf) を使用し、テキストを更新するには [Presentation::replaceText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#replaceText) を使用し、結果をエクスポートするには [Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) を使用します。

以下の例は、インポート後に `input.pdf` に「Draft」という編集可能なテキストが含まれていることを想定しています。その単語を「Final」に置き換えて `edited.pdf` として書き出します。インポート前に最初のスライドをクリアすることで、出力に余分な空白ページが入るのを防ぎます。検索は同一ケースの完全な単語にマッチします。`null` は結果コールバックが不要であることを意味します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

その他のオプションについては、[テキストの検索と置換](/slides/ja/php-java/search-and-replace-text/) および [PowerPoint を PDF に変換](/slides/ja/php-java/convert-powerpoint-to-pdf/) を参照してください。

{{% alert color="info" title="Note" %}}
テキスト置換はインポートされたテキストに対して機能し、スキャンした画像内のテキストには適用されません。変換によりレイアウトや書式が変わる可能性があるため、特に置換後のテキストが元のテキストより長い場合は出力を確認してください。
{{% /alert %}}

## **よくある質問**

**PDF をエクスポートする前に PPTX ファイルを保存する必要がありますか？**

いいえ。メモリ上の同じプレゼンテーションを編集してエクスポートできます。PowerPoint で引き続き編集したい場合のみ PPTX のコピーを保存してください。詳細は [プレゼンテーションの保存](/slides/ja/php-java/save-presentation/) を参照してください。

**なぜ一部のテキストが変更されないままになることがありますか？**

この例は、完全一致で大文字小文字を区別した「Draft」という単語にマッチします。画像としてインポートされたテキストや、別々のテキストフレームに分割されたテキストは検索に一致しない場合があります。インポートされたコンテンツを確認し、ドキュメントに合わせて検索条件を調整してください。