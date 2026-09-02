---
title: Správa řad dat grafu v prezentacích v PHP
linktitle: Datové řady
type: docs
url: /cs/php-java/chart-series/
keywords:
- řada grafu
- překrytí řady
- barva řady
- název řady
- datový bod
- buňka sešitu
- mezera řady
- záporná hodnota
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, jak spravovat řady grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí PHP."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu dat grafu. Objekt [ChartSeries](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/) představuje jednu sadu souvisejících hodnot a každý [ChartDataPoint](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekty [ChartCategory](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartcategory/) poskytují štítky nebo hodnoty seskupení sdílené řadami. Název řady, kategorie a hodnoty bodů jsou tedy spojeny s objekty [ChartDataCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatacell/) místo toho, aby byly uloženy pouze jako zobrazovaný text.

Pro typický kategoriální graf výchozí sešit používá řádek 0 pro názvy řad, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty řad. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/#getCell) jsou nulové. Toto uspořádání je užitečné při vytváření grafu s výchozími daty, ale nepředpokládejte, že jej používá každý existující graf. U načtené prezentace prověřte buňky odkazované řadami, kategoriemi a datovými body před změnou hodnot v sešitu.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni řady, například [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getFormat), poskytují výchozí vzhled pro všechny body v jedné řadě.
- Nastavení datového bodu, například [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getFormat), přepisují vzhled řady pro jeden bod.
- Nastavení skupiny se vztahují na kompatibilní řady, které patří do stejného [ChartSeriesGroup](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/). Přístup ke skupině získáte pomocí [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getParentSeriesGroup), pokud potřebujete nastavit volby jako překrytí nebo šířku mezery.

Pokud není nastaven explicitní výplň bodu nebo řady, určuje automatický vzhled styl a motiv grafu. Když jsou přítomny jak formátování řady, tak bodu, má přednost formátování bodu pro daný bod.

