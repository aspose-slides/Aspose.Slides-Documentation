---
title: PHPでハンドアウトモードを使用してPowerPointプレゼンテーションを変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/php-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint変換
- プレゼンテーション変換
- ハンドアウトモード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHPでプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides for PHPでPDFまたは画像にエクスポートします。サンプルコード付き。無料でお試しください。"
---
## **はじめに**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議やセミナー、その他のイベントに便利です。`setSlidesLayoutOptions` メソッドを [PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) クラスで設定することで、このモードを有効にできます。

エクスポート前にハンドアウトページのサイズと方向を設定するには、[Notes Page Size](/slides/ja/php-java/notes-size/) を参照してください。

## **ハンドアウトモードのエクスポート**

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。

```php
// プレゼンテーションを読み込みます。
$presentation = new Presentation("sample.pptx");

// エクスポートオプションを設定します。
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 1ページに横方向で4枚のスライド
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // スライド番号を印刷
$slidesLayoutOptions->setPrintFrameSlide(true);                      // スライドの周囲にフレームを印刷
$slidesLayoutOptions->setPrintComments(false);                       // コメントなし

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// 選択したレイアウトでプレゼンテーションをPDFにエクスポートします。
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用可能であることに留意してください。
{{% /alert %}} 

## **FAQ**

**ハンドアウトモードで1ページあたり表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/ja/php-java/aspose.slides/handouttype/) に対応しており、横または縦の順序でページあたり最大 9 つのサムネイルを配置できます: 1、2、3、4（横/縦）、6（横/縦）、および 9（横/縦）。

**5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/handouttype/) クラスで厳密に制御されており、任意のレイアウトはサポートされていません。

**隠しスライドをハンドアウトの出力に含めることはできますか？**

はい。`setShowHiddenSlides` メソッドを使用して、[PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) など、対象フォーマットのエクスポート設定で隠しスライドを有効にできます。