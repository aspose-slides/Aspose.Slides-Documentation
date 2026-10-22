---
title: Hantera diagramdataserier i presentationer i Java
linktitle: Dataserier
type: docs
url: /sv/java/chart-series/
keywords:
- diagramserier
- serieröverlappning
- seriefärg
- serienamn
- datapunkt
- arbetsbokscell
- seriemellanrum
- negativt värde
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboksceller, formatering, överlappning, mellanrum och negativa värden i presentationer med Java."
---
## **Översikt**

Ett diagram kan lagra sina plottade värden i arbetsbokens celler eller direkt som numeriska litteraler. En [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) representerar en uppsättning relaterade värden, och varje [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) representerar en punkt i den serien. [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/)‑objekt tillhandahåller etiketter eller grupperingsvärden som delas av serierna. I diagram som skapats med standarddata används [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/)‑objekt från diagrammets arbetsbok för serienamn, kategorier och punktvärden.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för serienamn, kolumn 0 för kategorinamn och de återstående cellerna för serievärden. Arbetsblad‑, rad‑ och kolumnindex som skickas till [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) är nollbaserade. Denna layout är praktisk när du skapar ett diagram med standarddata, men anta inte att varje befintligt diagram använder den. För en inläst presentation, inspektera cellerna som refereras av serier, kategorier och datapunkter innan du ändrar arbetsboksvärden.

Diagraminställningar har tre olika omfattningar:

- Inställningar på serie‑nivå, såsom [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--), anger standardutseendet för alla punkter i en serie.
- Inställningar på datapunkt‑nivå, såsom [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--), åsidosätter serieutseendet för en enskild punkt.
- Gruppinställningar gäller kompatibla serier som tillhör samma [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/). Åtkomst till gruppen sker via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) när du behöver ställa in alternativ som överlappning eller mellanrum.

När ingen explicit fyllning för punkt eller serie har angetts bestämmer diagramstilen och temat det automatiska utseendet. När både serie‑ och punktformatering finns, har punktformateringen företräde för den punkten.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ange seriervärden med numeriska litteraler**

Använd numeriska litteraler när seriervärden hämtas från programdata eller beräkningar och inte behöver referenser till arbetsblads‑celler. Anropa [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) med [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) innan du tilldelar varje punkts [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--)‑resultat via [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-).

Samlingens inställning styr källtypen för alla punktvärden i den serien. Varje punkts [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--)‑metod rapporterar den valda typen; ändra den via samlingsinställningen. Med `Worksheet` används [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) för att komma åt den refererade cellen. Med `DoubleLiterals` används [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) eller `setAsLiteralDouble` för att läsa eller skriva talet direkt.

Följande exempel skapar ett stapeldiagram med standardserier och -kategorier och tilldelar sedan beräknade värden 10, 20 osv. till befintliga punkter i den första serien. Det sparar presentationen, öppnar den igen och skriver ut de lagrade värdena.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

Punktvärdes källtyp är separat från [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--), som identifierar diagrammets interna eller externa arbetsbokskonfiguration. Att använda numeriska litteraler tar inte bort den inbäddade arbetsboken. I detta exempel förblir arbetsboken tillgänglig för kategorietiketter, serienamn och de övriga serierna. Se [Chart Workbook](/slides/sv/java/chart-workbook/) för hantering av arbetsböcker.

För spridnings‑ och bubbeldiagram, använd [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) och [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) för att välja källorna för [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) och [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--). Bubbeldiagram använder även [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) för [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--). Ställ in varje tillämplig källa på `DoubleLiterals` innan du tilldelar tal via dess `setAsLiteralDouble`‑metod.

## **Ange diagramseriens överlappning**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) rapporterar hur mycket staplar eller kolumner överlappar i ett 2D‑diagram, från –100 till 100 procent. Det är en skrivskyddad projektion av inställningen på den överordnade seriegruppen. Använd [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) för att uppdatera alla kompatibla serier i den gruppen. Detta alternativ gäller diagramtyper som visar grupperade staplar eller kolumner; det påverkar inte orelaterade seriegrupper i ett kombinationsdiagram.

Följande exempel ställer in överlappningen för gruppen som innehåller den första serien:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Det nya diagrammet innehåller exempelserier, kategorier och värden.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The series overlap](series_overlap.png)

## **Ändra seriefyllningsfärgen**

Använd [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning åsidosätter dess [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--)‑inställning seriefyllningen för den punkten.

Följande exempel tillämpar en solid blå fyllning på den första serien:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The color of the series](series_color.png)

## **Ändra seriens namn**

