---
title: "Personnaliser les barres d’erreur dans les graphiques de présentation avec Python"
linktitle: "Barre d’erreur"
type: docs
url: /fr/python-java/error-bar/
keywords:
- barre d'erreur
- valeur personnalisée
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez comment ajouter et personnaliser les barres d’erreur dans les graphiques avec Aspose.Slides pour Python via Java — optimisez les visualisations de données dans les présentations PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les barres d’erreur dans les graphiques de présentation en utilisant Aspose.Slides. Il montre comment ajouter des barres d’erreur à une série de graphique, configurer les paramètres des barres d’erreur X et Y, et appliquer différents types de valeurs tels que fixe, pourcentage et valeurs personnalisées.

Il montre également comment attribuer des valeurs de barres d’erreur personnalisées pour des points de données individuels dans une série en utilisant la collection de points de données correspondante. De plus, l’article comprend de brèves notes sur le comportement des barres d’erreur lors de l’exportation, leur compatibilité avec les marqueurs et les étiquettes de données, ainsi que l’emplacement des classes et énumérations de référence API associées.

## **Ajouter des barres d’erreur**

Aspose.Slides for Python via Java fournit une API simple pour gérer les valeurs des barres d’erreur. Le code d’exemple suivant utilise des types de valeurs fixes et en pourcentage.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajouter un diagramme à bulles à la diapositive souhaitée.
1. Accéder à la première série de graphique et définir le format de la barre d’erreur X.
1. Accéder à la première série de graphique et définir le format de la barre d’erreur Y.
1. Définir les valeurs et le formatage des barres d’erreur.
1. Enregistrer la présentation modifiée dans un fichier PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Créer une instance de la classe Presentation.
presentation = Presentation()
try:
    # Créer un diagramme à bulles.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Ajouter des barres d'erreur et définir leur formatage.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Enregistrer la présentation.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajouter des valeurs de barres d’erreur personnalisées**

Aspose.Slides for Python via Java fournit une API simple pour gérer les valeurs personnalisées des barres d’erreur. Le code d’exemple suivant s’applique lorsque [getValueType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/errorbarsformat/#getValueType) renvoie [ErrorBarValueType.Custom](https://reference.aspose.com/slides/fr/python-java/aspose.slides/errorbarvaluetype/#Custom). Pour spécifier une valeur, utilisez [getErrorBarsCustomValues](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) pour un point de données spécifique dans la collection renvoyée par la méthode de série [getDataPoints](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getDataPoints).

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajouter un diagramme à bulles à la diapositive souhaitée.
1. Accéder à la première série de graphique et définir le format de la barre d’erreur X.
1. Accéder à la première série de graphique et définir le format de la barre d’erreur Y.
1. Accéder aux points de données individuels dans la série de graphique et définir leurs valeurs de barres d’erreur.
1. Définir les valeurs et le formatage des barres d’erreur.
1. Enregistrer la présentation modifiée dans un fichier PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Créer une instance de la classe Presentation.
presentation = Presentation()
try:
    # Créer un diagramme à bulles.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Ajouter des barres d'erreur personnalisées et définir leur formatage.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Accéder aux points de données de la série du graphique et configurer leurs sources de valeurs de barres d'erreur.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Définir les valeurs des barres d'erreur pour les points de données de la série du graphique.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Enregistrer la présentation.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Que se passe-t-il avec les barres d’erreur lors de l’exportation d’une présentation au format PDF ou en images ?**

Elles sont rendues comme faisant partie du graphique et conservées lors de la conversion avec le reste du formatage du graphique, en supposant une version ou un rendu compatible.

**Les barres d’erreur peuvent-elles être combinées avec des marqueurs et des étiquettes de données ?**

Oui. Les barres d’erreur sont un élément distinct et sont compatibles avec les marqueurs et les étiquettes de données ; si les éléments se chevauchent, il peut être nécessaire d’ajuster le formatage.

**Où puis-je trouver la liste des propriétés et des classes pour travailler avec les barres d’erreur dans l’API ?**

Dans la référence API : la classe [ErrorBarsFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/errorbarsformat/) et les classes associées [ErrorBarType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/errorbartype/) et [ErrorBarValueType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/errorbarvaluetype/).