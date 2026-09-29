---
title: Verwalten von Diagrammdatenserien in Präsentationen in C++
linktitle: Datenserien
type: docs
url: /de/cpp/chart-series/
keywords:
- Diagrammserie
- Serienüberlappung
- Serienfarbe
- Kategoriefarbe
- Serienname
- Datenpunkt
- Serienlücke
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagrammserien, Datenpunkte, Arbeitsmappendaten, Formatierungen, Überlappungen, Lückenbreite und negative Werte in Präsentationen mit C++ verwalten."
---
## **Übersicht**

Ein Diagramm speichert seine geplotteten Daten in einer Diagrammdaten‑Arbeitsmappe. Eine [IChartSeries](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/) repräsentiert einen Satz zusammengehöriger Werte, und jedes [IChartDataPoint](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/) in der Serie bezieht sich auf eine oder mehrere Arbeitsmappenzellen. [IChartCategory](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartcategory/)-Objekte liefern die Beschriftungen oder Gruppierungswerte, die von den Serien gemeinsam genutzt werden. Der Serienname, die Kategorien und die Punktwerte sind daher mit [IChartDataCell](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/)‑Objekten verbunden und nicht nur als Anzeigetext gespeichert.

Für ein typisches Kategoriediagramm verwendet die Standardsucharbeitsmappe Zeile 0 für Seriennamen, Spalte 0 für Kategorienamen und die übrigen Zellen für Serienwerte. Die an [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) übergebenen Arbeitsblatt‑, Zeilen‑ und Spaltenindizes sind nullbasiert. Dieses Layout ist nützlich, wenn Sie ein Diagramm mit Standarddaten erstellen, aber gehen Sie nicht davon aus, dass jedes vorhandene Diagramm es verwendet. Prüfen Sie für eine geladene Präsentation die von den Serien, Kategorien und Datenpunkten referenzierten Zellen, bevor Sie Arbeitsmappenwerte ändern.

Diagrammeinstellungen haben drei verschiedene Geltungsbereiche:

- Einstellungen auf Serienebene, wie [IChartSeries::get_Format](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/get_format/), legen das Standardaussehen für alle Punkte einer Serie fest.
- Datenpunkt‑Einstellungen, wie [IChartDataPoint::get_Format](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/get_format/), überschreiben das Serienaussehen für einen einzelnen Punkt.
- Gruppeneinstellungen gelten für kompatible Serien, die zur selben [IChartSeriesGroup](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseriesgroup/) gehören. Greifen Sie über [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) auf die Gruppe zu, wenn Sie Optionen wie Überlappung oder Lückenbreite festlegen müssen.

Wenn kein expliziter Punkt‑ oder Serien‑Füllstil gesetzt ist, bestimmen Diagramm‑Stil und -Thema das automatische Erscheinungsbild. Liegen sowohl Serien‑ als auch Punkt‑Formatierungen vor, hat die Punkt‑Formatierung Vorrang für diesen Punkt.

![Diagramm‑Serie‑PowerPoint](chart-series-powerpoint.png)

## **Überlappung der Diagrammserie festlegen**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/get_overlap/) gibt an, wie stark Balken oder Säulen in einem 2‑D‑Diagramm überlappen, von ‑100 bis 100 Prozent. Es ist eine schreibgeschützte Projektion der Einstellung der übergeordneten Seriengruppe. Rufen Sie [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) auf, um jede kompatible Serie in dieser Gruppe zu aktualisieren. Diese Option gilt für Diagrammtypen, die gruppierte Balken oder Säulen anzeigen; sie wirkt sich nicht auf nicht verwandte Seriensgruppen in einem Kombinationsdiagramm aus.

Das folgende Beispiel setzt die Überlappung für die Gruppe, die die erste Serie enthält:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// Das neue Diagramm enthält Beispieldaten für Serien, Kategorien und Werte.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die Serien‑Überlappung](series_overlap.png)

## **Füllfarbe der Serie ändern**

