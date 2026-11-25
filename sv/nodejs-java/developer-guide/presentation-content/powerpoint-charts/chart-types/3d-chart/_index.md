---
title: Anpassa 3D-diagram i presentationer med JavaScript
linktitle: 3D-diagram
type: docs
url: /sv/nodejs-java/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa 3D-diagram i PowerPoint-presentationer med Aspose.Slides för Node.js via Java. Justera rotation, höjdförhållanden, diagramdjup och avstånd mellan serier med JavaScript-exempel."
---
## **Översikt**

Aspose.Slides for Node.js via Java låter dig anpassa vyn av ett 3D-diagram via metoden [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Den här artikeln visar hur du justerar rotation, höjdförhållanden, djup, räta vinklar på axlarna och avståndet mellan serier, och sedan sparar presentationen i PPTX-format.

## **Ange rotation och djup för ett 3D-diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) och använder [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) för att lägga till ett staplat 3D-kolumn-diagram på dess första bild. Det ersätter standardserierna och -kategorierna med två serier som innehåller tre värden vardera. Arbetsbladindex `0` identifierar diagrammets första dataarbetsblad; rad `0` innehåller serienamnen och kolumn `0` innehåller kategorietiketter.

Metoderna [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) och [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) sätter diagrammets rotation till respektive 40 och 270 grader. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) anger djupet till 150 % av bredden, medan [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) aktiverar räta vinklar på axlarna istället för perspektiv. Den resulterande presentationen innehåller diagrammet med dessa 3D‑vyinställningar.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Applicera en bildfyllning på en 3D-diagramyta**

Du kan fylla [sidovägg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), [bakvägg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) och [golv](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) på ett 3D-diagram var för sig. Ställ in ytan´s [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) till `Picture` och tilldela en bild. Ställ både [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) och ytan´s [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) till `Stretch` för att anpassa en kopia av bilden över ytan.

Spara [arrow.png](arrow.png) i arbetskatalogen. Exemplet roterar diagrammet och höjer det maximala värdet på den vertikala axeln så att golvet syns mellan kolumnerna. Det klonar sedan bilden två gånger och applicerar pilen på en annan yta i varje bild. Alla tre diagram behåller samma data, betraktningsvinkel och bakgrund.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint visar de tre bilderna enligt följande.

| Sidovägg | Bakvägg | Golv |
| --- | --- | --- |
| ![Pil som pekar in i diagrammet längs sidoväggen](side-wall.png) | ![Pil som pekar åt höger över bakväggen](back-wall.png) | ![Pil som pekar åt höger över golvet mellan kolumnerna](floor.png) |

## **Justera höjdförhållandena för ett 3D-diagram**

Använd [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) för att ange diagrammets höjd som en procentandel av dess bredd. Detta ändrar förhållandena i 3D‑scenen utan att ändra storleken på diagramobjektet på bilden.

Följande exempel skapar ett [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)-diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdförhållandena 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, avstånd mellan serier och formatering är identiska i alla tre filer; endast höjdprocenten ändras.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Följande bilder visar samma höjdinställningar i det motsvarande .NET‑exemplet och exporterades med Microsoft PowerPoint. En lägre procentandel ger en plattare scen, medan en högre procentandel ger en högre scen inom samma diagramobjekt. PowerPoint kan också justera axelns tick‑intervall och etikettplacering för att passa scenen.

| Höjd: 50 % | Höjd: 100 % | Höjd: 200 % |
| --- | --- | --- |
| ![3D‑kolumndiagram med höjd satt till 50 % av dess bredd](height_percent_50.png) | ![3D‑kolumndiagram med höjd satt till 100 % av dess bredd](height_percent_100.png) | ![3D‑kolumndiagram med höjd satt till 200 % av dess bredd](height_percent_200.png) |

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Höjd på 3D‑scenen som en procentandel av dess bredd. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Höjd på diagramobjektet på bilden, i punkter. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Djup på 3D‑scenen som en procentandel av dess bredd. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |

