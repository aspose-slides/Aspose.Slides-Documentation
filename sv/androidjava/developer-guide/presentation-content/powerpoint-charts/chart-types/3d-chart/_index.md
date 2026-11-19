---
title: Anpassa 3D-diagram i presentationer på Android
linktitle: 3D-diagram
type: docs
url: /sv/androidjava/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa 3D-diagram i PowerPoint-presentationer med Aspose.Slides för Android via Java. Justera rotation, höjdförhållanden, diagramdjup och avstånd mellan serier med Java-exempel."
---
## **Översikt**

Aspose.Slides for Android via Java låter dig anpassa visningen av ett 3D-diagram genom metoden [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . Denna artikel visar hur du justerar rotation, höjdförhållanden, djup, högra vinkel‑axlar och avstånd mellan serier, och sedan sparar presentationen i PPTX‑format.

## **Ställ in rotation och djup för ett 3D‑diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) och använder [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) för att lägga till ett staplat 3D‑kolumndiagram på den första bilden. Det ersätter standardserierna och kategorierna med två serier som innehåller tre värden vardera. Arbetsblad‑index `0` identifierar diagrammets första datablad; rad `0` innehåller serienamnen och kolumn `0` innehåller kategorimärkena.

Metoderna [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) och [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) sätter diagrammets rotation till 40 respektive 270 grader. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) anger dess djup till 150 % av dess bredd, medan [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) aktiverar högra‑vinkel‑axlar i stället för perspektiv. Den resulterande presentationen innehåller diagrammet med dessa 3D‑visningsinställningar.

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

## **Justera höjdförhållandena för ett 3D‑diagram**

Använd [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) för att ange höjden på ett 3D‑diagram som en procentandel av dess bredd. Detta ändrar proportionerna för 3D‑scenen utan att ändra storleken på diagramobjektet på bilden.

Följande exempel skapar ett [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/)‑diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdförhållanden på 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, seriespacing och formatering är identiska i alla tre filer; endast procentandelen för höjden varierar.

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

Följande bilder illustrerar samma höjdinställningar i det motsvarande .NET‑exemplet och exporterades med Microsoft PowerPoint. En lägre procentandel ger en plattare scen, medan en högre procentandel ger en högre scen inom samma diagramobjekt. PowerPoint kan också justera axelns tick‑intervall och etikettplacering för att passa scenen.

| Höjd: 50 % | Höjd: 100 % | Höjd: 200 % |
| --- | --- | --- |
| ![3D‑kolumndiagram med höjd inställd på 50 % av dess bredd](height_percent_50.png) | ![3D‑kolumndiagram med höjd inställd på 100 % av dess bredd](height_percent_100.png) | ![3D‑kolumndiagram med höjd inställd på 200 % av dess bredd](height_percent_200.png) |

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Höjd på 3D‑scenen som en procentandel av dess bredd. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Höjd på diagramobjektet på bilden, i punkter. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Djup på 3D‑scenen som en procentandel av dess bredd. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Avstånd mellan serier längs djup‑axeln, som en procentandel av markörens bredd. |

Höjdinställningen påverkar 3D‑stapel‑ och stapel‑diagram, inklusive cylinder‑, kon‑ och pyramid‑varianter, samt 3D‑linje‑, område‑, paj‑ och ytdiagram. Jämförelsen ovan använder den verifierade `Column3D`‑typen. Inställningen ändrar inte utseendet på ett 2D‑`ClusteredColumn`‑diagram eller ett `BubbleWith3D`‑diagram; dessa namn är medlemmar i klassen [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). För andra diagramutseendeinställningar, se [Chart Formatting](/slides/sv/androidjava/chart-formatting/).

## **Justera avståndet mellan serier**

Använd [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) för att kontrollera avståndet mellan dataserier längs djup‑axeln i ett 3D‑diagram, uttryckt som en procentandel av markörens bredd. Använd värden från **0 till 500**, inklusive: `0` tar bort avståndet, medan högre värden ökar mellanrummet. Med ett fast diagramdjup gör ett större avstånd markörerna tunnare längs djup‑axeln.

Kom åt gruppen via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Inställningen gäller för varje serie i den gruppen, inte bara för den serie som använts för åtkomst. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) returnerar djupavståndet och speglar föräldragruppens inställning.

Denna inställning påverkar 3D‑stapel‑ och stapeldiagram, inklusive deras cylinder‑, kon‑ och pyramid‑varianter, samt 3D‑linje‑ och områdesdiagram. Utseendet beror på om serierna är arrangerade i djup, gruppera eller staplade. För en tydlig jämförelse av avstånd mellan separata serier, använd `ChartType.Column3D` från klassen [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Avstånd mellan serier längs djup‑axeln, som en procentandel av markörens bredd. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Avstånd mellan intilliggande stapel‑ eller kolumnkluster, som en procentandel av stapel‑ eller kolumnbredden. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Totalt diagramdjup, som en procentandel av diagrammets bredd. |

Följande självständiga exempel använder standarddiagramdata med tre serier och fyra kategorier. Det sparar två presentationer med identiska data, rotation, gap‑bredd och diagramdjup; endast gap‑djupet förändras.

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

Följande bilder illustrerar samma gap‑djupinställningar i det motsvarande .NET‑exemplet och exporterades med Microsoft PowerPoint.

| Gap‑djup: 0 % | Gap‑djup: 500 % |
| --- | --- |
| ![3D‑kolumndiagram utan gap mellan serier längs djup‑axeln](gap_depth_0.png) | ![3D‑kolumndiagram med 500 % gap mellan serier längs djup‑axeln](gap_depth_500.png) |

## **Ändra 3D‑serietyp och stapelform**

I ett grupperat cylindrisk diagram börjar den första serien med en cylindrisk stapelform. Exemplet skriver ut de heltalsvärden som returneras av [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) och [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) före och efter varje förändring. Tabellen visar de motsvarande konstantnamnen.

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

| Ändra den första serien | Serietyp | Stapelform |
| --- | --- | --- |
| Skapa diagrammet | `ClusteredCylinder` | `Cylinder` |
| Ställ in serietyp till `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ställ in stapelform till `Box` | `ClusteredColumn3D` | `Box` |

Att sätta formen till `Box` ändrar också serietypen till `ClusteredColumn3D`. Om din kod grenartikulerar på serietypen, anropa `series.getType()` efter att ha ändrat formen. Ett värde som cachats före tilldelningen skulle fortfarande välja `ClusteredCone`‑grenen.

![PowerPoint‑jämförelse som visar den första serien som cylindrar, koner och rektangulära kolumner från vänster till höger](series-shapes.png)

## **FAQ**

**Vilka diagramtyper stöder 3D‑läge i Aspose.Slides?**

Aspose.Slides stöder 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via klassen [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild med [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) eller [rendera hela bilden](/slides/sv/androidjava/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en raster‑förhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterar bygga och rendera stora 3D‑diagram?**

Prestandan beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekter minimala, undvik tunga texturer på väggar och plottytor, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämplig upplösning och dimension som matchar måldisplayen eller utskriftsbehoven.