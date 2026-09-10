---
title: Créer ou mettre à jour des graphiques de présentation PowerPoint en Python
linktitle: Créer ou mettre à jour des graphiques
type: docs
weight: 10
url: /fr/python-java/create-chart/
keywords:
- ajouter un graphique
- créer un graphique
- modifier un graphique
- changer un graphique
- mettre à jour un graphique
- graphique de dispersion
- graphique circulaire
- graphique en courbes
- graphique en carte d'arbre
- graphique boursier
- graphique boîte à moustaches
- graphique en entonnoir
- graphique en rayons
- graphique histogramme
- graphique radar
- graphique multi‑catégorie
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer et personnaliser des graphiques dans des présentations PowerPoint à l'aide d'Aspose.Slides pour Python via Java. Ajouter, formater et modifier des graphiques avec des exemples de code pratiques en Python."
---
## **Vue d'ensemble**

Cet article fournit un guide complet sur la création et la personnalisation des graphiques avec Aspose.Slides. Vous apprendrez à ajouter un graphique à une diapositive de manière programmatique, à le remplir avec des données et à appliquer diverses options de mise en forme pour répondre à vos exigences de conception spécifiques. Tout au long de l'article, des exemples de code détaillés illustrent chaque étape, depuis l'initialisation de la présentation et de l'objet graphique jusqu'à la configuration des séries, des axes et des légendes. En suivant ce guide, vous acquerrez une compréhension solide de l'intégration de la génération dynamique de graphiques dans vos applications, simplifiant le processus de création de présentations basées sur les données.

## **Créer un graphique**

Les graphiques aident les gens à visualiser rapidement les données et à obtenir des informations qui ne sont pas immédiatement évidentes à partir d'un tableau ou d'une feuille de calcul.

**Pourquoi créer des graphiques ?**

En utilisant des graphiques, vous pouvez :

* agréger, condenser ou résumer de grandes quantités de données sur une seule diapositive d’une présentation
* faire apparaître des motifs et des tendances dans les données
* déduire la direction et l’élan des données au fil du temps ou par rapport à une unité de mesure spécifique
* repérer les valeurs aberrantes, les écarts, les erreurs, les données incohérentes, etc.
* communiquer ou présenter des données complexes

Dans PowerPoint, vous pouvez créer des graphiques via la fonction *Insert*, qui propose des modèles pour concevoir de nombreux types de graphiques. Avec Aspose.Slides, vous pouvez créer à la fois des graphiques classiques (basés sur des types de graphiques populaires) et des graphiques personnalisés.

{{% alert color="info" title="Remarque" %}}

Pour créer des graphiques, utilisez la classe [ChartType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/). Les champs de cette classe correspondent aux différents types de graphiques.

{{% /alert %}}

### **Créer des graphiques à colonnes groupées**

Cette section explique comment créer des graphiques à colonnes groupées avec Aspose.Slides. Vous apprendrez à initialiser une présentation, à ajouter un graphique et à personnaliser ses éléments tels que le titre, les données, les séries, les catégories et le style. Suivez les étapes ci‑dessous pour voir comment un graphique à colonnes groupées standard est généré :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données et spécifiez le type `ChartType.ClusteredColumn`.
1. Ajoutez un titre au graphique.
1. Accédez à la feuille de données du graphique.
1. Effacez toutes les séries et catégories par défaut.
1. Ajoutez de nouvelles séries et catégories.
1. Ajoutez de nouvelles données de graphique pour les séries.
1. Appliquez une couleur de remplissage aux séries du graphique.
1. Ajoutez des libellés aux séries du graphique.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# montre comment créer un graphique à colonnes groupées :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Instancie une classe de présentation qui représente un fichier PPTX.
presentation = Presentation()
try:
    # Accède à la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Ajoute un graphique avec ses données par défaut
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Définit le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Définit l'index de la feuille de données du graphique
    default_worksheet_index = 0

    # Récupère la feuille de calcul des données du graphique
    workbook = chart.getChartData().getChartDataWorkbook()

    # Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Ajoute de nouvelles séries
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Ajoute de nouvelles catégories
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # Prend la première série du graphique
    series = chart.getChartData().getSeries().get_Item(0)

    # Remplit maintenant les données de la série
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # Prend la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1)

    # Remplit les données de la série
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Définit la couleur de remplissage pour la série
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Créer des étiquettes personnalisées pour chaque catégorie de la nouvelle série
    # Définit la première étiquette pour afficher le nom de la catégorie
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Affiche la valeur pour la troisième étiquette
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Enregistre la présentation avec le graphique
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques de dispersion**

Les graphiques de dispersion (également appelés nuages de points ou graphiques X‑Y) sont souvent utilisés pour vérifier des motifs ou démontrer des corrélations entre deux variables.

Utilisez un graphique de dispersion lorsque :

* vous avez des données numériques appariées
* vous avez deux variables qui s’associent bien
* vous voulez déterminer si deux variables sont liées
* vous avez une variable indépendante possédant plusieurs valeurs pour une variable dépendante

