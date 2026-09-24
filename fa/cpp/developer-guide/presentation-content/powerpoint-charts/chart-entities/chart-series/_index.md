---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با C++
linktitle: سری‌های داده
type: docs
url: /fa/cpp/chart-series/
keywords:
- سری‌های نمودار
- هم‌پوشانی سری
- رنگ سری
- رنگ دسته
- نام سری
- نقطه داده
- فاصله سری
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "چگونه می‌توان سری‌های نموداری، نقاط داده، سلول‌های کارکتاب، قالب‌بندی، هم‌پوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با C++ مدیریت کرد."
---
## **مرور کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کارکتاب داده‌های نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/) در این سری به یک یا چند سلول کارکتاب ارجاع می‌دهد. اشیای [IChartCategory](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی را که توسط سری‌ها به اشتراک گذاشته می‌شوند فراهم می‌کنند. بنابراین نام سری، دسته‌ها و مقادیر نقاط به اشیای [IChartDataCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/) متصل هستند نه فقط به عنوان متن نمایشی ذخیره می‌شوند.

برای یک نمودار دسته‌ای معمولی، کارکتاب پیش‌فرض از ردیف 0 برای نام‌های سری، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر سری استفاده می‌کند. شاخص‌های کاربرگ، ردیف و ستون که به [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) پاس داده می‌شوند، صفر‑مبنا هستند. این ساختار زمانی که نمودار را با داده‌های پیش‌فرض ایجاد می‌کنید مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کارکتاب، سلول‌های ارجاع‌داده‌شده توسط سری‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه حوزه متفاوت وجود دارند:

- تنظیمات سطح سری، مانند [IChartSeries::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_format/)، ظاهر پیش‌فرض همه نقاط یک سری را فراهم می‌کند.
- تنظیمات نقطه‑داده، مانند [IChartDataPoint::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_format/)، ظاهر سری را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای سری‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند overlap یا gap width، از طریق [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) به گروه دسترسی پیدا کنید.

وقتی هیچ پرنگی صریح برای نقطه یا سری تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. هنگامی که هم تنظیمات سری و هم تنظیمات نقطه موجود باشد، تنظیمات نقطه برای آن نقطه در اولویت است.

![نمایش سری‌های نمودار در پاورپوینت](chart-series-powerpoint.png)

## **تنظیم هم‑پوشانی سری‌های نمودار**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_overlap/) گزارش می‌دهد که ستون‌ها یا نوارها در یک نمودار دو‑بعدی تا چه حد هم‌پوشانی دارند، از ‑100 تا 100 درصد. این یک پیش‌بینی فقط‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی همه سری‌های سازگار در آن گروه، [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) را فراخوانی کنید. این گزینه به نوع نمودارهایی که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های سری نامرتبط در یک نمودار ترکیبی اثر نمی‌گذارد.

مثال زیر هم‑پوشانی را برای گروهی که شامل اولین سری است تنظیم می‌کند:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// نمودار جدید شامل سری‌های نمونه، دسته‌ها و مقادیر است.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![هم‑پوشانی سری‌ها](series_overlap.png)

## **تغییر رنگ پرکننده سری**

از [IChartSeries::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_format/) برای تنظیم پرکننده پیش‌فرض یک سری کامل استفاده کنید. اگر برای یک نقطه پرکننده صریحی تنظیم شده باشد، تنظیمات [IChartDataPoint::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_format/) آن، پرکننده سری را برای آن نقطه بازنویسی می‌کند.

مثال زیر پرکنندهٔ آبی صلب را به اولین سری اعمال می‌کند:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![رنگ سری](series_color.png)

## **تغییر نام سری**

نام یک سری در کارکتاب داده‌های نمودار ذخیره می‌شود و به‌طور معمول در فهرست نمایش داده می‌شود. در کارکتاب پیش‌فرض ساخته‌شده برای یک نمودار ستونی خوشه‌ای، سلول B1 (ردیف 0، ستون 1) شامل نام اولین سری است. ثابت‌های نام‌گذاری شده در مثال زیر این ساختار را صریح می‌سازند:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

