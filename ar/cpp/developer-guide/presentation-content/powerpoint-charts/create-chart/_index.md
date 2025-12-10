---
title: إنشاء أو تحديث مخططات عروض PowerPoint في C++
linktitle: إنشاء أو تحديث المخططات
type: docs
weight: 10
url: /ar/cpp/create-chart/
keywords:
- إضافة مخطط
- إنشاء مخطط
- تحرير مخطط
- تغيير مخطط
- تحديث مخطط
- مخطط مبعثر
- مخطط دائري
- مخطط خطي
- مخطط خريطة شجرية
- مخطط أسهم
- مخطط صندوق وشارب
- مخطط قمع
- مخطط شمسي
- مخطط تكراري
- مخطط راداري
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint باستخدام Aspose.Slides للغة C++. إضافة، تنسيق، وتعديل المخططات مع أمثلة شيفرة عملية في C++."
---

## **إنشاء مخطط**

تساعد المخططات الأشخاص على تصور البيانات بسرعة واكتساب رؤى قد لا تكون واضحة فورًا من جدول أو جدول بيانات. 

**لماذا إنشاء المخططات؟**

باستخدام المخططات، يمكنك

* تجميع أو تكثيف أو تلخيص كميات كبيرة من البيانات في شريحة واحدة داخل عرض تقديمي
* إظهار الأنماط والاتجاهات في البيانات
* استنتاج اتجاه وتزايد البيانات عبر الوقت أو بالنسبة لوحدة قياس معينة 
* اكتشاف القيم المتطرفة، الشذوذ، الانحرافات، الأخطاء، البيانات غير المنطقية، إلخ 
* نقل أو تقديم البيانات المعقدة

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة الإدراج، التي توفر قوالب تُستخدم لتصميم العديد من أنواع المخططات. باستخدام Aspose.Slides، يمكنك إنشاء مخططات عادية (استنادًا إلى أنواع المخططات الشائعة) ومخططات مخصصة. 

{{% alert color="primary" %}} 

للسماح لك بإنشاء المخططات، توفر Aspose.Slides فئة تعداد [ChartType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) ضمن مساحة الاسم [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts/). القيم في هذه الفئة تمثل أنواع المخططات المختلفة. 

{{% /alert %}} 

### **إنشاء مخططات عادية**
1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط مع بعض البيانات وتحديد نوع المخطط المفضل. 
1. إضافة عنوان للمخطط. 
1. الوصول إلى ورقة عمل بيانات المخطط. 
1. مسح جميع السلاسل والفئات الافتراضية. 
1. إضافة سلاسل وفئات جديدة. 
1. إضافة بعض البيانات الجديدة لسلسلة المخطط. 
1. إضافة لون تعبئة لسلسلة المخطط. 
1. إضافة تسميات لسلسلة المخطط. 
1. حفظ العرض التقديمي المعدل كملف PPTX. 