Höjdinställningen påverkar 3D‑kolumn‑ och stapeldiagram, inklusive cylinder‑, kon‑ och pyramidalvarianter, samt 3D‑linje-, yta‑, paj‑ och ytdiagram. Jämförelsen ovan använder den verifierade typen `Column3D`. Inställningen ändrar inte utseendet på ett 2D‑`ClusteredColumn`‑diagram eller ett `BubbleWith3D`‑diagram; dessa namn är medlemmar i klassen [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). För andra diagramutseendeinställningar, se [Chart Formatting](/slides/sv/nodejs-java/chart-formatting/).

## **Justera avståndet mellan serier**

Använd [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) för att kontrollera avståndet mellan dataserier längs djupaxeln i ett 3D-diagram, uttryckt i procent av markörens bredd. Använd värden från **0 till 500**, inklusivt: `0` tar bort avståndet, medan större värden ökar avståndet. Med en fast diagramdjup gör ett ökat avstånd markörerna tunnare längs djupaxeln.

Kom åt gruppen via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Inställningen gäller för varje serie i den gruppen, inte bara för den serie som använts för att nå den. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) returnerar djupavståndet och speglar gruppens inställning.

Denna inställning påverkar 3D‑kolumn‑ och stapeldiagram, inklusive deras cylinder‑, kon‑ och pyramidalvarianter, samt 3D‑linje‑ och ytdiagram. Utseendet beror på om serierna är ordnade i djup, grupperade eller staplade. För en tydlig jämförelse av avstånd mellan separata serier, använd `ChartType.Column3D` från klassen [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Dessa metoder styr olika aspekter av diagrammet:

| Metod | Effekt |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Avstånd mellan intilliggande stapel‑ eller kolumnkluster, som en procentandel av stapel‑ eller kolumnbredden. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Totalt diagramdjup, som en procentandel av diagrambreden. |

Följande självständiga exempel använder standarddiagramdata, som innehåller tre serier och fyra kategorier. Det sparar två presentationer med identiska data, rotation, avståndsbredd och diagramdjup; endast djupavståndet ändras.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Följande bilder visar samma djupavståndsinställningar i det motsvarande .NET‑exemplet och exporterades med Microsoft PowerPoint.

| Djupavstånd: 0 % | Djupavstånd: 500 % |
| --- | --- |
| ![3D‑kolumndiagram utan avstånd mellan serier längs djupaxeln](gap_depth_0.png) | ![3D‑kolumndiagram med 500 % avstånd mellan serier längs djupaxeln](gap_depth_500.png) |

## **Ändra 3D‑serietyp och stapelform**

I ett grupperat cylinder‑diagram börjar den första serien med en cylindrisk stapelform. Exemplet skriver ut de heltalsvärden som returneras av [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) och [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) före och efter varje ändring. Tabellen visar motsvarande konstantnamn.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Ändring av den första serien | Serietyp | Stapelform |
| --- | --- | --- |
| Skapa diagrammet | `ClusteredCylinder` | `Cylinder` |
| Ställ in serietyp till `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ställ in stapelform till `Box` | `ClusteredColumn3D` | `Box` |

Att sätta formen till `Box` ändrar också serietypen till `ClusteredColumn3D`. Om din kod har villkor baserade på serietypen, anropa `series.getType()` efter att ha ändrat formen. Ett värde som cachats före tilldelningen skulle fortfarande välja grenen `ClusteredCone`.

![PowerPoint‑jämförelse som visar den första serien som cylindrar, koner och rektangulära kolumner från vänster till höger](series-shapes.png)

## **Vanliga frågor**

**Vilka diagramtyper stödjer 3D‑läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av kolumndiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via klassen [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D-diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild med [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) eller [rendera hela bilden](/slides/sv/nodejs-java/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en raster‑förhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterar byggande och återgivning av stora 3D-diagram?**

Prestanda beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekter minimala, undvik tunga texturer på väggar och plottområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämplig utdata‑storlek (upplösning och dimensioner) som matchar måldisplayen eller utskriftsbehovet.