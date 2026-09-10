---
title: Mise en forme des graphiques de présentation en Python
linktitle: Mise en forme des graphiques
type: docs
weight: 60
url: /fr/python-java/chart-formatting/
keywords:
- format graphique
- mise en forme de graphique
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
description: "Apprenez la mise en forme des graphiques dans Aspose.Slides pour Python via Java et améliorez votre présentation PowerPoint avec un style professionnel et attrayant."
---
## **Aperçu**

Cet article explique comment mettre en forme les graphiques dans les présentations PowerPoint en utilisant Aspose.Slides. Il montre comment personnaliser les éléments clés d’un graphique tels que les axes, les lignes de grille, les titres, les légendes, la zone de tracé et les remplissages des murs afin d’améliorer l’apparence et la lisibilité des données du graphique.

Il montre également comment définir les propriétés de police pour le texte du graphique, appliquer des formats numériques prédéfinis ou personnalisés aux données du graphique, et activer les coins arrondis pour la zone du graphique. Ensemble, ces exemples montrent comment contrôler à la fois le style visuel et la présentation des données d’un graphique dans une présentation.

## **Mettre en forme les entités du graphique**
Aspose.Slides for Python via Java permet aux développeurs d’ajouter des graphiques personnalisés à leurs diapositives à partir de zéro. Cet article explique comment mettre en forme différentes entités de graphique, y compris les axes de catégorie et de valeur.

