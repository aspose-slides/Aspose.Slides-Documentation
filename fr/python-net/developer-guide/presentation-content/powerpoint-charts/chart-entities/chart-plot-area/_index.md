---
title: Personnaliser les zones de tracé des graphiques de présentation en Python
linktitle: Zone de tracé
type: docs
url: /fr/python-net/chart-plot-area/
keywords:
- graphique
- zone de tracé
- largeur de la zone de tracé
- hauteur de la zone de tracé
- taille de la zone de tracé
- mode de mise en page
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment personnaliser les zones de tracé des graphiques dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Améliorez facilement le rendu de vos diapositives."
---

## **Obtenir la largeur, la hauteur de la zone de tracé du graphique**
Aspose.Slides for Python via .NET fournit une API simple pour .

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Accédez à la première diapositive.
3. Ajoutez un graphique avec des données par défaut.
4. Appelez la méthode IChart.ValidateChartLayout() avant pour obtenir les valeurs réelles.
5. Obtient la position X réelle (gauche) de l'élément du graphique par rapport au coin supérieur gauche du graphique.
6. Obtient le haut réel de l'élément du graphique par rapport au coin supérieur gauche du graphique.
7. Obtient la largeur réelle de l'élément du graphique.
8. Obtient la hauteur réelle de l'élément du graphique.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Enregistrer la présentation avec le graphique
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir le mode de mise en page de la zone de tracé du graphique**
Aspose.Slides for Python via .NET fournit une API simple pour définir le mode de mise en page de la zone de tracé du graphique. La propriété **LayoutTargetType** a été ajoutée aux classes **ChartPlotArea** et **IChartPlotArea**. Si la mise en page de la zone de tracé est définie manuellement, cette propriété indique s'il faut mettre en page la zone de tracé par son intérieur (sans inclure les axes et les étiquettes d'axe) ou par son extérieur (en incluant les axes et les étiquettes d'axe). Il existe deux valeurs possibles qui sont définies dans l'énumération **LayoutTargetType**.

- **LayoutTargetType.Inner** - indique que la taille de la zone de tracé doit déterminer la taille de la zone de tracé, sans inclure les marques de graduation et les étiquettes d'axe.
- **LayoutTargetType.Outer** - indique que la taille de la zone de tracé doit déterminer la taille de la zone de tracé, les marques de graduation et les étiquettes d'axe.

Le code d'exemple est fourni ci-dessous.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Dans quelles unités sont retournés actual_x, actual_y, actual_width et actual_height ?**

En points ; 1 pouce = 72 points. Il s’agit des unités de coordonnées d’Aspose.Slides.

**En quoi la zone de tracé diffère-t-elle de la zone du graphique en termes de contenu ?**

La zone de tracé est la région de dessin des données (séries, quadrillages, lignes de tendance, etc.) ; la zone du graphique comprend les éléments environnants (titre, légende, etc.). Dans les graphiques 3D, la zone de tracé inclut également les murs/plancher et les axes.

**Comment les X, Y, Largeur et Hauteur de la zone de tracé sont-ils interprétés lorsqu la mise en page est manuelle ?**

Ce sont des fractions (0–1) de la taille globale du graphique ; dans ce mode, le positionnement automatique est désactivé et les fractions que vous définissez sont utilisées.

**Pourquoi la position de la zone de tracé a‑t‑elle changé après l’ajout ou le déplacement de la légende ?**

La légende se trouve dans la zone du graphique à l’extérieur de la zone de tracé, mais elle influence la mise en page et l’espace disponible, de sorte que la zone de tracé peut se déplacer lorsque le positionnement automatique est actif. (Ceci est le comportement standard des graphiques PowerPoint.)