---
title: "Adatpontok testreszabása Treemap és Sunburst diagramokban PHP-ben"
linktitle: "Adatpontok Treemap és Sunburst diagramokban"
type: docs
url: /hu/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap diagram
- sunburst diagram
- hierarchikus diagram
- adatpont
- adatcímke
- ág szín
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre hierarchikus adatokat, és testreszabhatja a szinteket, címkéket és színeket a Treemap és Sunburst diagramokban az Aspose.Slides for PHP via Java segítségével."
---
## **Áttekintés**

A Treemap és a Sunburst diagramok ugyanazt a hierarchikus adatot jelenítik meg, de eltérő elrendezéseket használnak. A Treemap a hierarchiát egymásba ágyazott téglalapokként ábrázolja, ahol a terület a levél értékét jelenti. A Sunburst egymásba ágyazott gyűrűkkel ábrázolja: a legfelső szintű csoportok a középpont közelében vannak, a levélkategóriák pedig a külső gyűrűn.

Az Aspose.Slides for PHP via Java esetén minden numerikus érték egy [ChartDataPoint](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/). A [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) metódusa hozzáférést biztosít a levélhez és annak szülőcsoportjaihoz. Ez a cikk bemutatja ezt a leképezést, és megmutatja, hogyan hozhatók létre és formázhatók mindkét diagramtípus ugyanabból a mintaadatból.

![Treemap diagram a Consumer és Business ágakkal](treemap-hierarchy.png)

![Sunburst diagram a Consumer és Business hierarchiával](sunburst-hierarchy.png)

## **Kategóriák, adatpontok és szintek megértése**

Az alább használt minta három kategória szintet és egy numerikus sorozatot tartalmaz:

| Ágazat | Ág | Levél | Bevétel |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Minden sor egy levélkategóriát és egy adatpontot hoz létre. A kategória csoportosítási szintek leírják az útvonalat a levél és a szülői elemek között. Az első sor esetén az útvonal a `Consumer > Computers > Laptops`.

A [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) által visszaadott indexek a levéltől felfelé haladnak:

| `getDataPointLevels()` index | Logikai szint | Treemap ábrázolás | Sunburst ábrázolás |
| ---: | --- | --- | --- |
| `0` | Levél | Érték téglalap | Külső gyűrűs szegmens |
| `1` | Ág | Szülő téglalap vagy fejléc | Középső gyűrűs szegmens |
| `2` | Ágazat | Legfelső téglalap vagy fejléc | Belső gyűrűs szegmens |

Ez a sorrend mindkét diagramtípusnál ugyanaz, bár a vizuális elrendezés eltér. Egy szülő szegmenst több levél osztja meg. Formázásához használja az adott csoport első adatpontjának megfelelő szintjét. Például a `Consumer` ágazat a `Laptops` ponttal kezdődik, míg a `Software` ág a `Licenses` ponttal. Az ilyen pontokra való hivatkozások tárolása egyértelműbb és biztonságosabb, mint a `$dataPoints->get_Item(0)` vagy `$dataPoints->get_Item(6)` típusú kifejezések használata.

## **Mindkét diagram típus létrehozása és testreszabása**

Az alábbi teljes példa az első dián egy Treemap-et, a másodikon egy Sunburst-ot hoz létre. Felépíti a hierarchiát, megjeleníti a `Tablets` értékét, rögzített színeket alkalmaz a kiválasztott szintekre, formáz egy ágazatcímkét, majd elmenti a prezentációt.

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

        // Levél kategóriákat ad hozzá. A csoportosító elem csak akkor kerül beállításra, amikor egy új csoport kezdődik;
        // a következő kategóriák ebben a csoportban maradnak, amíg egy másik elem nincs beállítva.
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

        // Mutassa a kategóriát és az értéket a Tablets levélnél.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Formázza a Consumer ágat az ágon lévő első levél alapján.
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

        // Formázza a Software ágat az ágon lévő első levél alapján.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // A ParentLabelLayout befolyásolja a Treemap szülőcímkéket; a Sunburst a gyűrűszegmenseket használja.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

A kategória- és értékt cellák ugyanazon munkalap sorban helyezkednek el, ezért a gyűjtemény pozíciói továbbra is igazodnak. Ha létező diagrammal dolgozik egy új diagram létrehozása helyett, először vizsgálja meg a kategóriasorokat, és tárolja el a formázni kívánt adatpontok és szintek nevű hivatkozásait.

## **Viselkedés és gyakorlati szempontok**

### **Treemap és Sunburst különbségek**

