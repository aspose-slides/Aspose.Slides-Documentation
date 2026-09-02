---
title: Adatsorok testreszabása Treemap és Sunburst diagramokban JavaScript használatával
linktitle: Adatsorok Treemap és Sunburst diagramokban
type: docs
url: /hu/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap diagram
- sunburst diagram
- hierarchikus diagram
- adatsor
- adatcímke
- ág színe
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre hierarchikus adatokat, és testreszabhatja a szinteket, címkéket és színeket a Treemap és Sunburst diagramokban az Aspose.Slides for Node.js via Java segítségével."
---
## **Áttekintés**

A Treemap és a Sunburst diagramok ugyanazt a hierarchikus adatot jelenítik meg, de eltérő elrendezéseket használnak. A Treemap a hierarchiát egymásba ágyazott téglalapokként ábrázolja, ahol a terület a levél értékét jelzi. A Sunburst koncentrikus gyűrűkkel ábrázolja: a felső szintű csoportok a középpont közelében, a levélkategóriák pedig a külső gyűrűben vannak.

Az Aspose.Slides for Node.js via Java esetén minden numerikus érték egy [ChartDataPoint](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/). A [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) metódusa hozzáférést biztosít a levélhez és a szülőcsoportjaihoz. Ez a cikk elmagyarázza ezt a leképezést, és bemutatja, hogyan hozhatók létre és formázhatók mindkét diagramtípus ugyanabból a mintaadatból.

![A Treemap diagram a Consumer és Business ágakkal](treemap-hierarchy.png)

![Egy Sunburst diagram ugyanazzal a Consumer és Business hierarchiával](sunburst-hierarchy.png)

## **Kategóriák, adatsorok és szintek megértése**

Az alábbi példa három kategória szintet és egy numerikus sorozatot tartalmaz:

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

Minden sor egy levélkategóriát és egy adatsort hoz létre. A kategóriacsoportosítási szintek leírják az útvonalat a levélről a szülőire. Az első sor esetén az útvonal `Consumer > Computers > Laptops`.

A [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) által visszaadott indexek a levélről felfelé haladnak:

| `getDataPointLevels()` index | Logikai szint | Treemap ábrázolás | Sunburst ábrázolás |
| ---: | --- | --- | --- |
| `0` | Levél | Érték téglalap | Külső gyűrű szegmens |
| `1` | Ág | Szülő téglalap vagy fejléc | Középső gyűrű szegmens |
| `2` | Ágazat | Legfelső téglalap vagy fejléc | Belső gyűrű szegmens |

Ez a sorrend mindkét diagramtípusnál ugyanaz, bár a vizuális elrendezésük különbözik. Egy szülő szegmens több levél által közösen használt. Formázásához használja a csoport első adatpontjának megfelelő szintjét. Például a `Consumer` ágazat a `Laptops` ponttal kezdődik, míg a `Software` ág a `Licenses` ponttal. Az ezen pontokra való hivatkozások megtartása egyértelműbb és biztonságosabb, mint a `dataPoints.get_Item(0)` vagy `dataPoints.get_Item(6)` típusú, magyarázat nélküli kifejezések használata.

## **Mindkét diagramtípus létrehozása és testreszabása**

Az alábbi teljes példa egy Treemap diagramot hoz létre az első dián, egy Sunburst diagramot a másodikon. Felépíti a hierarchiát, megjeleníti a `Tablets` értékét, rögzített színeket alkalmaz a kiválasztott szintekre, formáz egy ágazatcímkét, és elmenti a prezentációt.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Adja hozzá a levélkategóriákat. Csoportosító elemet csak akkor állítanak be, amikor egy új csoport kezdődik;
        // a következő kategóriák ebben a csoportban maradnak, amíg egy másik elemet nem állítanak be.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Mutassa a kategóriát és az értéket a Tabletek levélén.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Formázza a Consumer ágat az adott ág első levéljén keresztül.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Formázza a Software ágat az adott ág első levéljén keresztül.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // A ParentLabelLayout hatással van a Treemap szülőcímkékre; a Sunburst gyűrűszegmenseket használ.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A kategória- és értécellák ugyanazt a munkalap-sort használják, ezért a gyűjteményük pozíciói összehangoltak maradnak. Ha meglévő diagrammal dolgozik, a létrehozás helyett először ellenőrizze a kategória sorokat, és tároljon névvel hivatkozásokat az adatpontokra és a formázni kívánt szintekre.

## **Viselkedés és gyakorlati megfontolások**

### **Treemap és Sunburst különbségek**

