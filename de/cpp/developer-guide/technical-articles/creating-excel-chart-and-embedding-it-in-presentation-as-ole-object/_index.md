---
title: Excel-Diagramme erstellen und in Präsentationen als OLE-Objekte einbetten
type: docs
weight: 40
url: /de/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel-Diagramm
- Diagramm einbetten
- OLE-Objekt
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für C++ und betten Sie die Arbeitsmappe in eine PowerPoint-Präsentation mit Aspose.Slides ein, einschließlich einer Diagrammvorschau."
---
## **Übersicht**

Dieser Artikel zeigt, wie man ein Excel‑Säulendiagramm mit Aspose.Cells für C++ erstellt und seine Arbeitsmappe in einer PowerPoint‑Präsentation mit Aspose.Slides für C++ einbettet. Die eingebettete Arbeitsmappe enthält sowohl die Quelldaten als auch das Diagramm. Eine separate PNG‑Vorschau zeigt das Diagramm auf der Folie, bevor das OLE‑Objekt aktiviert wird.

Das Ergebnis ist ein eingebettetes Excel‑Objekt, kein natives PowerPoint‑Diagramm. Das Bearbeiten der Arbeitsmappe über OLE erfordert eine Desktop‑Anwendung, die OLE‑Aktivierung unterstützt, sowie eine kompatible Excel‑Installation.

## **Voraussetzungen**

Konfigurieren Sie Ihr C++‑Projekt mit den Headern und Bibliotheken für Aspose.Cells für C++ und Aspose.Slides für C++. Platzieren Sie den Beispielcode im Einstiegspunkt Ihrer Anwendung, wobei die Include‑Deklarationen im Datei‑Scope stehen. Microsoft Office ist nicht erforderlich, um die Präsentation mit diesen Bibliotheken zu erzeugen.

Es werden keine Eingabedateien benötigt: Das Beispiel erzeugt die Daten und das Diagramm im Speicher und schreibt anschließend `OutputChart.pptx` in das aktuelle Arbeitsverzeichnis. Wenden Sie Lizenzen für beide Produkte an, wenn Sie außerhalb des Evaluationsmodus arbeiten.

## **Wie das Einbetten funktioniert**

1. Erstellen Sie eine Arbeitsmappe mit einem Daten‑Arbeitsblatt und einem Diagrammblatt.  
2. Machen Sie das Diagrammblatt aktiv, damit die Arbeitsmappe mit dem Diagramm geöffnet wird.  
3. Setzen Sie den OLE‑Anzeigebereich der Arbeitsmappe und rendern Sie das Diagramm zu PNG.  
4. Speichern Sie die Arbeitsmappe im Speicher als XLSX und betten Sie diese Bytes in eine Folie ein.  
5. Weisen Sie das PNG als Vorschau des OLE‑Objekts zu und speichern Sie die Präsentation als PPTX.

