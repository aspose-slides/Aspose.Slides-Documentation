---
title: Hantera diagramdataetiketter i presentationer med С++
linktitle: Dataetikett
type: docs
url: /sv/cpp/chart-data-label/
keywords:
- diagram
- dataetikett
- dataprecision
- procent
- etikettavstånd
- etikettplacering
- PowerPoint
- presentation
- С++
- Aspose.Slides
description: "Lär dig att lägga till och formatera diagramdataetiketter i PowerPoint-presentationer med Aspose.Slides för С++ för mer engagerande bilder."
---
## **Introduktion**

Datalabels på ett diagram visar detaljer om diagrammets dataserier eller enskilda datapunkter. De gör det möjligt för läsaren att snabbt identifiera dataserier och gör diagrammen lättare att förstå.

## **Ställ in dataprecision i diagrammets datalabels**

Den här C++-koden visar hur du anger dataprecision i en diagramdatapunktlabel:

```c++
	// Sökvägen till dokumentkatalogen
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Instansierar en Presentation-klass som representerar en PPTX-fil
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar den första bilden
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Lägger till diagram med standarddata
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Ställer in talformat för serien
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Skriver presentationsfilen till disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Visa procenttal som etiketter**
Aspose.Slides for C++ låter dig ange procentetiketter på diagram som visas. Den här C++-koden demonstrerar hur du gör det:

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


## **Ställ in procenttecken med diagrammets datalabels**
Den här C++-koden visar hur du ställer in procenttecken för en diagramdatapunktlabel:

```c++
	// Sökvägen till dokumentkatalogen.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Skapar en instans av Presentation-klassen
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar en slides referens via dess index
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Skapar diagrammet PercentsStackedColumn på en slide
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Ställer in NumberFormatLinkedToSource till false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Ställer in index för diagrammets kalkylblad
	int defaultWorksheetIndex = 0;

	// Hämtar diagrammets dataarbetsbok
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Tar bort standardgenererade serier 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Lägger till en ny serie
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Hämtar den första diagramserien
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Fyller serien med data
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Ställer in fyllningsfärg för serien
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Ställer in LabelFormat-egenskaper
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Hämtar den andra diagramserien
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Fyller serien med data
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Ställer in fyllningsfärg för serien
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Ställer in LabelFormat-egenskaper
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


## **Ställ in etikettdistans från axeln**
Den här C++-koden visar hur du anger etikettdistansen från en kategoraxel när du arbetar med ett diagram som ritas från axlar:

```c++
	// Sökvägen till dokumentkatalogen
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Skapar en instans av Presentation-klassen
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Hämtar en bilds referens
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Skapar ett diagram på bilden
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Hämtar diagrammets seriekollektion
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Ställer in etikettavståndet från en axel
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Skriver presentationsfilen till disk
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Justera etikettplacering**

När du skapar ett diagram som inte bygger på någon axel, till exempel ett cirkeldiagram, kan diagrammets datalabels hamna för nära kanten. I så fall måste du justera etikettens placering så att ledlinjerna visas tydligt.

Den här C++-koden visar hur du justerar etikettplaceringen i ett cirkeldiagram:

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

## **FAQ**

**Hur kan jag förhindra att datalabels överlappar i täta diagram?**

Kombinera automatisk placering av etiketter, ledlinjer och minskad teckenstorlek; vid behov dölja vissa fält (t.ex. kategori) eller visa etiketter endast för extrema/nyckelpunkter.

**Hur kan jag inaktivera etiketter endast för noll-, negativa eller tomma värden?**

Filtrera datapunkter innan du aktiverar etiketter och stäng av visning för värden som är 0, negativa värden eller saknade värden enligt en definierad regel.

**Hur kan jag säkerställa en konsekvent etikettdesign vid export till PDF/bilder?**

Ange tydligt teckensnitt (familj, storlek) och verifiera att teckensnittet finns tillgängligt på renderingssidan för att undvika ersättning.