---
title: Diagramok létrehozása vagy frissítése PowerPoint prezentációkban JavaScriptben
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/nodejs-java/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szórt diagram
- kördiagram
- vonaldiagram
- fátérkép diagram
- részvénydiagram
- doboz és bajusz diagram
- tölcsér diagram
- napkitörés diagram
- hisztogram diagram
- radar diagram
- többcsoportos diagram
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Node.js via Java segítségével. Diagramok hozzáadása, formázása és szerkesztése gyakorlati JavaScript kódrészletekkel."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt arról, hogyan hozhatók létre és testreszabhatók diagramok az Aspose.Slides for Node.js via Java használatával. Megtanulhatja, hogyan adhat programból diagramot egy diára, hogyan töltheti fel adatokka­l, és hogyan alkalmazhat különböző formázási beállításokat a specifikus tervezési követelményeknek megfelelően. A cikk során részletes kódrészletek szemléltetik minden lépést, a prezentáció és a diagramobjektum inicializálásától a sorozatok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével szilárd megértést szerez a dinamikus diagramgenerálás integrálásáról Node.js alkalmazásaiba, ezzel egyszerűsítve az adat‑alapú prezentációk létrehozásának folyamatát.

## **Diagram létrehozása**

Diagramok segítik az embereket az adatok gyors megjelenítésében és olyan betekintések szerzésében, amelyek egy táblázatból vagy munkafüzetből nem feltétlenül nyílnak fel azonnal.

**Miért készítsünk diagramokat?**

* nagy mennyiségű adat aggregálása, sűrítése vagy összefoglalása egyetlen dián a prezentációban;
* minták és trendek feltárása az adatokban;
* meghatározni az adatok irányát és lendületét az időben vagy egy meghatározott mértékegységhez képest;
* kijelölni kiugró értékeket, eltéréseket, hibákat és értelmetlen adatokat;
* komplex adatok közvetítése vagy bemutatása.

A PowerPointban a diagramokat az *Insert* (Beszúrás) funkcióval hozhatja létre, amely számos diagramtípus sablonját biztosítja. Az Aspose.Slides használatával mind szabványos diagramok (népszerű diagramtípusokon alapuló), mind egyedi diagramok hozhatók létre.

{{% alert color="info" title="Note" %}}
Használja a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) felsorolást a [aspose.slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) modulban. Ennek a felsorolásnak az értékei különböző diagramtípusoknak felelnek meg.
{{% /alert %}}

### **Csoportosított oszlopdiagramok létrehozása**

Ez a példa a [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) használatával hoz létre egy csoportosított oszlopdiagramot, amely két sorozatot hasonlít össze három kategóriában. A sorozatok piros és zöld kitöltést használnak, és az egyedi címkék a kategória neveket, sorozat neveket és értékeket mutatják. A 0. munkalap index az beágyazott diagram‑munkafüzet első lapjára hivatkozik.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().get_Item(0);

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    series = chart.getChartData().getSeries().get_Item(1);

    valueCell = workbook.getCell(worksheetIndex, 1, 2, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));

    let label = series.getDataPoints().get_Item(0).getLabel();
    label.getDataLabelFormat().setShowCategoryName(true);

    label = series.getDataPoints().get_Item(1).getLabel();
    label.getDataLabelFormat().setShowSeriesName(true);

    label = series.getDataPoints().get_Item(2).getLabel();
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setShowSeriesName(true);
    label.getDataLabelFormat().setSeparator("/");

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A csoportosított oszlop diagram](clustered_column_chart.png)

### **Szórásdiagramok létrehozása**

A szórásdiagramok (más néven szórási ábrák vagy x‑y grafikonok) gyakran használatosak minták ellenőrzésére vagy két változó közötti korrelációk bemutatására.

**Szórásdiagram használata akkor, ha:**

* Páros numerikus adatok állnak rendelkezésére.
* Két olyan változója van, amely jól párosítható.
* Meg szeretné határozni, hogy a két változó összefügg-e.
* Van egy független változó, amely több értékkel rendelkezik egy függő változóhoz.

