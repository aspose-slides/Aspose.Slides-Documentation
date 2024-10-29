---
title: PowerPointをTIFFに変換
type: docs
weight: 90
url: /ja/java/convert-powerpoint-to-tiff/
keywords: "PowerPointプレゼンテーションの変換, PowerPointからTIFF, PPTからTIFF, PPTXからTIFF, Java, Aspose.Slides"
description: "JavaでPowerPointプレゼンテーションをTIFFに変換"

---

**TIFF**（タグ付き画像ファイル形式）は、ロスレスのラスターおよび高品質な画像形式です。プロフェッショナルは、デザイン、写真、およびデスクトップパブリッシングの目的でTIFFを使用します。たとえば、デザインや画像のレイヤーや設定を保持したい場合は、作業をTIFF画像ファイルとして保存することをお勧めします。

Aspose.Slidesを使用すると、PowerPointのスライドを直接TIFFに変換できます。

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料PowerPointからPosterへの変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をぜひご利用ください。

{{% /alert %}}

## **PowerPointをTIFFに変換**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスによって公開されている[Save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-)メソッドを使用すると、PowerPointプレゼンテーション全体を素早くTIFFに変換できます。生成されたTIFF画像は、スライドのデフォルトサイズに対応します。

このJavaコードは、PowerPointをTIFFに変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("presentation.pptx");
try {
    // プレゼンテーションをTIFFとして保存します
    pres.save("tiff-image.tiff", SaveFormat.Tiff);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPointを白黒TIFFに変換**

Aspose.Slides 23.10では、[TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/)クラスに新しいプロパティ（[BwConversionMode](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-)）が追加され、カラーのスライドや画像が白黒TIFFに変換される際に従うアルゴリズムを指定できるようになりました。この設定は、[CompressionType](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setCompressionType-int-)プロパティが`CCITT4`または`CCITT3`に設定されている場合にのみ適用されます。

このJavaコードは、カラーのスライドや画像を白黒TIFFに変換する方法を示しています：

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

## **カスタムサイズのTIFFにPowerPointを変換**

定義されたサイズのTIFF画像が必要な場合は、[TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/)で提供されるプロパティを使用してお好みのサイズを定義できます。たとえば、[ImageSize](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)プロパティを使用して、生成される画像のサイズを設定できます。

このJavaコードは、カスタムサイズのTIFF画像にPowerPointを変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("presentation.pptx");
try {
    // TiffOptionsクラスをインスタンス化します
    TiffOptions opts = new TiffOptions();
    
    // 圧縮タイプを設定します
    // 可能な値は以下の通りです：
    // Default - デフォルトの圧縮方式（LZW）を指定します。
    // None - 圧縮なしを指定します。
    // CCITT3
    // CCITT4
    // LZW
    // RLE
    opts.setCompressionType(TiffCompressionTypes.Default);
    
    // Depth – 圧縮タイプに依存し、手動で設定することはできません。
    
    // 画像のDPIを設定します
    opts.setDpiX(200);
    opts.setDpiY(100);
    
    // 画像サイズを設定します
    opts.setImageSize(new java.awt.Dimension(1728, 1078));
    
    INotesCommentsLayoutingOptions options = opts.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);
    // 指定したサイズでプレゼンテーションをTIFFとして保存します
    pres.save("tiff-ImageSize.tiff", SaveFormat.Tiff, opts);
} finally {
    if (pres != null) pres.dispose();
}    
```

## **カスタム画像ピクセル形式のTIFFにPowerPointを変換**

[TiffOptions](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/)クラスの[PixelFormat](https://reference.aspose.com/slides/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-)プロパティを使用して、生成されるTIFF画像の好みのピクセル形式を指定できます。

このJavaコードは、カスタムピクセル形式でPowerPointをTIFF画像に変換する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation("presentation.pptx");
try {
    TiffOptions options = new TiffOptions();
    options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    
    /*
     * ImagePixelFormatには以下の値が含まれます（ドキュメントに記載されています）：
     * Format1bppIndexed; // 1ピクセルあたり1ビット、インデックス方式。
     * Format4bppIndexed; // 1ピクセルあたり4ビット、インデックス方式。
     * Format8bppIndexed; // 1ピクセルあたり8ビット、インデックス方式。
     * Format24bppRgb;    // 1ピクセルあたり24ビット、RGB。
     * Format32bppArgb;   // 1ピクセルあたり32ビット、ARGB。
     */
    
    // 指定された画像サイズでプレゼンテーションをTIFFとして保存します
    pres.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, options);
} finally {
    if (pres != null) pres.dispose();
}
```