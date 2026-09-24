---
title: Diagram adat sorozatok kezelése Android prezentációkban
linktitle: Adatsorozat
type: docs
url: /hu/androidjava/chart-series/
keywords:
- diagram sorozat
- sorozat átfedése
- sorozat színe
- sorozat neve
- adatpont
- munkafüzet cella
- sorozat rés
- negatív érték
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, rés szélességet és negatív értékeket Android prezentációkban."
---
## **Áttekintés**

A diagram az ábrázolt adatokat egy diagramadat-munkafüzetben tárolja. Az [IChartSeries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/) egy összefüggő értékcsoportot képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. [IChartCategory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartcategory/) objektumok biztosítják a sorozatok által megosztott címkéket vagy csoportosítási értékeket. A sorozat neve, a kategóriák és a pontértékek ezért [IChartDataCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/) objektumokhoz kapcsolódnak, ahelyett, hogy csak megjelenített szövegként tárolódnának.

Egy tipikus kategória-diagram esetén az alapértelmezett munkafüzet a 0‑s sort a sorozatnevekhez, a 0‑s oszlopot a kategória-nevekhez, a maradék cellákat pedig a sorozatértékekhez használja. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metódusnak átadott munkalap-, sor- és oszlopindexek nullárol indulnak. Ez a felépítés hasznos, amikor alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

A diagram beállításainak három különböző hatóköre van:

- Sorozatszintű beállítások, például az [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getFormat--) biztosítják az alapértelmezett megjelenést egy sorozat összes pontjához.
- Adatpont szintű beállítások, például a [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) felülírják a sorozat megjelenését egy adott pontra.
- Csoportbeállítások érvényesek a kompatibilis sorozatokra, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) segítségével érheti el, ha például átfedés vagy réstávolság beállítására van szükség.

Ha nincs kifejezett pont- vagy sorozatkitöltés beállítva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha a sorozat és a pont formázása egyaránt jelen van, a pont formázása lép érvénybe az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozatának átfedése**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getOverlap--) jelzi, hogy a sávok vagy oszlopok mennyire fednek át egy 2D diagramon, -100 és 100 százalék között. Ez egy csak olvasható leképezése a beállításnak a szülő sorozatcsoporton. Használja a [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) metódust a csoportban lévő összes kompatibilis sorozat frissítéséhez. Ez az opció a csoportosított sávokat vagy oszlopokat megjelenítő diagramtípusokra vonatkozik; nem érinti a kombinált diagramokban a nem kapcsolódó sorozatcsoportokat.

A következő példa beállítja az átfedést arra a csoportra, amely az első sorozatot tartalmazza:

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

Használja az [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getFormat--) metódust egy teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, akkor a [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa szilárd kék kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagramadat-munkafüzetben van tárolva, és általában a jelmagyarázatban jelenik meg. A csoportosított oszlopdiagramhoz létrehozott alapértelmezett munkafüzetben a B1 cella a 0‑s sorban, az 1‑es oszlopban van, és az első sorozat nevét tartalmazza. A következő példa névvel ellátott állandói egyértelművé teszik ezt a struktúrát:

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

A már [IChartSeries.getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getName--) által hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramban:

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

## **Az automatikus sorozatkitöltőszín lekérése**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozat indexéből és a diagram stílusából számított színt Android ARGB színteljegy egész számként. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása a számított színt olvassa; nem rendel hozzá új kitöltést.

A következő példa kiírja minden alapértelmezett sorozat automatikus színteljegyét:

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

A pontos egészértékek a diagram stílusától és témájától függenek.

## **Negatív értékek esetén fordított kitöltőszín beállítása egy diagram sorozatra**

Sáv-, oszlop- és buborék-sorozatoknál a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) lehetővé teszi a negatív értékek külön kitöltéssel történő megjelenítését. Állítsa be a normál sorozat kitöltését szilárdra, engedélyezze az invertálást, és a negatív értékek színét a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) segítségével adja meg. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

A következő példa az alapértelmezett diagramadatokat egy sorozattal helyettesíti. A munkalap 0‑s sorában a sorozat neve, a 0‑s oszlopban a kategória nevek, az 1‑es oszlopban pedig az értékek találhatók:

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

![A fordított szilárd kitöltő szín](inverted_solid_fill_color.png)

Az invertálást egy pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) segítségével engedélyezheti. A következő példában a sorozat esetén le van tiltva, és csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

## **Egy adott adatpont értékének törlése**

Egy pont üressé tételéhez a többi pont eltávolítása nélkül, állítsa a háttércelláját `null`-ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) metóduson keresztül érhető el. Az adatpont a ugyanazon kategória helyen marad, de a diagram a beállított üres-érték beállítások szerint az értékét üresnek kezeli.

A következő példa csak a második pontot törli az első sorozatban:

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

A szórásdiagramok külön X és Y cellákat használnak, a buborékdiagramok pedig mérett cellát is. Csak azt a cellát törölje, amely a törölni kívánt értéket tartalmazza. Ne hívja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metódust, ha a többi pontot meg szeretné tartani, mivel ez a metódus eltávolítja az összes adatpontot a gyűjteményből.

