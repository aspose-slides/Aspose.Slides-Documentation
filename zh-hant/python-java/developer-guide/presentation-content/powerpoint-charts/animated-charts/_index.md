---
title: 使用 Python via Java 為 PowerPoint 圖表添加動畫
linktitle: 動畫化圖表
type: docs
weight: 80
url: /zh-hant/python-java/animated-charts/
keywords:
- 圖表
- 動畫圖表
- 圖表動畫
- 圖表系列
- 圖表類別
- 系列元素
- 類別元素
- 新增效果
- 效果類型
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 於 Python via Java 建立驚豔的動畫圖表。以動態視覺效果提升 PPT 與 PPTX 檔案的簡報——立即開始吧。"
---
## **簡介**

Aspose.Slides for Python via Java 支援對圖表元素進行動畫化。**Series**、**Categories**、**Series Elements** 與 **Category Elements** 可使用 [Sequence.addEffect](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sequence/#addEffect) 方法以及兩個列舉型別： [EffectChartMajorGroupingType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effectchartmajorgroupingtype/) 和 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/effectchartminorgroupingtype/) 來設定動畫。

## **圖表系列動畫**

如果您想為圖表系列加入動畫，請按照下列步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為系列設定動畫。
1. 將簡報寫入磁碟。

以下範例展示如何為圖表系列加入動畫。範例檔案中的圖表有三個系列，因此會為索引 0 到 2 各新增一個效果。Aspose.Slides 不會檢查索引是否與圖表資料相符，若為不存在的系列新增效果，該效果仍會寫入檔案但不會產生動畫──請確保索引低於您圖表的系列數量。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 載入簡報。
presentation = Presentation("ExistingChart.pptx")
try:
    # 取得圖表物件的參考。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 為圖表元素設定動畫。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 將修改後的簡報寫入磁碟。
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **圖表類別動畫**

如果您想為圖表類別加入動畫，請按照下列步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為類別設定動畫。
1. 將簡報寫入磁碟。

以下範例展示如何為圖表類別加入動畫。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 載入簡報。
presentation = Presentation("ExistingChart.pptx")
try:
    # 取得圖表物件的參考。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 為圖表元素設定動畫。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 將修改後的簡報寫入磁碟。
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **系列元素的動畫**

如果您想為系列元素加入動畫，請按照下列步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為系列元素設定動畫。
1. 將簡報寫入磁碟。

以下範例展示如何為系列元素加入動畫。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 載入簡報。
presentation = Presentation("ExistingChart.pptx")
try:
    # 取得圖表物件的參考。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 為圖表元素設定動畫。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 將修改後的簡報寫入磁碟。
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **類別元素的動畫**

如果您想為類別元素加入動畫，請按照下列步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為類別元素設定動畫。
1. 將簡報寫入磁碟。

以下範例展示如何為類別元素加入動畫。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# 載入簡報。
presentation = Presentation("ExistingChart.pptx")
try:
    # 取得圖表物件的參考。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # 為圖表元素設定動畫。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 將修改後的簡報寫入磁碟。
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **常見問題**

**圖表是否支援不同的動畫類型（例如，進入、強調、退出），就像一般圖形一樣？**

是。圖表被視為形狀，因而支援標準的動畫類型，包括進入、強調與退出，且可透過投影片時間軸與動畫序列完整控制。

**我可以將圖表動畫與投影片切換效果結合使用嗎？**

可以。[Transitions](/slides/zh-hant/python-java/slide-transition/) 作用於整張投影片，而動畫效果則作用於投影片上的物件。兩者可同時使用，且可分別控制。

**將簡報另存為 PPTX 時，圖表動畫會被保留嗎？**

會。當您[另存為 PPTX](/slides/zh-hant/python-java/save-presentation/) 時，所有動畫效果與其順序皆會被保留，因為它們是簡報本機動畫模型的一部份。

**我能讀取簡報中已存在的圖表動畫並加以修改嗎？**

可以。API 提供對投影片時間軸、序列與效果的存取，讓您檢視並調整現有的圖表動畫，而不必全部重新建立。

**我可以使用 Aspose.Slides 產生包含圖表動畫的影片嗎？**

可以。您可以[將簡報匯出為影片](/slides/zh-hant/python-java/convert-powerpoint-to-video/)，在保留動畫的同時設定時間與其他匯出參數，讓最終影片顯示動畫播放效果。