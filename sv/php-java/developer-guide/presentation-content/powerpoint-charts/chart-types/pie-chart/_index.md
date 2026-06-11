---
title: Anpassa pajdiagram i presentationer med PHP
linktitle: Pajdiagram
type: docs
url: /sv/php-java/pie-chart/
keywords:
- pajdiagram
- hantera diagram
- anpassa diagram
- diagramalternativ
- diagraminställningar
- plotalternativ
- segmentfärg
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar pajdiagram med Aspose.Slides för PHP via Java, exporterar till PowerPoint, och förbättrar din databerättelse på sekunder."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med pajdiagram i Aspose.Slides. Den visar hur man konfigurerar sekundära plotalternativ för Pie of Pie- och Bar of Pie-diagram, samt hur man aktiverar automatisk färgläggning av segment för ett standardpajdiagram.

Exemplen fokuserar på praktiska anpassningssteg för diagram, såsom att lägga till ett diagram på en bild, justera serier och etikettinställningar, ersätta standarddiagramdata med anpassade kategorier och värden, samt spara den uppdaterade presentationen.

## **Alternativ för sekundär plot för Pie of Pie- och Bar of Pie-diagram**
Aspose.Slides for PHP via Java stödjer nu alternativ för sekundär plot för Pie of Pie- eller Bar of Pie-diagram. I det här avsnittet visar vi hur du specificerar dessa alternativ med Aspose.Slides. För att specificera egenskaperna gör du följande:

1. Skapa ett objekt av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Lägg till diagram på bilden.
1. Specificera diagrammets sekundära plotalternativ.
1. Skriv presentationen till disk.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Lägg till diagram på bilden
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Ange olika egenskaper
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Skriv presentation till disk
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ställ in automatiska färger för segment i pajdiagram**
Aspose.Slides for PHP via Java tillhandahåller ett enkelt API för att ange automatiska färger för segment i pajdiagram. Exempelkoden tillämpar inställning av de ovan nämnda egenskaperna.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Åtkomst till den första bilden.
1. Lägg till diagram med standarddata.
1. Ange diagramtitel.
1. Ställ in den första serien till Visa värden.
1. Ange indexet för diagrammets datablad.
1. Hämta diagrammets dataarbetsblad.
1. Ta bort standardgenererade serier och kategorier.
1. Lägg till nya kategorier.
1. Lägg till ny serie.

Spara den modifierade presentationen till en PPTX-fil.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Lägg till diagram med standarddata
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Ställer in diagramtitel
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Ställ in första serien till Visa värden
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Ställer in indexet för diagrammets datasblad
    $defaultWorksheetIndex = 0;
    # Hämtar diagrammets dataarbetsblad
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Ta bort standardgenererade serier och kategorier
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Lägger till nya kategorier
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Lägger till ny serie
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Nu fyller vi i serie data
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Stöds varianterna 'Pie of Pie' och 'Bar of Pie'?**

Ja, biblioteket [stöder](https://reference.aspose.com/slides/sv/php-java/aspose.slides/charttype/) en sekundär plot för pajdiagram, inklusive typerna 'Pie of Pie' och 'Bar of Pie'.

**Kan jag exportera bara diagrammet som en bild (till exempel PNG)?**

Ja, du kan [exportera diagrammet som en bild](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage) (t.ex. PNG) utan hela presentationen.