يعرض هذا الكود C++ كيفية إنشاء مخطط عادي:
```c++
// مسار دليل المستندات.
	const String outPath = u"../out/NormalCharts_out.pptx";

	//إنشاء كائن من فئة العرض التقديمي التي تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط ببيانات افتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// تعيين فهرس ورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة عمل بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// تعيين عنوان المخطط
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// إضافة فئات
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// أخذ السلسلة الأولى للمخطط
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// ملء بيانات السلسلة
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// تعيين لون تعبئة السلسلة
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// أخذ السلسلة الثانية للمخطط
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// ملء بيانات السلسلة
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// تعيين لون تعبئة السلسلة
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// يتم تعيين التسمية الأولى لإظهار اسم الفئة
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// إظهار القيمة للتسمية الثالثة
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


### **إنشاء مخططات مبعثرة**
المخططات المبعثرة (المعروفة أيضًا بالمخططات المبعثرة أو رسومات x‑y) تُستخدم غالبًا للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين. 

قد ترغب في استخدام مخطط مبعثر عندما 

* تتوفر لديك بيانات عددية مزدوجة
* لديك متغيران يتوافقان جيدًا معًا
* تريد تحديد ما إذا كان المتغيران مرتبطين
* لديك متغير مستقل له قيم متعددة للمتغير التابع 

يعرض هذا الكود C++ كيفية إنشاء مخططات مبعثرة مع مجموعة مختلفة من العلامات: 
```c++
// مسار دليل المستندات.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	// إنشاء كائن من فئة العرض التقديمي التي تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط ببيانات افتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// تعيين عنوان المخطط
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// حذف السلاسل التي تم إنشاؤها افتراضيًا 
	chart->get_ChartData()->get_Series()->Clear();
	
	// تعيين فهرس ورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة عمل بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// أخذ السلسلة الأولى للمخطط
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// إضافة نقطة جديدة (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// إضافة نقطة جديدة (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// تعديل نوع السلسلة
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// تغيير علامة سلسلة المخطط
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// أخذ السلسلة الثانية للمخطط
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// إضافة نقطة جديدة (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// إضافة نقطة جديدة (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// إضافة نقطة جديدة (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// إضافة نقطة جديدة (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// تغيير علامة سلسلة المخطط
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



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
	point2->get_Format()->get_Line()->set_Width ( 2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// إنشاء التسميات المخصصة لكل فئة من السلسلة الجديدة
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

	// إظهار خطوط القائد للمخطط
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// تعيين زاوية الدوران لقطاعات المخطط الدائري
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات دائرية**
تُستخدم المخططات الدائرية لإظهار علاقة الجزء إلى الكل في البيانات، خاصةً عندما تحتوي البيانات على تسميات فئوية مع قيم عددية. ومع ذلك، إذا كانت بياناتك تحتوي على العديد من الأجزاء أو التسميات، قد تفضّل استخدام مخطط شريطي بدلاً من ذلك. 

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (في هذه الحالة، `ChartType.Pie`). 
1. الوصول إلى بيانات المخطط IChartDataWorkbook. 
1. مسح السلاسل والفئات الافتراضية. 
1. إضافة سلاسل وفئات جديدة. 
1. إضافة بيانات مخطط جديدة لسلسلة المخطط. 
1. إضافة نقاط جديدة للمخططات وإضافة ألوان مخصصة لأقسام المخطط الدائري. 
1. تعيين تسميات للسلسلة. 
1. تعيين خطوط ربط لتسميات السلسلة. 
1. تعيين زاوية الدوران لشرائح المخطط الدائري. 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX 

يعرض هذا الكود C++ كيفية إنشاء مخطط دائري:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/PieChart_out.pptx";

	//إنشاء كائن من فئة Presentation الذي يمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط ببيانات افتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// تعيين عنوان المخطط
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// حذف السلسلة والفئات التي تم إنشاؤها افتراضيًا
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// تعيين فهرس ورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة عمل بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// إضافة فئات
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"First Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2nd Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3ed Qtr")));

	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	
	// أخذ السلسلة الأولى للمخطط
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// ملء بيانات السلسلة
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
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

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
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// تعيين زاوية الدوران لقطاعات المخطط الدائري
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات خطية**
تُستخدم المخططات الخطية (المعروفة أيضًا بالرسوم الخطية) في الحالات التي تريد فيها إظهار تغيرات القيمة عبر الوقت. باستخدام مخطط خطي، يمكنك مقارنة كميات كبيرة من البيانات في وقت واحد، تتبع التغيرات والاتجاهات عبر الوقت، إبراز الشذوذ في سلاسل البيانات، إلخ. 

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (في هذه الحالة، `ChartType::Line`). 
1. الوصول إلى بيانات المخطط IChartDataWorkbook. 
1. مسح السلاسل والفئات الافتراضية. 
1. إضافة سلاسل وفئات جديدة. 
1. إضافة بيانات مخطط جديدة لسلسلة المخطط. 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX 

يعرض هذا الكود C++ كيفية إنشاء مخطط خطي:
```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```


افتراضيًا، يتم ربط نقاط المخطط الخطي بخطوط مستقيمة مستمرة. إذا رغبت في ربط النقاط بخطوط متقطعة بدلاً من ذلك، يمكنك تحديد نوع الخط المتقطع المفضل بهذه الطريقة:
```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```


### **إنشاء مخططات شجرية**
مخططات شجرية تُستخدم بشكل أفضل لبيانات المبيعات عندما تريد إظهار الحجم النسبي لفئات البيانات وجذب الانتباه بسرعة إلى العناصر التي تساهم كثيرًا في كل فئة. 

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (في هذه الحالة، `ChartType.TreeMap`). 
1. الوصول إلى بيانات المخطط IChartDataWorkbook. 
1. مسح السلاسل والفئات الافتراضية. 
1. إضافة سلاسل وفئات جديدة. 
1. إضافة بيانات مخطط جديدة لسلسلة المخطط. 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX 

