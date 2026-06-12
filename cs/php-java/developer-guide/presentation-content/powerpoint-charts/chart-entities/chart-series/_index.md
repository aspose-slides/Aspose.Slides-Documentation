---
title: Správa datových řad grafu v prezentacích pomocí PHP
linktitle: Datové řady
type: docs
url: /cs/php-java/chart-series/
keywords:
- řady grafu
- překrytí řad
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera řady
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak v PHP spravovat datové řady grafu pro PowerPoint (PPT/PPTX) pomocí praktických příkladů kódu a osvědčených postupů, které vylepší vaše datové prezentace."
---
## **Přehled**

Tento článek popisuje roli objektu ChartSeries v Aspose.Slides, zaměřuje se na to, jak jsou data strukturována a vizualizována v prezentacích. Tyto objekty poskytují základní prvky, které definují jednotlivé sady datových bodů, kategorie a parametry vzhledu v grafu. Prací s objektem ChartSeries mohou vývojáři bez problémů integrovat podkladové datové zdroje a zachovat plnou kontrolu nad tím, jak jsou informace zobrazovány, což vede k dynamickým, na datech založeným prezentacím, které jasně předávají postřehy a analýzy.

Řada je řada nebo sloupec čísel vykreslených v grafu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řady grafu**

Pomocí metody getParentSeriesGroup můžete určit, jak moc se mají sloupce a pruhy překrývat v 2D grafu (rozsah: -100 až 100). Toto vlastnost se vztahuje na všechny řady v nadřazené skupině řad: jedná se o projekci odpovídající vlastnosti skupiny. Proto je tato vlastnost jen pro čtení. 

Použijte metodu `ChartSeriesGroup::setOverlap` k nastavení preferované hodnoty pro `Overlap`. 

1. Vytvořte instanci třídy Presentation.
1. Přidejte seskupený sloupcový graf na snímek.
1. Získejte první řadu grafu.
1. Získejte `ParentSeriesGroup` řady grafu a nastavte preferovanou hodnotu překrytí pro řadu. 
1. Uložte upravenou prezentaci do souboru PPTX.

Tento PHP kód ukazuje, jak nastavit překrytí pro řadu grafu:

