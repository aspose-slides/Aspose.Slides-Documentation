---
title: 自訂 C++ 中 Treemap 與 Sunburst 圖表的資料點
linktitle: Treemap 與 Sunburst 圖表的資料點
type: docs
url: /zh-hant/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- Treemap 圖表
- Sunburst 圖表
- 階層圖表
- 資料點
- 資料標籤
- 分支顏色
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "瞭解如何使用 Aspose.Slides for C++ 建立階層資料，並自訂 Treemap 與 Sunburst 圖表的層級、標籤與顏色。"
---
## **概覽**

Treemap 與 Sunburst 圖表顯示相同類型的階層資料，但使用不同的版面配置。Treemap 以嵌套矩形呈現階層，其面積代表葉節點值。Sunburst 則以同心環呈現：最高層級的群組位於中心，葉節點類別位於外環。

在 Aspose.Slides for C++ 中，每個數值都是一個 [IChartDataPoint](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/)。其 [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) 方法可存取葉節點及其父群組。本文說明此對應關係，並展示如何使用相同的樣本資料建立與格式化兩種圖表類型。

![包含 Consumer 與 Business 分支的 Treemap 圖表](treemap-hierarchy.png)

![相同 Consumer 與 Business 階層的 Sunburst 圖表](sunburst-hierarchy.png)

## **了解類別、資料點和層級**

以下範例包含三個類別層級和一個數值序列：

| 分支 | 幹線 | 葉節 | 營收 |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

每一列會建立一個葉節點類別和一個資料點。類別分組層級描述從該葉節點到其父層的路徑。對於第一列，路徑為 `Consumer > Computers > Laptops`。

[IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) 回傳的索引由葉節點向上：

| `get_DataPointLevels()` index | 邏輯層級 | Treemap 表示方式 | Sunburst 表示方式 |
| ---: | --- | --- | --- |
| `0` | Leaf | Value rectangle | Outer-ring segment |
| `1` | Stem | Parent rectangle or header | Middle-ring segment |
| `2` | Branch | Top-level rectangle or header | Inner-ring segment |

此順序對兩種圖表類型皆相同，儘管其視覺版面不同。父層區段會被多個葉節點共享。若要格式化它，請使用該群組中第一個資料點的相應層級。例如，`Consumer` 分支從 `Laptops` 點開始，而 `Software` 幹線則從 `Licenses` 點開始。保留這些點的參照比使用未說明的表達式如 `dataPoints->idx_get(0)` 或 `dataPoints->idx_get(6)` 更直觀且安全。

## **建立與自訂兩種圖表類型**

以下完整範例在第一張投影片建立 Treemap，於第二張投影片建立 Sunburst。它建構階層，顯示 `Tablets` 的數值，對選定層級套用固定顏色，格式化分支標籤，並儲存簡報。

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // 新增葉節點類別。僅在新群組開始時設定分組項目；
    // 隨後的類別將保持在該群組中，直至設定另一個項目。
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // 在 Tablets 葉節點上顯示類別和數值。
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // 透過該分支的第一個葉節點格式化 Consumer 分支。
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // 透過該幹線的第一個葉節點格式化 Software 幹線。
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout 會影響 Treemap 的父標籤；Sunburst 使用環段。
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

類別儲存格與數值儲存格使用相同的工作表列，因此其集合位置保持對齊。當您處理已存在的圖表而非新建時，先檢查類別列，並將欲格式化的資料點與層級儲存為具名參照。

## **行為與實務考量**

### **Treemap 與 Sunburst 差異**

- Treemap 以面積傳達值，以嵌套矩形傳達階層。此圖表類型的父標籤顯示方式由 [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) 方法控制。
- Sunburst 以角度傳達值，以環層深度傳達階層。[IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) 不會控制其環標籤。
- 兩種圖表均使用相同的類別分組層級與 [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) 返回的葉節點至父層順序，因而資料建構與層級格式化程式碼可以共用。
- 父層值是由其下屬葉節點計算得出。不要為分支或幹線另行加入數值點。

### **排序與區段順序**

圖表版面引擎決定矩形與環段的最終位置。將相關類別列排在一起後再加入圖表，但不要依賴特定的矩形位置或起始角度。如順序具備意義，請將其寫入標籤或改用具明確類別軸的圖表類型。

### **佈景主題與固定顏色**

未格式化的圖表層級會從簡報佈景繼承顏色。範例使用明確的 RGB 填色以產生可預測的輸出。若圖表需隨佈景變化，請改用配色方案顏色且避免覆寫每一層。變更分支或幹線填色後，也請檢查標籤對比度。

### **標籤與可用空間**

當區段過小時，PowerPoint 可能會隱藏或截斷標籤。調整圖表大小、縮短類別名稱或減少顯示的標籤欄位通常能得到較清晰的結果。標籤可透過 [IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/idatalabelformat/) 同時顯示類別名稱、序列名稱與數值，但開啟全部欄位往往會使階層圖表難以閱讀。

### **匯出與算繪**

保存為 PPTX 可保留圖表的可編輯性。當 Aspose.Slides 將簡報算繪為 PDF 或影像時，支援的填色與標籤設定會隨圖表一起算繪。字型置換與可用版面空間的細微差異可能改變換行或標籤可視性，請安裝所需字型並驗證重要的匯出目標。

## **常見問答**

**為何變更父層會影響多個葉節點？**

分支或幹線是一個共享的視覺區段。它的 [IChartDataPointLevel](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/ichartdatapointlevel/) 可透過任一子葉節點取得，但格式設定屬於共享的父區段，而非僅屬於該葉節點。

**為何資料標籤缺失？**

先在標籤的 [IDataLabelFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/idatalabelformat/) 物件上啟用所需欄位，然後檢查該區段是否有足夠空間。Treemap 的父標籤版面、圖表尺寸、標籤長度、字型大小以及啟用的欄位數量都會影響標籤是否能顯示。

**我能設定區段的精確順序或座標嗎？**

您可以控制來源列的順序並確保每個群組保持連續，但無法直接指定 Treemap 矩形或 Sunburst 角度的精確位置。圖表版面引擎會根據階層、數值與可用空間計算它們。

**為何在變更簡報佈景主題後顏色會改變？**

基於佈景的填色設計為跟隨簡報調色盤。對必須固定的層級套用明確的 RGB 顏色，或在需要隨新佈景調整時保留配色方案顏色。

**自訂格式化在 PDF 與影像匯出時會保留嗎？**

會的，支援的圖表填色與標籤設定在算繪時會被納入。為確保跨系統結果一致，請提供所需字型並測試最終匯出尺寸，因為標籤適配取決於版面配置。

## **相關參考**

- [建立 Treemap 圖表](/slides/zh-hant/cpp/create-chart/#create-tree-map-charts)
- [建立 Sunburst 圖表](/slides/zh-hant/cpp/create-chart/#create-sunburst-charts)
- [匯出簡報圖表](/slides/zh-hant/cpp/export-chart/)
- [管理簡報佈景主題](/slides/zh-hant/cpp/presentation-theme/)