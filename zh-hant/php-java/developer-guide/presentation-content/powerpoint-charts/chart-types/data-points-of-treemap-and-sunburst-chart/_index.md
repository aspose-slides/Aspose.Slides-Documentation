---
title: "使用 PHP 自訂 Treemap 與 Sunburst 圖表中的資料點"
linktitle: "Treemap 與 Sunburst 圖表的資料點"
type: docs
url: /zh-hant/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- "Treemap 圖表"
- "Sunburst 圖表"
- "資料點"
- "標籤顏色"
- "分支顏色"
- "PowerPoint"
- "簡報"
- "PHP"
- "Aspose.Slides"
description: "了解如何使用 Aspose.Slides for PHP via Java 在 Treemap 與 Sunburst 圖表中管理資料點，並相容於 PowerPoint 格式。"
---
## **簡介**

在其他 PowerPoint 圖表類型中，有兩種「層級」類型 ─ **Treemap** 與 **Sunburst** 圖表（亦稱 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart）。這些圖表顯示以樹狀結構組織的層級資料——從葉節點到分支頂端。葉節點由系列資料點定義，每一個後續的巢狀分組層級則由對應的類別定義。Aspose.Slides for PHP via Java 允許格式化 Sunburst 圖表與 Treemap 的資料點。

以下是一個 Sunburst 圖表，其中 Series1 欄位的資料定義葉節點，而其他欄位則定義層級資料點：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

讓我們從在簡報中加入新的 Sunburst 圖表開始：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="另請參閱" %}} 
- [**在 PHP 中建立或更新 PowerPoint 簡報圖表**](/slides/zh-hant/php-java/create-chart/)
{{% /alert %}}

如果需要格式化圖表的資料點，我們應使用下列項目：

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointlevelsmanager/)、 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointlevel/) 類別，  
以及 [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) 方法，  
提供對 Treemap 與 Sunburst 圖表資料點的格式設定存取。  
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointlevelsmanager/) 用於存取多層級類別——它代表  
[**ChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointlevel/) 物件的容器。  
基本上它是  
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartcategorylevelsmanager/) 的包裝器，加入了針對資料點的特定屬性。  
[**ChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointlevel/) 類別具有兩個方法：  
[**getFormat**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointlevel/#getFormat) 與  
[**getDataLabel**](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapointlevel/#getLabel)，提供對相應設定的存取。

## **顯示資料點值**

顯示「Leaf 4」資料點的值：

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **設定資料點標籤與顏色**

將「Branch 1」的資料標籤設定為顯示系列名稱（「Series1」）而非類別名稱。接著將文字顏色設定為黃色：

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **設定資料點分支顏色**

將「Steam 4」分支的顏色變更為：

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **常見問題**

**我可以變更 Sunburst/Treemap 中分段的順序（排序）嗎？**

不行。PowerPoint 會自動對分段進行排序（通常依值遞減且順時針方向）。Aspose.Slides 會同樣的行為：無法直接變更順序；只能透過在資料前處理來達成。

**簡報主題如何影響分段與標籤的顏色？**

圖表顏色會繼承簡報的 [主題/調色盤](/slides/zh-hant/php-java/presentation-theme/)（除非你明確設定填滿或字型）。若需一致的結果，請在所需層級鎖定實心填滿與文字格式。

**匯出為 PDF/PNG 時會保留自訂的分支顏色與標籤設定嗎？**

會。匯出簡報時，圖表的設定（填滿、標籤）會在輸出格式中保留，因為 Aspose.Slides 會依圖表的格式進行渲染。

**我可以計算標籤或元素的實際座標，以在圖表上方放置自訂覆蓋物嗎？**

可以。圖表版面配置驗證完成後，可取得元素的實際 *x* 與 *y* 座標（例如 [DataLabel](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/datalabel/)），這有助於精確定位覆蓋物。