---
title: Diagram adat sorozatok kezelése prezentációkban JavaScript használatával
linktitle: Adatsorok
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
description: "Tanulja meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban JavaScript segítségével."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagramadat-munkafüzetben tárolja. A [ChartSeries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/) egy kapcsolódó értékcsoportot képvisel, és a sorozatban található minden [ChartDataPoint](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Így a sorozat neve, a kategóriák és a pontértékek a [ChartDataCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként tárolódnak.

Egy tipikus kategória-diagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatneveknek, a 0‑s oszlopot a kategórianévnek, a maradék cellákat pedig sorozatértékeknek. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#getCell) függvénynek átadott munkalap-, sor- és oszlopszámok nulla‑alapúak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat a munkafüzetértékek módosítása előtt.

A diagrambeállítások három különböző hatókörben léteznek:

- Sorozat‑szintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getFormat) a sorozat összes pontjának alapértelmezett megjelenését határozza meg.
- Adatpont‑szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getFormat) felülírja a sorozat megjelenését egyetlen pontra.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/) tartoznak. A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) hívással érheti el, ha például átfedés vagy oszloptávolság beállítására van szükség.

Ha nincs explicit pont‑ vagy sorozat‑kitöltés megadva, a diagramstílus és a téma határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása előnyben részesül az adott pontra vonatkozóan.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozatának átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getOverlap) jelzi, hogy a sávok vagy oszlopok milyen mértékben fednek át egymást egy 2D diagramon, -100 és 100 százalék között. Ez csak olvasható visszatérés a szülő sorozatcsoport beállítására. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) használatával frissítheti a csoport összes kompatibilis sorozatát. Ez a lehetőség a csoportos sávok vagy oszlopok megjelenítését támogató diagramtípusokra vonatkozik; nem érinti a kombinált diagramok nem kapcsolódó sorozatcsoportjait.

Az alábbi példa beállítja az átfedést arra a csoportra, amely az első sorozatot tartalmazza:

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

Használja a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getFormat) metódust a teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontra.

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

A sorozat neve a diagramadat-munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet, amely egy csoportosított oszlopdiagramhoz jön létre, B1 cellája (0‑s sor, 1‑s oszlop) az első sorozat nevét tartalmazza. A következő példa névkonstansai ezt a struktúrát teszik egyértelművé:

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

Frissítheti azt a cellát is, amelyre a [ChartSeries.getName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getName) már hivatkozik. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy már létező diagram esetén:

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

## **Az automatikus sorozatszín lekérése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozat indexe és a diagramstílus alapján kiszámított színt. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs explicit módon meghatározva. A metódus hívása csak a számított színt olvassa, nem rendel új kitöltést.

Az alábbi példa kiírja minden alapértelmezett sorozat automatikus színét:

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

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagramstílustól és a témától függenek.

## **Invertált kitöltőszín beállítása egy diagram sorozathoz**

Sáv, oszlop és buborék sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) negatív értékeket megjeleníthet más kitöltéssel. Állítsa be a szabályos sorozatkitöltést szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenési színük változik.

Az alábbi példa az alapértelmezett diagramadatot egy sorozatra cseréli. A 0‑s sor tartalmazza a sorozat nevét, a 0‑s oszlop a kategórianeveket, az 1‑s oszlop pedig az értékeket:

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

Az invertálást egy pont esetén a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) használatával is engedélyezheti. Az alábbi példában a sorozatnál le van tiltva az invertálás, csak a kiválasztott pontnál van engedélyezve, valamint a pont negatív értéket kap, hogy a hatás látható legyen:

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

Egy pont üresre állításához a többi pontot érintve ne távolítsa el őket, állítsa a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getValue) segítségével érhető el. Az adatpont a kategóriapozícióban marad, de a diagram a értéket üresként kezeli a diagram üres‑érték beállításai szerint.

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

Szórásdiagramok külön X és Y cellákat használnak, a buborékdiagramok továbbá egy méretcellát. Törölje csak azt a cellát, amely a törlendő értéket tartalmazza. Ne hívja meg a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg szeretné tartani, mivel ez a metódus a gyűjtemény minden adatpontját eltávolítja.

## **Az üres cellák megjelenítésének vezérlése**

