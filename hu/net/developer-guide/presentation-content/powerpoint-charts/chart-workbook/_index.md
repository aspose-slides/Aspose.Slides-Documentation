---
title: Diagrammunkafüzetek kezelése prezentációkban .NET-ben
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/net/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
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
description: "Fedezze fel az Aspose.Slides for .NET-et: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagrammunkafüzetekkel dolgozni az Aspose.Slides‑ben. Ismerteti, hogyan olvassuk és írjuk a diagramadatokat munkafüzet‑folyamok segítségével, hogyan használjuk a munkafüzet‑cellákat diagramcímkeként, hogyan érjük el a munkalap‑gyűjteményeket, valamint hogyan adhatjuk meg az adatforrás‑típust a diagramértékekhez.

Továbbá tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák megmutatják, hogyan hozzunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan szerezzük meg egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesszük a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet‑cellákkal kapcsolatban lásd a [Control the Display of Empty Cells](/slides/hu/net/chart-series/) cikket, amely ismerteti a különbséget az üres cella és a nulla között, valamint egy vonaldiagram‑összehasonlítást a lehetséges megjelenítési módokról.

## **Adatok felvétele rejtett sorokból és oszlopokból**

Használja az [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) tulajdonságot annak szabályozására, hogy a diagram csak a látható munkalap‑sorokból és -oszlopokból származó adatokat ábrázolja-e. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és a rejtett cellákat egyaránt bele akarja foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap‑sorokat vagy -oszlopokat.

A [sample presentation](hidden-source-data.pptx) első diáján található egy oszlopdiagram, ami az első alakzat. A beágyazott munkalap, a `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forrás‑cellák eléréséhez használja az [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) függvényt, és olvassa ki az [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) tulajdonságot a rejtett állapotuk ellenőrzéséhez. Ez a tulajdonság csak olvasható. Ebben a példában a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa ennek megfelelően `False`, `True`, `True` értékeket ír ki.

Ehhez a példához frissítse a diagramadatokat a ábrázolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) segítségével, majd töltse be újra a [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) használatával. Az összes cella felvételekor használja a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) függvényt a teljes tartomány, köztük a rejtett februári kategória visszaállításához. Csak a jelző módosítása nem elegendő a mintában tárolt diagramadatok és kategóriacímkék frissítéséhez.

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

        // Frissítse a diagram adatait a beágyazott munkafüzetből.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Állítsa vissza a teljes forrás tartományt, beleértve a rejtett kategóriákat.
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

A példa két verziót ment a prezentációból: egyet, amely csak a látható Kiskereskedelem‑értékeket (10 és 20) tartalmazza, és egyet, amely az összes hat értéket tartalmazza. Az alábbi képek a mentett prezentációk újra‑megnyitása után lettek renderelve; mindkét fájl megőrzi a beállított ábrázolási módot. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Összes cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Összes cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

A rejtett, értékkel bíró cella különbözik egy üres cellától. Az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Control the Display of Empty Cells](/slides/hu/net/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat‑tartományának lekérése**

Mielőtt módosítaná a munkafüzet adatokat egy meglévő prezentációban, ellenőrizze a forrás‑tartományokat, hogy megtudja, mely munkalap‑cellákat használja egy-egy diagram. Az [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) metódus visszaadja a jelenlegi adat‑tartományt egy munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli, mindkettő abszolút hivatkozással.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, a metódus [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) kivételt dob. További információk a [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) oldalon találhatók.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi az alakzatokat a diagramok után. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, egy üzenetet jelenít meg, és folytatja a következő diagrammal.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **Diagramadatok olvasása és írása munkafüzettel**

Az Aspose.Slides for .NET a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) és [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat biztosítja, amelyekkel olvashat és írhat diagramadat‑munkafüzeteket (amelyek Aspose.Cells‑szel szerkesztett diagramadatokat tartalmaznak). **Megjegyzés:** a diagramadatoknak ugyanúgy vagy hasonló szerkezetben kell felépülniük, mint a forrás.

Ez a példa egy olyan prezentációt használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzetet egy folyamba, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változások memóriában maradnak; a példa nem menti el a prezentációt.

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

### **Diagramelrendezés ellenőrzése munkafüzet‑módosítás után**

Ha egy beágyazott munkafüzetet egy módosítottval helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeket. Ez az eltérés a [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) meghívásakor index‑out‑of‑range hibát okozhat. Írja ki a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés azt mutatja, hol történne a munkafűzet‑szerkesztés; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

    // Módosítsa itt a munkafüzet folyamatot, például az Aspose.Cells használatával.

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

A gyűjtemények törlése megszünteti a régi adat‑referenciákat, mielőtt a munkafüzet visszaíródik. Építse újból a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Munkafüzet‑cellát diagramcímkének beállítása**

A munkafüzet‑cellák szövegét felhasználhatja diagramcímkékként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. A 0‑számú munkalap A10:A12 tartományát használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, majd menti a frissített prezentációt.

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

Az [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) tulajdonság hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, és minden munkalap nevét kiírja a konzolra.

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

## **Az adatforrás típusának meghatározása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat nevet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál, a második a 0‑számú munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) felsorolás választja ki az egyes nevek forrását. A példa menti a prezentációt a frissített sorozatnevekkel.

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

## **Nem támogatott beágyazott munkafüzet‑formátumok felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amely néhány diagramhoz beágyazható. A [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) tulajdonságot használva az [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) együtt a [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) felsorolással, fel tudja ismerni a nem támogatott formátumokat, és kihagyhatja azokat a diagramokat. Ez a példa a meglévő prezentáció első diájának alakzatait vizsgálja, a nem‑diagram alakzatokat kihagyja, és diagnosztikai üzenetet ír ki minden .xlsb munkafüzetet beágyazó diagramra.

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

    // Olvassa vagy módosítsa itt a támogatott diagrammunkafüzet adatokat.
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramadat‑forrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) és [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódusokat egy beágyazott diagrammunkafüzet exportálásához fájlba, majd a diagramot ehhez a külső munkafüzethez kapcsolja.

Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, és exportálja a munkafüzetét. A kimeneti folyamatot a külső munkafüzet diagramadat‑forrásként történő hozzárendelése előtt zárja le, majd menti a kapcsolt prezentációt.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódussal egy külső munkafüzetet rendelhet diagramhoz adatforrásként. Ezzel a metódussal a külső munkafüzet útvonalát is frissítheti (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem lehet közvetlenül szerkeszteni, továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapján a B1 cella egy sorozatnevet, az A2:A4 cellák kategórianévként, a B2:B4 cellák pedig numerikus értékekként vannak definiálva. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) segítségével az A1:B4 tartományt egy sorozatra és három kategóriára leképezi. A prezentációt a kapcsolt diagrammal menti.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) `updateChartData` paramétere azt határozza meg, hogy a munkafüzet betöltődjön‑e.

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be vagy frissülnek a célmunkafüzetből, így a munkafüzet hiányozhat.
* Ha `updateChartData` **true**, a diagramadatok a célmunkafüzettel frissülnek.

A következő példa egy helyőrző URL‑t ad meg, a `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt a nem betöltött munkafüzet nélkül menti.

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

