---
title: Anpassa diagramaxlar i presentationer med PHP
linktitle: Diagramaxel
type: docs
url: /sv/php-java/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axeltitel
- axelposition
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för PHP via Java för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar diagramaxlar med Aspose.Slides för PHP via Java. Den täcker beräknade axelvärden, byte av diagramrader och -kolumner, axelns synlighet, intervall för kategorimärkning och stapelmärken, datumkategorier och formatering, titelrotation, axelpositionering, visningsenheter och logaritmisk skalning.

## **Hämta maxvärden på den vertikala axeln i diagram**

Skapa en [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) och lägg till ett områdesdiagram med standarddata. Anropa [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) innan du läser beräknade axelvärden så att diagramlayouten är uppdaterad.

Läs [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) och [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) för axelgränserna, samt [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) och [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) för stapelintervallen. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) och [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) ger tidsenhetsskalan, vilket är relevant för datumaxlar. Exemplet lagrar dessa värden i lokala variabler och sparar diagrammet.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Byt data mellan axlar**

Använd [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) för att utbyta rollerna för serier och kategorier i diagramdata. Varje tidigare kategori blir en serie, och varje tidigare serie blir en kategori. Detta ändrar hur data grupperas; den utbyter inte de horisontella och vertikala axlarna. Exemplet använder [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) för att binda standarddata till `Sheet1!A1:D5`, inklusive rubrikraden och kategori‑kolumnen, innan rader och kolumner byts. Det sparar ett diagram med fyra serier och tre kategorier.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Omvänd ritordning för en axel**

Använd [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) för att vända en kategori‑ eller värdeaxel. Till exempel kan ett horisontellt stapeldiagram visa projektfaser från topp till botten i samma ordning som kalkylbladet: Planering, Utveckling, Testning. Att vända en axel ändrar ritningsriktningen; den sorterar eller omarrangerar inte arbetsbokens data. Till jämförelse byter [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) rollerna för serier och kategorier.

Följande exempel skapar ett horisontellt stapeldiagram med tre faser och en serie. Det sparar en presentation med tre bilder: normal ordning, omvända kategorier och omvända värden. Varje kopia använder samma datamängd, och bara en axel är omvänd i varje kopia.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // Bild 2: visa den första kategorin högst upp.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Behåll den horisontella värdeaxeln längst ner.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // Bild 3: vänd endast den horisontella numeriska skalan.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Att vända en axel kan också flytta den vinkelräta axeln till motsatt sida av diagrammet. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) styr var den andra axeln korsar den axel som konfigureras. På bild 2 anropas den med `CrossesType::Maximum` på den omvända kategori­axeln så att den horisontella värdeaxeln behåller sig längst ner. För en specifik korsningspunkt, använd [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Kontrollera korsningsinställningarna när du ändrar riktning, särskilt om diagrammet redan har en anpassad korsningspunkt. Anropa `setPlotOrderReversed` med `false` för att återställa den normala ritningsriktningen; korsningsinställningarna är separata.

| Normal ordning (bild 1) | Omvända kategorier (bild 2) | Omvända värden (bild 3) |
| --- | --- | --- |
| ![Horisontellt stapeldiagram med normal kategori‑ och värdeaxelordning](axis-order-normal.png) | ![Horisontellt stapeldiagram med kategorier visade från topp till botten](axis-order-categories-reversed.png) | ![Horisontellt stapeldiagram med en omvänd värdeaxel och noll på höger sida](axis-order-values-reversed.png) |
| Kategorierna löper från botten till toppen; värdena ökar från vänster till höger. | Planering, Utveckling och Testning löper från topp till botten. Värdena och arbetsbokens radordning är oförändrade. | Kategorierna behåller sin normala ordning; värdena ökar från höger till vänster. Kategori‑axeln korsar vid noll på höger sida. |

## **Inaktivera den vertikala axeln för linjediagram**

Anropa [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) med `false` på den vertikala axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den vertikala axeln dold.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Inaktivera den horisontella axeln för linjediagram**

Anropa [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) med `false` på den horisontella axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den horisontella axeln dold.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ändra en kategori­axel**

