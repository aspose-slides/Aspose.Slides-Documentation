---
title: "Pas gegevenspunten aan in Treemap‑ en Sunburst‑grafieken in PHP"
linktitle: "Gegevenspunten in Treemap‑ en Sunburst‑grafieken"
type: docs
url: /nl/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap-grafiek
- sunburst-grafiek
- hiërarchische grafiek
- gegevenspunt
- gegevenslabel
- takkleur
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe je hiërarchische gegevens maakt en niveaus, labels en kleuren aanpast in Treemap‑ en Sunburst‑grafieken met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Treemap‑ en Sunburst‑grafieken tonen dezelfde soort hiërarchische gegevens, maar gebruiken verschillende lay‑outs. Een Treemap tekent de hiërarchie als geneste rechthoeken waarvan de oppervlakte de bladwaarden weergeeft. Een Sunburst tekent deze als concentrische ringen: groepen van het top‑niveau staan dicht bij het centrum, en bladcategorieën op de buitenring.

In Aspose.Slides voor PHP via Java is elke numerieke waarde een [ChartDataPoint](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/). De methode [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) biedt toegang tot het blad en de bovenliggende groepen. Dit artikel legt die mapping uit en laat zien hoe je beide grafiektype’s maakt en opmaakt met dezelfde voorbeeldgegevens.

![Een Treemap‑grafiek met Consumer‑ en Business‑takken](treemap-hierarchy.png)

![Een Sunburst‑grafiek met dezelfde Consumer‑ en Business‑hiërarchie](sunburst-hierarchy.png)

## **Begrijp categorieën, gegevenspunten en niveaus**

Het onderstaande voorbeeld bevat drie categoriëniveaus en één numerieke reeks:

| Tak | Stam | Blad | Omzet |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Elke rij creëert één bladcategorie en één gegevenspunt. De categoriëniveaus beschrijven het pad van dat blad naar zijn bovenliggende groepen. Voor de eerste rij is het pad `Consumer > Computers > Laptops`.

De indexen die door [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) worden geretourneerd, lopen van het blad omhoog:

| `getDataPointLevels()` index | Logisch niveau | Treemap‑weergave | Sunburst‑weergave |
| ---: | --- | --- | --- |
| `0` | Blad | Waarde‑rechthoek | Segment van de buitenste ring |
| `1` | Stam | Bovenliggende rechthoek of header | Segment van de middelste ring |
| `2` | Tak | Rechthoek of header van het top‑niveau | Segment van de binnenste ring |

Deze volgorde is voor beide grafiektype’s gelijk, ook al verschillen de visuele lay‑outs. Een bovenliggend segment wordt gedeeld door meerdere bladeren. Om het op te maken, gebruik je het overeenkomstige niveau van het eerste gegevenspunt in die groep. Bijvoorbeeld: de `Consumer`‑tak start met het punt `Laptops`, terwijl de `Software`‑stam start met het punt `Licenses`. Verwijzingen naar die punten bewaren is duidelijker en veiliger dan gebruik te maken van onduidelijke expressies zoals `$dataPoints->get_Item(0)` of `$dataPoints->get_Item(6)`.

## **Maak en pas beide grafiektype’s aan**

Het onderstaande volledige voorbeeld maakt een Treemap op de eerste dia en een Sunburst op de tweede dia. Het bouwt de hiërarchie, toont de waarde voor `Tablets`, past vaste kleuren toe op geselecteerde niveaus, formatteert een tak‑label en slaat de presentatie op.

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

        // Voeg de bladcategorieën toe. Een groepeer-item wordt alleen ingesteld wanneer een nieuwe groep begint;
        // de volgende categorieën blijven in die groep totdat een ander item wordt ingesteld.
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

        // Toon de categorie en waarde op het blad Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Formatteer de Consumer‑tak via het eerste blad in die tak.
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

        // Formatteer de Software‑stam via het eerste blad in die stam.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout beïnvloedt de bovenliggende labels van Treemap; Sunburst gebruikt ringsegmenten.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De categoriën‑cellen en waardecellen gebruiken dezelfde werkblad‑rij, zodat hun verzamelingsposities uitgelijnd blijven. Werk je met een bestaande grafiek in plaats van er een te maken, controleer dan eerst de categoriën‑rijen en sla benoemde verwijzingen naar de gegevenspunten en niveaus die je wilt opmaken op.

## **Gedrag en praktische overwegingen**

### **Verschillen tussen Treemap en Sunburst**

