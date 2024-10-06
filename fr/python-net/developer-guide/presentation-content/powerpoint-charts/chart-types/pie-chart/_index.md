---
title: Diagramme en Secteurs
type: docs
url: /python-net/pie-chart/
keywords: "Diagramme en secteurs, options de tracé, couleurs des parts, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Options de tracé du diagramme en secteurs et couleurs des parts dans la présentation PowerPoint en Python"
---

## **Deuxième Options de Tracé pour Diagramme en Secteurs et Diagramme en Barres de Secteurs**
Aspose.Slides pour Python via .NET prend désormais en charge les options de tracé seconde pour le Diagramme en Secteurs de Secteurs ou le Diagramme en Barres de Secteurs. Dans ce sujet, nous verrons avec un exemple comment spécifier ces options en utilisant Aspose.Slides. Pour spécifier les propriétés, veuillez suivre les étapes ci-dessous :

1. Instancier l'objet de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ajouter un diagramme sur la diapositive.
1. Spécifier les options de tracé seconde du diagramme.
1. Écrire la présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini différentes propriétés du Diagramme en Secteurs de Secteurs.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:
    # Ajouter un diagramme sur la diapositive
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Définir différentes propriétés
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Écrire la présentation sur le disque
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir les Couleurs des Parts de Diagramme en Secteurs Automatiquement**
Aspose.Slides pour Python via .NET fournit une API simple pour définir automatiquement les couleurs des parts de diagramme en secteurs. Le code d'exemple applique le réglage des propriétés mentionnées ci-dessus.

1. Créer une instance de la classe Presentation.
1. Accéder à la première diapositive.
1. Ajouter un diagramme avec des données par défaut.
1. Définir le titre du diagramme.
1. Définir la première série pour Afficher les Valeurs.
1. Définir l'index de la feuille de données du diagramme.
1. Obtenir la feuille de données du diagramme.
1. Supprimer les séries et catégories générées par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter de nouvelles séries.

Écrire la présentation modifiée dans un fichier PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation() as presentation:
	# Accéder à la première diapositive
	slide = presentation.slides[0]

	# Ajouter un diagramme avec des données par défaut
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Définir le titre du diagramme
	chart.chart_title.add_text_frame_for_overriding("Titre Exemple")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Définir la première série pour Afficher les Valeurs
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Définir l'index de la feuille de données du diagramme
	defaultWorksheetIndex = 0

	# Obtenir la feuille de données du diagramme
	fact = chart.chart_data.chart_data_workbook

	# Supprimer les séries et catégories générées par défaut
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Ajouter de nouvelles catégories
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "Premier Trimestre"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "Deuxième Trimestre"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "Troisième Trimestre"))

	# Ajouter de nouvelles séries
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Série 1"), chart.type)

	# Maintenant, peupler les données de la série
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```