---
title: Mise en forme des graphiques dans les présentations avec Python
linktitle: Formatage des graphiques
type: docs
weight: 60
url: /fr/python-net/chart-formatting/
keywords:
- format de graphique
- formatage de graphique
- entité de graphique
- propriétés du graphique
- paramètres du graphique
- options du graphique
- propriétés de police
- bordure arrondie
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez le formatage des graphiques dans Aspose.Slides pour Python via .NET et améliorez votre présentation PowerPoint avec des axes personnalisés, des polices, des formats numériques et des bordures de graphique arrondies."
---
## **Aperçu**

Cet article explique comment formater les graphiques dans les présentations PowerPoint en utilisant Aspose.Slides. Il montre comment personnaliser les éléments clés du graphique tels que les axes, les lignes de grille, les titres, les légendes, la zone de tracé et les remplissages des murs afin d'améliorer l'apparence et la lisibilité des données du graphique.

Il montre également comment définir les propriétés de police pour le texte du graphique, appliquer des formats numériques prédéfinis aux données du graphique et activer les coins arrondis pour la zone du graphique. Ensemble, ces exemples montrent comment contrôler à la fois le style visuel et la présentation des données des graphiques dans une présentation.

Pour des remplissages et des bordures distincts sur les intervalles croissants et décroissants, voir l'[exemple de graphique boursier](/slides/fr/python-net/create-chart/#create-stock-charts).

## **Formater les entités du graphique**

Utilisez [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) pour formater les titres du graphique, les axes, les lignes de grille, les légendes et la zone de tracé.  
Cet exemple crée un graphique en courbes avec des repères et des données par défaut, puis applique des styles de texte et de ligne distincts à ses axes de valeurs et de catégories. Les tailles de police et les largeurs de lignes sont spécifiées en points ; les libellés de catégorie sont pivotés de 45 degrés.

