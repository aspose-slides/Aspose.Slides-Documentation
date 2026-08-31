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
- عنوان البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخبأ المخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف Aspose.Slides لـ C++: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

هذه المقالة تشرح كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. توضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين لبيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء دفتر عمل خارجي وتعيينه، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتحرير بيانات المخطط عندما يكون دفتر العمل متاحًا.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides الأساليب [ReadWorkbookStream](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) و[WriteWorkbookStream](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) التي تتيح لك قراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها بنية مشابهة للمصدر.

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عندما تستبدل دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بمجموعات السلاسل والفئات الأصلية. هذا التعارض قد يتسبب في فشل [IChart::ValidateChartLayout](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/validatechartlayout/) مع خطأ “index-out-of-range”. قم بمسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث إلى المخطط.

```cpp
// بعد تعديل تدفق دفتر العمل (مثلاً باستخدام Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// مسح مراجع البيانات الحالية.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

مسح المجموعات يضمن أن بنية بيانات المخطط متسقة مع دفتر العمل الجديد، مما يسمح لـ `ValidateChartLayout` بالانتهاء دون أخطاء.

## **تعيين خلية دفتر عمل كعنوان لبيانات المخطط**

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. احصل على مرجع الشريحة عبر فهرسها.
3. أضف مخطط فقاعة مع بعض البيانات.
4. الوصول إلى سلسلة المخطط.
5. عيّن خلية دفتر العمل كعنوان للبيانات.
6. احفظ العرض التقديمي.

هذا هو كود C++ الذي يوضح كيفية تعيين خلية دفتر عمل كعنوان لبيانات المخطط:

``` cpp
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
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// ينشئ كائنًا من فئة Presentation التي تمثل ملف عرض تقديمي 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **إدارة أوراق العمل**

هذا كود C++ يوضح عملية يتم فيها استخدام الأسلوب [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) للوصول إلى مجموعة أوراق العمل:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **تحديد نوع مصدر البيانات**

هذا كود C++ يوضح كيفية تحديد نوع لمصدر البيانات:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **اكتشاف تنسيقات دفاتر العمل المضمنة غير المدعومة**

لا تدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام الأسلوب `get_EmbeddedWorkbookType` على [IChartData](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتخطي تلك المخططات.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // دفتر العمل المضمّن بتنسيق .xlsb غير مدعوم.
        continue;
    }

    // اقرأ أو عدل بيانات دفتر عمل المخطط هنا.
}
```

## **دفتر عمل خارجي**

{{% alert color="info" %}} 
في [Aspose.Slides](https://releases.aspose.com/slides/ar/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4، قمنا بتنفيذ دعم دفاتر العمل الخارجية كمصدر بيانات للمخططات.
{{% /alert %}} 

### **إنشاء دفتر عمل خارجي**

باستخدام أساليب **`ReadWorkbookStream`** و**`SetExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

هذا كود C++ يوضح عملية إنشاء دفتر عمل خارجي:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **تعيين دفتر عمل خارجي**

باستخدام أسلوب **`IChartData::SetExternalWorkbook`**، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذا الأسلوب لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

على الرغم من أنه لا يمكنك تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، إلا أنه لا يزال بإمكانك استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، سيتم تحويله تلقائيًا إلى مسار كامل.

هذا كود C++ يوضح كيفية تعيين دفتر عمل خارجي:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

معلم `updateChartData` (ضمن أسلوب `SetExternalWorkbook`) يستخدم لتحديد ما إذا كان سيتم تحميل دفتر عمل Excel أم لا.

* عندما تكون قيمة `updateChartData` مضبوطة على `false`، يتم فقط تحديث مسار دفتر العمل — لن يتم تحميل أو تحديث بيانات المخطط من دفتر العمل الهدف. قد ترغب في استخدام هذا الإعداد عندما يكون دفتر العمل الهدف غير موجود أو غير متاح.  
* عندما تكون قيمة `updateChartData` مضبوطة على `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **الحصول على مسار دفتر عمل مصدر البيانات الخارجي لمخطط**

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
2. احصل على مرجع الشريحة عبر فهرسها.
3. أنشئ كائنًا لشكل المخطط.
4. أنشئ كائنًا لنوع المصدر (`ChartDataSourceType`) الذي يمثل مصدر بيانات المخطط.
5. حدد الشرط المناسب بناءً على ما إذا كان نوع المصدر هو نفس نوع مصدر دفتر العمل الخارجي.

هذا كود C++ يوضح العملية:

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجرى بها التغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم رمي استثناء.

هذا كود C++ هو تنفيذ للخطوات الموضحة:

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ كائنًا من [LoadOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/)، قم بتكوينه باستخدام [set_SpreadsheetOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/)، واستدعِ [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) مع القيمة `true` قبل فتح العرض التقديمي.

المثال التالي بلغة C++ يفتح عرضًا تقديميًا يشير مخططه إلى دفتر عمل خارجي غير متاح ويصل إلى البيانات المستعادة عبر [IChart::get_ChartData](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichart/get_chartdata/) و[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تقوم Aspose.Slides برمي استثناء `System::InvalidOperationException`. فعّل الاستعادة فقط عندما يكون استخدام بيانات المخطط المخزنة مؤقتًا كخيار احتياطي مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مضمّن؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل يتم دعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. هذا مفيد لنقلية المشاريع؛ ومع ذلك، لاحظ أن العرض التقديمي سيخزن المسار المطلق في ملف PPTX.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام such دفاتر عمل كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides — يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

لا. يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) ويستخدمه لقراءة البيانات. لا يتم تعديل الملف الخارجي عند حفظ العرض التقديمي.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا تقبل كلمة مرور عند الربط. عادةً ما يتم إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (مثلاً باستخدام [Aspose.Cells](/cells/cpp/)) وربطها بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كان جميعها تشير إلى نفس الملف، فإن تحديث ذلك الملف سيظهر في كل مخطط عند تحميل البيانات مرة أخرى.