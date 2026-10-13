---
title: Personnaliser les axes de graphique dans les présentations avec Python
linktitle: Axe de graphique
type: docs
url: /fr/python-net/chart-axis/
keywords:
- axe de graphique
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
description: "Découvrez comment utiliser Aspose.Slides pour Python via .NET afin de personnaliser les axes de graphique dans les présentations PowerPoint et OpenDocument pour les rapports et les visualisations."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les axes de graphiques avec Aspose.Slides pour Python via .NET. Il couvre les valeurs d'axe calculées, l'échange des lignes et colonnes du graphique, la visibilité des axes, les intervalles des étiquettes de catégorie et des repères, les catégories de dates et leur formatage, la rotation du titre, le positionnement des axes, les unités d'affichage et le redimensionnement logarithmique.

## **Obtenir les valeurs maximales sur l'axe vertical des graphiques**

Créez une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et ajoutez un graphique en aires avec des données par défaut. Appelez [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) avant de lire les valeurs d'axe calculées afin que la mise en page du graphique soit à jour.

Lisez [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) et [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) pour les limites de l'axe, ainsi que [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) et [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) pour les intervalles des repères. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) et [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) fournissent les échelles d'unités de temps, pertinentes pour les axes de dates. L'exemple stocke ces valeurs dans des variables locales et enregistre le graphique.

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

Utilisez [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) pour échanger les rôles des séries et des catégories dans les données du graphique. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie la façon dont les données sont regroupées ; cela n'échange pas les axes horizontal et vertical. L'exemple utilise [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) pour lier les données par défaut à `Sheet1!A1:D5`, y compris la ligne d'en-tête et la colonne des catégories, avant d'échanger les lignes et les colonnes. Il enregistre un graphique avec quatre séries et trois catégories.

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

## **Désactiver l'axe vertical pour les graphiques en lignes**

Définissez [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) à `False` sur l'axe vertical pour le masquer. L'exemple crée un graphique en lignes avec des données par défaut et l'enregistre avec l'axe vertical masqué.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Désactiver l'axe horizontal pour les graphiques en lignes**

Définissez [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) à `False` sur l'axe horizontal pour le masquer. L'exemple crée un graphique en lignes avec des données par défaut et l'enregistre avec l'axe horizontal masqué.

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

Définissez [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) pour choisir un axe de catégorie date ou texte. Cet exemple nécessite `ExistingChart.pptx`, avec un graphique comme première forme sur la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il change l'axe horizontal en axe de date. Mettre [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) à `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) à `1`, et [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) à months place des repères majeurs à des intervalles d'un mois.

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

## **Contrôler les intervalles d'étiquettes d'axe de catégorie**

Lorsqu'un graphique comporte de nombreuses catégories, réduisez le nombre d'étiquettes d'axe visibles sans supprimer les catégories ou les points de données. Définissez [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) à `False`, puis définissez [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) à l'intervalle de catégorie souhaité. Pour les catégories de texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Étiquettes affichées dans l'exemple |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

Un intervalle de `3` affiche chaque troisième étiquette, laissant deux étiquettes cachées entre les étiquettes affichées. Cela ne supprime pas les colonnes correspondantes. L'espacement automatique choisit un intervalle en fonction de l'espace disponible ; il n'affiche pas nécessairement chaque étiquette.

Les repères ont des contrôles séparés. Définissez [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) à `False` et utilisez [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) pour définir leur intervalle. Par exemple, `1` maintient un repère à chaque intervalle de catégorie tandis que les étiquettes n'apparaissent que toutes les trois catégories. Définissez [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) sur un style visible afin de voir le résultat. Remettre l'une ou l'autre propriété d'espacement automatique à `True` laisse le graphique choisir à nouveau cet intervalle.

L'exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement d'étiquette manuel avec repères indépendants, et rétablissement de l'espacement automatique. Les deux copies conservent les données du graphique d'origine. Aucune présentation d'entrée n'est requise. Le texte des étiquettes horizontales rend la différence de densité facile à voir.

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

    # Diapositive 2: afficher chaque troisième étiquette, mais conserver un repère pour chaque catégorie.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Diapositive 3: laisser le graphique choisir à nouveau les deux intervalles.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Espacement automatique (diapositive 1) :** Dans ce rendu, chaque deuxième étiquette de catégorie est affichée et passe à la ligne. Le résultat automatique peut varier selon la taille du graphique, les polices et le moteur de rendu.

