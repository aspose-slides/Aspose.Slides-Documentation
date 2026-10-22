---
title: Diagramm munkafüzetek kezelése prezentációkban .NET-ben
linktitle: Diagramm munkafüzet
type: docs
weight: 70
url: /hu/net/chart-workbook/
keywords:
- diagramm munkafüzet
- diagramm adatok
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagramm gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for .NET-et: könnyedén kezelje a diagramm munkafüzeteket a PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozzunk diagramm munkafüzetekkel az Aspose.Slides-ben. Bemutatja, hogyan olvassuk és írjuk a diagramm adatokat munkafüzet adatfolyamokon keresztül, hogyan használjuk a munkafüzet cellákat diagramm adatcímkeként, hogyan érjük el a munkalap-gyűjteményeket, és hogyan határozzuk meg az adatforrás típusát a diagramm értékekhez.

Emellett tárgyalja a külső munkafüzetek diagramm adatforrásként történő használatát. A példák bemutatják, hogyan hozzunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan szerezzük meg egy diagrammhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesszük a diagramm adatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet cellák esetén lásd [Üres cellák megjelenítésének szabályozása](/slides/hu/net/chart-series/) a üres cella és a nulla közötti különbségért, valamint egy vonaldiagram összehasonlítását a rendelkezésre álló megjelenítési módokkal.

## **Rejtett sorok és oszlopok adatainak bevonása**

Használja az [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) metódust annak szabályozására, hogy a diagramm elrejtett munkalap sorokból és oszlopokból vegye-e fel az adatokat. Állítsa true-ra, hogy csak a látható cellákat ábrázolja, vagy false-ra, hogy a látható és rejtett cellákat egyaránt vegye fel. Ez a beállítás a diagramm ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorokat vagy oszlopokat.

