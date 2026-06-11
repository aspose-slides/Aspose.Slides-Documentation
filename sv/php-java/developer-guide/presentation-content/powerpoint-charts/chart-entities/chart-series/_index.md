---
title: Hantera diagramdataserier i presentationer med PHP
linktitle: Dataserier
type: docs
url: /sv/php-java/chart-series/
keywords:
- diagramserier
- serieöverlappning
- seriefärg
- kategorifärg
- serienamn
- datapunkt
- seriegap
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hanterar diagramdataserier i PHP för PowerPoint (PPT/PPTX) med praktiska kodexempel och bästa praxis för att förbättra dina datapresentationer."
---
## **Översikt**

Denna artikel beskriver rollen för [ChartSeries](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseries/) i Aspose.Slides, med fokus på hur data struktureras och visualiseras i presentationer. Dessa objekt tillhandahåller de grundläggande elementen som definierar individuella uppsättningar av datapunkter, kategorier och utseendeparametrar i ett diagram. Genom att arbeta med [ChartSeries](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseries/) kan utvecklare sömlöst integrera underliggande datakällor och behålla full kontroll över hur information visas, vilket resulterar i dynamiska, datadrivna presentationer som tydligt förmedlar insikter och analyser.

En serie är en rad eller kolumn med tal som plottas i ett diagram.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Ange överlappning för diagramserien**

Med metoden [getParentSeriesGroup](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseries/#getParentSeriesGroup) kan du ange hur mycket staplar och kolumner ska överlappa i ett 2D-diagram (intervall: -100 till 100). Denna egenskap gäller för alla serier i den överordnade serieggruppen: detta är en projektion av den motsvarande gruppens egenskap. Därför är denna egenskap skrivskyddad.

Använd metoden `ChartSeriesGroup::setOverlap` för att ange ditt föredragna värde för `Overlap`.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Lägg till ett grupperat kolumndiagram på en bild.
3. Hämta den första diagramserien.
4. Hämta diagramseriens `ParentSeriesGroup` och ange ditt föredragna överlappningsvärde för serien.
5. Skriv den modifierade presentationen till en PPTX-fil.

Denna PHP‑kod visar hur du anger överlappning för en diagramserie:

```php
  $pres = new Presentation();
  try {
    # Lägger till diagram
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Ställer in seriernas överlappning
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Skriver presentationsfilen till disk
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra seriefärg**

Aspose.Slides för PHP via Java låter dig ändra färgen på en serie på detta sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Lägg till ett diagram på bilden.
3. Hämta den serie vars färg du vill ändra.
4. Ange önskad fyllningstyp och fyllningsfärg.
5. Spara den modifierade presentationen.

Denna PHP‑kod visar hur du ändrar färgen på en serie:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra färg på seriekategori**

Aspose.Slides för PHP via Java låter dig ändra färgen på en seriekategori på detta sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Lägg till ett diagram på bilden.
3. Hämta den seriekategori vars färg du vill ändra.
4. Ange önskad fyllningstyp och fyllningsfärg.
5. Spara den modifierade presentationen.

Denna kod visar hur du ändrar färgen på en seriekategori:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ändra seriens namn**

Som standard är legendarens namn för ett diagram innehållet i cellerna ovanför varje kolumn eller rad med data.

I vårt exempel (exempelbild),

* kolumnerna är *Series 1, Series 2,* och *Series 3*;
* raderna är *Category 1, Category 2, Category 3,* och *Category 4.*

Aspose.Slides för PHP via Java låter dig uppdatera eller ändra ett seriens namn i dess diagramdata och legend.

Denna PHP‑kod visar hur du ändrar en seriens namn i dess diagramdata `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Denna PHP‑kod visar hur du ändrar ett seriens namn i dess legend via `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange fyllningsfärg för diagramserien**

Aspose.Slides för PHP via Java låter dig ange den automatiska fyllningsfärgen för diagramserier i ett plotområde på detta sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta referensen till en bild via dess index.
3. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType::ClusteredColumn`).
4. Hämta diagramserien och sätt fyllningsfärgen till Automatic.
5. Spara presentationen till en PPTX-fil.

Denna PHP‑kod visar hur du anger den automatiska fyllningsfärgen för en diagramserie:

```php
  $pres = new Presentation();
  try {
    # Skapar ett grupperat kolumndiagram
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Ställer in seriefyllformat till automatiskt
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Skriver presentationsfilen till disk
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange inverterad fyllningsfärg för en diagramserie**

Aspose.Slides låter dig ange den inverterade fyllningsfärgen för diagramserier i ett plotområde på detta sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta referensen till en bild via dess index.
3. Lägg till ett diagram med standarddata baserat på din föredragna typ (i exemplet nedan använde vi `ChartType::ClusteredColumn`).
4. Hämta diagramserien och sätt fyllningsfärgen till invert.
5. Spara presentationen till en PPTX-fil.

Denna PHP‑kod demonstrerar operationen:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Lägger till nya serier och kategorier
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Hämtar den första diagramserien och fyller i dess seriedata.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ställ in att en serie inverteras när värdet är negativt**

Aspose.Slides låter dig ställa in inverteringar via egenskaperna `IChartDataPoint.InvertIfNegative` och `ChartDataPoint.InvertIfNegative`. När en invertering har satts med egenskaperna inverteras datapunkten färgmässigt när den får ett negativt värde.

Denna PHP‑kod demonstrerar operationen:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rensa specifika punktdata**

Aspose.Slides för PHP via Java låter dig rensa `DataPoints`‑data för en specifik diagramserie på detta sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta referensen till en bild via dess index.
3. Hämta referensen till ett diagram via dess index.
4. Iterera över alla diagrammets `DataPoints` och sätt `XValue` och `YValue` till null.
5. Rensa alla `DataPoints` för en specifik diagramserie.
6. Skriv den modifierade presentationen till en PPTX-fil.

Denna PHP‑kod demonstrerar operationen:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange gapbredd för serien**

Aspose.Slides för PHP via Java låter dig ange en seriens Gap Width genom egenskapen **`GapWidth`** på detta sätt:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta den första bilden.
3. Lägg till ett diagram med standarddata.
4. Hämta någon diagramserie.
5. Ställ in egenskapen `GapWidth`.
6. Skriv den modifierade presentationen till en PPTX-fil.

Denna kod visar hur du anger en seriens Gap Width:

```php
  # Skapar en tom presentation
  $pres = new Presentation();
  try {
    # Hämtar presentationens första bild
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till ett diagram med standarddata
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Anger index för diagrammets datasheet
    $defaultWorksheetIndex = 0;
    # Hämtar diagrammets dataarbetsblad
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Lägger till serier
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Lägger till kategorier
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Hämtar den andra diagramserien
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Fyller seriedatan
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Anger GapWidth‑värde
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Sparar presentationen till disk
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Finns det någon gräns för hur många serier ett enda diagram kan innehålla?**

Aspose.Slides har ingen fast begränsning för antalet serier du kan lägga till. Den praktiska gränsen bestäms av diagrammets läsbarhet och av det minne som finns tillgängligt för din applikation.

**Vad händer om kolumnerna inom en grupp är för nära varandra eller för långt ifrån varandra?**

Justera `GapWidth`‑inställningen för den serien (eller dess överordnade serieggrupp). Att öka värdet breddar avståndet mellan kolumnerna, medan en minskning gör dem närmare varandra.