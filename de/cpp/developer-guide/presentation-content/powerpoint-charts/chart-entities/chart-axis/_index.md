---
title: Diagrammachsen in Präsentationen mit C++ anpassen
linktitle: Diagrammachse
type: docs
url: /de/cpp/chart-axis/
keywords:
- Diagrammachse
- vertikale Achse
- horizontale Achse
- Achse anpassen
- Achse manipulieren
- Achse verwalten
- Achseneigenschaften
- Maximalwert
- Minimalwert
- Achsenlinie
- Datumsformat
- Achsentitel
- Achsenposition
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie, wie Sie Aspose.Slides für C++ verwenden, um Diagrammachsen in PowerPoint-Präsentationen für Berichte und Visualisierungen anzupassen."
---

## **Ermitteln Sie die Maximalwerte auf der vertikalen Achse**
Aspose.Slides für C++ ermöglicht das Abrufen der minimalen und maximalen Werte auf einer vertikalen Achse. Gehen Sie dabei wie folgt vor:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)-Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Ermitteln Sie den tatsächlichen Maximalwert auf der Achse.
1. Ermitteln Sie den tatsächlichen Minimalwert auf der Achse.
1. Ermitteln Sie die tatsächliche Haupteinheit der Achse.
1. Ermitteln Sie die tatsächliche Nebeneinheit der Achse.
1. Ermitteln Sie die tatsächliche Skalierung der Haupteinheit der Achse.
1. Ermitteln Sie die tatsächliche Skalierung der Nebeneinheit der Achse.

Dieser Beispielcode – eine Umsetzung der obigen Schritte – zeigt, wie Sie die erforderlichen Werte in C++ erhalten:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Speichert die Präsentation
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```


## **Daten zwischen Achsen vertauschen**
Aspose.Slides ermöglicht das schnelle Vertauschen von Daten zwischen Achsen – die auf der vertikalen Achse (y-Achse) dargestellten Daten werden auf die horizontale Achse (x-Achse) verschoben und umgekehrt. 

Dieser C++‑Code zeigt, wie Sie den Datentausch zwischen Achsen in einem Diagramm durchführen:
``` cpp
// Erstellt eine leere Präsentation
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Vertauscht Zeilen und Spalten
chart->get_ChartData()->SwitchRowColumn();

// Speichert die Präsentation
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```


## **Vertikale Achse für Liniendiagramme deaktivieren**
Dieser C++‑Code zeigt, wie Sie die vertikale Achse in einem Liniendiagramm ausblenden:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **Horizontale Achse für Liniendiagramme deaktivieren**
Dieser Code zeigt, wie Sie die horizontale Achse in einem Liniendiagramm ausblenden:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```


## **Kategorieachse ändern**
Mit der Methode **set_CategoryAxisType()** können Sie den gewünschten Typ der Kategorieachse festlegen (**date** oder **text**). Dieser C++‑Code demonstriert die Vorgehensweise: 
``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```


## **Datumsformat für Kategorieachsenwerte festlegen**
Aspose.Slides für C++ ermöglicht das Festlegen des Datumsformats für einen Wert einer Kategorieachse. Die Vorgehensweise wird in diesem C++‑Code gezeigt:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```


## **Rotationswinkel für einen Achsentitel festlegen**
Aspose.Slides für C++ ermöglicht das Festlegen des Rotationswinkels für einen Diagramm‑Achsentitel. Dieser C++‑Code demonstriert die Vorgehensweise:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```


## **Achsenposition auf einer Kategorie‑ oder Werteachse festlegen**
Aspose.Slides für C++ ermöglicht das Festlegen der Achsenposition auf einer Kategorie‑ oder Werteachse. Dieser C++‑Code zeigt, wie die Aufgabe ausgeführt wird:
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```


## **Einheitenbeschriftung auf einer Diagramm‑Werteachse aktivieren**
Aspose.Slides für C++ ermöglicht die Konfiguration eines Diagramms, um eine Einheitenbeschriftung auf seiner Werteachse anzuzeigen. Dieser C++‑Code demonstriert die Vorgehensweise:
``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Achsen bieten eine [Kreuzungseinstellung](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/): Sie können wählen, ob die Achsen bei Null, beim maximalen Kategorie‑/Wert oder bei einem bestimmten numerischen Wert kreuzen. Dies ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder eine Basislinie hervorzuheben.

**Wie kann ich die Achsenbeschriftungen relativ zur Achse positionieren (neben, außen, innen)?**

Stellen Sie die [Beschriftungsposition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) auf „cross“, „outside“ oder „inside“ ein. Dies beeinflusst die Lesbarkeit und spart Platz, insbesondere bei kleinen Diagrammen.