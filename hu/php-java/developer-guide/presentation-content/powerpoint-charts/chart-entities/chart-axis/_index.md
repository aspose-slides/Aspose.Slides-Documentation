---
title: Diagram tengelyek testreszabása bemutatókban PHP segítségével
linktitle: Diagram tengely
type: docs
url: /hu/php-java/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengely pozíció
- PowerPoint
- bemutató
- PHP
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for PHP via Java-t a diagram tengelyek testreszabásához PowerPoint bemutatókban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan testre szabhatók a diagram tengelyei az Aspose.Slides-ben. Megmutatja, hogyan lehet lekérni a tényleges tengelyértékeket, adatcserét végrehajtani a tengelyek között, elrejteni a függőleges vagy vízszintes tengelyt vonaldiagramok esetén, módosítani a kategória tengely típusát, beállítani a dátumformátumot a kategória tengely értékeihez, elforgatni egy tengelycímkét, beállítani a tengely pozícióját, és megjeleníteni egy egységcímkét az értéktengelyen.

## **Maximum értékek lekérése a függőleges tengelyen diagramokon**

Az Aspose.Slides for PHP via Java lehetővé teszi a minimum és maximum értékek lekérését egy függőleges tengelyen. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
2. Hozzáférés az első diára.
3. Diagram hozzáadása alapértelmezett adatokkal.
4. A tengely tényleges maximum értékének lekérése.
5. A tengely tényleges minimum értékének lekérése.
6. A tengely tényleges fő egységének lekérése.
7. A tengely tényleges alsegységének lekérése.
8. A tengely tényleges fő egység skálájának lekérése.
9. A tengely tényleges alsegység skálájának lekérése.

Ez a mintakód – a fenti lépések megvalósítása – megmutatja, hogyan lehet lekérni a szükséges értékeket :

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # A bemutató mentése
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Adatok cseréje a tengelyek között**

Az Aspose.Slides gyors adatcserét tesz lehetővé a tengelyek között – a függőleges tengelyen (y‑tengely) megjelenő adatok a vízszintes tengelyre (x‑tengely) kerülnek, és fordítva.

Ez a PHP kód megmutatja, hogyan hajtható végre az adatcsere feladat a tengelyek között egy diagramon:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # Átállítja a sorokat és oszlopokat
    $chart->getChartData()->switchRowColumn();
    # Bemutató mentése
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Függőleges tengely letiltása vonaldiagramoknál**

Ez a PHP kód megmutatja, hogyan rejtheti el a függőleges tengelyt egy vonaldiagram esetén:

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

## **Vízszintes tengely letiltása vonaldiagramoknál**

Ez a kód megmutatja, hogyan rejtheti el a vízszintes tengelyt egy vonaldiagram esetén:

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

## **Kategória tengely módosítása**

A **CategoryAxisType** tulajdonság használatával megadhatja a kívánt kategória tengely típust (**date** vagy **text**). Ez a kód bemutatja a műveletet:

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

## **Dátumformátum beállítása a kategória tengely értékeihez**

Az Aspose.Slides for PHP via Java lehetővé teszi a dátumformátum beállítását egy kategória tengely értékéhez. A művelet ebben a PHP kódban van bemutatva:

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

## **Forgatási szög beállítása a diagram tengelycíméhez**

Az Aspose.Slides for PHP via Java lehetővé teszi a forgatási szög beállítását egy diagram tengelycíméhez. Ez a PHP kód mutatja be a műveletet:

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

## **Tengely pozíció beállítása kategória vagy érték tengelyen**

Az Aspose.Slides for PHP via Java lehetővé teszi a tengely pozíció beállítását egy kategória vagy érték tengelyen. Ez a PHP kód bemutatja, hogyan hajtható végre a feladat:

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

## **Egységcímke megjelenítésének engedélyezése a diagram értéktengelyén**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy a diagram értéktengelyén egységcímkét jelenítsen meg. Ez a PHP kód mutatja a műveletet:

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

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely keresztezi a másikat (tengelykereszteződés)?**

A tengelyek rendelkeznek egy [kereszteződési beállítással](https://reference.aspose.com/slides/hu/php-java/aspose.slides/axis/setcrosstype/): választhat, hogy a nulla, a maximális kategória/érték vagy egy adott numerikus érték pontján keresztezzenek. Ez hasznos a X‑tengely fel vagy le mozgatásához, illetve egy alapvonal hangsúlyozásához.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest (az oldalán, kívül, belül)?**

Állítsa be a [címke pozíciót](https://reference.aspose.com/slides/hu/php-java/aspose.slides/axis/setmajortickmark/) a „cross”, „outside” vagy „inside” értékek egyikére. Ez befolyásolja az olvashatóságot, és segít helyet takarítani, különösen kis diagramok esetén.