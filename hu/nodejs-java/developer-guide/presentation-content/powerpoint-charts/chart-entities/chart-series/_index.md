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
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban JavaScript‑el."
---
## **Áttekintés**

Egy diagram az ábrázolt adatokat egy diagramadat-munkafüzetben tárolja. Egy [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) egy kapcsolódó értékcsoportot képvisel, és a sorozat minden egyes [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) objektumok a sorozatok által közösen használt címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenített szövegként vannak tárolva.

Egy tipikus kategóriaábrán az alapértelmezett munkafüzet a 0. sorban a sorozatneveket, a 0. oszlopban a kategória neveket, a maradék cellákban pedig a sorozatértékeket használja. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCell) függvényhez átadott munkalap-, sor- és oszlopindexek nullától indulnak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hozunk létre diagramot, de ne feltételezzük, hogy minden létező diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozat szintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat) adja meg az alapértelmezett megjelenést egy sorozat összes pontjának.
- Adatpont szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat) felülírja a sorozat megjelenését egy pontnál.
- Csoport beállítások vonatkoznak a kompatibilis sorozatokra, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) csoporthoz tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) hívásával érheti el, ha olyan beállításokat szeretne megadni, mint az átfedés vagy a részsáv szélessége.

Ha nincs kifejezett pont‑ vagy sorozat‑kitöltés beállítva, a diagramstílus és a téma határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása felülírja a sorozatét az adott pontra.

![diagram-sorozat-pptx](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getOverlap) megadja, hogy a sávok vagy oszlopok milyen mértékben fednek át egy 2D diagramon, –100‑tól 100 %-ig. Ez a szülő sorozatcsoport beállításának csak olvasható leképezése. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) használatával frissítheti a csoport minden kompatibilis sorozatát. Ez az opció azoknál a diagramtípusoknál érvényes, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; nem befolyásolja a kombinált diagramokhoz nem kapcsolódó sorozatcsoportokat.

A következő példa beállítja az átfedést arra a csoportra, amelyik az első sorozatot tartalmazza:

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

Használja a [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getFormat) metódust a teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa egy szilárd kék kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagramadat-munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet, amely a klaszterezett oszlopdiagramhoz jön létre, a B1 cella (0. sor, 1. oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok egyértelművé teszik ezt a struktúrát:

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

A [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getName) által már hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli, hogy egy meglévő diagramra egy adott sorra és oszlopra vonatkozó feltételezéseket tegyen:

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

### **Sorozat létrehozása több cellából származó névvel**

Összetett sorozatnév hasznos, ha a terméknév és a jelentési időszak különálló munkafüzetcellákban van tárolva. Például az `Product A` értéket a B1‑ben és a `2026` értéket a C1‑ben egyetlen sorozatnévvé fűzheti, miközben mindkét rész a forráscelláira hivatkozik.

Használja a [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getCellCollection) metódust a névtartomány lekéréséhez, majd adja át a gyűjteményt a [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/#add) metódusnak. A `skipHiddenCells` argumentum szabályozza, hogy a rejtett cellákat belevegye: `true` kizárja, `false` pedig beleveszi őket. Ez a példa `false`‑t használ, hogy a névtartomány minden celláját beletartalmazza.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozat nevét szolgáltatják; az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket.

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

Az eredményként kapott sorozatnév `Product A 2026`, a két cellaérték között egy szóközzel. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép szemlélteti az eredményt:

![Oszlopdiagram északi és déli értékekkel, valamint a kompozit sorozatnév Product A 2026 a jelmagyarázatban](composite_series_name.png)

## **Az automatikus sorozatszín lekérdezése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozat indexéből és a diagramstílusból számított színt. Ez a szín akkor kerül használatra, amikor a sorozat kitöltése nincs kifejezetten definiálva. A metódus meghívása csak a számított színt olvassa; új kitöltést nem rendel hozzá.

A következő példa kiírja az egyes alapértelmezett sorozatok automatikus színét:

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

Példakimenet az alapértelmezett diagramstílushoz:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagramstílustól és a témától függenek.

## **Invertált kitöltőszín beállítása egy diagram sorozathoz**

Sáv‑, oszlop‑ és buborék‑sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) negatív értékek megjelenítésére használható eltérő kitöltéssel. Állítsa be a szabályos sorozatkitöltést szilárd színűre, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) metódussal. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

A következő példa az alapértelmezett diagramadatokat egy sorozattal helyettesíti. Az 0. sor a sorozat nevét, a 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket tartalmazza:

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

