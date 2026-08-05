---
title: Java を使用したハンドアウト モードでの PowerPoint プレゼンテーションの変換
linktitle: ハンドアウト モード
type: docs
weight: 150
url: /ja/java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- ハンドアウト モード
- ハンドアウト
- PPT
- PPTX
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java でプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF や画像にエクスポートできます。サンプル Java コード付きです。無料でお試しください。"
---
## **はじめに**

Aspose.Slides を使用すると、ハンドアウト モードに対応した出力形式にプレゼンテーションを変換できます。このモードでは、複数のスライドが 1 ページに配置され、会議やセミナーなどの資料を印刷する際に便利です。

ハンドアウト モードは `setSlidesLayoutOptions` メソッドで設定します。このメソッドは [IPdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihtmloptions/) および [ITiffOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiffoptions/) で利用可能です。ハンドアウトのレイアウトを定義するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。

## **ハンドアウト モードのエクスポート**

ハンドアウト モードでプレゼンテーションをエクスポートするには、対象のエクスポート オプションで `setSlidesLayoutOptions` メソッドを設定し、1 ページあたりのスライド数や表示パラメータを定義する [HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handoutlayoutingoptions/) インスタンスを割り当てます。

以下は、ハンドアウト モードでプレゼンテーションを PDF に変換するコード例です。

```java
// プレゼンテーションを読み込む。
Presentation presentation = new Presentation("sample.pptx");
try {
    // エクスポート オプションを設定。
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // 1 ページに横方向に 4 スライド
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // スライド番号を印刷
    slidesLayoutOptions.setPrintFrameSlide(true);                     // スライドの周囲に枠線を印刷
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
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウト モードでページあたりのスライド サムネイルの最大数は何ですか？**

Aspose.Slides は、[presets](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handouttype/) を利用して、横方向または縦方向の順序でページあたり最大 9 枚のサムネイルをサポートします。利用可能なレイアウトは 1、2、3、4（横/縦）、6（横/縦）、9（横/縦）です。

**5 枚や 8 枚など、カスタム グリッドを定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handouttype/) クラスによって厳密に制御されており、任意のレイアウトはサポートされていません。

**隠しスライドをハンドアウトの出力に含めることはできますか？**

はい。対象のフォーマット用エクスポート設定（例: [PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/)、[TiffOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tiffoptions/)）で `setShowHiddenSlides` メソッドを有効にすれば、隠しスライドを含めることができます。