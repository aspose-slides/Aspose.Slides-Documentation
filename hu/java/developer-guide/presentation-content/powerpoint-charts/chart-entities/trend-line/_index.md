---
title: Trendvonalak hozzáadása a prezentációs diagramokhoz Java-ban
linktitle: Trendvonal
type: docs
url: /hu/java/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatványos trendvonal
- egyéni trendvonal
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Röviden adjon hozzá és testreszabjon trendvonalakat a PowerPoint diagramokban az Aspose.Slides for Java segítségével – egy gyakorlati útmutató, amely segít lekötni a közönségét."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet trendvonalakat hozzáadni bemutató diagramokhoz az Aspose.Slides segítségével. Megmutatja, hogyan hozhat létre diagramot, adhat hozzá trendvonalakat a diagram sorozataihoz, és dolgozhat több trendvonal típussal, többek között exponenciálissal, lineárral, logaritmussal, mozgó átlagszámmal, polinommal és hatványoszal.

Leírja továbbá, hogyan adhat hozzá egy egyéni vonalat a diagramhoz egy vonal alakzat beszúrásával, és egy rövid GYIK-ot tartalmaz a trendvonal előre és hátra kiterjesztési értékekkel kapcsolatban, valamint arról, hogy a trendvonalak megmaradnak-e a PDF vagy SVG exportálásakor és a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**

Használja az [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) metódust egy trendvonal hozzáadásához a diagram sorozatához, típusát a [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/) segítségével választhatja ki. A példában egy csoportos oszlopdiagramot hoz létre alapértelmezett adatokkal, és minden három sorozathoz két trendvonalat ad hozzá.

Az exponenciális trendvonal a [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) és a [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) segítségével elrejti az egyenletet és az R-négyzet értéket, míg a lineáris trendvonal piros. A logaritmikus trendvonal a [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) metódust használja egy egyéni címkehez. A mozgó átlag egy három adatpontot tartalmazó [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) értéket és egy egyéni [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-) metódust használ.

A polinomiális trendvonal [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) értéke három, és egy kategóriát nyújt előre a [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-) segítségével. A hatványos trendvonal egy kategóriát nyújt vissza a [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-) segítségével.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Trendvonal metszéspont beállítása**

Használja a [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) metódust a trendvonal Y értékének rögzítéséhez X = 0-nál. Ez a beállítás támogatott lineáris, exponenciális és polinomiális trendvonalaknál.

Például egy termelési költségmodellnek 100 ismert állandó költségnél kell indulnia, még akkor is, ha a nem nulla termelési mennyiségeknél mért értékek más kiindulási alapot sugallnak. Lineáris trendvonal esetén a metszéspont rögzítése a `y = ax + b` egyenletet `b = 100`-ra korlátozza; a meredekség a korláttal együtt illeszkedik az adatokhoz. Ez nem csak egy már illesztett vonalat helyez át. A tengelykereszteződés beállítások szabályozzák, hol találkoznak a diagram tengelyei, nem a trendvonal együtthatóit.

Az alábbi példában egy szórt (XY) diagramot hoz létre 1-től 4-ig terjedő termelési mennyiségekkel és 170, 200, 230 és 260 költségekkel. A diagramot az alapértelmezett automatikus metszésponttal menti, beállítja a metszéspontot 100-ra, és elment egy második PPTX-et. A két fájl csak a metszéspont beállításában különbözik. A trendvonal megjeleníti az egyenletét és visszanyúlik X = 0-ig.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Automatikus számítás esetén ezek az adatok a `y = 30x + 140` egyenletet adják. A metszéspont 100-ra állítása helyette körülbelül `y = 43.33x + 100`-at eredményez: a nulla pontban illesztett érték megegyezik a ismert kiindulási alappal, míg a vonal már nem halad minden adatponton.

| Automatikus metszéspont | 100-ra rögzített metszéspont |
| --- | --- |
| ![Lineáris trendvonal automatikusan számított 140-es metszésponttal](intercept-automatic.png) | ![Lineáris trendvonal 100-as rögzített metszésponttal](intercept-fixed.png) |

Mindkét kép ugyanazokat az adatokat és tengelyskálákat használja. A trendvonalak visszanyúlnak X = 0-ig, hogy megjelenítsék a metszéspontjaikat.

Alapértelmezés szerint a [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) `Double.NaN` értéket ad vissza, ami egy nem meghatározott metszéspontot jelent, nem pedig nullát. A metszéspontot ezután automatikusan számítja ki az adat.

## **Egyéni vonal hozzáadása**

Egy egyéni vonal egy alakzat, amely a diagram fölé van rajzolva, nem pedig a sorozat adatok alapján számolt trendvonal. Ez a példa a [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) metódust használja egy vízszintes vonal hozzáadásához a diára a diagram felett. A vonal pozíciója a dia koordinátáiban van meghatározva, pontokban mérve, így a diagram bal szélénél indul, és a diagram felénél helyezkedik el. Szélessége megegyezik a diagram szélességével. A [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) piros szilárd színt ad a vonalnak.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Mit jelent a 'forward' és a 'backward' egy trendvonal esetén?**

Ezek a trendvonal előre vagy hátra kiterjesztett hossza: szórt (XY) diagramok esetén – a tengely egységeiben; nem szórt diagramok esetén – a kategóriák számában. Csak nem negatív értékek engedélyezettek.

**Megmarad a trendvonal a bemutató PDF vagy SVG formátumba exportálásakor, illetve a dia képként történő renderelésekor?**

Igen. Az Aspose.Slides a bemutatókat [PDF](/slides/hu/java/convert-powerpoint-to-pdf/) vagy [SVG](/slides/hu/java/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram részei, ezeknél a műveleteknél megmaradnak. Egy metódus is elérhető a [diagram képének exportálásához](/slides/hu/java/create-shape-thumbnails/).