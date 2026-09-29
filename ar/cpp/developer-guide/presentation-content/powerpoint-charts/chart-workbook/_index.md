---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام C++
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/cpp/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- تسمية البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخطط التخزين المؤقت
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ C++: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية التعامل مع دفاتر عمل المخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما يغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلية دفتر العمل التي تمثل بيانات مفقودة، راجع [Control the Display of Empty Cells](/slides/ar/cpp/chart-series/) للفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) للتحكم فيما إذا كان المخطط يرسم البيانات من الصفوف والأعمدة المخفية في ورقة العمل. اضبطه على `true` لرسم الخلايا المرئية فقط، أو على `false` لتضمين الخلايا المرئية والمخفية معًا. هذا الإعداد يتحكم في رسم المخطط؛ ولا يقوم بإخفاء أو إظهار صفوف أو أعمدة ورقة العمل.

قم بتحميل [hidden-source-data.pptx](hidden-source-data.pptx) وضعه في دليل العمل. يحتوي شريحته الأولى على مخطط عمودي كشكل أول. ورقة العمل المضمنة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما ما زالت تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر من خلال [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) وقراءة [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) لفحص حالة إخفائها. هذه الخاصية للقراءة فقط. في هذا الملف، B2 مرئية، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ المثال يطبع `False`، `True`، و`True` على التوالي.

في هذا المثال، قم بتحديث بيانات المخطط بعد تغيير إعداد التخطيط: احتفظ بدفتر العمل المضمن باستخدام [ReadWorkbookStream](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) وأعد تحميله باستخدام [WriteWorkbookStream](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). عند تضمين جميع الخلايا، استخدم أيضًا [SetRange](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/setrange/) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. تغيير العلامة فقط غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وتسميات الفئات في هذه العينة.

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

        // تحديث بيانات المخطط من دفتر العمل المضمّن.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // استعادة النطاق المصدر الكامل، بما في ذلك الفئات المخفية.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"الشكل الأول ليس مخططًا.");
}
```

يحفظ المثال `hidden_cells_True.pptx` فقط مع قيم التجزئة المرئية (10 و20)، و`hidden_cells_False.pptx` مع جميع القيم الست. توضح الصور أدناه وضعي التخطيط الاثنين. يظل الصف 3 والعمود C مخفيين في كلا دفترَي العمل المضمنين.

| الخلايا المرئية فقط (`true`) | جميع الخلايا (`false`) |
| --- | --- |
| ![الخلايا المرئية فقط: قيم التجزئة 10 و20 لشهري يناير ومارس.](hidden_cells_True.png) | ![جميع الخلايا: قيم التجزئة والجملة لشهري يناير وفبراير ومارس.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/get_displayblanksas/) في طريقة عرض القيم المفقودة؛ ولا يشمل أو يستثني بيانات المصدر المخفية. راجع [Control the Display of Empty Cells](/slides/ar/cpp/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides لـ C++ الطرقتين [ReadWorkbookStream](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و[WriteWorkbookStream](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) اللتين تتيحان لك قراءة وكتابة دفاتر بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تعديلها باستخدام Aspose.Cells). **ملاحظة** يجب تنظيم بيانات المخطط بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

يفتح هذا المثال الملف `chart.pptx`، ويجب أن يحتوي على مخطط كشكل أول في شريحته الأولى. يقرأ دفتر العمل المضمن إلى تدفق، يمسح السلاسل والفئات الحالية، ثم يكتب دفتر العمل نفسه مرة أخرى. تبقى التغييرات في الذاكرة؛ لا يقوم المثال بحفظ العرض.

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

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر العمل المضمن بآخر معدل، يحتفظ المخطط بسلاسل الفئات والمجموعات الأصلية. قد يتسبب هذا الاختلاف في فشل [IChart::ValidateChartLayout](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/validatechartlayout/) مع خطأ مؤشر خارج النطاق. امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث مرة أخرى إلى المخطط. يتطلب هذا المثال وجود `chart.pptx` يحتوي على مخطط كشكل أول في شريحته الأولى. يشير التعليق إلى مكان تحرير دفتر العمل؛ يكتب المثال القابل للتنفيذ دفتر العمل الأصلي مرة أخرى ويحقق من صحة التخطيط في الذاكرة.

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

    // قم بتعديل تدفق دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

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

إزالة المجموعات تحذف مراجع البيانات القديمة قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل وفئات مطلوبة للدفتر المحدث قبل استخدام المخطط.

## **تعيين خلية دفتر العمل كعنوان بيانات المخطط**

يمكنك استخدام النص من خلايا دفتر العمل كعناوين بيانات المخطط. توضح الخطوات التالية كيفية ربط العناوين في مخطط الفقاعات بالخلايا في دفتر بياناته.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى باستخدام الفهرس الصفري.
3. إضافة مخطط فقاعات ببيانات افتراضية.
4. الوصول إلى سلاسل المخطط.
5. تعيين خلية دفتر العمل كعنوان بيانات.
6. حفظ العرض.

يفتح هذا المثال الملف `chart2.pptx`، ويجب أن يحتوي على شريحة واحدة على الأقل، ويضيف مخطط فقاعات ببيانات افتراضية. يستخدم الخلايا A10:A12 في ورقة العمل 0 للثلاث عناوين الأولى في السلسلة الأولى، يمكّن العناوين من الخلايا، ويحفظ النتيجة في `resultchart.pptx`.

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

## **إدارة أوراق العمل**

توفر الطريقة [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) إمكانية الوصول إلى أوراق العمل في دفتر عمل المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart>
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

## **تحديد نوع مصدر البيانات**

ينشئ هذا المثال مخطط عمودي ثلاثي الأبعاد ببيانات افتراضية ويحدد اسمين لسلسلتين باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم قيمة نصية ثابتة؛ والثاني يستخدم الخلية C1 في ورقة العمل 0. تحدد تعداد [DataSourceType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/datasourcetype/) المصدر لكل اسم. يُحفظ الناتج في `pres.pptx`.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart>
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

## **اكتشاف صيغ دفاتر العمل المضمنة غير المدعومة**

لا تدعم Aspose.Slides صيغة دفتر عمل Excel الثنائي (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام الطريقة [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) على [IChartData](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/workbooktype/) لاكتشاف الصيغ غير المدعومة وتجاوز تلك المخططات. يستعرض هذا المثال الأشكال في الشريحة الأولى من `sample.pptx`، يتجاوز الأشكال غير المخططة، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مضمّن.

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

    // قراءة أو تعديل بيانات دفتر عمل المخطط المدعومة هنا.
}
```

