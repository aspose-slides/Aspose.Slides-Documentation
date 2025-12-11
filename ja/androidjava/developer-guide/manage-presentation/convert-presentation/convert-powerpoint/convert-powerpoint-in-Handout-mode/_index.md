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
description: "Javaでプレゼンテーションをハンドアウトに変換します。1ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides for Androidを使用してPDFまたは画像にエクスポートします。サンプルコード付きです。無料でお試しください。"
---

## **ハンドアウトモードエクスポート**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用ハンドアウトを作成することもできます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議やセミナー、その他のイベントに便利です。このモードは、[IPdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihtmloptions/)、および[ITiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itiffoptions/) インターフェイスで `setSlidesLayoutOptions` メソッドを設定することで有効にできます。

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。これにより、1ページに配置するスライド数やその他の表示パラメーターを決定できます。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。
```java
// プレゼンテーションを読み込む。
Presentation presentation = new Presentation("sample.pptx");
try {
	// エクスポートオプションを設定する。
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 1ページに横方向で4枚のスライド
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // スライド番号を印刷
	slidesLayoutOptions.setPrintFrameSlide(true);                     // スライドの周囲にフレームを印刷
	slidesLayoutOptions.setPrintComments(false);                      // コメントなし

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// 選択したレイアウトでプレゼンテーションを PDF にエクスポート。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```


{{% alert color="warning" %}} 
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式や画像としてレンダリングする場合にのみ利用可能であることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウトモードで1ページあたり表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) により、横方向または縦方向の並び順で最大 9 つのサムネイルを1ページに表示できます。利用可能なオプションは、1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5枚や8枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と並び順は [HandoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/handouttype/) クラスで厳密に制御されており、任意のレイアウトはサポートされていません。

**ハンドアウト出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で `setShowHiddenSlides` メソッドを使用して非表示スライドを有効にできます。たとえば、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/) です。