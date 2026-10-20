---
title: Működő megoldás a munkalap átméretezéséhez
type: docs
weight: 130
url: /hu/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezése
- Excel
- munkalap
- PowerPoint
- prezentáció
- C++
- Aspose.Slides for C++
description: "Működő megoldás a munkalap átméretezésére PowerPoint prezentációkban C++ használatával"
---
{{% alert color="info" title="Note" %}}
Az Aspose komponenseket használó PowerPoint‑prezentációba beágyazott OLE objektumként megjelenő Excel munkalapok első aktiválás után váratlanul átméreteződhetnek. Ez a viselkedés észrevehető vizuális különbséget eredményez az OLE objektum aktiválás előtti és utáni állapota között. Ez a cikk ismerteti a problémát, és két megoldási módot mutat be.
{{% /alert %}}

## **Háttér**

A [OLE kezelése](/slides/hu/cpp/manage-ole/) című cikkben ismertettük, hogyan lehet OLE keretet hozzáadni egy PowerPoint‑prezentációhoz az Aspose.Slides for C++ segítségével. Az [objektum előnézeti probléma](/slides/hu/cpp/object-preview-issue-when-adding-oleobjectframe/) megoldásához az OLE objektumkerethez a kiválasztott munkalap területének képét rendeltük hozzá. A kimeneti prezentációban, amikor duplán kattint a munkalap képet megjelenítő OLE objektumkeretre, az Excel munkafüzet aktiválódik. A végfelhasználók tetszőleges módosítást végezhetnek a tényleges Excel munkafüzetben, majd a slide‑ra visszatérhetnek az aktivált Excel munkafüzeten kívülre kattintva. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a slide‑ra. Az átméretezési arány a OLE objektumkeret és a beágyazott Excel munkafüzet méretétől függ.

## **Az átméretezés oka**

Mivel az Excel munkafüzetnek saját ablaktávolsága van, az első aktiváláskor megpróbálja megtartani az eredeti méretét. Ezzel szemben az OLE objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy az beágyazás során a helyes arányokat biztosítsa. Az átméretezés az Excel ablakmérete és az OLE objektumkeret mérete‑pozíciója közti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik az átméretezési hatás elkerülésére.

- Méretezze át az OLE keretet a PowerPoint‑prezentációban, hogy a kiválasztott sorok és oszlopok teljes magasságát és szélességét lefedje.
- Tartsa állandó méretűnek az OLE keretet, és skálázza a kiválasztott sorokat és oszlopokat, hogy beleilljen.

### **Az OLE keret méretének skálázása**

Ez a megközelítés az OLE keret méretét úgy állítja be, hogy az megegyezzen a beágyazott Excel munkalapban a kiválasztott sorok és oszlopok teljes magasságával és szélességével.

A példa betölti egy meglévő Excel munkafüzetet, és a nullától indexelt első munkalap első 10 sorát és 13 oszlopát választja ki. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) határozza meg a megjelenített tartományt. Az előnézet 96 DPI‑n kerül renderelésre, és a képpontméreteket 72 pont per hüvelyk arányával átalakítják pontokba. [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) a módosított munkafüzetet egy ilyen méretű keretbe ágyazza be. Az előnézetet a [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) segítségével rendeljük hozzá, hogy helyettesítse a mentett prezentációban a "EMBEDDED OLE OBJECT" helyőrzőt.
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

Az előnézet segédprogram a [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) használatával választja ki a tartományt, és eltávolítja a margókat, fejléceket és lábléceket. A [ImageOrPrintOptions::SetOnlyArea](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/imageorprintoptions/setonlyarea/) engedélyezésével a [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) PNG‑képet renderel a tartományról. A segédprogram a renderelt képadatokat egy új memória‑folyamba másolja, amely a elején van pozicionálva, a prezentációban való felhasználáshoz.
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

### **A cellatartomány méretének skálázása**

Ez a megközelítés a kiválasztott sorok magasságát és oszlopok szélességét skálázza, hogy egyezzen egy egyéni OLE keretmérettel.

