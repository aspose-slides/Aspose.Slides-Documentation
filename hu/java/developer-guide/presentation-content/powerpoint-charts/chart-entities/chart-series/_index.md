---
title: Diagram adat sorozatok kezelése prezentációkban Java nyelven
linktitle: Adatsorozatok
type: docs
url: /hu/java/chart-series/
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
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhetők a diagram sorozatok, adatpontok, munkafüzetcellák, formázás, átfedés, hézag szélesség és negatív értékek prezentációkban Java-val."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagramadat-munkafüzetben tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/) egy kapcsolódó értékcsoportot képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/) egy vagy több munkafüzet‑cellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartcategory/) objektumok a sorozatok által közösen használt címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [IChartDataCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/) objektumokhoz vannak kapcsolva, nem csak megjelenítési szövegként tárolódnak.

Egy tipikus kategória-diagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatneveknek, az 0‑s oszlopot a kategórianévnek, a maradék cellák pedig a sorozatértékeknek. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)‑nek átadott munkalap‑, sor‑ és oszlopindexek nullával kezdődnek. Ez a felépítés akkor hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például az [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getFormat--) a sorozat összes pontjának alapértelmezett megjelenését adja meg.
- Adatpont‑szintű beállítások, például az [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getFormat--) felülbírálja a sorozat megjelenését egyetlen pont esetén.
- Csoportbeállítások, amelyek kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/) tartoznak. A csoporthoz a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) használatával férhet hozzá, amikor például átfedés vagy hézag‑szélesség beállítására van szükség.

Ha nincs kifejezetten beállítva pont‑ vagy sorozat‑kitöltés, a diagramstílus és a téma határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása létezik, a pont formázása előnyben részesül a pontnál.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozatának átfedésének beállítása**

Az [IChartSeries.getOverlap](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getOverlap--) megadja, hogy a 2D diagramon a sávok vagy oszlopok milyen mértékben fedik át egymást, -100 és 100 százalék között. Ez csak olvasható leképezése a szülőcsoport beállításának. A [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) használatával frissítheti a csoport minden kompatibilis sorozatát. Ez a beállítás azoknál a diagramtípusoknál érvényes, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; egy kombinált diagram nem kapcsolódó sorozatcsoportokra nincs hatással.

Az alábbi példa beállítja az átfedést az első sorozatot tartalmazó csoportnál:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Az új diagram mintasorozatokat, kategóriákat és értékeket tartalmaz.
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

Használja az [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getFormat--) metódust a teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését az adott pontnál.

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

A sorozat neve a diagramadat‑munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Alapértelmezett, klaszteros oszlopdiagram esetén a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok egyértelművé teszik ezt a struktúrát:

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

Frissítheti azt a cellát is, amelyre már a [IChartSeries.getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getName--) hivatkozik. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramban:

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

## **Az automatikus sorozatszín lekérdezése**

Az [IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozatindex és a diagramstílus alapján kiszámított színt. Ez a szín használatos, ha a sorozat kitöltése nincs kifejezetten meghatározva. A metódus csak olvassa a kiszámított színt; nem állít be új kitöltést.

Az alábbi példa kiírja minden alapértelmezett sorozat automatikus színét:

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

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagramstílustól és a témától függenek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék‑sorozatoknál az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) segítségével a negatív értékek másik kitöltéssel jeleníthetők meg. Állítsa be a normál sorozat kitöltését szilárdra, engedélyezze az inverziót, és adja meg a negatív érték színét az [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) metódussal. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa egy sorozattal helyettesíti az alapértelmezett diagramadatot. A 0‑s sor tartalmazza a sorozat nevét, a 0‑s oszlop a kategórianév, az 1‑s oszlop pedig az értékeket:

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

![Az inverz szilárd kitöltőszín](inverted_solid_fill_color.png)

Az inverzió egy pontnál az [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) használatával engedélyezhető. Az alábbi példában a sorozatra vonatkozó inverzió ki van kapcsolva, csak a kiválasztott pontnál van beállítva, ráadásul a pont negatív értéket kap, hogy a hatás látható legyen:

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

## **Egy konkrét adatpont értékének törlése**

Egy pont üresen hagyásához a többi pont eltávolítása nélkül állítsa a mögöttes munkafüzet‑cellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getValue--)‑val érhető el. Az adatpont a kategóriahelyén marad, de a diagram a beállított „üres érték” szabályok szerint üresként kezeli.

Az alábbi példa csak a második pontot törli az első sorozatból:

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

Szétszórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig még egy méretcellát is. Csak azt a cellát törölje, amely a ténylegesen eltávolítandó értéket tartalmazza. Ne hívja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapointcollection/#clear--) metódust, ha a többi pontot meg akarja tartani, mert ez a metódus a teljes gyűjteményt törli.

## **Az üres cellák megjelenésének szabályozása**

