---
title: Formatage de Diagrammes
type: docs
weight: 60
url: /fr/python-net/chart-formatting/
keywords: "Entités de diagramme, propriétés de diagramme, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Formater les entités de diagrammes dans des présentations PowerPoint en Python"
---

## **Formater les Entités de Diagrammes**
Aspose.Slides pour Python via .NET permet aux développeurs d'ajouter des diagrammes personnalisés à leurs diapositives depuis zéro. Cet article explique comment formater différentes entités de diagrammes, y compris l'axe des catégories et l'axe des valeurs.

Aspose.Slides pour Python via .NET fournit une API simple pour gérer différentes entités de diagrammes et les formater à l'aide de valeurs personnalisées :

1. Créez une instance de la classe **Presentation**.
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un diagramme avec des données par défaut ainsi que le type souhaité (dans cet exemple, nous utiliserons ChartType.LineWithMarkers).
1. Accédez à l'axe des valeurs du diagramme et définissez les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de grille majeures de l'axe des valeurs
   1. Définir le **format de ligne** pour les lignes de grille mineures de l'axe des valeurs
   1. Définir le **format de nombre** pour l'axe des valeurs
   1. Définir les **unités Min, Max, Majors et Mineurs** pour l'axe des valeurs
   1. Définir les **propriétés de texte** pour les données de l'axe des valeurs
   1. Définir le **titre** pour l'axe des valeurs
   1. Définir le **format de ligne** pour l'axe des valeurs
1. Accédez à l'axe des catégories du diagramme et définissez les propriétés suivantes :
   1. Définir le **format de ligne** pour les lignes de grille majeures de l'axe des catégories
   1. Définir le **format de ligne** pour les lignes de grille mineures de l'axe des catégories
   1. Définir les **propriétés de texte** pour les données de l'axe des catégories
   1. Définir le **titre** pour l'axe des catégories
   1. Définir le **positionnement des étiquettes** pour l'axe des catégories
   1. Définir l'**angle de rotation** pour les étiquettes de l'axe des catégories
1. Accédez à la légende du diagramme et définissez les **propriétés de texte** pour elles
1. Affichez les légendes du diagramme sans chevauchement avec le diagramme
1. Accédez à l'**axe des valeurs secondaires** du diagramme et définissez les propriétés suivantes :
   1. Activez l'**axe des valeurs secondaires**
   1. Définir le **format de ligne** pour l'axe des valeurs secondaires
   1. Définir le **format de nombre** pour l'axe des valeurs secondaires
   1. Définir les **unités Min, Max, Majors et Mineurs** pour l'axe des valeurs secondaires
