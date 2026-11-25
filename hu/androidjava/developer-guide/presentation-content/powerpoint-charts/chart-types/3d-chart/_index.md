---
title: Egyedi 3D diagramok testreszabása Android prezentációkban
linktitle: 3D diagram
type: docs
url: /hu/androidjava/3d-chart/
keywords:
- 3D diagram
- forgatás
- mélység
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Készítsen 3D diagramokat PowerPoint prezentációkba az Aspose.Slides for Android via Java segítségével. Állítsa be a forgatást, a magasságarányokat, a diagram mélységét és a sorozatok közti távolságot Java példákkal."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy testreszabja egy 3D diagram nézetét az [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) metódussal. Ez a cikk bemutatja, hogyan állíthatja be a forgatást, a magasságarányokat, a mélységet, a derékszögű tengelyeket és a sorok közti távolságot, majd hogyan mentheti a bemutatót PPTX formátumban.

## **Állítsa be a forgatást és a mélységet egy 3D diagramon**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) és a [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) metódust használja, hogy egy halmozott 3D oszlopdiagramot adjon hozzá az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két, három értéket tartalmazó sorozatra. A `0` indexű munkalap a diagram első adatmunkalapját jelöli; a `0` sor a sorozatneveket, az `0` oszlop a kategóriacímkéket tartalmazza.

A [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) és a [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) metódusok a diagram forgatását 40‑re és 270‑re fokra állítják. A [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) a mélységet a szélesség 150 %-ára állítja, míg a [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) a perspektíva helyett derékszögű tengelyeket engedélyezi. A végeredményül kapott bemutató a kitöltött diagramot tartalmazza ezekkel a 3D nézetbeállításokkal.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alkalmazzon képtöltést egy 3D diagram felületére**

Egy 3D diagramnak három felülete van, amelyeket önállóan tölthet ki: a [side wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), a [back wall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) és a [floor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--). Állítsa a felület [fill type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) értékét `Picture`‑ra, és rendelje hozzá a képet. Állítsa mind a [picture fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) mind a felület [picture type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) értékét `Stretch`‑re, hogy a kép egy példánya kitöltse a felületet.

Mentse a [arrow.png](arrow.png) fájlt a munkakönyvtárba. A példa elfordítja a diagramot, és növeli a függőleges tengely maximális értékét, hogy a padló látható legyen az oszlopok között. Ezután kétszer klónozza a diát, és minden dián egy másik felületre alkalmazza a nyilat. Az összes három diagram ugyanazt az adatot, nézőszöget és háttért tartja.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    IPPImage arrow = presentation.getImages().addImage(image);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A Microsoft PowerPoint a három diát a következőképpen jeleníti meg.

| Oldalfal | Háttérfal | Padló |
| --- | --- | --- |
| ![Nyíl, amely a diagramba mutat az oldalfalon](side-wall.png) | ![Nyíl, amely jobbra mutat a háttérfalon](back-wall.png) | ![Nyíl, amely jobbra mutat a padlón az oszlopok között](floor.png) |

## **Állítsa be a magasságarányokat egy 3D diagramon**

Használja a [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) metódust, hogy a 3D diagram magasságát a szélességének százalékában állítsa be. Ez megváltoztatja a 3D jelenet arányait anélkül, hogy átméretezné a dián lévő diagram objektumot.

Az alábbi példa egy [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) diagramot hoz létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50 %, 100 % és 200 % magasságarányokkal. A diagram pozíciója, szélessége és magassága állandó marad. Az adatok, a forgatás, a mélység, a sorok közti távolság és a formázás minden három fájlban azonos; csak a magasság százalékos értéke változik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Az alábbi képek bemutatják ugyanazt a magasságbeállítást az ekvivalens .NET példában, és a Microsoft PowerPoint segítségével exportálták. A kisebb százalék laposabb jelenetet eredményez, míg a nagyobb százalék magasabb jelenetet hoz létre ugyanabban a diagram objektumban. A PowerPoint akár a tengelyjelölések intervallumát és a címkék elhelyezését is módosíthatja a jelenethez illeszkedően.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, melynek magassága a szélesség 50 %-a](height_percent_50.png) | ![3D oszlopdiagram, melynek magassága a szélesség 100 %-a](height_percent_100.png) | ![3D oszlopdiagram, melynek magassága a szélesség 200 %-a](height_percent_200.png) |

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Módszer | Hatás |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | A 3D jelenet magassága a szélességének százalékában. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | A diagram objektum magassága a dián, pontban. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | A 3D jelenet mélysége a szélességének százalékában. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | A sorozatok közti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |

