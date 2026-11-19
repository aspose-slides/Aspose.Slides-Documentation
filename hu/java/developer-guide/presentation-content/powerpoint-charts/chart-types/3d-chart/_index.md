---
title: Testreszabott 3D diagramok bemutatókban Java használatával
linktitle: 3D diagram
type: docs
url: /hu/java/3d-chart/
keywords:
- 3D diagram
- forgatás
- mélység
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Hozzon létre 3D diagramokat PowerPoint bemutatókban az Aspose.Slides for Java segítségével. Állítsa be a forgatást, a magasságarányokat, a diagram mélységét és a sorozatok közötti távolságot Java példákkal."
---
## **Áttekintés**

Az Aspose.Slides for Java lehetővé teszi egy 3D diagram nézetének testreszabását a [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) metódus segítségével. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magasságarányok, a mélység, a derékszögű tengelyek és a sorozatok közötti távolság, majd hogyan menthető a bemutató PPTX formátumban.

## **A 3D diagram forgatásának és mélységének beállítása**

Az alábbi példa egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) objektumot hoz létre, és a [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) metódussal egy halmozott 3D oszlopdiagramot ad az első diára. Lecseréli az alapértelmezett sorozatokat és kategóriákat két, három értéket tartalmazó sorozatra. A munkalap index `0` azonosítja a diagram első adatmunkalapját; a `0` sor a sorozatneveket, az `0` oszlop pedig a kategória címkéket tartalmazza.

A [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) és a [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) metódusok a diagram forgását állítják be 40 és 270 fokra, illetve. A [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) a mélységet a szélesség 150%-ára állítja, míg a [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) jobb szögű tengelyeket aktivál a perspektíva helyett. Az eredményül kapott bemutató a kitöltött diagramot tartalmazza ezekkel a 3D nézeti beállításokkal.

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

## **A 3D diagram magasságarányainak beállítása**

Használja az [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) metódust a 3D diagram magasságának a szélességéhez viszonyított százalékos beállításához. Ez megváltoztatja a 3D jelenet arányait anélkül, hogy átméretezné a dián lévő diagram objektumát.

A következő példa egy [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) diagramot hoz létre az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50%, 100% és 200% magasságarányokkal. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, forgatás, mélység, sorozatok közötti távolság és formázás minden három fájlban azonos; csak a magasság százaléka változik.

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

A következő képek ugyanazt a magasságbeállítást mutatják be az ekvivalens .NET példában, és a Microsoft PowerPoint segítségével exportálták őket. A kisebb százalék laposabb jelenetet eredményez, míg a nagyobb százalék magasabb jelenetet ugyanazon diagramobjektumban. A PowerPoint a jelenethez igazodva módosíthatja a tengelyjelölések intervallumát és a címkék elhelyezését.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50%-ára van beállítva](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100%-ára van beállítva](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200%-ára van beállítva](height_percent_200.png) |

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | A 3D jelenet magassága a szélességének százalékában. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | A diagram objektum magassága a dián, pontban. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | A 3D jelenet mélysége a szélességének százalékában. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | A sorozatok közötti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |

A magasságbeállítás a 3D oszlop- és sávdiagramokat érinti, beleértve a henger-, kúp- és piramisváltozatokat, valamint a 3D vonal-, terület-, kör- és felületdiagramokat. A fenti összehasonlítás a hitelesített `Column3D` típust használja. A beállítás nem változtatja meg a 2D `ClusteredColumn` diagram vagy a `BubbleWith3D` diagram megjelenését; ezek a nevek a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) osztály tagjai. Egyéb diagram megjelenítési beállításokért lásd a [Chart Formatting](/slides/hu/java/chart-formatting/) cikket.

## **A sorozatok közötti hézag beállítása**

Használja az [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) metódust az adat sorozatok mélységi tengelyen való távolságának szabályozásához egy 3D diagramon, a jelölő szélességének százalékában kifejezve. Használjon **0 és 500** közötti értékeket, beleértve: a `0` eltávolítja a hézagot, míg a nagyobb értékek növelik a távolságot. A diagram mélysége állandó esetén a hézag növelése vékonyabbá teszi a jelölőket a mélységi tengelyen.

A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) használatával érheti el. A beállítás a csoport minden sorozatára vonatkozik, nem csak arra a sorozatra, amelyen keresztül elérte. Az [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) visszaadja a mélységi hézagot, és tükrözi a szülőcsoport beállítását.

Ez a beállítás a 3D oszlop- és sávdiagramokra vonatkozik, beleértve a henger-, kúp- és piramisváltozatokat, valamint a 3D vonal- és területdiagramokat. A megjelenés attól függ, hogy a sorozatok mélységben, csoportosítva vagy halmozva vannak-e rendezve. Az egyes sorozatok közötti hézagok tiszta összehasonlításához használja a `ChartType.Column3D` értéket a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) osztályból.

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | A sorozatok közötti távolság a mélységi tengelyen, a jelölő szélességének százalékában. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | A szomszédos sáv- vagy oszlopcsoportok közötti távolság, a sáv vagy oszlop szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | A diagram teljes mélysége, a diagram szélességének százalékában. |

A következő önálló példa az alapértelmezett diagram adatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót ment azonos adat, forgatás, hézag szélesség és diagram mélység mellett; csak a hézag mélysége változik.

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

A következő képek ugyanazt a hézagmélység-beállítást mutatják be az ekvivalens .NET példában, és a Microsoft PowerPoint használatával exportálták őket.

| Hézagmélység: 0% | Hézagmélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, amelynek nincs hézag a sorozatok között a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, amelynek 500%-os hézagja van a sorozatok között a mélységi tengelyen](gap_depth_500.png) |

## **A 3D sorozattípus és sávforma módosítása**

Egy csoportos hengerdiagram esetén az első sorozat hengeres sávformával kezdődik. A példa kiírja az [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) és az [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) által visszaadott egészértékeket minden változtatás előtt és után. A táblázat a megfelelő állandóneveket mutatja.

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

| Módosítás az első sorozaton | Sorozattípus | Sávforma |
| --- | --- | --- |
| Diagram létrehozása | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone` típus beállítása | `ClusteredCone` | `Cone` |
| `Box` sávforma beállítása | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása a sorozattípust is `ClusteredColumn3D`-re változtatja. Ha a kód a sorozattípus alapján ágazik, hívja a `series.getType()` metódust a forma megváltoztatása után. A hozzárendelés előtt gyorsítótárazott érték továbbra is a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely balról jobbra mutatja az első sorozatot hengerként, kúpként és téglalap alakú oszlopként](series-shapes.png)

## **FAQ**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ben?**

Az Aspose.Slides támogatja az oszlopdiagramok 3D változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100% Stacked Column 3D típusokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) osztály tár. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) tagjait az API referenciában a telepített verziójában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) vagy a [teljes dia renderelésével](/slides/hu/java/convert-powerpoint-to-png/) PNG vagy JPEG formátumokba. Ez akkor hasznos, ha raszteres előnézetre van szüksége, vagy a diagramot dokumentumokba, irányítópultokba vagy weboldalakra szeretné beágyazni PowerPoint nélkül.

**Milyen teljesítményű a nagy 3D diagramok felépítése és renderelése?**

A teljesítmény az adat mennyiségétől és a vizuális összetettségtől függ. A legjobb eredmény érdekében minimalizálja a 3D hatásokat, kerülje a nehéz textúrákat a falakon és a plot területeken, korlátozza a sorozatonkénti adatpontok számát, ha lehetséges, és rendereljen megfelelő méretű kimenetre (felbontás és méretek), amely megfelel a célkijelző vagy nyomtatási igénynek.