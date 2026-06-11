---
title: Lägg till trendlinjer i presentationsdiagram i PHP
linktitle: Trendlinje
type: docs
url: /sv/php-java/trend-line/
keywords:
- diagram
- trendlinje
- exponentiell trendlinje
- linjär trendlinje
- logaritmisk trendlinje
- glidande medelvärdetrendlinje
- polynomisk trendlinje
- potens trendlinje
- anpassad trendlinje
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Snabbt lägg till och anpassa trendlinjer i PowerPoint-diagram med Aspose.Slides för PHP via Java — en praktisk guide för att engagera din publik."
---
## **Översikt**

Den här artikeln förklarar hur man lägger till trendlinjer i presentationsdiagram med Aspose.Slides. Den visar hur man skapar ett diagram, lägger till trendlinjer i diagramserier och arbetar med flera typer av trendlinjer, inklusive exponentiell, linjär, logaritmisk, glidande medelvärde, polynomisk och potens.

Den beskriver också hur man lägger till en anpassad linje i ett diagram genom att infoga en linjeform, och innehåller en kort FAQ om framåt- och bakåtriktade trendlinjeprojektioner samt om trendlinjer bevaras vid export till PDF eller SVG och vid rendering av diagram som bilder.

## **Lägg till en trendlinje**
Aspose.Slides for PHP via Java tillhandahåller ett enkelt API för att hantera olika diagramtrendlinjer:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
2. Hämta en slides referens genom dess index.
3. Lägg till ett diagram med standarddata samt önskad typ (detta exempel använder ChartType::ClusteredColumn).
4. Lägger till en exponentiell trendlinje för diagramserie 1.
5. Lägger till en linjär trendlinje för diagramserie 1.
6. Lägger till en logaritmisk trendlinje för diagramserie 2.
7. Lägger till en glidande medelvärdestrendlinje för diagramserie 2.
8. Lägger till en polynomisk trendlinje för diagramserie 3.
9. Lägger till en potens trendlinje för diagramserie 3.
10. Skriv den modifierade presentationen till en PPTX-fil.

Följande kod används för att skapa ett diagram med trendlinjer.

```php
  # Skapa en instans av Presentation-klass
  $pres = new Presentation();
  try {
    # Skapar ett grupperat stapeldiagram
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Lägger till exponentiell trendlinje för diagramserie 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Lägger till linjär trendlinje för diagramserie 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Lägger till logaritmisk trendlinje för diagramserie 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Lägger till glidande medelvärdestrendlinje för diagramserie 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Lägger till polynomisk trendlinje för diagramserie 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Lägger till potens trendlinje för diagramserie 3
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Sparar presentationen
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till en anpassad linje**
Aspose.Slides for PHP via Java tillhandahåller ett enkelt API för att lägga till anpassade linjer i ett diagram. För att lägga till en enkel rak linje i en vald slide i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
- Hämta referensen till en slide genom att använda dess Index.
- Skapa ett nytt diagram med metoden AddChart som exponeras av Shapes-objektet.
- Lägg till en AutoShape av typ Linje med metoden AddAutoShape som exponeras av Shapes-objektet.
- Ställ in färgen på formens linjer.
- Skriv den modifierade presentationen som en PPTX-fil.

Följande kod används för att skapa ett diagram med anpassade linjer.

```php
  # Skapa en instans av Presentation-klass
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $shape = $chart->getUserShapes()->getShapes()->addAutoShape(ShapeType::Line, 0, $chart->getHeight() / 2, $chart->getWidth(), 0);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("Presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Vad betyder 'forward' och 'backward' för en trendlinje?**

De är längderna på trendlinjen projicerade framåt/bakåt: för spridningsdiagram (XY) — i axelenheter; för icke‑spridningsdiagram — i antal kategorier. Endast icke‑negativa värden är tillåtna.

**Kommer trendlinjen att bevaras vid export av presentationen till PDF eller SVG, eller när en slide renderas till en bild?**

Ja. Aspose.Slides konverterar presentationer till [PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/sv/php-java/render-a-slide-as-an-svg-image/) och renderar diagram till bilder; trendlinjer, som en del av diagrammet, bevaras under dessa operationer. En metod finns också för att [exportera en bild av diagrammet](/slides/sv/php-java/create-shape-thumbnails/).