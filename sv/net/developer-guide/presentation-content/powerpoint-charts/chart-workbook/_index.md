---
title: Hantera diagramarbetsböcker i presentationer i .NET
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/net/chart-workbook/
keywords:
- diagramarbetsbok
- diagramdata
- arbetsbokscell
- datamärkning
- kalkylblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- arbetsboksåterställning
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck Aspose.Slides för .NET: hantera enkelt diagramarbetsböcker i PowerPoint- och OpenDocument-format för att effektivisera dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur du läser och skriver diagramdata via arbetsbok‑strömmar, använder arbetsboksceller som diagramdatamärkningar, får åtkomst till kalkylarksamlingar och anger datakälltyp för diagramvärden.

Den täcker också hur du arbetar med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur du skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

För arbetsboksceller som representerar saknade data, se [Styr visning av tomma celler](/slides/sv/net/chart-series/) för skillnaden mellan en tom cell och noll samt en linjediagramjämförelse av de tillgängliga visningslägena.

## **Inkludera data från dolda rader och kolumner**

Använd [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) för att styra om ett diagram plotTar data från dolda kalkylarksrader och -kolumner. Sätt den till `true` för att plotta endast synliga celler, eller `false` för att inkludera både synliga och dolda celler. Denna inställning styr diagramplottning; den döljer eller visar inte kalkylarksrader eller -kolumner.

Ladda ner [hidden-source-data.pptx](hidden-source-data.pptx) och placera den i arbetskatalogen. Dess första bild innehåller ett stapeldiagram som den första formen. Det inbäddade kalkylbladet, `Sheet1`, innehåller följande källintervall, `A1:C4`. Rad 3 och kolumn C är dolda, men deras celler innehåller fortfarande värden.

| Kalkylarksrad | A: Månad | B: Detaljhandel | C: Partihandel (dolt kolumn) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (dolt rad) | Februari | 40 | 60 |
| 4 | Mars | 20 | 50 |

Få åtkomst till källcellerna via [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/chartdataworkbook/) och läs [IChartDataCell.IsHidden](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatacell/ishidden/) för att inspektera deras dolda status. Denna egenskap är skrivskyddad. I den här filen är B2 synlig, B3 tillhör den dolda raden och C2 tillhör den dolda kolumnen; exemplet skriver ut `False`, `True` och `True` respektive.

För detta exempel, uppdatera diagramdata efter att du ändrat plotinställningen: behåll den inbäddade arbetsboken med [ReadWorkbookStream](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/readworkbookstream/) och läs in den igen med [WriteWorkbookStream](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/writeworkbookstream/). När du inkluderar alla celler, använd även [SetRange](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/setrange/) för att återställa hela intervallet, inklusive den dolda februari‑kategorin. Att enbart ändra flaggan räcker inte för att uppdatera detta exempels cachade diagramdata och kategorimärkningar.

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

        // Uppdatera diagramdata från den inbäddade arbetsboken.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Återställ hela källintervallet, inklusive dolda kategorier.
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

Exemplet sparar `hidden_cells_True.pptx` med endast de synliga detaljhandelsvärdena (10 och 20), och `hidden_cells_False.pptx` med alla sex värden. Bilderna nedan har renderats från de sparade presentationerna efter att de öppnats igen; båda filerna behåller sin tilldelade plotinställning. Rad 3 och kolumn C förblir dolda i båda inbäddade arbetsböckerna.

| Endast synliga celler (`true`) | Alla celler (`false`) |
| --- | --- |
| ![Endast synliga celler: Detaljhandelsvärden 10 och 20 för januari och mars.](hidden_cells_True.png) | ![Alla celler: Detaljhandels- och partihandelsvärden för januari, februari och mars.](hidden_cells_False.png) |

