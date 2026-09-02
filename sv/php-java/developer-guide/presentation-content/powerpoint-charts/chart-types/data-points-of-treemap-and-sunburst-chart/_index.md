---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram i PHP
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap diagram
- sunburst diagram
- hierarkiskt diagram
- datapunkt
- datalabel
- grenfärg
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du skapar hierarkisk data och anpassar nivåer, etiketter och färger i Treemap- och Sunburst-diagram med Aspose.Slides för PHP via Java."
---
## **Översikt**

Treemap- och Sunburst-diagram visar samma typ av hierarkiska data, men de använder olika layouter. En Treemap ritar hierarkin som inbäddade rektanglar vars områden representerar lövvärden. En Sunburst ritar den som koncentriska ringar: toppnivågrupper är nära centrum och lövkategorierna är på den yttre ringen.

I Aspose.Slides för PHP via Java är varje numeriskt värde ett [ChartDataPoint](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapoint/). Dess [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapoint/#getDataPointLevels)‑metod ger åtkomst till lövet och dess föräldragrupper. Den här artikeln förklarar den mappningen och visar hur man skapar och formaterar båda diagramtyperna från samma exempeldata.

![Ett Treemap-diagram med Consumer- och Business-grenar](treemap-hierarchy.png)

![Ett Sunburst-diagram med samma Consumer- och Business-hierarki](sunburst-hierarchy.png)

## **Förstå kategorier, datapunkter och nivåer**

Exemplet som används nedan har tre kategorinivåer och en numerisk serie:

| Gren | Stam | Löv | Intäkt |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Varje rad skapar en lövkategori och en datapunkt. Kategorigrupperingsnivåerna beskriver sökvägen från det lövet till dess föräldrar. För den första raden är sökvägen `Consumer > Computers > Laptops`.

Indexen som returneras av [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) löper från lövet uppåt:

| `getDataPointLevels()` index | Logisk nivå | Treemap-representation | Sunburst-representation |
| ---: | --- | --- | --- |
| `0` | Löv | Värderektangel | Yttre ringsegment |
| `1` | Stam | Föräldrarektangel eller rubrik | Mellan-ringsegment |
| `2` | Gren | Toppnivårektangel eller rubrik | Inre ringsegment |

Denna ordning är densamma för båda diagramtyperna även om deras visuella layouter skiljer sig. Ett föräldrasegment delas av flera löv. För att formatera det, använd motsvarande nivå från den första datapunkten i den gruppen. Till exempel startar grenen `Consumer` med datapunkten `Laptops`, medan stammen `Software` startar med datapunkten `Licenses`. Att hålla referenser till dessa punkter är tydligare och säkrare än att använda oförklarade uttryck såsom `$dataPoints->get_Item(0)` eller `$dataPoints->get_Item(6)`.

## **Skapa och anpassa båda diagramtyperna**

Det följande kompletta exemplet skapar en Treemap på den första bilden och en Sunburst på den andra bilden. Det bygger hierarkin, visar värdet för `Tablets`, applicerar fasta färger på valda nivåer, formaterar en grenetikett och sparar presentationen.

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

        // Lägg till lövkategorierna. Ett grupperingselement sätts endast när en ny grupp startar;
        // följande kategorier förblir i den gruppen tills ett annat element sätts.
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

        // Visa kategori och värde på Tablets-lövet.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Formatera Consumer-grenen via det första lövet i den grenen.
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

        // Formatera Software-stammen via det första lövet i den stammen.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout påverkar Treemap-föräldraetiketter; Sunburst använder ringsegment.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kategoricellerna och värdecellerna använder samma kalkylbladsrad, så deras samlingspositioner förblir justerade. När du arbetar med ett befintligt diagram snarare än att skapa ett, inspektera först kategoriraderna och lagra namngivna referenser till datapunkterna och nivåerna du avser att formatera.

## **Beteende och praktiska överväganden**

### **Treemap- och Sunburst-skillnader**

- En Treemap använder område för att kommunicera värde och inbäddade rektanglar för att kommunicera hierarki. Metoden [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseries/#setParentLabelLayout) styr hur föräldraetiketter visas i denna diagramtyp.
- En Sunburst använder vinkel för att kommunicera värde och ringdjup för att kommunicera hierarki. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseries/#setParentLabelLayout) styr inte dess ringetiketter.
- Båda diagramtyperna använder samma kategorigrupperingsnivåer och samma löv‑till‑förälder‑ordning som returneras av [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), så kod för databyggande och nivåformatering kan delas.
- Föräldravärden beräknas från deras underliggande löv. Lägg inte till separata numeriska punkter för grenar eller stammar.

### **Sortering och segmentordning**

Diagramlayoutsmotorn bestämmer den slutliga placeringen av rektanglar och ringsegment. Ordna relaterade kategorirader tillsammans innan du lägger till dem, men förlita dig inte på en specifik rektangelposition eller startvinkel. Om sekvensen har betydelse, inkludera den i etiketterna eller använd en diagramtyp med en explicit kategori‑axel.

### **Tema och fasta färger**

Oformaterade diagramnivåer ärver färger från presentationens tema. Exemplet använder explicita RGB‑fyllningar för förutsägbar utdata. Om diagrammet ska följa temaförändringar, använd schemes‑färger i stället för fasta RGB‑värden och undvik att åsidosätta varje nivå. Kontrollera även etikettkontrasten efter att ha ändrat en gren‑ eller stam‑fyllning.

### **Etiketter och tillgängligt utrymme**

PowerPoint kan dölja eller trunkera etiketter när ett segment är för litet. Att öka diagrammets storlek, förkorta kategorinamnen eller visa färre etikettfält ger vanligtvis ett tydligare resultat. En etikett kan kombinera kategorinamnet, serienamnet och värdet via [DataLabelFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabelformat/), men att aktivera varje fält gör ofta hierarkiska diagram svåra att läsa.

### **Export och rendering**

Att spara som PPTX bevarar diagrammets redigerbarhet. När Aspose.Slides renderar presentationen till PDF eller en bild, renderas de stödjade fyllningarna och etikettinställningarna med diagrammet. Teckensnittssubstitution och små skillnader i tillgängligt layoututrymme kan förändra radbrytning eller etikettens synlighet, så installera de nödvändiga teckensnitten och verifiera viktiga exportmål.

## **FAQ**

**Varför påverkar ändring av en föräldranivå flera löv?**

En gren eller stam är ett delat visuellt segment. Dess [ChartDataPointLevel](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartdatapointlevel/) kan nås via ett underliggande löv, men formateringen tillhör det delade föräldrasegmentet snarare än endast det lövet.

**Varför saknas en datalabel?**

Först aktivera de nödvändiga fälten på etikettens [DataLabelFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datalabelformat/)‑objekt. Kontrollera sedan om segmentet har tillräckligt med utrymme. Treemap‑föräldraetikettlayout, diagramdimensioner, etiketternas längd, teckenstorlek och antalet aktiverade fält påverkar alla om en etikett kan visas.

**Kan jag ange exakt ordning eller koordinater för segment?**

Du kan kontrollera källdataradens ordning och hålla varje grupp sammanhängande, men du kan inte tilldela exakta Treemap‑rektanglar eller Sunburst‑vinklar. Diagramlayoutsmotorn beräknar dem utifrån hierarkin, värdena och tillgängligt utrymme.

**Varför ändras färgerna efter att presentationens tema ändrats?**

Temabaserade fyllningar är avsedda att följa presentationens palett. Applicera explicita RGB‑färger på de nivåer som måste förbli fasta, eller behåll scheme‑färger när anpassning till ett nytt tema föredras.

**Kommer anpassad formatering att bevaras i PDF‑ och bild‑export?**

Ja, stödjade diagramfyllningar och etikettinställningar inkluderas vid rendering. För konsekventa resultat över system, gör de nödvändiga teckensnitten tillgängliga och testa den slutliga exportstorleken eftersom etikettpassning är layout‑beroende.

## **Se även**

- [Skapa Treemap-diagram](/slides/sv/php-java/create-chart/#create-tree-map-charts)
- [Skapa Sunburst-diagram](/slides/sv/php-java/create-chart/#create-sunburst-charts)
- [Exportera presentationsdiagram](/slides/sv/php-java/export-chart/)
- [Hantera presentationsteman](/slides/sv/php-java/presentation-theme/)