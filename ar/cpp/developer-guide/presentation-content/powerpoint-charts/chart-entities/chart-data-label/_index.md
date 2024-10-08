---
title: تسميات بيانات الرسم البياني
type: docs
url: /ar/cpp/chart-data-label/
keywords: "تسمية بيانات الرسم البياني، مسافة التسمية، C++، CPP، Aspose.Slides لـ C++"
description: "ضبط تسميات بيانات الرسم البياني والمسافة في C++"
---

تظهر تسميات البيانات في الرسم البياني تفاصيل حول سلسلة بيانات الرسم البياني أو نقاط البيانات الفردية. تتيح للقراء التعرف بسرعة على سلسلات البيانات كما تجعل الرسوم البيانية أسهل في الفهم.

## **ضبط دقة البيانات في تسمية بيانات الرسم البياني**

يوضح هذا الرمز في C++ كيفية ضبط دقة البيانات في تسمية بيانات الرسم البياني:

```c++
	// المسار إلى دليل الوثائق
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// إنشاء كائن من فئة Presentation التي تمثل ملف PPTX
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الحصول على الشريحة الأولى
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إضافة رسم بياني مع بيانات افتراضية
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// ضبط تنسيق رقم السلسلة
	chart->set_HasDataTable(true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues(u"#,##0.00");

	// كتابة ملف العرض إلى القرص
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **عرض النسبة المئوية كعلامات**
يسمح Aspose.Slides لـ C++ بضبط تسميات النسبة المئوية على الرسوم البيانية المعروضة. يوضح هذا الرمز في C++ العملية:

```c++
	// المسار إلى دليل الوثائق
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// إنشاء كائن من فئة Presentation
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

	// حفظ العرض الذي يحتوي على الرسم البياني
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **ضبط علامة النسبة المئوية مع تسمية بيانات الرسم البياني**
يوضح هذا الرمز في C++ كيفية ضبط علامة النسبة المئوية لتسمية بيانات الرسم البياني:

```c++
	// المسار إلى دليل الوثائق.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// إنشاء كائن من فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الحصول على مرجع الشريحة من خلال الفهرس
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إنشاء الرسم البياني من نوع PercentsStackedColumn على الشريحة
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// ضبط NumberFormatLinkedToSource على false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// ضبط فهرس ورقة بيانات الرسم البياني
	int defaultWorksheetIndex = 0;

	// الحصول على ورقة بيانات الرسم البياني
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// حذف السلاسل التي تم توليدها بشكل افتراضي 
	chart->get_ChartData()->get_Series()->Clear();
	

	// إضافة سلسلة جديدة
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// أخذ السلسلة الأولى للرسم البياني
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// تعبئة بيانات السلسلة
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// ضبط لون التعبئة للسلسلة
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// ضبط خصائص LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// أخذ السلسلة الثانية للرسم البياني
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// تعبئة بيانات السلسلة
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// ضبط لون التعبئة للسلسلة
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// ضبط خصائص LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// كتابة ملف العرض إلى القرص
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **ضبط مسافة التسمية من المحور**
يوضح هذا الرمز في C++ كيفية ضبط مسافة التسمية من محور الفئة عند التعامل مع رسم بياني مرسوم من المحاور:

```c++
	// المسار إلى دليل الوثائق
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// إنشاء كائن من فئة Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// الحصول على مرجع الشريحة
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// إنشاء رسم بياني على الشريحة
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// الحصول على مجموعة سلاسل الرسم البياني
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// ضبط مسافة التسمية من محور
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset(500);

	// كتابة ملف العرض إلى القرص
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ضبط موقع التسمية**

عندما تقوم بإنشاء رسم بياني لا يعتمد على أي محور مثل الرسم البياني الدائري، قد تنتهي تسميات بيانات الرسم البياني قريباً جداً من حافته. في هذه الحالة، تحتاج إلى ضبط موقع تسمية البيانات بحيث تظهر خطوط القيادة بوضوح.

يوضح هذا الرمز في C++ كيفية ضبط موقع التسمية في الرسم البياني الدائري:

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