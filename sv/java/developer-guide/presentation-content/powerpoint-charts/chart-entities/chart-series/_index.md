---
title: Hantera diagramdataserier i presentationer i Java
linktitle: Dataserier
type: docs
url: /sv/java/chart-series/
keywords:
- diagramserie
- serieöverlappning
- seriefärg
- serienamn
- datapunkt
- arbetsbokscell
- serieglapp
- negativt värde
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du hanterar diagramserier, datapunkter, arbetsboksceller, formatering, överlappning, glappbredd och negativa värden i presentationer med Java."
---
## **Översikt**

Ett diagram lagrar sina plottade data i en diagramdataarbetsbok. En [IChartSeries](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/) representerar en uppsättning relaterade värden, och varje [IChartDataPoint](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/) i serien refererar till en eller flera celler i arbetsboken. [IChartCategory](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartcategory/) objekt tillhandahåller etiketter eller grupperingvärden som delas av serierna. Serienamnet, kategorierna och punktvärdena är därför kopplade till [IChartDataCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/) objekt snarare än att bara lagras som displaytext.

För ett typiskt kategoridiagram använder standardarbetsboken rad 0 för serienamn, kolumn 0 för kategorinamn och de återstående cellerna för serievärden. Arbetsblad, rad- och kolumnindex som skickas till [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) är nollbaserade. Denna layout är användbar när du skapar ett diagram med standarddata, men anta inte att varje befintligt diagram använder den. För en inläst presentation, inspektera cellerna som refereras av serier, kategorier och datapunkter innan du ändrar arbetsboksvärden.

Diagraminställningar har tre olika omfattningar:

