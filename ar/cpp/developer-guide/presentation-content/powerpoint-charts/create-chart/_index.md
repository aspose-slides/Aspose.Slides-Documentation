---
title: إنشاء مخططات عرض باوربوينت في C++
linktitle: إنشاء مخطط
type: docs
weight: 10
url: /ar/cpp/create-chart/
keywords: "إنشاء مخطط، مخطط مبعثر، مخطط دائري، مخطط خريطة شجرية، مخطط أسهم، مخطط صندوق وشعيرات، مخطط هيستوغرام، مخطط قمع، مخطط شمس، مخطط متعدد الفئات، عرض باوربوينت، C++، CPP، Aspose.Slides for C++"
description: "إنشاء مخطط في عرض باوربوينت في C++"
---

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واكتساب رؤى قد لا تكون واضحة على الفور من جدول أو جدول بيانات.

**لماذا إنشاء المخططات؟**

باستخدام المخططات، يمكنك

* تجميع أو تكثيف أو تلخيص كميات كبيرة من البيانات في شريحة واحدة في عرض تقديمي
* كشف الأنماط والاتجاهات في البيانات
* استنتاج الاتجاه والزخم للبيانات مع مرور الوقت أو فيما يتعلق بوحدة قياس معينة
* اكتشاف القيم الشاذة والانحرافات والأخطاء والبيانات غير المنطقية، إلخ
* التواصل أو تقديم بيانات معقدة

في باوربوينت، يمكنك إنشاء المخططات من خلال وظيفة الإدراج، والتي توفر قوالب تستخدم لتصميم العديد من أنواع المخططات. باستخدام Aspose.Slides، يمكنك إنشاء مخططات عادية (استنادًا إلى أنواع المخططات الشائعة) ومخططات مخصصة.

{{% alert color="primary" %}}

للسماح لك بإنشاء مخططات، توفر Aspose.Slides فئة العد Enumeration [ChartType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) ضمن مساحة أسماء [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts/). القيم الموجودة ضمن هذه الفئة تتوافق مع أنواع المخططات المختلفة.

{{% /alert %}}