Använd [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) för att välja en datum‑ eller textkategori‑axel. Detta exempel kräver `ExistingChart.pptx`, med ett diagram som den första formen på den första bilden och kategori‑celler som innehåller numeriska Excel‑datumvärden. Det ändrar den horisontella axeln till en datumaxel. Anropa [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) med `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) med `1` och [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) med `TimeUnitType::Months` för att placera huvudstaplar med ett‑månadsintervall.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Styr intervall för kategori‑axelns etiketter**

När ett diagram har många kategorier, minska antalet synliga axel­etiketter utan att ta bort kategorier eller datapunkter. Anropa [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) med `false`, och skicka sedan önskat kategoriintervall till [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). För textkategorier i deras normala ordning startar räknandet på den första kategorin:

| Intervall | Etiketter som visas i exemplet |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, … Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, … Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, … Kategori 22 |

Ett intervall på `3` visar var tredje etikett och döljer två etiketter mellan de visade. Det tar inte bort motsvarande kolumner. Automatisk spacing väljer ett intervall baserat på tillgängligt utrymme; det visar inte nödvändigtvis varje etikett.

Stapelmarkeringarna har separata kontroller. Anropa [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) med `false` och använd [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) för att sätta deras intervall. Till exempel behåller `1` en stapelmarkering vid varje kategoriintervall medan etiketter bara visas var tredje kategori. Använd [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) med en synlig stil så att du kan se resultatet. Att igen anropa den automatiska inställaren med `true` låter diagrammet återigen välja intervallet automatiskt.

Följande självständiga exempel skapar 24 kategorier och en serie, och sparar sedan tre bilder i `CategoryAxisIntervals.pptx`: automatisk spacing, manuell etikettspacing med oberoende stapelmarkeringar och återställd automatisk spacing. De två kopiorna behåller originaldata. Ingen inmatningspresentation krävs. Horisontell etiketttext gör skillnaden i densitet tydlig.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // Bild 2: visa var tredje etikett, men behåll en stapelmarkering för varje kategori.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Bild 3: låt diagrammet välja båda intervallen igen.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatisk spacing (bild 1):** I den här återgivningen visas varannan kategori­etikett och de radbryts på två rader. Det automatiska resultatet kan variera med diagramstorlek, typsnitt och renderare.

![Automatisk kategori‑etikettspacing med alla 24 kolumner synliga](category-axis-automatic.png)

**Manuell spacing (bild 2):** Var tredje etikett visas på en rad, medan stapelmarkeringarna kvarstår vid varje kategoriintervall. Alla 24 kolumner, inklusive de utan etiketter, förblir synliga med samma värden. Bild 3 återställer den automatiska presentationen som visas ovan.

![Manuell kategori‑etikettintervall på tre med alla 24 kolumner synliga](category-axis-manual.png)

### **Välj rätt axel och intervall**

Använd detta kategori‑räkningsintervall för en textkategoriekaxel, såsom kategoriekaxeln i ett stapel‑, linje‑, områdes‑ eller stapeldiagram. I ett stapeldiagram är den horisontella axeln kategori‑axeln. I ett horisontellt stapeldiagram är kategori‑axeln vertikal, så tillämpa dessa inställningar på axeln som returneras av [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Stapel­intervall gäller också för en serie‑axel i diagram som har en sådan.

Använd inte kategori­etikettspacing för att sätta den numeriska skalan på en värdeaxel. På en värdeaxel specificerar [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) ett värdesskillnad: t.ex. ger en huvudenhet på `10` staplar vid 0, 10, 20 osv. när axeln startar vid noll. Ett kategori­etikettintervall på `3` räknar däremot kategori‑positioner, oavsett deras datavärden. Spridnings‑ och bubbel‑diagram använder värdeaxlar snarare än en textkategoriekaxel. För en datumaxel, använd tids­baserade huvudenheter och skalor enligt [Ändra en kategori­axel](#ändra-en-kategori‑axel).

## **Ställ in datumformat för kategori‑axelvärden**

Exemplet ersätter standarddiagramdata med fyra årliga värden. Datum lagras som OLE‑Automation‑serienummer i det första kalkylbladet (index `0`), beräknade som antalet dagar sedan 30 december 1899 för dessa datum. Använd [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) med `CategoryAxisType::Date`, anropa [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) med `false` och skicka `yyyy` till [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) så att kategori‑etiketterna visar fyrsiffriga år oberoende av cellformateringen.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ange rotationsvinkel för diagramaxelns titel**

Anropa [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) med `true` på den vertikala axeln, ange titeltext och använd [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) för att rotera titeln. Vinkeln mäts i grader; detta exempel sparar ett stapeldiagram med sin värdeaxeltitel roterad 90 grader.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ställ in axelposition på en kategori‑ eller värdeaxel**

Använd [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) för att styra om värdeaxeln korsar kategori‑axeln mellan kategorier eller vid kategori‑staplar. Denna inställning gäller kategori­axlar. Exemplet sätter den till `true` på den horisontella kategori‑axeln i ett stapeldiagram och sparar resultatet.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ställ in visningsenhet på en diagramvärdeaxel**

Använd [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) för att skala etiketterna på en värdeaxel utan att ändra underliggande data. Med [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) satt till `Millions` visas ett värde på 60 000 000 som 60. Exemplet skapar ett stapeldiagram och tillämpar miljon‑visningsenheten på dess vertikala axel.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Konfigurera en logaritmisk värdeaxel**

En logaritmisk värdeaxel är användbar när positiva värden spänner över flera storleksordningar. Till exempel kan en tjänst ta emot 10, 100, 1 000, 10 000 och 100 000 förfrågningar under fem perioder. På en linjär skala hamnar de mindre värdena nära varandra nära noll. En logaritmisk skala gör deras relativa tillväxt enklare att jämföra: lika avstånd representerar lika förhållanden snarare än lika differenser.

Anropa [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) med `true` på värdeaxeln och använd [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) för att välja bas. Detta ändrar hur de befintliga värdena visas; det ändrar inte datan eller lägger till en logaritmisk trendlinje. En trendlinje representerar ett anpassat förhållande i datan och är en separat funktion.

### **Välj värdeaxel och bas**

För ett linje‑ eller stapeldiagram returneras värdeaxeln av [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). För ett horisontellt stapeldiagram returneras den av [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Spridnings‑ och bubbel‑diagram har två värdeaxlar, så välj den horisontella axeln för X‑värden, den vertikala för Y‑värden, eller båda. Tillämpa inte logaritmisk skalning på en kategori‑axel.

Standardbasen för logaritmisk skala är `10`. För PPTX‑diagram kan du använda en bas från `2` till `1000`, inklusiv; bråkdelar som `2.5` stöds också. Med bas `10` är på varandra följande potenser såsom 10, 100, 1 000 och 10 000 lika avstånd från varandra.

### **Jämför linjär och logaritmisk skalning**

Följande självständiga exempel skapar ett linjediagram med de fem förfrågningsantalena på den första bilden, klonar sedan den bilden och aktiverar en bas‑10 logaritmisk värdeaxel på den andra. Båda bilderna behåller samma data.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Behåll den första bilden linjär och ändra bara kopians värdeaxelskala.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Linjär skala (bild 1):** Lika vertikala avstånd representerar lika skillnader i förfrågningsantal. Det största värdet dominerar diagrammet och gör de mindre värdena svåra att urskilja.

![Linjediagram i PowerPoint som visar fem förfrågningsantal på en linjär värdeaxel](value-axis-linear.png)

**Logaritmisk skala (bild 2):** Lika vertikala avstånd representerar lika förhållanden. Varje period har tio gånger så många förfrågningar som den föregående, så punkterna bildar en rak stigande linje på bas‑10‑skalan. Axel‑etiketterna visar fortfarande de ursprungliga förfrågningsantalena.

![Samma fem förfrågningsantal i PowerPoint på en bas‑10 logaritmisk värdeaxel](value-axis-logarithmic.png)

### **Hantera noll och negativa värden**

En logaritmisk skala kan bara visa strikt positiva värden. Kontrollera data innan du aktiverar den. Om noll eller negativa värden är meningsfulla, behåll en linjär skala eller visa dem separat. Om det är lämpligt att utesluta dessa värden för analysen, förklara uteslutningen. Ersätt dem inte tyst med små positiva tal, då det ändrar datans betydelse. Alla manuellt konfigurerade min‑ eller maxvärden för en logaritmisk axel måste också vara positiva.

## **FAQ**

**Hur anger jag värdet där en axel korsar den andra (axelkorsning)?**

Använd [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) för att välja korsningsbeteende. För att ange ett numeriskt korsningsvärde, använd [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Dessa inställningar låter dig flytta axelkorsningen till en lämplig baslinje.

**Hur kan jag placera stapel­etiketter i förhållande till axeln?**

Anropa [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) med hjälp av [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` eller `None`. För att styra själva stapelmarkeringarna, använd [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) eller [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); dessa är separata från etikettplaceringen.