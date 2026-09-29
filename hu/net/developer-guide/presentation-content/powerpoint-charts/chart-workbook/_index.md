---
title: Diagrammunkafüzetek kezelése prezentációkban .NET-ben
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/net/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET-et: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációs adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell a diagrammunkafüzetekkel dolgozni az Aspose.Slides-ban. Megmutatja, hogyan lehet a diagram adatait olvasni és írni munkafüzet adatfolyamok segítségével, hogyan használhatók a munkafüzet cellák diagram adatcímkeként, hogyan férhetünk hozzá a munkalapgyűjteményekhez, és hogyan adhatjuk meg az adatforrás típusát a diagram értékekhez.

Továbbá tárgyalja a külső munkafüzetek diagram adatforrásként történő használatát. A példák bemutatják, hogyan hozzunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan szerezzük meg egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesszük a diagram adatait, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzetcellákhoz lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/net/chart-series/) útmutatót, ahol megtudhatod az üres cella és a nulla közti különbséget, valamint a vonaldiagram összehasonlítását a különböző megjelenítési üzemmódok között.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használd az [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) beállítást annak szabályozására, hogy a diagram a rejtett munkalapsorok és -oszlopok adatait ábrázolja-e. Állítsd `true`-ra, ha csak a látható cellákat szeretnéd ábrázolni, vagy `false`-ra, ha a látható és rejtett cellákat egyaránt bele akarod foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

Töltsd le a [hidden-source-data.pptx](hidden-source-data.pptx) fájlt, és helyezd el a munkakönyvtárban. Első diáján egy oszlopdiagram található első alakzatként. A beágyazott munkalap, `Sheet1`, a következő forrásintervallumot tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forráscellák eléréséhez használd a [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/chartdataworkbook/) tulajdonságot, és olvasd a [IChartDataCell.IsHidden](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatacell/ishidden/) értékét a rejtett státusz vizsgálatához. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa a `False`, `True` és `True` értékeket írja ki megfelelően.

Ehhez a példához frissítsd a diagram adatát a ábrázolási beállítás módosítása után: tartsd meg a beágyazott munkafüzetet a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/readworkbookstream/) segítségével, majd töltsd be újra a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/writeworkbookstream/) használatával. Ha az összes cellát bele akarod foglalni, használd a [SetRange](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/setrange/) metódust is, hogy visszaállítsd a teljes tartományt, beleértve a rejtett februári kategóriát is. Csak a zászló megváltoztatása nem elegendő a mintában tárolt gyorsítótárazott diagramadatok és kategóriacímkék frissítéséhez.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // Frissítse a diagram adatát a beágyazott munkafüzetből.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Állítsa vissza a teljes forrásintervallumot, beleértve a rejtett kategóriákat.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

A példa a `hidden_cells_True.pptx` fájlt csak a látható Kiskereskedelem értékekkel (10 és 20) menti, míg a `hidden_cells_False.pptx` a hat összes értéket tartalmazza. Az alábbi képek a mentett prezentációk újra megnyitása után lettek renderelve; mindkét fájl megőrzi a hozzárendelt ábrázolási beállítást. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Összes cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Összes cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értékkel rendelkező rejtett cella különbözik az üres cellától. Az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/displayblanksas/) vezérli, hogyan jelennek meg a hiányzó értékek; ez nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/net/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adatok olvasása és írása munkafüzetből**

Az Aspose.Slides for .NET biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagramadat-munkafüzetek (Aspose.Cells‑szel szerkesztett diagramadatok) olvasását és írását. **Megjegyzés:** a diagramadatokat ugyanúgy kell szervezni, vagy hasonló szerkezettel kell rendelkezniük, mint a forrás.

