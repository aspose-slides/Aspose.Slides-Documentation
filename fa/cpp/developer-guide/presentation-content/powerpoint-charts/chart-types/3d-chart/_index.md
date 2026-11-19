---
title: سفارشی‌سازی نمودارهای 3D در ارائه‌ها با استفاده از C++
linktitle: نمودار 3D
type: docs
url: /fa/cpp/3d-chart/
keywords:
- نمودار 3D
- چرخش
- عمق
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نمودارهای 3D را در ارائه‌های PowerPoint با Aspose.Slides برای C++ ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با نمونه‌های C++ تنظیم کنید."
---
## **بررسی کلی**

Aspose.Slides for C++ به شما امکان می‌دهد نمای یک نمودار 3D را از طریق [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/) سفارشی کنید. این مقاله نشان می‌دهد چگونه چرخش، نسبت‌های ارتفاع، عمق، محورها با زاویهٔ راست و فاصله بین سری‌ها را تنظیم کنید و سپس ارائه را در قالب PPTX ذخیره کنید.

## **تنظیم چرخش و عمق یک نمودار 3D**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد می‌کند و از [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) برای افزودن یک نمودار ستونی 3D پشته‌ای به اسلاید اول استفاده می‌کند. این مثال سری‌ها و دسته‌های پیش‌فرض را با دو سری حاوی هر سه مقدار جایگزین می‌کند. اندیس کاربرگ `0` کاربرگ دادهٔ اول نمودار را شناسایی می‌کند؛ ردیف `0` نام‌های سری‌ها و ستون `0` برچسب‌های دسته‌ها را دارد.

متدهای [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) و [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) به ترتیب چرخش نمودار را به 40 و 270 درجه تنظیم می‌‌کنند. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) عمق آن را به 150٪ از عرضش تنظیم می‌کند، در حالی که [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) محورهای زاویهٔ راست را به جای پرسپکتیو فعال می‌سازد. ارائهٔ حاصل شامل نمودار پر شده با این تنظیمات نمای 3D است.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تنظیم نسبت‌های ارتفاع یک نمودار 3D**

از [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) برای تنظیم ارتفاع یک نمودار 3D به عنوان درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنهٔ 3D را بدون تغییر اندازهٔ شیء نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) با دادهٔ پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته. این مثال سه ارائه با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده‌ها، چرخش، عمق، فاصلهٔ سری‌ها و قالب‌بندی در هر سه فایل یکسان هستند؛ تنها درصد ارتفاع تغییر می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

تصاویر زیر از مثال معادل .NET با استفاده از Microsoft PowerPoint استخراج شده‌اند و همان تنظیمات ارتفاع را نشان می‌دهند. درصد کمتر صحنه‌ای صاف‌تر و درصد بیشتر صحنه‌ای بلندتر داخل همان شیء نمودار تولید می‌کند. PowerPoint ممکن است بازهٔ تیک‌های محور و موقعیت برچسب‌ها را برای متناسب شدن با صحنه تنظیم کند.

| ارتفاع: 50% | ارتفاع: 100% | ارتفاع: 200% |
| --- | --- | --- |
| ![نمودار ستونی 3D با ارتفاع تنظیم شده بر 50 درصد از عرض آن](height_percent_50.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده بر 100 درصد از عرض آن](height_percent_100.png) | ![نمودار ستونی 3D با ارتفاع تنظیم شده بر 200 درصد از عرض آن](height_percent_200.png) |

این متدها جنبه‌های مختلف نمودار را کنترل می‌کنند:

| متد | تاثیر |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | ارتفاع صحنهٔ 3D به عنوان درصدی از عرض آن. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | ارتفاع شیء نمودار در اسلاید، بر حسب پوینت. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | عمق صحنهٔ 3D به عنوان درصدی از عرض آن. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | فاصله بین سری‌ها در راستای محور عمق، به عنوان درصدی از عرض نشانگر. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3D، شامل انواع استوانه‌ای، مخروطی و هرم‌مانند، و همچنین نمودارهای خطی، مساحی، دایره‌ای و سطحی 3D تأثیر می‌گذارد. مقایسهٔ بالا از نوع تأیید شده `Column3D` استفاده می‌کند. این تنظیم ظاهر نمودار `ClusteredColumn` دو‌بعدی یا `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها اعضای شمارش‌گر [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) هستند. برای سایر تنظیمات ظاهر نمودار، به [Chart Formatting](/slides/fa/cpp/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) برای کنترل فاصلهٔ بین سری‌های داده در راستای محور عمق یک نمودار 3D استفاده کنید؛ مقدار به عنوان درصدی از عرض نشانگر بیان می‌شود. از مقادیر **0 تا 500** استفاده کنید؛ `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگ‌تر فاصله را افزایش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث باریک‌تر شدن نشانگرها در راستای محور عمق می‌شود.

