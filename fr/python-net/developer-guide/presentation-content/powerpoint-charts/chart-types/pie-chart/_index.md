---
title: Personnaliser les graphiques circulaires dans les présentations avec Python
linktitle: Graphique circulaire
type: docs
url: /fr/python-net/pie-chart/
keywords:
- graphique circulaire
- gérer le graphique
- personnaliser le graphique
- options du graphique
- paramètres du graphique
- options de tracé
- couleur de la tranche
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer et personnaliser des graphiques circulaires en Python avec Aspose.Slides, exportables vers PowerPoint et OpenDocument, pour dynamiser votre narration de données en quelques secondes."
---

## **Options de deuxième tracé pour les graphiques Pie of Pie et Bar of Pie**
Aspose.Slides for Python via .NET prend désormais en charge les options de deuxième tracé pour les graphiques Pie of Pie ou Bar of Pie. Dans ce sujet, nous verrons avec un exemple comment spécifier ces options à l’aide d’Aspose.Slides. Pour spécifier les propriétés, veuillez suivre les étapes ci‑dessous :

1. Instancier l’objet de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Ajouter un graphique à la diapositive.
1. Spécifier les options de deuxième tracé du graphique.
1. Enregistrer la présentation sur le disque.

Dans l’exemple ci‑dessous, nous avons défini différentes propriétés du graphique Pie of Pie.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:
    # Ajouter un graphique sur la diapositive
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Définir différentes propriétés
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Enregistrer la présentation sur le disque
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir les couleurs automatiques des tranches du graphique circulaire**
Aspose.Slides for Python via .NET fournit une API simple pour définir les couleurs automatiques des tranches d’un graphique circulaire. Le code d’exemple applique le paramétrage décrit ci‑dessus.

1. Créer une instance de la classe Presentation.
1. Accéder à la première diapositive.
1. Ajouter un graphique avec des données par défaut.
1. Définir le titre du graphique.
1. Configurer la première série pour afficher les valeurs.
1. Définir l’indice de la feuille de données du graphique.
1. Obtenir la feuille de données du graphique.
1. Supprimer les séries et catégories générées par défaut.
1. Ajouter de nouvelles catégories.
1. Ajouter de nouvelles séries.

Enregistrer la présentation modifiée dans un fichier PPTX.
```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation() as presentation:
	# Accéder à la première diapositive
	slide = presentation.slides[0]

	# Ajouter un graphique avec les données par défaut
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Définir le titre du graphique
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Définir la première série pour afficher les valeurs
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Définir l'index de la feuille de données du graphique
	defaultWorksheetIndex = 0

	# Obtenir la feuille de calcul des données du graphique
	fact = chart.chart_data.chart_data_workbook

	# Supprimer les séries et catégories générées par défaut
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Ajouter de nouvelles catégories
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Ajouter une nouvelle série
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Remplissage des données de la série
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Les variantes 'Pie of Pie' et 'Bar of Pie' sont‑elles prises en charge ?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types 'Pie of Pie' et 'Bar of Pie'.

**Puis‑je exporter uniquement le graphique sous forme d’image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui‑même en tant qu’image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (tel que PNG) sans toute la présentation.