يعرض هذا الكود C++ كيفية إنشاء مخطط شجري:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/TreemapChart_out.pptx";

	// ينشئ كائنًا من فئة Presentation الذي يمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// يصل إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// الفرع 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// الفرع 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

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

	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات أسهم**
1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.OpenHighLowClose). 
1. الوصول إلى بيانات المخطط IChartDataWorkbook. 
1. مسح السلاسل والفئات الافتراضية. 
1. إضافة سلاسل وفئات جديدة. 
1. إضافة بيانات مخطط جديدة لسلسلة المخطط. 
1. تحديد تنسيق HiLowLines. 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX 

عينة كود C++ لإنشاء مخطط أسهم:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/AddStockChart_out.pptx";

	// إنشاء كائن من فئة Presentation يمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط ببيانات افتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// تعيين الفهرس لورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة عمل بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// إضافة الفئات
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Open")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"High")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Low")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Close")), chart->get_Type());


	// أخذ السلسلة الأولى للمخطط
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// ملء بيانات السلسلة الأولى
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// ملء بيانات السلسلة الثانية
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// ملء بيانات السلسلة الثانية
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// ملء بيانات السلسلة الثانية
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

	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات الصندوق والشارب**
1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.BoxAndWhisker). 
1. الوصول إلى بيانات المخطط IChartDataWorkbook. 
1. مسح السلاسل والفئات الافتراضية. 
1. إضافة سلاسل وفئات جديدة. 
1. إضافة بيانات مخطط جديدة لسلسلة المخطط. 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX 

يعرض هذا الكود C++ كيفية إنشاء مخطط الصندوق والشارب:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// إنشاء كائن من فئة Presentation يمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::BoxAndWhisker, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 1")));

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


	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات القمع**
1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.Funnel). 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX 

يعرض هذا الكود C++ كيفية إنشاء مخطط قمع:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/FunnelChart_out.pptx";

	//إنشاء كائن من فئة Presentation يمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Funnel, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Category 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Category 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Category 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Category 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Category 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Category 6")));

	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(Aspose::Slides::Charts::ChartType::Funnel);

	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B1", System::ObjectExt::Box<int32_t>(50)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B2", System::ObjectExt::Box<int32_t>(100)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B3", System::ObjectExt::Box<int32_t>(200)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B4", System::ObjectExt::Box<int32_t>(300)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B5", System::ObjectExt::Box<int32_t>(400)));
	series->get_DataPoints()->AddDataPointForFunnelSeries(wb->GetCell(0, u"B6", System::ObjectExt::Box<int32_t>(500)));


	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات شمسية**
1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (في هذه الحالة، `ChartType.sunburst`). 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX 

يعرض هذا الكود C++ كيفية إنشاء مخطط شمسي:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// الفرع 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// الفرع 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Leaf5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Leaf6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Leaf7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Leaf8")));

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

	// حفظ ملف العرض التقديمي إلى القرص
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات تكرارية**
1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (`ChartType.Histogram` في هذه الحالة). 
1. الوصول إلى بيانات المخطط `IChartDataWorkbook`. 
1. مسح السلاسل والفئات الافتراضية. 
1. إضافة سلاسل وفئات جديدة. 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX. 

يعرض هذا الكود C++ كيفية إنشاء مخطط تكراري:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// إنشاء كائن من فئة Presentation يمثل ملف PPTX
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

	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات رادارية**
1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات معينة وتحديد نوع المخطط المفضل (`ChartType.Radar` في هذه الحالة). 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX 

