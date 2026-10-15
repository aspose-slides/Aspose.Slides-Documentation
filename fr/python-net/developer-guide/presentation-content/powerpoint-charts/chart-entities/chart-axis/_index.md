---
title: Personnaliser les axes des graphiques dans les présentations avec Python
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
description: "Découvrez comment utiliser Aspose.Slides for Python via .NET pour personnaliser les axes des graphiques dans les présentations PowerPoint et OpenDocument pour les rapports et visualisations."
---
## **Vue d’ensemble**

Cet article explique comment personnaliser les axes des graphiques avec Aspose.Slides for Python via .NET. Il couvre les valeurs d’axe calculées, le basculement des lignes et colonnes du graphique, la visibilité des axes, les intervalles d’étiquettes de catégorie et de marques d’échelle, les catégories de dates et leur mise en forme, la rotation du titre, le positionnement des axes, les unités d’affichage et le redimensionnement logarithmique.

## **Obtenir les valeurs maximales sur l’axe vertical des graphiques**

Créez une [Présentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et ajoutez un graphique en aires avec des données par défaut. Appelez [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) avant de lire les valeurs d’axe calculées afin que la mise en forme du graphique soit à jour.

Lisez [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) et [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) pour les limites de l’axe, ainsi que [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) et [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) pour les intervalles de marques. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) et [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) fournissent les échelles d’unités temporelles, pertinentes pour les axes de dates. L’exemple stocke ces valeurs dans des variables locales et enregistre le graphique.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Échanger les données entre les axes**

Utilisez [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) pour inverser les rôles des séries et des catégories dans les données du graphique. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie le regroupement des données ; cela n’échange pas les axes horizontal et vertical. L’exemple utilise [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) pour lier les données par défaut à `Sheet1!A1:D5`, incluant la ligne d’en‑tête et la colonne des catégories, avant d’échanger les lignes et colonnes. Il enregistre un graphique avec quatre séries et trois catégories.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Inverser l’ordre de trame d’un axe**

Utilisez [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) pour inverser un axe de catégorie ou de valeur. Par exemple, un graphique à barres horizontal peut afficher les étapes d’un projet de haut en bas dans le même ordre que la feuille : Planification, Développement, Test. Inverser un axe change la direction de traçage ; cela ne trie pas et ne réarrange pas les données du classeur. En comparaison, [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) échange les rôles des séries et des catégories.

L’exemple suivant crée un graphique à barres horizontal avec trois étapes et une série. Il enregistre une présentation avec trois diapositives : ordre normal, catégories inversées et valeurs inversées. Chaque copie utilise le même jeu de données, et un seul axe est inversé dans chaque copie.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Diapositive 2 : afficher la première catégorie en haut.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Conserver l'axe de valeur horizontal en bas.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Diapositive 3 : inverser uniquement l’échelle numérique horizontale.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Inverser un axe peut également déplacer l’axe perpendiculaire du côté opposé du tracé. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) contrôle l’endroit où l’autre axe croise l’axe configuré. Dans la diapositive 2, le définir sur `MAXIMUM` sur l’axe de catégorie inversé maintient l’axe de valeur horizontal en bas. Pour un point de croisement spécifique, utilisez [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Vérifiez les réglages de croisement lors du changement de direction, surtout si le graphique possède déjà un point de croisement personnalisé. Réinitialisez `is_plot_order_reversed` à `False` pour restaurer la direction de traçage normale ; les réglages de croisement sont indépendants.

| Ordre normal (diapo 1) | Catégories inversées (diapo 2) | Valeurs inversées (diapo 3) |
| --- | --- | --- |
| ![Graphique à barres horizontal avec ordre normal des axes de catégorie et de valeur](axis-order-normal.png) | ![Graphique à barres horizontal avec les catégories affichées de haut en bas](axis-order-categories-reversed.png) | ![Graphique à barres horizontal avec un axe de valeur inversé et zéro à droite](axis-order-values-reversed.png) |
| Les catégories s’étendent de bas en haut ; les valeurs augmentent de gauche à droite. | Planification, Développement et Test s’étendent de haut en bas. Les valeurs et l’ordre des lignes du classeur restent inchangés. | Les catégories conservent leur ordre normal ; les valeurs augmentent de droite à gauche. L’axe de catégorie croise à zéro à droite. |

## **Désactiver l’axe vertical pour les graphiques en courbes**

