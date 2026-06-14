---
title: 在 PHP 中為 PowerPoint 圖表加入動畫
linktitle: 動畫化圖表
type: docs
weight: 80
url: /zh-hant/php-java/animated-charts/
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 建立令人驚豔的動畫圖表。透過動態視覺效果提升 PPT 與 PPTX 簡報 — 現在就開始吧。"
---
## **簡介**

Aspose.Slides for PHP via Java 支援為圖表元素添加動畫。**Series**、**Categories**、**Series Elements**、**Categories Elements** 可以使用 [Sequence::addEffect](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/sequence/#addEffect) 方法以及兩個列舉 [EffectChartMajorGroupingType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/EffectChartMajorGroupingType) 和 [EffectChartMinorGroupingType](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/EffectChartMinorGroupingType) 來實作。

## **圖表系列動畫**
如果您想對圖表系列進行動畫，請按照以下列出的步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為系列新增動畫。
1. 將簡報檔寫入磁碟。

以下範例中，我們對圖表系列進行了動畫。

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # 取得圖表物件的參考
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # 為系列新增動畫
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 將修改後的簡報寫入磁碟
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **圖表類別動畫**
如果您想對圖表類別進行動畫，請按照以下列出的步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為類別新增動畫。
1. 將簡報檔寫入磁碟。

以下範例中，我們對圖表類別進行了動畫。

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **系列元素動畫**
如果您想對系列元素進行動畫，請按照以下列出的步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為系列元素新增動畫。
1. 將簡報檔寫入磁碟。

以下範例中，我們已對系列元素添加了動畫。

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # 取得圖表物件的參考
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # 為系列元素新增動畫
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 將簡報檔寫入磁碟
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **類別元素動畫**
如果您想對類別元素進行動畫，請按照以下列出的步驟編寫程式碼：

1. 載入簡報。
1. 取得圖表物件的參考。
1. 為類別元素新增動畫。
1. 將簡報檔寫入磁碟。

以下範例中，我們已對類別元素添加了動畫。

```php
  # 實例化代表簡報檔案的 Presentation 類別
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # 取得圖表物件的參考
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # 為類別元素新增動畫
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 將簡報檔寫入磁碟
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**圖表是否支援與一般圖形相同的不同效果類型（例如進入、強調、退出）？**

是的。圖表被視為形狀，因此支援標準的動畫效果類型，包括進入、強調和退出，您可以透過投影片的時間軸和動畫序列完整控制。

**我可以將圖表動畫與投影片轉場結合使用嗎？**

是的。[Transitions](/slides/zh-hant/php-java/slide-transition/) 會套用於投影片，而動畫效果則套用於投影片上的物件。您可以在同一簡報中同時使用兩者，並且分別加以控制。

**將簡報儲存為 PPTX 時，圖表動畫會被保留嗎？**

是的。當您[save to PPTX](/slides/zh-hant/php-java/save-presentation/)時，所有動畫效果及其順序都會被保留，因為它們是簡報原生動畫模型的一部份。

**我能讀取簡報中現有的圖表動畫並對其進行修改嗎？**

是的。API 提供對投影片時間軸、序列和效果的存取，讓您能檢視現有的圖表動畫並進行調整，而不必從頭重新建立。

**我可以使用 Aspose.Slides 產生包含圖表動畫的影片嗎？**

是的。您可以[export a presentation to video](/slides/zh-hant/php-java/convert-powerpoint-to-video/) 同時保留動畫、設定時間與其他匯出選項，使最終影片能呈現動畫播放效果。