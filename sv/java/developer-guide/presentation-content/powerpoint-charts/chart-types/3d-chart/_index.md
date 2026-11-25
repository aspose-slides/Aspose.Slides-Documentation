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
description: "Skapa 3D-diagram i PowerPoint-presentationer med Aspose.Slides för Java. Justera rotation, höjdproportioner, diagramdjup och avstånd mellan serier med Java-exempel."
---
## **Översikt**

Aspose.Slides for Java låter dig anpassa vyn av ett 3D-diagram via metoden [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Denna artikel visar hur du justerar rotation, höjdproportioner, djup, högervinkelaxlar och avstånd mellan serier, och sedan sparar presentationen i PPTX-format.

## **Ställ in rotation och djup för ett 3D-diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) och använder [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) för att lägga till ett staplat 3D-kolumndiagram på dess första bild. Det ersätter standardserierna och -kategorierna med två serier som innehåller tre värden vardera. Arbetsbladsindex `0` identifierar diagrammets första datakalkylblad; rad `0` innehåller serienamn, och kolumn `0` innehåller kategori‑etiketter.

Metoderna [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) och [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) sätter diagrammets rotation till 40 respektive 270 grader. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) sätter dess djup till 150 % av dess bredd, medan [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) aktiverar högervinkelaxlar istället för perspektiv. Den resulterande presentationen innehåller det ifyllda diagrammet med dessa 3D‑vyinställningar.

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

## **Applicera en bildfyllning på en 3D-diagramyta**

Ett 3D-diagram har tre ytor som du kan fylla var för sig: [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--), och [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) . Ställ in ytans [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) till `Picture` och tilldela en bild. Ställ in både [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) och ytans [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) till `Stretch` för att anpassa en kopia av bilden över ytan.

Spara [arrow.png](arrow.png) i arbetskatalogen. Exemplet roterar diagrammet och höjer maxvärdet på den vertikala axeln så att golvet syns mellan kolumnerna. Det klonar sedan bilden två gånger och applicerar pilen på en annan yta på varje bild. Alla tre diagrammen behåller samma data, visningsvinkel och bakgrund.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint visar de tre bilderna som följer.

| Sidovägg | Bakvägg | Golv |
| --- | --- | --- |
| ![Pil som pekar in i diagrammet längs sidoväggen](side-wall.png) | ![Pil som pekar åt höger över bakväggen](back-wall.png) | ![Pil som pekar åt höger över golvet mellan kolumnerna](floor.png) |

## **Justera höjdproportionerna för ett 3D-diagram**

Använd [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) för att sätta diagrammets höjd som en procentandel av dess bredd. Detta ändrar proportionerna i 3D‑scenen utan att ändra storleken på diagramobjektet på bilden.

