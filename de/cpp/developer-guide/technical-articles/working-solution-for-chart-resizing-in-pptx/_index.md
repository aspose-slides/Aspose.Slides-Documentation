---
title: Arbeitslösung für Diagrammgrößenänderung in PPTX
type: docs
weight: 60
url: /de/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- Diagrammgrößenänderung
- Excel-Diagramm
- OLE-Objekt
- Diagramm einbetten
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Behebt unerwartete Diagrammgrößenänderungen in PPTX bei Verwendung eingebetteter Excel-OLE-Objekte mit Aspose.Slides für C++. Legen Sie feste Diagrammabmessungen fest, um die Größe von Diagramm und OLE-Rahmen konsistent zu halten."
---
## **Hintergrund**

Excel‑Diagramme, die als OLE‑Objekte in PowerPoint‑Präsentationen mit Aspose‑Komponenten eingebettet sind, können ihre Größe nach der ersten Aktivierung ändern. Dies kann zu einem deutlichen Unterschied im Aussehen des Diagramms vor und nach der Aktivierung führen. Dieser Artikel erklärt, warum die Größenänderung auftritt, und zeigt, wie man sie verhindert, indem man feste Diagrammgrößen an den OLE‑Rahmen anpasst.

In [Excel-Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man mit Aspose.Cells für C++ ein Excel‑Diagramm erstellt und es mit Aspose.Slides für C++ in eine PowerPoint‑Präsentation einbettet. Um das [Objekt‑Vorschauproblem](/slides/de/cpp/object-preview-issue-when-adding-oleobjectframe/) zu lösen, haben wir das Diagrammbild dem OLE‑Objekt‑Rahmen des Diagramms zugewiesen. In der erzeugten Präsentation wird das OLE‑Objekt‑Rahmen, das das Diagrammbild anzeigt, bei einem Doppelklick aktiviert, wodurch das Excel‑Diagramm geöffnet wird. Benutzer können die eingebettete Excel‑Arbeitsmappe bearbeiten und anschließend zur Folie zurückkehren, indem sie außerhalb der aktivierten Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt, und der Skalierungsfaktor variiert je nach den ursprünglichen Größen sowohl des OLE‑Objekt‑Rahmens als auch der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Die eingebettete Excel‑Arbeitsmappe hat eigene Fensterabmessungen, die Excel beim ersten Aktivieren des Objekts beizubehalten versucht. Der OLE‑Rahmen auf der Folie hat unabhängig definierte Abmessungen. Wenn die Excel‑Arbeitsmappe aktiviert wird, verhandeln Excel und PowerPoint die Größe des Objekts, um dessen Proportionen im Rahmen des Einbettungsprozesses beizubehalten. Unterschiede zwischen dem Arbeitsmappen‑Fenster und dem OLE‑Rahmen können daher zu einer Größenänderung des Objekts führen.

## **Lösungsansatz**

Stellen Sie die Diagrammgröße dem OLE‑Rahmen auf der Folie an und halten Sie die Diagrammabmessungen unabhängig vom Arbeitsmappen‑Fenster. Diese Lösung funktioniert sowohl bei einer neuen Präsentation als auch bei einer vorhandenen Vorlage.

Das Beispiel erfordert Aspose.Cells für C++ und Aspose.Slides für C++. Es erzeugt ein einfaches Säulendiagramm auf einem aktiven Diagrammblatt und bettet die Arbeitsmappe im XLS‑Format ein. Es wird kein Diagramm‑Vorschau‑Bild zugewiesen; das Diagramm wird sichtbar, wenn das OLE‑Objekt in PowerPoint aktiviert wird.

Platzieren Sie den Beispielcode im Einstiegspunkt Ihrer Anwendung, wobei die Include‑Deklarationen im Dateibereich stehen. Initialisieren Sie Aspose.Cells, bevor Sie dessen Objekte erzeugen, und geben Sie dessen Ressourcen nach der Zerstörung dieser Objekte frei. Das Beispiel kopiert den von Aspose.Cells zurückgegebenen Byte‑Vektor der Arbeitsmappe in den von Aspose.Slides akzeptierten Array‑Typ.

Das Beispiel erstellt eine neue Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen, der 0,5 Zoll vom linken Rand und 1 Zoll vom oberen Rand positioniert ist. Folienkoordinaten und -abmessungen werden in Punkten (72 Punkte pro Zoll) angegeben. Für eine bestehende Präsentation siehe [Vorlage verwenden](#use-a-template).

## **Feste Diagrammgröße festlegen**

Setzen Sie [Chart::SetSizeWithWindow](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setsizewithwindow/) auf false, damit die Diagrammabmessungen unabhängig vom Arbeitsmappen‑Fenster sind. Setzen Sie die Abmessungen von [Chart::GetChartObject](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/getchartobject/) über [Shape::SetWidth](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setwidth/) und [Shape::SetHeight](https://reference.aspose.com/cells/cpp/aspose.cells.drawing/shape/setheight/), indem Sie Punkte mit 96 Pixel pro Zoll in Pixel umrechnen: Ein Rahmen von 684 × 288 Punkten entspricht einem Diagramm von 912 × 384 Pixel. Setzen Sie [Chart::SetPrintSize](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chart/setprintsize/) auf den benutzerdefinierten Wert von [PrintSizeType](https://reference.aspose.com/cells/cpp/aspose.cells/printsizetype/). Das Beispiel bettet die Arbeitsmappe mit [IShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addoleobjectframe/) ein und speichert eine Präsentation mit einem 9,5 × 4‑Zoll‑OLE‑Rahmen.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartShape.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/PrintSizeType.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <algorithm>
#include <cstdint>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"Data");
    dataSheet.GetCells().Get(u"A1").PutValue(10);
    dataSheet.GetCells().Get(u"A2").PutValue(20);

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, 20, 10);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    chart.GetNSeries().Add(u"Data!A1:A2", true);
    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Folienkoordinaten und -abmessungen sind in Punkten (72 Punkte pro Zoll).
    auto width = 684.f; // 9,5 Zoll.
    auto height = 288.f; // 4 Zoll.

    chart.SetSizeWithWindow(false);
    // Punkte mit 96 Pixel pro Zoll in Diagrammpixel umrechnen.
    chart.GetChartObject().SetWidth(static_cast<int32_t>(width / 72.f * 96.f));
    chart.GetChartObject().SetHeight(static_cast<int32_t>(height / 72.f * 96.f));
    chart.SetPrintSize(Aspose::Cells::PrintSizeType::Custom);

    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Excel97To2003);
    // Kopiere den Bytes-Vektor von Cells in den von Slides akzeptierten Array-Typ.
    auto workbookBytes = System::MakeArray<uint8_t>(workbookData.GetLength(), 0);
    std::copy(workbookData.GetData(), workbookData.GetData() + workbookData.GetLength(), workbookBytes->data_ptr());
    auto dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xls");
    slide->get_Shapes()->AddOleObjectFrame(36, 72, width, height, dataInfo);

    presentation->Save(u"chart-fixed-size.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
}
Aspose::Cells::Cleanup();
```
## **Vorlage verwenden**

Die Größenlogik ist für eine vorhandene Präsentation identisch. Um das Beispiel anzupassen:

1. Laden Sie die Vorlagen‑Präsentation anstelle einer leeren Präsentation.
1. Überprüfen Sie, dass die erste Folie mindestens drei Formen enthält, und verwenden Sie dann die Form mit Index 2 als Platzhalter.
1. Verwenden Sie die Rahmenbreite und -höhe dieser Form anstelle der festen Werte 684 und 288. Lassen Sie die Berechnungen unverändert.
1. Fügen Sie den OLE‑Rahmen an der Position des Platzhalters ein statt an den festen Koordinaten 36 und 72.
1. Entfernen Sie den Platzhalter, bevor Sie die Präsentation speichern.

## **FAQ**

**Warum ändert mein eingebettetes Excel‑Diagramm nach der Aktivierung in PowerPoint die Größe?**

Dies geschieht, weil Excel beim ersten Aktivieren versucht, die ursprüngliche Fenstergröße wiederherzustellen, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was die Größenänderung verursachen kann.

**Wie kann ich die Größen von Diagramm und OLE‑Rahmen konsistent halten?**

Setzen Sie feste Diagrammabmessungen, die dem OLE‑Rahmen entsprechen, und verwenden Sie vor dem Einbetten der Arbeitsmappe eine benutzerdefinierte Diagrammdruckgröße. Das obige Beispiel zeigt die erforderlichen Einstellungen und Einheitumrechnungen.

**Reicht es aus, die Größe des Arbeitsmappen‑Fensters anzupassen?**

Allein das Anpassen der Arbeitsmappen‑Fenstergröße verhindert nicht zuverlässig, dass der OLE‑Rahmen nach der Aktivierung seine Größe ändert. Verwenden Sie feste Diagrammabmessungen wie im Beispiel gezeigt.

**Funktioniert diese Lösung sowohl für vorlagenbasierte als auch für neue Präsentationen?**

Ja. Für eine Vorlage verwenden Sie die Abmessungen und die Position des Platzhalters. Für eine neue Präsentation geben Sie die Rahmenabmessungen und Position direkt an.

**Kann ich dieses Beispiel mit Diagrammen aus anderen Tabellenkalkulationsprogrammen verwenden?**

Das Beispiel verwendet eine mit Aspose.Cells erstellte Excel‑Arbeitsmappe. Es demonstriert das Aktivierungsverhalten für andere Tabellenkalkulationsprogramme nicht.

## **Verwandte Abschnitte**

- [Excel-Diagramme erstellen und als OLE‑Objekte in Präsentationen einbetten](/slides/de/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)