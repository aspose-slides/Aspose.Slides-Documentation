---
title: Správa datových sérií grafu v prezentacích v PHP
linktitle: Datové série
type: docs
url: /cs/php-java/chart-series/
keywords:
- série grafu
- překrytí sérií
- barva série
- název série
- datový bod
- buňka sešitu
- mezera mezi sériemi
- záporná hodnota
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí PHP."
---
## **Přehled**

Graf může ukládat své vykreslené hodnoty buď v buňkách sešitu, nebo přímo jako číselné literály. [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) představuje jednu sadu souvisejících hodnot a každý [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) představuje bod v této sérii. Objekt [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) poskytuje popisky nebo hodnoty seskupení sdílené sériemi. V grafech vytvořených s výchozími daty se názvy sérií, kategorie a hodnoty bodů používají z objektů [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) v sešitu grafu.

Pro typický sloupcový graf výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbylé buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) jsou nulové‑základní. Toto rozvržení je užitečné, když vytváříte graf s výchozími daty, ale nepředpokládejte, že každému existujícímu grafu odpovídá. Pro načtenou prezentaci zkontrolujte buňky odkazované sériemi, kategoriemi a datovými body před změnou hodnot v sešitu.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni série, například [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/), poskytují výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datových bodů, například [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/), přepisují vzhled série pro jeden bod.
- Skupinová nastavení se vztahují na kompatibilní série, které patří do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/). Přístup ke skupině získáte pomocí [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/), když potřebujete nastavit možnosti jako překrytí nebo šířka mezery.

Když není nastaven žádný explicitní výplňový styl pro bod nebo sérii, určuje automatický vzhled styl a motiv grafu. Když jsou k dispozici jak formátování série, tak bodu, má přednost formátování bodu.

![graf-serie-powerpoint](chart-series-powerpoint.png)

## **Nastavení hodnot série pomocí číselných literálů**

Používejte číselné literály, pokud hodnoty sérií pocházejí z aplikace nebo výpočtů a nevyžadují odkazy na buňky listu. Zavolejte [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) s [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) před přiřazením výsledku [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) každého bodu pomocí [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/).

Nastavení kolekce řídí typ zdroje všech hodnot bodů v dané sérii. Metoda [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) každého bodu vrací vybraný typ; změňte jej prostřednictvím nastavení kolekce. S `Worksheet` použijte [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) pro přístup k odkazované buňce. S `DoubleLiterals` použijte [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) nebo `setAsLiteralDouble` pro přímé čtení či zápis čísla.

Následující příklad vytvoří sloupcový graf s výchozími sériemi a kategoriemi a poté přiřadí vypočtené hodnoty 10, 20 atd. k existujícím bodům první série. Uloží prezentaci, otevře ji znovu a vypíše uložené hodnoty.

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

Typ zdroje hodnoty bodu je oddělen od [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), který identifikuje vnitřní nebo externí konfiguraci sešitu grafu. Použití číselných literálů samo o sobě neodstraňuje vložený sešit. V tomto příkladu sešit zůstává dostupný pro popisky kategorií, názvy sérií a další série. Viz [Chart Workbook](/slides/cs/php-java/chart-workbook/) pro správu sešitu.

Pro rozptylové a bublinové grafy použijte [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) k výběru zdrojů pro [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) a [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/). Bublinové grafy také používají [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) pro [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/). Nastavte každý relevantní zdroj na `DoubleLiterals` před přiřazením čísel prostřednictvím metody `setAsLiteralDouble`.

## **Nastavení překrytí sérií grafu**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) udává, jak moc se překrývají pruhy nebo sloupce ve 2D grafu, v rozmezí od -100 do 100 procent. Jedná se o pouze‑čtení projekci nastavení na nadřazenou skupinu sérií. Pro aktualizaci všech kompatibilních sérií ve skupině použijte [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/). Tato možnost platí pro typy grafů zobrazující seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

Následující příklad nastaví překrytí pro skupinu, která obsahuje první sérii:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Nový graf obsahuje ukázkové série, kategorie a hodnoty.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Výsledek:

![Překrytí sérií](series_overlap.png)

## **Změna barvy výplně série**

Použijte [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) k nastavení výchozí výplně celé série. Pokud má bod explicitně nastavenou výplň, jeho nastavení [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) přepíše výplň série pro tento bod.

Následující příklad použije pevnou modrou výplň pro první sérii:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Výsledek:

![Barva série](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu dat grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Názvy proměnných v následujícím příkladu tuto strukturu explicitně ukazují:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Můžete také aktualizovat buňku již odkazovanou metodou [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Výsledek:

![Název série](series_name.png)

### **Vytvoření série s názvem z více buněk**

Složený název série je užitečný, když je název produktu a období reportování uloženy v samostatných buňkách sešitu. Například můžete zkombinovat `Product A` v B1 a `2026` v C1 do jediného názvu série a přitom udržet oba části propojené se svými zdrojovými buňkami.

Použijte [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) k získání rozsahu názvu a poté předávejte tuto kolekci metodě [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/). Argument `skipHiddenCells` určuje, zda se zahrnou skryté buňky: `true` je vyloučí, `false` zahrne. Tento příklad používá `false` k zahrnutí všech buněk v rozsahu názvu.

Následující příklad vytvoří prezentaci s jednou sérií a dvěma datovými body. Buňky B1:C1 obsahují pouze název série; A2:A3 poskytují popisky kategorií a B2:B3 číselné hodnoty.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // Tyto dvě buňky poskytují název série.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // Samostatné buňky poskytují kategorie a číselné datové body.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledný název série je `Product A 2026` s mezerou mezi dvěma hodnotami buněk. Legenda zobrazuje tuto kombinaci jako jeden záznam pro oba sloupce. Obrázek níže ukazuje výsledek:

![Sloupcový graf s hodnotami North a South a složeným názvem série Product A 2026 v legendě](composite_series_name.png)

## **Získání automatické barvy výplně série**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) vrací barvu vypočtenou z indexu série a stylu grafu. To je barva použitá, když výplň série není explicitně definována. Volání metody pouze načte vypočtenou barvu; neprovádí žádnou novou výplň.

Následující příklad vytiskne automatickou barvu každé výchozí série:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Výstup příkladu pro výchozí styl grafu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Exact colors depend on the chart style and theme.

## **Nastavení invertované barvy výplně pro sérii grafu**

Pro barové, sloupcové a bublinové série může [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň série na pevnou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Záporná čísla v sešitu zůstávají beze změny; mění se jen jejich zobrazovaná barva.

Následující příklad nahradí výchozí data grafu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 popisky kategorií a sloupec 1 hodnoty:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Výsledek:

![Invertovaná pevná výplň](inverted_solid_fill_color.png)

Inverzi můžete povolit jen pro jeden bod pomocí [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). V následujícím příkladu je inverze zakázána pro sérii a povolena jen pro vybraný bod. Bod také získá zápornou hodnotu, aby byl efekt viditelný:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Vymazání konkrétní hodnoty datového bodu**

Chcete‑li prázdný bod, aniž byste odstraňovali ostatní body, nastavte jeho buňku v sešitu na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/). Datový bod zůstane na stejné pozici kategorie, ale graf bude jeho hodnotu považovat za prázdnou podle nastavení zobrazení prázdných hodnot.

Následující příklad vymaže pouze druhý bod první série:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Rozptylové grafy používají samostatné buňky X a Y a bublinové grafy ještě buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nevolajte [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) když chcete zachovat ostatní body, protože tato metoda odstraní všechny body ze sbírky.

## **Řízení zobrazování prázdných buněk**

Skryté buňky obsahující hodnoty jsou odlišné od prázdných buněk. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka s `0` představuje známou číselnou hodnotu. Zavolejte [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) s `null`, aby buňka byla prázdná. Číselná nula zůstane nulou bez ohledu na nastavení prázdné buňky.

Použijte [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) k volbě, jak má graf zobrazovat prázdné buňky. Toto nastavení platí pro celý graf. Mění způsob, jakým jsou mezery vykreslovány, aniž by prázdná buňka byla vyplněna nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný graf ve všech režimech. Nepotřebuje vstupní soubor. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // Nechte den 3. den skutečně prázdný, přičemž zachováte jeho kategorii a datový bod.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Každý výstupní soubor ukládá režim nastavený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pokud chcete uložit jen jeden soubor, nastavte požadovaný režim a prezentaci uložte jednou místo iterování přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Čárové grafy se stejnými daty: Gap přeruší čáru v den 3, Zero spustí čáru na nulu a Span spojí den 2 s dnem 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadno porovnat všechny tři režimy. Pruhové a sloupcové grafy nemají čáru, která by spojovala chybějící kategorii, takže `Span` nemůže vytvořit spojovací úsek, jak je znázorněno výše; chybějící sloupec a sloupec s nulovou výškou mohou vypadat podobně. Podobně u rozptylového grafu jen s značkami není žádná spojovací čára. Neočekávejte tři odlišné výsledky u každého typu grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními shluky pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Zavolejte [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi shluky; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží pouze finální prezentaci:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Výsledek:

![Šířka mezery](gap_width.png)

## **Často kladené otázky**

**Které typy grafů podporují datové série?**

Všechny typy grafů zastoupené výčtem [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) používají data grafu, ale jejich série nemají stejnou strukturu hodnot ani nastavení. Například kategoriové grafy používají kategorie a hodnoty, rozptylové grafy X a Y hodnoty a bublinové grafy přidávají velikosti bublin. Použijte metodu tvorby datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery platí jen pro kompatibilní skupiny pruhů nebo sloupců.

**Co je skupina sérií grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení úrovně skupiny. Kombinovaný graf může mít více než jednu skupinu, takže změna skupiny dosažená přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) vytvoří ukázkové série, kategorie a hodnoty. Tyto buňky můžete upravit nebo před přidáním úplně vlastního datového souboru vymazat jak kolekce sérií, tak kolekce kategorií. Přetížení může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou buňku hodnoty na `null`, aby bod zachoval svou pozici v kategorii jako prázdný. Používejte [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) jen v případě, že chcete odstranit všechny body z dané série. Pokud odstraňujete také kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané ke kolekci kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a hodnotě nastavené pomocí [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/). Podporované grafy mohou zobrazovat prázdné buňky jako mezery, nuly nebo spojením sousedních bodů. Zvolte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz [Řízení zobrazování prázdných buněk](#control-the-display-of-empty-cells) pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií zavolejte [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) a nastavte barvu získanou z [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). Chování můžete přepsat pro jednotlivý bod pomocí [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/). Tyto metody ovlivňují formátování, ne uložené číselné hodnoty.

**Které formátování má přednost, když jsou formátovány jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát série nebo, pokud formát série není definován, automatický styl a motiv grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozložení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu sérií, které může graf obsahovat?**

Aspose.Slides neukládá samostatný pevný limit počtu sérií. V praxi omezují souborové limity prezentace, dostupná paměť, doba vykreslování a čitelnost grafu.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Zavolejte [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) na příslušné nadřazené skupině sérií. Zvýšte hodnotu pro rozšíření prostoru mezi shluky nebo ji snižte pro jejich přiblížení.