Ez a példa megnyitja a `chart.pptx` fájlt, amelynek első diáján első alakzatként diagramnak kell lennie. Beolvassa a beágyazott munkafüzetet egy adatfolyamba, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A módosítások memóriában maradnak; a példa nem menti a prezentációt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosított változattal cserélsz le, a diagram megtartja az eredeti sorozat- és kategóriagyűjteményeit. Ez a nem egyezés az [IChart.ValidateChartLayout](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/validatechartlayout/) metódus hibáját okozhat index‑out‑of‑range kivétellel. Töröld a meglévő sorozatokat és kategóriákat, mielőtt visszaírnád a frissített munkafüzetet a diagramra. Ehhez a példához szükség van egy `chart.pptx` fájlra, amelynek első diáján első alakzatként diagramnak kell lennie. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa az eredeti munkafüzetet írja vissza, és memóriában ellenőrzi az elrendezést.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // Módosítsa itt a munkafüzet adatfolyamot, például az Aspose.Cells használatával.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

A gyűjtemények törlése eltávolítja a régi adatreferenciákat, mielőtt a munkafüzet visszaírásra kerül. Újraépítheted a szükséges sorozat‑ és kategóriatérképeket a frissített munkafüzethez, mielőtt a diagramot használod.

## **Munkafüzet cella beállítása diagram adatcímkeként**

Szöveget használhatsz a munkafüzet celláiból diagram adatcímkeként. Az alábbi lépések bemutatják, hogyan kapcsoljuk össze a felhődiagram címkéit a munkafüzet celláival.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Érd el az első diát a nulla‑alapú indexével.  
1. Adj hozzá egy felhődiagramot alapértelmezett adatokkal.  
1. Érd el a diagram sorozatát.  
1. Állítsd be a munkafüzet cellát adatcímkeként.  
1. Mentsd el a prezentációt.

Ez a példa megnyitja a `chart2.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, majd egy felhődiagramot ad hozzá alapértelmezett adatokkal. Az első sorozat első három címkéjét a 0‑ás munkalap A10:A12 cellái szolgáltatják, engedélyezi a cellákból származó címkéket, és a `resultchart.pptx` fájlba menti az eredményt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **Munkalapok kezelése**

Az [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdataworkbook/worksheets/) tulajdonság hozzáférést biztosít a diagram munkafüzetében lévő munkalapokhoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **Adatforrás típusának meghatározása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnévet állít be különböző adatforrásokból. Az első név egy karakterlánc‑literál, a második a 0‑ás munkalap C1 cellájából származik. A [DataSourceType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/datasourcetype/) felsorolt típusával adhatod meg az egyes nevek forrását. Az eredményt a `pres.pptx` fájlba menti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **Nem támogatott beágyazott munkafüzetformátumok felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzettel (.xlsb) formátumot, amely bizonyos diagramokba beágyazható. Használd az [EmbeddedWorkbookType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) tulajdonságot az [IChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/) esetén a [WorkbookType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/workbooktype/) felsorolással együtt, hogy felismerd a nem támogatott formátumokat és kihagyd az adott diagramokat. Ez a példa megvizsgálja a `sample.pptx` első diáján található alakzatokat, kihagyja a nem diagram alakzatokat, és diagnosztikai üzenetet ír ki minden olyan diagramra, amely beágyazott .xlsb munkafüzettel rendelkezik.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Olvassa vagy módosítsa a támogatott diagram munkafüzet adatokat itt.
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használd a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [SetExternalWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódusokat egy beágyazott diagrammunkafüzet exportálásához fájlba, majd a diagram összekapcsolásához ezzel a külső munkafüzettel.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, a munkafüzetet az `externalWorkbook1.xlsx` fájlba írja, majd a kimeneti adatfolyamot bezárja, mielőtt a fájlt a diagram adatforrásaként hozzárendeli. A kapcsolt prezentációt az `externalWorkbook.pptx` fájlba menti.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **Külső munkafüzet beállítása**

A [SetExternalWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódussal egy külső munkafüzetet rendelhetsz diagramhoz adatforrásként. Ezzel a módszerrel frissítheted a külső munkafüzet elérési útját is (ha az áthelyezésre került).

Bár távoli helyeken vagy erőforrásokban tárolt munkafüzeteket nem szerkesztheted, továbbra is használhatók külső adatforrásként. Relatív útvonal megadása esetén az automatikusan teljes útra konvertálódik.

Ez a példa egy `externalWorkbook.xlsx` fájlt igényel a munkakönyvtárban. A `Sheet1` munkalapnak tartalmaznia kell egy sorozatnevet a B1‑ben, kategórianéveket az A2:A4‑ben, valamint numerikus értékeket a B2:B4‑ben. A példa egy kördiagramot hoz létre, kapcsolja a munkafüzetet, majd a [SetRange](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/setrange/) metódussal az A1:B4 tartományt egy sorozatra és három kategóriára térképezi fel. Az eredményt a `Presentation_with_externalWorkbook.pptx` fájlba menti.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

A [SetExternalWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑e töltve.

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagram adatai nem töltődnek be vagy frissülnek a célmunkafüzettel, így a munkafüzet elérhetetlen is lehet.
* Ha `updateChartData` **true**, a diagram adatai frissülnek a célmunkafüzettel.

Az alábbi példa egy helyettesítő URL‑t ad meg `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt úgy menti, hogy a nem elérhető munkafüzetet nem tölti be.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **Diagram külső adatforrás munkafüzet útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához először ellenőrizd, hogy a diagram külső adatforrást használ‑e. Ha igen, a következő lépések szerint szerezheted meg a munkafüzet útvonalát.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Érd el az első diát a nulla‑alapú indexével.  
1. Ellenőrizd, hogy az első alakzat diagram‑e.  
1. Olvasd ki a diagram adatforrás típusát.  
1. Ha a forrás külső munkafüzet, olvasd ki az útvonalát.

