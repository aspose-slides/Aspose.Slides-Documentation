---
title: Diagramme in PowerPoint‑Präsentationen in C++ erstellen oder aktualisieren
linktitle: Diagramme erstellen oder aktualisieren
type: docs
weight: 10
url: /de/cpp/create-chart/
keywords:
- Diagramm hinzufügen
- Diagramm erstellen
- Diagramm bearbeiten
- Diagramm ändern
- Diagramm aktualisieren
- Streudiagramm
- Kreisdiagramm
- Liniendiagramm
- Baumkartendiagramm
- Börsendiagramm
- Box‑Und‑Whisker‑Diagramm
- Trichterdiagramm
- Sunburst‑Diagramm
- Histogramm
- Radar‑Diagramm
- Mehrkategorie‑Diagramm
- PowerPoint
- Präsentation
- С++
- Aspose.Slides
description: "Erstellen und anpassen von Diagrammen in PowerPoint‑Präsentationen mit Aspose.Slides für C++. Diagramme hinzufügen, formatieren und bearbeiten mit praktischen Code‑Beispielen in C++."
---

## **Diagramm erstellen**

Diagramme helfen dabei, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Spreadsheet nicht sofort ersichtlich sind. 

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie

* große Datenmengen auf einer einzigen Folie in einer Präsentation aggregieren, verdichten oder zusammenfassen
* Muster und Trends in den Daten sichtbar machen
* die Richtung und das Momentum der Daten über die Zeit oder in Bezug auf eine bestimmte Maßeinheit ableiten
* Ausreißer, Aberrationen, Abweichungen, Fehler, unsinnige Daten usw. erkennen
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die Einfügefunktion erstellen, die Vorlagen für viele Diagrammtypen bereitstellt. Mit Aspose.Slides können Sie reguläre Diagramme (basierend auf gängigen Diagrammtypen) und benutzerdefinierte Diagramme erstellen. 

{{% alert color="primary" %}} 

Um Diagramme zu erstellen, stellt Aspose.Slides das Enum [ChartType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) unter dem Namensraum [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts/) zur Verfügung. Die Werte dieses Enums entsprechen den verschiedenen Diagrammtypen. 

{{% /alert %}} 

### **Normale Diagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie den gewünschten Diagrammtyp an.  
1. Fügen Sie dem Diagramm einen Titel hinzu.  
1. Greifen Sie auf das Arbeitsblatt der Diagrammdaten zu.  
1. Entfernen Sie alle Standardserien und -kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.  
1. Legen Sie eine Füllfarbe für die Diagrammserie fest.  
1. Fügen Sie Beschriftungen für die Diagrammserie hinzu.  
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein normales Diagramm erstellen:
```c++
// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/NormalCharts_out.pptx";

	//Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);


	// Setzt den Index des Diagrammdatenblatts
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten‑Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Setzt den Diagrammtitel
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// Löscht die automatisch erzeugten Serien und Kategorien
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();


	// Fügt eine neue Serie hinzu
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Fügt Kategorien hinzu
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Caetegoty 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Caetegoty 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Caetegoty 3")));

	
	// Nimmt die erste Diagrammserie
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Befüllt die Seriendaten
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// Setzt die Füllfarbe für die Serie
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());


	// Nimmt die zweite Diagrammserie
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// Befüllt die Seriendaten
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// Setzt die Füllfarbe für die Serie
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());


	// Das erste Label wird so gesetzt, dass der Kategoriename angezeigt wird
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// Zeigt den Wert für das dritte Label an
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Streudiagramme erstellen**
Streudiagramme (auch Scatter‑Plots oder x‑y‑Diagramme genannt) werden häufig verwendet, um Muster zu prüfen oder Korrelationen zwischen zwei Variablen zu demonstrieren. 

Sie sollten ein Streudiagramm verwenden, wenn

* Sie gepaarte numerische Daten haben
* Sie 2 Variablen haben, die gut zusammenpassen
* Sie feststellen wollen, ob 2 Variablen miteinander verbunden sind
* Sie eine unabhängige Variable haben, die mehrere Werte für eine abhängige Variable besitzt

Dieser C++‑Code zeigt, wie Sie ein Streudiagramm mit einer unterschiedlichen Markerserie erstellen: 
```c++
// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	//Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// Setzt den Diagrammtitel
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Löscht die standardmäßig erzeugte Serie 
	chart->get_ChartData()->get_Series()->Clear();
	
	// Setzt den  Index für das Diagrammdatenblatt
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten-Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Fügt eine neue Serie hinzu
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Series 2")), chart->get_Type());

	// Nimmt die erste Diagrammserie
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Fügt einen neuen Punkt (1:3) hinzu
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// Fügt einen neuen Punkt (2:10) hinzu
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// Ändert den Seriotyp
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// Ändert den Marker der Diagrammserie
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);



	// Nimmt die zweite Diagrammserie
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// Fügt einen neuen Punkt (5:2) hinzu
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// Fügt einen neuen Punkt (3:1) hinzu
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// Fügt einen neuen Punkt (2:2) hinzu
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// Fügt einen neuen Punkt (5:1) hinzu
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// Ändert den Marker der Diagrammserie
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);



	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Setzt den Sektorrand
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Setzt den Sektorrand
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Setzt den Sektorrand
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width ( 2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Erstellt die benutzerdefinierten Beschriftungen für jede Kategorie der neuen Serie
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

	// Zeigt die Leitlinien für das Diagramm an
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Setzt den Rotationswinkel für die Sektoren des Kreisdiagramms
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);


	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Kreisdiagramme erstellen**
