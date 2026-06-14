---
title: 將 PowerPoint 簡報轉換為 TIFF（使用 PHP）
titlelink: PowerPoint 轉 TIFF
type: docs
weight: 90
url: /zh-hant/php-java/convert-powerpoint-to-tiff/
keywords:
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 TIFF
- 簡報轉 TIFF
- 投影片轉 TIFF
- PPT 轉 TIFF
- PPTX 轉 TIFF
- 將 PPT 儲存為 TIFF
- 將 PPTX 儲存為 TIFF
- 匯出 PPT 為 TIFF
- 匯出 PPTX 為 TIFF
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP (透過 Java) 輕鬆將 PowerPoint (PPT、PPTX) 簡報轉換為高品質的 TIFF 圖像，並附有程式碼範例。"
---
## **介紹**

TIFF（**Tagged Image File Format**）是一種廣泛使用的無損光柵影像格式，以其卓越的品質和對圖形的細緻保留而聞名。設計師、攝影師與桌面出版人常選擇 TIFF 以保留圖層、色彩精準度以及影像的原始設定。

使用 Aspose.Slides，您可以輕鬆將 PowerPoint 投影片（PPT、PPTX）與 OpenDocument 投影片（ODP）直接轉換為高品質的 TIFF 影像，確保您的簡報保留最高的視覺真實度。 

## **將簡報轉換為 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/#save) 方法，您可以快速將整個 PowerPoint 簡報轉換為 TIFF。產生的 TIFF 影像對應預設的投影片尺寸。

此程式碼示範如何將 PowerPoint 簡報轉換為 TIFF：

```php
// 實例化代表簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
$presentation = new Presentation("presentation.pptx");
try {
    // 將簡報儲存為 TIFF。
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **將簡報轉換為黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 類別中的方法 [setBwConversionMode](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/#setBwConversionMode) 允許您指定在將彩色投影片或影像轉換為黑白 TIFF 時使用的演算法。請注意，只有當 [setCompressionType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/#getCompressionType) 方法設定為 `CCITT4` 或 `CCITT3` 時，此設定才會生效。

假設我們有一個 "sample.pptx" 檔案，其中包含以下投影片：

![簡報投影片](slide_black_and_white.png)

此程式碼示範如何將彩色投影片轉換為黑白 TIFF：

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

結果：

![黑白 TIFF](TIFF_black_and_white.png)

## **將簡報轉換為自訂尺寸的 TIFF**

如果您需要具有特定尺寸的 TIFF 影像，可以使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 中提供的方法設定所需的值。例如，[setImageSize](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/#getImageSize) 方法允許您定義產生影像的尺寸。

此程式碼示範如何將 PowerPoint 簡報轉換為具有自訂尺寸的 TIFF 影像：

```php
// 實例化代表簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // 設定壓縮類型。
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    壓縮類型：
        Default - 指定預設的壓縮方案 (LZW)。
        None - 表示不使用壓縮。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 位深度取決於壓縮類型，無法手動設定。

    // 設定影像 DPI。
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // 設定影像尺寸。
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // 以指定尺寸將簡報儲存為 TIFF。
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **將簡報轉換為自訂影像像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/) 類別的 [setPixelFormat](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/tiffoptions/#getPixelFormat) 方法，您可以為產生的 TIFF 影像指定偏好的像素格式。

此程式碼示範如何將 PowerPoint 簡報轉換為具有自訂像素格式的 TIFF 影像：

```php
// 實例化代表簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat 包含以下值（如文件所述）：
        Format1bppIndexed - 每像素 1 位，索引色。
        Format4bppIndexed - 每像素 4 位，索引色。
        Format8bppIndexed - 每像素 8 位，索引色。
        Format24bppRgb    - 每像素 24 位，RGB。
        Format32bppArgb   - 每像素 32 位，ARGB。
    */

    // 以指定的影像尺寸將簡報儲存為 TIFF。
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="primary" %}}

看看 Aspose 的 [免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **常見問題**

**我可以將單一投影片而非整個 PowerPoint 簡報轉換為 TIFF 嗎？**

可以。Aspose.Slides 允許您將 PowerPoint 與 OpenDocument 簡報中的單張投影片分別轉換為 TIFF 影像。

**在將簡報轉換為 TIFF 時，投影片數量有任何限制嗎？**

沒有，Aspose.Slides 不會對投影片數量設定任何限制。您可以將任何規模的簡報轉換為 TIFF 格式。

**在將投影片轉換為 TIFF 時，PowerPoint 動畫和轉場效果會被保留嗎？**

不會，TIFF 是靜態影像格式。因此，動畫與轉場效果不會被保留；僅會匯出投影片的靜態快照。