---
title: Přizpůsobení legend grafů v prezentacích pomocí PHP
linktitle: Legenda grafu
type: docs
url: /cs/php-java/chart-legend/
keywords:
- legenda grafu
- umístění legendy
- velikost písma
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro PHP přes Java a optimalizujte prezentace PowerPoint pomocí nastaveného formátování legendy."
---
## **Overview**

Aspose.Slides poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak nastavit pozici a velikost legendy, nastavit velikost písma pro celou legendu a aplikovat formátování na jednotlivý záznam legendy.

Také pokrývá několik souvisejících chování v sekci FAQ, včetně použití režimu bez překrytí, aby oblast grafu udělala místo legendě, umožnění dlouhých popisků legendy zalamovat se nebo používat konce řádků a umožnění, aby formátování legendy zdědilo vzhled z motivu prezentace, pokud nejsou nastaveny explicitní nastavení textu a výplně.

## **Legend Positioning**

Pro nastavení vlastností legendy postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Získejte referenci na snímek.
- Přidejte graf na snímek.
- Nastavte vlastnosti legendy.
- Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme nastavili pozici a velikost legendy grafu.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Získejte referenci na snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Přidejte seskupený sloupcový graf na snímek
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Nastavte vlastnosti legendy
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Uložte prezentaci na disk
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set the Font Size of a Legend**

Aspose.Slides for PHP via Java umožňuje vývojářům nastavit velikost písma legendy. Postupujte podle následujících kroků: 

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Vytvořte výchozí graf.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Set the Font Size of an Individual Legend**

Aspose.Slides for PHP via Java umožňuje vývojářům nastavit velikost písma jednotlivých položek legendy. Postupujte podle následujících kroků: 

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Vytvořte výchozí graf.
- Přistupte k položce legendy.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Ano. Použijte režim bez překrytí ([setOverlay(false)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/legend/setoverlay/)); v tomto případě se oblast grafu zmenší, aby poskytla místo legendě.

**Can I make multi-line legend labels?**

Ano. Dlouhé popisky se automaticky zalamují, pokud není dostatek místa; nucené zalomení řádku je podporováno pomocí znaků nového řádku v názvu řady.

**How do I make the legend follow the presentation theme’s color scheme?**

Nenastavujte explicitní barvy/výplně/písma pro legendu nebo její text. Pak zdědí hodnoty z motivu a budou se správně aktualizovat při změně návrhu.