1. Maintenant, tracez la première série de diagramme sur l'axe des valeurs secondaires
1. Définir la couleur de remplissage du mur arrière du diagramme
1. Définir la couleur de remplissage de la zone de tracé du diagramme
1. Écrire la présentation modifiée dans un fichier PPTX

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciation de la présentation
with slides.Presentation() as pres:

    # Accéder à la première diapositive
    slide = pres.slides[0]

    # Ajouter le diagramme d'exemple
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    # Définir le titre du diagramme
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chartTitle = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chartTitle.text = "Diagramme d'Exemple"
    chartTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chartTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    chartTitle.portion_format.font_height = 20
    chartTitle.portion_format.font_bold = 1
    chartTitle.portion_format.font_italic = 1

    # Définir le format des lignes de grille majeures pour l'axe des valeurs
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    # Définir le format des lignes de grille mineures pour l'axe des valeurs
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    # Définir le format de nombre pour l'axe des valeurs
    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    # Définir les valeurs maximales et minimales du diagramme
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    # Définir les propriétés de texte de l'axe des valeurs
    txtVal = chart.axes.vertical_axis.text_format.portion_format
    txtVal.font_bold = 1
    txtVal.font_height = 16
    txtVal.font_italic = 1
    txtVal.fill_format.fill_type = slides.FillType.SOLID 
    txtVal.fill_format.solid_fill_color.color = draw.Color.dark_green
    txtVal.latin_font = slides.FontData("Times New Roman")

    # Définir le titre de l'axe des valeurs
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    valtitle = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    valtitle.text = "Axe Principal"
    valtitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    valtitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    valtitle.portion_format.font_height = 20
    valtitle.portion_format.font_bold = 1
    valtitle.portion_format.font_italic = 1

    # Définir le format des lignes de grille majeures pour l'axe des catégories
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    # Définir le format des lignes de grille mineures pour l'axe des catégories
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = draw.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    # Définir les propriétés de texte de l'axe des catégories
    txtCat = chart.axes.horizontal_axis.text_format.portion_format
    txtCat.font_bold = 1
    txtCat.font_height = 16
    txtCat.font_italic = 1
    txtCat.fill_format.fill_type = slides.FillType.SOLID 
    txtCat.fill_format.solid_fill_color.color = draw.Color.blue
    txtCat.latin_font = slides.FontData("Arial")

    # Définir le titre de la catégorie
    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    catTitle = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    catTitle.text = "Catégorie d'Exemple"
    catTitle.portion_format.fill_format.fill_type = slides.FillType.SOLID
    catTitle.portion_format.fill_format.solid_fill_color.color = draw.Color.gray
    catTitle.portion_format.font_height = 20
    catTitle.portion_format.font_bold = 1
    catTitle.portion_format.font_italic = 1

    # Définir la position des étiquettes de l'axe des catégories
    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    # Définir l'angle de rotation des étiquettes de l'axe des catégories
    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    # Définir les propriétés de texte des légendes
    txtleg = chart.legend.text_format.portion_format
    txtleg.font_bold = 1
    txtleg.font_height = 16
    txtleg.font_italic = 1
    txtleg.fill_format.fill_type = slides.FillType.SOLID 
    txtleg.fill_format.solid_fill_color.color = draw.Color.dark_red

    # Afficher les légendes du diagramme sans chevauchement avec le diagramme

    chart.legend.overlay = True
                
    # Définir la couleur du mur arrière du diagramme
    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = draw.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = draw.Color.red
    # Définir la couleur de la zone de tracé
    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = draw.Color.light_cyan

    # Sauvegarder la présentation
    pres.save("FormattedChart_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Définir les Propriétés de Police pour le Diagramme**
Aspose.Slides pour Python via .NET permet de définir les propriétés liées à la police pour le diagramme. Veuillez suivre les étapes ci-dessous pour définir les propriétés de police pour le diagramme.

- Instancier l'objet de la classe Presentation.
- Ajouter un diagramme sur la diapositive.
- Définir la hauteur de la police.
- Sauvegarder la présentation modifiée.

Un exemple d'échantillon est donné ci-dessous.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    pres.save("FontPropertiesForChart.pptx", slides.export.SaveFormat.PPTX)
```




## **Définir le Format des Nombres**
Aspose.Slides pour Python via .NET fournit une API simple pour gérer le format des données de diagramme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive par son index.
1. Ajoutez un diagramme avec des données par défaut ainsi que le type souhaité (cet exemple utilise **ChartType.ClusteredColumn**).
1. Définissez le format de nombre prédéfini à partir des valeurs prédéfinies possibles.
1. Parcourez la cellule de données du diagramme dans chaque série de diagramme et définissez le format de nombre des données du diagramme.
1. Sauvegardez la présentation.
1. Définissez le format de nombre personnalisé.
1. Parcourez la cellule de données du diagramme à l'intérieur de chaque série de diagrammes et définissez un format de nombre différent pour les données du diagramme.
1. Sauvegardez la présentation.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Instancier la présentation
with slides.Presentation() as pres:
    # Accéder à la première diapositive de la présentation
    slide = pres.slides[0]

    # Ajouter un diagramme à colonnes groupées par défaut
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    # Accéder à la collection de séries du diagramme
    series = chart.chart_data.series

    # Définir le format de nombre prédéfini
    # Parcourez chaque série de diagramme
    for ser in series:
        # Parcourez chaque cellule de données dans la série
        for cell in ser.data_points:
            # Définir le format de nombre
            cell.value.as_cell.preset_number_format = 10 #0.00%

    # Sauvegarder la présentation
    pres.save("PresetNumberFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

Les valeurs possibles du format de nombre prédéfini avec leur index prédéfini qui peuvent être utilisées sont données ci-dessous :

|**0**|Général|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rouge$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rouge$-#,##0.00|
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
|**38**|#,##0;Rouge-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rouge-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **Définir les Bords Arrondis de la Zone de Diagramme**
Aspose.Slides pour Python via .NET prend en charge la définition de la zone de diagramme. Les propriétés **IChart.HasRoundedCorners** et **Chart.HasRoundedCorners** ont été ajoutées dans Aspose.Slides. 

1. Instancier un objet de la classe `Presentation`.
1. Ajouter un diagramme sur la diapositive.
1. Définir le type de remplissage et la couleur de remplissage du diagramme.
1. Définir la propriété de coin arrondi sur Vrai.
1. Sauvegarder la présentation modifiée.

 Un exemple d'échantillon est donné ci-dessous. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
	chart.line_format.fill_format.fill_type = slides.FillType.SOLID
	chart.line_format.style = slides.LineStyle.SINGLE
	chart.has_rounded_corners = True

	presentation.save("out.pptx", slides.export.SaveFormat.PPTX)
```