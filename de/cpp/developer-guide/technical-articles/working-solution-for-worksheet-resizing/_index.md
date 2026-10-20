---
title: Lösungsansatz für die Größenänderung von Arbeitsblättern
type: docs
weight: 130
url: /de/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- Vorschaubild
- Bildskalierung
- Excel
- Arbeitsblatt
- PowerPoint
- Präsentation
- C++
- Aspose.Slides for C++
description: "Lösungsansatz für die Größenänderung von Arbeitsblättern in PowerPoint-Präsentationen mit C++"
---
{{% alert color="info" title="Note" %}}
Excel-Tabellen, die als OLE-Objekte in einer PowerPoint‑Präsentation mithilfe von Aspose‑Komponenten eingebettet sind, können sich nach ihrer ersten Aktivierung unerwartet in der Größe ändern. Dieses Verhalten erzeugt einen deutlichen visuellen Unterschied zwischen dem OLE‑Objekt vor und nach der Aktivierung. Dieser Artikel erklärt das Problem und beschreibt zwei Möglichkeiten, es zu beheben.
{{% /alert %}}

## **Hintergrund**

Im Artikel [OLE verwalten](/slides/de/cpp/manage-ole/) haben wir erklärt, wie man mithilfe von Aspose.Slides für C++ einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [Problem mit Objektvorschau](/slides/de/cpp/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objektrahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der erzeugten Präsentation wird beim Doppelklick auf den OLE‑Objektrahmen, der das Arbeitsblatt‑Bild anzeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können gewünschte Änderungen an der eigentlichen Excel‑Arbeitsmappe vornehmen und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objektrahmens und der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe bei der ersten Aktivierung beizubehalten. Der OLE‑Objektrahmen hingegen hat seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei Aktivierung der Arbeitsmappe die Größe, um sicherzustellen, dass das korrekte Seitenverhältnis im Einbettungsprozess erhalten bleibt. Die Größenänderung entsteht aufgrund der Unterschiede zwischen der Fenstergröße von Excel und der Größe und Position des OLE‑Objektrahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie den OLE‑Rahmen in der PowerPoint‑Präsentation, sodass er der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten entspricht.
- Halten Sie die Größe des OLE‑Rahmens konstant und skalieren Sie die ausgewählten Zeilen und Spalten, damit sie hineinpassen.

### **Größe des OLE‑Rahmens skalieren**

Dieser Ansatz setzt die Größe des OLE‑Rahmens so, dass sie der Gesamthöhe und -breite der ausgewählten Zeilen und Spalten im eingebetteten Excel‑Arbeitsblatt entspricht.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts mithilfe nullbasierter Indizes aus. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) definiert den angezeigten Bereich. Die Vorschau wird mit 96 DPI gerendert und ihre Pixelabmessungen werden mit 72 Punkten pro Zoll in Punkte umgerechnet. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) bettet die modifizierte Arbeitsmappe in einen Rahmen mit diesen Abmessungen ein. Die Vorschau wird über [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) zugewiesen, um den Platzhalter „EMBEDDED OLE OBJECT“ in der gespeicherten Präsentation zu ersetzen.
```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/image.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Set the displayed size when the workbook file is used as an OLE object in PowerPoint.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Get the width and height of the OLE image in points.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// We need to use the modified workbook.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Add the OLE image to the presentation resources.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```
Der Vorschau‑Helper verwendet [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/), um den Bereich auszuwählen und entfernt Ränder, Kopf‑ und Fußzeilen. Mit aktivierter [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) rendert [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) den Bereich als PNG‑Bild. Der Helper kopiert die gerenderten Bilddaten in einen neuen Memory‑Stream, der an dessen Anfang positioniert ist, zur Verwendung in der Präsentation.
```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

### **Größe des Zellbereichs skalieren**

Dieser Ansatz skaliert die Höhen der ausgewählten Zeilen und die Breiten der ausgewählten Spalten, um einer benutzerdefinierten OLE‑Rahmengröße zu entsprechen.

Das Beispiel lädt eine vorhandene Excel‑Arbeitsmappe und wählt die ersten 10 Zeilen und 13 Spalten des ersten Arbeitsblatts mithilfe nullbasierter Indizes aus. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) definiert den angezeigten Bereich, und der untenstehende Helper skaliert diesen Bereich, sodass er in einen Rahmen von 400 Punkten Breite und 100 Punkten Höhe passt. Nach dem Speichern der modifizierten Arbeitsmappe in ein Byte‑Array bettet [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) sie mit der angegebenen Größe ein. Eine mit 96 DPI gerenderte Vorschau wird über [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) zugewiesen, sodass die gespeicherte Präsentation die ausgewählten Zellen anstelle des Standard‑Platzhalters anzeigt.
```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Legt die angezeigte Größe fest, wenn die Arbeitsmappendatei als OLE‑Objekt in PowerPoint verwendet wird.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skaliert den Zellbereich, sodass er in die Rahmen­größe passt.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen die modifizierte Arbeitsmappe verwenden.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Fügt das OLE‑Bild zu den Präsentations‑Ressourcen hinzu.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Erstellt den OLE‑Objektrahmen.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```
Der Skalierungs‑Helper berechnet separate Breiten‑ und Höhenverhältnisse für den ausgewählten Bereich und bewahrt dabei die relativen Spaltenbreiten und Zeilenhöhen. Er wandelt die berechneten Abmessungen von Punkten in Zoll um, bevor er sie mit [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) bzw. [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/) anwendet. Der ausgewählte Bereich muss eine von Null unterschiedliche Breite und Höhe besitzen.
```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">Die erwartete Breite des Zellbereichs in Punkten.</param>
/// <param name="height">Die erwartete Höhe des Zellbereichs in Punkten.</param>
void ScaleCellRange(Aspose::Cells::Range cellRange, float width, float height)
{
    auto rangeWidth = cellRange.GetWidth();
    auto rangeHeight = cellRange.GetHeight();

    for (int i = 0; i < cellRange.GetColumnCount(); i++)
    {
        auto columnIndex = cellRange.GetFirstColumn() + i;
        auto columnWidth = cellRange.GetWorksheet().GetCells().GetColumnWidth(columnIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newColumnWidth = columnWidth * width / rangeWidth;
        auto widthInInches = newColumnWidth / 72;
        cellRange.GetWorksheet().GetCells().SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.GetRowCount(); i++)
    {
        auto rowIndex = cellRange.GetFirstRow() + i;
        auto rowHeight = cellRange.GetWorksheet().GetCells().GetRowHeight(rowIndex, false, Aspose::Cells::CellsUnitType::Point);

        auto newRowHeight = rowHeight * height / rangeHeight;
        auto heightInInches = newRowHeight / 72;
        cellRange.GetWorksheet().GetCells().SetRowHeightInch(rowIndex, heightInInches);
    }
}
```
Dieser Vorschau‑Helper rendert den skalierten Bereich mit [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/). Er verwendet [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/), um den Druck auf diesen Bereich zu beschränken, entfernt Ränder, Kopf‑ und Fußzeilen und gibt einen PNG‑Stream zurück, der an dessen Anfang positioniert ist.
```cpp
#include <system/array.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/PageSetup.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Worksheet.h"

using namespace System;
using namespace System::IO;

SharedPtr<MemoryStream> CreateOleImage(Aspose::Cells::Range cellRange, int imageResolution)
{
    auto pageSetup = cellRange.GetWorksheet().GetPageSetup();
    pageSetup.SetPrintArea(cellRange.GetAddress());
    pageSetup.SetLeftMargin(0);
    pageSetup.SetRightMargin(0);
    pageSetup.SetTopMargin(0);
    pageSetup.SetBottomMargin(0);
    pageSetup.ClearHeaderFooter();

    Aspose::Cells::ImageOrPrintOptions imageOptions;
    imageOptions.SetImageType(Aspose::Cells::ImageType::Png);
    imageOptions.SetVerticalResolution(imageResolution);
    imageOptions.SetHorizontalResolution(imageResolution);
    imageOptions.SetOnePagePerSheet(true);
    imageOptions.SetOnlyArea(true);

    Aspose::Cells::SheetRender sheetRender(cellRange.GetWorksheet(), imageOptions);
    auto renderData = sheetRender.ToImage(0);
    auto imageData = MakeObject<Array<uint8_t>>(renderData.GetLength(), renderData.GetData());
    auto imageStream = MakeObject<MemoryStream>(imageData);
    sheetRender.Dispose();

    return imageStream;
}
```

## **Fazit**

{{% alert color="info" title="Note" %}}
Es gibt zwei Ansätze, um das Problem mit der Größenänderung des Arbeitsblatts zu beheben. Wählen Sie den Ansatz, der am besten zu Ihren Anforderungen und Anwendungsfällen passt. Beide Ansätze funktionieren gleich, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Darüber hinaus gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objektrahmens.
{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Dies geschieht, weil Excel bei der Aktivierung versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Skalierung führen kann.

**Ist es möglich, dieses Skalierungsproblem vollständig zu verhindern?**

Ja. Durch das Skalieren des OLE‑Rahmens auf die Größe des Excel‑Zellbereichs bzw. das Skalieren des Zellbereichs auf die gewünschte OLE‑Rahmengröße kann eine unerwünschte Größenänderung verhindert werden.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmen‑Skalierung oder Zellbereich‑Skalierung?**

Wählen Sie **OLE‑Rahmen‑Skalierung**, wenn Sie die ursprünglichen Excel‑Zeilen‑ und Spaltengrößen beibehalten möchten. Wählen Sie **Zellbereich‑Skalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation wünschen.

**Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren sowohl für aus Vorlagen erstellte als auch für von Grund auf neu erstellte Präsentationen.

**Gibt es eine Begrenzung für die Größe des OLE‑Rahmens bei Verwendung dieser Methoden?**

Nein. Der OLE‑Objektrahmen kann beliebig groß sein, solange die Skalierung entsprechend eingestellt wird.

**Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**

Ja. Durch das Erstellen eines Schnappschusses des gewünschten Excel‑Zellbereichs und das Festlegen dieses Bildes als Platzhalterbild des OLE‑Rahmens können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)