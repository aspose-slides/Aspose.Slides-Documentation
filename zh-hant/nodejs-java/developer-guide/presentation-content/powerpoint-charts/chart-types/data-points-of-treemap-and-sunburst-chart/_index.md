---
title: 使用 JavaScript 自訂 Treemap 與 Sunburst 圖表中的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap 圖表
- sunburst 圖表
- 階層圖表
- 資料點
- 資料標籤
- 分支顏色
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 建立階層資料，並自訂 Treemap 與 Sunburst 圖表的層級、標籤與顏色。"
---
## **概覽**

Treemap 和 Sunburst 圖表顯示相同類型的階層資料，但其版面配置不同。Treemap 以嵌套矩形表示層級，矩形面積代表葉節點的值。Sunburst 則以同心環呈現：最上層群組位於中心附近，葉節點類別位於外環。

在 Aspose.Slides for Node.js via Java 中，每個數值都是一個 [ChartDataPoint](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/)。其 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) 方法提供對葉節點及其父群組的存取。本篇說明此對映，並展示如何使用相同的樣本資料建立與格式化兩種圖表類型。

![含有 Consumer 與 Business 分支的 Treemap 圖表](treemap-hierarchy.png)

![含有相同 Consumer 與 Business 階層的 Sunburst 圖表](sunburst-hierarchy.png)

## **了解類別、資料點與層級**

以下範例使用三個類別層級和一個數值序列：

| 分支 | 子分支 | 葉節點 | 收入 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每一列會建立一個葉節點類別與一個資料點。類別分組層級說明該葉節點到其父層級的路徑。以第一列為例，路徑為 `Consumer > Computers > Laptops`。

由 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) 回傳的索引由葉節點向上遞增：

| `getDataPointLevels()` 索引 | 邏輯層級 | Treemap 表示方式 | Sunburst 表示方式 |
| ---: | --- | --- | --- |
| `0` | 葉節點 | 值矩形 | 外環區段 |
| `1` | 子分支 | 父矩形或標題 | 中環區段 |
| `2` | 分支 | 頂層矩形或標題 | 內環區段 |

此順序在兩種圖表類型中相同，儘管視覺版面不同。父區段會被多個葉節點共用。若要格式化它，請使用該群組中第一個資料點的相應層級。例如，`Consumer` 分支從 `Laptops` 點開始，而 `Software` 子分支則從 `Licenses` 點開始。保留對這些點的參考比使用未說明的表達式如 `dataPoints.get_Item(0)` 或 `dataPoints.get_Item(6)` 更清晰且安全。

## **建立與自訂兩種圖表類型**

以下完整範例在第一張投影片建立 Treemap，第二張投影片建立 Sunburst。它會建構層級結構、顯示 `Tablets` 的值、對選取層級套用固定色彩、格式化分支標籤，並儲存簡報。

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // 新增葉節點類別。僅在新群組開始時設定分組項目；
        // 隨後的類別會保留在該群組中，直到設定另一個項目。
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // 在 Tablets 葉節點上顯示類別與數值。
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // 透過該分支的第一個葉節點格式化 Consumer 分支。
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // 透過該幹的第一個葉節點格式化 Software 幹。
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout 會影響 Treemap 的父標籤；Sunburst 使用環段。
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

類別儲存格與數值儲存格使用相同的工作表列，因而保有對齊的集合位置。當你處理既有圖表而非自行建立時，請先檢查類別列，並將欲格式化的資料點與層級存為具名參考。

## **行為與實務考量**

### **Treemap 與 Sunburst 差異**

- Treemap 以面積傳遞值，以嵌套矩形傳遞層級。其 [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) 方法可控制父標籤在此圖表類型中的顯示方式。
- Sunburst 以角度傳遞值，以環深度傳遞層級。[ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) 不會控制其環標籤。
- 兩種圖表使用相同的類別分組層級與由 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) 回傳的葉節點至父層順序，因而可以共用資料建構與層級格式化程式碼。
- 父層值由其子葉節點計算得出。不要為分支或子分支另外新增數值點。

### **排序與區段順序**

- 圖表版面引擎決定矩形與環區段的最終位置。請先將相關類別列一起排列後再加入圖表，但不要依賴特定的矩形位置或起始角度。若順序本身具有意義，請將其寫入標籤或改用具明確類別軸的圖表類型。

### **主題與固定色彩**

- 未格式化的圖表層級會繼承簡報主題的顏色。範例使用明確的 RGB 填色以確保可預測的輸出。若圖表需隨主題變更而變化，請改用配色方案色彩而非固定的 RGB 值，且避免對每一層級都覆寫。變更分支或子分支的填色後，也請檢查標籤的對比度。

### **標籤與可用空間**

- 當區段過小時，PowerPoint 可能會隱藏或截斷標籤。放大圖表尺寸、縮短類別名稱或減少顯示的標籤欄位通常能得到較清晰的結果。標籤可透過 [DataLabelFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabelformat/) 結合類別名稱、系列名稱與數值，但啟用所有欄位往往會使階層圖表難以閱讀。

### **匯出與渲染**

- 儲存為 PPTX 可保留圖表的可編輯性。當 Aspose.Slides 將簡報算繪為 PDF 或影像時，支援的填色與標籤設定會一併算繪。字型替換與可用版面空間的細微差異可能導致換行或標籤可見性變化，請安裝必要字型並驗證重要的匯出目標。

## **常見問題**

**為何變更父層級會影響多個葉節點？**

分支或子分支是共用的視覺區段。其 [ChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chartdatapointlevel/) 可以透過任一子葉節點取得，但格式化屬於共享的父區段，而非僅屬於該葉節點本身。

**為何資料標籤缺失？**

首先在標籤的 [DataLabelFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/datalabelformat/) 物件上啟用所需欄位，然後檢查該區段是否有足夠空間。Treemap 的父標籤版面、圖表尺寸、標籤長度、字型大小以及啟用的欄位數都會影響標籤是否能顯示。

**我可以設定區段的確切順序或座標嗎？**

您可以控制來源列的順序並保持每個群組連續，但無法指定 Treemap 矩形或 Sunburst 角度的精確位置。圖表版面引擎會根據層級結構、數值與可用空間計算它們。

**為何在簡報主題變更後顏色會改變？**

基於主題的填色會遵循簡報調色板。對必須保持不變的層級使用明確的 RGB 顏色，或在需要隨新主題調整時保留配色方案色彩。

**自訂格式在 PDF 與影像匯出時會保留嗎？**

會的，支援的圖表填色與標籤設定在算繪過程中會被納入。為確保跨系統結果一致，請確保所需字型可用，並測試最終匯出尺寸，因為標籤適配與版面有關。

## **參見**

- [建立 Treemap 圖表](/slides/zh-hant/nodejs-java/create-chart/#creating-tree-map-charts)
- [建立 Sunburst 圖表](/slides/zh-hant/nodejs-java/create-chart/#creating-sunburst-charts)
- [匯出簡報圖表](/slides/zh-hant/nodejs-java/export-chart/)
- [管理簡報主題](/slides/zh-hant/nodejs-java/presentation-theme/)