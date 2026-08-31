---
title: Hantera diagramarbok i presentationer med JavaScript
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/nodejs-java/chart-workbook/
keywords:
- diagramarbok
- diagramdata
- arbetsboks cell
- datamärkning
- arbetsblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- arbetsboksåterställning
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck Aspose.Slides för Node.js via Java: hantera enkelt diagramarbok i PowerPoint- och OpenDocument-format för att förenkla dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsboksströmmar, använder arbetsboks‑celler som diagramdatapunkter, får åtkomst till samlingar av arbetsblad och anger datakälltyp för diagramvärden.

Den tar också upp hur man arbetar med externa arbetsböcker som datakällor för diagram. Exempelen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides tillhandahåller metoderna [readWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) och [writeWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) som låter dig läsa och skriva diagramdataarbetsböcker (innehållande diagramdata redigerad med Aspose.Cells). **Obs!** diagramdata måste vara organiserad på samma sätt eller ha en struktur som liknar källan.

Denna JavaScript‑kod demonstrerar ett exempel på en operation:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Validera diagramlayout efter arbetsboksändring**

När du ersätter en inbäddad arbetsbok med en modifierad behåller diagrammet sina ursprungliga serier och kategorisamlingar. Denna mismatch kan få [Chart.validateChartLayout](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Chart#validateChartLayout--) att misslyckas med ett index‑out‑of‑range‑fel. Rensa befintliga serier och kategorier innan du skriver den uppdaterade arbetsboken tillbaka till diagrammet.

```javascript
// Efter att ha modifierat arbetsboksströmmen (t.ex. med Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Rensa befintliga datareferenser.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Att rensa samlingarna säkerställer att diagramdatans struktur är konsekvent med den nya arbetsboken, så att `validateChartLayout` kan slutföras utan fel.

## **Ange arbetsboks cell som diagramdatapunkt**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
2. Hämta en bilds referens via dess index.
3. Lägg till ett bubbeldiagram med några data.
4. Få åtkomst till diagramserien.
5. Ange arbetsboks‑cellen som en datapunkt.
6. Spara presentationen.

Denna JavaScript‑kod visar hur du anger en arbetsboks‑cell som en diagramdatapunkt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instanserar en presentationsklass som representerar en presentationsfil
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hantera arbetsblad**

Denna JavaScript‑kod demonstrerar en operation där metoden [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) används för att komma åt en samling av arbetsblad:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange datakälltyp**

Denna JavaScript‑kod visar hur du anger en typ för en datakälla:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Identifiera ej stödda inbäddade arbetsboksformat**

Aspose.Slides stöder inte det binära Excel‑arbetsboksformatet (.xlsb) som kan vara inbäddat i vissa diagram. Du kan använda metoden `getEmbeddedWorkbookType` på [ChartData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/workbooktype/) för att identifiera ej stödda format och hoppa över dessa diagram.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // Den inbäddade arbetsboken är i .xlsb-format, vilket inte stöds.
            continue;
        }

        // Läs eller ändra diagramarbokens data här.
    }
} finally {
    presentation.dispose();
}
```

## **Extern arbetsbok**

Aspose.Slides stöder externa arbetsböcker som datakälla för diagram.

### **Skapa extern arbetsbok**

Med hjälp av **`readWorkbookStream`** och **`setExternalWorkbook`** kan du antingen skapa en extern arbetsbok från grunden eller göra en intern arbetsbok extern.

Denna JavaScript‑kod demonstrerar processen för att skapa en extern arbetsbok:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream returnerar arbetsbokens bytes som en Node Buffer.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Ange extern arbetsbok**

Med hjälp av **`setExternalWorkbook`** kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

Denna JavaScript‑kod visar hur du anger en extern arbetsbok:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Den andra parametern i `setExternalWorkbook`‑metoden, `updateChartData`, anger om Excel‑arbetsboken ska laddas eller inte.

* När `updateChartData` är satt till `false`, uppdateras endast arbetsbokens sökväg – diagramdata laddas inte och uppdateras inte från mål‑arbetsboken. Detta kan vara användbart när mål‑arbetsboken är frånvarande eller otillgänglig.
* När `updateChartData` är satt till `true`, uppdateras diagramdata från mål‑arbetsboken.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Hämta diagrammets externa datakällas arbetsboksökväg**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
2. Hämta en bilds referens via dess index.
3. Skapa ett objekt för diagramformen.
4. Skapa ett objekt för källtypen (`ChartDataSourceType`) som representerar diagrammets datakälla.
5. Ange relevant villkor baserat på att källtypen är samma som den externa arbetsboksdatakälltypen.

Denna JavaScript‑kod demonstrerar operationen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Sparar presentationen
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Denna JavaScript‑kod är en implementation av den beskrivna processen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Skapar en instans av Presentation-klassen
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Återskapa en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig kan Aspose.Slides rekonstruera diagramarbetsboken från de data som cachas i presentationen. Skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/), konfigurera det med [SpreadsheetOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/spreadsheetoptions/), och anropa [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) med `true` innan du öppnar presentationen.

Följande JavaScript‑exempel öppnar en presentation vars diagram refererar till en otillgänglig extern arbetsbok och får åtkomst till den återställda datan via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Läs eller ändra den återställda arbetsbokens data här.
} finally {
    presentation.dispose();
}
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett undantag. Aktivera återställning endast när användning av den cachade diagramdatan är ett acceptabelt alternativ, eftersom cachen kanske inte innehåller förändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) och en [path to an external workbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); om källan är en extern arbetsbok kan du läsa hela sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektportabilitet; dock lagras den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som finns på nätverksresurser / delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Att redigera fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan bara användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Nej. Presentationen lagrar en [link to the external file](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) och använder den för att läsa data. Den externa filen i sig ändras inte när presentationen sparas.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. Ett vanligt tillvägagångssätt är att i förväg ta bort skyddet eller förbereda en avkrypterad kopia (till exempel med [Aspose.Cells](/cells/nodejs-java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data laddas.