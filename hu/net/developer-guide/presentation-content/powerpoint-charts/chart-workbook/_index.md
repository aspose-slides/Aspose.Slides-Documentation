---
title: Ábrák munkafüzeteinek kezelése prezentációkban .NET-ben
linktitle: Ábra munkafüzet
type: docs
weight: 70
url: /hu/net/chart-workbook/
keywords:
- ábra munkafüzet
- ábra adat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- ábra gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET-et: egyszerűen kezelheti a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy optimalizálja prezentációja adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet dolgozni diagrammunkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan lehet olvasni és írni diagram adatokat munkafüzet adatfolyamok segítségével, hogyan lehet a munkafüzet cellákat diagram adatcímkeként használni, a munkalap gyűjteményekhez hozzáférni, és hogyan kell megadni az adatforrás típusát a diagram értékekhez.

Az is bemutatja, hogyan lehet külső munkafüzeteket használni diagram adatforrásként. A példák megmutatják, hogyan hozhatsz létre és rendelj hozzá egy külső munkafüzetet, hogyan kérdezheted le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkesztheted a diagram adatokat, ha a munkafüzet elérhető.

Hiányzó adatokat tartalmazó munkafüzetcellák esetén lásd a [Az Üres Cellák Megjelenítésének Szabályozása](/slides/hu/net/chart-series/) cikket, amely a különbséget mutatja az üres cella és a nulla között, valamint egy vonaldiagramon mutatja be a rendelkezésre álló megjelenítési módokat.

## **Rejtett Sorok és Oszlopok Adatainak Belefoglalása**

Használd a [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) metódust, hogy szabályozd, egy diagram megjelenítse-e a rejtett munkalap sorok és oszlopok adatait. Állítsd `true`-ra, ha csak a látható cellákat szeretnéd megjeleníteni, vagy `false`-ra, ha a látható és a rejtett cellákat is bele akarod foglalni. Ez a beállítás a diagram rajzolását befolyásolja; nem rejt el vagy jelenít meg munkalap sorokat vagy oszlopokat.

A [minta prezentáció](hidden-source-data.pptx) első diájának első alakzataként egy oszlopdiagramot tartalmaz. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt (`A1:C4`) tartalmazza. A 3. sor és a C oszlop rejtett, de celláik továbbra is értéket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (rejtett sor) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forráscellákat a [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével érheted el, és az [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) tulajdonságot olvasva ellenőrizheted a rejtett állapotukat. Ez a tulajdonság csak olvasható. Ebben a példában a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa sorban a `False`, `True` és `True` értékeket írja ki.

Ehhez a példához frissítened kell a diagram adatokat a beállítás megváltoztatása után: tartsd meg a beágyazott munkafüzetet a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) segítségével, és töltsd be újra a [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/)‑nel. Ha az összes cellát belefoglalod, használd a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) metódust is, hogy visszaállítsd a teljes tartományt, beleértve a rejtett februári kategóriát. Csak a zászló módosítása nem elég a minta gyorsítótárazott diagram adatainak és kategóriacímkéinek frissítéséhez.

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

        // Frissítse a diagram adatokat a beágyazott munkafüzetről.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Állítsa vissza a teljes forrástartományt, beleértve a rejtett kategóriákat.
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

A példa két verzióban menti a prezentációt: egyben csak a látható Kiskereskedelem értékek (10 és 20) szerepelnek, a másikban minden hat érték. Az alábbi képek a mentett prezentációk újranyitása után lettek renderelve; mindkét fájl megőrzi a hozzárendelt rajzolási beállítást. A 3. sor és a C oszlop a beágyazott munkafüzetekben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márcra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márcra.](hidden_cells_False.png) |

