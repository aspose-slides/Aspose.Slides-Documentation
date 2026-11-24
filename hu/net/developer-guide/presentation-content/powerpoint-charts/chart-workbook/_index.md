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
description: "Fedezze fel az Aspose.Slides for .NET-et: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentációs adatokat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagrammunkafüzetekkel az Aspose.Slides‑ben. Megmutatja, hogyan olvashat és írhat diagramadatakat munkafüzet‑folyamokkal, hogyan használhatja a munkafüzet‑cellákat diagramadat‑címkéként, hogyan érheti el a munkalap‑gyűjteményeket, és hogyan adhatja meg az adatforrás‑típust a diagram‑értékekhez.

Továbbá bemutatja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák demonstrálják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan szerezheti meg egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet‑cellák esetén lásd a [Üres cellák megjelenítésének szabályozása](/slides/hu/net/chart-series/) részt az üres cella és a nulla közötti különbségért, valamint a rendelkezésre álló megjelenítési módok vonaldiagram‑összehasonlításáért.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja az [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) beállítást annak szabályozására, hogy a diagram a rejtett munkalapsorok és –oszlopok adatait is ábrázolja‑e. Állítsa **true**‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy **false**‑ra, ha a látható és rejtett cellákat egyaránt be szeretné vonni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [példa prezentáció](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz első alakzatként az első dián. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik még mindig értékkel rendelkeznek.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forrás‑cellák eléréséhez használja az [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) tulajdonságot, és olvassa az [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) értékét a rejtett állapot ellenőrzéséhez. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa sorban a **False**, **True**, **True** értékeket írja ki.

Ehhez a példához a diagramadatok frissítésére a rajzolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) használatával, és töltse be újra a [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) segítségével. Az összes cella belefoglalásakor használja még a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) metódust a teljes tartomány helyreállításához, beleértve a rejtett februári kategóriát is. Egyszerűen a jelző módosítása nem elegendő a mintában tárolt diagramadatok és kategória‑címkék frissítéséhez.

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
            // Állítsa vissza a teljes forrás‑tartományt, beleértve a rejtett kategóriákat.
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

