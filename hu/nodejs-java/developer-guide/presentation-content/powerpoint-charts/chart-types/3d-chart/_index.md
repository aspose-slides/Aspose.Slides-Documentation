---
title: 3D diagramok testreszabása prezentációkban JavaScript használatával
linktitle: 3D diagram
type: docs
url: /hu/nodejs-java/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Készítsen 3D diagramokat PowerPoint prezentációkban az Aspose.Slides for Node.js via Java segítségével. Állítsa be a forgást, a magasság arányait, a diagram mélységét és a sorozatok közötti távolságot JavaScript példákkal."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy a 3D diagram nézetét testre szabja a [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) metódus segítségével. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasság arányai, a mélység, a derékszögű tengelyek és a sorok közötti távolság, majd menthető a bemutató PPTX formátumban.

## **A 3D diagram forgatásának és mélységének beállítása**

Az alábbi példa egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) objektumot hoz létre, és a [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) segítségével hozzáad egy rétegezett 3D oszlopdiagramot az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két, három értéket tartalmazó sorozatra. A `0` munkalap-index a diagram első adatmunkalapját jelöli; a `0` sor a sorozatneveket, az `0` oszlop pedig a kategória címkéket tartalmazza.

A [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) és a [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) metódusok beállítják a diagram forgását 40 és 270 fokra. A [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) a mélységet a szélesség 150%-ára állítja, míg a [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) derékszögű tengelyeket aktivál a perspektíva helyett. Az eredményül kapott bemutató tartalmazza a kitöltött diagramot ezekkel a 3D nézeti beállításokkal.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A 3D diagram magasságarányának módosítása**

Használja a [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) metódust, hogy a 3D diagram magasságát a szélesség százalékában állítsa be. Ez módosítja a 3D jelenet arányait anélkül, hogy átméretezné a diagram objektumot a dián.

A következő példa egy [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) diagramot hoz létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50%, 100% és 200% magasságarányokkal. A diagram pozíciója, szélessége és magassága rögzített marad. Az adatok, forgatás, mélység, sorozatok közötti távolság és formázás az összes fájlban azonos; csak a magasság százalékos értéke változik.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Az alábbi képek ugyanazt a magasságbeállítást mutatják be a megfelelő .NET példában, és a Microsoft PowerPoint segítségével exportálták őket. Egy kisebb százalék laposabb jelenetet eredményez, míg egy nagyobb százalék magasabb jelenetet a diagram objektumon belül. A PowerPoint a tengelyjelölések intervallumát és a címkék elhelyezését is módosíthatja a jelenethez igazítva.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50%-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100%-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200%-a](height_percent_200.png) |

Az alábbi módszerek a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | A 3D jelenet magassága a szélesség százalékában. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | A diagram objektum magassága a dián, pontokban. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | A 3D jelenet mélysége a szélesség százalékában. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | A sorozatok közötti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |

A magasság beállítása a 3D oszlop- és oszlopdiagramokra is hat, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal-, terület-, kör- és felületdiagramokat. A fenti összehasonlításban a hitelesített `Column3D` típust használjuk. A beállítás nem változtatja meg egy 2D `ClusteredColumn` diagram vagy egy `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) osztály tagjai. Egyéb diagrammegjelenítési beállításokért lásd a [Chart Formatting](/slides/hu/nodejs-java/chart-formatting/) oldalt.

## **A sorozatok közötti hézag módosítása**

Használja a [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) metódust, hogy a 3D diagram mélységi tengelyén a sorozatok közötti távolságot a jelölő szélességének százalékában szabályozza. Az értékek **0‑tól 500‑ig** terjednek, beleértve: a `0` eltávolítja a hézagot, a nagyobb értékek pedig növelik a távolságot. Rögzített diagrammélység esetén a hézag növelése vékonyabbá teszi a jelölőket a mélységi tengelyen.

Elérheti a csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) segítségével. A beállítás a csoport minden sorozatára vonatkozik, nem csak arra a sorozatra, amelyen keresztül hozzáfértünk. A [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) visszaadja a mélységi hézagot és tükrözi a szülőcsoport beállítását.

A beállítás a 3D oszlop- és oszlopdiagramokra hat, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal- és területdiagramokra. A megjelenés attól függ, hogy a sorozatok mélység szerint, csoportosan vagy rétegezve vannak-e elrendezve. A különálló sorozatok közötti hézagok egyértelmű összehasonlításához használja a `ChartType.Column3D`-t a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) osztályból.

Az alábbi módszerek a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | A sorozatok közötti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | A szomszédos oszlop vagy sávcsoportok közötti távolság, a sáv vagy oszlop szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | A diagram teljes mélysége, a diagram szélességének százalékában. |

A következő önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót ment azonos adatokkal, forgatással, hézag szélességgel és diagrammélységgel; csak a hézag mélysége változik.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Az alábbi képek ugyanazt a hézagmélység beállítást mutatják be a megfelelő .NET példában, és a Microsoft PowerPoint segítségével lettek exportálva.

| Hézagmélység: 0% | Hézagmélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs hézag a sorozatok között a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500 százalékos hézagja van a sorozatok között a mélységi tengelyen](gap_depth_500.png) |

## **A 3D sorozattípus és oszlopforma módosítása**

Egy csoportos henger diagram esetén az első sorozat a hengeres oszlopformával kezdődik. A példa kiírja a [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) és a [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) által visszaadott egész értékeket minden módosítás előtt és után. A táblázatban a megfelelő állandóneveket szerepelteti.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| A változtatás az első sorozaton | Sorozattípus | Oszlopforma |
| --- | --- | --- |
| Diagram létrehozása | `ClusteredCylinder` | `Cylinder` |
| Sorozattípus beállítása `ClusteredCone` | `ClusteredCone` | `Cone` |
| Oszlopforma beállítása `Box` | `ClusteredColumn3D` | `Box` |

A `Box` alakra állításakor a sorozattípust is `ClusteredColumn3D`-re változtatja. Ha a kódja a sorozattípustól függően ágazik, hívja meg a `series.getType()`-ot a forma megváltoztatása után. A hozzárendelés előtt cache‑elt érték továbbra is a `ClusteredCone` ágat választaná.

![PowerPoint-összehasonlítás, amely balról jobbra mutatja az első sorozatot henger, kúp és téglalap alakú oszlopokként](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ben?**

Az Aspose.Slides támogatja a 3D változatokat az oszlopdiagramoknál, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100% Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) osztály biztosít. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) tagjait az API-referenciában a telepített verzióhoz.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) vagy a [render the entire slide](/slides/hu/nodejs-java/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumokba. Ez hasznos, ha raszteres előnézetre van szüksége, vagy be szeretné ágyazni a diagramot dokumentumokba, műszerfalakba vagy weboldalakra PowerPoint nélkül.

**Milyen teljesítményű a nagy 3D diagramok építése és renderelése?**

A teljesítmény az adatmennyiségtől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsa minimálisra a 3D effektusokat, kerülje a nehéz textúrákat a falakon és ábraterületeken, korlátozza a sorozatonkénti adatpontok számát ahol lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és méretek), hogy megfeleljen a cél kijelző vagy nyomtatási igényeknek.