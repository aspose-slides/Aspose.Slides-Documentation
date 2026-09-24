---
title: Diagram adat sorozatok kezelése prezentációkban Java-ban
linktitle: Adatsorozat
type: docs
url: /hu/java/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- sorozat neve
- adatpont
- munkafüzet cella
- sorozat hézag
- negatív érték
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet kezelni a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban Java-val."
---
## **Áttekintés**

A diagram a megjelenített adatait egy diagram adatkönyvben tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/) egy összefüggő értékek halmazát képviseli, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartcategory/) objektumok biztosítják a sorozatok által megosztott címkéket vagy csoportosítási értékeket. A sorozat neve, a kategóriák és a pontértékek ezért az [IChartDataCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/) objektumokhoz kapcsolódnak, nem csupán megjelenő szövegként tárolódnak.

Tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatneveknek, a 0. oszlopot a kategórianévnek, a maradék cellákat pedig a sorozatértékeknek. Az [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metódusnak átadott munkalap, sor és oszlop indexek nullától indulnak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden létező diagram ezt használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállítások három különböző hatókörrel rendelkeznek:

- Sorozat‑szintű beállítások, például az [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getFormat--) alapértelmezett megjelenést biztosítanak egy sorozat összes pontjának.
- Adatpont‑szintű beállítások, például az [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getFormat--) felülírják a sorozat megjelenését egyetlen pontnál.
- Csoport beállítások vonatkoznak a kompatibilis sorozatokra, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/) tartoznak. A csoporthoz férhet hozzá az [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) metódussal, ha például átfedés vagy hézag szélesség beállítására van szükség.

Ha nincs kifejezetten beállítva pont‑ vagy sorozat‑kitöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind sorozati, mind pont formázás jelen van, a pont formázása felülírja a sorozati beállítást az adott pontra.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

Az [IChartSeries.getOverlap](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getOverlap--) megadja, hogy a sávok vagy oszlopok mennyire fedik át egymást egy 2D diagramon, -100 és 100 százalék között. Ez egy csak olvasható leképezése a szülő sorozatcsoport beállításának. Használja az [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) metódust a csoport minden kompatibilis sorozatának frissítéséhez. Ez a beállítás a csoportos sávokat vagy oszlopokat megjelenítő diagramtípusokra vonatkozik; kombinált diagramokban a nem kapcsolódó sorozatcsoportokat nem érinti.

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

## **A sorozat kitöltőszínének módosítása**

Használja az [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getFormat--) metódust a teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak az [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozati kitöltést az adott pontban.

Az alábbi példa szilárd kék kitöltést alkalmaz az első sorozatra:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

A sorozat neve a diagram adatkönyvben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben egy klaszterezett oszlopdiagramnál a B1 cella a 0. sor, 1. oszlop helyén a első sorozat nevét tartalmazza. Az alábbi példa névkonstansai egyértelművé teszik ezt a felépítést:

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

Frissítheti azt a cellát is, amelyre már az [IChartSeries.getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getName--) mutat. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramban:

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

## **Az automatikus sorozat kitöltőszín lekérdezése**

Az [IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozati index és a diagram stílusa alapján kiszámított színt. Ez a szín akkor kerül felhasználásra, ha a sorozat kitöltése nincs kifejezetten definiálva. A metódus csak a számított színt olvassa; új kitöltést nem rendel.

Az alábbi példa kiírja az alapértelmezett sorozatok automatikus színét:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

Példa kimenet az alapértelmezett diagram stílusra:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függenek.

## **Invert (fordított) kitöltőszín beállítása egy diagram sorozathoz**

Sáv, oszlop és buborék sorozatok esetén az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatív értékeket másik kitöltéssel jelenítheti meg. Állítsa be a normál sorozatkitöltést szilárd színre, aktiválja a fordítást, és adja meg a negatív érték színét az [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) metódussal. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük módosul.

Az alábbi példa egyetlen sorozattal helyettesíti az alapértelmezett diagram adatot. A 0. munkalap sorában a sorozat neve, az 0. oszlopban a kategórianevek, az 1. oszlopban az értékek találhatók:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

![A fordított szilárd kitöltőszín](inverted_solid_fill_color.png)

A fordítást egy pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) metódussal engedélyezheti. Az alábbi példa a sorozatnál letiltja a fordítást, és csak a kijelölt pontnál engedélyezi. A pont negatív értéket is kap, így a hatás látható:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

## **Egy adott adatpont értékének törlése**

Egy pont üresen hagyásához a többi pont eltávolítása nélkül állítsa a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getValue--) metódussal érhető el. Az adatpont ugyanazon kategóriahelyen marad, de a diagram a beállításai szerint üresként kezeli az értéket.

Az alábbi példa csak az első sorozat második pontját törli:

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