Verwenden Sie [IChartSeries::get_Format](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/get_format/), um die standardmäßige Füllung für eine gesamte Serie festzulegen. Hat ein Punkt bereits eine explizite Füllung, überschreibt dessen [IChartDataPoint::get_Format](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/get_format/) Einstellung die Serien‑Füllung für diesen Punkt.

Das folgende Beispiel wendet eine einfarbige blaue Füllung auf die erste Serie an:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die Farbe der Serie](series_color.png)

## **Seriennamen ändern**

Ein Serienname wird in der Diagrammdaten‑Arbeitsmappe gespeichert und normalerweise in der Legende angezeigt. In der Standardsucharbeitsmappe für ein gruppiertes Säulendiagramm befindet sich Zelle B1 in Zeile 0, Spalte 1 und enthält den Namen der ersten Serie. Die benannten Konstanten im folgenden Beispiel machen diese Struktur explizit:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Sie können außerdem die bereits von [IChartSeries::get_Name](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/get_name/) referenzierte Zelle aktualisieren. Dieser Ansatz vermeidet Annahmen über eine bestimmte Zeile und Spalte in einem bestehenden Diagramm:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Der Serienname](series_name.png)

## **Automatische Füllfarbe der Serie abrufen**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) gibt die aus dem Serienindex und dem Diagramm‑Stil berechnete Farbe zurück. Dies ist die Farbe, die verwendet wird, wenn die Serien‑Füllung nicht explizit definiert wurde. Der Aufruf der Methode liest die berechnete Farbe; er weist keine neue Füllung zu.

Das folgende Beispiel gibt die automatische Farbe jeder Standardserie aus:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

Beispielausgabe für den Standard‑Diagramm‑Stil:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Die genauen Farben hängen vom Diagramm‑Stil und -Thema ab.

## **Umgekehrte Füllfarbe für eine Diagrammserie festlegen**

Für Balken‑, Säulen‑ und Blasendiagramme kann [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) negative Werte mit einer anderen Füllung darstellen. Legen Sie die reguläre Serien‑Füllung auf einfarbig fest, aktivieren Sie die Inversion und bestimmen Sie die Farbe für negative Werte über [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Negative Zahlen bleiben in der Arbeitsmappe unverändert; nur ihre Anzeigefarbe ändert sich.

Das folgende Beispiel ersetzt die Standard‑Diagrammdaten durch eine Serie. Zeile 0 des Arbeitsblatts enthält den Seriennamen, Spalte 0 die Kategorienamen und Spalte 1 die Werte:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die umgekehrte einfarbige Füllfarbe](inverted_solid_fill_color.png)

Sie können die Inversion für einen Punkt über [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) aktivieren. Im folgenden Beispiel ist die Inversion für die Serie deaktiviert und nur für den ausgewählten Punkt aktiviert. Der Punkt erhält zudem einen negativen Wert, sodass der Effekt sichtbar wird:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Wert eines bestimmten Datenpunkts löschen**

Um einen Punkt leer zu lassen, ohne die anderen Punkte zu entfernen, setzen Sie dessen zugehörige Arbeitsmappenzelle auf `nullptr`. Für ein Säulendiagramm ist der geplottete Wert über [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) abrufbar. Der Datenpunkt bleibt an derselben Kategorieposition, das Diagramm behandelt den Wert jedoch als leer gemäß den Einstellungen für leere Werte.

Das folgende Beispiel löscht nur den zweiten Punkt in der ersten Serie:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Streudiagramme verwenden separate X‑ und Y‑Zellen, und Blasendiagramme nutzen zusätzlich eine Größenzelle. Löschen Sie nur die Zelle, die den zu entfernenden Wert darstellt. Rufen Sie nicht [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) auf, wenn Sie die anderen Punkte behalten wollen, da diese Methode alle Datenpunkte aus der Sammlung entfernt.

## **Anzeige leerer Zellen steuern**

Versteckte Zellen, die Werte enthalten, sind ein anderer Fall als leere Zellen. Um Daten aus versteckten Arbeitsblatt‑Zeilen und -Spalten ein- oder auszuschließen, siehe [Include Data from Hidden Rows and Columns](/slides/de/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns).