Ez a példa két x‑y értékkészletet ábrázol. Az első sorozat egyenes vonalakat használ csillag‑markerrel, míg a második sima vonalakat kör‑markerrel; mindkettő 10‑es markermérettel rendelkezik, amit a [setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/marker/setsize/) segítségével állítottunk be. A [setSymbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/marker/setsymbol/) metódus a marker alakját vezérli.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();

    let seriesNameCell = workbook.getCell(worksheetIndex, 1, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 1, 3, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let series = chart.getChartData().getSeries().get_Item(0);

    let xValueCell = workbook.getCell(worksheetIndex, 2, 1, 1);
    let yValueCell = workbook.getCell(worksheetIndex, 2, 2, 3);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 1, 2);
    yValueCell = workbook.getCell(worksheetIndex, 3, 2, 10);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);

    series = chart.getChartData().getSeries().get_Item(1);

    xValueCell = workbook.getCell(worksheetIndex, 2, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 2, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 3, 3);
    yValueCell = workbook.getCell(worksheetIndex, 3, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 4, 3, 2);
    yValueCell = workbook.getCell(worksheetIndex, 4, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 5, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 5, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A szórás diagram](scatter_chart.png)

### **Kördiagramok létrehozása**

A kördiagramok leginkább a rész‑egész kapcsolat ábrázolására alkalmasak, különösen ha az adatok kategóriákat és numerikus értékeket tartalmaznak. Ha azonban az adat sok részt vagy címkét tartalmaz, érdemes inkább oszlopdiagramot használni.

Ez a példa egy kördiagramot hoz létre három negyedéves értékkel. Minden szelet egyedi kitöltéssel és szegéllyel rendelkezik, a címkék pedig különböző kombinációkat mutatnak az értékekből, százalékokból és sorozatinformációkból. A [setFirstSliceAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) metódus az első szeletet 180 foknál kezdi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let categoryCell = workbook.getCell(0, 1, 0, "1st Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "2nd Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "3rd Qtr");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForPieSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);

    let firstSlice = series.getDataPoints().get_Item(0);
    firstSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstSlice.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    firstSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    firstSlice.getFormat().getLine().setWidth(3.0);
    firstSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    firstSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDash));

    let secondSlice = series.getDataPoints().get_Item(1);
    secondSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlice.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));

    secondSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    secondSlice.getFormat().getLine().setWidth(3.0);
    secondSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    secondSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));

    let thirdSlice = series.getDataPoints().get_Item(2);
    thirdSlice.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlice.getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 127, 80));

    thirdSlice.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    thirdSlice.getFormat().getLine().setWidth(2.0);
    thirdSlice.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    thirdSlice.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));

    let firstLabel = series.getDataPoints().get_Item(0).getLabel();
    firstLabel.getDataLabelFormat().setShowValue(true);

    let secondLabel = series.getDataPoints().get_Item(1).getLabel();
    secondLabel.getDataLabelFormat().setShowValue(true);
    secondLabel.getDataLabelFormat().setShowLegendKey(true);
    secondLabel.getDataLabelFormat().setShowPercentage(true);

    let thirdLabel = series.getDataPoints().get_Item(2).getLabel();
    thirdLabel.getDataLabelFormat().setShowSeriesName(true);
    thirdLabel.getDataLabelFormat().setShowPercentage(true);

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);

    presentation.save("PieChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A kördiagram](pie_chart.png)

A körön kívüli címkék olvashatóságának javításához lásd a [Formátum vezető vonalak](/slides/hu/nodejs-java/chart-data-label/#format-leader-lines) példát, amely a címkék pozicionálását és a vonalak színének, szélességének, átlátszóságának és vonaltípusának testreszabását mutatja be.

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább olyan helyzetekben használandók, ahol az értékek időbeli változását szeretné bemutatni. Egy vonaldiagram segítségével egyszerre nagy mennyiségű adatot hasonlíthat össze, nyomon követheti az időbeli változásokat és trendeket, kiemelheti a sorozatok anomáliáit, és még sok mást.

Ez a példa a [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) használatával hoz létre egy vonaldiagramot az alapértelmezett sorozatokkal és kategóriákkal, majd PPTX‑ként menti a prezentációt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let lineChart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 20, 20, 500, 300);

    presentation.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Alapértelmezés szerint a vonaldiagram pontjait egyenes folytonos vonalak kötik össze. Ha a pontokat szaggatott vonalakkal szeretné összekötni, hívd meg a [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) metódust a [LineDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) egyik értékével:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let lineChart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 20, 20, 500, 300);

    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++)
    {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A vonaldiagram](line_chart.png)

