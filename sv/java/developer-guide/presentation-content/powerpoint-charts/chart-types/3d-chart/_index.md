---
title: Anpassa 3D-diagram i presentationer med Java
linktitle: 3D-diagram
type: docs
url: /sv/java/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Skapa 3D-diagram i PowerPoint-presentationer med Aspose.Slides för Java. Justera rotation, höjdförhållanden, diagramdjup och avstånd mellan serier med Java-exempel."
---
## **Översikt**

Aspose.Slides for Java låter dig anpassa vyn av ett 3D-diagram via metoden [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--). Den här artikeln visar hur du justerar rotation, höjdförhållanden, djup, ortogonala axlar och avstånd mellan serier, och sedan sparar presentationen i PPTX-format.

## **Ställ in rotation och djup för ett 3D-diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) och använder [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) för att lägga till ett staplat 3D stapeldiagram på dess första bild. Det ersätter standardserierna och -kategorierna med två serier som innehåller tre värden vardera. Arbetsbladsindex `0` identifierar diagrammets första datakalkylblad; rad `0` innehåller serienamn och kolumn `0` innehåller kategorietiketter.

Metoderna [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) och [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) sätter diagrammets rotation till 40 respektive 270 grader. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) anger dess djup till 150 % av dess bredd, medan [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) aktiverar ortogonala axlar i stället för perspektiv. Den resulterande presentationen innehåller det fyllda diagrammet med dessa 3D-vyinställningar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Justera höjdförhållandena för ett 3D-diagram**

Använd [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) för att ange diagrammets höjd som en procentsats av dess bredd. Detta ändrar proportionerna i 3D-scenen utan att ändra storleken på diagramobjektet på bilden.

Följande exempel skapar ett [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdförhållanden på 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, seriespacing och formatering är identiska i alla tre filerna; endast höjdpersen­tagen ändras.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Följande bilder illustrerar samma höjdinställningar i motsvarande .NET‑exempel och exporterades med Microsoft PowerPoint. En mindre procentsats ger en plattare scen, medan en större procentsats ger en högre scen inom samma diagramobjekt. PowerPoint kan också justera axelns stapelintervaller och etikettplacering för att passa scenen.

| Höjd: 50% | Höjd: 100% | Höjd: 200% |
| --- | --- | --- |
| ![3D stapeldiagram med höjden satt till 50 percent of its width](height_percent_50.png) | ![3D stapeldiagram med höjden satt till 100 percent of its width](height_percent_100.png) | ![3D stapeldiagram med höjden satt till 200 percent of its width](height_percent_200.png) |

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Höjd på 3D‑scenen som en procentsats av dess bredd. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Höjd på diagramobjektet på bilden, i punkter. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Djup på 3D‑scenen som en procentsats av dess bredd. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Avstånd mellan serier längs djupaxeln, som en procentsats av markörens bredd. |

Höjdinställningen påverkar 3D stapel- och stapeldiagram, inklusive cylinder-, kon- och pyramidalvarianter, samt 3D linje-, area-, paj- och ytdiagram. Jämförelsen ovan använder den verifierade typen `Column3D`. Inställningen ändrar inte utseendet på ett 2D `ClusteredColumn`‑diagram eller ett `BubbleWith3D`‑diagram; dessa namn är medlemmar i klassen [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). För andra diagramutseendeinställningar, se [Chart Formatting](/slides/sv/java/chart-formatting/).

## **Justera avståndet mellan serier**

Använd [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) för att styra avståndet mellan dataserier längs djupaxeln i ett 3D‑diagram, uttryckt som en procentsats av markörens bredd. Använd värden från **0 till 500**, inklusivt: `0` tar bort avståndet, medan högre värden ökar mellanrummet. Med ett fast diagramdjup gör ett ökat avstånd markörerna tunnare längs djupaxeln.

Kom åt gruppen via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Inställningen gäller för varje serie i den gruppen, inte bara för den serie som används för åtkomst. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) returnerar djupavståndet och speglar föräldragruppens inställning.

Den här inställningen påverkar 3D stapel- och stapeldiagram, inklusive deras cylinder-, kon- och pyramidalvarianter, samt 3D linje- och area‑diagram. Utseendet beror på om serierna är ordnade i djup, grupperade eller staplade. För en tydlig jämförelse av avstånd mellan separata serier, använd `ChartType.Column3D` från klassen [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Avstånd mellan serier längs djupaxeln, som en procentsats av markörens bredd. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Avstånd mellan intilliggande stapel- eller kolumnkluster, som en procentsats av stapel- eller kolumnbredden. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Totalt diagramdjup, som en procentsats av diagrambredden. |

Följande självständiga exempel använder standarddiagramdata, som innehåller tre serier och fyra kategorier. Det sparar två presentationer med identiska data, rotation, gapbredd och diagramdjup; endast gapdjupet förändras.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Följande bilder illustrerar samma gapdjupinställningar i motsvarande .NET‑exempel och exporterades med Microsoft PowerPoint.

| Gapdjup: 0% | Gapdjup: 500% |
| --- | --- |
| ![3D stapeldiagram utan avstånd mellan serier längs djupaxeln](gap_depth_0.png) | ![3D stapeldiagram med en 500 percent gap between series along the depth axis](gap_depth_500.png) |

## **Ändra 3D-serietyp och stapelform**

I ett grupperat cylinderdiagram börjar den första serien med en cylindrisk stapelform. Exemplet skriver ut heltalsvärdena som returneras av [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) och [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) före och efter varje ändring. Tabellen visar motsvarande konstantnamn.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Ändring av den första serien | Serietyp | Stapelform |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

Att sätta formen till `Box` ändrar också serietypen till `ClusteredColumn3D`. Om din kod har förgreningar baserade på serietypen, anropa `series.getType()` efter att du ändrat formen. Ett värde som cachats före tilldelningen skulle fortfarande välja `ClusteredCone`‑grenen.

![PowerPoint comparison showing the first series as cylinders, cones, and rectangular columns from left to right](series-shapes.png)

## **FAQ**

**Vilka diagramtyper stödjer 3D‑läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via klassen [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). För en exakt och aktuell lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild med [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) eller [rendera hela bilden](/slides/sv/java/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en rasterförhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterar byggande och rendering av stora 3D‑diagram?**

Prestanda beror på datamängd och visuell komplexitet. För bästa resultat, håll 3D‑effekterna minimala, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en output med lämplig storlek (upplösning och dimensioner) för att matcha målskärmen eller utskriftsbehoven.