---
title: Zone de Traçage du Graphique
type: docs
url: /python-net/chart-plot-area/
keywords: "Zone de Traçage du Graphique présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Obtenez la largeur, la hauteur de la zone de traçage du graphique. Définissez le mode de disposition. Présentation PowerPoint en Python"
---

## **Obtenez la Largeur, la Hauteur de la Zone de Traçage du Graphique**
Aspose.Slides pour Python via .NET fournit une API simple pour.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Accédez à la première diapositive.
1. Ajoutez un graphique avec des données par défaut.
1. Appelez la méthode IChart.ValidateChartLayout() avant d'obtenir les valeurs réelles.
1. Obtient la position X réelle (gauche) de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtient le haut réel de l'élément graphique par rapport au coin supérieur gauche du graphique.
1. Obtient la largeur réelle de l'élément graphique.
1. Obtient la hauteur réelle de l'élément graphique.

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
	
	# Enregistrez la présentation avec le graphique
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Définir le Mode de Disposition de la Zone de Traçage du Graphique**
Aspose.Slides pour Python via .NET fournit une API simple pour définir le mode de disposition de la zone de traçage du graphique. La propriété **LayoutTargetType** a été ajoutée aux classes **ChartPlotArea** et **IChartPlotArea**. Si la disposition de la zone de traçage est définie manuellement, cette propriété spécifie si la zone de traçage doit être disposée par son intérieur (sans inclure les axes et les étiquettes des axes) ou par son extérieur (en incluant les axes et les étiquettes des axes). Il existe deux valeurs possibles qui sont définies dans l'énumération **LayoutTargetType**.

- **LayoutTargetType.Inner** - précise que la taille de la zone de traçage doit déterminer la taille de la zone de traçage, sans inclure les marques de graduation et les étiquettes des axes.
- **LayoutTargetType.Outer** - précise que la taille de la zone de traçage doit déterminer la taille de la zone de traçage, les marques de graduation et les étiquettes des axes.

Le code d'exemple est donné ci-dessous.

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