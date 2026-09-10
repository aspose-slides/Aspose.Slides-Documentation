---
title: "Personnaliser les points de données dans les graphiques Treemap et Sunburst en Python"
linktitle: "Points de données dans les graphiques Treemap et Sunburst"
type: docs
url: /fr/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graphique Treemap
- graphique Sunburst
- graphique hiérarchique
- point de données
- étiquette de données
- couleur de branche
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à créer des données hiérarchiques et à personnaliser les niveaux, les étiquettes et les couleurs dans les graphiques Treemap et Sunburst avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Les graphiques Treemap et Sunburst affichent le même type de données hiérarchiques, mais ils utilisent des dispositions différentes. Un Treemap représente la hiérarchie sous forme de rectangles imbriqués dont les surfaces correspondent aux valeurs des feuilles. Un Sunburst la représente sous forme d’anneaux concentriques : les groupes de niveau supérieur sont près du centre, et les catégories feuilles se trouvent sur l’anneau extérieur.

Dans Aspose.Slides for Python via Java, chaque valeur numérique est un [ChartDataPoint](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/). Sa méthode [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) donne accès à la feuille et à ses groupes parents. Cet article explique ce mappage et montre comment créer et mettre en forme les deux types de graphiques à partir des mêmes données d’exemple.

![Un graphique Treemap avec les branches Consumer et Business](treemap-hierarchy.png)

![Un graphique Sunburst avec la même hiérarchie Consumer et Business](sunburst-hierarchy.png)

## **Comprendre les catégories, points de données et niveaux**

L’exemple utilisé ci‑dessous possède trois niveaux de catégorie et une série numérique :

| Branche | Tronc | Feuille | Revenu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Chaque ligne crée une catégorie feuille et un point de donnée. Les niveaux de regroupement décrivent le chemin de la feuille vers ses parents. Pour la première ligne, le chemin est `Consumer > Computers > Laptops`.

Les index renvoyés par [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) partent de la feuille et remontent :

| `getDataPointLevels()` index | Niveau logique | Représentation Treemap | Représentation Sunburst |
| ---: | --- | --- | --- |
| `0` | Feuille | Rectangle de valeur | Segment de l’anneau extérieur |
| `1` | Tronc | Rectangle ou en‑tête parent | Segment de l’anneau intermédiaire |
| `2` | Branche | Rectangle ou en‑tête de niveau supérieur | Segment de l’anneau intérieur |

Cet ordre est le même pour les deux types de graphiques même si leurs dispositions visuelles diffèrent. Un segment parent est partagé par plusieurs feuilles. Pour le mettre en forme, utilisez le niveau correspondant du premier point de donnée du groupe. Par exemple, la branche `Consumer` commence avec le point `Laptops`, tandis que le tronc `Software` commence avec le point `Licenses`. Conserver des références à ces points est plus clair et plus sûr que d’utiliser des expressions non expliquées telles que `data_points.get_Item(0)` ou `data_points.get_Item(6)`.

## **Créer et personnaliser les deux types de graphiques**

L’exemple complet suivant crée un Treemap sur la première diapositive et un Sunburst sur la deuxième. Il construit la hiérarchie, affiche la valeur pour `Tablets`, applique des couleurs fixes aux niveaux sélectionnés, met en forme une étiquette de branche, puis enregistre la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Ajouter les catégories feuilles. Un élément de regroupement est défini uniquement lorsqu'un nouveau groupe commence;
        # les catégories suivantes restent dans ce groupe jusqu'à ce qu'un autre élément soit défini.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Afficher la catégorie et la valeur sur la feuille Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Formater la branche Consumer via la première feuille de cette branche.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Formater le tronc Software via la première feuille de ce tronc.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout affecte les étiquettes parent du Treemap ; Sunburst utilise des segments d'anneau.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les cellules de catégorie et les cellules de valeur utilisent la même ligne de feuille de calcul, de sorte que leurs positions de collection restent alignées. Lorsque vous travaillez avec un graphique existant plutôt que d’en créer un, examinez d’abord les lignes de catégorie et stockez des références nommées aux points de donnée et aux niveaux que vous souhaitez mettre en forme.

## **Comportement et considérations pratiques**

### **Différences entre Treemap et Sunburst**