A rejtett, de értéket tartalmazó cellák külön esetet jelentenek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatainak fel‑ vagy le‑vonásához lásd a [Include Data from Hidden Rows and Columns](/slides/hu/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns) szakaszt.

Az üres munkafüzetcellát hiányzó adatként, a `0`‑t tartalmazó cellát ismert numerikus értékként értelmezzük. Hívja meg a [ChartDataCell.setValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setValue) metódust `null`‑gal egy cella üresre állításához. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellás beállítástól.

Használja a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) metódust a diagram üres cellák megjelenítésének módjának kiválasztásához. Ez a beállítás a teljes diagramra vonatkozik, és megváltoztatja, hogyan kerülnek ábrázolásra a hiányzó értékek, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené ki.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, és minden módot külön fájlba ment. Bemeneti fájlra nincs szükség. A [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot használja, az 0‑s oszlop a kategóriacímkéket, az 1‑s oszlop az értékeket, a 0‑s sor pedig a sorozatnevet tartalmazza; a végső adatsor: `10, 20, empty, 30, 40`.

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

    // Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriáját és az adatpontot.
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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és mentse a prezentációt egyszer a módok ciklikus végrehajtása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap a munkafüzetben minden esetben üres:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. Egy vonaldiagram könnyen összehasonlítható mindhárom módot. Sáv‑ és oszlopdiagramok esetén nincs vonal, amely összekötné a hiányzó kategóriát, így a `Span` nem hozhat létre csatlakozó szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlóan nézhet ki. Hasonlóan, egy szórásdiagram csak jelölőkkel nem rendelkezik vonallal. Ne várjon három különböző eredményt minden diagramtípusnál; mindig ellenőrizze a saját típusához tartozó kimenetet.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv‑ vagy oszloptömbök közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) a csoportra. Nagyobb érték nagyobb hézagot eredményez a csoportok között; kisebb érték sűrűbbet helyez el őket.

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

![The gap width](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de sorozataik nem mindegyiknek ugyanaz a struktúrája vagy beállításai. Például a kategória-diagramok kategóriákat és értékeket használnak, a szórásdiagramok X és Y értékeket, a buborékdiagramok pedig méretet is hozzáadnak. Használja a sorozattípusnak megfelelő adatpont‑létrehozó metódust. Az olyan opciók, mint az átfedés és a hézag szélessége csak kompatibilis sáv‑ vagy oszloppcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addChart) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket is törölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés (overload) segítségével diagramot hozhat létre alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, a kategóriacímkék és az adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatépítéskor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat igazított állapotban, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan tudok egy pontot törölni a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`‑ra, így a pont kategória‑pozíciója megmarad üres pontként. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha a teljes sorozatot szeretné eltávolítani. Ha a kategóriákat is törli, frissítse minden sorozatot, hogy az értékek továbbra is a kategória‑gyűjteménnyel legyenek összehangolva.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) beállításától függ. A támogatott diagramok a hiányzó értékeket szünetként, nullaként vagy szomszédos pontok összekapcsolásával jeleníthetik meg. Válassza ki a bemutatásához leginkább illeszkedő beállítást. A teljes példáért és vizuális összehasonlításért lásd a **[Az üres cellák megjelenítésének vezérlése](#control-the-display-of-empty-cells)** szakaszt.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv, oszlop és buborék sorozatok esetén hívja meg a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) által visszaadott színt. Egy egyedi pont viselkedését a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal felülbírálhatja. Ezek a módszerek a formázásra, nem pedig a tárolt numerikus értékekre hatnak.

**Melyik formázás nyer, ha a sorozat és a pont is formázva van?**

Az explicit adatpont‑formázás előnyben részesül az adott pontnál. A többi pont továbbra is a sorozat explicit formázását vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoport‑beállítások, mint az átfedés és a hézag szélessége, a layoutot szabályozzák, és nem pont‑szintű formázási felülbírálásként működnek.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem szab magának különálló, rögzített sorozatszám‑korlátot. Gyakorlatilag a prezentációfájl mérete, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos határt.

**Mit kell módosítanom, ha az oszlopok túl közel vannak egymáshoz vagy túl messze?**

Hívja meg a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a klaszterek közti tér növeléséhez, vagy csökkentse a klasztereket közelebb hozva.