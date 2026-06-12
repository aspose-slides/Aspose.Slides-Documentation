---
title: Beheer diagramgegevenslabels in presentaties met С++
linktitle: Gegevenslabel
type: docs
url: /nl/cpp/chart-data-label/
keywords:
- diagram
- gegevenslabel
- gegevensprecisie
- percentage
- labelafstand
- labellocatie
- PowerPoint
- presentatie
- С++
- Aspose.Slides
description: "Leer hoe u diagramgegevenslabels kunt toevoegen en opmaken in PowerPoint-presentaties met Aspose.Slides voor С++ voor meer boeiende dia's."
---
## **Inleiding**

Gegevenslabels op een diagram tonen details over de gegevensreeksen van het diagram of individuele gegevenspunten. Ze stellen lezers in staat om snel gegevensreeksen te identificeren en maken diagrammen bovendien beter begrijpelijk.

## **Precisie van gegevens instellen in diagramlabels**

Deze C++‑code laat zien hoe u de precisie van gegevens instelt in een diagramlabel:

```c++
	// Het pad naar de documentmap
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Instantieert een Presentation‑klasse die een PPTX‑bestand representeert
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Haal de eerste dia op
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Voegt een diagram toe met standaardgegevens
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Stelt getalnotatie voor de reeks in
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Schrijft het presentatiebestand naar schijf
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Percentages weergeven als labels**

Aspose.Slides for C++ maakt het mogelijk om percentage‑labels in weergegeven diagrammen in te stellen. Deze C++‑code demonstreert de werking:

```c++
	// Het pad naar de documentmap
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Maakt een instantie van de Presentation‑klasse
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

	// Slaat de presentatie met het diagram op
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Het procentteken instellen met diagramlabels**

Deze C++‑code laat zien hoe u het procentteken instelt voor een diagramlabel:

```c++
	// Het pad naar de documentmap.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Maakt een instantie van de Presentation‑klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Haalt een referentie naar een dia op via de index
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Maakt het PercentsStackedColumn‑diagram op een dia
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Stelt NumberFormatLinkedToSource in op false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Stelt de index van het diagramgegevensblad in
	int defaultWorksheetIndex = 0;

	// Haalt het werkblad met diagramgegevens op
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Verwijdert de standaard gegenereerde reeks 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Voegt een nieuwe reeks toe
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Neemt de eerste diagramreeks
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Vult de gegevens van de reeks
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Stelt de vulkleur voor de reeks in
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Stelt LabelFormat‑eigenschappen in
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Neemt de tweede diagramreeks
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Vult de gegevens van de reeks
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Stelt de vulkleur voor de reeks in
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Stelt LabelFormat‑eigenschappen in
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Schrijft het presentatiebestand naar schijf
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Labelafstand tot as instellen**

Deze C++‑code laat zien hoe u de labelafstand tot een categorische as instelt wanneer u werkt met een diagram dat vanuit assen is getekend:

```c++
	// Het pad naar de documentmap
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Maakt een instantie van de Presentation-klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Haalt een referentie naar de dia op
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Maakt een diagram op de dia
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Haalt de collectie van diagramreeksen op
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Stelt de labelafstand vanaf een as in
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Schrijft het presentatiebestand naar schijf
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Labelpositie aanpassen**

Wanneer u een diagram maakt dat niet op een as steunt, zoals een cirkeldiagram, kunnen de gegevenslabels van het diagram te dicht bij de rand komen te liggen. In dat geval moet u de positie van het label aanpassen zodat de verbindingslijnen duidelijk worden weergegeven.

Deze C++‑code laat zien hoe u de labelpositie aanpast op een cirkeldiagram:

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

**Hoe kan ik voorkomen dat gegevenslabels overlappen in dichtbevolkte diagrammen?**

Combineer automatische labelplaatsing, verbindingslijnen en een verkleinde lettergrootte; verberg indien nodig enkele velden (bijvoorbeeld de categorie) of toon labels alleen voor extreme/sleutelpunten.

**Hoe kan ik labels uitschakelen voor uitsluitend nul-, negatieve of lege waarden?**

Filter gegevenspunten voordat u de labels inschakelt en schakel de weergave uit voor waarden van 0, negatieve waarden of ontbrekende waarden volgens een gedefinieerde regel.

**Hoe kan ik een consistente labelstijl garanderen bij het exporteren naar PDF/afbeeldingen?**

Stel expliciet lettertypen (familie, grootte) in en controleer dat het lettertype beschikbaar is aan de renderzijde om een fallback te vermijden.