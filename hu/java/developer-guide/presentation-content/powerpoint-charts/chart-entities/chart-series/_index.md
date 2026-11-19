---
title: Diagram adatsorok kezelése prezentációkban Java
linktitle: Adatsorok
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
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és a negatív értékeket prezentációkban Java-val."
---
## **Áttekintés**

A diagram a megjelenített értékeket tárolhatja munkafüzetcellákban vagy közvetlenül numerikus literálokként. Egy [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) egy kapcsolódó értékkészletet képvisel, és minden [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) egy pontot jelöl abban a sorozatban. Az [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Az alapértelmezett adatokkal létrehozott diagramokban a sorozatnevek, kategóriák és pontértékek az [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) objektumokat használják a diagram munkafüzetéből.

Az általános kategória diagramnál az alapértelmezett munkafüzet a 0. sorban tárolja a sorozatneveket, a 0. oszlopban a kategórianéveket, a többi cella pedig a sorozatértékeket. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)‑nek átadott munkalap, sor és oszlop indexek nullával kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne tételezzük fel, hogy minden létező diagram ezt a szerkezetet használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékét módosítaná.

A diagram beállításainak három különböző hatóköre van:

- Sorozat‑szintű beállítások, például [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) adják meg az alapértelmezett megjelenést az adott sorozat minden pontjához.
- Adatpont‑szintű beállítások, például [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) felülírják a sorozat megjelenését egy adott pont esetén.
- Csoportbeállítások vonatkoznak a kompatibilis sorozatokra, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/)‑hez tartoznak. A csoportot az [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--)‑on keresztül érheti el, ha például átfedés vagy hézag szélesség beállítására van szükség.

Ha nem ad meg kifejezett kitöltést pont vagy sorozat szintjén, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása lesz előnyben a adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

Egy csoportos henger diagramnál tekintse meg, hogy a [3D sorozattípus vagy oszlopforma módosítása](/slides/hu/java/3d-chart/#change-the-3d-series-type-and-bar-shape) hogyan befolyásolja az első sorozatot.

## **Sorozatértékek beállítása numerikus literálokkal**

Használjon numerikus literálokat, ha a sorozatértékek alkalmazásadatokból vagy számításokból származnak, és nem szükséges munkalapcella hivatkozás. Hívja meg a [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-)‑t a [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) használatával, mielőtt minden pont [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) eredményét a [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-)‑vel rendeli.

A gyűjteménybeállítás szabályozza az adott sorozat összes pontjának forrástípusát. Minden pont [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) metódusa jelzi a kiválasztott típust; ezt a gyűjteménybeállítással módosíthatja. `Worksheet` esetén a [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--)‑t használja a hivatkozott cella eléréséhez. `DoubleLiterals` esetén a [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) vagy a `setAsLiteralDouble` segítségével olvashatja vagy írhatja a számot közvetlenül.

Az alábbi példa oszlopdiagramot hoz létre alapértelmezett sorozattal és kategóriákkal, majd a meglévő első sorozat pontjainak értékét 10, 20 stb. számokra állítja. A prezentációt elmenti, újra megnyitja, és kiírja a tárolt értékeket.

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

A pontérték forrástípusa különáll a [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--)‑tól, amely a diagram belső vagy külső munkafüzet konfigurációját jelzi. A numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is rendelkezésre áll a kategória címkék, sorozatnevek és a többi sorozat számára. Tekintse meg a [Diagram munkafüzet](/slides/hu/java/chart-workbook/) oldalt a munkafüzet kezeléséhez.

Szórt és buborék diagramok esetén használja a [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) és a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) metódusokat a [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) és a [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) forrásának kiválasztásához. A buborék diagramok további [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-)‑t használnak a [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--) esetén. Minden alkalmazandó forrást állítson `DoubleLiterals`‑ra, mielőtt a számot a `setAsLiteralDouble` metódussal rendeli.

## **Diagram sorozat átfedésének beállítása**

Az [IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) -12‑tól 100‑ig (százalékban) adja meg, hogy a sávok vagy oszlopok mennyire fednek egymást 2D diagramon. Ez a beállítás csak olvasható módon tükrözi a szülő sorozatcsoport beállítását. Az [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-)‑val frissítheti az összes kompatibilis sorozatot ebben a csoportban. Ez a lehetőség a csoportos sávok vagy oszlopok megjelenítésére vonatkozik; kombinációs diagramokban a nem kapcsolódó sorozatcsoportokat nem érinti.

Az alábbi példa beállítja az átfedést a első sorozatot tartalmazó csoportnál:

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

![The series overlap](series_overlap.png)

## **Sorozat kitöltőszín módosítása**

Használja az [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) metódust a teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését az adott pontnál.

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

![The color of the series](series_color.png)

## **Sorozat nevének módosítása**