Följande exempel skapar ett [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdproportioner på 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, serievärden och formatering är identiska i alla tre filer; endast höjdpunktsprocenten ändras.

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

Följande bilder illustrerar samma höjdinställningar i motsvarande .NET‑exempel och exporterades med Microsoft PowerPoint. En lägre procentandel ger en plattare scen, medan en högre procentandel ger en högre scen inom samma diagramobjekt. PowerPoint kan också justera axelns tickintervall och etikettplacering för att passa scenen.

| Höjd: 50% | Höjd: 100% | Höjd: 200% |
| --- | --- | --- |
| ![3D-kolumndiagram med höjd inställd på 50 % av dess bredd](height_percent_50.png) | ![3D-kolumndiagram med höjd inställd på 100 % av dess bredd](height_percent_100.png) | ![3D-kolumndiagram med höjd inställd på 200 % av dess bredd](height_percent_200.png) |

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Höjden på 3D‑scenen som en procentandel av dess bredd. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Höjden på diagramobjektet på bilden, i punkter. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Djupet på 3D‑scenen som en procentandel av dess bredd. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |

Höjdinställningen påverkar 3D‑kolumn- och stapeldiagram, inklusive cylinder-, kon- och pyramidvarianter, samt 3D‑linje-, area-, paj- och ytdiagram. Jämförelsen ovan använder den verifierade `Column3D`‑typen. Inställningen ändrar inte utseendet på ett 2D‑`ClusteredColumn`‑diagram eller ett `BubbleWith3D`‑diagram; dessa namn är medlemmar i klassen [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) . För andra diagramutseendeinställningar, se [Chart Formatting](/slides/sv/java/chart-formatting/).

## **Justera avståndet mellan serier**

Använd [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) för att styra avståndet mellan dataserier längs djupaxeln i ett 3D‑diagram, uttryckt som en procentandel av markörens bredd. Använd värden från **0 till 500**, inklusiva: `0` tar bort avståndet, medan större värden ökar avståndet. Med ett fast diagramdjup gör ett ökat avstånd markörerna tunnare längs djupaxeln.

Kom åt gruppen via [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Inställningen gäller för varje serie i den gruppen, inte bara den serie som användes för åtkomst. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) returnerar djupavståndet och speglar gruppens inställning.

Denna inställning påverkar 3D‑kolumn- och stapeldiagram, inklusive deras cylinder-, kon- och pyramidvarianter, samt 3D‑linje- och area-diagram. Utseendet beror på om serierna är arrangerade i djup, i kluster eller staplade. För en tydlig jämförelse av avstånd mellan separata serier, använd `ChartType.Column3D` från klassen [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) .

| Metod | Effekt |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Avstånd mellan intilliggande stapel- eller kolumnkluster, som en procentandel av stapelns eller kolumnens bredd. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Totalt diagramdjup, som en procentandel av diagrammets bredd. |

Det följande självständiga exemplet använder standarddiagramdata, som innehåller tre serier och fyra kategorier. Det sparar två presentationer med identisk data, rotation, avståndsbredd och diagramdjup; endast avståndsdjupet förändras.

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

Följande bilder illustrerar samma avståndsdjupinställningar i motsvarande .NET‑exempel och exporterades med Microsoft PowerPoint.

| Avståndsdjup: 0% | Avståndsdjup: 500% |
| --- | --- |
| ![3D-kolumndiagram utan avstånd mellan serier längs djupaxeln](gap_depth_0.png) | ![3D-kolumndiagram med 500 % avstånd mellan serier längs djupaxeln](gap_depth_500.png) |

## **Ändra 3D-serietyp och stapelform**

I ett klustrat cylindrisk diagram börjar den första serien med en cylindrisk stapelform. Exemplet skriver ut de heltalsvärden som returneras av [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) och [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) före och efter varje ändring. Tabellen ger de motsvarande konstantnamnen.

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

| Ändring av första serien | Serietyp | Stapelform |
| --- | --- | --- |
| Skapa diagrammet | `ClusteredCylinder` | `Cylinder` |
| Ställ in serietypen till `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ställ in stapelformen till `Box` | `ClusteredColumn3D` | `Box` |

Att ställa in formen till `Box` ändrar också serietypen till `ClusteredColumn3D`. Om din kod delar på serietypen, anropa `series.getType()` efter att ha ändrat formen. Ett värde som cachats innan tilldelningen skulle fortfarande välja `ClusteredCone`‑grenen.

![PowerPoint-jämförelse som visar den första serien som cylindrar, koner och rektangulära kolumner från vänster till höger](series-shapes.png)

## **FAQ**

**Vilka diagramtyper stödjer 3D-läge i Aspose.Slides?**

Aspose.Slides stödjer 3D-varianter av kolumndiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via klassen [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) . För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D-diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild med [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) eller [rendera hela bilden](/slides/sv/java/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en raster‑förhandsvisning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterar byggandet och rendering av stora 3D-diagram?**

Prestanda beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekterna på ett minimum, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämpligt stor utskrift (upplösning och dimensioner) för att matcha målvisning eller utskriftsbehov.