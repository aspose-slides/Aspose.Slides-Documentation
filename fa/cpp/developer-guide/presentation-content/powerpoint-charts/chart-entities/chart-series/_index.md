---
title: مدیریت داده‌های سری نمودار در ارائه‌ها با استفاده از C++
linktitle: سری داده‌ها
type: docs
url: /fa/cpp/chart-series/
keywords:
- سری نمودار
- همپوشانی سری
- رنگ سری
- رنگ دسته‌بندی
- نام سری
- نقطه داده
- فاصله سری
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "یادگیری نحوه مدیریت سری‌های نمودار در C++ برای پاورپوینت (PPT/PPTX) با مثال‌های عملی کد و بهترین روش‌ها برای بهبود ارائه‌های داده‌ای شما."
---
## **بررسی کلی**

این مقاله نقش [ChartSeries](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartseries/) را در Aspose.Slides توضیح می‌دهد و بر نحوه ساختاردهی و نمایش داده‌ها در ارائه‌ها تمرکز دارد. این اشیاء مؤلفه‌های پایه‌ای را فراهم می‌کنند که مجموعه‌های جداگانه‌ای از نقاط داده، دسته‌بندی‌ها و پارامترهای ظاهر را در یک نمودار تعریف می‌کنند. با کار با [ChartSeries](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartseries/)، توسعه‌دهندگان می‌توانند منابع داده پایه را به‌صورت یکپارچه ادغام کرده و کنترل کامل بر نمایش اطلاعات داشته باشند و در نتیجه ارائه‌های دینامیک و داده‌محور تولید کنند که بینش‌ها و تحلیل‌ها را به‌وضوح منتقل می‌نمایند.

یک سری ردیف یا ستونی از اعداد است که در نمودار رسم می‌شود.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری داده‌ها**

با متد [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) می‌توانید میزان همپوشانی میله‌ها و ستون‌ها در یک نمودار دو‑بعدی را تعیین کنید (محدوده: -100 تا 100). این ویژگی بر تمام سری‌های گروه سری والد اعمال می‌شود: این یک بازتاب از ویژگی گروه مناسب است.

از متد `get_ParentSeriesGroup()::set_Overlap()` برای تعیین مقدار مورد نظر خود برای `Overlap` استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. یک نمودار ستونی خوشه‌ای به اسلاید اضافه کنید.  
1. به اولین سری نمودار دسترسی پیدا کنید.  
1. `ParentSeriesGroup` سری نمودار را دریافت کرده و مقدار همپوشانی دلخواه را برای سری تنظیم کنید.  
1. ارائه اصلاح‌شده را به فایل PPTX بنویسید.

کد C++ زیر نشان می‌دهد چگونه همپوشانی یک سری نمودار را تنظیم کنید:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // تنظیم همپوشانی سری
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// نوشتن فایل ارائه بر روی دیسک
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **تغییر رنگ سری داده‌ها**
Aspose.Slides برای C++ به شما امکان می‌دهد رنگ یک سری را به‌صورت زیر تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. نمودار را به اسلاید اضافه کنید.  
1. سری‌ای که می‌خواهید رنگ آن را تغییر دهید، پیدا کنید.  
1. نوع پر کردن و رنگ پر کردن دلخواه را تنظیم کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه رنگ یک سری را تغییر دهید:

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

## **تغییر رنگ دسته‌بندی یک سری داده‌ها**
Aspose.Slides برای C++ به شما امکان می‌دهد رنگ یک دسته‌بندی سری را به‌صورت زیر تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. نمودار را به اسلاید اضافه کنید.  
1. دسته‌بندی سری‌ای که می‌خواهید رنگ آن را تغییر دهید، پیدا کنید.  
1. نوع پر کردن و رنگ پر کردن دلخواه را تنظیم کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.

این کد C++ نشان می‌دهد چگونه رنگ یک دسته‌بندی سری را تغییر دهید:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **تغییر نام سری داده‌ها** 

به‌طور پیش‌فرض، نام‌های لیجند برای یک نمودار محتوای سلول‌های بالای هر ستون یا ردیف داده هستند.

در مثال ما (تصویر نمونه)،

* ستون‌ها *Series 1, Series 2,* و *Series 3* هستند؛
* ردیف‌ها *Category 1, Category 2, Category 3,* و *Category 4* هستند.

Aspose.Slides برای C++ به شما اجازه می‌دهد نام یک سری را در داده‌های نمودار و لیجند آن به‌روزرسانی یا تغییر دهید.

کد C++ زیر نشان می‌دهد چگونه نام یک سری را در `ChartDataWorkbook` داده‌های نمودار تغییر دهید:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

کد C++ زیر نشان می‌دهد چگونه نام یک سری را از طریق `Series` در لیجند تغییر دهید:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **تنظیم رنگ پر شدن سری داده‌ها**

