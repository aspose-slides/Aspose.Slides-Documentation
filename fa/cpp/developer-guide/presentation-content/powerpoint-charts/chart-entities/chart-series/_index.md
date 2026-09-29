---
title: مدیریت مجموعه داده‌های نمودار در ارائه‌ها با C++
linktitle: مجموعه داده‌ها
type: docs
url: /fa/cpp/chart-series/
keywords:
- مجموعه نمودار
- همپوشانی مجموعه
- رنگ مجموعه
- رنگ دسته
- نام مجموعه
- نقطه داده
- فاصله مجموعه
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "بیاموزید چگونه مجموعه‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با C++ مدیریت کنید."
---
## **بررسی کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/) یک مجموعه از مقادیر مرتبط را نمایش می‌دهد و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار ارجاع می‌دهد. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک توسط مجموعه‌ها را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌بندی‌ها و مقادیر نقاط به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/) متصل هستند نه اینکه فقط به‌عنوان متن نمایش ذخیره شوند.

در یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض ردیف 0 را برای نام مجموعه‌ها، ستون 0 را برای نام دسته‌ها و بقیه سلول‌ها را برای مقادیر مجموعه‌ها استفاده می‌کند. شاخص‌های کاربرگ، ردیف و ستون که به [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) پاس داده می‌شوند، بر پایه صفر هستند. این چیدمان هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

Chart settings have three different scopes:

- تنظیمات سطح مجموعه، مانند [IChartSeries::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_format/) ظاهر پیش‌فرض را برای تمام نقاط یک مجموعه فراهم می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_format/) ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی بر مجموعه‌های سازگار که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/) تعلق دارند اعمال می‌شود. هنگامی که نیاز به تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله دارید، گروه را از طریق [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) دسترسی پیدا کنید.

وقتی پرشدگی صریح برای نقطه یا مجموعه تنظیم نشده باشد، استایل و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم فرمت‌بندی مجموعه و هم نقطه وجود داشته باشد، فرمت‌بندی نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی مجموعه نمودار**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_overlap/) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دو‌بعدی چقدر همپوشانی دارند، از -100 تا 100 درصد. این یک تصویر فقط-خواندنی از تنظیمات در گروه مجموعه والد است. برای به‌روزرسانی تمام مجموعه‌های سازگار در آن گروه، [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) را فراخوانی کنید. این گزینه برای انواع نمودارهایی که نوارها یا ستون‌های گروه‌بندی‌شده را نمایش می‌دهند اعمال می‌شود؛ اما بر گروه‌های مجموعه نامرتبط در یک نمودار ترکیبی تأثیر نمی‌گذارد.

مثال زیر همپوشانی برای گروهی که اولین مجموعه را شامل می‌شود تنظیم می‌کند:

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

// نمودار جدید شامل مجموعه‌های نمونه، دسته‌ها و مقادیر است.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![همپوشانی مجموعه](series_overlap.png)

## **تغییر رنگ پرشدگی مجموعه**

از [IChartSeries::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_format/) برای تنظیم پرشدگی پیش‌فرض کل مجموعه استفاده کنید. اگر یک نقطه قبلاً پرشدگی صریح داشته باشد، تنظیم [IChartDataPoint::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_format/) آن پرشدگی را برای آن نقطه بازنویسی می‌کند.

مثال زیر یک پرشدگی آبی جامد را به اولین مجموعه اعمال می‌کند:

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

![رنگ مجموعه](series_color.png)

## **تغییر نام مجموعه**

نام یک مجموعه در کتاب‌کار داده نمودار ذخیره می‌شود و معمولاً در legend (راهنما) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را شامل می‌شود. ثابت‌های نام‌گذاری شده در مثال زیر این ساختار را به‌صورت واضح نشان می‌دهند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries::get_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_name/) ارجاع شده را به‌روزرسانی کنید. این رویکرد از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

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

![نام مجموعه](series_name.png)

