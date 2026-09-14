---
title: 在 Python 透過 Java 中變更簡報投影片大小
linktitle: 投影片大小
type: docs
weight: 70
url: /zh-hant/python-java/slide-size/
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
- 確保適配
- 最大化
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Python 透過 Java 及 Aspose.Slides 快速調整 PPT、PPTX 與 ODP 檔案的投影片大小，並在不失真的情況下為任何螢幕最佳化簡報。"
---
## **簡介**

Aspose.Slides 提供完整的工具來調整 PowerPoint 簡報中的投影片大小和長寬比，對於列印和螢幕顯示皆至關重要。

常見的投影片尺寸與比例：

- **Standard (4:3 Aspect Ratio)**：最適合較舊的螢幕和裝置。
- **Widescreen (16:9 Aspect Ratio)**：建議用於現代的投影機和顯示器。

請確保整個簡報使用相同的投影片大小與長寬比，因為單一的設定會套用到所有投影片。為取得最佳效果，請在建立簡報之初即設定投影片尺寸，以免產生問題。

{{% alert color="info" title="注意" %}}
預設情況下，使用 Aspose.Slides 建立的簡報會使用標準的 4:3 長寬比。
{{% /alert %}}

## **變更簡報中的投影片大小**

此範例程式碼示範如何使用 Aspose.Slides 於 Python 透過 Java 變更簡報的投影片大小：

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

## **在簡報中指定自訂投影片尺寸**

如果您發現常用的投影片尺寸 (4:3 與 16:9) 不適合您的工作，您可以決定使用特定或唯一的投影片尺寸。例如，若您打算在自訂版面的紙張上列印完整尺寸的投影片，或是希望在特定類型的螢幕上顯示簡報，使用自訂尺寸設定將對您有幫助。

此範例程式碼示範如何使用 Aspose.Slides for Python 透過 Java 為簡報指定自訂投影片尺寸：

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

## **調整大小後處理投影片內容**

變更簡報的投影片大小後，投影片的內容（例如影像或物件）可能會變形。預設情況下，物件會自動調整大小以符合新的投影片尺寸。然而，在變更簡報的投影片大小時，您可以指定一個設定，決定 Aspose.Slides 如何處理投影片上的內容。

根據您的需求與目標，您可以使用以下任一設定：

- [DoNotScale](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  如果您不希望投影片上的物件被重新調整大小，請使用此設定。

- [EnsureFit](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  如果您想縮小投影片尺寸，且需要 Aspose.Slides 將投影片物件縮小以確保它們全部適應投影片（此方式可避免內容遺失），請使用此設定。

- [Maximize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/#Maximize)

  如果您想放大投影片尺寸，且需要 Aspose.Slides 將投影片物件放大以符合新的投影片比例，請使用此設定。

此範例程式碼示範在變更簡報投影片大小時如何使用 [Maximize](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/#Maximize) 設定：

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

**是否可以使用除英寸之外的單位（例如點或毫米）來設定自訂投影片尺寸？**

是的。Aspose.Slides 在內部使用點作為單位，1 點等於 1/72 英寸。您可以將任何單位（例如毫米或公分）轉換為點，並使用轉換後的數值來定義投影片的寬度和高度。

**非常大的自訂投影片尺寸會影響渲染時的效能與記憶體使用嗎？**

會的。較大的投影片尺寸（以點計）搭配較高的渲染比例會導致記憶體消耗增加以及處理時間變長。請選擇實用的投影片尺寸，並僅在需要達到特定輸出品質時調整渲染比例。

**我能定義一個非標準的投影片尺寸，然後合併具有不同尺寸的簡報的投影片嗎？**

您無法在投影片尺寸不同的情況下直接[合併簡報](/slides/zh-hant/python-java/merge-presentation/)，必須先將其中一個簡報的尺寸調整為與另一個相同。在變更投影片大小時，您可以透過 [SlideSizeScaleType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slidesizescaletype/) 選項選擇如何處理現有內容。對齊尺寸後，您即可合併投影片，同時保留格式。

**我能為投影片的單一形狀或特定區域產生縮圖，且它們會遵守新的投影片尺寸嗎？**

可以。Aspose.Slides 能為[整篇投影片](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage)以及[選取的形狀](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shape/#getImage)產生縮圖。產生的影像會反映當前的投影片尺寸與長寬比，確保構圖與幾何保持一致。