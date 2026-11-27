---
title: Prezentációs diagramok formázása PHP-ben
linktitle: Diagramformázás
type: docs
weight: 60
url: /hu/php-java/chart-formatting/
keywords:
- diagram formázása
- diagramformázás
- diagram elem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg a diagramformázást az Aspose.Slides PHP-hoz Java használatával, és emelje fel PowerPoint prezentációját egyedi tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagram szegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni diagramokat PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan lehet testre szabni a diagram kulcsfontosságú elemeit, mint például a tengelyek, rácsvonalak, címek, jelmagyarázatok, a rajzterület és a falak kitöltései, hogy javítsuk a diagram adatok megjelenését és olvashatóságát.

Az is bemutatja, hogyan lehet beállítani a betűtípus tulajdonságait a diagram szövegéhez, előre definiált numerikus formátumokat alkalmazni a diagram adatokra, és lekerekített sarkokat engedélyezni a diagram területén. Ezek a példák együtt mutatják, hogyan lehet irányítani a diagramok vizuális stílusát és adatmegjelenítését egy prezentációban.

A növekvő és csökkenő intervallumok külön kitöltései és körvonalai tekintetében lásd a [részvénydiagram példát](/slides/hu/php-java/create-chart/#create-stock-charts).

## **Diagram Elemeinek Formázása**

Használja a [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) elemet a diagram címek, tengelyek, rácsvonalak, jelmagyarázatok és a rajzterület formázásához. Ez a példa egy jelölőkkel ellátott vonaldiagramot hoz létre alapértelmezett adatokkal, majd külön szöveg- és vonalstílusokat alkalmaz az értéktengelyen és a kategóriatengelyen. A betűméreteket és a vonalszélességeket pontban adjuk meg; a kategóriacímkék 45 fokban vannak elforgatva.

Az értéktengely a [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) metódust használja a forráscelláktól függetlenül. Skálája -2‑től 15‑ig terjed, a fő intervallumok 2‑esek, a kisebb intervallumok 0,5‑ösök. A példa a százalékformázást is összekapcsolja a [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit) ezresek beállításával, ezért ezeket a beállításokat a saját adatai jelentéséhez és nagyságához igazítsa. A jelmagyarázat a rajzterület kívül marad, mivel a [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) `false` értékkel kerül meghívásra. A háttérfal és a padló kitöltései a [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) és a [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor) segítségével állíthatók be, de ezek a felületek csak 3D diagramokban láthatók.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LineDashStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\TickLabelPositionType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle::DashDot);

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);

    $chart->getAxes()->getVerticalAxis()->setMaxValue(15);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

    $valueAxisText = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $valueAxisText->setFontBold(NullableBool::True);
    $valueAxisText->setFontHeight(16);
    $valueAxisText->setFontItalic(NullableBool::True);
    $valueAxisText->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkGreen);
    $valueAxisText->setLatinFont(new FontData("Times New Roman"));

    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valueAxisTitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valueAxisTitle->setText("Primary Axis");
    $valueAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valueAxisTitle->getPortionFormat()->setFontHeight(20);
    $valueAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valueAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 128, 0));
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $categoryAxisText = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $categoryAxisText->setFontBold(NullableBool::True);
    $categoryAxisText->setFontHeight(16);
    $categoryAxisText->setFontItalic(NullableBool::True);
    $categoryAxisText->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisText->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $categoryAxisText->setLatinFont(new FontData("Arial"));

    $chart->getAxes()->getHorizontalAxis()->setTitle(true);
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

    $categoryAxisTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $categoryAxisTitle->setText("Sample Category");
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $categoryAxisTitle->getPortionFormat()->setFontHeight(20);
    $categoryAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $categoryAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

    $legendText = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $legendText->setFontBold(NullableBool::True);
    $legendText->setFontHeight(16);
    $legendText->setFontItalic(NullableBool::True);
    $legendText->getFillFormat()->setFillType(FillType::Solid);
    $legendText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkRed);

    $chart->getLegend()->setOverlay(false);

    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setPresetColor(PresetColor::LightCyan);

    $presentation->save("FormattedChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Diagramon Belüli Betűtípus Tulajdonságok Beállítása**

Állítsa be a diagram szövegének alapértelmezett betűméretét a [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat) segítségével. A példa egy csoportosított oszlopdiagramot hoz létre 20 pontos betűmérettel, és az első sorozatra a [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) használatával engedélyezi az értékcímkéket. Az egyedi betűtípusbeállításokkal rendelkező szövegelemek felülbírálhatják a diagram alapértelmezett beállításait.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Szövegkeret Formázásának Újrahasználása a Diagram Jelmagyarázatban**

A jelmagyarázatot a diacímhez igazítva, állítsa be a cím betűtípusát az első bekezdésen a [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) segítségével. Hívja meg a [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) metódust a jelmagyarázat [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat) által visszaadott formátumon. Ez a szövegkeret beállításait, az első bekezdés formázását és annak alapértelmezett betűtípus tulajdonságait másolja. Az egyes részekre vagy későbbi bekezdésekre közvetlenül alkalmazott formázás a forrásra korlátozódik.

A példa egy félkövér, 26 pontos Calibri címet használ sötétkék színben sablonként. A jelmagyarázat stílusozása után a [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo) metódust hívja, hogy ugyanazt a formázást alkalmazza egy külön feliratra.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\StyleType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $heading = $shapes->addAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
    $sourceTextFrame = $heading->addTextFrame("Quarterly sales");
    $font = $sourceTextFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $font->setLatinFont(new FontData("Calibri"));
    $font->setFontHeight(26);
    $font->setFontBold(NullableBool::True);
    $font->getFillFormat()->setFillType(FillType::Solid);
    $font->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 32, 64, 96));

    $chart = $shapes->addChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
    $chart->setStyle(StyleType::Style3);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->getCell(0, 0, 1)->setValue("Retail");
    $workbook->getCell(0, 0, 2)->setValue("Online");
    $workbook->getCell(0, 0, 3)->setValue("Wholesale");
    for ($quarter = 1; $quarter <= 4; $quarter++) {
        $workbook->getCell(0, $quarter, 0)->setValue("Q" . $quarter);
    }

    $chart->setLegend(true);
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $legendFormat = $chart->getLegend()->getTextFormat();
    $legendFormat->copyFrom($sourceTextFrame);

    $caption = $shapes->addAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
    $captionTextFrame = $caption->addTextFrame("Sales in millions of dollars");
    $legendFormat->copyTo($captionTextFrame);

    $presentation->save("legend-formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A mentett prezentációban a jelmagyarázat és a felirat méretben, vastagságban és színben megegyezik a címmel. A jelmagyarázat továbbra is a sorozatneveket jeleníti meg, a felirat pedig megőrzi saját szövegét. Ha a felirat egy részének már van kifejezett betűmérete, az felülbírálja a másolt bekezdés alapértelmezett méretét.

| Másolás előtt | Másolás után |
| --- | --- |
| ![Negyedéves értékesítési diagram szabályos fekete jelmagyarázat címkékkel és fekete felirattal](legend-formatting-before.png) | ![Ugyanez a diagram nagyobb, félkövér sötétkék jelmagyarázat címkékkel és illeszkedő felirattal](legend-formatting.png) |

## **Numerikus Formátum Beállítása**

Használja a [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat) metódust, hogy beépített számformátumot alkalmazzon a diagram munkafüzet celláira. Ez a példa egy alapértelmezett, cella‑alapú adatokkal rendelkező csoportosított oszlopdiagramot hoz létre, és a 10‑es formátumindexet (`0.00%`) alkalmazza minden sorozat értékcellájára. Ez megváltoztatja, hogyan jelennek meg az értékek a munkafüzetben a mögöttes számok módosítása nélkül; például a 0,25 25,00%-ként jelenik meg. A tengely és az adatcímke formátumok külön is konfigurálhatók.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries();

    for ($i = 0; $i < java_values($series->size()); $i++) {
        $chartSeries = $series->get_Item($i);
        $dataPoints = $chartSeries->getDataPoints();
        for ($j = 0; $j < java_values($dataPoints->size()); $j++) {
            $dataPoint = $dataPoints->get_Item($j);
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az alábbi táblázat felsorolja a beépített számformátum indexeket a megfelelő Excel formátumokkal az angol (Egyesült Államok) nyelvi beállításhoz. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és nyelvi beállításonként eltérhet, különösen a pénznemek és dátumok esetében. Néhány Excel formátum eltér az OOXML szabvány alapértelmezettjeitől, ahogyan azt a [Microsoft számformátum implementációs jegyzetében](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) ismertetik.

| Index | Formátum |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **A Diagram Területének Lekerekített Szélei**

Hívja a [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) metódust `true` értékkel a diagram területének sarkainak lekerekítéséhez. A példa egy csoportosított oszlopdiagramot hoz létre, és a [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) segítségével szilárd szürke színt és egyvonali stílust ad a körvonalnak, mielőtt mentené a prezentációt.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chart->getLineFormat()->setStyle(LineStyle::Single);
    $chart->setRoundedCorners(true);

    $presentation->save("out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Meglévő Diagram Megjegyzések Szerkesztése**

Egy diagram tartalmazhat egyedi alakzatokat, például egy szöveges megjegyzést, amely a jelentés állapotát magyarázza. Ezeket az alakzatokat a [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes) segítségével érheti el. A [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) által visszaadott gyűjtemény a diagramhoz tartozó alakzatokat tartalmazza, de ezek a felületek csak 3D diagramokban láthatók.

A diagram felett elhelyezett egyszerű szövegdoboz a diára tartozik, még ha úgy is néz ki, mintha a diagram része lenne. A [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) bejárásával megtalálja a diagramot és a szokásos diaelemeket, de nem sorolja fel a diagramon belüli egyedi alakzatokat. A diagramcímek és adatcímkék különálló diagram elemek, nem egyedi megjegyzések ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx) fájlt, és helyezze az alkalmazás munkakönyvtárába. Az első diája egy diagramot tartalmaz, amely egy csoportosítatlan megjegyzést ("Preliminary results"), egy diagramhoz tartozó vonalat és egy egyszerű diára helyezett szövegdobozt ("Slide overlay") tartalmaz. A példa megtalálja az első diagramot azon a dián, és a jelentés közzétételre kész állapotában a megjegyzést "Final results"-re módosítja. Ellenőrzi, hogy a gyűjtemény üres‑e, és csak egy [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) elemet szerkeszt, amelynek a [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) nem null szövegkerete és a várt szövege van.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-annotations.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chartType = new JavaClass("com.aspose.slides.IChart");
    $autoShapeType = new JavaClass("com.aspose.slides.IAutoShape");
    $chart = null;
    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartType)) {
            $chart = $shape;
            break;
        }
    }

    if ($chart === null || java_values($chart->getUserShapes()->getShapes()->size()) == 0) {
        echo "No chart or chart-owned shapes found." . PHP_EOL;
        return;
    }

    $updated = false;
    $userShapes = $chart->getUserShapes()->getShapes();
    for ($i = 0; $i < java_values($userShapes->size()); $i++) {
        $shape = $userShapes->get_Item($i);
        if (java_instanceof($shape, $autoShapeType)) {
            $annotation = $shape;
            if (!java_is_null($annotation->getTextFrame()) && java_values($annotation->getTextFrame()->getText()) === "Preliminary results") {
                $annotation->getTextFrame()->setText("Final results");
                $updated = true;
                break;
            }
        }
    }

    if ($updated) {
        $presentation->save("chart-annotations-updated.pptx", SaveFormat::Pptx);
    } else {
        echo "No matching text annotation found." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

A vonal és a dia szövegdoboz változatlan marad. Az alábbi képek mutatják a bemeneti és a mentett, újra megnyitott eredményt:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Diagram megjegyzés, amely a “Preliminary results” szöveget tartalmazza](chart-annotations-before.png) | ![Diagram megjegyzés, amely a “Final results” szöveget tartalmazza](chart-annotations-after.png) |

