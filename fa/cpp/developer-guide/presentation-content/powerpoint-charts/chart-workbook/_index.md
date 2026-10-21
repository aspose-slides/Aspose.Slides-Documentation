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
- ورق‌کار
- منبع داده
- کتاب‌کار خارجی
- دادهٔ خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه‌ی خود را به‌صورت یکپارچه سازماندهی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های ورق‌کاری دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. نمونه‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر کتاب‌کار خارجی پیوست‌شده به یک نمودار بازیابی شود و داده‌های نمودار هنگام در دسترس بودن کتاب‌کار ویرایش شود.

برای سلول‌های کتاب‌کاری که نمایانگر داده‌های گمشده هستند، به [Control the Display of Empty Cells](/slides/fa/cpp/chart-series/) مراجعه کنید تا تفاوت بین سلول خالی و صفر و مقایسه‌ای خطی از حالت‌های نمایش موجود را ببینید.

## **گنجاندن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) برای کنترل این که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی ورق‌کاری ترسیم می‌کند یا نه استفاده کنید. آن را به `true` تنظیم کنید تا فقط سلول‌های قابل مشاهده ترسیم شوند، یا به `false` تنظیم کنید تا هر دو سلول قابل مشاهده و مخفی گنجانده شوند. این تنظیم فقط ترسیم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های ورق‌کاری را مخفی یا نمایان نمی‌کند.