### **Fátérkép diagramok létrehozása**

A fátérkép diagramok leginkább értékesítési adatoknál hasznosak, amikor a kategóriák relatív méretét és a nagy hozzájárulók gyors kiemelését szeretné megjeleníteni.

Ez a példa egy fátérképet hoz létre nyolc levéllel, négy szárra és két ágra csoportosítva. A [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) metódus a 1. szintű csoportosításnál a szárakat, a 2. szintnél pedig az ágakat rendeli hozzá. Az értékek határozzák meg a relatív téglalapméreteket, a kategória‑címkék és a felülülütköző szülőcímkék pedig az hierarchiát mutatják.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Treemap, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Ág 1
    let categoryCell = workbook.getCell(0, "C1", "Leaf1");
    let leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Ág 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    let valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);

    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);

    presentation.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A fátérkép diagram](treemap_chart.png)

### **Vízözön diagramok létrehozása**

A vízözön diagram azt mutatja, hogyan járulnak hozzá a pozitív és negatív változások a végső értékhez. Például egy nyereség‑szétesés kezdődhet a bevétellel, levonja a költségeket, majd hozzáadja a többletbevételt. A változásos oszlopok az előző és az új futóértékek között lebegnek, míg a teljes oszlopok a nullától a felhalmozott értékig terjednek.

Az alábbi példa ezrek amerikai dollárban kifejezett összegeket használ:

| Kategória | Munkafüzet érték | Oszlop típusa |
| --- | ---: | --- |
| Bevétel | 1000 | Növekedés |
| Értékesítési költség | -400 | Csökkenés |
| Bruttó nyereség | 600 | Közbenső összeg |
| Működési költségek | -200 | Csökkenés |
| Egyéb bevétel | 50 | Növekedés |
| Nettó nyereség | 450 | Végösszeg |

Egy pont közbenső vagy végösszegként való megjelöléséhez hívd meg a [setSetAsTotal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setsetastotal/) metódust `true`‑val. A ponthoz tartozó munkafüzet‑cellában add meg a tényleges felhalmozott összeget: `600` a bruttó nyereséghez (`1000 - 400`) és `450` a nettó nyereséghez (`600 - 200 + 50`). A metódus csak a oszlopot jelöli meg összegként, nem számolja ki vagy tölti fel a cella‑értéket. Ne használj nullát helykitöltőként, és ne adj meg más változást egy összegpontnál. A teljes oszlop a felhalmozott értéket jeleníti meg anélkül, hogy újra hozzáadná a futóértékhez.

