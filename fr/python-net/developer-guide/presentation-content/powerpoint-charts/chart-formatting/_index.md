---
title: Formater les graphiques dans les présentations avec Python
linktitle: Mise en forme des graphiques
type: docs
weight: 60
url: /fr/python-net/chart-formatting/
keywords:
- format de graphique
- mise en forme du graphique
- entité du graphique
- propriétés du graphique
- paramètres du graphique
- options du graphique
- propriétés de police
- bord arrondi
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez la mise en forme des graphiques dans Aspose.Slides pour Python via .NET et améliorez votre présentation PowerPoint ou OpenDocument avec un style professionnel et accrocheur."
---

## **Vue d'ensemble**

Ce guide montre comment formater les graphiques PowerPoint à l’aide d’Aspose.Slides pour Python. Il explique la personnalisation des entités essentielles du graphique — telles que les axes des catégories et des valeurs, les quadrillages, les étiquettes, les titres, les légendes et les axes secondaires — et montre comment contrôler les polices, les formats numériques, les remplissages, les contours, les couleurs de la zone de tracé et du mur arrière, ainsi que les coins arrondis du graphique grâce à des extraits de code concis et exécutables. En suivant les exemples pas à pas, vous créerez une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), ajouterez et configurerez un graphique, et enregistrerez le résultat au format PPTX tout en appliquant des paramètres visuels et typographiques précis.

## **Formater les éléments du graphique**

Aspose.Slides for Python permet aux développeurs d’ajouter des graphiques personnalisés à leurs diapositives depuis zéro. Cette section explique comment formater divers éléments du graphique, y compris les axes des catégories et des valeurs.

Aspose.Slides fournit une API simple pour gérer les éléments du graphique et appliquer un formatage personnalisé :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut du type souhaité (dans cet exemple, `ChartType.LINE_WITH_MARKERS`).
1. Accédez à l’axe des valeurs du graphique et définissez :
   1. Le **format de ligne** pour les quadrillages majeurs de l’axe des valeurs.
   1. Le **format de ligne** pour les quadrillages mineurs de l’axe des valeurs.
   1. Le **format numérique** pour l’axe des valeurs.
   1. Les **unités min, max, majeures et mineures** pour l’axe des valeurs.
   1. Les **propriétés de texte** pour les étiquettes de l’axe des valeurs.
   1. Le **titre** de l’axe des valeurs.
   1. Le **format de ligne** de l’axe des valeurs.
1. Accédez à l’axe des catégories du graphique et définissez :
   1. Le **format de ligne** pour les quadrillages majeurs de l’axe des catégories.
   1. Le **format de ligne** pour les quadrillages mineurs de l’axe des catégories.
   1. Les **propriétés de texte** pour les étiquettes de l’axe des catégories.
   1. Le **titre** de l’axe des catégories.
   1. Le **positionnement des étiquettes** de l’axe des catégories.
   1. L’**angle de rotation** des étiquettes de l’axe des catégories.
1. Accédez à la légende du graphique et définissez ses **propriétés de texte**.
1. Affichez la légende du graphique sans chevaucher le graphique.
1. Accédez à l’**axe secondaire des valeurs** du graphique et définissez :
   1. Activez l’axe secondaire des **valeurs**.
   1. Le **format de ligne** pour l’axe secondaire des valeurs.
   1. Le **format numérique** pour l’axe secondaire des valeurs.
   1. Les **unités min, max, majeures et mineures** pour l’axe secondaire des valeurs.
