---
title: Android でハンドアウトモードの PowerPoint プレゼンテーションを変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint を変換
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
description: "Java でプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides for Android を使用して PDF または画像にエクスポートします。サンプルコード付きです。無料でお試しください。"
---
## **はじめに**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、ハンドアウトモードで印刷用のハンドアウトを作成することもできます。このモードでは、1 ページに複数のスライドをどのように配置するかを設定でき、会議やセミナー、その他のイベントで便利です。`setSlidesLayoutOptions` メソッドを[IPdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihtmloptions/)、および[ITiffOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiffoptions/)インターフェイスで設定することで、このモードを有効にできます。

## **ハンドアウトモードのエクスポート**

ハンドアウトモードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1 ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、ハンドアウトモードでプレゼンテーションを PDF に変換するコード例です。

```java
// プレゼンテーションを読み込む。
Presentation presentation = new Presentation("sample.pptx");
try {
	// エクスポートオプションを設定。
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 1 ページに横方向で 4 スライド
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // スライド番号を印刷
	slidesLayoutOptions.setPrintFrameSlide(true);                     // スライドの周囲に枠を印刷
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
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF など特定の出力形式や画像としてレンダリングする場合にのみ利用可能であることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウトモードで 1 ページあたり表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、横順または縦順の配置で、1 ページあたり最大 9 枚のサムネイルをサポートする[presets](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/handouttype/) を提供しています。利用可能な設定は、1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5 枚や 8 枚など、カスタムグリッドを定義できますか？**

いいえ。サムネイルの数と順序は[HandoutType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/handouttype/) クラスで厳密に管理されており、任意のレイアウトはサポートされていません。

**ハンドアウトの出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定（例: [PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmloptions/)、または[TiffOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/)）で`setShowHiddenSlides` メソッドを有効にすることで、非表示スライドを含めることができます。