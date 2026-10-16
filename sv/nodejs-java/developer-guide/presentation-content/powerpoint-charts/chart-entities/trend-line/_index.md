---
title: Lägg till trendlinjer i presentationsdiagram i JavaScript
linktitle: Trendlinje
type: docs
url: /sv/nodejs-java/trend-line/
keywords:
- diagram
- trendlinje
- exponentiell trendlinje
- linjär trendlinje
- logaritmisk trendlinje
- glidande medelvärde trendlinje
- polynomisk trendlinje
- potens trendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint-diagram med JavaScript och Aspose.Slides för Node.js via Java — en praktisk guide för att engagera din publik."
---
## **Översikt**

Denna artikel förklarar hur du lägger till trendlinjer i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur du skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynomisk och potens.

Den beskriver också hur du lägger till en anpassad linje i ett diagram genom att infoga en linjeform, och innehåller en kort FAQ om framåt‑ och bakåtriktade trendlinje‑projektioner samt huruvida trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Lägg till en trendlinje**

Använd [TrendlineCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinecollection/#add) för att lägga till en trendlinje i en diagramserie och välj dess typ med [TrendlineType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendlinetype/). Exemplet skapar ett grupperat stapeldiagram med standarddata och lägger till två trendlinjer för var och en av dess tre serier.

Den exponentiella trendlinjen döljer sin ekvation och R‑kvadrat‑värde via [setDisplayEquation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayEquation) och [setDisplayRSquaredValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setDisplayRSquaredValue), medan den linjära trendlinjen är röd. Den logaritmiska trendlinjen använder [addTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#addTextFrameForOverriding) för en anpassad etikett. Glidande medelvärde använder en [setPeriod](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setPeriod) på tre datapunkter och ett anpassat [setTrendlineName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setTrendlineName). Den polynomiska trendlinjen har en [setOrder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setOrder) på tre och sträcker en kategori framåt via [setForward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setForward). Den potentiella trendlinjen sträcker en kategori bakåt via [setBackward](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setBackward).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);

    const firstSeries = chart.getChartData().getSeries().get_Item(0);

    const exponentialTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    const linearTrendline = firstSeries.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(red);

    const secondSeries = chart.getChartData().getSeries().get_Item(1);

    const logarithmicTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    const movingAverageTrendline = secondSeries.getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod(java.newByte(3));
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    const thirdSeries = chart.getChartData().getSeries().get_Item(2);

    const polynomialTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder(java.newByte(3));

    const powerTrendline = thirdSeries.getTrendLines().add(aspose.slides.TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in ett trendlinjeintercept**

Använd [setIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#setIntercept) för att fixera en trendlinjes Y‑värde vid X = 0. Denna inställning stöds för linjära, exponentiella och polynomiska trendlinjer.

Till exempel kan en produktionskostnadsmodell behöva starta med kända fasta kostnader på 100, även när mätningar vid icke‑noll produktionsvolymer antyder ett annat grundvärde. För en linjär trendlinje begränsar fastställandet av interceptet ekvationen `y = ax + b` till `b = 100`; lutningen anpassas till data under den begränsningen. Det flyttar inte bara en redan anpassad linje. Inställningarna för axelkorsning styr var diagramaxlarna möts, inte koefficienterna för den anpassade trendlinjen.

Följande exempel skapar ett spridnings‑ (XY‑) diagram med produktionsvolymer från 1 till 4 och kostnader på 170, 200, 230 och 260. Det sparar diagrammet med standardinställning för automatiskt intercept, sätter interceptet till 100 och sparar en andra PPTX. De två filerna skiljer sig endast i interceptinställningen. Trendlinjen visar sin ekvation och sträcker sig tillbaka till X = 0.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const nameCell = workbook.getCell(0, 0, 1, "Production cost");
    const series = chart.getChartData().getSeries().add(nameCell, aspose.slides.ChartType.ScatterWithMarkers);
    const costs = [170, 200, 230, 260];

    for (let i = 0; i < costs.length; i++) {
        const xCell = workbook.getCell(0, i + 1, 0, i + 1);
        const yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    const trendline = series.getTrendLines().add(aspose.slides.TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", aspose.slides.SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Med automatisk beräkning ger dessa data `y = 30x + 140`. Att sätta interceptet till 100 ger i stället ungefär `y = 43.33x + 100`: det anpassade värdet vid noll motsvarar det kända grundvärdet, medan linjen inte längre passerar genom varje datapunkt.

| Automatisk intercept | Fast intercept på 100 |
| --- | --- |
| ![Linjär trendlinje med automatiskt beräknat intercept på 140](intercept-automatic.png) | ![Linjär trendlinje med fast intercept på 100](intercept-fixed.png) |

Båda bilderna använder samma data och axelskala. Trendlinjerna sträcks tillbaka till X = 0 för att visa sina intercept.

Som standard returnerar [getIntercept](https://reference.aspose.com/slides/nodejs-java/aspose.slides/trendline/#getIntercept) `NaN`, vilket representerar ett ospecificerat intercept snarare än noll. Interceptet beräknas då automatiskt från data.

## **Lägg till en anpassad linje**

En anpassad linje är en form som ritas över diagrammet snarare än en trendlinje beräknad från seriedata. Detta exempel använder [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAutoShape) för att lägga till en horisontell linje på bilden över diagrammet. Linjens position anges i bildkoordinater, mätt i punkter, så den börjar vid diagrammets vänstra kant och sitter halvvägs ner i diagrammet. Dess bredd matchar diagrammets bredd. [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) ger linjen en solid röd färg.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);

    const line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

    presentation.save("AddCustomLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Vad betyder 'forward' och 'backward' för en trendlinje?**

De är längderna på trendlinjen som projiceras framåt/bakåt: för spridnings‑ (XY‑) diagram — i axelenheter; för icke‑spridningsdiagram — i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras vid export av presentationen till PDF eller SVG, eller när en bild renderas till en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/) eller [SVG](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/nodejs-java/create-shape-thumbnails/) själv.