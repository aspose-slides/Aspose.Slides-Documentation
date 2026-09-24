---
title: Anpassa diagramdatatabeller i presentationer med Java
linktitle: Datatabell
type: docs
url: /sv/java/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Anpassa diagramdatatabellens teckensnitt, kanter och förklaringsnycklar i PowerPoint-presentationer med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides för Java låter dig visa ett diagram‑datatabell och anpassa dess textformatering, kanter och förklaringsnycklar. Denna artikel förklarar hur du aktiverar tabellen, formaterar dess text, styr varje typ av kant och visar eller döljer förklaringsnycklar. Exemplen sparar de konfigurerade diagrammen i PPTX‑filer.

## **Ställ in teckensnittsegenskaper**

För att visa ett diagram‑datatabell, skicka `true` till [setDataTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chart/#setDataTable-boolean-). Använd [getChartDataTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chart/#getChartDataTable--) för att komma åt tabellen och konfigurera dess textformatering.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
1. Lägg till ett grupperat stapeldiagram på den första bilden.
1. Aktivera diagrammets datatabell.
1. Aktivera fet text med [setFontBold](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) och skicka `20` till [setFontHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) för 20‑punkts text.
1. Spara den ändrade presentationen.

Följande exempel kräver `test.pptx` i arbetskatalogen med minst en bild. Det lägger till ett diagram med standarddata på positionen (50, 50), med en bredd på 600 punkter och en höjd på 400 punkter. Den sparade `output.pptx` innehåller diagrammet med dess datatabell aktiverad och de angivna teckensnittsinställningarna tillämpade.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Anpassa datatabellens kanter**

Aktivera tabellen med [IChart.setDataTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichart/#setDataTable-boolean-) och få åtkomst till den via [IChart.getChartDataTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichart/#getChartDataTable--). Du kan styra tre typer av kanter oberoende:

- [setBorderHorizontal](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) styr horisontella cellkanter.
- [setBorderVertical](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) styr vertikala cellkanter.
- [setBorderOutline](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) styr tabellens yttre kant.

Skicka `true` till varje metod för att visa dess kanter eller `false` för att dölja dem. Följande exempel skapar ett grupperat stapeldiagram med standarddata, visar horisontella kanter och den yttre kanten samt döljer vertikala kanter. Det kräver ingen indatafil. Diagrammets position och storlek anges i punkter.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jämförelsen nedan använder samma diagramdata och förklaringsnyckelinställning i alla fyra fallen. Med alla kanter aktiverade i början, inaktiverar varje återstående variant bara en kantinställning. Varianten nedre vänstra matchar kantinställningarna i exemplet.

![Diagramdatatabeller med alla kanter aktiverade, inga horisontella kanter, inga vertikala kanter och ingen yttre kant](data-table-borders.png)

## **Visa eller dölja förklaringsnycklar**

Förklaringsnycklar är små färgade markörer bredvid seriernas namn i datatabellen. De hjälper läsaren att matcha varje tabellrad med ett diagramserie. Skicka `true` till [setShowLegendKey](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) för att visa dessa markörer eller `false` för att dölja dem.

Diagrammets separata förklaring styrs av [IChart.setLegend](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ichart/#setLegend-boolean-). Dessa inställningar är oberoende: att dölja den separata förklaringen döljer inte nycklarna i datatabellen, och att dölja tabellens nycklar döljer inte den separata förklaringen.

Följande exempel skapar ett diagram med standarddata, aktiverar dess datatabell och visar förklaringsnycklar i den samtidigt som den separata förklaringen döljs. Alla tabellkanter är uttryckligen aktiverade. Ingen indata‑presentation krävs. För att bara dölja tabellens nycklar, skicka `false` till [setShowLegendKey](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jämförelsen nedan visar samma tabell med förklaringsnycklar aktiverade och inaktiverade. Alla kanter förblir aktiverade och den separata diagramförklaringen är dold i båda fallen.

![Diagramdatatabeller med förklaringsnycklar visas till vänster och dolda till höger](data-table-legend-keys.png)

## **FAQ**

**Kan jag visa förklaringsnycklar i ett diagramdatas tabell?**

Ja. Skicka `true` till [setShowLegendKey](https://reference.aspose.com/slides/sv/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) för att visa förklaringsnycklar eller `false` för att dölja dem.

**Kommer datatabellen att bevaras vid export av presentationen till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet och dess visade datatabell som en del av bilden vid export till [PDF](/slides/sv/java/convert-powerpoint-to-pdf/), [HTML](/slides/sv/java/convert-powerpoint-to-html/) eller [bilder](/slides/sv/java/convert-powerpoint-to-png/).

**Kan jag arbeta med datatabeller i diagram som laddas från en mall?**

Ja. För ett diagram som laddas från en befintlig presentation eller mall, använd [hasDataTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chart/#hasDataTable--) och [setDataTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chart/#setDataTable-boolean-) för att kontrollera eller ändra om dess datatabell visas.

**Hur kan jag hitta diagram som har en datatabell aktiverad?**

Iterera genom formerna på varje bild, identifiera diagrammen och anropa deras [hasDataTable](https://reference.aspose.com/slides/sv/java/com.aspose.slides/chart/#hasDataTable--)‑metod. Ett värde på `true` indikerar att datatabellen är aktiverad.