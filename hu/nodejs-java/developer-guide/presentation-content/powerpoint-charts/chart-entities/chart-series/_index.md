---
title: Diagram adat sorozatok kezelése prezentációkban JavaScript segítségével
linktitle: Adatsorozat
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
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban JavaScript segítségével."
---
## **Áttekintés**

A diagram tárolhatja a megjelenített értékeket munkafüzet cellákban vagy közvetlenül numerikus literálokként. A [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) egy kapcsolódó értékhalmazt képvisel, és minden [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) egy pontot a sorozatban. A [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) objektumok a sorozatok által közös címkéket vagy csoportosítási értékeket biztosítják. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatnevek, kategóriák és pontértékek a diagram munkafüzetéből származó [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) objektumokat használják.

Tipikus kategória diagram esetén az alapértelmezett munkafüzet az 0. sort a sorozatnevekhez, az 0. oszlopot a kategória nevekhez, a maradék cellákat pedig a sorozat értékekhez használja. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/)‑nek átadott munkalap-, sor‑ és oszlop‑indexek nulláról indulnak. Ez a felépítés hasznos, ha egy diagramot alapértelmezett adatokkal hoz létre, de nem szabad azt feltételezni, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, mint a [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), amely egy sorozat összes pontjának alapértelmezett megjelenését adja meg.
- Adatpont‑szintű beállítások, mint a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), amelyek egy pont esetén felülírják a sorozat megjelenését.
- Csoportbeállítások, amelyek kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) tartoznak. A csoporthoz a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/)‑on keresztül férhet hozzá, ha például átfedés vagy hézag szélesség beállítására van szükség.

Ha nincs kifejezett pont‑ vagy sorozat‑kitöltés megadva, a diagram stílusa és témája határozza meg a automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása felülírja a sorozat beállításait az adott pont esetén.

![chart-series-powerpoint](chart-series-powerpoint.png)

Csoportos henger diagram esetén lásd, hogy a [changing the 3D series type or bar shape](/slides/hu/nodejs-java/3d-chart/#change-the-3d-series-type-and-bar-shape) hogyan befolyásolja az első sorozatot.

## **Sorozatértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, ha a sorozatértékek alkalmazásadatokból vagy számításokból származnak, és nem szükséges munkalap‑cellahivatkozás. Hívja meg a [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/)‑t a [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/)‑vel, mielőtt minden pont [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) eredményét a [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/)‑vel állítaná be.

A gyűjtemény beállítása szabályozza az adott sorozat összes pontértékének forrástípusa. Minden pontérték [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) metódusa jelzi a kiválasztott típust; ezt a gyűjtemény beállításával módosíthatja. `Worksheet` esetén a [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/)‑t használva érheti el a hivatkozott cellát. `DoubleLiterals` esetén a [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) vagy a `setAsLiteralDouble` segítségével olvashat vagy írhat közvetlenül számot.

Az alábbi példa egy oszlopdiagramot hoz létre alapértelmezett sorozattal és kategóriákkal, majd a meglévő első sorozat pontjainak kiszámított 10, 20 stb. értékeket rendeli hozzá. A prezentációt elmenti, újra megnyitja, és kiírja a tárolt értékeket.

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

A pontérték forrástípusa különbözik a [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/)‑tól, amely a diagram belső vagy külső munkafüzet‑konfigurációját azonosítja. A numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategória címkék, sorozatnevek és a többi sorozat számára. A munkafüzet‑kezelésről lásd a [Chart Workbook](/slides/hu/nodejs-java/chart-workbook/) oldalt.

Szórt és buborék diagramok esetén használja a [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) és a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) metódusokat, hogy az [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) és az [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/) forrásait válassza ki. A buborék diagramok továbbá a [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/)‑t használják a [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/) esetén. Minden alkalmazható forrást állítson `DoubleLiterals`‑re, mielőtt a `setAsLiteralDouble` metódussal számot rendelne hozzá.

## **A diagram sorozat‑átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) jelentése, hogy egy 2D diagram oszlopai vagy sávjai mekkora mértékben fednek át egymást, -100 és 100 százalék között. Ez a beállítás csak a szülő sorozatcsoportot érinti olvasás‑csakként. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/)‑al frissítheti a csoport minden kompatibilis sorozatát. Ez a lehetőség azoknál a diagramtípusoknál használható, amelyek csoportos oszlopokat vagy sávokat jelenítenek meg; kombinált diagramokban a nem kapcsolódó sorozatcsoportokra nincs hatással.

Az alábbi példa beállítja az átfedést azon csoportnál, amelyik az első sorozatot tartalmazza:

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

