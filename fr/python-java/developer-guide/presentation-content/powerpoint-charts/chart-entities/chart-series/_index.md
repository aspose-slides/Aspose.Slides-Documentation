---
title: Gérer les séries de données de graphique dans les présentations en Python
linktitle: Séries de données
type: docs
url: /fr/python-java/chart-series/
keywords:
- séries de graphiques
- chevauchement des séries
- couleur des séries
- nom de la série
- point de données
- cellule de classeur
- écart des séries
- valeur négative
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à gérer les séries de graphiques, les points de données, les cellules de classeur, le formatage, le chevauchement, la largeur d’écart et les valeurs négatives dans les présentations avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Un graphique stocke ses données tracées dans un classeur de données de graphique. Un [ChartSeries](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/) représente un ensemble de valeurs liées, et chaque [ChartDataPoint](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/) de la série fait référence à une ou plusieurs cellules du classeur. Les objets [ChartCategory](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartcategory/) fournissent les libellés ou les valeurs de regroupement partagés par les séries. Le nom de la série, les catégories et les valeurs des points sont donc reliés aux objets [ChartDataCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/), plutôt que d’être stockés uniquement comme texte d’affichage.

Pour un graphique de type catégorie typique, le classeur par défaut utilise la ligne 0 pour les noms de séries, la colonne 0 pour les noms de catégories et les cellules restantes pour les valeurs des séries. Les index de feuille, de ligne et de colonne transmis à [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/#getCell) sont basés sur zéro. Cette disposition est utile lorsque vous créez un graphique avec des données par défaut, mais ne supposez pas que chaque graphique existant l’utilise. Pour une présentation chargée, inspectez les cellules référencées par les séries, les catégories et les points de données avant de modifier les valeurs du classeur.

Les paramètres du graphique ont trois portées différentes :

- Les paramètres au niveau de la série, tels que [ChartSeries.getFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getFormat), fournissent l’apparence par défaut pour tous les points d’une série.
- Les paramètres de point de données, tels que [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/#getFormat), remplacent l’apparence de la série pour un point.
- Les paramètres de groupe s’appliquent aux séries compatibles appartenant au même [ChartSeriesGroup](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/). Accédez au groupe via [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getParentSeriesGroup) lorsque vous devez définir des options telles que le chevauchement ou la largeur d’écart.

Lorsqu’aucun remplissage explicite de point ou de série n’est défini, le style et le thème du graphique déterminent l’apparence automatique. Lorsque les formats de série et de point sont tous deux présents, le format du point a la priorité pour ce point.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Définir le chevauchement des séries du graphique**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getOverlap) indique le degré de chevauchement des barres ou colonnes dans un graphique 2D, de -100 à 100 pourcent. Il s’agit d’une projection en lecture seule du paramètre du groupe de séries parent. Utilisez [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#setOverlap) pour mettre à jour toutes les séries compatibles de ce groupe. Cette option s’applique aux types de graphiques affichant des barres ou colonnes groupées ; elle n’affecte pas les groupes de séries non liés dans un graphique combiné.

L’exemple suivant définit le chevauchement pour le groupe contenant la première série :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Le nouveau graphique contient des séries d'exemple, des catégories et des valeurs.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :
![Le chevauchement des séries](series_overlap.png)

## **Modifier la couleur de remplissage de la série**

Utilisez [ChartSeries.getFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getFormat) pour définir le remplissage par défaut d’une série entière. Si un point possède déjà un remplissage explicite, son paramètre [ChartDataPoint.getFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/#getFormat) remplace le remplissage de la série pour ce point.

L’exemple suivant applique un remplissage bleu uni à la première série :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :
![La couleur de la série](series_color.png)

## **Modifier le nom de la série**

Le nom d’une série est stocké dans le classeur de données du graphique et est généralement affiché dans la légende. Dans le classeur par défaut créé pour un graphique à colonnes groupées, la cellule B1 se trouve à la ligne 0, colonne 1 et contient le nom de la première série. Les variables nommées dans l’exemple suivant rendent cette structure explicite :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vous pouvez également mettre à jour la cellule déjà référencée par [ChartSeries.getName](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getName). Cette approche évite de supposer une ligne ou une colonne particulière dans un graphique existant :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :
![Le nom de la série](series_name.png)

## **Obtenir la couleur de remplissage automatique de la série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) renvoie la couleur calculée à partir de l’index de la série et du style du graphique. C’est la couleur utilisée lorsque le remplissage de la série n’a pas été défini explicitement. L’appel de la méthode lit la couleur calculée ; il n’attribue pas de nouveau remplissage.

L’exemple suivant affiche la couleur automatique de chaque série par défaut :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Exemple de sortie pour le style de graphique par défaut :
```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Les couleurs exactes dépendent du style et du thème du graphique.

## **Définir la couleur de remplissage inversée pour une série de graphique**

Pour les séries à barres, colonnes et bulles, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#setInvertIfNegative) peut afficher les valeurs négatives avec un remplissage différent. Définissez le remplissage normal de la série comme solide, activez l’inversion et assignez la couleur des valeurs négatives via [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Les nombres négatifs restent inchangés dans le classeur ; seule leur couleur d’affichage change.

L’exemple suivant remplace les données du graphique par défaut par une seule série. La ligne 0 de la feuille de calcul contient le nom de la série, la colonne 0 les noms de catégorie et la colonne 1 les valeurs :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :
![La couleur de remplissage solide inversée](inverted_solid_fill_color.png)

Vous pouvez activer l’inversion pour un point via [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Dans l’exemple suivant, l’inversion est désactivée pour la série et activée uniquement pour le point sélectionné. Le point reçoit également une valeur négative afin que l’effet soit visible :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Effacer la valeur d’un point de données spécifique**

Pour rendre un point vide sans supprimer les autres points, définissez sa cellule du classeur sous-jacent sur `None`. Pour un graphique à colonnes, la valeur tracée est disponible via [ChartDataPoint.getValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/#getValue). Le point de données reste à la même position de catégorie, mais le graphique traite sa valeur comme vide selon les paramètres de valeurs vides du graphique.

L’exemple suivant ne vide que le deuxième point de la première série :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les graphiques en nuage de points utilisent des cellules X et Y séparées, et les graphiques à bulles utilisent également une cellule de taille. Ne videz que la cellule représentant la valeur que vous souhaitez supprimer. N’appelez pas [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapointcollection/#clear) lorsque vous voulez conserver les autres points, car cette méthode supprime tous les points de données de la collection.

## **Contrôler l’affichage des cellules vides**

Les cellules masquées contenant des valeurs constituent un cas distinct des cellules vides. Pour inclure ou exclure des données provenant de lignes et colonnes masquées d’une feuille de calcul, voir [Include Data from Hidden Rows and Columns](/slides/fr/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Une cellule vide du classeur représente des données manquantes ; une cellule contenant `0` représente une valeur numérique connue. Appelez [ChartDataCell.setValue](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatacell/#setValue) avec `None` pour rendre une cellule vide. Un zéro numérique reste zéro quel que soit le paramètre de cellule vide.

Utilisez [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#setDisplayBlanksAs) pour choisir comment le graphique affiche les cellules vides. Ce réglage s’applique à l’ensemble du graphique. Il modifie la façon dont les blancs sont tracés, sans remplir la cellule vide du classeur avec zéro ou une valeur interpolée.

L’exemple autonome suivant crée un graphique en courbes avec une série, vide la valeur du Jour 3 et enregistre le même graphique avec chaque mode. Aucun fichier d’entrée n’est requis. Le [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/) utilise la feuille 0, la colonne 0 pour les libellés de catégorie et la colonne 1 pour les valeurs ; la ligne 0 contient le nom de la série. Les données finales sont `10, 20, empty, 30, 40`.
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Laisser le jour 3 réellement vide, tout en conservant sa catégorie et son point de données.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Chaque fichier de sortie enregistre le mode attribué avant l’enregistrement : `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` et `empty_cells_Span.pptx`. Pour enregistrer une seule version, affectez le mode souhaité et sauvegardez la présentation une fois plutôt que d’itérer sur les modes.

La comparaison ci‑dessous montre les mêmes données dans les trois fichiers. Le Jour 3 est vide dans le classeur dans chaque cas :
![Graphiques en lignes avec données identiques : Gap coupe la ligne au Jour 3, Zero abaisse la ligne à zéro, et Span relie le Jour 2 au Jour 4.](display_blanks_as.png)

L’effet visible dépend du type de graphique. Un graphique en lignes rend les trois modes faciles à comparer. Les graphiques à barres et à colonnes n’ont pas de ligne à connecter entre des catégories manquantes, ainsi `Span` ne peut pas produire le segment de connexion montré ci‑dessus ; une colonne manquante et une colonne de hauteur zéro peuvent également se ressembler. De même, un nuage de points avec uniquement des marqueurs n’a pas de ligne de connexion. N’attendez pas trois résultats distincts pour chaque type de graphique ; vérifiez la sortie pour le type que vous utilisez.

## **Définir la largeur d’écart des séries**

La largeur d’écart est l’espace entre les groupes de barres ou de colonnes adjacents, exprimé en pourcentage de la largeur de la barre ou de la colonne. Comme le chevauchement, elle appartient au groupe de séries parent plutôt qu’à une série individuelle. Appelez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#setGapWidth) une fois pour le groupe. Une valeur plus grande crée plus d’espace entre les groupes ; une valeur plus petite les rend plus denses.

L’exemple suivant modifie la largeur d’écart et enregistre uniquement la présentation finale :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :
![La largeur d'écart](gap_width.png)

## **FAQ**

**Quels types de graphiques prennent en charge les séries de données ?**

Tous les types de graphiques représentés par l’énumération [ChartType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/) utilisent des données de graphique, mais leurs séries n’ont pas toutes la même structure de valeurs ou les mêmes paramètres. Par exemple, les graphiques à catégories utilisent des catégories et des valeurs, les graphiques en nuage de points utilisent des valeurs X et Y, et les graphiques à bulles ajoutent des tailles de bulles. Utilisez la méthode de création de points de données correspondant au type de série. Les options telles que le chevauchement et la largeur d’écart ne s’appliquent qu’aux groupes de barres ou de colonnes compatibles.

**Qu’est‑ce qu’un groupe de séries de graphique ?**

Un [ChartSeriesGroup](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/) contient des séries compatibles qui partagent des paramètres de tracé au niveau du groupe. Un graphique combiné peut contenir plusieurs groupes, ainsi le fait de modifier le groupe atteint via une série ne change pas forcément toutes les séries du graphique.

**Un graphique créé récemment contient‑il des données par défaut ?**

Oui. Par défaut, [ShapeCollection.addChart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addChart) crée des séries, catégories et valeurs d’exemple. Vous pouvez modifier ces cellules ou vider les collections de séries et de catégories avant d’ajouter un jeu de données entièrement personnalisé. Une surcharge peut également créer un graphique sans données par défaut.

**Comment les objets du graphique sont‑ils reliés aux cellules du classeur ?**

Les noms de séries, les libellés de catégories et les valeurs des points de données font référence à des cellules d’un [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/). Modifier une cellule référencée met à jour l’élément de graphique correspondant. Lorsque vous construisez des données personnalisées, maintenez les lignes de catégories et les lignes des valeurs de séries alignées afin que chaque point soit tracé sous la catégorie prévue.

**Comment effacer un point au lieu de toute la série ?**

Définissez la cellule de valeur concernée sur `None` pour conserver la position de catégorie du point comme point vide. Utilisez [ChartDataPointCollection.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapointcollection/#clear) uniquement lorsque vous souhaitez supprimer tous les points de cette série. Si vous supprimez également les catégories, mettez à jour chaque série afin que leurs valeurs restent alignées avec la collection de catégories.

**Comment les points vides sont‑ils affichés ?**

Le résultat dépend du type de graphique et de la valeur configurée via [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#setDisplayBlanksAs). Les graphiques pris en charge peuvent afficher les blancs comme des espaces, comme des valeurs zéro, ou en connectant les points voisins. Choisissez le paramètre qui correspond à la signification des données manquantes dans votre présentation. Voir [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pour un exemple complet et une comparaison visuelle.

**Comment les valeurs négatives sont‑elles formatées ?**

Pour les séries à barres, colonnes et bulles prises en charge, appelez [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#setInvertIfNegative) et définissez la couleur renvoyée par [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Vous pouvez remplacer le comportement pour un point individuel avec [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Ces méthodes affectent le formatage, pas les valeurs numériques stockées.

**Quel format l'emporte lorsque la série et le point sont tous deux formatés ?**

Le formatage explicite du point de données a la priorité pour ce point. Les autres points continuent d’utiliser le format de série explicite ou, si le format de la série n’est pas défini, le style et le thème automatiques du graphique. Les paramètres de groupe tels que le chevauchement et la largeur d’écart contrôlent la disposition et ne sont pas des remplacements de formatage au niveau du point.

**Existe‑t‑il une limite au nombre de séries qu’un graphique peut contenir ?**

Aspose.Slides n’impose pas de limite fixe distincte du nombre de séries. En pratique, les contraintes du fichier de présentation, la mémoire disponible, le temps de rendu et la lisibilité du graphique déterminent une limite utile.

**Que dois‑je modifier lorsque les colonnes sont trop proches ou trop éloignées ?**

Appelez [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#setGapWidth) sur le groupe de séries parent approprié. Augmentez la valeur pour élargir l’espace entre les groupes, ou diminuez‑la pour rapprocher les groupes.