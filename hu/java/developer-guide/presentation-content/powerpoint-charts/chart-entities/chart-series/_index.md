---
title: Diagram adatsorozatok kezelése prezentációkban Java-ban
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
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban Java-val."
---
## **Áttekintés**

A diagram az ábrázolt adatokat egy diagram adat munkafüzetben tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. A [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) objektumok biztosítják a címkéket vagy a sorozatok által megosztott csoportosítási értékeket. A sorozat neve, a kategóriák és a pontértékek ezért [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként vannak tárolva.

Tipikus kategória-diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatneveknek, a 0. oszlopot a kategórianévnek, a maradék cellákat pedig a sorozatértékeknek. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metódusnak átadott munkalap-, sor‑ és oszlopindexek nullával kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne vegye fel, hogy minden meglévő diagram ezt használja. A betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például az [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) alapértelmezett megjelenését biztosítják egy sorozat összes pontjához.
- Adatpont beállítások, például az [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) felülírja a sorozat megjelenését egy adott pontra.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) tartoznak. A csoportot az [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) segítségével érheti el, ha például átfedés vagy hézag szélesség beállítására van szükség.

Ha nincs kifejezett pont- vagy sorozatkitöltés megadva, a diagramstílus és a téma határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pontformázás jelen van, a pontformázás precedál a pontnál.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

Az [IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) megadja, hogy a sávok vagy oszlopok mennyire átfednek egy 2D diagramon, -100‑tól 100‑ig terjedő százalékban. Ez egy csak olvasható vetítése a szülő sorozatcsoport beállításának. Használja az [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) metódust a csoport minden kompatibilis sorozatának frissítéséhez. Ez az opció olyan diagramtípusokra vonatkozik, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; nem érinti az összevont diagramok nem kapcsolódó sorozatcsoportjait.

Az alábbi példa beállítja az átfedést az első sorozatot tartalmazó csoportra:

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