A szórásdiagramok külön X és Y cellákat használnak, a buborék diagramok méretcellát is. Tisztítsa csak azt a cellát, amely a törölni kívánt értéket tartalmazza. Ne hívja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapointcollection/#clear--) metódust, ha csak egy pontot szeretne megtartani, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének vezérlése**

Egy üres munkafüzetcellát hiányzó adatként kezelnek; egy `0` értékű cella ismert numerikus értéket jelent. Hívja az [IChartDataCell.setValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metódust `null`‑ral egy cella üresre állításához. A numerikus nulla minden esetben nulla marad, függetlenül az üres‑cellás beállítástól.

Használja az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódust annak meghatározásához, hogy a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. A beállítás megváltoztatja, hogyan kerülnek kirajzolásra a hiányzó értékek, anélkül hogy a munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, kitörli a 3. nap értékét, és minden módon elmenti ugyanazt a diagramot. Bemeneti fájlra nincs szükség. A [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/) a 0. munkalapot, az 0. oszlopot a kategóriacímkékhez, az 1. oszlopot az értékekhez használja; a 0. sor a sorozatnevet tartalmazza. A végső adatsor: `10, 20, empty, 30, 40`.

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

    // Hagyja a 3. napot valóban üresen, miközben megőrzi a kategóriáját és adatpontját.
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

Minden kimeneti fájl a mentés előtt beállított módot tükrözi: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, és `empty_cells_Span.pptx`. Ha csak egy változatot szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok ciklikus feldolgozása helyett.

Az alábbi összehasonlításban mindhárom fájl ugyanazt az adatot mutatja. A 3. nap üres a munkafüzetben minden esetben:

![Vonaldiagramok azonos adatokkal: Gap a vonalat szünetelteti a 3. napon, Zero a vonalat nullához viszi, Span pedig összeköti a 2. és a 4. napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagram mindhárom módot könnyen összehasonlíthatóvá teszi. Sáv‑ és oszlopdiagramok esetén nincs vonal, amely összekötné a hiányzó kategóriát, így a `Span` nem hozhat létre a fenti ábrán látható szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen a jelölőkkel ellátott szórásdiagramnak nincs csatlakozó vonala. Ne várjon három különböző eredményt minden diagramtípusra; ellenőrizze a kimenetet a használni kívánt típus esetén.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv‑ vagy oszlopcsoportok közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a beállítás a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja egyszer az [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a csoportra. Nagyobb érték több helyet hoz létre a csoportok között; kisebb érték sűrűbb elrendezést eredményez.

Az alábbi példa módosítja a hézag szélességét, és csak a végleges prezentációt menti:

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

![A hézag szélessége](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ adatokat, de sorozataik nem mindegyiknek azonos értékstruktúrája vagy beállításai vannak. Például a kategória diagramok kategóriákat és értékeket használnak, a szórásdiagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket. Használja a sorozattípusnak megfelelő adatpont‑létrehozó metódust. Az átfedés és hézag szélesség csak a kompatibilis sáv‑ vagy oszlopcsoportokra vonatkozik.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoport‑szintű ábrázolási beállításokat osztanak meg. Kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint az [IShapeCollection.addChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) minta sorozatokat, kategóriákat és értékeket hoz létre. Szerkesztheti ezeket a cellákat, vagy törölheti a sorozat‑ és kategória‑gyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés (overload) képes diagramot létrehozni alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategória címkék és adatpont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatok építésekor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat összehangoltan, hogy minden pont a megfelelő kategória alatt legyen ábrázolva.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`‑ra, így a pont kategória‑pozíciója megmarad üres pontként. A [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapointcollection/#clear--) metódust csak akkor használja, ha az egész sorozatot el akarja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek a kategória‑gyűjteménnyel igazodjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) beállítástól függ. Támogatott diagramok megjeleníthetik a hiányzókat hézagként, nullaként vagy a szomszédos pontok összekötésével. Válassza a hiányzó adatok jelentéséhez illő beállítást. Lásd: [Az üres cellák megjelenésének vezérlése](#control-the-display-of-empty-cells) a teljes példa és vizuális összehasonlítás érdekében.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv, oszlop és buborék sorozatok esetén hívja az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metódust, és állítsa be a színt az [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) visszatérési értékével. Egy egyedi pontnál felülbírálhatja a viselkedést a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) metódussal. Ezek a módszerek a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adatpont‑formázás előnyben részesül az adott ponton. A többi pont továbbra is a sorozat explicit formázását vagy, ha az nincs definiálva, a automatikus diagramstílust és témát használja. A csoport‑beállítások, mint az átfedés és a hézag szélesség, az elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korlátozás a diagramban lévő sorozatok számát illetően?**

Az Aspose.Slides nem alkalmaz külön fix sorozatszám‑korlátot. Gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit módosítsak, ha a oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja az [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közötti térszélesség növeléséhez, vagy csökkentse, ha közelebb szeretné hozni a csoportokat.