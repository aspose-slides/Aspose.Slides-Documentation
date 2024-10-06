---
title: Barre d'erreur
type: docs
url: /php-java/error-bar/
---

## **Ajouter une barre d'erreur**
Aspose.Slides pour PHP via Java fournit une API simple pour gérer les valeurs des barres d'erreur. Le code d'exemple s'applique lors de l'utilisation d'un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) de séries :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur X.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur Y.
1. Définir les valeurs et le format des barres.
1. Écrivez la présentation modifiée dans un fichier PPTX.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Création d'un graphique à bulles
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Ajout de barres d'erreur et définition de son format
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
    # Sauvegarde de la présentation
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter une valeur de barre d'erreur personnalisée**
Aspose.Slides pour PHP via Java fournit une API simple pour gérer les valeurs de barres d'erreur personnalisées. Le code d'exemple s'applique lorsque la propriété [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) de séries :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur X.
1. Accédez à la première série de graphiques et définissez le format de la barre d'erreur Y.
1. Accédez aux points de données individuels de la série de graphiques et définissez les valeurs de la barre d'erreur pour le point de données de série individuel.
1. Définir les valeurs et le format des barres.
1. Écrivez la présentation modifiée dans un fichier PPTX.

```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Création d'un graphique à bulles
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Ajout de barres d'erreur personnalisées et définition de son format
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Accéder aux points de données de la série de graphiques et définir les valeurs des barres d'erreur pour
    # chaque point individuel
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Définir des barres d'erreur pour les points de la série de graphiques
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Sauvegarde de la présentation
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```