---
title: "Treemap és Sunburst diagramok adatpontjainak testreszabása Java-ban"
linktitle: "Treemap és Sunburst diagramok adatpontjai"
type: docs
url: /hu/java/data-points-of-treemap-and-sunburst-chart/
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
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre hierarchikus adatokat, és testreszabhatja a szinteket, címkéket és színeket a Treemap és Sunburst diagramokban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A Treemap és a Sunburst diagramok ugyanazt a hierarchikus adatot jelenítik meg, de eltérő elrendezéseket használnak. A Treemap a hierarchiát egymásba ágyazott négyzetekkel ábrázolja, amelyek területei a levélértékeket jelölik. A Sunburst koncentrikus gyűrűkkel ábrázolja: a felső szintű csoportok a középpont közelében vannak, a levélkategóriák pedig a külső gyűrűn.

Az Aspose.Slides for Java-ban minden numerikus érték egy [IChartDataPoint](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/). Az [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) metódusa hozzáférést biztosít a levélhez és szülőcsoportjaihoz. Ez a cikk bemutatja ezt a leképezést, és megmutatja, hogyan kell létrehozni és formázni mindkét diagramtípust ugyanabból a mintaadatból.

![Treemap diagram a Fogyasztó és Üzleti ágazatokkal](treemap-hierarchy.png)

![Sunburst diagram azonos Fogyasztó és Üzleti hierarchiával](sunburst-hierarchy.png)

## **Kategóriák, Adatpontok és Szintek megértése**

Az alább használt minta három kategóriaszintet és egy numerikus sorozatot tartalmaz:

| Ágazat | Ág | Levél | Bevétel |
| --- | --- | --- | ---: |
| Fogyasztó | Számítógépek | Laptopok | 12 |
| Fogyasztó | Számítógépek | Asztali gépek | 8 |
| Fogyasztó | Mobil | Telefonok | 15 |
| Fogyasztó | Mobil | Táblagépek | 6 |
| Üzleti | Szolgáltatások | Tanácsadás | 10 |
| Üzleti | Szolgáltatások | Támogatás | 7 |
| Üzleti | Szoftver | Licenszek | 11 |
| Üzleti | Szoftver | Előfizetések | 14 |

Minden sor egy levélkategóriát és egy adatpontot hoz létre. A kategóriacsoportosítási szintek leírják az útvonalat a levéltől a szülői elemekig. Az első sor esetében az útvonal `Consumer > Computers > Laptops`.

Az [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) által visszaadott indexek a levéltől felfelé haladnak:

| `getDataPointLevels()` index | Logikai szint | Treemap ábrázolás | Sunburst ábrázolás |
| ---: | --- | --- | --- |
| `0` | Levél | Érték téglalap | Külső gyűrű szegmens |
| `1` | Ág | Szülő téglalap vagy fejléc | Középső gyűrű szegmens |
| `2` | Ágazat | Legfelső szintű téglalap vagy fejléc | Belső gyűrű szegmens |

Ez a sorrend mindkét diagramtípus esetében megegyezik, annak ellenére, hogy a vizuális elrendezésük különbözik. Egy szülő szegmens több levél által megosztott. Formázásához használja a csoport első adatpontjának megfelelő szintjét. Például a `Consumer` ágazat a `Laptops` ponttal kezdődik, míg a `Software` ág a `Licenses` ponttal. Az ilyen referenciák tárolása egyértelműbb és biztonságosabb, mint a `dataPoints.get_Item(0)` vagy `dataPoints.get_Item(6)` kifejezések használata.

## **Mindkét diagramtípus létrehozása és testreszabása**

Az alábbi teljes példa egy Treemap diagramot hoz létre az első dián és egy Sunburst diagramot a másodikon. Felépíti a hierarchiát, megjeleníti a `Tablets` értékét, rögzített színeket alkalmaz a kiválasztott szintekre, formáz egy ágazatcímkét, és menti a bemutatót.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Add the leaf categories. A grouping item is set only when a new group begins;
        // the following categories remain in that group until another item is set.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Show the category and value on the Tablets leaf.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Format the Consumer branch through the first leaf in that branch.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Format the Software stem through the first leaf in that stem.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout affects Treemap parent labels; Sunburst uses ring segments.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A kategóriacellák és értékcellák ugyanazt a munkalap-sort használják, így a gyűjteménypozíciók összehangoltak maradnak. Ha meglévő diagrammal dolgozik a létrehozás helyett, először ellenőrizze a kategóriasorokat, és tárolja a formázni kívánt adatpontokra és szintekre mutató neveket.

## **Viselkedés és gyakorlati szempontok**

### **Treemap és Sunburst különbségek**