Ez a példa megnyitja a `externalWorkbook.pptx` fájlt, amelyet az előző példában hoztunk létre, és ellenőrzi az első dián az első alakzatot. Ha az egy diagram, amely külső munkafüzettel van összekapcsolva, a példa a [ExternalWorkbookPath](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/externalworkbookpath/) értékét írja ki a konzolra. Ezután a prezentáció egy másolatát a `Result.pptx` fájlba menti.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **Diagram adatainak szerkesztése**

A külső munkafüzettel ugyanúgy szerkesztheted az adatokat, mint a belső munkafüzetek esetén. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy `presentation.pptx` fájlt igényel, amelynek első diáján első alakzatként diagramnak kell lennie, valamint egy elérhető külső munkafüzettel. A példában az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd a prezentációt a `presentation_out.pptx` fájlba menti. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért ha az eredeti munkafüzetet meg akarod őrizni, használj másolatot.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides képes a diagram munkafüzetét a prezentáció gyorsítótárában tárolt adatokból rekonstruálni. Hozz létre egy [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) objektumot, állítsd be a [SpreadsheetOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/spreadsheetoptions/) részt, és a [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) értékét **true**‑ra állítsd, mielőtt megnyitnád a prezentációt.

Az alábbi C# példa megnyitja a `presentation.pptx` fájlt, amelynek első diáján első alakzatként egy olyan diagramnak kell lennie, amely egy nem elérhető külső munkafüzetre hivatkozik, majd a helyreállított adatokat a [IChart.ChartData](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichart/chartdata/) és a [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével érheti el:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // Olvassa vagy módosítsa a helyreállított munkafüzet adatokat itt.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides egy [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) kivételt dob. Engedélyezd a helyreállítást csak akkor, ha a gyorsítótárban lévő diagramadatok használata elfogadható alternatíva, mert a gyorsítótár nem tartalmazhatja a külső munkafüzetben a legutóbbi frissítések után végzett módosításokat.

## **GYIK**

**Meg tudom állapítani, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e kapcsolva?**

Igen. A diagramnek van egy [adatforrás típusa](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [útvonal a külső munkafüzethez](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/); ha a forrás külső munkafüzet, kiolvashatod a teljes útvonalat, hogy megbizonyosodj arról, hogy egy külső fájlt használsz.

**Támogatottak a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat adsz meg, az automatikusan átalakul abszolút úttá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatók hálózati erőforrásokon/megosztott helyeken lévő munkafüzetek?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chartdata/externalworkbookpath/). A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Használj másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a kapcsolódáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy visszafejtett másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/net/) segítségével), majd a másolatra való hivatkozás.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mind ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramnál megjelenik.