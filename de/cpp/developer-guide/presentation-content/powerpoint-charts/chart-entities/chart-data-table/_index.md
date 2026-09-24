---
title: Diagrammdatentabellen in Präsentationen mit C++ anpassen
linktitle: Datentabelle
type: docs
url: /de/cpp/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Passen Sie Schriftarten, Rahmen und Legenden‑Schlüssel der Diagrammdatentabelle in PowerPoint‑Präsentationen mit Aspose.Slides für C++ an."
---
## **Übersicht**

Aspose.Slides for C++ ermöglicht das Anzeigen einer Datentabelle eines Diagramms und das Anpassen der Textformatierung, Rahmen und Legenden‑Schlüssel. Dieser Artikel erklärt, wie die Tabelle aktiviert, der Text formatiert, jeder Randtyp gesteuert und Legenden‑Schlüssel ein‑ oder ausgeblendet werden. Die Beispiele speichern die konfigurierten Diagramme in PPTX‑Dateien.

## **Schriftart-Eigenschaften festlegen**

Um die Datentabelle eines Diagramms anzuzeigen, übergeben Sie `true` an [IChart::set_HasDataTable](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Verwenden Sie [IChart::get_ChartDataTable](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/get_chartdatatable/), um auf die Tabelle zuzugreifen und deren Textformatierung zu konfigurieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Fügen Sie ein gruppiertes Säulendiagramm zur ersten Folie hinzu.
1. Aktivieren Sie die Datentabelle des Diagramms.
1. Aktivieren Sie fetten Text mit [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_fontbold/) und übergeben Sie `20` an [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/de/cpp/aspose.slides/ibaseportionformat/set_fontheight/) für Text mit 20 Punkt.
1. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erfordert `test.pptx` im Arbeitsverzeichnis mit mindestens einer Folie. Es fügt ein Diagramm mit Standarddaten an der Position (50, 50) ein, mit einer Breite von 600 Punkten und einer Höhe von 400 Punkten. Die gespeicherte `output.pptx` enthält das Diagramm mit aktivierter Datentabelle und den angewendeten Schriftart‑Einstellungen.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Ränder der Datentabelle anpassen**

Aktivieren Sie die Tabelle mit [IChart::set_HasDataTable](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/set_hasdatatable/) und greifen Sie über [IChart::get_ChartDataTable](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/get_chartdatatable/) darauf zu. Sie können drei Arten von Rändern unabhängig steuern:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) steuert die horizontalen Zellenränder.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) steuert die vertikalen Zellenränder.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) steuert den äußeren Rand der Tabelle.

Übergeben Sie `true` an jeden Setter, um die jeweiligen Ränder anzuzeigen, oder `false`, um sie auszublenden. Das folgende Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten, zeigt horizontale Ränder und den äußeren Rand an und blendet die vertikalen Ränder aus. Es benötigt keine Eingabedatei. Position und Größe des Diagramms werden in Punkten angegeben.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

Der Vergleich unten verwendet in allen vier Fällen dieselben Diagrammdaten und dieselbe Legenden‑Schlüssel‑Einstellung. Beginnend mit allen aktivierten Rändern deaktiviert jede verbleibende Variante genau eine Rand‑Einstellung. Die links‑untere Variante entspricht den Rand‑Einstellungen im Beispiel.

![Diagrammdatentabellen mit allen aktivierten Rändern, ohne horizontale Ränder, ohne vertikale Ränder und ohne äußeren Rand](data-table-borders.png)

## **Legenden‑Schlüssel ein- oder ausblenden**

Legenden‑Schlüssel sind kleine farbige Markierungen neben den Seriennamen in der Datentabelle. Sie helfen dem Leser, jede Tabellenzeile einer Diagrammserie zuzuordnen. Übergeben Sie `true` an [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/idatatable/set_showlegendkey/), um diese Markierungen anzuzeigen, oder `false`, um sie auszublenden.

Die separate Legende des Diagramms wird über [IChart::set_HasLegend](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/set_haslegend/) gesteuert. Diese Einstellungen sind unabhängig: Das Ausblenden der separaten Legende blendet die Schlüssel in der Datentabelle nicht aus, und das Ausblenden der Tabellenschlüssel blendet die separate Legende nicht aus.

Das folgende Beispiel erstellt ein Diagramm mit Standarddaten, aktiviert seine Datentabelle und zeigt Legenden‑Schlüssel darin an, während die separate Legende ausgeblendet wird. Alle Tabellennränder sind explizit aktiviert. Es ist keine Eingabepräsentation erforderlich. Um nur die Tabellenschlüssel auszublenden, übergeben Sie `false` an [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

Der Vergleich unten zeigt dieselbe Tabelle mit aktivierten und deaktivierten Legenden‑Schlüsseln. Alle Ränder bleiben aktiviert, und die separate Diagrammlegende ist in beiden Fällen ausgeblendet.

![Diagrammdatentabellen mit links angezeigten Legenden‑Schlüsseln und rechts ausgeblendeten](data-table-legend-keys.png)

## **FAQ**

**Kann ich Legenden‑Schlüssel in der Datentabelle eines Diagramms anzeigen?**

Ja. Übergeben Sie `true` an [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/idatatable/set_showlegendkey/), um Legenden‑Schlüssel anzuzeigen, oder `false`, um sie auszublenden.

**Wird die Datentabelle beim Export der Präsentation nach PDF, HTML oder Bildern erhalten bleiben?**

Ja. Aspose.Slides rendert das Diagramm und seine angezeigte Datentabelle als Teil der Folie, wenn in [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/de/cpp/convert-powerpoint-to-html/) oder [images](/slides/de/cpp/convert-powerpoint-to-png/) exportiert wird.

**Kann ich mit Datentabellen in Diagrammen arbeiten, die aus einer Vorlage geladen wurden?**

Ja. Für ein Diagramm, das aus einer vorhandenen Präsentation oder Vorlage geladen wurde, verwenden Sie [IChart::get_HasDataTable](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/get_hasdatatable/), um zu prüfen, ob seine Datentabelle angezeigt wird, und [IChart::set_HasDataTable](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/set_hasdatatable/), um die Sichtbarkeit zu ändern.

**Wie kann ich Diagramme finden, bei denen die Datentabelle aktiviert ist?**

Iterieren Sie über die Formen auf jeder Folie, identifizieren Sie die Diagramme und prüfen Sie deren Ergebnis von [IChart::get_HasDataTable](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Ein Wert von `true` zeigt an, dass die Datentabelle aktiviert ist.