![The series overlap](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

A [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/)‑ot használva állítható be egy teljes sorozat alapértelmezett kitöltése. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa egy szilárd kék kitöltést alkalmaz az első sorozatra:

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

![The color of the series](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagram adat‑munkafüzetben van tárolva, és általában a jelmagyarázatban jelenik meg. Alapértelmezett munkafüzet egy csoportos oszlopdiagram esetén a B1 cella (0. sor, 1. oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a megnevezett állandók ezt a struktúrát teszik egyértelművé:

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

Frissítheti azt a cellát is, amelyet a [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) már hivatkozik. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramban:

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

![The series name](series_name.png)

### **Sorozat létrehozása több cellából származó névvel**

Összetett sorozatnév akkor hasznos, ha a termék neve és a jelentési időszak külön munkafüzet‑cellákban van tárolva. Például a `Product A` B1‑ben és a `2026` C1‑ben egyetlen sorozatnevévé kombinálható, miközben mindkét rész hivatkozott marad a forráscellákra.

A [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/)‑t használja a névtartomány lekéréséhez, majd adja át a gyűjteményt a [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/)‑nak. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák szerepeljenek‑e: `true` kizárja őket, míg `false` felveszi. Ez a példa `false`‑t használ, hogy minden cellát belevegye a névtartományba.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozat nevét adják, az A2:A3 a kategória címkéket, a B2:B3 pedig a numerikus értékeket.

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

    // Ez a két cella biztosítja a sorozat nevét.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // Különálló cellák biztosítják a kategóriákat és a numerikus adatpontokat.
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

Az eredményül kapott sorozatnév `Product A 2026`, a két cellaérték között szóközzel. A jelmagyarázat ezt egy bejegyzésként jeleníti meg mindkét oszlophoz. Az alábbi kép szemlélteti az eredményt:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Az automatikus sorozat‑kitöltőszín lekérése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) visszaadja a sorozat indexéből és a diagram stílusából kalkulált színt. Ez a szín használatos, ha a sorozat kitöltése nincs kifejezetten meghatározva. A metódus a számított színt olvassa, nem rendel új kitöltést.

Az alábbi példa kiírja az egyes alapértelmezett sorozatok automatikus színét:

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

Példa kimenet az alapértelmezett diagramstílusra:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagramstílustól és témától függenek.

## **Inverz kitöltőszín beállítása diagram sorozathoz**

Oszlop, sáv és buborék sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) negatív értékek megjelenítésére használható más színnel. Állítsa be a szabályos sorozatkitöltést szilárdra, engedélyezze a invertálást, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)‑nel. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa egy sorozattal helyettesíti az alapértelmezett diagram adatot. A munkalap 0‑s sora a sorozatnevet, a 0‑s oszlop a kategória neveket, az 1‑s oszlop pedig az értékeket tartalmazza:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Egy pont invertálását a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/)‑val is engedélyezheti. Az alábbi példában a sorozatra le van tiltva az invertálás, csak a kiválasztott pontnál van engedélyezve, amelyhez negatív értéket is rendel, hogy a hatás látható legyen:

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

Egy pont üresre állításához anélkül, hogy a többi pontot eltávolítaná, állítsa a háttércellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/)‑on keresztül érhető el. Az adatpont ugyanazon kategória pozícióban marad, de a diagram a beállításoknak megfelelően üresnek tekinti az értéket.

Az alábbi példa csak a második pontot törli az első sorozatban:

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

Szórt diagramok X és Y cellákat külön használnak, a buborék diagramok méretcellát is. Csak a törlendő értéket tartalmazó cellát törölje. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/)‑t, ha a többi pontot megtartani kívánja, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenítésének vezérlése**

A rejtett, értéket tartalmazó cellák külön esetet jelentenek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatainak fel‑ vagy le‑vonásához lásd a [Include Data from Hidden Rows and Columns](/slides/hu/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Egy üres munkafüzet‑cellát a [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/)‑val `null`‑ra állítva jelölhetünk üresnek. A numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellá beállítástól.

A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/)‑t használva választhatja ki, hogyan jelenítse meg a diagram az üres cellákat. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja az üres értékek ábrázolását, anélkül, hogy a munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3. nap értékét, és minden mód esetén elmenti ugyanazt a diagramot. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot, 0‑s oszlopot használja a kategória címkékhez, az 1‑s oszlopot az értékekhez; a 0‑s sor a sorozat nevét tartalmazza. A végső adatsor: `10, 20, empty, 30, 40`.

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

    // A 3. napot valóban üresen hagyja, miközben megtartja a kategóriáját és adatpontját.
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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az összehasonlítás alább ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típustól függ. A vonaldiagram minden három módot könnyen összehasonlíthatóvá teszi. Oszlop‑ és sávdiagramoknak nincs vonala, amely összekötné a hiányzó kategóriát, ezért a `Span` nem hozhat létre csatlakozó szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, a csupán jelölőkkel rendelkező szórt diagramnak nincs összekötő vonala. Ne várjon három különböző eredményt minden diagramtípusnál; ellenőrizze a kimenetet a használt típusnál.

## **A sorozat hézag‑szélességének beállítása**

