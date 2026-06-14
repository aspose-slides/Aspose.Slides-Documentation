---
title: 在 Java 中為 PowerPoint 圖表添加動畫
linktitle: 動畫圖表
type: docs
weight: 80
url: /zh-hant/java/animated-charts/
keywords:
- 圖表
- 動畫圖表
- 圖表動畫
- 圖表系列
- 圖表類別
- 系列元素
- 類別元素
- 添加效果
- 效果類型
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中建立令人驚豔的動畫圖表。以動態視覺效果提升 PPT 與 PPTX 檔案的簡報效果——立即開始吧。"
---
## **簡介**

Aspose.Slides for Java 支援動畫化圖表元素。**Series**、**Categories**、**Series Elements**、**Categories Elements** 可以使用 [ISequence.addEffect](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) 方法以及兩個列舉 [EffectChartMajorGroupingType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/EffectChartMajorGroupingType) 和 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/EffectChartMinorGroupingType) 進行動畫化。

## **圖表系列動畫**
如果您想為圖表系列添加動畫，請依照以下步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為系列添加動畫。
1. 將簡報檔寫入磁碟。

在下方的範例中，我們為圖表系列添加了動畫。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 取得圖表物件的參考
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // 為系列添加動畫
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 將修改後的簡報寫入磁碟
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **圖表類別動畫**
如果您想為圖表類別添加動畫，請依照以下步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為類別添加動畫。
1. 將簡報檔寫入磁碟。

在下方的範例中，我們為圖表類別添加了動畫。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **系列元素動畫**
如果您想為系列元素添加動畫，請依照以下步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為系列元素添加動畫。
1. 將簡報檔寫入磁碟。

在下方的範例中，我們已為系列元素添加了動畫。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 取得圖表物件的參考
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // 為系列元素添加動畫
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 將簡報檔寫入磁碟 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **類別元素動畫**
如果您想為類別元素添加動畫，請依照以下步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為類別元素添加動畫。
1. 將簡報檔寫入磁碟。

在下方的範例中，我們已為類別元素添加了動畫。

```java
// 實例化代表簡報檔案的 Presentation 類別
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // 取得圖表物件的參考
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // 為類別元素添加動畫
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 將簡報檔寫入磁碟
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**圖表是否支援不同的效果類型（例如，進入、強調、退出），就像一般圖形一樣？**  
是的。圖表被視為形狀，因此支援標準的動畫效果類型，包括進入、強調和退出，並可透過投影片的時間軸和動畫序列完整控制。

**我可以將圖表動畫與投影片過場效果結合使用嗎？**  
是的。[Transitions](/slides/zh-hant/java/slide-transition/) 會套用於投影片本身，而動畫效果則套用於投影片上的物件。您可以在同一簡報中同時使用兩者，並分別加以控制。

**圖表動畫在儲存為 PPTX 時會被保留嗎？**  
是的。當您[save to PPTX](/slides/zh-hant/java/save-presentation/) 時，所有動畫效果及其順序都會被保留，因為它們是簡報原生動畫模型的一部份。

**我可以讀取簡報中已存在的圖表動畫並加以修改嗎？**  
是的。API 提供存取投影片時間軸、序列與效果的功能，讓您能檢視現有的圖表動畫並進行調整，無需從頭重新建立。

**我可以使用 Aspose.Slides 產生包含圖表動畫的影片嗎？**  
是的。您可以[export a presentation to video](/slides/zh-hant/java/convert-powerpoint-to-video/) 同時保留動畫，設定時間與其他匯出選項，使最終影片呈現動畫播放效果。