A sorozat neve a diagram adatmunkafüzetében tárolódik, és általában a legendában jelenik meg. Az alapértelmezett munkafüzet egy csoportos oszlopdiagramhoz a B1 cella (0. sor, 1. oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok a struktúrát explicit módon tükrözik:

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

A [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) által már hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli egy adott sor és oszlop feltételezését egy meglévő diagramban:

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

### **Sorozat létrehozása több cellából álló névvel**

Kompozit sorozatnév akkor hasznos, ha a termék neve és a beszámolási időszak különböző munkafüzetcellákban van tárolva. Például a `Product A` a B1‑ben, a `2026` a C1‑ben, és egyetlen sorozatnevet hozhat létre úgy, hogy mindkét cella forrása megmarad.

Használja az [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) metódust a névtartomány lekéréséhez, majd adja át a gyűjteményt az [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)‑nek. A `skipHiddenCells` argumentum határozza meg, hogy a rejtett cellák bekerüljenek-e: `true` kizárja őket, `false` pedig beleveszi. Ebben a példában `false` értékkel minden cellát felveszünk a névtartományba.

Az alábbi példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 csak a sorozatnevet tartalmazza; az A2:A3 a kategória címkéket, a B2:B3 pedig a numerikus értékeket szolgáltatja.

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

    // Ezek a két cella biztosítja a sorozat nevét.
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

Az eredményül kapott sorozatnév `Product A 2026`, egy szóközzel a két cellaérték között. A legendában ez egyetlen bejegyzésként jelenik meg mindkét oszlophoz. Az alábbi kép mutatja az eredményt:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Automatikus sorozat kitöltőszín lekérdezése**

Az [IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozat indexéből és a diagram stílusából számított színt. Ez a szín akkor használatos, ha a sorozat kitöltése nincs kifejezetten meghatározva. A metódushívás csak a kiszámított színt olvassa; új kitöltést nem rendeli hozzá.

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

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

A pontos színek a diagram stílusától és témájától függenek.

## **Invertált kitöltőszín beállítása egy diagram sorozathoz**

Oszlop-, sáv- és buborék sorozatoknál az [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) segítségével negatív értékek más színnel jeleníthetők meg. Állítsa be a normál sorozatkitöltést szilárdra, engedélyezze az invertálást, és a negatív érték színét a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)‑val adja meg. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

Az alábbi példa az alapértelmezett diagramadatot egy sorozattal helyettesíti. A 0. munkalap sor 0 a sorozat nevét, az oszlop 0 a kategória neveket, az oszlop 1 pedig az értékeket tartalmazza:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Egy pont invertálását az [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) metódussal is engedélyezheti. Az alábbi példában a sorozat invertálása ki van kapcsolva, csak a kiválasztott pontnál van bekapcsolva, és a pont negatív értéket kap, hogy a hatás látható legyen:

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

Egy pont üresen hagyásához a többi pontot érintés nélkül, állítsa a mögöttes munkafüzet celláját `null`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--)‑n keresztül érhető el. Az adatpont ugyanazon kategóriahelyen marad, de a diagram a beállított „üres érték” szabályok szerint üresként kezeli.

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

Szórt diagramok külön X és Y cellákat, a buborék diagramok pedig egy méret cellát használnak. Csak azt a cellát törölje, amelyik az eltávolítandó értéket tartalmazza. Ne hívja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)‑t, ha a többi pontot meg akarja tartani, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenésének irányítása**

A rejtett, de értéket tartalmazó cellák külön helyzetet jelentenek az üres celláktól. A rejtett munkalapsorok és -oszlopok adatainak fel- vagy letiltásához lásd a [Rejtett sorok és oszlopok adatainak felvétele](/slides/hu/java/chart-workbook/#include-data-from-hidden-rows-and-columns) témát.

Egy üres munkafüzetcell a hiányzó adatot jelenti; egy `0` értéket tartalmazó cella ismert numerikus értéket jelent. Hívja meg az [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-)‑t `null`‑val, hogy a cellát üressé tegye. A numerikus nulla minden esetben nulla marad, függetlenül az üres‑cellás beállítástól.

Használja az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)‑t, hogy kiválassza, a diagram hogyan jelenítse meg az üres cellákat. Ez a beállítás az egész diagramra vonatkozik. Megváltoztatja, hogyan ábrázolják a hiányzó értékeket, anélkül, hogy a munkafüzet cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3. nap értékét, és mindhárom móddal elmenti a diagramot. Bemeneti fájlra nincs szükség. Az [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) a 0‑ás munkalapot, a 0‑ás oszlopot használja a kategória címkékhez, az 1‑es oszlopot az értékekhez; a 0‑ás sor a sorozat nevét tárolja. A végső adatsor `10, 20, empty, 30, 40`.

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

Minden kimeneti fájl a mentéskor beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy változatot szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás mindhárom fájlban ugyanazt az adatot mutatja. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típusától függ. Egy vonaldiagram esetén könnyen összehasonlítható mindhárom mód. Oszlop- és sávdiagramoknál nincs vonal, amely összekötné a hiányzó kategóriát, ezért a `Span` nem tudja létrehozni a fent látható összekötő szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop akár hasonlóan is megjelenhet. Hasonlóan, egy csak jelölőkkel rendelkező szórt diagram sem rendelkezik összekötő vonallal. Nem minden diagramtípusnál várható három különálló eredmény; ellenőrizze a saját diagramtípusához tartozó kimenetet.

