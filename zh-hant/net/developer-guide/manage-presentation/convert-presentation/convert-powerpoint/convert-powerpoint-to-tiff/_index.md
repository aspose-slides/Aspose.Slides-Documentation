---
title: 在 .NET 中將 PowerPoint 簡報轉換為 TIFF
titlelink: PowerPoint 轉換為 TIFF
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
- PowerPoint 轉換為 TIFF
- 簡報 轉換為 TIFF
- 投影片 轉換為 TIFF
- PPT 轉換為 TIFF
- PPTX 轉換為 TIFF
- 將 PPT 保存為 TIFF
- 將 PPTX 保存為 TIFF
- 將 PPT 匯出為 TIFF
- 将 PPTX 匯出為 TIFF
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 輕鬆將 PowerPoint（PPT、PPTX）簡報轉換為高品質的 TIFF 圖像。提供 C# 程式碼範例。"
---
## **簡介**

TIFF（**Tagged Image File Format**）是一種廣泛使用的無損點陣圖格式，以其卓越的品質和對圖形的細緻保存而聞名。設計師、攝影師與桌面出版人員常選擇 TIFF 以保留圖層、色彩準確度以及原始設定。

使用 Aspose.Slides，您可以輕鬆將 PowerPoint 簡報（PPT、PPTX）和 OpenDocument 簡報（ODP）直接轉換為高品質的 TIFF 圖像，確保簡報保留最高的視覺忠實度。

## **將簡報轉換為 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別提供的 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法，您可以快速將整個 PowerPoint 簡報轉換為 TIFF。產生的 TIFF 圖像對應預設投影片尺寸。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // 將簡報儲存為 TIFF。
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **將簡報轉換為黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/) 類別中的屬性 [BwConversionMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/bwconversionmode/) 允許您指定在將彩色投影片或圖像轉換為黑白 TIFF 時使用的演算法。請注意，僅當 [CompressionType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/compressiontype/) 屬性設定為 `CCITT4` 或 `CCITT3` 時，此設定才會生效。

{{% alert color="info" title="Note" %}}
[TiffOptions.BwConversionMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/bwconversionmode/) 為匯出層級設定，會為完整的 TIFF 圖像選擇像素轉換演算法。若要定義在黑白顯示模式啟用時個別圖形的呈現方式，請使用 [IShape.BlackWhiteMode](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/blackwhitemode/)。有關範例，請參閱 [Control Black-and-White Rendering for Shapes](/net/shape-formatting/#control-black-and-white-rendering-for-shapes)。
{{% /alert %}}

假設我們有一個名為 **sample.pptx** 的檔案，其投影片如下：

![演示投影片](slide_black_and_white.png)

此 C# 程式碼示範如何將彩色投影片轉換為黑白 TIFF：

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

## **將簡報轉換為自訂尺寸的 TIFF**

如果您需要具有特定尺寸的 TIFF 圖像，可以使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/) 中提供的屬性設定所需的值。例如，[ImageSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/imagesize/) 屬性允許您定義產生圖像的大小。

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // 設定壓縮類型。
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
    壓縮類型：
        Default - 指定預設的壓縮方案（LZW）。
        None - 指定不使用壓縮。
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 深度取決於壓縮類型，不能手動設定。

    // 設定影像 DPI。
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // 設定影像大小。
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // 以指定的大小將簡報儲存為 TIFF。
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **將簡報轉換為自訂像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions) 類別的 [PixelFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/pixelformat/) 屬性，您可以為產生的 TIFF 圖像指定偏好的像素格式。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化表示簡報檔案（PPT、PPTX、ODP 等）的 Presentation 類別。
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat 包含以下值（如文件中所述）：
        Format1bppIndexed - 每像素 1 位，索引色。
        Format4bppIndexed - 每像素 4 位，索引色。
        Format8bppIndexed - 每像素 8 位，索引色。
        Format24bppRgb    - 每像素 24 位，RGB。
        Format32bppArgb   - 每像素 32 位，ARGB。
    */

    // 以指定的影像大小將簡報儲存為 TIFF。
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="info" %}}
查看 Aspose 的 [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

**是否可以將單一投影片而非整個 PowerPoint 簡報轉換為 TIFF？**

可以。Aspose.Slides 允許您將 PowerPoint 和 OpenDocument 簡報中的單一投影片分別轉換為 TIFF 圖像。

**在將簡報轉換為 TIFF 時，投影片數量是否有限制？**

沒有，Aspose.Slides 不會對投影片數量設置任何限制。您可以將任意大小的簡報轉換為 TIFF 格式。

**將投影片轉換為 TIFF 時，PowerPoint 動畫和轉場效果會被保留嗎？**

不會，TIFF 是靜態圖像格式。因此，動畫和轉場效果不會被保留，只會匯出投影片的靜態快照。