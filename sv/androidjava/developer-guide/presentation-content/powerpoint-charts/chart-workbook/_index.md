---
title: Hantera diagramarbetsböcker i presentationer på Android
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/androidjava/chart-workbook/
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
- arbetsboksåterställning
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck Aspose.Slides för Android via Java: hantera enkelt diagramarböcker i PowerPoint- och OpenDocument-format för att effektivisera dina presentationsdata."
---
## **Översikt**

Denna artikel förklarar hur du arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur du läser och skriver diagramdata via arbetsboksströmmar, använder arbetsboks-celler som diagramdatamärkning, får åtkomst till arbetsbladssamlingar och anger datakälltyp för diagramvärden.

Den behandlar också hur du arbetar med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur du skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkat till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

## **Läsa och skriva diagramdata från en arbetsbok**
Aspose.Slides tillhandahåller metoderna [ReadWorkbookStream](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) och [WriteWorkbookStream](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) som låter dig läsa och skriva diagramdataarbetsböcker (innehållande diagramdata redigerad med Aspose.Cells). **Obs!** att diagramdata måste vara organiserad på samma sätt eller ha en struktur som liknar källan.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Validera diagramlayout efter arbetsboksändring**

När du ersätter en inbäddad arbetsbok med en modifierad behåller diagrammet sina ursprungliga serier och kategori‑samlingar. Denna mismatch kan leda till att [IChart.validateChartLayout](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChart#validateChartLayout--) misslyckas med ett index‑out‑of‑range‑fel. Rensa de befintliga serierna och kategorierna innan du skriver tillbaka den uppdaterade arbetsboken till diagrammet.

```java
// Efter att ha modifierat arbetsboksströmmen (t.ex. med Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Rensa befintliga datreferenser.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Att rensa samlingarna säkerställer att diagramdatastrukturen är konsistent med den nya arbetsboken, så att `validateChartLayout` kan slutföras utan fel.

## **Ange en arbetsboks‑cell som diagramdatamärkning**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Hämta en bildreferens via dess index.
1. Lägg till ett bubbeldiagram med någon data.
1. Få åtkomst till diagramserierna.
1. Ange arbetsboks‑cellen som en datamärkning.
1. Spara presentationen.

Denna Java‑kod visar hur du anger en arbetsboks‑cell som en diagramdatamärkning:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instansierar en presentationklass som representerar en presentationsfil
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hantera arbetsblad**

Denna Java‑kod demonstrerar en operation där metoden [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) används för att komma åt en arbetsblads‑samling:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange datakälltyp**

Denna Java‑kod visar hur du anger en typ för en datakälla:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Upptäcka icke‑stödda inbäddade arbetsboksformat**

Aspose.Slides stödjer inte Excel‑binärarbetsboksformatet (.xlsb) som kan vara inbäddat i vissa diagram. Du kan använda metoden `getEmbeddedWorkbookType` på [IChartData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IChartData) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/WorkbookType) för att upptäcka icke‑stödda format och hoppa över dessa diagram.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Inbäddad arbetsbok är i .xlsb-format, vilket inte stöds.
            continue;
        }

        // Läs eller modifiera diagramarbokens data här.
    }
} finally {
    presentation.dispose();
}
```

## **Extern arbetsbok**

Aspose.Slides stödjer externa arbetsböcker som en datakälla för diagram.

### **Skapa en extern arbetsbok**

Med hjälp av metoderna **`readWorkbookStream`** och **`setExternalWorkbook`** kan du antingen skapa en extern arbetsbok från grunden eller göra en intern arbetsbok extern.

Denna Java‑kod demonstrerar processen för att skapa en extern arbetsbok:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ange en extern arbetsbok**

Genom att använda metoden **`setExternalWorkbook`** kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera en sökväg till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges konverteras den automatiskt till en fullständig sökväg.

Denna Java‑kod visar hur du anger en extern arbetsbok:

```java
import com.aspose.slides.*;

// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Parametern `updateChartData` (under metoden `setExternalWorkbook`) används för att ange om en Excel‑arbetsbok ska läsas in eller inte.

* När `updateChartData` är satt till `false` uppdateras endast arbetsbokens sökväg – diagramdata laddas inte och uppdateras inte från mål‑arbetsboken. Detta kan vara önskvärt när mål‑arbetsboken saknas eller är otillgänglig.  
* När `updateChartData` är satt till `true` uppdateras diagramdata från mål‑arbetsboken.

```java
import com.aspose.slides.*;

// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Hämta den externa datakällans arbetsboks‑sökväg för ett diagram**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation).
1. Hämta en bildreferens via dess index.
1. Skapa ett objekt för diagramformen.
1. Skapa ett objekt för källtypen (`ChartDataSourceType`) som representerar diagrammets datakälla.
1. Specificera det relevanta villkoret baserat på att källtypen är densamma som den externa arbetsbokens datakälltyp.

Denna Java‑kod demonstrerar operationen:

```java
import com.aspose.slides.*;

// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Sparar presentationen
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Denna Java‑kod är en implementation av den beskrivna processen:

```java
import com.aspose.slides.*;

// Skapar en instans av Presentation-klassen
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Återskapa en arbetsbok från diagram‑cachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig kan Aspose.Slides rekonstruera diagramarbetsboken från de data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/), konfigurera den med [SpreadsheetOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/spreadsheetoptions/), och anropa [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) med `true` innan du öppnar presentationen.

Följande Java‑exempel öppnar en presentation vars diagram refererar till en otillgänglig extern arbetsbok och får åtkomst till de återställda data via [IChart.getChartData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/#getChartData--) och [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Läs eller modifiera de återställda arbetsbokens data här.
} finally {
    presentation.dispose();
}
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett undantag. Aktivera återställning endast när det är acceptabelt att använda den cachade diagramdatan som en fallback, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) och en [path to an external workbook](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektportabilitet; dock lagrar presentationen den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som finns på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Redigering av fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Nej. Presentationen lagrar en [link to the external file](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) och använder den för att läsa data. Den externa filen ändras inte när presentationen sparas.

**Vad gör jag om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](/cells/androidjava/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av filen att återspeglas i varje diagram nästa gång data laddas.