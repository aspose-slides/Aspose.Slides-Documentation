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

Cet article explique comment personnaliser les axes des graphiques avec Aspose.Slides for Python via Java. Il couvre les valeurs d'axe calculées, l'échange des lignes et colonnes du graphique, la visibilité des axes, les intervalles des libellés de catégorie et des graduations, les catégories de date et leur formatage, la rotation du titre, le positionnement des axes, les unités d'affichage et le redimensionnement logarithmique.

## **Obtenir les valeurs maximales sur l'axe vertical d'un graphique**

Créez une [Présentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) et ajoutez un graphique en aires avec les données par défaut. Appelez [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) avant de lire les valeurs d'axe calculées afin que la disposition du graphique soit à jour.

Lisez [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) et [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) pour les limites de l'axe, ainsi que [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) et [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) pour les intervalles des graduations. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) et [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) fournissent des échelles d'unités de temps, pertinents pour les axes de date. L'exemple stocke ces valeurs dans des variables locales et enregistre le graphique.

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

Utilisez [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) pour permuter les rôles des séries et des catégories dans les données du graphique. Chaque ancienne catégorie devient une série, et chaque ancienne série devient une catégorie. Cela modifie le regroupement des données ; cela n'échange pas les axes horizontal et vertical. L'exemple utilise [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) pour lier les données par défaut à `Sheet1!A1:D5`, en incluant la ligne d'en-tête et la colonne des catégories, avant d'échanger les lignes et colonnes. Il enregistre un graphique avec quatre séries et trois catégories.

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

## **Inverser l'ordre de tracé d'un axe**

Utilisez [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) pour inverser un axe de catégorie ou de valeur. Par exemple, un graphique à barres horizontal peut afficher les étapes d'un projet de haut en bas dans le même ordre que la feuille de calcul : Planification, Développement, Test. Inverser un axe change la direction du tracé ; cela ne trie pas ni ne réarrange les données du classeur. En comparaison, [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) échange les rôles des séries et des catégories.

L'exemple suivant crée un graphique à barres horizontal avec trois étapes et une série. Il enregistre une présentation avec trois diapositives : ordre normal, catégories inversées et valeurs inversées. Chaque copie utilise le même jeu de données, et un seul axe est inversé dans chaque copie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
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

    # Diapositive 3 : inverser uniquement l'echelle numerique horizontale.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Inverser un axe peut également déplacer l'axe perpendiculaire du côté opposé du tracé. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) contrôle où l'autre axe traverse l'axe configuré. Dans la diapositive 2, l'appeler avec [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) sur l'axe de catégorie inversé maintient l'axe de valeur horizontal en bas. Pour un point de traversée spécifique, utilisez [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Vérifiez les paramètres de traversée lors du changement de direction, surtout si le graphique possède déjà un point de traversée personnalisé. Appelez [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) avec `False` pour rétablir la direction de tracé normale ; les paramètres de traversée sont séparés.

| Ordre normal (diapositive 1) | Catégories inversées (diapositive 2) | Valeurs inversées (diapositive 3) |
| --- | --- | --- |
| ![Graphique à barres horizontal avec ordre normal des axes de catégorie et de valeur](axis-order-normal.png) | ![Graphique à barres horizontal avec les catégories affichées de haut en bas](axis-order-categories-reversed.png) | ![Graphique à barres horizontal avec un axe de valeur inversé et zéro à droite](axis-order-values-reversed.png) |
| Les catégories vont du bas vers le haut ; les valeurs augmentent de gauche à droite. | Planification, Développement et Test s'affichent de haut en bas. Les valeurs et l'ordre des lignes du classeur restent inchangés. | Les catégories conservent leur ordre normal ; les valeurs augmentent de droite à gauche. L'axe de catégorie croise à zéro à droite. |

## **Masquer l'axe vertical pour les graphiques en courbes**

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

## **Masquer l'axe horizontal pour les graphiques en courbes**

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

## **Afficher ou masquer les quadrillages du graphique**

Appelez [getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) et [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines) pour vérifier quels quadrillages un axe affiche. Pour afficher les quadrillages mineurs, utilisez [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) et définissez le remplissage de ligne sur une couleur solide et visible. Pour les masquer, définissez le remplissage sur [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill). Utilisez [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) de la même façon pour les quadrillages majeurs. Modifier le remplissage préserve la visibilité de l'axe et des graduations.

