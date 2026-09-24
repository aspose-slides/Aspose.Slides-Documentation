---
title: Hantera diagramarbetsböcker i presentationer med JavaScript
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
- återställning av arbetsbok
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck Aspose.Slides för Node.js via Java: hantera enkelt diagramarbok i PowerPoint- och OpenDocument-format för att effektivisera dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur du läser och skriver diagramdata via arbetsbok‑strömar, använder arbetsboks‑celler som diagramdatamärkningar, får åtkomst till kalkylblads‑samlingar och anger datakälltyp för diagramvärden.

Den behandlar också hur du arbetar med externa arbetsböcker som diagramdatakällor. Exemplen visar hur du skapar och tilldelar en extern arbetsbok, hämtar sökvägen för en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

För arbetsboks‑celler som representerar saknad data, se [Control the Display of Empty Cells](/slides/sv/nodejs-java/chart-series/) för skillnaden mellan en tom cell och noll samt en linjediagram‑jämförelse av de tillgängliga visningslägena.

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides tillhandahåller metoderna [readWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) och [writeWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) som låter dig läsa och skriva diagramdataböcker (som innehåller diagramdata redigerade med Aspose.Cells). **Observera** att diagramdata måste vara organiserade på samma sätt eller ha en struktur som liknar källan.

Denna JavaScript‑kod demonstrerar ett exempel:

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

När du ersätter en inbäddad arbetsbok med en modifierad behåller diagrammet sina ursprungliga serier och kategorisamlingar. Denna mismatch kan orsaka att [Chart.validateChartLayout](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Chart#validateChartLayout--) misslyckas med ett index‑out‑of‑range‑fel. Rensa de befintliga serierna och kategorierna innan du skriver den uppdaterade arbetsboken tillbaka till diagrammet.

```javascript
// Efter att ha modifierat arbetsboksströmmen (t.ex. med Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// Rensa befintliga datreferenser.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Att rensa samlingarna säkerställer att diagramdatastrukturen är konsistent med den nya arbetsboken, vilket gör att `validateChartLayout` kan slutföras utan fel.

## **Ange arbetsboks‑cell som diagramdatamärkning**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
2. Hämta en slides referens via dess index.
3. Lägg till ett bubbeldiagram med viss data.
4. Åtkomst till diagramserierna.
5. Ange arbetsboks‑cellen som en datamärkning.
6. Spara presentationen.

Denna JavaScript‑kod visar hur du anger en arbetsboks‑cell som en diagramdatamärkning:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Instansierar en presentationsklass som representerar en presentationsfil
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

## **Hantera kalkylblad**

Denna JavaScript‑kod demonstrerar en operation där metoden [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) används för att få åtkomst till en kalkylblads‑samling:

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

## **Upptäck ej stödda inbäddade arbetsboksformat**

Aspose.Slides stöder inte Excel‑binärarbetsboken (.xlsb) som kan inbäddas i vissa diagram. Du kan använda metoden `getEmbeddedWorkbookType` på [ChartData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/workbooktype/) för att upptäcka ej stödda format och hoppa över dessa diagram.

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

Aspose.Slides stödjer externa arbetsböcker som datakälla för diagram.

### **Skapa extern arbetsbok**

Med hjälp av metoderna **`readWorkbookStream`** och **`setExternalWorkbook`** kan du antingen skapa en extern arbetsbok från grunden eller göra en intern arbetsbok extern.

Denna JavaScript‑kod demonstrerar processen för att skapa en extern arbetsbok:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream returnerar arbetsbokens byte som en Node Buffer.
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

Med metoden **`setExternalWorkbook`** kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan även användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges konverteras den automatiskt till en fullständig sökväg.

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

Den andra parametern för metoden `setExternalWorkbook`, `updateChartData`, anger om Excel‑arbetsboken ska laddas eller inte.

* När `updateChartData` är satt till `false` uppdateras endast arbetsbokens sökväg – diagramdata kommer inte att laddas eller uppdateras från målarboken. Du kan vilja använda denna inställning när målarboken saknas eller är otillgänglig.
* När `updateChartData` är satt till `true` uppdateras diagramdata från målarboken.

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
2. Hämta en slides referens via dess index.
3. Skapa ett objekt för diagramformen.
4. Skapa ett objekt för källtypen (`ChartDataSourceType`) som representerar diagrammets datakälla.
5. Ange det relevanta villkoret baserat på att källtypen är densamma som den externa arbetsbokens datakälltyp.

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

Du kan redigera data i externa arbetsböcker på samma sätt som du ändrar innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

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

### **Återställ en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig kan Aspose.Slides återskapa diagramarboken från data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/), konfigurera den med [SpreadsheetOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/spreadsheetoptions/), och anropa [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) med `true` innan presentationen öppnas.

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

    // Läs eller modifiera den återställda arbetsbokens data här.
} finally {
    presentation.dispose();
}
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad kastar Aspose.Slides ett undantag. Aktivera återställning endast när det är ett acceptabelt alternativ att använda cachad diagramdata, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [datakälltyp](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektportabilitet; var dock medveten om att presentationen lagrar den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som finns på nätverksresurser/delnade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Redigering av fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Nej. Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) och använder den för att läsa data. Den externa filen ändras inte när presentationen sparas.

**Vad bör jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. En vanlig metod är att ta bort skyddet i förväg eller skapa en avkrypterad kopia (t.ex. med [Aspose.Cells](/cells/nodejs-java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av filen att återspeglas i varje diagram nästa gång datan laddas.