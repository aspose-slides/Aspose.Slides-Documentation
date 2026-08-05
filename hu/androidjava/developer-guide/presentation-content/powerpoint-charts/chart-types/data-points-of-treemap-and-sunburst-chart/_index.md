---
title: Adatpontok testreszabása Treemap és Sunburst diagramokban Androidon
linktitle: Adatpontok Treemap és Sunburst diagramokban
type: docs
url: /hu/androidjava/data-points-of-treemap-and-sunburst-chart/
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
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre hierarchikus adatokat, és testreszabhatja a szinteket, címkéket és színeket Treemap és Sunburst diagramokban az Aspose.Slides for Android via Java használatával."
---
## **Áttekintés**

A Treemap és a Sunburst diagramok ugyanazt a hierarchikus adatot jelenítik meg, de különböző elrendezéseket használnak. A Treemap a hierarchiát egymásba ágyazott téglalapokként ábrázolja, amelyek területe a levélértékeket jelöli. A Sunburst koncentrikus gyűrűkkel ábrázolja: a legfelső szintű csoportok a közép közelében vannak, a levélkategóriák pedig a külső gyűrűben.

Az Aspose.Slides for Android via Java minden numerikus érték egy [IChartDataPoint](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/). Az [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) metódusa hozzáférést biztosít a levélhez és szülői csoportjaihoz. Ez a cikk elmagyarázza ezt a leképezést, és bemutatja, hogyan hozhatók létre és formázhatók mindkét diagramtípus ugyanabból a mintaadatból.

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **Kategóriák, adatpontok és szintek megértése**

Az alább használt példa három kategóriaszintet és egy numerikus sorozatot tartalmaz:

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

Minden sor egy levélkategóriát és egy adatpontot hoz létre. A kategória csoportosítási szintek a levél és szülői elemei közötti útvonalat írják le. Az első sor esetében az útvonal `Consumer > Computers > Laptops`.

Az [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) által visszaadott indexek a levéltől felfelé haladnak:

| `getDataPointLevels()` index | Logikai szint | Treemap ábrázolás | Sunburst ábrázolás |
| ---: | --- | --- | --- |
| `0` | Levél | Érték téglalap | Külső gyűrű szegmens |
| `1` | Ág | Szülő téglalap vagy fejléc | Középső gyűrű szegmens |
| `2` | Ágazat | Legfelső szint téglalap vagy fejléc | Belső gyűrű szegmens |

Ez a sorrend mindkét diagramtípusra ugyanaz, bár a vizuális elrendezésük különbözik. Egy szülő szegmens több levél által meg van osztva. Formázásához használja az adott csoport első adatpontjának megfelelő szintjét. Például a `Consumer` ágazat a `Laptops` ponttal kezdődik, míg a `Software` ágba a `Licenses` ponttal. Az ilyen pontokra való hivatkozás tárolása egyértelműbb és biztonságosabb, mint a `dataPoints.get_Item(0)` vagy `dataPoints.get_Item(6)` típusú kifejezések használata.

## **Mindkét diagramtípus létrehozása és testreszabása**

Az alábbi teljes példa egy Treemap diagramot hoz létre az első dián, egy Sunburst diagramot a második dián. Felépíti a hierarchiát, megjeleníti a `Tablets` értékét, rögzített színeket alkalmaz a kiválasztott szintekre, formáz egy ágazatcímkét, és elmenti a prezentációt.

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

        // Adja hozzá a levélkategóriákat. A csoportosító elemet csak akkor állítják be, amikor egy új csoport kezdődik; a következő kategóriák ebben a csoportban maradnak, amíg egy másik elemet be nem állítanak.
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

        // Mutassa a kategóriát és az értéket a Tablets levélen.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formázza a Consumer ágat az ágon lévő első levél segítségével.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        int consumerBranchColor = Color.rgb(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Formázza a Software ágat az ágon lévő első levél segítségével.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        int softwareStemColor = Color.rgb(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // A ParentLabelLayout a Treemap szülőcímkékre hat; a Sunburst gyűrűszegmenseket használ.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A kategóriacellák és az értékcellák ugyanazt a munkalap‑sort használják, ezért a gyűjteményhelyezkedésük összhangban marad. Ha meglévő diagrammal dolgozik egy új létrehozása helyett, először vizsgálja meg a kategória sorokat, és tárolja el a formázni kívánt adatpontokra és szintekre mutató névvel ellátott hivatkozásokat.

## **Viselkedés és gyakorlati szempontok**

### **Treemap és Sunburst különbségek**