L'axe vertical de ce graphique à colonnes groupées affiche initialement seulement les quadrillages majeurs. L'exemple affiche les quadrillages mineurs en orange foncé, puis les masque à nouveau avant d'enregistrer la présentation. Il imprime la visibilité du quadrillage à chaque étape.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230)
    axis = chart.getAxes().getVerticalAxis()
    print(f"Initial: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    minor_fill = axis.getMinorGridLinesFormat().getLine().getFillFormat()
    minor_fill.setFillType(FillType.Solid)
    minor_fill.getSolidFillColor().setColor(Color(255, 140, 0))
    print(f"Enabled: minor={axis.getShowMinorGridLines()}")

    minor_fill.setFillType(FillType.NoFill)
    print(f"Hidden: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Quadrillages mineurs affichés | Quadrillages mineurs masqués |
| --- | --- |
| ![Quadrillages mineurs orange entre les quadrillages majeurs sur l'axe vertical](minor-gridlines-enabled.png) | ![Le même graphique à colonnes avec uniquement les quadrillages majeurs visibles](minor-gridlines-hidden.png) |

## **Modifier un axe de catégorie**

Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) pour choisir un axe de catégorie date ou texte. Cet exemple nécessite `ExistingChart.pptx`, avec un graphique en première forme de la première diapositive et des cellules de catégorie contenant des valeurs de date Excel numériques. Il change l'axe horizontal en axe de date. Appeler [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) avec `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) avec `1`, et [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) avec [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) place les graduations majeures à des intervalles d'un mois.

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

### **Déterminer le type d'axe de catégorie à partir des données**

Appelez [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) après avoir rempli les catégories, puis lisez [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) pour inspecter la sélection. Cela est utile lorsqu'un même graphique reçoit soit des libellés texte, soit des valeurs de date numériques. La méthode détermine le type lors de l'appel ; elle n'active pas un mode persistant qui réévalue les changements de données ultérieurs. Rappelez‑la après avoir remplacé les catégories.

L'exemple suivant crée un graphique avec des catégories texte et imprime `True` lorsque le type sélectionné est [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text). Il remplace ensuite les valeurs de cellule de catégorie par des dates et rappelle la méthode, imprimant `True` lorsque le type sélectionné est [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date). Les dates sont stockées comme valeurs numériques OLE Automation, calculées comme le nombre de jours depuis le 30 decembre 1899, et non comme des chaînes de caractères. [setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) contrôle l'affichage de ces valeurs ; il ne convertit pas le texte en dates numériques. Pour plus d'informations sur les cellules de catégorie, voir [Chart Workbook](/slides/fr/python-java/chart-workbook/).

Utilisez la détermination automatique lorsque l’entrée est connue pour contenir des catégories texte ou des dates numériques, comme dans cet exemple. Pour des libellés numériques ordinaires, des catégories mixtes ou des données vides, appelez explicitement [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) afin de correspondre au sens attendu. Des valeurs numériques seules n'établissent pas que les catégories représentent des dates.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CategoryAxisType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series_name = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.getCell(0, i + 1, 0, label)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # Vrai

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # Vrai

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Contrôler les intervalles des libellés d'axe de catégorie**

Lorsqu'un graphique possède de nombreuses catégories, réduisez le nombre de libellés d'axe visibles sans supprimer les catégories ni les points de données. Appelez [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) avec `False`, puis transmettez l'intervalle de catégorie souhaité à [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Pour des catégories texte dans leur ordre normal, le comptage commence à la première catégorie :

| Intervalle | Libellés affichés dans l'exemple |
| --- | --- |
| `1` | Catégorie 1, Catégorie 2, Catégorie 3, … Catégorie 24 |
| `2` | Catégorie 1, Catégorie 3, Catégorie 5, … Catégorie 23 |
| `3` | Catégorie 1, Catégorie 4, Catégorie 7, … Catégorie 22 |

Un intervalle de `3` affiche chaque troisième libellé, en laissant deux libellés masqués entre deux libellés affichés. Cela ne supprime pas les colonnes correspondantes. L'espacement automatique choisit un intervalle selon l'espace disponible ; il n'affiche pas nécessairement chaque libellé.

Les graduations ont des contrôles séparés. Appelez [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) avec `False` et utilisez [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) pour définir leur intervalle. Par exemple, `1` conserve une graduation à chaque intervalle de catégorie tandis que les libellés n'apparaissent qu'à chaque troisième catégorie. Utilisez [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) avec un style visible pour voir le résultat. Repasser l'un des réglages d'espacement automatique à `True` permet au graphique de choisir à nouveau cet intervalle.

L'exemple auto‑contenu suivant crée 24 catégories et une série, puis enregistre trois diapositives dans `CategoryAxisIntervals.pptx` : espacement automatique, espacement manuel des libellés avec graduations indépendantes, et rétablissement de l'espacement automatique. Les deux copies conservent les données d'origine du graphique. Aucune présentation d'entrée n'est requise. Le texte des libellés horizontaux rend la différence de densité facilement visible.

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

    # Diapositive 2 : afficher chaque troisième libellé, mais conserver une graduation pour chaque catégorie.
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

**Espacement automatique (diapositive 1) :** Dans ce rendu, chaque deuxième libellé de catégorie est affiché et passe à la ligne. Le résultat automatique peut varier selon la taille du graphique, les polices et le moteur de rendu.

![Espacement automatique des libellés de catégorie avec les 24 colonnes visibles](category-axis-automatic.png)

**Espacement manuel (diapositive 2) :** Chaque troisième libellé est affiché sur une seule ligne, tandis que les graduations restent à chaque intervalle de catégorie. Les 24 colonnes, y compris celles sans libellés, restent visibles avec les mêmes valeurs. La diapositive 3 rétablit l'apparence automatique montrée ci‑dessus.

![Intervalle manuel de libellés de catégorie de trois avec les 24 colonnes visibles](category-axis-manual.png)

### **Choisir le bon axe et intervalle**

Utilisez cet intervalle basé sur le nombre de catégories pour un axe de catégorie texte, tel que l'axe de catégorie d'un graphique en colonnes, en lignes, en aires ou en barres. Dans un graphique en colonnes, il s'agit de l'axe horizontal. Dans un graphique à barres horizontal, l'axe de catégorie est vertical, appliquez donc ces réglages à l'axe retourné par [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). L'espacement des graduations s'applique également à un axe de série dans les graphiques qui en possèdent un.

N'utilisez pas l'espacement des libellés de catégorie pour définir l'échelle numérique d'un axe de valeur. Sur un axe de valeur, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) spécifie une différence de valeurs : par exemple, une unité majeure de `10` crée des graduations à 0, 10, 20, etc. lorsqu'il commence à zéro. Un intervalle de libellé de catégorie de `3` compte les positions de catégorie, quel que soit leur valeur. Les graphiques de dispersion et à bulles utilisent des axes de valeur plutôt qu'un axe de catégorie texte. Pour un axe de date, utilisez les unités majeures et les échelles basées sur le temps comme décrit dans [Modifier un axe de catégorie](#modifier-un-axe-de-catégorie).

## **Définir le format de date pour les valeurs d'axe de catégorie**

L'exemple remplace les données de graphique par défaut par quatre valeurs annuelles. Les dates sont stockées comme des numéros de série OLE Automation dans la première feuille de calcul (index `0`), calculées comme le nombre de jours depuis le 30 décembre 1899. Utilisez [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) avec [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), appelez [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) avec `False`, et transmettez `yyyy` à [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) afin que les libellés de catégorie affichent les années sur quatre chiffres indépendamment du format de cellule.

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

Appelez [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) avec `True` sur l'axe vertical, fournissez le texte du titre, et définissez l'angle de rotation dans le format du bloc de texte du titre. L'angle est mesuré en degrés ; cet exemple enregistre un graphique à colonnes avec le titre de l'axe de valeur pivoté à 90 degrés.

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

Utilisez [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) pour contrôler si l'axe de valeur croise l'axe de catégorie entre les catégories ou aux graduations de catégorie. Ce réglage s'applique aux axes de catégorie. L'exemple le définit sur `True` pour l'axe de catégorie horizontal d'un graphique en colonnes et enregistre le résultat.

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

Utilisez [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) pour mettre à l'échelle les libellés d'un axe de valeur sans modifier les données sous‑jacentes. Avec [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) réglé sur `Millions`, une valeur de 60 000 000 s'affiche comme 60. L'exemple crée un graphique à colonnes et applique l'unité d'affichage millions à son axe vertical.

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

Un axe de valeur logarithmique est utile lorsque des valeurs positives s'étalent sur plusieurs ordres de grandeur. Par exemple, un service peut recevoir 10, 100, 1 000, 10 000 et 100 000 requêtes sur cinq périodes. Sur une échelle linéaire, les petites valeurs apparaissent très proches du zéro. Une échelle logarithmique rend leur croissance relative plus facile à comparer : des distances égales représentent des rapports égaux plutôt que des différences égales.

Appelez [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) avec `True` sur l'axe de valeur et utilisez [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) pour choisir la base. Cela modifie l'affichage des valeurs existantes ; cela ne change pas les données ni n'ajoute de courbe de tendance logarithmique. Une courbe de tendance représente une relation ajustée aux données et constitue une fonctionnalité distincte.

### **Choisir l'axe de valeur et la base**

Pour un graphique en lignes ou en colonnes, l'axe de valeur est retourné par [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Pour un graphique à barres horizontal, il est retourné par [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Les graphiques de dispersion et à bulles ont deux axes de valeur, choisissez donc l'axe horizontal pour les valeurs X, l'axe vertical pour les valeurs Y, ou les deux. N'appliquez pas le redimensionnement logarithmique à un axe de catégorie.

La base logarithmique par défaut est `10`. Pour les graphiques PPTX, utilisez une base comprise entre `2` et `1000`, incluses ; les bases fractionnaires comme `2.5` sont également prises en charge. Avec la base `10`, les puissances successives telles que 10, 100, 1 000 et 10 000 sont espacées de façon égale.

### **Comparer l'échelle linéaire et logarithmique**

L'exemple auto‑contenu suivant crée un graphique en lignes avec les cinq comptes de requêtes sur la première diapositive, puis duplique cette diapositive et active un axe de valeur logarithmique base 10 sur la seconde. Les deux diapositives conservent les mêmes données.

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

**Échelle linéaire (diapositive 1) :** Des distances verticales égales représentent des différences égales dans le nombre de requêtes. La valeur la plus élevée domine le graphique, rendant les plus petites difficiles à distinguer.

![Graphique en lignes PowerPoint montrant cinq comptes de requêtes sur un axe de valeur linéaire](value-axis-linear.png)

**Échelle logarithmique (diapositive 2) :** Des distances verticales égales représentent des rapports égaux. Chaque période a dix fois plus de requêtes que la précédente, de sorte que les points forment une ligne droite ascendante sur l'échelle base 10. Les libellés d'axe affichent toujours les comptes de requêtes d'origine.

![Les mêmes cinq comptes de requêtes PowerPoint sur un axe de valeur logarithmique base 10](value-axis-logarithmic.png)

### **Gérer les valeurs zéro et négatives**

Une échelle logarithmique ne peut afficher que des valeurs strictement positives. Vérifiez les données avant de l'activer. Si les valeurs zéro ou négatives sont pertinentes, conservez une échelle linéaire ou affichez‑les séparément. Si leur exclusion est appropriée pour l'analyse, expliquez‑en la raison. Ne les remplacez pas silencieusement par de petits nombres positifs, car cela modifierait le sens des données. Tout minimum ou maximum configuré manuellement pour un axe logarithmique doit également être positif.

## **FAQ**

**Comment définir la valeur à laquelle un axe croise l'autre (croisement d'axe) ?**

Utilisez [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) pour sélectionner le comportement du croisement. Pour spécifier une valeur de croisement numérique, utilisez [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Ces paramètres vous permettent de déplacer le croisement de l'axe vers une ligne de base appropriée.

**Comment positionner les libellés de graduation par rapport à l'axe ?**

Appelez [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) en utilisant [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) : `Low`, `High`, `NextTo` ou `None`. Pour contrôler les graduations elles‑mêmes, utilisez [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) ou [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) ; ils sont séparés du positionnement des libellés.