---
title: Erstellen von PowerPoint-Präsentationsdiagrammen in C++
linktitle: Diagramm erstellen
type: docs
weight: 10
url: /cpp/create-chart/
keywords: "Diagramm erstellen, Punktdiagramm, Kreisdiagramm, Baumkarten-Diagramm, Aktiendiagramm, Box- und Whisker-Diagramm, Histogramm-Diagramm, Trichterdiagramm, Sonnenstrahl-Diagramm, Mehrkategoriediagramm, PowerPoint-Präsentation, C++, CPP, Aspose.Slides für C++"
description: "Diagramm in PowerPoint-Präsentation in C++ erstellen"
---

## **Diagramm erstellen**

Diagramme helfen Menschen, Daten schnell zu visualisieren und Erkenntnisse zu gewinnen, die aus einer Tabelle oder einem Spreadsheet möglicherweise nicht sofort ersichtlich sind.

**Warum Diagramme erstellen?**

Mit Diagrammen können Sie:

* große Datenmengen auf einer einzelnen Folie in einer Präsentation aggregieren, komprimieren oder zusammenfassen
* Muster und Trends in den Daten aufdecken
* die Richtung und Dynamik der Daten im Laufe der Zeit oder in Bezug auf eine bestimmte Maßeinheit ableiten 
* Ausreißer, Abweichungen, Fehler, unsinnige Daten usw. erkennen
* komplexe Daten kommunizieren oder präsentieren

In PowerPoint können Sie Diagramme über die Einfügefunktion erstellen, die Vorlagen bietet, die zur Gestaltung vieler Arten von Diagrammen verwendet werden. Mit Aspose.Slides können Sie reguläre Diagramme (basierend auf beliebten Diagrammtypen) und benutzerdefinierte Diagramme erstellen.

{{% alert color="primary" %}} 

