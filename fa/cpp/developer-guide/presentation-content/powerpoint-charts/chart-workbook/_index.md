---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از C++
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/cpp/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- کاربرگ
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های ورک‌شیت دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر یک کتاب‌کار خارجی پیوست‌شده به نمودار دریافت شود و داده‌های نمودار هنگام در دسترس بودن کتاب‌کار ویرایش شود.

برای سلول‌های کتاب‌کاری که داده‌های گمشده را نشان می‌دهند، به [کنترل نمایش سلول‌های خالی](/slides/fa/cpp/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسه‌ای خطی از حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) برای کنترل این‌که آیا یک نمودار فقط داده‌های سلول‌های قابل مشاهده را رسم می‌کند یا نه، استفاده کنید. مقدار `true` فقط سلول‌های قابل مشاهده را رسم می‌کند، در حالی که `false` هر دو سلول قابل مشاهده و مخفی را شامل می‌شود. این تنظیم تنها روی رسم نمودار تأثیر می‌گذارد؛ ردیف‌ها یا ستون‌های ورک‌شیت را مخفی یا نمایش نمی‌دهد.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی است که به‌عنوان اولین شکل در اولین اسلاید قرار دارد. ورک‌شیت جاسازی‌شده، `Sheet1`، بازه منبع `A1:C4` را دارد. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها همچنان مقادیر دارند.

