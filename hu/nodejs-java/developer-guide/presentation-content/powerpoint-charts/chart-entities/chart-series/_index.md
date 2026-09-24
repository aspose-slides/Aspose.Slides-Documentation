---
title: Diagram adat sorozatok kezelése előadásokban JavaScript segítségével
linktitle: Adatsorozatok
type: docs
url: /hu/nodejs-java/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- sorozat név
- adatpont
- munka könyv cella
- sorozat hézag
- negatív érték
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkakönyv cellákat, formázást, átfedést, hézag szélességet és negatív értékeket előadásokban JavaScript használatával."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagramadat‑munka könyvben tárolja. A [ChartSeries](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/) egy összefüggő értékkészletet képvisel, és a sorozat minden [ChartDataPoint](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/) egy vagy több munkalap‑cellára hivatkozik. A [ChartCategory](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Ezért a sorozat neve, a kategóriák és a pontértékek a [ChartDataCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként tárolódnak.

Egy tipikus kategória diagram esetén az alapértelmezett munkalap a 0‑s sort használja a sorozatneveknek, a 0‑s oszlopot a kategórianévnek, a maradék cellákat pedig a sorozatértékeknek. A [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/#getCell) metódusnak átadott munkalap, sor és oszlop indexek 0‑alapúak. Ez a felépítés akkor hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Egy betöltött előadás esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkalap értékeit.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például a [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getFormat), amely az adott sorozat összes pontjának alapértelmezett megjelenését biztosítja.
- Adatpont‑szintű beállítások, például a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getFormat), amelyek egy pont megjelenését felülírják a sorozatéval szemben.
- Csoportbeállítások, amelyek kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/) tartoznak. A csoporthoz a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) metódussal férhet hozzá, ha például átfedés vagy részsáv szélesség beállítására van szükség.

Ha nincs explicit pont‑ vagy sorozat‑kitöltés megadva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása elsőbbséget élvez.

![diagram-sor-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

A [ChartSeries.getOverlap](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getOverlap) megadja, hogy a 2D diagram oszlopai vagy sávjai mennyire fedik át egymást, -100‑tól 100 %-ig. Ez csak olvasható érték a szülő sorozatcsoport beállításából. A [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) használatával frissítheti a csoport minden kompatibilis sorozatát. Ez a lehetőség azokban a diagramtípusokban érvényes, amelyek csoportos oszlopokat vagy sávokat jelenítenek meg; kombinált diagramokban a nem kapcsolódó sorozatcsoportokra nincs hatással.

A következő példa az első sorozatot tartalmazó csoport átfedését állítja be:

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

A [ChartSeries.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getFormat) segítségével állítható be egy teljes sorozat alapértelmezett kitöltése. Ha egy pont már rendelkezik explicit kitöltéssel, annak a [ChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getFormat) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa egy egységkék szilárd kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagram adat‑munka könyvben van tárolva, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett, klaszter oszlopdiagramhoz létrehozott munkalapon a B1 cella a 0‑s sorban, 1‑es oszlopban van, és az első sorozat nevét tartalmazza. Az alábbi példában a megnevezett állandók expliciten tükrözik ezt a szerkezetet:

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

A cellát már a [ChartSeries.getName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getName) hivatkozza. Ez a megközelítés elkerüli a konkrét sor‑ és oszlopszám feltételezését egy meglévő diagram esetén:

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

## **Az automatikus sorozat színének lekérdezése**

A [ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor használatos, amikor a sorozat kitöltése nincs explicit módon meghatározva. A metódus meghívása csak a számított színt olvassa, nem állít be új kitöltést.

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

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függenek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Oszlop‑, sáv‑ és buborék‑sorozatok esetén a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) negatív értékekhez másik kitöltést jeleníthet meg. Állítsa be a normál sorozatkitöltést szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) segítségével. A negatív számok a munkalapban változatlanok maradnak; csak a megjelenésük színe változik.

A következő példa az alapértelmezett diagramadatot egy sorozattal helyettesíti. A 0‑s sor tartalmazza a sorozat nevét, az 0‑s oszlop a kategória neveket, az 1‑es oszlop az értékeket:

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

Az invertálás egyetlen pontnál engedélyezhető a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal. Az alábbi példában a sorozatra ki van kapcsolva az invertálás, csak a kiválasztott pontnál van engedélyezve, amelyhez hozzáadtunk egy negatív értéket, hogy a hatás látható legyen:

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

