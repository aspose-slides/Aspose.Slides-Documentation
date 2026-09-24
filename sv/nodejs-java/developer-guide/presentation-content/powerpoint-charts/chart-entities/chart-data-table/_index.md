---
title: Anpassa diagrammets datatabeller i presentationer med JavaScript
linktitle: Datatabell
type: docs
url: /sv/nodejs-java/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Anpassa diagrammets datatabellens teckensnitt, kanter och förklaringsnycklar i PowerPoint-presentationer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides for Node.js via Java låter dig visa ett diagram:s datatabell och anpassa dess textformatering, kanter och förklaringsnycklar. Den här artikeln förklarar hur du aktiverar tabellen, formaterar dess text, styr varje kanttyp och visar eller döljer förklaringsnycklar. Exemplen sparar de konfigurerade diagrammen i PPTX‑filer.

## **Ange teckensnittsegenskaper**

För att visa ett diagram:s datatabell, skicka `true` till [setDataTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/setdatatable/). Använd [getChartDataTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/getchartdatatable/) för att komma åt tabellen och konfigurera dess textformatering.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Lägg till ett grupperat stapeldiagram på den första bilden.
1. Aktivera diagrammets datatabell.
1. Aktivera fet text med [setFontBold](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setfontbold) och skicka `20` till [setFontHeight](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setfontheight) för 20‑punkts text.
1. Spara den ändrade presentationen.

Följande exempel kräver `input.pptx` i arbetskatalogen med minst en bild. Det lägger till ett diagram med standarddata på position (50, 50), med en bredd på 600 punkter och en höjd på 400 punkter. Den sparade `output.pptx` innehåller diagrammet med dess datatabell aktiverad och de angivna teckensnittinställningarna tillämpade.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Anpassa datatabellens kanter**

Aktivera tabellen med [Chart.setDataTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/setdatatable/) och nå den via [Chart.getChartDataTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/getchartdatatable/). Du kan styra tre typer av kanter oberoende:

- [setBorderHorizontal](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datatable/setborderhorizontal/) styr horisontella cellkanter.
- [setBorderVertical](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datatable/setbordervertical/) styr vertikala cellkanter.
- [setBorderOutline](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datatable/setborderoutline/) styr tabellens yttre kant.

Skicka `true` till varje metod för att visa dess kanter eller `false` för att dölja dem. Följande exempel skapar ett grupperat stapeldiagram med standarddata, visar horisontella kanter och den yttre kanten, och döljer vertikala kanter. Det kräver ingen indatafil. Diagrammets position och storlek anges i punkter.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jämförelsen nedan använder samma diagramdata och förklaringsnyckelinställning i alla fyra fallen. Med alla kanter aktiverade inaktiverar varje återstående variant bara en kantinställning. Varianten längst ner till vänster matchar kantinställningarna i exemplet.

![Diagramdatatabeller med alla kanter aktiverade, inga horisontella kanter, inga vertikala kanter och ingen yttre kant](data-table-borders.png)

## **Visa eller dölja förklaringsnycklar**

Förklaringsnycklar är små färgade markörer bredvid serienamnen i datatabellen. De hjälper läsaren att matcha varje tabellrad med ett diagramserie. Skicka `true` till [setShowLegendKey](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datatable/setshowlegendkey/) för att visa dessa markörer eller `false` för att dölja dem.

Diagrammets separata förklaring styrs av [Chart.setLegend](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/setlegend/). Dessa inställningar är oberoende: att dölja den separata förklaringen döljer inte nycklarna i datatabellen, och att dölja tabellens nycklar döljer inte den separata förklaringen.

Följande exempel skapar ett diagram med standarddata, aktiverar dess datatabell och visar förklaringsnycklar i den samtidigt som den separata förklaringen döljs. Alla tabellkanter är uttryckligen aktiverade. Ingen indata‑presentation krävs. För att bara dölja tabellens nycklar, skicka `false` till [setShowLegendKey](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jämförelsen nedan visar samma tabell med förklaringsnycklar aktiverade respektive inaktiverade. Alla kanter förblir aktiverade, och den separata diagram‑förklaringen är dold i båda fallen.

![Diagramdatatabeller med förklaringsnycklar visas till vänster och döljs till höger](data-table-legend-keys.png)

## **FAQ**

**Kan jag visa förklaringsnycklar i ett diagram:s datatabell?**

Ja. Skicka `true` till [setShowLegendKey](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/datatable/setshowlegendkey/) för att visa förklaringsnycklar eller `false` för att dölja dem.

**Behålls datatabellen när presentationen exporteras till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet och dess visade datatabell som en del av bilden vid export till [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/), eller [bilder](/slides/sv/nodejs-java/convert-powerpoint-to-png/).

**Kan jag arbeta med datatabeller i diagram som laddats från en mall?**

Ja. För ett diagram som laddats från en befintlig presentation eller mall, använd [hasDataTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/hasdatatable/) och [setDataTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/setdatatable/) för att kontrollera eller ändra om dess datatabell visas.

**Hur hittar jag diagram som har en datatabell aktiverad?**

Iterera genom formerna på varje bild, identifiera diagrammen och anropa deras [hasDataTable](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/hasdatatable/)‑metod. Ett värde på `true` indikerar att datatabellen är aktiverad.

---
title: Anpassa diagrammets datatabeller i presentationer med JavaScript
linktitle: Datatabell
type: docs
url: /sv/nodejs-java/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Anpassa diagrammets datatabellens teckensnitt, kanter och förklaringsnycklar i PowerPoint-presentationer med Aspose.Slides för Node.js via Java."
---