Eine leere Arbeitsmappenzelle steht für fehlende Daten; eine Zelle mit `0` steht für einen bekannten numerischen Wert. Rufen Sie [IChartDataCell::set_Value](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatacell/set_value/) mit `nullptr` auf, um die Zelle leer zu machen. Eine numerische Null bleibt eine Null, unabhängig von der Einstellung für leere Zellen.

Verwenden Sie [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/set_displayblanksas/), um auszuwählen, wie das Diagramm leere Zellen anzeigt. Diese Einstellung gilt für das gesamte Diagramm. Sie ändert, wie Lücken geplottet werden, ohne die leere Arbeitsmappenzelle mit Null oder einem interpolierten Wert zu füllen.

Das folgende eigenständige Beispiel erstellt ein Liniendiagramm mit einer Serie, löscht den Wert für Tag 3 und speichert das gleiche Diagramm in jedem Modus. Eine Eingabedatei ist nicht erforderlich. Der [IChartDataWorkbook](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/) verwendet Arbeitsblatt 0, Spalte 0 für Kategorien, und Spalte 1 für Werte; Zeile 0 hält den Seriennamen. Die Enddaten lauten `10, 20, empty, 30, 40`.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Lassen Sie Tag 3 wirklich leer, behalten jedoch seine Kategorie und den Datenpunkt bei.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