- A Treemap területet használ az érték közvetítésére és egymásba ágyazott téglalapokat a hierarchia ábrázolására. A [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#setParentLabelLayout) metódus szabályozza, hogy a szülőcímkék hogyan jelennek meg ebben a diagramtípusban.
- A Sunburst szöget használ az érték közvetítésére és a gyűrűmélységet a hierarchia ábrázolására. A [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartseries/#setParentLabelLayout) nem befolyásolja ennek a diagramnak a gyűrűcímkéit.
- Mindkét diagramtípus ugyanazt a kategória csoportosítási szintet és a [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) által visszaadott levél‑szülő sorrendet használja, így az adatépítő és szint‑formázó kód megosztható.
- A szülőértékeket a leszármazott levelek alapján számítják ki. Ne adjon hozzá külön numerikus pontokat ágazatokhoz vagy ágakhoz.

### **Rendezés és szegmens sorrend**

A diagramelrendező motor határozza meg a téglalapok és gyűrűszegmensek végső elhelyezkedését. Helyezze a kapcsolódó kategóriasorokat egymás mellé, mielőtt hozzáadná őket, de ne számítson konkrét téglalappozícióra vagy kezdőszögre. Ha a sorrend jelentőséggel bír, tüntesse fel a címkékben, vagy használjon olyan diagramtípust, amely explicit kategória tengelyt biztosít.

### **Téma és rögzített színek**

A formázatlan diagramszintek a prezentáció témájától öröklik a színeket. A példa meghatározott RGB kitöltéseket használ a kiszámítható kimenet érdekében. Ha a diagramnak a téma változásait kell követnie, használjon sémaszíneket a fix RGB értékek helyett, és kerüljön el minden szint felülírását. Emellett ellenőrizze a címke kontrasztját, miután megváltoztatja egy ágazat vagy ág kitöltését.

### **Címkék és rendelkezésre álló hely**

A PowerPoint elrejtheti vagy csonkolhatja a címkéket, ha egy szegmens túl kicsi. A diagram méretének növelése, a kategória nevek rövidítése vagy a megjelenített címkefelületek számának csökkentése általában tisztább eredményt ad. Egy címke kombinálhatja a kategórianévet, a sorozat nevét és az értéket a [DataLabelFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datalabelformat/) segítségével, de minden mező engedélyezése gyakran megnehezíti a hierarchikus diagramok olvasását.

### **Exportálás és renderelés**

A PPTX formátumban való mentés megőrzi a diagram szerkeszthetőségét. Amikor az Aspose.Slides a prezentációt PDF‑re vagy képre rendereli, a támogatott kitöltések és címke‑beállítások a diagram részeként kerülnek megjelenítésre. A betűtípus‑helyettesítés és a rendelkezésre álló elrendezési tér apró eltérései megváltoztathatják a sortörést vagy a címke láthatóságát, ezért telepítse a szükséges betűtípusokat, és ellenőrizze a fontos exportcélokat.

## **GYIK**

**Miért befolyásolja egy szülő szint módosítása több levelet?**

Egy ágazat vagy ág egy megosztott vizuális szegmens. A [ChartDataPointLevel](https://reference.aspose.com/slides/hu/php-java/aspose.slides/chartdatapointlevel/) elérhető egy leszármazott levélből, de a formázás a megosztott szülő szegmenshez tartozik, nem csak az adott levélhez.

**Miért hiányzik egy adatcímke?**

Először engedélyezze a szükséges mezőket a címke [DataLabelFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/datalabelformat/) objektumában. Ezután ellenőrizze, hogy a szegmensnek van‑e elegendő helye. A Treemap szülő‑címkelayout, a diagram méretei, a címkelengés, a betűméret és az engedélyezett mezők száma mind befolyásolják, hogy a címke megjelenik‑e.

**Beállíthatom a szegmensek pontos sorrendjét vagy koordinátáit?**

A forrás‑sorok sorrendjét és a csoportok folytonosságát szabályozhatja, de a pontos Treemap téglalapok vagy Sunburst szögek megadására nincs lehetőség. A diagramelrendező motor ezeket a hierarchiából, az értékekből és a rendelkezésre álló térből számítja ki.

**Miért változnak a színek a prezentáció téma változása után?**

A téma‑alapú kitöltések úgy vannak tervezve, hogy kövessék a prezentáció palettáját. Alkalmazzon explicit RGB színeket azokra a szintekre, amelyeknek rögzítve kell maradniuk, vagy használjon sémaszíneket, ha a téma változásához történő alkalmazkodás a kívánt megoldás.

**Megmaradnak‑e az egyéni formázások PDF‑ és kép‑exportokban?**

Igen, a támogatott diagram‑kitöltések és címke‑beállítások a renderelés során belekerülnek a kimenetbe. A konzisztens eredmények érdekében biztosítsa a szükséges betűtípusok elérhetőségét, és tesztelje a végső export méretét, mivel a címkék illeszkedése az elrendezéstől függ.

## **Kapcsolódó anyagok**

- [Create Treemap charts](/slides/hu/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/hu/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/hu/php-java/export-chart/)
- [Manage presentation themes](/slides/hu/php-java/presentation-theme/)