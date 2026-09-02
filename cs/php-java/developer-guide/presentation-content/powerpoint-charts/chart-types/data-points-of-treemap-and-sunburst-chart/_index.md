---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst v PHP
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graf Treemap
- graf Sunburst
- hierarchický graf
- datový bod
- popisek dat
- barva větve
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak vytvořit hierarchická data a přizpůsobit úrovně, popisky a barvy v grafech Treemap a Sunburst pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Grafy Treemap a Sunburst zobrazují stejný typ hierarchických dat, ale používají odlišná rozvržení. Treemap vykresluje hierarchii jako vnořené obdélníky, jejichž plochy představují hodnoty listů. Sunburst ji zobrazí jako soustředné kruhy: skupiny nejvyšší úrovně jsou blízko středu a listové kategorie jsou na vnějším kruhu.

V Aspose.Slides for PHP via Java je každá číselná hodnota [ChartDataPoint](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/). Jeho metoda [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) poskytuje přístup k listu a jeho nadřazeným skupinám. Tento článek vysvětluje toto mapování a ukazuje, jak vytvořit a formátovat oba typy grafů ze stejných ukázkových dat.

![Graf Treemap s větvemi Consumer a Business](treemap-hierarchy.png)

![Graf Sunburst se stejnou hierarchií Consumer a Business](sunburst-hierarchy.png)

## **Pochopení kategorií, datových bodů a úrovní**

Níže použité ukázkové data mají tři úrovně kategorií a jednu číselnou řadu:

| Větev | Vršek | List | Tržby |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Každý řádek vytváří jednu listovou kategorii a jeden datový bod. Úrovně seskupování popisují cestu od tohoto listu k jeho nadřazeným uzlům. Pro první řádek je cesta `Consumer > Computers > Laptops`.

Indexy vrácené metodou [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) běží od listu směrem nahoru:

| Index `getDataPointLevels()` | Logická úroveň | Reprezentace Treemap | Reprezentace Sunburst |
| ---: | --- | --- | --- |
| `0` | List | Obdélník hodnoty | Segment vnějšího kruhu |
| `1` | Vršek | Obdélník nadřazeného nebo hlavička | Segment středního kruhu |
| `2` | Větev | Obdélník nejvyšší úrovně nebo hlavička | Segment vnitřního kruhu |

Toto pořadí je stejné pro oba typy grafů, i když se liší jejich vizuální rozvržení. Nadřazený segment je sdílen několika listy. Pro jeho formátování použijte odpovídající úroveň prvního datového bodu v této skupině. Například větev `Consumer` začíná bodem `Laptops`, zatímco vršek `Software` začíná bodem `Licenses`. Uchovávání odkazů na tyto body je přehlednější a bezpečnější než používání nezdokumentovaných výrazů jako `$dataPoints->get_Item(0)` nebo `$dataPoints->get_Item(6)`.

## **Vytvoření a přizpůsobení obou typů grafů**

Následující kompletní příklad vytvoří Treemap na první snímku a Sunburst na druhém snímku. Vytvoří hierarchii, zobrazí hodnotu pro `Tablets`, použije pevné barvy pro vybrané úrovně, naformátuje popisek větve a uloží prezentaci.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Přidejte listové kategorie. Skupinová položka je nastavena pouze při zahájení nové skupiny;
        // následující kategorie zůstávají v této skupině, dokud není nastavena další položka.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Zobrazte kategorii a hodnotu na listu Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Naformátujte větev Consumer pomocí prvního listu v této větvi.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Naformátujte vršek Software pomocí prvního listu v tomto vršku.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout ovlivňuje popisky nadřazených uzlů v Treemap; Sunburst používá segmenty kruhů.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Buňky kategorií a hodnot používají stejný řádek sešitu, takže jejich pozice v kolekcích zůstávají zarovnané. Když pracujete s existujícím grafem místo jeho vytváření, nejprve prozkoumejte řádky kategorií a uložte pojmenované odkazy na datové body a úrovně, které chcete formátovat.

## **Chování a praktické úvahy**

### **Rozdíly mezi Treemap a Sunburst**

