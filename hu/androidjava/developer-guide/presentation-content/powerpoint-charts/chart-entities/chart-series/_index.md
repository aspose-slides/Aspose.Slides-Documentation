---
title: Diagramadat-sorozatok kezelése Android prezentációkban
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
description: "Tanulja meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket Android prezentációkban."
---
## **Áttekintés**

A diagram tárolhatja a ábrázolt értékeket a munkafüzet celláiban vagy közvetlenül numerikus literálokként. Egy [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) egy kapcsolódó értékkészletet képvisel, és minden [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) egy pontot jelöl ebben a sorozatban. Az [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatneveket, kategóriákat és pontértékeket [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) objektumokból veszik a diagram munkafüzetéből.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatneveknek, a 0. oszlopot a kategória neveknek, a maradék cellákat pedig a sorozatértékeknek. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) metódusnak átadott munkalap, sor és oszlop indexek 0‑alapúak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például az [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) alapértelmezett megjelenést adnak egy sorozat összes pontjához.
- Adatpont‑szintű beállítások, például az [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) felülírják a sorozat megjelenését egy pont esetében.
- Csoportbeállítások alkalmazandók kompatibilis sorozatokra, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) csoporthoz tartoznak. A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) segítségével érheti el, amikor például átfedés vagy hézag szélesség beállítására van szükség.

Ha nincs kifejezetten pont‑ vagy sorozat‑kitöltés meghatározva, a diagram stílusa és sablonja határozza meg a automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása élvez elsőbbséget az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Sorozatértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, ha a sorozatértékek az alkalmazás adataiból vagy számításaiból származnak, és nincs szükség munkalap cellahivatkozásokra. Hívja a [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) metódust a [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) értékkel, mielőtt minden pont [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) eredményét a [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-) segítségével állítaná be.

A gyűjtemény beállítása szabályozza az adott sorozat összes pont értékének forrástípusát. Egy pont értékének [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) metódusa jelzi a kiválasztott típust; változtassa meg a gyűjtemény beállításán keresztül. `Worksheet` esetén a [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) segítségével érheti el a hivatkozott cellát. `DoubleLiterals` esetén a [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) vagy a `setAsLiteralDouble` használatával olvashatja vagy írhatja a számot közvetlenül.

Az alábbi példa egy oszlopdiagramot hoz létre alapértelmezett sorozatokkal és kategóriákkal, majd a már létező első sorozat pontjaira kiszámított 10, 20, stb. értékeket rendel. A prezentációt elmenti, újra megnyitja, és kiírja a tárolt értékeket.

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

A pontérték forrástípusa elkülönül a [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) beállítástól, amely a diagram belső vagy külső munkafüzet‑konfigurációját azonosítja. A numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategória címkék, sorozatnevek és a többi sorozat számára. Lásd a [Diagramm munkafüzet](/slides/hu/androidjava/chart-workbook/) oldalt a munkafüzet kezeléséhez.

Szórt és buborék diagramok esetén használja a [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) és a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) metódusokat a [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) és a [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) forrásainak kiválasztásához. A buborék diagramok a [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) segítségével állítják be a [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) forrást. Minden alkalmazandó forrást állítson `DoubleLiterals`‑re, mielőtt a `setAsLiteralDouble` metódussal számokat rendelne.

## **A diagram sorozat‑átfedésének beállítása**

Az [IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) metódus arról tájékoztat, hogy a 2D diagram oszlopai vagy sávjai milyen mértékben fednek át egymást, -100‑tól 100‑ig százalékban. Ez a beállítás csak olvasható, mivel a szülő sorozatcsoport beállításnak felel meg. A [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) használatával frissítheti a csoport minden kompatibilis sorozatát. Ez a lehetőség olyan diagramtípusokra vonatkozik, amelyek csoportosított oszlopokat vagy sávokat jelenítenek meg; egy kombinációs diagram nem kapcsolódó sorozatcsoportokra nincs hatással.

Az alábbi példa beállítja az első sorozatot tartalmazó csoport átfedését:

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