Ett serienamn lagras i diagrammets datarbok och visas normalt i förklaringen. I standardarbetsboken som skapas för ett grupperat stapeldiagram ligger cell B1 i rad 0, kolumn 1 och innehåller namnet på den första serien. De namnkonstruktioner som visas i följande exempel gör den strukturen explicit:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Du kan också uppdatera cellen som redan refereras av [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--). Detta undviker att anta en viss rad och kolumn i ett befintligt diagram:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The series name](series_name.png)

### **Skapa en serie med namn från flera celler**

Ett sammansatt serienamn är användbart när ett produktnamn och en rapportperiod lagras i separata celler. Till exempel kan du kombinera `Product A` i B1 och `2026` i C1 till ett enda serienamn samtidigt som båda delarna förblir länkade till sina källceller.

Använd [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) för att hämta namnintervallet, och skicka sedan den samlingen till [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-). Argumentet `skipHiddenCells` styr om dolda celler inkluderas: `true` utesluter dem, `false` inkluderar dem. Detta exempel använder `false` för att inkludera varje cell i namnintervallet.

Följande exempel skapar en presentation med en serie och två datapunkter. Cellerna B1:C1 levererar endast serienamnet; A2:A3 levererar kategori‑etiketterna, och B2:B3 levererar de numeriska värdena.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Dessa två celler levererar serienamnet.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Separata celler levererar kategorierna och numeriska datapunkter.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Det resulterande serienamnet blir `Product A 2026`, med ett mellanslag mellan de två cellvärdena. Förklaringen visar detta som ett enda poster för båda kolumnerna. Bilden nedan illustrerar resultatet:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Hämta den automatiska seriefärgen**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) returnerar färgen som beräknas utifrån serie‑indexet och diagramstilen. Detta är färgen som används när serie‑fyllningen inte har definierats explicit. Anropet läser den beräknade färgen; det tilldelar ingen ny fyllning.

Följande exempel skriver ut den automatiska färgen för varje standardserie:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Exempelutdata för standarddiagramstil:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exakta färgerna beror på diagramstil och tema.

## **Ställ in inverterad fyllningsfärg för en diagramserie**

För stapel‑, kolumn‑ och bubbelseerier kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) visa negativa värden med en annan fyllning. Ställ in den vanliga serie‑fyllningen på solid, aktivera inversion och tilldela färgen för negativa värden via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negativa tal förblir oförändrade i arbetsboken; endast visningsfärgen ändras.

Följande exempel ersätter standarddiagramdata med en serie. Arbetsbladsrad 0 innehåller serienamnet, kolumn 0 innehåller kategorinamnen och kolumn 1 innehåller värdena:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The inverted solid fill color](inverted_solid_fill_color.png)

Du kan aktivera inversion för en enskild punkt via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). I följande exempel är inversion inaktiverad för serien och endast aktiverad för den valda punkten. Punkten tilldelas också ett negativt värde så att effekten blir synlig:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rensa ett specifikt datapunktvärde**

För att göra en punkt tom utan att ta bort de andra, sätt dess underliggande arbetsboks­cell till `null`. För ett stapeldiagram är det plottade värdet tillgängligt via [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--). Datapunkten behåller sin kategori‑position, men diagrammet behandlar värdet som blankt enligt diagrammets inställningar för tomma värden.

Följande exempel rensar endast den andra punkten i den första serien:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Spridningsdiagram använder separata X‑ och Y‑celler, och bubbeldiagram använder även en storlekscell. Rensa bara den cell som representerar det värde du vill ta bort. Anropa inte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) när du vill behålla de andra punkterna, eftersom den metoden tar bort alla datapunkter i samlingen.

## **Styr visning av tomma celler**

