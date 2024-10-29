---
title: Zone de Traçage du Graphique
type: docs
url: /fr/php-java/chart-plot-area/
---


## **Obtenir la Largeur, la Hauteur de la Zone de Traçage du Graphique**
Aspose.Slides pour PHP via Java fournit une API simple pour . 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Appelez la méthode [IChart.validateChartLayout()](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#validateChartLayout--) avant d'obtenir les valeurs réelles.
1. Obtient la position X réelle (gauche) de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtient le haut réel de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur réelle de l'élément graphique.
1. Obtient la hauteur réelle de l'élément graphique.

```php
  # Créez une instance de la classe Presentation
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

## **Définir le Mode de Mise en Page de la Zone de Traçage du Graphique**
Aspose.Slides pour PHP via Java fournit une API simple pour définir le mode de mise en page de la zone de traçage du graphique. Les méthodes [**setLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) et [**getLayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) ont été ajoutées à la classe [**ChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/ChartPlotArea) et à l'interface [**IChartPlotArea**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartPlotArea). Si la mise en page de la zone de traçage est définie manuellement, cette propriété spécifie si la zone de traçage doit être mise en page par son intérieur (sans inclure les axes et les étiquettes des axes) ou par son extérieur (y compris les axes et les étiquettes des axes). Il existe deux valeurs possibles définies dans l'énumération [**LayoutTargetType**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType::Inner**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Inner) - spécifie que la taille de la zone de traçage doit déterminer la taille de la zone de traçage, sans inclure les marques de graduation et les étiquettes des axes.
- [**LayoutTargetType::Outer**](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutTargetType#Outer) - spécifie que la taille de la zone de traçage doit déterminer la taille de la zone de traçage, les marques de graduation et les étiquettes des axes.

Un exemple de code est donné ci-dessous.

```php
  # Créez une instance de la classe Presentation
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