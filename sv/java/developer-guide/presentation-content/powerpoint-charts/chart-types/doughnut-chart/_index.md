---
title: Anpassa munkdiagram i presentationer med Java
linktitle: Munkdiagram
type: docs
weight: 30
url: /sv/java/doughnut-chart/
keywords:
- munkdiagram
- mittenhål
- hålstorlek
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar munkdiagram i Aspose.Slides för Java, med stöd för PowerPoint-format för dynamiska presentationer."
---
## **Översikt**

Den här artikeln visar hur du arbetar med ett munkdiagram i Aspose.Slides genom att lägga till diagrammet på en bild, ange storleken på dess centrala hål och spara presentationen. Fokus ligger på metoden `setDoughnutHoleSize` och demonstrerar de grundläggande stegen som krävs för att anpassa den här diagramtypen i kod.

Den innehåller också en kort FAQ som behandlar relaterade scenarier för munkdiagram, såsom att använda flera serier för att skapa flera ringar, arbeta med exploderade munkdiagram och exportera ett diagram som rasterbild eller SVG.

## **Ange mittenhålet i ett munkdiagram**
{{% alert color="info" %}} 

Aspose.Slides för Java stöder nu att specificera storleken på hålet i ett munkdiagram. I detta avsnitt ser vi med ett exempel hur man anger storleken på hålet i ett munkdiagram.

{{% /alert %}} 

För att ange storleken på hålet i ett munkdiagram, följ stegen nedan:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation)-objektet.  
1. Lägg till ett munkdiagram på bilden.  
1. Ange storleken på hålet i ett munkdiagram.  
1. Skriv presentationen till disk.

I exemplet nedan har vi ställt in storleken på hålet i ett munkdiagram.

```java
import com.aspose.slides.*;

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

## **Vanliga frågor**

### Kan jag skapa ett flerlagrat munkdiagram med flera ringar?

Ja. Lägg till flera serier i ett enda munkdiagram—varje serie blir en separat ring. Ringordningen bestäms av ordningen på serierna i samlingen.

### Stöds ett “exploderat” munkdiagram (separerade segment)?

Ja. Det finns en Exploderad munk [diagramtyp](https://reference.aspose.com/slides/sv/java/com.aspose.slides/charttype/) och en explosions‑egenskap på datapunkter; du kan separera enskilda segment.

### Hur kan jag få en bild av ett munkdiagram (PNG/SVG) för en rapport?

Ett diagram är en form; du kan rendera det till en [rasterbild](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getImage-int-float-float-) eller exportera diagrammet till en [SVG‑bild](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).