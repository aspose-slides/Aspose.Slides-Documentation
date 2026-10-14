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
- couleur de tranche
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créer et personnaliser des graphiques circulaires en Python avec Aspose.Slides. Configurer les tracés secondaires, afficher les libellés de données, et appliquer des couleurs automatiques aux tranches dans PowerPoint."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les graphiques circulaires dans Aspose.Slides. Il montre comment configurer les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie, et comment activer la coloration automatique des tranches pour un graphique circulaire standard.

Les exemples portent sur des tâches de personnalisation de graphiques telles que l’ajout d’un graphique à une diapositive, l’ajustement des séries et des paramètres d’étiquettes, le remplacement des données de graphique par défaut par des catégories et des valeurs personnalisées, et l’enregistrement de la présentation mise à jour.

## **Options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie**

Aspose.Slides for Python via .NET prend en charge les options de tracé secondaire pour les graphiques Pie of Pie et Bar of Pie. Ces options contrôlent la taille du tracé secondaire et la façon dont les points de données sont répartis entre les deux tracés.

L’exemple suivant crée un graphique Pie of Pie dans une nouvelle présentation et affiche les valeurs des points de données en tant qu’étiquettes. La propriété [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) définit la taille du tracé secondaire à 149% du tracé principal. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) sélectionne la répartition basée sur le pourcentage, et [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) définit le seuil à 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Afficher les valeurs et configurer le tracé secondaire.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Sélectionner des catégories pour le tracé secondaire**

Utilisez une répartition personnalisée lorsque vous souhaitez regrouper des catégories spécifiques dans le tracé secondaire, quel que soit leur pourcentage. Par exemple, un rapport de ventes peut afficher Online et Events ensemble afin que les lecteurs puissent comparer ces deux canaux, même s’ils représentent 35% et 10% des ventes totales.

Définissez [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) sur [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) et sélectionnez les points via [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). La méthode [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) de la collection accepte soit un indice basé sur zéro dans la série, soit un objet de point de données. Dans cet exemple, l’indice 1 sélectionne Online, et le point à l’indice 3 sélectionne Events. Partners est également ajouté temporairement, puis exclu à l’aide de [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Remplacer les données par défaut par les ventes par canal.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Sélectionner Online par son indice zéro et Events par son objet de point de données.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Exclure Partners de la sélection sans supprimer ses données source.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) et Events (10) apparaissent comme des tranches séparées dans le tracé secondaire. Dans le tracé principal, ils sont représentés par une tranche combinée d’une valeur de 45, aux côtés de Retail (40) et Partners (15). La suppression de Partners de la sélection personnalisée le conserve dans le tracé principal ; elle ne supprime pas la catégorie ni sa valeur des données sources du graphique.

L’image suivante montre la présentation enregistrée dans PowerPoint :

![Diagramme Pie of Pie avec Online et Events dans le tracé secondaire et leur valeur combinée de 45 dans le tracé principal](pie_of_pie_custom.png)

## **Définir les couleurs automatiques des tranches du graphique circulaire**

Aspose.Slides for Python via .NET peut attribuer automatiquement des couleurs différentes aux tranches d’un graphique circulaire. L’exemple suivant crée un graphique circulaire avec un titre centré et remplace les données par défaut par trois catégories trimestrielles et leurs valeurs. La propriété [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) affiche les valeurs 20, 50 et 30 en tant qu’étiquettes, tandis que [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) active une couleur distincte pour chaque tranche.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Ajouter un titre de graphique centré.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Remplacer les données par défaut en utilisant la première feuille de calcul.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Afficher les valeurs et attribuer des couleurs différentes aux tranches.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Les variantes Pie of Pie et Bar of Pie sont-elles prises en charge ?**

Oui, la bibliothèque [prend en charge](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) un tracé secondaire pour les graphiques circulaires, y compris les types Pie of Pie et Bar of Pie.

**Puis-je exporter uniquement le graphique en tant qu’image (par exemple, PNG) ?**

Oui, vous pouvez [exporter le graphique lui-même en tant qu’image](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (comme PNG) sans exporter l’ensemble de la présentation.