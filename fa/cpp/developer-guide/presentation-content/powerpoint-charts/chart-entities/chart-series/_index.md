---
title: مدیریت داده‌های مجموعه‌های نمودار در ارائه‌ها با C++
linktitle: مجموعه‌های داده
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
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه مجموعه‌های نمودار، نقطه‌های داده، سلول‌های کتاب کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با C++ مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های رسم شده خود را در یک کتاب کار داده‌های نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/) یک مجموعه از مقادیر مرتبط را نمایندگی می‌کند و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/) در این مجموعه به یک یا چند سلول کتاب کار ارجاع می‌دهد. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌آورند. نام مجموعه، دسته‌ها و مقادیر نقاط به‌همین دلیل به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/) متصل هستند نه اینکه فقط به‌عنوان متن نمایش ذخیره شوند.

برای یک نمودار دسته‌ای معمول، کتاب کار پیش‌فرض ردیف 0 را برای نام‌های مجموعه، ستون 0 را برای نام‌های دسته و سلول‌های باقی‌مانده را برای مقادیر مجموعه‌ها استفاده می‌کند. اندیس‌های ورق کار، ردیف و ستون که به [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) پاس می‌شوند پایهٔ صفر دارند. این چیدمان هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائهٔ بارگذاری شده، قبل از تغییر مقادیر کتاب کار، سلول‌های ارجاع‌داده‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزهٔ متفاوت هستند:

- تنظیمات سطح مجموعه، مانند [IChartSeries::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_format/)، ظاهر پیش‌فرض همهٔ نقاط در یک مجموعه را فراهم می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_format/)، ظاهر مجموعه را برای یک نقطه خاص لغو می‌کند.
- تنظیمات گروه برای مجموعه‌های سازگاری که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/) تعلق دارند اعمال می‌شود. هنگامی که نیاز به تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله دارید، از طریق [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) به گروه دسترسی پیدا کنید.

زمانی که پر کردن صریح برای نقطه یا مجموعه‌ای تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم تنظیمات نقطه وجود داشته باشد، تنظیمات نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی مجموعه نمودار**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_overlap/) میزان همپوشانی نوارها یا ستون‌ها را در یک نمودار دو‑بعدی از ‎‑100 تا 100 درصد گزارش می‌دهد. این مقدار یک تصویر فقط‑خواندنی از تنظیمات در گروه مجموعهٔ والد است. برای به‌روزرسانی همهٔ مجموعه‌های سازگار در آن گروه، از [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) استفاده کنید. این گزینه برای انواع نمودارهایی که نوارها یا ستون‌های گروهی را نمایش می‌دهند کاربرد دارد؛ برای گروه‌های مجموعهٔ نامربوط در یک نمودار ترکیبی تأثیری ندارند.

مثال زیر همپوشانی گروهی را که شامل اولین مجموعه است تنظیم می‌کند:

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

## **تغییر رنگ پر شدن مجموعه**

از [IChartSeries::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_format/) برای تنظیم پر شدن پیش‌فرض یک مجموعه کامل استفاده کنید. اگر یک نقطه قبلاً پر شدن صریح داشته باشد، تنظیمات [IChartDataPoint::get_Format](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_format/) آن، پر شدن مجموعه را برای آن نقطه لغو می‌کند.

مثال زیر پر شدن آبی ثابت را برای اولین مجموعه اعمال می‌کند:

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

نام یک مجموعه در کتاب کار داده‌های نمودار ذخیره می‌شود و به‌طور معمول در افسانه نمایش داده می‌شود. در کتاب کار پیش‌فرض ایجادشده برای یک نمودار ستون خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را شامل می‌شود. ثابت‌های نام‌گذاری شده در مثال زیر این ساختار را صریح می‌کنند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries::get_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_name/) ارجاع داده شده است به‌روزرسانی کنید. این روش از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

## **دریافت رنگ پر خودکار مجموعه**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگی را برمی‌گرداند که بر پایهٔ اندیس مجموعه و سبک نمودار محاسبه می‌شود. این همان رنگی است که وقتی پر شدن مجموعه به‌طور صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ پر شدن جدیدی اختصاص نمی‌دهد.

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

خروجی مثال برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق بستگی به سبک و تم نمودار دارند.

