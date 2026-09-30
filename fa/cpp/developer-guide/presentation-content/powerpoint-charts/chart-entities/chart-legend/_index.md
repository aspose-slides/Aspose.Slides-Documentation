---
title: سفارشی‌سازی راهنمای نمودارها در ارائه‌ها با استفاده از C++
linktitle: راهنمای نمودار
type: docs
url: /fa/cpp/chart-legend/
keywords:
- راهنمای نمودار
- موقعیت راهنما
- اندازه فونت
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "راهنمای نمودارها را با Aspose.Slides برای C++ سفارشی کنید تا ارائه‌های PowerPoint را با قالب‌بندی ویژهٔ راهنما بهینه کنید."
---
## **بررسی کلی**

Aspose.Slides for C++ گزینه‌هایی برای سفارشی‌سازی راهنمای نمودارها در ارائه‌های PowerPoint فراهم می‌کند. این مقاله نشان می‌دهد چگونه یک راهنما را موقعیت دهی و اندازه‌گیری کنید، اندازه فونت کل راهنما را تنظیم کنید، یک ورودی تک‌تک راهنما را قالب‌بندی کنید و ورودی‌های انتخابی را پنهان یا بازیابی کنید.

سؤالات متداول شامل رفتارهای مرتبط می‌شود، از جمله اختصاص فضای برای راهنما، نمایش برچسب‌های چند‌خطی، و ارث‌بری قالب‌بندی از تم ارائه.

## **موقعیت‌یابی راهنما**

از متدهای [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/)، [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/)، [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/)، و [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) راهنما استفاده کنید تا موقعیت و اندازه آن را به عنوان کسرهای ابعاد نمودار مشخص کنید.

این مثال یک ارائه ایجاد می‌کند و یک نمودار ستونی خوشه‌ای با داده‌های پیش‌فرض به اولین اسلاید اضافه می‌کند. تقسیم مقادیر افست و ابعاد مورد نظر راهنما بر عرض و ارتفاع نمودار، آن‌ها را به مقادیر نسبی تبدیل می‌کند: راهنما ۵۰ نقطه از گوشهٔ بالا‑چپ نمودار جابه‌جا شده و به اندازهٔ ۱۰۰ × ۱۰۰ نقطه تنظیم می‌شود.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// موقعیت و اندازهٔ راهنما را نسبت به نمودار بیان می‌کند.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **تنظیم اندازه فونت یک راهنما**

از متد [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) راهنما برای دسترسی به قالب‌بندی متن آن استفاده کنید و با [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) اندازه فونت را بر حسب نقطه تنظیم کنید.

این مثال یک نمودار با داده‌های پیش‌فرض ایجاد می‌کند و متن راهنما را به ۲۰ نقطه تنظیم می‌نماید. همچنین محدودیت‌های خودکار برای محور عمودی را غیرفعال کرده و بازهٔ آن را از ‑5 تا ۱۰ تنظیم می‌کند.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **تنظیم اندازه فونت یک ورودی تک‌تک راهنما**

از مجموعه‌ای که متد [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) راهنما برمی‌گرداند استفاده کنید تا قالب‌بندی یک ورودی خاص را دسترسی پیدا کنید. شاخص‌های ورودی صفر‑پایه هستند، بنابراین شاخص `1` به ورودی دوم اشاره دارد.

این مثال یک نمودار ستونی خوشه‌ای ایجاد می‌کند که داده‌های پیش‌فرض حداقل دو سری دارد. ورودی دوم راهنما را با متن بولد، ایتالیک و با رنگ‌آبی ۲۰ نقطه‌ای قالب‌بندی می‌کند.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **پنهان کردن ورودی‌های تک‌تک راهنما**

برای حذف یک سری کمکی از راهنما در حالی که داده‌های آن قابل مشاهده می‌ماند، با `true` از [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) از طریق [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/) فراخوانی کنید. این کار فقط ورودی انتخاب‌شدهٔ راهنما را پنهان می‌کند؛ سری یا نقاط داده‌اش حذف نمی‌شود. در مقابل، فراخوانی [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) با `false` تمام راهنما را مخفی می‌سازد.

مثال زیر یک نمودار ستونی خوشه‌ای با چندین سری با استفاده از داده‌های پیش‌فرض ایجاد می‌کند. ورودی راهنمای سری دوم (شاخص `1`) را پنهان می‌کند و ارائه را ذخیره می‌نماید. سپس با فراخوانی `set_Hide` با `false` ورودی را بازیابی کرده و یک نسخهٔ دوم ذخیره می‌کند. ستون‌ها در هر دو فایل به‌صورت قابل مشاهده باقی می‌مانند.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// ورودی همان را بدون تغییر داده‌های نمودار بازگردانید.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

مقایسهٔ زیر همان نمودار را با تمام ورودی‌های قابل مشاهده و با ورودی دوم پنهان نشان می‌دهد. ستون‌های سری دوم بدون تغییر باقی می‌مانند.

![مقایسهٔ یک نمودار با تمام ورودی‌های راهنما به‌صورت قابل مشاهده و با سری ۲ پنهان شده؛ تمام ستون‌ها همچنان قابل مشاهده‌اند.](hide-legend-entry.png)

در نمودارهای ستونی، میله‌ای و خطی، ورودی‌های راهنما، سری‌ها را شناسایی می‌کنند. برای نمودارهای دایره‌ای، آن‌ها نقاط دادهٔ تک‌تک (برش‌ها) را شناسایی می‌کنند، بنابراین به‌جای آن از [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) برای برش انتخاب‌شده استفاده کنید. API این متد نقطه‌داده را برای انواع نمودار `Pie`، `Pie3D`، `ExplodedPie`، `ExplodedPie3D`، `PieOfPie` و `BarOfPie` مستند کرده است. فرض نکنید که برای نمودارهای دونات نیز اعمال می‌شود، چرا که در آن فهرست گنجانده نشده‌اند.

## **سؤالات متداول**

**آیا می‌توانم نمودار را طوری تنظیم کنم که برای راهنما فضا اختصاص دهد به‌جای اینکه آن را روی نمودار بگذارد؟**

بله. با `false` از متد [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) فراخوانی کنید تا به‌جای اجازهٔ همپوشانی با ناحیهٔ ترسیم، برای راهنما فضا رزرو شود.

**آیا می‌توانم برچسب‌های راهنمای چندخطی داشته باشم؟**

بله. برچسب‌های طولانی زمانی که عرض موجود کافی نباشد، به‌صورت خودکار به‌خط‌های جدید می‌روند. همچنین می‌توانید از کاراکترهای خط جدید در نام‌های سری برای درخواست شکست خط استفاده کنید.

**چگونه می‌توانم راهنما را طوری تنظیم کنم که از طرح رنگی تم ارائه پیروی کند؟**

رنگ‌ها، پرکننده‌ها و فونت‌های راهنما را تنظیم نکنید تا بتواند قالب‌بندی تم را به ارث ببرد. قالب‌بندی صریح، تنظیمات متناظر تم را بازنویسی می‌کند.