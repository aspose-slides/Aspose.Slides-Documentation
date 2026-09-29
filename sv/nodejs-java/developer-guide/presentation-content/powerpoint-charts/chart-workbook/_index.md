---
title: Hantera diagramarbetsböcker i presentationer med JavaScript
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/nodejs-java/chart-workbook/
keywords:
- diagramarbok
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck Aspose.Slides för Node.js via Java: hantera enkelt diagramarbok i PowerPoint- och OpenDocument-format för att förenkla dina presentationsdata."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboksceller som diagramdatamärkningar, får åtkomst till kalkylblads­samlingar och specificerar datakälltyp för diagramvärden.

Den behandlar också hur man arbetar med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram, och redigerar diagramdata när arbetsboken är tillgänglig.

För arbetsboksceller som representerar saknad data, se [Control the Display of Empty Cells](/slides/sv/nodejs-java/chart-series/) för skillnaden mellan en tom cell och noll, samt en linjediagramjämförelse av de tillgängliga visningslägena.

## **Inkludera data från dolda rader och kolumner**

Använd [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) för att styra om ett diagram ritar data från dolda kalkylbladsrader och -kolumner. Sätt den till `true` för att enbart rita synliga celler, eller `false` för att inkludera både synliga och dolda celler. Denna inställning styr diagramritning; den döljer eller visar inte kalkylbladsrader eller -kolumner.

Ladda ner [hidden-source-data.pptx](hidden-source-data.pptx) och placera den i arbetskatalogen. Dess första bild innehåller ett stapeldiagram som den första formen. Det inbäddade kalkylbladet, `Sheet1`, innehåller följande källintervall, `A1:C4`. Rad 3 och kolumn C är dolda, men deras celler innehåller fortfarande värden.

| Arbetsbladsrad | A: Månad | B: Detaljhandel | C: Partihandel (dolt kolumn) |
| --- | --- | --- | --- |
| 2 | Januari | 10 | 30 |
| 3 (dold rad) | Februari | 40 | 60 |
| 4 | Mars | 20 | 50 |