## **Az üres cellák megjelenésének kezelése**

Egy üres munkafüzetcellát hiányzó adatként értelmezik; egy `0`‑t tartalmazó cella ismert numerikus értéket jelent. Hívja a [IChartDataCell.setValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metódust `null` értékkel, hogy egy cellát üressé tegyen. A numerikus nulla továbbra is nulla marad, függetlenül az üres-cellát beállítástól.

Használja a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódust annak kiválasztásához, hogyan jelenítse meg a diagram az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogy a hiányzó értékek hogyan kerülnek ábrázolásra, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

A következő önálló példa egy sorozatos vonaldiagramot hoz létre, törli a 3. nap értékét, és minden móddal elmenti ugyanazt a diagramot. Bemeneti fájl nem szükséges. A [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/) a 0‑s munkalapot, a 0‑s oszlopot használja a kategória címkékhez, az 1‑es oszlopot az értékekhez; a 0‑s sorban a sorozat neve van. A végleges adatok: `10, 20, empty, 30, 40`.

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

    // Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriáját és adatpontját.
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

Minden kimeneti fájl a mentés előtt megadott módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, adja meg a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: a Gap megszakítja a vonalat a 3. napnál, a Zero a vonalat nullára csökkenti, a Span összeköti a 2. napot a 4.-gyel.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagram esetén könnyű összehasonlítani mindhárom módot. Az oszlop- és sávdiagramoknál nincs vonal, amely összekötné a hiányzó kategóriát, ezért a `Span` nem képes előállítani a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, a csupán jelölőkkel rendelkező szórásdiagramnak nincs összekötő vonala. Ne várjon három eltérő eredményt minden diagramtípusnál; ellenőrizze a kimenetet a használt típus esetében.

## **A sorozat résekszélességének beállítása**

A réstávolság a szomszédos sáv- vagy oszlopcsoportok közötti távolság, amely a sáv vagy oszlop szélességének százalékában van kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja egyszer a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a csoport számára. Nagyobb érték több helyet hoz létre a csoportok között; kisebb érték sűrűbbé teszi őket.

A következő példa módosítja a réstávolságot, és csak a végső prezentációt menti:

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

![A réstávolság](gap_width.png)

## **FAQ**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Minden, a [ChartType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de sorozataik nem mindegyike rendelkezik azonos értékstruktúrával vagy beállításokkal. Például a kategória-diagramok kategóriákat és értékeket használnak, a szórás-diagramok X és Y értékeket, a buborék-diagramok pedig buborékméreteket adnak hozzá. Használja a sorozattípusnak megfelelő adatpont létrehozó metódust. Az átfedés és a réstávolság beállítások csak a kompatibilis sáv- vagy oszlopcsoportokra vonatkoznak.

**Mi a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [IShapeCollection.addChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) mintasorozatokat, kategóriákat és értékeket hoz létre. Szerkesztheti ezeket a cellákat, vagy törölheti mind a sorozat-, mind a kategória-gyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés segítségével diagramot is létrehozhat alapértelmezett adat nélkül.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzetcellákhoz?**

A sorozatnevek, a kategóriacímkék és az adatpont értékek az [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat építésekor tartsa a kategória sorokat és a sorozat-érték sorokat igazítva, hogy minden pont a kívánt kategória alá legyen ábrázolva.

**Hogyan törlök egy pontot a teljes sorozat helyett?**

Állítsa be a megfelelő értékcellát `null`-ra, hogy a pont kategóriahelye üres pontként maradjon. A [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metódust csak akkor használja, ha az adott sorozat összes pontját el szeretné távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek továbbra is össze legyenek illesztve a kategória-gyűjteménnyel.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) által beállított értéktől függ. A támogatott diagramok megjeleníthetik a hiányzó cellákat hézagként, nulla értékként vagy a szomszédos pontok összekapcsolásával. Válassza ki azt a beállítást, amely a prezentációjában a hiányzó adat jelentésével egyezik. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példáért és a vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

Támogatott sáv-, oszlop- és buborék-sorozatoknál hívja a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metódust, és állítsa be a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) által visszaadott színt. Egy egyedi pont viselkedését a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) segítségével felülírhatja. Ezek a metódusok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás győz, ha a sorozat és a pont is formázva van?**

A kifejezett adatpont-formázás előnyt élvez az adott pontnál. A többi pont a kifejezett sorozat-formázást használja, vagy ha a sorozat-formátum nincs definiálva, akkor az automatikus diagramstílust és -témát. A csoportbeállítások, például az átfedés és a réstávolság az elrendezést vezérlik, és nem pontszintű formázási felülírások.

**Van korlátja, hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem alkalmaz különálló, fix sorozatszámlimitet. Gyakorlatban a prezentáció fájlkorlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozzák meg a hasznos limitet.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Használja a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti tér növeléséhez, vagy csökkentse azt, hogy a csoportok közelebb kerüljenek egymáshoz.