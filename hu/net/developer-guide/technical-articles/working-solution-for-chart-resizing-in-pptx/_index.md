---
title: Működő megoldás a diagram átméretezéséhez PPTX-ben
type: docs
weight: 60
url: /hu/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezése
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Javítsa a PPTX-ben a beágyazott Excel OLE objektumok használatakor előforduló váratlan diagram átméretezést az Aspose.Slides for .NET segítségével. Állítson be rögzített diagramméreteket a diagram és az OLE keret méreteinek konzisztens megtartásához."
---
## **Háttér**

Az Aspose komponensekkel PowerPoint‑prezentációkba beágyazott OLE objektumként megjelenő Excel-diagramok az első aktiválásuk után megváltoztathatják méretüket. Ez a diagram megjelenésében jelentős különbséget okozhat aktiválás előtt és után. Ez a cikk elmagyarázza, miért történik a méretezés, és bemutatja, hogyan lehet ezt megakadályozni a diagram rögzített méretének az OLE kerethez való igazításával.

Az [Excel-diagramok létrehozása és OLE objektumként beágyazása a prezentációkba](/slides/hu/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) című cikkben ismertettük, hogyan hozhatunk létre egy Excel-diagramot az Aspose.Cells for .NET‑kel, és ágyazhatjuk be egy PowerPoint‑prezentációba az Aspose.Slides for .NET‑tel. Az [objektum előnézeti probléma](/slides/hu/net/object-preview-issue-when-adding-oleobjectframe/) kezelésére a diagram képet hozzárendeltük a diagram OLE objektumkeretéhez. A kimeneti prezentációban, amikor duplán kattint a diagram képet megjelenítő OLE objektumkeretre, az Excel-diagram aktiválódik. A felhasználók szerkeszthetik a beágyazott Excel-munkafüzetet, majd a diához visszatérhetnek a aktivált munkafüzeten kívülre kattintva. Az OLE objektumkeret mérete megválváltozik, amikor a felhasználó visszatér a diára, és a méretezési arány a OLE objektumkeret és a beágyazott Excel-munkafüzet eredeti méreteitől függ.

## **Az átméretezés oka**

A beágyazott Excel-munkafüzetnek saját ablakméretei vannak, amelyeket az Excel megpróbál megtartani az objektum első aktiválásakor. A diában lévő OLE-keret függetlenül meghatározott méretekkel rendelkezik. Amikor az Excel-munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik az objektum méretét, hogy a beágyazási folyamat részeként megőrizzék az arányokat. Az ablak és az OLE-keret közötti különbségek ezért az objektum átméreteződéséhez vezethetnek.

## **Működő megoldás**

Igazítsa a diagram méretét a dián lévő OLE-kerethez, és tartsa a diagram méreteit függetlenül a munkafüzet ablakától. Ez a megoldás új prezentációval vagy meglévő sablonnal egyaránt működik.

A példa az Aspose.Cells for .NET és az Aspose.Slides for .NET könyvtárakat igényli. Egy egyszerű oszlopdiagramot hoz létre az aktív diagramlapon, és beágyazza a munkafüzetet XLS formátumban. Nem kerül diagram előnézeti kép hozzárendelésre; a diagram akkor válik láthatóvá, amikor az OLE-objektum aktiválódik a PowerPointban.

A példa egy új prezentációt hoz létre, amely egy 9,5 × 4 hüvelykes OLE-keretet tartalmaz, amely 0,5 hüvelyk távolságra van a bal széltől és 1 hüvelykre a tetejétől. A diák koordinátái és méretei pontban vannak megadva (72 pont per hüvelyk). Egy meglévő prezentáció esetén lásd a [Sablon használata](#use-a-template) részt.

## **Rögzített diagramméret beállítása**

Állítsa a [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) értékét false-ra, hogy a diagram méretei függetlenek legyenek a munkafüzet ablakától. A [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) méreteit a [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) és a [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/) segítségével állítsa be, pontot pixellel átváltva 96 pixel per hüvelyk használatával: egy 684 × 288 pont méretű keret 912 × 384 pixel méretű diagramnak felel meg. Állítsa a [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) értékét a [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/) Custom értékére. A példa a munkafüzetet a [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) segítségével ágyazza be, és egy 9,5 × 4 hüvelykes OLE-kerettel menti a prezentációt.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// A dia koordinátái és méretei pontban vannak (72 pont per hüvelyk).
var width = 684f; // 9,5 hüvelyk.
var height = 288f; // 4 hüvelyk.

chart.SizeWithWindow = false;
// Konvertálja a pontokat diagrampixelé 96 pixel per hüvelyk használatával.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Sablon használata**

A méretezési logika megegyezik egy meglévő prezentáció esetén is. A példa adaptálásához:

1. Töltse be a sablonprezentációt az üres prezentáció létrehozása helyett.
2. Ellenőrizze, hogy az első dia legalább három alakzatot tartalmaz-e, majd használja a 2. indexű alakzatot helykitöltőként.
3. Vegye a keret szélességét és magasságát az alakzatról a rögzített 684 és 288 értékek helyett. Tartsa változatlanul a méretezési számításokat.
4. Adja hozzá az OLE-keretet a helykitöltő pozíciójához a rögzített 36 és 72 koordináták helyett.
5. Távolítsa el a helykitöltőt a prezentáció mentése előtt.

## **GYIK**

**Miért változik meg a beágyazott Excel-diagram mérete a PowerPointban történő aktiválás után?**

Ez azért történik, mert az Excel az első aktiváláskor megpróbálja visszaállítani az eredeti ablakméretet, míg a PowerPointban az OLE-objektumkeret saját méretekkel rendelkezik. A PowerPoint és az Excel egyeztetik a méretet az arány megtartása érdekében, ami az átméretezést okozhat.

**Hogyan tarthatom konzisztensnek a diagram és az OLE-keret méreteit?**

Állítson be rögzített diagramméreteket, amelyek megegyeznek az OLE-kerettel, és használjon egy egyedi diagramnyomtatási méretet a munkafüzet beágyazása előtt. A fenti példa mutatja a szükséges beállításokat és egységkonverziókat.

**Elégséges-e a munkafüzet ablakméretének egyeztetése?**

A munkafüzet ablakméretének egyedülálló egyeztetése nem biztos, hogy megbízhatóan megakadályozza az OLE-keret méretének változását aktiválás után. Használjon rögzített diagramméreteket, ahogy a példában látható.

**Működik ez a megoldás sablonalapú és új prezentációk esetén egyaránt?**

Igen. Sablonnál a helykitöltő méreteit és pozícióját használja. Új prezentáció esetén a keret méreteit és pozícióját adja meg közvetlenül.

**Használhatom ezt a példát más táblázatkezelő programokban létrehozott diagramokkal?**

A példa egy Aspose.Cells által létrehozott Excel-munkafüzetet használ. Nem mutatja be más táblázatkezelő programok aktiválási viselkedését.

## **Kapcsolódó szakaszok**

- [Excel-diagramok létrehozása és OLE objektumként beágyazása a prezentációkba](/slides/hu/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE-objektumok automatikus frissítése PowerPoint kiegészítővel](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)