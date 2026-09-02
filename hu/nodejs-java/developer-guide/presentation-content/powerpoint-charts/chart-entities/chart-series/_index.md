---
title: Diagram adat sorozatok kezelése prezentációkban JavaScript használatával
linktitle: Adatsorozatok
type: docs
url: /hu/nodejs-java/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- sorozat név
- adatpont
- munkafüzet cella
- sorozat hézag
- negatív érték
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézsávszélességet és negatív értékeket a prezentációkban JavaScript segítségével."
---
## **Áttekintés**

A diagram az ábrázolt adatokat egy diagram adat munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartcategory/) objektumok a sorozatok által közösen használt címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [ChartDataCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/) objektumokhoz vannak kapcsolva, nem csupán megjelenő szövegként tárolva.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatneveknél, a 0. oszlopot a kategória nevekhez, a többi cellát pedig a sorozatértékekhez. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#getCell) metódusnak átadott munkalap-, sor- és oszlopszámok nullától indulnak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén vizsgálja meg a sorozat, a kategóriák és az adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

Diagram beállítások három különböző hatókörrel rendelkeznek:
- Sorozat szintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getFormat) az egy sorozat összes pontjának alapértelmezett megjelenését biztosítja.
- Adatpont beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getFormat) felülírja a sorozat megjelenését egy adott pontra.
- Csoport beállítások alkalmazhatók a kompatibilis sorozatokra, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) segítségével érheti el, ha például átfedés vagy részsávszélesség beállítására van szükség.

Ha nincs kifejezetten megadva pont vagy sorozat kitöltés, a diagram stílusa és témája határozza meg a automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása lesz előnyben a konkrét pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Állítsa be a diagram sorozat átfedését**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getOverlap) azt jelzi, hogy a 2D diagramon a sávok vagy oszlopok mennyire fedik át egymást, -100 és 100 százalék között. Ez egy csak olvasható képezése a szülő sorozatcsoport beállításának. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) segítségével frissítheti az adott csoport minden kompatibilis sorozatát. Ez az opció a csoportosított sávok vagy oszlopok megjelenítését támogató diagramtípusokra vonatkozik; nem érinti a kombinált diagramok nem kapcsolódó sorozatcsoportjait.

A következő példa beállítja az átfedést azon csoportban, amely az első sorozatot tartalmazza:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Az új diagram mintasorozatokat, kategóriákat és értékeket tartalmaz.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

A teljes sorozat alapértelmezett kitöltésének beállításához használja a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getFormat) metódust. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa szilárd kék kitöltést alkalmaz az első sorozatra:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorozat színe](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagram adat munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely csoportos oszlopdiagramhoz jön létre, a B1 cella a 0. soron, 1. oszlopban van, és az első sorozat nevét tartalmazza. A következő példában szereplő névkonstansok egyértelművé teszik ezt a szerkezetet:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Frissítheti azt a cellát is, amelyre már a [ChartSeries.getName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getName) hivatkozik. Ez a megközelítés elkerüli, hogy meglévő diagram esetén konkrét sorra és oszlopra támaszkodjon:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorozat neve](series_name.png)

## **Az automatikus sorozat kitöltőszín lekérése**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor kerül felhasználásra, ha a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása csak a számolt színt olvassa, nem állít be új kitöltést.

A következő példa kiírja az alapértelmezett sorozatok automatikus színét:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

Példa kimenet az alapértelmezett diagram stílusra:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függenek.

## **Inverz kitöltőszín beállítása diagram sorozathoz**

Sáv-, oszlop- és buborék sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) lehetővé teszi, hogy a negatív értékek másik kitöltéssel jelenjenek meg. Állítsa be a normál sorozat kitöltését szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenő színük változik.

A következő példa az alapértelmezett diagram adatot egy sorozatra cseréli. A munkalap 0. sora a sorozat nevét, a 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket tartalmazza:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az invertált szilárd kitöltőszín](inverted_solid_fill_color.png)

