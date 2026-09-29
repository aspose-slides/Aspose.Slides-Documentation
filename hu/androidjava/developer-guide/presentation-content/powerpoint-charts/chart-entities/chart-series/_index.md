---
title: Diagram adat sorozatok kezelése Android prezentációkban
linktitle: Adatsorozatok
type: docs
url: /hu/androidjava/chart-series/
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
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket Android prezentációkban."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagramadat‑munkafüzetben tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/) egy vagy több munkalap‑cellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Így a sorozat neve, a kategóriák és a pontértékek a [IChartDataCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/) objektumokra hivatkoznak, nem csak megjelenő szövegként vannak tárolva.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatneveknek, a 0‑s oszlopot a kategórianéveknek, a többi cellát pedig a sorozatértékeknek. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)‑nek átadott munkalap‑, sor‑ és oszlopindexek 0‑alapúak. Ez a felépítés akkor hasznos, ha alapértelmezett adatokkal hoz létre egy diagramot, de ne feltételezze, hogy minden létező diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getFormat--) adják meg az alapértelmezett megjelenést egy sorozat összes pontjának.
- Adatpont‑szintű beállítások, például [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) felülírják a sorozat megjelenését egy adott pontnál.
- Csoportbeállítások az egymással kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--)‑en keresztül érheti el, ha például átfedés vagy részsűrűség beállítására van szükség.

Ha nincs kifejezetten beállítva pont‑ vagy sorozat‑kitöltés, a diagram stílusa és témája határozza meg a automatikus megjelenést. Ha mind a sorozatra, mind a pontra vonatkozó formázás meg van adva, a pont‑formázás felülírja a sorozat beállítását azon a ponton.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getOverlap--) azt jelzi, hogy a 2D diagramon a sávok vagy oszlopok mennyire fednek egymást, -100‑tól 100‑ig százalékban. Ez csak olvasható visszafejtése a szülő sorozatcsoport beállításának. A [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-)‑vel frissítheti az adott csoport minden kompatibilis sorozatát. Ez a lehetőség azoknál a diagramtípusoknál érvényes, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; a kombinált diagramok nem kapcsolódó sorozatcsoportjait nem befolyásolja.

Az alábbi példa beállítja az átfedést az első sorozatot tartalmazó csoportra:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Az új diagram minta sorozatokat, kategóriákat és értékeket tartalmaz.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltő színének módosítása**

Használja a [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getFormat--)‑t egy egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését azon a ponton.

Az alábbi példa egy szilárd kék kitöltést alkalmaz az első sorozatra:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorozat színe](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagramadat‑munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet, amely egy csoportos oszlopdiagramhoz készült, a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok egyértelművé teszik ezt a struktúrát:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [IChartSeries.getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getName--)‑vel már hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli, hogy egy meglévő diagramra egy meghatározott sorra és oszlopra támaszkodjon:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorozat neve](series_name.png)

## **Az automatikus sorozatszín lekérése**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozat indexe és a diagramstílus alapján számított színt Android ARGB egész számként. Ez a szín akkor használatos, amikor a sorozat kitöltése nincs kifejezetten meghatározva. A metódus csak a számított színt olvassa ki; nem állít be új kitöltést.

Az alábbi példa kiírja minden alapértelmezett sorozat automatikus színértékét:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

A pontos egészértékek a diagramstílustól és a témától függnek.

## **Inverz kitöltő szín beállítása egy diagram sorozathoz**

Oszlop‑, sáv‑ és buboréksorozatoknál az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) lehetővé teszi, hogy a negatív értékek másik kitöltéssel jelenjenek meg. Állítsa be a szabályos sorozat kitöltését szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)‑vel. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa az alapértelmezett diagramadatot egy sorozattal helyettesíti. A 0‑s munkalapsor a sorozat nevét, a 0‑s oszlop a kategórianév­eket, az 1‑s oszlop pedig az értékeket tartalmazza:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az invertált szilárd kitöltő szín](inverted_solid_fill_color.png)

Inverzálást egyetlen pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)‑vel engedélyezheti. Az alábbi példában a sorozatnál le van tiltva az invertálás, és csak a kijelölt pontnál van bekapcsolva. A ponthoz negatív értéket is adunk, hogy a hatás látható legyen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egy konkrét adatpont értékének törlése**

Egy pont üresen hagyásához a többi pont eltávolítása nélkül állítsa be a mögöttes munkafüzet‑cellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getValue--)‑n keresztül érhető el. Az adatpont a kategória pozícióján marad, de a diagram a beállított üres‑érték‑szabályok szerint üresként kezeli.

Az alábbi példa csak a második pontot törli az első sorozatban:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A szórási diagramok külön X‑ és Y‑cellákat használnak, a buborékdiagramok pedig egy méretcellát is. Törölje csak azt a cellát, amely a törölni kívánt értéket tartalmazza. Ne hívja meg az [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)‑t, ha a többi pontot meg akarja tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenítésének szabályozása**