[پرزنتیشن نمونه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اولین اسلاید خود است. ورق‌کاری جاسازی‌شده، `Sheet1`، محدوده منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقادیر دارند.

| ردیف ورق‌کاری | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی پیدا کنید و با خواندن [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) وضعیت مخفی بودن آن‌ها را بررسی کنید. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال `False`، `True` و `True` را به ترتیب چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) حفظ کنید و با [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام گنجاندن همه سلول‌ها، همچنین از [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) برای بازیابی محدوده کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. صرفاً تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ این نمونه و برچسب‌های دسته کافی نیست.

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

        // داده‌های نمودار را از کتاب‌کار جاسازی‌شده تازه کنید.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // محدودهٔ منبع کامل را بازگردانید، شامل دسته‌های مخفی.
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

مثال دو نسخه از پرزنتیشن را ذخیره می‌کند: یک نسخه فقط با مقادیر قابل مشاهدهٔ خرده‌فروشی (10 و 20) و نسخهٔ دیگر با تمام شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار با یک سلول خالی متفاوت است. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا حذف داده منبع مخفی نمی‌شود. برای مثال به [Control the Display of Empty Cells](/slides/fa/cpp/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی محدودهٔ دادهٔ نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک پرزنتیشن موجود، محدوده‌های منبع را بررسی کنید تا تعیین کنید هر نمودار از چه سلول‌های ورق‌کاری استفاده می‌کند. متد [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) محدودهٔ دادهٔ فعلی را به‌صورت فرمولی شناسایی‌شده توسط ورق‌کاری برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام ورق‌کاری است، `!` آن را از بازهٔ سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت‌های دلار مرجع سطر و ستون را مطلق می‌کند.

این متد محدودهٔ فعلی را می‌خواند بدون اینکه نمودار یا کتاب‌کار آن تغییر کند. اگر نمودار از کتاب‌کاری به عنوان منبع داده استفاده نکند، [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) پرتاب می‌شود. برای اطلاعات بیشتر به [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک پرزنتیشن را باز می‌کند و شکل‌های هر اسلاید را برای یافتن نمودارها بررسی می‌گیرد. نام هر نمودار و محدودهٔ منبع آن را چاپ می‌کند. اگر یک نمودار از کتاب‌کار استفاده نکند، پیغامی چاپ می‌کند و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن دادهٔ نمودار از کتاب‌کار**

Aspose.Slides برای C++ متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهند. **توجه** داشته باشید که دادهٔ نمودار باید به همان شیوه سازماندهی شده باشد یا ساختاری مشابه منبع داشته باشد.

این مثال از یک پرزنتیشن با نمودار به‌عنوان اولین شکل در اولین اسلاید استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال پرزنتیشن را ذخیره نمی‌کند.

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

هنگامی که یک کتاب‌کار جاسازی‌شده را با یک نسخهٔ تغییر یافته جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این ناهماهنگی می‌تواند باعث شکست [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) با خطای «index‑out‑of‑range» شود. قبل از نوشتن کتاب‌کار به‌روزشده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اولین اسلاید است استفاده می‌کند. توضیحاتی نشان می‌دهد که ویرایش کتاب‌کار در کجا رخ می‌دهد؛ مثال قابل اجرا کتاب‌کار اصلی را برمی‌گرداند و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

    // در اینجا جریان کتاب‌کار را اصلاح کنید، برای مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها مراجع دادهٔ منسوخ را پیش از نوشتن کتاب‌کار حذف می‌کند. پیش از استفاده از نمودار، هر سری و نگاشت دستهٔ موردنیاز برای کتاب‌کار به‌روزشده را بازسازی کنید.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار جاسازی‌شدهٔ نمودار استفاده کنید. برای مثال، یک گزارش ممکن است نیاز به نرخ تبدیل نشان داده‌شده به‌صورت درصد با چهار رقم اعشار و یک ضریب با پنج رقم اعشار داشته باشد. هر دو مقدار باید عددی باقی بمانند تا برای محاسبات و ترسیم نمودار در دسترس باشند.

قالب عددی نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` مقدار `0.125` را به‌صورت `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` است. به‌طور مشابه، `0.00000` مقدار `0.1234567` را به‌صورت `0.12346` نشان می‌دهد بدون اینکه مقدار ذخیره‌شده رند شود. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، قالب اختصاص‌داده‌شده توسط [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی می‌یابد. در ورق‌کاری 0، B2 نرخ تبدیل و C2 ضریب را داراست. هر دو سلول مقدارهای نمودار را فراهم می‌کنند. مثال همچنین برچسب‌های مقدار را فعال می‌کند که به قالب‌های منبع متصل هستند.

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

قالب‌های سلول کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیماً بر محورهای نمودار یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نمایش می‌دهد زیرا [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) با `true` فراخوانی شده و به قالب عددی منبع پیوند دارد چون [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) با `true` تنظیم شده است. پس از ذخیره و باز کردن مجدد پرزنتیشن، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند همان‌طور که در زیر مشاهده می‌شود. محور عمودی قالب خود را `0.00` دارد که از طریق [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) اختصاص یافته و [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) با `false` فراخوانی شده است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع را به `false` تنظیم کنید و قالب آن را از طریق [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. به‌عنوان مثال، قالب مستقل برچسب `0.00` مقدار اول را به‌صورت `0.13` نمایش می‌دهد، در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها، به [Chart Data Labels](/slides/fa/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر پس از باز کردن مجدد پرزنتیشن ذخیره‌شده رندر شده است:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **استفاده از یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید متن سلول‌های کتاب‌کار را به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اولین اسلاید یک پرزنتیشن موجود اضافه می‌کند. از سلول‌های A10:A12 در ورق‌کاری 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها از سلول‌ها فعال می‌شوند و پرزنتیشن به‌روز شده را ذخیره می‌کند.

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

## **مدیریت ورق‌های کاری**

متد [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) دسترسی به ورق‌های کاری در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر ورق کاری را در کنسول چاپ می‌کند.

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

این مثال یک نمودار ستونی سه‌بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشتهٔ واضح استفاده می‌کند؛ نام دوم از سلول C1 در ورق‌کاری 0 استفاده می‌کند. شمارنده [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال پرزنتیشن را با نام‌های سری به‌روزشده ذخیره می‌کند.

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

## **تشخیص قالب‌های کتاب‌کار جاسازی‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides از قالب کتاب‌کار باینری اکسل (.xlsb) که ممکن است در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) در [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) همراه با شمارنده [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید. این مثال شکل‌های اولین اسلاید یک پرزنتیشن موجود را بررسی می‌کند، شکل‌های غیرنموداری را نادیده می‌گیرد و برای هر نمودار دارای کتاب‌کار .xlsb یک پیام تشخیص چاپ می‌کند.

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

    // در اینجا داده‌های کتاب‌کار پشتیبانی‌شدهٔ نمودار را بخوانید یا تغییر دهید.
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) برای استخراج کتاب‌کار نمودار جاسازی‌شده به یک فایل و پیوست نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را استخراج می‌کند. قبل از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار، جریان خروجی را می‌بندد و سپس پرزنتیشن پیوست‌شده را ذخیره می‌کند.

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

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع داده‌اش اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (اگر منتقل شده باشد) به‌کار رود.

اگرچه نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که در ورق‌کاری با نام `Sheet1`، نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 وجود دارد. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوست می‌کند و با استفاده از [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) A1:B4 را به یک سری و سه دسته متصل می‌کند. سپس پرزنتیشن با نمودار پیوست‌شده را ذخیره می‌کند.

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

پارامتر `updateChartData` متد [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) تعیین می‌کند آیا کتاب‌کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

مثال زیر یک URL جایگزین با `updateChartData` تنظیم‌شده به `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شود و پرزنتیشن بدون بارگذاری کتاب‌کار در دسترس نیست ذخیره می‌شود.

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

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار پیوست شده است، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را دریافت کنید.

این مثال اولین شکل در اولین اسلاید یک پرزنتیشن با کتاب‌کار خارجی پیوست‌شده را بررسی می‌کند. اگر شکل یک نمودار پیوست‌شده به کتاب‌کار خارجی باشد، [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از پرزنتیشن را ذخیره می‌کند.

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

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های کتاب‌کارهای خارجی را همان‌گونه که داده‌های کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. زمانی که یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی در دسترس پیوست شده، استفاده می‌کند. مقدار پشتیبانی‌شده از سلول اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و پرزنتیشن به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست‌شده را به‌روز کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی یک کپی استفاده کنید.

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

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در پرزنتیشن بازسازی کند. [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) را ایجاد کنید، با [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن پرزنتیشن، [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) را به `true` تنظیم کنید.

مثال زیر C++ کتاب‌کار داده‌ها را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی در دسترس نیست، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) و [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی می‌یابد:

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

    // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا اصلاح کنید.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیر فعال باشد، Aspose.Slides یک [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار گزینهٔ پذیرشی باشد، بازیابی را فعال کنید، زیرا کش ممکن است شامل تغییرات انجام شده بر روی کتاب‌کار خارجی پس از آخرین به‌روزرسانی پرزنتیشن نشود.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم یک نمودار خاص به کتاب‌کار خارجی یا جاسازی‌شده پیوست است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. پرزنتیشن مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که روی منابع/اشتراک‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ پرزنتیشن فایل XLSX خارجی را بازنویسی می‌کند؟**

پرزنتیشن یک [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی پیوست‌شده را نیز به‌روزرسانی کند. اگر کتاب‌کار اصلی باید دست‌نخورده بماند، یک کپی از آن استفاده کنید.

**اگر فایل خارجی دارای رمز عبور باشد چه باید کرد؟**

Aspose.Slides هنگام پیوست کردن رمز عبوری نمی‌پذیرد. یک روش رایج این است که پیش از آن محافظت را حذف کنید یا یک کپی رمزگشایی‌شده (به‌عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) تهیه کنید و به آن پیوست کنید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همگی به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس می‌شود.