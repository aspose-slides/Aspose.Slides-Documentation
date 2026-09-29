---
title: Hantera diagramserier i presentationer med JavaScript
linktitle: Dataserier
type: docs
url: /sv/nodejs-java/chart-series/
keywords:
- diagramserier
- serieöverlappning
- seriefärg
- serienamn
- datapunkt
- arbetsbokscell
- serieavstånd
- negativt värde
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboksceller, formatering, överlappning, avstånd mellan staplar och negativa värden i presentationer med JavaScript."
---
## **Översikt**

Ett diagram lagrar sina plottade data i en diagramdatabok. En [ChartSeries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/) representerar en uppsättning relaterade värden, och varje [ChartDataPoint](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/) i serien refererar till en eller flera celler i arbetsboken. [ChartCategory](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartcategory/)‑objekt tillhandahåller etiketter eller grupperingvärden som delas av serierna. Serienamnet, kategorierna och punktvärdena är därför kopplade till [ChartDataCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/)‑objekt snarare än att bara lagras som visningstext.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för serienamn, kolumn 0 för kategorinamn och de resterande cellerna för serievärden. Arbetsblad, rad‑ och kolumnindex som skickas till [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#getCell) är nollbaserade. Denna layout är användbar när du skapar ett diagram med standarddata, men anta inte att varje befintligt diagram använder den. För en inläst presentation, granska cellerna som refereras av serierna, kategorierna och datapunkterna innan du ändrar arbetsbokens värden.

Diagraminställningar har tre olika omfattningar:

- Inställningar på serienivå, såsom [ChartSeries.getFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getFormat), ger standardutseendet för alla punkter i en serie.
- Inställningar på datapunkt­nivå, såsom [ChartDataPoint.getFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#getFormat), åsidosätter serieutseendet för en punkt.
- Gruppinställningar gäller kompatibla serier som tillhör samma [ChartSeriesGroup](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/). Åtkomst till gruppen sker via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) när du behöver ange alternativ som överlappning eller avstånd mellan staplar.

När ingen explicit fyllning för punkt eller serie är angiven bestämmer diagramstilen och temat det automatiska utseendet. När både serie‑ och punktformatering finns present har punktformateringen företräde för den punkten.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ange överlappning för diagramserier**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getOverlap) rapporterar hur mycket staplar eller kolumner överlappar i ett 2D‑diagram, från –100 till 100 procent. Det är en skrivskyddad projektion av inställningen på den överordnade seriegruppen. Använd [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) för att uppdatera alla kompatibla serier i den gruppen. Detta alternativ gäller diagramtyper som visar grupperade staplar eller kolumner; det påverkar inte orelaterade seriegrupper i ett kombinationsdiagram.

Följande exempel anger överlappning för gruppen som innehåller den första serien:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Det nya diagrammet innehåller exempelserier, kategorier och värden.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The series overlap](series_overlap.png)

## **Ändra fyllningsfärg för serien**

Använd [ChartSeries.getFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getFormat) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning åsidosätter dess [ChartDataPoint.getFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#getFormat) serie­fyllningen för den punkten.

Följande exempel tilldelar en enhetlig blå fyllning till den första serien:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The color of the series](series_color.png)

## **Ändra seriens namn**

Ett serienamn lagras i diagramdataboken och visas normalt i förklaringen. I standardarbetsboken som skapas för ett gruppradeldiagram ligger cell B1 på rad 0, kolumn 1 och innehåller namnet på den första serien. De namngivna konstanterna i följande exempel gör den strukturen tydlig:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Du kan också uppdatera den cell som redan refereras av [ChartSeries.getName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getName). Detta tillvägagångssätt undviker att anta en viss rad och kolumn i ett befintligt diagram:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The series name](series_name.png)

## **Hämta automatisk fyllningsfärg för serien**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) returnerar den färg som beräknas utifrån serie‑indexet och diagramstilen. Detta är den färg som används när serie­fyllningen inte har angetts explicit. Metoden läser den beräknade färgen; den tilldelar ingen ny fyllning.