## **دریافت رنگ پرشدگی خودکار مجموعه**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگی را بر می‌گرداند که از شاخص مجموعه و استایل نمودار محاسبه می‌شود. این رنگ هنگامی که پرشدگی مجموعه صریحاً تعریف نشده باشد استفاده می‌شود. فراخوانی این متد رنگ محاسبه‌شده را می‌خواند؛ یک پرشدگی جدید تخصیص نمی‌دهد.

مثال زیر رنگ خودکار هر مجموعه پیش‌فرض را چاپ می‌کند:

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

خروجی مثال برای استایل پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق وابسته به استایل و تم نمودار هستند.

## **تنظیم رنگ پرشدگی معکوس برای مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) می‌تواند مقادیر منفی را با یک پرشدگی متفاوت نمایش دهد. پرشدگی معمولی مجموعه را به حالت جامد تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) اختصاص دهید. اعداد منفی در کتاب‌کار بدون تغییر می‌مانند؛ فقط رنگ نمایش آن‌ها تغییر می‌کند.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 کاربرگ نام مجموعه را دارد، ستون 0 نام دسته‌ها و ستون 1 مقادیر را شامل می‌شود:

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

![رنگ پرشدگی جامد معکوس](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه با استفاده از [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) معکوس‌سازی را فعال کنید. در مثال زیر، معکوس‌سازی برای مجموعه غیرفعال و تنها برای نقطه انتخاب‌شده فعال شده است. همچنین به نقطه یک مقدار منفی اختصاص داده می‌شود تا اثر قابل مشاهده باشد:

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

## **پاک‌سازی مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف نقاط دیگر، سلول پشتیبان کتاب‌کار آن را به `nullptr` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را طبق تنظیمات مقدار خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر تنها نقطه دوم در اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی همچنین از یک سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید پاک کنید. وقتی می‌خواهید نقاط دیگر را نگه دارید، از فراخوانی [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) خودداری کنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که حاوی مقادیر هستند مورد متفاوتی نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی کاربرگ، به [Include Data from Hidden Rows and Columns](/slides/fa/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی در کتاب‌کار نشان‌دهنده داده‌های گمشده است؛ سلولی که حاوی `0` است نمایانگر مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [IChartDataCell::set_Value](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/set_value/) را با `nullptr` فراخوانی کنید. صفر عددی صرفاً صفر می‌ماند و تنظیمات سلول خالی بر آن تأثیری ندارد.

از [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/set_displayblanksas/) برای انتخاب نحوه نمایش سلول‌های خالی توسط نمودار استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. نحوه ترسیم خالی‌ها را تغییر می‌دهد، بدون اینکه سلول خالی کتاب‌کار با صفر یا مقدار برآوردی پر شود.

مثال خودکفا زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز 3 را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌نماید. هیچ فایل ورودی لازم نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را نگه می‌دارد. داده نهایی `10, 20, empty, 30, 40` است.

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

// Leave Day 3 genuinely empty, while retaining its category and data point.
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

هر فایل خروجی حالت اختصاص داده‌شده پیش از ذخیره‌سازی را ذخیره می‌کند: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیره تنها یک نسخه، حالت موردنظر را اختصاص داده و یکبار ارائه را ذخیره کنید به‌جای مرور حالت‌ها.

مقایسه زیر همان داده را در هر سه فایل نشان می‌دهد. روز 3 در هر حالت در کتاب‌کار خالی است:

![نمودارهای خطی با داده‌های یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌برد و Span روز 2 را به روز 4 وصل می‌کند.](display_blanks_as.png)

اثر قابل مشاهده بستگی به نوع نمودار دارد. یک نمودار خطی مقایسه سه حالت را آسان می‌کند. نمودارهای نوار و ستونی خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش اتصال نشان داده‌شده را تولید کند؛ یک ستون گمشده و ستون با ارتفاع صفر نیز می‌تواند مشابه به نظر برسد. به همین ترتیب، یک نمودار پراکندگی فقط با نشانگرها خط اتصال ندارد. انتظار نتایج متفاوت برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوع مورد استفاده خود بررسی کنید.

## **تنظیم عرض فاصله مجموعه**

عرض فاصله فضای بین خوشه‌های نوار یا ستون مجاور است که به عنوان درصدی از عرض نوار یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم به گروه مجموعه والد تعلق دارد نه به یک مجموعه. برای گروه یک بار [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) را فراخوانی کنید. مقدار بزرگتر فضای بین خوشه‌ها را بیشتر می‌کند؛ مقدار کوچکتر آن‌ها را فشرده‌تر می‌سازد.

مثال زیر عرض فاصله را تغییر می‌دهد و فقط ارائه نهایی را ذخیره می‌کند:

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

## **پرسش‌های متداول**

**کدام انواع نمودار از مجموعه داده‌ها پشتیبانی می‌کنند؟**

تمام انواع نمودارهای نمایان‌شده توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/charttype/) از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات مقادیر مجموعه‌های آنها همسان نیست. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y استفاده می‌کنند و نمودارهای حبابی اندازه حباب‌ها را اضافه می‌کند. از روش ایجاد نقطه داده‌ای که با نوع مجموعه مطابقت دارد استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستونی سازگار اعمال می‌شوند.