L'axe des valeurs utilise [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) indépendamment des cellules source. Son étendue va de -2 à 15, avec des intervalles majeurs de 2 et des intervalles mineurs de 0,5. L'exemple combine également le formatage en pourcentage avec [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) réglé sur les milliers, adaptez donc ces paramètres à la signification et à l'ampleur de vos données. La légende reste à l'extérieur de la zone de tracé parce que [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) est désactivé. Les remplissages du mur arrière et du plancher sont configurés via [back_wall](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/back_wall/) et [floor](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/floor/), mais ces surfaces ne sont visibles que dans les graphiques 3D.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 50, 50, 500, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("")
    chart_title = chart.chart_title.text_frame_for_overriding.paragraphs[0].portions[0]
    chart_title.text = "Sample Chart"
    chart_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    chart_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart_title.portion_format.font_height = 20
    chart_title.portion_format.font_bold = slides.NullableBool.TRUE
    chart_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.blue
    chart.axes.vertical_axis.major_grid_lines_format.line.width = 5
    chart.axes.vertical_axis.major_grid_lines_format.line.dash_style = slides.LineDashStyle.DASH_DOT

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.red
    chart.axes.vertical_axis.minor_grid_lines_format.line.width = 3

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.THOUSANDS
    chart.axes.vertical_axis.number_format = "0.0%"

    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.is_automatic_minor_unit = False
    chart.axes.vertical_axis.is_automatic_min_value = False

    chart.axes.vertical_axis.max_value = 15
    chart.axes.vertical_axis.min_value = -2
    chart.axes.vertical_axis.minor_unit = 0.5
    chart.axes.vertical_axis.major_unit = 2.0

    vertical_axis_portion_format = chart.axes.vertical_axis.text_format.portion_format
    vertical_axis_portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_portion_format.font_height = 16
    vertical_axis_portion_format.font_italic = slides.NullableBool.TRUE
    vertical_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_green
    vertical_axis_portion_format.latin_font = slides.FontData("Times New Roman")

    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("")
    vertical_axis_title = chart.axes.vertical_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    vertical_axis_title.text = "Primary Axis"
    vertical_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    vertical_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    vertical_axis_title.portion_format.font_height = 20
    vertical_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    vertical_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.green
    chart.axes.horizontal_axis.major_grid_lines_format.line.width = 5

    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.SOLID
    chart.axes.horizontal_axis.minor_grid_lines_format.line.fill_format.solid_fill_color.color = slides.Color.yellow
    chart.axes.horizontal_axis.minor_grid_lines_format.line.width = 3

    horizontal_axis_portion_format = chart.axes.horizontal_axis.text_format.portion_format
    horizontal_axis_portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_portion_format.font_height = 16
    horizontal_axis_portion_format.font_italic = slides.NullableBool.TRUE
    horizontal_axis_portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_portion_format.fill_format.solid_fill_color.color = slides.Color.blue
    horizontal_axis_portion_format.latin_font = slides.FontData("Arial")

    chart.axes.horizontal_axis.has_title = True
    chart.axes.horizontal_axis.title.add_text_frame_for_overriding("")

    horizontal_axis_title = chart.axes.horizontal_axis.title.text_frame_for_overriding.paragraphs[0].portions[0]
    horizontal_axis_title.text = "Sample Category"
    horizontal_axis_title.portion_format.fill_format.fill_type = slides.FillType.SOLID
    horizontal_axis_title.portion_format.fill_format.solid_fill_color.color = slides.Color.gray
    horizontal_axis_title.portion_format.font_height = 20
    horizontal_axis_title.portion_format.font_bold = slides.NullableBool.TRUE
    horizontal_axis_title.portion_format.font_italic = slides.NullableBool.TRUE

    chart.axes.horizontal_axis.tick_label_position = charts.TickLabelPositionType.LOW

    chart.axes.horizontal_axis.tick_label_rotation_angle = 45

    legend_portion_format = chart.legend.text_format.portion_format
    legend_portion_format.font_bold = slides.NullableBool.TRUE
    legend_portion_format.font_height = 16
    legend_portion_format.font_italic = slides.NullableBool.TRUE
    legend_portion_format.fill_format.fill_type = slides.FillType.SOLID
    legend_portion_format.fill_format.solid_fill_color.color = slides.Color.dark_red

    chart.legend.overlay = False

    chart.back_wall.thickness = 1
    chart.back_wall.format.fill.fill_type = slides.FillType.SOLID
    chart.back_wall.format.fill.solid_fill_color.color = slides.Color.orange

    chart.floor.format.fill.fill_type = slides.FillType.SOLID
    chart.floor.format.fill.solid_fill_color.color = slides.Color.red

    chart.plot_area.format.fill.fill_type = slides.FillType.SOLID
    chart.plot_area.format.fill.solid_fill_color.color = slides.Color.light_cyan

    presentation.save("FormattedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir les propriétés de police pour un graphique**

Définissez la taille de police par défaut pour le texte du graphique via [Chart.text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/text_format/). L'exemple crée un graphique à colonnes groupées avec une police de 20 points et active les étiquettes de valeur pour la première série via [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). Les éléments de texte avec leurs propres paramètres de police explicites peuvent remplacer la valeur par défaut du graphique.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    chart.text_format.portion_format.font_height = 20
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    presentation.save("ChartFontProperties.pptx", slides.export.SaveFormat.PPTX)
```

## **Réutiliser le formatage du cadre de texte pour une légende de graphique**

Pour faire correspondre une légende à l'en-tête d'une diapositive, définissez la police via [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) sur le premier paragraphe de l'en-tête. Appelez [copy_from](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_from/) sur le [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) de la légende. Cela copie les paramètres du cadre de texte, le formatage du premier paragraphe et les propriétés de police par défaut de ce paragraphe. Le formatage appliqué directement aux portions individuelles ou aux paragraphes ultérieurs reste local à la source.

L'exemple utilise un en-tête en gras, bleu marine, Calibri de 26 points comme modèle. Après avoir stylisé la légende, il utilise [copy_to](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttextformat/copy_to/) pour appliquer le même formatage à une légende séparée.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    heading = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 640, 40, False)
    source_text_frame = heading.add_text_frame("Quarterly sales")
    font = source_text_frame.paragraphs[0].paragraph_format.default_portion_format
    font.latin_font = slides.FontData("Calibri")
    font.font_height = 26
    font.font_bold = slides.NullableBool.TRUE
    font.fill_format.fill_type = slides.FillType.SOLID
    font.fill_format.solid_fill_color.color = slides.Color.from_argb(32, 64, 96)

    chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 75, 640, 360)
    chart.style = charts.StyleType.STYLE3
    workbook = chart.chart_data.chart_data_workbook
    for column, name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.get_cell(0, 0, column).value = name
    for quarter in range(1, 5):
        workbook.get_cell(0, quarter, 0).value = f"Q{quarter}"

    chart.has_legend = True
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.copy_from(source_text_frame)

    caption = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 460, 640, 40, False)
    caption_text_frame = caption.add_text_frame("Sales in millions of dollars")
    chart.legend.text_format.copy_to(caption_text_frame)

    presentation.save("legend-formatting.pptx", slides.export.SaveFormat.PPTX)
```

Dans la présentation enregistrée, la légende et la légende correspondante (caption) correspondent à l'en-tête en taille, poids et couleur. La légende affiche toujours les noms des séries, et la légende (caption) conserve son propre texte. Si une portion de la légende possède déjà une taille de police explicite, cette taille prévaut sur la police par défaut du paragraphe copié.

| Avant la copie | Après la copie |
| --- | --- |
| ![Graphique des ventes trimestrielles avec des étiquettes de légende noires normales et une légende noire](legend-formatting-before.png) | ![Le même graphique avec des étiquettes de légende plus grandes, en gras, bleu marine et une légende correspondante](legend-formatting.png) |

## **Définir le format numérique**

Utilisez [ChartDataCell.preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) pour appliquer un format numérique intégré aux cellules du classeur du graphique. Cet exemple crée un graphique à colonnes groupées avec des données par défaut liées aux cellules et applique l’indice de format 10 (`0.00%`) à chaque cellule de valeur de série. Cela modifie la façon dont les valeurs sont affichées dans le classeur sans changer les nombres sous-jacents ; par exemple, 0,25 est affiché comme 25,00 %. Les formats des axes et des étiquettes de données peuvent être configurés séparément.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 400)

    for series in chart.chart_data.series:
        for data_point in series.data_points:
            data_point.value.as_cell.preset_number_format = 10  # 0.00%

    presentation.save("PresetNumberFormat.pptx", slides.export.SaveFormat.PPTX)
