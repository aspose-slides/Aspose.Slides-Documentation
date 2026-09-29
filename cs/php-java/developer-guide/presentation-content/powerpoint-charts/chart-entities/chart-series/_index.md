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
- mezera série
- záporná hodnota
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích s PHP."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu s daty grafu. [ChartSeries](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/) představuje sadu souvisejících hodnot a každý [ChartDataPoint](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekt [ChartCategory](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartcategory/) poskytuje popisky nebo skupinové hodnoty sdílené sériemi. Název série, kategorie a hodnoty bodů jsou proto propojeny s objekty [ChartDataCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/) místo toho, aby byly uloženy jen jako zobrazovaný text.

Pro typický kategoriový graf výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbytek buněk pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#getCell) jsou nulové. Tento rozvržení je užitečné, když vytváříte graf s výchozími daty, ale neassumujte, že každý existující graf jej používá. Pro načtenou prezentaci si před změnou hodnot v sešitu prohlédněte buňky odkazované sériemi, kategoriemi a datovými body.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni série, jako například [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getFormat), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, jako například [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getFormat), přepíše vzhled série pro jeden bod.
- Skupinová nastavení platí pro kompatibilní série, které patří do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/). Přístup ke skupině získáte pomocí [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getParentSeriesGroup), když potřebujete nastavit volby jako překrytí nebo šířku mezery.

