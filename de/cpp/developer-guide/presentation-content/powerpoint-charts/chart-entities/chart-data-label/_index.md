---
title: Diagrammbeschriftungen in Präsentationen mit C++ verwalten
linktitle: Datenbeschriftung
type: docs
url: /de/cpp/chart-data-label/
keywords:
- Diagramm
- Datenbeschriftung
- Datenpräzision
- Prozentsatz
- Beschriftungsabstand
- Beschriftungsposition
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammbeschriftungen in PowerPoint-Präsentationen mit Aspose.Slides für C++ hinzufügen und formatieren, um ansprechendere Folien zu erstellen."
---

Datenbeschriftungen in einem Diagramm zeigen Details zur Diagrammdatenreihe oder zu einzelnen Datenpunkten an. Sie ermöglichen es den Lesern, Datenreihen schnell zu identifizieren, und erleichtern das Verständnis von Diagrammen.

## **Datenpräzision in Diagrammbeschriftungen festlegen**

Dieser C++-Code zeigt, wie Sie die Datenpräzision in einer Diagrammbeschriftung festlegen:
```c++
	// Der Pfad zum Dokumentenverzeichnis
	const String outPath = u"../out/SettingPrecisionOfDataLabel_out.pptx";

	// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Holt die erste Folie
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Line, 0, 0, 500, 500);

	// Legt das Zahlenformat der Serie fest
	chart->set_HasDataTable( true);
	chart->get_ChartData()->get_Series()->idx_get(0)->set_NumberFormatOfValues (u"#,##0.00");

	// Schreibt die Präsentationsdatei auf die Festplatte
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Prozentsätze als Beschriftungen anzeigen**
Aspose.Slides für C++ ermöglicht das Festlegen von Prozentbeschriftungen in angezeigten Diagrammen. Dieser C++-Code demonstriert die Vorgehensweise:
```c++
	// Der Pfad zum Dokumentenverzeichnis
	const String outPath = u"../out/DisplayPercentageAsLabels_out.pptx";

	// Erstellt eine Instanz der Presentation-Klasse
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

	// Speichert die Präsentation, die das Diagramm enthält
	presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Prozentzeichen in Diagrammbeschriftungen festlegen**
Dieser C++-Code zeigt, wie Sie das Prozentzeichen für eine Diagrammbeschriftung festlegen:
```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/DataLabelsPercentageSign_out.pptx";

	// Erstellt eine Instanz der Presentation-Klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Ermittelt die Referenz einer Folie über ihren Index
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Erstellt das PercentsStackedColumn-Diagramm auf einer Folie
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::PercentsStackedColumn, 0, 0, 500, 500);

	// Setzt NumberFormatLinkedToSource auf false
	chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource ( false);
	chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00%");


	// Setzt den Index des Diagrammdatenblatts
	int defaultWorksheetIndex = 0;

	// Ermittelt das Diagrammdaten-Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Löscht standardmäßig generierte Serie 
	chart->get_ChartData()->get_Series()->Clear();
	

	// Fügt eine neue Serie hinzu
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());


	// Nimmt die erste Diagrammserie
	SharedPtr<IChartSeries> series=chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Red")), chart->get_Type());
	// Füllt die Seriendaten
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(0.50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(0.80)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(0.65)));

	// Setzt die Füllfarbe für die Serie
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Setzt Eigenschaften von LabelFormat
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource ( false);
	series->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat (u"0.0%");
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight ( 10);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Nimmt die zweite Diagrammserie
	SharedPtr<IChartSeries> series2 = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Blues")), chart->get_Type());
	// Füllt die Seriendaten
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(0.70)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(0.50)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(0.20)));
	series2->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 4, 2, ObjectExt::Box<double>(0.35)));

	// Setzt die Füllfarbe für die Serie
	series2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

	// Setzt Eigenschaften von LabelFormat
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_IsNumberFormatLinkedToSource(false);
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_NumberFormat(u"0.0%");
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->set_FontHeight(10);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
	series2->get_Labels()->get_DefaultDataLabelFormat()->get_TextFormat()->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_White());
	series2->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

	// Schreibt die Präsentationsdatei auf die Festplatte
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Abstand der Beschriftung von der Achse festlegen**
Dieser C++-Code zeigt, wie Sie den Abstand der Beschriftung von einer Kategorienachse festlegen, wenn Sie ein Diagramm aus Achsen plotten:
```c++
	// Der Pfad zum Dokumentenverzeichnis
	const String outPath = u"../out/CategoryAxisLabelDistance_out.pptx";

	// Erstellt eine Instanz der Presentation-Klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Ermittelt die Referenz einer Folie
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Erstellt ein Diagramm auf der Folie
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Ermittelt die Diagramm-Seriensammlung
	SharedPtr<IChartSeriesCollection> seriesCollection = chart->get_ChartData()->get_Series();

	// Setzt den Beschriftungsabstand von einer Achse
	chart->get_Axes()->get_HorizontalAxis()->set_LabelOffset ( 500);

	// Schreibt die Präsentationsdatei auf die Festplatte
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Beschriftungsposition anpassen**

Wenn Sie ein Diagramm erstellen, das keine Achse verwendet, wie beispielsweise ein Kreisdiagramm, können die Datenbeschriftungen des Diagramms zu nah am Rand liegen. In einem solchen Fall müssen Sie die Position der Datenbeschriftung anpassen, damit die Führungs‑Linien deutlich angezeigt werden.

Dieser C++-Code zeigt, wie Sie die Beschriftungsposition in einem Kreisdiagramm anpassen:
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

**Wie kann ich verhindern, dass Datenbeschriftungen in dichten Diagrammen überlappen?**

Kombinieren Sie die automatische Platzierung von Beschriftungen, Führungs‑Linien und eine reduzierte Schriftgröße; bei Bedarf können Sie einige Felder (z. B. die Kategorie) ausblenden oder Beschriftungen nur für extreme bzw. wichtige Punkte anzeigen.

**Wie kann ich Beschriftungen nur für Null-, negative oder leere Werte deaktivieren?**

Filtern Sie Datenpunkte, bevor Sie Beschriftungen aktivieren, und schalten Sie die Anzeige für Werte von 0, für negative Werte oder für fehlende Werte gemäß einer definierten Regel aus.

**Wie kann ich einen konsistenten Beschriftungsstil beim Exportieren in PDF/Bilder sicherstellen?**

Legen Sie Schriftarten (Familie, Größe) explizit fest und prüfen Sie, ob die Schriftart auf der Rendering‑Seite verfügbar ist, um ein Zurückgreifen auf Ersatzschriften zu vermeiden.