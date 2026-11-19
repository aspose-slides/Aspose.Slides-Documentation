---
title: 3D diagramok testreszabása Androidon futó prezentációkban
linktitle: 3D diagram
type: docs
url: /hu/androidjava/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Hozzon létre 3D diagramokat PowerPoint prezentációkban az Aspose.Slides for Android via Java segítségével. Állítsa be a forgást, a magasság arányait, a diagram mélységét és a sorozatok közti távolságot Java példákkal."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy testreszabja egy 3D diagram nézetét az [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) metóduson keresztül. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasság arányai, a mélység, a derékszögű tengelyek és a sorozatok közötti távolság, majd hogyan menthető a bemutató PPTX formátumban.

## **A 3D diagram forgatásának és mélységének beállítása**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) objektumot, és a [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) segítségével egy halmozott 3D oszlopdiagramot ad az első diájához. Lecseréli az alapértelmezett sorozatokat és kategóriákat két, három értéket tartalmazó sorozatra. A munkalap index `0` a diagram első adatmunkalapját azonosítja; a `0` sor tartalmazza a sorozatneveket, az `0` oszlop a kategóriacímkéket.

A [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) és a [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) metódusok a diagram forgását 40 illetve 270 fokra állítják. A [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) a mélységet a szélesség 150%-ára állítja, míg a [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) a perspektíva helyett derékszögű tengelyeket engedélyezi. Az eredményül kapott bemutató tartalmazza a kitöltött diagramot ezekkel a 3D nézetbeállításokkal.

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

## **A 3D diagram magasságarányainak módosítása**

Használja az [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) metódust a 3D diagram magasságának a szélességéhez viszonyított százalékban történő beállításához. Ez megváltoztatja a 3D jelenet arányait anélkül, hogy a diagram objektum méretét a dián módosítaná.

A következő példa egy [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) diagramot hoz létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50%, 100% és 200% magasságarányokkal. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, a forgatás, a mélység, a sorozatok távolsága és a formázás minden három fájlban azonos; csak a magasság százalékos értéke változik.

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

A következő képek bemutatják ugyanazokat a magasságbeállításokat az ekvivalens .NET példában, és a Microsoft PowerPoint használatával lettek exportálva. Egy kisebb százalék laposabb jelenetet eredményez, míg egy nagyobb százalék magasabb jelenetet ugyanazon diagramobjektumban. A PowerPoint akár a tengelyjelölések intervallumait és a címkék elhelyezését is módosíthatja a jelenethez illeszkedve.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50%-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100%-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200%-a](height_percent_200.png) |

Ezek a metódusok a diagram különböző aspektusait vezérlik:

| Metódus | Hatás |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | A 3D jelenet magassága a szélesség százalékaként. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | A diagram objektum magassága a dián, pontban. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | A 3D jelenet mélysége a szélesség százalékaként. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | A sorozatok közötti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |

A magasságbeállítás a 3D oszlop- és sávdiagramokra hat, beleértve a henger-, kúp- és piramisváltozatokat, valamint a 3D vonal-, terület-, kördiagram- és felületdiagramokat. A fenti összehasonlítás a ellenőrzött `Column3D` típust használja. A beállítás nem változtatja meg egy 2D `ClusteredColumn` diagram vagy egy `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) osztály tagjai. Más diagram megjelenítési beállításokért lásd a [Chart Formatting](/slides/hu/androidjava/chart-formatting/) oldalt.

## **A sorozatok közötti hézag módosítása**

Használja az [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) metódust a 3D diagram adat sorozatai közötti távolság a mélységi tengelyen történő szabályozására, a jelölő szélességének százalékában kifejezve. Az **0-500** közötti értékek használhatók, a `0` eltávolítja a hézagot, míg a nagyobb értékek növelik a távolságot. Rögzített diagrammélység esetén a hézag növelése vékonyabbá teszi a jelölőket a mélységi tengelyen.

A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) segítségével érheti el. A beállítás a csoport minden sorozatára érvényes, nem csak arra a sorozatra, amelyen keresztül elérte. Az [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) visszaadja a mélységi hézagot és tükrözi a szülőcsoport beállítását.

Ez a beállítás a 3D oszlop- és sávdiagramokra hat, beleértve a henger-, kúp- és piramisváltozatokat, valamint a 3D vonal- és területdiagramokat. A megjelenés attól függ, hogy a sorozatok mélységben, halomként vagy kupacként vannak-e rendezve. A különálló sorozatok közti hézagok egyértelmű összehasonlításához használja a `ChartType.Column3D`-t a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) osztályból.

Ezek a metódusok a diagram különböző aspektusait vezérlik:

| Metódus | Hatás |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | A sorozatok közötti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | A szomszédos sáv- vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | A diagram teljes mélysége, a diagram szélességének százalékában. |

A következő önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót ment azonos adatokkal, forgatással, hézag szélességgel és diagrammélységgel; csak a hézag mélysége változik.

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

A következő képek bemutatják az azonos hézagmélység beállításokat az ekvivalens .NET példában, és a Microsoft PowerPoint segítségével lettek exportálva.

| Hézagmélység: 0% | Hézagmélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs hézag a sorozatok között a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500%-os hézagja van a sorozatok között a mélységi tengelyen](gap_depth_500.png) |

## **A 3D sorozattípus és a sáv alakjának módosítása**

Egy csoportos hengerdiagram első sorozata hengeres sávalakzattal kezdődik. A példa kiírja az [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) és az [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) által visszaadott egészértékeket minden egyes módosítás előtt és után. A táblázat a megfelelő konstans neveket mutatja.

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

| Változtatás az első sorozaton | Sorozattípus | Sáv alak |
| --- | --- | --- |
| Create the chart | `ClusteredCylinder` | `Cylinder` |
| Set the series type to `ClusteredCone` | `ClusteredCone` | `Cone` |
| Set the bar shape to `Box` | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása szintén a sorozattípust `ClusteredColumn3D`-re változtatja. Ha a kódja a sorozattípus alapján ágazik, hívja meg a `series.getType()`-ot a forma megváltoztatása után. A hozzárendelés előtti gyorsítótárazott érték még mindig a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely balról jobbra mutatja az első sorozatot hengerekként, kúpként és téglalap alakú oszlopként](series-shapes.png)

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ben?**

Az Aspose.Slides a oszlopdiagramok 3D változatait támogatja, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100% Stacked Column 3D diagramokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) osztály tesz elérhetővé. A pontos, naprakész listáért ellenőrizze a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) tagjait az Ön által telepített verzió API‑referenciájában.

**Kaphatok raster (bitmap) képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) vagy a [teljes dia renderelése](/slides/hu/androidjava/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumokba. Ez hasznos, ha raster előnézetre van szüksége, vagy a diagramot dokumentumokba, műszerfalakba vagy weboldalakba akarja beágyazni PowerPoint nélkül.

**Milyen a nagy 3D diagramok felépítésének és renderelésének teljesítménye?**

A teljesítmény az adatmennyiségtől és a vizuális komplexitástól függ. A legjobb eredmény érdekében tartsák a 3D effektusokat minimálisra, kerüljék a nehéz textúrákat a falakon és a diagramterületeken, korlátozzák az egy sorozatra jutó adatpontok számát, ha lehetséges, és rendereljenek olyan méretű kimenetre (felbontás és dimenziók), amely megfelel a célkijelző vagy nyomtatási igényeknek.