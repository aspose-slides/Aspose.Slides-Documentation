---
title: Personnaliser les axes de graphique dans les présentations avec Python
linktitle: Axe du graphique
type: docs
url: /fr/python-java/chart-axis/
keywords:
- axe du graphique
- axe vertical
- axe horizontal
- personnaliser l'axe
- manipuler l'axe
- gérer l'axe
- propriétés de l'axe
- valeur maximale
- valeur minimale
- ligne d'axe
- format de date
- titre de l'axe
- position de l'axe
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment utiliser Aspose.Slides pour Python via Java afin de personnaliser les axes de graphique dans les présentations PowerPoint pour les rapports et les visualisations."
---
## **Vue d'ensemble**

Cet article explique comment personnaliser les axes des graphiques avec Aspose.Slides for Python via Java. Il couvre les valeurs d'axes calculées, le changement de lignes et de colonnes du graphique, la visibilité des axes, les intervalles d'étiquettes de catégorie et des graduations, les catégories de dates et leur formatage, la rotation du titre, le positionnement des axes, les unités d'affichage et le redimensionnement logarithmique.

## **Obtenir les valeurs maximales sur l'axe vertical d'un graphique**

Créez une [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) et ajoutez un graphique en aires avec les données par défaut. Appelez [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) avant de lire les valeurs d'axe calculées afin que la disposition du graphique soit à jour.

Lisez [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) et [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) pour les limites de l'axe, ainsi que [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) et [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) pour les intervalles des graduations. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) et [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) fournissent des échelles d'unité de temps, pertinentes pour les axes de date. L'exemple stocke ces valeurs dans des variables locales et enregistre le graphique.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Échanger les données entre les axes**

Utilisez [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) pour échanger les rôles des séries et des catégories dans les données du graphique. Chaque catégorie précédente devient une série, et chaque série précédente devient une catégorie. Cela modifie la façon dont les données sont groupées ; cela n'échange pas les axes horizontal et vertical. L'exemple utilise [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) pour associer les données par défaut à `Sheet1!A1:D5`, incluant la ligne d'en-tête et la colonne de catégories, avant d'échanger les lignes et les colonnes. Il enregistre un graphique avec quatre séries et trois catégories.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Inverser l'ordre de traçage d'un axe**

Utilisez [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) pour inverser un axe de catégorie ou de valeur. Par exemple, un graphique à barres horizontal peut afficher les étapes d'un projet de haut en bas dans le même ordre que la feuille de calcul : Planning, Development, Testing. Inverser un axe change la direction du tracé ; cela ne trie pas ni ne réarrange les données du classeur. En comparaison, [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) échange les rôles des séries et des catégories.

L'exemple suivant crée un graphique à barres horizontal avec trois étapes et une série. Il enregistre une présentation avec trois diapositives : ordre normal, catégories inversées et valeurs inversées. Chaque copie utilise le même jeu de données, et un seul axe est inversé dans chaque copie.

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Diapositive 2 : afficher la première catégorie en haut.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Conserver l'axe de valeur horizontal en bas.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Diapositive 3 : inverser uniquement l'échelle numérique horizontale.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Inverser un axe peut également déplacer l'axe perpendiculaire du côté opposé du tracé. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) contrôle où l'autre axe croise l'axe configuré. Dans la diapositive 2, l'appeler avec [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) sur l'axe de catégorie inversé maintient l'axe de valeur horizontal en bas. Pour un point de croisement spécifique, utilisez [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Vérifiez les paramètres de croisement lors du changement de direction, surtout si le graphique possède déjà un point de croisement personnalisé. Appelez [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) avec `False` pour rétablir la direction de tracé normale ; les paramètres de croisement sont séparés.

| Ordre normal (diapositive 1) | Catégories inversées (diapositive 2) | Valeurs inversées (diapositive 3) |
| --- | --- | --- |
| ![Graphique à barres horizontal avec ordre normal des axes de catégorie et de valeur](axis-order-normal.png) | ![Graphique à barres horizontal avec catégories affichées de haut en bas](axis-order-categories-reversed.png) | ![Graphique à barres horizontal avec un axe de valeur inversé et zéro à droite](axis-order-values-reversed.png) |
| Les catégories vont du bas vers le haut ; les valeurs augmentent de gauche à droite. | Planning, Development et Testing vont du haut vers le bas. Les valeurs et l'ordre des lignes du classeur restent inchangés. | Les catégories conservent leur ordre normal ; les valeurs augmentent de droite à gauche. L'axe de catégorie croise à zéro à droite. |

## **Désactiver l'axe vertical pour les graphiques en lignes**

Appelez [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) avec `False` sur l'axe vertical pour le masquer. L'exemple crée un graphique en courbes avec les données par défaut et l'enregistre avec l'axe vertical masqué.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Désactiver l'axe horizontal pour les graphiques en lignes**

Appelez [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) avec `False` sur l'axe horizontal pour le masquer. L'exemple crée un graphique en courbes avec les données par défaut et l'enregistre avec l'axe horizontal masqué.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifier un axe de catégorie**

Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) pour choisir un axe de catégorie de type date ou texte. Cet exemple nécessite `ExistingChart.pptx`, avec un graphique comme première forme sur la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il change l'axe horizontal en un axe de date. Appeler [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) avec `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) avec `1`, et [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) avec [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) place les graduations majeures à des intervalles d'un mois.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Contrôler les intervalles d'étiquettes d'axe de catégorie**

