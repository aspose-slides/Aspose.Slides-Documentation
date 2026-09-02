---
title: "Hantera diagramarbok i presentationer i .NET"
linktitle: "Diagramarbok"
type: docs
weight: 70
url: /sv/net/chart-workbook/
keywords:
- diagramarbok
- diagramdata
- arbetsbokscell
- datamärkning
- arbetsblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- återställning av arbetsbok
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck Aspose.Slides för .NET: hantera enkelt diagramarbok i PowerPoint- och OpenDocument-format för att effektivisera dina presentationsdata."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramarbok i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboksceller som diagramdatamärkning, får åtkomst till arbetsbladssamlingar och specificerar datakälltyp för diagramvärden.

Den täcker även arbete med externa arbetsböcker som diagramdatakällor. Exemplen visar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram samt redigerar diagramdata när arbetsboken är tillgänglig.

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides tillhandahåller metoderna [ReadWorkbookStream](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/readworkbookstream/) och [WriteWorkbookStream](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/writeworkbookstream/) som låter dig läsa och skriva diagramdataarbetsböcker (som innehåller diagramdata redigerade med Aspose.Cells). **Obs** att diagramdata måste organiseras på samma sätt eller ha en struktur som liknar källan.

Den här C#-koden demonstrerar ett exempel på en operation:

```c#
using (Presentation pres = new Presentation("chart.pptx"))
{
    Chart chart = (Chart) pres.Slides[0].Shapes[0];
    IChartData data = chart.ChartData;

    MemoryStream stream = data.ReadWorkbookStream();

    data.Series.Clear();
    data.Categories.Clear();

    stream.Position = 0;
    data.WriteWorkbookStream(stream);
}
```

## **Ställ in en arbetsboks cell som diagramdatamärkning**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Lägg till ett bubbeldiagram med lite data.
1. Åtkomst till diagramserierna.
1. Ställ in arbetsbokscellen som en datamärkning.
1. Spara presentationen.

Den här C#-koden visar hur du ställer in en arbetsbokscell som en diagramdatamärkning:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Skapar en presentationsklass som representerar en presentationsfil

using (Presentation pres = new Presentation("chart2.pptx"))
{
    ISlide slide = pres.Slides[0];


    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);

    IChartSeriesCollection series = chart.ChartData.Series;

    series[0].Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;

    IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

    series[0].Labels[0].ValueFromCell = wb.GetCell(0, "A10", lbl0);
    series[0].Labels[1].ValueFromCell = wb.GetCell(0, "A11", lbl1);
    series[0].Labels[2].ValueFromCell = wb.GetCell(0, "A12", lbl2);

    pres.Save("resultchart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Hantera arbetsblad**

Den här C#-koden demonstrerar en operation där egenskapen [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) används för att komma åt en samling av arbetsblad:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Specificera datakälltyp**

Den här C#-koden visar hur du specificerar en typ för en datakälla:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.ChartData.Series[0].Name;
    
    val.DataSourceType = DataSourceType.StringLiterals;
    val.Data = "LiteralString";

    val = chart.ChartData.Series[1].Name;
    val.Data = chart.ChartData.ChartDataWorkbook.GetCell(0, "B1", "NewCell");

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Detektera ej stödda inbäddade arbetsboksformat**

Aspose.Slides stödjer inte Excel‑binärarboken (.xlsb) som kan vara inbäddad i vissa diagram. Du kan använda egenskapen `EmbeddedWorkbookType` på [IChartData](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/workbooktype/) för att upptäcka ej stödda format och hoppa över dessa diagram.

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        if (shape is not IChart chart) continue;

        var chartData = chart.ChartData;

        if (chartData.DataSourceType == ChartDataSourceType.InternalWorkbook &&
            chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro)
        {
            // Inbäddad arbetsbok är i .xlsb-format, vilket inte stöds.
            continue;
        }

        // Läs eller ändra diagramarbokens data här.
    }
}
```

## **Extern arbetsbok**

{{% alert color="primary" %}} 
I Aspose.Slides 19.4 implementerade vi stöd för externa arbetsböcker som datakälla för diagram.
{{% /alert %}} 

### **Skapa en extern arbetsbok**
Genom att använda metoderna **`ReadWorkbookStream`** och **`SetExternalWorkbook`** kan du antingen skapa en extern arbetsbok från grunden eller göra en intern arbetsbok extern.

Den här C#-koden demonstrerar processen för att skapa en extern arbetsbok:

```c#
using (Presentation pres = new Presentation())
{
    const string workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
    using (FileStream fileStream = new FileStream(workbookPath, FileMode.Create))
    {
        byte[] workbookData = chart.ChartData.ReadWorkbookStream().ToArray();
        fileStream.Write(workbookData, 0, workbookData.Length);
    }
    
    chart.ChartData.SetExternalWorkbook(Path.GetFullPath(workbookPath));

    pres.Save("externalWorkbook.pptx", SaveFormat.Pptx);
}
```

### **Tilldela en extern arbetsbok**
Genom att använda metoden **`SetExternalWorkbook`** kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

Den här C#-koden visar hur du ställer in en extern arbetsbok:

```c#
// Sökvägen till dokumentkatalogen.
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.ChartData;
                    
    chartData.SetExternalWorkbook(Path.GetFullPath("externalWorkbook.xlsx"));
                  

    chartData.Series.Add(chartData.ChartDataWorkbook.GetCell(0, "B1"), ChartType.Pie);
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B2"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B3"));
    chartData.Series[0].DataPoints.AddDataPointForPieSeries(chartData.ChartDataWorkbook.GetCell(0, "B4"));

    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A2"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A3"));
    chartData.Categories.Add(chartData.ChartDataWorkbook.GetCell(0, "A4"));
    pres.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
}
```

Parametern `ChartData` (under metoden `SetExternalWorkbook`) används för att ange om en Excel‑arbok ska laddas eller inte.

* När värdet för `ChartData` är `false` uppdateras endast arbetsbokens sökväg – diagramdata kommer inte att laddas eller uppdateras från målarboken. Du kan vilja använda denna inställning när målarboken saknas eller är otillgänglig.
* När värdet för `ChartData` är `true` uppdateras diagramdata från målarboken.

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
	IChartData chartData = chart.ChartData;

	(chartData as ChartData).SetExternalWorkbook("http://path/doesnt/exists", false);

	pres.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
}
```