A [mintaprezentáció](hidden-source-data.pptx) tartalmaz egy oszlopdiagramot, mint első alakzatot az első dián. A beágyazott munkalap, `Sheet1`, a következő forrás tartományt tartalmazza, `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik továbbra is értékeket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

Érje el a forráscellákat az [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével, és olvassa a [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) tulajdonságot a rejtett állapotuk ellenőrzéséhez. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa `False`, `True`, és `True` értékeket ír ki.

Ehhez a példához frissítse a diagramm adatokat a megjelenítési beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) segítségével, és töltse be újra a [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) segítségével. Ha az összes cellát belefűzi, használja a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát. Az egyszerű zászló módosítása nem elegendő a minta gyorsítótárazott diagramm adatainak és kategória címkéinek frissítéséhez.

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

        // Frissítse a diagramm adatokat a beágyazott munkafüzetből.
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

A példa két verzióban menti a prezentációt: egyet csak a látható kiskereskedelmi értékekkel (10 és 20), a másikat az összes hat értékkel. Az alábbi képek a mentett prezentációk újra megnyitása után lettek renderelve; mindkét fájl megőrzi a beállított megjelenítési beállítást. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Az értéket tartalmazó rejtett cella különbözik az üres cellától. Az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) szabályozza, hogyan jelennek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Üres cellák megjelenítésének szabályozása](/slides/hu/net/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagramm adat-tartományának lekérése**

Mielőtt frissítené a munkafüzet adatokat egy meglévő prezentációban, ellenőrizze a forrás tartományokat, hogy mely munkalap cellákat használja egy diagramm. Az [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) metódus visszaadja a jelenlegi adat-tartományt munkalap‑képess képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig tartó cellákat jelöli. A dollárjelek abszolút sor és oszlop hivatkozásokat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagrammot vagy annak munkafüzetét. Ha a diagramm nem használ munkafüzetet adatforrásként, [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) dobódik. További információért lásd a [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/).

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi az alakzatokat diagrammok után. Kiírja minden diagramm nevét és forrás tartományát. Ha egy diagramm nem használ munkafüzetet, üzenetet ír ki és folytatja a következő diagrammmal.

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

## **Diagramm adatok olvasása és írása munkafüzetből**

Az Aspose.Slides for .NET biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagramm adat munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramm adatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramm adatoknak ugyanúgy kell felépülniük, vagy hasonló szerkezetűnek kell lenniük, mint a forrás.

Ez a példa egy prezentációt használ, amelynek első alakzata az első dián egy diagramm. Beolvassa a beágyazott munkafüzetet egy adatfolyamba, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változtatások memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagramm elrendezésének ellenőrzése munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet lecserél egy módosítottra, a diagramm megtartja az eredeti sorozat‑ és kategória‑gyűjteményeket. Ez a nem egyezés okozhatja, hogy az [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) hibát dob index‑túlhaladás miatt. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagrammba. Ez a példa egy diagrammot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet és memóriában ellenőrzi az elrendezést.

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

    // Módosítsa a munkafüzet adatfolyamot itt, például az Aspose.Cells használatával.

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

A gyűjtemények törlése eltávolítja a régi adat hivatkozásokat, mielőtt a munkafüzet visszaírásra kerül. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethoz, mielőtt a diagrammot használná.

## **Egyéni számformátumok beállítása munkafüzet cellákhoz**

A [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) segítségével szabályozhatja, hogyan jelenjenek meg a numerikus értékek egy diagramm beágyazott munkafüzetében. Például egy jelentésnek szüksége lehet egy konverziós rátára, amely százalékban van négy tizedes jeggyel, és egy együtthatóra, amely öt tizedes jegyet használ. Tartsa mindkét értéket numerikusként, hogy elérhetőek maradjanak a számításokhoz és a diagramm ábrázolásához.

Egy számformátum a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; nem cseréli le a tárolt számot `12.5`‑re. Hasonlóképpen, a `0.00000` a `0.1234567` értéket `0.12346`‑ként jeleníti meg a kerekítés nélküli tárolt érték megőrzésével. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) használatos helyette.

A következő példa egy oszlopdiagramot hoz létre és a cellákat a [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével érheti el. Az 0‑es munkalapon a B2 tartalmazza a konverziós rátát, a C2 pedig az együtthatót. Mindkét cella adja a diagramm értékeket. A példa továbbá engedélyezi az értékcímkéket, amelyek a forrás formátumához kapcsolódnak.

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

A munkafüzet cellaformátumok különböznek a diagramm tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás cella értékét jeleníti, mert a [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) engedélyezve van, és a forrás számformátumot követi, mivel a [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) `true`. A prezentáció mentése és újra megnyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy alább látszik. A függőleges tengely saját [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) `0.00`‑ot használ, az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) `false`‑ra állítva.

Egy adatcímke önálló formázásához állítsa a forrás‑kapcsolati jelzőt `false`‑ra, és adja meg a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/)‑t. Ez nem változtatja meg a munkafüzet cella formátumát. Például egy önálló címke `0.00` formátuma az első értéket `0.13`‑ként jeleníti, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Chart Data Labels](/slides/hu/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) példát a közvetlen címkeformázáshoz.

![Oszlopdiagram forrásra hivatkozó címkékkel, amelyek 12.5000% és 0.12346 értékeket mutatnak, valamint egy önállóan formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagramm adatcímkeként**

Szöveget használhat munkafüzet cellákból diagramm adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal az első dián egy meglévő prezentációhoz. A 0‑es munkalapon az A10:A12 cellákat használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

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

Az [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) tulajdonság hozzáférést biztosít a diagramm munkafüzet munkalapjaihoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és kiírja minden munkalap nevét a konzolra.

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

## **Az adatforrás típusának megadása**

A sorozat pont értékei közvetlenül numerikus literálokként is tárolhatók. Lásd a [Sorozatértékek beállítása numerikus literálokkal](/slides/hu/net/chart-series/#set-series-values-using-numeric-literals) teljes példát, amely menti és olvassa őket. A pont értékek forrás típusa különálló a diagramm belső vagy külső munkafüzet konfigurációjától; numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat nevet állít be különböző adatforrásokkal. Az első nevet karakterliterálként állítja; a másodikat a 0‑es munkalap C1 cellájából. A [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) felsorolás kiválasztja a forrást minden névhez. A példa menti a prezentációt a frissített sorozat nevekkel.

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

## **Nem támogatott beágyazott munkafüzet formátumok felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagrammokba beágyazható. Használhatja az [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) tulajdonságot az [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) együtt a [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) felsorolással, hogy felismerje a nem támogatott formátumokat és kihagyja ezeket a diagrammokat. Ez a példa ellenőrzi az első dián az alakzatait egy meglévő prezentációban, kihagyja a nem‑diagramm alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb beágyazott munkafüzetű diagrammra.

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

    // Olvassa vagy módosítsa a támogatott diagramm munkafüzet adatokat itt.
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramm adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódusokat, hogy egy beágyazott diagramm munkafüzetet exportáljon fájlba, és a diagrammot ehhez a külső munkafüzethez kapcsolja.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja munkafüzetét. Bezárja a kimeneti adatfolyamot, mielőtt a külső munkafüzetet a diagramm adatforrásaként rendeli hozzá, majd menti a kapcsolt prezentációt.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódus használatával egy külső munkafüzetet rendelhet diagrammhez adatforrásként. Ez a metódus felhasználható a külső munkafüzet elérési útjának frissítésére (ha az áthelyezésre került).

Bár a távoli helyen vagy erőforrásban tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes úttá konvertálódik.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` munkalapja egy sorozat nevet tartalmaz B1‑ben, kategória neveket A2:A4‑ben, és numerikus értékeket B2:B4‑ben. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) segítségével az A1:B4‑et egy sorozatra és három kategóriára képezi le. A prezentációt a kapcsolt diagrammmal menti.

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

