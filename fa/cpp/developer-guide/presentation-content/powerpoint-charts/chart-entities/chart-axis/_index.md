---
title: سفارشی‌سازی محورها نمودار در ارائه‌ها با استفاده از C++
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
- بزرگ‌ترین مقدار
- کوچک‌ترین مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای C++ برای سفارشی‌سازی محورها نمودار در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه محورهای نمودار را با Aspose.Slides for C++ سفارشی کنید. این مقاله به مقادیر محاسبه‌شده محور، تعویض سطرها و ستون‌های نمودار، قابلیت مشاهده محور، فاصله‌های برچسب دسته و علامت تیک، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌گیری محور، واحدهای نمایش و مقیاس لگاریتمی می‌پردازد.

## **دریافت بیشترین مقادیر در محور عمودی نمودارها**

یک [ارائه](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد کنید و یک نمودار مساحت با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، متد [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) را صدا بزنید تا طرح نمودار به‌روز باشد.

برای محدوده‌های محور، [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) و [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) را بخوانید و برای فواصل علامت‌گذاری، [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) و [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) را. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) و [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) مقیاس‌های زمان‑واحد را ارائه می‌دهند که برای محورهای تاریخ مهم هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

از [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی به یک سری تبدیل می‌شود و هر سری قبلی به یک دسته. این تغییر نحوه گروه‌بندی داده‌ها را اصلاح می‌کند؛ محورهای افقی و عمودی را جابه‌جا نمی‌کند. مثال از [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) برای بایند کردن داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل سطر سرآیند و ستون دسته، قبل از تعویض سطر و ستون استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌کند.

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

از [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) برای معکوس کردن یک محور دسته یا مقدار استفاده کنید. برای مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیب برگشت‌پذیر شیت نشان دهد: برنامه‌ریزی، توسعه، تست. معکوس کردن محور جهت رسم را تغییر می‌دهد؛ داده‌های کتاب کار را سورت یا جابجا نمی‌کند. در مقایسه، [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) نقش سری‌ها و دسته‌ها را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. یک ارائه با سه اسلاید ذخیره می‌شود: ترتیب عادی، دسته‌های معکوس، و مقادیر معکوس. هر نسخه از یک دیتاست یکسان استفاده می‌کند و فقط یک محور در هر نسخه معکوس می‌شود.

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

// Slide 2: display the first category at the top.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Keep the horizontal value axis at the bottom.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Slide 3: reverse only the horizontal numeric scale.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

معکوس کردن محور می‌تواند محور عمود را به سمت طرف مقابل نمودار نیز جابه‌جا کند. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) کنترل می‌کند که محور دیگر کجا محور تنظیم‌شده را قطع می‌کند. در اسلاید ۲، تنظیم آن روی `Maximum` در محور دسته معکوس، محور مقدار افقی را در پایین نگه می‌دارد. برای نقطه قطع خاص، از [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) استفاده کنید. هنگام تغییر جهت، تنظیمات قطع را بررسی کنید، بویژه اگر نمودار از قبل یک نقطه قطع سفارشی دارد. برای بازگرداندن جهت رسم عادی، `set_IsPlotOrderReversed` را با `false` صدا بزنید؛ تنظیمات قطع جداگانه هستند.

