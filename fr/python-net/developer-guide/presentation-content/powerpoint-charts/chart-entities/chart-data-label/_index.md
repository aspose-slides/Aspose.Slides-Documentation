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
- distance de l'étiquette
- position de l'étiquette
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à ajouter et formater les étiquettes de données de graphique dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Python via .NET pour des diapositives plus engageantes."
---

## **Vue d'ensemble**

Les étiquettes de données sur un graphique affichent des détails sur les séries de données du graphique ou sur des points de données individuels. Elles permettent aux lecteurs d'identifier rapidement les séries de données et facilitent également la compréhension des graphiques. Dans Aspose.Slides pour Python, vous pouvez activer, personnaliser et formater les étiquettes de données pour n’importe quel graphique — en choisissant ce qui doit être affiché (valeurs, pourcentages, noms de séries ou de catégories), où positionner les étiquettes et à quoi elles doivent ressembler (police, format numérique, séparateurs, lignes de repère, etc.). Cet article présente les API essentielles et des exemples pour ajouter des étiquettes claires et informatives à vos graphiques.

## **Définir la précision des étiquettes de données**

Les étiquettes de données d’un graphique affichent souvent des valeurs numériques qui nécessitent une précision constante. Cette section montre comment contrôler le nombre de décimales des étiquettes de données dans Aspose.Slides en appliquant un format numérique approprié.

L’exemple Python suivant montre comment définir la précision numérique des étiquettes de données d’un graphique :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Afficher les pourcentages comme étiquettes**

Avec Aspose.Slides, vous pouvez afficher les pourcentages comme étiquettes de données sur les graphiques. L’exemple ci‑dessous calcule la part de chaque point dans sa catégorie et formate l’étiquette pour afficher le pourcentage.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Crée une instance de la classe Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Enregistre la présentation contenant le graphique.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Afficher le symbole % avec les étiquettes de données du graphique**

Cette section montre comment afficher les pourcentages dans les étiquettes de données du graphique et inclure le signe % à l’aide d’Aspose.Slides. Vous apprendrez à activer les valeurs en pourcentage pour l’ensemble d’une série ou pour des points spécifiques (idéal pour les graphiques circulaires, en anneau et empilés à 100 %) et à contrôler le formatage via les options d’étiquette ou un format numérique personnalisé.

L’exemple Python suivant montre comment ajouter le symbole % à une étiquette de données de graphique :

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Crée une instance de la classe Presentation.
with slides.Presentation() as presentation:

    # Récupère une référence à la diapositive par son indice.
    slide = presentation.slides[0]

    # Crée un graphique PercentsStackedColumn sur la diapositive.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Récupère le classeur de données du graphique.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Ajoute une nouvelle série.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Définit la couleur de remplissage de la série.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Définit les propriétés du format d’étiquette.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Ajoute une nouvelle série.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Définit le type et la couleur du remplissage.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Enregistre la présentation.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la distance de l’étiquette par rapport à l’axe**

Cette section montre comment contrôler la distance entre les étiquettes de données et l’axe du graphique dans Aspose.Slides. Ajuster cet écart permet d’éviter les chevauchements et d’améliorer la lisibilité dans des visuels denses.

Le code Python suivant montre comment régler la distance de l’étiquette par rapport à l’axe des catégories lorsqu’on travaille avec un graphique basé sur des axes :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Crée une instance de la classe Presentation.
with slides.Presentation() as presentation:
    # Récupère une référence à la diapositive.
    slide = presentation.slides[0]

    # Crée un graphique à colonnes groupées sur la diapositive.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Définit la distance de l’étiquette par rapport à l’axe des catégories (horizontal).
    chart.axes.horizontal_axis.label_offset = 500

    # Enregistre la présentation.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajuster la position de l’étiquette**

Lorsque vous créez un graphique qui n’utilise pas d’axes, comme un graphique circulaire, les étiquettes de données peuvent être trop proches du bord. Dans ce cas, ajustez la position de l’étiquette afin que les lignes de repère s’affichent clairement.

Le code Python suivant montre comment ajuster la position de l’étiquette sur un graphique circulaire :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Changed label position](changed_label_position.png)

## **FAQ**

**Comment empêcher les étiquettes de données de se chevaucher sur des graphiques denses ?**

Combinez le placement automatique des étiquettes, les lignes de repère et la réduction de la taille de la police ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les points extrêmes/clé.

**Comment désactiver les étiquettes uniquement pour les valeurs nulles, négatives ou vides ?**

Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style d’étiquette cohérent lors de l’exportation vers PDF/images ?**

Définissez explicitement les polices (famille, taille) et vérifiez que la police est disponible sur le côté rendu afin d’éviter les substitutions.