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
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à ajouter et formater les étiquettes de données de graphique dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides for Python via .NET pour des diapositives plus attrayantes."
---

## **Vue d'ensemble**

Les étiquettes de données d’un graphique affichent des détails sur les séries de données du graphique ou sur les points de données individuels. Elles permettent aux lecteurs d’identifier rapidement les séries de données et rendent les graphiques plus faciles à comprendre. Dans Aspose.Slides for Python, vous pouvez activer, personnaliser et formater les étiquettes de données pour n’importe quel graphique — en choisissant ce qui doit être affiché (valeurs, pourcentages, noms de séries ou de catégories), où positionner les étiquettes et comment elles apparaissent (police, format numérique, séparateurs, lignes de repère, etc.). Cet article décrit les API essentielles et fournit des exemples pour ajouter des étiquettes claires et informatives à vos graphiques.

## **Définir la précision des étiquettes de données**

Les étiquettes de données d’un graphique affichent souvent des valeurs numériques qui nécessitent une précision cohérente. Cette section montre comment contrôler le nombre de décimales des étiquettes de données dans Aspose.Slides en appliquant un format numérique approprié.

L'exemple Python suivant montre comment définir la précision numérique des étiquettes de données du graphique :

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

Avec Aspose.Slides, vous pouvez afficher les pourcentages comme étiquettes de données sur les graphiques. L'exemple ci-dessous calcule la part de chaque point dans sa catégorie et formate l'étiquette pour afficher le pourcentage.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Créez une instance de la classe Presentation.
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

    # Enregistrez la présentation contenant le graphique.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Afficher le symbole % avec les étiquettes de données du graphique**

Cette section montre comment afficher les pourcentages dans les étiquettes de données d’un graphique et inclure le symbole % à l’aide d’Aspose.Slides. Vous apprendrez à activer les valeurs de pourcentage pour l’ensemble d’une série ou pour des points spécifiques (idéal pour les graphiques en secteurs, en anneau et empilés à 100 %) et à contrôler le format via les options d’étiquette ou un format numérique personnalisé.

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:

    # Obtenez une référence à la diapositive par indice.
    slide = presentation.slides[0]

    # Créez un graphique PercentsStackedColumn sur la diapositive.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Obtenez le classeur de données du graphique.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Ajoutez une nouvelle série.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Définissez la couleur de remplissage de la série.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Définissez les propriétés du format d’étiquette.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Ajoutez une nouvelle série.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Définissez le type de remplissage et la couleur.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Enregistrez la présentation.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la distance de l'étiquette à l'axe**

Cette section montre comment contrôler la distance entre les étiquettes de données et l’axe du graphique dans Aspose.Slides. Ajuster cet offset aide à éviter les chevauchements et améliore la lisibilité dans les visuels denses.

Le code Python suivant montre comment définir la distance de l’étiquette à l’axe des catégories lorsqu’on travaille avec un graphique basé sur des axes :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:
    # Obtenez une référence à la diapositive.
    slide = presentation.slides[0]

    # Créez un graphique à colonnes groupées sur la diapositive.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Définissez la distance de l’étiquette à l’axe des catégories (horizontal).
    chart.axes.horizontal_axis.label_offset = 500

    # Enregistrez la présentation.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajuster la position de l'étiquette**

Lorsque vous créez un graphique qui n’utilise pas d’axes, comme un graphique en secteurs, les étiquettes de données peuvent être trop proches du bord. Dans ce cas, ajustez la position de l’étiquette afin que les lignes de repère s’affichent clairement.

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

![Étiquette de position modifiée](changed_label_position.png)

## **FAQ**

**Comment éviter le chevauchement des étiquettes de données sur les graphiques denses ?**  
Combinez le placement automatique des étiquettes, les lignes de repère et une taille de police réduite ; si nécessaire, masquez certains champs (par exemple, la catégorie) ou n’affichez les étiquettes que pour les points extrêmes/ clés.

**Comment désactiver les étiquettes uniquement pour les valeurs zéro, négatives ou vides ?**  
Filtrez les points de données avant d’activer les étiquettes et désactivez l’affichage pour les valeurs égales à 0, les valeurs négatives ou les valeurs manquantes selon une règle définie.

**Comment garantir un style d’étiquette cohérent lors de l’exportation en PDF/images ?**  
Définissez explicitement les polices (famille, taille) et vérifiez que la police est disponible côté rendu afin d’éviter le recours à une police de substitution.