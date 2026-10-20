---
title: Excel diagramok létrehozása és beágyazása prezentációkba OLE objektumként
type: docs
weight: 50
url: /hu/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel diagram
- diagram beágyazása
- OLE objektum
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Excel diagram létrehozása Aspose.Cells for .NET használatával és a munkafüzet beágyazása PowerPoint prezentációba Aspose.Slides segítségével, diagram előnézettel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre oszlopdiagramot Excelben az Aspose.Cells for .NET segítségével, és ágyazhatja be a munkafüzetet egy PowerPoint bemutatóba az Aspose.Slides for .NET segítségével. A beágyazott munkafüzet tartalmazza a forrásadatokat és a diagramot is. Egy külön PNG előnézet jeleníti meg a diagramot a dián, mielőtt az OLE objektum aktiválódna. Az eredmény egy beágyazott Excel objektum, nem natív PowerPoint diagram. A munkafüzet OLE‑on keresztüli szerkesztéséhez olyan asztali alkalmazás szükséges, amely támogatja az OLE aktiválást és kompatibilis Excel telepítéssel rendelkezik.

## **Előfeltételek**

Adjon hozzá hivatkozásokat az Aspose.Cells for .NET és az Aspose.Slides for .NET könyvtárakhoz a C# projektjében. A példában felső szintű utasítások (top-level statements) vannak használva, és C# 9 vagy újabb szükséges. A Microsoft Office nem szükséges a bemutató generálásához ezekkel a könyvtárakkal. Nem szükséges bemeneti fájl: a példa a memóriában hozza létre az adatokat és a diagramot, majd a `OutputChart.pptx` fájlt a jelenlegi munkakönyvtárba írja. Licencet kell alkalmazni mindkét termékre, ha értékelő módból kívül futtatja.

## **Hogyan Működik a Beágyazás**

1. Hozzon létre egy munkafüzetet egy adat munkalappal és egy diagramlapra.  
1. Tegye a diagramlapot aktívvá, hogy a munkafüzet a diagramon nyíljon meg.  
1. Állítsa be a munkafüzet OLE megjelenítési tartományát, és renderelje a diagramot PNG‑re.  
1. Mentse a munkafüzetet XLSX formátumban a memóriába, és ágyazza be ezeket a bájtokat egy diára.  
1. Állítsa be a PNG‑t az OLE objektum előnézeteként, és mentse a bemutatót PPTX‑ként.  

A munkafüzet megjelenítési tartománya és a dián lévő keret különböző szerepeket töltenek be. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) nulláról induló kezdő/észső sor- és oszlopindexeket vár. A [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) ezzel szemben a felső sor, bal oszlop, alsó sor és jobb oszlop értékét veszi. A példa a 55‑ös sorindexet és a 25‑ös oszlopindexet használja alsó‑jobb határként; ezek az értékek elrendezési választások, nem az adatsorok vagy oszlopok számát jelentik.  

A diakeret pontokban van megadva. A példa a dián belül elhelyezi és középre helyezi, miközben megtartja a PNG képarányát, ahelyett, hogy az előnézetet a dia teljes kitöltésére nyújtaná.

## **Diagram Létrehozása és Beágyazása**

Az alábbi teljes példa a `DataSheet`‑et négy sorral és öt oszloppal tölti fel értékekkel. Minden sor egy diagram sorozattá válik. A `ChartSheet` van kiválasztva aktív lapon, mielőtt a munkafüzet mentésre kerül.  

A munkafüzet kifejezetten XLSX‑ként van mentve, amely egyezik a `xlsx` kiterjesztéssel, amelyet a [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) kap. A PNG közvetlenül a folyamatából van betöltve, anélkül, hogy köztes bitmap konverzióra lenne szükség. A [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) segítségével történő hozzárendelés felülírja az alapértelmezett OLE helyőrzőt.  

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// A diagram előnézetet rendereli, és külön menti a szerkeszthető munkafüzetet.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Az előnézetet a dián belül elhelyezi a képarány megváltoztatása nélkül.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Várható Eredmény**

A `OutputChart.pptx` egy diát tartalmaz, amely beágyazott Excel munkafüzettel és egy diagram előnézettel rendelkezik. A munkafüzet az eredeti adatokat és egy négy sorozatú oszlopdiagramot tartalmaz. Az előnézet a dián középre van helyezve, és megtartja arányait.  

![Excel oszlopdiagram, amely beágyazott munkafüzet előnézeteként jelenik meg](excel-chart-ole-preview.png)  

Kompatibilis asztali PowerPoint környezetben, ahol az Excel elérhető, duplán kattintson az objektumra az aktiváláshoz és a beágyazott munkafüzet szerkesztéséhez. Az aktiválás és a szerkesztés a gazda alkalmazás OLE‑támogatásától és biztonsági beállításaitól függ.  

## **GYIK**

**Miért szükséges előnézeti kép?**  
A beágyazott munkafüzet és a dián lévő előnézet különálló tartalom. Adj meg egy diagramképet, így a dia a diagramot jeleníti meg az alapértelmezett "EMBEDDED OLE OBJECT" helyőrző helyett. Lásd a [Object Preview Issue when Adding OleObjectFrame](/slides/hu/net/object-preview-issue-when-adding-oleobjectframe/).  

**Frissül automatikusan az előnézet, ha a kódban módosítom a munkafüzetet?**  
Kezeld az előnézetet egy pillanatképként. Ha programozottan frissíted a munkafüzet adatait, újból generáld a diagramképet, és cseréld le az előnézetet, valamint a beágyazott munkafüzet adatát.  

**Használhatok XLS‑et XLSX helyett?**  
Igen. Mentse a munkafüzetet XLS formátumban, és használja az `xls` kiterjesztést a beágyazott adatként. A kiterjesztésnek meg kell egyeznie a tényleges munkafüzet formátummal; csak a kiterjesztés megváltoztatása nem konvertálja az adatot.  

**Miért változhat meg az objektum mérete aktiválás után?**  
A gazda alkalmazás frissítheti az OLE objektum megjelenését, amikor aktiválja a munkafüzetet. A munkafüzet OLE megjelenítési tartománya és a diakeret méretei egyaránt fontosak. Lásd a [Working Solution for Chart Resizing in PPTX](/slides/hu/net/working-solution-for-chart-resizing-in-pptx/).  

## **Kapcsolódó szakaszok**

- [Working Solution for Chart Resizing in PPTX](/slides/hu/net/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/hu/net/object-preview-issue-when-adding-oleobjectframe/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)