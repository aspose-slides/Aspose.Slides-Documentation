---
title: Hantera diagramdataserier i presentationer med JavaScript
linktitle: Dataserier
type: docs
url: /sv/nodejs-java/chart-series/
keywords:
- diagramserie
- serieöverlappning
- seriefärg
- serienamn
- datapunkt
- arbetsbokscell
- seriemellanrum
- negativt värde
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboksceller, formatering, överlappning, mellanrum och negativa värden i presentationer med JavaScript."
---
## **Översikt**

Ett diagram lagrar sina plottade data i en diagramdatabok. En [ChartSeries](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/) representerar en uppsättning relaterade värden, och varje [ChartDataPoint](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/) i serien refererar till en eller flera celler i arbetsboken. [ChartCategory](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartcategory/) -objekt tillhandahåller etiketter eller grupperingvärden som delas av serierna. Serienamnet, kategorierna och punktvärdena är därför kopplade till [ChartDataCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/) -objekt snarare än att bara lagras som visningstext.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för serienamnen, kolumn 0 för kategorinamnen och de återstående cellerna för serievärdena. Arbetsblad, rad- och kolumnindex som skickas till [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/#getCell) är nollbaserade. Denna layout är användbar när du skapar ett diagram med standarddata, men anta inte att alla befintliga diagram använder den. För en inläst presentation, inspektera cellerna som refereras av serierna, kategorierna och datapunkterna innan du ändrar arbetsbokens värden.

Diagraminställningar har tre olika omfattningar:

- Inställningar på serienivå, såsom [ChartSeries.getFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getFormat), ger standardutseendet för alla punkter i en serie.
- Inställningar för datapunkter, såsom [ChartDataPoint.getFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#getFormat), åsidosätter serieutseendet för en punkt.
- Gruppinställningar gäller för kompatibla serier som tillhör samma [ChartSeriesGroup](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/). Åtkomst till gruppen sker via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) när du behöver ställa in alternativ som överlappning eller mellanrum.

När ingen explicit punkt- eller seriefyllning är angiven bestämmer diagramstilen och temat det automatiska utseendet. När både serie- och punktformatering finns, har punktformateringen företräde för den punkten.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ställ in diagramseriens överlappning**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getOverlap) rapporterar hur mycket staplar eller kolumner överlappar i ett 2D-diagram, från -100 till 100 procent. Det är en skrivskyddad projektion av inställningen på den överordnade seriegrouppen. Använd [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) för att uppdatera alla kompatibla serier i den gruppen. Detta alternativ gäller för diagramtyper som visar grupperade staplar eller kolumner; det påverkar inte orelaterade seriegupper i ett kombinationsdiagram.

Följande exempel ställer in överlappningen för den grupp som innehåller den första serien:

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

## **Ändra seriefyllningsfärg**

Använd [ChartSeries.getFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getFormat) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning, åsidosätter dess [ChartDataPoint.getFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#getFormat)‑inställning seriefyllningen för den punkten.

Följande exempel applicerar en solid blå fyllning på den första serien:

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

## **Ändra serienamn**

Ett serienamn lagras i diagramdataboken och visas normalt i förklaringen. I standardarbetsboken som skapas för ett klustrat kolumndiagram ligger cell B1 på rad 0, kolumn 1 och innehåller namnet på den första serien. De namngivna konstanterna i följande exempel gör den strukturen explicit:

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

Du kan också uppdatera cellen som redan refereras av [ChartSeries.getName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getName). Detta tillvägagångssätt undviker att anta en specifik rad och kolumn i ett befintligt diagram:

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

## **Hämta automatisk seriefyllnadsfärg**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) returnerar färgen som beräknas från serieindexet och diagramstilen. Detta är färgen som används när seriefyllningen inte har definierats explicit. Att anropa metoden läser den beräknade färgen; den tilldelar ingen ny fyllning.

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

Exempelutdata för standarddiagramstilen:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exakta färgerna beror på diagramstilen och temat.

## **Ställ in inverterad fyllningsfärg för en diagramserie**

För stapel-, kolumn- och bubbla‑serier kan [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) visa negativa värden med en annan fyllning. Ställ in den vanliga seriefyllningen till solid, aktivera inversion och tilldela färgen för negativa värden via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Negativa tal förblir oförändrade i arbetsboken; endast deras displayfärg ändras.

Följande exempel ersätter standarddiagramdata med en serie. Arbetsbladets rad 0 innehåller serienamnet, kolumn 0 innehåller kategorinamnen och kolumn 1 innehåller värdena:

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

Du kan aktivera inversion för en punkt via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). I följande exempel är inversion inaktiverad för serien och endast aktiverad för den valda punkten. Punkten tilldelas också ett negativt värde så att effekten är synlig:

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