- Treemap používá plochu k předání hodnoty a vnořené obdélníky k předání hierarchie. Metoda [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#setParentLabelLayout) řídí, jak se zobrazují popisky nadřazených uzlů v tomto typu grafu.
- Sunburst používá úhel k předání hodnoty a hloubku kruhu k předání hierarchie. Metoda [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/#setParentLabelLayout) neovlivňuje popisky jeho kruhů.
- Oba typy grafů používají stejné úrovně seskupování kategorií a stejné pořadí list‑nadřazený vrácené metodou [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), takže kód pro vytváření dat a formátování úrovní může být sdílen.
- Hodnoty nadřazených uzlů jsou vypočítány z jejich podřízených listů. Nepřidávejte samostatné číselné body pro větve nebo vršky.

### **Řazení a pořadí segmentů**

Stroj rozvržení grafu určuje finální umístění obdélníků a segmentů kruhů. Před jejich přidáním seskupte související řádky kategorií, ale nespoléhejte se na konkrétní pozici obdélníku nebo počáteční úhel. Pokud má sekvence význam, zahrňte ji do popisků nebo použijte typ grafu s explicitní kategoriální osou.

### **Motiv a pevné barvy**

Neformátované úrovně grafu dědí barvy z motivů prezentace. Příklad používá explicitní výplně RGB pro předvídatelný výstup. Pokud má graf sledovat změny motivu, použijte barvy schématu místo pevných RGB hodnot a vyhněte se přepisování všech úrovní. Také po změně výplně větve nebo vršku zkontrolujte kontrast popisků.

### **Popisky a dostupný prostor**

PowerPoint může skrývat nebo zkracovat popisky, když je segment příliš malý. Zvýšení velikosti grafu, zkrácení názvů kategorií nebo zobrazení menšího počtu polí popisku obvykle vede k přehlednějším výsledkům. Popisek může kombinovat název kategorie, název řady a hodnotu pomocí [DataLabelFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datalabelformat/), ale povolení všech polí často ztěžuje čitelnost hierarchických grafů.

### **Export a vykreslování**

Ukládání do PPTX zachovává editovatelnost grafu. Když Aspose.Slides vykresluje prezentaci do PDF nebo obrázku, podporované výplně a nastavení popisků jsou vykresleny spolu s grafem. Substituce písem a drobné rozdíly v dostupném prostoru mohou změnit zalamování řádků nebo viditelnost popisků, proto nainstalujte požadovaná písma a ověřte důležité exportní cíle.

## **Často kladené otázky**

**Proč změna úrovně nadřazeného uzlu ovlivní několik listů?**

Větev nebo vršek je sdílený vizuální segment. Jeho [ChartDataPointLevel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartdatapointlevel/) lze dosáhnout přes podřízený list, ale formátování patří sdílenému nadřazenému segmentu, nikoli jen tomuto listu.

**Proč v grafu chybí popisek dat?**

Nejprve povolte požadovaná pole v objektu [DataLabelFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datalabelformat/) popisku. Pak zkontrolujte, zda má segment dostatek místa. Rozvržení popisků nadřazených uzlů v Treemap, rozměry grafu, délka popisku, velikost písma a počet povolených polí ovlivňují, zda může být popisek zobrazen.

**Mohu nastavit přesné pořadí nebo souřadnice segmentů?**

Můžete kontrolovat pořadí řádků zdroje a udržovat každou skupinu souvislou, ale nemůžete přiřadit přesné obdélníky Treemap ani úhly Sunburst. Stroj rozvržení grafu je vypočítá z hierarchie, hodnot a dostupného prostoru.

**Proč se barvy změní po změně motivu prezentace?**

Výplně založené na motivu jsou navrženy tak, aby sledovaly paletu prezentace. Použijte explicitní RGB barvy pro úrovně, které mají zůstat pevné, nebo zachovejte barvy schématu, pokud je preferováno přizpůsobení novému motivu.

**Zůstanou vlastní formátování zachována v exportech do PDF a obrázků?**

Ano, podporované výplně grafu a nastavení popisků jsou zahrnuty během vykreslování. Pro konzistentní výsledky napříč systémy zpřístupněte požadovaná písma a otestujte finální velikost exportu, protože umisťování popisků je závislé na rozvržení.

## **Související odkazy**

- [Create Treemap charts](/slides/cs/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/cs/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/cs/php-java/export-chart/)
- [Manage presentation themes](/slides/cs/php-java/presentation-theme/)