Ez a teljes JavaScript példa a `Waterfall` elemet a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/)‑ból használja, törli az alapértelmezett adatokat, és feltölti a beágyazott munkafüzetet. A `0`‑ás munkalap‑index az első munkalapot választja; az A oszlop a kategória neveket, a B oszlop az értékeket tartalmazza. Minden értékcellát a [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/)‑zel adunk hozzá. A `2` és `5`‑ös null‑alapú pont‑indexek az közbenső és a végösszegeket azonosítják. A [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) `true`‑val hívva megjeleníti az összegeket az oszlopokon. Bemutató‑prezentációra vagy munkafüzetre nincs szükség.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Waterfall, 20, 20, 680, 200);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)");
    chart.getChartTitle().setOverlay(false);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    workbook.clear(worksheetIndex);

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Profit");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Waterfall);
    let categories = [ "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" ];
    let values = [ 1000, -400, 600, -200, 50, 450 ];

    for (let i = 0; i < categories.length; i++)
    {
        let categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categories[i]);
        chart.getChartData().getCategories().add(categoryCell);
        let valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForWaterfallSeries(valueCell);
    }

    // A harmadik és a hatodik pont összegként jelenik meg, nem további változásként.
    series.getDataPoints().get_Item(2).setSetAsTotal(true);
    series.getDataPoints().get_Item(5).setSetAsTotal(true);
    series.setShowConnectorLines(true);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("WaterfallChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

A sorozatszintű [setShowConnectorLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setshowconnectorlines/) metódust `true`‑ra állítva megjelennek a szomszédos oszlopokat összekötő vonalak, ami könnyebbé teszi a futóérték követését. Ezeknek a vonalaknak a elrejtéséhez cseréld le a példában a metódushívást `series.setShowConnectorLines(false);`‑re a mentés előtt. Ez csak a vonalak láthatóságát változtatja, az adatokat vagy az összegpontokat nem.

A mentett prezentáció a 600‑as bruttó nyereséget és a 450‑as nettó nyereséget mutatja, mindkét összeg a nullától indul:

![Vízözön diagram, amely a 600-as bruttó nyereséget és a 450-es nettó nyereséget, valamint a bevételt és költségeket mutatja, értékcímkékkel és csatlakozó vonalakkal](waterfall_chart.png)

### **Részvénydiagramok létrehozása**

A részvénydiagramok a nyitási, legmagasabb, legalacsonyabb és záró árak megjelenítésére szolgálnak, segítve a piaci trendek és a volatilitás elemzését. Alapvető betekintést nyújtanak a részvény teljesítményébe, támogatva a befektetőket és elemzőket a megalapozott döntéshozatalban.

Ez a példa egy nyitás‑magas‑magas‑zár (OHLC) diagramot hoz létre négy sorozattal ebben a sorrendben és három kategóriával. A [setUpDownBars](https://reference.aspose.com/slides/nodejs-java/aspose.slides/updownbarsmanager/setupdownbars/) metódus engedélyezi a fel‑/le‑oszlopokat, a [getHiLowLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) pedig a magas‑alacsony vonalakat szabályozza, míg az egyes sorozat‑vonalak és a kisebb vízszintes rácsvonalak rejtve maradnak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    let workbook = chart.getChartData().getChartDataWorkbook();

    let categoryCell = workbook.getCell(0, 1, 0, "A");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "B");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "C");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, 0, 1, "Open");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 2, "High");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 3, "Low");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 4, "Close");
    chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.OpenHighLowClose);

    let series = chart.getChartData().getSeries().get_Item(0);
    let valueCell = workbook.getCell(0, 1, 1, 72);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 1, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 1, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(1);
    valueCell = workbook.getCell(0, 1, 2, 172);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(2);
    valueCell = workbook.getCell(0, 1, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 3, 13);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(3);
    valueCell = workbook.getCell(0, 1, 4, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 4, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 4, 50);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        let stockSeries = chart.getChartData().getSeries().get_Item(i);
        stockSeries.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    presentation.save("Stock-chart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A részvénydiagram](stock_chart.png)

### **Doboz‑ és bajusz diagramok létrehozása**

A doboz‑ és bajusz diagramok az adatok eloszlását jelenítik meg kulcsfontosságú statisztikai mérőszámok, például a medián, kvartilisek és lehetséges kiugró értékek összefoglalásával. Különösen hasznosak felderítő adat‑analízisekben és statisztikai vizsgálatokban a változatosság gyors megértéséhez és az anomáliák azonosításához.

Ez a példa hat értékből hoz létre egy doboz‑ és bajusz diagramot. A [setQuartileMethod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setquartilemethod/) metódus az exkluzív kvartilis‑számítást választja. A példa engedélyezi az átlag‑vonalakat, átlag‑marker‑eket, belső‑pontokat és kiugró‑pontokat is.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);

    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    let valueCell = workbook.getCell(0, "B1", 15);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 41);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 10);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 23);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);

    presentation.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

### **Tölcsér diagramok létrehozása**

A tölcsér diagramok a folyamatok szekvenciális szakaszainak vizualizálására szolgálnak, ahol az adat mennyisége csökken a lépésről lépésre haladva. Különösen hasznosak a konverziós arányok elemzéséhez, az akadályok azonosításához és a értékesítési vagy marketing folyamatok hatékonyságának nyomon követéséhez.

