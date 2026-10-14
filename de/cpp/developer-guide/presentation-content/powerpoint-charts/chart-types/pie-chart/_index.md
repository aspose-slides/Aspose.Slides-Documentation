---
title: Kreisdiagramme in Präsentationen mit C++ anpassen
linktitle: Kreisdiagramm
type: docs
url: /de/cpp/pie-chart/
keywords:
- Kreisdiagramm
- Diagramm verwalten
- Diagramm anpassen
- Diagrammoptionen
- Diagrammeinstellungen
- Plot-Optionen
- Segmentfarbe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen und Anpassen von Kreisdiagrammen in C++ mit Aspose.Slides. Sekundäre Plots konfigurieren, Datenbeschriftungen anzeigen und automatische Segmentfarben in PowerPoint anwenden."
---
## **Übersicht**

Der Artikel erklärt, wie man mit Kreisdiagrammen in Aspose.Slides arbeitet. Er zeigt, wie man sekundäre Plot‑Optionen für Pie of Pie‑ und Bar of Pie‑Diagramme konfiguriert und wie man die automatische Färbung von Segmenten für ein Standard‑Kreisdiagramm aktiviert.

Die Beispiele konzentrieren sich auf Diagrammanpassungsaufgaben wie das Hinzufügen eines Diagramms zu einer Folie, das Anpassen von Serien‑ und Beschriftungseinstellungen, das Ersetzen der Standarddiagrammdaten durch benutzerdefinierte Kategorien und Werte sowie das Speichern der aktualisierten Präsentation.

## **Optionen für sekundäre Plots bei Pie of Pie- und Bar of Pie-Diagrammen**

Aspose.Slides für C++ unterstützt Optionen für sekundäre Plots bei Pie of Pie- und Bar of Pie‑Diagrammen. Diese Optionen steuern die Größe des sekundären Plots und wie Datenpunkte zwischen den beiden Plots aufgeteilt werden.

Im folgenden Beispiel wird ein Pie of Pie‑Diagramm in einer neuen Präsentation erstellt und die Werte der Datenpunkte als Beschriftungen angezeigt. Die [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) Methode setzt die Größe des sekundären Plots auf 149 % des Hauptplots. [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) wählt prozentbasierte Aufteilung, und [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) legt den Schwellenwert auf 53 % fest.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

// Display values and configure the secondary plot.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_SecondPieSize(149);
seriesGroup->set_PieSplitBy(PieSplitType::ByPercentage);
seriesGroup->set_PieSplitPosition(53);

presentation->Save(u"pie_of_pie.pptx", SaveFormat::Pptx);
```

### **Kategorien für den sekundären Plot auswählen**

Verwenden Sie benutzerdefinierte Aufteilung, wenn Sie bestimmte Kategorien im sekundären Plot gruppieren möchten, unabhängig von deren prozentualen Werten. Zum Beispiel kann ein Verkaufsbericht Online und Events zusammen anzeigen, damit die Leser diese beiden Kanäle vergleichen können, obwohl sie 35 % bzw. 10 % des Gesamtumsatzes ausmachen.

Rufen Sie [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) mit [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) auf und wählen Sie die Punkte über [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/). Die [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/)‑Methode der Sammlung akzeptiert einen nullbasierten Index in der Serie. In diesem Beispiel wählt Index 1 Online aus und Index 3 Events. Partners wird ebenfalls vorübergehend hinzugefügt und dann mit [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/) ausgeschlossen.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IPieSplitCustomPointCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 200);

// Ersetzen Sie die Standarddaten durch Verkäufe nach Kanal.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"Retail", u"Online", u"Partners", u"Events" };
auto values = std::vector<int>{ 40, 35, 15, 10 };
auto seriesNameCell = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_PieSplitBy(PieSplitType::Custom);
seriesGroup->set_IsColorVaried(true);

// Wählen Sie Online und Events anhand ihrer nullbasierten Indizes in der Serie aus.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// Schließen Sie Partners von der Auswahl aus, ohne deren Quelldaten zu löschen.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Online (35) und Events (10) erscheinen als separate Segmente im sekundären Plot. Im primären Plot werden sie durch ein kombiniertes Segment mit dem Wert 45 dargestellt, zusammen mit Retail (40) und Partners (15). Das Entfernen von Partners aus der benutzerdefinierten Auswahl lässt es im primären Plot erhalten; die Kategorie oder ihr Wert werden nicht aus den Quelldaten des Diagramms entfernt.

Das folgende Bild zeigt die gespeicherte Präsentation in PowerPoint:

![Kreisdiagramm Pie of Pie mit Online und Events im sekundären Plot und ihrem kombinierten Wert von 45 im primären Plot](pie_of_pie_custom.png)

## **Automatische Farben für Pie‑Diagrammsegmente festlegen**

Aspose.Slides für C++ kann automatisch verschiedene Farben den Segmenten eines Kreisdiagramms zuweisen. Das folgende Beispiel erstellt ein Kreisdiagramm mit einem zentrierten Titel und ersetzt die Standarddaten durch drei Quartalskategorien und deren Werte.

Die [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/)‑Methode zeigt die Werte 20, 50 und 30 als Beschriftungen an, während [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) für jede Scheibe eine unterschiedliche Farbe aktiviert.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 100, 100, 400, 400);

// Fügen Sie einen zentrierten Diagrammtitel hinzu.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// Ersetzen Sie die Standarddaten mithilfe des ersten Arbeitsblatts.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"First Qtr", u"2nd Qtr", u"3rd Qtr" };
auto values = std::vector<int>{ 20, 50, 30 };
auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, System::ObjectExt::Box(System::String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

// Werte anzeigen und verschiedenen Segmenten unterschiedliche Farben zuweisen.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Werden die Pie of Pie- und Bar of Pie-Varianten unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) einen sekundären Plot für Kreisdiagramme, einschließlich der Pie of Pie- und Bar of Pie‑Typen.

**Kann ich nur das Diagramm als Bild exportieren (z. B. PNG)?**

Ja, Sie können [das Diagramm selbst als Bild exportieren](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (wie PNG) exportieren, ohne die gesamte Präsentation zu exportieren.