Jede Ausgabedatei speichert den vor dem Speichern zugewiesenen Modus: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` und `empty_cells_Span.pptx`. Um nur eine Version zu speichern, weisen Sie den gewünschten Modus zu und speichern die Präsentation einmal statt über die Modi zu iterieren.

Der Vergleich unten zeigt dieselben Daten in allen drei Dateien. Tag 3 ist in der Arbeitsmappe in jedem Fall leer:

![Liniendiagramme mit identischen Daten: Gap bricht die Linie bei Tag 3, Zero lässt die Linie auf Null fallen, Span verbindet Tag 2 mit Tag 4.](display_blanks_as.png)

Der sichtbare Effekt hängt vom Diagrammtyp ab. Ein Liniendiagramm ermöglicht einen einfachen Vergleich aller drei Modi. Balken‑ und Säulendiagramme haben keine Linie, die über eine fehlende Kategorie hinweg verbindet, sodass `Span` nicht das oben gezeigte Verbindungselement erzeugen kann; eine fehlende Säule und eine Säule mit Höhe 0 können ebenfalls ähnlich aussehen. Ebenso hat ein Streudiagramm mit nur Markern keine Verbindungslinie. Erwarten Sie nicht für jeden Diagrammtyp drei unterschiedliche Ergebnisse; prüfen Sie die Ausgabe für den von Ihnen verwendeten Typ.

## **Lückenbreite der Serie festlegen**

Die Lückenbreite ist der Abstand zwischen benachbarten Balken‑ oder Säulen‑Clustern, ausgedrückt als Prozentsatz der Balken‑ bzw. Säulenbreite. Wie die Überlappung gehört sie zur übergeordneten Seriengruppe und nicht zu einer einzelnen Serie. Rufen Sie [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) einmal für die Gruppe auf. Ein größerer Wert erzeugt mehr Abstand zwischen den Clustern; ein kleinerer Wert macht sie dichter.

Das folgende Beispiel ändert die Lückenbreite und speichert nur die finale Präsentation:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Das Ergebnis:

![Die Lückenbreite](gap_width.png)

## **FAQ**

**Welche Diagrammtypen unterstützen Datenserien?**

Alle Diagrammtypen, die durch die [ChartType](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/charttype/)-Aufzählung repräsentiert werden, nutzen Diagrammdaten, aber ihre Serien haben nicht immer dieselbe Werte‑Struktur oder dieselben Einstellungen. Beispielsweise verwenden Kategoriediagramme Kategorien und Werte, Streudiagramme X‑ und Y‑Werte, und Blasendiagramme zusätzlich Blasengrößen. Verwenden Sie die Datenpunkt‑Erstellungsmethode, die zum Serientyp passt. Optionen wie Überlappung und Lückenbreite gelten nur für kompatible Balken‑ oder Säulengruppen.

**Was ist eine Diagrammseriengruppe?**

Eine [IChartSeriesGroup](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseriesgroup/) enthält kompatible Serien, die gruppenweite Darstellungs‑Einstellungen teilen. Ein Kombinationsdiagramm kann mehr als eine Gruppe enthalten, sodass das Ändern der Gruppe über eine Serie nicht zwingend jede Serie im Diagramm ändert.

**Enthält ein neu erstelltes Diagramm Standarddaten?**

Ja. Standardmäßig erzeugt [IShapeCollection::AddChart](https://reference.aspose.com/slides/de/cpp/aspose.slides/ishapecollection/addchart/) Beispieldaten für Serien, Kategorien und Werte. Sie können diese Zellen bearbeiten oder sowohl die Serien‑ als auch die Kategoriesammlungen löschen, bevor Sie ein komplett benutzerdefiniertes Datenset hinzufügen. Eine Überladung kann zudem ein Diagramm ohne Standarddaten erzeugen.

**Wie sind Diagrammobjekte mit Arbeitsmappendaten verknüpft?**

Seriennamen, Kategorienbeschriftungen und Datenpunktwerte verweisen auf Zellen in einem [IChartDataWorkbook](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/). Das Ändern einer referenzierten Zelle aktualisiert das zugehörige Diagrammelement. Beim Erstellen benutzerdefinierter Daten sollten Sie Kategorien‑Zeilen und Serien‑Werte‑Zeilen ausrichten, sodass jeder Punkt unter der beabsichtigten Kategorie geplottet wird.

**Wie lösche ich einen Punkt statt der gesamten Serie?**

Setzen Sie die relevante Wertzelle auf `nullptr`, um die Position des Punktes als leeren Punkt beizubehalten. Rufen Sie [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) nur auf, wenn Sie alle Punkte dieser Serie entfernen wollen. Entfernen Sie außerdem nicht die Kategorien, ohne jede Serie anzupassen, damit deren Werte weiterhin mit der Kategoriesammlung übereinstimmen.

**Wie werden leere Punkte angezeigt?**

Das Ergebnis hängt vom Diagrammtyp und von [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/get_displayblanksas/) ab. Unterstützte Diagramme können Lücken als Lücken, als Null‑Werte oder durch Verbinden benachbarter Punkte darstellen. Wählen Sie die Einstellung, die der Bedeutung fehlender Daten in Ihrer Präsentation entspricht. Siehe [Anzeige leerer Zellen steuern](#control-the-display-of-empty-cells) für ein vollständiges Beispiel und einen visuellen Vergleich.

**Wie werden negative Werte formatiert?**

Für unterstützte Balken‑, Säulen‑ und Blasendiagramme rufen Sie [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) auf und setzen die Farbe über [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Sie können das Verhalten für einen einzelnen Punkt mit [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) überschreiben. Diese Methoden beeinflussen die Formatierung, nicht die gespeicherten numerischen Werte.

**Welche Formatierung gewinnt, wenn sowohl eine Serie als auch ein Punkt formatiert sind?**

Explizite Datenpunkt‑Formatierung hat Vorrang für diesen Punkt. Andere Punkte verwenden weiterhin das explizite Serienformat oder, wenn das Serienformat nicht definiert ist, den automatischen Diagramm‑Stil und das Theme. Gruppeneinstellungen wie Überlappung und Lückenbreite steuern das Layout und sind keine Formatierungs‑Überschreibungen auf Punktebene.

**Gibt es ein Limit für die Anzahl von Serien in einem Diagramm?**

Aspose.Slides legt kein separates festes Serien‑Zähl‑Limit fest. In der Praxis bestimmen Dateigrößen‑Beschränkungen, verfügbarer Speicher, Renderzeit und die Lesbarkeit des Diagramms ein sinnvolles Limit.

**Was soll ich ändern, wenn Säulen zu eng oder zu weit auseinander liegen?**

Rufen Sie [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) auf der entsprechenden übergeordneten Seriengruppe auf. Erhöhen Sie den Wert, um den Abstand zwischen den Clustern zu vergrößern, oder verringern Sie ihn, um die Cluster näher zusammenzubringen.