![Espacement automatique des étiquettes de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** Chaque troisième étiquette est affichée sur une ligne, tandis que les repères restent à chaque intervalle de catégorie. Les 24 colonnes, y compris celles sans étiquette, restent visibles avec les mêmes valeurs. La diapositive 3 rétablit l'apparence automatique montrée ci‑dessus.

![Intervalle manuel des étiquettes de catégorie de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir le bon axe et intervalle**

Utilisez cet intervalle de comptage de catégorie pour un axe de catégorie texte, tel que l'axe de catégorie d'un graphique à colonnes, en lignes, en aires ou à barres. Dans un graphique à colonnes, il s'agit de l'axe horizontal. Dans un graphique à barres horizontal, l'axe de catégorie est vertical, donc appliquez ces paramètres à [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). L'espacement des repères s'applique également à un axe de série dans les graphiques qui en possèdent un.

Ne pas utiliser l'espacement des étiquettes de catégorie pour définir l'échelle numérique d'un axe de valeur. Sur un axe de valeur, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) spécifie une différence de valeurs : par exemple, une unité majeure de `10` produit des repères à 0, 10, 20, etc. lorsque l'axe commence à zéro. Un intervalle d'étiquette de catégorie de `3` compte plutôt les positions de catégorie, indépendamment de leurs valeurs de données. Les graphiques de dispersion et à bulles utilisent des axes de valeur plutôt qu'un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures basées sur le temps et des échelles comme décrit dans [Modifier un axe de catégorie](#modifier-un-axe-de-catégorie).

## **Définir le format de date pour les valeurs d'axe de catégorie**

L'exemple remplace les données de graphique par défaut par quatre valeurs annuelles. Les dates sont stockées sous forme de nombres de série OLE Automation dans la première feuille de calcul (index `0`). Définissez [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) sur un axe de date, désactivez [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), et attribuez `yyyy` à [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) afin que les étiquettes de catégorie affichent les années à quatre chiffres indépendamment du format de cellule.

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

## **Définir un angle de rotation pour le titre d'un axe de graphique**

Activez [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) sur l'axe vertical, fournissez le texte du titre, et définissez [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) pour faire pivoter le titre. L'angle est mesuré en degrés ; cet exemple enregistre un graphique à colonnes avec son titre d'axe de valeur pivoté de 90 degrés.

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

## **Définir la position de l'axe sur un axe de catégorie ou de valeur**

Utilisez [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) pour contrôler si l'axe de valeur coupe l'axe de catégorie entre les catégories ou aux repères de catégorie. Cette propriété s'applique aux axes de catégorie. L'exemple la définit à `True` sur l'axe de catégorie horizontal d'un graphique à colonnes et enregistre le résultat.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir l'unité d'affichage sur un axe de valeur de graphique**

Définissez [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) pour mettre à l'échelle les étiquettes d'un axe de valeur sans modifier les données sous‑jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) réglé sur `MILLIONS`, une valeur de 60 000 000 s'affiche comme 60. L'exemple crée un graphique à colonnes et applique l'unité d'affichage millions à son axe vertical.

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

Un axe de valeur logarithmique est utile lorsque des valeurs positives couvrent plusieurs ordres de grandeur. Par exemple, un service pourrait recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent très proches du zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Définissez [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) à `True` sur l'axe de valeur et utilisez [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) pour choisir la base. Cela modifie la façon dont les valeurs existantes sont affichées ; cela ne change pas les données ni n'ajoute une courbe de tendance logarithmique. Une courbe de tendance représente une relation ajustée aux données et constitue une fonctionnalité distincte.

### **Choisir l'axe de valeur et la base**

Pour un graphique en lignes ou à colonnes, l'axe de valeur est [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Pour un graphique à barres horizontal, il s'agit de [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Les graphiques de dispersion et à bulles ont deux axes de valeur, donc choisissez l'axe horizontal pour les valeurs X, l'axe vertical pour les valeurs Y, ou les deux. N'appliquez pas de mise à l'échelle logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les graphiques PPTX, utilisez une base comprise entre `2` et `1000`, inclusive ; les bases fractionnaires comme `2.5` sont également prises en charge. Avec une base de `10`, les puissances successives telles que 10, 100, 1 000 et 10 000 sont espacées de façon égale.

### **Comparer le redimensionnement linéaire et logarithmique**

L'exemple autonome suivant crée un graphique en lignes avec les cinq comptages de requêtes sur la première diapositive, puis duplique cette diapositive et active un axe de valeur logarithmique base‑10 sur la deuxième. Les deux diapositives conservent les mêmes données.

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

    # Conserver la première diapositive linéaire et ne modifier que l'échelle de l'axe de valeur de la copie.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Échelle linéaire (diapositive 1) :** Des distances verticales égales représentent des différences égales dans les comptages de requêtes. La valeur la plus élevée domine le graphique, rendant les valeurs plus petites difficiles à distinguer.

![Graphique en lignes PowerPoint montrant cinq comptages de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2) :** Des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, de sorte que les points forment une ligne droite ascendante sur l'échelle base‑10. Les étiquettes d'axe affichent toujours les comptages de requêtes d'origine.

![Les mêmes cinq comptages de requêtes dans PowerPoint sur un axe de valeur logarithmique base‑10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l'activer. Si les valeurs zéro ou négatives sont significatives, conservez une échelle linéaire ou affichez‑les séparément. Si exclure ces valeurs est approprié pour l'analyse, expliquez l'omission. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela changerait le sens des données. Toute valeur minimale ou maximale configurée manuellement pour un axe logarithmique doit également être positive.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axe) ?**

Utilisez [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) pour sélectionner le comportement du croisement. Pour spécifier une valeur numérique de croisement, définissez [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Ces paramètres vous permettent de déplacer le croisement de l'axe à une base appropriée.

**Comment positionner les étiquettes de repère par rapport à l'axe ?**

Définissez [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) en utilisant [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) : `LOW`, `HIGH`, `NEXT_TO` ou `NONE`. Pour contrôler les repères eux‑mêmes, utilisez [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) ou [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) ; ces propriétés sont distinctes du positionnement des étiquettes.