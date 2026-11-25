---
title: سفارشی‌سازی نمودارهای 3 بعدی در ارائه‌ها با استفاده از C++
linktitle: نمودار 3 بعدی
type: docs
url: /fa/cpp/3d-chart/
keywords:
- نمودار 3 بعدی
- چرخش
- عمق
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نمودارهای 3 بعدی را در ارائه‌های PowerPoint با Aspose.Slides برای C++ ایجاد کنید. چرخش، نسبت‌های ارتفاع، عمق نمودار و فاصله بین سری‌ها را با مثال‌های C++ تنظیم کنید."
---
## **نمای کلی**

Aspose.Slides for C++ به شما امکان می‌دهد نمای یک نمودار 3 بعدی را از طریق [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/) تنظیم کنید. این مقاله نشان می‌دهد چگونه چرخش، نسبت‌های ارتفاع، عمق، محورهای زاویه‌دار راست و فاصله بین سری‌ها را تنظیم کرده و سپس ارائه را در فرمت PPTX ذخیره کنید.

## **تنظیم چرخش و عمق یک نمودار 3 بعدی**

مثال زیر یک [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ایجاد می‌کند و با استفاده از [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) یک نمودار ستونی 3 بعدی انباشته را به اسلاید اول اضافه می‌نماید. این مثال سری‌ها و دسته‌های پیش‌فرض را با دو سری حاوی هر کدام سه مقدار جایگزین می‌کند. شاخص کاربرگ `0` کاربرگ دادهٔ اول نمودار را نشان می‌دهد؛ ردیف `0` نام سری‌ها و ستون `0` برچسب‌های دسته را نگه می‌دارد.

متدهای [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) و [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) به ترتیب چرخش نمودار را به 40 و 270 درجه تنظیم می‌کنند. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) عمق آن را به 150٪ از عرض تنظیم می‌نماید، در حالی که [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) محورهای زاویه‌دار راست را به جای پرسپکتیو فعال می‌کند. ارائهٔ حاصل شامل نمودار پر شده با این تنظیمات نمای 3 بعدی است.

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

## **اعمال پر کردن تصویر به سطح یک نمودار 3 بعدی**

می‌توانید [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/)، [back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/) و [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) یک نمودار 3 بعدی را به‌صورت مستقل پر کنید. نوع پر کردن سطح را با استفاده از [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) به `Picture` تنظیم کنید و یک تصویر اختصاص دهید. برای اینکه یک کپی تصویر بر سطح کشیده شود، هر دو [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) و [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) سطح را به `Stretch` تنظیم کنید.

فایل [arrow.png](arrow.png) را در پوشه کاری ذخیره کنید. مثال چرخش نمودار را انجام می‌دهد و حداکثر مقدار محور عمودی را افزایش می‌دهد تا کف بین ستون‌ها قابل مشاهده باشد. سپس اسلاید را دو بار کپی می‌کند و پیکان را بر سطح متفاوتی در هر اسلاید اعمال می‌نماید. هر سه نمودار داده، زاویهٔ نمایش و پس‌زمینهٔ یکسانی دارند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Microsoft PowerPoint سه اسلاید را به‌صورت زیر نمایش می‌دهد.

| دیوار جانبی | دیوار پشت | کف |
| --- | --- | --- |
| ![پیکان نشان‌گر به سمت داخل نمودار در طول دیوار جانبی](side-wall.png) | ![پیکان به سمت راست در طول دیوار پشت](back-wall.png) | ![پیکان به سمت راست در طول کف بین ستون‌ها](floor.png) |

## **تنظیم نسبت‌های ارتفاع یک نمودار 3 بعدی**

از [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) برای تنظیم ارتفاع یک نمودار 3 بعدی به‌عنوان درصدی از عرض آن استفاده کنید. این کار نسبت‌های صحنهٔ 3 بعدی را بدون تغییر اندازهٔ شیء نمودار در اسلاید تغییر می‌دهد.

