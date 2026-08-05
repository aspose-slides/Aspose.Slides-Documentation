---
title: 在 .NET 中自訂 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap 圖表
- Sunburst 圖表
- 階層圖表
- 資料點
- 資料標籤
- 分支顏色
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 建立階層資料，並自訂 Treemap 與 Sunburst 圖表的層級、標籤與顏色。"
---
## **概觀**

Treemap 與 Sunburst 圖表顯示相同類型的階層資料，但使用不同的版面配置。Treemap 以巢狀矩形繪製階層，矩形面積代表葉子值。Sunburst 則以同心環顯示：頂層群組位於中心，葉子類別則在外環。

在 Aspose.Slides for .NET 中，每個數值都是一個 [IChartDataPoint](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/)。其 [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) 集合提供對葉子及其父層組的存取。本文說明此對應關係，並示範如何使用相同的範例資料建立與格式化兩種圖表類型。

![含有 Consumer 與 Business 分支的 Treemap 圖表](treemap-hierarchy.png)

![含有相同 Consumer 與 Business 階層的 Sunburst 圖表](sunburst-hierarchy.png)

## **了解類別、資料點與層級**

以下範例使用三個類別層級以及一個數值序列：

| 分支 | 節點 | 葉子 | 營收 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每一列會建立一個葉子類別與一個資料點。類別的群組層級描述從該葉子到其父層的路徑。對於第一列，路徑為 `Consumer > Computers > Laptops`。

[IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) 的索引由葉子向上遞增：

| `DataPointLevels` index | 邏輯層級 | Treemap 表示法 | Sunburst 表示法 |
| ---: | --- | --- | --- |
| `0` | 葉子 | 值矩形 | 外環片段 |
| `1` | 節點 | 父矩形或標頭 | 中環片段 |
| `2` | 分支 | 頂層矩形或標頭 | 內環片段 |

此順序對兩種圖表皆相同，儘管其視覺版面不同。父層片段會被多個葉子共享。若要格式化它，請使用該群組中第一個資料點的相應層級。例如，`Consumer` 分支以 `Laptops` 資料點開始，而 `Software` 節點以 `Licenses` 資料點開始。保留對這些點的參照比使用未說明的表達式如 `dataPoints[0]` 或 `dataPoints[6]` 更清晰且安全。

## **建立與自訂兩種圖表類型**

以下完整範例會在第一張投影片建立 Treemap，第二張投影片建立 Sunburst。它會建構階層、顯示 `Tablets` 的值、對選取層級套用固定色彩、格式化分支標籤，並儲存簡報。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // 新增葉子類別。僅在新群組開始時設定分組項目；
    // 之後的類別會保持在該群組中，直至設定另一個項目。
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // 在 Tablets 葉子上顯示類別名稱與數值。
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // 透過該分支的第一個葉子來格式化 Consumer 分支。
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // 透過該幹的第一個葉子來格式化 Software 幹。
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout 會影響 Treemap 的父標籤；Sunburst 使用環段。
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

類別儲存格與數值儲存格使用相同的工作表列，因而其集合位置保持對齊。當您處理既有圖表而非新建圖表時，請先檢查類別列，並為欲格式化的資料點與層級儲存具名參照。

## **行為與實務考量**

### **Treemap 與 Sunburst 差異**

- Treemap 使用面積傳遞數值，使用巢狀矩形傳遞階層。此圖表類型的 [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/parentlabellayout/) 屬性控制父標籤的顯示方式。
- Sunburst 使用角度傳遞數值，使用環深度傳遞階層。[IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/parentlabellayout/) 不會控制其環標籤。
- 兩種圖表使用相同的類別群組層級與相同的葉子到父層順序 (`DataPointLevels`)，因此資料建構與層級格式化程式碼可以共用。
- 父層值由其子葉子計算得出。不要為分支或節點額外新增數值點。

### **排序與分割順序**

圖表版面引擎決定矩形與環片段的最終位置。請在加入前將相關類別列排列在一起，但不要依賴特定的矩形位置或起始角度。如順序本身具有意義，請將其納入標籤或使用具有明確類別軸的圖表類型。

### **主題與固定顏色**

未格式化的圖表層級會從簡報主題繼承顏色。範例使用明確的 RGB 填色以確保輸出可預測。若圖表需隨主題變更，請改用色彩方案而非固定 RGB，且避免覆寫每個層級。變更分支或節點填色後，也要檢查標籤對比度。

### **標籤與可用空間**

當片段太小時，PowerPoint 可能隱藏或截斷標籤。增大圖表尺寸、縮短類別名稱，或顯示較少的標籤欄位通常能得到更清晰的結果。標籤可透過 [IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatalabelformat/) 結合類別名稱、序列名稱與數值，但啟用所有欄位往往會使階層圖表難以閱讀。

### **匯出與算繪**

儲存為 PPTX 可保留圖表可編輯性。當 Aspose.Slides 將簡報算繪為 PDF 或影像時，支援的填色與標籤設定會一併算繪。字型替代與可用版面空間的細微差異可能改變換行或標籤可見性，請安裝所需字型並驗證重要的匯出目標。

## **常見問題**

**為什麼變更父層會影響多個葉子？**

分支或節點是共享的視覺片段。其 [IChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartdatapointlevel/) 可以透過子葉子取得，但格式屬於共享的父片段，而非僅屬於該葉子。

**為什麼資料標籤遺失了？**

先在標籤的 [IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/idatalabelformat/) 物件上啟用所需欄位，然後檢查片段是否有足夠空間。Treemap 的父標籤版面、圖表尺寸、標籤長度、字型大小與啟用欄位數量皆會影響標籤是否能顯示。

**我可以設定片段的精確順序或座標嗎？**

您可以控制來源列的順序並讓每個群組保持連續，但無法指定精確的 Treemap 矩形或 Sunburst 角度。圖表版面引擎會根據階層、數值與可用空間計算它們。

**為什麼主題變更後顏色會改變？**

基於主題的填色設計為遵循簡報調色盤。對必須固定的層級套用明確的 RGB 顏色，或在適應新主題時保留色彩方案。

**自訂格式會在 PDF 與影像匯出中保留嗎？**

會的，支援的圖表填色與標籤設定在算繪時會被保留。為確保跨系統一致，請提供所需字型並測試最終匯出尺寸，因為標籤適配取決於版面配置。

## **參見**

- [建立 Treemap 圖表](/slides/zh-hant/net/create-chart/#create-tree-map-charts)
- [建立 Sunburst 圖表](/slides/zh-hant/net/create-chart/#create-sunburst-charts)
- [匯出簡報圖表](/slides/zh-hant/net/export-chart/)
- [管理簡報主題](/slides/zh-hant/net/presentation-theme/)