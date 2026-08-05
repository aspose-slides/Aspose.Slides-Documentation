---
title: 在 Android 上自訂 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap 圖表
- Sunburst 圖表
- 階層圖表
- 資料點
- 資料標籤
- 分支顏色
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 建立階層資料，並自訂 Treemap 與 Sunburst 圖表的層級、標籤與顏色。"
---
## **概觀**

Treemap 與 Sunburst 圖表顯示相同類型的階層資料，但使用不同的版面配置。Treemap 以嵌套矩形繪製階層，其面積代表葉節點的值。Sunburst 則以同心環呈現：最高層級的群組位於中心，葉節點則在最外環。

在 Aspose.Slides for Android via Java 中，每個數值都是一個 [IChartDataPoint](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/)。其 [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) 方法提供對葉節點及其父層群組的存取。本文說明此映射關係，並示範如何使用相同的樣本資料建立與格式化兩種圖表。

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **了解類別、資料點與層級**

以下範例使用三個類別層級與一條數值序列：

| 分支 | 主幹 | 葉節點 | 收入 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每一列會產生一個葉節點類別與一個資料點。類別的群組層級描述該葉節點到其父層的路徑。第一列的路徑為 `Consumer > Computers > Laptops`。

[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) 回傳的索引從葉節點向上遞增：

| `getDataPointLevels()` 索引 | 邏輯層級 | Treemap 表示 | Sunburst 表示 |
| ---: | --- | --- | --- |
| `0` | 葉節點 | 值矩形 | 外環區段 |
| `1` | 主幹 | 父矩形或標題 | 中環區段 |
| `2` | 分支 | 頂層矩形或標題 | 內環區段 |

此順序在兩種圖表類型中相同，儘管視覺版面不同。父層區段會被多個葉節點共享。格式化時，請使用該群組中第一個資料點的對應層級。例如，`Consumer` 分支以 `Laptops` 點開始，而 `Software` 主幹以 `Licenses` 點開始。保留對這些點的參考比使用未說明的表達式如 `dataPoints.get_Item(0)` 或 `dataPoints.get_Item(6)` 更清晰且安全。

## **建立與自訂兩種圖表類型**

以下完整範例在第一張投影片建立 Treemap，第二張投影片建立 Sunburst。它建立階層、顯示 `Tablets` 的值、對選取層級套用固定顏色、格式化分支標籤，最後儲存簡報。

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // 新增葉節點類別。只有在新群組開始時才設定分組項目；
        // 其餘類別會保持在該群組中，直到設定另一個項目。
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // 在 Tablets 葉節點上顯示類別和數值。
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // 透過該分支的第一個葉節點格式化 Consumer 分支。
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // 透過該主幹的第一個葉節點格式化 Software 主幹。
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout 會影響 Treemap 的父標籤；Sunburst 使用環段。
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

類別儲存格與數值儲存格使用相同的工作表列，因此它們的集合位置保持對齊。若對現有圖表進行操作，而非建立新圖表，請先檢查類別列，並將欲格式化的資料點與層級儲存為具名參考。

## **行為與實務考量**

### **Treemap 與 Sunburst 差異**

- Treemap 使用面積傳達值，使用嵌套矩形傳達階層。此圖表類型的父標籤顯示方式由 [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) 方法控制。
- Sunburst 使用角度傳達值，使用環深度傳達階層。[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) 不會控制其環標籤。
- 兩種圖表使用相同的類別群組層級與相同的葉節點到父層順序，因而資料建構與層級格式化程式碼可以共用。
- 父層值由其子葉節點計算得出。不要為分支或主幹另外新增數值點。

### **排序與區段順序**

圖表版面引擎決定矩形與環區段的最終位置。將相關類別列一起排列後再加入圖表，但不要依賴特定的矩形位置或起始角度。如果順序本身具有意義，請將其納入標籤，或使用具有明確類別軸的圖表類型。

### **佈景主題與固定顏色**

未格式化的圖表層級會從簡報佈景主題繼承顏色。範例使用明確的 RGB 填色以確保輸出可預測。若圖表需要隨佈景主題變化，請改用配色方案色彩而非固定 RGB，且避免對每個層級都覆寫。更改分支或主幹填色後，也請檢查標籤的對比度。

### **標籤與可用空間**

當區段過小時，PowerPoint 可能隱藏或截斷標籤。增大圖表尺寸、縮短類別名稱或減少顯示的標籤欄位通常可得到更清晰的結果。標籤可以透過 [IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/) 結合類別名稱、序列名稱與數值，但啟用所有欄位往往會使階層圖表難以閱讀。

### **匯出與渲染**

將簡報另存為 PPTX 可保留圖表的可編輯性。當 Aspose.Slides 將簡報渲染為 PDF 或影像時，支援的填色與標籤設定會一起渲染。字型置換與可用版面空間的細微差異可能影響換行或標籤可見性，請確保安裝所需字型並驗證重要的匯出目標。

## **常見問題**

**為什麼變更父層會影響多個葉節點？**

分支或主幹是共享的視覺區段。其 [IChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichartdatapointlevel/) 可以透過任一子葉節點存取，但格式化屬於共享的父區段，而非單一葉節點。

**為什麼資料標籤遺失了？**

先在標籤的 [IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/idatalabelformat/) 物件上啟用所需欄位，然後檢查該區段是否有足夠空間。Treemap 的父標籤版面、圖表尺寸、標籤長度、字型大小及啟用的欄位數都會影響標籤是否顯示。

**我可以設定區段的確切順序或座標嗎？**

可以控制來源列的順序並保持每個群組連續，但無法直接指定 Treemap 矩形或 Sunburst 角度的精確位置。圖表版面引擎會根據階層、值與可用空間計算它們。

**為什麼佈景主題變更後顏色會改變？**

基於佈景的填色設計為隨簡報調色盤變化。對必須固定的層級套用明確的 RGB 顏色，或在需要隨佈景變化時保留配色方案色彩。

**自訂格式在 PDF 與影像匯出時會保留嗎？**

會，支援的圖表填色與標籤設定會在渲染時一起納入。為了在不同系統上取得一致結果，請提供所需字型並測試最終匯出尺寸，因為標籤適配取決於版面配置。

## **參考資料**

- [建立 Treemap 圖表](/slides/zh-hant/androidjava/create-chart/#create-tree-map-charts)
- [建立 Sunburst 圖表](/slides/zh-hant/androidjava/create-chart/#create-sunburst-charts)
- [匯出簡報圖表](/slides/zh-hant/androidjava/export-chart/)
- [管理簡報佈景主題](/slides/zh-hant/androidjava/presentation-theme/)