---
title: Formatage des graphiques de présentation en Python
linktitle: Mise en forme des graphiques
type: docs
weight: 60
url: /fr/python-java/chart-formatting/
keywords:
- format de graphique
- mise en forme de graphique
- entité de graphique
- propriétés du graphique
- paramètres du graphique
- options du graphique
- propriétés de police
- bord arrondi
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Apprenez le formatage des graphiques dans Aspose.Slides pour Python via Java et améliorez votre présentation PowerPoint avec des axes personnalisés, des polices, des formats numériques et des bordures de graphique arrondies."
---
## **Vue d'ensemble**

Cet article explique comment mettre en forme les graphiques dans les présentations PowerPoint en utilisant Aspose.Slides. Il montre comment personnaliser les éléments clés du graphique tels que les axes, les lignes de grille, les titres, les légendes, la zone de traçage et les remplissages des murs afin d'améliorer l'apparence et la lisibilité des données du graphique.

Il démontre également comment définir les propriétés de police pour le texte du graphique, appliquer des formats numériques prédéfinis aux données du graphique et activer les coins arrondis pour la zone du graphique. Ensemble, ces exemples montrent comment contrôler à la fois le style visuel et la présentation des données des graphiques dans une présentation.

Pour des remplissages et des contours séparés sur les intervalles haussiers et baissiers, voir l'[exemple de graphique boursier](/slides/fr/python-java/create-chart/#create-stock-charts).

## **Formater les entités du graphique**

Utilisez [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) pour formater les titres de graphique, les axes, les lignes de grille, les légendes et la zone de traçage. Cet exemple crée un graphique linéaire avec marqueurs et données par défaut, puis applique des styles de texte et de ligne distincts à ses axes de valeur et de catégorie. Les tailles de police et les épaisseurs de ligne sont spécifiées en points ; les libellés de catégorie sont tournés de 45 degrés.

L'axe de valeur utilise [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) indépendamment des cellules source. Son échelle va de -2 à 15, avec des intervalles majeurs de 2 et des intervalles mineurs de 0,5. L'exemple combine également le format de pourcentage avec [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) réglé sur mille, adaptez ces paramètres à la signification et à l'ampleur de vos données. La légende reste à l'extérieur de la zone de traçage parce que [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) est appelé avec `False`. Les remplissages du mur arrière et du plancher sont configurés via [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) et [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor), mais ces surfaces ne sont visibles que dans les graphiques 3D.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir les propriétés de police d’un graphique**

Définissez la taille de police par défaut pour le texte du graphique via [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat). L'exemple crée un graphique à barres groupées avec une police de 20 points et active les libellés de valeur pour la première série via [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Les éléments de texte disposant de leurs propres paramètres de police explicites peuvent remplacer le paramètre par défaut du graphique.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Réutiliser le formatage du cadre de texte pour la légende d’un graphique**

Pour faire correspondre une légende à un titre de diapositive, définissez la police du titre via [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) sur le premier paragraphe. Appelez [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) sur le format renvoyé par le [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) de la légende. Cela copie les paramètres du cadre de texte, le format du premier paragraphe et les propriétés de police par défaut de ce paragraphe. Le formatage appliqué directement à des portions individuelles ou à des paragraphes ultérieurs reste local à la source.

L'exemple utilise un titre en Calibri gras de 26 points en bleu marine comme modèle. Après avoir stylisé la légende, il appelle [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) pour appliquer le même formatage à une légende distincte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LegendPositionType, NullableBool, Presentation, SaveFormat, ShapeType, StyleType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, False)
    source_text_frame = heading.addTextFrame("Quarterly sales")
    paragraph = source_text_frame.getParagraphs().get_Item(0)
    font = paragraph.getParagraphFormat().getDefaultPortionFormat()
    font.setLatinFont(FontData("Calibri"))
    font.setFontHeight(26)
    font.setFontBold(NullableBool.True_)
    font.getFillFormat().setFillType(FillType.Solid)
    font.getFillFormat().getSolidFillColor().setColor(Color(32, 64, 96))

    chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360)
    chart.setStyle(StyleType.Style3)
    workbook = chart.getChartData().getChartDataWorkbook()
    for column, series_name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.getCell(0, 0, column).setValue(series_name)
    for quarter in range(1, 5):
        workbook.getCell(0, quarter, 0).setValue(f"Q{quarter}")

    chart.setLegend(True)
    legend = chart.getLegend()
    legend.setPosition(LegendPositionType.Bottom)
    legend_format = legend.getTextFormat()
    legend_format.copyFrom(source_text_frame)

    caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, False)
    caption_text_frame = caption.addTextFrame("Sales in millions of dollars")
    legend_format.copyTo(caption_text_frame)

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dans la présentation enregistrée, la légende et la légende secondaire correspondent au titre en taille, graisse et couleur. La légende affiche toujours les noms des séries, et la légende secondaire conserve son propre texte. Si une portion de la légende secondaire possède déjà une taille de police explicite, cette taille prime sur le paragraphe copié.

