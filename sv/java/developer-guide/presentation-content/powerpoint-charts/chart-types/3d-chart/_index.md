---
title: Anpassa 3D-diagram i presentationer med Java
linktitle: 3D-diagram
type: docs
url: /sv/java/3d-chart/
keywords:
- 3D-diagram
- rotering
- djup
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar 3D-diagram i Aspose.Slides för Java, med stöd för PPT och PPTX-filer – förbättra dina presentationer idag."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar ett 3D‑diagram i Aspose.Slides genom att konfigurera `Rotation3D`‑inställningar såsom `RotationX`, `RotationY`, `DepthPercents` och `RightAngleAxes`. Den går igenom att skapa en presentation, lägga till ett 3D‑diagram med standarddata, tillämpa de nödvändiga 3D‑vyinställningarna och spara den ändrade presentationen som en PPTX‑fil.

## **Ställ in egenskaperna RotationX, RotationY och DepthPercents för ett 3D‑diagram**
Aspose.Slides for Java erbjuder ett enkelt API för att ställa in dessa egenskaper. Följande artikel hjälper dig att sätta olika egenskaper såsom **X,Y Rotation, DepthPercents** osv. Exempelprogramkoden tillämpar inställning av de ovan nämnda egenskaperna.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Öppna den första bilden.
3. Lägg till ett diagram med standarddata.
4. Ställ in Rotation3D‑egenskaperna.
5. Skriv den modifierade presentationen till en PPTX‑fil.

```java
Presentation pres = new Presentation();
try {
    // Åtkomst till första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägg till diagram med standarddata
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Ställer in index för diagramdatasheet
    int defaultWorksheetIndex = 0;
    
    // Hämtar diagramdatasbladet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Lägg till serier
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Lägg till kategorier
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Ställ in Rotation3D-egenskaper
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Hämta andra diagramserien
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Nu fyller vi seriedata
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ställ in Overlap‑värde
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Spara presentationen till disk
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Vilka diagramtyper stödjer 3D‑läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via klassen [ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/). För en exakt och uppdaterad lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/) i API‑referensen för den version du har installerat.

**Kan jag få en rasterbild av ett 3D‑diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild via [chart API](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getImage-int-float-float-) eller [render the entire slide](/slides/sv/java/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en pixel‑perfekt förhandsvisning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterar byggande och rendering av stora 3D‑diagram?**

Prestandan beror på datamängd och visuell komplexitet. För bästa resultat, håll 3D‑effekterna minimala, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en output med lämplig storlek (upplösning och dimensioner) för att matcha måldisplay eller utskriftsbehov.