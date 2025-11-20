---
title: Gérer les séries de graphiques en Python
linktitle: Séries de graphiques
type: docs
url: /fr/python-net/chart-series/
keywords:
- séries de graphiques
- chevauchement de séries
- couleur de série
- couleur de catégorie
- nom de série
- point de données
- écart de série
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques en Python pour PowerPoint (PPT/PPTX) grâce à des exemples de code pratiques et aux meilleures pratiques afin d’améliorer vos présentations de données."
---

## **Vue d'ensemble**

Cet article décrit le rôle de [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) dans Aspose.Slides pour Python, en se concentrant sur la façon dont les données sont structurées et visualisées dans les présentations. Ces objets fournissent les éléments fondamentaux qui définissent des ensembles individuels de points de données, de catégories et de paramètres d’apparence dans un graphique. En travaillant avec [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/), les développeurs peuvent intégrer de manière transparente les sources de données sous‑jacentes et garder un contrôle total sur la façon dont l’information est affichée, ce qui aboutit à des présentations dynamiques, axées sur les données, qui transmettent clairement les aperçus et l’analyse.

Une série est une ligne ou une colonne de nombres tracée dans un graphique.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement de série**

La propriété [ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) contrôle la façon dont les barres et les colonnes se chevauchent dans un graphique 2D en spécifiant une plage de –100 à 100. Cette propriété est associée au groupe de séries plutôt qu’à chaque série individuelle, elle est donc en lecture seule au niveau de la série. Pour configurer les valeurs de chevauchement, utilisez la propriété en lecture/écriture `parent_series_group.overlap`, qui applique le chevauchement spécifié à toutes les séries du groupe.

Voici un exemple Python qui montre comment créer une présentation, ajouter un graphique à colonnes groupées, accéder à la première série du graphique, configurer le paramètre de chevauchement, puis enregistrer le résultat au format PPTX :
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter un graphique à colonnes groupées avec des données par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # Définir le chevauchement de la série.
        series.parent_series_group.overlap = series_overlap

    # Enregistrer le fichier de présentation sur le disque.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![Le chevauchement des séries](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Aspose.Slides simplifie la personnalisation des couleurs de remplissage des séries de graphiques, vous permettant de mettre en évidence des points de données spécifiques et de créer des graphiques esthétiques. Cela se fait via l’objet [Format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/), qui prend en charge divers types de remplissage, configurations de couleur et options de style avancées. Après avoir ajouté un graphique à une diapositive et accédé à la série souhaitée, il suffit d’obtenir la série et d’appliquer la couleur de remplissage appropriée. Au‑delà des remplissages unis, vous pouvez également exploiter les remplissages dégradés ou à motif pour davantage de flexibilité de conception. Une fois les couleurs définies selon vos besoins, enregistrez la présentation pour finaliser le rendu mis à jour.

L’exemple de code Python suivant montre comment changer la couleur de la première série :
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter un graphique à colonnes groupées avec des données par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # Définir la couleur de la première série.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # Enregistrer le fichier de présentation sur le disque.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![La couleur de la série](series_color.png)

## **Renommer une série**

Aspose.Slides propose un moyen simple de modifier les noms des séries de graphiques, facilitant ainsi l’étiquetage clair et significatif des données. En accédant à la cellule de feuille de calcul correspondante dans les données du graphique, les développeurs peuvent personnaliser la présentation des données. Cette modification est particulièrement utile lorsque les noms de séries doivent être mis à jour ou clarifiés en fonction du contexte des données. Après avoir renommé la série, la présentation peut être enregistrée pour conserver les changements.

Voici un extrait de code Python illustrant ce processus en action.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter un graphique à colonnes groupées avec des données par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # Définir le nom de la première série.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # Enregistrer le fichier de présentation sur le disque.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```


