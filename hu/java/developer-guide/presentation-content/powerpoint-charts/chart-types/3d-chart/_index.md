---
title: 3D diagramok testreszabása prezentációkban Java használatával
linktitle: 3D diagram
type: docs
url: /hu/java/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Készítsen 3D diagramokat PowerPoint prezentációkban az Aspose.Slides for Java segítségével. Állítsa be a forgást, a magassági arányokat, a diagram mélységét és a sorozatok közti távolságot Java példákkal."
---
## **Áttekintés**

Aspose.Slides for Java lehetővé teszi, hogy testre szabja egy 3D diagram nézetét az [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) metódus segítségével. Ez a cikk bemutatja, hogyan állítható be a forgatás, a magassági arányok, a mélység, a derékszögű tengelyek és a sorok közti távolság, majd mentse a bemutatót PPTX formátumban.

## **Állítsa be a forgást és a mélységet egy 3D diagramnál**

Az alábbi példa létrehoz egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) objektumot, és a [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) segítségével egy összesített 3D oszlopdiagramot ad az első diára. Lecseréli az alapértelmezett sorozatokat és kategóriákat két, három értéket tartalmazó sorozatra. A `0` indexű munkalap az adatdiagram első munkalapját jelöli; a `0` sor a sorozatneveket, a `0` oszlop a kategóriacímkéket tartalmazza.

A [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) és a [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) metódusok a diagram forgatásait 40 és 270 fokra állítják. A [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) a mélységet a szélesség 150%-ára állítja, míg a [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) helyettesíti a perspektívát derékszögű tengelyekkel. A kapott bemutató a feltöltött diagramot tartalmazza ezekkel a 3D nézeti beállításokkal.

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

## **Képpel kitöltés alkalmazása egy 3D diagram felületére**

Egy 3D diagramnak három felülete van, amelyeket külön-külön lehet kitölteni: a [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) és a [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) . Állítsa a felület [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) értékét `Picture`-re, és rendeljen hozzá egy képet. Állítsa mind a [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) , mind a felület [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) értékét `Stretch`-re, hogy a kép egy példánya kitöltse a felületet.

Mentse el az [arrow.png](arrow.png) fájlt a munkakönyvtárba. A példa elforgatja a diagramot, és növeli a függőleges tengely maximális értékét, hogy a padló látható legyen az oszlopok között. Ezután kétszer klónozza a diát, és minden diához más felülethez rendeli a nyilat. Mindhárom diagram ugyanazt az adatot, nézőszöget és háttérszínt tartja meg.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
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

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

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

Microsoft PowerPoint a három diát az alábbiak szerint jeleníti meg.

| Oldalsó fal | Hátsó fal | Padló |
| --- | --- | --- |
| ![Nyíl, amely a diagram felé mutat az oldalsó fal mentén](side-wall.png) | ![Nyíl, amely jobbra mutat a hátsó falon](back-wall.png) | ![Nyíl, amely jobbra mutat a padlón a oszlopok között](floor.png) |

## **A magassági arányok beállítása egy 3D diagramnál**

Használja az [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) metódust, hogy a 3D diagram magasságát a szélesség százalékában adja meg. Ez megváltoztatja a 3D jelenet arányait anélkül, hogy átméretezné a diagram objektumot a dián.

Az alábbi példa létrehoz egy [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) diagramot az alapértelmezett adatokkal: három sorozat és négy kategória. Három bemutatót ment 50 %, 100 % és 200 % magassági arányokkal. A diagram pozíciója, szélessége és magassága változatlan marad. Az adatok, forgatás, mélység, sorozatok közti távolság és formázás minden fájlban azonos; csak a magassági százalék változik.

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

A következő képek a .NET megfelelő példa azonos magassági beállításait mutatják, és a Microsoft PowerPointból exportálták. Egy kisebb százalék laposabb jelenetet eredményez, míg egy nagyobb százalék magasabb jelenetet hoz létre ugyanabban a diagram objektumban. A PowerPoint a tengelyek beosztásait és a címkék elhelyezését is módosíthatja a jelenethez.

| Magasság: 50% | Magasság: 100% | Magasság: 200% |
| --- | --- | --- |
| ![3D oszlopdiagram, amelynek magassága a szélesség 50%-a](height_percent_50.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 100%-a](height_percent_100.png) | ![3D oszlopdiagram, amelynek magassága a szélesség 200%-a](height_percent_200.png) |

Ezek a metódusok a diagram különböző aspektusait szabályozzák:

| Metódus | Hatás |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | A 3D jelenet magassága a szélesség százalékában. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | A diagram objektum magassága a dián, pontban. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | A 3D jelenet mélysége a szélesség százalékában. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | A sorozatok közti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |

A magassági beállítás a 3D oszlop- és sávdiagramokra, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal-, terület-, kör- és felületdiagramokra is hatással van. A fenti összehasonlítás a hitelesített `Column3D` típust használja. A beállítás nem változtatja meg a 2D `ClusteredColumn` vagy a `BubbleWith3D` diagram kinézetét; ezek a nevek a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) osztály tagjai. Egyéb diagramformázási beállításokért lásd a [Diagram formázása](/slides/hu/java/chart-formatting/) oldalt.

## **A sorok közti rés (gap) beállítása**

Használja az [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) metódust a 3D diagram sorozatai közti távolság szabályozásához a mélységi tengelyen, a jelölő szélességének százalékában kifejezve. Értékek **0‑tól 500‑ig** engedélyezettek: a `0` eltávolítja a részt, míg a nagyobb értékek növelik a távolságot. Fix diagrammélység esetén a rés növelése vékonyabbá teszi a jelölőket a mélységi tengelyen.

A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) segítségével érheti el. A beállítás az adott csoport minden sorozatára vonatkozik, nem csak arra, amelyen keresztül elérte. A [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) visszaadja a mélységi részt, és tükrözi a szülőcsoport beállítását.

Ez a beállítás a 3D oszlop‑ és sávdiagramokra, beleértve a henger, kúp és piramis változatokat, valamint a 3D vonal‑ és területdiagramokra is hat. A megjelenés attól függ, hogy a sorozatok mélységben, csoportosítva vagy halmozva vannak-e. A különálló sorozatok közti rés összehasonlításához használja a `ChartType.Column3D` típust a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) osztályból.

| Metódus | Hatás |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | A sorozatok közti távolság a mélységi tengely mentén, a jelölő szélességének százalékában. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | A szomszédos sáv‑ vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | A diagram teljes mélysége, a diagram szélességének százalékában. |

Az alábbi önálló példa az alapértelmezett diagramadatokat használja, amelyek három sorozatot és négy kategóriát tartalmaznak. Két bemutatót ment, amelyek azonos adatot, forgatást, részszélességet és diagrammélységet tartalmaznak; csak a résmélység változik.

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

A következő képek a .NET megfelelő példa azonos résmélységi beállításait mutatják, és a Microsoft PowerPointból exportálták.

| Rést mélység: 0% | Rést mélység: 500% |
| --- | --- |
| ![3D oszlopdiagram, sorok között nincs rés a mélységi tengelyen](gap_depth_0.png) | ![3D oszlopdiagram, sorok között 500 %-os rés a mélységi tengelyen](gap_depth_500.png) |

## **A 3D sorozattípus és a sáv alakjának módosítása**

Egy csoportosított hengerdiagram első sorozata henger alakú sávval kezdődik. A példa kiírja a [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) és a [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) által visszaadott egész értékeket minden módosítás előtt és után. A táblázat a megfelelő konstansneveket mutatja.

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
| Diagram létrehozása | `ClusteredCylinder` | `Cylinder` |
| Állítsa a sorozattípust `ClusteredCone`‑ra | `ClusteredCone` | `Cone` |
| Állítsa a sáv alakot `Box`‑ra | `ClusteredColumn3D` | `Box` |

A `Box` alak beállítása egyúttal a sorozattípust is `ClusteredColumn3D`‑re változtatja. Ha a kód a sorozattípus alapján ágazik, a sáv forma módosítása után hívja meg a `series.getType()` metódust. A hozzárendelés előtti, cache‑ben tárolt érték továbbra is a `ClusteredCone` ágat választaná.

![PowerPoint összehasonlítás, amely balról jobbra mutatja az első sorozatot henger, kúp és téglalap alakú oszlopokként](series-shapes.png)

## **FAQ**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides‑ban?**

Az Aspose.Slides támogatja a 3D változatú oszlopdiagramokat, többek között a Column 3D, Clustered Column 3D, Stacked Column 3D és 100 % Stacked Column 3D típusokat, valamint a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) osztályon keresztül elérhető kapcsolódó 3D típusokat. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) tagjait az API-referenciában a telepített verzióhoz.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. Exportálhatja a diagramot képpé a [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) vagy a [render the entire slide](/slides/hu/java/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumban. Ez akkor hasznos, ha raster előnézetre vagy a diagram beágyazására van szükség dokumentumokba, irányítópultokra vagy weboldalakra PowerPoint szükségessége nélkül.

**Milyen teljesítményű a nagy 3D diagramok építése és renderelése?**

A teljesítmény az adatvolumen és a vizuális komplexitás függvénye. A legjobb eredmény érdekében tartsa a 3D hatásokat minimálisra, kerüljön el nehéz textúrákat a falakon és a diagramterületen, korlátozza a sorozatonkénti adatpontok számát, ha lehetséges, és rendereljen megfelelő felbontású és méretű kimenetre, amely megfelel a célmegjelenítő vagy nyomtatási igénynek.