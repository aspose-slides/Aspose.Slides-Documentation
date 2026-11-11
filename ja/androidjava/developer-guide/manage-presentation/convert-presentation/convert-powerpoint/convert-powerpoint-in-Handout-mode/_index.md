---
title: Android でハンドアウトモードの PowerPoint プレゼンテーションを変換
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/androidjava/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- ハンドアウト モード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java でプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides for Android を使用して PDF または画像にエクスポートします。サンプルコード付きです。無料で試すことができます。"
---
## **はじめに**

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供します。これには、配布資料モードで印刷用のハンドアウトを作成することも含まれます。このモードでは、1ページに複数のスライドをどのように配置するかを設定でき、会議やセミナーなどのイベントで便利です。`setSlidesLayoutOptions` メソッドを、[IPdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ihtmloptions/)、[ITiffOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiffoptions/) インターフェイスで設定することで、このモードを有効にできます。

エクスポート前に配布資料ページのサイズと向きを設定するには、[Notes Page Size](/slides/ja/androidjava/notes-size/)をご覧ください。

## **配布資料モードのエクスポート**

配布資料モードを構成するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。このオブジェクトは、1ページに配置するスライド数やその他の表示パラメータを決定します。

以下は、配布資料モードでプレゼンテーションを PDF に変換するコード例です。

```java
import com.aspose.slides.*;

// プレゼンテーションを読み込む。
Presentation presentation = new Presentation("sample.pptx");
try {
	// エクスポート オプションを設定する。
	HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
	slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 1ページに横方向でスライドを4枚配置
	slidesLayoutOptions.setPrintSlideNumbers(true);                   // スライド番号を印刷
	slidesLayoutOptions.setPrintFrameSlide(true);                     // スライドの周囲に枠を印刷
	slidesLayoutOptions.setPrintComments(false);                      // コメントなし

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

	// 選択したレイアウトでプレゼンテーションを PDF にエクスポートする。
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ使用できることに留意してください。
{{% /alert %}}

## **FAQ**

**配布資料モードで1ページあたり配置できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/handouttype/) により、横方向または縦方向の順序で最大 9 枚のサムネイルをページに配置できます: 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）。

**5 枚や 8 枚など、カスタムグリッドを定義できますか？**

できません。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/handouttype/) クラスで厳密に管理されており、任意のレイアウトはサポートされていません。

**配布資料の出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で `setShowHiddenSlides` メソッドを有効にします。例: [PdfOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tiffoptions/)。