{{% alert color="info" title="Megjegyzés" %}}
Az a példa csak a legfelső szintű diagramhoz tartozó alakzatokat vizsgálja. Ha egy megjegyzés egy [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) belsejében van, akkor ellenőrizze az adott csoport [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) gyűjteményét is. Ismételje meg rekurzívan a beágyazott csoportoknál, ugyanazokat a szövegellenőrzéseket alkalmazva a gyermekalakzatokra. Egy csoport önmagában egy tároló; ne tekintse szövegdoboznak.
{{% /alert %}}

## **GYIK**

**Beállíthatok félig átlátszó kitöltéseket oszlopoknak/területeknek, miközben a szegély átlátszatlan marad?**  
Igen. A kitöltés átlátszósága és a körvonal külön konfigurálható. Ez a sűrű vizualizációkban a rács és az adatok olvashatóságának javításában hasznos.

**Hogyan kezeljem az adatcímkéket, ha átfedik egymást?**  
Csökkentse a betűméretet, tiltsa le a nem lényeges címke komponenseket (például a kategóriákat), állítsa be a címke pozícióját, szükség esetén csak a kiválasztott pontokhoz jelenítsen meg címkéket, vagy változtassa a formátumot "érték + jelmagyarázat"-ra.

**Alkalmazhatok fokozatos vagy mintázott kitöltéseket sorozatokra?**  
Igen. A sorozatok támogatják az egyszínű, fokozatos és mintázott kitöltéseket. Gyakorlati tanács: a fokozatokat mértékkel használja, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.