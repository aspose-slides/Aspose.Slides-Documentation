---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها با C++
linktitle: نمودار دایره‌ای
type: docs
url: /fa/cpp/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های ترسیم
- رنگ برش
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "نمودارهای دایره‌ای را در C++ با Aspose.Slides ایجاد و سفارشی کنید. نمودارهای ثانویه را پیکربندی کنید، برچسب‌های داده را نمایش دهید و رنگ‌های خودکار برش را در PowerPoint اعمال کنید."
---
## **بررسی کلی**

این مقاله نحوه کار با نمودارهای دایره‌ای در Aspose.Slides را توضیح می‌دهد. این مقاله نشان می‌دهد چگونه گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie را تنظیم کنید و چگونه رنگ‌بندی خودکار برش‌ها را برای یک نمودار دایره‌ای استاندارد فعال کنید.

مثال‌ها بر روی وظایف سفارشی‌سازی نمودار متمرکز هستند، از جمله افزودن یک نمودار به اسلاید، تنظیم سری‌ها و برچسب‌ها، جایگزینی داده‌های پیش‌فرض نمودار با دسته‌ها و مقادیر سفارشی، و ذخیره ارائه به‌روز شده.

## **گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie**

Aspose.Slides برای C++ از گزینه‌های نمودار ثانویه برای نمودارهای Pie of Pie و Bar of Pie پشتیبانی می‌کند. این گزینه‌ها اندازه نمودار ثانویه و نحوه تقسیم نقاط داده بین دو نمودار را کنترل می‌کنند.

مثال زیر یک نمودار Pie of Pie را در یک ارائه جدید ایجاد می‌کند و مقادیر نقاط داده را به‌عنوان برچسب نمایش می‌دهد. متد [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) اندازه نمودار ثانویه را روی 149٪ از نمودار اصلی تنظیم می‌کند. متد [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) تقسیم‌بندی مبتنی بر درصد را انتخاب می‌کند و متد [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) آستانه را روی 53٪ تنظیم می‌کند.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

// Display values and configure the secondary plot.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_SecondPieSize(149);
seriesGroup->set_PieSplitBy(PieSplitType::ByPercentage);
seriesGroup->set_PieSplitPosition(53);

presentation->Save(u"pie_of_pie.pptx", SaveFormat::Pptx);
```

### **انتخاب دسته‌ها برای نمودار ثانویه**

از تقسیم‌بندی سفارشی استفاده کنید وقتی می‌خواهید دسته‌های خاصی را در نمودار ثانویه گروه‌بندی کنید بدون در نظر گرفتن مقادیر درصدی آن‌ها. به عنوان مثال، یک گزارش فروش ممکن است Online و Events را با هم نشان دهد تا خوانندگان بتوانند این دو کانال را مقایسه کنند، حتی اگر آن‌ها 35٪ و 10٪ از کل فروش را تشکیل دهند.

متد [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) را با [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) فراخوانی کنید و نقاط را از طریق [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/) انتخاب کنید. متد [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/) این مجموعه یک شاخص صفر‑مبتنی در سری را می‌پذیرد. در این مثال، شاخص 1 Online را انتخاب می‌کند و شاخص 3 Events را. Partners نیز به‌صورت موقت افزوده می‌شود، سپس با استفاده از [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/) حذف می‌شود.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IPieSplitCustomPointCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 200);

// داده‌های پیش‌فرض را با فروش بر اساس کانال‌ها جایگزین کنید.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"Retail", u"Online", u"Partners", u"Events" };
auto values = std::vector<int>{ 40, 35, 15, 10 };
auto seriesNameCell = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_PieSplitBy(PieSplitType::Custom);
seriesGroup->set_IsColorVaried(true);

// Online و Events را بر اساس شاخص‌های صفر-مبتنی آن‌ها در سری انتخاب کنید.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// Partners را از انتخاب حذف کنید بدون حذف داده‌های منبع آن.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Online (35) و Events (10) به‌صورت برش‌های جداگانه در نمودار ثانویه ظاهر می‌شوند. در نمودار اصلی، آن‌ها توسط یک برش ترکیبی با مقدار 45، به‌همراه Retail (40) و Partners (15) نمایش داده می‌شوند. حذف Partners از انتخاب سفارشی باعث می‌شود در نمودار اصلی باقی بماند؛ این عمل دسته یا مقدار آن را از داده‌های منبع نمودار حذف نمی‌کند.

![نمودار Pie of Pie با Online و Events در نمودار ثانویه و مقدار ترکیبی 45 آنها در نمودار اصلی](pie_of_pie_custom.png)

## **تنظیم رنگ خودکار برش‌های نمودار دایره‌ای**

Aspose.Slides برای C++ می‌تواند به‌صورت خودکار رنگ‌های متفاوتی به برش‌های نمودار دایره‌ای اختصاص دهد. مثال زیر یک نمودار دایره‌ای با عنوان مرکزی ایجاد می‌کند و داده‌های پیش‌فرض را با سه دسته فصلی و مقادیرشان جایگزین می‌نماید. متد [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) مقادیر 20، 50 و 30 را به‌عنوان برچسب نمایش می‌دهد، در حالی که [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) رنگ متمایزی برای هر برش فعال می‌کند.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 100, 100, 400, 400);

// عنوان نمودار را به صورت مرکزی اضافه کنید.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// داده‌های پیش‌فرض را با استفاده از اولین صفحه‌کار جایگزین کنید.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"First Qtr", u"2nd Qtr", u"3rd Qtr" };
auto values = std::vector<int>{ 20, 50, 30 };
auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, System::ObjectExt::Box(System::String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

// مقادیر را نشان دهید و رنگ‌های متفاوتی به برش‌ها اختصاص دهید.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **سوالات متداول**

**آیا انواع Pie of Pie و Bar of Pie پشتیبانی می‌شوند؟**

بله، کتابخانه [supports](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) یک نمودار ثانویه برای نمودارهای دایره‌ای، از جمله انواع Pie of Pie و Bar of Pie را ارائه می‌دهد.

**آیا می‌توانم فقط نمودار را به‌عنوان تصویر (مثلاً PNG) استخراج کنم؟**

بله، می‌توانید [export the chart itself as an image](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (مانند PNG) را بدون استخراج کل ارائه انجام دهید.