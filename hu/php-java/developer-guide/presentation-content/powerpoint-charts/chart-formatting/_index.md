---
title: Prezentációs diagramok formázása PHP-ben
linktitle: Diagram formázása
type: docs
weight: 60
url: /hu/php-java/chart-formatting/
keywords:
- diagram formázás
- diagram formázása
- diagram elem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- körített szegély
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for PHP via Java segítségével, és emelje ki PowerPoint prezentációját professzionális, szemrevaló stílussal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók diagramok PowerPoint előadásokban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram fő elemei, például tengelyek, rácsvonalak, címek, jelmagyarázatok, a diagramterület és a falak kitöltései a diagram adatok megjelenésének és olvashatóságának javítása érdekében.

Emellett bemutatja, hogyan állíthatók be a betűtípus tulajdonságai a diagram szövegeihez, hogyan alkalmazhatók előre definiált és egyéni számformátumok a diagram adatokra, valamint hogyan engedélyezhetők a körített sarkok a diagram területén. Ezek a példák együtt mutatják, hogyan lehet irányítani a diagramok vizuális stílusát és az adatmegjelenítést egy előadásban.

## **Diagramelemek formázása**
Aspose.Slides for PHP via Java lehetővé teszi a fejlesztők számára, hogy saját diagramokat adjanak a diákhoz a semmiből. Ez a cikk bemutatja, hogyan formázhatók a különböző diagramelemek, többek között a diagram kategória‑ és értéktengelye.

Aspose.Slides for PHP via Java egyszerű API‑t biztosít a különböző diagramelemek kezeléséhez és egyéni értékekkel történő formázásukhoz:

1. Hozzon létre egy példányt a [**Presentation**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg egy dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típus valamelyikével (ebben a példában a ChartType::LineWithMarkers típust használjuk).
1. A diagram **Value Axis**‑éhez férjen hozzá, és állítsa be a következő tulajdonságokat:
   1. Az értéktengely fő rácsvonalainak **Line format** beállítása
   1. Az értéktengely segéd rácsvonalainak **Line format** beállítása
   1. Az értéktengely **Number Format**‑jának beállítása
   1. Az értéktengely **Min, Max, Major and Minor units**‑ának beállítása
   1. Az értéktengely adatainak **Text Properties**‑ának beállítása
   1. Az értéktengely **Title**‑jának beállítása
   1. Az értéktengely **Line Format**‑jának beállítása
1. A diagram **Category Axis**‑éhez férjen hozzá, és állítsa be a következő tulajdonságokat:
   1. A kategória‑tengely fő rácsvonalainak **Line format** beállítása
   1. A kategória‑tengely segéd rácsvonalainak **Line format** beállítása
   1. A kategória‑tengely adatainak **Text Properties**‑ának beállítása
   1. A kategória‑tengely **Title**‑jának beállítása
   1. A kategória‑tengely **Label Positioning**‑jának beállítása
   1. A kategória‑tengely címkéinek **Rotation Angle**‑jának beállítása
1. A diagram **Legend**‑jéhez férjen hozzá, és állítsa be a **Text Properties**‑t
1. Állítsa be a diagram jelmagyarázatát úgy, hogy ne fedje egymást a diagram
1. A diagram **Secondary Value Axis**‑éhez férjen hozzá, és állítsa be a következő tulajdonságokat:
   1. A Secondary **Value Axis** engedélyezése
   1. A Secondary Value Axis **Line Format**‑jának beállítása
   1. A Secondary Value Axis **Number Format**‑jának beállítása
   1. A Secondary Value Axis **Min, Max, Major and Minor units**‑ának beállítása
1. Most ábrázolja az első diagram sorozatot a Secondary Value Axis‑on
1. Állítsa be a diagram hátfal kitöltőszínét
1. Állítsa be a diagram diagramterület (plot area) kitöltőszínét
1. Írja a módosított előadást egy PPTX fájlba

```php
  # Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    # Az első dia elérése
    $slide = $pres->getSlides()->get_Item(0);
    # Minta diagram hozzáadása
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Diagram cím beállítása
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Fő rácsvonalak formátumának beállítása az értéktengelyhez
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Segéd rácsvonalak formátumának beállítása az értéktengelyhez
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Értéktengely számformátumának beállítása
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Diagram maximum és minimum értékeinek beállítása
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Értéktengely szövegtulajdonságainak beállítása
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Értéktengely címének beállítása
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Fő rácsvonalak formátumának beállítása a kategória tengelyhez
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Segéd rácsvonalak formátumának beállítása a kategória tengelyhez
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Kategória tengely szövegtulajdonságainak beállítása
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Kategória cím beállítása
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Kategória tengely címke helyzetének beállítása
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Kategória tengely címke forgatási szögének beállítása
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Jelmagyarázat szövegtulajdonságainak beállítása
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Ábrázolja a diagram jelmagyarázatát anélkül, hogy átfedné a diagramot
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Másodlagos értéktengely beállítása
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Másodlagos értéktengely számformátumának beállítása
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Diagram maximum és minimum értékeinek beállítása
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Diagram hátfal színének beállítása
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Diagram ábraterület (plot area) színének beállítása
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Prezentáció mentése
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Betűtípus tulajdonságainak beállítása diagramhoz**
Aspose.Slides for PHP via Java támogatja a diagram betűtípus‑tulajdonságainak beállítását. Kövesse az alábbi lépéseket a betűtípus beállításához a diagramon.

- Példányosítson egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályobjektumot.
- Adjon hozzá egy diagramot a diára.
- Állítsa be a betűmagasságot.
- Mentse a módosított előadást.

Az alábbi minta példa ez.

```php
  # Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Számformátum beállítása**
Aspose.Slides for PHP via Java egyszerű API‑t biztosít a diagramadat-formátum kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályból.
1. Szerezze meg egy dia referenciáját az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, a kívánt típus valamelyikével (ebben a példában a **ChartType::ClusteredColumn**‑t használjuk).
1. Állítsa be az előre definiált számformátumot a lehetséges előre definiált értékek közül.
1. Járja be a diagram adatcelláit minden diagram sorozatban, és állítsa be a diagram adat számformátumát.
1. Mentse az előadást.
1. Állítsa be az egyéni számformátumot.
1. Járja be a diagram adatcelláit minden diagram sorozatban, és állítson be különböző diagram adat számformátumot.
1. Mentse az előadást.

```php
  # Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    # Az első prezentációs dia elérése
    $slide = $pres->getSlides()->get_Item(0);
    # Alapértelmezett csoportosított oszlop diagram hozzáadása
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # A diagram sorozatgyűjteményének elérése
    $series = $chart->getChartData()->getSeries();
    # Minden diagram sorozaton való iterálás
    foreach($series as $ser) {
      # Sorozat minden adatcellájának bejárása
      foreach($ser->getDataPoints() as $cell) {
        # Számformátum beállítása
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # Prezentáció mentése
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Az alábbiakban a lehetséges előre definiált számformátumértékek, azok indexe és használható formátumaik szerepelnek:

|**0**|Általános|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Körített szegélyek beállítása a diagramterületen**
Aspose.Slides for PHP via Java támogatja a diagram terület beállítását. A [**hasRoundedCorners**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/hasroundedcorners/) és a [**setRoundedCorners**](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chart/setroundedcorners/) metódusok bekerültek a [Chart](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Chart) osztályba.

1. Példányosítson egy [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) osztályobjektumot.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a diagram kitöltés típusát és színét.
1. Állítsa a round corner tulajdonságot True értékre.
1. Mentse a módosított előadást.

Az alábbi minta példa ez.

```php
  # Presentation osztály példányosítása
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Beállíthatok félig átlátszó kitöltést oszlopoknak/területeknek, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációk esetén.

**Hogyan kezelhetem a adatcímkéket, amikor átfednek?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke eltolását/pozícióját, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy változtassa meg a formátumot „value + legend” formára.

**Alkalmazhatok színátmenet vagy minta kitöltéseket sorozatokra?**

Igen. Általában elérhetők a szilárd, valamint a színátmenetes/mintás kitöltések. Gyakorlatban használja a színátmeneteket mértékkel, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rácshoz és a szöveghez.