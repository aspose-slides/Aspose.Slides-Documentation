---
title: 優化 C++ 簡報中的圖表計算
linktitle: 圖表計算
type: docs
weight: 50
url: /zh-hant/cpp/chart-calculations/
keywords:
- 圖表計算
- 圖表元素
- 元素位置
- 實際位置
- 子元素
- 父元素
- 圖表值
- 實際值
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 中圖表計算、資料更新與精度控制，適用於 PPT 與 PPTX，並附有實用的 C++ 程式碼範例。"
---
## **概觀**

Aspose.Slides 為在簡報中處理圖表計算和版面配置資料提供 API。本文說明如何取得圖表元素的實際值，包括實作 `IActualLayout` 的元素之真實位置與大小，以及圖表座標軸的實際值。亦會說明這些值會在圖表版面配置驗證之後才會填入。

此外，本文示範如何取得父圖表元素的實際位置，以及如何隱藏圖表元件（如標題、座標軸、圖例與格線）。透過這些範例，您可以以程式方式檢查圖表版面資訊，並控制 PowerPoint 簡報中圖表元素的可見性。

## **計算圖表元素的實際值**
Aspose.Slides for C++ 提供簡易的 API 來取得這些屬性。這可協助您 **計算圖表元素的實際值**。實際值包括實作 IActualLayout 介面的元素位置（IActualLayout::get_ActualX()、IActualLayout::get_ActualY()、IActualLayout::get_ActualWidth()、IActualLayout::get_ActualHeight()）以及座標軸的實際值（IAxis::get_ActualMaxValue()、IAxis::get_ActualMinValue()、IAxis::get_ActualMajorUnit()、IAxis::get_ActualMinorUnit()、IAxis::get_ActualMajorUnitScale()、IAxis::get_ActualMinorUnitScale()）。

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// 儲存簡報
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **計算父圖表元素的實際位置**
Aspose.Slides for C++ 提供簡易的 API 來取得這些屬性。IActualLayout 的方法可提供父圖表元素的實際位置資訊。必須先呼叫 IChart::ValidateChartLayout() 方法，以在屬性中填入實際值。

``` cpp
// 建立空白簡報
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **隱藏圖表元素**
本章節說明如何在圖表中隱藏資訊。使用 Aspose.Slides for C++，您可以隱藏 **標題、垂直座標軸、水平座標軸** 與 **格線**。以下程式碼範例示範如何使用這些屬性。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **為圖表設定資料範圍**
Aspose.Slides for C++ 提供最簡易的 API，以最直接的方式設定圖表的資料範圍。設定圖表資料範圍的步驟如下：

- 開啟包含圖表的 **Presentation** 類別實例。
- 依索引取得投影片的參考。
- 遍歷所有圖形以尋找目標圖表。
- 取得圖表資料並設定範圍。
- 將修改後的簡報儲存為 PPTX 檔案。

以下程式碼範例示範如何更新圖表。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **常見問題**

**外部 Excel 活頁簿可以作為資料來源嗎？這會如何影響重新計算？**

是。圖表可以參照外部活頁簿：當您連接或重新整理外部來源時，公式與值會從該活頁簿取得，圖表會在開啟或編輯時反映更新。API 允許您[指定外部活頁簿](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/setexternalworkbook/)的路徑，並管理連結資料。

**我可以在不自行實作回歸的情況下計算並顯示趨勢線嗎？**

可以。[趨勢線](/slides/zh-hant/cpp/trend-line/)（線性、指數等）由 Aspose.Slides 自動加入並更新；其參數會根據系列資料自動重新計算，您無需自行實作計算。

**如果簡報中有多個圖表帶有外部連結，我能控制每個圖表使用哪一本活頁簿來計算值嗎？**

可以。每個圖表可以指向自己的[外部活頁簿](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartdata/setexternalworkbook/)，亦或您可以為每個圖表獨立建立或取代外部活頁簿，互不影響。