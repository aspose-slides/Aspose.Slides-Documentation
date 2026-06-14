---
title: 在 .NET 中自訂 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap 圖表
- Sunburst 圖表
- 資料點
- 標籤顏色
- 分支顏色
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 管理 Treemap 與 Sunburst 圖表的資料點，並相容於 PowerPoint 格式。"
---
## **簡介**

在其他 PowerPoint 圖表類型之外，還有兩種「分層」類型──**Treemap** 與 **Sunburst** 圖表（亦稱為 Sunburst Graph、Sunburst Diagram、Radial Chart、Radial Graph 或 Multi Level Pie Chart）。這些圖表以樹狀結構顯示分層資料——由葉節點到分支的頂端。葉節點由系列資料點定義，而每個後續的巢狀分組層級則由相應的類別定義。Aspose.Slides for .NET 允許在 C# 中格式化 Sunburst Chart 與 Treemap 的資料點。

以下是一個 Sunburst 圖表，Series1 欄位的資料定義葉節點，而其他欄位則定義分層資料點：

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

讓我們從在簡報中新增 Sunburst 圖表開始：

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```

{{% alert color="primary" title="See also" %}} 
- [**建立 Sunburst 圖表**](/slides/zh-hant/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

如果需要格式化圖表的資料點，我們應使用以下方式：

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/IChartDataPointLevelsManager)、[IChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapointlevel) 類別，以及[**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) 屬性，提供存取 Treemap 和 Sunburst 圖表資料點格式的功能。[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/IChartDataPointLevelsManager) 用於存取多層類別——它代表 [**IChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/IChartDataPointLevel) 物件的容器。基本上它是 [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/IChartCategoryLevelsManager) 的包裝器，並加入針對資料點的特定屬性。[**IChartDataPointLevel**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/IChartDataPointLevel) 類別具有兩個屬性： [**Format**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapointlevel/properties/format) 和 [**DataLabel**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapointlevel/properties/label)，提供對應設定的存取。

## **顯示資料點值**

顯示「Leaf 4」資料點的值：

```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **設定資料點標籤與顏色**

將「Branch 1」的資料標籤設定為顯示系列名稱（「Series1」）而非類別名稱。然後將文字顏色設定為黃色：

```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **設定資料點分支顏色**

變更「Stem 4」分支的顏色：

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **常見問題**

**我可以變更 Sunburst/Treemap 中區段的順序（排序）嗎？**

不行。PowerPoint 會自動排序區段（通常依值遞減，順時針方向）。Aspose.Slides 會映射此行為：無法直接變更順序；只能透過前置處理資料來達成。

**簡報主題如何影響區段與標籤的顏色？**

圖表顏色會繼承簡報的 [主題/調色盤](/slides/zh-hant/net/presentation-theme/)（除非您明確設定填色或字體）。若需一致的結果，請在所需層級上鎖定純色填充與文字格式。

**匯出為 PDF/PNG 時會保留自訂的分支顏色與標籤設定嗎？**

會。匯出簡報時，圖表的設定（填色、標籤）會保留在輸出格式中，因為 Aspose.Slides 會依圖表的格式進行渲染。

**我能計算標籤/元件的實際座標，以在圖表上方放置自訂覆蓋層嗎？**

會。當圖表版面配置驗證完成後，元素（例如 [DataLabel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/datalabel/)）會提供 `ActualX`/`ActualY`，可協助精確定位覆蓋層。