Ez a példa a [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) használatával ad egy tölcsér diagramot egy meglévő prezentáció első diájához. Lecseréli az alapértelmezett adatokat hat kategóriára és 50‑től 500‑ig terjedő értékekre, majd menti a frissített prezentációt. A bemeneti prezentációnak legalább egy diát kell tartalmaznia.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("test.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);

    let valueCell = workbook.getCell(0, "B1", 50);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 100);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 200);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 300);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 400);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 500);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);

    presentation.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A tölcsér diagram](funnel_chart.png)

### **Napkitörés diagramok létrehozása**

A napkitörés diagramok a hierarchikus adatokat ábrázolják, a szinteket koncentrikus gyűrűként jelenítik meg. Segítenek bemutatni a rész‑egész összefüggéseket, és ideálisak beágyazott kategóriák és alkategóriák világos, kompakt megjelenítésére.

Ez a példa egy napkitörés diagramot hoz létre nyolc levéllel, négy szárra és két ágra csoportosítva. A [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) metódus a 1. szintű csoportosításnál a szárakat, a 2. szintnél pedig az ágakat rendeli hozzá. A kategória‑címkék az egyes szegmenseket azonosítják, az értékek pedig a relatív méreteket határozzák meg.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Sunburst, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Ág 1
    let categoryCell = workbook.getCell(0, "C1", "Leaf1");
    let leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // Ág 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    let valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);

    presentation.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A napkitörés diagram](sunburst_chart.png)

### **Hisztogram diagramok létrehozása**

A hisztogram diagramok azt mutatják, hogyan oszlanak el a numerikus értékek intervallumok (bin‑ek) között. Havi jelentésekhez, például a megrendelési feldolgozási időkhöz, használj egységes bin‑szélességet és küszöbértékeket, hogy az intervallumok konzisztensék legyenek, és az eloszlások összehasonlíthatók legyenek.

Hívd meg a [setAggregationType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setaggregationtype/) függvényt a vízszintes tengelyen a [AxisAggregationType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axisaggregationtype/) egyik módjával. A [setBinWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setbinwidth/) csak a `ByBinWidth` esetén alkalmazható; a [setNumberOfBins](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberofbins/) csak a `ByNumberOfBins` esetén. Az `Automatic` lehetőséggel a diagram maga választja ki a bin‑eket.

#### **Fix szélességű bin használata**

