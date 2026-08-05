---
title: 使用 Python 變更簡報的投影片尺寸
linktitle: 投影片尺寸
type: docs
weight: 70
url: /zh-hant/python-net/slide-size/
keywords:
- 投影片尺寸
- 長寬比
- 標準
- 寬螢幕
- 4:3
- 16:9
- 設定投影片尺寸
- 變更投影片尺寸
- 自訂投影片尺寸
- 特殊投影片尺寸
- 獨特投影片尺寸
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
description: "了解如何使用 Python 與 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，優化簡報以適應任何螢幕而不失真。"
---
## **簡介**

Aspose.Slides 提供完整的工具，用於調整 PowerPoint 簡報的投影片尺寸與長寬比，這對於列印與螢幕顯示皆相當重要。

常見的投影片尺寸與比例：

- **標準 (4:3 長寬比)**：適合較舊的螢幕與裝置。
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機與顯示器。

確保整個簡報保持一致，因為單一的投影片尺寸與長寬比會套用至所有投影片。為取得最佳效果，請在建立簡報時一開始就設定投影片尺寸，以免日後產生問題。

{{% alert color="primary" %}} 
預設情況下，由 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **變更簡報的投影片尺寸**

此範例程式碼示範如何在 Python 中使用 Aspose.Slides 變更簡報的投影片尺寸：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **指定自訂投影片尺寸**

如果常見的投影片尺寸（4:3 與 16:9）無法滿足您的需求，您可以選擇使用特定或獨特的投影片尺寸。例如，若您打算在自訂版面上列印全尺寸投影片，或是要在特定類型的螢幕上顯示簡報，使用自訂尺寸設定將非常有幫助。

此範例程式碼示範如何在 Python（透過 .NET）使用 Aspose.Slides 為簡報指定自訂投影片尺寸：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 紙張尺寸
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **變更尺寸後處理投影片內容**

在調整簡報的投影片尺寸後，投影片內的內容（例如影像或物件）可能會出現變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，變更投影片尺寸時，您可以指定一個設定，以決定 Aspose.Slides 如何處理投影片上的內容。

依照您的需求，可使用以下任一設定：

- `DO_NOT_SCALE`

  如果您不希望投影片上的物件被重新調整大小，請使用此設定。

- `ENSURE_FIT`

  如果您希望縮小投影片尺寸，且需要 Aspose.Slides 縮小投影片內的物件以確保全部內容都能容納於投影片中（這樣可避免遺失內容），請使用此設定。

- `MAXIMIZE`

  如果您希望放大投影片尺寸，且需要 Aspose.Slides 放大投影片內的物件，使其與新的投影片尺寸成比例，請使用此設定。

此範例程式碼示範如何在變更簡報投影片尺寸時使用 `MAXIMIZE` 設定：

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **常見問題**

**我可以使用除英吋以外的單位（例如點或毫米）設定自訂投影片尺寸嗎？**

可以。Aspose.Slides 內部使用點作為單位，1 點等於 1/72 英吋。您可以將任何單位（例如毫米或公分）轉換為點，然後使用轉換後的數值定義投影片的寬度與高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）結合較高的渲染比例會導致記憶體消耗增加與處理時間變長。建議採用實際可行的投影片尺寸，僅在需要提高輸出品質時調整渲染比例。

**我可以定義一個非標準的投影片尺寸，然後合併來自尺寸不同的簡報嗎？**

您無法在投影片尺寸不同的情況下直接[合併簡報](/slides/zh-hant/python-net/merge-presentation/)，必須先將其中一個簡報的尺寸調整與另一個匹配。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesizescaletype/)選項決定如何處理現有內容。對齊尺寸後，即可在保留格式的情況下合併投影片。

**我可以為單一形狀或投影片的特定區域產生縮圖，且它們會遵循新的投影片尺寸嗎？**

可以。Aspose.Slides 能夠為[整張投影片](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/)以及[已選取的形狀](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/)產生縮圖。產生的圖像會反映當前的投影片尺寸與長寬比，確保框架與幾何形狀一致。