![graf-série-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řady grafu**

Metoda [ChartSeries.getOverlap](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getOverlap) udává, jak moc se překrývají sloupce nebo pruhy v 2D grafu, v rozmezí od -100 do 100 procent. Jedná se o pouze pro čtení projekci nastavení na nadřazenou skupinu řad. Použijte [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/#setOverlap) k aktualizaci všech kompatibilních řad v této skupině. Tato volba se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny řad v kombinovaném grafu.

Následující příklad nastavuje překrytí pro skupinu, která obsahuje první řadu:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // Nový graf obsahuje ukázkové řady, kategorie a hodnoty.
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

![Překrytí řady](series_overlap.png)

## **Změna výplně řady**

Použijte [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getFormat) k nastavení výchozí výplně celé řady. Pokud má bod již explicitní výplň, jeho nastavení [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getFormat) přepisuje výplň řady pro tento bod.

Následující příklad použije plnou modrou výplň na první řadu:

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

![Barva řady](series_color.png)

## **Změna názvu řady**

Název řady je uložen v sešitu dat grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitě vytvořeném pro seskupený sloupcový graf je buňka B1 v řádku 0, sloupci 1 a obsahuje název první řady. Pojmenované proměnné v následujícím příkladu explicitně ukazují tuto strukturu:

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

Buňku, na kterou již ukazuje [ChartSeries.getName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getName), můžete také aktualizovat. Tento přístup zabraňuje předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

![Název řady](series_name.png)

## **Získání automatické barvy výplně řady**

Metoda [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) vrací barvu vypočítanou z indexu řady a stylu grafu. Jedná se o barvu používanou, když výplň řady není explicitně definována. Volání metody načte vypočítanou barvu; nepřiřazuje novou výplň.

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

Příklad výstupu pro výchozí styl grafu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Přesné barvy závisí na stylu grafu a motivu.

## **Nastavení invertované barvy výplně pro řadu grafu**

Pro pruhové, sloupcové a bublinové řady může metoda [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#setInvertIfNegative) zobrazit záporné hodnoty s odlišnou výplní. Nastavte běžnou výplň řady na plnou, povolte invertování a přiřaďte barvu pro záporné hodnoty pomocí [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Záporná čísla zůstávají v sešitu beze změny; mění se pouze jejich zobrazovaná barva.

Následující příklad nahrazuje výchozí data grafu jednou řadou. Řádek listu 0 obsahuje název řady, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

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

![Invertovaná plná výplň](inverted_solid_fill_color.png)

Pro jeden bod můžete invertování povolit pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). V následujícím příkladu je invertování pro řadu zakázáno a povoleno pouze pro vybraný bod. Bodu je také přiřazena záporná hodnota, aby byl efekt viditelný:

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

Nastavte příslušnou buňku s hodnotou na `null`, aby bod zachoval svou pozici kategorie jako prázdný bod. U sloupcového grafu je vykreslená hodnota dostupná pomocí [ChartDataPoint.getValue](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getValue). Datový bod zůstane na stejné pozici kategorie, ale graf jej podle nastavení prázdných hodnot považuje za prázdný.

Následující příklad vymaže pouze druhý bod v první řadě:

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

Rozptylové grafy používají samostatné buňky X a Y a bublinové grafy také používají buňku pro velikost. Vymažte pouze buňku, která představuje hodnotu, kterou chcete odstranit. Nevolajte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointcollection/#clear), pokud chcete zachovat ostatní body, protože tato metoda odstraní každý datový bod ze sbírky.

## **Nastavení šířky mezery řady**

Šířka mezery je prostor mezi sousedními skupinami pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině řad, nikoli k jedné řadě. Metodu [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/#setGapWidth) zavolejte jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi skupinami; menší hodnota je učiní hustšími.

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

**Které typy grafů podporují datové řady?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/) používají data grafu, ale jejich řady nemají všechny stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, rozptylové grafy používají hodnoty X a Y a bublinové grafy přidávají velikosti bublin. Použijte metodu vytváření datových bodů, která odpovídá typu řady. Možnosti jako překrytí a šířka mezery se vztahují pouze na kompatibilní skupiny pruhů nebo sloupců.

**Co je skupina řad grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/) obsahuje kompatibilní řady, které sdílejí nastavení vykreslování na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny získané přes jednu řadu nutně nemění všechny řady v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [ShapeCollection.addChart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addChart) vytváří ukázkové řady, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak kolekci řad, tak kolekci kategorií před přidáním zcela vlastního datového souboru. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy řad, štítky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot řad zarovnané, aby byl každý bod vykreslen pod zamýšlenou kategorií.

**Jak mohu vymazat jeden bod místo celé řady?**

Nastavte příslušnou buňku s hodnotou na `null`, aby bod zachoval svou pozici kategorie jako prázdný bod. Metodu [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointcollection/#clear) používejte jen v případě, že chcete odstranit všechny body z dané řady. Pokud také odstraňujete kategorie, aktualizujte všechny řady, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a hodnotě nastavené pomocí [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/#setDisplayBlanksAs). Podporované grafy mohou prázdné místo zobrazovat jako mezery, jako nulové hodnoty nebo propojením sousedních bodů. Zvolte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci.

**Jak jsou záporné hodnoty formátovány?**

U podporovaných pruhových, sloupcových a bublinových řad zavolejte [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#setInvertIfNegative) a nastavte barvu vrácenou metodou [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Chování pro jednotlivý bod můžete přepsat pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když jsou formátovány jak řada, tak bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát řady nebo, pokud formát řady není definován, automatický styl a motiv grafu. Nastavení skupiny, jako jsou překrytí a šířka mezery, řídí rozvržení a nejsou přepisováním formátování na úrovni bodu.

**Existuje limit, kolik řad může graf obsahovat?**

Aspose.Slides neukládá samostatný pevný limit počtu řad. V praxi určují omezení souboru prezentace, dostupná paměť, čas renderování a čitelnost grafu praktický limit.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/#setGapWidth) na odpovídající nadřazené skupině řad. Zvyšte hodnotu, aby se zvětšil prostor mezi skupinami, nebo ji snižte, aby se skupiny přiblížily k sobě.