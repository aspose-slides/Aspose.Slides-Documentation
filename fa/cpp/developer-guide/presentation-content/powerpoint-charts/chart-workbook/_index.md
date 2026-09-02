---
title: مدیریت کتاب‌های کار نمودار در ارائه‌ها با C++
linktitle: کتاب کار نمودار
type: docs
weight: 70
url: /fa/cpp/chart-workbook/
keywords:
- کتاب کار نمودار
- داده‌های نمودار
- سلول کتاب کار
- برچسب داده
- کاربرگ
- منبع داده
- کتاب کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب کار
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را کشف کنید: به سادگی کتاب‌های کار نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهبود ببخشید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌های کار نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب کار بخوانید و بنویسید، از سلول‌های کتاب کار به عنوان برچسب داده‌های نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌های کار خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. نمونه‌ها نشان می‌دهند چگونه یک کتاب کار خارجی ایجاد و اختصاص دهید، مسیر کتاب کار خارجی پیوست‌شده به یک نمودار را بازیابی کنید و داده‌های نمودار را وقتی کتاب کار در دسترس باشد ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب کار**

Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) را ارائه می‌دهد که به شما امکان می‌دهد کتاب‌های کار دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شیوه سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

این کد C++ عمل تنظیم یک کتاب کار دادهٔ نمودار را نشان می‌دهد:

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

## **تنظیم یک سلول WorkBook به عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک نمودار حبابی با برخی داده‌ها اضافه کنید.  
4. به سری‌های نمودار دسترسی پیدا کنید.  
5. سلول workbook را به عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه یک سلول workbook را به عنوان برچسب دادهٔ نمودار تنظیم کنید:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// یک نمونه از کلاس Presentation که فایل ارائه را نمایندگی می‌کند 
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

## **تشخیص فرمت‌های پشتیبانی‌نشده کتاب کار جاسازی‌شده**

Aspose.Slides از فرمت کتاب کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از متد `get_EmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/workbooktype/) برای تشخیص فرمت‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.

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
        // کتاب کار جاسازی‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
        continue;
    }

    // در اینجا داده‌های کتاب کار نمودار را بخوانید یا تغییر دهید.
}
```

## **کتاب کار خارجی**

{{% alert color="primary" %}} 
در [Aspose.Slides](https://releases.aspose.com/slides/fa/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) نسخه 19.4، ما پشتیبانی از کتاب‌های کار خارجی را به عنوان منبع داده برای نمودارها پیاده‌سازی کردیم.
{{% /alert %}} 

### **ایجاد یک کتاب کار خارجی**

با استفاده از متدهای **`ReadWorkbookStream`** و **`SetExternalWorkbook`** می‌توانید یا یک کتاب کار خارجی را از ابتدا ایجاد کنید یا یک کتاب کار داخلی را خارجی کنید.

این کد C++ فرآیند ایجاد کتاب کار خارجی را نشان می‌دهد:

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

### **تنظیم یک کتاب کار خارجی**

با استفاده از متد **`IChartData::SetExternalWorkbook`** می‌توانید یک کتاب کار خارجی را به یک نمودار به عنوان منبع داده اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب کار خارجی (اگر جابجا شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌ها را در کتاب‌های کاری که در مکان‌های دوردست یا منابع ذخیره شده‌اند ویرایش کنید، می‌توانید همچنان از چنین کتاب‌هایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب کار خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد C++ نشان می‌دهد چگونه یک کتاب کار خارجی تنظیم کنید:

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

پارامتر `updateChartData` (در زیر متد `SetExternalWorkbook`) برای تعیین اینکه آیا یک کتاب کار اکسل بارگذاری شود یا نه، به کار می‌رود.

* وقتی مقدار `updateChartData` برابر `false` تنظیم شود، فقط مسیر کتاب کار به‌روز می‌شود—داده‌های نمودار بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید از این تنظیم زمانی استفاده کنید که کتاب کار هدف وجود نداشته باشد یا در دسترس نباشد.  
* وقتی مقدار `updateChartData` برابر `true` تنظیم شود، داده‌های نمودار از کتاب کار هدف به‌روزرسانی می‌شوند.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **دریافت مسیر کتاب کار منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شی برای شکل نمودار ایجاد کنید.  
4. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع دادهٔ نمودار است ایجاد کنید.  
5. شرط مربوطه را بر اساس اینکه نوع منبع همان نوع منبع دادهٔ کتاب کار خارجی باشد، مشخص کنید.

این کد C++ عمل را نشان می‌دهد:

```c++
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

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌های کار خارجی را همان‌گونه که محتویات کتاب‌های کار داخلی را تغییر می‌دهید، ویرایش کنید. وقتی یک کتاب کار خارجی قابل بارگذاری نباشد، استثنا ایپاد می‌شود.

این کد C++ پیاده‌سازی فرآیند توضیح‌شده را نشان می‌دهد:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **بازیابی کتاب کار از کش نمودار**

اگر یک نمودار از کتاب کار خارجی که گم‌شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شی [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) ایجاد کنید، آن را با [set_SpreadsheetOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه، متد [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) را با مقدار `true` فراخوانی کنید.

مثال C++ زیر ارائه‌ای را باز می‌کند که نمودار آن به یک کتاب کار خارجی غیرقابل دسترس ارجاع می‌دهد و داده‌های بازیابی‌شده را از طریق [IChart::get_ChartData](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_chartdata/) و [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی می‌یابد:

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// در اینجا داده‌های کتاب کار بازیابی‌شده را بخوانید یا ویرایش کنید.

presentation->Dispose();
```

اگر کتاب کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک `System::InvalidOperationException` پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ پذیرفتنی باشد، زیرا کش ممکن است تغییراتی که پس از آخرین بروز رسانی ارائه روی کتاب کار خارجی اعمال شده‌اند، شامل نشود.

## **سوالات متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به کتاب کار خارجی یا داخلی لینک شده است؟**  
بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و [مسیر به کتاب کار خارجی](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) است؛ اگر منبع یک کتاب کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌های کار خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت حمل پروژه مفید است؛ اما باید بدانید که مسیر مطلق در فایل PPTX ذخیره می‌شود.

**آیا می‌توانم از کتاب‌های کاری که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**  
بله، چنین کتاب‌های کاری می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌های کاری دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی خود هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**در صورتی که فایل خارجی با رمز محافظت شده باشد، چه کاری باید انجام دهم؟**  
Aspose.Slides هنگام لینک‌کردن رمز عبور را قبول نمی‌کند. یک روش معمول این است که پیش از لینک‌کردن حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/cpp/)) آماده کنید و به آن نسخه لینک دهید.

**آیا می‌توان چندین نمودار به یک کتاب کار خارجی ارجاع داد؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس خواهد شد.