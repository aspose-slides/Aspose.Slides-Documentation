---
title: Diagrammarbeitsmappen in Präsentationen mit C++ verwalten
linktitle: Diagrammarbeitsmappe
type: docs
weight: 70
url: /de/cpp/chart-workbook/
keywords:
- Diagrammarbeitsmappe
- Diagrammdaten
- Arbeitsmappenzelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externe Arbeitsmappe
- externe Daten
- Diagramm-Cache
- Arbeitsmappenwiederherstellung
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für C++: Verwalten Sie Diagrammarbeitsmappen in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie man Diagrammdaten über Arbeitsmappen‑Streams liest und schreibt, Arbeitsmappen‑Zellen als Diagramm‑Datenbeschriftungen verwendet, auf Arbeitsblatt‑Sammlungen zugreift und den Datentyp der Quelle für Diagrammwerte festlegt.

Er behandelt zudem die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme. Die Beispiele demonstrieren, wie man eine externe Arbeitsmappe erstellt und zuweist, den Pfad einer externen Arbeitsmappe, die mit einem Diagramm verknüpft ist, ermittelt und Diagrammdaten bearbeitet, wenn die Arbeitsmappe verfügbar ist.

Für Arbeitsmappen‑Zellen, die fehlende Daten darstellen, siehe [Steuerung der Anzeige leerer Zellen](/slides/de/cpp/chart-series/) für den Unterschied zwischen einer leeren Zelle und Null sowie einen Liniendiagramm‑Vergleich der verfügbaren Anzeigemodi.

## **Daten aus versteckten Zeilen und Spalten einbeziehen**

Verwenden Sie [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/), um zu steuern, ob ein Diagramm Daten aus versteckten Arbeitsblatt‑Zeilen und -Spalten plotten soll. Setzen Sie es auf `true`, um nur sichtbare Zellen zu plotten, oder auf `false`, um sowohl sichtbare als auch versteckte Zellen einzubeziehen. Diese Einstellung steuert das Plotten des Diagramms; sie blendet keine Arbeitsblatt‑Zeilen oder -Spalten ein oder aus.

Die [Beispielpräsentation](hidden-source-data.pptx) enthält ein Säulendiagramm als erste Form auf ihrer ersten Folie. Das eingebettete Arbeitsblatt `Sheet1` enthält den folgenden Quellbereich `A1:C4`. Zeile 3 und Spalte C sind versteckt, aber ihre Zellen enthalten weiterhin Werte.

| Arbeitsblattzeile | A: Monat | B: Einzelhandel | C: Großhandel (versteckte Spalte) |
| --- | --- | --- | --- |
| 2 | Januar | 10 | 30 |
| 3 (versteckte Zeile) | Februar | 40 | 60 |
| 4 | März | 20 | 50 |

Greifen Sie über [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) auf Quellzellen zu und lesen Sie [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/), um deren versteckten Status zu prüfen. Diese Eigenschaft ist schreibgeschützt. In dieser Datei ist B2 sichtbar, B3 gehört zur versteckten Zeile und C2 zur versteckten Spalte; das Beispiel gibt `False`, `True` bzw. `True` aus.

Für dieses Beispiel aktualisieren Sie die Diagrammdaten nach Änderung der Plot‑Einstellung: behalten Sie die eingebettete Arbeitsmappe mit [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) und laden Sie sie mit [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) erneut. Beim Einbeziehen aller Zellen verwenden Sie zudem [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/), um den vollständigen Bereich inklusive der versteckten Februar‑Kategorie wiederherzustellen. Einfach das Flag zu ändern reicht nicht aus, um die zwischengespeicherten Diagrammdaten und Kategorienamen dieses Beispiels zu aktualisieren.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // Diagrammdaten aus der eingebetteten Arbeitsmappe aktualisieren.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Den vollständigen Quellbereich wiederherstellen, einschließlich versteckter Kategorien.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Das Beispiel speichert zwei Versionen der Präsentation: eine nur mit den sichtbaren Einzelhandelswerten (10 und 20) und eine mit allen sechs Werten. Die untenstehenden Bilder zeigen die beiden Plot‑Modi. Zeile 3 und Spalte C bleiben in beiden eingebetteten Arbeitsmappen versteckt.

