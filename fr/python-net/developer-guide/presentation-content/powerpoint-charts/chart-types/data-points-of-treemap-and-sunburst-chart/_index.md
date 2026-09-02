---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst en Python
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- graphique treemap
- graphique sunburst
- graphique hiérarchique
- point de données
- étiquette de données
- couleur de branche
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez à créer des données hiérarchiques et à personnaliser les niveaux, les libellés et les couleurs dans les graphiques Treemap et Sunburst avec Aspose.Slides pour Python via .NET."
---
## **Aperçu**

Les graphiques Treemap et Sunburst affichent le même type de données hiérarchiques, mais ils utilisent des dispositions différentes. Un Treemap représente la hiérarchie sous forme de rectangles imbriqués dont les zones représentent les valeurs des feuilles. Un Sunburst la représente sous forme d'anneaux concentriques : les groupes de niveau supérieur sont proches du centre, et les catégories feuilles sont sur l'anneau extérieur.

Dans Aspose.Slides pour Python via .NET, chaque valeur numérique est un [ChartDataPoint](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapoint/). Sa collection [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) fournit l'accès à la feuille et à ses groupes parents. Cet article explique ce mappage et montre comment créer et formater les deux types de graphiques à partir des mêmes données d'exemple.

![Un graphique Treemap avec les branches Consumer et Business](treemap-hierarchy.png)

![Un graphique Sunburst avec la même hiérarchie Consumer et Business](sunburst-hierarchy.png)

## **Comprendre les catégories, les points de données et les niveaux**

L'exemple utilisé ci‑dessous comporte trois niveaux de catégories et une série numérique :

| Branche | Tronc | Feuille | Chiffre d'affaires |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Chaque ligne crée une catégorie feuille et un point de données. Les niveaux de regroupement de catégorie décrivent le chemin de cette feuille jusqu'à ses parents. Pour la première ligne, le chemin est `Consumer > Computers > Laptops`.

Les index dans [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) partent de la feuille vers le haut :

| index `data_point_levels` | Niveau logique | Représentation Treemap | Représentation Sunburst |
| ---: | --- | --- | --- |
| `0` | Feuille | Rectangle de valeur | Segment anneau extérieur |
| `1` | Tronc | Rectangle ou en‑tête parent | Segment anneau intermédiaire |
| `2` | Branche | Rectangle ou en‑tête de niveau supérieur | Segment anneau interne |

Cet ordre est le même pour les deux types de graphiques, même si leurs dispositions visuelles diffèrent. Un segment parent est partagé par plusieurs feuilles. Pour le formater, utilisez le niveau correspondant du premier point de données de ce groupe. Par exemple, la branche `Consumer` débute avec le point `Laptops`, tandis que le tronc `Software` débute avec le point `Licenses`. Conserver des références à ces points est plus clair et plus sûr que d'utiliser des expressions non expliquées telles que `data_points[0]` ou `data_points[6]`.

## **Créer et personnaliser les deux types de graphiques**

L'exemple complet suivant crée un Treemap sur la première diapositive et un Sunburst sur la deuxième diapositive. Il construit la hiérarchie, affiche la valeur pour `Tablets`, applique des couleurs fixes aux niveaux sélectionnés, formate une étiquette de branche et enregistre la présentation.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Ajoutez les catégories feuilles. Un élément de regroupement est défini uniquement lorsqu'un nouveau groupe commence ;
    # les catégories suivantes restent dans ce groupe jusqu'à ce qu'un autre élément soit défini.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Affichez la catégorie et la valeur sur la feuille Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Formatez la branche Consumer via la première feuille de cette branche.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Formatez le tronc Software via la première feuille de ce tronc.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout affecte les libellés parents du Treemap ; Sunburst utilise des segments d'anneau.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

Les cellules de catégorie et les cellules de valeur utilisent la même ligne de feuille de calcul, de sorte que leurs positions de collection restent alignées. Lorsque vous travaillez avec un graphique existant plutôt que d'en créer un, inspectez d'abord les lignes de catégorie et stockez des références nommées aux points de données et aux niveaux que vous prévoyez de formater.

## **Comportement et considérations pratiques**

### **Différences entre Treemap et Sunburst**