- A Treemap a területet használja az érték közvetítésére, a beágyazott téglalapokat pedig a hierarchia jelzésére. A [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) metódus szabályozza, hogyan jelennek meg a szülőcímkék ebben a diagramtípusban.
- A Sunburst a szöget használja az érték közvetítésére, a gyűrűmélységet a hierarchia jelzésére. A [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) nem befolyásolja a gyűrűcímkéket.
- Mindkét diagramtípus ugyanazt a kategóriacsoportosítási szinteket és a levél‑szülő sorrendet használja, amelyet a [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) ad vissza, ezért a adatépítő és szint‑formázó kód megosztható.
- A szülő értékek a leszármazott levelekből számítódnak ki. Ne adjon hozzá külön numerikus pontokat az ágazatokhoz vagy ágakhoz.

### **Rendezés és szegmens sorrend**

A diagram elrendező motorja határozza meg a téglalapok és gyűrűszegmensek végső helyét. Helyezze egymáshoz kapcsolódó kategóriasorokat együtt, mielőtt hozzáadná őket, de ne támaszkodjon egy konkrét téglalappozícióra vagy kezdőszögre. Ha a sorozat jelentéssel bír, tüntesse fel a címkékben vagy használjon olyan diagramtípust, amely kifejezett kategória‑tengelyt biztosít.

### **Téma és rögzített színek**

Formázatlan diagramszintek a prezentáció téma színeit öröklik. A példa kifejezett RGB kitöltéseket használ a kiszámítható kimenet érdekében. Ha a diagramnak a téma változásait kell követnie, használjon séma‑színeket a rögzített RGB értékek helyett, és kerülje minden szint felülírását. Emellett ellenőrizze a címke kontrasztját egy ágazat vagy ág kitöltésének módosítása után.

### **Címkék és rendelkezésre álló hely**

A PowerPoint elrejtheti vagy csonkolhatja a címkéket, ha egy szegmens túl kicsi. A diagram méretének növelése, a kategórianév rövidítése vagy a megjelenített címkefields számának csökkentése általában tisztább eredményt ad. Egy címke kombinálhatja a kategórianév, sorozatnév és érték megjelenítését a [DataLabelFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabelformat/) segítségével, de minden mező engedélyezése gyakran nehezen olvasható hierarchikus diagramot eredményez.

### **Exportálás és renderelés**

A PPTX formátumba mentés megőrzi a diagram szerkeszthetőségét. Amikor az Aspose.Slides a prezentációt PDF‑be vagy képfájlba rendereli, a támogatott kitöltések és címke‑beállítások a diagramon jelennek meg. A betűtípus‑helyettesítés és a rendelkezésre álló elrendezési hely apró eltérései befolyásolhatják a sortörést vagy a címke láthatóságát, ezért telepítse a szükséges betűtípusokat, és ellenőrizze a fontos exportcélokat.

## **GYIK**

**Miért befolyásolja egy szülő szint módosítása több levél megjelenését?**

Egy ágazat vagy ág közös vizuális szegmens. A [ChartDataPointLevel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapointlevel/) egy leszármazott levélről érhető el, de a formázás a megosztott szülő szegmenshez tartozik, nem csak a konkrét levélhez.

**Miért hiányzik egy adatcímke?**

Először engedélyezze a szükséges mezőket a címke [DataLabelFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/datalabelformat/) objektumában. Ezután ellenőrizze, hogy a szegmensnek elegendő helye van‑e. A Treemap szülőcímke‑elrendezés, a diagram méretei, a címke hossza, betűmérete és a bekapcsolt mezők száma mind hatással van arra, hogy a címke megjeleníthető‑e.

**Beállíthatom a szegmensek pontos sorrendjét vagy koordinátáit?**

Igen, szabályozhatja a forrás‑sorok sorrendjét, és megtartja minden csoport egymás mellett lévő elrendezését, de nem adhat meg pontos Treemap téglalapokat vagy Sunburst szögeket. A diagram elrendező motorja a hierarchiából, az értékekből és a rendelkezésre álló helyből számítja ki ezeket.

**Miért változnak a színek a prezentáció téma módosítása után?**

A téma‑alapú kitöltések a prezentáció palettáját követik. Alkalmazzon kifejezett RGB színeket azokra a szintekre, amelyeknek rögzítve kell maradniuk, vagy használjon séma‑színeket, ha az új témahoz való alkalmazkodás a kívánt.

**Megmarad a saját formázás PDF‑ és kép‑exportokban?**

Igen, a támogatott diagram‑kitöltések és címke‑beállítások a renderelés során bennemaradnak. A konzisztens eredmény érdekében biztosítsa a szükséges betűtípusok elérhetőségét, és tesztelje a végső export méretét, mert a címke‑illeszkedés az elrendezéstől függ.

## **Lásd még**

- [Treemap diagramok létrehozása](/slides/hu/nodejs-java/create-chart/#creating-tree-map-charts)
- [Sunburst diagramok létrehozása](/slides/hu/nodejs-java/create-chart/#creating-sunburst-charts)
- [Prezentációs diagramok exportálása](/slides/hu/nodejs-java/export-chart/)
- [Prezentációs témák kezelése](/slides/hu/nodejs-java/presentation-theme/)