A rejtett, értéket tartalmazó cellák külön esetet jelentenek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatainak felvételéhez vagy kizárásához lásd a [Include Data from Hidden Rows and Columns](/slides/hu/java/chart-workbook/#include-data-from-hidden-rows-and-columns) fejezetet.

Az üres munkafüzet‑cellák hiányzó adatot jelentenek; a `0` értéket tartalmazó cella ismert numerikus értéket. A [IChartDataCell.setValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) hívásával `null`‑t adjon meg, hogy a cella üres legyen. A numerikus nulla minden esetben nulla marad, függetlenül az üres‑cellás beállítástól.

Használja az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódust, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik, és megváltoztatja az üres értékek ábrázolását anélkül, hogy a munkafüzet‑cellát nullával vagy interpolált értékkel kitöltené.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3‑as nap értékét, és mindhárom módot elmenti. Bemeneti fájl nem szükséges. Az [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot a kategóriacímkékhez, az 1‑s oszlopot az értékekhez használja; a 0‑s sor tartalmazza a sorozat nevét. A végső adatsor: `10, 20, empty, 30, 40`.

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

    // Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriát és az adatpontot.
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

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót akar menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az összehasonlítás alább ugyanazt az adatot mutatja mindhárom fájlban. A 3‑as nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: a Gap a vonalat szaggatja a 3‑as napon, a Zero a vonalat nullához húzza, a Span a 2‑as napot összeköti a 4‑essel.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. Egy vonaldiagram esetén a három mód könnyen összehasonlítható. Sáv‑ és oszlopdiagramok esetén nincs vonal a hiányzó kategória áthidalásához, ezért a `Span` nem hoz létre csatlakozó szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop ugyanolyanul nézhet ki. Hasonlóan, egy szórásdiagram csak jelölőkkel nem rendelkezik csatlakozó vonallal. Ne várjon három különböző eredményt minden diagramtípustól; ellenőrizze a kimenetet az adott típusnál.

## **A sorozat hézag‑szélességének beállítása**

A hézag‑szélesség a szomszédos sáv‑ vagy oszlop‑klaszterek közti tér, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülőcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a csoportra. Nagyobb érték szélesebb hézagot eredményez, kisebb érték sűrűbb elrendezést.

Az alábbi példa módosítja a hézag‑szélességet, és csak a végső prezentációt menti:

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

![A hézag‑szélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat‑sorozatot?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de a sorozataik nem mindegyiknek van ugyanaz az érték‑szerkezete vagy beállítása. Például a kategória‑diagramok kategóriákat és értékeket használnak, a szórásdiagramok X és Y értékeket, a buborékdiagramok pedig méreteket is. Használja a sorozattípusnak megfelelő adatpont‑létrehozási metódust. Az olyan opciók, mint az átfedés és a hézag‑szélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül érinti a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint az [IShapeCollection.addChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket kiürítheti, mielőtt teljesen egyedi adatot adna meg. Egy túlterhelés lehetővé teszi diagram létrehozását alapértelmezett adat nélkül is.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzet‑cellákhoz?**

A sorozatnevek, kategória‑címkék és adat‑pont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat felépítésekor tartsa összehangoltan a kategória‑sorokat és a sorozat‑érték‑sorokat, hogy minden pont a megfelelő kategória alatti helyen jelenjen meg.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő érték‑cellát `null`‑ra, így a pont kategória‑helye megmarad üres pontként. A [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapointcollection/#clear--) csak akkor használható, ha a sorozat összes pontját el akarja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek továbbra is a kategória‑gyűjteménnyel legyenek összehangolva.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) beállítástól függ. A támogatott diagramok megjeleníthetik a hiányzókat hézagként, zero‑értékként vagy a szomszédos pontok összekötésével. Válassza azt a beállítást, amely a hiányzó adat jelentését a prezentációjában leginkább tükrözi. Tekintse meg a ‎[Az üres cellák megjelenésének szabályozása](#control-the-display-of-empty-cells)‎ fejezetet a teljes példáért és vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv-, oszlop- és buborék‑sorozatoknál hívja meg az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metódust, és állítsa be a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) által visszaadott színt. Egyéni pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) felülbírálhatja ezt a viselkedést. Ezek a metódusok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

Az explicit adat‑pont formázás előnyt élvez a pontnál. A többi pont továbbra is az explicit sorozat‑formátumot vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoport‑beállítások (például átfedés és hézag‑szélesség) az elrendezést szabályozzák, nem pont‑szintű formázási felülírások.

**Van korlátozás a diagramon megjeleníthető sorozatok számát illetően?**

Az Aspose.Slides nem alkalmaz különálló, fix sorozatszám‑korlátot. Gyakorlatban a prezentációs fájl mérete, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit kell változtatni, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg az [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a megfelelő szülőcsoporton. Növelje az értéket a klaszterek közti tér szélesítéséhez, vagy csökkentse a közelebb hozáshoz.