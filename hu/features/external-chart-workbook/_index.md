---
title: Diagramok összekapcsolása külső munkafüzettel
description: Diagramadatok összekapcsolása egy külső munkafüzettel és annak frissítése.
type: docs
url: /hu/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Áttekintés**

Állítsa be a diagramot egy külső munkafüzetre, ahelyett, hogy az összes forrásadatot a prezentációba ágyazná. Megadhatja a munkafüzet útvonalát, és kiválaszthatja, hogy a diagramot frissítse‑e a fájlból. A mentett diagram tárolhatja a gyorsítótárazott megjelenítési adatokat is.

## **Használati példa**

Ez a C# példa az Aspose.Slides for .NET-et használja. Hozzon létre egy érvényes értékesítési munkafüzetet, ahol Észak = 55 és Dél = 40, és írja azt sales.xlsx néven a kimenet mellé. Állítsa vissza a diagram Észak értékét 20‑ra, majd kapcsolja a diagramot a munkafüzet abszolút útvonalához, és frissítse: az Észak újra 55 lesz. Az explicit tartomány magában foglalja a fejléccel és két adat sorral. Tartsa elérhetőnek a sales.xlsx fájlt a diagram újranyitásakor vagy frissítésekor; a prezentáció nem ágyazza be ezt a külső fájlt. Bemeneti fájlra nincs szükség. Mentésre kerül a *external-chart-workbook.pptx* és a *external-chart-workbook.png*. Telepítse a könyvtárat a [telepítési útmutató](/slides/hu/net/installation/) segítségével.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **GYIK**

### **Olvashatom minden gyorsítótárazott értéket, ha a kapcsolt fájl hiányzik?**

Az Aspose.Slides for .NET 26.11 [közvetlenül beolvasni a tárolt diagramértékeket](/slides/hu/net/chart-workbook/#read-cached-chart-values-without-a-workbook) tud anélkül, hogy megnyitná a kapcsolt munkafüzetet. Ez magában foglalja a szokásos értékeket, X/Y értékeket, buborékméreteket és kategóriaértékeket, ha ezek a gyorsítótárak léteznek. A gyorsítótárazott adatok hiányozhatnak vagy elavulhatnak; nem egy teljes munkafüzetről van szó. A forrásból való frissítés továbbra is egy elérhető támogatott munkafüzetet igényel. Más SDK‑k és verziók esetén nézze meg a megfelelő diagram útmutatót.

### **Mi történik, ha a külső munkafüzetet áthelyezik?**

Frissítse a diagram külső munkafüzetének útvonalát az új helyére, és tegye a fájlt elérhetővé, ahol a prezentációt feldolgozzák. Ne támaszkodjon a gyorsítótárazott adatokra teljes adatlekérdezési műveletekhez, ha azok hiányoznak.

### **Választhatok, hogy frissítsem‑e a gyorsítótárazott diagramadatokat a hivatkozáskor?**

Igen. Választhatja, hogy a hivatkozás beállításakor frissíti‑e a diagram adatait. A frissítéshez egy elérhető támogatott munkafüzet szükséges; a frissítés kihagyása csak a hivatkozást rögzíti, anélkül, hogy az új értékeket a fájlból beolvasná.

## **Útmutatók**

- [Kezelje a diagram munkafüzeteket a .NET prezentációkban](/slides/hu/net/chart-workbook/)

Kapcsolódó funkció: [Kitölthető diagramok adatfűzéssel](/slides/hu/features/chart-data-binding/).