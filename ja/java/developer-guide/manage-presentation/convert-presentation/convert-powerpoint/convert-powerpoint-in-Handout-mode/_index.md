---
title: JavaでハンドアウトモードでPowerPointプレゼンテーションを変換する
linktitle: ハンドアウトモード
type: docs
weight: 150
url: /ja/java/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- ハンドアウトモード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Javaでプレゼンテーションをハンドアウトに変換します。スライドをページごとに設定し、ノートを保持し、Aspose.SlidesでPDFや画像にエクスポートします。サンプルJavaコード付きです。無料でお試しください。"
---

Aspose.Slides は、プレゼンテーションをさまざまな形式に変換する機能を提供し、Handout モードで印刷用の配布資料を作成することもできます。このモードでは、1 ページに複数のスライドをどのように配置するかを構成でき、会議やセミナー、その他のイベントで便利です。`setSlidesLayoutOptions` メソッドを[IPdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ihtmloptions/) および [ITiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/itiffoptions/) インターフェイスで設定することで、このモードを有効にできます。

Handout モードを構成するには、1 ページに配置するスライド数やその他の表示パラメータを決定する[HandoutLayoutingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。

以下は、Handout モードでプレゼンテーションを PDF に変換するコード例です。
```java
// プレゼンテーションを読み込みます。
Presentation presentation = new Presentation("sample.pptx");
try {
    // エクスポートオプションを設定します。
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 1ページに横方向で4枚のスライド
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // スライド番号を印刷
    slidesLayoutOptions.setPrintFrameSlide(true);                     // スライドの周囲にフレームを印刷
    slidesLayoutOptions.setPrintComments(false);                      // コメントなし

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // 選択したレイアウトでプレゼンテーションをPDFにエクスポートします。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```


{{% alert color="warning" %}} 
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用可能であることに留意してください。
{{% /alert %}}