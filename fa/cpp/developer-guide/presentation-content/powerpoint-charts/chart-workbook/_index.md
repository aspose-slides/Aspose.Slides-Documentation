---
title: مدیریت دفترهای کاری نمودار در ارائه‌ها با استفاده از C++
linktitle: دفتر کار نمودار
type: docs
weight: 70
url: /fa/cpp/chart-workbook/
keywords:
- دفتر کار نمودار
- داده‌های نمودار
- سلول دفتر کار
- برچسب داده
- کاربرگ
- منبع داده
- دفتر کار خارجی
- داده خارجی
- کش نمودار
- بازیابی دفتر کار
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "Aspose.Slides برای C++ را کشف کنید: به‌راحتی دفترهای کاری نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با دفترچه‌های کاری نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های دفتر کار خوانده و نوشته، از سلول‌های دفتر کار به عنوان برچسب داده‌های نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با دفترچه‌های کاری خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک دفترچه کاری خارجی ایجاد و اختصاص دهید، مسیر دفترچه کاری خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را هنگامی که دفترچه کاری در دسترس است، ویرایش کنید.

برای سلول‌های دفتر کار که نشان‌دهنده داده‌های گمشده هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/cpp/chart-series/) مراجعه کنید تا تفاوت بین سلول خالی و صفر، و مقایسه نمودار خطی حالت‌های نمایش موجود را ببینید.

## **گنجاندن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) برای کنترل این‌که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی کاربرگ ترسیم می‌کند یا نه استفاده کنید. مقدار `true` فقط سلول‌های قابل مشاهده را ترسیم می‌کند، و `false` هر دو سلول قابل مشاهده و مخفی را شامل می‌شود. این تنظیم فقط ترسیم نمودار را تحت تأثیر قرار می‌دهد؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

فایل [hidden-source-data.pptx](hidden-source-data.pptx) را دانلود کنید و در پوشه کاری قرار دهید. اولین اسلاید آن شامل یک نمودار ستونی به عنوان اولین شکل است. کاربرگ جاسازی‌شده، `Sheet1`، بازه منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آنها همچنان مقادیر دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی پیدا کنید و با خواندن [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) وضعیت مخفی بودن آنها را بررسی کنید. این ویژگی فقط‑خواندنی است. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `False`، `True` و `True` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: دفترچه کار جاسازی‌شده را با [ReadWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) حفظ کنید و با [WriteWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) دوباره بارگذاری کنید. هنگام گنجاندن تمام سلول‌ها، همچنین از [SetRange](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/setrange/) برای بازگرداندن بازه کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ نمونه کافی نیست.

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

        // داده‌های نمودار را از دفتر کار جاسازی‌شده تازه کنید.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // بازهٔ منبع کامل را بازیابی کنید، شامل دسته‌های مخفی.
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

مثال `hidden_cells_True.pptx` را فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) ذخیره می‌کند و `hidden_cells_False.pptx` را با تمام شش مقدار ذخیره می‌کند. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو دفترچه کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که دارای مقدار است با یک سلول خالی متفاوت است. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_displayblanksas/) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم مخفی یا غیرمخفی کردن داده‌های منبع را تحت تأثیر قرار نمی‌دهد. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/cpp/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **خواندن و نوشتن داده‌های نمودار از یک دفتر کار**

Aspose.Slides for C++ متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) را ارائه می‌دهد که به شما امکان می‌دهد دفترچه‌های کاری داده‌های نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال `chart.pptx` را باز می‌کند که باید یک نمودار به عنوان اولین شکل در اسلاید اول داشته باشد. دفترچه کار جاسازی‌شده را به یک جریان می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان دفترچه را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر دفتر کار**

وقتی یک دفتر کار جاسازی‌شده با یک دفتر کار اصلاح‌شده جایگزین می‌شود، نمودار مجموعه‌های سری و دسته اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [IChart::ValidateChartLayout](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/validatechartlayout/) با خطای «index‑out‑of‑range» شود. قبل از نوشتن دفتر کار به‌روز شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال نیاز به `chart.pptx` با یک نمودار به عنوان اولین شکل در اسلاید اول دارد. نظرات محل ویرایش دفتر کار را نشان می‌دهند؛ مثال قابل اجرا دفتر کار اصلی را دوباره می‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

    // جریان کتاب کار را اینجا اصلاح کنید، به عنوان مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها قبل از نوشتن دفتر کار، ارجاع‌های دادهٔ کهنه را حذف می‌کند. قبل از استفاده از نمودار، هر سری و نگاشت دسته‌ای مورد نیاز برای دفتر کار به‌روزرسانی‌شده را بازسازی کنید.

