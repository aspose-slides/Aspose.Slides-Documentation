---
title: 將 PowerPoint 簡報轉換為 TIFF（JavaScript）
titlelink: PowerPoint 轉 TIFF
type: docs
weight: 90
url: /zh-hant/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js，透過 JavaScript 程式碼範例，輕鬆將 PowerPoint (PPT、PPTX) 簡報轉換為高品質的 TIFF 影像。"
---
## **簡介**

TIFF (**Tagged Image File Format**) 是一種廣泛使用的無損點陣圖影像格式，以其卓越的品質和圖形細節保存而聞名。設計師、攝影師與桌面出版人員常選擇 TIFF 來保留圖層、顏色精確度以及原始設定。

使用 Aspose.Slides，您可以輕鬆將 PowerPoint 投影片 (PPT、PPTX) 與 OpenDocument 投影片 (ODP) 直接轉換為高品質的 TIFF 影像，確保簡報保有最高的視覺忠實度。

## **將簡報轉換為 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) 方法，您可以快速將整個 PowerPoint 簡報轉換為 TIFF。產生的 TIFF 影像對應預設投影片尺寸。

以下 JavaScript 程式碼示範如何將 PowerPoint 簡報轉換為 TIFF：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化表示簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // 將簡報儲存為 TIFF。
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **將簡報轉換為黑白 TIFF**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 類別中的 [setBwConversionMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) 方法允許您指定將彩色投影片或影像轉換為黑白 TIFF 時使用的演算法。請注意，僅當 [setCompressionType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) 方法設定為 `CCITT4` 或 `CCITT3` 時，此設定才會生效。

{{% alert color="info" title="注意" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) 是匯出層級的設定，會為整個 TIFF 影像選擇像素轉換演算法。若要在啟用黑白顯示模式時定義單一圖形的呈現方式，請使用 [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#setBlackWhiteMode)。請參考 [控制黑白渲染形狀](/slides/zh-hant/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) 以取得範例。
{{% /alert %}}

假設我們有一個名為「sample.pptx」的檔案，其投影片內容如下：

![簡報投影片](slide_black_and_white.png)

以下 JavaScript 程式碼示範如何將彩色投影片轉換為黑白 TIFF：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

結果：

![黑白 TIFF](TIFF_black_and_white.png)

## **將簡報轉換為自訂尺寸的 TIFF**

若您需要特定尺寸的 TIFF 影像，可使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 中提供的方法設定所需數值。例如，[setImageSize](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/#setImageSize) 方法允許您定義最終影像的大小。

以下 JavaScript 程式碼示範如何將 PowerPoint 簡報轉換為自訂尺寸的 TIFF 影像：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 實例化表示簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // 設定壓縮類型。
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    壓縮類型：
        Default - 指定預設的壓縮方案 (LZW)。
        None - 指定無壓縮。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 顏色深度由像素格式控制（請參見下方範例）；CCITT3 與 CCITT4 總是產生每像素 1 位元。

    // 設定影像 DPI。
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // 設定影像尺寸。
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 以指定尺寸將簡報儲存為 TIFF。
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **將簡報轉換為自訂影像像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/) 類別的 [setPixelFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) 方法，您可以為產生的 TIFF 影像指定偏好的像素格式。

以下 JavaScript 程式碼示範如何將 PowerPoint 簡報轉換為具自訂像素格式的 TIFF 影像：

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 實例化表示簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat 包含以下值（如文件中所述）：
        Format1bppIndexed - 每像素 1 位元，索引模式。
        Format4bppIndexed - 每像素 4 位元，索引模式。
        Format8bppIndexed - 每像素 8 位元，索引模式。
        Format24bppRgb    - 每像素 24 位元，RGB。
        Format32bppArgb   - 每像素 32 位元，ARGB。
    */

    /// 以指定的影像尺寸將簡報儲存為 TIFF。
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="提示" color="info" %}}
請參考 Aspose 的 [免費 PowerPoint 海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

**是否可以只轉換單一投影片而非整個 PowerPoint 簡報為 TIFF？**

可以。Aspose.Slides 允許您將 PowerPoint 與 OpenDocument 簡報中的單張投影片單獨轉換為 TIFF 影像。

**轉換簡報為 TIFF 時，有沒有投影片數量的限制？**

沒有，Aspose.Slides 不會對投影片數量設定任何限制。您可以將任何規模的簡報轉換為 TIFF 格式。

**在將投影片轉換為 TIFF 時，PowerPoint 的動畫與過渡效果會被保留嗎？**

不會，TIFF 是靜態影像格式。因此，動畫與過渡效果不會被保留，僅會匯出投影片的靜態快照。