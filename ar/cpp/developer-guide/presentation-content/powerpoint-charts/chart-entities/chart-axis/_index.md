---
title: تخصيص محاور المخططات في العروض التقديمية باستخدام C++
linktitle: محور المخطط
type: docs
url: /ar/cpp/chart-axis/
keywords:
- محور المخطط
- المحور العمودي
- المحور الأفقي
- تخصيص المحور
- معالجة المحور
- إدارة المحور
- خصائص المحور
- القيمة القصوى
- القيمة الدنيا
- خط المحور
- تنسيق التاريخ
- عنوان المحور
- موضع المحور
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides للـ C++ لتخصيص محاور المخططات في عروض PowerPoint التقديمية للتقارير والتصورات."
---

## **الحصول على القيم القصوى على المحور العمودي**
Aspose.Slides for C++ يتيح لك الحصول على القيم الدنيا والقصوى على محور عمودي. اتبع الخطوات التالية:

1. إنشاء مثال لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الحصول على القيمة القصوى الفعلية على المحور.
1. الحصول على القيمة الدنيا الفعلية على المحور.
1. الحصول على الوحدة الرئيسية الفعلية للمحور.
1. الحصول على الوحدة الفرعية الفعلية للمحور.
1. الحصول على مقياس الوحدة الرئيسية الفعلية للمحور.
1. الحصول على مقياس الوحدة الفرعية الفعلية للمحور.

يعرض لك هذا الكود النموذجى—تنفيذ الخطوات السابقة—كيفية الحصول على القيم المطلوبة في C++:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// يحفظ العرض التقديمي
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```


## **تبديل البيانات بين المحاور**
يتيح لك Aspose.Slides تبديل البيانات بين المحاور بسرعة—فالبيانات الموجودة على المحور العمودي (y-axis) تنتقل إلى المحور الأفقي (x-axis) والعكس بالعكس. 

يعرض لك هذا الكود C++ كيفية تنفيذ مهمة تبديل البيانات بين المحاور على مخطط:
``` cpp
// إنشاء عرض تقديمي فارغ
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// تبديل الصفوف والأعمدة
chart->get_ChartData()->SwitchRowColumn();

// حفظ العرض التقديمي
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```


## **تعطيل المحور العمودي لمخططات الخط**
يعرض لك هذا الكود C++ كيفية إخفاء المحور العمودي لمخطط خط:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **تعطيل المحور الأفقي لمخططات الخط**
يعرض لك هذا الكود كيفية إخفاء المحور الأفقي لمخطط خط:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **تغيير محور الفئة**
باستخدام طريقة **set_CategoryAxisType()**، يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). يوضح هذا الكود في C++ العملية: 
``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```


## **تعيين تنسيق التاريخ لقيم محور الفئة**
يتيح لك Aspose.Slides for C++ تعيين تنسيق التاريخ لقيمة محور الفئة. يتم توضيح العملية في هذا الكود C++:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```


## **تعيين زاوية الدوران لعنوان المحور**
يتيح لك Aspose.Slides for C++ تعيين زاوية الدوران لعنوان محور المخطط. يوضح هذا الكود C++ العملية:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```


## **تعيين موضع المحور على محور الفئة أو القيمة**
يتيح لك Aspose.Slides for C++ تعيين موضع المحور في محور الفئة أو قيمة المحور. يوضح هذا الكود C++ كيفية تنفيذ المهمة:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```


## **تمكين تسمية وحدة العرض على محور قيمة المخطط**
يتيح لك Aspose.Slides for C++ تكوين مخطط لعرض تسمية وحدة على محور قيمة المخطط. يوضح هذا الكود C++ العملية:
``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **الأسئلة الشائعة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها محور مع الآخر (تقاطع المحور)؟**

توفر المحاور [إعداد التقاطع](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/): يمكنك الاختيار للتقاطع عند الصفر، أو عند أقصى فئة/قيمة، أو عند قيمة عددية محددة. هذا مفيد لتحريك محور X لأعلى أو لأسفل أو لتسليط الضوء على خط أساس.

**كيف يمكنني وضع تسميات العلامات بالنسبة إلى المحور (بجانب، خارج، داخل)؟**

قم بتعيين [موضع التسمية](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) إلى "cross" أو "outside" أو "inside". يؤثر هذا على قابلية القراءة ويساعد على توفير المساحة، خاصة في المخططات الصغيرة.