Définissez [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) sur `False` pour l’axe vertical afin de le masquer. L’exemple crée un graphique en courbes avec des données par défaut et l’enregistre avec l’axe vertical masqué.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Désactiver l’axe horizontal pour les graphiques en courbes**

Définissez [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) sur `False` pour l’axe horizontal afin de le masquer. L’exemple crée un graphique en courbes avec des données par défaut et l’enregistre avec l’axe horizontal masqué.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifier un axe de catégorie**

Définissez [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) pour choisir un axe de catégorie de type date ou texte. Cet exemple nécessite `ExistingChart.pptx`, contenant un graphique comme première forme de la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il change l’axe horizontal en axe de date. En définissant [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) sur `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) sur `1` et [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) sur « months », les marques majeures sont placées à intervalles d’un mois.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Contrôler les intervalles des étiquettes d’axe de catégorie**

Lorsqu’un graphique possède de nombreuses catégories, réduisez le nombre d’étiquettes d’axe visibles sans supprimer les catégories ou les points de données. Définissez [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) sur `False`, puis définissez [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) sur l’intervalle de catégorie souhaité. Pour des catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Étiquettes affichées dans l’exemple |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Un intervalle de `3` affiche chaque troisième étiquette, les deux étiquettes intermédiaires restant masquées. Cela ne supprime pas les colonnes correspondantes. L’espacement automatique choisit un intervalle en fonction de l’espace disponible ; il n’affiche pas forcément chaque étiquette.

Les marques de graduation disposent de contrôles séparés. Définissez [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) sur `False` et utilisez [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) pour définir leur intervalle. Par exemple, `1` conserve une marque de graduation à chaque intervalle de catégorie tandis que les étiquettes n’apparaissent que toutes les trois catégories. Définissez [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) sur un style visible afin de voir le résultat. Réactiver l’une ou l’autre des propriétés d’espacement automatique à `True` laisse le graphique choisir à nouveau cet intervalle.

L’exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement manuel des étiquettes avec marques de graduation indépendantes, et restauration de l’espacement automatique. Les deux copies conservent les données d’origine du graphique. Aucune présentation d’entrée n’est requise. Le texte d’étiquette horizontal rend la différence de densité facile à voir.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Diapositive 2 : afficher chaque troisième étiquette, mais garder une marque de graduation pour chaque catégorie.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Diapositive 3 : laisser le graphique choisir à nouveau les deux intervalles.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Espacement automatique (diapo 1) :** Dans ce rendu, chaque deuxième étiquette de catégorie est affichée et passe à la ligne. Le résultat automatique peut varier selon la taille du graphique, les polices et le moteur de rendu.

![Espacement automatique des étiquettes de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapo 2) :** Chaque troisième étiquette est affichée sur une ligne, tandis que les marques de graduation restent à chaque intervalle de catégorie. Les 24 colonnes, y compris celles sans étiquette, restent visibles avec les mêmes valeurs. La diapo 3 restaure l’apparence automatique montrée ci‑dessus.

![Intervalle d’étiquettes de catégorie manuelles de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir le bon axe et intervalle**

Utilisez cet intervalle de comptage de catégories pour un axe de catégorie texte, tel que l’axe de catégorie d’un graphique à colonnes, lignes, aires ou barres. Dans un graphique à colonnes, il s’agit de l’axe horizontal. Dans un graphique à barres horizontal, l’axe de catégorie est vertical, appliquez donc ces réglages à [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). L’espacement des marques de graduation s’applique également à un axe de série dans les graphiques qui en possèdent un.

N’utilisez pas l’espacement des étiquettes de catégorie pour définir l’échelle numérique d’un axe de valeur. Sur un axe de valeur, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) indique une différence de valeurs : par exemple, une unité majeure de `10` produit des marques à 0, 10, 20, etc. lorsqu’un axe commence à zéro. Un intervalle d’étiquette de catégorie de `3` compte les positions de catégorie, indépendamment de leurs valeurs. Les graphiques en nuage de points et en bulles utilisent des axes de valeur plutôt qu’un axe de catégorie texte. Pour un axe de date, utilisez les unités majeures basées sur le temps et les échelles décrites dans [Modifier un axe de catégorie](#modifier-un-axe-de-catégorie).

## **Définir le format de date pour les valeurs d’axe de catégorie**

L’exemple remplace les données du graphique par défaut par quatre valeurs annuelles. Les dates sont stockées comme nombres de série OLE Automation dans la première feuille de calcul (index `0`). Définissez [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) sur un axe de date, désactivez [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), et attribuez `yyyy` à [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) afin que les étiquettes de catégorie affichent les années sur quatre chiffres indépendamment du format de la cellule.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir un angle de rotation pour le titre d’un axe de graphique**

Activez [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) sur l’axe vertical, fournissez le texte du titre et définissez [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) pour faire pivoter le titre. L’angle est mesuré en degrés ; cet exemple enregistre un graphique à colonnes avec son titre d’axe de valeur pivoté de 90 degrés.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la position de l’axe sur un axe de catégorie ou de valeur**

Utilisez [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) pour contrôler si l’axe de valeur croise l’axe de catégorie entre les catégories ou aux marques de catégorie. Cette propriété s’applique aux axes de catégorie. L’exemple la définit sur `True` pour l’axe de catégorie horizontal d’un graphique à colonnes et enregistre le résultat.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir l’unité d’affichage sur un axe de valeur du graphique**

Définissez [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) pour mettre à l’échelle les étiquettes d’un axe de valeur sans modifier les données sous‑jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) réglé sur `MILLIONS`, une valeur de 60 000 000 s’affiche comme 60. L’exemple crée un graphique à colonnes et applique l’unité d’affichage millions à son axe vertical.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Configurer un axe de valeur logarithmique**

Un axe de valeur logarithmique est utile lorsque des valeurs positives couvrent plusieurs ordres de grandeur. Par exemple, un service peut recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent proches les unes des autres près de zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Définissez [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) sur `True` pour l’axe de valeur et utilisez [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) pour choisir la base. Cela modifie la façon dont les valeurs existantes sont affichées ; cela ne modifie pas les données ni n’ajoute une courbe de tendance logarithmique. Une courbe de tendance représente une relation ajustée aux données et constitue une fonctionnalité distincte.

### **Choisir l’axe de valeur et la base**

Pour un graphique en lignes ou en colonnes, l’axe de valeur est [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Pour un graphique à barres horizontal, il s’agit de [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Les graphiques en nuage de points et en bulles possèdent deux axes de valeur, choisissez donc l’axe horizontal pour les valeurs X, l’axe vertical pour les valeurs Y, ou les deux. N’appliquez pas le redimensionnement logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les graphiques PPTX, utilisez une base comprise entre `2` et `1000` inclusive ; les bases fractionnaires comme `2.5` sont également prises en charge. Avec la base `10`, les puissances successives telles que 10, 100, 1 000 et 10 000 sont espacées de façon égale.

### **Comparer l’échelle linéaire et logarithmique**

L’exemple autonome suivant crée un graphique en lignes avec les cinq décomptes de requêtes sur la première diapositive, puis clone cette diapositive et active un axe de valeur logarithmique base 10 sur la seconde. Les deux diapositives conservent les mêmes données.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Conserver la première diapositive en linéaire et ne modifier que l'échelle de l'axe des valeurs de la copie.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Échelle linéaire (diapo 1) :** Des distances verticales égales représentent des différences égales dans les comptes de requêtes. La valeur la plus élevée domine le graphique, rendant les valeurs plus petites difficiles à distinguer.

![Graphique en lignes dans PowerPoint montrant cinq décomptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapo 2) :** Des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, de sorte que les points forment une ligne droite ascendante sur l’échelle base 10. Les étiquettes d’axe affichent toujours les comptes de requêtes d’origine.

![Les mêmes cinq décomptes de requêtes dans PowerPoint sur un axe de valeur logarithmique base 10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l’activer. Si les valeurs zéro ou négatives sont significatives, conservez une échelle linéaire ou affichez‑les séparément. Si leur exclusion est appropriée pour l’analyse, expliquez cette omission. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela altère le sens des données. Toute valeur minimale ou maximale configurée manuellement pour un axe logarithmique doit également être positive.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l’autre (croisement d’axe) ?**

Utilisez [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) pour sélectionner le comportement de croisement. Pour spécifier une valeur de croisement numérique, définissez [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Ces réglages vous permettent de déplacer le croisement de l’axe vers une ligne de base appropriée.

**Comment positionner les étiquettes de graduation par rapport à l’axe ?**

Définissez [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) à l’aide de [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) : `LOW`, `HIGH`, `NEXT_TO` ou `NONE`. Pour contrôler les marques de graduation elles‑mêmes, utilisez [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) ou [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) ; ils sont séparés du positionnement des étiquettes.