Få åtkomst till källceller via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) och läs [ChartDataCell.isHidden](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#isHidden) för att inspektera deras dolda status. Denna metod rapporterar den dolda statusen utan att ändra den. I detta fil är B2 synlig, B3 tillhör den dolda raden, och C2 tillhör den dolda kolumnen; exemplet skriver ut `false`, `true` och `true` respektive.

För detta exempel, uppdatera diagramdata efter att plottningsinställningen har förändrats: behåll den inbäddade arbetsboken med [readWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) och läs in den igen med [writeWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream). När alla celler inkluderas, använd även [setRange](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#setRange) för att återställa det kompletta intervallet, inklusive den dolda februari‑kategorin. Att bara ändra flaggan räcker inte för att uppdatera detta exempels cachade diagramdata och kategorimärkningar. Exemplet konverterar den returnerade Node.js‑bufferten till en Java‑byte‑array innan den skickas till skriv‑metoden.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Uppdatera diagramdata från den inbäddade arbetsboken.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Återställ det kompletta källintervallet, inklusive dolda kategorier.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Exemplet sparar `hidden_cells_true.pptx` med endast de synliga detaljhandelsvärdena (10 och 20), och `hidden_cells_false.pptx` med alla sex värden. Bilderna nedan illustrerar de två plottningslägena. Rad 3 och kolumn C förblir dolda i båda inbäddade arbetsböckerna.

| Endast synliga celler (`true`) | Alla celler (`false`) |
| --- | --- |
| ![Endast synliga celler: Detaljhandelsvärden 10 och 20 för Januari och Mars.](hidden_cells_True.png) | ![Alla celler: Detaljhandel och Partihandelvärden för Januari, Februari och Mars.](hidden_cells_False.png) |

En dold cell som innehåller ett värde skiljer sig från en tom cell. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) styr hur saknade värden visas; den inkluderar eller exkluderar inte dold källdata. Se [Control the Display of Empty Cells](/slides/sv/nodejs-java/chart-series/#control-the-display-of-empty-cells) för ett exempel.

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides för Node.js via Java tillhandahåller metoderna [readWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) och [writeWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) som låter dig läsa och skriva diagramdataböcker (innehållande diagramdata redigerad med Aspose.Cells). **Note** att diagramdata måste organiseras på samma sätt eller ha en struktur som liknar källan.

Detta exempel öppnar `chart.pptx`, som måste innehålla ett diagram som den första formen på dess första bild. Det läser den inbäddade arbetsboken till en byte‑array, tömmer befintliga serier och kategorier, och skriver tillbaka samma arbetsbok. Ändringarna kvarstår i minnet; exemplet sparar inte presentationen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Validera diagramlayout efter arbetsboksändring**

När du ersätter en inbäddad arbetsbok med en modifierad, behåller diagrammet sina ursprungliga serie‑ och kategorisamlingar. Denna inkonsekvens kan leda till att [Chart.validateChartLayout](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/#validateChartLayout) misslyckas med ett index‑out‑of‑range‑fel. Töm befintliga serier och kategorier innan den uppdaterade arbetsboken skrivs tillbaka till diagrammet. Detta exempel kräver `chart.pptx` med ett diagram som den första formen på dess första bild. Kommentaren markerar var arbetsboksredigering skulle ske; det körbara exemplet skriver tillbaka originalarbetsboken och validerar layouten i minnet.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Ändra arbetsboksbytena här, till exempel med Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Att tömma samlingarna tar bort föråldrade datreferenser innan arbetsboken skrivs tillbaka. Bygg om eventuella nödvändiga serie‑ och kategorimappningar för den uppdaterade arbetsboken innan diagrammet används.

## **Ange en arbetsbokscell som diagramdatamärkning**

Du kan använda text från arbetsboksceller som diagramdatamärkningar. Följande steg visar hur man länkar märkningarna i ett bubbeldiagram till celler i dess datarbok.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta den första bilden via dess nollbaserade index.
3. Lägg till ett bubbeldiagram med standarddata.
4. Få åtkomst till diagramserierna.
5. Ange arbetsbokscellen som en datamärkning.
6. Spara presentationen.

Detta exempel öppnar `chart2.pptx`, som måste innehålla minst en bild, och lägger till ett bubbeldiagram med standarddata. Det använder cellerna A10:A12 på kalkylblad 0 för de första tre märkningarna i den första serien, aktiverar märkningar från celler, och sparar resultatet till `resultchart.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hantera kalkylblad**

Metoden [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) ger åtkomst till kalkylbladen i en diagramarbetsbok. Detta exempel skapar ett cirkeldiagram med standarddata och skriver ut varje kalkylbladsnamn i konsolen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Specificera datakälltyp**

Detta exempel skapar ett 3D‑stapeldiagram med standarddata och anger två serienamn med olika datakällor. Det första namnet använder en strängliteral; det andra använder cell C1 på kalkylblad 0. Uppräkningen [DataSourceType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datasourcetype/) väljer källan för varje namn. Resultatet sparas till `pres.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Detektera ej stödda inbäddade arbetsbokformat**

Aspose.Slides stödjer inte Excel‑binärarbetsboksformatet (.xlsb) som kan inbäddas i vissa diagram. Du kan använda metoden [getEmbeddedWorkbookType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) på [ChartData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/workbooktype/) för att upptäcka ej stödda format och hoppa över dessa diagram. Detta exempel inspekterar formerna på den första bilden i `sample.pptx`, hoppar över icke‑diagramformer, och skriver ut ett diagnostiskt meddelande för varje diagram med en inbäddad .xlsb‑arbetsbok.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Läs eller ändra stödjda diagramarboksdata här.
    }
} finally {
    presentation.dispose();
}
```

## **Extern arbetsbok**

Aspose.Slides stödjer att använda externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Använd [readWorkbookStream](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) och [setExternalWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) för att exportera en inbäddad diagramarbetsbok till en fil och länka diagrammet till den externa arbetsboken.

Detta exempel skapar ett cirkeldiagram med standarddata, skriver dess arbetsbok till `externalWorkbook1.xlsx`, och slutför filskrivningen innan filen tilldelas som diagrammets datakälla. Det sparar den länkade presentationen till `externalWorkbook.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Ange en extern arbetsbok**

Genom att använda metoden [setExternalWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan även användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du fortfarande använda sådana arbetsböcker som en extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

Detta exempel kräver `externalWorkbook.xlsx` i arbetskatalogen. Dess kalkylblad med namnet `Sheet1` måste innehålla ett serienamn i B1, kategorinamnen i A2:A4, och numeriska värden i B2:B4. Exemplet skapar ett cirkeldiagram, länkar arbetsboken, och använder [setRange](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#setRange) för att mappa A1:B4 till en serie och tre kategorier. Det sparar resultatet till `Presentation_with_externalWorkbook.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Parametern `updateChartData` i [setExternalWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) styr om arbetsboken laddas.

* När `updateChartData` är `false` uppdateras endast arbetsbokens sökväg. Diagramdata laddas inte eller uppdateras från målarbetsboken, så arbetsboken kan vara otillgänglig.
* När `updateChartData` är `true` uppdateras diagramdata från målarbetsboken.

Följande exempel tilldelar en platshållar‑URL med `updateChartData` satt till `false`. Det behåller cirkeldiagrammets standarddata och sparar presentationen utan att ladda den otillgängliga arbetsboken.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Hämta den externa datakällans arbetsboksökväg för ett diagram**

För att identifiera arbetsboken som är länkad till ett diagram, kontrollera först om diagrammet använder en extern datakälla. Om så är fallet kan du hämta arbetsbokens sökväg genom att följa dessa steg.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Hämta den första bilden via dess nollbaserade index.
3. Kontrollera att den första formen är ett diagram.
4. Läs diagrammets datakälltyp.
5. Om källan är en extern arbetsbok, läs dess sökväg.

Detta exempel öppnar `externalWorkbook.pptx`, skapat i det tidigare exemplet, och inspekterar den första formen på den första bilden. Om den är ett diagram länkat till en extern arbetsbok, skriver exemplet ut [getExternalWorkbookPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) i konsolen. Det sparar sedan en kopia av presentationen till `Result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Detta exempel kräver `presentation.pptx` med ett diagram som den första formen på den första bilden och en åtkomlig extern arbetsbok. Det sätter det cellbaserade värdet för den första datapunkten i den första serien till 100 och sparar presentationen till `presentation_out.pptx`. Att redigera cellvärden kan uppdatera den länkade externa XLSX‑filen, så använd en kopia om du behöver bevara originalarbetsboken.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Återskapa en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig, kan Aspose.Slides rekonstruera diagramarbetsboken från de data som cachats i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/), anropa [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), och sätt [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) till `true` innan presentationen öppnas.

Följande JavaScript‑exempel öppnar `presentation.pptx`, vars första form på den första bilden måste vara ett diagram som refererar till en otillgänglig extern arbetsbok, och får åtkomst till de återställda data via [Chart.getChartData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/#getChartData) och [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Läs eller ändra den återställda arbetsboksdatan här.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Om den externa arbetsboken är otillgänglig och återhämtning är inaktiverad, kastar Aspose.Slides ett undantag. Aktivera återhämtning endast när det är acceptabelt att använda de cachade diagramdata som en reserv, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [data source type](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#getDataSourceType) och en [path to an external workbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Presentationen lagrar den absoluta sökvägen i PPTX‑filen, så om arbetsboken flyttas kan länken behöva uppdateras.

**Kan jag använda arbetsböcker som ligger på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Däremot stöds inte redigering av fjärrarbetsböcker direkt från Aspose.Slides – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Presentationen lagrar en [link to the external file](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). Att redigera cellbaserad diagramdata kan också uppdatera den länkade lokala XLSX‑filen. Använd en kopia av arbetsboken om originalet måste förbli oförändrat.

**Vad bör jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (till exempel med [Aspose.Cells](https://reference.aspose.com/cells/java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång datan laddas.