Aspose.Slides for Python via Java fournit une API simple pour gérer différentes entités de graphique et les mettre en forme à l’aide de valeurs personnalisées :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Accédez à une diapositive par son index.
1. Ajoutez un graphique du type souhaité avec des données par défaut (cet exemple utilise [ChartType.LineWithMarkers](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Accédez à l’axe des valeurs du graphique et définissez les propriétés suivantes :
   1. Définissez le **format de ligne** pour les lignes de grille majeures de l’axe des valeurs.
   1. Définissez le **format de ligne** pour les lignes de grille mineures de l’axe des valeurs.
   1. Définissez le **format numérique** pour l’axe des valeurs.
   1. Définissez le **minimum, le maximum, les unités majeures et mineures** pour l’axe des valeurs.
   1. Définissez les **propriétés de texte** pour les données de l’axe des valeurs.
   1. Définissez le **titre** de l’axe des valeurs.
1. Accédez à l’axe de catégorie du graphique et définissez les propriétés suivantes :
   1. Définissez le **format de ligne** pour les lignes de grille majeures de l’axe de catégorie.
   1. Définissez le **format de ligne** pour les lignes de grille mineures de l’axe de catégorie.
   1. Définissez les **propriétés de texte** pour les données de l’axe de catégorie.
   1. Définissez le **titre** de l’axe de catégorie.
   1. Définissez le **positionnement des étiquettes** pour l’axe de catégorie.
   1. Définissez l’**angle de rotation** des étiquettes de l’axe de catégorie.
1. Accédez à la légende du graphique et définissez ses **propriétés de texte**.
1. Affichez la légende du graphique sans qu’elle chevauche le graphique.
1. Accédez à l’**axe des valeurs secondaire** du graphique et définissez les propriétés suivantes :
   1. Activez l’**axe des valeurs** secondaire.
   1. Définissez le **format de ligne** pour l’axe des valeurs secondaire.
   1. Définissez le **format numérique** pour l’axe des valeurs secondaire.
   1. Définissez le **minimum, le maximum, les unités majeures et mineures** pour l’axe des valeurs secondaire.
1. Tracez la première série du graphique sur l’axe des valeurs secondaire.
1. Définissez la couleur de remplissage du mur arrière du graphique.
1. Définissez la couleur de remplissage de la zone de tracé du graphique.
1. Écrivez la présentation modifiée dans un fichier PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Créer une instance de la classe Presentation
presentation = Presentation()
try:
    # Accéder à la première diapositive
    slide = presentation.getSlides().get_Item(0)

    # Ajouter le graphique d'exemple
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Définir le titre du graphique
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Définir le format des lignes de grille majeures pour l'axe des valeurs
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Définir le format des lignes de grille mineures pour l'axe des valeurs
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Définir le format numérique de l'axe des valeurs
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Définir les valeurs maximale et minimale du graphique
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Définir les propriétés de texte de l'axe des valeurs
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Définir le titre de l'axe des valeurs
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Définir le format des lignes de grille majeures pour l'axe des catégories
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Définir le format des lignes de grille mineures pour l'axe des catégories
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Définir les propriétés de texte de l'axe des catégories
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Définir le titre de la catégorie
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Définir la position des étiquettes de l'axe des catégories
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Définir l'angle de rotation des étiquettes de l'axe des catégories
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Définir les propriétés de texte de la légende
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Afficher la légende du graphique sans chevaucher le graphique

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Définir l'axe des valeurs secondaire
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Définir le format numérique de l'axe des valeurs secondaire
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Définir les valeurs maximale et minimale du graphique
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Définir la couleur du mur arrière du graphique
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Définir la couleur de la zone de tracé
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Enregistrer la présentation
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir les propriétés de police pour un graphique**
Aspose.Slides for Python via Java prend en charge la définition des propriétés de police pour les graphiques. Suivez ces étapes pour définir les propriétés de police :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
- Ajoutez un graphique à la diapositive.
- Définissez la hauteur de la police.
- Enregistrez la présentation modifiée.

L’exemple suivant illustre ces étapes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Créer une instance de la classe Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir le format numérique**
Aspose.Slides for Python via Java fournit une API simple pour gérer les formats de données des graphiques :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Accédez à une diapositive par son index.
1. Ajoutez un graphique du type souhaité avec des données par défaut (cet exemple utilise [ChartType.ClusteredColumn](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Définissez le format numérique prédéfini parmi les valeurs prédéfinies possibles.
1. Parcourez les cellules de données de chaque série du graphique et définissez leur format numérique.
1. Enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Créer une instance de la classe Presentation
presentation = Presentation()
try:
    # Accéder à la première diapositive de la présentation
    slide = presentation.getSlides().get_Item(0)

    # Ajouter un graphique à colonnes groupées par défaut
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Accéder à la collection des séries du graphique
    chart_series_collection = chart.getChartData().getSeries()

    # Parcourir chaque série du graphique
    for chart_series in chart_series_collection:
        # Parcourir chaque point de données de la série
        for data_point in chart_series.getDataPoints():
            # Définir le format numérique
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Enregistrer la présentation
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les formats numériques prédéfinis disponibles et leurs indices sont répertoriés ci‑dessous :

|**0**|Général|
| :- | :- |
|**1**|0|
|**2**|0,00|
|**3**|#,##0|
|**4**|#,##0,00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0,00;$-#,##0,00|
|**8**|$#,##0,00;Red$-#,##0,00|
|**9**|0%|
|**10**|0,00%|
|**11**|0,00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|jj/mm/aa|
|**15**|j‑mmm‑aa|
|**16**|j‑mmm|
|**17**|mmm‑aa|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|jj/mm/aa h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0,00;-#,##0,00|
|**40**|#,##0,00;Red-#,##0,00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0,00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0,00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0,0E+00|
|**49**|@|

## **Définir des bordures arrondies pour la zone du graphique**
Aspose.Slides for Python via Java prend en charge les coins arrondis pour la zone du graphique via les méthodes [hasRoundedCorners](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#hasRoundedCorners) et [setRoundedCorners](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#setRoundedCorners) de la classe [Chart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/).

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajoutez un graphique à la diapositive.
1. Définissez le type de remplissage et le style de la ligne de bordure du graphique.
1. Activez les coins arrondis.
1. Enregistrez la présentation modifiée.

L’exemple suivant montre ces étapes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Créer une instance de la classe Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je appliquer des remplissages semi‑transparents aux colonnes/aires tout en conservant le contour opaque ?**

Oui. La transparence du remplissage et le contour sont configurés séparément. Cela permet d’améliorer la lisibilité de la grille et des données dans les visualisations denses.

**Comment gérer les étiquettes de données lorsqu’elles se chevauchent ?**

Réduisez la taille de la police, désactivez les composants d’étiquette non essentiels (par exemple, les catégories), définissez le décalage/la position de l’étiquette, n’affichez les étiquettes que pour les points sélectionnés si nécessaire, ou passez au format « valeur + légende ».

**Puis‑je appliquer des remplissages en dégradé ou en motif aux séries ?**

Oui. Les remplissages unis ainsi que les dégradés ou motifs sont généralement disponibles. En pratique, utilisez les dégradés avec modération et évitez les combinaisons qui réduisent le contraste avec la grille et le texte.