- Un Treemap utilise la surface pour communiquer la valeur et des rectangles imbriqués pour communiquer la hiérarchie. La propriété [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/parent_label_layout/) contrôle l'apparence des libellés parents dans ce type de graphique.
- Un Sunburst utilise l'angle pour communiquer la valeur et la profondeur des anneaux pour communiquer la hiérarchie. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartseries/parent_label_layout/) ne contrôle pas les libellés des anneaux.
- Les deux types de graphiques utilisent les mêmes niveaux de regroupement de catégorie et le même ordre feuille‑vers‑parent dans `data_point_levels`, de sorte que le code de création de données et de formatage des niveaux peut être partagé.
- Les valeurs des parents sont calculées à partir de leurs feuilles descendantes. N'ajoutez pas de points numériques séparés pour les branches ou les troncs.

### **Tri et ordre des segments**

Le moteur de mise en page du graphique détermine le placement final des rectangles et des segments d'anneau. Regroupez les lignes de catégorie connexes avant de les ajouter, mais ne comptez pas sur une position de rectangle ou un angle de départ spécifiques. Si la séquence porte une signification, intégrez‑la dans les libellés ou utilisez un type de graphique avec un axe de catégorie explicite.

### **Thème et couleurs fixes**

Les niveaux de graphique non formatés héritent des couleurs du thème de la présentation. L'exemple utilise des remplissages RVB explicites pour un résultat prévisible. Si le graphique doit suivre les changements de thème, utilisez les couleurs du schéma au lieu de valeurs RVB fixes et évitez de remplacer chaque niveau. Vérifiez également le contraste des libellés après avoir modifié le remplissage d'une branche ou d'un tronc.

### **Étiquettes et espace disponible**

PowerPoint peut masquer ou tronquer les libellés lorsqu'un segment est trop petit. Augmenter la taille du graphique, raccourcir les noms de catégorie ou afficher moins de champs de libellé produit généralement un résultat plus lisible. Une étiquette peut combiner le nom de catégorie, le nom de série et la valeur via [DataLabelFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabelformat/), mais activer tous les champs rend souvent les graphiques hiérarchiques difficiles à lire.

### **Exportation et rendu**

Enregistrer au format PPTX conserve le graphique éditable. Lorsque Aspose.Slides rend la présentation en PDF ou en image, les remplissages et les paramètres de libellé pris en charge sont rendus avec le graphique. La substitution de polices et les petites différences d'espace de mise en page peuvent modifier le retour à la ligne ou la visibilité des libellés, il faut donc installer les polices requises et vérifier les cibles d'exportation importantes.

## **FAQ**

**Pourquoi la modification d'un niveau parent affecte-t-elle plusieurs feuilles ?**

Une branche ou un tronc est un segment visuel partagé. Son [ChartDataPointLevel](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdatapointlevel/) peut être atteint via une feuille descendante, mais le formatage appartient au segment parent partagé et non uniquement à cette feuille.

**Pourquoi une étiquette de données est-elle manquante ?**

Activez d'abord les champs requis sur l'objet [DataLabelFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/datalabelformat/) de l'étiquette. Vérifiez ensuite que le segment dispose de suffisamment d'espace. La disposition des libellés parents du Treemap, les dimensions du graphique, la longueur des libellés, la taille de police et le nombre de champs activés influencent tous la possibilité d'afficher une étiquette.

**Puis-je définir l'ordre exact ou les coordonnées des segments ?**

Vous pouvez contrôler l'ordre des lignes sources et garder chaque groupe contigu, mais vous ne pouvez pas assigner des rectangles Treemap ou des angles Sunburst précis. Le moteur de mise en page du graphique les calcule à partir de la hiérarchie, des valeurs et de l'espace disponible.

**Pourquoi les couleurs changent-elles après la modification du thème de la présentation ?**

Les remplissages basés sur le thème sont conçus pour suivre la palette de la présentation. Appliquez des couleurs RVB explicites aux niveaux qui doivent rester fixes, ou conservez les couleurs du schéma lorsque l'adaptation à un nouveau thème est souhaitée.

**Le formatage personnalisé sera-t-il conservé lors des exportations PDF et image ?**

Oui, les remplissages de graphique et les paramètres de libellé pris en charge sont inclus lors du rendu. Pour des résultats cohérents sur tous les systèmes, rendez les polices requises disponibles et testez la taille d'exportation finale, car l'ajustement des libellés dépend de la mise en page.

## **Voir aussi**

- [Créer des graphiques Treemap](/slides/fr/python-net/create-chart/#create-tree-map-charts)
- [Créer des graphiques Sunburst](/slides/fr/python-net/create-chart/#create-sunburst-charts)
- [Exporter les graphiques de présentation](/slides/fr/python-net/export-chart/)
- [Gérer les thèmes de présentation](/slides/fr/python-net/presentation-theme/)