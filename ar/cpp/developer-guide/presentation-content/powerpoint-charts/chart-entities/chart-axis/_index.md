---
title: تخصيص محاور المخطط في العروض التقديمية باستخدام C++
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
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف كيفية استخدام Aspose.Slides للـ C++ لتخصيص محاور المخطط في عروض PowerPoint التقديمية للتقارير والتصوير البصري."
---
## **نظرة عامة**

يفسر هذا المقال كيفية تخصيص محاور المخطط في Aspose.Slides. يوضح كيفية الحصول على القيم الفعلية للمحاور، تبديل البيانات بين المحاور، إخفاء المحور العمودي أو الأفقي لرسوم الخطوط، تغيير نوع محور الفئة، تعيين تنسيق التاريخ لقيم محور الفئة، تدوير عنوان المحور، تعيين موضع المحور، وعرض تسمية وحدة على محور القيمة.

## **الحصول على القيم القصوى على المحور العمودي**
يسمح Aspose.Slides للـ C++ بالحصول على القيم الدنيا والعليا على محور عمودي. اتبع الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. الحصول على القيمة القصوى الفعلية للمحور.
5. الحصول على القيمة الدنيا الفعلية للمحور.
6. الحصول على الوحدة الرئيسية الفعلية للمحور.
7. الحصول على الوحدة الفرعية الفعلية للمحور.
8. الحصول على مقياس الوحدة الرئيسية الفعلية للمحور.
9. الحصول على مقياس الوحدة الفرعية الفعلية للمحور.

يعرض رمز العينة هذا — تنفيذ الخطوات السابقة — كيفية الحصول على القيم المطلوبة في C++:

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
يسمح Aspose.Slides لك بتبديل البيانات بين المحاور بسرعة — حيث تنتقل البيانات الممثلة على المحور العمودي (y-axis) إلى المحور الأفقي (x-axis) والعكس بالعكس.

يعرض هذا الرمز C++ كيفية تنفيذ مهمة تبديل البيانات بين المحاور على المخطط:

``` cpp
// ينشئ عرضًا تقديميًا فارغًا
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// يبدل الصفوف والأعمدة
chart->get_ChartData()->SwitchRowColumn();

// يحفظ العرض التقديمي
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **إلغاء تفعيل المحور العمودي لرسوم الخطوط**

يعرض هذا الرمز C++ كيفية إخفاء المحور العمودي لرسوم الخطوط:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **إلغاء تفعيل المحور الأفقي لرسوم الخطوط**

يعرض هذا الرمز كيفية إخفاء المحور الأفقي لرسوم الخطوط:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **تغيير محور الفئة**

باستخدام الطريقة **set_CategoryAxisType()**، يمكنك تحديد نوع محور الفئة المفضل لديك (**date** أو **text**). يوضح هذا الرمز في C++ العملية:

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
يسمح Aspose.Slides للـ C++ بتعيين تنسيق التاريخ لقيمة محور الفئة. يتم توضيح العملية في رمز C++ هذا:

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
يسمح Aspose.Slides للـ C++ بتعيين زاوية الدوران لعنوان محور المخطط. يوضح هذا الرمز C++ العملية:

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
يسمح Aspose.Slides للـ C++ بتعيين موضع المحور في محور الفئة أو القيمة. يوضح هذا الرمز C++ كيفية تنفيذ المهمة:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **تفعيل عرض تسمية الوحدة على محور قيمة المخطط**
يسمح Aspose.Slides للـ C++ بتهيئة مخطط لإظهار تسمية وحدة على محور قيمة المخطط. يوضح هذا الرمز C++ العملية:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **الأسئلة المتكررة**

**كيف يمكنني تعيين القيمة التي يتقاطع عندها أحد المحاور مع الآخر (تقاطع المحاور)؟**

توفر المحاور إعداد [crossing setting](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/axis/set_crosstype/): يمكنك اختيار التقاطع عند الصفر، أو عند الفئة/القيمة القصوى، أو عند قيمة عددية محددة. هذا مفيد لتحريك محور X لأعلى أو لأسفل أو لتسليط الضوء على خط الأساس.

**كيف يمكنني وضع تسميات العلامات بالنسبة للمحور (بجانب، خارج، داخل)؟**

اضبط [label position](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/axis/set_majortickmark/) إلى "cross" أو "outside" أو "inside". يؤثر ذلك على قابلية القراءة ويساعد في توفير المساحة، خاصةً في المخططات الصغيرة.