A rejtett cellákban lévő értékek különböznek az üres celláktól. A rejtett munkalapsorok és -oszlopok adatainak fel‑ vagy letiltásához lásd a [Hidden Rows and Columns adatainak felvétele](/slides/hu/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) szakaszt.

Az üres munkafüzet‑cellák hiányzó adatot jelentenek; a `0` értékű cella ismert numerikus értéket jelent. Hívja meg az [IChartDataCell.setValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-)‑t `null`‑al, hogy a cellát üresre állítsa. A numerikus nulla minden esetben nulla marad, függetlenül az üres‑cellás beállítástól.

Használja az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)‑t a diagram üres cellák megjelenítési módjának kiválasztásához. Ez a beállítás a teljes diagramra vonatkozik, és azt módosítja, hogyan ábrázolja a hiányzó értékeket anélkül, hogy a munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, majd minden módot külön fájlba menti. Nem szükséges bemeneti fájl. Az [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot a kategória‑címkékhez, az 1‑s oszlopot az értékekhez használja; a 0‑s sor a sorozat nevét tartalmazza. A végső adatsor: `10, 20, empty, 30, 40`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // A 3. napot valóban üresen hagyja, miközben megtartja a kategóriát és az adatpontot.
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy változatot akar menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás mindhárom fájlban ugyanazt az adatot mutatja. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: a Gap a vonalat szakadáshoz, a Zero a vonalat nullára csökkenti, a Span összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. A vonaldiagram minden három módot könnyen összehasonlíthatóvá teszi. A sáv‑ és oszlopdiagramoknál nincs vonal, amely összekapcsolna egy hiányzó kategóriát, így a `Span` nem hozhat létre egy látható szakaszt; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, a pontokkal ellátott szórási diagramnál sincs vonal a pontok között. Ne várjon három különböző eredményt minden diagramtípusnál; ellenőrizze a kimenetet a használt típusnál.

## **A sorozat részsűrűségének beállítása**

A részsűrűség a szomszédos sáv‑ vagy oszlopcsoportok közti távolságot jelenti, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)‑t a csoportra. Nagyobb érték több helyet hoz létre a csoportok között; kisebb érték sűrűbbé teszi őket.

Az alábbi példa módosítja a részsűrűséget, és csak a végleges prezentációt menti:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A részsűrűség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes [ChartType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de sorozataik nem minden esetben ugyanazzal a szerkezettel vagy beállításokkal rendelkeznek. Például a kategóriadiagramok kategóriákat és értékeket használnak, a szórási diagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket. Használja a sorozattípusnak megfelelő adatpont‑létrehozási metódust. Az olyan beállítások, mint az átfedés és a részsűrűség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokkal dolgoznak. Egy kombinált diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Egy újonnan létrehozott diagram tartalmaz alapértelmezett adatot?**

Igen. Alapértelmezés szerint az [IShapeCollection.addChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket is törölheti, mielőtt teljesen egyedi adatkészletet adna meg. Egy overload akár alapértelmezett adat nélkül is létrehozhat diagramot.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzet celláihoz?**

A sorozatnevek, kategóriacímkék és adatpont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatok építésekor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat összhangban, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan töröljek egy pontot anélkül, hogy az egész sorozatot eltávolítanám?**

Állítsa a megfelelő értékcellát `null`‑ra, így a pont kategóriapozíciója megmarad, de üres pontként jelenik meg. Az [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)‑t csak akkor hívja meg, ha az adott sorozat összes pontját el akarja távolítani. Ha a kategóriákat is törli, frissítse az összes sorozatot, hogy értékeik a kategória‑gyűjteménnyel összhangban maradjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)‑ben beállított értéktől függ. A támogatott diagramok üreseket ábrázolhatnak hézagként, nulla értékként vagy a szomszédos pontok összekapcsolásával. Válassza ki a hiányzó adat jelentésének megfelelő beállítást a prezentációjában. Lásd a [Üres cellák megjelenítésének szabályozása](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatoknál hívja meg az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)‑t, és állítsa be a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)‑ből kapott színt. Egy adott pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) felülírhatja a viselkedést. Ezek a metódusok a formázást érintik, nem a tárolt numerikus értéket.

**Mi nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adatpont‑formázás felülírja a sorozat beállítását azon a ponton. A többi pont továbbra is a sorozat explicit formátumát vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoport‑beállítások, például átfedés vagy részsűrűség, a layoutot szabályozzák, nem pont‑szintű formázási felülírások.

**Van korlát a diagramban szereplő sorozatok számában?**

Az Aspose.Slides nem ír elő különálló, fix sorozatszám‑korlátot. A gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit módosítsak, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg az [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)‑t a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti tér növeléséhez, vagy csökkentse, ha a csoportok közelebb szeretnék kerülni egymáshoz.