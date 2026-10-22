---
title: Diagram adatsorok kezelése prezentációkban JavaScript használatával
linktitle: Adatsorok
type: docs
url: /hu/nodejs-java/chart-series/
keywords:
- diagram sorok
- sor átfedés
- sor szín
- sor név
- adatpont
- munkafüzet cella
- sor hézag
- negatív érték
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diagram sorokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban JavaScript segítségével."
---
## **Áttekintés**

Egy diagram tárolhatja a megjelenített értékeit munkafüzetcellákban vagy közvetlenül számliterálokként. A [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) egy kapcsolódó értékekből álló halmazt képvisel, és minden [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) a sor egy pontját jelenti. A [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) objektumok biztosítják a címkéket vagy a sorok által megosztott csoportosítási értékeket. Az alapértelmezett adatokkal létrehozott diagramokban a sornevek, kategóriák és pontértékek a diagram munkafüzetének [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) objektumaiból származnak.

Egy tipikus kategória diagram alapértelmezett munkafüzetében a 0. sor a sorneveket, a 0. oszlop a kategória neveket, a maradék cellák pedig a sor értékeit tartalmazzák. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) számára megadott munkalap-, sor- és oszlopszámok nulla‑alapúak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállítások három különböző hatókörrel rendelkeznek:

- Sor‑szintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) alapértelmezett megjelenést ad minden pontnak egy sorban.
- Adatpont‑szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) felülbírálják a sor megjelenését egy adott pontnál.
- Csoport beállítások alkalmazhatók kompatibilis sorokra, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) segítségével érheti el, ha például átfedés vagy hézag szélesség beállítására van szüksége.

Ha nincs explicit pont‑ vagy sor‑kitöltés megadva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Amikor mind sor, mind pont formázás jelen van, a pont formázása felülírja a sorét az adott pontnál.

![diagram-sorok-powerpoint](chart-series-powerpoint.png)

## **Sorértékek beállítása számliterálokkal**

Használjon számliterálokat, ha a sorértékek az alkalmazás adataiból vagy számításaiból származnak, és nincs szükség munkalap‑cellahivatkozásokra. Hívja a [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) metódust a [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) értékkel, mielőtt minden pont [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) eredményét a [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/) metódussal állítaná be.

A gyűjtemény‑beállítás szabályozza az összes pont értékének forrástípusát az adott sorban. Minden pont [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) metódusa jelzi a kiválasztott típust; változtassa meg a gyűjtemény‑beállítással. `Worksheet` esetén a [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) segítségével érheti el a hivatkozott cellát. `DoubleLiterals` esetén a [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) vagy a `setAsLiteralDouble` metódussal olvashat vagy írhat közvetlenül számot.

Az alábbi példa egy oszlopdiagramot hoz létre alapértelmezett sorokkal és kategóriákkal, majd a meglévő első sor pontjaihoz rendeli a 10, 20 stb. számított értékeket. Ezután menti a prezentációt, újra megnyitja, és kiírja a tárolt értékeket.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

A pontérték forrástípusa különbözik a [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) beállítástól, amely a diagram belső vagy külső munkafüzet‑konfigurációját jelzi. A számliterálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategóriacímkék, sornevek és a többi sor számára. Lásd a [Chart Workbook](/slides/hu/nodejs-java/chart-workbook/) oldalt a munkafüzet‑kezeléshez.

Szórt és buborék diagramok esetén használja a [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) és a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) metódusokat a [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) és a [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/) forrásainak kiválasztásához. A buborék diagramok a [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) metódust is használják a [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/) forrásához. Minden alkalmazandó forrást állítson `DoubleLiterals`‑re, mielőtt a `setAsLiteralDouble` metódussal számokat rendelne a megfelelő értékhez.

## **Diagram sor‑átfedés beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) jelentése, hogy a 2D diagram oszlopai vagy sávjai milyen mértékben fednek át egymásra, –100‑tól 100‑ig százalékban. Ez egy csak‑olvasásra szánt leképezés a szülő sorcsoport beállításáról. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) használatával frissítheti az összes kompatibilis sort a csoportban. Ez a lehetőség olyan diagramtípusokra vonatkozik, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; kombinált diagramok esetén nem befolyásolja a nem kapcsolódó sorcsoportokat.

Az alábbi példa a első sort tartalmazó csoport átfedését állítja be:

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

    // Az új diagram minta sorokat, kategóriákat és értékeket tartalmaz.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorok átfedése](series_overlap.png)