| سطر ورک‌شیت | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (سطر مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی پیدا کنید و با خواندن [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) وضعیت مخفی بودن آن‌ها را بررسی کنید. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 به ردیف مخفی تعلق دارد و C2 به ستون مخفی؛ مثال به ترتیب `False`، `True` و `True` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه سازی کنید: کتاب‌کار جاسازی‌شده را با [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) حفظ کنید و با [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، همچنین از [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) برای بازگرداندن بازه کامل، شامل دسته‌بندی مخفی فوریه استفاده کنید. تنها تغییر پرچم کافی نیست تا داده‌های کش‌شده نمودار و برچسب‌های دسته‌بندی این نمونه تازه سازی شود.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // داده‌های نمودار را از کتاب‌کار جاسازی‌شده تازه سازی کنید.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // بازه منبع کامل را بازگردانید، از جمله دسته‌های مخفی.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر دو حالت رسم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| تنها سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![تنها سلول‌های قابل مشاهده: مقادیر خرده‌فروشی 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقادیر خرده‌فروشی و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار متفاوت از یک سلول خالی است. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا حذف داده‌های منبع مخفی نمی‌شود. برای مثال نگاه کنید به [کنترل نمایش سلول‌های خالی](/slides/fa/cpp/chart-series/#control-the-display-of-empty-cells).

## **دریافت بازه داده‌های نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائه موجود، بازه‌های منبع را بررسی کنید تا متوجه شوید هر نمودار از چه سلول‌های ورک‌شیتی استفاده می‌کند. روش [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) بازه داده فعلی را به‌صورت یک فرمول شناسایی‌شده توسط ورک‌شیت برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام ورک‌شیت است، `!` آن را از بازه سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را به‌صورت شامل می‌کند. علامت دلار نشان‌دهنده مراجع مطلق ردیف و ستون است.

این روش بازه جاری را می‌خواند بدون اینکه نمودار یا کتاب‌کار آن را تغییر دهد. اگر نمودار از کتاب‌کاری به‌عنوان منبع داده استفاده نمی‌کند، استثنای [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) صادر می‌شود. برای اطلاعات بیشتر، به [مرجع API ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌های هر اسلاید را مستقیماً برای یافتن نمودارها بررسی می‌کند. نام هر نمودار و بازه منبع آن را چاپ می‌کند. اگر یک نمودار از کتاب‌کار استفاده نکند، پیام مناسب چاپ می‌شود و ادامه می‌یابد.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides برای C++ روش‌های [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما اجازه می‌دهد کتاب‌کارهای داده نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شیوه سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال یک ارائه با یک نمودار به‌عنوان اولین شکل در اولین اسلاید استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌بندی‌های موجود را پاک می‌کند و همان کتاب‌کار را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **اعتبارسنجی چیدمان نمودار پس از اصلاح کتاب‌کار**

هنگامی که کتاب‌کار جاسازی‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) با خطای «index‑out‑of‑range» شکست بخورد. قبل از نوشتن کتاب‌کار به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌بندی‌های موجود را پاک کنید. این مثال از یک نمودار استفاده می‌کند که اولین شکل در اولین اسلاید است. نظرات نشان می‌دهند که ویرایش کتاب‌کار در کجا رخ می‌دهد؛ مثال اجرایی کتاب‌کار اصلی را باز می‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // جریان کتاب‌کار را اینجا تغییر دهید، به عنوان مثال با Aspose.Cells.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

پاک سازی مجموعه‌ها قبل از نوشتن کتاب‌کار، ارجاعات داده‌های منقضی‌شده را حذف می‌کند. قبل از استفاده از نمودار، هر سری و نگاشت دسته‌بندی مورد نیاز برای کتاب‌کار به‌روز شده را بازسازی کنید.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) برای کنترل نحوه نمایش مقادیر عددی در کتاب‌کار جاسازی‌شده یک نمودار استفاده کنید. برای مثال، ممکن است گزارشی نیاز به نرخ تبدیل به‌صورت درصد با چهار رقم اعشار و یک ضریب با پنج رقم اعشار داشته باشد. هر دو مقدار را به صورت عددی نگه دارید تا برای محاسبات و رسم نمودار در دسترس باشند.

یک قالب عددی فقط نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` مقدار `0.125` را به‌صورت `12.5000%` نشان می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` است. به‌طور مشابه، `0.00000` عدد `0.1234567` را به‌صورت `0.12346` نمایش می‌دهد بدون اینکه مقدار ذخیره‌شده را گرد کند. اگر قالب سفارشی یک رشته خالی (`""`) باشد، قالبی که از طریق [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) اختصاص داده شده است، مورد استفاده قرار می‌گیرد.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی می‌یابد. در ورک‌شیت ۰، B2 نرخ تبدیل و C2 ضریب را دارد. هر دو سلول مقدارهای نمودار را تأمین می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع متصل هستند، فعال می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

قالب‌های سلول کتاب‌کار متفاوت از قالب‌های تنظیم‌شده مستقیماً بر محورهای نمودار یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نشان می‌دهد چون [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) با `true` فراخوانی شده و به قالب عددی منبع پیوند دارد چون [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) نیز با `true` صدا زده شده. پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در تصویر زیر دیده می‌شود. محور عمودی از قالب اختصاصی `0.00` استفاده می‌کند که از طریق [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) تنظیم شده و [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) با `false` فراخوانی شده است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع را `false` تنظیم کنید و قالب آن را از طریق [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. برای مثال، قالب مستقل برچسب `0.00` مقدار اول را به‌صورت `0.13` نشان می‌دهد، در حالی که B2 همچنان `12.5000%` را نمایش می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [برچسب‌های داده نمودار](/slides/fa/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر از ارائه ذخیره‌شده پس از بازگشایی رندر شده است:

![نمودار ستونی با برچسب‌های منبع‌پیوندی نشان‌دهنده 12.5000% و 0.12346 و محور عددی با قالب مستقل.](custom-cell-formats.png)

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب داده نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اولین اسلاید یک ارائه موجود اضافه می‌کند. از سلول‌های A10:A12 در ورک‌شیت ۰ برای سه برچسب اول در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌سازد و ارائه به‌روزرسانی‌شده را ذخیره می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **مدیریت ورک‌شیت‌ها**

روش [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) دسترسی به ورک‌شیت‌های یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر ورک‌شیت را در کنسول چاپ می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **مشخص کردن نوع منبع داده**

مقادیر نقاط سری می‌توانند مستقیم به‌صورت literals عددی ذخیره شوند. برای مثال کامل به [تنظیم مقادیر سری با استفاده از literals عددی](/slides/fa/cpp/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای جدا از پیکربندی کتاب‌کار داخلی یا خارجی نمودار است؛ استفاده از literals عددی به‌تنهایی کتاب‌کار جاسازی‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی ۳‌بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. اسم اول از یک literal رشته‌ای استفاده می‌کند؛ اسم دوم از سلول C1 در ورک‌شیت ۰ استفاده می‌کند. شمارش [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزرسانی‌شده ذخیره می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **شناسایی قالب‌های کتاب‌کار جاسازی‌شده پشتیبانی‌نشده**

Aspose.Slides قالب کتاب‌کار باینری اکسل (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از روش [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) روی [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) قالب‌های نام پشتیبانی‌شده را شناسایی و آن‌ نمودارها را نادیده بگیرید. این مثال شکل‌های اولین اسلاید یک ارائه موجود را بررسی می‌کند، اشکال غیرنموداری را نادیده می‌گیرد و برای هر نموداری که کتاب‌کار .xlsb جاسازی‌شده دارد، پیام تشخیصی چاپ می‌کند.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // داده‌های کتاب‌کار پشتیبانی‌شده نمودار را اینجا بخوانید یا تغییر دهید.
}
```

## **کتاب‌کار خارجی**

Aspose.Slides استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها را پشتیبانی می‌کند.

### **ایجاد کتاب‌کار خارجی**

از [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) برای استخراج کتاب‌کار نمودار جاسازی‌شده به یک فایل و پیوست نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را استخراج می‌کند. قبل از اختصاص کتاب‌کار خارجی به‌عنوان منبع داده نمودار، جریان خروجی را بسته و سپس ارائه پیوست‌شده را ذخیره می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);

presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **تنظیم کتاب‌کار خارجی**

با استفاده از روش [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع داده اختصاص دهید. این روش می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی‌که جابه‌جا شده باشد) نیز به‌کار رود.

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های راه دور یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که ورک‌شیت با نام `Sheet1` شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوست می‌کند و با استفاده از [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) بازه A1:B4 را به یک سری و سه دسته‌بندی نگاشت می‌دهد. سپس ارائه با نمودار پیوست‌شده را ذخیره می‌کند.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

پارامتر `updateChartData` روش [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) کنترل می‌کند آیا کتاب‌کار بارگیری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. داده‌های نمودار بارگیری یا به‌روزرسانی نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

مثال زیر یک URL placeholder را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگیری کتاب‌کار در دسترس نیست ذخیره می‌شود.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار پیوست است، بررسی کنید که آیا نمودار از منبع داده خارجی استفاده می‌کند و مسیر کتاب‌کار آن را دریافت کنید.

این مثال اولین شکل در اولین اسلاید یک ارائه با کتاب‌کار خارجی پیوست‌شده را بررسی می‌کند. اگر شکل یک نمودار پیوست به کتاب‌کار خارجی باشد، مثال [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک نسخه از ارائه را ذخیره می‌کند.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌طور که داده‌های کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. وقتی یک کتاب‌کار خارجی قابل بارگیری نباشد، استثنایی صادر می‌شود.

این مثال از یک نمودار استفاده می‌کند که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی قابل دسترسی پیوست شده است. مقدار پشتیبانی‌شده از سلول برای اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائه به‌روزرسانی‌شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست‌شده را به‌روز کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که مفقود یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) ایجاد کنید، آن را با [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه، [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) را با مقدار `true` تنظیم کنید.

مثال C++ زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی در دسترس نیست، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) و [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی پیدا می‌کند:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // داده‌های کتاب‌کار بازیابی‌شده را اینجا بخوانید یا تغییر دهید.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) صادر می‌کند. فقط زمانی بازیابی را فعال کنید که استفاده از داده‌های کش‌شده نمودار یک گزینه قابل قبول باشد، زیرا کش ممکن است شامل تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا جاسازی‌شده پیوست است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع شبکه/به‌اشتراک‌گذاری شده‌اند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبان‌دار توسط سلول می‌تواند فایل XLSX محلی پیوست‌شده را نیز به‌روز کند. اگر کتاب‌کار اصلی باید بدون تغییر بماند، از یک کپی استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام پیوست کردن رمز عبور را قبول نمی‌کند. یک روش معمول این است که پیش‌از‌هم حفاظت را حذف کنید یا یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) تهیه کنید و به آن پیوست کنید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگیری داده‌ها در تمام نمودارها منعکس می‌شود.