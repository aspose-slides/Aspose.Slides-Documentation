---
title: Přizpůsobení os grafu v prezentacích pomocí PHP
linktitle: Osa grafu
type: docs
url: /cs/php-java/chart-axis/
keywords:
- osa grafu
- vertikální osa
- horizontální osa
- přizpůsobení osy
- manipulace s osou
- správa osy
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides for PHP via Java přizpůsobit osy grafu v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu v Aspose.Slides. Ukazuje, jak získat skutečné hodnoty os, prohodit data mezi osami, skrýt vertikální nebo horizontální osu pro spojnicové grafy, změnit typ osy kategorií, nastavit formát data pro hodnoty osy kategorií, otočit název osy, nastavit polohu osy a zobrazit jednotkový štítek na hodnotové ose.

## **Získání maximálních hodnot na vertikální ose v grafech**
Aspose.Slides for PHP via Java umožňuje získat minimální a maximální hodnoty na vertikální ose. Proveďte následující kroky:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte přístup k první snímku.
3. Přidejte graf s výchozími daty.
4. Získejte skutečnou maximální hodnotu na ose.
5. Získejte skutečnou minimální hodnotu na ose.
6. Získejte skutečnou hlavní jednotku osy.
7. Získejte skutečnou vedlejší jednotku osy.
8. Získejte skutečnou stupnici hlavní jednotky osy.
9. Získejte skutečnou stupnici vedlejší jednotky osy.

Tento ukázkový kód – implementace výše uvedených kroků – ukazuje, jak získat požadované hodnoty :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # Uloží prezentaci
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Prohození dat mezi osami**
Aspose.Slides umožňuje rychle prohodit data mezi osami – data zobrazená na vertikální ose (y‑osa) se přesunou na horizontální osu (x‑osa) a naopak.

Tento PHP kód ukazuje, jak provést výměnu dat mezi osami v grafu:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Přepíná řádky a sloupce
    $chart->getChartData()->switchRowColumn();
    # Uloží prezentaci
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zakázání vertikální osy pro spojnicové grafy**

Tento PHP kód ukazuje, jak skrýt vertikální osu pro spojnicový graf:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zakázání horizontální osy pro spojnicové grafy**

Tento kód ukazuje, jak skrýt horizontální osu pro spojnicový graf:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Změna osy kategorií**

Pomocí vlastnosti **CategoryAxisType** můžete určit požadovaný typ osy kategorií (**date** nebo **text**). Tento kód demonstruje operaci:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Nastavení formátu data pro hodnoty osy kategorií**
Aspose.Slides for PHP via Java umožňuje nastavit formát data pro hodnotu osy kategorií. Operace je demonstrována v tomto PHP kódu:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Nastavení úhlu otáčení názvu osy grafu**
Aspose.Slides for PHP via Java umožňuje nastavit úhel otáčení názvu osy grafu. Tento PHP kód demonstruje operaci:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Nastavení polohy osy na ose kategorií nebo hodnot**
Aspose.Slides for PHP via Java umožňuje nastavit polohu osy v ose kategorií nebo hodnot. Tento PHP kód ukazuje, jak provést úkol:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Povolení zobrazení jednotky na hodnotové ose grafu**
Aspose.Slides for PHP via Java umožňuje nakonfigurovat graf tak, aby na své hodnotové ose zobrazoval štítek jednotky. Tento PHP kód demonstruje operaci:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jak nastavit hodnotu, ve které se jedna osa protíná s druhou (průsečík os)?**

Osy poskytují [nastavení průsečíku](https://reference.aspose.com/slides/cs/php-java/aspose.slides/axis/setcrosstype/): můžete zvolit průsečík v nule, v maximální kategorii/hodnotě nebo na konkrétní číselné hodnotě. To je užitečné pro posunutí osy X nahoru nebo dolů nebo pro zvýraznění referenční linie.

**Jak mohu umístit popisky značek vzhledem k ose (vedle, venku, uvnitř)?**

Nastavte [polohu štítku](https://reference.aspose.com/slides/cs/php-java/aspose.slides/axis/setmajortickmark/) na „cross“, „outside“ nebo „inside“. Toto ovlivňuje čitelnost a pomáhá šetřit místo, zejména u malých grafů.