A hézag‑szélesség a szomszédos oszlop‑ vagy sáv‑klaszterek közti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/)‑t a csoporton. Egy nagyobb érték több helyet hoz létre a klaszterek között; egy kisebb érték sűrűbbé teszi őket.

Az alábbi példa módosítja a hézag‑szélességet, és csak a végleges prezentációt menti:

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

![The gap width](gap_width.png)

## **Sorozatvonalak megjelenítése vagy elrejtése**

A sorozatvonalak vizuálisan összekötik a diagram kapcsolódó részeit. A [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setserieslines/)‑t használja a támogatott halmozott sáv‑ és OfPie diagramoknál, hogy megjelenítse vagy elrejtse őket. Két dimenziós halmozott sáv‑ és oszlopdiagramokban a sorozatvonalak a megfelelő réteg‑határokat kötik össze a kategóriák között. Pie of Pie és Bar of Pie diagramok esetén a fő ábrát kötik a másodlagos ábrához. Ez a beállítás nem általános csatlakozó más diagramtípusokhoz.

A csoporthoz a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/)‑on keresztül férhet hozzá. A beállítás minden sorozatra vonatkozik a csoportban. A [ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/hasserieslines/) csak‑olvasás, és a szülő csoport beállítását tükrözi; a csoport setter‑ével frissítheti.

Az alábbi példa egy [PieOfPie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) diagramot hoz létre alapértelmezett adatokkal. A diagramot egyszer sorozatvonalakkal menti, majd egyszer nélkül, két prezentációt hozva létre összehasonlításra.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 400);
    const series = chart.getChartData().getSeries().get_Item(0);
    const seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", aspose.slides.SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Sorozatvonalak engedélyezve | Sorozatvonalak letiltva |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| A két vonal összeköti a fő tortát a másodlagos tortával. | Mindkét torta látható marad, de a kapcsoló vonalak rejtve vannak. |

A sorozatvonalak különböznek az adatcímke‑vezetővonalaktól, amelyek a címkéket a pontokhoz kötik; a demenciatól, amelyek a diagram tengelyeit jelölik; és a vonaldiagram vonalai, amelyek az adatértékeket ábrázolják. Ez a beállítás nem szabályozza ezeket az elemeket.

## **GYIK**

**Mely diagramtípusok támogatják az adat‑sorozatot?**

Az összes, a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagram adatot, de sorozataik nem mindegyikében ugyanaz a érték‑szerkezet vagy beállítások. Például a kategória‑diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Az adott sorozattípusnak megfelelő adat‑pont létrehozó metódust használja. Az olyan beállítások, mint az átfedés és a hézag‑szélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram‑sorozat‑csoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmazza egy újonnan létrehozott diagram az alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) mintasorozatot, kategóriát és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategóriagyűjteményeket kiürítheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés segítségével diagramot hozhat létre alapértelmezett adat nélkül is.

**Hogyan kapcsolódnak a diagram‑objektumok a munkafüzet‑cellákhoz?**

A sorozatnevek, kategóriacímkék és adat‑pont értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat felépítésekor ügyeljen arra, hogy a kategória‑sorok és a sorozat‑érték‑sorok össze legyenek hangolva, így minden pont a megfelelő kategóriához kerül.

**Hogyan tudok egy pontot törölni a teljes sorozat helyett?**

Állítsa a vonatkozó értékcellát `null`‑ra, hogy a pont kategória‑pozíciója üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/)‑t csak akkor használja, ha minden pontot el kíván távolítani a sorozatból, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/)‑nál beállított értéktől függ. A támogatott diagramok megjeleníthetik az üresek közti hézagot, nulla értékeket vagy a szomszédos pontok összekapcsolását. Válassza ki a hiányzó adatok jelentésének megfelelő beállítást a prezentációban. A teljes példa és vizuális összehasonlítás a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részben található.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatok esetén hívja a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/)‑t, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) által visszaadott színt. Egy egyedi pont esetén a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/)‑val felülbírálhatja a viselkedést. Ezek a metódusok a formázást, nem a tárolt numerikus értékeket érintik.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adat‑pont formázás felülírja a sorozat formázását az adott pontnál. A többi pont továbbra is a sorozat explicite definiált formázását vagy, ha az nincs definiálva, a automatikus diagram‑stílust és témát használja. A csoport‑beállítások, mint az átfedés és a hézag‑szélesség, a layout‑ot szabályozzák, és nem pont‑szintű formázás felülírásai.

**Van korlátozás a diagramban lévő sorozatok számára?**

Az Aspose.Slides nem határoz meg különálló, fix sorozatszám‑korlátot. Gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos határt.

**Mit kell változtatni, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/)‑t a megfelelő szülő sorozatcsoporton. Növelje az értéket a klaszterek közti távolság szélesítéséhez, vagy csökkentse, hogy a klaszterek közelebb kerüljenek egymáshoz.