Aspose.Slides برای C++ به شما امکان می‌دهد رنگ پر شدن خودکار برای سری‌های نمودار داخل ناحیه رسم را به‌صورت زیر تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را بر اساس ایندکس آن به‌دست آورید.  
1. یک نمودار با داده‌های پیش‌فرض بر اساس نوع دلخواه خود اضافه کنید (در مثال زیر از `ChartType::ClusteredColumn` استفاده کردیم).  
1. سری نمودار را دسترسی پیدا کرده و رنگ پر شدن را به Automatic تنظیم کنید.  
1. ارائه را به فایل PPTX ذخیره کنید.

کد C++ زیر نشان می‌دهد چگونه رنگ پر شدن خودکار برای یک سری نمودار تنظیم شود:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// یک نمودار ستونی خوشه ای ایجاد می کند
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// قالب پر شدن سری را به حالت خودکار تنظیم می کند
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// فایل ارائه را بر روی دیسک می نویسد
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **تنظیم معکوس رنگ پر شدن سری داده‌ها**
Aspose.Slides به شما اجازه می‌دهد رنگ پر شدن معکوس برای سری‌های نمودار داخل ناحیه رسم را به‌صورت زیر تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع یک اسلاید را بر اساس ایندکس آن به‌دست آورید.  
1. یک نمودار با داده‌های پیش‌فرض بر اساس نوع دلخواه خود اضافه کنید (در مثال زیر از `ChartType::ClusteredColumn` استفاده کردیم).  
1. سری نمودار را دسترسی پیدا کرده و رنگ پر شدن را به invert تنظیم کنید.  
1. ارائه را به فایل PPTX ذخیره کنید.

این کد C++ عملیات را نشان می‌دهد:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// افزودن سری‌ها و دسته‌بندی‌های جدید
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// دریافت اولین سری نمودار و پر کردن داده‌های سری آن.
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

## **تنظیم معکوس رنگ پر شدن برای یک سری نمودار**
Aspose.Slides به شما اجازه می‌دهد معکوس‌سازی را از طریق متدهای `IChartDataPoint::set_InvertIfNegative()` و `ChartDataPoint.set_InvertIfNegative()` انجام دهید. وقتی معکوس با این متدها تنظیم شود، نقطه داده هنگام دریافت مقدار منفی رنگ خود را معکوس می‌کند.

این کد C++ عملیات را نشان می‌دهد:

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

## **پاک‌سازی مقادیر نقطه داده خاص**
Aspose.Slides برای C++ به شما امکان می‌دهد داده‌های `DataPoints` یک سری خاص نمودار را به‌صورت زیر پاک کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع یک اسلاید را از طریق ایندکس آن به‌دست آورید.  
3. مرجع یک نمودار را از طریق ایندکس آن به‌دست آورید.  
4. تمام `DataPoints` نمودار را پیمایش کنید و `XValue` و `YValue` را به null تنظیم کنید.  
5. تمام `DataPoints` برای سری خاص را پاک کنید.  
6. ارائه اصلاح‌شده را به فایل PPTX بنویسید.

این کد C++ عملیات را نشان می‌دهد:

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

## **تنظیم عرض فاصله (Gap Width) سری داده‌ها**
Aspose.Slides برای C++ به شما اجازه می‌دهد عرض فاصله یک سری را از طریق متد **`set_GapWidth()`** به‌صورت زیر تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. اولین اسلاید را دسترسی پیدا کنید.  
1. نموداری با داده‌های پیش‌فرض اضافه کنید.  
1. هر سری نموداری را دسترسی پیدا کنید.  
1. ویژگی `GapWidth` را تنظیم کنید.  
1. ارائه اصلاح‌شده را به فایل PPTX بنویسید.

این کد C++ نشان می‌دهد چگونه عرض فاصله یک سری تنظیم شود:

```cpp
// یک ارائه خالی ایجاد می‌کند 
auto presentation = System::MakeObject<Presentation>();

// به اولین اسلاید ارائه دسترسی می‌یابد
auto slide = presentation->get_Slides()->idx_get(0);

// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// اندیس شیت داده‌های نمودار را تنظیم می‌کند
int32_t worksheetIndex = 0;

// برگه‌کار داده‌های نمودار را دریافت می‌کند
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// سری‌ها را اضافه می‌کند
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// دسته‌بندی‌ها را اضافه می‌کند
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// دومین سری نمودار را دریافت می‌کند
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// داده‌های سری را پر می‌کند
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// مقدار GapWidth را تنظیم می‌کند
series->get_ParentSeriesGroup()->set_GapWidth(50);

// ارائه را بر روی دیسک ذخیره می‌کند
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا محدودیتی برای تعداد سری‌هایی که یک نمودار می‌تواند داشته باشد وجود دارد؟**

Aspose.Slides هیچ محدودیت ثابتی برای تعداد سری‌های اضافه‌شده اعمال نمی‌کند. سقف عملی توسط قابلیت خواندن نمودار و حافظه موجود برای برنامه شما تعیین می‌شود.

**اگر ستون‌های داخل یک خوشه بیش از حد نزدیک یا بیش از حد دور باشند چه باید کرد؟**

تنظیم مقدار **Gap Width** برای آن سری (یا گروه سری والد) را تغییر دهید. افزایش مقدار، فضای بین ستون‌ها را گسترش می‌دهد، در حالی که کاهش مقدار، آن‌ها را به‑هم نزدیک می‌کند.