- A Treemap területet használ az érték közvetítésére, és egymásba ágyazott téglalapokat a hierarchia ábrázolására. A [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) metódus szabályozza, hogyan jelennek meg a szülőcímkék ebben a diagramtípusban.
- A Sunburst szöget használ az érték közvetítésére, a gyűrűmélységet a hierarchia ábrázolására. A [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) nem szabályozza a gyűrűcímkéket.
- Mindkét diagramtípus ugyanazt a kategória‑csoportosítási szintet és ugyanazt a levél‑szülő sorrendet használja, amelyet az [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) ad vissza, így az adatépítési és szint‑formázási kód megosztható.
- A szülőértékek a leszármazott levelekből számíthatók ki. Ne adjon hozzá külön numerikus pontokat ágazatokhoz vagy ágakhoz.

### **Rendezés és szegmens sorrend**

A diagram elrendező motorja határozza meg a téglalapok és gyűrűszegmensek végleges elhelyezését. Hozza együtt a kapcsolódó kategóriasorokat a hozzáadás előtt, de ne támaszkodjon egy adott téglalappozícióra vagy kezdőszögre. Ha a sorrend jelentéssel bír, vegye fel azt a címkékbe, vagy használjon olyan diagramtípust, amelynek kifejezett kategória‑tengelye van.

### **Téma és rögzített színek**

A formázatlan diagram‑szintek a prezentáció téma színeit öröklik. A példa kifejezett RGB kitöltéseket használ a kiszámítható kimenet érdekében. Ha a diagramnak a téma változását kell követnie, használjon séma‑színeket a rögzített RGB‑értékek helyett, és kerülje minden szint felülírását. Emellett ellenőrizze a címke kontrasztját egy ágazat vagy ág kitöltésének módosítása után.

### **Címkék és rendelkezésre álló hely**

A PowerPoint elrejthet vagy csonkolhat címkéket, ha egy szegmens túl kicsi. A diagram méretének növelése, a kategórianév lerövidítése vagy a megjelenő címkefelületek számának csökkentése általában tisztább eredményt ad. Egy címke kombinálhatja a kategórianév, a sorozatnév és az érték megjelenítését a [IDataLabelFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatalabelformat/) segítségével, de minden mező engedélyezése gyakran nehezen olvasható hierarchikus diagramokhoz vezet.

### **Exportálás és renderelés**

A PPTX formátumba mentés megőrzi a diagram szerkeszthetőségét. Amikor az Aspose.Slides a prezentációt PDF‑re vagy képre rendereli, a támogatott kitöltések és címke‑beállítások a diagrammal együtt kerülnek renderelésre. Betűtípus‑helyettesítés és a rendelkezésre álló elrendezési hely apró eltérései megváltoztathatják a sortörést vagy a címke láthatóságát, ezért telepítse a szükséges betűtípusokat, és ellenőrizze a fontos exportcélokat.

## **GYIK**

**Miért befolyásol egy szülőszint módosítása több levelet?**

Egy ágazat vagy ág egy megosztott vizuális szegmens. Az [IChartDataPointLevel](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapointlevel/) elérhető egy leszármazott levélön keresztül, de a formázás a megosztott szülő szegmenshez tartozik, nem csak ahhoz a levélhez.

**Miért hiányzik egy adatcímke?**

Először engedélyezze a szükséges mezőket a címke [IDataLabelFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatalabelformat/) objektumán. Ezután ellenőrizze, hogy a szegmensnek van‑e elegendő helye. A Treemap szülőcímke‑elrendezése, a diagram méretei, a címke hossza, a betűméret és a bekapcsolt mezők száma mind befolyásolják, hogy megjelenik‑e a címke.

**Beállíthatom a szegmensek pontos sorrendjét vagy koordinátáit?**

Irányíthatja a forrássor sorrendjét, és fenntarthatja minden csoport folytonosságát, de nem adhat meg pontos Treemap téglalapokat vagy Sunburst szögeket. A diagram elrendező motorja a hierarchiából, az értékekből és a rendelkezésre álló helyből számolja ki ezeket.

**Miért változnak a színek a prezentáció téma módosítása után?**

A téma‑alapú kitöltések a prezentáció palettáját követik. Adjon meg kifejezett RGB színeket azoknak a szinteknek, amelyeknek rögzítve kell maradniuk, vagy használjon séma‑színeket, ha az új témához való alkalmazkodás a kívánt.

**Megmaradnak-e az egyedi formázások PDF‑ és képexportáláskor?**

Igen, a támogatott diagram‑kitöltések és címke‑beállítások a renderelés során belekerülnek. A konzisztens eredmény érdekében biztosítsa a szükséges betűtípusok elérhetőségét, és tesztelje a végső export méretét, mert a címke‑illesztés elrendezéstől függ.

## **Lásd még**

- [Create Treemap charts](/slides/hu/androidjava/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/hu/androidjava/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/hu/androidjava/export-chart/)
- [Manage presentation themes](/slides/hu/androidjava/presentation-theme/)