يعرض هذا الكود C++ كيفية إنشاء مخطط راداري:
```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات متعددة الفئات**
1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation). 
1. الحصول على مرجع الشريحة عبر فهرستها. 
1. إضافة مخطط ببيانات افتراضية مع النوع المطلوب (ChartType.ClusteredColumn). 
1. الوصول إلى بيانات المخطط IChartDataWorkbook. 
1. مسح السلاسل والفئات الافتراضية. 
1. إضافة سلاسل وفئات جديدة. 
1. إضافة بيانات مخطط جديدة لسلسلة المخطط. 
1. حفظ العرض التقديمي المعدل إلى ملف PPTX. 

يعرض هذا الكود C++ كيفية إنشاء مخطط متعدد الفئات:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الوصول إلى الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة مخطط ببيانات افتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// تعيين الفهرس لورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة عمل بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// مسح دفتر العمل
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// إضافة الفئات
	SharedPtr<IChartCategory> category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c2", ObjectExt::Box<System::String>(u"A")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group1"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c3", ObjectExt::Box<System::String>(u"B")));
	
	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c4", ObjectExt::Box<System::String>(u"C")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group2"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c5", ObjectExt::Box<System::String>(u"D")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c6", ObjectExt::Box<System::String>(u"E")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group3"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c7", ObjectExt::Box<System::String>(u"F")));


	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c8", ObjectExt::Box<System::String>(u"G")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Group4"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c9", ObjectExt::Box<System::String>(u"H")));

	// إضافة سلسلة جديدة
	SharedPtr<IChartSeries>  series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(0, u"D1", ObjectExt::Box<System::String>(u"Series 1")),
		ChartType::ClusteredColumn);

	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D2", ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D3", ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D4", ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D5", ObjectExt::Box<double>(40)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D6", ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D7", ObjectExt::Box<double>(60)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D8", ObjectExt::Box<double>(70)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, u"D9", ObjectExt::Box<double>(80)));

	// حفظ العرض التقديمي
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **إنشاء مخططات خريطة**
مخطط الخريطة هو تصور لمنطقة تحتوي على بيانات. تُستخدم مخططات الخريطة بشكل أفضل لمقارنة البيانات أو القيم عبر المناطق الجغرافية. 

يعرض هذا الكود C++ كيفية إنشاء مخطط خريطة:
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```


### **إنشاء مخططات مركبة**
مخطط مركب (أو مخطط مشترك) يجمع نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح لك هذا المخطط إبراز أو مقارنة أو فحص الفروق بين مجموعتين أو أكثر من البيانات، مما يساعدك على تحديد العلاقات بينها. 

![The combination chart](combination_chart.png)

يعرض الكود C++ التالي كيفية إنشاء المخطط المركب الموضح أعلاه في عرض PowerPoint:
```cpp
static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // تعيين عنوان المخطط.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // تعيين وسيلة إيضاح المخطط.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // حذف السلاسل والفئات التي تم إنشاؤها افتراضيًا.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // إضافة فئات جديدة.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // إضافة السلسلة الأولى.
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<double>(4.3)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));

    return chart;
}

static void AddSecondSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::ClusteredColumn);

    series->get_ParentSeriesGroup()->set_Overlap(-25);
    series->get_ParentSeriesGroup()->set_GapWidth(220);

    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<double>(2.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<double>(4.4)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<double>(1.8)));
    series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 2, ObjectExt::Box<double>(2.8)));
}

static void AddThirdSeriesToChart(SharedPtr<IChart> chart)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    const int worksheetIndex = 0;

    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, ObjectExt::Box<String>(u"Series 3"));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, ChartType::Line);

    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 1, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 2, 3, ObjectExt::Box<double>(2.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 3, 3, ObjectExt::Box<double>(3.0)));
    series->get_DataPoints()->AddDataPointForLineSeries(workbook->GetCell(worksheetIndex, 4, 3, ObjectExt::Box<double>(5.0)));

    series->set_PlotOnSecondAxis(true);
}

static void SetAxisTitle(SharedPtr<IAxis> axis, String axisTitle)
{
    axis->set_HasTitle(true);
    axis->get_Title()->set_Overlay(false);
    auto titleParagraph = axis->get_Title()->AddTextFrameForOverriding(axisTitle)->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(12.0);
}

static void SetPrimaryAxesFormat(SharedPtr<IChart> chart)
{
    // تعيين المحور الأفقي.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // تعيين المحور العمودي.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // تعيين لون خطوط الشبكة العمودية الرئيسية.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // تعيين المحور الأفقي الثانوي.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // تعيين المحور العمودي الثانوي.
    auto secondaryVerticalAxis = chart->get_Axes()->get_SecondaryVerticalAxis();
    secondaryVerticalAxis->set_Position(AxisPositionType::Right);
    secondaryVerticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    secondaryVerticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryVerticalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(secondaryVerticalAxis, u"Y Axis 2");
}

static void CreateComboChart()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto chart = CreateChartWithFirstSeries(slide);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation->Save(u"combo-chart.pptx", SaveFormat::Pptx);
    presentation->Dispose();
}
```


## **تحديث المخططات**

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) التي تمثل العرض التقديمي المحتوي على المخطط. 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. استعراض جميع الأشكال للعثور على المخطط المطلوب. 
4. الوصول إلى ورقة عمل بيانات المخطط. 
5. تعديل بيانات سلسلة المخطط بتغيير قيم السلسلة. 
6. إضافة سلسلة جديدة وتعبئة البيانات فيها. 
7. حفظ العرض التقديمي المعدل كملف PPTX. 