Az invertálást egyetlen pontra a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal is engedélyezheti. Az alábbi példában a sorozatnál le van tiltva az invertálás, csak a kiválasztott pontnál van bekapcsolva, és a pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresre állításához, anélkül, hogy a többi pontot eltávolítaná, állítsa a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagramnál a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#getValue) metódussal érhető el. Az adatpont a ugyanazon kategóriahelyen marad, de a diagram a értéket üresként kezeli a diagram üres‑érték beállításai szerint.

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

A szórt diagramok X és Y cellákat külön kezelnek, a buborékdiagramok pedig egy méretcellát is használnak. Törölje csak azt a cellát, amely a eltávolítani kívánt értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg szeretné tartani, mert ez a metódus minden adatpontot eltávolít a gyűjteményből.

## **Üres cellák megjelenítésének szabályozása**

A rejtett, de értéket tartalmazó cellák külön esetet képeznek az üres celláktól. A rejtett munkalap‑sorok és –oszlopok adatainak felvételéhez vagy kizárásához lásd a [Include Data from Hidden Rows and Columns](/slides/hu/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) cikket.

Egy üres munkafüzetcellát hiányzó adatként értelmezünk; a `0` értékű cella egy ismert numerikus értéket jelent. A [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setValue) metódust `null`‑val hívva üres cellát hozhat létre. A numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellá beállítástól.

A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) metódussal adhatja meg, hogyan jelenjenek meg az üres cellák a diagramon. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja, hogyan ábrázolják a hiányzó értékeket, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, és minden mód esetén elmenti ugyanazt a diagramot. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot használja a kategóriacímkékhez, az 1‑s oszlopot az értékekhez; a 0‑s sor tartalmazza a sorozat nevét. A végső adatsor `10, 20, empty, 30, 40`.

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

Minden kimeneti fájl az elmentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy változatot kíván menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok ciklikus iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: a Gap szüneteli a vonalat a 3. napon, a Zero a vonalat nullához szorítja, a Span összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. Egy vonaldiagram három módot is könnyen összehasonlíthatóvá tesz. Sáv‑ és oszlopdiagramok esetén nincs vonal, amely átkötne egy hiányzó kategóriát, ezért a `Span` nem hozza létre a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen egy szórt diagram marker‑ekkel nem rendelkezik összekötő vonallal. Ne várjon három különböző eredményt minden diagramtípustól; ellenőrizze a kimenetet a saját típusánál.

## **A sorozat részsávszélességének beállítása**

A részsávszélesség a szomszédos sáv‑ vagy oszlopháromsók közötti távolság, amely a sáv‑ vagy oszlopszélesség százalékában van megadva. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a csoportra. A nagyobb érték nagyobb távolságot hoz létre a klaszterek között, a kisebb érték pedig sűrűbb elrendezést eredményez.

A következő példa módosítja a részsávszélességet, és csak a végleges prezentációt menti el:

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

![A részsávszélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) felsorolás által képviselt diagramtípus használ diagramadatokat, de sorozataik nem mindegyiknek ugyanaz a szerkezete vagy beállítása. Például a kategóriaábrák kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket. Használja a sorozattípussal megegyező adatpont‑létrehozó metódust. Az olyan opciók, mint az átfedés és a részsávszélesség csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi a diagram sorozatcsoport?**

Egy [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addChart) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategóriagyűjteményeket törölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagram objektumai a munkafüzetcellákhoz?**

A sorozatnevek, kategóriacímkék és adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adatok építésekor tartsa a kategóriasorokat és a sorozat‑érték‑sorokat összehangolt állapotban, hogy minden pont a kívánt kategória alatt jelenjen meg.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`‑ra, hogy a pont kategóriahelye megmaradjon üres pontként. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha az adott sorozat összes pontját el kívánja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy azok értékei a kategóriagyűjteménnyel összhangban maradjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) által beállított értéktől függ. A támogatott diagramok üres helyeket jeleníthetnek meg részként, nullaként, vagy a szomszédos pontok összekötésével. Válassza a megfelelő beállítást a hiányzó adatok jelentésének megfelelően. A teljes példáért és a vizuális összehasonlításért tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatok esetén hívja meg a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a színt a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott értékre. Egy egyedi pontnál felülbírálhatja a viselkedést a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal. Ezek a módszerek a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont egyaránt formázva van?**

A kifejezetten egy pont számára megadott formázás felülírja a sorozat formázását az adott pontnál. A többi pont továbbra is a kifejezett sorozat‑formázást, vagy ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoportbeállítások, például az átfedés és a részsávszélesség a layoutra vonatkoznak, nem pont‑szintű formázási felülírásokra.

**Van korlátozás a diagramban szereplő sorozatok számát illetően?**

Az Aspose.Slides nem alkalmaz különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentáció fájlmérete, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a használható felső határt.

**Mit kell változtatni, ha a oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a klaszterek közti távolság bővítéséhez, vagy csökkentse, ha közelebb szeretné őket hozni.