## **تنظیم یک سلول دفتر کار به عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های دفتر کار به عنوان برچسب دادهٔ نمودار استفاده کنید. مراحل زیر نشان می‌دهند چگونه برچسب‌ها را در یک نمودار حبابی به سلول‌های دفترکار دادهٔ خود پیوند دهید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. اولین اسلاید را با ایندکس صفر‑مبنای خود دسترسی پیدا کنید.  
3. یک نمودار حبابی با دادهٔ پیش‌فرض اضافه کنید.  
4. به سری نمودار دسترسی پیدا کنید.  
5. سلول دفتر کار را به عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

این مثال `chart2.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد و یک نمودار حبابی با دادهٔ پیش‌فرض اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها از سلول‌ها فعال می‌شوند و نتیجه در `resultchart.pptx` ذخیره می‌شود.

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

متد [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) دسترسی به کاربرگ‌های موجود در یک دفتر کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را به کنسول چاپ می‌کند.

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

این مثال یک نمودار ستونی 3‑بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشته ثابت استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارش [DataSourceType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/datasourcetype/) منبع را برای هر نام انتخاب می‌کند. نتیجه در `pres.pptx` ذخیره می‌شود.

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

## **تشخیص فرمت‌های دفتر کار جاسازی‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides از فرمت دفتر کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) روی [IChartData](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/workbooktype/) فرمت‌های پشتیبانی‌نشده را شناسایی کنید و از آن نمودارها عبور کنید. این مثال اشکال موجود در اسلاید اول `sample.pptx` را بررسی می‌کند، اشکال غیرنموداری را عبور می‌دهد و برای هر نمودار دارای دفتر کار .xlsb یک پیام تشخیص چاپ می‌کند.

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

    // داده‌های پشتیبانی‌شده دفتر کار نمودار را در اینجا بخوانید یا اصلاح کنید.
}
```

## **دفتر کار خارجی**

Aspose.Slides از استفاده از دفتر کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک دفتر کار خارجی**

