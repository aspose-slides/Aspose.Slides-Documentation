---
title: Přizpůsobení os diagramu v prezentacích pomocí PHP
linktitle: Os diagramu
type: docs
url: /cs/php-java/chart-axis/
keywords:
- os diagramu
- vertikální osa
- horizontální osa
- přizpůsobit osu
- manipulovat osou
- spravovat osu
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
description: "Objevte, jak pomocí Aspose.Slides pro PHP přes Java přizpůsobit osy diagramů v PowerPoint prezentacích pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy diagramu pomocí Aspose.Slides pro PHP přes Java. Pokrývá vypočítané hodnoty os, přepínání řádků a sloupců diagramu, viditelnost os, intervaly popisků kategorií a značek os, datumové kategorie a formátování, otáčení názvu, umístění os, zobrazovací jednotky a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose v diagramech**

Vytvořte [Prezentaci](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) a přidejte plošný diagram s výchozími daty. Zavolejte [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) před načtením vypočítaných hodnot os, aby byl rozvržení diagramu aktuální.

Pro limity os přečtěte [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) a [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/). Pro intervaly značek použijte [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) a [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/). [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) a [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) poskytují časové jednotky, které jsou relevantní pro datumové osy. Příklad uloží tyto hodnoty do lokálních proměnných a uloží diagram.

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

## **Prohození dat mezi osami**

Použijte [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) k výměně rolí sérií a kategorií v datech diagramu. Každá bývalá kategorie se stane sérií a každá bývalá série se stane kategorií. Tím se změní způsob seskupení dat; neprohodí to vodorovnou a svislou osu. Příklad používá [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) k svázání výchozích dat s `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží diagram se čtyřmi sériemi a třemi kategoriemi.

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

## **Obrácení pořadí vykreslování osy**

Použijte [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) k obrácení kategoriální nebo hodnotové osy. Například vodorovný sloupcový diagram může zobrazovat fáze projektu odshora dolů ve stejném pořadí jako list: Plánování, Vývoj, Testování. Obrácení osy mění směr vykreslování; neseřadí ani nepřeskládá data sešitu. Naopak [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) vymění role sérií a kategorií.

Následující příklad vytvoří vodorovný sloupcový diagram se třemi fázemi a jednou sérií. Uloží prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie použije stejnou sadu dat a na každé kopii je obrácena pouze jedna osa.

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

    // Snímek 2: zobrazit první kategorii nahoře.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // Udržet vodorovnou hodnotovou osu ve spodní části.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // Snímek 3: obrátit pouze vodorovnou číselnou škálu.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Obrácení osy může také přesunout kolmou osu na protější stranu grafu. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) určuje, kde druhá osa protíná konfigurovanou osu. V snímku 2 volání s `CrossesType::Maximum` na obrácené kategorické ose zachová vodorovnou hodnotovou osu ve spodní části. Pro konkrétní průsečík použijte [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Při změně směru zkontrolujte nastavení průsečíků, zejména pokud diagram již má vlastní bod průsečíků. Zavolejte `setPlotOrderReversed` s `false` pro obnovení normálního směru vykreslování; nastavení průsečíků jsou oddělená.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný sloupcový diagram s normálním pořadím kategorií a osy hodnot](axis-order-normal.png) | ![Vodorovný sloupcový diagram se zobrazovanými kategoriemi shora dolů](axis-order-categories-reversed.png) | ![Vodorovný sloupcový diagram s obrácenou osou hodnot a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží odspodu nahoru; hodnoty rostou zleva doprava. | Plánování, Vývoj a Testování běží shora dolů. Hodnoty a pořadí řádků sešitu zůstávají nezměněny. | Kategorie si zachovávají normální pořadí; hodnoty rostou zprava doleva. Kategorická osa protíná nulu vpravo. |

## **Zakázání svislé osy pro spojnicové diagramy**

Zavolejte [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) s `false` na svislé ose, aby byla skryta. Příklad vytvoří spojnicový diagram s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Zakázání vodorovné osy pro spojnicové diagramy**

Zavolejte [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) s `false` na vodorovné ose, aby byla skryta. Příklad vytvoří spojnicový diagram s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna kategoriální osy**

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) k výběru datumové nebo textové kategoriální osu. Tento příklad vyžaduje `ExistingChart.pptx`, kde je diagram jako první tvar na prvním snímku a buňky kategorií obsahují číselné datumové hodnoty Excelu. Změní vodorovnou osu na datumovou osu. Volání [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) s `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) s `TimeUnitType::Months` umístí hlavní značky v měsíčních intervalech.

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