Dolda celler som innehåller värden är en annan sak än tomma celler. För att inkludera eller exkludera data från dolda arbetsbladsrader och -kolumner, se [Include Data from Hidden Rows and Columns](/slides/sv/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

En tom arbetsboks­cell representerar saknad data; en cell som innehåller `0` representerar ett känt numeriskt värde. Anropa [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) med `null` för att göra cellen tom. En numerisk nolla förblir noll oavsett inställning för tomma celler.

Använd [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) för att välja hur diagrammet visar tomma celler. Denna inställning gäller hela diagrammet. Den ändrar hur tomma värden plottas, utan att fylla den tomma arbetsboks­cellen med noll eller ett interpolerat värde.

Följande självständiga exempel skapar ett linjediagram med en serie, rensar värdet för Dag 3 och sparar samma diagram med varje läge. Ingen indatafil behövs. [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) använder arbetsblad 0, kolumn 0 för kategori‑etiketter och kolumn 1 för värden; rad 0 innehåller serienamnet. Den slutliga datan är `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Lämna dag 3 faktiskt tom, men behåll dess kategori och datapunkt.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Varje utdatafil lagrar det läge som tilldelats före sparning: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` och `empty_cells_Span.pptx`. För att spara bara en version, ange önskat läge och spara presentationen en gång istället för att iterera över lägena.

Jämförelsen nedan visar samma data i alla tre filer. Dag 3 är tom i arbetsboken i alla fall:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Den synliga effekten beror på diagramtypen. Ett linjediagram gör alla tre lägen enkla att jämföra. Stapel‑ och kolumndiagram har ingen linje att förena över en saknad kategori, så `Span` kan inte skapa det visade förbindelsesegmentet; en saknad kolumn och en noll‑höjd‑kolumn kan också se lika ut. På samma sätt har ett spridningsdiagram med enbart markörer ingen sammankopplad linje. Förvänta dig inte tre distinkta resultat för varje diagramtyp; kontrollera utdata för den typ du använder.

## **Ställ in serie‑mellanrum (gap width)**

Mellanrum är avståndet mellan intilliggande stapel‑ eller kolumnkluster, uttryckt som procent av stapel‑ eller kolumnbredden. Precis som överlappning tillhör det den överordnade seriegruppen snarare än en enskild serie. Anropa [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) en gång för gruppen. Ett högre värde skapar mer utrymme mellan klustren; ett lägre värde gör dem tätare.

Följande exempel ändrar mellanrummet och sparar endast den slutgiltiga presentationen:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The gap width](gap_width.png)

## **Vanliga frågor**

**Vilka diagramtyper stödjer dataserier?**

Alla diagramtyper som representeras av uppräkningen [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) använder diagramdata, men deras serier har inte alltid samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram X‑ och Y‑värden, och bubbeldiagram lägger till bubbeltstorlekar. Använd den datapunkt‑skapande metod som matchar serietypen. Alternativ som överlappning och mellanrum gäller endast kompatibla stapel‑ eller kolumngrupper.

**Vad är en diagramseriegoup?**

En [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) innehåller kompatibla serier som delar grupp‑nivå‑plot‑inställningar. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen som nås via en serie förändrar inte nödvändigtvis alla serier i diagrammet.

**Skapar ett nyss skapat diagram standarddata?**

Ja. Som standard skapar [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) exempelserier, -kategorier och -värden. Du kan redigera dessa celler eller rensa både serie‑ och kategorisamlingarna innan du lägger till en helt anpassad datasats. En överbelastning kan också skapa ett diagram utan standarddata.

**Hur är diagramobjekt kopplade till arbetsboks­celler?**

Serienamn, kategori‑etiketter och datapunkt‑värden refererar celler i en [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/). När en refererad cell ändras uppdateras motsvarande diagramdel. När du bygger anpassad data, håll kategori‑rader och serie‑värdes‑rader i linje så att varje punkt plottas under rätt kategori.

**Hur rensar jag en enda punkt istället för hela serien?**

Sätt den relevanta värdecellen till `null` för att behålla punktens kategori‑position som en tom punkt. Använd [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) endast när du avser att ta bort alla punkter från den serien. Om du också tar bort kategorier, uppdatera varje serie så att deras värden förblir i linje med kategori‑samlingen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtyp och det värde som konfigurerats via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Stödda diagram kan visa tomma värden som luckor, som nollvärden eller genom att koppla ihop intilliggande punkter. Välj inställning som matchar innebörden av saknad data i din presentation. Se [Control the Display of Empty Cells](#control-the-display-of-empty-cells) för ett komplett exempel och visuell jämförelse.

**Hur formateras negativa värden?**

För stödda stapel‑, kolumn‑ och bubbelseerier, anropa [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) och ange färgen som returneras av [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Du kan åsidosätta beteendet för en enskild punkt med [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Dessa metoder påverkar formatering, inte de lagrade numeriska värdena.

**Vilken formatering har företräde när både en serie och en punkt är formaterade?**

Explicit datapunkt‑formatering har företräde för den punkten. Övriga punkter fortsätter att använda den explicit angivna serie‑formateringen eller, när serie‑formateringen saknas, det automatiska diagramstil‑ och temautseendet. Gruppinställningar såsom överlappning och mellanrum styr layout och är inte formateringsöverskrivningar på punkt‑nivå.

**Finns det någon gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides har ingen separat fast gräns för antalet serier. I praktiken bestäms en rimlig gräns av presentationsfilens begränsningar, tillgängligt minne, renderingtid och diagrammets läsbarhet.

**Vad bör jag ändra när kolumner är för nära varandra eller för långt ifrån varandra?**

Anropa [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) på den aktuella föräldra‑seriegruppen. Öka värdet för att bredda avståndet mellan klustren, eller minska det för att föra klustren närmare varandra.