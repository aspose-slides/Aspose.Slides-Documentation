---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با C++
linktitle: سری داده
type: docs
url: /fa/cpp/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- رنگ دسته
- نام سری
- نقطه داده
- فاصله سری
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "چگونگی مدیریت سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله، و مقادیر منفی در ارائه‌ها با C++ را بیاموزید."
---
## **مرور کلی**

یک نمودار می‌تواند مقادیر ترسیم‌شده خود را در سلول‌های کتاب‌کار یا به‌صورت مستقیم به‌عنوان مقادیر عددی ثابت ذخیره کند. یک [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/) یک نقطه در آن مجموعه را نشان می‌دهد. اشیاء [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. در نمودارهایی که با داده‌های پیش‌فرض ایجاد می‌شوند، نام‌های مجموعه، دسته‌ها و مقادیر نقاط از اشیاء [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/) کتاب‌کار نمودار استفاده می‌کنند.

در یک نمودار دسته‌ای معمولی، کتاب‌کار پیش‌فرض ردیف 0 را برای نام‌های مجموعه، ستون 0 را برای نام‌های دسته و بقیهٔ سلول‌ها را برای مقادیر مجموعه استفاده می‌کند. شاخص‌های Worksheet، ردیف و ستون که به [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) ارسال می‌شوند، صفر‑پایه هستند. این طرح‌بندی هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائهٔ بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌هایی که توسط مجموعه‌ها، دسته‌ها و نقاط داده ارجاع داده شده‌اند را بررسی کنید.

تنظیمات نمودار سه حوزه متفاوت دارند:

- تنظیمات سطح مجموعه، مانند [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/)، ظاهر پیش‌فرض تمام نقاط در یک مجموعه را فراهم می‌کنند.
- تنظیمات نقطه‌داده، مانند [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کنند.
- تنظیمات گروهی بر مجموعه‌های سازگار که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) تعلق دارند، اعمال می‌شوند. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، از طریق [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) به گروه دسترسی پیدا کنید.

زمانی که پرکردن صریح برای نقطه یا مجموعه تنظیم نشده باشد، سبک و قالب‌بندی نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم‌زمان قالب‌بندی مجموعه و نقطه وجود داشته باشد، قالب‌بندی نقطه برای آن نقطه اولویت دارد.

![chart-series-powerpoint](chart-series-powerpoint.png)

برای یک نمودار استوانه‌ای خوشه‌ای، به این نگاه کنید که چگونه [changing the 3D series type or bar shape](/slides/fa/cpp/3d-chart/#change-the-3d-series-type-and-bar-shape) بر اولین مجموعه تأثیر می‌گذارد.

## **تنظیم مقادیر مجموعه با استفاده از مقادیر عددی ثابت**

از مقادیر عددی ثابت زمانی استفاده کنید که مقادیر مجموعه از داده‌های برنامه یا محاسبات می‌آیند و نیازی به ارجاع به سلول‌های کاربرگ ندارند. قبل از اختصاص مقدار برگردانده‌شده توسط هر نقطهٔ [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_value/)‌، متد [set_DataSourceTypeForValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforvalues/) را با [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) فراخوانی کنید و سپس از [set_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/set_asliteraldouble/) استفاده کنید.

تنظیم مجموعه منبع نوع تمام مقادیر نقاط در آن مجموعه را کنترل می‌کند. [IBaseChartValue::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ibasechartvalue/get_datasourcetype/) نوع انتخاب شده را گزارش می‌دهد؛ آن را از طریق تنظیم مجموعه تغییر دهید. با `Worksheet` از [get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/isinglecellchartvalue/get_ascell/) برای دسترسی به سلول ارجاع‌شده استفاده کنید. با `DoubleLiterals` از [get_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/get_asliteraldouble/) یا `set_AsLiteralDouble` برای خواندن یا نوشتن مستقیم عدد استفاده کنید.

مثال زیر یک نمودار میله‌ای با مجموعه‌ها و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شده 10، 20 و غیره را به نقاط موجود اولین مجموعه اختصاص می‌دهد. ارائه ذخیره می‌شود، دوباره باز می‌شود و مقادیر ذخیره‌شده چاپ می‌شوند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

series->get_DataPoints()->set_DataSourceTypeForValues(DataSourceType::DoubleLiterals);
for (auto i = 0; i < series->get_DataPoints()->get_Count(); i++)
{
    series->get_DataPoints()->idx_get(i)->get_Value()->set_AsLiteralDouble((i + 1) * 10);
}

presentation->Save(u"numeric_literals.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"numeric_literals.pptx");
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedChart = ExplicitCast<IChart>(reopenedSlide->get_Shape(0));
auto reopenedSeries = reopenedChart->get_ChartData()->get_Series()->idx_get(0);
for (auto i = 0; i < reopenedSeries->get_DataPoints()->get_Count(); i++)
{
    auto point = reopenedSeries->get_DataPoints()->idx_get(i);
    Console::WriteLine(point->get_Value()->get_AsLiteralDouble());
}
reopenedPresentation->Dispose();
```

نوع منبع مقدار نقطه جدا از [IChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_datasourcetype/) است که پیکربندی کتاب‌کار داخلی یا خارجی نمودار را شناسایی می‌کند. استفاده از مقادیر عددی ثابت به‌تنهایی کتاب‌کار جاسازی‌شده را حذف نمی‌کند. در این مثال، کتاب‌کار برای برچسب‌های دسته، نام‌های مجموعه و سایر مجموعه‌ها در دسترس می‌ماند. برای مدیریت کتاب‌کار، به [Chart Workbook](/slides/fa/cpp/chart-workbook/) مراجعه کنید.

برای نمودارهای پراکنده و حبابی، برای انتخاب منبع‌های [get_XValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_xvalue/) و [get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) به ترتیب متدهای [set_DataSourceTypeForXValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforxvalues/) و [set_DataSourceTypeForYValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforyvalues/) را فراخوانی کنید. برای نمودارهای حبابی نیز از [set_DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforbubblesizes/) برای [get_BubbleSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_bubblesize/) استفاده می‌شود. قبل از اختصاص اعداد از متد `set_AsLiteralDouble`، هر منبع قابل اعمال را به `DoubleLiterals` تنظیم کنید.

## **تنظیم همپوشانی مجموعه نمودار**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار ۲‑بعدی از چه مقدار (از ‑۱۰۰ تا ۱۰۰ درصد) همپوشانی دارند. این مقدار نمایانگر فقط تنظیمات گروه والد است. برای به‌روزرسانی همه مجموعه‌های سازگار در آن گروه، متد [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) را فراخوانی کنید. این گزینه برای انواع نمودارهایی که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود و روی گروه‌های مجموعهٔ نامرتبط در نمودار ترکیبی تأثیری ندارد.

مثال زیر همپوشانی برای گروهی که شامل اولین مجموعه است تنظیم می‌کند:

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

![The series overlap](series_overlap.png)

## **تغییر رنگ پرکردن مجموعه**

از [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) برای تنظیم پرکردن پیش‌فرض برای یک مجموعه کامل استفاده کنید. اگر یک نقطه قبلاً پرکردن صریح داشته باشد، تنظیم [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) آن، پرکردن مجموعه را برای آن نقطه لغو می‌کند.

مثال زیر پرکردن آبی ثابت را به اولین مجموعه اعمال می‌کند:

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

![The color of the series](series_color.png)

## **تغییر نام مجموعه**

نام مجموعه در کتاب‌کار دادهٔ نمودار ذخیره می‌شود و معمولاً در legend نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد شده برای یک نمودار میله‌ای خوشه‌ای، سلول B1 در ردیف 0، ستون 1 قرار دارد و نام اولین مجموعه را دارد. ثابت‌های نامی در مثال زیر این ساختار را واضح می‌کند:

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

همچنین می‌توانید سلول ارجاع‌شده توسط [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/) را به‌روزرسانی کنید. این رویکرد از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

![The series name](series_name.png)

### **ایجاد مجموعه‌ای با نام از چند سلول**

نام ترکیبی مجموعه زمانی مفید است که نام محصول و دورهٔ گزارش در سلول‌های جداگانهٔ کتاب‌کار ذخیره شده باشند. برای مثال می‌توانید `Product A` در B1 و `2026` در C1 را به‌صورت یک نام مجموعه ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود لینک باقی می‌مانند.

از [IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/) برای دریافت محدودهٔ نام استفاده کنید، سپس آن مجموعه را به [IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/) پاس دهید. آرگومان `skipHiddenCells` تعیین می‌کند که آیا سلول‌های مخفی گنجانده شوند یا نه: `true` آنها را حذف می‌کند، در حالی که `false` شامل می‌شود. این مثال از `false` برای دربرگیری همهٔ سلول‌های محدودهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام مجموعه را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته و B2:B3 مقادیر عددی را فراهم می‌کنند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCellCollection.h>
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

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 620.0f, 180.0f);
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
chart->set_HasLegend(true);

auto workbook = chartData->get_ChartDataWorkbook();
workbook->Clear(0);

// این دو سلول نام مجموعه را فراهم می‌کند.
auto productName = ObjectExt::Box<String>(u"Product A");
auto reportingPeriod = ObjectExt::Box<String>(u"2026");
workbook->GetCell(0, 0, 1, productName);
workbook->GetCell(0, 0, 2, reportingPeriod);
auto nameCells = workbook->GetCellCollection(u"Sheet1!$B$1:$C$1", false);
auto series = chartData->get_Series()->Add(nameCells, ChartType::ClusteredColumn);

// سلول‌های جداگانه دسته‌ها و نقاط داده عددی را فراهم می‌کنند.
auto northLabel = ObjectExt::Box<String>(u"North");
auto southLabel = ObjectExt::Box<String>(u"South");
auto northCategory = workbook->GetCell(0, 1, 0, northLabel);
auto southCategory = workbook->GetCell(0, 2, 0, southLabel);
chartData->get_Categories()->Add(northCategory);
chartData->get_Categories()->Add(southCategory);
auto northAmount = ObjectExt::Box<int>(120);
auto southAmount = ObjectExt::Box<int>(150);
auto northValue = workbook->GetCell(0, 1, 1, northAmount);
auto southValue = workbook->GetCell(0, 2, 1, southAmount);
series->get_DataPoints()->AddDataPointForBarSeries(northValue);
series->get_DataPoints()->AddDataPointForBarSeries(southValue);

presentation->Save(u"composite_series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نام مجموعهٔ حاصل `Product A 2026` است، با یک فاصله بین دو مقدار سلولی. legend این را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **دریافت رنگ پرکردن خودکار مجموعه**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگ محاسبه‌شده بر پایهٔ شاخص مجموعه و سبک نمودار را برمی‌گرداند. این همان رنگی است که وقتی پرکردن مجموعه صریحاً تعریف نشده باشد استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ رنگ جدیدی را تنظیم نمی‌کند.

مثال زیر رنگ خودکار هر مجموعهٔ پیش‌فرض را چاپ می‌کند:

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

رنگ‌های دقیق بسته به سبک و قالب‌بندی نمودار متفاوت هستند.

## **تنظیم رنگ پرکردن معکوس برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، می‌توانید با استفاده از [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) مقادیر منفی را با پرکردن متفاوتی نمایش دهید. پرکردن معمولی مجموعه را به‌صورت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) تعیین کنید. اعداد منفی در کتاب‌کار بدون تغییر باقی می‌مانند؛ فقط رنگ نمایش آنها تغییر می‌کند.

مثال زیر دادهٔ پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 کاربرگ نام مجموعه را دارد، ستون 0 نام دسته‌ها را دارد و ستون 1 مقادیر را دارد:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

می‌توانید معکوس‌سازی را برای یک نقطهٔ خاص از طریق [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخاب‌شده فعال است. این نقطه همچنین مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

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

## **پاک کردن مقدار نقطه دادهٔ خاص**

برای خالی‌کردن یک نقطه بدون حذف سایر نقاط، سلول کتاب‌کار پشتیبان آن را به `nullptr` تنظیم کنید. برای یک نمودار میله‌ای، مقدار ترسیم‌شده از طریق [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات خالی بودن نمودار به‌عنوان خالی درنظر می‌گیرد.

مثال زیر تنها نقطهٔ دوم اولین مجموعه را پاک می‌کند:

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

نمودارهای پراکنده از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حبابی همچنین از سلول اندازه استفاده می‌کنند. فقط سلولی که مقدار موردنظر را نشان می‌دهد پاک کنید. وقتی می‌خواهید سایر نقاط را حفظ کنید، از [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) استفاده نکنید، زیرا این متد تمام نقاط دادهٔ مجموعه را حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که شامل مقدار هستند، مورد متفاوتی نسبت به سلول‌های خالی هستند. برای شامل یا حذف داده‌ها از ردیف‌ها و ستون‌های مخفی کاربرگ، به [Include Data from Hidden Rows and Columns](/slides/fa/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns) مراجعه کنید.

یک سلول خالی در کتاب‌کار نشان‌دهندهٔ دادهٔ گمشده است؛ سلولی که مقدار `0` دارد نشان‌دهندهٔ مقدار عددی شناخته‌شده است. برای خالی‌کردن یک سلول، متد [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/) را با `nullptr` فراخوانی کنید. یک صفر عددی صرفاً صفر باقی می‌ماند، صرف‌نظر از تنظیم خالی بودن سلول.

از [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/) برای انتخاب نحوهٔ نمایش سلول‌های خالی استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود و نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد بدون اینکه سلول کتاب‌کار را با صفر یا مقدار درونی‌سازی‌شده پر کند.

مثال کامل زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز ۳ را پاک می‌کند و هر حالت را ذخیره می‌نماید. فایل ورودی لازم نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) از کاربرگ 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

// روز ۳ را به‌طور واقعی خالی بگذارید، در حالی که دسته و نقطه داده آن را نگه می‌دارید.
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

هر فایل خروجی حالت اختصاص‌یافته قبل از ذخیره را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ فقط یک نسخه، حالت دلخواه را تنظیم کنید و یک بار ارائه را ذخیره کنید.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز ۳ در کتاب‌کار در هر حالت خالی است:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

اثر قابل مشاهده بستگی به نوع نمودار دارد. یک نمودار خطی تمام three modes را به‌راحتی مقایسه می‌کند. نمودارهای میله‌ای و ستونی خطی برای اتصال بین دسته‌های گمشده ندارند، بنابراین `Span` نمی‌تواند بخش اتصال نشان داده‌شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکنده فقط با نشانگرها هیچ خطی برای اتصال ندارد. انتظار نتایج سه گانهٔ متمایز برای هر نوع نمودار را نداشته باشید؛ خروجی مورد استفادهٔ خود را بررسی کنید.

## **تنظیم عرض فاصلهٔ مجموعه**

عرض فاصله، فضایی بین خوشه‌های میله یا ستون مجاور است که به‌صورت درصدی از عرض میله یا ستون بیان می‌شود. مشابه همپوشانی، این تنظیم به گروه والد مجموعه تعلق دارد نه به یک مجموعهٔ خاص. برای گروه یک بار متد [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) را فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آنها را فشرده‌تر می‌کند.

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

![The gap width](gap_width.png)

## **نمایش یا مخفی‌ کردن خطوط مجموعه**

خطوط مجموعه به‌صورت بصری قسمت‌های مرتبط یک نمودار را به‌هم وصل می‌کنند. برای نمایش یا مخفی‌کردن آنها در نمودارهای ستونی/میله‌ای پشته‌ای پشتیبانی‌شده، از [IChartSeriesGroup::set_HasSeriesLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_hasserieslines/) استفاده کنید. در نمودارهای ستونی/میله‌ای پشته‌ای دو‌بعدی، این خطوط مرزهای پشتهٔ مربوطه را بین دسته‌ها به‌هم وصل می‌کنند. در نمودارهای Pie of Pie و Bar of Pie، این خطوط نمودار اصلی را به نمودار ثانویه متصل می‌کنند. این تنظیم یک connector عمومی برای سایر انواع نمودارها نیست.

دسترسی به گروه از طریق [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) انجام می‌شود. این تنظیم برای هر مجموعهٔ آن گروه اعمال می‌شود. [IChartSeries::get_HasSeriesLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_hasserieslines/) فقط مقدار را می‌خواند و تنظیمات گروه والد را بازتاب می‌دهد؛ برای به‌روزرسانی باید متد setter گروه را فراخوانی کنید.

مثال زیر یک نمودار [ChartType::PieOfPie](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) با داده‌های پیش‌فرض ایجاد می‌کند. همان نمودار را ابتدا با خطوط مجموعه فعال و سپس غیرفعال ذخیره می‌کند تا دو ارائه برای مقایسه ایجاد شود.

```cpp
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

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto seriesGroup = series->get_ParentSeriesGroup();

seriesGroup->set_HasSeriesLines(true);
presentation->Save(u"series_lines_enabled.pptx", SaveFormat::Pptx);

seriesGroup->set_HasSeriesLines(false);
presentation->Save(u"series_lines_disabled.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| خطوط مجموعه فعال | خطوط مجموعه غیرفعال |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| دو خط اصلی را به پيت ثانویه متصل می‌کنند. | هر دو پای چارت قابل مشاهده‌اند اما خطوط اتصال مخفی‌اند. |

خطوط مجموعه با خطوط راهنمای برچسب داده، خطوط شبکه، و خطوط در نمودار خط متفاوت هستند؛ این تنظیم این عناصر را کنترل نمی‌کند.

## **سوالات متداول**

**کدام انواع نمودار از مجموعه‌های داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهایی که توسط شمارش‌گر [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) تعریف شده‌اند از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات ارزش آن‌ها یکسان نیست. به عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حبابی اندازهٔ حباب را نیز اضافه می‌کنند. از روش ایجاد نقطه‌داده‌ای که با نوع مجموعه سازگار است استفاده کنید. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های میله یا ستون سازگار اعمال می‌شوند.

**یک گروه مجموعهٔ نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات رسم سطح گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروه از طریق یک مجموعه لزوماً همهٔ مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجاد‌شده شامل داده‌های پیش‌فرض است؟**

بله. به‌طور پیش‌فرض، متد [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) مجموعه‌های نمونه، دسته‌ها و مقادیر ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعه و دسته‌ها را پاک کنید. یک overload نیز می‌تواند نموداری بدون دادهٔ پیش‌فرض ایجاد کند.

**شیء‌های نمودار چگونه به سلول‌های کتاب‌کار متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه‌داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده المان مربوط به نمودار را به‌روز می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ موردنظر رسم شود.

**چگونه یک نقطه را پاک کنم بدون حذف کل مجموعه؟**

سلول مقدار مربوطه را به `nullptr` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطهٔ خالی حفظ شود. متد [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) را فقط زمانی فراخوانی کنید که می‌خواهید همهٔ نقاط مجموعه حذف شوند، زیرا این متد تمام نقاط دادهٔ مجموعه را پاک می‌کند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بستگی به نوع نمودار و [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌عنوان فاصله، به‌عنوان مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی که با معنای دادهٔ گمشده در ارائهٔ شما منطبق باشد انتخاب کنید. برای مثال کامل و مقایسهٔ بصری، به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های مینی، ستون و حباب پشتیبانی‌شده، از [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) استفاده کنید و رنگ را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**وقتی هم مجموعه و هم نقطه قالب‌بندی شوند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطه‌داده برای آن نقطه برتری دارد. سایر نقاط همچنان از قالب‌­بندی صریح مجموعه یا، وقتی قالب‌­بندی مجموعه تعریف نشده باشد، از سبک و قالب‌بندی خودکار نمودار استفاده می‌کنند. تنظیمات گروهی مانند همپوشانی و عرض فاصله فقط طرح‌بندی را کنترل می‌کنند و بازنویسی قالب‌بندی در سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌هایی که یک نمودار می‌تواند داشته باشد وجود دارد؟**

Aspose.Slides محدودیتی ثابت برای تعداد مجموعه‌ها تعیین نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندر و قابلیت خواندن نمودار تعیین‌کنندهٔ حد مفید هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور از یکدیگر هستند؟**

متد [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) را در گروه والد مناسب فراخوانی کنید. برای افزایش فاصله بین خوشه‌ها مقدار را بزرگتر کنید؛ برای کاهش فاصله مقدار را کوچکتر کنید.