يعرض هذا الكود C++ كيفية تحديث مخطط:
```c++
// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// الوصول إلى الشريحة الأولى
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// يضيف مخططًا ببيانات افتراضية
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// تعيين الفهرس لورقة بيانات المخطط
int32_t defaultWorksheetIndex = 0;

// الحصول على ورقة عمل بيانات المخطط
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// تغيير اسم فئة المخطط
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Modified Category 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Modified Category 2"));

// الحصول على السلسلة الأولى للمخطط
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// تحديث بيانات السلسلة
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"New_Series1"));
// تعديل اسم السلسلة
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// الحصول على السلسلة الثانية للمخطط
series = chart->get_ChartData()->get_Series()->idx_get(1);

// الآن يتم تحديث بيانات السلسلة
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// تعديل اسم السلسلة
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// الآن، إضافة سلسلة جديدة
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// الحصول على السلسلة الثالثة للمخطط
series = chart->get_ChartData()->get_Series()->idx_get(2);

// الآن يتم تعبئة بيانات السلسلة
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// حفظ العرض التقديمي مع المخطط
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **تعيين نطاق البيانات للمخططات**

1. فتح مثال من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) التي تحتوي على المخطط. 
2. الحصول على مرجع الشريحة عبر فهرستها. 
3. استعراض جميع الأشكال للعثور على المخطط المطلوب. 
4. الوصول إلى بيانات المخطط وتحديد النطاق. 
5. حفظ العرض التقديمي المعدل كملف PPTX. 

يعرض هذا الكود C++ كيفية تعيين نطاق البيانات لمخطط:
```cpp
// مسار دليل المستندات.
String dataDir = GetDataPath();

// ينشئ كائنًا من فئة Presentation يمثل ملف PPTX
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// الوصول إلى الشريحة الأولى وإضافة مخطط ببيانات افتراضية
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```


## **استخدام العلامات الافتراضية في المخططات**
عند استخدام علامة افتراضية في المخططات، يحصل كل سلسلة مخطط على رموز علامة افتراضية مختلفة تلقائيًا. 

يعرض هذا الكود C++ كيفية تعيين علامة سلسلة مخطط تلقائيًا:
```cpp
// مسار دليل المستندات.
String dataDir = GetDataPath();

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 10.0f, 10.0f, 400.0f, 400.0f);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 1, 0, ObjectExt::Box<String>(u"C1")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(24)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 2, 0, ObjectExt::Box<String>(u"C2")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(23)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 3, 0, ObjectExt::Box<String>(u"C3")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-10)));
chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, 4, 0, ObjectExt::Box<String>(u"C4")));
series->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 1, nullptr));

chart->get_ChartData()->get_Series()->Add(wb->GetCell(0, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// يأخذ السلسلة الثانية للمخطط
auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

// ملء بيانات السلسلة
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

chart->set_HasLegend(true);
chart->get_Legend()->set_Overlay(false);

pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```


## **الأسئلة المتكررة**

**ما هي أنواع المخططات التي يدعمها Aspose.Slides؟**

يدعم Aspose.Slides مجموعة واسعة من أنواع المخططات، بما في ذلك المخططات الشريطية، الخطية، الدائرية، المساحية، المبعثرة، التكرارية، الرادارية، وغيرها الكثير. هذه المرونة تتيح لك اختيار النوع الأنسب لتصوير بياناتك.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، أولاً تُنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)، ثم تُسترجع الشريحة المطلوبة باستخدام فهرستها، ثم تستدعي الطريقة لإضافة مخطط مع تحديد نوع المخطط والبيانات الأولية. يدمج هذا المخطط مباشرةً في عرضك التقديمي.

**كيف يمكنني تحديث البيانات المعروضة في المخطط؟**

يمكنك تحديث بيانات المخطط بالوصول إلى دفتر عمل البيانات الخاص به ([IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/))، ثم مسح أي سلاسل وفئات افتراضية، ثم إضافة البيانات المخصصة الخاصة بك. يتيح لك ذلك تحديث المخطط برمجيًا ليعكس أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، يوفر Aspose.Slides خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، التسميات، وسيلة الإيضاح، وغيرها من عناصر التنسيق لتكييف مظهر المخطط وفقًا لمتطلبات التصميم الخاصة بك.