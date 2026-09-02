---
title: 在 Java 中自訂 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- 樹狀圖表
- 日暈圖表
- 階層圖表
- 資料點
- 資料標籤
- 分支顏色
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 建立階層資料，並自訂 Treemap 與 Sunburst 圖表中的層級、標籤與顏色。"
---
## **概覽**

Treemap 與 Sunburst 圖表會顯示相同類型的階層資料，但它們使用不同的版面配置。Treemap 以巢狀矩形呈現階層，矩形的面積代表葉節點的值。Sunburst 以同心環呈現階層：最高層級的群組位於中心，葉節點則在最外層環。

在 Aspose.Slides for Java 中，每個數值都是一個[IChartDataPoint](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/)。其[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) 方法提供對葉節點及其父層級的存取。本章說明此對應關係，並展示如何使用相同的樣本資料建立與格式化兩種圖表。

![Treemap 圖表，顯示 Consumer 與 Business 分支](treemap-hierarchy.png)

![Sunburst 圖表，顯示相同的 Consumer 與 Business 階層](sunburst-hierarchy.png)

## **了解類別、資料點與層級**

以下樣本有三個類別層級與一個數值序列：

| 分支 | 主幹 | 葉節點 | 營收 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每一列會產生一個葉節點類別與一個資料點。類別的分組層級描述該葉節點到其父層級的路徑。第一列的路徑為 `Consumer > Computers > Laptops`。

[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) 所回傳的索引由葉節點向上遞增：

| `getDataPointLevels()` 索引 | 邏輯層級 | Treemap 表示 | Sunburst 表示 |
| ---: | --- | --- | --- |
| `0` | 葉節點 | 值矩形 | 外環段 |
| `1` | 主幹 | 父矩形或標題 | 中環段 |
| `2` | 分支 | 頂層矩形或標題 | 內環段 |

此順序對兩種圖表皆相同，儘管它們的視覺版面不同。父層級的區段會被多個葉節點共享。若要格式化它，請使用該群組中第一個資料點的相對層級。例如，`Consumer` 分支以 `Laptops` 資料點開始，而 `Software` 主幹則以 `Licenses` 資料點開始。保留對這些資料點的參照比使用不易理解的 `dataPoints.get_Item(0)` 或 `dataPoints.get_Item(6)` 更清晰且安全。

## **建立與自訂兩種圖表類型**

以下完整範例會在第一張投影片上建立 Treemap，第二張投影片上建立 Sunburst。它會建構階層、顯示 `Tablets` 的值、對選取的層級套用固定顏色、格式化分支標籤，最後儲存簡報。

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

        // 新增葉節點類別。僅在新群組開始時設定分組項目；
        // 之後的類別會保持在該群組中，直到設定另一個項目。
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

        // 在 Tablets 葉節點上顯示類別與數值。
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // 透過該分支的第一個葉節點格式化 Consumer 分支。
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
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
        Color softwareStemColor = new Color(112, 173, 71);
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

類別儲存格與數值儲存格使用相同的工作表列，因此它們的集合位置保持對齊。若是對現有圖表進行操作而非新建，請先檢查類別列，並將欲格式化的資料點與層級儲存為具名參照。

## **行為與實務考量**

### **Treemap 與 Sunburst 差異**

- Treemap 以面積傳遞數值，以巢狀矩形傳遞階層。此圖表類型的父標籤外觀可透過[IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) 方法控制。
- Sunburst 以角度傳遞數值，以環深度傳遞階層。`IChartSeries.setParentLabelLayout` 不會控制其環標籤。
- 兩種圖表皆使用相同的類別分組層級與由[IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) 回傳的葉節點至父層級順序，因而可以共用資料建構與層級格式化程式碼。
- 父層級的值是由其子葉節點計算得出。不要為分支或主幹另行加入數值點。

### **排序與區段順序**

圖表版面引擎會決定矩形與環段的最終位置。請在加入資料前將相關的類別列排在一起，但不要依賴特定的矩形位置或起始角度。若序列本身具備意義，請將其寫入標籤或改用具有明確類別軸的圖表類型。

### **佈景主題與固定顏色**

未格式化的圖表層級會從簡報佈景主題繼承顏色。範例使用明確的 RGB 填色以取得可預測的輸出。若圖表需隨佈景主題變化，請使用配色方案色彩而非固定 RGB，且避免對每個層級都覆寫。變更分支或主幹填色後，也請檢查標籤的對比度。

### **標籤與可用空間**

當區段過小時，PowerPoint 可能會隱藏或截斷標籤。增大圖表尺寸、縮短類別名稱或顯示較少的標籤欄位通常能得到更清晰的結果。標籤可透過[IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idatalabelformat/) 結合類別名稱、系列名稱與數值，但同時啟用所有欄位往往會讓階層圖表難以閱讀。

### **匯出與轉譯**

儲存為 PPTX 會保留圖表可編輯性。當 Aspose.Slides 將簡報轉譯為 PDF 或影像時，支援的填色與標籤設定會一併轉譯。字型替代與可用版面空間的細微差異可能會改變換行或標籤可見性，請安裝必要字型並驗證重要的匯出目標。

## **常見問題**

**為什麼變更父層級會影響多個葉節點？**

分支或主幹是一個共用的視覺區段。雖然可以透過子葉節點存取其[IChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ichartdatapointlevel/)，但格式設定屬於共享的父區段，而非單一葉節點。

**為什麼資料標籤消失了？**

先在標籤的[IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/idatalabelformat/) 物件上啟用所需的欄位，然後檢查該區段是否有足夠空間。Treemap 的父標籤版面、圖表尺寸、標籤長度、字型大小與啟用的欄位數量皆會影響標籤是否能顯示。

**我可以設定區段的精確順序或座標嗎？**

可以控制來源列的順序並確保每個群組是連續的，但無法直接指定 Treemap 矩形或 Sunburst 角度的精確位置。圖表版面引擎會根據階層、數值與可用空間計算它們。

**為什麼佈景主題變更後顏色會改變？**

以佈景主題為基礎的填色會遵循簡報調色盤。對必須固定的層級套用明確的 RGB 顏色，或在需要隨主題變更時保留配色方案色彩。

**自訂格式在 PDF 與影像匯出時會被保留嗎？**

會的，支援的圖表填色與標籤設定會在轉譯時一併加入。為確保跨系統的一致性，請提供必要的字型，並測試最終匯出尺寸，因為標籤的適配取決於版面配置。

## **相關參考**

- [Create Treemap charts](/slides/zh-hant/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/zh-hant/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/zh-hant/java/export-chart/)
- [Manage presentation themes](/slides/zh-hant/java/presentation-theme/)