---
title: AndroidでハンドアウトモードのPowerPointプレゼンテーションを変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/androidjava/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- ハンドアウトモード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Javaでプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides for Android を使用して PDF または画像にエクスポートします。サンプルコード付き。無料でお試しください。"
---

## **ハンドアウトモードエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議、セミナー、その他のイベントに便利です。`setSlidesLayoutOptions` メソッドを、[IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/)、および [ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) インターフェイスで設定することで、このモードを有効にできます。

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。
```java
// プレゼンテーションをロードします。
Presentation presentation = new Presentation("sample.pptx");
try {
	// エクスポートオプションを設定します。
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 1ページに横方向で4枚のスライド
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // スライド番号を印刷
	slidesLayoutOptions.setPrintFrameSlide(true);                     // スライドの周囲に枠線を印刷
	slidesLayoutOptions.setPrintComments(false);                      // コメントなし

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```


{{% alert color="warning" %}} 
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ使用できることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウトモードでページあたり最大何枚のスライドサムネイルを表示できますか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) をサポートしており、水平または垂直の順序でページあたり最大9枚のサムネイルを配置できます：1、2、3、4（水平/垂直）、6（水平/垂直）、9（水平/垂直）。

**ページあたり5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は、[HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) クラスで厳密に制御されており、任意のレイアウトはサポートされていません。

**ハンドアウトの出力に非表示スライドを含めることはできますか？**

はい。`setShowHiddenSlides` メソッドを使用して、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) など、対象フォーマットのエクスポート設定で非表示スライドを有効にできます。