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
description: "Anpassa diagramdatatabeller för PPT och PPTX med Aspose.Slides för PHP via Java för att öka effektiviteten och attraktionskraften i presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramdatatabeller i Aspose.Slides. Den visar hur man visar en datatabell för ett diagram och anpassar dess textformatering genom att ange teckensnittsegenskaper som fet stil och teckenhöjd. Exemplet demonstrerar hur man laddar en presentation, lägger till ett diagram, aktiverar diagrammets datatabell, tillämpar teckensnittinställningar och sparar den uppdaterade presentationen.

Den innehåller även korta svar på vanliga frågor om att visa förklaringsnycklar i en diagramdatatabell, bevara datatabellen vid export, arbeta med diagram som laddas från befintliga presentationer eller mallar, samt identifiera diagram där datatabellen är aktiverad.

## **Ställ in teckensnittsegenskaper för en diagramdatatabell**

Aspose.Slides for PHP via Java ger stöd för att ändra färg på kategorier i en seriefärg.

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) klassobjekt.
1. Lägg till ett diagram på bilden.
1. ställ in diagrammets tabell.
1. Ställ in teckenhöjd.
1. Spara den modifierade presentationen.

Nedan ges ett exempel.

```php
  # Skapar tom presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan jag visa små förklaringsnycklar bredvid värdena i diagrammets datatabell?**

Ja. Datatabellen stödjer [legend keys](https://reference.aspose.com/slides/sv/php-java/aspose.slides/datatable/setshowlegendkey/), och du kan slå på eller av dem.

**Kommer datatabellen att bevaras vid export av presentationen till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet som en del av bilden, så den exporterade [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/sv/php-java/convert-powerpoint-to-html/)/[image](/slides/sv/php-java/convert-powerpoint-to-png/) innehåller diagrammet med dess datatabell.

**Stöds datatabeller för diagram som kommer från en mallfil?**

Ja. För alla diagram som laddas från en befintlig presentation eller mall kan du kontrollera och ändra om en datatabell [visas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/hasdatatable/) med hjälp av diagrammets egenskaper.

**Hur kan jag snabbt hitta vilka diagram i en fil som har datatabellen aktiverad?**

Inspektera varje diagram egenskap som indikerar om datatabellen [visas](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/hasdatatable/) och gå igenom bilderna för att identifiera de diagram där den är aktiverad.