Használja az [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) metódust a teljes sorozat alapértelmezett kitöltésének megadásához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak a [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését a pontnál.

Az alábbi példa egy egységes kék kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagram adatmunkafüzetében van tárolva, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely egy csoportosított oszlopdiagramhoz jön létre, a B1 cella (0. sor, 1. oszlop) az első sorozat nevét tartalmazza. Az alábbi példában a névkonstansok expliciten tükrözik ezt a struktúrát:

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

A cellát közvetlenül is frissítheti a [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) által már hivatkozott cellával. Ezzel a megközelítéssel elkerülhető, hogy egy meglévő diagramra egy adott sor és oszlop feltételezésére építsen:

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

### **Sorozat létrehozása több cella nevével**

Összetett sorozatnév akkor hasznos, ha egy termék neve és egy jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` B1‑ben és a `2026` C1‑ben egyetlen sorozatnevébe kombinálható, miközben mindkét rész továbbra is a forráscellához van kapcsolva.

Használja az [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) metódust a névtartomány lekéréséhez, majd adja át ezt a gyűjteményt a [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) metódusnak. A `skipHiddenCells` argumentum szabályozza, hogy a rejtett cellák is szerepeljenek‑e: `true` kizárja őket, `false` pedig beleveszi. Ebben a példában `false`‑t használunk, hogy minden cella szerepeljen a névtartományban.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozatnevet biztosítják; az A2:A3 a kategóriacímkéket, a B2:B3 pedig a numerikus értékeket.

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

    // Külön cellák biztosítják a kategóriákat és a numerikus adatpontokat.
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

Az eredményül kapott sorozatnév `Product A 2026`, egy szóközzel elválasztva a két cella értékét. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép mutatja az eredményt:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Az automatikus sorozat‑kitöltőszín lekérése**

Az [IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) metódus a sorozat indexe és a diagram stílusa alapján számított Android ARGB színt egész számként adja vissza. Ez a szín akkor használatos, amikor a sorozat kitöltése nincs kifejezetten meghatározva. A metódus hívása csak a számított színt olvassa, nem állít be új kitöltést.

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

A pontos egész szám értékek a diagram stílusától és sablonjától függenek.

## **Invertált kitöltőszín beállítása diagram sorozathoz**

Oszlop, sáv és buborék sorozatok esetén az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) használatával a negatív értékek más kitöltéssel jeleníthetők meg. Állítsa be a normál sorozatkitöltést szilárdra, engedélyezze az invertálást, és adja meg a negatív érték színét az [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) segítségével. A negatív számok a munkafüzetben érintetlenül maradnak; csak a megjelenített színük változik.

Az alábbi példa egy sorozattal helyettesíti az alapértelmezett diagramadatot. A munkalap 0. sora a sorozatnevet, a 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket tartalmazza:

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

Inverziót egyetlen pontnál az [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) segítségével is engedélyezheti. Az alábbi példában a sorozatra vonatkozó invertálás ki van kapcsolva, csak a kiválasztott pontnál van bekapcsolva, amelynek negatív értéket is adunk a hatás láthatósága érdekében:

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

Egy pont üresen hagyásához, a többi pontot nem érintve, állítsa a mögöttes munkafüzetcellát `null`‑ra. Oszlopdiagram esetén a ábrázolt érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) metódussal érhető el. Az adatpont ugyanazon kategóriapozícióban marad, de a diagram a beállított üres‑érték opció szerint a pontot üresnek tekinti.

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

A szórt diagramok külön X és Y cellákat használnak, a buborék diagramok méretcellát is. Csak azt a cellát törölje, amely a törlendő értéket tartalmazza. Ne hívja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metódust, ha a többi pontot meg akarja tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének vezérlése**

A rejtett, de értékkel rendelkező cellák más esetet képeznek, mint az üres cellák. A rejtett munkalapról származó sorok és oszlopok adatainak belefoglalásához tekintse meg a [Include Data from Hidden Rows and Columns](/slides/hu/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Egy üres munkafüzetcellát a [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) metódussal `null`‑ra állítva tehet üressé. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellák beállításától.

Az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódussal választhatja ki, hogyan jelenjenek meg az üres cellák. Ez a beállítás az egész diagramra vonatkozik, és úgy módosítja, hogy a hiányzó értékek hogyan kerülnek ábrázolásra, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3. nap értékét törli, és minden módhoz elmenti a diagramot. Bemeneti fájlra nincs szükség. A [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) a 0. munkalapot, az 0. oszlopot használja a kategória címkékhez, az 1. oszlopot az értékekhez; a 0. sor a sorozat nevet tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

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

    // Hagyd a 3. napot valóban üresen, miközben megtartod a kategóriáját és az adatpontját.
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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok ismétlése helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagram esetén mindhárom mód könnyen összehasonlítható. Az oszlop- és sávdiagramoknak nincs vonala, amely összekötné a hiányzó kategóriát, így a `Span` nem tudja létrehozni a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla magaságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, a csak jelölőket tartalmazó szórt diagramnak nincs összekötő vonala. Ne várjon három különböző eredményt minden diagramtípusnál; ellenőrizze a kimenetet a használt típus esetén.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv‑ vagy oszlopklaszterek közötti térköz, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja egyszer a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a csoportra. A nagyobb érték nagyobb távolságot hoz létre a klaszterek között; a kisebb érték sűrűbb elrendezést eredményez.

Az alábbi példa módosítja a hézag szélességét, és csak a végső prezentációt menti el:

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

## **GYIK**

**Mely diagramtípusok támogatják a adat sorozatokat?**

Az összes olyan diagramtípus, amelyet a [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) felsorolás tartalmaz, használ diagramadatokat, de sorozataik nem minden esetben rendelkeznek ugyanazzal az értékszerkezettel vagy beállításokkal. Például a kategória diagramok kategóriákat és értékeket, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket használnak. A sorozattípusnak megfelelő adatpont‑létrehozó metódust kell alkalmazni. Az olyan opciók, mint az átfedés és a hézag szélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek a csoport‑szintű ábrázolási beállításokat osztják meg. Egy kombinációs diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Egy újból létrehozott diagram alapértelmezett adatokat tartalmaz?**

Igen. Alapértelmezés szerint az [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) metódus mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat‑ és kategória‑gyűjteményeket, mielőtt teljesen saját adatkészletet adna hozzá. Egy túlterhelés segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategória címkék és adatpont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat felépítésekor tartsa a kategória sorokat és a sorozat‑érték sorokat összehangoltan, hogy minden pont a kívánt kategória alatt legyen ábrázolva.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`‑ra, így a pont kategória pozíciója üres pontként marad. A [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metódust csak akkor használja, ha az adott sorozat összes pontját el akarja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy értékeik a kategória‑gyűjteménnyel igazodva maradjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) által beállított értéktől függ. A támogatott diagramok megjeleníthetik a hiányzókat hézagként, nullaként vagy a szomszédos pontok összekapcsolásával. Válassza ki a jelentésnek leginkább megfelelő beállítást a prezentációjában. Tekintse meg a [Üres cellák megjelenítésének vezérlése](#control-the-display-of-empty-cells) részt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

Támogatott sáv-, oszlop- és buborék sorozatok esetén hívja az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metódust, és állítsa be a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) által visszaadott színt. Egy egyedi pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) metódussal felülbírálhatja a viselkedést. Ezek a metódusok a formázásra hatnak, nem a tárolt numerikus értékekre.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adatpont‑formázás elsőbbséget élvez az adott pontnál. A többi pont továbbra is az explicit sorozat‑formátumot vagy, ha az nincs definiálva, a automatikus diagramstílust és sablont használja. A csoport‑beállítások, mint az átfedés és a hézag szélesség, elrendezést szabályoznak, és nem pont‑szintű formázási felülbírálások.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem határoz meg különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg az értelmes határt.

**Mit kell módosítani, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Hívja a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a klaszterek közötti térköz bővítéséhez, vagy csökkentse, ha közelebb szeretné helyezni a klasztereket.