## **Řízení intervalů popisků kategoriální osy**

Když má diagram mnoho kategorií, snižte počet viditelných popisků os bez odstranění kategorií nebo datových bodů. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) s `false` a poté předáte požadovaný interval kategorií do [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). Pro textové kategorie v jejich normálním pořadí počítání začíná od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Interval `3` zobrazuje každý třetí popisek a mezi zobrazenými popisky skryje dva popisky. Neodstraňuje to odpovídající sloupce. Automatické rozestupy volí interval na základě dostupného prostoru; nemusí zobrazovat všechny popisky.

Značky os mají samostatné ovládání. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) s `false` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/), abyste nastavili jejich interval. Například `1` ponechá značku na každém intervalu kategorie, zatímco popisky se zobrazí jen každou třetí kategorii. Použijte [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) s viditelným stylem, abyste viděli výsledek. Opětovné volání kteréhokoli nastavení automatického rozestupu s `true` umožní diagramu znovu zvolit tento interval.

Následující samostatný příklad vytvoří 24 kategorií a jednu sérii, poté uloží tři snímky do `CategoryAxisIntervals.pptx`: automatické rozestupy, ruční rozestupy popisků s nezávislými značkami a obnovené automatické rozestupy. Obě kopie zachovají původní data diagramu. Vstupní prezentace není vyžadována. Vodorovný text popisků usnadňuje vidět rozdíl v hustotě.

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

    // Snímek 2: zobrazit každý třetí štítek, ale zachovat značku pro každou kategorii.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // Snímek 3: nechat diagram znovu vybrat oba intervaly.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Automatické rozestupy (snímek 1):** V tomto zobrazení je každý druhý popisek kategorie zobrazen a zalamuje se na dva řádky. Automatický výsledek se může lišit podle velikosti diagramu, fontů a vykreslovacího nástroje.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Manuální rozestupy (snímek 2):** Každý třetí popisek je zobrazen na jednom řádku, zatímco značky zůstávají na každém intervalu kategorie. Všech 24 sloupců, včetně těch bez popisků, zůstává viditelných se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled zobrazený výše.

![Manuální interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Zvolte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou kategoriální osu, například pro osu kategorií sloupcového, spojnicového, plošného nebo pruhového diagramu. V sloupcovém diagramu je to vodorovná osa. Ve vodorovném pruhovém diagramu je osa kategorií svislá, takže tato nastavení aplikujte na osu vrácenou metodou [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). Rozestup značek se také vztahuje na osu sérií v diagramech, které takovou osu mají.

Nepoužívejte rozestupy popisků kategorií k nastavení číselné škály hodnotové osy. Na hodnotové ose [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) určuje rozdíl v hodnotách: například hlavní jednotka `10` vytvoří značky na 0, 10, 20 atd., pokud osa začíná nulou. Interval popisků kategorií `3` počítá pozice kategorií, nezávisle na jejich datových hodnotách. Rozptylové a bublinové diagramy používají hodnotové osy místo textové kategoriální osy. Pro datumovou osu použijte časově založené hlavní jednotky a škály, jak je popsáno v [Change a Category Axis](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty kategoriální osy**

Příklad nahradí výchozí data diagramu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první tabulce (index `0`), spočítaná jako počet dní od 30. prosince 1899. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) s `CategoryAxisType::Date`, zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) s `false` a předávejte `yyyy` do [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/), aby popisky kategorií zobrazovaly čtyřčíslné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otáčení názvu osy diagramu**

