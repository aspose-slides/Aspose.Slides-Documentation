---
title: Anpassa diagramdatatabeller i presentationer med PHP
linktitle: Datatabell
type: docs
url: /sv/php-java/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Anpassa diagrammets datatabellens teckensnitt, kantlinjer och förklaringsnycklar i PowerPoint-presentationer med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides för PHP via Java låter dig visa ett diagrammets datatabell och anpassa dess textformatering, kantlinjer och förklaringsnycklar. Den här artikeln förklarar hur du aktiverar tabellen, formaterar texten, styr varje typ av kantlinje och visar eller döljer förklaringsnycklar. Exemplen sparar de konfigurerade diagrammen i PPTX-filer.

## **Ställ in teckensnittsegenskaper**

För att visa ett diagrammets datatabell, skicka `true` till [setDataTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/setdatatable/). Använd [getChartDataTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/getchartdatatable/) för att komma åt tabellen och konfigurera dess textformatering.

1. Läs in presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Lägg till ett sammanslaget kolumndiagram på den första bilden.
1. Aktivera diagrammets datatabell.
1. Aktivera fet text med [setFontBold](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setFontBold) och skicka `20` till [setFontHeight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setFontHeight) för 20‑punkters text.
1. Spara den ändrade presentationen.

Följande exempel kräver `test.pptx` i arbetskatalogen med minst en bild. Det lägger till ett diagram med standarddata på position (50, 50), med en bredd på 600 punkter och en höjd på 400 punkter. Den sparade `output.pptx` innehåller diagrammet med dess datatabell aktiverad och de angivna teckensnittinställningarna tillämpade.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Anpassa datatabellens kantlinjer**

Aktivera tabellen med [Chart::setDataTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/setdatatable/) och få åtkomst till den via [Chart::getChartDataTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/getchartdatatable/). Du kan styra tre typer av kantlinjer oberoende:

- [setBorderHorizontal](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datatable/setborderhorizontal/) styr horisontella cellkantlinjer.
- [setBorderVertical](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datatable/setbordervertical/) styr vertikala cellkantlinjer.
- [setBorderOutline](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datatable/setborderoutline/) styr den yttre kantlinjen på tabellen.

Skicka `true` till varje metod för att visa dess kantlinjer eller `false` för att dölja dem. Följande exempel skapar ett sammanslaget kolumndiagram med standarddata, visar horisontella kantlinjer och den yttre kantlinjen och döljer vertikala kantlinjer. Det kräver ingen indatafil. Diagrammets position och storlek anges i punkter.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jämförelsen nedan använder samma diagramdata och förklaringsnyckelinställning i alla fyra fallen. Med alla kantlinjer aktiverade inaktiveras i varje efterföljande variant bara en kantlinje. Variant nedre vänster matchar kantlinjeinställningarna i exemplet.

![Diagramdatatabeller med alla kantlinjer aktiverade, inga horisontella kantlinjer, inga vertikala kantlinjer och ingen yttre kantlinje](data-table-borders.png)

## **Visa eller dölja förklaringsnycklar**

Förklaringsnycklar är små färgade markörer bredvid seriernas namn i datatabellen. De hjälper läsaren att matcha varje tabellrad med ett diagramserie. Skicka `true` till [setShowLegendKey](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datatable/setshowlegendkey/) för att visa dessa markörer eller `false` för att dölja dem.

Diagrammets separata förklaring styrs av [Chart::setLegend](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/setlegend/). Dessa inställningar är oberoende: att dölja den separata förklaringen döljer inte nycklarna i datatabellen, och att dölja tabellens nycklar döljer inte den separata förklaringen.

Följande exempel skapar ett diagram med standarddata, aktiverar dess datatabell och visar förklaringsnycklar i den samtidigt som den separata förklaringen döljas. Alla tabellkantlinjer är uttryckligen aktiverade. Ingen indata‑presentation krävs. För att endast dölja tabellens nycklar, skicka `false` till [setShowLegendKey](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jämförelsen nedan visar samma tabell med förklaringsnycklar visas till vänster och dolda till höger. Alla kantlinjer förblir aktiverade, och den separata diagramförklaringen är dold i båda fallen.

![Diagramdatatabeller med förklaringsnycklar visas till vänster och dolda till höger](data-table-legend-keys.png)

## **FAQ**

**Kan jag visa förklaringsnycklar i ett diagrammets datatabell?**

Ja. Skicka `true` till [setShowLegendKey](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datatable/setshowlegendkey/) för att visa förklaringsnycklar eller `false` för att dölja dem.

**Behålls datatabellen när presentationen exporteras till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet och dess visade datatabell som en del av bilden när man exporterar till [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/sv/php-java/convert-powerpoint-to-html/), eller [bilder](/slides/sv/php-java/convert-powerpoint-to-png/).

**Kan jag arbeta med datatabeller i diagram som laddas från en mall?**

Ja. För ett diagram som laddas från en befintlig presentation eller mall, använd [hasDataTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/hasdatatable/) och [setDataTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/setdatatable/) för att kontrollera eller ändra om dess datatabell visas.

**Hur kan jag hitta diagram som har en aktiv datatabell?**

Iterera genom formerna på varje bild, identifiera diagrammen och anropa deras [hasDataTable](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/hasdatatable/)‑metod. Ett värde på `true` indikerar att datatabellen är aktiverad.