### **إنشاء مخططات عادية**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط ببعض البيانات وتحديد نوع المخطط المفضل لديك.
4. إضافة عنوان للمخطط.
5. الوصول إلى ورقة بيانات المخطط.
6. مسح جميع السلاسل والفئات الافتراضية.
7. إضافة سلاسل وفئات جديدة.
8. إضافة بعض البيانات الجديدة للمخطط لسلاسل المخطط.
9. إضافة لون تعبئة لسلسلة المخطط.
10. إضافة تسميات لسلسلة المخطط.
11. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط عادي:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/NormalCharts_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط بالبيانات الافتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);
  
	// تعيين فهرس ورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// تعيين عنوان المخطط
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"عنوان العينة");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// حذف السلاسل والفئات الافتراضية المولدة
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();

	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"السلسلة 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"السلسلة 2")), chart->get_Type());

	// إضافة الفئات
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"الفئة 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"الفئة 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"الفئة 3")));

	
	// أخذ أول سلسلة مخطط
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// تعبئة بيانات السلسلة
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// تعيين لون التعبئة للسلسلة
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// تفعيل العرض
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
``` 

### **إنشاء مخططات مبعثرة**
بشكل عام، يتم استخدام المخططات المبعثرة (المعروفة أيضًا باسم مخططات الانتشار أو رسوم x-y) للتحقق من الأنماط أو لإظهار الارتباطات بين متغيرين. 

قد ترغب في استخدام مخطط مبعثر عندما 

* تمتلك بيانات عددية مرتبطة
* تمتلك متغيرين يتوافقان جيدًا معًا
* تريد تحديد ما إذا كان المتغيران مرتبطين
* لديك متغير مستقل له قيم متعددة للمتغير التابع

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخاطر متعددة مع مجموعة مختلفة من العلامات:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط بالبيانات الافتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// تعيين عنوان المخطط
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"عنوان العينة");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// حذف السلاسل المولدة بشكل افتراضي
	chart->get_ChartData()->get_Series()->Clear();
	
	// تعيين الفهرس لورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"السلسلة 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"السلسلة 2")), chart->get_Type());

	// أخذ أول سلسلة مخطط
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// إضافة نقطة جديدة (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// إضافة نقطة جديدة (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// تعديل نوع السلسلة
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// تغيير رمز سلسلة مخطط السلسلة
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);

	// أخذ السلسلة الثانية
	series = chart->get_ChartData()->get_Series()->idx_get(1);

	// إضافة نقطة جديدة (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// إضافة نقطة جديدة (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// إضافة نقطة جديدة (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// إضافة نقطة جديدة (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// تغيير رمز السلسلة لمخطط السلسلة
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);

	// إعداد الفئة الأولى لإظهار اسم الفئة
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// يظهر القيمة للتسمية الثالثة
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// حفظ العرض
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات دائرية**
تعتبر المخططات الدائرية الأفضل للإشارة إلى علاقة الجزء بالكل في البيانات، خاصةً عندما تحتوي البيانات على تسميات تصنيفية بقيم عددية. ومع ذلك، إذا كانت بياناتك تحتوي على العديد من الأجزاء أو التسميات، قد ترغب في التفكير في استخدام مخطط شريطي بدلاً من ذلك. 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المرغوب (في هذه الحالة، `ChartType.Pie`).
4. الوصول إلى بيانات المخطط `IChartDataWorkbook`.
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للمخطط لسلسلة المخطط.
8. إضافة نقاط جديدة للمخططات وإضافة ألوان مخصصة لقطاعات المخطط الدائري.
9. تعيين تسميات للسلاسل.
10. تعيين خطوط القائد لتسميات السلسلة.
11. تعيين زاوية الدوران لشرائح المخطط الدائري.
12. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط دائري:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/PieChart_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط بالبيانات الافتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// تعيين عنوان المخطط
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"عنوان العينة");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// مسح السلاسل والفئات الافتراضية
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// تعيين الفهرس لورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// إضافة الفئات
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"الربع الأول")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"الربع الثاني")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"الربع الثالث")));

	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"السلسلة 1")), chart->get_Type());
	
	// أخذ أول سلسلة مخطط
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// تعبئة بيانات السلسلة
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// تعيين حدود القطاع
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// تعيين حدود القطاع
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);

	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// تعيين حدود القطاع
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);

	// إنشاء تسميات مخصصة لكل فئة من السلسلة الجديدة
	SharedPtr<IDataLabel> lbl1 = series->get_DataPoints()->idx_get(0)->get_Label();

	// lbl.ShowCategoryName = true;
	lbl1->get_DataLabelFormat()->set_ShowValue(true);

	SharedPtr<IDataLabel> lbl2 = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl2->get_DataLabelFormat()->set_ShowValue(true);
	lbl2->get_DataLabelFormat()->set_ShowLegendKey(true);
	lbl2->get_DataLabelFormat()->set_ShowPercentage(true);

	SharedPtr<IDataLabel> lbl3 = series->get_DataPoints()->idx_get(2)->get_Label();

	lbl3->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl3->get_DataLabelFormat()->set_ShowPercentage(true);

	// تعيين السلسلة لإظهار خطوط القائد للمخطط
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// تعيين زاوية الدوران لقطاعات المخطط الدائري
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);

	// حفظ العرض
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات خطية**

تعتبر المخططات الخطية (المعروفة أيضًا باسم رسومات الخط) الأفضل في الحالات التي ترغب فيها بإظهار التغييرات في القيمة مع مرور الوقت. باستخدام مخطط خطي، يمكنك مقارنة الكثير من البيانات في وقت واحد، تتبع التغييرات والاتجاهات مع مرور الوقت، إبراز الشذوذ في سلاسل البيانات، إلخ.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المرغوب (في هذه الحالة، `ChartType::Line`).
4. الوصول إلى بيانات المخطط `IChartDataWorkbook`.
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للمخطط لسلسلة المخطط.
8. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط خطي:

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

بشكل افتراضي، يتم ربط النقاط في المخطط الخطي بواسطة خطوط مستمرة مستقيمة. إذا كنت ترغب في ربط النقاط بواسطة خطوط منقطة بدلاً من ذلك، يمكنك تحديد نوع النقطة المفضلة لديك بهذه الطريقة:

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **إنشاء مخططات خريطة شجرية**

تعتبر مخططات الخريطة الشجرية الأفضل لبيانات المبيعات عندما ترغب في إظهار الحجم النسبي لفئات البيانات وفي نفس الوقت تجذب الانتباه بسرعة إلى العناصر التي تمثل مساهمات كبيرة في كل فئة. 

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المرغوب (في هذه الحالة، `ChartType.TreeMap`).
4. الوصول إلى بيانات المخطط `IChartDataWorkbook`.
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للمخطط لسلسلة المخطط.
8. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط خريطة شجرية:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/TreemapChart_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// فرع 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"ورقة1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"فرع1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"فرع1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"ورقة2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"ورقة3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"فرع2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"ورقة4")));


	// فرع 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"ورقة5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"فرع3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"فرع2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"ورقة6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"ورقة7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"فرع4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"ورقة8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Treemap);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForTreemapSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	series->set_ParentLabelLayout(Aspose::Slides::Charts::ParentLabelLayoutType::Overlapping);

	// حفظ العرض
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات الأسهم**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المرغوب (ChartType.OpenHighLowClose).
4. الوصول إلى بيانات المخطط `IChartDataWorkbook`.
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للمخطط لسلسلة المخطط.
8. تحديد تنسيق HiLowLines.
9. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط الأسهم:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/AddStockChart_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط بالبيانات الافتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// تعيين الفهرس لورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// حذف السلاسل والفئات الافتراضية المولدة
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// إضافة الفئات
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"فتح")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"مرتفع")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"منخفض")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"إغلاق")), chart->get_Type());

	// أخذ أول سلسلة مخطط
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// تعبئة بيانات السلسلة الأولى
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));

	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// تعبئة بيانات السلسلة الثانية
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// تعبئة بيانات السلسلة الثالثة
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));

	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// تعبئة بيانات السلسلة الرابعة
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// تعيين مجموعة السلاسل
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);

	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// حفظ العرض
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات صندوق وشعيرات**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المرغوب (ChartType.BoxAndWhisker).
4. الوصول إلى بيانات المخطط `IChartDataWorkbook`.
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للمخطط لسلسلة المخطط.
8. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط صندوق وشعيرات:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::BoxAndWhisker, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"الفئة 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"الفئة 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"الفئة 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"الفئة 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"الفئة 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"الفئة 6")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::BoxAndWhisker);

	series->set_QuartileMethod(Aspose::Slides::Charts::QuartileMethodType::Exclusive);
	series->set_ShowMeanLine(true);
	series->set_ShowMeanMarkers(true);
	series->set_ShowInnerPoints(true);
	series->set_ShowOutlierPoints(true);

	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(41)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(23)));
	series->get_DataPoints()->AddDataPointForBoxAndWhiskerSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(16)));

	// حفظ العرض
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات قمع**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المرغوب (ChartType.Funnel).
4. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط قمع:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/FunnelChart_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Funnel, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"الفئة 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"الفئة 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"الفئة 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"الفئة 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"الفئة 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"الفئة 6")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Funnel);

	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(50)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(100)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(200)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(300)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(400)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(500)));

	// حفظ العرض
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات شمسية**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المرغوب (في هذه الحالة، `ChartType.sunburst`).
4. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط شمسي:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// فرع 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"ورقة1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"فرع1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"فرع1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"ورقة2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"ورقة3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"فرع2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"ورقة4")));

	// فرع 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"ورقة5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"فرع3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"فرع2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"ورقة6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"ورقة7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"فرع4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"ورقة8")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Sunburst);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D1", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D2", System::ObjectExt::Box<int32_t>(5)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D3", System::ObjectExt::Box<int32_t>(3)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D4", System::ObjectExt::Box<int32_t>(6)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D5", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D6", System::ObjectExt::Box<int32_t>(9)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D7", System::ObjectExt::Box<int32_t>(4)));
	series->get_DataPoints()->AddDataPointForSunburstSeries(wb->GetCell(0, u"D8", System::ObjectExt::Box<int32_t>(3)));

	// كتابة ملف العرض إلى القرص
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات هيستوغرام**
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة بعض المخططات ببعض البيانات وتحديد نوع المخطط المفضل لديك (`ChartType.Histogram` في هذه الحالة).
4. الوصول إلى البيانات `IChartDataWorkbook`.
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط هيستوغرام:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Histogram, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Histogram);
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A1", System::ObjectExt::Box<int32_t>(15)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A2", System::ObjectExt::Box<int32_t>(-41)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A3", System::ObjectExt::Box<int32_t>(16)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A4", System::ObjectExt::Box<int32_t>(10)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A5", System::ObjectExt::Box<int32_t>(-23)));
	series->get_DataPoints()->AddDataPointForHistogramSeries(wb->GetCell(0, u"A6", System::ObjectExt::Box<int32_t>(16)));

	chart->get_Axes()->get_HorizontalAxis()->set_AggregationType(Aspose::Slides::Charts::AxisAggregationType::Automatic);

	// حفظ العرض
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات رادار**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها. 
3. إضافة مخطط ببعض البيانات وتحديد نوع المخطط المفضل لديك (`ChartType.Radar` في هذه الحالة).
4. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط رادار:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات متعددة الفئات**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة مخطط بالبيانات الافتراضية مع النوع المرغوب (ChartType.ClusteredColumn).
4. الوصول إلى بيانات المخطط `IChartDataWorkbook`.
5. مسح السلاسل والفئات الافتراضية.
6. إضافة سلاسل وفئات جديدة.
7. إضافة بيانات جديدة للمخطط لسلسلة المخطط.
8. كتابة العرض المعدل إلى ملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط متعدد الفئات:

```c++
// المسار إلى دليل الوثائق.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	// إنشاء مثيل لفئة العرض تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط بالبيانات الافتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// تعيين الفهرس لورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// مسح دفتر العمل
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// إضافة الفئات
	SharedPtr<IChartCategory> category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c2", ObjectExt::Box<System::String>(u"A")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"المجموعة1"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c3", ObjectExt::Box<System::String>(u"B")));
	
	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c4", ObjectExt::Box<System::String>(u"C")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"المجموعة2"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c5", ObjectExt::Box<System::String>(u"D")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c6", ObjectExt::Box<System::String>(u"E")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"المجموعة3"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c7", ObjectExt::Box<System::String>(u"F")));


	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c8", ObjectExt::Box<System::String>(u"G")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"المجموعة4"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c9", ObjectExt::Box<System::String>(u"H")));

	// إضافة سلسلة جديدة
	SharedPtr<IChartSeries>  series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(0, u"D1", ObjectExt::Box<System::String>(u"السلسلة 1")),
		ChartType::ClusteredColumn);

	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D2", ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D3", ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D4", ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D5", ObjectExt::Box<double>(40)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D6", ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D7", ObjectExt::Box<double>(60)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D8", ObjectExt::Box<double>(70)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D9", ObjectExt::Box<double>(80)));

	// حفظ العرض
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **إنشاء مخططات خريطة**