Um Ihnen die Erstellung von Diagrammen zu ermöglichen, stellt Aspose.Slides die [ChartType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts#a23ba9ea390f5be4c8f5ab18baf4f8c05) Enum-Klasse im [Aspose::Slides::Charts](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.charts/) Namespace zur Verfügung. Die Werte in dieser Enum-Klasse entsprechen verschiedenen Diagrammtypen.

{{% /alert %}} 

### **Erstellen von normalen Diagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp an. 
1. Fügen Sie einen Titel für das Diagramm hinzu. 
1. Greifen Sie auf das Diagrammdaten-Arbeitsblatt zu.
1. Löschen Sie alle standardmäßigen Datenserien und Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
1. Fügen Sie eine Füllfarbe für die Diagrammserien hinzu.
1. Fügen Sie Beschriftungen für die Diagrammserien hinzu. 
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein normales Diagramm erstellt:

```c++
// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/NormalCharts_out.pptx";

	// Instanziiert eine Präsentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// Setzt den Index des Diagrammdatenblatts
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten-Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Setzt den Diagrammtitel
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Beispiel Titel");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText ( NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle( true);

	// Löscht die standardmäßig generierten Serien und Kategorien
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();
	int s = chart->get_ChartData()->get_Series()->get_Count();
	s = chart->get_ChartData()->get_Categories()->get_Count();

	// Fügt eine neue Serie hinzu
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Serie 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 2, ObjectExt::Box<System::String>(u"Serie 2")), chart->get_Type());

	// Fügt Kategorien hinzu
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Kategorie 1")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"Kategorie 2")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"Kategorie 3")));

	// Nimmt die erste Diagrammserie
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Füllt die Seriendaten
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	// Setzt die Füllfarbe für die Serien
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

	// Nimmt die zweite Diagrammserie
	 series = chart->get_ChartData()->get_Series()->idx_get(1);

	// Füllt die Seriendaten
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(30)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(10)));
	series->get_DataPoints()->AddDataPointForBarSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(60)));

	// Setzt die Füllfarbe für die Serien
	series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());

	// Erste Beschriftung wird gesetzt, um den Kategorienamen anzuzeigen
	SharedPtr<IDataLabel> lbl = series->get_DataPoints()->idx_get(0)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowCategoryName(true);

	lbl = series->get_DataPoints()->idx_get(1)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowSeriesName (true);

	// Zeigt den Wert für die dritte Beschriftung an
	lbl = series->get_DataPoints()->idx_get(2)->get_Label();
	lbl->get_DataLabelFormat()->set_ShowValue (true);
	lbl->get_DataLabelFormat()->set_ShowSeriesName(true);
	lbl->get_DataLabelFormat()->set_Separator (u"/");

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Erstellen von Punktdiagrammen**
Punktdiagramme (auch als Punktediagramme oder X-Y-Diagramme bekannt) werden häufig verwendet, um nach Mustern zu suchen oder Korrelationen zwischen zwei Variablen zu demonstrieren. 

Sie möchten möglicherweise ein Punktdiagramm verwenden, wenn:

* Sie gepaarte numerische Daten haben
* Sie 2 Variablen haben, die gut zusammenpassen
* Sie bestimmen möchten, ob 2 Variablen miteinander verwandt sind
* Sie eine unabhängige Variable haben, die mehrere Werte für eine abhängige Variable hat

Dieser C++-Code zeigt Ihnen, wie man ein Punktdiagramm mit einer anderen Serie von Markierungen erstellt: 

```c++
// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/ScatteredChart_out.pptx";

	// Instanziert eine Präsentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ScatterWithSmoothLines, 0, 0, 500, 500);

	// Setzt den Diagrammtitel
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Beispiel Titel");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Löscht die standardmäßig generierten Serien 
	chart->get_ChartData()->get_Series()->Clear();
	
	// Setzt den Index für das Diagrammdatenblatt
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten-Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Fügt eine neue Serie hinzu
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Serie 1")), chart->get_Type());
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<System::String>(u"Serie 2")), chart->get_Type());

	// Nimmt die erste Diagrammserie
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Fügt einen neuen Punkt hinzu (1:3)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(1)), fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(3)));

	// Fügt einen neuen Punkt hinzu (2:10)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(10)));

	// Bearbeitet den Serientyp
	series->set_Type (ChartType::ScatterWithStraightLinesAndMarkers);

	// Ändert den Marker des Diagrammserien
	series->get_Marker()->set_Size  (10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Star);

	// Nimmt die zweite Diagrammserie
	series  = chart->get_ChartData()->get_Series()->idx_get(1);

	// Fügt einen neuen Punkt hinzu (5:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 2, 4, ObjectExt::Box<double>(2)));

	// Fügt einen neuen Punkt hinzu (3:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(3)), fact->GetCell(defaultWorksheetIndex, 3, 4, ObjectExt::Box<double>(1)));

	// Fügt einen neuen Punkt hinzu (2:2)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 4, 3, ObjectExt::Box<double>(2)), fact->GetCell(defaultWorksheetIndex, 4, 4, ObjectExt::Box<double>(2)));

	// Fügt einen neuen Punkt hinzu (5:1)
	series->get_DataPoints()->AddDataPointForScatterSeries(fact->GetCell(defaultWorksheetIndex, 5, 3, ObjectExt::Box<double>(5)), fact->GetCell(defaultWorksheetIndex, 5, 4, ObjectExt::Box<double>(1)));

	// Ändert den Marker des Diagrammserien
	series->get_Marker()->set_Size ( 10);
	series->get_Marker()->set_Symbol(MarkerStyleType::Circle);

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Setzt den Sektorrahmen
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Setzt den Sektorrahmen
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);

	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Setzt den Sektorrahmen
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

	// Zeigt die Führungs Linien für das Diagramm an
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines(true);

	// Setzt den Rotationswinkel für die Sektoren des Kreisdiagramms
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle(180);

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Erstellen von Kreisdiagrammen**
Kreisdiagramme eignen sich am besten, um die Teil-Ganzes-Beziehung in Daten darzustellen, insbesondere wenn die Daten kategorische Beschriftungen mit numerischen Werten enthalten. Wenn Ihre Daten jedoch viele Teile oder Beschriftungen enthalten, sollten Sie in Betracht ziehen, stattdessen ein Balkendiagramm zu verwenden.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (in diesem Fall `ChartType.Pie`) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standard-Serien und -Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
1. Fügen Sie neue Punkte für die Diagramme hinzu und fügen Sie benutzerdefinierte Farben für die Sektoren des Kreisdiagramms hinzu.
1. Setzen Sie Beschriftungen für die Serien.
1. Setzen Sie die Führungs Linien für die Serienbeschriftungen.
1. Setzen Sie den Rotationswinkel für die Sektoren der Kreisdiagramme.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Kreisdiagramm erstellt:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/PieChart_out.pptx";

	// Instanziert eine Präsentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Pie, 0, 0, 500, 500);

	// Setzt den Diagrammtitel
	chart->get_ChartTitle()->AddTextFrameForOverriding(u"Beispiel Titel");
	chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
	chart->get_ChartTitle()->set_Height(20);
	chart->set_HasTitle(true);

	// Löscht die standardmäßig generierten Serien und Kategorien
	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Setzt den Index des Diagrammdatenblatts
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten-Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Fügt Kategorien hinzu
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 1, 0, ObjectExt::Box<System::String>(u"Erstes Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 2, 0, ObjectExt::Box<System::String>(u"2. Qtr")));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, 3, 0, ObjectExt::Box<System::String>(u"3. Qtr")));

	// Fügt eine neue Serie hinzu
	chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 0, 1, ObjectExt::Box<System::String>(u"Serie 1")), chart->get_Type());
	
	// Nimmt die erste Diagrammserie
	SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->idx_get(0);

	// Füllt die Seriendaten
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(20)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(50)));
	series->get_DataPoints()->AddDataPointForPieSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(30)));

	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_IsColorVaried(true);

	SharedPtr<IChartDataPoint> point = series->get_DataPoints()->idx_get(0);
	point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Cyan());
	// Setzt den Sektorrahmen
	point->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Gray());
	point->get_Format()->get_Line()->set_Width ( 3.0);
	point->get_Format()->get_Line()->set_Style(LineStyle::ThinThick);
	point->get_Format()->get_Line()->set_DashStyle(LineDashStyle::DashDot);

	SharedPtr<IChartDataPoint> point1 = series->get_DataPoints()->idx_get(1);
	point1->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Brown());

	// Setzt den Sektorrahmen
	point1->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point1->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());
	point1->get_Format()->get_Line()->set_Width (3.0);
	point1->get_Format()->get_Line()->set_Style(LineStyle::Single);
	point1->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDot);

	SharedPtr<IChartDataPoint> point2 = series->get_DataPoints()->idx_get(2);
	point2->get_Format()->get_Fill()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Coral());

	// Setzt den Sektorrahmen
	point2->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
	point2->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
	point2->get_Format()->get_Line()->set_Width (2.0);
	point2->get_Format()->get_Line()->set_Style(LineStyle::ThickThin);
	point2->get_Format()->get_Line()->set_DashStyle(LineDashStyle::LargeDashDotDot);

	// Erstellt benutzerdefinierte Beschriftungen für jede der Kategorien der neuen Serie
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

	// Setzt die Serien, um Führungs Linien für das Diagramm anzuzeigen
	series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLeaderLines ( true);

	// Setzt den Rotationswinkel für die Sektoren des Kreisdiagramms
	chart->get_ChartData()->get_SeriesGroups()->idx_get(0)->set_FirstSliceAngle ( 180);

	// Speichert die Präsentation
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Erstellen von Liniendiagrammen**