همچنین می‌توانید سلولی را که توسط [IChartSeries::get_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_name/) ارجاع شده است به‌روزرسانی کنید. این روش از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![نام سری](series_name.png)

## **دریافت رنگ پرکنندهٔ خودکار سری**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگی را برمی‌گرداند که بر اساس اندیس سری و سبک نمودار محاسبه می‌شود. این همان رنگی است که وقتی پرکنندهٔ سری به‌صورت صریح تعریف نشده باشد استفاده می‌شود. فراخوانی این متد رنگ محاسبه‌شده را می‌خواند؛ هیچ پرکننده جدیدی را اختصاص نمی‌دهد.

مثال زیر رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق به سبک و تم نمودار وابسته‌اند.

## **تنظیم رنگ پرکننده معکوس برای یک سری نمودار**

برای سری‌های میله، ستون و حباب، [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) می‌تواند مقادیر منفی را با پرکننده‌ای متفاوت نمایش دهد. پرکنندهٔ معمولی سری را به صلب تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) اختصاص دهید. اعداد منفی در کارکتاب بدون تغییر باقی می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 کاربرگ حاوی نام سری، ستون 0 حاوی نام دسته‌ها و ستون 1 حاوی مقادیر است:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![رنگ پرکنندهٔ صلب معکوس](inverted_solid_fill_color.png)

می‌توانید برای یک نقطهٔ خاص معکوس‌سازی را از طریق [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) فعال کنید. در مثال زیر، معکوس‌سازی برای سری غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال می‌شود. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **پاک کردن مقدار نقطهٔ دادهٔ خاص**

برای حذف یک نقطه بدون حذف سایر نقاط، سلول پشتیبان کارکتاب آن را به `nullptr` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) در دسترس است. نقطهٔ داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی بر اساس تنظیمات مقدار خالی نمودار در نظر می‌گیرد.

مثال زیر فقط نقطهٔ دوم در اولین سری را پاک می‌کند:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نمودارهای پراکندگی از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز از سلول اندازه بهره می‌برند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. وقتی می‌خواهید نقاط دیگر را نگه دارید، از فراخوانی [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) خودداری کنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

یک سلول خالی کارکتاب نشان‌دهنده دادهٔ گمشده است؛ یک سلول حاوی `0` نمایانگر یک مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [IChartDataCell::set_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_value/) را با `nullptr` فراخوانی کنید. رقم صفر عددی همچنان صفر می‌ماند صرف‌نظر از تنظیمات سلول خالی.

برای انتخاب نحوهٔ نمایش سلول‌های خالی در نمودار، از [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/set_displayblanksas/) استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. این گزینه نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد، بدون این‌که سلول خالی کارکتاب را با صفر یا مقدار درون‌خطی پر کند.

مثال خودمختار زیر یک نمودار خطی با یک سری ایجاد می‌کند، مقدار روز 3 را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌نماید. فایل ورودی موردنیاز نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/) از کاربرگ 0 استفاده می‌کند؛ ستون 0 برای برچسب‌های دسته، ستون 1 برای مقادیر؛ ردیف 0 نام سری را نگه می‌دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// روز 3 را به‌طور واقعی خالی بگذارید، در حالی که دسته‌بندی و نقطه دادهٔ آن را نگه دارید.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

هر فایل خروجی حالت انتساب‑شده قبل از ذخیره‌سازی را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیره تنها یک نسخه، حالت دلخواه را تنظیم کنید و فقط یک بار ارائه را ذخیره کنید به‌جای تکرار بر روی همهٔ حالت‌ها.

مقایسهٔ زیر همان داده‌ها را در سه فایل نشان می‌دهد. روز 3 در کارکتاب در هر حالت خالی است:

![نمودارهای خطی با دادهٔ یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌برد و Span روز 2 را به روز 4 وصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی سه حالت را به‌راحتی قابل مقایسه می‌کند. نمودارهای میله و ستون خطی برای وصل کردن بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش وصل‌شدهٔ نمایش‌داده‌شده در بالا را تولید کند؛ یک ستون خالی و یک ستون دارای ارتفاع صفر نیز می‌توانند شبیه هم به‌نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط با علامت‌گرها خط وصل‌کننده‌ای ندارد. انتظار نتایج متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوعی که استفاده می‌کنید بررسی کنید.

## **تنظیم عرض فاصلهٔ سری‌ها**

عرض فاصله (Gap width) فاصله بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مشابه overlap، این تنظیم متعلق به گروه سری والد است نه به یک سری تک. برای گروه یک بار [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) را فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌کند.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائهٔ نهایی را ذخیره می‌کند:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![عرض فاصله](gap_width.png)

## **سوالات متداول**

**کدام انواع نمودار از سری‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهای معرفی‌شده توسط перечисление [ChartType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/charttype/) از داده‌های نمودار استفاده می‌کنند، اما سری‌های آن‌ها ساختار یا تنظیمات مقداری یکسانی ندارند. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب اندازه حباب را اضافه می‌کنند. از روش ایجاد نقطه‑داده‌ای که با نوع سری مطابقت دارد استفاده کنید. گزینه‌هایی مانند overlap و gap width فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**گروه سری نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات نموداری سطح‑گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری دسترسی پیدا می‌کنید لزوماً تمام سری‌های موجود در نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته حاوی داده‌های پیش‌فرض است؟**

بله. به‌صورت پیش‌فرض، [IShapeCollection::AddChart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addchart/) نمونه‌ای از سری‌ها، دسته‌ها و مقادیر ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نمودار را بدون داده‌های پیش‌فرض ایجاد کند.

**چگونه اشیای نمودار به سلول‌های کارکتاب متصل می‌شوند؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه‑داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌دهند. تغییر سلول ارجاع‌داده‌شده عنصر مربوطه در نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر سری را طوری هماهنگ نگه دارید که هر نقطه زیر دستهٔ موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل سری پاک کنم؟**

سلول مقدار مربوطه را به `nullptr` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. فقط زمانی که قصد حذف تمام نقاط یک سری را دارید، [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) را فراخوانی کنید. اگر همچنین دسته‌ها را حذف می‌کنید، هر سری را به‌روزرسانی کنید تا مقادیرشان با مجموعه دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_displayblanksas/) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌عنوان فاصله، به‌عنوان مقدار صفر یا با وصل کردن نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای دادهٔ گمشده در ارائهٔ شما سازگار باشد. برای مثال کامل و مقایسهٔ تصویری به بخش «کنترل نمایش سلول‌های خالی» مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های میله، ستون و حباب پشتیبانی‌شده، [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) را صدا بزنید و رنگ را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**زمانی که هم سری و هم نقطه قالب‌بندی شده باشند، کدامیک برنده می‌شود؟**

قالب‌بندی صریح نقطه‑داده برای آن نقطه در اولویت است. سایر نقاط همچنان از قالب صریح سری یا، اگر قالب سری تعریف نشده باشد، از سبک و تم خودکار نمودار استفاده می‌کنند. تنظیمات گروه مانند overlap و gap width برچسب‌های چیدمان را کنترل می‌کنند و بازنویسی قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد سری‌ها تعیین نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و خوانایی نمودار تعیین‌کنندهٔ حد عملی هستند.

**اگر ستون‌ها بیش از حد نزدیک یا دور از هم باشند، چه کاری باید انجام دهم؟**

در گروه سری والد مربوطه، [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) را فراخوانی کنید. مقدار را افزایش دهید تا فضای بین خوشه‌ها عریض‌تر شود یا کاهش دهید تا خوشه‌ها به‌یکدیگر نزدیک‌تر شوند.