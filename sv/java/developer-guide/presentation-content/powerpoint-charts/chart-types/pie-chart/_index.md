---
title: Anpassa pajdiagram i presentationer med Java
linktitle: Pajdiagram
type: docs
url: /sv/java/pie-chart/
keywords:
- pajdiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- sektorfärg
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa och anpassa pajdiagram i Java med Aspose.Slides. Konfigurera sekundära plotter, visa datalabels och applicera automatiska sektorfärger i PowerPoint."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med pajdiagram i Aspose.Slides. Den visar hur man konfigurerar alternativ för sekundär plott för Pie of Pie- och Bar of Pie-diagram, samt hur man aktiverar automatisk färgläggning av sektorer för ett standardpajdiagram.

Exemplen fokuserar på uppgifter för anpassning av diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med anpassade kategorier och värden, samt spara den uppdaterade presentationen.

## **Alternativ för sekundär plott för Pie of Pie- och Bar of Pie-diagram**

Aspose.Slides for Java stöder alternativ för sekundär plott för Pie of Pie- och Bar of Pie-diagram. Dessa alternativ styr storleken på den sekundära plotten och hur datapunkter fördelas mellan de två plotterna.

Följande exempel skapar ett Pie of Pie-diagram i en ny presentation och visar datapunktvärden som etiketter. Metoden [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) sätter storleken på den sekundära plotten till 149 % av huvudplotten. [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) väljer procentbaserad uppdelning, och [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) sätter tröskelvärdet till 53 %.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Visa värden och konfigurera den sekundära plotten.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Välj kategorier för den sekundära plotten**

Använd anpassad uppdelning när du vill gruppera specifika kategorier i den sekundära plotten oavsett deras procentvärden. Till exempel kan en försäljningsrapport visa Online och Events tillsammans så att läsarna kan jämföra dessa två kanaler, även om de utgör 35 % respektive 10 % av den totala försäljningen.

Anropa [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) med [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) och välj punkterna via [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). Samlingens [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) metod accepterar ett nollbaserat index i serien; använd [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) för att lägga till ett datapunktobjekt. I detta exempel väljer index 1 Online, och punkten vid index 3 väljer Events. Partners läggs också till tillfälligt, och tas sedan bort med [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Ersätt standarddata med försäljning per kanal.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Välj Online med dess nollbaserade index och Events med dess datapunktobjekt.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Exkludera Partners från urvalet utan att ta bort dess källdata.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) och Events (10) visas som separata sektorer i den sekundära plotten. I den primära plotten representeras de av en sammanslagen sektor med värdet 45, tillsammans med Retail (40) och Partners (15). Att ta bort Partners från den anpassade urvalet behåller den i den primära plotten; det tar inte bort kategorin eller dess värde från diagrammets källdata.

Följande bild visar den sparade presentationen i PowerPoint:

![Pie of Pie-diagram med Online och Events i den sekundära plotten och deras kombinerade värde 45 i den primära plotten](pie_of_pie_custom.png)

## **Ställ in automatiska färger för pajdiagrammets sektorer**

Aspose.Slides for Java kan automatiskt tilldela olika färger till pajdiagrammets sektorer. Följande exempel skapar ett pajdiagram med en centrerad titel och ersätter standarddata med tre kvartalskategorier och deras värden. Metoden [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) visar värdena 20, 50 och 30 som etiketter, medan [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) möjliggör en distinkt färg för varje sektor.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Lägg till en centrerad diagramtitel.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Ersätt standarddata med hjälp av det första kalkylbladet.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Visa värden och tilldela olika färger till sektorerna.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

**Stöds Pie of Pie- och Bar of Pie-varianterna?**

Ja, biblioteket [stödjer](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) en sekundär plott för pajdiagram, inklusive typerna Pie of Pie och Bar of Pie.

**Kan jag exportera bara diagrammet som en bild (till exempel PNG)?**

Ja, du kan [exportera själva diagrammet som en bild](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (t.ex. PNG) utan att exportera hela presentationen.