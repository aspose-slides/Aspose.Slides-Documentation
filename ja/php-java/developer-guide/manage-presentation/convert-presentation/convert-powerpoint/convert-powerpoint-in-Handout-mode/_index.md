---
title: PHP を使用した Handout モードで PowerPoint プレゼンテーションを変換
linktitle: Handout モード
type: docs
weight: 150
url: /ja/php-java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- ハンドアウト モード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP でプレゼンテーションをハンドアウトに変換します。スライド数をページごとに設定し、ノートを保持し、Aspose.Slides for PHP を使用して PDF または画像にエクスポートします。サンプルコード付き。無料でお試しください。"
---

## **配布資料モードのエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、配布資料モードで印刷用のハンドアウトを作成することもできます。このモードでは、複数のスライドを 1 ページにどのように配置するかを設定でき、会議やセミナー、その他のイベントで便利です。`setSlidesLayoutOptions` メソッドを、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/)、および [TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/) クラスで設定することで、このモードを有効にできます。

Handout モードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1 ページに配置されるスライド数やその他の表示パラメータを決定します。

以下は、配布資料モードでプレゼンテーションを PDF に変換するコード例です。
```php
// プレゼンテーションを読み込みます。
$presentation = new Presentation("sample.pptx");

// Set the export options.
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 1ページに横方向で4枚のスライド
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // スライド番号を印刷
$slidesLayoutOptions->setPrintFrameSlide(true);                      // スライドの周囲に枠を印刷
$slidesLayoutOptions->setPrintComments(false);                       // コメントなし

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```


{{% alert color="warning" %}} 
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式および画像としてレンダリングする場合にのみ利用可能です。
{{% /alert %}} 

## **よくある質問**

**配布資料モードで 1 ページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) をサポートしており、1 ページあたり最大 9 枚のサムネイルを水平または垂直に配置できます。利用できる設定は、1、2、3、4（水平/垂直）、6（水平/垂直）、9（水平/垂直）です。

**5 枚や 8 枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/php-java/aspose.slides/handouttype/) クラスで厳密に制御されており、任意のレイアウトはサポートされていません。

**配布資料の出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で `setShowHiddenSlides` メソッドを使用して非表示スライドを有効にできます。例: [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/)。