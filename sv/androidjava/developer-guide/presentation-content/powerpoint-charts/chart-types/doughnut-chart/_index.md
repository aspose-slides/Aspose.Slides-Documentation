---
title: Anpassa munkdiagram i presentationer på Android
linktitle: Munkdiagram
type: docs
weight: 30
url: /sv/androidjava/doughnut-chart/
keywords:
- munkdiagram
- centrumgap
- hålstorlek
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar munkdiagram i Aspose.Slides för Android via Java, med stöd för PowerPoint‑format för dynamiska presentationer."
---
## **Översikt**

Den här artikeln visar hur man arbetar med ett munkdiagram i Aspose.Slides genom att lägga till diagrammet på en bild, ange storleken på dess centrumhål och spara presentationen. Den fokuserar på metoden `setDoughnutHoleSize` och demonstrerar de grundläggande stegen som krävs för att anpassa den här diagramtypen i kod.

Den innehåller också en kort FAQ som täcker relaterade scenario för munkdiagram, såsom att använda flera serier för att skapa flera ringar, arbeta med exploderade munkdiagram och exportera ett diagram som en rasterbild eller SVG.

## **Ange centrumgapet i ett munkdiagram**
{{% alert color="primary" %}} 
Aspose.Slides för Android via Java stöder nu att specificera storleken på hålet i ett munkdiagram. I det här avsnittet kommer vi att se med ett exempel hur man anger storleken på hålet i ett munkdiagram.
{{% /alert %}} 

För att ange storleken på hålet i ett munkdiagram, följ stegen nedan:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) objekt.
1. Lägg till ett munkdiagram på bilden.
1. Ange storleken på hålet i ett munkdiagram.
1. Skriv presentationen till disk.

I exemplet nedan har vi angett storleken på hålet i ett munkdiagram.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Spara presentationen till disk
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan jag skapa ett flernivå-munkdiagram med flera ringar?**

Ja. Lägg till flera serier i ett enda munkdiagram—varje serie blir en separat ring. Ringordningen bestäms av serienas ordning i samlingen.

**Stöds ett "exploderat" munkdiagram (separerade segment)?**

Ja. Det finns en Exploderad Munk [diagramtyp](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/charttype/) och en exploderings‑egenskap på datapunkter; du kan separera enskilda segment.

**Hur kan jag få en bild av ett munkdiagram (PNG/SVG) för en rapport?**

Ett diagram är en form; du kan rendera det till en [rasterbild](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) eller exportera diagrammet till en [SVG‑bild](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).