از [ReadWorkbookStream](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و [SetExternalWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) برای استخراج یک دفتر کار نمودار جاسازی‌شده به یک فایل و پیوند نمودار به آن دفتر کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند، دفتر کارش را در `externalWorkbook1.xlsx` می‌نویسد و قبل از اختصاص فایل به عنوان منبع دادهٔ نمودار جریان خروجی را می‌بندد. ارائهٔ پیوندشده در `externalWorkbook.pptx` ذخیره می‌شود.

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

### **تنظیم یک دفتر کار خارجی**

با استفاده از متد [SetExternalWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) می‌توانید یک دفتر کار خارجی را به‌عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد می‌تواند مسیر دفتر کار خارجی را به‌روزرسانی کند (اگر دفتر کار جابه‌جا شده باشد).

در حالی که نمی‌توانید داده‌های موجود در دفتر کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، همچنان می‌توانید از چنین دفتر کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک دفتر کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این مثال به `externalWorkbook.xlsx` در پوشه کاری نیاز دارد. کاربرگ `Sheet1` باید شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 باشد. مثال یک نمودار دایره‌ای ایجاد می‌کند، دفتر کار را پیوند می‌دهد و با استفاده از [SetRange](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/setrange/) بازهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. نتیجه در `Presentation_with_externalWorkbook.pptx` ذخیره می‌شود.

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

پارامتر `updateChartData` متد [SetExternalWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) کنترل می‌کند آیا دفتر کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر دفتر کار به‌روزرسانی می‌شود. دادهٔ نمودار از دفتر کار هدف بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین دفتر کار ممکن است در دسترس نباشد.  
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از دفتر کار هدف به‌روزرسانی می‌شود.

مثال زیر یک URL مکان‌دار را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شود و ارائه بدون بارگذاری دفتر کار غیرقابل دسترس ذخیره می‌شود.

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

### **دریافت مسیر دفتر کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی دفتر کار پیوندشده به یک نمودار، ابتدا بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند یا نه. اگر بله، می‌توانید مسیر دفتر کار را با دنبال کردن مراحل زیر بازیابی کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد کنید.  
2. اولین اسلاید را با ایندکس صفر‑مبنای خود دسترسی پیدا کنید.  
3. اطمینان حاصل کنید که اولین شکل یک نمودار است.  
4. نوع منبع دادهٔ نمودار را بخوانید.  
5. اگر منبع یک دفتر کار خارجی است، مسیر آن را بخوانید.

این مثال `externalWorkbook.pptx` را که در مثال قبلی ایجاد شده بود باز می‌کند و اولین شکل در اسلاید اول را بررسی می‌کند. اگر نمودار به یک دفتر کار خارجی پیوند داشته باشد، [get_ExternalWorkbookPath](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) را به کنسول چاپ می‌کند. سپس یک کپی از ارائه را در `Result.pptx` ذخیره می‌کند.

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

می‌توانید داده‌های موجود در دفتر کارهای خارجی را همان‌گونه که داده‌های دفتر کارهای داخلی را ویرایش می‌کنید، تغییر دهید. وقتی یک دفتر کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال به `presentation.pptx` با یک نمودار به عنوان اولین شکل در اسلاید اول و یک دفتر کار خارجی قابل دسترسی نیاز دارد. مقدار پشتیبان‌دار سلول اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائه را در `presentation_out.pptx` ذخیره می‌نماید. ویرایش مقادیر سلول می‌تواند فایل XLSX پیوندشده را به‌روزرسانی کند، بنابراین اگر نیاز به حفظ دفتر کار اصلی دارید، از یک نسخهٔ کپی استفاده کنید.

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

### **بازیابی دفتر کار از کش نمودار**

اگر یک نمودار از دفتر کاری خارجی استفاده می‌کند که گم شده یا در دسترس نیست، Aspose.Slides می‌تواند دفتر کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/) ایجاد کنید، آن را با [set_SpreadsheetOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) پیکربندی کنید و پیش از باز کردن ارائه، [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) را به `true` تنظیم کنید.

مثال C++ زیر `presentation.pptx` را باز می‌کند که اولین شکل در اسلاید اول باید یک نمودار باشد که به یک دفتر کار خارجی غیرقابل دسترس اشاره دارد، و داده‌های بازیابی‌شده را از طریق [IChart::get_ChartData](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichart/get_chartdata/) و [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) دسترسی می‌یابد:

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

    // در اینجا داده‌های دفتر کار بازیابی‌شده را بخوانید یا اصلاح کنید.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

اگر دفتر کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک [System::InvalidOperationException](https://reference.aspose.com/slides/fa/cpp/system/details_invalidoperationexception/) پرتاب می‌کند. فقط زمانی بازیابی را فعال کنید که استفاده از دادهٔ کش‌شدهٔ نمودار به‌عنوان یک گزینهٔ پذیرش‌پذیر باشد، زیرا کش ممکن است تغییراتی که پس از آخرین به‑روزرسانی ارائه در دفتر کار خارجی انجام شده‌اند را شامل نشود.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم یک نمودار خاص به یک دفتر کار خارجی یا جاسازی‌شده پیوند دارد؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و [مسیر به دفتر کار خارجی](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) است؛ اگر منبع یک دفتر کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به دفتر کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی دفتر کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از دفتر کارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین دفتر کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم دفتر کارهای راه دور از Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [پیوند به فایل خارجی](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبان‌شده توسط سلول می‌تواند فایل XLSX محلی پیوندشده را به‌روزرسانی کند. اگر نسخهٔ اصلی باید دست‌نخورده بماند، از یک نسخهٔ کپی دفتر کار استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شود چه کار کنم؟**

Aspose.Slides هنگام پیوندگیری رمز عبور را قبول نمی‌کند. یک روش رایج این است که پیش از پیوندگیری حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) تهیه کنید و به آن نسخه پیوند دهید.

**آیا چندین نمودار می‌توانند به یک دفتر کار خارجی اشاره کنند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.