Lorsque un graphique possède de nombreuses catégories, réduisez le nombre d'étiquettes d'axe visibles sans enlever de catégories ni de points de données. Appelez [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) avec `False`, puis transmettez l'intervalle de catégorie souhaité à [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Pour les catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Étiquettes affichées dans l'exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, ... Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, ... Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, ... Catégorie 22 |

Un intervalle de `3` affiche chaque troisième étiquette, laissant deux étiquettes cachées entre les étiquettes affichées. Il ne supprime pas les colonnes correspondantes. L'espacement automatique choisit un intervalle en fonction de l'espace disponible ; il n'affiche pas nécessairement chaque étiquette.

Les graduations ont des contrôles séparés. Appelez [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) avec `False` et utilisez [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) pour définir leur intervalle. Par exemple, `1` conserve une graduation à chaque intervalle de catégorie tandis que les étiquettes n'apparaissent qu'à chaque troisième catégorie. Utilisez [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) avec un style visible afin de voir le résultat. Appeler de nouveau l'un des setters d'espacement automatique avec `True` laisse le graphique choisir à nouveau cet intervalle.

L'exemple autonome suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement manuel des étiquettes avec graduations indépendantes, et restauration de l'espacement automatique. Les deux copies conservent les données originales du graphique. aucune présentation d'entrée n'est requise. Le texte horizontal des étiquettes rend la différence de densité facile à voir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # Diapositive 2 : afficher chaque troisième étiquette, mais conserver une graduation pour chaque catégorie.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Diapositive 3 : laisser le graphique choisir à nouveau les deux intervalles.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Espacement automatique (diapositive 1) :** Dans ce rendu, chaque deuxième étiquette de catégorie est affichée et se répartit sur deux lignes. Le résultat automatique peut varier selon la taille du graphique, les polices et le moteur de rendu.

