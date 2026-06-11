---
title: Anpassa munkdiagram i presentationer med PHP
linktitle: Munkdiagram
type: docs
weight: 30
url: /sv/php-java/doughnut-chart/
keywords:
- munkdiagram
- centralt gap
- hålstorlek
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar munkdiagram i Aspose.Slides för PHP via Java, med stöd för PowerPoint-format för dynamiska presentationer."
---
## **Översikt**

Den här artikeln visar hur man arbetar med ett munkdiagram i Aspose.Slides genom att lägga till diagrammet på en bild, ange storleken på dess centrala hål och spara presentationen. Den fokuserar på metoden `setDoughnutHoleSize` och demonstrerar de grundläggande stegen som krävs för att anpassa denna diagramtyp i kod.

Den innehåller också en kort FAQ som täcker relaterade munkdiagramsscenarier, såsom att använda flera serier för att skapa flera ringar, arbeta med exploderade munkdiagram och exportera ett diagram som rasterbild eller SVG.

## **Ange det centrala gapet i ett munkdiagram**

För att ange storleken på hålet i ett munkdiagram, följ stegen nedan:

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation)-objektet.
1. Lägg till ett munkdiagram på bilden.
1. Ange storleken på hålet i ett munkdiagram.
1. Skriv presentationen till disk.

I exemplet nedan har vi angett storleken på hålet i ett munkdiagram.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Skriv presentationen till disk
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan jag skapa ett flernivå-munkdiagram med flera ringar?**

Ja. Lägg till flera serier i ett enda munkdiagram – varje serie blir en separat ring. Ringordningen bestäms av serienas ordning i samlingen.

**Stöds ett “exploderat” munkdiagram (separerade segment)?**

Ja. Det finns en Exploded Doughnut [chart type](https://reference.aspose.com/slides/sv/php-java/aspose.slides/charttype/) och en exploderings‑egenskap på datapunkter; du kan separera enskilda segment.

**Hur får jag en bild av ett munkdiagram (PNG/SVG) för en rapport?**

Ett diagram är en form; du kan rendera det till en [raster image](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage) eller exportera diagrammet till en [SVG image](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#writeAsSvg).