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
description: "Upptäck Aspose.Slides för Node.js via Java: hantera enkelt diagramarböcker i PowerPoint- och OpenDocument-format för att effektivisera dina presentationsdata."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsboksströmmar, använder arbetsboks-celler som diagramdatamärkningar, får åtkomst till arbetsbladsamlingar och anger datakälltyp för diagramvärden.

Den täcker också arbete med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig.

För arbetsboks-celler som representerar saknad data, se [Styr visning av tomma celler](/slides/sv/nodejs-java/chart-series/) för skillnaden mellan en tom cell och noll, samt en linjediagramsjämförelse av de tillgängliga visningslägena.

## **Inkludera data från dolda rader och kolumner**

Använd [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) för att styra om ett diagram ritar data från dolda arbetsbladsrader och -kolumner. Sätt den till `true` för att rita endast synliga celler, eller `false` för att inkludera både synliga och dolda celler. Denna inställning styr diagramritning; den döljer eller visar inte arbetsbladsrader eller -kolumner.

Den [exempelpresentation](hidden-source-data.pptx) innehåller ett stapeldiagram som den första formen på dess första bild. Det inbäddade arbetsbladet, `Sheet1`, innehåller följande källområde, `A1:C4`. Rad 3 och kolumn C är dolda, men deras celler innehåller fortfarande värden.

| Arbetsbladsrad | A: Månad | B: Detaljhandel | C: Partihandel (dold kolumn) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (dold rad) | februari | 40 | 60 |
| 4 | mars | 20 | 50 |

Få åtkomst till källceller via [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) och läs [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) för att undersöka deras dolda status. Denna metod rapporterar den dolda statusen utan att ändra den. I den här filen är B2 synlig, B3 tillhör den dolda raden, och C2 tillhör den dolda kolumnen; exemplet skriver ut `false`, `true` och `true` respektive.

För det här exemplet, uppdatera diagramdata efter att ha ändrat ritinställningen: behåll den inbäddade arbetsboken med [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) och läs in den igen med [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). När alla celler inkluderas, använd också [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) för att återställa hela området, inklusive den dolda februari-kategorin. Att bara ändra flaggan räcker inte för att uppdatera detta exempels cachelagrade diagramdata och kategorimärkningar. Exemplet konverterar den returnerade Node.js‑bufferten till en Java‑byte‑array innan den skickas till skrivmetoden.

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
                // Återställ hela källområdet, inklusive dolda kategorier.
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

Exemplet sparar två versioner av presentationen: en med endast de synliga detaljhandelsvärdena (10 och 20), och en med alla sex värden. Bilderna nedan illustrerar de två ritlägena. Rad 3 och kolumn C förblir dolda i båda inbäddade arbetsböckerna.

| Endast synliga celler (`true`) | Alla celler (`false`) |
| --- | --- |
| ![Endast synliga celler: Detaljhandelsvärden 10 och 20 för januari och mars.](hidden_cells_True.png) | ![Alla celler: Detaljhandels- och partihandelsvärden för januari, februari och mars.](hidden_cells_False.png) |

