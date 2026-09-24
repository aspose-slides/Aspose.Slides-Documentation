---
title: Personnaliser les tableaux de données des graphiques dans les présentations à l'aide de Python
linktitle: Tableau de données
type: docs
url: /fr/python-java/chart-data-table/
keywords:
- données de graphique
- tableau de données
- propriétés de police
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Personnalisez les polices, les bordures et les repères de légende des tableaux de données de graphiques dans les présentations PowerPoint à l'aide d'Aspose.Slides for Python via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java vous permet d'afficher le tableau de données d'un graphique et de personnaliser le format du texte, les bordures et les repères de légende. Cet article explique comment activer le tableau, formater son texte, contrôler chaque type de bordure et afficher ou masquer les repères de légende. Les exemples enregistrent les graphiques configurés dans des fichiers PPTX.

## **Définir les propriétés de police**

Pour afficher le tableau de données d'un graphique, passez `True` à [setDataTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#setDataTable). Utilisez [getChartDataTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#getChartDataTable) pour accéder au tableau et configurer son format de texte.

1. Chargez la présentation en utilisant la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajoutez un graphique à colonnes groupées à la première diapositive.
1. Activez le tableau de données du graphique.
1. Activez le texte en gras avec [setFontBold](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setFontBold) et passez `20` à [setFontHeight](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseportionformat/#setFontHeight) pour un texte de 20 points.
1. Enregistrez la présentation modifiée.

L'exemple suivant nécessite `test.pptx` dans le répertoire de travail avec au moins une diapositive. Il ajoute un graphique avec des données par défaut à la position (50, 50), avec une largeur de 600 points et une hauteur de 400 points. Le `output.pptx` enregistré contient le graphique avec son tableau de données activé et les paramètres de police spécifiés appliqués.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Personnaliser les bordures du tableau de données**

Activez le tableau avec [Chart.setDataTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#setDataTable) et accédez-y via [Chart.getChartDataTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#getChartDataTable). Vous pouvez contrôler trois types de bordures indépendamment :

- [setBorderHorizontal](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datatable/#setBorderHorizontal) contrôle les bordures horizontales des cellules.
- [setBorderVertical](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datatable/#setBorderVertical) contrôle les bordures verticales des cellules.
- [setBorderOutline](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datatable/#setBorderOutline) contrôle la bordure extérieure du tableau.

Passez `True` à chaque méthode pour afficher ses bordures ou `False` pour les masquer. L'exemple suivant crée un graphique à colonnes groupées avec des données par défaut, affiche les bordures horizontales et la bordure extérieure, et masque les bordures verticales. Aucun fichier d'entrée n'est requis. La position et la taille du graphique sont spécifiées en points.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La comparaison ci‑dessous utilise les mêmes données de graphique et le même paramètre de repère de légende dans les quatre cas. En commençant avec toutes les bordures activées, chaque variante restante désactive un seul paramètre de bordure. La variante en bas à gauche correspond aux paramètres de bordure de l'exemple.

![Tableaux de données du graphique avec toutes les bordures activées, sans bordures horizontales, sans bordures verticales et sans bordure extérieure](data-table-borders.png)

## **Afficher ou masquer les repères de légende**

Les repères de légende sont de petits marqueurs colorés à côté des noms de séries dans le tableau de données. Ils aident les lecteurs à associer chaque ligne du tableau à une série du graphique. Passez `True` à [setShowLegendKey](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datatable/#setShowLegendKey) pour afficher ces marqueurs ou `False` pour les masquer.

La légende séparée du graphique est contrôlée par [Chart.setLegend](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#setLegend). Ces réglages sont indépendants : masquer la légende séparée ne masque pas les repères dans le tableau de données, et masquer les repères du tableau ne masque pas la légende séparée.

L'exemple suivant crée un graphique avec des données par défaut, active son tableau de données, et affiche les repères de légende à l'intérieur tout en masquant la légende séparée. Toutes les bordures du tableau sont explicitement activées. Aucun fichier de présentation d'entrée n'est requis. Pour masquer uniquement les repères du tableau, passez `False` à [setShowLegendKey](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La comparaison ci‑dessous montre le même tableau avec les repères de légende activés et désactivés. Toutes les bordures restent activées, et la légende séparée du graphique est masquée dans les deux cas.

![Tableaux de données du graphique avec les repères de légende affichés à gauche et masqués à droite](data-table-legend-keys.png)

## **FAQ**

**Puis-je afficher les repères de légende dans le tableau de données d'un graphique ?**

Oui. Passez `True` à [setShowLegendKey](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datatable/#setShowLegendKey) pour afficher les repères de légende ou `False` pour les masquer.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation vers PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique et son tableau de données affiché comme partie de la diapositive lors de l'exportation vers [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/fr/python-java/convert-powerpoint-to-html/), ou [images](/slides/fr/python-java/convert-powerpoint-to-png/).

**Puis-je travailler avec les tableaux de données dans des graphiques chargés depuis un modèle ?**

Oui. Pour un graphique chargé depuis une présentation ou un modèle existant, utilisez [hasDataTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#hasDataTable) et [setDataTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#setDataTable) pour vérifier ou modifier si son tableau de données est affiché.

**Comment puis-je trouver les graphiques dont le tableau de données est activé ?**

Parcourez les formes de chaque diapositive, identifiez les graphiques, et appelez leur méthode [hasDataTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#hasDataTable). Une valeur `True` indique que le tableau de données est activé.