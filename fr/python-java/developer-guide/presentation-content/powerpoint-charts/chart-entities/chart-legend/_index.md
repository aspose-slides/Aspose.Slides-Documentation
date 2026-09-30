---
title: Personnaliser les légendes de graphiques dans les présentations avec Python
linktitle: Légende de graphique
type: docs
url: /fr/python-java/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides pour Python via Java afin d'optimiser les présentations PowerPoint grâce à un formatage de légende adapté."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java propose des options pour personnaliser les légendes de graphiques dans les présentations PowerPoint. Cet article montre comment positionner et dimensionner une légende, définir la taille de police pour l’ensemble de la légende, formater une entrée de légende individuelle et masquer ou restaurer des entrées sélectionnées.

La FAQ couvre les comportements associés, y compris la réservation d’espace pour la légende, l’affichage d’étiquettes multilignes et l’héritage du formatage depuis le thème de la présentation.

## **Positionnement de la légende**

Utilisez les méthodes [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) et [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) de la légende pour spécifier sa position et sa taille en fractions des dimensions du graphique.

Cet exemple crée une présentation et ajoute un graphique à colonnes groupées avec des données par défaut à la première diapositive. Diviser les décalages et dimensions souhaités de la légende par la largeur et la hauteur du graphique les convertit en valeurs relatives : la légende est décalée de 50 points depuis le coin supérieur gauche du graphique et dimensionnée à 100 × 100 points.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Exprime la position et la taille de la légende par rapport au graphique.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la taille de police d’une légende**

Utilisez la méthode [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) de la légende pour accéder à son formatage de texte et utilisez [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) pour définir la taille de police en points.

Cet exemple crée un graphique avec des données par défaut et définit le texte de la légende à 20 points. Il désactive également les limites automatiques de l’axe vertical et fixe son intervalle de -5 à 10.

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

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la taille de police d’une entrée de légende individuelle**

Utilisez la collection renvoyée par la méthode [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) de la légende pour accéder au formatage d’une entrée spécifique. Les indices des entrées commencent à zéro, ainsi l’indice `1` correspond à la deuxième entrée.

Cet exemple crée un graphique à colonnes groupées dont les données par défaut comprennent au moins deux séries. Il formate la deuxième entrée de légende avec du texte bleu en gras, italique et de 20 points.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Masquer les entrées de légende individuelles**

Pour exclure une série auxiliaire de la légende tout en conservant ses données visibles, appelez [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) avec `True` via [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Cela masque uniquement l’entrée de légende sélectionnée ; cela ne supprime ni la série ni ses points de données. En revanche, appeler [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) avec `False` masque la légende entière.

L’exemple ci‑dessous crée un graphique à colonnes groupées avec plusieurs séries utilisant les données par défaut. Il masque l’entrée de légende de la deuxième série (indice `1`) et enregistre la présentation. Il restaure ensuite l’entrée en appelant [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) avec `False` et enregistre une seconde copie. Les colonnes restent visibles dans les deux fichiers.

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
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Restaurer la même entrée sans modifier les données du graphique.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La comparaison ci‑dessous montre le même graphique avec toutes les entrées visibles et avec la deuxième entrée masquée. Les colonnes de la deuxième série restent inchangées.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

Dans les graphiques à colonnes, barres et lignes, les entrées de légende identifient les séries. Pour les graphiques circulaires, elles identifient les points de données individuels (tranches), utilisez donc [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) sur la tranche sélectionnée. L’API documente cette méthode de point de données pour les types de graphiques `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` et `BarOfPie`. Ne supposez pas qu’elle s’applique aux graphiques en anneau, qui ne figurent pas dans cette liste.

## **FAQ**

**Puis‑je faire en sorte que le graphique réserve de l’espace pour la légende au lieu de la superposer ?**

Oui. Appelez [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) avec `False` pour réserver de l’espace à la légende au lieu de lui permettre de chevaucher la zone du tracé.

**Puis‑je créer des étiquettes de légende multilignes ?**

Oui. Les longues étiquettes peuvent se renvoyer à la ligne lorsque la largeur disponible est insuffisante. Vous pouvez également insérer des caractères de saut de ligne dans les noms de séries pour demander des retours à la ligne.

**Comment faire en sorte que la légende suive le jeu de couleurs du thème de la présentation ?**

Laissez les couleurs, remplissages et polices de la légende non définis afin qu’elle puisse hériter du formatage du thème. Un formatage explicite remplace les paramètres correspondants du thème.