Liniendiagramme (auch als Liniendiagramme bekannt) eignen sich am besten für Situationen, in denen Sie Veränderungen von Werten im Laufe der Zeit demonstrieren möchten. Mit einem Liniendiagramm können Sie viele Daten auf einmal vergleichen, Änderungen und Trends im Laufe der Zeit verfolgen, Anomalien in Datensätzen hervorheben usw.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (in diesem Fall `ChartType::Line`) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standard-Serien und -Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Liniendiagramm erstellt:

```c++
auto pres = System::MakeObject<Presentation>();

System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
pres->Save(u"lineChart.pptx", SaveFormat::Pptx);
```

Standardmäßig werden die Punkte auf einem Liniendiagramm durch gerade durchgehende Linien verbunden. Wenn Sie möchten, dass die Punkte stattdessen durch Striche verbunden werden, können Sie Ihren bevorzugten Strichtyp so angeben:

```c++
System::SharedPtr<IChart> lineChart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Line, 10.0f, 50.0f, 600.0f, 350.0f);
for (auto&& series : lineChart->get_ChartData()->get_Series())
{
    series->get_Format()->get_Line()->set_DashStyle(LineDashStyle::Dash);
}
```

### **Erstellen von Baumkarten-Diagrammen**

Baumkarten-Diagramme eignen sich am besten für Verkaufsdaten, wenn Sie die relative Größe von Datenkategorien zeigen möchten und gleichzeitig schnell auf Elemente aufmerksam machen, die große Beiträge zu jeder Kategorie leisten. 

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (in diesem Fall `ChartType.TreeMap`) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standard-Serien und -Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Baumkarten-Diagramm erstellt:

```c++
// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/TreemapChart_out.pptx";

	// Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Treemap, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Zweig 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Blatt1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stamm1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Zweig1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Blatt2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Blatt3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stamm2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Blatt4")));

	// Zweig 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Blatt5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stamm3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Zweig2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Blatt6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Blatt7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stamm4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Blatt8")));

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

### **Erstellen von Aktien-Diagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (ChartType.OpenHighLowClose).
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standard-Serien und -Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
1. Geben Sie das HiLowLines-Format an.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Beispiel-C++-Code zum Erstellen eines Aktien-Diagramms:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/AddStockChart_out.pptx";

	// Instanziert eine Präsentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::OpenHighLowClose, 0, 0, 500, 500);

	// Setzt den Index für das Diagrammdatenblatt
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten-Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Löscht die standardmäßig generierten Serien und Kategorien
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
	// Füllt die ersten Seriendaten
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(72)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(25)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(38)));

	series = chart->get_ChartData()->get_Series()->idx_get(1);
	// Füllt die zweiten Seriendaten
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 2, ObjectExt::Box<double>(172)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 2, ObjectExt::Box<double>(57)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 2, ObjectExt::Box<double>(57)));

	series = chart->get_ChartData()->get_Series()->idx_get(2);
	// Füllt die dritten Seriendaten
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 1, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 2, 3, ObjectExt::Box<double>(12)));
	series->get_DataPoints()->AddDataPointForStockSeries(fact->GetCell(defaultWorksheetIndex, 3, 3, ObjectExt::Box<double>(13)));

	series = chart->get_ChartData()->get_Series()->idx_get(3);
	// Füllt die vierten Seriendaten
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

### **Erstellen von Box- und Whisker-Diagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (ChartType.BoxAndWhisker) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standard-Serien und -Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Box- und Whisker-Diagramm erstellt:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/BoxAndWhisker_out.pptx";

	// Instanziert eine Präsentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::BoxAndWhisker, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Kategorie 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Kategorie 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Kategorie 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Kategorie 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Kategorie 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Kategorie 1")));

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

### **Erstellen von Trichterdiagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (ChartType.Funnel) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Trichterdiagramm erstellt:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/FunnelChart_out.pptx";

	// Instanziert eine Präsentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Funnel, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A1", System::ObjectExt::Box<System::String>(u"Kategorie 1")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A2", System::ObjectExt::Box<System::String>(u"Kategorie 2")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A3", System::ObjectExt::Box<System::String>(u"Kategorie 3")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A4", System::ObjectExt::Box<System::String>(u"Kategorie 4")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A5", System::ObjectExt::Box<System::String>(u"Kategorie 5")));
	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"A6", System::ObjectExt::Box<System::String>(u"Kategorie 6")));

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

### **Erstellen von Sonnenstrahl-Diagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (in diesem Fall `ChartType.sunburst`) hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Sonnenstrahl-Diagramm erstellt:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/SunburstChart_out.pptx";

	// Instanziert eine Präsentation-Klasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	System::SharedPtr<IChart> chart=slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Sunburst, 50, 50, 500, 400);
	chart->get_ChartData()->get_Categories()->Clear();
	chart->get_ChartData()->get_Series()->Clear();

	System::SharedPtr<IChartDataWorkbook> wb = chart->get_ChartData()->get_ChartDataWorkbook();

	wb->Clear(0);

	// Zweig 1
	System::SharedPtr<IChartCategory> leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C1", System::ObjectExt::Box<System::String>(u"Blatt1")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stamm1"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Zweig1"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C2", System::ObjectExt::Box<System::String>(u"Blatt2")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C3", System::ObjectExt::Box<System::String>(u"Blatt3")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stamm2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C4", System::ObjectExt::Box<System::String>(u"Blatt4")));

	// Zweig 2
	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C5", System::ObjectExt::Box<System::String>(u"Blatt5")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stamm3"));
	leaf->get_GroupingLevels()->SetGroupingItem(2, System::ObjectExt::Box<System::String>(u"Zweig2"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C6", System::ObjectExt::Box<System::String>(u"Blatt6")));

	leaf = chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C7", System::ObjectExt::Box<System::String>(u"Blatt7")));
	leaf->get_GroupingLevels()->SetGroupingItem(1, System::ObjectExt::Box<System::String>(u"Stamm4"));

	chart->get_ChartData()->get_Categories()->Add(wb->GetCell(0, u"C8", System::ObjectExt::Box<System::String>(u"Blatt8")));

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

	// Schreiben Sie die Präsentationsdatei auf die Festplatte
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Erstellen von Histogramm-Diagrammen**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index. 
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp an (`ChartType.Histogram` in diesem Fall).
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standard-Serien und -Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Histogramm-Diagramm erstellt:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/HistogramChart_out.pptx";

	// Instanziert eine Präsentation-Klasse, die eine PPTX-Datei darstellt
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

### **Erstellen von Radar-Diagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Holen Sie sich die Referenz einer Folie über ihren Index. 
1. Fügen Sie ein Diagramm mit einigen Daten hinzu und geben Sie Ihren bevorzugten Diagrammtyp an (`ChartType.Radar` in diesem Fall).
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Radar-Diagramm erstellt:

```c++
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::Radar, 20.0f, 20.0f, 400.0f, 300.0f);
presentation->Save(u"Radar-chart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Erstellen von Mehrkategorie-Diagrammen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Erhalten Sie die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten zusammen mit dem gewünschten Typ (ChartType.ClusteredColumn) hinzu.
1. Greifen Sie auf das Diagrammdaten-IChartDataWorkbook zu.
1. Löschen Sie die Standard-Serien und -Kategorien.
1. Fügen Sie neue Serien und Kategorien hinzu.
1. Fügen Sie neue Diagrammdaten für die Diagrammserien hinzu.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Mehrkategorie-Diagramm erstellt:

```c++
	// Der Pfad zum Dokumentenverzeichnis.
	const String outPath = u"../out/MultiCategoryChart_out.pptx";

	// Instanziert eine Präsentationsklasse, die eine PPTX-Datei darstellt
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Greift auf die erste Folie zu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Fügt ein Diagramm mit Standarddaten hinzu
	SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::ClusteredColumn, 0, 0, 500, 500);

	// Setzt den Index für das Diagrammdatenblatt
	int defaultWorksheetIndex = 0;

	// Holt das Diagrammdaten-Arbeitsblatt
	SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

	// Löscht die Arbeitsmappe
	fact->Clear(defaultWorksheetIndex);

	chart->get_ChartData()->get_Series()->Clear();
	chart->get_ChartData()->get_Categories()->Clear();

	// Fügt Kategorien hinzu
	SharedPtr<IChartCategory> category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c2", ObjectExt::Box<System::String>(u"A")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Gruppe1"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c3", ObjectExt::Box<System::String>(u"B")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c4", ObjectExt::Box<System::String>(u"C")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Gruppe2"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c5", ObjectExt::Box<System::String>(u"D")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c6", ObjectExt::Box<System::String>(u"E")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Gruppe3"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c7", ObjectExt::Box<System::String>(u"F")));

	category = chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c8", ObjectExt::Box<System::String>(u"G")));
	category->get_GroupingLevels()->SetGroupingItem(1, ObjectExt::Box<System::String>(u"Gruppe4"));
	chart->get_ChartData()->get_Categories()->Add(fact->GetCell(defaultWorksheetIndex, u"c9", ObjectExt::Box<System::String>(u"H")));

	// Fügt eine neue Serie hinzu
	SharedPtr<IChartSeries>  series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(0, u"D1", ObjectExt::Box<System::String>(u"Serie 1")),
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

### **Erstellen von Karten-Diagrammen**

Ein Karten-Diagramm ist eine Visualisierung eines Gebietes, das Daten enthält. Karten-Diagramme eignen sich am besten, um Daten oder Werte über geografische Regionen hinweg zu vergleichen.

Dieser C++-Code zeigt Ihnen, wie man ein Karten-Diagramm erstellt:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Map, 50.0f, 50.0f, 500.0f, 400.0f);
pres->Save(u"mapChart.pptx", SaveFormat::Pptx);
```

### **Erstellen von Kombinations-Diagrammen**

Ein Kombinationsdiagramm (oder Kombodiagramm) ist ein Diagramm, das zwei oder mehr Diagramme in einem einzigen Diagramm kombiniert. Ein solches Diagramm ermöglicht es Ihnen, Unterschiede zwischen zwei (oder mehr) Datensätzen hervorzuheben, zu vergleichen oder zu überprüfen. Auf diese Weise sehen Sie die Beziehung (falls vorhanden) zwischen den Datensätzen.

![kombinationsdiagramm-ppt](kombinationsdiagramm-ppt.png)

Dieser C++-Code zeigt Ihnen, wie man ein Kombinationsdiagramm in PowerPoint erstellt:

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

    seriesCollection->Add(workbook->GetCell(worksheetIndex, 0, 1, System::ExplicitCast<System::Object>(u"Serie 1")), chart->get_Type());
    seriesCollection->Add(workbook->GetCell(worksheetIndex, 0, 2, System::ExplicitCast<System::Object>(u"Serie 2")), chart->get_Type());

    categories->Add(workbook->GetCell(worksheetIndex, 1, 0, System::ExplicitCast<System::Object>(u"Kategorie 1")));
    categories->Add(workbook->GetCell(worksheetIndex, 2, 0, System::ExplicitCast<System::Object>(u"Kategorie 2")));
    categories->Add(workbook->GetCell(worksheetIndex, 3, 0, System::ExplicitCast<System::Object>(u"Kategorie 3")));

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

    System::SharedPtr<IChartSeries> series = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 3, System::ExplicitCast<System::Object>(u"Serie 3")), ChartType::ScatterWithSmoothLines);
    System::SharedPtr<IChartDataPointCollection> dataPoints = series->get_DataPoints();

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 0, 1, System::ExplicitCast<System::Object>(3)), workbook->GetCell(worksheetIndex, 0, 2, System::ExplicitCast<System::Object>(5)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 3, System::ExplicitCast<System::Object>(10)), workbook->GetCell(worksheetIndex, 1, 4, System::ExplicitCast<System::Object>(13)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 2, 3, System::ExplicitCast<System::Object>(20)), workbook->GetCell(worksheetIndex, 2, 4, System::ExplicitCast<System::Object>(15)));

    series->set_PlotOnSecondAxis(true);
}

