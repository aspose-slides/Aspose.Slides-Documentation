---
title: Arbeitslösung für die Skalierung von Arbeitsblättern
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
description: "Arbeitslösung für die Skalierung von Arbeitsblättern in PowerPoint‑Präsentationen mit C++"
---

{{% alert color="primary" %}}

Es wurde beobachtet, dass Excel-Arbeitsblätter, die als OLE-Objekte in einer PowerPoint-Präsentation über Aspose-Komponenten eingebettet sind, nach der ersten Aktivierung auf einen nicht identifizierten Maßstab skaliert werden. Dieses Verhalten erzeugt einen deutlichen visuellen Unterschied in der Präsentation zwischen dem Zustand des OLE-Objekts vor und nach der Aktivierung. Wir haben das Problem eingehend untersucht und eine Lösung bereitgestellt, die in diesem Artikel behandelt wird.

{{% /alert %}}

## **Hintergrund**

Im Artikel [Manage OLE](/slides/de/cpp/manage-ole/) erklärten wir, wie man mit Aspose.Slides für C++ einen OLE‑Rahmen zu einer PowerPoint‑Präsentation hinzufügt. Um das [object preview issue](/slides/de/cpp/object-preview-issue-when-adding-oleobjectframe/) zu beheben, haben wir dem OLE‑Objektrahmen ein Bild des ausgewählten Arbeitsblattbereichs zugewiesen. In der Ergebnis‑Präsentation wird beim Doppelklick auf den OLE‑Objektrahmen, der das Arbeitsblatt‑Bild anzeigt, die Excel‑Arbeitsmappe aktiviert. Endbenutzer können beliebige Änderungen an der tatsächlichen Excel‑Arbeitsmappe vornehmen und dann zur Folie zurückkehren, indem sie außerhalb der aktivierten Excel‑Arbeitsmappe klicken. Die Größe des OLE‑Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor variiert je nach Größe des OLE‑Objektrahmens und der eingebetteten Excel‑Arbeitsmappe. 

## **Ursache der Skalierung**

Da die Excel‑Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, bei der ersten Aktivierung ihre ursprüngliche Größe beizubehalten. Andererseits hat der OLE‑Objektrahmen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel‑Arbeitsmappe die Größe, um sicherzustellen, dass die richtigen Proportionen im Einbettungsprozess erhalten bleiben. Die Skalierung erfolgt basierend auf den Unterschieden zwischen der Excel‑Fenstergröße und der Größe und Position des OLE‑Objektrahmens.

## **Funktionierende Lösung**

Es gibt zwei mögliche Lösungen, um den Skalierungseffekt zu vermeiden.

- Skaliere die Größe des OLE‑Rahmens in der PowerPoint‑Präsentation, sodass sie der Höhe und Breite der gewünschten Anzahl von Zeilen und Spalten im OLE‑Rahmen entspricht.
- Behalte die Größe des OLE‑Rahmens konstant und skaliere die Größe der beteiligten Zeilen und Spalten, sodass sie in die ausgewählte OLE‑Rahmengröße passen.

### **OLE‑Rahmengröße skalieren**

Bei diesem Ansatz lernen wir, wie man die OLE‑Rahmengröße der eingebetteten Excel‑Arbeitsmappe so einstellt, dass sie der kumulierten Größe der beteiligten Zeilen und Spalten im Excel‑Arbeitsblatt entspricht.

Angenommen, wir haben ein Vorlagen‑Excel‑Blatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario wird die Größe des OLE‑Objektrahmens zunächst anhand der kumulierten Zeilenhöhen und Spaltenbreiten der beteiligten Zeilen und Spalten in der Arbeitsmappe berechnet. Dann setzen wir die Größe des OLE‑Rahmens auf diesen berechneten Wert. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche in der Arbeitsmappe und setzen es als OLE‑Rahmen‑Bild.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Setze die angezeigte Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
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

