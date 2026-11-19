---
title: Diagram adatsorozatok kezelése prezentációkban Androidon
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
description: "Ismerje meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket Androidos prezentációkban."
---
## **Áttekintés**

Egy diagram tárolhatja a megjelenített értékeket a munkafüzet celláiban vagy közvetlenül numerikus literálokként. Egy [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) egy kapcsolódó értékkészletet képvisel, és minden [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) a sorozat egy pontját jelöli. [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatnevek, kategóriák és pontértékek [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) objektumokat használnak a diagram munkafüzetéből.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sort a sorozatneveknek, a 0‑s oszlopot a kategória neveknek, a többi cellát pedig a sorozat értékeknek használja. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)‑nek átadott munkalap, sor és oszlop indexek nullával kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozat szintű beállítások, például [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) biztosítják az alapértelmezett megjelenést egy sorozat összes pontjához.
- Adatpont szintű beállítások, például [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) felülírják a sorozat megjelenését egy pont esetén.
- Csoport beállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanolyan [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) tagjai. A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) segítségével érheti el, ha például átfedés vagy hézag szélesség beállítását szeretné módosítani.

Ha nincs kifejezetten beállítva pont vagy sorozat kitöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása élvez elsőbbséget az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

Egy klaszterezett henger diagram esetén tekintse meg, hogy a [changing the 3D series type or bar shape](/slides/hu/androidjava/3d-chart/#change-the-3d-series-type-and-bar-shape) hogyan befolyásolja az első sorozatot.

## **Sorozatértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, ha a sorozatértékek alkalmazásadatokból vagy számításokból származnak, és nem szükséges munkalap cellahivatkozás. Hívja meg a [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-)‑t a [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) értékkel, mielőtt minden pont [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) eredményét a [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-)‑vel állítaná be.

A gyűjtemény beállítása szabályozza az összes pont értékének forrástípusát az adott sorozatban. Minden pont értékének [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) metódusa jelzi a kiválasztott típust; ezt a gyűjtemény beállításával módosíthatja. `Worksheet` esetén a [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) használható a hivatkozott cella eléréséhez. `DoubleLiterals` esetén a [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) vagy a `setAsLiteralDouble` segítségével olvashat vagy írhat számot közvetlenül.

A következő példa egy oszlopdiagramot hoz létre alapértelmezett sorozatokkal és kategóriákkal, majd a számított 10, 20 stb. értékeket rendeli az első sorozat meglévő pontjaihoz. A prezentációt elmenti, újra megnyitja, és kiírja a tárolt értékeket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

A pontérték forrástípusa különbözik az [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--)‑tól, amely a diagram belső vagy külső munkafüzet konfigurációját azonosítja. A numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategória címkék, sorozatnevek és a többi sorozat számára. A munkafüzet kezeléséről lásd a [Chart Workbook](/slides/hu/androidjava/chart-workbook/) oldalt.

Szórás- és buborékdiagramoknál a [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) és a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) használható a [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) és [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) forrásainak kiválasztásához. A buborékdiagramok a [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) segítségével állítják be a [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) forrását. Minden alkalmazandó forrást állítson `DoubleLiterals`‑re, mielőtt a `setAsLiteralDouble` metódussal számokat rendelnél hozzá.

## **A diagram sorozat átfedésének beállítása**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) azt jelzi, hogy a sávok vagy oszlopok milyen mértékben fednek át egy 2D diagramon, -100 és 100 százalék között. Ez a beállítás a szülő sorozatcsoport beállításának csak olvasható leképezése. A [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) segítségével frissítheti az összes kompatibilis sorozatot a csoportban. Ez az opció a csoportosított sávok vagy oszlopok megjelenítésére alkalmas diagramtípusoknál; nem érinti a kombinált diagramon a nem kapcsolódó sorozatcsoportokat.

A következő példa beállítja az átfedést annak a csoportnak, amely az első sorozatot tartalmazza:

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

