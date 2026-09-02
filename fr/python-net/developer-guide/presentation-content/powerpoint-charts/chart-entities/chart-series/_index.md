---
title: Gestion des séries de données de graphique dans les présentations en Python
linktitle: Séries de données
type: docs
url: /fr/python-net/chart-series/
keywords:
- séries de graphique
- chevauchement des séries
- couleur des séries
- couleur de catégorie
- nom de la série
- point de données
- écart de série
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez comment gérer les séries de graphiques, les points de données, les cellules du classeur, le formatage, le chevauchement, la largeur d’écart et les valeurs négatives dans les présentations avec Python."
---
## **Vue d’ensemble**

Un graphique stocke ses données tracées dans un classeur de données de graphique. Un [ChartSeries](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/) représente un ensemble de valeurs liées, et chaque [ChartDataPoint](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapoint/) de la série fait référence à une ou plusieurs cellules du classeur. Les objets [ChartCategory](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartcategory/) fournissent les libellés ou les valeurs de regroupement partagés par les séries. Le nom de la série, les catégories et les valeurs des points sont donc liés à des objets [ChartDataCell](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatacell/) plutôt qu’enregistrés uniquement comme texte affiché.

Pour un graphique de catégorie typique, le classeur par défaut utilise la ligne 0 pour les noms de séries, la colonne 0 pour les noms de catégories, et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) sont basés sur zéro. Cette disposition est pratique lorsque vous créez un graphique avec des données par défaut, mais ne supposez pas que chaque graphique existant l’utilise. Pour une présentation chargée, inspectez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du graphique ont trois portées différentes :

- Paramètres au niveau de la série, comme [ChartSeries.format](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/format/), fournissent l’apparence par défaut pour tous les points d’une série.
- Paramètres au niveau du point de données, comme [ChartDataPoint.format](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapoint/format/), remplacent l’apparence de la série pour un point.
- Les paramètres de groupe s’appliquent aux séries compatibles qui appartiennent au même [ChartSeriesGroup](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseriesgroup/). Accédez au groupe via [ChartSeries.parent_series_group](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/parent_series_group/) lorsque vous devez définir des options telles que le chevauchement ou la largeur de l’écart.

Lorsqu’aucun remplissage explicite de point ou de série n’est défini, le style et le thème du graphique déterminent l’apparence automatique. Lorsque les deux formats (série et point) sont présents, le format du point a la priorité pour ce point.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries du graphique**

[ChartSeries.overlap](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/overlap/) indique dans quelle mesure les barres ou les colonnes se chevauchent dans un graphique 2D, de –100 à 100 pour cent. Il s’agit d’une projection en lecture seule du paramètre du groupe de séries parent. Définissez [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseriesgroup/overlap/) pour mettre à jour toutes les séries compatibles de ce groupe. Cette option s’applique aux types de graphiques qui affichent des barres ou des colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un graphique combiné.

L’exemple suivant définit le chevauchement pour le groupe contenant la première série :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Le nouveau graphique contient des séries, des catégories et des valeurs d'exemple.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![The series overlap](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [ChartSeries.format](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/format/) pour définir le remplissage par défaut d’une série entière. Si un point possède déjà un remplissage explicite, son paramètre [ChartDataPoint.format](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapoint/format/) remplace le remplissage de la série pour ce point.

L’exemple suivant applique un remplissage bleu uni à la première série :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![The color of the series](series_color.png)

## **Modifier le nom de la série**

Le nom d’une série est stocké dans le classeur de données du graphique et apparaît généralement dans la légende. Dans le classeur par défaut créé pour un graphique à colonnes groupées, la cellule B1 se trouve à la ligne 0, colonne 1 et contient le nom de la première série. Les constantes nommées de l’exemple suivant rendent cette structure explicite :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Vous pouvez également mettre à jour la cellule déjà référencée par [ChartSeries.name](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/name/). Cette approche évite de supposer une ligne ou une colonne particulière dans un graphique existant :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![The series name](series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) renvoie la couleur calculée à partir de l’index de la série et du style du graphique. C’est la couleur utilisée lorsque le remplissage de la série n’a pas été explicitement défini. L’appel de la méthode lit la couleur calculée ; il n’assigne pas un nouveau remplissage.

L’exemple suivant affiche la couleur automatique de chaque série par défaut :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Exemple de sortie pour le style de graphique par défaut :

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Les couleurs exactes dépendent du style et du thème du graphique.

## **Définir la couleur de remplissage inversée pour une série de graphique**

