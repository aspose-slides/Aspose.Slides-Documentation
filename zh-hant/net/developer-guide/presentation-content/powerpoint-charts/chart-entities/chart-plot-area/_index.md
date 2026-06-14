---
title: 自訂 .NET 簡報圖表的繪圖區
linktitle: 繪圖區
type: docs
url: /zh-hant/net/chart-plot-area/
keywords:
- 圖表
- 繪圖區
- 繪圖區寬度
- 繪圖區高度
- 繪圖區大小
- 版面配置模式
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索如何使用 Aspose.Slides for .NET 於 PowerPoint 簡報中自訂圖表的繪圖區，輕鬆提升投影片視覺效果。"
---
## **概觀**

本文說明如何在 Aspose.Slides 中操作圖表的繪圖區。它解釋了如何透過驗證圖表版面配置來取得繪圖區的實際位置與尺寸，然後讀取其 X、Y、寬度與高度的值。

同時也示範了在手動設定版面配置時，如何使用 `LayoutTargetType` 來定義繪圖區是以內部區域或外部區域（包含座標軸與座標軸標籤）計算。

## **取得圖表繪圖區的寬度與高度**
Aspose.Slides for .NET 提供簡易的 API。

1. 建立一個 [簡報](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 取得第一張投影片。
3. 新增預設資料的圖表。
4. 在取得實際值之前呼叫 IChart.ValidateChartLayout() 方法。
5. 取得圖表元件相對於圖表左上角的實際 X 位置（左）。
6. 取得圖表元件相對於圖表左上角的實際 Y 位置（上）。
7. 取得圖表元件的實際寬度。
8. 取得圖表元件的實際高度。

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// 儲存含圖表的簡報
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **設定圖表繪圖區的版面配置模式**
Aspose.Slides for .NET 提供簡易的 API 以設定圖表繪圖區的版面配置模式。已在 **ChartPlotArea** 與 **IChartPlotArea** 類別加入屬性 **LayoutTargetType**。如果手動定義繪圖區的版面配置，該屬性指定是以內部（不含座標軸與座標軸標籤）或外部（含座標軸與座標軸標籤）方式排版。此屬性有兩個可能的值，定義於 **LayoutTargetType** 列舉中。

- **LayoutTargetType.Inner** - 指定繪圖區的尺寸僅決定繪圖區本身的大小，不包含刻度線與座標軸標籤。
- **LayoutTargetType.Outer** - 指定繪圖區的尺寸決定繪圖區本身、刻度線以及座標軸標籤的大小。

以下為範例程式碼。

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**ActualX、ActualY、ActualWidth 與 ActualHeight 以何種單位回傳？**

以點 (point) 為單位；1 英吋 = 72 點。這是 Aspose.Slides 的座標單位。

**繪圖區與圖表區在內容上有何不同？**

繪圖區是資料繪製區域（系列、格線、趨勢線等）；圖表區則包含周圍的元素（標題、圖例等）。在 3D 圖表中，繪圖區亦包含牆面/底面與座標軸。

**當版面配置為手動時，繪圖區的 X、Y、寬度與高度如何解釋？**

它們是圖表整體大小的比例（0–1）；在此模式下會停用自動定位，使用您設定的比例值。

**為何在新增或移動圖例後，繪圖區的位置會變動？**

圖例位於圖表區的繪圖區之外，會影響版面配置與可用空間，因而在自動定位啟用時可能導致繪圖區移動。（這是 PowerPoint 圖表的標準行為。）