Kreisdiagramme eignen sich am besten, um das Verhältnis von Teilen zum Ganzen darzustellen, insbesondere wenn die Daten kategoriale Beschriftungen mit numerischen Werten enthalten. Wenn Ihre Daten jedoch viele Teile oder Beschriftungen enthalten, sollten Sie stattdessen ein Balkendiagramm in Betracht ziehen. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Fall `ChartType.Pie`).  
1. Greifen Sie auf die Diagrammdaten‑IChartDataWorkbook zu.  
1. Entfernen Sie die Standardserie und -kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.  
1. Fügen Sie neue Punkte für das Diagramm hinzu und definieren Sie benutzerdefinierte Farben für die Sektoren des Kreisdiagramms.  
1. Setzen Sie Beschriftungen für die Serien.  
1. Setzen Sie Führungs­linien für die Serienbeschriftungen.  
1. Legen Sie den Rotationswinkel für die Kreisdiagramm‑Folien fest.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Kreisdiagramm erstellen:
```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/PieChart_out.pptx";

	//Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// Setzt den Diagrammtitel
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Löscht die standardmäßig erzeugten Serien und Kategorien
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Setzt den Index des Diagrammdatenblatts
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten‑Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Fügt Kategorien hinzu
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"First Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2nd Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3ed Qtr")));

	// Fügt eine neue Serie hinzu
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());
	
	// Nimmt die erste Diagrammserie
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Befüllt die Seriendaten
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Setzt den Sektorrand
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style( LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle ( LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Setzt den Sektorrand
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);


	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Setzt den Sektorrand
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);


	// Creates custom labels for each of categories for new series
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

	// Setzt die Serie so, dass Leitlinien für das Diagramm angezeigt werden
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// Setzt den Rotationswinkel für die Sektoren des Kreisdiagramms
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);


	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Liniendiagramme erstellen**

Liniendiagramme (auch Liniengraphen genannt) eignen sich besonders, wenn Sie Veränderungen von Werten im Zeitverlauf darstellen wollen. Mit einem Liniendiagramm können Sie viele Daten gleichzeitig vergleichen, Änderungen und Trends über die Zeit nachverfolgen, Ausreißer in Datenreihen hervorheben usw.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Fall `ChartType::Line`).  
1. Greifen Sie auf die Diagrammdaten‑IChartDataWorkbook zu.  
1. Entfernen Sie die Standardserie und -kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Liniendiagramm erstellen:
```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```


Standardmäßig werden die Punkte eines Liniendiagramms durch gerade, durchgehende Linien verbunden. Wenn Sie die Punkte stattdessen mit Strichen verbinden wollen, können Sie den gewünschten Strichtyp wie folgt angeben:
```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```


### **Baumkartendiagramme erstellen**

Baumkartendiagramme eignen sich besonders für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen und gleichzeitig schnell auf Großbeiträge jeder Kategorie aufmerksam machen möchten. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Fall `ChartType.TreeMap`).  
1. Greifen Sie auf die Diagrammdaten‑IChartDataWorkbook zu.  
1. Entfernen Sie die Standardserie und -kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Baumkartendiagramm erstellen:
```c++
// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/TreemapChart_out.pptx";

	//Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Zweig 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));


	// Zweig 2
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

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Börsendiagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (`ChartType.OpenHighLowClose`).  
1. Greifen Sie auf die Diagrammdaten‑IChartDataWorkbook zu.  
1. Entfernen Sie die Standardserie und -kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.  
1. Legen Sie das Format für HiLowLines fest.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Beispiel‑C++‑Code zum Erstellen eines Börsendiagramms:
```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/AddStockChart_out.pptx";

	//Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);


	// Setzt den Index für das Diagrammdatenblatt
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten-Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


	// Löscht die standardmäßig erzeugten Serien und Kategorien
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Fügt Kategorien hinzu
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"A")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"B")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"C")));

	// Fügt eine neue Serie hinzu
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Open")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"High")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, ObjectExt::Box<System::String>(u"Low")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 4, ObjectExt::Box<System::String>(u"Close")), chart->get_Type());


	// Nimmt die erste Diagrammserie
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);
	// Befüllt die Daten der ersten Serie
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));


	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// Befüllt die Daten der zweiten Serie
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// Befüllt die Daten der zweiten Serie
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));


	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// Befüllt die Daten der zweiten Serie
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 4, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(38)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(50)));

	// Setzt die Seriengruppe
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_UpDownBars()->set_HasUpDownBars (true);
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->get_HiLowLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);


	for(int i=0;i<chart->get_ChartData()->get_Series()->get_Count();i++)
	{
		series = chart->get_ChartData()->get_Series()->idx_get(i);
		series->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
	}

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Box‑und‑Whisker‑Diagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (`ChartType.BoxAndWhisker`).  
1. Greifen Sie auf die Diagrammdaten‑IChartDataWorkbook zu.  
1. Entfernen Sie die Standardserie und -kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Box‑und‑Whisker‑Diagramm erstellen:
```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	//Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Greift auf die erste Folie zu
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


	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Trichterdiagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (`ChartType.Funnel`).  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Trichterdiagramm erstellen:
```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/FunnelChart_out.pptx";

	//Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Greift auf die erste Folie zu
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


	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Sunburst‑Diagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (in diesem Fall `ChartType.sunburst`).  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Sunburst‑Diagramm erstellen:
```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Zweig 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Leaf1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Branch1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Leaf2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Leaf3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stem2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Leaf4")));

	// Zweig 2
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

	// Schreibt die Präsentationsdatei auf die Festplatte
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Histogramm‑Diagramme erstellen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie Ihren gewünschten Diagrammtyp an (`ChartType.Histogram` in diesem Fall).  
1. Greifen Sie auf die Diagrammdaten‑`IChartDataWorkbook` zu.  
1. Entfernen Sie die Standardserie und -kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Histogramm‑Diagramm erstellen:
```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
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

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Radar‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie Ihren gewünschten Diagrammtyp an (`ChartType.Radar` in diesem Fall).  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Radar‑Diagramm erstellen:
```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Mehrkategorie‑Diagramme erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index den Verweis auf eine Folie.  
1. Fügen Sie ein Diagramm mit Standarddaten und dem gewünschten Typ hinzu (`ChartType.ClusteredColumn`).  
1. Greifen Sie auf die Diagrammdaten‑IChartDataWorkbook zu.  
1. Entfernen Sie die Standardserie und -kategorien.  
1. Fügen Sie neue Serien und Kategorien hinzu.  
1. Fügen Sie neue Diagrammdaten für die Diagrammserie hinzu.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Mehrkategorie‑Diagramm erstellen:
```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	//Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	//Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// Setzt den Index für das Diagrammdatenblatt
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten-Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Löscht das Arbeitsbuch
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();


	// Fügt Kategorien hinzu
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

	// Fügt eine neue Serie hinzu
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

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


### **Karten‑Diagramme erstellen**

Ein Karten‑Diagramm visualisiert ein Gebiet, das Daten enthält. Karten‑Diagramme eignen sich besonders zum Vergleich von Daten oder Werten über geografische Regionen hinweg.

Dieser C++‑Code zeigt, wie Sie ein Karten‑Diagramm erstellen:
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```


### **Kombinations‑Diagramme erstellen**

Ein Kombinations‑Diagramm (oder Combo‑Diagramm) kombiniert zwei oder mehr Diagrammtypen in einem einzigen Graphen. Dieses Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei oder mehr Datensätzen hervorzuheben, zu vergleichen oder zu untersuchen, wodurch Beziehungen zwischen ihnen ersichtlich werden.

![The combination chart](combination_chart.png)