En dold cell som innehåller ett värde är annorlunda än en tom cell. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) styr hur saknade värden visas; den inkluderar eller exkluderar inte dold källdata. Se [Styr visning av tomma celler](/slides/sv/nodejs-java/chart-series/#control-the-display-of-empty-cells) för ett exempel.

## **Hämta ett diagrams dataområde**

Innan du uppdaterar arbetsboksdata i en befintlig presentation, inspektera källområdena för att identifiera vilka arbetsblads-celler varje diagram använder. Metoden [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) returnerar det aktuella dataområdet som en arbetsblads‑kvalificerad formel, t.ex. `Sheet1!$A$1:$D$5`. Här är `Sheet1` arbetsbladsnamnet, `!` separerar det från cellområdet, och `$A$1:$D$5` identifierar cellerna A1 till D5, inklusivt. Dollartecknen indikerar absoluta rad‑ och kolumnreferenser.

Metoden läser det aktuella området utan att ändra diagrammet eller dess arbetsbok. Om diagrammet inte använder en arbetsbok som datakälla kastas `InvalidOperationException`. För mer information, se [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/).

Detta exempel öppnar en presentation och kontrollerar formerna direkt på varje bild för diagram. Det skriver ut varje diagramnamn och källområde. Om ett diagram inte använder en arbetsbok, skriver det ett meddelande och fortsätter till nästa diagram.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides for Node.js via Java tillhandahåller [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) och [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) metoder som låter dig läsa och skriva diagramdataarbetsböcker (innehållande diagramdata redigerad med Aspose.Cells). **Obs** att diagramdata måste vara organiserad på samma sätt eller ha en liknande struktur som källan.

Detta exempel använder en presentation med ett diagram som den första formen på dess första bild. Det läser den inbäddade arbetsboken till en byte‑array, rensar befintliga serier och kategorier, och skriver tillbaka samma arbetsbok. Ändringarna kvarstår i minnet; exemplet sparar inte presentationen.

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

### **Validera diagramlayout efter arbetsboksmodifiering**

När du ersätter en inbäddad arbetsbok med en modifierad, behåller diagrammet sina ursprungliga serie‑ och kategori‑samlingar. Denna mismatch kan orsaka att [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) misslyckas med ett index‑out‑of‑range‑fel. Rensa de befintliga serierna och kategorierna innan du skriver tillbaka den uppdaterade arbetsboken till diagrammet. Detta exempel använder ett diagram som är den första formen på den första bilden. Kommentaren markerar var arbetsboksredigering skulle ske; det körbara exemplet skriver tillbaka den ursprungliga arbetsboken och validerar layouten i minnet.

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

        // Modifiera arbetsboksbytarna här, till exempel med Aspose.Cells.

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

Rensning av samlingarna tar bort föråldrade datareferenser innan arbetsboken skrivs tillbaka. Bygg om eventuella nödvändiga serie‑ och kategori‑mappningar för den uppdaterade arbetsboken innan diagrammet används.

## **Ange anpassade talformat för arbetsboks-celler**

Använd [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) för att styra hur numeriska värden visas i ett diagrams inbäddade arbetsbok. Till exempel kan en rapport behöva ett konverteringsvärde visat som procent med fyra decimaler och en koefficient visas med fem decimaler. Behåll båda värdena som numeriska så att de förblir tillgängliga för beräkningar och diagramritning.

Ett talformat ändrar visningen, inte det lagrade värdet. Formatet `0.0000%` visar `0.125` som `12.5000%`; det ersätter inte det lagrade numret med `12.5`. På samma sätt visar `0.00000` `0.1234567` som `0.12346` utan att runda det lagrade värdet. Om det anpassade formatet är en tom sträng (`""`) används formatet som returneras av [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) i stället.

Följande exempel skapar ett stapeldiagram och får åtkomst till dess celler via [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). På arbetsblad 0 innehåller B2 konverteringsgraden och C2 koefficienten. Båda cellerna levererar diagramvärden. Exemplet aktiverar också värdemärkningar länkade till källformaten.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Arbetsboks‑celformat är separata från format som sätts direkt på diagramaxlar eller datamärkningar. I detta exempel visar varje märke värdet från sin källcell eftersom [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) är satt till `true`, och följer källans talformat eftersom [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) är satt till `true`. Efter att presentationen sparats och öppnats igen visar märkena `12.5000%` och `0.12346`, som visas nedan. Den vertikala axeln använder sitt eget talformat, tilldelat med [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) som `0.00`, med [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) satt till `false`.

För att formatera en datamärkning oberoende, sätt dess käll‑länka‑flagga till `false` och tilldela ett format med [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). Detta ändrar inte arbetsboks‑cellens format. Till exempel visar ett oberoende märkesformat `0.00` det första värdet som `0.13`, medan B2 fortfarande visar `12.5000%`. Se [Chart Data Labels](/slides/sv/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) för direkt märkesformatering.

Bilden nedan renderades från den sparade presentationen efter att den öppnats igen:

![Stapeldiagram med käll‑länkade märken som visar 12.5000% och 0.12346 samt en oberoende formaterad numerisk axel.](custom-cell-formats.png)

## **Ange en arbetsboks-cell som diagramdatamärkning**

Du kan använda text från arbetsboks-celler som diagramdatamärkningar.

Detta exempel lägger till ett bubbeldiagram med standarddata på den första bilden i en befintlig presentation. Det använder cellerna A10:A12 på arbetsblad 0 för de tre första märkena i den första serien, aktiverar märken från celler och sparar den uppdaterade presentationen.

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

## **Hantera arbetsblad**

Metoden [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) ger åtkomst till arbetsbladen i ett diagramarbetsbok. Detta exempel skapar ett sektordiagram med standarddata och skriver ut varje arbetsbladsnamn till konsolen.

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

## **Ange datakälltyp**

Serievärden kan också lagras direkt som numeriska litteraler. Se [Ange serievärden med numeriska litteraler](/slides/sv/nodejs-java/chart-series/#set-series-values-using-numeric-literals) för ett komplett exempel som sparar och läser dem. Källdatatypen för punktvärden är separat från diagrammets interna eller externa arbetsboks‑konfiguration; att använda numeriska litteraler tar inte bort den inbäddade arbetsboken.

Detta exempel skapar ett 3D‑stapeldiagram med standarddata och sätter två serienamn med olika datakällor. Det första namnet använder en sträng‑litteral; det andra använder cell C1 på arbetsblad 0. Upplagan [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) väljer källan för varje namn. Exemplet sparar presentationen med de uppdaterade serienamnen.

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

## **Detektera ej stödda inbäddade arbetsboksformat**

Aspose.Slides stöder inte Excel‑binärarbetsboksformatet (.xlsb) som kan vara inbäddat i vissa diagram. Du kan använda `getEmbeddedWorkbookType`‑metoden på [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) tillsammans med uppräkningen [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) för att upptäcka ej stödda format och hoppa över de diagrammen. Detta exempel inspekterar formerna på den första bilden i en befintlig presentation, hoppar över former som inte är diagram och skriver ut ett diagnostiskt meddelande för varje diagram med en inbäddad .xlsb‑arbetsbok.

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

        // Läs eller modifiera stödd diagramarboksdata här.
    }
} finally {
    presentation.dispose();
}
```

## **Extern arbetsbok**

Aspose.Slides stöder att använda externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Använd [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) och [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) för att exportera en inbäddad diagramarbetsbok till en fil och länka diagrammet till den externa arbetsboken.

Detta exempel skapar ett sektordiagram med standarddata och exporterar dess arbetsbok. Det slutför filskrivningen innan den externa arbetsboken tilldelas som diagrammets datakälla, och sparar sedan den länkade presentationen.

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

Genom att använda [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera en sökväg till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan sådana arbetsböcker ändå användas som extern datakälla. Om en relativ sökväg för en extern arbetsbok anges konverteras den automatiskt till en fullständig sökväg.

Detta exempel använder en extern arbetsbok där arbetsbladet `Sheet1` innehåller ett serienamn i B1, kategorinamnen i A2:A4 och numeriska värden i B2:B4. Exemplet skapar ett sektordiagram, länkar arbetsboken och använder [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) för att mappa A1:B4 till en serie och tre kategorier. Det sparar presentationen med det länkade diagrammet.

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

Parametern `updateChartData` för [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) styr om arbetsboken laddas.

* När `updateChartData` är `false` uppdateras endast arbetsbokens sökväg. Diagramdata laddas inte eller uppdateras från målarbetsboken, så arbetsboken kan vara otillgänglig.
* När `updateChartData` är `true` uppdateras diagramdata från målarbetsboken.

Följande exempel tilldelar en platshållar‑URL med `updateChartData` satt till `false`. Det behåller sektordiagrammets standarddata och sparar presentationen utan att ladda den otillgängliga arbetsboken.

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

För att identifiera arbetsboken som är länkad till ett diagram, kontrollera om diagrammet använder en extern datakälla och hämta dess arbetsboksökväg.

Detta exempel inspekterar den första formen på den första bilden i en presentation med en länkad extern arbetsbok. Om det är ett diagram som är länkat till en extern arbetsbok, skriver exemplet ut [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) till konsolen. Det sparar sedan en kopia av presentationen.

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

Detta exempel använder ett diagram som är den första formen på den första bilden och som är länkat till en åtkomlig extern arbetsbok. Det sätter det cell‑stödda värdet för den första datapunkten i den första serien till 100 och sparar den uppdaterade presentationen. Redigering av cellvärden kan uppdatera den länkade externa XLSX‑filen, så använd en kopia om du måste bevara den ursprungliga arbetsboken.

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

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig, kan Aspose.Slides rekonstruera diagramarbetsboken från den data som cachas i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), anropa [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/), och sätt [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) till `true` innan du öppnar presentationen.

Följande JavaScript‑exempel återställer arbetsboksdata för ett diagram som är den första formen på den första bilden och refererar till en otillgänglig extern arbetsbok. Det får åtkomst till den återställda data via [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) och [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // Läs eller modifiera den återställda arbetsboksdata här.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad, kastar Aspose.Slides ett undantag. Aktivera återställning endast när användning av cachelagrad diagramdata är ett acceptabelt fallback‑alternativ, eftersom cachen kanske inte innehåller förändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [datakälltyp](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att försäkra dig om att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du specificerar en relativ sökväg konverteras den automatiskt till en absolut sökväg. Presentationen lagrar den absoluta sökvägen i PPTX‑filen, så flytt av arbetsboken kan kräva att länken uppdateras.

**Kan jag använda arbetsböcker som ligger på nätverksresurser/delade mappar?**

Ja, sådana arbetsböcker kan användas som extern datakälla. Redigering av fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX-filen när presentationen sparas?**

Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Redigering av cell‑stödd diagramdata kan också uppdatera den länkade lokala XLSX‑filen. Använd en kopia av arbetsboken om originalet måste förbli oförändrat.

**Vad bör jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inget lösenord vid länkning. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller förbereda en avkrypterad kopia (t.ex. med [Aspose.Cells](https://reference.aspose.com/cells/java/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av den filen att återspeglas i varje diagram nästa gång data laddas.