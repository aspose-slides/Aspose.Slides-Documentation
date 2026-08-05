---
title: PHP を使用したハンドアウトモードでの PowerPoint プレゼンテーションの変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/php-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- ハンドアウトモード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PHP でプレゼンテーションをハンドアウトに変換します。1ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides for PHP を使用して PDF または画像にエクスポートします。サンプルコード付き。無料でお試しください。"
---
## **はじめに**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドを配置する方法を設定できるため、会議、セミナー、その他のイベントで便利です。`setSlidesLayoutOptions` メソッドを設定することで、このモードを有効にできます。対象のクラスは [PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/)、[RenderingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/renderingoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/)、および [TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) です。

## **ハンドアウトモードのエクスポート**

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。

```php
// プレゼンテーションをロードします。
$presentation = new Presentation("sample.pptx");

// エクスポートオプションを設定します。
$slidesLayoutOptions = new HandoutLayoutingOptions();
$slidesLayoutOptions->setHandout(HandoutType::Handouts4Horizontal);  // 1ページに横方向に4枚のスライド
$slidesLayoutOptions->setPrintSlideNumbers(true);                    // スライド番号を印刷
$slidesLayoutOptions->setPrintFrameSlide(true);                      // スライドの周囲に枠を印刷
$slidesLayoutOptions->setPrintComments(false);                       // コメントなし

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($slidesLayoutOptions);

// 選択したレイアウトでプレゼンテーションを PDF にエクスポート。
$presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
$presentation->dispose();
```

{{% alert color="warning" %}} 
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウトモードで1ページあたりのスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/ja/php-java/aspose.slides/handouttype/) をサポートしており、横または縦の順序で1ページあたり最大9枚のサムネイルを配置できます。利用可能なオプションは 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/handouttype/) クラスで厳密に制御されており、任意のレイアウトはサポートされていません。

**ハンドアウト出力に非表示スライドを含めることはできますか？**

はい。`setShowHiddenSlides` メソッドを使用して、[PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tiffoptions/) など、対象形式のエクスポート設定で非表示スライドを有効にしてください。