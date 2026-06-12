---
title: Přizpůsobení oblastí vykreslení grafů v prezentacích v PHP
linktitle: Oblast vykreslení
type: docs
url: /cs/php-java/chart-plot-area/
keywords:
- graf
- oblast vykreslení
- šířka oblasti vykreslení
- výška oblasti vykreslení
- velikost oblasti vykreslení
- režim rozvržení
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Objevte, jak přizpůsobit oblasti vykreslení grafů v prezentacích PowerPoint pomocí Aspose.Slides pro PHP přes Java. Zlepšete vizuální podobu snímků snadno."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s oblastí vykreslení grafu v Aspose.Slides. Vysvětluje, jak získat skutečnou polohu a velikost oblasti vykreslení ověřením rozvržení grafu a následným čtením hodnot X, Y, šířky a výšky.

Také ukazuje, jak nastavit režim rozvržení oblasti vykreslení, když je rozvržení nastaveno ručně, pomocí `LayoutTargetType` k určení, zda se oblast vykreslení počítá podle svého vnitřního regionu nebo podle vnějšího regionu spolu s osami a popisky os.

## **Získání šířky a výšky plochy grafu**
Aspose.Slides pro PHP přes Java poskytuje jednoduché API pro .

1. Vytvořte instanci třídy[Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Přistupte k prvnímu snímku.
3. Přidejte graf s výchozími daty.
4. Zavolejte metodu[Chart.validateChartLayout](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/validatechartlayout/) před získáním skutečných hodnot.
5. Získá skutečnou polohu X (levá) elementu grafu relativně k levému hornímu rohu grafu.
6. Získá skutečnou horní polohu elementu grafu relativně k levému hornímu rohu grafu.
7. Získá skutečnou šířku elementu grafu.
8. Získá skutečnou výšku elementu grafu.

```php
  # Vytvořte instanci třídy Presentation
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

## **Nastavení režimu rozvržení plochy grafu**
Aspose.Slides pro PHP přes Java poskytuje jednoduché API pro nastavení režimu rozvržení oblasti vykreslení grafu. Metody[**setLayoutTargetType**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) a[**getLayoutTargetType**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) byly přidány do třídy[**ChartPlotArea**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ChartPlotArea). Pokud je rozvržení oblasti vykreslení definováno ručně, tato vlastnost určuje, zda se oblast vykreslení rozvrhuje podle vnitřku (bez zahrnutí os a popisků os) nebo podle vnějšího okraje (včetně os a popisků os). Existují dvě možné hodnoty, které jsou definovány v enumeraci[**LayoutTargetType**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LayoutTargetType#Inner) – určuje, že velikost plochy grafu určuje velikost plochy grafu, bez zahrnutí značek a popisků os.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/LayoutTargetType#Outer) – určuje, že velikost plochy grafu určuje velikost plochy grafu, značky a popisky os.

Ukázkový kód je uveden níže.

```php
  # Vytvořte instanci třídy Presentation
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

## **FAQ**

**V jakých jednotkách jsou vráceny skutečné x, skutečné y, skutečná šířka a skutečná výška?**

V bodech; 1 palec = 72 bodů. Jedná se o souřadnicové jednotky Aspose.Slides.

**Jak se oblast vykreslení liší od oblasti grafu z hlediska obsahu?**

Oblast vykreslení je oblast pro vykreslení dat (řady, mřížky, trendové čáry atd.); oblast grafu zahrnuje okolní prvky (název, legendu atd.). Ve 3D grafech oblast vykreslení také zahrnuje stěny/podlahu a osy.

**Jak jsou x, y, šířka a výška oblasti vykreslení interpretovány, když je rozvržení ruční?**

Jedná se o zlomky (0–1) celkové velikosti grafu; v tomto režimu je automatické umístění zakázáno a použijí se zlomky, které jste nastavili.

**Proč se pozice oblasti vykreslení změnila po přidání/přesunutí legendy?**

Legenda sídlí v oblasti grafu mimo oblast vykreslení, ale ovlivňuje rozvržení a dostupný prostor, takže oblast vykreslení může posunout, když je v platnosti automatické umístění. (Toto je standardní chování grafů v PowerPointu.)