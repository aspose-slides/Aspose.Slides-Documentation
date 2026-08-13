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
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek egységes tartására - a keret vagy a lap méretezése - a PPT és PPTX formátumokban."
---
{{% alert color="info" %}} 

Megfigyelés szerint az Aspose komponenseken keresztül egy PowerPoint előadásba beágyazott OLE objektumként megjelenő Excel munkalapok az első aktiválás után ismeretlen méretarányra vannak átméretezve. Ez a viselkedés észrevehető vizuális különbséget eredményez az előadásban az OLE objektum aktiválás előtti és utáni állapota között. Részletesen kivizsgáltuk a problémát, és megoldást nyújtottunk, amely ebben a cikkben található.

{{% /alert %}} 

## **Háttér**

A [Manage OLE](/slides/hu/net/manage-ole/) című cikkben elmagyaráztuk, hogyan lehet OLE keretet hozzáadni egy PowerPoint előadáshoz az Aspose.Slides for .NET használatával. A [object preview issue](/slides/hu/net/object-preview-issue-when-adding-oleobjectframe/) kezeléséhez a kiválasztott munkalap területének képét rendeltük az OLE objektum keretéhez. A kimeneti előadásban, ha duplán kattint a munkalap képet megjelenítő OLE objektum keretre, az Excel munkafüzet aktiválódik. A végfelhasználók tetszőleges módosításokat végezhetnek a tényleges Excel munkafüzeten, majd a diára visszatérhetnek a aktivált Excel munkafüzeten kívül kattintva. Az OLE objektum keret mérete megváltozik, amikor a felhasználó visszatér a diára. Az átméretezési tényező a OLE objektum keret és a beágyazott Excel munkafüzet méretétől függ.

## **Az átméretezés oka**

Mivel az Excel munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani az eredeti méretét. Ezzel szemben az OLE objektum keretnek saját mérete van. A Microsoft szerint, amikor az Excel munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy biztosítsák a megfelelő arányok megtartását a beágyazási folyamat részeként. Az átméretezés az Excel ablakmérete és az OLE objektum keret mérete és pozíciója közti különbségek alapján történik.

## **Működő megoldás**

Két lehetséges megoldás létezik az átméretezési hatás elkerülésére.

- Méretezze át az OLE keret méretét a PowerPoint előadásban, hogy megegyezzen az OLE keretben kívánt sorok és oszlopok magasságával és szélességével.
- Tartsa állandóan az OLE keret méretét, és méretezze át a résztvevő sorok és oszlopok méretét, hogy illeszkedjen a kiválasztott OLE keret méretébe.

### **OLE keret méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel munkafüzet OLE keret méretét úgy, hogy az megegyezzen a munkalapban résztvevő sorok és oszlopok összesített méretével.

Tegyük fel, hogy van egy sablon Excel lapunk, és OLE keretként szeretnénk hozzáadni egy előadáshoz. Ebben a helyzetben az OLE objektum keret méretét először a munkafüzetben résztvevő sorok magasságának és oszlopok szélességének összesített értéke alapján számítjuk ki. Ezután ezt a kiszámított értéket állítjuk be az OLE keret méretének. A PowerPointban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben kívánt sor- és oszloptartományok képét is rögzítjük, és azt állítjuk be OLE keret képként.

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

// Állítsa be a megjelenített méretet, amikor a munkafüzetfájl OLE objektumként van használva a PowerPointban.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
var imageStream = CreateOleImage(cellRange, imageResolution);

// Szerezze meg az OLE kép szélességét és magasságát pontokban.
using var image = Image.FromStream(imageStream);
var imageWidth = image.Width * 72 / imageResolution;
var imageHeight = image.Height * 72 / imageResolution;

// A módosított munkafüzetet kell használnunk.
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

### **Cella tartomány méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan skálázzuk a résztvevő sorok magasságát és oszlopok szélességét úgy, hogy az egyedi OLE keret méretéhez illeszkedjen.

