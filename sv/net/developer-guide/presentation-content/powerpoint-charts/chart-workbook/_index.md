---
title: Hantera diagramarbok i presentationer i .NET
linktitle: Diagramarbok
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
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck Aspose.Slides för .NET: hantera diagramarbok i PowerPoint- och OpenDocument-format på ett enkelt sätt för att effektivisera dina presentationsdata."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboksceller som diagramdatamärkning, får åtkomst till arbetsbladssamlingar och anger datakälltyp för diagramvärden.

Den behandlar även arbete med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

## **Läs och skriv diagramdata från en arbetsbok**
Aspose.Slides tillhandahåller metoderna [ReadWorkbookStream](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/readworkbookstream/) och [WriteWorkbookStream](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/writeworkbookstream/) som låter dig läsa och skriva diagramarbetsböcker (innehållande diagramdata redigerad med Aspose.Cells). **Obs!** diagramdata måste vara organiserad på samma sätt eller ha en struktur som liknar källan.

Denna C#‑kod demonstrerar ett exempel:

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

## **Ange en arbetsbokscell som diagramdatamärkning**
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
2. Hämta en bilds referens via dess index.
3. Lägg till ett bubbeldiagram med någon data.
4. Få åtkomst till diagramserierna.
5. Ange arbetsbokscellen som en datamärkning.
6. Spara presentationen.

Denna C#‑kod visar hur du anger en arbetsbokscell som en diagramdatamärkning:

```c#
string lbl0 = "Label 0 cell value";
string lbl1 = "Label 1 cell value";
string lbl2 = "Label 2 cell value";

// Instansierar en presentationsklass som representerar en presentationsfil 

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

Denna C#‑kod demonstrerar en operation där egenskapen [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdataworkbook/properties/worksheets) används för att få åtkomst till en arbetsbladssamling:

``` csharp
using (Presentation pres = new Presentation())
{
   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
   IChartDataWorkbook wb =  chart.ChartData.ChartDataWorkbook;
   for (int i = 0; i < wb.Worksheets.Count; i++)
      Console.WriteLine(wb.Worksheets[i].Name);
}
```

## **Ange datakälltyp**

Denna C#‑kod visar hur du anger en typ för en datakälla:

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

## **Identifiera ej stödjade inbäddade arbetsbokformat**

Aspose.Slides stöder inte Excel‑binärarbetsboksformatet (.xlsb) som kan vara inbäddat i vissa diagram. Du kan använda egenskapen `EmbeddedWorkbookType` på [IChartData](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/workbooktype/) för att identifiera ej stödjade format och hoppa över dessa diagram.

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

        // Läs eller modifiera diagramarbokens data här.
    }
}
```

## **Extern arbetsbok**

{{% alert color="primary" %}} 
I [Aspose.Slides 19.4](https://docs.aspose.com/slides/sv/net/aspose-slides-for-net-19-4-release-notes/) har vi implementerat stöd för externa arbetsböcker som datakälla för diagram.
{{% /alert %}} 

### **Skapa en extern arbetsbok**
Med metoderna **`ReadWorkbookStream`** och **`SetExternalWorkbook`** kan du antingen skapa en extern arbetsbok från grunden eller göra en intern arbetsbok extern.

Denna C#‑kod demonstrerar processen för att skapa en extern arbetsbok:

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

### **Ange en extern arbetsbok**
Med metoden **`SetExternalWorkbook`** kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Du kan inte redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, men du kan ändå använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok tillhandahålls konverteras den automatiskt till en fullständig sökväg.

Denna C#‑kod visar hur du anger en extern arbetsbok:

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

Parametern `ChartData` (under metoden `SetExternalWorkbook`) används för att ange om en Excel‑arbetsbok ska laddas eller inte.

* När `ChartData`‑värdet är `false` uppdateras endast arbetsbokens sökväg – diagramdata laddas inte och uppdateras inte från mål‑arbetsboken. Detta kan vara användbart när mål‑arbetsboken saknas eller är otillgänglig.  
* När `ChartData`‑värdet är `true` uppdateras diagramdata från mål‑arbetsboken.

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
2. Hämta en bilds referens via dess index.
3. Skapa ett objekt för diagramformen.
4. Skapa ett objekt för källtypen (`ChartDataSourceType`) som representerar diagrammets datakälla.
5. Ange det relevanta villkoret baserat på att källtypen är densamma som den externa arbetsbokens datakälltyp.

Denna C#‑kod demonstrerar operationen:

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

Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Denna C#‑kod är en implementation av den beskrivna processen:

```c#
using (Presentation pres = new Presentation("presentation.pptx"))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;
    ChartData chartData = (ChartData)chart.ChartData;
                   

    chartData.Series[0].DataPoints[0].Value.AsCell.Value = 100;
    pres.Save("presentation_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller inbäddad arbetsbok?**

Ja. Ett diagram har en [datakälltyp](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/datasourcetype/) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/externalworkbookpath/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektportabilitet; dock lagras den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som ligger på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Att redigera fjärrarbetsböcker direkt från Aspose.Slides stöds däremot inte – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Nej. Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/chartdata/externalworkbookpath/) och använder den för att läsa data. Den externa filen ändras inte när presentationen sparas.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inget lösenord vid länkning. Ett vanligt tillvägagångssätt är att i förväg ta bort skyddet eller skapa en avkrypterad kopia (t.ex. med [Aspose.Cells](/cells/net/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en ändring av den filen att återspeglas i varje diagram nästa gång data laddas.