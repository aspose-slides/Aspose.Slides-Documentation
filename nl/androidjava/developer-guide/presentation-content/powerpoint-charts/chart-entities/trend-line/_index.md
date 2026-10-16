---
title: Trendlijnen toevoegen aan presentatiediagrammen op Android
linktitle: Trendlijn
type: docs
url: /nl/androidjava/trend-line/
keywords:
- diagram
- trendlijn
- exponentiële trendlijn
- lineaire trendlijn
- logaritmische trendlijn
- voortschrijdend gemiddelde trendlijn
- polynomiale trendlijn
- machts trendlijn
- aangepaste trendlijn
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Voeg snel trendlijnen toe en pas ze aan in PowerPoint-diagrammen met Aspose.Slides voor Android via Java — een praktische gids om uw publiek te boeien."
---
## **Overzicht**

Dit artikel legt uit hoe u trendlijnen kunt toevoegen aan presentatiediagrammen met behulp van Aspose.Slides. Het laat zien hoe u een diagram maakt, trendlijnen toevoegt aan diagramreeksen, en werkt met verschillende trendlijntypen, waaronder exponentieel, lineair, logaritmisch, voortschrijdend gemiddelde, polynomiaal en macht.

Het beschrijft tevens hoe u een aangepaste lijn aan een diagram kunt toevoegen door een lijnvorm in te voegen, en bevat een korte FAQ over de waarde van vooruit- en achterwaartse projectie van trendlijnen en of trendlijnen behouden blijven bij export naar PDF of SVG en bij het renderen van diagrammen als afbeeldingen.

## **Trendlijn toevoegen**

Gebruik [ITrendlineCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendlinecollection/#add-int-) om een trendlijn toe te voegen aan een diagramreeks, en selecteer het type met [TrendlineType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendlinetype/). Het voorbeeld maakt een gegroepeerde kolomgrafiek met standaardgegevens en voegt twee trendlijnen toe aan elk van de drie reeksen.

De exponentiële trendlijn verbergt zijn vergelijking en R‑kwadraat‑waarde via [setDisplayEquation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) en [setDisplayRSquaredValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-), terwijl de lineaire trendlijn rood is. De logaritmische trendlijn gebruikt [addTextFrameForOverriding](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-) voor een aangepast label. Het voortschrijdend gemiddelde gebruikt een [setPeriod](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setPeriod-byte-) van drie gegevenspunten en een aangepaste [setTrendlineName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-).

De polynomiale trendlijn heeft een [setOrder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setOrder-byte-) van drie en strekt één categorie vooruit uit via [setForward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setForward-double-). De machts trendlijn strekt één categorie achteruit uit via [setBackward](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itrendline/#setBackward-double-).

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

## **Intercept voor een trendlijn instellen**

Gebruik [setIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#setIntercept-double-) om de Y‑waarde van een trendlijn vast te leggen op X = 0. Deze instelling wordt ondersteund voor lineaire, exponentiële en polynomiale trendlijnen.

Bijvoorbeeld, een productiekostmodel moet mogelijk beginnen met bekende vaste kosten van 100, zelfs wanneer metingen bij niet‑nul productievolumes een andere basislijn suggereren. Voor een lineaire trendlijn zorgt het vastzetten van het intercept ervoor dat de vergelijking `y = ax + b` wordt beperkt tot `b = 100`; de helling wordt dan aan de gegevens aangepast onder die beperking. Het verplaatst niet simpelweg een reeds aangepaste lijn. De instellingen voor assenkruising bepalen waar de assen van het diagram elkaar ontmoeten, niet de coëfficiënten van de aangepaste trendlijn.

Het volgende voorbeeld maakt een spreidingsdiagram (XY) met productievolumes van 1 tot 4 en kosten van 170, 200, 230 en 260. Het slaat het diagram op met het standaard automatische intercept, stelt het intercept in op 100, en slaat een tweede PPTX op. De twee bestanden verschillen alleen in de intercept‑instelling. De trendlijn toont zijn vergelijking en strekt zich terug uit tot X = 0.

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

Met automatische berekening leveren deze gegevens `y = 30x + 140` op. Het instellen van het intercept op 100 levert in plaats daarvan ongeveer `y = 43.33x + 100` op: de aangepaste waarde bij nul komt overeen met de bekende basislijn, terwijl de lijn niet langer door elk datapunt gaat.

| Automatisch intercept | Vast intercept van 100 |
| --- | --- |
| ![Lineaire trendlijn met een automatisch berekend intercept van 140](intercept-automatic.png) | ![Lineaire trendlijn met een vast intercept van 100](intercept-fixed.png) |

Beide afbeeldingen gebruiken dezelfde gegevens en as‑schaal. De trendlijnen worden teruggestrekt naar X = 0 om hun intercepters te tonen.

Standaard retourneert [getIntercept](https://reference.aspose.com/slides/androidjava/com.aspose.slides/trendline/#getIntercept--) `Double.NaN`, wat een niet‑gespecificeerd intercept aangeeft in plaats van nul. Het intercept wordt dan automatisch berekend uit de gegevens.

## **Aangepaste lijn toevoegen**

Een aangepaste lijn is een vorm die over het diagram wordt getekend in plaats van een trendlijn die wordt berekend uit seriedata. Dit voorbeeld gebruikt [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) om een horizontale lijn toe te voegen aan de dia boven het diagram. De positie van de lijn wordt gespecificeerd in dia‑coördinaten, gemeten in punten, dus hij begint aan de linkerkant van het diagram en zit halverwege het diagram. De breedte komt overeen met de breedte van het diagram. De [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) geeft de lijn een effen rode kleur.

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

## **FAQ**

**Wat betekenen 'forward' en 'backward' voor een trendlijn?**

Het zijn de lengtes van de trendlijn die voortwaarts/achterwaarts worden geprojecteerd: voor spreidingsdiagrammen (XY) — in assen‑eenheden; voor niet‑spreidingsdiagrammen — in aantal categorieën. Alleen niet‑negatieve waarden zijn toegestaan.

**Wordt de trendlijn behouden bij het exporteren van de presentatie naar PDF of SVG, of bij het renderen van een dia naar een afbeelding?**

Ja. Aspose.Slides converteert presentaties naar [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/) of [SVG](/slides/nl/androidjava/render-a-slide-as-an-svg-image/) en rendert diagrammen naar afbeeldingen; trendlijnen, als onderdeel van het diagram, blijven behouden tijdens deze bewerkingen. Er is ook een methode beschikbaar om een afbeelding van het diagram zelf te [een afbeelding van het diagram exporteren](/slides/nl/androidjava/create-shape-thumbnails/).