Der folgende C++‑Code zeigt, wie Sie das oben gezeigte Kombinations‑Diagramm in einer PowerPoint‑Präsentation erstellen:
```cpp
static SharedPtr<IChart> CreateChartWithFirstSeries(SharedPtr<ISlide> slide)
{
    auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // Setzt den Diagrammtitel.
    chart->set_HasTitle(true);
    chart->get_ChartTitle()->AddTextFrameForOverriding(u"Chart Title");
    chart->get_ChartTitle()->set_Overlay(false);
    auto titleParagraph = chart->get_ChartTitle()->get_TextFrameForOverriding()->get_Paragraph(0);
    auto titleFormat = titleParagraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    titleFormat->set_FontBold(NullableBool::False);
    titleFormat->set_FontHeight(18.0);

    // Setzt die Diagrammlegende.
    chart->get_Legend()->set_Position(LegendPositionType::Bottom);
    chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);

    // Löscht die standardmäßig erzeugten Serien und Kategorien.
    chart->get_ChartData()->get_Series()->Clear();
    chart->get_ChartData()->get_Categories()->Clear();

    const int worksheetIndex = 0;
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Fügt neue Kategorien hinzu.
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));
    chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Category 4")));

    // Fügt die erste Serie hinzu.
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
    // Setzt die horizontale Achse.
    auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
    horizontalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    horizontalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(horizontalAxis, u"X Axis");

    // Setzt die vertikale Achse.
    auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
    verticalAxis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12.0);
    verticalAxis->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    SetAxisTitle(verticalAxis, u"Y Axis 1");

    // Setzt die Farbe der vertikalen Hauptgitterlinien.
    auto majorGridLinesFormat = verticalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat();
    majorGridLinesFormat->set_FillType(FillType::Solid);
    majorGridLinesFormat->get_SolidFillColor()->set_Color(Color::FromArgb(217, 217, 217));
}

static void SetSecondaryAxesFormat(SharedPtr<IChart> chart)
{
    // Setzt die sekundäre horizontale Achse.
    auto secondaryHorizontalAxis = chart->get_Axes()->get_SecondaryHorizontalAxis();
    secondaryHorizontalAxis->set_Position(AxisPositionType::Bottom);
    secondaryHorizontalAxis->set_CrossType(CrossesType::Maximum);
    secondaryHorizontalAxis->set_IsVisible(false);
    secondaryHorizontalAxis->get_MajorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);
    secondaryHorizontalAxis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Setzt die sekundäre vertikale Achse.
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


## **Diagramme aktualisieren**

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse, die die Präsentation mit dem Diagramm repräsentiert.  
2. Holen Sie sich über den Index den Verweis auf eine Folie.  
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.  
4. Greifen Sie auf das Arbeitsblatt der Diagrammdaten zu.  
5. Ändern Sie die Daten der Diagrammserie, indem Sie Serienwerte anpassen.  
6. Fügen Sie eine neue Serie hinzu und befüllen Sie deren Daten.  
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie ein Diagramm aktualisieren:
```c++
// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// Greift auf die erste Folie zu
System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Fügt ein Diagramm mit Standarddaten hinzu
System::SharedPtr<IChart> chart = System::ExplicitCast<Aspose::Slides::Charts::IChart>(sld->get_Shapes()->idx_get(0));

// Setzt den Index für das Diagrammdatenblatt
int32_t defaultWorksheetIndex = 0;

// Holt das Diagrammdaten‑Arbeitsblatt
System::SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();


// Ändert den Diagramm‑Kategorienamen
fact->GetCell(defaultWorksheetIndex, 1, 0, System::ObjectExt::Box<System::String>(u"Modified Category 1"));
fact->GetCell(defaultWorksheetIndex, 2, 0, System::ObjectExt::Box<System::String>(u"Modified Category 2"));

// Nimmt die erste Diagrammserie
System::SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

// Aktualisiert die Seriendaten
fact->GetCell(defaultWorksheetIndex, 0, 1, System::ObjectExt::Box<System::String>(u"New_Series1"));
// Ändert den Seriennamen
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(90));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(123));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(44));

// Nimmt die zweite Diagrammserie
series = chart->get_ChartData()->get_Series()->idx_get(1);

// Jetzt werden die Seriendaten aktualisiert
fact->GetCell(defaultWorksheetIndex, 0, 2, System::ObjectExt::Box<System::String>(u"New_Series2"));
// Ändert den Seriennamen
series->get_DataPoints()->idx_get(0)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(23));
series->get_DataPoints()->idx_get(1)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(67));
series->get_DataPoints()->idx_get(2)->get_Value()->set_Data(System::ObjectExt::Box<int32_t>(99));


