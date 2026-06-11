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
description: "Lär dig hur du skapar och anpassar 3D-diagram i Aspose.Slides för Node.js via Java, med stöd för PPT- och PPTX-filer—höj dina presentationer idag."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar ett 3D-diagram i Aspose.Slides genom att konfigurera `Rotation3D`‑inställningar såsom `RotationX`, `RotationY`, `DepthPercents` och `RightAngleAxes`. Den går igenom att skapa en presentation, lägga till ett 3D-diagram med standarddata, tillämpa de nödvändiga 3D‑vyinställningarna och spara den ändrade presentationen som en PPTX‑fil.

## **Ställ in RotationX-, RotationY- och DepthPercents‑egenskaper för 3D-diagram**

Aspose.Slides för Node.js via Java tillhandahåller ett enkelt API för att ställa in dessa egenskaper. Följande artikel hjälper dig att sätta olika egenskaper som **X,Y Rotation, DepthPercents** osv. Exempelprogrammet tillämpar inställning av de nämnda egenskaperna.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Kom åt den första bilden.
3. Lägg till ett diagram med standarddata.
4. Ställ in Rotation3D‑egenskaperna.
5. Skriv den ändrade presentationen till en PPTX‑fil.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Åtkomst till första bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägg till diagram med standarddata
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Ställer in index för diagramdatasblad
    var defaultWorksheetIndex = 0;
    // Hämtar kalkylbladet för diagramdata
    var fact = chart.getChartData().getChartDataWorkbook();
    // Lägg till serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Lägg till kategorier
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Ställ in Rotation3D-egenskaper
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Hämta andra diagramserien
    var series = chart.getChartData().getSeries().get_Item(1);
    // Fyll nu i serie-data
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Ställ in OverLap‑värde
    series.getParentSeriesGroup().setOverlap(100);
    // Skriv presentation till disk
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Vilka diagramtyper stödjer 3D‑läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via uppräkningen [ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/). För en exakt, uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/) i API‑referensen för din installerade version.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild via [chart API](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getImage) eller [rendera hela bilden](/slides/sv/nodejs-java/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en pixelperfekt förhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterar byggandet och renderingen av stora 3D‑diagram?**

Prestanda beror på datamängd och visuell komplexitet. För bästa resultat, håll 3D‑effekterna minimala, undvik tunga texturer på ytor och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämpligt stor utdata (upplösning och dimensioner) som matchar målskärmen eller utskriftsbehovet.