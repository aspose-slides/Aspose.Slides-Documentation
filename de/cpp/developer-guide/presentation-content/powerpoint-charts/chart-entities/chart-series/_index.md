---
title: Diagrammserien
type: docs
url: /de/cpp/chart-series/
---

Eine Serie ist eine Zeile oder Spalte von Zahlen, die in einem Diagramm dargestellt wird.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Diagrammserienüberlappung festlegen**

Mit der [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) Methode können Sie angeben, wie stark Balken und Spalten in einem 2D-Diagramm überlappen sollen (Bereich: -100 bis 100). Diese Eigenschaft gilt für alle Serien der übergeordneten Seriengruppe: Dies ist eine Projektion der entsprechenden Gruppeneigenschaft.

Verwenden Sie die `get_ParentSeriesGroup()::set_Overlap()` Methode, um Ihren bevorzugten Wert für `Overlap` festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Fügen Sie ein gruppiertes Säulendiagramm auf einer Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu.
1. Greifen Sie auf die `ParentSeriesGroup` der Diagrammserie zu und setzen Sie Ihren bevorzugten Überlappungswert für die Serie.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie die Überlappung für eine Diagrammserie festlegen:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Fügt das Diagramm hinzu
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Setzt die Serienüberlappung
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Speichert die Präsentationsdatei auf der Festplatte
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Serienfarbe ändern**
Aspose.Slides für C++ ermöglicht es Ihnen, die Farbe einer Serie auf folgende Weise zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Greifen Sie auf die Serie zu, deren Farbe Sie ändern möchten.
1. Setzen Sie Ihren bevorzugten Fülltyp und die Füllfarbe.
1. Speichern Sie die modifizierte Präsentation.

Dieser C++-Code zeigt Ihnen, wie Sie die Farbe einer Serie ändern:

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

## **Farben der Serienkategorie ändern**
Aspose.Slides für C++ ermöglicht es Ihnen, die Farbe einer Serienkategorie auf folgende Weise zu ändern:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Greifen Sie auf die Serienkategorie zu, deren Farbe Sie ändern möchten.
1. Setzen Sie Ihren bevorzugten Fülltyp und die Füllfarbe.
1. Speichern Sie die modifizierte Präsentation.

Dieser Code in C++ zeigt Ihnen, wie Sie die Farbe einer Serienkategorie ändern:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Seriennamen ändern**

Standardmäßig sind die Legendenamen für ein Diagramm die Inhalte der Zellen über jeder Spalte oder Zeile von Daten.

In unserem Beispiel (Beispielbild):

* die Spalten sind *Serie 1, Serie 2,* und *Serie 3*;
* die Zeilen sind *Kategorie 1, Kategorie 2, Kategorie 3,* und *Kategorie 4.* 

Aspose.Slides für C++ ermöglicht es Ihnen, einen Seriennamen in seinen Diagrammdaten und der Legende zu aktualisieren oder zu ändern.

Dieser C++-Code zeigt Ihnen, wie Sie einen Seriennamen in seinen Diagrammdaten `ChartDataWorkbook` ändern:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"Neuer Name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Dieser C++-Code zeigt Ihnen, wie Sie einen Seriennamen in seiner Legende über `Series` ändern:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"Neuer Name"));
```

## **Füllfarbe der Diagrammserie festlegen**

Aspose.Slides für C++ ermöglicht es Ihnen, die automatische Füllfarbe für Diagrammserien innerhalb eines Plotbereichs auf folgende Weise festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel verwendeten wir `ChartType::ClusteredColumn`).
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf automatisch.
1. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser C++-Code zeigt Ihnen, wie Sie die automatische Füllfarbe für eine Diagrammserie festlegen:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Erstellt ein gruppiertes Säulendiagramm
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Setzt das Füllformat der Serien auf automatisch
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Speichert die Präsentationsdatei auf der Festplatte
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Füllfarben der Diagrammserie invertieren**
Aspose.Slides ermöglicht es Ihnen, die invertierte Füllfarbe für Diagrammserien innerhalb eines Plotbereichs auf folgende Weise festzulegen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten basierend auf Ihrem bevorzugten Typ hinzu (im folgenden Beispiel verwendeten wir `ChartType::ClusteredColumn`).
1. Greifen Sie auf die Diagrammserie zu und setzen Sie die Füllfarbe auf invertiert.
1. Speichern Sie die Präsentation in einer PPTX-Datei.

Dieser C++-Code demonstriert die Operation:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Fügt neue Serien und Kategorien hinzu
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Serie 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Kategorie 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Kategorie 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Kategorie 3")));

// Nimmt die erste Diagrammserie und füllt ihre Seriendaten.
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

## **Serien invertieren, wenn der Wert negativ ist**
Aspose.Slides ermöglicht es Ihnen, Inversionen über die Methoden `IChartDataPoint::set_InvertIfNegative()` und `ChartDataPoint.set_InvertIfNegative()` festzulegen. Wenn eine Inversion mithilfe der Methoden festgelegt wird, invertiert der Datenpunkt seine Farben, wenn er einen negativen Wert erhält.

Dieser C++-Code demonstriert die Operation:

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

## **Spezifische Datenpunktdaten löschen**
Aspose.Slides für C++ ermöglicht es Ihnen, die `DataPoints`-Daten für eine bestimmte Diagrammserie auf folgende Weise zu löschen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
2. Erhalten Sie die Referenz einer Folie anhand ihres Index.
3. Erhalten Sie die Referenz eines Diagramms anhand seines Index.
4. Iterieren Sie durch alle Diagramm `DataPoints` und setzen Sie `XValue` und `YValue` auf null.
5. Löschen Sie alle `DataPoints` für bestimmte Diagrammserien.
6. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser C++-Code demonstriert die Operation:

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

## **Serienabstand einstellen**
Aspose.Slides für C++ ermöglicht es Ihnen, den Abstand einer Serie über die **`set_GapWidth()`** Methode auf folgende Weise einzustellen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Greifen Sie auf eine beliebige Diagrammserie zu.
1. Setzen Sie die `GapWidth`-Eigenschaft.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

Dieser Code in C++ zeigt Ihnen, wie Sie den Abstand einer Serie einstellen:

```cpp
// Erstellt eine leere Präsentation 
auto presentation = System::MakeObject<Presentation>();

// Greift auf die erste Folie der Präsentation zu
auto slide = presentation->get_Slides()->idx_get(0);

// Fügt ein Diagramm mit Standarddaten hinzu
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Setzt den Index des Diagrammdatenblatts
int32_t worksheetIndex = 0;

// Holt das Diagrammdatenarbeitsblatt
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Fügt Serien hinzu
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Serie 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Serie 2")), chart->get_Type());

// Fügt Kategorien hinzu
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Kategorie 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Kategorie 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Kategorie 3")));

// Nimmt die zweite Diagrammserie
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Füllt die Seriendaten
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Setzt den GapWidth-Wert
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Speichert die Präsentation auf der Festplatte
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```