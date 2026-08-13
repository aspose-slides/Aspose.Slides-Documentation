---
title: Működő megoldás a munkalap átméretezéséhez
type: docs
weight: 130
url: /hu/cpp/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezés
- Excel
- munkalap
- PowerPoint
- prezentáció
- C++
- Aspose.Slides for C++
description: "Működő megoldás a munkalap átméretezésére PowerPoint prezentációkban C++ használatával"
---
{{% alert color="info" %}}

Azt megfigyeltük, hogy az Aspose komponensekkel egy PowerPoint‑prezentációba beágyazott Excel‑munkalapok OLE‑objektumként az első aktiválás után ismeretlen méretarányra méreteződnek át. Ez a viselkedés a prezentációban észrevehető vizuális eltérést okoz az OLE‑objektum aktiválás előtti és utáni állapota között. Részletesen kivizsgáltuk ezt a problémát, és megoldást nyújtottunk, amelyet ebben a cikkben ismertetünk.

{{% /alert %}}

## **Háttér**

A [Manage OLE](/slides/hu/cpp/manage-ole/) című cikkben ismertettük, hogyan lehet OLE‑keretet hozzáadni egy PowerPoint‑prezentációhoz az Aspose.Slides for C++ segítségével. Az [object preview issue](/slides/hu/cpp/object-preview-issue-when-adding-oleobjectframe/) megoldásához az OLE‑objektumkerethez a kiválasztott munkalap területének képét rendeltük hozzá. A kimeneti prezentációban, ha duplán kattint a munkalap képet megjelenítő OLE‑objektumkeretre, az Excel‑munkafüzet aktiválódik. A végfelhasználó elvégezheti a kívánt módosításokat a tényleges Excel‑munkafüzetben, majd a diához visszatérve a aktivált Excel‑munkafüzeten kívülre kattint. Az OLE‑objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára. A méretezési tényező a OLE‑objektumkeret és a beágyazott Excel‑munkafüzet méretétől függ.

## **Az átméretezés oka**

Mivel az Excel‑munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani az eredeti méretét. Ezzel szemben az OLE‑objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy az beágyazási folyamat részeként a megfelelő arányokat megőrizze. Az átméretezés az Excel‑ablak mérete és az OLE‑objektumkeret mérete és pozíciója közötti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik az átméretezési hatás elkerülésére.

- Méretezze az OLE‑keret méretét a PowerPoint‑prezentációban, hogy megfeleljen a kívánt sorok és oszlopok magasságának és szélességének az OLE‑keretben.
- Tartsa állandóan az OLE‑keret méretét, és méretezze a résztvevő sorok és oszlopok méretét úgy, hogy illeszkedjenek a kiválasztott OLE‑keret méretébe.

### **Az OLE‑keret méretének skálázása**

Ebben a megközelítésben megmutatjuk, hogyan állítható be a beágyazott Excel‑munkafüzet OLE‑keretmérete úgy, hogy az egyezzen a munkalapban résztvevő sorok és oszlopok összesített méretével.

Tegyük fel, hogy van egy sablon Excel‑lapunk, és OLE‑keretként szeretnénk hozzáadni egy prezentációhoz. Ebben az esetben az OLE‑objektumkeret méretét először a munkafüzetben résztvevő sorok magasságának és oszlopok szélességének összesített értéke alapján számítjuk ki. Ezután ezt a kiszámított értéket állítjuk be az OLE‑keret méretének. A PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben a kívánt sor- és oszloptartomány képet is rögzítjük, és azt állítjuk be OLE‑keret képként.

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

// Állítsa be a megjelenített méretet, amikor a munkafájl OLE‑objektumként van használva a PowerPointban.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Szerezze meg az OLE-kép szélességét és magasságát pontban.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// A módosított munkafüzetet kell használnunk.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Hozza létre az OLE-objektumkeretet.
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

### **A cellatartomány méretének skálázása**

Ebben a megközelítésben megmutatjuk, hogyan lehet a résztvevő sorok magasságát és oszlopok szélességét skálázni, hogy azok egy egyéni OLE‑keretmérettel egyezzenek.

Tegyük fel, hogy van egy sablon Excel‑lapunk, és OLE‑keretként szeretnénk hozzáadni egy prezentációhoz. Ebben az esetben beállítjuk az OLE‑keret méretét, és skálázzuk a OLE‑keret területén résztvevő sorok és oszlopok méretét. Ezután a változtatásokat egy áramlamba (stream) mentjük, byte‑tömbbé konvertáljuk, és a OLE‑kerethez adjuk. A PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben a kívánt sor- és oszloptartomány képet is rögzítjük, és azt állítjuk be OLE‑keret képként.

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

// A módosított munkafüzetet kell használnunk.
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

{{% alert color="info" %}}

Az munkalap átméretezési problémájának megoldására két megközelítés létezik. A megfelelő megközelítés kiválasztása a konkrét követelményektől és felhasználási esettől függ. Mindkét módszer ugyanúgy működik, legyen szó sablonból vagy üresből készült prezentációról. Ezenkívül ebben a megoldásban nincs korlátozás az OLE‑objektumkeret méretére.

{{% /alert %}}

## **GYIK**

### Miért változik méretét egy beágyazott Excel‑munkalapnak, amikor először aktiválják PowerPoint‑ban?

Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretet aktiváláskor, míg a PowerPoint‑ban az OLE‑objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet az arányok megtartása érdekében, ami az átméretezést okozhat.

### Lehetséges-e ezt az átméretezési problémát teljesen elkerülni?

Igen. Az OLE‑keret skálázásával az Excel‑cellatartomány méretéhez vagy a cellatartomány skálázásával a kívánt OLE‑keretmérethez megakadályozható a nem kívánt átméretezés.

### Melyik skálázási módszert válasszam, az OLE‑keret skálázását vagy a cellatartomány skálázását?

Válassza az **OLE‑keret skálázását**, ha meg szeretné tartani az eredeti Excel‑sorok és -oszlopok méretét. Válassza a **cellatartomány skálázását**, ha a prezentációban egy fix OLE‑keretméretet szeretne.

### Működnek-e ezek a megoldások, ha a prezentációm sablonon alapul?

Igen. Mindkét megoldás működik sablonból és üresből létrehozott prezentációk esetén is.

### Van-e korlátozás az OLE‑keret méretére ezeknél a módszereknél?

Nem. Az OLE‑objektumkeretet tetszőleges méretűre beállíthatja, amíg a skálát megfelelően állítja.

### Van mód elkerülni a "EMBEDDED OLE OBJECT" helyőrző szöveget a PowerPoint‑ban?

Igen. A célzott Excel‑cellatartomány pillanatképének elkészítésével és azt OLE‑keret helyőrzőképként beállítva egy egyéni előnézeti képet jeleníthet meg az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Excel diagram létrehozása és OLE‑objektumként beágyazása a prezentációba](/slides/hu/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)