A rejtett, értéket tartalmazó cella különbözik az üres cellától. Az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) szabályozza, hogyan jelennek meg a hiányzó értékek; nem veszi fel vagy veti ki a rejtett forrásadatokat. További példáért lásd a [Az Üres Cellák Megjelenítésének Szabályozása](/slides/hu/net/chart-series/#control-the-display-of-empty-cells) cikket.

## **Diagram Adattartományának Lekérdezése**

Mielőtt egy meglévő prezentációban módosítanád a munkafüzet adatait, ellenőrizd a forrás‑tartományokat, hogy megtudd, mely munkalap‑cellákat használja az egyes diagramok. Az [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) metódus az aktuális adat‑tartományt adja vissza egy munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, és a `$A$1:$D$5` az A1‑től D5‑ig terjedő cellákat azonosítja, a `$` jel az abszolút sor‑ és oszlophivatkozásra utal.

A metódus a jelenlegi tartományt csak olvassa, anélkül, hogy módosítaná a diagramot vagy a munkafüzetét. Ha egy diagram nem használ munkafüzetet adatforrásként, [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) kivételt dob. További információkért lásd a [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi a alakzatokat, hogy vannak‑e diagramok. Kiírja minden diagram nevét és forrástartományát. Ha a diagram nem használ munkafüzetet, üzenetet ír ki, és a következő diagramra lép tovább.

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

## **Diagram Adatok Olvasása és Írása Munkafüzetből**

Az Aspose.Slides for .NET a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat biztosítja, amelyekkel a diagram adatokat tartalmazó munkafüzeteket (amelyek Aspose.Cells‑szel szerkesztett adatokat tartalmaznak) olvashatod és írhatod. **Megjegyzés**: a diagram adatokat ugyanolyan módon kell megszervezni, vagy hasonló felépítéssel kell rendelkezniük, mint a forrás.

Ez a példa egy olyan prezentációt használ, amelynek első diájának első alakzata egy diagram. Beolvassa a beágyazott munkafüzetet egy adatfolyamba, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A változtatások csak a memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagram Elrendezésének Ellenőrzése Munkafüzet Módosítása Után**

Ha egy beágyazott munkafüzetet egy módosított verzióval helyettesítesz, a diagram megőrzi az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem‑egyezés azt okozhatja, hogy az [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) index‑határon túli hibával hibázik. Töröld a meglévő sorozatokat és kategóriákat, mielőtt az új munkafüzetet visszaírnád a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés azt jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet és memóriában ellenőrzi az elrendezést.

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

A gyűjtemények törlése eltávolítja a már elavult adat‑hivatkozásokat, mielőtt a munkafüzet visszaírásra kerül. Az új munkafüzethez szükséges sorozat‑ és kategória‑leképezéseket újból fel kell építeni, mielőtt a diagramot használnád.

## **Egyéni Számformátumok Beállítása Munkafüzet Cellákhoz**

Használd a [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) metódust, hogy szabályozd, hogyan jelennek meg a numerikus értékek egy diagram beágyazott munkafüzetében. Például egy jelentéshez szükség lehet a konverziós arány százalékos, négy tizedesjegyű megjelenítésére, illetve egy együttható öt tizedesjegyű formátumra. Mindkét értéket numerikus formában tartsd, hogy a számítások és a diagramrajzolás során is elérhetők legyenek.

A számformátum csak a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; a tárolt szám nem lesz `12.5`. Hasonlóképpen a `0.00000` formátum a `0.1234567` értéket `0.12346`‑ként mutatja, anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) kerül felhasználásra.

Az alábbi példa egy oszlopdiagramot hoz létre, és a cellákat a [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével éri el. Az 0‑s munkalapon a B2 tartalmazza a konverziós arányt, a C2 pedig az együtthatót. Mindkét cella diagramértéket szolgáltat. A példa továbbá engedélyezi az értékcímkéket, amelyek a forrásformátumra hivatkoznak.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

A munkafüzet cellaformátumok különállóak a diagram tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás‑cellájának értékét jeleníti meg, mivel a [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) engedélyezve van, és a [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true`. A prezentáció mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy az alább látható. A függőleges tengely saját [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`‑t használ, a [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) pedig `false`.

Az adatcímke független formázásához állítsd a forrás‑hivatkozási zászlót `false`‑ra, és rendelj neki egy [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) értéket. Ez nem változtatja meg a munkafüzet cella formátumát. Például egy önálló `0.00` formátumú címke az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Diagram Adatcímkék](/slides/hu/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) szakaszt a közvetlen címkeformázáshoz.

![Oszlopdiagram forráshivatkozott címkékkel, amelyek 12.5000% és 0.12346 értékeket mutatnak, valamint önállóan formázott numerikus tengely.](custom-cell-formats.png)

## **Munkafüzet Cellát Diagram Adatcímkének Beállítása**

A munkafüzet cellákból származó szöveget használhatod diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal a meglévő prezentáció első diájához. Az 0‑s munkalapon az A10:A12 tartományt használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

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

## **Munkalapok Kezelése**

Az [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) tulajdonság biztosítja a hozzáférést a diagram munkafüzetének munkalapjaihoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét a konzolra írja.

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

## **Az Adatforrás Típusának Megadása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrások segítségével. Az első név egy szöveg‑literált használ, a második a 0‑s munkalap C1 celláját. A [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) felsorolás határozza meg a forrást minden névhez. A példa a frissített sorozatnevekkel menti a prezentációt.

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

## **Nem Támogatott Beágyazott Munkafüzet Formátumok Felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amely néhány diagramba beágyazható. A [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) tulajdonságot az [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/)‑nél a [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) felsorolással együtt használhatod a nem támogatott formátumok felismerésére és az ilyen diagramok kihagyására. Ez a példa az első dián lévő alakzatokat ellenőrzi, kihagyja a nem‑diagram alakzatokat, és minden .xlsb‑t beágyazott munkafüzettel rendelkező diagramhoz diagnosztikai üzenetet ír ki.

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

## **Külső Munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső Munkafüzet Létrehozása**

Használd a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódusokat egy beágyazott diagrammunkafüzet exportálásához fájlba, majd a diagram külső munkafüzethez való csatolásához.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja annak munkafüzetét. Az adatfolyamot a külső munkafüzet diagramadat‑forrásként való hozzárendelése előtt bezárja, majd menti a csatolt prezentációt.

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

### **Külső Munkafüzet Beállítása**

A [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódussal egy külső munkafüzetet rendelhetsz egy diagramhoz adatforrásként. Ezzel a metódussal a külső munkafüzet elérési útját is frissítheted (ha azt például áthelyezték).

Bár távoli helyen vagy erőforráson tárolt munkafüzetek adatait nem szerkesztheted, továbbra is használhatod ezeket külső adatforrásként. Ha relatív útvonalat adsz meg egy külső munkafüzethez, az automatikusan teljes útvonalra konvertálódik.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapja B1‑ben egy sorozat‑nevet, A2:A4‑ben kategória‑neveket, B2:B4‑ben pedig numerikus értékeket tartalmaz. A példa kördiagramot hoz létre, csatolja a munkafüzetet, és a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) segítségével az A1:B4 tartományt egy sorozatra és három kategóriára map‑olja. A diagramot a csatolással menti.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha az `updateChartData` **false**, csak a munkafüzet útvonalát frissíti. A diagram adat nem töltődik be vagy frissül a cél‑munkafüzetből, így a munkafüzet hiányzó is lehet.
* Ha az `updateChartData` **true**, a diagram adat frissül a cél‑munkafüzetből.

Az alábbi példa egy helyőrző URL‑t ad meg, az `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt anélkül menti, hogy betöltené a nem elérhető munkafüzetet.

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

### **Diagram Külső Adatforrás‑Munkafüzetének Útvonalának Lekérdezése**

A diagramhoz csatolt munkafüzet azonosításához ellenőrizd, hogy a diagram külső adatforrást használ‑e, és kérdezd le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot ellenőrzi, amely egy külső munkafüzethez csatolt diagram. Ha ez egy olyan diagram, amely külső munkafüzettel van összekapcsolva, a példa kiírja az [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) értékét a konzolra, majd ment egy másolatot a prezentációról.

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

### **Diagram Adatainak Szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheted, ahogy a belső munkafüzetekét is. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy olyan diagramot használ, amely az első dián az első alakzat, és elérhető külső munkafüzettel van összekapcsolva. Beállítja az első sorozat első adatpontjának cella‑alapú értékét 100‑ra, és menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a csatolt külső XLSX‑fájlt, ezért ha az eredeti munkafüzetet meg kell őrizned, használj másolatot.

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

### **Munkafüzet Visszaállítása a Diagram Gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes rekonstruálni a diagram munkafüzett a prezentációban gyorsítótárazott adatokból. Hozz létre egy [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) objektumot, állítsd be a [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) beállításait, és a [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) értékét `true`‑ra állítsd, mielőtt megnyitod a prezentációt.

Az alábbi C# példa visszaállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzetre hivatkozik. A visszaállított adatokat az [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) és az [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével érheted el:

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

    // Olvassa vagy módosítsa a visszaállított munkafüzet adatokat itt.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Ha a külső munkafüzet nem elérhető, és a helyreállítás le van tiltva, az Aspose.Slides [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) kivételt dob. Engedélyezd a helyreállítást csak akkor, ha a gyorsítótár‑alapú diagramadatok használata elfogadható megoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció utolsó mentése óta végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e csatolva?**

Igen. A diagramnek van egy [adatforrás típusa](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [útvonala egy külső munkafüzethez](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); ha a forrás egy külső munkafüzet, kiolvashatod a teljes útvonalat, hogy megbizonyosodj róla, hogy egy külső fájl van használatban.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat adsz meg, az automatikusan átalakul abszolút útvonallá. A prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban, ezért a munkafüzet áthelyezése esetén a hivatkozást frissíteni kell.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑fájlt a prezentáció mentésekor?**

A prezentáció egy [linket tárol a külső fájlhoz](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/). A cella‑alapú diagramadatok szerkesztése szintén frissítheti a csatolt helyi XLSX‑fájlt. Ha az eredeti munkafüzetet érintetlenül kell hagyni, használj másolatot.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Általános megoldás a védelem előzetes eltávolítása, vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/net/)‑szel), majd annak a másolatnak a csatolása.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagramnál érvényesül a következő adatbetöltéskor.