تعتبر مخططات الخريطة تمثيلًا لمنطقة تحتوي على بيانات. تعتبر مخططات الخريطة الأفضل لمقارنة البيانات أو القيم عبر المناطق الجغرافية.

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط خريطة:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **إنشاء مخططات مدمجة**

المخطط المدمج (أو مخطط المجموعة) هو مخطط يجمع بين مخططين أو أكثر على رسم بياني واحد. يسمح لك هذا النوع من المخططات بإبراز أو مقارنة أو مراجعة الاختلافات بين مجموعتين (أو أكثر) من البيانات. بهذه الطريقة، ترى العلاقة (إن وُجدت) بين مجموعات البيانات.

![combination-chart-ppt](combination-chart-ppt.png)

يوضح لك هذا الرمز بلغة C++ كيفية إنشاء مخطط مدمج في باوربوينت:

```c++
void CreateComboChart()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
    System::SharedPtr<IChart> chart = CreateChart(pres->get_Slide(0));
    AddFirstSeriesToChart(chart);
    AddSecondSeriesToChart(chart);
    pres->Save(u"combo-chart.pptx", SaveFormat::Pptx);
}

System::SharedPtr<IChart> CreateChart(System::SharedPtr<ISlide> slide)
{
    System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 400.0f);
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartSeriesCollection> seriesCollection = chartData->get_Series();
    System::SharedPtr<IChartCategoryCollection> categories = chartData->get_Categories();

    seriesCollection->Clear();
    categories->Clear();

    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    seriesCollection->Add(workbook->GetCell(worksheetIndex, 0, 1, System::ExplicitCast<System::Object>(u"السلسلة 1")), chart->get_Type());
    seriesCollection->Add(workbook->GetCell(worksheetIndex, 0, 2, System::ExplicitCast<System::Object>(u"السلسلة 2")), chart->get_Type());

    categories->Add(workbook->GetCell(worksheetIndex, 1, 0, System::ExplicitCast<System::Object>(u"الفئة 1")));
    categories->Add(workbook->GetCell(worksheetIndex, 2, 0, System::ExplicitCast<System::Object>(u"الفئة 2")));
    categories->Add(workbook->GetCell(worksheetIndex, 3, 0, System::ExplicitCast<System::Object>(u"الفئة 3")));

    System::SharedPtr<IChartDataPointCollection> dataPoints = chartData->get_ChartSeries(0)->get_DataPoints();

    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, System::ExplicitCast<System::Object>(20)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, System::ExplicitCast<System::Object>(50)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, System::ExplicitCast<System::Object>(30)));

    dataPoints = chartData->get_ChartSeries(1)->get_DataPoints();

    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, System::ExplicitCast<System::Object>(30)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, System::ExplicitCast<System::Object>(10)));
    dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, System::ExplicitCast<System::Object>(60)));

    return chart;
}

void AddFirstSeriesToChart(System::SharedPtr<IChart> chart)
{
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    System::SharedPtr<IChartSeries> series = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 3, System::ExplicitCast<System::Object>(u"السلسلة 3")), ChartType::ScatterWithSmoothLines);
    System::SharedPtr<IChartDataPointCollection> dataPoints = series->get_DataPoints();

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 1, System::ExplicitCast<System::Object>(3)), workbook->GetCell(worksheetIndex, 1, 2, System::ExplicitCast<System::Object>(5)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 5, System::ExplicitCast<System::Object>(10)), workbook->GetCell(worksheetIndex, 1, 6, System::ExplicitCast<System::Object>(7)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 2, 5, System::ExplicitCast<System::Object>(15)), workbook->GetCell(worksheetIndex, 2, 6, System::ExplicitCast<System::Object>(12)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 3, 5, System::ExplicitCast<System::Object>(12)), workbook->GetCell(worksheetIndex, 3, 6, System::ExplicitCast<System::Object>(9)));

    series->set_PlotOnSecondAxis(true);
}

void AddSecondSeriesToChart(System::SharedPtr<IChart> chart)
{
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    System::SharedPtr<IChartSeries> series = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 5, System::ExplicitCast<System::Object>(u"السلسلة 4")), ChartType::ScatterWithStraightLinesAndMarkers);
    System::SharedPtr<IChartDataPointCollection> dataPoints = series->get_DataPoints();

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 3, System::ExplicitCast<System::Object>(5)), workbook->GetCell(worksheetIndex, 1, 4, System::ExplicitCast<System::Object>(2)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 5, System::ExplicitCast<System::Object>(10)), workbook->GetCell(worksheetIndex, 1, 6, System::ExplicitCast<System::Object>(7)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 2, 5, System::ExplicitCast<System::Object>(15)), workbook->GetCell(worksheetIndex, 2, 6, System::ExplicitCast<System::Object>(12)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 3, 5, System::ExplicitCast<System::Object>(12)), workbook->GetCell(worksheetIndex, 3, 6, System::ExplicitCast<System::Object>(9)));

    series->set_PlotOnSecondAxis(true);
}
```

