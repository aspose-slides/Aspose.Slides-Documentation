---
title: Hantera diagramarbetsböcker i presentationer med JavaScript
linktitle: Diagramarbetsbok
type: docs
weight: 70
url: /sv/nodejs-java/chart-workbook/
keywords:
- diagramarbetsbok
- diagramdata
- arbetsbokscell
- datamärkning
- arbetsblad
- datakälla
- extern arbetsbok
- extern data
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck Aspose.Slides för Node.js via Java: hantera diagramarbetsböcker i PowerPoint- och OpenDocument-format enkelt för att effektivisera dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur du läser och skriver diagramdata via arbetsbokströmmen, använder arbetsboksceller som diagramdatamärkning, får åtkomst till arbetsbladsamlingar och specificerar datakälltyp för diagramvärden.

Den behandlar också hur du arbetar med externa arbetsböcker som diagramdatakällor. Exemplen visar hur du skapar och tilldelar en extern arbetsbok, hämtar sökvägen för en extern arbetsbok som är länkat till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides tillhandahåller metoderna [readWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) och [writeWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) som låter dig läsa och skriva diagramdataböcker (som innehåller diagramdata redigerad med Aspose.Cells). **Obs** att diagramdata måste organiseras på samma sätt eller ha en struktur som liknar källan.

Denna JavaScript‑kod demonstrerar ett exempel på en operation:

```javascript
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

## **Ange WorkBook Cell som Chart DataLabel**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Hämta en slides referens via dess index.
1. Lägg till ett Bubble chart med några data.
1. Få åtkomst till chart series.
1. Ange workbook cell som en DataLabel.
1. Spara presentationen.

Denna JavaScript‑kod visar hur du anger en workbook‑cell som en Chart DataLabel:

```javascript
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

## **Hantera arbetsblad**

Denna JavaScript‑kod demonstrerar en operation där metoden [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) används för att få åtkomst till en samling av arbetsblad:

```javascript
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

## **Specificera datakälltyp**

Denna JavaScript‑kod visar hur du specificerar en typ för en datakälla:

```javascript
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

## **Upptäcka ej stödda inbäddade arbetsboksformat**

Aspose.Slides stödjer inte Excel‑binärarbetsboksformatet (.xlsb) som kan vara inbäddat i vissa diagram. Du kan använda metoden `getEmbeddedWorkbookType` på [ChartData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/workbooktype/) för att upptäcka ej stödda format och hoppa över dessa diagram.

```js
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

        // Läs eller redigera diagramarbetsbokens data här.
    }
} finally {
    presentation.dispose();
}
```

## **Extern arbetsbok**

Aspose.Slides stödjer externa arbetsböcker som datakälla för diagram.

### **Skapa extern arbetsbok**

Med metoderna **`readWorkbookStream`** och **`setExternalWorkbook`** kan du antingen skapa en extern arbetsbok från grunden eller göra en intern arbetsbok extern.

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
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

Med metoden **`setExternalWorkbook`** kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

```javascript
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

`ChartData`‑parametern (under `setExternalWorkbook`‑metoden) används för att ange om en Excel‑arbetsbok ska laddas eller inte. 

* När `ChartData`‑värdet sätts till `false` uppdateras endast arbetsbokens sökväg – diagramdata laddas inte och uppdateras inte från målarbetsboken. Du kan vilja använda denna inställning när målarbetsboken saknas eller är otillgänglig. 
* När `ChartData`‑värdet sätts till `true` uppdateras diagramdata från målarbetsboken.

```javascript
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

### **Hämta diagrammets externa datakällas arbetsbokssökväg**

1. Skapa en instans av klassen [Presentation](https://apireference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
1. Hämta en slides referens via dess index.
1. Skapa ett objekt för diagramformen.
1. Skapa ett objekt för källtypen (`ChartDataSourceType`) som representerar diagrammets datakälla.
1. Ange det relevanta villkoret baserat på att källtypen är densamma som den externa arbetsbokens datakälltyp.

Denna JavaScript‑kod demonstrerar operationen:

```javascript
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

## **Vanliga frågor**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller inbäddad arbetsbok?**

Ja. Ett diagram har en [datakälltyp](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Detta är praktiskt för projektportabilitet; var dock medveten om att presentationen lagrar den absoluta sökvägen i PPTX‑filen.

**Kan jag använda arbetsböcker som finns på nätverksresurser/‑delningar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Redigering av fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som källa.

**Överskriver Aspose.Slides den externa XLSX‑filen när presentationen sparas?**

Nej. Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) och använder den för att läsa data. Den externa filen modifieras inte när presentationen sparas.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. En vanlig metod är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](/cells/nodejs-java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av filen att återspeglas i varje diagram nästa gång data läses.