- Inställningar på serienivå, såsom [IChartSeries.getFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#getFormat--) ger standardutseendet för alla punkter i en serie.
- Inställningar på datapunktnivå, såsom [IChartDataPoint.getFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/#getFormat--) åsidosätter serieutseendet för en punkt.
- Gruppinställningar gäller för kompatibla serier som tillhör samma [IChartSeriesGroup](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseriesgroup/). Åtkomst till gruppen sker via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) när du behöver ange alternativ som överlappning eller glappbredd.

Om ingen explicit punkt- eller seriefyllning är angiven bestämmer diagramstilen och temat det automatiska utseendet. När både serie- och punktformatering finns, har punktformateringen företräde för den punkten.

![diagram-serie-powerpoint](chart-series-powerpoint.png)

## **Ange Diagramseriens Överlappning**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#getOverlap--) rapporterar hur mycket staplar eller kolumner överlappar i ett 2D-diagram, från -100 till 100 procent. Det är en skrivskyddad projektion av inställningen på den överordnade serieggruppen. Använd [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) för att uppdatera alla kompatibla serier i den gruppen. Detta alternativ gäller för diagramtyper som visar grupperade staplar eller kolumner; det påverkar inte orelaterade serieggrupper i ett kombinationsdiagram.

Följande exempel sätter överlappningen för gruppen som innehåller den första serien:

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

![Serieöverlappning](series_overlap.png)

## **Ändra Seriefyllningsfärgen**

Använd [IChartSeries.getFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#getFormat--) för att ange standardfyllning för en hel serie. Om en punkt redan har en explicit fyllning, åsidosätter dess [IChartDataPoint.getFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/#getFormat--) -inställning seriefyllningen för den punkten.

Följande exempel applicerar en solid blå fyllning på den första serien:

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

![Färgen på serien](series_color.png)

## **Ändra Serienamnet**

Ett serienamn lagras i diagramdataarbetsboken och visas normalt i teckenförklaringen. I standardarbetsboken som skapas för ett grupperat kolumndiagram är cell B1 på rad 0, kolumn 1 och innehåller namnet på den första serien. De namngivna konstanterna i följande exempel gör den strukturen explicit:

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

Du kan också uppdatera cellen som redan refereras av [IChartSeries.getName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#getName--). Detta tillvägagångssätt undviker att anta en specifik rad och kolumn i ett befintligt diagram:

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

![Serienamnet](series_name.png)

## **Hämta Automatisk Seriefyllningsfärg**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) returnerar färgen som beräknas utifrån serieindexet och diagramstilen. Detta är färgen som används när seriefyllningen inte har definierats explicit. Att anropa metoden läser den beräknade färgen; den tilldelar ingen ny fyllning.

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

Exempelutmatning för standarddiagramstilen:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

De exakta färgerna beror på diagramstilen och temat.

## **Ange Inverterad Fyllningsfärg för en Diagramserie**

För stapel-, kolumn- och bubbelseerier kan [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) visa negativa värden med en annan fyllning. Ställ in den vanliga seriefyllningen till solid, aktivera inversion och tilldela den negativa färgen via [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Negativa tal förblir oförändrade i arbetsboken; endast deras displayfärg ändras.

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

![Den inverterade solida fyllningsfärgen](inverted_solid_fill_color.png)

Du kan aktivera inversion för en punkt via [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). I följande exempel är inversion inaktiverad för serien och endast aktiverad för den valda punkten. Punkten tilldelas också ett negativt värde så att effekten blir synlig:

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

## **Rensa ett Specifikt Datapunktvärde**

För att göra en punkt tom utan att ta bort de andra punkterna, sätt dess underliggande arbetsboks cell till `null`. För ett kolumndiagram är det plottade värdet tillgängligt via [IChartDataPoint.getValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/#getValue--). Datapunkten förblir på samma kategoriposition, men diagrammet behandlar dess värde som tomt enligt diagrammets inställningar för tomma värden.

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

Spridningsdiagram använder separata X- och Y-celler, och bubbeldiagram använder dessutom en storlekscell. Rensa endast den cell som representerar det värde du avser att ta bort. Anropa inte [IChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapointcollection/#clear--) när du vill behålla de andra punkterna, eftersom den metoden tar bort alla datapunkter i samlingen.

## **Styr Visning av Tomma Celler**

Dolda celler som innehåller värden är ett separat fall från tomma celler. För att inkludera eller exkludera data från dolda arbetsbladsrader och -kolumner, se [Include Data from Hidden Rows and Columns](/slides/sv/java/chart-workbook/#include-data-from-hidden-rows-and-columns).

En tom arbetsboks cell representerar saknad data; en cell som innehåller `0` representerar ett känt numeriskt värde. Anropa [IChartDataCell.setValue](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) med `null` för att göra en cell tom. En numerisk nolla förblir en nolla oavsett inställningen för tomma celler.

Använd [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) för att välja hur diagrammet visar tomma celler. Denna inställning gäller för hela diagrammet. Den ändrar hur tomrum plottas, utan att fylla den tomma arbetsboks cellen med noll eller ett interpolerat värde.

Följande självständiga exempel skapar ett linjediagram med en serie, rensar värdet för Dag 3 och sparar samma diagram med varje läge. Ingen indatafil krävs. [IChartDataWorkbook] använder arbetsblad 0, kolumn 0 för kategorietiketter och kolumn 1 för värden; rad 0 innehåller serienamnet. De slutgiltiga data är `10, 20, empty, 30, 40`.

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

    // Lämna dag 3 faktiskt tom, samtidigt som dess kategori och datapunkt behålls.
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

Varje utdatafil lagrar läget som tilldelats innan sparning: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` och `empty_cells_Span.pptx`. För att spara endast en version, tilldela önskat läge och spara presentationen en gång istället för att iterera över lägena.

Jämförelsen nedan visar samma data i alla tre filer. Dag 3 är tom i arbetsboken i varje fall:

![Linjediagram med identiska data: Gap bryter linjen vid Dag 3, Zero sänker linjen till noll, och Span kopplar Dag 2 till Dag 4.](display_blanks_as.png)

Den synliga effekten beror på diagramtypen. Ett linjediagram gör alla tre lägen enkla att jämföra. Stapel- och kolumndiagram har ingen linje att koppla över en saknad kategori, så `Span` kan inte skapa den anslutande sektionen som visas ovan; en saknad kolumn och en kolumn med nollhöjd kan också se lika ut. På samma sätt har ett spridningsdiagram med enbart markörer ingen anslutningslinje. Förvänta dig inte tre olika resultat för varje diagramtyp; kontrollera utdata för den typ du använder.

## **Ange Serieglappbredd**

Glappbredd är avståndet mellan intilliggande stapel- eller kolumnkluster, uttryckt som en procentandel av stapel- eller kolumnbredden. Liksom överlappning tillhör den den överordnade serieggruppen snarare än en enskild serie. Anropa [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) en gång för gruppen. Ett större värde skapar mer utrymme mellan klustren; ett mindre värde gör dem tätare.

Följande exempel ändrar glappbredden och sparar endast den slutgiltiga presentationen:

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

![Glappbredden](gap_width.png)

## **FAQ**

**Vilka diagramtyper stöder dataserier?**

Alla diagramtyper som representeras av uppräkningen [ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/) använder diagramdata, men deras serier har inte alla samma värdestruktur eller inställningar. Till exempel använder kategoridiagram kategorier och värden, spridningsdiagram använder X- och Y‑värden, och bubbeldiagram lägger till bubbeltstorlekar. Använd den datapunktsskapande metoden som matchar serietypen. Alternativ som överlappning och glappbredd gäller endast för kompatibla stapel- eller kolumngrupper.

**Vad är en diagramseriegrupp?**

Ett [IChartSeriesGroup](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseriesgroup/) innehåller kompatibla serier som delar gruppnivåinställningar för plottning. Ett kombinationsdiagram kan innehålla mer än en grupp, så att ändra gruppen som nås via en serie inte nödvändigtvis ändrar varje serie i diagrammet.

**Innehåller ett nyss skapat diagram standarddata?**

Ja. Som standard skapar [IShapeCollection.addChart](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) exempelserier, kategorier och värden. Du kan redigera dessa celler eller rensa både serie- och kategori‑samlingarna innan du lägger till ett helt eget dataset. En överlagrad metod kan också skapa ett diagram utan standarddata.

**Hur är diagramobjekt kopplade till arbetsboks celler?**

Serienamn, kategorietiketter och datapunktvärden refererar till celler i en [IChartDataWorkbook](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdataworkbook/). Att ändra en refererad cell uppdaterar motsvarande diagramelement. När du bygger anpassade data, håll kategorirader och serie‑värderader i linje så att varje punkt plottas under avsedd kategori.

**Hur rensar jag en punkt istället för hela serien?**

Sätt den relevanta värdecellen till `null` för att behålla punktens kategoriposition som en tom punkt. Använd [IChartDataPointCollection.clear](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapointcollection/#clear--) endast när du avser att ta bort alla punkter från den serien. Om du också tar bort kategorier, uppdatera varje serie så att deras värden förblir i linje med kategori‑samlingen.

**Hur visas tomma punkter?**

Resultatet beror på diagramtypen och värdet som konfigurerats via [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). Stödda diagram kan visa tomrum som luckor, som nollvärden eller genom att koppla ihop närliggande punkter. Välj den inställning som motsvarar betydelsen av saknad data i din presentation. Se [Styr Visning av Tomma Celler](#control-the-display-of-empty-cells) för ett komplett exempel och visuell jämförelse.

**Hur formateras negativa värden?**

För stödda stapel-, kolumn- och bubbelseerier, anropa [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) och ange färgen som returneras av [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). Du kan åsidosätta beteendet för en enskild punkt med [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). Dessa metoder påverkar formateringen, inte de lagrade numeriska värdena.

**Vilken formatering vinner när både en serie och en punkt är formaterade?**

Explicit datapunktformatering har företräde för den punkten. Övriga punkter fortsätter att använda den explicit angivna serieformaten eller, när serieformatet inte är definierat, diagramstilens och temats automatiska format. Gruppinställningar såsom överlappning och glappbredd styr layout och är inte formateringsåsidosättningar på punktnivå.

**Finns det en gräns för hur många serier ett diagram kan innehålla?**

Aspose.Slides påför ingen separat fast gräns för antalet serier. I praktiken bestäms en rimlig gräns av presentationsfilens begränsningar, tillgängligt minne, renderingtid och diagrammets läsbarhet.

**Vad bör jag ändra när kolumner är för nära varandra eller för långt ifrån varandra?**

Anropa [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) på lämplig överordnad serieggrupp. Höj värdet för att öka avståndet mellan klustren, eller sänk det för att föra klustren närmare varandra.