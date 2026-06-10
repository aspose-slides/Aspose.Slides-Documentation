---
title: Diagram adatelcímkék kezelése prezentációkban PHP használatával
linktitle: Adatelcímke
type: docs
url: /hu/php-java/chart-data-label/
keywords:
- diagram
- adatelcímke
- adat pontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá és formázza a diagram adatelcímkéket PowerPoint prezentációkban az Aspose.Slides for PHP via Java segítségével, hogy vonzóbb diák legyenek."
---
## **Bevezetés**

Az adatelcímkék a diagramon a diagram adatcsoportról vagy az egyes adatpontokról adnak részleteket. Lehetővé teszik az olvasók számára, hogy gyorsan azonosítsák az adatcsoportrákat, és megkönnyítik a diagramok megértését.

## **Az adatpontok pontosságának beállítása a diagram adatelcímkéiben**

Ez a PHP kód megmutatja, hogyan állítható be az adat pontossága egy diagram adatelcímkéjében:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Százalék megjelenítése címkékként**

Az Aspose.Slides for PHP via Java lehetővé teszi, hogy százalékcímkéket állítson be a megjelenített diagramokon. Ez a PHP kód bemutatja a műveletet:

```php
  # Létrehozza a Presentation osztály egy példányát
  $pres = new Presentation();
  try {
    # Lekéri az első diát
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # Elmenti a diagramot tartalmazó prezentációt
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Százalékjel beállítása a diagram adatelcímkékkel**

Ez a PHP kód megmutatja, hogyan állítható be a százalékjel egy diagram adatelcímkéjére:

```php
  # Létrehozza a Presentation osztály egy példányát
  $pres = new Presentation();
  try {
    # Lekéri a dia hivatkozását az indexe alapján
    $slide = $pres->getSlides()->get_Item(0);
    # Létrehozza a PercentsStackedColumn diagramot a diáon
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # A NumberFormatLinkedToSource értékét false-ra állítja
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # Lekéri a diagram adat munkalapját
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # Új sorozatot ad hozzá
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # Beállítja a sorozat kitöltőszínét
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Sets the LabelFormat properties
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Új sorozatot ad hozzá
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # Beállítja a kitöltés típusát és színét
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Kiírja a prezentációt a lemezre
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Címke távolságának beállítása egy tengelytől**

Ez a PHP kód megmutatja, hogyan állítható be a címke távolsága a kategóriatengelytől, amikor tengelyekből felépített diagrammal dolgozik:

```php
  # Létrehozza a Presentation osztály egy példányát
  $pres = new Presentation();
  try {
    # Lekéri a dia hivatkozását
    $sld = $pres->getSlides()->get_Item(0);
    # Létrehozza a diagramot a dián
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # Beállítja a címke távolságát egy tengelytől
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # Kiírja a prezentációt a lemezre
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Címke pozíciójának módosítása**

Amikor olyan diagramot hoz létre, amely nem támaszkodik semmilyen tengelyre, például egy kördiagram, a diagram adatelcímkéi túl közel kerülhetnek a széléhez. Ilyen esetben a címke helyzetét kell módosítani, hogy a vezetéssorok egyértelműen láthatók legyenek.

Ez a PHP kód megmutatja, hogyan állítható be a címke pozíciója egy kördiagramon:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**Hogyan akadályozhatom meg az adatelcímkék átfedését zsúfolt diagramok esetén?**

Használjon automatikus címkeelhelyezést, vezetéssorokat és csökkentett betűméretet; szükség esetén rejtse el bizonyos mezőket (például a kategóriát), vagy csak a szélső/kulcsfontosságú pontokhoz jelenítsen meg címkéket.

**Hogyan tilthatom le a címkéket csak a nullára, negatívra vagy üres értékekre?**

Szűrje le az adatpontokat a címkék engedélyezése előtt, és egy meghatározott szabály alapján tiltsa le a megjelenítést a 0-ás, negatív vagy hiányzó értékeknél.

**Hogyan biztosítható az egységes címkestílus PDF/képek exportálásakor?**

Állítsa be kifeexplicit módon a betűkészleteket (család, méret), és ellenőrizze, hogy a betűtípus elérhető legyen a renderelő oldalon, hogy elkerülje a helyettesítést.