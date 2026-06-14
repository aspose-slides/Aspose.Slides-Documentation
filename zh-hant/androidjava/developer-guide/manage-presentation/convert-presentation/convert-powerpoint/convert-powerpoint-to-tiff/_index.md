---
title: 在 Android 上將 PowerPoint 簡報轉換為 TIFF
titlelink: PowerPoint 轉 TIFF
type: docs
weight: 90
url: /zh-hant/androidjava/convert-powerpoint-to-tiff/
keywords:
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 TIFF
- 簡報 轉 TIFF
- 投影片 轉 TIFF
- PPT 轉 TIFF
- PPTX 轉 TIFF
- 將 PPT 儲存為 TIFF
- 將 PPTX 儲存為 TIFF
- 匯出 PPT 為 TIFF
- 匯出 PPTX 為 TIFF
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android，透過 Java 程式碼範例，輕鬆將 PowerPoint（PPT、PPTX）簡報轉換為高品質的 TIFF 圖像。"
---
## **簡介**

TIFF（**Tagged Image File Format**）是一種廣泛使用的無損點陣圖像格式，以其卓越的品質和對圖形細節的完整保留而聞名。設計師、攝影師與桌面出版人員常選擇 TIFF 來維持圖層、顏色精準度以及圖像的原始設定。

使用 Aspose.Slides，您可以輕鬆將 PowerPoint 投影片（PPT、PPTX）和 OpenDocument 投影片（ODP）直接轉換為高品質的 TIFF 圖像，確保簡報保留最大的視覺真實度。

## **將簡報轉換為 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 方法，您可以快速將整個 PowerPoint 簡報轉換為 TIFF。產生的 TIFF 圖像對應於預設的投影片大小。

以下程式碼示範如何將 PowerPoint 簡報轉換為 TIFF：

```java
// 實例化代表簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
Presentation presentation = new Presentation("presentation.pptx");
try {
    // 將簡報儲存為 TIFF。
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **將簡報轉換為黑白 TIFF**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/) 類別中的 [setBwConversionMode](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) 方法允許您指定在將彩色投影片或圖像轉換為黑白 TIFF 時使用的演算法。請注意，此設定僅在 [setCompressionType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) 方法被設定為 `CCITT4` 或 `CCITT3` 時套用。

假設我們有一個名為 "sample.pptx" 的檔案，其投影片如下：

![A presentation slide](slide_black_and_white.png)

以下程式碼示範如何將彩色投影片轉換為黑白 TIFF：

```java
TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

轉換結果：

![Black-and-White TIFF](TIFF_black_and_white.png)

## **將簡報轉換為自訂大小的 TIFF**

如果您需要特定尺寸的 TIFF 圖像，可以使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/) 中提供的方法設定所需的值。例如，[setImageSize](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) 方法允許您定義產生圖像的大小。

以下程式碼示範如何將 PowerPoint 簡報轉換為具自訂大小的 TIFF 圖像：

```java
// 實例化代表簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // 設定壓縮類型。
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    壓縮類型：
        Default - 指定預設的壓縮方案 (LZW)。
        None - 指定不使用壓縮。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 深度取決於壓縮類型，且無法手動設定。

    // 設定影像 DPI。
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // 設定影像尺寸。
    tiffOptions.setImageSize(new Size(1728, 1078));

    INotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 以指定尺寸將簡報儲存為 TIFF。
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **將簡報轉換為自訂像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/) 類別的 [setPixelFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) 方法，您可以為產生的 TIFF 圖像指定首選的像素格式。

以下程式碼示範如何將 PowerPoint 簡報轉換為具自訂像素格式的 TIFF 圖像：

```java
// 實例化代表簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat 包含以下值（如文件所述）：
        Format1bppIndexed - 每像素 1 位，索引色。
        Format4bppIndexed - 每像素 4 位，索引色。
        Format8bppIndexed - 每像素 8 位，索引色。
        Format24bppRgb    - 每像素 24 位，RGB。
        Format32bppArgb   - 每像素 32 位，ARGB。
    */
    
    // 以指定的影像尺寸將簡報儲存為 TIFF。
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
查看 Aspose 提供的[免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

**我可以只將單一投影片而不是整個 PowerPoint 簡報轉換為 TIFF 嗎？**

可以。Aspose.Slides 允許您將 PowerPoint 和 OpenDocument 簡報中的個別投影片分別轉換為 TIFF 圖像。

**在將簡報轉換為 TIFF 時，投影片數量有限制嗎？**

沒有，Aspose.Slides 不會對投影片數量設置任何限制，您可以將任何規模的簡報轉換為 TIFF 格式。

**將投影片轉換為 TIFF 時，PowerPoint 動畫和過場效果會被保留嗎？**

不會，TIFF 是靜態圖像格式。因此，動畫與過場效果不會被保留，只會匯出投影片的靜態快照。