Használja az [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) metódust egy egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pontnak már van kifejezett kitöltése, az [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését azon a ponton.

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

A sorozat neve a diagram adat munkafüzetben van tárolva, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben egy klaszteros oszlopdiagram esetén a B1 cella a 0. sor, 1. oszlop helyén tartalmazza az első sorozat nevét. Az alábbi példában szereplő névkoncepciók ezt a struktúrát teszik nyilvánvalóvá:

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

A cellát közvetlenül is frissítheti az [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) által visszaadott hivatkozással. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy már meglévő diagramon:

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

### **Sorozat létrehozása több cellából álló névvel**

Összetett sorozatnév akkor hasznos, ha egy termék neve és egy jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` a B1‑ben és a `2026` a C1‑ben egyetlen sorozatnévvé kombinálható, miközben mindkét rész továbbra is a forráscellához van kapcsolva.

Használja az [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) metódust a névtartomány lekéréséhez, majd adja át ezt a gyűjteményt az [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) metódusnak. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák szerepelnek‑e: `true` kizárja őket, `false` pedig beleveszi. Ebben a példában `false`‑t használunk, hogy minden cella a névtartományban szerepeljen.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 csak a sorozatnevet szolgáltatja; az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // Ez a két cella biztosítja a sorozat nevét.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // Különálló cellák biztosítják a kategóriákat és a numerikus adatpontokat.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredményül kapott sorozatnév `Product A 2026`, a két cellaérték között szóközzel. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép mutatja az eredményt:

![Oszlopdiagram Észak és Dél értékekkel és a Product A 2026 összetett sorozatnévvel a jelmagyarázatban](composite_series_name.png)

## **Az automatikus sorozatkitöltőszín lekérése**

Az [IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozatidex és a diagramstílus alapján kiszámított színt. Ez a szín akkor kerül használatra, ha a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása a kiszámított színt olvassa; nem állít be új kitöltést.

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

Oszlop, sáv és buborék sorozatok esetén az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) negatív értékeket külön kitöltéssel jeleníthet meg. Állítsa be a szabályos sorozatkitöltést szilárdra, engedélyezze az inverziót, és adja meg a negatív érték színét az [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) metódussal. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenített színük változik.

Az alábbi példa az alapértelmezett diagramadatokat egy sorozatra cseréli. A 0. munkalap sor 0‑ja a sorozatnevet tartalmazza, az 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket:

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

Az inverzió egy pontnál az [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) segítségével engedélyezhető. Az alábbi példában az inverzió a sorozatnál ki van kapcsolva, csak a kiválasztott pontnál van bekapcsolva, amelynek negatív értéke is van, hogy a hatás látható legyen:

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

Egy pont üresen hagyásához a többi pontot érintés nélkül állítsa a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték az [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) segítségével érhető el. Az adatpont a kategóriahelyen marad, de a diagram a beállított üres‑érték opcióknak megfelelően kezeli azt üresként.

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

A szórt diagramok külön X és Y cellákat használnak, a buborékkör diagramok pedig egy méretcellát is. Törölje csak azt a cellát, amely a eltávolítandó értéket tartalmazza. Ne hívja meg az [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) metódust, ha a többi pontot meg szeretné tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenítésének szabályozása**

A rejtett, értékkel rendelkező cellák külön esetet képeznek az üres celláktól. A rejtett munkalap sorok és oszlopok adatainak bevonásához vagy kizárásához tekintse meg a **[Include Data from Hidden Rows and Columns](/slides/hu/java/chart-workbook/#include-data-from-hidden-rows-and-columns)** szakaszt.

Egy üres munkafüzetcellát hiányzó adatként kell tekinteni; egy `0`‑t tartalmazó cella ismert numerikus érték. Hívja meg az [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metódust `null`‑val, hogy a cellát üressé tegye. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellás beállítástól.

Használja az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódust, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja, hogyan ábrázolják a hiányos értékeket anélkül, hogy a munkafüzetcellát nullára vagy interpolált értékre töltené.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, és minden módot külön fájlba ment. Nem szükséges bemeneti fájl. Az [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) munkalap 0‑t, az 0. oszlopot a kategóriacímkéknek, az 1. oszlopot az értékeknek használja; a 0. sor a sorozatnevet tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verzióra van szükség, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az összehasonlítás az alábbiakban mutatja a három fájl azonos adatát. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: a Gap szünetelteti a vonalat a 3. napon, a Zero a vonalat nullához vonja, a Span összeköti a 2. és a 4. napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagram esetén mindhárom mód könnyen összehasonlítható. Oszlop‑ és sávdiagramoknál nincs vonal, amely összekötné a hiányzó kategóriát, ezért a `Span` nem tudja megjeleníteni a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlóan nézhet ki. Ugyanígy egy szórt diagram csak jelölőkkel nem rendelkezik vonallal. Ne várjon három különböző eredményt minden diagramtípus esetén; ellenőrizze a kimenetet a használt típushoz.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv‑ vagy oszlopcsoportok közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a csoportra. Nagyobb érték több helyet hoz létre a csoportok között; kisebb érték sűrűbbé teszi őket.

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

Az összes, a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) felsorolásban felsorolt diagramtípus használ diagramadatot, de sorozataik nem minden esetben rendelkeznek ugyanazzal az értékstruktúrával vagy beállításokkal. Például a kategóriadiagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket. A sorozattípushoz illeszkedő adatpont‑létrehozó módszert használja. Az olyan opciók, mint az átfedés és a hézag szélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Az [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Egy újonnan létrehozott diagram tartalmaz alapértelmezett adatot?**

Igen. Alapértelmezés szerint az [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) mintaként sorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket törölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés segítségével diagramot hozhat létre alapértelmezett adat nélkül is.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategóriacímkék és adatpont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) celláira mutatnak. Egy hivatkozott cella módosítása frissíti a hozzá tartozó diagramelemet. Egyedi adat építésekor tartsa a kategóriasorokat és a sorozat‑érték sorokat összehangoltan, hogy minden pont a megfelelő kategória alatt jelenjen meg.

**Hogyan töröljek egy pontot anélkül, hogy a teljes sorozatot törölném?**

Állítsa a releváns értékcellát `null`‑ra, hogy a pont kategóriahelye üres pontként maradjon. Az [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) metódust csak akkor használja, ha minden pontot el akar távolítani az adott sorozatból. Ha a kategóriákat is törli, frissítse minden sorozatot, hogy értékeik továbbra is illeszkedjenek a kategória‑gyűjteményhez.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) beállítástól függ. A támogatott diagramok megjeleníthetik a hiányzó adatokat hézagként, nulla értékként vagy a szomszédos pontok összekapcsolásával. Válassza ki a beállítást, amely a hiányzó adatok jelentését legjobban tükrözi a prezentációjában. Tekintse meg a **[Control the Display of Empty Cells](#control-the-display-of-empty-cells)** részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázzák a negatív értékeket?**

Az támogatott sáv‑, oszlop‑ és buborék sorozatok esetén hívja meg az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metódust, és állítsa be a színt az [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) visszaadott értékkel. Egy egyedi pont viselkedését felülírhatja az [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) metódussal. Ezek a módszerek a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adatpont‑formázás precedál az adott pontnál. A többi pont továbbra is a sorozat explicit formátumát vagy, ha az nincs meghatározva, az automatikus diagramstílust és témát használja. A csoport‑beállítások, mint az átfedés és a hézag szélesség, a layoutra vonatkoznak, nem pedig pont‑szintű formázási felülírásra.

**Van korlát a diagramban lévő sorozatok számát illetően?**

Az Aspose.Slides nem szab ki különálló fix sorozatszám‑korlátot. Gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti távolság növeléséhez, vagy csökkentse a közelebbi elhelyezkedéshez.