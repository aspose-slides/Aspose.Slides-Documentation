---
title: 在 C++ 中自訂簡報圖表的繪圖區
linktitle: 繪圖區
type: docs
url: /zh-hant/cpp/chart-plot-area/
keywords:
- 圖表
- 繪圖區
- 繪圖區寬度
- 繪圖區高度
- 繪圖區大小
- 佈局模式
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 簡報中自訂圖表的繪圖區，輕鬆提升投影片視覺效果。"
---
## **概述**

本文說明如何在 Aspose.Slides 中使用圖表的繪圖區。它解釋了透過驗證圖表佈局，然後讀取其 X、Y、寬度和高度值，如何取得繪圖區的實際位置和尺寸。

它還示範了在手動設定佈局時，如何使用 `LayoutTargetType` 來配置繪圖區的佈局模式，定義繪圖區是根據其內部區域，還是連同坐標軸與軸標籤的外部區域來計算。

## **取得圖表繪圖區的寬度與高度**
Aspose.Slides for C++ 提供簡單的 API 用於 .

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
1. 取得第一張投影片。
1. 新增具有預設資料的圖表。
1. 在取得實際值之前呼叫 IChart::ValidateChartLayout() 方法。
1. 取得圖表元件相對於圖表左上角的實際 X 位置（左側）。
1. 取得圖表元件相對於圖表左上角的實際 Y 位置（頂部）。
1. 取得圖表元件的實際寬度。
1. 取得圖表元件的實際高度。

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.Pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// 儲存包含圖表的簡報
pres->Save(u"Chart_out.pptx", SaveFormat::Pptx);
```

## **設定圖表繪圖區的佈局模式**
Aspose.Slides for C++ 提供簡單的 API 以設定圖表繪圖區的佈局模式。已在 **ChartPlotArea** 與 **IChartPlotArea** 類別中加入屬性 **LayoutTargetType**。如果繪圖區的佈局是手動定義的，此屬性會指定是依其內部（不包含坐標軸與軸標籤）還是外部（包含坐標軸與軸標籤）來佈局繪圖區。**LayoutTargetType** 列舉定義了兩個可能的值。

- **LayoutTargetType.Inner** - 指定繪圖區的大小應決定繪圖區的尺寸，不包括刻度線與坐標軸標籤。
- **LayoutTargetType.Outer** - 指定繪圖區的大小應決定繪圖區的尺寸、刻度線與坐標軸標籤。

以下提供範例程式碼。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetLayoutMode-SetLayoutMode.cpp" >}}

## **常見問題**

**ActualX、ActualY、ActualWidth 與 ActualHeight 的單位為何？**

以點 (point) 為單位；1 英吋 = 72 點。這是 Aspose.Slides 的座標單位。

**繪圖區在內容上如何與圖表區不同？**

繪圖區是資料繪製區域（系列、格線、趨勢線等）；圖表區則包含周圍的元素（標題、圖例等）。在 3D 圖表中，繪圖區還包括牆面/底面以及坐標軸。

**當佈局為手動時，繪圖區的 X、Y、寬度與高度如何解釋？**

它們是圖表整體尺寸的比例（0–1）；在此模式下，會停用自動定位，使用您設定的比例值。

**為何在新增/移動圖例後繪圖區位置會變動？**

圖例位於圖表區的繪圖區之外，但會影響佈局與可用空間，因此在自動定位生效時，繪圖區可能會移動。（這是 PowerPoint 圖表的標準行為。）