## **دفتر عمل خارجي**

تدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [ReadWorkbookStream](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و[SetExternalWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) لتصدير دفتر عمل المخطط المضمن إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية، يكتب دفتر عمله إلى `externalWorkbook1.xlsx`، ويغلق تدفق الإخراج قبل تعيين الملف كمصدر بيانات للمخطط. يحفظ العرض المرتبط في `externalWorkbook.pptx`.

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

### **تعيين دفتر عمل خارجي**

باستخدام الطريقة [SetExternalWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)، يمكنك تعيين دفتر عمل خارجي للمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (في حال تم نقل الأخير).

على الرغم من أنك لا تستطيع تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، إلا أنه لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر العمل الخارجي، يتم تحويله إلى مسار كامل تلقائيًا.

يتطلب هذا المثال وجود `externalWorkbook.xlsx` في دليل العمل. يجب أن تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، وأسماء الفئات في A2:A4، وقيم رقمية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [SetRange](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/setrange/) لتعيين A1:B4 كسلسلة واحدة وثلاث فئات. يحفظ النتيجة في `Presentation_with_externalWorkbook.pptx`.

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

معامل `updateChartData` في [SetExternalWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) يتحكم فيما إذا كان دفتر العمل سيتم تحميله.

* عندما تكون `updateChartData` `false`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل المستهدف، لذا يمكن أن يكون دفتر العمل غير متوفر.
* عندما تكون `updateChartData` `true`، يتم تحديث بيانات المخطط من دفتر العمل المستهدف.

يعين المثال التالي عنوان URL Placeholder مع `updateChartData` مضبوطًا على `false`. يحتفظ ببيانات المخطط الدائري الافتراضية ويحفظ العرض دون تحميل دفتر العمل غير المتوفر.

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

### **الحصول على مسار دفتر العمل لمصدر البيانات الخارجي للمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق أولًا مما إذا كان المخطط يستخدم مصدر بيانات خارجي. إذا كان كذلك، يمكنك استرجاع مسار دفتر العمل باتباع الخطوات التالية.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. الوصول إلى الشريحة الأولى باستخدام الفهرس الصفري.
3. التحقق من أن الشكل الأول هو مخطط.
4. قراءة نوع مصدر بيانات المخطط.
5. إذا كان المصدر دفتر عمل خارجي، قراءة مساره.

يفتح هذا المثال الملف `externalWorkbook.pptx`، الذي أنشئ في المثال السابق، ويفحص الشكل الأول في الشريحة الأولى. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع المثال [get_ExternalWorkbookPath](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض في `Result.pptx`.

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

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تعدل بها محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر العمل الخارجي، يتم رفع استثناء.

يتطلب هذا المثال وجود `presentation.pptx` يحتوي على مخطط كشكل أول في الشريحة الأولى ودفتر عمل خارجي يمكن الوصول إليه. يضبط قيمة الخلية للنقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض في `presentation_out.pptx`. يمكن لتعديل قيم الخلايا تحديث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت بحاجة إلى الحفاظ على دفتر العمل الأصلي.

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

### **استعادة دفتر العمل من ذاكرة مخطط التخزين المؤقت**

إذا كان مخطط يستخدم دفتر عمل خارجي مفقود أو غير متوفر، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/)، واضبطه باستخدام [set_SpreadsheetOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/)، واستدعِ [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) مع `true` قبل فتح العرض.

المثال التالي بلغة C++ يفتح `presentation.pptx`، ويجب أن يكون الشكل الأول في الشريحة الأولى مخططًا يشير إلى دفتر عمل خارجي غير متوفر، ويصل إلى البيانات المستعادة عبر [IChart::get_ChartData](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/get_chartdata/) و[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

إذا كان دفتر العمل الخارجي غير متوفر وتم تعطيل الاستعادة، يرمي Aspose.Slides استثناءً من نوع [System::InvalidOperationException](https://reference.aspose.com/slides/ar/cpp/system/details_invalidoperationexception/). فعّل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا هو حل مقبول، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض.

## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مدمج؟**

نعم. يمتلك المخطط [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و[مسارًا إلى دفتر عمل خارجي](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا قمت بتحديد مسار نسبي، يتم تحويله تلقائيًا إلى مسار مطلق. يخزن العرض المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الرابط.

**هل يمكنني استخدام دفاتر العمل الموجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تعديل دفاتر العمل البعيدة مباشرةً من Aspose.Slides؛ يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض؟**

يقوم العرض بتخزين [رابط إلى الملف الخارجي](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). يمكن لتعديل بيانات المخطط المدعومة بالخلية أيضًا تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان يجب أن يظل الأصل دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. يُعد الإجراء الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) وربطها بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميعها تشير إلى نفس الملف، فسيظهر تحديث ذلك الملف في كل مخطط عند تحميل البيانات مرة أخرى.