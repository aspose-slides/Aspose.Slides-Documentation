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
description: "Készítsen 3D diagramokat PowerPoint prezentációkba az Aspose.Slides for Node.js via Java segítségével. Állítsa be a forgást, a magasság arányait, a diagram mélységét és a sorok közötti távolságot JavaScript példákkal."
---
## **Áttekintés**

Aspose.Slides for Node.js via Java lehetővé teszi, hogy testreszabja egy 3D diagram nézetét a [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) metódus segítségével. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasság arányai, a mélység, a derékszögű tengelyek és a sorok közötti távolság, majd hogyan menthető a prezentáció PPTX formátumban.

## **Állítsa be a 3D diagram forgatását és mélységét**

Az alábbi példa egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) objektumot hoz létre, és a [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) segítségével egy rétegezett 3D oszlopdiagramot ad az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két sorozatra, amelyek mindegyike három értéket tartalmaz. A `0` indexű munkalap az első adatlapot jelöli; a `0` sor a sorozatneveket, a `0` oszlop pedig a kategória címkéket tartalmazza.

A [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) és a [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) metódusok a diagram forgatásait állítják be 40 és 270 fokra. A [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) a szélesség 150%-ára állítja a mélységet, míg a [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) derékszögű tengelyeket aktivál a perspektíva helyett. Az eredményül kapott prezentáció az ezekkel a beállításokkal rendelkező diagramot tartalmazza.

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

## **Képpel kitöltés alkalmazása a 3D diagram felületére**

A [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), a [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) és a [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) felületét önállóan töltheti ki. Állítsa a felület [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) értékét `Picture`-ra, és rendelje hozzá a képet. Állítsa mind a [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/), mind a felület [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) értékét `Stretch`-re, hogy a kép egy példánnyal kitöltse a felületet.

Mentse el a [arrow.png](arrow.png) fájlt a munkakönyvtárba. A példa elforgatja a diagramot, és a függőleges tengely maximális értékét megemeli, hogy a padló látható legyen az oszlopok között. Ezután a diát kétszer klónozza, és a nyilat egy különböző felületre alkalmazza minden dián. Mindhárom diagram ugyanazt az adatot, nézetet és háttérszínt tartja meg.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A Microsoft PowerPoint a három diát a következőképpen jeleníti meg.

| Oldalfal | Háttérfal | Aljzat |
| --- | --- | --- |
| ![Nyíl, ami a diagramba mutat az oldalfalon](side-wall.png) | ![Nyíl, ami jobbra mutat a háttérfalon](back-wall.png) | ![Nyíl, ami jobbra mutat az aljzaton a oszlopok között](floor.png) |

## **A 3D diagram magasság arányainak beállítása**

Használja a [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) metódust a 3D diagram magasságának a szélesség százalékában való megadásához. Ez a 3D jelenet arányait változtatja meg anélkül, hogy a diagram objektum méretét a dián módosítaná.

Az alábbi példa egy [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) diagramot hoz létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három prezentációt ment el 50 %, 100 % és 200 % magasság arányokkal. A diagram pozíciója, szélessége és magassága állandó marad. Az adatok, a forgatás, a mélység, a sorok távolsága és a formázás minden fájlban azonos; csak a magasság százalékos értéke változik.

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

Az alábbi képek ugyanazt a magasságbeállítást mutatják a megfelelő .NET példában, és a Microsoft PowerPoint segítségével exportálták. Az alacsonyabb százalék laposabb jelenetet eredményez, míg a magasabb százalék magasabb jelenetet hoz létre ugyanabban a diagram objektumban. A PowerPoint a tengelyek jelölőinek intervalumát és a címkék elhelyezését is módosíthatja a jelenethez illeszkedve.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50%-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100%-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200%-a](height_percent_200.png) |

Ezek a módszerek a diagram különböző aspektusait szabályozzák:

| Módszer | Hatás |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | A 3D jelenet magassága a szélesség százalékában. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | A diagram objektum magassága a dián, pontban. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | A 3D jelenet mélysége a szélesség százalékában. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | A sorok közötti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |

A magasságbeállítás hat a 3D oszlop- és sávdiagramokra, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal-, terület-, kör- és felületi diagramokra. A fenti összehasonlítás a hitelesített `Column3D` típust használja. A beállítás nem változtatja meg a 2D `ClusteredColumn` vagy a `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) osztály tagjai. Más diagrammegjelenítési beállításokért lásd a [Chart Formatting](/slides/hu/nodejs-java/chart-formatting/).

## **A sorok közötti hézag beállítása**

Használja a [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) metódust a 3D diagram adatcsoportjai közötti távolság szabályozásához a mélységi tengelyen, a jelölő szélességének százalékában kifejezve. Az értékek **0‑tól 500‑ig** terjedhetnek, inkluzívan: a `0` eltávolítja a hézagot, a nagyobb értékek pedig növelik a távolságot. Rögzített diagrammélység esetén a hézag növelése vékonyabb jelölőket eredményez a mélységi tengelyen.

A csoportot a [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) segítségével érheti el. A beállítás a csoport minden sorozatára vonatkozik, nem csak a hozzáférő sorozatra. A [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) visszaadja a mélységi hézagot, és tükrözi a szülőcsoport beállítását.

Ez a beállítás hat a 3D oszlop- és sávdiagramokra, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal‑ és területdiagramokra. A megjelenés attól függ, hogy a sorozatok mélységben, csoportosan vagy egymásra rakva jelennek‑e meg. A különálló sorozatok közötti hézagok egyértelmű összehasonlításához használja a `ChartType.Column3D` értéket a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) osztályból.

| Módszer | Hatás |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | A sorok közötti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | A szomszédos oszlop‑ vagy sávcsoportok közötti távolság, az oszlop vagy sáv szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | A diagram teljes mélysége a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két prezentációt ment el azonos adatokkal, forgatással, hézag szélességgel és diagrammélységgel; csak a hézag mélysége változik.

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

Az alábbi képek ugyanazt a hézag‑mélység beállítást mutatják a megfelelő .NET példában, és a Microsoft PowerPoint segítségével exportálták.

| Hézag mélysége: 0% | Hézag mélysége: 500% |
| --- | --- |
| ![3D oszlopdiagram, sorok között nincs hézag a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, 500 százalékos hézag a sorok között a mélységi tengelyen](gap_depth_500.png) |

## **A 3D sor típusa és sáv alakjának módosítása**

Egy csoportosított hengerdiagram első sorozata henger alakú sávval kezdődik. A példa kiírja a [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) és a [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) által visszaadott egész értékeket minden változtatás előtt és után. A táblázat a megfelelő állandó neveket mutatja.

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

| Változtatás az első sorozatra | Sor típus | Sáv alak |
| --- | --- | --- |
| Diagram létrehozása | `ClusteredCylinder` | `Cylinder` |
| A sor típusának beállítása `ClusteredCone` | `ClusteredCone` | `Cone` |
| A sáv alakjának beállítása `Box` | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása a sor típusát is `ClusteredColumn3D`‑re változtatja. Ha a kódja a sor típusán alapulva ágazik, hívja meg a `series.getType()`‑t a forma módosítása után. A hozzárendelés előtt eltárolt érték továbbra is a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely balról jobbra mutatja az első sorozatot hengeres, kúpos és téglalap alakú oszlopokként](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a 3D változatú oszlopdiagramokat, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100 % Stacked Column 3D típusokat, valamint az ehhez kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) osztály tesz elérhetővé. A pontos, naprakész listáért tekintse meg a telepített verzió API‑referenciájában a [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) tagjait.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. Exportálhat egy diagramot képként a [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) vagy a [teljes dia renderelése](/slides/hu/nodejs-java/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumba. Ez hasznos, ha raszteres előnézetre van szüksége, vagy a diagramot dokumentumokba, irányítópultokra vagy weboldalakra szeretné beágyazni PowerPoint igénybevétele nélkül.

**Mennyire teljesítményorientált a nagy 3D diagramok felépítése és renderelése?**

A teljesítmény az adat mennyiségétől és a vizuális összetettségtől függ. A legjobb eredmény érdekében minimalizálja a 3D hatásokat, kerülje a nehéz textúrákat a falakon és a diagramterületeken, korlátozza a sorozatonkénti adatpontok számát, ha lehetséges, és a kimenetet a célkijelző vagy nyomtatási igényekhez megfelelő felbontásban és méretben renderelje.