| Avant la copie | Après la copie |
| --- | --- |
| ![Graphique des ventes trimestrielles avec légendes noires régulières et légende noire](legend-formatting-before.png) | ![Même graphique avec légendes en bleu marine, plus grandes et en gras, et légende correspondante](legend-formatting.png) |

## **Définir le format numérique**

Utilisez [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) pour appliquer un format numérique intégré aux cellules du classeur du graphique. Cet exemple crée un graphique à barres groupées avec des données par défaut sauvegardées dans les cellules et applique l’indice de format 10 (`0.00%`) à chaque cellule de valeur de série. Cela modifie la façon dont les valeurs sont affichées dans le classeur sans changer les nombres sous-jacents ; par exemple, 0,25 s’affiche comme 25,00 %. Les formats des axes et des libellés de données peuvent être configurés séparément.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0,00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le tableau suivant répertorie les indices de formats numériques intégrés avec des formats Excel représentatifs pour la locale anglais (États‑Unis). Les chaînes de format exactes et leur affichage peuvent varier selon l’application et la locale, en particulier pour les devises et les dates. Certains formats Excel diffèrent également des valeurs par défaut du standard OOXML, comme indiqué dans les [notes d’implémentation du format numérique de Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Format |
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

## **Définir les bords arrondis de la zone du graphique**

Appelez [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) avec `True` pour arrondir les coins de la zone du graphique. L’exemple crée un graphique à barres groupées et utilise [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) pour donner à son contour une couleur grise unie et un style ligne simple avant d’enregistrer la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifier les annotations de graphique existantes**

Un graphique peut contenir des formes personnalisées, comme une annotation textuelle expliquant l’état d’un rapport. Accédez à ces formes via [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes). La collection renvoyée par [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) contient les formes appartenant au graphique.

Une zone de texte ordinaire placée au‑dessus d’un graphique appartient à la diapositive, même si elle ressemble à une partie du graphique. Parcourir [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) trouve le graphique ainsi que les formes ordinaires de la diapositive, mais n’énumère pas les formes individuelles à l’intérieur du graphique. Les titres de graphique et les libellés de données sont des éléments de graphique distincts, pas des annotations personnalisées dans cette collection.

Téléchargez [chart-annotations.pptx](chart-annotations.pptx) et placez‑le dans le répertoire de travail de l’application. Sa première diapositive contient un graphique avec une annotation non groupée affichant « Preliminary results », une ligne appartenant au graphique et une zone de texte ordinaire affichant « Slide overlay ». L’exemple trouve le premier graphique sur cette diapositive et modifie l’annotation en « Final results » lorsque le rapport est prêt à être publié. Il vérifie qu’une collection n’est pas vide et ne modifie qu’une [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) dont le cadre de texte n’est pas `None`, renvoyé par [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) et contenant le texte attendu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

La ligne et la zone de texte de la diapositive restent inchangées. Les images suivantes montrent l’entrée et le résultat enregistré, rouvert :

| Avant la modification | Après la modification |
| --- | --- |
| ![Annotation du graphique affichant Preliminary results](chart-annotations-before.png) | ![Annotation du graphique affichant Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
L’exemple n’inspecte que les formes de niveau supérieur appartenant au graphique. Si une annotation se trouve à l’intérieur d’un [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), inspectez également la collection [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) de ce groupe. Répétez cela récursivement pour les groupes imbriqués, en appliquant les mêmes vérifications de texte à leurs formes enfants. Un groupe lui‑même est un conteneur ; ne le traitez pas comme une zone de texte.
{{% /alert %}}

## **FAQ**

**Puis‑je définir des remplissages semi‑transparents pour les colonnes/zones tout en conservant le contour opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela est utile pour améliorer la lisibilité de la grille et des données dans des visualisations denses.

**Comment gérer les libellés de données lorsqu’ils se chevauchent ?**

Réduisez la taille de police, désactivez les composants de libellé non essentiels (par exemple, les catégories), ajustez la position du libellé, affichez les libellés uniquement pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages dégradés ou à motifs aux séries ?**

Oui. Les séries prennent en charge les remplissages unis, dégradés et à motifs. En pratique, utilisez les dégradés avec parcimonie et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.