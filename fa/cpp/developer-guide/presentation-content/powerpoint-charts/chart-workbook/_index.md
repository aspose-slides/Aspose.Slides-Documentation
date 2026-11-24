---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با C++
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/cpp/chart-workbook/
keywords:
- کتاب‌کار نمودار
- دادهٔ نمودار
- سلول کتاب‌کار
- برچسب داده
- کاربرگ
- منبع داده
- کتاب‌کار خارجی
- دادهٔ خارجی
- کش نمودار
- بازیابی کتاب‌کار
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را به‌صورت یکپارچه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانیم و بنویسیم، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنیم، به مجموعه‌های کاربرگ دسترسی پیدا کنیم و نوع منبع داده برای مقادیر نمودار را مشخص کنیم.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهیم، مسیر یک کتاب‌کار خارجی پیوست‌شده به یک نمودار را بازیابی کنیم و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است ویرایش کنیم.

برای سلول‌های کتاب‌کار که دادهٔ گمشده را نشان می‌دهند، به [کنترل نمایش سلول‌های خالی](/slides/fa/cpp/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسهٔ نمودار خطی از حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های پنهان**

از [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) برای کنترل اینکه آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های پنهان کاربرگ ترسیم کند یا نه استفاده کنید. مقدار آن را به `true` تنظیم کنید تا فقط سلول‌های قابل مشاهده ترسیم شوند، یا به `false` تا هر دو سلول قابل مشاهده و پنهان شامل شوند. این تنظیم فقط ترسیم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا نشان‌داده نمی‌کند.

The [نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اسلاید اول آن است. کاربرگ توکار، `Sheet1`، شامل بازهٔ منبع زیر است: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها همچنان مقدار دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی پیدا کنید و [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) را بخوانید تا وضعیت مخفی بودن آن‌ها را بررسی کنید. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال مقدارهای `False`، `True` و `True` را به ترتیب چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار توکار را با [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) نگه دارید و آن را با [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، همچنین از [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) برای بازگردانی بازهٔ کامل، شامل دستهٔ فوریهٔ مخفی، استفاده کنید. تنها تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ نمودار و برچسب‌های دسته در این نمونه تازه شوند.

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

        // داده‌های نمودار را از کتاب‌کار توکار تازه کنید.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // بازهٔ منبع کامل را بازگردانید، از جمله دسته‌های مخفی.
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

این مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار توکار مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقادیر خرده‌فروشی 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقادیر خرده‌فروشی و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول مخفی که دارای مقدار است با یک سلول خالی متفاوت است. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) نحوه نمایش مقادیر گمشده را کنترل می‌کند؛ داده‌های منبع مخفی را شامل یا مستثنی نمی‌کند. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/cpp/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی بازهٔ دادهٔ نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائه موجود، بازه‌های منبع را بررسی کنید تا تشخیص دهید هر نمودار از کدام سلول‌های کاربرگ استفاده می‌کند. متد [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) بازهٔ دادهٔ فعلی را به‌صورت فرمولی که شامل نام کاربرگ است، مانند `Sheet1!$A$1:$D$5` برمی‌گرداند. در اینجا، `Sheet1` نام کاربرگ است، `!` آن را از بازهٔ سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت دلار نشان‌دهندهٔ ارجاع مطلق به ردیف و ستون است.

این متد بازهٔ فعلی را می‌خواند بدون اینکه نمودار یا کتاب‌کار آن را تغییر دهد. اگر نمودار از کتاب‌کاری به‌عنوان منبع دادهٔ خود استفاده نکند، یک [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) را پرتاب می‌کند. برای اطلاعات بیشتر، به [مرجع API ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌ها را به‌طور مستقیم در هر اسلاید برای نمودارها بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر یک نمودار از کتاب‌کار استفاده نکند، پیام چاپ می‌کند و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن داده‌های نمودار از کتاب‌کار**

Aspose.Slides برای C++ متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) را فراهم می‌کند که به شما اجازه می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** اینکه داده‌های نمودار باید به همان روش سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال از یک ارائه استفاده می‌کند که یک نمودار به‌عنوان اولین شکل در اسلاید اول دارد. کتاب‌کار توکار را به یک جریان می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

وقتی یک کتاب‌کار توکار را با یک کتاب‌کار تغییر یافته جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌ی اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) با خطای out‑of‑range ایندکس شکست بخورد. قبل از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار استفاده می‌کند که اولین شکل در اولین اسلاید است. توضیح‌نامه جایی را که ویرایش کتاب‌کار باید صورت گیرد مشخص می‌کند؛ مثال اجرایی کتاب‌کار اصلی را باز می‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

    // در اینجا جریان کتاب‌کار را اصلاح کنید، به‌عنوان مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها مراجع دادهٔ منقضی‌شده را قبل از نوشتن کتاب‌کار حذف می‌کند. قبل از استفاده از نمودار، هر نگاشت سری و دستهٔ لازم برای کتاب‌کار به‌روز شده را بازساخت کنید.

## **انتخاب نحوهٔ ذخیره‌سازی برچسب‌های دسته**

قبل از افزودن برچسب‌ها، متد [IChartCategoryCollection::set_UseCells](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorycollection/set_usecells/) را بر روی مجموعهٔ خالی دسته‌ها فراخوانی کنید. برای برچسب‌هایی که به داده‌های کتاب‌کار اشاره دارند یا سلسله‌مراتبی شکل می‌دهند، مانند فصول گروه‌بندی‌شده بر حسب سال، از سلول‌های کاربرگ استفاده کنید. برای سطوح تک‌برچسبی که نیازی به ارجاع به سلول ندارند، از رشته‌های ثابت استفاده کنید. این تنظیم فقط برای دسته‌ها اعمال می‌شود. هر دو نمودار در مثال برای مقادیر سری‌های عددی از سلول‌های کاربرگ استفاده می‌کنند.

مثال دو نمودار ستونی ایجاد می‌کند و حالت ذخیره‌سازی و برچسب‌های `Q1 Q2 Q3 Q4` را برای هر کدام چاپ می‌کند. برای برچسب‌های مبتنی بر کاربرگ، [IChartCategory::get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/get_ascell/) دسترسی به سلول زیرین را فراهم می‌کند و [IChartDataCell::get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_value/) برچسب آن را برمی‌گرداند. برای برچسب‌های ثابت، رشته را مستقیماً از [IChartCategory::get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/get_value/) می‌خوانید.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

for (auto useCells : {true, false})
{
    auto x = useCells ? 20 : 360;
    auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, 20, 320, 250);
    auto data = chart->get_ChartData();
    auto categories = data->get_Categories();
    data->get_Series()->Clear();
    categories->Clear();
    categories->set_UseCells(useCells);

    auto workbook = data->get_ChartDataWorkbook();
    auto seriesName = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Sales"));
    auto series = data->get_Series()->Add(seriesName, chart->get_Type());
    for (auto row = 1; row <= 4; ++row)
    {
        auto label = String::Format(u"Q{0}", row);
        auto labelValue = ObjectExt::Box<String>(label);
        if (useCells)
        {
            auto labelCell = workbook->GetCell(0, row, 0, labelValue);
            categories->Add(labelCell);
        }
        else
        {
            categories->Add(labelValue);
        }

        auto valueCell = workbook->GetCell(0, row, 1, ObjectExt::Box<int32_t>(row * 10));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    Console::Write(u"UseCells = {0}:", categories->get_UseCells());
    for (auto category : IterateOver(categories))
    {
        auto label = categories->get_UseCells() ? category->get_AsCell()->get_Value() : category->get_Value();
        Console::Write(u" {0}", label->ToString());
    }
    Console::WriteLine();
}

presentation->Save(u"category-labels.pptx", Export::SaveFormat::Pptx);
```

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) برای کنترل نحوه نمایش مقادیر عددی در کتاب‌کار توکار یک نمودار استفاده کنید. برای مثال، ممکن است گزارشی نیاز داشته باشد که نرخ تبدیل به صورت درصد با چهار رقم اعشار و یک ضریب با پنج رقم اعشار نمایش داده شود. هر دو مقدار را به صورت عددی نگه دارید تا برای محاسبات و ترسیم نمودار در دسترس باقی بمانند.

یک قالب عددی فقط نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` مقدار `0.125` را به `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده به `12.5` تبدیل نمی‌شود. به‌ طور مشابه، `0.00000` مقدار `0.1234567` را به `0.12346` نمایش می‌دهد بدون اینکه مقدار ذخیره‌شده را گرد کند. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، به‌جای آن قالب اختصاص داده‌شده از طریق [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی می‌یابد. در کاربرگ 0، B2 شامل نرخ تبدیل و C2 شامل ضریب است. هر دو سلول مقادیر نمودار را فراهم می‌کنند. مثال همچنین برچسب‌های مقادیر را که به قالب‌های منبع لینک شده‌اند فعال می‌کند.

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

قالب‌های سلول‌های کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیم بر روی محورهای نمودار یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نمایش می‌دهد زیرا [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) با مقدار `true` فراخوانی شده است و قالب عددی منبع را دنبال می‌کند چون [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) نیز با `true` فراخوانی شده است. پس از ذخیره و باز کردن مجدد ارائه، برچسب‌ها `12.5000%` و `0.12346` را همان‌طور که در زیر نشان داده شده است، نمایش می‌دهند. محور عمودی قالب خود را `0.00` دارد که از طریق [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) اختصاص یافته و [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) با `false` فراخوانی شده است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم لینک منبع آن را به `false` تنظیم کنید و قالب آن را از طریق [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. برای مثال، یک قالب برچسب مستقل `0.00` مقدار اول را به `0.13` نمایش می‌دهد، در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [برچسب‌های دادهٔ نمودار](/slides/fa/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر پس از ذخیره و باز کردن مجدد ارائه رندر شده است:
![نمودار ستونی با برچسب‌های لینک‌شده به منبع که 12.5000% و 0.12346 را نشان می‌دهند و یک محور عددی با قالب مستقل.](custom-cell-formats.png)

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها از سلول‌ها فعال می‌شوند و ارائهٔ به‌روزرسانی‌شده را ذخیره می‌کند.

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

## **مدیریت کاربرگ‌ها**

متد [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) دسترسی به کاربرگ‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

## **مشخص‌کردن نوع منبع داده**

برای مقادیر نقطه‌های سری می‌توان به‌صورت مستقیم به‌عنوان مقادیر عددی ثابت ذخیره شد. برای مثال کامل که آن‌ها را ذخیره و می‌خواند به [تنظیم مقادیر سری با استفاده از مقادیر عددی ثابت](/slides/fa/cpp/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای جدا از پیکربندی کتاب‌کار داخلی یا خارجی نمودار است؛ استفاده از مقادیر عددی ثابت به‌تنهایی کتاب‌کار توکار را حذف نمی‌کند.

این مثال یک نمودار ستونی 3 بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با استفاده از منابع دادهٔ متفاوت تنظیم می‌کند. نام اول از یک رشته ثابت استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارش [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روز شده ذخیره می‌کند.

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

## **تشخیص فرمت‌های کتاب‌کار توکار نامعتبر**

Aspose.Slides از فرمت کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید از متد [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) بر روی [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) برای تشخیص فرمت‌های نامعتبر استفاده کنید و آن نمودارها را نادیده بگیرید. این مثال شکل‌ها را در اسلاید اول یک ارائهٔ موجود بررسی می‌کند، شکل‌های غیرنموداری را نادیده می‌گیرد و برای هر نمودار دارای کتاب‌کار .xlsb توکار پیام تشخیصی چاپ می‌کند.

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

    // داده‌های کتاب‌کار پشتیبانی‌شدهٔ نمودار را اینجا بخوانید یا اصلاح کنید.
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع دادهٔ نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) برای استخراج یک کتاب‌کار نمودار توکار به یک فایل و پیوست کردن نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌کند. قبل از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار، جریان خروجی را می‌بندد و سپس ارائهٔ لینک‌شده را ذخیره می‌کند.

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

با استفاده از متد [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)، می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (اگر کتاب‌کار جابجا شده باشد) نیز استفاده شود.

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های راه دور یا منابع را ویرایش کنید، هنوز می‌توانید از این کتاب‌کارها به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که کاربرگ آن به نام `Sheet1` شامل نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را لینک می‌کند و از [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) برای نگاشت A1:B4 به یک سری و سه دسته استفاده می‌کند. سپس ارائه را با نمودار لینک‌شده ذخیره می‌کند.

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

پارامتر `updateChartData` در [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) تعیین می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

- وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روز می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
- وقتی `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

مثال زیر یک URL جایگزین را با `updateChartData` تنظیم‌شده به `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای را حفظ می‌کند و ارائه را بدون بارگذاری کتاب‌کار در دسترس نبودن ذخیره می‌کند.

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

برای شناسایی کتاب‌کار پیوست‌شده به یک نمودار، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اسلاید اول یک ارائه که کتاب‌کار خارجی وصل شده دارد را بررسی می‌کند. اگر این یک نمودار پیوست‌شده به کتاب‌کار خارجی باشد، مثال [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را ذخیره می‌کند.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را به همان شیوه‌ای که محتویات کتاب‌کارهای داخلی را ویرایش می‌کنید، ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال از یک نمودار استفاده می‌کند که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی قابل دسترس پیوست شده است. مقدار سلولی اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائهٔ به‌روزرسانی‌شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست‌شده را به‌روز کند، بنابراین اگر نیاز به حفظ کتاب‌کار اصلی دارید، از یک نسخهٔ کپی استفاده کنید.

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

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) ایجاد کنید، با [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) آن را پیکربندی کنید و قبل از باز کردن ارائه، [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) را با مقدار `true` فراخوانی کنید.

مثال C++ زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی در دسترس نیست ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) و [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی می‌یابد:

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

    // داده‌های کتاب‌کار بازیابی‌شده را اینجا بخوانید یا اصلاح کنید.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) را پرتاب می‌کند. بازیابی را تنها زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ پذیرش‌پذیر باشد، زیرا کش ممکن است تغییراتی که پس از آخرین به‌روزرسانی ارائه در کتاب‌کار خارجی ایجاد شده‌اند، شامل نشود.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم آیا یک نمودار خاص به یک کتاب‌کار خارجی یا توکار پیوست شده است؟**  
بله. یک نمودار دارای یک [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و یک [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کتاب‌کارهای قرار گرفته بر روی منابع/اشتراک‌های شبکه استفاده کنم؟**  
بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود؛ آنها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
ارائه یک [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) را ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی پیوست‌شده را نیز به‌روز کند. اگر لازم است فایل اصلی بدون تغییر بماند، از یک کپی کتاب‌کار استفاده کنید.

**اگر فایل خارجی با رمز محافظت شده باشد، چه کاری باید انجام دهم؟**  
Aspose.Slides هنگام لینک‌کردن رمز عبور را قبول نمی‌کند. یک روش معمول این است که قبلاً محافظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده تهیه کنید (برای مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) و به آن نسخه لینک کنید.

**آیا می‌توان چندین نمودار به همان کتاب‌کار خارجی ارجاع داد؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در دفعهٔ بعدی که داده‌ها بارگذاری می‌شوند، مشاهده می‌شود.