Az [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen-e töltve.

* Ha `updateChartData` `false`, csak a munkafüzet útvonala frissül. A diagramm adatai nem töltődnek be vagy frissülnek a célnyelvi munkafüzetről, így a munkafüzet lehet, hogy nem érhető el.  
* Ha `updateChartData` `true`, a diagramm adatai frissülnek a célnyelvi munkafüzetről.

A következő példa egy helyőrző URL‑t rendeli hozzá `updateChartData` `false` értékkel. Megtartja a kördiagram alapértelmezett adatait, és a prezentációt a munkafüzet betöltése nélkül menti.

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

### **Diagramm külső adatforrás munkafüzet útvonalának lekérése**

A diagrammhez kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagramm külső adatforrást használ-e, és szerezze meg a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot vizsgálja egy prezentációban, amelynek külső munkafüzettel kapcsolt diagrammját. Ha ez egy diagramm, amely külső munkafüzettel van összekapcsolva, a példa kiírja a [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) konzolra. Ezután a prezentáció egy másolatát menti.

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

### **Diagramm adatainak szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagrammot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzettel van összekapcsolva. Beállítja az első sorozat első adatpontjának cellába tárolt értékét 100-ra, és menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha meg kell őrizni az eredeti munkafüzetet.

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

### **Munkafüzet helyreállítása a diagramm gyorsítótárból**

Ha egy diagramm egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagramm munkafüzett a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) példányt, konfigurálja annak [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) beállításait, és állítsa az [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) `true`‑ra a prezentáció megnyitása előtt.

A következő C# példa helyreállítja a munkafüzet adatokat egy diagrammhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzettel hivatkozik. A helyreállított adatokat az [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) és az [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével érheti el:

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

Ha a külső munkafüzet nem elérhető és a helyreállítás le van tiltva, az Aspose.Slides [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)-t dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramm adatok használata elfogadható, mivel a gyorsítótár nem tartalmazhatja a külső munkafüzetben a prezentáció legutóbbi frissítése után történt módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagramm egy külső vagy beágyazott munkafüzethez van‑e kapcsolva?**

Igen. Egy diagramm rendelkezik egy [adatforrás típusa](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [az externális munkafüzet útvonala](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/); ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat annak biztosítására, hogy egy külső fájlt használ.

**Támogatottak a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. A prezentáció az abszolút útvonalat a PPTX fájlban tárolja, így a munkafüzet áthelyezése esetén a hivatkozást frissíteni kell.

**Használhatok hálózati erőforrásokon/megosztásokon lévő munkafüzeteket?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX‑t a prezentáció mentésekor?**

A prezentáció egy [link a külső fájlhoz](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) tárolja. A cellákra hivatkozó diagramm adatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt. Használjon másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a kapcsoláskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/net/) segítségével), majd arra hivatkozni.

**Több diagramm hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagramm a saját hivatkozását táoldja. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagrammra hatással lesz a következő adatbetöltéskor.