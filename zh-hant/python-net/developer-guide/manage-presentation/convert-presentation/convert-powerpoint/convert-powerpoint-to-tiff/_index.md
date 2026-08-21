---
title: 在 Python 中將 PowerPoint 簡報轉換為 TIFF
titlelink: PowerPoint 轉換為 TIFF
type: docs
weight: 90
url: /zh-hant/python-net/convert-powerpoint-to-tiff/
keywords:
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換 簡報
- 轉換 投影片
- PowerPoint 轉 TIFF
- OpenDocument 轉 TIFF
- 簡報 轉 TIFF
- 投影片 轉 TIFF
- PPT 轉 TIFF
- PPTX 轉 TIFF
- ODP 轉 TIFF
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET，輕鬆將 PowerPoint (PPT、PPTX) 與 OpenDocument (ODP) 簡報轉換為高品質的 TIFF 圖像。本文提供逐步說明以及程式碼範例。"
---
## **簡介**

TIFF (**Tagged Image File Format**) 是廣泛使用的無失真柵格影像格式，以其卓越的品質和對圖形的細緻保留而聞名。設計師、攝影師與桌面出版人員常選擇 TIFF 以在圖像中保留圖層、色彩精準度與原始設定。

使用 Aspose.Slides，您可以輕鬆將 PowerPoint 投影片（PPT、PPTX）和 OpenDocument 投影片（ODP）直接轉換為高品質的 TIFF 圖像，確保簡報保留最大的視覺真實性。

## **將簡報轉換為 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/#methods) 方法，您可以快速將整個 PowerPoint 簡報轉換為 TIFF。產生的 TIFF 圖像對應於預設的投影片大小。

以下 Python 程式碼示範如何將 PowerPoint 簡報轉換為 TIFF：

```py
import aspose.slides as slides

# 實例化代表簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
with slides.Presentation("presentation.pptx") as presentation:
    # 將簡報儲存為 TIFF。
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **將簡報轉換為黑白 TIFF**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 類別中的屬性 [bw_conversion_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) 允許您指定在將彩色投影片或影像轉換為黑白 TIFF 時所使用的演算法。請注意，僅當 [compression_type](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/compression_type/) 屬性設定為 `CCITT4` 或 `CCITT3` 時，此設定才會生效。

{{% alert color="info" title="注意" %}}

[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) 是一個匯出層級的設定，用於為整個 TIFF 圖像選擇像素轉換演算法。若要定義在黑白顯示模式啟用時個別圖形的顯示方式，請使用 [Shape.black_white_mode](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/black_white_mode/)。請參考 [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes) 取得範例。

{{% /alert %}}

假設我們有一個名為 **sample.pptx** 的檔案，其投影片如下：

![A presentation slide](slide_black_and_white.png)

以下 Python 程式碼示範如何將彩色投影片轉換為黑白 TIFF：

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

結果：

![Black-and-White TIFF](TIFF_black_and_white.png)

## **將簡報轉換為自訂尺寸的 TIFF**

如果您需要特定尺寸的 TIFF 圖像，可以使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 中提供的屬性來設定所需的值。例如，[image_size](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/image_size/) 屬性允許您定義產生圖像的大小。

以下 Python 程式碼示範如何將 PowerPoint 簡報轉換為具有自訂尺寸的 TIFF 圖像：

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# 實例化代表簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # 設定壓縮類型。
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # 設定影像 DPI。
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # 設定影像尺寸。
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # 使用指定尺寸將簡報儲存為 TIFF。
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **將簡報轉換為具自訂影像像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/) 類別中的 [pixel_format](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/tiffoptions/pixel_format/) 屬性，您可以為產生的 TIFF 圖像指定首選的像素格式。

以下 Python 程式碼示範如何將 PowerPoint 簡報轉換為具有自訂像素格式的 TIFF 圖像：

```py
import aspose.slides as slides

# 實例化代表簡報檔案 (PPT、PPTX、ODP 等) 的 Presentation 類別。
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # 使用指定的像素格式將簡報儲存為 TIFF。
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="技巧" color="info" %}}

請查看 Aspose 的 [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}

## **常見問題**

**我可以只轉換單一投影片而不是整個 PowerPoint 簡報為 TIFF 嗎？**

可以。Aspose.Slides 允許您將 PowerPoint 與 OpenDocument 簡報中的單一投影片分別轉換為 TIFF 圖像。

**將簡報轉換為 TIFF 時，投影片數量有任何限制嗎？**

沒有，Aspose.Slides 不對投影片數量施加任何限制。您可以將任意大小的簡報轉換為 TIFF 格式。

**在將投影片轉換為 TIFF 時，PowerPoint 動畫與過渡效果會被保留嗎？**

不會，TIFF 是靜態影像格式。因此，動畫與過渡效果不會被保留；僅會匯出投影片的靜態快照。