Když není nastaven explicitní výplň bodu ani série, určuje automatický vzhled styl grafu a téma. Když jsou k dispozici jak formát série, tak formát bodu, formát bodu má přednost pro tento bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií grafu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getOverlap) uvádí, jak moc se pruhy nebo sloupce překrývají ve 2‑D grafu, v rozsahu –100 až 100 procent. Jedná se o jen‑read‑only projekci nastavení v nadřazené skupině sérií. Použijte [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/#setOverlap) pro aktualizaci všech kompatibilních sérií v této skupině. Tato možnost se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

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

![The series overlap](series_overlap.png)

## **Změna výplně série**

Použijte [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getFormat) pro nastavení výchozí výplně celé série. Pokud má bod již explicitně nastavenou výplň, jeho nastavení [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getFormat) přepíše výplň série pro tento bod.

Následující příklad aplikuje pevnou modrou výplň na první sérii:

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

![The color of the series](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu s daty grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro shlukový sloupcový graf je buňka B1 na řádku 0, sloupci 1 a obsahuje název první série. Pojmenované proměnné v následujícím příkladu tuto strukturu explicitně vyjadřují:

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

Můžete také aktualizovat buňku již odkazovanou metodou [ChartSeries.getName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getName). Tento přístup zabraňuje předpokládání konkrétního řádku a sloupce v existujícím grafu:

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

![The series name](series_name.png)

## **Získání automatické barvy výplně série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) vrací barvu vypočtenou z indexu série a stylu grafu. Jedná se o barvu použitou, když výplň série nebyla explicitně definována. Volání metody pouze načte vypočtenou barvu; nepřiřazuje novou výplň.

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

Ukázkový výstup pro výchozí styl grafu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Přesné barvy závisí na stylu a tématu grafu.

## **Nastavení invertované barvy výplně pro sérii grafu**

Pro pruhové, sloupcové a bublinové série může [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#setInvertIfNegative) zobrazit záporné hodnoty s odlišnou výplní. Nastavte běžnou výplň série na pevnou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Záporná čísla zůstávají v sešitu beze změny; mění se pouze jejich zobrazovaná barva.

Následující příklad nahradí výchozí data grafu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Inverzi můžete povolit jen pro jeden bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). V následujícím příkladu je inverze zakázána pro sérii a povolena pouze pro vybraný bod. Bod má také přiřazenou zápornou hodnotu, aby byl efekt viditelný:

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

Chcete‑li učinit jeden bod prázdným bez odstraňování ostatních bodů, nastavte jeho buňku v sešitu na `null`. U sloupcového grafu je vykreslená hodnota dostupná přes [ChartDataPoint.getValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getValue). Datový bod zůstane na stejném místě kategorie, ale graf bude jeho hodnotu považovat za prázdnou podle nastavení prázdných hodnot grafu.

Následující příklad vymaže jen druhý bod v první sérii:

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

Bodové grafy používají oddělené buňky X a Y a bublinové grafy používají také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nevolajte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointcollection/#clear), pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazení prázdných buněk**

Skryté buňky, které obsahují hodnoty, jsou odlišným případem od prázdných buněk. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu se podívejte na [Include Data from Hidden Rows and Columns](/slides/cs/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [ChartDataCell::setValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/#setValue) s `null`, aby buňka byla prázdná. Číselná nula zůstane nulou bez ohledu na nastavení prázdných buněk.

Použijte [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/#setDisplayBlanksAs) k výběru, jak graf zobrazí prázdné buňky. Toto nastavení platí pro celý graf. Mění způsob, jakým jsou prázdné hodnoty vykreslovány, aniž by se prázdná buňka vyplnila nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro Den 3 a uloží graf ve všech třech režimech. Vstupní soubor není vyžadován. [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

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

    // Nechte Den 3 skutečně prázdný, přičemž zachováte jeho kategorii a datový bod.
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

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pokud chcete uložit jen jednu variantu, přiřaďte požadovaný režim a prezentaci uložte jednou místo iterace přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf usnadňuje srovnání všech tří režimů. Pruhové a sloupcové grafy nemají čáru, kterou by bylo možné propojit přes chybějící kategorii, takže `Span` nemůže vytvořit propojený segment zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou vypadat podobně. Podobně u bodového grafu pouze s značkami neexistuje propojující čára. Neočekávejte tři odlišné výsledky pro každý typ grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními shluky pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/#setGapWidth) jednou pro skupinu. Větší hodnota vytváří více prostoru mezi shluky; menší hodnota je činí hustšími.

Následující příklad změní šířku mezery a uloží jen konečnou prezentaci:

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

![The gap width](gap_width.png)

## **Často kladené otázky**

**Které typy grafů podporují datové série?**

Všechny typy grafů zastoupené výčtem [ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/) používají datový sešit, ale jejich série nemají vždy stejnou strukturu hodnot ani nastavení. Například kategoriové grafy používají kategorie a hodnoty, bodové grafy používají X a Y hodnoty a bublinové grafy přidávají velikosti bublin. Použijte metodu vytvoření datového bodu, která odpovídá typu série. Volby jako překrytí a šířka mezery platí jen pro kompatibilní skupiny pruhových nebo sloupcových grafů.

**Co je skupina sérií grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení úrovně skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažená přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [ShapeCollection.addChart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addChart) vytvoří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak sériové, tak kategoriové kolekce před přidáním zcela vlastního datového souboru. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při tvorbě vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte odpovídající buňku hodnoty na `null`, aby bod zachoval svou pozici v kategorii jako prázdný bod. Použijte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointcollection/#clear) pouze když chcete odstranit všechny body z dané série. Pokud také odstraňujete kategorie, aktualizujte všechny série tak, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazeny?**

Výsledek závisí na typu grafu a hodnotě nastavené metodou [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/#setDisplayBlanksAs). Podporované grafy mohou prázdná místa zobrazit jako mezery, jako nulové hodnoty nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz sekce [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií zavolejte [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#setInvertIfNegative) a nastavte barvu vrácenou metodou [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Chování můžete přepsat pro jednotlivý bod metodou [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když jsou formátovány jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro daný bod. Ostatní body nadále používají explicitní formát série nebo, pokud formát série není definován, automatický styl a téma grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozvržení a nejsou formátovacími přepisy na úrovni bodu.

**Existuje omezení počtu sérií, které může graf obsahovat?**

Aspose.Slides neukládá samostatný pevný limit počtu sérií. V praxi rozhodují omezení souboru prezentace, dostupná paměť, čas vykreslování a čitelnost grafu.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/#setGapWidth) na příslušnou nadřazenou skupinu sérií. Zvýšením hodnoty zvětšíte prostor mezi shluky, snížením ho přiblížíte.