![Espacement automatique des étiquettes de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** Chaque troisième étiquette est affichée sur une ligne, tandis que les graduations restent à chaque intervalle de catégorie. Toutes les 24 colonnes, y compris celles sans étiquette, restent visibles avec les mêmes valeurs. La diapositive 3 restaure l'apparence automatique présentée ci‑dessus.

![Intervalle manuel d'étiquettes de catégorie de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir l'axe et l'intervalle corrects**

Utilisez cet intervalle de comptage de catégories pour un axe de catégorie texte, comme l'axe de catégorie d'un graphique en colonnes, en courbes, en aires ou à barres. Dans un graphique en colonnes, il s'agit de l'axe horizontal. Dans un graphique à barres horizontal, l'axe de catégorie est vertical, donc appliquez ces paramètres à l'axe renvoyé par [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). L'espacement des graduations s'applique également à un axe de série dans les graphiques qui en possèdent un.

Ne pas utiliser l'espacement des étiquettes de catégorie pour définir l'échelle numérique d'un axe de valeur. Sur un axe de valeur, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) spécifie une différence de valeurs : par exemple, une unité majeure de `10` produit des graduations à 0, 10, 20, etc. lorsqu'un axe débute à zéro. Un intervalle d'étiquette de catégorie de `3` compte les positions de catégorie, quel que soit leurs valeurs de données. Les graphiques de dispersion et de bulles utilisent des axes de valeur plutôt qu'un axe de catégorie texte. Pour un axe de date, utilisez des unités majeures basées sur le temps et des échelles comme décrit dans [Modifier un axe de catégorie](#change-a-category-axis).

## **Définir le format de date pour les valeurs d'axe de catégorie**

L'exemple remplace les données du graphique par défaut par quatre valeurs annuelles. Les dates sont stockées comme nombres de série OLE Automation dans la première feuille de calcul (index `0`), calculés comme le nombre de jours depuis le 30 décembre 1899, pour ces dates. Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) avec [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), appelez [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) avec `False`, et transmettez `yyyy` à [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) afin que les étiquettes de catégorie affichent les années sur quatre chiffres indépendamment du format de la cellule.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir un angle de rotation pour le titre d'un axe de graphique**

Appelez [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) avec `True` sur l'axe vertical, fournissez le texte du titre et définissez l'angle de rotation dans le formatage du bloc de texte du titre. L'angle est mesuré en degrés ; cet exemple enregistre un graphique en colonnes avec le titre de l'axe de valeur tourné de 90 degrés.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la position de l'axe sur un axe de catégorie ou de valeur**

Utilisez [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) pour contrôler si l'axe de valeur croise l'axe de catégorie entre les catégories ou aux marques de graduation de catégorie. Ce paramètre s'applique aux axes de catégorie. L'exemple le définit à `True` sur l'axe de catégorie horizontal d'un graphique en colonnes et enregistre le résultat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir l'unité d'affichage sur un axe de valeur de graphique**

Utilisez [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) pour mettre à l'échelle les étiquettes d'un axe de valeur sans modifier les données sous-jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) réglé sur `Millions`, une valeur de 60 000 000 est affichée comme 60. L'exemple crée un graphique en colonnes et applique l'unité d'affichage millions à son axe vertical.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Configurer un axe de valeur logarithmique**

Un axe de valeur logarithmique est utile lorsque des valeurs positives couvrent plusieurs ordres de grandeur. Par exemple, un service peut recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent proches les unes des autres près de zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Appelez [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) avec `True` sur l'axe de valeur et utilisez [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) pour choisir la base. Cela modifie la façon dont les valeurs existantes sont affichées ; cela ne modifie pas les données ni n'ajoute une courbe de tendance logarithmique. Une courbe de tendance représente une relation ajustée dans les données et constitue une fonctionnalité distincte.

### **Choisir l'axe de valeur et la base**

Pour un graphique en lignes ou en colonnes, l'axe de valeur est renvoyé par [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Pour un graphique à barres horizontal, il est renvoyé par [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Les graphiques de dispersion et de bulles ont deux axes de valeur, choisissez donc l'axe horizontal pour les valeurs X, l'axe vertical pour les valeurs Y, ou les deux. Ne pas appliquer le redimensionnement logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les graphiques PPTX, utilisez une base comprise entre `2` et `1000`, incluses ; les bases fractionnaires comme `2,5` sont également prises en charge. Avec la base `10`, les puissances successives comme 10, 100, 1 000 et 10 000 sont espacées de manière égale.

### **Comparer l'échelle linéaire et logarithmique**

L'exemple autonome suivant crée un graphique en lignes avec les cinq décomptes de requêtes sur la première diapositive, puis duplique cette diapositive et active un axe de valeur logarithmique base 10 sur la seconde. Les deux diapositives conservent les mêmes données.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Conserver la première diapositive en linéaire et ne modifier que l'échelle de l'axe de valeur de la copie.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Échelle linéaire (diapositive 1) :** Des distances verticales égales représentent des différences égales dans le nombre de requêtes. La valeur la plus élevée domine le graphique, rendant les valeurs plus petites difficiles à distinguer.

![Graphique en lignes dans PowerPoint montrant cinq décomptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2) :** Des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, ainsi les points forment une ligne droite ascendante sur l'échelle base 10. Les étiquettes de l'axe affichent toujours les décomptes de requêtes d'origine.

![Les mêmes cinq décomptes de requêtes dans PowerPoint sur un axe de valeur logarithmique base 10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l'activer. Si les valeurs zéro ou négatives sont significatives, conservez une échelle linéaire ou affichez‑les séparément. Si l'exclusion de ces valeurs est appropriée pour l'analyse, expliquez cette omission. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela modifie le sens des données. Tout minimum ou maximum configuré manuellement pour un axe logarithmique doit également être positif.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axe) ?**  
Utilisez [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) pour choisir le comportement de croisement. Pour spécifier une valeur de croisement numérique, utilisez [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Ces paramètres vous permettent de déplacer le point de croisement de l'axe vers une ligne de base appropriée.

**Comment positionner les étiquettes de graduation par rapport à l'axe ?**  
Appelez [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) en utilisant [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` ou `None`. Pour contrôler les graduations elles‑mêmes, utilisez [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) ou [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) ; elles sont séparées du positionnement des étiquettes.