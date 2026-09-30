---
title: Anpassa diagramförklaringar i presentationer med JavaScript
linktitle: Diagramförklaring
type: docs
url: /sv/nodejs-java/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för Node.js via Java för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides för Node.js via Java erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Den här artikeln visar hur man placerar och storlekar en förklaring, anger teckenstorleken för hela förklaringen, formaterar ett enskilt förklarings‑element och döljer eller återställer valda element.

FAQ täcker relaterade beteenden, inklusive att reservera utrymme för förklaringen, visa flerradiga etiketter och ärva formatering från presentationens tema.

## **Placering av förklaring**

Använd förklaringens [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/), och [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/)‑metoder för att ange dess position och storlek som bråkdelar av diagrammets mått.

Detta exempel skapar en presentation och lägger till ett grupperat stapeldiagram med standarddata på den första bilden. Genom att dividera de önskade förklaringens förskjutningar och dimensioner med diagrammets bredd och höjd konverteras de till relativa värden: förklaringen förskjuts 50 punkter från diagrammets övre vänstra hörn och har storleken 100 × 100 punkter.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Ange förklaringens position och storlek relativt diagrammet.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange teckenstorlek för en förklaring**

Använd förklaringens [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) för att komma åt dess textformatering och [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) för att ange teckenstorleken i punkter.

Detta exempel skapar ett diagram med standarddata och ställer in förklaringstexten till 20 punkter. Det inaktiverar också automatiska gränser för den vertikala axeln och sätter dess intervall till -5 till 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange teckenstorlek för ett enskilt förklarings‑element**

Använd samlingen som returneras av förklaringens [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/)‑metod för att komma åt formatering för ett specifikt element. Index för element är nollbaserade, så index `1` hänvisar till det andra elementet.

Detta exempel skapar ett grupperat stapeldiagram vars standarddata innehåller minst två serier. Det formaterar det andra förklarings‑elementet med fet, kursiv och 20‑punkts blå text.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dölj enskilda förklarings‑element**

För att exkludera en hjälpserie från förklaringen samtidigt som dess data förblir synlig, anropa [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) med `true` via [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Detta döljer endast det valda förklarings‑elementet; det tar inte bort serien eller dess datapunkter. Att anropa [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) med `false` döljer däremot hela förklaringen.

Exemplet nedan skapar ett grupperat stapeldiagram med flera serier med standarddata. Det döljer den andra seriens förklarings‑element (index `1`) och sparar presentationen. Det återställer sedan elementet genom att anropa [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) med `false` och sparar en andra kopia. Kolumnerna förblir synliga i båda filerna.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Återställ samma element utan att ändra diagramdata.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jämförelsen nedan visar samma diagram med alla element synliga och med det andra elementet dolt. Den andra seriens kolumner förblir oförändrade.

![Jämförelse av ett diagram med alla förklarings‑element synliga och med Serie 2 dold i förklaringen; alla kolumner förblir synliga.](hide-legend-entry.png)

I stapel‑, stapel‑och linjediagram identifierar förklarings‑element serier. I cirkeldiagram identifierar de enskilda datapunkter (skivor), så använd [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) på den valda skivan istället. API‑dokumentationen beskriver denna datapunktmetod för diagramtyperna `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` och `BarOfPie`. Anta inte att den gäller för donuts‑diagram, som inte ingår i listan.

## **FAQ**

**Kan jag få diagrammet att reservera utrymme för förklaringen istället för att överlappa den?**

Ja. Anropa [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) med `false` för att reservera utrymme för förklaringen istället för att låta den överlappa plot‑området.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter kan radbrytas när den tillgängliga bredden är otillräcklig. Du kan också använda nyradstecken i serienamn för att begära radbrytningar.

**Hur får jag förklaringen att följa presentationens färgschema?**

Låt förklaringens färger, fyllningar och teckensnitt vara odefinierade så att den kan ärva temats formatering. Explicit formatering åsidosätter de motsvarande temainställningarna.