```php
  $pres = new Presentation();
  try {
    # Přidá graf
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Nastaví překrytí řady
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Zapíše soubor prezentace na disk
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Změna barvy řady**

Aspose.Slides pro PHP přes Java umožňuje změnit barvu řady tímto způsobem:

1. Vytvořte instanci třídy Presentation.
1. Přidejte graf na snímek.
1. Získejte řadu, jejíž barvu chcete změnit. 
1. Nastavte požadovaný typ výplně a barvu výplně.
1. Uložte upravenou prezentaci.

Tento PHP kód ukazuje, jak změnit barvu řady:

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

## **Změna barvy kategorie řady**

Aspose.Slides pro PHP přes Java umožňuje změnit barvu kategorie řady tímto způsobem:

1. Vytvořte instanci třídy Presentation.
1. Přidejte graf na snímek.
1. Získejte kategorii řady, jejíž barvu chcete změnit.
1. Nastavte požadovaný typ výplně a barvu výplně.
1. Uložte upravenou prezentaci.

Tento kód ukazuje, jak změnit barvu kategorie řady:

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

## **Změna názvu řady** 

Ve výchozím nastavení jsou názvy legendy pro graf obsaženy v buňkách nad každým sloupcem nebo řádkem dat. 

V našem příkladu (ukázkový obrázek), 

* sloupce jsou *Series 1, Series 2,* a *Series 3*;
* řádky jsou *Category 1, Category 2, Category 3,* a *Category 4.* 

Aspose.Slides pro PHP přes Java umožňuje aktualizovat nebo změnit název řady v datech grafu a legendě.

Tento PHP kód ukazuje, jak změnit název řady v datech grafu `ChartDataWorkbook`:

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

Tento PHP kód ukazuje, jak změnit název řady v legendě pomocí`Series`:

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

## **Nastavení barvy výplně řady grafu**

Aspose.Slides pro PHP přes Java umožňuje nastavit automatickou barvu výplně řady grafu v oblasti kresby tímto způsobem:

1. Vytvořte instanci třídy Presentation.
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty podle vámi preferovaného typu (v níže uvedeném příkladu jsme použili `ChartType::ClusteredColumn`).
1. Získejte řadu grafu a nastavte barvu výplně na Automatic.
1. Uložte prezentaci do souboru PPTX.

Tento PHP kód ukazuje, jak nastavit automatickou barvu výplně pro řadu grafu:

```php
  $pres = new Presentation();
  try {
    # Vytvoří seskupený sloupcový graf
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Nastaví formát výplně řady na automatický
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Zapíše soubor prezentace na disk
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavení invertované barvy výplně pro řadu grafu**
Aspose.Slides umožňuje nastavit invertovanou barvu výplně řady grafu v oblasti kresby tímto způsobem:

1. Vytvořte instanci třídy Presentation.
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty podle vámi preferovaného typu (v níže uvedeném příkladu jsme použili `ChartType::ClusteredColumn`).
1. Získejte řadu grafu a nastavte barvu výplně na invert.
1. Uložte prezentaci do souboru PPTX.

Tento PHP kód demonstruje operaci:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Přidá nové řady a kategorie
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Vezme první řadu grafu a naplní její data.
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

## **Nastavení řady, aby se invertovala při záporné hodnotě**
Aspose.Slides umožňuje nastavit invertování pomocí vlastností `IChartDataPoint.InvertIfNegative` a `ChartDataPoint.InvertIfNegative`. Když je invertování nastaveno pomocí těchto vlastností, datový bod invertuje své barvy, pokud získá zápornou hodnotu. 

Tento PHP kód demonstruje operaci:

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

## **Vymazání konkrétních dat bodu**
Aspose.Slides pro PHP přes Java umožňuje vymazat data `DataPoints` pro konkrétní řadu grafu tímto způsobem:

1. Vytvořte instanci třídy Presentation.
2. Získejte referenci na snímek podle jeho indexu.
3. Získejte referenci na graf podle jeho indexu.
4. Projděte všechny `DataPoints` grafu a nastavte `XValue` a `YValue` na null.
5. Vymažte všechny `DataPoints` pro konkrétní řadu grafu.
6. Uložte upravenou prezentaci do souboru PPTX.

Tento PHP kód demonstruje operaci:

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

## **Nastavení šířky mezery řady**
Aspose.Slides pro PHP přes Java umožňuje nastavit šířku mezery řady pomocí **`GapWidth`** vlastnosti tímto způsobem:

1. Vytvořte instanci třídy Presentation.
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Získejte libovolnou řadu grafu.
1. Nastavte vlastnost `GapWidth`.
1. Uložte upravenou prezentaci do souboru PPTX.

Tento kód ukazuje, jak nastavit šířku mezery řady:

```php
  # Vytvoří prázdnou prezentaci
  $pres = new Presentation();
  try {
    # Získá první snímek prezentace
    $slide = $pres->getSlides()->get_Item(0);
    # Přidá graf s výchozími daty
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Nastaví index listu s daty grafu
    $defaultWorksheetIndex = 0;
    # Získá list s daty grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Přidá řady
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Přidá kategorie
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Získá druhou řadu grafu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Naplní data řady
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Nastaví hodnotu GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Uloží prezentaci na disk
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Existuje limit, kolik řad může jeden graf obsahovat?**

Aspose.Slides neuvádí žádný pevný limit počtu řad, které můžete přidat. Praktický limit je dán čitelností grafu a množstvím paměti dostupné vaší aplikaci.

**Co když jsou sloupce v rámci klastru příliš blízko u sebe nebo naopak příliš daleko?**

Upravte nastavení `GapWidth` pro danou řadu (nebo její nadřazenou skupinu řad). Zvýšením hodnoty zvětšíte mezeru mezi sloupci, snížením ji přiblížíte.