### **Diagram külső adatforrás‑munkafüzetének útvonalának lekérése**

Azonosítani a diagramhoz kapcsolt munkafüzetet a következőképpen: ellenőrizze, hogy a diagram külső adatforrást használ‑e, majd szerezze be a munkafüzet útvonalát.

Ez a példa a prezentáció első diájának első alakzatát vizsgálja, ahol egy külső munkafüzethez kapcsolt diagram van. Ha ilyen diagramot talál, a [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) értékét kiírja a konzolra, majd elment egy másolatot a prezentációról.

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

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzethez van kapcsolva. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd menti a frissített prezentációt. A cella‑értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg akarja őrizni.

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes a diagram munkafüzetet rekonstruálni a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) objektumot, konfigurálja a [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) tulajdonságait, és állítsa az [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) értékét **true**‑ra a prezentáció megnyitása előtt.

Az alábbi C# példa helyreállítja a munkafüzet‑adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzetre hivatkozik. A helyreállított adatokat a [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) és az [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével érheti el:

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

    // Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) kivételt dob. A helyreállítást csak akkor engedélyezze, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék megoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció utolsó frissítése óta végrehajtott módosításokat.

## **GYIK**

**Meg tudom állapítani, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) tulajdonsággal; ha a forrás külső munkafüzet, a teljes útvonal beolvasásával ellenőrizhető, hogy külső fájlt használ-e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonallá alakul. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatók hálózati erőforrásokon/megosztókon lévő munkafüzetek?**

Igen, az ilyen munkafüzetek külső adatforrásként használhatók. A távoli munkafüzetek közvetlen szerkesztése azonban nem támogatott – csak forrásként szolgálhatnak.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) tárolja. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Ha az eredetit változatlanul kell hagyni, használjon másolatot a munkafüzetről.

**Mi a teendő, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a kapcsolódáskor. Általános megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy dekódolt másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/net/) segítségével) készít, majd ahhoz kapcsolódik.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramra hatással lesz a következő adatbetöltéskor.