### **Hämta den externa datakällans arbetsboksökväg för ett diagram**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
1. Hämta en bilds referens via dess index.
1. Skapa ett objekt för diagramformen.
1. Skapa ett objekt för källtypen (`ChartDataSourceType`) som representerar diagrammets datakälla.
1. Specificera det relevanta villkoret baserat på att källtypen är densamma som den externa arbetsbokens datakälltyp.

Den här C#-koden demonstrerar operationen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[1];
    IChart chart = (IChart)slide.Shapes[0];
    ChartDataSourceType sourceType = chart.ChartData.DataSourceType;
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        string path = chart.ChartData.ExternalWorkbookPath;
    }
    
    // Sparar presentationen
    pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

### **Redigera diagramdata**
Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Den här C#-koden är en implementation av den beskrivna processen:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

### **Återskapa en arbetsbok från diagramcachen**
Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig kan Aspose.Slides rekonstruera diagramarboken från de data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/), konfigurera dess [SpreadsheetOptions](https://reference.aspose.com/slides/sv/net/aspose.slides/loadoptions/spreadsheetoptions/), och sätt [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/sv/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) till `true` innan du öppnar presentationen.

Följande C#‑exempel öppnar en presentation vars diagram refererar till en otillgänglig extern arbetsbok och får åtkomst till de återställda data via [IChart.ChartData](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichart/chartdata/) och [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        RecoverWorkbookFromChartCache = true
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

var chart = (IChart)presentation.Slides[0].Shapes[0];
var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

// Read or modify the recovered workbook data here.
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett `InvalidOperationException`. Aktivera återställning endast när det är acceptabelt att använda den cachade diagramdatan som en fallback, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/datasourcetype/) och en [path to an external workbook](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/externalworkbookpath/). Om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektportabilitet; dock bör du vara medveten om att presentationen lagrar den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker placerade på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Däremot stöds inte direkt redigering av fjärrarbetsböcker från Aspose.Slides – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX-filen när presentationen sparas?**

Nej. Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/externalworkbookpath/). Den externa filen modifieras inte när presentationen sparas.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](/cells/net/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av filen att återspeglas i varje diagram nästa gång datan laddas.