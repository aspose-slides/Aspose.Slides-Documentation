---
title: Működő megoldás a munkalap átméretezésére
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
description: "Javítsa az Excel munkalap OLE átméretezését a prezentációkban: két mód a objektumkeretek egységességének megtartására – a keret vagy a lap skálázása – a PPT és PPTX formátumok között."
---
{{% alert color="primary" %}} 

Megfigyeltük, hogy az Aspose komponenseken keresztül PowerPoint‑prezentációba beágyazott OLE‑objektumként megjelenő Excel‑munkalapok az első aktiválás után egy ismeretlen méretarányra méreteződnek át. Ez a viselkedés a prezentációban észrevehető vizuális különbséget eredményez az OLE‑objektum aktiválás előtti és utáni állapota között. Részletesen vizsgáltuk ezt a problémát, és megoldást nyújtottunk, amely ebben a cikkben szerepel.

{{% /alert %}} 

## **Háttér**

Az [OLE kezelés](/slides/hu/net/manage-ole/) című cikkben bemutattuk, hogyan adhatunk OLE‑keretet egy PowerPoint‑prezentációhoz az Aspose.Slides for .NET segítségével. A [objektum előnézeti problémájának](/slides/hu/net/object-preview-issue-when-adding-oleobjectframe/) megoldásaként a kiválasztott munkalap területének képét rendeltük az OLE‑objektumkerethez. A kimeneti prezentációban, ha duplán kattint a munkalapkép‑megjelenítő OLE‑objektumkeretre, az Excel‑munkafüzet aktiválódik. A felhasználók a tényleges Excel‑munkafüzetben tetszőleges módosításokat végezhetnek, majd az aktivált Excel‑munkafüzeten kívülre kattintva visszatérhetnek a diára. Az OLE‑objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára. A méretezési tényező a OLE‑objektumkeret és a beágyazott Excel‑munkafüzet méretétől függ.

## **Átméretezés oka**

Mivel az Excel‑munkafüzetnek saját ablakmérete van, az első aktiváláskor igyekszik megőrizni eredeti méretét. Ezzel szemben az OLE‑objektumkeretnek saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, hogy az beágyazási folyamat során a helyes arányokat megtartsa. Az átméretezés az Excel‑ablak mérete és az OLE‑objektumkeret mérete‑pozíciója közti különbségen alapul.

## **Működő megoldás**

Az átméretezési hatás elkerülésére két lehetséges megoldás van.

- Méretezze át az OLE‑keret méretét a PowerPoint‑prezentációban úgy, hogy a kívánt sor- és oszlopszám magasságával és szélességével megegyezzen.
- Tartsa állandó méretűnek az OLE‑keretet, és skálázza a részt vevő sorok és oszlopok méretét, hogy illeszkedjen a kiválasztott OLE‑keret méretéhez.

### **Az OLE keret méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel‑munkafüzet OLE‑keret méretét úgy, hogy az megegyezzen a munkalapban részt vevő sorok és oszlopok összegzett méretével.

Tegyük fel, hogy van egy sablon Excel‑lapunk, amelyet OLE‑keretként szeretnénk hozzáadni a prezentációhoz. Ebben az esetben az OLE‑objektumkeret méretét először a munkafüzetben részt vevő sorok magasságának és oszlopok szélességének összegzése alapján számítjuk ki. Ezután ezt a kiszámított értéket állítjuk be az OLE‑keret méretének. A PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben a kívánt sor- és oszloptartományok képét is lekapjuk, és azt állítjuk be OLE‑keret képként.

