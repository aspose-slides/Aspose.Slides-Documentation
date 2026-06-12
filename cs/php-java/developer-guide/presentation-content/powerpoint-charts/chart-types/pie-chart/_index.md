---
title: Přizpůsobení koláčových grafů v prezentacích pomocí PHP
linktitle: Koláčový graf
type: docs
url: /cs/php-java/pie-chart/
keywords:
- koláčový graf
- správa grafu
- přizpůsobení grafu
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva výseč
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se vytvářet a přizpůsobovat koláčové grafy pomocí Aspose.Slides pro PHP přes Java, exportovatelné do PowerPointu, což vám umožní během několika vteřin vylepšit vyprávění dat."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nakonfigurovat možnosti sekundárního výkresu pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů u standardního koláčového grafu.

Příklady se zaměřují na praktické kroky přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti druhého výkresu pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides for PHP via Java nyní podporuje možnosti druhého výkresu pro grafy Pie of Pie nebo Bar of Pie. V tomto tématu vám ukážeme, jak tyto možnosti specifikovat pomocí Aspose.Slides. Pro určení vlastností postupujte takto:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Přidejte graf na snímek.
1. Zadejte možnosti druhého výkresu grafu.
1. Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili různé vlastnosti grafu Pie of Pie.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Přidejte graf na snímek
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Nastavte různé vlastnosti
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Uložte prezentaci na disk
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavte automatické barvy výsečů koláčového grafu**

Aspose.Slides for PHP via Java poskytuje jednoduché API pro nastavení automatických barev výsečů koláčového grafu. Ukázkový kód ukazuje nastavení výše uvedených vlastností.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Nastavte název grafu.
1. Nastavte první sérii na Zobrazit hodnoty.
1. Nastavte index listu s daty grafu.
1. Získání listu s daty grafu.
1. Odstraňte výchozí generované série a kategorie.
1. Přidejte nové kategorie.
1. Přidejte nové série.

Uložte upravenou prezentaci do souboru PPTX.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Přidejte graf s výchozími daty
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Nastavení názvu grafu
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Nastavte první sérii na Zobrazit hodnoty
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Nastavení indexu listu s daty grafu
    $defaultWorksheetIndex = 0;
    # Získání listu s daty grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Odstraňte výchozí generované série a kategorie
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Přidání nových kategorií
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Přidání nové série
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Now populating series data
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

## **Často kladené otázky**

**Jsou podporovány varianty 'Pie of Pie' a 'Bar of Pie'?**

Ano, knihovna [supports](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/) sekundární výkres pro koláčové grafy, včetně typů 'Pie of Pie' a 'Bar of Pie'.

**Mohu exportovat jen graf jako obrázek (například PNG)?**

Ano, můžete [export the chart itself as an image](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage) (například PNG) bez celé prezentace.