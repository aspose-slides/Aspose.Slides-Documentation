---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट डेटा लेबल प्रबंधित करें
linktitle: डेटा लेबल
type: docs
url: /hi/cpp/chart-data-label/
keywords:
- चार्ट
- डेटा लेबल
- डेटा सटीकता
- प्रतिशत
- लेबल दूरी
- लेबल स्थान
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा लेबल जोड़ने और फ़ॉर्मेट करने के बारे में जानें, जिससे अधिक आकर्षक स्लाइड्स बनें।"
---
## **परिचय**

डेटा लेबल्स चार्ट पर डेटा श्रृंखला या व्यक्तिगत डेटा बिंदुओं के बारे में विवरण दिखाते हैं। वे पाठकों को जल्दी से डेटा श्रृंखला पहचानने में मदद करते हैं और चार्ट को समझना आसान बनाते हैं।

## **चार्ट डेटा लेबल्स में डेटा सटीकता सेट करें**

यह C++ कोड दिखाता है कि चार्ट डेटा लेबल में डेटा सटीकता कैसे सेट करें:

```c++
	// डॉक्यूमेंट्स निर्देशिका का पथ
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का instance बनाता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// पहली स्लाइड प्राप्त करता है
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ता है
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// सीरीज़ संख्या प्रारूप सेट करता है
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// प्रेजेंटेशन फ़ाइल को डिस्क में लिखता है
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **लेबल्स के रूप में प्रतिशत दिखाएँ**
Aspose.Slides for C++ आपको प्रदर्शित चार्ट्स पर प्रतिशत लेबल सेट करने की अनुमति देता है। यह C++ कोड इस ऑपरेशन को दर्शाता है:

```c++
	// डॉक्यूमेंट्स निर्देशिका का पथ
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Presentation क्लास का instance बनाता है
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

	// चार्ट युक्त प्रेजेंटेशन को सहेजता है
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **चार्ट डेटा लेबल्स के साथ प्रतिशत चिह्न सेट करें**
यह C++ कोड दिखाता है कि चार्ट डेटा लेबल के लिए प्रतिशत चिह्न कैसे सेट करें:

```c++
	// डॉक्यूमेंट्स निर्देशिका का पथ।
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Presentation क्लास का एक instance बनाता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करता है
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// स्लाइड पर PercentsStackedColumn चार्ट बनाता है
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// NumberFormatLinkedToSource को false सेट करता है
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// चार्ट डेटा शीट का इंडेक्स सेट करता है
	int defaultWorksheetIndex = 0;

	// चार्ट डेटा वर्कशीट प्राप्त करता है
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// डिफ़ॉल्ट जेनरेटेड सीरीज़ को हटाता है
	chart->get_ChartData()->get_Series()->Clear();
	

	// एक नई सीरीज़ जोड़ता है
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// पहली चार्ट सीरीज़ लेता है
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// सीरीज़ डेटा को भरता है
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// सीरीज़ के लिए फ़िल कलर सेट करता है
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// LabelFormat प्रॉपर्टीज़ सेट करता है
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// दूसरी चार्ट सीरीज़ लेता है
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// सीरीज़ डेटा को भरता है
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// सीरीज़ के लिए फ़िल कलर सेट करता है
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// LabelFormat प्रॉपर्टीज़ सेट करता है
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// प्रेजेंटेशन फ़ाइल को डिस्क में लिखता है
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **अक्ष से लेबल दूरी सेट करें**
यह C++ कोड दिखाता है कि जब आप अक्षों से बना चार्ट प्लॉट कर रहे हों तो श्रेणी अक्ष से लेबल दूरी कैसे सेट करें:

```c++
	// डॉक्यूमेंट्स निर्देशिका का पथ
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Presentation क्लास का एक instance बनाता है
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// स्लाइड का संदर्भ प्राप्त करता है
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// स्लाइड पर चार्ट बनाता है
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// चार्ट सीरीज़ कलेक्शन प्राप्त करता है
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// अक्ष से लेबल दूरी सेट करता है
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// प्रेजेंटेशन फ़ाइल को डिस्क में लिखता है
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **लेबल स्थान समायोजित करें**

जब आप ऐसा चार्ट बनाते हैं जो किसी भी अक्ष पर निर्भर नहीं करता है, जैसे पाई चार्ट, तो चार्ट के डेटा लेबल्स उसके किनारे के बहुत पास हो सकते हैं। ऐसे मामले में, आपको डेटा लेबल का स्थान समायोजित करना पड़ता है ताकि लीडर लाइन्स स्पष्ट रूप से दिखाई दें।

यह C++ कोड दिखाता है कि पाई चार्ट पर लेबल स्थान कैसे समायोजित करें:

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

![पाई-चार्ट-समायोजित-लेबल](pie-chart-adjusted-label.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**घनी चार्ट्स में डेटा लेबल्स के ओवरलैप को कैसे रोकें?**

स्वचालित लेबल प्लेसमेंट, लीडर लाइन्स, और फ़ॉन्ट आकार को घटाकर संयोजन करें; यदि आवश्यक हो तो कुछ फ़ील्ड (जैसे श्रेणी) को छिपाएँ या केवल चरम/मुख्य बिंदुओं के लिए लेबल दिखाएँ।

**शून्य, नकारात्मक, या खाली मानों के लिए लेबल केवल कैसे निष्क्रिय करें?**

लेबल्स सक्षम करने से पहले डेटा पॉइंट्स को फ़िल्टर करें और परिभाषित नियम के अनुसार 0, नकारात्मक या अनुपलब्ध मानों के लिए डिस्प्ले बंद करें।

**PDF/इमेज में निर्यात करने पर लेबल शैली निरंतर कैसे रखें?**

फ़ॉन्ट (परिवार, आकार) को स्पष्ट रूप से सेट करें और रेंडरिंग पक्ष पर फ़ॉन्ट उपलब्ध है यह सत्यापित करें ताकि फॉलबैक न हो।