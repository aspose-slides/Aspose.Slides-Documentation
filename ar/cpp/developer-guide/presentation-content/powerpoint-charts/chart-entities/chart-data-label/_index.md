---
title: إدارة تسميات بيانات المخطط في العروض التقديمية باستخدام C++
linktitle: تسمية البيانات
type: docs
url: /ar/cpp/chart-data-label/
keywords:
- مخطط
- تسمية البيانات
- دقة البيانات
- النسبة المئوية
- مسافة التسمية
- موضع التسمية
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ C++ لإنشاء شرائح أكثر تفاعلاً."
---

تُظهر تسميات البيانات في المخطط تفاصيل حول سلسلة بيانات المخطط أو نقاط البيانات الفردية. فهي تسمح للقراء بتحديد سلسلة البيانات بسرعة وتُسهِّل أيضًا فهم المخططات.

## **ضبط دقة البيانات في تسميات بيانات المخطط**
هذا الكود C++ يوضح لك كيفية ضبط دقة البيانات في تسمية بيانات المخطط:
```c++
	// مسار دليل المستندات
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// ينشئ كائن من فئة Presentation التي تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// يحصل على الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// يضيف مخططًا ببيانات افتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// يضبط تنسيق أرقام السلسلة
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// يحفظ ملف العرض التقديمي على القرص
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```



## **عرض النسب المئوية كتسميات**
تتيح لك Aspose.Slides للـ C++ تعيين تسميات النسبة المئوية على المخططات المعروضة. يوضح هذا الكود C++ العملية:
```c++
	// مسار دليل المستندات
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// إنشاء مثيل لفئة Presentation
	System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

	System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);
	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::StackedColumn, 20, 20, 400, 400);
	System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	System::SharedPtr<IChartCategory> cat;
	System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(chart->get_ChartData()->get_Categories()->get_Count(), 0);
	for (int32_t k = 0; k < chart->get_ChartData()->get_Categories()->get_Count(); k++)
	{
		cat = chart->get_ChartData()->get_Categories()->idx_get(k);

		for (int32_t i = 0; i < chart->get_ChartData()->get_Series()->get_Count(); i++)
		{
			total_for_Cat[k] = total_for_Cat[k] + System::Convert::ToDouble(chart->get_ChartData()->get_Series()->idx_get(i)->get_DataPoints()->idx_get(k)->get_Value()->get_Data());
		}
	}

	double dataPontPercent = 0.f;

	for (int32_t x = 0; x < chart->get_ChartData()->get_Series()->get_Count(); x++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(x);
		series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLegendKey(false);

		for (int32_t j = 0; j < series->get_DataPoints()->get_Count(); j++)
		{
			System::SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(j)->get_Label();
			dataPontPercent = (System::Convert::ToDouble(series->get_DataPoints()->idx_get(j)->get_Value()->get_Data()) / total_for_Cat[j]) * 100;

			System::SharedPtr<IPortion> port = System::MakeObject<Portion>();
			port->set_Text(System::String::Format(u"{0:F2} %", dataPontPercent));
			port->get_PortionFormat()->set_FontHeight(8.f);
			lbl->get_TextFrameForOverriding()->set_Text(u"");
			System::SharedPtr<IParagraph> para = lbl->get_TextFrameForOverriding()->get_Paragraphs()->idx_get(0);
			para->get_Portions()->Add(port);

			lbl->get_DataLabelFormat()->set_ShowSeriesName(false);
			lbl->get_DataLabelFormat()->set_ShowPercentage(false);
			lbl->get_DataLabelFormat()->set_ShowLegendKey(false);
			lbl->get_DataLabelFormat()->set_ShowCategoryName(false);
			lbl->get_DataLabelFormat()->set_ShowBubbleSize(false);
		}
	}

	// حفظ العرض التقديمي الذي يحتوي على المخطط
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **ضبط علامة النسبة المئوية في تسميات بيانات المخطط**
هذا الكود C++ يوضح لك كيفية ضبط علامة النسبة المئوية لتسمية بيانات المخطط:
```c++
	// مسار دليل المستندات.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// إنشاء مثيل لفئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الحصول على مرجع الشريحة عبر فهرسها
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إنشاء مخطط PercentsStackedColumn على شريحة
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// تعيين NumberFormatLinkedToSource إلى false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// تعيين فهرس ورقة بيانات المخطط
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة عمل بيانات المخطط
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// حذف السلسلة المُنشأة افتراضيًا 
	chart->get_ChartData()->get_Series()->Clear();
	

	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// أخذ أول سلسلة في المخطط
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// تعبئة بيانات السلسلة
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// تعيين لون التعبئة للسلسلة
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// تعيين خصائص LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// أخذ السلسلة الثانية في المخطط
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// تعبئة بيانات السلسلة
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// تعيين لون التعبئة للسلسلة
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// تعيين خصائص LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// حفظ ملف العرض التقديمي على القرص
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **ضبط مسافة التسمية عن المحور**
هذا الكود C++ يوضح لك كيفية ضبط مسافة التسمية عن محور الفئة عندما تتعامل مع مخطط مرسوم من المحاور:
```c++
	// مسار دليل المستندات
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// إنشاء مثيل لفئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الحصول على مرجع الشريحة
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إنشاء مخطط على الشريحة
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// الحصول على مجموعة سلاسل المخطط
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// تعيين مسافة التسمية من المحور
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// حفظ ملف العرض التقديمي على القرص
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **ضبط موقع التسمية**
عند إنشاء مخطط لا يعتمد على أي محور مثل مخطط الفطيرة، قد تكون تسميات البيانات في المخطط قريبة جدًا من حافته. في هذه الحالة، يجب عليك ضبط موقع تسمية البيانات لتظهر خطوط الربط بوضوح.
هذا الكود C++ يوضح لك كيفية ضبط موقع التسمية في مخطط الفطيرة:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> chart = pres->get_Slide(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 200.0f, 200.0f);

System::SharedPtr<IChartSeriesCollection> series = chart->get_ChartData()->get_Series();
System::SharedPtr<IDataLabel> label = series->idx_get(0)->get_Label(0);
System::SharedPtr<IDataLabelFormat> dataLabelFormat = label->get_DataLabelFormat();

dataLabelFormat->set_ShowValue(true);
dataLabelFormat->set_Position(LegendDataLabelPosition::OutsideEnd);
label->set_X(0.71f);
label->set_Y(0.04f);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **الأسئلة المتكررة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات الكثيفة؟**
استخدم وضعية توضع التسميات تلقائيًا، خطوط الربط، وتصغير حجم الخط؛ إذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للنقاط المتطرفة/المهمة.

**كيف يمكنني تعطيل التسميات للقيم الصفرية أو السالبة أو الفارغة فقط؟**
قوم بفلترة نقاط البيانات قبل تمكين التسميات وأطفئ العرض للقيم الصفرية أو السالبة أو القيم المفقودة وفقًا لقاعدة محددة.

**كيف يمكنني ضمان نمط تسميات ثابت عند التصدير إلى PDF/صور؟**
قم بتحديد الخطوط (العائلة، الحجم) صراحةً وتأكد من توافر الخط على جانب العرض لتجنب الاستبدال.