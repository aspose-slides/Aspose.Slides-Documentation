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
## **Übersicht**

Dieser Artikel erklärt, wie Sie Diagrammachsen in Aspose.Slides anpassen. Er zeigt, wie Sie tatsächliche Achsenwerte erhalten, Daten zwischen Achsen austauschen, die vertikale oder horizontale Achse bei Liniendiagrammen ausblenden, den Typ der Kategorieachse ändern, das Datumsformat für Kategorieachsenwerte festlegen, einen Achsentitel drehen, die Achsenposition setzen und eine Einheitensbeschriftung auf der Werteachse anzeigen.

## **Ermitteln der Maximalwerte auf der vertikalen Achse**
Aspose.Slides für C++ ermöglicht das Abrufen des Minimum‑ und Maximumwerts einer vertikalen Achse. Gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Ermitteln Sie den tatsächlichen Maximalwert der Achse.
1. Ermitteln Sie den tatsächlichen Minimalwert der Achse.
1. Ermitteln Sie die tatsächliche Haupteinheit der Achse.
1. Ermitteln Sie die tatsächliche Nebeneinheit der Achse.
1. Ermitteln Sie die tatsächliche Skala der Haupteinheit der Achse.
1. Ermitteln Sie die tatsächliche Skala der Nebeneinheit der Achse.

Dieser Beispielcode - eine Umsetzung der oben genannten Schritte - zeigt, wie Sie die erforderlichen Werte in C++ erhalten:

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

## **Daten zwischen Achsen austauschen**
Aspose.Slides ermöglicht es, die Daten zwischen Achsen schnell zu vertauschen – die auf der vertikalen Achse (y‑Achse) dargestellten Daten werden auf die horizontale Achse (x‑Achse) verschoben und umgekehrt.

Dieser C++‑Code zeigt, wie Sie den Datenaustausch zwischen Achsen in einem Diagramm durchführen:

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

Dieser C++‑Code zeigt, wie Sie die vertikale Achse für ein Liniendiagramm ausblenden:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Horizontale Achse für Liniendiagramme deaktivieren**

Dieser Code zeigt, wie Sie die horizontale Achse für ein Liniendiagramm ausblenden:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Kategorieachse ändern**

Mit der Methode **set_CategoryAxisType()** können Sie den gewünschten Typ der Kategorieachse (**date** oder **text**) festlegen. Dieser C++‑Code demonstriert die Vorgehensweise:

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
Aspose.Slides für C++ ermöglicht das Festlegen des Datumsformats für einen Wert der Kategorieachse. Der Vorgang wird in diesem C++‑Code demonstriert:

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
Aspose.Slides für C++ ermöglicht das Festlegen des Rotationswinkels für einen Diagrammachsentitel. Dieser C++‑Code demonstriert den Vorgang:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Achsenposition auf einer Kategorie‑ oder Wertachse festlegen**
Aspose.Slides für C++ ermöglicht das Festlegen der Position einer Achse in einer Kategorie‑ oder Wertachse. Dieser C++‑Code zeigt, wie Sie die Aufgabe ausführen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Anzeige der Einheitensbeschriftung auf einer Diagrammwertachse aktivieren**
Aspose.Slides für C++ ermöglicht es, ein Diagramm zu konfigurieren, sodass eine Einheitensbeschriftung auf seiner Werteachse angezeigt wird. Dieser C++‑Code demonstriert den Vorgang:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Wie lege ich den Wert fest, an dem eine Achse die andere schneidet (Achsenkreuzung)?**

Achsen bieten eine [Kreuzungseinstellung](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/axis/set_crosstype/): Sie können wählen, dass die Achsen bei Null, beim maximalen Kategorie‑/Wert‑Punkt oder bei einem spezifischen numerischen Wert kreuzen. Dies ist nützlich, um die X‑Achse nach oben oder unten zu verschieben oder eine Basislinie hervorzuheben.

**Wie kann ich die Tick‑Beschriftungen relativ zur Achse positionieren (neben, außen, innen)?**

Setzen Sie die [label position](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/axis/set_majortickmark/) auf "cross", "outside" oder "inside". Das beeinflusst die Lesbarkeit und hilft, Platz zu sparen, besonders bei kleinen Diagrammen.