مثال زیر یک نمودار [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) با دادهٔ پیش‌فرض ایجاد می‌کند: سه سری و چهار دسته. سپس سه ارائه با نسبت‌های ارتفاع 50٪، 100٪ و 200٪ ذخیره می‌کند. موقعیت، عرض و ارتفاع نمودار ثابت می‌مانند. داده، چرخش، عمق، فاصلهٔ بین سری‌ها و قالب‌بندی در همهٔ سه فایل یکسان است؛ تنها درصد ارتفاع تغییر می‌کند.

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

تصاویر زیر از مثال معادل .NET استخراج شده‌اند و با استفاده از Microsoft PowerPoint صادر شده‌اند تا همان تنظیمات ارتفاع را نشان دهند. درصد کمتر صحنهٔ صاف‌تری ایجاد می‌کند، در حالی که درصد بزرگ‌تر صحنهٔ بلندتری درون همان شیء نمودار می‌سازد. PowerPoint ممکن است فاصلهٔ تیک‌های محور و جای‌گذاری برچسب‌ها را برای متناسب شدن با صحنه تنظیم کند.

| ارتفاع: 50% | ارتفاع: 100% | ارتفاع: 200% |
| --- | --- | --- |
| ![نمودار ستونی 3 بعدی با ارتفاع 50 درصد از عرض آن](height_percent_50.png) | ![نمودار ستونی 3 بعدی با ارتفاع 100 درصد از عرض آن](height_percent_100.png) | ![نمودار ستونی 3 بعدی با ارتفاع 200 درصد از عرض آن](height_percent_200.png) |

این متدها جنبه‌های مختلف نمودار را کنترل می‌کنند:

| متد | تأثیر |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | ارتفاع صحنهٔ 3 بعدی به‌عنوان درصدی از عرض آن. |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | ارتفاع شیء نمودار در اسلاید، به پوینت. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | عمق صحنهٔ 3 بعدی به‌عنوان درصدی از عرض آن. |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | فاصله بین سری‌ها در امتداد محور عمق، به‌عنوان درصدی از عرض مارکر. |

تنظیم ارتفاع بر نمودارهای ستونی و میله‌ای 3 بعدی، شامل انواع سیلندری، مخروطی و هرم‌دار، و همچنین نمودارهای خطی، مساحی، دایره‌ای و سطحی 3 بعدی تأثیر می‌گذارد. مقایسهٔ بالا از نوع تأیید شدهٔ `Column3D` استفاده می‌کند. این تنظیم شکل نمودار 2 بعدی `ClusteredColumn` یا `BubbleWith3D` را تغییر نمی‌دهد؛ این نام‌ها عضو [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) هستند. برای سایر تنظیمات ظاهر نمودار، به [Chart Formatting](/slides/fa/cpp/chart-formatting/) مراجعه کنید.

## **تنظیم فاصله بین سری‌ها**

از [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) برای کنترل فاصلهٔ بین سری‌های داده در امتداد محور عمق یک نمودار 3 بعدی استفاده کنید؛ مقدار به‌صورت درصدی از عرض مارکر بیان می‌شود. مقادیر از **0 تا 500** شامل می‌شود: `0` فاصله را حذف می‌کند، در حالی که مقادیر بزرگ‌تر فواصل را افزیش می‌دهند. با عمق ثابت نمودار، افزایش فاصله باعث باریک‌تر شدن مارکرها در امتداد محور عمق می‌شود.

به گروه از طریق [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) دسترسی پیدا کنید. این تنظیم برای تمام سری‌های موجود در آن گروه اعمال می‌شود، نه فقط سری‌ای که برای دسترسی استفاده شده است. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) مقدار تنظیم گروه والد را برمی‌گرداند.

این تنظیم بر نمودارهای ستونی و میله‌ای 3 بعدی، شامل انواع سیلندری، مخروطی و هرم‌دار، و همچنین نمودارهای خطی و مساحی 3 بعدی تأثیر می‌گذارد. ظاهر بستگی به این دارد که سری‌ها در عمق، خوشه‌ای یا انباشته‌ شده باشند. برای مقایسهٔ واضح فاصله‌ها بین سری‌های جداگانه، از `ChartType::Column3D` موجود در شمارش [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) استفاده کنید.

این متدها جنبه‌های مختلف نمودار را کنترل می‌کنند:

