---
title: Přizpůsobení chybových pruhů v prezentačních grafech pomocí PHP
linktitle: Chybový pruh
type: docs
url: /cs/php-java/error-bar/
keywords:
- chybový pruh
- vlastní hodnota
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak přidat a přizpůsobit chybové pruhy v grafech pomocí Aspose.Slides pro PHP přes Java — optimalizujte vizualizaci dat v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s chybovými pruhy v prezentačních grafech pomocí Aspose.Slides. Ukazuje, jak přidat chybové pruhy k sérii grafu, nakonfigurovat nastavení chybových pruhů X a Y a použít různé typy hodnot, jako jsou pevné, procentuální a vlastní hodnoty.

Také demonstruje, jak přiřadit vlastní hodnoty chybových pruhů jednotlivým datovým bodům v sérii pomocí odpovídající kolekce datových bodů. Navíc článek obsahuje stručné poznámky o tom, jak se chybové pruhy chovají během exportu, jejich kompatibilitě s značkami a popisky dat a kde najít související třídy a výčty v API referenci.

## **Přidání chybových pruhů**
Aspose.Slides for PHP via Java poskytuje jednoduché API pro správu hodnot chybových pruhů. Ukázkový kód platí při použití vlastního typu hodnoty. Chcete‑li zadat hodnotu, použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci [**datové body**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriescollection/) série:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybového pruhu X.
1. Získejte první sérii grafu a nastavte formát chybového pruhu Y.
1. Nastavte hodnoty a formát pruhů.
1. Uložte upravenou prezentaci do souboru PPTX.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Vytvoření bublinového grafu
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Přidání chybových pruhů a nastavení jejich formátu
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Uložení prezentace
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přidání vlastních hodnot chybových pruhů**
Aspose.Slides for PHP via Java poskytuje jednoduché API pro správu vlastních hodnot chybových pruhů. Ukázkový kód platí, když metoda [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/errorbarsformat/#getValueType) vrátí **Custom**. Chcete‑li zadat hodnotu, použijte vlastnost **ErrorBarCustomValues** konkrétního datového bodu v kolekci [**datové body**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chartseriescollection/) série:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Přidejte bublinový graf na požadovaný snímek.
1. Získejte první sérii grafu a nastavte formát chybového pruhu X.
1. Získejte první sérii grafu a nastavte formát chybového pruhu Y.
1. Získejte jednotlivé datové body série grafu a nastavte hodnoty chybových pruhů pro každý datový bod.
1. Nastavte hodnoty a formát pruhů.
1. Uložte upravenou prezentaci do souboru PPTX.

```php
  # Vytvořte instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Vytvoření bublinového grafu
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Přidání vlastních chybových pruhů a nastavení jejich formátu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Přístup k datovému bodu série grafu a nastavení hodnot chybových pruhů pro
    # jednotlivý bod
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Nastavení chybových pruhů pro body série grafu
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Uložení prezentace
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Co se stane s chybovými pruhy při exportu prezentace do PDF nebo obrázků?**

Jsou vykresleny jako součást grafu a během konverze zachovány spolu se zbytkem formátování grafu, za předpokladu kompatibilní verze nebo rendereru.

**Lze chybové pruhy kombinovat se značkami a popisky dat?**

Ano. Chybové pruhy jsou samostatný prvek a jsou kompatibilní se značkami a popisky dat; pokud se prvky překrývají, může být nutné upravit formátování.

**Kde najdu seznam vlastností a tříd pro práci s chybovými pruhy v API?**

V API referenci: třída [ErrorBarsFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/errorbarsformat/) a související třídy [ErrorBarType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/errorbartype/) a [ErrorBarValueType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/errorbarvaluetype/).