Egy pont üresre állításához, anélkül hogy a többi pontot eltávolítaná, állítsa a mögöttes munkalap‑cellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [ChartDataPoint.getValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#getValue) metódussal érhető el. Az adatpont a kategória pozíciójában marad, de a diagram a beállított „üres érték” szabályok szerint a pontot üresnek tekinti.

A következő példa csak az első sorozat második pontját törli:

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

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méretcellát is. Törölje csak azt a cellát, amely az eltávolítani kívánt értéket tartalmazza. Ne hívja a [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metódust, ha a többi pontot meg akarja tartani, mivel ez a módszer az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének vezérlése**

Egy üres munkalap‑cellát hiányzó adatok jelentenek; egy `0`‑t tartalmazó cella ismert numerikus értéket jelent. Hívja a [ChartDataCell.setValue](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatacell/#setValue) metódust `null`‑val, hogy a cellát üressé tegye. A numerikus nulla továbbra is nulla marad, függetlenül az „üres cella” beállítástól.

Használja a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) metódust, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja, hogyan ábrázolják a hiányzó adatokat, anélkül, hogy a munkalap‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3‑as nap értékét törli, majd minden módnál elmenti ugyanazt a diagramot. Nem szükséges bemeneti fájl. A [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot a kategóriacímkéknek, az 1‑es oszlopot az értékeknek használja; a 0‑s sor a sorozat nevét tartalmazza. A végső adatok: `10, 20, empty, 30, 40`.

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

    // A 3. napot valóban üresen hagyja, miközben megtartja a kategóriát és az adatpontot.
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

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy változatot szeretne menteni, állítsa be a kívánt módot, és egyszer mentse el a prezentációt a módok iterálása helyett.

Az alábbi összehasonlításban ugyanazok az adatok láthatók mindhárom fájlban. A 3‑as nap a munkalapban minden esetben üres:

![Vonaldiagramok azonos adatokkal: Gap megszakítja a vonalat a 3‑as napnál, Zero a vonalat nullához húzza, Span összeköti a 2‑es napot a 4‑essel.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagram esetén a három mód könnyen összehasonlítható. Oszlop‑ és sávdiagramoknál nincs vonal, amely átkötné a hiányzó kategóriát, így a `Span` nem hozhat létre összekötő szegmenst, ahogy a fenti példában látható; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, egy csak jelölőkkel rendelkező szórt diagramnak sincs vonala. Ne várjon három különböző eredményt minden diagramtípusnál; ellenőrizze a kimenetet a saját típusához.

## **A sorozat részsávszélességének beállítása**

A részsávszélesség a szomszédos oszlop‑ vagy sáv‑klaszterek közötti távolságot jelenti, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust egyszer a csoport számára. A nagyobb érték nagyobb távolságot eredményez a klaszterek között; a kisebb érték sűrűbbé teszi őket.

A következő példa módosítja a részsávszélességet, és csak a végső prezentációt menti el:

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

Az összes [ChartType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/charttype/) felsorolt diagramtípus használ diagramadatot, de sorozataik nem mindegyiknek ugyanaz a szerkezete vagy beállításai. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. A sorozattípusnak megfelelő adatpont‑létrehozó módszert kell alkalmazni. Az olyan opciók, mint az átfedés és a részsávszélesség, csak kompatibilis oszlop‑ vagy sáv‑csoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

A [ChartSeriesGroup](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Tartalmaz egy újból létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [ShapeCollection.addChart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/#addChart) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat‑ és kategória‑gyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy overload segítségével diagram létrehozható alapértelmezett adatok nélkül is.

**Hogyan vannak a diagramobjektumok összekapcsolva a munkalap‑cellákkal?**

A sorozatnevek, kategória‑címkék és adatpont‑értékek a [ChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat felépítésekor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat egymáshoz igazítva, hogy minden pont a megfelelő kategória alatt jelenjen meg.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a vonatkozó értékcellát `null`‑ra, hogy a pont kategória‑pozíciója üres pontként maradjon. A [ChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapointcollection/#clear) metódust csak akkor használja, ha minden pontot el akar távolítani a sorozatból. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek továbbra is a kategória‑gyűjteménnyel legyenek összhangban.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) beállításától függ. A támogatott diagramok megjeleníthetik az üresek „részként”, „nullaként” vagy „kapcsolt pontként”. Válassza a hiányzó adatok jelentésének megfelelő beállítást. Lásd: **[Az üres cellák megjelenítésének vezérlése](#control-the-display-of-empty-cells)** a teljes példáért és vizuális összehasonlításért.

**Hogyan formázzák a negatív értékeket?**

A támogatott oszlop‑, sáv‑ és buborék‑sorozatoknál hívja a [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) metódust, és állítsa be a színt, amelyet a [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) visszaad. Egy egyedi pont viselkedését a [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) metódussal felülírhatja. Ezek a módszerek a formázásra hatnak, nem a tárolt numerikus értékekre.

**Melyik formázás nyer, ha a sorozat és egy pont is formázva van?**

Az explicit adatpont‑formázás elsőbbséget élvez az adott pontnál. A többi pont továbbra is a sorozat explicit formázását vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoport‑beállítások, mint az átfedés és a részsávszélesség, a layoutot szabályozzák, nem pont‑szintű formázási felülírások.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem állít be külön, fix sorozatszám‑korlátot. Gyakorlatban a prezentációfájl‑korlátok, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a használható felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Hívja a [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a klaszterek közti távolság növeléséhez, vagy csökkentse, ha szorítania kell a klasztereket.