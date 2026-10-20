---
title: Működő megoldás a munkalap átméretezéshez
type: docs
weight: 40
url: /hu/net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- előnézeti kép
- kép átméretezés
- Excel
- munkalap
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód az objektumkeretek konzisztens megtartására – a keret vagy a munkalap skálázása – a PPT és PPTX formátumokban."
---
{{% alert color="info" title="Note" %}}

Az Aspose komponensekkel PowerPoint‑prezentációba beágyazott OLE objektumként megjelenő Excel‑munkalapok az első aktiválás után váratlanul átméreteződhetnek. Ez a viselkedés észrevehető vizuális különbséget eredményez az OLE objektum aktiválás előtti és utáni állapota között. Ez a cikk ismerteti a problémát, és két megoldási módot mutat be.

{{% /alert %}} 

## **Háttér**

A [OLE kezelése](/slides/hu/net/manage-ole/) című cikkben bemutattuk, hogyan adhatunk OLE‑keretet egy PowerPoint‑prezentációhoz az Aspose.Slides for .NET használatával. Az [objektum előnézeti probléma](/slides/hu/net/object-preview-issue-when-adding-oleobjectframe/) kezelésére a kiválasztott munkalap‑terület képét rendeltük az OLE‑objektumkerethez. A kimeneti prezentációban, amikor duplán kattint a munkalapkép‑megjelenítő OLE‑objektumkeretre, az Excel‑munkafüzet aktiválódik. A végfelhasználók tetszőleges módosítást végezhetnek a tényleges Excel‑munkafüzeteen, majd a diahoz visszatérhetnek a aktivált Excel‑munkafüzeten kívülre kattintva. Az OLE‑objektumkeret mérete változni fog, amikor a felhasználó visszatér a diára. Az átméretezés mértéke a OLE‑objektumkeret és a beágyazott Excel‑munkafüzet méretétől függ.

## **Az átméretezés oka**

Hogy mivel az Excel‑munkafüzettel saját ablakmérete van, az első aktiváláskor megpróbálja megtartani az eredeti méretét. Ezzel szemben az OLE‑objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy az beágyazási folyamat részeként megőrizze a megfelelő arányokat. Az átméretezés az Excel‑ablak mérete és az OLE‑objektumkeret mérete és pozíciója közti különbségen alapul.

## **Működő megoldás**

Az átméretezési hatás elkerülésére két lehetséges megoldás létezik.

- Skalázza az OLE‑keretet a PowerPoint‑prezentációban, hogy megegyezzen a kiválasztott sorok és oszlopok teljes magasságával és szélességével.
- Tartsa állandó méretűnek az OLE‑keretet, és skalázza a kiválasztott sorokat és oszlopokat, hogy illeszkedjenek bele.

### **OLE‑keret méretének skálázása**

Ez a megközelítés beállítja az OLE‑keret méretét, hogy megegyezzen a beágyazott Excel‑munkalapban a kiválasztott sorok és oszlopok teljes magasságával és szélességével.

Az példakód betölti egy meglévő Excel‑munkafüzetet, és a nullától induló indexekkel kiválasztja az első munkalap első 10 sorát és 13 oszlopát. A [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) határozza meg a megjelenített tartományt. Az előnézet 96 DPI‑n kerül renderelésre, pixelméreteit pedig 72 pont per hüvelyk alapján pontokba konvertálja. A [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) beágyazza a módosított munkafüzettet egy olyan keretbe, amelynek méretei megegyeznek. Az előnézetet a [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) segítségével rendeli hozzá, hogy a mentett prezentációban a "EMBEDDED OLE OBJECT" helyőrzőt lecserélje.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják a PowerPointban.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Szerezze meg az OLE kép szélességét és magasságát pontban.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// Használnunk kell a módosított munkafüzetet.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
imageStream.Seek(0, SeekOrigin.Begin);
var oleImage = presentation.Images.AddImage(imageStream);

