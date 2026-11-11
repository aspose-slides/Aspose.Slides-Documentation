---
title: Change the Slide Size in Presentations with Python
linktitle: Slide Size
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
description: "了解如何使用 Python 與 Aspose.Slides 迅速調整 PPT、PPTX 與 ODP 檔案中的投影片大小，為任何螢幕最佳化簡報且不失真。"
---
## **簡介**

Aspose.Slides 提供全面的工具，用於調整 PowerPoint 簡報的投影片大小與長寬比，對於列印與螢幕顯示皆相當重要。

常見的投影片尺寸與比例：

- **標準 (4:3 長寬比)**：適用於較舊的螢幕和裝置。
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機和顯示器。

確保簡報全程保持一致，因為所有投影片皆使用相同的尺寸與長寬比。為獲得最佳效果，請在建立簡報之初就設定投影片尺寸，以免產生問題。

{{% alert color="info" title="Note" %}}
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

註腳與講義頁面的尺寸與一般投影片不同。請參閱[註腳頁面大小](/slides/zh-hant/python-net/notes-size/)以變更其尺寸與方向。

## **變更簡報的投影片大小**

 此範例程式碼示範如何在 Python 中使用 Aspose.Slides 變更簡報的投影片大小：
```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **指定自訂投影片尺寸**

如果您發現常見的投影片尺寸（4:3 與 16:9）不適合您的需求，您可以決定使用特定或獨特的投影片尺寸。例如，若您打算在自訂版面上列印全尺寸投影片，或是希望在特定類型的螢幕上展示簡報，使用自訂尺寸設定將對您有所幫助。

此範例程式碼示範如何在 Python 中透過 .NET 使用 Aspose.Slides 來為簡報指定自訂投影片尺寸：
```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 紙張大小
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **調整投影片大小後的內容處理**

在變更簡報的投影片大小後，投影片的內容（例如影像或物件）可能會失真。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，在變更簡報的投影片大小時，您可以指定一個設定，決定 Aspose.Slides 如何處理投影片上的內容。

根據您的需求或目標，您可以使用以下任一設定：

- `DO_NOT_SCALE`
  
  如果您不希望投影片上的物件被調整大小，請使用此設定。

- `ENSURE_FIT`
  
  如果您想縮小投影片尺寸，且需要 Aspose.Slides 將投影片的物件縮小以確保全部內容能容納於投影片內（避免遺失內容），請使用此設定。

- `MAXIMIZE`
  
  如果您想放大投影片尺寸，且需要 Aspose.Slides 將投影片的物件放大，使其與新的投影片尺寸成比例，請使用此設定。

此範例程式碼示範如何在變更簡報投影片尺寸時使用 `MAXIMIZE` 設定：
```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **常見問題**

**是否可以使用除英吋以外的單位（例如點或毫米）設定自訂投影片尺寸？**

可以。Aspose.Slides 內部使用點 (point) 作為單位，1 point 等於 1/72 英吋。您可以將任何單位（例如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度與高度。

**非常大的自訂投影片尺寸會影響算繪時的效能與記憶體使用量嗎？**

會。較大的投影片尺寸（以點為單位）加上較高的算繪比例，會導致記憶體消耗增加與處理時間變長。請以實用的投影片尺寸為目標，僅在需要提升輸出品質時調整算繪比例。

**我能定義單一非標準投影片尺寸，然後合併來自不同尺寸簡報的投影片嗎？**

當簡報的投影片尺寸不同時，您無法[合併簡報](/slides/zh-hant/python-net/merge-presentation/)。必須先將其中一個簡報的尺寸調整與另一個相同。變更投影片尺寸時，您可以透過[SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slidesizescaletype/)選項選擇如何處理現有內容。尺寸對齊後，即可在保留格式的前提下合併投影片。

**我可以為投影片的單一圖形或特定區域產生縮圖，且它們會遵循新的投影片尺寸嗎？**

可以。Aspose.Slides 能為[整張投影片](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/get_image/)以及[選取的圖形](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/get_image/)產生縮圖。產生的圖像會反映當前的投影片尺寸與長寬比，確保構圖與幾何的一致性。