Tegyük fel, hogy van egy sablon Excel lapunk, és OLE keretként szeretnénk hozzáadni egy előadáshoz. Ebben a helyzetben beállítjuk az OLE keret méretét, és skálázzuk a OLE keret területében résztvevő sorok és oszlopok méretét. Ezután a munkafüzetet áramlamba (stream) mentjük a módosítások alkalmazásához, és bájttömbbé alakítjuk, hogy hozzáadhassuk az OLE kerethez. A PowerPointban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben kívánt sor- és oszloptartományok képét is rögzítjük, és azt állítjuk be OLE keret képként.

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

// Állítsa be a megjelenített méretet, amikor a munkafüzet fájlt OLE objektumként használják a PowerPointban.
var lastRow = startRow + rowCount - 1;
var lastColumn = startColumn + columnCount - 1;
workbook.Worksheets.SetOleSize(startRow, lastRow, startColumn, lastColumn);

// Skálázza a cellatartományt, hogy illeszkedjen a keret méretéhez.
var cellRange = worksheet.Cells.CreateRange(startRow, startColumn, rowCount, columnCount);
ScaleCellRange(cellRange, frameWidth, frameHeight);

var imageStream = CreateOleImage(cellRange, imageResolution);

// A módosított munkafüzetet kell használnunk.
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

```cs
/// <param name="width">A cellatartomány várható szélessége pontban.</param>
/// <param name="height">A cellatartomány várható magassága pontban.</param>
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

{{% alert color="info" %}}

Két megközelítés létezik a munkalap átméretezési probléma megoldására. A megfelelő megközelítés kiválasztása a konkrét követelményektől és felhasználási esetektől függ. Mindkét megközelítés ugyanúgy működik, függetlenül attól, hogy az előadás sablonból vagy a nulláról lett-e létrehozva. Továbbá ebben a megoldásban nincs korlátozás az OLE objektum keret méretére vonatkozóan.

{{% /alert %}}

## **GYIK**

### Miért változik a beágyazott Excel munkalap mérete az első PowerPoint aktiváláskor?
Ez azért fordul elő, mert az Excel az aktiváláskor megpróbálja megtartani az eredeti ablakméretet, míg a PowerPoint OLE objektum keretének saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet, hogy megőrizzék az arányt, ami átméretezést okozhat.

### Lehet-e teljesen elkerülni ezt az átméretezési problémát?
Igen. Az OLE keret skálázásával az Excel cellatartomány méretéhez, vagy a cellatartomány skálázásával a kívánt OLE keret méretéhez megakadályozható a nem kívánt átméretezés.

### Melyik skálázási módszert kellene használnom, OLE keret skálázást vagy cellatartomány skálázást?
Válassza a **OLE keret skálázást**, ha az eredeti Excel sor- és oszlops méreteket szeretné megőrizni. Válassza a **cellatartomány skálázást**, ha a prezentációban egy rögzített méretű OLE keretet szeretne.

### Működnek ezek a megoldások, ha az előadás sablonon alapul?
Igen. Mindkét megoldás működik sablonból vagy a nulláról létrehozott előadások esetén.

### Van-e korlátozás az OLE keret méretére ezen módszerek használatakor?
Nem. Az OLE objektum keretet tetszőleges méretűre állíthatja, amíg a skálát megfelelően beállítja.

### Van mód a „EMBEDDED OLE OBJECT” helykitöltő szöveg elkerülésére a PowerPointban?
Igen. A célzott Excel cellatartomány pillanatképének készítésével és azt OLE keret helykitöltő képének beállításával egy egyedi előnézeti képet jeleníthet meg az alapértelmezett helykitöltő helyett.

## **Kapcsolódó cikkek**

[Excel diagram létrehozása és OLE objektumként való beágyazása egy előadásba](/slides/hu/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE objektumok automatikus frissítése MS PowerPoint kiegészítő használatával](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)