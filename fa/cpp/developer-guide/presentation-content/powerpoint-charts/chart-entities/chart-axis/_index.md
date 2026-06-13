---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها با استفاده از C++
linktitle: محور نمودار
type: docs
url: /fa/cpp/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
- مدیریت محور
- ویژگی‌های محور
- مقدار حداکثر
- مقدار حداقل
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای C++ استفاده کنید تا محورهای نمودار را در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه محورهای نمودار را در Aspose.Slides سفارشی کنید. نشان می‌دهد چگونه مقادیر واقعی محور را به دست آورید، داده‌ها را بین محورها جابه‌جا کنید، محور عمودی یا افقی را برای نمودارهای خطی مخفی کنید، نوع محور دسته‌ای را تغییر دهید، قالب تاریخ برای مقادیر محور دسته‌ای را تنظیم کنید، عنوان یک محور را بچرخانید، موقعیت محور را تعیین کنید و برچسب واحد را بر روی محور مقدار نمایش دهید.

## **دریافت مقادیر حداکثری در محور عمودی**
Aspose.Slides for C++ به شما اجازه می‌دهد که مقادیر حداقل و حداکثر را در یک محور عمودی به دست آورید. این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
4. مقدار حداکثری واقعی محور را دریافت کنید.
5. مقدار حداقل واقعی محور را دریافت کنید.
6. واحد اصلی واقعی محور را دریافت کنید.
7. واحد فرعی واقعی محور را دریافت کنید.
8. مقیاس واحد اصلی واقعی محور را دریافت کنید.
9. مقیاس واحد فرعی واقعی محور را دریافت کنید.

این کد نمونه—یک پیاده‌سازی از مراحل بالا—نشان می‌دهد چگونه مقادیر مورد نیاز را در C++ بدست آورید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// ذخیرهٔ ارائه
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **تعویض داده‌ها بین محورها**
Aspose.Slides به شما امکان می‌دهد به سرعت داده‌ها را بین محورها جابه‌جا کنید—داده‌های نمایش داده شده در محور عمودی (محور y) به محور افقی (محور x) منتقل می‌شوند و بالعکس.

این کد C++ نشان می‌دهد چگونه عملیات تعویض داده‌ها بین محورهای یک نمودار را انجام دهید:

``` cpp
// ایجاد یک ارائه خالی
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// ردیف‌ها و ستون‌ها را جابجا می‌کند
chart->get_ChartData()->SwitchRowColumn();

// ارائه را ذخیره می‌کند
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

این کد C++ نشان می‌دهد چگونه محور عمودی یک نمودار خطی را مخفی کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **غیرفعال کردن محور افقی برای نمودارهای خطی**

این کد نشان می‌دهد چگونه محور افقی یک نمودار خطی را مخفی کنید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **تغییر محور دسته‌ای**

با استفاده از متد **set_CategoryAxisType()** می‌توانید نوع محور دسته‌ای دلخواه خود را (‏**date** یا **text**) مشخص کنید. این کد در C++ عملیات را نمایش می‌دهد:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**
Aspose.Slides for C++ به شما اجازه می‌دهد قالب تاریخ را برای مقدار یک محور دسته‌ای تنظیم کنید. عملیات در این کد C++ نشان داده شده است:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **تنظیم زاویه چرخش برای عنوان محور**
Aspose.Slides for C++ به شما اجازه می‌دهد زاویه چرخش را برای عنوان محور یک نمودار تنظیم کنید. این کد C++ عملیات را نشان می‌دهد:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **تنظیم موقعیت محور در محور دسته‌ای یا مقدار**
Aspose.Slides for C++ به شما اجازه می‌دهد موقعیت محور را در یک محور دسته‌ای یا مقدار تنظیم کنید. این کد C++ نشان می‌دهد چگونه این کار را انجام دهید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **فعال‌سازی نمایش برچسب واحد بر روی محور مقدار نمودار**
Aspose.Slides for C++ به شما اجازه می‌دهد یک نمودار را طوری پیکربندی کنید که برچسب واحد را بر روی محور مقدار خود نشان دهد. این کد C++ عملیات را نمایش می‌دهد:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (تقاطع محور) را تنظیم کنم؟**

محورها یک [تنظیم تقاطع](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/axis/set_crosstype/) ارائه می‌دهند: می‌توانید انتخاب کنید که در صفر، در حداکثر دسته/مقدار یا در یک مقدار عددی مشخص تقاطع داشته باشند. این برای جابجایی محور X به بالا یا پایین یا برای تاکید بر یک خط پایه مفید است.

**چگونه برچسب‌های تیک را نسبت به محور موقعیت‌دهی کنم (در کنار، خارج، داخل)؟**

[موقعیت برچسب](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/axis/set_majortickmark/) را به "cross"، "outside" یا "inside" تنظیم کنید. این بر خوانایی تاثیر می‌گذارد و به خصوص در نمودارهای کوچک به صرفه‌جویی در فضا کمک می‌کند.