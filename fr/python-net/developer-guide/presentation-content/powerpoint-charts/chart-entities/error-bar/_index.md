---
title: Personnaliser les barres d'erreur dans les graphiques de présentation avec Python
linktitle: Barre d'erreur
type: docs
url: /fr/python-net/error-bar/
keywords:
- barre d'erreur
- valeur personnalisée
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment ajouter et personnaliser les barres d'erreur dans les graphiques avec Aspose.Slides for Python via .NET — optimisez la visualisation des données dans les présentations PowerPoint et OpenDocument."
---

## **Ajouter une barre d’erreur**
Aspose.Slides for Python via .NET fournit une API simple pour gérer les valeurs des barres d’erreur. Le code d’exemple s’applique lors de l’utilisation d’un type de valeur personnalisé. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d’un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d’erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d’erreur Y.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Création d'une présentation vide
with slides.Presentation() as presentation:
    # Création d'un graphique à bulles
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Ajout des barres d'erreur et définition de leur format
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Enregistrement de la présentation
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter une valeur de barre d’erreur personnalisée**
Aspose.Slides for Python via .NET fournit une API simple pour gérer les valeurs de barre d’erreur personnalisées. Le code d’exemple s’applique lorsque la propriété **IErrorBarsFormat.ValueType** est égale à **Custom**. Pour spécifier une valeur, utilisez la propriété **ErrorBarCustomValues** d’un point de données spécifique dans la collection **DataPoints** de la série :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ajoutez un graphique à bulles sur la diapositive souhaitée.
1. Accédez à la première série du graphique et définissez le format de la barre d’erreur X.
1. Accédez à la première série du graphique et définissez le format de la barre d’erreur Y.
1. Accédez aux points de données individuels de la série du graphique et définissez les valeurs de la barre d’erreur pour chaque point de données de la série.
1. Définissez les valeurs et le format des barres.
1. Enregistrez la présentation modifiée dans un fichier PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Création d'une présentation vide
with slides.Presentation() as presentation:
    # Création d'un graphique à bulles
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Ajout de barres d'erreur personnalisées et définition de leur format
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Accès au point de données de la série du graphique et définition des valeurs des barres d'erreur pour le point individuel
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Définition des barres d'erreur pour les points de la série du graphique
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Enregistrement de la présentation
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Que se passe-t-il avec les barres d’erreur lors de l’exportation d’une présentation vers PDF ou images ?**

Elles sont rendues comme partie du graphique et conservées lors de la conversion avec le reste du formatage du graphique, à condition d’utiliser une version ou un moteur compatible.

**Les barres d’erreur peuvent‑elles être combinées avec des repères et des étiquettes de données ?**

Oui. Les barres d’erreur sont un élément distinct et sont compatibles avec les repères et les étiquettes de données ; si les éléments se chevauchent, il peut être nécessaire d’ajuster le formatage.

**Où puis‑je trouver la liste des propriétés et des énumérations pour travailler avec les barres d’erreur dans l’API ?**

Dans la référence de l’API : la classe [ErrorBarsFormat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarsformat/) et les énumérations associées [ErrorBarType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbartype/) et [ErrorBarValueType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/errorbarvaluetype/).