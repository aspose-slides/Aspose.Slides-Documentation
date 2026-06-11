---
title: Lägg till trendlinjer i presentationsdiagram på Android
linktitle: Trendlinje
type: docs
url: /sv/androidjava/trend-line/
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
- Android
- Java
- Aspose.Slides
description: "Lägg snabbt till och anpassa trendlinjer i PowerPoint-diagram med Aspose.Slides för Android via Java - en praktisk guide för att engagera din publik."
---
## **Översikt**

Den här artikeln förklarar hur du lägger till trendlinjer i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur du skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynom och potens.

Den beskriver också hur du lägger till en anpassad linje i ett diagram genom att infoga en linjefigur, och innehåller en kort FAQ om framåt- och bakåtriktade trendlinjeprojektioner samt om trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Lägg till en trendlinje**
Aspose.Slides för Android via Java tillhandahåller ett enkelt API för att hantera olika trendlinjer i diagram:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Hämta en slides referens via dess index.
3. Lägg till ett diagram med standarddata och önskad typ (detta exempel använder ChartType.ClusteredColumn).
4. Lägger till exponentiell trendlinje för diagramserie 1.
5. Lägger till linjär trendlinje för diagramserie 1.
6. Lägger till logaritmisk trendlinje för diagramserie 2.
7. Lägger till glidande medelvärdes trendlinje för diagramserie 2.
8. Lägger till polynom trendlinje för diagramserie 3.
9. Lägger till potens trendlinje för diagramserie 3.
10. Skriv den modifierade presentationen till en PPTX-fil.

Följande kod används för att skapa ett diagram med trendlinjer.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    // Skapar ett grupperat kolumndiagram
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Lägger till exponentiell trendlinje för diagramserie 1
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Lägger till linjär trendlinje för diagramserie 1
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Lägger till logaritmisk trendlinje för diagramserie 2
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Lägger till trendlinje för glidande medelvärde för diagramserie 2
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Lägger till polynomtrendlinje för diagramserie 3
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Lägger till potens trendlinje för diagramserie 3
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Sparar presentationen
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lägg till en anpassad linje**
Aspose.Slides för Android via Java tillhandahåller ett enkelt API för att lägga till anpassade linjer i ett diagram. För att lägga till en enkel rak linje i en vald slide i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
- Hämta referensen till en slide genom att använda dess Index.
- Skapa ett nytt diagram med metoden AddChart som exponeras av Shapes-objektet.
- Lägg till en AutoShape av typ Linje med metoden AddAutoShape som exponeras av Shapes-objektet.
- Ange färgen på figurens linjer.
- Skriv den modifierade presentationen som en PPTX-fil

Följande kod används för att skapa ett diagram med anpassade linjer.

```java
// Skapa en instans av Presentation-klassen
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Vad betyder 'forward' och 'backward' för en trendlinje?**

De är längderna på trendlinjen projicerade framåt/bakåt: för spridningsdiagram (XY) – i enhetsvärden på axlarna; för icke‑spridningsdiagram – i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras vid export av presentationen till PDF eller SVG, eller vid rendering av en slide till en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/)/[SVG](/slides/sv/androidjava/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/androidjava/create-shape-thumbnails/).