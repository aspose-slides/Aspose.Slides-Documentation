---
title: Diagrammachse
type: docs
url: /cpp/chart-axis/
keywords: "PowerPoint Diagrammachse, Präsentationsdiagramme, C++, Diagrammachse manipulieren, Diagrammdaten"
description: "Wie man die Diagrammachse in PowerPoint in C++ bearbeitet"
---


## **Maximalwerte der vertikalen Achse in Diagrammen erhalten**
Aspose.Slides für C++ ermöglicht es Ihnen, die minimalen und maximalen Werte auf einer vertikalen Achse zu erhalten. Befolgen Sie diese Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Erhalten Sie den tatsächlichen Maximalwert auf der Achse.
1. Erhalten Sie den tatsächlichen Minimalwert auf der Achse.
1. Erhalten Sie die tatsächliche Haupteinheit der Achse.
1. Erhalten Sie die tatsächliche Nebeneinheit der Achse.
1. Erhalten Sie den tatsächlichen Hauptmaßstab der Achse.
1. Erhalten Sie den tatsächlichen Nebeneinheitsmaßstab der Achse.

Dieser Beispielcode – eine Umsetzung der oben genannten Schritte – zeigt Ihnen, wie Sie die erforderlichen Werte in C++ erhalten:

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


## **Daten zwischen Achsen tauschen**
Aspose.Slides ermöglicht es Ihnen, die Daten zwischen den Achsen schnell zu tauschen – die auf der vertikalen Achse dargestellten Daten (y-Achse) wechseln zur horizontalen Achse (x-Achse) und umgekehrt. 

Dieser C++-Code zeigt Ihnen, wie Sie die Daten zwischen den Achsen auf einem Diagramm tauschen:

``` cpp
// Erstellt eine leere Präsentation
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Tauscht Zeilen und Spalten
chart->get_ChartData()->SwitchRowColumn();

// Speichert die Präsentation
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Die vertikale Achse für Liniendiagramme deaktivieren**

Dieser C++-Code zeigt Ihnen, wie Sie die vertikale Achse für ein Liniendiagramm ausblenden:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Die horizontale Achse für Liniendiagramme deaktivieren**

Dieser Code zeigt Ihnen, wie Sie die horizontale Achse für ein Liniendiagramm ausblenden:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Kategorieachse ändern**

Mit der **set_CategoryAxisType()**-Methode können Sie Ihren bevorzugten Typ der Kategorieachse (**Datum** oder **Text**) festlegen. Dieser C++-Code demonstriert die Operation:

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

## **Das Datumsformat für den Wert der Kategorieachse festlegen**
Aspose.Slides für C++ ermöglicht es Ihnen, das Datumsformat für einen Wert der Kategorieachse festzulegen. Die Operation wird in diesem C++-Code demonstriert:

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

## **Den Rotationswinkel für den Titel der Diagrammachse festlegen**
Aspose.Slides für C++ ermöglicht es Ihnen, den Rotationswinkel für den Titel einer Diagrammachse festzulegen. Dieser C++-Code demonstriert die Operation:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Die Positionsachse in einer Kategorie- oder Wertenachse festlegen**
Aspose.Slides für C++ ermöglicht es Ihnen, die Positionsachse in einer Kategorie- oder Wertenachse festzulegen. Dieser C++-Code zeigt, wie Sie die Aufgabe durchführen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Aktivieren der Anzeigewerteinheiten auf der Diagrammwertachse**
Aspose.Slides für C++ ermöglicht es Ihnen, ein Diagramm zu konfigurieren, um ein Werteinheitenetikett auf seiner Diagrammwertachse anzuzeigen. Dieser C++-Code demonstriert die Operation:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```