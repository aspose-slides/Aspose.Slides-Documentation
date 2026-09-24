---
title: Personnaliser les tables de données des graphiques dans les présentations en Python
linktitle: Table de données
type: docs
url: /fr/python-net/chart-data-table/
keywords:
- données du graphique
- table de données
- propriétés de police
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Personnalisez les polices, les bordures et les clés de légende des tables de données des graphiques dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET vous permet d'afficher le tableau de données d'un graphique et de personnaliser le format du texte, les bordures et les clés de légende. Cet article explique comment activer le tableau, formater son texte, contrôler chaque type de bordure et afficher ou masquer les clés de légende. Les exemples enregistrent les graphiques configurés dans des fichiers PPTX.

## **Définir les propriétés de police**

Pour afficher le tableau de données d'un graphique, définissez [has_data_table](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/has_data_table/) sur `True`. Utilisez [chart_data_table](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/chart_data_table/) pour accéder au tableau et configurer le format du texte.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
1. Ajoutez un graphique à colonnes groupées à la première diapositive.
1. Activez le tableau de données du graphique.
1. Activez le texte en gras avec [font_bold](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/font_bold/) et définissez [font_height](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseportionformat/font_height/) sur `20` pour un texte de 20 points.
1. Enregistrez la présentation modifiée.

L'exemple suivant nécessite `test.pptx` dans le répertoire de travail contenant au moins une diapositive. Il ajoute un graphique avec des données par défaut à la position (50, 50), avec une largeur de 600 points et une hauteur de 400 points. Le fichier `output.pptx` enregistré contient le graphique avec son tableau de données activé et les paramètres de police spécifiés appliqués.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Personnaliser les bordures du tableau de données**

Activez le tableau avec [Chart.has_data_table](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/has_data_table/) et accédez-y via [Chart.chart_data_table](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/chart_data_table/). Vous pouvez contrôler trois types de bordures indépendamment :

- [has_border_horizontal](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datatable/has_border_horizontal/) contrôle les bordures horizontales des cellules.
- [has_border_vertical](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datatable/has_border_vertical/) contrôle les bordures verticales des cellules.
- [has_border_outline](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datatable/has_border_outline/) contrôle la bordure extérieure du tableau.

Définissez chaque propriété sur `True` pour afficher ses bordures ou sur `False` pour les masquer. L'exemple suivant crée un graphique à colonnes groupées avec des données par défaut, affiche les bordures horizontales et la bordure extérieure, et masque les bordures verticales. Aucun fichier d'entrée n'est requis. La position et la taille du graphique sont spécifiées en points.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

La comparaison ci‑dessus utilise les mêmes données de graphique et le même paramètre de clé de légende dans les quatre cas. En partant de toutes les bordures activées, chaque variante restante désactive une seule propriété de bordure. La variante en bas à gauche correspond aux paramètres de bordure de l'exemple.

![Tableaux de données du graphique avec toutes les bordures activées, sans bordures horizontales, sans bordures verticales et sans bordure extérieure](data-table-borders.png)

## **Afficher ou masquer les clés de légende**

Les clés de légende sont de petits indicateurs colorés à côté des noms de séries dans le tableau de données. Elles aident les lecteurs à associer chaque ligne du tableau à une série du graphique. Définissez [show_legend_key](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datatable/show_legend_key/) sur `True` pour afficher ces indicateurs ou sur `False` pour les masquer.

La légende distincte du graphique est contrôlée par [Chart.has_legend](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/has_legend/). Ces paramètres sont indépendants : masquer la légende distincte ne masque pas les clés à l'intérieur du tableau de données, et masquer les clés du tableau ne masque pas la légende distincte.

L'exemple suivant crée un graphique avec des données par défaut, active son tableau de données et affiche les clés de légende à l'intérieur tout en masquant la légende distincte. Toutes les bordures du tableau sont explicitement activées. Aucun fichier de présentation d'entrée n'est requis. Pour masquer uniquement les clés du tableau, changez `data_table.show_legend_key` en `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

La comparaison ci‑dessus montre le même tableau avec les clés de légende activées et désactivées. Toutes les bordures restent activées, et la légende distincte du graphique est masquée dans les deux cas.

![Tableaux de données du graphique avec les clés de légende affichées à gauche et masquées à droite](data-table-legend-keys.png)

## **FAQ**

**Puis-je afficher les clés de légende dans le tableau de données d'un graphique ?**

Oui. Définissez [show_legend_key](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datatable/show_legend_key/) sur `True` pour afficher les clés de légende ou sur `False` pour les masquer.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation vers PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique et son tableau de données affiché comme partie de la diapositive lors de l'exportation vers [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/fr/python-net/convert-powerpoint-to-html/), ou [images](/slides/fr/python-net/convert-powerpoint-to-png/).

**Puis-je travailler avec les tableaux de données dans des graphiques chargés à partir d'un modèle ?**

Oui. Pour un graphique chargé à partir d'une présentation ou d'un modèle existant, utilisez [has_data_table](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/has_data_table/) pour vérifier ou modifier si son tableau de données est affiché.

**Comment puis‑je trouver les graphiques qui ont un tableau de données activé ?**

Parcourez les formes de chaque diapositive, identifiez les graphiques et vérifiez leur propriété [has_data_table](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/has_data_table/). Une valeur de `True` indique que le tableau de données est activé.