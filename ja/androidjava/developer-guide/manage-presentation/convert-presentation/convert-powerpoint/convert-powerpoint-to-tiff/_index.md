---
title: PowerPointをTIFFに変換
type: docs
weight: 90
url: /ja/androidjava/convert-powerpoint-to-tiff/
keywords: "PowerPointプレゼンテーションの変換, PowerPointをTIFFに, PPTをTIFFに, PPTXをTIFFに, Java, Aspose.Slides"
description: "JavaでPowerPointプレゼンテーションをTIFFに変換"

---

**TIFF**（Tagged Image File Format）は、ロスレスラスタおよび高品質の画像フォーマットです。専門家はデザイン、写真、デスクトップパブリッシングの目的でTIFFを使用します。たとえば、デザインや画像のレイヤーや設定を保持したい場合は、作業をTIFF画像ファイルとして保存することをお勧めします。

Aspose.Slidesを使用すると、PowerPointのスライドを直接TIFFに変換できます。

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料PowerPointからポスタ変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をチェックしてみてください。

{{% /alert %}}

## **PowerPointをTIFFに変換**

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスが公開する[Save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)メソッドを利用することで、全体のPowerPointプレゼンテーションを迅速にTIFFに変換できます。生成されるTIFF画像は、スライドのデフォルトサイズに対応します。

このJavaコードは、PowerPointをTIFFに変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("presentation.pptx");
try {
    // プレゼンテーションをTIFFとして保存
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPointを白黒TIFFに変換**

Aspose.Slides 23.10では、[TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/)クラスに新しいプロパティ（[BwConversionMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)）が追加され、カラースライドや画像を白黒TIFFに変換する際に使用されるアルゴリズムを指定できます。この設定は、[CompressionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-)プロパティが`CCITT4`または`CCITT3`に設定されている場合にのみ適用されます。

このJavaコードは、カラースライドや画像を白黒TIFFに変換する方法を示しています：

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **カスタムサイズでPowerPointをTIFFに変換**

定義された寸法のTIFF画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/)で提供されるプロパティを通じて好みの数値を定義できます。たとえば、[ImageSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)プロパティを使用すると、生成される画像のサイズを設定できます。

このJavaコードは、カスタムサイズでPowerPointをTIFF画像に変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("presentation.pptx");
try {
    // TiffOptionsクラスをインスタンス化
    TiffOptions opts = new TiffOptions();
    
    // 圧縮タイプを設定
    // 可能な値：
    // Default - デフォルトの圧縮スキーム（LZW）を指定します。
    // None - 圧縮なしを指定します。
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // Depth – 圧縮タイプに依存し、手動で設定できません。
    
    // 画像のDPIを設定
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // 画像サイズを設定
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // 指定されたサイズでプレゼンテーションをTIFFに保存
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```


## **カスタム画像ピクセル形式でPowerPointをTIFFに変換**

[TiffOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/)クラスの[PixelFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-)プロパティを使用することで、生成されるTIFF画像の好ましいピクセル形式を指定できます。

このJavaコードは、カスタムピクセル形式でPowerPointをTIFF画像に変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormatには、以下の値が含まれます（ドキュメントに記載）：
     * Format1bppIndexed; // 1ビット/ピクセル、インデックス化。
     * Format4bppIndexed; // 4ビット/ピクセル、インデックス化。
     * Format8bppIndexed; // 8ビット/ピクセル、インデックス化。
     * Format24bppRgb;    // 24ビット/ピクセル、RGB。
     * Format32bppArgb;   // 32ビット/ピクセル、ARGB。
     */
    
    // 指定された画像サイズでプレゼンテーションをTIFFに保存
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```