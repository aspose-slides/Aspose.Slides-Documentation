---
title: Optimalizovat výpočty grafů pro prezentace v PHP
linktitle: Výpočty grafů
type: docs
weight: 50
url: /cs/php-java/chart-calculations/
keywords:
- výpočty grafu
- prvky grafu
- pozice prvku
- skutečná pozice
- podřízený prvek
- nadřazený prvek
- hodnoty grafu
- skutečná hodnota
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Pochopte výpočty grafů, aktualizace dat a řízení přesnosti v Aspose.Slides pro PHP přes Java pro PPT a PPTX, s praktickými ukázkami kódu."
---
## **Přehled**

Aspose.Slides poskytuje rozhraní API pro práci s výpočty grafů a daty rozvržení v prezentacích. Tento článek ukazuje, jak získat skutečné hodnoty prvků grafu, včetně skutečné polohy a velikosti prvků a skutečných hodnot os grafu. Také vysvětluje, že tyto hodnoty jsou vyplněny po ověření rozvržení grafu.

Dále článek ukazuje, jak získat skutečnou polohu nadřazených prvků grafu a jak skrýt komponenty grafu, jako jsou **Název**, **svislá osa**, **vodorovná osa** a **mřížkové čáry**. Tyto příklady vám pomáhají programově prozkoumat informace o rozvržení grafu a řídit viditelnost prvků grafu v prezentacích PowerPoint.

## **Vypočítat skutečné hodnoty prvků grafu**
Aspose.Slides for PHP via Java poskytuje jednoduché API pro získání těchto vlastností. Metody třídy [Axis](https://reference.aspose.com/slides/cs/php-java/aspose.slides/axis/) poskytují informace o skutečné poloze prvku osy grafu ([getActualMaxValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/axis/getactualmaxvalue/), [getActualMinValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/axis/getactualminvalue/), [getActualMajorUnit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/axis/getactualmajorunit/), [getActualMinorUnit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/axis/getactualminorunit/), [getActualMajorUnitScale](https://reference.aspose.com/slides/cs/php-java/aspose.slides/axis/getactualmajorunitscale/), [getActualMinorUnitScale](https://reference.aspose.com/slides/cs/php-java/aspose.slides/axis/getactualminorunitscale/)). Je nutné předtím zavolat metodu [Chart.validateChartLayout](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/validatechartlayout/), aby se vlastnosti naplnily skutečnými hodnotami.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vypočítat skutečnou polohu nadřazených prvků grafu**
Aspose.Slides for PHP via Java poskytuje jednoduché API pro získání těchto vlastností. Metody třídy `ActualLayout` poskytují informace o skutečné poloze nadřazeného prvku grafu (`getActualX`, `getActualY`, `getActualWidth`, `getActualHeight`). Je nutné předtím zavolat metodu [Chart.validateChartLayout](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/validatechartlayout/), aby se vlastnosti naplnily skutečnými hodnotami.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Skrýt prvky grafu**
Toto téma vám pomůže pochopit, jak skrýt informace v grafu. Pomocí Aspose.Slides for PHP via Java můžete skrýt **Název**, **svislou osu**, **vodorovnou osu** a **mřížkové čáry** v grafu. Níže uvedený příklad kódu ukazuje, jak tyto vlastnosti použít.

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 140, 118, 320, 370);
    # Skrývání názvu grafu
    $chart->setTitle(false);
    # /Skrývání osy hodnot
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    # Viditelnost kategorie osy
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    # Skrývání legendy
    $chart->setLegend(false);
    # Skrývání hlavních mřížkových čar
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->removeAt($i);
    }
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setPosition(LegendDataLabelPosition->Top);
    $series->getMarker()->setSize(15);
    # Nastavení barvy čáry řady
    $series->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $series->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Solid);
    $pres->save("HideInformationFromChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Fungují externí sešity Excelu jako zdroj dat a jak to ovlivňuje přepočet?**

Ano. Graf může odkazovat na externí sešit: když se připojíte nebo obnovíte externí zdroj, vzorce a hodnoty jsou převzaty z tohoto sešitu a graf během otevření/úprav zobrazuje aktualizace. API vám umožňuje [upřesnit externí sešit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/setexternalworkbook/) a spravovat propojená data.

**Mohu vypočítat a zobrazit trendové čáry, aniž bych implementoval regresi sám?**

Ano. [Trendline](https://reference.aspose.com/slides/cs/php-java/trend-line/) (lineární, exponenciální a další) jsou přidávány a aktualizovány Aspose.Slides; jejich parametry jsou automaticky přepočítány z dat řady, takže není nutné provádět vlastní výpočty.

**Pokud má prezentace více grafů s externími odkazy, mohu řídit, který sešit používá pro výpočty hodnot v jednotlivých grafech?**

Ano. Každý graf může odkazovat na svůj vlastní [externí sešit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdata/setexternalworkbook/), nebo můžete pro každý graf vytvořit/nahradit externí sešit nezávisle na ostatních.