---
title: Anpassa diagramförklaringar i presentationer med Java
linktitle: Diagramförklaring
type: docs
url: /sv/java/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för Java för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides for Java erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint‑presentationer. Denna artikel visar hur du placerar och storlekar en förklaring, ställer in teckenstorleken för hela förklaringen, formaterar ett enskilt förklaringselement och döljer eller återställer valda element.

FAQ:n täcker relaterade beteenden, inklusive att reservera utrymme för förklaringen, visa flerradiga etiketter och ärva formatering från presentationens tema.

## **Placering av förklaring**

Använd förklaringens [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), och [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-)‑metoder för att ange dess position och storlek som bråkdelar av diagrammets dimensioner.

Detta exempel skapar en presentation och lägger till ett grupperat stapeldiagram med standarddata på den första bilden. Genom att dividera de önskade förklaringsförskjutningarna och dimensionerna med diagrammets bredd och höjd konverteras de till relativa värden: förklaringen förskjuts 50 punkter från diagrammets övre vänstra hörn och storlek sätts till 100 × 100 punkter.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Uttryck förklaringens position och storlek relativt diagrammet.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in teckenstorlek för en förklaring**

Använd förklaringens [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) för att få åtkomst till dess textformatering och använd [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) för att ange teckenstorleken i punkter.

Detta exempel skapar ett diagram med standarddata och sätter förklaringstexten till 20 punkter. Det inaktiverar också automatiska gränser för den vertikala axeln och sätter dess intervall till -5 till 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in teckenstorlek för ett enskilt förklaringselement**

Använd samlingen som returneras av förklaringens [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--)‑metod för att komma åt formatering för ett specifikt element. Elementens index är nollbaserade, så index `1` hänvisar till det andra elementet.

Detta exempel skapar ett grupperat stapeldiagram vars standarddata innehåller minst två serier. Det formaterar det andra förklaringselementet med fet, kursiv och 20‑punkts blå text.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dölj enskilda förklaringselement**

För att utesluta en hjälpseries från förklaringen samtidigt som dess data förblir synliga, anropa [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) med `true` via [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Detta döljer endast det valda förklaringselementet; det tar inte bort serien eller dess datapunkter. Att anropa [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) med `false` döljer däremot hela förklaringen.

Exemplet nedan skapar ett grupperat stapeldiagram med flera serier med standarddata. Det döljer den andra seriens förklaringselement (index `1`) och sparar presentationen. Det återställer sedan elementet genom att anropa [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) med `false` och sparar en andra kopia. Kolumnerna förblir synliga i båda filerna.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Återställ samma element utan att ändra diagramdata.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jämförelsen nedan visar samma diagram med alla element synliga och med det andra elementet dolt. Den andra seriens kolumner förblir oförändrade.

![Jämförelse av ett diagram med alla förklaringselement synliga och med Serie 2 dold från förklaringen; alla kolumner förblir synliga.](hide-legend-entry.png)

I stapel‑, stapel‑ och linjediagram identifierar förklaringselement serier. I cirkeldiagram identifierar de enskilda datapunkter (delar), så använd [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) på den valda delen istället. API‑dokumentationen beskriver denna datapunktmetod för diagramtyperna `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` och `BarOfPie`. Anta inte att den gäller för donut‑diagram, som inte ingår i listan.

## **FAQ**

**Kan jag få diagrammet att reservera utrymme för förklaringen istället för att överlappa den?**

Ja. Anropa [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) med `false` för att reservera utrymme för förklaringen istället för att låta den överlappa plottområdet.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter kan radbrytas när den tillgängliga bredden är otillräcklig. Du kan också använda nyrader i serienamn för att begära radbrytningar.

**Hur får jag förklaringen att följa presentationens temafärgsschema?**

Lämna förklaringens färger, fyllningar och teckensnitt oinställda så att den kan ärva temats formatering. Explicit formatering åsidosätter motsvarande temainställningar.