// Jetzt wird eine neue Serie hinzugefügt
chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 3, System::ObjectExt::Box<System::String>(u"Series 3")), chart->get_Type());

// Nimmt die dritte Diagrammserie
series = chart->get_ChartData()->get_Series()->idx_get(2);

// Jetzt werden die Seriendaten befüllt
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, System::ObjectExt::Box<int32_t>(20)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, System::ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, System::ObjectExt::Box<int32_t>(30)));

chart->set_Type(Aspose::Slides::Charts::ChartType::ClusteredCylinder);

// Speichert die Präsentation mit dem Diagramm
pres->Save(u"AsposeChartModified_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```



## **Datenbereich für Diagramme festlegen**

1. Öffnen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse, die das Diagramm enthält.  
2. Holen Sie sich über den Index den Verweis auf eine Folie.  
3. Durchlaufen Sie alle Formen, um das gewünschte Diagramm zu finden.  
4. Greifen Sie auf die Diagrammdaten zu und setzen Sie den Bereich.  
5. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser C++‑Code zeigt, wie Sie den Datenbereich für ein Diagramm festlegen:
```cpp
// Der Pfad zum Dokumentenverzeichnis.
String dataDir = GetDataPath();

// Instanziert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
auto presentation = System::MakeObject<Presentation>(dataDir + u"ExistingChart.pptx");

// Greift auf die erste Folie zu und fügt ein Diagramm mit Standarddaten hinzu
auto slide = presentation->get_Slides()->idx_get(0);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
chart->get_ChartData()->SetRange(u"Sheet1!A1:B4");
presentation->Save(dataDir + u"SetDataRange_out.pptx", SaveFormat::Pptx);
```



## **Standard‑Marker in Diagrammen verwenden**
Wenn Sie einen Standard‑Marker in Diagrammen verwenden, erhält jede Diagrammserie automatisch ein unterschiedliches Standard‑Markersymbol.

Dieser C++‑Code zeigt, wie Sie einen Diagramm‑Series‑Marker automatisch festlegen:
```cpp
// Der Pfad zum Dokumentenverzeichnis.
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

// Nimmt die zweite Diagrammserie
auto series2 = chart->get_ChartData()->get_Series()->idx_get(1);

// Befüllt die Seriendaten
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 1, 2, ObjectExt::Box<int32_t>(30)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 2, 2, ObjectExt::Box<int32_t>(10)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 3, 2, ObjectExt::Box<int32_t>(60)));
series2->get_DataPoints()->AddDataPointForLineSeries(wb->GetCell(0, 4, 2, ObjectExt::Box<int32_t>(40)));

chart->set_HasLegend(true);
chart->get_Legend()->set_Overlay(false);

pres->Save(dataDir + u"DefaultMarkersInChart.pptx", SaveFormat::Pptx);
```



## **FAQ**

**Welche Diagrammtypen werden von Aspose.Slides unterstützt?**

Aspose.Slides unterstützt eine breite Palette von Diagrammtypen, darunter Balken, Linien, Kreis, Fläche, Scatter, Histogramm, Radar und viele mehr. Diese Flexibilität erlaubt Ihnen, den am besten geeigneten Diagrammtyp für Ihre Datenvisualisierung auszuwählen.

**Wie füge ich ein neues Diagramm zu einer Folie hinzu?**

Um ein Diagramm hinzuzufügen, erstellen Sie zunächst eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse, rufen die gewünschte Folie über deren Index ab und rufen dann die Methode zum Hinzufügen eines Diagramms auf, wobei Sie den Diagrammtyp und die Anfangsdaten angeben. Dieser Vorgang integriert das Diagramm direkt in Ihre Präsentation.

**Wie kann ich die in einem Diagramm angezeigten Daten aktualisieren?**

Sie können die Daten eines Diagramms aktualisieren, indem Sie auf dessen Daten‑Workbook ([IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/)) zugreifen, bestehende Standardserien und -kategorien löschen und anschließend Ihre eigenen Daten hinzufügen. So können Sie das Diagramm programmgesteuert auf den neuesten Stand bringen.

**Ist es möglich, das Erscheinungsbild des Diagramms anzupassen?**

Ja, Aspose.Slides bietet umfangreiche Anpassungsoptionen. Sie können Farben, Schriftarten, Beschriftungen, Legenden und weitere Formatierungselemente ändern, um das Diagramm an Ihre spezifischen Gestaltungsanforderungen anzupassen.