Der Anzeigebereich der Arbeitsmappe und der Rahmen auf der Folie haben unterschiedliche Rollen. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) nimmt nullbasierte Start‑/End‑Zeilen- und Spaltenindizes entgegen. [ChartCollection::Add](https://reference.aspose.com/cells/cpp/aspose.cells.charts/chartcollection/add/) verwendet stattdessen die obere Zeile, die linke Spalte, die untere Zeile und die rechte Spalte. Das Beispiel verwendet den Zeilenindex 55 und den Spaltenindex 25 als rechte untere Grenzen; diese Werte sind Layout‑Entscheidungen, nicht die Anzahl der Datenzeilen oder -spalten.

Der Folienrahmen verwendet Punkte. Das Beispiel passt ihn innerhalb der Folie an und zentriert ihn, wobei das Seitenverhältnis des PNG beibehalten wird, anstatt die Vorschau zu strecken, um die Folie auszufüllen.

## **Diagramm erstellen und einbetten**

Das folgende vollständige Beispiel füllt `DataSheet` mit vier Zeilen und fünf Spalten von Werten. Jede Zeile wird zu einer Diagrammreihe. `ChartSheet` wird vor dem Speichern der Arbeitsmappe als aktives Blatt ausgewählt.

Die Arbeitsmappe wird explizit als XLSX gespeichert, passend zur `xlsx`‑Erweiterung, die an [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) übergeben wird. Das PNG wird aus einem In‑Memory‑Stream geladen, ohne eine Zwischentextur‑Umwandlung. Aspose.Cells liefert Byte‑Vektoren, die das Beispiel in den von Aspose.Slides akzeptierten Array‑Typ kopiert. Initialisieren Sie Aspose.Cells, bevor Sie seine Objekte verwenden, und geben Sie seine Ressourcen frei, nachdem diese Objekte zerstört wurden. Das Zuweisen über [IOleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/get_substitutepictureformat/) ersetzt den Standard‑OLE‑Platzhalter.

```cpp
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Chart.h"
#include "Aspose.Cells/ChartCollection.h"
#include "Aspose.Cells/ChartType.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/SeriesCollection.h"
#include "Aspose.Cells/SheetType.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <Util/Images.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <algorithm>
#include <IImage.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;

// Initialize Cells before creating any of its objects.
Aspose::Cells::Startup();
{
    Aspose::Cells::Workbook workbook;
    auto dataSheet = workbook.GetWorksheets().Get(0);
    dataSheet.SetName(u"DataSheet");

    int32_t values[4][5] =
    {
        { 67, 44, 46, 43, 24 },
        { 86, 64, 97, 29, 40 },
        { 68, 89, 78, 69, 38 },
        { 91, 48, 60, 26, 25 }
    };

    for (auto row = 0; row < 4; row++)
    {
        for (auto column = 0; column < 5; column++)
        {
            dataSheet.GetCells().Get(row, column).PutValue(values[row][column]);
        }
    }

    auto chartSheetIndex = workbook.GetWorksheets().Add(Aspose::Cells::SheetType::Chart);
    auto chartSheet = workbook.GetWorksheets().Get(chartSheetIndex);
    chartSheet.SetName(u"ChartSheet");

    auto lastChartRow = 55;
    auto lastChartColumn = 25;
    auto chartIndex = chartSheet.GetCharts().Add(Aspose::Cells::Charts::ChartType::Column, 0, 0, lastChartRow, lastChartColumn);
    auto chart = chartSheet.GetCharts().Get(chartIndex);
    const char16_t* seriesRanges[] = { u"DataSheet!A1:E1", u"DataSheet!A2:E2", u"DataSheet!A3:E3", u"DataSheet!A4:E4" };
    for (auto range : seriesRanges)
    {
        chart.GetNSeries().Add(range, false);
    }

    workbook.GetWorksheets().SetActiveSheetIndex(chartSheetIndex);
    workbook.GetWorksheets().SetOleSize(0, lastChartRow, 0, lastChartColumn);

    // Die Diagrammvorschau rendern und die bearbeitbare Arbeitsmappe separat serialisieren.
    auto chartImageData = chart.ToImage(Aspose::Cells::Drawing::ImageType::Png);
    auto workbookData = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);

    // Kopiere Cells-Puffer in den von Slides verwendeten Array-Typ.
    auto toSlidesArray = [](const Aspose::Cells::Vector<uint8_t>& buffer)
    {
        auto result = System::MakeArray<uint8_t>(buffer.GetLength(), 0);
        std::copy(buffer.GetData(), buffer.GetData() + buffer.GetLength(), result->data_ptr());
        return result;
    };
    auto chartImageBytes = toSlidesArray(chartImageData);
    auto workbookBytes = toSlidesArray(workbookData);
    auto chartImageStream = System::MakeObject<System::IO::MemoryStream>(chartImageBytes);
    auto chartImage = Images::FromStream(chartImageStream);

    auto presentation = System::MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto slideSize = presentation->get_SlideSize()->get_Size();

    // Passe die Vorschau an die Folie an, ohne das Seitenverhältnis zu ändern.
    auto scale = (std::min)(slideSize.get_Width() / chartImage->get_Width(), slideSize.get_Height() / chartImage->get_Height());
    auto frameWidth = chartImage->get_Width() * scale;
    auto frameHeight = chartImage->get_Height() * scale;
    auto frameX = (slideSize.get_Width() - frameWidth) / 2;
    auto frameY = (slideSize.get_Height() - frameHeight) / 2;

    auto embeddedData = System::MakeObject<OleEmbeddedDataInfo>(workbookBytes, u"xlsx");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
    auto previewImage = presentation->get_Images()->AddImage(chartImage);
    oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(previewImage);

    presentation->Save(u"OutputChart.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
    presentation->Dispose();
    chartImage->Dispose();
    chartImageStream->Dispose();
}
// Gib die Cells-Ressourcen frei, nachdem alle Cells-Objekte zerstört wurden.
Aspose::Cells::Cleanup();
```

## **Erwartetes Ergebnis**

`OutputChart.pptx` enthält eine Folie mit einer eingebetteten Excel‑Arbeitsmappe und einer Diagrammvorschau. Die Arbeitsmappe enthält die ursprünglichen Daten und ein Säulendiagramm mit vier Reihen. Die Vorschau ist auf der Folie zentriert und behält ihre Proportionen bei.

![Excel‑Säulendiagramm angezeigt als Vorschau einer eingebetteten Arbeitsmappe](excel-chart-ole-preview.png)

In einer kompatiblen Desktop‑PowerPoint‑Umgebung mit verfügbarem Excel können Sie das Objekt doppelklicken, um das eingebettete Arbeitsblatt zu aktivieren und zu bearbeiten. Aktivierung und Bearbeitung hängen von der OLE‑Unterstützung und den Sicherheitseinstellungen der Host‑Anwendung ab.

## **FAQ**

**Warum wird ein Vorschaubild benötigt?**

Die eingebettete Arbeitsmappe und ihre Folienvorschau sind getrennte Inhalte. Stellen Sie ein Diagrammbild bereit, damit die Folie das Diagramm anstelle des Standard‑„EMBEDDED OLE OBJECT“-Platzhalters anzeigt. Siehe [Objekt‑Vorschau‑Problem beim Hinzufügen von OleObjectFrame](/slides/de/cpp/object-preview-issue-when-adding-oleobjectframe/).

**Wird die Vorschau automatisch aktualisiert, wenn ich die Arbeitsmappe im Code ändere?**

Betrachten Sie die Vorschau als Momentaufnahme. Wenn Sie Daten der Arbeitsmappe programmgesteuert aktualisieren, erstellen Sie das Diagrammbild neu und ersetzen sowohl die Vorschau als auch die eingebetteten Arbeitsmappendaten.

**Kann ich XLS anstelle von XLSX verwenden?**

Ja. Speichern Sie die Arbeitsmappe im XLS‑Format und verwenden Sie `xls` als Erweiterung für die eingebetteten Daten. Die Erweiterung muss dem tatsächlichen Arbeitsmappformat entsprechen; das alleinige Ändern der Erweiterung konvertiert die Daten nicht.

**Warum könnte das Objekt nach der Aktivierung die Größe ändern?**

Die Host‑Anwendung kann die Darstellung des OLE‑Objekts aktualisieren, wenn sie die Arbeitsmappe aktiviert. Sowohl der OLE‑Anzeigebereich der Arbeitsmappe als auch die Abmessungen des Folienrahmens sind dabei relevant. Siehe [Arbeitslösung für Diagramm‑Größenänderung in PPTX](/slides/de/cpp/working-solution-for-chart-resizing-in-pptx/).

## **Verwandte Abschnitte**

- [Arbeitslösung für Diagramm‑Größenänderung in PPTX](/slides/de/cpp/working-solution-for-chart-resizing-in-pptx/)
- [Objekt‑Vorschau‑Problem beim Hinzufügen von OleObjectFrame](/slides/de/cpp/object-preview-issue-when-adding-oleobjectframe/)