- Un Treemap utilise la surface pour communiquer la valeur et des rectangles imbriqués pour communiquer la hiérarchie. La méthode [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#setParentLabelLayout) contrôle l’apparence des étiquettes parent dans ce type de graphique.
- Un Sunburst utilise l’angle pour communiquer la valeur et la profondeur de l’anneau pour communiquer la hiérarchie. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseries/#setParentLabelLayout) ne contrôle pas les étiquettes de ses anneaux.
- Les deux types de graphiques utilisent les mêmes niveaux de regroupement de catégories et le même ordre feuille‑parent renvoyé par [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), de sorte que le code de construction des données et de mise en forme des niveaux peut être partagé.
- Les valeurs parent sont calculées à partir de leurs feuilles descendantes. N’ajoutez pas de points numériques séparés pour les branches ou les troncs.

### **Tri et ordre des segments**

Le moteur de disposition du graphique détermine le placement final des rectangles et des segments d’anneau. Regroupez les lignes de catégories liées avant de les ajouter, mais ne comptez pas sur une position de rectangle ou un angle de départ spécifiques. Si la séquence porte une signification, incluez‑la dans les étiquettes ou utilisez un type de graphique avec un axe de catégorie explicite.

### **Thème et couleurs fixes**

Les niveaux de graphique non formatés héritent des couleurs du thème de la présentation. L’exemple utilise des remplissages RVB explicites pour obtenir un résultat prévisible. Si le graphique doit suivre les changements de thème, utilisez des couleurs de jeu plutôt que des valeurs RVB fixes et évitez de remplacer chaque niveau. Vérifiez également le contraste des étiquettes après avoir changé le remplissage d’une branche ou d’un tronc.

### **Étiquettes et espace disponible**

PowerPoint peut masquer ou tronquer les étiquettes lorsqu’un segment est trop petit. Augmenter la taille du graphique, raccourcir les noms de catégorie ou afficher moins de champs d’étiquette donne généralement un résultat plus lisible. Une étiquette peut combiner le nom de catégorie, le nom de série et la valeur via [DataLabelFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/), mais activer tous les champs rend souvent les graphiques hiérarchiques difficiles à lire.

### **Exportation et rendu**

Enregistrement au format PPTX conserve le graphique éditable. Lorsque Aspose.Slides rend la présentation en PDF ou en image, les remplissages et paramètres d’étiquette pris en charge sont rendus avec le graphique. La substitution de polices et de petites différences dans l’espace de mise en page disponible peuvent modifier le retour à la ligne ou la visibilité des étiquettes, donc installez les polices requises et vérifiez les cibles d’exportation importantes.

## **FAQ**

**Pourquoi la modification d’un niveau parent affecte‑t‑elle plusieurs feuilles ?**

Une branche ou un tronc est un segment visuel partagé. Son [ChartDataPointLevel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdatapointlevel/) est accessible via une feuille descendante, mais la mise en forme appartient au segment parent partagé plutôt qu’à cette seule feuille.

**Pourquoi une étiquette de donnée est‑elle absente ?**

Activez d’abord les champs requis sur l’objet [DataLabelFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datalabelformat/) de l’étiquette. Vérifiez ensuite que le segment dispose de suffisamment d’espace. La disposition des étiquettes parent du Treemap, les dimensions du graphique, la longueur de l’étiquette, la taille de police et le nombre de champs activés influencent tous la possibilité d’afficher une étiquette.

**Puis‑je définir l’ordre exact ou les coordonnées des segments ?**

Vous pouvez contrôler l’ordre des lignes source et garder chaque groupe contigu, mais vous ne pouvez pas assigner des rectangles Treemap ou des angles Sunburst exacts. Le moteur de disposition du graphique les calcule à partir de la hiérarchie, des valeurs et de l’espace disponible.

**Pourquoi les couleurs changent‑elles après une modification du thème de la présentation ?**

Les remplissages basés sur le thème sont conçus pour suivre la palette de la présentation. Appliquez des couleurs RVB explicites aux niveaux qui doivent rester fixes, ou conservez les couleurs de jeu lorsque l’adaptation à un nouveau thème est privilégiée.

**Les formats personnalisés seront‑ils conservés lors des exportations PDF et image ?**

Oui, les remplissages de graphique et les paramètres d’étiquette pris en charge sont inclus lors du rendu. Pour des résultats cohérents entre systèmes, rendez les polices requises disponibles et testez la taille d’export final, car l’ajustement des étiquettes dépend de la mise en page.

## **Voir aussi**

- [Create Treemap charts](/slides/fr/python-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/fr/python-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/fr/python-java/export-chart/)
- [Manage presentation themes](/slides/fr/python-java/presentation-theme/)