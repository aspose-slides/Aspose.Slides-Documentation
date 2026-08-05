---
title: "在 C++ 中自訂簡報圖表的繪圖區"
linktitle: "繪圖區"
type: docs
url: /zh-hant/cpp/chart-plot-area/
keywords:
- 圖表
- 繪圖區
- 繪圖區寬度
- 繪圖區高度
- 繪圖區大小
- 版面配置模式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 簡報中自訂圖表的繪圖區，輕鬆提升投影片視覺效果。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中操作圖表的繪圖區。它解釋了如何透過驗證圖表佈局來取得繪圖區的實際位置與大小，並讀取其 X、Y、寬度與高度值。

此外，還示範了在手動設定佈局時，如何使用 `LayoutTargetType` 來定義繪圖區是根據其內部區域或包含軸線與軸標籤的外部區域來計算。

## **取得圖表繪圖區的寬度與高度**
Aspose.Slides for C++ 提供了簡單的 API。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 取得第一張投影片。
3. 新增使用預設資料的圖表。
4. 在取得實際值之前呼叫 IChart::ValidateChartLayout() 方法。
5. 取得圖表元素相對於圖表左上角的實際 X 位置（左）。
6. 取得圖表元素相對於圖表左上角的實際 Y 位置（上）。
7. 取得圖表元素的實際寬度。
8. 取得圖表元素的實際高度。

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// 儲存含圖表的簡報
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **設定圖表繪圖區的版面配置模式**
Aspose.Slides for C++ 提供了簡單的 API 來設定圖表繪圖區的版面配置模式。**LayoutTargetType** 屬性已新增至 **ChartPlotArea** 與 **IChartPlotArea** 類別。若手動定義繪圖區的佈局，這個屬性可指定是以內部（不包含軸線與軸標籤）或外部（包含軸線與軸標籤）來佈局。**LayoutTargetType** 列舉有兩個可能的值。

- **LayoutTargetType.Inner** - 指定繪圖區的大小僅由繪圖區本身決定，不包括刻度線與軸標籤。
- **LayoutTargetType.Outer** - 指定繪圖區的大小由繪圖區本身、刻度線與軸標籤共同決定。

以下提供範例程式碼。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **常見問題**

**ActualX、ActualY、ActualWidth 與 ActualHeight 以什麼單位回傳？**

以點 (point) 為單位；1 英吋 = 72 點。這是 Aspose.Slides 的座標單位。

**繪圖區與圖表區在內容上有何不同？**

繪圖區是資料繪製區域（系列、格線、趨勢線等）；圖表區則包含周邊元素（標題、圖例等）。在 3D 圖表中，繪圖區還包括牆面/底面與軸線。

**當佈局為手動時，繪圖區的 X、Y、寬度與高度如何解讀？**

它們是相對於圖表整體大小的比例 (0–1)；在此模式下會停用自動定位，使用者設定的比例將直接套用。

**為何在新增或移動圖例後繪圖區位置會變動？**

圖例位於圖表區的繪圖區之外，會影響佈局與可用空間，因此在啟用自動定位時，圖例的變動可能導致繪圖區移動。這是 PowerPoint 圖表的標準行為。