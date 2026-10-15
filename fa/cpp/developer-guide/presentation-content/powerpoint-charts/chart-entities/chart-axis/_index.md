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
  - حداکثر مقدار
  - حداقل مقدار
  - خط محور
  - قالب تاریخ
  - عنوان محور
  - موقعیت محور
  - PowerPoint
  - ارائه
  - C++
  - Aspose.Slides
description: "کشف کنید چگونه می‌توان از Aspose.Slides برای C++ برای سفارشی‌سازی محورها در نمودارهای ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها استفاده کرد."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان محورها را در نمودارها با Aspose.Slides برای C++ شخصی‌سازی کرد. مواردی مانند مقادیر محاسبه‌شده محور، جابجایی ردیف‌ها و ستون‌های نمودار، نمایش یا مخفی بودن محور، بازه برچسب‌های دسته‌ای و علامت‌گذاری‌های تقسیم، دسته‌بندی‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌گذاری محور، واحدهای نمایش و مقیاس لگاریتمی را پوشش می‌دهد.

## **دریافت بزرگ‌ترین مقادیر در محور عمودی نمودارها**

یک [ارائه](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید و یک نمودار منطقه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، برای به‌روزرسانی طرح نمودار، فراخوانی کنید [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/).

مقادیر حدهای محور را با [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) و [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) بخوانید و بازه‌های تقسیم را با [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) و [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) دریافت کنید. مقیاس‌های واحد زمان را با [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) و [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) به‌دست می‌آورید که برای محورهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌نماید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **جابه‌جایی داده‌ها بین محورها**

از [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته‌ی قبلی تبدیل به یک سری می‌شود و هر سری قبلی تبدیل به یک دسته می‌شود. این تغییر فقط نحوهٔ گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورها را جابه‌جا نمی‌کند. مثال از [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل سطر سرعنوان و ستون دسته، پیش از جابجایی ردیف‌ها و ستون‌ها استفاده می‌کند. سپس یک نمودار با چهار سری و سه دسته ذخیره می‌شود.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **معکوس کردن ترتیب رسم محور**

از [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) برای معکوس کردن محور دسته یا مقدار استفاده کنید. برای مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیب که در صفحه‌کار وجود دارد نمایش دهد: برنامه‌ریزی، توسعه، تست. معکوس کردن محور جهت رسم را تغییر می‌دهد؛ داده‌های کتاب‌کار را مرتب یا جابه‌جا نمی‌کند. برای مقایسه، [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) نقش سری‌ها و دسته‌ها را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. یک ارائه با سه اسلاید ذخیره می‌شود: ترتیب معمول، دسته‌های معکوس، و مقادیر معکوس. هر نسخه از همان مجموعه داده استفاده می‌کند و فقط یک محور در هر نسخه معکوس می‌شود.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// اسلاید ۲: نمایش اولین دسته در بالا.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// محور مقدار افقی را در پایین نگه دارید.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// اسلاید ۳: فقط مقیاس عددی افقی را معکوس کنید.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

معکوس کردن یک محور می‌تواند محور عمودی مخالف را به سمت دیگر نمودار جابه‌جا کند. با [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) می‌توانید تعیین کنید که محور دیگر در کجا از محور پیکربندی‌شده عبور کند. در اسلاید ۲، تنظیم آن روی `Maximum` در محور دسته معکوس باعث می‌شود محور مقدار افقی در پایین بماند. برای تعیین نقطهٔ عبور خاص، از [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) استفاده کنید. هنگام تغییر جهت، تنظیمات عبور را بررسی کنید، به‌ویژه اگر نمودار قبلاً نقطهٔ عبور سفارشی داشته باشد. برای بازگرداندن جهت عادی، `set_IsPlotOrderReversed` را با `false` فراخوانی کنید؛ تنظیمات عبور مستقل از این ویژگی هستند.

| ترتیب معمول (اسلاید 1) | دسته‌های معکوس (اسلاید 2) | مقادیر معکوس (اسلاید 3) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب معمول محور دسته و مقدار](axis-order-normal.png) | ![نمودار میله‌ای افقی با نمایش دسته‌ها از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا می‌روند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و تست از بالا به پایین نمایش داده می‌شوند. مقادیر و ترتیب ردیف‌های کتاب‌کار تغییری نکرده‌اند. | دسته‌ها ترتیب معمول خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در صفر سمت راست عبور می‌کند. |

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

با استفاده از [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) و مقدار `false` برای محور عمودی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **غیرفعال کردن محور افقی برای نمودارهای خطی**

با استفاده از [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) و مقدار `false` برای محور افقی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **تغییر یک محور دسته‌ای**

از [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) برای انتخاب محور دسته‌ای تاریخ یا متن استفاده کنید. این مثال به `ExistingChart.pptx` نیاز دارد که در اولین اسلاید اولین شکل آن یک نمودار است و سلول‌های دسته مقادیر عددی تاریخ اکسل را دارند. محور افقی را به محور تاریخ تغییر می‌دهد. با فراخوانی [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) با `false`، [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) با `1` و [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) با ماه، تقسیمات اصلی را به فواصل یک‌ماه تنظیم می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **کنترل فواصل برچسب محور دسته‌ای**

زمانی که یک نمودار دسته‌های زیادی دارد، می‌توانید تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. از [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) با `false` استفاده کنید، سپس با [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) فاصلهٔ دلخواه دسته را تنظیم کنید. برای دسته‌های متنی با ترتیب معمول، شمارش از اولین دسته شروع می‌شود:

| فواصل | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

فاصلهٔ `3` هر سومین برچسب را نمایش می‌دهد و دو برچسب میان آن‌ها مخفی می‌ماند. این کار ستون‌های متناظر را حذف نمی‌کند. فاصلهٔ خودکار بر اساس فضای موجود محاسبه می‌شود؛ لزوماً تمام برچسب‌ها را نمایش نمی‌دهد.

علامت‌گذاری‌ها کنترل‌های جداگانه‌ای دارند. با [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) و `false` و سپس با [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) می‌توانید فاصلهٔ آن‌ها را تنظیم کنید. برای مثال، مقدار `1` یک علامت‌گذاری در هر فاصلهٔ دسته نگه می‌دارد در حالی که برچسب‌ها تنها هر سومین دسته نمایش داده می‌شوند. با [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) یک سبک قابل مشاهده انتخاب کنید تا نتیجه را ببینید. بازگرداندن هر یک از خصوصیات فاصلهٔ خودکار به `true` به نمودار اجازه می‌دهد تا دوباره آن فاصله را انتخاب کند.

مثال زیر یک نمودار خودمختار ایجاد می‌کند که ۲۴ دسته و یک سری دارد، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ دستی برچسب‌ها با علامت‌گذاری‌های مستقل، و بازگرداندن فاصلهٔ خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائهٔ ورودی لازم نیست. متن برچسب افقی باعث می‌شود چگالی به وضوح قابل مشاهده باشد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// اسلاید ۲: هر سومین برچسب را نشان دهید، اما برای هر دسته یک علامت‌گذاری نگه دارید.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// اسلاید ۳: بگذارید نمودار دوباره هر دو بازه را انتخاب کند.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**فاصلهٔ خودکار (اسلاید 1):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار می‌تواند بسته به اندازهٔ نمودار، قلم‌ها و رندر کننده متفاوت باشد.

![فاصلهٔ خودکار برچسب‌های دسته با نمایش تمام ۲۴ ستون](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید 2):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که علامت‌گذاری‌ها در هر فاصلهٔ دسته نگه داشته می‌شوند. تمام ۲۴ ستون، شامل آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده می‌مانند. اسلاید ۳ ظاهر خودکار را که در بالا نشان داده شد بازمی‌گرداند.

![فاصلهٔ دستی برچسب‌های دسته به مقدار سه با نمایش تمام ۲۴ ستون](category-axis-manual.png)

### **انتخاب محور و فاصلهٔ صحیح**

از این فاصلهٔ شمارشی برای محوری متنی استفاده کنید، مانند محور دسته‌ای در یک نمودار ستونی، خطی، مساحتی یا میله‌ای. در نمودار ستونی، این محور افقی است. در نمودار میله‌ای افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را برای [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) اعمال کنید. فاصلهٔ علامت‌گذاری نیز برای محوری سری در نمودارهایی که چنین محوری دارند، اعمال می‌شود.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی محور مقدار استفاده نکنید. در محور مقدار، [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) تفاوت مقادیر را تعیین می‌کند: برای مثال، واحد اصلی `10` علامت‌گذاری‌هایی در 0، 10، 20 و ... تولید می‌کند هنگامی که محور از صفر شروع شود. فاصلهٔ برچسب دسته‌ای `3` به جای مقادیر عددی، موقعیت‌های دسته‌ای را می‌شمارد. نمودارهای پراکندگی و حبابی از محورهای مقدار استفاده می‌کنند نه محور دسته‌ای متنی. برای محور تاریخ، از واحدهای اصلی مبتنی بر زمان و مقیاس‌ها همان‌طور که در [تغییر یک محور دسته‌ای](#change-a-category-axis) توضیح داده شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**

این مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌صورت شماره‌های سریال OLE Automation در اولین ورک‌شیت (اندیس `0`) ذخیره می‌شوند. با استفاده از [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) یک محور تاریخ انتخاب کنید، قالب‌بندی وابسته به منبع را با [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) غیرفعال کنید و `yyyy` را با [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) اختصاص دهید تا برچسب‌های دسته به‌صورت سال‌های چهاررقمی независимо از قالب سلول‌ها نمایش داده شوند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **تنظیم زاویهٔ چرخش برای عنوان محور نمودار**

عنوان محور عمودی را با [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/) فعال کنید، متن عنوان را وارد کنید و با [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) زاویهٔ چرخش را تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی با عنوان محور مقدار را به‌صورت 90 درجه چرخان ذخیره می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **تنظیم موقعیت محور بر روی محور دسته یا مقدار**

از [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) برای کنترل اینکه آیا محور مقدار در بین دسته‌ها یا در علامت‌گذاری‌های دسته محور عبور کند استفاده کنید. این ویژگی برای محورهاِ دسته‌ای اعمال می‌شود. مثال این ویژگی را روی محور دسته‌ای افقی یک نمودار ستونی به `true` تنظیم کرده و نتیجه را ذخیره می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **تنظیم واحد نمایش بر روی محور مقدار نمودار**

با استفاده از [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) برچسب‌های محور مقدار را بدون تغییر داده‌های پایه مقیاس‌بندی کنید. وقتی [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) روی `Millions` تنظیم شود، مقدار 60,000,000 به صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **پیکربندی یک محور مقدار لگاریتمی**

یک محور مقدار لگاریتمی وقتی مفید است که مقادیر مثبت در چندین مرتبهٔ بزرگگی متفاوت باشند. برای مثال، یک سرویس ممکن است 10، 100، 1 000، 10 000 و 100 000 درخواست در پنج دوره دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر به‌هم چسبیده به‌نظر می‌آیند. مقیاس لگاریتمی رشد نسبی آن‌ها را مقایسه‌پذیرتر می‌کند: فواصل برابر نشان‌دهندهٔ نسبت‌های برابر هستند نه اختلاف‌های عددی برابر.

با فراخوانی [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) و مقدار `true` برای محور مقدار و استفاده از [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) پایهٔ دلخواه را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند یک ویژگی جداگانه است.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار از [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) دریافت می‌شود. برای یک نمودار میله‌ای افقی، محور مقدار از [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/) به‌دست می‌آید. نمودارهای پراکندگی و حبابی دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو استفاده کنید. از اعمال مقیاس لگاریتمی بر محور دسته‌ای خودداری کنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10` توان‌های متوالی مانند 10، 100، 1 000 و 10 000 به‌طور مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی می‌کند و در اسلاید دوم محور مقدار لگاریتمی با پایهٔ 10 را فعال می‌نماید. هر دو اسلاید همان داده را حفظ می‌کنند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// اولین اسلاید را خطی نگه دارید و فقط مقیاس محور مقدار کپی را تغییر دهید.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**مقیاس خطی (اسلاید 1):** فواصل عمودی برابر نشان‌دهندهٔ اختلاف برابر در شمارش درخواست‌ها هستند. بزرگ‌ترین مقدار بر نمودار غلبه می‌کند و مقادیر کوچکتر را تشخیص دشوار می‌سازد.

![نمودار خطی در پاورپوینت که پنج شمارش درخواست را روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید 2):** فواصل عمودی برابر نشان‌دهندهٔ نسبت‌های برابر هستند. هر دوره ده برابر دوره قبلی درخواست دارد، بنابراین نقاط روی مقیاس پایهٔ 10 یک خط صعودی مستقیم می‌سازند. برچسب‌های محور همچنان شمارش درخواست‌های اصلی را نشان می‌دهند.

![همان پنج شمارش درخواست در پاورپوینت روی محور مقدار لگاریتمی پایهٔ 10](value-axis-logarithmic.png)

### **مدیریت صفر و مقادیر منفی**

مقیاس لگاریتمی فقط مقادیر مثبت صریح را می‌توانند نمایش دهند. قبل از فعال‌سازی آن داده‌ها را بررسی کنید. اگر صفر یا مقادیر منفی معنایی داشته باشند، مقیاس خطی را حفظ کنید یا به‌صورت جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب باشد، دلیل حذف را توضیح دهید. به‌صورت ساکن آن‌ها را با اعداد مثبت کوچک جایگزین نکنید، چرا که این کار معنای داده را تغییر می‌دهد. هر حداقل یا حداًکثر دستی که برای محور لگاریتمی تنظیم می‌کنید نیز باید مثبت باشد.

## **سوالات متداول**

**چگونه مقدار نقطهٔ عبور یک محور از محور دیگر را تنظیم کنم؟**

از [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) برای انتخاب رفتار عبور استفاده کنید. برای مشخص کردن مقدار عددی عبور، از [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) استفاده کنید. این تنظیمات به شما اجازه می‌دهد نقطهٔ عبور محور را به مبنای مناسب منتقل کنید.

**چگونه می‌توان برچسب‌های تقسیم را نسبت به محور موقعیت‌دهی کرد؟**

از [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) با یک مقدار از [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) استفاده کنید: `Low`، `High`، `NextTo` یا `None`. برای کنترل خود علامت‌گذاری‌ها، از [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) یا [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) استفاده کنید؛ اینها مستقل از موقعیت برچسب هستند.