- A Treemap területet használ az érték közlésére, és egymásba ágyazott négyzeteket a hierarchia ábrázolására. Az [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) metódus szabályozza, hogy a szülőcímkék hogyan jelennek meg ebben a diagramtípusban.
- A Sunburst szöget használ az érték közlésére, és a gyűrű mélységét a hierarchia ábrázolására. Az [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) nem befolyásolja a gyűrűcímkéket.
- Mindkét diagramtípus ugyanazt a kategória csoportosítási szintet és ugyanazt a levél‑szülő sorrendet használja, amelyet az [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) ad vissza, ezért az adatépítési és szint‑formázási kódot meg lehet osztani.
- A szülő értékeket a leszármazott levelekből számítják ki. Ne adjon hozzá külön numerikus pontokat ágazatokhoz vagy ágakhoz.

### **Rendezés és szegmens sorrend**

A diagram elrendező motora határozza meg a téglalapok és gyűrűszegmensek végleges elhelyezését. Hozza együttesre a kapcsolódó kategóriasorokat, mielőtt hozzáadná őket, de ne támaszkodjon egy adott téglalappozícióra vagy kezdőszögre. Ha a sorrend jelentést hordoz, tüntesse fel azt a címkékben, vagy használjon olyan diagramtípust, amely kifejezett kategória‑tengelyt biztosít.

### **Téma és fix színek**

A nem formázott diagramszintek a bemutató témájából öröklik a színeket. A példa kifejezett RGB kitöltéseket használ a kiszámítható kimenet érdekében. Ha a diagramnak a téma változásait kell követnie, használjon séma‑színeket a rögzített RGB értékek helyett, és kerülje a minden szint felülírását. Ellenőrizze a címke kontrasztját egy ágazat vagy ág kitöltésének módosítása után is.

### **Címkék és rendelkezésre álló hely**

A PowerPoint elrejtheti vagy csonkolhatja a címkéket, ha egy szegmens túl kicsi. A diagram méretének növelése, a kategórianevek rövidítése vagy a megjelenített címkefelemek csökkentése általában tisztább eredményt ad. Egy címke kombinálhatja a kategórianév, sorozatnév és érték megjelenítését a [IDataLabelFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idatalabelformat/) segítségével, de minden mező engedélyezése gyakran nehezíti a hierarchikus diagramok olvasását.

### **Exportálás és renderelés**

A PPTX formátumba mentés megőrzi a diagram szerkeszthetőségét. Amikor az Aspose.Slides a prezentációt PDF‑re vagy képre rendereli, a támogatott kitöltések és címke‑beállítások a diagrammal együtt kerülnek feldolgozásra. A betűtípus‑helyettesítés és a rendelkezésre álló elrendezési tér kisebb eltérései megváltoztathatják a sortörést vagy a címke láthatóságát, ezért telepítse a szükséges betűtípusokat, és ellenőrizze a fontos exportcélokat.

## **GYIK**

**Miért befolyásolja egy szülő szint módosítása több levelet?**

Egy ágazat vagy ág egy megosztott vizuális szegmens. Az [IChartDataPointLevel](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapointlevel/) a leszármazott levélön keresztül érhető el, de a formázás a közös szülő szegmenshez tartozik, nem csak a konkrét levélhez.

**Miért hiányzik egy adatcímke?**

Először engedélyezze a szükséges mezőket a címke [IDataLabelFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/idatalabelformat/) objektumán. Ezután ellenőrizze, hogy a szegmens rendelkezik‑e elegendő hellyel. A Treemap szülőcímke‑elrendezése, a diagram méretei, a címke hossza, betűmérete és az engedélyezett mezők száma mind befolyásolják, hogy a címke megjeleníthető‑e.

**Beállíthatom a szegmensek pontos sorrendjét vagy koordinátáit?**

A forrás‑sor sorrendjét szabályozhatja, és minden csoportot összefüggővé tehet, de a pontos Treemap téglalapok vagy Sunburst szögek megadása nem lehetséges. A diagram elrendező motora a hierarchiából, az értékekből és a rendelkezésre álló térből számolja ki őket.

**Miért változnak a színek a prezentáció téma módosítása után?**

A téma‑alapú kitöltések a bemutató palettáját követik. Azoknak a szinteknek, amelyeknek rögzítettnek kell maradniuk, használjon kifejezett RGB színeket, vagy a téma‑váltás esetén maradjon a séma‑színek használatánál.

**Megmarad-e az egyéni formázás PDF‑ és kép‑exportoknál?**

Igen, a támogatott diagram‑kitöltések és címke‑beállítások a renderelés során is szerepelnek. A konzisztens eredményekért biztosítsa a szükséges betűtípusok elérhetőségét, és tesztelje a végső export méretét, mivel a címke‑elhelyezés az elrendezéstől függ.

## **Lásd még**

- [Treemap diagramok létrehozása](/slides/hu/java/create-chart/#create-tree-map-charts)
- [Sunburst diagramok létrehozása](/slides/hu/java/create-chart/#create-sunburst-charts)
- [Prezentációs diagramok exportálása](/slides/hu/java/export-chart/)
- [Prezentációs témák kezelése](/slides/hu/java/presentation-theme/)