```cpp
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

Bei diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten so skaliert, dass sie einer benutzerdefinierten OLE‑Rahmengröße entsprechen.

Angenommen, wir haben ein Vorlagen‑Excel‑Blatt und möchten es als OLE‑Rahmen zu einer Präsentation hinzufügen. In diesem Szenario setzen wir die Größe des OLE‑Rahmens und skalieren die Größe der Zeilen und Spalten, die im OLE‑Rahmenbereich teilnehmen. Anschließend speichern wir die Arbeitsmappe in einen Stream, um die Änderungen anzuwenden, und konvertieren sie in ein Byte‑Array, um sie dem OLE‑Rahmen hinzuzufügen. Um die rote Meldung „EMBEDDED OLE OBJECT“ für den OLE‑Rahmen in PowerPoint zu vermeiden, erfassen wir außerdem ein Bild der gewünschten Zeilen‑ und Spaltenbereiche in der Arbeitsmappe und setzen es als OLE‑Rahmen‑Bild.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Setze die angezeigte Größe, wenn die Arbeitsmappendatei als OLE-Objekt in PowerPoint verwendet wird.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skaliere den Zellbereich, damit er in die Rahmengröße passt.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Wir müssen die modifizierte Arbeitsmappe verwenden.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Füge das OLE-Bild zu den Präsentationsressourcen hinzu.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Create the OLE object frame.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

```cpp
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
SharedPtr<MemoryStream> CreateOleImage(Aspise::Cells::Range cellRange, int imageResolution)
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

{{% alert color="primary" %}}

Es gibt zwei Ansätze, um das Problem der Arbeitsblatt‑Skalierung zu beheben. Die Wahl des geeigneten Ansatzes hängt von den spezifischen Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren identisch, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf erstellt werden. Zudem gibt es in dieser Lösung keine Beschränkung der Größe des OLE‑Objektrahmens.

{{% /alert %}}

## **FAQ**

**Warum ändert ein eingebettetes Excel‑Arbeitsblatt seine Größe, wenn es in PowerPoint zum ersten Mal aktiviert wird?**

Das passiert, weil Excel bei der Aktivierung versucht, die ursprüngliche Fenstergröße beizubehalten, während der OLE‑Objektrahmen in PowerPoint eigene Abmessungen hat. PowerPoint und Excel verhandeln die Größe, um das Seitenverhältnis zu erhalten, was zu einer Skalierung führen kann.

**Ist es möglich, dieses Skalierungsproblem vollständig zu verhindern?**

Ja. Durch das Skalieren des OLE‑Rahmens, um die Excel‑Zellbereichsgröße zu passen, oder durch das Skalieren des Zellbereichs, um die gewünschte OLE‑Rahmengröße zu erreichen, kann eine unerwünschte Skalierung vermieden werden.

**Welche Skalierungsmethode sollte ich verwenden, OLE‑Rahmen‑Skalierung oder Zellbereich‑Skalierung?**

Verwenden Sie **OLE‑Rahmen‑Skalierung**, wenn Sie die ursprünglichen Excel‑Zeilen‑ und Spaltengrößen beibehalten möchten. Verwenden Sie **Zellbereich‑Skalierung**, wenn Sie in Ihrer Präsentation eine feste Größe für den OLE‑Rahmen haben wollen.

**Funktionieren diese Lösungen, wenn meine Präsentation auf einer Vorlage basiert?**

Ja. Beide Lösungen funktionieren sowohl für aus Vorlagen erstellte als auch für von Grund auf neu erstellte Präsentationen.

**Gibt es eine Begrenzung der OLE‑Rahmengröße bei Verwendung dieser Methoden?**

Nein. Sie können den OLE‑Objektrahmen beliebig groß machen, solange Sie die Skalierung entsprechend einstellen.

**Gibt es eine Möglichkeit, den Platzhaltertext „EMBEDDED OLE OBJECT“ in PowerPoint zu vermeiden?**

Ja. Indem Sie einen Schnappschuss des gewünschten Excel‑Zellbereichs aufnehmen und ihn als Platzhalterbild des OLE‑Rahmens festlegen, können Sie ein benutzerdefiniertes Vorschaubild anstelle des Standardplatzhalters anzeigen.

## **Verwandte Artikel**

[Erstellen eines Excel‑Diagramms und Einbetten in eine Präsentation als OLE‑Objekt](/slides/de/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)