A pont szintjén az invertálást a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) segítségével engedélyezheti. A következő példában az invertálás a sorozatra le van tiltva, és csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egy adott adatpont értékének törlése**

Egy pont üresen hagyásához a többi pont eltávolítása nélkül, állítsa a mögöttes munkafüzetcellát `null`-ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getValue) segítségével érhető el. Az adatpont a ugyanazon kategóriahelyen marad, de a diagram a beállított üresérték-kezelés szerint üresként kezeli az értékét.

A következő példa csak a második pontot törli az első sorozatban:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pontos diagramok külön X és Y cellákat használnak, a buborék diagramok továbbá egy méretcellát is. Csak azt a cellát törölje, amely az eltávolítandó értéket reprezentálja. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg akarja tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **A sorozat hézagszélességének beállítása**

A hézagszélesség a szomszédos sáv- vagy oszlopcsoportok közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez is a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust egyszer kell meghívni a csoporton. A nagyobb érték nagyobb távolságot hoz létre a csoportok között; a kisebb érték szorosabb elrendezést eredményez.

A következő példa módosítja a hézagszélességet, és csak a végleges prezentációt menti:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A hézagszélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType] felsorolásban szereplő diagramtípus használ diagram adatot, de sorozataik nem rendelkeznek ugyanazzal az értékszerkezettel vagy beállításokkal. Például a kategória diagramok kategóriákat és értékeket használnak, a pontdiagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Használja az adatpont létrehozásához a sorozat típusának megfelelő metódust. Az olyan opciók, mint az átfedés és a hézagszélesség, csak a kompatibilis sáv vagy oszlop csoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup] tartalmaz kompatibilis sorozatokat, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több mint egy csoportot is tartalmazhat, ezért egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart] mintasorozatokat, kategóriákat és értékeket hoz létre. Szerkesztheti ezeket a cellákat, vagy törölheti a sorozat- és kategória-gyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Túlterhelt verzió is létrehozható diagram alapértelmezett adat nélkül.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sorozatnevek, a kategóriacímkék és az adatpontértékek a [ChartDataWorkbook] celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adatok építésekor tartsa a kategória sorokat és a sorozat-érték sorokat igazítva, hogy minden pont a megfelelő kategória alá kerüljön.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a releváns értékcellát `null`-ra, hogy a pont kategóriahelye üres pontként maradjon. A [ChartDataPointCollection.clear] csak akkor használja, ha az adott sorozat minden pontját el kívánja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek összehangoltak maradjanak a kategória-gyűjteménnyel.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [Chart.setDisplayBlanksAs] által beállított értéktől függ. A támogatott diagramok üres pontokat megjeleníthetnek hézagként, nullaként vagy a szomszédos pontok összekapcsolásával. Válassza ki a beállítást, amely a hiányzó adatok jelentését tükrözi a prezentációban.

**Hogyan formázzák a negatív értékeket?**

Támogatott sáv, oszlop és buborék sorozatok esetén hívja a [ChartSeries.setInvertIfNegative] metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor] által visszaadott színt. Egy egyedi pontnál a [ChartDataPoint.setInvertIfNegative] használatával felülbírálhatja a viselkedést. Ezek a metódusok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adatpont formázás lesz előnyben az adott pontnál. A többi pont továbbra a sorozat explicit formázását vagy, ha az nincs definiálva, az automatikus diagram stílusát és témáját használja. A csoport beállítások, mint az átfedés és a hézagszélesség, a elrendezést szabályozzák, és nem felülírják a pontszintű formázást.

**Van korlátozva, hogy egy diagram hány sorozatot tartalmazhat?**

Az Aspose.Slides nem von ki külön rögzített sorozatszámlimitet. Gyakorlatban a prezentáció fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos limitet.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja a [ChartSeriesGroup.setGapWidth] metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közötti távolság növeléséhez, vagy csökkentse, hogy a csoportok közelebb kerüljenek egymáshoz.