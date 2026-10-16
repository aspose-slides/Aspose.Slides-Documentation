---
title: Gérer les étiquettes de données de graphiques dans les présentations avec Python
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
description: "Apprenez à ajouter et à formater les étiquettes de données de graphiques dans les présentations PowerPoint en utilisant Aspose.Slides pour Python via .NET pour des diapositives plus attrayantes."
---
## **Introduction**

Les etiquettes de données affichent des informations sur les séries de graphiques et les points de données individuels, aidant les lecteurs à identifier les valeurs et à comprendre le graphique. Cet article explique comment formater les valeurs, afficher les pourcentages, lire le texte des étiquettes, contrôler les étiquettes au-dela du maximum de l'axe, ajuster l'espacement des étiquettes de l'axe des categories et positionner les étiquettes d'un graphique en secteur.

## **Définir la précision des données dans les étiquettes de graphique**

Utilisez [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) pour formater les valeurs des séries. Cet exemple crée un graphique en ligne avec des données par défaut, affiche son tableau de données et active les étiquettes de valeur pour la première série. Le format `#,##0.00` affiche un séparateur de milliers et deux décimales sans modifier les valeurs sous-jacentes.

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

Pour un graphique à colonnes empilées, calculez chaque valeur comme pourcentage du total de sa catégorie et affectez le texte à [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). Cet exemple utilise les données de graphique par défaut et affiche les pourcentages avec deux décimales dans une police de 8 points. Les categories dont le total est zéro sont ignorées afin d'éviter une division par zéro. Recalculez le texte d'étiquette personnalisé si les données du graphique changent.

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

Lorsque les valeurs sont stockées sous forme de fractions, utilisez [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) pour afficher les pourcentages. Définissez [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) sur `False` pour appliquer le format d'étiquette indépendamment des cellules source.

Cet exemple crée un graphique à colonnes empilées à 100% avec des séries rouge et bleue sur quatre catégories. Chaque paire de valeurs s'additionne à 1. Le format d'étiquette `0.0%` affiche 0.30 comme 30.0%, tandis que l'axe vertical utilise deux décimales. Les deux séries utilisent un texte d'étiquette blanc de 10 points.

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

Utilisez [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) pour récupérer le texte généré par les paramètres d'une étiquette de données. Cela est utile lors de l'extraction d'étiquettes pour des rapports, la recherche de contenu dans une présentation ou la validation de graphiques générés. Dans l'exemple ci-dessous, le [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) par défaut combine le nom de chaque catégorie, le nom de la série et la valeur. Un point formate sa valeur en pourcentage, et un autre utilise un texte personnalisé provenant de [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/).

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

Le nombre stocké dans un point de données reste `0.75`, même si son etiquette affiche `75%` avec les noms de categorie et de serie. Le texte personnalisé remplace le texte d'etiquette genere. [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) renvoie la chaine d'etiquette resultante dans les deux cas. Verifiez [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) separement, comme indique ci-dessous, lorsque vous souhaitez extraire uniquement les etiquettes visibles.

## **Contrôler les étiquettes de données au-dela du maximum de l'axe**

Lorsque vous limitez manuellement la plage d'un axe, certains points de données peuvent dépasser son maximum. Utilisez [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) pour contrôler si leurs étiquettes de données sont affichées. Ce paramètre modifie la visibilité des étiquettes ; il ne modifie pas la plage de l'axe ni les valeurs sous-jacentes.

L'exemple ci-dessous crée un graphique à colonnes groupées 2D avec des valeurs de 60 et 120. Il définit [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) sur `False` et [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) à 100 sur l'axe vertical. La première diapositive autorise les étiquettes au-dela du maximum ; une copie de cette diapositive les désactive. Les deux diapositives sont enregistrées dans `DataLabelsOverMaximum.pptx`.