1. Tracez la première série du graphique sur l’axe secondaire des valeurs.
1. Définissez la couleur de remplissage du mur arrière du graphique.
1. Définissez la couleur de remplissage de la zone de tracé du graphique.
1. Enregistrez la présentation modifiée dans un fichier PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation.
with slides.Presentation() as presentation:

    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Ajouter un graphique d’exemple.
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Définir le titre du graphique.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = 1
    chart_title.portion_format.font_italic = 1

    # Définir le format du quadrillage majeur pour l’axe des valeurs.
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Définir le format du quadrillage mineur pour l’axe des valeurs.
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Définir le format numérique de l’axe des valeurs.
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Définir les valeurs maximale, minimale, l’unité majeure et mineure de l’axe des valeurs.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Définir les propriétés de texte de l’axe des valeurs.
    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = 1
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = 1
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    vertical_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    # Définir le titre de l’axe des valeurs.
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = 1
    vertical_axis_title.portion_format.font_italic = 1

    # Définir le format du quadrillage majeur pour l’axe des catégories.
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Définir le format du quadrillage mineur pour l’axe des catégories.
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Définir les propriétés de texte de l’axe des catégories.
    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = 1
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = 1
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = draw.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    # Définir le titre de l’axe des catégories.
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = 1
    horizontal_axis_title.portion_format.font_italic = 1

    # Définir la position des étiquettes de l’axe des catégories.
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Définir l’angle de rotation des étiquettes de l’axe des catégories.
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Définir les propriétés de texte de la légende.
    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = 1
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = 1
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID 
    legend_portion_format.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Afficher la légende du graphique chevauchant le graphique.
    chart.legend.overlay = True
                
    # Définir la couleur du mur arrière du graphique.
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red

    # Définir la couleur de la zone de tracé.
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Enregistrer la présentation.
    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir les propriétés de police du graphique**

Aspose.Slides for Python prend en charge la définition des propriétés liées à la police pour les graphiques. Suivez les étapes ci‑dessous pour configurer les propriétés de police du graphique :

1. Instanciez un objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ajoutez un graphique à la diapositive.
1. Définissez la hauteur de la police.
1. Enregistrez la présentation modifiée.

Un exemple de code est fourni ci‑dessous.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir le format numérique**

Aspose.Slides for Python fournit une API simple pour gérer les formats de données des graphiques :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par son indice.
1. Ajoutez un graphique avec des données par défaut du type souhaité.
1. Appliquez un format numérique prédéfini parmi les valeurs disponibles.
1. Parcourez les cellules de données du graphique dans chaque série et définissez le format numérique.
1. Enregistrez la présentation.
1. Appliquez un format numérique personnalisé.
1. Parcourez les cellules de données du graphique dans chaque série et définissez un format différent.
1. Enregistrez la présentation.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instancier la classe Presentation.
with slides.Presentation() as presentation:
    # Accéder à la première diapositive.
    slide = presentation.slides[0]

    # Ajouter un graphique en colonnes groupées par défaut.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Appliquer le format numérique prédéfini.
    # Parcourir chaque série du graphique.
    for series in chart.chart_data.series:
        # Parcourir chaque point de données de la série.
        for cell in series.data_points:
            # Définir le format numérique.
            cell.value.as_cell.preset_number_format = 10  # 0.00%

    # Enregistrer la présentation.
    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Les formats numériques prédéfinis disponibles et leurs indices correspondants sont répertoriés ci‑dessous.

|**0**|Général|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/j/aa|
|**15**|j-mmm-aa|
|**16**|j-mmm|
|**17**|mmm-aa|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/j/aa h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Définir des bordures arrondies pour la zone du graphique**

Aspose.Slides for Python prend en charge la configuration de la zone du graphique à l’aide de la propriété `Chart.has_rounded_corners`.

1. Instanciez un objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Ajoutez un graphique à la diapositive.
3. Définissez le type de remplissage et la couleur de remplissage du graphique.
4. Activez la propriété des coins arrondis en la réglant sur `True`.
5. Enregistrez la présentation modifiée.

Un exemple est fourni ci‑dessous.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis‑je définir des remplissages semi‑transparents pour les colonnes/aires tout en conservant le bord opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les étiquettes de données lorsqu’elles se chevauchent ?**

Réduisez la taille de la police, désactivez les composants d’étiquette non essentiels (par exemple, les catégories), ajustez le décalage/position de l’étiquette, affichez les étiquettes uniquement pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages dégradés ou à motifs aux séries ?**

Oui. Les remplissages solides et dégradés/motifs sont généralement disponibles. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.