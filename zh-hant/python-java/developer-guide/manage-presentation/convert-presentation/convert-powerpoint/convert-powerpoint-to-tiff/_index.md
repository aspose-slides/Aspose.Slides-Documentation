---
title: 將 PowerPoint 簡報轉換為 TIFF（Python）
linktitle: PowerPoint 轉 TIFF
type: docs
weight: 90
url: /zh-hant/python-java/convert-powerpoint-to-tiff/
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
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java，輕鬆將 PowerPoint (PPT, PPTX) 簡報轉換為高品質的 TIFF 圖像，並附有程式碼範例。"
---
## **簡介**

TIFF (**Tagged Image File Format**) 是一種光柵圖像格式，支援多頁和無損壓縮。它適用於將渲染的投影片儲存在單一圖像檔案中。

使用 Aspose.Slides for Python via Java，您可以將 PowerPoint (PPT, PPTX) 與 OpenDocument (ODP) 簡報轉換為 TIFF。以下每個範例皆在需要時啟動 Java 虛擬機器，並在使用後釋放簡報。

## **將簡報轉換為 TIFF**

使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別提供的 [save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法，您可以快速將整個 PowerPoint 簡報轉換為 TIFF。產生的多頁 TIFF 包含每張投影片在預設尺寸下的渲染圖像。

此程式碼示範如何將 PowerPoint 簡報轉換為 TIFF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # 將所有投影片儲存為多頁 TIFF 檔案。
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **將簡報轉換為黑白 TIFF**

在 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/) 類別中的方法 [setBwConversionMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/#setBwConversionMode) 允許您指定將彩色投影片或影像轉換為黑白 TIFF 時使用的演算法。請注意，此設定僅在 [setCompressionType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/#setCompressionType) 方法被設定為 [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) 或 [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) 時才會套用。

{{% alert color="info" title="注意" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/#setBwConversionMode) 是一個匯出層級的設定，用於為完整的 TIFF 圖像選擇像素轉換演算法。若要定義在黑白顯示模式下個別圖形的呈現方式，請使用 [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#setBlackWhiteMode)。請參閱 [Control Black-and-White Rendering for Shapes](/slides/zh-hant/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) 以取得範例。
{{% /alert %}}

假設我們有一個名為 "sample.pptx" 的檔案，其投影片如下：

![投影片示例](slide_black_and_white.png)

此程式碼示範如何將彩色投影片轉換為黑白 TIFF：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

結果：

![黑白 TIFF](TIFF_black_and_white.png)

## **將簡報轉換為自訂尺寸的 TIFF**

如果您需要具備特定尺寸的 TIFF 圖像，您可以使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/) 中可用的方法設定所需值。例如，[setImageSize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/#setImageSize) 方法允許您定義產生圖像的尺寸。

此程式碼示範如何將 PowerPoint 簡報轉換為自訂尺寸的 TIFF 圖像：

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # 設定水平與垂直解析度。
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # 設定輸出尺寸（以像素為單位）。
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # 在每張投影片下方加入完整的講者備註。
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **將簡報轉換為自訂圖像像素格式的 TIFF**

使用 [TiffOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/) 類別中的 [setPixelFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/tiffoptions/#setPixelFormat) 方法，您可以為產生的 TIFF 圖像指定首選的像素格式。

此程式碼示範如何將 PowerPoint 簡報轉換為具自訂像素格式的 TIFF 圖像：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="提示" color="success" %}}
請查看 Aspose 的 [免費 PowerPoint 轉海報轉換器](https://products.aspose.app/slides/zh-hant/conversion/convert-ppt-to-poster-online)。
{{% /alert %}}

## **常見問題**

**我可以將單一投影片而非整個 PowerPoint 簡報轉換為 TIFF 嗎？**

可以。Aspose.Slides 允許您將 PowerPoint 與 OpenDocument 簡報中的單一投影片分別轉換為 TIFF 圖像。

**在將簡報轉換為 TIFF 時，投影片數量有任何限制嗎？**

TIFF 匯出沒有固定的投影片數量上限。可用記憶體、投影片的複雜度以及輸出尺寸會影響您能處理的簡報大小。

**在將投影片轉換為 TIFF 時，PowerPoint 的動畫和過場效果會被保留嗎？**

不會，TIFF 是靜態圖像格式。因此，動畫和過場效果不會被保留；僅會匯出投影片的靜態快照。