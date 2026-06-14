---
title: 使用 C++ 在簡報中管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/cpp/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 類別顏色
- 系列名稱
- 資料點
- 系列間距
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 C++ 中管理 PowerPoint (PPT/PPTX) 的圖表系列，並透過實用程式碼範例與最佳實踐提升資料簡報的效果。"
---
## **概述**

本文件說明了 Aspose.Slides 中 [ChartSeries](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartseries/) 的角色，重點在於資料在簡報中的結構與可視化方式。這些物件提供了定義圖表中各個資料點集合、類別與外觀參數的基礎元素。透過使用 [ChartSeries](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chartseries/)，開發人員能夠無縫整合底層資料來源，並完整掌控資訊的顯示方式，從而產生動態、資料驅動的簡報，清晰傳達見解與分析。

系列是圖表中繪製的一行或一列數字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定資料系列重疊**

使用 [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) 方法，您可以指定 2D 圖表中條形與柱形的重疊程度（範圍：-100 到 100）。此屬性套用到父系列群組的所有系列：這是相應群組屬性的投射。

使用 `get_ParentSeriesGroup()::set_Overlap()` 方法為 `Overlap` 設定您偏好的值。

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
1. 在投影片上新增叢集柱狀圖。
1. 存取第一個圖表系列。
1. 存取圖表系列的 `ParentSeriesGroup` 並為該系列設定您偏好的重疊值。
1. 將修改後的簡報寫入 PPTX 檔案。

此 C++ 程式碼示範如何為圖表系列設定重疊：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // 設定系列重疊
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Writes the presentation file to disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **變更資料系列顏色**

Aspose.Slides for C++ 允許您這樣變更系列的顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
1. 在投影片上新增圖表。
1. 存取您想變更顏色的系列。
1. 設定您偏好的填充類型與填充顏色。
1. 儲存修改後的簡報。

此 C++ 程式碼示範如何變更系列的顏色：

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **變更資料系列類別的顏色**

Aspose.Slides for C++ 允許您這樣變更系列類別的顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
1. 在投影片上新增圖表。
1. 存取您想變更顏色的系列類別。
1. 設定您偏好的填充類型與填充顏色。
1. 儲存修改後的簡報。

此 C++ 程式碼示範如何變更系列類別的顏色：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **變更資料系列名稱**

預設情況下，圖表的圖例名稱會取自每個欄位或列上方儲存格的內容。

在我們的範例（示意圖）中，

* 列是 *Series 1, Series 2,* 與 *Series 3*；
* 行是 *Category 1, Category 2, Category 3,* 與 *Category 4*。

Aspose.Slides for C++ 允許您在圖表資料與圖例中更新或變更系列名稱。

此 C++ 程式碼示範如何在圖表資料 `ChartDataWorkbook` 中變更系列名稱：

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

此 C++ 程式碼示範如何透過 `Series` 在圖例中變更系列名稱：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **設定資料系列填充顏色**

Aspose.Slides for C++ 允許您這樣在繪圖區域內為圖表系列設定自動填充顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
1. 依索引取得投影片的參照。
1. 依您偏好的類型新增預設資料圖表（以下範例使用 `ChartType::ClusteredColumn`）。
1. 存取圖表系列並將填充顏色設定為 Automatic。
1. 將簡報儲存為 PPTX 檔案。

此 C++ 程式碼示範如何為圖表系列設定自動填充顏色：

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// 建立叢集柱狀圖
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// 將系列填充格式設定為自動
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// 將簡報檔案寫入磁碟
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **設定資料系列反轉填充顏色**

Aspose.Slides 允許您這樣在繪圖區域內為圖表系列設定反轉填充顏色：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
1. 依索引取得投影片的參照。
1. 依您偏好的類型新增預設資料圖表（以下範例使用 `ChartType::ClusteredColumn`）。
1. 存取圖表系列並將填充顏色設定為 invert。
1. 將簡報儲存為 PPTX 檔案。

此 C++ 程式碼示範此操作：

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **為圖表系列設定反轉填充顏色**

Aspose.Slides 允許您透過 `IChartDataPoint::set_InvertIfNegative()` 與 `ChartDataPoint.set_InvertIfNegative()` 方法設定反轉。當使用這些方法設定反轉時，資料點在取得負值時會反轉其顏色。

此 C++ 程式碼示範此操作：

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **清除特定資料點值**

Aspose.Slides for C++ 允許您這樣清除特定圖表系列的 `DataPoints` 資料：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 依索引取得投影片的參照。
3. 依索引取得圖表的參照。
4. 迭代所有圖表的 `DataPoints`，將 `XValue` 與 `YValue` 設為 null。
5. 清除特定圖表系列的所有 `DataPoints`。
6. 將修改後的簡報寫入 PPTX 檔案。

此 C++ 程式碼示範此操作：

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **設定資料系列間隙寬度**

Aspose.Slides for C++ 允許您透過 **`set_GapWidth()`** 方法為系列設定間隙寬度：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
1. 存取第一張投影片。
1. 新增預設資料圖表。
1. 存取任意圖表系列。
1. 設定 `GapWidth` 屬性。
1. 將修改後的簡報寫入 PPTX 檔案。

此 C++ 程式碼示範如何設定系列的間隙寬度：

```cpp
// 建立空白簡報 
auto presentation = System::MakeObject<Presentation>();

// 取得簡報的第一張投影片
auto slide = presentation->get_Slides()->idx_get(0);

// 新增具有預設資料的圖表
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// 設定圖表資料工作表的索引
int32_t worksheetIndex = 0;

// 取得圖表資料工作表
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// 新增系列
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// 新增類別
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// 取得第二個圖表系列
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// 填入系列資料
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// 設定間隙寬度值
series->get_ParentSeriesGroup()->set_GapWidth(50);

// 將簡報儲存至磁碟
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**單一圖表可包含的系列數量有上限嗎？**

Aspose.Slides 不對您加入的系列數量設定固定上限。實際限制取決於圖表的可讀性以及您的應用程式可用的記憶體。

**如果叢集內的柱狀圖過於靠近或過於分散該怎麼辦？**

調整該系列（或其父系列群組）的間隙寬度設定。增大數值會擴大柱狀圖之間的間距，減小則會使它們更靠近。