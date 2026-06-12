---
title: Přizpůsobení 3D grafů v prezentacích pomocí PHP
linktitle: 3D graf
type: docs
url: /cs/php-java/3d-chart/
keywords:
- 3D graf
- rotace
- hloubka
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se vytvářet a přizpůsobovat 3D grafy v Aspose.Slides pro PHP přes Java, s podporou souborů PPT a PPTX — vylepšete své prezentace ještě dnes."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit 3D graf v Aspose.Slides nastavením parametrů `Rotation3D` jako `RotationX`, `RotationY`, `DepthPercents` a `RightAngleAxes`. Popisuje vytvoření prezentace, přidání 3D grafu s výchozími daty, aplikaci požadovaných nastavení 3D zobrazení a uložení upravené prezentace jako soubor PPTX.

## **Nastavte vlastnosti RotationX, RotationY a DepthPercents 3D grafu**
Aspose.Slides for PHP via Java poskytuje jednoduché rozhraní API pro nastavení těchto vlastností. Tento následující článek vám pomůže nastavit různé vlastnosti, jako jsou **X,Y Rotation, DepthPercents** atd. Vzorový kód ukazuje, jak nastavit výše uvedené vlastnosti.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Přistupte k první snímku.
3. Přidejte graf s výchozími daty.
4. Nastavte vlastnosti Rotation3D.
5. Zapište upravenou prezentaci do souboru PPTX.

```php
  $pres = new Presentation();
  try {
    # Přístup k prvnímu snímku
    $slide = $pres->getSlides()->get_Item(0);
    # Přidat graf s výchozími daty
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);
    # Nastavení indexu listu s daty grafu
    $defaultWorksheetIndex = 0;
    # Získání pracovního listu s daty grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Přidat sérii
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Přidat kategorie
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Nastavit vlastnosti Rotation3D
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);
    # Vybrat druhou sérii grafu
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Nyní vyplňování dat série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Nastavit hodnotu OverLap
    $series->getParentSeriesGroup()->setOverlap(100);
    # Zapsat prezentaci na disk
    $pres->save("Rotation3D_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Které typy grafů podporují 3D režim v Aspose.Slides?**

Aspose.Slides podporuje 3D varianty sloupcových grafů, včetně Column 3D, Clustered Column 3D, Stacked Column 3D a 100 % Stacked Column 3D, spolu s souvisejícími 3D typy, které jsou k dispozici prostřednictvím třídy [ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/). Pro přesný a aktuální seznam zkontrolujte členy [ChartType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/charttype/) v referenci API vaší nainstalované verze.

**Mohu získat rastrový obrázek 3D grafu pro zprávu nebo web?**

Ano. Graf můžete exportovat do obrázku pomocí [chart API](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage) nebo [vykreslit celý snímek](/slides/cs/php-java/convert-powerpoint-to-png/) do formátů jako PNG nebo JPEG. To je užitečné, když potřebujete dokonalý náhled v pixelech nebo chcete vložit graf do dokumentů, panelů nebo webových stránek bez nutnosti PowerPointu.

**Jak výkonná je tvorba a vykreslování velkých 3D grafů?**

Výkon závisí na objemu dat a vizuální složitosti. Pro nejlepší výsledky držte 3D efekty na minimu, vyhněte se těžkým texturám na stěnách a ploše grafu, pokud možno omezte počet datových bodů na sérii a vykreslujte do výstupu vhodných rozměrů (rozlišení a velikost), aby odpovídal cílovému zobrazovacímu nebo tiskovému zařízení.