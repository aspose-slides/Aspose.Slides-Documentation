---
title: Anpassa diagrammets plotområden i presentationer i PHP
linktitle: Plotområde
type: docs
url: /sv/php-java/chart-plot-area/
keywords:
- diagram
- plotområde
- plotområdesbredd
- plotområdeshöjd
- plotområdesstorlek
- layoutläge
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Upptäck hur du anpassar diagrammets plotområden i PowerPoint-presentationer med Aspose.Slides för PHP via Java. Förbättra dina bildspel visuellt utan ansträngning."
---
## **Översikt**

Den här artikeln visar hur man arbetar med diagrammets plotområde i Aspose.Slides. Den förklarar hur man får den faktiska positionen och storleken på plotområdet genom att validera diagramlayouten och sedan läsa dess X-, Y-, bredd- och höjdvärden.

Den visar också hur man konfigurerar plotområdets layoutläge när layouten sätts manuellt, med `LayoutTargetType` för att definiera om plotområdet beräknas av dess inre region eller av dess yttre region tillsammans med axlar och axelrubriker.

## **Hämta bredd och höjd på diagrammets plotområde**
Aspose.Slides för PHP via Java tillhandahåller ett enkelt API för .

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Hämta den första bilden.
1. Lägg till ett diagram med standarddata.
1. Anropa metoden [Chart.validateChartLayout](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/validatechartlayout/) innan för att få faktiska värden.
1. Hämtar den faktiska X‑positionen (vänster) för diagramelementet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska toppen för diagramelementet relativt diagrammets övre vänstra hörn.
1. Hämtar den faktiska bredden på diagramelementet.
1. Hämtar den faktiska höjden på diagramelementet.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $x = $chart->getPlotArea()->getActualX();
    $y = $chart->getPlotArea()->getActualY();
    $w = $chart->getPlotArea()->getActualWidth();
    $h = $chart->getPlotArea()->getActualHeight();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ställ in layoutläget för diagrammets plotområde**
Aspose.Slides för PHP via Java tillhandahåller ett enkelt API för att ställa in layoutläget för diagrammets plotområde. Metoderna [**setLayoutTargetType**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) och [**getLayoutTargetType**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) har lagts till i klassen [**ChartPlotArea**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ChartPlotArea). Om layouten för plotområdet definieras manuellt anger den här egenskapen om plotområdet ska layoutas av sin insida (utan axlar och axelrubriker) eller av sin utsida (inklusive axlar och axelrubriker). Det finns två möjliga värden som definieras i enumen [**LayoutTargetType**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LayoutTargetType#Inner) - anger att plotområdets storlek ska bestämma storleken på plotområdet, utan att inkludera tick‑märken och axelrubriker.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LayoutTargetType#Outer) - anger att plotområdets storlek ska bestämma storleken på plotområdet, tick‑märkena och axelrubrikerna.

Exempelkod ges nedan.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getPlotArea()->setX(0.2);
    $chart->getPlotArea()->setY(0.2);
    $chart->getPlotArea()->setWidth(0.7);
    $chart->getPlotArea()->setHeight(0.7);
    $chart->getPlotArea()->setLayoutTargetType(LayoutTargetType::Inner);
    $pres->save("SetLayoutMode_outer.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**I vilka enheter returneras faktisk x, faktisk y, faktisk bredd och faktisk höjd?**  
I punkter; 1 tum = 72 punkter. Detta är Aspose.Slides koordinatenheter.

**Hur skiljer sig plotområdet från diagramområdet när det gäller innehåll?**  
Plotområdet är dataritningsområdet (serier, rutnät, trendlinjer osv.); diagramområdet inkluderar de omgivande elementen (titel, legend osv.). I 3D-diagram inkluderar plotområdet även väggarna/golvet och axlarna.

**Hur tolkas plotområdets x, y, bredd och höjd när layouten är manuell?**  
De är bråk (0–1) av diagrammets totala storlek; i detta läge är automatisk positionering inaktiverad och de bråk du anger används.

**Varför ändrades plotområdets position efter att legend har lagts till/förflyttats?**  
Legenden placeras i diagramområdet utanför plotområdet men påverkar layouten och tillgängligt utrymme, så plotområdet kan förflyttas när automatisk positionering är aktiv. (Detta är standardbeteende för PowerPoint-diagram.)