---
title: مدیریت سری‌های داده نمودار در ارائه‌ها با استفاده از C++
linktitle: سری داده‌ها
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
description: "یاد بگیرید چگونه سری‌های نمودار را در C++ برای PowerPoint (PPT/PPTX) مدیریت کنید، با مثال‌های عملی کد و بهترین روش‌ها برای بهبود ارائه‌های داده‌ای خود."
---
## **نمای کلی**

این مقاله نقش [ChartSeries](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartseries/) را در Aspose.Slides توضیح می‌دهد و بر نحوه ساختاردهی و تجسم داده‌ها در ارائه‌ها متمرکز است. این شیءها عناصر بنیادی را فراهم می‌کنند که مجموعه‌های جداگانه‌ای از نقاط داده، دسته‌ها و پارامترهای ظاهر را در یک نمودار تعریف می‌کنند. با کار با [ChartSeries](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartseries/)، توسعه‌دهندگان می‌توانند منابع داده زیرین را به‌صورت یکپارچه یکپارچه‌سازی کنند و کنترل کامل بر نحوه نمایش اطلاعات داشته باشند، که منجر به ارائه‌های پویا و مبتنی بر داده می‌شود که به‌وضوح بینش‌ها و تحلیل‌ها را منتقل می‌کند.

یک سری، ردیف یا ستونی از اعداد است که در یک نمودار رسم می‌شود.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری داده‌ها**

با متد [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) می‌توانید مقدار همپوشانی نوارها و ستون‌ها را در یک نمودار 2D تعیین کنید (محدوده: -100 تا 100). این ویژگی برای تمام سری‌های گروه سری والد اعمال می‌شود: این یک بازسنجی از ویژگی گروه مناسب است.

از متد `get_ParentSeriesGroup()::set_Overlap()` برای تنظیم مقدار موردنظر برای `Overlap` استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. یک نمودار ستونی خوشه‌ای به اسلاید اضافه کنید.  
1. سری نمودار اول را دسترسی پیدا کنید.  
1. `ParentSeriesGroup` سری نمودار را دسترسی پیدا کنید و مقدار همپوشانی موردنظر را برای سری تنظیم کنید.  
1. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.  

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// افزودن نمودار
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // تنظیم همپوشانی سری
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// ذخیره فایل ارائه در دیسک
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **تغییر رنگ سری داده‌ها**

Aspose.Slides برای C++ به شما امکان می‌دهد رنگ یک سری را به این روش تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. یک نمودار به اسلاید اضافه کنید.  
1. سری‌ای که می‌خواهید رنگ آن را تغییر دهید، دسترسی پیدا کنید.  
1. نوع پرکنش و رنگ پرکنش موردنظر خود را تنظیم کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.  

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

## **تغییر رنگ دسته‌بندی سری داده‌ها**

Aspose.Slides برای C++ به شما امکان می‌دهد رنگ یک دسته‌بندی سری را به این روش تغییر دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. یک نمودار به اسلاید اضافه کنید.  
1. دسته‌بندی سری‌ای که می‌خواهید رنگ آن را تغییر دهید، دسترسی پیدا کنید.  
1. نوع پرکنش و رنگ پرکنش موردنظر خود را تنظیم کنید.  
1. ارائه اصلاح‌شده را ذخیره کنید.  

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

به‌صورت پیش‌فرض، نام‌های لگند برای یک نمودار محتوای سلول‌های بالای هر ستون یا ردیف داده هستند.  

در مثال ما (تصویر نمونه)،  

* ستون‌ها عبارتند از *Series 1, Series 2,* و *Series 3*؛  
* سطرها عبارتند از *Category 1, Category 2, Category 3,* و *Category 4.*  

Aspose.Slides برای C++ به شما امکان می‌دهد نام یک سری را در داده‌های نمودار و لگند به‌روزرسانی یا تغییر دهید.  

این کد C++ نشان می‌دهد چگونه نام یک سری را در داده‌های نمودار `ChartDataWorkbook` تغییر دهید:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

این کد C++ نشان می‌دهد چگونه نام یک سری را در لگند آن از طریق `Series` تغییر دهید:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **تنظیم رنگ پرکنش سری داده‌ها**

