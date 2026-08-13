---
title: Arbeitslösung für das Ändern der Arbeitsblattgröße
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
- Aspose.Slides für C++
description: "Arbeitslösung für die Größenänderung von Arbeitsblättern in PowerPoint-Präsentationen mittels C++"
---
{{% alert color="info" %}}
Es wurde beobachtet, dass in einer PowerPoint‑Präsentation über Aspose‑Komponenten eingebettete Excel‑Arbeitsblätter als OLE‑Objekte nach der ersten Aktivierung auf eine nicht definierte Skalierung skaliert werden. Dieses Verhalten erzeugt einen deutlich sichtbaren visuellen Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des OLE‑Objekts. Wir haben dieses Problem eingehend untersucht und eine Lösung bereitgestellt, die in diesem Artikel behandelt wird.
{{% /alert %}}

## **Hintergrund**

Im Artikel [Manage OLE](/slides/de/cpp/manage-ole/) haben wir erklärt, wie man mit Aspose.Slides für C++ einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [object preview issue](/slides/de/cpp/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objekt‑Rahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der Ergebnis‑Präsentation wird beim Doppelklick auf den OLE‑Objekt‑Rahmen, der das Arbeitsblatt‑Bild anzeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können beliebige Änderungen an der eigentlichen Excel‑Arbeitsmappe vornehmen und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Die Größe des OLE‑Objekt‑Rahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objekt‑Rahmens und der eingebetteten Excel‑Arbeitsmappe.

## **Ursache der Größenänderung**

Da die Excel‑Arbeitsmappe über eine eigene Fenstergröße verfügt, versucht sie, nach der ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Der OLE‑Objekt‑Rahmen hingegen hat seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Arbeitsmappe die Größe, um sicherzustellen, dass die korrekten Proportionen im Einbettungsprozess erhalten bleiben. Die Größenänderung erfolgt aufgrund der Unterschiede zwischen der Excel‑Fenstergröße und der Größe sowie Position des OLE‑Objekt‑Rahmens.

## **Lösungsansatz**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skalieren Sie die OLE‑Rahmengröße in der PowerPoint‑Präsentation, sodass sie der Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen entspricht.
- Halten Sie die OLE‑Rahmengröße konstant und skalieren Sie die Größe der beteiligten Zeilen und Spalten, sodass sie in die ausgewählte OLE‑Rahmengröße passen.

### **OLE‑Rahmengröße skalieren**

In diesem Ansatz lernen wir, wie man die Größe des OLE‑Rahmens der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der kumulierten Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objekt‑Rahmens zunächst basierend auf den kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten in der Arbeitsmappe berechnet. Anschließend setzen wir die Größe des OLE‑Rahmens auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Bereiche der Zeilen und Spalten in der Arbeitsmappe und setzen es als OLE‑Rahmen‑Bild.

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

// Setzen Sie die angezeigte Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Ermitteln Sie die Breite und Höhe des OLE-Bildes in Punkten.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Wir müssen die modifizierte Arbeitsmappe verwenden.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Fügen Sie das OLE-Bild zu den Präsentationsressourcen hinzu.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Erstellen Sie den OLE-Objektrahmen.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```
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

### **Zellbereichsgröße skalieren**

In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten so skaliert, dass sie einer benutzerdefinierten OLE‑Rahmengröße entsprechen.

Angenommen, wir haben ein Excel‑Vorlagenblatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Rahmens und skalieren die Größe der Zeilen und Spalten, die im OLE‑Rahmenbereich enthalten sind. Anschließend speichern wir die Arbeitsmappe in einen Stream, um die Änderungen anzuwenden, und konvertieren sie in ein Byte‑Array, um sie dem OLE‑Rahmen hinzuzufügen. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Bereiche der Zeilen und Spalten in der Arbeitsmappe und setzen es als OLE‑Rahmen‑Bild.

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

// Setzen Sie die angezeigte Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skalieren Sie den Zellbereich, damit er in die Rahmen-Größe passt.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen die modifizierte Arbeitsmappe verwenden.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Fügen Sie das OLE-Bild zu den Präsentationsressourcen hinzu.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Erstellen Sie den OLE-Objektrahmen.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```
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
{{% alert color="info" %}}
Es gibt zwei Ansätze, um das Problem der Größenänderung des Arbeitsblatts zu beheben. Die Auswahl des geeigneten Ansatzes hängt von den konkreten Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren gleichermaßen, egal ob die Präsentationen aus einer Vorlage oder von Grund auf neu erstellt werden. Zusätzlich gibt es in dieser Lösung keine Begrenzung für die Größe des OLE‑Objekt‑Rahmens.
{{% /alert %}}

## **FAQ**

### Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?
Das geschieht, weil Excel beim Aktivieren versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objekt‑Rahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis beizubehalten, was zu einer Größenänderung führen kann.

### Ist es möglich, dieses Größenproblem vollständig zu verhindern?
Ja. Durch das Skalieren des OLE‑Rahmens an die Größe des Excel‑Zellbereichs oder das Skalieren des Zellbereichs an die gewünschte OLE‑Rahmengröße können Sie unerwünschte Größenänderungen vermeiden.

### Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmen‑Skalierung oder Zellbereichs‑Skalierung?
Wählen Sie **OLE‑Rahmen‑Skalierung**, wenn Sie die originalen Excel‑Zeilen‑ und Spaltengrößen beibehalten möchten. Wählen Sie **Zellbereichs‑Skalierung**, wenn Sie eine feste Größe für den OLE‑Rahmen in Ihrer Präsentation wünschen.

### Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?
Ja. Beide Lösungen funktionieren für Präsentationen, die aus Vorlagen und von Grund auf neu erstellt werden.

### Gibt es eine Größenbegrenzung für den OLE‑Rahmen bei der Verwendung dieser Methoden?
Nein. Sie können den OLE‑Objekt‑Rahmen beliebig groß machen, solange Sie die Skalierung entsprechend einstellen.

### Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?
Ja. Durch das Erstellen eines Schnappschusses des Ziel‑Excel‑Zellbereichs und das Setzen dieses Bildes als Platzhalterbild des OLE‑Rahmens können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standard‑Platzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE Object](/slides/de/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)