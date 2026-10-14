---
title: Anpassa cirkeldiagram i presentationer med JavaScript
linktitle: Cirkeldiagram
type: docs
url: /sv/nodejs-java/pie-chart/
keywords:
- cirkeldiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- segmentfärg
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och anpassa cirkeldiagram i JavaScript med Aspose.Slides för Node.js via Java. Konfigurera sekundära diagram, visa dataetiketter och tillämpa automatiska segmentfärger i PowerPoint."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med cirkeldiagram i Aspose.Slides. Den visar hur man konfigurerar sekundära diagramalternativ för Pie of Pie- och Bar of Pie-diagram, samt hur man aktiverar automatisk färgläggning av segment för ett standardcirkeldiagram.

Exemplen fokuserar på anpassningsuppgifter för diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med egna kategorier och värden, samt spara den uppdaterade presentationen.

## **Sekundära diagramalternativ för Pie of Pie- och Bar of Pie-diagram**

Aspose.Slides för Node.js via Java stöder sekundära diagramalternativ för Pie of Pie- och Bar of Pie-diagram. Dessa alternativ styr storleken på det sekundära diagrammet och hur datapunkter fördelas mellan de två diagrammen.

Följande exempel skapar ett Pie of Pie-diagram i en ny presentation och visar datapunktvärden som etiketter. Metoden [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) ställer in storleken på det sekundära diagrammet till 149% av huvuddiagrammet. [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) väljer procentbaserad uppdelning, och [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) sätter tröskeln till 53%.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // Visa värden och konfigurera det sekundära diagrammet.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Välj kategorier för det sekundära diagrammet**

Använd anpassad uppdelning när du vill gruppera specifika kategorier i det sekundära diagrammet oavsett deras procentvärden. Till exempel kan en försäljningsrapport visa Online och Events tillsammans så att läsarna kan jämföra dessa två kanaler, även om de utgör 35% respektive 10% av den totala försäljningen.

Anropa [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) med [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) och välj punkterna via [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Samlingens [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add)-metod accepterar ett nollbaserat index i serien; använd [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) för att lägga till ett datapunktobjekt. I detta exempel väljer index 1 Online, och punkten på index 3 väljer Events. Partners läggs också till tillfälligt, och tas sedan bort med [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // Ersätt standarddata med försäljning per kanal.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Välj Online med dess nollbaserade index och Events med dess datapunktobjekt.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Exkludera Partners från urvalet utan att ta bort dess källdata.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) och Events (10) visas som separata segment i det sekundära diagrammet. I huvuddiagrammet representeras de av ett kombinerat segment med värdet 45, tillsammans med Retail (40) och Partners (15). Att ta bort Partners från den anpassade urvalet behåller det i huvuddiagrammet; det tar inte bort kategorin eller dess värde från diagrammets källdata.

Följande bild visar den sparade presentationen i PowerPoint:

![Pie of Pie-diagram med Online och Events i det sekundära diagrammet och deras kombinerade värde 45 i huvuddiagrammet](pie_of_pie_custom.png)

## **Ställ in automatisk färgläggning av cirkeldiagramsegment**

Aspose.Slides för Node.js via Java kan automatiskt tilldela olika färger till cirkeldiagramsegment. Följande exempel skapar ett cirkeldiagram med en centrerad titel och ersätter standarddata med tre kvartalskategorier och deras värden. Metoden [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) visar värdena 20, 50 och 30 som etiketter, medan [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) möjliggör en unik färg för varje segment.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // Lägg till en centrerad diagramtitel.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Ersätt standarddata med det första kalkylbladet.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Visa värden och tilldela olika färger till segmenten.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Stöds variationerna Pie of Pie och Bar of Pie?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ett sekundärt diagram för cirkeldiagram, inklusive typerna Pie of Pie och Bar of Pie.

**Kan jag exportera bara diagrammet som en bild (t.ex. PNG)?**

Ja, du kan [exportera diagrammet som en bild](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (t.ex. PNG) utan att exportera hela presentationen.