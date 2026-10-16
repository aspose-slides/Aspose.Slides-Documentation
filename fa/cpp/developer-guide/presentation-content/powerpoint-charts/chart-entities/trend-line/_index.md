---
title: افزودن خطوط روند به نمودارهای ارائه در C++
linktitle: خط روند
type: docs
url: /fa/cpp/trend-line/
keywords:
- نمودار
- خط روند
- خط روند نمایی
- خط روند خطی
- خط روند لگاریتمی
- خط روند میانگین متحرک
- خط روند چندجمله‌ای
- خط روند توان
- خط روند سفارشی
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "به‌سرعت خطوط روند را در نمودارهای پاورپوینت با Aspose.Slides برای C++ اضافه و سفارشی کنید — راهنمایی عملی برای جذب مخاطبان شما."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه خطوط روند را به نمودارهای ارائه با استفاده از Aspose.Slides اضافه کنیم. نحوه ایجاد یک نمودار، افزودن خطوط روند به سری‌های نمودار و کار با چندین نوع خط روند، از جمله نمایی، خطی، لگاریتمی، میانگین متحرک، چندجمله‌ای و توان، را نشان می‌دهد.

همچنین توضیح می‌دهد چگونه می‌توان یک خط سفارشی به نمودار اضافه کرد با وارد کردن یک شکل خطی، و شامل یک بخش پرسش‌وپاسخ کوتاه درباره مقادیر پیش‌پروجکتیو و بازپروجکتیو خطوط روند و اینکه آیا خطوط روند هنگام خروجی به PDF یا SVG و همچنین هنگام رندر نمودارها به تصویر حفظ می‌شوند یا نه.

## **افزودن خط روند**

از [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) برای افزودن یک خط روند به یک سری نمودار استفاده کنید و نوع آن را با [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/) انتخاب کنید. این مثال یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض ایجاد می‌کند و دو خط روند به هر یک از سه سری آن اضافه می‌کند.

خط روند نمایی معادله و مقدار R‑مربعی خود را از طریق [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) و [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/) مخفی می‌کند، در حالی که خط روند خطی به رنگ قرمز است. خط روند لگاریتمی برای برچسب سفارشی از [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) استفاده می‌کند. میانگین متحرک با استفاده از [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) برای میانگین‌گیری از سه نقطه داده و [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) برای نام سفارشی بهره می‌برد.

خط روند چندجمله‌ای از [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) برای تنظیم درجه به سه استفاده می‌کند و یک دسته به جلو گسترش می‌یابد از طریق [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/). خط روند توان یک دسته به عقب گسترش می‌یابد از طریق [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/).

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **تنظیم برش خط روند**

از [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) برای ثابت کردن مقدار Y خط روند در X = 0 استفاده کنید. این تنظیم برای خطوط روند خطی، نمایی و چندجمله‌ای پشتیبانی می‌شود.

به عنوان مثال، یک مدل هزینه تولید ممکن است نیاز داشته باشد از هزینه‌های ثابت شناخته‌شده ۱۰۰ شروع شود، حتی اگر اندازه‌گیری‌ها در حجم‌های تولید غیرصفر نشان‌دهنده مبنای متفاوتی باشد. برای یک خط روند خطی، ثابت کردن برش معادله `y = ax + b` را به `b = 100` محدود می‌کند؛ شیب بر اساس داده‌ها تحت این محدودیت برازش می‌شود. این به سادگی خطی که قبلاً برازش شده را جابه‌جا نمی‌کند. تنظیمات عبور محور مشخص می‌کند که محورها در کجا به‌هم می‌رسند، نه ضریب‌های خط روند برازش‌شده.

مثال زیر یک نمودار پراکندگی (XY) با حجم‌های تولید از ۱ تا ۴ و هزینه‌های ۱۷۰، ۲۰۰، ۲۳۰ و ۲۶۰ ایجاد می‌کند. نمودار را با برش خودکار پیش‌فرض ذخیره می‌کند، برش را به ۱۰۰ تنظیم می‌کند و یک فایل PPTX دوم ذخیره می‌کند. دو فایل تنها در تنظیم برش متفاوت هستند. خط روند معادله خود را نشان می‌دهد و به X = 0 باز می‌گردد.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

با محاسبه خودکار، این داده‌ها `y = 30x + 140` تولید می‌کند. تنظیم برش به ۱۰۰ به‌جای آن تقریباً `y = 43.33x + 100` ایجاد می‌کند: مقدار برازش‌شده در صفر با مبنای شناخته‌شده تطابق دارد، در حالی که خط دیگر از تمام نقاط داده عبور نمی‌کند.

| برش خودکار | برش ثابت 100 |
| --- | --- |
| ![خط روند خطی با برش به‌صورت خودکار محاسبه‌شده 140](intercept-automatic.png) | ![خط روند خطی با برش ثابت 100](intercept-fixed.png) |

هر دو تصویر از همان داده‌ها و مقیاس محورها استفاده می‌کنند. خطوط روند به X = 0 باز می‌گردند تا برش‌های خود را نشان دهند.

به‌طور پیش‌فرض، این ویژگی شامل `std::numeric_limits<double>::quiet_NaN()` است که نمایانگر برش نامشخص به‌جای صفر است. سپس برش به‌صورت خودکار از داده‌ها محاسبه می‌شود.

## **افزودن خط سفارشی**

یک خط سفارشی شکلی است که بالای نمودار کشیده می‌شود نه خط روندی که از داده‌های سری محاسبه می‌شود. این مثال از [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) برای افزودن یک خط افقی به اسلاید بالای نمودار استفاده می‌کند. موقعیت خط در مختصات اسلاید، به‌واحد نقطه، مشخص می‌شود، بنابراین از لبه چپ نمودار شروع می‌شود و نیمه‌راه پایین نمودار قرار می‌گیرد. عرض آن با عرض نمودار مطابقت دارد. فرمت خطی که توسط [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) برگردانده می‌شود، به خط رنگ قرمز پر می‌دهد.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **FAQ**

**«پیش» و «پس» برای یک خط روند چه معنایی دارند؟**

اینها طول‌های خط روند هستند که به‌صورت پیش‌پروجکتیو/بازپروجکتیو گسترش می‌یابند: برای نمودارهای پراکندگی (XY) — برحسب واحدهای محور؛ برای نمودارهای غیرپراکندگی — برحسب تعداد دسته‌ها. تنها مقادیر غیرمنفی مجاز هستند.

**آیا خط روند هنگام خروجی‌گیری ارائه به PDF یا SVG، یا هنگام رندر یک اسلاید به تصویر حفظ می‌شود؟**

Yes. Aspose.Slides ارائه‌ها را به [PDF](/slides/fa/cpp/convert-powerpoint-to-pdf/) یا [SVG](/slides/fa/cpp/render-a-slide-as-an-svg-image/) تبدیل می‌کند و نمودارها را به تصویر رندر می‌سازد؛ خطوط روند، به‌عنوان بخشی از نمودار، در طول این عملیات حفظ می‌شوند. همچنین روشی برای [export an image of the chart](/slides/fa/cpp/shape-thumbnails/) موجود است.