## **Sor kitöltőszínének megváltoztatása**

Használja a [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) metódust az egész sor alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, akkor annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) beállítása felülbírálja a sor kitöltését az adott pontnál.

Az alábbi példa egy szilárd kék kitöltést alkalmaz az első sorra:

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

![A sor színe](series_color.png)

## **Sor nevének módosítása**

A sor neve a diagram adatmunkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely a klaszteres oszlopdiagramhoz jön létre, a B1 cella (0‑sor, 1‑oszlop) tartalmazza az első sor nevét. Az alábbi példában a névkonstansok explicit módon tükrözik ezt a struktúrát:

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

Frissítheti azt a cellát is, amelyet már a [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) hivatkozik. Ez a megközelítés elkerüli egy konkrét sor‑ és oszlophivatkozás feltételezését egy létező diagramon:

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

![A sor neve](series_name.png)

### **Sor létrehozása több cella nevéből**

Összetett sornevet akkor használhat, ha a termék neve és a jelentési időszak külön munkafüzetcellákban tárolódik. Például a `Product A` a B1‑ben és a `2026` a C1‑ben kombinálható egyetlen sornevébe, miközben mindkét rész megmarad a forráscellához kapcsolódva.

Használja a [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) metódust a névtartomány lekéréséhez, majd adja át ezt a gyűjteményt a [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/) metódusnak. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellákat is belevegye: `true` kizárja, `false` belefoglalja. Ebben a példában `false` értékkel minden cellát felvesz a névtartományból.

Az alábbi példa egy prezentációt hoz létre egy sorral és két adatponttal. A B1:C1 tartomány csak a sor nevét adja, az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Ez a két cella szolgáltatja a sor nevét.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Külön cellák szolgáltatják a kategóriákat és a numerikus adatpontokat.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott sor neve `Product A 2026`, a két cellaérték között szóközzel. A jelmagyarázat egy bejegyzésként jeleníti meg azt mindkét oszlop esetén. Az alábbi kép szemlélteti az eredményt:

![Oszlopdiagram északi‑déli értékekkel, összetett sorneve `Product A 2026` a jelmagyarázatban](composite_series_name.png)

## **Automatikus sor kitöltőszín lekérése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) visszaadja a sor indexe és a diagram stílusa alapján számított színt. Ez a szín használatos, amikor a sor kitöltése nincs explicit módon definiálva. A metódus csak a számított színt olvassa; nem állít be új kitöltést.

Az alábbi példa kiírja minden alapértelmezett sor automatikus színét:

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

A példakimenet az alapértelmezett diagram stílushoz:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függenek.

## **Inverz kitöltőszín beállítása diagram sorhoz**

Osztott, oszlop és buborék sorok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) használatával megjeleníthető a negatív érték másik kitöltéssel. Állítsa be a szabályos sor kitöltését szilárdra, engedélyezze az invertálást, és a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) adja vissza. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük módosul.

Az alábbi példa az alapértelmezett diagram adatot egyetlen sorra cseréli. A munkalap 0‑sora a sor nevét tartalmazza, az 0‑oszlop a kategória neveket, az 1‑es oszlop pedig az értékeket:

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

Egy pont invertálását a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) segítségével is engedélyezheti. Az alábbi példában a sor invertálása le van tiltva, csak a kiválasztott pontnál van engedélyezve, amelynek negatív értéke is van, hogy a hatás látható legyen:

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

## **Adott adatpont értékének törlése**

Egy pont üresként való beállításához a többi pont eltávolítása nélkül, állítsa a mögöttes munkafüzet‑cellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) metódussal érhető el. Az adatpont ugyanabban a kategóriapozícióban marad, de a diagram a értékét üresnek tekinti a diagram üres‑érték beállításaitól függően.

Az alábbi példa csak a második pontot törli az első sorban:

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

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méretcellát is. Csak azt a cellát törölje, amelyik az eltávolítandó értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) metódust, ha a másik pontokat meg akarja tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenítésének vezérlése**

A rejtett, de értékkel rendelkező cellák esetét különbözőként kell kezelni az üres celláktól. A rejtett munkalap‑sorok és –oszlopok adatait a [Include Data from Hidden Rows and Columns](/slides/hu/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) szakaszban tekintheti meg.

