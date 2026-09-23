---
title: Gérer les étiquettes de données de graphique dans les présentations avec Python
linktitle: Étiquette de données
type: docs
url: /fr/python-net/chart-data-label/
keywords:
- graphique
- étiquette de données
- précision des données
- pourcentage
- distance d'étiquette
- position d'étiquette
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à ajouter et formater les étiquettes de données de graphique dans les présentations PowerPoint en utilisant Aspose.Slides pour Python via .NET afin de créer des diapositives plus attrayantes."
---
## **Introduction**

Les étiquettes de données affichent des informations sur les séries de graphiques et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des étiquettes, ajuster l'espacement des étiquettes de l'axe des catégories et positionner les étiquettes des graphiques circulaires.

## **Définir la précision des données dans les étiquettes de graphique**

Utilisez [number_format_of_values](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/number_format_of_values/) pour formater les valeurs des séries. Cet exemple crée un graphique en courbes avec des données par défaut, affiche son tableau de données et active les étiquettes de valeur pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous-jacentes.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Afficher le pourcentage comme étiquettes**

Pour un graphique à colonnes empilées, calculez chaque valeur comme un pourcentage du total de sa catégorie et attribuez le texte à [text_frame_for_overriding](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Cet exemple utilise les données de graphique par défaut et affiche les pourcentages avec deux décimales dans une police de 8 points. Les catégories dont le total est zéro sont ignorées afin d'éviter une division par zéro. Recalculez le texte d'étiquette personnalisé si les données du graphique changent.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir le signe de pourcentage avec les étiquettes de graphique**

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [number_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabelformat/number_format/) pour afficher les pourcentages. Réglez [is_number_format_linked_to_source](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) sur `False` pour appliquer le format d'étiquette indépendamment des cellules sources.

Cet exemple crée un graphique à colonnes empilées à 100 % avec des séries rouge et bleue sur quatre catégories. Chaque paire de valeurs s'additionne à 1. Le format d'étiquette `0.0%` affiche 0.30 comme 30.0 %, tandis que l'axe vertical utilise deux décimales. Les deux séries utilisent du texte d'étiquette blanc de 10 points.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Lire le texte réel des étiquettes de données**

Utilisez [get_actual_label_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) pour récupérer le texte produit par les paramètres d'une étiquette de donnée. Ceci est utile lors de l'extraction d'étiquettes pour des rapports, la recherche de contenu dans une présentation ou la validation de graphiques générés. Dans l'exemple ci‑dessous, le format d'étiquette par défaut [data label format](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabelformat/) combine chaque nom de catégorie, nom de série et valeur. Un point formate sa valeur comme un pourcentage, et un autre utilise du texte personnalisé provenant de [text_frame_for_overriding](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

Le nombre stocké dans un point de données reste `0.75`, même lorsque son étiquette indique `75%` avec les noms de catégorie et de série. Le texte personnalisé remplace le texte d'étiquette généré. [get_actual_label_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) renvoie la chaîne d'étiquette résultante dans les deux cas. Vérifiez [is_visible](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabel/is_visible/) séparément, comme illustré ci‑dessus, lorsque vous ne souhaitez extraire que les étiquettes visibles.

## **Définir la distance de l’étiquette par rapport à un axe**

Utilisez [label_offset](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/axis/label_offset/) pour contrôler la distance entre les étiquettes de l'axe des catégories et l'axe. La valeur est un pourcentage de la taille maximale de police des étiquettes d'axe. Cet exemple crée un graphique à colonnes groupées et fixe le décalage des étiquettes de l'axe horizontal à 500. Ce réglage affecte les étiquettes de l'axe des catégories plutôt que les étiquettes attachées aux points de données individuels.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajuster la position de l’étiquette**

Sur un graphique circulaire, ajustez les positions des étiquettes de données pour améliorer l'espacement et laisser de la place aux lignes de liaison.

Cet exemple affiche la valeur du premier point de données, place son étiquette à l'extérieur de la tranche et ajuste les décalages [x](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabel/x/) et [y](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabel/y/). Ces décalages sont relatifs à la largeur et à la hauteur du graphique, respectivement.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Graphique circulaire avec une position d’étiquette de données ajustée](pie-chart-adjusted-label.png)

## **FAQ**

**Comment puis‑je éviter que les étiquettes de données se chevauchent sur des graphiques denses ?**

Combinez le placement automatique des étiquettes, les lignes de liaison et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les valeurs extrêmes ou les points clés.

**Comment désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**

Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style d’étiquette cohérent lors de l’exportation en PDF/images ?**

Définissez explicitement la famille et la taille de la police et vérifiez que la police est disponible dans l’environnement de rendu afin d’éviter le recours à une police de secours.