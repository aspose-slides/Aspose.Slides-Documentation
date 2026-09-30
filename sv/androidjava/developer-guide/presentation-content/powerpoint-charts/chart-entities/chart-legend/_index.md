---
title: Anpassa diagramförklaringar i presentationer på Android
linktitle: Diagramförklaring
type: docs
url: /sv/androidjava/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för Android via Java för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides for Android via Java erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Den här artikeln visar hur man placerar och ändrar storlek på en förklaring, anger teckenstorlek för hela förklaringen, formaterar en enskild förklaringspost och döljer eller återställer valda poster.

Vanliga frågor täcker relaterat beteende, inklusive att reservera utrymme för förklaringen, visa flerradiga etiketter och ärva formatering från presentationens tema.

## **Placering av förklaring**

Använd förklaringens [setX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setWidth-float-), och [setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setHeight-float-)‑metoder för att ange dess position och storlek som bråkdelar av diagrammets dimensioner.

Detta exempel skapar en presentation och lägger till ett grupperat stapeldiagram med standarddata på den första bilden. Genom att dividera de önskade förklaringsförskjutningarna och dimensionerna med diagrammets bredd och höjd konverteras de till relativa värden: förklaringen förskjuts 50 punkter från diagrammets övre vänstra hörn och får storleken 100 gånger 100 punkter.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Uttryck förklaringens position och storlek i förhållande till diagrammet.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ange teckenstorlek för en förklaring**

Använd förklaringens [getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getTextFormat--) för att komma åt dess textformatering och använd [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) för att ange teckenstorleken i punkter.

Detta exempel skapar ett diagram med standarddata och anger förklaringstexten till 20 punkter. Det inaktiverar också automatiska gränser för den vertikala axeln och sätter dess intervall till -5 till 10.

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

## **Ange teckenstorlek för en enskild förklaringspost**

Använd samlingen som returneras av förklaringens [getEntries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#getEntries--)‑metod för att komma åt formatering för en specifik post. Postindexpunkterna är nollbaserade, så index `1` hänvisar till den andra posten.

Detta exempel skapar ett grupperat stapeldiagram vars standarddata innehåller minst två serier. Det formaterar den andra förklaringsposten med fet, kursiv och 20‑punkts blå text.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Dölj enskilda förklaringsposter**

För att utesluta en hjälpserie från förklaringen samtidigt som dess data förblir synlig, anropa [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) med `true` via [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Detta döljer endast den valda förklaringsposten; den tar inte bort serien eller dess datapunkter. Att anropa [IChart.setLegend](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setLegend-boolean-) med `false` döljer däremot hela förklaringen.

Exemplet nedan skapar ett grupperat stapeldiagram med flera serier med standarddata. Det döljer den andra seriens förklaringspost (index `1`) och sparar presentationen. Det återställer sedan posten genom att anropa [setHide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) med `false` och sparar en andra kopia. Kolumnerna förblir synliga i båda filerna.

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

    // Återställ samma post utan att ändra diagramdata.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jämförelsen nedan visar samma diagram med alla poster synliga och med den andra posten dold. Den andra seriens kolumner förblir oförändrade.

![Jämförelse av ett diagram med alla förklaringsposter synliga och med Serie 2 dold från förklaringen; alla kolumner förblir synliga.](hide-legend-entry.png)

I stapel-, stapel- och linjediagram identifierar förklaringsposter serier. För cirkeldiagram identifierar de enskilda datapunkter (bitar), så använd [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) på den valda biten istället. API:et dokumenterar denna datapunktmetod för diagramtyperna `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` och `BarOfPie`. Anta inte att den gäller för donutsdiagram, som inte är med i listan.

## **FAQ**

**Kan jag få diagrammet att reservera utrymme för förklaringen istället för att överlappa den?**

Ja. Anropa [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-) med `false` för att reservera utrymme för förklaringen istället för att låta den överlappa plotområdet.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter kan radbrytas när den tillgängliga bredden är otillräcklig. Du kan också använda radbrytningstecken i seriens namn för att begära radbrytningar.

**Hur får jag förklaringen att följa presentationens färgschema?**

Lämna förklaringens färger, fyllningar och teckensnitt odefinierade så att den kan ärva temats formatering. Explicit formatering åsidosätter motsvarande temainställningar.