A magasságbeállítás érinti a 3D oszlop- és oszlopdiagramokat, beleértve a hengert, a kúpot és a piramis változatokat, valamint a 3D vonal-, terület-, kördiagram- és felületi diagramokat. A fenti összehasonlítás a bizonyított `Column3D` típust használja. A beállítás nem változtatja meg egy 2D `ClusteredColumn` diagram vagy egy `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) osztály tagjai. A diagram megjelenésének egyéb beállításaiért lásd a [Chart Formatting](/slides/hu/androidjava/chart-formatting/) oldalt.

## **Állítsa be a sorok közti hézagot**

Használja a [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) metódust, hogy a 3D diagram adat sorozatai közti távolságot a mélységi tengely mentén szabályozza, a jelölő szélességének százalékában kifejezve. Az értékek **0‑tól 500‑ig** terjednek, a `0` eltávolítja a hézagot, míg a nagyobb értékek növelik a távolságot. Rögzített diagrammélység esetén a hézag növelése a jelölőket vékonyabbá teszi a mélységi tengely mentén.

A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) útján érheti el. A beállítás a csoport minden sorozatára érvényes, nem csak arra a sorozatra, amelyen keresztül elérte. A [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) visszaadja a mélységi hézagot és tükrözi a szülőcsoport beállítását.

Ez a beállítás a 3D oszlop- és oszlopdiagramokat érinti, beleértve a hengert, kúpot és piramis változatokat, valamint a 3D vonal- és területdiagramokat. A megjelenés attól függ, hogy a sorozatok mélységben, csoportosítva vagy halmozva vannak-e. Az egyes sorozatok közti hézagok egyértelmű összehasonlításához használja a `ChartType.Column3D` típust a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) osztályból.

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Módszer | Hatás |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | A sorozatok közti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | A szomszédos oszlop- vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | A diagram összesített mélysége, a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót ment, azonos adatokkal, forgatással, hézag szélességgel és diagrammélységgel; csak a hézag mélysége változik.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Az alábbi képek az ekvivalens .NET példában ugyanazt a hézagmélység beállítást szemléltetik, és a Microsoft PowerPoint segítségével exportálták.

| Hézagmélység: 0% | Hézagmélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs hézag a sorozatok között a mélységi tengely mentén](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500 % hézag van a sorozatok között a mélységi tengely mentén](gap_depth_500.png) |

## **Módosítsa a 3D sorozat típusát és az oszlop alakját**

Egy csoportosított henger diagramban az első sorozat hengeres oszlopalakból indul. A példa kiírja az [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) és [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) által visszaadott egész értékeket minden változtatás előtt és után. A táblázat a megfelelő állandó neveket adja meg.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Változtatás az első sorozaton | Sorozattípus | Oszlop alak |
| --- | --- | --- |
| Diagram létrehozása | `ClusteredCylinder` | `Cylinder` |
| Állítsa be a sorozat típusát `ClusteredCone`-ra | `ClusteredCone` | `Cone` |
| Állítsa be az oszlop alakot `Box`-ra | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása szintén a sorozattípust `ClusteredColumn3D`‑ra változtatja. Ha a kódja a sorozattípus alapján ágazik, hívja meg a `series.getType()` metódust az alak megváltoztatása után. A hozzárendelés előtt tárolt érték még mindig a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely az első sorozatot hengerként, kúpként és téglalap alakú oszlopként mutatja balról jobbra](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a 3D oszlopdiagram változatokat, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és 100 % Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) osztály tesz elérhetővé. A pontos, naprakész listaért ellenőrizze a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) tagjait a telepített verzió API‑referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) vagy a [teljes dia renderelése](/slides/hu/androidjava/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumokba. Ez akkor hasznos, ha raszteres előnézetre van szüksége, vagy a diagramot dokumentumokba, műszerfalakba vagy weboldalakba szeretné beágyazni PowerPoint nélkül.

**Milyen teljesítményű a nagy 3D diagramok létrehozása és renderelése?**

A teljesítmény az adatmennyiségtől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsa a 3D hatásokat minimálisra, kerülje a nehéz textúrákat a falakon és a diagramterületen, korlátozza a sorozatonkénti adatpontok számát, ha lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és dimenziók), hogy megfeleljen a célkijelző vagy nyomtatási igényeknek.