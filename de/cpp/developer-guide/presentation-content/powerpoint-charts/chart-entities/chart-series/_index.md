---
title: Diagrammdatenserien in Präsentationen mit C++ verwalten
linktitle: Datenserien
type: docs
url: /de/cpp/chart-series/
keywords:
- Diagrammserie
- Serienüberlappung
- Serienfarbe
- Kategorienfarbe
- Serienname
- Datenpunkt
- Serienlücke
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien in C++ für PowerPoint (PPT/PPTX) verwalten, mit praktischen Codebeispielen und bewährten Methoden, um Ihre Datenpräsentationen zu verbessern."
---

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt werden.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Überschneidung der Datenserie festlegen**

Mit der [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb)-Methode können Sie festlegen, wie stark Balken und Säulen in einem 2D-Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Serien der übergeordneten Seriengruppe: Dies ist eine Projektion der entsprechenden Gruppeneigenschaft.

Verwenden Sie die Methode `get_ParentSeriesGroup()::set_Overlap()`, um Ihren gewünschten Wert für `Overlap` festzulegen. 

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Fügen Sie einer Folie ein gruppiertes Säulendiagramm hinzu.
1. Greifen Sie auf die erste Diagrammserie zu.
1. Greifen Sie auf die `ParentSeriesGroup` der Diagrammserie zu und setzen Sie den gewünschten Überschneidungswert für die Serie. 
1. Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.

This C++ code shows you how to set the overlap for a chart series:
```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Fügt Diagramm hinzu
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Setzt die Serienüberlappung
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Schreibt die Präsentationsdatei auf die Festplatte
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```


## **Farbe der Datenserie ändern**

Aspose.Slides für C++ ermöglicht das Ändern der Farbe einer Serie wie folgt:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Fügen Sie dem Folienbereich ein Diagramm hinzu.
1. Greifen Sie auf die Serie zu, deren Farbe Sie ändern möchten. 
1. Setzen Sie Ihren gewünschten Fülltyp und Ihre Füllfarbe.
1. Speichern Sie die geänderte Präsentation.

This C++ code shows you how to change a series' color:
```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Farbe einer Datenserien‑Kategorie ändern**

Aspose.Slides für C++ ermöglicht das Ändern der Farbe einer Seriekategorie wie folgt:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Fügen Sie dem Folienbereich ein Diagramm hinzu.
1. Greifen Sie auf die Seriekategorie zu, deren Farbe Sie ändern möchten.
1. Setzen Sie Ihren gewünschten Fülltyp und Ihre Füllfarbe.
1. Speichern Sie die geänderte Präsentation.

This code in C++ shows you how to change a series category's color:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **Namen der Datenserie ändern** 

Standardmäßig sind die Legendenbeschriftungen eines Diagramms die Inhalte der Zellen über jeder Spalte oder Zeile der Daten. 

In unserem Beispiel (Beispielbild) gilt: 

* Die Spalten sind *Series 1, Series 2* und *Series 3*;
* Die Zeilen sind *Category 1, Category 2, Category 3* und *Category 4*. 

Aspose.Slides für C++ ermöglicht das Aktualisieren oder Ändern des Namens einer Serie in den Diagrammdaten und in der Legende. 

This C++ code shows you how to change a series' name in its chart data `ChartDataWorkbook`:
```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


This C++ code shows you how to change a series name in its legend through`Series`:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```


## **Füllfarbe der Datenserie festlegen**

Aspose.Slides für C++ ermöglicht das Festlegen der automatischen Füllfarbe für Diagrammserien im Plotbereich wie folgt:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, basierend auf Ihrem bevorzugten Typ (im folgenden Beispiel wurde `ChartType::ClusteredColumn` verwendet).
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf Automatic.
1. Speichern Sie die Präsentation in einer PPTX-Datei.

This C++ code shows you how to set the automatic fill color for a chart series:
```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Erstellt ein gruppiertes Säulendiagramm
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Setzt das Füllformat der Serie auf automatisch
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Schreibt die Präsentationsdatei auf die Festplatte
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```


## **Invertierte Füllfarben für Datenserie festlegen**

Aspose.Slides ermöglicht das Festlegen invertierter Füllfarben für Diagrammserien im Plotbereich wie folgt:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Holen Sie sich eine Folienreferenz über ihren Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, basierend auf Ihrem bevorzugten Typ (im folgenden Beispiel wurde `ChartType::ClusteredColumn` verwendet).
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf invert.
1. Speichern Sie die Präsentation in einer PPTX-Datei.

This C++ code demonstrates the operation:
```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```


## **Invertierte Füllfarbe für eine Diagrammserie festlegen**

Aspose.Slides ermöglicht das Setzen von Invertierungen über die Methoden `IChartDataPoint::set_InvertIfNegative()` und `ChartDataPoint.set_InvertIfNegative()`. Wird eine Invertierung über diese Methoden gesetzt, ändert der Datenpunkt seine Farben, sobald er einen negativen Wert erhält. 

This C++ code demonstrates the operation:
```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```


## **Spezifische Datenpunktwerte löschen**

Aspose.Slides für C++ ermöglicht das Löschen der `DataPoints`‑Daten für eine bestimmte Diagrammserie wie folgt:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Holen Sie sich die Referenz eines Diagramms über seinen Index.
4. Durchlaufen Sie alle `DataPoints` des Diagramms und setzen Sie `XValue` und `YValue` auf null.
5. Löschen Sie alle `DataPoints` für die spezifische Diagrammserie.
6. Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.

This C++ code demonstrates the operation:
```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```


## **Lückenbreite der Datenserie festlegen**

Aspose.Slides für C++ ermöglicht das Festlegen der Lückenbreite einer Serie über die **`set_GapWidth()`**‑Methode wie folgt:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Greifen Sie auf eine beliebige Diagrammserie zu.
1. Setzen Sie die Eigenschaft `GapWidth`.
1. Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.

This code in C++ shows you how to set a series' Gap Width:
```cpp
// Erstellt leere Präsentation 
auto presentation = System::MakeObject<Presentation>();

// Greift auf die erste Folie der Präsentation zu
auto slide = presentation->get_Slides()->idx_get(0);

// Fügt ein Diagramm mit Standarddaten hinzu
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Setzt den Index des Diagrammdatenblatts
int32_t worksheetIndex = 0;

// Holt das Diagrammdaten-Arbeitsblatt
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Fügt Serien hinzu
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Fügt Kategorien hinzu
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Nimmt die zweite Diagrammserie
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Befüllt die Seriendaten
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Setzt den GapWidth-Wert
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Speichert die Präsentation auf dem Datenträger
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```



## **FAQ**

**Gibt es eine Grenze, wie viele Serien ein einzelnes Diagramm enthalten kann?**

Aspose.Slides setzt keine feste Obergrenze für die Anzahl der hinzugefügten Serien. Praktisch begrenzt werden Sie durch die Lesbarkeit des Diagramms und den verfügbaren Speicher Ihrer Anwendung.

**Was tun, wenn die Spalten innerhalb eines Clusters zu eng oder zu weit auseinander liegen?**

Passen Sie die Lückenbreite‑Einstellung für diese Serie (oder ihre übergeordnete Seriengruppe) an. Ein höherer Wert vergrößert den Abstand zwischen den Spalten, ein niedrigerer Wert bringt sie näher zusammen.