// Hozza létre az OLE objektumkeretet.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, imageWidth, imageHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Az előnézet segédprogram a [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) beállítással a kiválasztott tartományra állítja, és eltávolítja a margókat, fejléceket és lábléceket. Az [ImageOrPrintOptions.OnlyArea](https://reference.aspose.com/cells/net/aspose.cells.rendering/imageorprintoptions/onlyarea/) engedélyezésével a [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) a tartományt PNG‑képként rendereli. A segédprogram visszaállítja a képfolyam kezdőpozícióját, mielőtt visszaadná a prezentációban való felhasználáshoz.

```cs
static MemoryStream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

### **A cellatartomány méretének skálázása**

Ez a megközelítés a kiválasztott sorok magasságát és a kiválasztott oszlopok szélességét úgy skálázza, hogy egy egyedi OLE‑keretmérethez igazodjon.

A példakód betölti egy meglévő Excel‑munkafüzetet, és a nullától induló indexekkel kiválasztja az első munkalap első 10 sorát és 13 oszlopát. A [WorksheetCollection.SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) határozza meg a megjelenített tartományt, az alábbi segédprogram pedig úgy skálázza azt, hogy egy 400 pont széles és 100 pont magas keretbe illeszkedjen. A módosított munkafüzet streambe mentése után a [ShapeCollection.AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addoleobjectframe/) beágyazza a megadott méretű keretbe. A 96 DPI‑n renderelt előnézetet a [OleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/substitutepictureformat/) segítségével rendeli hozzá, így a mentett prezentáció a kiválasztott cellákat jeleníti meg az alapértelmezett helyőrző helyett.

```cs
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;
using Aspose.Slides.Export;

int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;
float frameWidth = 400, frameHeight = 100;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Állítsa be a megjelenített méretet, amikor a munkafájl OLE objektumként van használva a PowerPointban.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skálázza a cellatartományt, hogy illeszkedjen a keret méretéhez.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// Használnunk kell a módosított munkafüzetet.
using var oleStream = new MemoryStream();
workbook.Save(oleStream, Aspose.Cells.SaveFormat.Xlsx);

using var presentation = new Presentation();
var slide = presentation.Slides.First();

// Adja hozzá az OLE képet a prezentáció erőforrásaihoz.
var oleImage = presentation.Images.AddImage(imageStream);

// Hozza létre az OLE objektumkeretet.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

