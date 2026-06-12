---
title: Přidání trendových čar do grafů v prezentaci v PHP
linktitle: Trendová čára
type: docs
url: /cs/php-java/trend-line/
keywords:
- graf
- trendová čára
- exponenciální trendová čára
- lineární trendová čára
- logaritmická trendová čára
- trendová čára klouzavého průměru
- polynomická trendová čára
- mocninná trendová čára
- vlastní trendová čára
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Rychle přidejte a upravte trendové čáry v grafech PowerPointu pomocí Aspose.Slides pro PHP přes Java — praktický průvodce, jak zaujmout své publikum."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides přidat do grafů v prezentaci trendové čáry. Ukazuje, jak vytvořit graf, přidat trendové čáry do sérií grafu a pracovat s několika typy trendových čar, včetně exponenciální, lineární, logaritmické, klouzavého průměru, polynomické a mocninné.

Také popisuje, jak do grafu přidat vlastní čáru vložením tvaru čáry, a obsahuje krátké FAQ o hodnotách projekce trendové čáry vpřed a vzad a o tom, zda jsou trendové čáry zachovány při exportu do PDF nebo SVG a při vykreslování grafů jako obrázků.

## **Přidání trendové čáry**
Aspose.Slides for PHP via Java poskytuje jednoduché rozhraní API pro správu různých trendových čar v grafech:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek podle jeho indexu.
3. Přidejte graf s výchozími daty a požadovaným typem (v tomto příkladu se používá ChartType::ClusteredColumn).
4. Přidání exponenciální trendové čáry pro sérii grafu 1.
5. Přidání lineární trendové čáry pro sérii grafu 1.
6. Přidání logaritmické trendové čáry pro sérii grafu 2.
7. Přidání trendové čáry klouzavého průměru pro sérii grafu 2.
8. Přidání polynomické trendové čáry pro sérii grafu 3.
9. Přidání mocninné trendové čáry pro sérii grafu 3.
10. Zapíšete upravenou prezentaci do souboru PPTX.

Následující kód slouží k vytvoření grafu s trendovými čarami.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Vytvoření seskupeného sloupcového grafu
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);
    # Přidání exponenciální trendové čáry pro sérii grafu 1
    $tredLinep = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Exponential);
    $tredLinep->setDisplayEquation(false);
    $tredLinep->setDisplayRSquaredValue(false);
    # Přidání lineární trendové čáry pro sérii grafu 1
    $tredLineLin = $chart->getChartData()->getSeries()->get_Item(0)->getTrendLines()->add(TrendlineType::Linear);
    $tredLineLin->setTrendlineType(TrendlineType::Linear);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $tredLineLin->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Přidání logaritmické trendové čáry pro sérii grafu 2
    $tredLineLog = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Logarithmic);
    $tredLineLog->setTrendlineType(TrendlineType::Logarithmic);
    $tredLineLog->addTextFrameForOverriding("New log trend line");
    # Přidání trendové čáry klouzavého průměru pro sérii grafu 2
    $tredLineMovAvg = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::MovingAverage);
    $tredLineMovAvg->setTrendlineType(TrendlineType::MovingAverage);
    $tredLineMovAvg->setPeriod(3);
    $tredLineMovAvg->setTrendlineName("New TrendLine Name");
    # Přidání polynomické trendové čáry pro sérii grafu 3
    $tredLinePol = $chart->getChartData()->getSeries()->get_Item(2)->getTrendLines()->add(TrendlineType::Polynomial);
    $tredLinePol->setTrendlineType(TrendlineType::Polynomial);
    $tredLinePol->setForward(1);
    $tredLinePol->setOrder(3);
    # Přidání mocninné trendové čáry pro sérii grafu 3
    $tredLinePower = $chart->getChartData()->getSeries()->get_Item(1)->getTrendLines()->add(TrendlineType::Power);
    $tredLinePower->setTrendlineType(TrendlineType::Power);
    $tredLinePower->setBackward(1);
    # Ukládání prezentace
    $pres->save("ChartTrendLines_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání vlastní čáry**
Aspose.Slides for PHP via Java poskytuje jednoduché rozhraní API pro přidání vlastních čar do grafu. Chcete-li do vybraného snímku prezentace přidat jednoduchou rovnou čáru, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Vytvořte nový graf pomocí metody AddChart, která je součástí objektu Shapes.
- Přidejte AutoShape typu Line pomocí metody AddAutoShape, která je součástí objektu Shapes.
- Nastavte barvu čar tvary.
- Uložte upravenou prezentaci jako soubor PPTX.

Následující kód slouží k vytvoření grafu s vlastními čarami.

```php
  # Vytvořte instanci třídy Presentation
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

## **FAQ**

**Co znamená 'forward' a 'backward' u trendové čáry?**

Jedná se o délky trendové čáry projektované dopředu či dozadu: pro rozptylové (XY) grafy – v jednotkách osy; pro ne‑rozptylové grafy – v počtu kategorií. Povolené jsou pouze nezáporné hodnoty.

**Zůstane trendová čára zachována při exportu prezentace do PDF nebo SVG, nebo při vykreslování snímku do obrázku?**

Ano. Aspose.Slides převádí prezentace do [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/)/[SVG](/slides/cs/php-java/render-a-slide-as-an-svg-image/) a vykresluje grafy do obrázků; trendové čáry jako součást grafu jsou během těchto operací zachovány. K dispozici je také metoda pro [export an image of the chart](/slides/cs/php-java/create-shape-thumbnails/).