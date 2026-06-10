---
title: Működő megoldás a munkalap méretezésére
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
description: Működő megoldás a munkalap méretezésére PowerPoint prezentációkban C++ használatával
---
{{% alert color="primary" %}}
Az megfigyelés szerint az Aspose komponensek által PowerPoint prezentációba beágyazott OLE objektumként megjelenő Excel munkalapok az első aktiválás után egy ismeretlen méretarányra méreteződnek át. Ez a viselkedés észrevehető vizuális különbséget eredményez a prezentációban az OLE objektum aktiválás előtti és utáni állapota között. Részletesen kivizsgáltuk ezt a problémát, és megoldást nyújtottunk, amelyet ebben a cikkben tárgyalunk.
{{% /alert %}}

## **Háttér**

Az [Manage OLE](/slides/hu/cpp/manage-ole/) című cikkben elmagyaráztuk, hogyan lehet OLE keretet hozzáadni egy PowerPoint prezentációhoz az Aspose.Slides for C++ használatával. Az [object preview issue](/slides/hu/cpp/object-preview-issue-when-adding-oleobjectframe/) kezelésére a kiválasztott munkalap területének képét rendeltük az OLE objektumkerethez. A kimeneti prezentációban, ha duplán kattint a munkalap képet megjelenítő OLE objektumkeretre, az Excel munkafüzet aktiválódik. A végfelhasználók a valós Excel munkafüzetben tetszőleges módosításokat végezhetnek, majd a prezentációra visszatérhetnek a aktivált Excel munkafüzeten kívülre kattintva. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára. A méretezési tényező a OLE objektumkeret és a beágyazott Excel munkafüzet mérete alapján változik.

## **Méretezés oka**

Mivel az Excel munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani eredeti méretét. Ezzel szemben az OLE objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy a beágyazási folyamat részeként a megfelelő arányok megmaradjanak. A méretezés az Excel ablakmérete és az OLE objektumkeret mérete és pozíciója közötti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik a méretezési hatás elkerülésére.

- Az OLE keret méretének skálázása a PowerPoint prezentációban, hogy megegyezzen a kívánt sorok és oszlopok magasságával és szélességével az OLE keretben.
- Az OLE keret méretét állandóan tartani, és a résztvevő sorok és oszlopok méretét skálázni, hogy illeszkedjen a kiválasztott OLE keret méretébe.

### **OLE keret méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel munkafüzet OLE keret méretét úgy, hogy megegyezzen a Excel munkalapban résztvevő sorok és oszlopok összesített méretével.

Tegyük fel, hogy van egy sablon Excel-munkalapunk, és OLE keretként szeretnénk hozzáadni egy prezentációhoz. Ebben a forgatókönyvben az OLE objektumkeret méretét először a munkafüzetben résztvevő sorok magasságának és oszlopok szélességének összegzett értéke alapján számoljuk ki. Ezután az OLE keret méretét erre a kiszámított értékre állítjuk. A PowerPointban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben kívánt sor- és oszloptartományok képét is rögzítjük, és beállítjuk OLE keret képként.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják PowerPointban.
auto lastRow = startRow + rowCount - 1;
auto lastColumn = startColumn + columnCount - 1;
workbook.GetWorksheets().SetOleSize(startRow, lastRow, startColumn, lastColumn);

auto cellRange = worksheet.GetCells().CreateRange(startRow, startColumn, rowCount, columnCount);
auto imageStream = CreateOleImage(cellRange, imageResolution);

// Szerezze meg az OLE kép szélességét és magasságát pontban.
auto image = Image::FromStream(imageStream);
auto imageWidth = image->get_Width() * 72.0f / imageResolution;
auto imageHeight = image->get_Height() * 72.0f / imageResolution;

// Használnunk kell a módosított munkafüzetet.
auto oleStream = workbook.Save(Aspose::Cells::SaveFormat::Xlsx);
auto oleData = MakeArray<uint8_t>(oleStream.GetLength(), oleStream.GetData());
workbook.Dispose();

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
auto oleImage = presentation->get_Images()->AddImage(image);
image->Dispose();

// Hozza létre az OLE objektumkeretet.
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

### **Cellatartomány méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan skálázzuk a résztvevő sorok magasságát és oszlopok szélességét úgy, hogy egy egyedi OLE keret méretéhez igazodjanak.

Tegyük fel, hogy van egy sablon Excel-munkalapunk, és OLE keretként szeretnénk hozzáadni egy prezentációhoz. Ebben a forgatókönyvben beállítjuk az OLE keret méretét, és skálázzuk a sorok és oszlopok méretét, amelyek részt vesznek az OLE keret területén. Ezután a munkafüzetet egy streambe mentjük, hogy alkalmazzuk a módosításokat, és bájt tömbbé konvertáljuk, hogy hozzá lehessen adni az OLE kerethez. A PowerPointban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben kívánt sor- és oszloptartományok képét is rögzítjük, és beállítjuk OLE keret képként.

```cpp
Aspose::Cells::Startup();

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

Aspose::Cells::Workbook workbook(u"sample.xlsx");
auto worksheet = workbook.GetWorksheets().Get(worksheetIndex);

// Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják PowerPointban.
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

```cpp
/// <param name="width">A cellatartomány várt szélessége pontban.</param>
/// <param name="height">A cellatartomány várt magassága pontban.</param>
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
{{% alert color="primary" %}}
Két megközelítés létezik a munkalap méretezési probléma megoldására. A megfelelő megközelítés kiválasztása az adott követelményektől és felhasználási esettől függ. Mindkét megközelítés ugyanúgy működik, legyen szó sablonból vagy nulláról készített prezentációról. Továbbá, ebben a megoldásban nincs korlátozás az OLE objektumkeret méretére.
{{% /alert %}}

## **GYIK**

**Miért változik méretben egy beágyazott Excel munkalap, amikor először aktiválják PowerPointban?**

Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretet aktiváláskor, míg a PowerPointban lévő OLE objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet az arány megtartása érdekében, ami a méretezést okozhat.

**Lehetséges-e teljesen elkerülni ezt a méretezési problémát?**

Igen. Az OLE keret skálázásával az Excel cellatartomány méretéhez, vagy a cellatartomány skálázásával a kívánt OLE keret méretéhez megakadályozható a nem kívánt méretezés.

**Melyik skálázási módszert használjam, OLE keret skálázást vagy cellatartomány skálázást?**

Válassza az **OLE keret skálázást**, ha meg szeretné tartani az eredeti Excel sor- és oszlopszemélyiségeket. Válassza a **cellatartomány skálázást**, ha az OLE keretnek fix méretet szeretne a prezentációban.

**Működnek ezek a megoldások, ha a prezentációm sablonon alapul?**

Igen. Mindkét megoldás működik sablonból vagy nulláról készített prezentációk esetén.

**Van korlátozás az OLE keret méretére ezzel a módszerrel?**

Nem. Az OLE objektumkeretet bármilyen méretre beállíthatja, amíg a skálát megfelelően állítja be.

**Létezik módja annak, hogy elkerülje a „EMBEDDED OLE OBJECT” helyőrző szöveget a PowerPointban?**

Igen. A célzott Excel cellatartomány pillanatképének elkészítésével és azt OLE keret helyőrző képeként beállítva egyedi előnézeti képet jeleníthet meg az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Excel diagram létrehozása és OLE objektumként való beágyazása a prezentációba](/slides/hu/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)