**یک گروه مجموعه نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات رسم سطح گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی می‌شود لزوماً تمام مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجاد شده شامل داده‌های پیش‌فرض است؟**

بله. به‌طور پیش‌فرض، [IShapeCollection::AddChart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addchart/) نمونه‌ای از مجموعه‌ها، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید آن سلول‌ها را ویرایش کنید یا هم مجموعه‌ها و هم دسته‌ها را قبل از افزودن یک مجموعه داده کاملاً سفارشی پاک کنید. یک overload می‌تواند همچنین نموداری بدون داده پیش‌فرض ایجاد کند.

**چگونه اشیاء نمودار به سلول‌های کتاب‌کار متصل هستند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌راستا نگه دارید تا هر نقطه زیر دسته موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `nullptr` تنظیم کنید تا موقعیت دسته‌ای نقطه به‌عنوان نقطه خالی حفظ شود. فقط زمانی که می‌خواهید تمام نقاط را از آن مجموعه حذف کنید، [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) را فراخوانی کنید. اگر دسته‌ها را نیز حذف کنید، هر مجموعه را به‌روزرسانی کنید تا مقادیر آنها با مجموعه دسته‌ها هم‌راستا بماند.

**چگونه نقاط خالی نمایش داده می‌شوند؟**

نتیجه بستگی به نوع نمودار و [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_displayblanksas/) دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌عنوان فاصله، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای داده‌های گمشده در ارائه شما مطابقت دارد. برای مثال کامل و مقایسه تصویری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**چگونه مقادیر منفی قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) را فراخوانی کنید و رنگ را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) تنظیم کنید. می‌توانید رفتار را برای یک نقطه با [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت‌تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**کدام قالب‌بندی برنده است وقتی هم یک مجموعه و هم یک نقطه قالب‌بندی شوند؟**

قالب‌بندی صریح نقطه داده برای آن نقطه اولویت دارد. سایر نقاط به قالب‌بندی صریح مجموعه یا، وقتی قالب‌بندی مجموعه تعریف نشده باشد، به استایل و تم خودکار نمودار وابسته می‌شوند. تنظیمات گروهی مانند همپوشانی و عرض فاصله فقط طرح‌بندی را کنترل می‌کنند و بازنویسی قالب‌بندی نقطه‌ای نیستند.

**آیا محدودیتی برای تعداد مجموعه‌هایی که یک نمودار می‌تواند داشته باشد وجود دارد؟**

Aspose.Slides محدودیت شمار سری ثابت جداگانه‌ای اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و قابلیت خواندن نمودار محدودیت‌های عملی را تعیین می‌کنند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد به‌هم نزدیک یا دور هستند؟**

[IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) را روی گروه مجموعه والد مناسب فراخوانی کنید. مقدار را برای گسترده‌کردن فاصله بین خوشه‌ها افزایش دهید یا برای نزدیک‌تر کردن آن‌ها کاهش دهید.