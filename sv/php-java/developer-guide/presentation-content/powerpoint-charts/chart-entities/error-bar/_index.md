---
title: Anpassa felstaplar i presentationsdiagram med PHP
linktitle: Felstapel
type: docs
url: /sv/php-java/error-bar/
keywords:
- felstapel
- anpassat värde
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du lägger till och anpassar felstaplar i diagram med Aspose.Slides för PHP via Java — optimera datavisualiseringar i PowerPoint‑presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med felstaplar i presentationsdiagram med hjälp av Aspose.Slides. Den visar hur man lägger till felstaplar i en diagramserie, konfigurerar X‑ och Y‑felstaplar, och använder olika värdetyper såsom fast, procentuell och anpassade värden.

Den visar också hur man tilldelar anpassade felstaplarvärden för enskilda datapunkter i en serie genom att använda den motsvarande datapunktssamlingen. Dessutom innehåller artikeln korta noter om hur felstaplar beter sig vid export, deras kompatibilitet med markörer och datatetiketter, samt var man hittar de relaterade API‑referensklasserna och uppräkningsvärdena.

## **Lägg till felstaplar**
Aspose.Slides för PHP via Java tillhandahåller ett enkelt API för att hantera felstaplarvärden. Exempelkoden gäller när en anpassad värdetyp används. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i samlingen av [**data points**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseriescollection/) för serier:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Åtkomst till den första diagramserien och ställ in X‑formatet för felstaplar.
1. Åtkomst till den första diagramserien och ställ in Y‑formatet för felstaplar.
1. Ställ in staplarnas värden och format.
1. Spara den ändrade presentationen till en PPTX‑fil.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Skapar ett bubbeldiagram
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Lägger till felstaplar och ställer in dess format
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
    # Sparar presentationen
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till anpassade felstaplarvärden**
Aspose.Slides för PHP via Java tillhandahåller ett enkelt API för att hantera anpassade felstaplarvärden. Exempelkoden gäller när metoden [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/errorbarsformat/#getValueType) returnerar **Custom**. För att ange ett värde, använd egenskapen **ErrorBarCustomValues** för en specifik datapunkt i samlingen av [**data points**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chartseriescollection/) för serier:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Lägg till ett bubbeldiagram på önskad bild.
1. Åtkomst till den första diagramserien och ställ in X‑formatet för felstaplar.
1. Åtkomst till den första diagramserien och ställ in Y‑formatet för felstaplar.
1. Åtkomst till de enskilda datapunkterna i diagramserien och ställ in felstaplarvärden för varje datapunkt i serien.
1. Ställ in staplarnas värden och format.
1. Spara den ändrade presentationen till en PPTX‑fil.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Skapar ett bubbeldiagram
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Lägger till anpassade felstaplar och ställer in deras format
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Åtkomst till diagramseriens datapunkt och ställer in felstaplarvärden för
    # individuell punkt
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Ställer in felstaplar för diagramseriens datapunkter
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Sparar presentationen
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Vad händer med felstaplar när en presentation exporteras till PDF eller bilder?**

De renderas som en del av diagrammet och bevaras under konverteringen tillsammans med resten av diagramformatet, förutsatt att en kompatibel version eller renderare används.

**Kan felstaplar kombineras med markörer och datatetiketter?**

Ja. Felstaplar är ett separat element och är kompatibla med markörer och datatetiketter; om element överlappar kan du behöva justera formateringen.

**Var kan jag hitta listan över egenskaper och klasser för att arbeta med felstaplar i API:t?**

I API‑referensen: klassen [ErrorBarsFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/errorbarsformat/) samt de relaterade klasserna [ErrorBarType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/errorbartype/) och [ErrorBarValueType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/errorbarvaluetype/).