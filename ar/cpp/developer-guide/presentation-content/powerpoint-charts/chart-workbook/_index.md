---
title: دفتر الرسم البياني
type: docs
weight: 70
url: /cpp/chart-workbook/
keywords: "دفتر الرسم البياني، بيانات الرسم البياني، عرض PowerPoint، C++، CPP، Aspose.Slides لـ C++"
description: "دفتر الرسم البياني في عرض PowerPoint بـ C++"
---

## **تعيين بيانات الرسم البياني من دفتر العمل**

توفر Aspose.Slides طرق [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a1bc3d9eaafc86814336b6c23bffd8e2e) و [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a3f42c5e16bf1fd1d4e69579bffc6ce8e) التي تتيح لك قراءة وكتابة دفاتر بيانات الرسم البياني (المحتوية على بيانات الرسم البياني المعدلة باستخدام Aspose.Cells). **ملاحظة** أن بيانات الرسم البياني يجب تنظيمها بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

يوضح هذا الكود بلغة C++ العملية لتعيين دفتر بيانات رسم بياني:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **تعيين خلية دفتر العمل كعلامة بيانات الرسم البياني**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) .
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إضافة رسم بياني فقاعة مع بعض البيانات.
1. الوصول إلى سلسل الرسم البياني.
1. تعيين خلية دفتر العمل كعلامة بيانات.
1. حفظ العرض التقديمي.

يوضح هذا الكود بلغة C++ كيفية تعيين خلية دفتر العمل كعلامة بيانات لرسم بياني:

``` cpp
System::String lbl0 = u"قيمة خلية التسمية 0";
System::String lbl1 = u"قيمة خلية التسمية 1";
System::String lbl2 = u"قيمة خلية التسمية 2";

// ينشئ فئة Presentation التي تمثل ملف تقديم 
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

يوضح هذا الكود بلغة C++ عملية حيث يتم استخدام خاصية [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook#a8a5bfd5f6d389c497fe0d9ff4037d928) للوصول إلى مجموعة من أوراق العمل:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **تحديد نوع مصدر البيانات**

يوضح هذا الكود بلغة C++ كيفية تحديد نوع لمصدر البيانات:

```c++
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

## **دفتر العمل الخارجي**

{{% alert color="primary" %}} 
في [Aspose.Slides](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-19-4-release-notes/) 19.4 ، قمنا بتنفيذ دعم دفاتر العمل الخارجية كمصدر بيانات للرسم البياني.
{{% /alert %}} 

### **إنشاء دفتر عمل خارجي**

باستخدام طرق **`ReadWorkbookStream`** و **`SetExternalWorkbook`**، يمكنك إما إنشاء دفتر عمل خارجي من الصفر أو تحويل دفتر عمل داخلي إلى خارجي.

يوضح هذا الكود بلغة C++ عملية إنشاء دفتر العمل الخارجي:

```c++
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

باستخدام طريقة **`IChartData.SetExternalWorkbook`**، يمكنك تعيين دفتر عمل خارجي لرسم بياني كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الأخير).

بينما لا يمكنك تعديل البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، يمكنك استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير المسار النسبي لدفتر العمل الخارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يوضح هذا الكود بلغة C++ كيفية تعيين دفتر عمل خارجي:

```c++
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

يتم استخدام معلمة `updateChartData` (تحت طريقة `SetExternalWorkbook`) لتحديد ما إذا كان سيتم تحميل دفتر عمل إكسل أم لا. 

* عندما يتم تعيين قيمة `updateChartData` إلى `false`، يتم تحديث مسار دفتر العمل فقط — لن يتم تحميل بيانات الرسم البياني أو تحديثها من دفتر العمل المستهدف. قد ترغب في استخدام هذا الإعداد في حالة عدم وجود أو عدم توفر دفتر العمل المستهدف. 
* عندما يتم تعيين قيمة `updateChartData` إلى `true`، تتحدث بيانات الرسم البياني من دفتر العمل المستهدف.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **الحصول على مسار دفتر البيانات الخارجي للرسم البياني**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. إنشاء كائن لشكل الرسم البياني.
1. إنشاء كائن لنوع مصدر البيانات (`ChartDataSourceType`) الذي يمثل مصدر بيانات الرسم البياني.
1. تحديد الشرط المناسب بناءً على كون نوع المصدر هو نفسه نوع مصدر البيانات لدفتر العمل الخارجي.

يوضح هذا الكود بلغة C++ العملية:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// حفظ العرض التقديمي
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **تحرير بيانات الرسم البياني**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر العمل الخارجي، يتم رمي استثناء.

يوضح هذا الكود بلغة C++ تطبيق العملية الموضحة:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```