## **تنظیم رنگ پر معکوس برای مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) می‌تواند مقادیر منفی را با پر شدن متفاوت نمایش دهد. پر شدن معمولی مجموعه را به حالت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) اختصاص دهید. اعداد منفی در کتاب کار تغییر نمی‌کنند؛ فقط رنگ نمایش آن‌ها تغییر می‌یابد.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 ورق کار شامل نام مجموعه، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

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

![رنگ پر معکوس جامد](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطه از طریق [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) فعال کنید. در مثال زیر، معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخابی فعال می‌شود. همچنین به نقطه مقدار منفی اختصاص داده می‌شود تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول پشتیبان کتاب کار آن را به `nullptr` تنظیم کنید. برای یک نمودار ستون، مقدار رسم‌شده از طریق [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات مقادیر خالی نمودار به‌عنوان خالی در نظر می‌گیرد.

مثال زیر فقط نقطه دوم در اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حباب نیز از یک سلول اندازه بهره می‌برند. فقط سلولی که نمایانگر مقداری است که می‌خواهید حذف کنید را پاک کنید. هنگام تمایل به نگه داشتن سایر نقاط، از فراخوانی [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) خودداری کنید، زیرا این متد تمام نقاط داده را از مجموعه حذف می‌نماید.

## **تنظیم عرض فاصله مجموعه**

عرض فاصله، فضای بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه همپوشانی، این مقدار به گروه مجموعهٔ والد تعلق دارد نه به یک مجموعهٔ خاص. برای گروه یک بار از [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را فشرده‌تر می‌کند.

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

## **FAQ**

**کدام انواع نمودار از مجموعه داده پشتیبانی می‌کنند؟**

تمام انواع نموداری که توسط شمارش [ChartType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/charttype/) نمایان می‌شوند، از داده‌های نمودار استفاده می‌کنند، اما ساختار مقادیر یا تنظیمات مجموعه‌های آن‌ها یکسان نیست. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حباب از اندازه حباب نیز بهره می‌برند. روش ایجاد نقطه داده‌ای را به کار ببرید که با نوع مجموعه مطابقت داشته باشد. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**گروه مجموعهٔ نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات رسم در سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دسترسی پیدا می‌کنید، لزوماً تمام مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا نمودار تازه‌ساخته‌شده دارای داده‌های پیش‌فرض است؟**

بله. به‌صورت پیش‌فرض، [IShapeCollection::AddChart](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishapecollection/addchart/) مجموعه‌های نمونه، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید آن سلول‌ها را ویرایش کنید یا قبل از افزودن مجموعه دادهٔ کاملاً سفارشی، هم مجموعه‌ها و هم دسته‌ها را پاک کنید. یک overload نیز می‌تواند نموداری بدون داده‌های پیش‌فرض ایجاد کند.

**کائنات نمودار چگونه به سلول‌های کتاب کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌شوند. تغییر یک سلول ارجاع‌داده‌شده، عنصر مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را طوری هماهنگ نگه دارید که هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مربوطه را به `nullptr` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان یک نقطه خالی حفظ شود. فقط زمانی که قصد حذف تمام نقاط یک مجموعه را دارید، از [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) استفاده کنید. اگر هم دسته‌ها را حذف می‌کنید، هر مجموعه را به‌روزرسانی کنید تا مقادیر آن‌ها با مجموعهٔ دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_displayblanksas/) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت شکاف، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که با معنای داده‌های گمشده در ارائهٔ شما همخوانی داشته باشد.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، از [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) استفاده کنید و رنگ را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ جداگانه با [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) لغو کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند و مقادیر عددی ذخیره‌شده را تغییر نمی‌دهند.

**وقتی هم مجموعه و هم نقطه قالب‌بندی شوند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطه داده برای همان نقطه برتری دارد. نقاط دیگر همچنان از قالب صریح مجموعه استفاده می‌کنند یا، اگر قالب مجموعه تعریف نشده باشد، از سبک و تم خودکار نمودار بهره می‌برند. تنظیمات گروهی مانند همپوشانی و عرض فاصله کنترل چیدمان را بر عهده دارند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و قابلیت خواندن نمودار تعیین‌کنندهٔ حد قابل استفاده هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور از هم هستند؟**

بر روی گروه مجموعهٔ والد مربوطه [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) را فراخوانی کنید. برای افزایش فضای بین خوشه‌ها مقدار را بزرگتر کنید یا برای نزدیک‌تر کردن خوشه‌ها مقدار را کوچکتر کنید.