Ez a példa a feldolgozási időket 10 perces intervallumokra csoportosítja, külön bin‑ekkel a 10 percnél vagy annál kevesebb, illetve a 40 percnél több időkre. Ezeket a bin‑eket a [setUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setunderflowbin/) és a [setOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setoverflowbin/) engedélyezi. Ha explicit küszöbértékeket adsz meg a [setUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setunderflowbin/) és a [setOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setoverflowbin/) segítségével, hívd meg a [setAutomaticUnderflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticunderflowbin/) és a [setAutomaticOverflowBin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticoverflowbin/) metódusokat `false`‑ra.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
    let values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for (let i = 0; i < values.length; i++)
    {
        let valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    let axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(aspose.slides.AxisAggregationType.ByBinWidth);
    axis.setBinWidth(10);
    axis.setUnderflowBin(true);
    axis.setAutomaticUnderflowBin(false);
    axis.setUnderflowBin(10);
    axis.setOverflowBin(true);
    axis.setAutomaticOverflowBin(false);
    axis.setOverflowBin(40);

    presentation.save("Histogram-bin-width.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

A PowerPointban megjelenő prezentáció **3, 4, 4, 4, és 2** értékű bin‑számot mutat. Az alul‑bin tartalmazza a `5, 10, 10` értékeket, ezért a küszöb inkluzív; a felül‑bin csak a `41, 50` értékeket tartalmazza, így a küszöb exkluzív, a `40`‑es értékek az előző intervallumban maradnak. A belső bin‑ek a saját alsó határuknál nagyobb, a felső határuknál kisebb vagy egyenlő értékeket tartalmazzák.

![Hisztogram 10 perces bin‑ekkel és explicit alul‑ és felül‑küszöbökkel](histogram_bin_width.png)

#### **Adja meg a bin-ek számát**

Ha a részletesség szintjét akarja rögzíteni a fix intervallumok helyett, kérjen öt bin‑t ugyanarra az adatra. Ez a példa a alul‑ és felül‑bin‑eket letiltja. A diagram a szélességet az adat‑tartományból számítja, így a határok jelentések között változhatnak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
    let values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for (let i = 0; i < values.length; i++)
    {
        let valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    let axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(aspose.slides.AxisAggregationType.ByNumberOfBins);
    axis.setNumberOfBins(5);

    presentation.save("Histogram-bin-count.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az öt bin **4, 4, 4, 4, és 1** értéket tartalmaz. Hasonlítsa össze ezt az eloszlást a fenti fix‑szélességű eredménnyel: a bemeneti értékek azonosak, de a határok eltérnek.

![Hisztogram öt bin‑nel, amely ugyanazból az adatból számított](histogram_bin_count.png)

### **Radar diagramok létrehozása**

A radar diagramok többváltozós adatokat jelenítenek meg kétdimenziós formában, lehetővé téve több változó egyidejű összehasonlítását. Különösen hasznosak minták, erősségek és gyengeségek azonosításához több teljesítménymutató vagy attribútum esetén.

Ez a példa a [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) használatával hoz létre egy radar diagramot az alapértelmezett sorozatokkal és kategóriákkal, majd PPTX‑ként menti a prezentációt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 500, 300);

    presentation.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A radar diagram](radar_chart.png)

### **Többcsoportos diagramok létrehozása**

A többcsoportos diagramok több kategória‑csoportot jelenítenek meg egyszerre, lehetővé téve az értékek több dimenzióban történő egyidejű összehasonlítását. Különösen hasznosak komplex, több szintű adatbázisok trendjeinek és összefüggéseinek elemzéséhez.

Ez a példa egy csoportosított oszlopdiagramot hoz létre nyolc kategóriával, négy párban rendezve. A [setGroupingItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) metódus minden párnak közös címkét ad az 1. szintű csoportosításnál, így a kategóriatengely egyéni és csoportcímkéket egyaránt tartalmaz.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    let worksheetIndex = 0;

    let categoryCell = workbook.getCell(0, "c2", "A");
    let category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    categoryCell = workbook.getCell(0, "c3", "B");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c4", "C");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    categoryCell = workbook.getCell(0, "c5", "D");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c6", "E");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    categoryCell = workbook.getCell(0, "c7", "F");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c8", "G");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    categoryCell = workbook.getCell(0, "c9", "H");
    category = chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(0, "D1", "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    let valueCell = workbook.getCell(worksheetIndex, "D2", 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D3", 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D4", 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D5", 40);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D6", 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D7", 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D8", 70);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D9", 80);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    presentation.save("AsposeChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A többcsoportos diagram](multi_category_chart.png)

### **Térképi diagramok létrehozása**

A térképi diagramok földrajzi adatokat jelenítenek meg úgy, hogy az információkat konkrét helyekhez (országok, államok, városok) rendelik. Különösen hasznosak regionális trendek, demográfiai adatok és térbeli eloszlások elemzéséhez vizuálisan vonzó módon.

Ez a példa a [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) használatával hoz létre egy térképi diagramot az alapértelmezett földrajzi adatokkal, és menti a PowerPointban való megtekintéshez.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.Map, 20, 20, 500, 300);

    presentation.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

Az eredmény:

![A térképi diagram](map_chart.png)

{{% alert color="info" title="Note" %}}
A fenti kép a mentett prezentációt mutatja megnyitva a PowerPointban. Az Aspose.Slides helyesen írja a térképi diagramot és annak adatait, de magát a térképi diagramot nem rajzolja meg: amikor egy diát, amely ilyen diagramot tartalmaz, képre renderel vagy PDF‑‑re, SVG‑re konvertál, a diagram területe üres marad. A többi alakzat ugyanazon a dián érintetlen marad.
{{% /alert %}}

### **Kombinációs diagramok létrehozása**

A kombinációs diagram (vagy combo diagram) több diagramtípust egyesít egyetlen grafikonba. Ez a diagram lehetővé teszi, hogy kiemeljünk, összehasonlítsunk vagy vizsgáljunk különbségeket két vagy több adathalmaz között, segítve ezzel a köztük lévő kapcsolatok felismerését.