A példa két változatban menti a prezentációt: egyet, amely csak a látható kiskereskedelmi értékeket (10 és 20) tartalmazza, és egy másikat, amely az összes hat értéket tartalmazza. Az alábbi képek a mentett prezentációk újranyitása után kerültek renderelésre; mindkét fájl megőrzi a beállított rajzolási beállítást. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella eltér egy üres cellától. Az [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) szabályozza, hogyan vannak megjelenítve a hiányzó értékek; nem adja hozzá vagy távolítja el a rejtett forrásadatokat. Lásd a [Üres cellák megjelenítésének szabályozása](/slides/hu/net/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram tartományának lekérése**

Mielőtt frissítené a munkafüzet‑adatokat egy meglévő prezentációban, vizsgálja meg a forrás‑tartományokat, hogy azonosítsa, mely munkalap‑cellákat használja az egyes diagramok. Az [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) metódus visszaadja a jelenlegi adat‑tartományt egy munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig (inkluzívan) terjedő cellákat jelöli. A dollárjelek az abszolút sor‑ és oszlop‑hivatkozásokat jelzik.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, az [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) kivételt dob. További információért lásd a [Diagramadat API hivatkozás](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, majd közvetlenül minden dián ellenőrzi az alakzatokat diagramok keresése céljából. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, egy üzenetet ír ki, és a következő diagramra lép.

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

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for .NET biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatok) olvasását és írását. **Megjegyzés:** a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa egy prezentációt használ, amelynek első alakzata az első dián egy diagram. Beolvassa a beágyazott munkafüzetet egy folyamba, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változtatások memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagram elrendezésének ellenőrzése munkafüzet‑módosítás után**

Ha egy beágyazott munkafüzetet módosított verzióval helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés okozhatja, hogy az [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) index‑túllépés hibával meghiúsuljon. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet‑szerkesztés; a futtatható példa visszaírja az eredeti munkafüzetet, és a memóriában ellenőrzi az elrendezést.

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

    // Módosítsa itt a munkafüzet folyamot, például az Aspose.Cells használatával.

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

A gyűjtemények törlése eltávolítja a régi adat‑hivatkozásokat, mielőtt a munkafüzet vissza lenne írva. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Kategória‑címkék tárolásának módjának kiválasztása**

Állítsa be az [IChartCategoryCollection.UseCells](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorycollection/usecells/) tulajdonságot a üres kategória‑gyűjteményen, mielőtt címkéket adna hozzá. Használjon munkalap‑cellákat olyan címkékhez, amelyek munkafüzet‑adatokra hivatkoznak vagy hierarchiát alkotnak, például év szerint csoportosított negyedévek. Használjon karakter‑literálokat egyetlen szintű címkéhez, amelynek nincs szüksége cella‑hivatkozásra. Ez a beállítás csak a kategóriákra vonatkozik. Mindkét alább látható diagram a numerikus sorozat‑értékekhez munkalap‑cellákat használ.

A példa két oszlopdiagramot hoz létre, és mindkettőnél **Q1 Q2 Q3 Q4**‑et írat ki, valamint a tárolási módját. Munkalap‑támogatott címkéknél az [IChartCategory.AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/ascell/) ad hozzáférést az alap‑cellához, és az [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) visszaadja a címkét. Literális címkék esetén a karakterláncot közvetlenül az [IChartCategory.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/value/) adja vissza.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

foreach (var useCells in new[] { true, false })
{
    var x = useCells ? 20 : 360;
    var chart = shapes.AddChart(ChartType.ClusteredColumn, x, 20, 320, 250);
    var data = chart.ChartData;
    data.Series.Clear();
    data.Categories.Clear();
    data.Categories.UseCells = useCells;

    var workbook = data.ChartDataWorkbook;
    var seriesName = workbook.GetCell(0, 0, 1, "Sales");
    var series = data.Series.Add(seriesName, chart.Type);
    for (var row = 1; row <= 4; row++)
    {
        var label = $"Q{row}";
        if (useCells)
        {
            var labelCell = workbook.GetCell(0, row, 0, label);
            data.Categories.Add(labelCell);
        }
        else
        {
            data.Categories.Add(label);
        }

        var valueCell = workbook.GetCell(0, row, 1, row * 10);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    Console.Write($"UseCells = {data.Categories.UseCells}:");
    foreach (var category in data.Categories)
    {
        var label = data.Categories.UseCells ? category.AsCell.Value : category.Value;
        Console.Write($" {label}");
    }
    Console.WriteLine();
}

presentation.Save("category-labels.pptx", SaveFormat.Pptx);
```

## **Egyéni számformátum beállítása munkafüzet‑cellákhoz**

Használja a [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) metódust, hogy szabályozza, hogyan jelenjenek meg a numerikus értékek egy diagram beágyazott munkafüzetében. Például egy jelentésnek szüksége lehet egy konverziós rátára, amelyet százalékos formában, négy tizedesjeggyel, illetve egy együtthatóra, amelyet öt tizedesjeggyel kell megjeleníteni. Tartsa mindkét értéket numerikus formában, hogy továbbra is rendelkezésre álljanak a számításokhoz és a diagramrajzoláshoz.

A számformátum csak a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125`‑et `12.5000%`‑ként jeleníti meg; nem cseréli le a tárolt számot `12.5`‑re. Hasonlóan, a `0.00000` a `0.1234567`‑et `0.12346`‑ként mutatja, anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), a [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) kerül felhasználásra.

Az alábbi példa egy oszlopdiagramot hoz létre, és a cellákat a [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével ér el. Az 0‑s munkalapon a B2 tartalmazza a konverziós rátát, a C2 a együtthatót. Mindkét cella diagramértékeket szolgáltat. A példa továbbá engedélyezi a forrásformátumokhoz kapcsolt értékcímkéket.

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

A munkafüzet‑cellák formátumai elválasztottak a diagram‑tengelyekre vagy adatcímkékre közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás‑cella értékét jeleníti meg, mivel a [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) engedélyezett, és követi a forrás‑számformátumot, mert az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) **true**. A prezentáció mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy az alább látható. A függőleges tengely saját [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) formátummal rendelkezik (`0.00`), ahol az [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) **false**.

Ahhoz, hogy egy adatcímkét függetlenül formázzon, állítsa a forrás‑kapcsolat jelzőjét **false**‑ra, és adja meg a [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) értékét. Ez nem módosítja a munkafüzet‑cella formátumát. Például egy független címkeformátum `0.00` az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Diagramadat‑címkék](/slides/hu/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) fejezetet a közvetlen címkeformázáshoz.

Az alábbi kép a prezentáció mentése és újranyitása után lett renderelve:

![Oszlopdiagram forrás‑kapcsolt címkékkel, amelyek 12.5000% és 0.12346 értékeket, valamint egy függetlenül formázott numerikus tengelyt mutatnak.](custom-cell-formats.png)

## **Munkafüzet‑cella beállítása diagramadat‑címkének**

A munkafüzet‑cellák szövegét felhasználhatja diagramadat‑címkékhez.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. A 0‑s munkalap A10:A12 tartományát használja az első sorozat első három címkéjének, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

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