## **تحديث المخططات**

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) يمثل العرض الذي يحتوي على المخطط.
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. التنقل عبر جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى ورقة بيانات المخطط وتحديث قيم السلسلة.
5. إضافة سلسلة جديدة وتعبئة البيانات بها.
6. كتابة العرض المعدل كملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية تحديث المخطط:

```c++
// إنشاء مثيل لفئة العرض تمثل ملف PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// الوصول إلى الشريحة الأولى
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// إضافة مخطط بالبيانات الافتراضية
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// تعيين الفهرس لورقة بيانات المخطط
int32_t defaultWorksheetIndex = 0;

// الحصول على ورقة بيانات المخطط
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// تغيير اسم الفئات للمخطط
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"الفئة المعدلة 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"الفئة المعدلة 2"));

// أخذ أول سلسلة مخطط
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// تحديث بيانات السلسلة
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"السلسلة الجديدة"));
// تعديل اسم السلسلة
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// أخذ السلسلة الثانية
series = chart->get_ChartData()->get_Series()->idx_get(1);

// الآن تحديث بيانات السلسلة
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"السلسلة الجديدة 2"));
// تعديل اسم السلسلة
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));

// الآن إضافة سلسلة جديدة
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"السلسلة 3")), chart->get_Type());

// أخذ السلسلة الثالثة
series = chart->get_ChartData()->get_Series()->idx_get(2);

// الآن تعبئة بيانات السلسلة
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// حفظ العرض
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تعيين نطاق البيانات للمخططات**

1. فتح مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) تحتوي على المخطط.
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. التنقل عبر جميع الأشكال للعثور على المخطط المطلوب.
4. الوصول إلى بيانات المخطط وتعيين النطاق.
5. حفظ العرض المعدل كملف PPTX.

يوضح لك هذا الرمز بلغة C++ كيفية تعيين نطاق البيانات لمخطط:

```cpp
// المسار إلى دليل الوثائق.
String dataDir = GetDataPath();

// إنشاء مثيل لفئة العرض تمثل ملف PPTX
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// الوصول إلى الشريحة الأولى وإضافة مخطط بالبيانات الافتراضية
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```

## **استخدام علامات افتراضية في المخططات**
عند استخدام علامة افتراضية في المخططات، فإن كل سلسلة مخطط تحصل تلقائيًا على رموز علامة افتراضية مختلفة.

يوضح لك هذا الرمز بلغة C++ كيفية تعيين علامة سلسلة المخطط تلقائيًا:

```cpp
// المسار إلى دليل الوثائق.
String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10.0f, 10.0f, 400.0f, 400.0f);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 1, ObjectExt::Box<String>(u"السلسلة 1")), chart->get_Type());
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 1, 0, ObjectExt::Box<String>(u"C1")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(24)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 2, 0, ObjectExt::Box<String>(u"C2")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(23)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 3,