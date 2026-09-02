---
title: 在 PHP 中自訂 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/php-java/data-points-of-treemap-and-sunburst-chart/
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
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 建立階層資料，並自訂 Treemap 與 Sunburst 圖表的層級、標籤與顏色。"
---
## **概述**

Treemap 和 Sunburst 圖表顯示相同類型的階層資料，但使用不同的版面配置。Treemap 以嵌套矩形呈現階層，矩形面積代表葉節點的值。Sunburst 則以同心環呈現：最高層級的群組位於中心附近，葉節點分類位於最外環。

In Aspose.Slides for PHP via Java 中，每個數值都是一個 [ChartDataPoint](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/)。它的 [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) 方法提供對葉節點及其父群組的存取。本文說明此對應關係，並展示如何使用相同的樣本資料建立與格式化兩種圖表類型。

![一個包含 Consumer 和 Business 分支的 Treemap 圖表](treemap-hierarchy.png)

![一個具有相同 Consumer 和 Business 階層的 Sunburst 圖表](sunburst-hierarchy.png)

## **了解類別、資料點與層級**

以下範例使用三個類別層級和一個數值系列：

| 分支 | 子類別 | 葉節點 | 營收 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每一列會建立一個葉節點類別以及一個資料點。類別分組層級描述從該葉節點到其父層級的路徑。對於第一列，路徑為 `Consumer > Computers > Laptops`。

由 [ChartDataPoint.getDataPointLevels] 回傳的索引從葉節點向上計算：

| `getDataPointLevels()` 索引 | 邏輯層級 | Treemap 表示 | Sunburst 表示 |
| ---: | --- | --- | --- |
| `0` | 葉節點 | 值矩形 | 外環段 |
| `1` | 子類別 | 父矩形或標題 | 中環段 |
| `2` | 分支 | 頂層矩形或標題 | 內環段 |

即使兩種圖表的視覺版面不同，這個順序在兩者中皆相同。父段落會被多個葉節點共用。若要格式化它，請使用該群組中第一個資料點的相應層級。例如，`Consumer` 分支的起始點是 `Laptops`，而 `Software` 子類別的起始點是 `Licenses`。保留對這些資料點的參照比使用未說明的表達式（如 `$dataPoints->get_Item(0)` 或 `$dataPoints->get_Item(6)`）更清晰且安全。

## **建立與自訂兩種圖表類型**

以下完整範例在第一投影片上建立 Treemap，於第二投影片上建立 Sunburst。它建立階層、顯示 `Tablets` 的值、對選定層級套用固定顏色、格式化分支標籤，並儲存簡報。

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // 加入葉節點類別。僅在新的群組開始時設定分組項目；
        // 隨後的類別會保持在該群組中，直到再設定其他項目。
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // 在 Tablets 葉節點上顯示類別和數值。
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // 透過該分支的第一個葉節點格式化 Consumer 分支。
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // 透過該幹的第一個葉節點格式化 Software 幹。
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout 會影響 Treemap 的父標籤；Sunburst 使用環段。
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

類別儲存格與數值儲存格使用相同的工作表列，因此其集合位置保持對齊。當您處理現有圖表而非建立新圖表時，請先檢查類別列，並保存要格式化之資料點與層級的具名參照。

## **行為與實務考量**

### **Treemap 與 Sunburst 的差異**

- Treemap 以面積傳達數值，並以嵌套矩形傳達階層。[ChartSeries.setParentLabelLayout] 方法控制此圖表類型中父標籤的顯示方式。
- Sunburst 以角度傳達數值，並以環深度傳達階層。[ChartSeries.setParentLabelLayout] 不會控制其環標籤。
- 兩種圖表皆使用相同的類別分組層級以及 [ChartDataPoint.getDataPointLevels] 回傳的相同葉節點至父層級順序，故資料建構與層級格式化程式碼可共用。
- 父層級的數值由其子葉節點計算得出。不要為分支或子類別另外新增數值點。

### **排序與段落順序**

圖表版面引擎決定矩形與環段的最終位置。請在加入之前先將相關類別列排序在一起，但不要依賴特定的矩形位置或起始角度。如果順序具有意義，請將其納入標籤或使用具明確類別軸的圖表類型。

### **佈景主題與固定顏色**

未格式化的圖表層級會繼承簡報主題的顏色。範例使用明確的 RGB 填色以獲得可預測的輸出。若圖表需跟隨主題變更，請使用配色方案顏色而非固定的 RGB 值，且避免對每個層級皆進行覆寫。變更分支或子類別填色後，也請檢查標籤的對比度。

### **標籤與可用空間**

當段落過小時，PowerPoint 可能會隱藏或截斷標籤。增大圖表大小、縮短類別名稱或顯示較少的標籤欄位通常可得到更清晰的結果。標籤可透過 [DataLabelFormat] 結合類別名稱、系列名稱與數值，但啟用所有欄位往往會使階層圖表不易閱讀。

儲存為 PPTX 會保留圖表可編輯性。當 Aspose.Slides 將簡報渲染為 PDF 或影像時，支援的填色與標籤設定會與圖表一起渲染。字型替換以及可用版面空間的微小差異可能會改變換行或標籤可見性，故請安裝所需字型並確認重要的匯出目標。

## **常見問題**

**為何變更父層級會影響多個葉節點？**

分支或子類別是共用的視覺段落。其 [ChartDataPointLevel] 可透過子葉節點存取，但格式化屬於共用的父段落，而非僅屬於該葉節點。

**為何資料標籤遺失？**

首先在標籤的 [DataLabelFormat] 物件上啟用所需欄位。接著檢查該段落是否有足夠空間。Treemap 的父標籤版面配置、圖表尺寸、標籤長度、字型大小以及啟用的欄位數量皆會影響標籤是否能顯示。

**我能設定段落的精確順序或座標嗎？**

您可以控制來源列的順序並保持每個群組連續，但無法指派精確的 Treemap 矩形或 Sunburst 角度。圖表版面引擎會根據階層、數值與可用空間計算它們。

**為何簡報主題變更後顏色會改變？**

基於主題的填色會跟隨簡報調色盤。對必須保持固定的層級套用明確的 RGB 顏色，或在需要適應新主題時保留配色方案顏色。

**自訂格式在 PDF 與影像匯出時會保留嗎？**

會的，支援的圖表填色與標籤設定會在渲染時保留下來。為確保跨系統的一致結果，請提供必要的字型，並測試最終匯出尺寸，因為標籤適應取決於版面配置。

## **參見**

- [建立 Treemap 圖表](/slides/zh-hant/php-java/create-chart/#create-tree-map-charts)
- [建立 Sunburst 圖表](/slides/zh-hant/php-java/create-chart/#create-sunburst-charts)
- [匯出簡報圖表](/slides/zh-hant/php-java/export-chart/)
- [管理簡報主題](/slides/zh-hant/php-java/presentation-theme/)