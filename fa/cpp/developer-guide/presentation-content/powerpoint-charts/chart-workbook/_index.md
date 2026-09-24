---
title: مدیریت دفتر کار چارت در ارائه‌ها با C++
linktitle: دفتر کار چارت
type: docs
weight: 70
url: /fa/cpp/chart-workbook/
keywords:
- دفتر کار چارت
- داده‌های چارت
- سلول دفتر کار
- برچسب داده
- کاربرگ
- منبع داده
- دفتر کار خارجی
- داده خارجی
- کش چارت
- بازیابی دفتر کار
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را کشف کنید: به راحتی دفترهای کار چارت را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با دفترهای کار چارت در Aspose.Slides کار کنید. نحوه خواندن و نوشتن داده‌های چارت از طریق جریان‌های دفترکار، استفاده از سلول‌های دفترکار به عنوان برچسب‌های داده چارت، دسترسی به مجموعه‌های کاربرگ و تعیین نوع منبع داده برای مقادیر چارت را نشان می‌دهد.

همچنین کار با دفترهای کار خارجی به عنوان منابع داده چارت را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک دفتر کار خارجی ایجاد و اختصاص دهید، مسیر دفتر کار خارجی مرتبط با یک چارت را بازیابی کنید و داده‌های چارت را زمانی که دفتر کار در دسترس باشد ویرایش کنید.

برای سلول‌های دفترکار که داده‌های گمشده را نشان می‌دهند، به [Control the Display of Empty Cells](/slides/fa/cpp/chart-series/) مراجعه کنید تا تفاوت بین سلول خالی و صفر و مقایسه‌ی خط‌چارت حالت‌های نمایش موجود را مشاهده کنید.

## **خواندن و نوشتن داده‌های چارت از دفترکار**

Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما امکان خواندن و نوشتن دفترهای کار داده‌های چارت (حاوی داده‌های چارت ویرایش‌شده با Aspose.Cells) را می‌دهد. **Note** این که داده‌های چارت باید به همان صورت سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **اعتبارسنجی چیدمان چارت پس از اصلاح دفترکار**

وقتی یک دفترکار جاسازی‌شده را با یک دفترکار اصلاح‌شده جایگزین می‌کنید، چارت مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [IChart::ValidateChartLayout](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/validatechartlayout/) با خطای out-of-range شود. قبل از نوشتن دفترکار به‌روز شده به چارت، سری‌ها و دسته‌بندی‌های موجود را پاک کنید.

```cpp
// پس از اصلاح جریان دفترکار (به عنوان مثال، با استفاده از Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// پاک‌سازی ارجاعات داده‌های موجود.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

پاک‌سازی مجموعه‌ها تضمین می‌کند که ساختار داده‌های چارت با دفترکار جدید سازگار باشد و `ValidateChartLayout` بدون خطا کامل شود.

## **تنظیم یک سلول دفترکار به عنوان برچسب داده چارت**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک چارت حبابی با برخی داده‌ها اضافه کنید.  
4. به سری‌های چارت دسترسی پیدا کنید.  
5. سلول دفترکار را به عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک سلول دفترکار را به عنوان برچسب داده چارت تنظیم کنید:

``` cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **مدیریت کاربرگ‌ها**

این کد C++ نشان می‌دهد که چگونه از متد [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) برای دسترسی به مجموعه کاربرگ‌ها استفاده کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **تعیین نوع منبع داده**

این کد C++ نشان می‌دهد چگونه برای یک منبع داده نوعی را مشخص کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **تشخیص فرمت‌های پشتیبانی‌نشده دفترکار جاسازی‌شده**

Aspose.Slides از فرمت دفترکار باینری Excel (.xlsb) که می‌تواند در برخی چارت‌ها جاسازی شود پشتیبانی نمی‌کند. می‌توانید از متد `get_EmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/) همراه با شمارنده [WorkbookType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/workbooktype/) برای تشخیص فرمت‌های پشتیبانی‌نشده و حذف آن چارت‌ها استفاده کنید.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // دفترکار جاسازی‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
        continue;
    }

    // در اینجا داده‌های دفترکار چارت را بخوانید یا ویرایش کنید.
}
```

## **دفترکار خارجی**

Aspose.Slides از استفاده از دفترکارهای خارجی به عنوان منبع داده برای چارت‌ها پشتیبانی می‌کند.

### **ایجاد یک دفترکار خارجی**