Aspose.Slides برای C++ به شما امکان می‌دهد رنگ پرکنش خودکار برای سری‌های نمودار داخل ناحیه رسم را به این روش تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع اسلاید را بر حسب ایندکس آن به دست آورید.  
1. یک نمودار با داده‌های پیش‌فرض بر اساس نوع موردنظر خود اضافه کنید (در مثال زیر از `ChartType::ClusteredColumn` استفاده کردیم).  
1. سری نمودار را دسترسی پیدا کنید و رنگ پرکنش را به Automatic تنظیم کنید.  
1. ارائه را به یک فایل PPTX ذخیره کنید.  

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// یک نمودار ستونی خوشه‌ای ایجاد می‌کند
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// قالب پرکنش سری را به حالت خودکار تنظیم می‌کند
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// فایل ارائه را بر روی دیسک می‌نویسد
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **تنظیم رنگ‌های پرکنش معکوس برای سری داده‌ها**

Aspose.Slides به شما امکان می‌دهد رنگ پرکنش معکوس برای سری‌های نمودار داخل ناحیه رسم را به این روش تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. مرجع اسلاید را بر حسب ایندکس آن به دست آورید.  
1. یک نمودار با داده‌های پیش‌فرض بر اساس نوع موردنظر خود اضافه کنید (در مثال زیر از `ChartType::ClusteredColumn` استفاده کردیم).  
1. سری نمودار را دسترسی پیدا کنید و رنگ پرکنش را به invert تنظیم کنید.  
1. ارائه را به یک فایل PPTX ذخیره کنید.  

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// سری‌ها و دسته‌ها را اضافه می‌کند
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// سری اول نمودار را می‌گیرد و داده‌های سری آن را پر می‌کند.
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

## **تنظیم رنگ پرکنش معکوس برای یک سری نمودار**

Aspose.Slides به شما امکان می‌دهد معکوس‌ها را از طریق متدهای `IChartDataPoint::set_InvertIfNegative()` و `ChartDataPoint.set_InvertIfNegative()` تنظیم کنید. وقتی معکوس با استفاده از این متدها تنظیم شود، نقطه داده رنگ‌های خود را هنگام دریافت مقدار منفی معکوس می‌کند.  

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

Aspose.Slides برای C++ به شما امکان می‌دهد داده‌های `DataPoints` را برای یک سری نمودار خاص به این روش پاک کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق ایندکس آن به دست آورید.  
3. مرجع نمودار را از طریق ایندکس آن به دست آورید.  
4. بر همه `DataPoints` نمودار پیمایش کنید و `XValue` و `YValue` را به null تنظیم کنید.  
5. تمام `DataPoints` برای سری نمودار خاص را پاک کنید.  
6. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.  

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

## **تنظیم عرض فاصله سری داده‌ها**

Aspose.Slides برای C++ به شما امکان می‌دهد عرض فاصله یک سری را از طریق متد **`set_GapWidth()`** به این صورت تنظیم کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.  
1. اسلاید اول را دسترسی پیدا کنید.  
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید.  
1. هر سری نمودار را دسترسی پیدا کنید.  
1. ویژگی `GapWidth` را تنظیم کنید.  
1. ارائه اصلاح‌شده را به یک فایل PPTX بنویسید.  

```cpp
// یک ارائه خالی ایجاد می‌کند 
auto presentation = System::MakeObject<Presentation>();

// به اولین اسلاید ارائه دسترسی پیدا می‌کند
auto slide = presentation->get_Slides()->idx_get(0);

// یک نمودار با داده‌های پیش‌فرض اضافه می‌کند
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// ایندکس شیت داده‌های نمودار را تنظیم می‌کند
int32_t worksheetIndex = 0;

// شیت کاری داده‌های نمودار را دریافت می‌کند
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// سری‌ها را اضافه می‌کند
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// دسته‌ها را اضافه می‌کند
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// سری دوم نمودار را می‌گیرد
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

// ارائه را روی دیسک ذخیره می‌کند
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا محدودیتی برای تعداد سری‌هایی که یک نمودار می‌تواند داشته باشد وجود دارد؟**

Aspose.Slides محدودیت ثابت برای تعداد سری‌های اضافه‌شده اعمال نمی‌کند. سقف عملی توسط قابلیت خوانایی نمودار و حافظه موجود برای برنامه شما تعیین می‌شود.

**اگر ستون‌های داخل یک خوشه بیش از حد نزدیک یا بیش از حد دور باشند چه می‌شود؟**

تنظیم عرض فاصله (gap width) برای آن سری (یا گروه سری والد) را تغییر دهید. افزایش مقدار، فاصله بین ستون‌ها را گسترش می‌دهد، در حالی که کاهش مقدار، آن‌ها را نزدیک‌تر می‌کند.