| متد | تأثیر |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | فاصله بین سری‌ها در امتداد محور عمق، به‌عنوان درصدی از عرض مارکر. |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | فاصله بین خوشه‌های میله یا ستون مجاور، به‌عنوان درصدی از عرض میله یا ستون. |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | عمق کلی نمودار، به‌عنوان درصدی از عرض نمودار. |

مثال زیر به‌صورت مستقل از پیش‌فرض داده‌ها استفاده می‌کند که شامل سه سری و چهار دسته است. سپس دو ارائه با داده، چرخش، عرض فاصله و عمق نمودار یکسان ذخیره می‌کند؛ تنها عمق فاصله تغییر می‌کند.

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

تصاویر زیر از مثال معادل .NET استخراج شده‌اند و تنظیمات یکسان عمق فاصله را نشان می‌دهند.

| عمق فاصله: 0% | عمق فاصله: 500% |
| --- | --- |
| ![نمودار ستونی 3 بعدی بدون فاصله بین سری‌ها در امتداد محور عمق](gap_depth_0.png) | ![نمودار ستونی 3 بعدی با فاصلهٔ 500 درصدی بین سری‌ها در امتداد محور عمق](gap_depth_500.png) |

## **تغییر نوع سری 3D و شکل میله**

در یک نمودار سیلندری خوشه‌ای، سری اول با میله‌های سیلندری آغاز می‌شود. مثال مقدارهای [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) و [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) را پیش و پس از هر تغییر می‌خواند.

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

| تغییر به سری اول | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| ایجاد نمودار | `ClusteredCylinder` | `Cylinder` |
| فراخوانی [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) با `ClusteredCone` | `ClusteredCone` | `Cone` |
| فراخوانی [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) با `Box` | `ClusteredColumn3D` | `Box` |

تنظیم شکل به `Box` همچنین نوع سری را به `ClusteredColumn3D` تغییر می‌دهد. اگر کد شما بر اساس نوع سری شاخه‌بندی می‌کند، پس از تغییر شکل باید `series->get_Type()` را فراخوانی کنید. مقدار ذخیره‌شده قبل از تغییر هنوز شاخهٔ `ClusteredCone` را انتخاب می‌کند.

![مقایسهٔ PowerPoint نشان‌دهندهٔ سری اول به‌صورت سیلندری، مخروطی و ستون‌های مستطیلی از چپ به راست](series-shapes.png)

## **پرسش‌های متداول**

**کدام انواع نمودارها حالت 3D را در Aspose.Slides پشتیبانی می‌کنند؟**

Aspose.Slides انواع 3D نمودارهای ستونی را پشتیبانی می‌کند، شامل Column 3D، Clustered Column 3D، Stacked Column 3D و 100 % Stacked Column 3D، به‌همراه انواع 3D مرتبط که از طریق شمارش [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) در دسترس هستند. برای دریافت فهرست دقیق و به‌روز، اعضای [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) را در مرجع API نسخهٔ نصب‌شده‌تان بررسی کنید.

**آیا می‌توانم تصویر رستر از یک نمودار 3D برای گزارش یا وب دریافت کنم؟**

بله. می‌توانید نمودار را با استفاده از [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) به تصویر صادر کنید یا کل اسلاید را به فرمت‌هایی مانند PNG یا JPEG رندر کنید (به‌عنوان مثال در [convert PowerPoint to PNG](/slides/fa/cpp/convert-powerpoint-to-png/)). این کار برای پیش‌نمایش رستر یا جاسازی نمودار در اسناد، داشبوردها یا صفحات وب بدون نیاز به PowerPoint مفید است.

**عملکرد ساخت و رندر نمودارهای بزرگ 3D چقدر است؟**

عملکرد به حجم داده و پیچیدگی بصری بستگی دارد. برای بهترین نتایج، اثرات 3D را حداقل نگه دارید، از بافت‌های سنگین بر روی دیوارها و نواحی نمودار پرهیز کنید، تعداد نقاط داده در هر سری را در صورت امکان محدود کنید و خروجی را با وضوح و ابعاد مناسب برای نمایش یا چاپ هدف تنظیم کنید.