با استفاده از متدهای **`ReadWorkbookStream`** و **`SetExternalWorkbook`** می‌توانید یا یک دفترکار خارجی از ابتدا ایجاد کنید یا یک دفترکار داخلی را خارجی کنید.

این کد C++ فرآیند ایجاد دفترکار خارجی را نشان می‌دهد:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **تنظیم یک دفترکار خارجی**

با استفاده از متد **`IChartData::SetExternalWorkbook`** می‌توانید یک دفترکار خارجی را به عنوان منبع داده چارت اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر دفترکار خارجی (اگر دفتر کار جابجا شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌های موجود در دفترکارهای ذخیره‌شده در مکان‌های راه دور یا منابع را ویرایش کنید، می‌توانید همچنان از چنین دفترکارهایی به عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای دفتر کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد C++ نشان می‌دهد چگونه یک دفترکار خارجی تنظیم کنید:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

پارامتر `updateChartData` (در متد `SetExternalWorkbook`) برای تعیین این‌که آیا یک دفتر کار اکسل بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `updateChartData` روی `false` تنظیم شود، فقط مسیر دفترکار به‌روزرسانی می‌شود—داده‌های چارت از دفترکار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید این تنظیم را وقتی که دفترکار هدف موجود نیست یا در دسترس نیست، به کار ببرید.  
* وقتی مقدار `updateChartData` روی `true` تنظیم شود، داده‌های چارت از دفترکار هدف به‌روز می‌شوند.

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **دریافت مسیر دفترکار منبع داده خارجی یک چارت**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شی برای شکل چارت ایجاد کنید.  
4. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع داده چارت است ایجاد کنید.  
5. شرط مربوطه را بر اساس این‌که نوع منبع همان نوع منبع دفترکار خارجی باشد، تعیین کنید.

این کد C++ عملیات را نشان می‌دهد:

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **ویرایش داده‌های چارت**

 می‌توانید داده‌های موجود در دفترکارهای خارجی را همانند تغییر محتواهای دفترکارهای داخلی ویرایش کنید. وقتی یک دفترکار خارجی قابل بارگذاری نباشد، استثنایی رخ می‌دهد.

این کد C++ پیاده‌سازی فرآیند توصیف‌شده را نشان می‌دهد:

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **بازگرداندن دفترکار از کش چارت**

اگر یک چارت از دفترکار خارجی استفاده کند که موجود نیست یا در دسترس نیست، Aspose.Slides می‌تواند دفترکار چارت را از داده‌های کش‌شده در ارائه بازسازی کند. یک شی [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) ایجاد کنید، آن را با [set_SpreadsheetOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه، `true` را به متد [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) پاس دهید.

مثال زیر C++ یک ارائه را باز می‌کند که چارت آن به یک دفترکار خارجی غیرفعال ارجاع دارد و داده‌های بازگردانده‌شده را از طریق [IChart::get_ChartData](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_chartdata/) و [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی می‌یابد:

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

اگر دفترکار خارجی در دسترس نباشد و بازگردانی غیرفعال باشد، Aspose.Slides یک `System::InvalidOperationException` پرتاب می‌کند. بازگردانی را فقط زمانی فعال کنید که استفاده از داده‌های چارت کش‌شده یک گزینه‌پذیر باشد، زیرا کش ممکن است تغییرات ایجادشده در دفترکار خارجی پس از آخرین بروز رسانی ارائه را شامل نشود.

## **سؤال‌های متداول**

**آیا می‌توانم تعیین کنم که یک چارت خاص به یک دفترکار خارجی یا جاسازی‌شده لینک دارد؟**  
بله. یک چارت دارای [data source type](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) است؛ اگر منبع یک دفترکار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید که از یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به دفترکارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای جابجایی پروژه راحت است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از دفترکارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**  
بله، چنین دفترکارهایی می‌توانند به عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم دفترکارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به عنوان منبع مورد استفاده قرار گیرند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
نه. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیره ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه باید کرد؟**  
Aspose.Slides هنگام لینک کردن رمز عبور را پذیرش نمی‌کند. رویکرد معمول حذف محافظت از پیش یا تهیه یک نسخه رمزگشایی‌شده (به عنوان مثال با استفاده از [Aspose.Cells](/cells/cpp/)) و لینک به آن نسخه است.

**آیا می‌توان چندین چارت را به یک دفترکار خارجی ارجاع داد؟**  
بله. هر چارت لینک مخصوص خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام چارت‌ها منعکس می‌شود.