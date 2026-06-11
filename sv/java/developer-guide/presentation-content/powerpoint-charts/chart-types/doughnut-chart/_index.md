---
title: Anpassa donutdiagram i presentationer med Java
linktitle: Donutdiagram
type: docs
weight: 30
url: /sv/java/doughnut-chart/
keywords:
- donutdiagram
- centrumgap
- hålstorlek
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar donutdiagram i Aspose.Slides för Java, med stöd för PowerPoint-format för dynamiska presentationer."
---
## **Översikt**

Den här artikeln visar hur du arbetar med ett donutdiagram i Aspose.Slides genom att lägga till diagrammet på en bild, ange storleken på dess centrumhål och spara presentationen. Den fokuserar på metoden `setDoughnutHoleSize` och visar de grundläggande stegen som krävs för att anpassa denna diagramtyp i kod.

Den innehåller också en kort FAQ som täcker relaterade donutdiagram-scenarier, såsom att använda flera serier för att skapa flera ringar, arbete med exploderade donutdiagram och export av ett diagram som rasterbild eller SVG.

## **Ange centrumgapet i ett donutdiagram**
{{% alert color="primary" %}} 

Aspose.Slides for Java stöder nu att ange storleken på hålet i ett donutdiagram. I det här avsnittet ser vi med ett exempel hur du specificerar storleken på hålet i ett donutdiagram.

{{% /alert %}} 

För att ange storleken på hålet i ett donutdiagram, följ stegen nedan:

1. Skapa ett [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation)-objekt.
1. Lägg till ett donutdiagram på bilden.
1. Ange storleken på hålet i ett donutdiagram.
1. Spara presentationen till disk.

I exemplet nedan har vi angett storleken på hålet i ett donutdiagram.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Skriv presentationen till disk
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag skapa ett flernivå-donut med flera ringar?**

Ja. Lägg till flera serier i ett enda donutdiagram - varje serie blir en separat ring. Ringordningen bestäms av ordningen på serierna i samlingen.

**Stöds ett "exploderat" donut (separerade segment)?**

Ja. Det finns en Exploderad donut [chart type](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/) samt en explosions-egenskap på datapunkter; du kan separera enskilda segment.

**Hur kan jag få en bild av ett donutdiagram (PNG/SVG) för en rapport?**

Ett diagram är en form; du kan rendera det till en [raster image](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getImage-int-float-float-) eller exportera diagrammet till en [SVG image](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).