Az [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) tulajdonság hozzáférést biztosít a diagram‑munkafüzetben lévő munkalapokhoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét a konzolra írja.

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

A sorozat‑pont értékei tárolhatók közvetlenül numerikus literálokként is. Lásd a [Sorozatértékek beállítása numerikus literálokkal](/slides/hu/net/chart-series/#set-series-values-using-numeric-literals) fejezetet egy teljes példáért, amely elmenti és beolvassa őket. A pontértékek forrás‑típusa különválik a diagram belső vagy külső munkafüzet‑konfigurációjától; numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrásokkal. Az első név egy karakter‑literál, a második a 0‑s munkalap C1 cellájából származik. A [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) felsorolt típusával választható ki az egyes nevek forrása. A példa menti a prezentációt a frissített sorozat‑nevekkel.

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

## **Nem támogatott beágyazott munkafüzet‑formátumok észlelése**

Az Aspose.Slides nem támogatja a Excel bináris munkafüzet (.xlsb) formátumát, amely néhány diagramba beágyazott lehet. A [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) tulajdonságot használhatja az [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) együtt a [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) felsorolt típussal, hogy észlelje a nem támogatott formátumokat, és átugorja az ilyen diagramokat. Ez a példa az első dián lévő alakzatokat vizsgálja egy meglévő prezentációban, kihagyja a nem‑diagram alakzatokat, és diagnosztikus üzenetet ír ki minden .xlsb‑t tartalmazó diagramhoz.

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

    // Olvassa vagy módosítsa itt a támogatott diagrammunkafüzet adatait.
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) és a [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódusokat a beágyazott diagram‑munkafüzet exportálásához fájlba, és a diagram külső munkafüzethez való kapcsolásához.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. A kimeneti folyamot a külső munkafüzet diagramadat‑forrásként való hozzárendelése előtt zárja le, majd menti a kapcsolt prezentációt.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) metódus segítségével egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a módszerrel frissíthető a külső munkafüzet elérési útja is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem lehet szerkeszteni, továbbra is használhatóak külső adatforrásként. Ha relatív útvonalat adunk meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` munkalapja B1‑ben tartalmaz egy sorozat‑nevet, A2:A4‑ben kategória‑neveket, és B2:B4‑ben numerikus értékeket. A példa egy kördiagramot hoz létre, kapcsolja a munkafüzetet, és a [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) segítségével A1:B4‑et egy sorozatra és három kategóriára leképezi. Mentse a prezentációt a kapcsolt diagrammal.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) **updateChartData** paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha **updateChartData** **false**, csak a munkafüzet útvonala frissül. A diagramadatok nincsenek betöltve vagy frissítve a cél‑munkafüzetből, így a munkafüzet hiányozhat.
* Ha **updateChartData** **true**, a diagramadatok frissülnek a cél‑munkafüzetről.

Az alábbi példa egy helyettesítő URL‑t ad meg **updateChartData** **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt a munkafüzet betöltése nélkül menti.

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

### **Diagram külső adatforrás‑munkafüzetének útvonalának lekérdezése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot vizsgálja egy, külső munkafüzettel kapcsolt prezentációban. Ha ez egy diagram, amely külső munkafüzethez van kapcsolva, a példa kiírja az [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) értékét a konzolra, majd ment egy másolatot a prezentációról.

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

### **Diagramadatok szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzethez van kapcsolva. Az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, és menti a frissített prezentációt. A cella‑értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetnek változatlanul kell maradnia.

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

## **Diagramadatok frissítése forrás‑munkafüzetekből**

Az Aspose.Slides for .NET 26.11 hozzáadta az [IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) metódust egy diagramhoz, valamint az [IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) metódust a prezentációhoz. Használja ezeket, ha a forrás‑munkafüzet értékei megváltoznak. A külső munkafüzeteknek elérhetőnek és támogatottnak kell lenniük.

A [Aspose.Slides for .NET](/slides/hu/net/installation/) 26.11 vagy újabb verziójának telepítése után ez a példa frissíti a `charts.pptx` első diáján az első diagramot. A forrás‑munkafüzetnek elérhetőnek kell lennie. Mentse az eredményt a frissített diagramadatok megtartásához.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
var chart = presentation.Slides[0].Shapes.OfType<IChart>().FirstOrDefault();
if (chart == null)
{
    Console.WriteLine("The first slide must contain a chart.");
    return;
}

chart.ChartData.RefreshData();
presentation.Save("refreshed-chart.pptx", SaveFormat.Pptx);
```

Az összes diagram frissítéséhez használjon egy külön prezentáció‑példányt az alábbiak szerint. A **false** átadása esetén a frissítési hiba a hívóhoz propagálódik; nem vonja vissza a már frissített diagramokat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

