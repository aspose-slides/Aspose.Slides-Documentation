---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از C++
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/cpp/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- کاربرگ
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار می‌کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده‌های نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را دریافت کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش شده با Aspose.Cells) را بخوانید و بنویسید. **Note** داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

### **اعتبارسنجی چیدمان نمودار پس از اصلاح کتاب‌کار**

وقتی کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌بندی‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود متد [IChart::ValidateChartLayout](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/validatechartlayout/) با خطای «index‑out‑of‑range» شکست بخورد. پیش از نوشتن کتاب‌کار به‌روزشده به نمودار، سری‌ها و دسته‌بندی‌های موجود را پاک کنید.

```cpp
// پس از تغییر جریان کتاب‌کار (به عنوان مثال با استفاده از Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// پاک کردن مراجعات داده‌های موجود.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

پاک کردن مجموعه‌ها اطمینان می‌دهد که ساختار دادهٔ نمودار با کتاب‌کار جدید سازگار است و `ValidateChartLayout` بدون خطا تکمیل می‌شود.

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک نمودار حبابی با برخی داده‌ها اضافه کنید.  
4. به سری‌های نمودار دسترسی پیدا کنید.  
5. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک سلول کتاب‌کار را به‌عنوان برچسب دادهٔ نمودار تنظیم کنید:

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

// یک شی از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
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

این کد C++ عملی را نشان می‌دهد که در آن متد [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) برای دسترسی به مجموعهٔ کاربرگ‌ها استفاده می‌شود:

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

## **مشخص کردن نوع منبع داده**

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

## **تشخیص قالب‌های توکار کتاب‌کار که پشتیبانی نمی‌شوند**

Aspose.Slides از قالب کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `get_EmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید.

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
        // دفتر کاری توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
        continue;
    }

    // در اینجا داده‌های دفتر کاری نمودار را بخوانید یا اصلاح کنید.
}
```

## **کتاب‌کار خارجی**

{{% alert color="info" %}} 
در [Aspose.Slides](https://releases.aspose.com/slides/fa/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4، ما پشتیبانی از کتاب‌کارهای خارجی را به عنوان منبع دادهٔ نمودارها پیاده‌سازی کرده‌ایم. 
{{% /alert %}} 

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای **`ReadWorkbookStream`** و **`SetExternalWorkbook`** می‌توانید یا یک کتاب‌کار خارجی را از صفر ایجاد کنید یا یک کتاب‌کار داخلی را به‌صورت خارجی درآورید.

این کد C++ فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

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

### **تخصیص یک کتاب‌کار خارجی**

با استفاده از متد **`IChartData::SetExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابجا شدن آن) استفاده شود.

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهایی که در مکان‌های شبکه‌ای یا منابع دوردست ذخیره شده‌اند را مستقیما ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی فراهم شود، به‌طور خودکار به مسیر کامل تبدیل می‌گردد.

این کد C++ نشان می‌دهد چگونه یک کتاب‌کار خارجی را تنظیم کنید:

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

پارامتر `updateChartData` (در زیر متد `SetExternalWorkbook`) برای تعیین اینکه آیا یک کتاب‌کار Excel بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید از این تنظیم وقتی کتاب‌کار هدف وجود ندارد یا در دسترس نیست، استفاده کنید.  
* وقتی مقدار `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

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

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
3. یک شی برای شکل نمودار بسازید.  
4. یک شی برای نوع منبع (`ChartDataSourceType`) که منبع دادهٔ نمودار را نشان می‌دهد، ایجاد کنید.  
5. شرط مربوطه را بر اساس این‌که نوع منبع همان نوع منبع دادهٔ کتاب‌کار خارجی باشد، مشخص کنید.

این کد C++ عمل را نشان می‌دهد:

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

// ذخیرهٔ ارائه
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند تغییرات در محتویات کتاب‌کارهای داخلی ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

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

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده کند که غائب یا در دسترس نباشد، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش شده در ارائه بازسازی کند. یک شی [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) ایجاد کنید، آن را با متد [set_SpreadsheetOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه، متد [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) را با مقدار `true` صدا بزنید.

مثال زیر یک ارائه را باز می‌کند که نمودار آن به یک کتاب‌کار خارجی غیرفعال اشاره دارد و داده‌های بازیابی‌شده را از طریق [IChart::get_ChartData](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_chartdata/) و [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی می‌یابد:

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

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک `System::InvalidOperationException` پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش شده نمودار یک گزینهٔ قابل قبول باشد، بازیابی را فعال کنید، زیرا کش ممکن است شامل تغییراتی که پس از آخرین به‌روزرسانی ارائه در کتاب‌کار خارجی ایجاد شده باشد، نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به یک کتاب‌کار خارجی یا توکار لینک شده است؟**  
بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. این برای جابجایی پروژه مناسب است؛ اما باید توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/اشتراک‌های شبکه‌ای قرار دارند استفاده کنم؟**  
بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توان آنها را به‌عنوان منبع استفاده کرد.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
نه. ارائه فقط یک [link to the external file](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کاری باید انجام دهم؟**  
Aspose.Slides هنگام لینک‌دهی رمز عبور را نمی‌پذیرد. یک روش معمول این است که پیش از لینک‌دهی محافظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/cpp/)) تهیه کنید و به آن لینک دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس می‌شود.