L’exemple de code Python suivant montre une alternative pour changer le nom de la série :
```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter un graphique à colonnes groupées avec des données par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # Définir le nom de la première série.
    series.name.as_cells[0].value = series_name

    # Enregistrer le fichier de présentation sur le disque.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```


Le résultat :

![Le nom de la série](series_name.png)

## **Obtenir la couleur de remplissage automatique d'une série**

Aspose.Slides pour Python vous permet d’obtenir la couleur de remplissage automatique d’une série de graphiques dans une zone de tracé. Après avoir créé une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), vous pouvez obtenir une référence à la diapositive souhaitée par index, puis ajouter un graphique du type de votre choix (par exemple `ChartType.CLUSTERED_COLUMN`). En accédant aux séries du graphique, vous pouvez récupérer la couleur de remplissage automatique.

Le code Python ci‑dessous détaille ce processus.
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter un graphique à colonnes groupées avec des données par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # Obtenir la couleur de remplissage de la série.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```


Exemple de sortie :
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```


## **Définir les couleurs de remplissage inversées pour une série**

Lorsque votre série de données comporte à la fois des valeurs positives et négatives, appliquer la même couleur à chaque colonne ou barre peut rendre le graphique difficile à lire. Aspose.Slides pour Python vous permet d’attribuer une couleur de remplissage inversée — un remplissage séparé appliqué automatiquement aux points de données situés en dessous de zéro — de sorte que les valeurs négatives se démarquent immédiatement. Dans cette section, vous apprendrez à activer cette option, choisir une couleur appropriée et enregistrer la présentation mise à jour.

L’exemple de code suivant montre l’opération :
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Ajouter de nouvelles catégories.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # Ajouter une nouvelle série.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Remplir les données de la série.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # Définir les paramètres de couleur pour la série.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![La couleur de remplissage solide inversée](inverted_solid_fill_color.png)

Vous pouvez inverser la couleur de remplissage pour un seul point de données plutôt que pour l’ensemble de la série. Il suffit d’accéder au `ChartDataPoint` souhaité et de définir sa propriété `invert_if_negative` sur `True`.

L’exemple de code suivant montre comment faire :
```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```


## **Effacer les données pour des points de données spécifiques**

Parfois, un graphique contient des valeurs de test, des valeurs aberrantes ou des entrées obsolètes que vous devez supprimer sans reconstruire toute la série. Aspose.Slides pour Python vous permet de cibler n’importe quel point de données par index, d’en effacer le contenu et d’actualiser instantanément le tracé afin que les points restants se déplacent et que les axes se redimensionnent automatiquement.

L’exemple de code suivant montre l’opération :
```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la largeur d'écart de la série**

La largeur d’écart contrôle la quantité d’espace vide entre des colonnes ou des barres adjacentes — des écarts plus larges mettent en avant les catégories individuelles, tandis que des écarts plus étroits créent un rendu plus dense et compact. Grâce à Aspose.Slides pour Python, vous pouvez ajuster ce paramètre pour l’ensemble d’une série, obtenant ainsi exactement l’équilibre visuel requis pour votre présentation sans modifier les données sous‑jacentes.

L’exemple de code suivant montre comment définir la largeur d’écart pour une série :
```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# Créer une présentation vide.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Ajouter un graphique avec des données par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # Enregistrer la présentation sur le disque.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # Définir la valeur gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # Enregistrer la présentation sur le disque.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![La largeur d'écart](gap_width.png)

## **FAQ**

**Existe-t-il une limite au nombre de séries qu'un graphique unique peut contenir ?**

Aspose.Slides n’impose aucune limite fixe au nombre de séries que vous ajoutez. La contrainte pratique dépend de la lisibilité du graphique et de la mémoire disponible pour votre application.

**Que faire si les colonnes d'un groupe sont trop proches ou trop éloignées ?**

Ajustez le paramètre [gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/gap_width/) pour cette série (ou son groupe de séries parent). Augmenter la valeur élargit l’espace entre les colonnes, tandis que la diminuer les rapproche.