Az példa betölti egy meglévő Excel munkafüzetet, és a nullától indexelt első munkalap első 10 sorát és 13 oszlopát választja ki. [WorksheetCollection::SetOleSize](https://reference.aspose.com/cells/cpp/aspose.cells/worksheetcollection/setolesize/) határozza meg a megjelenített tartományt, és az alábbi segédprogram skálázza ezt a tartományt, hogy beleférjen egy 400 pont széles és 100 pont magas keretbe. A módosított munkafüzet byte‑tömbbe mentése után a [ShapeCollection::AddOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/shapecollection/addoleobjectframe/) a megadott mérettel ágyazza be. Egy 96 DPI‑n renderelt előnézetet a [OleObjectFrame::get_SubstitutePictureFormat](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/get_substitutepictureformat/) segítségével rendeljük hozzá, így a mentett prezentáció a kiválasztott cellákat jeleníti meg az alapértelmezett helyőrző helyett.
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

// Állítsa be a megjelenített méretet, amikor a munkafájl OLE objektumként van használva a PowerPointban.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skálázza a cellatartományt, hogy illeszkedjen a keret méretéhez.
auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

auto imageStream = CreateOleImage(cellRange, imageResolution);

// Használnunk kell a módosított munkafüzetet.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Hozza létre az OLE objektumkeretet.
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(oleData, u"xlsx");
auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();

Aspose::Cells::Cleanup();
```

A skálázó segédprogram külön szélesség‑ és magasság‑arányokat számít a kiválasztott tartományra, megőrizve az oszlopok relatív szélességét és a sorok relatív magasságát. A kiszámított méreteket pontból hüvelykre konvertálja, mielőtt a [Cells::SetColumnWidthInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setcolumnwidthinch/) és a [Cells::SetRowHeightInch](https://reference.aspose.com/cells/cpp/aspose.cells/cells/setrowheightinch/) segítségével alkalmazná. A kiválasztott tartománynak nem lehet nulla szélességű vagy magasságú.
```cpp
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/CellsUnitType.h"
#include "Aspose.Cells/Range.h"
#include "Aspose.Cells/Worksheet.h"

/// <param name="width">A cellatartomány várható szélessége pontban.</param>
/// <param name="height">A cellatartomány várható magassága pontban.</param>
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

Ez az előnézet segédprogram a [SheetRender::ToImage](https://reference.aspose.com/cells/cpp/aspose.cells.rendering/sheetrender/toimage/) használatával rendereli a átméretezett tartományt. A [PageSetup::SetPrintArea](https://reference.aspose.com/cells/cpp/aspose.cells/pagesetup/setprintarea/) segítségével a nyomtatást erre a tartományra korlátozza, eltávolítja a margókat, fejléceket és lábléceket, és egy PNG‑folyamot ad vissza, amely a kezdeténél van pozicionálva.
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

## **Következtetés**
{{% alert color="info" title="Note" %}}
Két megközelítés létezik a munkalap átméretezési probléma megoldására. Válassza azt a megoldást, amely a legjobban megfelel az igényeinek és a felhasználási esetnek. Mindkét megközelítés egyformán működik, akár sablonból, akár üresből készített prezentációk esetén. Emellett nincs korláta az OLE objektumkeret méretének ebben a megoldásban.
{{% /alert %}}

## **GYIK**

**Miért változik méretben egy beágyazott Excel munkalap, amikor első alkalommal aktiválják PowerPointban?**  
Ez azért történik, mert az Excel aktiváláskor megpróbálja megtartani az eredeti ablakméretet, míg a PowerPoint‑ban az OLE objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet, hogy megőrizzék az arányokat, ami átméretezést eredményezhet.

**Lehet-e teljesen megakadályozni ezt az átméretezési problémát?**  
Igen. Az OLE keret skálázásával úgy, hogy illeszkedjen az Excel cellatartomány méretéhez, vagy a cellatartomány skálázásával úgy, hogy illeszkedjen a kívánt OLE keretmérethez, elkerülhető a nem kívánt átméretezés.

**Melyik skálázási módszert használjam, OLE keret skálázást vagy cellatartomány skálázást?**  
Válassza az **OLE keret skálázását**, ha az eredeti Excel sor- és oszlops méreteket szeretné megtartani. Válassza a **cellatartomány skálázását**, ha a prezentációjában egy fix méretű OLE keretet szeretne.

**Működnek-e ezek a megoldások, ha a prezentációm sablonon alapul?**  
Igen. Mindkét megoldás működik sablonból és üresből létrehozott prezentációk esetén.

**Van-e korlátozás az OLE keret méretére ezekkel a módszerekkel?**  
Nem. Az OLE objektumkeretet tetszőleges méretűre állíthatja, amíg a skálát megfelelően beállítja.

**Létezik mód a "EMBEDDED OLE OBJECT" helyőrző szöveg elkerülésére a PowerPointban?**  
Igen. A cél Excel cellatartomány pillanatfelvételének készítésével, és azt OLE keret helyőrző képeként beállítva, egy egyedi előnézeti képet jeleníthet meg az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Excel diagram létrehozása és OLE objektumként történő beágyazása a prezentációba](/slides/hu/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)