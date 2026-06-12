---
title: Přizpůsobení bublinových grafů v prezentacích pomocí PHP
linktitle: Bublinový graf
type: docs
url: /cs/php-java/bubble-chart/
keywords:
- bublinový graf
- velikost bubliny
- škálování velikosti
- reprezentace velikosti
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte a přizpůsobte výkonné bublinové grafy v PowerPointu s Aspose.Slides pro PHP přes Java, abyste snadno vylepšili vizualizaci dat."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s bublinovými grafy v Aspose.Slides. Pokrývá dvě konkrétní možnosti přizpůsobení: škálování velikosti bublin metodou `setBubbleSizeScale` a řízení toho, jak jsou hodnoty velikosti bublin reprezentovány metodou `setBubbleSizeRepresentation`. Ukázky demonstrují, jak vytvořit bublinový graf, upravit jeho škálování velikosti a přepnout reprezentaci velikosti bubliny na šířku. Článek také obsahuje stručnou sekci FAQ, která objasňuje podporu typu grafu „Bubble with 3‑D“, uvádí, že praktická omezení grafu závisí na výkonu a cílové verzi PowerPointu, a vysvětluje, že export zachovává vzhled grafu pomocí renderovacího enginu Aspose.Slides.

## **Škálování velikosti bublinového grafu**
Aspose.Slides for PHP via Java poskytuje podporu pro škálování velikosti bublinového grafu. V Aspose.Slides for PHP via Java byly přidány metody [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/getbubblesizescale/), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/getbubblesizescale/) a [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/setbubblesizescale/). Níže je uveden ukázkový příklad. 

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

## **Reprezentovat data jako velikosti bublin v grafu**
Metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/setbubblesizerepresentation/) a [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/getbubblesizerepresentation/) byly přidány do tříd [ChartSeries](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseries/), [ChartSeriesGroup](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriesgroup/) a souvisejících tříd. **BubbleSizeRepresentation** určuje, jak jsou hodnoty velikosti bublin v bublinovém grafu reprezentovány. Možné hodnoty jsou: [**BubbleSizeRepresentationType::Area**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/BubbleSizeRepresentationType#Area) a [**BubbleSizeRepresentationType::Width**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/BubbleSizeRepresentationType#Width). V souladu s tím byl přidán výčet [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/BubbleSizeRepresentationType), který určuje možné způsoby, jak reprezentovat data jako velikosti bublin v grafu. Ukázkový kód je uveden níže.

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

## **Často kladené otázky**

**Je podporován „bublinový graf s 3‑D efektem“ a jak se liší od běžného?**

Ano. Existuje samostatný typ grafu „Bubble with 3‑D“. Používá 3‑D stylování na bubliny, ale nepřidává další osu; data zůstávají X‑Y‑S (velikost). Tento typ je k dispozici ve třídě [chart type](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/).

**Existuje limit na počet sérií a bodů v bublinovém grafu?**

Na úrovni API neexistuje pevný limit; omezení jsou určena výkonem a cílovou verzí PowerPointu. Doporučuje se udržovat počet bodů na rozumné úrovni pro čitelnost a rychlost renderování.

**Jak export ovlivní vzhled bublinového grafu (PDF, obrázky)?**

Export do podporovaných formátů zachovává vzhled grafu; renderování provádí engine Aspose.Slides. Pro rastrové/vektorové formáty platí obecná pravidla renderování grafických prvků (rozlišení, anti‑aliasing), takže pro tisk zvolte dostatečnou DPI.