---
title: Hantera diagramdataetiketter i presentationer med C++
linktitle: Dataetikett
type: docs
url: /sv/cpp/chart-data-label/
keywords:
- diagram
- dataetikett
- dataprecision
- procentandel
- etikettavstånd
- etikettposition
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig lägga till och formatera diagramdataetiketter i PowerPoint-presentationer med Aspose.Slides för C++ för mer engagerande bildspel."
---
## **Introduktion**

Dataetiketter på ett diagram visar detaljer om diagrammets dataserier eller enskilda datapunkter. De gör det möjligt för läsare att snabbt identifiera dataserier och de gör också diagrammen lättare att förstå.

## **Ställ in dataprecision i diagramdataetiketter**

Den här C++-koden visar hur du ställer in dataprecision i en diagramdataetikett:

```c++
	// Sökvägen till dokumentkatalogen
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Skapar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Lägger till diagram med standarddata
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Ställer in serienummerformat
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Skriver presentationsfilen till disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Visa procent som etiketter**
Aspose.Slides för C++ låter dig ange procentetiketter på visade diagram. Den här C++-koden demonstrerar hur det görs:

```c++
	// Sökvägen till dokumentkatalogen
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Skapar en instans av Presentation-klassen
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

	// Sparar presentationen som innehåller diagrammet
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ange procenttecknet i diagramdataetiketter**
Den här C++-koden visar hur du anger procenttecknet för en diagramdataetikett:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Skapar en instans av Presentation-klassen
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar en bilds referens via dess index
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Skapar diagrammet PercentsStackedColumn på en bild
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Sätter NumberFormatLinkedToSource till false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Anger index för diagrammets dataark
	int defaultWorksheetIndex = 0;

	// Hämtar diagrammets dataarbetsblad
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Tar bort standardgenererad serie 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Lägger till en ny serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Hämtar den första diagramserien
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Fyller seriedatan
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Anger fyllnadsfärg för serien
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Anger egenskaper för LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Hämtar den andra diagramserien
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Fyller seriedatan
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Anger fyllnadsfärg för serien
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Anger egenskaper för LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Skriver presentationsfilen till disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ange etikettavstånd från axel**
Den här C++-koden visar hur du ställer in etikettavståndet från en kategoriekel när du arbetar med ett diagram som ritas från axlar:

```c++
	// Sökvägen till dokumentkatalogen
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Skapar en instans av Presentation-klassen
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar en bilds referens
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Skapar ett diagram på bilden
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Hämtar samlingen av diagramserier
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Ställer in etikettavståndet från en axel
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Skriver presentationsfilen till disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Justera etikettposition**

När du skapar ett diagram som inte är beroende av någon axel, som ett pajdiagram, kan diagrammets dataetiketter hamna för nära kanten. I så fall måste du justera etikettens placering så att hjälplinjerna visas tydligt.

Den här C++-koden visar hur du justerar etikettplaceringen på ett pajdiagram:

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

## **Vanliga frågor**

**Hur kan jag förhindra att dataetiketter överlappar i täta diagram?**

Kombinera automatisk placering av etiketter, hjälplinjer och minskad teckenstorlek; om det behövs, dölj vissa fält (t.ex. kategorin) eller visa etiketter endast för extrema/nyckelpunkter.

**Hur kan jag inaktivera etiketter bara för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan du aktiverar etiketter och stäng av visning för värden på 0, negativa värden eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettstil vid export till PDF/bilder?**

Ange explicit teckensnitt (familj, storlek) och verifiera att teckensnittet är tillgängligt på renderingssidan för att undvika fallback.