| Nur sichtbare Zellen (`true`) | Alle Zellen (`false`) |
| --- | --- |
| ![Nur sichtbare Zellen: Einzelhandelswerte 10 und 20 für Januar und März.](hidden_cells_True.png) | ![Alle Zellen: Einzelhandels‑ und Großhandelswerte für Januar, Februar und März.](hidden_cells_False.png) |

Eine versteckte Zelle, die einen Wert enthält, unterscheidet sich von einer leeren Zelle. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) steuert, wie fehlende Werte angezeigt werden; sie schließt keine versteckten Quelldaten ein oder aus. Siehe [Steuerung der Anzeige leerer Zellen](/slides/de/cpp/chart-series/#control-the-display-of-empty-cells) für ein Beispiel.

## **Datenbereich eines Diagramms abrufen**

Bevor Sie Arbeitsmappendaten in einer bestehenden Präsentation aktualisieren, prüfen Sie die Quellbereiche, um zu ermitteln, welche Arbeitsblatt‑Zellen jedes Diagramm verwendet. Die Methode [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) gibt den aktuellen Datenbereich als arbeitsblattqualifizierte Formel zurück, z. B. `Sheet1!$A$1:$D$5`. Hier ist `Sheet1` der Arbeitsblatt‑Name, `!` trennt ihn vom Zellbereich, und `$A$1:$D$5` bezeichnet die Zellen A1 bis D5 inkl. Die Dollar‑Zeichen kennzeichnen absolute Zeilen‑ und Spaltenbezüge.

Die Methode liest den aktuellen Bereich, ohne das Diagramm oder seine Arbeitsmappe zu ändern. Wenn das Diagramm keine Arbeitsmappe als Datenquelle verwendet, wird eine [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) ausgelöst. Weitere Informationen finden Sie in der [ChartData‑API‑Referenz](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Dieses Beispiel öffnet eine Präsentation und prüft die Formen jeder Folie direkt auf Diagramme. Es gibt den Namen jedes Diagramms und den Quellbereich aus. Wenn ein Diagramm keine Arbeitsmappe verwendet, gibt es eine Meldung aus und fährt mit dem nächsten Diagramm fort.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**

Aspose.Slides für C++ stellt die Methoden [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) und [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) bereit, mit denen Sie Arbeitsmappen‑Diagrammdaten (die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis:** Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine dem Quellformat ähnliche Struktur besitzen.

Dieses Beispiel verwendet eine Präsentation mit einem Diagramm als erste Form auf ihrer ersten Folie. Es liest die eingebettete Arbeitsmappe in einen Stream, löscht die vorhandenen Serien und Kategorien und schreibt dieselbe Arbeitsmappe zurück. Die Änderungen verbleiben im Speicher; das Beispiel speichert die Präsentation nicht.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Diagrammlayout nach Arbeitsmappen‑Änderung validieren**

Wenn Sie eine eingebettete Arbeitsmappe durch eine modifizierte ersetzen, behält das Diagramm seine ursprünglichen Serien‑ und Kategorien‑Sammlungen. Diese Diskrepanz kann dazu führen, dass [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) mit einem „Index‑out‑of‑range“-Fehler fehlschlägt. Löschen Sie die vorhandenen Serien und Kategorien, bevor Sie die aktualisierte Arbeitsmappe zurück in das Diagramm schreiben. Dieses Beispiel verwendet ein Diagramm, das die erste Form auf der ersten Folie ist. Der Kommentar markiert die Stelle, an der die Arbeitsmappe bearbeitet werden würde; das lauffähige Beispiel schreibt die ursprüngliche Arbeitsmappe zurück und validiert das Layout im Speicher.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // Modifizieren Sie hier den Arbeitsmappen-Stream, zum Beispiel mit Aspose.Cells.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Das Leeren der Sammlungen entfernt veraltete Datenreferenzen, bevor die Arbeitsmappe zurückgeschrieben wird. Stellen Sie vor der Nutzung des Diagramms die erforderlichen Serien‑ und Kategorien‑Zuordnungen für die aktualisierte Arbeitsmappe wieder her.

## **Benutzerdefinierte Zahlenformate für Arbeitsmappenzellen festlegen**

Verwenden Sie [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/), um zu steuern, wie numerische Werte in der eingebetteten Arbeitsmappe eines Diagramms angezeigt werden. Beispielsweise muss in einem Bericht ein Umrechnungskurs als Prozentsatz mit vier Dezimalstellen und ein Koeffizient mit fünf Dezimalstellen angezeigt werden. Beide Werte bleiben numerisch, damit sie für Berechnungen und Diagramm‑Plotting verfügbar bleiben.

Ein Zahlenformat ändert die Darstellung, nicht den gespeicherten Wert. Das Format `0.0000%` zeigt `0.125` als `12.5000%` an; es ersetzt die gespeicherte Zahl nicht durch `12.5`. Ebenso zeigt `0.00000` `0.1234567` als `0.12346` an, ohne den gespeicherten Wert zu runden. Wenn das benutzerdefinierte Format ein leerer String (`""`) ist, wird stattdessen das über [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) zugewiesene Format verwendet.

Im folgenden Beispiel wird ein Säulendiagramm erstellt und über [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) auf seine Zellen zugegriffen. Auf Arbeitsblatt 0 enthält B2 den Umrechnungskurs und C2 den Koeffizienten. Beide Zellen liefern Diagrammwerte. Das Beispiel aktiviert zudem Werte‑Beschriftungen, die an die Quellformate gebunden sind.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

Arbeitsmappen‑Zellformate sind von Formaten getrennt, die direkt auf Diagramm‑Achsen oder Datenbeschriftungen gesetzt werden. In diesem Beispiel zeigt jede Beschriftung den Wert ihrer Quellzelle, weil [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) mit `true` aufgerufen wird und weil [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) ebenfalls mit `true` gesetzt ist. Nach dem Speichern und erneuten Öffnen der Präsentation zeigen die Beschriftungen `12.5000%` und `0.12346` wie unten dargestellt. Die vertikale Achse verwendet ihr eigenes Format `0.00`, das über [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) zugewiesen wurde, wobei [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) mit `false` gesetzt ist.

Um ein Datenlabel unabhängig zu formatieren, setzen Sie dessen Quell‑Link‑Flag auf `false` und weisen Sie das Format über [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) zu. Dies ändert nicht das Format der Arbeitsmappen‑Zelle. Beispielsweise zeigt ein unabhängiges Label‑Format `0.00` den ersten Wert als `0.13` an, während B2 weiterhin `12.5000%` anzeigt. Siehe [Diagrammdatennamen](/slides/de/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) für direkte Label‑Formatierung.

Das folgende Bild wurde aus der gespeicherten Präsentation nach dem erneuten Öffnen gerendert:

![Säulendiagramm mit quellenverknüpften Beschriftungen, die 12.5000% und 0.12346 zeigen, und einer unabhängig formatierten numerischen Achse.](custom-cell-formats.png)

## **Eine Arbeitsmappenzelle als Diagrammdatenbeschriftung festlegen**

Sie können Text aus Arbeitsmappenzellen als Diagrammdatenbeschriftungen verwenden.

Dieses Beispiel fügt einer bestehenden Präsentation auf der ersten Folie ein Bubble‑Diagramm mit Standarddaten hinzu. Es verwendet die Zellen A10:A12 auf Arbeitsblatt 0 für die ersten drei Beschriftungen der ersten Serie, aktiviert Beschriftungen aus Zellen und speichert die aktualisierte Präsentation.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **Arbeitsblätter verwalten**

Die Methode [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) bietet Zugriff auf die Arbeitsblätter einer Diagramm‑Arbeitsmappe. Dieses Beispiel erstellt ein Kuchendiagramm mit Standarddaten und gibt jeden Arbeitsblatt‑Namen in der Konsole aus.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **Datentyp der Datenquelle angeben**

Serien‑Punktwerte können auch direkt als numerische Literale gespeichert werden. Siehe [Set Series Values Using Numeric Literals](/slides/de/cpp/chart-series/#set-series-values-using-numeric-literals) für ein vollständiges Beispiel, das das Speichern und Lesen demonstriert. Der Quelltyp der Punktwerte ist von der internen oder externen Arbeitsmappen‑Konfiguration des Diagramms getrennt; die Verwendung numerischer Literale entfernt nicht per se die eingebettete Arbeitsmappe.

Dieses Beispiel erstellt ein 3D‑Säulendiagramm mit Standarddaten und setzt zwei Serien‑Namen mithilfe verschiedener Datenquellen. Der erste Name verwendet einen Zeichenketten‑Literal; der zweite verwendet die Zelle C1 auf Arbeitsblatt 0. Die Aufzählung [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) wählt die Quelle für jeden Namen aus. Das Beispiel speichert die Präsentation mit den aktualisierten Serien‑Namen.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **Nicht unterstützte eingebettete Arbeitsmappenformate erkennen**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb) nicht, das in einigen Diagrammen eingebettet sein kann. Sie können die Methode [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) auf [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen. Dieses Beispiel untersucht die Formen auf der ersten Folie einer bestehenden Präsentation, überspringt Nicht‑Diagramm‑Formen und gibt für jedes Diagramm mit einer eingebetteten .xlsb‑Arbeitsmappe eine Diagnosemeldung aus.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Lese oder ändere hier unterstützte Diagramm-Arbeitsmappendaten.
}
```

## **Externe Arbeitsmappe**

Aspose.Slides unterstützt die Verwendung externer Arbeitsmappen als Datenquelle für Diagramme.

### **Externe Arbeitsmappe erstellen**

Verwenden Sie [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) und [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/), um eine eingebettete Diagramm‑Arbeitsmappe in eine Datei zu exportieren und das Diagramm mit dieser externen Arbeitsmappe zu verknüpfen.

Dieses Beispiel erstellt ein Kuchendiagramm mit Standarddaten und exportiert dessen Arbeitsmappe. Es schließt den Ausgabestream, bevor es die externe Arbeitsmappe als Datenquelle zuweist, und speichert anschließend die verknüpfte Präsentation.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);

presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **Externe Arbeitsmappe festlegen**

Mit der Methode [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) können Sie einem Diagramm eine externe Arbeitsmappe als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um einen Pfad zu einer externen Arbeitsmappe zu aktualisieren (wenn diese verschoben wurde).

Während Sie die Daten in Arbeitsmappen, die an entfernten Speicherorten oder Ressourcen liegen, nicht bearbeiten können, können Sie solche Arbeitsmappen weiterhin als externe Datenquelle nutzen. Wird ein relativer Pfad zu einer externen Arbeitsmappe angegeben, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieses Beispiel verwendet eine externe Arbeitsmappe, deren Arbeitsblatt `Sheet1` einen Serien‑Namen in B1, Kategorienamen in A2:A4 und numerische Werte in B2:B4 enthält. Das Beispiel erstellt ein Kuchendiagramm, verknüpft die Arbeitsmappe und verwendet [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/), um A1:B4 einer Serie und drei Kategorien zuzuordnen. Es speichert die Präsentation mit dem verknüpften Diagramm.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

Der Parameter `updateChartData` von [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) steuert, ob die Arbeitsmappe geladen wird.

* Wenn `updateChartData` **false** ist, wird nur der Pfad zur Arbeitsmappe aktualisiert. Die Diagrammdaten werden nicht aus der Ziel‑Arbeitsmappe geladen oder aktualisiert, sodass die Arbeitsmappe nicht vorhanden sein kann.
* Wenn `updateChartData` **true** ist, werden die Diagrammdaten aus der Ziel‑Arbeitsmappe aktualisiert.

Das folgende Beispiel setzt eine Platzhalter‑URL mit `updateChartData` = `false`. Es behält die Standarddaten des Kuchendiagramms bei und speichert die Präsentation, ohne die nicht verfügbare Arbeitsmappe zu laden.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **Pfad der externen Datenquellenarbeitsmappe eines Diagramms abrufen**

Um die mit einem Diagramm verknüpfte Arbeitsmappe zu ermitteln, prüfen Sie, ob das Diagramm eine externe Datenquelle verwendet, und rufen Sie dessen Arbeitsmappen‑Pfad ab.

Dieses Beispiel untersucht die erste Form auf der ersten Folie einer Präsentation mit einer verknüpften externen Arbeitsmappe. Handelt es sich um ein Diagramm, das mit einer externen Arbeitsmappe verknüpft ist, gibt das Beispiel [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) in der Konsole aus. Anschließend wird eine Kopie der Präsentation gespeichert.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen genauso bearbeiten wie die Inhalte interner Arbeitsmappen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieses Beispiel verwendet ein Diagramm, das die erste Form auf der ersten Folie ist und mit einer zugänglichen externen Arbeitsmappe verknüpft ist. Es setzt den zellgestützten Wert des ersten Datenpunkts der ersten Serie auf 100 und speichert die aktualisierte Präsentation. Das Bearbeiten von Zellwerten kann die verknüpfte externe XLSX‑Datei aktualisieren; verwenden Sie daher eine Kopie, wenn das Original‑Arbeitsmappen erhalten bleiben soll.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Arbeitsmappe aus dem Diagramm‑Cache wiederherstellen**

Wenn ein Diagramm eine externe Arbeitsmappe verwendet, die fehlt oder nicht verfügbar ist, kann Aspose.Slides das Diagramm‑Arbeitsmappe aus den im Dokument zwischengespeicherten Daten rekonstruiert. Erzeugen Sie ein [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), konfigurieren Sie es mit [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), und rufen Sie vor dem Öffnen der Präsentation [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) mit **true** auf.

Das folgende C++‑Beispiel stellt Arbeitsmappendaten für ein Diagramm wieder her, das die erste Form auf der ersten Folie ist und auf eine nicht verfügbare externe Arbeitsmappe verweist. Es greift über [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) und [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) auf die wiederhergestellten Daten zu:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Lesen oder ändern Sie hier die wiederhergestellten Arbeitsmappendaten.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Wenn die externe Arbeitsmappe nicht verfügbar ist und die Wiederherstellung deaktiviert ist, wirft Aspose.Slides eine [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Aktivieren Sie die Wiederherstellung nur, wenn die Nutzung zwischengespeicherter Diagrammdaten ein akzeptablerFallback ist, da der Cache möglicherweise Änderungen, die nach dem letzten Aktualisieren der Präsentation an der externen Arbeitsmappe vorgenommen wurden, nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [Datentyp der Datenquelle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) und einen [Pfad zu einer externen Arbeitsmappe](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); wenn die Quelle eine externe Arbeitsmappe ist, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wird ein relativer Pfad angegeben, wird er automatisch in einen absoluten Pfad umgewandelt. Die Präsentation speichert den absoluten Pfad in der PPTX‑Datei, sodass ein Verschieben der Arbeitsmappe ein Aktualisieren des Links erforderlich machen kann.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerk‑Ressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle genutzt werden. Das direkte Bearbeiten entfernter Arbeitsmappen aus Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle verwendet werden.

**Überschreibt Aspose.Slides die externe XLSX‑Datei beim Speichern der Präsentation?**

Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Das Bearbeiten von zellgestützten Diagrammdaten kann außerdem die verknüpfte lokale XLSX‑Datei aktualisieren. Verwenden Sie eine Kopie der Arbeitsmappe, wenn das Original unverändert bleiben muss.

**Was soll ich tun, wenn die externe Datei passwortgeschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz besteht darin, den Schutz im Voraus zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) vorzubereiten und auf diese Kopie zu verweisen.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, werden Aktualisierungen dieser Datei in jedem Diagramm beim nächsten Laden der Daten reflektiert.