![The series overlap](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Használja az [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) metódust a teljes sorozatra vonatkozó alapértelmezett kitöltés beállításához. Ha egy pont már explicit kitöltéssel rendelkezik, annak a [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa egy egységes kék kitöltést alkalmaz az első sorozatra:

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

![The color of the series](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagram adatmunkafüzetében van tárolva, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet egy klaszterezett oszlopdiagram esetén a B1 cella a 0‑s sorban, 1‑s oszlopban található, és az első sorozat nevét tartalmazza. Az alábbi példában szereplő névkonstansok explicit módon szemléltetik ezt a struktúrát:

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

Frissítheti azt a cellát is, amelyet már a [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) hivatkozik. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramban:

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

![The series name](series_name.png)

### **Sorozat létrehozása több cellából származó névvel**

Összetett sorozatnév hasznos, ha a termék neve és a jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` értéket a B1‑ben és a `2026` értéket a C1‑ben egyetlen sorozatnévre kombinálhatja, miközben mindkét rész a forráscellához van kapcsolva.

Használja a [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) metódust a névtartomány lekéréséhez, majd adja át a gyűjteményt a [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)‑nek. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák szerepeljen‑e: `true` kizárja őket, `false` pedig belefoglalja. Ebben a példában `false`‑t használunk, hogy minden cellát felvegye a névtartományba.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák kizárólag a sorozat nevét biztosítják; az A2:A3 cellák a kategória címkéket, a B2:B3 cellák a numerikus értékeket tartalmazzák.

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

Az eredményül kapott sorozatnév `Product A 2026`, egy szóközzel a két cellaérték között. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép szemlélteti az eredményt:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Az automatikus sorozat kitöltőszín lekérdezése**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozat indexéből és a diagram stílusából számított Android ARGB szín egész számát. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten definiálva. A metódus meghívása csak a számított színt olvassa; nem rendel hozzá új kitöltést.

A következő példa kiírja minden alapértelmezett sorozat automatikus színértékét:

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

## **Inverz kitöltőszín beállítása diagram sorozathoz**

Oszlop-, sáv- és buboréksorozatoknál az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) lehetővé teszi, hogy a negatív értékeket más színnel jelenítse meg. Állítsa be a szabályos sorozatkitöltést szilárdra, engedélyezze az inverziót, és adja meg a negatív érték színét az [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa lecseréli az alapértelmezett diagram adatot egy sorozatra. A munkalap 0‑s sora tartalmazza a sorozat nevét, a 0‑s oszlop a kategória neveket, az 1‑s oszlop pedig az értékeket:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Engedélyezheti az inverziót egyetlen pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) segítségével. Az alábbi példában a sorozatra vonatkozó inverzió ki van kapcsolva, és csak a kiválasztott pontra van bekapcsolva. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresen hagyásához a többi pont eltávolítása nélkül, állítsa a mögöttes munkafüzet celláját `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--)‑val érhető el. Az adatpont ugyanazon kategória pozícióban marad, de a diagram a beállított üres‑érték opciók szerint üresként kezeli.

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

A szórásdiagramok külön X és Y cellákat használnak, a buborékdiagramok pedig méretcellát is. Csak azt a cellát törölje, amely a törlendő értéket tartalmazza. Ne hívja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metódust, ha a többi pontot meg akarja tartani, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének szabályozása**

A rejtett cellák, amelyek értéket tartalmaznak, külön kategória az üres celláktól. A rejtett munkalap sorok és oszlopok adatainak felvételéhez vagy kihagyásához lásd a [Include Data from Hidden Rows and Columns](/slides/hu/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) cikket.

Az üres munkafüzetcellák hiányzó adatot jelentenek; a `0` értékű cella ismert numerikus értéket jelent. Hívja meg az [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metódust `null`‑val, hogy a cellát üressé tegye. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellás beállítástól.

Használja a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódust, hogy kiválassza, hogyan jelenítse meg a diagram az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogyan vannak ábrázolva a hiányzó értékek, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3. nap értékét, és minden módot elmenti ugyanabba a diagramba. Nem szükséges bemeneti fájl. Az [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) a 0‑s munkalapot, 0‑s oszlopot használja a kategória címkékhez, és az 1‑s oszlopot az értékekhez; a 0‑s sor a sorozat nevet tartalmazza. A végső adat `10, 20, empty, 30, 40`.

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

Minden kimeneti fájl tárolja a mentés előtt beállított módot: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy változatot szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagram esetén mindhárom mód könnyen összehasonlítható. Az oszlop- és sávdiagramoknál nincs vonal, amely a hiányzó kategória felett összeköttetést hozna létre, így a `Span` nem tudja előállítani a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen egy csak jelölőkkel rendelkező szórásdiagramnak sincs vonala, amely összekötne. Ne várjon három különböző eredményt minden diagramtípusnál; ellenőrizze a kimenetet a használt típusra.

## **A sorozat hézag szélességének beállítása**

A hézag szélesség a szomszédos sáv vagy oszlop klaszterek közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a csoporton. Egy nagyobb érték több helyet hoz létre a klaszterek között; egy kisebb érték sűrűbbé teszi őket.

A következő példa megváltoztatja a hézag szélességet, és csak a végső prezentációt menti:

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

![The gap width](gap_width.png)

## **Sorozatvonalak megjelenítése vagy elrejtése**

A sorozatvonalak vizuálisan összekötik a diagram kapcsolódó részeit. Használja a [IChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSeriesLines-boolean-) metódust a támogatott halmozott sáv és OfPie diagramokban való megjelenítéshez vagy elrejtéshez. Két dimenziós halmozott sáv- és oszlopdiagramokban a vonalak a megfelelő halom határait kötik össze a kategóriák között. Pie of Pie és Bar of Pie diagramokban a vonalak a fő diagramot kötik össze a másodlagos diagrammal. Ez a beállítás nem általános célú csatlakozó más diagramtípusokhoz.

A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) segítségével érheti el. A beállítás a csoport minden sorozatára vonatkozik. Az [IChartSeries.hasSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#hasSeriesLines--) csak olvasható, és a szülő csoport beállítását tükrözi; a csoport setterét hívja meg a frissítéshez.

A következő példa egy [PieOfPie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#PieOfPie) diagramot hoz létre alapértelmezett adatokkal. Mentse el ugyanazt a diagramot sorozatvonalakkal engedélyezve, majd letiltva, hogy két prezentációt kapjon összehasonlításra.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Sorozatvonalak engedélyezve | Sorozatvonalak letiltva |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| A két vonal összeköti a fő tortát a másodlagos tortával. | Mindkét torta látható, de a csatlakozó vonalak rejtve vannak. |

A sorozatvonalak eltérnek az adatcímke vezető vonalaitól, amelyek a címkéket kötik az adatpontokhoz; a rácsvonalaktól, amelyek a diagram tengelyek mentén jelölik az intervallumokat; és a vonaldiagram vonalai, amelyek az adatértékeket ábrázolják. Ez a beállítás nem szabályozza ezeket az elemeket.

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Minden, a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagram adatot, de a sorozatok nem mindegyiknek ugyanaz a értékstruktúrája vagy beállítása. Például a kategória diagramok kategóriákat és értékeket használnak, a szórás diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Használja a sorozattípusnak megfelelő adatpont‑létrehozó metódust. Az olyan opciók, mint az átfedés és a hézag szélesség, csak a kompatibilis sáv vagy oszlop csoportokra vonatkoznak.

**Mi a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több mint egy csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) mintavörű sorozatokat, kategóriákat és értékeket hoz létre. Szerkesztheti ezeket a cellákat, vagy törölheti a sorozat‑ és kategória‑gyűjteményeket, mielőtt teljesen custom adatot adna hozzá. Egy túlterhelés (overload) is létrehozhat diagramot alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet cellákhoz?**

A sorozatnevek, kategória címkék és adatpont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyedi adat felépítésekor tartsa a kategória sorokat és a sorozat‑érték sorokat igazítottan, hogy minden pont a kívánt kategória alá legyen ábrázolva.

**Hogyan törölhetem egy pontot a teljes sorozat helyett?**

Állítsa a releváns értékcellát `null`‑ra, hogy a pont kategória‑pozíciója üres maradjon. Használja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) csak akkor, ha minden pontot el akar távolítani az adott sorozatból. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek a kategória gyűjteménnyel összhangban maradjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) által konfigurált beállítástól függ. A támogatott diagramok megjeleníthetik a hiányzó adatokat hézagként, nulla értékként vagy a szomszédos pontok összekapcsolásával. Válassza ki a hiányzó adatok jelentésének megfelelő beállítást a prezentációban. Lásd a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példa és vizuális összehasonlítás érdekében.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv, oszlop és buborék sorozatoknál hívja meg a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) és állítsa be a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) által visszaadott színt. Egy egyedi pontnál felülbírálhatja a viselkedést a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) segítségével. Ezek a metódusok a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

Az explicit adatpont‑formázás élvezi az adott pont előnyét. A többi pont a kifejezett sorozatformátumot használja, vagy ha a sorozatformátum nincs definiálva, akkor az automatikus diagram stílus és téma szerinti megjelenést. A csoport‑beállítások, mint az átfedés és a hézag szélesség, a elrendezésért felelnek, nem pont‑szintű formázási felülírások.

**Van-e korlát arra, hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem állapít meg különálló fix sorozatszám‑korlátot. Gyakorlatban a prezentáció fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) megfelelő szülő sorozatcsoporton. Növelje az értéket a klaszterek közti tér növeléséhez, vagy csökkentse a közelebbi elrendezéshez.