Följande exempel skriver ut den automatiska färgen för varje standardserie:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Exempelsutdata för standarddiagramstilen:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Exakta färger beror på diagramstil och tema.

## **Ange inverterad fyllningsfärg för en diagramserie**

För stapel‑, kolumn‑ och bubbeldiagram kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) visa negativa värden med en annan fyllning. Ställ in den vanliga serie­fyllningen till solid, aktivera inversion och tilldela den negativa färgen via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negativa tal förblir oförändrade i arbetsboken; endast deras displayfärg ändras.

Följande exempel ersätter standarddiagramdata med en serie. Arbetsbladsrad 0 innehåller serienamnet, kolumn 0 innehåller kategorinamn, och kolumn 1 innehåller värdena:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The inverted solid fill color](inverted_solid_fill_color.png)

Du kan aktivera inversion för en enskild punkt via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). I följande exempel är inversion inaktiverad för serien och endast aktiverad för den valda punkten. Punkten tilldelas också ett negativt värde så att effekten blir synlig:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rensa ett specifikt datapunktvärde**

För att göra en punkt tom utan att ta bort de andra punkterna, sätt dess underliggande arbetsboks­cell till `null`. För ett kolumndiagram är det plottade värdet tillgängligt via [ChartDataPoint.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#getValue). Datapunkten behåller samma kategori‑position, men diagrammet behandlar dess värde som tomt enligt diagrammets inställningar för tomma värden.

Följande exempel rensar endast den andra punkten i den första serien:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Spridningsdiagram använder separata X‑ och Y‑celler, och bubbeldiagram använder också en storlekscell. Rensa bara den cell som representerar det värde du vill ta bort. Anropa inte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapointcollection/#clear) när du vill behålla de andra punkterna, eftersom den metoden tar bort alla datapunkter i samlingen.

## **Styr visning av tomma celler**

Dolda celler som innehåller värden är ett separat fall från tomma celler. För att inkludera eller exkludera data från dolda arbetsbladsrader och -kolumner, se [Include Data from Hidden Rows and Columns](/slides/sv/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

En tom arbetsboks­cell representerar saknad data; en cell som innehåller `0` representerar ett känt numeriskt värde. Anropa [ChartDataCell.setValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setValue) med `null` för att göra en cell tom. En numerisk nolla förblir nolla oavsett inställning för tomma celler.

Använd [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) för att välja hur diagrammet visar tomma celler. Denna inställning gäller för hela diagrammet. Den ändrar hur tomma värden plottas, utan att fylla den tomma arbetsboks­cellen med noll eller ett interpolerat värde.

Följande självständiga exempel skapar ett linjediagram med en serie, rensar värdet för Dag 3 och sparar diagrammet med varje läge. Ingen indatafil krävs. [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/) använder arbetsblad 0, kolumn 0 för kategorietiketter och kolumn 1 för värden; rad 0 innehåller serienamnet. Slutdata är `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Lämna Dag 3 riktigt tom, men behåll dess kategori och datapunkt.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Varje utdatafil lagrar läget som tilldelats före sparning: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` och `empty_cells_Span.pptx`. För att spara bara en version, tilldela önskat läge och spara presentationen en gång istället för att iterera över lägena.

Jämförelsen nedan visar samma data i alla tre filer. Dag 3 är tom i arbetsboken i alla fall:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Den synliga effekten beror på diagramtyp. Ett linjediagram gör alla tre lägen enkla att jämföra. Stapel‑ och kolumndiagram har ingen linje att koppla över en saknad kategori, så `Span` kan inte skapa den föreställda förbindelsen; en saknad kolumn och en kolumn med nollhöjd kan också se lika ut. På samma sätt har ett spridningsdiagram med endast markörer ingen förbindande linje. Förvänta dig inte tre distinkta resultat för varje diagramtyp; kontrollera utdata för den typ du använder.

## **Ange avstånd mellan stapel‑/kolumnkluster**

Avståndet (gap width) är utrymmet mellan intilliggande stapel‑ eller kolumnkluster, uttryckt i procent av stapel‑ eller kolumnbredden. Precis som överlappning tillhör det den överordnade seriegruppen snarare än en enskild serie. Anropa [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) en gång för gruppen. Ett större värde skapar mer utrymme mellan klustren; ett mindre värde gör dem tätare.

Följande exempel ändrar avståndet och sparar endast den slutgiltiga presentationen:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The gap width](gap_width.png)

## **FAQ**

**Vilka diagramtyper stöder dataserier?**

Alla diagramtyper som representeras av [ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/)-enumerationen använder diagramdata, men deras serier har inte alla samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram använder X‑ och Y‑värden, och bubbeldiagram lägger till bubbelformer. Använd den datapunkt‑skapande metod som motsvarar serietypen. Alternativ som överlappning och avstånd mellan staplar gäller endast kompatibla stapel‑ eller kolumngrupper.

**Vad är en diagramseriegrupp?**

En [ChartSeriesGroup](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/) innehåller kompatibla serier som delar gruppnivåinställningar för plotning. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen som nås via en serie förändrar inte nödvändigtvis alla serier i diagrammet.

**Innehåller ett nyss skapat diagram standarddata?**

Ja. Som standard skapar [ShapeCollection.addChart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addChart) exempelserier, kategorier och värden. Du kan redigera dessa celler eller rensa både serie‑ och kategorisamlingarna innan du lägger till en helt anpassad datamängd. En överlagring kan också skapa ett diagram utan standarddata.

**Hur kopplas diagramobjekt till arbetsboks­celler?**

Serienamn, kategori‑etiketter och datapunktvärden refererar till celler i en [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/). Att ändra en refererad cell uppdaterar motsvarande diagramdel. När du bygger anpassad data, håll kategorirader och serie‑värderader i linje så att varje punkt plottas under rätt kategori.

**Hur rensar jag en punkt utan att rensa hela serien?**

Sätt den relevanta värdecellen till `null` för att behålla punktens kategori­position som en tom punkt. Använd [ChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapointcollection/#clear) endast när du avser att ta bort alla punkter från den serien. Om du också tar bort kategorier, uppdatera varje serie så att deras värden förblir i linje med kategori­samlingen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtyp och värdet som konfigurerats via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Stödda diagram kan visa tomma värden som luckor, som nollvärden eller genom att förena närliggande punkter. Välj den inställning som matchar betydelsen av saknad data i din presentation. Se [Control the Display of Empty Cells](#control-the-display-of-empty-cells) för ett komplett exempel och visuell jämförelse.

**Hur formateras negativa värden?**

För stödjade stapel‑, kolumn‑ och bubbeldiagram, anropa [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) och ange färgen som returneras av [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Du kan åsidosätta beteendet för en enskild punkt med [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Dessa metoder påverkar formateringen, inte de lagrade numeriska värdena.

**Vilken formatering har företräde när både en serie och en punkt är formaterade?**

Explicita datapunkt‑formateringar har företräde för den punkten. Andra punkter fortsätter att använda den explicita serieformaten eller, när serieformatet inte är definierat, den automatiska diagramstilen och temat. Gruppinställningar som överlappning och avstånd mellan staplar styr layout och är inte formateringsåsidosättningar på punktnivå.

**Finns det någon gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides påtvingar ingen separat fast gräns för antalet serier. I praktiken bestäms en praktisk gräns av presentationsfilens begränsningar, tillgängligt minne, renderingtid och diagrammets läsbarhet.

**Vad bör jag ändra när kolumner är för nära varandra eller för långt ifrån?**

Anropa [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) på den relevanta överordnade seriegruppen. Öka värdet för att bredda avståndet mellan kluster, eller minska det för att föra klustren närmare varandra.