Zavolejte [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) s `true` na svislé ose, zadejte text názvu a použijte [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) k otáčení názvu. Úhel se měří ve stupních; tento příklad uloží sloupcový diagram s názvem hodnotové osy otočeným o 90 stupňů.

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

## **Nastavení polohy osy u kategoriální nebo hodnotové osy**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) k řízení, zda hodnotová osa protíná kategoriální osu mezi kategoriemi nebo na značkách kategorií. Toto nastavení platí pro kategoriální osy. Příklad nastaví hodnotu na `true` na vodorovné kategoriální ose sloupcového diagramu a uloží výsledek.

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

## **Nastavení zobrazovací jednotky na hodnotové ose diagramu**

Použijte [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) k škálování popisků na hodnotové ose, aniž byste měnili podkladová data. S [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový diagram a použije jednotku milionů na jeho svislé ose.

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

## **Konfigurace logaritmické hodnotové osy**

Logaritmická hodnotová osa je užitečná, když kladné hodnoty pokrývají několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici jsou menší hodnoty blízko sebe u nuly. Logaritmická stupnice usnadňuje porovnání jejich relativního růstu: stejné vzdálenosti představují stejné poměry místo stejných rozdílů.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) s `true` na hodnotové ose a použijte [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) k výběru základu. Tím se změní způsob, jakým jsou existující hodnoty zobrazeny; nemění to data ani nepřidává logaritmickou čáru trendu. Čára trendu představuje vhodně přizpůsobený vztah v datech a je samostatnou funkcí.

### **Výběr hodnotové osy a základu**

U spojnicového nebo sloupcového diagramu je hodnotová osa vrácena metodou [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). U vodorovného pruhového diagramu je vrácena metodou [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). Rozptylové a bublinové diagramy mají dvě hodnotové osy, takže vyberte vodorovnou osu pro hodnoty X, svislou osu pro hodnoty Y nebo obě. Na kategoriální osu nepoužívejte logaritmické škálování.

Výchozí logaritmický základ je `10`. Pro diagramy PPTX použijte základ od `2` do `1000` včetně; podporovány jsou také desetinné základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny 10, 100, 1 000 a 10 000 rovnoměrně rozloženy.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří spojnicový diagram s pěti počty požadavků na prvním snímku, poté tento snímek duplikuje a na druhém povolí logaritmickou hodnotovou osu se základem 10. Oba snímky zachovají stejná data.

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

    // Nechte první snímek lineární a změňte jen měřítko hodnotové osy v kopii.
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

**Lineární škála (snímek 1):** Rovné vertikální vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje diagramu, což ztěžuje rozlišení menších hodnot.

![Spojnicový diagram v PowerPointu zobrazující pět počtů požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická škála (snímek 2):** Rovné vertikální vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří rovnou rostoucí linii na stupnici se základem 10. Popisky os stále zobrazují původní počty požadavků.

![Stejných pět požadavků v PowerPointu na hodnotové ose logaritmické se základem 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat pouze striktně kladné hodnoty. Před jejím povolením data zkontrolujte. Pokud jsou nulové nebo záporné hodnoty relevantní, zachovejte lineární stupnici nebo je zobrazte odděleně. Pokud je vyloučení těchto hodnot vhodné pro analýzu, vysvětlete vynechání. Nepřepisujte je tiše malými kladnými čísly, protože to mění význam dat. Jakýkoli ručně nastavený minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, kde se jedna osa protíná s druhou (průsečík osy)?**  
Použijte [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) k výběru chování průsečíku. Pro zadání číselné hodnoty průsečíku použijte [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). Tato nastavení vám umožní přesunout průsečík osy na vhodnou základnu.

**Jak mohu umístit popisky značek relativně k ose?**  
Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro řízení samotných značek použijte [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) nebo [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); jsou oddělené od umístění popisků.