För att göra en punkt tom utan att ta bort de andra punkterna, sätt dess underliggande arbetsboks cell till `null`. För ett kolumndiagram är det plottade värdet tillgängligt via [ChartDataPoint.getValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#getValue). Datapunkten förblir på samma kategori‑position, men diagrammet behandlar dess värde som tomt enligt diagrammets tomma‑värde-inställningar.

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

Spridningsdiagram använder separata X- och Y‑celler, och bubbeldiagram använder också en storlekscell. Rensa endast den cell som representerar värdet du vill ta bort. Anropa inte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapointcollection/#clear) när du vill behålla de andra punkterna, eftersom den metoden tar bort alla datapunkter från samlingen.

## **Styr visning av tomma celler**

En tom arbetsboks‑cell representerar saknad data; en cell som innehåller `0` representerar ett känt numeriskt värde. Anropa [ChartDataCell.setValue](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatacell/#setValue) med `null` för att göra en cell tom. En numerisk nolla förblir en nolla oavsett inställningen för tomma celler.

Använd [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) för att välja hur diagrammet visar tomma celler. Denna inställning gäller för hela diagrammet. Den ändrar hur tomma värden plottas, utan att fylla den tomma arbetsboks‑cellen med noll eller ett interpolerat värde.

Följande fristående exempel skapar ett linjediagram med en serie, rensar värdet för Dag 3 och sparar samma diagram med varje läge. Ingen indatafil krävs. [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/) använder arbetsblad 0, kolumn 0 för kategorietiketter och kolumn 1 för värden; rad 0 håller serienamnet. Slutdatat är `10, 20, empty, 30, 40`.

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

    // Lämna dag 3 faktiskt tom, men behåll dess kategori och datapunkt.
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

Jämförelsen nedan visar samma data i alla tre filerna. Dag 3 är tom i arbetsboken i varje fall:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Den synliga effekten beror på diagramtypen. Ett linjediagram gör alla tre lägen lätta att jämföra. Stapel- och kolumndiagram har ingen linje att koppla över en saknad kategori, så `Span` kan inte producera den anslutande sektionen som visas ovan; en saknad kolumn och en kolumn med nollhöjd kan också se likadana ut. På samma sätt har ett spridningsdiagram med enbart markörer ingen anslutande linje. Förvänta dig inte tre distinkta resultat för varje diagramtyp; kontrollera resultatet för den typ du använder.

## **Ställ in serie‑mellanrum (gap width)**

Mellanrum (gap width) är avståndet mellan intilliggande stapel‑ eller kolumnkluster, uttryckt som en procentandel av stapel‑ eller kolumnbredden. Liksom överlappning tillhör det den överordnade seriegrouppen snarare än en enskild serie. Anropa [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) en gång för gruppen. Ett större värde skapar mer avstånd mellan klustren; ett mindre värde gör dem tätare.

Följande exempel ändrar mellanrummet och sparar endast den slutliga presentationen:

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

Alla diagramtyper som representeras av uppräkningen [ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/) använder diagramdata, men deras serier har inte alla samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram använder X‑ och Y‑värden, och bubbeldiagram lägger till bubbeltstorlekar. Använd den datapunkts‑skapande metoden som matchar serietypen. Alternativ som överlappning och mellanrum gäller endast för kompatibla stapel‑ eller kolumngrupper.

**Vad är en diagramseriegrupp?**

En [ChartSeriesGroup](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/) innehåller kompatibla serier som delar gruppnivå‑plottinginställningar. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen som nås via en serie ändrar inte nödvändigtvis alla serier i diagrammet.

**Innehåller ett ny‑skapat diagram standarddata?**

Ja. Som standard skapar [ShapeCollection.addChart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addChart) exempelserier, kategorier och värden. Du kan redigera dessa celler eller rensa både serie‑ och kategori‑samlingarna innan du lägger till en helt anpassad datamängd. En överlagring kan också skapa ett diagram utan standarddata.

**Hur är diagramobjekt kopplade till arbetsbokens celler?**

Serienamn, kategorietiketter och datapunktvärden refererar till celler i en [ChartDataWorkbook](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdataworkbook/). Att ändra en refererad cell uppdaterar motsvarande diagramelement. När du bygger anpassad data, håll kategorirader och serie‑värderader i linje så att varje punkt plottas under den avsedda kategorin.

**Hur rensar jag en punkt istället för hela serien?**

Sätt den relevanta värdecellen till `null` för att behålla punktens kategori­position som en tom punkt. Använd [ChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapointcollection/#clear) endast när du avser att ta bort alla punkter från den serien. Om du också tar bort kategorier, uppdatera alla serier så att deras värden förblir i linje med kategori‑samlingen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtypen och det värde som konfigurerats via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs). Stödda diagram kan visa tomrum som luckor, som nollvärden eller genom att ansluta intilliggande punkter. Välj den inställning som matchar betydelsen av saknad data i din presentation. Se [Control the Display of Empty Cells](#control-the-display-of-empty-cells) för ett komplett exempel och visuell jämförelse.

**Hur formateras negativa värden?**

För stödda stapel‑, kolumn‑ och bubbla‑serier, anropa [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) och ange färgen som returneras av [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Du kan åsidosätta beteendet för en enskild punkt med [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Dessa metoder påverkar formatering, inte de lagrade numeriska värdena.

**Vilken formatering har företräde när både en serie och en punkt är formaterade?**

Explicit datapunktformatering har företräde för den punkten. Andra punkter fortsätter att använda den explicita serieformatet eller, när serieformatet inte är definierat, den automatiska diagramstilen och temat. Gruppinställningar såsom överlappning och mellanrum styr layouten och är inte punkt‑nivå formateringsöverskrivningar.

**Finns det någon gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides har ingen separat fast gräns för antalet serier. I praktiken bestäms en praktisk gräns av presentationsfilens begränsningar, tillgängligt minne, renderings‑tid och diagrammets läsbarhet.

**Vad bör jag ändra när kolumner är för nära varandra eller för långt ifrån varandra?**

Anropa [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) på den lämpliga föräldraseriegrouppen. Öka värdet för att bredda avståndet mellan klustren, eller minska det för att föra klustren närmare varandra.