![A kombinációs diagram](combination_chart.png)

Ez a példa két csoportosított oszlop sorozatot kombinál egy vonal sorozattal négy kategórián keresztül. Az oszlopok az elsődleges függőleges tengelyt használják, míg a [setPlotOnSecondAxis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setplotonsecondaxis/) a vonalat a jobb oldalon lévő másodlagos függőleges tengelyre helyezi. A segédfüggvények konfigurálják a címet, a jelmagyarázatot, a tengelycímkéket és a rácsvonalakat.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function createComboChart()
{
    let presentation = new aspose.slides.Presentation();
    try
    {
        let chart = createChartWithFirstSeries(presentation.getSlides().get_Item(0));

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    }
    finally
    {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide)
{
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let portionFormat = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    portionFormat.setFontHeight(18);

    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 4, 0, "Category 4");
    chart.getChartData().getCategories().add(categoryCell);

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    let valueCell = workbook.getCell(worksheetIndex, 1, 1, 4.3);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 2.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 3.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 1, 4.5);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    return chart;
}

function addSecondSeriesToChart(chart)
{
    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    let valueCell = workbook.getCell(worksheetIndex, 1, 2, 2.4);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 4.4);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 1.8);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 2, 2.8);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
}

function addThirdSeriesToChart(chart)
{
    let workbook = chart.getChartData().getChartDataWorkbook();
    let worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    let valueCell = workbook.getCell(worksheetIndex, 1, 3, 2.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 3, 2.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 3, 3.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 4, 3, 5.0);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart)
{
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart)
{
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle)
{
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titlePortionFormat = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    titlePortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titlePortionFormat.setFontHeight(12);
}

