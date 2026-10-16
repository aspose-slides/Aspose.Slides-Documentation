---
title: Lägg till trendlinjer i presentationsdiagram i Java
linktitle: Trendlinje
type: docs
url: /sv/java/trend-line/
keywords:
- diagram
- trendlinje
- exponentiell trendlinje
- linjär trendlinje
- logaritmisk trendlinje
- trendlinje för glidande medelvärde
- polynomisk trendlinje
- potenstrendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint‑diagram med Aspose.Slides för Java — en praktisk guide för att engagera din publik."
---
## **Översikt**

Denna artikel förklarar hur du lägger till trendlinjer i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur du skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynom och potens.

Den beskriver också hur du lägger till en anpassad linje i ett diagram genom att infoga en linjeshape, och innehåller en kort FAQ om värden för framåt‑ och bakåtriktad projektion av trendlinjer samt om trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Lägg till en trendlinje**

Använd [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-) för att lägga till en trendlinje i en diagramserie, välj dess typ med [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/). Exemplet skapar ett grupperat stapeldiagram med standarddata och lägger till två trendlinjer för var och en av dess tre serier.

Den exponentiella trendlinjen döljer sin ekvation och R‑kvadrerade värde via [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) och [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), medan den linjära trendlinjen är röd. Den logaritmiska trendlinjen använder [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) för en anpassad etikett. Glidande medelvärde använder en [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-) på tre datapunkter och en anpassad [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

Den polynomiska trendlinjen har en [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-) på tre och sträcker sig en kategori framåt genom [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-). Potens‑trendlinjen sträcker sig en kategori bakåt genom [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-).

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

## **Ställ in ett intercept för trendlinjen**

Använd [setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-) för att fixera en trendlinjes Y‑värde vid X = 0. Denna inställning stöds för linjära, exponentiella och polynomiska trendlinjer.

Till exempel kan en produktionskostnadsmodell behöva börja med kända fasta kostnader på 100, även när mätningar vid icke‑noll produktionsvolymer tyder på ett annat baslinje. För en linjär trendlinje begränsar fixering av interceptet ekvationen `y = ax + b` till `b = 100`; lutningen anpassas till data under den begränsningen. Det flyttar inte bara en redan anpassad linje. Inställningar för axelöverskridning styr var diagramaxlarna möts, inte koefficienterna för den anpassade trendlinjen.

Följande exempel skapar ett spridnings‑(XY‑)diagram med produktionsvolymer från 1 till 4 och kostnader på 170, 200, 230 och 260. Det sparar diagrammet med standardautomatiskt intercept, sätter interceptet till 100 och sparar en andra PPTX. De två filerna skiljer sig endast i interceptinställningen. Trendlinjen visar sin ekvation och sträcker sig tillbaka till X = 0.

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

Med automatisk beräkning ger dessa data `y = 30x + 140`. Om interceptet sätts till 100 ger det ungefär `y = 43.33x + 100`: det anpassade värdet vid noll matchar den kända baslinjen, medan linjen inte längre går igenom varje datapunkt.

| Automatiskt intercept | Fast intercept på 100 |
| --- | --- |
| ![Linjär trendlinje med ett automatiskt beräknat intercept på 140](intercept-automatic.png) | ![Linjär trendlinje med ett fast intercept på 100](intercept-fixed.png) |

Båda bilderna använder samma data och axelskalor. Trendlinjerna sträcks tillbaka till X = 0 för att visa deras intercept.

Som standard returnerar [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--) `Double.NaN`, vilket representerar ett ospecificerat intercept snarare än noll. Interceptet beräknas då automatiskt från data.

## **Lägg till en anpassad linje**

En anpassad linje är en form som ritas över diagrammet snarare än en trendlinje beräknad från serien data. Detta exempel använder [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) för att lägga till en horisontell linje på bilden över diagrammet. Linjens position anges i bildkoordinater, mätt i punkter, så den börjar vid diagrammets vänstra kant och sitter halvvägs ner i diagrammet. Dess bredd matchar diagrammets bredd. [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) ger linjen en solid röd färg.

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

## **Vanliga frågor**

**Vad betyder 'framåt' och 'bakåt' för en trendlinje?**

De är längderna på trendlinjen som projiceras framåt/bakåt: för spridnings‑(XY‑)diagram – i axelenheter; för icke‑spridningsdiagram – i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras vid export av presentationen till PDF eller SVG, eller när en bild renderas till en bildfil?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/java/convert-powerpoint-to-pdf/) eller [SVG](/slides/sv/java/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/java/create-shape-thumbnails/) själv.