```cs
int startRow = 0, rowCount = 10;
int startColumn = 0, columnCount = 13;
int worksheetIndex = 0;

int imageResolution = 96;

using var workbook = new Aspose.Cells.Workbook("sample.xlsx");
var worksheet = workbook.Worksheets[worksheetIndex];

// Állítsa be a megjelenített méretet, amikor a munkafájl OLE objektumként van használva a PowerPointban.
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

// Hozza létre az OLE objektum keretet.
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

### **A cellatartomány méretének skálázása**

Ebben a megközelítésben megtanuljuk, hogyan skálázzuk a részt vevő sorok magasságát és az oszlopok szélességét úgy, hogy az egy egyedi OLE‑keret méretének megfeleljen.

Tegyük fel, hogy van egy sablon Excel‑lapunk, amelyet OLE‑keretként szeretnénk hozzáadni a prezentációhoz. Ebben az esetben beállítjuk az OLE‑keret méretét, és skálázzuk a keret területébe tartozó sorok és oszlopok méretét. Ezután a munkafüzét egy stream‑be mentjük, hogy az változtatásokat alkalmazzuk, és bájt‑tömbbé konvertáljuk az OLE‑kerethez való hozzáadáshoz. A PowerPoint‑ban megjelenő piros „EMBEDDED OLE OBJECT” üzenet elkerülése érdekében a munkafüzetben a kívánt sor- és oszloptartományok képét is lekapjuk, és azt állítjuk be OLE‑keret képként.

```cs
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

// Hozza létre az OLE objektum keretet.
var dataInfo = new OleEmbeddedDataInfo(oleStream.ToArray(), "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(10, 10, frameWidth, frameHeight, dataInfo);
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

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

{{% alert color="primary" %}}

Az munkalap átméretezési problémáját két megközelítéssel lehet orvosolni. A megfelelő módszer kiválasztása a konkrét követelményektől és felhasználási esettől függ. Mindkét megközelítés ugyanúgy működik, legyen szó sablonból vagy a semmiből létrehozott prezentációról. Továbbá ebben a megoldásban nincs korlátozás az OLE‑objektumkeret méretére.

{{% /alert %}}

## **GYIK**

**Miért változik a beágyazott Excel‑munkalap mérete az első PowerPoint‑aktiváláskor?**  
Ez azért történik, mert az Excel aktiváláskor az eredeti ablakméretét próbálja megtartani, míg a PowerPoint‑ban az OLE‑objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet, hogy az arányt megtartsák, ami átméretezést eredményez.

**Lehet-e teljesen megakadályozni ezt az átméretezési problémát?**  
Igen. Az OLE‑keret méretének az Excel‑cellatartomány méretéhez való igazításával vagy a cellatartomány méretének a kívánt OLE‑kerethez való skálázásával elkerülhető a nem kívánt átméretezés.

**Melyik skálázási módszert használjam, az OLE‑keret skálázását vagy a cellatartomány skálázását?**  
Válassza az **OLE‑keret skálázását**, ha az eredeti Excel‑sor- és oszlopszemléket szeretné megtartani. Válassza a **cellatartomány skálázását**, ha egy rögzített méretű OLE‑keretet kíván a prezentációban.

**Működni fognak ezek a megoldások, ha a prezentáció sablonon alapul?**  
Igen. Mindkét megoldás működik sablonokból és alapból létrehozott prezentációk esetén.

**Van-e korlátozás az OLE‑keret méretére ezzel a módszerrel?**  
Nincs. Az OLE‑objektumkeretet bármilyen méretűre beállíthatja, amíg a skálát megfelelően definiálja.

**Létezik módja annak, hogy elkerüljük a „EMBEDDED OLE OBJECT” helyőrző szöveget a PowerPointban?**  
Igen. A cél Excel‑cellatartomány képének lefotózásával és azt az OLE‑keret helyőrző képeként beállítva egy egyedi előnézeti képet jeleníthet meg az alapértelmezett helyőrző helyett.

## **Kapcsolódó cikkek**

[Excel diagram létrehozása és OLE‑objektumként történő beágyazása a prezentációba](/slides/hu/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[OLE‑objektumok automatikus frissítése MS PowerPoint‑kiegészítő használatával](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)