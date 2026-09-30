---
title: Personnaliser les légendes de graphiques dans les présentations avec Python
linktitle: Légende du graphique
type: docs
url: /fr/python-net/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides for Python via .NET pour optimiser les présentations PowerPoint avec un formatage de légende adapté."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET offre des options pour personnaliser les légendes de graphiques dans les présentations PowerPoint. Cet article montre comment positionner et dimensionner une légende, définir la taille de police pour l’ensemble de la légende, formater une entrée de légende individuelle, et masquer ou restaurer des entrées sélectionnées.

La FAQ couvre les comportements associés, notamment la réservation d’espace pour la légende, l’affichage d’étiquettes multilignes et l’héritage du formatage à partir du thème de la présentation.

## **Positionnement de la légende**

Utilisez les propriétés [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/), et [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) de la légende pour spécifier sa position et sa taille en fractions des dimensions du graphique.

Cet exemple crée une présentation et ajoute un graphique à colonnes groupées avec des données par défaut à la première diapositive. Diviser les décalages et dimensions souhaités de la légende par la largeur et la hauteur du graphique les convertit en valeurs relatives : la légende est décalée de 50 points du coin supérieur gauche du graphique et dimensionnée à 100 × 100 points.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Exprimez la position et la taille de la légende par rapport au graphique.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la taille de police d’une légende**

Utilisez le [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) de la légende pour accéder à son formatage de texte et définir [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) en points.

Cet exemple crée un graphique avec des données par défaut et définit le texte de la légende à 20 points. Il désactive également les limites automatiques pour l’axe vertical et fixe sa plage de -5 à 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la taille de police d’une entrée de légende individuelle**

Utilisez la collection [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) de la légende pour accéder au formatage d’une entrée spécifique. Les indices des entrées commencent à zéro, ainsi l’indice `1` correspond à la deuxième entrée.

Cet exemple crée un graphique à colonnes groupées dont les données par défaut comprennent au moins deux séries. Il formate la deuxième entrée de légende avec du texte gras, italique et bleu de 20 points.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Masquer des entrées de légende individuelles**

Pour exclure une série auxiliaire de la légende tout en gardant ses données visibles, définissez [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) sur `True` via [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Cela masque uniquement l’entrée de légende sélectionnée ; cela ne supprime pas la série ni ses points de données. En revanche, définir [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) sur `False` masque la légende entière.

L’exemple ci‑dessous crée un graphique à colonnes groupées avec plusieurs séries en utilisant les données par défaut. Il masque l’entrée de légende de la deuxième série (indice `1`) et enregistre la présentation. Il restaure ensuite l’entrée en définissant [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) sur `False` et enregistre une seconde copie. Les colonnes restent visibles dans les deux fichiers.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Restaurez la même entrée sans modifier les données du graphique.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

La comparaison ci‑dessous montre le même graphique avec toutes les entrées visibles et avec la deuxième entrée masquée. Les colonnes de la deuxième série restent inchangées.

![Comparaison d’un graphique avec toutes les entrées de légende visibles et avec la Série 2 masquée de la légende ; toutes les colonnes restent visibles.](hide-legend-entry.png)

Dans les graphiques à colonnes, à barres et en courbes, les entrées de légende identifient les séries. Pour les graphiques circulaires, elles identifient les points de données individuels (tranches), utilisez donc [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) sur la tranche sélectionnée. L’API documente cette propriété de point de données pour les types de graphiques `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` et `BAR_OF_PIE`. Ne supposez pas qu’elle s’applique aux graphiques en anneau, qui ne figurent pas dans cette liste.

## **FAQ**

**Puis-je faire en sorte que le graphique réserve de l’espace pour la légende au lieu de la superposer ?**

Oui. Définissez [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) sur `False` pour réserver de l’espace à la légende au lieu de lui permettre de chevaucher la zone de tracé.

**Puis-je créer des étiquettes de légende multilignes ?**

Oui. Les longues étiquettes peuvent s’enrouler lorsque la largeur disponible est insuffisante. Vous pouvez également utiliser des caractères de nouvelle ligne dans les noms de séries pour demander des sauts de ligne.

**Comment faire en sorte que la légende suive le jeu de couleurs du thème de la présentation ?**

Laissez les couleurs, remplissages et polices de la légende non définis afin qu’elle puisse hériter du formatage du thème. Un formatage explicite remplace les paramètres correspondants du thème.