1. Suivez les étapes de [Créer des graphiques à colonnes groupées](#cr%C3%A9er-des-graphiques-%C3%A0-colonnes-group%C3%A9es).
2. Pour la troisième étape, ajoutez un graphique avec des données et spécifiez votre type de graphique parmi les suivants :
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Représente un graphique de dispersion._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Représente un graphique de dispersion relié par des courbes, avec des repères de données._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Représente un graphique de dispersion relié par des courbes, sans repères de données._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Représente un graphique de dispersion relié par des lignes droites, avec des repères de données._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Représente un graphique de dispersion relié par des lignes droites, sans repères de données._

Ce code Python montre comment créer un graphique de dispersion avec différents repères pour chaque série :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# Instancie une classe de présentation qui représente un fichier PPTX.
presentation = Presentation()
try:
    # Accède à la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Crée le graphique par défaut
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Obtient l'index de la feuille de données du graphique par défaut
    default_worksheet_index = 0

    # Obtient la feuille de données du graphique
    workbook = chart.getChartData().getChartDataWorkbook()

    # Supprime les séries de démonstration
    chart.getChartData().getSeries().clear()

    # Ajoute de nouvelles séries
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Prend la première série du graphique
    series = chart.getChartData().getSeries().get_Item(0)

    # Ajoute un nouveau point (1:3) à la série
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Ajoute un nouveau point (2:10)
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Modifie le type de la série
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Modifie le repère de la série du graphique
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # Prend la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1)

    # Ajoute un nouveau point (5:2) là
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Ajoute un nouveau point (3:1)
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Ajoute un nouveau point (2:2)
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Ajoute un nouveau point (5:1)
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Modifie le repère de la série du graphique
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques circulaires**

Les graphiques circulaires sont les mieux adaptés pour illustrer la relation partie‑à‑tout dans les données, surtout lorsque les données contiennent des libellés catégoriels associés à des valeurs numériques. Cependant, si vos données comportent de nombreuses parties ou libellés, il peut être préférable d’utiliser un graphique à barres.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Pie](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#Pie).
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/).
5. Effacez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Ajoutez de nouveaux points au graphique et appliquez des couleurs personnalisées aux secteurs du graphique circulaire.
9. Définissez les libellés pour les séries.
10. Activez les lignes directrices pour les libellés des séries.
11. Définissez l’angle de rotation des secteurs du graphique circulaire.
12. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique circulaire :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Instancie une classe de présentation qui représente un fichier PPTX.
presentation = Presentation()
try:
    # Accède à la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Ajoute un graphique avec les données par défaut
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Définit le titre du graphique
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Définit l'index de la feuille de données du graphique
    default_worksheet_index = 0

    # Obtient la feuille de calcul des données du graphique
    workbook = chart.getChartData().getChartDataWorkbook()

    # Supprime les séries et catégories générées par défaut
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Ajoute de nouvelles catégories
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Ajoute de nouvelles séries
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Remplit les données de la série
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Ajout de nouveaux points et définition de la couleur du secteur
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Définit la bordure du secteur
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Définit la bordure du secteur
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Définit la bordure du secteur
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Crée des étiquettes personnalisées pour chaque catégorie de la nouvelle série
    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Affiche les lignes directrices pour le graphique
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Définit l'angle de rotation des secteurs du graphique circulaire
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Enregistre la présentation avec un graphique
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques en courbes**

