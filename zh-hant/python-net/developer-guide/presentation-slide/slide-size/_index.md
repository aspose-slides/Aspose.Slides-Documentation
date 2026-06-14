---
title: 使用 Python 變更簡報的投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/python-net/slide-size/
keywords:
- 投影片大小
- 長寬比
- 標準
- 寬螢幕
- 4:3
- 16:9
- 設定投影片大小
- 變更投影片大小
- 自訂投影片大小
- 特殊投影片大小
- 獨特投影片大小
- 全尺寸投影片
- 螢幕類型
- 不縮放
- 確保適合
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
descriptions: "了解如何使用 Python 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，為任何螢幕優化簡報且不失真。"
---
## **Introduction**

Aspose.Slides 提供完整的工具，以調整 PowerPoint 簡報中的投影片大小和長寬比，對列印和螢幕顯示皆相當重要。

常見的投影片大小與比例：

- **Standard (4:3 長寬比)**：適用於較舊的螢幕和裝置。
- **Widescreen (16:9 長寬比)**：建議用於現代投影機和顯示器。

確保整份簡報的一致性，因為單一的投影片大小和長寬比會套用到所有投影片。為獲得最佳效果，請在建立簡報之初就設定投影片尺寸，以免產生後續的複雜問題。

{{% alert color="primary" %}} 
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **Change the Slide Size in a Presentation**

此範例程式碼示範如何在 Python 中使用 Aspose.Slides 變更簡報的投影片大小：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Specify Custom Slide Sizes**

如果您發現常見的投影片大小（4:3 與 16:9）不符合需求，您可以選擇使用特定或自訂的投影片尺寸。例如，若您打算在自訂頁面排版上列印完整尺寸的投影片，或是希望在特定類型的螢幕上顯示簡報，使用自訂尺寸設定將對您有所幫助。

此範例程式碼示範如何在 Python（透過 .NET）使用 Aspose.Slides 為簡報指定自訂的投影片大小：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 紙張大小
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Handle Slide Content After Resizing**

變更簡報的投影片大小後，投影片內容（例如圖像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，在變更投影片大小時，您可以指定設定，決定 Aspose.Slides 如何處理投影片上的內容。

根據您的需求或目標，您可以使用以下任何設定：

- `DO_NOT_SCALE`
  
  若您 **不** 想讓投影片上的物件被重新調整大小，請使用此設定。

- `ENSURE_FIT`
  
  若您欲縮小投影片尺寸，且需要 Aspose.Slides 將投影片物件縮小，使其全部適合於投影片（以避免遺失內容），請使用此設定。

- `MAXIMIZE`
  
  若您欲放大投影片尺寸，且需要 Aspose.Slides 將投影片物件放大，使其與新的投影片尺寸成比例，請使用此設定。

此範例程式碼示範在變更簡報投影片大小時，如何使用 `MAXIMIZE` 設定：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**

是的。Aspose.Slides 在內部使用點（point）作為單位，1 點等於 1/72 英吋。您可以將任何單位（例如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

**Will a very large custom slide size affect performance and memory usage during rendering?**

會的。較大的投影片尺寸（以點為單位）加上較高的渲染比例，會導致記憶體使用量增加且處理時間延長。請保持實用的投影片尺寸，並僅在必要時調整渲染比例，以取得所需的輸出品質。

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**

在投影片大小不同的情況下，無法 [merge presentations](/slides/zh-hant/python-net/merge-presentation/)。必須先將其中一個簡報的尺寸調整為與另一個相同。變更投影片大小時，您可以透過 [SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesizescaletype/) 選項選擇如何處理現有內容。尺寸對齊後，您即可在保留格式的前提下合併投影片。

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**

是的。Aspose.Slides 可以為 [整張投影片](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/)以及 [選取的圖形](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/)產生縮圖。產生的圖像會反映目前的投影片大小與長寬比，確保框架與幾何形狀的一致性。