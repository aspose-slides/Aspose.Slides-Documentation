---
title: سفارشی‌سازی محورها در نمودارهای ارائه با استفاده از C++
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
- بیشترین مقدار
- کمترین مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای C++ برای سفارشی‌سازی محورها در نمودارهای PowerPoint در ارائه‌ها برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **بررسی اجمالی**

این مقاله توضیح می‌دهد که چگونه محورها را در نمودارهای Aspose.Slides سفارشی کنید. این مقاله نشان می‌دهد چگونه مقادیر واقعی محورها را دریافت کنید، داده‌ها را بین محورها جابه‌جا کنید، محور عمودی یا افقی را برای نمودارهای خطی مخفی کنید، نوع محور دسته‌بندی را تغییر دهید، قالب تاریخ برای مقادیر محور دسته‌بندی را تنظیم کنید، عنوان یک محور را چرخانده، موقعیت محور را تنظیم کنید و برچسب واحد را بر روی محور مقادیر نمایش دهید.

## **دریافت حداکثر مقادیر محور عمودی**

Aspose.Slides برای C++ به شما امکان می‌دهد مقادیر حداقل و حداکثر را بر روی محور عمودی به‌دست آورید. این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
1. مقدار حداکثری واقعی محور را دریافت کنید.
1. مقدار حداقل واقعی محور را دریافت کنید.
1. واحد اصلی واقعی محور را دریافت کنید.
1. واحد فرعی واقعی محور را دریافت کنید.
1. مقیاس واحد اصلی واقعی محور را دریافت کنید.
1. مقیاس واحد فرعی واقعی محور را دریافت کنید.

این کد نمونه — پیاده‌سازی مراحل بالا — نشان می‌دهد چگونه مقادیر مورد نیاز را در C++ به‌دست آورید:

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

// ارائه را ذخیره می‌کند
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **جابه‌جایی داده‌ها بین محورها**

Aspose.Slides به شما امکان می‌دهد به سرعت داده‌ها را بین محورها جابجا کنید — داده‌های نمایان‌شده بر روی محور عمودی (y-axis) به محور افقی (x-axis) منتقل می‌شوند و بالعکس.

این کد C++ نشان می‌دهد چگونه وظیفه جابجایی داده‌ها بین محورها را بر روی یک نمودار انجام دهید:

``` cpp
// یک ارائه خالی ایجاد می‌کند
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// سطرها و ستون‌ها را جابجا می‌کند
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

## **تغییر محور دسته‌بندی**

با استفاده از متد **set_CategoryAxisType()** می‌توانید نوع محور دسته‌بندی دلخواه خود (**date** یا **text**) را تعیین کنید. این کد در C++ عملیات را نشان می‌دهد: 

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

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌بندی**

Aspose.Slides برای C++ به شما امکان می‌دهد قالب تاریخ برای مقدار محور دسته‌بندی را تنظیم کنید. این عملیات در کد C++ زیر نشان داده شده است:

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

Aspose.Slides برای C++ به شما امکان می‌دهد زاویه چرخش را برای عنوان محور نمودار تنظیم کنید. این کد C++ عملیات را نشان می‌دهد:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **تنظیم موقعیت محور بر روی محور دسته‌بندی یا مقدار**

Aspose.Slides برای C++ به شما امکان می‌دهد موقعیت محور را در یک محور دسته‌بندی یا مقدار تنظیم کنید. این کد C++ نشان می‌دهد چگونه این کار را انجام دهید:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **فعال‌سازی نمایش برچسب واحد بر محور مقدار نمودار**

Aspose.Slides برای C++ به شما امکان می‌دهد یک نمودار را طوری پیکربندی کنید که برچسب واحد را بر روی محور مقدار نمودار نمایش دهد. این کد C++ عملیات را نشان می‌دهد:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**چگونه مقدار عبور یک محور از محور دیگر (crossing) را تنظیم کنم؟**

محورها یک [تنظیم crossing](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/axis/set_crosstype/) ارائه می‌دهند: می‌توانید انتخاب کنید که در صفر، در حداکثر دسته/مقدار یا در یک مقدار عددی خاص عبور کنند. این برای جابه‌جایی محور X به بالا یا پایین یا برای برجسته‌سازی خط پایه مفید است.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌دهی کنم (در کنار، خارج، داخل)؟**

موقعیت [برچسب](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/axis/set_majortickmark/) را روی «cross»، «outside» یا «inside» تنظیم کنید. این بر خوانایی تأثیر می‌گذارد و به صرفه‌جویی در فضا، به‌ویژه در نمودارهای کوچک، کمک می‌کند.