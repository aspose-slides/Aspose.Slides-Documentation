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
description: "Java でプレゼンテーションをハンドアウトに変換します。ページあたりのスライド数を設定し、ノートを保持し、Aspose.Slides を使用して PDF または画像にエクスポートします。サンプル Java コード付きです。無料でお試しください。"
---
## **はじめに**

Aspose.Slides を使用すると、ハンドアウト モードに対応した出力形式にプレゼンテーションを変換できます。このモードでは、複数のスライドが 1 ページに配置され、会議やセミナーなどのプレゼンテーション資料を印刷する際に便利です。

ハンドアウト モードは `setSlidesLayoutOptions` メソッドで構成します。このメソッドは [IPdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipdfoptions/)、[IRenderingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/irenderingoptions/)、[IHtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ihtmloptions/)、[ITiffOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiffoptions/) で利用できます。ハンドアウトのレイアウトを定義するには、[HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handoutlayoutingoptions/) オブジェクトを使用します。

エクスポート前にハンドアウトのページサイズと向きを設定するには、[Notes Page Size](/slides/ja/java/notes-size/) を参照してください。

## **ハンドアウト モードのエクスポート**

ハンドアウト モードでプレゼンテーションをエクスポートするには、対象のエクスポート オプションに対して `setSlidesLayoutOptions` メソッドを設定し、1 ページあたりのスライド数や表示パラメータを定義する [HandoutLayoutingOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handoutlayoutingoptions/) インスタンスを割り当てます。

以下は、ハンドアウト モードでプレゼンテーションを PDF に変換するコード例です。

```java
import com.aspose.slides.*;

// プレゼンテーションを読み込みます。
Presentation presentation = new Presentation("sample.pptx");
try {
    // エクスポート オプションを設定します。
    HandoutLayoutingOptions slidesLayoutOptions = new HandoutLayoutingOptions();
    slidesLayoutOptions.setHandout(HandoutType.Handouts4Horizontal);  // ページあたり 4 スライドを横方向に配置
    slidesLayoutOptions.setPrintSlideNumbers(true);                   // スライド番号を印刷
    slidesLayoutOptions.setPrintFrameSlide(true);                     // スライドの周囲にフレームを印刷
    slidesLayoutOptions.setPrintComments(false);                      // コメントはなし

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(slidesLayoutOptions);

    // 選択したレイアウトでプレゼンテーションを PDF にエクスポートします。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

{{% alert color="warning" title="Warning" %}}
`setSlidesLayoutOptions` メソッドは、PDF、HTML、TIFF などの特定の出力形式、または画像としてレンダリングする場合にのみ利用できることに注意してください。
{{% /alert %}} 

## **よくある質問**

**ハンドアウト モードでページあたりに表示できるスライドサムネイルの最大数は何ですか？**

Aspose.Slides は、水平または垂直の順序でページあたり最大 9 枚のサムネイルをサポートする [presets](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handouttype/) を提供します。具体的には、1、2、3、4（水平/垂直）、6（水平/垂直）、9（水平/垂直）です。

**5 枚や 8 枚など、カスタム グリッド（ページあたりのスライド数）を定義できますか？**

いいえ。サムネイルの数と順序は [HandoutType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/handouttype/) クラスで厳密に管理されており、任意のレイアウトはサポートされていません。

**ハンドアウト出力に非表示スライドを含めることはできますか？**

はい。対象フォーマットのエクスポート設定で `setShowHiddenSlides` メソッドを使用して非表示スライドを有効にできます。たとえば、[PdfOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/htmloptions/)、または [TiffOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tiffoptions/) などです。