void AddSecondSeriesToChart(System::SharedPtr<IChart> chart)
{
    System::SharedPtr<IChartData> chartData = chart->get_ChartData();
    System::SharedPtr<IChartDataWorkbook> workbook = chartData->get_ChartDataWorkbook();
    const int32_t worksheetIndex = 0;

    System::SharedPtr<IChartSeries> series = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 5, System::ExplicitCast<System::Object>(u"Serie 4")), ChartType::ScatterWithStraightLinesAndMarkers);
    System::SharedPtr<IChartDataPointCollection> dataPoints = series->get_DataPoints();

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 3, System::ExplicitCast<System::Object>(5)), workbook->GetCell(worksheetIndex, 1, 4, System::ExplicitCast<System::Object>(2)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 1, 5, System::ExplicitCast<System::Object>(10)), workbook->GetCell(worksheetIndex, 1, 6, System::ExplicitCast<System::Object>(7)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 2, 5, System::ExplicitCast<System::Object>(15)), workbook->GetCell(worksheetIndex, 2, 6, System::ExplicitCast<System::Object>(12)));

    dataPoints->AddDataPointForScatterSeries(workbook->GetCell(worksheetIndex, 3, 5, System::ExplicitCast<System::Object>(12)), workbook->GetCell(worksheetIndex, 3, 6, System::ExplicitCast<System::Object>(9)));

    series->set_PlotOnSecondAxis(true);
}
```

## **Diagramme aktualisieren**

1. Instanziieren Sie eine [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse, die die Präsentation mit dem Diagramm darstellt.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Durchsuchen Sie alle Shapes, um das gewünschte Diagramm zu finden.
4. Greifen Sie auf das Diagrammdaten-Arbeitsblatt zu.
5. Ändern Sie die Daten der Diagrammserie, indem Sie die Serienwerte ändern.
6. Fügen Sie eine neue Serie hinzu und fügen Sie Daten hinzu.
7. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie man ein Diagramm aktualisiert:

```c++
// Instanziiert eine Präsentation-Klasse, die eine PPTX-Datei darstellt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"ExistingChart.pptx");

// Greift auf die erste Folie zu