Az alapértelmezett paraméter **true**: a [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) kihagy egy hibás diagramot, és a többit folytatja. Nem ad vissza diagram‑specifikus eredményeket, így egy befejezett hívás önmagában nem bizonyítja, hogy minden diagram frissült. Használjon egyedi [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) hívásokat, ha a hibás diagramok azonosítására van szükség.

A frissítés újratölti a forrás‑adatokat. Ez különbözik a képlet‑számítástól, a diagram‑elrendezés‑ellenőrzéstől és az OLE‑előnézet frissítésétől. A memóriában lévő cella‑alapú értékek ellenőrzésével vizsgálhatja a frissítést. Egy [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) még mindig leírhatja a korábban mentett diagramot, amíg a prezentációt nem menti és nem nyitja meg újra.

### **Gyorsítótárazott diagramértékek olvasása munkafüzet nélkül**

A .NET 26.11‑ban a gyorsítótár‑hozzáférők a diagrammal tárolt értékeket olvassák ki a munkafüzet megnyitása nélkül. Hasznosak, ha a kapcsolt fájl nem érhető el, és csak a diagram utolsó tárolt adataira van szükség. Ez eltér a lenti helyreállítási lehetőség használatával történő munkafüzet‑rekonstrukciótól.

| Objektum | Gyorsítótárazott accessor |
| --- | --- |
| Szokásos sorozat adatpont | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| Szórás‑ vagy buborék‑adatpont | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| Buborék‑adatpont | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| Diagram‑kategória | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

Mindegyik accessor visszaad egy [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/) példányt. A [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) a tárolt objektumot adja, a [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) szöveget biztosít, a [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) **NaN**‑t ad vissza hiányzó vagy nem numerikus érték esetén. A gyorsítótár hiányozhat vagy elavult lehet, például egy újból létrehozott, még nem mentett diagram esetén. Ne feltételezze, hogy minden mező létezik vagy számot tartalmaz.

Ez a példa az összes fenti mezőt olvassa a `cached-chart.pptx`‑ből, egy mentett prezentációból, amely diagramokat tartalmaz. A hiányzó külső munkafüzet elfogadható, mivel a kód nem érinti a [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) vagy az élő munkafüzet‑cellákat.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("cached-chart.pptx");
foreach (var slide in presentation.Slides)
foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
        continue;

    foreach (var category in chart.ChartData.Categories)
        PrintCache("Category", category.CachedValue);

    foreach (var series in chart.ChartData.Series)
    foreach (var point in series.DataPoints)
    {
        PrintCache("Value", point.CachedValue);
        PrintCache("X", point.CachedXValue);
        PrintCache("Y", point.CachedYValue);
        PrintCache("Bubble size", point.CachedBubbleSize);
    }
}

static void PrintCache(string name, ICachedChartValue value)
{
    var number = value.ToDouble();
    if (value.Data == null)
        Console.WriteLine($"{name}: no cached value");
    else if (double.IsNaN(number))
        Console.WriteLine($"{name}: {value} (not numeric)");
    else
        Console.WriteLine($"{name}: {number}");
}
```

Használja a frissítést, ha aktuális forrás‑adatokra van szüksége; használja a gyorsítótár‑olvasást, ha a tárolt pillanatkép elegendő. A gyorsítótár nem a munkafüzet teljes másolata, és nem szolgáltatja a legutóbb frissítés óta történt változásokat.

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides rekonstruálhatja a diagram‑munkafüzetet a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) objektumot, konfigurálja a [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) beállításait, és állítsa a [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) értékét **true**‑ra, mielőtt megnyitná a prezentációt.

Az alábbi C# példa helyreállítja a munkafüzet‑adatokat egy diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzetre hivatkozik. A helyreállított adatokat az [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) és az [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) segítségével érheti el:

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

Ha a kód a külső munkafüzetet elérhetetlenül próbálja elérni, és a helyreállítás ki van kapcsolva, az Aspose.Slides egy [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótár‑adatok használata elfogadható megoldás, mivel a gyorsítótár nem tartalmazhatja a külső munkafüzeten történt változásokat a legutóbbi prezentáció‑frissítés óta.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e kapcsolva?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) tulajdonsággal; ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy külső fájlt használ.

**Támogatottak-e a külső munkafüzetek relatív útvonalai, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan átalakítja abszolút úttá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezése esetén frissíteni kell a linket.

**Használhatók‑e a hálózati erőforrásokon/megosztókon található munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt. Ha az eredetit érintetlenül kell hagyni, használjon másolatot a munkafüzetről.

**Mi a teendő, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a kapcsoláskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/net/) segítségével), majd a másolatra való kapcsolás.