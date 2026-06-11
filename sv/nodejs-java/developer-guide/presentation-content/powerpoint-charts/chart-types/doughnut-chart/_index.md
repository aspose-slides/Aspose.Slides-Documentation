---
title: Anpassa donutdiagram i presentationer med JavaScript
linktitle: Donutdiagram
type: docs
weight: 30
url: /sv/nodejs-java/doughnut-chart/
keywords:
- donutdiagram
- centralt gap
- hålstorlek
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar donutdiagram med JavaScript och Aspose.Slides för Node.js, med stöd för PowerPoint-format för dynamiska presentationer."
---
## **Översikt**

Den här artikeln visar hur man arbetar med ett donutdiagram i Aspose.Slides genom att lägga till diagrammet på en bild, ställa in storleken på dess centrala hål och spara presentationen. Den fokuserar på metoden `setDoughnutHoleSize` och demonstrerar de grundläggande stegen som krävs för att anpassa den här diagramtypen i kod.

Den innehåller också en kort FAQ som täcker relaterade donutdiagram‑scenarier, såsom att använda flera serier för att skapa flera ringar, arbeta med exploderade donutdiagram och att exportera ett diagram som en rasterbild eller SVG.

## **Ändra centralt gap i donutdiagram**

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) objekt.
1. Lägg till ett donutdiagram på bilden.
1. Ange storleken på hålet i ett donutdiagram.
1. Skriv presentationen till disk.

I exemplet nedan har vi ställt in storleken på hålet i ett donutdiagram.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Skriv presentation till disk
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan jag skapa ett flernivå-donut med flera ringar?**

Ja. Lägg till flera serier i ett enda donutdiagram—varje serie blir en separat ring. Ringordningen bestäms av ordningen på serierna i samlingen.

**Stöds ett "exploderat" donut (separerade segment)?**

Ja. Det finns en Exploderad donut [diagramtyp](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/charttype/) och en exploderings‑egenskap på datapunkter; du kan separera enskilda segment.

**Hur kan jag få en bild av ett donutdiagram (PNG/SVG) för en rapport?**

Ett diagram är en form; du kan rendera det till en [rasterbild](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getImage) eller exportera diagrammet till en [SVG‑bild](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/writeassvg/).