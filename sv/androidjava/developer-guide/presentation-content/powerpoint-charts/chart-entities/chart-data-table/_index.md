---
title: Anpassa diagramdatatabeller i presentationer på Android
linktitle: Datatabell
type: docs
url: /sv/androidjava/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Anpassa diagramdatatabellens teckensnitt, kantlinjer och legendnycklar i PowerPoint-presentationer med Aspose.Slides för Android via Java."
---
## **Översikt**

Aspose.Slides för Android via Java låter dig visa ett diagramts datatabell och anpassa dess textformatering, kantlinjer och legendarnycklar. Denna artikel förklarar hur du aktiverar tabellen, formaterar dess text, styr varje typ av kantlinje och visar eller döljer legendarnycklar. Exemplen sparar de konfigurerade diagrammen i PPTX‑filer.

## **Ställ in teckensnittsegenskaper**

För att visa ett diagramts datatabell, skicka `true` till [setDataTable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). Använd [getChartDataTable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/#getChartDataTable--) för att komma åt tabellen och konfigurera dess textformatering.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Lägg till ett grupperat stapeldiagram på den första bilden.
1. Aktivera diagrammets datatabell.
1. Aktivera fet text med [setFontBold](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) och skicka `20` till [setFontHeight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) för 20‑punkts text.
1. Spara den modifierade presentationen.

Följande exempel kräver `test.pptx` i arbetskatalogen med minst en bild. Det lägger till ett diagram med standarddata på position (50, 50), med en bredd på 600 punkter och en höjd på 400 punkter. Den sparade `output.pptx` innehåller diagrammet med dess datatabell aktiverad och de angivna teckensnittsinställningarna tillämpade.

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

## **Anpassa kantlinjer för datatabell**

Aktivera tabellen med [IChart.setDataTable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) och få åtkomst till den via [IChart.getChartDataTable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/#getChartDataTable--). Du kan styra tre typer av kantlinjer oberoende:

- [setBorderHorizontal](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) styr horisontella cellkantlinjer.
- [setBorderVertical](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) styr vertikala cellkantlinjer.
- [setBorderOutline](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) styr tabellens yttre kantlinje.

Skicka `true` till varje metod för att visa dess kantlinjer eller `false` för att dölja dem. Följande exempel skapar ett grupperat stapeldiagram med standarddata, visar horisontella kantlinjer och den yttre kantlinjen samt döljer vertikala kantlinjer. Det kräver ingen indatafil. Diagrammets position och storlek anges i punkter.

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

Jämförelsen nedan använder samma diagramdata och legendarnyckelinställning i alla fyra fallen. Med alla kantlinjer aktiverade inaktiverar varje efterföljande variant bara en kantlinje. Varianten längst ner till vänster motsvarar kantlinjeinställningarna i exemplet.

![Diagramdatatabeller med alla kantlinjer aktiverade, inga horisontella kantlinjer, inga vertikala kantlinjer och ingen yttre kantlinje](data-table-borders.png)

## **Visa eller dölja legendarnycklar**

Legendarnycklar är små färgade markörer bredvid serienamnen i datatabellen. De hjälper läsaren att matcha varje tabellrad med en diagramserie. Skicka `true` till [setShowLegendKey](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) för att visa dessa markörer eller `false` för att dölja dem.

Diagrammets separata legend styrs av [IChart.setLegend](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ichart/#setLegend-boolean-). Dessa inställningar är oberoende: att dölja den separata legenden döljer inte nycklarna i datatabellen, och att dölja tabellens nycklar döljer inte den separata legenden.

Följande exempel skapar ett diagram med standarddata, aktiverar dess datatabell och visar legendarnycklar i den medan den separata legenden döljs. Alla tabellkantlinjer är explicit aktiverade. Ingen inmatningspresentation krävs. För att bara dölja tabellens nycklar, skicka `false` till [setShowLegendKey](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

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

Jämförelsen nedan visar samma tabell med legendarnycklar visas till vänster och dolda till höger. Alla kantlinjer förblir aktiverade, och den separata diagramlegenden är dold i båda fallen.

![Diagramdatatabeller med legendarnycklar visade till vänster och dolda till höger](data-table-legend-keys.png)

## **FAQ**

**Kan jag visa legendarnycklar i ett diagrammets datatabell?**

Ja. Skicka `true` till [setShowLegendKey](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) för att visa legendarnycklar eller `false` för att dölja dem.

**Kommer datatabellen att bevaras när presentationen exporteras till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet och dess visade datatabell som en del av bilden när du exporterar till [PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/sv/androidjava/convert-powerpoint-to-html/) eller [bilder](/slides/sv/androidjava/convert-powerpoint-to-png/).

**Kan jag arbeta med datatabeller i diagram som laddats från en mall?**

Ja. För ett diagram som laddats från en befintlig presentation eller mall, använd [hasDataTable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/#hasDataTable--) och [setDataTable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) för att kontrollera eller ändra om dess datatabell visas.

**Hur kan jag hitta diagram som har en aktiverad datatabell?**

Iterera genom formerna på varje bild, identifiera diagrammen och anropa deras [hasDataTable](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/chart/#hasDataTable--)‑metod. Värdet `true` indikerar att datatabellen är aktiverad.