به گروه از طریق [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) دسترسی پیدا کنید. این تنظیم برای تمام سری‌های آن گروه اعمال می‌شود، نه فقط سری‌ای که برای دسترسی به آن استفاده شده است. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) مقدار تنظیم گروه والد را بر می‌گرداند.

این تنظیم بر نمودارهای ستونی و میله‌ای 3D، شامل انواع استوانه‌ای، مخروطی و هرم‌مانند، و همچنین نمودارهای خطی و مساحی 3D تأثیر می‌گذارد. ظاهر بستگی به این دارد که سری‌ها به صورت عمقی، خوشه‌ای یا پشته‌ای مرتب شده باشند. برای مقایسهٔ واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType::Column3D` موجود در شمارش‌گر [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) استفاده کنید.

این متدها جنبه‌های مختلف نمودار را کنترل می‌کنند:

| متد | تاثیر |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | فاصله بین سری‌ها در راستای محور عمق، به عنوان درصدی از عرض نشانگر. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | فاصله بین خوشه‌های میله یا ستون مجاور، به عنوان درصدی از عرض میله یا ستون. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | عمق کلی نمودار، به عنوان درصدی از عرض نمودار. |

مثال زیر کاملاً مستقل است و از داده‌های پیش‌فرض نمودار استفاده می‌کند که شامل سه سری و چهار دسته است. این مثال دو ارائه با داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ فقط عمق فاصله تغییر می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

تصاویر زیر از مثال معادل .NET استخراج شده‌اند و همان تنظیمات عمق فاصله را نشان می‌دهند.

| عمق فاصله: 0% | عمق فاصله: 500% |
| --- | --- |
| ![نمودار ستونی 3D بدون فاصله بین سری‌ها در راستای محور عمق](gap_depth_0.png) | ![نمودار ستونی 3D با فاصلهٔ 500 درصدی بین سری‌ها در راستای محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار سیلندری خوشه‌ای، سری اول با میله‌های استوانه‌ای شروع می‌شود. مثال قبل و بعد از هر تغییر، مقادیر [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) و [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) را می‌خواند.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| تغییر در سری اول | get_Type | get_Bar3DShape |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| فراخوانی [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) با `ClusteredCone` | `ClusteredCone` | `Cone` |
| فراخوانی [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) با `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌برداری می‌کند، پس از تغییر شکل حتماً `series->get_Type()` را فراخوانی کنید. مقداری که قبل از تغییر کشیده شده باشد همچنان شاخهٔ `ClusteredCone` را انتخاب خواهد کرد.

![مقایسه PowerPoint که سری اول را به ترتیب به صورت سیلندر، مخروط و ستون‌های مستطیلی از چپ به راست نشان می‌دهد](series-shapes.png)

## **سؤالات متداول**

**کدام نوع نمودارها حالت 3D را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، از جمله Column 3D، Clustered Column 3D، Stacked Column 3D و 100% Stacked Column 3D، به همراه انواع 3D مرتبط که از طریق شمارش‌گر [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) را در مرجع API نسخهٔ نصب‌شده‌تان بررسی کنید.

**آیا می‌توانم تصویر راستر از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید یک نمودار را با استفاده از [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) به تصویر تبدیل کنید یا کل اسلاید را با [render the entire slide](/slides/fa/cpp/convert-powerpoint-to-png/) به فرمت‌هایی مانند PNG یا JPEG رندر کنید. این کار برای پیش‌نمایش راستر یا درج نمودار در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint مفید است.

**کارایی ساخت و رندر نمودارهای بزرگ 3D چقدر است؟**

کارایی به حجم داده و پیچیدگی بصری بستگی دارد. برای بهترین نتایج، اثرات 3D را به حداقل برسانید، از تکسچرهای سنگین بر روی دیوارها و نواحی رسم‌دار خودداری کنید، در صورت امکان تعداد نقاط داده در هر سری را محدود کنید و به اندازهٔ خروجی مناسب (رزولوشن و ابعاد) برای نمایش یا چاپ هدف رندر کنید.