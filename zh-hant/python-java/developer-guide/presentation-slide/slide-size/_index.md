---
title: "使用 Python via Java 更改簡報投影片大小"
linktitle: "投影片大小"
type: docs
weight: 70
url: /zh-hant/python-java/slide-size/
keywords:
- "投影片大小"
- "長寬比"
- "標準"
- "寬螢幕"
- "4:3"
- "16:9"
- "設定投影片大小"
- "變更投影片大小"
- "自訂投影片大小"
- "特殊投影片大小"
- "獨特投影片大小"
- "全尺寸投影片"
- "螢幕類型"
- "不縮放"
- "確保適合"
- "最大化"
- "PowerPoint"
- "OpenDocument"
- "簡報"
- "Python"
- "Java"
- "Aspose.Slides"
description: "了解如何使用 Python via Java 及 Aspose.Slides 快速調整 PPT、PPTX 和 ODP 檔案中的投影片大小，並在不失真情況下為任何螢幕優化簡報。"
---
## **簡介**

Aspose.Slides 提供完整的工具來調整 PowerPoint 簡報的投影片大小和長寬比，對於列印與螢幕顯示皆相當重要。

常見的投影片尺寸與比例：

- **標準 (4:3 長寬比)**：適用於較舊的螢幕和裝置。
- **寬螢幕 (16:9 長寬比)**：建議用於現代投影機和顯示器。

確保整份簡報的一致性，因為單一的投影片大小與長寬比會套用到所有投影片。為取得最佳效果，請在簡報製作初期即設定投影片尺寸，以避免後續的問題。

{{% alert color="info" title="Note" %}}
預設情況下，使用 Aspose.Slides 建立的簡報採用標準的 4:3 長寬比。
{{% /alert %}}

備註與講義頁面的尺寸與一般投影片不同。請參閱[備註頁面大小](/slides/zh-hant/python-java/notes-size/)以變更其尺寸和方向。

## **變更簡報中的投影片大小**

以下範例程式碼示範如何在使用 Aspose.Slides 的 Python（via Java）環境中變更簡報的投影片大小：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **在簡報中指定自訂投影片大小**

如果您發現常見的投影片尺寸（4:3 與 16:9）不符合需求，您可以選擇使用特定或獨特的投影片大小。例如，若您打算將簡報的投影片以自訂版面的方式完整列印，或是要在特定螢幕上顯示簡報，使用自訂尺寸設定將對您有幫助。

以下範例程式碼示範如何使用 Aspose.Slides for Python via Java 為簡報指定自訂投影片大小：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **調整大小後的投影片內容處理**

在變更簡報的投影片大小後，投影片內容（例如影像或物件）可能會變形。預設情況下，物件會自動調整大小以適應新的投影片尺寸。然而，在變更投影片大小時，您可以指定設定，以決定 Aspose.Slides 如何處理投影片中的內容。

根據您的需求或目標，您可以使用以下任一設定：

- [DoNotScale](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  如果您 **不** 想讓投影片上的物件被重新調整大小，請使用此設定。

- [EnsureFit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  如果您想縮小投影片尺寸，且需要 Aspose.Slides 將投影片物件縮小，以確保所有內容都能容納在投影片內（以免遺失內容），請使用此設定。

- [Maximize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/#Maximize)

  如果您想放大投影片尺寸，且需要 Aspose.Slides 將投影片物件放大，使其與新的投影片大小成比例，請使用此設定。

以下範例程式碼示範如何在變更簡報的投影片大小時使用 [Maximize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/#Maximize) 設定：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **常見問題**

**是否可以使用英寸以外的單位（例如點或毫米）設定自訂投影片大小？**

可以。Aspose.Slides 在內部使用點作為單位，1 點等於 1/72 英寸。您可以將任意單位（例如毫米或公分）轉換為點，並使用轉換後的值來定義投影片的寬度與高度。

**非常大的自訂投影片尺寸會在渲染過程中影響效能與記憶體使用嗎？**

會。較大的投影片尺寸（以點為單位）加上較高的渲染比例會導致記憶體消耗增加以及處理時間變長。請選擇實用的投影片尺寸，並僅在需要時調整渲染比例以取得所需的輸出品質。

**我能定義一個非標準的投影片尺寸，然後合併來自不同尺寸簡報的投影片嗎？**

在投影片尺寸不同的情況下，您無法[合併簡報](/slides/zh-hant/python-java/merge-presentation/)。必須先將其中一個簡報的尺寸調整為與另一個相同。變更投影片大小時，您可以透過 [SlideSizeScaleType]（https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/）選擇既有內容的處理方式。對齊尺寸後，即可合併投影片並保留格式。

**我能為投影片的單一形狀或特定區域產生縮圖，且它們會遵循新的投影片大小嗎？**

可以。Aspose.Slides 能夠為[整個投影片]（https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage）以及[選取的形狀]（https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage）產生縮圖。產生的影像會反映目前的投影片大小與長寬比，確保構圖與幾何形狀保持一致。