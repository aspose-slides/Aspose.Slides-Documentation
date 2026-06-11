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
- trendlinje för glidande medelvärde
- polynomtrendlinje
- potenstrendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint‑diagram med JavaScript och Aspose.Slides för Node.js via Java — en praktisk guide för att engagera din publik."
---
## **Översikt**

Den här artikeln förklarar hur man lägger till trendlinjer i presentationsdiagram med Aspose.Slides. Den visar hur man skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynom och potens.

Den beskriver också hur man lägger till en anpassad linje i ett diagram genom att infoga en linjeform, och innehåller en kort FAQ om framåt‑ och bakåtriktade trendlinjeprojektioner samt huruvida trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Lägg till trendlinje**

Aspose.Slides for Node.js via Java tillhandahåller ett enkelt API för att hantera olika diagram‑Trend Lines:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑klassen.
1. Hämta en slides referens via dess index.
1. Lägg till ett diagram med standarddata och någon önskad typ (detta exempel använder ChartType.ClusteredColumn).
1. Lägger till exponentiell trendlinje för diagramserie 1.
1. Lägger till linjär trendlinje för diagramserie 1.
1. Lägger till logaritmisk trendlinje för diagramserie 2.
1. Lägger till glidande medelvärdestrendlinje för diagramserie 2.
1. Lägger till polynomtrendlinje för diagramserie 3.
1. Lägger till potenstrendlinje för diagramserie 3.
1. Spara den modifierade presentationen till en PPTX‑fil.

Följande kod används för att skapa ett diagram med trendlinjer.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    // Skapar ett diagram med grupperade staplar
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Lägger till exponentiell trendlinje för diagramserie 1
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Lägger till linjär trendlinje för diagramserie 1
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Lägger till logaritmisk trendlinje för diagramserie 2
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Lägger till trendlinje för glidande medelvärde för diagramserie 2
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Lägger till polynomtrendlinje för diagramserie 3
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Lägger till potenstrendlinje för diagramserie 3
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Sparar presentationen
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lägg till anpassad linje**

Aspose.Slides for Node.js via Java tillhandahåller ett enkelt API för att lägga till anpassade linjer i ett diagram. För att lägga till en enkel rak linje på ett valt bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑klassen
- Hämta referensen till en bild genom att använda dess Index
- Skapa ett nytt diagram med AddChart‑metoden som exponeras av Shapes‑objektet
- Lägg till en AutoShape av typ Linje med AddAutoShape‑metoden som exponeras av Shapes‑objektet
- Ställ in färgen på formens linjer.
- Spara den modifierade presentationen som en PPTX‑fil

Följande kod används för att skapa ett diagram med anpassade linjer.

```javascript
// Skapa en instans av Presentation-klassen
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Vad betyder 'forward' och 'backward' för en trendlinje?**

De är längderna på trendlinjen projicerade framåt/bakåt: för spridningsdiagram (XY) – i axelenheter; för icke‑spridningsdiagram – i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras när presentationen exporteras till PDF eller SVG, eller när en bild renderas till en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/nodejs-java/create-shape-thumbnails/) själva.