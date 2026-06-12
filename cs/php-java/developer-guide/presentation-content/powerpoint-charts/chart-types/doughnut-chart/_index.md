---
title: Přizpůsobení prstencových grafů v prezentacích pomocí PHP
linktitle: Prstencový graf
type: docs
weight: 30
url: /cs/php-java/doughnut-chart/
keywords:
- prstencový graf
- středová mezera
- velikost díry
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat prstencové grafy v Aspose.Slides pro PHP pomocí Javy, s podporou formátů PowerPoint pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s prstencovým grafem v Aspose.Slides přidáním grafu na snímek, nastavením velikosti jeho středové díry a uložením prezentace. Zaměřuje se na metodu `setDoughnutHoleSize` a demonstruje základní kroky potřebné k přizpůsobení tohoto typu grafu v kódu.

Obsahuje také krátkou sekci FAQ, která pokrývá související scénáře s prstencovými grafy, jako je použití více sérií k vytvoření několika prstenců, práce s rozstřelenými prstencovými grafy a export grafu jako rastrový obrázek nebo SVG.

## **Určení středové mezery v prstencovém grafu**

Pro nastavení velikosti díry v prstencovém grafu postupujte podle následujících kroků:

1. Vytvořte objekt [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Přidejte prstencový graf na snímek.
1. Zadejte velikost díry v prstencovém grafu.
1. Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili velikost díry v prstencovém grafu.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Uložte prezentaci na disk
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Mohu vytvořit víceúrovňový prstencový graf s několika prstenci?**

Ano. Přidejte do jediného prstencového grafu více sérií – každá série se stane samostatným prstencem. Pořadí prstenců je určeno pořadím sérií v kolekci.

**Je podporován „rozstřelený“ prstencový graf (oddělené výsečě)?**

Ano. Existuje typ grafu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/) a vlastnost exploze na datových bodech; můžete oddělit jednotlivé výseče.

**Jak mohu získat obrázek prstencového grafu (PNG/SVG) pro zprávu?**

Graf je tvar; můžete jej vykreslit jako [rastrový obrázek](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage) nebo exportovat graf do [SVG obrázku](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#writeAsSvg).