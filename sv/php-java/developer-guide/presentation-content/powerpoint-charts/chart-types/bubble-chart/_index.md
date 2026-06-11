---
title: Anpassa bubbeldiagram i presentationer med PHP
linktitle: Bubbeldiagram
type: docs
url: /sv/php-java/bubble-chart/
keywords:
- bubbeldiagram
- bubblestorlek
- storlekskalning
- storleksrepresentation
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Skapa och anpassa kraftfulla bubbeldiagram i PowerPoint med Aspose.Slides för PHP via Java för att enkelt förbättra din datavisualisering."
---
## **Översikt**

Denna artikel visar hur man arbetar med bubbeldiagram i Aspose.Slides. Den täcker två specifika anpassningsalternativ: skalning av bubbelformer via metoden `setBubbleSizeScale` och kontroll av hur bubbelformsvärden representeras via metoden `setBubbleSizeRepresentation`.

Exemplen demonstrerar hur man skapar ett bubbeldiagram, justerar dess skalning och byter representation av bubbelformen till att använda bredd. Artikeln innehåller också en kort FAQ‑sektion som förklarar stöd för diagramtypen “Bubble with 3‑D”, noterar att praktiska diagramgränser beror på prestanda och målsättningsversion av PowerPoint, samt förklarar att export bevarar diagrammets utseende via Aspose.Slides rendering‑motor.

## **Skalning av bubbeldiagramstorlek**
Aspose.Slides for PHP via Java erbjuder stöd för skalning av bubbeldiagramstorlek. I Aspose.Slides for PHP via Java [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) och [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/) har metoder lagts till. Nedan ges ett exempel.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 100, 100, 400, 300);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeScale(150);
    $pres->save("Result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Representera data som bubbeldiagramstorlekar**
Metoderna [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) och [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) har lagts till i klasserna [ChartSeries](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseriesgroup/) och relaterade klasser. **BubbleSizeRepresentation** specificerar hur bubbelformsvärden representeras i bubbeldiagrammet. Möjliga värden är: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/BubbleSizeRepresentationType#Area) och [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/BubbleSizeRepresentationType#Width). Därmed har enum‑värdet [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/BubbleSizeRepresentationType) lagts till för att specificera de möjliga sätten att representera data som bubbeldiagramstorlekar. Exempel på kod ges nedan.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setBubbleSizeRepresentation(BubbleSizeRepresentationType::Width);
    $pres->save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Stöds ett "bubbeldiagram med 3‑D‑effekt", och hur skiljer det sig från ett vanligt?**

Ja. Det finns en separat diagramtyp, "Bubble with 3‑D." Den tillämpar 3‑D‑stil på bubblorna men lägger inte till en extra axel; data förblir X‑Y‑S (storlek). Typen finns i klassen [chart type](https://reference.aspose.com/slides/sv/php-java/aspose.slides/charttype/).

**Finns det någon gräns för antal serier och punkter i ett bubbeldiagram?**

Det finns ingen hård gräns på API‑nivå; begränsningarna bestäms av prestanda och mål‑PowerPoint‑versionen. Det rekommenderas att hålla antalet punkter rimligt för läsbarhet och renderingshastighet.

**Hur påverkar export utseendet på ett bubbeldiagram (PDF, bilder)?**

Export till stödjade format bevarar diagrammets utseende; rendering utförs av Aspose.Slides‑motorn. För raster‑/vektormatser gäller allmänna regler för diagramgrafikrendering (upplösning, kantutjämning), så välj tillräcklig DPI för utskrift.