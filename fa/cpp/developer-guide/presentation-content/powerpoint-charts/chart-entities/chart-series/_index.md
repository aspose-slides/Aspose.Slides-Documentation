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
description: "یاد بگیرید چگونه مجموعه‌های نمودار، نقاط داده، سلول‌های workbook، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را در ارائه‌ها با C++ مدیریت کنید."
---
## **نمای کلی**

یک نمودار می‌تواند مقادیر ترسیمی خود را در سلول‌های workbook یا به‌صورت مستقیم به‌عنوان مقادیر عددی ثابت ذخیره کند. یک [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/) نشان‌دهنده یک مجموعه از مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/) نمایانگر یک نقطه در آن مجموعه است. اشیاء [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی مشترک بین مجموعه‌ها را فراهم می‌کنند. در نمودارهایی که با داده‌های پیش‌فرض ساخته می‌شوند، نام‌های مجموعه‌ها، دسته‌ها و مقادیر نقاط از اشیاء [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/) در workbook نمودار استفاده می‌شود.

برای یک نمودار دسته‌ای معمول، workbook پیش‌فرض ردیف 0 را برای نام‌های مجموعه، ستون 0 را برای نام‌های دسته و سلول‌های باقی‌مانده را برای مقادیر مجموعه استفاده می‌کند. شاخص‌های Worksheet، ردیف و ستون که به [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) پاس داده می‌شوند، صفر‑مبنا هستند. این چیدمان هنگام ایجاد یک نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که همهٔ نمودارهای موجود از آن استفاده می‌کنند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر workbook سلول‌های ارجاع‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار دارای سه حوزهٔ متفاوت هستند:

- تنظیمات سطح‑مجموعه، مانند [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/)، ظاهر پیش‌فرض تمام نقاط یک مجموعه را تعیین می‌کند.
- تنظیمات نقطه‑داده، مانند [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی بر روی مجموعه‌های سازگار که به همان [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند overlap یا gap width گروه را از طریق [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) دریافت کنید.

زمانی که پر کردن صریح برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم تنظیمات مجموعه و هم نقطه وجود داشته باشد، تنظیمات نقطه برتری دارد.

![نمودار-سری-پاورپوینت](chart-series-powerpoint.png)

## **تنظیم مقادیر مجموعه با استفاده از مقادیر عددی ثابت**

از مقادیر عددی ثابت استفاده کنید هنگامی که مقادیر مجموعه از داده‌های برنامه یا محاسبات می‌آیند و نیازی به ارجاع به سلول‌های Worksheet ندارند. قبل از اختصاص مقداری که توسط [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_value/) هر نقطه بازگردانده می‌شود، [set_DataSourceTypeForValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforvalues/) را با [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) فراخوانی کنید و سپس از [set_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/set_asliteraldouble/) استفاده کنید.

این تنظیم مجموعه منبع نوع تمام مقادیر نقطه‌ها در آن مجموعه را کنترل می‌کند. [IBaseChartValue::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ibasechartvalue/get_datasourcetype/) نوع انتخابی را گزارش می‌دهد؛ آن را از طریق تنظیم مجموعه تغییر دهید. با `Worksheet` از [get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/isinglecellchartvalue/get_ascell/) برای دسترسی به سلول ارجاع‌شده استفاده کنید. با `DoubleLiterals` از [get_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/get_asliteraldouble/) یا `set_AsLiteralDouble` برای خواندن یا نوشتن مستقیم عدد استفاده کنید.

مثال زیر یک نمودار ستونی با مجموعه و دسته‌های پیش‌فرض ایجاد می‌کند، سپس مقادیر محاسبه‌شدهٔ 10، 20 و غیره را به نقاط موجود مجموعهٔ اول اختصاص می‌دهد. ارائه را ذخیره، دوباره باز می‌کند و مقادیر ذخیره‌شده را چاپ می‌کند.

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

نوع منبع مقدار نقطه جدا از [IChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_datasourcetype/) است که پیکربندی workbook داخلی یا خارجی نمودار را شناسایی می‌کند. استفاده از مقادیر عددی ثابت به‌تنهایی workbook توکار را حذف نمی‌کند. در این مثال، workbook برای برچسب‌های دسته، نام‌های مجموعه و سایر مجموعه‌ها در دسترس می‌ماند. برای مدیریت workbook به بخش [Chart Workbook](/slides/fa/cpp/chart-workbook/) مراجعه کنید.

برای نمودارهای پراکندگی و حبابی، برای انتخاب منبع‌های [get_XValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_xvalue/) و [get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) به ترتیب [set_DataSourceTypeForXValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforxvalues/) و [set_DataSourceTypeForYValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforyvalues/) را فراخوانی کنید. برای نمودارهای حبابی همچنین از [set_DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforbubblesizes/) برای [get_BubbleSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_bubblesize/) استفاده می‌شود. هر منبع قابل‌کاربرد را پیش از اختصاص اعداد به `DoubleLiterals` تنظیم کنید و سپس مقدار را از طریق `set_AsLiteralDouble` بنویسید.

## **تنظیم هم‌پوشانی مجموعه نمودار**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/) میزان هم‌پوشانی نوارها یا ستون‌ها را در یک نمودار دو‑بعدی از ‑100 تا 100 درصد گزارش می‌دهد. این مقدار یک تصویر تنها‑خواندنی از تنظیمات گروه سری والد است. برای به‌روزرسانی همهٔ مجموعه‌های سازگار در آن گروه، [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) را فراخوانی کنید. این گزینه برای انواع نمودارهایی که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ در نمودار ترکیبی بر روی گروه‌های سری نامرتبط تأثیری ندارد.

مثال زیر هم‌پوشانی گروهی که شامل مجموعهٔ اول است تنظیم می‌کند:

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

![هم‌پوشانی مجموعه‌ها](series_overlap.png)

## **تغییر رنگ پر کردن مجموعه**

از [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) برای تنظیم پر کردن پیش‌فرض یک مجموعه کامل استفاده کنید. اگر برای یک نقطه پر کردن صریح تنظیم شده باشد، تنظیمات [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) آن نقطه، پر کردن مجموعه را برای همان نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی ثابت را برای مجموعهٔ اول اعمال می‌کند:

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

نام یک مجموعه در workbook داده‌های نمودار ذخیره می‌شود و به‌صورت معمول در افسانه (legend) نمایش داده می‌شود. در workbook پیش‌فرض ایجاد شده برای یک نمودار ستونی خوشه‌ای، سلول B1 که ردیف 0 و ستون 1 است، نام اولین مجموعه را دارد. ثابت‌های نام‌گذاری در مثال زیر این ساختار را به‌صورت صریح نشان می‌دهند:

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

همچنین می‌توانید سلولی که توسط [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/) ارجاع شده است به‌روزرسانی کنید. این رویکرد از فرض ردیف و ستون خاصی در یک نمودار موجود جلوگیری می‌کند:

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

### **ایجاد مجموعه با نام از چند سلول**

نام ترکیبی مجموعه زمانی مفید است که نام محصول و بازهٔ گزارش‌گیری در سلول‌های جداگانه workbook ذخیره شده باشند. برای مثال می‌توانید `Product A` در B1 و `2026` در C1 را به یک نام مجموعه ترکیب کنید در حالی که هر دو بخش به سلول‌های منبع خود پیوند دارند.

از [IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/) برای دریافت بازهٔ نام استفاده کنید، سپس آن مجموعه را به [IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/) پاس دهید. آرگومان `skipHiddenCells` تعیین می‌کند آیا سلول‌های مخفی شامل شوند یا نه: `true` آن‌ها را حذف می‌کند، در حالی که `false` آن‌ها را شامل می‌شود. این مثال از `false` برای شامل‌کردن تمام سلول‌های بازهٔ نام استفاده می‌کند.

مثال زیر یک ارائه با یک مجموعه و دو نقطه داده ایجاد می‌کند. سلول‌های B1:C1 فقط نام مجموعه را فراهم می‌کنند؛ A2:A3 برچسب‌های دسته‌ها را تأمین می‌کنند و B2:B3 مقادیر عددی را.

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

// این دو سلول نام مجموعه را فراهم می‌کنند.
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

نام مجموعه حاصل `Product A 2026` است که بین دو مقدار سلولی یک فاصله دارد. افسانه این را به‌عنوان یک ورودی برای هر دو ستون نمایش می‌دهد. تصویر زیر نتیجه را نشان می‌دهد:

![نمودار ستونی با مقادیر شمال و جنوب و نام ترکیبی مجموعه Product A 2026 در افسانه](composite_series_name.png)

## **دریافت رنگ پر کردن خودکار مجموعه**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) رنگی را بر می‌گرداند که از ایندکس مجموعه و سبک نمودار محاسبه می‌شود. این همان رنگی است که وقتی پر کردن مجموعه به‌صورت صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد تنها رنگ محاسبه‌شده را می‌خواند؛ هیچ پر کردن جدیدی اختصاص نمی‌دهد.

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

خروجی نمونه برای سبک پیش‌فرض نمودار:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

رنگ‌های دقیق به سبک و تم نمودار وابسته هستند.

## **تنظیم رنگ پر کردن معکوس برای یک مجموعه نمودار**

برای مجموعه‌های نوار، ستون و حباب، می‌توان با استفاده از [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) مقادیر منفی را با یک پر کردن متفاوت نشان داد. پر کردن معمولی مجموعه را به‌صورت ثابت تنظیم کنید، معکوس‌سازی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) اختصاص دهید. اعداد منفی در workbook تغییری نمی‌کنند؛ تنها رنگ نمایش آن‌ها تغییر می‌یابد.

مثال زیر داده‌های پیش‌فرض نمودار را با یک مجموعه جایگزین می‌کند. ردیف 0 Worksheet شامل نام مجموعه، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

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

![رنگ پر کردن ثابت معکوس](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه معکوس‌سازی را از طریق [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) فعال کنید. در مثال زیر معکوس‌سازی برای مجموعه غیرفعال و فقط برای نقطهٔ انتخابی فعال می‌شود. همچنین برای مشاهده اثر، به نقطه مقدار منفی اختصاص داده شده است:

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

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول workbook پشتیبان آن را به `nullptr` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را بر اساس تنظیمات خالی‑مقدار نمودار به‌صورت خالی در نظر می‌گیرد.

مثال زیر تنها نقطهٔ دوم در مجموعهٔ اول را پاک می‌کند:

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

نمودارهای پراکندگی از سلول‌های جداگانه X و Y استفاده می‌کنند و نمودارهای حبابی همچنین از یک سلول اندازه استفاده می‌کنند. فقط سلولی را که نمایانگر مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگام نیاز به حفظ نقاط دیگر، از فراخوانی [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) خودداری کنید؛ این متد تمام نقاط داده را از مجموعه حذف می‌کند.

## **کنترل نمایش سلول‌های خالی**

سلول‌های مخفی که مقادیر دارند، موردی متفاوت نسبت به سلول‌های خالی هستند. برای شامل یا مستثنی کردن داده‌ها از ردیف‌ها و ستون‌های مخفی Worksheet، بخش [Include Data from Hidden Rows and Columns](/slides/fa/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns) را ببینید.

یک سلول workbook خالی نشان‌دهندهٔ دادهٔ گمشده است؛ سلولی که `0` دارد نشان‌دهندهٔ مقدار عددی شناخته‌شده است. برای خالی کردن یک سلول، [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/) را با `nullptr` فراخوانی کنید. عدد صفر عددی صفر می‌ماند صرف‌نظر از تنظیم خالی‑سلول.

از [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/) برای انتخاب نحوهٔ نمایش سلول‌های خالی استفاده کنید. این تنظیم برای کل نمودار اعمال می‌شود. نحوهٔ ترسیم خالی‌ها را تغییر می‌دهد بدون اینکه سلول خالی workbook با صفر یا مقدار درون‌خطی پر شود.

مثال زیر یک نمودار خطی با یک مجموعه ایجاد می‌کند، مقدار روز 3 را پاک می‌کند و همان نمودار را با هر حالت ذخیره می‌کند. نیازی به فایل ورودی نیست. [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) از worksheet 0، ستون 0 برای برچسب‌های دسته و ستون 1 برای مقادیر استفاده می‌کند؛ ردیف 0 نام مجموعه را دارد. دادهٔ نهایی `10, 20, empty, 30, 40` است.

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

هر فایل خروجی حالت اختصاص‌یافته قبل از ذخیره را نشان می‌دهد: `empty_cells_Gap.pptx`، `empty_cells_Zero.pptx` و `empty_cells_Span.pptx`. برای ذخیرهٔ تنها یک نسخه، حالت دلخواه را تنظیم کنید و یک‌بار ارائه را ذخیره کنید به جای تکرار بر روی حالت‌ها.

مقایسهٔ زیر همان داده را در هر سه فایل نشان می‌دهد. روز 3 در workbook در هر حالت خالی است:

![نمودارهای خطی با دادهٔ یکسان: Gap خط را در روز 3 قطع می‌کند، Zero خط را به صفر می‌کاهد، و Span روز 2 را به روز 4 وصل می‌کند.](display_blanks_as.png)

اثر قابل‌مشاهده به نوع نمودار بستگی دارد. یک نمودار خطی سه حالت را به راحتی مقایسه می‌کند. نمودارهای نوار و ستون خطی برای اتصال بین دستهٔ گمشده ندارند، بنابراین `Span` نمی‌تواند قطعهٔ متصل شده نشان داده شده در بالا را تولید کند؛ یک ستون گمشده و یک ستون با ارتفاع صفر نیز می‌توانند مشابه به‌نظر برسند. به‌طور مشابه، یک نمودار پراکندگی فقط با نشانگرها خط متصل‌کننده‌ای ندارد. انتظار نتایج سه‌گانهٔ متفاوت برای هر نوع نمودار را نداشته باشید؛ خروجی را برای نوع مورد استفاده‌تان بررسی کنید.

## **تنظیم عرض فاصله مجموعه**

عرض فاصله (gap width) فاصلهٔ بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. مشابه overlap، این تنظیم به گروه مجموعه والد تعلق دارد نه به یک مجموعهٔ تک. برای گروه یک‌بار [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) را فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچکتر آن‌ها را متراکم‌تر می‌کند.

مثال زیر عرض فاصله را تغییر می‌دهد و تنها ارائهٔ نهایی را ذخیره می‌کند:

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

**کدام انواع نمودار از مجموعه داده پشتیبانی می‌کنند؟**

تمام انواع نمودارهایی که توسط شمارش [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) تعریف شده‌اند از داده‌های نمودار استفاده می‌کنند، اما مجموعه‌های آن‌ها ساختار یا تنظیمات ارزش یکسانی ندارند. برای مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکندگی از مقادیر X و Y، و نمودارهای حبابی از اندازهٔ حباب‌ها استفاده می‌کنند. روش ایجاد نقطه‑داده‌ای را که با نوع مجموعه منطبق است انتخاب کنید. گزینه‌هایی مانند overlap و gap width فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**یک گروه مجموعه نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) شامل مجموعه‌های سازگاری است که تنظیمات نموداری سطح‑گروه را به‌اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک مجموعه دریافت می‌شود لزوماً تمام مجموعه‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه‌ساخته داده‌های پیش‌فرض دارد؟**

بله. به‌صورت پیش‌فرض، [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) مجموعه‌های نمونه، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعه دادهٔ کاملاً سفارشی، هر دو مجموعهٔ سری و دسته را پاک کنید. یک overload نیز می‌تواند نمودار را بدون داده‌های پیش‌فرض ایجاد کند.

**شیءهای نمودار چگونه به سلول‌های workbook متصل می‌شوند؟**

نام‌های مجموعه، برچسب‌های دسته و مقادیر نقطه‑داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده عنصر مربوطهٔ نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده‌های سفارشی، ردیف‌های دسته و ردیف‌های مقادیر مجموعه را هم‌راستا نگه دارید تا هر نقطه زیر دستهٔ مورد نظر ترسیم شود.

**چگونه یک نقطه را به‌جای کل مجموعه پاک کنم؟**

سلول مقدار مرتبط را به `nullptr` تنظیم کنید تا موقعیت دستهٔ نقطه به‌عنوان نقطه‌ای خالی حفظ شود. فقط زمانی که می‌خواهید تمام نقاط را حذف کنید، [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) را فراخوانی کنید؛ این متد تمام نقاط داده را از مجموعه حذف می‌کند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه به نوع نمودار و [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) بستگی دارد. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌صورت فاصله، به‌صورت مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای دادهٔ گمشده در ارائهٔ شما را منعکس کند. برای مثال کامل و مقایسهٔ تصویری به بخش [Control the Display of Empty Cells](#control-the-display-of-empty-cells) مراجعه کنید.

**مقدارهای منفی چگونه قالب‌بندی می‌شوند؟**

برای مجموعه‌های نوار، ستون و حباب پشتیبانی‌شده، [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) را فراخوانی کنید و رنگ را از طریق [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) تنظیم کنید. می‌توانید رفتار را برای یک نقطهٔ منفرد با [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) بازنویسی کنید. این متدها فقط قالب‌بندی را تحت تأثیر قرار می‌دهند و مقادیر عددی ذخیره‌شده تغییر نمی‌کنند.

**در زمانیکه هم مجموعه و هم نقطه قالب‌بندی شده‌اند، کدامیک برتری دارد؟**

قالب‌بندی صریح نقطه‑داده برای آن نقطه برتر است. نقاط دیگر به قالب‌بندی صریح مجموعه یا، زمانی که قالب‌بندی مجموعه تعریف نشده باشد، به سبک و تم خودکار نمودار ادامه می‌دهند. تنظیمات گروهی مانند overlap و gap width بر چیدمان تأثیر می‌گذارند و بازنویسی‌های قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد مجموعه‌های یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد مجموعه‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظهٔ موجود، زمان رندرینگ و قابلیت خواندن نمودار تعیین کنندهٔ حد قابل استفاده هستند.

**چه کاری باید انجام دهم وقتی ستون‌ها بیش از حد نزدیک یا دور از هم هستند؟**

در گروه مجموعهٔ والد مناسب، [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) را فراخوانی کنید. مقدار را افزایش دهید تا فاصلهٔ بین خوشه‌ها گسترده شود یا کاهش دهید تا خوشه‌ها نزدیک‌تر شوند.