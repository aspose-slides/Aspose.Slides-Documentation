---
title: Diagram adat sorozatok kezelése prezentációkban Java nyelven
linktitle: Adatsorozat
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
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban Java-val."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagramadat-munkafüzetben tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartcategory/) objektumok a sorozatok által közösen használt címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [IChartDataCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenő szövegként tárolódnak.

Egy tipikus kategória-diagram esetén az alapértelmezett munkafüzet a 0. sort a sorozatneveknek, a 0. oszlopot a kategórianévnek, a többi cellát pedig a sorozatértékeknek használja. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metódusnak átadott munkalap-, sor- és oszlopindexek nullától kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden létező diagram ezt használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

A diagram beállításai három különböző hatókörben léteznek:

- Sorozatszintű beállítások, például az [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getFormat--) adja meg az alapértelmezett megjelenést egy sorozat összes pontjának.
- Adatpont beállítások, például az [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getFormat--) felülírja a sorozat megjelenését egy adott pontnál.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/) tartoznak. A csoporthoz a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) metódussal férhet hozzá, ha olyan opciókat kell beállítania, mint az átfedés vagy a hézag szélessége.

Ha nincs kifejezetten beállítva pont- vagy sorozatkitöltés, a diagram stílusa és témája határozza meg a automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása előnyben részesül az adott pont esetén.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

Az [IChartSeries.getOverlap](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getOverlap--) megadja, hogy a sávok vagy oszlopok mennyire fedik át egymást egy 2D diagramon, -100 és 100 százalék között. Ez egy csak olvasható leképezése a beállításnak a szülő sorozatcsoportban. Használja a [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) metódust a csoport összes kompatibilis sorozatának frissítéséhez. Ez az opció olyan diagramtípusokra vonatkozik, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; kombinált diagram esetén nem érinti a nem kapcsolódó sorozatcsoportokat.

Az alábbi példa beállítja az átfedést az első sorozatot tartalmazó csoportban:

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

Használja az [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getFormat--) metódust egy egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik explicit kitöltéssel, annak [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa egy egyszínű kék kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagramadat-munkafüzetben tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet, amely egy klaszter oszlopdiagramot hoz létre, a B1 (0. sor, 1. oszlop) cellában tartalmazza az első sorozat nevét. Az alábbi példában a megnevezett állandók ezt a struktúrát teszik explicitté:

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

Frissítheti azt a cellát is, amelyre a [IChartSeries.getName](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getName--) már hivatkozik. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramon:

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

Az [IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín kerül felhasználásra, amikor a sorozat kitöltése nincs explicit módon meghatározva. A metódus meghívása csak a számított színt olvassa, nem rendel új kitöltést.

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

A pontos színek a diagram stílusától és témájától függenek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék-sorozatoknál az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) lehetővé teszi a negatív értékek megjelenítését eltérő kitöltéssel. Állítsa be a szabályos sorozatkitöltést szilárdra, engedélyezze az inverziót, és adja meg a negatív érték színét az [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) metódussal. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa az alapértelmezett diagramadatokat egy sorozatra cseréli. A munkalap 0. sora tartalmazza a sorozat nevét, az 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket:

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

Az inverzió egy pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) metódussal engedélyezhető. Az alábbi példában az inverzió le van tiltva a sorozatra, és csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresen hagyásához anélkül, hogy a többi pontot eltávolítaná, állítsa a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#getValue--) metódussal érhető el. Az adatpont ugyanott marad a kategória pozíciójában, de a diagram a beállításoknak megfelelően üresként kezeli az értékét.

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

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méretcellát is. Csak azt a cellát törölje, amely az eltávolítandó értéket tartalmazza. Ne hívja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapointcollection/#clear--) metódust, ha a többi pontot meg szeretné tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **A sorozat hézagszélességének beállítása**

A hézagszélesség a szomszédos sáv‑ vagy oszlophúrok közti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a csoporton. A nagyobb érték több helyet hoz létre a csoportok között; a kisebb érték sűrűbbé teszi őket.

Az alábbi példa megváltoztatja a hézagszélességet, és csak a végleges prezentációt menti:

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

![A hézagszélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de sorozataik nem mindegyik rendelkezik ugyanolyan értékstruktúrával vagy beállításokkal. Például a kategória-diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Használja a sorozattípusnak megfelelő adatpont‑létrehozó metódust. Az olyan opciók, mint az átfedés és a hézagszélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Tartalmaz egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [IShapeCollection.addChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) példasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategóriagyűjteményeket törölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés biztosíthat diagramot alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategória címkék és adatpont‑értékek az [IChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adatépítéskor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat összehangoltan, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan törölhetem egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcella‑értéket `null`‑ra, hogy a pont kategóriapozíciója üres pontként maradjon. Használja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapointcollection/#clear--) metódust csak akkor, ha az adott sorozat összes pontját el kívánja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy értékeik összhangban legyenek a kategóriagyűjteménnyel.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) beállítástól függ. A támogatott diagramok megjeleníthetik az üres helyeket hézagként, nullákként, vagy a szomszédos pontok összekötésével. Válassza azt a beállítást, amely a hiányzó adatok jelentését tükrözi a prezentációjában.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatok esetén hívja a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metódust, és állítsa be a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) által visszaadott színt. Egyedi pont esetén a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) felülírhatja a viselkedést. Ezek a metódusok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

Az explicit adatpont‑formázás előnyben részesül az adott pontnál. A többi pont továbbra is az explicit sorozatformázást használja, vagy ha a sorozatformázás nincs definiálva, akkor az automatikus diagramstílust és témát. A csoportbeállítások, mint az átfedés és a hézagszélesség, a elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korlátozás a diagramban szereplő sorozatok számát illetően?**

Az Aspose.Slides nem határoz meg különálló, fix sorozatszám‑korlátot. Gyakorlatban a prezentáció fájlkorlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a használható felső határt.

**Mit kell változtatni, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti távolság bővítéséhez, vagy csökkentse a csoportok közelebb hozatalához.