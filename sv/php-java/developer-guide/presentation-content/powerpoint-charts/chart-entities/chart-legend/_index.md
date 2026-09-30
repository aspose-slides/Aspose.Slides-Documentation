---
title: Anpassa diagramförklaringar i presentationer med PHP
linktitle: Diagramförklaring
type: docs
url: /sv/php-java/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för PHP via Java för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides for PHP via Java erbjuder alternativ för att anpassa förklaringsrader i PowerPoint-presentationer. Denna artikel visar hur man positionerar och storlekar en förklaringsrad, anger teckenstorlek för hela förklaringsraden, formaterar ett enskilt förklaringsradspost och döljer eller återställer valda poster.

FAQ‑avsnittet täcker relaterade beteenden, inklusive att reservera utrymme för förklaringsraden, visa flerradiga etiketter och ärva formatering från presentationens tema.

## **Placering av förklaringsruta**

Använd förklaringsradsmetoderna [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/) och [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) för att ange dess position och storlek som bråkdelar av diagrammets dimensioner.

Detta exempel skapar en presentation och lägger till ett grupperat stapeldiagram med standarddata på den första bilden. Genom att dividera önskade förklaringsradsförskjutningar och dimensioner med diagrammets bredd och höjd omvandlas de till relativa värden: förklaringsraden förskjuts 50 punkter från diagrammets övre vänstra hörn och får storleken 100 × 100 punkter. Exemplet använder `java_values` för att konvertera diagramdimensionerna som returneras av PHP/Java Bridge till PHP‑tal innan divisionen.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // Ange förklaringsrutans position och storlek relativt diagrammet.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ange teckenstorlek för en förklaringsruta**

Använd förklaringsradsmetoden [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) för att komma åt dess textformatering och [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) för att ange teckenstorleken i punkter.

Detta exempel skapar ett diagram med standarddata och sätter förklaringsradens text till 20 punkter. Det inaktiverar dessutom automatiska gränser för den vertikala axeln och sätter dess intervall till –5 till 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ange teckenstorlek för ett enskilt förklaringsradspost**

Använd samlingen som returneras av förklaringsradsmetoden [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) för att komma åt formatering för ett specifikt inlägg. Index är nollbaserade, så index `1` avser det andra inlägget.

Detta exempel skapar ett grupperat stapeldiagram vars standarddata innehåller minst två serier. Det formaterar det andra förklaringsradsposten med fet, kursiv och 20‑punkts blå text.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Dölj enskilda förklaringsradsposter**

För att utesluta en hjälpserie från förklaringsraden samtidigt som dess data förblir synlig, anropa [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) med `true` via [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). Detta döljer endast den valda förklaringsradsposten; den tar inte bort serien eller dess datapunkter. Att anropa [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) med `false` döljer däremot hela förklaringsraden.

Exemplet nedan skapar ett grupperat stapeldiagram med flera serier med standarddata. Det döljer den andra seriens förklaringsradspost (index `1`) och sparar presentationen. Därefter återställer det inlägget genom att anropa [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) med `false` och sparar en andra kopia. Kolumnerna förblir synliga i båda filerna.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // Återställ samma post utan att ändra diagramdata.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jämförelsen nedan visar samma diagram med alla poster synliga och med den andra posten dold. Den andra seriens kolumner förblir oförändrade.

![Jämförelse av ett diagram med alla förklaringsradsposter synliga och med Serie 2 dold från förklaringsraden; alla kolumner förblir synliga.](hide-legend-entry.png)

I kolumn-, stapel- och linjediagram identifierar förklaringsradsposter serier. I cirkeldiagram identifierar de enskilda datapunkter (segment), så använd [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) på den valda segmentet istället. API‑dokumentationen anger denna datapunktmetod för diagramtyperna `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` och `BarOfPie`. Anta inte att den gäller för doughnut‑diagram, som inte ingår i listan.

## **Vanliga frågor**

**Kan jag få diagrammet att reservera utrymme för förklaringsraden istället för att överlappa den?**

Ja. Anropa [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) med `false` för att reservera utrymme för förklaringsraden istället för att låta den överlappa plot‑området.

**Kan jag ha flerradiga förklaringsradsetiketter?**

Ja. Långa etiketter kan radbrytas när den tillgängliga bredden är otillräcklig. Du kan också använda nyradstecken i serienamn för att begära radbrytningar.

**Hur får jag förklaringsraden att följa presentationens temafärgskala?**

Lämna förklaringsradens färger, fyllningar och typsnitt odefinierade så att den kan ärva temats formatering. Explicit formatering åsidosätter motsvarande temainställningar.