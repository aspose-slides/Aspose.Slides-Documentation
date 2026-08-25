---
title: 將 PowerPoint 簡報轉換為 .NET 的 TIFF
titlelink: PowerPoint 轉 TIFF
type: docs
weight: 90
url: /zh-hant/net/convert-powerpoint-to-tiff/
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET，輕鬆將 PowerPoint (PPT、PPTX) 簡報轉換為高品質的 TIFF 圖像。提供 C# 程式碼範例。"
---
## **介紹**

TIFF（**Tagged Image File Format**）是一種廣泛使用的無損點陣圖像格式，以其卓越的品質和對圖形細節的完整保留而聞名。設計師、攝影師以及桌面出版人員常常選擇 TIFF 來保持圖層、色彩準確度與原始設定。

使用 Aspose.Slides，您可以輕鬆將 PowerPoint 投影片 (PPT、PPTX) 與 OpenDocument 投影片 (ODP) 直接轉換為高品質的 TIFF 圖像，確保您的簡報保留最高的視覺忠實度。 

## **將簡報轉換為 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別提供的 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法，您可以快速將整個 PowerPoint 簡報轉換為 TIFF。產生的 TIFF 圖像對應於預設的投影片大小。

以下 C# 程式碼示範如何將 PowerPoint 簡報轉換為 TIFF：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // 將簡報儲存為 TIFF。
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **將簡報轉換為黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/) 類別中的屬性 [BwConversionMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/bwconversionmode/) 允許您指定將彩色投影片或圖像轉換為黑白 TIFF 時所使用的演算法。請注意，僅當 [CompressionType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/compressiontype/) 屬性設定為 `CCITT4` 或 `CCITT3` 時，此設定才會套用。

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode] 是匯出層級的設定，用於為整個 TIFF 圖像選擇像素轉換演算法。若要定義在啟用黑白顯示模式時個別圖形的呈現方式，請使用 [IShape.BlackWhiteMode]。參閱 [控制形狀的黑白呈現](/slides/zh-hant/net/shape-formatting/#control-black-and-white-rendering-for-shapes) 以取得範例。
{{% /alert %}}

假設我們有一個名為「sample.pptx」的檔案，其投影片如下：

![簡報投影片](slide_black_and_white.png)

以下 C# 程式碼示範如何將彩色投影片轉換為黑白 TIFF：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

結果：

![黑白 TIFF](TIFF_black_and_white.png)

## **將簡報轉換為自訂大小的 TIFF**

如果您需要具有特定尺寸的 TIFF 圖像，您可以使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/) 中提供的屬性設定所需的值。例如，[ImageSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/imagesize/) 屬性允許您定義產生圖像的大小。

以下 C# 程式碼示範如何將 PowerPoint 簡報轉換為具有自訂大小的 TIFF 圖像：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // 設定壓縮類型。
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
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
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // 設定影像尺寸。
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // 將簡報以指定尺寸儲存為 TIFF。
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **將簡報轉換為具有自訂像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions) 類別中的 [PixelFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/pixelformat/) 屬性，您可以為產生的 TIFF 圖像指定偏好的像素格式。

以下 C# 程式碼示範如何將 PowerPoint 簡報轉換為具有自訂像素格式的 TIFF 圖像：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化代表簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat 包含以下值（如文件所述）：
        Format1bppIndexed - 每像素 1 位，索引色。
        Format4bppIndexed - 每像素 4 位，索引色。
        Format8bppIndexed - 每像素 8 位，索引色。
        Format24bppRgb    - 每像素 24 位，RGB。
        Format32bppArgb   - 每像素 32 位，ARGB。
    */

    // 以指定的影像尺寸將簡報儲存為 TIFF。
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
請參考 Aspose 的 [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **FAQ**

**我可以將單一投影片而非整個 PowerPoint 簡報轉換為 TIFF 嗎？**

可以。Aspose.Slides 允許您將 PowerPoint 與 OpenDocument 簡報中的單一投影片分別轉換為 TIFF 圖像。

**將簡報轉換為 TIFF 時，投影片數量有任何限制嗎？**

沒有，Aspose.Slides 不會對投影片數量設置任何限制。您可以將任何規模的簡報轉換為 TIFF 格式。

**將投影片轉換為 TIFF 時，PowerPoint 的動畫和過渡效果會被保留嗎？**

不會，TIFF 是靜態圖像格式。因此，動畫與過渡效果不會被保留；僅會匯出投影片的靜態快照。