Les graphiques en courbes (également appelés graphiques linéaires) sont les mieux adaptés lorsqu’il faut montrer des variations de valeur au fil du temps. Avec un graphique en courbes, vous pouvez comparer un grand volume de données d’un seul coup, suivre les évolutions et les tendances dans le temps, mettre en évidence des anomalies dans les séries, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive à l’aide de son indice.
1. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Line](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#Line).
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique en courbes :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Par défaut, les points d’un graphique en courbes sont reliés par des lignes droites continues. Si vous préférez que les points soient reliés par des tirets, vous pouvez spécifier le type de tiret souhaité comme suit :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques en carte d’arbre**

Les graphiques en carte d’arbre sont les mieux adaptés aux données de ventes lorsqu’il faut montrer la taille relative des catégories de données et attirer rapidement l’attention sur les éléments qui contribuent le plus au sein de chaque catégorie.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Treemap](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#Treemap).
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/).
5. Effacez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique en carte d’arbre :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #branche 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #branche 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques boursiers**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#OpenHighLowClose).
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/).
5. Effacez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Spécifiez le format des lignes haut‑bas.
9. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique boursier :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques boîte à moustaches**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#BoxAndWhisker).
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/).
5. Effacez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique boîte à moustaches :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques en entonnoir**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Funnel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#Funnel).
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique en entonnoir :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques en rayons (Sunburst)**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Sunburst](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#Sunburst).
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique en rayons :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #branche 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #branche 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques histogrammes**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.Histogram](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#Histogram).
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/).
5. Effacez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique histogramme :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques radar**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données et spécifiez votre type de graphique préféré ([ChartType.Radar](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#Radar) dans ce cas).
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique radar :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques multi‑catégories**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Ajoutez un graphique avec des données par défaut et spécifiez le type [ChartType.ClusteredColumn](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#ClusteredColumn).
4. Accédez au classeur de données du graphique [ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/).
5. Effacez les séries et catégories par défaut.
6. Ajoutez de nouvelles séries et catégories.
7. Ajoutez de nouvelles données de graphique pour les séries.
8. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un graphique multi‑catégorie :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # Ajout de séries
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Enregistrer la présentation avec le graphique
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques cartographiques**

Les graphiques cartographiques visualisent les données géographiques et aident à comparer les valeurs entre régions.

Ce code Python montre comment créer un graphique cartographique :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Créer des graphiques combinés**

Un graphique combiné (ou combo) regroupe deux types de graphiques ou plus dans un même diagramme. Ce graphique vous permet de mettre en évidence, comparer ou examiner les différences entre deux ensembles de données ou plus, facilitant l’identification de leurs relations.

![The combination chart](combination_chart.png)

Le code Python suivant montre comment créer le graphique combiné illustré ci‑dessus dans une présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Définir le titre du graphique.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Définir la légende du graphique.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Supprimer les séries et catégories générées par défaut.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Ajouter de nouvelles catégories.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Ajouter la première série.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Définir l'axe horizontal.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Définir l'axe vertical.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Définir la couleur des lignes de grille majeures verticales.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Définir l'axe horizontal secondaire.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Définir l'axe vertical secondaire.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Mettre à jour les graphiques**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui représente la présentation contenant le graphique à mettre à jour.
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez à la feuille de données du graphique.
5. Modifiez les séries de données du graphique en changeant les valeurs de séries.
6. Ajoutez une nouvelle série et remplissez‑la avec des données.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment mettre à jour un graphique :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Ouvre la présentation contenant le graphique à mettre à jour
presentation = Presentation("ExistingChart.pptx")
try:
    # Accède à la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Récupère le graphique depuis la diapositive
    chart = slide.getShapes().get_Item(0)

    # Définit l'index de la feuille de données du graphique
    default_worksheet_index = 0

    # Obtient la feuille de calcul des données du graphique
    workbook = chart.getChartData().getChartDataWorkbook()

    # Modifie le nom de la catégorie du graphique
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # Prend la première série du graphique
    series = chart.getChartData().getSeries().get_Item(0)

    # Met à jour les données de la série
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Modification du nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # Prend la deuxième série du graphique
    series = chart.getChartData().getSeries().get_Item(1)

    # Met à jour les données de la série
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Modification du nom de la série
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Ajoute une nouvelle série
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Prend la 3ᵉ série du graphique
    series = chart.getChartData().getSeries().get_Item(2)

    # Remplit les données de la série
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Enregistre la présentation avec le graphique
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la plage de données d’un graphique**

Pour définir la plage de données d’un graphique, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) qui représente la présentation contenant le graphique.
2. Obtenez une référence à une diapositive à l’aide de son indice.
3. Parcourez toutes les formes pour trouver le graphique souhaité.
4. Accédez aux données du graphique et définissez la plage.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment définir la plage de données d’un graphique :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Ouvre la présentation qui contient le graphique
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Utiliser des repères par défaut dans les graphiques**

Lorsque vous utilisez des repères par défaut dans les graphiques, chaque série de graphique reçoit automatiquement un symbole de repère différent.

Ce code Python montre comment définir automatiquement le repère d’une série de graphique :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    # Prendre la deuxième série du graphique
    second_series = chart.getChartData().getSeries().get_Item(1)

    # Maintenant remplissage des données de la série
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quels types de graphiques sont pris en charge par Aspose.Slides ?**

Aspose.Slides prend en charge un large éventail de [types de graphiques](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/), notamment des barres, des lignes, des secteurs, des aires, des dispersions, des histogrammes, des radars et bien d’autres. Cette flexibilité vous permet de choisir le type de graphique le plus adapté à vos besoins de visualisation de données.

**Comment ajouter un nouveau graphique à une diapositive ?**

Pour ajouter un graphique, créez d’abord une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), récupérez la diapositive souhaitée à l’aide de son indice, puis appelez la méthode d’ajout de graphique en spécifiant le type de graphique et les données initiales. Ce processus intègre le graphique directement dans votre présentation.

**Comment mettre à jour les données affichées dans un graphique ?**

Vous pouvez mettre à jour les données d’un graphique en accédant à son classeur de données ([ChartDataWorkbook](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdataworkbook/)), en supprimant les séries et catégories par défaut, puis en ajoutant vos propres données personnalisées. Cela vous permet d’actualiser le graphique avec les dernières informations.

**Est‑il possible de personnaliser l’apparence du graphique ?**

Oui, Aspose.Slides offre de nombreuses options de personnalisation. Vous pouvez modifier les couleurs, les polices, les libellés, les légendes et d’autres [éléments de mise en forme](/slides/fr/python-java/chart-entities/) afin d’adapter l’apparence du graphique à vos exigences de conception spécifiques.