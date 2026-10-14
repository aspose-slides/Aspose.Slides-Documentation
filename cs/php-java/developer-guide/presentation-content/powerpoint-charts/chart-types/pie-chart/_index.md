---
title: Přizpůsobení koláčových grafů v prezentacích pomocí PHP
linktitle: Koláčový graf
type: docs
url: /cs/php-java/pie-chart/
keywords:
- koláčový graf
- spravovat graf
- přizpůsobit graf
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva výseče
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte a přizpůsobte koláčové grafy v PHP pomocí Aspose.Slides. Nakonfigurujte sekundární vykreslení, zobrazte popisky dat a aplikujte automatické barvy výsečí v PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nakonfigurovat možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů pro standardní koláčový graf.

Příklady se zaměřují na úlohy přizpůsobení grafu, jako je přidání grafu do snímku, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides pro PHP prostřednictvím Javy podporuje možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie. Tyto možnosti řídí velikost sekundárního vykreslení a způsob, jakým jsou datové body rozděleny mezi oba vykreslení.

Následující příklad vytvoří graf Pie of Pie v nové prezentaci a zobrazí hodnoty datových bodů jako popisky. Metoda [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) nastaví velikost sekundárního vykreslení na 149% hlavního vykreslení. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) vybírá rozdělení založené na procentech a [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) nastavuje prahovou hodnotu na 53%.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // Zobrazit hodnoty a nakonfigurovat sekundární vykreslení.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Vyberte kategorie pro sekundární vykreslení**

Použijte vlastní rozdělení, pokud chcete seskupit konkrétní kategorie v sekundárním vykreslení bez ohledu na jejich procentuální hodnoty. Například prodejní zpráva může zobrazit Online a Events společně, aby si čtenáři mohli porovnat tyto dva kanály, i když představují 35% a 10% celkových prodejů.

Zavolejte [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) s [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) a vyberte body pomocí [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Metoda [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) kolekce přijímá nulový index v řadě; použijte [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) k přidání objektu datového bodu. V tomto příkladu index 1 vybírá Online a bod v indexu 3 vybírá Events. Partners je také dočasně přidán, poté vyloučen pomocí [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // Nahraďte výchozí data prodeji podle kanálu.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // Vyberte Online podle jeho nulového indexu a Events podle objektu datového bodu.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // Vyloučte Partners ze výběru, aniž byste smazali jeho zdrojová data.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) a Events (10) se zobrazují jako samostatné výseče v sekundárním vykreslení. V primárním vykreslení jsou reprezentovány jednou spojovanou výsečí s hodnotou 45, spolu s Retail (40) a Partners (15). Odstranění Partners ze vlastní volby jej ponechá v primárním vykreslení; neodstraní kategorii ani její hodnotu ze zdrojových dat grafu.

Následující obrázek ukazuje uloženou prezentaci v PowerPointu:

![Graf Pie of Pie s Online a Events v sekundárním vykreslení a jejich spojenou hodnotou 45 v primárním vykreslení](pie_of_pie_custom.png)

## **Nastavení automatických barev výsečí koláčového grafu**

Aspose.Slides pro PHP prostřednictvím Javy může automaticky přiřadit různé barvy výsečím koláčového grafu. Následující příklad vytvoří koláčový graf se středovým názvem a nahradí výchozí data třemi čtvrtletními kategoriemi a jejich hodnotami. Metoda [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) zobrazí hodnoty 20, 50 a 30 jako popisky, zatímco [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) umožní odlišnou barvu pro každou výseč.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // Přidejte středový název grafu.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // Nahraďte výchozí data pomocí prvního listu.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // Zobrazte hodnoty a přiřaďte výsečím různé barvy.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Jsou variace Pie of Pie a Bar of Pie podporovány?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) sekundární vykreslení pro koláčové grafy, včetně typů Pie of Pie a Bar of Pie.

**Mohu exportovat jen graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (například PNG) bez exportu celé prezentace.