Egy üres munkafüzet‑cellát a hiányzó adat jelölésére használunk; a `0` értékű cella egy ismert numerikus értéket jelent. Hívja a [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) metódust `null`‑val, hogy a cellát üresre állítsa. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellá beállítástól.

Használja a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) metódust, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik, és módosítja az üres értékek ábrázolását anélkül, hogy a munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorral, törli a 3. nap értékét, majd minden módot külön fájlba menti. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) a 0‑sor, 0‑oszlop kategóriacímkéket, 1‑es oszlop értékeket használ; a 0‑sor tartalmazza a sor nevét. A végső adatsor: `10, 20, empty, 30, 40`.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriát és az adatpontot.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és mentse el a prezentációt egyszer a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: Gap a vonalat szakad a 3. napon, Zero a vonalat nullára húzza, és Span összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagram esetén a három mód könnyen összehasonlítható. Oszlop- és sávdiagramok esetén nincs vonal a hiányzó kategória áthidalásához, így a `Span` nem hoz létre összekötő szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop hasonlóan nézhet ki. Hasonlóképpen a szórt diagram csak jelölőkkel nincs összekötő vonala. Ne várjon három különböző eredményt minden diagramtípusnál; ellenőrizze a kimenetet a használt típushoz.

## **Sor hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv‑ vagy oszlopcsoportok közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez is a szülő sorcsoport szintjén van, nem egyetlen sorban. Hívja egyszer a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) metódust a csoporton. A nagyobb érték nagyobb részt hoz létre a csoportok között; a kisebb érték sűrűbb elrendezést eredményez.

Az alábbi példa módosítja a hézag szélességét, és csak a végső prezentációt menti:

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

![A hézag szélessége](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják a sorokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagram adatot, de sorai nem mindegyik esetben rendelkeznek azonos értékszerkezettel vagy beállításokkal. Például a kategóriadiagramok kategóriákat és értékeket, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket használnak. Használja a sor típusának megfelelő adatpont‑létrehozó metódust. Az átfedés és hézag szélesség beállítások csak kompatibilis sáv‑ vagy oszlopsorok esetén alkalmazhatók.

**Mi az a diagram sorcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) olyan kompatibilis sorokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, ezért egy soron keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) mintasorokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sor‑ és kategóriagyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy overload akár alapértelmezett adat nélkül is létrehozhat diagramot.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sornevek, kategóriacímkék és adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adat felépítésekor tartsa a kategória‑sorokat és a sor‑érték sorokat igazítva, hogy minden pont a megfelelő kategória alá legyen ábrázolva.

**Hogyan töröljek egy pontot a teljes sor helyett?**

Állítsa az érintett értékcellát `null`‑ra, hogy a pont kategóriahelyzetét üres pontként megtartsa. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/)‑t csak akkor használja, ha minden pontot el akar távolítani az adott sorból. Ha a kategóriákat is eltávolítja, frissítse minden sort, hogy az értékek továbbra is a kategóriagyűjteménnyel igazodjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) beállítástól függ. A támogatott diagramok megjeleníthetik az üreseként maradt részleteket hézagként, nullaként, vagy a szomszédos pontok összekötésével. Válassza azt a beállítást, amely a hiányzó adatok jelentésének leginkább megfelel a prezentációjában. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) szakaszt a teljes példáért és a vizuális összehasonlításért.

**Hogyan formázott a negatív érték?**

A támogatott sáv‑, oszlop‑ és buborék sorok esetén hívja a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) által visszaadott színt. Egy egyedi pont viselkedését a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/) metódussal írhatja felül. Ezek a módszerek a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sor és egy pont is formázva van?**

Az explicit adatpont‑formázás felülbírálja a sor formázását az adott pontnál. A többi pont továbbra is a sor explicit formázását vagy, ha az nincs definiálva, az automatikus diagram stílust és témát használja. A csoportszintű beállítások, mint az átfedés és hézag szélesség, a elrendezést szabályozzák, és nem pontszintű formázási felülírások.

**Van korlátozás a diagramon szereplő sorok számában?**

Az Aspose.Slides nem határoz meg külön fix sor‑számkorlátot. Gyakorlatban a prezentáció fájlmérete, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit kell módosítani, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) metódust a megfelelő szülő sorcsoporton. Növelje az értéket a klaszterek közti távolság növeléséhez, vagy csökkentse a csoportok közelebb hozatalához.