## **Sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv- vagy oszlopcsoportok között lévő távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyedi sorozathoz. Hívja meg egyszer a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)‑t a csoporton. Nagyobb érték nagyobb távolságot hoz létre a csoportok között; kisebb érték szorosabb elrendezést eredményez.

Az alábbi példa módosítja a hézag szélességét, és csak a végleges prezentációt menti el:

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

A sorozatvonalak vizuálisan összekötik a diagram kapcsolódó részeit. Használja a [IChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSeriesLines-boolean-) metódust a támogatott “stacked bar” és “OfPie” diagramokban. Két dimenziós “stacked bar” és “column” diagramokban a vonalak a megfelelő halmozott határokat kötik össze a kategóriák között. “Pie of Pie” és “Bar of Pie” diagramokban a fő diagramot kapcsolják a másodlagos diagramhoz. Ez a beállítás nem általános összekötő minden más diagramtípushoz.

A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--)‑on keresztül érheti el. A beállítás a csoport minden sorozatára vonatkozik. Az [IChartSeries.hasSeriesLines](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#hasSeriesLines--) csak olvasható, és a szülő csoport beállítását tükrözi; a csoport setterét kell használni a módosításhoz.

Az alábbi példa egy [PieOfPie](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#PieOfPie) diagramot hoz létre alapértelmezett adatokkal. Elmenti ugyanazt a diagramot sorozatvonalakkal engedélyezve, majd letiltva, így két prezentációt hozva létre összehasonlítás céljából.

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
| A két vonal összeköti a fő tortát a másodlagos tortával. | Mindkét torta látható, de a kapcsoló vonalak rejtve vannak. |

A sorozatvonalak különböznek az adatcímke vezetővonalaitól, amelyek a címkéket kötik az adatpontokhoz; a rácsvonalaktól, amelyek a diagram tengelyein jelölik az intervallumokat; valamint a vonaldiagramon megjelenő vonalakól, amelyek az adatértékeket ábrázolják. Ez a beállítás nem befolyásolja az említett elemeket.

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) felsorolásban szereplő diagramtípus használ diagramadatokat, de sorozataik nem minden esetben rendelkeznek ugyanazzal az értékstruktúrával vagy beállításokkal. Például a kategória diagramok kategóriákat és értékeket, a szórt diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket használnak. Válassza a sorozattípusnak megfelelő adatpont‑létrehozó metódust. Az átfedés és hézag szélesség beállításai csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Az [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinációs diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram összes sorozatát.

**Egy újonnan létrehozott diagram tartalmaz alapértelmezett adatokat?**

Igen. Alapértelmezés szerint az [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) mintaként sorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategóriagyűjteményeket megtisztíthatja, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés szintén képes diagramot létrehozni alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sorozatnevek, kategória címkék és adatpont‑értékek az [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat felépítésekor tartsa összehangoltan a kategóriasorokat és a sorozat‑érték sorokat, hogy minden pont a kívánt kategória alatt jelenjen meg.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`‑ra, hogy a pont kategóriahelye üres pontként maradjon. Használja csak akkor az [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)‑t, ha valóban az összes pontot el kívánja távolítani az adott sorozatból. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek továbbra is illeszkedjenek a kategória‑gyűjteményhez.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)‑ban beállított értéktől függ. A támogatott diagramok megjeleníthetik az üres részeket hézagként, nulla értékekként vagy a szomszédos pontok összekapcsolásával. Válassza a hiányzó adatok jelentésének megfelelő beállítást. Tekintse meg a [Üres cellák megjelenésének irányítása](#control-the-display-of-empty-cells) szekciót a teljes példa és vizuális összehasonlítás érdekében.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv-, oszlop- és buborék sorozatok esetén hívja meg a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)‑t, és állítsa be a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)‑ban visszakapott színt. Egyéni pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)‑val felülbírálhatja a viselkedést. Ezek a metódusok a formázást, nem a tárolt numerikus értékeket befolyásolják.

**Melyik formázás nyer, ha a sorozat és a pont is formázva van?**

Az explicit adatpont‑formázás előnyben részesül az adott pontnál. A többi pont továbbra is az explicit sorozat‑formázást, vagy ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoportbeállítások, mint az átfedés és a hézag szélesség, az elrendezést irányítják, és nem pont‑szintű formázási felülírások.

**Van korlát arra, hogy hány sorozat lehet egy diagramban?**

Az Aspose.Slides nem szab be külön fix sorozatszám‑korlátot. Gyakorlatban a prezentáció fájlmérete, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit módosítsak, ha az oszlopok túl közel vagy túl messze vannak egymástól?**

Hívja meg a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)‑t a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti távolság bővítéséhez, vagy csökkentse, hogy a csoportok közelebb kerüljenek egymáshoz.