| ترتیب عادی (اسلاید ۱) | دسته‌های معکوس (اسلاید ۲) | مقادیر معکوس (اسلاید ۳) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب عادی محور دسته و مقدار](axis-order-normal.png) | ![نمودار میله‌ای افقی با نمایش دسته‌ها از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا حرکت می‌کنند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه، و تست از بالا به پایین نمایش داده می‌شوند. مقادیر و ترتیب سطرهای کتاب‌کار تغییر نکرده‌اند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در صفر سمت راست را قطع می‌کند. |

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

از [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) با مقدار `false` بر روی محور عمودی استفاده کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌کند.

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

از [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) با مقدار `false` بر روی محور افقی استفاده کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌کند.

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

## **نمایش یا مخفی‌سازی خطوط توری نمودار**

از [get_ShowMajorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showmajorgridlines/) و [get_ShowMinorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showminorgridlines/) برای بررسی اینکه کدام خطوط توری توسط یک محور نمایش داده می‌شود استفاده کنید. هر دو ویژگی فقط‑خواندنی هستند. برای نمایش خطوط توری دقیق، از [get_MinorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_minorgridlinesformat/) استفاده کنید و پر رنگ خط را به رنگ ثابت و قابل مشاهده تنظیم کنید. برای مخفی‌سازی آن‌ها، پر رنگ را به [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) تنظیم کنید. از [get_MajorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_majorgridlinesformat/) برای تغییر خطوط توری اصلی به همان روش استفاده کنید. تغییر پر رنگ خطوط توری، قابلیت مشاهده محور و علامت‌های تیک را حفظ می‌کند.

محور عمودی این نمودار ستونی خوشه‌ای در ابتدا فقط خطوط توری اصلی را نشان می‌دهد. مثال خطوط توری دقیق را به رنگ نارنجی نمایش می‌دهد، سپس قبل از ذخیره ارائه دوباره آن‌ها را مخفی می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
auto axis = chart->get_Axes()->get_VerticalAxis();
std::cout << std::boolalpha << "Initial: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

auto minorFill = axis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat();
minorFill->set_FillType(FillType::Solid);
minorFill->get_SolidFillColor()->set_Color(Color::get_DarkOrange());
std::cout << "Enabled: minor=" << axis->get_ShowMinorGridLines() << '\n';

minorFill->set_FillType(FillType::NoFill);
std::cout << "Hidden: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

presentation->Save(u"ChartGridlines.pptx", SaveFormat::Pptx);
```

| خطوط توری دقیق فعال | خطوط توری دقیق مخفی |
| --- | --- |
| ![خطوط توری دقیق نارنجی بین خطوط توری اصلی در محور عمودی](minor-gridlines-enabled.png) | ![نمودار ستونی مشابه که تنها خطوط توری اصلی قابل مشاهده هستند](minor-gridlines-hidden.png) |

## **تغییر محور دسته**

از [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) برای انتخاب یک محور دسته تاریخ یا متن استفاده کنید. این مثال نیاز به `ExistingChart.pptx` دارد، به‌طوری که یک نمودار به‌عنوان اولین شکل در اولین اسلاید باشد و سلول‌های دسته شامل مقادیر عددی تاریخ اکسل باشند. محور افقی را به یک محور تاریخ تغییر می‌دهد. فراخوانی [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) با `false`، [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) با `1` و [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) با ماه‌ها، علامت‌های اصلی را در فواصل یک‑ماهه قرار می‌دهد.

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

### **تشخیص نوع محور دسته از داده**

پس از پر کردن دسته‌ها، [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) را فراخوانی کنید، سپس با [get_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_categoryaxistype/) نوع انتخاب‌شده را بررسی کنید. این روش زمانی مفید است که همان نمودار ممکن است برچسب‌های متنی یا مقادیر عددی تاریخ دریافت کند. متد در زمان فراخوانی نوع را تعیین می‌کند؛ حالت پایداری فعال نمی‌کند که بعداً تغییرات داده را دوباره ارزیابی کند. پس از جایگزینی دسته‌ها، دوباره آن را صدا بزنید.

مثال زیر یک نمودار با دسته‌های متنی ایجاد می‌کند و `Text` چاپ می‌کند. سپس مقادیر سلول‌های دسته را با تاریخ‌ها جایگزین می‌کند و دوباره متد را فراخوانی می‌کند که `Date` چاپ می‌شود. تاریخ‌ها به عنوان مقادیر عددی OLE Automation برگردانده‌شده توسط [System::DateTime::ToOADate](https://reference.aspose.com/slides/cpp/system/datetime/tooadate/) ذخیره می‌شوند، نه به‌عنوان رشته‌های تاریخ. [set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) نحوه نمایش این مقادیر را کنترل می‌کند؛ متن را به تاریخ‌های عددی تبدیل نمی‌کند. برای اطلاعات بیشتر در مورد سلول‌های دسته، به [دفتر کار نمودار](/slides/fa/cpp/chart-workbook/) مراجعه کنید.

از تشخیص خودکار زمانی استفاده کنید که ورودی به‌وضوح شامل دسته‌های متنی یا تاریخ‌های عددی باشد، همان‌طور که در این مثال نشان داده شده است. برای برچسب‌های عددی عادی، دسته‌های ترکیبی یا داده‌های خالی، به‌طور صریح [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_categoryaxistype/) را فراخوانی کنید تا با معنی موردنظر مطابقت داشته باشد. صرفاً مقادیر عددی به تنهایی نشانگر این نیستند که دسته‌ها تاریخ هستند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/date_time.h>
#include <system/console.h>
#include <system/enum.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto seriesName = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());
auto labels = std::array<System::String, 3>{u"First", u"Second", u"Third"};

for (auto i = 0; i < labels.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(labels[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box((i + 1) * 10));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // متن

auto dates = std::array<System::DateTime, 3>{System::DateTime(2026, 1, 1), System::DateTime(2026, 1, 2), System::DateTime(2026, 2, 1)};

for (auto i = 0; i < dates.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0);
    categoryCell->set_Value(System::ObjectExt::Box(dates[i].ToOADate()));
    categoryCell->set_CustomNumberFormat(u"yyyy-mm-dd");
}

axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // تاریخ

presentation->Save(u"AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
```

## **کنترل فواصل برچسب محور دسته**

وقتی یک نمودار تعداد زیادی دسته دارد، می‌توانید تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. ابتدا با [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) مقدار `false` تنظیم کنید، سپس با [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) فاصله دلخواه دسته را مشخص کنید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فاصله | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | دسته 1، دسته 2، دسته 3، … دسته 24 |
| `2` | دسته 1، دسته 3، دسته 5، … دسته 23 |
| `3` | دسته 1، دسته 4، دسته 7، … دسته 22 |

فاصلهٔ `3` هر سومین برچسب را نمایش می‌دهد و دو برچسب بین هر دو برچسب نمایش داده‌شده مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله خودکار بر پایهٔ فضای موجود انتخاب می‌شود؛ لزوماً همه برچسب‌ها را نمایش نمی‌دهد.

علامت‌های تیک کنترل جداگانه‌ای دارند. با [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) مقدار `false` تنظیم کنید و سپس با [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) فاصلهٔ آن‌ها را مشخص کنید. به‌عنوان مثال، `1` یک علامت تیک در هر فاصلهٔ دسته نگه می‌دارد در حالی که برچسب‌ها تنها هر سومین دسته ظاهر می‌شوند. با [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) یک سبک قابل مشاهده تنظیم کنید تا نتیجه را ببینید. بازگرداندن هر کدام از ویژگی‌های فاصلهٔ خودکار به `true` اجازه می‌دهد نمودار دوباره آن فاصله را انتخاب کند.

مثال زیر به‌صورت خودکفا ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید را در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله خودکار، فاصله برچسب دستی با علامت‌های تیک مستقل، و بازگرداندن فاصله خودکار. دو نسخه داده‌های اصلی نمودار را حفظ می‌کنند. هیچ ارائهٔ ورودی لازم نیست. متن برچسب‌های افقی تفاوت چگالی را به‌راحتی نشان می‌دهد.

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

// اسلاید ۲: هر سومین برچسب را نشان دهید، اما برای هر دسته یک علامت تیک نگه دارید.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// اسلاید ۳: اجازه دهید نمودار دوباره هر دو فاصله را انتخاب کند.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**فاصله خودکار (اسلاید ۱):** در این نمایش، هر دومین برچسب دسته نمایش داده می‌شود و بر دو خط می‌پیچد. نتیجه خودکار می‌تواند بسته به اندازه نمودار، قلم‌ها و رندرر متفاوت باشد.

![فاصله خودکار برچسب دسته با تمام ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصله دستی (اسلاید ۲):** هر سومین برچسب بر یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، حتی آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده هستند. اسلاید ۳ ظاهر خودکار نشان‑داده‌شده در بالا را بازمی‌گرداند.

![فاصله برچسب دسته به‌صورت دستی به‌صورت سه‌تایی با تمام ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصله صحیح**

از این فاصله شمارش دسته برای یک محور دسته متنی استفاده کنید، مانند محور دسته یک نمودار ستونی، خطی، مساحتی یا میله‌ای. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته عمودی است، بنابراین این تنظیمات را بر روی [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) اعمال کنید. فاصله علامت‌های تیک همچنین برای محور سری در نمودارهایی که چنین محوری دارند، اعمال می‌شود.

از فاصله برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) اختلاف مقادیر را تعیین می‌کند؛ به‌عنوان مثال، واحد اصلی `10` علامت‌ها را در 0، 10، 20 و غیره وقتی محور از صفر شروع می‌شود، می‌سازد. فاصله برچسب دسته `3` به‌جای آن موقعیت‌های دسته را می‌شمارد، بدون توجه به مقادیر داده‌ای آن‌ها. نمودارهای پراکندگی و حبابی از محورهای مقدار استفاده می‌کنند نه یک محور دسته متنی. برای محور تاریخ، از واحدهای اصلی زمانی و مقیاس‌های زمان‑محور همان‌گونه که در [تغییر محور دسته](#change-a-category-axis) توضیح داده شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان شماره‌های سریال OLE Automation در اولین کاربرگ (شاخص `0`) ذخیره می‌شوند. از [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) برای انتخاب یک محور تاریخ، از [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) برای غیرفعال‌سازی قالب‌بندی پیوندی به منبع، و با [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) مقدار `yyyy` را اختصاص دهید تا برچسب‌های دسته سال‌های چهار رقمی را به‌صورت مستقل از قالب‌بندی سلول نشان دهند.

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

## **تنظیم زاویه چرخش برای عنوان محور نمودار**

عنوان محور عمودی را با [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/) فعال کنید، متن عنوان را ارائه دهید و با [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) زاویهٔ چرخش را تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی با عنوان محور مقدار معکوس 90 درجه ذخیره می‌کند.

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

## **تنظیم موقعیت محور در محور دسته یا مقدار**

از [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) برای کنترل اینکه آیا محور مقدار محور دسته را بین دسته‌ها یا روی علامت‌های تیک دسته قطع می‌کند استفاده کنید. این ویژگی برای محورهای دسته اعمال می‌شود. مثال این ویژگی را روی `true` در محور دسته افقی یک نمودار ستونی تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

## **تنظیم واحد نمایش در محور مقدار نمودار**

از [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) برای مقیاس‌بندی برچسب‌های یک محور مقدار بدون تغییر داده‌های پایه استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) روی `Millions`، مقدار 60,000,000 به‌صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر روی محور عمودی آن اعمال می‌کند.

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

## **پیکربندی محور مقدار لگاریتمی**

یک محور مقدار لگاریتمی وقتی مفید است که مقادیر مثبت در چندین مرتبهٔ توان متفاوت باشند. برای مثال، سرویس ممکن است در طول پنج دوره درخواست‌های 10، 100، 1 000، 10 000 و 100 000 دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر جمع می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فواصل برابر نشانگر نسبت‌های برابر هستند نه اختلاف‌های برابر.

با [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) مقدار `true` را روی محور مقدار تنظیم کنید و با [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) پایه را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند رابطهٔ برازش‑شده در داده‌ها را نشان می‌دهد و ویژگی جداگانه‌ای است.

### **انتخاب محور مقدار و پایه**

در یک نمودار خطی یا ستونی، محور مقدار [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) است. در یک نمودار میله‌ای افقی، محور مقدار [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/) است. نمودارهای پراکندگی و حبابی دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. مقیاس لگاریتمی را بر روی یک محور دسته اعمال نکنید.

پایه پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای بین `2` تا `1000` استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایه `10` توان‌های متوالی مانند 10، 100، 1 000 و 10 000 به‌صورت مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال زیر به‌صورت خودکفا یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی کرده و در اسلاید دوم محور مقدار لگاریتمی پایه‑10 را فعال می‌کند. هر دو اسلاید داده‌های یکسان را حفظ می‌کنند.

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

// اسلاید اول را خطی نگه دارید و فقط مقیاس محور مقدار کپی را تغییر دهید.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**مقیاس خطی (اسلاید ۱):** فاصله‌های عمودی برابر نشانگر اختلاف‌های برابر در تعداد درخواست‌ها هستند. بزرگ‌ترین مقدار بر نمودار غلبه می‌کند و مقادیر کوچکتر را تشخیص دادن سخت می‌شود.

![نمودار خطی در پاورپوینت که پنج تعداد درخواست را بر محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فاصله‌های عمودی برابر نشانگر نسبت‌های برابر هستند. هر دوره ده‌برابر دوره قبلی درخواست دارد، بنابراین نقاط روی مقیاس پایه‑10 یک خط صعودی مستقیم می‌سازند. برچسب‌های محور هنوز تعداد درخواست‌های اصلی را نشان می‌دهند.

![همان پنج تعداد درخواست در پاورپوینت بر محور مقدار لگاریتمی پایه‑۱۰](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

مقیاس لگاریتمی فقط مقادیر مثبت صریح را نمایش می‌دهد. قبل از فعال‌سازی آن داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنی‌دار هستند، از مقیاس خطی استفاده کنید یا آن‌ها را جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلایل حذف را توضیح دهید. به‌صورت ساکت آن‌ها را با عددهای کوچک مثبت جایگزین نکنید، زیرا معنای داده را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی پیکربندی‌شده برای یک محور لگاریتمی نیز باید مثبت باشد.

## **پرسش‌های متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (crossing) را تنظیم کنم؟**  
از [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) برای انتخاب رفتار تقاطع استفاده کنید. برای مشخص کردن یک مقدار عددی تقاطع، از [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) استفاده کنید. این تنظیمات به شما امکان می‌دهد تقاطع محور را به خط پایهٔ مناسب منتقل کنید.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌دهی کنم؟**  
از [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) با مقدار یکی از انواع [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`، `High`، `NextTo` یا `None` استفاده کنید. برای کنترل خود علامت‌های تیک، از [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) یا [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) استفاده کنید؛ این تنظیمات جدا از موقعیت‌بندی برچسب‌ها هستند.