Pour les séries à barres, colonnes et bulles, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/invert_if_negative/) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage régulier de la série sur solide, activez l’inversion et attribuez la couleur des valeurs négatives via [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Les nombres négatifs restent inchangés dans le classeur ; seule leur couleur d’affichage varie.

L’exemple suivant remplace les données de graphique par défaut par une série. La ligne 0 de la feuille contient le nom de la série, la colonne 0 les noms de catégories et la colonne 1 les valeurs :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![The inverted solid fill color](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un seul point via [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l’effet soit visible :

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Effacer la valeur d’un point de données spécifique**

Pour rendre un point vide sans supprimer les autres points, définissez la cellule du classeur sous‑jacent à `None`. Pour un graphique à colonnes, la valeur tracée est disponible via [ChartDataPoint.value](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapoint/value/). Le point de données reste à la même position de catégorie, mais le graphique traite sa valeur comme vide selon les paramètres de valeurs vides du graphique.

L’exemple suivant efface uniquement le deuxième point de la première série :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Les graphiques en nuage de points utilisent des cellules X et Y séparées, et les graphiques à bulles utilisent également une cellule de taille. Effacez uniquement la cellule qui représente la valeur que vous souhaitez supprimer. N’utilisez pas [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapointcollection/clear/) si vous voulez conserver les autres points, car cette méthode supprime tous les points de la collection.

## **Définir la largeur de l’écart de la série**

La largeur de l’écart est l’espace entre les clusters de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, il appartient au groupe de séries parent plutôt qu’à une seule série. Définissez [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) une fois pour le groupe. Une valeur plus grande crée plus d’espace entre les clusters ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur de l’écart et enregistre uniquement la présentation finale :

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![The gap width](gap_width.png)

## **FAQ**

**Quels types de graphiques prennent en charge les séries de données ?**

Tous les types de graphiques représentés par l’énumération [ChartType](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/charttype/) utilisent des données de graphique, mais leurs séries n’ont pas toutes la même structure de valeurs ou les mêmes paramètres. Par exemple, les graphiques de catégorie utilisent des catégories et des valeurs, les graphiques en nuage de points utilisent des valeurs X et Y, et les graphiques à bulles ajoutent des tailles de bulles. Utilisez la méthode de création de points de données qui correspond au type de série. Les options telles que le chevauchement et la largeur de l’écart ne s’appliquent qu’aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de graphique ?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseriesgroup/) contient des séries compatibles qui partagent des paramètres de tracé au niveau du groupe. Un graphique combiné peut contenir plusieurs groupes, de sorte que la modification du groupe atteinte via une série ne modifie pas forcément toutes les séries du graphique.

**Un graphique nouvellement créé contient‑il des données par défaut ?**

Oui. Par défaut, [ShapeCollection.add_chart](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_chart/) crée des séries, des catégories et des valeurs d’exemple. Vous pouvez modifier ces cellules ou effacer à la fois les collections de séries et de catégories avant d’ajouter un jeu de données entièrement personnalisé. Une surcharge peut également créer un graphique sans données par défaut.

**Comment les objets de graphique sont‑ils liés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs de points de données font référence à des cellules d’un [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdataworkbook/). Modifier une cellule référencée met à jour l’élément de graphique correspondant. Lorsque vous créez des données personnalisées, maintenez les lignes de catégories et les lignes de valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point sans supprimer toute la série ?**

Définissez la cellule de valeur concernée sur `None` pour conserver la position de catégorie du point en tant que point vide. Utilisez [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapointcollection/clear/) uniquement lorsque vous souhaitez supprimer tous les points de cette série. Si vous supprimez également des catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de graphique et de [Chart.display_blanks_as](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/display_blanks_as/). Les graphiques pris en charge peuvent afficher les blancs comme des écarts, comme des valeurs zéro, ou en reliant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries de barres, colonnes et bulles prises en charge, activez [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/invert_if_negative/) et définissez [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Vous pouvez remplacer ce comportement pour un point individuel avec [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Ces propriétés affectent le formatage, pas les valeurs numériques stockées.

**Quel format l’emporte lorsque la série et le point sont tous deux formatés ?**

Le formatage explicite du point de données prime pour ce point. Les autres points continuent d’utiliser le format de série explicite ou, lorsque le format de la série n’est pas défini, le style et le thème automatiques du graphique. Les propriétés de groupe telles que le chevauchement et la largeur de l’écart contrôlent la disposition et ne constituent pas des remplacements de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu’un graphique peut contenir ?**

Aspose.Slides n’impose pas de limite fixe séparée au nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du graphique déterminent une limite utile.

**Que faut‑il modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Définissez [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les clusters, ou diminuez‑la pour rapprocher les clusters les uns des autres.