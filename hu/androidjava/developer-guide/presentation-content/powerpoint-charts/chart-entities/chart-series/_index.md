---
title: "Kezelje a diagram adat sorozatokat prezentációkban Androidon"
linktitle: "Adatsorozat"
type: docs
url: /hu/androidjava/chart-series/
keywords:
- "diagram sorozat"
- "sorozat átfedés"
- "sorozat szín"
- "sorozat név"
- "adatpont"
- "munkafüzet cella"
- "sorozat hézag"
- "negatív érték"
- "PowerPoint"
- "prezentáció"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket Android prezentációkban."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagram adat-munkafüzetben tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) egy kapcsolódó értékcsoportot képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) objektumok a sorozatok által közösen használt címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pont értékek tehát [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) objektumokhoz kapcsolódnak, nem csupán megjelenő szövegként tárolódnak.

Tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatnevekre, az 0. oszlopot a kategórianévre, a fennmaradó cellákat pedig a sorozatértékekre. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)‑nek átadott munkalap‑, sor‑ és oszlopindexek nullára kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállítások három különböző hatókörben léteznek:

- Sorozatszintű beállítások, például a [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) biztosítja az alapértelmezett megjelenést egy sorozat összes pontjára.
- Adatpont beállítások, például a [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) felülírja a sorozat megjelenését egy adott ponton.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) segítségével érheti el, ha például átfedés vagy hézag szélesség beállítására van szükség.

Ha nincs kifejezetten pont‑ vagy sorozat‑kitöltés megadva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása élvez elsőbbséget az adott pontra.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) megadja, hogy a 2D diagramban a sávok vagy oszlopok milyen mértékben fednek át, -100 és 100 százalék között. Ez csak olvasható leképezése a szülő sorozatcsoport beállításának. Használja a [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) metódust a csoportban lévő minden kompatibilis sorozat frissítéséhez. Ez a beállítás azokban a diagramtípusokban alkalmazható, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; nem érinti a kombinált diagramok nem kapcsolódó sorozatcsoportjait.

A következő példa az első sorozatot tartalmazó csoport átfedését állítja be:

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