En dold cell som innehåller ett värde är annorlunda än en tom cell. [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/displayblanksas/) kontrollerar hur saknade värden visas; den inkluderar eller exkluderar inte dold källdata. Se [Styr visning av tomma celler](/slides/sv/net/chart-series/#control-the-display-of-empty-cells) för ett exempel.

## **Läs och skriv diagramdata från en arbetsbok**

Aspose.Slides for .NET tillhandahåller metoderna [ReadWorkbookStream](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/readworkbookstream/) och [WriteWorkbookStream](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/writeworkbookstream/) som låter dig läsa och skriva diagramdataboksarbetsböcker (innehållande diagramdata redigerad med Aspose.Cells). **Obs** att diagramdata måste organiseras på samma sätt eller ha en struktur som liknar källan.

Detta exempel öppnar `chart.pptx`, som måste innehålla ett diagram som den första formen på dess första bild. Det läser in den inbäddade arbetsboken till en ström, rensar befintliga serier och kategorier och skriver tillbaka samma arbetsbok. Ändringarna kvarstår i minnet; exemplet sparar inte presentationen.

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

### **Validera diagramlayout efter arbetsboksändring**

När du ersätter en inbäddad arbetsbok med en modifierad, behåller diagrammet sina ursprungliga serie- och kategorisamlingar. Denna mismatch kan leda till att [IChart.ValidateChartLayout](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/validatechartlayout/) misslyckas med ett index‑out‑of‑range‑fel. Rensa befintliga serier och kategorier innan du skriver tillbaka den uppdaterade arbetsboken till diagrammet. Detta exempel kräver `chart.pptx` med ett diagram som den första formen på dess första bild. Kommentaren markerar var arbetsboksredigering skulle ske; det körbara exemplet skriver tillbaka den ursprungliga arbetsboken och validerar layouten i minnet.

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

    // Ändra arbetsboksströmmen här, till exempel med Aspose.Cells.

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

Att rensa samlingarna tar bort föråldrade datareferenser innan arbetsboken skrivs tillbaka. Återskapa eventuella nödvändiga serie‑ och kategorimappningar för den uppdaterade arbetsboken innan du använder diagrammet.

## **Ange en arbetsbokscell som diagramdatamärkning**

Du kan använda text från arbetsboksceller som diagramdatamärkningar. Följande steg visar hur du länkar märkningarna i ett bubbeldiagram till celler i dess datarbok.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Få åtkomst till den första bilden via dess nollbaserade index.
3. Lägg till ett bubbeldiagram med standarddata.
4. Få åtkomst till diagramserierna.
5. Ange arbetsbokscellen som en datamärkning.
6. Spara presentationen.

Detta exempel öppnar `chart2.pptx`, som måste innehålla minst en bild, och lägger till ett bubbeldiagram med standarddata. Det använder cellerna A10:A12 på kalkylblad 0 för de tre första märkningarna i den första serien, aktiverar märken från celler och sparar resultatet till `resultchart.pptx`.

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

## **Hantera kalkylblad**

[IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/worksheets/)‑egenskapen ger åtkomst till kalkylbladen i en diagramarbetsbok. Detta exempel skapar ett cirkeldiagram med standarddata och skriver ut varje kalkylbladsnamn till konsolen.

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

## **Ange datakälltyp**

Detta exempel skapar ett 3D‑stapeldiagram med standarddata och anger två serienamn med olika datakällor. Det första namnet använder en strängliteral; det andra använder cell C1 på kalkylblad 0. Enumerationen [DataSourceType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/datasourcetype/) väljer källan för varje namn. Resultatet sparas till `pres.pptx`.

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

## **Upptäck ej stödda inbäddade arbetsbokformat**

Aspose.Slides stöder inte Excel‑binärarbetsboken (.xlsb) som kan vara inbäddad i vissa diagram. Du kan använda egenskapen [EmbeddedWorkbookType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) på [IChartData](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/) tillsammans med enumerationen [WorkbookType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/workbooktype/) för att upptäcka ej stödda format och hoppa över dessa diagram. Detta exempel granskar formerna på den första bilden i `sample.pptx`, hoppar över former som inte är diagram och skriver ut ett diagnostiskt meddelande för varje diagram med en inbäddad .xlsb‑arbetsbok.

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

    // Läs eller modifiera stödjda diagramarbetsboksdata här.
}
```

## **Extern arbetsbok**

Aspose.Slides stöder att använda externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Använd [ReadWorkbookStream](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/readworkbookstream/) och [SetExternalWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/setexternalworkbook/) för att exportera en inbäddad diagramarbetsbok till en fil och länka diagrammet till den externa arbetsboken.

Detta exempel skapar ett cirkeldiagram med standarddata, skriver dess arbetsbok till `externalWorkbook1.xlsx` och stänger utdata‑strömmen innan filen tilldelas som diagrammets datakälla. Det sparar den länkade presentationen till `externalWorkbook.pptx`.

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

### **Ange en extern arbetsbok**

Genom att använda metoden [SetExternalWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/setexternalworkbook/) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du ändå använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges konverteras den automatiskt till en fullständig sökväg.

Detta exempel kräver `externalWorkbook.xlsx` i arbetskatalogen. Dess kalkylblad med namn `Sheet1` måste innehålla ett serienamn i B1, kategorinamn i A2:A4 och numeriska värden i B2:B4. Exemplet skapar ett cirkeldiagram, länkar arbetsboken och använder [SetRange](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/setrange/) för att mappa A1:B4 till en serie och tre kategorier. Det sparar resultatet till `Presentation_with_externalWorkbook.pptx`.

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

`updateChartData`‑parametern i [SetExternalWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/setexternalworkbook/) styr om arbetsboken laddas.

* När `updateChartData` är `false` uppdateras endast arbetsbokens sökväg. Diagramdata laddas inte eller uppdateras från mål‑arbetsboken, så arbetsboken kan vara otillgänglig.
* När `updateChartData` är `true` uppdateras diagramdata från mål‑arbetsboken.

Följande exempel tilldelar en platshållar‑URL med `updateChartData` satt till `false`. Det behåller cirkeldiagrammets standarddata och sparar presentationen utan att ladda den otillgängliga arbetsboken.

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

### **Hämta den externa datakällans arbetsbokssökväg för ett diagram**

För att identifiera arbetsboken som är länkad till ett diagram, kontrollera först om diagrammet använder en extern datakälla. Om så är fallet kan du hämta arbetsbokens sökväg genom att följa dessa steg.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/).
2. Få åtkomst till den första bilden via dess nollbaserade index.
3. Kontrollera att den första formen är ett diagram.
4. Läs diagrammets datakälltyp.
5. Om källan är en extern arbetsbok, läs dess sökväg.

Detta exempel öppnar `externalWorkbook.pptx`, skapat i föregående exempel, och granskar den första formen på den första bilden. Om den är ett diagram länkat till en extern arbetsbok, skriver exemplet ut [ExternalWorkbookPath](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/externalworkbookpath/) till konsolen. Det sparar sedan en kopia av presentationen till `Result.pptx`.

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

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Detta exempel kräver `presentation.pptx` med ett diagram som den första formen på den första bilden samt en åtkomlig extern arbetsbok. Det sätter cellbaserat värde för den första datapunkten i den första serien till 100 och sparar presentationen till `presentation_out.pptx`. Att redigera cellvärden kan uppdatera den länkade externa XLSX‑filen, så använd en kopia om du behöver bevara den ursprungliga arbetsboken.

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

### **Återskapa en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig, kan Aspose.Slides återskapa diagramarboken från de data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/) , konfigurera dess [SpreadsheetOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/spreadsheetoptions/) , och sätt [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/sv/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) till `true` innan du öppnar presentationen.

Följande C#‑exempel öppnar `presentation.pptx`, vars första form på den första bilden måste vara ett diagram som refererar till en otillgänglig extern arbetsbok, och får åtkomst till de återställda data via [IChart.ChartData](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/chartdata/) och [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // Läs eller modifiera de återställda arbetsboksdata här.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception). Aktivera återställning endast när det är acceptabelt att använda den cachade diagramdata som en reserv, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller inbäddad arbetsbok?**

Ja. Ett diagram har en [datakälltyp](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/datasourcetype/) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/externalworkbookpath/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Presentationen lagrar den absoluta sökvägen i PPTX‑filen, så att flytta arbetsboken kan kräva att länken uppdateras.

**Kan jag använda arbetsböcker som ligger på nätverksresurser/ delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Däremot stöds inte redigering av fjärrarbetsböcker direkt från Aspose.Slides – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/externalworkbookpath/). Att redigera cellbaserad diagramdata kan även uppdatera den länkade lokala XLSX‑filen. Använd en kopia av arbetsboken om originalet måste förbli oförändrat.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inget lösenord vid länkning. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](https://reference.aspose.com/cells/net/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data laddas.