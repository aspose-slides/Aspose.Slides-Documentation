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

Aspose.Slides for Node.js via Java låter dig anpassa vyn av ett 3D-diagram via metoden [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) . Denna artikel visar hur du justerar rotation, höjdförhållanden, djup, rakvinkliga axlar och avstånd mellan serier, och sedan sparar presentationen i PPTX-format.

## **Ställ in rotation och djup för ett 3D-diagram**

Exemplet nedan skapar en [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) och använder [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) för att lägga till ett staplat 3D-stapeldiagram på dess första bildblad. Det ersätter standardserierna och -kategorierna med två serier som vardera innehåller tre värden. Arbetsbladsindex `0` identifierar diagrammets första datakalkylblad; rad `0` innehåller serienamnen och kolumn `0` innehåller kategorietiketter.

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) och [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) metoderna sätter diagrammets rotation till 40 respektive 270 grader. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) sätter dess djup till 150 % av dess bredd, medan [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) aktiverar räta vinkelaxlar istället för perspektiv. Den resulterande presentationen innehåller det fyllda diagrammet med dessa 3D-vyvärden.

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

## **Justera höjdförhållandena för ett 3D-diagram**

Använd [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) för att sätta höjden på ett 3D-diagram som en procentandel av dess bredd. Detta ändrar proportionerna i 3D-scenen utan att ändra storleken på diagramobjektet på bildsliden.

Följande exempel skapar ett [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) diagram med standarddata: tre serier och fyra kategorier. Det sparar tre presentationer med höjdförhållanden på 50 %, 100 % och 200 %. Diagrammets position, bredd och höjd förblir oförändrade. Data, rotation, djup, seriemellanrum och formatering är identiska i alla tre filer; endast höjdprocenten ändras.

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

Följande bilder illustrerar samma höjdinställningar i det motsvarande .NET-exemplet och exporterades med Microsoft PowerPoint. En lägre procentandel ger en plattare scen, medan en högre procentandel ger en högre scen inom samma diagramobjekt. PowerPoint kan också justera axelns tickintervall och etikettplacering för att passa scenen.

| Höjd: 50% | Höjd: 100% | Höjd: 200% |
| --- | --- | --- |
| ![3D stapeldiagram med höjden inställd på 50 procent av dess bredd](height_percent_50.png) | ![3D stapeldiagram med höjden inställd på 100 procent av dess bredd](height_percent_100.png) | ![3D stapeldiagram med höjden inställd på 200 procent av dess bredd](height_percent_200.png) |

| Metod | Effekt |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Höjden på 3D-scenen som en procentandel av dess bredd. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Höjden på diagramobjektet på bildsliden, i punkter. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Djupet på 3D-scenen som en procentandel av dess bredd. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |

Höjdinställningen påverkar 3D-staplar och -stapeldiagram, inklusive cylindrisk, konisk och pyramidal varianter, samt 3D-linje-, område-, paj- och ytdiagram. Jämförelsen ovan använder den verifierade `Column3D`-typen. Inställningen ändrar inte utseendet på ett 2D `ClusteredColumn`-diagram eller ett `BubbleWith3D`-diagram; dessa namn är medlemmar i klassen [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). För andra diagramutseendeinställningar, se [Diagramformatering](/slides/sv/nodejs-java/chart-formatting/).

## **Justera mellanrummet mellan serier**

Använd [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) för att styra avståndet mellan dataserier längs djupaxeln i ett 3D-diagram, uttryckt som en procentandel av markörens bredd. Använd värden från **0 till 500**, inklusive: `0` tar bort mellanrummet, medan större värden ökar avståndet. Med ett fast diagramdjup gör ett ökat mellanrum markörerna tunnare längs djupaxeln.

Kom åt gruppen via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Inställningen gäller för varje serie i den gruppen, inte bara för den serie som används för åtkomst. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) returnerar djupmellanrummet och återspeglar gruppens inställning.

Denna inställning påverkar 3D-staplar och -stapeldiagram, inklusive deras cylindriska, koniska och pyramida varianter, samt 3D-linje- och områdesdiagram. Utseendet beror på om serierna är ordnade i djup, grupperade eller staplade. För en tydlig jämförelse av mellanrum mellan separata serier, använd `ChartType.Column3D` från klassen [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

| Metod | Effekt |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Avstånd mellan serier längs djupaxeln, som en procentandel av markörens bredd. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Avstånd mellan intilliggande stapel- eller kolumnkluster, som en procentandel av stapel- eller kolumnbredden. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Totalt diagramdjup, som en procentandel av diagrammets bredd. |

Följande fristående exempel använder standarddiagramdata, som innehåller tre serier och fyra kategorier. Det sparar två presentationer med identisk data, rotation, mellanrum och diagramdjup; endast djupmellanrummet ändras.

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

Följande bilder illustrerar samma djupmellanrumsinställningar i det motsvarande .NET-exemplet och exporterades med Microsoft PowerPoint.

| Djupmellanrum: 0% | Djupmellanrum: 500% |
| --- | --- |
| ![3D stapeldiagram utan mellanrum mellan serier längs djupaxeln](gap_depth_0.png) | ![3D stapeldiagram med 500 procent mellanrum mellan serier längs djupaxeln](gap_depth_500.png) |

## **Ändra 3D-serietyp och stapelform**

I ett grupperat cylinderdiagram börjar den första serien med en cylindrisk stapelform. Exemplet skriver ut heltalsvärdena som returneras av [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) och [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) före och efter varje förändring. Tabellen visar motsvarande konstantnamn.

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
| Ställ in serietypen till `ClusteredCone` | `ClusteredCone` | `Cone` |
| Ställ in stapelformen till `Box` | `ClusteredColumn3D` | `Box` |

Att ställa in formen till `Box` ändrar också serietypen till `ClusteredColumn3D`. Om din kod har villkor baserade på serietypen, anropa `series.getType()` efter att ha ändrat formen. ett värde som cachats före tilldelningen skulle fortfarande välja `ClusteredCone`-grenen.

![PowerPoint-jämförelse som visar den första serien som cylindrar, koner och rektangulära kolumner från vänster till höger](series-shapes.png)

## **Vanliga frågor**

**Vilka diagramtyper stödjer 3D-läge i Aspose.Slides?**

Aspose.Slides stödjer 3D-varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D-typer som exponeras via klassen [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) i API-referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D-diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild med [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) eller [render the entire slide](/slides/sv/nodejs-java/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en rasterförhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att behöva PowerPoint.

**Hur presterar byggande och rendering av stora 3D-diagram?**

Prestandan beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D-effekter till ett minimum, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämpligt stor utdata (upplösning och dimensioner) som matchar målskärm eller utskriftsbehov.