Használja a [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) metódust az egész sorozatra vonatkozó alapértelmezett kitöltés beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, annak [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését az adott pontra.

A következő példa egy szilárd kék kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagram adat-munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely egy klaszter oszlopdiagramhoz jön létre, a B1 cella a 0. sorban, 1. oszlopban található, és az első sorozat nevét tartalmazza. Az alábbi példában szereplő névkonstansok ezt a struktúrát teszik egyértelművé:

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

A cellát közvetlenül is frissítheti a [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) már hivatkozza. Ez a megközelítés elkerüli, hogy egy meglévő diagram esetén egy adott sorra és oszlopra támaszkodjon:

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

Összetett sorozatnév hasznos, ha a termék neve és a jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` a B1‑ben és a `2026` a C1‑ben egyesíthető egyetlen sorozatnévvé, miközben mindkét rész hivatkozik a forráscelláira.

Használja a [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) metódust a névtartomány lekéréséhez, majd adja át ezt a gyűjteményt a [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) metódusnak. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák szerepelnek‑e: a `true` kizárja őket, a `false` pedig beleveszi. Ebben a példában a `false` értéket használjuk, hogy minden cella szerepeljen a névtartományban.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 csak a sorozat nevét adja; az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket szolgáltatja.

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

    // Ez a két cella adja a sorozat nevét.
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

Az eredményül kapott sorozat neve `Product A 2026`, a két cellaérték között szóközzel. A jelmagyarázat ezt egy bejegyzésként jeleníti meg mindkét oszlopra. Az alábbi kép szemlélteti az eredményt:

![Oszlopdiagram Észak és Dél értékekkel, és a kompozit sorozatnév Product A 2026 a jelmagyarázatban](composite_series_name.png)

## **Az automatikus sorozatkitöltőszín lekérése**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozat indexéből és a diagram stílusából számított színt Android ARGB szín‑egész számként. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs explicit módon meghatározva. A metódus meghívása csak a számított színt olvassa, nem állít be új kitöltést.

A következő példa kiírja minden alapértelmezett sorozat automatikus szín‑egész számát:

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

A pontos egész szám értékek a diagram stílusától és témájától függenek.

## **Negatív értékek kitöltőszínének invertálása egy diagram sorozatban**

Sáv-, oszlop- és buboréksorozatok esetén a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) segítségével megjeleníthetők a negatív értékek eltérő kitöltéssel. Állítsa be a szabályos sorozat kitöltését szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) metódussal. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük módosul.

Az alábbi példa a alapértelmezett diagram adatot egy sorozattal helyettesíti. A munkalap 0. sora tartalmazza a sorozat nevét, a 0. oszlop a kategórianeveket, az 1. oszlop pedig az értékeket:

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

![Az invertált szilárd kitöltőszín](inverted_solid_fill_color.png)

Az invertálást egy ponton a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)‑nel is engedélyezheti. Az alábbi példában a sorozatra tiltjuk az invertálást, csak a kiválasztott ponton engedélyezzük. A pont negatív értéket is kap, hogy a hatás látható legyen:

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

Egy pontot úgy tehet üresé, hogy a mögöttes munkafüzet celláját `null`‑ra állítja, anélkül, hogy a többi pontot eltávolítaná. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--)‑val érhető el. Az adatpont ugyanabban a kategóriapozícióban marad, de a diagram a beállításai szerint üresként kezeli.

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

A szórt diagramok külön X és Y cellákat használnak, a buborékdiagramok pedig egy méretcellát is. Csak azt a cellát törölje, amely a törlendő értéket tartalmazza. Ne hívja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metódust, ha csak egy pontot akar megtartani, mert ez a metódus az egész sorozat adatpontjait eltávolítja.

## **Üres cellák megjelenítésének vezérlése**

A rejtett, de értéket tartalmazó cellák külön esetet jelentenek az üres celláktól. A rejtett munkalapsorok és oszlopok adatainak be- vagy kizárásához lásd az [Include Data from Hidden Rows and Columns](/slides/hu/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) szakaszt.

Egy üres munkafüzetcellát hiányzó adatként értelmeznek; egy `0` értéket tartalmazó cella ismert numerikus értéket jelent. Hívja a [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metódust `null`‑lal, hogy a cella üres legyen. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellák beállításától.

Használja a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódust, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogyan kerülnek ábrázolásra a hiányzó értékek, anélkül, hogy a munkafüzet celláját nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy egy sorozatos vonaldiagramot hoz létre, a 3. nap értékét törli, és minden mód esetén elmenti ugyanazt a diagramot. Bemeneti fájl nem szükséges. Az [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) a 0. munkalapot, az 0. oszlopot használja a kategóriacímkékhez, az 1. oszlopot az értékekhez; a 0. sor a sorozat nevét tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

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

    // Hagyja a 3. napot valóban üresen, miközben megtartja a kategóriáját és az adatpontját.
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

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Vonaldiagramok azonos adatokkal: Gap szünetet okoz a vonalon a 3. napnál, Zero leejti a vonalat nullára, és Span összeköti a 2. és a 4. napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagram mindhárom módot egyszerűen összehasonlíthatóvá teszi. Az oszlop‑ és sávdiagramok nem rendelkeznek vonallal, amely áthidalná a hiányzó kategóriát, ezért a `Span` nem hoz létre az alábbiakban látható kapcsolódó szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, a csak jelölőkkel rendelkező szórt diagramnak nincs vonala a kapcsoláshoz. Ne számítson három különböző eredményre minden diagramtípus esetén; ellenőrizze a kimenetet a saját típusához.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv‑ vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust egyszer a csoporton. A nagyobb érték több helyet hoz létre a csoportok között; a kisebb érték szorosabb elrendezést eredményez.

A következő példa módosítja a hézag szélességét, és csak a végső prezentációt menti:

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

Az összes, a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) felsorolt diagramtípus használ diagram adatot, de sorozataik nem minden esetben rendelkeznek azonos értékstruktúrával vagy beállításokkal. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket. A sorozattípusnak megfelelő adat‑pont létrehozó metódust kell használni. Az olyan beállítások, mint az átfedés és a hézag szélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoport‑szintű ábrázolási beállításokat osztoznak. Egy kombinált diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) mintaként sorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket törölheti a teljesen egyedi adatkészlet hozzáadása előtt. Egy túlterhelés (overload) szintén létrehozhat diagramot alapértelmezett adat nélkül.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sorozatnevek, kategória címkék és adat‑pont értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Amikor saját adatot épít, tartsa összehangoltan a kategória‑sorokat és a sorozat‑érték‑sorokat, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan töröljek egyetlen pontot a teljes sorozat helyett?**

Állítsa a releváns értékcellát `null`‑ra, így a pont kategóriapozíciója megtartásra kerül üres pontként. A [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--)‑t csak akkor használja, ha valóban az adott sorozat összes pontját el akarja távolítani. Ha a kategóriákat is törli, minden sorozatot frissítenie kell, hogy értékeik a kategória‑gyűjteménnyel továbbra is egyezzenek.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)‑ben beállított módtól függ. A támogatott diagramok megjeleníthetik az üreseként jelölt pontokat hézagokként, nullákként, vagy a szomszédos pontok összekapcsolásával. Válassza a hiányzó adatok jelentésének megfelelő beállítást. Lásd a [Üres cellák megjelenítésének vezérlése](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv‑, oszlop‑ és buborék sorozatok esetén hívja a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)‑t, és állítsa be a színt a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)‑vel. Egy egyedi pont formázását a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)‑vel felülírhatja. Ezek a metódusok a formázásra hatnak, nem a tárolt numerikus értékekre.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adat‑pont formázás elsőbbséget élvez az adott ponton. A többi pont továbbra is a sorozat explicit formátumát vagy, ha a sorozat formátuma nincs definiálva, az automatikus diagram‑stílust és témát használja. A csoport‑szintű beállítások, mint az átfedés és a hézag szélesség, az elrendezést szabályozzák, nem pont‑szintű formázási felülírások.

**Van korlát a diagramban szereplő sorozatok számát illetően?**

Az Aspose.Slides nem szab külön fix sorozatszám‑korlátot. Gyakorlatban a prezentáció fájlkorlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a használható felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Hívja a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)‑t a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti térköz szélesítéséhez, vagy csökkentse a csoportok közelebb hozásához.