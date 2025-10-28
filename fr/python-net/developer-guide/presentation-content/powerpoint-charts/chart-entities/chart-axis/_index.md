---
title: Personnaliser les axes de graphique dans les présentations avec Python
linktitle: Axe du graphique
type: docs
url: /fr/python-net/chart-axis/
keywords:
- axe du graphique
- axe vertical
- axe horizontal
- personnaliser l'axe
- manipuler l'axe
- gérer l'axe
- propriétés de l'axe
- valeur maximale
- valeur minimale
- ligne d'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides for Python via .NET pour personnaliser les axes des graphiques dans les présentations PowerPoint et OpenDocument pour les rapports et les visualisations."
---


## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**
Aspose.Slides for Python via .NET vous permet d’obtenir les valeurs minimale et maximale sur un axe vertical. Suivez ces étapes :

1. Créer une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. Accéder à la première diapositive.
3. Ajouter un graphique avec des données par défaut.
4. Obtenir la valeur maximale réelle sur l'axe.
5. Obtenir la valeur minimale réelle sur l'axe.
6. Obtenir l'unité principale réelle de l'axe.
7. Obtenir l'unité mineure réelle de l'axe.
8. Obtenir l'échelle de l'unité principale réelle de l'axe.
9. Obtenir l'échelle de l'unité mineure réelle de l'axe.

Ce code d’exemple — une implémentation des étapes ci‑dessus — montre comment obtenir les valeurs requises en Python :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Enregistre la présentation
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Échanger les données entre les axes**
Aspose.Slides vous permet d’échanger rapidement les données entre les axes — les données représentées sur l'axe vertical (axe Y) sont déplacées vers l'axe horizontal (axe X) et inversement. 

Ce code Python montre comment procéder à l’échange des données entre les axes d’un graphique :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Crée une présentation vide
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    # Échange les lignes et les colonnes
    chart.chart_data.switch_row_column()
            
    # Enregistre la présentation
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Désactiver l'axe vertical pour les graphiques en courbes**

Ce code Python montre comment masquer l'axe vertical d'un graphique en courbes :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Désactiver l'axe horizontal pour les graphiques en courbes**

Ce code montre comment masquer l'axe horizontal d'un graphique en courbes :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifier l'axe des catégories**

En utilisant la propriété **CategoryAxisType**, vous pouvez spécifier le type d'axe des catégories souhaité (**date** ou **text**). Ce code Python illustre l'opération : 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir le format de date pour la valeur de l'axe des catégories**
Aspose.Slides for Python via .NET vous permet de définir le format de date pour une valeur d'axe des catégories. L'opération est démontrée dans ce code Python :

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir l'angle de rotation du titre de l'axe du graphique**
Aspose.Slides for Python via .NET vous permet de définir l'angle de rotation du titre d'un axe de graphique. Ce code Python montre l'opération :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la position de l'axe dans un axe de catégorie ou de valeur**
Aspose.Slides for Python via .NET vous permet de définir la position de l'axe dans un axe de catégorie ou de valeur. Ce code Python montre comment réaliser la tâche :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Activer le libellé d'unité d'affichage sur l'axe des valeurs du graphique**
Aspose.Slides for Python via .NET vous permet de configurer un graphique pour afficher un libellé d'unité sur son axe des valeurs. Ce code Python montre l'opération :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement des axes) ?**

Les axes offrent un [paramètre de croisement](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) : vous pouvez choisir de croiser à zéro, au maximum de la catégorie/valeur, ou à une valeur numérique spécifique. Cela est utile pour déplacer l'axe X vers le haut ou le bas ou pour mettre en évidence une ligne de base.

**Comment positionner les libellés des graduations par rapport à l'axe (à côté, à l'extérieur, à l'intérieur) ?**

Définissez la [position du libellé](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) sur « cross », « outside » ou « inside ». Cela affecte la lisibilité et aide à économiser de l'espace, notamment sur les petits graphiques.