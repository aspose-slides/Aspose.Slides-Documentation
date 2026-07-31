---
title: 使用 C++ 在簡報中自訂圖表坐標軸
linktitle: 圖表坐標軸
type: docs
url: /zh-hant/cpp/chart-axis/
keywords:
- 圖表坐標軸
- 垂直坐標軸
- 水平坐標軸
- 自訂坐標軸
- 操作坐標軸
- 管理坐標軸
- 坐標軸屬性
- 最大值
- 最小值
- 坐標軸線
- 日期格式
- 坐標軸標題
- 坐標軸位置
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "探索如何使用 Aspose.Slides for C++ 在 PowerPoint 簡報中自訂圖表坐標軸，以用於報告與視覺化。"
---
## **概覽**

本文說明如何在 Aspose.Slides 中自訂圖表坐標軸。它展示了如何取得實際坐標軸值、在坐標軸之間交換資料、隱藏折線圖的垂直或水平坐標軸、更改類別坐標軸類型、設定類別坐標軸值的日期格式、旋轉坐標軸標題、設定坐標軸位置，以及在數值坐標軸上顯示單位標籤。

## **取得垂直坐標軸的最大值**
Aspose.Slides for C++ 允許您取得垂直坐標軸的最小值與最大值。請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
1. 存取第一張投影片。
1. 新增一個使用預設資料的圖表。
1. 取得坐標軸的實際最大值。
1. 取得坐標軸的實際最小值。
1. 取得坐標軸的實際主要單位。
1. 取得坐標軸的實際次要單位。
1. 取得坐標軸的實際主要單位刻度。
1. 取得坐標軸的實際次要單位刻度。

此範例程式碼—上述步驟的實作—示範了如何在 C++ 中取得所需值：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// 保存簡報
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **交換坐標軸之間的資料**
Aspose.Slides 允許您快速交換坐標軸之間的資料——垂直坐標軸 (y 軸) 上的資料會移至水平坐標軸 (x 軸)，反之亦然。

此 C++ 程式碼示範如何在圖表的坐標軸之間執行資料交換：

``` cpp
// 建立空白簡報
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// 交換行與列
chart->get_ChartData()->SwitchRowColumn();

// 儲存簡報
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **為折線圖停用垂直坐標軸**

此 C++ 程式碼示範如何隱藏折線圖的垂直坐標軸：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **為折線圖停用水平坐標軸**

此程式碼示範如何隱藏折線圖的水平坐標軸：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **變更類別坐標軸**

使用 **set_CategoryAxisType()** 方法，您可以指定首選的類別坐標軸類型（**date** 或 **text**）。以下 C++ 程式碼示範此操作：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **設定類別坐標軸值的日期格式**
Aspose.Slides for C++ 允許您為類別坐標軸值設定日期格式。此 C++ 程式碼示範了此操作：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **設定坐標軸標題的旋轉角度**
Aspose.Slides for C++ 允許您設定圖表坐標軸標題的旋轉角度。此 C++ 程式碼示範了此操作：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **設定類別或數值坐標軸的位置**
Aspose.Slides for C++ 允許您在類別或數值坐標軸上設定位置坐標軸。此 C++ 程式碼說明了如何執行此任務：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **在圖表數值坐標軸上啟用顯示單位標籤**
Aspose.Slides for C++ 允許您設定圖表在其數值坐標軸上顯示單位標籤。此 C++ 程式碼示範了此操作：

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**如何設定兩條坐標軸交叉的值（坐標軸交叉）？**

坐標軸提供一個 [crossing setting](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/axis/set_crosstype/)：您可以選擇在零、在最大類別/數值，或在特定數值處交叉。此功能有助於上下移動 X 軸或強調基準線。

**如何相對於坐標軸定位刻度標籤（旁邊、外側、內側）？**

將 [label position](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/axis/set_majortickmark/) 設為 "cross"、"outside" 或 "inside"。此設定會影響可讀性，並有助於在小型圖表上節省空間。