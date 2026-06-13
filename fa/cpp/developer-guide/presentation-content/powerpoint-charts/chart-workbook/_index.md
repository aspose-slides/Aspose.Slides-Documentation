---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با C++
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/cpp/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- ورق کاری
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را سهل‌سازی کنید."
---
## **مروری کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های ورق‌های کاری دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع داده برای نمودارها را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و انتساب دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را دریافت کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است، ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما امکان می‌دهند کتاب‌کارهای داده نمودار (حاوی داده‌های نمودار ویرایش شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

این کد C++ عملیاتی را که برای تنظیم یک کتاب‌کار داده نمودار انجام می‌شود نمایش می‌دهد:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.
1. یک نمودار حبابی (Bubble) با داده‌هایی اضافه کنید.
1. به سری‌های نمودار دسترسی پیدا کنید.
1. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.
1. ارائه (Presentation) را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک سلول کتاب‌کار را به‌عنوان برچسب داده نمودار تنظیم کنید:

``` cpp
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

## **مدیریت ورق‌های کاری**

این کد C++ عملیاتی را نشان می‌دهد که در آن متد [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) برای دسترسی به مجموعه ورق‌های کاری استفاده می‌شود:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **مشخص‌کردن نوع منبع داده**

این کد C++ نشان می‌دهد چگونه یک نوع برای منبع داده مشخص کنید:

```c++
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

## **تشخیص فرمت‌های کتاب‌کار تعبیه‌شده پشتیبانی‌نشده**

Aspose.Slides از فرمت کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها تعبیه شود، پشتیبانی نمی‌کند. می‌توانید از متد `get_EmbeddedWorkbookType` روی [IChartData](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/workbooktype/) برای تشخیص فرمت‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
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
        // کتاب‌کار تعبیه‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
        continue;
    }

    // داده‌های کتاب‌کار نمودار را در اینجا بخوانید یا ویرایش کنید.
}
```

## **کتاب‌کار خارجی**

{{% alert color="primary" %}} 
در [Aspose.Slides](https://releases.aspose.com/slides/fa/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) نسخه 19.4، ما پشتیبانی از کتاب‌کارهای خارجی را به‌عنوان منبع داده برای نمودارها پیاده‌سازی کردیم.
{{% /alert %}} 

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای **`ReadWorkbookStream`** و **`SetExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به‌صورت خارجی درآورید.

این کد C++ فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

```c++
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

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد **`IChartData::SetExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع داده یک نمودار انتساب دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی استفاده شود (اگر کتاب‌کار جابجا شده باشد).

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌ها یا منابع دوردست را ویرایش کنید، هنوز می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این کد C++ نشان می‌دهد چگونه یک کتاب‌کار خارجی تنظیم کنید:

```c++
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

پارامتر `updateChartData` (در متد `SetExternalWorkbook`) برای تعیین اینکه آیا یک کتاب‌کار اکسل بارگذاری شود یا نه، استفاده می‌شود.

* زمانی که مقدار `updateChartData` روی `false` تنظیم شود، فقط مسیر کتاب‌کار به‌روز می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شوند. ممکن است بخواهید این تنظیم را در موقعیتی که کتاب‌کار هدف وجود ندارد یا در دسترس نیست، استفاده کنید. 
* زمانی که مقدار `updateChartData` روی `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.
1. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.
1. یک شی برای شکل نمودار ایجاد کنید.
1. یک شی برای نوع منبع (`ChartDataSourceType`) ایجاد کنید که منبع داده نمودار را نمایندگی می‌کند.
1. شرط مربوطه را بر اساس این‌که نوع منبع با نوع منبع داده کتاب‌کار خارجی یکسان است، مشخص کنید.

این کد C++ عملیات را نشان می‌دهد:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// ارائه را ذخیره می‌کند
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های کتاب‌کارهای خارجی را همان‌طور که محتویات کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. هنگامی که یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنای مربوطه پرتاب می‌شود.

این کد C++ پیاده‌سازی فرآیند شرح‌داده‌شده است:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کتاب‌کار خارجی یا تعبیه‌شده لینک دارد؟**

بله. یک نمودار دارای یک [نوع منبع داده](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و یک [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید که از یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شود و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. این برای قابل‌انتقال بودن پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهای موجود در منابع/اشتراک‌های شبکه استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی به‌خاطر ذخیره‌سازی ارائه تغییر نمی‌کند.

**در صورت اینکه فایل خارجی دارای رمز عبور باشد، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام لینک کردن رمز عبور را نمی‌پذیرد. یک روش معمول این است که پیش از آن حفاظت را حذف کنید یا یک نسخه بدون رمز (مثلاً با استفاده از [Aspose.Cells](/cells/cpp/)) تهیه کنید و به آن نسخه لینک دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همگی به یک فایل اشاره کنند، به‌روزرسانی آن فایل در بارگذاری بعدی داده‌ها در هر نمودار منعکس خواهد شد.