A skálázó segédprogram külön szélesség‑ és magasságarányt számít a kiválasztott tartományra, megőrizve az oszlopok relatív szélességét és a sorok relatív magasságát. A kiszámított méreteket pontból hüvelykre konvertálja, mielőtt a [Cells.SetColumnWidthInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setcolumnwidthinch/) és a [Cells.SetRowHeightInch](https://reference.aspose.com/cells/net/aspose.cells/cells/setrowheightinch/) metódusokkal alkalmazná. A kiválasztott tartománynak nem lehet nulla szélességű vagy magasságú.

```cs
/// <param name="width">A cellatartomány várt szélessége pontban.</param>
/// <param name="height">A cellatartomány várt magassága pontban.</param>
static void ScaleCellRange(Aspose.Cells.Range cellRange, float width, float height)
{
    var rangeWidth = cellRange.Width;
    var rangeHeight = cellRange.Height;

    for (int i = 0; i < cellRange.ColumnCount; i++)
    {
        var columnIndex = cellRange.FirstColumn + i;
        var columnWidth = cellRange.Worksheet.Cells.GetColumnWidth(columnIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newColumnWidth = columnWidth * width / rangeWidth;
        var widthInInches = newColumnWidth / 72;
        cellRange.Worksheet.Cells.SetColumnWidthInch(columnIndex, widthInInches);
    }

    for (int i = 0; i < cellRange.RowCount; i++)
    {
        var rowIndex = cellRange.FirstRow + i;
        var rowHeight = cellRange.Worksheet.Cells.GetRowHeight(rowIndex, false, Aspose.Cells.CellsUnitType.Point);

        var newRowHeight = rowHeight * height / rangeHeight;
        var heightInInches = newRowHeight / 72;
        cellRange.Worksheet.Cells.SetRowHeightInch(rowIndex, heightInInches);
    }
}
```

Ez az előnézet segédprogram a [SheetRender.ToImage](https://reference.aspose.com/cells/net/aspose.cells.rendering/sheetrender/toimage/) segítségével rendereli a méretezett tartományt. A [PageSetup.PrintArea](https://reference.aspose.com/cells/net/aspose.cells/pagesetup/printarea/) csak erre a tartományra korlátozza, eltávolítja a margókat, fejléceket és lábléceket, és egy a kezdetén pozicionált PNG‑folyamot ad vissza.

```cs
static Stream CreateOleImage(Aspose.Cells.Range cellRange, int imageResolution)
{
    var pageSetup = cellRange.Worksheet.PageSetup;
    pageSetup.PrintArea = cellRange.Address;
    pageSetup.LeftMargin = 0;
    pageSetup.RightMargin = 0;
    pageSetup.TopMargin = 0;
    pageSetup.BottomMargin = 0;
    pageSetup.ClearHeaderFooter();

    var imageOptions = new Aspose.Cells.Rendering.ImageOrPrintOptions
    {
        ImageType = Aspose.Cells.Drawing.ImageType.Png,
        VerticalResolution = imageResolution,
        HorizontalResolution = imageResolution,
        OnePagePerSheet = true,
        OnlyArea = true
    };

    var sheetRender = new Aspose.Cells.Rendering.SheetRender(cellRange.Worksheet, imageOptions);
    var imageStream = new MemoryStream();

    sheetRender.ToImage(0, imageStream);
    imageStream.Seek(0, SeekOrigin.Begin);

    return imageStream;
}
```

## **Következtetés**

{{% alert color="info" title="Note" %}}

Az munkalap átméretezési probléma megoldására két megközelítés létezik. Válassza azt a megközelítést, amely a legjobban megfelel az igényeinek és a felhasználási esetnek. Mindkét megközelítés ugyanúgy működik, függetlenül attól, hogy a prezentációt sablonból vagy a semmiből hozza létre. Továbbá ebben a megoldásban nincs korlátozás az OLE‑objektumkeret méretére.

{{% /alert %}}

## **FAQ**

**Miért változik meg az beágyazott Excel‑munkalap mérete, amikor először aktiválják a PowerPointban?**

Ez azért történik, mert az Excel megpróbálja megtartani az eredeti ablakméretet aktiváláskor, míg a PowerPoint‑ban az OLE‑objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet, hogy megőrizzék az arányt, ami átméretezést eredményezhet.

**Lehet-e teljesen megakadályozni ezt az átméretezési problémát?**

Igen. Az OLE‑keret skálázásával az Excel‑cellatartomány méretéhez, vagy a cellatartomány skálázásával a kívánt OLE‑keretmérethez megakadályozható a nem kívánt átméretezés.

**Melyik skálázási módszert használjam, OLE‑keret skálázását vagy cellatartomány skálázását?**

Válassza az **OLE‑keret skálázását**, ha az eredeti Excel‑sor- és oszlopszemélyiségeket szeretné megőrizni. Válassza a **cellatartomány skálázását**, ha a prezentációjában rögzített méretű OLE‑keretet szeretne.

**Működnek-e ezek a megoldások, ha a prezentációm egy sablonon alapszik?**

Igen. Mindkét megoldás működik sablonból vagy a semmiből létrehozott prezentációk esetén.

**Van korlátozás az OLE‑keret méretére ezen módszerek használata esetén?**

Nem. Az OLE‑objektumkeretet tetszőleges méretűre állíthatja, amíg a skálát megfelelően beállítja.

**Van mód elkerülni a „EMBEDDED OLE OBJECT” helyőrző szöveget a PowerPointban?**

Igen. A cél Excel‑cellatartomány pillanatképének készítésével, és azt OLE‑keret helyőrzőképének beállításával megjeleníthet egy egyedi előnézeti képet az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Excel diagram létrehozása és OLE objektumként történő beágyazása egy prezentációba](/slides/hu/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE objektumok automatikus frissítése MS PowerPoint bővítmény segítségével](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)