Activez les étiquettes de valeur avec [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Le paramètre au niveau du graphique n'active pas l'affichage des valeurs par lui-même ni ne remplace le paramètre d'affichage désactivé d'une étiquette individuelle. Cet exemple active les valeurs pour toute la série et utilise [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) pour placer les étiquettes à l'extrémité extérieure de chaque colonne.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Les images suivantes montrent les diapositives enregistrées rendues par Microsoft PowerPoint. Avec `True`, l'étiquette **120** est visible à la limite supérieure ; avec `False`, elle est cachée. L'étiquette **60** reste visible, le maximum de l'axe reste à **100**, et le deuxième point de données reste **120** dans les deux cas.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Type de graphique" %}}
Cet exemple utilise un graphique à colonnes 2D avec un axe de valeurs. Les graphiques sans axe de valeurs, comme les graphiques en secteur et en anneau, n'ont pas de maximum d'axe à limiter de cette façon.
{{% /alert %}}

## **Définir la distance de l'étiquette par rapport à un axe**

Utilisez [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) pour contrôler la distance entre les étiquettes de l'axe des categories et l'axe. La valeur est un pourcentage de la taille maximale de police des etiquettes d'axe. Cet exemple crée un graphique à colonnes groupées et définit le decalage des etiquettes de l'axe horizontal à 500. Ce paramètre affecte les étiquettes de l'axe des categories plutôt que les étiquettes attachees aux points de données individuels.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajuster la position de l'étiquette**

Sur un graphique en secteur, ajustez les positions des étiquettes de données pour améliorer l'espacement et laisser de la place aux lignes de repères.

Cet exemple affiche la valeur du premier point de données, place son etiquette à l'extérieur de la tranche et ajuste ses decales [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) et [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/). Ces decales sont relatifs à la largeur et à la hauteur du graphique, respectivement.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Formater les lignes de repère**

Lorsque les eti­quettes d'un graphique en secteur sont placees a l'exterieur de leurs tranches, les lignes de repere aident les lecteurs a associer chaque valeur a la bonne tranche. Une couleur contrastee et une ligne legerement plus epaisse peuvent faciliter la lecture, tandis que la transparence et un style pointille rend les lignes moins visibles.

Utilisez [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) pour formater les lignes de repere au niveau de la collection d'etiquettes de données de la serie. Les parametres dans `series.labels.leader_lines_format.line` s'appliquent à la collection, plutot qu'à une etiquette individuelle.

Cet exemple cree un graphique en secteur avec des donnees par defaut, affiche les valeurs a l'exterieur des tranches et active [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). Il eloigne deux etiquettes de leurs tranches en utilisant les decales [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) et [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/), exprimes en fractions de la largeur et de la hauteur du graphique. Aucune presentation d'entree n'est requise.

Le [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) de la ligne definit une couleur bleue unie avec une valeur alpha de 191 sur 255, ce qui donne environ 25% de transparence. [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) definit l'epaisseur a 2 points, et [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) rend la ligne en pointille.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # Déplacez deux étiquettes plus loin de leurs tranches.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

Activer les lignes de repere ne garantit pas qu'une ligne apparaisse pour chaque etiquette. La visibilite depend du placement des etiquettes et du comportement de mise en page du graphique. Dans cet exemple, les deux etiquettes deplacees ont des lignes de repere visibles ; les etiquettes proches de leurs tranches n'en ont pas besoin.

L'image suivante montre le fichier `FormattedLeaderLines.pptx` enregistre, rendu avec Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Ajouter plusieurs rangées d'étiquettes de données au-dessus d'un graphique à colonnes**

Cet exemple cree un graphique à colonnes avec deux rangées d'étiquettes de données au-dessus de la zone du trace. La serie A affiche les colonnes visibles, tandis que les series B et C fournissent les etiquettes supplementaires. Leurs colonnes sont cachees en supprimant le remplissage et le contour. La propriete [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) aligne les trois series sur les memes centres de categories.

Les parametres [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) reserve de l'espace pour les rangées d'etiquettes. Apres que [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) calcule les positions par defaut, [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) et [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) conservent l'alignement horizontal et appliquent des decales verticaux pour disposer les etiquettes en deux rangées. Les nombres restent des etiquettes de donnees liees aux valeurs des series ; seuls les en-tetes de rangee sont des formes de texte separees.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Masquez les colonnes de B et C, mais conservez leurs étiquettes de données.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Alignez les trois séries sur les mêmes centres de catégorie.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Utilisez moins de lignes de grille pour cet exemple compact.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Réservez de l'espace au-dessus du tracé pour deux rangées d'étiquettes de données.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Conservez la position horizontale par défaut. Y est un décalage depuis
            # la position d'étiquette par défaut, exprimé comme une fraction de la hauteur du graphique.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Seul le titre de ligne est une forme de texte distincte.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **FAQ**

**Comment puis‑je empêcher les étiquettes de données de se chevaucher sur des graphiques denses ?**

Combinez le placement automatique des étiquettes, les lignes de repère et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n'affichez les étiquettes que pour les valeurs extrêmes ou les points clés.

**Comment puis‑je désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**

Filtrez les points de données avant d'activer les étiquettes et désactivez l'affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment puis‑je garantir un style d'étiquette cohérent lors de l'exportation vers PDF/images ?**

Définissez explicitement la famille et la taille de police et vérifiez que la police est disponible dans l'environnement de rendu afin d'éviter le remplacement.