createComboChart();
```

## **Diagramok frissítése**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy a PowerPoint diagramokat frissítse a diagramadatok, formázás és stílus módosításával. Ez a funkció leegyszerűsíti a prezentációk dinamikus tartalommal való naprakészen tartását, és biztosítja, hogy a diagramok pontosan tükrözzék a jelenlegi adatokat és vizuális szabványokat.

Ez a példa frissíti a „My chart” nevű diagramot az első dián egy meglévő prezentációban. Két oszlop sorozatot igényel, mindkettő három adatponttal, a kategória‑címkék az A oszlopban, a sorozat‑nevek az első munkalap első sorában vannak. A példa a [getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) használatával módosítja a munkafüzet‑cellákat, frissíti a sorozat‑értékeket, hozzáad egy harmadik sorozatot, és a diagramot csoportosított hengerekké (clustered cylinders) alakítja a [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/settype/) segítségével.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let chartName = "My chart";

let presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++)
    {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart") && chartName === shape.getName())
        {
            let chart = shape;
            let worksheetIndex = 0;

            let workbook = chart.getChartData().getChartDataWorkbook();

            workbook.getCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.getCell(worksheetIndex, 2, 0, "Modified Category 2");

            let series = chart.getChartData().getSeries().get_Item(0);

            workbook.getCell(worksheetIndex, 0, 1, "New_Series 1");
            series.getDataPoints().get_Item(0).getValue().setData(90);
            series.getDataPoints().get_Item(1).getValue().setData(123);
            series.getDataPoints().get_Item(2).getValue().setData(44);

            series = chart.getChartData().getSeries().get_Item(1);

            workbook.getCell(worksheetIndex, 0, 2, "New_Series 2");
            series.getDataPoints().get_Item(0).getValue().setData(23);
            series.getDataPoints().get_Item(1).getValue().setData(67);
            series.getDataPoints().get_Item(2).getValue().setData(99);

            let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
            series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

            let valueCell = workbook.getCell(worksheetIndex, 1, 3, 20);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 2, 3, 50);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 3, 3, 30);
            series.getDataPoints().addDataPointForBarSeries(valueCell);

            chart.setType(aspose.slides.ChartType.ClusteredCylinder);
        }
    }

    presentation.save("AsposeChartModified.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Adattartomány beállítása egy diagramhoz**

A diagram adat‑tartományának lekérése: lásd a [Diagram adat-tartományának lekérése](/slides/hu/nodejs-java/chart-workbook/#retrieve-a-charts-data-range) oldalt.

Az Aspose.Slides for Node.js via Java rugalmasságot biztosít egy adott munkalap‑adat‑tartomány meghatározásához, amely a diagram adatforrásaként szolgál. Ez azt jelenti, hogy közvetlenül leképezhet egy munkalap‑részletet a diagramra, így szabályozhatja, mely cellák járulnak hozzá a diagram sorozataihoz és kategóriáihoz. Ennek eredményeként könnyen frissítheti és szinkronizálhatja diagramjait a munkalap legújabb adatváltozásaival, biztosítva, hogy a PowerPoint‑prezentációk aktuális és pontos információkat tükrözzenek.

Ez a példa a [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) használatával állítja be a „My chart” nevű diagram adatforrását egy meglévő prezentáció első diáján a `Sheet1!A1:B4` tartományra. A diagram‑munkafüzetnek tartalmaznia kell azt a munkalapot, valamint egy feltöltött tartományt, ahol az első sorban a sorozat‑fejléc, az A oszlopban a kategória‑címkék, a B oszlopban pedig három érték szerepel.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let chartName = "My chart";

let presentation = new aspose.slides.Presentation("ExistingChart.pptx");
try
{
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++)
    {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart") && chartName === shape.getName())
        {
            let chart = shape;
            chart.getChartData().setRange("Sheet1!A1:B4");
        }
    }

    presentation.save("SetDataRange.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **Alapértelmezett markerek használata diagramokban**

Alapértelmezett markerek használatakor minden diagram‑sorozat automatikusan más‑más alapértelmezett marker‑szimbólumot kap.

Ez a példa a [addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) használatával hoz létre egy diagramot két vonal‑sorozattal és egy jelmagyarázattal. A [getMarker](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getmarker/)‑on keresztül elérhető marker‑beállítások megtartják az automatikusan hozzárendelt marker‑szimbólumokat. Az első sorozat negatív és hiányzó értéket tartalmaz (`null`), míg a második minden kategóriához értéket ad.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try
{
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    let workbook = chart.getChartData().getChartDataWorkbook();

    let seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    let categoryCell = workbook.getCell(0, 1, 0, "C1");
    chart.getChartData().getCategories().add(categoryCell);
    let valueCell = workbook.getCell(0, 1, 1, 24);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 2, 0, "C2");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 2, 1, 23);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 3, 0, "C3");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 3, 1, -10);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 4, 0, "C4");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 4, 1, null);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    seriesNameCell = workbook.getCell(0, 0, 2, "Series 2");
    let secondSeries = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    valueCell = workbook.getCell(0, 1, 2, 30);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 10);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 60);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 4, 2, 40);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    presentation.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **GYIK**

**Milyen diagramtípusokat támogat az Aspose.Slides for Node.js via Java?**

Az Aspose.Slides for Node.js via Java számos diagramtípust támogat, többek között oszlop, vonal, kör, terület, szórás, hisztogram, radar és még sok más. Ez a rugalmasság lehetővé teszi, hogy a legalkalmasabb diagramtípust válassza adatvizualizációs igényeihez.

**Hogyan adhatok új diagramot egy diára?**

Új diagram hozzáadásához először egy példányt hoz létre a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztályból, lekéri a kívánt diát az indexe alapján, majd meghívja a diagram hozzáadására szolgáló metódust, megadva a diagramtípust és a kezdeti adatokat. Ez a folyamat közvetlenül a prezentációba integrálja a diagramot.

**Hogyan frissíthetem egy diagramon megjelenő adatokat?**

Frissítheti egy diagram adatát a [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) elérésével, törölve az alapértelmezett sorozatokat és kategóriákat, majd hozzáadva a saját adatait. Ez lehetővé teszi, hogy programból frissítse a diagramot a legújabb adatokkal.

**Lehetséges-e a diagram megjelenésének testreszabása?**

Igen, az Aspose.Slides for Node.js via Java kiterjedt testreszabási lehetőségeket biztosít. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb formázási elemeket, hogy a diagram megjelenését a specifikus tervezési követelményeknek megfelelően alakítsa.