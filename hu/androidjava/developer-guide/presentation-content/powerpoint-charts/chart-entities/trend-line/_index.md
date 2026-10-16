---
title: Trendvonalak hozzáadása a bemutató diagramokhoz Androidon
linktitle: Trendvonal
type: docs
url: /hu/androidjava/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgóátlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyéni trendvonal
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Gyorsan adjon hozzá és testre szabjon trendvonalakat a PowerPoint diagramokban az Aspose.Slides for Android segítségével Java nyelven — egy gyakorlati útmutató, hogy elkötelezze a közönségét."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhat trendvonalakat a bemutató diagramokhoz az Aspose.Slides használatával. Megmutatja, hogyan hozhat létre diagramot, trendvonalakat adhat a diagram sorozataihoz, és hogyan dolgozhat többféle trendvonal típussal, beleértve az exponenciális, lineáris, logaritmikus, mozgóátlag, polinomiális és hatványtípusúakat.  
Leírja továbbá, hogyan adhat egy egyéni vonalat a diagramhoz egy vonal alakzat beszúrásával, és tartalmaz egy rövid GYIK-et a trendvonal előre és hátra vetített értékéről, valamint arról, hogy megmaradnak-e a trendvonalak a PDF vagy SVG formátumba való exportáláskor és a diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**

Használja az [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) metódust, hogy trendvonalat adjon egy diagram sorozatához, a típust a [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/) segítségével választva. A példa egy klaszter oszlopdiagramot hoz létre alapértelmezett adatokkal, és két trendvonalat ad minden három sorozatához.  
Az exponenciális trendvonal elrejti egyenletét és az R‑négyzet értékét a [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) és a [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-) segítségével, míg a lineáris trendvonal piros. A logaritmikus trendvonal a [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) metódust használja egy egyéni címkéhez. A mozgóátlag a [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) három adatpontra állítja, valamint egy egyéni [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-)‑t használ.  
A polinomiális trendvonal [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) háromra van állítva, és egy kategóriával előre terjeszkedik a [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-) segítségével. A hatvány trendvonal egy kategóriával hátra terjeszkedik a [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-) segítségével.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Használja a [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) metódust, hogy a trendvonal Y értékét X = 0‑nál rögzítse. Ez a beállítás a lineáris, exponenciális és polinomiális trendvonalaknál támogatott.  
Például egy termelési költségmodellnek 100 ismert fix költségnél kell kezdődnie, még akkor is, ha a nem nulla termelési mennyiségek mérései más kiindulási alapot sugallnak. Lineáris trendvonal esetén a metszéspont rögzítése a `y = ax + b` egyenletet `b = 100`‑ra korlátozza; a meredekség az adatokhoz illeszkedik ebben a korlátozásban. Ez nem egyszerűen egy már illesztett vonalat mozgat. A tengelykereszteződés beállítások szabályozzák, hol találkoznak a diagram tengelyei, nem pedig a trendvonal illesztett együtthatóit.  
Az alábbi példa egy szórt (XY) diagramot hoz létre 1 és 4 közötti termelési mennyiségekkel, valamint 170, 200, 230 és 260 költségekkel. Az alapértelmezett automatikus metszésponttal menti a diagramot, majd a metszéspontot 100‑ra állítja, és egy második PPTX‑et ment. A két fájl csak a metszéspont beállításában különbözik. A trendvonal megjeleníti egyenletét és visszanyúlik X = 0‑ig.

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

Automatikus számítással ezek az adatok `y = 30x + 140`‑at eredményeznek. A metszéspont 100‑ra állítása helyette nagyjából `y = 43.33x + 100`‑at ad: a nullánál illesztett érték egyezik a ismert kiindulási alappal, míg a vonal már nem halad át minden adatponton.

| Automatikus metszéspont | 100‑as rögzített metszéspont |
| --- | --- |
| ![Lineáris trendvonal automatikusan kiszámított 140‑es metszésponttal](intercept-automatic.png) | ![Lineáris trendvonal 100‑as rögzített metszésponttal](intercept-fixed.png) |

Mindkét kép ugyanazt az adatot és tengelyskálát használja. A trendvonalak vissza vannak nyújtva X = 0‑ig, hogy megmutassák a metszéspontjaikat.  
Alapértelmezés szerint a [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) `Double.NaN`‑t ad vissza, ami egy nem meghatározott metszéspontot jelöl, nem nullát. A metszéspont ezután automatikusan számítódik az adatok alapján.

## **Egyéni vonal hozzáadása**

Az egyéni vonal egy alakzat, amely a diagram felett van megrajzolva, nem pedig a sorozati adatokból számított trendvonal. Ez a példa a [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) metódust használja egy vízszintes vonal hozzáadásához a diára a diagram felett. A vonal pozíciója a diasz koordinátáiban van megadva, pontokban mérve, ezért a diagram bal szélén kezdődik és a diagram felénél helyezkedik el. Szélessége megegyezik a diagram szélességével. A [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) szilárd piros színt ad a vonalnak.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
Ez a trendvonal előre/hátra vetített hosszát jelenti: szórt (XY) diagramoknál – tengelyegységekben; nem szórt diagramoknál – kategóriák száma szerint. Csak nem negatív értékek engedélyezettek.

**Megmarad a trendvonal, amikor a prezentációt PDF vagy SVG formátumba exportálják, vagy a diát képként renderálják?**  
Igen. Az Aspose.Slides a prezentációkat [PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/) vagy [SVG](/slides/hu/androidjava/render-a-slide-as-an-svg-image/) formátumba konvertálja, és a diagramokat képekké rendereli; a trendvonalak, mint a diagram részei, megmaradnak ezek során. Egy metódus is rendelkezésre áll a diagram [képének exportálásához](/slides/hu/androidjava/create-shape-thumbnails/).