```

Le tableau suivant répertorie les indices de formats numériques intégrés avec des formats Excel représentatifs pour la locale anglais (États‑Unis). Les chaînes de format exactes et leur affichage peuvent varier selon l’application et la locale, notamment pour les devises et les dates. Certains formats Excel diffèrent également des valeurs par défaut du standard OOXML, comme décrit dans les [notes d’implémentation du format numérique de Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indice | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Définir les bordures arrondies de la zone du graphique**

Activez [Chart.has_rounded_corners](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_rounded_corners/) pour arrondir les coins de la zone du graphique. L'exemple crée un graphique à colonnes groupées et utilise [line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) pour donner à son contour une couleur gris solide et un style à ligne unique avant d’enregistrer la présentation.

```python
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.line_format.fill_format.fill_type = slides.FillType.SOLID
    chart.line_format.fill_format.solid_fill_color.color = slides.Color.gray
    chart.line_format.style = slides.LineStyle.SINGLE
    chart.has_rounded_corners = True

    presentation.save("RoundedBorders.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifier les annotations de graphique existantes**

Un graphique peut contenir des formes personnalisées, comme une annotation texte expliquant l'état d'un rapport. Accédez à ces formes via [Chart.user_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/user_shapes/). Sa collection [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) contient les formes appartenant au graphique.

Une zone de texte ordinaire placée au-dessus d'un graphique appartient à la diapositive, même si elle ressemble à une partie du graphique. Parcourir [Slide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/) trouve le graphique et les formes ordinaires de la diapositive, mais n'énumère pas les formes individuelles à l'intérieur du graphique. Les titres de graphique et les étiquettes de données sont des éléments de graphique distincts, pas des annotations personnalisées dans cette collection.

Téléchargez [chart-annotations.pptx](chart-annotations.pptx) et placez‑le dans le répertoire de travail de l'application. Sa première diapositive contient un graphique avec une annotation non groupée affichant « Preliminary results », une ligne appartenant au graphique et une zone de texte ordinaire affichant « Slide overlay ». L'exemple trouve le premier graphique de cette diapositive et change l'annotation en « Final results » lorsque le rapport est prêt à être publié. Il vérifie qu’il ne s’agit pas d’une collection vide et ne modifie qu’un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) dont le [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/) n’est pas `None` et contient le texte attendu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-annotations.pptx") as presentation:
    slide = presentation.slides[0]
    chart = next((shape for shape in slide.shapes if isinstance(shape, charts.Chart)), None)

    if chart is None or len(chart.user_shapes.shapes) == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.user_shapes.shapes:
            if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
                if shape.text_frame.text == "Preliminary results":
                    shape.text_frame.text = "Final results"
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("No matching text annotation found.")
```

La ligne et la zone de texte de la diapositive restent inchangées. Les images suivantes montrent l’entrée et le résultat enregistré, puis rouvert :

| Avant la modification | Après la modification |
| --- | --- |
| ![Annotation du graphique affichant Résultats préliminaires](chart-annotations-before.png) | ![Annotation du graphique affichant Résultats finaux](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
L'exemple n'inspecte que les formes appartenant directement au graphique de premier niveau. Si une annotation se trouve à l'intérieur d'un [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), inspectez également la collection [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) de ce groupe. Répétez cette opération de manière récursive pour les groupes imbriqués, en appliquant les mêmes vérifications de texte à leurs formes enfants. Un groupe lui‑même est un conteneur ; ne le traitez pas comme une zone de texte.
{{% /alert %}}

## **FAQ**

**Puis-je définir des remplissages semi-transparents pour les colonnes/zones tout en gardant la bordure opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les étiquettes de données lorsqu'elles se chevauchent ?**

Réduisez la taille de la police, désactivez les composants d'étiquette non essentiels (par exemple, les catégories), ajustez la position de l'étiquette, affichez les étiquettes uniquement pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis-je appliquer des remplissages en dégradé ou à motifs aux séries ?**

Oui. Les séries supportent les remplissages solides, en dégradé et à motifs. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.