- Een Treemap gebruikt oppervlakte om de waarde te communiceren en geneste rechthoeken om de hiërarchie te tonen. De methode [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#setParentLabelLayout) bepaalt hoe bovenliggende labels verschijnen in dit grafiektype.
- Een Sunburst gebruikt hoek om de waarde te communiceren en ringdiepte om de hiërarchie te tonen. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartseries/#setParentLabelLayout) regelt de ring‑labels niet.
- Beide grafiektype’s gebruiken dezelfde categoriën‑groeperingsniveaus en dezelfde blad‑naar‑ouder‑volgorde die door [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) wordt geretourneerd, waardoor de code voor gegevensopbouw en niveau‑opmaak kan worden gedeeld.
- Bovenliggende waarden worden berekend uit hun afstammende bladeren. Voeg geen aparte numerieke punten toe voor takken of stammen.

### **Sorteren en volgorde van segmenten**

De layout‑engine van de grafiek bepaalt de uiteindelijke plaatsing van rechthoeken en ringsegmenten. Groepeer gerelateerde categoriënrijen vóór het toevoegen, maar vertrouw niet op een specifieke rechthoek‑positie of starthoek. Als de volgorde betekenis heeft, neem die dan op in de labels of gebruik een grafiektype met een expliciete categorie‑as.

### **Thema en vaste kleuren**

Niet‑geformatteerde grafiekniveaus erven kleuren uit het presentatiethema. Het voorbeeld gebruikt expliciete RGB‑vullingen voor voorspelbare output. Als de grafiek thema‑wijzigingen moet volgen, gebruik dan themakleuren in plaats van vaste RGB‑waarden en vermijd het overschrijven van elk niveau. Controleer ook het label‑contrast nadat je een tak‑ of stam‑vulling hebt aangepast.

### **Labels en beschikbare ruimte**

PowerPoint kan labels verbergen of afkappen wanneer een segment te klein is. Het vergroten van de grafiek, het inkorten van categorienamen of het weergeven van minder label‑velden levert meestal een duidelijker resultaat op. Een label kan de categorienaam, de serienaam en de waarde combineren via [DataLabelFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat/), maar het inschakelen van alle velden maakt hiërarchische grafieken vaak moeilijk leesbaar.

### **Export en weergave**

Opslaan als PPTX houdt de grafiek bewerkbaar. Wanneer Aspose.Slides de presentatie renderen naar PDF of een afbeelding, worden de ondersteunde vullingen en labelinstellingen mee‑gerenderd. Font‑substitutie en kleine verschillen in beschikbare layout‑ruimte kunnen doorloop of label‑zichtbaarheid beïnvloeden, dus zorg dat de benodigde lettertypen geïnstalleerd zijn en controleer de belangrijke export‑doelen.

## **FAQ**

**Waarom heeft het wijzigen van een bovenliggend niveau invloed op meerdere bladeren?**

Een tak of stam is een gedeeld visueel segment. De [ChartDataPointLevel](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chartdatapointlevel/) ervan is bereikbaar via een afstammend blad, maar de opmaak behoort toe aan het gedeelde bovenliggende segment, niet alleen aan dat blad.

**Waarom ontbreekt een datalabel?**

Schakel eerst de benodigde velden in op het [DataLabelFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/datalabelformat/)-object van het label. Controleer daarna of het segment voldoende ruimte heeft. De layout van het Treemap‑bovenliggende label, grafiekafmetingen, label‑lengte, lettergrootte en het aantal ingeschakelde velden bepalen of een label getoond kan worden.

**Kan ik de exacte volgorde of coördinaten van segmenten instellen?**

Je kunt de volgorde van de bron‑rijen regelen en elke groep aaneengesloten houden, maar je kunt geen exacte Treemap‑rechthoeken of Sunburst‑hoeken toewijzen. De layout‑engine berekent deze vanuit de hiërarchie, waarden en beschikbare ruimte.

**Waarom veranderen kleuren na een thema‑wijziging van de presentatie?**

Thema‑gebaseerde vullingen volgen het kleurenpalet van de presentatie. Gebruik expliciete RGB‑kleuren voor niveaus die vast moeten blijven, of behoud themakleuren wanneer je je aan een nieuw thema wilt aanpassen.

**Wordt aangepaste opmaak behouden bij export naar PDF en afbeeldingen?**

Ja, ondersteunde grafiekvullingen en labelinstellingen worden meegenomen tijdens het renderen. Voor consistente resultaten across systemen, zorg dat de vereiste fonts beschikbaar zijn en test de uiteindelijke exportgrootte, want label‑passing is afhankelijk van de layout.

## **Zie ook**

- [Create Treemap charts](/slides/nl/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/nl/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/nl/php-java/export-chart/)
- [Manage presentation themes](/slides/nl/php-java/presentation-theme/)