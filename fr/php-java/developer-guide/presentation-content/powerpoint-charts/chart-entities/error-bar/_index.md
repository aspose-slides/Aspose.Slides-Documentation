---
title: Personnaliser les barres d'erreur dans les graphiques de présentation avec PHP
linktitle: Barre d'erreur
type: docs
url: /fr/php-java/error-bar/
keywords:
- barre d'erreur
- valeur personnalisée
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment ajouter et personnaliser les barres d'erreur dans les graphiques avec Aspose.Slides pour PHP via Java — optimisez les visuels de données dans les présentations PowerPoint."
---

## **Ajouter des barres d'erreur**
Aspose.Slides for PHP via Java propose une API simple pour gérer les valeurs des barres d'erreur. Le code d'exemple s'applique lors de l'utilisation d'un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur Y.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Créer un graphique à bulles
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Ajouter des barres d'erreur et définir leur format
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
    # Enregistrer la présentation
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Ajouter des valeurs de barres d'erreur personnalisées**
Aspose.Slides for PHP via Java propose une API simple pour gérer les valeurs de barres d'erreur personnalisées. Le code d'exemple s'applique lorsque la propriété [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d'un point de données spécifique dans la collection [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d'erreur Y.
1. Accédez aux points de données individuels de la série et définissez les valeurs de la barre d'erreur pour chaque point de données.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```php
  # Créer une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Créer un graphique à bulles
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Ajouter des barres d'erreur personnalisées et définir leur format
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Accéder au point de données de la série du graphique et définir les valeurs des barres d'erreur pour
    # point individuel
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Définir les barres d'erreur pour les points de la série du graphique
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Enregistrer la présentation
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Que se passe-t-il avec les barres d'erreur lors de l'exportation d'une présentation vers PDF ou images ?**

Elles sont rendues comme partie du graphique et conservées durant la conversion avec le reste du formatage du graphique, en supposant une version ou un moteur compatible.

**Les barres d'erreur peuvent-elles être combinées avec des repères et des étiquettes de données ?**

Oui. Les barres d'erreur sont un élément distinct et sont compatibles avec les repères et les étiquettes de données ; si les éléments se chevauchent, il peut être nécessaire d'ajuster le formatage.

**Où puis-je trouver la liste des propriétés et des classes pour travailler avec les barres d'erreur dans l'API ?**

Dans la référence de l'API : la classe [ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) et les classes associées [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) et [ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/).